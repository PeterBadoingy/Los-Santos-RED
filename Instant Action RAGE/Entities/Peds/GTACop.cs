﻿
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GTACop : GTAPed
{
    public GTACop(Ped _Pedestrian, bool _canSeePlayer, int _Health,Agency _Agency) : base (_Pedestrian, _canSeePlayer, _Health)
    {
        //Pedestrian = _Pedestrian;
        //canSeePlayer = _canSeePlayer;
        //Health = _Health;
        AssignedAgency = _Agency;
        SetAccuracyAndSightRange();
        if (_Pedestrian.Model.Name.ToLower() == "s_m_y_swat_01")
            IsSwat = true;
    }
    public GTACop(Ped _Pedestrian, bool _canSeePlayer, uint _gameTimeLastSeenPlayer,Vector3 _positionLastSeenPlayer, int _Health,Agency _Agency) : base(_Pedestrian, _canSeePlayer, _Health)
    {
        Pedestrian = _Pedestrian;
        canSeePlayer = _canSeePlayer;
        GameTimeLastSeenPlayer = _gameTimeLastSeenPlayer;
        PositionLastSeenPlayer = _positionLastSeenPlayer;
        Health = _Health;
        AssignedAgency = _Agency;
        SetAccuracyAndSightRange();
        if (_Pedestrian.Model.Name.ToLower() == "s_m_y_swat_01")
            IsSwat = true;
    }

    public bool isTasked { get; set; } = false;
    public bool WasRandomSpawn { get; set; } = false;
    public bool WasRandomSpawnDriver { get; set; } = false;
    public bool IsBikeCop { get; set; } = false;
    public bool IsSwat { get; set; } = false;
    public bool isPursuitPrimary { get; set; } = false;
    public PoliceTask.Task TaskType { get; set; } = PoliceTask.Task.NoTask;
    public GameFiber TaskFiber { get; set; }
    public bool SetTazer { get; set; } = false;
    public bool SetUnarmed { get; set; } = false;
    public bool SetDeadly { get; set; } = false;
    public bool TaskIsQueued { get; set; } = false;
    public uint GameTimeLastWeaponCheck { get; set; }
    public uint GameTimeLastTask { get; set; }
    public uint GameTimeLastSpoke { get; set; }
    public GTAWeapon IssuedPistol { get; set; } = new GTAWeapon("weapon_pistol", 60, GTAWeapon.WeaponCategory.Pistol, 1, 453432689, true,true,false,true);
    public GTAWeapon IssuedHeavyWeapon { get; set; }
    public WeaponVariation PistolVariation { get; set; }
    public WeaponVariation HeavyVariation { get; set; }
    public Agency AssignedAgency { get; set; } = Agencies.LSPD;
    public bool AtWantedCenterDuringSearchMode { get; set; } = false;
    public void SetAccuracyAndSightRange()
    {
        Pedestrian.VisionRange = 55f;
        Pedestrian.HearingRange = 25;
        if(Settings.OverridePoliceAccuracy)
            Pedestrian.Accuracy = Settings.PoliceGeneralAccuracy;
    }
    public bool NeedsWeaponCheck
    {
        get
        {
            if (GameTimeLastWeaponCheck == 0)
                return true;
            else if (Game.GameTime > GameTimeLastWeaponCheck + 500)
                return true;
            else
                return false;
        }       
    }
    public bool CanSpeak
    {
        get
        {
            if (GameTimeLastSpoke == 0)
                return true;
            else if (Game.GameTime > GameTimeLastSpoke + 15000)
                return true;
            else
                return false;
        }
    }
}

