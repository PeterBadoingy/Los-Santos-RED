﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ViolationSettings : ISettingsDefaultable
{
    [Description("Additional time peds will react to you hurting a civilian. Used for when they only see you directly after you hurt a ped.")]
    public uint RecentlyHurtCivilianTime { get; set; }
    [Description("Additional time peds will react to you hurting a cop. Used for when they only see you directly after you hurt a ped.")]
    public uint RecentlyHurtPoliceTime { get; set; }
    [Description("Additional time peds will react to you killing a civilian. Used for when they only see you directly after you killed a ped.")]
    public uint RecentlyKilledCivilianTime { get; set; }
    [Description("Additional time peds will react to you killing a cop. Used for when they only see you directly after you killed a ped.")]
    public uint RecentlyKilledPoliceTime { get; set; }
    [Description("Distance the cops will consider you guilty if you killed the target and stand around them. Don't stand near people you murdered (common sense?)")]
    public float MurderDistance { get; set; }
    [Description("Time you can violate driving against traffic before the cops react. Used to ignore small traffic errors.")]
    public uint RecentlyDrivingAgainstTrafficTime { get; set; }
    [Description("Time you can violate driving on pavement before the cops react. Used to ignore small traffic errors.")]
    public uint RecentlyDrivingOnPavementTime { get; set; }
    [Description("Additional time peds will react to you hitting a ped with a car. Used for when they only see you directly after you hit a ped.")]
    public uint RecentlyHitPedTime { get; set; }
    [Description("Additional time peds will react to you hitting a peds car with a car. Used for when they only see you directly after you hit a ped.")]
    public uint RecentlyHitVehicleTime { get; set; }
    [Description("Time resisting arrest will trigger when you are moving fast.")]
    public uint ResistingArrestFastTriggerTime { get; set; }
    [Description("Time resisting arrest will trigger when you are moving at a medium pace.")]
    public uint ResistingArrestMediumTriggerTime { get; set; }
    [Description("Time resisting arrest will trigger when you are barely moving or walking")]
    public uint ResistingArrestSlowTriggerTime { get; set; }
    [Description("If enabled, the game will assume you are a cop and not trigger violations for anything besides murding or hurting other cops")]
    public bool TreatAsCop { get; set; }
    public ViolationSettings()
    {
        SetDefault();
#if DEBUG

#endif
    }
    public void SetDefault()
    {
        RecentlyHurtCivilianTime = 5000;
        RecentlyHurtPoliceTime = 5000;
        RecentlyKilledCivilianTime = 5000;
        RecentlyKilledPoliceTime = 5000;
        MurderDistance = 9f;
        RecentlyDrivingAgainstTrafficTime = 1000;
        RecentlyDrivingOnPavementTime = 1000;
        RecentlyHitPedTime = 1500;
        RecentlyHitVehicleTime = 1500;
        ResistingArrestFastTriggerTime = 5000;
    }
}