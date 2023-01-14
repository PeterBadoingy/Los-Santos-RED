﻿using System.ComponentModel;

public class PoliceSpawnSettings : ISettingsDefaultable
{
    [Description("Allows mod spawning of police in the world. (Not recommended to disable)")]
    public bool ManageDispatching { get; set; }
    [Description("Attach a blip to any spawned police pedestrian")]
    public bool ShowSpawnedBlips { get; set; }
    [Description("Enable of disable removing all police peds not spawned by LSR.")]
    public bool RemoveNonSpawnedPolice { get; set; }
    [Description("Enable of disable removing all police peds not spawned by LSR that are non persistent.")]
    public bool RemoveAmbientPolice { get; set; }
    [Description("Percentage of time to add optional passenegers to a vehicle. 0 is never 100 is always.")]
    public float AddOptionalPassengerPercentage { get; set; }
    [Description("Percentage of time to spawn foot patrol officers (when possible). 0 is never 100 is always. WIP")]
    public float PedestrianSpawnPercentage { get; set; }
    [Description("Enable or disable ambient spawns around police stations.")]
    public bool AllowStationSpawning { get; set; }
    [Description("Maximum wanted level to spawn ambient peds and vehicles around the station.")]
    public int StationSpawning_MaxWanted { get; set; }
    [Description("If enabled, police stations ambient spawns ignore the ped and vehicle spawn limits. Use with StationSpawning_MaxWanted of 1 or 2 to allow ambient spawning, but not overload ped limits when in a serious chase.")]
    public bool StationSpawningIgnoresLimits { get; set; }
    [Description("Maximum distance (in meters) that police can spawn when you are wanted and seen by police.")]
    public float MaxDistanceToSpawn_WantedSeen { get; set; }
    [Description("Maximum distance (in meters) that police can spawn when you are wanted and not seen by police.")]
    public float MaxDistanceToSpawn_WantedUnseen { get; set; }
    [Description("Maximum distance (in meters) that police can spawn when you not wanted.")]
    public float MaxDistanceToSpawn_NotWanted { get; set; }



    [Description("Minimum distance (in meters) that police can spawn when you are wanted and not seen by police.")]
    public float MinDistanceToSpawn_WantedUnseen { get; set; }
    [Description("Minimum distance (in meters) that police can spawn when you are wanted and seen by police.")]
    public float MinDistanceToSpawn_WantedSeen { get; set; }

    [Description("Decrease min distance (in meters) that police can spawn for each wanted level when you are wanted and not seen by the police. A value of 40 with a wanted level of 3 would be (MinDistanceToSpawn_WantedUnseen - (3 * 40))")]
    public float MinDistanceToSpawn_WantedUnseenScalar { get; set; }
    [Description("Decrease min distance (in meters) that police can spawn for each wanted level when you are wanted and seen by police. A value of 40 with a wanted level of 3 would be (MinDistanceToSpawn_WantedUnseen - (3 * 40))")]
    public float MinDistanceToSpawn_WantedSeenScalar { get; set; }




    [Description("Minimum distance (in meters) that police can spawn when you are not wanted.")]
    public float MinDistanceToSpawn_NotWanted { get; set; }
    [Description("Time (in ms) between cop spawns when you are not seen.")]
    public int TimeBetweenCopSpawn_Unseen { get; set; }
    [Description("Minimum time (in ms) between cop spawns when you are seen by police.")]
    public int TimeBetweenCopSpawn_Seen_Min { get; set; }
    [Description("Decreased time (in ms) between cop spawns when you are seen as you increase your wanted level. Formula: ((6 - WantedLevel) * TimeBetweenCopSpawn_Seen_AdditionalTimeScaler) + TimeBetweenCopSpawn_Seen_Min;")]
    public int TimeBetweenCopSpawn_Seen_AdditionalTimeScaler { get; set; }
    [Description("Time (in ms) between cops despawning when you are unseen.")]
    public int TimeBetweenCopDespawn_Unseen { get; set; }
    [Description("Minimum time (in ms) between cop despawns when you are seen by police.")]
    public int TimeBetweenCopDespawn_Seen_Min { get; set; }
    [Description("Decreased time (in ms) between cop despawns when you are seen as you increase your wanted level. Formula: ((6 - WantedLevel) * TimeBetweenCopDespawn_Seen_AdditionalTimeScaler) + TimeBetweenCopDespawn_Seen_Min;")]
    public int TimeBetweenCopDespawn_Seen_AdditionalTimeScaler { get; set; }


