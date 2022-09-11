﻿using LosSantosRED.lsr;
using LosSantosRED.lsr.Interface;
using LSR.Vehicles;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WeaponViolations
{
    private uint GameTimeStartedBrandishing;
    private IViolateable Player;
    private Violations Violations;
    private ISettingsProvideable Settings;
    private ITimeReportable Time;

    public WeaponViolations(IViolateable player, Violations violations, ISettingsProvideable settings, ITimeReportable time)
    {
        Player = player;
        Violations = violations;
        Settings = settings;
        Time = time;
    }
    public void Setup()
    {

    }
    public void Dispose()
    {

    }
    public void Reset()
    {
        GameTimeStartedBrandishing = 0;
    }
    public void Update()
    {
        if (Player.RecentlyShot)
        {
            if (!(Player.Character.IsCurrentWeaponSilenced || Player.WeaponEquipment.CurrentWeaponCategory == WeaponCategory.Melee || Player.WeaponEquipment.CurrentWeaponCategory == WeaponCategory.Throwable))
            {
                Violations.AddViolating("FiringWeapon");//.IsCurrentlyViolating = true;
                if (Player.AnyPoliceRecentlySeenPlayer || (Player.CurrentTargetedPed != null && Player.CurrentTargetedPed.IsCop) || (Player.AnyPoliceCanHearPlayer && Player.ClosestPoliceDistanceToPlayer <= 30f))
                {
                    Violations.AddViolating("FiringWeaponNearPolice");//.IsCurrentlyViolating = true;
                }
            }
        }
        bool isBrandishing = CheckBrandishing();
        if (isBrandishing && Player.Character.Inventory.EquippedWeapon != null && !Player.IsInVehicle)
        {
            Violations.AddViolating("BrandishingWeapon");//.IsCurrentlyViolating = true;
            if (Player.WeaponEquipment.CurrentWeapon != null && Player.WeaponEquipment?.CurrentWeapon?.WeaponLevel >= 4)
            {
                Violations.AddViolating("TerroristActivity");//.IsCurrentlyViolating = true;
            }
            if (Player.WeaponEquipment.CurrentWeapon != null && Player.WeaponEquipment?.CurrentWeapon?.WeaponLevel >= 3)
            {
                Violations.AddViolating("BrandishingHeavyWeapon");//.IsCurrentlyViolating = true;
            }
            if (Player.WeaponEquipment.CurrentWeapon != null && Player.WeaponEquipment.CurrentWeapon?.Category == WeaponCategory.Melee)
            {
                Violations.AddViolating("BrandishingCloseCombatWeapon");//.IsCurrentlyViolating = true;
            }
        }
        if (isBrandishing && Player.CurrentTargetedPed != null && Player.WeaponEquipment?.CurrentWeapon?.Category != WeaponCategory.Melee)
        {
            if (Player.CurrentTargetedPed.IsCop)
            {
                Violations.AddViolating("AimingWeaponAtPolice");
            }
            else
            {
                Violations.AddViolating("AssaultingWithDeadlyWeapon");
            }
        }
    }
    private bool CheckBrandishing()
    {
        if (Player.IsVisiblyArmed)
        {
            if (GameTimeStartedBrandishing == 0)
            {
                GameTimeStartedBrandishing = Game.GameTime;
            }
        }
        else
        {
            GameTimeStartedBrandishing = 0;
        }

        if (GameTimeStartedBrandishing > 0 && Game.GameTime - GameTimeStartedBrandishing >= 1500)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

