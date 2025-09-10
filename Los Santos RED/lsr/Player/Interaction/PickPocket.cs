using LosSantosRED.lsr.Interface;
using Rage;
using Rage.Native;
using System;
using System.Linq;

public class PickPocket : Interaction
{
    private readonly IInteractionable Player;
    private readonly ITargetable TargetPlayer;
    private readonly PedExt Target;
    private readonly ISettingsProvideable Settings;
    private readonly ICrimes Crimes;
    private readonly IEntityProvideable World;
    private readonly Random Random;
    private readonly string AnimDict = "anim@scripted@player@freemode@tun_prep_grab_midd_ig3@male@";
    private readonly string AnimName = "tun_prep_grab_midd_ig3";
    private uint GameTimeStartedPickpocketing;
    private readonly float SuccessRate;
    private readonly float DetectionChance;
    private readonly float MaxDistance;
    private bool isSuccess;
    private bool canPickpocket;
    private bool isCleanedUp;
    private bool isStarting;
    private bool _targetWillCallPolice;
    private bool _targetWillCallPoliceIntense;

    public PickPocket(IInteractionable player, ITargetable targetPlayer, PedExt target, ISettingsProvideable settings, ICrimes crimes, IEntityProvideable world)
    {
        Player = player ?? throw new ArgumentNullException(nameof(player));
        TargetPlayer = targetPlayer ?? throw new ArgumentNullException(nameof(targetPlayer));
        Target = target ?? throw new ArgumentNullException(nameof(target));
        Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        Crimes = crimes ?? throw new ArgumentNullException(nameof(crimes));
        World = world ?? throw new ArgumentNullException(nameof(world));
        Random = new Random();
        SuccessRate = settings.SettingsManager.ActivitySettings.PickPocketSuccessRate > 0 && settings.SettingsManager.ActivitySettings.PickPocketSuccessRate <= 1.0f
            ? settings.SettingsManager.ActivitySettings.PickPocketSuccessRate : 0.5f;
        DetectionChance = settings.SettingsManager.ActivitySettings.PickPocketBaseDetectionChance > 0 && settings.SettingsManager.ActivitySettings.PickPocketBaseDetectionChance <= 1.0f
            ? settings.SettingsManager.ActivitySettings.PickPocketBaseDetectionChance : 0.5f;
        MaxDistance = settings.SettingsManager.ActivitySettings.PickPocketDistance > 0
            ? settings.SettingsManager.ActivitySettings.PickPocketDistance : 4.0f;
        canPickpocket = true;
        isCleanedUp = false;
        isStarting = false;
        EntryPoint.WriteToConsole($"Pickpocket: Initialized for ped {Target.Pedestrian?.Handle:X8 ?? 0}, MaxDistance={MaxDistance}, AllowPedPickPockets={Settings.SettingsManager.ActivitySettings.AllowPedPickPockets}, SuccessRate={SuccessRate:F2}, DetectionChance={DetectionChance:F2}, IsGangMember={Target.IsGangMember}, IsCop={Target.IsCop}, PedType={Target.GetType().Name}");
    }

    public override string DebugString => $"Pickpocketing {Target.Pedestrian?.Handle:X8 ?? 0} Success={isSuccess} Detected={isDetected}";
    public override bool CanPerformActivities { get; set; } = true;
    public bool isDetected { get; set; }

    public override void Dispose()
    {
        if (!isCleanedUp)
        {
            CleanUp();
        }
    }

    public override void Start()
    {
        if (isStarting)
        {
            EntryPoint.WriteToConsole($"Pickpocket: Blocked, already starting for ped {Target.Pedestrian?.Handle:X8 ?? 0}");
            CleanUp();
            return;
        }
        isStarting = true;

        if (!CanStartPickpocketing())
        {
            CleanUp();
            return;
        }

        GameFiber.StartNew(() =>
        {
            try
            {
                Setup();
            }
            catch (Exception ex)
            {
                EntryPoint.WriteToConsole($"Pickpocket: Error in Start - {ex.Message} {ex.StackTrace}");
                CleanUp();
            }
        }, $"PickpocketStart_{Target.Pedestrian?.Handle:X8 ?? 0}");
    }

