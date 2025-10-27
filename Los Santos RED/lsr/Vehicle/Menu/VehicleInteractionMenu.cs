﻿using LSR.Vehicles;
using Rage;
using RAGENativeUI.Elements;
using RAGENativeUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosSantosRED.lsr.Interface;

public class VehicleInteractionMenu
{
    protected VehicleExt VehicleExt;
    protected MenuPool MenuPool;
    protected UIMenu VehicleInteractMenu;
    protected VehicleDoorSeatData VehicleDoorSeatData;
    protected IInteractionable Player;
    public bool IsShowingMenu { get; set; } = false;
    public VehicleInteractionMenu(VehicleExt vehicleExt)
    {
        VehicleExt = vehicleExt;
    }
    public virtual void ShowInteractionMenu(IInteractionable player, IWeapons weapons, IModItems modItems, VehicleDoorSeatData vehicleDoorSeatData, IVehicleSeatAndDoorLookup vehicleSeatDoorData, IEntityProvideable world, ISettingsProvideable settings, bool showDefault,
        IPlacesOfInterest placesOfInterest, ITimeReportable time)
    {
        VehicleDoorSeatData = vehicleDoorSeatData;
        Player = player;

        if (VehicleExt == null || !VehicleExt.Vehicle.Exists())
        {
            EntryPoint.WriteToConsole("SHOW INTERACTION MENU: VehicleExt is null or Vehicle does not exist");
            return;
        }

        CreateInteractionMenu();
        EntryPoint.WriteToConsole($"SHOW INTERACTION MENU: Created interaction menu, IsInVehicle={player.IsInVehicle}, IsBoat={VehicleExt.IsBoat}");
        if (!player.IsInVehicle)
        {
            VehicleExt.VehicleBodyManager.CreateInteractionMenu(MenuPool, VehicleInteractMenu, vehicleSeatDoorData, world);
            EntryPoint.WriteToConsole("SHOW INTERACTION MENU: Added VehicleBody menu");
        }
        UIMenu InventoryWeaponHeaderMenu = MenuPool.AddSubMenu(VehicleInteractMenu, "Inventory, Cash, and Weapons");
        VehicleInteractMenu.MenuItems[VehicleInteractMenu.MenuItems.Count() - 1].Description = "Manage Stored Inventory, Cash, and Weapons. Place items, cash, or weapons within storage, or retrieve them for use.";
        InventoryWeaponHeaderMenu.SetBannerType(EntryPoint.LSRedColor);
        EntryPoint.WriteToConsole($"SHOW INTERACTION MENU: Added Inventory menu with LSRedColor=R={EntryPoint.LSRedColor.R},G={EntryPoint.LSRedColor.G},B={EntryPoint.LSRedColor.B}");
        InventoryWeaponHeaderMenu.OnMenuOpen += (sender) =>
        {
            vehicleDoorSeatData = VehicleExt.GetClosestPedStorageBone(player, 5.0f, vehicleSeatDoorData);
            if (vehicleDoorSeatData == null || player.IsInVehicle)
            {
                return;
            }
            player.ActivityManager.SetDoor(vehicleDoorSeatData.DoorID, true, false, VehicleExt);
        };
        InventoryWeaponHeaderMenu.OnMenuClose += (sender) =>
        {
            if (vehicleDoorSeatData == null || player.IsInVehicle)
            {
                return;
            }
            player.ActivityManager.SetDoor(vehicleDoorSeatData.DoorID, false, false, VehicleExt);
        };

        if (player.IsInVehicle && !VehicleExt.IsBoat)
        {
            UIMenu WindowAccessHeaderMenu = MenuPool.AddSubMenu(VehicleInteractMenu, "Windows");
            VehicleInteractMenu.MenuItems[VehicleInteractMenu.MenuItems.Count() - 1].Description = "Open/Close various windows";
            WindowAccessHeaderMenu.SetBannerType(EntryPoint.LSRedColor);
            EntryPoint.WriteToConsole($"SHOW INTERACTION MENU: Added Windows menu with LSRedColor=R={EntryPoint.LSRedColor.R},G={EntryPoint.LSRedColor.G},B={EntryPoint.LSRedColor.B}");
            VehicleExt.CreateWindowInteractionMenu(player, MenuPool, WindowAccessHeaderMenu, vehicleSeatDoorData);
        }
        if (!player.IsInVehicle && !VehicleExt.IsBoat)
        {
            UIMenu DoorAccessHeaderMenu = MenuPool.AddSubMenu(VehicleInteractMenu, "Doors");
            VehicleInteractMenu.MenuItems[VehicleInteractMenu.MenuItems.Count() - 1].Description = "Open/Close various doors";
            DoorAccessHeaderMenu.SetBannerType(EntryPoint.LSRedColor);
            EntryPoint.WriteToConsole($"SHOW INTERACTION MENU: Added Doors menu with LSRedColor=R={EntryPoint.LSRedColor.R},G={EntryPoint.LSRedColor.G},B={EntryPoint.LSRedColor.B}");
            VehicleExt.CreateDoorInteractionMenu(player, MenuPool, DoorAccessHeaderMenu, vehicleSeatDoorData);
        }
        if (VehicleExt.IsBoat)
        {
            EntryPoint.WriteToConsole($"SHOW INTERACTION MENU: Skipped Windows/Doors menu due to IsBoat={VehicleExt.IsBoat}");
        }

        VehicleExt.CreateAnchorInteractionMenu(MenuPool, VehicleInteractMenu, player);
        EntryPoint.WriteToConsole($"SHOW INTERACTION MENU: Added Anchor menu, IsDriver={Game.LocalPlayer.Character.IsInVehicle(VehicleExt.Vehicle, true)}");

        VehicleExt.HandleRandomItems(modItems);
        VehicleExt.HandleRandomWeapons(modItems, weapons);
        VehicleExt.HandleRandomCash();
        VehicleExt.SimpleInventory.CreateInteractionMenu(player, MenuPool, InventoryWeaponHeaderMenu, !player.IsInVehicle, null, null, false, null, null);
        VehicleExt.WeaponStorage.CreateInteractionMenu(player, MenuPool, InventoryWeaponHeaderMenu, weapons, modItems, !player.IsInVehicle, false);
        VehicleExt.CashStorage.CreateInteractionMenu(player, MenuPool, InventoryWeaponHeaderMenu, null, !player.IsInVehicle, false);
        EntryPoint.WriteToConsole("SHOW INTERACTION MENU: Added Inventory, Weapons, Cash menus");

        VehicleInteractMenu.Visible = true;
        IsShowingMenu = true;
        Player.ButtonPrompts.RemovePrompts("VehicleInteract");
        EntryPoint.WriteToConsole("SHOW INTERACTION MENU: Menu set to visible");
        ProcessMenu();
    }
    protected virtual void CreateInteractionMenu()
    {
        MenuPool = new MenuPool();
        VehicleInteractMenu = new UIMenu("Vehicle", "Select an Option");
        VehicleInteractMenu.SetBannerType(EntryPoint.LSRedColor);
        MenuPool.Add(VehicleInteractMenu);     
    }
    protected virtual void ProcessMenu()
    {
        GameFiber.StartNew(delegate
        {
            try
            {
                while (EntryPoint.ModController.IsRunning && Player.IsAliveAndFree && MenuPool.IsAnyMenuOpen() && VehicleExt.Vehicle.Exists() &&
                       VehicleExt.Vehicle.Speed <= (VehicleExt.IsBoat ? 3.0f : 0.5f) && VehicleExt.Vehicle.DistanceTo2D(Game.LocalPlayer.Character) <= 7f)
                {
                    MenuPool.ProcessMenus();
                    GameFiber.Yield();
                }
                //if(VehicleDoorSeatData != null)
                //{
                //    Player.ActivityManager.SetDoor(VehicleDoorSeatData.DoorID, true, false);
                //}
                IsShowingMenu = false;
            }
            catch (Exception ex)
            {
                EntryPoint.WriteToConsole(ex.Message + " " + ex.StackTrace, 0);
                EntryPoint.ModController.CrashUnload();
            }
        }, "VehicleInteraction");
    }
}

