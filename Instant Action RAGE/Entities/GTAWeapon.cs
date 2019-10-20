﻿using Instant_Action_RAGE.Entities.Weapon_Variation;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GTAWeapon
{
    public enum WeaponCategory
    {
        Melee = 0,
        Pistol = 1,
        Shotgun = 2,
        SMG = 3,
        AR = 4,
        LMG = 5,
        Sniper = 6,
        Heavy = 7,
    }
    public GTAWeapon(String _Name, short _AmmoAmount, WeaponCategory _Category, int _WeaponLevel, ulong _Hash)
    {
        Name = _Name;
        AmmoAmount = _AmmoAmount;
        Category = _Category;
        WeaponLevel = _WeaponLevel;
        Hash = _Hash;
    }
    public GTAWeapon(String _Name, short _AmmoAmount, WeaponCategory _Category, int _WeaponLevel, ulong _Hash, bool _isPoliceIssue)
    {
        Name = _Name;
        AmmoAmount = _AmmoAmount;
        Category = _Category;
        WeaponLevel = _WeaponLevel;
        Hash = _Hash;
        isPoliceIssue = _isPoliceIssue;
    }
    public string Name;
    public short AmmoAmount;
    public WeaponCategory Category;
    public int WeaponLevel;
    public ulong Hash;
    public string ScannerFile;
    public bool isPoliceIssue = false;
    public bool CanPistolSuicide = false;
}

