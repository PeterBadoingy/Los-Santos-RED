using NAudio.CoreAudioApi.Interfaces;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;


public class DispatchableVehicles_Gangs
{
    public List<DispatchableVehicleGroup> GangVehicles { get; private set; }
    public List<DispatchableVehicle> BallasVehicles { get; private set; }
    public List<DispatchableVehicle> VagosVehicles { get; private set; }
    public List<DispatchableVehicle> FamiliesVehicles { get; private set; }
    public List<DispatchableVehicle> AncelottiVehicles { get; private set; }
    public List<DispatchableVehicle> MessinaVehicles { get; private set; }
    public List<DispatchableVehicle> LupisellaVehicles { get; private set; }
    public List<DispatchableVehicle> PavanoVehicles { get; private set; }
    public List<DispatchableVehicle> GambettiVehicles { get; private set; }
    public List<DispatchableVehicle> ArmenianVehicles { get; private set; }
    public List<DispatchableVehicle> CartelVehicles { get; private set; }
    public List<DispatchableVehicle> RedneckVehicles { get; private set; }
    public List<DispatchableVehicle> TriadVehicles { get; private set; }
    public List<DispatchableVehicle> KoreanVehicles { get; private set; }
    public List<DispatchableVehicle> MarabuntaVehicles { get; private set; }
    public List<DispatchableVehicle> DiablosVehicles { get; private set; }
    public List<DispatchableVehicle> VarriosVehicles { get; private set; }
    public List<DispatchableVehicle> LostVehicles { get; private set; }
    public List<DispatchableVehicle> YardiesVehicles { get; private set; }


    public List<DispatchableVehicle> NorthHollandVehicles { get; private set; }
    public List<DispatchableVehicle> PetrovicVehicles { get; private set; }
    public List<DispatchableVehicle> SpanishLordsVehicles { get; private set; }
    public List<DispatchableVehicle> AngelsOfDeathVehicles { get; private set; }
    public List<DispatchableVehicle> UptownRidersVehicles { get; private set; }

    //Metallic paints only
    public List<int> DefaultOptionalColors { get; private set; } = new List<int>() { 0, 3, 4, 5, 11, 27, 28, 37, 38, 49, 52, 54, 61, 64, 73, 88, 91, 93, 97, 112, 145 };

    //Create a Vehicle
    public string GangSentinel5 = "Sentinel5";


    public void DefaultConfig()
    {
        SetBallasVehicles();
        SetVagosVehicles();
        SetFamiliesVehicles();
        SetAncelottiVehicles();
        SetMessinaVehicles();
        SetLupisellaVehicles();
        SetPavanoVehicles();
        SetGambettiVehicles();
        SetArmenianVehicles();
        SetCartelVehicles();
        SetRedneckVehicles();
        SetTriadVehicles();
        SetKoreanVehicles();
        SetMarabuntaVehicles();
        SetDiablosVehicles();
        SetVarriosVehicles();
        SetLostVehicles();
        SetYardiesVehicles();


        SetNorthHollandVehicles();
        SetPetrovicVehicles();
        SetSpanishLordsVehicles();
        SetAngelsOfDeathVehicles();
        SetUptownRidersVehicles();

    }