    private bool CanStartPickpocketing()
    {
        bool isPlayerInVehicle = TargetPlayer.Character.IsInAnyVehicle(false);
        bool isPlayerPerformingActivity = Player.ActivityManager?.IsPerformingActivity ?? false;
        bool canPickpocketLookedAtPed = Player.ActivityManager?.CanPickpocketLookedAtPed ?? false;
        bool isPedValid = Target.Pedestrian?.Exists() ?? false;
        float distanceToPed = isPedValid ? Target.DistanceToPlayer : float.MaxValue;
        bool isPedInVehicle = Target.IsInVehicle;
        bool isPedUnconscious = Target.IsUnconscious;
        bool isPedDead = Target.IsDead;
        bool hasBeenMugged = Target.HasBeenMugged;

        if (!canPickpocket || !Settings.SettingsManager.ActivitySettings.AllowPedPickPockets || !canPickpocketLookedAtPed || isPlayerPerformingActivity || !isPedValid)
        {
            EntryPoint.WriteToConsole($"Pickpocket: Blocked, CanPickpocket={canPickpocket}, AllowPedPickPockets={Settings.SettingsManager.ActivitySettings.AllowPedPickPockets}, CanPickpocketLookedAtPed={canPickpocketLookedAtPed}, IsPerformingActivity={isPlayerPerformingActivity}, PedExists={isPedValid}");
            return false;
        }
        if (isPedInVehicle || distanceToPed > MaxDistance || isPedUnconscious || isPedDead || hasBeenMugged)
        {
            Game.DisplayHelp("Cannot pickpocket: Invalid target state");
            EntryPoint.WriteToConsole($"Pickpocket: Cannot start, Exists={isPedValid}, IsInVehicle={isPedInVehicle}, Distance={distanceToPed:F2}, MaxDistance={MaxDistance}, IsUnconscious={isPedUnconscious}, IsDead={isPedDead}, HasBeenMugged={hasBeenMugged}");
            return false;
        }
        return true;
    }

    private void Setup()
    {
        if (!Target.Pedestrian.Exists())
        {
            EntryPoint.WriteToConsole($"Pickpocket: Setup failed, ped {Target.Pedestrian?.Handle:X8 ?? 0} does not exist");
            CleanUp();
            return;
        }
        _targetWillCallPolice = Target.WillCallPolice;
        _targetWillCallPoliceIntense = Target.WillCallPoliceIntense;
        Target.HasBeenMugged = true;
        EntryPoint.WriteToConsole($"Pickpocket: Attempt registered, future attempts blocked for ped {Target.Pedestrian.Handle:X8}");
        AnimationDictionary.RequestAnimationDictionay(AnimDict);
        GameTimeStartedPickpocketing = Game.GameTime;
        canPickpocket = false;
        Player.ActivityManager.IsPickPocketing = true;
        EntryPoint.WriteToConsole($"Pickpocket: Setup for ped {Target.Pedestrian.Handle:X8}, Money={Target.Money}, IsGangMember={Target.IsGangMember}, IsCop={Target.IsCop}, TaskStatus={NativeFunction.Natives.GET_SCRIPT_TASK_STATUS<int>(Target.Pedestrian, 0x811455F8)}, CrimesWitnessed={Target.PlayerCrimesWitnessed.Count}, WillCallPolice={Target.WillCallPolice}, WillCallPoliceIntense={Target.WillCallPoliceIntense}, PedType={Target.GetType().Name}");
        PerformPickpocket();
    }

