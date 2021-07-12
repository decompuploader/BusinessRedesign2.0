using GTA;
using GTA.Math;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ExecutiveBusiness
{
  public class VehicleWarehouse : Script
  {
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public bool AwaitingClose;
    public int VehicleWarehouseBought;
    public SaveCar SC = new SaveCar();
    public Vector3 EnterMarkerA;
    public Vector3 EnterMarkerB;
    public Vector3 EnterMarkerC;
    public Vector3 ExitMarker;
    public Vector3 Vehicle1Loc = new Vector3(987.485f, -2992.6f, -39f);
    public Vehicle Vehicle1;
    public Vector3 Vehicle2Loc = new Vector3(990.485f, -2992.6f, -39f);
    public Vehicle Vehicle2;
    public Vector3 Vehicle3Loc = new Vector3(993.485f, -2992.6f, -39f);
    public Vehicle Vehicle3;
    public Vector3 Vehicle4Loc = new Vector3(996.485f, -2992.6f, -39f);
    public Vehicle Vehicle4;
    public Vector3 Vehicle5Loc = new Vector3(999.485f, -2992.6f, -39f);
    public Vehicle Vehicle5;
    public Vector3 Vehicle6Loc = new Vector3(1009.4f, -3026f, -40f);
    public Vehicle Vehicle6;
    public Vector3 Vehicle7Loc = new Vector3(1004f, -3026f, -40f);
    public Vehicle Vehicle7;
    public Vector3 Vehicle8Loc = new Vector3(998.5f, -3026f, -40f);
    public Vehicle Vehicle8;
    public Vector3 Vehicle9Loc = new Vector3(993.3f, -3025.7f, -40f);
    public Vehicle Vehicle9;
    public Vector3 Vehicle10Loc = new Vector3(980f, -3034f, -40f);
    public Vehicle Vehicle10;
    public Vector3 Vehicle11Loc = new Vector3(966.7f, -3025.9f, -40f);
    public Vehicle Vehicle11;
    public Vector3 Vehicle12Loc = new Vector3(972f, -3034f, -40f);
    public Vehicle Vehicle12;
    public Vector3 Vehicle13Loc = new Vector3(966.7f, -3022.3f, -40f);
    public Vehicle Vehicle13;
    public Vector3 Vehicle14Loc = new Vector3(963.5f, -3034f, -40f);
    public Vehicle Vehicle14;
    public Vector3 Vehicle15Loc = new Vector3(959.4f, -3033f, -40f);
    public Vehicle Vehicle15;
    public Vector3 Vehicle16Loc = new Vector3(955.6f, -3029f, -40f);
    public Vehicle Vehicle16;
    public Vector3 Vehicle17Loc = new Vector3(956f, -3023.7f, -40f);
    public Vehicle Vehicle17;
    public Vector3 Vehicle18Loc = new Vector3(955.4f, -3018.4f, -40f);
    public Vehicle Vehicle18;
    public Vector3 Vehicle19Loc = new Vector3(976.5f, -3034.4f, -40f);
    public Vehicle Vehicle19;
    public Vector3 Vehicle20Loc = new Vector3(967.5f, -3034f, -40f);
    public Vehicle Vehicle20;
    public Vector3 Vehicle21Loc = new Vector3(984.5f, -3001f, -40f);
    public Vehicle Vehicle21;
    public Vector3 Vehicle22Loc = new Vector3(987f, -3001f, -39f);
    public Vehicle Vehicle22;
    public Vector3 Vehicle23Loc = new Vector3(990.4f, -3001f, -40f);
    public Vehicle Vehicle23;
    public Vector3 Vehicle24Loc = new Vector3(993f, -3001f, -40f);
    public Vehicle Vehicle24;
    public Vector3 Vehicle25Loc = new Vector3(995.9f, -3001f, -40f);
    public Vehicle Vehicle25;
    public Vector3 Vehicle26Loc = new Vector3(993.3f, -3010f, -40f);
    public Vehicle Vehicle26;
    public Vector3 Vehicle27Loc = new Vector3(990.4f, -3010f, -40f);
    public Vehicle Vehicle27;
    public Vector3 Vehicle28Loc = new Vector3(987.6f, -3010f, -40f);
    public Vehicle Vehicle28;
    public Vector3 Vehicle29Loc = new Vector3(984.9f, -3010f, -40f);
    public Vehicle Vehicle29;
    public Vector3 Vehicle30Loc = new Vector3(996f, -3010f, -40f);
    public Vehicle Vehicle30;
    public Vector3 Vehicle31Loc = new Vector3(971f, -3001f, -40f);
    public Vehicle Vehicle31;
    public Vector3 Vehicle32Loc = new Vector3(971f, -3004f, -40f);
    public Vehicle Vehicle32;
    public Vector3 Vehicle33Loc = new Vector3(971f, -3007f, -40f);
    public Vehicle Vehicle33;
    public Vector3 Vehicle34Loc = new Vector3(971f, -3010f, -40f);
    public Vehicle Vehicle34;
    public Vector3 Vehicle35Loc = new Vector3(971f, -3013f, -40f);
    public Vehicle Vehicle35;
    public Vector3 MenuMarker = new Vector3(265.215f, -3085.09f, 4.5f);
    private MenuPool modMenuPool;
    private UIMenu GarageMenu;
    private UIMenu mainMenu;
    public Vector3 EntryMarker = new Vector3(-1574.64f, -569.683f, 108f);
    public Vector3 ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
    public string path = "scripts//HKH191sBusinessMods//ExecutiveBusiness//WareHouses//";
    public Vehicle SaveVehicle;
    public Vector3 RemoveMarker = new Vector3(979.393f, -2989.47f, -41f);
    private MenuPool modMenuPool2;
    private UIMenu RemoveMenu;
    private UIMenu mainMenu2;
    public string GarageNum;
    public bool DeliveringVehicle;
    public Vehicle VehicleToDeliver;
    public string SlotToDelete;
    public int Ruiner2000Bought;
    public int RampbuggyBought;
    public int ABoxvilleBought;
    public int TechnicalAquaBought;
    public int PhantomWBought;
    public int RvolticBought;
    public int BlazerAquaBought;
    public int WastelanderBought;
    public Vector3 Ruiner2000Loc = new Vector3(1001.44f, -2991.64f, -47f);
    public Vehicle Ruiner2000;
    public Vector3 RampBuggyLoc = new Vector3(993.44f, -2991.64f, -47f);
    public Vehicle RampBuggy;
    public Vector3 BoxvilleLoc = new Vector3(985.44f, -2991.64f, -47f);
    public Vehicle Boxville;
    public Vector3 TechnicalALoc = new Vector3(978.44f, -2991.64f, -47f);
    public Vehicle TechnicalA;
    public Vector3 PhantomWLoc = new Vector3(962.44f, -2991.64f, -48f);
    public Vehicle PhantomW;
    public Vector3 RvolticLoc = new Vector3(954.44f, -2991.64f, -47f);
    public Vehicle Rvoltic;
    public Vector3 BlazerAquaLoc = new Vector3(946.44f, -2991.64f, -47f);
    public Vehicle BlazerAqua;
    public Vector3 WastelanderLoc = new Vector3(939.44f, -2991.64f, -47f);
    public Vehicle Wastelander;
    private MenuPool modMenuPool3;
    private UIMenu BuyCar1;
    private UIMenu mainMenu3;
    public Vector3 BuyMaker = new Vector3(1002.18f, -3000.16f, -49f);
    public Blip VehicleWarehouseMarker;
    public Vector3 WherehouseMarker;
    public float WherehouseExitHeading;
    public bool TriggerWanted;
    public Vector3 SleepPos = new Vector3(959.389f, -3006.57f, -41f);
    public bool IsInInterior;
    public Vector3 PointA = new Vector3(993.299f, 3537.02f, 35f);
    public Vector3 PointB = new Vector3(1753.16f, 4568.55f, 39f);
    public Vector3 PointC = new Vector3(-1525.76f, 4696.35f, 42f);
    public Vehicle Sam1;
    public Vehicle Sam2;
    public Vehicle Sam3;
    public Blip Sam1blip;
    public Blip Sam2blip;
    public Blip Sam3blip;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public string Style;
    private UIMenu InteiorOptions;
    private Keys Key1;
    private UIMenu weaponsMenu;
    public Vector3 GunLockerMarker;
    public int GunLockerBought;
    private UIMenu MK2Pumpshotgun;
    private UIMenu MK2SNSPistol;
    private UIMenu MK2Revolver;
    private UIMenu Mk2SpecialCarbine;
    private UIMenu MK2Bullpup;
    private UIMenu MK2MarksmanRifle;
    private UIMenu MK2Pistol;
    private UIMenu MK2SMG;
    private UIMenu MK2LMG;
    private UIMenu MK2Carbine;
    private UIMenu MK2AssaultRifle;
    private UIMenu MK2Sniper;
    private MenuPool GLmodMenuPool;
    private UIMenu GLmainMenu;
    public int Tintscount = 32;
    public Vector3 MenuMarker2 = new Vector3(964f, -3004f, -41f);
    private MenuPool MissionsMenuPool;
    private UIMenu MissionsmainMenu;
    private UIMenu MissionsMenu;
    public Vector3 Sam1Loc;
    public Vector3 Sam2Loc;
    public Vector3 Sam3Loc;
    public Vector3 VehicleSpawn;
    public bool MissionSetup;
    public int mission;
    public Vector3 CurrentPoint;
    public bool killedDriver;
    public Vector3 DeliveryPoint = new Vector3(254.6f, -3057f, 5.7f);
    public bool NOTIFY;
    public float SourcingPayout;
    public Blip VehicleMarker;
    public Vehicle Vehicletoget;
    public string SourcedVehicle;
    public bool NewVehicleSourcing;
    public bool foundvehicleyet;
    public bool SourcingCheckingforDamage;
    public Vector3 Vehicleloc;
    public VehicleHash VehicleIdentifier;
    public bool hasgotvehicle;
    public ScriptSettings Config;
    public ScriptSettings WarehouseConfig;
    public VehicleClass VClass;
    public int VehicleWarehouseLoc;
    public ScriptSettings Config2;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public int LiveryColor;
    public List<VehicleWarehouse.PlayerVehicles> CurrentVehicles = new List<VehicleWarehouse.PlayerVehicles>();
    public List<Vehicle> CurrentVehicles_Vehicle = new List<Vehicle>();
    public float M;
    public string Price = "000";
    public string Model = "";
    public string man = "";
    public string ListPath = "scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MilitaryTrader\\AllVehicles.ini";
    public Prop ChairProp;
    public string ChairPropModel = "ex_prop_offchair_exec_01";
    public int Missionnum;
    public Scaleform GUIscaleform;
    public int GUIMT;
    public float GUIPosY;
    public float GUIPosX;
    public bool AdhawlScaleOn;
    public bool SecuroservCargoOn;
    public bool SecuroservVehicleOn;
    public bool HangerCargoCrateGUION;
    public bool NightclubManagementOn;
    public bool BunkerLogisiticsGUIOn;
    public int frame;
    public float Screen;
    public float Tab;
    public bool GUIOn;
    public bool ShowingOverlay;
    public bool SellingCargo;
    public bool StealingCargo;
    public int OverlayIndex;
    public int SellType;
    public int GUIAPP;
    public int GUIBIX;
    public bool GUICheckBool;
    public GTA.Control Key = GTA.Control.Attack;
    public string SS_Name = "HKH191";
    public string SS_Company = "Executive Office";
    public int SS_WarehousesOwned = 1;
    public int SS_CollectionsFailed;
    public int SS_CollectionsCompleted = 4;
    public int SS_SalesMade = 11;
    public int SS_SalesFailed = 1;
    public int SS_TotalEarnings = 250000;
    public int SS_Warehouse1Index = 5;
    public int SS_Warehouse1Stock = 7;
    public int SS_Warehouse2Index = 6;
    public int SS_Warehouse2Stock = 21;
    public int SS_Warehouse3Index = 1;
    public int SS_Warehouse3Stock = 2;
    public int SS_Warehouse4Index = 14;
    public int SS_Warehouse4Stock = 8;
    public int SS_Warehouse5Index = 11;
    public int SS_Warehouse5Stock = 60;
    public int SS_VehiclesExportedSuccess = 45;
    public int SS_VehiclesExportedFail = 45;
    public int SS_VehicleStealSuccess = 5;
    public int SS_VehicleStealFail = 5;
    public int SS_VehiclesStolenSuccess = 5;
    public int SS_VehiclesStolenFail = 1;
    public int SS_TotalExportEarnings = 1250000;
    public int SS_SpecialItems = 3;
    public int VehicleWarehouseIndex = 3;
    public int SS_VehicleWarehouseLoc = 4;
    public int SS_Warehouse1CurrentValue = 241000;
    public int SS_Warehouse2CurrentValue = 210000;
    public int SS_Warehouse3CurrentValue = 180000;
    public int SS_Warehouse4CurrentValue = 311000;
    public int SS_Warehouse5CurrentValue = 271000;
    public int SS_VehiclesTotalCurrentValue = 1750000;
    public int SS_CurrentVehiclesAmt = 29;
    public float SS_SuccessRate = 8f;
    public float SS_SaleSuccessRate = 98f;
    public float SS_VehiclesExportedTotal = 91f;
    public float SS_StealSuccessTotal = 96f;
    public float SS_VehiclesStolenTotal = 98f;
    public int SS_VehicleWarehouseTotalEarnings = 250000;
    public int SS_SourceVehicleWait;
    public int WarehouseSelected;
    public int VehiclesInWarehouse = 12;
    public List<VehicleWarehouse.CargoWarehouseData> CargoWarehouses = new List<VehicleWarehouse.CargoWarehouseData>()
    {
      new VehicleWarehouse.CargoWarehouseData(0, 0, 265000, 16, new Vector3(234.2376f, -1946.627f, 23.1f), "Convenience Store Lockup", "Rancho", "Rancho Warehouse", 250000, "DYN_MPWH_12"),
      new VehicleWarehouse.CargoWarehouseData(0, 0, 325000, 16, new Vector3(896.4013f, -1035.933f, 35.7f), "Celltowa Unit", "La Mesa", "La Mesa Warehouse", 318000, "DYN_MPWH_3"),
      new VehicleWarehouse.CargoWarehouseData(0, 0, 375000, 16, new Vector3(-1082.821f, -1261.822f, 4.6f), "White Widow Garage", "La Puerta", "La Puerta Warehouse", 360000, "DYN_MPWH_2"),
      new VehicleWarehouse.CargoWarehouseData(0, 0, 380000, 16, new Vector3(51.31f, -2570.59f, 5f), "Pacific Bait Storage", "Elysian Island 1", "Elysian Island Warehouse", 376000, "DYN_MPWH_1"),
      new VehicleWarehouse.CargoWarehouseData(0, 0, 400000, 16, new Vector3(274.46f, -3015.293f, 4.69f), "Pier 400 Utility Building", "Elysian Island", "Elysian Island Warehouse", 392000, "DYN_MPWH_9"),
      new VehicleWarehouse.CargoWarehouseData(0, 0, 412000, 16, new Vector3(-424.789f, 185.59f, 79.8f), "Foreclosed Garage", "West Vinewood", "West Vinewood Warehouse", 400000, "DYN_MPWH_5"),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 902000, 42, new Vector3(1569.81f, -2130.083f, 77.33f), "GEE Warehouse", "El Burro Heights", "El Burro Heights Warehouse", 880000, "DYN_MPWH_10"),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 914000, 42, new Vector3(-1268.769f, -812.7471f, 16.108f), "Derriere Lingerie Backlot", "Del Perro", "Del Perro Warehouse", 902000, "DYN_MPWH_7"),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 931000, 42, new Vector3(-528.27f, -1784.095f, 20.55f), "Fridgit Annexe", "La Puerta", "La Puerta Warehouse", 925000, "DYN_MPWH_13"),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 952000, 42, new Vector3(359.2f, 326.078f, 102.88f), "Discount Retail Unit", "Downtown Vinewood", "Downtown Vinewood Warehouse", 948000, "DYN_MPWH_10"),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 976000, 42, new Vector3(-295.311f, -1353.118f, 30.31f), "Disused Factory Outlet", "Strawberry", "Strawberry Warehouse", 971000, "DYN_MPWH_14"),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 1002000, 42, new Vector3(-315.2554f, -2697.967f, 6.55f), "LS Marine Building 3", "Elysian Island", "Elysian Island Warehouse", 994000, "DYN_MPWH_11"),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 1010000, 42, new Vector3(540.4222f, -1945.05f, 23.98f), "Old Power Station", "Rancho", "Rancho Warehouse", 1000000, "DYN_MPWH_4"),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 1025000, 42, new Vector3(500.0675f, -651.895f, 23.9f), "Railyard Warehouse", "La Mesa", "La Mesa Warehouse", 1017000, "DYN_MPWH_12"),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 1910000, 111, new Vector3(1013.557f, -2150.798f, 30.53f), "Wholesale Furniture", "Cypress Flats", "Cypress Flats Warehouse", 1900000, "DYN_MPWH_18"),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 2165000, 111, new Vector3(-262.9621f, 202.4988f, 84.37f), "West Vinewood Backlot", "West Vinewood", "West Vinewood Warehouse", 2135000, "DYN_MPWH_20"),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 2400000, 111, new Vector3(-1070.599f, -2003.346f, 14.79f), "Xero Gas Factory", "LSIA", "LSIA Warehouse", 2365000, "DYN_MPWH_6"),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 2630000, 111, new Vector3(962.5995f, -1557.725f, 29.8f), "Logistics Depot", "La Mesa", "La Mesa Warehouse", 2600000, "DYN_MPWH_21"),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 3000000, 111, new Vector3(-873.377f, -2734.696f, 12.92f), "Bilgeco Warehouse", "LSIA", "LSIA Warehouse", 2825000, "DYN_MPWH_8"),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 3100000, 111, new Vector3(95.899f, -2216.529f, 5.171f), "Walker & Sons Warehouse", "Banning", "Banning Warehouse", 3040000, "DYN_MPWH_16"),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 3300000, 111, new Vector3(1018.735f, -2511.857f, 27.47f), "Cypress Warehouses", "Cypress Flats", "Cypress Flats Warehouse", 3265000, "DYN_MPWH_19"),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 3550000, 111, new Vector3(759.7921f, -899.2148f, 24.21f), "Darnel Bros Warehouse", "La Mesa", "La Mesa Warehouse", 3500000, "DYN_MPWH_17"),
      new VehicleWarehouse.CargoWarehouseData(0, 0, 995000, 16, new Vector3(137.067f, -2472.874f, 5.1f), "Seweage Co", "Chum St", "Chum St Warehouse", 975000, ""),
      new VehicleWarehouse.CargoWarehouseData(0, 0, 1100000, 16, new Vector3(675.2f, -2726.29f, 6.17f), "Fuel Station Warehouse", "Elysian Island Island", "Elysian Island Warehouse", 1150000, ""),
      new VehicleWarehouse.CargoWarehouseData(0, 1, 2055000, 42, new Vector3(-520.1091f, -2903.51f, 5f), "Post Op Warehouse", "Elysian Island", "Elysian Island Warehouse", 2045000, ""),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 2055000, 111, new Vector3(1234.361f, -3201.442f, 4.52f), "United Stats Post Warehouse", "Buccaneer Way", "Buccaneer Way Warehouse", 2045000, ""),
      new VehicleWarehouse.CargoWarehouseData(0, 2, 2055000, 111, new Vector3(-1327.592f, -237.636f, 41.71f), "Rockford Hills Storage", "Rockford Hills", "Rockford Hills Warehouse", 2045000, "")
    };
    public List<VehicleWarehouse.VehicleWarehouseData> VehicleWarehouses = new List<VehicleWarehouse.VehicleWarehouseData>()
    {
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(804.2842f, -2224.391f, 28.4f), 178.4f, "Cypress Flats Vehicle Warehouse", "Cypress Flats", "IE_WH_TXD_1", 2675000, 2700000, "There's no more discreet place to locate a gigantic storage unit than in a neighborhood full of other gigantic storage units. And compared to them, whatever you're planning will almost look legal."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(-66.34f, -1827.459f, 25.9f), -127.74f, "Davis Vehicle Warehouse", "Davis", "IE_WH_TXD_2", 2495000, 2500000, "Does it qualify as a bonded warehouse if the government just doesn't know it exists? We think so, and we've got another warehouse full of lawyers who'll say the same. On the market for a limited time only."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(1763.221f, -1654.817f, 111.6f), -165f, "El Burro Heights Vehicle Warehouse", "El Burro Heights", "IE_WH_TXD_3", 1635000, 1700000, "Who would locate an off-the-books vehicle depot in the middle of a suburban wasteland where the white picket fences got burned for fuel a decade ago? A visionary venture capitalist with an eye on privacy, that's who."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(144.3986f, -3002.219f, 6.03f), 1f, "Elysian Island Vehicle Warehouse", "lysian Island", "IE_WH_TXD_4", 1950000, 2000000, "In a recent survey of warehouse owners in the port area of Los Santos, 94% self-identity as radical entrepreneurs while only 2% could spell the word 'tax'. Welcome home."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(1001.701f, -1859.269f, 29.88f), 179f, "La Mesa Vehicle Warehouse", "La Mesa", "IE_WH_TXD_5", 1500000, 1550000, "Sure, this part of La Mesa won the LSPD's 'Most Gang-Related Stabbings' award three years running. But the previous owner of this spacious depot had the largest collection of authentic Customs and Border Protection agency badges in the state, and his widow is throwing them in as a sweetener. You can't say fairer than that."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(-634.8254f, -1780.845f, 23f), 124f, "La Puerta Vehicle Warehouse", "La Puerta", "IE_WH_TXD_6", 2735000, 2750000, "If buying a red brick warehouse in a blue collar neighborhood and filling it with unregistered super cars doesn't count as gentrification, then nothing does. Throw in a flat white served in a chemistry beaker and consider this community regenerated."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(-1156.016f, -2174.042f, 12.21f), 137f, "LSIA Vehicle Warehouse", "LSIA", "IE_WH_TXD_7", 2170000, 2200000, "If you want your business to inspire the masses, this is the location for you. Because when they're queuing for another cavity search at LSIA, the sight of you stepping off your private jet to take delivery of a million dollar hypercar will be just the motivation they need to get off their asses and start being incredibly rich."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(-512.1462f, -2198.591f, 5.39f), -42f, "LSIA Vehicle Warehouse", "LSIA", "IE_WH_TXD_8", 2300000, 2350000, "It's a sad day for democracy when political correctness, liberal media elites and nineteen counts of human trafficking conspire to bring down one of the oldest storage companies in the state. Lesson learned: don't deal in goods that can testify against you in court, and this place could serve you for decades to come."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(1211.081f, -1262.385f, 34.22f), 89f, "Murrieta Heights Vehicle Warehouse", "Murrieta Heights", "IE_WH_TXD_9", 2850000, 3000000, "Here at SecuroServ, we have a dream that one day everyone living in Murrieta Heights will be a billionaire crimelord with an enormous portfolio of nearly-new luxury cars. But we also know that every journey of a thousand miles begins with a single warehouse full of stolen goods. Step up, be the hope, pocket the change."),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(254.6f, -3057f, 4.8f), 132f, "Elysian Island Vehicle Warehouse", "Elysian Island", "", 1850000, 2000000, "A Custom Warehouse Located at Elysian Island "),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(938.35f, -1494.98f, 29.08f), -95f, "La Mesa Vehicle Warehouse", "La Mesa", "", 2250000, 2300000, "A Custom Warehouse Located at La Mesa "),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(-2036.8f, -272.4f, 22.38f), 58f, "Pacific Bluffs Vehicle Warehouse", "Pacific Bluffs", "", 2450000, 2500000, "A Custom Warehouse Located at Pacific Bluffs "),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(544.3f, -211.5f, 52.55f), 156f, "Hawick Vehicle Warehouse", "Hawick", "", 1450000, 1500000, "A Custom Warehouse Located at Hawick"),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(39.9f, -1283.7f, 28.28f), -84f, "Strawberry Vehicle Warehouse", "Strawberry", "", 1950000, 2000000, "A Custom Warehouse Located at Strawberry"),
      new VehicleWarehouse.VehicleWarehouseData(0, new Vector3(497.4f, -635.5f, 23.94f), -98f, "La Mesa Vehicle Warehouse", "La Mesa", "", 1950000, 2000000, "A Custom Warehouse Located at La Mesa (2)")
    };
    public List<VehicleWarehouse.VehicleData> VehiclesData = new List<VehicleWarehouse.VehicleData>()
    {
      new VehicleWarehouse.VehicleData("DUKES2", "279000", (GTA.Model) " IMPONTE DUKE O'DEATH"),
      new VehicleWarehouse.VehicleData("GUARDIAN", "375000", (GTA.Model) " VAPID GUARDIAN"),
      new VehicleWarehouse.VehicleData("KURUMA2", "525000", (GTA.Model) " KARIN KURUMA"),
      new VehicleWarehouse.VehicleData("INSURGENT2", "675000", (GTA.Model) " HVY INSURGENT"),
      new VehicleWarehouse.VehicleData("SCHAFTER5", "325000", (GTA.Model) " BENEFACTOR SCHAFTER V12"),
      new VehicleWarehouse.VehicleData("SCHAFTER6", "438000", (GTA.Model) " BENEFACTOR SCHAFTER LWB"),
      new VehicleWarehouse.VehicleData("COG552", "396000", (GTA.Model) " ENUS COGNOSCENTI 55"),
      new VehicleWarehouse.VehicleData("COGNOSCENTI2", "558000", (GTA.Model) " ENUS COGNOSCENTI"),
      new VehicleWarehouse.VehicleData("BALLER5", "374000", (GTA.Model) " GALLIVANTER BALLER LE"),
      new VehicleWarehouse.VehicleData("BALLER6", "513000", (GTA.Model) " GALLIVANTER BALLER LE LWB"),
      new VehicleWarehouse.VehicleData("LIMO2", "1650000", (GTA.Model) " BENEFACTOR STRETCH E TURRETED"),
      new VehicleWarehouse.VehicleData("XLS2", "522000", (GTA.Model) " BENEFACTOR XLS"),
      new VehicleWarehouse.VehicleData("BOXVILLE5", "2926000", (GTA.Model) " BRUTE ARMORED BOXVILLE"),
      new VehicleWarehouse.VehicleData("DUNE3", "1130500", (GTA.Model) " BF DUNE FAV"),
      new VehicleWarehouse.VehicleData("HALFTRACK", "2254350", (GTA.Model) " BRAVADO HALF-TRACK"),
      new VehicleWarehouse.VehicleData("TAMPA3", "2108050", (GTA.Model) " DECLASSE WEAPONIZED TAMPA"),
      new VehicleWarehouse.VehicleData("APC", "3092250", (GTA.Model) " HVY APC"),
      new VehicleWarehouse.VehicleData("INSURGENT3", "202500", (GTA.Model) " HVY INSURGENT PICK-UP CUSTOM"),
      new VehicleWarehouse.VehicleData("NIGHTSHARK", "1245000", (GTA.Model) " HVY NIGHTSHARK"),
      new VehicleWarehouse.VehicleData("TECHNICAL3", "142500", (GTA.Model) " KARIN TECHNICAL CUSTOM"),
      new VehicleWarehouse.VehicleData("BARRAGE", "2121350", (GTA.Model) " BARRAGE"),
      new VehicleWarehouse.VehicleData("CARACARA", "1775000", (GTA.Model) " VAPID CARACARA"),
      new VehicleWarehouse.VehicleData("MENACER", "1775000", (GTA.Model) " HVY MENACER"),
      new VehicleWarehouse.VehicleData("IMPALER2", "1541335", (GTA.Model) " APOCALYPSE IMPALER"),
      new VehicleWarehouse.VehicleData("IMPALER3", "1541335", (GTA.Model) " FUTURE SHOCK IMPALER"),
      new VehicleWarehouse.VehicleData("IMPALER4", "1541335", (GTA.Model) " NIGHTMARE IMPALER"),
      new VehicleWarehouse.VehicleData("DOMINATOR4", "1167000", (GTA.Model) " APOCALYPSE DOMINATOR"),
      new VehicleWarehouse.VehicleData("DOMINATOR5", "1167000", (GTA.Model) " FUTURE SHOCK DOMINATOR"),
      new VehicleWarehouse.VehicleData("DOMINATOR6", "1167000", (GTA.Model) " NIGHTMARE DOMINATOR"),
      new VehicleWarehouse.VehicleData("DEATHBIKE", "1270200", (GTA.Model) " APOCALYPSE DEATHBIKE"),
      new VehicleWarehouse.VehicleData("DEATHBIKE2", "1270200", (GTA.Model) " FUTURE SHOCK DEATHBIKE"),
      new VehicleWarehouse.VehicleData("DEATHBIKE3", "1270200", (GTA.Model) " NIGHTMARE DEATHBIKE"),
      new VehicleWarehouse.VehicleData("BRUISER", "1809000", (GTA.Model) " APOCALYPSE BRUISER"),
      new VehicleWarehouse.VehicleData("BRUISER2", "1809000", (GTA.Model) " FUTURE SHOCK BRUISER"),
      new VehicleWarehouse.VehicleData("BRUISER3", "1809000", (GTA.Model) " NIGHTMARE BRUISER"),
      new VehicleWarehouse.VehicleData("BRUTUS", "2666650", (GTA.Model) " APOCALYPSE BRUTUS"),
      new VehicleWarehouse.VehicleData("BRUTUS2", "2666650", (GTA.Model) " FUTURE SHOCK BRUTUS"),
      new VehicleWarehouse.VehicleData("BRUTUS3", "2666650", (GTA.Model) " NIGHTMARE BRUTUS"),
      new VehicleWarehouse.VehicleData("ISSI4", "1449000", (GTA.Model) " APOCALYPSE ISSI CLASSIC"),
      new VehicleWarehouse.VehicleData("ISSI5", "1449000", (GTA.Model) " FUTURE SHOCK ISSI CLASSIC"),
      new VehicleWarehouse.VehicleData("ISSI6", "1449000", (GTA.Model) " NIGHTMARE ISSI CLASSIC"),
      new VehicleWarehouse.VehicleData("MONSTER3", "1536875", (GTA.Model) " APOCALYPSE SASQUATCH"),
      new VehicleWarehouse.VehicleData("MONSTER4", "1536875", (GTA.Model) " FUTURE SHOCK SASQUATCH"),
      new VehicleWarehouse.VehicleData("MONSTER5", "1536875", (GTA.Model) " NIGHTMARE SASQUATSCH"),
      new VehicleWarehouse.VehicleData("SCARAB", "3076290", (GTA.Model) " APOCALYPSE SCARAB"),
      new VehicleWarehouse.VehicleData("SCARAB2", "3076290", (GTA.Model) " SHOCK FUTURE SCARAB"),
      new VehicleWarehouse.VehicleData("SCARAB3", "3076290", (GTA.Model) " NIGHTMARE SACRAB"),
      new VehicleWarehouse.VehicleData("SLAMVAN4", "1371375", (GTA.Model) " APOCALYPSE SLAMVAN"),
      new VehicleWarehouse.VehicleData("SLAMVAN5", "1371375", (GTA.Model) " FUTURE SHOCK SLAMVAN"),
      new VehicleWarehouse.VehicleData("SLAMVAN6", "1371375", (GTA.Model) " NIGHTMARE SLAMVAN"),
      new VehicleWarehouse.VehicleData("ZR380", "2138640", (GTA.Model) " APOCALYPSE ZR380"),
      new VehicleWarehouse.VehicleData("ZR3802", "2138640", (GTA.Model) " FUTURE SHOCK ZR380"),
      new VehicleWarehouse.VehicleData("ZR3803", "2138640", (GTA.Model) " NIGHTMARE ZR380"),
      new VehicleWarehouse.VehicleData("IMPERATOR", "2284940", (GTA.Model) " APOCALYPSE IMPERATOR"),
      new VehicleWarehouse.VehicleData("IMPERATOR2", "2284940", (GTA.Model) " FUTURE SHOCK IMPERATOR"),
      new VehicleWarehouse.VehicleData("IMPERATOR3", "2284940", (GTA.Model) " NIGHTMARE IMPERATOR"),
      new VehicleWarehouse.VehicleData("PARAGON2", "1350000", (GTA.Model) " ENUS PARAGON R (ARMORED)"),
      new VehicleWarehouse.VehicleData("JB700", "475000", (GTA.Model) " DEWBAUCHEE JB 700"),
      new VehicleWarehouse.VehicleData("MANANA", "8000", (GTA.Model) " ALBANY MANANA"),
      new VehicleWarehouse.VehicleData("MONROE", "490000", (GTA.Model) " PEGASSI MONROE"),
      new VehicleWarehouse.VehicleData("PEYOTE", "12000", (GTA.Model) " VAPID PEYOTE"),
      new VehicleWarehouse.VehicleData("STINGER", "1000000", (GTA.Model) " GROTTI STINGER"),
      new VehicleWarehouse.VehicleData("STINGERGT", "1100000", (GTA.Model) " GROTTI STINGER GT"),
      new VehicleWarehouse.VehicleData("TORNADO", "30000", (GTA.Model) " DECLASSE TORNADO"),
      new VehicleWarehouse.VehicleData("TORNADO2", "31000", (GTA.Model) " DECLASSE TORNADO"),
      new VehicleWarehouse.VehicleData("ZTYPE", "10000000", (GTA.Model) " TRUFFADE Z-TYPE"),
      new VehicleWarehouse.VehicleData("BTYPE", "750000", (GTA.Model) " ALBANY ROOSEVELT"),
      new VehicleWarehouse.VehicleData("PIGALLE", "400000", (GTA.Model) " LAMPADATI PIGALLE"),
      new VehicleWarehouse.VehicleData("COQUETTE2", "395000", (GTA.Model) " INVETERO COQUETTE CLASSIC"),
      new VehicleWarehouse.VehicleData("CASCO", "680000", (GTA.Model) " LAMPADATI CASCO"),
      new VehicleWarehouse.VehicleData("FELTZER3", "975000", (GTA.Model) " BENEFACTOR STIRLING GT"),
      new VehicleWarehouse.VehicleData("BTYPE2", "550000", (GTA.Model) " ALBANY FRANKEN STANGE"),
      new VehicleWarehouse.VehicleData("MAMBA", "995000", (GTA.Model) " DECLASSE MAMBA"),
      new VehicleWarehouse.VehicleData("BTYPE3", "1750000", (GTA.Model) " ALBANY ROOSEVELT VALOR"),
      new VehicleWarehouse.VehicleData("TORNADO6", "378000", (GTA.Model) " DECLASSE TORNADO RAT ROD"),
      new VehicleWarehouse.VehicleData("TORNADO5", "500000", (GTA.Model) " DECLASSE TORNADO CUSTOM"),
      new VehicleWarehouse.VehicleData("INFERNUS2", "900000", (GTA.Model) " PEGASSI INFERNUS CLASSIC"),
      new VehicleWarehouse.VehicleData("TURISMO2", "700000", (GTA.Model) " GROTTI TURISMO CLASSIC"),
      new VehicleWarehouse.VehicleData("ARDENT", "1150000", (GTA.Model) " OCELOT ARDENT"),
      new VehicleWarehouse.VehicleData("CHEETAH2", "865000", (GTA.Model) " GROTTI CHEETAH CLASSIC"),
      new VehicleWarehouse.VehicleData("TORERO", "998000", (GTA.Model) " PEGASSI TORERO"),
      new VehicleWarehouse.VehicleData("RAPIDGT3", "885000", (GTA.Model) " DEWBAUCHEE RAPID GT CLASSIC"),
      new VehicleWarehouse.VehicleData("RETINUE", "615000", (GTA.Model) " VAPID RETINUE"),
      new VehicleWarehouse.VehicleData("DELUXO", "4721500", (GTA.Model) " IMPONTE DELUXO"),
      new VehicleWarehouse.VehicleData("GT500", "785000", (GTA.Model) " GROTTI GT500"),
      new VehicleWarehouse.VehicleData("HERMES", "535000", (GTA.Model) " ALBANY HERMES"),
      new VehicleWarehouse.VehicleData("HUSTLER", "625000", (GTA.Model) " VAPID HUSTLER"),
      new VehicleWarehouse.VehicleData("SAVESTRA", "990000", (GTA.Model) " ANNIS SAVESTRA"),
      new VehicleWarehouse.VehicleData("STROMBERG", "3185350", (GTA.Model) " OCELOT STROMBERG"),
      new VehicleWarehouse.VehicleData("VISERIS", "875000", (GTA.Model) " LAMPADATI VISERIS"),
      new VehicleWarehouse.VehicleData("Z190", "900000", (GTA.Model) " KARIN 190Z"),
      new VehicleWarehouse.VehicleData("CHEBUREK", "145000", (GTA.Model) " RUNE CHEBUREK"),
      new VehicleWarehouse.VehicleData("JESTER3", "790000", (GTA.Model) " DINKA JESTER CLASSIC"),
      new VehicleWarehouse.VehicleData("MICHELLI", "1225000", (GTA.Model) " LAMPADA MICHELLI"),
      new VehicleWarehouse.VehicleData("FAGALOA", "335000", (GTA.Model) " VULCAR FAGALOA"),
      new VehicleWarehouse.VehicleData("STAFFORD", "1272000", (GTA.Model) " ENUS STAFFORD"),
      new VehicleWarehouse.VehicleData("SWINGER", "909000", (GTA.Model) " OCELOT SWINGER"),
      new VehicleWarehouse.VehicleData("DYNASTY", "450000", (GTA.Model) " WEENY DYNASTY"),
      new VehicleWarehouse.VehicleData("NEBULA", "797000", (GTA.Model) " VULCAR NEBULA TURBO"),
      new VehicleWarehouse.VehicleData("ZION3", "812000", (GTA.Model) " UBERMACHT ZION CLASSIC"),
      new VehicleWarehouse.VehicleData("JB7002", "1470000", (GTA.Model) " DEWBAUCHEE JB 700W"),
      new VehicleWarehouse.VehicleData("RETINUE2", "1620000", (GTA.Model) " VAPID RETINUE MK II"),
      new VehicleWarehouse.VehicleData("PEYOTE3", "658000", (GTA.Model) " VAPID PEYOTE CUSTOM"),
      new VehicleWarehouse.VehicleData("BLISTA", "16000", (GTA.Model) " DINKA BLISTA"),
      new VehicleWarehouse.VehicleData("DILETTANTE", "25000", (GTA.Model) " KARIN DILETTANTE"),
      new VehicleWarehouse.VehicleData("ISSI2", "18000", (GTA.Model) " WEENY ISSI"),
      new VehicleWarehouse.VehicleData("PRAIRIE", "25000", (GTA.Model) " BOLLOKAN PRAIRIE"),
      new VehicleWarehouse.VehicleData("BLISTA3", "42000", (GTA.Model) " GO GO MONKEY BLISTA"),
      new VehicleWarehouse.VehicleData("BLISTA2", "42000", (GTA.Model) " DINKA BLISTA COMPACT"),
      new VehicleWarehouse.VehicleData("RHAPSODY", "140000", (GTA.Model) " DECLASSE RHAPSODY"),
      new VehicleWarehouse.VehicleData("PANTO", "85000", (GTA.Model) " BENEFACTOR PANTO"),
      new VehicleWarehouse.VehicleData("BRIOSO", "155000", (GTA.Model) " GROTTI BRIOSO R/A"),
      new VehicleWarehouse.VehicleData("ISSI3", "360000", (GTA.Model) " WEENY ISSI CLASSIC"),
      new VehicleWarehouse.VehicleData("ASBO", "408000", (GTA.Model) " MAXWELL ASBO"),
      new VehicleWarehouse.VehicleData("KANJO", "580000", (GTA.Model) " DINKA BLISTA KANJO"),
      new VehicleWarehouse.VehicleData("CLUB", "1280000", (GTA.Model) " BF CLUB"),
      new VehicleWarehouse.VehicleData("COGCABRIO", "185000", (GTA.Model) " ENUS COGNOSCENTI CABRIO"),
      new VehicleWarehouse.VehicleData("EXEMPLAR", "205000", (GTA.Model) " DEWBAUCHEE EXEMPLAR"),
      new VehicleWarehouse.VehicleData("F620", "80000", (GTA.Model) " OCELOT F620"),
      new VehicleWarehouse.VehicleData("FELON", "100000", (GTA.Model) " LAMPADATI FELON"),
      new VehicleWarehouse.VehicleData("FELON2", "110000", (GTA.Model) " LAMPADATI FELON GT"),
      new VehicleWarehouse.VehicleData("JACKAL", "60000", (GTA.Model) " OCELOT JACKAL"),
      new VehicleWarehouse.VehicleData("ORACLE", "82000", (GTA.Model) " UBERMACHT ORACLE XS"),
      new VehicleWarehouse.VehicleData("ORACLE2", "80000", (GTA.Model) " UBERMACHT ORACLE"),
      new VehicleWarehouse.VehicleData("SENTINEL", "60000", (GTA.Model) " UBERMACHT SENTINEL XS"),
      new VehicleWarehouse.VehicleData("SENTINEL2", "95000", (GTA.Model) " UBERMACHT SENTINEL"),
      new VehicleWarehouse.VehicleData("ZION", "50000", (GTA.Model) " UBERMACHT ZION XS"),
      new VehicleWarehouse.VehicleData("ZION2", "60000", (GTA.Model) " UBERMACHT ZION CONVERTIBLE"),
      new VehicleWarehouse.VehicleData("WINDSOR", "845000", (GTA.Model) " ENUS WINDSOR"),
      new VehicleWarehouse.VehicleData("WINDSOR2", "900000", (GTA.Model) " ENUS WINDSOR DROP"),
      new VehicleWarehouse.VehicleData("ADDER", "1000000", (GTA.Model) " TRUFFADE ADDER"),
      new VehicleWarehouse.VehicleData("BULLET", "155000", (GTA.Model) " VAPID BULLET"),
      new VehicleWarehouse.VehicleData("CHEETAH", "650000", (GTA.Model) " GROTTI CHEETAH"),
      new VehicleWarehouse.VehicleData("ENTITYXF", "795000", (GTA.Model) " OVERFLOD ENTITY XF"),
      new VehicleWarehouse.VehicleData("INFERNUS", "440000", (GTA.Model) " PEGASSI INFERNUS"),
      new VehicleWarehouse.VehicleData("VACCA", "240000", (GTA.Model) " PEGASSI VACCA"),
      new VehicleWarehouse.VehicleData("VOLTIC", "150000", (GTA.Model) " COIL VOLTIC"),
      new VehicleWarehouse.VehicleData("TURISMOR", "500000", (GTA.Model) " GROTTI TURISMO R"),
      new VehicleWarehouse.VehicleData("ZENTORNO", "725000", (GTA.Model) " PEGASSI ZENTORNO"),
      new VehicleWarehouse.VehicleData("OSIRIS", "1950000", (GTA.Model) " PEGASSI OSIRIS"),
      new VehicleWarehouse.VehicleData("T20", "2200000", (GTA.Model) " PROGEN T20"),
      new VehicleWarehouse.VehicleData("BANSHEE2", "655000", (GTA.Model) " BRAVADO BANSHEE 900R"),
      new VehicleWarehouse.VehicleData("SULTANRS", "807000", (GTA.Model) " KARIN SULTAN RS"),
      new VehicleWarehouse.VehicleData("FMJ", "1750000", (GTA.Model) " VAPID FMJ"),
      new VehicleWarehouse.VehicleData("PFISTER811", "1135000", (GTA.Model) " PFISTER 811"),
      new VehicleWarehouse.VehicleData("PROTOTIPO", "2700000", (GTA.Model) " GROTTI X80 PROTO"),
      new VehicleWarehouse.VehicleData("REAPER", "1595000", (GTA.Model) " PEGASSI REAPER"),
      new VehicleWarehouse.VehicleData("TYRUS", "2550000", (GTA.Model) " PROGEN TYRUS"),
      new VehicleWarehouse.VehicleData("SHEAVA", "1995000", (GTA.Model) " EMPEROR ETR1"),
      new VehicleWarehouse.VehicleData("LE7B", "2475000", (GTA.Model) " ANNIS RE-7B"),
      new VehicleWarehouse.VehicleData("ITALIGTB", "4550000", (GTA.Model) " PROGEN ITALI GTB"),
      new VehicleWarehouse.VehicleData("ITALIGTB2", "1684000", (GTA.Model) " PROGEN ITALI GTB CUSTOM"),
      new VehicleWarehouse.VehicleData("NERO", "1440000", (GTA.Model) " TRUFFADE NERO"),
      new VehicleWarehouse.VehicleData("NERO2", "2045000", (GTA.Model) " TRUFFADE NERO CUSTOM"),
      new VehicleWarehouse.VehicleData("PENETRATOR", "880000", (GTA.Model) " OCELOT PENETRATOR"),
      new VehicleWarehouse.VehicleData("TEMPESTA", "1329000", (GTA.Model) " PEGASSI TEMPESTA"),
      new VehicleWarehouse.VehicleData("VOLTIC2", "3830400", (GTA.Model) " COIL ROCKET VOLTIC"),
      new VehicleWarehouse.VehicleData("GP1", "1260000", (GTA.Model) " PROGEN GP1"),
      new VehicleWarehouse.VehicleData("VAGNER", "1535000", (GTA.Model) " DEWBAUCHEE VAGNER"),
      new VehicleWarehouse.VehicleData("XA21", "2375000", (GTA.Model) " OCELOT XA-21"),
      new VehicleWarehouse.VehicleData("CYCLONE", "1890000", (GTA.Model) " COIL CYCLONE"),
      new VehicleWarehouse.VehicleData("VIGILANTE", "3750000", (GTA.Model) " VIGILANTE"),
      new VehicleWarehouse.VehicleData("VISIONE", "2250000", (GTA.Model) " GROTTI VISIONE"),
      new VehicleWarehouse.VehicleData("AUTARCH", "1955000", (GTA.Model) " OVERFLOD AUTARCH"),
      new VehicleWarehouse.VehicleData("SC1", "1603000", (GTA.Model) " UBERMACHT SC1"),
      new VehicleWarehouse.VehicleData("ENTITY2", "2305000", (GTA.Model) " OVERFLOD ENTITY XXR"),
      new VehicleWarehouse.VehicleData("TYRANT", "2515000", (GTA.Model) " OVERFLOD TYRANT"),
      new VehicleWarehouse.VehicleData("TEZERACT", "2825000", (GTA.Model) " PEGASSI TEZERACT"),
      new VehicleWarehouse.VehicleData("TAIPAN", "1980000", (GTA.Model) " CHEVAL TAIPAN"),
      new VehicleWarehouse.VehicleData("SCRAMJET", "4628400", (GTA.Model) " DECLASSE SCRAMJET"),
      new VehicleWarehouse.VehicleData("DEVESTE", "1795000", (GTA.Model) " PRINCIPLE DEVESTE EIGHT"),
      new VehicleWarehouse.VehicleData("ITALIGTO", "1965000", (GTA.Model) " GROTTI ITALI GTO"),
      new VehicleWarehouse.VehicleData("EMERUS", "2750000", (GTA.Model) " PROGEN EMERUS"),
      new VehicleWarehouse.VehicleData("KRIEGER", "2875000", (GTA.Model) " BENEFACTOR KRIEGER"),
      new VehicleWarehouse.VehicleData("NEO", "1875000", (GTA.Model) " VYSSER NEO"),
      new VehicleWarehouse.VehicleData("S80", "2575000", (GTA.Model) " ANNIS S80RR"),
      new VehicleWarehouse.VehicleData("THRAX", "2325000", (GTA.Model) " TRUFFADE THRAX"),
      new VehicleWarehouse.VehicleData("ZORRUSSO", "1925000", (GTA.Model) " PEGASSI ZORRUSSO"),
      new VehicleWarehouse.VehicleData("FURIA", "2740000", (GTA.Model) " GROTTI FURIA"),
      new VehicleWarehouse.VehicleData("TIGON", "2310000", (GTA.Model) " LAMPADATI TIGON"),
      new VehicleWarehouse.VehicleData("AKUMA", "9000", (GTA.Model) " DINKA AKUMA"),
      new VehicleWarehouse.VehicleData("BAGGER", "7000", (GTA.Model) " WMC BAGGER"),
      new VehicleWarehouse.VehicleData("BATI", "10000", (GTA.Model) " PEGASSI BATI 801"),
      new VehicleWarehouse.VehicleData("BATI2", "15000", (GTA.Model) " PEGASSI BATI 801RR"),
      new VehicleWarehouse.VehicleData("CARBONRS", "40000", (GTA.Model) " NAGASAKI CARBON RS"),
      new VehicleWarehouse.VehicleData("DAEMON", "20000", (GTA.Model) " WMC DAEMON"),
      new VehicleWarehouse.VehicleData("DOUBLE", "12000", (GTA.Model) " DINKA DOUBLE-T"),
      new VehicleWarehouse.VehicleData("FAGGIO2", "5000", (GTA.Model) " PRINCIPE FAGGIO"),
      new VehicleWarehouse.VehicleData("HEXER", "15000", (GTA.Model) " LCC HEXER"),
      new VehicleWarehouse.VehicleData("NEMESIS", "12000", (GTA.Model) " PRINCIPE NEMESIS"),
      new VehicleWarehouse.VehicleData("PCJ", "9000", (GTA.Model) " SHITZU PCJ-600"),
      new VehicleWarehouse.VehicleData("RUFFIAN", "10000", (GTA.Model) " PEGASSI RUFFIAN"),
      new VehicleWarehouse.VehicleData("SANCHEZ", "7000", (GTA.Model) " MAIBATSU SANCHEZ"),
      new VehicleWarehouse.VehicleData("SANCHEZ2", "8000", (GTA.Model) " MAIBATSU SANCHEZ"),
      new VehicleWarehouse.VehicleData("VADER", "9000", (GTA.Model) " SHITZU VADER"),
      new VehicleWarehouse.VehicleData("THRUST", "75000", (GTA.Model) " DINKA THRUST"),
      new VehicleWarehouse.VehicleData("SOVEREIGN", "120000", (GTA.Model) " WMC SOVEREIGN"),
      new VehicleWarehouse.VehicleData("INNOVATION", "92500", (GTA.Model) " LCC INNOVATION"),
      new VehicleWarehouse.VehicleData("HAKUCHOU", "82000", (GTA.Model) " SHITZU HAKUCHOU"),
      new VehicleWarehouse.VehicleData("ENDURO", "48000", (GTA.Model) " DINKA ENDURO"),
      new VehicleWarehouse.VehicleData("LECTRO", "750000", (GTA.Model) " PRINCIPE LECTRO"),
      new VehicleWarehouse.VehicleData("VINDICATOR", "630000", (GTA.Model) " DINKA VINDICATOR"),
      new VehicleWarehouse.VehicleData("GARGOYLE", "120000", (GTA.Model) " WESTERN GARGOYLE"),
      new VehicleWarehouse.VehicleData("CLIFFHANGER", "145000", (GTA.Model) " WESTERN CLIFFHANGER"),
      new VehicleWarehouse.VehicleData("BF400", "95000", (GTA.Model) " NAGASAKI BF400"),
      new VehicleWarehouse.VehicleData("AVARUS", "116000", (GTA.Model) " LCC AVARUS"),
      new VehicleWarehouse.VehicleData("CHIMERA", "210000", (GTA.Model) " NAGASAKI CHIMERA"),
      new VehicleWarehouse.VehicleData("DAEMON2", "20000", (GTA.Model) " WMC DAEMON"),
      new VehicleWarehouse.VehicleData("DEFILER", "412000", (GTA.Model) " SHITZU DEFILER"),
      new VehicleWarehouse.VehicleData("ESSKEY", "264000", (GTA.Model) " PEGASSI ESSKEY"),
      new VehicleWarehouse.VehicleData("FAGGIO", "47500", (GTA.Model) " PEGASSI FAGGIO SPORT"),
      new VehicleWarehouse.VehicleData("FAGGIO3", "55000", (GTA.Model) " PEGASSI FAGGIO MOD"),
      new VehicleWarehouse.VehicleData("HAKUCHOU2", "976000", (GTA.Model) " SHITZU HAKUCHOU DRAG"),
      new VehicleWarehouse.VehicleData("MANCHEZ", "67000", (GTA.Model) " MAIBATSU MANCHEZ"),
      new VehicleWarehouse.VehicleData("NIGHTBLADE", "116000", (GTA.Model) " WMC NIGHTBLADE"),
      new VehicleWarehouse.VehicleData("RATBIKE", "48000", (GTA.Model) " WMC RAT BIKE"),
      new VehicleWarehouse.VehicleData("SANCTUS", "1995000", (GTA.Model) " LCC SANCTUS"),
      new VehicleWarehouse.VehicleData("SHOTARO", "2375000", (GTA.Model) " NAGASAKI SHOTARO"),
      new VehicleWarehouse.VehicleData("VORTEX", "356000", (GTA.Model) " PEGASSI VORTEX"),
      new VehicleWarehouse.VehicleData("WOLFSBANE", "95000", (GTA.Model) " WMC WOLFSBANE"),
      new VehicleWarehouse.VehicleData("ZOMBIEA", "99000", (GTA.Model) " WMC ZOMBIE BOBBER"),
      new VehicleWarehouse.VehicleData("ZOMBIEB", "122000", (GTA.Model) " WMC ZOMBIE CHOPPER"),
      new VehicleWarehouse.VehicleData("DIABLOUS", "169000", (GTA.Model) " PRINCIPE DIABLOUS"),
      new VehicleWarehouse.VehicleData("DIABLOUS2", "1169000", (GTA.Model) " PRINCIPE DIABLOUS"),
      new VehicleWarehouse.VehicleData("FCR", "155000", (GTA.Model) " PEGASSI FCR 1000"),
      new VehicleWarehouse.VehicleData("FCR2", "1155000", (GTA.Model) " PEGASSI FCR 1000 CUSTOM"),
      new VehicleWarehouse.VehicleData("OPPRESSOR", "3524500", (GTA.Model) " PEGASSI OPPRESSOR"),
      new VehicleWarehouse.VehicleData("OPPRESSOR2", "3890250", (GTA.Model) " PEGASSI OPPRESSOR MK II"),
      new VehicleWarehouse.VehicleData("RROCKET", "925000", (GTA.Model) " WMC RAMPANT ROCKET"),
      new VehicleWarehouse.VehicleData("STRYDER", "670000", (GTA.Model) " NAGASAKI STRYDER"),
      new VehicleWarehouse.VehicleData("BUCCANEER", "28000", (GTA.Model) " ALBANY BUCCANEER"),
      new VehicleWarehouse.VehicleData("DOMINATOR", "35000", (GTA.Model) " VAPID DOMINATOR"),
      new VehicleWarehouse.VehicleData("GAUNTLET", "32000", (GTA.Model) " BRAVADO GAUNTLET"),
      new VehicleWarehouse.VehicleData("HOTKNIFE", "90000", (GTA.Model) " VAPID HOTKNIFE"),
      new VehicleWarehouse.VehicleData("PHOENIX", "20000", (GTA.Model) " IMPONTE PHOENIX"),
      new VehicleWarehouse.VehicleData("PICADOR", "9000", (GTA.Model) " CHEVAL PICADOR"),
      new VehicleWarehouse.VehicleData("RUINER", "10000", (GTA.Model) " IMPONTE RUINER"),
      new VehicleWarehouse.VehicleData("SABREGT", "15000", (GTA.Model) " DECLASSE SABRE TURBO"),
      new VehicleWarehouse.VehicleData("VIGERO", "21000", (GTA.Model) " DECLASSE VIGERO"),
      new VehicleWarehouse.VehicleData("BUFFALO3", "96000", (GTA.Model) " SPRUNK BUFFALO"),
      new VehicleWarehouse.VehicleData("DUKES", "279000", (GTA.Model) " IMPONTE DUKES"),
      new VehicleWarehouse.VehicleData("STALION", "71000", (GTA.Model) " DECLASSE STALLION"),
      new VehicleWarehouse.VehicleData("STALION2", "71000", (GTA.Model) " DECLASSE STALLION RACING"),
      new VehicleWarehouse.VehicleData("DOMINATOR2", "35000", (GTA.Model) " VAPID DOMINATOR RACING"),
      new VehicleWarehouse.VehicleData("GAUNTLET2", "32000", (GTA.Model) " REDWOOD GAUNTLET"),
      new VehicleWarehouse.VehicleData("BLADE", "160000", (GTA.Model) " VAPID BLADE"),
      new VehicleWarehouse.VehicleData("RATLOADER2", "37500", (GTA.Model) " BRAVADO RAT-TRUCK"),
      new VehicleWarehouse.VehicleData("SLAMVAN", "49500", (GTA.Model) " VAPID SLAMVAN"),
      new VehicleWarehouse.VehicleData("VOODOO2", "5000", (GTA.Model) " DECLASSE VOODOO"),
      new VehicleWarehouse.VehicleData("VIRGO", "195000", (GTA.Model) " ALBANY VIRGO"),
      new VehicleWarehouse.VehicleData("COQUETTE3", "695000", (GTA.Model) " INVETERO COQUETTE BLACKFIN"),
      new VehicleWarehouse.VehicleData("CHINO", "225000", (GTA.Model) " VAPID CHINO"),
      new VehicleWarehouse.VehicleData("FACTION", "36000", (GTA.Model) " WILLARD FACTION"),
      new VehicleWarehouse.VehicleData("LURCHER", "650000", (GTA.Model) " ALBANY LURCHER"),
      new VehicleWarehouse.VehicleData("NIGHTSHADE", "585000", (GTA.Model) " IMPONTE NIGHTSHADE"),
      new VehicleWarehouse.VehicleData("TAMPA", "375000", (GTA.Model) " DECLASSE TAMPA"),
      new VehicleWarehouse.VehicleData("VIRGO3", "165000", (GTA.Model) " DUNDREARY VIRGO CLASSIC"),
      new VehicleWarehouse.VehicleData("RUINER2", "5745600", (GTA.Model) " IMPONTE RUINER 2000"),
      new VehicleWarehouse.VehicleData("BUCCANEER2", "419000", (GTA.Model) " ALBANY BUCCANEER"),
      new VehicleWarehouse.VehicleData("CHINO2", "405000", (GTA.Model) " VAPID CHINO"),
      new VehicleWarehouse.VehicleData("FACTION2", "371000", (GTA.Model) " WILLARD FACTION"),
      new VehicleWarehouse.VehicleData("MOONBEAM2", "402500", (GTA.Model) " DECLASSE MOONBEAM"),
      new VehicleWarehouse.VehicleData("VOODOO", "425500", (GTA.Model) " DECLASSE VOODOO"),
      new VehicleWarehouse.VehicleData("FACTION3", "371000", (GTA.Model) " WILLARD FACTION CUSTOM DONK"),
      new VehicleWarehouse.VehicleData("SABREGT2", "500000", (GTA.Model) " DECLASSE SABRE TURBO CUSTOM"),
      new VehicleWarehouse.VehicleData("SLAMVAN3", "443750", (GTA.Model) " VAPID SLAMVAN CUSTOM"),
      new VehicleWarehouse.VehicleData("VIRGO2", "405000", (GTA.Model) " DUNDREARY VIRGO CLASSIC CUSTOM"),
      new VehicleWarehouse.VehicleData("YOSEMITE", "485000", (GTA.Model) " DECLASSE YOSEMITE"),
      new VehicleWarehouse.VehicleData("ELLIE", "565000", (GTA.Model) " VAPID ELLIE"),
      new VehicleWarehouse.VehicleData("DOMINATOR3", "725000", (GTA.Model) " VAPID DOMINATOR GTX"),
      new VehicleWarehouse.VehicleData("CLIQUE", "909000", (GTA.Model) " VAPID CLIQUE"),
      new VehicleWarehouse.VehicleData("DEVIANT", "512000", (GTA.Model) " SCHYSTER DEVIANT"),
      new VehicleWarehouse.VehicleData("IMPALER", "331835", (GTA.Model) " DECLASSE IMPALER"),
      new VehicleWarehouse.VehicleData("TULIP", "718000", (GTA.Model) " DECLASSE TULIP"),
      new VehicleWarehouse.VehicleData("VAMOS", "596000", (GTA.Model) " DECLASSE VAMOS"),
      new VehicleWarehouse.VehicleData("GAUNTLET3", "615000", (GTA.Model) " BRAVADO GAUNTLET CLASSIC"),
      new VehicleWarehouse.VehicleData("GAUNTLET4", "745000", (GTA.Model) " BRAVADO GAUNTLET HELLFIRE"),
      new VehicleWarehouse.VehicleData("PEYOTE2", "805000", (GTA.Model) " VAPID PEYOTE GASSER"),
      new VehicleWarehouse.VehicleData("YOSEMITE2", "1308000", (GTA.Model) " DECLASSE DRIFT YOSEMITE"),
      new VehicleWarehouse.VehicleData("DUKES3", "378000", (GTA.Model) " IMPONTE BEATER DUKES"),
      new VehicleWarehouse.VehicleData("GAUNTLET5", "815000", (GTA.Model) " BRAVADO GAUNTLET CLASSIC CUSTOM"),
      new VehicleWarehouse.VehicleData("MANANA2", "935000", (GTA.Model) " ALBANY MANANA CUSTOM"),
      new VehicleWarehouse.VehicleData("BLAZER", "8000", (GTA.Model) " NAGASAKI BLAZER"),
      new VehicleWarehouse.VehicleData("BLAZER2", "9000", (GTA.Model) " NAGASAKI BLAZER LIFEGUARD"),
      new VehicleWarehouse.VehicleData("BLAZER3", "69000", (GTA.Model) " HOT ROD BLAZER"),
      new VehicleWarehouse.VehicleData("BFINJECTION", "16000", (GTA.Model) " BF INJECTION"),
      new VehicleWarehouse.VehicleData("BODHI2", "25000", (GTA.Model) " CANIS BODHI"),
      new VehicleWarehouse.VehicleData("DUNE", "20000", (GTA.Model) " BURGERFAHRZEUG DUNE BUGGY"),
      new VehicleWarehouse.VehicleData("DLOADER", "15000", (GTA.Model) " BRAVADO DUNELOADER"),
      new VehicleWarehouse.VehicleData("MESA3", "90000", (GTA.Model) " MERRYWEATHER MESA"),
      new VehicleWarehouse.VehicleData("RANCHERXL", "9000", (GTA.Model) " DECLASSE RANCHER XL"),
      new VehicleWarehouse.VehicleData("REBEL2", "22000", (GTA.Model) " KARIN REBEL"),
      new VehicleWarehouse.VehicleData("SANDKING", "45000", (GTA.Model) " VAPID SANDKING XL"),
      new VehicleWarehouse.VehicleData("SANDKING2", "38000", (GTA.Model) " VAPID SANDKING SWB"),
      new VehicleWarehouse.VehicleData("MARSHALL", "250000", (GTA.Model) " CHEVAL MARSHALL"),
      new VehicleWarehouse.VehicleData("BIFTA", "75000", (GTA.Model) " BURGERFAHRZEUG BIFTA"),
      new VehicleWarehouse.VehicleData("KALAHARI", "51000", (GTA.Model) " CANIS KALAHARI"),
      new VehicleWarehouse.VehicleData("DUBSTA3", "249000", (GTA.Model) " BENEFACTOR DUBSTA 6X6"),
      new VehicleWarehouse.VehicleData("MONSTER", "742014", (GTA.Model) " VAPID THE LIBERATOR"),
      new VehicleWarehouse.VehicleData("BRAWLER", "715000", (GTA.Model) " COIL BRAWLER"),
      new VehicleWarehouse.VehicleData("TROPHYTRUCK", "550000", (GTA.Model) " VAPID TROPHY TRUCK"),
      new VehicleWarehouse.VehicleData("TROPHYTRUCK2", "695000", (GTA.Model) " VAPID DESERT RAID"),
      new VehicleWarehouse.VehicleData("BLAZER4", "81000", (GTA.Model) " NAGASAKI STREET BLAZER"),
      new VehicleWarehouse.VehicleData("BLAZER5", "1755600", (GTA.Model) " NAGASAKI BLAZER AQUA"),
      new VehicleWarehouse.VehicleData("DUNE4", "3192000", (GTA.Model) " BURGERFAHRZEUG DUNE RAMP BUGGY"),
      new VehicleWarehouse.VehicleData("DUNE5", "3192000", (GTA.Model) " BURGERFAHRZEUG DUNE RAMP BUGGY"),
      new VehicleWarehouse.VehicleData("KAMACHO", "345000", (GTA.Model) " CANIS KAMACHO"),
      new VehicleWarehouse.VehicleData("RIATA", "380000", (GTA.Model) " VAPID RIATA"),
      new VehicleWarehouse.VehicleData("FREECRAWLER", "597000", (GTA.Model) " CANIS FREECRAWLER"),
      new VehicleWarehouse.VehicleData("CARACARA2", "875000", (GTA.Model) " VAPID CARACARA 4X4"),
      new VehicleWarehouse.VehicleData("HELLION", "835000", (GTA.Model) " ANNIS HELLION"),
      new VehicleWarehouse.VehicleData("EVERON", "1475000", (GTA.Model) " KARIN EVERON"),
      new VehicleWarehouse.VehicleData("OUTLAW", "1268000", (GTA.Model) " NAGASAKI OUTLAW"),
      new VehicleWarehouse.VehicleData("VAGRANT", "2214000", (GTA.Model) " MAXWELL VAGRANT"),
      new VehicleWarehouse.VehicleData("ZHABA", "2400000", (GTA.Model) " RUNE ZHABA"),
      new VehicleWarehouse.VehicleData("YOSEMITE3", "700000", (GTA.Model) " DECLASSE YOSEMITE RANCHER"),
      new VehicleWarehouse.VehicleData("FORMULA", "3515000", (GTA.Model) " PROGEN PR4"),
      new VehicleWarehouse.VehicleData("FORMULA2", "3115000", (GTA.Model) " OCELOT R88"),
      new VehicleWarehouse.VehicleData("OPENWHEEL1", "3400000", (GTA.Model) " BENEFACTOR BR8"),
      new VehicleWarehouse.VehicleData("OPENWHEEL2", "2997000", (GTA.Model) " DECLASSE DR1"),
      new VehicleWarehouse.VehicleData("ASEA", "12000", (GTA.Model) " DECLASSE ASEA"),
      new VehicleWarehouse.VehicleData("ASTEROPE", "26000", (GTA.Model) " KARIN ASTEROPE"),
      new VehicleWarehouse.VehicleData("EMPEROR", "42000", (GTA.Model) " ALBANY EMPEROR"),
      new VehicleWarehouse.VehicleData("FUGITIVE", "24000", (GTA.Model) " CHEVAL FUGITIVE"),
      new VehicleWarehouse.VehicleData("INTRUDER", "16000", (GTA.Model) " KARIN INTRUDER"),
      new VehicleWarehouse.VehicleData("PREMIER", "10000", (GTA.Model) " DECLASSE PREMIER"),
      new VehicleWarehouse.VehicleData("PRIMO", "9000", (GTA.Model) " ALBANY PRIMO"),
      new VehicleWarehouse.VehicleData("SCHAFTER2", "65000", (GTA.Model) " BENEFACTOR SCHAFTER"),
      new VehicleWarehouse.VehicleData("STANIER", "10000", (GTA.Model) " VAPID STANIER"),
      new VehicleWarehouse.VehicleData("STRETCH", "30000", (GTA.Model) " ALBANY STRETCH"),
      new VehicleWarehouse.VehicleData("SUPERD", "250000", (GTA.Model) " ENUS SUPER DIAMOND"),
      new VehicleWarehouse.VehicleData("SURGE", "38000", (GTA.Model) " CHEVAL SURGE"),
      new VehicleWarehouse.VehicleData("TAILGATER", "55000", (GTA.Model) " OBEY TAILGATER"),
      new VehicleWarehouse.VehicleData("WASHINGTON", "15000", (GTA.Model) " ALBANY WASHINGTON"),
      new VehicleWarehouse.VehicleData("WARRENER", "120000", (GTA.Model) " VULCAR WARRENER"),
      new VehicleWarehouse.VehicleData("GLENDALE", "200000", (GTA.Model) " BENEFACTOR GLENDALE"),
      new VehicleWarehouse.VehicleData("INGOT", "9000", (GTA.Model) " VULCAR INGOT"),
      new VehicleWarehouse.VehicleData("REGINA", "8000", (GTA.Model) " DUNDREARY REGINA"),
      new VehicleWarehouse.VehicleData("ROMERO", "35000", (GTA.Model) " CHARIOT ROMERO"),
      new VehicleWarehouse.VehicleData("STRATUM", "10000", (GTA.Model) " ZIRCONIUM STRATUM"),
      new VehicleWarehouse.VehicleData("COG55", "154000", (GTA.Model) " ENUS COGNOSCENTI 55"),
      new VehicleWarehouse.VehicleData("COGNOSCENTI", "254000", (GTA.Model) " ENUS COGNOSCENTI"),
      new VehicleWarehouse.VehicleData("PRIMO2", "409000", (GTA.Model) " ALBANY PRIMO"),
      new VehicleWarehouse.VehicleData("GLENDALE2", "720000", (GTA.Model) " BENEFACTOR GLENDALE CUSTOM"),
      new VehicleWarehouse.VehicleData("BANSHEE", "90000", (GTA.Model) " BRAVADO BANSHEE"),
      new VehicleWarehouse.VehicleData("BUFFALO", "35000", (GTA.Model) " BRAVADO BUFFALO"),
      new VehicleWarehouse.VehicleData("BUFFALO2", "96000", (GTA.Model) " BRAVADO BUFFALO S"),
      new VehicleWarehouse.VehicleData("CARBONIZZARE", "195000", (GTA.Model) " GROTTI CARBONIZZARE"),
      new VehicleWarehouse.VehicleData("COMET2", "100000", (GTA.Model) " PFISTER COMET"),
      new VehicleWarehouse.VehicleData("COQUETTE", "138000", (GTA.Model) " INVETERO COQUETTE"),
      new VehicleWarehouse.VehicleData("ELEGY2", "95000", (GTA.Model) " ANNIS ELEGY RH8"),
      new VehicleWarehouse.VehicleData("FELTZER2", "145000", (GTA.Model) " BENEFACTOR FELTZER"),
      new VehicleWarehouse.VehicleData("FUSILADE", "36000", (GTA.Model) " SCHYSTER FUSILADE"),
      new VehicleWarehouse.VehicleData("FUTO", "9000", (GTA.Model) " KARIN FUTO"),
      new VehicleWarehouse.VehicleData("KHAMELION", "100000", (GTA.Model) " HIJAK KHAMELION"),
      new VehicleWarehouse.VehicleData("NINEF", "120000", (GTA.Model) " OBEY 9F"),
      new VehicleWarehouse.VehicleData("NINEF2", "130000", (GTA.Model) " OBEY 9F CABRIO"),
      new VehicleWarehouse.VehicleData("PENUMBRA", "24000", (GTA.Model) " MAIBATSU PENUMBRA"),
      new VehicleWarehouse.VehicleData("RAPIDGT", "132000", (GTA.Model) " DEWBAUCHEE RAPID GT"),
      new VehicleWarehouse.VehicleData("RAPIDGT2", "140000", (GTA.Model) " DEWBAUCHEE RAPID GT CONVERTIBLE"),
      new VehicleWarehouse.VehicleData("SCHWARZER", "80000", (GTA.Model) " BENEFACTOR SCHWARTZER"),
      new VehicleWarehouse.VehicleData("SULTAN", "12000", (GTA.Model) " KARIN SULTAN"),
      new VehicleWarehouse.VehicleData("SURANO", "99000", (GTA.Model) " BENEFACTOR SURANO"),
      new VehicleWarehouse.VehicleData("JESTER", "240000", (GTA.Model) " DINKA JESTER"),
      new VehicleWarehouse.VehicleData("ALPHA", "150000", (GTA.Model) " ALBANY ALPHA"),
      new VehicleWarehouse.VehicleData("MASSACRO", "275000", (GTA.Model) " DEWBAUCHEE MASSACRO"),
      new VehicleWarehouse.VehicleData("FUROREGT", "448000", (GTA.Model) " LAMPADATI FURORE GT"),
      new VehicleWarehouse.VehicleData("JESTER2", "385000", (GTA.Model) " DINKA JESTER RACING"),
      new VehicleWarehouse.VehicleData("MASSACRO2", "385000", (GTA.Model) " DEWBAUCHEE MASSACRO RACING"),
      new VehicleWarehouse.VehicleData("KURUMA", "95000", (GTA.Model) " KARIN KURUMA"),
      new VehicleWarehouse.VehicleData("VERLIERER2", "695000", (GTA.Model) " BRAVADO VERLIERER"),
      new VehicleWarehouse.VehicleData("SCHAFTER4", "208000", (GTA.Model) " BENEFACTOR SCHAFTER LWB"),
      new VehicleWarehouse.VehicleData("SCHAFTER3", "116000", (GTA.Model) " BENEFACTOR SCHAFTER V12"),
      new VehicleWarehouse.VehicleData("BESTIAGTS", "610000", (GTA.Model) " GROTTI BESTIA GTS"),
      new VehicleWarehouse.VehicleData("SEVEN70", "695000", (GTA.Model) " DEWBAUCHEE SEVEN 70"),
      new VehicleWarehouse.VehicleData("LYNX", "801000", (GTA.Model) " OCELOT LYNX"),
      new VehicleWarehouse.VehicleData("OMNIS", "701000", (GTA.Model) " OBEY OMNIS"),
      new VehicleWarehouse.VehicleData("TROPOS", "816000", (GTA.Model) " LAMPADATI TROPOS RALLYE"),
      new VehicleWarehouse.VehicleData("TAMPA2", "750000", (GTA.Model) " DECLASSE DRIFT TAMPA"),
      new VehicleWarehouse.VehicleData("RAPTOR", "648000", (GTA.Model) " BF RAPTOR"),
      new VehicleWarehouse.VehicleData("COMET3", "2100000", (GTA.Model) " PFISTER COMET RETRO CUSTOM"),
      new VehicleWarehouse.VehicleData("ELEGY", "970000", (GTA.Model) " ANNIS ELEGY RETRO CUSTOM"),
      new VehicleWarehouse.VehicleData("SPECTER", "932000", (GTA.Model) " DEWBAUCHEE SPECTER"),
      new VehicleWarehouse.VehicleData("SPECTER2", "2932000", (GTA.Model) " DEWBAUCHEE SPECTER CUSTOM"),
      new VehicleWarehouse.VehicleData("RUSTON", "400000", (GTA.Model) " HIJAK RUSTON"),
      new VehicleWarehouse.VehicleData("COMET4", "710000", (GTA.Model) " PFISTER COMET SAFARI"),
      new VehicleWarehouse.VehicleData("COMET5", "1145000", (GTA.Model) " PFISTER COMET SR"),
      new VehicleWarehouse.VehicleData("NEON", "1500000", (GTA.Model) " PFISTER NEON"),
      new VehicleWarehouse.VehicleData("PARIAH", "1420000", (GTA.Model) " OCELOT PARIAH"),
      new VehicleWarehouse.VehicleData("RAIDEN", "1375000", (GTA.Model) " COIL RAIDEN"),
      new VehicleWarehouse.VehicleData("REVOLTER", "1610000", (GTA.Model) " UBERMACHT REVOLTER"),
      new VehicleWarehouse.VehicleData("SENTINEL3", "650000", (GTA.Model) " UBERMACHT SENTINEL CLASSIC"),
      new VehicleWarehouse.VehicleData("HOTRING", "830000", (GTA.Model) " DECLASSE HOTRING SABRE"),
      new VehicleWarehouse.VehicleData("FLASHGT", "1675000", (GTA.Model) " VAPID FLASH GT"),
      new VehicleWarehouse.VehicleData("GB200", "940000", (GTA.Model) " VAPID GB200"),
      new VehicleWarehouse.VehicleData("SCHLAGEN", "1300000", (GTA.Model) " BENEFACTOR SCHLAGEN GT"),
      new VehicleWarehouse.VehicleData("DRAFTER", "718000", (GTA.Model) " OBEY 8F DRAFTER"),
      new VehicleWarehouse.VehicleData("ISSI7", "897000", (GTA.Model) " WEENY ISSI SPORT"),
      new VehicleWarehouse.VehicleData("JUGULAR", "1225000", (GTA.Model) " OCELOT JUGULAR"),
      new VehicleWarehouse.VehicleData("LOCUST", "1625000", (GTA.Model) " OCELOT LOCUST"),
      new VehicleWarehouse.VehicleData("PARAGON", "905000", (GTA.Model) " ENUS PARAGON R"),
      new VehicleWarehouse.VehicleData("IMORGON", "2165000", (GTA.Model) " ÖVERFLÖD IMORGON"),
      new VehicleWarehouse.VehicleData("KOMODA", "1700000", (GTA.Model) " LAMPADATI KOMODA"),
      new VehicleWarehouse.VehicleData("SUGOI", "1224000", (GTA.Model) " DINKA SUGOI"),
      new VehicleWarehouse.VehicleData("SULTAN2", "1718000", (GTA.Model) " KARIN SULTAN CLASSIC"),
      new VehicleWarehouse.VehicleData("VSTR", "1285000", (GTA.Model) " ALBANY V-STR"),
      new VehicleWarehouse.VehicleData("COQUETTE4", "1510000", (GTA.Model) " INVETERO COQUETTE D10"),
      new VehicleWarehouse.VehicleData("PENUMBRA2", "1380000", (GTA.Model) " MAIBATSU PENUMBRA FF"),
      new VehicleWarehouse.VehicleData("BALLER", "70000", (GTA.Model) " GALLIVANTER BALLER"),
      new VehicleWarehouse.VehicleData("BALLER2", "90000", (GTA.Model) " GALLIVANTER BALLER SPORT"),
      new VehicleWarehouse.VehicleData("BJXL", "27000", (GTA.Model) " KARIN BEEJAY XL"),
      new VehicleWarehouse.VehicleData("CAVALCADE", "60000", (GTA.Model) " ALBANY CAVALCADE FXT"),
      new VehicleWarehouse.VehicleData("CAVALCADE2", "70000", (GTA.Model) " ALBANY CAVALCADE"),
      new VehicleWarehouse.VehicleData("DUBSTA", "70000", (GTA.Model) " BENEFACTOR DUBSTA"),
      new VehicleWarehouse.VehicleData("DUBSTA2", "165000", (GTA.Model) " BENEFACTOR DUBSTA BLACK"),
      new VehicleWarehouse.VehicleData("FQ2", "50000", (GTA.Model) " FATHOM FQ 2"),
      new VehicleWarehouse.VehicleData("GRANGER", "35000", (GTA.Model) " DECLASSE GRANGER"),
      new VehicleWarehouse.VehicleData("GRESLEY", "29000", (GTA.Model) " BRAVADO GRESLEY"),
      new VehicleWarehouse.VehicleData("HABANERO", "42000", (GTA.Model) " EMPEROR HABANERO"),
      new VehicleWarehouse.VehicleData("LANDSTALKER", "58000", (GTA.Model) " DUNDREARY LANSTALKER"),
      new VehicleWarehouse.VehicleData("MESA", "87000", (GTA.Model) " CANIS MESA"),
      new VehicleWarehouse.VehicleData("PATRIOT", "50000", (GTA.Model) " MAMMOTH PATRIOT"),
      new VehicleWarehouse.VehicleData("RADI", "32000", (GTA.Model) " VAPID RADIUS"),
      new VehicleWarehouse.VehicleData("ROCOTO", "85000", (GTA.Model) " OBEY ROCOTO"),
      new VehicleWarehouse.VehicleData("SEMINOLE", "30000", (GTA.Model) " CANIS SEMINOLE"),
      new VehicleWarehouse.VehicleData("SERRANO", "60000", (GTA.Model) " BENEFACTOR SERRANO"),
      new VehicleWarehouse.VehicleData("HUNTLEY", "195000", (GTA.Model) " ENUS HUNTLEY S"),
      new VehicleWarehouse.VehicleData("BALLER3", "149000", (GTA.Model) " GALLIVANTER BALLER LE"),
      new VehicleWarehouse.VehicleData("BALLER4", "247000", (GTA.Model) " GALLIVANTER BALLER LE LWB"),
      new VehicleWarehouse.VehicleData("XLS", "253000", (GTA.Model) " BENEFACTOR XLS"),
      new VehicleWarehouse.VehicleData("CONTENDER", "300000", (GTA.Model) " VAPID CONTENDER"),
      new VehicleWarehouse.VehicleData("STREITER", "500000", (GTA.Model) " BENEFACTOR STREITER"),
      new VehicleWarehouse.VehicleData("PATRIOT2", "611800", (GTA.Model) " MAMMOTH PATRIOT STRETCH"),
      new VehicleWarehouse.VehicleData("TOROS", "498000", (GTA.Model) " PEGASSI TOROS"),
      new VehicleWarehouse.VehicleData("NOVAK", "608000", (GTA.Model) " LAMPADATI NOVAK"),
      new VehicleWarehouse.VehicleData("REBLA", "1175000", (GTA.Model) " ÜBERMACHT REBLA GTS"),
      new VehicleWarehouse.VehicleData("LANDSTALKER2", "1220000", (GTA.Model) " DUNDREARY LANDSTALKER XL"),
      new VehicleWarehouse.VehicleData("SEMINOLE2", "678000", (GTA.Model) " CANIS SEMINOLE FRONTIER"),
      new VehicleWarehouse.VehicleData("BISON", "30000", (GTA.Model) " BRAVADO BISON"),
      new VehicleWarehouse.VehicleData("BOBCATXL", "23000", (GTA.Model) " VAPID BOBCAT XL"),
      new VehicleWarehouse.VehicleData("CADDY2", "5200", (GTA.Model) " NAGASAKI CADDY"),
      new VehicleWarehouse.VehicleData("SADLER", "35000", (GTA.Model) " VAPID SADLER"),
      new VehicleWarehouse.VehicleData("BOXVILLE2", "45000", (GTA.Model) " BRUTE BOXVILLE"),
      new VehicleWarehouse.VehicleData("BURRITO3", "15000", (GTA.Model) " DECLASSE BURRITO"),
      new VehicleWarehouse.VehicleData("CAMPER", "20800", (GTA.Model) " BRUTE CAMPER"),
      new VehicleWarehouse.VehicleData("JOURNEY", "15000", (GTA.Model) " ZIRCONIUM JOURNEY"),
      new VehicleWarehouse.VehicleData("MINIVAN", "30000", (GTA.Model) " VAPID MINIVAN"),
      new VehicleWarehouse.VehicleData("PONY", "13000", (GTA.Model) " BRUTE PONY"),
      new VehicleWarehouse.VehicleData("RUMPO", "13000", (GTA.Model) " BRAVADO RUMPO"),
      new VehicleWarehouse.VehicleData("SPEEDO", "15000", (GTA.Model) " VAPID SPEEDO"),
      new VehicleWarehouse.VehicleData("SURFER", "11000", (GTA.Model) " BURGERFAHRZEUG SURFER"),
      new VehicleWarehouse.VehicleData("YOUGA", "16000", (GTA.Model) " BRAVADO YOUGA"),
      new VehicleWarehouse.VehicleData("PARADISE", "50000", (GTA.Model) " BRAVADO PARADISE"),
      new VehicleWarehouse.VehicleData("GBURRITO2", "65000", (GTA.Model) " DECLASSE GANG BURRITO"),
      new VehicleWarehouse.VehicleData("MOONBEAM", "32500", (GTA.Model) " DECLASSE MOONBEAM"),
      new VehicleWarehouse.VehicleData("RUMPO3", "130000", (GTA.Model) " BRAVADO RUMPO CUSTOM"),
      new VehicleWarehouse.VehicleData("YOUGA2", "195000", (GTA.Model) " BRAVADO YOUGA CLASSIC"),
      new VehicleWarehouse.VehicleData("MINIVAN2", "500000", (GTA.Model) " VAPID MINIVAN CUSTOM"),
      new VehicleWarehouse.VehicleData("SPEEDO4", "140000", (GTA.Model) " VAPID SPEEDO CUSTOM"),
      new VehicleWarehouse.VehicleData("YOUGA3", "1483000", (GTA.Model) " BRAVADO YOUGA CLASSIC 4X4")
    };
    public List<Vector3> SelectedSellPoints = new List<Vector3>();
    public List<Vector3> CompletedSellPoints = new List<Vector3>();
    public List<Vector3> GroundDropPoint_BC = new List<Vector3>()
    {
      new Vector3(338.4105f, 3564.933f, 33.46082f),
      new Vector3(90.74469f, 3734.106f, 40.01419f),
      new Vector3(360.1537f, 4443.778f, 62.92328f),
      new Vector3(1316.729f, 4328.159f, 38.12376f),
      new Vector3(1838.777f, 4822.32f, 44.27086f),
      new Vector3(2043.971f, 4984.791f, 40.8699f),
      new Vector3(2436.609f, 4990.096f, 46.02332f),
      new Vector3(2591.881f, 4649.492f, 33.62912f),
      new Vector3(2718.125f, 4274.942f, 47.24967f),
      new Vector3(2488.223f, 3734.939f, 42.97411f),
      new Vector3(2176.326f, 3507.188f, 45.4706f),
      new Vector3(2396.697f, 3323.55f, 47.6274f),
      new Vector3(2635.238f, 3267.645f, 55.22104f),
      new Vector3(1987.776f, 3029.115f, 47.04488f),
      new Vector3(1741.064f, 3043.006f, 61.3792f),
      new Vector3(1577.296f, 2906.428f, 56.80774f),
      new Vector3(1123.176f, 2660.472f, 37.99625f),
      new Vector3(750.7753f, 2565.746f, 75.84059f),
      new Vector3(393.6532f, 2582.341f, 43.51351f),
      new Vector3(410.9716f, 2980.257f, 40.81686f),
      new Vector3(264.5997f, 3179.692f, 42.51227f),
      new Vector3(-234.4132f, 3087.198f, 38.14804f),
      new Vector3(-629.2133f, 2918.847f, 14.99539f),
      new Vector3(-1024.824f, 2776.701f, 24.42429f),
      new Vector3(-1493.264f, 2779.57f, 19.52092f),
      new Vector3(-1622.469f, 3200.645f, 30.25848f),
      new Vector3(-1721.159f, 2636.903f, 0.9020873f),
      new Vector3(-2772.632f, 2710.068f, 2.152616f),
      new Vector3(-1911.859f, 2047.034f, 140.7344f),
      new Vector3(-264.4362f, 2189.669f, 129.7881f),
      new Vector3(-287.0154f, 2558.63f, 73.35431f),
      new Vector3(-109.3444f, 2802.475f, 53.58705f),
      new Vector3(178.8037f, 2239.836f, 90.10175f),
      new Vector3(814.9496f, 2184.514f, 52.28234f),
      new Vector3(1238.013f, 1852.569f, 79.6578f),
      new Vector3(1528.807f, 1719.899f, 110.1068f),
      new Vector3(2323.921f, 2538.036f, 46.66751f),
      new Vector3(2981.492f, 3487.853f, 71.25694f),
      new Vector3(2893.471f, 4469.159f, 48.09846f),
      new Vector3(3321.512f, 5149.677f, 18.70039f),
      new Vector3(2206.274f, 5596.936f, 53.60205f)
    };
    public List<Vector3> GroundDropPoint_LS = new List<Vector3>()
    {
      new Vector3(-262.0311f, 195.8023f, 85.16026f),
      new Vector3(-1487.499f, -201.5679f, 50.39709f),
      new Vector3(-1422.425f, -240.4453f, 46.37913f),
      new Vector3(-1318.59f, -232.9813f, 43.02388f),
      new Vector3(-1169.022f, -751.374f, 19.22467f),
      new Vector3(-1207.11f, -1074.41f, 8.312729f),
      new Vector3(-754.6543f, -1038.178f, 12.79302f),
      new Vector3(-452.0849f, -940.5854f, 23.66427f),
      new Vector3(-331.9252f, -757.4856f, 53.35413f),
      new Vector3(36.6026f, -411.8505f, 40.0701f),
      new Vector3(334.5783f, -213.6587f, 54.08014f),
      new Vector3(579.2178f, 130.9492f, 98.041f),
      new Vector3(137.2357f, -242.9576f, 51.5365f),
      new Vector3(477.3281f, -581.4378f, 28.6183f),
      new Vector3(500.6329f, -506.8322f, 25.34557f),
      new Vector3(474.9978f, -1281.376f, 29.59866f),
      new Vector3(490.2281f, -1335.528f, 29.32614f),
      new Vector3(488.9641f, -1507.831f, 29.28663f),
      new Vector3(552.4913f, -1826.242f, 25.17233f),
      new Vector3(545.2916f, -1941.088f, 24.98512f),
      new Vector3(412.9511f, -2066.52f, 21.47118f),
      new Vector3(90.98637f, -2233.042f, 6.03968f),
      new Vector3(-253.1606f, -2254f, 7.900317f),
      new Vector3(-339.4914f, -2436.446f, 5.940394f),
      new Vector3(271.5289f, -3011.571f, 5.794857f),
      new Vector3(507.9313f, -2118.953f, 5.923953f),
      new Vector3(377.3893f, -1830.509f, 28.76753f),
      new Vector3(459.7094f, -1360.975f, 43.4966f),
      new Vector3(700.5648f, -1106.737f, 22.46314f),
      new Vector3(653.9521f, -442.3446f, 24.71997f),
      new Vector3(-728.8388f, -760.2722f, 35.585f),
      new Vector3(-916.3595f, -781.7725f, 15.87423f),
      new Vector3(-1249.986f, -631.8416f, 40.35752f),
      new Vector3(-1481.926f, -660.1251f, 28.94311f),
      new Vector3(-1574.033f, 408.5303f, 107.2125f)
    };
    public List<Vector3> AirSellPoints = new List<Vector3>()
    {
      new Vector3(142.9343f, 6914.887f, 19.29789f),
      new Vector3(291.3384f, 6499.594f, 28.78313f),
      new Vector3(757.7981f, 6452.818f, 30.86196f),
      new Vector3(2256.923f, 5614.318f, 53.31849f),
      new Vector3(2379.987f, 5053.654f, 45.44461f),
      new Vector3(2072.918f, 5084.007f, 42.33178f),
      new Vector3(1730.037f, 4860.375f, 39.50177f),
      new Vector3(1377.788f, 4358.424f, 42.43552f),
      new Vector3(890.6893f, 3579.15f, 32.36761f),
      new Vector3(869.2792f, 2863.958f, 56.00978f),
      new Vector3(527.7366f, 3092.536f, 39.46517f),
      new Vector3(392.4561f, 2973.885f, 40.018f),
      new Vector3(212.2625f, 3030.897f, 41.46631f),
      new Vector3(217.7538f, 2460.63f, 55.17255f),
      new Vector3(180.3113f, 2249.292f, 89.51086f),
      new Vector3(-258.0314f, 1026.052f, 233.1569f),
      new Vector3(-815.6135f, 863.9863f, 202.044f),
      new Vector3(-1560.356f, 846.2502f, 182.2905f),
      new Vector3(-522.7313f, 211.7888f, 93.40929f),
      new Vector3(-253.5001f, -187.6828f, 77.33955f),
      new Vector3(39.57681f, -387.5955f, 72.94682f),
      new Vector3(-162.263f, -1072.698f, 41.13926f),
      new Vector3(-448.5564f, -1589.815f, -0.7476568f),
      new Vector3(-203.1636f, -1810.336f, -0.1749601f),
      new Vector3(527.9789f, -2395.045f, 4.866005f),
      new Vector3(673.2985f, -1735.707f, 8.156456f),
      new Vector3(585.2514f, -1032.77f, 8.873472f),
      new Vector3(763.2703f, -285.6783f, 58.89305f),
      new Vector3(393.7914f, 808.2f, 188.6591f),
      new Vector3(-2547.925f, 3882.809f, 2.265001f),
      new Vector3(-2206.595f, 5109.48f, 10.2239f),
      new Vector3(-1808.578f, 5500.877f, 9.868484f),
      new Vector3(-1274.257f, 5357.082f, 2.61005f),
      new Vector3(-894.6169f, 6039.076f, 41.42483f),
      new Vector3(-641.7639f, 6300.4f, 2.548452f),
      new Vector3(101.7068f, 6720.847f, 40.32216f),
      new Vector3(85.64242f, 7019.84f, 10.33254f),
      new Vector3(91.11735f, 7119.979f, 25.57077f),
      new Vector3(-118.0909f, 7274.998f, 15.71198f),
      new Vector3(212.161f, 7401.202f, 15.63491f),
      new Vector3(1601.31f, 6624.853f, 14.7691f),
      new Vector3(3457.082f, 5869.54f, 0.5336733f),
      new Vector3(3629.815f, 5676.708f, 7.189864f),
      new Vector3(3257.696f, 5181.274f, 18.71513f),
      new Vector3(3670.324f, 4957.411f, 15.70396f),
      new Vector3(4122.448f, 4503.318f, 16.15442f),
      new Vector3(3929.639f, 4391.797f, 15.64299f),
      new Vector3(3811.919f, 4463.106f, 3.14999f),
      new Vector3(4061.834f, 4220.689f, 9.964996f),
      new Vector3(3938.668f, 4030.557f, 3.773781f),
      new Vector3(3941.106f, 3704.395f, 20.78075f),
      new Vector3(3708.714f, 3096.141f, 9.729301f),
      new Vector3(3477.062f, 2796.258f, 11.38898f),
      new Vector3(3458.979f, 2585.261f, 15.70652f),
      new Vector3(3285.49f, 2200.374f, 1.187321f),
      new Vector3(3135.44f, 2005.745f, 9.799809f),
      new Vector3(2977.936f, 1859.366f, 12.29116f),
      new Vector3(3107.809f, 1156.429f, 17.08418f),
      new Vector3(2995.529f, 868.1177f, 10.58837f),
      new Vector3(2935.602f, 708.0146f, 0.8921661f),
      new Vector3(3107.87f, 624.568f, 10.37827f),
      new Vector3(2924.56f, 378.6835f, 1.738621f),
      new Vector3(3258.943f, -143.0432f, 15.82851f),
      new Vector3(2829.321f, -628.1918f, 0.9898243f),
      new Vector3(2851.669f, -1335.525f, 13.45509f),
      new Vector3(2824.25f, -1483.526f, 11.20686f),
      new Vector3(2617.836f, -1676.538f, 19.4633f),
      new Vector3(2450.235f, -1953.551f, 60.66158f),
      new Vector3(2316.828f, -2124.865f, 1.076571f),
      new Vector3(1807.449f, -2708.403f, 1.074924f),
      new Vector3(1417.394f, -2750.26f, 2.793983f),
      new Vector3(1303.811f, -2725.18f, 1.115398f),
      new Vector3(1169.412f, -2674.187f, 3.598064f),
      new Vector3(968.1642f, -2626.891f, 4.435923f),
      new Vector3(1287.15f, -3069.081f, 4.906601f),
      new Vector3(1288.359f, -3331.024f, 4.903426f),
      new Vector3(508.2104f, -3366.036f, 5.069911f),
      new Vector3(117.208f, -3333.155f, 5.016824f),
      new Vector3(-759.6255f, -3243.744f, 13.14648f),
      new Vector3(-1044.988f, -3501.196f, 13.14841f),
      new Vector3(-1320.263f, -3200.409f, 13.1467f),
      new Vector3(-1454.023f, -2929.56f, 13.31358f),
      new Vector3(-1507.422f, -2584.384f, 13.75464f),
      new Vector3(-1370.566f, -2191.398f, 13.93104f),
      new Vector3(-1241.077f, -1856.326f, 0.6324749f),
      new Vector3(-1469.659f, -1481.27f, 1.152094f),
      new Vector3(-1532.163f, -1264.186f, 1.099478f),
      new Vector3(-1785.938f, -999.5118f, 1.474227f),
      new Vector3(-1928.561f, -771.367f, 1.793015f),
      new Vector3(-1702.465f, -201.0395f, 55.70387f),
      new Vector3(-1550.158f, -266.4189f, 47.26624f),
      new Vector3(-1054.454f, -681.3167f, 21.69321f),
      new Vector3(-930.5082f, -725.9016f, 18.91875f),
      new Vector3(-1091.46f, -974.295f, 2.95294f),
      new Vector3(-1526.987f, -990.1545f, 12.01739f),
      new Vector3(-1819.574f, -1249.881f, 12.01735f),
      new Vector3(-2109.117f, -1013.269f, 7.970045f),
      new Vector3(-2178.404f, -413.3558f, 12.19503f),
      new Vector3(-2224.494f, 191.7505f, 193.6117f),
      new Vector3(-2644.671f, 1444.412f, 128.0838f),
      new Vector3(-2823.629f, 1424.163f, 99.8154f),
      new Vector3(-2307.263f, 2481.316f, 2.257484f),
      new Vector3(-2422.007f, 2527.542f, 1.727083f),
      new Vector3(-2704.059f, 2654.977f, 1.203823f),
      new Vector3(-2762.171f, 2715.103f, 1.216527f),
      new Vector3(-2900.167f, 3095.061f, 1.596127f),
      new Vector3(-3099.238f, 1744.895f, 34.21094f),
      new Vector3(-3245.414f, 1302.68f, 2.242867f),
      new Vector3(-3264.443f, 1178.125f, 1.48119f),
      new Vector3(-3289.997f, 1010.866f, 1.791059f),
      new Vector3(-3187.021f, 743.3129f, 1.071545f),
      new Vector3(-3084.087f, 498.2883f, 1.39183f),
      new Vector3(-3156.147f, 292.091f, 1.352177f),
      new Vector3(-3104.177f, 76.16432f, 0.7282944f),
      new Vector3(-2436.101f, -314.0953f, 2.894951f),
      new Vector3(-1739.873f, 158.1663f, 63.37101f),
      new Vector3(-1493.539f, 175.6694f, 54.70207f),
      new Vector3(-1233.095f, 80.76678f, 53.44827f),
      new Vector3(-1163.586f, -22.84781f, 44.96262f),
      new Vector3(-1002.538f, -40.59651f, 43.57173f),
      new Vector3(-509.9043f, -233.3065f, 35.21329f),
      new Vector3(-389.1174f, -278.8406f, 33.62776f),
      new Vector3(-354.0632f, -303.7758f, 31.1349f),
      new Vector3(-129.8553f, -447.6499f, 33.44976f),
      new Vector3(681.5182f, -485.8087f, 14.36395f),
      new Vector3(1166.885f, -147.3212f, 55.76991f),
      new Vector3(1273.343f, -54.4118f, 60.78726f)
    };
    public List<Vector3> WaterSellPoints = new List<Vector3>()
    {
      new Vector3(599.541f, -2336.73f, 0.0f),
      new Vector3(767.9865f, -2904.438f, 0.0f),
      new Vector3(1190.201f, -2886.793f, 0.0f),
      new Vector3(1309f, -3079.063f, 0.0f),
      new Vector3(1283.459f, -3356.579f, 0.2615672f),
      new Vector3(1140.264f, -3358.832f, 0.2615671f),
      new Vector3(282.1375f, -3346.672f, 0.6252037f),
      new Vector3(121.0077f, -2791.2f, -0.6475241f),
      new Vector3(159.3044f, -2686.311f, 0.2615678f),
      new Vector3(37.39562f, -2783.954f, 1.443386f),
      new Vector3(-61.52f, -2764.369f, 0.7161138f),
      new Vector3(-82.58383f, -2762.556f, -0.03936636f),
      new Vector3(-119.3027f, -2744.307f, 0.4151789f),
      new Vector3(-207.5031f, -2720.166f, -0.403002f),
      new Vector3(-292.5135f, -2798.402f, 1.142453f),
      new Vector3(-392.2332f, -2858.028f, 1.142453f),
      new Vector3(-540.6699f, -2776.649f, 1.142453f),
      new Vector3(-345.7127f, -2557.428f, 0.5060892f),
      new Vector3(-425.0461f, -2239.414f, 0.1424533f),
      new Vector3(-90.71731f, -2269.053f, 0.3242664f),
      new Vector3(94.78544f, -2264.441f, 0.1424504f),
      new Vector3(2668.643f, -1800.947f, 0.6879092f),
      new Vector3(2933.277f, 1485.321f, 0.415181f),
      new Vector3(3819.087f, 3711.157f, 0.8697297f),
      new Vector3(3879.662f, 4462.737f, 0.3242743f),
      new Vector3(-1347.97f, 6731.339f, 0.1424577f),
      new Vector3(-1618.083f, 5272.68f, 1.233367f),
      new Vector3(-3441.143f, 966.4492f, 0.5060942f),
      new Vector3(-2002.154f, -1044.844f, 1.597005f),
      new Vector3(-1908.545f, -2684.218f, 0.3242776f),
      new Vector3(-637.0583f, -2508.152f, 0.8697339f),
      new Vector3(-365.6855f, -2313.352f, -0.1302645f),
      new Vector3(476.5973f, -2225.528f, 0.5970083f),
      new Vector3(960.0664f, -2677.66f, 0.5970084f),
      new Vector3(423.7486f, -3203.884f, 0.5970045f),
      new Vector3(324.4364f, -2888.487f, 2.597004f),
      new Vector3(454.7864f, -2812.363f, 1.051549f),
      new Vector3(431.4216f, -2733.468f, 1.051549f),
      new Vector3(136.7685f, -2272.946f, 1.051548f),
      new Vector3(-281.639f, -2541.726f, 0.7788212f),
      new Vector3(-465.1034f, -2427.18f, 0.7788212f),
      new Vector3(-556.7281f, -2872.181f, 0.7788218f)
    };
    public List<VehicleWarehouse.Flare> SellPointsSmoke_Air = new List<VehicleWarehouse.Flare>();
    public List<VehicleWarehouse.Flare> SellPointsSmoke_Water = new List<VehicleWarehouse.Flare>();
    public List<VehicleWarehouse.Flare> Cargo = new List<VehicleWarehouse.Flare>();
    public List<Vector3> CargoDropped = new List<Vector3>();
    public List<int> SmokeParticles = new List<int>();
    public List<VehicleWarehouse.Flare> SmokePropaParticles = new List<VehicleWarehouse.Flare>();
    public bool SupplyMissionOn;
    public int SupplyMissionID;
    public int SupplyMissionStage;
    public int SupplyMissionType;
    public List<Vehicle> SupplyMissionVehicles = new List<Vehicle>();
    public List<Ped> SupplyMissionPeds = new List<Ped>();
    public List<Prop> SupplyMissionProps = new List<Prop>();
    public List<Blip> SupplyMissionBlips = new List<Blip>();
    public Vehicle SupplyMissionMainVehicle;
    public Vector3 AreaOffset;
    public float TotalPay;
    public float TotalBonus;
    public float TotalLoss;
    public Prop DeliverCrate1;
    public Prop DeliverCrate1Fake;
    public Blip DeliverLocBlip1;
    public bool DeliveredtoLoc1;
    public Vector3 AreaOffset1;
    public Prop DeliverCrate2;
    public Prop DeliverCrate2Fake;
    public Blip DeliverLocBlip2;
    public bool DeliveredtoLoc2;
    public Vector3 AreaOffset2;
    public Prop DeliverCrate3;
    public Prop DeliverCrate3Fake;
    public Blip DeliverLocBlip3;
    public bool DeliveredtoLoc3;
    public Vector3 AreaOffset3;
    public Prop DeliverCrate4;
    public Prop DeliverCrate4Fake;
    public Blip DeliverLocBlip4;
    public bool DeliveredtoLoc4;
    public Vector3 AreaOffset4;
    public Prop DeliverCrate5;
    public Prop DeliverCrate5Fake;
    public Blip DeliverLocBlip5;
    public bool DeliveredtoLoc5;
    public Vector3 AreaOffset5;
    public List<PedHash> EnemyPedhashes = new List<PedHash>()
    {
      PedHash.Hillbilly01AMM,
      PedHash.Hillbilly02AMM,
      PedHash.ONeil,
      PedHash.SalvaBoss01GMY,
      PedHash.Salton04AMM,
      PedHash.SalvaGoon01GMY,
      PedHash.SalvaGoon02GMY,
      PedHash.SalvaGoon03GMY,
      PedHash.MilitaryBum,
      PedHash.Lost02GMY,
      PedHash.Lost01GFY
    };
    public List<VehicleHash> EnemyVehiclehashes = new List<VehicleHash>()
    {
      VehicleHash.Technical,
      VehicleHash.Dune,
      VehicleHash.Manchez,
      VehicleHash.DLoader,
      VehicleHash.BfInjection,
      VehicleHash.BF400,
      VehicleHash.Mesa,
      VehicleHash.Rebel,
      VehicleHash.Rebel2,
      VehicleHash.Blazer,
      VehicleHash.Rebel2
    };
    public int EnemySpawnSet;
    public bool WaitingForEnemySpawn;
    public List<Vector3> BrickadeSpawnPos = new List<Vector3>()
    {
      new Vector3(973.9282f, -1504.946f, 31.63f),
      new Vector3(733.6379f, -1996.565f, 29.63f),
      new Vector3(530.2698f, -1857.719f, 25.69f),
      new Vector3(169.6421f, -1520.013f, 29.49f),
      new Vector3(514.2137f, -571.242f, 25.2f),
      new Vector3(63.69f, -398.55f, 40.26f),
      new Vector3(-60.73f, -189.64f, 52.41f),
      new Vector3(-208.2718f, 18.15f, 56.25f),
      new Vector3(-335.56f, -1396.98f, 31.056f),
      new Vector3(-240.74f, -1672.214f, 33.85f),
      new Vector3(-260.43f, -2473.976f, 6.34f),
      new Vector3(-84.05f, 97.36f, 73.22f)
    };
    public List<VehicleWarehouse.SpawnH> BrickadeSpawnH = new List<VehicleWarehouse.SpawnH>()
    {
      new VehicleWarehouse.SpawnH(new Vector3(973.9282f, -1504.946f, 31.63f), 0.0f),
      new VehicleWarehouse.SpawnH(new Vector3(733.6379f, -1996.565f, 29.63f), 173f),
      new VehicleWarehouse.SpawnH(new Vector3(530.2698f, -1857.719f, 25.69f), 141f),
      new VehicleWarehouse.SpawnH(new Vector3(169.6421f, -1520.013f, 29.49f), 37f),
      new VehicleWarehouse.SpawnH(new Vector3(514.2137f, -571.242f, 25.2f), 174f),
      new VehicleWarehouse.SpawnH(new Vector3(63.69f, -398.55f, 40.26f), -20f),
      new VehicleWarehouse.SpawnH(new Vector3(-60.73f, -189.64f, 52.41f), 67f),
      new VehicleWarehouse.SpawnH(new Vector3(-208.2718f, 18.15f, 56.25f), 69f),
      new VehicleWarehouse.SpawnH(new Vector3(-335.56f, -1396.98f, 31.056f), -179f),
      new VehicleWarehouse.SpawnH(new Vector3(-240.74f, -1672.214f, 33.85f), -179f),
      new VehicleWarehouse.SpawnH(new Vector3(-260.43f, -2473.976f, 6.34f), -131f),
      new VehicleWarehouse.SpawnH(new Vector3(-84.05f, 97.36f, 73.22f), 68f)
    };
    public List<VehicleWarehouse.SpawnH> Cuban800SpawnH = new List<VehicleWarehouse.SpawnH>()
    {
      new VehicleWarehouse.SpawnH(new Vector3(-1042.79f, -3488.871f, 14.77f), 2.9f),
      new VehicleWarehouse.SpawnH(new Vector3(-1065.169f, -3471.22f, 14.77f), -7.7f),
      new VehicleWarehouse.SpawnH(new Vector3(-926.99f, -3096.54f, 14.57f), 98.11f),
      new VehicleWarehouse.SpawnH(new Vector3(-1218.016f, -2888.023f, 14.57f), 97.4f),
      new VehicleWarehouse.SpawnH(new Vector3(-1370.94f, -2421.087f, 14.57f), 90.7f),
      new VehicleWarehouse.SpawnH(new Vector3(-1710.592f, -3146.551f, 14.58f), 16.73f),
      new VehicleWarehouse.SpawnH(new Vector3(-1213.214f, -3364.88f, 14.57f), -10f)
    };
    public List<VehicleWarehouse.SpawnH> TugSpawnH = new List<VehicleWarehouse.SpawnH>()
    {
      new VehicleWarehouse.SpawnH(new Vector3(-481.78f, -2280.69f, 0.8f), 160f),
      new VehicleWarehouse.SpawnH(new Vector3(-298.94f, -2384.505f, 1.271f), -39.58f),
      new VehicleWarehouse.SpawnH(new Vector3(88.34f, -2266.75f, 0.81f), -92.05f),
      new VehicleWarehouse.SpawnH(new Vector3(-904.4f, -1448.64f, 0.93f), -68.98f),
      new VehicleWarehouse.SpawnH(new Vector3(92.466f, -2449.216f, 1.4f), 53.62f),
      new VehicleWarehouse.SpawnH(new Vector3(321.0196f, -2977.834f, 0.64f), -177f)
    };
    public Vector3 CurrentWarehousePos;
    public int AmttoDeliver;
    public int Selectedpoints;
    public int PointstoGoto;
    public bool WaitingForDrop;
    public int CrateSelected;
    public int CrateSpawn;
    public Vehicle DeliveryVehicle1;
    public Vehicle DeliveryVehicle2;
    public Vehicle DeliveryVehicle3;
    public Vehicle DeliveryVehicle4;
    public string DeliverSlot1;
    public string DeliverSlot2;
    public string DeliverSlot3;
    public string DeliverSlot4;
    public bool DeliveredVehicle1;
    public bool DeliveredVehicle2;
    public bool DeliveredVehicle3;
    public bool DeliveredVehicle4;
    public int num;
    public bool NearLoc1;
    public bool NearLoc2;
    public bool NearLoc3;
    public bool NearLoc4;
    public int SellMission = 1;
    public int WheelType;
    public int Delivered;
    public int Deliveries;
    public Ped DeliverPed;
    public bool FirsttimeSmoke;
    public float PercentageSell;
    public List<Ped> SourceASellMissionPeds = new List<Ped>();
    public List<Vehicle> SourceASellMissionVehicles = new List<Vehicle>();
    public List<Prop> SourceASellMissionProps = new List<Prop>();
    public List<Blip> SourceASellMissionBlips = new List<Blip>();
    public Vector3 Points;
    public bool CreatedDealers;
    public bool CanNotSaveVehicle;
    public Color mainColor;
    public bool IsSittinginCeoSeat;
    public Vector3 ChairPos = new Vector3(964.5682f, -3003.434f, -39.63f);

    private void CheckHostName(string iniName)
    {
      try
      {
        this.HostNameSettings = ScriptSettings.Load(iniName);
        this.HostName = this.HostNameSettings.GetValue<string>("Misc", "HostName", this.HostName);
        this.Uicolour = this.HostNameSettings.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public string GetHostName()
    {
      this.CheckHostName("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.HostName = this.Config2.GetValue<string>("Misc", "HostName", this.HostName);
      this.Uicolour = this.Config2.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      string str = "~" + this.Uicolour + "~";
      return this.HostName;
    }

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Executive Business", "Warehouse", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void LoadExecutivemain(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public VehicleWarehouse(int o)
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.CreateBanner();
      this.Setup();
    }

    public VehicleWarehouse()
    {
    }

    private void SetupMarker()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      int vehicleWarehouseBought = this.VehicleWarehouseBought;
    }

    private void VehicleIdentiferfun2(VehicleHash v)
    {
      if (this.VehicleMarker != (Blip) null)
        this.VehicleMarker.Remove();
      this.Vehicletoget = (Vehicle) null;
      System.Random random = new System.Random();
      if (random.Next(1, 13) == 1)
        this.VehicleSpawn = new Vector3(-1069.32f, -72.28f, 19f);
      if (random.Next(1, 13) == 2)
        this.VehicleSpawn = new Vector3(-1579.93f, -155.28f, 55f);
      if (random.Next(1, 13) == 3)
        this.VehicleSpawn = new Vector3(-711.74f, -28.28f, 37f);
      if (random.Next(1, 13) == 4)
        this.VehicleSpawn = new Vector3(6f, 253.58f, 109f);
      if (random.Next(1, 13) == 5)
        this.VehicleSpawn = new Vector3(703f, 32f, 84f);
      if (random.Next(1, 13) == 6)
        this.VehicleSpawn = new Vector3(1197f, -421.5f, 68f);
      if (random.Next(1, 13) == 7)
        this.VehicleSpawn = new Vector3(1257f, -1428f, 35f);
      if (random.Next(1, 13) == 8)
        this.VehicleSpawn = new Vector3(1264f, -2039f, 45f);
      if (random.Next(1, 13) == 9)
        this.VehicleSpawn = new Vector3(527f, -2052f, 28f);
      if (random.Next(1, 13) == 10)
        this.VehicleSpawn = new Vector3(-161f, -2087.8f, 26f);
      if (random.Next(1, 13) == 11)
        this.VehicleSpawn = new Vector3(756f, -1723f, 30f);
      if (random.Next(1, 13) == 12)
        this.VehicleSpawn = new Vector3(-816f, -2300f, 11f);
      if (random.Next(1, 13) == 13)
        this.VehicleSpawn = new Vector3(-1839f, 136f, 78f);
      this.Vehicletoget = World.CreateVehicle((GTA.Model) v, this.VehicleSpawn);
      this.SourcedVehicle = this.Vehicletoget.DisplayName;
      this.Vehicletoget.Delete();
      this.NewVehicleSourcing = true;
      this.foundvehicleyet = true;
      this.SourcingCheckingforDamage = true;
      UI.Notify(this.GetHostName() + " Test!");
    }

    private void VehicleIdentiferfun(VehicleHash v)
    {
      if (this.VehicleMarker != (Blip) null)
        this.VehicleMarker.Remove();
      this.Vehicletoget = (Vehicle) null;
      System.Random random = new System.Random();
      if (random.Next(1, 13) == 1)
        this.VehicleSpawn = new Vector3(-1069.32f, -72.28f, 19f);
      if (random.Next(1, 13) == 2)
        this.VehicleSpawn = new Vector3(-1579.93f, -155.28f, 55f);
      if (random.Next(1, 13) == 3)
        this.VehicleSpawn = new Vector3(-711.74f, -28.28f, 37f);
      if (random.Next(1, 13) == 4)
        this.VehicleSpawn = new Vector3(6f, 253.58f, 109f);
      if (random.Next(1, 13) == 5)
        this.VehicleSpawn = new Vector3(703f, 32f, 84f);
      if (random.Next(1, 13) == 6)
        this.VehicleSpawn = new Vector3(1197f, -421.5f, 68f);
      if (random.Next(1, 13) == 7)
        this.VehicleSpawn = new Vector3(1257f, -1428f, 35f);
      if (random.Next(1, 13) == 8)
        this.VehicleSpawn = new Vector3(1264f, -2039f, 45f);
      if (random.Next(1, 13) == 9)
        this.VehicleSpawn = new Vector3(527f, -2052f, 28f);
      if (random.Next(1, 13) == 10)
        this.VehicleSpawn = new Vector3(-161f, -2087.8f, 26f);
      if (random.Next(1, 13) == 11)
        this.VehicleSpawn = new Vector3(756f, -1723f, 30f);
      if (random.Next(1, 13) == 12)
        this.VehicleSpawn = new Vector3(-816f, -2300f, 11f);
      if (random.Next(1, 13) == 13)
        this.VehicleSpawn = new Vector3(-1839f, 136f, 78f);
      this.Vehicletoget = World.CreateVehicle((GTA.Model) v, this.VehicleSpawn);
      this.Vehicletoget.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.Busker01SMO);
      this.Vehicletoget.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
      this.Vehicleloc = this.Vehicletoget.Position;
      this.VehicleMarker = World.CreateBlip(this.Vehicleloc);
      this.VehicleMarker.Sprite = BlipSprite.Cab;
      this.VehicleMarker.Color = BlipColor.Red;
      this.VehicleMarker.Name = "Target Car";
      this.foundvehicleyet = true;
      this.SourcingCheckingforDamage = true;
    }

    private void VehicleIdentiferfun3(VehicleClass v)
    {
      this.Missionnum = 412;
      this.foundvehicleyet = true;
      this.SourcingCheckingforDamage = true;
    }

    public int GetVehiclesInWarehouse() => 0;

    public void ResetData()
    {
      for (int index = 0; index < this.VehicleWarehouses.Count; ++index)
      {
        if (index == this.VehicleWarehouseIndex)
        {
          this.WherehouseMarker = new Vector3(this.VehicleWarehouses[index].VehicleWarehouseCoords.X, this.VehicleWarehouses[index].VehicleWarehouseCoords.Y, this.VehicleWarehouses[index].VehicleWarehouseCoords.Z);
          this.WherehouseExitHeading = this.VehicleWarehouses[index].VehicleWarehouseExitHeading;
          if (this.VehicleWarehouseMarker != (Blip) null)
            this.VehicleWarehouseMarker.Remove();
          this.VehicleWarehouseMarker = World.CreateBlip(this.WherehouseMarker);
          this.VehicleWarehouseMarker.Sprite = BlipSprite.VehicleWarehouse;
          this.VehicleWarehouseMarker.Color = BlipColor.White;
          this.VehicleWarehouseMarker.Name = "Vehicle Warehouse : " + this.VehicleWarehouses[index].VehicleWarehouseName;
          this.VehicleWarehouseMarker.IsShortRange = true;
        }
      }
    }

    public void IPEXMissions()
    {
      List<object> items = new List<object>();
      VehicleHash[] allvehiclehashes = (VehicleHash[]) Enum.GetValues(typeof (VehicleHash));
      for (int index = 0; index < allvehiclehashes.Length; ++index)
        items.Add((object) allvehiclehashes[index]);
      UIMenu uiMenu1 = this.MissionsMenuPool.AddSubMenu(this.MissionsmainMenu, "Source a vehicle (Expanded)");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.MissionsMenuPool.AddSubMenu(this.MissionsmainMenu, "Source a vehicle (Random Vehicle)");
      this.GUIMenus.Add(uiMenu2);
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1");
      Slots.Add((object) "Slot2");
      Slots.Add((object) "Slot3");
      Slots.Add((object) "Slot4");
      Slots.Add((object) "Slot5");
      Slots.Add((object) "Slot6");
      Slots.Add((object) "Slot7");
      Slots.Add((object) "Slot8");
      Slots.Add((object) "Slot9");
      Slots.Add((object) "Slot10");
      Slots.Add((object) "Slot11");
      Slots.Add((object) "Slot12");
      Slots.Add((object) "Slot13");
      Slots.Add((object) "Slot14");
      Slots.Add((object) "Slot15");
      Slots.Add((object) "Slot16");
      Slots.Add((object) "Slot17");
      Slots.Add((object) "Slot18");
      Slots.Add((object) "Slot19");
      Slots.Add((object) "Slot20");
      Slots.Add((object) "Slot21");
      Slots.Add((object) "Slot22");
      Slots.Add((object) "Slot23");
      Slots.Add((object) "Slot24");
      Slots.Add((object) "Slot25");
      Slots.Add((object) "Slot26");
      Slots.Add((object) "Slot27");
      Slots.Add((object) "Slot28");
      Slots.Add((object) "Slot29");
      Slots.Add((object) "Slot30");
      Slots.Add((object) "Slot31");
      Slots.Add((object) "Slot32");
      Slots.Add((object) "Slot33");
      Slots.Add((object) "Slot34");
      Slots.Add((object) "Slot35");
      List<object> KnownVehicles = new List<object>();
      List<object> Types = new List<object>();
      Types.Add((object) "Specific Vehicle");
      Types.Add((object) "Specific Class");
      List<object> VClasses = new List<object>();
      List<object> VClassesPrice = new List<object>();
      VClasses.Add((object) VehicleClass.Super);
      VClassesPrice.Add((object) 700000);
      VClasses.Add((object) VehicleClass.SUVs);
      VClassesPrice.Add((object) 150000);
      VClasses.Add((object) VehicleClass.Sports);
      VClassesPrice.Add((object) 350000);
      VClasses.Add((object) VehicleClass.SportsClassics);
      VClassesPrice.Add((object) 550000);
      VClasses.Add((object) VehicleClass.Sedans);
      VClassesPrice.Add((object) 50000);
      VClasses.Add((object) VehicleClass.Muscle);
      VClassesPrice.Add((object) 250000);
      VClasses.Add((object) VehicleClass.Military);
      VClassesPrice.Add((object) 950000);
      VClasses.Add((object) VehicleClass.Motorcycles);
      VClassesPrice.Add((object) 125000);
      VClasses.Add((object) VehicleClass.OffRoad);
      VClassesPrice.Add((object) 250000);
      VClasses.Add((object) VehicleClass.Vans);
      VClassesPrice.Add((object) 150000);
      UIMenuListItem RNChoosenClass = new UIMenuListItem("Chosen Class: ", VClasses, 0);
      uiMenu2.AddItem((UIMenuItem) RNChoosenClass);
      RNChoosenClass.Description = "Random Vehicle will be choosen from Choosen Class";
      UIMenuListItem s = new UIMenuListItem("Slot : ", Slots, 0);
      uiMenu2.AddItem((UIMenuItem) s);
      UIMenuItem RNgetvehicle = new UIMenuItem("Source Vehicle ~g~$700,000");
      uiMenu2.AddItem(RNgetvehicle);
      RNgetvehicle.Description = "~y~ Warning~w~ Sourcing a vehicle to a slot will replace the vehicle that is in that slot if any";
      uiMenu2.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        UIMenuItem uiMenuItem = RNgetvehicle;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__2;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__1 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, string, object, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, string, object, object>> p1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__0.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__0, VClassesPrice[RNChoosenClass.Index], "N");
        object obj2 = target2((CallSite) p1, "Source Vehicle ~g~$", obj1);
        string str = target1((CallSite) p2, obj2);
        uiMenuItem.Text = str;
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != RNgetvehicle)
          return;
        this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        this.VehicleWarehouseBought = this.Config2.GetValue<int>("Setup", "VehicleWarehouseBought", this.VehicleWarehouseBought);
        if (this.VehicleWarehouseBought == 1)
        {
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__4.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p4 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__4;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__3.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__3, VClasses[RNChoosenClass.Index], VehicleClass.Super);
          if (target1((CallSite) p4, obj1))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 7)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__5 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__5.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__5, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__6 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__6.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__6, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__9 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__9 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__9.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p9 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__9;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__8 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__8.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p8 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__8;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__7 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__7 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__7.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__7, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p8, obj2, ".ini");
              target2((CallSite) p9, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__10 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__10.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__10, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__12 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target4 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__12.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p12 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__12;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__11 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj4 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__11.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__11, VClasses[RNChoosenClass.Index], VehicleClass.SUVs);
          if (target4((CallSite) p12, obj4))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 2)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__13 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__13.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__13, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__14 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__14.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__14, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__17 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__17 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__17.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p17 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__17;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__16 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__16.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p16 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__16;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__15 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__15 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__15.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__15, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p16, obj2, ".ini");
              target2((CallSite) p17, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__18 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__18.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__18, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__20 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target5 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__20.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p20 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__20;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__19 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj5 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__19.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__19, VClasses[RNChoosenClass.Index], VehicleClass.Sports);
          if (target5((CallSite) p20, obj5))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 6)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__21 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__21.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__21, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__22 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__22.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__22, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__25 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__25 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__25.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p25 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__25;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__24 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__24 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__24.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p24 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__24;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__23 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__23 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__23.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__23, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p24, obj2, ".ini");
              target2((CallSite) p25, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__26 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__26 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__26.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__26, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__28 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__28 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target6 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__28.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p28 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__28;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__27 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__27 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj6 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__27.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__27, VClasses[RNChoosenClass.Index], VehicleClass.SportsClassics);
          if (target6((CallSite) p28, obj6))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 5)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__29 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__29 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__29.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__29, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__30 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__30 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__30.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__30, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__33 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__33 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__33.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p33 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__33;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__32 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__32 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__32.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p32 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__32;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__31 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__31 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__31.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__31, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p32, obj2, ".ini");
              target2((CallSite) p33, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__34 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__34 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__34.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__34, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__36 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__36 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target7 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__36.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p36 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__36;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__35 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__35 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__35.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__35, VClasses[RNChoosenClass.Index], VehicleClass.Sedans);
          if (target7((CallSite) p36, obj7))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 1)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__37 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__37 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__37.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__37, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__38 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__38 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__38.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__38, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__41 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__41 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__41.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p41 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__41;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__40 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__40 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__40.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p40 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__40;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__39 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__39 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__39.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__39, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p40, obj2, ".ini");
              target2((CallSite) p41, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__42 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__42 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__42.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__42, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__44 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__44 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target8 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__44.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p44 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__44;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__43 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__43 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj8 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__43.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__43, VClasses[RNChoosenClass.Index], VehicleClass.Muscle);
          if (target8((CallSite) p44, obj8))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 4)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__45 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__45 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__45.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__45, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__46 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__46 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__46.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__46, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__49 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__49 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__49.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p49 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__49;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__48 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__48 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__48.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p48 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__48;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__47 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__47 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__47.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__47, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p48, obj2, ".ini");
              target2((CallSite) p49, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__50 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__50 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__50.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__50, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__52 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__52 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target9 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__52.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p52 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__52;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__51 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__51 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj9 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__51.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__51, VClasses[RNChoosenClass.Index], VehicleClass.Military);
          if (target9((CallSite) p52, obj9))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 19)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__53 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__53 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__53.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__53, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__54 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__54 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__54.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__54, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__57 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__57 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__57.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p57 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__57;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__56 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__56 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__56.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p56 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__56;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__55 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__55 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__55.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__55, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p56, obj2, ".ini");
              target2((CallSite) p57, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__58 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__58 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__58.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__58, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__60 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__60 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target10 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__60.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p60 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__60;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__59 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__59 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj10 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__59.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__59, VClasses[RNChoosenClass.Index], VehicleClass.Motorcycles);
          if (target10((CallSite) p60, obj10))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 8)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__61 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__61 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__61.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__61, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__62 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__62 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__62.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__62, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__65 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__65 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__65.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p65 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__65;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__64 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__64 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__64.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p64 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__64;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__63 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__63 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__63.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__63, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p64, obj2, ".ini");
              target2((CallSite) p65, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__66 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__66 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__66.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__66, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__68 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__68 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target11 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__68.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p68 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__68;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__67 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__67 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj11 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__67.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__67, VClasses[RNChoosenClass.Index], VehicleClass.OffRoad);
          if (target11((CallSite) p68, obj11))
          {
            if (KnownVehicles.Count > 0)
              KnownVehicles.Clear();
            foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
            {
              if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 9)
                KnownVehicles.Add((object) vehicleHash);
            }
            int money1 = Game.Player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__69 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__69 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__69.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__69, VClassesPrice[RNChoosenClass.Index]);
            if (money1 >= num1)
            {
              Player player = Game.Player;
              int money2 = player.Money;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__70 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__70 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              int num2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__70.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__70, VClassesPrice[RNChoosenClass.Index]);
              player.Money = money2 - num2;
              this.DestoryCars();
              string Garage = "GarageA";
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__73 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__73 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__73.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Action<CallSite, SaveCar, object>> p73 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__73;
              SaveCar sc = this.SC;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__72 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__72 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__72.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string, object>> p72 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__72;
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__71 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__71 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__71.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__71, this.path + Garage + "//", Slots[s.Index]);
              object obj3 = target3((CallSite) p72, obj2, ".ini");
              target2((CallSite) p73, sc, obj3);
              System.Random random = new System.Random();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__74 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__74 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__74.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__74, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
              UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
              this.SC.SaveRandomMods(vehicle);
              this.SC.SaveName(vehicle.DisplayName);
              this.SC.SaveWithoutDelete();
              Script.Wait(500);
              vehicle.Delete();
              this.CreateCars(Garage);
            }
            else
              UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__76 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__76 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target12 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__76.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p76 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__76;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__75 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__75 = CallSite<Func<CallSite, object, VehicleClass, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj12 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__75.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__75, VClasses[RNChoosenClass.Index], VehicleClass.Vans);
          if (!target12((CallSite) p76, obj12))
            return;
          if (KnownVehicles.Count > 0)
            KnownVehicles.Clear();
          foreach (VehicleHash vehicleHash in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
          {
            if (Function.Call<int>(Hash._0xDEDF1C8BD47C2200, (InputArgument) (int) vehicleHash) == 12)
              KnownVehicles.Add((object) vehicleHash);
          }
          int money3 = Game.Player.Money;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__77 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__77 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__77.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__77, VClassesPrice[RNChoosenClass.Index]);
          if (money3 >= num3)
          {
            Player player = Game.Player;
            int money1 = player.Money;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__78 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__78 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            int num1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__78.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__78, VClassesPrice[RNChoosenClass.Index]);
            player.Money = money1 - num1;
            this.DestoryCars();
            string Garage = "GarageA";
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__81 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__81 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Action<CallSite, SaveCar, object> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__81.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Action<CallSite, SaveCar, object>> p81 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__81;
            SaveCar sc = this.SC;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__80 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__80 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, string, object> target3 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__80.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, string, object>> p80 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__80;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__79 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__79 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__79.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__79, this.path + Garage + "//", Slots[s.Index]);
            object obj3 = target3((CallSite) p80, obj2, ".ini");
            target2((CallSite) p81, sc, obj3);
            System.Random random = new System.Random();
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__82 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__82 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__82.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__82, KnownVehicles[random.Next(0, KnownVehicles.Count)])), new Vector3(0.0f, 0.0f, 0.0f), 0.0f);
            UI.Notify(this.GetHostName() + " We have added a ~b~" + vehicle.FriendlyName + "~w~ to your garage");
            this.SC.SaveRandomMods(vehicle);
            this.SC.SaveName(vehicle.DisplayName);
            this.SC.SaveWithoutDelete();
            Script.Wait(500);
            vehicle.Delete();
            this.CreateCars(Garage);
          }
          else
            UI.Notify(this.GetHostName() + " you dont have enough money to purchase a random car");
        }
        else
          UI.Notify(this.GetHostName() + " You need a ~b~Vehicle Warehouse~w~ to source vehicles ");
      });
      UIMenuListItem typ = new UIMenuListItem("Type: ", Types, 0);
      uiMenu1.AddItem((UIMenuItem) typ);
      UIMenuListItem list = new UIMenuListItem("Vehicle: ", items, 0);
      uiMenu1.AddItem((UIMenuItem) list);
      list.Description = "Vehicle Choosen if Type is 'Specific Vehicle'";
      UIMenuListItem ChoosenClass = new UIMenuListItem("Class: ", VClasses, 0);
      uiMenu1.AddItem((UIMenuItem) ChoosenClass);
      ChoosenClass.Description = "Reteive any Vehicle in Class if Type is       'Specific Class'";
      UIMenuItem getvehicle = new UIMenuItem("Source Vehicle");
      uiMenu1.AddItem(getvehicle);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != getvehicle)
          return;
        this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        this.VehicleWarehouseBought = this.Config2.GetValue<int>("Setup", "VehicleWarehouseBought", this.VehicleWarehouseBought);
        if (this.VehicleWarehouseBought == 1)
        {
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__84 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__84 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__84.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p84 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__84;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__83 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__83 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__83.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__83, Types[typ.Index], "Specific Vehicle");
          if (target1((CallSite) p84, obj1))
          {
            VehicleHash v = allvehiclehashes[list.Index];
            if (v == VehicleHash.Insurgent || v == VehicleHash.Insurgent2 || (v == VehicleHash.Insurgent3 || v == VehicleHash.Kuruma2) || (v == VehicleHash.Oppressor || v == VehicleHash.APC || (v == VehicleHash.HalfTrack || v == VehicleHash.NightShark)) || (v == VehicleHash.Dune3 || v == VehicleHash.Technical || (v == VehicleHash.Technical2 || v == VehicleHash.Technical3) || v == VehicleHash.Chernobog))
              this.SourcingPayout = (float) new System.Random().Next(125000, 350000);
            if (v == VehicleHash.EntityXXR || v == VehicleHash.LE7B || (v == VehicleHash.Nero2 || v == VehicleHash.Nero2) || (v == VehicleHash.T20 || v == VehicleHash.Tyrant || (v == VehicleHash.Tezeract || v == VehicleHash.NightShark)) || (v == VehicleHash.Tempesta || v == VehicleHash.Technical || (v == VehicleHash.Osiris || v == VehicleHash.GP1) || (v == VehicleHash.Autarch || v == VehicleHash.SultanRS || (v == VehicleHash.Banshee2 || v == VehicleHash.Taipan))) || (v == VehicleHash.Taipan || v == VehicleHash.Vagner || (v == VehicleHash.Visione || v == VehicleHash.Prototipo) || (v == VehicleHash.Reaper || v == VehicleHash.Pfister811 || (v == VehicleHash.FMJ || v == VehicleHash.Zentorno)) || (v == VehicleHash.ItaliGTB2 || v == VehicleHash.ItaliGTB || v == VehicleHash.Voltic2)))
            {
              int num1 = new System.Random().Next(75000, 1000000);
              float num2 = (float) (new System.Random().Next(25, 75) / 100);
              this.SourcingPayout = (float) num1 + (float) ((double) num1 * (double) num2 / 100.0);
            }
            if (v == VehicleHash.ZType)
            {
              int num1 = new System.Random().Next(195000, 2300000);
              float num2 = (float) (new System.Random().Next(25, 75) / 100);
              this.SourcingPayout = (float) num1 + (float) ((double) num1 * (double) num2 / 100.0);
            }
            if (v == VehicleHash.Deluxo || v == VehicleHash.Stromberg || (v == VehicleHash.Vigilante || v == VehicleHash.Dune2))
            {
              int num1 = new System.Random().Next(135000, 550000);
              float num2 = (float) (new System.Random().Next(25, 75) / 100);
              this.SourcingPayout = (float) num1 + (float) ((double) num1 * (double) num2 / 100.0);
            }
            if (v == VehicleHash.Phantom2 || v == VehicleHash.Dune4 || (v == VehicleHash.Dune5 || v == VehicleHash.Wastelander) || (v == VehicleHash.Tampa3 || v == VehicleHash.Caracara || v == VehicleHash.Monster))
            {
              int num1 = new System.Random().Next(100000, 400000);
              float num2 = (float) (new System.Random().Next(25, 75) / 100);
              this.SourcingPayout = (float) num1 + (float) ((double) num1 * (double) num2 / 100.0);
            }
            if (v == VehicleHash.Rhino || v == VehicleHash.Khanjari)
            {
              int num1 = new System.Random().Next(290000, 2000000);
              float num2 = (float) (new System.Random().Next(25, 75) / 100);
              this.SourcingPayout = (float) num1 + (float) ((double) num1 * (double) num2 / 100.0);
            }
            else
            {
              int num1 = new System.Random().Next(100000, 200000);
              float num2 = (float) (new System.Random().Next(25, 75) / 100);
              this.SourcingPayout = (float) num1 + (float) ((double) num1 * (double) num2 / 100.0);
            }
            this.VehicleIdentifier = v;
            this.VehicleIdentiferfun2(v);
            UI.Notify(this.GetHostName() + " Ok the car is a " + v.ToString());
            UI.Notify(this.GetHostName() + " the pay is  $" + this.SourcingPayout.ToString());
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__86 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__86 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__86.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p86 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__86;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__85 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__85 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__85.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__85, Types[typ.Index], "Specific Class");
          if (!target2((CallSite) p86, obj2))
            return;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__87 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__87 = CallSite<Func<CallSite, object, VehicleClass>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleClass), typeof (VehicleWarehouse)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.VClass = VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__87.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__202.\u003C\u003Ep__87, VClasses[ChoosenClass.Index]);
          this.VehicleIdentiferfun3(this.VClass);
          UI.Notify(this.GetHostName() + " Ok steal any car in the ~b~ " + this.VClass.ToString() + "~w~ Catagory and deliver it to the ~b~Vehicle Warehouse~w~");
        }
        else
          UI.Notify(this.GetHostName() + " You need a ~b~Vehicle Warehouse~w~ to source vehicles ");
      });
      UIMenu uiMenu3 = this.MissionsMenuPool.AddSubMenu(this.MissionsMenu, "Recovery ");
      this.GUIMenus.Add(uiMenu3);
      UIMenu uiMenu4 = this.MissionsMenuPool.AddSubMenu(this.MissionsMenu, "Elimination ");
      this.GUIMenus.Add(uiMenu4);
      UIMenu uiMenu5 = this.MissionsMenuPool.AddSubMenu(this.MissionsMenu, "Convoy ");
      this.GUIMenus.Add(uiMenu5);
      UIMenuItem Aboxville = new UIMenuItem("Armoured Boxville");
      uiMenu5.AddItem(Aboxville);
      UIMenuItem Dune3R = new UIMenuItem("Ramp Buggy");
      uiMenu3.AddItem(Dune3R);
      UIMenuItem PhantomWR = new UIMenuItem("Phantom Wedge ");
      uiMenu3.AddItem(PhantomWR);
      UIMenuItem Ruiner2000R = new UIMenuItem("Ruiner 2000 ");
      uiMenu3.AddItem(Ruiner2000R);
      UIMenuItem TechnicalAR = new UIMenuItem("Technical Aqua");
      uiMenu3.AddItem(TechnicalAR);
      UIMenuItem AboxvilleR = new UIMenuItem("Armoured Boxville");
      uiMenu3.AddItem(AboxvilleR);
      UIMenuItem RocketVR = new UIMenuItem("Rocket Voltic");
      uiMenu3.AddItem(RocketVR);
      UIMenuItem BlazerAquaR = new UIMenuItem("Blazer Aqua");
      uiMenu3.AddItem(BlazerAquaR);
      UIMenuItem Dune3E = new UIMenuItem("Ramp Buggy ");
      uiMenu4.AddItem(Dune3E);
      UIMenuItem PhantomWE = new UIMenuItem("Phantom Wedge ");
      uiMenu4.AddItem(PhantomWE);
      UIMenuItem Ruiner2000E = new UIMenuItem("Ruiner 2000 ");
      uiMenu4.AddItem(Ruiner2000E);
      UIMenuItem TechnicalAE = new UIMenuItem("Technical Aqua");
      uiMenu4.AddItem(TechnicalAE);
      UIMenuItem AboxvilleE = new UIMenuItem("Armoured Boxville");
      uiMenu4.AddItem(AboxvilleE);
      UIMenuItem RocketVE = new UIMenuItem("Rocket Voltic");
      uiMenu4.AddItem(RocketVE);
      UIMenuItem BlazerAquaE = new UIMenuItem("Blazer Aqua");
      uiMenu4.AddItem(BlazerAquaE);
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Aboxville)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if ((Entity) this.Sam2 != (Entity) null)
          this.Sam2.Delete();
        if ((Entity) this.Sam3 != (Entity) null)
          this.Sam3.Delete();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        if (this.Sam2blip != (Blip) null)
          this.Sam2blip.Remove();
        if (this.Sam3blip != (Blip) null)
          this.Sam3blip.Remove();
        this.Sam1Loc = new Vector3(772f, -1737f, 29f);
        this.Sam2Loc = new Vector3(746f, -1737f, 29f);
        this.Sam3Loc = new Vector3(730f, -1737f, 29f);
        this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Boxville5, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((GTA.Model) VehicleHash.Boxville5, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((GTA.Model) VehicleHash.Boxville5, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.PointB, 20f, 160f);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.PointB, 20f, 160f);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.PointB, 20f, 160f);
        this.Sam1.SetMod(VehicleMod.Roof, 0, true);
        this.Sam1.CreatePedOnSeat(VehicleSeat.ExtraSeat1, (GTA.Model) PedHash.ArmLieut01GMM);
        this.Sam1.GetPedOnSeat(VehicleSeat.ExtraSeat1).Task.VehicleShootAtPed(Game.Player.Character);
        this.Sam2.SetMod(VehicleMod.Roof, 0, true);
        this.Sam2.CreatePedOnSeat(VehicleSeat.ExtraSeat1, (GTA.Model) PedHash.ArmLieut01GMM);
        this.Sam2.GetPedOnSeat(VehicleSeat.ExtraSeat1).Task.VehicleShootAtPed(Game.Player.Character);
        this.Sam3.SetMod(VehicleMod.Roof, 0, true);
        this.Sam3.CreatePedOnSeat(VehicleSeat.ExtraSeat1, (GTA.Model) PedHash.ArmLieut01GMM);
        this.Sam3.GetPedOnSeat(VehicleSeat.ExtraSeat1).Task.VehicleShootAtPed(Game.Player.Character);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.Wastelander;
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "Vehicle A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        this.Sam2blip.Sprite = BlipSprite.Wastelander;
        this.Sam2blip.Color = BlipColor.Red;
        this.Sam2blip.Name = "Vehicle B";
        this.Sam3blip = World.CreateBlip(this.Sam3.Position);
        this.Sam3blip.Sprite = BlipSprite.Wastelander;
        this.Sam3blip.Color = BlipColor.Red;
        this.Sam3blip.Name = "Vehicle C";
        this.mission = 3;
        this.MissionSetup = true;
      });
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Dune3E)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Dune4, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.DuneFAV;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Ramp buggy";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " Boss go destroy that Ramp buggy, it was stolen from us");
        }
        if (item == PhantomWE)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Phantom2, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.PhantomWedge;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Phantom Wedge";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " Boss go destroy that Phantom Wedge, it was stolen from us");
        }
        if (item == Ruiner2000E)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Ruiner2, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.Ruiner2000;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Ruiner 2000";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " Boss go destroy that Ruiner 2000, it was stolen from us");
        }
        if (item == TechnicalAE)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Technical2, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.TechnicalAqua;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Technical Aqua";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " Boss go destroy that Technical Aqua, it was stolen from us");
        }
        if (item == AboxvilleE)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Boxville5, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.ArmoredBoxville;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Armored Boxville";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " Boss go destroy that Armored Boxville, it was stolen from us");
        }
        if (item == RocketVE)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Voltic2, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.RocketVoltic;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Rocket Voltic";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " Boss go destroy that Rocket Voltic, it was stolen from us");
        }
        if (item != BlazerAquaE)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Blazer5, this.GetLocation());
        this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
        this.CurrentPoint = this.GetLocation();
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.GunCar;
        this.Sam1blip.Color = BlipColor.White;
        this.Sam1blip.Name = "Blazer Aqua";
        this.MissionSetup = true;
        this.mission = 2;
        this.killedDriver = true;
        this.NOTIFY = true;
        UI.Notify(this.GetHostName() + " Boss go destroy that Blazer Aqua, it was stolen from us");
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Dune3R)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Dune4, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.DuneFAV;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Ramp buggy";
          UI.Notify(this.GetHostName() + " Boss go retrieve that Ramp buggy, it was stolen from us");
          this.MissionSetup = true;
          this.mission = 1;
          this.killedDriver = true;
          this.NOTIFY = true;
        }
        if (item == PhantomWR)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Phantom3, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.PhantomWedge;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Phantom Wedge";
          UI.Notify(this.GetHostName() + " Boss go retrieve that Phantom Wedge, it was stolen from us");
          this.MissionSetup = true;
          this.mission = 1;
          this.killedDriver = true;
          this.NOTIFY = true;
        }
        if (item == Ruiner2000R)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Ruiner2, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.Ruiner2000;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Ruiner 2000";
          UI.Notify(this.GetHostName() + " Boss go retrieve that Ruiner 2000, it was stolen from us");
          this.MissionSetup = true;
          this.mission = 1;
          this.killedDriver = true;
          this.NOTIFY = true;
        }
        if (item == TechnicalAR)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Technical2, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.TechnicalAqua;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Technical Aqua";
          UI.Notify(this.GetHostName() + " Boss go retrieve that Technical Aqua, it was stolen from us");
          this.MissionSetup = true;
          this.mission = 1;
          this.killedDriver = true;
          this.NOTIFY = true;
        }
        if (item == AboxvilleR)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Boxville5, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.ArmoredBoxville;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Armored Boxville";
          UI.Notify(this.GetHostName() + " Boss go retrieve that Armored Boxville, it was stolen from us");
          this.MissionSetup = true;
          this.mission = 1;
          this.killedDriver = true;
          this.NOTIFY = true;
        }
        if (item == RocketVR)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Voltic2, this.GetLocation());
          this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.RocketVoltic;
          this.Sam1blip.Color = BlipColor.White;
          this.Sam1blip.Name = "Rocket Voltic";
          UI.Notify(this.GetHostName() + " Boss go retrieve that Rocket Voltic, it was stolen from us");
          this.MissionSetup = true;
          this.mission = 1;
          this.killedDriver = true;
          this.NOTIFY = true;
        }
        if (item != BlazerAquaR)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Blazer5, this.GetLocation());
        this.Sam1.CreateRandomPedOnSeat(VehicleSeat.Driver);
        this.CurrentPoint = this.GetLocation();
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.GunCar;
        this.Sam1blip.Color = BlipColor.White;
        this.Sam1blip.Name = "Blazer Aqua";
        UI.Notify(this.GetHostName() + " Boss go retrieve that Blazer Aqua, it was stolen from us");
        this.MissionSetup = true;
        this.mission = 1;
        this.killedDriver = true;
        this.NOTIFY = true;
      });
    }

    public Vector3 GetLocation()
    {
      System.Random random = new System.Random();
      if (random.Next(1, 13) == 1)
        this.VehicleSpawn = new Vector3(-1069.32f, -72.28f, 19f);
      if (random.Next(1, 13) == 2)
        this.VehicleSpawn = new Vector3(-1579.93f, -155.28f, 55f);
      if (random.Next(1, 13) == 3)
        this.VehicleSpawn = new Vector3(-711.74f, -28.28f, 37f);
      if (random.Next(1, 13) == 4)
        this.VehicleSpawn = new Vector3(6f, 253.58f, 109f);
      if (random.Next(1, 13) == 5)
        this.VehicleSpawn = new Vector3(703f, 32f, 84f);
      if (random.Next(1, 13) == 6)
        this.VehicleSpawn = new Vector3(1197f, -421.5f, 68f);
      if (random.Next(1, 13) == 7)
        this.VehicleSpawn = new Vector3(1257f, -1428f, 35f);
      if (random.Next(1, 13) == 8)
        this.VehicleSpawn = new Vector3(1264f, -2039f, 45f);
      if (random.Next(1, 13) == 9)
        this.VehicleSpawn = new Vector3(527f, -2052f, 28f);
      if (random.Next(1, 13) == 10)
        this.VehicleSpawn = new Vector3(-161f, -2087.8f, 26f);
      if (random.Next(1, 13) == 11)
        this.VehicleSpawn = new Vector3(756f, -1723f, 30f);
      if (random.Next(1, 13) == 12)
        this.VehicleSpawn = new Vector3(-816f, -2300f, 11f);
      if (random.Next(1, 13) == 13)
        this.VehicleSpawn = new Vector3(-1839f, 136f, 78f);
      return this.VehicleSpawn;
    }

    public void MainModRefresh()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.Style = this.Config2.GetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
      this.Ruiner2000Bought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "Ruiner2000Bought", this.Ruiner2000Bought);
      this.RampbuggyBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "RampbuggyBought", this.RampbuggyBought);
      this.ABoxvilleBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "ABoxvilleBought", this.ABoxvilleBought);
      this.TechnicalAquaBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "TechnicalAquaBought", this.TechnicalAquaBought);
      this.PhantomWBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "PhantomWBought", this.PhantomWBought);
      this.RvolticBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "RvolticBought", this.RvolticBought);
      this.BlazerAquaBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "BlazerAquaBought", this.BlazerAquaBought);
      this.WastelanderBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "WastelanderBought", this.WastelanderBought);
      this.VehicleWarehouseBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "VehicleWarehouseBought", this.VehicleWarehouseBought);
      this.SetupMarker();
    }

    public void MainModDestroy()
    {
      if (this.Sam1blip != (Blip) null)
        this.Sam1blip.Remove();
      if (this.Sam2blip != (Blip) null)
        this.Sam2blip.Remove();
      if (this.Sam3blip != (Blip) null)
        this.Sam3blip.Remove();
      if ((Entity) this.Sam1 != (Entity) null)
        this.Sam1.Delete();
      if ((Entity) this.Sam2 != (Entity) null)
        this.Sam2.Delete();
      if ((Entity) this.Sam3 != (Entity) null)
        this.Sam3.Delete();
      if (this.VehicleMarker != (Blip) null)
        this.VehicleMarker.Remove();
      if (this.VehicleWarehouseMarker != (Blip) null)
        this.VehicleWarehouseMarker.Remove();
      if ((Entity) this.Vehicle1 != (Entity) null)
        this.Vehicle1.Delete();
      if ((Entity) this.Vehicle2 != (Entity) null)
        this.Vehicle2.Delete();
      if ((Entity) this.Vehicle3 != (Entity) null)
        this.Vehicle3.Delete();
      if ((Entity) this.Vehicle4 != (Entity) null)
        this.Vehicle4.Delete();
      if ((Entity) this.Vehicle5 != (Entity) null)
        this.Vehicle5.Delete();
      if ((Entity) this.Vehicle5 != (Entity) null)
        this.Vehicle5.Delete();
      if ((Entity) this.Vehicle6 != (Entity) null)
        this.Vehicle6.Delete();
      if ((Entity) this.Vehicle7 != (Entity) null)
        this.Vehicle7.Delete();
      if ((Entity) this.Vehicle8 != (Entity) null)
        this.Vehicle8.Delete();
      if ((Entity) this.Vehicle9 != (Entity) null)
        this.Vehicle9.Delete();
      if ((Entity) this.Vehicle10 != (Entity) null)
        this.Vehicle10.Delete();
      if ((Entity) this.Vehicle11 != (Entity) null)
        this.Vehicle11.Delete();
      if ((Entity) this.Vehicle12 != (Entity) null)
        this.Vehicle12.Delete();
      if ((Entity) this.Vehicle13 != (Entity) null)
        this.Vehicle13.Delete();
      if ((Entity) this.Vehicle14 != (Entity) null)
        this.Vehicle14.Delete();
      if ((Entity) this.Vehicle15 != (Entity) null)
        this.Vehicle15.Delete();
      if ((Entity) this.Vehicle16 != (Entity) null)
        this.Vehicle16.Delete();
      if ((Entity) this.Vehicle17 != (Entity) null)
        this.Vehicle17.Delete();
      if ((Entity) this.Vehicle18 != (Entity) null)
        this.Vehicle18.Delete();
      if ((Entity) this.Vehicle19 != (Entity) null)
        this.Vehicle19.Delete();
      if ((Entity) this.Vehicle20 != (Entity) null)
        this.Vehicle20.Delete();
      if ((Entity) this.Vehicle21 != (Entity) null)
        this.Vehicle21.Delete();
      if ((Entity) this.Vehicle22 != (Entity) null)
        this.Vehicle22.Delete();
      if ((Entity) this.Vehicle23 != (Entity) null)
        this.Vehicle23.Delete();
      if ((Entity) this.Vehicle24 != (Entity) null)
        this.Vehicle24.Delete();
      if ((Entity) this.Vehicle25 != (Entity) null)
        this.Vehicle25.Delete();
      if ((Entity) this.Vehicle26 != (Entity) null)
        this.Vehicle26.Delete();
      if ((Entity) this.Vehicle27 != (Entity) null)
        this.Vehicle27.Delete();
      if ((Entity) this.Vehicle28 != (Entity) null)
        this.Vehicle28.Delete();
      if ((Entity) this.Vehicle29 != (Entity) null)
        this.Vehicle29.Delete();
      if ((Entity) this.Vehicle30 != (Entity) null)
        this.Vehicle30.Delete();
      if ((Entity) this.Vehicle31 != (Entity) null)
        this.Vehicle31.Delete();
      if ((Entity) this.Vehicle32 != (Entity) null)
        this.Vehicle32.Delete();
      if ((Entity) this.Vehicle33 != (Entity) null)
        this.Vehicle33.Delete();
      if ((Entity) this.Vehicle34 != (Entity) null)
        this.Vehicle34.Delete();
      if ((Entity) this.Vehicle35 != (Entity) null)
        this.Vehicle35.Delete();
      if ((Entity) this.RampBuggy != (Entity) null)
        this.RampBuggy.Delete();
      if ((Entity) this.Ruiner2000 != (Entity) null)
        this.Ruiner2000.Delete();
      if ((Entity) this.Boxville != (Entity) null)
        this.Boxville.Delete();
      if ((Entity) this.TechnicalA != (Entity) null)
        this.TechnicalA.Delete();
      if ((Entity) this.Rvoltic != (Entity) null)
        this.Rvoltic.Delete();
      if ((Entity) this.PhantomW != (Entity) null)
        this.PhantomW.Delete();
      if ((Entity) this.BlazerAqua != (Entity) null)
        this.BlazerAqua.Delete();
      if (!((Entity) this.Wastelander != (Entity) null))
        return;
      this.Wastelander.Delete();
    }

    private void LoadIniFile2(string iniName)
    {
      try
      {
        this.Config2 = ScriptSettings.Load(iniName);
        this.VehicleWarehouseBought = this.Config2.GetValue<int>("Setup", "VehicleWarehouseBought", this.VehicleWarehouseBought);
        this.ChairPropModel = this.Config2.GetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
        this.Style = this.Config2.GetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
        this.Ruiner2000Bought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "Ruiner2000Bought", this.Ruiner2000Bought);
        this.RampbuggyBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "RampbuggyBought", this.RampbuggyBought);
        this.ABoxvilleBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "ABoxvilleBought", this.ABoxvilleBought);
        this.TechnicalAquaBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "TechnicalAquaBought", this.TechnicalAquaBought);
        this.PhantomWBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "PhantomWBought", this.PhantomWBought);
        this.RvolticBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "RvolticBought", this.RvolticBought);
        this.BlazerAquaBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "BlazerAquaBought", this.BlazerAquaBought);
        this.WastelanderBought = this.Config2.GetValue<int>("VEHICLEWAREHOUSES", "WastelanderBought", this.WastelanderBought);
      }
      catch (Exception ex)
      {
      }
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.LoadExecutivemain("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.MissionsMenuPool = new MenuPool();
      this.MissionsmainMenu = new UIMenu("Import/Export", "Select an Option");
      this.GUIMenus.Add(this.MissionsmainMenu);
      this.MissionsMenu = this.MissionsMenuPool.AddSubMenu(this.MissionsmainMenu, "Import/Export Missions");
      this.GUIMenus.Add(this.MissionsMenu);
      this.MissionsMenuPool.Add(this.MissionsmainMenu);
      this.IPEXMissions();
      this.SetupMarker();
      this.ExitMarker = new Vector3(970.171f, -2995.51f, -41f);
      this.modMenuPool3 = new MenuPool();
      this.mainMenu3 = new UIMenu("Buy a special Vehicle", "Select an Option");
      this.GUIMenus.Add(this.mainMenu3);
      this.modMenuPool3.Add(this.mainMenu3);
      this.BuyCar1 = this.modMenuPool3.AddSubMenu(this.mainMenu3, "Special Vehicles");
      this.GUIMenus.Add(this.BuyCar1);
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Executive Business", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.GarageMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Garage Options");
      this.GUIMenus.Add(this.GarageMenu);
      this.modMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Remove a Vehicle", "Select an Option");
      this.GUIMenus.Add(this.mainMenu2);
      this.modMenuPool2.Add(this.mainMenu2);
      this.RemoveMenu = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Remove A Vehicle");
      this.GUIMenus.Add(this.RemoveMenu);
      this.InteiorOptions = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Interior Options");
      this.GUIMenus.Add(this.InteiorOptions);
      this.SetupGarage();
      this.RemoveCar();
      this.BuyCar();
      this.SetupInterior();
      this.GunLockerMarker = new Vector3(966.68f, -2992.39f, -41f);
      this.GLmodMenuPool = new MenuPool();
      this.GLmainMenu = new UIMenu("Executive Business", "Select an Option");
      this.GUIMenus.Add(this.GLmainMenu);
      this.GLmodMenuPool.Add(this.GLmainMenu);
      this.weaponsMenu = this.GLmodMenuPool.AddSubMenu(this.GLmainMenu, "Weapons");
      this.GUIMenus.Add(this.weaponsMenu);
      this.SetupWeapons();
      this.GunLockerBought = 1;
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void SetLivery(string Weapon, string Component) => Function.Call((Hash) 11521724316029606125, (InputArgument) Function.Call<Ped>(Hash._0xD80958FC74E988A6), (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) Weapon), (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) Component), (InputArgument) this.LiveryColor);

    public int GetLivery(string Weapon, string Component) => Function.Call<int>((Hash) 17340547693307858733, (InputArgument) Function.Call<Ped>(Hash._0xD80958FC74E988A6), (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) Weapon), (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) Component));

    public bool CheckWeaponCamo(Weapon Weapon)
    {
      bool flag = false;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleClip01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo0))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoSlide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo02Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo03Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo04Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo05Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo06Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo07Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo08Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo09Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo10Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoIndependence01))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoIndependence01Slide))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo02))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo03))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo04))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo05))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo06))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo07))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo08))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo09))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo10))
        flag = true;
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2CamoIndependence01))
        flag = true;
      return flag;
    }

    public void SetWeaponLivery(Weapon Weapon)
    {
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo02))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo03))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo04))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo05))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo06))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo07))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo08))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo09))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo10))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2CamoIndependence01))
        this.SetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleClip01))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo02))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo03))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo04))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo05))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo06))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo07))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo08))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo09))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo10))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2CamoIndependence01))
        this.SetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo02))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo03))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo04))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo05))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo06))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo07))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo08))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo09))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo10))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2CamoIndependence01))
        this.SetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo02))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo03))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo04))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo05))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo06))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo07))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo08))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo09))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo10))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2CamoIndependence01))
        this.SetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo02))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo0))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo03))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo04))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo05))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo06))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo07))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo09))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo10))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2CamoIndependence01))
        this.SetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo02))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo03))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo04))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo05))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo06))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo07))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo08))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo09))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo10))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2CamoIndependence01))
        this.SetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo02))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_02_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_02");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo03))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_03_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_03");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo04))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_04_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_04");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo05))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_05_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_05");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo06))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_06_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_06");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo07))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_07_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_07");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo08))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_08_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_08");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo09))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_09_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_09");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo10))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_10_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_10");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2CamoIndependence01))
      {
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE");
        this.SetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_IND_01");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo02))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo03))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo04))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo05))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo06))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo07))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo08))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo09))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo10))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2CamoIndependence01))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01r");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo02))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo03))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo04))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo05))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo06))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo07))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo08))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo09))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo10))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2CamoIndependence01))
        this.SetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo02))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo03))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo04))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo05))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo06))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo07))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo08))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo09))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo10))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2CamoIndependence01))
        this.SetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoSlide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo02))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo02Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo03))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo03Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo04))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo04Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo05))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo05Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo06))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo06Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo07))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo07Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo08))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo08Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo09))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo09Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo10))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo10Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoIndependence01))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoIndependence01Slide))
        this.SetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo02))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo03))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo04))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo05))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo06))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo07))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo08))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo09))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo10))
        this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_10");
      if (!Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2CamoIndependence01))
        return;
      this.SetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01");
    }

    public int GetWeaponLivery(Weapon Weapon)
    {
      int num = 0;
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo02))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo03))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo04))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo05))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo06))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo07))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo08))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo09))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2Camo10))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.AssaultRifleMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_ASSAULTRIFLE_MK2", "COMPONENT_ASSAULTRIFLE_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleClip01))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo02))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo03))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo04))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo05))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo06))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo07))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo08))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo09))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2Camo10))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.BullpupRifleMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_BULLPUPRIFLE_MK2", "COMPONENT_BULLPUPRIFLE_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo02))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo03))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo04))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo05))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo06))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo07))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo08))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo09))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2Camo10))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.CarbineRifleMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_CARBINERIFLE_MK2", "COMPONENT_CARBINERIFLE_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo02))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo03))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo04))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo05))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo06))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo07))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo08))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo09))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2Camo10))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.CombatMGMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_COMBATMG_MK2", "COMPONENT_COMBATMG_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo02))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo0))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo03))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo04))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo05))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo06))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo07))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo09))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2Camo10))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.HeavySniperMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_HEAVYSNIPER_MK2", "COMPONENT_HEAVYSNIPER_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo02))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo03))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo04))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo05))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo06))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo07))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo08))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo09))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2Camo10))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.MarksmanRifleMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_MARKSMANRIFLE_MK2", "COMPONENT_MARKSMANRIFLE_MK2_CAMO_IND_01");
      int livery;
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo02))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_02_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_02");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo03))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_03_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_03");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo04))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_04_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_04");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo05))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_05_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_05");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo06))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_06_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_06");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo07))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_07_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_07");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo08))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_08_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_08");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo09))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_09_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_09");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2Camo10))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_10_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_10");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PistolMk2CamoIndependence01))
      {
        livery = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_IND_01_SLIDE");
        num = this.GetLivery("WEAPON_PISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_IND_01");
      }
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo02))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo03))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo04))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo05))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo06))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo07))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo08))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo09))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2Camo10))
        num = this.GetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.PumpShotgunMk2CamoIndependence01))
        this.SetLivery("WEAPON_PUMPSHOTGUN_MK2", "COMPONENT_PUMPSHOTGUN_MK2_CAMO_IND_01r");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo02))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo03))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo04))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo05))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo06))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo07))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo08))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo09))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2Camo10))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.RevolverMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_REVOLVER_MK2", "COMPONENT_REVOLVER_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo02))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo03))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo04))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo05))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo06))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo07))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo08))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo09))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2Camo10))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.SMGMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_SMG_MK2", "COMPONENT_SMG_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoSlide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_PISTOL_MK2_CAMO_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo02))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo02Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_02_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo03))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo03Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_03_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo04))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo04Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_04_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo05))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo05Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_05_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo06))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo06Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_06_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo07))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo07Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_07_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo08))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo08Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_08_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo09))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo09Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_09_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo10))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2Camo10Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_10_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01");
      if (Weapon.IsComponentActive(WeaponComponent.SNSPistolMk2CamoIndependence01Slide))
        num = this.GetLivery("WEAPON_SNSPISTOL_MK2", "COMPONENT_SNSPISTOL_MK2_CAMO_IND_01_SLIDE");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo02))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_02");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo03))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_03");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo04))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_04");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo05))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_05");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo06))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_06");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo07))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_07");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo08))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_08");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo09))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_09");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2Camo10))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_10");
      if (Weapon.IsComponentActive(WeaponComponent.SpecialCarbineMk2CamoIndependence01))
        num = this.GetLivery("WEAPON_SPECIALCARBINE_MK2", "COMPONENT_SPECIALCARBINE_MK2_CAMO_IND_01");
      return num;
    }

    private void SetupWeapons()
    {
      List<object> items1 = new List<object>();
      items1.Add((object) "Classic Black");
      items1.Add((object) "Classic Gray");
      items1.Add((object) "Classic Two-Tone");
      items1.Add((object) "Classic White");
      items1.Add((object) "Classic Beige");
      items1.Add((object) "Classic Green");
      items1.Add((object) "Classic Blue");
      items1.Add((object) "Classic Earth");
      items1.Add((object) "Classic Brown & Black");
      items1.Add((object) "Red Contrast");
      items1.Add((object) "Blue Contrast");
      items1.Add((object) "Yellow Contrast");
      items1.Add((object) "Orange Contrast");
      items1.Add((object) "Bold Pink");
      items1.Add((object) "Bold Purple & Yellow");
      items1.Add((object) "Bold Orange");
      items1.Add((object) "Bold Green & Purple");
      items1.Add((object) "Bold Red & Black");
      items1.Add((object) "Bold Green & Black");
      items1.Add((object) "Bold Cyan & Black");
      items1.Add((object) "Bold Yellow & Black");
      items1.Add((object) "Bold Red & White");
      items1.Add((object) "Bold Blue & White");
      items1.Add((object) "Metallic Gold");
      items1.Add((object) "Metallic Platinum");
      items1.Add((object) "Metallic Gray & Lilac");
      items1.Add((object) "Metallic Purple & Lime");
      items1.Add((object) "Metallic Red");
      items1.Add((object) "Metallic Green");
      items1.Add((object) "Metallic Blue");
      items1.Add((object) "Metallic White & Aqua");
      items1.Add((object) "Metallic Red & Yellow");
      List<object> items2 = new List<object>();
      items2.Add((object) "Grey");
      items2.Add((object) "Dark Grey");
      items2.Add((object) "Black");
      items2.Add((object) "White");
      items2.Add((object) "Blue ");
      items2.Add((object) "Cyan");
      items2.Add((object) "Aqua");
      items2.Add((object) "Cool Blue");
      items2.Add((object) "Dark Blue");
      items2.Add((object) "Royal Blue");
      items2.Add((object) "Plum");
      items2.Add((object) "Dark Purple");
      items2.Add((object) "Purple");
      items2.Add((object) "Red");
      items2.Add((object) "Wine Red");
      items2.Add((object) "Magenta");
      items2.Add((object) "Pink ");
      items2.Add((object) "Salmon");
      items2.Add((object) "Hot Pink");
      items2.Add((object) "Rust Orange ");
      items2.Add((object) "Brown");
      items2.Add((object) "Earth");
      items2.Add((object) "Orange");
      items2.Add((object) "Light Orange");
      items2.Add((object) "Dark Yellow");
      items2.Add((object) "Yellow");
      items2.Add((object) "Light Brown");
      items2.Add((object) "Lime Green");
      items2.Add((object) "Olive");
      items2.Add((object) "Moss");
      items2.Add((object) "Turquoise");
      items2.Add((object) "Dark Green");
      float CPrice = 34000f;
      List<object> Mk2Weapons = new List<object>();
      Mk2Weapons.Add((object) WeaponHash.AssaultrifleMk2);
      Mk2Weapons.Add((object) WeaponHash.BullpupRifleMk2);
      Mk2Weapons.Add((object) WeaponHash.CarbineRifleMk2);
      Mk2Weapons.Add((object) WeaponHash.CombatMGMk2);
      Mk2Weapons.Add((object) WeaponHash.HeavySniperMk2);
      Mk2Weapons.Add((object) WeaponHash.MarksmanRifleMk2);
      Mk2Weapons.Add((object) WeaponHash.PistolMk2);
      Mk2Weapons.Add((object) WeaponHash.PumpShotgunMk2);
      Mk2Weapons.Add((object) WeaponHash.RevolverMk2);
      Mk2Weapons.Add((object) WeaponHash.SMGMk2);
      Mk2Weapons.Add((object) WeaponHash.SNSPistolMk2);
      Mk2Weapons.Add((object) WeaponHash.SpecialCarbineMk2);
      List<object> Components = new List<object>();
      Components.Add((object) WeaponComponent.AssaultRifleClip01);
      Components.Add((object) WeaponComponent.AssaultRifleClip02);
      UIMenu uiMenu1 = this.GLmodMenuPool.AddSubMenu(this.weaponsMenu, "Mk2 Weapons (Advanced)");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem W = new UIMenuListItem("Weapon : ", Mk2Weapons, 0);
      uiMenu1.AddItem((UIMenuItem) W);
      UIMenuListItem C = new UIMenuListItem("Component  : ", Components, 0);
      uiMenu1.AddItem((UIMenuItem) C);
      UIMenuItem Enable = new UIMenuItem("Enable Component : $" + CPrice.ToString("N"));
      uiMenu1.AddItem(Enable);
      UIMenuItem DIsable = new UIMenuItem("Disable Component");
      uiMenu1.AddItem(DIsable);
      UIMenuItem uiMenuItem1 = new UIMenuItem("-------------------------------------------------------------");
      uiMenu1.AddItem(uiMenuItem1);
      UIMenuListItem WT = new UIMenuListItem("Tint ", items1, 0);
      uiMenu1.AddItem((UIMenuItem) WT);
      UIMenuItem getTintAV = new UIMenuItem("Buy Tint: $10,000");
      uiMenu1.AddItem(getTintAV);
      UIMenuItem uiMenuItem2 = new UIMenuItem("-------------------------------------------------------------");
      uiMenu1.AddItem(uiMenuItem2);
      UIMenuListItem WT2 = new UIMenuListItem("Livery Tint ", items2, 0);
      uiMenu1.AddItem((UIMenuItem) WT2);
      UIMenuItem getTintAV2 = new UIMenuItem("Buy Livery Tint: $10,000");
      uiMenu1.AddItem(getTintAV2);
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == W)
        {
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p1 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__0 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__0.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__0, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
          if (target1((CallSite) p1, obj1))
          {
            Components.Clear();
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__2 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__2.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__2, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
            foreach (WeaponComponent weaponComponent in (WeaponComponent[]) Enum.GetValues(typeof (WeaponComponent)))
            {
              try
              {
                if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) W.IndexToItem(W.Index).GetHashCode(), (InputArgument) weaponComponent.GetHashCode()))
                  Components.Add((object) weaponComponent);
              }
              catch
              {
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target2 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__4.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p4 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__4;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__3.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__3, Components[C.Index]);
          string str = target2((CallSite) p4, obj2);
          if (str.Contains("Muzzle"))
          {
            CPrice = 45700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Barrel"))
          {
            CPrice = 48700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Barrel"))
          {
            CPrice = 48700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Sights"))
          {
            CPrice = 24700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Tracer"))
          {
            CPrice = 42700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("FMJ"))
          {
            CPrice = 73000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("ArmourPiercing"))
          {
            CPrice = 63000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Incediary"))
          {
            CPrice = 49000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("ClipExplosive"))
          {
            CPrice = 115450f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Grip"))
          {
            CPrice = 14080f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Supp"))
          {
            CPrice = 40250f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Clip02"))
          {
            CPrice = 60000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo01"))
          {
            CPrice = 40000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo02"))
          {
            CPrice = 43500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo03"))
          {
            CPrice = 43500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo04"))
          {
            CPrice = 45500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo05"))
          {
            CPrice = 49500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo06"))
          {
            CPrice = 75500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo07"))
          {
            CPrice = 51500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo08"))
          {
            CPrice = 53500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo09"))
          {
            CPrice = 55500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo10"))
          {
            CPrice = 60500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Independence"))
          {
            CPrice = 100500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
        }
        if (item != C)
          return;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p6 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__5.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__5, Components[C.Index]);
        string str1 = target((CallSite) p6, obj);
        if (str1.Contains("Barrel"))
        {
          CPrice = 48700f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Barrel"))
        {
          CPrice = 48700f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Sights"))
        {
          CPrice = 24700f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Tracer"))
        {
          CPrice = 42700f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("FMJ"))
        {
          CPrice = 73000f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("ArmourPiercing"))
        {
          CPrice = 63000f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Incediary"))
        {
          CPrice = 49000f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("ClipExplosive"))
        {
          CPrice = 115450f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Grip"))
        {
          CPrice = 14080f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Supp"))
        {
          CPrice = 40250f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Clip02"))
        {
          CPrice = 60000f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo01"))
        {
          CPrice = 40000f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo02"))
        {
          CPrice = 43500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo03"))
        {
          CPrice = 43500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo04"))
        {
          CPrice = 45500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo05"))
        {
          CPrice = 49500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo06"))
        {
          CPrice = 75500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo07"))
        {
          CPrice = 51500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo08"))
        {
          CPrice = 53500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo09"))
        {
          CPrice = 55500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (str1.Contains("Camo10"))
        {
          CPrice = 60500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
        if (!str1.Contains("Independence"))
          return;
        CPrice = 100500f;
        Enable.Text = "Enable Component : $" + CPrice.ToString("N");
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTintAV2)
        {
          this.LiveryColor = WT2.Index;
          if (Game.Player.Character.Weapons.Current != null)
            this.SetWeaponLivery(Game.Player.Character.Weapons.Current);
        }
        if (item == getTintAV)
        {
          try
          {
            int index1 = WT.Index;
            Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.Weapons.Current.GetHashCode(), (InputArgument) index1);
            Game.Player.Character.Weapons.Current.Tint = (WeaponTint) index1;
            Game.Player.Money -= 10000;
          }
          catch (Exception ex)
          {
            UI.Notify("Error");
          }
        }
        if (item == Enable)
        {
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target1 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p8 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__7.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__7, Components[C.Index]);
          string str = target1((CallSite) p8, obj1);
          if (str.Contains("Barrel"))
          {
            CPrice = 48700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Barrel"))
          {
            CPrice = 48700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Sights"))
          {
            CPrice = 24700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Tracer"))
          {
            CPrice = 42700f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("FMJ"))
          {
            CPrice = 73000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("ArmourPiercing"))
          {
            CPrice = 63000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Incediary"))
          {
            CPrice = 49000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("ClipExplosive"))
          {
            CPrice = 115450f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Grip"))
          {
            CPrice = 14080f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Supp"))
          {
            CPrice = 40250f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Clip02"))
          {
            CPrice = 60000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo01"))
          {
            CPrice = 40000f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo02"))
          {
            CPrice = 43500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo03"))
          {
            CPrice = 43500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo04"))
          {
            CPrice = 45500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo05"))
          {
            CPrice = 49500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo06"))
          {
            CPrice = 75500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo07"))
          {
            CPrice = 51500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo08"))
          {
            CPrice = 53500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo09"))
          {
            CPrice = 55500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Camo10"))
          {
            CPrice = 60500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if (str.Contains("Independence"))
          {
            CPrice = 100500f;
            Enable.Text = "Enable Component : $" + CPrice.ToString("N");
          }
          if ((double) Game.Player.Money >= (double) CPrice)
          {
            Game.Player.Money -= (int) CPrice;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, bool> target2 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__10.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, bool>> p10 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__10;
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__9 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__9 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__9.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__9, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
            if (target2((CallSite) p10, obj2))
            {
              if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) W.IndexToItem(W.Index).GetHashCode(), (InputArgument) C.IndexToItem(C.Index).GetHashCode()))
              {
                // ISSUE: reference to a compiler-generated field
                if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__11 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__11 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__11.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__11, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
                // ISSUE: reference to a compiler-generated field
                if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__12 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__12 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__12.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__12, Game.Player.Character.Weapons.Current, Components[C.Index], true);
              }
            }
          }
        }
        if (item != DIsable)
          return;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__14.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p14 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__14;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__13 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__13.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__13, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
        if (!target3((CallSite) p14, obj3))
          return;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__19 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target4 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__19.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p19 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__19;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__18 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool, object> target5 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__18.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool, object>> p18 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__18;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__17 = CallSite<Func<CallSite, System.Type, Hash, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Call", (IEnumerable<System.Type>) new System.Type[1]
          {
            typeof (bool)
          }, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, System.Type, Hash, object, object, object> target6 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__17.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, System.Type, Hash, object, object, object>> p17 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__17;
        System.Type type = typeof (Function);
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__15 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__15.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__15, Mk2Weapons[W.Index]);
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__16 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj5 = VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__16.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__16, Components[C.Index]);
        object obj6 = target6((CallSite) p17, type, Hash._0x5CEE3DF569CECAB0, obj4, obj5);
        object obj7 = target5((CallSite) p18, obj6, true);
        if (!target4((CallSite) p19, obj7))
          return;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__20 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__20.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__20, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__21 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__21 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__21.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__219.\u003C\u003Ep__21, Game.Player.Character.Weapons.Current, Components[C.Index], false);
      });
      UIMenu uiMenu2 = this.GLmodMenuPool.AddSubMenu(this.weaponsMenu, "Scifi Weapons");
      this.GUIMenus.Add(uiMenu2);
      UIMenu menu = this.GLmodMenuPool.AddSubMenu(this.weaponsMenu, "Mk2 Weapons");
      this.GUIMenus.Add(menu);
      UIMenu uiMenu3 = this.GLmodMenuPool.AddSubMenu(this.weaponsMenu, "Normal Weapons");
      this.GUIMenus.Add(uiMenu3);
      List<object> items3 = new List<object>();
      for (int index = 0; index < this.Tintscount; ++index)
        items3.Add((object) index);
      this.MK2Pumpshotgun = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Pump Shotgun");
      this.GUIMenus.Add(this.MK2Pumpshotgun);
      this.MK2SNSPistol = this.GLmodMenuPool.AddSubMenu(menu, "MK2 SNS Pistol");
      this.GUIMenus.Add(this.MK2SNSPistol);
      this.MK2Revolver = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Revolver");
      this.GUIMenus.Add(this.MK2Revolver);
      this.Mk2SpecialCarbine = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Special Carbine");
      this.GUIMenus.Add(this.Mk2SpecialCarbine);
      this.MK2Bullpup = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Bullpup Rifle");
      this.GUIMenus.Add(this.MK2Bullpup);
      this.MK2MarksmanRifle = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Marksmans Rifle");
      this.GUIMenus.Add(this.MK2MarksmanRifle);
      this.MK2Pistol = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Pistol");
      this.GUIMenus.Add(this.MK2Pistol);
      this.MK2SMG = this.GLmodMenuPool.AddSubMenu(menu, "MK2 SMG");
      this.GUIMenus.Add(this.MK2SMG);
      this.MK2LMG = this.GLmodMenuPool.AddSubMenu(menu, "MK2 LMG");
      this.GUIMenus.Add(this.MK2LMG);
      this.MK2Carbine = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Carbine");
      this.GUIMenus.Add(this.MK2Carbine);
      this.MK2AssaultRifle = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Assault Rifle");
      this.GUIMenus.Add(this.MK2AssaultRifle);
      this.MK2Sniper = this.GLmodMenuPool.AddSubMenu(menu, "MK2 Sniper");
      this.GUIMenus.Add(this.MK2Sniper);
      UIMenuItem mk2ShotgunP = new UIMenuItem("MK2 Pump Shotgun: $75,000");
      this.MK2Pumpshotgun.AddItem(mk2ShotgunP);
      UIMenuItem mk2Shotgunclip = new UIMenuItem("Normal Shells : $0");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunclip);
      UIMenuItem mk2Shotgunclip1 = new UIMenuItem("Dragon's Breath Shells : $65,200");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunclip1);
      UIMenuItem mk2Shotgunclip3 = new UIMenuItem("Flechette Shells: $75,140");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunclip3);
      UIMenuItem mk2Shotgunclip2 = new UIMenuItem("Steel Buckshot Shells: $96,645");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunclip2);
      UIMenuItem mk2Shotgunclip4 = new UIMenuItem("Explosive Shells: $145,850");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunclip4);
      UIMenuItem mk2Shotgunsights = new UIMenuItem("Holographic Sight: $29,260");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunsights);
      UIMenuItem mk2Shotgunsights2 = new UIMenuItem("Small Scope: $39,920");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunsights2);
      UIMenuItem mk2Shotgunsights3 = new UIMenuItem("Medium Scope: $50,785");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunsights3);
      UIMenuItem mk2Shotgunflashlight = new UIMenuItem("Flashlight: $10,500");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunflashlight);
      UIMenuItem mk2ShotgunSuppressor = new UIMenuItem("Suppressor: $45,860");
      this.MK2Pumpshotgun.AddItem(mk2ShotgunSuppressor);
      UIMenuItem mk2Shotgunmuzzle = new UIMenuItem("Muzzle Brake: $37,650");
      this.MK2Pumpshotgun.AddItem(mk2Shotgunmuzzle);
      UIMenuListItem list1 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2Pumpshotgun.AddItem((UIMenuItem) list1);
      UIMenuItem getTint1 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2Pumpshotgun.AddItem(getTint1);
      UIMenuItem mk2Snspistol = new UIMenuItem("MK2 SNS Pistol: $35,000");
      this.MK2SNSPistol.AddItem(mk2Snspistol);
      UIMenuItem mk2Snspistolclipn = new UIMenuItem("Default Clip: $8,000");
      this.MK2SNSPistol.AddItem(mk2Snspistolclipn);
      UIMenuItem mk2Snspistolclipe = new UIMenuItem("Extended Clip: $18,300");
      this.MK2SNSPistol.AddItem(mk2Snspistolclipe);
      UIMenuItem mk2Snspistolclip1 = new UIMenuItem("Tracer Rounds: $34,320");
      this.MK2SNSPistol.AddItem(mk2Snspistolclip1);
      UIMenuItem mk2Snspistolclip2 = new UIMenuItem("Incendiary Rounds: $41,700");
      this.MK2SNSPistol.AddItem(mk2Snspistolclip2);
      UIMenuItem mk2Snspistolclip3 = new UIMenuItem("Hollow Point Rounds : $47,580");
      this.MK2SNSPistol.AddItem(mk2Snspistolclip3);
      UIMenuItem mk2Snspistolclip4 = new UIMenuItem("Full Metal Jacket Rounds: $62,400");
      this.MK2SNSPistol.AddItem(mk2Snspistolclip4);
      UIMenuItem mk2Snspistolflash = new UIMenuItem("Flashlight: $7,500");
      this.MK2SNSPistol.AddItem(mk2Snspistolflash);
      UIMenuItem mk2Snspistolscope1 = new UIMenuItem("Mounted Scope: $16,250");
      this.MK2SNSPistol.AddItem(mk2Snspistolscope1);
      UIMenuItem mk2Snspistolsuppressor = new UIMenuItem("Suppressor: $28,750");
      this.MK2SNSPistol.AddItem(mk2Snspistolsuppressor);
      UIMenuItem mk2Snspistolcomp = new UIMenuItem("Compensator: $21,250");
      this.MK2SNSPistol.AddItem(mk2Snspistolcomp);
      UIMenuListItem list2 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2SNSPistol.AddItem((UIMenuItem) list2);
      UIMenuItem getTint2 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2SNSPistol.AddItem(getTint2);
      UIMenuItem mk2Revolver = new UIMenuItem("MK2 Revolver: $35,000");
      this.MK2Revolver.AddItem(mk2Revolver);
      UIMenuItem mk2Revolverclip = new UIMenuItem("Normal Rounds: $0");
      this.MK2Revolver.AddItem(mk2Revolverclip);
      UIMenuItem mk2Revolverclip1 = new UIMenuItem("Tracer Rounds: $31,460");
      this.MK2Revolver.AddItem(mk2Revolverclip1);
      UIMenuItem mk2Revolverclip2 = new UIMenuItem("Incendiary Rounds: $38,225");
      this.MK2Revolver.AddItem(mk2Revolverclip2);
      UIMenuItem mk2Revolverclip3 = new UIMenuItem("Hollow Point Rounds: $43,615");
      this.MK2Revolver.AddItem(mk2Revolverclip3);
      UIMenuItem mk2Revolverclip4 = new UIMenuItem("Full Metal Jacket Rounds: $57,200");
      this.MK2Revolver.AddItem(mk2Revolverclip4);
      UIMenuItem mk2Revolversights = new UIMenuItem("Holographic Sight: $16,250");
      this.MK2Revolver.AddItem(mk2Revolversights);
      UIMenuItem mk2Revolversights1 = new UIMenuItem("Small Scope: $25,450");
      this.MK2Revolver.AddItem(mk2Revolversights1);
      UIMenuItem mk2Revolverflashlight = new UIMenuItem("Flashlight: $7,500");
      this.MK2Revolver.AddItem(mk2Revolverflashlight);
      UIMenuItem mk2RevolverComp = new UIMenuItem("Compensator: $21,250");
      this.MK2Revolver.AddItem(mk2RevolverComp);
      UIMenuListItem list3 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2Revolver.AddItem((UIMenuItem) list3);
      UIMenuItem getTint3 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2Revolver.AddItem(getTint3);
      UIMenuItem mk2SCarbine = new UIMenuItem("MK2 Special Carbine: $65,000");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbine);
      UIMenuItem mk2SCarbineclip = new UIMenuItem("Default Clip: $5,000");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbineclip);
      UIMenuItem mk2SCarbineclip1 = new UIMenuItem("Extended Clip: $26,450");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbineclip1);
      UIMenuItem mk2SCarbineclip2 = new UIMenuItem("Tracer Rounds: $61,465");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbineclip2);
      UIMenuItem mk2SCarbineclip3 = new UIMenuItem("Incendiary Rounds : $70,950");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbineclip3);
      UIMenuItem mk2SCarbineclip4 = new UIMenuItem("Armor Piercing Rounds : $90,750");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbineclip4);
      UIMenuItem mk2SCarbineclip5 = new UIMenuItem("Full Metal Jacket Rounds : $104,775");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbineclip5);
      UIMenuItem mk2SCarbineflash = new UIMenuItem("Flashlight: $10,500");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbineflash);
      UIMenuItem mk2SCarbinesight1 = new UIMenuItem("Holographic Sight: $19,600");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbinesight1);
      UIMenuItem mk2SCarbinesight2 = new UIMenuItem("Small Scope: $23,730");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbinesight2);
      UIMenuItem mk2SCarbinesight3 = new UIMenuItem("Large Scope: $34,020");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbinesight3);
      UIMenuItem mk2SCarbinesupressor = new UIMenuItem("Suppressor : $40,250");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbinesupressor);
      UIMenuItem mk2SCarbinemuzzle = new UIMenuItem("Muzzle : $29,750");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbinemuzzle);
      UIMenuItem mk2SCarbinegrip = new UIMenuItem("Grip : $14,080");
      this.Mk2SpecialCarbine.AddItem(mk2SCarbinegrip);
      UIMenuListItem list4 = new UIMenuListItem("Tint ", items3, 0);
      this.Mk2SpecialCarbine.AddItem((UIMenuItem) list4);
      UIMenuItem getTint4 = new UIMenuItem("Buy Tint: $10,000");
      this.Mk2SpecialCarbine.AddItem(getTint4);
      UIMenuItem mk2Bullpup = new UIMenuItem("MK2 Bullpup Rifle: $60,000");
      this.MK2Bullpup.AddItem(mk2Bullpup);
      UIMenuItem mk2Bullpupclip1 = new UIMenuItem("Default Clip : $5,000");
      this.MK2Bullpup.AddItem(mk2Bullpupclip1);
      UIMenuItem mk2Bullpupclip2 = new UIMenuItem("Extended Clip : $22,100");
      this.MK2Bullpup.AddItem(mk2Bullpupclip2);
      UIMenuItem mk2Bullpupclip3 = new UIMenuItem("Tracer Rounds : $44,350");
      this.MK2Bullpup.AddItem(mk2Bullpupclip3);
      UIMenuItem mk2Bullpupclip4 = new UIMenuItem("Incendiary Rounds : $52,100");
      this.MK2Bullpup.AddItem(mk2Bullpupclip4);
      UIMenuItem mk2Bullpupclip5 = new UIMenuItem("Armor Piercing Rounds  : $87,320");
      this.MK2Bullpup.AddItem(mk2Bullpupclip5);
      UIMenuItem mk2Bullpupclip6 = new UIMenuItem("Full Metal Jacket Rounds : $77,490");
      this.MK2Bullpup.AddItem(mk2Bullpupclip6);
      UIMenuItem mk2Bullpupflash = new UIMenuItem("Flashlight  : $10,500");
      this.MK2Bullpup.AddItem(mk2Bullpupflash);
      UIMenuItem mk2Bullpupsight1 = new UIMenuItem("Holographic Sight : $19,600");
      this.MK2Bullpup.AddItem(mk2Bullpupsight1);
      UIMenuItem mk2Bullpupsight2 = new UIMenuItem("Small Scope : $23,730");
      this.MK2Bullpup.AddItem(mk2Bullpupsight2);
      UIMenuItem mk2Bullpupsight3 = new UIMenuItem("Medium Scope : $34,020");
      this.MK2Bullpup.AddItem(mk2Bullpupsight3);
      UIMenuItem mk2BullpupBarrel = new UIMenuItem("Heavy Barrel : $49,000");
      this.MK2Bullpup.AddItem(mk2BullpupBarrel);
      UIMenuItem mk2BullpupGrip = new UIMenuItem("Grip : $14,080");
      this.MK2Bullpup.AddItem(mk2BullpupGrip);
      UIMenuItem mk2Bullpupmuzzle = new UIMenuItem("Muzzle  : $29,750");
      this.MK2Bullpup.AddItem(mk2Bullpupmuzzle);
      UIMenuItem mk2BullpupSuppressor = new UIMenuItem("Suppressor  : $40,250");
      this.MK2Bullpup.AddItem(mk2BullpupSuppressor);
      UIMenuListItem list5 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2Bullpup.AddItem((UIMenuItem) list5);
      UIMenuItem getTint5 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2Bullpup.AddItem(getTint5);
      UIMenuItem mk2marksman = new UIMenuItem("MK2 Marksman Rifle : $80,000");
      this.MK2MarksmanRifle.AddItem(mk2marksman);
      UIMenuItem mk2marksmanclip1 = new UIMenuItem("Default Clip : $5,000");
      this.MK2MarksmanRifle.AddItem(mk2marksmanclip1);
      UIMenuItem mk2marksmanclip2 = new UIMenuItem("Extended Clip : $26,850");
      this.MK2MarksmanRifle.AddItem(mk2marksmanclip2);
      UIMenuItem mk2marksmanclip3 = new UIMenuItem("Tracer Rounds : $49,775");
      this.MK2MarksmanRifle.AddItem(mk2marksmanclip3);
      UIMenuItem mk2marksmanclip4 = new UIMenuItem("Incendiary Rounds : $57,295");
      this.MK2MarksmanRifle.AddItem(mk2marksmanclip4);
      UIMenuItem mk2marksmanclip5 = new UIMenuItem("Armor Piercing Rounds  : $73,560");
      this.MK2MarksmanRifle.AddItem(mk2marksmanclip5);
      UIMenuItem mk2marksmanclip6 = new UIMenuItem("Full Metal Jacket Rounds : $85,570");
      this.MK2MarksmanRifle.AddItem(mk2marksmanclip6);
      UIMenuItem mk2marksmanflash = new UIMenuItem("Flashlight  : $11,250");
      this.MK2MarksmanRifle.AddItem(mk2marksmanflash);
      UIMenuItem mk2marksmansight1 = new UIMenuItem("Holographic Sight  : $11,485");
      this.MK2MarksmanRifle.AddItem(mk2marksmansight1);
      UIMenuItem mk2marksmansight2 = new UIMenuItem("Large Scope  : $17,870");
      this.MK2MarksmanRifle.AddItem(mk2marksmansight2);
      UIMenuItem mk2marksmansight3 = new UIMenuItem("Zoom Scope  : $27,150");
      this.MK2MarksmanRifle.AddItem(mk2marksmansight3);
      UIMenuItem mk2marksmanGrip = new UIMenuItem("Grip  : $14,080");
      this.MK2MarksmanRifle.AddItem(mk2marksmanGrip);
      UIMenuItem mk2marksmanmuzzle = new UIMenuItem("Muzzle  : $44,620");
      this.MK2MarksmanRifle.AddItem(mk2marksmanmuzzle);
      UIMenuItem mk2marksmanSuppressor = new UIMenuItem("Suppressor  : $60,375");
      this.MK2MarksmanRifle.AddItem(mk2marksmanSuppressor);
      UIMenuListItem list6 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2MarksmanRifle.AddItem((UIMenuItem) list6);
      UIMenuItem getTint6 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2MarksmanRifle.AddItem(getTint6);
      UIMenuItem mk2pistol = new UIMenuItem("MK2 Pistol : $20,000");
      this.MK2Pistol.AddItem(mk2pistol);
      UIMenuItem mk2pistolClip = new UIMenuItem("Default Clip : $0");
      this.MK2Pistol.AddItem(mk2pistolClip);
      UIMenuItem mk2pistolClip1 = new UIMenuItem("Extended Clip : $15,250");
      this.MK2Pistol.AddItem(mk2pistolClip1);
      UIMenuItem mk2pistolClip2 = new UIMenuItem("Tracer Rounds : $32,850");
      this.MK2Pistol.AddItem(mk2pistolClip2);
      UIMenuItem mk2pistolClip3 = new UIMenuItem("Incendiary Rounds : $34,750");
      this.MK2Pistol.AddItem(mk2pistolClip3);
      UIMenuItem mk2pistolClip4 = new UIMenuItem("Hollow Point Rounds : $39,650");
      this.MK2Pistol.AddItem(mk2pistolClip4);
      UIMenuItem mk2pistolClip5 = new UIMenuItem("Full Metal Jacket Rounds  : $52,000");
      this.MK2Pistol.AddItem(mk2pistolClip5);
      UIMenuItem mk2pistolSight1 = new UIMenuItem("Mounted Scope : $16,250");
      this.MK2Pistol.AddItem(mk2pistolSight1);
      UIMenuItem mk2pistolflash = new UIMenuItem("Flashlight : $7,500");
      this.MK2Pistol.AddItem(mk2pistolflash);
      UIMenuItem mk2pistolsupp = new UIMenuItem("Suppressor : $28,750");
      this.MK2Pistol.AddItem(mk2pistolsupp);
      UIMenuItem mk2pistolcomp = new UIMenuItem("Compensator : $21,250");
      this.MK2Pistol.AddItem(mk2pistolcomp);
      UIMenuListItem list7 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2Pistol.AddItem((UIMenuItem) list7);
      UIMenuItem getTint7 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2Pistol.AddItem(getTint7);
      UIMenuItem mk2smg = new UIMenuItem("MK2 SMG : $25,000");
      this.MK2SMG.AddItem(mk2smg);
      UIMenuItem mk2smgclip = new UIMenuItem("Default Clip : $0");
      this.MK2SMG.AddItem(mk2smgclip);
      UIMenuItem mk2smgclip1 = new UIMenuItem("Extended Clip : $18,300");
      this.MK2SMG.AddItem(mk2smgclip1);
      UIMenuItem mk2smgClip2 = new UIMenuItem("Tracer Rounds : $28,600");
      this.MK2SMG.AddItem(mk2smgClip2);
      UIMenuItem mk2smgClip3 = new UIMenuItem("Incendiary Rounds : $34,750");
      this.MK2SMG.AddItem(mk2smgClip3);
      UIMenuItem mk2smgClip4 = new UIMenuItem("Hollow Point Rounds : $39,650");
      this.MK2SMG.AddItem(mk2smgClip4);
      UIMenuItem mk2smgClip5 = new UIMenuItem("Full Metal Jacket Rounds  : $52,000");
      this.MK2SMG.AddItem(mk2smgClip5);
      this.MK2SMG.AddItem(new UIMenuItem("Flashlight : $7,500"));
      UIMenuItem mk2smgsight1 = new UIMenuItem("Holographic Sight : $15,200");
      this.MK2SMG.AddItem(mk2smgsight1);
      UIMenuItem mk2smgsight2 = new UIMenuItem("Small Scope: $19,950");
      this.MK2SMG.AddItem(mk2smgsight2);
      UIMenuItem mk2smgsight3 = new UIMenuItem("Holographic Sight : $24,100");
      this.MK2SMG.AddItem(mk2smgsight3);
      UIMenuItem mk2smgsupp = new UIMenuItem("Suppressor  : $34,500");
      this.MK2SMG.AddItem(mk2smgsupp);
      UIMenuItem mk2smgmuzzle = new UIMenuItem("Muzzle : $25,500");
      this.MK2SMG.AddItem(mk2smgmuzzle);
      UIMenuItem mk2smgbarrel = new UIMenuItem("Barrel : $22,500");
      this.MK2SMG.AddItem(mk2smgbarrel);
      UIMenuListItem list8 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2SMG.AddItem((UIMenuItem) list8);
      UIMenuItem getTint8 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2SMG.AddItem(getTint8);
      UIMenuItem mk2carbine = new UIMenuItem("MK2 Carbine : $35,000");
      this.MK2Carbine.AddItem(mk2carbine);
      UIMenuItem mk2carbineClip1 = new UIMenuItem("Default Clip: $0");
      this.MK2Carbine.AddItem(mk2carbineClip1);
      UIMenuItem mk2carbineClip2 = new UIMenuItem("Extended Clip: $25,925");
      this.MK2Carbine.AddItem(mk2carbineClip2);
      UIMenuItem mk2carbineClip3 = new UIMenuItem("Tracer Rounds: $44,700");
      this.MK2Carbine.AddItem(mk2carbineClip3);
      UIMenuItem mk2carbineClip4 = new UIMenuItem("Incendiary Rounds : $51,600");
      this.MK2Carbine.AddItem(mk2carbineClip4);
      UIMenuItem mk2carbineClip5 = new UIMenuItem("Armor Piercing Rounds: $66,000 ");
      this.MK2Carbine.AddItem(mk2carbineClip5);
      UIMenuItem mk2carbineClip6 = new UIMenuItem("Full Metal Jacket Rounds: $76,200 ");
      this.MK2Carbine.AddItem(mk2carbineClip6);
      UIMenuItem mk2carbineGrip = new UIMenuItem("Grip: $14,080 ");
      this.MK2Carbine.AddItem(mk2carbineGrip);
      UIMenuItem mk2carbineFlash = new UIMenuItem("Flashlight: $10,500 ");
      this.MK2Carbine.AddItem(mk2carbineFlash);
      UIMenuItem mk2carbineSight1 = new UIMenuItem("Holographic Sight: $19,600  ");
      this.MK2Carbine.AddItem(mk2carbineSight1);
      UIMenuItem mk2carbineSight2 = new UIMenuItem("Small Scope: $23,730 ");
      this.MK2Carbine.AddItem(mk2carbineSight2);
      UIMenuItem mk2carbineSight3 = new UIMenuItem("Large Scope: $34,020 ");
      this.MK2Carbine.AddItem(mk2carbineSight3);
      UIMenuItem mk2carbineSupp = new UIMenuItem("Suppressor: $40,250 ");
      this.MK2Carbine.AddItem(mk2carbineSupp);
      UIMenuListItem list9 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2Carbine.AddItem((UIMenuItem) list9);
      UIMenuItem getTint9 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2Carbine.AddItem(getTint9);
      UIMenuItem mk2AR = new UIMenuItem("MK2 Assault Rifle : $30,000");
      this.MK2AssaultRifle.AddItem(mk2AR);
      UIMenuItem mk2ARClip1 = new UIMenuItem("Default Clip : $0");
      this.MK2AssaultRifle.AddItem(mk2ARClip1);
      UIMenuItem mk2ARClip2 = new UIMenuItem("Extended Clip: $22,000");
      this.MK2AssaultRifle.AddItem(mk2ARClip2);
      UIMenuItem mk2ARClip3 = new UIMenuItem("Tracer Rounds  : $42,700");
      this.MK2AssaultRifle.AddItem(mk2ARClip3);
      UIMenuItem mk2ARClip4 = new UIMenuItem("Incendiary Rounds  : $49,400");
      this.MK2AssaultRifle.AddItem(mk2ARClip4);
      UIMenuItem mk2ARClip5 = new UIMenuItem("Armor Piercing Rounds : $63,200");
      this.MK2AssaultRifle.AddItem(mk2ARClip5);
      UIMenuItem mk2ARClip6 = new UIMenuItem("Full Metal Jacket Rounds  : $73,000");
      this.MK2AssaultRifle.AddItem(mk2ARClip6);
      UIMenuItem mk2ARClipFlash = new UIMenuItem("Flashlight : $10,500");
      this.MK2AssaultRifle.AddItem(mk2ARClipFlash);
      UIMenuItem mk2ARClipSight1 = new UIMenuItem("Holographic Sight : $19,600");
      this.MK2AssaultRifle.AddItem(mk2ARClipSight1);
      UIMenuItem mk2ARClipSight2 = new UIMenuItem("Small Scope : $23,730");
      this.MK2AssaultRifle.AddItem(mk2ARClipSight2);
      UIMenuItem mk2ARClipSight3 = new UIMenuItem("Large Scope : $33,000");
      this.MK2AssaultRifle.AddItem(mk2ARClipSight3);
      UIMenuItem mk2ARClipGrip = new UIMenuItem("Grip : $14,000");
      this.MK2AssaultRifle.AddItem(mk2ARClipGrip);
      UIMenuItem mk2ARsuppressor = new UIMenuItem("Suppressor : $40,250");
      this.MK2AssaultRifle.AddItem(mk2ARsuppressor);
      UIMenuListItem list10 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2AssaultRifle.AddItem((UIMenuItem) list10);
      UIMenuItem getTint10 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2AssaultRifle.AddItem(getTint10);
      UIMenuItem mk2lmg = new UIMenuItem("MK2 LMG : $95,000");
      this.MK2LMG.AddItem(mk2lmg);
      UIMenuItem mk2lmgClip1 = new UIMenuItem("Default Clip : $0");
      this.MK2LMG.AddItem(mk2lmgClip1);
      UIMenuItem mk2lmgClip2 = new UIMenuItem("Extended Clip : $28,975");
      this.MK2LMG.AddItem(mk2lmgClip2);
      UIMenuItem mk2lmgClip3 = new UIMenuItem("Tracer Rounds : $57,100");
      this.MK2LMG.AddItem(mk2lmgClip3);
      UIMenuItem mk2lmgClip4 = new UIMenuItem("Incendiary Rounds : $64,650");
      this.MK2LMG.AddItem(mk2lmgClip4);
      UIMenuItem mk2lmgClip5 = new UIMenuItem("Armor Piercing Rounds : $82,550");
      this.MK2LMG.AddItem(mk2lmgClip5);
      UIMenuItem mk2lmgClip6 = new UIMenuItem("Full Metal Jacket Rounds  : $94,950");
      this.MK2LMG.AddItem(mk2lmgClip6);
      UIMenuItem mk2lmgGrip = new UIMenuItem("Grip : $20,180");
      this.MK2LMG.AddItem(mk2lmgGrip);
      UIMenuItem mk2lmgSight1 = new UIMenuItem("Holographic Sight : $26,600");
      this.MK2LMG.AddItem(mk2lmgSight1);
      UIMenuItem mk2lmgSight2 = new UIMenuItem("Small Scope : $36,290");
      this.MK2LMG.AddItem(mk2lmgSight2);
      UIMenuItem mk2lmgSight3 = new UIMenuItem("Large Scope : $46,170");
      this.MK2LMG.AddItem(mk2lmgSight3);
      UIMenuItem mk2lmgMuzzle = new UIMenuItem("Flat Muzzle Brake : $40,375");
      this.MK2LMG.AddItem(mk2lmgMuzzle);
      UIMenuItem mk2lmgBarrel = new UIMenuItem("Heavy Barrel : $66,500");
      this.MK2LMG.AddItem(mk2lmgBarrel);
      UIMenuListItem list11 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2LMG.AddItem((UIMenuItem) list11);
      UIMenuItem getTint11 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2LMG.AddItem(getTint11);
      UIMenuItem mk2sniper = new UIMenuItem("MK2 Heavy Sniper : $100,000");
      this.MK2Sniper.AddItem(mk2sniper);
      UIMenuItem mk2sniperClip1 = new UIMenuItem("Default Clip : $0");
      this.MK2Sniper.AddItem(mk2sniperClip1);
      UIMenuItem mk2sniperClip2 = new UIMenuItem("Extended Clip : $35,025");
      this.MK2Sniper.AddItem(mk2sniperClip2);
      UIMenuItem mk2sniperClip3 = new UIMenuItem("Incendiary Rounds : $59,275");
      this.MK2Sniper.AddItem(mk2sniperClip3);
      UIMenuItem mk2sniperClip4 = new UIMenuItem("Armor Piercing Rounds : $76,100");
      this.MK2Sniper.AddItem(mk2sniperClip4);
      UIMenuItem mk2sniperClip5 = new UIMenuItem("Full Metal Jacket Rounds : $88,525");
      this.MK2Sniper.AddItem(mk2sniperClip5);
      UIMenuItem mk2sniperClip6 = new UIMenuItem("Explosive Rounds : $115,450");
      this.MK2Sniper.AddItem(mk2sniperClip6);
      UIMenuItem mk2sniperSight1 = new UIMenuItem("Zoom scope : $20.200");
      this.MK2Sniper.AddItem(mk2sniperSight1);
      UIMenuItem mk2sniperSight2 = new UIMenuItem("Advanced Scope : $32,000");
      this.MK2Sniper.AddItem(mk2sniperSight2);
      UIMenuItem mk2sniperSight3 = new UIMenuItem("Night Vision Scope : $57,400");
      this.MK2Sniper.AddItem(mk2sniperSight3);
      UIMenuItem mk2sniperSight4 = new UIMenuItem("Thermal Scope : $69,000");
      this.MK2Sniper.AddItem(mk2sniperSight4);
      UIMenuItem mk2sniperSupp = new UIMenuItem("Suppressor : $40,250");
      this.MK2Sniper.AddItem(mk2sniperSupp);
      UIMenuItem mk2sniperMuzzle = new UIMenuItem("Bell-End Muzzle Brake : $57,790");
      this.MK2Sniper.AddItem(mk2sniperMuzzle);
      UIMenuItem mk2sniperBarrel = new UIMenuItem("Heavy Barrel : $27,500");
      this.MK2Sniper.AddItem(mk2sniperBarrel);
      UIMenuListItem list12 = new UIMenuListItem("Tint ", items3, 0);
      this.MK2Sniper.AddItem((UIMenuItem) list12);
      UIMenuItem getTint12 = new UIMenuItem("Buy Tint: $10,000");
      this.MK2Sniper.AddItem(getTint12);
      List<object> items4 = new List<object>();
      WeaponHash[] allweaponhashes = (WeaponHash[]) Enum.GetValues(typeof (WeaponHash));
      for (int index = 0; index < allweaponhashes.Length; ++index)
        items4.Add((object) allweaponhashes[index]);
      UIMenuListItem list = new UIMenuListItem("Weapon: ", items4, 0);
      uiMenu3.AddItem((UIMenuItem) list);
      UIMenuItem getWeapon = new UIMenuItem("Buy Weapon : $10000");
      uiMenu3.AddItem(getWeapon);
      UIMenuItem RayGun = new UIMenuItem("Ray Gun : $100,000");
      uiMenu2.AddItem(RayGun);
      UIMenuItem UnholyHellbringer = new UIMenuItem("UnholyHellbringer : $250,000");
      uiMenu2.AddItem(UnholyHellbringer);
      UIMenuItem Widowmaker = new UIMenuItem("Widowmaker : $1,000,000");
      uiMenu2.AddItem(Widowmaker);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != getWeapon)
          return;
        WeaponHash hash = allweaponhashes[list.Index];
        switch (hash)
        {
          case WeaponHash.HeavySniperMk2:
          case WeaponHash.AssaultrifleMk2:
          case WeaponHash.PumpShotgunMk2:
          case WeaponHash.MarksmanRifleMk2:
          case WeaponHash.SMGMk2:
          case WeaponHash.BullpupRifleMk2:
          case WeaponHash.SNSPistolMk2:
          case WeaponHash.SpecialCarbineMk2:
          case WeaponHash.PistolMk2:
          case WeaponHash.RevolverMk2:
          case WeaponHash.CombatMGMk2:
          case WeaponHash.CarbineRifleMk2:
            UI.Notify(this.GetHostName() + " Boss, this is a MKII weapon please perchase it from the MkII page");
            break;
          default:
            Game.Player.Character.Weapons.Give(hash, 9999, true, true);
            Game.Player.Money -= 10000;
            break;
        }
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == RayGun)
        {
          if (Game.Player.Money >= 100000)
          {
            Game.Player.Money -= 100000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 2939590305U, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enough money for this weapon ");
        }
        if (item == UnholyHellbringer)
        {
          if (Game.Player.Money >= 250000)
          {
            Game.Player.Money -= 250000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 1198256469, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enough money for this weapon ");
        }
        if (item != Widowmaker)
          return;
        if (Game.Player.Money >= 1000000)
        {
          Game.Player.Money -= 1000000;
          Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 3056410471U, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " You dont have enough money for this weapon ");
      });
      this.MK2Sniper.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint12)
        {
          int index1 = list12.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) list12.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2sniper)
        {
          if (Game.Player.Money > 100000)
          {
            Game.Player.Money -= 100000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperClip1)
        {
          if (Game.Player.Money > 0)
          {
            Game.Player.Money = Game.Player.Money;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 4196276776U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperClip2)
        {
          if (Game.Player.Money > 35025)
          {
            Game.Player.Money -= 35025;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 752418717);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperClip3)
        {
          if (Game.Player.Money > 59275)
          {
            Game.Player.Money -= 59275;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 247526935);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperClip4)
        {
          if (Game.Player.Money > 76100)
          {
            Game.Player.Money -= 76100;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 4164277972U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperClip5)
        {
          if (Game.Player.Money > 88525)
          {
            Game.Player.Money -= 88525;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 1005144310);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperClip6)
        {
          if (Game.Player.Money > 115450)
          {
            Game.Player.Money -= 115450;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 2313935527U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperSight1)
        {
          if (Game.Player.Money > 20200)
          {
            Game.Player.Money -= 20200;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 2193687427U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperSight2)
        {
          if (Game.Player.Money > 32000)
          {
            Game.Player.Money -= 32000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 3159677559U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperSight3)
        {
          if (Game.Player.Money > 57400)
          {
            Game.Player.Money -= 57400;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 3061846192U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperSight4)
        {
          if (Game.Player.Money > 69000)
          {
            Game.Player.Money -= 69000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 776198721);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperSupp)
        {
          if (Game.Player.Money > 40250)
          {
            Game.Player.Money -= 40250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 2890063729U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2sniperMuzzle)
        {
          if (Game.Player.Money > 57790)
          {
            Game.Player.Money -= 57790;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 1764221345);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2sniperBarrel)
          return;
        if (Game.Player.Money > 27500)
        {
          Game.Player.Money -= 27500;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 2425761975U);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2LMG.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint11)
        {
          int index1 = list11.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) list11.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2lmg)
        {
          if (Game.Player.Money > 95000)
          {
            Game.Player.Money -= 95000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgClip1)
        {
          if (Game.Player.Money > 0)
          {
            Game.Player.Money = Game.Player.Money;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1227564412);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgClip2)
        {
          if (Game.Player.Money > 28975)
          {
            Game.Player.Money -= 28975;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 400507625);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgClip3)
        {
          if (Game.Player.Money > 57100)
          {
            Game.Player.Money -= 57100;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 4133787461U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgClip4)
        {
          if (Game.Player.Money > 64650)
          {
            Game.Player.Money -= 64650;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 3274096058U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgClip5)
        {
          if (Game.Player.Money > 82550)
          {
            Game.Player.Money -= 82550;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 696788003);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgClip6)
        {
          if (Game.Player.Money > 94950)
          {
            Game.Player.Money -= 94950;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1475288264);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgGrip)
        {
          if (Game.Player.Money > 20180)
          {
            Game.Player.Money -= 20180;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 2640679034U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgSight1)
        {
          if (Game.Player.Money > 26600)
          {
            Game.Player.Money -= 26600;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1108334355);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgSight2)
        {
          if (Game.Player.Money > 36290)
          {
            Game.Player.Money -= 36290;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 1060929921);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgSight3)
        {
          if (Game.Player.Money > 46170)
          {
            Game.Player.Money -= 46170;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 3328927042U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2lmgMuzzle)
        {
          if (Game.Player.Money > 40375)
          {
            Game.Player.Money -= 40375;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 3113485012U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2lmgBarrel)
          return;
        if (Game.Player.Money > 66500)
        {
          Game.Player.Money -= 66500;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 3051509595U);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2Carbine.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint9)
        {
          int index1 = list9.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) list9.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2carbine)
        {
          if (Game.Player.Money > 35000)
          {
            Game.Player.Money -= 35000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineClip1)
        {
          if (Game.Player.Money > 0)
          {
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1283078430);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineClip2)
        {
          if (Game.Player.Money > 25925)
          {
            Game.Player.Money -= 25925;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1574296533);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineClip3)
        {
          if (Game.Player.Money > 44700)
          {
            Game.Player.Money -= 44700;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 391640422);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineClip4)
        {
          if (Game.Player.Money > 51600)
          {
            Game.Player.Money -= 51600;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1025884839);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineClip5)
        {
          if (Game.Player.Money > 66000)
          {
            Game.Player.Money -= 66000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 626875735);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineClip6)
        {
          if (Game.Player.Money > 76000)
          {
            Game.Player.Money -= 76000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1141059345);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineFlash)
        {
          if (Game.Player.Money > 10500)
          {
            Game.Player.Money -= 10500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 2076495324);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineGrip)
        {
          if (Game.Player.Money > 14080)
          {
            Game.Player.Money -= 14080;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 2640679034U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineSight1)
        {
          if (Game.Player.Money > 19600)
          {
            Game.Player.Money -= 19600;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 1108334355);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineSight2)
        {
          if (Game.Player.Money > 23730)
          {
            Game.Player.Money -= 23730;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 77277509);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2carbineSight3)
        {
          if (Game.Player.Money > 34020)
          {
            Game.Player.Money -= 34020;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 3328927042U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2carbineSupp)
          return;
        if (Game.Player.Money > 40250)
        {
          Game.Player.Money -= 40250;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 2205435306U);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2SMG.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint8)
        {
          int index1 = list8.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) list8.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2smg)
        {
          if (Game.Player.Money > 25000)
          {
            Game.Player.Money -= 25000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgclip)
        {
          if (Game.Player.Money > 0)
          {
            Game.Player.Money = Game.Player.Money;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1277460590);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgclip1)
        {
          if (Game.Player.Money > 18300)
          {
            Game.Player.Money -= 18300;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 3112393518U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgClip2)
        {
          if (Game.Player.Money > 32850)
          {
            Game.Player.Money -= 32850;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 2146055916);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgClip3)
        {
          if (Game.Player.Money > 34750)
          {
            Game.Player.Money -= 34750;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 3650233061U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgClip4)
        {
          if (Game.Player.Money > 39650)
          {
            Game.Player.Money -= 39650;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 974903034);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgClip5)
        {
          if (Game.Player.Money > 52000)
          {
            Game.Player.Money -= 52000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 190476639);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgsight1)
        {
          if (Game.Player.Money > 15200)
          {
            Game.Player.Money -= 15200;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 2681951826U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgsight2)
        {
          if (Game.Player.Money > 19950)
          {
            Game.Player.Money -= 19950;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 3842157419U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgsight3)
        {
          if (Game.Player.Money > 24100)
          {
            Game.Player.Money -= 24100;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1038927834);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgsupp)
        {
          if (Game.Player.Money > 34500)
          {
            Game.Player.Money -= 34500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1038927834);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2smgmuzzle)
        {
          if (Game.Player.Money > 25500)
          {
            Game.Player.Money -= 25500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 3113485012U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2smgbarrel)
          return;
        if (Game.Player.Money > 22500)
        {
          Game.Player.Money -= 22500;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 3641720545U);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 1000);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2AssaultRifle.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint10)
        {
          int index1 = list10.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) list10.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2AR)
        {
          if (Game.Player.Money > 30000)
          {
            Game.Player.Money -= 30000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClip1)
        {
          if (Game.Player.Money > 0)
          {
            Game.Player.Money = Game.Player.Money;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 2249208895U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClip2)
        {
          if (Game.Player.Money > 22000)
          {
            Game.Player.Money -= 22000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 3509242479U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClip3)
        {
          if (Game.Player.Money > 42700)
          {
            Game.Player.Money -= 42700;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 4012669121U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClip4)
        {
          if (Game.Player.Money > 49400)
          {
            Game.Player.Money -= 49400;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 4218476627U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClip5)
        {
          if (Game.Player.Money > 63200)
          {
            Game.Player.Money -= 63200;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 2816286296U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClip6)
        {
          if (Game.Player.Money > 73000)
          {
            Game.Player.Money -= 73000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 1675665560);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClipFlash)
        {
          if (Game.Player.Money > 10500)
          {
            Game.Player.Money -= 10500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 2076495324);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClipGrip)
        {
          if (Game.Player.Money > 14000)
          {
            Game.Player.Money -= 14000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 2640679034U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClipSight1)
        {
          if (Game.Player.Money > 19600)
          {
            Game.Player.Money -= 19600;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 1108334355);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClipSight2)
        {
          if (Game.Player.Money > 23730)
          {
            Game.Player.Money -= 23730;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 77277509);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ARClipSight3)
        {
          if (Game.Player.Money > 33000)
          {
            Game.Player.Money -= 33000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 3328927042U);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2ARsuppressor)
          return;
        if (Game.Player.Money > 40250)
        {
          Game.Player.Money -= 40250;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 2805810788U);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2Pistol.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint7)
        {
          int index1 = list7.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) list7.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2pistol)
        {
          if (Game.Player.Money > 20000)
          {
            Game.Player.Money -= 20000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolClip)
        {
          if (Game.Player.Money > 0)
          {
            Game.Player.Money = Game.Player.Money;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 2499030370U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolClip1)
        {
          if (Game.Player.Money > 15250)
          {
            Game.Player.Money -= 15250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1591132456);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolClip2)
        {
          if (Game.Player.Money > 28600)
          {
            Game.Player.Money -= 28600;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 634039983);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolClip3)
        {
          if (Game.Player.Money > 34750)
          {
            Game.Player.Money -= 34750;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 733837882);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolClip4)
        {
          if (Game.Player.Money > 39650)
          {
            Game.Player.Money -= 39650;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 2248057097U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolClip5)
        {
          if (Game.Player.Money > 39650)
          {
            Game.Player.Money -= 39650;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1329061674);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolflash)
        {
          if (Game.Player.Money > 7500)
          {
            Game.Player.Money -= 7500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 2396306288U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolSight1)
        {
          if (Game.Player.Money > 16250)
          {
            Game.Player.Money -= 16250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 2396306288U);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2pistolsupp)
        {
          if (Game.Player.Money > 28750)
          {
            Game.Player.Money -= 28750;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1709866683);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2pistolcomp)
          return;
        if (Game.Player.Money > 21250)
        {
          Game.Player.Money -= 21250;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 568543123);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 1000);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2Pumpshotgun.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint1)
        {
          int index1 = list1.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) list1.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2Shotgunclip4)
        {
          if (Game.Player.Money > 145000)
          {
            Game.Player.Money -= 145000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1004815965);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Shotgunclip)
        {
          if (Game.Player.Money > 0)
          {
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) -845938367);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Shotgunclip2)
        {
          if (Game.Player.Money > 96645)
          {
            Game.Player.Money -= 96645;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1315288101);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Shotgunclip3)
        {
          if (Game.Player.Money > 75140)
          {
            Game.Player.Money -= 75140;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) -380098265);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Shotgunclip1)
        {
          if (Game.Player.Money > 65200)
          {
            Game.Player.Money -= 65200;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) -1618338827);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1000);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ShotgunP)
        {
          if (Game.Player.Money > 75000)
          {
            Game.Player.Money -= 75000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Shotgunflashlight)
        {
          if (Game.Player.Money > 10500)
          {
            Game.Player.Money -= 10500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 2076495324);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Shotgunsights)
        {
          if (Game.Player.Money > 29320)
          {
            Game.Player.Money -= 29320;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1108334355);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Shotgunsights2)
        {
          if (Game.Player.Money > 39920)
          {
            Game.Player.Money -= 39920;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 77277509);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Shotgunsights3)
        {
          if (Game.Player.Money > 50785)
          {
            Game.Player.Money -= 50785;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1060929921);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2ShotgunSuppressor)
        {
          if (Game.Player.Money > 45860)
          {
            Game.Player.Money -= 45860;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) -1404903567);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2Shotgunmuzzle)
          return;
        if (Game.Player.Money > 37650)
        {
          Game.Player.Money -= 37650;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 1602080333);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2SNSPistol.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint2)
        {
          int index1 = list2.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) list2.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2Snspistol)
        {
          if (Game.Player.Money > 45000)
          {
            Game.Player.Money -= 45000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolclipn)
        {
          if (Game.Player.Money > 8000)
          {
            Game.Player.Money -= 8000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 21392614);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolclipe)
        {
          if (Game.Player.Money > 18300)
          {
            Game.Player.Money -= 18300;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) -829683854);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolclip1)
        {
          if (Game.Player.Money > 34320)
          {
            Game.Player.Money -= 34320;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) -1876057490);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 9999);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolclip2)
        {
          if (Game.Player.Money > 41700)
          {
            Game.Player.Money -= 41700;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) -424845447);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 9999);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolclip3)
        {
          if (Game.Player.Money > 47580)
          {
            Game.Player.Money -= 47580;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) -1928301566);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 9999);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolclip4)
        {
          if (Game.Player.Money > 62400)
          {
            Game.Player.Money -= 62400;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) -1055790298);
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 9999);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolcomp)
        {
          if (Game.Player.Money > 21250)
          {
            Game.Player.Money -= 21250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) -1434287169);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolflash)
        {
          if (Game.Player.Money > 7500)
          {
            Game.Player.Money -= 7500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 1246324211);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Snspistolscope1)
        {
          if (Game.Player.Money > 16250)
          {
            Game.Player.Money -= 16250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 1205768792);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2Snspistolsuppressor)
          return;
        if (Game.Player.Money > 28750)
        {
          Game.Player.Money -= 28750;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 1709866683);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2Revolver.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint3)
        {
          int index1 = list3.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) list3.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2Revolver)
        {
          if (Game.Player.Money > 85000)
          {
            Game.Player.Money -= 85000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Revolverclip)
        {
          if (Game.Player.Money > 0)
          {
            Game.Player.Money = Game.Player.Money;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) -1172055874);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Revolverclip1)
        {
          if (Game.Player.Money > 31460)
          {
            Game.Player.Money -= 31460;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) -958864266);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Revolverclip2)
        {
          if (Game.Player.Money > 38225)
          {
            Game.Player.Money -= 38225;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 15712037);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Revolverclip3)
        {
          if (Game.Player.Money > 43615)
          {
            Game.Player.Money -= 43615;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 284438159);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Revolverclip4)
        {
          if (Game.Player.Money > 57200)
          {
            Game.Player.Money -= 57200;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 231258687);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Revolversights)
        {
          if (Game.Player.Money > 16250)
          {
            Game.Player.Money -= 16250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 1108334355);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Revolversights1)
        {
          if (Game.Player.Money > 25450)
          {
            Game.Player.Money -= 25450;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 77277509);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Revolverflashlight)
        {
          if (Game.Player.Money > 7500)
          {
            Game.Player.Money -= 7500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 899381934);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2RevolverComp)
          return;
        if (Game.Player.Money > 21250)
        {
          Game.Player.Money -= 21250;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 654802123);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.Mk2SpecialCarbine.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint4)
        {
          int index1 = list4.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) list4.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2SCarbine)
        {
          if (Game.Player.Money > 65000)
          {
            Game.Player.Money -= 65000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbineclip)
        {
          if (Game.Player.Money > 5000)
          {
            Game.Player.Money -= 5000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 382112385);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbineclip1)
        {
          if (Game.Player.Money > 26450)
          {
            Game.Player.Money -= 26450;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) -568352468);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbineclip2)
        {
          if (Game.Player.Money > 61465)
          {
            Game.Player.Money -= 61465;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 1000);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) -2023373174);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbineclip3)
        {
          if (Game.Player.Money > 70950)
          {
            Game.Player.Money -= 70950;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 1000);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) -570355066);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbineclip4)
        {
          if (Game.Player.Money > 90750)
          {
            Game.Player.Money -= 90750;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 1000);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 1362433589);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbineclip5)
        {
          if (Game.Player.Money > 104775)
          {
            Game.Player.Money -= 104775;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 1000);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 1346235024);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbineflash)
        {
          if (Game.Player.Money > 10500)
          {
            Game.Player.Money -= 10500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 2076495324);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbinesight1)
        {
          if (Game.Player.Money > 19600)
          {
            Game.Player.Money -= 19600;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 1108334355);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbinesight2)
        {
          if (Game.Player.Money > 23730)
          {
            Game.Player.Money -= 23730;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 77277509);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbinesight3)
        {
          if (Game.Player.Money > 34020)
          {
            Game.Player.Money -= 34020;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) -966040254);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbinesupressor)
        {
          if (Game.Player.Money > 40250)
          {
            Game.Player.Money -= 40250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) -1489156508);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2SCarbinemuzzle)
        {
          if (Game.Player.Money > 29750)
          {
            Game.Player.Money -= 29750;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) -1181482284);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2SCarbinegrip)
          return;
        if (Game.Player.Money > 14080)
        {
          Game.Player.Money -= 14080;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) -1654288262);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2Bullpup.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint5)
        {
          int index1 = list5.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) list5.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2Bullpup)
        {
          if (Game.Player.Money > 60000)
          {
            Game.Player.Money -= 60000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupclip1)
        {
          if (Game.Player.Money > 5000)
          {
            Game.Player.Money -= 5000;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 25766362);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupclip2)
        {
          if (Game.Player.Money > 22100)
          {
            Game.Player.Money -= 22100;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) -273676760);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupclip3)
        {
          if (Game.Player.Money > 44350)
          {
            Game.Player.Money -= 44350;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) -2111807319);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupclip4)
        {
          if (Game.Player.Money > 52100)
          {
            Game.Player.Money -= 52100;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) -1449330342);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupclip5)
        {
          if (Game.Player.Money > 87320)
          {
            Game.Player.Money -= 87320;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) -89655827);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupclip6)
        {
          if (Game.Player.Money > 77490)
          {
            Game.Player.Money -= 77490;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 1130501904);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupflash)
        {
          if (Game.Player.Money > 10500)
          {
            Game.Player.Money -= 10500;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 2076495324);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupsight1)
        {
          if (Game.Player.Money > 19600)
          {
            Game.Player.Money -= 19600;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 1108334355);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupsight2)
        {
          if (Game.Player.Money > 23730)
          {
            Game.Player.Money -= 23730;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) -944910075);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2Bullpupsight3)
        {
          if (Game.Player.Money > 34020)
          {
            Game.Player.Money -= 34020;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 1060929921);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2BullpupBarrel)
        {
          if (Game.Player.Money > 49000)
          {
            Game.Player.Money -= 49000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 1704640795);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2BullpupGrip)
        {
          if (Game.Player.Money > 14080)
          {
            Game.Player.Money -= 14080;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) -1654288262);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2BullpupSuppressor)
        {
          if (Game.Player.Money > 40250)
          {
            Game.Player.Money -= 40250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) -2089531990);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2Bullpupmuzzle)
          return;
        if (Game.Player.Money > 29750)
        {
          Game.Player.Money -= 29750;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) -1181482284);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
      this.MK2MarksmanRifle.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == getTint6)
        {
          int index1 = list6.Index;
          Function.Call(Hash._0x50969B9B89ED5738, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) list6.Index);
          Game.Player.Money -= 10000;
        }
        if (item == mk2marksman)
        {
          if (Game.Player.Money > 60000)
          {
            Game.Player.Money -= 60000;
            Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanclip1)
        {
          if (Game.Player.Money > 5000)
          {
            Game.Player.Money -= 5000;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -1797182002);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanclip3)
        {
          if (Game.Player.Money > 49775)
          {
            Game.Player.Money -= 49775;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 1000);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -679861550);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanclip4)
        {
          if (Game.Player.Money > 57295)
          {
            Game.Player.Money -= 57295;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 1000);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 1842849902);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanclip5)
        {
          if (Game.Player.Money > 73560)
          {
            Game.Player.Money -= 73560;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 1000);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -193998727);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanclip6)
        {
          if (Game.Player.Money > 85570)
          {
            Game.Player.Money -= 85570;
            Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 1000);
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -515203373);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanclip2)
        {
          if (Game.Player.Money > 26850)
          {
            Game.Player.Money -= 26850;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -422587990);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanflash)
        {
          if (Game.Player.Money > 11250)
          {
            Game.Player.Money -= 11250;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 2076495324);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmansight1)
        {
          if (Game.Player.Money > 11485)
          {
            Game.Player.Money -= 11485;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 1108334355);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmansight2)
        {
          if (Game.Player.Money > 17870)
          {
            Game.Player.Money -= 17870;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -966040254);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmansight3)
        {
          if (Game.Player.Money > 27150)
          {
            Game.Player.Money -= 27150;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 1528590652);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanGrip)
        {
          if (Game.Player.Money > 14080)
          {
            Game.Player.Money -= 14080;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -1654288262);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item == mk2marksmanSuppressor)
        {
          if (Game.Player.Money > 60375)
          {
            Game.Player.Money -= 60375;
            Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -2089531990);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
        }
        if (item != mk2marksmanmuzzle)
          return;
        if (Game.Player.Money > 44620)
        {
          Game.Player.Money -= 44620;
          Function.Call(Hash._0xD966D51AA5B28BB9, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) -1181482284);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enough money to purchase this Weapon!");
      });
    }

    public void SetupInterior()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.InteiorOptions, "Interior Presets");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem A = new UIMenuItem("Basic");
      uiMenu.AddItem(A);
      UIMenuItem B = new UIMenuItem("Urban");
      uiMenu.AddItem(B);
      UIMenuItem C = new UIMenuItem("Branded");
      uiMenu.AddItem(C);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == A)
        {
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "urban_style_set");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "branded_style_set");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "car_floor_hatch");
          Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 252673);
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
          int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 994.5925, (InputArgument) -3002.594, (InputArgument) -39.64699);
          this.Style = "basic_style_set";
          this.Config2.SetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
          this.Config2.Save();
          this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          this.Style = this.Config2.GetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) this.Style);
          Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
        }
        if (item == B)
        {
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "urban_style_set");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "branded_style_set");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "car_floor_hatch");
          Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 252673);
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
          int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 994.5925, (InputArgument) -3002.594, (InputArgument) -39.64699);
          this.Style = "urban_style_set";
          this.Config2.SetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
          this.Config2.Save();
          this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          this.Style = this.Config2.GetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) this.Style);
          Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
        }
        if (item != C)
          return;
        Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "urban_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "branded_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "car_floor_hatch");
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
        int num1 = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 994.5925, (InputArgument) -3002.594, (InputArgument) -39.64699);
        this.Style = "branded_style_set";
        this.Config2.SetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
        this.Config2.Save();
        this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        this.Style = this.Config2.GetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.Style);
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num1);
      });
    }

    public void BuyCar()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.BuyCar1, "Special Vehicles");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Ruiner2000Car = new UIMenuItem("Ruiner 2000 : $4,320,000");
      uiMenu.AddItem(Ruiner2000Car);
      UIMenuItem RampBuggyCar = new UIMenuItem("Ramp Buggy: $2,400,000");
      uiMenu.AddItem(RampBuggyCar);
      UIMenuItem ABoxvilleCar = new UIMenuItem("Armoured Boxville: $2,200,000");
      uiMenu.AddItem(ABoxvilleCar);
      UIMenuItem TechnicalAquaCar = new UIMenuItem("Technical Aqua: $1,120,000");
      uiMenu.AddItem(TechnicalAquaCar);
      UIMenuItem PhantomWCar = new UIMenuItem("Phantom Wedge: $1,920,000");
      uiMenu.AddItem(PhantomWCar);
      UIMenuItem RVolticCar = new UIMenuItem("Rocket Voltic: $2,880,000");
      uiMenu.AddItem(RVolticCar);
      UIMenuItem BlazerAquaCar = new UIMenuItem("Blazer Aqua: $1,320,000 ");
      uiMenu.AddItem(BlazerAquaCar);
      UIMenuItem WastlanderCar = new UIMenuItem("Wastelander: $495,000 ");
      uiMenu.AddItem(WastlanderCar);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Ruiner2000Car)
        {
          this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          if (this.Ruiner2000Bought == 0)
          {
            if (Game.Player.Money >= 4320000)
            {
              Game.Player.Money -= 4320000;
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
              this.Ruiner2000Bought = 1;
              this.Config2.SetValue<int>("Setup", "Ruiner2000Bought", this.Ruiner2000Bought);
              this.Config2.Save();
              UI.Notify(this.GetHostName() + " Your new special vehicle will be delivered next time you enter the warehouse");
            }
            else
              UI.Notify(this.GetHostName() + " You do not have enought money to purchase this vehicle");
          }
          else
            UI.Notify(this.GetHostName() + " You allready own this special vehicle");
        }
        if (item == RampBuggyCar)
        {
          this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          if (this.RampbuggyBought == 0)
          {
            if (Game.Player.Money >= 2400000)
            {
              Game.Player.Money -= 2400000;
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
              this.RampbuggyBought = 1;
              this.Config2.SetValue<int>("Setup", "RampbuggyBought", this.RampbuggyBought);
              this.Config2.Save();
              UI.Notify(this.GetHostName() + " Your new special vehicle will be delivered next time you enter the warehouse");
            }
            else
              UI.Notify(this.GetHostName() + " You do not have enought money to purchase this vehicle");
          }
          else
            UI.Notify(this.GetHostName() + " You allready own this special vehicle");
        }
        if (item == ABoxvilleCar)
        {
          this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          if (this.ABoxvilleBought == 0)
          {
            if (Game.Player.Money >= 2200000)
            {
              Game.Player.Money -= 2200000;
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
              this.ABoxvilleBought = 1;
              this.Config2.SetValue<int>("VEHICLEWAREHOUSES", "ABoxvilleBought", this.ABoxvilleBought);
              this.Config2.Save();
              UI.Notify(this.GetHostName() + " Your new special vehicle will be delivered next time you enter the warehouse");
            }
            else
              UI.Notify(this.GetHostName() + " You do not have enought money to purchase this vehicle");
          }
          else
            UI.Notify(this.GetHostName() + " You allready own this special vehicle");
        }
        if (item == TechnicalAquaCar)
        {
          this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          if (this.TechnicalAquaBought == 0)
          {
            if (Game.Player.Money >= 1200000)
            {
              Game.Player.Money -= 1200000;
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
              this.TechnicalAquaBought = 1;
              this.Config2.SetValue<int>("VEHICLEWAREHOUSES", "TechnicalAquaBought", this.TechnicalAquaBought);
              this.Config2.Save();
              UI.Notify(this.GetHostName() + " Your new special vehicle will be delivered next time you enter the warehouse");
            }
            else
              UI.Notify(this.GetHostName() + " You do not have enought money to purchase this vehicle");
          }
          else
            UI.Notify(this.GetHostName() + " You allready own this special vehicle");
        }
        if (item == PhantomWCar)
        {
          if (this.PhantomWBought == 0)
          {
            if (Game.Player.Money >= 1920000)
            {
              Game.Player.Money -= 1920000;
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
              this.PhantomWBought = 1;
              this.Config2.SetValue<int>("VEHICLEWAREHOUSES", "PhantomWBought", this.PhantomWBought);
              this.Config2.Save();
              UI.Notify(this.GetHostName() + " Your new special vehicle will be delivered next time you enter the warehouse");
            }
            else
              UI.Notify(this.GetHostName() + " You do not have enought money to purchase this vehicle");
          }
          else
            UI.Notify(this.GetHostName() + " You allready own this special vehicle");
        }
        if (item == RVolticCar)
        {
          if (this.RvolticBought == 0)
          {
            if (Game.Player.Money >= 2880000)
            {
              Game.Player.Money -= 2880000;
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
              this.RvolticBought = 1;
              this.Config2.SetValue<int>("VEHICLEWAREHOUSES", "RvolticBought", this.RvolticBought);
              this.Config2.Save();
              UI.Notify(this.GetHostName() + " Your new special vehicle will be delivered next time you enter the warehouse");
            }
            else
              UI.Notify(this.GetHostName() + " You do not have enought money to purchase this vehicle");
          }
          else
            UI.Notify(this.GetHostName() + " You allready own this special vehicle");
        }
        if (item == BlazerAquaCar)
        {
          if (this.BlazerAquaBought == 0)
          {
            if (Game.Player.Money >= 1320000)
            {
              Game.Player.Money -= 1320000;
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
              this.BlazerAquaBought = 1;
              this.Config2.SetValue<int>("VEHICLEWAREHOUSES", "BlazerAquaBought", this.BlazerAquaBought);
              this.Config2.Save();
              UI.Notify(this.GetHostName() + " Your new special vehicle will be delivered next time you enter the warehouse");
            }
            else
              UI.Notify(this.GetHostName() + " You do not have enought money to purchase this vehicle");
          }
          else
            UI.Notify(this.GetHostName() + " You allready own this special vehicle");
        }
        if (item != WastlanderCar)
          return;
        if (this.WastelanderBought == 0)
        {
          if (Game.Player.Money >= 495000)
          {
            Game.Player.Money -= 495000;
            this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
            this.WastelanderBought = 1;
            this.Config2.SetValue<int>("VEHICLEWAREHOUSES", "WastelanderBought", this.WastelanderBought);
            this.Config2.Save();
            UI.Notify(this.GetHostName() + " Your new special vehicle will be delivered next time you enter the warehouse");
          }
          else
            UI.Notify(this.GetHostName() + " You do not have enought money to purchase this vehicle");
        }
        else
          UI.Notify(this.GetHostName() + " You allready own this special vehicle");
      });
    }

    public void DeleteCarinSlot(string Slot, Vehicle V)
    {
      this.SC.LoadIniFile(this.path + "GarageA//" + Slot + ".ini");
      if (this.SC.VehicleName != "null")
      {
        if (V.DisplayName == "ZTYPE")
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        if (V.ClassType == VehicleClass.Coupes)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.Military)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.Super)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.SUVs)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.OffRoad)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.Sports)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.SportsClassics)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.Sedans)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.Muscle)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else if (V.ClassType == VehicleClass.Motorcycles)
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        else
        {
          System.Random random = new System.Random();
          Game.Player.Money += (int) this.GetVehicleValue(V.DisplayName, 20);
        }
        UI.Notify(this.GetHostName() + " Vehicle Sold");
      }
      if (this.SC.VehicleName == "null")
        UI.Notify(this.GetHostName() + " There is no Vehicle in " + Slot);
      this.SC.SaveName();
      this.VehicleToDeliver = (Vehicle) null;
      V.Delete();
    }

    public void DeleteCarinSlot2(string Slot, Vehicle V)
    {
      this.SC.LoadIniFile(this.path + "GarageA//" + Slot + ".ini");
      int num1 = 0;
      if (this.SC.VehicleName != "null")
        num1 = (int) this.GetVehicleValue(V.DisplayName, 10);
      if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
        UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
      if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
        UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
      if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
        UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
      int num2 = 0;
      if (V.GetMod(VehicleMod.Livery) >= 1)
        num2 += 10000;
      if (V.GetMod(VehicleMod.Engine) > 0)
      {
        if (V.GetMod(VehicleMod.Engine) == 1)
          num2 += 5000;
        if (V.GetMod(VehicleMod.Engine) == 2)
          num2 += 10000;
        if (V.GetMod(VehicleMod.Engine) == 3)
          num2 += 15000;
      }
      if (V.GetMod(VehicleMod.Transmission) > 0)
      {
        if (V.GetMod(VehicleMod.Transmission) == 1)
          num2 += 5000;
        if (V.GetMod(VehicleMod.Transmission) == 2)
          num2 += 10000;
        if (V.GetMod(VehicleMod.Transmission) == 3)
          num2 += 15000;
      }
      if (V.GetMod(VehicleMod.Armor) > 0)
      {
        if (V.GetMod(VehicleMod.Armor) == 1)
          num2 += 5000;
        if (V.GetMod(VehicleMod.Armor) == 2)
          num2 += 10000;
        if (V.GetMod(VehicleMod.Armor) == 3)
          num2 += 15000;
      }
      if (V.GetMod(VehicleMod.Brakes) > 0)
      {
        if (V.GetMod(VehicleMod.Brakes) == 1)
          num2 += 5000;
        if (V.GetMod(VehicleMod.Brakes) == 2)
          num2 += 10000;
        if (V.GetMod(VehicleMod.Brakes) == 3)
          num2 += 15500;
      }
      if (V.GetMod(VehicleMod.Roof) == 1 || V.GetMod(VehicleMod.Roof) == -1)
        num2 += 35000;
      float num3 = (float) (((double) this.VehicleToDeliver.Health + (double) this.VehicleToDeliver.BodyHealth) / 2000.0);
      Game.Player.Money += num2;
      Game.Player.Money += (int) ((double) num1 * (double) num3);
      int num4 = 0;
      this.SC.SaveName();
      this.DeliveringVehicle = false;
      this.VehicleToDeliver = (Vehicle) null;
      MissionScreen missionScreen = new MissionScreen();
      ++this.SS_VehiclesExportedSuccess;
      this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedSuccess", this.SS_VehiclesExportedSuccess);
      this.Config.Save();
      int Payout = (int) ((double) num1 * (double) num3);
      int Pay2 = num4;
      double num5 = (double) num3;
      missionScreen.SetPass2("Vehicle Warehouse : Sell vehicle", Payout, Pay2, (float) num5, "");
      Script.Wait(5000);
      Game.FadeScreenOut(2500);
      Script.Wait(2500);
      V.Delete();
      this.SupplyMissionOn = false;
      foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
      {
        if ((Entity) supplyMissionVehicle != (Entity) null)
          supplyMissionVehicle.Delete();
      }
      if (this.SupplyMissionVehicles.Count > 0)
        this.SupplyMissionVehicles.Clear();
      foreach (Prop supplyMissionProp in this.SupplyMissionProps)
      {
        if ((Entity) supplyMissionProp != (Entity) null)
          supplyMissionProp.Delete();
      }
      if (this.SupplyMissionProps.Count > 0)
        this.SupplyMissionProps.Clear();
      foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
      {
        if (supplyMissionBlip != (Blip) null)
          supplyMissionBlip.Remove();
      }
      if (this.SupplyMissionBlips.Count > 0)
        this.SupplyMissionBlips.Clear();
      foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
      {
        if ((Entity) supplyMissionPed != (Entity) null)
          supplyMissionPed.Delete();
      }
      if (this.SupplyMissionPeds.Count > 0)
        this.SupplyMissionPeds.Clear();
      foreach (Vehicle asellMissionVehicle in this.SourceASellMissionVehicles)
      {
        if ((Entity) asellMissionVehicle != (Entity) null)
          asellMissionVehicle.Delete();
      }
      if (this.SourceASellMissionVehicles.Count > 0)
        this.SourceASellMissionVehicles.Clear();
      foreach (Prop asellMissionProp in this.SourceASellMissionProps)
      {
        if ((Entity) asellMissionProp != (Entity) null)
          asellMissionProp.Delete();
      }
      if (this.SourceASellMissionProps.Count > 0)
        this.SourceASellMissionProps.Clear();
      foreach (Blip asellMissionBlip in this.SourceASellMissionBlips)
      {
        if (asellMissionBlip != (Blip) null)
          asellMissionBlip.Remove();
      }
      if (this.SourceASellMissionBlips.Count > 0)
        this.SourceASellMissionBlips.Clear();
      foreach (Ped sourceAsellMissionPed in this.SourceASellMissionPeds)
      {
        if ((Entity) sourceAsellMissionPed != (Entity) null)
          sourceAsellMissionPed.Delete();
      }
      if (this.SourceASellMissionPeds.Count > 0)
        this.SourceASellMissionPeds.Clear();
      Script.Wait(2500);
      Game.FadeScreenIn(500);
    }

    public GTA.Model RequestModel(string Name)
    {
      GTA.Model model = new GTA.Model(Name);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        return model;
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public GTA.Model RequestModel(VehicleHash Name)
    {
      GTA.Model model = new GTA.Model(Name);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        return model;
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public GTA.Model RequestModel(PedHash Name)
    {
      GTA.Model model = new GTA.Model(Name);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        return model;
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public bool GetIndex(int Check, int _1, int _2, int _3)
    {
      bool flag = false;
      return Check == _1 || Check == _2 || Check == _3 || flag;
    }

    public void RemoveCar()
    {
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1");
      Slots.Add((object) "Slot2");
      Slots.Add((object) "Slot3");
      Slots.Add((object) "Slot4");
      Slots.Add((object) "Slot5");
      Slots.Add((object) "Slot6");
      Slots.Add((object) "Slot7");
      Slots.Add((object) "Slot8");
      Slots.Add((object) "Slot9");
      Slots.Add((object) "Slot10");
      Slots.Add((object) "Slot11");
      Slots.Add((object) "Slot12");
      Slots.Add((object) "Slot13");
      Slots.Add((object) "Slot14");
      Slots.Add((object) "Slot15");
      Slots.Add((object) "Slot16");
      Slots.Add((object) "Slot17");
      Slots.Add((object) "Slot18");
      Slots.Add((object) "Slot19");
      Slots.Add((object) "Slot20");
      Slots.Add((object) "Slot21");
      Slots.Add((object) "Slot22");
      Slots.Add((object) "Slot23");
      Slots.Add((object) "Slot24");
      Slots.Add((object) "Slot25");
      Slots.Add((object) "Slot26");
      Slots.Add((object) "Slot27");
      Slots.Add((object) "Slot28");
      Slots.Add((object) "Slot29");
      Slots.Add((object) "Slot30");
      Slots.Add((object) "Slot31");
      Slots.Add((object) "Slot32");
      Slots.Add((object) "Slot33");
      Slots.Add((object) "Slot34");
      Slots.Add((object) "Slot35");
      Slots.Add((object) "Slot36");
      Slots.Add((object) "Slot37");
      Slots.Add((object) "Slot38");
      Slots.Add((object) "Slot39");
      Slots.Add((object) "Slot40");
      List<object> items = new List<object>();
      items.Add((object) "No Slot Selected");
      items.Add((object) "Slot1");
      items.Add((object) "Slot2");
      items.Add((object) "Slot3");
      items.Add((object) "Slot4");
      items.Add((object) "Slot5");
      items.Add((object) "Slot6");
      items.Add((object) "Slot7");
      items.Add((object) "Slot8");
      items.Add((object) "Slot9");
      items.Add((object) "Slot10");
      items.Add((object) "Slot11");
      items.Add((object) "Slot12");
      items.Add((object) "Slot13");
      items.Add((object) "Slot14");
      items.Add((object) "Slot15");
      items.Add((object) "Slot16");
      items.Add((object) "Slot17");
      items.Add((object) "Slot18");
      items.Add((object) "Slot19");
      items.Add((object) "Slot20");
      items.Add((object) "Slot21");
      items.Add((object) "Slot22");
      items.Add((object) "Slot23");
      items.Add((object) "Slot24");
      items.Add((object) "Slot25");
      items.Add((object) "Slot26");
      items.Add((object) "Slot27");
      items.Add((object) "Slot28");
      items.Add((object) "Slot29");
      items.Add((object) "Slot30");
      items.Add((object) "Slot31");
      items.Add((object) "Slot32");
      items.Add((object) "Slot33");
      items.Add((object) "Slot34");
      items.Add((object) "Slot35");
      items.Add((object) "Slot36");
      items.Add((object) "Slot37");
      items.Add((object) "Slot38");
      items.Add((object) "Slot39");
      items.Add((object) "Slot40");
      string VH1 = "";
      string VH2 = "";
      string VH3 = "";
      string VH4 = "";
      string VH5 = "";
      string VH6 = "";
      string VH7 = "";
      string VH8 = "";
      string VH9 = "";
      string VH10 = "";
      string VH11 = "";
      string VH12 = "";
      int CarsInColl = 0;
      int CarsCollected = 0;
      int Value = 0;
      List<object> Coll = new List<object>();
      Coll.Add((object) "1");
      Coll.Add((object) "2");
      Coll.Add((object) "3");
      Coll.Add((object) "4");
      Coll.Add((object) "5");
      Coll.Add((object) "6");
      Coll.Add((object) "7");
      Coll.Add((object) "8");
      Coll.Add((object) "9");
      Coll.Add((object) "10");
      Coll.Add((object) "11");
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Sell a Collection");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem C = new UIMenuListItem("Collection  : ", Coll, 0);
      uiMenu1.AddItem((UIMenuItem) C);
      UIMenuItem CName = new UIMenuItem("Collection : <Unknown>");
      uiMenu1.AddItem(CName);
      UIMenuItem EstValue = new UIMenuItem("Est Value : <Unknown>");
      uiMenu1.AddItem(EstValue);
      UIMenuItem V1 = new UIMenuItem("Vehicle 1 :  <Unknown>");
      uiMenu1.AddItem(V1);
      UIMenuItem V2 = new UIMenuItem("Vehicle 2 :  <Unknown>");
      uiMenu1.AddItem(V2);
      UIMenuItem V3 = new UIMenuItem("Vehicle 3 :  <Unknown>");
      uiMenu1.AddItem(V3);
      UIMenuItem V4 = new UIMenuItem("Vehicle 4 :  <Unknown>");
      uiMenu1.AddItem(V4);
      UIMenuItem V5 = new UIMenuItem("Vehicle 5 :  <Unknown>");
      uiMenu1.AddItem(V5);
      UIMenuItem V6 = new UIMenuItem("Vehicle 6 :  <Unknown>");
      uiMenu1.AddItem(V6);
      UIMenuItem V7 = new UIMenuItem("Vehicle 7 :  <Unknown>");
      uiMenu1.AddItem(V7);
      UIMenuItem V8 = new UIMenuItem("Vehicle 8 :  <Unknown>");
      uiMenu1.AddItem(V8);
      UIMenuItem V9 = new UIMenuItem("Vehicle 9 :  <Unknown>");
      uiMenu1.AddItem(V9);
      UIMenuItem V10 = new UIMenuItem("Vehicle 10 :  <Unknown>");
      uiMenu1.AddItem(V10);
      UIMenuItem V11 = new UIMenuItem("Vehicle 11 :  <Unknown>");
      uiMenu1.AddItem(V11);
      UIMenuItem V12 = new UIMenuItem("Vehicle 11 :  <Unknown>");
      uiMenu1.AddItem(V12);
      UIMenuItem SellC = new UIMenuItem("Sell Collection");
      uiMenu1.AddItem(SellC);
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != C)
          return;
        VH1 = "";
        VH2 = "";
        VH3 = "";
        VH4 = "";
        VH5 = "";
        VH6 = "";
        VH7 = "";
        VH8 = "";
        VH9 = "";
        VH10 = "";
        VH11 = "";
        VH12 = "";
        CarsInColl = 0;
        CarsCollected = 0;
        Value = 0;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target1 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p1 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__0.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__0, Coll[C.Index], "1");
        if (target1((CallSite) p1, obj1))
        {
          CarsInColl = 0;
          CarsInColl = 12;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "SABREGT2";
          VH2 = "FACTION2";
          VH3 = "FACTION3";
          VH4 = "BUCCANEER2";
          VH5 = "CHINO2";
          VH6 = "VOODOO";
          VH7 = "SLAMVAN3";
          VH8 = "PRIMO2";
          VH9 = "TORNADO5";
          VH10 = "VIRGO2";
          VH11 = "MOONBEAM2";
          VH12 = "MINIVAN2";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 4 ? "Collection: <Unknown>" : "Collection : Custom Classics";
          if (CarsCollected > 6)
          {
            EstValue.Text = "Est Value : $" + 12000000.ToString("N");
            Value = 12000000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target2 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p3 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__2.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__2, Coll[C.Index], "2");
        if (target2((CallSite) p3, obj2))
        {
          CarsInColl = 0;
          CarsInColl = 6;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "ZTYPE";
          VH2 = "JB700";
          VH3 = "STINGER";
          VH4 = "MONROE";
          VH5 = "CHEETAH";
          VH6 = "ENTITYXF";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 2 ? "Collection: <Unknown>" : "Collection : Original 6 Hiest Cars";
          if (CarsCollected > 3)
          {
            EstValue.Text = "Est Value : $" + 24000000.ToString("N");
            Value = 24000000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__5.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p5 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__5;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__4.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__4, Coll[C.Index], "3");
        if (target3((CallSite) p5, obj3))
        {
          CarsInColl = 0;
          CarsInColl = 6;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "NERO";
          VH2 = "RE7B";
          VH3 = "BANSHEE2";
          VH4 = "SULTANRS";
          VH5 = "VAGNER";
          VH6 = "COMET5";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 2 ? "Collection: <Unknown>" : "Collection : As Fast As They Come";
          if (CarsCollected > 3)
          {
            EstValue.Text = "Est Value : $" + 18000000.ToString("N");
            Value = 18000000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target4 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__7.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p7 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__7;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__6.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__6, Coll[C.Index], "4");
        if (target4((CallSite) p7, obj4))
        {
          CarsInColl = 0;
          CarsInColl = 6;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "KURUMA2";
          VH2 = "INSURGENT2";
          VH3 = "NIGHTSHARK";
          VH4 = "BALLER6";
          VH5 = "XLS2";
          VH6 = "DUKES2";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 2 ? "Collection: <Unknown>" : "Collection : Armoured Like A Beast";
          if (CarsCollected > 3)
          {
            EstValue.Text = "Est Value : $" + 7000000.ToString("N");
            Value = 7000000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__9 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target5 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__9.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p9 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__9;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj5 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__8.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__8, Coll[C.Index], "5");
        if (target5((CallSite) p9, obj5))
        {
          CarsInColl = 0;
          CarsInColl = 4;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "TAMPA3";
          VH2 = "DUNE3";
          VH3 = "TECHNICAL";
          VH4 = "INSURGENT";
          VH5 = "";
          VH6 = "";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 1 ? "Collection: <Unknown>" : "Collection : Ready for War";
          if (CarsCollected > 2)
          {
            EstValue.Text = "Est Value : $" + 5000000.ToString("N");
            Value = 5000000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__11 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target6 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__11.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p11 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__11;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj6 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__10.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__10, Coll[C.Index], "6");
        if (target6((CallSite) p11, obj6))
        {
          CarsInColl = 0;
          CarsInColl = 4;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "JB700";
          VH2 = "XA21";
          VH3 = "STROMBERG";
          VH4 = "SEVEN70";
          VH5 = "";
          VH6 = "";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 1 ? "Collection: <Unknown>" : "Collection : 007";
          if (CarsCollected > 2)
          {
            EstValue.Text = "Est Value : $" + 6500000.ToString("N");
            Value = 6500000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target7 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__13.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p13 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__13;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__12 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj7 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__12.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__12, Coll[C.Index], "7");
        if (target7((CallSite) p13, obj7))
        {
          CarsInColl = 0;
          CarsInColl = 4;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "GB200";
          VH2 = "OMNIS";
          VH3 = "TROPOS";
          VH4 = "FLASHGT";
          VH5 = "";
          VH6 = "";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 1 ? "Collection: <Unknown>" : "Collection : Rally Stage";
          if (CarsCollected > 3)
          {
            EstValue.Text = "Est Value : $" + 3500000.ToString("N");
            Value = 3500000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__15 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target8 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__15.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p15 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__15;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj8 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__14.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__14, Coll[C.Index], "8");
        if (target8((CallSite) p15, obj8))
        {
          CarsInColl = 0;
          CarsInColl = 4;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "TORNADO6";
          VH2 = "BTYPE2";
          VH3 = "HUSTLER";
          VH4 = "HOTKNIFE";
          VH5 = "";
          VH6 = "";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 1 ? "Collection: <Unknown>" : "Collection : Rods";
          if (CarsCollected > 3)
          {
            EstValue.Text = "Est Value : $" + 4250000.ToString("N");
            Value = 4250000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target9 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__17.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p17 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__17;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__16 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj9 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__16.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__16, Coll[C.Index], "9");
        if (target9((CallSite) p17, obj9))
        {
          CarsInColl = 0;
          CarsInColl = 6;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "VIGINALTE";
          VH2 = "DELUXO";
          VH3 = "DUKES";
          VH4 = "RUINER2";
          VH5 = "JOURNEY";
          VH6 = "GBURRITO";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 3 ? "Collection: <Unknown>" : "Collection : Movie Icons";
          if (CarsCollected > 4)
          {
            EstValue.Text = "Est Value : $" + 8250000.ToString("N");
            Value = 8250000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__19 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target10 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__19.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p19 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__19;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__18 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj10 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__18.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__18, Coll[C.Index], "10");
        if (target10((CallSite) p19, obj10))
        {
          CarsInColl = 0;
          CarsInColl = 4;
          V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
          V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
          V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
          V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
          V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
          V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
          V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
          V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
          V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
          V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
          V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
          V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
          VH1 = "OPPRESSOR2";
          VH2 = "PROTOTIPO";
          VH3 = "SCRAMJET";
          VH4 = "TEZERACT";
          VH5 = "";
          VH6 = "";
          VH7 = "";
          VH8 = "";
          VH9 = "";
          VH10 = "";
          VH11 = "";
          VH12 = "";
          CarsCollected = 0;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (!this.SC.VehicleName.Equals("null"))
            {
              if (this.SC.VehicleName.Equals(VH1))
                V1.Text = "Vehicle 1 : " + VH1;
              if (this.SC.VehicleName.Equals(VH2))
                V2.Text = "Vehicle 2 : " + VH2;
              if (this.SC.VehicleName.Equals(VH3))
                V3.Text = "Vehicle 3 : " + VH3;
              if (this.SC.VehicleName.Equals(VH4))
                V4.Text = "Vehicle 4 : " + VH4;
              if (this.SC.VehicleName.Equals(VH5))
                V5.Text = "Vehicle 5 : " + VH5;
              if (this.SC.VehicleName.Equals(VH6))
                V6.Text = "Vehicle 6 : " + VH6;
              if (this.SC.VehicleName.Equals(VH7))
                V7.Text = "Vehicle 7 : " + VH7;
              if (this.SC.VehicleName.Equals(VH8))
                V8.Text = "Vehicle 8 : " + VH8;
              if (this.SC.VehicleName.Equals(VH9))
                V9.Text = "Vehicle 9 : " + VH9;
              if (this.SC.VehicleName.Equals(VH10))
                V10.Text = "Vehicle 10 : " + VH10;
              if (this.SC.VehicleName.Equals(VH11))
                V11.Text = "Vehicle 11 : " + VH11;
              if (this.SC.VehicleName.Equals(VH12))
                V12.Text = "Vehicle 12 : " + VH12;
            }
          }
          if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
            ++CarsCollected;
          if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
            ++CarsCollected;
          CName.Text = CarsCollected <= 2 ? "Collection: <Unknown>" : "Collection : The Next Gen";
          if (CarsCollected > 3)
          {
            EstValue.Text = "Est Value : $" + 9250000.ToString("N");
            Value = 9250000;
          }
          else
            EstValue.Text = "Est Value : <Unknown>";
        }
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__21 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target11 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__21.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p21 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__21;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj11 = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__20.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__20, Coll[C.Index], "11");
        if (!target11((CallSite) p21, obj11))
          return;
        CarsInColl = 0;
        CarsInColl = 4;
        V1.Text = CarsInColl < 1 ? "NONE" : "Vehicle 1 :  <Unknown>";
        V2.Text = CarsInColl < 2 ? "NONE" : "Vehicle 2 :  <Unknown>";
        V3.Text = CarsInColl < 3 ? "NONE" : "Vehicle 3 :  <Unknown>";
        V4.Text = CarsInColl < 4 ? "NONE" : "Vehicle 4 :  <Unknown>";
        V5.Text = CarsInColl < 5 ? "NONE" : "Vehicle 5 :  <Unknown>";
        V6.Text = CarsInColl < 6 ? "NONE" : "Vehicle 6 :  <Unknown>";
        V7.Text = CarsInColl < 7 ? "NONE" : "Vehicle 7 :  <Unknown>";
        V8.Text = CarsInColl < 8 ? "NONE" : "Vehicle 8 :  <Unknown>";
        V9.Text = CarsInColl < 9 ? "NONE" : "Vehicle 9 :  <Unknown>";
        V10.Text = CarsInColl < 10 ? "NONE" : "Vehicle 10 :  <Unknown>";
        V11.Text = CarsInColl < 11 ? "NONE" : "Vehicle 11 :  <Unknown>";
        V12.Text = CarsInColl < 12 ? "NONE" : "Vehicle 12 :  <Unknown>";
        VH1 = "COQUETTE";
        VH2 = "NINEF";
        VH3 = "TEMPESTA";
        VH4 = "YOUGA2";
        VH5 = "";
        VH6 = "";
        VH7 = "";
        VH8 = "";
        VH9 = "";
        VH10 = "";
        VH11 = "";
        VH12 = "";
        CarsCollected = 0;
        for (int index1 = 1; index1 < 36; ++index1)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
          this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
          if (!this.SC.VehicleName.Equals("null"))
          {
            if (this.SC.VehicleName.Equals(VH1))
              V1.Text = "Vehicle 1 : " + VH1;
            if (this.SC.VehicleName.Equals(VH2))
              V2.Text = "Vehicle 2 : " + VH2;
            if (this.SC.VehicleName.Equals(VH3))
              V3.Text = "Vehicle 3 : " + VH3;
            if (this.SC.VehicleName.Equals(VH4))
              V4.Text = "Vehicle 4 : " + VH4;
            if (this.SC.VehicleName.Equals(VH5))
              V5.Text = "Vehicle 5 : " + VH5;
            if (this.SC.VehicleName.Equals(VH6))
              V6.Text = "Vehicle 6 : " + VH6;
            if (this.SC.VehicleName.Equals(VH7))
              V7.Text = "Vehicle 7 : " + VH7;
            if (this.SC.VehicleName.Equals(VH8))
              V8.Text = "Vehicle 8 : " + VH8;
            if (this.SC.VehicleName.Equals(VH9))
              V9.Text = "Vehicle 9 : " + VH9;
            if (this.SC.VehicleName.Equals(VH10))
              V10.Text = "Vehicle 10 : " + VH10;
            if (this.SC.VehicleName.Equals(VH11))
              V11.Text = "Vehicle 11 : " + VH11;
            if (this.SC.VehicleName.Equals(VH12))
              V12.Text = "Vehicle 12 : " + VH12;
          }
        }
        if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
          ++CarsCollected;
        CName.Text = CarsCollected <= 2 ? "Collection: <Unknown>" : "Collection : 10 Years Of Marvel";
        if (CarsCollected > 3)
        {
          EstValue.Text = "Est Value : $" + 6250000.ToString("N");
          Value = 6250000;
        }
        else
          EstValue.Text = "Est Value : <Unknown>";
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != SellC)
          return;
        CarsCollected = 0;
        if (!V1.Text.Contains("Unknown") && !V1.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V2.Text.Contains("Unknown") && !V2.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V3.Text.Contains("Unknown") && !V3.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V4.Text.Contains("Unknown") && !V4.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V5.Text.Contains("Unknown") && !V5.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V6.Text.Contains("Unknown") && !V6.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V7.Text.Contains("Unknown") && !V7.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V8.Text.Contains("Unknown") && !V8.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V9.Text.Contains("Unknown") && !V9.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V10.Text.Contains("Unknown") && !V10.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V11.Text.Contains("Unknown") && !V11.Text.Contains("NONE"))
          ++CarsCollected;
        if (!V12.Text.Contains("Unknown") && !V12.Text.Contains("NONE"))
          ++CarsCollected;
        if (CarsCollected == CarsInColl)
        {
          CarsInColl = 0;
          this.modMenuPool.CloseAllMenus();
          Game.Player.Money += Value;
          for (int index1 = 1; index1 < 36; ++index1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            this.SC.CheckCar(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
            if (this.SC.VehicleName.Equals(VH1))
            {
              this.SC.SaveName();
              VH1 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH2))
            {
              this.SC.SaveName();
              VH2 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH3))
            {
              this.SC.SaveName();
              VH3 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH4))
            {
              this.SC.SaveName();
              VH4 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH5))
            {
              this.SC.SaveName();
              VH5 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH6))
            {
              this.SC.SaveName();
              VH6 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH7))
            {
              this.SC.SaveName();
              VH7 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH8))
            {
              this.SC.SaveName();
              VH8 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH9))
            {
              this.SC.SaveName();
              VH9 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH10))
            {
              this.SC.SaveName();
              VH10 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH11))
            {
              this.SC.SaveName();
              VH11 = "NONE";
            }
            if (this.SC.VehicleName.Equals(VH12))
            {
              this.SC.SaveName();
              VH12 = "NONE";
            }
          }
          this.DestoryCars();
          this.CreateCars("GarageA");
          UI.Notify("Success Sold All vehicles From this Collection");
        }
        else
          UI.Notify("One or more cars is missing from this collection, please retrieve the vehicle and try again");
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Sell Vehicle Option A (Worse)");
      this.GUIMenus.Add(uiMenu2);
      UIMenuListItem s = new UIMenuListItem("Slot : ", Slots, 0);
      uiMenu2.AddItem((UIMenuItem) s);
      UIMenuItem CarinSlot = new UIMenuItem("Car : ");
      uiMenu2.AddItem(CarinSlot);
      UIMenuItem Delete1 = new UIMenuItem("Sell and Remove");
      uiMenu2.AddItem(Delete1);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Sell Vehicle Option B (Better)");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem s1 = new UIMenuListItem("Slot : ", Slots, 0);
      uiMenu3.AddItem((UIMenuItem) s1);
      UIMenuItem CarinSlot1 = new UIMenuItem("Car : ");
      uiMenu3.AddItem(CarinSlot1);
      UIMenuItem Delete2 = new UIMenuItem("Sell and Remove");
      uiMenu3.AddItem(Delete2);
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Sell Multiple Vehicles (Better)");
      this.GUIMenus.Add(uiMenu4);
      UIMenuListItem Veh1 = new UIMenuListItem("Vehicle 1 : ", items, 0);
      uiMenu4.AddItem((UIMenuItem) Veh1);
      UIMenuListItem Veh2 = new UIMenuListItem("Vehicle 2 : ", items, 0);
      uiMenu4.AddItem((UIMenuItem) Veh2);
      UIMenuListItem Veh3 = new UIMenuListItem("Vehicle 3 : ", items, 0);
      uiMenu4.AddItem((UIMenuItem) Veh3);
      UIMenuListItem Veh4 = new UIMenuListItem("Vehicle 4 : ", items, 0);
      uiMenu4.AddItem((UIMenuItem) Veh4);
      UIMenuItem Delete3 = new UIMenuItem("Sell Vehicles Selected");
      uiMenu4.AddItem(Delete3);
      uiMenu4.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == Veh1)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot" + Veh1.Index.ToString() + ".ini");
          GTA.Model model = this.SC.CheckCar(this.path + "GarageA//Slot" + Veh1.Index.ToString() + ".ini");
          if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null)
            Veh1.Description = "Vehicle to sell : " + this.SC.VehicleName;
        }
        if (item == Veh2)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot" + Veh2.Index.ToString() + ".ini");
          GTA.Model model = this.SC.CheckCar(this.path + "GarageA//Slot" + Veh2.Index.ToString() + ".ini");
          if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null)
            Veh2.Description = "Vehicle to sell : " + this.SC.VehicleName;
        }
        if (item == Veh3)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot" + Veh3.Index.ToString() + ".ini");
          GTA.Model model = this.SC.CheckCar(this.path + "GarageA//Slot" + Veh3.Index.ToString() + ".ini");
          if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null)
            Veh3.Description = "Vehicle to sell : " + this.SC.VehicleName;
        }
        if (item != Veh4)
          return;
        this.SC.LoadIniFile(this.path + "GarageA//Slot" + Veh4.Index.ToString() + ".ini");
        GTA.Model model1 = this.SC.CheckCar(this.path + "GarageA//Slot" + Veh4.Index.ToString() + ".ini");
        if (!(model1 != (GTA.Model) "null") || !(model1 != (GTA.Model) (string) null))
          return;
        Veh4.Description = "Vehicle to sell : " + this.SC.VehicleName;
      });
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Delete3)
          return;
        int index1 = Veh1.Index;
        int index2 = Veh2.Index;
        int index3 = Veh3.Index;
        int index4 = Veh4.Index;
        if (true)
        {
          this.TotalPay = 0.0f;
          this.TotalLoss = 0.0f;
          this.TotalBonus = 0.0f;
          this.Deliveries = 0;
          foreach (int smokeParticle in this.SmokeParticles)
            Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
          List<Vector3> vector3List = new List<Vector3>();
          if (this.SellMission == 1)
          {
            List<Vector3> groundDropPointLs = this.GroundDropPoint_LS;
          }
          if (this.SellMission == 2)
          {
            List<Vector3> groundDropPointBc = this.GroundDropPoint_BC;
          }
          this.CreatedDealers = false;
          this.DeliveredVehicle1 = false;
          this.DeliveredVehicle2 = false;
          this.DeliveredVehicle3 = false;
          this.DeliveredVehicle4 = false;
          this.NearLoc1 = false;
          this.NearLoc2 = false;
          this.NearLoc3 = false;
          this.NearLoc4 = false;
          this.DeliveredtoLoc1 = false;
          this.DeliveredtoLoc2 = false;
          this.DeliveredtoLoc3 = false;
          this.DeliveredtoLoc4 = false;
          foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
          {
            if ((Entity) supplyMissionVehicle != (Entity) null)
              supplyMissionVehicle.Delete();
          }
          foreach (Prop supplyMissionProp in this.SupplyMissionProps)
          {
            if ((Entity) supplyMissionProp != (Entity) null)
              supplyMissionProp.Delete();
          }
          foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
          {
            if (supplyMissionBlip != (Blip) null)
              supplyMissionBlip.Remove();
          }
          foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
          {
            if ((Entity) supplyMissionPed != (Entity) null)
              supplyMissionPed.Delete();
          }
          if (this.SupplyMissionPeds.Count > 0)
            this.SupplyMissionPeds.Clear();
          if (this.SupplyMissionBlips.Count > 0)
            this.SupplyMissionBlips.Clear();
          if (this.SupplyMissionProps.Count > 0)
            this.SupplyMissionProps.Clear();
          if (this.SupplyMissionVehicles.Count > 0)
            this.SupplyMissionVehicles.Clear();
          System.Random random = new System.Random();
          this.Deliveries = 0;
          random.Next(0, 100);
          this.DeliveryVehicle1 = (Vehicle) null;
          this.DeliveryVehicle2 = (Vehicle) null;
          this.DeliveryVehicle3 = (Vehicle) null;
          this.DeliveryVehicle4 = (Vehicle) null;
          List<object> objectList = new List<object>();
          foreach (Vector3 vector3 in this.GroundDropPoint_BC)
            objectList.Add((object) vector3);
          foreach (Vector3 vector3 in this.GroundDropPoint_LS)
            objectList.Add((object) vector3);
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__22 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, Vector3>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Vector3), typeof (VehicleWarehouse)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.AreaOffset = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__22.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__22, objectList[random.Next(0, objectList.Count)]);
          int num = 0;
          int index5;
          if (Veh1.Index != 0)
          {
            SaveCar sc1 = this.SC;
            string path1 = this.path;
            index5 = Veh1.Index;
            string str1 = index5.ToString();
            string iniName1 = path1 + "GarageA//Slot" + str1 + ".ini";
            sc1.LoadIniFile(iniName1);
            SaveCar sc2 = this.SC;
            string path2 = this.path;
            index5 = Veh1.Index;
            string str2 = index5.ToString();
            string iniName2 = path2 + "GarageA//Slot" + str2 + ".ini";
            GTA.Model model = sc2.CheckCar(iniName2);
            if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null)
            {
              ++num;
              index5 = Veh1.Index;
              this.DeliverSlot1 = "Slot" + index5.ToString();
              this.DeliveryVehicle1 = World.CreateVehicle(this.RequestModel(this.SC.VehicleName.ToUpper()), this.WherehouseMarker, this.WherehouseExitHeading);
              this.SupplyMissionVehicles.Add(this.DeliveryVehicle1);
              this.SC.Load(this.DeliveryVehicle1);
              if ((Entity) this.DeliveryVehicle1 != (Entity) null)
              {
                this.DeliveryVehicle1.AddBlip();
                this.DeliveryVehicle1.CurrentBlip.Sprite = BlipSprite.GetawayCar;
                this.DeliveryVehicle1.CurrentBlip.Color = BlipColor.Blue;
                this.DeliveryVehicle1.CurrentBlip.Name = "Deliver Vehicle to Drop Point";
              }
              this.AreaOffset1 = this.AreaOffset;
              ++this.Deliveries;
            }
          }
          if (Veh2.Index != 0)
          {
            SaveCar sc1 = this.SC;
            string path1 = this.path;
            index5 = Veh2.Index;
            string str1 = index5.ToString();
            string iniName1 = path1 + "GarageA//Slot" + str1 + ".ini";
            sc1.LoadIniFile(iniName1);
            SaveCar sc2 = this.SC;
            string path2 = this.path;
            index5 = Veh2.Index;
            string str2 = index5.ToString();
            string iniName2 = path2 + "GarageA//Slot" + str2 + ".ini";
            GTA.Model model = sc2.CheckCar(iniName2);
            if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null)
            {
              ++num;
              index5 = Veh2.Index;
              this.DeliverSlot2 = "Slot" + index5.ToString();
              this.DeliveryVehicle2 = World.CreateVehicle(this.RequestModel(this.SC.VehicleName.ToUpper()), this.WherehouseMarker, this.WherehouseExitHeading);
              this.SupplyMissionVehicles.Add(this.DeliveryVehicle2);
              this.DeliveryVehicle2.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, 5f, 0.0f));
              this.SC.Load(this.DeliveryVehicle2);
              if ((Entity) this.DeliveryVehicle2 != (Entity) null)
              {
                this.DeliveryVehicle2.AddBlip();
                this.DeliveryVehicle2.CurrentBlip.Sprite = BlipSprite.GetawayCar;
                this.DeliveryVehicle2.CurrentBlip.Color = BlipColor.Blue;
                this.DeliveryVehicle2.CurrentBlip.Name = "Deliver Vehicle to Drop Point";
              }
              this.AreaOffset2 = this.AreaOffset;
              ++this.Deliveries;
            }
          }
          if (Veh3.Index != 0)
          {
            SaveCar sc1 = this.SC;
            string path1 = this.path;
            index5 = Veh3.Index;
            string str1 = index5.ToString();
            string iniName1 = path1 + "GarageA//Slot" + str1 + ".ini";
            sc1.LoadIniFile(iniName1);
            SaveCar sc2 = this.SC;
            string path2 = this.path;
            index5 = Veh3.Index;
            string str2 = index5.ToString();
            string iniName2 = path2 + "GarageA//Slot" + str2 + ".ini";
            GTA.Model model = sc2.CheckCar(iniName2);
            if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null)
            {
              ++num;
              index5 = Veh3.Index;
              this.DeliverSlot3 = "Slot" + index5.ToString();
              this.DeliveryVehicle3 = World.CreateVehicle(this.RequestModel(this.SC.VehicleName.ToUpper()), this.WherehouseMarker, this.WherehouseExitHeading);
              this.SupplyMissionVehicles.Add(this.DeliveryVehicle3);
              this.DeliveryVehicle3.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, 0.0f));
              this.SC.Load(this.DeliveryVehicle3);
              if ((Entity) this.DeliveryVehicle3 != (Entity) null)
              {
                this.DeliveryVehicle3.AddBlip();
                this.DeliveryVehicle3.CurrentBlip.Sprite = BlipSprite.GetawayCar;
                this.DeliveryVehicle3.CurrentBlip.Color = BlipColor.Blue;
                this.DeliveryVehicle3.CurrentBlip.Name = "Deliver Vehicle to Drop Point";
              }
              this.AreaOffset3 = this.AreaOffset;
              ++this.Deliveries;
            }
          }
          if (Veh4.Index != 0)
          {
            SaveCar sc1 = this.SC;
            string path1 = this.path;
            index5 = Veh4.Index;
            string str1 = index5.ToString();
            string iniName1 = path1 + "GarageA//Slot" + str1 + ".ini";
            sc1.LoadIniFile(iniName1);
            SaveCar sc2 = this.SC;
            string path2 = this.path;
            index5 = Veh4.Index;
            string str2 = index5.ToString();
            string iniName2 = path2 + "GarageA//Slot" + str2 + ".ini";
            GTA.Model model = sc2.CheckCar(iniName2);
            if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null)
            {
              ++num;
              index5 = Veh4.Index;
              this.DeliverSlot4 = "Slot" + index5.ToString();
              this.DeliveryVehicle4 = World.CreateVehicle(this.RequestModel(this.SC.VehicleName.ToUpper()), this.WherehouseMarker, this.WherehouseExitHeading);
              this.SupplyMissionVehicles.Add(this.DeliveryVehicle4);
              this.DeliveryVehicle4.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(5f, 5f, 0.0f));
              this.SC.Load(this.DeliveryVehicle4);
              if ((Entity) this.DeliveryVehicle4 != (Entity) null)
              {
                this.DeliveryVehicle4.AddBlip();
                this.DeliveryVehicle4.CurrentBlip.Sprite = BlipSprite.GetawayCar;
                this.DeliveryVehicle4.CurrentBlip.Color = BlipColor.Blue;
                this.DeliveryVehicle4.CurrentBlip.Name = "Deliver Vehicle to Drop Point";
              }
              this.AreaOffset4 = this.AreaOffset;
              ++this.Deliveries;
            }
          }
          if (num == 0)
            UI.Notify(this.GetHostName() + " All vehicle slots selected are empty!");
          if (num == 0)
            return;
          Blip blip = World.CreateBlip(this.AreaOffset);
          blip.Sprite = BlipSprite.Standard;
          blip.Color = BlipColor.Yellow;
          blip.Name = "Drop Off";
          blip.Alpha = (int) byte.MaxValue;
          blip.IsShortRange = true;
          this.DeliverLocBlip1 = blip;
          Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip, (InputArgument) true);
          this.SupplyMissionBlips.Add(blip);
          this.TriggerWanted = true;
          this.SupplyMissionID = 1;
          this.SupplyMissionStage = 1;
          this.SupplyMissionOn = true;
        }
        else
          UI.Notify(this.GetHostName() + " You cannot sell multiple vehicles in the same slot");
      });
      uiMenu2.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != s)
          return;
        this.SC.LoadIniFile(this.path + "GarageA//" + s.IndexToItem(s.Index)?.ToString() + ".ini");
        if (!this.SC.VehicleName.Equals("null"))
        {
          CarinSlot.Text = this.SC.VehicleName;
        }
        else
        {
          if (!this.SC.VehicleName.Equals("null"))
            return;
          CarinSlot.Text = "No car in slot";
        }
      });
      uiMenu3.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != s1)
          return;
        this.SC.LoadIniFile(this.path + "GarageA//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini");
        if (!this.SC.VehicleName.Equals("null"))
        {
          CarinSlot1.Text = this.SC.VehicleName;
        }
        else
        {
          if (!this.SC.VehicleName.Equals("null"))
            return;
          CarinSlot1.Text = "No car in slot";
        }
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Delete1)
          return;
        Vehicle vehicle = (Vehicle) null;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__23 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__23 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string str = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__23.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__23, Slots[s.Index]);
        if (str.Equals("Slot1"))
          vehicle = this.Vehicle1;
        if (str.Equals("Slot2"))
          vehicle = this.Vehicle2;
        if (str.Equals("Slot3"))
          vehicle = this.Vehicle3;
        if (str.Equals("Slot4"))
          vehicle = this.Vehicle4;
        if (str.Equals("Slot5"))
          vehicle = this.Vehicle5;
        if (str.Equals("Slot6"))
          vehicle = this.Vehicle6;
        if (str.Equals("Slot7"))
          vehicle = this.Vehicle7;
        if (str.Equals("Slot8"))
          vehicle = this.Vehicle8;
        if (str.Equals("Slot9"))
          vehicle = this.Vehicle9;
        if (str.Equals("Slot10"))
          vehicle = this.Vehicle10;
        if (str.Equals("Slot11"))
          vehicle = this.Vehicle11;
        if (str.Equals("Slot12"))
          vehicle = this.Vehicle12;
        if (str.Equals("Slot13"))
          vehicle = this.Vehicle13;
        if (str.Equals("Slot14"))
          vehicle = this.Vehicle14;
        if (str.Equals("Slot15"))
          vehicle = this.Vehicle15;
        if (str.Equals("Slot16"))
          vehicle = this.Vehicle16;
        if (str.Equals("Slot17"))
          vehicle = this.Vehicle17;
        if (str.Equals("Slot18"))
          vehicle = this.Vehicle18;
        if (str.Equals("Slot19"))
          vehicle = this.Vehicle19;
        if (str.Equals("Slot20"))
          vehicle = this.Vehicle20;
        if (str.Equals("Slot21"))
          vehicle = this.Vehicle21;
        if (str.Equals("Slot22"))
          vehicle = this.Vehicle22;
        if (str.Equals("Slot23"))
          vehicle = this.Vehicle23;
        if (str.Equals("Slot24"))
          vehicle = this.Vehicle25;
        if (str.Equals("Slot25"))
          vehicle = this.Vehicle25;
        if (str.Equals("Slot26"))
          vehicle = this.Vehicle26;
        if (str.Equals("Slot27"))
          vehicle = this.Vehicle27;
        if (str.Equals("Slot28"))
          vehicle = this.Vehicle28;
        if (str.Equals("Slot29"))
          vehicle = this.Vehicle29;
        if (str.Equals("Slot30"))
          vehicle = this.Vehicle30;
        if (str.Equals("Slot31"))
          vehicle = this.Vehicle31;
        if (str.Equals("Slot32"))
          vehicle = this.Vehicle32;
        if (str.Equals("Slot33"))
          vehicle = this.Vehicle33;
        if (str.Equals("Slot34"))
          vehicle = this.Vehicle34;
        if (str.Equals("Slot35"))
          vehicle = this.Vehicle35;
        if (!((Entity) vehicle != (Entity) null))
          return;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__24 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__24 = CallSite<Action<CallSite, VehicleWarehouse, object, Vehicle>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "DeleteCarinSlot", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__24.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__24, this, Slots[s.Index], vehicle);
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Delete2)
          return;
        Vehicle V = (Vehicle) null;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__25 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__25 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string Slot = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__25.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__25, Slots[s1.Index]);
        if (Slot.Equals("Slot1"))
          V = this.Vehicle1;
        if (Slot.Equals("Slot2"))
          V = this.Vehicle2;
        if (Slot.Equals("Slot3"))
          V = this.Vehicle3;
        if (Slot.Equals("Slot4"))
          V = this.Vehicle4;
        if (Slot.Equals("Slot5"))
          V = this.Vehicle5;
        if (Slot.Equals("Slot6"))
          V = this.Vehicle6;
        if (Slot.Equals("Slot7"))
          V = this.Vehicle7;
        if (Slot.Equals("Slot8"))
          V = this.Vehicle8;
        if (Slot.Equals("Slot9"))
          V = this.Vehicle9;
        if (Slot.Equals("Slot10"))
          V = this.Vehicle10;
        if (Slot.Equals("Slot11"))
          V = this.Vehicle11;
        if (Slot.Equals("Slot12"))
          V = this.Vehicle12;
        if (Slot.Equals("Slot13"))
          V = this.Vehicle13;
        if (Slot.Equals("Slot14"))
          V = this.Vehicle14;
        if (Slot.Equals("Slot15"))
          V = this.Vehicle15;
        if (Slot.Equals("Slot16"))
          V = this.Vehicle16;
        if (Slot.Equals("Slot17"))
          V = this.Vehicle17;
        if (Slot.Equals("Slot18"))
          V = this.Vehicle18;
        if (Slot.Equals("Slot19"))
          V = this.Vehicle19;
        if (Slot.Equals("Slot20"))
          V = this.Vehicle20;
        if (Slot.Equals("Slot21"))
          V = this.Vehicle21;
        if (Slot.Equals("Slot22"))
          V = this.Vehicle22;
        if (Slot.Equals("Slot23"))
          V = this.Vehicle23;
        if (Slot.Equals("Slot24"))
          V = this.Vehicle25;
        if (Slot.Equals("Slot25"))
          V = this.Vehicle25;
        if (Slot.Equals("Slot26"))
          V = this.Vehicle26;
        if (Slot.Equals("Slot27"))
          V = this.Vehicle27;
        if (Slot.Equals("Slot28"))
          V = this.Vehicle28;
        if (Slot.Equals("Slot29"))
          V = this.Vehicle29;
        if (Slot.Equals("Slot30"))
          V = this.Vehicle30;
        if (Slot.Equals("Slot31"))
          V = this.Vehicle31;
        if (Slot.Equals("Slot32"))
          V = this.Vehicle32;
        if (Slot.Equals("Slot33"))
          V = this.Vehicle33;
        if (Slot.Equals("Slot34"))
          V = this.Vehicle34;
        if (Slot.Equals("Slot35"))
          V = this.Vehicle35;
        if (!((Entity) V != (Entity) null))
          return;
        this.DeliveredtoLoc1 = false;
        foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
        {
          if ((Entity) supplyMissionVehicle != (Entity) null)
            supplyMissionVehicle.Delete();
        }
        if (this.SupplyMissionVehicles.Count > 0)
          this.SupplyMissionVehicles.Clear();
        foreach (Prop supplyMissionProp in this.SupplyMissionProps)
        {
          if ((Entity) supplyMissionProp != (Entity) null)
            supplyMissionProp.Delete();
        }
        if (this.SupplyMissionProps.Count > 0)
          this.SupplyMissionProps.Clear();
        foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
        {
          if (supplyMissionBlip != (Blip) null)
            supplyMissionBlip.Remove();
        }
        if (this.SupplyMissionBlips.Count > 0)
          this.SupplyMissionBlips.Clear();
        foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
        {
          if ((Entity) supplyMissionPed != (Entity) null)
            supplyMissionPed.Delete();
        }
        if (this.SupplyMissionPeds.Count > 0)
          this.SupplyMissionPeds.Clear();
        foreach (Vehicle asellMissionVehicle in this.SourceASellMissionVehicles)
        {
          if ((Entity) asellMissionVehicle != (Entity) null)
            asellMissionVehicle.Delete();
        }
        if (this.SourceASellMissionVehicles.Count > 0)
          this.SourceASellMissionVehicles.Clear();
        foreach (Prop asellMissionProp in this.SourceASellMissionProps)
        {
          if ((Entity) asellMissionProp != (Entity) null)
            asellMissionProp.Delete();
        }
        if (this.SourceASellMissionProps.Count > 0)
          this.SourceASellMissionProps.Clear();
        foreach (Blip asellMissionBlip in this.SourceASellMissionBlips)
        {
          if (asellMissionBlip != (Blip) null)
            asellMissionBlip.Remove();
        }
        if (this.SourceASellMissionBlips.Count > 0)
          this.SourceASellMissionBlips.Clear();
        foreach (Ped sourceAsellMissionPed in this.SourceASellMissionPeds)
        {
          if ((Entity) sourceAsellMissionPed != (Entity) null)
            sourceAsellMissionPed.Delete();
        }
        if (this.SourceASellMissionPeds.Count > 0)
          this.SourceASellMissionPeds.Clear();
        this.DeliveringVehicle = true;
        this.LoadCarinToRealWorld2(V, Slot);
        this.SlotToDelete = Slot;
        UI.Notify(this.GetHostName() + " ok boss deliver this vehicle to the ~y~Buyer to sell it for a higher price");
        List<object> objectList = new List<object>();
        foreach (Vector3 vector3 in this.GroundDropPoint_BC)
          objectList.Add((object) vector3);
        foreach (Vector3 vector3 in this.GroundDropPoint_LS)
          objectList.Add((object) vector3);
        System.Random random = new System.Random();
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__26 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__26 = CallSite<Func<CallSite, object, Vector3>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Vector3), typeof (VehicleWarehouse)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.AreaOffset = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__26.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__26, objectList[random.Next(0, objectList.Count)]);
        Blip blip = World.CreateBlip(this.AreaOffset);
        blip.Sprite = BlipSprite.Standard;
        blip.Color = BlipColor.Yellow;
        blip.Name = "Drop Off";
        blip.Alpha = (int) byte.MaxValue;
        blip.IsShortRange = true;
        this.DeliverLocBlip1 = blip;
        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip, (InputArgument) true);
        this.SupplyMissionBlips.Add(blip);
        this.TriggerWanted = true;
        this.SupplyMissionID = 2;
        this.SupplyMissionStage = 1;
        this.SupplyMissionOn = true;
      });
      UIMenu uiMenu5 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Add vehicle in Slot");
      this.GUIMenus.Add(uiMenu5);
      List<object> LogList = new List<object>();
      string[] logFile = File.ReadAllLines(this.ListPath);
      foreach (string str in logFile)
        LogList.Add((object) str);
      this.LoadIniFile2(this.ListPath);
      List<object> objectList1 = new List<object>()
      {
        (object) "None",
        (object) "Super",
        (object) "Sport",
        (object) "Armoured",
        (object) "SportClassic",
        (object) "Compact",
        (object) "Coupe",
        (object) "Bikes",
        (object) "Offroad",
        (object) "Sedan",
        (object) "Suv",
        (object) "Vans"
      };
      UIMenuListItem Ve = new UIMenuListItem("Vehicle : ", LogList, 0);
      uiMenu5.AddItem((UIMenuItem) Ve);
      UIMenuItem VDName = new UIMenuItem("Vehicle Spawn Name  : Dukes2");
      uiMenu5.AddItem(VDName);
      UIMenuItem VName = new UIMenuItem("Vehicle Full Name  : Imponte Dukes");
      uiMenu5.AddItem(VName);
      UIMenuItem PuchaseV = new UIMenuItem("Purchase Vehicle : $0");
      uiMenu5.AddItem(PuchaseV);
      List<object> STlist = new List<object>();
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      UIMenuItem uiMenuItem1 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu5.AddItem(uiMenuItem1);
      UIMenuItem Search = new UIMenuItem("Enter Vehicle Name");
      uiMenu5.AddItem(Search);
      UIMenuListItem Ve2 = new UIMenuListItem("Vehicle : ", STlist, 0);
      uiMenu5.AddItem((UIMenuItem) Ve2);
      UIMenuItem uiMenuItem2 = new UIMenuItem("Search Term  : NULL");
      uiMenu5.AddItem(uiMenuItem2);
      UIMenuItem VDName2 = new UIMenuItem("Vehicle Spawn Name  : NULL");
      uiMenu5.AddItem(VDName2);
      UIMenuItem VName2 = new UIMenuItem("Vehicle Full Name  : NULL");
      uiMenu5.AddItem(VName2);
      UIMenuItem PuchaseV2 = new UIMenuItem("Purchase Vehicle : NULL");
      uiMenu5.AddItem(PuchaseV2);
      UIMenuItem uiMenuItem3 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu5.AddItem(uiMenuItem3);
      UIMenuListItem ListSlot = new UIMenuListItem("Slot: ", Slots, 0);
      uiMenu5.AddItem((UIMenuItem) ListSlot);
      uiMenu5.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == Ve)
        {
          try
          {
            string[] separator = new string[2]{ " = ", "," };
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__27 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__27 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            string[] strArray = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__27.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__27, LogList[Ve.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (int index1 = 0; index1 < strArray.Length; ++index1)
            {
              this.Price = strArray[1];
              this.Model = strArray[2];
              this.man = strArray[0];
              VDName.Text = "Vehicle Spawn Name : " + this.Model;
              VName.Text = "Vehicle Full Name  : " + this.man;
              PuchaseV.Text = "Purchase Vehicle : " + this.Price;
            }
          }
          catch
          {
          }
        }
        if (item != Ve2)
          return;
        try
        {
          string[] separator = new string[2]{ " = ", "," };
          // ISSUE: reference to a compiler-generated field
          if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__28 == null)
          {
            // ISSUE: reference to a compiler-generated field
            VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__28 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string[] strArray = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__28.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__28, STlist[Ve2.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
          for (int index1 = 0; index1 < strArray.Length; ++index1)
          {
            this.Price = strArray[1];
            this.Model = strArray[2];
            this.man = strArray[0];
            VDName2.Text = "Vehicle Spawn Name : " + this.Model;
            VName2.Text = "Vehicle Full Name  : " + this.man;
            PuchaseV2.Text = "Purchase Vehicle : " + this.Price;
          }
        }
        catch
        {
        }
      });
      string SearchTerm;
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Search)
        {
          try
          {
            if (STlist.Count > 0)
              STlist.Clear();
            SearchTerm = Game.GetUserInput(32);
            SearchTerm = SearchTerm.ToUpper();
            UI.Notify("Search Term : " + SearchTerm);
            bool flag = false;
            foreach (string str in logFile)
            {
              if (str.ToUpper().Contains(SearchTerm))
              {
                UI.Notify("Found Match");
                STlist.Add((object) str);
                flag = true;
              }
            }
            if (!flag)
            {
              UI.Notify("Found No Match");
              STlist.Add((object) "NULL");
              STlist.Add((object) "NULL");
              STlist.Add((object) "NULL");
              STlist.Add((object) "NULL");
              STlist.Add((object) "NULL");
              STlist.Add((object) "NULL");
            }
          }
          catch (Exception ex)
          {
            UI.Notify("Invalid Search Term Entered");
          }
        }
        try
        {
          this.M = (float) int.Parse(this.Price);
        }
        catch (Exception ex)
        {
        }
        if (item == PuchaseV2)
        {
          if ((double) Game.Player.Money > (double) this.M)
          {
            try
            {
              Game.Player.Money -= (int) this.M;
              this.DestoryCars();
              // ISSUE: reference to a compiler-generated field
              if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__29 == null)
              {
                // ISSUE: reference to a compiler-generated field
                VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__29 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              string str = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__29.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__29, Slots[ListSlot.Index]);
              this.SC.LoadIniFile(this.path + this.GarageNum + "//" + str + ".ini");
              UI.Notify(this.path + this.GarageNum + "//" + str + ".ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.SC.LoadIniFile(this.path + this.GarageNum + "//" + str + ".ini");
              try
              {
                Vehicle vehicle = World.CreateVehicle(this.RequestModel(this.man), new Vector3(), 0.0f);
                this.SC.SaveName(vehicle.DisplayName);
                this.AwaitingClose = true;
                UI.Notify("Warehouse will Refresh, When this menu closes");
                vehicle.Delete();
              }
              catch (NullReferenceException ex)
              {
                UI.Notify("~r~error ~w~ Invalid Vehicle Name!");
              }
            }
            catch (Exception ex)
            {
            }
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item != PuchaseV)
          return;
        if ((double) Game.Player.Money > (double) this.M)
        {
          try
          {
            Game.Player.Money -= (int) this.M;
            this.DestoryCars();
            // ISSUE: reference to a compiler-generated field
            if (VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__30 == null)
            {
              // ISSUE: reference to a compiler-generated field
              VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__30 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (VehicleWarehouse)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            string str = VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__30.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__236.\u003C\u003Ep__30, Slots[ListSlot.Index]);
            this.SC.LoadIniFile(this.path + this.GarageNum + "//" + str + ".ini");
            UI.Notify(this.path + this.GarageNum + "//" + str + ".ini");
            Vector3 position = Game.Player.Character.Position;
            this.SC.Save();
            try
            {
              this.SC.LoadIniFile(this.path + this.GarageNum + "//" + str + ".ini");
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(this.man), new Vector3(), 0.0f);
              this.SC.SaveName(vehicle.DisplayName);
              this.AwaitingClose = true;
              UI.Notify("Warehouse will Refresh, When this menu closes");
              vehicle.Delete();
            }
            catch (Exception ex)
            {
            }
          }
          catch (Exception ex)
          {
          }
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
      });
    }

    public void SaveLocalcar(string G, Vehicle V, string Slot)
    {
      if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        if (Game.Player.Character.CurrentVehicle.DisplayName != "RHINO" || Game.Player.Character.CurrentVehicle.DisplayName != "KHANJALI" || Game.Player.Character.CurrentVehicle.DisplayName != "CHERNOBOG")
        {
          if ((Entity) this.SaveVehicle != (Entity) null)
            this.SaveVehicle.Delete();
          string str = G;
          this.GarageNum = G;
          UI.Notify(this.path + str + "//" + Slot + ".ini");
          this.SC.LoadIniFile(this.path + str + "//" + Slot + ".ini");
          this.SC.Save();
        }
        else
          this.DisplayHelpTextThisFrame("You cannot save this vehicle");
      }
      else
        this.DisplayHelpTextThisFrame("Bring a vehicle to save");
    }

    private void SetupGarage()
    {
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1");
      Slots.Add((object) "Slot2");
      Slots.Add((object) "Slot3");
      Slots.Add((object) "Slot4");
      Slots.Add((object) "Slot5");
      Slots.Add((object) "Slot6");
      Slots.Add((object) "Slot7");
      Slots.Add((object) "Slot8");
      Slots.Add((object) "Slot9");
      Slots.Add((object) "Slot10");
      Slots.Add((object) "Slot11");
      Slots.Add((object) "Slot12");
      Slots.Add((object) "Slot13");
      Slots.Add((object) "Slot14");
      Slots.Add((object) "Slot15");
      Slots.Add((object) "Slot16");
      Slots.Add((object) "Slot17");
      Slots.Add((object) "Slot18");
      Slots.Add((object) "Slot19");
      Slots.Add((object) "Slot20");
      Slots.Add((object) "Slot21");
      Slots.Add((object) "Slot22");
      Slots.Add((object) "Slot23");
      Slots.Add((object) "Slot24");
      Slots.Add((object) "Slot25");
      Slots.Add((object) "Slot26");
      Slots.Add((object) "Slot27");
      Slots.Add((object) "Slot28");
      Slots.Add((object) "Slot29");
      Slots.Add((object) "Slot30");
      Slots.Add((object) "Slot31");
      Slots.Add((object) "Slot32");
      Slots.Add((object) "Slot33");
      Slots.Add((object) "Slot34");
      Slots.Add((object) "Slot35");
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.GarageMenu, "Enter Warehouse");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem s = new UIMenuListItem("Slot : ", Slots, 0);
      uiMenu.AddItem((UIMenuItem) s);
      UIMenuItem CarinSlot = new UIMenuItem("Car : ");
      uiMenu.AddItem(CarinSlot);
      UIMenuItem Set = new UIMenuItem("Save Current Car");
      uiMenu.AddItem(Set);
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != s)
          return;
        this.SC.LoadIniFile(this.path + "GarageA//" + s.IndexToItem(s.Index)?.ToString() + ".ini");
        if (!this.SC.VehicleName.Equals("null"))
        {
          CarinSlot.Text = this.SC.VehicleName;
        }
        else
        {
          if (!this.SC.VehicleName.Equals("null"))
            return;
          CarinSlot.Text = "No car in slot";
        }
      });
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Set)
          return;
        // ISSUE: reference to a compiler-generated field
        if (VehicleWarehouse.\u003C\u003Eo__238.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          VehicleWarehouse.\u003C\u003Eo__238.\u003C\u003Ep__0 = CallSite<Action<CallSite, VehicleWarehouse, string, Vehicle, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "SaveLocalcar", (IEnumerable<System.Type>) null, typeof (VehicleWarehouse), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        VehicleWarehouse.\u003C\u003Eo__238.\u003C\u003Ep__0.Target((CallSite) VehicleWarehouse.\u003C\u003Eo__238.\u003C\u003Ep__0, this, "GarageA", this.Vehicle1, Slots[s.Index]);
      });
    }

    public void OnShutdown()
    {
      if (false)
        return;
      foreach (VehicleWarehouse.Flare flare in this.SellPointsSmoke_Water)
      {
        if ((Entity) flare.FlareProp != (Entity) null)
        {
          Function.Call(Hash._0x8F75998877616996, (InputArgument) flare.FlareID_1, (InputArgument) false);
          flare.FlareProp.Delete();
        }
      }
      foreach (VehicleWarehouse.Flare flare in this.SellPointsSmoke_Air)
      {
        if ((Entity) flare.FlareProp != (Entity) null)
        {
          Function.Call(Hash._0x8F75998877616996, (InputArgument) flare.FlareID_1, (InputArgument) false);
          flare.FlareProp.Delete();
        }
      }
      foreach (VehicleWarehouse.Flare flare in this.Cargo)
      {
        if ((Entity) flare.FlareProp != (Entity) null)
          flare.FlareProp.Delete();
      }
      if (this.CargoDropped.Count > 0)
        this.CargoDropped.Clear();
      foreach (int smokeParticle in this.SmokeParticles)
        Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
      foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
      {
        if ((Entity) supplyMissionVehicle != (Entity) null)
          supplyMissionVehicle.Delete();
      }
      foreach (Prop supplyMissionProp in this.SupplyMissionProps)
      {
        if ((Entity) supplyMissionProp != (Entity) null)
          supplyMissionProp.Delete();
      }
      foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
      {
        if (supplyMissionBlip != (Blip) null)
          supplyMissionBlip.Remove();
      }
      foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
      {
        if ((Entity) supplyMissionPed != (Entity) null)
          supplyMissionPed.Delete();
      }
      foreach (Vehicle asellMissionVehicle in this.SourceASellMissionVehicles)
      {
        if ((Entity) asellMissionVehicle != (Entity) null)
          asellMissionVehicle.Delete();
      }
      foreach (Prop asellMissionProp in this.SourceASellMissionProps)
      {
        if ((Entity) asellMissionProp != (Entity) null)
          asellMissionProp.Delete();
      }
      foreach (Blip asellMissionBlip in this.SourceASellMissionBlips)
      {
        if (asellMissionBlip != (Blip) null)
          asellMissionBlip.Remove();
      }
      foreach (Ped sourceAsellMissionPed in this.SourceASellMissionPeds)
      {
        if ((Entity) sourceAsellMissionPed != (Entity) null)
          sourceAsellMissionPed.Delete();
      }
      if ((Entity) this.ChairProp != (Entity) null)
        this.ChairProp.Delete();
      if (this.Sam1blip != (Blip) null)
        this.Sam1blip.Remove();
      if (this.Sam2blip != (Blip) null)
        this.Sam2blip.Remove();
      if (this.Sam3blip != (Blip) null)
        this.Sam3blip.Remove();
      if ((Entity) this.Sam1 != (Entity) null)
        this.Sam1.Delete();
      if ((Entity) this.Sam2 != (Entity) null)
        this.Sam2.Delete();
      if ((Entity) this.Sam3 != (Entity) null)
        this.Sam3.Delete();
      if (this.VehicleMarker != (Blip) null)
        this.VehicleMarker.Remove();
      if (this.VehicleWarehouseMarker != (Blip) null)
        this.VehicleWarehouseMarker.Remove();
      if ((Entity) this.Vehicle1 != (Entity) null)
        this.Vehicle1.Delete();
      if ((Entity) this.Vehicle2 != (Entity) null)
        this.Vehicle2.Delete();
      if ((Entity) this.Vehicle3 != (Entity) null)
        this.Vehicle3.Delete();
      if ((Entity) this.Vehicle4 != (Entity) null)
        this.Vehicle4.Delete();
      if ((Entity) this.Vehicle5 != (Entity) null)
        this.Vehicle5.Delete();
      if ((Entity) this.Vehicle5 != (Entity) null)
        this.Vehicle5.Delete();
      if ((Entity) this.Vehicle6 != (Entity) null)
        this.Vehicle6.Delete();
      if ((Entity) this.Vehicle7 != (Entity) null)
        this.Vehicle7.Delete();
      if ((Entity) this.Vehicle8 != (Entity) null)
        this.Vehicle8.Delete();
      if ((Entity) this.Vehicle9 != (Entity) null)
        this.Vehicle9.Delete();
      if ((Entity) this.Vehicle10 != (Entity) null)
        this.Vehicle10.Delete();
      if ((Entity) this.Vehicle11 != (Entity) null)
        this.Vehicle11.Delete();
      if ((Entity) this.Vehicle12 != (Entity) null)
        this.Vehicle12.Delete();
      if ((Entity) this.Vehicle13 != (Entity) null)
        this.Vehicle13.Delete();
      if ((Entity) this.Vehicle14 != (Entity) null)
        this.Vehicle14.Delete();
      if ((Entity) this.Vehicle15 != (Entity) null)
        this.Vehicle15.Delete();
      if ((Entity) this.Vehicle16 != (Entity) null)
        this.Vehicle16.Delete();
      if ((Entity) this.Vehicle17 != (Entity) null)
        this.Vehicle17.Delete();
      if ((Entity) this.Vehicle18 != (Entity) null)
        this.Vehicle18.Delete();
      if ((Entity) this.Vehicle19 != (Entity) null)
        this.Vehicle19.Delete();
      if ((Entity) this.Vehicle20 != (Entity) null)
        this.Vehicle20.Delete();
      if ((Entity) this.Vehicle21 != (Entity) null)
        this.Vehicle21.Delete();
      if ((Entity) this.Vehicle22 != (Entity) null)
        this.Vehicle22.Delete();
      if ((Entity) this.Vehicle23 != (Entity) null)
        this.Vehicle23.Delete();
      if ((Entity) this.Vehicle24 != (Entity) null)
        this.Vehicle24.Delete();
      if ((Entity) this.Vehicle25 != (Entity) null)
        this.Vehicle25.Delete();
      if ((Entity) this.Vehicle26 != (Entity) null)
        this.Vehicle26.Delete();
      if ((Entity) this.Vehicle27 != (Entity) null)
        this.Vehicle27.Delete();
      if ((Entity) this.Vehicle28 != (Entity) null)
        this.Vehicle28.Delete();
      if ((Entity) this.Vehicle29 != (Entity) null)
        this.Vehicle29.Delete();
      if ((Entity) this.Vehicle30 != (Entity) null)
        this.Vehicle30.Delete();
      if ((Entity) this.Vehicle31 != (Entity) null)
        this.Vehicle31.Delete();
      if ((Entity) this.Vehicle32 != (Entity) null)
        this.Vehicle32.Delete();
      if ((Entity) this.Vehicle33 != (Entity) null)
        this.Vehicle33.Delete();
      if ((Entity) this.Vehicle34 != (Entity) null)
        this.Vehicle34.Delete();
      if ((Entity) this.Vehicle35 != (Entity) null)
        this.Vehicle35.Delete();
      if ((Entity) this.RampBuggy != (Entity) null)
        this.RampBuggy.Delete();
      if ((Entity) this.Ruiner2000 != (Entity) null)
        this.Ruiner2000.Delete();
      if ((Entity) this.Boxville != (Entity) null)
        this.Boxville.Delete();
      if ((Entity) this.TechnicalA != (Entity) null)
        this.TechnicalA.Delete();
      if ((Entity) this.Rvoltic != (Entity) null)
        this.Rvoltic.Delete();
      if ((Entity) this.PhantomW != (Entity) null)
        this.PhantomW.Delete();
      if ((Entity) this.BlazerAqua != (Entity) null)
        this.BlazerAqua.Delete();
      if (!((Entity) this.Wastelander != (Entity) null))
        return;
      this.Wastelander.Delete();
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    private string func_715(int iParam0)
    {
      switch (iParam0)
      {
        case 0:
          return "SVM_VEH_1";
        case 1:
          return "SVM_VEH_2";
        case 2:
          return "SVM_VEH_3";
        case 3:
          return "SVM_VEH_4";
        case 4:
          return "SVM_VEH_5";
        case 5:
          return "SVM_VEH_6";
        case 6:
          return "SVM_VEH_7";
        case 7:
          return "SVM_VEH_8";
        default:
          return "";
      }
    }

    private string func_716(int iParam0)
    {
      switch (iParam0)
      {
        case 0:
          return "SVM_MIS_1";
        case 1:
          return "SVM_MIS_2";
        case 2:
          return "SVM_MIS_3";
        case 3:
          return "SVM_MIS_4";
        case 4:
          return "SVM_MIS_5";
        case 5:
          return "SVM_MIS_6";
        case 6:
          return "SVM_MIS_7";
        case 7:
          return "SVM_MIS_8";
        default:
          return "";
      }
    }

    private string func_369(int iParam0)
    {
      switch (iParam0)
      {
        case 1:
          return "DYN_MPWH_1";
        case 2:
          return "DYN_MPWH_2";
        case 3:
          return "DYN_MPWH_3";
        case 4:
          return "DYN_MPWH_4";
        case 5:
          return "DYN_MPWH_5";
        case 6:
          return "DYN_MPWH_6";
        case 7:
          return "DYN_MPWH_7";
        case 8:
          return "DYN_MPWH_8";
        case 9:
          return "DYN_MPWH_9";
        case 10:
          return "DYN_MPWH_10";
        case 11:
          return "DYN_MPWH_11";
        case 12:
          return "DYN_MPWH_12";
        case 13:
          return "DYN_MPWH_13";
        case 14:
          return "DYN_MPWH_14";
        case 15:
          return "DYN_MPWH_15";
        case 16:
          return "DYN_MPWH_16";
        case 17:
          return "DYN_MPWH_17";
        case 18:
          return "DYN_MPWH_18";
        case 19:
          return "DYN_MPWH_19";
        case 20:
          return "DYN_MPWH_20";
        case 21:
          return "DYN_MPWH_21";
        case 22:
          return "DYN_MPWH_22";
        default:
          return "";
      }
    }

    private string func_370(int iParam0)
    {
      switch (iParam0)
      {
        case 1:
          return "MP_WHOUSE_0DES";
        case 2:
          return "MP_WHOUSE_1DES";
        case 3:
          return "MP_WHOUSE_2DES";
        case 4:
          return "MP_WHOUSE_3DES";
        case 5:
          return "MP_WHOUSE_4DES";
        case 6:
          return "MP_WHOUSE_5DES";
        case 7:
          return "MP_WHOUSE_6DES";
        case 8:
          return "MP_WHOUSE_7DES";
        case 9:
          return "MP_WHOUSE_8DES";
        case 10:
          return "MP_WHOUSE_9DES";
        case 11:
          return "MP_WHOUSE_10DES";
        case 12:
          return "MP_WHOUSE_11DES";
        case 13:
          return "MP_WHOUSE_12DES";
        case 14:
          return "MP_WHOUSE_13DES";
        case 15:
          return "MP_WHOUSE_14DES";
        case 16:
          return "MP_WHOUSE_15DES";
        case 17:
          return "MP_WHOUSE_16DES";
        case 18:
          return "MP_WHOUSE_17DES";
        case 19:
          return "MP_WHOUSE_18DES";
        case 20:
          return "MP_WHOUSE_19DES";
        case 21:
          return "MP_WHOUSE_20DES";
        case 22:
          return "MP_WHOUSE_21DES";
        default:
          return "";
      }
    }

    public int GetVehicleCount()
    {
      int num = 0;
      for (int index = 1; index < 41; ++index)
      {
        this.SC.LoadIniFile(this.path + "GarageA//Slot" + index.ToString() + ".ini");
        GTA.Model model = this.SC.CheckCar(this.path + "GarageA//Slot" + index.ToString() + ".ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null)
          ++num;
      }
      return num;
    }

    public float GetWarehouseValue()
    {
      this.ListPath = "scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MilitaryTrader\\AllVehicles.ini";
      List<object> objectList = new List<object>();
      foreach (string readAllLine in File.ReadAllLines(this.ListPath))
        objectList.Add((object) readAllLine);
      float num1 = 0.0f;
      for (int index1 = 1; index1 < 41; ++index1)
      {
        this.SC.LoadIniFile(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
        string str = this.SC.GrabCarName(this.path + "GarageA//Slot" + index1.ToString() + ".ini");
        if (str != "null" && str != null)
        {
          for (int index2 = 0; index2 < this.VehiclesData.Count; ++index2)
          {
            if (this.VehiclesData[index2].modelString.ToUpper().Equals(str.ToUpper()))
            {
              try
              {
                int num2 = int.Parse(this.VehiclesData[index2].Price);
                num1 += (float) (num2 / 10);
              }
              catch
              {
              }
            }
          }
        }
      }
      return num1;
    }

    public float GetVehicleValue(string Vehicle, int devide)
    {
      this.ListPath = "scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MilitaryTrader\\AllVehicles.ini";
      List<object> objectList = new List<object>();
      foreach (string readAllLine in File.ReadAllLines(this.ListPath))
        objectList.Add((object) readAllLine);
      float num1 = 0.0f;
      if (Vehicle != "null")
      {
        for (int index = 0; index < this.VehiclesData.Count; ++index)
        {
          if (this.VehiclesData[index].modelString.ToUpper().Equals(Vehicle.ToUpper()))
          {
            try
            {
              int num2 = int.Parse(this.VehiclesData[index].Price);
              num1 += (float) (num2 / devide);
            }
            catch
            {
            }
          }
        }
      }
      return num1;
    }

    public static Vector3 GenerateSpawnPos(
      Vector3 desiredPos,
      VehicleWarehouse.Nodetype roadtype,
      bool sidewalk)
    {
      Vector3 zero = Vector3.Zero;
      bool flag = false;
      OutputArgument outputArgument = new OutputArgument();
      int num1 = 1;
      int num2 = 0;
      if (roadtype == VehicleWarehouse.Nodetype.AnyRoad)
        num2 = 1;
      if (roadtype == VehicleWarehouse.Nodetype.Road)
        num2 = 0;
      if (roadtype == VehicleWarehouse.Nodetype.Offroad)
      {
        num2 = 1;
        flag = true;
      }
      if (roadtype == VehicleWarehouse.Nodetype.Water)
        num2 = 3;
      int num3 = Function.Call<int>(Hash._0x22D7275A79FE8215, (InputArgument) desiredPos.X, (InputArgument) desiredPos.Y, (InputArgument) desiredPos.Z, (InputArgument) num1, (InputArgument) num2, (InputArgument) 300f, (InputArgument) 300f);
      if (flag)
      {
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x4F5070AA58F69279, (InputArgument) num3) && num1 < 500)
          {
            ++num1;
            num3 = Function.Call<int>(Hash._0x22D7275A79FE8215, (InputArgument) desiredPos.X, (InputArgument) desiredPos.Y, (InputArgument) desiredPos.Z, (InputArgument) num1, (InputArgument) num2, (InputArgument) 300f, (InputArgument) 300f);
          }
          else
            break;
        }
      }
      Function.Call(Hash._0x703123E5E7D429C2, (InputArgument) num3, (InputArgument) outputArgument);
      Vector3 position = outputArgument.GetResult<Vector3>();
      if (sidewalk)
        position = World.GetNextPositionOnSidewalk(position);
      return position;
    }

    public void CreateSmoke(Vector3 X)
    {
      Vector3 vector3 = X;
      for (int index = 0; index < 100; ++index)
      {
        Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_oddjobtraffickingair");
        Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_oddjobtraffickingair");
      }
      X = new Vector3(vector3.X, vector3.Y, World.GetGroundHeight(new Vector3(vector3.X, vector3.Y, vector3.Z + 500f)));
      Prop prop = World.CreateProp(this.RequestModel("prop_flare_01b"), X, false, false);
      this.SupplyMissionProps.Add(prop);
      int num = Function.Call<int>(Hash._0xE184F4F0DC5910E7, (InputArgument) "scr_crate_drop_flare", (InputArgument) X.X, (InputArgument) X.Y, (InputArgument) X.Z, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 5f, (InputArgument) false, (InputArgument) false, (InputArgument) false, (InputArgument) false);
      this.SetRange(num, 100000f);
      this.SetColor(num, (float) byte.MaxValue, 0.0f, 0.0f, true);
      this.SmokeParticles.Add(num);
      this.SmokePropaParticles.Add(new VehicleWarehouse.Flare(prop, num, true));
    }

    private void SetColor(int particle, float r, float g, float b, bool p1) => Function.Call(Hash._0x7F8F65877F88783B, (InputArgument) particle, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) p1);

    private void SetRange(int handle, float range) => Function.Call(Hash._0xDCB194B85EF7B541, (InputArgument) handle, (InputArgument) range);

    private int GetBoneByName(Entity entity, string name) => Function.Call<int>(Hash._0xFB71170B7E76ACBA, (InputArgument) entity, (InputArgument) name);

    public void CreateSmoke_SellMission(VehicleWarehouse.Flare X)
    {
      Vector3 location = X.Location;
      X.Created = true;
      for (int index = 0; index < 100; ++index)
      {
        Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_oddjobtraffickingair");
        Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_oddjobtraffickingair");
      }
      Prop prop = World.CreateProp(this.RequestModel("prop_flare_01b"), X.Location, false, false);
      X.FlareProp = prop;
      this.SupplyMissionProps.Add(prop);
      int num = Function.Call<int>(Hash._0xE184F4F0DC5910E7, (InputArgument) "scr_crate_drop_flare", (InputArgument) X.Location.X, (InputArgument) X.Location.Y, (InputArgument) X.Location.Z, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 5f, (InputArgument) false, (InputArgument) false, (InputArgument) false, (InputArgument) false);
      this.SetRange(num, 100000f);
      this.SetColor(num, (float) byte.MaxValue, 0.0f, 0.0f, true);
      X.FlareID_1 = num;
      this.SmokeParticles.Add(num);
    }

    private float progresswidth(float percent) => 0.08f * percent;

    private float progressxcoord(float percent) => 0.9f + 0.04f * percent;

    private void drawSprite2(
      string textureDict,
      string textureName,
      float screenX,
      float screenY,
      float width,
      float height,
      int r,
      int g,
      int b,
      int alpha)
    {
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) textureDict, (InputArgument) 0);
      if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) textureDict))
        return;
      Function.Call(Hash._0xE7FFAE5EBF23D890, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) screenX, (InputArgument) screenY, (InputArgument) width, (InputArgument) height, (InputArgument) 0, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha, (InputArgument) 0);
    }

    private void drawText(string text, float x, float y, float scale, int r, int g, int b)
    {
      Function.Call(Hash._0x25FBB336DF1804CB, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0xBE6B23FFA53FB442, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) (int) byte.MaxValue);
      Function.Call(Hash._0x07C837F9A01C34C9, (InputArgument) 0.0f, (InputArgument) scale);
      Function.Call(Hash._0xCD015E5BB0D96A57, (InputArgument) x, (InputArgument) y, (InputArgument) 0.1);
    }

    public void DrawStockBarNoLines(
      string Name,
      float X,
      float Y,
      float CrntValue,
      float MaxValue)
    {
      this.drawSprite2("timerbars", "all_black_bg", X, Y, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.drawSprite2("timerbars", "all_black_bg", X - 0.1f, Y, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.drawSprite2("timerbars", "damagebarfill_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, 0);
      this.drawSprite2("timerbars", "damagebarfill_128", this.progressxcoord(CrntValue / MaxValue), Y, this.progresswidth(CrntValue / MaxValue), 0.03f, 150, 150, 150, (int) byte.MaxValue);
      this.drawText(Name, X - 0.1f, Y - 0.016f, 0.3f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    }

    public void OnTick()
    {
      if ((Entity) this.ChairProp != (Entity) null)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) < 2.0)
        {
          if (this.IsSittinginCeoSeat)
          {
            if ((Game.IsControlJustPressed(2, GTA.Control.FrontendPauseAlternate) || Game.IsControlJustPressed(2, GTA.Control.PhoneCancel)) && this.MissionsmainMenu.Visible)
            {
              Prop chairProp = this.ChairProp;
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_exit", (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num, (InputArgument) "computer_exit_chair", (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            }
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
              if (!this.MissionsmainMenu.Visible)
              {
                Prop chairProp = this.ChairProp;
                int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(100);
                this.MissionsmainMenu.Visible = !this.MissionsmainMenu.Visible;
              }
            }
            if (Game.IsControlJustPressed(2, GTA.Control.Cover))
            {
              this.MissionsMenuPool.CloseAllMenus();
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ChairProp.Position.X, (InputArgument) this.ChairProp.Position.Y, (InputArgument) this.ChairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ChairProp.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "exit", (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ChairProp, (InputArgument) num, (InputArgument) "exit_chair", (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(4000);
              Game.Player.Character.Task.ClearAll();
              Game.Player.Character.Position = this.ChairProp.GetOffsetInWorldCoords(new Vector3(-1f, 0.0f, 0.0f));
              this.IsSittinginCeoSeat = false;
            }
          }
          else if (!this.IsSittinginCeoSeat && Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            Script.Wait(100);
            string str = "anim@amb@office@boss@male@";
            VehicleWarehouse.LoadDict("anim@amb@office@boss@male@");
            if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) str))
            {
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ChairProp.Position.X, (InputArgument) this.ChairProp.Position.Y, (InputArgument) this.ChairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ChairProp.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "enter", (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ChairProp, (InputArgument) num, (InputArgument) "enter_chair", (InputArgument) VehicleWarehouse.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(5000);
              this.IsSittinginCeoSeat = true;
            }
          }
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) < 2.0)
        {
          if (this.IsSittinginCeoSeat)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open Menu, Press ~INPUT_COVER~ to Exit");
          if (!this.IsSittinginCeoSeat)
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to sit on CEO chair to access Menu");
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) > 4.0 && this.IsSittinginCeoSeat)
        {
          this.MissionsMenuPool.CloseAllMenus();
          this.IsSittinginCeoSeat = false;
          Game.Player.Character.FreezePosition = true;
          Game.FadeScreenOut(500);
          Script.Wait(500);
          Game.Player.Character.Position = this.ChairPos;
          Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
          Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
          Game.Player.Character.Task.ClearAnimation("anim@amb@office@laptops@male@var_c@base@", "base");
          Game.Player.Character.FreezePosition = false;
          Script.Wait(500);
          Game.FadeScreenIn(500);
        }
      }
      if (this.GLmodMenuPool != null && this.GLmodMenuPool.IsAnyMenuOpen())
        this.GLmodMenuPool.ProcessMenus();
      if (this.IsInInterior)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
          this.GLmainMenu.Visible = !this.GLmainMenu.Visible;
        if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 3.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ open gun locker");
        if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 40.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.GunLockerMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 1f), this.mainColor);
      }
      if (!this.modMenuPool.IsAnyMenuOpen() && !this.modMenuPool2.IsAnyMenuOpen() && (!this.modMenuPool3.IsAnyMenuOpen() && this.AwaitingClose))
      {
        this.CreateCars("GarageA");
        this.AwaitingClose = false;
      }
      this.OnKeyDown();
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2399.7f, 718.1f, 221.4f)) < 2.0 && Game.Player.Character.Alpha == 15)
      {
        Script.Wait(600);
        this.MainModDestroy();
        this.MainModRefresh();
      }
      if (this.VehicleWarehouseBought == 1)
      {
        if (this.Missionnum != 412)
        {
          if (this.SourcingCheckingforDamage)
          {
            if (this.NewVehicleSourcing && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null && Game.Player.Character.CurrentVehicle.DisplayName == this.SourcedVehicle)
              this.Vehicletoget = Game.Player.Character.CurrentVehicle;
            if ((Entity) this.Vehicletoget != (Entity) null && this.Vehicletoget.IsDamaged)
            {
              this.SourcingCheckingforDamage = false;
              UI.Notify(this.GetHostName() + " Be Carefull the Vehice is already damaged ");
            }
          }
          if (this.foundvehicleyet && !this.NewVehicleSourcing)
          {
            this.Vehicleloc = this.Vehicletoget.Position;
            if (this.VehicleMarker != (Blip) null)
              this.VehicleMarker.Position = this.Vehicletoget.Position;
            if (this.Vehicletoget.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && this.foundvehicleyet)
            {
              this.foundvehicleyet = true;
              this.Vehicletoget.IsDriveable = true;
              UI.Notify(this.GetHostName() + " Boss that is the car we need, bring it back to the vehicle ~b~Vehicle Warehouse~w~ to sell it");
              this.foundvehicleyet = false;
              this.hasgotvehicle = true;
            }
          }
          if (this.foundvehicleyet && this.NewVehicleSourcing && ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && Game.Player.Character.CurrentVehicle.DisplayName == this.SourcedVehicle))
          {
            this.Vehicletoget = Game.Player.Character.CurrentVehicle;
            if (this.Vehicletoget.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && this.foundvehicleyet)
            {
              this.foundvehicleyet = true;
              this.Vehicletoget.IsDriveable = true;
              UI.Notify(this.GetHostName() + " Boss that is the car we need, bring it back to the vehicle ~b~Vehicle Warehouse~w~ to sell it");
              this.foundvehicleyet = false;
              this.hasgotvehicle = true;
            }
          }
          if ((Entity) this.Vehicletoget != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 10.0 && (this.hasgotvehicle && !this.NewVehicleSourcing) && !this.Vehicletoget.IsDead)
          {
            if (this.SourcingCheckingforDamage)
              UI.Notify("Congradulations the vehicle is undamaged");
            this.Missionnum = 0;
            Game.FadeScreenOut(300);
            Script.Wait(300);
            this.VehicleMarker.Remove();
            this.Vehicletoget = (Vehicle) null;
            this.Vehicletoget = (Vehicle) null;
            this.hasgotvehicle = false;
            Script.Wait(300);
            Game.FadeScreenIn(300);
            this.Missionnum = 0;
            UI.Notify(this.GetHostName() + " Ok store the vehicle away and you can either ~b~ Keep~w~ or ~b~ Sell~w~ the car");
          }
          if (this.SourcedVehicle != null && (double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 10.0 && (this.hasgotvehicle && this.NewVehicleSourcing))
          {
            if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && Game.Player.Character.CurrentVehicle.DisplayName == this.SourcedVehicle)
              this.Vehicletoget = Game.Player.Character.CurrentVehicle;
            if ((Entity) this.Vehicletoget != (Entity) null && !this.Vehicletoget.IsDead)
            {
              if (this.SourcingCheckingforDamage)
                UI.Notify("Congradulations the vehicle is undamaged");
              this.Missionnum = 0;
              Game.FadeScreenOut(300);
              Script.Wait(300);
              this.Vehicletoget = (Vehicle) null;
              this.hasgotvehicle = false;
              this.SourcedVehicle = (string) null;
              this.NewVehicleSourcing = false;
              Script.Wait(300);
              Game.FadeScreenIn(300);
              UI.Notify(this.GetHostName() + " Ok store the vehicle away and you can either ~b~ Keep~w~ or ~b~ Sell~w~ the car");
            }
          }
        }
        if (this.Missionnum == 412 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          if (Game.Player.Character.CurrentVehicle.ClassType == this.VClass)
          {
            this.Vehicletoget = Game.Player.Character.CurrentVehicle;
            if (this.Vehicletoget.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && this.foundvehicleyet)
            {
              this.foundvehicleyet = true;
              this.Vehicletoget.IsDriveable = true;
              UI.Notify(this.GetHostName() + " Boss that is the car we need, bring it back to the vehicle ~b~Vehicle Warehouse~w~ to sell it");
              this.foundvehicleyet = false;
              this.hasgotvehicle = true;
            }
          }
          if (Game.Player.Character.CurrentVehicle.ClassType != this.VClass)
          {
            this.Vehicletoget = (Vehicle) null;
            this.foundvehicleyet = false;
          }
          if ((Entity) this.Vehicletoget != (Entity) null && (double) World.GetDistance(this.Vehicletoget.Position, this.WherehouseMarker) < 10.0 && (this.hasgotvehicle && !this.Vehicletoget.IsDead))
          {
            if (this.SourcingCheckingforDamage)
              UI.Notify("Congradulations the vehicle is undamaged");
            this.Missionnum = 0;
            Game.FadeScreenOut(300);
            Script.Wait(300);
            this.hasgotvehicle = false;
            Script.Wait(300);
            Game.FadeScreenIn(300);
            this.Missionnum = 0;
            UI.Notify(this.GetHostName() + " Ok store the vehicle away and you can either ~b~ Keep~w~ or ~b~ Sell~w~ the car");
            this.Vehicletoget = (Vehicle) null;
            this.Vehicletoget = (Vehicle) null;
          }
        }
        if (this.MissionsMenuPool != null && this.MissionsMenuPool.IsAnyMenuOpen())
          this.MissionsMenuPool.ProcessMenus();
        if (this.MissionSetup)
        {
          if (this.mission == 3)
          {
            if ((Entity) this.Sam1 != (Entity) null && this.Sam1.IsAlive)
            {
              if ((double) World.GetDistance(this.Sam1.Position, this.PointA) < 20.0)
                this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.PointB, 20f, 140f);
              if ((double) World.GetDistance(this.Sam1.Position, this.PointB) < 20.0)
                this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.PointC, 20f, 140f);
              if ((double) World.GetDistance(this.Sam1.Position, this.PointC) < 20.0)
                this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.PointA, 20f, 140f);
            }
            if ((Entity) this.Sam2 != (Entity) null && this.Sam2.IsAlive)
            {
              if ((double) World.GetDistance(this.Sam2.Position, this.PointA) < 20.0)
                this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.PointB, 20f, 140f);
              if ((double) World.GetDistance(this.Sam2.Position, this.PointB) < 20.0)
                this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.PointC, 20f, 140f);
              if ((double) World.GetDistance(this.Sam2.Position, this.PointC) < 20.0)
                this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.PointA, 20f, 140f);
            }
            if ((Entity) this.Sam3 != (Entity) null && this.Sam3.IsAlive)
            {
              if ((double) World.GetDistance(this.Sam3.Position, this.PointA) < 20.0)
                this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.PointB, 20f, 140f);
              if ((double) World.GetDistance(this.Sam3.Position, this.PointB) < 20.0)
                this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.PointC, 20f, 140f);
              if ((double) World.GetDistance(this.Sam3.Position, this.PointC) < 20.0)
                this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.PointA, 20f, 140f);
            }
            if (!this.Sam1.IsAlive)
            {
              if (this.Sam1blip != (Blip) null)
                this.Sam1blip.Remove();
            }
            else
              this.Sam1blip.Position = this.Sam1.Position;
            if (!this.Sam2.IsAlive)
            {
              if (this.Sam2blip != (Blip) null)
                this.Sam2blip.Remove();
            }
            else
              this.Sam2blip.Position = this.Sam2.Position;
            if (!this.Sam3.IsAlive)
            {
              if (this.Sam3blip != (Blip) null)
                this.Sam3blip.Remove();
            }
            else
              this.Sam3blip.Position = this.Sam3.Position;
            if (!this.Sam1.IsAlive && !this.Sam2.IsAlive && !this.Sam3.IsAlive)
            {
              Game.FadeScreenOut(500);
              Script.Wait(500);
              if ((Entity) this.Sam1 != (Entity) null)
                this.Sam1.Delete();
              if ((Entity) this.Sam2 != (Entity) null)
                this.Sam2.Delete();
              if ((Entity) this.Sam3 != (Entity) null)
                this.Sam3.Delete();
              if (this.Sam1blip != (Blip) null)
                this.Sam1blip.Remove();
              if (this.Sam2blip != (Blip) null)
                this.Sam2blip.Remove();
              if (this.Sam3blip != (Blip) null)
                this.Sam3blip.Remove();
              this.mission = 0;
              this.MissionSetup = false;
              Script.Wait(500);
              Game.FadeScreenIn(500);
            }
          }
          if (this.mission == 2 && (Entity) this.Sam1 != (Entity) null)
          {
            if (this.Sam1.IsAlive)
            {
              if (this.Sam1blip != (Blip) null)
                this.Sam1blip.Position = this.Sam1.Position;
              if (this.killedDriver)
              {
                if ((double) World.GetDistance(this.Sam1.Position, this.CurrentPoint) < 40.0)
                {
                  this.CurrentPoint = this.GetLocation();
                  this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
                  UI.Notify("tEstw");
                }
                if (!this.Sam1.GetPedOnSeat(VehicleSeat.Driver).IsAlive)
                  this.killedDriver = false;
              }
            }
            else if (!this.Sam1.IsAlive)
            {
              if (this.Sam1blip != (Blip) null)
                this.Sam1blip.Remove();
              this.mission = 0;
              this.MissionSetup = false;
              this.Sam1.Delete();
              Game.Player.Money += 225000;
              UI.Notify(this.GetHostName() + " Good job boss, on destroying that vehicle");
            }
          }
          if (this.mission == 1 && (Entity) this.Sam1 != (Entity) null)
          {
            if (this.Sam1.IsAlive)
            {
              if (this.Sam1blip != (Blip) null)
                this.Sam1blip.Position = this.Sam1.Position;
              if (this.killedDriver)
              {
                if ((double) World.GetDistance(this.Sam1.Position, this.CurrentPoint) < 40.0)
                {
                  this.CurrentPoint = this.GetLocation();
                  this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
                  UI.Notify("tEstw");
                }
                if (!this.Sam1.GetPedOnSeat(VehicleSeat.Driver).IsAlive)
                  this.killedDriver = false;
              }
              if (!this.killedDriver)
              {
                if (this.Sam1.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && this.NOTIFY)
                {
                  this.NOTIFY = false;
                  UI.Notify(this.GetHostName() + " Deliver this vehicle to the 'Combined Vehicle Warehouse' to complete the mission");
                }
                if ((double) World.GetDistance(this.Sam1.Position, this.DeliveryPoint) < 20.0)
                {
                  Game.Player.Character.Position = this.DeliveryPoint;
                  if (this.Sam1blip != (Blip) null)
                    this.Sam1blip.Remove();
                  this.mission = 0;
                  this.MissionSetup = false;
                  this.Sam1.Delete();
                  Game.Player.Money += 250000;
                  UI.Notify(this.GetHostName() + " Good job boss, on colecting that vehicle");
                }
              }
            }
            if (!this.Sam1.IsAlive)
            {
              if (this.Sam1blip != (Blip) null)
                this.Sam1blip.Remove();
              this.mission = 0;
              this.MissionSetup = false;
              this.Sam1.Delete();
              UI.Notify(this.GetHostName() + " Boss we needed that vehicle");
            }
          }
        }
      }
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      if (this.modMenuPool2 != null && this.modMenuPool2.IsAnyMenuOpen())
        this.modMenuPool2.ProcessMenus();
      if (this.modMenuPool3 != null && this.modMenuPool3.IsAnyMenuOpen())
        this.modMenuPool3.ProcessMenus();
      if (this.VehicleWarehouseBought != 1)
        return;
      if (!this.SupplyMissionOn && (double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 60.0)
        World.DrawMarker(MarkerType.VerticalCylinder, this.WherehouseMarker, Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.5f), this.mainColor);
      if (this.IsInInterior && (double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker) < 60.0)
        World.DrawMarker(MarkerType.VerticalCylinder, this.ExitMarker, Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.5f), this.mainColor);
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker) < 2.0 && this.IsInInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ Exit the Warehouse");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SleepPos) < 3.0 && this.IsInInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sleep");
      if (!this.SupplyMissionOn && (double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 5.0)
      {
        if (!this.CanNotSaveVehicle)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to save a vehicle into the Warehouse or Press ~INPUT_COVER~ to Enter Warehouse");
        if (this.CanNotSaveVehicle)
          this.DisplayHelpTextThisFrame("Please respray the vehicle first before storing this vehicle in the Warhouse");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.BuyMaker) < 2.0 && this.IsInInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase a special vehicle");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.RemoveMarker) < 2.0 && this.IsInInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sell/Buy a vehicle");
      if (this.IsInInterior)
        World.DrawMarker(MarkerType.VerticalCylinder, this.RemoveMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.6f), this.mainColor);
      if (this.IsInInterior)
        World.DrawMarker(MarkerType.VerticalCylinder, this.BuyMaker, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.6f), this.mainColor);
      if (this.SupplyMissionOn)
      {
        if (this.SupplyMissionID == 1)
        {
          if (!this.CreatedDealers && (double) World.GetDistance(Game.Player.Character.Position, this.AreaOffset) < 200.0)
          {
            this.CreatedDealers = true;
            Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Cognoscenti), this.AreaOffset, 0.0f);
            vehicle.Position = this.AreaOffset.Around(5f);
            this.SupplyMissionVehicles.Add(vehicle);
            Ped ped = World.CreatePed(this.RequestModel(PedHash.Business01AMM), vehicle.GetOffsetInWorldCoords(new Vector3(3f, 0.0f, 0.0f)));
            this.SupplyMissionPeds.Add(ped);
            this.DeliverPed = ped;
            this.SupplyMissionPeds.Add(World.CreatePed(this.RequestModel(PedHash.Business02AFM), vehicle.GetOffsetInWorldCoords(new Vector3(-3f, 1f, 0.0f))));
          }
          if ((Entity) this.DeliveryVehicle1 != (Entity) null && !this.DeliveredVehicle1 && !this.DeliveryVehicle1.IsAlive)
          {
            new MissionScreen().SetFail("Vehicle Warehouse : Sell vehicle", 0, "A Vehicle Was Destroyed");
            ++this.SS_VehiclesExportedFail;
            this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedFail", this.SS_VehiclesExportedFail);
            this.Config.Save();
            this.SupplyMissionStage = 0;
            this.SupplyMissionOn = false;
            this.SupplyMissionID = 0;
            Script.Wait(6500);
            Game.FadeScreenOut(2500);
            Script.Wait(1500);
            foreach (int smokeParticle in this.SmokeParticles)
              Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
            foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
            {
              if ((Entity) supplyMissionVehicle != (Entity) null)
                supplyMissionVehicle.Delete();
            }
            foreach (Prop supplyMissionProp in this.SupplyMissionProps)
            {
              if ((Entity) supplyMissionProp != (Entity) null)
                supplyMissionProp.Delete();
            }
            foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
            {
              if (supplyMissionBlip != (Blip) null)
                supplyMissionBlip.Remove();
            }
            foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
            {
              if ((Entity) supplyMissionPed != (Entity) null)
                supplyMissionPed.Delete();
            }
            if (this.SupplyMissionPeds.Count > 0)
              this.SupplyMissionPeds.Clear();
            if (this.SupplyMissionBlips.Count > 0)
              this.SupplyMissionBlips.Clear();
            if (this.SupplyMissionProps.Count > 0)
              this.SupplyMissionProps.Clear();
            if (this.SupplyMissionVehicles.Count > 0)
              this.SupplyMissionVehicles.Clear();
            Script.Wait(2500);
            Game.FadeScreenIn(2500);
          }
          if ((Entity) this.DeliveryVehicle2 != (Entity) null && !this.DeliveredVehicle2 && !this.DeliveryVehicle2.IsAlive)
          {
            new MissionScreen().SetFail("Vehicle Warehouse : Sell vehicle", 0, "A Vehicle Was Destroyed");
            ++this.SS_VehiclesExportedFail;
            this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedFail", this.SS_VehiclesExportedFail);
            this.Config.Save();
            this.SupplyMissionStage = 0;
            this.SupplyMissionOn = false;
            this.SupplyMissionID = 0;
            Script.Wait(6500);
            Game.FadeScreenOut(2500);
            Script.Wait(1500);
            foreach (int smokeParticle in this.SmokeParticles)
              Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
            foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
            {
              if ((Entity) supplyMissionVehicle != (Entity) null)
                supplyMissionVehicle.Delete();
            }
            foreach (Prop supplyMissionProp in this.SupplyMissionProps)
            {
              if ((Entity) supplyMissionProp != (Entity) null)
                supplyMissionProp.Delete();
            }
            foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
            {
              if (supplyMissionBlip != (Blip) null)
                supplyMissionBlip.Remove();
            }
            foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
            {
              if ((Entity) supplyMissionPed != (Entity) null)
                supplyMissionPed.Delete();
            }
            if (this.SupplyMissionPeds.Count > 0)
              this.SupplyMissionPeds.Clear();
            if (this.SupplyMissionBlips.Count > 0)
              this.SupplyMissionBlips.Clear();
            if (this.SupplyMissionProps.Count > 0)
              this.SupplyMissionProps.Clear();
            if (this.SupplyMissionVehicles.Count > 0)
              this.SupplyMissionVehicles.Clear();
            Script.Wait(2500);
            Game.FadeScreenIn(2500);
          }
          if ((Entity) this.DeliveryVehicle3 != (Entity) null && !this.DeliveredVehicle3 && !this.DeliveryVehicle3.IsAlive)
          {
            new MissionScreen().SetFail("Vehicle Warehouse : Sell vehicle", 0, "A Vehicle Was Destroyed");
            ++this.SS_VehiclesExportedFail;
            this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedFail", this.SS_VehiclesExportedFail);
            this.Config.Save();
            this.SupplyMissionStage = 0;
            this.SupplyMissionOn = false;
            this.SupplyMissionID = 0;
            Script.Wait(6500);
            Game.FadeScreenOut(2500);
            Script.Wait(1500);
            foreach (int smokeParticle in this.SmokeParticles)
              Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
            foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
            {
              if ((Entity) supplyMissionVehicle != (Entity) null)
                supplyMissionVehicle.Delete();
            }
            foreach (Prop supplyMissionProp in this.SupplyMissionProps)
            {
              if ((Entity) supplyMissionProp != (Entity) null)
                supplyMissionProp.Delete();
            }
            foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
            {
              if (supplyMissionBlip != (Blip) null)
                supplyMissionBlip.Remove();
            }
            foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
            {
              if ((Entity) supplyMissionPed != (Entity) null)
                supplyMissionPed.Delete();
            }
            if (this.SupplyMissionPeds.Count > 0)
              this.SupplyMissionPeds.Clear();
            if (this.SupplyMissionBlips.Count > 0)
              this.SupplyMissionBlips.Clear();
            if (this.SupplyMissionProps.Count > 0)
              this.SupplyMissionProps.Clear();
            if (this.SupplyMissionVehicles.Count > 0)
              this.SupplyMissionVehicles.Clear();
            Script.Wait(2500);
            Game.FadeScreenIn(2500);
          }
          if ((Entity) this.DeliveryVehicle4 != (Entity) null && !this.DeliveredVehicle4 && !this.DeliveryVehicle4.IsAlive)
          {
            new MissionScreen().SetFail("Vehicle Warehouse : Sell vehicle", 0, "A Vehicle Was Destroyed");
            ++this.SS_VehiclesExportedFail;
            this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedFail", this.SS_VehiclesExportedFail);
            this.Config.Save();
            this.SupplyMissionStage = 0;
            this.SupplyMissionOn = false;
            this.SupplyMissionID = 0;
            Script.Wait(6500);
            Game.FadeScreenOut(2500);
            Script.Wait(1500);
            foreach (int smokeParticle in this.SmokeParticles)
              Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
            foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
            {
              if ((Entity) supplyMissionVehicle != (Entity) null)
                supplyMissionVehicle.Delete();
            }
            foreach (Prop supplyMissionProp in this.SupplyMissionProps)
            {
              if ((Entity) supplyMissionProp != (Entity) null)
                supplyMissionProp.Delete();
            }
            foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
            {
              if (supplyMissionBlip != (Blip) null)
                supplyMissionBlip.Remove();
            }
            foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
            {
              if ((Entity) supplyMissionPed != (Entity) null)
                supplyMissionPed.Delete();
            }
            if (this.SupplyMissionPeds.Count > 0)
              this.SupplyMissionPeds.Clear();
            if (this.SupplyMissionBlips.Count > 0)
              this.SupplyMissionBlips.Clear();
            if (this.SupplyMissionProps.Count > 0)
              this.SupplyMissionProps.Clear();
            if (this.SupplyMissionVehicles.Count > 0)
              this.SupplyMissionVehicles.Clear();
            Script.Wait(2500);
            Game.FadeScreenIn(2500);
          }
          if (this.SupplyMissionStage == 1)
          {
            if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
            {
              if (this.IsInInterior)
                UI.ShowSubtitle("Exit the ~b~Vehicle Warehouse~w~");
              if (!this.IsInInterior)
                UI.ShowSubtitle("Enter a ~b~Cargo Delivery Vehicle~w~");
            }
            if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            {
              Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
              if ((Entity) currentVehicle != (Entity) this.DeliveryVehicle1 && (Entity) currentVehicle != (Entity) this.DeliveryVehicle2 && ((Entity) currentVehicle != (Entity) this.DeliveryVehicle3 && (Entity) currentVehicle != (Entity) this.DeliveryVehicle4))
                UI.ShowSubtitle("Enter a ~b~Cargo Delivery Vehicle~w~");
              if ((Entity) this.DeliveryVehicle1 != (Entity) null)
              {
                if (this.Deliveries == 1 && this.DeliveredtoLoc1)
                {
                  Vehicle deliveryVehicle1 = this.DeliveryVehicle1;
                  MissionScreen missionScreen = new MissionScreen();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot1 + ".ini");
                  int num1 = 0;
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle1.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num2 = 0;
                  if (deliveryVehicle1.GetMod(VehicleMod.Livery) >= 1)
                    num2 += 10000;
                  if (deliveryVehicle1.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 3)
                      num2 += 15500;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle1.GetMod(VehicleMod.Roof) == -1)
                    num2 += 35000;
                  float num3 = (float) (((double) this.DeliveryVehicle1.Health + (double) this.DeliveryVehicle1.BodyHealth) / 2000.0);
                  this.TotalBonus += (float) num2;
                  this.TotalPay += (float) (int) ((double) num1 * (double) num3);
                  Game.Player.Money += (int) this.TotalBonus;
                  Game.Player.Money += (int) this.TotalPay;
                  this.SS_VehicleWarehouseTotalEarnings += (int) this.TotalPay;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehicleWarehouseTotalEarnings", this.SS_VehicleWarehouseTotalEarnings);
                  this.Config.Save();
                  this.SC.SaveName();
                  this.DeliveringVehicle = false;
                  this.VehicleToDeliver = (Vehicle) null;
                  this.SS_VehicleWarehouseTotalEarnings += (int) this.TotalPay;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehicleWarehouseTotalEarnings", this.SS_VehicleWarehouseTotalEarnings);
                  this.Config.Save();
                  ++this.SS_VehiclesExportedSuccess;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedSuccess", this.SS_VehiclesExportedSuccess);
                  this.Config.Save();
                  int Payout = (int) ((double) num1 * (double) num3);
                  int totalBonus = (int) this.TotalBonus;
                  double num4 = (double) num3;
                  missionScreen.SetPass2("Vehicle Warehouse : Sell vehicle", Payout, totalBonus, (float) num4, "");
                  Script.Wait(6500);
                  Game.FadeScreenOut(2500);
                  Script.Wait(1500);
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
                  {
                    if ((Entity) supplyMissionVehicle != (Entity) null)
                      supplyMissionVehicle.Delete();
                  }
                  foreach (Prop supplyMissionProp in this.SupplyMissionProps)
                  {
                    if ((Entity) supplyMissionProp != (Entity) null)
                      supplyMissionProp.Delete();
                  }
                  foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                  {
                    if (supplyMissionBlip != (Blip) null)
                      supplyMissionBlip.Remove();
                  }
                  foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                  {
                    if ((Entity) supplyMissionPed != (Entity) null)
                      supplyMissionPed.Delete();
                  }
                  if (this.SupplyMissionPeds.Count > 0)
                    this.SupplyMissionPeds.Clear();
                  if (this.SupplyMissionBlips.Count > 0)
                    this.SupplyMissionBlips.Clear();
                  if (this.SupplyMissionProps.Count > 0)
                    this.SupplyMissionProps.Clear();
                  if (this.SupplyMissionVehicles.Count > 0)
                    this.SupplyMissionVehicles.Clear();
                  this.SupplyMissionStage = 0;
                  this.SupplyMissionOn = false;
                  this.SupplyMissionID = 0;
                  Script.Wait(2500);
                  Game.FadeScreenIn(2500);
                }
                if ((Entity) currentVehicle == (Entity) this.DeliveryVehicle1)
                {
                  this.DrawStockBarNoLines("DAMAGE            ", 0.89f, 0.94f, (float) (2000.0 - ((double) currentVehicle.Health + (double) currentVehicle.BodyHealth)), 2000f);
                  UI.ShowSubtitle("Deliver the " + currentVehicle.FriendlyName + " to the ~y~buyer~w~");
                }
                if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc1)
                {
                  this.DeliveredVehicle1 = true;
                  if (this.DeliveryVehicle1.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle1.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc1 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle1, true);
                  this.NearLoc1 = false;
                }
              }
              if ((Entity) this.DeliveryVehicle2 != (Entity) null)
              {
                if (this.Deliveries == 2 && this.DeliveredtoLoc1 && this.DeliveredtoLoc2)
                {
                  int num1 = 0;
                  MissionScreen missionScreen = new MissionScreen();
                  Vehicle deliveryVehicle1 = this.DeliveryVehicle1;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot1 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle1.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num2 = 0;
                  if (deliveryVehicle1.GetMod(VehicleMod.Livery) >= 1)
                    num2 += 10000;
                  if (deliveryVehicle1.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 3)
                      num2 += 15500;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle1.GetMod(VehicleMod.Roof) == -1)
                    num2 += 35000;
                  this.TotalBonus += (float) num2;
                  this.TotalPay += (float) num1;
                  Vehicle deliveryVehicle2 = this.DeliveryVehicle2;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot2 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle2.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num3 = 0;
                  if (deliveryVehicle2.GetMod(VehicleMod.Livery) >= 1)
                    num3 += 10000;
                  if (deliveryVehicle2.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 3)
                      num3 += 15500;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle2.GetMod(VehicleMod.Roof) == -1)
                    num3 += 35000;
                  this.TotalBonus += (float) num3;
                  this.TotalPay += (float) num1;
                  float num4 = (float) (((double) this.DeliveryVehicle1.Health + (double) this.DeliveryVehicle1.BodyHealth + ((double) this.DeliveryVehicle2.Health + (double) this.DeliveryVehicle2.BodyHealth)) / 4000.0);
                  this.TotalPay = (float) (int) ((double) this.TotalPay * (double) num4);
                  Game.Player.Money += (int) this.TotalBonus;
                  Game.Player.Money += (int) this.TotalPay;
                  this.SS_VehicleWarehouseTotalEarnings += (int) this.TotalPay;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehicleWarehouseTotalEarnings", this.SS_VehicleWarehouseTotalEarnings);
                  this.Config.Save();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot1 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot2 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.DeliveringVehicle = false;
                  this.VehicleToDeliver = (Vehicle) null;
                  ++this.SS_VehiclesExportedSuccess;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedSuccess", this.SS_VehiclesExportedSuccess);
                  this.Config.Save();
                  int Payout = (int) ((double) num1 * (double) num4);
                  int totalBonus = (int) this.TotalBonus;
                  double num5 = (double) num4;
                  missionScreen.SetPass2("Vehicle Warehouse : Sell vehicle", Payout, totalBonus, (float) num5, "");
                  Script.Wait(6500);
                  Game.FadeScreenOut(2500);
                  Script.Wait(1500);
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
                  {
                    if ((Entity) supplyMissionVehicle != (Entity) null)
                      supplyMissionVehicle.Delete();
                  }
                  foreach (Prop supplyMissionProp in this.SupplyMissionProps)
                  {
                    if ((Entity) supplyMissionProp != (Entity) null)
                      supplyMissionProp.Delete();
                  }
                  foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                  {
                    if (supplyMissionBlip != (Blip) null)
                      supplyMissionBlip.Remove();
                  }
                  foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                  {
                    if ((Entity) supplyMissionPed != (Entity) null)
                      supplyMissionPed.Delete();
                  }
                  if (this.SupplyMissionPeds.Count > 0)
                    this.SupplyMissionPeds.Clear();
                  if (this.SupplyMissionBlips.Count > 0)
                    this.SupplyMissionBlips.Clear();
                  if (this.SupplyMissionProps.Count > 0)
                    this.SupplyMissionProps.Clear();
                  if (this.SupplyMissionVehicles.Count > 0)
                    this.SupplyMissionVehicles.Clear();
                  this.SupplyMissionStage = 0;
                  this.SupplyMissionOn = false;
                  this.SupplyMissionID = 0;
                  Script.Wait(2500);
                  Game.FadeScreenIn(2500);
                }
                if ((Entity) currentVehicle == (Entity) this.DeliveryVehicle2)
                {
                  this.DrawStockBarNoLines("DAMAGE            ", 0.89f, 0.94f, (float) (2000.0 - ((double) currentVehicle.Health + (double) currentVehicle.BodyHealth)), 2000f);
                  UI.ShowSubtitle("Deliver the " + currentVehicle.FriendlyName + " to the ~y~buyer~w~");
                }
                if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc1)
                {
                  this.DeliveredVehicle1 = true;
                  if (this.DeliveryVehicle1.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle1.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc1 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle1, true);
                  this.NearLoc1 = false;
                }
                if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc2)
                {
                  this.DeliveredVehicle2 = true;
                  if (this.DeliveryVehicle2.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle2.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc2 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle2, true);
                  this.NearLoc2 = false;
                }
              }
              if ((Entity) this.DeliveryVehicle3 != (Entity) null)
              {
                if (this.Deliveries == 3 && this.DeliveredtoLoc1 && (this.DeliveredtoLoc2 && this.DeliveredtoLoc3))
                {
                  int num1 = 0;
                  MissionScreen missionScreen = new MissionScreen();
                  Vehicle deliveryVehicle1 = this.DeliveryVehicle1;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot1 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle1.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num2 = 0;
                  if (deliveryVehicle1.GetMod(VehicleMod.Livery) >= 1)
                    num2 += 10000;
                  if (deliveryVehicle1.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 3)
                      num2 += 15500;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle1.GetMod(VehicleMod.Roof) == -1)
                    num2 += 35000;
                  this.TotalBonus += (float) num2;
                  Vehicle deliveryVehicle2 = this.DeliveryVehicle2;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot2 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle2.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num3 = 0;
                  if (deliveryVehicle2.GetMod(VehicleMod.Livery) >= 1)
                    num3 += 10000;
                  if (deliveryVehicle2.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 3)
                      num3 += 15500;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle2.GetMod(VehicleMod.Roof) == -1)
                    num3 += 35000;
                  this.TotalBonus += (float) num3;
                  this.TotalPay += (float) num1;
                  Vehicle deliveryVehicle3 = this.DeliveryVehicle3;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot3 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle3.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num4 = 0;
                  if (deliveryVehicle3.GetMod(VehicleMod.Livery) >= 1)
                    num4 += 10000;
                  if (deliveryVehicle3.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle3.GetMod(VehicleMod.Engine) == 1)
                      num4 += 5000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Engine) == 2)
                      num4 += 10000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Engine) == 3)
                      num4 += 15000;
                  }
                  if (deliveryVehicle3.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle3.GetMod(VehicleMod.Transmission) == 1)
                      num4 += 5000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Transmission) == 2)
                      num4 += 10000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Transmission) == 3)
                      num4 += 15000;
                  }
                  if (deliveryVehicle3.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle3.GetMod(VehicleMod.Armor) == 1)
                      num4 += 5000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Armor) == 2)
                      num4 += 10000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Armor) == 3)
                      num4 += 15000;
                  }
                  if (deliveryVehicle3.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle3.GetMod(VehicleMod.Brakes) == 1)
                      num4 += 5000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Brakes) == 2)
                      num4 += 10000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Brakes) == 3)
                      num4 += 15500;
                  }
                  if (deliveryVehicle3.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle3.GetMod(VehicleMod.Roof) == -1)
                    num4 += 35000;
                  this.TotalBonus += (float) num4;
                  this.TotalPay += (float) num1;
                  float num5 = (float) (((double) this.DeliveryVehicle1.Health + (double) this.DeliveryVehicle1.BodyHealth + ((double) this.DeliveryVehicle2.Health + (double) this.DeliveryVehicle2.BodyHealth) + ((double) this.DeliveryVehicle3.Health + (double) this.DeliveryVehicle3.BodyHealth)) / 6000.0);
                  this.TotalPay = (float) (int) ((double) this.TotalPay * (double) num5);
                  Game.Player.Money += (int) this.TotalBonus;
                  Game.Player.Money += (int) this.TotalPay;
                  this.SS_VehicleWarehouseTotalEarnings += (int) this.TotalPay;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehicleWarehouseTotalEarnings", this.SS_VehicleWarehouseTotalEarnings);
                  this.Config.Save();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot1 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot2 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot3 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.DeliveringVehicle = false;
                  this.VehicleToDeliver = (Vehicle) null;
                  ++this.SS_VehiclesExportedSuccess;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedSuccess", this.SS_VehiclesExportedSuccess);
                  this.Config.Save();
                  int Payout = (int) ((double) num1 * (double) num5);
                  int totalBonus = (int) this.TotalBonus;
                  double num6 = (double) num5;
                  missionScreen.SetPass2("Vehicle Warehouse : Sell vehicle", Payout, totalBonus, (float) num6, "");
                  Script.Wait(6500);
                  Game.FadeScreenOut(2500);
                  Script.Wait(1500);
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
                  {
                    if ((Entity) supplyMissionVehicle != (Entity) null)
                      supplyMissionVehicle.Delete();
                  }
                  foreach (Prop supplyMissionProp in this.SupplyMissionProps)
                  {
                    if ((Entity) supplyMissionProp != (Entity) null)
                      supplyMissionProp.Delete();
                  }
                  foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                  {
                    if (supplyMissionBlip != (Blip) null)
                      supplyMissionBlip.Remove();
                  }
                  foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                  {
                    if ((Entity) supplyMissionPed != (Entity) null)
                      supplyMissionPed.Delete();
                  }
                  if (this.SupplyMissionPeds.Count > 0)
                    this.SupplyMissionPeds.Clear();
                  if (this.SupplyMissionBlips.Count > 0)
                    this.SupplyMissionBlips.Clear();
                  if (this.SupplyMissionProps.Count > 0)
                    this.SupplyMissionProps.Clear();
                  if (this.SupplyMissionVehicles.Count > 0)
                    this.SupplyMissionVehicles.Clear();
                  this.SupplyMissionStage = 0;
                  this.SupplyMissionOn = false;
                  this.SupplyMissionID = 0;
                  Script.Wait(2500);
                  Game.FadeScreenIn(2500);
                }
                if ((Entity) currentVehicle == (Entity) this.DeliveryVehicle3)
                {
                  this.DrawStockBarNoLines("DAMAGE            ", 0.89f, 0.94f, (float) (2000.0 - ((double) currentVehicle.Health + (double) currentVehicle.BodyHealth)), 2000f);
                  UI.ShowSubtitle("Deliver the " + currentVehicle.FriendlyName + " to the ~y~buyer~w~");
                }
                if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc1)
                {
                  this.DeliveredVehicle1 = true;
                  if (this.DeliveryVehicle1.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle1.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc1 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle1, true);
                  this.NearLoc1 = false;
                }
                if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc2)
                {
                  this.DeliveredVehicle2 = true;
                  if (this.DeliveryVehicle2.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle2.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc2 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle2, true);
                  this.NearLoc2 = false;
                }
                if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc3)
                {
                  this.DeliveredVehicle3 = true;
                  if (this.DeliveryVehicle3.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle3.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc3 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle3, true);
                  this.NearLoc3 = false;
                }
              }
              if ((Entity) this.DeliveryVehicle4 != (Entity) null)
              {
                if (this.Deliveries == 4 && this.DeliveredtoLoc1 && (this.DeliveredtoLoc2 && this.DeliveredtoLoc3) && this.DeliveredtoLoc4)
                {
                  int num1 = 0;
                  MissionScreen missionScreen = new MissionScreen();
                  Vehicle deliveryVehicle1 = this.DeliveryVehicle1;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot1 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle1.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num2 = 0;
                  if (deliveryVehicle1.GetMod(VehicleMod.Livery) >= 1)
                    num2 += 10000;
                  if (deliveryVehicle1.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Engine) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Transmission) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Armor) == 3)
                      num2 += 15000;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 1)
                      num2 += 5000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 2)
                      num2 += 10000;
                    if (deliveryVehicle1.GetMod(VehicleMod.Brakes) == 3)
                      num2 += 15500;
                  }
                  if (deliveryVehicle1.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle1.GetMod(VehicleMod.Roof) == -1)
                    num2 += 35000;
                  this.TotalBonus += (float) num2;
                  this.TotalPay += (float) num1;
                  Vehicle deliveryVehicle2 = this.DeliveryVehicle2;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot2 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle2.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num3 = 0;
                  if (deliveryVehicle2.GetMod(VehicleMod.Livery) >= 1)
                    num3 += 10000;
                  if (deliveryVehicle2.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Engine) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Transmission) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Armor) == 3)
                      num3 += 15000;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 1)
                      num3 += 5000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 2)
                      num3 += 10000;
                    if (deliveryVehicle2.GetMod(VehicleMod.Brakes) == 3)
                      num3 += 15500;
                  }
                  if (deliveryVehicle2.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle2.GetMod(VehicleMod.Roof) == -1)
                    num3 += 35000;
                  this.TotalBonus += (float) num3;
                  this.TotalPay += (float) num1;
                  Vehicle deliveryVehicle3 = this.DeliveryVehicle3;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot3 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle3.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num4 = 0;
                  if (deliveryVehicle3.GetMod(VehicleMod.Livery) >= 1)
                    num4 += 10000;
                  if (deliveryVehicle3.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle3.GetMod(VehicleMod.Engine) == 1)
                      num4 += 5000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Engine) == 2)
                      num4 += 10000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Engine) == 3)
                      num4 += 15000;
                  }
                  if (deliveryVehicle3.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle3.GetMod(VehicleMod.Transmission) == 1)
                      num4 += 5000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Transmission) == 2)
                      num4 += 10000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Transmission) == 3)
                      num4 += 15000;
                  }
                  if (deliveryVehicle3.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle3.GetMod(VehicleMod.Armor) == 1)
                      num4 += 5000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Armor) == 2)
                      num4 += 10000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Armor) == 3)
                      num4 += 15000;
                  }
                  if (deliveryVehicle3.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle3.GetMod(VehicleMod.Brakes) == 1)
                      num4 += 5000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Brakes) == 2)
                      num4 += 10000;
                    if (deliveryVehicle3.GetMod(VehicleMod.Brakes) == 3)
                      num4 += 15500;
                  }
                  if (deliveryVehicle3.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle3.GetMod(VehicleMod.Roof) == -1)
                    num4 += 35000;
                  this.TotalBonus += (float) num4;
                  Vehicle deliveryVehicle4 = this.DeliveryVehicle4;
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot4 + ".ini");
                  if (this.SC.VehicleName != "null")
                    num1 = (int) this.GetVehicleValue(deliveryVehicle4.DisplayName, 10);
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
                    UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
                    UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
                  if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
                    UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
                  int num5 = 0;
                  if (deliveryVehicle4.GetMod(VehicleMod.Livery) >= 1)
                    num5 += 10000;
                  if (deliveryVehicle4.GetMod(VehicleMod.Engine) > 0)
                  {
                    if (deliveryVehicle4.GetMod(VehicleMod.Engine) == 1)
                      num5 += 5000;
                    if (deliveryVehicle4.GetMod(VehicleMod.Engine) == 2)
                      num5 += 10000;
                    if (deliveryVehicle4.GetMod(VehicleMod.Engine) == 3)
                      num5 += 15000;
                  }
                  if (deliveryVehicle4.GetMod(VehicleMod.Transmission) > 0)
                  {
                    if (deliveryVehicle4.GetMod(VehicleMod.Transmission) == 1)
                      num5 += 5000;
                    if (deliveryVehicle4.GetMod(VehicleMod.Transmission) == 2)
                      num5 += 10000;
                    if (deliveryVehicle4.GetMod(VehicleMod.Transmission) == 3)
                      num5 += 15000;
                  }
                  if (deliveryVehicle4.GetMod(VehicleMod.Armor) > 0)
                  {
                    if (deliveryVehicle4.GetMod(VehicleMod.Armor) == 1)
                      num5 += 5000;
                    if (deliveryVehicle4.GetMod(VehicleMod.Armor) == 2)
                      num5 += 10000;
                    if (deliveryVehicle4.GetMod(VehicleMod.Armor) == 3)
                      num5 += 15000;
                  }
                  if (deliveryVehicle4.GetMod(VehicleMod.Brakes) > 0)
                  {
                    if (deliveryVehicle4.GetMod(VehicleMod.Brakes) == 1)
                      num5 += 5000;
                    if (deliveryVehicle4.GetMod(VehicleMod.Brakes) == 2)
                      num5 += 10000;
                    if (deliveryVehicle4.GetMod(VehicleMod.Brakes) == 3)
                      num5 += 15500;
                  }
                  if (deliveryVehicle4.GetMod(VehicleMod.Roof) == 1 || deliveryVehicle4.GetMod(VehicleMod.Roof) == -1)
                    num5 += 35000;
                  this.TotalBonus += (float) num5;
                  this.TotalPay += (float) num1;
                  float num6 = (float) (((double) this.DeliveryVehicle1.Health + (double) this.DeliveryVehicle1.BodyHealth + ((double) this.DeliveryVehicle2.Health + (double) this.DeliveryVehicle2.BodyHealth) + ((double) this.DeliveryVehicle3.Health + (double) this.DeliveryVehicle3.BodyHealth) + ((double) this.DeliveryVehicle4.Health + (double) this.DeliveryVehicle4.BodyHealth)) / 8000.0);
                  this.TotalPay = (float) (int) ((double) this.TotalPay * (double) num6);
                  Game.Player.Money += (int) this.TotalBonus;
                  Game.Player.Money += (int) this.TotalPay;
                  this.SS_VehicleWarehouseTotalEarnings += (int) this.TotalPay;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehicleWarehouseTotalEarnings", this.SS_VehicleWarehouseTotalEarnings);
                  this.Config.Save();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot1 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot2 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot3 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.SC.LoadIniFile(this.path + "GarageA//" + this.DeliverSlot4 + ".ini");
                  if (this.SC.VehicleName != "null")
                    this.SC.SaveName();
                  this.DeliveringVehicle = false;
                  this.VehicleToDeliver = (Vehicle) null;
                  ++this.SS_VehiclesExportedSuccess;
                  this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedSuccess", this.SS_VehiclesExportedSuccess);
                  this.Config.Save();
                  int Payout = (int) ((double) num1 * (double) num6);
                  int totalBonus = (int) this.TotalBonus;
                  double num7 = (double) num6;
                  missionScreen.SetPass2("Vehicle Warehouse : Sell vehicle", Payout, totalBonus, (float) num7, "");
                  Script.Wait(6500);
                  Game.FadeScreenOut(2500);
                  Script.Wait(1500);
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
                  {
                    if ((Entity) supplyMissionVehicle != (Entity) null)
                      supplyMissionVehicle.Delete();
                  }
                  foreach (Prop supplyMissionProp in this.SupplyMissionProps)
                  {
                    if ((Entity) supplyMissionProp != (Entity) null)
                      supplyMissionProp.Delete();
                  }
                  foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                  {
                    if (supplyMissionBlip != (Blip) null)
                      supplyMissionBlip.Remove();
                  }
                  foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                  {
                    if ((Entity) supplyMissionPed != (Entity) null)
                      supplyMissionPed.Delete();
                  }
                  if (this.SupplyMissionPeds.Count > 0)
                    this.SupplyMissionPeds.Clear();
                  if (this.SupplyMissionBlips.Count > 0)
                    this.SupplyMissionBlips.Clear();
                  if (this.SupplyMissionProps.Count > 0)
                    this.SupplyMissionProps.Clear();
                  if (this.SupplyMissionVehicles.Count > 0)
                    this.SupplyMissionVehicles.Clear();
                  this.SupplyMissionStage = 0;
                  this.SupplyMissionOn = false;
                  this.SupplyMissionID = 0;
                  Script.Wait(2500);
                  Game.FadeScreenIn(2500);
                }
                if ((Entity) currentVehicle == (Entity) this.DeliveryVehicle4)
                {
                  this.DrawStockBarNoLines("DAMAGE            ", 0.89f, 0.94f, (float) (2000.0 - ((double) currentVehicle.Health + (double) currentVehicle.BodyHealth)), 2000f);
                  UI.ShowSubtitle("Deliver the " + currentVehicle.FriendlyName + " to the ~y~buyer~w~");
                }
                if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc1)
                {
                  this.DeliveredVehicle1 = true;
                  if (this.DeliveryVehicle1.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle1.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc1 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle1, true);
                  this.NearLoc1 = false;
                }
                if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc2)
                {
                  this.DeliveredVehicle2 = true;
                  if (this.DeliveryVehicle2.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle2.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc2 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle2, true);
                  this.DeliveryVehicle2.MarkAsNoLongerNeeded();
                  this.NearLoc2 = false;
                }
                if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc3)
                {
                  this.DeliveredVehicle3 = true;
                  if (this.DeliveryVehicle3.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle3.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc3 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle3, true);
                  this.NearLoc3 = false;
                }
                if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset) < 5.0 && !this.DeliveredtoLoc4)
                {
                  this.DeliveredVehicle4 = true;
                  if (this.DeliveryVehicle4.CurrentBlip != (Blip) null)
                    this.DeliveryVehicle4.CurrentBlip.Remove();
                  if (this.DeliverLocBlip4 != (Blip) null)
                    this.DeliverLocBlip4.Remove();
                  foreach (int smokeParticle in this.SmokeParticles)
                    Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                  this.DeliveredtoLoc4 = true;
                  Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle4, true);
                  this.NearLoc4 = false;
                }
              }
            }
          }
        }
        if (this.SupplyMissionID == 2)
        {
          if (this.DeliveringVehicle && (Entity) this.VehicleToDeliver != (Entity) null && this.VehicleToDeliver.IsAlive)
          {
            Vector3 areaOffset = this.AreaOffset;
            if (this.DeliverLocBlip1 != (Blip) null)
              this.DeliverLocBlip1.ShowRoute = true;
            this.DrawStockBarNoLines("DAMAGE            ", 0.89f, 0.94f, (float) (2000.0 - ((double) this.VehicleToDeliver.Health + (double) this.VehicleToDeliver.BodyHealth)), 2000f);
            UI.ShowSubtitle("Deliver the " + this.VehicleToDeliver.FriendlyName + " to the ~y~buyer~w~");
            if ((double) World.GetDistance(Game.Player.Character.Position, areaOffset) < 60.0 && !this.DeliveredtoLoc1)
            {
              this.DeliveredtoLoc1 = true;
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Cognoscenti), this.AreaOffset, 0.0f);
              vehicle.Position = this.AreaOffset.Around(5f);
              this.SupplyMissionVehicles.Add(vehicle);
              Ped ped = World.CreatePed(this.RequestModel(PedHash.Business01AMM), vehicle.GetOffsetInWorldCoords(new Vector3(3f, 0.0f, 0.0f)));
              this.SupplyMissionPeds.Add(ped);
              this.DeliverPed = ped;
              this.SupplyMissionPeds.Add(World.CreatePed(this.RequestModel(PedHash.Business02AFM), vehicle.GetOffsetInWorldCoords(new Vector3(-3f, 1f, 0.0f))));
            }
          }
          if ((Entity) this.VehicleToDeliver != (Entity) null)
          {
            if (this.VehicleToDeliver.IsAlive && (double) World.GetDistance(Game.Player.Character.Position, this.AreaOffset) < 10.0 && (Entity) this.VehicleToDeliver != (Entity) null)
            {
              this.DeliveringVehicle = false;
              this.DeleteCarinSlot2(this.SlotToDelete, this.VehicleToDeliver);
              this.SlotToDelete = (string) null;
            }
            if ((Entity) this.VehicleToDeliver != (Entity) null && !this.VehicleToDeliver.IsAlive && (Entity) this.VehicleToDeliver != (Entity) null)
            {
              UI.Notify(this.GetHostName() + " Sorry boss, there is no pay for a destroyed vehicle");
              MissionScreen missionScreen = new MissionScreen();
              ++this.SS_VehiclesExportedFail;
              this.Config.SetValue<int>("VehicleWarehouses", "VehiclesExportedFail", this.SS_VehiclesExportedFail);
              this.Config.Save();
              missionScreen.SetFail("Vehicle Warehouse : Sell vehicle", 0, "The Vehicle Was Destroyed");
              Script.Wait(5000);
              Game.FadeScreenOut(2500);
              Script.Wait(2500);
              this.VehicleToDeliver.Delete();
              foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
              {
                if ((Entity) supplyMissionVehicle != (Entity) null)
                  supplyMissionVehicle.Delete();
              }
              if (this.SupplyMissionVehicles.Count > 0)
                this.SupplyMissionVehicles.Clear();
              foreach (Prop supplyMissionProp in this.SupplyMissionProps)
              {
                if ((Entity) supplyMissionProp != (Entity) null)
                  supplyMissionProp.Delete();
              }
              if (this.SupplyMissionProps.Count > 0)
                this.SupplyMissionProps.Clear();
              foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
              {
                if (supplyMissionBlip != (Blip) null)
                  supplyMissionBlip.Remove();
              }
              if (this.SupplyMissionBlips.Count > 0)
                this.SupplyMissionBlips.Clear();
              foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
              {
                if ((Entity) supplyMissionPed != (Entity) null)
                  supplyMissionPed.Delete();
              }
              if (this.SupplyMissionPeds.Count > 0)
                this.SupplyMissionPeds.Clear();
              foreach (Vehicle asellMissionVehicle in this.SourceASellMissionVehicles)
              {
                if ((Entity) asellMissionVehicle != (Entity) null)
                  asellMissionVehicle.Delete();
              }
              if (this.SourceASellMissionVehicles.Count > 0)
                this.SourceASellMissionVehicles.Clear();
              foreach (Prop asellMissionProp in this.SourceASellMissionProps)
              {
                if ((Entity) asellMissionProp != (Entity) null)
                  asellMissionProp.Delete();
              }
              if (this.SourceASellMissionProps.Count > 0)
                this.SourceASellMissionProps.Clear();
              foreach (Blip asellMissionBlip in this.SourceASellMissionBlips)
              {
                if (asellMissionBlip != (Blip) null)
                  asellMissionBlip.Remove();
              }
              if (this.SourceASellMissionBlips.Count > 0)
                this.SourceASellMissionBlips.Clear();
              foreach (Ped sourceAsellMissionPed in this.SourceASellMissionPeds)
              {
                if ((Entity) sourceAsellMissionPed != (Entity) null)
                  sourceAsellMissionPed.Delete();
              }
              if (this.SourceASellMissionPeds.Count > 0)
                this.SourceASellMissionPeds.Clear();
              Script.Wait(2500);
              Game.FadeScreenIn(500);
              this.DeliveringVehicle = false;
              this.GarageNum = "GarageA";
              this.SC.LoadIniFile(this.path + "GarageA//" + this.SlotToDelete + ".ini");
              UI.Notify(this.path + "GarageA//" + this.SlotToDelete + ".ini");
              this.SC.SaveName();
              this.SlotToDelete = (string) null;
            }
          }
        }
      }
      if (!this.IsInInterior || !((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
        return;
      Vehicle currentVehicle1 = Game.Player.Character.CurrentVehicle;
      if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle1)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle2)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle3)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle4)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle5)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle6)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle7)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle8)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle9)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle10)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle11)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle12)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle13 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle13)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle14 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle14)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle15 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle15)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle16 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle16)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle17 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle17)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle18 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle18)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle19 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle19)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle20 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle20)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle21 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle21)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle22 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle22)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle23 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle23)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle24 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle24)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle25 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle25)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle26 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle26)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle27 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle27)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle28 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle28)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle29 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle29)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle30 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle30)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle31 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle31)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle32 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle32)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle33 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle33)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle34 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle34)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Vehicle35 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle35)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle");
      if ((Entity) this.Ruiner2000 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Ruiner2000)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to Save Vehicle");
      if ((Entity) this.RampBuggy != (Entity) null && (Entity) currentVehicle1 == (Entity) this.RampBuggy)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to Save Vehicle");
      if ((Entity) this.Boxville != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Boxville)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to Save Vehicle");
      if ((Entity) this.TechnicalA != (Entity) null && (Entity) currentVehicle1 == (Entity) this.TechnicalA)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to Save Vehicle");
      if ((Entity) this.PhantomW != (Entity) null && (Entity) currentVehicle1 == (Entity) this.PhantomW)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to Save Vehicle");
      if ((Entity) this.Rvoltic != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Rvoltic)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to Save Vehicle");
      if ((Entity) this.BlazerAqua != (Entity) null && (Entity) currentVehicle1 == (Entity) this.BlazerAqua)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to Save Vehicle");
      if (!((Entity) this.Wastelander != (Entity) null) || !((Entity) currentVehicle1 == (Entity) this.BlazerAqua))
        return;
      this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to Save Vehicle");
    }

    public void LoadCarinToRealWorld(Vehicle V)
    {
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      currentVehicle.Position = this.WherehouseMarker;
      currentVehicle.Heading = this.WherehouseExitHeading;
      Game.Player.Character.SetIntoVehicle(currentVehicle, VehicleSeat.Driver);
      this.DestoryCars();
      currentVehicle.IsDriveable = true;
      this.SaveVehicle = currentVehicle;
      this.SaveVehicle.IsDriveable = true;
      this.SaveVehicle.Repair();
    }

    public void LoadCarinToRealWorld2(Vehicle V, string Slot)
    {
      this.SC.LoadIniFile(this.path + "GarageA//" + Slot + ".ini");
      V = World.CreateVehicle((GTA.Model) V.DisplayName, this.MenuMarker, 180f);
      this.SC.Load(V);
      V.IsDriveable = true;
      V.Position = this.MenuMarker;
      this.VehicleToDeliver = V;
      V = (Vehicle) null;
      this.VehicleToDeliver.Position = this.WherehouseMarker;
      this.VehicleToDeliver.Heading = this.WherehouseExitHeading;
      Game.Player.Character.SetIntoVehicle(this.VehicleToDeliver, VehicleSeat.Driver);
      this.DestoryCars();
      this.VehicleToDeliver.IsDriveable = true;
      this.SaveVehicle = this.VehicleToDeliver;
      this.SaveVehicle.IsDriveable = true;
      this.SaveVehicle.Repair();
    }

    private void OnKeyDown()
    {
      if (this.VehicleWarehouseBought != 1)
        return;
      if (this.IsInInterior && (double) World.GetDistance(Game.Player.Character.Position, this.SleepPos) < 2.0 && (this.IsInInterior && Game.IsControlJustPressed(2, GTA.Control.Context)))
      {
        Game.Player.Character.FreezePosition = true;
        Game.FadeScreenOut(500);
        Script.Wait(500);
        Function.Call(Hash._0xC8CA9670B9D83B3B, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0);
        Game.Player.WantedLevel = 0;
        Function.Call(Hash._0x8FE22675A5A45817, (InputArgument) Game.Player.Character);
        Function.Call(Hash._0x9C720776DAA43E7E, (InputArgument) Game.Player.Character);
        Game.Player.Character.Position = this.SleepPos;
        Game.Player.Character.Heading = 248.15f;
        Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
        Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
        Game.Player.Character.FreezePosition = false;
        Script.Wait(1500);
        Game.FadeScreenIn(500);
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && !this.SupplyMissionOn && ((double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 5.0 && !this.CanNotSaveVehicle))
        this.mainMenu.Visible = !this.mainMenu.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.RemoveMarker) < 2.0 && this.IsInInterior)
        this.mainMenu2.Visible = !this.mainMenu2.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.BuyMaker) < 2.0 && this.IsInInterior)
        this.mainMenu3.Visible = !this.mainMenu3.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        if ((Entity) currentVehicle == (Entity) this.Ruiner2000)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//RUINER2000.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved!");
        }
        if ((Entity) currentVehicle == (Entity) this.RampBuggy)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//RAMPBUGGY.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved!");
        }
        if ((Entity) currentVehicle == (Entity) this.Boxville)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//ARMOUREDBOXVILLE.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved!");
        }
        if ((Entity) currentVehicle == (Entity) this.TechnicalA)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//TECHNICALAAQUA.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved!");
        }
        if ((Entity) currentVehicle == (Entity) this.PhantomW)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//PHANTOMWEDGE.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved!");
        }
        if ((Entity) currentVehicle == (Entity) this.Rvoltic)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//ROCKETVOLTIC.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved!");
        }
        if ((Entity) currentVehicle == (Entity) this.BlazerAqua)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//BLAZERAQUA.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved!");
        }
        if ((Entity) currentVehicle == (Entity) this.Wastelander)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//WASTELANDER.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved!");
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
        {
          this.Vehicle1 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle1);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
        {
          this.Vehicle2 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle2);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
        {
          this.Vehicle3 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle3);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
        {
          this.Vehicle4 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle4);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
        {
          this.Vehicle5 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle5);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
        {
          this.Vehicle6 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle6);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
        {
          this.Vehicle7 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle7);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
        {
          this.Vehicle8 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle8);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
        {
          this.Vehicle9 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle9);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
        {
          this.Vehicle10 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle10);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle11)
        {
          this.Vehicle11 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle11);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle12)
        {
          this.Vehicle12 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle12);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle13 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle13)
        {
          this.Vehicle13 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle13);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle14 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle14)
        {
          this.Vehicle14 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle14);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle15 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle15)
        {
          this.Vehicle15 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle15);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle16 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle16)
        {
          this.Vehicle16 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle16);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle17 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle17)
        {
          this.Vehicle17 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle17);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle18 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle18)
        {
          this.Vehicle18 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle18);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle19 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle19)
        {
          this.Vehicle19 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle19);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle20 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle20)
        {
          this.Vehicle20 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle20);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Vehicle21 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle21)
        {
          this.Vehicle21 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle21);
        }
        if ((Entity) this.Vehicle22 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle22)
        {
          this.Vehicle22 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle22);
        }
        if ((Entity) this.Vehicle23 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle23)
        {
          this.Vehicle23 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle23);
        }
        if ((Entity) this.Vehicle24 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle24)
        {
          this.Vehicle24 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle24);
        }
        if ((Entity) this.Vehicle25 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle25)
        {
          this.Vehicle25 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle25);
        }
        if ((Entity) this.Vehicle26 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle26)
        {
          this.Vehicle26 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle26);
        }
        if ((Entity) this.Vehicle27 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle27)
        {
          this.Vehicle27 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle27);
        }
        if ((Entity) this.Vehicle28 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle28)
        {
          this.Vehicle28 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle28);
        }
        if ((Entity) this.Vehicle29 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle29)
        {
          this.Vehicle29 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle29);
        }
        if ((Entity) this.Vehicle30 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle30)
        {
          this.Vehicle30 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle30);
        }
        if ((Entity) this.Vehicle31 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle31)
        {
          this.Vehicle31 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle31);
        }
        if ((Entity) this.Vehicle32 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle32)
        {
          this.Vehicle32 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle32);
        }
        if ((Entity) this.Vehicle33 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle33)
        {
          this.Vehicle33 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle33);
        }
        if ((Entity) this.Vehicle34 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle34)
        {
          this.Vehicle34 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle34);
        }
        if ((Entity) this.Vehicle35 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle35)
        {
          this.Vehicle35 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle35);
        }
        if ((Entity) this.Ruiner2000 != (Entity) null && (Entity) currentVehicle == (Entity) this.Ruiner2000)
        {
          this.Ruiner2000 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Ruiner2000);
        }
        if ((Entity) this.RampBuggy != (Entity) null && (Entity) currentVehicle == (Entity) this.RampBuggy)
        {
          this.RampBuggy = (Vehicle) null;
          this.LoadCarinToRealWorld(this.RampBuggy);
        }
        if ((Entity) this.Boxville != (Entity) null && (Entity) currentVehicle == (Entity) this.Boxville)
        {
          this.Boxville = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Boxville);
        }
        if ((Entity) this.TechnicalA != (Entity) null && (Entity) currentVehicle == (Entity) this.TechnicalA)
        {
          this.TechnicalA = (Vehicle) null;
          this.LoadCarinToRealWorld(this.TechnicalA);
        }
        if ((Entity) this.PhantomW != (Entity) null && (Entity) currentVehicle == (Entity) this.PhantomW)
        {
          this.PhantomW = (Vehicle) null;
          this.LoadCarinToRealWorld(this.PhantomW);
        }
        if ((Entity) this.Rvoltic != (Entity) null && (Entity) currentVehicle == (Entity) this.Rvoltic)
        {
          this.Rvoltic = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Rvoltic);
        }
        if ((Entity) this.BlazerAqua != (Entity) null && (Entity) currentVehicle == (Entity) this.BlazerAqua)
        {
          this.BlazerAqua = (Vehicle) null;
          this.LoadCarinToRealWorld(this.BlazerAqua);
        }
        if ((Entity) this.Wastelander != (Entity) null && (Entity) currentVehicle == (Entity) this.Wastelander)
        {
          this.Wastelander = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Wastelander);
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Cover))
      {
        if (!this.IsInInterior)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 2.0)
          {
            this.IsInInterior = true;
            this.GarageNum = "GarageA";
            this.DestoryCars();
            if ((Entity) this.SaveVehicle != (Entity) null)
              this.SaveVehicle.Delete();
            Game.Player.Character.Position = this.ExitMarker;
            Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
            Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
            this.CreateCars("GarageA");
            foreach (Vector3 position in new List<Vector3>()
            {
              new Vector3(954.7f, -3018.3f, -37.88f),
              new Vector3(954.7f, -3023.6f, -37.88f),
              new Vector3(954.7f, -3028.65f, -37.88f),
              new Vector3(959.35f, -3035.9f, -37.88f),
              new Vector3(963.5f, -3036f, -37.88152f),
              new Vector3(967.7f, -3035.9f, -37.88f),
              new Vector3(971.85f, -3035.8f, -37.88f),
              new Vector3(975.95f, -3036.2f, -37.88152f),
              new Vector3(980.15f, -3036f, -37.88152f),
              new Vector3(993.15f, -3027.098f, -37.88f),
              new Vector3(998.5f, -3026.85f, -37.88152f),
              new Vector3(1004f, -3026.995f, -37.88152f),
              new Vector3(1009.25f, -3026.95f, -37.88152f),
              new Vector3(978.15f, -3009.6f, -40.65f),
              new Vector3(978.05f, -2994.05f, -40.65f)
            })
            {
              foreach (Prop nearbyProp in World.GetNearbyProps(position, 1f))
              {
                if ((Entity) nearbyProp != (Entity) null)
                  nearbyProp.Delete();
              }
            }
          }
        }
        else if (this.IsInInterior && (double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker) < 2.0)
        {
          this.IsInInterior = false;
          Script.Wait(300);
          this.DestoryCars();
          Game.Player.Character.Position = this.WherehouseMarker;
          if ((Entity) this.DeliveryVehicle2 != (Entity) null && !this.DeliveryVehicle2.IsOnAllWheels)
            this.DeliveryVehicle2.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -5f, 0.0f));
          if ((Entity) this.DeliveryVehicle3 != (Entity) null && !this.DeliveryVehicle3.IsOnAllWheels)
            this.DeliveryVehicle3.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(-5f, 0.0f, 0.0f));
          if ((Entity) this.DeliveryVehicle4 != (Entity) null && !this.DeliveryVehicle4.IsOnAllWheels)
            this.DeliveryVehicle4.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(-5f, 5f, 0.0f));
        }
      }
      Game.IsControlJustPressed(2, GTA.Control.Cover);
      if (!Game.IsControlJustPressed(2, GTA.Control.Cover) || !this.IsInInterior || (double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker2) >= 2.0)
        return;
      this.IsInInterior = false;
      Script.Wait(300);
      this.DestoryCars();
      Game.Player.Character.Position = this.MenuMarker;
    }

    public void DestoryCars()
    {
      if ((Entity) this.ChairProp != (Entity) null)
        this.ChairProp.Delete();
      if ((Entity) this.Vehicle1 != (Entity) null)
        this.Vehicle1.Delete();
      if ((Entity) this.Vehicle2 != (Entity) null)
        this.Vehicle2.Delete();
      if ((Entity) this.Vehicle3 != (Entity) null)
        this.Vehicle3.Delete();
      if ((Entity) this.Vehicle4 != (Entity) null)
        this.Vehicle4.Delete();
      if ((Entity) this.Vehicle5 != (Entity) null)
        this.Vehicle5.Delete();
      if ((Entity) this.Vehicle5 != (Entity) null)
        this.Vehicle5.Delete();
      if ((Entity) this.Vehicle6 != (Entity) null)
        this.Vehicle6.Delete();
      if ((Entity) this.Vehicle7 != (Entity) null)
        this.Vehicle7.Delete();
      if ((Entity) this.Vehicle8 != (Entity) null)
        this.Vehicle8.Delete();
      if ((Entity) this.Vehicle9 != (Entity) null)
        this.Vehicle9.Delete();
      if ((Entity) this.Vehicle10 != (Entity) null)
        this.Vehicle10.Delete();
      if ((Entity) this.Vehicle11 != (Entity) null)
        this.Vehicle11.Delete();
      if ((Entity) this.Vehicle12 != (Entity) null)
        this.Vehicle12.Delete();
      if ((Entity) this.Vehicle13 != (Entity) null)
        this.Vehicle13.Delete();
      if ((Entity) this.Vehicle14 != (Entity) null)
        this.Vehicle14.Delete();
      if ((Entity) this.Vehicle15 != (Entity) null)
        this.Vehicle15.Delete();
      if ((Entity) this.Vehicle16 != (Entity) null)
        this.Vehicle16.Delete();
      if ((Entity) this.Vehicle17 != (Entity) null)
        this.Vehicle17.Delete();
      if ((Entity) this.Vehicle18 != (Entity) null)
        this.Vehicle18.Delete();
      if ((Entity) this.Vehicle19 != (Entity) null)
        this.Vehicle19.Delete();
      if ((Entity) this.Vehicle20 != (Entity) null)
        this.Vehicle20.Delete();
      if ((Entity) this.Vehicle21 != (Entity) null)
        this.Vehicle21.Delete();
      if ((Entity) this.Vehicle22 != (Entity) null)
        this.Vehicle22.Delete();
      if ((Entity) this.Vehicle23 != (Entity) null)
        this.Vehicle23.Delete();
      if ((Entity) this.Vehicle24 != (Entity) null)
        this.Vehicle24.Delete();
      if ((Entity) this.Vehicle25 != (Entity) null)
        this.Vehicle25.Delete();
      if ((Entity) this.Vehicle26 != (Entity) null)
        this.Vehicle26.Delete();
      if ((Entity) this.Vehicle27 != (Entity) null)
        this.Vehicle27.Delete();
      if ((Entity) this.Vehicle28 != (Entity) null)
        this.Vehicle28.Delete();
      if ((Entity) this.Vehicle29 != (Entity) null)
        this.Vehicle29.Delete();
      if ((Entity) this.Vehicle30 != (Entity) null)
        this.Vehicle30.Delete();
      if ((Entity) this.Vehicle31 != (Entity) null)
        this.Vehicle31.Delete();
      if ((Entity) this.Vehicle32 != (Entity) null)
        this.Vehicle32.Delete();
      if ((Entity) this.Vehicle33 != (Entity) null)
        this.Vehicle33.Delete();
      if ((Entity) this.Vehicle34 != (Entity) null)
        this.Vehicle34.Delete();
      if ((Entity) this.Vehicle35 != (Entity) null)
        this.Vehicle35.Delete();
      if ((Entity) this.RampBuggy != (Entity) null)
        this.RampBuggy.Delete();
      if ((Entity) this.Ruiner2000 != (Entity) null)
        this.Ruiner2000.Delete();
      if ((Entity) this.Boxville != (Entity) null)
        this.Boxville.Delete();
      if ((Entity) this.TechnicalA != (Entity) null)
        this.TechnicalA.Delete();
      if ((Entity) this.Rvoltic != (Entity) null)
        this.Rvoltic.Delete();
      if ((Entity) this.PhantomW != (Entity) null)
        this.PhantomW.Delete();
      if ((Entity) this.BlazerAqua != (Entity) null)
        this.BlazerAqua.Delete();
      if (!((Entity) this.Wastelander != (Entity) null))
        return;
      this.Wastelander.Delete();
    }

    public static string LoadDict(string dict)
    {
      while (true)
      {
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) dict))
        {
          Function.Call(Hash._0xD3BD40951412FEF6, (InputArgument) dict);
          Script.Yield();
        }
        else
          break;
      }
      return dict;
    }

    public void CreateCars(string Garage)
    {
      try
      {
        this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        this.ChairPropModel = this.Config2.GetValue<string>("Misc", "CHAIRMODELCEO", this.ChairPropModel);
        if ((Entity) this.ChairProp != (Entity) null)
          this.ChairProp.Delete();
        this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), new Vector3(964.6574f, -3003.5f, -40.5f), new Vector3(0.0f, 0.0f, 0.0f), false, false);
        this.ChairProp.FreezePosition = true;
        this.ChairProp.Heading = -130f;
      }
      catch
      {
        UI.Notify("error 1");
      }
      try
      {
        Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "urban_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "branded_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "car_floor_hatch");
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 252673);
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
        int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 994.5925, (InputArgument) -3002.594, (InputArgument) -39.64699);
        this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        this.Style = this.Config2.GetValue<string>("VEHICLEWAREHOUSES", "Style", this.Style);
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) this.Style);
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
        this.SC.LoadIniFile(this.path + Garage + "//Slot1.ini");
        GTA.Model model1 = this.SC.CheckCar(this.path + Garage + "//Slot1.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot2.ini");
        GTA.Model model2 = this.SC.CheckCar(this.path + Garage + "//Slot2.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot3.ini");
        GTA.Model model3 = this.SC.CheckCar(this.path + Garage + "//Slot3.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot4.ini");
        GTA.Model model4 = this.SC.CheckCar(this.path + Garage + "//Slot4.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot5.ini");
        GTA.Model model5 = this.SC.CheckCar(this.path + Garage + "//Slot5.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot6.ini");
        GTA.Model model6 = this.SC.CheckCar(this.path + Garage + "//Slot6.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot7.ini");
        GTA.Model model7 = this.SC.CheckCar(this.path + Garage + "//Slot7.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot8.ini");
        GTA.Model model8 = this.SC.CheckCar(this.path + Garage + "//Slot8.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot9.ini");
        GTA.Model model9 = this.SC.CheckCar(this.path + Garage + "//Slot9.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot10.ini");
        GTA.Model model10 = this.SC.CheckCar(this.path + Garage + "//Slot10.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot11.ini");
        GTA.Model model11 = this.SC.CheckCar(this.path + Garage + "//Slot11.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot12.ini");
        GTA.Model model12 = this.SC.CheckCar(this.path + Garage + "//Slot12.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot13.ini");
        GTA.Model model13 = this.SC.CheckCar(this.path + Garage + "//Slot13.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot14.ini");
        GTA.Model model14 = this.SC.CheckCar(this.path + Garage + "//Slot14.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot15.ini");
        GTA.Model model15 = this.SC.CheckCar(this.path + Garage + "//Slot15.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot16.ini");
        GTA.Model model16 = this.SC.CheckCar(this.path + Garage + "//Slot15.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot17.ini");
        GTA.Model model17 = this.SC.CheckCar(this.path + Garage + "//Slot17.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot18.ini");
        GTA.Model model18 = this.SC.CheckCar(this.path + Garage + "//Slot18.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot19.ini");
        GTA.Model model19 = this.SC.CheckCar(this.path + Garage + "//Slot19.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot20.ini");
        GTA.Model model20 = this.SC.CheckCar(this.path + Garage + "//Slot20.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot21.ini");
        GTA.Model model21 = this.SC.CheckCar(this.path + Garage + "//Slot21.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot22.ini");
        GTA.Model model22 = this.SC.CheckCar(this.path + Garage + "//Slot22.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot23.ini");
        GTA.Model model23 = this.SC.CheckCar(this.path + Garage + "//Slot23.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot24.ini");
        GTA.Model model24 = this.SC.CheckCar(this.path + Garage + "//Slot24.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot25.ini");
        GTA.Model model25 = this.SC.CheckCar(this.path + Garage + "//Slot25.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot26.ini");
        GTA.Model model26 = this.SC.CheckCar(this.path + Garage + "//Slot26.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot27.ini");
        GTA.Model model27 = this.SC.CheckCar(this.path + Garage + "//Slot27.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot28.ini");
        GTA.Model model28 = this.SC.CheckCar(this.path + Garage + "//Slot28.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot29.ini");
        GTA.Model model29 = this.SC.CheckCar(this.path + Garage + "//Slot29.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot30.ini");
        GTA.Model model30 = this.SC.CheckCar(this.path + Garage + "//Slot30.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot31.ini");
        GTA.Model model31 = this.SC.CheckCar(this.path + Garage + "//Slot31.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot32.ini");
        GTA.Model model32 = this.SC.CheckCar(this.path + Garage + "//Slot32.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot33.ini");
        GTA.Model model33 = this.SC.CheckCar(this.path + Garage + "//Slot33.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot34.ini");
        GTA.Model model34 = this.SC.CheckCar(this.path + Garage + "//Slot34.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot35.ini");
        GTA.Model model35 = this.SC.CheckCar(this.path + Garage + "//Slot35.ini");
        this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        if (model1 != (GTA.Model) "null" && model1 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot1.ini");
          this.Vehicle1 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot1.ini"), this.Vehicle1Loc, 180f);
          this.SC.Load(this.Vehicle1);
          this.Vehicle1.IsDriveable = false;
        }
        if (model2 != (GTA.Model) "null" && model2 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot2.ini");
          this.Vehicle2 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot2.ini"), this.Vehicle2Loc, 180f);
          this.SC.Load(this.Vehicle2);
          this.Vehicle2.IsDriveable = false;
        }
        if (model3 != (GTA.Model) "null" && model3 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot3.ini");
          this.Vehicle3 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot3.ini"), this.Vehicle3Loc, 180f);
          this.SC.Load(this.Vehicle3);
          this.Vehicle3.IsDriveable = false;
        }
        if (model4 != (GTA.Model) "null" && model4 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot4.ini");
          this.Vehicle4 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot4.ini"), this.Vehicle4Loc, 180f);
          this.SC.Load(this.Vehicle4);
          this.Vehicle4.IsDriveable = false;
        }
        if (model5 != (GTA.Model) "null" && model5 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot5.ini");
          this.Vehicle5 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot5.ini"), this.Vehicle5Loc, 180f);
          this.SC.Load(this.Vehicle5);
          this.Vehicle5.IsDriveable = false;
        }
        if (model6 != (GTA.Model) "null" && model6 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot6.ini");
          this.Vehicle6 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot6.ini"), this.Vehicle6Loc, 0.0f);
          this.SC.Load(this.Vehicle6);
          this.Vehicle6.IsDriveable = false;
        }
        if (model7 != (GTA.Model) "null" && model7 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot7.ini");
          this.Vehicle7 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot7.ini"), this.Vehicle7Loc, 0.0f);
          this.SC.Load(this.Vehicle7);
          this.Vehicle7.IsDriveable = false;
        }
        if (model8 != (GTA.Model) "null" && model8 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot8.ini");
          this.Vehicle8 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot8.ini"), this.Vehicle8Loc, 0.0f);
          this.SC.Load(this.Vehicle8);
          this.Vehicle8.IsDriveable = false;
        }
        if (model9 != (GTA.Model) "null" && model9 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot9.ini");
          this.Vehicle9 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot9.ini"), this.Vehicle9Loc, 0.0f);
          this.SC.Load(this.Vehicle9);
          this.Vehicle9.IsDriveable = false;
        }
        if (model10 != (GTA.Model) "null" && model10 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot10.ini");
          this.Vehicle10 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot10.ini"), this.Vehicle10Loc, 0.0f);
          this.SC.Load(this.Vehicle10);
          this.Vehicle10.IsDriveable = false;
        }
        if (model11 != (GTA.Model) "null" && model11 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot11.ini");
          this.Vehicle11 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot11.ini"), this.Vehicle11Loc, 90f);
          this.SC.Load(this.Vehicle11);
          this.Vehicle11.IsDriveable = false;
        }
        if (model12 != (GTA.Model) "null" && model12 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot12.ini");
          this.Vehicle12 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot12.ini"), this.Vehicle12Loc, 0.0f);
          this.SC.Load(this.Vehicle12);
          this.Vehicle12.IsDriveable = false;
        }
        if (model13 != (GTA.Model) "null" && model13 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot13.ini");
          this.Vehicle13 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot13.ini"), this.Vehicle13Loc, 90f);
          this.SC.Load(this.Vehicle13);
          this.Vehicle13.IsDriveable = false;
        }
        if (model14 != (GTA.Model) "null" && model14 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot14.ini");
          this.Vehicle14 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot14.ini"), this.Vehicle14Loc, 0.0f);
          this.SC.Load(this.Vehicle14);
          this.Vehicle14.IsDriveable = false;
        }
        if (model15 != (GTA.Model) "null" && model15 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot15.ini");
          this.Vehicle15 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot15.ini"), this.Vehicle15Loc, 0.0f);
          this.SC.Load(this.Vehicle15);
          this.Vehicle15.IsDriveable = false;
        }
        if (model16 != (GTA.Model) "null" && model16 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot16.ini");
          this.Vehicle16 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot16.ini"), this.Vehicle16Loc, -90f);
          this.SC.Load(this.Vehicle16);
          this.Vehicle16.IsDriveable = false;
        }
        if (model17 != (GTA.Model) "null" && model17 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot17.ini");
          this.Vehicle17 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot17.ini"), this.Vehicle17Loc, -90f);
          this.SC.Load(this.Vehicle17);
          this.Vehicle17.IsDriveable = false;
        }
        if (model18 != (GTA.Model) "null" && model18 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot18.ini");
          this.Vehicle18 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot18.ini"), this.Vehicle18Loc, -90f);
          this.SC.Load(this.Vehicle18);
          this.Vehicle18.IsDriveable = false;
        }
        if (model19 != (GTA.Model) "null" && model19 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot19.ini");
          this.Vehicle19 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot19.ini"), this.Vehicle19Loc, 0.0f);
          this.SC.Load(this.Vehicle19);
          this.Vehicle19.IsDriveable = false;
        }
        if (model20 != (GTA.Model) "null" && model20 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot20.ini");
          this.Vehicle20 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot20.ini"), this.Vehicle20Loc, 0.0f);
          this.SC.Load(this.Vehicle20);
          this.Vehicle20.IsDriveable = false;
        }
        if (model21 != (GTA.Model) "null" && model21 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot21.ini");
          this.Vehicle21 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot21.ini"), this.Vehicle21Loc, 0.0f);
          this.SC.Load(this.Vehicle21);
          this.Vehicle21.IsDriveable = false;
        }
        if (model22 != (GTA.Model) "null" && model22 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot22.ini");
          this.Vehicle22 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot22.ini"), this.Vehicle22Loc, 0.0f);
          this.SC.Load(this.Vehicle22);
          this.Vehicle22.IsDriveable = false;
        }
        if (model23 != (GTA.Model) "null" && model23 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot23.ini");
          this.Vehicle23 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot23.ini"), this.Vehicle23Loc, 0.0f);
          this.SC.Load(this.Vehicle23);
          this.Vehicle23.IsDriveable = false;
        }
        if (model24 != (GTA.Model) "null" && model24 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot24.ini");
          this.Vehicle24 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot24.ini"), this.Vehicle24Loc, 0.0f);
          this.SC.Load(this.Vehicle24);
          this.Vehicle24.IsDriveable = false;
        }
        if (model25 != (GTA.Model) "null" && model25 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot25.ini");
          this.Vehicle25 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot25.ini"), this.Vehicle25Loc, 0.0f);
          this.SC.Load(this.Vehicle25);
          this.Vehicle25.IsDriveable = false;
        }
        if (model26 != (GTA.Model) "null" && model26 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot26.ini");
          this.Vehicle26 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot26.ini"), this.Vehicle26Loc, 180f);
          this.SC.Load(this.Vehicle26);
          this.Vehicle26.IsDriveable = false;
        }
        if (model27 != (GTA.Model) "null" && model27 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot27.ini");
          this.Vehicle27 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot27.ini"), this.Vehicle27Loc, 180f);
          this.SC.Load(this.Vehicle27);
          this.Vehicle27.IsDriveable = false;
        }
        if (model28 != (GTA.Model) "null" && model28 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot28.ini");
          this.Vehicle28 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot28.ini"), this.Vehicle28Loc, 180f);
          this.SC.Load(this.Vehicle28);
          this.Vehicle28.IsDriveable = false;
        }
        if (model29 != (GTA.Model) "null" && model29 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot29.ini");
          this.Vehicle29 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot29.ini"), this.Vehicle29Loc, 180f);
          this.SC.Load(this.Vehicle29);
          this.Vehicle29.IsDriveable = false;
        }
        if (model30 != (GTA.Model) "null" && model30 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot30.ini");
          this.Vehicle30 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot30.ini"), this.Vehicle30Loc, 180f);
          this.SC.Load(this.Vehicle30);
          this.Vehicle30.IsDriveable = false;
        }
        if (model31 != (GTA.Model) "null" && model31 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot31.ini");
          this.Vehicle31 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot31.ini"), this.Vehicle31Loc, -90f);
          this.SC.Load(this.Vehicle31);
          this.Vehicle31.IsDriveable = false;
        }
        if (model32 != (GTA.Model) "null" && model32 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot32.ini");
          this.Vehicle32 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot32.ini"), this.Vehicle32Loc, -90f);
          this.SC.Load(this.Vehicle32);
          this.Vehicle32.IsDriveable = false;
        }
        if (model33 != (GTA.Model) "null" && model33 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot33.ini");
          this.Vehicle33 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot33.ini"), this.Vehicle33Loc, -90f);
          this.SC.Load(this.Vehicle33);
          this.Vehicle33.IsDriveable = false;
        }
        if (model34 != (GTA.Model) "null" && model34 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot34.ini");
          this.Vehicle34 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot34.ini"), this.Vehicle34Loc, -90f);
          this.SC.Load(this.Vehicle34);
          this.Vehicle34.IsDriveable = false;
        }
        if (model35 != (GTA.Model) "null" && model35 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot35.ini");
          this.Vehicle35 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot35.ini"), this.Vehicle35Loc, -90f);
          this.SC.Load(this.Vehicle35);
          this.Vehicle35.IsDriveable = false;
        }
        if (this.Ruiner2000Bought == 1)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//RUINER2000.ini");
          this.Ruiner2000 = World.CreateVehicle((GTA.Model) VehicleHash.Ruiner2, this.Ruiner2000Loc, 180f);
          this.SC.Load(this.Ruiner2000);
          this.Ruiner2000.IsDriveable = false;
        }
        if (this.RampbuggyBought == 1)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//RAMPBUGGY.ini");
          string vehicleName = this.SC.VehicleName;
          this.RampBuggy = World.CreateVehicle((GTA.Model) VehicleHash.Dune4, this.RampBuggyLoc, 180f);
          this.SC.Load(this.RampBuggy);
          this.RampBuggy.IsDriveable = false;
        }
        if (this.ABoxvilleBought == 1)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//ARMOUREDBOXVILLE.ini");
          string vehicleName = this.SC.VehicleName;
          this.Boxville = World.CreateVehicle((GTA.Model) VehicleHash.Boxville5, this.BoxvilleLoc, 180f);
          this.SC.Load(this.Boxville);
          this.Boxville.IsDriveable = false;
        }
        if (this.TechnicalAquaBought == 1)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//TECHNICALAAQUA.ini");
          string vehicleName = this.SC.VehicleName;
          this.TechnicalA = World.CreateVehicle((GTA.Model) VehicleHash.Technical2, this.TechnicalALoc, 180f);
          this.SC.Load(this.TechnicalA);
          this.TechnicalA.IsDriveable = false;
        }
        if (this.PhantomWBought == 1)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//PHANTOMWEDGE.ini");
          string vehicleName = this.SC.VehicleName;
          this.PhantomW = World.CreateVehicle((GTA.Model) VehicleHash.Phantom2, this.PhantomWLoc, 180f);
          this.SC.Load(this.PhantomW);
          this.PhantomW.IsDriveable = false;
        }
        if (this.RvolticBought == 1)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//ROCKETVOLTIC.ini");
          string vehicleName = this.SC.VehicleName;
          this.Rvoltic = World.CreateVehicle((GTA.Model) VehicleHash.Voltic2, this.RvolticLoc, 180f);
          this.SC.Load(this.Rvoltic);
          this.Rvoltic.IsDriveable = false;
        }
        if (this.BlazerAquaBought == 1)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//BLAZERAQUA.ini");
          string vehicleName = this.SC.VehicleName;
          this.BlazerAqua = World.CreateVehicle((GTA.Model) VehicleHash.Blazer5, this.BlazerAquaLoc, 180f);
          this.SC.Load(this.BlazerAqua);
          this.BlazerAqua.IsDriveable = false;
        }
        if (this.WastelanderBought == 1)
        {
          this.SC.LoadIniFile(this.path + "UnderGround//WASTELANDER.ini");
          string vehicleName = this.SC.VehicleName;
          this.Wastelander = World.CreateVehicle((GTA.Model) VehicleHash.Wastelander, this.WastelanderLoc, 180f);
          this.SC.Load(this.Wastelander);
          this.Wastelander.IsDriveable = false;
        }
        this.GarageNum = Garage;
      }
      catch (NullReferenceException ex)
      {
        if (this.SC == null)
          UI.Notify("SC Null");
        UI.Notify("~r~ Executive Warehouse : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
      }
    }

    public class PlayerVehicles
    {
      public string PlateText;

      public Vehicle Vehicle { get; set; }

      public VehicleColor PrimaryColor { get; set; }

      public VehicleColor SecondaryColor { get; set; }

      public PlayerVehicles()
      {
      }

      public PlayerVehicles(Vehicle V, VehicleColor Pc, VehicleColor Sc, string Pt)
      {
        this.Vehicle = V;
        this.PrimaryColor = Pc;
        this.SecondaryColor = Sc;
        this.PlateText = Pt;
      }
    }

    public class CargoWarehouseData : Script
    {
      public int Owned { get; set; }

      public int Size { get; set; }

      public int Cost { get; set; }

      public int Maxcrates { get; set; }

      public Vector3 Location { get; set; }

      public string WarehouseName { get; set; }

      public string WarehouseLocation { get; set; }

      public string WarehouseDescription { get; set; }

      public int DiscountCost { get; set; }

      public string PicTexture { get; set; }

      public CargoWarehouseData()
      {
      }

      public CargoWarehouseData(
        int O,
        int S,
        int C,
        int Mc,
        Vector3 L,
        string Wn,
        string Wl,
        string Wd,
        int Dc,
        string Pt)
      {
        this.Owned = O;
        this.Size = S;
        this.Cost = C;
        this.Maxcrates = Mc;
        this.Location = L;
        this.WarehouseName = Wn;
        this.WarehouseLocation = Wl;
        this.WarehouseDescription = Wd;
        this.DiscountCost = Dc;
        this.PicTexture = Pt;
      }
    }

    public class VehicleWarehouseData : Script
    {
      public int Owned { get; set; }

      public string VehicleWarehouseName { get; set; }

      public string VehicleWarehouseLocationName { get; set; }

      public string VehicleWarehousePicTex { get; set; }

      public string VehicleWarehouseDescription { get; set; }

      public Vector3 VehicleWarehouseCoords { get; set; }

      public float VehicleWarehouseExitHeading { get; set; }

      public int Price { get; set; }

      public int DiscountPrice { get; set; }

      public VehicleWarehouseData()
      {
      }

      public VehicleWarehouseData(
        int O,
        Vector3 wLoc,
        float H,
        string Wn,
        string Wln,
        string Pictex,
        int p,
        int Dp,
        string Desc)
      {
        this.Owned = O;
        this.VehicleWarehouseCoords = wLoc;
        this.VehicleWarehouseExitHeading = H;
        this.VehicleWarehouseName = Wn;
        this.VehicleWarehouseLocationName = Wln;
        this.VehicleWarehousePicTex = Pictex;
        this.VehicleWarehouseDescription = Desc;
        this.Price = p;
        this.DiscountPrice = Dp;
      }
    }

    public class VehicleData
    {
      public string modelString { get; set; }

      public string Price { get; set; }

      public GTA.Model Model { get; set; }

      public VehicleData()
      {
      }

      public VehicleData(string s, string p, GTA.Model m)
      {
        this.modelString = s;
        this.Price = p;
        this.Model = m;
      }
    }

    public class Flare : Script
    {
      public Vector3 Location { get; set; }

      public bool Created { get; set; }

      public Prop FlareProp { get; set; }

      public int FlareID_1 { get; set; }

      public int FlareID_2 { get; set; }

      public int FlareID_3 { get; set; }

      public Flare()
      {
      }

      public Flare(Prop FP, int Fid1, int Fid2, int Fid3)
      {
        this.FlareProp = FP;
        this.FlareID_1 = Fid1;
        this.FlareID_2 = Fid2;
        this.FlareID_3 = Fid3;
      }

      public Flare(Prop FP, int Fid1)
      {
        this.FlareProp = FP;
        this.FlareID_1 = Fid1;
      }

      public Flare(Prop FP, int Fid1, bool C)
      {
        this.FlareProp = FP;
        this.FlareID_1 = Fid1;
        this.Created = C;
      }

      public Flare(Vector3 Loc, bool C)
      {
        this.Location = Loc;
        this.Created = C;
      }

      public Flare(Prop FP, Vector3 Loc, bool C)
      {
        this.FlareProp = FP;
        this.Location = Loc;
        this.Created = C;
      }
    }

    public class SpawnH
    {
      public Vector3 Position { get; set; }

      public float Heading { get; set; }

      public SpawnH()
      {
      }

      public SpawnH(Vector3 P, float H)
      {
        this.Position = P;
        this.Heading = H;
      }
    }

    public enum Nodetype
    {
      AnyRoad,
      Road,
      Offroad,
      Water,
    }
  }
}
