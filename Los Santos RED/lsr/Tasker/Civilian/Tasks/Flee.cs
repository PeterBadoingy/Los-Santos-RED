﻿using LosSantosRED.lsr.Interface;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Flee : ComplexTask
{
    private uint GameTimeStartedCallIn;
    private uint GameTimeStartedFlee;
    private bool HasStartedPhoneTask;
    private uint GameTimeToCallIn = 10000;
    private bool isInVehicle = false;
    private ITargetable Target;
    private bool isCowering = false;
    private ISettingsProvideable Settings;
    private bool IsWithinCowerDistance => Ped.DistanceToPlayer <= Ped.CowerDistance;
    private bool ShouldCower => Ped.WillCower && IsWithinCowerDistance && !Player.RecentlyShot;
    private bool ShouldCallIn => Ped.HasCellPhone && (Ped.WillCallPolice || (Ped.WillCallPoliceIntense && Ped.PedReactions.HasSeenIntenseCrime));
    public Flee(IComplexTaskable ped, ITargetable player, ISettingsProvideable settings) : base(player, ped, 5000)
    {
        Name = "Flee";
        SubTaskName = "";
        Target = player;
        Settings = settings;
    }
    public override void Start()
    {
        if (!Ped.Pedestrian.Exists())
        {
            return;
        }
        NativeFunction.Natives.SET_PED_SHOULD_PLAY_IMMEDIATE_SCENARIO_EXIT(Ped.Pedestrian);
        isInVehicle = Ped.Pedestrian.IsInAnyVehicle(false);
        ReTask();
        GameTimeStartedFlee = Game.GameTime;
        GameTimeLastRan = Game.GameTime;    
    }
    public override void Update()
    {
        if (Ped.Pedestrian.Exists() && isInVehicle != Ped.Pedestrian.IsInAnyVehicle(false))
        {
            isInVehicle = Ped.Pedestrian.IsInAnyVehicle(false);
            ReTask();
        }
        if(isInVehicle && Ped.IsDriver)
        {
            NativeFunction.Natives.SET_DRIVE_TASK_DRIVING_STYLE(Ped.Pedestrian, (int)eCustomDrivingStyles.Vanilla_Alerted);
            NativeFunction.Natives.SET_DRIVE_TASK_CRUISE_SPEED(Ped.Pedestrian, 100f);//new
            NativeFunction.Natives.SET_DRIVER_ABILITY(Ped.Pedestrian, 1.0f);
            NativeFunction.Natives.SET_DRIVER_AGGRESSIVENESS(Ped.Pedestrian, 1.0f);
        }
        if(ShouldCower != isCowering)
        {
            ReTask();
        }
        CheckCallIn();
        GameTimeLastRan = Game.GameTime;
    }
    public override void Stop()
    {

    }
    public override void ReTask()
    {
        if (!Ped.Pedestrian.Exists())
        {
            return;
        }
        Ped.Pedestrian.BlockPermanentEvents = true;
        Ped.Pedestrian.KeepTasks = true;
        if (isInVehicle && Ped.IsDriver)
        {
            TaskVehicleFlee();
        }
        else
        {
            if (Ped.WillCower && IsWithinCowerDistance)
            {
                TaskCowerOnFoot();
            }
            else
            {
                TaskFleeOnFoot();
            }
        }
        isCowering = ShouldCower;
    }
    private void CheckCallIn()
    {
        if(!ShouldCallIn)
        {
            return;
        }
        if (!Ped.Pedestrian.Exists() && Settings.SettingsManager.CivilianSettings.AllowCallInIfPedDoesNotExist)
        {
            if (Settings.SettingsManager.CivilianSettings.AllowCallInIfPedDoesNotExist && Game.GameTime - GameTimeStartedCallIn >= Settings.SettingsManager.CivilianSettings.GameTimeToCallInIfPedDoesNotExist && (Ped.PlayerCrimesWitnessed.Any() || Ped.OtherCrimesWitnessed.Any() || Ped.PedAlerts.HasCrimeToReport))
            {
                EntryPoint.WriteToConsole("NOT EXISTING PED CALLED IN CRIME");
                Ped.ReportCrime(Player);
            }
            return;
        }
        if (!Ped.Pedestrian.Exists() || !Ped.CanFlee || isCowering)
        {
            return;
        }
        if (!HasStartedPhoneTask && Game.GameTime - GameTimeStartedFlee >= GameTimeToCallIn)
        {
            TaskUsePhone();
        }
        if (HasStartedPhoneTask && Game.GameTime - GameTimeStartedCallIn >= GameTimeToCallIn + Settings.SettingsManager.CivilianSettings.GameTimeAfterCallInToReportCrime && (Ped.PlayerCrimesWitnessed.Any() || Ped.OtherCrimesWitnessed.Any() || Ped.PedAlerts.HasCrimeToReport))
        {
            Ped.ReportCrime(Player);
            EntryPoint.WriteToConsole($"{Ped.Handle} CALLED IN CRIME");
            if (Ped.Pedestrian.Exists())
            {
                ReTask();
            }
        }
    }
    private void TaskUsePhone()
    {
        NativeFunction.CallByName<bool>("TASK_USE_MOBILE_PHONE_TIMED", Ped.Pedestrian, Settings.SettingsManager.CivilianSettings.GameTimeAfterCallInToReportCrime);
        HasStartedPhoneTask = true;
        Ped.PlaySpeech(new List<string>() { "GENERIC_SHOCKED_HIGH", "GENERIC_FRUSTRATED_HIGH", "GET_OUT_OF_HERE" }, false, false);
        EntryPoint.WriteToConsole($"{Ped.Handle} STARTED PHONE TASK");
    }
    private void TaskVehicleFlee()
    {
        Vector3 CurrentPos = Ped.Pedestrian.Position;
        NativeFunction.CallByName<bool>("TASK_SMART_FLEE_COORD", Ped.Pedestrian, CurrentPos.X, CurrentPos.Y, CurrentPos.Z, 5000f, -1, true, false);
        NativeFunction.Natives.SET_DRIVE_TASK_DRIVING_STYLE(Ped.Pedestrian, (int)eCustomDrivingStyles.Vanilla_Alerted);
        NativeFunction.Natives.SET_DRIVE_TASK_CRUISE_SPEED(Ped.Pedestrian, 100f);//new
        NativeFunction.Natives.SET_DRIVER_ABILITY(Ped.Pedestrian, 1.0f);
        NativeFunction.Natives.SET_DRIVER_AGGRESSIVENESS(Ped.Pedestrian, 1.0f);
        EntryPoint.WriteToConsole("FLEE SET PED FLEE IN VEHICLE");
    }
    private void TaskCowerOnFoot()
    {
        NativeFunction.Natives.TASK_COWER(Ped.Pedestrian, -1);
        EntryPoint.WriteToConsole("FLEE SET PED COWER");
    }
    private void TaskFleeOnFoot()
    {
        Vector3 CurrentPos = Ped.Pedestrian.Position;
        NativeFunction.CallByName<bool>("TASK_SMART_FLEE_COORD", Ped.Pedestrian, CurrentPos.X, CurrentPos.Y, CurrentPos.Z, 5000f, -1, true, false);
        EntryPoint.WriteToConsole("FLEE SET PED FLEE");
    }
}

