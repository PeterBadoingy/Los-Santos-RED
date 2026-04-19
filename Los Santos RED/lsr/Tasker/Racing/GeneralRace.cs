using LosSantosRED.lsr.Interface;
using LSR.Vehicles;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GeneralRace : ComplexTask, ILocationReachable
{
    private PedExt PedGeneral;
    private IEntityProvideable World;
    private IPlacesOfInterest PlacesOfInterest;
    private SeatAssigner SeatAssigner;
    private TaskState CurrentTaskState;
    private ISettingsProvideable Settings;
    private VehicleRace VehicleRace;
    private VehicleRacer VehicleRacer;
    private VehicleRaceCheckpoint AssignedCheckpoint;

    public GeneralRace(PedExt pedGeneral, IComplexTaskable ped, ITargetable player, IEntityProvideable world, List<VehicleExt> possibleVehicles, IPlacesOfInterest placesOfInterest, ISettingsProvideable settings, 
         VehicleRace vehicleRace, VehicleRacer vehicleRacer) :
        base(player, ped, 1000)//1500
    {
        PedGeneral = pedGeneral;
        Name = "GeneralRace";
        SubTaskName = "";
        World = world;
        PlacesOfInterest = placesOfInterest;
        Settings = settings;
        VehicleRace = vehicleRace;
        VehicleRacer = vehicleRacer;
    }

    public bool HasReachedLocatePosition { get; set; }

    public void OnFinalSearchLocationReached()
    {

    }

    public void OnLocationReached()
    {
        EntryPoint.WriteToConsole("AI RACER HAS REACHED LOACTION");
        HasReachedLocatePosition = true;
    }

    public override void ReTask()
    {
        Start();
    }
    public override void Start()
    {
        HasReachedLocatePosition = false;
        CurrentTaskState?.Stop();

        if (PedGeneral != null && PedGeneral.Pedestrian.Exists())
        {
            Ped racePed = PedGeneral.Pedestrian;

            NativeFunction.Natives.SET_DRIVER_ABILITY(racePed, 1.0f);
            NativeFunction.Natives.SET_DRIVER_AGGRESSIVENESS(racePed, 1.0f);
            NativeFunction.Natives.SET_DRIVER_RACING_MODIFIER(racePed, 1.0f);

            // This is the SPEED LIMITER. Set it high so our rubber-banding isn't capped.
            NativeFunction.Natives.SET_DRIVE_TASK_MAX_CRUISE_SPEED(racePed, 250f, true);

            // Remove the SET_DRIVE_TASK_CRUISE_SPEED(500f) call from here. 
            // Let AIVehicleRacer.cs handle the actual speed.

            NativeFunction.Natives.SET_PED_SEEING_RANGE(racePed, 10000f);
            NativeFunction.Natives.SET_PED_COMBAT_ATTRIBUTES(racePed, 3, false);
            NativeFunction.Natives.SET_PED_CONFIG_FLAG(racePed, 118, true);
        }

        GetNewTaskState();
        CurrentTaskState?.Start();
    }
    public override void Stop()
    {
        CurrentTaskState?.Stop();
    }

    public override void Update()
    {
        if (VehicleRacer == null || PedGeneral == null) return;

        // Detect if the racer has moved on to a new checkpoint in the base class
        if (AssignedCheckpoint != VehicleRacer.TargetCheckpoint)
        {
            GetNewTaskState();
        }

        if (CurrentTaskState == null || !CurrentTaskState.IsValid)
        {
            Start();
        }
        else
        {
            SubTaskName = CurrentTaskState.DebugName;
            CurrentTaskState.Update();
        }
    }

    private void GetNewTaskState()
    {
        if (VehicleRacer?.TargetCheckpoint != null)
        {
            AssignedCheckpoint = VehicleRacer.TargetCheckpoint;

           
            CurrentTaskState = new GoToPositionVehicleRaceTaskState(
                PedGeneral, Player, World, SeatAssigner, Settings, true, AssignedCheckpoint.Position, this);

            CurrentTaskState.Start();
        }
    }
}

