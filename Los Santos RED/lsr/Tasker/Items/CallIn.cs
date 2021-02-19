﻿using LosSantosRED.lsr.Interface;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CallIn : ComplexTask
{
    private uint GameTimeStartedCallIn;
    public CallIn(IComplexTaskable ped, ITargetable player) : base(player, ped, 1000)
    {
        Name = "CallIn";
        SubTaskName = "";
        GameTimeStartedCallIn = Game.GameTime;
    }
    public override void Start()
    {
        
        //Game.Console.Print($"TASKER: CallIn Start: {Ped.Pedestrian.Handle}");
        unsafe
        {
            int lol = 0;
            NativeFunction.CallByName<bool>("OPEN_SEQUENCE_TASK", &lol);
            NativeFunction.CallByName<bool>("TASK_SMART_FLEE_PED", 0, Game.LocalPlayer.Character, 50f, 7000);//100f
            NativeFunction.CallByName<bool>("TASK_USE_MOBILE_PHONE_TIMED", 0, 5000);
            NativeFunction.CallByName<bool>("TASK_SMART_FLEE_PED", 0, Game.LocalPlayer.Character, 100f, -1);
            NativeFunction.CallByName<bool>("SET_SEQUENCE_TO_REPEAT", lol, false);
            NativeFunction.CallByName<bool>("CLOSE_SEQUENCE_TASK", lol);
            NativeFunction.CallByName<bool>("TASK_PERFORM_SEQUENCE", Ped.Pedestrian, lol);
            NativeFunction.CallByName<bool>("CLEAR_SEQUENCE_TASK", &lol);
        }
        GameTimeLastRan = Game.GameTime;
    }
    public override void Update()
    {
        //Game.Console.Print($"TASKER: CallIn Update: {Ped.Pedestrian.Handle}");
        if(Game.GameTime - GameTimeStartedCallIn >= 4000 && Ped.CrimesWitnessed.Any())
        {
            ReportCrime();
        }
        GameTimeLastRan = Game.GameTime;
    }
    public override void Stop()
    {

    }
    private void ReportCrime()
    {
        //Game.Console.Print($"TASKER: CallIn ReportCrime: {Ped.Pedestrian.Handle}");
        if (Ped.Pedestrian.Exists() && Ped.Pedestrian.IsAlive && !Ped.Pedestrian.IsRagdoll)
        {
            Crime ToReport = Ped.CrimesWitnessed.OrderBy(x => x.Priority).FirstOrDefault();
            if(ToReport == null)
            {
                //Game.Console.Print($"TASKER: CallIn ReportCrime Handle {Ped.Pedestrian.Handle} NULL CRIME!!!!");
            }
            else
            {
                //Game.Console.Print($"TASKER: CallIn ReportCrime Handle {Ped.Pedestrian.Handle} Crime {ToReport.ID}");
                //Player.PoliceResponse.AddCrime(ToReport, false, Ped.PositionLastSeenCrime, Ped.VehicleLastSeenPlayerIn, Ped.WeaponLastSeenPlayerWith, Ped.EverSeenPlayer && Ped.ClosestDistanceToPlayer <= 20f);

                Player.AddCrime(ToReport, false, Ped.PositionLastSeenCrime, Ped.VehicleLastSeenPlayerIn, Ped.WeaponLastSeenPlayerWith, Ped.EverSeenPlayer && Ped.ClosestDistanceToPlayer <= 20f);
            }

            Ped.CrimesWitnessed.Clear();      
        }
    }
}

