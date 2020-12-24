﻿using ExtensionsMethods;
using LosSantosRED.lsr;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LosSantosRED.lsr
{
    public class PoliceResponse
    {
        private PoliceState PrevPoliceState;
        private uint GameTimePoliceStateStart;
        private uint GameTimeLastSetWanted;
        private uint GameTimeWantedStarted;
        private uint GameTimeWantedLevelStarted;
        private uint GameTimeLastWantedEnded;
        private uint GameTimeLastRequestedBackup;
        private Blip CurrentWantedCenterBlip;
        private Blip LastWantedCenterBlip;
        private int PreviousWantedLevel;
        private PoliceState CurrentPoliceState;

        public PoliceResponse()
        {
            CurrentCrimes = new CriminalHistory();
        }

        private enum PoliceState
        {
            Normal = 0,
            UnarmedChase = 1,
            CautiousChase = 2,
            DeadlyChase = 3,
            ArrestedWait = 4,
        }
        public int WantedLevelLastset { get; set; }
        public float LastWantedSearchRadius { get; set; }
        public bool PlayerSeenDuringCurrentWanted { get; set; }
        public bool IsWeaponsFree { get; set; }
        public CriminalHistory CurrentCrimes { get; set; }
        public Vector3 LastWantedCenterPosition { get; set; }
        public Vector3 PlaceWantedStarted { get; private set; }
        public uint HasBeenNotWantedFor
        {
            get
            {
                if (Game.LocalPlayer.WantedLevel != 0)
                {
                    return 0;
                }
                if (GameTimeLastWantedEnded == 0)
                {
                    return 0;
                }
                else
                    return Game.GameTime - GameTimeLastWantedEnded;
            }
        }
        public uint HasBeenWantedFor
        {
            get
            {
                if (Game.LocalPlayer.WantedLevel == 0)
                {
                    return 0;
                }
                else
                    return Game.GameTime - GameTimeWantedStarted;
            }
        }
        public uint HasBeenAtCurrentWantedLevelFor
        {
            get
            {
                if (Game.LocalPlayer.WantedLevel == 0)
                {
                    return 0;
                }
                else
                    return Game.GameTime - GameTimeWantedLevelStarted;
            }
        }
        public uint HasBeenAtCurrentPoliceStateFor
        {
            get
            {
                return Game.GameTime - GameTimePoliceStateStart;
            }
        }
        public bool IsDeadlyChase
        {
            get
            {
                if (CurrentPoliceState == PoliceState.DeadlyChase)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string CurrentPoliceStateString
        {
            get
            {
                return CurrentPoliceState.ToString();
            }
        }
        public string CrimesObservedJoined
        {
            get
            {
                return string.Join(",", CurrentCrimes.CrimesObserved.Select(x => x.AssociatedCrime.Name));
            }
        }
        public string CrimesReportedJoined
        {
            get
            {
                return string.Join(",", CurrentCrimes.CrimesReported.Select(x => x.AssociatedCrime.Name));
            }
        }
        public bool HasReportedCrimes
        {
            get
            {
                return CurrentCrimes.CrimesReported.Any();
            }
        }
        public bool RecentlySetWanted
        {
            get
            {
                if (GameTimeLastSetWanted == 0)
                {
                    return false;
                }
                else if (Game.GameTime - GameTimeLastSetWanted <= 5000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool RecentlyRequestedBackup
        {
            get
            {
                if (GameTimeLastRequestedBackup == 0)
                {
                    return false;
                }
                else if (Game.GameTime - GameTimeLastRequestedBackup <= 5000)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public bool RecentlyLostWanted
        {
            get
            {
                if (GameTimeLastWantedEnded == 0)
                {
                    return false;
                }
                else if (Game.GameTime - GameTimeLastWantedEnded <= 5000)
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public bool ShouldSirenBeOn
        {
            get
            {
                if (CurrentResponse == ResponsePriority.Low || CurrentResponse == ResponsePriority.None)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public float ResponseDrivingSpeed
        {
            get
            {
                if (CurrentResponse == ResponsePriority.High)
                {
                    return 25f; //55 mph
                }
                else if (CurrentResponse == ResponsePriority.Medium)
                {
                    return 25f; //55 mph
                }
                else
                {
                    return 20f; //40 mph
                }
            }
        }
        public bool PoliceChasingRecklessly
        {
            get
            {
                if (CurrentPoliceState == PoliceState.DeadlyChase && (CurrentCrimes.InstancesOfCrime("KillingPolice") >= 1 || CurrentCrimes.InstancesOfCrime("KillingCivilians") >= 2 || Mod.Player.Instance.WantedLevel >= 4))
                {
                    return true;
                }
                else
                    return false;
            }
        }
        public ResponsePriority CurrentResponse
        {
            get
            {
                if (Mod.Player.Instance.IsNotWanted)
                {
                    if (Mod.Player.Instance.Investigations.IsActive)
                    {
                        if (CurrentCrimes.CrimesReported.Any(x => x.AssociatedCrime.Priority <= 8))
                        {
                            return ResponsePriority.Medium;
                        }
                        else
                        {
                            return ResponsePriority.Low;
                        }
                    }
                    else
                    {
                        return ResponsePriority.None;
                    }
                }
                else
                {
                    if (Mod.Player.Instance.WantedLevel > 4)
                    {
                        return ResponsePriority.Full;
                    }
                    else if (Mod.Player.Instance.WantedLevel >= 2)
                    {
                        return ResponsePriority.High;
                    }
                    else
                    {
                        return ResponsePriority.Medium;
                    }
                }
            }
        }
        public void Update()
        {
            GetPoliceState();
            WantedLevelTick();
        }
        public void Reset()
        {
            SetWantedLevel(0, "Police Response Reset", true);
            CurrentCrimes = new CriminalHistory();
            IsWeaponsFree = false;
            CurrentPoliceState = PoliceState.Normal;
            GameTimeWantedLevelStarted = 0;
            Mod.World.Instance.ResetPolice();
            Mod.World.Instance.ResetScanner();
        }
        public void SetWantedLevel(int WantedLevel, string Reason, bool UpdateRecent)
        {
            if (UpdateRecent)
            {
                GameTimeLastSetWanted = Game.GameTime;
            }

            if (Game.LocalPlayer.WantedLevel < WantedLevel || WantedLevel == 0)
            {
                NativeFunction.CallByName<bool>("SET_MAX_WANTED_LEVEL", WantedLevel);
                Debug.Instance.WriteToLog("SetWantedLevel", string.Format("Current Wanted: {0}, Desired Wanted: {1}, {2}", Game.LocalPlayer.WantedLevel, WantedLevel, Reason));
                Game.LocalPlayer.WantedLevel = WantedLevel;
                WantedLevelLastset = WantedLevel;
            }
        }
        public void ApplyReportedCrimes()
        {
            if (CurrentCrimes.CrimesReported.Any())
            {
                foreach (CrimeEvent MyCrimes in CurrentCrimes.CrimesReported)
                {
                    CrimeEvent PreviousViolation = CurrentCrimes.CrimesObserved.FirstOrDefault(x => x.AssociatedCrime == MyCrimes.AssociatedCrime);
                    if (PreviousViolation == null)
                    {
                        CurrentCrimes.CrimesObserved.Add(new CrimeEvent(MyCrimes.AssociatedCrime));
                    }
                    else if (PreviousViolation.CanAddInstance)
                    {
                        PreviousViolation.AddInstance();
                    }

                }
                CrimeEvent WorstObserved = CurrentCrimes.CrimesObserved.OrderBy(x => x.AssociatedCrime.Priority).FirstOrDefault();
                if (WorstObserved != null)
                {
                    SetWantedLevel(WorstObserved.AssociatedCrime.ResultingWantedLevel, "you are a suspect!", true);
                    Mod.World.Instance.AnnounceCrime(WorstObserved.AssociatedCrime, new PoliceScannerCallIn(!Mod.Player.Instance.IsInVehicle, true, Game.LocalPlayer.Character.Position, true));
                }
            }
        }
        public void RefreshPoliceState()
        {
            CurrentPoliceState = PoliceState.Normal;
            GetPoliceState();
        }
        public bool NearLastWanted(float DistanceTo)
        {
            return LastWantedCenterPosition != Vector3.Zero && Game.LocalPlayer.Character.DistanceTo2D(LastWantedCenterPosition) <= DistanceTo;
        }
        private void GetPoliceState()
        {
            if (Mod.Player.Instance.WantedLevel == 0)
            {
                CurrentPoliceState = PoliceState.Normal;
            }//Default state

            if (Mod.Player.Instance.IsBusted)
            {
                CurrentPoliceState = PoliceState.ArrestedWait;
            }

            if (CurrentPoliceState == PoliceState.ArrestedWait || CurrentPoliceState == PoliceState.DeadlyChase)
            {
                return;
            }

            if (Mod.Player.Instance.WantedLevel >= 1 && Mod.Player.Instance.WantedLevel <= 3 && Mod.World.Instance.AnyPoliceCanSeePlayer)
            {
                if (Mod.World.Instance.AnyPoliceCanSeePlayer)
                {
                    if (CurrentCrimes.LethalForceAuthorized)
                    {
                        CurrentPoliceState = PoliceState.DeadlyChase;
                    }
                    else if (Mod.Player.Instance.IsConsideredArmed)
                    {
                        CurrentPoliceState = PoliceState.CautiousChase;
                    }
                    else
                    {
                        CurrentPoliceState = PoliceState.UnarmedChase;
                    }
                }
                else
                {
                    CurrentPoliceState = PoliceState.UnarmedChase;
                }
            }
            else if (Mod.Player.Instance.WantedLevel >= 4)
            {
                CurrentPoliceState = PoliceState.DeadlyChase;
            }

        }
        private void PoliceStateChanged()
        {
            Debug.Instance.WriteToLog("ValueChecker", string.Format("PoliceState Changed to: {0} Was {1}", CurrentPoliceState, PrevPoliceState));
            GameTimePoliceStateStart = Game.GameTime;
            PrevPoliceState = CurrentPoliceState;
        }
        private void WantedLevelTick()
        {
            if (PreviousWantedLevel != Game.LocalPlayer.WantedLevel)
            {
                WantedLevelChanged();
            }
            if (PrevPoliceState != CurrentPoliceState)
            {
                PoliceStateChanged();
            }
            if (!Mod.Player.Instance.HasActiveArrestWarrant)
            {
                RemoveLastBlip();
            }
            if (Mod.Player.Instance.IsWanted)
            {
                if (!Mod.Player.Instance.IsDead && !Mod.Player.Instance.IsBusted)
                {
                    Vector3 CurrentWantedCenter = Mod.World.Instance.PlacePoliceLastSeenPlayer; //NativeFunction.CallByName<Vector3>("GET_PLAYER_WANTED_CENTRE_POSITION", Game.LocalPlayer);
                    if (CurrentWantedCenter != Vector3.Zero)
                    {
                        LastWantedCenterPosition = CurrentWantedCenter;
                        UpdateBlip(CurrentWantedCenter, Mod.Player.Instance.BlipSize);
                    }

                    if (Mod.World.Instance.AnyPoliceCanSeePlayer)
                    {
                        PlayerSeenDuringCurrentWanted = true;
                        CurrentCrimes.PlayerSeenDuringWanted = true;
                    }

                    if (DataMart.Instance.Settings.SettingsManager.Police.WantedLevelIncreasesOverTime && HasBeenAtCurrentWantedLevelFor > DataMart.Instance.Settings.SettingsManager.Police.WantedLevelIncreaseTime && Mod.World.Instance.AnyPoliceCanSeePlayer && Mod.Player.Instance.WantedLevel <= DataMart.Instance.Settings.SettingsManager.Police.WantedLevelInceaseOverTimeLimit)
                    {
                        GameTimeLastRequestedBackup = Game.GameTime;
                        SetWantedLevel(Mod.Player.Instance.WantedLevel + 1, "WantedLevelIncreasesOverTime", true);
                    }
                    if (CurrentPoliceState == PoliceState.DeadlyChase && Mod.Player.Instance.WantedLevel < 3)
                    {
                        SetWantedLevel(3, "Deadly chase requires 3+ wanted level", true);
                    }
                    int PoliceKilled = CurrentCrimes.InstancesOfCrime("KillingPolice");
                    if (PoliceKilled > 0)
                    {
                        if (PoliceKilled >= 2 * DataMart.Instance.Settings.SettingsManager.Police.PoliceKilledSurrenderLimit && Mod.Player.Instance.WantedLevel < 5)
                        {
                            SetWantedLevel(5, "You killed too many cops 5 Stars", true);
                            IsWeaponsFree = true;
                        }
                        else if (PoliceKilled >= DataMart.Instance.Settings.SettingsManager.Police.PoliceKilledSurrenderLimit && Mod.Player.Instance.WantedLevel < 4)
                        {
                            SetWantedLevel(4, "You killed too many cops 4 Stars", true);
                            IsWeaponsFree = true;
                        }
                    }
                }
            }
            else
            {
                RemoveBlip();
            }
        }
        private void WantedLevelChanged()
        {
            if (Game.LocalPlayer.WantedLevel == 0)
            {
                WantedLevelRemoved();
            }
            else if (PreviousWantedLevel == 0 && Game.LocalPlayer.WantedLevel > 0)
            {
                WantedLevelAdded();
            }

            //CurrentCrimes.MaxWantedLevel = Mod.Player.Instance.WantedLevel;
            GameTimeWantedLevelStarted = Game.GameTime;
            Debug.Instance.WriteToLog("WantedLevel", string.Format("Changed to: {0}, Recently Set: {1}", Game.LocalPlayer.WantedLevel, RecentlySetWanted));
            PreviousWantedLevel = Game.LocalPlayer.WantedLevel;
        }
        private void WantedLevelAdded()
        {
            if (!RecentlySetWanted)//randomly set by the game
            {
                if (Mod.Player.Instance.WantedLevel <= 2)//let some level 3 and 4 wanted override and be set
                {
                    SetWantedLevel(0, "Resetting Unknown Wanted", false);
                    return;
                }
            }
            Mod.Player.Instance.Investigations.Reset();
            CurrentCrimes.GameTimeWantedStarted = Game.GameTime;
            //CurrentCrimes.MaxWantedLevel = Mod.Player.Instance.WantedLevel;
            PlaceWantedStarted = Game.LocalPlayer.Character.Position;
            GameTimeWantedStarted = Game.GameTime;
            RemoveLastBlip();
        }
        private void WantedLevelRemoved()
        {
            if (!Mod.Player.Instance.IsDead && !Mod.Player.Instance.RecentlyRespawned)//they might choose the respawn as the same character, so do not replace it yet?
            {
                CurrentCrimes.GameTimeWantedEnded = Game.GameTime;
                //CurrentCrimes.MaxWantedLevel = Mod.Player.Instance.MaxWantedLastLife;
                if (CurrentCrimes.PlayerSeenDuringWanted && PreviousWantedLevel != 0)// && !RecentlySetWanted)//i didnt make it go to zero, the chase was lost organically
                {
                    Mod.Player.Instance.StoreCriminalHistory(CurrentCrimes);
                }
                Reset();
            }
            GameTimeLastWantedEnded = Game.GameTime;
            PlayerSeenDuringCurrentWanted = false;
            RemoveBlip();


            if (Mod.Player.Instance.HasActiveArrestWarrant)
            {
                UpdateLastBlip(LastWantedCenterPosition);
            }
            else
            {
                RemoveLastBlip();
            }
        }
        private void RemoveBlip()
        {
            if (CurrentWantedCenterBlip.Exists())
            {
                CurrentWantedCenterBlip.Delete();
            }
        }
        private void UpdateBlip(Vector3 Position, float Size)
        {
            if (Position == Vector3.Zero)
            {
                if (CurrentWantedCenterBlip.Exists())
                {
                    CurrentWantedCenterBlip.Delete();
                }
                return;
            }
            if (!CurrentWantedCenterBlip.Exists())
            {
                CurrentWantedCenterBlip = new Blip(Position, Size)
                {
                    Name = "Current Wanted Center Position",
                    Color = Color.Red,
                    Alpha = 0.5f
                };

                NativeFunction.CallByName<bool>("SET_BLIP_AS_SHORT_RANGE", (uint)CurrentWantedCenterBlip.Handle, true);
                Mod.World.Instance.AddBlip(CurrentWantedCenterBlip);
            }
            if (CurrentWantedCenterBlip.Exists())
            {
                CurrentWantedCenterBlip.Position = Position;
            }
            CurrentWantedCenterBlip.Color = Mod.Player.Instance.BlipColor;
            CurrentWantedCenterBlip.Scale = Mod.Player.Instance.BlipSize;
        }
        private void UpdateLastBlip(Vector3 Position)
        {
            if (Position == Vector3.Zero)
            {
                if (LastWantedCenterBlip.Exists())
                {
                    LastWantedCenterBlip.Delete();
                }
                return;
            }
            if (!LastWantedCenterBlip.Exists())
            {
                int MaxWanted = Mod.Player.Instance.MaxWantedLevel;
                if (MaxWanted != 0)
                {
                    LastWantedSearchRadius = MaxWanted * DataMart.Instance.Settings.SettingsManager.Police.LastWantedCenterSize;
                }
                else
                    LastWantedSearchRadius = DataMart.Instance.Settings.SettingsManager.Police.LastWantedCenterSize;

                LastWantedCenterBlip = new Blip(LastWantedCenterPosition, LastWantedSearchRadius)
                {
                    Name = "Last Wanted Center Position",
                    Color = Color.Yellow,
                    Alpha = 0.25f
                };

                NativeFunction.CallByName<bool>("SET_BLIP_AS_SHORT_RANGE", (uint)LastWantedCenterBlip.Handle, true);
                Mod.World.Instance.AddBlip(LastWantedCenterBlip);
            }
            if (LastWantedCenterBlip.Exists())
            {
                LastWantedCenterBlip.Position = Position;
            }
        }
        private void RemoveLastBlip()
        {
            if (LastWantedCenterBlip.Exists())
            {
                LastWantedCenterBlip.Delete();
            }
        }
    }
}