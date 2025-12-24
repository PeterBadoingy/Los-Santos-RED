using LosSantosRED.lsr.Interface;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SavedResidence : SavedGameLocation
{
    public SavedResidence()
    {
    }

    public SavedResidence(string name, bool isOwnedByPlayer, bool isRentedByPlayer)
    {
        Name = name;
        IsOwnedByPlayer = isOwnedByPlayer;
        IsRentedByPlayer = isRentedByPlayer;
    }

    public bool IsRentedByPlayer { get; set; } = false;
    public bool IsOwnedByPlayer { get; set; }
    public DateTime RentalPaymentDate { get; set; }
    public DateTime DateOfLastRentalPayment { get; set; }
    public List<StoredWeapon> WeaponInventory { get; set; } = new List<StoredWeapon>();
    public List<InventorySave> InventoryItems { get; set; } = new List<InventorySave>();
    public List<TrophyPlacement> TrophyPlacements { get; set; } = new List<TrophyPlacement>();
    public int StoredCash { get; set; }

    public override void LoadSavedData(IInventoryable player, IPlacesOfInterest placesOfInterest, IModItems modItems, ISettingsProvideable settings, IEntityProvideable world)
    {
        if (!(IsOwnedByPlayer || IsRentedByPlayer))
            return;

        Residence savedPlace = placesOfInterest.PossibleLocations.Residences
            .FirstOrDefault(x => x.Name == Name && x.IsCorrectMap(world.IsMPMapLoaded));

        if (savedPlace == null)
            return;

        // Add the location to the player's owned properties
        player.Properties.AddOwnedLocation(savedPlace);

        // Set ownership/rental data
        savedPlace.IsOwned = IsOwnedByPlayer;
        savedPlace.IsRented = IsRentedByPlayer;
        savedPlace.DateRentalPaymentDue = RentalPaymentDate;
        savedPlace.DateRentalPaymentPaid = DateOfLastRentalPayment;

        // Initialize inventory if null
        if (savedPlace.WeaponStorage == null)
            savedPlace.WeaponStorage = new WeaponStorage(settings);

        if (savedPlace.SimpleInventory == null)
            savedPlace.SimpleInventory = new SimpleInventory(settings);

        // Load weapons
        foreach (StoredWeapon storedWeap in WeaponInventory)
            savedPlace.WeaponStorage.StoredWeapons.Add(storedWeap.Copy());

        // Load inventory items
        foreach (InventorySave stest in InventoryItems)
            savedPlace.SimpleInventory.Add(modItems.Get(stest.ModItemName), stest.RemainingPercent);

        // Load stored cash
        savedPlace.CashStorage.StoredCash = StoredCash;

        // Handle interior & trophies
        if (savedPlace.ResidenceInterior != null)
        {
            var interior = savedPlace.ResidenceInterior;

            // Clear previous trophies/props
            interior.RemoveSpawnedProps();
            interior.PlacedTrophies.Clear();
            interior.SavedPlacedTrophies.Clear();

            // Set interior references
            interior.SetResidence(savedPlace);

            // Load trophies from save
            interior.SavedPlacedTrophies = TrophyPlacements.ToList();
            foreach (TrophyPlacement tp in interior.SavedPlacedTrophies)
                interior.PlacedTrophies[tp.SlotID] = tp.TrophyID;

            // Load interior and spawn trophies asynchronously
            interior.Load(true);

            GameFiber.StartNew(delegate
            {
                // Wait until the interior is valid
                while (interior.InternalID == 0)
                {
                    GameFiber.Yield();
                }

                interior.SpawnTrophies();
            }, "Spawn Saved Trophies");
        }

        // Refresh UI
        savedPlace.RefreshUI();
    }


}

