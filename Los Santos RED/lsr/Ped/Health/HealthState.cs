﻿using LosSantosRED.lsr;
using LosSantosRED.lsr.Interface;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HealthState
{
    private int Armor;
    private int CurrentArmor;
    private int CurrentHealth;
    private uint GameTimeLastBled;
    private uint GameTimeLastCheckedDamage;
    private int Health;
    private bool HurtByPed;
    private bool HurtByVehicle;
    private ISettingsProvideable Settings;

    public HealthState()
    {

    }
    public HealthState(PedExt _MyPed, ISettingsProvideable settings)
    {
        MyPed = _MyPed;
        Health = _MyPed.Pedestrian.Health;
        Armor = _MyPed.Pedestrian.Armor;
        CurrentArmor = Armor;
        CurrentHealth = Health;
        Settings = settings;
    }
    public PedExt MyPed { get; set; }
    public bool HasLoggedDeath { get; private set; }
    private bool NeedDamageCheck
    {
        get
        {
            if(!HasLoggedDeath && MyPed.Pedestrian.Exists() && MyPed.Pedestrian.IsDead)
            {
                return true;
            }
            if(MyPed.DistanceToPlayer >= 400)
            {
                return false;
            }
            if (Game.GameTime - GameTimeLastCheckedDamage >= 300)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    private bool ShouldBleed
    {
        get
        {
            if (GameTimeLastBled == 0)
                return true;
            else if (Game.GameTime - GameTimeLastBled >= 2500)
                return true;
            else
                return false;
        }
    }

    public bool WasShot { get; private set; }
    public bool WasMeleeAttacked { get; private set; }
    public bool WasHitByVehicle { get; private set; }

    public void Update(IPoliceRespondable CurrentPlayer)
    {
        if (NeedDamageCheck && MyPed.Pedestrian.Exists() && !HasLoggedDeath)
        {
            GameTimeLastCheckedDamage = Game.GameTime;
            CurrentHealth = MyPed.Pedestrian.Health;
            CurrentArmor = MyPed.Pedestrian.Armor;
            if(CurrentHealth <= 0)
            {
                HasLoggedDeath = true;//need to check once after the ped died to see who killed them, butr checking more is wasteful
            }
            if (CurrentHealth < Health || CurrentArmor < Armor)
            {
                GameFiber.Yield();
                if (MyPed.Pedestrian.Exists())
                {
                    EntryPoint.WriteToConsole($"HEALTHSTATE DAMAGE DETECTED {MyPed.Pedestrian} CurrentHealth {CurrentHealth} CurrentArmor {CurrentArmor} Existing Health {Health} Existing Armor {Armor}", 5);
                    FlagDamage(CurrentPlayer);
                    GameFiber.Yield();
                    ModifyDamage();
                    GameFiber.Yield();
                    Health = CurrentHealth;
                    Armor = CurrentArmor;
                }
            }
        }
    }
    public void Update()
    {
        if (NeedDamageCheck && MyPed.Pedestrian.Exists() && !HasLoggedDeath)
        {
            GameTimeLastCheckedDamage = Game.GameTime;
            CurrentHealth = MyPed.Pedestrian.Health;
            CurrentArmor = MyPed.Pedestrian.Armor;
            if (CurrentHealth <= 0)
            {
                HasLoggedDeath = true;//need to check once after the ped died to see who killed them, but checking more is wasteful
            }
            if (CurrentHealth < Health || CurrentArmor < Armor)
            {
               // EntryPoint.WriteToConsole($"HEALTHSTATE DAMAGE DETECTED {MyPed.Pedestrian} CurrentHealth {CurrentHealth} CurrentArmor {CurrentArmor} Existing Health {Health} Existing Armor {Armor}", 5);
                ModifyDamage();
                Health = CurrentHealth;
                Armor = CurrentArmor;
            }
        }
    }
    public void Reset()
    {
        HasLoggedDeath = false;
        GameTimeLastCheckedDamage = 0;
        if(MyPed.Pedestrian.Exists())
        {
            Health = MyPed.Pedestrian.Health;
            Armor = MyPed.Pedestrian.Armor;
            CurrentArmor = Armor;
            CurrentHealth = Health;
        }
    }
    private void FlagDamage(IPoliceRespondable CurrentPlayer)
    {
        if(CurrentPlayer == null)//only flag the player we want to have the damage
        {
            return;
        }
        if (MyPed.Pedestrian.IsDead)
        {
            MyPed.LogSourceOfDeath();
            if (MyPed.CheckKilledBy(CurrentPlayer.Character))
            {
                CurrentPlayer.AddKilled(MyPed, WasShot, WasMeleeAttacked, WasHitByVehicle);
               // EntryPoint.WriteToConsole($"FlagDamage: {MyPed.Pedestrian.Handle} Killed By Player", 5);
            }
        }
        else
        {
            if (!Settings.SettingsManager.PlayerSettings.Violations_TreatAsCop && !CurrentPlayer.IsCop && !MyPed.HasBeenHurtByPlayer && MyPed.CheckHurtBy(CurrentPlayer.Character,false))
            {
                if (Health - CurrentHealth + Armor - CurrentArmor > 5)
                {
                    MyPed.HasBeenHurtByPlayer = true;
                    CurrentPlayer.AddInjured(MyPed, WasShot, WasMeleeAttacked, WasHitByVehicle);
                   // EntryPoint.WriteToConsole($"FlagDamage: {MyPed.Pedestrian.Handle} Hurt By Player", 5);
                }
                else
                {
                   // EntryPoint.WriteToConsole($"FlagDamage: {MyPed.Pedestrian.Handle} Hurt By Player (Small Amount Discarded)", 5);
                }
            }
        }
    }
    private BodyLocation GetDamageLocation(Ped Pedestrian)
    {
        int outBone = 0;
        unsafe
        {
            NativeFunction.CallByName<bool>("GET_PED_LAST_DAMAGE_BONE", Pedestrian, &outBone);
        }

        if (outBone != 0)
        {
            if (Settings.SettingsManager.DamageSettings.ClearDamage)
            {
                NativeFunction.CallByName<bool>("CLEAR_PED_LAST_DAMAGE_BONE", Pedestrian);
            }
            Bone DamagedOne = GetBone(outBone);//    .FirstOrDefault(x => x.Tag == DamagedBoneId);
            if (DamagedOne != null)
            {
                return DamagedOne.Location;
            }
            else
            {
                return BodyLocation.Unknown;
            }
        }
        else
        {
            return BodyLocation.Unknown;
        }
    }
    private float GetDamageModifier(InjuryType injury, bool IsArmor)
    {
        if (IsArmor)
        {
            if (injury == InjuryType.Normal)
                return Settings.SettingsManager.DamageSettings.Armor_NormalDamageModifier;
            else if (injury == InjuryType.Graze)
                return Settings.SettingsManager.DamageSettings.Armor_GrazeDamageModifier;
            else if (injury == InjuryType.Critical)
                return Settings.SettingsManager.DamageSettings.Armor_CriticalDamageModifier;
            else if (injury == InjuryType.Vanilla)
                return 1.0f;
            else
                return 1.0f;
        }
        else
        {
            if (injury == InjuryType.Fatal)
                return Settings.SettingsManager.DamageSettings.Health_FatalDamageModifier;
            else if (injury == InjuryType.Normal)
                return Settings.SettingsManager.DamageSettings.Health_NormalDamageModifier;
            else if (injury == InjuryType.Graze)
                return Settings.SettingsManager.DamageSettings.Health_GrazeDamageModifier;
            else if (injury == InjuryType.Critical)
                return Settings.SettingsManager.DamageSettings.Health_CriticalDamageModifier;
            else if (injury == InjuryType.Vanilla)
                return 1.0f;
            else
                return 1.0f;
        }
    }
    private void ModifyDamage()
    {
        if (!Settings.SettingsManager.DamageSettings.ModifyDamage || !MyPed.Pedestrian.Exists())
        {
            return;
        }

        HurtByPed = NativeFunction.CallByName<bool>("HAS_ENTITY_BEEN_DAMAGED_BY_ANY_PED", MyPed.Pedestrian);
        HurtByVehicle = NativeFunction.CallByName<bool>("HAS_ENTITY_BEEN_DAMAGED_BY_ANY_VEHICLE", MyPed.Pedestrian);
        if (HurtByPed || HurtByVehicle)
        {
            int TotalDamage = Health - CurrentHealth + Armor - CurrentArmor;
            int HealthDamage = Health - CurrentHealth;
            int ArmorDamage = Armor - CurrentArmor;
            BodyLocation DamagedLocation = GetDamageLocation(MyPed.Pedestrian);
            WeaponCategory category = WeaponCategory.Unknown;
            if (NativeFunction.CallByName<bool>("HAS_PED_BEEN_DAMAGED_BY_WEAPON", MyPed.Pedestrian, 0, 1))
            {
                category = WeaponCategory.Melee;
                WasMeleeAttacked = true;
            }
            else if (NativeFunction.CallByName<bool>("HAS_PED_BEEN_DAMAGED_BY_WEAPON", MyPed.Pedestrian, 0, 2))
            {
                if(MyPed.Pedestrian.IsStunned)
                {
                    category = WeaponCategory.Melee;
                }
                else
                {
                    category = WeaponCategory.Pistol;
                    WasShot = true;
                }
            }
            else if (NativeFunction.CallByName<bool>("HAS_ENTITY_BEEN_DAMAGED_BY_ANY_VEHICLE", MyPed.Pedestrian))
            {
                category = WeaponCategory.Vehicle;
                WasHitByVehicle = true;
            }
   
            bool CanBeFatal = false;
            if (DamagedLocation == BodyLocation.Head || DamagedLocation == BodyLocation.Neck || DamagedLocation == BodyLocation.UpperTorso)
            {
                CanBeFatal = true;
            }

            bool ArmorWillProtect = false;
            if (DamagedLocation == BodyLocation.UpperTorso)
            {
                ArmorWillProtect = true;
            }
            InjuryType HealthInjury = InjuryType.Vanilla; //RandomType(CanBeFatal);
            InjuryType ArmorInjury = InjuryType.Vanilla; //RandomType(false);
            if (MyPed.Health == 0)//already dead, we are intercepting
            {
                HealthInjury = InjuryType.Fatal;
            }
            else if (category != WeaponCategory.Vehicle && category != WeaponCategory.Melee && category != WeaponCategory.Unknown)
            {
                HealthInjury = RandomType(CanBeFatal);
                ArmorInjury = RandomType(false);
            }

            //if(HealthInjury == InjuryType.Critical || HealthInjury == InjuryType.Fatal)
            //{
            //    FlagAsBleeding();
            //}

            float HealthDamageModifier = GetDamageModifier(HealthInjury, false);
            float ArmorDamageModifier = GetDamageModifier(ArmorInjury, true);

            int NewHealthDamage = Convert.ToInt32(HealthDamage * HealthDamageModifier);

            if (!ArmorWillProtect)
            {
                NewHealthDamage = Convert.ToInt32((HealthDamage + ArmorDamage) * HealthDamageModifier);
            }

            int NewArmorDamage = 0;
            if (ArmorWillProtect)
            {
                NewArmorDamage = Convert.ToInt32(ArmorDamage * ArmorDamageModifier);
            }

            if (Health - NewHealthDamage > 0)
            {
                MyPed.Pedestrian.Health = Health - NewHealthDamage;
            }
            else
            {
                MyPed.Pedestrian.Health = 0;
            }

            if (Armor - NewArmorDamage > 0)
            {
                MyPed.Pedestrian.Armor = Armor - NewArmorDamage;
            }
            else
            {
                MyPed.Pedestrian.Armor = 0;
            }

            string DisplayString = "";
            if (MyPed.IsCop)
            {
                DisplayString = string.Format("  Cop: {0}, {1}-{2}-{3} Damage {4}/{5} Health {6}/{7}",
                 MyPed.Pedestrian.Handle, HealthInjury, DamagedLocation, category, NewHealthDamage, NewArmorDamage, MyPed.Pedestrian.Health, MyPed.Pedestrian.Armor);
            }
            else
            {
                DisplayString = string.Format("  Ped: {0}, {1}-{2}-{3} Damage {4}/{5} Health {6}/{7}",
                  MyPed.Pedestrian.Handle, HealthInjury, DamagedLocation, category, NewHealthDamage, NewArmorDamage, MyPed.Pedestrian.Health, MyPed.Pedestrian.Armor);
            }
            //EntryPoint.WriteToConsole("PedWoundSystem" + DisplayString);
        }
        if (Health != CurrentHealth && MyPed.Pedestrian.Health > 0)
        {
            SetRagdoll(CurrentHealth);
        }

    }
    private InjuryType RandomType(bool CanBeFatal)
    {
        var ToPickFrom = new List<(float, InjuryType)>
        {
            (Settings.SettingsManager.DamageSettings.NormalDamagePercent, InjuryType.Normal),
            (Settings.SettingsManager.DamageSettings.GrazeDamagePercent, InjuryType.Graze),
            (Settings.SettingsManager.DamageSettings.CriticalDamagePercent, InjuryType.Critical),
            (Settings.SettingsManager.DamageSettings.FatalDamagePercent,InjuryType.Fatal)
        };
        float Total = ToPickFrom.Sum(x => x.Item1);
        float RandomPick = RandomItems.GetRandomNumber(0, Total);//--RandomItems.MyRand.Next(0, Total);
        foreach ((float, InjuryType) percentage in ToPickFrom)
        {
            float SpawnChance = percentage.Item1;
            if (RandomPick < SpawnChance)
            {     
                if (percentage.Item2 != InjuryType.Fatal)
                {
                    return percentage.Item2;
                }
                else if (percentage.Item2 == InjuryType.Fatal && CanBeFatal)
                {
                    return percentage.Item2;
                }
            }
            RandomPick -= SpawnChance;
        }
        return InjuryType.Normal;
    }
    private void SetRagdoll(int NewHealth)
    {
        if(!Settings.SettingsManager.DamageSettings.AllowRagdoll)
        {
            return;
        }
        if (Health - NewHealth >= 65)
        {
            EntryPoint.WriteToConsole($"HEALTHSTATE: RAGDOLL 1 {MyPed.Pedestrian.Handle} Health - NewHealth = {Health - NewHealth} NewHealth {NewHealth} Health {Health} MyPed.Pedestrian.Health {MyPed.Pedestrian.Health}", 5);
            //NativeFunction.CallByName<bool>("SET_PED_TO_RAGDOLL", MyPed.Pedestrian, 3000, 3000, 0, false, false, false);
        }
        //else if (Health - NewHealth >= 35 && RandomItems.RandomPercent(60))
        //{
        //    EntryPoint.WriteToConsole($"HEALTHSTATE: RAGDOLL 2 {MyPed.Pedestrian.Handle} Health - NewHealth = {Health - NewHealth} NewHealth {NewHealth} Health {Health} MyPed.Pedestrian.Health {MyPed.Pedestrian.Health}", 5);
        //   // NativeFunction.CallByName<bool>("SET_PED_TO_RAGDOLL", MyPed.Pedestrian, 1500, 1500, 1, false, false, false);
        //}
        //else if (Health - NewHealth >= 15 && RandomItems.RandomPercent(30))
        //{
        //    EntryPoint.WriteToConsole($"HEALTHSTATE: RAGDOLL 3 {MyPed.Pedestrian.Handle} Health - NewHealth = {Health - NewHealth} NewHealth {NewHealth} Health {Health} MyPed.Pedestrian.Health {MyPed.Pedestrian.Health}", 5);
        //    NativeFunction.CallByName<bool>("SET_PED_TO_RAGDOLL", MyPed.Pedestrian, 1500, 1500, 1, false, false, false);
        //}
        //else if (Health - NewHealth >= 10)
        //{
        //    EntryPoint.WriteToConsole($"HEALTHSTATE: RAGDOLL 4 {MyPed.Pedestrian.Handle} Health - NewHealth = {Health - NewHealth} NewHealth {NewHealth} Health {Health} MyPed.Pedestrian.Health {MyPed.Pedestrian.Health}", 5);
        //}
    }
    private Bone GetBone(int ID)
    {
        List<Bone>  PedBones = new List<Bone>
        {
            new Bone("SKEL_ROOT", 4215, 0, BodyLocation.LowerTorso),
            new Bone("SKEL_Pelvis", 4103, 11816, BodyLocation.LowerTorso),
            new Bone("SKEL_L_Thigh", 4103, 58271, BodyLocation.LeftLeg),
            new Bone("SKEL_L_Calf", 4103, 63931, BodyLocation.LeftLeg),
            new Bone("SKEL_L_Foot", 4103, 14201, BodyLocation.LeftLeg),
            new Bone("SKEL_L_Toe0", 7, 2108, BodyLocation.LeftLeg),
            new Bone("IK_L_Foot", 119, 65245, BodyLocation.LeftLeg),
            new Bone("PH_L_Foot", 119, 57717, BodyLocation.LeftLeg),
            new Bone("MH_L_Knee", 119, 46078, BodyLocation.LeftLeg),
            new Bone("SKEL_R_Thigh", 4103, 51826, BodyLocation.RightLeg),
            new Bone("SKEL_R_Calf", 4103, 36864, BodyLocation.RightLeg),
            new Bone("SKEL_R_Foot", 4103, 52301, BodyLocation.RightLeg),
            new Bone("SKEL_R_Toe0", 7, 20781, BodyLocation.RightLeg),
            new Bone("IK_R_Foot", 119, 35502, BodyLocation.RightLeg),
            new Bone("PH_R_Foot", 119, 24806, BodyLocation.RightLeg),
            new Bone("MH_R_Knee", 119, 16335, BodyLocation.RightLeg),
            new Bone("RB_L_ThighRoll", 7, 23639, BodyLocation.LeftLeg),
            new Bone("RB_R_ThighRoll", 7, 6442, BodyLocation.RightLeg),
            new Bone("SKEL_Spine_Root", 4103, 57597, BodyLocation.LowerTorso),
            new Bone("SKEL_Spine0", 4103, 23553, BodyLocation.LowerTorso),
            new Bone("SKEL_Spine1", 4103, 24816, BodyLocation.LowerTorso),
            new Bone("SKEL_Spine2", 4103, 24817, BodyLocation.UpperTorso),
            new Bone("SKEL_Spine3", 4103, 24818, BodyLocation.UpperTorso),
            new Bone("SKEL_L_Clavicle", 4103, 64729, BodyLocation.LeftArm),
            new Bone("SKEL_L_UpperArm", 4103, 45509, BodyLocation.LeftArm),
            new Bone("SKEL_L_Forearm", 4215, 61163, BodyLocation.LeftArm),
            new Bone("SKEL_L_Hand", 4215, 18905, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger00", 4103, 26610, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger01", 4103, 4089, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger02", 7, 4090, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger10", 4103, 26611, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger11", 4103, 4169, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger12", 7, 4170, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger20", 4103, 26612, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger21", 4103, 4185, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger22", 7, 4186, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger30", 4103, 26613, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger31", 4103, 4137, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger32", 7, 4138, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger40", 4103, 26614, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger41", 4103, 4153, BodyLocation.LeftArm),
            new Bone("SKEL_L_Finger42", 7, 4154, BodyLocation.LeftArm),
            new Bone("PH_L_Hand", 119, 60309, BodyLocation.LeftArm),
            new Bone("IK_L_Hand", 119, 36029, BodyLocation.LeftArm),
            new Bone("RB_L_ForeArmRoll", 7, 61007, BodyLocation.LeftArm),
            new Bone("RB_L_ArmRoll", 7, 5232, BodyLocation.LeftArm),
            new Bone("MH_L_Elbow", 119, 22711, BodyLocation.LeftArm),
            new Bone("SKEL_R_Clavicle", 4103, 10706, BodyLocation.RightArm),
            new Bone("SKEL_R_UpperArm", 4103, 40269, BodyLocation.RightArm),
            new Bone("SKEL_R_Forearm", 4215, 28252, BodyLocation.RightArm),
            new Bone("SKEL_R_Hand", 4215, 57005, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger00", 4103, 58866, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger01", 4103, 64016, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger02", 7, 64017, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger10", 4103, 58867, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger11", 4103, 64096, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger12", 7, 64097, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger20", 4103, 58868, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger21", 4103, 64112, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger22", 7, 64113, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger30", 4103, 58869, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger31", 4103, 64064, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger32", 7, 64065, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger40", 4103, 58870, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger41", 4103, 64080, BodyLocation.RightArm),
            new Bone("SKEL_R_Finger42", 7, 64081, BodyLocation.RightArm),
            new Bone("PH_R_Hand", 119, 28422, BodyLocation.RightArm),
            new Bone("IK_R_Hand", 119, 6286, BodyLocation.RightArm),
            new Bone("RB_R_ForeArmRoll", 7, 43810, BodyLocation.RightArm),
            new Bone("RB_R_ArmRoll", 7, 37119, BodyLocation.RightArm),
            new Bone("MH_R_Elbow", 119, 2992, BodyLocation.RightArm),
            new Bone("SKEL_Neck_1", 4103, 39317, BodyLocation.Neck),
            new Bone("SKEL_Head", 4103, 31086, BodyLocation.Head),
            new Bone("IK_Head", 119, 12844, BodyLocation.Head),
            new Bone("FACIAL_facialRoot", 4103, 65068, BodyLocation.Head),
            new Bone("FB_L_Brow_Out_000", 1799, 58331, BodyLocation.Head),
            new Bone("FB_L_Lid_Upper_000", 1911, 45750, BodyLocation.Head),
            new Bone("FB_L_Eye_000", 1799, 25260, BodyLocation.Head),
            new Bone("FB_L_CheekBone_000", 1799, 21550, BodyLocation.Head),
            new Bone("FB_L_Lip_Corner_000", 1911, 29868, BodyLocation.Head),
            new Bone("FB_R_Lid_Upper_000", 1911, 43536, BodyLocation.Head),
            new Bone("FB_R_Eye_000", 1799, 27474, BodyLocation.Head),
            new Bone("FB_R_CheekBone_000", 1799, 19336, BodyLocation.Head),
            new Bone("FB_R_Brow_Out_000", 1799, 1356, BodyLocation.Head),
            new Bone("FB_R_Lip_Corner_000", 1911, 11174, BodyLocation.Head),
            new Bone("FB_Brow_Centre_000", 1799, 37193, BodyLocation.Head),
            new Bone("FB_UpperLipRoot_000", 5895, 20178, BodyLocation.Head),
            new Bone("FB_UpperLip_000", 6007, 61839, BodyLocation.Head),
            new Bone("FB_L_Lip_Top_000", 1911, 20279, BodyLocation.Head),
            new Bone("FB_R_Lip_Top_000", 1911, 17719, BodyLocation.Head),
            new Bone("FB_Jaw_000", 5895, 46240, BodyLocation.Head),
            new Bone("FB_LowerLipRoot_000", 5895, 17188, BodyLocation.Head),
            new Bone("FB_LowerLip_000", 6007, 20623, BodyLocation.Head),
            new Bone("FB_L_Lip_Bot_000", 1911, 47419, BodyLocation.Head),
            new Bone("FB_R_Lip_Bot_000", 1911, 49979, BodyLocation.Head),
            new Bone("FB_Tongue_000", 1911, 47495, BodyLocation.Head),
            new Bone("RB_Neck_1", 7, 35731, BodyLocation.Neck),
            new Bone("IK_Root", 119, 56604, BodyLocation.LowerTorso)
        };
        return PedBones.FirstOrDefault(x => x.Tag == ID);
    }
}