    private void SetUptownRidersVehicles()
    {
        UptownRidersVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("burrito3",2,2) { },
            new DispatchableVehicle("double", 25, 25) { MaxOccupants = 1 },
            new DispatchableVehicle("bati", 25, 25) { MaxOccupants = 1 },
            new DispatchableVehicle("bati2", 25, 25) { MaxOccupants = 1,RequiresDLC = true },
            new DispatchableVehicle("hakuchou", 25, 25) { MaxOccupants = 1, },
            new DispatchableVehicle("hakuchou2", 25, 25) { MaxOccupants = 1,RequiresDLC = true },           
            // Custom Motorcycles
            new DispatchableVehicle() {
                DebugName = "BATI_UptownRiders_PB",
                ModelName = "BATI",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 1,
                RequiredSecondaryColorID = 29,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 1,
                    SecondaryColor = 29,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 27,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 3 },
                        new VehicleMod() { ID = 24, Output = 3 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "DEFILER_UptownRiders_PB",
                ModelName = "DEFILER",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 11,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 11,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 28,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 2 },
                        new VehicleMod() { ID = 24, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 6 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "diablous2_UptownRiders_PB",
                ModelName = "diablous2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 27,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 27,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 156,
                    DashboardColor = 92,
                    WheelColor = 27,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 8 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 10 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 9, Output = 2 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 3 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 48, Output = 14 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "diablous2_UptownRiders2_PB",
                ModelName = "diablous2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 156,
                    DashboardColor = 94,
                    WheelColor = 89,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 8 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 10 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 9, Output = 4 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 39 },
                        new VehicleMod() { ID = 24, Output = 39 },
                        new VehicleMod() { ID = 48, Output = 16 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "diablous2_UptownRiders3_PB",
                ModelName = "diablous2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 156,
                    DashboardColor = 111,
                    WheelColor = 121,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 4 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 32, Output = 8 },
                        new VehicleMod() { ID = 45, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 16 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "diablous2_UptownRiders4_PB",
                ModelName = "diablous2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 118,
                    PearlescentColor = 3,
                    InteriorColor = 156,
                    DashboardColor = 111,
                    WheelColor = 28,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 9 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 9, Output = 6 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 41 },
                        new VehicleMod() { ID = 24, Output = 41 },
                        new VehicleMod() { ID = 32, Output = 13 },
                        new VehicleMod() { ID = 40, Output = 5 },
                        new VehicleMod() { ID = 45, Output = 6 },
                        new VehicleMod() { ID = 48, Output = 12 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "HAKUCHOU2_UptownRiders_PB",
                ModelName = "HAKUCHOU2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 27,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 27,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 27,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 2 },
                        new VehicleMod() { ID = 24, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "HAKUCHOU2_UptownRiders2_PB",
                ModelName = "HAKUCHOU2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 27,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 27,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SHINOBI_UptownRiders_PB",
                ModelName = "SHINOBI",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 112,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 112,
                    SecondaryColor = 0,
                    PearlescentColor = 12,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 1,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 3 },
                        new VehicleMod() { ID = 13, Output = 3 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 48, Output = 11 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SHINOBI_UptownRiders2_PB",
                ModelName = "SHINOBI",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 27,
                RequiredSecondaryColorID = 13,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 27,
                    SecondaryColor = 13,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 135,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 3 },
                        new VehicleMod() { ID = 13, Output = 3 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 4 },
                        new VehicleMod() { ID = 24, Output = 4 },
                        new VehicleMod() { ID = 48, Output = 13 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SHINOBI_UptownRiders3_PB",
                ModelName = "SHINOBI",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 112,
                RequiredSecondaryColorID = 21,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 112,
                    SecondaryColor = 21,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 95,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 3 },
                        new VehicleMod() { ID = 13, Output = 3 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 1 },
                        new VehicleMod() { ID = 24, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 8 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SHINOBI_UptownRiders4_PB",
                ModelName = "SHINOBI",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 112,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 112,
                    SecondaryColor = 0,
                    PearlescentColor = 12,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 139,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 11, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 3 },
                        new VehicleMod() { ID = 13, Output = 3 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 4 },
                        new VehicleMod() { ID = 24, Output = 4 },
                        new VehicleMod() { ID = 48, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "VORTEX_UptownRiders_PB",
                ModelName = "VORTEX",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 120,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 3 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "VORTEX_UptownRiders2_PB",
                ModelName = "VORTEX",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 39,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 39,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 132,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 4 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 1 },
                        new VehicleMod() { ID = 24, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 9 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetAngelsOfDeathVehicles()
    {
        AngelsOfDeathVehicles = new List<DispatchableVehicle>()
        {
            new DispatchableVehicle("burrito3",2,2) { },
            new DispatchableVehicle("daemon", 25, 25) { MaxOccupants = 1,RequiredPrimaryColorID = 134,RequiredSecondaryColorID = 112 },
            new DispatchableVehicle("daemon2", 25, 25) { MaxOccupants = 1,RequiresDLC = true ,RequiredPrimaryColorID = 134,RequiredSecondaryColorID = 112},
            new DispatchableVehicle("nightblade", 25, 25) { MaxOccupants = 1,RequiresDLC = true ,RequiredPrimaryColorID = 134,RequiredSecondaryColorID = 112},
            new DispatchableVehicle("wolfsbane", 25, 25) { MaxOccupants = 1,RequiresDLC = true ,RequiredPrimaryColorID = 134,RequiredSecondaryColorID = 112},            
            //Custom
            //Van
            new DispatchableVehicle() {
                DebugName = "GBURRITO2_AOD_PB",
                ModelName = "GBURRITO2",
                AmbientSpawnChance = 15,
                WantedSpawnChance = 15,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 15,
                RequiredSecondaryColorID = 122,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 15,
                    SecondaryColor = 122,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 132,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 17 },
                    },
                },
                RequiresDLC = true,
            },
            // Motorcycles
            new DispatchableVehicle() {
                DebugName = "AVARUS_AOD_PB",
                ModelName = "AVARUS",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 134,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 134,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 111,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 5 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 8 },
                        new VehicleMod() { ID = 24, Output = 8 },
                        new VehicleMod() { ID = 48, Output = 11 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "AVARUS_AOD2_PB",
                ModelName = "AVARUS",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 11,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 11,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 10 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 44 },
                        new VehicleMod() { ID = 24, Output = 44 },
                        new VehicleMod() { ID = 48, Output = 10 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "AVARUS_AOD3_PB",
                ModelName = "AVARUS",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 11,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 11,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 5 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 45 },
                        new VehicleMod() { ID = 24, Output = 45 },
                        new VehicleMod() { ID = 48, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DAEMON2_AOD_PB",
                ModelName = "DAEMON2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 134,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 134,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 7 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 6 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 47 },
                        new VehicleMod() { ID = 24, Output = 47 },
                        new VehicleMod() { ID = 48, Output = 10 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "HEXER_AOD_PB",
                ModelName = "HEXER",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 134,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 134,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 44 },
                        new VehicleMod() { ID = 24, Output = 44 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "SANCTUS_AOD_PB",
                ModelName = "SANCTUS",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 134,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 134,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 7 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 10 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "ZOMBIEA_AOD_PB",
                ModelName = "ZOMBIEA",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 6 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 7 },
                        new VehicleMod() { ID = 10, Output = 6 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 9 },
                        new VehicleMod() { ID = 24, Output = 9 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "ZOMBIEA_AOD2_PB",
                ModelName = "ZOMBIEA",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 134,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 134,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 10 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 48, Output = 10 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "ZOMBIEB_AOD_PB",
                ModelName = "ZOMBIEB",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 134,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 134,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 6 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 6 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 9 },
                        new VehicleMod() { ID = 24, Output = 9 },
                        new VehicleMod() { ID = 48, Output = 9 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetSpanishLordsVehicles()
    {
        SpanishLordsVehicles = new List<DispatchableVehicle>()
        {
            new DispatchableVehicle("primo2", 20, 20) { RequiresDLC = true,RequiredPrimaryColorID = 68,RequiredSecondaryColorID = 68 },
            new DispatchableVehicle("primo", 20, 20) {RequiredPrimaryColorID = 68,RequiredSecondaryColorID = 68 },
            new DispatchableVehicle("cavalcade", 25, 20) { RequiredPrimaryColorID = 68,RequiredSecondaryColorID = 68 },
            new DispatchableVehicle("cavalcade2", 25, 20) { RequiredPrimaryColorID = 68,RequiredSecondaryColorID = 68 },
            new DispatchableVehicle("cavalcade3", 2, 2) { RequiresDLC = true,RequiredPrimaryColorID = 68,RequiredSecondaryColorID = 68 },              
            // Custom
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "SULTAN_SLords_PB",
                ModelName = "SULTAN",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 15 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "SULTAN2_SLords_PB",
                ModelName = "SULTAN2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 8 },
                        new VehicleMod() { ID = 5, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 10 },
                        new VehicleMod() { ID = 9, Output = 2 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 28 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "tulip_SLords_PB",
                ModelName = "tulip",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 3 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "BANSHEE2_SLords_PB",
                ModelName = "BANSHEE2",
                AmbientSpawnChance = 45,
                WantedSpawnChance = 45,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 1, IsTurnedOn = false },
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 14 },
                        new VehicleMod() { ID = 29, Output = 0 },
                        new VehicleMod() { ID = 32, Output = 0 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 41, Output = 10 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SULTANRS_SLords_PB",
                ModelName = "SULTANRS",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 8 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 14 },
                        new VehicleMod() { ID = 27, Output = 0 },
                        new VehicleMod() { ID = 29, Output = 0 },
                        new VehicleMod() { ID = 30, Output = 0 },
                        new VehicleMod() { ID = 32, Output = 1 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 41, Output = 11 },
                        new VehicleMod() { ID = 42, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "TAMPA_SLords_PB",
                ModelName = "TAMPA",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 8 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SABREGT_SLords_PB",
                ModelName = "SABREGT",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 12 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "PHOENIX_SLords_PB",
                ModelName = "PHOENIX",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 7 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "HERMES_SLords_PB",
                ModelName = "HERMES",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 68,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 68,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 15,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 28 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetPetrovicVehicles()
    {
        PetrovicVehicles = new List<DispatchableVehicle>()
        {
            new DispatchableVehicle("cognoscenti", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cogcabrio", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("ingot", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cavalcade", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cavalcade2", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cavalcade3", 20, 20) { RequiresDLC = true, RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black           
            // Custom
            //SUV
            new DispatchableVehicle() {
                DebugName = "DUBSTA2_Petrovic_PB",
                ModelName = "DUBSTA2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 3,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 15 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "Novak_Petrovic_PB",
                ModelName = "Novak",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 3 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "CAVALCADE2_Petrovic_PB",
                ModelName = "CAVALCADE2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 70,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 0,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 43 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "CAVALCADE3_Petrovic_PB",
                ModelName = "CAVALCADE3",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 70,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 3,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 7 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 13 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 35 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "SCHAFTER3_Petrovic_PB",
                ModelName = "SCHAFTER3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 0,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 39 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "sentinel5_Petrovic_PB",
                ModelName = "sentinel5",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 7,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 26 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "CHEBUREK_Petrovic_PB",
                ModelName = "CHEBUREK",
                AmbientSpawnChance = 25,
                WantedSpawnChance = 25,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 1,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "vorschlaghammer_Petrovic_PB",
                ModelName = "vorschlaghammer",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 70,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 7,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 32 },
                        new VehicleMod() { ID = 27, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "SCHWARZER_Petrovic_PB",
                ModelName = "SCHWARZER",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 0,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 43 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "cypher_Petrovic_PB",
                ModelName = "cypher",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 156,
                    WheelColor = 120,
                    WheelType = 7,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 25 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetNorthHollandVehicles()
    {
        NorthHollandVehicles = new List<DispatchableVehicle>()
        {
            new DispatchableVehicle("patriot3",2,2) { RequiresDLC = true, RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },
            new DispatchableVehicle("landstalker",20,20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },
            new DispatchableVehicle("landstalker2",20,20) { RequiresDLC = true, RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },           
            // Custom
            // SUV
            new DispatchableVehicle() {
                DebugName = "PATRIOT3_Hustlers_PB",
                ModelName = "PATRIOT3",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 28,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 28,
                    PearlescentColor = 35,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 4 },
                        new VehicleMod() { ID = 2, Output = 3 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 6 },
                        new VehicleMod() { ID = 28, Output = 6 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "landstalker2_Hustlers_PB",
                ModelName = "landstalker2",
                AmbientSpawnChance = 45,
                WantedSpawnChance = 45,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 28,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 28,
                    PearlescentColor = 35,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 1,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 6 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 4 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 11 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "REVOLTER_Hustlers_PB",
                ModelName = "REVOLTER",
                AmbientSpawnChance = 45,
                WantedSpawnChance = 45,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 28,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 28,
                    PearlescentColor = 35,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 28 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BUFFALO4_Hustlers_PB",
                ModelName = "BUFFALO4",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 28,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 28,
                    PearlescentColor = 35,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 12,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 6 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 17 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "vstr_Hustlers_PB",
                ModelName = "vstr",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 28,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 28,
                    PearlescentColor = 35,
                    InteriorColor = 4,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 10 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 5 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 10 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "DOMINATOR9_Hustlers_PB",
                ModelName = "DOMINATOR9",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 35,
                    InteriorColor = 2,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 9 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 8 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 22 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DOMINATOR3_Hustlers_PB",
                ModelName = "DOMINATOR3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 35,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 6 },
                        new VehicleMod() { ID = 5, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 7 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 15 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 15 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "gauntlet4_Hustlers_PB",
                ModelName = "gauntlet4",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 28,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 28,
                    PearlescentColor = 35,
                    InteriorColor = 2,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 5 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 21 },
                        new VehicleMod() { ID = 48, Output = 4 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }

    private void SetBallasVehicles()
    {
        BallasVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("baller", 20, 20){ RequiredPrimaryColorID = 145,RequiredSecondaryColorID = 145 },
            new DispatchableVehicle("baller2", 20, 20){ RequiredPrimaryColorID = 145,RequiredSecondaryColorID = 145 },//purple

            //Custom
            // SUV
            new DispatchableVehicle() {
                DebugName = "BALLER_Ballas_PB",
                ModelName = "BALLER",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 0,
                    DashboardColor = 24,
                    WheelColor = 156,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 29 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "baller7_Ballas_PB",
                ModelName = "baller7",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 93,
                    DashboardColor = 24,
                    WheelColor = 156,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 30 },
                    },
                },
                RequiresDLC = false,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "IMPALER5_Ballas_PB",
                ModelName = "IMPALER5",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 159,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 159,
                    PearlescentColor = 74,
                    InteriorColor = 23,
                    DashboardColor = 23,
                    WheelColor = 156,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 40 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "PRIMO2_Ballas_PB",
                ModelName = "PRIMO2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 0,
                    DashboardColor = 160,
                    WheelColor = 156,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 36 },
                        new VehicleMod() { ID = 25, Output = 1 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 28, Output = 6 },
                        new VehicleMod() { ID = 30, Output = 4 },
                        new VehicleMod() { ID = 33, Output = 1 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 35, Output = 20 },
                        new VehicleMod() { ID = 36, Output = 3 },
                        new VehicleMod() { ID = 37, Output = 6 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 5 },
                        new VehicleMod() { ID = 40, Output = 3 },
                        new VehicleMod() { ID = 43, Output = 2 },
                        new VehicleMod() { ID = 44, Output = 1 },
                        new VehicleMod() { ID = 45, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "impaler6_Ballas_PB",
                ModelName = "impaler6",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 145,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 5 },
                        new VehicleMod() { ID = 2, Output = 5 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 8 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 9, Output = 10 },
                        new VehicleMod() { ID = 10, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 26 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door - Lowrider
            new DispatchableVehicle() {
                DebugName = "VIRGO2_Ballas_PB",
                ModelName = "VIRGO2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 1,
                    InteriorColor = 0,
                    DashboardColor = 160,
                    WheelColor = 156,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 23 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 7 },
                        new VehicleMod() { ID = 28, Output = 6 },
                        new VehicleMod() { ID = 30, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 15 },
                        new VehicleMod() { ID = 34, Output = 0 },
                        new VehicleMod() { ID = 35, Output = 20 },
                        new VehicleMod() { ID = 36, Output = 4 },
                        new VehicleMod() { ID = 37, Output = 4 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 4 },
                        new VehicleMod() { ID = 40, Output = 1 },
                        new VehicleMod() { ID = 43, Output = 1 },
                        new VehicleMod() { ID = 44, Output = 0 },
                        new VehicleMod() { ID = 45, Output = 3 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "tahoma_Ballas_PB",
                ModelName = "tahoma",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 21,
                    DashboardColor = 23,
                    WheelColor = 156,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 9 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 61 },
                        new VehicleMod() { ID = 48, Output = 6 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "manana2_Ballas_PB",
                ModelName = "manana2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 21,
                    DashboardColor = 160,
                    WheelColor = 156,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 4, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 30 },
                        new VehicleMod() { ID = 25, Output = 6 },
                        new VehicleMod() { ID = 30, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 0 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 35, Output = 20 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "vigero2_Ballas_PB",
                ModelName = "vigero2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 156,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 14 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 21 },
                    },
                },
                RequiresDLC = true,
            },
            // Special
            new DispatchableVehicle() {
                DebugName = "FACTION3_Ballas_PB",
                ModelName = "FACTION3",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 145,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false },
                        new VehicleExtra() { ID = 3, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 25 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 7 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 28, Output = 3 },
                        new VehicleMod() { ID = 33, Output = 12 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 35, Output = 20 },
                        new VehicleMod() { ID = 36, Output = 1 },
                        new VehicleMod() { ID = 37, Output = 6 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 4 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BLAZER4_Ballas_PB",
                ModelName = "BLAZER4",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 0,
                    DashboardColor = 24,
                    WheelColor = 156,
                    WheelType = 9,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 5 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 5 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 21 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "MANCHEZ_Ballas_PB",
                ModelName = "MANCHEZ",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 145,
                RequiredSecondaryColorID = 105,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 145,
                    SecondaryColor = 105,
                    PearlescentColor = 105,
                    InteriorColor = 27,
                    DashboardColor = 27,
                    WheelColor = 156,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetVagosVehicles()
    {
        VagosVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("chino", 20, 20){ RequiredPrimaryColorID = 42,RequiredSecondaryColorID = 42 },
            new DispatchableVehicle("chino2", 20, 20){ RequiredPrimaryColorID = 42,RequiredSecondaryColorID = 42 },//yellow

            //Custom
            //SUV - Pickup Trucks
            new DispatchableVehicle() {
                DebugName = "SLAMVAN3_VAGOS_PB",
                ModelName = "SLAMVAN3",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                MaxOccupants = 2,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 26,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 4 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 43 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 28, Output = 0 },
                        new VehicleMod() { ID = 29, Output = 0 },
                        new VehicleMod() { ID = 32, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 9 },
                        new VehicleMod() { ID = 34, Output = 13 },
                        new VehicleMod() { ID = 35, Output = 17 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 2 },
                        new VehicleMod() { ID = 40, Output = 1 },
                        new VehicleMod() { ID = 45, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "FIREBOLT_VAGOS_PB",
                ModelName = "FIREBOLT",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 26,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 31 },
                        new VehicleMod() { ID = 48, Output = 6 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DORADO_VAGOS_PB",
                ModelName = "DORADO",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants= 4,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 2,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 9 },
                        new VehicleMod() { ID = 1, Output = 8 },
                        new VehicleMod() { ID = 2, Output = 8 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 8 },
                        new VehicleMod() { ID = 9, Output = 5 },
                        new VehicleMod() { ID = 15, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 7 },
                        new VehicleMod() { ID = 48, Output = 8 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 doors
            new DispatchableVehicle() {
                DebugName = "IMPALER5_VAGOS_PB",
                ModelName = "IMPALER5",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 11,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 11,
                    PearlescentColor = 11,
                    InteriorColor = 2,
                    DashboardColor = 157,
                    WheelColor = 120,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 14 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BUFFALO4_VAGOS_PB",
                ModelName = "BUFFALO4",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 12,
                    PearlescentColor = 11,
                    InteriorColor = 26,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 6 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 16 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door Muslce Cars
            new DispatchableVehicle() {
                DebugName = "IMPALER_VAGOS_PB",
                ModelName = "IMPALER",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 2,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 23 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "tulip2_VAGOS_PB",
                ModelName = "tulip2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 2,
                    InteriorColor = 2,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 5 },
                        new VehicleMod() { ID = 23, Output = 29 },
                        new VehicleMod() { ID = 48, Output = 8 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DEVIANT_VAGOS_PB",
                ModelName = "DEVIANT",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 2,
                    DashboardColor = 157,
                    WheelColor = 120,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 1, IsTurnedOn = true },
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 6 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 9 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 3 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 8 },
                        new VehicleMod() { ID = 48, Output = 4 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "gauntlet4_VAGOS_PB",
                ModelName = "gauntlet4",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 0,
                    PearlescentColor = 11,
                    InteriorColor = 26,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 5 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 23 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DOMINATOR7_VAGOS_PB",
                ModelName = "DOMINATOR7",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 0,
                    PearlescentColor = 11,
                    InteriorColor = 26,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 11 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 13 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 0 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 30, Output = 4 },
                        new VehicleMod() { ID = 32, Output = 1 },
                        new VehicleMod() { ID = 33, Output = 11 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 6 },
                        new VehicleMod() { ID = 41, Output = 15 },
                        new VehicleMod() { ID = 42, Output = 3 },
                        new VehicleMod() { ID = 44, Output = 0 },
                        new VehicleMod() { ID = 46, Output = 1 },
                        new VehicleMod() { ID = 47, Output = 6 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            // Lowriders
            new DispatchableVehicle() {
                DebugName = "CHINO2_VAGOS_PB",
                ModelName = "CHINO2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 89,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },

                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 5 },
                        new VehicleMod() { ID = 25, Output = 9 },
                        new VehicleMod() { ID = 27, Output = 4 },
                        new VehicleMod() { ID = 28, Output = 0 },
                        new VehicleMod() { ID = 30, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 5 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 35, Output = 17 },
                        new VehicleMod() { ID = 37, Output = 7 },
                        new VehicleMod() { ID = 38, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 2 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BUCCANEER2_VAGOS_PB",
                ModelName = "BUCCANEER2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 16,
                    DashboardColor = 160,
                    WheelColor = 120,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false },
                        new VehicleExtra() { ID = 4, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 17 },
                        new VehicleMod() { ID = 25, Output = 9 },
                        new VehicleMod() { ID = 27, Output = 10 },
                        new VehicleMod() { ID = 28, Output = 0 },
                        new VehicleMod() { ID = 30, Output = 2 },
                        new VehicleMod() { ID = 33, Output = 12 },
                        new VehicleMod() { ID = 34, Output = 0 },
                        new VehicleMod() { ID = 35, Output = 17 },
                        new VehicleMod() { ID = 36, Output = 2 },
                        new VehicleMod() { ID = 37, Output = 6 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 4 },
                        new VehicleMod() { ID = 40, Output = 3 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 4 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "TORNADO5_VAGOS_PB",
                ModelName = "TORNADO5",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 89,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 89,
                    SecondaryColor = 118,
                    PearlescentColor = 11,
                    InteriorColor = 21,
                    DashboardColor = 160,
                    WheelColor = 147,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 16 },
                        new VehicleMod() { ID = 27, Output = 8 },
                        new VehicleMod() { ID = 28, Output = 0 },
                        new VehicleMod() { ID = 30, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 14 },
                        new VehicleMod() { ID = 34, Output = 0 },
                        new VehicleMod() { ID = 35, Output = 17 },
                        new VehicleMod() { ID = 37, Output = 2 },
                        new VehicleMod() { ID = 38, Output = 5 },
                        new VehicleMod() { ID = 39, Output = 4 },
                        new VehicleMod() { ID = 40, Output = 3 },
                        new VehicleMod() { ID = 42, Output = 5 },
                        new VehicleMod() { ID = 43, Output = 0 },
                        new VehicleMod() { ID = 45, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetFamiliesVehicles()
    {
        FamiliesVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("emperor",15,15) { RequiredPrimaryColorID = 53,RequiredSecondaryColorID = 53 },//green
            new DispatchableVehicle("nemesis",15,15) {MaxOccupants = 1 },
            new DispatchableVehicle("buccaneer",15,15) { RequiredPrimaryColorID = 53,RequiredSecondaryColorID = 53 },//green
            new DispatchableVehicle("tornado",15,15)  { RequiredPrimaryColorID = 53,RequiredSecondaryColorID = 53 },//green    
            //Custom
            // SUV
            new DispatchableVehicle() {
                DebugName = "ALEUTIAN_Families_PB",
                ModelName = "ALEUTIAN",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 93,
                    DashboardColor = 55,
                    WheelColor = 156,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 6, Output = 6 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 22 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "MINIVAN2_Families_PB",
                ModelName = "MINIVAN2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 0,
                    DashboardColor = 55,
                    WheelColor = 156,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 15 },
                        new VehicleMod() { ID = 25, Output = 4 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 28, Output = 5 },
                        new VehicleMod() { ID = 31, Output = 3 },
                        new VehicleMod() { ID = 32, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 6 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 35, Output = 18 },
                        new VehicleMod() { ID = 37, Output = 6 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "glendale2_Families_PB",
                ModelName = "glendale2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 18,
                    DashboardColor = 55,
                    WheelColor = 156,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 18 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 4 },
                        new VehicleMod() { ID = 27, Output = 6 },
                        new VehicleMod() { ID = 28, Output = 5 },
                        new VehicleMod() { ID = 33, Output = 4 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 35, Output = 18 },
                        new VehicleMod() { ID = 36, Output = 3 },
                        new VehicleMod() { ID = 37, Output = 4 },
                        new VehicleMod() { ID = 38, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 4 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 8 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "greenwood_Families_PB",
                ModelName = "greenwood",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 93,
                    DashboardColor = 55,
                    WheelColor = 156,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 7 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 24 },
                        new VehicleMod() { ID = 40, Output = 2 },
                        new VehicleMod() { ID = 42, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BUFFALO4_Families_PB",
                ModelName = "BUFFALO4",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 1,
                    DashboardColor = 55,
                    WheelColor = 112,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 14 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "PEYOTE3_Families_PB",
                ModelName = "PEYOTE3",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 1,
                    DashboardColor = 55,
                    WheelColor = 156,
                    WheelType = 8,
                    WindowTint = 0,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 26 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 4 },
                        new VehicleMod() { ID = 27, Output = 7 },
                        new VehicleMod() { ID = 28, Output = 5 },
                        new VehicleMod() { ID = 30, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 1 },
                        new VehicleMod() { ID = 35, Output = 13 },
                        new VehicleMod() { ID = 39, Output = 1 },
                        new VehicleMod() { ID = 43, Output = 0 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "manana2_Families_PB",
                ModelName = "manana2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 21,
                    DashboardColor = 4,
                    WheelColor = 156,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false },
                        new VehicleExtra() { ID = 3, IsTurnedOn = true },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 24 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 4 },
                        new VehicleMod() { ID = 27, Output = 0 },
                        new VehicleMod() { ID = 28, Output = 5 },
                        new VehicleMod() { ID = 33, Output = 1 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 37, Output = 3 },
                        new VehicleMod() { ID = 38, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 1 },
                        new VehicleMod() { ID = 42, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DOMINATOR3_Families_PB",
                ModelName = "DOMINATOR3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 1,
                    DashboardColor = 55,
                    WheelColor = 12,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 7 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 26 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DOMINATOR9_Families_PB",
                ModelName = "DOMINATOR9",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 1,
                    DashboardColor = 55,
                    WheelColor = 156,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 6 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 9 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 25 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            // Specials
            new DispatchableVehicle() {
                DebugName = "MANCHEZ_Families_PB",
                ModelName = "MANCHEZ",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 15,
                    PearlescentColor = 52,
                    InteriorColor = 0,
                    DashboardColor = 55,
                    WheelColor = 12,
                    WheelType = 6,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SANCHEZ2_Families_PB",
                ModelName = "SANCHEZ2",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 0,
                    PearlescentColor = 52,
                    InteriorColor = 1,
                    DashboardColor = 55,
                    WheelColor = 156,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 12, Output = 2 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "BLAZER4_Families_PB",
                ModelName = "BLAZER4",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                RequiredPrimaryColorID = 53,
                RequiredSecondaryColorID = 132,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 53,
                    SecondaryColor = 132,
                    PearlescentColor = 52,
                    InteriorColor = 1,
                    DashboardColor = 55,
                    WheelColor = 134,
                    WheelType = 11,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 4 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetAncelottiVehicles()
    {
        AncelottiVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("cognoscenti", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cogcabrio", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("huntley", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            //Custom
            // SUV
            new DispatchableVehicle() {
                DebugName = "HUNTLEY_Ancelotti_PB",
                ModelName = "HUNTLEY",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 0,
                    PearlescentColor = 157,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 156,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 35 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "Novak_Ancelotti_PB",
                ModelName = "Novak",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 0,
                    PearlescentColor = 157,
                    InteriorColor = 4,
                    DashboardColor = 156,
                    WheelColor = 156,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "CAVALCADE3_Ancelotti_PB",
                ModelName = "CAVALCADE3",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 75,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 75,
                    PearlescentColor = 157,
                    InteriorColor = 4,
                    DashboardColor = 156,
                    WheelColor = 156,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 4 },
                        new VehicleMod() { ID = 3, Output = 13 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 5 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 32 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "omnisegt_Ancelotti_PB",
                ModelName = "omnisegt",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 0,
                    PearlescentColor = 157,
                    InteriorColor = 4,
                    DashboardColor = 156,
                    WheelColor = 156,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 30 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "COG55_Ancelotti_PB",
                ModelName = "COG55",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 75,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 75,
                    PearlescentColor = 157,
                    InteriorColor = 1,
                    DashboardColor = 156,
                    WheelColor = 156,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 31 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "cinquemila_Ancelotti_PB",
                ModelName = "cinquemila",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 0,
                    PearlescentColor = 157,
                    InteriorColor = 4,
                    DashboardColor = 156,
                    WheelColor = 156,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "COGCABRIO_Ancelotti_PB",
                ModelName = "COGCABRIO",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 0,
                    PearlescentColor = 157,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 156,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 28 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "drafter_Ancelotti_PB",
                ModelName = "drafter",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 0,
                    PearlescentColor = 157,
                    InteriorColor = 111,
                    DashboardColor = 156,
                    WheelColor = 156,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "COMET7_Ancelotti_PB",
                ModelName = "COMET7",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 0,
                    PearlescentColor = 157,
                    InteriorColor = 4,
                    DashboardColor = 156,
                    WheelColor = 156,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 40 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "NINEF2_Ancelotti_PB",
                ModelName = "NINEF2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 75,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 75,
                    SecondaryColor = 0,
                    PearlescentColor = 157,
                    InteriorColor = 4,
                    DashboardColor = 156,
                    WheelColor = 156,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 39 },
                    },
                },
                RequiresDLC = false,
            }
        };
    }
    private void SetMessinaVehicles()
    {
        MessinaVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("sentinel", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cognoscenti", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cogcabrio", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            //Custom
            // SUV
            new DispatchableVehicle() {
                DebugName = "jubilee_Messina_PB",
                ModelName = "jubilee",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 12,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 9 },
                        new VehicleMod() { ID = 2, Output = 7 },
                        new VehicleMod() { ID = 3, Output = 8 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 7, Output = 14 },
                        new VehicleMod() { ID = 23, Output = 26 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BALLER8_Messina_PB",
                ModelName = "BALLER8",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 93,
                    DashboardColor = 120,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 29 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door 
            new DispatchableVehicle() {
                DebugName = "WINDSOR2_Messina_PB",
                ModelName = "WINDSOR2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 0,
                    DashboardColor = 27,
                    WheelColor = 0,
                    WheelType = 12,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SUPERD_Messina_PB",
                ModelName = "SUPERD",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 29 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "COG55_Messina_PB",
                ModelName = "COG55",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 7 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "deity_Messina_PB",
                ModelName = "deity",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 3 },
                        new VehicleMod() { ID = 3, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 6 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "WINDSOR_Messina_PB",
                ModelName = "WINDSOR",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 26 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "PARAGON3_Messina_PB",
                ModelName = "PARAGON3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "paragon_Messina_PB",
                ModelName = "paragon",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 34,
                RequiredSecondaryColorID = 34,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 34,
                    SecondaryColor = 34,
                    PearlescentColor = 47,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetLupisellaVehicles()
    {
        LupisellaVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("sentinel", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("sentinel2", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("huntley", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            //Custom
            //SUV - Wagon
            new DispatchableVehicle() {
                DebugName = "rebla_Lupisella_PB",
                ModelName = "rebla",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 96,
                RequiredSecondaryColorID = 96,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 96,
                    SecondaryColor = 96,
                    PearlescentColor = 95,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 8 },
                        new VehicleMod() { ID = 8, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 16 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "rhinehart_Lupisella_PB",
                ModelName = "rhinehart",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 96,
                RequiredSecondaryColorID = 96,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 96,
                    SecondaryColor = 96,
                    PearlescentColor = 95,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 9 },
                        new VehicleMod() { ID = 23, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "sentinel5_Lupisella_PB",
                ModelName = "sentinel5",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 96,
                RequiredSecondaryColorID = 96,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 96,
                    SecondaryColor = 96,
                    PearlescentColor = 95,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 7 },
                        new VehicleMod() { ID = 42, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "komoda_Lupisella_PB",
                ModelName = "komoda",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 96,
                RequiredSecondaryColorID = 96,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 96,
                    SecondaryColor = 96,
                    PearlescentColor = 95,
                    InteriorColor = 4,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "ORACLE_Lupisella_PB",
                ModelName = "ORACLE",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 96,
                RequiredSecondaryColorID = 96,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 96,
                    SecondaryColor = 96,
                    PearlescentColor = 95,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 42 },
                    },
                },
                RequiresDLC = false,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "cypher_Lupisella_PB",
                ModelName = "cypher",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 96,
                RequiredSecondaryColorID = 96,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 96,
                    SecondaryColor = 96,
                    PearlescentColor = 95,
                    InteriorColor = 22,
                    DashboardColor = 157,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 5 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 7 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 16 },
                        new VehicleMod() { ID = 26, Output = 1 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 42, Output = 1 },
                        new VehicleMod() { ID = 44, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "NIOBE_Lupisella_PB",
                ModelName = "NIOBE",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 96,
                RequiredSecondaryColorID = 96,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 96,
                    SecondaryColor = 96,
                    PearlescentColor = 95,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SENTINEL_Lupisella_PB",
                ModelName = "SENTINEL",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 96,
                RequiredSecondaryColorID = 96,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 96,
                    SecondaryColor = 96,
                    PearlescentColor = 95,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 21 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 8 },
                        new VehicleMod() { ID = 9, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 17 },
                    },
                },
                RequiresDLC = false,
            }
        };
    }
    private void SetPavanoVehicles()
    {
        PavanoVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("sentinel", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("sentinel2", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cogcabrio", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            //Custom
            // SUV
            new DispatchableVehicle() {
                DebugName = "ALEUTIAN_Pavano_PB",
                ModelName = "ALEUTIAN",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "ROCOTO_Pavano_PB",
                ModelName = "ROCOTO",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 147,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 15 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "IWAGEN_Pavano_PB",
                ModelName = "IWAGEN",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 93,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 6 },
                        new VehicleMod() { ID = 23, Output = 11 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "TAILGATER2_Pavano_PB",
                ModelName = "TAILGATER2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 5,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 7 },
                        new VehicleMod() { ID = 25, Output = 0 },
                        new VehicleMod() { ID = 27, Output = 2 },
                        new VehicleMod() { ID = 42, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "TAILGATER_Pavano_PB",
                ModelName = "TAILGATER",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },
                        new VehicleExtra() { ID = 3, IsTurnedOn = true },

                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 16 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "minimus_Pavano_PB",
                ModelName = "minimus",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 6, Output = 5 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 16 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "CHAVOSV6_Pavano_PB",
                ModelName = "CHAVOSV6",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "drafter_Pavano_PB",
                ModelName = "drafter",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "cypher_Pavano_PB",
                ModelName = "cypher",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 52,
                RequiredSecondaryColorID = 52,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 52,
                    SecondaryColor = 52,
                    PearlescentColor = 59,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetGambettiVehicles()
    {
        
        GambettiVehicles = new List<DispatchableVehicle>()
        {
            //test
            Create_GangSentinel5(75, 75, GangVehicleType.Gang1, -1, -1, 1, 4, "", "", false, 2, 4, -1, 15, -1, 0, 3, true),
            Create_GangSentinel5(75, 75, GangVehicleType.Gang2, -1, -1, 1, 4, "", "", false, 2, 4, -1, 56, 27, 11, 2, true),
            Create_GangSentinel5(75, 75, GangVehicleType.Gang3, -1, -1, 1, 4, "", "", false, 2, 4, -1, 27, 42, 11, 1, true),
            Create_GangSentinel5(75, 75, GangVehicleType.Gang4, -1, -1, 1, 4, "", "", false, 2, 4, -1, 42, 56, 12, 1, true),
            //Base
            new DispatchableVehicle("sentinel", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("sentinel2", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cognoscenti", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            //Custom
            // SUV
            new DispatchableVehicle() {
                DebugName = "BALLER8_Gambetti_PB",
                ModelName = "BALLER8",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 0,
                    PearlescentColor = 4,
                    InteriorColor = 99,
                    DashboardColor = 6,
                    WheelColor = 147,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 8 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BALLER4_Gambetti_PB",
                ModelName = "BALLER4",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 0,
                    PearlescentColor = 4,
                    InteriorColor = 8,
                    DashboardColor = 156,
                    WheelColor = 147,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 11 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "baller7_Gambetti_PB",
                ModelName = "baller7",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 0,
                    PearlescentColor = 4,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 147,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 5 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = false,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "vstr_Gambetti_PB",
                ModelName = "vstr",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 2,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 2,
                    PearlescentColor = 4,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 147,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 10 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 31 },
                    },
                },
                RequiresDLC = true,
            },
            //new DispatchableVehicle() {
            //    DebugName = "sentinel5_Gambetti_PB",
            //    ModelName = "sentinel5",
            //    AmbientSpawnChance = 75,
            //    WantedSpawnChance = 75,
            //    MaxOccupants = 4,
            //    RequiredPrimaryColorID = 2,
            //    RequiredSecondaryColorID = 0,
            //    RequiredVariation = new VehicleVariation() {
            //        PrimaryColor = 2,
            //        SecondaryColor = 0,
            //        PearlescentColor = 4,
            //        InteriorColor = 15,
            //        DashboardColor = 134,
            //        WheelColor = 147,
            //        WheelType = 0,
            //        WindowTint = 3,
            //        VehicleToggles = new List<VehicleToggle>() {
            //            new VehicleToggle() { ID = 18, IsTurnedOn = true },
            //        },
            //        VehicleMods = new List<VehicleMod>() {
            //            new VehicleMod() { ID = 0, Output = 2 },
            //            new VehicleMod() { ID = 1, Output = 0 },
            //            new VehicleMod() { ID = 2, Output = 0 },
            //            new VehicleMod() { ID = 4, Output = 3 },
            //            new VehicleMod() { ID = 7, Output = 0 },
            //            new VehicleMod() { ID = 8, Output = 0 },
            //            new VehicleMod() { ID = 9, Output = 2 },
            //            new VehicleMod() { ID = 10, Output = 0 },
            //            new VehicleMod() { ID = 11, Output = 3 },
            //            new VehicleMod() { ID = 12, Output = 2 },
            //            new VehicleMod() { ID = 13, Output = 2 },
            //            new VehicleMod() { ID = 15, Output = 1 },
            //            new VehicleMod() { ID = 23, Output = 31 },
            //        },
            //    },
            //    RequiresDLC = true,
            //},
            new DispatchableVehicle() {
                DebugName = "deity_Gambetti_PB",
                ModelName = "deity",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 0,
                    PearlescentColor = 4,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 147,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 4 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "paragon_Gambetti_PB",
                ModelName = "paragon",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 0,
                    PearlescentColor = 4,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 147,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 39 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SCHWARZER_Gambetti_PB",
                ModelName = "SCHWARZER",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 0,
                    PearlescentColor = 4,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 147,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 7 },
                        new VehicleMod() { ID = 7, Output = 14 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 30 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "drafter_Gambetti_PB",
                ModelName = "drafter",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 0,
                    PearlescentColor = 4,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 147,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 7 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "vectre_Gambetti_PB",
                ModelName = "vectre",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 2,
                RequiredSecondaryColorID = 2,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 2,
                    SecondaryColor = 2,
                    PearlescentColor = 4,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 147,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 10 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 32 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetArmenianVehicles()
    {
        ArmenianVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("schafter2", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black

            //Custom
            // SUV
            new DispatchableVehicle() {
                DebugName = "DUBSTA2_Armenian_PB",
                ModelName = "DUBSTA2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 2,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "Novak_Armenian_PB",
                ModelName = "Novak",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 0,
                    InteriorColor = 3,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "SCHAFTER3_Armenian_PB",
                ModelName = "SCHAFTER3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 4,
                    InteriorColor = 1,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 2,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 26 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SCHAFTER4_Armenian_PB",
                ModelName = "SCHAFTER4",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 0,
                    InteriorColor = 1,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 2,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "sentinel5_Armenian_PB",
                ModelName = "sentinel5",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 0,
                    InteriorColor = 3,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 12,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 5 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 4 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 25 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "STREITER_Armenian_PB",
                ModelName = "STREITER",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 0,
                    InteriorColor = 3,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 5 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 17 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "vorschlaghammer_Armenian_PB",
                ModelName = "vorschlaghammer",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 0,
                    InteriorColor = 3,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 2,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 12 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 0 },
                        new VehicleMod() { ID = 27, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "SCHWARZER_Armenian_PB",
                ModelName = "SCHWARZER",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 2,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 11 },
                        new VehicleMod() { ID = 9, Output = 3 },
                        new VehicleMod() { ID = 10, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 17 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "schlagen_Armenian_PB",
                ModelName = "schlagen",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 0,
                    InteriorColor = 3,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 2,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 6 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 16 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "cypher_Armenian_PB",
                ModelName = "cypher",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 147,
                RequiredSecondaryColorID = 147,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 147,
                    SecondaryColor = 147,
                    PearlescentColor = 0,
                    InteriorColor = 3,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 7 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetCartelVehicles()
    {
        CartelVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("cavalcade2", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            new DispatchableVehicle("cavalcade", 20, 20) { RequiredPrimaryColorID = 0,RequiredSecondaryColorID = 0 },//black
            //Custom
            // 4 Door SUV/Pickups/Offroads
            new DispatchableVehicle() {
                DebugName = "KAMACHO_Cartel_PB",
                ModelName = "KAMACHO",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 93,
                    DashboardColor = 65,
                    WheelColor = 0,
                    WheelType = 4,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 1, IsTurnedOn = true },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 6 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 7 },
                        new VehicleMod() { ID = 23, Output = 23 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "PATRIOT3_Cartel_PB",
                ModelName = "PATRIOT3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 64,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 4,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 5 },
                        new VehicleMod() { ID = 2, Output = 5 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 8 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 7 },
                        new VehicleMod() { ID = 23, Output = 23 },
                        new VehicleMod() { ID = 28, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "CAVALCADE2_Cartel_PB",
                ModelName = "CAVALCADE2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "CAVALCADE3_Cartel_PB",
                ModelName = "CAVALCADE3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 7,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 19 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 6, Output = 13 },
                        new VehicleMod() { ID = 7, Output = 5 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "GRANGER2_Cartel_PB",
                ModelName = "GRANGER2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 4,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 29 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "caracara2_Cartel_PB",
                ModelName = "caracara2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 7,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 8 },
                        new VehicleMod() { ID = 1, Output = 6 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door SUV/Pickups/Offroads
            new DispatchableVehicle() {
                DebugName = "hellion_Cartel_PB",
                ModelName = "hellion",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 1,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 4,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 11 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 5 },
                        new VehicleMod() { ID = 8, Output = 8 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "YOSEMITE1500_Cartel_PB",
                ModelName = "YOSEMITE1500",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 4,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 6 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 34 },
                    },
                },
                RequiresDLC = true,
            }

        };
    }
    private void SetRedneckVehicles()
    {
        RedneckVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("sandking2",10,10),
            new DispatchableVehicle("rebel", 10, 10),
            new DispatchableVehicle("bison", 10, 10),
            new DispatchableVehicle("sanchez2",10,10) {MaxOccupants = 1 },
            //Custom
            // Vans
            new DispatchableVehicle() {
                DebugName = "youga3_Redneck_PB",
                ModelName = "youga3",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredInteriorColorID = 16,
                RequiredWheelColorID = 12,
                WheelType = 4,
                MaxRandomDirtLevel = 10,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(0,65) // spoiler
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(2,18),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,18),
                            new DispatchableVehicleModValue(5,16),
                            new DispatchableVehicleModValue(6,16),
                            new DispatchableVehicleModValue(7,16),
                        },
                    },
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,20),
                            new DispatchableVehicleModValue(1,40),
                            new DispatchableVehicleModValue(2,20),
                            new DispatchableVehicleModValue(3,20),
                        },
                    },
                    new DispatchableVehicleMod(2,65) // rear bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(1,20),
                            new DispatchableVehicleModValue(2,16),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,16),
                            new DispatchableVehicleModValue(5,16),
                        },
                    },
                    new DispatchableVehicleMod(3,65) // side skirt
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,40),
                            new DispatchableVehicleModValue(3,30),
                            new DispatchableVehicleModValue(4,30),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(1,16),
                            new DispatchableVehicleModValue(2,16),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,20),
                            new DispatchableVehicleModValue(5,16),
                        },
                    },
                    new DispatchableVehicleMod(5,50) // side ladders
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),

                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(1,16),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,16),
                            new DispatchableVehicleModValue(5,16),
                            new DispatchableVehicleModValue(6,20),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(1,12),
                            new DispatchableVehicleModValue(3,12),
                            new DispatchableVehicleModValue(4,12),
                            new DispatchableVehicleModValue(5,12),
                            new DispatchableVehicleModValue(6,12),
                            new DispatchableVehicleModValue(7,12),
                            new DispatchableVehicleModValue(8,12),
                        },
                    },
                    new DispatchableVehicleMod(9,65) // roof visor
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,22),
                            new DispatchableVehicleModValue(1,22),
                            new DispatchableVehicleModValue(2,34),
                            new DispatchableVehicleModValue(3,22),
                        },
                    },
                    new DispatchableVehicleMod(10,65) // roof 
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,35),
                            new DispatchableVehicleModValue(1,35),
                            new DispatchableVehicleModValue(2,40),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(27,65) // interior design
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(6,16),
                            new DispatchableVehicleModValue(9,16),
                            new DispatchableVehicleModValue(10,18),
                            new DispatchableVehicleModValue(12,16),
                        },
                    },
                    new DispatchableVehicleMod(39,65) // splitters
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,18),
                            new DispatchableVehicleModValue(1,16),
                            new DispatchableVehicleModValue(2,16),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,18),
                            new DispatchableVehicleModValue(5,16),
                        },
                    },
                    new DispatchableVehicleMod(42,65) // bull bars
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,20),
                            new DispatchableVehicleModValue(1,20),
                            new DispatchableVehicleModValue(2,20),
                            new DispatchableVehicleModValue(3,20),
                            new DispatchableVehicleModValue(4,20),
                        },
                    },
                    new DispatchableVehicleMod(43,100) // light cover
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                        },
                    },
                    new DispatchableVehicleMod(44,65) // roof attachments
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,20),
                            new DispatchableVehicleModValue(1,20),
                            new DispatchableVehicleModValue(2,20),
                            new DispatchableVehicleModValue(3,20),
                            new DispatchableVehicleModValue(4,20),
                        },
                    },
                    new DispatchableVehicleMod(45,65)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,10),
                            new DispatchableVehicleModValue(1,16),
                            new DispatchableVehicleModValue(2,16),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,16),
                            new DispatchableVehicleModValue(5,18)
                        },
                    },
                    new DispatchableVehicleMod(46,65)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,20),
                            new DispatchableVehicleModValue(1,20),
                            new DispatchableVehicleModValue(2,20),
                            new DispatchableVehicleModValue(3,20),
                        },
                    },
                    new DispatchableVehicleMod(47,65)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,30),
                            new DispatchableVehicleModValue(1,35),
                            new DispatchableVehicleModValue(2,30),
                        },
                    },
                    new DispatchableVehicleMod(48,100) // liveries
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,8),
                            new DispatchableVehicleModValue(1,12),
                            new DispatchableVehicleModValue(2,8),
                            new DispatchableVehicleModValue(3,8),
                            new DispatchableVehicleModValue(5,8),
                            new DispatchableVehicleModValue(6,8),
                            new DispatchableVehicleModValue(7,8),
                            new DispatchableVehicleModValue(8,8),
                            new DispatchableVehicleModValue(9,8),
                            new DispatchableVehicleModValue(10,8),
                            new DispatchableVehicleModValue(11,8),

                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "YOUGA2_Redneck_PB",
                ModelName = "YOUGA2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredInteriorColorID = 156,
                RequiredWheelColorID = 12,
                WheelType = 1,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(3,65) // side skirt
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                        },
                    },
                    new DispatchableVehicleMod(5,65) // sidesteps
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),

                        },
                    },
                    new DispatchableVehicleMod(10,65) // roof 
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(5,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(7,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(10,5),
                            new DispatchableVehicleModValue(11,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(15,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(25,5),
                            new DispatchableVehicleModValue(26,5),
                            new DispatchableVehicleModValue(28,5),
                            new DispatchableVehicleModValue(29,5),
                            new DispatchableVehicleModValue(33,5),

                        },
                    },
                    new DispatchableVehicleMod(48,100) // liveries
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,5),
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(8,20),
                            new DispatchableVehicleModValue(9,15),
                            new DispatchableVehicleModValue(10,20),
                            new DispatchableVehicleModValue(11,20),

                        },
                    },
                },
                RequiresDLC = true,
            },
            // Pickup Trucks SUV
            new DispatchableVehicle() {
                DebugName = "yosemite3_Redneck_PB",
                ModelName = "yosemite3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredInteriorColorID = 16,
                RequiredWheelColorID = 12,
                WheelType = 4,
                MaxRandomDirtLevel = 10,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(0,65) // spoiler
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                            new DispatchableVehicleModValue(1,50),
                        },
                    },
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,10),
                            new DispatchableVehicleModValue(1,10),
                            new DispatchableVehicleModValue(2,10),
                            new DispatchableVehicleModValue(3,10),
                            new DispatchableVehicleModValue(4,10),
                            new DispatchableVehicleModValue(5,10),
                            new DispatchableVehicleModValue(6,10),
                            new DispatchableVehicleModValue(7,10),
                            new DispatchableVehicleModValue(8,10),
                            new DispatchableVehicleModValue(9,10),
                        },
                    },
                    new DispatchableVehicleMod(2,65) // rear bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,20),
                            new DispatchableVehicleModValue(1,20),
                            new DispatchableVehicleModValue(2,20),
                            new DispatchableVehicleModValue(3,20),
                            new DispatchableVehicleModValue(4,20),
                        },
                    },
                    new DispatchableVehicleMod(3,65) // side skirt
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(1,25),
                            new DispatchableVehicleModValue(4,25),
                            new DispatchableVehicleModValue(5,25),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,33),
                            new DispatchableVehicleModValue(1,33),
                            new DispatchableVehicleModValue(2,34),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(1,17),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,17),
                            new DispatchableVehicleModValue(5,16),
                            new DispatchableVehicleModValue(6,17),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,13),
                            new DispatchableVehicleModValue(1,9),
                            new DispatchableVehicleModValue(3,10),
                            new DispatchableVehicleModValue(4,10),
                            new DispatchableVehicleModValue(5,10),
                            new DispatchableVehicleModValue(6,10),
                            new DispatchableVehicleModValue(7,18),
                            new DispatchableVehicleModValue(8,10),
                            new DispatchableVehicleModValue(9,10),
                        },
                    },
                    new DispatchableVehicleMod(8,65)  // Fendor - Arches
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,33),
                            new DispatchableVehicleModValue(1,33),
                            new DispatchableVehicleModValue(2,34),
                        },
                    },
                    new DispatchableVehicleMod(9,65) // Right Fender - Side Steps
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,19),
                            new DispatchableVehicleModValue(4,19),
                            new DispatchableVehicleModValue(7,19),
                            new DispatchableVehicleModValue(10,24),
                            new DispatchableVehicleModValue(13,19),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(42,65) // rear roll cage
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,24),
                            new DispatchableVehicleModValue(2,24),
                            new DispatchableVehicleModValue(5,24),
                            new DispatchableVehicleModValue(6,28),
                        },
                    },
                    new DispatchableVehicleMod(44,65)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                            new DispatchableVehicleModValue(1,50),
                        },
                    },
                    new DispatchableVehicleMod(48,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,10),
                            new DispatchableVehicleModValue(1,10),
                            new DispatchableVehicleModValue(2,10),
                            new DispatchableVehicleModValue(12,10),
                            new DispatchableVehicleModValue(13,20),
                            new DispatchableVehicleModValue(14,20),
                            new DispatchableVehicleModValue(15,20),

                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "yosemite_Redneck_PB",
                ModelName = "yosemite",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredInteriorColorID = 16,
                RequiredWheelColorID = 12,
                WheelType = 4,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(0,65) // spoiler
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,30),
                            new DispatchableVehicleModValue(1,35),
                            new DispatchableVehicleModValue(5,35),
                        },
                    },
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,10),
                            new DispatchableVehicleModValue(1,10),
                            new DispatchableVehicleModValue(2,10),
                            new DispatchableVehicleModValue(4,10),
                            new DispatchableVehicleModValue(5,10),
                            new DispatchableVehicleModValue(7,10),
                            new DispatchableVehicleModValue(8,10),
                        },
                    },
                    new DispatchableVehicleMod(2,65) // rear bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                        },
                    },
                    new DispatchableVehicleMod(3,65) // side skirt
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(3,14),
                            new DispatchableVehicleModValue(4,14),
                            new DispatchableVehicleModValue(6,14),
                            new DispatchableVehicleModValue(7,14),
                            new DispatchableVehicleModValue(9,14),
                            new DispatchableVehicleModValue(10,14),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(1,25),
                            new DispatchableVehicleModValue(2,25),
                            new DispatchableVehicleModValue(3,25),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,10),
                            new DispatchableVehicleModValue(1,10),
                            new DispatchableVehicleModValue(3,12),
                            new DispatchableVehicleModValue(4,12),
                            new DispatchableVehicleModValue(5,10),
                            new DispatchableVehicleModValue(6,10),
                            new DispatchableVehicleModValue(7,10),
                            new DispatchableVehicleModValue(8,10),
                        },
                    },
                    new DispatchableVehicleMod(10,65) // roof - pickup bed cover
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                            new DispatchableVehicleModValue(3,50),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(48,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,20),
                            new DispatchableVehicleModValue(1,20),
                            new DispatchableVehicleModValue(5,10),
                            new DispatchableVehicleModValue(6,10),
                            new DispatchableVehicleModValue(7,10),
                            new DispatchableVehicleModValue(8,10),
                            new DispatchableVehicleModValue(9,20),

                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "slamvan4_Redneck_PB",
                ModelName = "slamvan4",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(2,65) // wheel guards
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,30),
                            new DispatchableVehicleModValue(1,30),
                            new DispatchableVehicleModValue(2,40),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,28),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(2,24),
                            new DispatchableVehicleModValue(3,24),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood horns
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,30),
                            new DispatchableVehicleModValue(1,30),
                            new DispatchableVehicleModValue(2,40),
                        },
                    },
                    new DispatchableVehicleMod(36,5) // wheelie bars
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(42,65) // ram bars
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,40),
                            new DispatchableVehicleModValue(2,60),
                        },
                    },
                    new DispatchableVehicleMod(48,100) // liveries
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(1,25),
                            new DispatchableVehicleModValue(2,35),
                            new DispatchableVehicleModValue(3,15),
                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SLAMVAN3_Redneck_PB",
                ModelName = "SLAMVAN3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredInteriorColorID = 16,
                RequiredWheelColorID = 12,
                WheelType = 4,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(0,50) // bed spoiler
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,15),
                            new DispatchableVehicleModValue(1,15),
                            new DispatchableVehicleModValue(2,15),
                            new DispatchableVehicleModValue(3,25),
                            new DispatchableVehicleModValue(4,30),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,30),
                            new DispatchableVehicleModValue(1,15),
                            new DispatchableVehicleModValue(2,15),
                            new DispatchableVehicleModValue(3,20),
                            new DispatchableVehicleModValue(4,20),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,30),
                            new DispatchableVehicleModValue(2,30),
                            new DispatchableVehicleModValue(3,40),

                        },
                    },
                    new DispatchableVehicleMod(10,65) // windscreen visor
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),

                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(32,65) // seats
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,18),
                            new DispatchableVehicleModValue(1,16),
                            new DispatchableVehicleModValue(2,16),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(5,18),
                            new DispatchableVehicleModValue(6,16),
                        },
                    },
                    new DispatchableVehicleMod(45,65) // rear roll cage
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                            new DispatchableVehicleModValue(1,50),
                        },
                    },
                    new DispatchableVehicleMod(48,100) // liveries
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,15),
                            new DispatchableVehicleModValue(3,15),
                            new DispatchableVehicleModValue(4,15),
                            new DispatchableVehicleModValue(5,5),
                            new DispatchableVehicleModValue(6,15),
                            new DispatchableVehicleModValue(7,30),
                            new DispatchableVehicleModValue(8,5),

                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "seminole2_Redneck_PB",
                ModelName = "seminole2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredWheelColorID = 12,
                WheelType = 4,
                MaxRandomDirtLevel = 10,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(0,65) // deflectors - spoiler
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,30),
                            new DispatchableVehicleModValue(1,30),
                            new DispatchableVehicleModValue(2,40),
                        },
                    },
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,14),
                            new DispatchableVehicleModValue(1,14),
                            new DispatchableVehicleModValue(2,13),
                            new DispatchableVehicleModValue(3,13),
                            new DispatchableVehicleModValue(4,20),
                            new DispatchableVehicleModValue(5,13),
                            new DispatchableVehicleModValue(6,13),
                        },
                    },
                    new DispatchableVehicleMod(2,65) // antenna - rear bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),

                        },
                    },
                    new DispatchableVehicleMod(3,65) // side skirt
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,40),
                            new DispatchableVehicleModValue(1,60),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,24),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(3,24),
                            new DispatchableVehicleModValue(4,28),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,24),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(2,28),
                            new DispatchableVehicleModValue(3,24),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(2,25),
                            new DispatchableVehicleModValue(4,50),
                        },
                    },
                    new DispatchableVehicleMod(8,65)  // Fendor - Arches
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,18),
                            new DispatchableVehicleModValue(1,18),
                            new DispatchableVehicleModValue(2,18),
                            new DispatchableVehicleModValue(3,18),
                            new DispatchableVehicleModValue(4,28),
                        },
                    },
                    new DispatchableVehicleMod(9,65) // Mud Flaps
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),

                        },
                    },
                    new DispatchableVehicleMod(10,65)  // roof rack
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,13),
                            new DispatchableVehicleModValue(1,13),
                            new DispatchableVehicleModValue(2,13),
                            new DispatchableVehicleModValue(3,20),
                            new DispatchableVehicleModValue(4,13),
                            new DispatchableVehicleModValue(5,13),
                            new DispatchableVehicleModValue(6,13),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(42,50) // mirrors
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(48,100) // liveries
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,14),
                            new DispatchableVehicleModValue(1,14),
                            new DispatchableVehicleModValue(2,13),
                            new DispatchableVehicleModValue(5,20),
                            new DispatchableVehicleModValue(6,13),
                            new DispatchableVehicleModValue(7,13),
                            new DispatchableVehicleModValue(9,13),

                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "RATLOADER_Redneck_PB",
                ModelName = "RATLOADER",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredWheelColorID = 12,
                WheelType = 1,
                MaxRandomDirtLevel = 10,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,28),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(2,24),
                            new DispatchableVehicleModValue(3,24),
                        },
                    },
                    new DispatchableVehicleMod(5,65) // engine cover
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(1,25),
                            new DispatchableVehicleModValue(2,25),
                            new DispatchableVehicleModValue(3,25),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(1,16),
                            new DispatchableVehicleModValue(2,16),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,18),
                            new DispatchableVehicleModValue(5,16),
                        },
                    },
                    new DispatchableVehicleMod(8,65)  // Fendor - Arches
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                            new DispatchableVehicleModValue(1,50),
                        },
                    },
                    new DispatchableVehicleMod(10,65)  // rear bed
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,23),
                            new DispatchableVehicleModValue(1,27),
                            new DispatchableVehicleModValue(2,27),
                            new DispatchableVehicleModValue(3,23),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                },
                RequiresDLC = false,
            },
            // Muscle Cars 2 doors
            new DispatchableVehicle() {
                DebugName = "dukes3_Redneck_PB",
                ModelName = "dukes3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredWheelColorID = 12,
                WheelType = 1,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(0,65) // spoiler
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,30),
                            new DispatchableVehicleModValue(1,20),
                            new DispatchableVehicleModValue(2,15),
                            new DispatchableVehicleModValue(4,20),
                            new DispatchableVehicleModValue(5,15),
                        },
                    },
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,28),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(2,24),
                            new DispatchableVehicleModValue(7,24),
                        },
                    },
                    new DispatchableVehicleMod(3,65) // Louvers
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,60),
                            new DispatchableVehicleModValue(1,40),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(1,16),
                            new DispatchableVehicleModValue(4,20),
                            new DispatchableVehicleModValue(5,16),
                            new DispatchableVehicleModValue(6,16),
                            new DispatchableVehicleModValue(8,16),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,24),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(2,24),
                            new DispatchableVehicleModValue(3,28),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,14),
                            new DispatchableVehicleModValue(1,20),
                            new DispatchableVehicleModValue(3,14),
                            new DispatchableVehicleModValue(8,13),
                            new DispatchableVehicleModValue(9,13),
                            new DispatchableVehicleModValue(10,13),
                            new DispatchableVehicleModValue(11,13),
                        },
                    },
                    new DispatchableVehicleMod(8,65)  // Mirrors
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(1,25),
                            new DispatchableVehicleModValue(2,25),
                            new DispatchableVehicleModValue(3,25),

                        },
                    },
                    new DispatchableVehicleMod(9,65) // Right Wing
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                            new DispatchableVehicleModValue(1,50)

                        },
                    },
                    new DispatchableVehicleMod(10,65)  // roof rack
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,94),
                            new DispatchableVehicleModValue(1,5), // USA! USA! USA!
                            new DispatchableVehicleModValue(20,1), // FREEDOM!
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(48,100) // liveries
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,19),
                            new DispatchableVehicleModValue(1,19),
                            new DispatchableVehicleModValue(2,19),
                            new DispatchableVehicleModValue(4,19),
                            new DispatchableVehicleModValue(5,4),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(7,5),
                            new DispatchableVehicleModValue(9,5),
                            new DispatchableVehicleModValue(10,5),

                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "broadway_Redneck_PB",// Default Pearlescent Paint Still Applies.
                ModelName = "broadway",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredWheelColorID = 12,
                WheelType = 1,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {

                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,18),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(2,18),
                            new DispatchableVehicleModValue(3,10),
                            new DispatchableVehicleModValue(4,15),
                            new DispatchableVehicleModValue(5,15),
                        },
                    },
                    new DispatchableVehicleMod(2,65) // rear bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,28),
                            new DispatchableVehicleModValue(1,18),
                            new DispatchableVehicleModValue(2,18),
                            new DispatchableVehicleModValue(3,18),
                            new DispatchableVehicleModValue(4,18),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,60),
                            new DispatchableVehicleModValue(2,40),

                        },
                    },
                    new DispatchableVehicleMod(5,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,24),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(2,24),
                            new DispatchableVehicleModValue(3,28),

                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,30),
                            new DispatchableVehicleModValue(1,30),
                            new DispatchableVehicleModValue(2,10),
                            new DispatchableVehicleModValue(3,10),
                            new DispatchableVehicleModValue(4,10),
                            new DispatchableVehicleModValue(5,10),
                        },
                    },
                    new DispatchableVehicleMod(8,65)  // Body mod
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,40),
                            new DispatchableVehicleModValue(1,15),
                            new DispatchableVehicleModValue(2,15),
                            new DispatchableVehicleModValue(3,15),
                            new DispatchableVehicleModValue(4,15),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(48,100) // liveries
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,10),
                            new DispatchableVehicleModValue(1,10),
                            new DispatchableVehicleModValue(2,10),
                            new DispatchableVehicleModValue(7,30),
                            new DispatchableVehicleModValue(8,30),
                            new DispatchableVehicleModValue(9,10),

                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DOMINATOR10_Redneck_PB",
                ModelName = "DOMINATOR10",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredInteriorColorID = 16,
                RequiredWheelColorID = 12,
                WheelType = 1,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(0,65) // spoiler
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,24),
                            new DispatchableVehicleModValue(1,24),
                            new DispatchableVehicleModValue(4,24),
                            new DispatchableVehicleModValue(5,28),
                        },
                    },
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,18),
                            new DispatchableVehicleModValue(1,28),
                            new DispatchableVehicleModValue(2,18),
                            new DispatchableVehicleModValue(3,18),
                            new DispatchableVehicleModValue(4,18),
                        },
                    },
                    new DispatchableVehicleMod(2,65) // rear bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,60),
                            new DispatchableVehicleModValue(1,40),

                        },
                    },
                    new DispatchableVehicleMod(3,65) // Skirts
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,14),
                            new DispatchableVehicleModValue(1,14),
                            new DispatchableVehicleModValue(3,14),
                            new DispatchableVehicleModValue(4,14),
                            new DispatchableVehicleModValue(6,14),
                            new DispatchableVehicleModValue(7,14),
                            new DispatchableVehicleModValue(8,16),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,24),
                            new DispatchableVehicleModValue(2,24),
                            new DispatchableVehicleModValue(3,24),
                            new DispatchableVehicleModValue(5,28),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,14),
                            new DispatchableVehicleModValue(1,14),
                            new DispatchableVehicleModValue(2,14),
                            new DispatchableVehicleModValue(3,14),
                            new DispatchableVehicleModValue(4,14),
                            new DispatchableVehicleModValue(5,16),
                            new DispatchableVehicleModValue(6,14),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,24),
                            new DispatchableVehicleModValue(1,28),
                            new DispatchableVehicleModValue(2,24),
                            new DispatchableVehicleModValue(4,24),

                        },
                    },
                    new DispatchableVehicleMod(9,65) // Arch Covers
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,40),
                            new DispatchableVehicleModValue(1,30),
                            new DispatchableVehicleModValue(2,30),

                        },
                    },
                    new DispatchableVehicleMod(10,75)  // sunstrip
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,40),
                            new DispatchableVehicleModValue(1,30),
                            new DispatchableVehicleModValue(2,30),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(48,100) // liveries
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,15),
                            new DispatchableVehicleModValue(1,15),
                            new DispatchableVehicleModValue(3,15),
                            new DispatchableVehicleModValue(5,15),
                            new DispatchableVehicleModValue(9,30),
                            new DispatchableVehicleModValue(12,10),
                        },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "HUSTLER_Redneck_PB",
                ModelName = "HUSTLER",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredWheelColorID = 156,
                WheelType = 4,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,40),
                            new DispatchableVehicleModValue(1,60),
                        },
                    },
                    new DispatchableVehicleMod(2,65) // rear bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,40),
                            new DispatchableVehicleModValue(1,60),
                        },
                    },
                    new DispatchableVehicleMod(3,65) // side skirt
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,60),
                            new DispatchableVehicleModValue(1,40),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(1,25),
                            new DispatchableVehicleModValue(2,25),
                            new DispatchableVehicleModValue(3,25),
                        },
                    },
                    new DispatchableVehicleMod(6,65) // grille
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,28),
                            new DispatchableVehicleModValue(1,18),
                            new DispatchableVehicleModValue(3,18),
                            new DispatchableVehicleModValue(4,18),
                            new DispatchableVehicleModValue(5,18),

                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(1,25),
                            new DispatchableVehicleModValue(2,25),
                            new DispatchableVehicleModValue(3,25),
                        },
                    },
                    new DispatchableVehicleMod(8,65)  // Fendor - Arches
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,33),
                            new DispatchableVehicleModValue(1,33),
                            new DispatchableVehicleModValue(2,34),
                        },
                    },
                    new DispatchableVehicleMod(10,75) // visor
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(48,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,10),
                            new DispatchableVehicleModValue(1,10),
                            new DispatchableVehicleModValue(5,20),
                            new DispatchableVehicleModValue(6,20),
                            new DispatchableVehicleModValue(8,20),
                            new DispatchableVehicleModValue(9,20),

                        },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "EMPEROR2_Redneck_PB",
                ModelName = "EMPEROR2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredWheelColorID = 12,
                WheelType = 2,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleExtras = new List<DispatchableVehicleExtra>()
                {
                    new DispatchableVehicleExtra(10,true,50),
                    new DispatchableVehicleExtra(12,true,50),
                },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                },
                RequiresDLC =false,
            },
            new DispatchableVehicle() {
                DebugName = "tulip_Redneck_PB",
                ModelName = "tulip",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredWheelColorID = 12,
                WheelType = 1,
                MaxRandomDirtLevel = 10,
                RequiredPearlescentColorID = 12,
                OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
                VehicleMods = new List<DispatchableVehicleMod>()
                {
                    new DispatchableVehicleMod(0,65) // spoiler
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,50),
                            new DispatchableVehicleModValue(2,50),
                        },
                    },
                    new DispatchableVehicleMod(1,65) // front bumper
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,50),
                            new DispatchableVehicleModValue(3,25),
                            new DispatchableVehicleModValue(5,25),
                        },
                    },
                    new DispatchableVehicleMod(4,65) // exhaust
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,25),
                            new DispatchableVehicleModValue(1,25),
                            new DispatchableVehicleModValue(2,25),
                            new DispatchableVehicleModValue(3,25),
                        },
                    },
                    new DispatchableVehicleMod(7,65) // hood - bonnet
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,20),
                            new DispatchableVehicleModValue(3,15),
                            new DispatchableVehicleModValue(4,20),
                            new DispatchableVehicleModValue(8,15),
                            new DispatchableVehicleModValue(9,15),
                            new DispatchableVehicleModValue(10,15),
                        },
                    },
                    new DispatchableVehicleMod(23,100) // wheels
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,5),
                            new DispatchableVehicleModValue(2,5),
                            new DispatchableVehicleModValue(3,5),
                            new DispatchableVehicleModValue(4,5),
                            new DispatchableVehicleModValue(6,5),
                            new DispatchableVehicleModValue(8,5),
                            new DispatchableVehicleModValue(12,5),
                            new DispatchableVehicleModValue(13,5),
                            new DispatchableVehicleModValue(14,5),
                            new DispatchableVehicleModValue(16,5),
                            new DispatchableVehicleModValue(17,5),
                            new DispatchableVehicleModValue(18,5),
                            new DispatchableVehicleModValue(19,5),
                            new DispatchableVehicleModValue(20,5),
                            new DispatchableVehicleModValue(21,5),
                            new DispatchableVehicleModValue(22,5),
                            new DispatchableVehicleModValue(23,5),
                            new DispatchableVehicleModValue(24,5),
                        },
                    },
                    new DispatchableVehicleMod(48,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,16),
                            new DispatchableVehicleModValue(1,16),
                            new DispatchableVehicleModValue(3,16),
                            new DispatchableVehicleModValue(4,16),
                            new DispatchableVehicleModValue(5,20),
                            new DispatchableVehicleModValue(6,16),

                        },
                    },
                },
                RequiresDLC = true,
            },         
        };
    }
    private void SetTriadVehicles()
    {
        TriadVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("fugitive", 20, 20){ RequiredPrimaryColorID = 111,RequiredSecondaryColorID = 111 },//white
            new DispatchableVehicle("washington", 20, 20){ RequiredPrimaryColorID = 111,RequiredSecondaryColorID = 111 },//white

            //Custom Vehicles
            //Bikes
            new DispatchableVehicle() {
                DebugName = "HAKUCHOU_Triads_PB",
                ModelName = "HAKUCHOU",
                AmbientSpawnChance = 50,
                WantedSpawnChance = 50,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    WheelColor = 27,
                    WheelType = 6,
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DOUBLE_Triads_PB",
                ModelName = "DOUBLE",
                AmbientSpawnChance = 50,
                WantedSpawnChance = 50,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 0 },
                    },
                },
                RequiresDLC = false,
            },
            //SUV etc Vehicles
            new DispatchableVehicle() {
                DebugName = "VIVANITE_Triads_PB",
                ModelName = "VIVANITE",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 132,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 3, Output = 8 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 6, Output = 4 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 32 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "woodlander_Triads_PB",
                ModelName = "woodlander",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 132,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 5 },
                        new VehicleMod() { ID = 2, Output = 4 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 12 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door Vehicles
            new DispatchableVehicle() {
                    DebugName = "hardy_Triads_PB",
                    ModelName = "hardy",
                    AmbientSpawnChance = 75,
                    WantedSpawnChance = 75,
                    MaxOccupants = 4,
                    RequiredPrimaryColorID = 111,
                    RequiredSecondaryColorID = 111,
                    RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 132,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 8 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 3 },
                        new VehicleMod() { ID = 9, Output = 3 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 32 },
                        new VehicleMod() { ID = 42, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "minimus_Triads_PB",
                ModelName = "minimus",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 132,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 7 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "KURUMA_Triads_PB",
                ModelName = "KURUMA",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>()
                    {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false}
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 16 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "cinquemila_Triads_PB",
                ModelName = "cinquemila",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 132,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 14 },
                        new VehicleMod() { ID = 8, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 5 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 27 },
                    },
                },
                RequiresDLC = true,
            },
            //Tuner Vehicles
            new DispatchableVehicle() {
                DebugName = "ELEGY_Triads_PB",
                ModelName = "ELEGY",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 63,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 9 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 8, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 19 },
                        new VehicleMod() { ID = 26, Output = 0 },
                        new VehicleMod() { ID = 27, Output = 0 },
                        new VehicleMod() { ID = 31, Output = 0 },
                        new VehicleMod() { ID = 32, Output = 5 },
                        new VehicleMod() { ID = 33, Output = 2 },
                        new VehicleMod() { ID = 39, Output = 2 },
                        new VehicleMod() { ID = 40, Output = 7 },
                        new VehicleMod() { ID = 41, Output = 1 },
                        new VehicleMod() { ID = 43, Output = 6 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 46, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "FUTO2_Triads_PB",
                ModelName = "FUTO2",
                AmbientSpawnChance = 60,
                WantedSpawnChance = 60,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 134,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 9 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 11 },
                        new VehicleMod() { ID = 26, Output = 0 },
                        new VehicleMod() { ID = 27, Output = 0 },
                        new VehicleMod() { ID = 32, Output = 1 },
                        new VehicleMod() { ID = 39, Output = 0 },
                        new VehicleMod() { ID = 40, Output = 4 },
                        new VehicleMod() { ID = 41, Output = 11 },
                        new VehicleMod() { ID = 42, Output = 2 },
                        new VehicleMod() { ID = 44, Output = 0 },
                        new VehicleMod() { ID = 45, Output = 0 },
                        new VehicleMod() { ID = 46, Output = 2 },
                        new VehicleMod() { ID = 47, Output = 5 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "JESTER3_Triads_PB",
                ModelName = "JESTER3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 134,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 29 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "Euros_Triads_PB",
                ModelName = "Euros",
                AmbientSpawnChance = 60,
                WantedSpawnChance = 60,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 10 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 12 },
                        new VehicleMod() { ID = 8, Output = 5 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 14 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            // High end Sports Vehicles
            new DispatchableVehicle() {
                DebugName = "tenf2_Triads_PB",
                ModelName = "tenf2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 157,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 6 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 18 },
                        new VehicleMod() { ID = 7, Output = 13 },
                        new VehicleMod() { ID = 8, Output = 4 },
                        new VehicleMod() { ID = 9, Output = 5 },
                        new VehicleMod() { ID = 10, Output = 7 },
                        new VehicleMod() { ID = 15, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 27 },
                        new VehicleMod() { ID = 27, Output = 0 },
                        new VehicleMod() { ID = 29, Output = 3 },
                        new VehicleMod() { ID = 44, Output = 3 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "JESTER4_Triads_PB",
                ModelName = "JESTER4",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 157,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 10 },
                        new VehicleMod() { ID = 1, Output = 9 },
                        new VehicleMod() { ID = 2, Output = 8 },
                        new VehicleMod() { ID = 3, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 5 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 7 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "R300_Triads_PB",
                ModelName = "R300",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 3 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            //Extra Vehicles
            new DispatchableVehicle() {
                DebugName = "REMUS_Triads_PB",
                ModelName = "REMUS",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 132,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 12,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 8 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 5 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 4 },
                        new VehicleMod() { ID = 27, Output = 2 },
                        new VehicleMod() { ID = 30, Output = 5 },
                        new VehicleMod() { ID = 31, Output = 0 },
                        new VehicleMod() { ID = 32, Output = 1 },
                        new VehicleMod() { ID = 33, Output = 11 },
                        new VehicleMod() { ID = 44, Output = 3 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "EUROSX32_Triads_PB",
                ModelName = "EUROSX32",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 132,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 5 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 4 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 15, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 29 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "CHAVOSV6_Triads_PB",
                ModelName = "CHAVOSV6",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 111,
                RequiredSecondaryColorID = 111,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 111,
                    SecondaryColor = 111,
                    PearlescentColor = 0,
                    InteriorColor = 132,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 32 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetKoreanVehicles()
    {
        KoreanVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("feltzer2", 20, 20){ RequiredPrimaryColorID = 4,RequiredSecondaryColorID = 4 },//silver
            new DispatchableVehicle("comet2", 20, 20){ RequiredPrimaryColorID = 4,RequiredSecondaryColorID = 4 },//silver
            new DispatchableVehicle("dubsta2", 20, 20){ RequiredPrimaryColorID = 4,RequiredSecondaryColorID = 4 },//silver

            //Custom Vehicles
            //Bikes
            new DispatchableVehicle() {
                DebugName = "DOUBLE_PB_Korean",
                ModelName = "DOUBLE",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    WheelColor = 0,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 0 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "SHINOBI_PB_Korean",
                ModelName = "SHINOBI",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    WheelColor = 12,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 3 },
                        new VehicleMod() { ID = 24, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            //SUV etc Vehicles
            new DispatchableVehicle() {
                DebugName = "DUBSTA2_PB_Korean",
                ModelName = "DUBSTA2",
                AmbientSpawnChance = 60,
                WantedSpawnChance = 60,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    InteriorColor = 16,
                    PearlescentColor = 5,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 12 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "astron_PB_Korean",
                ModelName = "astron",
                AmbientSpawnChance = 60,
                WantedSpawnChance = 60,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 6 },
                        new VehicleMod() { ID = 1, Output = 6 },
                        new VehicleMod() { ID = 2, Output = 6 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 27 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door Vehicles
            new DispatchableVehicle() {
                DebugName = "CHAVOSV6_PB_Korean",
                ModelName = "CHAVOSV6",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 7,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 7,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 5 },
                        new VehicleMod() { ID = 3, Output = 14 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 14 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 35 },
                        new VehicleMod() { ID = 45, Output = 18 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "minimus_PB_Korean",
                ModelName = "minimus",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 7 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "sentinel5_PB_Korean",
                ModelName = "sentinel5",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 12,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 5 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 26 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SULTAN2_PB_Korean",
                ModelName = "SULTAN2",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 159,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 8 },
                        new VehicleMod() { ID = 5, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 7 },
                        new VehicleMod() { ID = 9, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 16 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            },
            //Tuner Vehicles
            new DispatchableVehicle() {
                DebugName = "JESTER3_PB_Korean",
                ModelName = "JESTER3",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 6 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 22 },
                        new VehicleMod() { ID = 48, Output = 9 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "ZR350_PB_Korean",
                ModelName = "ZR350",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 10 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 6, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 6 },
                        new VehicleMod() { ID = 48, Output = 12 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "comet5_PB_Korean",
                ModelName = "comet5",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 15 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "RT3000_PB_Korean",
                ModelName = "RT3000",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 6, Output = 5 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 22 },
                        new VehicleMod() { ID = 26, Output = 0 },
                        new VehicleMod() { ID = 27, Output = 2 },
                        new VehicleMod() { ID = 31, Output = 0 },
                        new VehicleMod() { ID = 32, Output = 1 },
                        new VehicleMod() { ID = 39, Output = 0 },
                        new VehicleMod() { ID = 40, Output = 6 },
                        new VehicleMod() { ID = 41, Output = 5 },
                        new VehicleMod() { ID = 46, Output = 1 },
                        new VehicleMod() { ID = 47, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            // High end Sports Vehicles
            new DispatchableVehicle() {
                DebugName = "COMET6_PB_Korean",
                ModelName = "COMET6",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 12,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 6 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 6 },
                        new VehicleMod() { ID = 3, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 5 },
                        new VehicleMod() { ID = 8, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 14 },
                        new VehicleMod() { ID = 25, Output = 0 },
                        new VehicleMod() { ID = 26, Output = 0 },
                        new VehicleMod() { ID = 27, Output = 0 },
                        new VehicleMod() { ID = 43, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "GROWLER_PB_Korean",
                ModelName = "GROWLER",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 2, Output = 4 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 7, Output = 7 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 15 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "COMET7_PB_Korean",
                ModelName = "COMET7",
                AmbientSpawnChance = 70,
                WantedSpawnChance = 70,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 11,
                    WindowTint = -1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 7 },
                        new VehicleMod() { ID = 3, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 5 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 26 },
                        new VehicleMod() { ID = 48, Output = 4 },
                    },
                },
                RequiresDLC = true,
            },
            //Extra Vehicles
            new DispatchableVehicle() {
                DebugName = "CAVALCADE3_PB_Korean",
                ModelName = "CAVALCADE3",
                AmbientSpawnChance = 60,
                WantedSpawnChance = 60,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 7,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 7,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 3,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 8 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 3, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 13 },
                        new VehicleMod() { ID = 7, Output = 5 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 11 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "PREVION_PB_Korean",
                ModelName = "PREVION",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 24 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 30, Output = 1 },
                        new VehicleMod() { ID = 32, Output = 1 },
                        new VehicleMod() { ID = 33, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 0 },
                        new VehicleMod() { ID = 42, Output = 6 },
                        new VehicleMod() { ID = 47, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "Sugoi_PB_Korean",
                ModelName = "Sugoi",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 7,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 7,
                    SecondaryColor = 12,
                    PearlescentColor = 5,
                    InteriorColor = 16,
                    DashboardColor = 134,
                    WheelColor = 12,
                    WheelType = 7,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 6, Output = 3 },
                        new VehicleMod() { ID = 15, Output = 1 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetMarabuntaVehicles()
    {
        MarabuntaVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("faction", 20, 20){ RequiredPrimaryColorID = 70,RequiredSecondaryColorID = 70 },
            new DispatchableVehicle("faction2", 20, 20){ RequiredPrimaryColorID = 70,RequiredSecondaryColorID = 70 },//blue

            //Custom
            // Minivan
            new DispatchableVehicle() {
                DebugName = "MOONBEAM2_Marabunta_PB",
                ModelName = "MOONBEAM2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 70,
                RequiredSecondaryColorID = 15,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 70,
                    SecondaryColor = 15,
                    PearlescentColor = 0,
                    InteriorColor = 16,
                    DashboardColor = 127,
                    WheelColor = 120,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 32 },
                        new VehicleMod() { ID = 25, Output = 8 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 28, Output = 2 },
                        new VehicleMod() { ID = 30, Output = 0 },
                        new VehicleMod() { ID = 31, Output = 3 },
                        new VehicleMod() { ID = 32, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 3 },
                        new VehicleMod() { ID = 34, Output = 5 },
                        new VehicleMod() { ID = 35, Output = 18 },
                        new VehicleMod() { ID = 37, Output = 3 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "MINIVAN2_Marabunta_PB",
                ModelName = "MINIVAN2",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 70,
                RequiredSecondaryColorID = 2,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 70,
                    SecondaryColor = 2,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 127,
                    WheelColor = 70,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 17 },
                        new VehicleMod() { ID = 24, Output = 5 },
                        new VehicleMod() { ID = 25, Output = 1 },
                        new VehicleMod() { ID = 27, Output = 0 },
                        new VehicleMod() { ID = 28, Output = 2 },
                        new VehicleMod() { ID = 30, Output = 0 },
                        new VehicleMod() { ID = 31, Output = 3 },
                        new VehicleMod() { ID = 32, Output = 0 },
                        new VehicleMod() { ID = 33, Output = 4 },
                        new VehicleMod() { ID = 34, Output = 13 },
                        new VehicleMod() { ID = 35, Output = 13 },
                        new VehicleMod() { ID = 37, Output = 6 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            //Lowriders
            new DispatchableVehicle() {
                DebugName = "CHINO2_Marabunta_PB",
                ModelName = "CHINO2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 70,
                RequiredSecondaryColorID = 2,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 70,
                    SecondaryColor = 2,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 127,
                    WheelColor = 120,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },
                        new VehicleExtra() { ID = 3, IsTurnedOn = false },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 5 },
                        new VehicleMod() { ID = 27, Output = 5 },
                        new VehicleMod() { ID = 35, Output = 13 },
                        new VehicleMod() { ID = 37, Output = 4 },
                        new VehicleMod() { ID = 38, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 2 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 7 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "CHINO2_Marabunta_PB",
                ModelName = "CHINO2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 70,
                RequiredSecondaryColorID = 2,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 70,
                    SecondaryColor = 2,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 127,
                    WheelColor = 120,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false },
                        new VehicleExtra() { ID = 3, IsTurnedOn = true },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 5 },
                        new VehicleMod() { ID = 27, Output = 5 },
                        new VehicleMod() { ID = 35, Output = 13 },
                        new VehicleMod() { ID = 37, Output = 4 },
                        new VehicleMod() { ID = 38, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 2 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 4 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SABREGT2_Marabunta_PB",
                ModelName = "SABREGT2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 70,
                RequiredSecondaryColorID = 70,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 70,
                    SecondaryColor = 70,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 127,
                    WheelColor = 88,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 5 },
                        new VehicleMod() { ID = 27, Output = 7 },
                        new VehicleMod() { ID = 35, Output = 19 },
                        new VehicleMod() { ID = 36, Output = 1 },
                        new VehicleMod() { ID = 37, Output = 4 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 6 },
                        new VehicleMod() { ID = 40, Output = 3 },
                        new VehicleMod() { ID = 48, Output = 7 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "FACTION2_Marabunta_PB",
                ModelName = "FACTION2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 70,
                RequiredSecondaryColorID = 70,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 70,
                    SecondaryColor = 70,
                    PearlescentColor = 38,
                    InteriorColor = 0,
                    DashboardColor = 127,
                    WheelColor = 90,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 5 },
                        new VehicleMod() { ID = 27, Output = 1 },
                        new VehicleMod() { ID = 35, Output = 19 },
                        new VehicleMod() { ID = 48, Output = 4 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "VOODOO_Marabunta_PB",
                ModelName = "VOODOO",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 70,
                RequiredSecondaryColorID = 70,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 70,
                    SecondaryColor = 70,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 127,
                    WheelColor = 156,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 31 },
                        new VehicleMod() { ID = 24, Output = 4 },
                        new VehicleMod() { ID = 25, Output = 5 },
                        new VehicleMod() { ID = 27, Output = 5 },
                        new VehicleMod() { ID = 33, Output = 5 },
                        new VehicleMod() { ID = 35, Output = 18 },
                        new VehicleMod() { ID = 37, Output = 4 },
                        new VehicleMod() { ID = 38, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 1 },
                        new VehicleMod() { ID = 42, Output = 0 },
                        new VehicleMod() { ID = 43, Output = 0 },
                        new VehicleMod() { ID = 44, Output = 5 },
                        new VehicleMod() { ID = 45, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 6 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetDiablosVehicles()
    {
        DiablosVehicles = new List<DispatchableVehicle>() {
            // Base
            new DispatchableVehicle("stalion", 20, 20) { RequiredPrimaryColorID = 28,RequiredSecondaryColorID = 28,},

            // Custom
            // Van - Pickup Truck
            new DispatchableVehicle() {
                DebugName = "GBURRITO2_Diablos_PB",
                ModelName = "GBURRITO2",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 0,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "FIREBOLT_Diablos_PB",
                ModelName = "FIREBOLT",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 6, Output = 5 },
                        new VehicleMod() { ID = 7, Output = 7 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 14 },
                        new VehicleMod() { ID = 48, Output = 8 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "BUFFALO4_Diablos_PB",
                ModelName = "BUFFALO4",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 0,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 6 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "greenwood_Diablos_PB",
                ModelName = "greenwood",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 10 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 8 },
                        new VehicleMod() { ID = 42, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "stalion_Diablos_PB",
                ModelName = "stalion",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 1, IsTurnedOn = false },
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 15 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "tampa4_Diablos_PB",
                ModelName = "tampa4",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 4 },
                        new VehicleMod() { ID = 1, Output = 6 },
                        new VehicleMod() { ID = 2, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 6 },
                        new VehicleMod() { ID = 6, Output = 4 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 26 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "HERMES_Diablos_PB",
                ModelName = "HERMES",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 120,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 120,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                        new VehicleToggle() { ID = 22, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 3 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "gauntlet3_Diablos_PB",
                ModelName = "gauntlet3",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 3 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 12 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "GAUNTLET5_Diablos_PB",
                ModelName = "GAUNTLET5",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 120,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 120,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 134,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 9 },
                        new VehicleMod() { ID = 2, Output = 4 },
                        new VehicleMod() { ID = 3, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 4 },
                        new VehicleMod() { ID = 7, Output = 4 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 0 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 4 },
                        new VehicleMod() { ID = 28, Output = 4 },
                        new VehicleMod() { ID = 29, Output = 0 },
                        new VehicleMod() { ID = 30, Output = 3 },
                        new VehicleMod() { ID = 33, Output = 6 },
                        new VehicleMod() { ID = 35, Output = 5 },
                        new VehicleMod() { ID = 39, Output = 2 },
                        new VehicleMod() { ID = 44, Output = 2 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "gauntlet4_Diablos_PB",
                ModelName = "gauntlet4",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 28,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 28,
                    PearlescentColor = 29,
                    InteriorColor = 2,
                    DashboardColor = 0,
                    WheelColor = 0,
                    WheelType = 12,
                    WindowTint = 1,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 5 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 5 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 10 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            // Special
            new DispatchableVehicle() {
                DebugName = "BANSHEE3_Diablos_PB",
                ModelName = "BANSHEE3",
                AmbientSpawnChance = 45,
                WantedSpawnChance = 45,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 28,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 28,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 13,
                    DashboardColor = 111,
                    WheelColor = 0,
                    WheelType = 12,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 1 },
                    },
                },
                RequiresDLC = true,
            }
          };
    }
    private void SetVarriosVehicles()
    {
        VarriosVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("buccaneer", 20, 20){ RequiredPrimaryColorID = 68,RequiredSecondaryColorID = 68},
            // Custom
            //Lowriders
            new DispatchableVehicle() {
                DebugName = "BUCCANEER2_Varrios_PB",
                ModelName = "BUCCANEER2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 63,
                RequiredSecondaryColorID = 120,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 63,
                    SecondaryColor = 120,
                    PearlescentColor = 0,
                    InteriorColor = 156,
                    DashboardColor = 127,
                    WheelColor = 90,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },

                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 9 },
                        new VehicleMod() { ID = 27, Output = 5 },
                        new VehicleMod() { ID = 28, Output = 2 },
                        new VehicleMod() { ID = 33, Output = 9 },
                        new VehicleMod() { ID = 34, Output = 9 },
                        new VehicleMod() { ID = 35, Output = 18 },
                        new VehicleMod() { ID = 36, Output = 2 },
                        new VehicleMod() { ID = 37, Output = 6 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 1 },
                        new VehicleMod() { ID = 40, Output = 1 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BUCCANEER2_Varrios_PB",
                ModelName = "BUCCANEER2",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 63,
                RequiredSecondaryColorID = 120,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 63,
                    SecondaryColor = 120,
                    PearlescentColor = 0,
                    InteriorColor = 156,
                    DashboardColor = 127,
                    WheelColor = 90,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false },
                    },
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 25, Output = 9 },
                        new VehicleMod() { ID = 27, Output = 5 },
                        new VehicleMod() { ID = 28, Output = 2 },
                        new VehicleMod() { ID = 33, Output = 9 },
                        new VehicleMod() { ID = 34, Output = 9 },
                        new VehicleMod() { ID = 35, Output = 18 },
                        new VehicleMod() { ID = 36, Output = 2 },
                        new VehicleMod() { ID = 37, Output = 6 },
                        new VehicleMod() { ID = 38, Output = 3 },
                        new VehicleMod() { ID = 39, Output = 1 },
                        new VehicleMod() { ID = 40, Output = 1 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            // 4 Door
            new DispatchableVehicle() {
                DebugName = "tulip_Varrios_PB",
                ModelName = "tulip",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 63,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 63,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 2,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 17, IsTurnedOn = true },
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 Door
            new DispatchableVehicle() {
                DebugName = "vamos_Varrios_PB",
                ModelName = "vamos",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 63,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 63,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 2,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 11,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 4 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "PHOENIX_Varrios_PB",
                ModelName = "PHOENIX",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 63,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 63,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 2,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 12 },
                    },
                },
                RequiresDLC = false,
            },
            new DispatchableVehicle() {
                DebugName = "TAMPA_Varrios_PB",
                ModelName = "TAMPA",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 63,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 63,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 2,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 2 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 8 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "tampa4_Varrios_PB",
                ModelName = "tampa4",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 63,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 63,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 2,
                    DashboardColor = 156,
                    WheelColor = 0,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 4 },
                        new VehicleMod() { ID = 2, Output = 3 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 9 },
                        new VehicleMod() { ID = 8, Output = 1 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 10 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetYardiesVehicles()
    {
        YardiesVehicles = new List<DispatchableVehicle>()
        {
            //Base
             new DispatchableVehicle("virgo", 20, 20){ RequiredPrimaryColorID = 55,RequiredSecondaryColorID = 55 },//matte lime green
             new DispatchableVehicle("voodoo", 20, 20){ RequiredPrimaryColorID = 55,RequiredSecondaryColorID = 55 },//matte lime green
             new DispatchableVehicle("voodoo2", 20, 20){ RequiredPrimaryColorID = 55,RequiredSecondaryColorID = 55 },//matte lime green
            // Custom
            //4 door
            new DispatchableVehicle() {
                DebugName = "eudora_Yardies_PB",
                ModelName = "eudora",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 92,
                RequiredSecondaryColorID = 92,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 92,
                    SecondaryColor = 92,
                    PearlescentColor = 92,
                    InteriorColor = 159,
                    DashboardColor = 55,
                    WheelColor = 0,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 17 },
                        new VehicleMod() { ID = 48, Output = 7 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "impaler6_Yardies_PB",
                ModelName = "impaler6",
                AmbientSpawnChance = 65,
                WantedSpawnChance = 65,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 92,
                RequiredSecondaryColorID = 92,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 92,
                    SecondaryColor = 92,
                    PearlescentColor = 92,
                    InteriorColor = 158,
                    DashboardColor = 55,
                    WheelColor = 0,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 5 },
                        new VehicleMod() { ID = 2, Output = 5 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 6, Output = 6 },
                        new VehicleMod() { ID = 7, Output = 1 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 15, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 4 },
                        new VehicleMod() { ID = 48, Output = 7 },
                    },
                },
                RequiresDLC = true,
            },
            // 2 door
            new DispatchableVehicle() {
                DebugName = "VIRGO2_Yardies_PB",
                ModelName = "VIRGO2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 92,
                RequiredSecondaryColorID = 0,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 92,
                    SecondaryColor = 0,
                    PearlescentColor = 92,
                    InteriorColor = 158,
                    DashboardColor = 55,
                    WheelColor = 0,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 30 },
                        new VehicleMod() { ID = 27, Output = 0 },
                        new VehicleMod() { ID = 28, Output = 15 },
                        new VehicleMod() { ID = 30, Output = 2 },
                        new VehicleMod() { ID = 33, Output = 10 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 43, Output = 0 },
                        new VehicleMod() { ID = 44, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "TORNADO5_Yardies_PB",
                ModelName = "TORNADO5",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 92,
                RequiredSecondaryColorID = 37,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 92,
                    SecondaryColor = 37,
                    PearlescentColor = 92,
                    InteriorColor = 158,
                    DashboardColor = 55,
                    WheelColor = 0,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 20 },
                        new VehicleMod() { ID = 24, Output = 4 },
                        new VehicleMod() { ID = 27, Output = 8 },
                        new VehicleMod() { ID = 30, Output = 7 },
                        new VehicleMod() { ID = 33, Output = 9 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 37, Output = 2 },
                        new VehicleMod() { ID = 38, Output = 5 },
                        new VehicleMod() { ID = 39, Output = 4 },
                        new VehicleMod() { ID = 40, Output = 3 },
                        new VehicleMod() { ID = 42, Output = 3 },
                        new VehicleMod() { ID = 43, Output = 1 },
                        new VehicleMod() { ID = 45, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 6 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "VOODOO_Yardies_PB",
                ModelName = "VOODOO",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 92,
                RequiredSecondaryColorID = 158,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 92,
                    SecondaryColor = 158,
                    PearlescentColor = 92,
                    InteriorColor = 159,
                    DashboardColor = 55,
                    WheelColor = 0,
                    WheelType = 9,
                    WindowTint = 3,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 24 },
                        new VehicleMod() { ID = 24, Output = 4 },
                        new VehicleMod() { ID = 27, Output = 6 },
                        new VehicleMod() { ID = 30, Output = 4 },
                        new VehicleMod() { ID = 33, Output = 8 },
                        new VehicleMod() { ID = 34, Output = 2 },
                        new VehicleMod() { ID = 38, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 40, Output = 2 },
                        new VehicleMod() { ID = 42, Output = 2 },
                        new VehicleMod() { ID = 43, Output = 2 },
                        new VehicleMod() { ID = 45, Output = 2 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "BUCCANEER2_Yardies_PB",
                ModelName = "BUCCANEER2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 92,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 92,
                    SecondaryColor = 118,
                    PearlescentColor = 92,
                    InteriorColor = 158,
                    DashboardColor = 55,
                    WheelColor = 0,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false },
                        new VehicleExtra() { ID = 4, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 19 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 27, Output = 6 },
                        new VehicleMod() { ID = 30, Output = 7 },
                        new VehicleMod() { ID = 33, Output = 5 },
                        new VehicleMod() { ID = 36, Output = 3 },
                        new VehicleMod() { ID = 45, Output = 0 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "manana2_Yardies_PB",
                ModelName = "manana2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 2,
                RequiredPrimaryColorID = 92,
                RequiredSecondaryColorID = 37,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 92,
                    SecondaryColor = 37,
                    PearlescentColor = 92,
                    InteriorColor = 158,
                    DashboardColor = 55,
                    WheelColor = 0,
                    WheelType = 8,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = false },
                        new VehicleExtra() { ID = 3, IsTurnedOn = true },

                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 27 },
                        new VehicleMod() { ID = 24, Output = 3 },
                        new VehicleMod() { ID = 27, Output = 13 },
                        new VehicleMod() { ID = 30, Output = 7 },
                        new VehicleMod() { ID = 33, Output = 4 },
                        new VehicleMod() { ID = 39, Output = 3 },
                        new VehicleMod() { ID = 42, Output = 1 },
                        new VehicleMod() { ID = 45, Output = 1 },
                        new VehicleMod() { ID = 48, Output = 11 },
                    },
                },
                RequiresDLC = true,
            }
        };
    }
    private void SetLostVehicles()
    {
        LostVehicles = new List<DispatchableVehicle>()
        {
            //Base
            new DispatchableVehicle("daemon", 25, 25) { MaxOccupants = 1 },
            new DispatchableVehicle("slamvan2", 15, 15) { MaxOccupants = 2 },
            new DispatchableVehicle("gburrito", 15, 15) { MaxOccupants = 2 },
            //Custom
            // Van
            new DispatchableVehicle() {
                DebugName = "SURFER3_Lost_PB",
                ModelName = "SURFER3",
                AmbientSpawnChance = 15,
                WantedSpawnChance = 15,
                MaxOccupants = 4,
                RequiredPrimaryColorID = 12,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 12,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 0,
                    DashboardColor = 0,
                    WheelColor = 28,
                    WheelType = 1,
                    WindowTint = 3,
                    VehicleExtras = new List<VehicleExtra>() {
                        new VehicleExtra() { ID = 2, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 7 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 9 },
                        new VehicleMod() { ID = 48, Output = 7 },
                    },
                },
                RequiresDLC = true,
            },
            // Motorcycles
            new DispatchableVehicle() {
                DebugName = "CHIMERA_Lost_PB",
                ModelName = "CHIMERA",
                AmbientSpawnChance = 35,
                WantedSpawnChance = 35,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 12,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 12,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 147,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 3 },
                        new VehicleMod() { ID = 3, Output = 7 },
                        new VehicleMod() { ID = 4, Output = 4 },
                        new VehicleMod() { ID = 5, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 0 },
                        new VehicleMod() { ID = 8, Output = 7 },
                        new VehicleMod() { ID = 10, Output = 0 },
                        new VehicleMod() { ID = 23, Output = 21 },
                        new VehicleMod() { ID = 48, Output = 17 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "DAEMON2_Lost_PB",
                ModelName = "DAEMON2",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 21,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 21,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 147,
                    WheelType = 6,
                    VehicleToggles = new List<VehicleToggle>() {
                        new VehicleToggle() { ID = 18, IsTurnedOn = true },
                    },
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 1 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 3 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 6, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 5 },
                        new VehicleMod() { ID = 11, Output = 3 },
                        new VehicleMod() { ID = 12, Output = 2 },
                        new VehicleMod() { ID = 13, Output = 2 },
                        new VehicleMod() { ID = 16, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 50 },
                        new VehicleMod() { ID = 24, Output = 50 },
                        new VehicleMod() { ID = 48, Output = 5 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "WOLFSBANE_Lost_PB",
                ModelName = "WOLFSBANE",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 21,
                RequiredSecondaryColorID = 21,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 21,
                    SecondaryColor = 21,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 112,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 9, Output = 1 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 25 },
                        new VehicleMod() { ID = 24, Output = 25 },
                        new VehicleMod() { ID = 48, Output = 14 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "WOLFSBANE_Lost2_PB",
                ModelName = "WOLFSBANE",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 0,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 0,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 112,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 2 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 1 },
                        new VehicleMod() { ID = 4, Output = 5 },
                        new VehicleMod() { ID = 7, Output = 3 },
                        new VehicleMod() { ID = 8, Output = 6 },
                        new VehicleMod() { ID = 10, Output = 6 },
                        new VehicleMod() { ID = 23, Output = 21 },
                        new VehicleMod() { ID = 24, Output = 21 },
                        new VehicleMod() { ID = 48, Output = 3 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "SANCTUS_Lost_PB",
                ModelName = "SANCTUS",
                AmbientSpawnChance = 55,
                WantedSpawnChance = 55,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 13,
                RequiredSecondaryColorID = 5,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 13,
                    SecondaryColor = 5,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 73,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 0 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 4 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 10, Output = 1 },
                        new VehicleMod() { ID = 23, Output = 68 },
                        new VehicleMod() { ID = 24, Output = 68 },
                        new VehicleMod() { ID = 48, Output = 2 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "ZOMBIEB_Lost_PB",
                ModelName = "ZOMBIEB",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 12,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 12,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 147,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 0 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 7 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 7, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 4 },
                        new VehicleMod() { ID = 10, Output = 4 },
                        new VehicleMod() { ID = 23, Output = 22 },
                        new VehicleMod() { ID = 24, Output = 22 },
                        new VehicleMod() { ID = 48, Output = 0 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "ZOMBIEA_Lost_PB",
                ModelName = "ZOMBIEA",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 12,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 12,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 147,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 7 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 0 },
                        new VehicleMod() { ID = 4, Output = 1 },
                        new VehicleMod() { ID = 5, Output = 1 },
                        new VehicleMod() { ID = 8, Output = 5 },
                        new VehicleMod() { ID = 10, Output = 6 },
                        new VehicleMod() { ID = 23, Output = 8 },
                        new VehicleMod() { ID = 24, Output = 9 },
                        new VehicleMod() { ID = 48, Output = 11 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "AVARUS_Lost_PB",
                ModelName = "AVARUS",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 12,
                RequiredSecondaryColorID = 12,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 12,
                    SecondaryColor = 12,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 2,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 3 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 3, Output = 2 },
                        new VehicleMod() { ID = 4, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 2 },
                        new VehicleMod() { ID = 23, Output = 21 },
                        new VehicleMod() { ID = 24, Output = 21 },
                        new VehicleMod() { ID = 48, Output = 15 },
                    },
                },
                RequiresDLC = true,
            },
            new DispatchableVehicle() {
                DebugName = "AVARUS_Lost2_PB",
                ModelName = "AVARUS",
                AmbientSpawnChance = 75,
                WantedSpawnChance = 75,
                MaxOccupants = 1,
                RequiredPrimaryColorID = 131,
                RequiredSecondaryColorID = 118,
                RequiredVariation = new VehicleVariation() {
                    PrimaryColor = 131,
                    SecondaryColor = 118,
                    PearlescentColor = 0,
                    InteriorColor = 111,
                    DashboardColor = 111,
                    WheelColor = 120,
                    WheelType = 6,
                    VehicleMods = new List<VehicleMod>() {
                        new VehicleMod() { ID = 0, Output = 11 },
                        new VehicleMod() { ID = 1, Output = 1 },
                        new VehicleMod() { ID = 2, Output = 0 },
                        new VehicleMod() { ID = 3, Output = 5 },
                        new VehicleMod() { ID = 4, Output = 2 },
                        new VehicleMod() { ID = 5, Output = 2 },
                        new VehicleMod() { ID = 8, Output = 0 },
                        new VehicleMod() { ID = 10, Output = 3 },
                        new VehicleMod() { ID = 23, Output = 11 },
                        new VehicleMod() { ID = 24, Output = 11 },
                        new VehicleMod() { ID = 48, Output = 11 },
                    },
                },
                RequiresDLC = true,
            }
        };

    }


    public DispatchableVehicle Create_GangSentinel5(int ambientPercent, int wantedPercent, GangVehicleType gangVehicleType, int minWantedLevel, int maxWantedLevel, int minOccupants, int maxOccupants,
    string requiredPedGroup, string groupName, bool useOptionalColors, int requiredColor, int requiredPearlescent, int requiredDashColor, int requiredInteriorColor, int requiredWheelColor, int wheelType, int windowTint, bool requiresDLC)
    {
        DispatchableVehicle toReturn = new DispatchableVehicle(GangSentinel5, ambientPercent, wantedPercent);
        if (gangVehicleType == GangVehicleType.Gang1) // Clean
        {

            toReturn.VehicleMods = new List<DispatchableVehicleMod>() {

                    new DispatchableVehicleMod(0,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(2,100),
                        },
                    },
                    new DispatchableVehicleMod(1,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(2,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(7,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(8,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(9,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(4,100),
                        },
                    },
                    new DispatchableVehicleMod(10,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(23,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(31,100),
                        },
                    },
            };
        }
        else if (gangVehicleType == GangVehicleType.Gang2) // STD Setup
        {
            toReturn.VehicleMods = new List<DispatchableVehicleMod>() {

                    new DispatchableVehicleMod(0,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(5,100),
                        },
                    },
                    new DispatchableVehicleMod(2,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(2,100),
                        },
                    },
                    new DispatchableVehicleMod(3,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(4,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(3,100),
                        },
                    },
                    new DispatchableVehicleMod(7,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,100),
                        },
                    },
                    new DispatchableVehicleMod(8,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(9,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(10,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(3,100),
                        },
                    },
                    new DispatchableVehicleMod(23,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(26,100),
                        },
                    },
            };
        }
        else if (gangVehicleType == GangVehicleType.Gang3) //Sports
        {
            toReturn.VehicleMods = new List<DispatchableVehicleMod>() {

                    new DispatchableVehicleMod(0,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(7,100),
                        },
                    },
                    new DispatchableVehicleMod(1,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,100),
                        },
                    },
                    new DispatchableVehicleMod(2,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(3,100),
                        },
                    },
                    new DispatchableVehicleMod(3,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(4,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(3,100),
                        },
                    },
                    new DispatchableVehicleMod(6,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(2,100),
                        },
                    },
                    new DispatchableVehicleMod(7,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(2,100),
                        },
                    },
                    new DispatchableVehicleMod(8,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(9,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(3,100),
                        },
                    },
                    new DispatchableVehicleMod(10,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(5,100),
                        },
                    },
                    new DispatchableVehicleMod(23,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(16,100),
                        },
                    },
                    new DispatchableVehicleMod(42,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,100),
                        },
                    },
            };
        }
        else if (gangVehicleType == GangVehicleType.Gang4) // Racer
        {
            toReturn.VehicleMods = new List<DispatchableVehicleMod>() {

                    new DispatchableVehicleMod(0,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(8,32),
                            new DispatchableVehicleModValue(10,33),
                            new DispatchableVehicleModValue(11,35),
                        },
                    },
                    new DispatchableVehicleMod(1,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(2,100),
                        },
                    },
                    new DispatchableVehicleMod(2,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(6,100),
                        },
                    },
                    new DispatchableVehicleMod(3,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(2,100),
                        },
                    },
                    new DispatchableVehicleMod(4,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(3,100),
                        },
                    },
                    new DispatchableVehicleMod(5,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(2,100),
                        },
                    },
                    new DispatchableVehicleMod(6,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,100),
                        },
                    },
                    new DispatchableVehicleMod(7,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(3,100),
                        },
                    },
                    new DispatchableVehicleMod(8,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(0,100),
                        },
                    },
                    new DispatchableVehicleMod(9,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,100),
                        },
                    },
                    new DispatchableVehicleMod(10,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(7,100),
                        },
                    },
                    new DispatchableVehicleMod(23,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(20,100),
                        },
                    },
                    new DispatchableVehicleMod(42,100)
                    {
                        DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
                        {
                            new DispatchableVehicleModValue(1,100),
                        },
                    },
            };
        }

        SetDefault(toReturn, minWantedLevel, maxWantedLevel, -1, -1, requiredPedGroup, groupName, useOptionalColors, requiredColor, requiredPearlescent, requiredDashColor, requiredInteriorColor, requiredWheelColor, wheelType, windowTint, requiresDLC);
        return toReturn;
         }

    private void SetDefault(DispatchableVehicle toSetup, int minWantedLevel, int maxWantedLevel, int minOccupants, int maxOccupants,
    string requiredPedGroup, string groupName ,bool useOptionalColors, int requiredColor, int requiredPearlescent, int requiredDashColor, int requiredInteriorColor, int requiredWheelColor, int wheelType ,int windowTint, bool requiresDLC)
    {
        if (toSetup == null)
        {
            return;
        }
        if (minWantedLevel != -1)
        {
            toSetup.MinWantedLevelSpawn = minWantedLevel;
        }
        if (maxWantedLevel != -1)
        {
            toSetup.MaxWantedLevelSpawn = maxWantedLevel;
        }
        if (minOccupants != -1)
        {
            toSetup.MinOccupants = minOccupants;
        }
        if (maxOccupants != -1)
        {
            toSetup.MaxOccupants = maxOccupants;
        }
        if (requiredPedGroup != "")
        {
            toSetup.RequiredPedGroup = requiredPedGroup;
        }
        if (groupName != "")
        {
            toSetup.GroupName = groupName;
        }
        if (useOptionalColors)
        {
            toSetup.OptionalColors = DefaultOptionalColors.ToList();
        }
        if (requiredColor != -1)
        {
            toSetup.RequiredPrimaryColorID = requiredColor;
            toSetup.RequiredSecondaryColorID = requiredColor; // might split these to allow for different color variations later
        }
        if (requiredPearlescent != -1)
        {
            toSetup.RequiredPearlescentColorID = requiredPearlescent;
        }
        if (requiredDashColor != -1)
        {
            toSetup.RequiredDashColorID = requiredDashColor;
        }
        if (requiredInteriorColor != -1)
        {
            toSetup.RequiredInteriorColorID = requiredInteriorColor;
        }
        if (requiredWheelColor != -1)
        {
            toSetup.RequiredWheelColorID = requiredWheelColor;
        }
        if (wheelType != -1)
        {
            toSetup.WheelType = wheelType;
        }
        if (windowTint != -1)
        {
            toSetup.RequiredWindowTintID = windowTint;
        }
        if (requiresDLC != false)
        { 
            toSetup.RequiresDLC = requiresDLC;
        }
    }

    //
    //
    // The following are newer versions of the Lost MC bikes.
    // They are kept here for now in case the need to revert to this method.
    // They also sucked.
    //
    //new DispatchableVehicle()
    //{
    //    DebugName = "DAEMON2_Lost_PB",
    //            ModelName = "DAEMON2",
    //            AmbientSpawnChance = 75,
    //            WantedSpawnChance = 75,
    //            MaxOccupants = 1,
    //            RequiredPrimaryColorID = 21,
    //            RequiredSecondaryColorID = 118,
    //            RequiredPearlescentColorID = 0,
    //            WheelType = 6,
    //            SetRandomCustomization = true,
    //            RandomCustomizationPercentage = 100f,
    //            VehicleMods = new List<DispatchableVehicleMod>()
    //            {
    //                new DispatchableVehicleMod(50,100) // front wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(21,100),

    //                    },
    //                },
    //                new DispatchableVehicleMod(50,100) // rear wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(21,100),

    //                    },
    //                },
    //            },
    //            RequiresDLC = true,
    //        },
    //        new DispatchableVehicle()
    //{
    //    DebugName = "WOLFSBANE_Lost_PB",
    //            ModelName = "WOLFSBANE",
    //            AmbientSpawnChance = 75,
    //            WantedSpawnChance = 75,
    //            MaxOccupants = 1,
    //            RequiredPrimaryColorID = 12,
    //            RequiredSecondaryColorID = 12,
    //            RequiredPearlescentColorID = 0,
    //            WheelType = 6,
    //            SetRandomCustomization = true,
    //            RandomCustomizationPercentage = 100f,
    //            VehicleMods = new List<DispatchableVehicleMod>()
    //            {
    //                new DispatchableVehicleMod(23,100) // front wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(21,100),

    //                    },
    //                },
    //                new DispatchableVehicleMod(24,100) // rear wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(21,100),

    //                    },
    //                },
    //            },
    //            RequiresDLC = true,
    //        },
    //        new DispatchableVehicle()
    //{
    //    DebugName = "SANCTUS_Lost_PB", 
    //            ModelName = "SANCTUS",
    //            AmbientSpawnChance = 55,
    //            WantedSpawnChance = 55,
    //            MaxOccupants = 1,
    //            RequiredPrimaryColorID = 13,
    //            RequiredSecondaryColorID = 5,
    //            RequiredPearlescentColorID = 0,
    //            WheelType = 6,
    //            RequiredWheelColorID = 147,
    //            SetRandomCustomization = true,
    //            RandomCustomizationPercentage = 100f,
    //            VehicleMods = new List<DispatchableVehicleMod>()
    //            {
    //                new DispatchableVehicleMod(10,100) //spawns ugly rib cage
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {
    //                        new DispatchableVehicleModValue(0,95),
    //                        new DispatchableVehicleModValue(1,95),
    //                        new DispatchableVehicleModValue(2,95),
    //                        new DispatchableVehicleModValue(3,95),
    //                        new DispatchableVehicleModValue(4,95),
    //                    },
    //                },
    //                new DispatchableVehicleMod(23,100) // front wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(68,100),

    //                    },
    //                },
    //                new DispatchableVehicleMod(24,100) // rear wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(68,100),

    //                    },
    //                },
    //            },
    //            RequiresDLC = true,
    //        },
    //        new DispatchableVehicle()
    //{
    //    DebugName = "ZOMBIEB_Lost_PB",
    //            ModelName = "ZOMBIEB",
    //            AmbientSpawnChance = 75,
    //            WantedSpawnChance = 75,
    //            MaxOccupants = 1,
    //            RequiredPrimaryColorID = 12,
    //            RequiredSecondaryColorID = 118,
    //            RequiredPearlescentColorID = 0,
    //            WheelType = 6,
    //            RequiredWheelColorID = 147,
    //            SetRandomCustomization = true,
    //            RandomCustomizationPercentage = 100f,
    //            VehicleMods = new List<DispatchableVehicleMod>()
    //            {
    //                new DispatchableVehicleMod(23,100) // front wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(22,100),

    //                    },
    //                },
    //                new DispatchableVehicleMod(24,100) // rear wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(22,100),

    //                    },
    //                },
    //            },  
    //            RequiresDLC = true,
    //        },
    //        new DispatchableVehicle()
    //{
    //    DebugName = "ZOMBIEA_Lost_PB",
    //            ModelName = "ZOMBIEA",
    //            AmbientSpawnChance = 75,
    //            WantedSpawnChance = 75,
    //            MaxOccupants = 1,
    //            RequiredPrimaryColorID = 12,
    //            RequiredSecondaryColorID = 118,
    //            RequiredPearlescentColorID = 0,
    //            WheelType = 6,
    //            RequiredWheelColorID = 147,
    //            SetRandomCustomization = true,
    //            RandomCustomizationPercentage = 100f,
    //            VehicleMods = new List<DispatchableVehicleMod>()
    //            {
    //                new DispatchableVehicleMod(23,100) // front wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(9,100),

    //                    },
    //                },
    //                new DispatchableVehicleMod(24,100) // rear wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(9,100),

    //                    },
    //                },
    //            },
    //            RequiresDLC = true,
    //        },
    //        new DispatchableVehicle()
    //{
    //    DebugName = "AVARUS_Lost_PB",
    //            ModelName = "AVARUS",
    //            AmbientSpawnChance = 75,
    //            WantedSpawnChance = 75,
    //            MaxOccupants = 1,
    //            RequiredPrimaryColorID = 12,
    //            RequiredSecondaryColorID = 12,
    //            RequiredPearlescentColorID = 0,
    //            WheelType = 6,
    //            SetRandomCustomization = true,
    //            RandomCustomizationPercentage = 100f,
    //            VehicleMods = new List<DispatchableVehicleMod>()
    //            {
    //                new DispatchableVehicleMod(23,100) // front wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(21,100),

    //                    },
    //                },
    //                new DispatchableVehicleMod(24,100) // rear wheels
    //                {
    //                    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {

    //                        new DispatchableVehicleModValue(21,100),

    //                    },
    //                },
    //            },
    //            RequiresDLC = true,
    //        },

    // 
    //
    // Performance Upgrades
    //
    //                 new DispatchableVehicleMod(11,100) // Engine
    //{
    //    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {
    //                        new DispatchableVehicleModValue(0,25),
    //                        new DispatchableVehicleModValue(1,25),
    //                        new DispatchableVehicleModValue(2,25),
    //                        new DispatchableVehicleModValue(3,25),
    //                    },
    //                },
    //                new DispatchableVehicleMod(12,100) //Brakes
    //{
    //    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {
    //                        new DispatchableVehicleModValue(0,33),
    //                        new DispatchableVehicleModValue(1,33),
    //                        new DispatchableVehicleModValue(2,34),
    //                    },
    //                },
    //                new DispatchableVehicleMod(13,100) // Transmission
    //{
    //    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {
    //                        new DispatchableVehicleModValue(0,33),
    //                        new DispatchableVehicleModValue(1,33),
    //                        new DispatchableVehicleModValue(2,34),
    //                    },
    //                },
    //                new DispatchableVehicleMod(15,100) // suspension
    //{
    //    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {
    //                        new DispatchableVehicleModValue(0,25),
    //                        new DispatchableVehicleModValue(1,25),
    //                        new DispatchableVehicleModValue(2,25),
    //                        new DispatchableVehicleModValue(3,25),
    //                    },
    //                },
    //                new DispatchableVehicleMod(16,100) // armor
    //{
    //    DispatchableVehicleModValues = new List<DispatchableVehicleModValue>()
    //                    {
    //                        new DispatchableVehicleModValue(0,20),
    //                        new DispatchableVehicleModValue(1,20),
    //                        new DispatchableVehicleModValue(2,20),
    //                        new DispatchableVehicleModValue(3,20),
    //                        new DispatchableVehicleModValue(4,20),
    //                    },
    //                },
    //
    //  Redneck Worn Colors
    //OptionalColors = new List<int>() { 21, 22, 23, 24, 25, 26, 46, 47, 48, 58, 59, 60, 85, 86, 87, 113, 114, 115, 116, 121, 123, 124, 126, 130, 132, 133 },
    //OptionalColors = new List<int>() { 21, 22, 24, 26, 46, 47, 59, 60, 86, 87, 113, 114, 116, 121, 123, 126, 132 },
}

