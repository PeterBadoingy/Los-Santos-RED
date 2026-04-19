using LosSantosRED.lsr.Interface;
using LSR.Vehicles;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AIVehicleRacer : VehicleRacer
{
    uint GameTimeLastClearedFront;
    private bool hasBeenDisposed;

    // Personality offsets to ensure each racer drives slightly differently
    private float SpeedOffset;
    private float PowerOffset;

    public AIVehicleRacer(PedExt pedExt, VehicleExt vehicleExt) : base(vehicleExt)
    {
        PedExt = pedExt;

        // Assign a unique personality to this racer to prevent bunching
        // Speed: +/- 4.0 m/s (~9 MPH variance)
        // Power: +/- 0.2 variance in acceleration/torque
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        SpeedOffset = (float)(rnd.NextDouble() * 8.0 - 4.0);
        PowerOffset = (float)(rnd.NextDouble() * 0.4 - 0.2);
    }

    public PedExt PedExt { get; set; }
    public bool WasSpawnedForRace { get; set; }
    public override string RacerName => PedExt == null ? base.RacerName : PedExt.Name;
    public bool IsManualDispose { get; set; } = false;

    public override void Update(VehicleRace vehicleRace)
    {
        if (vehicleRace == null || PedExt == null || HasFinishedRace) return;

        // --- START LINE HOLD ---
        if (!vehicleRace.HasRaceStarted)
        {
            if (VehicleExt?.Vehicle != null && VehicleExt.Vehicle.Exists())
            {
                NativeFunction.Natives.SET_VEHICLE_FORWARD_SPEED(VehicleExt.Vehicle, 0f);
                NativeFunction.Natives.SET_VEHICLE_HANDBRAKE(VehicleExt.Vehicle, true);
            }
            return;
        }
        else
        {
            if (VehicleExt?.Vehicle != null && VehicleExt.Vehicle.Exists())
                NativeFunction.Natives.SET_VEHICLE_HANDBRAKE(VehicleExt.Vehicle, false);
        }

        base.Update(vehicleRace); // Process checkpoint logic
        PedExt.CurrentTask?.Update();

        if (VehicleExt != null && VehicleExt.Vehicle.Exists() && PedExt.Pedestrian.Exists())
        {
            Vehicle raceCar = VehicleExt.Vehicle;
            Ped driver = PedExt.Pedestrian;
            VehicleRacer playerRacer = vehicleRace.VehicleRacers.FirstOrDefault(r => r.IsPlayer);

            if (playerRacer != null)
            {
                float rb_distance = raceCar.DistanceTo(playerRacer.VehicleExt.Vehicle);
                bool isBehind = CheckIfBehind(playerRacer);

                // Use the personality offset to define this specific driver's target speed
                float rb_base_speed = 54.0f + SpeedOffset; //52 - 116MPH base target speed / 54 - 120MPH 
                float rb_new_speed = rb_base_speed;
                float rb_cheat_power = 1.0f + PowerOffset;

                if (isBehind)
                {
                    // --- CATCH UP LOGIC ---
                    if (rb_distance > 60f) { rb_new_speed = rb_base_speed * 1.6f; rb_cheat_power += 0.7f; }
                    else if (rb_distance > 30f) { rb_new_speed = rb_base_speed * 1.3f; rb_cheat_power += 0.4f; }
                    else { rb_new_speed = rb_base_speed * 1.15f; rb_cheat_power += 0.2f; }
                }
                else
                {
                    // --- OVERTAKE & LEAD LOGIC ---
                    if (rb_distance < 25f)
                    {
                        // PASSING ZONE: AI is ahead but close. 
                        // Keep a slight speed advantage to complete the pass and build a gap.
                        rb_new_speed = rb_base_speed * 1.1f;
                        rb_cheat_power += 0.1f;
                    }
                    else if (rb_distance > 80f)
                    {
                        // LEADING: AI is far ahead, slow down slightly so the player can stay in the race.
                        rb_new_speed = rb_base_speed * 0.85f;
                        rb_cheat_power -= 0.2f;
                    }
                    else
                    {
                        // MAINTAINING: AI is safely ahead, drive at their natural pace.
                        rb_new_speed = rb_base_speed;
                    }
                }

                // Ensure power never drops so low the car becomes undriveable
                rb_cheat_power = Math.Max(0.6f, rb_cheat_power);

                // Apply Motivation and Ability
                NativeFunction.Natives.SET_DRIVE_TASK_CRUISE_SPEED(driver, rb_new_speed);
                NativeFunction.Natives.MODIFY_VEHICLE_TOP_SPEED(raceCar, rb_new_speed);
                NativeFunction.Natives.SET_VEHICLE_CHEAT_POWER_INCREASE(raceCar, rb_cheat_power);
            }

            NativeFunction.Natives.SET_VEHICLE_IS_RACING(raceCar, true);
        }

        // Traffic Clearing
        if (Game.GameTime - GameTimeLastClearedFront > 200)
        {
            ClearFront();
            GameTimeLastClearedFront = Game.GameTime;
        }
    }

    private bool CheckIfBehind(VehicleRacer playerRacer)
    {
        if (CurrentLap < playerRacer.CurrentLap) return true;
        if (CurrentLap > playerRacer.CurrentLap) return false;

        int myCP = TargetCheckpoint?.Order ?? 0;
        int playerCP = playerRacer.TargetCheckpoint?.Order ?? 0;

        if (myCP < playerCP) return true;
        if (myCP > playerCP) return false;

        return DistanceToCheckpoint > playerRacer.DistanceToCheckpoint;
    }

    public void AssignTask(VehicleRace vehicleRace, ITargetable Targetable, IEntityProvideable World, ISettingsProvideable Settings)
    {
        if (PedExt == null || !PedExt.Pedestrian.Exists()) return;

        Ped racePed = PedExt.Pedestrian;
        Vehicle raceCar = PedExt.AssignedVehicle.Vehicle;

        racePed.BlockPermanentEvents = true;

        NativeFunction.Natives.SET_VEHICLE_HANDLING_OVERRIDE(raceCar, Game.GetHashKey("SPORTS_CAR"));
        NativeFunction.Natives.SET_VEHICLE_STRONG(raceCar, true);
        NativeFunction.Natives.SET_VEHICLE_HAS_STRONG_AXLES(raceCar, true);
        NativeFunction.Natives.SET_VEHICLE_TYRES_CAN_BURST(raceCar, false);
        NativeFunction.Natives.SET_ENABLE_VEHICLE_SLIPSTREAMING(true);
        NativeFunction.Natives.SET_CAR_HIGH_SPEED_BUMP_SEVERITY_MULTIPLIER( 0.0f );

        if (NativeFunction.Natives.GET_NUM_VEHICLE_MODS<int>(raceCar, 15) > 0)
            NativeFunction.Natives.SET_VEHICLE_MOD(raceCar, 15, -1, true);

        NativeFunction.Natives.SET_ENTITY_ONLY_DAMAGED_BY_PLAYER(racePed, true);
        NativeFunction.Natives.SET_ENTITY_ONLY_DAMAGED_BY_PLAYER(raceCar, true);

        NativeFunction.Natives.SET_PED_CONFIG_FLAG(racePed, 32, false);  // PCF_WillFlyThroughWindscreen
        NativeFunction.Natives.SET_PED_CONFIG_FLAG(racePed, 184, false); // PCF_GetOutUndriveableVehicle
        NativeFunction.Natives.SET_PED_CONFIG_FLAG(racePed, 208, false); // PCF_RunFromFiresAndExplosions
        NativeFunction.Natives.SET_PED_CONFIG_FLAG(racePed, 305, true);
        NativeFunction.Natives.SET_PED_CONFIG_FLAG(racePed, 347, true);
        NativeFunction.Natives.SET_PED_CONFIG_FLAG(racePed, 429, true);  // PCF_DontAllowToBeDraggedOutOfVehicle
        NativeFunction.Natives.SET_PED_DIES_IN_WATER(racePed, false);

        NativeFunction.Natives.SET_ENTITY_LOAD_COLLISION_FLAG(raceCar, true);
        NativeFunction.Natives.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE(racePed, 3);

        // Initial speed limit; will be overridden by rubber-banding in Update
        NativeFunction.Natives.SET_DRIVE_TASK_CRUISE_SPEED(racePed, 500f);

        PedExt.CurrentTask = new GeneralRace(PedExt, PedExt, Targetable, World, new List<VehicleExt>() { PedExt.AssignedVehicle }, null, Settings, vehicleRace, this);
        PedExt.CurrentTask.Start();
    }

    public override void Dispose()
    {
        if (IsManualDispose) return;

        if (PedExt != null)
        {
            PedExt.SetNonPersistent();
            if (WasSpawnedForRace)
            {
                PedExt.DeleteBlip();
                if (PedExt.Pedestrian.Exists())
                {
                    PedExt.Pedestrian.IsPersistent = false;
                }
                PedExt.CanBeIdleTasked = true;
                PedExt.IsManuallyDeleted = false;
            }
            PedExt.CanBeAmbientTasked = true;
            PedExt.CanBeTasked = true;
            PedExt.CurrentTask?.Stop();
            PedExt.CurrentTask = null;
        }

        if (VehicleExt != null)
        {
            if (WasSpawnedForRace && !VehicleExt.IsOwnedByPlayer)
            {
                VehicleExt.RemoveBlip();
                if (VehicleExt.Vehicle.Exists())
                {
                    VehicleExt.Vehicle.IsPersistent = false;
                }
            }
        }
        base.Dispose();
    }

    public override void OnFinishedRace(int finalPosition, VehicleRace vehicleRace)
    {
        if (PedExt != null && VehicleExt != null && VehicleExt.Vehicle.Exists())
        {
            Vehicle raceCar = VehicleExt.Vehicle;
            Ped driver = PedExt.Pedestrian;

            // 1. STOP THE RACE TASK
            // This stops the AI from trying to calculate racing paths or checkpoints.
            PedExt.CurrentTask?.Stop();
            PedExt.CurrentTask = null;

            // 2. RESET PHYSICS & NATIVES
            // Return the car to standard performance so they don't wander at 150mph.
            NativeFunction.Natives.MODIFY_VEHICLE_TOP_SPEED(raceCar, -1.0f);
            NativeFunction.Natives.SET_VEHICLE_CHEAT_POWER_INCREASE(raceCar, 1.0f);
            NativeFunction.Natives.SET_VEHICLE_IS_RACING(raceCar, false);
            NativeFunction.Natives.SET_VEHICLE_HANDLING_OVERRIDE(raceCar, 0);
            NativeFunction.Natives.SET_VEHICLE_STRONG(raceCar, false);
            NativeFunction.Natives.SET_ENTITY_ONLY_DAMAGED_BY_PLAYER(raceCar, false);
            NativeFunction.Natives.SET_ENABLE_VEHICLE_SLIPSTREAMING(false);

            // 3. START WANDERING
            // TASK_VEHICLE_DRIVE_WANDER(Ped ped, Vehicle vehicle, float speed, int drivingStyle)
            // Speed 20f is ~45mph. DrivingStyle 786603 is "Normal/Ignore Lights" which keeps them moving.
            NativeFunction.Natives.TASK_VEHICLE_DRIVE_WANDER(driver, raceCar, 20f, 786603);

            EntryPoint.WriteToConsole($"RACER {RacerName} finished and is now wandering.");
        }

        // Handle the winnings
        if (finalPosition == 1 && vehicleRace != null && vehicleRace.BetAmount > 0)
        {
            int totalWinAmount = vehicleRace.BetAmount * vehicleRace.VehicleRacers.Count();
            PedExt.Money += totalWinAmount;
        }

        base.OnFinishedRace(finalPosition, vehicleRace);
    }

    public void ClearFront()
    {
        if (PedExt.IsInHelicopter || !PedExt.Pedestrian.Exists()) return;
        Vehicle raceCar = PedExt.Pedestrian.CurrentVehicle;
        if (!raceCar.Exists()) return;

        (float distInFront, float range) = GetClearanceBounds(raceCar);

        if (PedExt.DistanceToPlayer <= 20f || raceCar.IsOnScreen)
            CarefulFrontDelete(raceCar, distInFront, range);
        else
            LargeFrontDelete(raceCar, distInFront, range);
    }

    private (float dist, float range) GetClearanceBounds(Vehicle raceCar)
    {
        if (raceCar.Speed >= 27f || PedExt.DistanceToPlayer >= 120f)
            return (9.0f, 12f);
        return (4.25f, 7.25f);
    }

    private void LargeFrontDelete(Vehicle raceCar, float distanceInFront, float range)
    {
        float length = raceCar.Model.Dimensions.Y;
        Vector3 Position = raceCar.GetOffsetPositionFront(length / 2f + distanceInFront);
        NativeFunction.Natives.CLEAR_AREA(Position.X, Position.Y, Position.Z, range, true, false, false, false);
    }

    private void CarefulFrontDelete(Vehicle raceCar, float distanceInFront, float range)
    {
        float length = raceCar.Model.Dimensions.Y;
        Entity ClosestCarEntity = Rage.World.GetClosestEntity(raceCar.GetOffsetPositionFront(length / 2f + distanceInFront), range, GetEntitiesFlags.ConsiderGroundVehicles | GetEntitiesFlags.ExcludePoliceCars | GetEntitiesFlags.ExcludePlayerVehicle);

        if (ClosestCarEntity.Exists() && !ClosestCarEntity.IsOnScreen && !ClosestCarEntity.IsPersistent)
        {
            if (ClosestCarEntity.Handle != raceCar.Handle)
            {
                if (ClosestCarEntity is Vehicle targetVeh)
                {
                    foreach (Ped occupant in targetVeh.Occupants) occupant?.Delete();
                    targetVeh.Delete();
                }
            }
        }
    }
}