using LosSantosRED.lsr.Interface;
using Rage;
using Rage.Native;
using System;

namespace LSR.Vehicles
{
    public class Anchor
    {
        private VehicleExt VehicleToMonitor;
        private uint GameTimeLastToggledAnchor;
        private uint GameTimeLastUpdated;
        private const uint AnchorToggleCooldown = 1500;
        private const uint UpdateCooldown = 3000; 
        private const float MinPlayerDistance = 20.0f; 
        private bool lastAnchorState;

        public Anchor(VehicleExt vehicleToMonitor)
        {
            VehicleToMonitor = vehicleToMonitor;
            IsDeployed = false;
            lastAnchorState = false;
        }

        public bool IsDeployed { get; private set; }
        public bool CanToggle => VehicleToMonitor != null &&
                                 VehicleToMonitor.Vehicle.Exists() &&
                                 VehicleToMonitor.IsBoat &&
                                 VehicleToMonitor.Vehicle.Speed < 2f &&
                                 Game.GameTime - GameTimeLastToggledAnchor >= AnchorToggleCooldown;

        public void Toggle(IActivityManageable player)
        {
            if (!CanToggle)
            {
                if (VehicleToMonitor != null && VehicleToMonitor.Vehicle.Exists() && !VehicleToMonitor.IsBoat)
                {
                    Game.DisplaySubtitle("Anchor can only be used on boats");
                }
                else if (VehicleToMonitor.Vehicle.Speed >= 3f)
                {
                    Game.DisplaySubtitle("Slow down to toggle anchor");
                }
                return;
            }

            SetState(!IsDeployed, player);
            GameTimeLastToggledAnchor = Game.GameTime;
        }

        public void SetState(bool deploy, IActivityManageable player)
        {
            if (VehicleToMonitor == null || !VehicleToMonitor.Vehicle.Exists() || !VehicleToMonitor.IsBoat)
            {
                if (VehicleToMonitor != null && VehicleToMonitor.Vehicle.Exists() && !VehicleToMonitor.IsBoat)
                {
                    Game.DisplaySubtitle("Anchor can only be used on boats");
                }
                return;
            }

            bool canAnchor = NativeFunction.Natives.CAN_ANCHOR_BOAT_HERE<bool>(VehicleToMonitor.Vehicle);
            if (deploy && !canAnchor)
            {
                Game.DisplaySubtitle("Cannot anchor the boat at this location");
                EntryPoint.WriteToConsole($"ANCHOR FAILED: Unsafe to anchor Vehicle {VehicleToMonitor.Vehicle.Handle}");
                return;
            }

            IsDeployed = deploy;
            float lodDistance = 100.0f; // Static LOD distance
            if (IsDeployed)
            {
                NativeFunction.Natives.SET_BOAT_ANCHOR(VehicleToMonitor.Vehicle, true);
                NativeFunction.Natives.SET_BOAT_REMAINS_ANCHORED_WHILE_PLAYER_IS_DRIVER(VehicleToMonitor.Vehicle, true);
                NativeFunction.Natives.SET_BOAT_LOW_LOD_ANCHOR_DISTANCE(VehicleToMonitor.Vehicle, lodDistance);
                //NativeFunction.Natives.SET_FORCE_LOW_LOD_ANCHOR_MODE(VehicleToMonitor.Vehicle, true); 
                // true = prevents driving and vehicle movement when anchored / causes visual jittering when returning to an anchored vehicle.
                // false = allows driving and vehicle movement when anchored / is very glitchy if trying to move while anchored
                Game.DisplaySubtitle("Anchor Deployed");
                EntryPoint.WriteToConsole($"ANCHOR DEPLOYED for Vehicle {VehicleToMonitor.Vehicle.Handle} with LOD distance {lodDistance}");
                player?.OnManuallyToggledAnchor(true);
            }
            else
            {
                NativeFunction.Natives.SET_BOAT_ANCHOR(VehicleToMonitor.Vehicle, false);
                NativeFunction.Natives.SET_BOAT_REMAINS_ANCHORED_WHILE_PLAYER_IS_DRIVER(VehicleToMonitor.Vehicle, false);
                NativeFunction.Natives.SET_BOAT_LOW_LOD_ANCHOR_DISTANCE(VehicleToMonitor.Vehicle, -1.0f);
                //NativeFunction.Natives.SET_FORCE_LOW_LOD_ANCHOR_MODE(VehicleToMonitor.Vehicle, false);
                Game.DisplaySubtitle("Anchor Retracted");
                EntryPoint.WriteToConsole($"ANCHOR RETRACTED for Vehicle {VehicleToMonitor.Vehicle.Handle}");
                player?.OnManuallyToggledAnchor(false);
            }
            lastAnchorState = IsDeployed;
        }

        public void Update()
        {
            if (VehicleToMonitor == null || !VehicleToMonitor.Vehicle.Exists() || !VehicleToMonitor.IsBoat)
            {
                return;
            }
            if (Game.GameTime - GameTimeLastUpdated < UpdateCooldown)
            {
                return; // Skip update to reduce CPU load
            }
            float playerDistance = Game.LocalPlayer.Character.DistanceTo(VehicleToMonitor.Vehicle.Position);
            if (playerDistance < MinPlayerDistance)
            {
                return; // Skip update if player is too close
            }
            if (IsDeployed)
            {
                bool isAnchored = NativeFunction.Natives.IS_BOAT_ANCHORED<bool>(VehicleToMonitor.Vehicle);
                if (!isAnchored && lastAnchorState)
                {
                    float lodDistance = 100.0f; // Static LOD distance
                    NativeFunction.Natives.SET_BOAT_ANCHOR(VehicleToMonitor.Vehicle, true);
                    NativeFunction.Natives.SET_BOAT_REMAINS_ANCHORED_WHILE_PLAYER_IS_DRIVER(VehicleToMonitor.Vehicle, true);
                    NativeFunction.Natives.SET_BOAT_LOW_LOD_ANCHOR_DISTANCE(VehicleToMonitor.Vehicle, lodDistance);
                    //NativeFunction.Natives.SET_FORCE_LOW_LOD_ANCHOR_MODE(VehicleToMonitor.Vehicle, true);
                    EntryPoint.WriteToConsole($"ANCHOR UPDATE: Maintaining Deployed state for Vehicle {VehicleToMonitor.Vehicle.Handle} with LOD distance {lodDistance}");
                }
                lastAnchorState = isAnchored;
            }
            GameTimeLastUpdated = Game.GameTime;
        }
    }
}