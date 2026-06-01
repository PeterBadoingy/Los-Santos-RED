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
        private int TargetCount;
        private bool HasArrivedNearRaid;
        private bool HasSpawnedRaidGang;
        private List<GangMember> SpawnedMembers = new List<GangMember>();

        public GangRaidLocationTask(ITaskAssignable player, ITimeReportable time, IGangs gangs, IPlacesOfInterest placesOfInterest, ISettingsProvideable settings, IEntityProvideable world,
            ICrimes crimes, IWeapons weapons, INameProvideable names, IPedGroups pedGroups, IShopMenus shopMenus, IModItems modItems, PlayerTasks playerTasks, GangTasks gangTasks,
            PhoneContact hiringContact, Gang hiringGang, RaidLocation raidLocation, int targetCount) : base(player, time, gangs, placesOfInterest, settings, world, crimes, weapons, names, pedGroups, shopMenus, modItems, playerTasks, gangTasks, hiringContact, hiringGang)
        {
            DebugName = "Raid Location";
            RepOnCompletion = 500;
            DebtOnFail = 0;
            RepOnFail = -250;
            DaysToComplete = 2;
            RaidLocation = raidLocation;
            TargetCount = targetCount;
        }

        public override void Dispose()
        {
            CleanupPeds();
            if (RaidLocation != null)
            {
                RaidLocation.IsPlayerInterestedInLocation = false;
                RaidLocation.SetRaidMissionActive(false);
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
            TargetCount = Math.Max(1, Math.Min(TargetCount, RaidLocation.MaxAssaultSpawns));
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
                $"{TargetGang.ColorPrefix}{TargetGang.ShortName}~s~ are around ~p~{RaidLocation.Name}~s~ on ~y~{RaidLocation.FullStreetAddress}~s~. Clear them out for ${PaymentAmount}"
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
                if (!HasArrivedNearRaid && RaidLocation.DistanceToPlayer <= 200f) // 200
                {
                    OnArrivedNearRaid();
                }
                if (!HasSpawnedRaidGang && RaidLocation.HasRaidStarted)
                {
                    SpawnRaidGang();
                }
                if (HasSpawnedRaidGang && SpawnedMembers.Any() && SpawnedMembers.All(x => x.IsDead || x.IsUnconscious || !x.Pedestrian.Exists()))
                {
                    CurrentTask.OnReadyForPayment(true);
                    break;
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
           // Game.DisplayHelp($"Enter {RaidLocation.Name} to start the raid.");
        }

        private void SpawnRaidGang()
        {
            List<ConditionalLocation> spawnLocations = GetRaidSpawnLocations();
            if (!spawnLocations.Any())
            {
                spawnLocations.Add(new GangConditionalLocation(RaidLocation.EntrancePosition, RaidLocation.EntranceHeading, 100f) { AssociationID = RaidLocation.AssociationID });
            }

            for (int i = 0; i < TargetCount; i++)
            {
                ConditionalLocation conditionalLocation = spawnLocations[i % spawnLocations.Count];
                SpawnLocation spawnLocation = new SpawnLocation(conditionalLocation.Location, conditionalLocation.Heading) { StreetPosition = conditionalLocation.Location };
                DispatchablePerson dispatchablePerson = TargetGang.GetRandomPed(0, conditionalLocation.RequiredPedGroup);
                if (dispatchablePerson == null)
                {
                    continue;
                }
                GangSpawnTask gangSpawnTask = new GangSpawnTask(TargetGang, spawnLocation, null, dispatchablePerson, Settings.SettingsManager.GangSettings.ShowSpawnedBlip, Settings, Weapons, Names, false, Crimes, PedGroups, ShopMenus, World, ModItems, conditionalLocation.ForceMelee, conditionalLocation.ForceSidearm, conditionalLocation.ForceLongGun);
                gangSpawnTask.PlacePedOnGround = true;
                gangSpawnTask.AllowAnySpawn = true;
                gangSpawnTask.AllowBuddySpawn = true;
                gangSpawnTask.IsHitSquad = true;
                gangSpawnTask.SpawnRequirement = conditionalLocation.TaskRequirements;
                gangSpawnTask.AttemptSpawn();
                foreach (GangMember gm in gangSpawnTask.CreatedPeople)
                {
                    conditionalLocation.AddLocationRequirements(gm);
                    gm.IsHitSquad = true;
                    gm.WillFight = true;
                    gm.WillAlwaysFightPolice = true;
                    gm.WillFightPolice = true;
                    gm.CombatMovement = 1; // Stand ground
                    SpawnedMembers.Add(gm);
                }
            }
            HasSpawnedRaidGang = SpawnedMembers.Any();
            if (HasSpawnedRaidGang)
            {
                Game.DisplaySubtitle($"{TargetGang.ColorPrefix}{TargetGang.ShortName}~s~ are defending the stash house.");
            }
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
