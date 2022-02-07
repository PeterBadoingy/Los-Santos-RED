﻿using ExtensionsMethods;
using iFruitAddon2;
using LosSantosRED.lsr.Helper;
using LosSantosRED.lsr.Interface;
using Rage;
using Rage.Native;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CellPhone
{
    private ICellPhoneable Player;
    private int ContactIndex = 40;
    private int TextIndex = 0;
    private UIMenu EmergencyServicesMenu;
    private UIMenu GangMenu;
    private MenuPool MenuPool;
    private UIMenuItem RequestPolice;
    private UIMenuItem PayoffGang;
    private UIMenuItem PayoffGangNeutral;
    private UIMenuItem ApoligizeToGang;
    private UIMenuItem RequestFire;
    private UIMenuItem RequestEMS;
    private IJurisdictions Jurisdictions;
    private List<iFruitContact> AddedContacts = new List<iFruitContact>();
    private List<ContactLookup> ContactLookups;
    private ISettingsProvideable Settings;
    private ITimeReportable Time;
    private IGangs Gangs;
    private List<iFruitText> AddedTexts = new List<iFruitText>();
    private Gang ActiveGang;
    private GangReputation ActiveGangRep;
    private IPlacesOfInterest PlacesOfInterest;
    private IZones Zones;
    private IStreets Streets;
    private List<ScheduledContact> ScheduledContacts = new List<ScheduledContact>();
    private List<ScheduledText> ScheduledTexts = new List<ScheduledText>();
    private UIMenuItem RequestGangWork;
    private UIMenuItem RequestGangDen;
    private UIMenuItem PayoffGangFriendly;
    private IGangTerritories GangTerritories;
    private int TextSound;
    private string playerCurrentFormattedStreetName;
    private string playerCurrentFormattedZoneName;
    private List<PhoneResponse> PhoneResponses = new List<PhoneResponse>();
    private UIMenu CopMenu;
    private iFruitContact LastAnsweredContact;
    private UIMenuItem PayoffCops;
    private UIMenuItem RequestCopWork;
    private UIMenu GangWorkMenu;
    private UIMenuItem GangHit;
    private UIMenuItem DeadDropPickup;
    private UIMenuItem GangTheft;
    private UIMenuItem GangTaskCancel;

    private int CostToClearWanted
    {
        get
        {
            return Player.WantedLevel * 10000;
        }
    }
    private int CostToPayoffGang(int repLevel)
    {
        if (repLevel < 0)
        {
            return (0 - repLevel) * 5.Round(100);
        }
        else if (repLevel >= 500)
        {
            return 0;
        }
        else
        {
            return (500 - repLevel) * 5.Round(100);
        }      
    }

    public CustomiFruit CustomiFruit { get; private set; }
    public List<iFruitText> TextList => AddedTexts;
    public List<iFruitContact> ContactList => AddedContacts;
    public List<PhoneResponse> PhoneResponseList => PhoneResponses;
    public CellPhone (ICellPhoneable player, IJurisdictions jurisdictions, ISettingsProvideable settings, ITimeReportable time, IGangs gangs, IPlacesOfInterest placesOfInterest, IZones zones, IStreets streets, IGangTerritories gangTerritories)
    {
        Player = player;
        CustomiFruit = new CustomiFruit();
        MenuPool = new MenuPool();
        Jurisdictions = jurisdictions;
        Settings = settings;
        Time = time;
        Gangs = gangs;
        Zones = zones;
        Streets = streets;
        ContactIndex = Settings.SettingsManager.CellphoneSettings.CustomContactStartingID;
        PlacesOfInterest = placesOfInterest;
        GangTerritories = gangTerritories;
    }
    public void Setup()
    {
        if (Settings.SettingsManager.CellphoneSettings.OverwriteVanillaEmergencyServicesContact)
        {
            AddEmergencyServicesCustomContact();
        }
        ContactLookups = new List<ContactLookup>()
        {
             new ContactLookup(ContactIcon.Generic,"CHAR_DEFAULT"),
             new ContactLookup(ContactIcon.Abigail,"CHAR_ABIGAIL"),
             new ContactLookup(ContactIcon.AllCharacters,"CHAR_ALL_PLAYERS_CONF"),
             new ContactLookup(ContactIcon.Amanda,"CHAR_AMANDA"),
             new ContactLookup(ContactIcon.Ammunation,"CHAR_AMMUNATION"),
             new ContactLookup(ContactIcon.Andreas,"CHAR_ANDREAS"),
             new ContactLookup(ContactIcon.Antonia,"CHAR_ANTONIA"),
             new ContactLookup(ContactIcon.Arthur,"CHAR_ARTHUR"),
             new ContactLookup(ContactIcon.Ashley,"CHAR_ASHLEY"),
             new ContactLookup(ContactIcon.BankOfLiberty,"CHAR_BANK_BOL"),
             new ContactLookup(ContactIcon.FleecaBank,"CHAR_BANK_FLEECA"),
             new ContactLookup(ContactIcon.MazeBank,"CHAR_BANK_MAZE"),
             new ContactLookup(ContactIcon.Barry,"CHAR_BARRY"),
             new ContactLookup(ContactIcon.Beverly,"CHAR_BEVERLY"),
             new ContactLookup(ContactIcon.Bikesite,"CHAR_BIKESITE"),
             new ContactLookup(ContactIcon.Blank,"CHAR_BLANK_ENTRY"),
             new ContactLookup(ContactIcon.Blimp,"CHAR_BLIMP"),
             new ContactLookup(ContactIcon.Blocked,"CHAR_BLOCKED"),
             new ContactLookup(ContactIcon.Boatsite,"CHAR_BOATSITE"),
             new ContactLookup(ContactIcon.BrokenDownGirl,"CHAR_BROKEN_DOWN_GIRL"),
             new ContactLookup(ContactIcon.Bugstars,"CHAR_BUGSTARS"),
             new ContactLookup(ContactIcon.Emergency,"CHAR_CALL911"),
             new ContactLookup(ContactIcon.LegendaryMotorsport,"CHAR_CARSITE"),
             new ContactLookup(ContactIcon.SSASuperAutos,"CHAR_CARSITE2"),
             new ContactLookup(ContactIcon.Castro,"CHAR_CASTRO"),
             new ContactLookup(ContactIcon.ChatIcon,"CHAR_CHAT_CALL"),
             new ContactLookup(ContactIcon.Chef,"CHAR_CHEF"),
             new ContactLookup(ContactIcon.Cheng,"CHAR_CHENG"),
             new ContactLookup(ContactIcon.ChengSr,"CHAR_CHENGSR"),
             new ContactLookup(ContactIcon.Chop,"CHAR_CHOP"),
             new ContactLookup(ContactIcon.CreatorPortraits,"CHAR_CREATOR_PORTRAITS"),
             new ContactLookup(ContactIcon.Cris,"CHAR_CRIS"),
             new ContactLookup(ContactIcon.Dave,"CHAR_DAVE"),
             new ContactLookup(ContactIcon.Denise,"CHAR_DENISE"),
             new ContactLookup(ContactIcon.DetonateBomb,"CHAR_DETONATEBOMB"),
             new ContactLookup(ContactIcon.DetonatePhone,"CHAR_DETONATEPHONE"),
             new ContactLookup(ContactIcon.Devin,"CHAR_DEVIN"),
             new ContactLookup(ContactIcon.DialASub,"CHAR_DIAL_A_SUB"),
             new ContactLookup(ContactIcon.Dom,"CHAR_DOM"),
             new ContactLookup(ContactIcon.DomesticGirl,"CHAR_DOMESTIC_GIRL"),
             new ContactLookup(ContactIcon.Dreyfuss,"CHAR_DREYFUSS"),
             new ContactLookup(ContactIcon.DrFriedlander,"CHAR_DR_FRIEDLANDER"),
             new ContactLookup(ContactIcon.Epsilon,"CHAR_EPSILON"),
             new ContactLookup(ContactIcon.EstateAgent,"CHAR_ESTATE_AGENT"),
             new ContactLookup(ContactIcon.Facebook,"CHAR_FACEBOOK"),
             new ContactLookup(ContactIcon.Filmnoir,"CHAR_FILMNOIR"),
             new ContactLookup(ContactIcon.Floyd,"CHAR_FLOYD"),
             new ContactLookup(ContactIcon.Franklin,"CHAR_FRANKLIN"),
             new ContactLookup(ContactIcon.FranklinTrevor,"CHAR_FRANK_TREV_CONF"),
             new ContactLookup(ContactIcon.GayMilitary,"CHAR_GAYMILITARY"),
             new ContactLookup(ContactIcon.Hao,"CHAR_HAO"),
             new ContactLookup(ContactIcon.HitcherGirl,"CHAR_HITCHER_GIRL"),
             new ContactLookup(ContactIcon.Human,"CHAR_HUMANDEFAULT"),
             new ContactLookup(ContactIcon.Hunter,"CHAR_HUNTER"),
             new ContactLookup(ContactIcon.Jimmy,"CHAR_JIMMY"),
             new ContactLookup(ContactIcon.JimmyBoston,"CHAR_JIMMY_BOSTON"),
             new ContactLookup(ContactIcon.Joe,"CHAR_JOE"),
             new ContactLookup(ContactIcon.Josef,"CHAR_JOSEF"),
             new ContactLookup(ContactIcon.Josh,"CHAR_JOSH"),
             new ContactLookup(ContactIcon.Lamar,"CHAR_LAMAR"),
             new ContactLookup(ContactIcon.Lazlow,"CHAR_LAZLOW"),
             new ContactLookup(ContactIcon.Lester,"CHAR_LESTER"),
             new ContactLookup(ContactIcon.Skull,"CHAR_LESTER_DEATHWISH"),
             new ContactLookup(ContactIcon.LesterFranklin,"CHAR_LEST_FRANK_CONF"),
             new ContactLookup(ContactIcon.LesterMichael,"CHAR_LEST_MIKE_CONF"),
             new ContactLookup(ContactIcon.Lifeinvader,"CHAR_LIFEINVADER"),
             new ContactLookup(ContactIcon.LSCustoms,"CHAR_LS_CUSTOMS"),
             new ContactLookup(ContactIcon.LSTouristBoard,"CHAR_LS_TOURIST_BOARD"),
             new ContactLookup(ContactIcon.Manuel,"CHAR_MANUEL"),
             new ContactLookup(ContactIcon.Marnie,"CHAR_MARNIE"),
             new ContactLookup(ContactIcon.Martin,"CHAR_MARTIN"),
             new ContactLookup(ContactIcon.MaryAnn,"CHAR_MARY_ANN"),
             new ContactLookup(ContactIcon.Maude,"CHAR_MAUDE"),
             new ContactLookup(ContactIcon.Mechanic,"CHAR_MECHANIC"),
             new ContactLookup(ContactIcon.Michael,"CHAR_MICHAEL"),
             new ContactLookup(ContactIcon.MichaelFranklin,"CHAR_MIKE_FRANK_CONF"),
             new ContactLookup(ContactIcon.MichaelTrevor,"CHAR_MIKE_TREV_CONF"),
             new ContactLookup(ContactIcon.Milsite,"CHAR_MILSITE"),
             new ContactLookup(ContactIcon.Minotaur,"CHAR_MINOTAUR"),
             new ContactLookup(ContactIcon.Molly,"CHAR_MOLLY"),
             new ContactLookup(ContactIcon.MP_ArmyContact,"CHAR_MP_ARMY_CONTACT"),
             new ContactLookup(ContactIcon.MP_BikerBoss,"CHAR_MP_BIKER_BOSS"),
             new ContactLookup(ContactIcon.MP_BikerMechanic,"CHAR_MP_BIKER_MECHANIC"),
             new ContactLookup(ContactIcon.MP_Brucie,"CHAR_MP_BRUCIE"),
             new ContactLookup(ContactIcon.MP_Detonatephone,"CHAR_MP_DETONATEPHONE"),
             new ContactLookup(ContactIcon.MP_FamBoss,"CHAR_MP_FAM_BOSS"),
             new ContactLookup(ContactIcon.MP_FibContact,"CHAR_MP_FIB_CONTACT"),
             new ContactLookup(ContactIcon.MP_FmContact,"CHAR_MP_FM_CONTACT"),
             new ContactLookup(ContactIcon.MP_Gerald,"CHAR_MP_GERALD"),
             new ContactLookup(ContactIcon.MP_Julio,"CHAR_MP_JULIO"),
             new ContactLookup(ContactIcon.MP_Mechanic,"CHAR_MP_MECHANIC"),
             new ContactLookup(ContactIcon.MP_Merryweather,"CHAR_MP_MERRYWEATHER"),
             new ContactLookup(ContactIcon.MP_MexBoss,"CHAR_MP_MEX_BOSS"),
             new ContactLookup(ContactIcon.MP_MexDocks,"CHAR_MP_MEX_DOCKS"),
             new ContactLookup(ContactIcon.MP_MexLt,"CHAR_MP_MEX_LT"),
             new ContactLookup(ContactIcon.MP_MorsMutual,"CHAR_MP_MORS_MUTUAL"),
             new ContactLookup(ContactIcon.MP_ProfBoss,"CHAR_MP_PROF_BOSS"),
             new ContactLookup(ContactIcon.MP_RayLavoy,"CHAR_MP_RAY_LAVOY"),
             new ContactLookup(ContactIcon.MP_Roberto,"CHAR_MP_ROBERTO"),
             new ContactLookup(ContactIcon.MP_Snitch,"CHAR_MP_SNITCH"),
             new ContactLookup(ContactIcon.MP_Stretch,"CHAR_MP_STRETCH"),
             new ContactLookup(ContactIcon.MP_StripclubPr,"CHAR_MP_STRIPCLUB_PR"),
             new ContactLookup(ContactIcon.MrsThornhill,"CHAR_MRS_THORNHILL"),
             new ContactLookup(ContactIcon.Multiplayer,"CHAR_MULTIPLAYER"),
             new ContactLookup(ContactIcon.Nigel,"CHAR_NIGEL"),
             new ContactLookup(ContactIcon.Omega,"CHAR_OMEGA"),
             new ContactLookup(ContactIcon.Oneil,"CHAR_ONEIL"),
             new ContactLookup(ContactIcon.Ortega,"CHAR_ORTEGA"),
             new ContactLookup(ContactIcon.Oscar,"CHAR_OSCAR"),
             new ContactLookup(ContactIcon.Patricia,"CHAR_PATRICIA"),
             new ContactLookup(ContactIcon.Pegasus,"CHAR_PEGASUS_DELIVERY"),
             new ContactLookup(ContactIcon.Planesite,"CHAR_PLANESITE"),
             new ContactLookup(ContactIcon.Property_ArmsTrafficking,"CHAR_PROPERTY_ARMS_TRAFFICKING"),
             new ContactLookup(ContactIcon.Property_BarAirport,"CHAR_PROPERTY_BAR_AIRPORT"),
             new ContactLookup(ContactIcon.Property_BarBayview,"CHAR_PROPERTY_BAR_BAYVIEW"),
             new ContactLookup(ContactIcon.Property_BarCafeRojo,"CHAR_PROPERTY_BAR_CAFE_ROJO"),
             new ContactLookup(ContactIcon.Property_BarCockotoos,"CHAR_PROPERTY_BAR_COCKOTOOS"),
             new ContactLookup(ContactIcon.Property_BarEclipse,"CHAR_PROPERTY_BAR_ECLIPSE"),
             new ContactLookup(ContactIcon.Property_BarFes,"CHAR_PROPERTY_BAR_FES"),
             new ContactLookup(ContactIcon.Property_BarHenHouse,"CHAR_PROPERTY_BAR_HEN_HOUSE"),
             new ContactLookup(ContactIcon.Property_BarHiMen,"CHAR_PROPERTY_BAR_HI_MEN"),
             new ContactLookup(ContactIcon.Property_BarHookies,"CHAR_PROPERTY_BAR_HOOKIES"),
             new ContactLookup(ContactIcon.Property_BarIrish,"CHAR_PROPERTY_BAR_IRISH"),
             new ContactLookup(ContactIcon.Property_BarLesBianco,"CHAR_PROPERTY_BAR_LES_BIANCO"),
             new ContactLookup(ContactIcon.Property_BarMirrorPark,"CHAR_PROPERTY_BAR_MIRROR_PARK"),
             new ContactLookup(ContactIcon.Property_BarPitchers,"CHAR_PROPERTY_BAR_PITCHERS"),
             new ContactLookup(ContactIcon.Property_BarSingletons,"CHAR_PROPERTY_BAR_SINGLETONS"),
             new ContactLookup(ContactIcon.Property_BarTequilala,"CHAR_PROPERTY_BAR_TEQUILALA"),
             new ContactLookup(ContactIcon.Property_BarUnbranded,"CHAR_PROPERTY_BAR_UNBRANDED"),
             new ContactLookup(ContactIcon.Property_CarModShop,"CHAR_PROPERTY_CAR_MOD_SHOP"),
             new ContactLookup(ContactIcon.Property_CarScrapYard,"CHAR_PROPERTY_CAR_SCRAP_YARD"),
             new ContactLookup(ContactIcon.Property_CinemaDowntown,"CHAR_PROPERTY_CINEMA_DOWNTOWN"),
             new ContactLookup(ContactIcon.Property_CinemaMorningwood,"CHAR_PROPERTY_CINEMA_MORNINGWOOD"),
             new ContactLookup(ContactIcon.Property_CinemaVinewood,"CHAR_PROPERTY_CINEMA_VINEWOOD"),
             new ContactLookup(ContactIcon.Property_GolfClub,"CHAR_PROPERTY_GOLF_CLUB"),
             new ContactLookup(ContactIcon.Property_PlaneScrapYard,"CHAR_PROPERTY_PLANE_SCRAP_YARD"),
             new ContactLookup(ContactIcon.Property_SonarCollections,"CHAR_PROPERTY_SONAR_COLLECTIONS"),
             new ContactLookup(ContactIcon.Property_TaxiLot,"CHAR_PROPERTY_TAXI_LOT"),
             new ContactLookup(ContactIcon.Property_TowingImpound,"CHAR_PROPERTY_TOWING_IMPOUND"),
             new ContactLookup(ContactIcon.Property_WeedShop,"CHAR_PROPERTY_WEED_SHOP"),
             new ContactLookup(ContactIcon.Ron,"CHAR_RON"),
             new ContactLookup(ContactIcon.Saeeda,"CHAR_SAEEDA"),
             new ContactLookup(ContactIcon.Sasquatch,"CHAR_SASQUATCH"),
             new ContactLookup(ContactIcon.Simeon,"CHAR_SIMEON"),
             new ContactLookup(ContactIcon.SocialClub,"CHAR_SOCIAL_CLUB"),
             new ContactLookup(ContactIcon.Solomon,"CHAR_SOLOMON"),
             new ContactLookup(ContactIcon.Steve,"CHAR_STEVE"),
             new ContactLookup(ContactIcon.SteveMichael,"CHAR_STEVE_MIKE_CONF"),
             new ContactLookup(ContactIcon.SteveTrevor,"CHAR_STEVE_TREV_CONF"),
             new ContactLookup(ContactIcon.Stretch,"CHAR_STRETCH"),
             new ContactLookup(ContactIcon.StripperChastity,"CHAR_STRIPPER_CHASTITY"),
             new ContactLookup(ContactIcon.StripperCheetah,"CHAR_STRIPPER_CHEETAH"),
             new ContactLookup(ContactIcon.StripperFufu,"CHAR_STRIPPER_FUFU"),
             new ContactLookup(ContactIcon.StripperInfernus,"CHAR_STRIPPER_INFERNUS"),
             new ContactLookup(ContactIcon.StripperJuliet,"CHAR_STRIPPER_JULIET"),
             new ContactLookup(ContactIcon.StripperNikki,"CHAR_STRIPPER_NIKKI"),
             new ContactLookup(ContactIcon.StripperPeach,"CHAR_STRIPPER_PEACH"),
             new ContactLookup(ContactIcon.StripperSapphire,"CHAR_STRIPPER_SAPPHIRE"),
             new ContactLookup(ContactIcon.Tanisha,"CHAR_TANISHA"),
             new ContactLookup(ContactIcon.Taxi,"CHAR_TAXI"),
             new ContactLookup(ContactIcon.TaxiLiz,"CHAR_TAXI_LIZ"),
             new ContactLookup(ContactIcon.TennisCoach,"CHAR_TENNIS_COACH"),
             new ContactLookup(ContactIcon.Tonya,"CHAR_TOW_TONYA"),
             new ContactLookup(ContactIcon.Tracey,"CHAR_TRACEY"),
             new ContactLookup(ContactIcon.Trevor,"CHAR_TREVOR"),
             new ContactLookup(ContactIcon.Wade,"CHAR_WADE"),
             new ContactLookup(ContactIcon.Youtube,"CHAR_YOUTUBE"),
        };
    }
    public void Update()
    {
        CheckScheduledItems();
        CustomiFruit.Update();
        MenuPool.ProcessMenus();
    }
    public void Reset()
    {
        CustomiFruit.ForceClose();
        CustomiFruit = new CustomiFruit();
        ContactIndex = Settings.SettingsManager.CellphoneSettings.CustomContactStartingID;
        AddedTexts = new List<iFruitText>();
        AddedContacts = new List<iFruitContact>();
        PhoneResponses = new List<PhoneResponse>();
        ScheduledContacts = new List<ScheduledContact>();
        ScheduledTexts = new List<ScheduledText>();
        if (Settings.SettingsManager.CellphoneSettings.OverwriteVanillaEmergencyServicesContact)
        {
            AddEmergencyServicesCustomContact();
        }
    }
    public void Dispose()
    {
        CustomiFruit.ForceClose();
    }

    private void CheckScheduledItems()
    {
        CheckScheduledTexts();
        CheckScheduledContacts();
    }
    private void CheckScheduledTexts()
    {
        for (int i = ScheduledTexts.Count - 1; i >= 0; i--)
        {
            ScheduledText sc = ScheduledTexts[i];
            if (DateTime.Compare(Time.CurrentDateTime, sc.TimeToSend) >= 0)
            {
                if (!AddedTexts.Any(x => x.Name == sc.ContactName && x.Message == sc.Message))
                {
                    AddText(sc.ContactName, sc.IconName, sc.Message, Time.CurrentHour, Time.CurrentMinute, false);
                    NativeHelper.DisplayNotificationCustom(sc.IconName, sc.IconName, sc.ContactName, "~g~Text Received~s~", sc.Message, NotificationIconTypes.ChatBox, false);
                    TextSound = NativeFunction.Natives.GET_SOUND_ID<int>();
                    NativeFunction.Natives.PLAY_SOUND_FRONTEND(TextSound, "Phone_Generic_Key_01", "HUD_MINIGAME_SOUNDSET", 0);


                    if (!AddedContacts.Any(x => x.Name == sc.ContactName))
                    {
                        Gang relatedGang = Gangs.GetGangByContact(sc.ContactName);
                        if (relatedGang != null)
                        {
                            AddContact(relatedGang, true);
                        }
                        else if (sc.ContactName == "Officer Friendly")
                        {
                            AddCopContact(sc.ContactName, sc.IconName, true);
                        }
                        else
                        {
                            AddContact(sc.ContactName, sc.IconName, true);
                        }

                    }
                }
                ScheduledTexts.RemoveAt(i);
            }
        }
    }
    private void CheckScheduledContacts()
    {
        for (int i = ScheduledContacts.Count - 1; i >= 0; i--)
        {
            ScheduledContact sc = ScheduledContacts[i];
            if (DateTime.Compare(Time.CurrentDateTime, sc.TimeToSend) >= 0)
            {
                if (!AddedContacts.Any(x => x.Name == sc.ContactName))
                {
                    Gang relatedGang = Gangs.GetGangByContact(sc.ContactName);
                    if (relatedGang != null)
                    {
                        AddContact(relatedGang, true);
                    }
                    else if (sc.ContactName == "Officer Friendly")
                    {
                        AddCopContact(sc.ContactName,sc.IconName, true);
                    }
                    else
                    {
                        AddContact(sc.ContactName, sc.IconName, true);
                    }
                    TextSound = NativeFunction.Natives.GET_SOUND_ID<int>();
                    NativeFunction.Natives.PLAY_SOUND_FRONTEND(TextSound, "Phone_Generic_Key_01", "HUD_MINIGAME_SOUNDSET", 0);
                    if (sc.Message == "")
                    {
                        NativeHelper.DisplayNotificationCustom(sc.IconName, sc.IconName, "New Contact", sc.ContactName, NotificationIconTypes.AddFriendRequest, true);
                    }
                    else
                    {
                        NativeHelper.DisplayNotificationCustom(sc.IconName, sc.IconName, "New Contact", sc.ContactName, sc.Message, NotificationIconTypes.AddFriendRequest, false);
                    }
                }
                ScheduledContacts.RemoveAt(i);
            }
        }
    }
    public void AddScheduledContact(string Name, string IconName, string MessageToSend, DateTime timeToAdd)
    {
        if(!AddedContacts.Any(x=> x.Name == Name))
        {
            ScheduledContacts.Add(new ScheduledContact(timeToAdd, Name, MessageToSend, IconName));
        }
    }
    public void AddContact(string Name, string IconName, bool displayNotification)
    {
        if (!AddedContacts.Any(x => x.Name == Name))
        {
            iFruitContact contactA = new iFruitContact(Name, ContactIndex);
            contactA.Answered += CivAnswered;
            contactA.Active = false;
            contactA.DialTimeout = 4000;
            contactA.RandomizeDialTimeout = true;
            contactA.Icon = GetIconFromString(IconName);
            contactA.IconName = IconName;
            CustomiFruit.Contacts.Add(contactA);
            ContactIndex++;
            AddedContacts.Add(contactA);

            if (displayNotification)
            {
                NativeHelper.DisplayNotificationCustom(IconName, IconName, "New Contact", Name, NotificationIconTypes.AddFriendRequest, true);
                NativeFunction.Natives.PLAY_SOUND_FRONTEND(TextSound, "Phone_Generic_Key_01", "HUD_MINIGAME_SOUNDSET", 0);
            }
        }
    }

    public void AddCopContact(string Name, string IconName, bool displayNotification)
    {
        if (!AddedContacts.Any(x => x.Name == Name))
        {
            iFruitContact contactA = new iFruitContact(Name, ContactIndex);
            contactA.Answered += CopAnswered;
            contactA.Active = true;
            contactA.DialTimeout = 4000;
            contactA.RandomizeDialTimeout = true;
            contactA.Icon = GetIconFromString(IconName);
            contactA.IconName = IconName;
            CustomiFruit.Contacts.Add(contactA);
            ContactIndex++;
            AddedContacts.Add(contactA);

            if (displayNotification)
            {
                NativeHelper.DisplayNotificationCustom(IconName, IconName, "New Contact", Name, NotificationIconTypes.AddFriendRequest, true);
                NativeFunction.Natives.PLAY_SOUND_FRONTEND(TextSound, "Phone_Generic_Key_01", "HUD_MINIGAME_SOUNDSET", 0);
            }
        }
    }



    public void AddContact(Gang gang, bool displayNotification)
    {
        if (!AddedContacts.Any(x=> x.Name == gang.ContactName))
        {
            iFruitContact contactA = new iFruitContact(gang.ContactName, ContactIndex);
            contactA.Answered += GangAnswered;
            contactA.Active = true;
            contactA.DialTimeout = 4000;
            contactA.RandomizeDialTimeout = true;
            contactA.Icon = GetIconFromString(gang.ContactIcon);
            contactA.IconName = gang.ContactIcon;
            CustomiFruit.Contacts.Add(contactA);
            ContactIndex++;
            AddedContacts.Add(contactA);

            if (displayNotification)
            {
                NativeHelper.DisplayNotificationCustom(gang.ContactIcon, gang.ContactIcon, "New Contact", gang.ContactName, NotificationIconTypes.AddFriendRequest, true);
                NativeFunction.Natives.PLAY_SOUND_FRONTEND(TextSound, "Phone_Generic_Key_01", "HUD_MINIGAME_SOUNDSET", 0);
            }
        }
    }
    public void AddGangText(Gang gang, bool isPositive)
    {
        if (gang != null)
        {
            List<string> Replies = new List<string>();
            if (isPositive)
            {
                Replies.AddRange(new List<string>() {
                    $"Heard some good things about you, come see us sometime.",
                    $"Call us soon to discuss business.",
                    $"Might have some business opportunites for you soon, give us a call.",
                    $"You've been making some impressive moves, call us to discuss.",
                    $"Give us a call soon.",
                    $"We may have some opportunites for you.",
                    $"My guys tell me you are legit, hit us up sometime.",
                    $"Looking for people I can trust, if so give us a call.",
                    $"Word has gotten around about you, mostly positive, give us a call soon.",
                    $"Always looking for help with some 'items'. Call us if you think you can handle it.",
                });
            }
            else
            {
                Replies.AddRange(new List<string>() {
                    $"Watch your back",
                    $"Dead man walking",
                    $"ur fucking dead",
                    $"You just fucked with the wrong people asshole",
                    $"We're gonna fuck you up buddy",
                    $"My boys are gonna skin you alive prick.",
                    $"You will die slowly.",
                    $"I'll take pleasure in guttin you boy.",
                    $"Better leave LS while you can...",
                    $"We'll be waiting for you asshole.",
                    $"You're gonna wish you were dead motherfucker.",
                    $"Got some 'associates' out looking for you prick. Where you at?",
                });
            }

            List<ZoneJurisdiction> myGangTerritories = GangTerritories.GetGangTerritory(gang.ID);
            ZoneJurisdiction mainTerritory = myGangTerritories.OrderBy(x => x.Priority).FirstOrDefault();

            if (mainTerritory != null)
            {
                Zone mainGangZone = Zones.GetZone(mainTerritory.ZoneInternalGameName);
                if (mainGangZone != null)
                {
                    if (isPositive)
                    {
                        Replies.AddRange(new List<string>() {
                            $"Heard some good things about you, come see us sometime in ~p~{mainGangZone.DisplayName}~s~ to discuss some business",
                            $"Call us soon to discuss business in ~p~{mainGangZone.DisplayName}~s~.",
                            $"Might have some business opportunites for you soon in ~p~{mainGangZone.DisplayName}~s~, give us a call.",
                            $"You've been making some impressive moves, call us to discuss.",
                        });
                    }
                    else
                    {
                        Replies.AddRange(new List<string>() {
                            $"Watch your back next time you are in ~p~{mainGangZone.DisplayName}~s~ motherfucker",
                            $"You are dead next time we see you in ~p~{mainGangZone.DisplayName}~s~",
                            $"Better stay out of ~p~{mainGangZone.DisplayName}~s~ cocksucker",
                        });
                    }
                }
            }
            string MessageToSend;
            MessageToSend = Replies.PickRandom();
            AddScheduledText(gang.ContactName, gang.ContactIcon, MessageToSend);
        }
    }
    public void AddScheduledText(string Name, string IconName, string MessageToSend, int minutesToWait)
    {
        AddScheduledText(Name, IconName, MessageToSend, Time.CurrentDateTime.AddMinutes(minutesToWait));
    }
    public void AddScheduledText(string Name, string IconName, string MessageToSend)
    {
        AddScheduledText(Name, IconName, MessageToSend, Time.CurrentDateTime.AddMinutes(3));
    }
    public void AddScheduledText(string Name, string IconName, string MessageToSend, DateTime timeToAdd)
    {
        if (!AddedTexts.Any(x => x.Name == Name && x.Message == MessageToSend))
        {
            ScheduledTexts.Add(new ScheduledText(timeToAdd, Name, MessageToSend, IconName));
        }
    }
    public void AddText(string Name, string IconName, string message, int hourSent, int minuteSent, bool isRead)
    {
        if (!AddedTexts.Any(x => x.Name == Name && x.Message == message && x.HourSent == hourSent && x.MinuteSent == minuteSent))
        {
            iFruitText textA = new iFruitText(Name, TextIndex, message, hourSent, minuteSent);
            textA.Icon = GetIconFromString(IconName);      // Contact's icon
            textA.IconName = IconName;
            textA.IsRead = isRead;
            textA.TimeReceived = Time.CurrentDateTime;
            CustomiFruit.Texts.Add(textA);         // Add the contact to the phone
            TextIndex++;
            AddedTexts.Add(textA);

            int NewTextIndex = 0;
            foreach(iFruitText ifta in CustomiFruit.Texts.OrderByDescending(x=> x.TimeReceived))
            {
                ifta.Index = NewTextIndex;
                NewTextIndex++;
            }
        }
    }
    public void AddPhoneResponse(string Name, string IconName, string Message)
    {
        PhoneResponses.Add(new PhoneResponse(Name, IconName, Message,Time.CurrentDateTime));
        Game.DisplayNotification(IconName, IconName, Name, "~o~Response", Message);
        NativeFunction.Natives.PLAY_SOUND_FRONTEND(TextSound, "Phone_Generic_Key_02", "HUD_MINIGAME_SOUNDSET", 0);
    }
    public void DisableContact(string Name)
    {
        iFruitContact myContact = AddedContacts.FirstOrDefault(x => x.Name == Name);
        if(myContact != null)
        {
            myContact.Active = false;
        }
    }
    public bool IsContactEnabled(string contactName)
    {
        iFruitContact myContact = AddedContacts.FirstOrDefault(x => x.Name == contactName);
        if (myContact != null)
        {
            return myContact.Active;
        }
        return false;
    }
    public void GangAnswered(Gang gang)
    {
        ActiveGang = gang;
        int repLevel = Player.GangRelationships.GetRepuationLevel(ActiveGang);

        GangMenu = new UIMenu("", "Select an Option");
        GangMenu.RemoveBanner();
        MenuPool.Add(GangMenu);
        GangMenu.OnItemSelect += OnGangItemSelect;

        if (repLevel < 0)
        {
            PayoffGangNeutral = new UIMenuItem("Payoff", "Payoff the gang to return to a neutral relationship") { RightLabel = CostToPayoffGang(repLevel).ToString("C0") };
            ApoligizeToGang = new UIMenuItem("Apologize", "Apologize to the gang for your actions");
            GangMenu.AddItem(PayoffGangNeutral);
            GangMenu.AddItem(ApoligizeToGang);
        }
        else if (repLevel >= 500)
        {
            //RequestGangWork = new UIMenuItem("Request Work", "Ask for some work from the gang");
            if (Player.PlayerTasks.HasTask(ActiveGang.ContactName))
            {
                GangTaskCancel = new UIMenuItem("Cancel Task", "Tell the gang you can't complete the task.") { RightLabel = "$?" };
                GangMenu.AddItem(GangTaskCancel);
            }
            else
            {
                GangWorkMenu = MenuPool.AddSubMenu(GangMenu, "Request Work");
                GangMenu.MenuItems[GangMenu.MenuItems.Count() - 1].Description = "Ask for some work from the gang";
                GangHit = new UIMenuItem("Hit", "Do a hit for the gang on a rival") { RightLabel = "$10,000+" };
                DeadDropPickup = new UIMenuItem("Pickup", "Pickup an item for the gang and bring it back") { RightLabel = "$200-$1,000" };
                GangTheft = new UIMenuItem("Theft", "Steal an item for the gang") { RightLabel = "$1,000+" };
                GangWorkMenu.AddItem(GangHit);
                GangWorkMenu.AddItem(DeadDropPickup);
                GangWorkMenu.AddItem(GangTheft);
            }
            RequestGangDen = new UIMenuItem("Request Invite", "Request the location of the gang den");
            //GangMenu.AddItem(RequestGangWork);
            GangMenu.AddItem(RequestGangDen);
            GangWorkMenu.RemoveBanner();
            GangWorkMenu.OnItemSelect += OnGangWorkItemSelect;

        }
        else
        {
            PayoffGangFriendly = new UIMenuItem("Payoff", "Payoff the gang to get a friendly relationship") { RightLabel = CostToPayoffGang(repLevel).ToString("C0") };
            GangMenu.AddItem(PayoffGangFriendly);
        }
        GangMenu.Visible = true;
        GameFiber.StartNew(delegate
        {
            while (GangMenu.Visible || GangWorkMenu.Visible)
            {
                GameFiber.Yield();
            }
            CustomiFruit.Close(2000);
        }, "CellPhone");
    }


    private void GangAnswered(iFruitContact contact)
    {
        Gang myGang = Gangs.GetAllGangs().FirstOrDefault(x => x.ContactName == contact.Name);
        if(myGang == null)
        {
            CustomiFruit.Close(2000);
            return;
        }
        ActiveGang = myGang;
        GangAnswered(ActiveGang);
    }
    private void OnGangItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
    {
        if (Player.PlayerTasks.HasTask(ActiveGang.ContactName))
        {
            if(selectedItem == PayoffGangNeutral || selectedItem == GangHit || selectedItem == PayoffGangFriendly || selectedItem == DeadDropPickup || selectedItem == GangTheft)//cant do more than one of these.....
            {
                AlreadyWorkingForGang();
                sender.Visible = false;
                return;
            }
        }
        if (selectedItem == PayoffGangFriendly)
        {
            PayoffGangToFriendly();
            sender.Visible = false;
        }
        else if (selectedItem == PayoffGangNeutral)
        {
            PayoffGangToNeutral();
            sender.Visible = false;
        }
        else if (selectedItem == ApoligizeToGang)
        {
            ApologizeToGang();
            sender.Visible = false;
        }
        else if (selectedItem == RequestGangDen)
        {
            RequestDenAddress();
            sender.Visible = false;
        }
        else if (selectedItem == GangTaskCancel)
        {
            GangCancel();
            sender.Visible = false;
        }

    }
    private void OnGangWorkItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
    {
        if (Player.PlayerTasks.HasTask(ActiveGang.ContactName))
        {
            if (selectedItem == PayoffGangNeutral || selectedItem == GangHit || selectedItem == PayoffGangFriendly || selectedItem == DeadDropPickup || selectedItem == GangTheft)//cant do more than one of these.....
            {
                AlreadyWorkingForGang();
                sender.Visible = false;
                return;
            }
        }
       if (selectedItem == DeadDropPickup)
        {
            GangPickupWork();
        }
        else if (selectedItem == GangTheft)
        {
            GangTheftWork();
        }
        else if (selectedItem == GangHit)
        {
            GangHitWork();
        }

        sender.Visible = false;
    }
    private void PayoffGangToFriendly()
    {
        int repLevel = Player.GangRelationships.GetRepuationLevel(ActiveGang);
        int CostToBuy = CostToPayoffGang(repLevel);
        if(CostToBuy <= 500)
        {
            Player.GangRelationships.SetReputation(ActiveGang, 500, false);
            List<string> Replies = new List<string>() {
                $"${Math.Abs(CostToBuy)}? Don't worry about it",
                $"We can forget about the ${Math.Abs(CostToBuy)}, not worth my time.",
                };
            AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
        }
        else
        {
            CreateDeadDrop(CostToBuy, 500, true);
        }     
    }
    private void PayoffGangToNeutral()
    {
        int repLevel = Player.GangRelationships.GetRepuationLevel(ActiveGang);
        int CostToBuy = CostToPayoffGang(repLevel);
        CreateDeadDrop(CostToBuy, 0, true);
       
    }
    private void CreateDeadDrop(int CostToBuy, int RepToSet, bool isDropOff)
    {
        DeadDrop myDrop = PlacesOfInterest.PossibleLocations.DeadDrops.Where(x => !x.IsEnabled).PickRandom();
        if (myDrop != null)
        {
            Player.PlayerTasks.AddTask(ActiveGang.ContactName);
            myDrop.SetGang(ActiveGang, CostToBuy, RepToSet, isDropOff);
            List<string> Replies = new List<string>() {
                    $"Drop ${CostToBuy} on {myDrop.StreetAddress}, its {myDrop.Description}. My guy won't pick it up if you are around.",
                    $"Place ${CostToBuy} in {myDrop.Description}, address is {myDrop.StreetAddress}. Don't hang around either, drop it off and leave.",
                    $"Drop off ${CostToBuy} to {myDrop.Description} on {myDrop.StreetAddress}. Once you drop the cash off, get out of the area.",
                    };

            AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
            //CustomiFruit.Close();
        }
        else
        {
            //CustomiFruit.Close(500);
        }
    }
    private void ApologizeToGang()
    {
        List<string> Replies = new List<string>() {
                    "You think I give a shit?",
                    "Fuck off prick.",
                    "Go fuck yourself prick.",
                    "You are really starting to piss me off",
                    "(click)",
                    "I'm not even going to respond to this shit.",

                    };
        AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
        //CustomiFruit.Close();
    }
    private void GangPickupWork()
    {
        DeadDrop myDrop = PlacesOfInterest.PossibleLocations.DeadDrops.Where(x => !x.IsEnabled).PickRandom();
        GangDen myDen = PlacesOfInterest.PossibleLocations.GangDens.FirstOrDefault(x => x.AssociatedGang?.ID == ActiveGang.ID);
        if (myDrop != null && myDen != null)
        {
            Player.PlayerTasks.AddTask(ActiveGang.ContactName);
            int MoneyToPickup = RandomItems.GetRandomNumberInt(2000, 10000).Round(500);
            float TenPercent = (float)MoneyToPickup / 10;

            int MoneyToRecieve = (int)TenPercent;

            if(MoneyToRecieve <= 0)
            {
                MoneyToRecieve = 500;
            }
            MoneyToRecieve = MoneyToRecieve.Round(10);
            myDrop.SetGang(ActiveGang, MoneyToPickup, 0, false);
            myDen.ExpectedMoney = MoneyToPickup;
            myDen.RepOnDropOff = 500;
            myDen.MoneyOnDropOff = MoneyToRecieve;
            List<string> Replies = new List<string>() {
                    $"Pickup ${MoneyToPickup} from {myDrop.StreetAddress}, its {myDrop.Description}. Bring it to the {ActiveGang.DenName} on {myDen.StreetAddress}. You get 10% on completion",
                    $"Go get ${MoneyToPickup} from {myDrop.Description}, address is {myDrop.StreetAddress}. Bring it to the {ActiveGang.DenName} on {myDen.StreetAddress}. 10% to you when you drop it off",
                    $"Make a pickup of ${MoneyToPickup} from {myDrop.Description} on {myDrop.StreetAddress}. Take it to the {ActiveGang.DenName} on {myDen.StreetAddress}. You'll get 10% when I get my money.",
                    };
            AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
            //CustomiFruit.Close();
        }
        else
        {
            List<string> Replies = new List<string>() {
                    "Nothing yet, I'll let you know",
                    "I've got nothing for you yet",
                    "Give me a few days",
                    "Not a lot to be done right now",
                    "We will let you know when you can do something for us",
                    "Check back later.",
                    };
            AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
            //CustomiFruit.Close();
        }
       
    }
    private void GangTheftWork()
    {
        //DeadDrop myDrop = PlacesOfInterest.PossibleLocations.DeadDrops.Where(x => !x.IsEnabled).PickRandom();
        bool IsCancelled = false;
        GangDen myDen = PlacesOfInterest.PossibleLocations.GangDens.FirstOrDefault(x => x.AssociatedGang?.ID == ActiveGang.ID);
        Gang TargetGang = Gangs.GetAllGangs().Where(x => x.ID != ActiveGang.ID).PickRandom();
        if (myDen != null && TargetGang != null)
        {
            Player.PlayerTasks.AddTask(ActiveGang.ContactName);
            int MoneyToRecieve = RandomItems.GetRandomNumberInt(1000, 10000).Round(500);

            if (MoneyToRecieve <= 0)
            {
                MoneyToRecieve = 500;
            }

            DispatchableVehicle toget = TargetGang.GetRandomVehicle(0, false, false, true);
            if (toget != null)
            {
                string MakeName = NativeHelper.VehicleMakeName(Game.GetHashKey(toget.ModelName));
                string ModelName = NativeHelper.VehicleModelName(Game.GetHashKey(toget.ModelName));


                List<string> Replies = new List<string>() {
                    $"Go steal a ~p~{MakeName} {ModelName}~s~ from {TargetGang.ColorPrefix}{TargetGang.ShortName}~s~. Once you are done come back to {ActiveGang.DenName} on {myDen.StreetAddress}. ${MoneyToRecieve} on completion",



                   // $"Go get ${MoneyToPickup} from {myDrop.Description}, address is {myDrop.StreetAddress}. Bring it to the {ActiveGang.DenName} on {myDen.StreetAddress}. ${MoneyToRecieve} to get it done",
                   // $"Make a pickup of ${MoneyToPickup} from {myDrop.Description} on {myDrop.StreetAddress}. Take it to the {ActiveGang.DenName} on {myDen.StreetAddress}. You'll get ${MoneyToRecieve} once its done.",
                    };
                AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
                //CustomiFruit.Close();


                Gang toWatchGang = ActiveGang;
                GameFiber PayoffFiber = GameFiber.StartNew(delegate
                {
                    while(true)
                    {
                        if(Player.CurrentVehicle != null && Player.CurrentVehicle.Vehicle.Exists() && Player.CurrentVehicle.Vehicle.Model.Name.ToLower() == toget.ModelName.ToLower() && Player.CurrentVehicle.WasModSpawned && Player.CurrentVehicle.AssociatedGang != null && Player.CurrentVehicle.AssociatedGang.ID == toWatchGang.ID)
                        {
                            EntryPoint.WriteToConsole($"You got in a {toget.ModelName.ToLower()} so the den is now ACTIVE!");
                            break;
                        }
                        GameFiber.Yield();
                    }
                    myDen.RepOnDropOff = 1000;
                    myDen.MoneyOnDropOff = MoneyToRecieve;
                    Player.PlayerTasks.GetTask(toWatchGang.ContactName).IsReadyForPayment = true;

                }, "PayoffFiber");

            }
            else
            {
                IsCancelled = true;
            }
        }
        else
        {
            IsCancelled = true;
        }

        if(IsCancelled)
        {
            List<string> Replies = new List<string>() {
                    "Nothing yet, I'll let you know",
                    "I've got nothing for you yet",
                    "Give me a few days",
                    "Not a lot to be done right now",
                    "We will let you know when you can do something for us",
                    "Check back later.",
                    };
            AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
            //CustomiFruit.Close(2000);
        }

    }
    private void GangHitWork()
    {
        bool IsCancelled = false;
        GangDen myDen = PlacesOfInterest.PossibleLocations.GangDens.FirstOrDefault(x => x.AssociatedGang?.ID == ActiveGang.ID);
        Gang TargetGang = Gangs.GetAllGangs().Where(x => x.ID != ActiveGang.ID).PickRandom();
        if (myDen != null && TargetGang != null)
        {
            Player.PlayerTasks.AddTask(ActiveGang.ContactName);
            int MoneyToRecieve = RandomItems.GetRandomNumberInt(10000, 30000).Round(500);

            if (MoneyToRecieve <= 0)
            {
                MoneyToRecieve = 500;
            }

            DispatchableVehicle toget = TargetGang.GetRandomVehicle(0, false, false, true);
            if (toget != null)
            {
                string MakeName = NativeHelper.VehicleMakeName(Game.GetHashKey(toget.ModelName));
                string ModelName = NativeHelper.VehicleModelName(Game.GetHashKey(toget.ModelName));
                List<string> Replies = new List<string>() {
                    $"{TargetGang.ShortName} thinks they can fuck with me? Go give one of those pricks a dirt nap. Once you are done come back to {ActiveGang.DenName} on {myDen.StreetAddress}. ${MoneyToRecieve} to you",
                   $"The {TargetGang.ShortName} decided to make some moves against us. Let them know we don't approve with some gentle encouragement on a member. When you are finished, get back to the {ActiveGang.DenName} on {myDen.StreetAddress}. I'll have ${MoneyToRecieve} waiting for you.",
                   $"Go find one of those pricks from {TargetGang.ShortName}. Make sure he won't ever talk to anyone again. Come back to the {ActiveGang.DenName} on {myDen.StreetAddress} for your payment of ${MoneyToRecieve}",
                    };
                AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
                //CustomiFruit.Close();

                GangReputation gr = Player.GangRelationships.GetReputation(ActiveGang);

                int CurrentKilledMembers = gr.MembersKilled;


                GameFiber PayoffFiber = GameFiber.StartNew(delegate
                {
                    while (true)
                    {
                        if (gr.MembersKilled > CurrentKilledMembers)
                        {
                            EntryPoint.WriteToConsole($"You killed a member so the den is now ACTIVE!");
                            break;
                        }
                        GameFiber.Yield();
                    }
                    myDen.RepOnDropOff = 2000;
                    myDen.MoneyOnDropOff = MoneyToRecieve;
                    Player.PlayerTasks.GetTask(ActiveGang.ContactName).IsReadyForPayment = true;


                }, "PayoffFiber");

            }
            else
            {
                IsCancelled = true;
            }
        }
        else
        {
            IsCancelled = true;
        }

        if (IsCancelled)
        {
            List<string> Replies = new List<string>() {
                    "Nothing yet, I'll let you know",
                    "I've got nothing for you yet",
                    "Give me a few days",
                    "Not a lot to be done right now",
                    "We will let you know when you can do something for us",
                    "Check back later.",
                    };
            AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
            //CustomiFruit.Close();
        }

    }
    private void GangCancel()
    {
        Player.PlayerTasks.RemoveTask(ActiveGang.ContactName);
        Player.GangRelationships.ChangeReputation(ActiveGang, -200, false);
        List<string> Replies = new List<string>() {
                    "I knew you were reliable",
                    "You really fucked me on this one",
                    "You are very helpful",
                    "This is a great time to fuck me like this prick",
                    "Whatever prick",
                    "Sorry I stuck my neck out for you",
                    };
        AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
        //CustomiFruit.Close();
    }
    private void RequestDenAddress()
    {

        GangDen myDen = PlacesOfInterest.PossibleLocations.GangDens.FirstOrDefault(x => x.AssociatedGang?.ID == ActiveGang.ID);
        if (myDen != null)
        {
            Player.AddGPSRoute(myDen.Name, myDen.EntrancePosition);
            List<string> Replies = new List<string>() {
                    $"Our {ActiveGang.DenName} is located on {myDen.StreetAddress} come see us.",
                    $"Come check out our {ActiveGang.DenName} on {myDen.StreetAddress}.",
                    $"You can find out {ActiveGang.DenName} on {myDen.StreetAddress}.",
                    $"{myDen.StreetAddress}.",
                    $"It's on {myDen.StreetAddress} come see us.",
                    $"The {ActiveGang.DenName}? It's on {myDen.StreetAddress}.",

                    };
            AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
            //CustomiFruit.Close();
        }




        //GameLocation den = PlacesOfInterest.GetLocations(LocationType.GangDen).Where(x => x.GangID == ActiveGang.ID).FirstOrDefault();
        //if (den != null)
        //{
        //    Player.AddGPSRoute(den.Name, den.EntrancePosition);
        //    Zone gangZome = Zones.GetZone(den.EntrancePosition);
        //    string StreetName = Streets.GetStreetNames(den.EntrancePosition);
        //    string locationText = $"~s~on {StreetName} {(gangZome.IsSpecificLocation ? "near" : "in")} ~p~{gangZome.FullDisplayName}~s~".Trim();

        //    List<string> Replies = new List<string>() {
        //            $"Our {ActiveGang.DenName} is located {locationText} come see us.",
        //            $"Come check out our {ActiveGang.DenName} {locationText}.",
        //            $"You can find out {ActiveGang.DenName} {locationText}.",
        //            $"{locationText}.",
        //            $"It's {locationText} come see us.",
        //            $"The {ActiveGang.DenName}? It's {locationText}.",

        //            };
        //    AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
        //    CustomiFruit.Close();
        //}
    }
    private void AlreadyWorkingForGang()
    {
        List<string> Replies = new List<string>() {
                    $"Aren't you already taking care of that thing for us?",
                    $"Didn't we already give you something to do?",
                    $"Finish your task before you call us again prick.",
                    $"Get going on that thing, stop calling me",
                    $"I alredy told you what to do, stop calling me.",
                    $"You already have an item, stop with the calls.",

                    };
        AddPhoneResponse(ActiveGang.ContactName, ActiveGang.ContactIcon, Replies.PickRandom());
        //CustomiFruit.Close();
    }

    private void AddEmergencyServicesCustomContact()
    {
        iFruitContact contactA = new iFruitContact("Emergency Services ", Settings.SettingsManager.CellphoneSettings.EmergencyServicesContactID);
        contactA.Answered += PoliceAnswered;
        contactA.DialTimeout = 8000;
        contactA.Active = true;
        contactA.Icon = ContactIcon.Emergency;
        CustomiFruit.Contacts.Add(contactA);
    }
    private void PoliceAnswered(iFruitContact contact)
    {
        // The contact has answered, we can execute our code
        //Game.DisplayNotification("CHAR_CALL911", "CHAR_CALL911", "Emergency Services", "~r~Please Wait", "Your call is important to us, please stay on the line! ~n~~n~If you are being killed, yell a description of your attacker into the phone. Otherwise enjoy some smooth jazz.");

        EmergencyServicesMenu = new UIMenu("Emergency Services", "Select an Option");
        EmergencyServicesMenu.RemoveBanner();
        MenuPool.Add(EmergencyServicesMenu);
        EmergencyServicesMenu.OnItemSelect += OnEmergencyServicesSelect;
        RequestPolice = new UIMenuItem("Police Assistance");
        RequestFire = new UIMenuItem("Fire Assistance");
        RequestEMS = new UIMenuItem("Medical Service");
        EmergencyServicesMenu.AddItem(RequestPolice);
        EmergencyServicesMenu.AddItem(RequestFire);
        EmergencyServicesMenu.AddItem(RequestEMS);
        EmergencyServicesMenu.Visible = true;

        GameFiber.StartNew(delegate
        {
            while (EmergencyServicesMenu.Visible)
            {
                GameFiber.Yield();
            }
            CustomiFruit.Close(2000);
        }, "CellPhone");

        // We need to close the phone at a moment.
        // We can close it as soon as the contact pick up calling _iFruit.Close().
        // Here, we will close the phone in 5 seconds (5000ms).     
    }
    private void OnEmergencyServicesSelect(UIMenu sender, UIMenuItem selectedItem, int index)
    {
        if (selectedItem == RequestPolice)
        {
            RequestPoliceAssistance();
        }
        else if (selectedItem == RequestFire)
        {
            RequestFireAssistance();
        }
        else if (selectedItem == RequestEMS)
        {
            RequestEMSAssistance();
        }
        sender.Visible = false;
    }
    private void GetPlayerLocationString()
    {
        playerCurrentFormattedStreetName = "";
        playerCurrentFormattedZoneName = "";
        if (Player.CurrentLocation.CurrentStreet != null)
        {
            playerCurrentFormattedStreetName = $"~HUD_COLOUR_YELLOWLIGHT~{Player.CurrentLocation.CurrentStreet.Name}~s~";
            if (Player.CurrentLocation.CurrentCrossStreet != null)
            {
                playerCurrentFormattedStreetName += " at ~HUD_COLOUR_YELLOWLIGHT~" + Player.CurrentLocation.CurrentCrossStreet.Name + "~s~ ";
            }
            else
            {
                playerCurrentFormattedStreetName += " ";
            }
        }
        if (Player.CurrentLocation.CurrentZone != null)
        {
            playerCurrentFormattedZoneName = Player.CurrentLocation.CurrentZone.IsSpecificLocation ? "near ~p~" : "in ~p~" + Player.CurrentLocation.CurrentZone.DisplayName + "~s~";
        }
    }

    private void CivAnswered(iFruitContact contact)
    {
       // CustomiFruit.Close();
    }

    private void CopAnswered(iFruitContact contact)
    {
        CopMenu = new UIMenu("", "Select an Option");
        CopMenu.RemoveBanner();
        MenuPool.Add(CopMenu);
        CopMenu.OnItemSelect += OnCopItemSelect;
        LastAnsweredContact = contact;
        PayoffCops = new UIMenuItem("Clear Wanted", "Ask your contact to have the cops forget about you") { RightLabel = CostToClearWanted.ToString("C0") };
        RequestCopWork = new UIMenuItem("Request Work", "Ask for some work from the cops");

        if (Player.IsWanted)
        {
            CopMenu.AddItem(PayoffCops);
        }
        else if (Player.IsNotWanted)
        {
            CopMenu.AddItem(RequestCopWork);
        }
        else
        {
            //CustomiFruit.Close();
            return;
        }
        CopMenu.Visible = true;
        GameFiber.StartNew(delegate
        {
            while (CopMenu.Visible)
            {
                GameFiber.Yield();
            }
            //CustomiFruit.Close();
        }, "CellPhone");
    }
    private void OnCopItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
    {
        if (selectedItem == PayoffCops)
        {
            PayoffCop(LastAnsweredContact);
            CopMenu.Visible = false;
        }
        else if (selectedItem == RequestCopWork)
        {
            RequestWorkFromCop(LastAnsweredContact);
            CopMenu.Visible = false;
        }
    }
    private void RequestWorkFromCop(iFruitContact contact)
    {
        List<string> Replies = new List<string>() {
                "Nothing yet, I'll let you know",
                "I've got nothing for you yet",
                "Give me a few days",
                "Not a lot to be done right now",
                "We will let you know when you can do something for us",
                "Check back later.",
                };
        AddPhoneResponse(contact.Name, contact.IconName, Replies.PickRandom());
        //CustomiFruit.Close(2000);
    }
    private void PayoffCop(iFruitContact contact)
    {

        EntryPoint.WriteToConsole($"Player.Money {Player.Money} CostToClearWanted {CostToClearWanted}");
        if(Player.WantedLevel > 4)
        {
            List<string> Replies = new List<string>() {
                $"Nothing I can do, you really fucked up.",
                $"Should have called me earlier",
                $"Too late now, you are on your own",
                $"Too many eyes on this one, should have let me known earlier",
                };
            AddPhoneResponse(contact.Name, contact.IconName, Replies.PickRandom());

        }
        else if (Player.WantedLevel >= 3 && Player.PoliceResponse.HasHurtPolice)
        {
            List<string> Replies = new List<string>() {
                $"Shouldn't have messed with the cops so much, they really want you. It's outta my hands",
                $"They are out to get you since you fucked with the cops, nothing I can do.",
                $"Next time don't send so many cops to the hospital and maybe I can help",
                };
            AddPhoneResponse(contact.Name, contact.IconName, Replies.PickRandom());
        }
        else if(Player.WantedLevel == 1)
        {
            List<string> Replies = new List<string>() {
                $"Why not just pay the fine?",
                $"Just stop and pay the fine",
                $"The fine is a lot cheaper than me",
                $"Why not pay the small fine instead of bothering me?",
                };
            AddPhoneResponse(contact.Name, contact.IconName, Replies.PickRandom());
        }
        else if(Player.Money >= CostToClearWanted)
        {
            Player.GiveMoney(-1 * CostToClearWanted);

            GameFiber PayoffFiber = GameFiber.StartNew(delegate
            {
                int SleepTime = RandomItems.GetRandomNumberInt(5000, 10000);
                GameFiber.Sleep(SleepTime);
                Player.PayoffPolice();
                Player.SetWantedLevel(0, "Cop Payoff", true);

            }, "PayoffFiber");



            List<string> Replies = new List<string>() {
                $"Let me work my magic, hang on.",
                $"They should forget about you soon.",
                $"Let me make up some bullshit to distract them, wait a few.",
                $"Sending out an officer down across town, should get them off your tail for a while",
                };
            AddPhoneResponse(contact.Name, contact.IconName, Replies.PickRandom());
        }
        else if(Player.Money < CostToClearWanted)
        {
            List<string> Replies = new List<string>() {
                $"Don't bother me unless you have some money",
                $"This shit isn't free you know",
                };
            AddPhoneResponse(contact.Name, contact.IconName, Replies.PickRandom());
        }
        else
        {
            List<string> Replies = new List<string>() {
                $"Don't bother me",
                };
            AddPhoneResponse(contact.Name, contact.IconName, Replies.PickRandom());
        }
    }

    private void RequestPoliceAssistance()
    {
        string fullText = "";
        if (Player.CurrentLocation != null)
        {
            Agency main = Jurisdictions.GetMainAgency(Player.CurrentLocation.CurrentZone.InternalGameName, ResponseType.LawEnforcement);
            if (main != null)
            {
                fullText = $"The {main.ColorPrefix}{main.FullName}~s~";
            }
        }
        if (fullText == "")
        {
            fullText = $"An officer";
        }
        fullText += " is en route to ";
        fullText += playerCurrentFormattedStreetName;
        fullText += playerCurrentFormattedZoneName;

        AddPhoneResponse("Emergency Services", "CHAR_CALL911", fullText);


        //Game.DisplayNotification("CHAR_CALL911", "CHAR_CALL911", "Emergency Services", "~o~Response", fullText);
        Player.CallPolice();
    }
    private void RequestFireAssistance()
    {
        string fullText = "";
        if (Player.CurrentLocation != null)
        {
            Agency main = Jurisdictions.GetMainAgency(Player.CurrentLocation.CurrentZone.InternalGameName, ResponseType.Fire);
            if (main != null)
            {
                fullText = $"The {main.ColorPrefix}{main.FullName}~s~";
                //Game.DisplayNotification("CHAR_CALL911", "CHAR_CALL911", "Emergency Services", "~b~Police Service", $"An officer from {main.FullName} is now en route to .");
            }
        }
        if (fullText == "")
        {
            fullText = $"The fire department";
        }
        fullText += " is en route to ";
        fullText += playerCurrentFormattedStreetName;
        fullText += playerCurrentFormattedZoneName;

        fullText = "Apologies, ~r~firefighting service~s~ is unavailable due to budget cuts.";
        AddPhoneResponse("Emergency Services", "CHAR_CALL911", fullText);
        //Game.DisplayNotification("CHAR_CALL911", "CHAR_CALL911", "Emergency Services", "~r~Fire Service", fullText);
        //Player.CallPolice();
    }
    private void RequestEMSAssistance()
    {
        string fullText = "";
        if (Player.CurrentLocation != null)
        {
            Agency main = Jurisdictions.GetMainAgency(Player.CurrentLocation.CurrentZone.InternalGameName, ResponseType.Fire);
            if (main != null)
            {
                fullText = $"The {main.ColorPrefix}{main.FullName}~s~";
                //Game.DisplayNotification("CHAR_CALL911", "CHAR_CALL911", "Emergency Services", "~b~Police Service", $"An officer from {main.FullName} is now en route to .");
            }
        }
        if (fullText == "")
        {
            fullText = $"Emergency medical services";
        }
        fullText += " is en route to ";
        fullText += playerCurrentFormattedStreetName;
        fullText += playerCurrentFormattedZoneName;

        fullText = "We are sorry, all our ~w~ambulances~s~ are busy. Please try again later.";
        AddPhoneResponse("Emergency Services", "CHAR_CALL911", fullText);
        //Game.DisplayNotification("CHAR_CALL911", "CHAR_CALL911", "Emergency Services", "~h~Medical Service", fullText);
        //Player.CallPolice();
    }

    private ContactIcon GetIconFromString(string StringName)
    {
        ContactLookup cl = ContactLookups.FirstOrDefault(x => x.IconText.ToLower() == StringName.ToLower());
        if (cl != null)
        {
            return cl.ContactIcon;
        }
        return ContactIcon.Generic;
    }
    private class ContactLookup
    {
        public ContactLookup(ContactIcon contactIcon, string iconText)
        {
            ContactIcon = contactIcon;
            IconText = iconText;
        }

        public ContactIcon ContactIcon { get; set; }
        public string IconText { get; set; }
    }
    private class ScheduledContact
    {
        public ScheduledContact(DateTime timeToSend, string contactName, string message, string iconName)
        {
            TimeToSend = timeToSend;
            ContactName = contactName;
            Message = message;
            IconName = iconName;
        }

        public DateTime TimeToSend { get; set; }
        public string ContactName { get; set; }
        public string Message { get; set; } = "We need to talk";
        public string IconName { get; set; } = "CHAR_DEFAULT";
    }
    private class ScheduledCall
    {
        public DateTime TimeToSend { get; set; }
        public iFruitContact ContactToCall { get; set; }
    }
    private class ScheduledText
    {
        public ScheduledText(DateTime timeToSend, string contactName, string message, string iconName)
        {
            TimeToSend = timeToSend;
            ContactName = contactName;
            Message = message;
            IconName = iconName;
        }
        public DateTime TimeToSend { get; set; }
        public string ContactName { get; set; }
        public string Message { get; set; } = "We need to talk";
        public string IconName { get; set; } = "CHAR_DEFAULT";
    }

}



