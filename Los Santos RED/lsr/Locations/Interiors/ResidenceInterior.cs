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
    public Dictionary<int, Rage.Object> SpawnedTrophies { get; set; } = new Dictionary<int, Rage.Object>();
    [XmlIgnore]
    public Dictionary<int, int> PlacedTrophies { get; set; } = new Dictionary<int, int>();
    public string MansionType { get; set; }
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
        PlacedTrophies = new Dictionary<int, int>();
    }
    public ResidenceInterior(int iD, string name) : base(iD, name)
    {
        PlacedTrophies = new Dictionary<int, int>();
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
        MansionType = newResidence.MansionType;
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
            test.MansionType = newResidence.MansionType;
        }
    }
    public override void AddLocation(PossibleInteriors interiorList)
    {
        interiorList.ResidenceInteriors.Add(this);
    }
    public virtual void Load(bool isOpen)
    {
        base.Load(isOpen);
        SpawnTrophies();
    }
    private void SpawnTrophies()
    {
        if (string.IsNullOrEmpty(MansionType) || !TrophyInteract.CabinetDatas.TryGetValue(MansionType, out CabinetData data))
        {
            return;
        }
        foreach (KeyValuePair<int, int> kvp in PlacedTrophies)
        {
            int slot = kvp.Key;
            int trophyID = kvp.Value;
            if (trophyID == 0)
            {
                continue;
            }
            TrophySlot ts = data.Slots.FirstOrDefault(x => x.SlotID == slot);
            if (ts == null)
            {
                continue;
            }
            if (!TrophyInteract.TrophyRegistry.TryGetValue(trophyID, out TrophyDefinition def))
            {
                continue;
            }
            uint modelHash = Game.GetHashKey(def.ModelName);
            NativeFunction.Natives.REQUEST_MODEL(modelHash);
            uint startTime = Game.GameTime;
            while (!NativeFunction.Natives.HAS_MODEL_LOADED<bool>(modelHash) && Game.GameTime - startTime < 5000)
            {
                GameFiber.Yield();
            }
            if (NativeFunction.Natives.HAS_MODEL_LOADED<bool>(modelHash))
            {
                Rage.Object newTrophy = new Rage.Object(modelHash, ts.Position, ts.Rotation);
                if (newTrophy.Exists())
                {
                    SpawnedTrophies[slot] = newTrophy;
                    SpawnedProps.Add(newTrophy);
                }
            }
        }
    }
}