using LosSantosRED.lsr.Interface;
using Rage;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

public class RaidLocation : GameLocation, IAssaultSpawnable
{
    public RaidLocation(Vector3 _EntrancePosition, float _EntranceHeading, string _Name, string _Description) : base(_EntrancePosition, _EntranceHeading, _Name, _Description)
    {
        IsBlipEnabled = false; // Ensure it does not spawn immediately
    }
    public RaidLocation() : base()
    {

    }

    public override bool ShowsOnDirectory { get; set; } = false;
    public override bool ShowsOnTaxi { get; set; } = false;
    public override string TypeName { get; set; } = "Raid Location";
    public override int MapIcon { get; set; } = (int)BlipSprite.BountyHit2;
    public int MaxAssaultSpawns { get; set; } = 15;
    public List<SpawnPlace> AssaultSpawnLocations { get; set; }
    public bool RestrictAssaultSpawningUsingPedSpawns { get; set; } = false;
    public float AssaultSpawnHeavyWeaponsPercent { get; set; } = 80f;

    [XmlIgnore]
    public bool IsRaidMissionActive { get; private set; } = false;
    [XmlIgnore]
    public bool HasRaidStarted { get; private set; } = false;

    public override bool CanCurrentlyInteract(ILocationInteractable player)
    {
        ButtonPromptText = $"Enter {Name}";
        return IsRaidMissionActive;
    }

    public override void OnInteract()
    {
        if (!IsRaidMissionActive)
        {
            Game.DisplayHelp($"{Name} is only available during a raid.");
            return;
        }
        HasRaidStarted = true;
        base.OnInteract();
    }

    public void SetRaidMissionActive(bool isActive)
    {
        IsRaidMissionActive = isActive;
        IsBlipEnabled = isActive;
        TotalAssaultSpawns = 0;
        if (!isActive)
        {
            HasRaidStarted = false;
            IsPlayerInterestedInLocation = false;

            if (this.Blip != null && this.Blip.Exists())
            {
                this.Blip.Delete();
            }

            if (Interior != null)
            {
                Interior.CleanupAbandonedTeleportInterior();
            }
        }
    }

    [OnDeserialized()]
    private void SetValuesOnDeserialized(StreamingContext context)
    {
        if (MaxAssaultSpawns == 0)
        {
            MaxAssaultSpawns = 15;
        }
        if (AssaultSpawnHeavyWeaponsPercent == 0f)
        {
            AssaultSpawnHeavyWeaponsPercent = 80f;
        }
    }

    public override void AddLocation(PossibleLocations possibleLocations)
    {
        possibleLocations.RaidLocations.Add(this);
        base.AddLocation(possibleLocations);
    }
}