    [Description("Maximum police peds that can be spawned when you are not wanted and no investigation is active.")]
    public int PedSpawnLimit_Default { get; set; }
    [Description("Maximum police peds that can be spawned when you are not wanted and an investigation is active.")]
    public int PedSpawnLimit_Investigation { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 1.")]
    public int PedSpawnLimit_Wanted1 { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 2.")]
    public int PedSpawnLimit_Wanted2 { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 3.")]
    public int PedSpawnLimit_Wanted3 { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 4.")]
    public int PedSpawnLimit_Wanted4 { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 5.")]
    public int PedSpawnLimit_Wanted5 { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 6.")]
    public int PedSpawnLimit_Wanted6 { get; set; }


    [Description("Maximum police peds that can be spawned when you are at wanted level 7.")]
    public int PedSpawnLimit_Wanted7 { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 8.")]
    public int PedSpawnLimit_Wanted8 { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 9.")]
    public int PedSpawnLimit_Wanted9 { get; set; }
    [Description("Maximum police peds that can be spawned when you are at wanted level 10.")]
    public int PedSpawnLimit_Wanted10 { get; set; }



    [Description("Maximum police vehicles that can be spawned when you are not wanted and no investigation is active.")]
    public int VehicleSpawnLimit_Default { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are not wanted and an investigation is active.")]
    public int VehicleSpawnLimit_Investigation { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 1.")]
    public int VehicleSpawnLimit_Wanted1 { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 2.")]
    public int VehicleSpawnLimit_Wanted2 { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 3.")]
    public int VehicleSpawnLimit_Wanted3 { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 4.")]
    public int VehicleSpawnLimit_Wanted4 { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 5.")]
    public int VehicleSpawnLimit_Wanted5 { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 6.")]
    public int VehicleSpawnLimit_Wanted6 { get; set; }

    [Description("Maximum police vehicles that can be spawned when you are at wanted level 7.")]
    public int VehicleSpawnLimit_Wanted7 { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 8.")]
    public int VehicleSpawnLimit_Wanted8 { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 9.")]
    public int VehicleSpawnLimit_Wanted9 { get; set; }
    [Description("Maximum police vehicles that can be spawned when you are at wanted level 10.")]
    public int VehicleSpawnLimit_Wanted10 { get; set; }


    [Description("Maximum police boats that can be spawned when you are not wanted and no investigation is active.")]
    public int BoatSpawnLimit_Default { get; set; }
    [Description("Maximum police boats that can be spawned when you are not wanted and an investigation is active.")]
    public int BoatSpawnLimit_Investigation { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 1.")]
    public int BoatSpawnLimit_Wanted1 { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 2.")]
    public int BoatSpawnLimit_Wanted2 { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 3.")]
    public int BoatSpawnLimit_Wanted3 { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 4.")]
    public int BoatSpawnLimit_Wanted4 { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 5.")]
    public int BoatSpawnLimit_Wanted5 { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 6.")]
    public int BoatSpawnLimit_Wanted6 { get; set; }

    [Description("Maximum police boats that can be spawned when you are at wanted level 7.")]
    public int BoatSpawnLimit_Wanted7 { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 8.")]
    public int BoatSpawnLimit_Wanted8 { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 9.")]
    public int BoatSpawnLimit_Wanted9 { get; set; }
    [Description("Maximum police boats that can be spawned when you are at wanted level 10.")]
    public int BoatSpawnLimit_Wanted10 { get; set; }


    [Description("Maximum police helicopters that can be spawned when you are not wanted and no investigation is active.")]
    public int HeliSpawnLimit_Default { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are not wanted and an investigation is active.")]
    public int HeliSpawnLimit_Investigation { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 1.")]
    public int HeliSpawnLimit_Wanted1 { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 2.")]
    public int HeliSpawnLimit_Wanted2 { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 3.")]
    public int HeliSpawnLimit_Wanted3 { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 4.")]
    public int HeliSpawnLimit_Wanted4 { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 5.")]
    public int HeliSpawnLimit_Wanted5 { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 6.")]
    public int HeliSpawnLimit_Wanted6 { get; set; }

    [Description("Maximum police helicopters that can be spawned when you are at wanted level 7.")]
    public int HeliSpawnLimit_Wanted7 { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 8.")]
    public int HeliSpawnLimit_Wanted8 { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 9.")]
    public int HeliSpawnLimit_Wanted9 { get; set; }
    [Description("Maximum police helicopters that can be spawned when you are at wanted level 10.")]
    public int HeliSpawnLimit_Wanted10 { get; set; }



    [Description("Percentage of time to spawn foot patrol police when near a police station. 0 is never, 100 is always. Inactive Setting.")]
    public int PercentageSpawnOnFootNearStation { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when not wanted. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Default { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when not wanted. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Default { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 1 star. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted1 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 1 star. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted1 { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 2 stars. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted2 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 2 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted2 { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 3 stars. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted3 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 3 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted3 { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 4 stars. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted4 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 4 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted4 { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 5 star. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted5 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 5 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted5 { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 6 star. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted6 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 6 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted6 { get; set; }



    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 7 star. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted7 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 7 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted7 { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 8 star. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted8 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 8 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted8 { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 9 star. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted9 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 9 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted9 { get; set; }
    [Description("Percentage of time to allow spawning a random agency (that can spawn in the given location) instead of the main assigned jurisdiction when at 10 star. Allows agencies without territory to spawn randomly. 0 is never 100 is always.")]
    public int LikelyHoodOfAnySpawn_Wanted10 { get; set; }
    [Description("Percentage of time to allow spawning the county assigned jurisdiction when at 10 stars. Allows the possibility of county agencies to spawn when in a location with zone based jurisdiction. 0 is never 100 is always.")]
    public int LikelyHoodOfCountySpawn_Wanted10 { get; set; }


    public PoliceSpawnSettings()
    {
        SetDefault();


    }
    public void SetDefault()
    {

        ManageDispatching = true;
     
        PedSpawnLimit_Default = 7;
        PedSpawnLimit_Investigation = 8;
        PedSpawnLimit_Wanted1 = 9;
        PedSpawnLimit_Wanted2 = 10;
        PedSpawnLimit_Wanted3 = 16;
        PedSpawnLimit_Wanted4 = 20;
        PedSpawnLimit_Wanted5 = 24;
        PedSpawnLimit_Wanted6 = 26;

        PedSpawnLimit_Wanted7 = 26;
        PedSpawnLimit_Wanted8 = 26;
        PedSpawnLimit_Wanted9 = 26;
        PedSpawnLimit_Wanted10 = 26;

        VehicleSpawnLimit_Default = 9;
        VehicleSpawnLimit_Investigation = 10;
        VehicleSpawnLimit_Wanted1 = 11;
        VehicleSpawnLimit_Wanted2 = 12;
        VehicleSpawnLimit_Wanted3 = 13;
        VehicleSpawnLimit_Wanted4 = 15;
        VehicleSpawnLimit_Wanted5 = 16;
        VehicleSpawnLimit_Wanted6 = 18;

        VehicleSpawnLimit_Wanted7 = 18;
        VehicleSpawnLimit_Wanted8 = 18;
        VehicleSpawnLimit_Wanted9 = 18;
        VehicleSpawnLimit_Wanted10 = 18;

        BoatSpawnLimit_Default = 0;
        BoatSpawnLimit_Investigation = 0;
        BoatSpawnLimit_Wanted1 = 0;
        BoatSpawnLimit_Wanted2 = 0;
        BoatSpawnLimit_Wanted3 = 1;
        BoatSpawnLimit_Wanted4 = 1;
        BoatSpawnLimit_Wanted5 = 1;
        BoatSpawnLimit_Wanted6 = 1;

        BoatSpawnLimit_Wanted7 = 1;
        BoatSpawnLimit_Wanted8 = 1;
        BoatSpawnLimit_Wanted9 = 1;
        BoatSpawnLimit_Wanted10 = 1;

        HeliSpawnLimit_Default = 0;
        HeliSpawnLimit_Investigation = 0;
        HeliSpawnLimit_Wanted1 = 0;
        HeliSpawnLimit_Wanted2 = 0;
        HeliSpawnLimit_Wanted3 = 1;
        HeliSpawnLimit_Wanted4 = 1;
        HeliSpawnLimit_Wanted5 = 2;
        HeliSpawnLimit_Wanted6 = 2;

        HeliSpawnLimit_Wanted7 = 2;
        HeliSpawnLimit_Wanted8 = 2;
        HeliSpawnLimit_Wanted9 = 2;
        HeliSpawnLimit_Wanted10 = 2;

        MaxDistanceToSpawn_WantedSeen = 550f;
        MaxDistanceToSpawn_WantedUnseen = 350f;
        MaxDistanceToSpawn_NotWanted = 900f;
        MinDistanceToSpawn_WantedUnseen = 250f;
        MinDistanceToSpawn_WantedSeen = 400f;
        MinDistanceToSpawn_NotWanted = 150f;//350f;

        MinDistanceToSpawn_WantedUnseenScalar = 40f;
        MinDistanceToSpawn_WantedSeenScalar = 40f;



        TimeBetweenCopSpawn_Unseen = 3000;
        TimeBetweenCopSpawn_Seen_Min = 2000;
        TimeBetweenCopSpawn_Seen_AdditionalTimeScaler = 2000;
        TimeBetweenCopDespawn_Unseen = 2000;
        TimeBetweenCopDespawn_Seen_Min = 1000;
        TimeBetweenCopDespawn_Seen_AdditionalTimeScaler = 1000;

        AddOptionalPassengerPercentage = 75f;
        PedestrianSpawnPercentage = 50f;
        PercentageSpawnOnFootNearStation = 50;

        LikelyHoodOfAnySpawn_Default = 5;
        LikelyHoodOfCountySpawn_Default = 5;
        LikelyHoodOfAnySpawn_Wanted1 = 5;// 5;
        LikelyHoodOfCountySpawn_Wanted1 = 5;
        LikelyHoodOfAnySpawn_Wanted2 = 5;
        LikelyHoodOfCountySpawn_Wanted2 = 5;
        LikelyHoodOfAnySpawn_Wanted3 = 5;// 10;
        LikelyHoodOfCountySpawn_Wanted3 = 10;
        LikelyHoodOfAnySpawn_Wanted4 = 5;//20;
        LikelyHoodOfCountySpawn_Wanted4 = 20;
        LikelyHoodOfAnySpawn_Wanted5 = 5;//20;
        LikelyHoodOfCountySpawn_Wanted5 = 20;
        LikelyHoodOfAnySpawn_Wanted6 = 5;//20;
        LikelyHoodOfCountySpawn_Wanted6 = 20;

        LikelyHoodOfAnySpawn_Wanted7 = 5;
        LikelyHoodOfCountySpawn_Wanted7 = 20;
        LikelyHoodOfAnySpawn_Wanted8 = 5;
        LikelyHoodOfCountySpawn_Wanted8 = 20;
        LikelyHoodOfAnySpawn_Wanted9 = 5;
        LikelyHoodOfCountySpawn_Wanted9 = 20;
        LikelyHoodOfAnySpawn_Wanted10 = 5;
        LikelyHoodOfCountySpawn_Wanted10 = 20;

        RemoveNonSpawnedPolice = false;
        RemoveAmbientPolice = false;
#if DEBUG
        ShowSpawnedBlips = true;
#else
#endif
        AllowStationSpawning = true;
        StationSpawning_MaxWanted = 2;
        StationSpawningIgnoresLimits = true;
    }
}