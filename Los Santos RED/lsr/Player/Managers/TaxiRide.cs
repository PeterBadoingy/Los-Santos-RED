﻿using LosSantosRED.lsr.Interface;
using LSR.Vehicles;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TaxiRide
{
    private Vector3 InitialPickupLocation;
    private IEntityProvideable World;
    private ITaxiRideable Player;
    private Blip PickupBlip;
    private uint GameTimeArrivedAtPickup;
    private bool HasDonePickupItems;

    public TaxiRide(IEntityProvideable world, ITaxiRideable player, TaxiFirm requestedFirm, TaxiVehicleExt respondingVehicle, TaxiDriver respondingDriver, Vector3 pickupLocation)
    {
        World = world;
        Player = player;
        HasPickedUpPlayer = true;
        IsNearbyPickup = false;
        GameTimeArrivedAtPickup = Game.GameTime;
        RequestedFirm = requestedFirm;
        InitialPickupLocation = pickupLocation;
        RespondingVehicle = respondingVehicle;
        RespondingDriver = respondingDriver;
        TaxiDrivingStyle = new PedDrivingStyle("Normal", eCustomDrivingStyles.Taxi_StandardDrivingMode, 10f);
        PossibleTaxiDrivingStyles = new List<PedDrivingStyle>() {
            new PedDrivingStyle("Normal", eCustomDrivingStyles.Taxi_StandardDrivingMode, 10f),
            new PedDrivingStyle("Fast", eCustomDrivingStyles.TaxiRushed_AvoidCarsObeyLights, 42f) { Fee = RequestedFirm == null ? 0 : RequestedFirm.FastSpeedFee },
            new PedDrivingStyle("Crazy", eCustomDrivingStyles.TaxiCrazy_AvoidCars, 90f) { Fee = RequestedFirm == null ? 0 : RequestedFirm.CrazySpeedFee },
        };
        PickupLocation = new SpawnLocation();
        DestinationLocation = new SpawnLocation();
    }
    public TaxiRide(IEntityProvideable world, ITaxiRideable player, TaxiFirm requestedFirm, Vector3 pickupLocation)
    {
        World = world;
        Player = player;
        RequestedFirm = requestedFirm;
        InitialPickupLocation = pickupLocation;
        TaxiDrivingStyle = new PedDrivingStyle("Normal", eCustomDrivingStyles.Taxi_StandardDrivingMode, 10f);
        PossibleTaxiDrivingStyles = new List<PedDrivingStyle>() {
            new PedDrivingStyle("Normal", eCustomDrivingStyles.Taxi_StandardDrivingMode, 10f),
            new PedDrivingStyle("Fast", eCustomDrivingStyles.TaxiRushed_AvoidCarsObeyLights, 42f) { Fee = RequestedFirm == null ? 0 : RequestedFirm.FastSpeedFee },
            new PedDrivingStyle("Crazy", eCustomDrivingStyles.TaxiCrazy_AvoidCars, 90f) { Fee = RequestedFirm == null ? 0 : RequestedFirm.CrazySpeedFee },
        };
        PickupLocation = new SpawnLocation();
        DestinationLocation = new SpawnLocation();
    }
    public Vector3 CurrentDriveToPosition
    {
        get
        {
            if(!HasPickedUpPlayer && HasPickup)
            {
                return PickupLocation.StreetPosition;
            }
            else if (HasPickedUpPlayer && HasDestination)
            {
                return DestinationLocation.StreetPosition;
            }
            return Vector3.Zero;
        }
    }
    public float CurrentDriveToHeading
    {
        get
        {
            if (!HasPickedUpPlayer && HasPickup)
            {
                return PickupLocation.Heading;
            }
            else if (HasPickedUpPlayer && HasDestination)
            {
                return DestinationLocation.Heading;
            }
            return 0f;
        }
    }
    public float EstimatedDistance { get; set; }
    public float EstimatedDistanceMiles { get; set; }
    public List<PedDrivingStyle> PossibleTaxiDrivingStyles { get; private set; }
    public string DesitnationName { get; set; }
    public bool HasSetFast { get; set; } = false;
    public TaxiFirm RequestedFirm { get; set; }
    public SpawnLocation PickupLocation { get; set; }
    public TaxiVehicleExt RespondingVehicle { get; private set; }
    public TaxiDriver RespondingDriver { get; private set; }
    public SpawnLocation DestinationLocation { get; private set; }
    public PedDrivingStyle TaxiDrivingStyle { get; set; }
    public bool IsValid { get; private set; } = true;
    public bool IsActive { get; private set; } = false;
    public bool HasPickedUpPlayer { get; set; } = false;
    public bool HasDroppedOffPlayer { get; set; } = false;
    public bool HasArrivedAtDestination { get; set; } = false;
    public bool HasDestination => DestinationLocation != null && DestinationLocation.StreetPosition != Vector3.Zero;
    public bool HasPickup => PickupLocation != null && PickupLocation.StreetPosition != Vector3.Zero;

    public bool IsNearbyDestination { get; private set; }
    public bool IsNearbyPickup { get; private set; }

    public void Setup()
    {
        IsActive = false;
        PickupLocation = new SpawnLocation(InitialPickupLocation);
        DestinationLocation = new SpawnLocation();
        PickupLocation.GetClosestStreet(true);
        PickupLocation.GetClosestSideOfRoad();
        if (!PickupLocation.HasStreetPosition)
        {
            EntryPoint.WriteToConsole("TAXI RIDE SETUP FAIL NO STREET POSITION");
            return;
        }
        if (GetVehicleAndDriver())//if there is an existing one
        {
            IsActive = true;
            AddPickupBlip();
            //Player.GPSManager.AddGPSRoute("Taxi Pickup", PickupLocation.FinalPosition);
            return;
        }
        SpawnVehicleAndDriver();
        if (GetVehicleAndDriver())//if there is an existing one
        {
            IsActive = true;
            AddPickupBlip();
            return;
        }
        EntryPoint.WriteToConsole("TAXI RIDE SETUP FAIL NO DISPATCH");
    }
    public void Update()
    {
        if (RespondingVehicle == null || !RespondingVehicle.Vehicle.Exists())
        {
            IsValid = false;
            return;
        }
        if (RespondingDriver == null || !RespondingDriver.Pedestrian.Exists())
        {
            IsValid = false;
            return;
        }
        if (RespondingDriver.HasSeenPlayerCommitMajorCrime || RespondingDriver.Pedestrian.IsFleeing || Player.WantedLevel >= 3)
        {
            IsValid = false;
            return;
        }
        if (!HasPickedUpPlayer)
        {
            if (Player.CurrentVehicle != null && Player.CurrentVehicle.Handle == RespondingVehicle.Handle)
            {
                OnPickedUpPlayer();
            }
            float distanceToPickup = RespondingDriver.Position.DistanceTo2D(PickupLocation.StreetPosition);
            if(!IsNearbyPickup && distanceToPickup <= 20f)
            {
                OnArrivedAtPickup();
            }
            if(IsNearbyPickup && Game.GameTime - GameTimeArrivedAtPickup >= 5000 && !HasDonePickupItems)
            {
                OnWaitedAtPickup();
            }
        }
        if (!HasArrivedAtDestination && HasPickedUpPlayer && !HasDroppedOffPlayer && HasDestination)
        {
            float distanceToDestination = RespondingDriver.Position.DistanceTo2D(DestinationLocation.StreetPosition);
            if (distanceToDestination <= 20f)
            {
                OnArrivedAtDestination();
            }
            else if(!IsNearbyDestination && distanceToDestination <= 125f)
            {
                OnIsNearbyDestination();
            }
        }
    }
    private void OnWaitedAtPickup()
    {
        if (RespondingVehicle != null && RespondingVehicle.Vehicle.Exists())
        {
            NativeFunction.Natives.START_VEHICLE_HORN(RespondingVehicle.Vehicle, 3000, Game.GetHashKey("HELDDOWN"), 0);
        }
        HasDonePickupItems = true;
        EntryPoint.WriteToConsole("OnWaitedAtPickup RAN");
    }
    private void OnArrivedAtPickup()
    {
        DisplayNotification("~g~Pick Up Ready", $"Your driver is about to arrive at ~p~{DesitnationName}~s~ for the pickup. Please wait for the Taxi to come to a complete stop before entering.");
        IsNearbyPickup = true;
        EntryPoint.WriteToConsole("TAXI RIDE IS NEARBY PICKUP");
        GameTimeArrivedAtPickup = Game.GameTime;

    }

    private void OnIsNearbyDestination()
    {
        DisplayNotification("~g~Arriving", $"You are about to arrive at ~p~{DesitnationName}~s~. Please wait for the Taxi to come to a complete stop before exiting.");
        IsNearbyDestination = true;
        EntryPoint.WriteToConsole("TAXI RIDE IS NEARBY DESTINATION");
        SpawnLocation spawnLocation = new SpawnLocation(DestinationLocation.StreetPosition);
        spawnLocation.GetClosestStreet(false);
        spawnLocation.GetClosestSideOfRoad();
        if(spawnLocation.HasStreetPosition)
        {
            EntryPoint.WriteToConsole($"NEARBY DESTINATION UPDATED WAS {DestinationLocation.StreetPosition} NOW {spawnLocation.StreetPosition}");
            DestinationLocation.StreetPosition = spawnLocation.StreetPosition;
        }
        else
        {
            EntryPoint.WriteToConsole($"NEARBY DESTINATION UPDATED COULDNT FIND NEW POS");
        }

    }

    public void Cancel()
    {
        IsActive = false;
        if (RespondingDriver != null)
        {
            RespondingDriver.TaxiRide = null;
            RespondingDriver.ClearTasks(true);
            RespondingDriver.SetNonPersistent();
        }
        if (PickupBlip.Exists())
        {
            PickupBlip.Delete();
        }
        EntryPoint.WriteToConsole("TAXI RIDE HAS BEEN CANCELLED");
        // RespondingDriver?.ReleaseTasking();     
    }
    public void Dispose()
    {
        Cancel();
    }
    private void AddPickupBlip()
    {
        if (!HasPickedUpPlayer)
        {
            PickupBlip = new Blip(PickupLocation.FinalPosition) { Sprite = (BlipSprite)198, Scale = 0.5f };
            if (PickupBlip.Exists())
            {
                World.AddBlip(PickupBlip);
            }
        }
    }
    private void SpawnVehicleAndDriver()
    {
        EntryPoint.WriteToConsole("TAXI RIDE SETUP FORCING TAXI SPAWN");
        Player.Dispatcher.ForceTaxiSpawn(RequestedFirm);// Dispatcher.ForceTaxiSpawn(RequestedFirm);
    }
    private bool GetVehicleAndDriver()
    {
        RespondingVehicle = World.Vehicles.TaxiVehicles.Where(x => x.TaxiFirm.ID == RequestedFirm.ID && x.Vehicle.Exists() && x.Vehicle.HasDriver).OrderBy(x=> x.Vehicle.Position.DistanceTo2D(Player.Position)).FirstOrDefault();
        if(RespondingVehicle == null || !RespondingVehicle.Vehicle.Exists() || !RespondingVehicle.Vehicle.Driver.Exists())
        {
            return false;
        }
        uint driverhandle = RespondingVehicle.Vehicle.Driver.Handle;
        RespondingDriver = World.Pedestrians.TaxiDriverList.FirstOrDefault(x => x.Handle == driverhandle);
        if(RespondingDriver == null || !RespondingDriver.Pedestrian.Exists())
        {
            return false;
        }
        //RespondingDriver.SetTaskingActive(PickupLocation.StreetPosition);
        RespondingDriver.SetTaxiRide(this);
        return true;
    }

    private void OnArrivedAtDestination()
    {
        EntryPoint.WriteToConsole("TAXI RIDE PLAYER HAS ARRIVED");
        ChargePlayer();
        HasArrivedAtDestination = true;
        IsNearbyDestination = true;
        RespondingDriver?.PlaySpeech("TAXID_ARRIVE_AT_DEST",false);
    }
    private void ChargePlayer()
    {
        int fullFare = GetPrice(EstimatedDistanceMiles);
        if (fullFare > 0)
        {
            Player.BankAccounts.GiveMoney(-1 * fullFare, true);
            DisplayNotification("~g~Arrived", $"Total Price: ~r~${fullFare}~s~");
        }

    }

    private void OnPickedUpPlayer()
    {
        EntryPoint.WriteToConsole("TAXI RIDE PLAYER WAS PICKED UP");
        HasPickedUpPlayer = true;
        if (PickupBlip.Exists())
        {
            PickupBlip.Delete();
        }
        RespondingDriver?.PlaySpeech("TAXID_WHERE_TO", false);
    }
    public void UpdateDestination(Vector3 destinationCoordinates, Vector3 startCoordinates, string Name)
    {
        if(destinationCoordinates == Vector3.Zero)
        {
            return;
        }
        if (startCoordinates == Vector3.Zero)
        {
            return;
        }
        if (RespondingDriver == null)
        {
            return;
        }
        if(HasDestination && !HasArrivedAtDestination)
        {
            EntryPoint.WriteToConsole($"TAXI RIDE UPDATED DESTINATION ALREADY HAS DESTINATION CHARGING");
            int PartialPrice = GetPrice(startCoordinates.DistanceTo2D(Player.Position) * 0.000621371f);
            if(PartialPrice > 0)
            {
                Player.BankAccounts.GiveMoney(-1 * PartialPrice, true);
                DisplayNotification("~r~Destination Updated",$"Partial Ride Price: ~r~${PartialPrice}");
            }
        }
        else
        {
            DisplayNotification("~g~Destination Added", $"Added New Destination: {Name}");
        }
        PickupLocation = new SpawnLocation(startCoordinates);
        PickupLocation.StreetPosition = startCoordinates;
        DestinationLocation.StreetPosition = destinationCoordinates;
        EstimatedDistance = startCoordinates.DistanceTo2D(DestinationLocation.StreetPosition);
        EstimatedDistanceMiles = EstimatedDistance * 0.000621371f;
        DesitnationName = Name;
        HasArrivedAtDestination = false;
        IsNearbyDestination = false;
        EntryPoint.WriteToConsole($"TAXI RIDE UPDATED DESTINATION {destinationCoordinates}");
        RespondingDriver?.PlaySpeech("TAXID_CHANGE_DEST", false);
    }

    public int GetPrice(float distance)
    {
        if(RequestedFirm == null)
        {
            return 0;
        }
        return RequestedFirm.CalculateFare(distance);
    }
    public void SetActive()
    {
        IsActive = true;
    }
    public void OnGotOutOfVehicle()
    {
        if(!IsActive)
        {
            return;
        }
        if(HasArrivedAtDestination)
        {
            Cancel();
            return;
        }
        else 
        {
            RespondingDriver?.PlaySpeech("TAXID_GET_OUT_EARLY", false);
            Game.DisplayHelp("Return to the taxi to continue the ride.");
        }
    }

    public void DisplayNotification(string subtitle, string text)
    {
        if (string.IsNullOrEmpty(subtitle) || string.IsNullOrEmpty(text))
        {
            return;
        }
        string texture = "CHAR_BLANK_ENTRY";
        string title = "Taxi Company";
        if (RequestedFirm != null)
        {
            title = RequestedFirm.ShortName;
            if (RequestedFirm.PhoneContact != null)
            {
                texture = RequestedFirm.PhoneContact.IconName;
            }
        }
        Game.DisplayNotification(texture, texture, title, subtitle, text);
    }
}