/*
 * 
 * 
 * if (Player.Money >= CostToBuy)
            {
                Player.GiveMoney(-1 * CostToBuy);
                Player.GangRelationships.SetReputation(GangLastCalled, 500, false);

                List<string> Replies = new List<string>() {
                    "Nice to get some respect from you finally",
                    "I knew you were one of the good ones",
                    "Well this certainly smooths things over",
                    "I always liked you",
                    "Thanks for that, I'll remember it",
                    "Ah you got me my favorite thing!",
                    };
                AddPhoneResponse(GangLastCalled.ContactName, GangLastCalled.ContactIcon, Replies.PickRandom());
                CustomiFruit.Close();
            }
            else
            {
                List<string> Replies = new List<string>() {
                    "Call me when you're a little, hmmm, richer?",
                    "What are you trying to pull",
                    "Call me back when you aren't so poor",
                    "Why are you bothering me with this bullshit",
                    "Am i supposed to wait for a chargeback or something?",
                    "I don't see any cash",

                    };
                AddPhoneResponse(GangLastCalled.ContactName, GangLastCalled.ContactIcon, Replies.PickRandom());
                CustomiFruit.Close();
            }
 * 
 *     private void PayoffGangToNeutral()
    {
        if (GangLastCalled != null)
        {
            int repLevel = Player.GangRelationships.GetRepuationLevel(GangLastCalled);
            int CostToBuy = (0 - repLevel) * 5;

            DeadDrop myDrop = PlacesOfInterest.PossibleLocations.DeadDrops.PickRandom();
            if (myDrop != null)
            {
                myDrop.SetGang(GangLastCalled, -1 * CostToBuy);
                List<string> Replies = new List<string>() {
                    $"Drop ${CostToBuy} on {myDrop.StreetAddress}, its the {myDrop.Description}",
                    $"Place ${CostToBuy} in the {myDrop.Description}, address is {myDrop.StreetAddress}",
                    $"Drop off ${CostToBuy} to the {myDrop.Description} on {myDrop.StreetAddress}",
                    };
                AddPhoneResponse(GangLastCalled.ContactName, GangLastCalled.ContactIcon, Replies.PickRandom());
                //Game.DisplayNotification(GangLastCalled.ContactIcon, GangLastCalled.ContactIcon, GangLastCalled.ContactName, "~o~Response", Replies.PickRandom());
                AddText(GangLastCalled.ContactName, GangLastCalled.ContactIcon, Replies.PickRandom(), Time.CurrentHour, Time.CurrentMinute, true);
            }
            else
            {
                CustomiFruit.Close(500);
            }


            //if (Player.Money >= CostToBuy)
            //{
            //    Player.GiveMoney(-1 * CostToBuy);
            //    Player.GangRelationships.SetReputation(GangLastCalled, 0, false);
            //    List<string> Replies = new List<string>() {
            //    "I guess we can forget about that shit.",
            //    "No problem man, all is forgiven",
            //    "That shit before? Forget about it.",
            //    "We are square",
            //    "You are off the hit list",
            //    "This doesn't make us friends prick, just associates",
            //    };
            //    Game.DisplayNotification(GangLastCalled.ContactIcon, GangLastCalled.ContactIcon, GangLastCalled.ContactName, "~o~Response", Replies.PickRandom());
            //}
            //else
            //{
            //    List<string> Replies = new List<string>() {
            //    "The fuck are you trying to pull dickhead?",
            //    "Fuck off prick.",
            //    "Poor motherfucker",
            //    "You are really starting to piss me off",
            //    "You really are a dumb motherfucker arent you?",
            //    "Can you even read the numbers in your bank account?",
            //    };
            //    Game.DisplayNotification(GangLastCalled.ContactIcon, GangLastCalled.ContactIcon, GangLastCalled.ContactName, "~o~Response", Replies.PickRandom());
            //}
        }
    }*/