    private void PerformPickpocket()
    {
        try
        {
            if (!IsValidState())
            {
                Game.DisplayHelp("Pickpocket failed: Invalid state");
                EntryPoint.WriteToConsole($"Pickpocket: Failed, PlayerExists={TargetPlayer.Character.Exists()}, PedExists={Target.Pedestrian.Exists()}, Distance={Target.DistanceToPlayer:F2}, MaxDistance={MaxDistance}, IsAliveAndFree={TargetPlayer.IsAliveAndFree}, PedType={Target.GetType().Name}");
                CleanUp();
                return;
            }

            PlayAnimation();
            if (!WaitForAnimation())
            {
                Game.DisplayHelp("Pickpocket failed: Animation not loaded!");
                EntryPoint.WriteToConsole($"Pickpocket: Animation {AnimDict}/{AnimName} failed to play for ped {Target.Pedestrian.Handle:X8}");
                CleanUp();
                return;
            }

            if (!IsValidState())
            {
                Game.DisplayHelp("Pickpocket failed: Invalid state");
                EntryPoint.WriteToConsole($"Pickpocket: Failed post-animation, PlayerExists={TargetPlayer.Character.Exists()}, PedExists={Target.Pedestrian.Exists()}, Distance={Target.DistanceToPlayer:F2}, MaxDistance={MaxDistance}, PedType={Target.GetType().Name}");
                CleanUp();
                return;
            }

            Crime pickpocketCrime = Crimes.GetCrime(StaticStrings.PickPocketingCrimeID);
            if (pickpocketCrime == null)
            {
                EntryPoint.WriteToConsole($"Pickpocket: Crime {StaticStrings.PickPocketingCrimeID} not found");
                CleanUp();
                return;
            }

            double randomValue = Random.NextDouble();
            isSuccess = randomValue < SuccessRate;
            double detectionRandomValue = isSuccess ? 0.0 : Random.NextDouble();
            isDetected = !isSuccess && detectionRandomValue < DetectionChance;
            EntryPoint.WriteToConsole($"Pickpocket: Outcome check, ped {Target.Pedestrian.Handle:X8}, SuccessRate={SuccessRate:F2}, RandomValue={randomValue:F4}, isSuccess={isSuccess}, DetectionChance={DetectionChance:F2}, DetectionRandomValue={detectionRandomValue:F4}, isDetected={isDetected}, IsViolatingAnyCrimes={Player.Violations.IsViolatingAnyCrimes}, CrimesWitnessed={Target.PlayerCrimesWitnessed.Count}, PedType={Target.GetType().Name}");

            if (isSuccess)
            {
                Target.WillCallPolice = false;
                Target.WillCallPoliceIntense = false;
                CreateMoneyDrop();
                EntryPoint.WriteToConsole($"Pickpocket: Successful pickpocket of {(Target.IsGangMember ? $"gang member {(Target as GangMember)?.Gang?.ShortName ?? "Unknown"}" : $"non-gang member, IsCop={Target.IsCop}")}, ped {Target.Pedestrian.Handle:X8}, FlagsSuppressed=True, PedType={Target.GetType().Name}");
            }
            else if (isDetected)
            {
                Game.DisplayHelp("Pickpocketing failed! Detected!");
                Player.PlaySpeech("GENERIC_CURSE_MED", false);
                Target.PlaySpeech("GENERIC_INSULT_MED", false);
                Target.HatesPlayer = true; // Trigger reaction
                Target.OnPlayerFailedPickpocketing(Player);
                EntryPoint.WriteToConsole($"Pickpocket: Failed and detected pickpocket of {(Target.IsGangMember ? $"gang member {(Target as GangMember)?.Gang?.ShortName ?? "Unknown"}" : $"non-gang member, IsCop={Target.IsCop}")}, ped {Target.Pedestrian.Handle:X8}, CrimesWitnessed={Target.PlayerCrimesWitnessed.Count}, HasSeenMundaneCrime={Target.PedReactions.HasSeenMundaneCrime}, CurrentTask={Target.CurrentTask?.Name}, PedType={Target.GetType().Name}");
            }
            else
            {
                Game.DisplayHelp("Pickpocketing failed! Not detected.");
                Player.PlaySpeech("GENERIC_CURSE_MED", false);
                EntryPoint.WriteToConsole($"Pickpocket: Failed but not detected pickpocket of {(Target.IsGangMember ? $"gang member {(Target as GangMember)?.Gang?.ShortName ?? "Unknown"}" : $"non-gang member, IsCop={Target.IsCop}")}, ped {Target.Pedestrian.Handle:X8}, PedType={Target.GetType().Name}");
            }
            CleanUp();
        }
        catch (Exception ex)
        {
            EntryPoint.WriteToConsole($"Pickpocket: Error in PerformPickpocket - {ex.Message} {ex.StackTrace}");
            CleanUp();
        }
    }

    private bool IsValidState()
    {
        return TargetPlayer.Character.Exists() && Target.Pedestrian.Exists() && Target.DistanceToPlayer <= MaxDistance && TargetPlayer.IsAliveAndFree;
    }

    private void PlayAnimation()
    {
        Vector3 position = TargetPlayer.Character.Position;
        Vector3 rotation = NativeFunction.Natives.GET_ENTITY_ROTATION<Vector3>(TargetPlayer.Character, 2);
        NativeFunction.Natives.TASK_PLAY_ANIM_ADVANCED(TargetPlayer.Character, AnimDict, AnimName, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, 4.0f, -4.0f, 800, 49, 0.0f, 0.0f, false, false);
    }

    private bool WaitForAnimation()
    {
        uint animationStartTime = Game.GameTime;
        while (!NativeFunction.Natives.IS_ENTITY_PLAYING_ANIM<bool>(TargetPlayer.Character, AnimDict, AnimName, 3) && Game.GameTime - animationStartTime < 500)
        {
            GameFiber.Yield();
        }
        if (!NativeFunction.Natives.IS_ENTITY_PLAYING_ANIM<bool>(TargetPlayer.Character, AnimDict, AnimName, 3))
        {
            return false;
        }
        while (Game.GameTime - animationStartTime < 800 && IsValidState())
        {
            GameFiber.Wait(100);
            GameFiber.Yield();
        }
        return true;
    }

