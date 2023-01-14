﻿using LosSantosRED.lsr.Interface;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Dispatcher
{
    private readonly IAgencies Agencies;
    private readonly IDispatchable Player;
    private readonly ISettingsProvideable Settings;
    private readonly IStreets Streets;
    private readonly IEntityProvideable World;
    private readonly IJurisdictions Jurisdictions;
    private readonly IZones Zones;
    private LEDispatcher LEDispatcher;
    private EMSDispatcher EMSDispatcher;
    private FireDispatcher FireDispatcher;
    private ZombieDispatcher ZombieDispatcher;
    private SecurityDispatcher SecurityDispatcher;
    private GangDispatcher GangDispatcher;
    private IWeapons Weapons;
    private INameProvideable Names;
    //private List<RandomHeadData> RandomHeadList;

    private ICrimes Crimes;
    private IPedGroups PedGroups;
    private IGangs Gangs;
    private IGangTerritories GangTerritories;
    private IShopMenus ShopMenus;
    private IPlacesOfInterest PlacesOfInterest;
    private bool hasLocationDispatched;

    public Dispatcher(IEntityProvideable world, IDispatchable player, IAgencies agencies, ISettingsProvideable settings, IStreets streets, IZones zones, IJurisdictions jurisdictions, IWeapons weapons, INameProvideable names, ICrimes crimes, IPedGroups pedGroups, IGangs gangs, IGangTerritories gangTerritories, IShopMenus shopMenus, IPlacesOfInterest placesOfInterest)
    {
        Player = player;
        World = world;
        Agencies = agencies;
        Settings = settings;
        Streets = streets;
        Zones = zones;
        Jurisdictions = jurisdictions;
        Weapons = weapons;
        Names = names;
        Crimes = crimes;
        Gangs = gangs;
        PedGroups = pedGroups;
        GangTerritories = gangTerritories;
        ShopMenus = shopMenus;
        PlacesOfInterest = placesOfInterest;
    }
    public void Setup()
    {
        LEDispatcher = new LEDispatcher(World, Player, Agencies, Settings, Streets, Zones, Jurisdictions, Weapons, Names, PlacesOfInterest);
        EMSDispatcher = new EMSDispatcher(World, Player, Agencies, Settings, Streets, Zones, Jurisdictions, Weapons, Names, PlacesOfInterest);
        SecurityDispatcher = new SecurityDispatcher(World, Player, Agencies, Settings, Streets, Zones, Jurisdictions, Weapons, Names, PlacesOfInterest);
        FireDispatcher = new FireDispatcher(World, Player, Agencies, Settings, Streets, Zones, Jurisdictions, Weapons, Names, PlacesOfInterest);
        ZombieDispatcher = new ZombieDispatcher(World, Player, Settings, Streets, Zones, Jurisdictions, Weapons, Names, Crimes);
        GangDispatcher = new GangDispatcher(World, Player, Gangs, Settings, Streets, Zones, GangTerritories, Weapons, Names, PedGroups, Crimes, ShopMenus, PlacesOfInterest);
    }
    public void Dispatch()
    {
        if(Player.IsCustomizingPed)
        {
            return;
        }
        if (!LEDispatcher.Dispatch())
        {
            if (!EMSDispatcher.Dispatch())
            {
                if(!FireDispatcher.Dispatch())
                {
                    if(!SecurityDispatcher.Dispatch())
                    {

                    }
                }
            }
        }
        GangDispatcher.Dispatch();
        if (World.IsZombieApocalypse)
        {
            GameFiber.Yield();
            ZombieDispatcher.Dispatch();
        }
        LocationDispatch();
    }
    public void LocationDispatch()
    {
        if (Player.Respawning.WasRecentlyTeleported && !hasLocationDispatched)
        {
            LEDispatcher.LocationDispatch();
            GameFiber.Yield();
            EMSDispatcher.LocationDispatch();
            GameFiber.Yield();
            FireDispatcher.LocationDispatch();
            GameFiber.Yield();
            GangDispatcher.LocationDispatch();
            GameFiber.Yield();
            SecurityDispatcher.LocationDispatch();
            GameFiber.Yield();
            hasLocationDispatched = true;
        }
        else
        {
            hasLocationDispatched = false;
        }
    }
    public void Recall()
    {
        LEDispatcher.Recall();
        EMSDispatcher.Recall();
        FireDispatcher.Recall();
        SecurityDispatcher.Recall();
        if (World.IsZombieApocalypse)
        {
            GameFiber.Yield();
            ZombieDispatcher.Recall();
        }
        GangDispatcher.Recall();
    }
    public void Dispose()
    {
        LEDispatcher.Dispose();
    }
    public void DebugSpawnRoadblock(float distance)
    {
        LEDispatcher.SpawnRoadblock(true, distance);
    }
    public void DebugRemoveRoadblock()
    {
        LEDispatcher.RemoveRoadblock();

        World.Vehicles.ClearSpawned(true);
        World.Pedestrians.ClearSpawned();
    }
    public void DebugSpawnCop()
    {
        LEDispatcher.DebugSpawnCop("",false, false);
    }
    public void DebugSpawnCop(string agencyID, bool onFoot, bool isEmpty)
    {
        LEDispatcher.DebugSpawnCop(agencyID,onFoot, isEmpty);
    }
    public void DebugSpawnGang()
    {
        GangDispatcher.DebugSpawnGangMember("",false);
    }
    public void DebugSpawnGang(string agencyID, bool onFoot)
    {
        GangDispatcher.DebugSpawnGangMember(agencyID, onFoot);
    }
    public void DebugSpawnEMT(string agencyID, bool onFoot, bool isEmpty)
    {
        EMSDispatcher.DebugSpawnEMT(agencyID, onFoot, isEmpty);
    }

    public void DebugSpawnSecurityGuard(string agencyID, bool onFoot, bool isEmpty)
    {
        SecurityDispatcher.DebugSpawnSecurity(agencyID, onFoot, isEmpty);
    }
}

