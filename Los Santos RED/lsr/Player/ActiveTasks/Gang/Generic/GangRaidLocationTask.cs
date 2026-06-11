using ExtensionsMethods;
using LosSantosRED.lsr.Interface;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LosSantosRED.lsr.Player.ActiveTasks
{
    public class GangRaidLocationTask : GangTask, IPlayerTask
    {
        private GangDen HiringGangDen;
        private RaidLocation RaidLocation;
        private Gang TargetGang;
        private bool HasArrivedNearRaid;
        private bool HasSpawnedRaidGang;
        private uint GameTimeLastAssaultSpawn;
        private bool HasMetObjective;
        private List<GangMember> SpawnedMembers = new List<GangMember>();
        private List<GangMember> DefenderMembers = new List<GangMember>();
        private List<GangMember> ConfirmedDeadDefenders = new List<GangMember>();
        private const uint TimeBetweenAssaultSpawns = 30000;
        private const float MinAssaultSpawnDistanceToPlayer = 5f;

        public GangRaidLocationTask(ITaskAssignable player, ITimeReportable time, IGangs gangs, IPlacesOfInterest placesOfInterest, ISettingsProvideable settings, IEntityProvideable world,
            ICrimes crimes, IWeapons weapons, INameProvideable names, IPedGroups pedGroups, IShopMenus shopMenus, IModItems modItems, PlayerTasks playerTasks, GangTasks gangTasks,
            PhoneContact hiringContact, Gang hiringGang, RaidLocation raidLocation)
            : base(player, time, gangs, placesOfInterest, settings, world, crimes, weapons, names, pedGroups, shopMenus, modItems, playerTasks, gangTasks, hiringContact, hiringGang)
        {
            DebugName = "Raid Location";
            RepOnCompletion = 500;
            DebtOnFail = 0;
            RepOnFail = -250;
            DaysToComplete = 2;
            RaidLocation = raidLocation;
        }

        public override void Dispose()
        {
            CleanupPeds();
            if (RaidLocation != null)
            {
                RaidLocation.IsPlayerInterestedInLocation = false;
                RaidLocation.SetRaidMissionActive(false);
                if (RaidLocation.Interior != null && RaidLocation.Interior.IsTeleportEntry)
                {

                }
            }
            base.Dispose();
        }

        protected override bool GetTaskData()
        {
            HiringGangDen = PlacesOfInterest.GetMainDen(HiringGang.ID, World.IsMPMapLoaded, Player.CurrentLocation);
            if (HiringGangDen == null)
            {
                return false;
            }
            if (RaidLocation == null)
            {
                RaidLocation = PlacesOfInterest.PossibleLocations.RaidTaskLocations()
                    .Where(x => x.IsCorrectMap(World.IsMPMapLoaded) && x.IsSameState(Player.CurrentLocation?.CurrentZone?.GameState))
                    .Cast<RaidLocation>()
                    .Where(x =>
                    {
                        Gang associatedGang = Gangs.GetGang(x.AssociationID);
                        if (associatedGang == null || associatedGang.ID == HiringGang.ID)
                        {
                            return false;
                        }

                        GangReputation relation = Player.RelationshipManager.GangRelationships.GetReputation(associatedGang);

                        return relation.GangRelationship != GangRespect.Friendly && !relation.IsMember;
                    })
                    .PickRandom();
            }
            if (RaidLocation == null)
            {
                return false;
            }
            TargetGang = Gangs.GetGang(RaidLocation.AssociationID);
            if (TargetGang == null || TargetGang.ID == HiringGang.ID)
            {
                return false;
            }
            return true;
        }

        protected override void GetPayment()
        {
            PaymentAmount = RandomItems.GetRandomNumberInt(HiringGang.RaidPaymentMin, HiringGang.RaidPaymentMax).Round(250);//500
            if (PaymentAmount <= 0)
            {
                PaymentAmount = 500;//500
            }
        }

        protected override void SendInitialInstructionsMessage()
        {
            List<string> Replies = new List<string>() {
                $"{TargetGang.ColorPrefix}{TargetGang.ShortName}~s~ are around ~p~{RaidLocation.Name}~s~ on ~y~{RaidLocation.FullStreetAddress}~s~. Clear them out for ${PaymentAmount}."
                //$"Raid set. {TargetGang.ColorPrefix}{TargetGang.ShortName}~s~ are around ~p~{RaidLocation.Name}~s~ on ~y~{RaidLocation.FullStreetAddress}~s~. Clear them out and get back to the {HiringGang.DenName} on {HiringGangDen.FullStreetAddress}. ${PaymentAmount}"
            };
            Player.CellPhone.AddPhoneResponse(HiringGang.Contact.Name, HiringGang.Contact.IconName, Replies.PickRandom());
        }

        protected override void AddTask()
        {
            if (RaidLocation != null)
            {
                RaidLocation.IsPlayerInterestedInLocation = true;
                RaidLocation.SetRaidMissionActive(true);
            }
            base.AddTask();

            CurrentTask = PlayerTasks.GetTask(HiringGang.ContactName);
            if (CurrentTask != null)
            {
                CurrentTask.FailOnStandardRespawn = true;
            }
        }

        protected override void Loop()
        {
            EntryPoint.WriteToConsole("Raid Location Loop Start");
            while (true)
            {
                CurrentTask = PlayerTasks.GetTask(HiringGang.ContactName);
                if (CurrentTask == null || !CurrentTask.IsActive)
                {
                    break;
                }

                // FAILURE: Player ran away before clearing defenders
                if (HasArrivedNearRaid && !HasMetObjective && RaidLocation.DistanceToPlayer > 200f)
                {
                    EntryPoint.WriteToConsole("RAID LOCATION TASK FAILED - PLAYER LEFT AREA BEFORE CLEARING");
                    SetFailed();
                    break;
                }

                if (!HasArrivedNearRaid && RaidLocation.EntrancePosition.DistanceTo2D(Player.Character.Position) <= 15f)
                {
                    if (RaidLocation.IsPlayerInterestedInLocation)
                    {
                        OnArrivedNearRaid();
                    }
                }

                if (!HasSpawnedRaidGang && RaidLocation.HasRaidStarted)
                {
                    SpawnRaidGang();
                }

                if (HasSpawnedRaidGang)
                {

                    TrackNeutralizedDefenders();

                    if (!HasMetObjective && AreDefendersNeutralized())
                    {
                        HasMetObjective = true;
                        CurrentTask.OnReadyForPayment(true, "Raid defenders cleared. Leave the location when you are done.");
                        EntryPoint.WriteToConsole($"RAID LOCATION DEFENDERS CLEARED {ConfirmedDeadDefenders.Count}/{DefenderMembers.Count}");
                    }

                    if (HasMetObjective && !IsPlayerInsideRaidLocation())
                    {
                        break;
                    }

                    TrySpawnAssaultBackup();
                }
                GameFiber.Sleep(1000);
            }
        }

        protected override void FinishTask()
        {
            if (CurrentTask != null && CurrentTask.IsActive && CurrentTask.IsReadyForPayment)
            {
                PlayerTasks.CompleteTask(HiringContact, true);
                OnTaskCompletedOrFailed();
            }
            else if (CurrentTask != null && CurrentTask.IsActive)
            {
                SetFailed();
            }
            else
            {
                Dispose();
            }
        }

        private void OnArrivedNearRaid()
        {
            HasArrivedNearRaid = true;
            Game.DisplayHelp($"Enter {RaidLocation.Name} to start the raid.");
            EntryPoint.WriteToConsole($"RAID LOCATION PLAYER HAS ARRIVED NEAR LOCATION {RaidLocation.Name}");
        }

        private void SpawnRaidGang()
        {
            EntryPoint.WriteToConsole("RAID LOCATION START SPAWN DEFENDERS");
            List<ConditionalLocation> spawnLocations = GetRaidSpawnLocations();
            if (!spawnLocations.Any())
            {
                spawnLocations.Add(new GangConditionalLocation(RaidLocation.EntrancePosition, RaidLocation.EntranceHeading, 100f) { AssociationID = RaidLocation.AssociationID });
            }

            foreach (ConditionalLocation conditionalLocation in spawnLocations)
            {
                SpawnRaidGangMember(conditionalLocation, false, true);
            }
            HasSpawnedRaidGang = SpawnedMembers.Any();
            if (HasSpawnedRaidGang)
            {
                GameTimeLastAssaultSpawn = Game.GameTime;
                Game.DisplaySubtitle($"{TargetGang.ColorPrefix}{TargetGang.ShortName}~s~ are defending the stash house.");
            }
        }

        private bool SpawnRaidGangMember(ConditionalLocation conditionalLocation, bool isAssaultSquad = false, bool isDefender = false)
        {
            SpawnLocation spawnLocation = new SpawnLocation(conditionalLocation.Location, conditionalLocation.Heading) { StreetPosition = conditionalLocation.Location };
            DispatchablePerson dispatchablePerson = TargetGang.GetRandomPed(0, conditionalLocation.RequiredPedGroup);
            if (dispatchablePerson == null)
            {
                return false;
            }
            GangSpawnTask gangSpawnTask = new GangSpawnTask(TargetGang, spawnLocation, null, dispatchablePerson, Settings.SettingsManager.GangSettings.ShowSpawnedBlip, Settings, Weapons, Names, false, Crimes, PedGroups, ShopMenus, World, ModItems, conditionalLocation.ForceMelee, conditionalLocation.ForceSidearm, conditionalLocation.ForceLongGun);
            gangSpawnTask.PlacePedOnGround = true;
            gangSpawnTask.AllowAnySpawn = true;
            gangSpawnTask.AllowBuddySpawn = false; // Prevent duplicate spawns on top of each other.
            gangSpawnTask.IsHitSquad = isAssaultSquad;
            gangSpawnTask.IsGeneralBackup = !isAssaultSquad;
            gangSpawnTask.SpawnRequirement = conditionalLocation.TaskRequirements;
            gangSpawnTask.AttemptSpawn();
            foreach (GangMember gm in gangSpawnTask.CreatedPeople)
            {
                conditionalLocation.AddLocationRequirements(gm);
                //if (Settings.SettingsManager.TaskSettings.ShowEntityBlips) // Optional Blips for spawned entities, not needed for stash house raid defense peds but would be helpful in open world spawning situations.
                //{
                //    gm.AddBlip();
                //}
                gm.CombatMovement = 1; // 1 - I'm a Defender  0 - Don't move punk!
                //gm.CombatRange = 0; // keeps within 5-15m - Ok for small stash house interiors but need to consider larger interiors
                gm.IsHitSquad = isAssaultSquad;
                gm.IsGeneralBackup = !isAssaultSquad;
                gm.HatesPlayer = true;
                gm.WillFight = true;
                gm.WillAlwaysFightPolice = true;
                gm.WillFightPolice = true;
                SpawnedMembers.Add(gm);
                if (isDefender)
                {
                    DefenderMembers.Add(gm);
                }
            }
            return gangSpawnTask.CreatedPeople.Any();
        }

        private void TrySpawnAssaultBackup()
        {
            if (!IsPlayerInsideRaidLocation() || RaidLocation.TotalAssaultSpawns >= RaidLocation.MaxAssaultSpawns || RaidLocation.AssaultSpawnLocations == null || !RaidLocation.AssaultSpawnLocations.Any())
            {
                return;
            }
            if (GameTimeLastAssaultSpawn != 0 && Game.GameTime - GameTimeLastAssaultSpawn < TimeBetweenAssaultSpawns)
            {
                return;
            }
            List<SpawnPlace> possibleSpawnPlaces = RaidLocation.AssaultSpawnLocations.Where(x => x.Position.DistanceTo2D(Player.Character.Position) >= MinAssaultSpawnDistanceToPlayer).ToList();
            if (!possibleSpawnPlaces.Any())
            {
                EntryPoint.WriteToConsole("RAID LOCATION ASSAULT BACKUP SKIPPED, PLAYER TOO CLOSE TO ALL SPAWN LOCATIONS");
                return;
            }
            SpawnPlace spawnPlace = possibleSpawnPlaces.PickRandom();
            bool forceLongGun = RandomItems.RandomPercent(RaidLocation.AssaultSpawnHeavyWeaponsPercent);
            ConditionalLocation conditionalLocation = new GangConditionalLocation(spawnPlace.Position, spawnPlace.Heading, 100f)
            {
                AssociationID = RaidLocation.AssociationID,
                ForceLongGun = forceLongGun,
                LongGunAlwaysEquipped = forceLongGun,
                TaskRequirements = TaskRequirements.Guard | TaskRequirements.CanMoveWhenGuarding | TaskRequirements.EquipLongGunWhenIdle
            };
            GameTimeLastAssaultSpawn = Game.GameTime;
            if (SpawnRaidGangMember(conditionalLocation, true))
            {
                RaidLocation.TotalAssaultSpawns++;
                EntryPoint.WriteToConsole($"RAID LOCATION ASSAULT BACKUP SPAWNED {RaidLocation.TotalAssaultSpawns}/{RaidLocation.MaxAssaultSpawns}");
            }
        }

        private bool AreDefendersNeutralized()
        {
            return DefenderMembers.Any() && ConfirmedDeadDefenders.Count >= DefenderMembers.Count;
        }

        private void TrackNeutralizedDefenders()
        {
            foreach (GangMember gm in DefenderMembers)
            {
                if (!ConfirmedDeadDefenders.Contains(gm))
                {
                    if (gm.Pedestrian.Exists() && (gm.IsDead || gm.IsUnconscious))
                    {
                        ConfirmedDeadDefenders.Add(gm);
                    }
                }
            }
        }

        private bool IsPlayerInsideRaidLocation()
        {
            bool trackerSaysInside = Player.CurrentLocation?.CurrentInteriorGameLocation == RaidLocation
                                  || Player.CurrentLocation?.CurrentInterior?.GameLocation == RaidLocation;

            if (trackerSaysInside)
            {
                return true;
            }

            if (RaidLocation != null && RaidLocation.Interior != null)
            {
                if (RaidLocation.Interior.IsTeleportEntry)
                {

                    if (RaidLocation.Interior.InteriorEgressPosition.DistanceTo(Player.Character) < RaidLocation.InteriorMaxUpdateDistance)
                    {
                        return true;
                    }
                }
                else
                {
                    if (RaidLocation.DistanceToPlayer < RaidLocation.InteriorMaxUpdateDistance)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private List<ConditionalLocation> GetRaidSpawnLocations()
        {
            List<ConditionalLocation> spawnLocations = new List<ConditionalLocation>();
            if (RaidLocation.PossiblePedSpawns != null)
            {
                spawnLocations.AddRange(RaidLocation.PossiblePedSpawns);
            }
            if (RaidLocation.PossibleGroupSpawns != null)
            {
                foreach (ConditionalGroup conditionalGroup in RaidLocation.PossibleGroupSpawns)
                {
                    if (conditionalGroup?.PossiblePedSpawns == null)
                    {
                        continue;
                    }
                    spawnLocations.AddRange(conditionalGroup.PossiblePedSpawns);
                }
            }
            return spawnLocations;
        }

        private void CleanupPeds()
        {
            foreach (GangMember gm in SpawnedMembers)
            {
                if (gm.Pedestrian.Exists() && gm.DistanceToPlayer >= 200f) // 200
                {
                    gm.Pedestrian.IsPersistent = false;
                }
            }
            SpawnedMembers.Clear();
            DefenderMembers.Clear();
            ConfirmedDeadDefenders.Clear();
        }

        protected override void OnTaskCompletedOrFailed()
        {
            CleanupPeds();
            if (RaidLocation != null)
            {
                RaidLocation.IsPlayerInterestedInLocation = false;
                RaidLocation.SetRaidMissionActive(false);
            }

        }
    }
}