    private void CreateMoneyDrop()
    {
        try
        {
            int money = Target.Money;
            if (money <= 0)
            {
                Game.DisplayHelp("Pickpocket failed: Target has no money!");
                EntryPoint.WriteToConsole($"Pickpocket: No money to drop for ped {Target.Pedestrian.Handle:X8}, Money={money}");
                return;
            }
            Target.Money = 0;
            if (!IsValidState())
            {
                Game.DisplayHelp("Pickpocket failed: Invalid state!");
                EntryPoint.WriteToConsole($"Pickpocket: Pickup creation skipped, PedExists={Target.Pedestrian.Exists()}, PlayerExists={TargetPlayer.Character.Exists()}");
                return;
            }

            NativeFunction.Natives.SET_PED_MONEY(Target.Pedestrian, 0);
            uint modelHash = Game.GetHashKey("PICKUP_MONEY_WALLET");
            Vector3 moneyPos = Target.Pedestrian.Position.Around2D(0.5f, 1.5f);

            if (Target.IsGangMember)
            {
                modelHash = Game.GetHashKey("PICKUP_MONEY_VARIABLE");
                int moneyPickupCreated = 0;
                int pickupsToCreate = Math.DivRem(money, 500, out int remainder);
                if (remainder > 0)
                {
                    pickupsToCreate++;
                }
                for (int i = 0; i < pickupsToCreate; i++)
                {
                    int moneyToDrop = money - moneyPickupCreated;
                    if (moneyToDrop > 500)
                    {
                        moneyToDrop = 500;
                    }
                    moneyPos = Target.Pedestrian.Position.Around2D(0.5f, 1.5f);
                    NativeFunction.Natives.CREATE_AMBIENT_PICKUP(modelHash, moneyPos.X, moneyPos.Y, moneyPos.Z, 0, moneyToDrop, 1, false, true);
                    moneyPickupCreated += moneyToDrop;
                }
            }
            else
            {
                if (Target.IsMerchant)
                {
                    modelHash = Game.GetHashKey("PICKUP_MONEY_DEP_BAG");
                }
                NativeFunction.Natives.CREATE_AMBIENT_PICKUP(modelHash, moneyPos.X, moneyPos.Y, moneyPos.Z, 0, money, 1, false, true);
            }

            string description = $"Cash Stolen:~n~~g~${money}~s~";
            Game.DisplayNotification("CHAR_BLANK_ENTRY", "CHAR_BLANK_ENTRY", "~r~Ped Pickpocketed", $"~y~{Target.Name}", description);
            EntryPoint.WriteToConsole($"Pickpocket: Created money drop for ped {Target.Pedestrian.Handle:X8}, Money={money}, TaskStatus={NativeFunction.Natives.GET_SCRIPT_TASK_STATUS<int>(Target.Pedestrian, 0x811455F8)}, WillCallPolice={Target.WillCallPolice}, HasBeenMugged={Target.HasBeenMugged}, CrimesWitnessed={Target.PlayerCrimesWitnessed.Count}, PedType={Target.GetType().Name}");
        }
        catch (Exception ex)
        {
            EntryPoint.WriteToConsole($"Pickpocket: Error in CreateMoneyDrop - {ex.Message} {ex.StackTrace}");
            CleanUp();
        }
    }

    private void CleanUp()
    {
        if (isCleanedUp)
        {
            return;
        }
        isCleanedUp = true;

        if (Target?.Pedestrian != null && Target.Pedestrian.Exists())
        {
            Target.WillCallPolice = _targetWillCallPolice;
            Target.WillCallPoliceIntense = _targetWillCallPoliceIntense;
            Target.CanBeTasked = true;
            Target.CanBeAmbientTasked = true;
            if (isSuccess || !isDetected)
            {
                if (Target.CurrentTask != null)
                {
                    Target.CurrentTask.Stop();
                    Target.CurrentTask = null;
                }
                int taskStatus = NativeFunction.Natives.GET_SCRIPT_TASK_STATUS<int>(Target.Pedestrian, 0x811455F8);
                if (taskStatus == 7)
                {
                    EntryPoint.WriteToConsole($"Pickpocket: WARNING: Ped {Target.Pedestrian.Handle:X8} has no active task after cleanup, IsGangMember={Target.IsGangMember}, IsCop={Target.IsCop}");
                }
                EntryPoint.WriteToConsole($"Pickpocket: Restored tasking for ped {Target.Pedestrian.Handle:X8}, IsGangMember={Target.IsGangMember}, IsCop={Target.IsCop}, TaskStatus={taskStatus}, WillCallPolice={Target.WillCallPolice}, HasBeenMugged={Target.HasBeenMugged}, CrimesWitnessed={Target.PlayerCrimesWitnessed.Count}");
            }
        }

        if (Player?.ActivityManager != null)
        {
            Player.ActivityManager.IsPerformingActivity = false;
            Player.ActivityManager.IsPickPocketing = false;
            Player.ButtonPrompts.RemovePrompts("Pickpocket");
            NativeFunction.Natives.CLEAR_ALL_HELP_MESSAGES();
        }

        canPickpocket = true;
        isStarting = false;
        EntryPoint.WriteToConsole($"Pickpocket: Cleaned up for ped {Target.Pedestrian?.Handle:X8 ?? 0}");
    }
}