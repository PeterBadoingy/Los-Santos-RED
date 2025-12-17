using LosSantosRED.lsr.Interface;
using Rage;
using Rage.Native;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

public class ElevatorInteract : InteriorInteract
{
    [XmlIgnore]
    public IElevatorableLocation ElevatorableLocation { get; set; }

    private Floor nearestFloorCache;

    public class Floor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public float Heading { get; set; }
        public float? GroundZ { get; set; }

        public Floor() { }

        public Floor(int id, string name, Vector3 position, float heading)
        {
            ID = id;
            Name = name;
            Position = position;
            Heading = heading;
        }
    }

    public List<Floor> Floors { get; set; } = new List<Floor>();

    public ElevatorInteract()
    {
        ButtonPromptText = "Use Elevator";
        ShouldHideMarker = false;
    }

    public override void UpdateDistances(IInteractionable player)
    {
        base.UpdateDistances(player);

        nearestFloorCache = null;
        distanceTo = float.MaxValue;
        canAddPrompt = false;

        if (Floors == null || Floors.Count == 0 || player == null)
            return;

        float closestDistance = float.MaxValue;

        foreach (Floor floor in Floors)
        {
            float dist = player.Character.DistanceTo(floor.Position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                nearestFloorCache = floor;
            }
        }

        distanceTo = closestDistance;
        canAddPrompt = distanceTo <= InteractDistance;
    }

    public override bool ShouldAddPrompt =>
        !Interior.IsMenuInteracting &&
        canAddPrompt &&
        !Player.ActivityManager.IsInteracting &&
        Player.ActivityManager.CanPerformActivitiesOnFoot;

    public override void AddPrompt()
    {
        if (Player == null || !canAddPrompt)
            return;

        Player.ButtonPrompts.AttemptAddPrompt(
            Name,
            ButtonPromptText,
            Name,
            Settings.SettingsManager.KeySettings.InteractStart,
            999);
    }

    public override void RemovePrompt()
    {
        Player?.ButtonPrompts.RemovePrompt(Name);
    }

    public override void DisplayMarker(int markerType, float zOffset, float markerScale)
    {
        if (ShouldHideMarker || Floors == null || Player == null)
            return;

        foreach (Floor floor in Floors)
        {
            if (Player.Character.DistanceTo(floor.Position) >= 30f)
                continue;

            if (!floor.GroundZ.HasValue)
            {
                float groundZ;
                NativeFunction.Natives.GET_GROUND_Z_FOR_3D_COORD(
                    floor.Position.X,
                    floor.Position.Y,
                    floor.Position.Z + 1f,
                    out groundZ,
                    false);

                floor.GroundZ = groundZ;
            }

            NativeFunction.Natives.DRAW_MARKER(
                markerType,
                floor.Position.X,
                floor.Position.Y,
                floor.GroundZ.Value + zOffset,
                0f, 0f, 0f,
                0f, 0f, 0f,
                markerScale, markerScale, markerScale,
                EntryPoint.LSRedColor.R,
                EntryPoint.LSRedColor.G,
                EntryPoint.LSRedColor.B,
                EntryPoint.LSRedColor.A,
                false, false, 2, true, 0, 0, false);
        }
    }

    public override void OnInteract()
    {
        if (nearestFloorCache == null)
            return;

        Interior.IsMenuInteracting = true;
        Interior?.RemoveButtonPrompts();
        RemovePrompt();

        try
        {
            if (!TestFloorAccessibility(nearestFloorCache))
            {
                Game.DisplayHelp("Access Failed");
                return;
            }

            Player.InteriorManager.OnStartedInteriorInteract();
            ShowElevatorMenu();
            Player.InteriorManager.OnEndedInteriorInteract();
        }
        finally
        {
            Interior.IsMenuInteracting = false;
        }
    }

    private void ShowElevatorMenu()
    {
        if (Floors == null || Floors.Count == 0 || nearestFloorCache == null)
            return;

        MenuPool menuPool = new MenuPool();
        UIMenu menu = new UIMenu("Elevator", "Select Floor");
        menu.SetBannerType(EntryPoint.LSRedColor);
        menuPool.Add(menu);

        UIMenuItem current = new UIMenuItem($"~o~{nearestFloorCache.Name}~s~", "You are on this floor")
        {
            Enabled = false
        };
        menu.AddItem(current);

        Dictionary<UIMenuItem, Floor> itemMap = new Dictionary<UIMenuItem, Floor>();

        foreach (Floor floor in Floors.Where(f => f != nearestFloorCache).OrderBy(f => f.ID))
        {
            UIMenuItem item = new UIMenuItem(floor.Name);
            itemMap[item] = floor;
            menu.AddItem(item);
        }

        menu.OnItemSelect += (sender, item, index) =>
        {
            if (itemMap.TryGetValue(item, out Floor floor))
            {
                TeleportToFloor(floor);
                sender.Visible = false;
            }
        };

        menu.RefreshIndex();
        menu.Visible = true;

        while (menu.Visible && EntryPoint.ModController.IsRunning && Player.IsAliveAndFree)
        {
            menuPool.ProcessMenus();
            GameFiber.Yield();
        }
    }

    private void TeleportToFloor(Floor floor)
    {
        Game.FadeScreenOut(600, true);
        GameFiber.Sleep(1200);

        Player.Character.Position = floor.Position;
        Player.Character.Heading = floor.Heading;

        GameFiber.Sleep(400);
        Game.FadeScreenIn(800, true);
    }

    private bool TestFloorAccessibility(Floor floor)
    {
        Vector3 originalPosition = Position;
        float originalHeading = Heading;

        Position = floor.Position;
        Heading = floor.Heading;

        bool success = MoveToPosition();

        Position = originalPosition;
        Heading = originalHeading;

        return success;
    }
}
