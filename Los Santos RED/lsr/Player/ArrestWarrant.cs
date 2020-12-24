﻿using LosSantosRED.lsr;
using LSR.Vehicles;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosSantosRED.lsr
{
    public class ArrestWarrant
    {
        private uint GameTimeLastAppliedWantedStats;
        public bool IsActive { get; private set; }
        public List<CriminalHistory> CriminalHistoryList { get; set; } = new List<CriminalHistory>();
        public bool RecentlyAppliedWantedStats
        {
            get
            {
                if (GameTimeLastAppliedWantedStats == 0)
                {
                    return false;
                }
                else
                {
                    return Game.GameTime - GameTimeLastAppliedWantedStats <= 5000;
                }
            }
        }
        public int LastWantedMaxLevel
        {
            get
            {
                CriminalHistory LastWanted = GetLastWantedStats();
                if (LastWanted != null)
                {
                    return LastWanted.ObservedMaxWantedLevel;
                }
                else
                {
                    return 0;
                }
            }
        }
        public bool LethalForceAuthorized
        {
            get
            {
                CriminalHistory LastWanted = GetLastWantedStats();
                if (LastWanted != null)
                {
                    return LastWanted.LethalForceAuthorized;
                }
                else
                {
                    return false;
                }
            }
        }
        public float SearchRadius
        {
            get
            {
                if (LastWantedMaxLevel > 0)
                {
                    return LastWantedMaxLevel * DataMart.Instance.Settings.SettingsManager.Police.LastWantedCenterSize;
                }
                else
                {
                    return DataMart.Instance.Settings.SettingsManager.Police.LastWantedCenterSize;
                }
            }
        }
        public void Update()
        {
            if (!Mod.Player.Instance.IsDead && !Mod.Player.Instance.IsBusted)
            {
                CheckCurrentVehicle();
                CheckSight();

                if (Mod.Player.Instance.IsWanted)
                {
                    if (!IsActive && Mod.World.Instance.AnyPoliceCanSeePlayer)
                    {
                        IsActive = true;
                    }
                }
                else
                {
                    if (IsActive && Mod.Player.Instance.CurrentPoliceResponse.HasBeenNotWantedFor >= 120000)
                    {
                        Reset();
                    }
                }
            }
        }
        public void StoreCriminalHistory(CriminalHistory rapSheet)
        {
            CriminalHistoryList.Add(rapSheet);
            Debug.Instance.WriteToLog("Arrest Warrant", "Stored Criminal History");
        }
        public void Reset()
        {
            IsActive = false;
            CriminalHistoryList.Clear();
            Debug.Instance.WriteToLog("Arrest Warrant", "History Cleared");
        }
        private void CheckCurrentVehicle()
        {
            if ((Mod.Player.Instance.IsNotWanted || Mod.Player.Instance.WantedLevel == 1) && Mod.World.Instance.AnyPoliceCanRecognizePlayer && Mod.Player.Instance.IsInVehicle && Game.LocalPlayer.Character.IsInAnyVehicle(false))//first check is cheaper, but second is required to verify
            {
                VehicleExt VehicleToCheck = Mod.Player.Instance.CurrentVehicle;

                if (VehicleToCheck == null)
                {
                    return;
                }

                if (VehicleToCheck.CopsRecognizeAsStolen)
                {
                    ApplyWantedStatsForPlate(VehicleToCheck.CarPlate.PlateNumber);
                }
            }
        }
        private void CheckSight()
        {
            if (IsActive && Mod.World.Instance.AnyPoliceCanSeePlayer)
            {
                if (Mod.Player.Instance.IsWanted)
                {
                    ApplyLastWantedStats();
                }
                else
                {
                    if (Mod.Player.Instance.CurrentPoliceResponse.NearLastWanted(SearchRadius) && Mod.Player.Instance.CurrentPoliceResponse.HasBeenNotWantedFor >= 5000)
                    {
                        ApplyLastWantedStats();
                    }
                }
            }
        }
        private void ApplyWantedStatsForPlate(string PlateNumber)
        {
            CriminalHistory StatsForPlate = GetWantedLevelStatsForPlate(PlateNumber);
            if (StatsForPlate != null)
            {
                ApplyWantedStats(StatsForPlate);
            }
        }
        private void ApplyLastWantedStats()
        {
            CriminalHistory CriminalHistory = GetLastWantedStats();
            if (CriminalHistory != null)
            {
                ApplyWantedStats(CriminalHistory);
            }
        }
        private void ApplyWantedStats(CriminalHistory CriminalHistory)
        {
            if (CriminalHistory == null)
            {
                return;
            }
            if (Mod.Player.Instance.WantedLevel < CriminalHistory.ObservedMaxWantedLevel)
            {
                Mod.Player.Instance.CurrentPoliceResponse.SetWantedLevel(CriminalHistory.ObservedMaxWantedLevel, "Applying old Wanted stats", true);
            }
            CriminalHistoryList.Remove(CriminalHistory);
            Mod.Player.Instance.CurrentPoliceResponse.CurrentCrimes = CriminalHistory;

            GameTimeLastAppliedWantedStats = Game.GameTime;
            Debug.Instance.WriteToLog("WantedLevelStats Replace", Mod.Player.Instance.CurrentPoliceResponse.CurrentCrimes.DebugPrintCrimes());
        }
        private CriminalHistory GetLastWantedStats()
        {
            if (CriminalHistoryList == null || !CriminalHistoryList.Where(x => x.PlayerSeenDuringWanted).Any())
            {
                return null;
            }

            return CriminalHistoryList.Where(x => x.PlayerSeenDuringWanted).OrderByDescending(x => x.GameTimeWantedEnded).OrderByDescending(x => x.GameTimeWantedStarted).FirstOrDefault();
        }
        private CriminalHistory GetWantedLevelStatsForPlate(string PlateNumber)
        {
            if (CriminalHistoryList == null || !CriminalHistoryList.Where(x => x.PlayerSeenDuringWanted).Any())
            {
                return null;
            }

            return CriminalHistoryList.Where(x => x.PlayerSeenDuringWanted && x.WantedPlates.Any(y => y.PlateNumber == PlateNumber)).OrderByDescending(x => x.GameTimeWantedEnded).OrderByDescending(x => x.GameTimeWantedStarted).FirstOrDefault();
        }
    }
}