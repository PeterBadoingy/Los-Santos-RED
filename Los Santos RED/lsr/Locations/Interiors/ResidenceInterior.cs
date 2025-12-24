using Rage;
using Rage.Native;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

public class ResidenceInterior : Interior
{
    protected Residence residence;
    public Residence Residence => residence;
    public List<RestInteract> RestInteracts { get; set; } = new List<RestInteract>();
    public List<InventoryInteract> InventoryInteracts { get; set; } = new List<InventoryInteract>();
    public List<OutfitInteract> OutfitInteracts { get; set; } = new List<OutfitInteract>();
    public List<TrophyInteract> TrophyInteracts { get; set; } = new List<TrophyInteract>();
    [XmlIgnore]
    public override List<InteriorInteract> AllInteractPoints
    {
        get
        {
            List<InteriorInteract> AllInteracts = new List<InteriorInteract>();
            AllInteracts.AddRange(InteractPoints);
            AllInteracts.AddRange(RestInteracts);
            AllInteracts.AddRange(InventoryInteracts);
            AllInteracts.AddRange(OutfitInteracts);
            AllInteracts.AddRange(TrophyInteracts);
            return AllInteracts;
        }
    }
    public ResidenceInterior()
    {

    }
    public ResidenceInterior(int iD, string name) : base(iD, name)
    {

    }
    protected override void LoadDoors(bool isOpen, bool reLockForcedEntry)
    {
        if (isOpen && Residence != null && Residence.IsOwnedOrRented)
        {
            foreach (InteriorDoor door in Doors)
            {
                door.UnLockDoor();
            }
        }
        else
        {
            if (reLockForcedEntry)
            {
                foreach (InteriorDoor door in Doors.Where(x => x.LockWhenClosed))
                {
                    door.LockDoor();
                }
            }
            else
            {
                foreach (InteriorDoor door in Doors.Where(x => x.LockWhenClosed && !x.HasBeenForcedOpen))
                {
                    door.LockDoor();
                }
            }
        }
    }
    public void SetResidence(Residence newResidence)
    {
        residence = newResidence;
        MansionLoc = newResidence.MansionLoc;
        foreach (RestInteract test in RestInteracts)
        {
            test.RestableLocation = newResidence;
        }
        foreach (InventoryInteract test in InventoryInteracts)
        {
            test.InventoryableLocation = newResidence;
        }
        foreach (OutfitInteract test in OutfitInteracts)
        {
            test.OutfitableLocation = newResidence;
        }
        foreach (TrophyInteract test in TrophyInteracts)
        {
            test.MansionLoc = newResidence.MansionLoc;
        }
        SavedPlacedTrophies.Clear();

        if (newResidence.TrophyPlacements != null && newResidence.TrophyPlacements.Any())
        {
            foreach (var tp in newResidence.TrophyPlacements)
            {
                SavedPlacedTrophies.Add(new TrophyPlacement
                {
                    SlotID = tp.SlotID,
                    TrophyID = tp.TrophyID
                });
            }

            EntryPoint.WriteToConsole(
                $"ResidenceInterior: Loaded {SavedPlacedTrophies.Count} saved trophies from residence '{newResidence.Name}'");
        }
    }
    public override void AddLocation(PossibleInteriors interiorList)
    {
        interiorList.ResidenceInteriors.Add(this);
    }
    public void SyncTrophiesToResidence()
    {
        if (residence == null) return;

        // Clear previous saved trophies in the Residence
        residence.TrophyPlacements.Clear();

        // Copy all currently placed trophies from the interior to the Residence
        foreach (var tp in SavedPlacedTrophies)
        {
            residence.TrophyPlacements.Add(new TrophyPlacement
            {
                SlotID = tp.SlotID,
                TrophyID = tp.TrophyID
            });
        }

        EntryPoint.WriteToConsole($"ResidenceInterior: Synced {SavedPlacedTrophies.Count} trophies to Residence '{residence.Name}'");
    }
}