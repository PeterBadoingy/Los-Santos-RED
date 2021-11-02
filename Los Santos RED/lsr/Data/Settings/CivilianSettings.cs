﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CivilianSettings
{
    public bool ManageCivilianTasking { get; set; } = true;
    public float FightPercentage { get; set; } = 7f;//5f
    public float CallPolicePercentage { get; set; } = 65f;//55f
    public float SecurityFightPercentage { get; set; } = 30f;//70f
    public float GangFightPercentage { get; set; } = 85f;
    public bool OverrideHealth { get; set; } = true;
    public int MinHealth { get; set; } = 70;
    public int MaxHealth { get; set; } = 100;
    public bool OverrideAccuracy { get; set; } = true;
    public int GeneralAccuracy { get; set; } = 5;//10
    public float SightDistance { get; set; } = 70f;//90f
    public float GunshotHearingDistance { get; set; } = 80f;//100f
    public bool TaskMissionPeds { get; set; } = false;
    public bool AllowMissionPedsToInteract { get; set; } = false;
    public CivilianSettings()
    {

    }

}