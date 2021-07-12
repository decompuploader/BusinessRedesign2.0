using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ExecutiveBusiness
{
  public class SubBusinesses : Script
  {
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public Vector3 ChairPos_1 = new Vector3(1088.822f, -3101.395f, -39.9f);
    public float P_Rotation_1 = 50f;
    public Prop ChairProp_1;
    public Vector3 ChairPos_2 = new Vector3(1049.514f, -3100.566f, -39.9f);
    public float P_Rotation_2 = 60f;
    public Prop ChairProp_2;
    public Vector3 ChairPos_3 = new Vector3(994.0709f, -3099.978f, -39.9f);
    public float P_Rotation_3 = -130f;
    public Prop ChairProp_3;
    public BlipColor ArcadiusBlip_Colour;
    public Color ArcadiusMarkerColor;
    public string ArcadiusMarkerColorString;
    public BlipColor MazeBankBlip_Colour;
    public Color MazeBankMarkerColor;
    public string MazeBankMarkerColorString;
    public BlipColor MBWBlip_Colour;
    public Color MBWMarkerColor;
    public string MBWMarkerColorString;
    public BlipColor LombokBlip_Colour;
    public Color LombokMarkerColor;
    public string LombokMarkerColorString;
    private ScriptSettings MainConfigFile;
    public float BusinessUpgradeIncreaseGain = 75000f;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    private ScriptSettings Config;
    private ScriptSettings Config2;
    private ScriptSettings Config3;
    private Keys Key1;
    public Vector3 SubLoc;
    public Vector3 SubLocMenu;
    public Vector3 SubLocExit;
    private MenuPool WarehouseMenu;
    private UIMenu Warehouse;
    private UIMenu Warehousemenus;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private UIMenu Buy;
    private UIMenu Import;
    private UIMenu Export;
    private UIMenu Details;
    private UIMenu Upgrades;
    public int waittime;
    public int maxstocks;
    public int NarcoticsBusinessBought;
    public int NarcoticsStock;
    public int NarcoticsProfit;
    public float NarcoticsGain;
    public int GemstonesBusinessBought;
    public int GemstonesStock;
    public int GemstonesProfit;
    public float GemstonesGain;
    public int MunitionsBusinessBought;
    public int MunitionsStock;
    public int MunitionsProfit;
    public float MunitionGain;
    public int timer;
    public Blip SubBusinessMarkerMB;
    public Blip SubBusinessMarkerMBW;
    public Blip SubBusinessMarkerA;
    public Blip SubBusinessMarkerL;
    public ExecutiveTower Arcadius;
    public string Tower;
    public int purchaselvl;
    public int purchaselvlMain;
    public bool Read;
    public AllStocks Allstocks;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public List<Vector3> pPosition = new List<Vector3>();
    public List<Vector3> pPosition2 = new List<Vector3>();
    public List<Vector3> pPosition3 = new List<Vector3>();
    public List<Prop> Props = new List<Prop>();
    public List<string> CrateIds = new List<string>();
    public int StockCount;
    public Vector3 BrickadeSpawn = new Vector3(138f, -3188f, 6f);
    public int WarehouseIn;
    public int WarehouseMax;
    public int SmallBought;
    public int MaxStocksForSmall = 100;
    public int MediumBought;
    public int MaxStocksForMedium = 350;
    public int LargeBought;
    public int MaxStocksForLarge = 750;
    public List<Vector3> DropPoint = new List<Vector3>();
    public List<Blip> DropBlip = new List<Blip>();
    public int Droptype;
    public Vehicle DropVehicle;
    public Blip DropVehicleBlip;
    public int missionnum;
    public bool PlayingMission;
    public int PointsBeenAt;
    public float amountToSell;
    public int StockAmount;
    public float vehicleHealth;
    public int DeliverPointsReq;
    public int DeliverPointsReqLeft;
    public DateTime CurrentDate;
    public DateTime NextDate;
    public int DaysWait = 3;
    public int NextDay;
    public int NextMonth;
    public int NextYear;
    public int NextDay2;
    public int NextMonth2;
    public int NextYear2;
    public bool BYPASS_NOSAVE_OR_CRASH = true;
    public int DAYSTORESET_UPDATETIME = 12;
    public int Now;
    public int CurrentCratestotal;
    public string Towerstr;
    public float Narcotic_MultiplierPercent;
    public float Munitions_MultiplierPercent;
    public float Gemstones_MultiplierPercent;
    public int SubbusinessLoc;
    public Vector3 SubbusinessLocVector3;
    public Vector3 SubbusinessVehicleSpawn;
    public float SubbusinessVehicleRot;
    public int SubbusinessBought = 1;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public bool Firsttime;
    public bool IsSittinginCeoSeat;
    public Prop ChairProp;
    public Vector3 ChairLoc;
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
    public GTA.Control BackKey = GTA.Control.Aim;
    public int BNKr_TotalEarnings = 326000;
    public int BNKr_TotalSales = 54;
    public int BNKr_ResupplySuccessRate = 98;
    public int BNKr_SellSuccess_BC = 90;
    public int BNKr_SellSuccess_LS = 92;
    public int BNKr_ResearchCompletedCrt = 13;
    public int BNKr_ResearchToComplete = 42;
    public int BNKr_FastTrackResearchPrice = 88000;
    public int BNKr_BCSellPrice = 234000;
    public int BNKr_LSSellPrice = 132000;
    public int BNKr_BunkerOperationStatus = 1;
    public int BNKr_ResearchStatus = 2;
    public int BNKr_StockLevel = 10;
    public int BNKr_ResearchProgress = 80;
    public int BNKr_SuppliesLevel = 40;
    public int BNKr_UnlockPage = 1;
    public int BNKr_SetupBusiness = 1;
    public string BNKr_BunkerImage = "UA_BUNKER_TXD_8";
    public string BNKr_Name = "HKH191";
    public int BNKr_UnitsManufactured = 24;
    public string BNKr_BunkerLocation = "Grand Senora Desert";
    public string BNKr_BunkerName = "Farmhouse Bunker";
    public int BNKr_StaffAssignment = 2;
    public int BNKr_Upgrade1FullPrice = 200000;
    public int BNKr_Upgrade1Unlocked = 2;
    public int BNKr_Upgrade1DiscountPrice = 190000;
    public int BNKr_Upgrade2FullPrice = 175000;
    public int BNKr_Upgrade2Unlocked = 2;
    public int BNKr_Upgrade2DiscountPrice = 145000;
    public int BNKr_Upgrade3FullPrice = 180000;
    public int BNKr_Upgrade3Unlocked = 2;
    public int BNKr_Upgrade3DiscountPrice = 170000;
    public string SMG_Name = "HKH191";
    public int SMG_StealsCompleted = 2;
    public int SMG_StealSuccessRate = 98;
    public int SMG_SalesCompleted = 4;
    public int SMG_SalesSuccessRate = 94;
    public int SMG_RivalCratesStolen = 6;
    public int SMG_Earnings = 24000;
    public int SMG_CargoTypeBonus = 14000;
    public int SMG_MaxCrates = 248;
    public int SMG_CurrentCrates = 166;
    public int SMG_ValueTotal;
    public float SMG_Narcotics_Bonus = 2f;
    public int SMG_Narcotics_CurrentStock = 55;
    public int SMG_Narcotics_StockMax = 212;
    public int SMG_Narcotics_Value = 100000;
    public float SMG_Chemicals_Bonus = 1f;
    public int SMG_Chemicals_CurrentStock = 31;
    public int SMG_Chemicals_StockMax = 214;
    public int SMG_Chemicals_Value = 98000;
    public float SMG_MedicalSupplies_Bonus = 4f;
    public int SMG_MedicalSupplies_CurrentStock = 15;
    public int SMG_MedicalSupplies_StockMax = 177;
    public int SMG_MedicalSupplies_Value = 62562;
    public float SMG_AnimalMaterials_Bonus = 3f;
    public int SMG_AnimalMaterials_CurrentStock = 25;
    public int SMG_AnimalMaterials_StockMax = 155;
    public int SMG_AnimalMaterials_Value = 51251;
    public float SMG_ArtaAntiques_Bonus = 5f;
    public int SMG_ArtaAntiques_CurrentStock = 25;
    public int SMG_ArtaAntiques_StockMax = 200;
    public int SMG_ArtaAntiques_Value = 15151;
    public float SMG_JewelryaGemstones_Bonus = 4f;
    public int SMG_JewelryaGemstones_CurrentStock = 22;
    public int SMG_JewelryaGemstones_StockMax = 180;
    public int SMG_JewelryaGemstones_Value = 62661;
    public float SMG_TabaccoaAlcohol_Bonus = 1f;
    public int SMG_TabaccoaAlcohol_CurrentStock = 14;
    public int SMG_TabaccoaAlcohol_StockMax = 231;
    public int SMG_TabaccoaAlcohol_Value = 107333;
    public float SMG_CounterfeitGoods_Bonus = 3f;
    public int SMG_CounterfeitGoods_CurrentStock = 151;
    public int SMG_CounterfeitGoods_StockMax = 251;
    public int SMG_CounterfeitGoods_Value = 34468;
    public List<Vector2> SMG_Screen1ButtonPos = new List<Vector2>()
    {
      new Vector2(0.242f, 0.43f),
      new Vector2(0.414f, 0.43f),
      new Vector2(0.585f, 0.43f),
      new Vector2(0.753f, 0.43f),
      new Vector2(0.242f, 0.766f),
      new Vector2(0.414f, 0.766f),
      new Vector2(0.585f, 0.766f),
      new Vector2(0.753f, 0.766f)
    };
    public List<string> SMG_Screen1ButtonType = new List<string>()
    {
      "Narcotics",
      "Chemicals",
      "Medical Supplies",
      "Animal Materials",
      "Art & Antiques",
      "Jewelry & Gemstones",
      "Tobacco & Alcohol",
      "Counterfeit Goods"
    };
    public List<Vector2> SMG_Screen2ButtonPos = new List<Vector2>()
    {
      new Vector2(0.244f, 0.47f),
      new Vector2(0.413f, 0.47f),
      new Vector2(0.585f, 0.47f),
      new Vector2(0.755f, 0.43f),
      new Vector2(0.244f, 0.842f),
      new Vector2(0.413f, 0.842f),
      new Vector2(0.585f, 0.842f),
      new Vector2(0.755f, 0.842f)
    };
    public List<string> SMG_Screen2ButtonType = new List<string>()
    {
      "Narcotics",
      "Chemicals",
      "Medical Supplies",
      "Animal Materials",
      "Art & Antiques",
      "Jewelry & Gemstones",
      "Tobacco & Alcohol",
      "Counterfeit Goods",
      "All"
    };
    public int SS_VehicleSalesMade;
    public string SS_Name = "HKH191";
    public string SS_Company = "Executive Office";
    public int SS_SuccessRate = 8;
    public int SS_SaleSuccessRate = 98;
    public int SourceCrateCostMultiplier = 3;
    public int SellCrateCostMultiplier = 3;
    public int SourceCrateAmtMultiplier = 3;
    public int SellCrateAmtMultiplier = 3;
    public int SS_WarehousesOwned = 1;
    public int SS_CollectionsFailed;
    public int SS_CollectionsCompleted = 4;
    public int SS_TotalSalesMade = 11;
    public int SS_TotalSalesFailed = 1;
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
    public int SS_VehiclesExportedTotal = 91;
    public int SS_StealSuccessTotal = 96;
    public float SS_VehiclesStolenTotal = 98f;
    public int SS_SpecialItems = 3;
    public int SS_Warehouse1CurrentValue = 241000;
    public int SS_Warehouse2CurrentValue = 210000;
    public int SS_Warehouse3CurrentValue = 180000;
    public int SS_Warehouse4CurrentValue = 311000;
    public int SS_Warehouse5CurrentValue = 271000;
    public int VehicleWarehouseIndex = 3;
    public int SS_VehicleWarehouseLoc = 4;
    public int SS_CurrentVehiclesAmt = 29;
    public int SS_VehiclesTotalCurrentValue = 1750000;
    public int SS_SourceVehicleWait;
    public int WarehouseSelected;
    public int VehiclesInWarehouse = 12;
    public List<SubBusinesses.CargoWarehouseData> CargoWarehouses = new List<SubBusinesses.CargoWarehouseData>()
    {
      new SubBusinesses.CargoWarehouseData(0, 0, 265000, 16, new Vector3(234.2376f, -1946.627f, 23.1f), "Convenience Store Lockup", "Rancho", "Rancho Warehouse", 250000, "DYN_MPWH_12"),
      new SubBusinesses.CargoWarehouseData(0, 0, 325000, 16, new Vector3(896.4013f, -1035.933f, 35.7f), "Celltowa Unit", "La Mesa", "La Mesa Warehouse", 318000, "DYN_MPWH_3"),
      new SubBusinesses.CargoWarehouseData(0, 0, 375000, 16, new Vector3(-1082.821f, -1261.822f, 4.6f), "White Widow Garage", "La Puerta", "La Puerta Warehouse", 360000, "DYN_MPWH_2"),
      new SubBusinesses.CargoWarehouseData(0, 0, 380000, 16, new Vector3(51.31f, -2570.59f, 5f), "Pacific Bait Storage", "Elysian Island 1", "Elysian Island Warehouse", 376000, "DYN_MPWH_1"),
      new SubBusinesses.CargoWarehouseData(0, 0, 400000, 16, new Vector3(274.46f, -3015.293f, 4.69f), "Pier 400 Utility Building", "Elysian Island", "Elysian Island Warehouse", 392000, "DYN_MPWH_9"),
      new SubBusinesses.CargoWarehouseData(0, 0, 412000, 16, new Vector3(-424.789f, 185.59f, 79.8f), "Foreclosed Garage", "West Vinewood", "West Vinewood Warehouse", 400000, "DYN_MPWH_5"),
      new SubBusinesses.CargoWarehouseData(0, 1, 902000, 42, new Vector3(1569.81f, -2130.083f, 77.33f), "GEE Warehouse", "El Burro Heights", "El Burro Heights Warehouse", 880000, "DYN_MPWH_10"),
      new SubBusinesses.CargoWarehouseData(0, 1, 914000, 42, new Vector3(-1268.769f, -812.7471f, 16.108f), "Derriere Lingerie Backlot", "Del Perro", "Del Perro Warehouse", 902000, "DYN_MPWH_7"),
      new SubBusinesses.CargoWarehouseData(0, 1, 931000, 42, new Vector3(-528.27f, -1784.095f, 20.55f), "Fridgit Annexe", "La Puerta", "La Puerta Warehouse", 925000, "DYN_MPWH_13"),
      new SubBusinesses.CargoWarehouseData(0, 1, 952000, 42, new Vector3(359.2f, 326.078f, 102.88f), "Discount Retail Unit", "Downtown Vinewood", "Downtown Vinewood Warehouse", 948000, "DYN_MPWH_10"),
      new SubBusinesses.CargoWarehouseData(0, 1, 976000, 42, new Vector3(-295.311f, -1353.118f, 30.31f), "Disused Factory Outlet", "Strawberry", "Strawberry Warehouse", 971000, "DYN_MPWH_14"),
      new SubBusinesses.CargoWarehouseData(0, 1, 1002000, 42, new Vector3(-315.2554f, -2697.967f, 6.55f), "LS Marine Building 3", "Elysian Island", "Elysian Island Warehouse", 994000, "DYN_MPWH_11"),
      new SubBusinesses.CargoWarehouseData(0, 1, 1010000, 42, new Vector3(540.4222f, -1945.05f, 23.98f), "Old Power Station", "Rancho", "Rancho Warehouse", 1000000, "DYN_MPWH_4"),
      new SubBusinesses.CargoWarehouseData(0, 1, 1025000, 42, new Vector3(500.0675f, -651.895f, 23.9f), "Railyard Warehouse", "La Mesa", "La Mesa Warehouse", 1017000, "DYN_MPWH_12"),
      new SubBusinesses.CargoWarehouseData(0, 2, 1910000, 111, new Vector3(1013.557f, -2150.798f, 30.53f), "Wholesale Furniture", "Cypress Flats", "Cypress Flats Warehouse", 1900000, "DYN_MPWH_18"),
      new SubBusinesses.CargoWarehouseData(0, 2, 2165000, 111, new Vector3(-262.9621f, 202.4988f, 84.37f), "West Vinewood Backlot", "West Vinewood", "West Vinewood Warehouse", 2135000, "DYN_MPWH_20"),
      new SubBusinesses.CargoWarehouseData(0, 2, 2400000, 111, new Vector3(-1070.599f, -2003.346f, 14.79f), "Xero Gas Factory", "LSIA", "LSIA Warehouse", 2365000, "DYN_MPWH_6"),
      new SubBusinesses.CargoWarehouseData(0, 2, 2630000, 111, new Vector3(962.5995f, -1557.725f, 29.8f), "Logistics Depot", "La Mesa", "La Mesa Warehouse", 2600000, "DYN_MPWH_21"),
      new SubBusinesses.CargoWarehouseData(0, 2, 3000000, 111, new Vector3(-873.377f, -2734.696f, 12.92f), "Bilgeco Warehouse", "LSIA", "LSIA Warehouse", 2825000, "DYN_MPWH_8"),
      new SubBusinesses.CargoWarehouseData(0, 2, 3100000, 111, new Vector3(95.899f, -2216.529f, 5.171f), "Walker & Sons Warehouse", "Banning", "Banning Warehouse", 3040000, "DYN_MPWH_16"),
      new SubBusinesses.CargoWarehouseData(0, 2, 3300000, 111, new Vector3(1018.735f, -2511.857f, 27.47f), "Cypress Warehouses", "Cypress Flats", "Cypress Flats Warehouse", 3265000, "DYN_MPWH_19"),
      new SubBusinesses.CargoWarehouseData(0, 2, 3550000, 111, new Vector3(759.7921f, -899.2148f, 24.21f), "Darnel Bros Warehouse", "La Mesa", "La Mesa Warehouse", 3500000, "DYN_MPWH_17"),
      new SubBusinesses.CargoWarehouseData(0, 0, 995000, 16, new Vector3(137.067f, -2472.874f, 5.1f), "Seweage Co", "Chum St", "Chum St Warehouse", 975000, ""),
      new SubBusinesses.CargoWarehouseData(0, 0, 1100000, 16, new Vector3(675.2f, -2726.29f, 6.17f), "Fuel Station Warehouse", "Elysian Island Island", "Elysian Island Warehouse", 1150000, ""),
      new SubBusinesses.CargoWarehouseData(0, 1, 2055000, 42, new Vector3(-520.1091f, -2903.51f, 5f), "Post Op Warehouse", "Elysian Island", "Elysian Island Warehouse", 2045000, ""),
      new SubBusinesses.CargoWarehouseData(0, 2, 2055000, 111, new Vector3(1234.361f, -3201.442f, 4.52f), "United Stats Post Warehouse", "Buccaneer Way", "Buccaneer Way Warehouse", 2045000, ""),
      new SubBusinesses.CargoWarehouseData(0, 2, 2055000, 111, new Vector3(-1327.592f, -237.636f, 41.71f), "Rockford Hills Storage", "Rockford Hills", "Rockford Hills Warehouse", 2045000, "")
    };
    public List<SubBusinesses.VehicleWarehouseData> VehicleWarehouses = new List<SubBusinesses.VehicleWarehouseData>()
    {
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(804.2842f, -2224.391f, 28.4f), "Cypress Flats Vehicle Warehouse", "Cypress Flats", "IE_WH_TXD_1", 2675000, 2700000, "There's no more discreet place to locate a gigantic storage unit than in a neighborhood full of other gigantic storage units. And compared to them, whatever you're planning will almost look legal."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(-66.34f, -1827.459f, 25.9f), "Davis Vehicle Warehouse", "Davis", "IE_WH_TXD_2", 2495000, 2500000, "Does it qualify as a bonded warehouse if the government just doesn't know it exists? We think so, and we've got another warehouse full of lawyers who'll say the same. On the market for a limited time only."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(1763.221f, -1654.817f, 111.6f), "El Burro Heights Vehicle Warehouse", "El Burro Heights", "IE_WH_TXD_3", 1635000, 1700000, "Who would locate an off-the-books vehicle depot in the middle of a suburban wasteland where the white picket fences got burned for fuel a decade ago? A visionary venture capitalist with an eye on privacy, that's who."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(144.3986f, -3002.219f, 6.03f), "Elysian Island Vehicle Warehouse", "lysian Island", "IE_WH_TXD_4", 1950000, 2000000, "In a recent survey of warehouse owners in the port area of Los Santos, 94% self-identity as radical entrepreneurs while only 2% could spell the word 'tax'. Welcome home."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(998.3342f, -1858.597f, 29.88f), "La Mesa Vehicle Warehouse", "La Mesa", "IE_WH_TXD_5", 1500000, 1550000, "Sure, this part of La Mesa won the LSPD's 'Most Gang-Related Stabbings' award three years running. But the previous owner of this spacious depot had the largest collection of authentic Customs and Border Protection agency badges in the state, and his widow is throwing them in as a sweetener. You can't say fairer than that."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(-634.8254f, -1780.845f, 23f), "La Puerta Vehicle Warehouse", "La Puerta", "IE_WH_TXD_6", 2735000, 2750000, "If buying a red brick warehouse in a blue collar neighborhood and filling it with unregistered super cars doesn't count as gentrification, then nothing does. Throw in a flat white served in a chemistry beaker and consider this community regenerated."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(-1156.016f, -2174.042f, 12.21f), "LSIA Vehicle Warehouse", "LSIA", "IE_WH_TXD_7", 2170000, 2200000, "If you want your business to inspire the masses, this is the location for you. Because when they're queuing for another cavity search at LSIA, the sight of you stepping off your private jet to take delivery of a million dollar hypercar will be just the motivation they need to get off their asses and start being incredibly rich."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(-512.1462f, -2198.591f, 5.39f), "LSIA Vehicle Warehouse", "LSIA", "IE_WH_TXD_8", 2300000, 2350000, "It's a sad day for democracy when political correctness, liberal media elites and nineteen counts of human trafficking conspire to bring down one of the oldest storage companies in the state. Lesson learned: don't deal in goods that can testify against you in court, and this place could serve you for decades to come."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(1211.081f, -1262.385f, 34.22f), "Murrieta Heights Vehicle Warehouse", "Murrieta Heights", "IE_WH_TXD_9", 2850000, 3000000, "Here at SecuroServ, we have a dream that one day everyone living in Murrieta Heights will be a billionaire crimelord with an enormous portfolio of nearly-new luxury cars. But we also know that every journey of a thousand miles begins with a single warehouse full of stolen goods. Step up, be the hope, pocket the change."),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(254.6f, -3057f, 4.8f), "Elysian Island Vehicle Warehouse", "Elysian Island", "", 1850000, 2000000, "A Custom Warehouse Located at Elysian Island "),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(943f, -1494f, 29.08f), "La Mesa Vehicle Warehouse", "La Mesa", "", 2250000, 2300000, "A Custom Warehouse Located at La Mesa "),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(-2036.8f, -272.4f, 22.38f), "Pacific Bluffs Vehicle Warehouse", "Pacific Bluffs", "", 2450000, 2500000, "A Custom Warehouse Located at Pacific Bluffs "),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(544.3f, -211.5f, 52.55f), "Hawick Vehicle Warehouse", "Hawick", "", 1450000, 1500000, "A Custom Warehouse Located at Hawick"),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(39.9f, -1283.7f, 28.28f), "Strawberry Vehicle Warehouse", "Strawberry", "", 1950000, 2000000, "A Custom Warehouse Located at Strawberry"),
      new SubBusinesses.VehicleWarehouseData(0, new Vector3(497.4f, -635.5f, 23.94f), "La Mesa Vehicle Warehouse", "La Mesa", "", 1950000, 2000000, "A Custom Warehouse Located at La Mesa (2)")
    };
    public int NC_Upgrade1UnLocked = 2;
    public int NC_Upgrade1Discounted;
    public int NC_Upgrade1DiscountedPrice = 270000;
    public int NC_Upgrade1Price = 350000;
    public int NC_Upgrade2UnLocked = 2;
    public int NC_Upgrade2Discounted = 1;
    public int NC_Upgrade2DiscountedPrice = 120000;
    public int NC_Upgrade2Price = 160000;
    public int NC_Upgrade3UnLocked = 2;
    public int NC_Upgrade3Discounted = 2;
    public int NC_Upgrade3DiscountedPrice = 180000;
    public int NC_Upgrade3Price = 240000;
    public int NC_Popuarity = 60;
    public string NC_Owner = "HKH191";
    public string NC_Location = "La Mesa";
    public int NC_NightclubJobsCompleted = 3;
    public int NC_NightClubEarnings = 25000;
    public int NC_WarehouseSalesCompleted = 5;
    public int NC_WarehouseEarnings = 44500;
    public int NC_TotalEarnings = 125250;
    public int NC_safeCapacityMax = 88000;
    public int NC_safeCapacityCrt = 44000;
    public int NC_Dailyincome = 12500;
    public int NC_Goods = 7;
    public int NC_GoodsAquired;
    public int NC_GoodsSold;
    public int NC_Technician1Status = 1;
    public int NC_Technician1LockedStatus;
    public int NC_Technician1Task = 5;
    public int NC_Technician2Status = 1;
    public int NC_Technician2LockedStatus;
    public int NC_Technician2Task = 4;
    public int NC_Technician3Status = 2;
    public int NC_Technician3LockedStatus;
    public int NC_Technician3Task = 3;
    public int NC_Technician4Status;
    public int NC_Technician4LockedStatus = 1;
    public int NC_Technician4Task = -1;
    public int NC_Technician5Status = 2;
    public int NC_Technician5LockedStatus;
    public int NC_Technician5Task = 1;
    public int NC_AssignedTask;
    public bool GettingNewTask;
    public int TechnicialSelected;
    public int NC_SellType;
    public int NC_CargoStockCurrent = 4;
    public int NC_CargoStockMax = 50;
    public int NC_CargoPricePerCrate = 3000;
    public int NC_SAIStockCurrent = 2;
    public int NC_SAIStockMax = 50;
    public int NC_SAIPricePerCrate = 2000;
    public int NC_PharStockCurrent = 4;
    public int NC_PharStockMax = 50;
    public int NC_PharPricePerCrate = 3500;
    public int NC_SportingGoodsStockCurrent = 16;
    public int NC_SportingGoodsStockMax = 50;
    public int NC_SportingGoodsPricePerCrate = 4400;
    public int NC_PrintCopyStockCurrent = 4;
    public int NC_PrintCopyStockMax = 50;
    public int NC_PrintCopyPricePerCrate = 7400;
    public int NC_CounterfeitStockCurrent = 8;
    public int NC_CounterfeitStockMax = 50;
    public int NC_CounterfeitPricePerCrate = 8800;
    public int NC_OrgProduceStockCurrent = 8;
    public int NC_OrgProduceStockMax = 50;
    public int NC_OrgProducePricePerCrate = 6200;
    public int NC_ClubType;
    public int NC_CelebAppearances = 15;
    public int NC_PlayerVisits = 3;
    private string NC_NightclubLocImg = "CLUB_TERMINAL";
    public float SS_Warehouse1Rating;
    public int SS_Warehouse1SalesMade;
    public int SS_Warehouse1SalesFailed;
    public int SS_Warehouse1LifetimeEarnings;
    public int SS_Warehouse1SpecialItems = 3;
    public float SS_Warehouse2Rating;
    public int SS_Warehouse2SalesMade;
    public int SS_Warehouse2SalesFailed;
    public int SS_Warehouse2LifetimeEarnings;
    public int SS_Warehouse2SpecialItems = 3;
    public float SS_Warehouse3Rating;
    public int SS_Warehouse3SalesMade;
    public int SS_Warehouse3SalesFailed;
    public int SS_Warehouse3LifetimeEarnings;
    public int SS_Warehouse3SpecialItems = 3;
    public float SS_Warehouse4Rating;
    public int SS_Warehouse4SalesMade;
    public int SS_Warehouse4SalesFailed;
    public int SS_Warehouse4LifetimeEarnings;
    public int SS_Warehouse4SpecialItems = 3;
    public float SS_Warehouse5Rating;
    public int SS_Warehouse5SalesMade;
    public int SS_Warehouse5SalesFailed;
    public int SS_Warehouse5LifetimeEarnings;
    public int SS_Warehouse5SpecialItems = 3;
    public string AHC_Name = "HKH191";
    public string AHC_Company = "Executive Office";
    public int AHC_MaxStock = 110;
    public int AHC_Size = 1;
    public bool ADV_LoadFirsttime;
    public bool ArcadeManagementGUIon;
    public bool ArcadeHubGUIon;
    public bool AH_LoadFirsttime;
    public int VehicleWarehouseBought = 1;
    public bool TestCaseOn;
    public Vector3 WarehouseExit;
    public int CurrentWarehouse;
    public bool IsIninterior;
    public Color mainColor;
    public int CratesToSpawn;
    public int Crt;
    public ScriptSettings CrateConfig;
    public int Source1Price;
    public int Source2Price;
    public int Source3Price;
    public int CratesToSource;
    public float CurrentStock;
    public float CurrentPrice;
    public List<Ped> SourceASellMissionPeds = new List<Ped>();
    public List<Vehicle> SourceASellMissionVehicles = new List<Vehicle>();
    public List<Prop> SourceASellMissionProps = new List<Prop>();
    public List<Blip> SourceASellMissionBlips = new List<Blip>();
    public Vector3 Points;
    public int Lastmodel;
    public int lastValidSkin;
    public bool SwitchModel;
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
    public List<SubBusinesses.Flare> SellPointsSmoke_Air = new List<SubBusinesses.Flare>();
    public List<SubBusinesses.Flare> SellPointsSmoke_Water = new List<SubBusinesses.Flare>();
    public List<SubBusinesses.Flare> Cargo = new List<SubBusinesses.Flare>();
    public List<Vector3> CargoDropped = new List<Vector3>();
    public List<int> SmokeParticles = new List<int>();
    public List<SubBusinesses.Flare> SmokePropaParticles = new List<SubBusinesses.Flare>();
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
    public List<SubBusinesses.SpawnH> BrickadeSpawnH = new List<SubBusinesses.SpawnH>()
    {
      new SubBusinesses.SpawnH(new Vector3(973.9282f, -1504.946f, 31.63f), 0.0f),
      new SubBusinesses.SpawnH(new Vector3(733.6379f, -1996.565f, 29.63f), 173f),
      new SubBusinesses.SpawnH(new Vector3(530.2698f, -1857.719f, 25.69f), 141f),
      new SubBusinesses.SpawnH(new Vector3(169.6421f, -1520.013f, 29.49f), 37f),
      new SubBusinesses.SpawnH(new Vector3(514.2137f, -571.242f, 25.2f), 174f),
      new SubBusinesses.SpawnH(new Vector3(63.69f, -398.55f, 40.26f), -20f),
      new SubBusinesses.SpawnH(new Vector3(-60.73f, -189.64f, 52.41f), 67f),
      new SubBusinesses.SpawnH(new Vector3(-208.2718f, 18.15f, 56.25f), 69f),
      new SubBusinesses.SpawnH(new Vector3(-335.56f, -1396.98f, 31.056f), -179f),
      new SubBusinesses.SpawnH(new Vector3(-240.74f, -1672.214f, 33.85f), -179f),
      new SubBusinesses.SpawnH(new Vector3(-260.43f, -2473.976f, 6.34f), -131f),
      new SubBusinesses.SpawnH(new Vector3(-84.05f, 97.36f, 73.22f), 68f)
    };
    public List<SubBusinesses.SpawnH> Cuban800SpawnH = new List<SubBusinesses.SpawnH>()
    {
      new SubBusinesses.SpawnH(new Vector3(-1042.79f, -3488.871f, 14.77f), 2.9f),
      new SubBusinesses.SpawnH(new Vector3(-1065.169f, -3471.22f, 14.77f), -7.7f),
      new SubBusinesses.SpawnH(new Vector3(-926.99f, -3096.54f, 14.57f), 98.11f),
      new SubBusinesses.SpawnH(new Vector3(-1218.016f, -2888.023f, 14.57f), 97.4f),
      new SubBusinesses.SpawnH(new Vector3(-1370.94f, -2421.087f, 14.57f), 90.7f),
      new SubBusinesses.SpawnH(new Vector3(-1710.592f, -3146.551f, 14.58f), 16.73f),
      new SubBusinesses.SpawnH(new Vector3(-1213.214f, -3364.88f, 14.57f), -10f)
    };
    public List<SubBusinesses.SpawnH> TugSpawnH = new List<SubBusinesses.SpawnH>()
    {
      new SubBusinesses.SpawnH(new Vector3(-481.78f, -2280.69f, 0.8f), 160f),
      new SubBusinesses.SpawnH(new Vector3(-298.94f, -2384.505f, 1.271f), -39.58f),
      new SubBusinesses.SpawnH(new Vector3(88.34f, -2266.75f, 0.81f), -92.05f),
      new SubBusinesses.SpawnH(new Vector3(-904.4f, -1448.64f, 0.93f), -68.98f),
      new SubBusinesses.SpawnH(new Vector3(92.466f, -2449.216f, 1.4f), 53.62f),
      new SubBusinesses.SpawnH(new Vector3(321.0196f, -2977.834f, 0.64f), -177f)
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
    public bool WaitingForRaid;
    public bool isAtRaidLocation;
    public Vector3 RaidLocation;
    public int RaidHour;
    public bool StartedRaid;
    public float SpawnAttackerTimer;
    public float Raidtimer;
    public Blip BlipItem_SetupMission;
    public int RaidEnemyTime;
    public int NextHour;
    public int CurrentTime;
    public int NextRaidTimer;
    public int CurrentRaidWarehouse;
    public int IndexRaidWarehouse;
    public int RaidCounter;

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
      this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
      this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      string str = "~" + this.Uicolour + "~";
      return this.HostName;
    }

    private void LoadMain(string iniName)
    {
      try
      {
        this.MainConfigFile = ScriptSettings.Load(iniName);
        this.ArcadiusBlip_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "ArcadiusBlip_Colour", this.ArcadiusBlip_Colour);
        this.ArcadiusMarkerColorString = this.MainConfigFile.GetValue<string>("Misc", "ArcadiusMarkerColor", this.ArcadiusMarkerColorString);
        if (this.ArcadiusMarkerColorString.Contains("ARGB"))
        {
          string[] strArray = this.ArcadiusMarkerColorString.Split(new string[1]
          {
            "_"
          }, StringSplitOptions.None);
          this.ArcadiusMarkerColor = Color.FromArgb(int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
        }
        if (!this.ArcadiusMarkerColorString.Contains("ARGB"))
          this.ArcadiusMarkerColor = Color.FromName(this.ArcadiusMarkerColorString);
        this.MazeBankBlip_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "MazeBankBlip_Colour", this.MazeBankBlip_Colour);
        this.MazeBankMarkerColorString = this.MainConfigFile.GetValue<string>("Misc", "MazeBankMarkerColor", this.MazeBankMarkerColorString);
        if (this.MazeBankMarkerColorString.Contains("ARGB"))
        {
          string[] strArray = this.MazeBankMarkerColorString.Split(new string[1]
          {
            "_"
          }, StringSplitOptions.None);
          this.MazeBankMarkerColor = Color.FromArgb(int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
        }
        if (!this.MazeBankMarkerColorString.Contains("ARGB"))
          this.MazeBankMarkerColor = Color.FromName(this.MazeBankMarkerColorString);
        this.MBWBlip_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "MBWBlip_Colour", this.MBWBlip_Colour);
        this.MBWMarkerColorString = this.MainConfigFile.GetValue<string>("Misc", "MBWsMarkerColor", this.MBWMarkerColorString);
        if (this.MBWMarkerColorString.Contains("ARGB"))
        {
          string[] strArray = this.MBWMarkerColorString.Split(new string[1]
          {
            "_"
          }, StringSplitOptions.None);
          this.MBWMarkerColor = Color.FromArgb(int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
        }
        if (!this.MBWMarkerColorString.Contains("ARGB"))
          this.MBWMarkerColor = Color.FromName(this.MBWMarkerColorString);
        this.LombokBlip_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "LombokBlip_Colour", this.LombokBlip_Colour);
        this.LombokMarkerColorString = this.MainConfigFile.GetValue<string>("Misc", "LombokMarkerColor", this.LombokMarkerColorString);
        if (this.LombokMarkerColorString.Contains("ARGB"))
        {
          string[] strArray = this.LombokMarkerColorString.Split(new string[1]
          {
            "_"
          }, StringSplitOptions.None);
          this.LombokMarkerColor = Color.FromArgb(int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
        }
        if (!this.LombokMarkerColorString.Contains("ARGB"))
          this.LombokMarkerColor = Color.FromName(this.LombokMarkerColorString);
        this.BusinessUpgradeIncreaseGain = this.MainConfigFile.GetValue<float>("Prices", "BusinessUpgradeIncreaseGain", this.BusinessUpgradeIncreaseGain);
        this.BusinessUpgradeBasePrice = this.MainConfigFile.GetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
        this.IncreaseStockMinAmount = this.MainConfigFile.GetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
        this.IncreaseStockMaxAmount = this.MainConfigFile.GetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
        this.DecreaseStockMinAmount = this.MainConfigFile.GetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
        this.DecreaseStockMaxAmount = this.MainConfigFile.GetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    private void DeliverPoints()
    {
      this.DropPoint.Add(new Vector3(966f, -126f, 74f));
      this.DropPoint.Add(new Vector3(200f, 383f, 107f));
      this.DropPoint.Add(new Vector3(-606f, 338f, 84f));
      this.DropPoint.Add(new Vector3(-606f, 338f, 84f));
      this.DropPoint.Add(new Vector3(-1539f, -76f, 53f));
      this.DropPoint.Add(new Vector3(-2077f, -313f, 12f));
      this.DropPoint.Add(new Vector3(-1451f, -364f, 43f));
      this.DropPoint.Add(new Vector3(-587f, -1112f, 22f));
      this.DropPoint.Add(new Vector3(-3153f, 1067f, 20f));
      this.DropPoint.Add(new Vector3(-3041f, 128f, 11f));
      this.DropPoint.Add(new Vector3(-2342f, 290f, 168f));
      this.DropPoint.Add(new Vector3(649f, 616f, (float) sbyte.MaxValue));
      this.DropPoint.Add(new Vector3(-1176f, -1774f, 3f));
      this.DropPoint.Add(new Vector3(-1395f, 53f, 53f));
      this.DropPoint.Add(new Vector3(-413f, 1181f, 325f));
      this.DropPoint.Add(new Vector3(2716f, 1362f, 24f));
      this.DropPoint.Add(new Vector3(-1134f, 2666f, 18f));
      this.DropPoint.Add(new Vector3(-1568f, 2777f, 17f));
      this.DropPoint.Add(new Vector3(1264f, -2585f, 43f));
      this.DropPoint.Add(new Vector3(1545f, -2107f, 77f));
      this.DropPoint.Add(new Vector3(2547f, -298f, 92f));
      this.DropPoint.Add(new Vector3(1369f, 1146f, 113f));
      this.DropPoint.Add(new Vector3(1504f, 1700f, 110f));
    }

    public void GetSubbusinessLocs()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.SubbusinessLoc = this.Config2.GetValue<int>("Setup", "SubbusinessLoc", this.SubbusinessLoc);
      this.SubbusinessBought = this.Config2.GetValue<int>("Setup", "SubbusinessBought", this.SubbusinessBought);
      if (this.SubbusinessLoc == 0)
      {
        this.SubbusinessLocVector3 = new Vector3(-520.1091f, -2903.51f, 5.5f);
        this.SubbusinessVehicleSpawn = new Vector3(-545.24f, -2855.945f, 6f);
        this.SubbusinessVehicleRot = -70f;
      }
      if (this.SubbusinessLoc == 1)
      {
        this.SubbusinessLocVector3 = new Vector3(138.37f, -2477.83f, 5f);
        this.SubbusinessVehicleSpawn = new Vector3(143.84f, -2499.6f, 6f);
        this.SubbusinessVehicleRot = 157f;
      }
      if (this.SubbusinessLoc == 2)
      {
        this.SubbusinessLocVector3 = new Vector3(669.66f, -2687.88f, 6f);
        this.SubbusinessVehicleSpawn = new Vector3(657.23f, -2671.37f, 6f);
        this.SubbusinessVehicleRot = 88f;
      }
      if (this.SubbusinessLoc == 3)
      {
        this.SubbusinessLocVector3 = new Vector3(1234.365f, -3202.3f, 5.2f);
        this.SubbusinessVehicleSpawn = new Vector3(1205.097f, -3199.153f, 5.5f);
        this.SubbusinessVehicleRot = 169f;
      }
      if (this.SubbusinessLoc == 4)
      {
        this.SubbusinessLocVector3 = new Vector3(990.93f, -2431.103f, 30.5f);
        this.SubbusinessVehicleSpawn = new Vector3(984.0623f, -2441.2f, 28f);
        this.SubbusinessVehicleRot = -6f;
      }
      if (this.SubbusinessLoc == 5)
      {
        this.SubbusinessLocVector3 = new Vector3(840.01f, -2230.9f, 29.5f);
        this.SubbusinessVehicleSpawn = new Vector3(826.511f, -2232.649f, 30f);
        this.SubbusinessVehicleRot = 84f;
      }
      if (this.SubbusinessLoc == 6)
      {
        this.SubbusinessLocVector3 = new Vector3(835.583f, -912.3167f, 24.5f);
        this.SubbusinessVehicleSpawn = new Vector3(821.7f, -913.5f, 25.9f);
        this.SubbusinessVehicleRot = -90f;
      }
      if (this.SubbusinessLoc == 7)
      {
        this.SubbusinessLocVector3 = new Vector3(496.01f, -637.144f, 23.6f);
        this.SubbusinessVehicleSpawn = new Vector3(496.0136f, -637.144f, 23.7f);
        this.SubbusinessVehicleRot = 86f;
      }
      if (this.SubbusinessLoc == 8)
      {
        this.SubbusinessLocVector3 = new Vector3(-320.7f, -1400.6f, 30.6f);
        this.SubbusinessVehicleSpawn = new Vector3(-340.39f, -1391.133f, 31f);
        this.SubbusinessVehicleRot = 177f;
      }
      if (this.SubbusinessLoc == 9)
      {
        this.SubbusinessLocVector3 = new Vector3(-1288.46f, -277.07f, 37.7f);
        this.SubbusinessVehicleSpawn = new Vector3(-1300.444f, -279.173f, 39.5f);
        this.SubbusinessVehicleRot = -61f;
      }
      if (this.SubbusinessLoc == 10)
      {
        this.SubbusinessLocVector3 = new Vector3(-960.5f, -1982.6f, 14.4f);
        this.SubbusinessVehicleSpawn = new Vector3(-964.6014f, -1962.887f, 13.5f);
        this.SubbusinessVehicleRot = -134f;
      }
      if (this.SubbusinessLoc == 11)
      {
        this.SubbusinessLocVector3 = new Vector3(-966.532f, -2068.965f, 8.5f);
        this.SubbusinessVehicleSpawn = new Vector3(-981.8f, -2061.234f, 9.7f);
        this.SubbusinessVehicleRot = -142f;
      }
      int subbusinessLoc1 = this.SubbusinessLoc;
      int subbusinessLoc2 = this.SubbusinessLoc;
      int subbusinessLoc3 = this.SubbusinessLoc;
      int subbusinessLoc4 = this.SubbusinessLoc;
      int subbusinessLoc5 = this.SubbusinessLoc;
    }

    public int GetCrateCountByID(int W)
    {
      int index1 = 0;
      for (int index2 = 0; index2 < this.CargoWarehouses.Count; ++index2)
      {
        if (this.SS_Warehouse1Index == index2 && W == 1)
          index1 = index2;
        if (this.SS_Warehouse2Index == index2 && W == 2)
          index1 = index2;
        if (this.SS_Warehouse3Index == index2 && W == 3)
          index1 = index2;
        if (this.SS_Warehouse4Index == index2 && W == 4)
          index1 = index2;
        if (this.SS_Warehouse5Index == index2 && W == 5)
          index1 = index2;
      }
      this.CurrentCratestotal = 0;
      this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + W.ToString() + ".ini");
      for (int index2 = 1; index2 <= 111; ++index2)
      {
        System.Random random = new System.Random();
        if (index2 < 17 && this.CargoWarehouses[index1].Maxcrates >= 16 && this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (index2 >= 17 && index2 < 43 && (this.CargoWarehouses[index1].Maxcrates >= 42 && this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), -1) != -1))
          ++this.CurrentCratestotal;
        else if (index2 >= 43 && this.CargoWarehouses[index1].Maxcrates >= 111 && this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
      }
      return this.CurrentCratestotal;
    }

    public int SetCrateCountByID(int W)
    {
      int index1 = 0;
      for (int index2 = 0; index2 < this.CargoWarehouses.Count; ++index2)
      {
        if (W == 1)
        {
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + W.ToString() + ".ini");
          for (int index3 = 1; index3 < 111; ++index3)
          {
            System.Random random = new System.Random();
            if (index3 < 17)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 17 && index3 < 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            Script.Wait(1);
          }
        }
        if (W == 2)
        {
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + W.ToString() + ".ini");
          for (int index3 = 1; index3 < 111; ++index3)
          {
            System.Random random = new System.Random();
            if (index3 < 17)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 17 && index3 < 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            Script.Wait(1);
          }
        }
        if (W == 3)
        {
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + W.ToString() + ".ini");
          for (int index3 = 1; index3 < 111; ++index3)
          {
            System.Random random = new System.Random();
            if (index3 < 17)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 17 && index3 < 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            Script.Wait(1);
          }
        }
        if (W == 4)
        {
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + W.ToString() + ".ini");
          for (int index3 = 1; index3 < 111; ++index3)
          {
            System.Random random = new System.Random();
            if (index3 < 17)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 17 && index3 < 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            Script.Wait(1);
          }
        }
        if (W == 5)
        {
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + W.ToString() + ".ini");
          for (int index3 = 1; index3 < 111; ++index3)
          {
            System.Random random = new System.Random();
            if (index3 < 17)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 17 && index3 < 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            if (index3 >= 43)
            {
              int num = -1;
              this.CrateConfig.SetValue<float>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), (float) num);
              this.CrateConfig.Save();
            }
            Script.Wait(1);
          }
        }
      }
      this.CurrentCratestotal = 0;
      this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + W.ToString() + ".ini");
      for (int index2 = 1; index2 <= 111; ++index2)
      {
        System.Random random = new System.Random();
        if (this.CargoWarehouses[index1].Maxcrates >= 16 && this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (this.CargoWarehouses[index1].Maxcrates >= 42 && this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (this.CargoWarehouses[index1].Maxcrates >= 111 && this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
      }
      return this.CurrentCratestotal;
    }

    public int GetCrateCountByIndex(int I, int W)
    {
      int index1 = I;
      this.CurrentCratestotal = 0;
      this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + W.ToString() + ".ini");
      for (int index2 = 1; index2 <= 111; ++index2)
      {
        System.Random random = new System.Random();
        if (this.CargoWarehouses[index1].Maxcrates >= 16 && this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (this.CargoWarehouses[index1].Maxcrates >= 42 && this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (this.CargoWarehouses[index1].Maxcrates >= 111 && this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
      }
      return this.CurrentCratestotal;
    }

    public int GetCrateCountByIndex(int I)
    {
      int index1 = I;
      int num = 0;
      for (int index2 = 0; index2 < this.CargoWarehouses.Count; ++index2)
      {
        if (this.SS_Warehouse1Index == I && this.GetWarehouseID(this.CurrentWarehouse) == 1)
          num = 1;
        if (this.SS_Warehouse2Index == I && this.GetWarehouseID(this.CurrentWarehouse) == 2)
          num = 2;
        if (this.SS_Warehouse3Index == I && this.GetWarehouseID(this.CurrentWarehouse) == 3)
          num = 3;
        if (this.SS_Warehouse4Index == I && this.GetWarehouseID(this.CurrentWarehouse) == 4)
          num = 4;
        if (this.SS_Warehouse5Index == I && this.GetWarehouseID(this.CurrentWarehouse) == 5)
          num = 5;
      }
      this.CurrentCratestotal = 0;
      this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + num.ToString() + ".ini");
      for (int index2 = 1; index2 <= 111; ++index2)
      {
        System.Random random = new System.Random();
        if (this.CargoWarehouses[index1].Maxcrates >= 16 && this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (this.CargoWarehouses[index1].Maxcrates >= 42 && this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (this.CargoWarehouses[index1].Maxcrates >= 111 && this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index2.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
      }
      return this.CurrentCratestotal;
    }

    public int GetCrateCountByIndex()
    {
      int currentWarehouse = this.CurrentWarehouse;
      this.CurrentCratestotal = 0;
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 1)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_1.ini");
        if (this.SS_Warehouse2Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 2)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_2.ini");
        if (this.SS_Warehouse3Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 3)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_3.ini");
        if (this.SS_Warehouse4Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 4)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_4.ini");
        if (this.SS_Warehouse5Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 5)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_5.ini");
      }
      for (int index = 1; index <= 111; ++index)
      {
        System.Random random = new System.Random();
        if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 16 && this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 42 && this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
        else if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 111 && this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
          ++this.CurrentCratestotal;
      }
      return this.CurrentCratestotal;
    }

    public float GetWarehouseValue()
    {
      float num1 = 0.0f;
      int currentWarehouse = this.CurrentWarehouse;
      this.CurrentCratestotal = 0;
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 1)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_1.ini");
        if (this.SS_Warehouse2Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 2)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_2.ini");
        if (this.SS_Warehouse3Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 3)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_3.ini");
        if (this.SS_Warehouse4Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 4)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_4.ini");
        if (this.SS_Warehouse5Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 5)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_5.ini");
      }
      for (int index = 1; index <= 111; ++index)
      {
        System.Random random = new System.Random();
        if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 16 && this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
        {
          int num2 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1);
          if (num2 < 42)
          {
            num1 += 25000f;
          }
          else
          {
            if (num2 == 43)
              num1 += 95000f;
            if (num2 == 44)
              num1 += 105000f;
            if (num2 == 45)
              num1 += 115000f;
            if (num2 == 46)
              num1 += 125000f;
            if (num2 == 47)
              num1 += 135000f;
            if (num2 == 48)
              num1 += 150000f;
          }
        }
        else if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 42 && this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
        {
          int num2 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1);
          if (num2 < 42)
          {
            num1 += 25000f;
          }
          else
          {
            if (num2 == 43)
              num1 += 95000f;
            if (num2 == 44)
              num1 += 105000f;
            if (num2 == 45)
              num1 += 115000f;
            if (num2 == 46)
              num1 += 125000f;
            if (num2 == 47)
              num1 += 135000f;
            if (num2 == 48)
              num1 += 150000f;
          }
        }
        else if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 111 && this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
        {
          int num2 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1);
          if (num2 < 42)
          {
            num1 += 25000f;
          }
          else
          {
            if (num2 == 43)
              num1 += 95000f;
            if (num2 == 44)
              num1 += 105000f;
            if (num2 == 45)
              num1 += 115000f;
            if (num2 == 46)
              num1 += 125000f;
            if (num2 == 47)
              num1 += 135000f;
            if (num2 == 48)
              num1 += 150000f;
          }
        }
      }
      return num1;
    }

    public float GetWarehouseValue(int CrateAmt)
    {
      float num1 = 0.0f;
      int currentWarehouse = this.CurrentWarehouse;
      int num2 = 0;
      this.CurrentCratestotal = 0;
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 1)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_1.ini");
        if (this.SS_Warehouse2Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 2)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_2.ini");
        if (this.SS_Warehouse3Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 3)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_3.ini");
        if (this.SS_Warehouse4Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 4)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_4.ini");
        if (this.SS_Warehouse5Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 5)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_5.ini");
      }
      for (int index = 1; index <= 111; ++index)
      {
        System.Random random = new System.Random();
        if (num2 < CrateAmt)
        {
          if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 16 && this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
          {
            ++num2;
            int num3 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1);
            if (num3 < 42)
            {
              num1 += 25000f;
            }
            else
            {
              if (num3 == 43)
                num1 += 95000f;
              if (num3 == 44)
                num1 += 105000f;
              if (num3 == 45)
                num1 += 115000f;
              if (num3 == 46)
                num1 += 125000f;
              if (num3 == 47)
                num1 += 135000f;
              if (num3 == 48)
                num1 += 150000f;
            }
            this.CrateConfig.SetValue<float>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1f);
            this.CrateConfig.Save();
          }
          else if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 42 && this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
          {
            ++num2;
            int num3 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1);
            if (num3 < 42)
            {
              num1 += 25000f;
            }
            else
            {
              if (num3 == 43)
                num1 += 95000f;
              if (num3 == 44)
                num1 += 105000f;
              if (num3 == 45)
                num1 += 115000f;
              if (num3 == 46)
                num1 += 125000f;
              if (num3 == 47)
                num1 += 135000f;
              if (num3 == 48)
                num1 += 150000f;
            }
            this.CrateConfig.SetValue<float>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1f);
            this.CrateConfig.Save();
          }
          else if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 111 && this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
          {
            ++num2;
            int num3 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1);
            if (num3 < 42)
            {
              num1 += 25000f;
            }
            else
            {
              if (num3 == 43)
                num1 += 95000f;
              if (num3 == 44)
                num1 += 105000f;
              if (num3 == 45)
                num1 += 115000f;
              if (num3 == 46)
                num1 += 125000f;
              if (num3 == 47)
                num1 += 135000f;
              if (num3 == 48)
                num1 += 150000f;
            }
            this.CrateConfig.SetValue<float>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1f);
            this.CrateConfig.Save();
          }
        }
      }
      return num1;
    }

    public float GetSpecialItemsCount()
    {
      int num1 = 0;
      int currentWarehouse = this.CurrentWarehouse;
      this.CurrentCratestotal = 0;
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 1)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_1.ini");
        if (this.SS_Warehouse2Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 2)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_2.ini");
        if (this.SS_Warehouse3Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 3)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_3.ini");
        if (this.SS_Warehouse4Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 4)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_4.ini");
        if (this.SS_Warehouse5Index == index && this.GetWarehouseID(this.CurrentWarehouse) == 5)
          this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_5.ini");
      }
      for (int index = 1; index <= 111; ++index)
      {
        System.Random random = new System.Random();
        if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 16 && this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
        {
          int num2 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1);
          if (num2 >= 42)
          {
            if (num2 == 43)
              ++num1;
            if (num2 == 44)
              ++num1;
            if (num2 == 45)
              ++num1;
            if (num2 == 46)
              ++num1;
            if (num2 == 47)
              ++num1;
            if (num2 == 48)
              ++num1;
          }
        }
        else if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 42 && this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
        {
          int num2 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1);
          if (num2 >= 42)
          {
            if (num2 == 43)
              ++num1;
            if (num2 == 44)
              ++num1;
            if (num2 == 45)
              ++num1;
            if (num2 == 46)
              ++num1;
            if (num2 == 47)
              ++num1;
            if (num2 == 48)
              ++num1;
          }
        }
        else if (this.CargoWarehouses[currentWarehouse].Maxcrates >= 111 && this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1) != -1)
        {
          int num2 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1);
          if (num2 >= 42)
          {
            if (num2 == 43)
              ++num1;
            if (num2 == 44)
              ++num1;
            if (num2 == 45)
              ++num1;
            if (num2 == 46)
              ++num1;
            if (num2 == 47)
              ++num1;
            if (num2 == 48)
              ++num1;
          }
        }
      }
      return (float) num1;
    }

    public void SetupSellStock(int Type)
    {
      this.Droptype = Type;
      foreach (Blip blip in this.DropBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      if ((Entity) this.DropVehicle != (Entity) null)
        this.DropVehicle.Delete();
      if (this.DropVehicleBlip != (Blip) null)
        this.DropVehicleBlip.Remove();
      this.DropVehicle = World.CreateVehicle((Model) VehicleHash.Brickade, this.SubbusinessVehicleSpawn, this.SubbusinessVehicleRot);
      this.DropVehicleBlip = World.CreateBlip(this.DropVehicle.Position);
      this.DropVehicleBlip.Sprite = BlipSprite.Truck;
      this.DropVehicleBlip.Name = "CEO Delivery Vehicle";
      this.DropVehicleBlip.Color = BlipColor.White;
      if (this.Droptype == 1)
      {
        this.amountToSell = (float) this.GemstonesProfit * (this.Gemstones_MultiplierPercent / 100f);
        this.StockAmount = this.GemstonesStock;
        UI.Notify(this.GetHostName() + " Ok Boss you have choosen to sell all ~b~Gemstones~w~ product, there is a Brickade parked near the Combined Vehicle Storage, if the Brickade gets destroyed, we lose everything! be careful");
        UI.Notify("Becuase Gemstones price on the market is at " + this.Gemstones_MultiplierPercent.ToString() + "%, our sell price is $" + this.amountToSell.ToString("N"));
      }
      if (this.Droptype == 2)
      {
        this.amountToSell = (float) this.MunitionsProfit * (this.Munitions_MultiplierPercent / 100f);
        this.StockAmount = this.MunitionsStock;
        UI.Notify("Becuase Narcotic price on the market is at " + this.Narcotic_MultiplierPercent.ToString() + "%, our sell price is $" + this.amountToSell.ToString("N"));
        UI.Notify(this.GetHostName() + " Ok Boss you have choosen to sell all ~b~Munitions ~w~ product, there is a Brickade parked near the Combined Vehicle Storage, if the Brickade gets destroyed, we lose everything! be careful");
        UI.Notify("Becuase Munitions price on the market is at " + this.Munitions_MultiplierPercent.ToString() + "%, our sell price is $" + this.amountToSell.ToString("N"));
      }
      if (this.Droptype == 3)
      {
        this.amountToSell = (float) this.NarcoticsProfit * (this.Narcotic_MultiplierPercent / 100f);
        this.StockAmount = this.NarcoticsStock;
        UI.Notify(this.GetHostName() + " Ok Boss you have choosen to sell all ~b~Narcotics~w~ product, there is a Brickade parked near the Combined Vehicle Storage, if the Brickade gets destroyed, we lose everything! be careful");
        UI.Notify("Becuase Narcotic price on the market is at " + this.Narcotic_MultiplierPercent.ToString() + "%, our sell price is $" + this.amountToSell.ToString("N"));
      }
      if (this.StockAmount < 30)
        this.DeliverPointsReq = 2;
      if (this.StockAmount >= 30 && this.StockAmount < 70)
        this.DeliverPointsReq = 3;
      if (this.StockAmount >= 70 && this.StockAmount < 120)
        this.DeliverPointsReq = 4;
      if (this.StockAmount >= 120 && this.StockAmount < 150)
        this.DeliverPointsReq = 5;
      if (this.StockAmount >= 150 && this.StockAmount < 190)
        this.DeliverPointsReq = 6;
      if (this.StockAmount >= 190 && this.StockAmount < 230)
        this.DeliverPointsReq = 7;
      if (this.StockAmount >= 230 && this.StockAmount < 260)
        this.DeliverPointsReq = 8;
      if (this.StockAmount >= 260 && this.StockAmount < 290)
        this.DeliverPointsReq = 9;
      if (this.StockAmount >= 290 && this.StockAmount < 330)
        this.DeliverPointsReq = 10;
      if (this.StockAmount >= 330 && this.StockAmount < 360)
        this.DeliverPointsReq = 12;
      if (this.StockAmount >= 360 && this.StockAmount < 400)
        this.DeliverPointsReq = 14;
      if (this.StockAmount >= 400)
        this.DeliverPointsReq = 16;
      this.DeliverPointsReqLeft = this.DeliverPointsReq;
      this.missionnum = 1;
      this.PointsBeenAt = 0;
      this.PlayingMission = true;
      UI.Notify("Office Assistant, ~b~Because your Stock Level is " + this.StockAmount.ToString() + ", you need to deliver to a minimum of " + this.DeliverPointsReq.ToString() + " drop points~w~, each drop point is indicated by a blue crate icon on your map, good luck");
      foreach (Vector3 position in this.DropPoint)
      {
        Blip blip = World.CreateBlip(position);
        blip.Sprite = BlipSprite.SpecialCargo;
        blip.Name = "Cargo Drop Point";
        blip.Color = BlipColor.Blue;
        this.DropBlip.Add(blip);
        blip.IsShortRange = true;
      }
    }

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Executive Business", "SubBusiness", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public SubBusinesses(int o)
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.Allstocks = new AllStocks();
      this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.CreateBanner();
      this.Setup();
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.purchaselvlMain = this.Config2.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvlMain);
      this.Now = this.GetDay();
      this.GetSubbusinessLocs();
    }

    public SubBusinesses()
    {
    }

    public void MainModRefresh()
    {
      this.GetSubbusinessLocs();
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
    }

    public void MainModDestroy()
    {
      foreach (Blip blip in this.DropBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      if ((Entity) this.DropVehicle != (Entity) null)
        this.DropVehicle.Delete();
      if (this.DropVehicleBlip != (Blip) null)
        this.DropVehicleBlip.Remove();
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.SubBusinessMarkerMB != (Blip) null)
        this.SubBusinessMarkerMB.Remove();
      if (this.SubBusinessMarkerA != (Blip) null)
        this.SubBusinessMarkerA.Remove();
      if (this.SubBusinessMarkerMBW != (Blip) null)
        this.SubBusinessMarkerMBW.Remove();
      if (this.SubBusinessMarkerL != (Blip) null)
        this.SubBusinessMarkerL.Remove();
      this.SetupMarkerMB();
    }

    public void SetupMarkerMB() => this.GetSubbusinessLocs();

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      Game.Player.Character.IsVisible = true;
      this.DeliverPoints();
      this.SetupPropsvec();
      this.SubLocExit = new Vector3(1026.01f, -3102.22f, -40f);
      this.SubLocMenu = new Vector3(994.125f, -3099.99f, -40f);
      this.WarehouseMenu = new MenuPool();
      this.Warehousemenus = new UIMenu("Warehouse Options", "Select an Option");
      this.Warehouse = this.WarehouseMenu.AddSubMenu(this.Warehousemenus, "Warehouse Options");
      this.GUIMenus.Add(this.Warehouse);
      this.WarehouseMenu.Add(this.Warehousemenus);
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Executive Business", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.Upgrades = this.modMenuPool.AddSubMenu(this.mainMenu, "Upgrade");
      this.GUIMenus.Add(this.Upgrades);
      this.Buy = this.modMenuPool.AddSubMenu(this.mainMenu, "Buy/Sell a Stock Licence");
      this.GUIMenus.Add(this.Buy);
      this.Import = this.modMenuPool.AddSubMenu(this.mainMenu, "Import Stock (Buy)");
      this.GUIMenus.Add(this.Import);
      this.Export = this.modMenuPool.AddSubMenu(this.mainMenu, "Export Stock (Sell)");
      this.GUIMenus.Add(this.Export);
      this.Details = this.modMenuPool.AddSubMenu(this.mainMenu, "Business Details");
      this.GUIMenus.Add(this.Details);
      this.modMenuPool.Add(this.mainMenu);
      this.SetupExport();
      this.SetupImport();
      this.SetupBuyBusiness();
      this.SetupMarkerMB();
      this.CrateProps();
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ex_exec_warehouse_placement_interior_2_int_warehouse_l_dlc_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ex_exec_warehouse_placement_interior_2_int_warehouse_l_dlc_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ex_exec_warehouse_placement_interior_1_int_warehouse_s_dlc_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ex_exec_warehouse_placement_interior_1_int_warehouse_s_dlc_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ex_exec_warehouse_placement_interior_0_int_warehouse_m_dlc_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ex_exec_warehouse_placement_interior_0_int_warehouse_m_dlc_milo_");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 1006.967, (InputArgument) -3102.079, (InputArgument) -39.0035);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "ex_prop_crate_ammo_bc");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "ex_prop_crate_ammo_sc");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "ex_prop_crate_art_02_bc");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "ex_prop_crate_art_02_sc");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "ex_prop_crate_art_bc");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "ex_prop_crate_art_sc");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public int GetCrateProp(string S)
    {
      int num = 0;
      string str = S;
      List<string> stringList = new List<string>();
      stringList.Add("ex_prop_crate_wlife_sc");
      stringList.Add("ex_prop_crate_wlife_bc");
      stringList.Add("ex_prop_crate_tob_sc");
      stringList.Add("ex_prop_crate_tob_bc");
      stringList.Add("ex_prop_crate_pharma_sc");
      stringList.Add("ex_prop_crate_pharma_bc");
      stringList.Add("ex_prop_crate_narc_sc");
      stringList.Add("ex_prop_crate_narc_bc");
      stringList.Add("ex_prop_crate_money_sc");
      stringList.Add("ex_prop_crate_money_bc");
      stringList.Add("ex_prop_crate_med_sc");
      stringList.Add("ex_prop_crate_med_bc");
      stringList.Add("ex_prop_crate_jewels_sc");
      stringList.Add("ex_prop_crate_jewels_racks_sc");
      stringList.Add("ex_prop_crate_jewels_racks_bc");
      stringList.Add("ex_prop_crate_jewels_bc");
      stringList.Add("ex_prop_crate_highend_pharma_sc");
      stringList.Add("ex_prop_crate_highend_pharma_bc");
      stringList.Add("ex_prop_crate_gems_sc");
      stringList.Add("ex_prop_crate_gems_bc");
      stringList.Add("ex_prop_crate_furjacket_sc");
      stringList.Add("ex_prop_crate_furjacket_bc");
      stringList.Add("ex_prop_crate_expl_sc");
      stringList.Add("ex_prop_crate_expl_bc");
      stringList.Add("ex_prop_crate_elec_sc");
      stringList.Add("ex_prop_crate_elec_bc");
      stringList.Add("ex_prop_crate_clothing_sc");
      stringList.Add("ex_prop_crate_clothing_bc");
      stringList.Add("ex_prop_crate_closed_sc");
      stringList.Add("ex_prop_crate_closed_rw.");
      stringList.Add("ex_prop_crate_closed_mw");
      stringList.Add("ex_prop_crate_closed_ms");
      stringList.Add("ex_prop_crate_closed_bc");
      stringList.Add("ex_prop_crate_bull_sc_02");
      stringList.Add("ex_prop_crate_bull_bc_02");
      stringList.Add("ex_prop_crate_biohazard_sc");
      stringList.Add("ex_prop_crate_biohazard_bc");
      stringList.Add("ex_prop_crate_art_sc");
      stringList.Add("ex_prop_crate_art_bc");
      stringList.Add("ex_prop_crate_art_02_sc");
      stringList.Add("ex_prop_crate_art_02_bc");
      stringList.Add("ex_prop_crate_ammo_sc");
      stringList.Add("ex_prop_crate_ammo_bc");
      stringList.Add("ex_prop_crate_freel");
      stringList.Add("ex_prop_crate_shide");
      stringList.Add("ex_prop_crate_minig");
      stringList.Add("ex_prop_crate_oegg");
      stringList.Add("ex_prop_crate_xldiam");
      stringList.Add("ex_prop_crate_watch");
      for (int index = 0; index < stringList.Count; ++index)
      {
        if (str.Equals(stringList[index]))
          num = index;
      }
      return num;
    }

    public string GetCrateProp(int I)
    {
      string str = "";
      List<string> stringList = new List<string>();
      stringList.Add("ex_prop_crate_wlife_sc");
      stringList.Add("ex_prop_crate_wlife_bc");
      stringList.Add("ex_prop_crate_tob_sc");
      stringList.Add("ex_prop_crate_tob_bc");
      stringList.Add("ex_prop_crate_pharma_sc");
      stringList.Add("ex_prop_crate_pharma_bc");
      stringList.Add("ex_prop_crate_narc_sc");
      stringList.Add("ex_prop_crate_narc_bc");
      stringList.Add("ex_prop_crate_money_sc");
      stringList.Add("ex_prop_crate_money_bc");
      stringList.Add("ex_prop_crate_med_sc");
      stringList.Add("ex_prop_crate_med_bc");
      stringList.Add("ex_prop_crate_jewels_sc");
      stringList.Add("ex_prop_crate_jewels_racks_sc");
      stringList.Add("ex_prop_crate_jewels_racks_bc");
      stringList.Add("ex_prop_crate_jewels_bc");
      stringList.Add("ex_prop_crate_highend_pharma_sc");
      stringList.Add("ex_prop_crate_highend_pharma_bc");
      stringList.Add("ex_prop_crate_gems_sc");
      stringList.Add("ex_prop_crate_gems_bc");
      stringList.Add("ex_prop_crate_furjacket_sc");
      stringList.Add("ex_prop_crate_furjacket_bc");
      stringList.Add("ex_prop_crate_expl_sc");
      stringList.Add("ex_prop_crate_expl_bc");
      stringList.Add("ex_prop_crate_elec_sc");
      stringList.Add("ex_prop_crate_elec_bc");
      stringList.Add("ex_prop_crate_clothing_sc");
      stringList.Add("ex_prop_crate_clothing_bc");
      stringList.Add("ex_prop_crate_closed_sc");
      stringList.Add("ex_prop_crate_closed_rw.");
      stringList.Add("ex_prop_crate_closed_mw");
      stringList.Add("ex_prop_crate_closed_ms");
      stringList.Add("ex_prop_crate_closed_bc");
      stringList.Add("ex_prop_crate_bull_sc_02");
      stringList.Add("ex_prop_crate_bull_bc_02");
      stringList.Add("ex_prop_crate_biohazard_sc");
      stringList.Add("ex_prop_crate_biohazard_bc");
      stringList.Add("ex_prop_crate_art_sc");
      stringList.Add("ex_prop_crate_art_bc");
      stringList.Add("ex_prop_crate_art_02_sc");
      stringList.Add("ex_prop_crate_art_02_bc");
      stringList.Add("ex_prop_crate_ammo_sc");
      stringList.Add("ex_prop_crate_ammo_bc");
      stringList.Add("ex_prop_crate_freel");
      stringList.Add("ex_prop_crate_shide");
      stringList.Add("ex_prop_crate_minig");
      stringList.Add("ex_prop_crate_oegg");
      stringList.Add("ex_prop_crate_xldiam");
      stringList.Add("ex_prop_crate_watch");
      for (int index = 0; index < stringList.Count; ++index)
        str = stringList[I];
      return str;
    }

    public void CrateProps()
    {
      if (this.CrateIds.Count > 0)
        this.CrateIds.Clear();
      this.CrateIds.Add("ex_prop_crate_xldiam");
      this.CrateIds.Add("ex_prop_crate_wlife_sc");
      this.CrateIds.Add("ex_prop_crate_wlife_bc");
      this.CrateIds.Add("ex_prop_crate_watch");
      this.CrateIds.Add("ex_prop_crate_tob_sc");
      this.CrateIds.Add("ex_prop_crate_tob_bc");
      this.CrateIds.Add("ex_prop_crate_shide");
      this.CrateIds.Add("ex_prop_crate_pharma_sc");
      this.CrateIds.Add("ex_prop_crate_pharma_bc");
      this.CrateIds.Add("ex_prop_crate_oegg");
      this.CrateIds.Add("ex_prop_crate_narc_sc");
      this.CrateIds.Add("ex_prop_crate_narc_bc");
      this.CrateIds.Add("ex_prop_crate_money_sc");
      this.CrateIds.Add("ex_prop_crate_money_bc");
      this.CrateIds.Add("ex_prop_crate_minig");
      this.CrateIds.Add("ex_prop_crate_med_sc");
      this.CrateIds.Add("ex_prop_crate_med_bc");
      this.CrateIds.Add("ex_prop_crate_jewels_sc");
      this.CrateIds.Add("ex_prop_crate_jewels_racks_sc");
      this.CrateIds.Add("ex_prop_crate_jewels_racks_bc");
      this.CrateIds.Add("ex_prop_crate_jewels_bc");
      this.CrateIds.Add("ex_prop_crate_highend_pharma_sc");
      this.CrateIds.Add("ex_prop_crate_highend_pharma_bc");
      this.CrateIds.Add("ex_prop_crate_gems_sc");
      this.CrateIds.Add("ex_prop_crate_gems_bc");
      this.CrateIds.Add("ex_prop_crate_furjacket_sc");
      this.CrateIds.Add("ex_prop_crate_furjacket_bc");
      this.CrateIds.Add("ex_prop_crate_freel");
      this.CrateIds.Add("ex_prop_crate_expl_sc");
      this.CrateIds.Add("ex_prop_crate_expl_bc");
      this.CrateIds.Add("ex_prop_crate_elec_sc");
      this.CrateIds.Add("ex_prop_crate_elec_bc");
      this.CrateIds.Add("ex_prop_crate_clothing_sc");
      this.CrateIds.Add("ex_prop_crate_clothing_bc");
      this.CrateIds.Add("ex_prop_crate_closed_sc");
      this.CrateIds.Add("ex_prop_crate_closed_rw.");
      this.CrateIds.Add("ex_prop_crate_closed_mw");
      this.CrateIds.Add("ex_prop_crate_closed_ms");
      this.CrateIds.Add("ex_prop_crate_closed_bc");
      this.CrateIds.Add("ex_prop_crate_bull_sc_02");
      this.CrateIds.Add("ex_prop_crate_bull_bc_02");
      this.CrateIds.Add("ex_prop_crate_biohazard_sc");
      this.CrateIds.Add("ex_prop_crate_biohazard_bc");
      this.CrateIds.Add("ex_prop_crate_art_sc");
      this.CrateIds.Add("ex_prop_crate_art_bc");
      this.CrateIds.Add("ex_prop_crate_art_02_sc");
      this.CrateIds.Add("ex_prop_crate_art_02_bc");
      this.CrateIds.Add("ex_prop_crate_ammo_sc");
      this.CrateIds.Add("ex_prop_crate_ammo_bc");
    }

    public void SpawnCrates(string Crate, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Crate);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        World.CreateProp(model, Pos, Rot, true, false);
        foreach (Prop nearbyProp in World.GetNearbyProps(Pos, 10f, model))
          this.Props.Add(nearbyProp);
      }
      model.MarkAsNoLongerNeeded();
    }

    public void SetupPropsvec() => this.pPosition.Add(new Vector3(1018f, -3102f, -38f));

    public void OnShutdown()
    {
      bool flag = true;
      if (!flag || !flag)
        return;
      if (this.BlipItem_SetupMission != (Blip) null)
        this.BlipItem_SetupMission.Remove();
      foreach (SubBusinesses.Flare flare in this.SellPointsSmoke_Water)
      {
        if ((Entity) flare.FlareProp != (Entity) null)
        {
          Function.Call(Hash._0x8F75998877616996, (InputArgument) flare.FlareID_1, (InputArgument) false);
          flare.FlareProp.Delete();
        }
      }
      foreach (SubBusinesses.Flare flare in this.SellPointsSmoke_Air)
      {
        if ((Entity) flare.FlareProp != (Entity) null)
        {
          Function.Call(Hash._0x8F75998877616996, (InputArgument) flare.FlareID_1, (InputArgument) false);
          flare.FlareProp.Delete();
        }
      }
      foreach (SubBusinesses.Flare flare in this.Cargo)
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
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.CargoWarehouses[index].blip != (Blip) null)
          this.CargoWarehouses[index].blip.Remove();
      }
      foreach (SubBusinesses.Flare flare in this.SellPointsSmoke_Water)
      {
        if ((Entity) flare.FlareProp != (Entity) null)
        {
          Function.Call(Hash._0x8F75998877616996, (InputArgument) flare.FlareID_1, (InputArgument) false);
          flare.FlareProp.Delete();
        }
      }
      foreach (SubBusinesses.Flare flare in this.SellPointsSmoke_Air)
      {
        if ((Entity) flare.FlareProp != (Entity) null)
        {
          Function.Call(Hash._0x8F75998877616996, (InputArgument) flare.FlareID_1, (InputArgument) false);
          flare.FlareProp.Delete();
        }
      }
      foreach (SubBusinesses.Flare flare in this.Cargo)
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
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.CargoWarehouses[index].blip != (Blip) null)
          this.CargoWarehouses[index].blip.Remove();
      }
      if ((Entity) this.ChairProp_3 != (Entity) null)
        this.ChairProp_3.Delete();
      if ((Entity) this.ChairProp_2 != (Entity) null)
        this.ChairProp_2.Delete();
      if ((Entity) this.ChairProp_1 != (Entity) null)
        this.ChairProp_1.Delete();
      foreach (Blip blip in this.DropBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      if ((Entity) this.DropVehicle != (Entity) null)
        this.DropVehicle.Delete();
      if (this.DropVehicleBlip != (Blip) null)
        this.DropVehicleBlip.Remove();
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.SubBusinessMarkerMB != (Blip) null)
        this.SubBusinessMarkerMB.Remove();
      if (this.SubBusinessMarkerA != (Blip) null)
        this.SubBusinessMarkerA.Remove();
      if (this.SubBusinessMarkerMBW != (Blip) null)
        this.SubBusinessMarkerMBW.Remove();
      if (!(this.SubBusinessMarkerL != (Blip) null))
        return;
      this.SubBusinessMarkerL.Remove();
    }

    private void LoadIniFile3(string iniName)
    {
      try
      {
        this.Config3 = ScriptSettings.Load(iniName);
        this.purchaselvl = this.Config3.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: " + iniName + ".ini Failed To Load.");
      }
    }

    private void LoadIniFile(string iniName)
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

    private void LoadIniFile2(string iniName)
    {
      try
      {
        this.Config2 = ScriptSettings.Load(iniName);
        this.purchaselvlMain = this.Config2.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvlMain);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public void SetupImport()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.Import, "Import Narcotics");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.Import, "Import Gemstones");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.Import, "Import Munitions");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem NBuy1 = new UIMenuItem("X1: $45,000 x " + (this.Narcotic_MultiplierPercent / 100f).ToString() + "%");
      uiMenu1.AddItem(NBuy1);
      UIMenuItem NBuy2 = new UIMenuItem("X10: $450,000 x " + (this.Narcotic_MultiplierPercent / 100f).ToString() + "%");
      uiMenu1.AddItem(NBuy2);
      UIMenuItem NMarketV = new UIMenuItem("Get Narcotic Market Value");
      uiMenu1.AddItem(NMarketV);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == NMarketV)
          UI.Notify(this.GetHostName() + " Becuase ~b~Narcotic~w~ price on the market is at " + this.Narcotic_MultiplierPercent.ToString() + "%, our Buy price is ~b~$" + ((float) (45000.0 * ((double) this.Narcotic_MultiplierPercent / 100.0))).ToString("N") + "~w~ for ~b~x1~w~, and ~b~$" + ((float) (450000.0 * ((double) this.Narcotic_MultiplierPercent / 100.0))).ToString("N") + "~w~ for ~b~x10~w~");
        if (item == NBuy1)
        {
          if (this.NarcoticsBusinessBought == 1)
          {
            if (Game.Player.Money >= (int) (45000.0 * ((double) this.Narcotic_MultiplierPercent / 100.0)))
            {
              if (this.NarcoticsStock + 1 <= this.maxstocks && this.NarcoticsStock + 1 <= this.WarehouseMax)
              {
                Game.Player.Money -= (int) (45000.0 * ((double) this.Narcotic_MultiplierPercent / 100.0));
                ++this.NarcoticsStock;
                this.NarcoticsProfit += 22500;
                this.Config.SetValue<int>("Narcotics", "NStock", this.NarcoticsStock);
                this.Config.SetValue<int>("Narcotics", "NPROFIT", this.NarcoticsProfit);
                this.Config.Save();
                UI.Notify(this.GetHostName() + " Narcotics Stock: " + this.Config.GetValue<int>("Narcotics", "NStock", this.NarcoticsStock).ToString() + "/" + this.maxstocks.ToString());
              }
              else
              {
                UI.Notify(this.GetHostName() + " Sorry boss we have reached the max capacity for this warehouse, please either buy or use a larger warehouse");
                Script.Wait(500);
                UI.Notify(this.GetHostName() + " ~b~ OR ~w~ we have reached max capacity for this level, upgrade the business to continue");
              }
            }
            else
              UI.Notify(this.GetHostName() + " Sorry boss you dont have enough money to purchase stock for this sub business");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you don't own this sub business");
        }
        if (item != NBuy2)
          return;
        if (this.NarcoticsBusinessBought == 1)
        {
          if (Game.Player.Money >= (int) (450000.0 * ((double) this.Narcotic_MultiplierPercent / 100.0)))
          {
            if (this.NarcoticsStock + 10 <= this.maxstocks && this.NarcoticsStock + 10 <= this.WarehouseMax)
            {
              Game.Player.Money -= (int) (450000.0 * ((double) this.Narcotic_MultiplierPercent / 100.0));
              this.NarcoticsStock += 10;
              this.NarcoticsProfit += 225000;
              this.Config.SetValue<int>("Narcotics", "NStock", this.NarcoticsStock);
              this.Config.SetValue<int>("Narcotics", "NPROFIT", this.NarcoticsProfit);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " Narcotics Stock: " + this.Config.GetValue<int>("Narcotics", "NStock", this.NarcoticsStock).ToString() + "/" + this.maxstocks.ToString());
            }
            else
            {
              UI.Notify(this.GetHostName() + " Sorry boss we have reached the max capacity for this warehouse, please either buy or use a larger warehouse");
              Script.Wait(500);
              UI.Notify(this.GetHostName() + " ~b~ OR ~w~ we have reached max capacity for this level, upgrade the business to continue");
            }
          }
          else
            UI.Notify(this.GetHostName() + " Narcotics Sorry boss you dont have enough money to purchase stock for this sub business");
        }
        else
          UI.Notify(this.GetHostName() + " Sorry boss you don't own this sub business");
      });
      UIMenuItem GBuy1 = new UIMenuItem("X1: $145,000  x " + (this.Gemstones_MultiplierPercent / 100f).ToString() + "%");
      uiMenu2.AddItem(GBuy1);
      UIMenuItem GBuy2 = new UIMenuItem("X10: $1,450,000 x " + (this.Gemstones_MultiplierPercent / 100f).ToString() + "%");
      uiMenu2.AddItem(GBuy2);
      UIMenuItem GMarketV = new UIMenuItem("Get Gemstones Market Value");
      uiMenu2.AddItem(GMarketV);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == GMarketV)
          UI.Notify(this.GetHostName() + " Becuase ~b~Gemstones~w~ price on the market is at " + this.Gemstones_MultiplierPercent.ToString() + "%, our Buy price is ~b~$" + ((float) (145000.0 * ((double) this.Gemstones_MultiplierPercent / 100.0))).ToString("N") + "~w~ for ~b~x1~w~, and ~b~$" + ((float) (1450000.0 * ((double) this.Gemstones_MultiplierPercent / 100.0))).ToString("N") + "~w~ for ~b~x10~w~");
        if (item == GBuy1)
        {
          if (this.GemstonesBusinessBought == 1)
          {
            if (Game.Player.Money >= (int) (145000.0 * ((double) this.Gemstones_MultiplierPercent / 100.0)))
            {
              if (this.GemstonesStock + 1 <= this.maxstocks && this.GemstonesStock + 1 <= this.WarehouseMax)
              {
                Game.Player.Money -= (int) (145000.0 * ((double) this.Gemstones_MultiplierPercent / 100.0));
                ++this.GemstonesStock;
                this.GemstonesProfit += 75000;
                this.Config.SetValue<int>("GEMSTONES", "GPROFIT", this.GemstonesProfit);
                this.Config.SetValue<int>("GEMSTONES", "GStock", this.GemstonesStock);
                this.Config.Save();
                UI.Notify(this.GetHostName() + " Gemstones Stock: " + this.Config.GetValue<int>("GEMSTONES", "GStock", this.GemstonesStock).ToString() + "/" + this.maxstocks.ToString());
              }
              else
              {
                UI.Notify(this.GetHostName() + " Sorry boss we have reached the max capacity for this warehouse, please either buy or use a larger warehouse");
                Script.Wait(500);
                UI.Notify(this.GetHostName() + " ~b~ OR ~w~ we have reached max capacity for this level, upgrade the business to continue");
              }
            }
            else
              UI.Notify(this.GetHostName() + " Sorry boss you dont have enough money to purchase stock for this sub business");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you don't own this sub business");
        }
        if (item != GBuy2)
          return;
        if (this.GemstonesBusinessBought == 1)
        {
          if (Game.Player.Money >= (int) (1450000.0 * ((double) this.Gemstones_MultiplierPercent / 100.0)))
          {
            if (this.GemstonesStock + 10 <= this.maxstocks && this.GemstonesStock + 10 <= this.WarehouseMax)
            {
              Game.Player.Money -= (int) (1450000.0 * ((double) this.Gemstones_MultiplierPercent / 100.0));
              this.GemstonesStock += 10;
              this.GemstonesProfit += 722500;
              this.Config.SetValue<int>("GEMSTONES", "GPROFIT", this.GemstonesProfit);
              this.Config.SetValue<int>("GEMSTONES", "GStock", this.GemstonesStock);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " Gemstones Stock: " + this.Config.GetValue<int>("GEMSTONES", "GStock", this.GemstonesStock).ToString() + "/" + this.maxstocks.ToString());
            }
            else
            {
              UI.Notify(this.GetHostName() + " Sorry boss we have reached the max capacity for this warehouse, please either buy or use a larger warehouse");
              Script.Wait(500);
              UI.Notify(this.GetHostName() + " ~b~ OR ~w~ we have reached max capacity for this level, upgrade the business to continue");
            }
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you dont have enough money to purchase stock for this sub business");
        }
        else
          UI.Notify(this.GetHostName() + " Sorry boss you don't own this sub business");
      });
      UIMenuItem MBuy1 = new UIMenuItem("X1: $99,000 x " + (this.Munitions_MultiplierPercent / 100f).ToString() + "%");
      uiMenu3.AddItem(MBuy1);
      UIMenuItem MBuy2 = new UIMenuItem("X10: $990,000 x " + (this.Munitions_MultiplierPercent / 100f).ToString() + "%");
      uiMenu3.AddItem(MBuy2);
      UIMenuItem MMarketV = new UIMenuItem("Get Munitions Market Value");
      uiMenu3.AddItem(MMarketV);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == MMarketV)
          UI.Notify(this.GetHostName() + " Becuase ~b~Munitions~w~ price on the market is at " + this.Munitions_MultiplierPercent.ToString() + "%, our Buy price is ~b~$" + ((float) (99000.0 * ((double) this.Munitions_MultiplierPercent / 100.0))).ToString("N") + "~w~ for ~b~x1~w~, and ~b~$" + ((float) (990000.0 * ((double) this.Munitions_MultiplierPercent / 100.0))).ToString("N") + "~w~ for ~b~x10~w~");
        if (item == MBuy1)
        {
          if (this.MunitionsBusinessBought == 1)
          {
            if (Game.Player.Money >= (int) (99000.0 * ((double) this.Munitions_MultiplierPercent / 100.0)))
            {
              if (this.MunitionsStock + 1 <= this.maxstocks && this.MunitionsStock + 1 <= this.WarehouseMax)
              {
                Game.Player.Money -= (int) (99000.0 * ((double) this.Munitions_MultiplierPercent / 100.0));
                ++this.MunitionsStock;
                this.MunitionsProfit += 49500;
                this.Config.SetValue<int>("MUNITIONS", "MSTOCK", this.MunitionsStock);
                this.Config.SetValue<int>("MUNITIONS", "MPROFIT", this.MunitionsProfit);
                this.Config.Save();
                UI.Notify(this.GetHostName() + " Munitions Stock: " + this.Config.GetValue<int>("MUNITIONS", "MSTOCK", this.MunitionsStock).ToString() + "/" + this.maxstocks.ToString());
              }
              else
              {
                UI.Notify(this.GetHostName() + " Sorry boss we have reached the max capacity for this warehouse, please either buy or use a larger warehouse");
                Script.Wait(500);
                UI.Notify(this.GetHostName() + " ~b~ OR ~w~ we have reached max capacity for this level, upgrade the business to continue");
              }
            }
            else
              UI.Notify(this.GetHostName() + " Sorry boss you dont have enough money to purchase stock for this sub business");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you don't own this sub business");
        }
        if (item != MBuy2)
          return;
        if (this.MunitionsBusinessBought == 1)
        {
          if (Game.Player.Money >= (int) (990000.0 * ((double) this.Munitions_MultiplierPercent / 100.0)))
          {
            if (this.MunitionsStock + 10 <= this.maxstocks && this.MunitionsStock + 10 <= this.WarehouseMax)
            {
              Game.Player.Money -= (int) (990000.0 * ((double) this.Munitions_MultiplierPercent / 100.0));
              this.MunitionsStock += 10;
              this.MunitionsProfit += 495000;
              this.Config.SetValue<int>("MUNITIONS", "MSTOCK", this.MunitionsStock);
              this.Config.SetValue<int>("MUNITIONS", "MPROFIT", this.MunitionsProfit);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " Munitions Stock: " + this.Config.GetValue<int>("MUNITIONS", "MSTOCK", this.MunitionsStock).ToString() + "/" + this.maxstocks.ToString());
            }
            else
            {
              UI.Notify(this.GetHostName() + " Sorry boss we have reached the max capacity for this warehouse, please either buy or use a larger warehouse");
              Script.Wait(500);
              UI.Notify(this.GetHostName() + " ~b~ OR ~w~ we have reached max capacity for this level, upgrade the business to continue");
            }
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you dont have enough money to purchase stock for this sub business");
        }
        else
          UI.Notify(this.GetHostName() + " Sorry boss you don't own this sub business");
      });
    }

    public void SetupExport()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Export, "Export Goods");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem N = new UIMenuItem("Export All Narcotics");
      uiMenu.AddItem(N);
      UIMenuItem G = new UIMenuItem("Export All Gemstones");
      uiMenu.AddItem(G);
      UIMenuItem M = new UIMenuItem("Export All Munitions");
      uiMenu.AddItem(M);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == N)
        {
          if (this.NarcoticsStock != 0)
          {
            this.SetupSellStock(3);
            this.NarcoticsProfit = 0;
            this.NarcoticsStock = 0;
            this.Config.SetValue<int>("Narcotics", "NPROFIT", this.NarcoticsProfit);
            this.Config.SetValue<int>("Narcotics", "NStock", this.NarcoticsStock);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You cannot sell, with no stock!");
        }
        if (item == G)
        {
          if (this.GemstonesStock != 0)
          {
            this.SetupSellStock(1);
            this.GemstonesProfit = 0;
            this.GemstonesStock = 0;
            this.Config.SetValue<int>("GEMSTONES", "GPROFIT", this.GemstonesProfit);
            this.Config.SetValue<int>("GEMSTONES", "GStock", this.GemstonesStock);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You cannot sell, with no stock!");
        }
        if (item != M)
          return;
        if (this.MunitionsStock != 0)
        {
          this.SetupSellStock(2);
          this.MunitionsProfit = 0;
          this.MunitionsStock = 0;
          this.Config.SetValue<int>("MUNITIONS", "MSTOCK", this.MunitionsStock);
          this.Config.SetValue<int>("MUNITIONS", "MPROFIT", this.MunitionsProfit);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " You cannot sell, with no stock!");
      });
    }

    public void SetupBuyBusiness()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.Buy, "Buy/Sell Narcotics Stock Licence");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.Buy, "Buy/Sell Gemstones Stock Licence");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.Buy, "Buy/Sell Munitions Stock Licence");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem Buy1 = new UIMenuItem("Buy: $2,250,000");
      uiMenu1.AddItem(Buy1);
      UIMenuItem Sell1 = new UIMenuItem("Sell ");
      uiMenu1.AddItem(Sell1);
      UIMenuItem Buy2 = new UIMenuItem("Buy: $3,000,000");
      uiMenu2.AddItem(Buy2);
      UIMenuItem Sell2 = new UIMenuItem("Sell ");
      uiMenu2.AddItem(Sell2);
      UIMenuItem Buy3 = new UIMenuItem("Buy: $2,750,000");
      uiMenu3.AddItem(Buy3);
      UIMenuItem Sell3 = new UIMenuItem("Sell ");
      uiMenu3.AddItem(Sell3);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Buy1)
        {
          if (Game.Player.Money >= 2250000)
          {
            Game.Player.Money -= 2250000;
            this.NarcoticsBusinessBought = 1;
            this.Config.SetValue<int>("Narcotics", "NBBought", this.NarcoticsBusinessBought);
            this.Config.Save();
            UI.Notify(this.GetHostName() + " Ok Boss, i am organising the Setup of a Subbusiness, we will need to purchase a Licence to purchase each stock type ");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you dont have enough money to purchase this sub business");
        }
        if (item != Sell1)
          return;
        this.NarcoticsBusinessBought = 0;
        this.Config.SetValue<int>("Narcotics", "NBBought", this.NarcoticsBusinessBought);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " ok i can arange to sell this sub business");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Buy2)
        {
          if (Game.Player.Money >= 3000000)
          {
            this.Config.Save();
            Game.Player.Money -= 3000000;
            this.GemstonesBusinessBought = 1;
            this.Config.SetValue<int>("Gemstones", "GBBought", this.GemstonesBusinessBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you dont have enough money to purchase this sub business");
        }
        if (item != Sell2)
          return;
        this.GemstonesBusinessBought = 0;
        this.Config.SetValue<int>("Gemstones", "GBBought", this.GemstonesBusinessBought);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " ok i can arange to sell this sub business");
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Buy3)
        {
          if (Game.Player.Money >= 2750000)
          {
            Game.Player.Money -= 2750000;
            this.MunitionsBusinessBought = 1;
            this.Config.SetValue<int>("Munitions", "MBBought", this.MunitionsBusinessBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you dont have enough money to purchase this sub business");
        }
        if (item != Sell3)
          return;
        this.MunitionsBusinessBought = 0;
        this.Config.SetValue<int>("Munitions", "MBBought", this.MunitionsBusinessBought);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " ok i can arange to sell this sub business");
      });
    }

    public void GetDateRelative()
    {
      if (!this.BYPASS_NOSAVE_OR_CRASH || this.Now == this.GetDay())
        return;
      this.Now = this.GetDay();
      int num1 = this.GetDay() + this.DAYSTORESET_UPDATETIME;
      int num2 = this.GetMonth();
      int year = this.GetYear();
      if (num1 < 0)
      {
        num1 = -num1;
        if (this.GetMonth() + 1 <= 12)
          num2 = this.GetMonth() + 1;
        if (this.GetMonth() + 1 > 12)
          num2 = 1;
      }
      if (num1 > 30)
        num1 = 30;
      if (this.GetMonth() + 1 > 12)
        num2 = 1;
      if ((num1 > this.NextDay || num2 > this.NextMonth) && (num2 >= this.NextMonth && num2 <= this.NextMonth) && year == this.NextYear)
        return;
      this.NextMonth = this.GetMonth();
      this.NextDay = this.GetDay() + this.DaysWait;
      this.NextYear = this.GetYear();
      this.Config2.SetValue<int>("Setup", "NextYear", this.NextYear);
      this.Config2.SetValue<int>("Setup", "NextDay", this.NextDay);
      this.Config2.SetValue<int>("Setup", "NextMonth", this.NextMonth);
      this.Config2.Save();
    }

    public void GetDateRelative2()
    {
      if (!this.BYPASS_NOSAVE_OR_CRASH || this.Now == this.GetDay())
        return;
      this.Now = this.GetDay();
      int num1 = this.GetDay() + 1;
      int num2 = this.GetMonth();
      int year = this.GetYear();
      if (num1 < 0)
      {
        num1 = -num1;
        if (this.GetMonth() + 1 <= 12)
          num2 = this.GetMonth() + 1;
        if (this.GetMonth() + 1 > 12)
          num2 = 1;
      }
      if (num1 > 30)
        num1 = 30;
      if (this.GetMonth() + 1 > 12)
        num2 = 1;
      if ((num1 > this.NextDay2 || num2 > this.NextMonth2) && (num2 >= this.NextMonth2 && num2 <= this.NextMonth2) && year == this.NextYear2)
        return;
      this.NextMonth2 = this.GetMonth();
      this.NextDay2 = this.GetDay() + this.DaysWait;
      this.NextYear2 = this.GetYear();
    }

    public int GetHour() => Function.Call<int>(Hash._0x25223CA6B4D20B7F);

    public int GetMinutes() => Function.Call<int>(Hash._0x13D2B8ADD79640F2);

    public int GetDay() => Function.Call<int>(Hash._0x3D10BC92A4DB1D35);

    public int GetMonth() => Function.Call<int>(Hash._0xBBC72712E80257A1);

    public int GetYear() => Function.Call<int>(Hash._0x961777E64BDAF717);

    public void SetDate()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      if (this.GetDay() + this.DaysWait <= 30)
      {
        this.NextDay = this.GetDay() + this.DaysWait;
        this.NextMonth = this.GetMonth();
      }
      if (this.GetDay() + this.DaysWait > 30)
      {
        this.NextDay = -(30 - (this.GetDay() + this.DaysWait));
        if (this.GetMonth() + 1 <= 12)
          this.NextMonth = this.GetDay() + 1;
        if (this.GetMonth() + 1 > 12)
          this.NextMonth = 1;
      }
      this.NextYear = this.GetYear();
      System.Random random = new System.Random();
      this.Config2.SetValue<int>("Setup", "NextYear", this.NextYear);
      this.Config2.SetValue<int>("Setup", "NextDay", this.NextDay);
      this.Config2.SetValue<int>("Setup", "NextMonth", this.NextMonth);
      this.Config2.Save();
    }

    public void SetDate2()
    {
      if (this.GetDay() + this.DaysWait <= 30)
      {
        this.NextDay2 = this.GetDay() + this.DaysWait;
        this.NextMonth2 = this.GetMonth();
      }
      if (this.GetDay() + this.DaysWait > 30)
      {
        this.NextDay2 = -(30 - (this.GetDay() + this.DaysWait));
        if (this.GetMonth() + 1 <= 12)
          this.NextMonth2 = this.GetDay() + 1;
        if (this.GetMonth() + 1 > 12)
          this.NextMonth2 = 1;
      }
      this.NextYear2 = this.GetYear();
    }

    public Model RequestModel(string Prop)
    {
      Model model = new Model(Prop);
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

    public Model RequestModel(int Prop)
    {
      Model model = new Model(Prop);
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

    public Model RequestModel(VehicleHash Prop)
    {
      Model model = new Model(Prop);
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

    public Model RequestModel(PedHash Prop)
    {
      Model model = new Model(Prop);
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

    public void NC_CheckTasks(int TC, int TSK)
    {
      if (TC == 0)
      {
        if (this.NC_Technician1Task == TSK)
        {
          this.ShowingOverlay = true;
          this.OverlayIndex = 3;
          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot assign a task that current technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
        }
        if (this.TechnicialSelected == TC && (this.NC_Technician2Task == TSK || this.NC_Technician3Task == TSK || (this.NC_Technician4Task == TSK || this.NC_Technician5Task == TSK)))
        {
          this.ShowingOverlay = true;
          this.OverlayIndex = 3;
          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot Assign a task that another technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
        }
      }
      if (TC == 1)
      {
        if (this.NC_Technician1Task == TSK)
        {
          this.ShowingOverlay = true;
          this.OverlayIndex = 3;
          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot assign a task that current technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
        }
        if (this.TechnicialSelected == TC && (this.NC_Technician1Task == TSK || this.NC_Technician3Task == TSK || (this.NC_Technician4Task == TSK || this.NC_Technician5Task == TSK)))
        {
          this.ShowingOverlay = true;
          this.OverlayIndex = 3;
          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot Assign a task that another technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
        }
      }
      if (TC == 2)
      {
        if (this.NC_Technician1Task == TSK)
        {
          this.ShowingOverlay = true;
          this.OverlayIndex = 3;
          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot assign a task that current technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
        }
        if (this.TechnicialSelected == TC && (this.NC_Technician2Task == TSK || this.NC_Technician1Task == TSK || (this.NC_Technician4Task == TSK || this.NC_Technician5Task == TSK)))
        {
          this.ShowingOverlay = true;
          this.OverlayIndex = 3;
          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot Assign a task that another technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
        }
      }
      if (TC == 3)
      {
        if (this.NC_Technician1Task == TSK)
        {
          this.ShowingOverlay = true;
          this.OverlayIndex = 3;
          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot assign a task that current technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
        }
        if (this.TechnicialSelected == TC && (this.NC_Technician2Task == TSK || this.NC_Technician3Task == TSK || (this.NC_Technician1Task == TSK || this.NC_Technician5Task == TSK)))
        {
          this.ShowingOverlay = true;
          this.OverlayIndex = 3;
          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot Assign a task that another technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
        }
      }
      if (TC != 4)
        return;
      if (this.NC_Technician1Task == TSK)
      {
        this.ShowingOverlay = true;
        this.OverlayIndex = 3;
        this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot assign a task that current technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
      }
      if (this.TechnicialSelected != TC || this.NC_Technician2Task != TSK && this.NC_Technician3Task != TSK && (this.NC_Technician4Task != TSK && this.NC_Technician1Task != TSK))
        return;
      this.ShowingOverlay = true;
      this.OverlayIndex = 3;
      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Cannot Assign a task that another technician already Has assigned", (object) "Cancel", (object) "OK", (object) 0);
    }

    public int joaat(string S) => Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) S);

    private int func_280(int iParam0)
    {
      switch (iParam0)
      {
        case 1:
        case 2:
        case 3:
          return this.joaat("prototipo");
        case 4:
        case 5:
        case 6:
          return this.joaat("tyrus");
        case 7:
        case 8:
        case 9:
          return this.joaat("bestiagts");
        case 10:
        case 11:
        case 12:
          return this.joaat("t20");
        case 13:
        case 14:
        case 15:
          return this.joaat("sheava");
        case 16:
        case 17:
        case 18:
          return this.joaat("osiris");
        case 19:
        case 20:
        case 21:
          return this.joaat("fmj");
        case 22:
        case 23:
        case 24:
          return this.joaat("reaper");
        case 25:
        case 26:
        case 27:
          return this.joaat("pfister811");
        case 28:
        case 29:
        case 30:
          return this.joaat("alpha");
        case 31:
        case 32:
        case 33:
          return this.joaat("mamba");
        case 34:
        case 35:
        case 36:
          return this.joaat("tampa");
        case 37:
        case 38:
        case 39:
          return this.joaat("btype3");
        case 40:
        case 41:
        case 42:
          return this.joaat("feltzer3");
        case 43:
        case 44:
        case 45:
          return this.joaat("ztype");
        case 46:
        case 47:
        case 48:
          return this.joaat("tropos");
        case 49:
        case 50:
        case 51:
          return this.joaat("entityxf");
        case 52:
        case 53:
        case 54:
          return this.joaat("sultanrs");
        case 55:
        case 56:
        case 57:
          return this.joaat("zentorno");
        case 58:
        case 59:
        case 60:
          return this.joaat("omnis");
        case 61:
        case 62:
        case 63:
          return this.joaat("coquette3");
        case 64:
        case 65:
        case 66:
          return this.joaat("seven70");
        case 67:
        case 68:
        case 69:
          return this.joaat("verlierer2");
        case 70:
        case 71:
        case 72:
          return this.joaat("feltzer2");
        case 73:
        case 74:
        case 75:
          return this.joaat("coquette2");
        case 76:
        case 77:
        case 78:
          return this.joaat("cheetah");
        case 80:
        case 81:
          return this.joaat("nightshade");
        case 82:
        case 83:
        case 84:
          return this.joaat("banshee2");
        case 85:
        case 86:
        case 87:
          return this.joaat("turismor");
        case 88:
        case 89:
        case 90:
          return this.joaat("massacro");
        case 91:
        case 92:
        case 93:
          return this.joaat("sabregt2");
        case 94:
        case 95:
        case 96:
          return this.joaat("jester");
        default:
          return 0;
      }
    }

    public void ResetData()
    {
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_WarehousesOwned >= 1 && this.SS_Warehouse1Index == index)
        {
          if (this.CargoWarehouses[index].blip != (Blip) null)
            this.CargoWarehouses[index].blip.Remove();
          this.CargoWarehouses[index].blip = World.CreateBlip(new Vector3(this.CargoWarehouses[index].Location.X, this.CargoWarehouses[index].Location.Y, 50f));
          this.CargoWarehouses[index].blip.Sprite = BlipSprite.Warehouse;
          this.CargoWarehouses[index].blip.Color = BlipColor.White;
          this.CargoWarehouses[index].blip.Name = "Cargo Warehouse : " + this.CargoWarehouses[index].WarehouseName;
          this.CargoWarehouses[index].blip.IsShortRange = true;
        }
        else if (this.SS_WarehousesOwned >= 2 && this.SS_Warehouse2Index == index)
        {
          if (this.CargoWarehouses[index].blip != (Blip) null)
            this.CargoWarehouses[index].blip.Remove();
          this.CargoWarehouses[index].blip = World.CreateBlip(new Vector3(this.CargoWarehouses[index].Location.X, this.CargoWarehouses[index].Location.Y, 50f));
          this.CargoWarehouses[index].blip.Sprite = BlipSprite.Warehouse;
          this.CargoWarehouses[index].blip.Color = BlipColor.White;
          this.CargoWarehouses[index].blip.Name = "Cargo Warehouse : " + this.CargoWarehouses[index].WarehouseName;
          this.CargoWarehouses[index].blip.IsShortRange = true;
        }
        else if (this.SS_WarehousesOwned >= 3 && this.SS_Warehouse3Index == index)
        {
          if (this.CargoWarehouses[index].blip != (Blip) null)
            this.CargoWarehouses[index].blip.Remove();
          this.CargoWarehouses[index].blip = World.CreateBlip(new Vector3(this.CargoWarehouses[index].Location.X, this.CargoWarehouses[index].Location.Y, 50f));
          this.CargoWarehouses[index].blip.Sprite = BlipSprite.Warehouse;
          this.CargoWarehouses[index].blip.Color = BlipColor.White;
          this.CargoWarehouses[index].blip.Name = "Cargo Warehouse : " + this.CargoWarehouses[index].WarehouseName;
          this.CargoWarehouses[index].blip.IsShortRange = true;
        }
        else if (this.SS_WarehousesOwned >= 4 && this.SS_Warehouse4Index == index)
        {
          if (this.CargoWarehouses[index].blip != (Blip) null)
            this.CargoWarehouses[index].blip.Remove();
          this.CargoWarehouses[index].blip = World.CreateBlip(new Vector3(this.CargoWarehouses[index].Location.X, this.CargoWarehouses[index].Location.Y, 50f));
          this.CargoWarehouses[index].blip.Sprite = BlipSprite.Warehouse;
          this.CargoWarehouses[index].blip.Color = BlipColor.White;
          this.CargoWarehouses[index].blip.Name = "Cargo Warehouse : " + this.CargoWarehouses[index].WarehouseName;
          this.CargoWarehouses[index].blip.IsShortRange = true;
        }
        else if (this.SS_WarehousesOwned >= 5 && this.SS_Warehouse5Index == index)
        {
          if (this.CargoWarehouses[index].blip != (Blip) null)
            this.CargoWarehouses[index].blip.Remove();
          this.CargoWarehouses[index].blip = World.CreateBlip(new Vector3(this.CargoWarehouses[index].Location.X, this.CargoWarehouses[index].Location.Y, 50f));
          this.CargoWarehouses[index].blip.Sprite = BlipSprite.Warehouse;
          this.CargoWarehouses[index].blip.Color = BlipColor.White;
          this.CargoWarehouses[index].blip.Name = "Cargo Warehouse : " + this.CargoWarehouses[index].WarehouseName;
          this.CargoWarehouses[index].blip.IsShortRange = true;
        }
      }
    }

    public void SetupPropsLarge(int Wn)
    {
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.Props.Count > 0)
        this.Props.Clear();
      UI.Notify("Warehouse " + Wn.ToString());
      this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + Wn.ToString() + ".ini");
      Vector3 Pos1 = new Vector3(1017.9f, -3108.6f, -40f);
      Vector3 Pos2 = new Vector3(1017.9f, -3102.6f, -40f);
      Vector3 Pos3 = new Vector3(1017.9f, -3097.6f, -40f);
      Vector3 Pos4 = new Vector3(1017.9f, -3091.6f, -40f);
      Vector3 Pos5 = new Vector3(993.0983f, -3106.427f, -40f);
      Vector3 Pos6 = new Vector3(1026.7f, -3096.295f, -40f);
      Vector3 Pos7 = new Vector3(1026.782f, -3106.479f, -40f);
      float num1 = 2.4f;
      float num2 = 2.1f;
      float num3 = 1f;
      float num4 = 1f;
      float num5 = 1f;
      float num6 = 1f;
      float num7 = 1f;
      float num8 = 1f;
      float num9 = 1f;
      float num10 = 1f;
      float num11 = 1f;
      float num12 = 1f;
      float num13 = 1f;
      float num14 = 1f;
      float num15 = 1f;
      float num16 = 1f;
      int num17 = 0;
      UI.Notify("~b~Loading Props, Please be patient, do not exit the subbusienss untill this is complete~w~");
      for (int index = 1; index <= 111; ++index)
      {
        Script.Wait(1);
        Vector3 Rot = new Vector3(0.0f, 0.0f, 180f);
        int num18 = new System.Random().Next(1, 100);
        new System.Random().Next(1, this.CrateIds.Count);
        if (num18 < 25)
          Rot = new Vector3(0.0f, 0.0f, 180f);
        if (num18 >= 25 && num18 < 50)
          Rot = new Vector3(0.0f, 0.0f, 90f);
        Rot = num18 < 50 || num18 >= 75 ? new Vector3(0.0f, 0.0f, 0.0f) : new Vector3(0.0f, 0.0f, -90f);
        this.CurrentCratestotal = this.GetCrateCountByID(Wn);
        if (this.CurrentCratestotal > 0 && num17 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num17 + 1 <= this.CurrentCratestotal && (double) num10 != 4.0))
        {
          if ((double) num3 <= 7.0)
          {
            int num19 = 0;
            if (index < 17)
              num19 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 17 && index < 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num19);
            if (num19 >= 0)
            {
              ++num17;
              this.SpawnCrates(this.GetCrateProp(num19), Pos1, Rot);
              Pos1 = new Vector3(Pos1.X -= num1, Pos1.Y, Pos1.Z);
              ++num3;
            }
          }
          else
          {
            Pos1 = new Vector3(1017.9f, -3108.6f, Pos1.Z);
            float num19 = 0.0f;
            Pos1 = new Vector3(Pos1.X, Pos1.Y, Pos1.Z += num2);
            num3 = num19 + 1f;
            ++num10;
          }
        }
        if (this.CurrentCratestotal > 21 && num17 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num17 + 1 <= this.CurrentCratestotal && (double) num11 != 4.0))
        {
          if ((double) num4 <= 7.0)
          {
            int num19 = 0;
            if (index < 17)
              num19 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 17 && index < 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num19);
            if (num19 >= 0)
            {
              ++num17;
              this.SpawnCrates(this.GetCrateProp(num19), Pos2, Rot);
              Pos2 = new Vector3(Pos2.X -= num1, Pos2.Y, Pos2.Z);
              ++num4;
            }
          }
          else
          {
            Pos2 = new Vector3(1017.9f, -3102.6f, Pos2.Z);
            float num19 = 0.0f;
            Pos2 = new Vector3(Pos2.X, Pos2.Y, Pos2.Z += num2);
            num4 = num19 + 1f;
            ++num11;
          }
        }
        if (this.CurrentCratestotal > 60 && num17 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num17 + 1 <= this.CurrentCratestotal && (double) num12 != 4.0))
        {
          if ((double) num5 <= 7.0)
          {
            int num19 = 0;
            if (index < 17)
              num19 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 17 && index < 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num19);
            if (num19 >= 0)
            {
              ++num17;
              this.SpawnCrates(this.GetCrateProp(num19), Pos3, Rot);
              Pos3 = new Vector3(Pos3.X -= num1, Pos3.Y, Pos3.Z);
              ++num5;
            }
          }
          else
          {
            Pos3 = new Vector3(1017.9f, -3097.6f, Pos3.Z);
            float num19 = 0.0f;
            Pos3 = new Vector3(Pos3.X, Pos3.Y, Pos3.Z += num2);
            num5 = num19 + 1f;
            ++num12;
          }
        }
        if (this.CurrentCratestotal > 84 && num17 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num17 + 1 <= this.CurrentCratestotal && (double) num13 != 4.0))
        {
          if ((double) num6 <= 7.0)
          {
            int num19 = 0;
            if (index < 17)
              num19 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 17 && index < 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num19);
            if (num19 >= 0)
            {
              ++num17;
              this.SpawnCrates(this.GetCrateProp(num19), Pos4, Rot);
              Pos4 = new Vector3(Pos4.X -= num1, Pos4.Y, Pos4.Z);
              ++num6;
            }
          }
          else
          {
            Pos4 = new Vector3(1017.9f, -3091.6f, Pos4.Z);
            float num19 = 0.0f;
            Pos4 = new Vector3(Pos4.X, Pos4.Y, Pos4.Z += num2);
            num6 = num19 + 1f;
            ++num13;
          }
        }
        if (this.CurrentCratestotal > 93 && num17 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num17 + 1 <= this.CurrentCratestotal && (double) num14 != 4.0))
        {
          if ((double) num7 <= 4.0)
          {
            int num19 = 0;
            if (index < 17)
              num19 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 17 && index < 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num19);
            if (num19 >= 0)
            {
              ++num17;
              this.SpawnCrates(this.GetCrateProp(num19), Pos5, Rot);
              Pos5 = new Vector3(Pos5.X, Pos5.Y -= num1, Pos5.Z);
              ++num7;
            }
          }
          else
          {
            float num19 = 0.0f;
            Pos5 = new Vector3(993.0983f, -3106.427f, -40f);
            Pos5 = new Vector3(Pos5.X, Pos5.Y, Pos5.Z += num2);
            num7 = num19 + 1f;
            ++num14;
          }
        }
        if (this.CurrentCratestotal > 102 && num17 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num17 + 1 <= this.CurrentCratestotal && (double) num15 != 4.0))
        {
          if ((double) num8 <= 4.0)
          {
            int num19 = 0;
            if (index < 17)
              num19 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 17 && index < 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num19);
            if (num19 >= 0)
            {
              ++num17;
              this.SpawnCrates(this.GetCrateProp(num19), Pos6, Rot);
              Pos6 = new Vector3(Pos6.X, Pos6.Y += num1, Pos6.Z);
              ++num8;
            }
          }
          else
          {
            float num19 = 0.0f;
            Pos6 = new Vector3(1026.7f, -3096.295f, -40f);
            Pos6 = new Vector3(Pos6.X, Pos6.Y, Pos6.Z += num2);
            num8 = num19 + 1f;
            ++num15;
          }
        }
        if (this.CurrentCratestotal > 111 && num17 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num17 + 1 <= this.CurrentCratestotal && (double) num16 != 4.0))
        {
          if ((double) num9 <= 4.0)
          {
            int num19 = 0;
            if (index < 17)
              num19 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 17 && index < 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num19);
            if (index >= 43)
              num19 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num19);
            if (num19 >= 0)
            {
              ++num17;
              this.SpawnCrates(this.GetCrateProp(num19), Pos7, Rot);
              Pos7 = new Vector3(Pos7.X, Pos7.Y += num1, Pos7.Z);
              ++num9;
            }
          }
          else
          {
            float num19 = 0.0f;
            Pos7 = new Vector3(1026.782f, -3106.479f, -40f);
            Pos7 = new Vector3(Pos7.X, Pos7.Y, Pos7.Z -= num2);
            num9 = num19 + 1f;
            ++num16;
          }
        }
      }
      UI.Notify("~b~Successfully loaded Props, Thank you for being patient~w~");
      UI.Notify("LARGE amountofCrates " + num17.ToString() + ", " + this.CurrentCratestotal.ToString());
    }

    public void SetupPropsSmall(int Wn)
    {
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.Props.Count > 0)
        this.Props.Clear();
      this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + Wn.ToString() + ".ini");
      Vector3 Pos = new Vector3(1103.78f, -3096.448f, -40f);
      float num1 = 2f;
      float num2 = 1f;
      float num3 = 1f;
      int num4 = 0;
      int num5 = 0;
      UI.Notify("~b~Loading Props, Please be patient, do not exit the subbusienss untill this is complete~w~");
      for (int index = 1; index <= 16; ++index)
      {
        ++num4;
        float num6;
        if (num4 == 2)
        {
          num4 = 0;
          num6 = 3.6f;
        }
        else
          num6 = 2.4f;
        Script.Wait(1);
        Vector3 Rot = new Vector3(0.0f, 0.0f, 180f);
        int num7 = new System.Random().Next(1, 100);
        System.Random random = new System.Random();
        random.Next(1, this.CrateIds.Count);
        if (num7 < 25)
          Rot = new Vector3(0.0f, 0.0f, 180f);
        if (num7 >= 25 && num7 < 50)
          Rot = new Vector3(0.0f, 0.0f, 90f);
        Rot = num7 < 50 || num7 >= 75 ? new Vector3(0.0f, 0.0f, 0.0f) : new Vector3(0.0f, 0.0f, -90f);
        this.CurrentCratestotal = this.GetCrateCountByID(Wn);
        if (this.CurrentCratestotal > 0 && num5 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num5 + 1 <= this.CurrentCratestotal && (double) num3 != 3.0))
        {
          if ((double) num2 <= 6.0)
          {
            int num8 = 0;
            if (index < 17)
              num8 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num8);
            if (index >= 17 && index < 43)
              num8 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num8);
            if (index >= 43)
              num8 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num8);
            if (num8 >= 0)
            {
              ++num5;
              this.SpawnCrates(this.GetCrateProp(num8), Pos, Rot);
              Pos = new Vector3(Pos.X -= num6, Pos.Y, Pos.Z);
              ++num2;
            }
          }
          else
          {
            Pos = new Vector3(1103.78f, -3096.448f, Pos.Z);
            float num8 = 0.0f;
            Pos = new Vector3(Pos.X, Pos.Y, Pos.Z += num1);
            num2 = num8 + 1f;
            ++num3;
          }
        }
        random.Next(1, this.CrateIds.Count);
      }
      UI.Notify("~b~Successfully loaded Props, Thank you for being patient~w~");
      UI.Notify("SMALL amountofCrates " + num5.ToString() + ", " + this.CurrentCratestotal.ToString());
    }

    public void SetupPropsMedium(int Wn)
    {
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.Props.Count > 0)
        this.Props.Clear();
      this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + Wn.ToString() + ".ini");
      Vector3 Pos1 = new Vector3(1067.616f, -3110.126f, -40f);
      Vector3 Pos2 = new Vector3(1067.616f, -3102.561f, -40f);
      Vector3 Pos3 = new Vector3(1067.616f, -3095.411f, -40f);
      float num1 = 2.4f;
      float num2 = 2f;
      float num3 = 1f;
      float num4 = 1f;
      float num5 = 1f;
      float num6 = 1f;
      float num7 = 1f;
      float num8 = 1f;
      int num9 = 0;
      UI.Notify("~b~Loading Props, Please be patient, do not exit the subbusienss untill this is complete~w~");
      for (int index = 1; index <= 42; ++index)
      {
        Script.Wait(1);
        Vector3 Rot = new Vector3(0.0f, 0.0f, 180f);
        int num10 = new System.Random().Next(1, 100);
        System.Random random = new System.Random();
        random.Next(1, this.CrateIds.Count);
        if (num10 < 25)
          Rot = new Vector3(0.0f, 0.0f, 180f);
        if (num10 >= 25 && num10 < 50)
          Rot = new Vector3(0.0f, 0.0f, 90f);
        Rot = num10 < 50 || num10 >= 75 ? new Vector3(0.0f, 0.0f, 0.0f) : new Vector3(0.0f, 0.0f, -90f);
        this.CurrentCratestotal = this.GetCrateCountByID(Wn);
        if (this.CurrentCratestotal > 0 && num9 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num9 + 1 <= this.CurrentCratestotal && (double) num6 != 3.0))
        {
          if ((double) num3 <= 8.0)
          {
            int num11 = 0;
            if (index < 17)
              num11 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num11);
            if (index >= 17 && index < 43)
              num11 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num11);
            if (index >= 43)
              num11 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num11);
            if (num11 >= 0)
            {
              ++num9;
              this.SpawnCrates(this.GetCrateProp(num11), Pos1, Rot);
              Pos1 = new Vector3(Pos1.X -= num1, Pos1.Y, Pos1.Z);
              ++num3;
            }
          }
          else
          {
            Pos1 = new Vector3(1067.616f, -3110.126f, Pos1.Z);
            float num11 = 0.0f;
            Pos1 = new Vector3(Pos1.X, Pos1.Y, Pos1.Z += num2);
            num3 = num11 + 1f;
            ++num6;
          }
        }
        random.Next(1, this.CrateIds.Count);
        if (this.CurrentCratestotal > 34 && num9 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num9 + 1 <= this.CurrentCratestotal && (double) num7 != 3.0))
        {
          if ((double) num4 < 8.0)
          {
            int num11 = 0;
            if (index < 17)
              num11 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num11);
            if (index >= 17 && index < 43)
              num11 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num11);
            if (index >= 43)
              num11 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num11);
            if (num11 >= 0)
            {
              ++num9;
              this.SpawnCrates(this.GetCrateProp(num11), Pos2, Rot);
              Pos2 = new Vector3(Pos2.X -= num1, Pos2.Y, Pos2.Z);
              ++num4;
            }
          }
          else
          {
            Pos2 = new Vector3(1067.616f, -3102.561f, Pos2.Z);
            float num11 = 0.0f;
            Pos2 = new Vector3(Pos2.X, Pos2.Y, Pos2.Z += num2);
            num4 = num11 + 1f;
            ++num7;
          }
        }
        random.Next(1, this.CrateIds.Count);
        if (this.CurrentCratestotal > 66 && num9 + 1 <= this.CargoWarehouses[this.CurrentWarehouse].Maxcrates && (num9 + 1 <= this.CurrentCratestotal && (double) num8 != 3.0))
        {
          if ((double) num5 <= 8.0)
          {
            int num11 = 0;
            if (index < 17)
              num11 = this.CrateConfig.GetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), num11);
            if (index >= 17 && index < 43)
              num11 = this.CrateConfig.GetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), num11);
            if (index >= 43)
              num11 = this.CrateConfig.GetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), num11);
            if (num11 >= 0)
            {
              ++num9;
              this.SpawnCrates(this.GetCrateProp(num11), Pos3, Rot);
              Pos3 = new Vector3(Pos3.X -= num1, Pos3.Y, Pos3.Z);
              ++num5;
            }
          }
          else
          {
            Pos3 = new Vector3(1067.616f, -3095.411f, Pos3.Z);
            float num11 = 0.0f;
            Pos3 = new Vector3(Pos3.X, Pos3.Y, Pos3.Z += num2);
            num5 = num11 + 1f;
            ++num8;
          }
        }
        random.Next(1, this.CrateIds.Count);
        UI.Notify("MEDIUM amountofCrates " + num9.ToString() + ", " + this.CurrentCratestotal.ToString());
      }
      UI.Notify("~b~Successfully loaded Props, Thank you for being patient~w~");
    }

    public void LoadCrates(string iniName)
    {
      try
      {
        this.CrateConfig = ScriptSettings.Load(iniName);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public int GetWarehouse_ByIni(int W)
    {
      int num = 0;
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && W == 1)
          num = index;
        if (this.SS_Warehouse2Index == index && W == 2)
          num = index;
        if (this.SS_Warehouse3Index == index && W == 3)
          num = index;
        if (this.SS_Warehouse4Index == index && W == 4)
          num = index;
        if (this.SS_Warehouse5Index == index && W == 5)
          num = index;
      }
      return num;
    }

    public int GetWarehouseIndex(int W)
    {
      int num = 0;
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && W == index)
          num = index;
        if (this.SS_Warehouse2Index == index && W == index)
          num = index;
        if (this.SS_Warehouse3Index == index && W == index)
          num = index;
        if (this.SS_Warehouse4Index == index && W == index)
          num = index;
        if (this.SS_Warehouse5Index == index && W == index)
          num = index;
      }
      return num;
    }

    public int GetWarehouseID(int W)
    {
      int num = 0;
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && W == index)
          num = 1;
        if (this.SS_Warehouse2Index == index && W == index)
          num = 2;
        if (this.SS_Warehouse3Index == index && W == index)
          num = 3;
        if (this.SS_Warehouse4Index == index && W == index)
          num = 4;
        if (this.SS_Warehouse5Index == index && W == index)
          num = 5;
      }
      return num;
    }

    public Vector3 GetWarehouseMarker_ByID(int W)
    {
      Vector3 vector3 = new Vector3();
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && W == 1)
          vector3 = this.CargoWarehouses[index].Location;
        if (this.SS_Warehouse2Index == index && W == 2)
          vector3 = this.CargoWarehouses[index].Location;
        if (this.SS_Warehouse3Index == index && W == 3)
          vector3 = this.CargoWarehouses[index].Location;
        if (this.SS_Warehouse4Index == index && W == 4)
          vector3 = this.CargoWarehouses[index].Location;
        if (this.SS_Warehouse5Index == index && W == 5)
          vector3 = this.CargoWarehouses[index].Location;
      }
      return vector3;
    }

    public void StartSellMission(int W)
    {
      int num1 = new System.Random().Next(0, 300);
      int num2 = 0;
      for (int index = 0; index < this.CargoWarehouses.Count; ++index)
      {
        if (this.SS_Warehouse1Index == index && W == 1)
          num2 = this.SS_Warehouse1Stock;
        if (this.SS_Warehouse2Index == index && W == 2)
          num2 = this.SS_Warehouse2Stock;
        if (this.SS_Warehouse3Index == index && W == 3)
          num2 = this.SS_Warehouse3Stock;
        if (this.SS_Warehouse4Index == index && W == 4)
          num2 = this.SS_Warehouse4Stock;
        if (this.SS_Warehouse5Index == index && W == 5)
          num2 = this.SS_Warehouse5Stock;
      }
      if (num2 <= 5)
        this.Points = new Vector3(1f, 1f, 1f);
      if (num2 > 5 && num2 <= 10)
        this.Points = new Vector3(1f, 1f, 1f);
      if (num2 > 10 && num2 <= 16)
        this.Points = new Vector3(1f, 1f, 1f);
      if (num2 > 16 && num2 <= 20)
        this.Points = new Vector3(3f, 1f, 2f);
      if (num2 > 20 && num2 <= 25)
        this.Points = new Vector3(3f, 2f, 2f);
      if (num2 > 25 && num2 <= 32)
        this.Points = new Vector3(3f, 2f, 2f);
      if (num2 > 32 && num2 <= 46)
        this.Points = new Vector3(4f, 2f, 3f);
      if (num2 > 46 && num2 <= 52)
        this.Points = new Vector3(4f, 3f, 3f);
      if (num2 > 52 && num2 <= 64)
        this.Points = new Vector3(4f, 3f, 3f);
      if (num2 > 64 && num2 <= 72)
        this.Points = new Vector3(4f, 3f, 3f);
      if (num2 > 72 && num2 <= 84)
        this.Points = new Vector3(5f, 4f, 3f);
      if (num2 > 84 && num2 <= 96)
        this.Points = new Vector3(5f, 4f, 4f);
      if (num2 > 96 && num2 <= 111)
        this.Points = new Vector3(5f, 4f, 5f);
      if (num1 > 100)
        ;
      if (num1 <= 200)
        ;
    }

    public static Vector3 GenerateSpawnPos(
      Vector3 desiredPos,
      SubBusinesses.Nodetype roadtype,
      bool sidewalk)
    {
      Vector3 zero = Vector3.Zero;
      bool flag = false;
      OutputArgument outputArgument = new OutputArgument();
      int num1 = 1;
      int num2 = 0;
      if (roadtype == SubBusinesses.Nodetype.AnyRoad)
        num2 = 1;
      if (roadtype == SubBusinesses.Nodetype.Road)
        num2 = 0;
      if (roadtype == SubBusinesses.Nodetype.Offroad)
      {
        num2 = 1;
        flag = true;
      }
      if (roadtype == SubBusinesses.Nodetype.Water)
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
      Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_oddjobtraffickingair");
      Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_oddjobtraffickingair");
      Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_oddjobtraffickingair");
      if (!Function.Call<bool>(Hash._0x8702416E512EC454, (InputArgument) "scr_oddjobtraffickingair"))
      {
        Script.Wait(0);
        Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_oddjobtraffickingair");
        Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_oddjobtraffickingair");
        Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_oddjobtraffickingair");
      }
      if (!Function.Call<bool>(Hash._0x8702416E512EC454, (InputArgument) "scr_oddjobtraffickingair"))
        return;
      X = new Vector3(vector3.X, vector3.Y, World.GetGroundHeight(new Vector3(vector3.X, vector3.Y, vector3.Z + 500f)));
      Prop prop = World.CreateProp(this.RequestModel("prop_flare_01b"), X, false, false);
      this.SupplyMissionProps.Add(prop);
      int num = Function.Call<int>(Hash._0xE184F4F0DC5910E7, (InputArgument) "scr_crate_drop_flare", (InputArgument) X.X, (InputArgument) X.Y, (InputArgument) X.Z, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 5f, (InputArgument) false, (InputArgument) false, (InputArgument) false, (InputArgument) false);
      this.SetRange(num, 100000f);
      this.SetColor(num, (float) byte.MaxValue, 0.0f, 0.0f, true);
      this.SmokeParticles.Add(num);
      this.SmokePropaParticles.Add(new SubBusinesses.Flare(prop, num, true));
    }

    private void SetColor(int particle, float r, float g, float b, bool p1) => Function.Call(Hash._0x7F8F65877F88783B, (InputArgument) particle, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) p1);

    private void SetRange(int handle, float range) => Function.Call(Hash._0xDCB194B85EF7B541, (InputArgument) handle, (InputArgument) range);

    private int GetBoneByName(Entity entity, string name) => Function.Call<int>(Hash._0xFB71170B7E76ACBA, (InputArgument) entity, (InputArgument) name);

    public void CreateSmoke_SellMission(SubBusinesses.Flare X)
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

    public void DrawStockBar(string Name, float X, float Y, float CrntValue, float MaxValue)
    {
      this.drawSprite2("timerbars", "all_black_bg", X, Y, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.drawSprite2("timerbars", "all_black_bg", X - 0.1f, Y, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.drawSprite2("timerbars", "damagebarfill_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 225, 130);
      this.drawSprite2("timerbars", "damagebarfill_128", this.progressxcoord(CrntValue / MaxValue), Y, this.progresswidth(CrntValue / MaxValue), 0.03f, 0, 0, 225, (int) byte.MaxValue);
      this.drawSprite2("timerbar_lines", "LineMarker20_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, (int) byte.MaxValue);
      this.drawSprite2("timerbar_lines", "LineMarker40_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, (int) byte.MaxValue);
      this.drawSprite2("timerbar_lines", "LineMarker60_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, (int) byte.MaxValue);
      this.drawSprite2("timerbar_lines", "LineMarker80_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, (int) byte.MaxValue);
      this.drawText(Name, X - 0.1f, Y - 0.016f, 0.3f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    }

    private void ArmedPed2(Ped Ped, WeaponHash Weapon)
    {
      int num = new System.Random().Next(0, 300);
      if (num < 50)
        Ped.Weapons.Give(WeaponHash.CombatPistol, 9999, true, true);
      if (num > 50 && num < 100)
        Ped.Weapons.Give(WeaponHash.SMG, 9999, true, true);
      if (num > 100 && num < 150)
        Ped.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
      if (num > 150 && num < 200)
        Ped.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
      if (num > 200 && num < 225)
        Ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
      if (num <= 225 || num >= 300)
        return;
      Ped.Weapons.Give(WeaponHash.CombatPistol, 9999, true, true);
    }

    private void ArmedPed(Ped Ped, WeaponHash Weapon)
    {
      int num = new System.Random().Next(0, 300);
      if (num < 50)
        Ped.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
      if (num > 50 && num < 100)
        Ped.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
      if (num > 100 && num < 150)
        Ped.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
      if (num > 150 && num < 200)
        Ped.Weapons.Give(WeaponHash.SMG, 9999, true, true);
      if (num > 200 && num < 250)
        Ped.Weapons.Give(WeaponHash.DoubleBarrelShotgun, 9999, true, true);
      if (num <= 250 || num >= 300)
        return;
      Ped.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
    }

    private void SetupBallas(Vehicle Car, int type)
    {
      if (type == 1)
      {
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) Car.Handle, (InputArgument) 0);
        Car.PrimaryColor = VehicleColor.MetallicPurpleBlue;
        Car.SecondaryColor = VehicleColor.MetallicPurpleBlue;
        Car.SetMod(VehicleMod.Livery, 3, true);
        Car.SetMod(VehicleMod.Plaques, 1, true);
        Car.SetMod(VehicleMod.BackWheels, 3, true);
        Car.SetMod(VehicleMod.DialDesign, 13, true);
        Car.SetMod(VehicleMod.SteeringWheels, 15, true);
      }
      if (type != 2)
        return;
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) Car.Handle, (InputArgument) 0);
      Car.PrimaryColor = VehicleColor.MetallicPurpleBlue;
      Car.SecondaryColor = VehicleColor.MetallicPurpleBlue;
      Car.SetMod(VehicleMod.Livery, 10, true);
      Car.SetMod(VehicleMod.Plaques, 1, true);
      Car.SetMod(VehicleMod.BackWheels, 3, true);
      Car.SetMod(VehicleMod.DialDesign, 13, true);
      Car.SetMod(VehicleMod.SteeringWheels, 15, true);
    }

    private void SetupFamilies(Vehicle Car, int type)
    {
      if (type == 1)
      {
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) Car.Handle, (InputArgument) 0);
        Car.PrimaryColor = VehicleColor.MetallicGreen;
        Car.SecondaryColor = VehicleColor.MetallicGreen;
        Car.SetMod(VehicleMod.Livery, 7, true);
        Car.SetMod(VehicleMod.Plaques, 5, true);
        Car.SetMod(VehicleMod.BackWheels, 3, true);
        Car.SetMod(VehicleMod.DialDesign, 13, true);
        Car.SetMod(VehicleMod.SteeringWheels, 15, true);
      }
      if (type != 2)
        return;
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) Car.Handle, (InputArgument) 0);
      Car.PrimaryColor = VehicleColor.MetallicGreen;
      Car.SecondaryColor = VehicleColor.MetallicGreen;
      Car.SetMod(VehicleMod.Livery, 4, true);
      Car.SetMod(VehicleMod.Plaques, 5, true);
      Car.SetMod(VehicleMod.BackWheels, 3, true);
      Car.SetMod(VehicleMod.DialDesign, 13, true);
      Car.SetMod(VehicleMod.SteeringWheels, 15, true);
    }

    private void SetupVagos(Vehicle Car, int type)
    {
      if (type == 1)
      {
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) Car.Handle, (InputArgument) 0);
        Car.PrimaryColor = VehicleColor.MetallicRaceYellow;
        Car.SecondaryColor = VehicleColor.MetallicRaceYellow;
        Car.SetMod(VehicleMod.Livery, 6, true);
        Car.SetMod(VehicleMod.Plaques, 2, true);
        Car.SetMod(VehicleMod.BackWheels, 3, true);
        Car.SetMod(VehicleMod.DialDesign, 13, true);
        Car.SetMod(VehicleMod.SteeringWheels, 15, true);
      }
      if (type != 2)
        return;
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) Car.Handle, (InputArgument) 0);
      Car.PrimaryColor = VehicleColor.MetallicRaceYellow;
      Car.SecondaryColor = VehicleColor.MetallicRaceYellow;
      Car.SetMod(VehicleMod.Livery, 4, true);
      Car.SetMod(VehicleMod.Plaques, 2, true);
      Car.SetMod(VehicleMod.BackWheels, 3, true);
      Car.SetMod(VehicleMod.DialDesign, 13, true);
      Car.SetMod(VehicleMod.SteeringWheels, 15, true);
    }

    public void SetupRaid(int RaidTypeMission)
    {
      System.Random random = new System.Random();
      int num = random.Next(0, 100);
      if (num >= 60)
        this.RaidEnemyTime = 1;
      if (num < 59)
        this.RaidEnemyTime = 0;
      this.WaitingForRaid = false;
      this.CurrentTime = this.GetHour();
      this.RaidHour = Game.GameTime + new System.Random().Next(225000, 880000);
      random.Next(0, 100);
      List<Vector3> vector3List = new List<Vector3>();
      if (this.SS_WarehousesOwned >= 1)
        vector3List.Add(this.GetWarehouseMarker_ByID(1));
      if (this.SS_WarehousesOwned >= 2)
        vector3List.Add(this.GetWarehouseMarker_ByID(2));
      if (this.SS_WarehousesOwned >= 3)
        vector3List.Add(this.GetWarehouseMarker_ByID(3));
      if (this.SS_WarehousesOwned >= 4)
        vector3List.Add(this.GetWarehouseMarker_ByID(4));
      if (this.SS_WarehousesOwned >= 5)
        vector3List.Add(this.GetWarehouseMarker_ByID(5));
      Vector3 position = vector3List[random.Next(0, vector3List.Count)];
      this.RaidLocation = position;
      if (this.GetWarehouseMarker_ByID(1) == this.RaidLocation)
      {
        this.CurrentRaidWarehouse = 1;
        this.IndexRaidWarehouse = this.GetWarehouse_ByIni(1);
      }
      if (this.GetWarehouseMarker_ByID(2) == this.RaidLocation)
      {
        this.CurrentRaidWarehouse = 2;
        this.IndexRaidWarehouse = this.GetWarehouse_ByIni(2);
      }
      if (this.GetWarehouseMarker_ByID(3) == this.RaidLocation)
      {
        this.CurrentRaidWarehouse = 3;
        this.IndexRaidWarehouse = this.GetWarehouse_ByIni(3);
      }
      if (this.GetWarehouseMarker_ByID(4) == this.RaidLocation)
      {
        this.CurrentRaidWarehouse = 4;
        this.IndexRaidWarehouse = this.GetWarehouse_ByIni(4);
      }
      if (this.GetWarehouseMarker_ByID(5) == this.RaidLocation)
      {
        this.CurrentRaidWarehouse = 5;
        this.IndexRaidWarehouse = this.GetWarehouse_ByIni(5);
      }
      if (this.SS_WarehousesOwned < 1)
        return;
      SubBusinesses.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Cargo Warehouse Raid", "Our " + this.CargoWarehouses[this.IndexRaidWarehouse].WarehouseName + " is Under attack!");
      Blip blip = World.CreateBlip(position);
      blip.Sprite = BlipSprite.PropertyVagos;
      blip.Color = this.ArcadiusBlip_Colour;
      blip.Name = "Business Raid";
      blip.IsShortRange = true;
      this.SupplyMissionBlips.Add(blip);
      this.SupplyMissionOn = true;
      this.SupplyMissionID = 100;
    }

    public static void TextNotification(
      string avatar,
      string author,
      string title,
      string message)
    {
      Function.Call(Hash._0x67C540AA08E4A6F5, (InputArgument) -1, (InputArgument) "CONFIRM_BEEP", (InputArgument) "HUD_MINI_GAME_SOUNDSET");
      Function.Call(Hash._0x202709F4C58A0424, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) message);
      Function.Call<int>(Hash._0x1CCD9A37359072CF, (InputArgument) avatar, (InputArgument) avatar, (InputArgument) true, (InputArgument) 0, (InputArgument) title, (InputArgument) author);
    }

    public void ShowGUIInsrucitons()
    {
      Convert.ToInt32(UIMenu.GetScreenResolutionMantainRatio().Width / 2f);
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.CallFunction("CLEAR_ALL");
      scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", (object) 0);
      scaleform.CallFunction("CREATE_CONTAINER");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 0, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 200, (InputArgument) 0), (object) "Exit");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 1, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 24, (InputArgument) 0), (object) "Select");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 2, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 25, (InputArgument) 0), (object) "Back");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 4, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 198, (InputArgument) 0), (object) "Screen Up/Down");
      scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", (object) -1);
      scaleform.Render2D();
    }

    public void onTick()
    {
      if (Game.GameTime > this.NextRaidTimer)
      {
        System.Random random = new System.Random();
        this.NextRaidTimer = Game.GameTime + random.Next(800000, 1395000);
        int num = random.Next(0, 100);
        if (this.RaidCounter == 1)
        {
          if (this.SS_WarehousesOwned >= 1 && num < 10)
            this.SetupRaid(1);
          if (this.SS_WarehousesOwned >= 2 && num < 15)
            this.SetupRaid(1);
          if (this.SS_WarehousesOwned >= 3 && num < 20)
            this.SetupRaid(1);
          if (this.SS_WarehousesOwned >= 4 && num < 25)
            this.SetupRaid(1);
          if (this.SS_WarehousesOwned >= 5 && num < 30)
            this.SetupRaid(1);
        }
        else
          this.RaidCounter = 1;
      }
      if (this.IsIninterior)
      {
        if (Game.Player.Character.Weapons.Current != null && Game.Player.Character.Weapons.Current.Hash != WeaponHash.Unarmed)
        {
          this.DisplayHelpTextThisFrame("You cannot use weapons while inside your Warehouse");
          Game.Player.Character.Weapons.Select(WeaponHash.Unarmed, true);
        }
        if (Game.IsControlPressed(2, GTA.Control.SelectWeapon))
        {
          Game.DisableControlThisFrame(2, GTA.Control.SelectWeapon);
          this.DisplayHelpTextThisFrame("You cannot use weapons while inside your Warehouse");
        }
      }
      if (!this.FirsttimeSmoke)
      {
        this.FirsttimeSmoke = true;
        foreach (Vector3 airSellPoint in this.AirSellPoints)
          this.SellPointsSmoke_Air.Add(new SubBusinesses.Flare(airSellPoint, false));
        foreach (Vector3 waterSellPoint in this.WaterSellPoints)
          this.SellPointsSmoke_Water.Add(new SubBusinesses.Flare(waterSellPoint, false));
      }
      if (this.FirsttimeSmoke)
      {
        if (this.SellPointsSmoke_Water.Count > 0)
        {
          foreach (SubBusinesses.Flare X in this.SellPointsSmoke_Water)
          {
            if (!X.Created && this.SelectedSellPoints.Contains(X.Location) && (double) World.GetDistance(Game.Player.Character.Position, X.Location) < 700.0)
              this.CreateSmoke_SellMission(X);
            if (X.Created && this.SelectedSellPoints.Contains(X.Location) && (double) World.GetDistance(Game.Player.Character.Position, X.Location) > 700.0)
            {
              X.Created = false;
              if ((Entity) X.FlareProp != (Entity) null)
              {
                Function.Call(Hash._0x8F75998877616996, (InputArgument) X.FlareID_1, (InputArgument) false);
                X.FlareProp.Delete();
              }
            }
          }
        }
        if (this.SellPointsSmoke_Air.Count > 0)
        {
          foreach (SubBusinesses.Flare X in this.SellPointsSmoke_Air)
          {
            if (!X.Created && this.SelectedSellPoints.Contains(X.Location) && (double) World.GetDistance(Game.Player.Character.Position, X.Location) < 700.0)
              this.CreateSmoke_SellMission(X);
            if (X.Created && this.SelectedSellPoints.Contains(X.Location) && (double) World.GetDistance(Game.Player.Character.Position, X.Location) > 700.0)
            {
              X.Created = false;
              if ((Entity) X.FlareProp != (Entity) null)
              {
                Function.Call(Hash._0x8F75998877616996, (InputArgument) X.FlareID_1, (InputArgument) false);
                X.FlareProp.Delete();
              }
            }
          }
        }
      }
      if (this.SupplyMissionOn)
      {
        if (this.SupplyMissionID == 100)
        {
          if (this.SupplyMissionPeds.Count > 0)
          {
            foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
            {
              if (!supplyMissionPed.IsAlive)
                supplyMissionPed.CurrentBlip.Alpha = 0;
            }
          }
          if (this.WaitingForRaid)
          {
            Game.Player.WantedLevel = 0;
            if (Game.Player.Character.IsAlive)
            {
              if (this.isAtRaidLocation && (double) World.GetDistance(Game.Player.Character.Position, this.RaidLocation) < 30.0)
              {
                UI.Notify(this.GetHostName() + " Ok incoming enemies, stay sharp boss");
                this.isAtRaidLocation = false;
                this.Raidtimer = (float) new System.Random().Next(200, 425);
                this.StartedRaid = true;
                this.SpawnAttackerTimer = 160f;
              }
              if (this.StartedRaid)
              {
                TimeSpan timeSpan1 = TimeSpan.FromSeconds((double) this.Raidtimer);
                timeSpan1.Subtract(new TimeSpan(0, 0, 0, timeSpan1.Milliseconds));
                TimeSpan timeSpan2 = TimeSpan.FromSeconds((double) this.SpawnAttackerTimer);
                timeSpan2.Subtract(new TimeSpan(0, 0, 0, timeSpan2.Milliseconds));
                string str1 = string.Format("{0:D2}:{1:D2}", (object) (int) timeSpan1.TotalMinutes, (object) timeSpan1.Seconds);
                string str2 = string.Format("{0:D2}:{1:D2}", (object) (int) timeSpan2.TotalMinutes, (object) timeSpan2.Seconds);
                UI.ShowSubtitle("Raid ends : " + str1 + " , next attack : " + str2);
                UI.ShowSubtitle("Raid ends : " + str1 + " , next attack : " + str2);
                if ((double) this.Raidtimer != 0.0)
                {
                  this.Raidtimer -= 0.05f;
                  foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                  {
                    if ((Entity) supplyMissionPed != (Entity) null)
                    {
                      int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                      Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) supplyMissionPed, (InputArgument) num);
                      Function.Call(Hash._0x9F7794730795E019, (InputArgument) supplyMissionPed, (InputArgument) 0, (InputArgument) 0);
                      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) supplyMissionPed, (InputArgument) 1);
                      supplyMissionPed.Task.FightAgainst(Game.Player.Character);
                      Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) supplyMissionPed, (InputArgument) 1);
                    }
                  }
                }
                if ((double) this.Raidtimer <= 0.0)
                {
                  this.SpawnAttackerTimer = 5000f;
                  this.SpawnAttackerTimer = 0.0f;
                  foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                  {
                    if ((Entity) supplyMissionPed != (Entity) null)
                      supplyMissionPed.Delete();
                  }
                  foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
                  {
                    if ((Entity) supplyMissionVehicle != (Entity) null)
                      supplyMissionVehicle.Delete();
                  }
                  this.SupplyMissionID = 0;
                  this.SupplyMissionOn = false;
                  this.StartedRaid = false;
                  Game.Player.Money += 550000;
                  if (this.BlipItem_SetupMission != (Blip) null)
                    this.BlipItem_SetupMission.Remove();
                  new MissionScreen().SetPass("Executive Cargo Warehouse Raid", 550000, "The Player did not respond to the raid");
                  this.DisplayHelpTextThisFrame(this.GetHostName() + " Good job boss, you just prevented a raid!");
                  UI.Notify(this.GetHostName() + " Good job boss, you just prevented a raid!");
                }
                if ((double) this.SpawnAttackerTimer != 0.0)
                  this.SpawnAttackerTimer -= 0.75f;
                if ((double) this.SpawnAttackerTimer <= 0.0)
                {
                  System.Random random1 = new System.Random();
                  this.SpawnAttackerTimer = (float) random1.Next(100, 300);
                  if (this.RaidEnemyTime == 1)
                  {
                    if (random1.Next(1, 100) < 25)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Chino2, Game.Player.Character.Position.Around((float) random1.Next(100, 500)));
                      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
                      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Vagos01GFY);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.MicroSMG);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.MicroSMG);
                      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                      this.SetupVagos(vehicle, 1);
                      this.SupplyMissionVehicles.Add(vehicle);
                      vehicle.PlaceOnNextStreet();
                    }
                    if (random1.Next(1, 100) > 25 && random1.Next(1, 100) < 50)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Faction2, Game.Player.Character.Position.Around((float) random1.Next(100, 500)));
                      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
                      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Families01GFY);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
                      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.MicroSMG);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.MicroSMG);
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                      this.SetupFamilies(vehicle, 1);
                      this.SupplyMissionVehicles.Add(vehicle);
                      vehicle.PlaceOnNextStreet();
                    }
                    if (random1.Next(1, 100) > 50 && random1.Next(1, 100) < 75)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Buccaneer2, Game.Player.Character.Position.Around((float) random1.Next(100, 500)));
                      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
                      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.BallaEast01GMY);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
                      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.MicroSMG);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.MicroSMG);
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                      this.SetupBallas(vehicle, 1);
                      this.SupplyMissionVehicles.Add(vehicle);
                      vehicle.PlaceOnNextStreet();
                    }
                    if (random1.Next(1, 100) > 75 && random1.Next(1, 100) < 100)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Moonbeam2, Game.Player.Character.Position.Around((float) random1.Next(100, 500)));
                      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
                      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.BallaEast01GMY);
                      vehicle.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
                      vehicle.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.BallaEast01GMY);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.LeftRear), WeaponHash.AssaultRifle);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.RightRear), WeaponHash.AssaultRifle);
                      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.MicroSMG);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.MicroSMG);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.LeftRear), WeaponHash.MicroSMG);
                      this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.RightRear), WeaponHash.MicroSMG);
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.RightRear));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.LeftRear));
                      this.SetupBallas(vehicle, 2);
                      this.SupplyMissionVehicles.Add(vehicle);
                      vehicle.PlaceOnNextStreet();
                    }
                  }
                  if (this.RaidEnemyTime == 0)
                  {
                    if (random1.Next(1, 100) < 25)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Police, Game.Player.Character.Position.Around((float) random1.Next(100, 500)));
                      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) vehicle.Handle, (InputArgument) 0);
                      vehicle.PrimaryColor = VehicleColor.MetallicWhite;
                      vehicle.SecondaryColor = VehicleColor.MetallicWhite;
                      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
                      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.CombatPistol);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.CombatPistol);
                      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                      this.SupplyMissionVehicles.Add(vehicle);
                      vehicle.PlaceOnNextStreet();
                    }
                    if (random1.Next(1, 100) > 25 && random1.Next(1, 100) < 50)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Police3, Game.Player.Character.Position.Around((float) random1.Next(100, 500)));
                      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) vehicle.Handle, (InputArgument) 0);
                      vehicle.PrimaryColor = VehicleColor.MetallicWhite;
                      vehicle.SecondaryColor = VehicleColor.MetallicWhite;
                      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SMY);
                      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SFY);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.CombatPistol);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.CombatPistol);
                      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                      this.SupplyMissionVehicles.Add(vehicle);
                      vehicle.PlaceOnNextStreet();
                    }
                    if (random1.Next(1, 100) > 50 && random1.Next(1, 100) < 75)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Police4, Game.Player.Character.Position.Around((float) random1.Next(100, 500)));
                      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) vehicle.Handle, (InputArgument) 0);
                      vehicle.PrimaryColor = VehicleColor.MetallicWhite;
                      vehicle.SecondaryColor = VehicleColor.MetallicWhite;
                      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SMY);
                      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SFY);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.CombatPistol);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.CombatPistol);
                      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                      this.SupplyMissionVehicles.Add(vehicle);
                      vehicle.PlaceOnNextStreet();
                    }
                    if (random1.Next(1, 100) > 75 && random1.Next(1, 100) < 100)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.PoliceT, Game.Player.Character.Position.Around((float) random1.Next(100, 500)));
                      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) vehicle.Handle, (InputArgument) 0);
                      vehicle.PrimaryColor = VehicleColor.MetallicWhite;
                      vehicle.SecondaryColor = VehicleColor.MetallicWhite;
                      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SMY);
                      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SFY);
                      vehicle.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.Cop01SMY);
                      vehicle.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.Cop01SMY);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.LeftRear), WeaponHash.CarbineRifle);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.RightRear), WeaponHash.CarbineRifle);
                      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
                      vehicle.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.CombatPistol);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.CombatPistol);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.LeftRear), WeaponHash.CombatPistol);
                      this.ArmedPed2(vehicle.GetPedOnSeat(VehicleSeat.RightRear), WeaponHash.CombatPistol);
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.RightRear));
                      this.SupplyMissionPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.LeftRear));
                      this.SupplyMissionVehicles.Add(vehicle);
                      vehicle.PlaceOnNextStreet();
                    }
                  }
                  foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                  {
                    if (supplyMissionPed.Alpha != 0)
                    {
                      supplyMissionPed.CurrentBlip.Remove();
                      supplyMissionPed.AddBlip();
                      supplyMissionPed.CurrentBlip.Sprite = BlipSprite.Enemy;
                      supplyMissionPed.CurrentBlip.Color = BlipColor.Red;
                      supplyMissionPed.CurrentBlip.Name = "Enemy";
                      supplyMissionPed.CurrentBlip.Scale = 0.8f;
                      supplyMissionPed.Accuracy = 400;
                      int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                      Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) supplyMissionPed, (InputArgument) num);
                      Function.Call(Hash._0x9F7794730795E019, (InputArgument) supplyMissionPed, (InputArgument) 0, (InputArgument) 0);
                      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) supplyMissionPed, (InputArgument) 1);
                      supplyMissionPed.Task.FightAgainst(Game.Player.Character);
                    }
                  }
                }
              }
            }
            if (!Game.Player.Character.IsAlive)
            {
              this.SpawnAttackerTimer = 0.0f;
              foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
              {
                if ((Entity) supplyMissionPed != (Entity) null)
                  supplyMissionPed.Delete();
              }
              foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
              {
                if ((Entity) supplyMissionVehicle != (Entity) null)
                  supplyMissionVehicle.Delete();
              }
              this.SupplyMissionID = 0;
              this.SupplyMissionOn = false;
              this.StartedRaid = false;
              if (this.BlipItem_SetupMission != (Blip) null)
                this.BlipItem_SetupMission.Remove();
              this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + this.CurrentRaidWarehouse.ToString() + ".ini");
              for (int index = 1; index < 112; ++index)
              {
                if (index < 17 && this.CargoWarehouses[this.IndexRaidWarehouse].Maxcrates >= 16)
                {
                  this.CrateConfig.SetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1);
                  this.CrateConfig.Save();
                }
                else if (index >= 17 && index < 43 && this.CargoWarehouses[this.IndexRaidWarehouse].Maxcrates >= 42)
                {
                  this.CrateConfig.SetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1);
                  this.CrateConfig.Save();
                }
                else if (index >= 43 && this.CargoWarehouses[this.IndexRaidWarehouse].Maxcrates >= 111)
                {
                  this.CrateConfig.SetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1);
                  this.CrateConfig.Save();
                }
              }
              this.SupplyMissionID = 0;
              this.SupplyMissionOn = false;
              new MissionScreen().SetFail("Executive Cargo Warehouse Raid", 0, "The Player did not respond to the raid");
              SubBusinesses.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Executive Cargo Warehouse", "Raid Failed, We've lost all cargo!");
              this.NextHour = -1;
              this.DisplayHelpTextThisFrame(this.GetHostName() + " the raid was not stopped, we cannot aford to do this again");
              UI.Notify(this.GetHostName() + " the raid was not stopped, we cannot aford to do this again");
            }
          }
          if (!this.WaitingForRaid)
          {
            if (Game.GameTime < this.RaidHour)
            {
              if ((double) World.GetDistance(Game.Player.Character.Position, this.RaidLocation) < 30.0)
              {
                this.isAtRaidLocation = true;
                this.WaitingForRaid = true;
                SubBusinesses.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Executive Cargo Warehouse", "A Raid has been started, kill all enemies to complete the raid");
              }
            }
            else
            {
              this.LoadCrates("scripts//HKH191sBusinessMods//ExecutiveBusiness//CargoWarehouses//PlayerWarehouse_" + this.CurrentRaidWarehouse.ToString() + ".ini");
              for (int index = 1; index < 112; ++index)
              {
                if (index < 17 && this.CargoWarehouses[this.IndexRaidWarehouse].Maxcrates >= 16)
                {
                  this.CrateConfig.SetValue<int>("Crates-Small-Warehouse", "CrateID_" + index.ToString(), -1);
                  this.CrateConfig.Save();
                }
                else if (index >= 17 && index < 43 && this.CargoWarehouses[this.IndexRaidWarehouse].Maxcrates >= 42)
                {
                  this.CrateConfig.SetValue<int>("Crates-Medium-Warehouse", "CrateID_" + index.ToString(), -1);
                  this.CrateConfig.Save();
                }
                else if (index >= 43 && this.CargoWarehouses[this.IndexRaidWarehouse].Maxcrates >= 111)
                {
                  this.CrateConfig.SetValue<int>("Crates-Large-Warehouse", "CrateID_" + index.ToString(), -1);
                  this.CrateConfig.Save();
                }
              }
              this.SupplyMissionID = 0;
              this.SupplyMissionOn = false;
              new MissionScreen().SetFail("Executive Cargo Warehouse Raid", 0, "The Player did not respond to the raid");
              SubBusinesses.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Executive Cargo Warehouse", "Raid Failed, We've lost all cargo!");
              this.NextHour = -1;
            }
          }
        }
        foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
        {
          if (supplyMissionBlip != (Blip) null)
            supplyMissionBlip.ShowRoute = true;
        }
        if (Game.Player.IsAlive)
        {
          if (this.SupplyMissionID == 3)
          {
            if (this.SupplyMissionStage == 1)
            {
              UI.ShowSubtitle("Find the ~b~Tug~w~");
              if ((double) World.GetDistance(Game.Player.Character.Position, this.SupplyMissionMainVehicle.Position) < 30.0)
                this.SupplyMissionStage = 2;
            }
            if (this.SupplyMissionStage == 2)
            {
              if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
              {
                Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
                if ((Entity) currentVehicle == (Entity) this.SupplyMissionMainVehicle)
                {
                  currentVehicle.IsInvincible = false;
                  foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                  {
                    if (supplyMissionBlip != (Blip) null)
                      supplyMissionBlip.Remove();
                  }
                  foreach (SubBusinesses.Flare flare in this.Cargo)
                  {
                    if ((Entity) flare.FlareProp != (Entity) null)
                      flare.FlareProp.Delete();
                  }
                  if (this.CargoDropped.Count > 0)
                    this.CargoDropped.Clear();
                  if (this.SelectedSellPoints.Count > 0)
                    this.SelectedSellPoints.Clear();
                  if (this.CompletedSellPoints.Count > 0)
                    this.CompletedSellPoints.Clear();
                  this.Selectedpoints = 15;
                  float num = (float) (this.GetCrateCountByIndex() / this.CargoWarehouses[this.CurrentWarehouse].Maxcrates * 100);
                  if ((double) num <= 10.0)
                    this.Selectedpoints = 3;
                  if ((double) num > 10.0 && (double) num <= 25.0)
                    this.Selectedpoints = 5;
                  if ((double) num > 25.0 && (double) num <= 35.0)
                    this.Selectedpoints = 6;
                  if ((double) num > 35.0 && (double) num <= 50.0)
                    this.Selectedpoints = 8;
                  if ((double) num > 50.0 && (double) num <= 65.0)
                    this.Selectedpoints = 9;
                  if ((double) num > 65.0 && (double) num <= 80.0)
                    this.Selectedpoints = 11;
                  if ((double) num > 80.0 && (double) num <= 100.0)
                    this.Selectedpoints = 15;
                  this.PointstoGoto = this.Selectedpoints;
                  System.Random random = new System.Random();
                  for (int index = 0; index < 1000; ++index)
                  {
                    if (this.Selectedpoints > 0)
                    {
                      Vector3 waterSellPoint = this.WaterSellPoints[random.Next(0, this.WaterSellPoints.Count)];
                      if (!this.SelectedSellPoints.Contains(waterSellPoint))
                      {
                        --this.Selectedpoints;
                        this.SelectedSellPoints.Add(waterSellPoint);
                        Blip blip1 = World.CreateBlip(waterSellPoint);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Yellow;
                        blip1.Name = "Drop Off";
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(waterSellPoint);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Yellow;
                        blip2.Name = "Drop Off";
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                      }
                    }
                    else if (this.Selectedpoints <= 0)
                      this.SupplyMissionStage = 3;
                  }
                }
                else
                  UI.ShowSubtitle("Enter the ~b~Tug~w~");
              }
              else
                UI.ShowSubtitle("Enter the ~b~Tug~w~");
            }
            if (this.SupplyMissionStage == 3)
            {
              this.drawSprite2("timerbars", "all_black_bg", 0.89f, 0.97f, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 130);
              this.drawText(("TOTAL DELIVERED   " + this.PointsBeenAt.ToString() + "/" + this.PointstoGoto.ToString()).ToString(), 0.82f, 0.961f, 0.4f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              if (this.PointsBeenAt < this.PointstoGoto)
                UI.ShowSubtitle("Deliver the Cargo to the ~y~drop-offs");
              if (this.PointsBeenAt >= this.PointstoGoto)
              {
                this.SupplyMissionStage = 4;
                UI.ShowSubtitle("Deliver the Cargo to the ~y~drop-offs");
              }
              foreach (Vector3 selectedSellPoint in this.SelectedSellPoints)
              {
                if (!this.CompletedSellPoints.Contains(selectedSellPoint))
                {
                  if ((double) World.GetDistance(this.SupplyMissionMainVehicle.Position, selectedSellPoint) < 100.0)
                    World.DrawMarker(MarkerType.UpsideDownCone, selectedSellPoint, Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 3f), this.mainColor);
                  if ((double) World.GetDistance(this.SupplyMissionMainVehicle.Position, selectedSellPoint) < 5.0)
                  {
                    this.CompletedSellPoints.Add(selectedSellPoint);
                    ++this.PointsBeenAt;
                    ++this.AmttoDeliver;
                    foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                    {
                      if (supplyMissionBlip != (Blip) null && (double) World.GetDistance(supplyMissionBlip.Position, selectedSellPoint) < 30.0)
                        supplyMissionBlip.Remove();
                    }
                    foreach (SubBusinesses.Flare flare in this.SellPointsSmoke_Water)
                    {
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) flare.FlareID_1, (InputArgument) false);
                      if ((Entity) flare.FlareProp != (Entity) null && (double) World.GetDistance(flare.FlareProp.Position, selectedSellPoint) < 30.0)
                        flare.FlareProp.Delete();
                    }
                  }
                }
              }
            }
            if (this.SupplyMissionStage == 4)
            {
              UI.ShowSubtitle("Return to the ~b~Warehouse ");
              if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentWarehousePos) < 20.0)
              {
                List<string> stringList = new List<string>();
                MissionScreen missionScreen = new MissionScreen();
                int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                float num = this.GetWarehouseValue((int) ((double) this.GetCrateCountByID(warehouseId) * (double) this.PercentageSell)) * ((float) this.AmttoDeliver / (float) this.PointsBeenAt);
                missionScreen.SetPass2("Securoserv : Sell Cargo", (int) num, this.AmttoDeliver.ToString() + " of " + this.PointsBeenAt.ToString() + " Cargo delivered");
                if (warehouseId == 1)
                {
                  ++this.SS_Warehouse1SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesMade", this.SS_Warehouse1SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse1LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1LifetimeEarnings", this.SS_Warehouse1LifetimeEarnings);
                  this.Config.Save();
                }
                if (warehouseId == 2)
                {
                  ++this.SS_Warehouse2SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesMade", this.SS_Warehouse2SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse2LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2LifetimeEarnings", this.SS_Warehouse2LifetimeEarnings);
                  this.Config.Save();
                }
                if (warehouseId == 3)
                {
                  ++this.SS_Warehouse3SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesMade", this.SS_Warehouse3SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse3LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3LifetimeEarnings", this.SS_Warehouse3LifetimeEarnings);
                  this.Config.Save();
                }
                if (warehouseId == 4)
                {
                  ++this.SS_Warehouse4SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesMade", this.SS_Warehouse4SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse4LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4LifetimeEarnings", this.SS_Warehouse4LifetimeEarnings);
                  this.Config.Save();
                }
                if (warehouseId == 5)
                {
                  ++this.SS_Warehouse5SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesMade", this.SS_Warehouse5SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse5LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5LifetimeEarnings", this.SS_Warehouse5LifetimeEarnings);
                  this.Config.Save();
                }
                Script.Wait(6000);
                this.SupplyMissionStage = 5;
              }
            }
            if (this.SupplyMissionStage == 5)
            {
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
              MissionScreen missionScreen = new MissionScreen();
              this.SupplyMissionStage = 0;
              this.SupplyMissionOn = false;
              this.SupplyMissionID = 0;
              Script.Wait(2500);
              Game.FadeScreenIn(2500);
            }
          }
          if (this.SupplyMissionID == 2)
          {
            if (this.SupplyMissionStage == 1)
            {
              if (this.IsIninterior)
                UI.ShowSubtitle("Exit the ~b~Warehouse~w~");
              if (!this.IsIninterior)
              {
                UI.ShowSubtitle("Find the ~b~Brickades~w~");
                if ((double) World.GetDistance(Game.Player.Character.Position, this.DeliveryVehicle1.Position) < 30.0)
                {
                  foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                  {
                    if (supplyMissionBlip != (Blip) null)
                      supplyMissionBlip.Remove();
                  }
                  if (this.Deliveries >= 1)
                  {
                    if ((Entity) this.DeliveryVehicle1 != (Entity) null)
                    {
                      this.DeliveryVehicle1.AddBlip();
                      this.DeliveryVehicle1.CurrentBlip.Sprite = BlipSprite.Truck;
                      this.DeliveryVehicle1.CurrentBlip.Color = BlipColor.Blue;
                      this.DeliveryVehicle1.CurrentBlip.Name = "Deliver Vehicle to Drop Point";
                    }
                    List<Vector3> vector3List = new List<Vector3>();
                    System.Random random = new System.Random();
                    this.SellMission = random.Next(0, 100);
                    if (this.SellMission <= 50)
                      vector3List = this.GroundDropPoint_LS;
                    if (this.SellMission > 50)
                      vector3List = this.GroundDropPoint_BC;
                    this.AreaOffset1 = vector3List[random.Next(0, vector3List.Count)];
                    Script.Wait(1);
                    this.DeliverLocBlip1 = World.CreateBlip(this.AreaOffset1);
                    this.DeliverLocBlip1.Sprite = BlipSprite.SpecialCargo;
                    this.DeliverLocBlip1.Color = BlipColor.Yellow;
                    this.DeliverLocBlip1.Name = "Deliver Cargo Vehicle";
                    this.DeliverLocBlip1.Alpha = (int) byte.MaxValue;
                    this.DeliverLocBlip1.IsShortRange = true;
                    this.SupplyMissionBlips.Add(this.DeliverLocBlip1);
                  }
                  if (this.Deliveries >= 2)
                  {
                    if ((Entity) this.DeliveryVehicle2 != (Entity) null)
                    {
                      this.DeliveryVehicle2.AddBlip();
                      this.DeliveryVehicle2.CurrentBlip.Sprite = BlipSprite.Truck;
                      this.DeliveryVehicle2.CurrentBlip.Color = BlipColor.Blue;
                      this.DeliveryVehicle2.CurrentBlip.Name = "Deliver Vehicle to Drop Point";
                    }
                    List<Vector3> vector3List = new List<Vector3>();
                    System.Random random = new System.Random();
                    this.SellMission = random.Next(0, 100);
                    if (this.SellMission <= 50)
                      vector3List = this.GroundDropPoint_LS;
                    if (this.SellMission > 50)
                      vector3List = this.GroundDropPoint_BC;
                    this.AreaOffset2 = vector3List[random.Next(0, vector3List.Count)];
                    Script.Wait(1);
                    this.DeliverLocBlip2 = World.CreateBlip(this.AreaOffset2);
                    this.DeliverLocBlip2.Sprite = BlipSprite.SpecialCargo;
                    this.DeliverLocBlip2.Color = BlipColor.Yellow;
                    this.DeliverLocBlip2.Name = "Deliver Cargo Vehicle";
                    this.DeliverLocBlip2.Alpha = (int) byte.MaxValue;
                    this.DeliverLocBlip2.IsShortRange = true;
                    this.SupplyMissionBlips.Add(this.DeliverLocBlip2);
                  }
                  if (this.Deliveries >= 3)
                  {
                    if ((Entity) this.DeliveryVehicle3 != (Entity) null)
                    {
                      this.DeliveryVehicle3.AddBlip();
                      this.DeliveryVehicle3.CurrentBlip.Sprite = BlipSprite.Truck;
                      this.DeliveryVehicle3.CurrentBlip.Color = BlipColor.Blue;
                      this.DeliveryVehicle3.CurrentBlip.Name = "Deliver Vehicle to Drop Point";
                    }
                    List<Vector3> vector3List = new List<Vector3>();
                    System.Random random = new System.Random();
                    this.SellMission = random.Next(0, 100);
                    if (this.SellMission <= 50)
                      vector3List = this.GroundDropPoint_LS;
                    if (this.SellMission > 50)
                      vector3List = this.GroundDropPoint_BC;
                    this.AreaOffset3 = vector3List[random.Next(0, vector3List.Count)];
                    Script.Wait(1);
                    this.DeliverLocBlip3 = World.CreateBlip(this.AreaOffset3);
                    this.DeliverLocBlip3.Sprite = BlipSprite.SpecialCargo;
                    this.DeliverLocBlip3.Color = BlipColor.Yellow;
                    this.DeliverLocBlip3.Name = "Deliver Cargo Vehicle";
                    this.DeliverLocBlip3.Alpha = (int) byte.MaxValue;
                    this.DeliverLocBlip3.IsShortRange = true;
                    this.SupplyMissionBlips.Add(this.DeliverLocBlip3);
                  }
                  if (this.Deliveries >= 4)
                  {
                    if ((Entity) this.DeliveryVehicle4 != (Entity) null)
                    {
                      this.DeliveryVehicle4.AddBlip();
                      this.DeliveryVehicle4.CurrentBlip.Sprite = BlipSprite.Truck;
                      this.DeliveryVehicle4.CurrentBlip.Color = BlipColor.Blue;
                      this.DeliveryVehicle4.CurrentBlip.Name = "Deliver Vehicle to Drop Point";
                    }
                    List<Vector3> vector3List = new List<Vector3>();
                    System.Random random = new System.Random();
                    this.SellMission = random.Next(0, 100);
                    if (this.SellMission <= 50)
                      vector3List = this.GroundDropPoint_LS;
                    if (this.SellMission > 50)
                      vector3List = this.GroundDropPoint_BC;
                    this.AreaOffset4 = vector3List[random.Next(0, vector3List.Count)];
                    Script.Wait(1);
                    this.DeliverLocBlip4 = World.CreateBlip(this.AreaOffset4);
                    this.DeliverLocBlip4.Sprite = BlipSprite.SpecialCargo;
                    this.DeliverLocBlip4.Color = BlipColor.Yellow;
                    this.DeliverLocBlip4.Name = "Deliver Cargo Vehicle";
                    this.DeliverLocBlip4.Alpha = (int) byte.MaxValue;
                    this.DeliverLocBlip4.IsShortRange = true;
                    this.SupplyMissionBlips.Add(this.DeliverLocBlip4);
                  }
                  this.SupplyMissionStage = 2;
                }
              }
            }
            if (this.SupplyMissionStage == 2)
            {
              if ((Entity) this.DeliveryVehicle1 != (Entity) null && !this.DeliveredVehicle1 && !this.DeliveryVehicle1.IsAlive)
              {
                new MissionScreen().SetFail("Securoserv : Sell Cargo", 8000, "A Sell Vehicle Was Destroyed");
                int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                if (warehouseId == 1)
                {
                  ++this.SS_Warehouse1SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesFailed", this.SS_Warehouse1SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 2)
                {
                  ++this.SS_Warehouse2SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesFailed", this.SS_Warehouse2SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 3)
                {
                  ++this.SS_Warehouse3SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesFailed", this.SS_Warehouse3SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 4)
                {
                  ++this.SS_Warehouse4SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesFailed", this.SS_Warehouse4SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 5)
                {
                  ++this.SS_Warehouse5SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesFailed", this.SS_Warehouse5SalesFailed);
                  this.Config.Save();
                }
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
                new MissionScreen().SetFail("Securoserv : Sell Cargo", 8000, "A Sell Vehicle Was Destroyed");
                int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                if (warehouseId == 1)
                {
                  ++this.SS_Warehouse1SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesFailed", this.SS_Warehouse1SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 2)
                {
                  ++this.SS_Warehouse2SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesFailed", this.SS_Warehouse2SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 3)
                {
                  ++this.SS_Warehouse3SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesFailed", this.SS_Warehouse3SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 4)
                {
                  ++this.SS_Warehouse4SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesFailed", this.SS_Warehouse4SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 5)
                {
                  ++this.SS_Warehouse5SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesFailed", this.SS_Warehouse5SalesFailed);
                  this.Config.Save();
                }
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
                new MissionScreen().SetFail("Securoserv : Sell Cargo", 8000, "A Sell Vehicle Was Destroyed");
                int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                if (warehouseId == 1)
                {
                  ++this.SS_Warehouse1SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesFailed", this.SS_Warehouse1SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 2)
                {
                  ++this.SS_Warehouse2SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesFailed", this.SS_Warehouse2SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 3)
                {
                  ++this.SS_Warehouse3SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesFailed", this.SS_Warehouse3SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 4)
                {
                  ++this.SS_Warehouse4SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesFailed", this.SS_Warehouse4SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 5)
                {
                  ++this.SS_Warehouse5SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesFailed", this.SS_Warehouse5SalesFailed);
                  this.Config.Save();
                }
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
                new MissionScreen().SetFail("Securoserv : Sell Cargo", 8000, "A Sell Vehicle Was Destroyed");
                int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                if (warehouseId == 1)
                {
                  ++this.SS_Warehouse1SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesFailed", this.SS_Warehouse1SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 2)
                {
                  ++this.SS_Warehouse2SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesFailed", this.SS_Warehouse2SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 3)
                {
                  ++this.SS_Warehouse3SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesFailed", this.SS_Warehouse3SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 4)
                {
                  ++this.SS_Warehouse4SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesFailed", this.SS_Warehouse4SalesFailed);
                  this.Config.Save();
                }
                if (warehouseId == 5)
                {
                  ++this.SS_Warehouse5SalesFailed;
                  this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesFailed", this.SS_Warehouse5SalesFailed);
                  this.Config.Save();
                }
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
            }
            if (this.SupplyMissionStage == 2)
            {
              if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
              {
                if (this.IsIninterior)
                  UI.ShowSubtitle("Exit the ~b~Warehouse~w~");
                if (!this.IsIninterior)
                  UI.ShowSubtitle("Enter a ~b~Brickade~w~");
              }
              if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
              {
                Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
                if ((Entity) currentVehicle != (Entity) this.DeliveryVehicle1 && (Entity) currentVehicle != (Entity) this.DeliveryVehicle2 && ((Entity) currentVehicle != (Entity) this.DeliveryVehicle3 && (Entity) currentVehicle != (Entity) this.DeliveryVehicle4))
                  UI.ShowSubtitle("Enter a ~b~Brickade~w~");
                if ((Entity) this.DeliveryVehicle1 != (Entity) null)
                {
                  if (this.Deliveries == 1 && this.DeliveredtoLoc1)
                  {
                    List<string> stringList = new List<string>();
                    MissionScreen missionScreen = new MissionScreen();
                    int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                    float num = this.GetWarehouseValue((int) ((double) this.GetCrateCountByID(warehouseId) * (double) this.PercentageSell)) * ((float) this.AmttoDeliver / (float) this.PointsBeenAt);
                    missionScreen.SetPass2("Securoserv : Sell Cargo", (int) num, "All Cargo delivered");
                    if (warehouseId == 1)
                    {
                      ++this.SS_Warehouse1SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesMade", this.SS_Warehouse1SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse1LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1LifetimeEarnings", this.SS_Warehouse1LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 2)
                    {
                      ++this.SS_Warehouse2SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesMade", this.SS_Warehouse2SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse2LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2LifetimeEarnings", this.SS_Warehouse2LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 3)
                    {
                      ++this.SS_Warehouse3SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesMade", this.SS_Warehouse3SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse3LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3LifetimeEarnings", this.SS_Warehouse3LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 4)
                    {
                      ++this.SS_Warehouse4SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesMade", this.SS_Warehouse4SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse4LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4LifetimeEarnings", this.SS_Warehouse4LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 5)
                    {
                      ++this.SS_Warehouse5SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesMade", this.SS_Warehouse5SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse5LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5LifetimeEarnings", this.SS_Warehouse5LifetimeEarnings);
                      this.Config.Save();
                    }
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
                    UI.ShowSubtitle("Deliver the Cargo to a ~y~Drop off~w~");
                  if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset1) < 200.0)
                  {
                    Vector3 areaOffset1 = this.AreaOffset1;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset1.X, areaOffset1.Y, World.GetGroundHeight(new Vector3(areaOffset1.X, areaOffset1.Y, areaOffset1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc1 && !this.NearLoc1)
                    {
                      Vector3 areaOffset2 = this.AreaOffset2;
                      this.NearLoc1 = true;
                      this.CreateSmoke(areaOffset2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset2) < 200.0)
                  {
                    Vector3 areaOffset2 = this.AreaOffset2;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset2.X, areaOffset2.Y, World.GetGroundHeight(new Vector3(areaOffset2.X, areaOffset2.Y, areaOffset2.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc2 && !this.NearLoc2)
                    {
                      Vector3 areaOffset1 = this.AreaOffset1;
                      this.NearLoc2 = true;
                      this.CreateSmoke(areaOffset1);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset3) < 200.0)
                  {
                    Vector3 areaOffset3_1 = this.AreaOffset3;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset3_1.X, areaOffset3_1.Y, World.GetGroundHeight(new Vector3(areaOffset3_1.X, areaOffset3_1.Y, areaOffset3_1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc3 && !this.NearLoc3)
                    {
                      Vector3 areaOffset3_2 = this.AreaOffset3;
                      this.NearLoc3 = true;
                      this.CreateSmoke(areaOffset3_2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset4) < 200.0)
                  {
                    Vector3 areaOffset4_1 = this.AreaOffset4;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset4_1.X, areaOffset4_1.Y, World.GetGroundHeight(new Vector3(areaOffset4_1.X, areaOffset4_1.Y, areaOffset4_1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc4 && !this.NearLoc4)
                    {
                      Vector3 areaOffset4_2 = this.AreaOffset4;
                      this.NearLoc4 = true;
                      this.CreateSmoke(areaOffset4_2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset1) < 5.0 && !this.DeliveredtoLoc1)
                  {
                    this.DeliveredVehicle1 = true;
                    if (this.DeliveryVehicle1.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle1.CurrentBlip.Remove();
                    if (this.DeliverLocBlip1 != (Blip) null)
                      this.DeliverLocBlip1.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc1 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle1, true);
                    this.DeliveryVehicle1.MarkAsNoLongerNeeded();
                    this.NearLoc1 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset2) < 5.0 && !this.DeliveredtoLoc2)
                  {
                    this.DeliveredVehicle1 = true;
                    if (this.DeliveryVehicle1.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle1.CurrentBlip.Remove();
                    if (this.DeliverLocBlip2 != (Blip) null)
                      this.DeliverLocBlip2.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc2 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle1, true);
                    this.DeliveryVehicle1.MarkAsNoLongerNeeded();
                    this.NearLoc2 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset3) < 5.0 && !this.DeliveredtoLoc3)
                  {
                    this.DeliveredVehicle1 = true;
                    if (this.DeliveryVehicle1.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle1.CurrentBlip.Remove();
                    if (this.DeliverLocBlip3 != (Blip) null)
                      this.DeliverLocBlip3.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc3 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle1, true);
                    this.DeliveryVehicle1.MarkAsNoLongerNeeded();
                    this.NearLoc3 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle1.Position, this.AreaOffset4) < 5.0 && !this.DeliveredtoLoc4)
                  {
                    this.DeliveredVehicle1 = true;
                    if (this.DeliveryVehicle1.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle1.CurrentBlip.Remove();
                    if (this.DeliverLocBlip4 != (Blip) null)
                      this.DeliverLocBlip4.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc4 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle1, true);
                    this.DeliveryVehicle1.MarkAsNoLongerNeeded();
                    this.NearLoc4 = false;
                  }
                }
                if ((Entity) this.DeliveryVehicle2 != (Entity) null)
                {
                  if (this.Deliveries == 2 && this.DeliveredtoLoc1 && this.DeliveredtoLoc2)
                  {
                    List<string> stringList = new List<string>();
                    MissionScreen missionScreen = new MissionScreen();
                    int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                    float num = this.GetWarehouseValue((int) ((double) this.GetCrateCountByID(warehouseId) * (double) this.PercentageSell)) * ((float) this.AmttoDeliver / (float) this.PointsBeenAt);
                    missionScreen.SetPass2("Securoserv : Sell Cargo", (int) num, "All Cargo delivered");
                    if (warehouseId == 1)
                    {
                      ++this.SS_Warehouse1SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesMade", this.SS_Warehouse1SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse1LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1LifetimeEarnings", this.SS_Warehouse1LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 2)
                    {
                      ++this.SS_Warehouse2SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesMade", this.SS_Warehouse2SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse2LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2LifetimeEarnings", this.SS_Warehouse2LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 3)
                    {
                      ++this.SS_Warehouse3SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesMade", this.SS_Warehouse3SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse3LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3LifetimeEarnings", this.SS_Warehouse3LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 4)
                    {
                      ++this.SS_Warehouse4SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesMade", this.SS_Warehouse4SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse4LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4LifetimeEarnings", this.SS_Warehouse4LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 5)
                    {
                      ++this.SS_Warehouse5SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesMade", this.SS_Warehouse5SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse5LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5LifetimeEarnings", this.SS_Warehouse5LifetimeEarnings);
                      this.Config.Save();
                    }
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
                    UI.ShowSubtitle("Deliver the Cargo to a ~y~Drop off~w~");
                  if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset1) < 200.0)
                  {
                    Vector3 areaOffset1 = this.AreaOffset1;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset1.X, areaOffset1.Y, World.GetGroundHeight(new Vector3(areaOffset1.X, areaOffset1.Y, areaOffset1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc1 && !this.NearLoc1)
                    {
                      Vector3 areaOffset2 = this.AreaOffset2;
                      this.NearLoc1 = true;
                      this.CreateSmoke(areaOffset2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset2) < 200.0)
                  {
                    Vector3 areaOffset2 = this.AreaOffset2;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset2.X, areaOffset2.Y, World.GetGroundHeight(new Vector3(areaOffset2.X, areaOffset2.Y, areaOffset2.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc2 && !this.NearLoc2)
                    {
                      Vector3 areaOffset1 = this.AreaOffset1;
                      this.NearLoc2 = true;
                      this.CreateSmoke(areaOffset1);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset3) < 200.0)
                  {
                    Vector3 areaOffset3_1 = this.AreaOffset3;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset3_1.X, areaOffset3_1.Y, World.GetGroundHeight(new Vector3(areaOffset3_1.X, areaOffset3_1.Y, areaOffset3_1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc3 && !this.NearLoc3)
                    {
                      Vector3 areaOffset3_2 = this.AreaOffset3;
                      this.NearLoc3 = true;
                      this.CreateSmoke(areaOffset3_2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset4) < 200.0)
                  {
                    Vector3 areaOffset4_1 = this.AreaOffset4;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset4_1.X, areaOffset4_1.Y, World.GetGroundHeight(new Vector3(areaOffset4_1.X, areaOffset4_1.Y, areaOffset4_1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc4 && !this.NearLoc4)
                    {
                      Vector3 areaOffset4_2 = this.AreaOffset4;
                      this.NearLoc4 = true;
                      this.CreateSmoke(areaOffset4_2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset1) < 5.0 && !this.DeliveredtoLoc1)
                  {
                    this.DeliveredVehicle2 = true;
                    if (this.DeliveryVehicle2.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle2.CurrentBlip.Remove();
                    if (this.DeliverLocBlip1 != (Blip) null)
                      this.DeliverLocBlip1.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc1 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle2, true);
                    this.DeliveryVehicle2.MarkAsNoLongerNeeded();
                    this.NearLoc1 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset2) < 5.0 && !this.DeliveredtoLoc2)
                  {
                    this.DeliveredVehicle2 = true;
                    if (this.DeliveryVehicle2.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle2.CurrentBlip.Remove();
                    if (this.DeliverLocBlip2 != (Blip) null)
                      this.DeliverLocBlip2.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc2 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle2, true);
                    this.DeliveryVehicle2.MarkAsNoLongerNeeded();
                    this.NearLoc2 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset3) < 5.0 && !this.DeliveredtoLoc3)
                  {
                    this.DeliveredVehicle2 = true;
                    if (this.DeliveryVehicle2.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle2.CurrentBlip.Remove();
                    if (this.DeliverLocBlip3 != (Blip) null)
                      this.DeliverLocBlip3.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc3 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle2, true);
                    this.DeliveryVehicle2.MarkAsNoLongerNeeded();
                    this.NearLoc3 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle2.Position, this.AreaOffset4) < 5.0 && !this.DeliveredtoLoc4)
                  {
                    this.DeliveredVehicle2 = true;
                    if (this.DeliveryVehicle2.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle2.CurrentBlip.Remove();
                    if (this.DeliverLocBlip4 != (Blip) null)
                      this.DeliverLocBlip4.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc4 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle2, true);
                    this.DeliveryVehicle2.MarkAsNoLongerNeeded();
                    this.NearLoc4 = false;
                  }
                }
                if ((Entity) this.DeliveryVehicle3 != (Entity) null)
                {
                  if (this.Deliveries == 3 && this.DeliveredtoLoc1 && (this.DeliveredtoLoc2 && this.DeliveredtoLoc3))
                  {
                    List<string> stringList = new List<string>();
                    MissionScreen missionScreen = new MissionScreen();
                    int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                    float num = this.GetWarehouseValue((int) ((double) this.GetCrateCountByID(warehouseId) * (double) this.PercentageSell)) * ((float) this.AmttoDeliver / (float) this.PointsBeenAt);
                    missionScreen.SetPass2("Securoserv : Sell Cargo", (int) num, "All Cargo delivered");
                    if (warehouseId == 1)
                    {
                      ++this.SS_Warehouse1SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesMade", this.SS_Warehouse1SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse1LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1LifetimeEarnings", this.SS_Warehouse1LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 2)
                    {
                      ++this.SS_Warehouse2SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesMade", this.SS_Warehouse2SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse2LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2LifetimeEarnings", this.SS_Warehouse2LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 3)
                    {
                      ++this.SS_Warehouse3SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesMade", this.SS_Warehouse3SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse3LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3LifetimeEarnings", this.SS_Warehouse3LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 4)
                    {
                      ++this.SS_Warehouse4SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesMade", this.SS_Warehouse4SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse4LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4LifetimeEarnings", this.SS_Warehouse4LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 5)
                    {
                      ++this.SS_Warehouse5SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesMade", this.SS_Warehouse5SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse5LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5LifetimeEarnings", this.SS_Warehouse5LifetimeEarnings);
                      this.Config.Save();
                    }
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
                    UI.ShowSubtitle("Deliver the Cargo to a ~y~Drop off~w~");
                  if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset1) < 200.0)
                  {
                    Vector3 areaOffset1 = this.AreaOffset1;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset1.X, areaOffset1.Y, World.GetGroundHeight(new Vector3(areaOffset1.X, areaOffset1.Y, areaOffset1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc1 && !this.NearLoc1)
                    {
                      Vector3 areaOffset2 = this.AreaOffset2;
                      this.NearLoc1 = true;
                      this.CreateSmoke(areaOffset2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset2) < 200.0)
                  {
                    Vector3 areaOffset2 = this.AreaOffset2;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset2.X, areaOffset2.Y, World.GetGroundHeight(new Vector3(areaOffset2.X, areaOffset2.Y, areaOffset2.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc2 && !this.NearLoc2)
                    {
                      Vector3 areaOffset1 = this.AreaOffset1;
                      this.NearLoc2 = true;
                      this.CreateSmoke(areaOffset1);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset3) < 200.0)
                  {
                    Vector3 areaOffset3_1 = this.AreaOffset3;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset3_1.X, areaOffset3_1.Y, World.GetGroundHeight(new Vector3(areaOffset3_1.X, areaOffset3_1.Y, areaOffset3_1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc3 && !this.NearLoc3)
                    {
                      Vector3 areaOffset3_2 = this.AreaOffset3;
                      this.NearLoc3 = true;
                      this.CreateSmoke(areaOffset3_2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset4) < 200.0)
                  {
                    Vector3 areaOffset4_1 = this.AreaOffset4;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset4_1.X, areaOffset4_1.Y, World.GetGroundHeight(new Vector3(areaOffset4_1.X, areaOffset4_1.Y, areaOffset4_1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc4 && !this.NearLoc4)
                    {
                      Vector3 areaOffset4_2 = this.AreaOffset4;
                      this.NearLoc4 = true;
                      this.CreateSmoke(areaOffset4_2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset1) < 5.0 && !this.DeliveredtoLoc1)
                  {
                    this.DeliveredVehicle3 = true;
                    if (this.DeliveryVehicle3.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle3.CurrentBlip.Remove();
                    if (this.DeliverLocBlip1 != (Blip) null)
                      this.DeliverLocBlip1.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc1 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle3, true);
                    this.DeliveryVehicle3.MarkAsNoLongerNeeded();
                    this.NearLoc1 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset2) < 5.0 && !this.DeliveredtoLoc2)
                  {
                    this.DeliveredVehicle3 = true;
                    if (this.DeliveryVehicle3.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle3.CurrentBlip.Remove();
                    if (this.DeliverLocBlip2 != (Blip) null)
                      this.DeliverLocBlip2.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc2 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle3, true);
                    this.DeliveryVehicle3.MarkAsNoLongerNeeded();
                    this.NearLoc2 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset3) < 5.0 && !this.DeliveredtoLoc3)
                  {
                    this.DeliveredVehicle3 = true;
                    if (this.DeliveryVehicle3.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle3.CurrentBlip.Remove();
                    if (this.DeliverLocBlip3 != (Blip) null)
                      this.DeliverLocBlip3.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc3 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle3, true);
                    this.DeliveryVehicle3.MarkAsNoLongerNeeded();
                    this.NearLoc3 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle3.Position, this.AreaOffset4) < 5.0 && !this.DeliveredtoLoc4)
                  {
                    this.DeliveredVehicle3 = true;
                    if (this.DeliveryVehicle3.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle3.CurrentBlip.Remove();
                    if (this.DeliverLocBlip4 != (Blip) null)
                      this.DeliverLocBlip4.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc4 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle3, true);
                    this.DeliveryVehicle3.MarkAsNoLongerNeeded();
                    this.NearLoc4 = false;
                  }
                }
                if ((Entity) this.DeliveryVehicle4 != (Entity) null)
                {
                  if (this.Deliveries == 4 && this.DeliveredtoLoc1 && (this.DeliveredtoLoc2 && this.DeliveredtoLoc3) && this.DeliveredtoLoc4)
                  {
                    List<string> stringList = new List<string>();
                    MissionScreen missionScreen = new MissionScreen();
                    int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                    float num = this.GetWarehouseValue((int) ((double) this.GetCrateCountByID(warehouseId) * (double) this.PercentageSell)) * ((float) this.AmttoDeliver / (float) this.PointsBeenAt);
                    missionScreen.SetPass2("Securoserv : Sell Cargo", (int) num, "All Cargo delivered");
                    if (warehouseId == 1)
                    {
                      ++this.SS_Warehouse1SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesMade", this.SS_Warehouse1SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse1LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1LifetimeEarnings", this.SS_Warehouse1LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 2)
                    {
                      ++this.SS_Warehouse2SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesMade", this.SS_Warehouse2SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse2LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2LifetimeEarnings", this.SS_Warehouse2LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 3)
                    {
                      ++this.SS_Warehouse3SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesMade", this.SS_Warehouse3SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse3LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3LifetimeEarnings", this.SS_Warehouse3LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 4)
                    {
                      ++this.SS_Warehouse4SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesMade", this.SS_Warehouse4SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse4LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4LifetimeEarnings", this.SS_Warehouse4LifetimeEarnings);
                      this.Config.Save();
                    }
                    if (warehouseId == 5)
                    {
                      ++this.SS_Warehouse5SalesMade;
                      this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesMade", this.SS_Warehouse5SalesMade);
                      this.Config.Save();
                      this.SS_Warehouse5LifetimeEarnings += (int) num;
                      this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5LifetimeEarnings", this.SS_Warehouse5LifetimeEarnings);
                      this.Config.Save();
                    }
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
                    UI.ShowSubtitle("Deliver the Cargo to a ~y~Drop off~w~");
                  if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset1) < 200.0)
                  {
                    Vector3 areaOffset1 = this.AreaOffset1;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset1.X, areaOffset1.Y, World.GetGroundHeight(new Vector3(areaOffset1.X, areaOffset1.Y, areaOffset1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc1 && !this.NearLoc1)
                    {
                      Vector3 areaOffset2 = this.AreaOffset2;
                      this.NearLoc1 = true;
                      this.CreateSmoke(areaOffset2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset2) < 200.0)
                  {
                    Vector3 areaOffset2 = this.AreaOffset2;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset2.X, areaOffset2.Y, World.GetGroundHeight(new Vector3(areaOffset2.X, areaOffset2.Y, areaOffset2.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc2 && !this.NearLoc2)
                    {
                      Vector3 areaOffset1 = this.AreaOffset1;
                      this.NearLoc2 = true;
                      this.CreateSmoke(areaOffset1);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset3) < 200.0)
                  {
                    Vector3 areaOffset3_1 = this.AreaOffset3;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset3_1.X, areaOffset3_1.Y, World.GetGroundHeight(new Vector3(areaOffset3_1.X, areaOffset3_1.Y, areaOffset3_1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc3 && !this.NearLoc3)
                    {
                      Vector3 areaOffset3_2 = this.AreaOffset3;
                      this.NearLoc3 = true;
                      this.CreateSmoke(areaOffset3_2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset4) < 200.0)
                  {
                    Vector3 areaOffset4_1 = this.AreaOffset4;
                    World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(areaOffset4_1.X, areaOffset4_1.Y, World.GetGroundHeight(new Vector3(areaOffset4_1.X, areaOffset4_1.Y, areaOffset4_1.Z + 500f))), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 0.8f), Color.Yellow);
                    if (!this.DeliveredtoLoc4 && !this.NearLoc4)
                    {
                      Vector3 areaOffset4_2 = this.AreaOffset4;
                      this.NearLoc4 = true;
                      this.CreateSmoke(areaOffset4_2);
                    }
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset1) < 5.0 && !this.DeliveredtoLoc1)
                  {
                    this.DeliveredVehicle4 = true;
                    if (this.DeliveryVehicle4.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle4.CurrentBlip.Remove();
                    if (this.DeliverLocBlip1 != (Blip) null)
                      this.DeliverLocBlip1.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc1 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle4, true);
                    this.DeliveryVehicle4.MarkAsNoLongerNeeded();
                    this.NearLoc1 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset2) < 5.0 && !this.DeliveredtoLoc2)
                  {
                    this.DeliveredVehicle4 = true;
                    if (this.DeliveryVehicle4.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle4.CurrentBlip.Remove();
                    if (this.DeliverLocBlip2 != (Blip) null)
                      this.DeliverLocBlip2.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc2 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle4, true);
                    this.DeliveryVehicle4.MarkAsNoLongerNeeded();
                    this.NearLoc2 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset3) < 5.0 && !this.DeliveredtoLoc3)
                  {
                    this.DeliveredVehicle4 = true;
                    if (this.DeliveryVehicle4.CurrentBlip != (Blip) null)
                      this.DeliveryVehicle4.CurrentBlip.Remove();
                    if (this.DeliverLocBlip3 != (Blip) null)
                      this.DeliverLocBlip3.Remove();
                    foreach (int smokeParticle in this.SmokeParticles)
                      Function.Call(Hash._0x8F75998877616996, (InputArgument) smokeParticle, (InputArgument) false);
                    this.DeliveredtoLoc3 = true;
                    Game.Player.Character.Task.LeaveVehicle(this.DeliveryVehicle4, true);
                    this.DeliveryVehicle4.MarkAsNoLongerNeeded();
                    this.NearLoc3 = false;
                  }
                  if ((double) World.GetDistance(this.DeliveryVehicle4.Position, this.AreaOffset4) < 5.0 && !this.DeliveredtoLoc4)
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
                    this.DeliveryVehicle4.MarkAsNoLongerNeeded();
                    this.NearLoc4 = false;
                  }
                }
              }
            }
          }
          if (this.SupplyMissionID == 1)
          {
            if ((Entity) this.SupplyMissionMainVehicle != (Entity) null && this.SupplyMissionStage < 4 && !this.SupplyMissionMainVehicle.IsAlive)
            {
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
              int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
              if (warehouseId == 1)
              {
                ++this.SS_Warehouse1SalesFailed;
                this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesFailed", this.SS_Warehouse1SalesFailed);
                this.Config.Save();
              }
              if (warehouseId == 2)
              {
                ++this.SS_Warehouse2SalesFailed;
                this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesFailed", this.SS_Warehouse2SalesFailed);
                this.Config.Save();
              }
              if (warehouseId == 3)
              {
                ++this.SS_Warehouse3SalesFailed;
                this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesFailed", this.SS_Warehouse3SalesFailed);
                this.Config.Save();
              }
              if (warehouseId == 4)
              {
                ++this.SS_Warehouse4SalesFailed;
                this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesFailed", this.SS_Warehouse4SalesFailed);
                this.Config.Save();
              }
              if (warehouseId == 5)
              {
                ++this.SS_Warehouse5SalesFailed;
                this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesFailed", this.SS_Warehouse5SalesFailed);
                this.Config.Save();
              }
              new MissionScreen().SetFail("Securoserv : Sell Cargo", 8000, "The Sell Vehicle Was Destroyed");
              this.SupplyMissionStage = 0;
              this.SupplyMissionOn = false;
              this.SupplyMissionID = 0;
            }
            if (this.SupplyMissionStage == 1)
            {
              UI.ShowSubtitle("Find the ~b~Cuban 800~w~");
              if ((double) World.GetDistance(Game.Player.Character.Position, this.SupplyMissionMainVehicle.Position) < 30.0)
                this.SupplyMissionStage = 2;
            }
            if (this.SupplyMissionStage == 2)
            {
              if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
              {
                Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
                if ((Entity) currentVehicle == (Entity) this.SupplyMissionMainVehicle)
                {
                  currentVehicle.IsInvincible = false;
                  foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                  {
                    if (supplyMissionBlip != (Blip) null)
                      supplyMissionBlip.Remove();
                  }
                  foreach (SubBusinesses.Flare flare in this.Cargo)
                  {
                    if ((Entity) flare.FlareProp != (Entity) null)
                      flare.FlareProp.Delete();
                  }
                  if (this.CargoDropped.Count > 0)
                    this.CargoDropped.Clear();
                  if (this.SelectedSellPoints.Count > 0)
                    this.SelectedSellPoints.Clear();
                  if (this.CompletedSellPoints.Count > 0)
                    this.CompletedSellPoints.Clear();
                  this.Selectedpoints = 15;
                  float num = (float) (this.GetCrateCountByIndex() / this.CargoWarehouses[this.CurrentWarehouse].Maxcrates * 100);
                  if ((double) num <= 10.0)
                    this.Selectedpoints = 3;
                  if ((double) num > 10.0 && (double) num <= 25.0)
                    this.Selectedpoints = 5;
                  if ((double) num > 25.0 && (double) num <= 35.0)
                    this.Selectedpoints = 6;
                  if ((double) num > 35.0 && (double) num <= 50.0)
                    this.Selectedpoints = 8;
                  if ((double) num > 50.0 && (double) num <= 65.0)
                    this.Selectedpoints = 9;
                  if ((double) num > 65.0 && (double) num <= 80.0)
                    this.Selectedpoints = 11;
                  if ((double) num > 80.0 && (double) num <= 100.0)
                    this.Selectedpoints = 15;
                  this.PointstoGoto = this.Selectedpoints;
                  System.Random random = new System.Random();
                  for (int index = 0; index < 1000; ++index)
                  {
                    if (this.Selectedpoints > 0)
                    {
                      Vector3 airSellPoint = this.AirSellPoints[random.Next(0, this.AirSellPoints.Count)];
                      if (!this.SelectedSellPoints.Contains(airSellPoint))
                      {
                        --this.Selectedpoints;
                        this.SelectedSellPoints.Add(airSellPoint);
                        Blip blip1 = World.CreateBlip(airSellPoint);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Yellow;
                        blip1.Name = "Drop Off";
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(airSellPoint);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Yellow;
                        blip2.Name = "Drop Off";
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                      }
                    }
                    else if (this.Selectedpoints <= 0)
                      this.SupplyMissionStage = 3;
                  }
                }
                else
                  UI.ShowSubtitle("Enter the ~b~Cuban 800~w~");
              }
              else
                UI.ShowSubtitle("Enter the ~b~Cuban 800~w~");
            }
            if (this.SupplyMissionStage == 3)
            {
              this.drawSprite2("timerbars", "all_black_bg", 0.89f, 0.97f, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 130);
              this.drawText(("TOTAL DELIVERED   " + this.PointsBeenAt.ToString() + "/" + this.PointstoGoto.ToString()).ToString(), 0.82f, 0.961f, 0.4f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              if (this.PointsBeenAt < this.PointstoGoto)
                UI.ShowSubtitle("Deliver the Cargo to the ~y~drop-offs");
              if (this.PointsBeenAt >= this.PointstoGoto)
              {
                this.SupplyMissionStage = 4;
                UI.ShowSubtitle("Deliver the Cargo to the ~y~drop-offs");
              }
              if (this.Cargo.Count > 0)
              {
                foreach (SubBusinesses.Flare flare1 in this.Cargo)
                {
                  if (!flare1.Created && (Entity) flare1.FlareProp != (Entity) null)
                  {
                    if ((double) World.GetDistance(flare1.FlareProp.Position, flare1.Location) < 30.0 && (double) flare1.FlareProp.HeightAboveGround < 10.0)
                    {
                      foreach (SubBusinesses.Flare flare2 in this.SellPointsSmoke_Air)
                      {
                        Function.Call(Hash._0x8F75998877616996, (InputArgument) flare2.FlareID_1, (InputArgument) false);
                        if ((Entity) flare2.FlareProp != (Entity) null && (double) World.GetDistance(flare2.FlareProp.Position, flare1.Location) < 30.0)
                          flare2.FlareProp.Delete();
                      }
                      ++this.PointsBeenAt;
                      ++this.AmttoDeliver;
                      Audio.SetAudioFlag("LoadMPData", true);
                      Audio.PlaySoundFrontend("LOCAL_PLYR_CASH_COUNTER_COMPLETE", "DLC_HEISTS_GENERAL_FRONTEND_SOUNDS");
                      Audio.SetAudioFlag("LoadMPData", false);
                      flare1.Created = true;
                    }
                    if ((double) World.GetDistance(flare1.FlareProp.Position, flare1.Location) > 30.0 && (double) flare1.FlareProp.HeightAboveGround < 10.0)
                    {
                      foreach (SubBusinesses.Flare flare2 in this.SellPointsSmoke_Air)
                      {
                        Function.Call(Hash._0x8F75998877616996, (InputArgument) flare2.FlareID_1, (InputArgument) false);
                        if ((Entity) flare2.FlareProp != (Entity) null && (double) World.GetDistance(flare2.FlareProp.Position, flare1.Location) < 30.0)
                          flare2.FlareProp.Delete();
                      }
                      ++this.PointsBeenAt;
                      flare1.Created = true;
                    }
                  }
                }
              }
              foreach (Vector3 selectedSellPoint in this.SelectedSellPoints)
              {
                if (!this.CompletedSellPoints.Contains(selectedSellPoint))
                {
                  if ((double) World.GetDistance(this.SupplyMissionMainVehicle.Position, selectedSellPoint) > 80.0)
                  {
                    double distance = (double) World.GetDistance(this.SupplyMissionMainVehicle.Position, selectedSellPoint);
                  }
                  if ((double) World.GetDistance(this.SupplyMissionMainVehicle.Position, selectedSellPoint) < 200.0)
                  {
                    this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Drop Cargo");
                    if (Game.IsControlPressed(2, GTA.Control.Context) && !this.CargoDropped.Contains(selectedSellPoint))
                    {
                      foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                      {
                        if (supplyMissionBlip != (Blip) null && (double) World.GetDistance(supplyMissionBlip.Position, selectedSellPoint) < 30.0)
                          supplyMissionBlip.Remove();
                      }
                      this.CargoDropped.Add(selectedSellPoint);
                      this.SupplyMissionMainVehicle.OpenBombBay();
                    }
                  }
                }
                if (Function.Call<bool>((Hash) 15028927856255482792, (InputArgument) this.SupplyMissionMainVehicle))
                {
                  if (!this.CompletedSellPoints.Contains(selectedSellPoint) && !this.WaitingForDrop)
                  {
                    System.Random random = new System.Random();
                    this.CompletedSellPoints.Add(selectedSellPoint);
                    this.WaitingForDrop = true;
                    Script.Wait(500);
                    this.DeliverCrate1 = World.CreateProp(this.RequestModel("ba_prop_battle_fakeid_boxdl_01a"), this.SupplyMissionMainVehicle.GetOffsetInWorldCoords(new Vector3(1f, 0.0f, -1f)), false, false);
                    this.SupplyMissionProps.Add(this.DeliverCrate1);
                    foreach (Prop supplyMissionProp in this.SupplyMissionProps)
                    {
                      if ((Entity) supplyMissionProp != (Entity) null && supplyMissionProp.Model == this.RequestModel("ba_prop_battle_fakeid_boxdl_01a"))
                      {
                        supplyMissionProp.Detach();
                        supplyMissionProp.FreezePosition = false;
                        supplyMissionProp.ApplyForce(Vector3.WorldDown);
                        supplyMissionProp.ApplyForce(new Vector3((float) random.Next(0, 5), (float) random.Next(0, 5), (float) random.Next(0, 5)));
                        supplyMissionProp.HasGravity = true;
                      }
                    }
                    this.Cargo.Add(new SubBusinesses.Flare(this.DeliverCrate1, selectedSellPoint, false));
                  }
                  if (this.CompletedSellPoints.Contains(selectedSellPoint) && this.WaitingForDrop && ((Entity) this.DeliverCrate1 != (Entity) null && (double) World.GetDistance(this.DeliverCrate1.Position, this.SupplyMissionMainVehicle.Position) > 120.0))
                  {
                    this.WaitingForDrop = false;
                    Script.Wait(500);
                    this.SupplyMissionMainVehicle.CloseBombBay();
                  }
                }
              }
            }
            if (this.SupplyMissionStage == 4)
            {
              UI.ShowSubtitle("Return to the ~b~Warehouse ");
              if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentWarehousePos) < 20.0)
              {
                List<string> stringList = new List<string>();
                MissionScreen missionScreen = new MissionScreen();
                int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                float num = this.GetWarehouseValue((int) ((double) this.GetCrateCountByID(warehouseId) * (double) this.PercentageSell)) * ((float) this.AmttoDeliver / (float) this.PointsBeenAt);
                missionScreen.SetPass2("Securoserv : Sell Cargo", (int) num, this.AmttoDeliver.ToString() + " of " + this.PointsBeenAt.ToString() + " Cargo delivered");
                if (warehouseId == 1)
                {
                  ++this.SS_Warehouse1SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesMade", this.SS_Warehouse1SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse1LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1LifetimeEarnings", this.SS_Warehouse1LifetimeEarnings);
                  this.Config.Save();
                }
                if (warehouseId == 2)
                {
                  ++this.SS_Warehouse2SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesMade", this.SS_Warehouse2SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse2LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2LifetimeEarnings", this.SS_Warehouse2LifetimeEarnings);
                  this.Config.Save();
                }
                if (warehouseId == 3)
                {
                  ++this.SS_Warehouse3SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesMade", this.SS_Warehouse3SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse3LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3LifetimeEarnings", this.SS_Warehouse3LifetimeEarnings);
                  this.Config.Save();
                }
                if (warehouseId == 4)
                {
                  ++this.SS_Warehouse4SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesMade", this.SS_Warehouse4SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse4LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4LifetimeEarnings", this.SS_Warehouse4LifetimeEarnings);
                  this.Config.Save();
                }
                if (warehouseId == 5)
                {
                  ++this.SS_Warehouse5SalesMade;
                  this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesMade", this.SS_Warehouse5SalesMade);
                  this.Config.Save();
                  this.SS_Warehouse5LifetimeEarnings += (int) num;
                  this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5LifetimeEarnings", this.SS_Warehouse5LifetimeEarnings);
                  this.Config.Save();
                }
                Script.Wait(6000);
                this.SupplyMissionStage = 5;
              }
            }
            if (this.SupplyMissionStage == 5)
            {
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
              MissionScreen missionScreen = new MissionScreen();
              this.SupplyMissionStage = 0;
              this.SupplyMissionOn = false;
              this.SupplyMissionID = 0;
              Script.Wait(2500);
              Game.FadeScreenIn(2500);
            }
          }
        }
        else
        {
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
          int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
          if (warehouseId == 1)
          {
            ++this.SS_Warehouse1SalesFailed;
            this.Config.SetValue<int>("CargoWarehouses-1", "Warehouse1SalesFailed", this.SS_Warehouse1SalesFailed);
            this.Config.Save();
          }
          if (warehouseId == 2)
          {
            ++this.SS_Warehouse2SalesFailed;
            this.Config.SetValue<int>("CargoWarehouses-2", "Warehouse2SalesFailed", this.SS_Warehouse2SalesFailed);
            this.Config.Save();
          }
          if (warehouseId == 3)
          {
            ++this.SS_Warehouse3SalesFailed;
            this.Config.SetValue<int>("CargoWarehouses-3", "Warehouse3SalesFailed", this.SS_Warehouse3SalesFailed);
            this.Config.Save();
          }
          if (warehouseId == 4)
          {
            ++this.SS_Warehouse4SalesFailed;
            this.Config.SetValue<int>("CargoWarehouses-4", "Warehouse4SalesFailed", this.SS_Warehouse4SalesFailed);
            this.Config.Save();
          }
          if (warehouseId == 5)
          {
            ++this.SS_Warehouse5SalesFailed;
            this.Config.SetValue<int>("CargoWarehouses-5", "Warehouse5SalesFailed", this.SS_Warehouse5SalesFailed);
            this.Config.Save();
          }
          new MissionScreen().SetFail("Securoserv : Sell Cargo", 8000, "The Player Died");
          this.SupplyMissionStage = 0;
          this.SupplyMissionOn = false;
          this.SupplyMissionID = 0;
        }
      }
      if (this.IsIninterior)
      {
        this.DrawStockBar("Cargo            ", 0.89f, 0.97f, (float) this.GetCrateCountByIndex(this.CurrentWarehouse), (float) this.CargoWarehouses[this.CurrentWarehouse].Maxcrates);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.WarehouseExit) < 100.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.WarehouseExit, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.8f), this.mainColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.WarehouseExit) < 2.0)
        {
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to exit " + this.CargoWarehouses[this.CurrentWarehouse].WarehouseName);
          if (Game.IsControlJustPressed(2, GTA.Control.Context))
          {
            float x = this.CargoWarehouses[this.CurrentWarehouse].Location.X;
            float y = this.CargoWarehouses[this.CurrentWarehouse].Location.Y;
            float z = this.CargoWarehouses[this.CurrentWarehouse].Location.Z;
            Game.FadeScreenOut(800);
            Script.Wait(1500);
            Game.Player.Character.Position = new Vector3(x, y, z);
            this.IsIninterior = false;
            Script.Wait(1500);
            Game.FadeScreenIn(800);
          }
        }
      }
      if (!this.IsIninterior)
      {
        for (int index = 0; index < this.CargoWarehouses.Count; ++index)
        {
          if (this.SS_WarehousesOwned >= 1 && this.SS_Warehouse1Index == index)
          {
            float x = this.CargoWarehouses[index].Location.X;
            float y = this.CargoWarehouses[index].Location.Y;
            float z = this.CargoWarehouses[index].Location.Z;
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 100.0)
              World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(x, y, z), Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.8f), this.mainColor);
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 2.0)
            {
              this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter " + this.CargoWarehouses[index].WarehouseName);
              if (Game.IsControlJustPressed(2, GTA.Control.Context))
              {
                this.GetCrateCountByIndex(index, 1);
                Game.FadeScreenOut(800);
                Script.Wait(1500);
                this.CurrentWarehouse = index;
                this.CurrentWarehousePos = new Vector3(x, y, z);
                if (this.CargoWarehouses[index].Size == 0)
                {
                  this.CratesToSpawn = 16;
                  this.WarehouseExit = new Vector3(1104.767f, -3099.539f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsSmall(1);
                }
                if (this.CargoWarehouses[index].Size == 1)
                {
                  this.CratesToSpawn = 42;
                  this.WarehouseExit = new Vector3(1072.769f, -3102.537f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsMedium(1);
                }
                if (this.CargoWarehouses[index].Size == 2)
                {
                  this.CratesToSpawn = 111;
                  this.WarehouseExit = new Vector3(1027.522f, -3101.361f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsLarge(1);
                }
                this.IsIninterior = true;
                Script.Wait(1500);
                Game.FadeScreenIn(800);
              }
            }
          }
          else if (this.SS_WarehousesOwned >= 2 && this.SS_Warehouse2Index == index)
          {
            float x = this.CargoWarehouses[index].Location.X;
            float y = this.CargoWarehouses[index].Location.Y;
            float z = this.CargoWarehouses[index].Location.Z;
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 100.0)
              World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(x, y, z), Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.8f), this.mainColor);
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 2.0)
            {
              this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter " + this.CargoWarehouses[index].WarehouseName);
              if (Game.IsControlJustPressed(2, GTA.Control.Context))
              {
                this.CurrentWarehousePos = new Vector3(x, y, z);
                this.GetCrateCountByIndex(index, 2);
                Game.FadeScreenOut(800);
                Script.Wait(1500);
                this.CurrentWarehouse = index;
                if (this.CargoWarehouses[index].Size == 0)
                {
                  this.CratesToSpawn = 16;
                  this.WarehouseExit = new Vector3(1104.767f, -3099.539f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsSmall(2);
                }
                if (this.CargoWarehouses[index].Size == 1)
                {
                  this.CratesToSpawn = 42;
                  this.WarehouseExit = new Vector3(1072.769f, -3102.537f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsMedium(2);
                }
                if (this.CargoWarehouses[index].Size == 2)
                {
                  this.CratesToSpawn = 111;
                  this.WarehouseExit = new Vector3(1027.522f, -3101.361f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsLarge(2);
                }
                this.IsIninterior = true;
                Script.Wait(1500);
                Game.FadeScreenIn(800);
              }
            }
          }
          else if (this.SS_WarehousesOwned >= 3 && this.SS_Warehouse3Index == index)
          {
            float x = this.CargoWarehouses[index].Location.X;
            float y = this.CargoWarehouses[index].Location.Y;
            float z = this.CargoWarehouses[index].Location.Z;
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 100.0)
              World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(x, y, z), Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.8f), this.mainColor);
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 2.0)
            {
              this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter " + this.CargoWarehouses[index].WarehouseName);
              if (Game.IsControlJustPressed(2, GTA.Control.Context))
              {
                this.CurrentWarehousePos = new Vector3(x, y, z);
                this.GetCrateCountByIndex(index, 3);
                Game.FadeScreenOut(800);
                Script.Wait(1500);
                this.CurrentWarehouse = index;
                if (this.CargoWarehouses[index].Size == 0)
                {
                  this.CratesToSpawn = 16;
                  this.WarehouseExit = new Vector3(1104.767f, -3099.539f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsSmall(3);
                }
                if (this.CargoWarehouses[index].Size == 1)
                {
                  this.CratesToSpawn = 42;
                  this.WarehouseExit = new Vector3(1072.769f, -3102.537f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsMedium(3);
                }
                if (this.CargoWarehouses[index].Size == 2)
                {
                  this.CratesToSpawn = 111;
                  this.WarehouseExit = new Vector3(1027.522f, -3101.361f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsLarge(3);
                }
                this.IsIninterior = true;
                Script.Wait(1500);
                Game.FadeScreenIn(800);
              }
            }
          }
          else if (this.SS_WarehousesOwned >= 4 && this.SS_Warehouse4Index == index)
          {
            float x = this.CargoWarehouses[index].Location.X;
            float y = this.CargoWarehouses[index].Location.Y;
            float z = this.CargoWarehouses[index].Location.Z;
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 100.0)
              World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(x, y, z), Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.8f), this.mainColor);
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 2.0)
            {
              this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter " + this.CargoWarehouses[index].WarehouseName);
              if (Game.IsControlJustPressed(2, GTA.Control.Context))
              {
                this.CurrentWarehousePos = new Vector3(x, y, z);
                this.GetCrateCountByIndex(index, 4);
                Game.FadeScreenOut(800);
                Script.Wait(1500);
                this.CurrentWarehouse = index;
                if (this.CargoWarehouses[index].Size == 0)
                {
                  this.CratesToSpawn = 16;
                  this.WarehouseExit = new Vector3(1104.767f, -3099.539f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsSmall(4);
                }
                if (this.CargoWarehouses[index].Size == 1)
                {
                  this.CratesToSpawn = 42;
                  this.WarehouseExit = new Vector3(1072.769f, -3102.537f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsMedium(4);
                }
                if (this.CargoWarehouses[index].Size == 2)
                {
                  this.CratesToSpawn = 111;
                  this.WarehouseExit = new Vector3(1027.522f, -3101.361f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsLarge(4);
                }
                this.IsIninterior = true;
                Script.Wait(1500);
                Game.FadeScreenIn(800);
              }
            }
          }
          else if (this.SS_WarehousesOwned >= 5 && this.SS_Warehouse5Index == index)
          {
            float x = this.CargoWarehouses[index].Location.X;
            float y = this.CargoWarehouses[index].Location.Y;
            float z = this.CargoWarehouses[index].Location.Z;
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 100.0)
              World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(x, y, z), Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.8f), this.mainColor);
            if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(x, y, z)) < 2.0)
            {
              this.CurrentWarehousePos = new Vector3(x, y, z);
              this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter " + this.CargoWarehouses[index].WarehouseName);
              if (Game.IsControlJustPressed(2, GTA.Control.Context))
              {
                this.GetCrateCountByIndex(index, 5);
                Game.FadeScreenOut(800);
                Script.Wait(1500);
                this.CurrentWarehouse = index;
                if (this.CargoWarehouses[index].Size == 0)
                {
                  this.CratesToSpawn = 16;
                  this.WarehouseExit = new Vector3(1104.767f, -3099.539f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsSmall(5);
                }
                if (this.CargoWarehouses[index].Size == 1)
                {
                  this.CratesToSpawn = 42;
                  this.WarehouseExit = new Vector3(1072.769f, -3102.537f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsMedium(5);
                }
                if (this.CargoWarehouses[index].Size == 2)
                {
                  this.CratesToSpawn = 111;
                  this.WarehouseExit = new Vector3(1027.522f, -3101.361f, -40f);
                  Game.Player.Character.Position = this.WarehouseExit;
                  this.SetupPropsLarge(5);
                }
                this.IsIninterior = true;
                Script.Wait(1500);
                Game.FadeScreenIn(800);
              }
            }
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1631.044f, 1678.682f, 103f)) < 1000.0)
      {
        World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(1631.044f, 1678.682f, 103f), Vector3.Zero, Vector3.Zero, new Vector3(5f, 5f, 1f), this.mainColor);
        World.DrawMarker(MarkerType.DebugSphere, new Vector3(1631.044f, 1678.682f, 225f), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 3f), this.mainColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1631.044f, 1678.682f, 100f)) < 6.0)
        {
          SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
          int int32_1 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
          int int32_2 = Convert.ToInt32(resolutionMantainRatio.Height / 2f);
          float num1 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
          float num2 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
          new UIResText("~o~GXY  {" + this.GUIPosX.ToString() + "," + this.GUIPosY.ToString() + "}  MXY  {" + num2.ToString() + "," + num1.ToString() + "}  ~b~S: " + this.Screen.ToString() + "~r~ F: " + this.frame.ToString() + ",~b~ SO: " + this.ShowingOverlay.ToString() + ",~y~ ST: " + this.SellType.ToString() + "~g~ T" + this.Tab.ToString(), new Point(int32_1, int32_2 - 450), 0.6f, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
          new UIResText("~o~Selection   {" + this.WarehouseSelected.ToString() + "/" + this.GUIBIX.ToString() + "/" + this.GUIAPP.ToString() + "} ", new Point(int32_1, int32_2 - 400), 0.6f, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
          if (Game.IsControlPressed(2, GTA.Control.Sprint) && Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            if (this.TestCaseOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.GUIOn = false;
              this.GUIscaleform.Unload();
              this.TestCaseOn = false;
            }
            else if (!this.TestCaseOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.NightclubManagementOn = false;
              this.SecuroservCargoOn = false;
              this.SecuroservVehicleOn = false;
              this.HangerCargoCrateGUION = false;
              this.AdhawlScaleOn = false;
              this.BunkerLogisiticsGUIOn = false;
              this.TestCaseOn = true;
              this.GUIOn = true;
            }
          }
          if (Game.IsControlPressed(2, GTA.Control.Sprint) && Game.IsControlJustPressed(2, GTA.Control.VehicleDuck))
          {
            if (this.ArcadeHubGUIon)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.GUIOn = false;
              this.GUIscaleform.Unload();
              this.ArcadeHubGUIon = false;
            }
            else if (!this.ArcadeHubGUIon)
            {
              this.AH_LoadFirsttime = false;
              this.Screen = 0.0f;
              this.frame = 0;
              this.NightclubManagementOn = false;
              this.SecuroservCargoOn = false;
              this.SecuroservVehicleOn = false;
              this.HangerCargoCrateGUION = false;
              this.AdhawlScaleOn = false;
              this.BunkerLogisiticsGUIOn = false;
              this.ArcadeHubGUIon = true;
              this.GUIOn = true;
            }
          }
          if (!Game.IsControlPressed(2, GTA.Control.Sprint) && Game.IsControlJustPressed(2, GTA.Control.SelectWeaponSniper))
          {
            if (this.SecuroservVehicleOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.GUIOn = false;
              this.GUIscaleform.Unload();
              this.SecuroservVehicleOn = false;
            }
            else if (!this.SecuroservVehicleOn)
            {
              this.ADV_LoadFirsttime = false;
              this.Screen = 0.0f;
              this.frame = 0;
              this.NightclubManagementOn = false;
              this.SecuroservCargoOn = false;
              this.SecuroservVehicleOn = false;
              this.HangerCargoCrateGUION = false;
              this.AdhawlScaleOn = false;
              this.BunkerLogisiticsGUIOn = false;
              this.SecuroservVehicleOn = true;
              this.GUIOn = true;
            }
          }
          if (Game.IsControlPressed(2, GTA.Control.Sprint) && Game.IsControlJustPressed(2, GTA.Control.SelectWeaponSniper))
          {
            if (this.SecuroservCargoOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.GUIOn = false;
              this.GUIscaleform.Unload();
              this.SecuroservCargoOn = false;
            }
            else if (!this.SecuroservCargoOn)
            {
              this.Screen = 3f;
              this.frame = 0;
              this.NightclubManagementOn = false;
              this.SecuroservCargoOn = false;
              this.SecuroservVehicleOn = false;
              this.HangerCargoCrateGUION = false;
              this.AdhawlScaleOn = false;
              this.BunkerLogisiticsGUIOn = false;
              this.SecuroservCargoOn = true;
              this.GUIOn = true;
            }
          }
          if (!Game.IsControlPressed(2, GTA.Control.Sprint) && Game.IsControlJustPressed(2, GTA.Control.SelectWeaponSpecial))
          {
            if (this.NightclubManagementOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.GUIOn = false;
              this.GUIscaleform.Unload();
              this.NightclubManagementOn = false;
            }
            else if (!this.NightclubManagementOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.NightclubManagementOn = false;
              this.SecuroservCargoOn = false;
              this.SecuroservVehicleOn = false;
              this.HangerCargoCrateGUION = false;
              this.AdhawlScaleOn = false;
              this.BunkerLogisiticsGUIOn = false;
              this.NightclubManagementOn = true;
              this.GUIOn = true;
            }
          }
          if (Game.IsControlPressed(2, GTA.Control.Sprint) && Game.IsControlJustPressed(2, GTA.Control.SelectWeaponSpecial))
          {
            if (this.BunkerLogisiticsGUIOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.GUIOn = false;
              this.GUIscaleform.Unload();
              this.BunkerLogisiticsGUIOn = false;
            }
            else if (!this.BunkerLogisiticsGUIOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.NightclubManagementOn = false;
              this.SecuroservCargoOn = false;
              this.SecuroservVehicleOn = false;
              this.HangerCargoCrateGUION = false;
              this.AdhawlScaleOn = false;
              this.BunkerLogisiticsGUIOn = false;
              this.BunkerLogisiticsGUIOn = true;
              this.GUIOn = true;
            }
          }
        }
      }
      if (!this.GUIOn)
        Game.Player.Character.FreezePosition = false;
      try
      {
        if (this.GUIOn)
        {
          Game.Player.Character.FreezePosition = true;
          if (Game.Player.Character.Weapons.Current.GetHashCode() != -1569615261)
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed, true);
          int num1;
          if (!Function.Call<bool>(Hash._0x580417101DDB492F, (InputArgument) 2, (InputArgument) 201))
            num1 = Function.Call<bool>(Hash._0x580417101DDB492F, (InputArgument) 2, (InputArgument) 237) ? 1 : 0;
          else
            num1 = 1;
          if (num1 != 0)
          {
            this.GUICheckBool = false;
            this.GUIscaleform.CallFunction("SET_INPUT_EVENT", (object) 201f, (object) -1082130432, (object) -1082130432, (object) -1082130432, (object) -1082130432);
            Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "GET_CURRENT_SELECTION");
            this.GUIAPP = Function.Call<int>(Hash._0xC50AA39A577AF886);
          }
          if (!this.GUICheckBool)
          {
            if (Function.Call<bool>(Hash._0x768FF8961BA904D6, (InputArgument) this.GUIAPP))
            {
              this.GUIBIX = Function.Call<int>(Hash._0x2DE7EFA66B906036, (InputArgument) this.GUIAPP);
              this.GUICheckBool = true;
              if (this.GUIBIX < 1000)
                this.WarehouseSelected = this.GUIBIX <= this.SS_WarehousesOwned ? this.GUIBIX : this.GUIBIX - this.SS_WarehousesOwned;
            }
          }
          if (this.TestCaseOn)
          {
            if (this.frame == 0)
            {
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "COVERT_OPS"));
              this.GUIscaleform.CallFunction("showScreen", (object) 2);
            }
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
                this.frame = 1;
              if (this.frame == 1)
                this.frame = 2;
              if (this.frame == 2)
              {
                if (Game.IsControlJustPressed(2, GTA.Control.Context))
                {
                  ++this.Screen;
                  if ((double) this.Screen > 6.0)
                  {
                    this.frame = 1;
                    this.Screen = 0.0f;
                  }
                  UI.Notify("Next Screen " + this.Screen.ToString());
                  this.GUIscaleform.CallFunction("showScreen", (object) this.Screen, (object) -1f, (object) -1f, (object) -1f, (object) -1f);
                }
                this.GUIscaleform.Render2D();
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num2;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num2 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num2 = 1;
                  if (num2 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num3;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num3 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num3 = 1;
                  if (num3 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
            }
          }
          if (this.BunkerLogisiticsGUIOn)
          {
            if (this.frame == 0)
            {
              if (this.GUIscaleform != null)
                this.GUIscaleform.Unload();
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "DISRUPTION_LOGISTICS"));
              this.Screen = 0.0f;
              this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
            }
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
              {
                this.Screen = 0.0f;
                this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                this.frame = 1;
              }
              if (this.frame == 1)
              {
                if (this.BNKr_ResearchProgress >= 100)
                  this.GUIscaleform.CallFunction("ACTIVATE_FAST_TRACK");
                if (this.BNKr_SetupBusiness == 1)
                {
                  int num2 = 1;
                  int num3 = 2;
                  int num4 = 2;
                  int num5 = 2;
                  int num6 = 2;
                  int num7 = 1;
                  int num8 = 2;
                  int num9 = 2;
                  this.GUIscaleform.CallFunction("SET_BUTTON_STATES", (object) num2, (object) num3, (object) num4, (object) num5, (object) num6, (object) num9, (object) num7, (object) num8, (object) this.BNKr_ResearchStatus, (object) 1, (object) 1, (object) 1, (object) 1);
                }
                if (this.BNKr_SetupBusiness == 0)
                  this.GUIscaleform.CallFunction("SET_BUTTON_STATES", (object) 2, (object) 1, (object) 1, (object) 1, (object) 1, (object) 1, (object) 1, (object) 1, (object) 1, (object) 1, (object) 1, (object) 1, (object) 1);
                this.GUIscaleform.CallFunction("SET_RESEARCH", (object) this.BNKr_FastTrackResearchPrice, (object) 50, (object) "UA_UNLOCK_1", (object) this.BNKr_ResearchStatus, (object) "SAM Missile", (object) "Current Research");
                this.GUIscaleform.CallFunction("SET_STATS", (object) this.BNKr_Name, (object) this.BNKr_Name, (object) this.BNKr_BunkerImage, (object) this.BNKr_BunkerName, (object) this.BNKr_BunkerLocation, (object) this.BNKr_BunkerOperationStatus, (object) this.BNKr_StockLevel, (object) this.BNKr_ResearchProgress, (object) this.BNKr_SuppliesLevel, (object) this.BNKr_TotalEarnings, (object) this.BNKr_TotalSales, (object) this.BNKr_ResupplySuccessRate, (object) this.BNKr_SellSuccess_BC, (object) this.BNKr_SellSuccess_LS, (object) this.BNKr_UnitsManufactured, (object) this.BNKr_ResearchCompletedCrt, (object) this.BNKr_ResearchToComplete, (object) this.BNKr_StaffAssignment);
                for (int index = 1; index < 52; ++index)
                  this.GUIscaleform.CallFunction("ADD_RESEARCH_UNLOCKABLE", (object) true, (object) ("UA_UNLOCK_" + index.ToString()).ToString(), (object) ("Unlock " + index.ToString()), (object) ("Description for Unlock " + index.ToString()), (object) (index - 1));
                this.GUIscaleform.CallFunction("SET_SELL_PRICES", (object) this.BNKr_LSSellPrice, (object) this.BNKr_BCSellPrice);
                this.GUIscaleform.CallFunction("SET_UPGRADES", (object) this.BNKr_Upgrade1FullPrice, (object) this.BNKr_Upgrade1Unlocked, (object) this.BNKr_Upgrade2FullPrice, (object) this.BNKr_Upgrade2Unlocked, (object) this.BNKr_Upgrade3FullPrice, (object) this.BNKr_Upgrade3Unlocked, (object) this.BNKr_Upgrade1DiscountPrice, (object) this.BNKr_Upgrade2DiscountPrice, (object) this.BNKr_Upgrade3DiscountPrice);
                this.GUIscaleform.CallFunction("SET_RESUPPLIES", (object) 14000, (object) 2, (object) 2, (object) 12000);
                this.frame = 2;
              }
              if (this.frame == 2)
              {
                if (Game.IsControlJustPressed(2, this.BackKey))
                {
                  this.Screen = 1f;
                  this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                  this.frame = 1;
                }
                float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                if (!this.ShowingOverlay)
                {
                  if ((double) this.Screen == 6.0)
                  {
                    Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 197, (InputArgument) 1);
                    Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 198, (InputArgument) 1);
                    int controlValue1 = Game.GetControlValue(2, GTA.Control.FrontendRightAxisX);
                    int controlValue2 = Game.GetControlValue(2, GTA.Control.FrontendRightAxisY);
                    bool flag = Game.IsControlPressed(2, GTA.Control.CursorScrollDown) || Game.IsDisabledControlPressed(2, GTA.Control.CursorScrollDown);
                    if (!flag)
                      flag = Game.IsControlPressed(2, GTA.Control.CursorScrollUp) || Game.IsDisabledControlPressed(2, GTA.Control.CursorScrollUp);
                    this.GUIscaleform.CallFunction("SET_ANALOG_STICK_INPUT", (object) false, (object) controlValue1, (object) controlValue2, (object) flag);
                  }
                  if ((double) this.Screen == 0.0 && this.GUIBIX == 34151)
                  {
                    this.Screen = 1f;
                    this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                    this.frame = 1;
                  }
                  if (Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) this.Screen == 3.0 && this.BNKr_SetupBusiness == 1 && ((double) x > 0.345999985933304 && (double) x < 0.629000008106232 && ((double) y > 0.689000010490417 && (double) y < 0.763000011444092) || (double) this.GUIPosX > 0.345999985933304 && (double) this.GUIPosX < 0.629000008106232 && ((double) this.GUIPosY > 0.689000010490417 && (double) this.GUIPosY < 0.763000011444092)))
                    {
                      this.frame = 1;
                      this.Screen = 6f;
                      this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                    }
                    if ((double) this.Screen >= 0.0)
                    {
                      if (this.BNKr_SetupBusiness == 1)
                      {
                        if ((double) x > 0.156000003218651 && (double) x < 0.321999996900558 && ((double) y > 0.493000000715256 && (double) y < 0.53600001335144) || (double) this.GUIPosX > 0.156000003218651 && (double) this.GUIPosX < 0.321999996900558 && ((double) this.GUIPosY > 0.493000000715256 && (double) this.GUIPosY < 0.53600001335144))
                        {
                          this.frame = 1;
                          this.Screen = 2f;
                          this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                        }
                        if ((double) x > 0.156000003218651 && (double) x < 0.321999996900558 && ((double) y > 0.556999981403351 && (double) y < 0.601999998092651) || (double) this.GUIPosX > 0.156000003218651 && (double) this.GUIPosX < 0.321999996900558 && ((double) this.GUIPosY > 0.556999981403351 && (double) this.GUIPosY < 0.601999998092651))
                        {
                          this.frame = 1;
                          this.Screen = 3f;
                          this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                        }
                        if ((double) x > 0.156000003218651 && (double) x < 0.321999996900558 && ((double) y > 0.619000017642975 && (double) y < 0.662000000476837) || (double) this.GUIPosX > 0.156000003218651 && (double) this.GUIPosX < 0.321999996900558 && (double) this.GUIPosY > 0.556999981403351)
                        {
                          this.frame = 1;
                          this.Screen = 7f;
                          this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                        }
                        if ((double) x > 0.156000003218651 && (double) x < 0.321999996900558 && ((double) y > 0.683000028133392 && (double) y < 0.725000023841858) || (double) this.GUIPosX > 0.156000003218651 && (double) this.GUIPosX < 0.321999996900558 && (double) this.GUIPosY > 0.556999981403351)
                        {
                          this.frame = 1;
                          this.Screen = 4f;
                          this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                        }
                        if ((double) x > 0.156000003218651 && (double) x < 0.321999996900558 && ((double) y > 0.736000001430511 && (double) y < 0.78600001335144) || (double) this.GUIPosX > 0.156000003218651 && (double) this.GUIPosX < 0.321999996900558 && (double) this.GUIPosY > 0.556999981403351)
                        {
                          this.frame = 1;
                          this.Screen = 5f;
                          this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                        }
                      }
                      if ((double) this.Screen >= 0.0)
                      {
                        if (this.BNKr_SetupBusiness == 1)
                        {
                          if ((double) x > 0.156000003218651 && (double) x < 0.321999996900558 && ((double) y > 0.808000028133392 && (double) y < 0.842999994754791) || (double) this.GUIPosX > 0.156000003218651 && (double) this.GUIPosX < 0.321999996900558 && ((double) this.GUIPosY > 0.808000028133392 && (double) this.GUIPosY < 0.842999994754791))
                          {
                            this.ShowingOverlay = true;
                            this.OverlayIndex = 2;
                            this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Disruption Logistics", (object) "Shutdown Business", (object) "Cancel", (object) this.BNKr_BunkerImage, (object) "Shutdown Business", (object) 0);
                          }
                          if ((double) x > 0.156000003218651 && (double) x < 0.321999996900558 && ((double) y > 0.870000004768372 && (double) y < 0.919000029563904) || (double) this.GUIPosX > 0.156000003218651 && (double) this.GUIPosX < 0.321999996900558 && ((double) this.GUIPosY > 0.870000004768372 && (double) this.GUIPosY < 0.919000029563904))
                          {
                            this.ShowingOverlay = true;
                            this.OverlayIndex = 3;
                            this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Disruption Logistics", (object) "Restart Business", (object) "Cancel", (object) this.BNKr_BunkerImage, (object) "Restart Business", (object) 0);
                          }
                        }
                        if (this.BNKr_SetupBusiness == 0 && ((double) x > 0.156000003218651 && (double) x < 0.321999996900558 && ((double) y > 0.430000007152557 && (double) y < 0.469999998807907) || (double) this.GUIPosX > 0.156000003218651 && (double) this.GUIPosX < 0.321999996900558 && ((double) this.GUIPosY > 0.430000007152557 && (double) this.GUIPosY < 0.469999998807907)))
                        {
                          this.ShowingOverlay = true;
                          this.OverlayIndex = 1;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Disruption Logistics", (object) "Confirm", (object) "Cancel", (object) this.BNKr_BunkerImage, (object) "Setup Business", (object) 0);
                        }
                      }
                    }
                  }
                }
                if (this.ShowingOverlay)
                {
                  if (this.OverlayIndex == 1 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.441f, 0.753f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.441f, 0.753f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.554f, 0.754f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.554f, 0.754f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 2 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.441f, 0.753f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.441f, 0.753f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.554f, 0.754f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.554f, 0.754f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 3 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.441f, 0.753f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.441f, 0.753f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.554f, 0.754f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.554f, 0.754f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 4)
                  {
                    if (this.GUIBIX == 1)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 0)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 5)
                  {
                    if (this.GUIBIX == 1)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 0)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 6)
                  {
                    if (this.GUIBIX == 1)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 0)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 7)
                  {
                    if (this.GUIBIX == 1)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 0)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 8)
                  {
                    if (this.GUIBIX == 1)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 0)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 9)
                  {
                    if (this.GUIBIX == 0)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 1)
                    {
                      this.BNKr_Upgrade1Unlocked = 0;
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                      this.frame = 1;
                    }
                  }
                  if (this.OverlayIndex == 10)
                  {
                    if (this.GUIBIX == 0)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 1)
                    {
                      this.BNKr_Upgrade2Unlocked = 0;
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                      this.frame = 1;
                    }
                  }
                  if (this.OverlayIndex == 11)
                  {
                    if (this.GUIBIX == 0)
                    {
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 1)
                    {
                      this.BNKr_Upgrade3Unlocked = 0;
                      this.GUIBIX = -1;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                      this.frame = 1;
                    }
                  }
                }
                if ((double) this.Screen == 6.0 && Game.IsControlJustPressed(2, this.Key))
                {
                  if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.382f, 0.182f)) < 0.00999999977648258 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.382f, 0.182f)) < 0.00999999977648258)
                  {
                    this.frame = 1;
                    this.Tab = 0.0f;
                    if (this.GUIscaleform != null)
                      this.GUIscaleform.Unload();
                    this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "DISRUPTION_LOGISTICS"));
                    this.Screen = 6f;
                    this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                  }
                  if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.466f, 0.182f)) < 0.00999999977648258 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.382f, 0.179f)) < 0.00999999977648258)
                  {
                    this.frame = 1;
                    this.Tab = 2f;
                    if (this.GUIscaleform != null)
                      this.GUIscaleform.Unload();
                    this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "DISRUPTION_LOGISTICS"));
                    this.Screen = 6f;
                    this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                  }
                  if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.571f, 0.183f)) < 0.00999999977648258 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.571f, 0.183f)) < 0.00999999977648258)
                  {
                    this.frame = 1;
                    this.Tab = 1f;
                    if (this.GUIscaleform != null)
                      this.GUIscaleform.Unload();
                    this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "DISRUPTION_LOGISTICS"));
                    this.Screen = 6f;
                    this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen);
                  }
                }
                if ((double) this.Screen == 4.0)
                {
                  if (this.GUIBIX == 16)
                  {
                    this.BNKr_StaffAssignment = 0;
                    if (this.GUIscaleform != null)
                      this.GUIscaleform.Unload();
                    this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "DISRUPTION_LOGISTICS"));
                    this.GUIBIX = -1;
                    this.frame = 1;
                    this.Screen = 4f;
                  }
                  if (this.GUIBIX == 17)
                  {
                    this.BNKr_StaffAssignment = 1;
                    if (this.GUIscaleform != null)
                      this.GUIscaleform.Unload();
                    this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "DISRUPTION_LOGISTICS"));
                    this.GUIBIX = -1;
                    this.frame = 1;
                    this.Screen = 4f;
                  }
                  if (this.GUIBIX == 18)
                  {
                    this.BNKr_StaffAssignment = 2;
                    if (this.GUIscaleform != null)
                      this.GUIscaleform.Unload();
                    this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "DISRUPTION_LOGISTICS"));
                    this.GUIBIX = -1;
                    this.frame = 1;
                    this.Screen = 4f;
                  }
                }
                if ((double) this.Screen == 5.0)
                {
                  if (this.GUIBIX == 13 && this.BNKr_Upgrade1Unlocked != 0)
                  {
                    this.GUIBIX = -1;
                    this.ShowingOverlay = true;
                    this.OverlayIndex = 9;
                    this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) ("Purchase Equipment Upgrade for $" + this.BNKr_Upgrade1DiscountPrice.ToString("N")), (object) "Confirm", (object) "Cancel", (object) 1);
                  }
                  if (this.GUIBIX == 14 && this.BNKr_Upgrade2Unlocked != 0)
                  {
                    this.GUIBIX = -1;
                    this.ShowingOverlay = true;
                    this.OverlayIndex = 10;
                    this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) ("Purchase Staff Upgrade for $" + this.BNKr_Upgrade2DiscountPrice.ToString("N")), (object) "Confirm", (object) "Cancel", (object) 1);
                  }
                  if (this.GUIBIX == 15 && this.BNKr_Upgrade3Unlocked != 0)
                  {
                    this.GUIBIX = -1;
                    this.ShowingOverlay = true;
                    this.OverlayIndex = 11;
                    this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) ("Purchase Security Upgrade for $" + this.BNKr_Upgrade3DiscountPrice.ToString("N")), (object) "Confirm", (object) "Cancel", (object) 1);
                  }
                }
                if ((double) this.Screen == 2.0)
                {
                  if (this.GUIBIX == 12)
                  {
                    this.GUIBIX = -1;
                    this.ShowingOverlay = true;
                    this.OverlayIndex = 4;
                    this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Would you like to steal supplies", (object) "Confirm", (object) "Cancel", (object) 1);
                  }
                  if (this.GUIBIX == 11)
                  {
                    this.GUIBIX = -1;
                    this.ShowingOverlay = true;
                    this.OverlayIndex = 5;
                    this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Would you like to purchase supplies", (object) "Confirm", (object) "Cancel", (object) 1);
                  }
                }
                if ((double) this.Screen == 3.0)
                {
                  if (this.GUIBIX == 19)
                  {
                    this.GUIBIX = -1;
                    this.ShowingOverlay = true;
                    this.OverlayIndex = 6;
                    this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Confirm fast track research?", (object) "Confirm", (object) "Cancel", (object) 1);
                  }
                  int guibix = this.GUIBIX;
                }
                if ((double) this.Screen == 7.0)
                {
                  if (this.GUIBIX == 9)
                  {
                    this.GUIBIX = -1;
                    this.ShowingOverlay = true;
                    this.OverlayIndex = 7;
                    this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Sell supplies to Blaine County", (object) "Confirm", (object) "Cancel", (object) 1);
                  }
                  if (this.GUIBIX == 10)
                  {
                    this.GUIBIX = -1;
                    this.ShowingOverlay = true;
                    this.OverlayIndex = 8;
                    this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Sell supplies to Los Santos", (object) "Confirm", (object) "Cancel", (object) 1);
                  }
                }
                if (Game.IsControlJustPressed(2, GTA.Control.Context))
                {
                  ++this.Screen;
                  if ((double) this.Screen > 10.0)
                  {
                    this.frame = 2;
                    this.Screen = 0.0f;
                  }
                  UI.Notify("Next Screen " + this.Screen.ToString());
                  this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen, (object) -1f, (object) -1f, (object) -1f, (object) -1f);
                }
                this.GUIscaleform.Render2D();
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num2;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num2 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num2 = 1;
                  if (num2 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num3;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num3 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num3 = 1;
                  if (num3 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
            }
          }
          if (this.NightclubManagementOn)
          {
            if (this.frame == 0)
            {
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "NIGHTCLUB"));
              this.Screen = 0.0f;
              this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
            }
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
                this.frame = 1;
              if (this.frame == 1)
              {
                this.GUIscaleform.CallFunction("UPDATE_UPGRADE", (object) 0, (object) this.NC_Upgrade1Price, (object) this.NC_Upgrade1DiscountedPrice, (object) 2, (object) 0);
                this.GUIscaleform.CallFunction("UPDATE_UPGRADE", (object) 1, (object) this.NC_Upgrade2Price, (object) this.NC_Upgrade2DiscountedPrice, (object) 2, (object) 0);
                this.GUIscaleform.CallFunction("UPDATE_UPGRADE", (object) 2, (object) this.NC_Upgrade3Price, (object) this.NC_Upgrade3DiscountedPrice, (object) 2, (object) 0);
                this.GUIscaleform.CallFunction("UPDATE_TECHNICIAN", (object) 0, (object) this.NC_Technician1Task, (object) this.NC_Technician1Status, (object) this.NC_Technician1LockedStatus, (object) 1);
                this.GUIscaleform.CallFunction("UPDATE_TECHNICIAN", (object) 1, (object) this.NC_Technician2Task, (object) this.NC_Technician2Status, (object) this.NC_Technician2LockedStatus, (object) 2);
                this.GUIscaleform.CallFunction("UPDATE_TECHNICIAN", (object) 2, (object) this.NC_Technician3Task, (object) this.NC_Technician3Status, (object) this.NC_Technician3LockedStatus, (object) 3);
                this.GUIscaleform.CallFunction("UPDATE_TECHNICIAN", (object) 3, (object) this.NC_Technician4Task, (object) this.NC_Technician4Status, (object) this.NC_Technician4LockedStatus, (object) 4);
                this.GUIscaleform.CallFunction("UPDATE_TECHNICIAN", (object) 4, (object) this.NC_Technician5Task, (object) this.NC_Technician5Status, (object) this.NC_Technician5LockedStatus, (object) 5);
                this.GUIscaleform.CallFunction("SELECT_TECHNICIAN", (object) this.TechnicialSelected);
                this.GUIscaleform.CallFunction("UPDATE_STOCK", (object) 6, (object) this.NC_CounterfeitStockCurrent, (object) this.NC_CounterfeitStockMax, (object) (this.NC_CounterfeitStockCurrent * this.NC_CounterfeitPricePerCrate));
                this.GUIscaleform.CallFunction("UPDATE_STOCK", (object) 5, (object) this.NC_PrintCopyStockCurrent, (object) this.NC_PrintCopyStockMax, (object) (this.NC_PrintCopyStockCurrent * this.NC_PrintCopyPricePerCrate));
                this.GUIscaleform.CallFunction("UPDATE_STOCK", (object) 4, (object) this.NC_OrgProduceStockCurrent, (object) this.NC_OrgProduceStockMax, (object) (this.NC_OrgProduceStockCurrent * this.NC_OrgProducePricePerCrate));
                this.GUIscaleform.CallFunction("UPDATE_STOCK", (object) 3, (object) this.NC_PharStockCurrent, (object) this.NC_PharStockMax, (object) (this.NC_PharStockCurrent * this.NC_PharPricePerCrate));
                this.GUIscaleform.CallFunction("UPDATE_STOCK", (object) 2, (object) this.NC_SAIStockCurrent, (object) this.NC_SAIStockMax, (object) (this.NC_SAIStockCurrent * this.NC_SAIPricePerCrate));
                this.GUIscaleform.CallFunction("UPDATE_STOCK", (object) 1, (object) this.NC_SportingGoodsStockCurrent, (object) this.NC_SportingGoodsStockMax, (object) (this.NC_SportingGoodsStockCurrent * this.NC_SportingGoodsPricePerCrate));
                this.GUIscaleform.CallFunction("UPDATE_STOCK", (object) 0, (object) this.NC_CargoStockCurrent, (object) this.NC_CargoStockMax, (object) (this.NC_CargoStockCurrent * this.NC_CargoPricePerCrate));
                this.GUIscaleform.CallFunction("SET_GENERAL_STATS", (object) this.NC_Owner, (object) this.NC_NightclubLocImg, (object) "CLUB_EXT", (object) this.NC_ClubType, (object) this.NC_Location, (object) 0, (object) this.NC_Owner, (object) this.NC_Popuarity, (object) (this.NC_CounterfeitStockCurrent * this.NC_CounterfeitPricePerCrate + this.NC_PrintCopyStockCurrent * this.NC_PrintCopyPricePerCrate + this.NC_OrgProduceStockCurrent * this.NC_OrgProducePricePerCrate + this.NC_PharStockCurrent * this.NC_PharPricePerCrate + this.NC_SAIStockCurrent * this.NC_SAIPricePerCrate + this.NC_SportingGoodsStockCurrent * this.NC_SportingGoodsPricePerCrate + this.NC_CargoStockCurrent * this.NC_CargoPricePerCrate));
                this.GUIscaleform.CallFunction("SET_HOMEPAGE_STATS", (object) this.NC_NightclubJobsCompleted, (object) this.NC_NightClubEarnings, (object) this.NC_WarehouseSalesCompleted, (object) this.NC_WarehouseEarnings, (object) this.NC_TotalEarnings, (object) 1);
                this.GUIscaleform.CallFunction("SET_NIGHTCLUB_STATS", (object) this.NC_PlayerVisits, (object) 29f, (object) this.NC_Dailyincome, (object) this.NC_safeCapacityCrt, (object) this.NC_safeCapacityMax, (object) this.NC_CelebAppearances, (object) 10000f, (object) 20000f, (object) 30000f, (object) 10000f, (object) 10000f, (object) 20000f, (object) 100f);
                this.GUIscaleform.CallFunction("SET_WAREHOUSE_STATS", (object) this.NC_GoodsAquired, (object) this.NC_GoodsSold, (object) this.NC_Goods, (object) 2, (object) 4, (object) 6, (object) 8, (object) 10, (object) 12, (object) 14, (object) 16);
                this.GUIscaleform.CallFunction("UPDATE_DJ", (object) 0, (object) 1, (object) true, (object) "Tales Of Us", (object) "", (object) 0, (object) 25000, (object) "NIGHTCLUB_DJ", (object) "DJ3", (object) true, (object) true);
                this.GUIscaleform.CallFunction("UPDATE_DJ", (object) 1, (object) 1, (object) false, (object) "Black Madonna", (object) "", (object) 0, (object) 25000, (object) "NIGHTCLUB_DJ", (object) "DJ4", (object) true, (object) true);
                this.GUIscaleform.CallFunction("UPDATE_DJ", (object) 2, (object) 1, (object) true, (object) "Solomun", (object) "", (object) 0, (object) 25000, (object) "NIGHTCLUB_DJ", (object) "DJ1", (object) true, (object) true);
                this.GUIscaleform.CallFunction("UPDATE_DJ", (object) 3, (object) 1, (object) false, (object) "Dixon", (object) "", (object) 0, (object) 25000, (object) "NIGHTCLUB_DJ", (object) "DJ2", (object) true, (object) true);
                this.GUIscaleform.CallFunction("UPDATE_ASSIGNMENT", (object) 0, (object) 1, (object) 1);
                this.GUIscaleform.CallFunction("UPDATE_ASSIGNMENT", (object) 1, (object) 1, (object) 1);
                this.GUIscaleform.CallFunction("UPDATE_ASSIGNMENT", (object) 2, (object) 1, (object) 1);
                this.GUIscaleform.CallFunction("UPDATE_ASSIGNMENT", (object) 3, (object) 1, (object) 1);
                this.GUIscaleform.CallFunction("UPDATE_ASSIGNMENT", (object) 4, (object) 1, (object) 1);
                this.GUIscaleform.CallFunction("UPDATE_ASSIGNMENT", (object) 5, (object) 1, (object) 1);
                this.GUIscaleform.CallFunction("UPDATE_ASSIGNMENT", (object) 6, (object) 1, (object) 1);
                this.frame = 2;
              }
              if (this.frame == 2)
              {
                float num2 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                float num3 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                if (Game.IsControlJustPressed(2, this.Key))
                {
                  if ((double) num3 > 0.164000004529953 && (double) num3 < 0.370000004768372 && ((double) num2 > 0.515999972820282 && (double) num2 < 0.579999983310699) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.370000004768372 && ((double) this.GUIPosY > 0.515999972820282 && (double) this.GUIPosY < 0.579999983310699))
                  {
                    this.Screen = 0.0f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
                  }
                  else if ((double) num3 > 0.164000004529953 && (double) num3 < 0.370000004768372 && ((double) num2 > 0.59799998998642 && (double) num2 < 0.657000005245209) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.370000004768372 && ((double) this.GUIPosY > 0.59799998998642 && (double) this.GUIPosY < 0.657000005245209))
                  {
                    this.Screen = 1f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
                  }
                  else if ((double) num3 > 0.164000004529953 && (double) num3 < 0.370000004768372 && ((double) num2 > 0.671999990940094 && (double) num2 < 0.730000019073486) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.370000004768372 && ((double) this.GUIPosY > 0.671999990940094 && (double) this.GUIPosY < 0.730000019073486))
                  {
                    this.Screen = 2f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
                  }
                  else if ((double) num3 > 0.164000004529953 && (double) num3 < 0.370000004768372 && ((double) num2 > 0.740000009536743 && (double) num2 < 0.800000011920929) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.370000004768372 && ((double) this.GUIPosY > 0.74 && (double) this.GUIPosY < 0.800000011920929))
                  {
                    this.Screen = 3f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
                  }
                  else if ((double) num3 > 0.164000004529953 && (double) num3 < 0.370000004768372 && ((double) num2 > 0.889999985694885 && (double) num2 < 0.939999997615814) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.370000004768372 && ((double) this.GUIPosY > 0.889999985694885 && (double) this.GUIPosY < 0.939999997615814))
                  {
                    this.Screen = 4f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
                  }
                  else if ((double) num3 > 0.164000004529953 && (double) num3 < 0.370000004768372 && ((double) num2 > 0.816999971866608 && (double) num2 < 0.870000004768372) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.370000004768372 && ((double) this.GUIPosY > 0.816999971866608 && (double) this.GUIPosY < 0.870000004768372))
                  {
                    this.Screen = 5f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
                  }
                }
                if (Game.IsControlJustPressed(2, GTA.Control.Context))
                {
                  ++this.Screen;
                  if ((double) this.Screen > 5.0)
                  {
                    this.frame = 1;
                    this.Screen = 0.0f;
                  }
                  UI.Notify("Next Screen " + this.Screen.ToString());
                  this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen, (object) -1f, (object) -1f, (object) -1f, (object) -1f);
                }
                this.GUIscaleform.Render2D();
                if (!this.ShowingOverlay)
                {
                  if ((double) this.Screen == 3.0)
                  {
                    if (this.GettingNewTask)
                    {
                      if (this.GUIBIX == 8 && this.NC_Technician1LockedStatus == 0)
                      {
                        this.GettingNewTask = true;
                        this.TechnicialSelected = 0;
                        this.frame = 1;
                        this.GUIBIX = 0;
                      }
                      if (this.GUIBIX == 9 && this.NC_Technician2LockedStatus == 0)
                      {
                        this.GettingNewTask = true;
                        this.TechnicialSelected = 1;
                        this.frame = 1;
                        this.GUIBIX = 0;
                      }
                      if (this.GUIBIX == 10 && this.NC_Technician3LockedStatus == 0)
                      {
                        this.GettingNewTask = true;
                        this.TechnicialSelected = 2;
                        this.frame = 1;
                        this.GUIBIX = 0;
                      }
                      if (this.GUIBIX == 11 && this.NC_Technician4LockedStatus == 0)
                      {
                        this.GettingNewTask = true;
                        this.TechnicialSelected = 3;
                        this.frame = 1;
                        this.GUIBIX = 0;
                      }
                      if (this.GUIBIX == 12 && this.NC_Technician5LockedStatus == 0)
                      {
                        this.GettingNewTask = true;
                        this.TechnicialSelected = 4;
                        this.frame = 1;
                        this.GUIBIX = 0;
                      }
                      if (this.GUIBIX == 13)
                      {
                        if (this.NC_Technician1Task != 0 && this.NC_Technician2Task != 0 && (this.NC_Technician3Task != 0 && this.NC_Technician4Task != 0) && this.NC_Technician5Task != 0)
                        {
                          this.NC_AssignedTask = 0;
                          this.ShowingOverlay = true;
                          this.OverlayIndex = 2;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Assign technician to Cargo & Shipments", (object) "Cancel", (object) "Confirm", (object) 0);
                        }
                        else
                          this.NC_CheckTasks(this.TechnicialSelected, 1);
                      }
                      if (this.GUIBIX == 14)
                      {
                        if (this.NC_Technician1Task != 1 && this.NC_Technician2Task != 1 && (this.NC_Technician3Task != 1 && this.NC_Technician4Task != 1) && this.NC_Technician5Task != 1)
                        {
                          this.NC_AssignedTask = 1;
                          this.ShowingOverlay = true;
                          this.OverlayIndex = 2;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Assign technician to Sporting Goods", (object) "Cancel", (object) "Confirm", (object) 0);
                        }
                        else
                          this.NC_CheckTasks(this.TechnicialSelected, 2);
                      }
                      if (this.GUIBIX == 15)
                      {
                        if (this.NC_Technician1Task != 2 && this.NC_Technician2Task != 2 && (this.NC_Technician3Task != 2 && this.NC_Technician4Task != 2) && this.NC_Technician5Task != 2)
                        {
                          this.NC_AssignedTask = 2;
                          this.ShowingOverlay = true;
                          this.OverlayIndex = 2;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Assign technician to Soth American Imports", (object) "Cancel", (object) "Confirm", (object) 0);
                        }
                        else
                          this.NC_CheckTasks(this.TechnicialSelected, 2);
                      }
                      if (this.GUIBIX == 16)
                      {
                        if (this.NC_Technician1Task != 3 && this.NC_Technician2Task != 3 && (this.NC_Technician3Task != 3 && this.NC_Technician4Task != 3) && this.NC_Technician5Task != 3)
                        {
                          this.NC_AssignedTask = 3;
                          this.ShowingOverlay = true;
                          this.OverlayIndex = 2;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Assign technician to Pharmaceutical Research", (object) "Cancel", (object) "Confirm", (object) 0);
                        }
                        else
                          this.NC_CheckTasks(this.TechnicialSelected, 3);
                      }
                      if (this.GUIBIX == 17)
                      {
                        if (this.NC_Technician1Task != 4 && this.NC_Technician2Task != 4 && (this.NC_Technician3Task != 4 && this.NC_Technician4Task != 4) && this.NC_Technician5Task != 4)
                        {
                          this.NC_AssignedTask = 4;
                          this.ShowingOverlay = true;
                          this.OverlayIndex = 2;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Assign technician to Organic Produce", (object) "Cancel", (object) "Confirm", (object) 0);
                        }
                        else
                          this.NC_CheckTasks(this.TechnicialSelected, 4);
                      }
                      if (this.GUIBIX == 18)
                      {
                        if (this.NC_Technician1Task != 5 && this.NC_Technician2Task != 5 && (this.NC_Technician3Task != 5 && this.NC_Technician4Task != 5) && this.NC_Technician5Task != 5)
                        {
                          this.NC_AssignedTask = 5;
                          this.ShowingOverlay = true;
                          this.OverlayIndex = 2;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Assign technician to Printing & Copying", (object) "Cancel", (object) "Confirm", (object) 0);
                        }
                        else
                          this.NC_CheckTasks(this.TechnicialSelected, 5);
                      }
                      if (this.GUIBIX == 19)
                      {
                        if (this.NC_Technician1Task != 6 && this.NC_Technician2Task != 6 && (this.NC_Technician3Task != 6 && this.NC_Technician4Task != 6) && this.NC_Technician5Task != 6)
                        {
                          this.NC_AssignedTask = 6;
                          this.ShowingOverlay = true;
                          this.OverlayIndex = 2;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Assign technician to Cash Creation", (object) "Cancel", (object) "Confirm", (object) 0);
                        }
                        else
                          this.NC_CheckTasks(this.TechnicialSelected, 6);
                      }
                    }
                    if (this.GUIBIX == 8 && this.NC_Technician1LockedStatus == 0)
                    {
                      this.GettingNewTask = true;
                      this.TechnicialSelected = 0;
                      this.frame = 1;
                      this.GUIBIX = 0;
                    }
                    if (this.GUIBIX == 9 && this.NC_Technician2LockedStatus == 0)
                    {
                      this.GettingNewTask = true;
                      this.TechnicialSelected = 1;
                      this.frame = 1;
                      this.GUIBIX = 0;
                    }
                    if (this.GUIBIX == 10 && this.NC_Technician3LockedStatus == 0)
                    {
                      this.GettingNewTask = true;
                      this.TechnicialSelected = 2;
                      this.frame = 1;
                      this.GUIBIX = 0;
                    }
                    if (this.GUIBIX == 11 && this.NC_Technician4LockedStatus == 0)
                    {
                      this.GettingNewTask = true;
                      this.TechnicialSelected = 3;
                      this.frame = 1;
                      this.GUIBIX = 0;
                    }
                    if (this.GUIBIX == 12 && this.NC_Technician5LockedStatus == 0)
                    {
                      this.GettingNewTask = true;
                      this.TechnicialSelected = 4;
                      this.frame = 1;
                      this.GUIBIX = 0;
                    }
                  }
                  if ((double) this.Screen == 5.0)
                  {
                    if (this.GUIBIX == 27)
                    {
                      this.NC_SellType = 1;
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Sell All Cargo & Shipments Goods", (object) "Cancel", (object) "Confirm", (object) 0);
                    }
                    if (this.GUIBIX == 28)
                    {
                      this.NC_SellType = 2;
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Sell All Sporting Goods", (object) "Cancel", (object) "Confirm", (object) 0);
                    }
                    if (this.GUIBIX == 29)
                    {
                      this.NC_SellType = 3;
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Sell All South American Imports Goods", (object) "Cancel", (object) "Confirm", (object) 0);
                    }
                    if (this.GUIBIX == 30)
                    {
                      this.NC_SellType = 4;
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Sell All Pharmaceutical Research Goods", (object) "Cancel", (object) "Confirm", (object) 0);
                    }
                    if (this.GUIBIX == 31)
                    {
                      this.NC_SellType = 5;
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Sell All Organic Produce Goods", (object) "Cancel", (object) "Confirm", (object) 0);
                    }
                    if (this.GUIBIX == 32)
                    {
                      this.NC_SellType = 6;
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Sell All Printing & Copying Goods ", (object) "Cancel", (object) "Confirm", (object) 0);
                    }
                    if (this.GUIBIX == 33)
                    {
                      this.NC_SellType = 7;
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Sell All Cash Creation Goods", (object) "Cancel", (object) "Confirm", (object) 0);
                    }
                    if (this.GUIBIX == 34)
                    {
                      this.NC_SellType = 8;
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Nightclub Management", (object) "Sell All Goods", (object) "Cancel", (object) "Confirm", (object) 0);
                    }
                  }
                }
                if (this.ShowingOverlay)
                {
                  if ((double) this.Screen == 3.0)
                  {
                    if (this.OverlayIndex == 2)
                    {
                      if (this.GUIBIX == 1)
                      {
                        this.GettingNewTask = false;
                        this.frame = 1;
                        this.GUIBIX = 0;
                        this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                        this.ShowingOverlay = false;
                      }
                      if (this.GUIBIX == 0)
                      {
                        if (this.NC_AssignedTask == 0)
                        {
                          this.GettingNewTask = false;
                          if (this.TechnicialSelected == 0)
                            this.NC_Technician1Task = 0;
                          if (this.TechnicialSelected == 1)
                            this.NC_Technician2Task = 0;
                          if (this.TechnicialSelected == 2)
                            this.NC_Technician3Task = 0;
                          if (this.TechnicialSelected == 3)
                            this.NC_Technician4Task = 0;
                          if (this.TechnicialSelected == 4)
                            this.NC_Technician5Task = 0;
                          this.frame = 1;
                          this.GUIBIX = 0;
                        }
                        if (this.NC_AssignedTask == 1)
                        {
                          this.GettingNewTask = false;
                          if (this.TechnicialSelected == 0)
                            this.NC_Technician1Task = 1;
                          if (this.TechnicialSelected == 1)
                            this.NC_Technician2Task = 1;
                          if (this.TechnicialSelected == 2)
                            this.NC_Technician3Task = 1;
                          if (this.TechnicialSelected == 3)
                            this.NC_Technician4Task = 1;
                          if (this.TechnicialSelected == 4)
                            this.NC_Technician5Task = 1;
                          this.frame = 1;
                          this.GUIBIX = 0;
                        }
                        if (this.NC_AssignedTask == 2)
                        {
                          this.GettingNewTask = false;
                          if (this.TechnicialSelected == 0)
                            this.NC_Technician1Task = 2;
                          if (this.TechnicialSelected == 1)
                            this.NC_Technician2Task = 2;
                          if (this.TechnicialSelected == 2)
                            this.NC_Technician3Task = 2;
                          if (this.TechnicialSelected == 3)
                            this.NC_Technician4Task = 2;
                          if (this.TechnicialSelected == 4)
                            this.NC_Technician5Task = 2;
                          this.frame = 1;
                          this.GUIBIX = 0;
                        }
                        if (this.NC_AssignedTask == 3)
                        {
                          this.GettingNewTask = false;
                          if (this.TechnicialSelected == 0)
                            this.NC_Technician1Task = 3;
                          if (this.TechnicialSelected == 1)
                            this.NC_Technician2Task = 3;
                          if (this.TechnicialSelected == 2)
                            this.NC_Technician3Task = 3;
                          if (this.TechnicialSelected == 3)
                            this.NC_Technician4Task = 3;
                          if (this.TechnicialSelected == 4)
                            this.NC_Technician5Task = 3;
                          this.frame = 1;
                          this.GUIBIX = 0;
                        }
                        if (this.NC_AssignedTask == 4)
                        {
                          this.GettingNewTask = false;
                          if (this.TechnicialSelected == 0)
                            this.NC_Technician1Task = 4;
                          if (this.TechnicialSelected == 1)
                            this.NC_Technician2Task = 4;
                          if (this.TechnicialSelected == 2)
                            this.NC_Technician3Task = 4;
                          if (this.TechnicialSelected == 3)
                            this.NC_Technician4Task = 4;
                          if (this.TechnicialSelected == 4)
                            this.NC_Technician5Task = 4;
                          this.frame = 1;
                          this.GUIBIX = 0;
                        }
                        if (this.NC_AssignedTask == 5)
                        {
                          this.GettingNewTask = false;
                          if (this.TechnicialSelected == 0)
                            this.NC_Technician1Task = 5;
                          if (this.TechnicialSelected == 1)
                            this.NC_Technician2Task = 5;
                          if (this.TechnicialSelected == 2)
                            this.NC_Technician3Task = 5;
                          if (this.TechnicialSelected == 3)
                            this.NC_Technician4Task = 5;
                          if (this.TechnicialSelected == 4)
                            this.NC_Technician5Task = 5;
                          this.frame = 1;
                          this.GUIBIX = 0;
                        }
                        if (this.NC_AssignedTask == 6)
                        {
                          this.GettingNewTask = false;
                          if (this.TechnicialSelected == 0)
                            this.NC_Technician1Task = 6;
                          if (this.TechnicialSelected == 1)
                            this.NC_Technician2Task = 6;
                          if (this.TechnicialSelected == 2)
                            this.NC_Technician3Task = 6;
                          if (this.TechnicialSelected == 3)
                            this.NC_Technician4Task = 6;
                          if (this.TechnicialSelected == 4)
                            this.NC_Technician5Task = 6;
                          this.frame = 1;
                          this.GUIBIX = 0;
                        }
                        this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                        this.ShowingOverlay = false;
                      }
                    }
                    if (this.OverlayIndex == 3)
                    {
                      if (this.GUIBIX == 1)
                      {
                        this.GettingNewTask = false;
                        this.frame = 1;
                        this.GUIBIX = 0;
                        this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                        this.ShowingOverlay = false;
                      }
                      if (this.GUIBIX == 0)
                      {
                        this.GettingNewTask = false;
                        this.frame = 1;
                        this.GUIBIX = 0;
                        this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                        this.ShowingOverlay = false;
                      }
                    }
                  }
                  if ((double) this.Screen == 5.0 && this.OverlayIndex == 2)
                  {
                    if (this.GUIBIX == 1)
                    {
                      this.frame = 1;
                      this.GUIBIX = 0;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 0)
                    {
                      this.frame = 1;
                      this.GUIBIX = 0;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                }
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num6;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num6 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num6 = 1;
                  if (num6 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num7;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num7 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num7 = 1;
                  if (num7 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
            }
          }
          if (this.HangerCargoCrateGUION)
          {
            if (this.frame == 0)
            {
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "HANGAR_CARGO"));
              this.Screen = 0.0f;
              this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
            }
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
                this.frame = 1;
              if (this.frame == 1)
              {
                UI.ShowSubtitle("Test");
                this.GUIscaleform.CallFunction("ADD_CARGO", (object) 1, (object) this.SMG_Narcotics_CurrentStock, (object) this.SMG_Narcotics_StockMax, (object) this.SMG_Narcotics_Bonus, (object) this.SMG_Narcotics_Value);
                this.GUIscaleform.CallFunction("ADD_CARGO", (object) 2, (object) this.SMG_Chemicals_CurrentStock, (object) this.SMG_Chemicals_StockMax, (object) this.SMG_Chemicals_Bonus, (object) this.SMG_Chemicals_Value);
                this.GUIscaleform.CallFunction("ADD_CARGO", (object) 3, (object) this.SMG_MedicalSupplies_CurrentStock, (object) this.SMG_MedicalSupplies_StockMax, (object) this.SMG_MedicalSupplies_Bonus, (object) this.SMG_MedicalSupplies_Value);
                this.GUIscaleform.CallFunction("ADD_CARGO", (object) 4, (object) this.SMG_AnimalMaterials_CurrentStock, (object) this.SMG_AnimalMaterials_StockMax, (object) this.SMG_AnimalMaterials_Bonus, (object) this.SMG_AnimalMaterials_Value);
                this.GUIscaleform.CallFunction("ADD_CARGO", (object) 5, (object) this.SMG_ArtaAntiques_CurrentStock, (object) this.SMG_ArtaAntiques_StockMax, (object) this.SMG_ArtaAntiques_Bonus, (object) this.SMG_ArtaAntiques_Value);
                this.GUIscaleform.CallFunction("ADD_CARGO", (object) 6, (object) this.SMG_JewelryaGemstones_CurrentStock, (object) this.SMG_JewelryaGemstones_StockMax, (object) this.SMG_JewelryaGemstones_Bonus, (object) this.SMG_JewelryaGemstones_Value);
                this.GUIscaleform.CallFunction("ADD_CARGO", (object) 7, (object) this.SMG_TabaccoaAlcohol_CurrentStock, (object) this.SMG_TabaccoaAlcohol_StockMax, (object) this.SMG_TabaccoaAlcohol_Bonus, (object) this.SMG_TabaccoaAlcohol_Value);
                this.GUIscaleform.CallFunction("ADD_CARGO", (object) 8, (object) this.SMG_CounterfeitGoods_CurrentStock, (object) this.SMG_CounterfeitGoods_StockMax, (object) this.SMG_CounterfeitGoods_Bonus, (object) this.SMG_CounterfeitGoods_Value);
                this.SMG_ValueTotal = this.SMG_Narcotics_Value + this.SMG_Chemicals_Value + this.SMG_MedicalSupplies_Value + this.SMG_AnimalMaterials_Value + this.SMG_ArtaAntiques_Value + this.SMG_JewelryaGemstones_Value + this.SMG_TabaccoaAlcohol_Value + this.SMG_CounterfeitGoods_Value;
                this.GUIscaleform.CallFunction("SET_STATS", (object) this.SMG_Name, (object) 0, (object) this.SMG_StealsCompleted, (object) this.SMG_StealSuccessRate, (object) this.SMG_SalesCompleted, (object) this.SMG_SalesSuccessRate, (object) this.SMG_RivalCratesStolen, (object) this.SMG_Earnings, (object) this.SMG_CargoTypeBonus, (object) this.SMG_CurrentCrates, (object) this.SMG_MaxCrates, (object) this.SMG_ValueTotal);
                this.frame = 2;
              }
              if (this.frame == 2)
              {
                if (!this.ShowingOverlay)
                {
                  if ((double) this.Screen == 0.0)
                  {
                    float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (Game.IsControlJustPressed(2, this.Key))
                    {
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.628f, 0.102f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.802f, 0.102f)) < 0.100000001490116)
                      {
                        this.Screen = 1f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 1;
                      }
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.773f, 0.097f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.773f, 0.097f)) < 0.100000001490116)
                      {
                        this.Screen = 2f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 1;
                      }
                    }
                  }
                  else if ((double) this.Screen == 1.0)
                  {
                    float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (Game.IsControlJustPressed(2, this.Key))
                    {
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.49f, 0.097f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.49f, 0.097f)) < 0.100000001490116)
                      {
                        this.Screen = 0.0f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 1;
                      }
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.773f, 0.097f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.773f, 0.097f)) < 0.100000001490116)
                      {
                        this.Screen = 2f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 1;
                      }
                      for (int index = 0; index < this.SMG_Screen1ButtonPos.Count; ++index)
                      {
                        if ((double) new Vector2(x, y).DistanceTo(new Vector2(this.SMG_Screen1ButtonPos[index].X, this.SMG_Screen1ButtonPos[index].Y)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(this.SMG_Screen1ButtonPos[index].X, this.SMG_Screen1ButtonPos[index].Y)) < 0.100000001490116)
                        {
                          this.OverlayIndex = 1;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) this.SMG_Screen2ButtonType[index], (object) "Souce Crate", (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                        }
                      }
                      if ((double) x > 0.164000004529953 && (double) x < 0.934000015258789 && ((double) y > 0.839999973773956 && (double) y < 0.899999976158142) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.934000015258789 && ((double) this.GUIPosY > 0.839999973773956 && (double) this.GUIPosY < 0.899999976158142))
                      {
                        this.OverlayIndex = 1;
                        this.ShowingOverlay = true;
                        this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source Any", (object) "Source Any Crate?", (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                      }
                    }
                  }
                  else if ((double) this.Screen == 2.0)
                  {
                    float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (Game.IsControlJustPressed(2, this.Key))
                    {
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.49f, 0.097f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.49f, 0.097f)) < 0.100000001490116)
                      {
                        this.Screen = 0.0f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 1;
                      }
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.628f, 0.097f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.802f, 0.097f)) < 0.100000001490116)
                      {
                        this.Screen = 1f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 1;
                      }
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.773f, 0.097f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.773f, 0.097f)) < 0.100000001490116)
                      {
                        this.Screen = 2f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 1;
                      }
                      for (int index = 0; index < this.SMG_Screen2ButtonPos.Count; ++index)
                      {
                        if ((double) new Vector2(x, y).DistanceTo(new Vector2(this.SMG_Screen2ButtonPos[index].X, this.SMG_Screen2ButtonPos[index].Y)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(this.SMG_Screen2ButtonPos[index].X, this.SMG_Screen2ButtonPos[index].Y)) < 0.100000001490116)
                        {
                          this.OverlayIndex = 2;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) this.SMG_Screen2ButtonType[index], (object) "Sell Crates", (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                        }
                      }
                      if ((double) x > 0.164000004529953 && (double) x < 0.934000015258789 && ((double) y > 0.899999976158142 && (double) y < 0.962999999523163) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.934000015258789 && ((double) this.GUIPosY > 0.899999976158142 && (double) this.GUIPosY < 0.962999999523163))
                      {
                        this.OverlayIndex = 2;
                        this.ShowingOverlay = true;
                        this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Sell All", (object) "Sell All Crates", (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                      }
                    }
                  }
                }
                if (this.ShowingOverlay)
                {
                  float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                  float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                  if (this.OverlayIndex == 1 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116)
                    {
                      this.SellingCargo = false;
                      this.StealingCargo = false;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                      this.SellingCargo = false;
                      this.StealingCargo = true;
                    }
                  }
                  if (this.OverlayIndex == 2 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116)
                    {
                      this.SellingCargo = false;
                      this.StealingCargo = false;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                      this.SellingCargo = true;
                      this.StealingCargo = false;
                    }
                  }
                }
                if (Game.IsControlJustPressed(2, GTA.Control.Context))
                {
                  ++this.Screen;
                  if ((double) this.Screen > 2.0)
                  {
                    this.frame = 0;
                    this.Screen = 0.0f;
                  }
                  UI.Notify("Next Screen " + this.Screen.ToString());
                  this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) this.Screen, (object) -1f, (object) -1f, (object) -1f, (object) -1f);
                }
                this.GUIscaleform.Render2D();
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num2;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num2 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num2 = 1;
                  if (num2 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num3;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num3 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num3 = 1;
                  if (num3 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
            }
          }
          int num10;
          if (this.SecuroservCargoOn)
          {
            if (this.frame == 0)
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "securoserv"));
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
              {
                this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                this.frame = 1;
              }
              if (this.frame == 1)
              {
                if (this.SellType == 1)
                {
                  this.GUIscaleform.CallFunction("SHOW_EXPORT_SCREEN");
                  this.GUIscaleform.CallFunction("SHOW_BUYERS", (object) 1, (object) 2, (object) 3, (object) 4, (object) 5, (object) 6, (object) true, (object) true, (object) true);
                  this.GUIscaleform.CallFunction("UPDATE_COLLECTION", (object) 0, (object) 0, (object) false);
                  this.GUIscaleform.CallFunction("UPDATE_VEHICLE", (object) 12, (object) 13, (object) 0, (object) false, (object) true, (object) 0, (object) 0);
                  Vector2 vector2 = new Vector2(-376f, -1868f);
                  for (int index = 0; index < this.CargoWarehouses.Count; ++index)
                    this.CargoWarehouses[index].Index = index;
                  for (int index = 0; index < this.CargoWarehouses.Count; ++index)
                  {
                    if (this.SS_WarehousesOwned >= 1 && this.SS_Warehouse1Index == index)
                    {
                      this.CargoWarehouses[index].ID = 0;
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE", (object) 0, (object) this.CargoWarehouses[index].Location.X, (object) this.CargoWarehouses[index].Location.Y, (object) this.CargoWarehouses[index].DiscountCost, (object) this.CargoWarehouses[index].WarehouseName, (object) this.CargoWarehouses[index].WarehouseLocation, (object) 1, (object) this.CargoWarehouses[index].PicTexture, (object) 1, (object) this.CargoWarehouses[index].Size, (object) this.CargoWarehouses[index].Maxcrates, (object) this.SS_Warehouse1Stock, (object) this.SS_Warehouse1CurrentValue, (object) 1, (object) 3, (object) 40, (object) 30, (object) "TEST1 ", (object) "TEST2 ", (object) "TEST3 ", (object) "TEST4");
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 0, (object) 1, (object) 0, (object) "Jewelry", (object) 2, (object) 8000, (object) 3, (object) 0, (object) 18000, (object) 3, (object) 2000);
                    }
                    else if (this.SS_WarehousesOwned >= 2 && this.SS_Warehouse2Index == index)
                    {
                      this.CargoWarehouses[index].ID = 1;
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE", (object) 1, (object) this.CargoWarehouses[index].Location.X, (object) this.CargoWarehouses[index].Location.Y, (object) this.CargoWarehouses[index].DiscountCost, (object) this.CargoWarehouses[index].WarehouseName, (object) this.CargoWarehouses[index].WarehouseLocation, (object) 1, (object) this.CargoWarehouses[index].PicTexture, (object) 1, (object) this.CargoWarehouses[index].Size, (object) this.CargoWarehouses[index].Maxcrates, (object) this.SS_Warehouse2Stock, (object) this.SS_Warehouse2CurrentValue, (object) 1, (object) 3, (object) 40, (object) 30, (object) "TEST1 ", (object) "TEST2 ", (object) "TEST3 ", (object) "TEST4");
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 1, (object) 1, (object) 0, (object) "Jewelry", (object) 2, (object) 8000, (object) 3, (object) 0, (object) 18000, (object) 3, (object) 2000);
                    }
                    else if (this.SS_WarehousesOwned >= 3 && this.SS_Warehouse3Index == index)
                    {
                      this.CargoWarehouses[index].ID = 2;
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE", (object) 2, (object) this.CargoWarehouses[index].Location.X, (object) this.CargoWarehouses[index].Location.Y, (object) this.CargoWarehouses[index].DiscountCost, (object) this.CargoWarehouses[index].WarehouseName, (object) this.CargoWarehouses[index].WarehouseLocation, (object) 1, (object) this.CargoWarehouses[index].PicTexture, (object) 1, (object) this.CargoWarehouses[index].Size, (object) this.CargoWarehouses[index].Maxcrates, (object) this.SS_Warehouse3Stock, (object) this.SS_Warehouse3CurrentValue, (object) 1, (object) 1, (object) 3, (object) 40, (object) 30, (object) "TEST1 ", (object) "TEST2 ", (object) "TEST3 ", (object) "TEST4");
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 2, (object) 1, (object) 0, (object) "Jewelry", (object) 2, (object) 8000, (object) 3, (object) 0, (object) 18000, (object) 3, (object) 2000);
                    }
                    else if (this.SS_WarehousesOwned >= 4 && this.SS_Warehouse4Index == index)
                    {
                      this.CargoWarehouses[index].ID = 3;
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE", (object) 3, (object) this.CargoWarehouses[index].Location.X, (object) this.CargoWarehouses[index].Location.Y, (object) this.CargoWarehouses[index].DiscountCost, (object) this.CargoWarehouses[index].WarehouseName, (object) this.CargoWarehouses[index].WarehouseLocation, (object) 1, (object) this.CargoWarehouses[index].PicTexture, (object) 1, (object) this.CargoWarehouses[index].Size, (object) this.CargoWarehouses[index].Maxcrates, (object) this.SS_Warehouse4Stock, (object) this.SS_Warehouse4CurrentValue, (object) 1, (object) 1, (object) 3, (object) 40, (object) 30, (object) "TEST1 ", (object) "TEST2 ", (object) "TEST3 ", (object) "TEST4");
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 3, (object) 1, (object) 0, (object) "Jewelry", (object) 2, (object) 8000, (object) 3, (object) 3, (object) 18000, (object) 3, (object) 2000);
                    }
                    else if (this.SS_WarehousesOwned >= 5 && this.SS_Warehouse5Index == index)
                    {
                      this.CargoWarehouses[index].ID = 4;
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE", (object) 4, (object) this.CargoWarehouses[index].Location.X, (object) this.CargoWarehouses[index].Location.Y, (object) this.CargoWarehouses[index].DiscountCost, (object) this.CargoWarehouses[index].WarehouseName, (object) this.CargoWarehouses[index].WarehouseLocation, (object) 1, (object) this.CargoWarehouses[index].PicTexture, (object) 1, (object) this.CargoWarehouses[index].Size, (object) this.CargoWarehouses[index].Maxcrates, (object) this.SS_Warehouse5Stock, (object) this.SS_Warehouse5CurrentValue, (object) 1, (object) 1, (object) 3, (object) 40, (object) 30, (object) "TEST1 ", (object) "TEST2 ", (object) "TEST3 ", (object) "TEST4");
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 4, (object) 1, (object) 0, (object) "Jewelry", (object) 2, (object) 8000, (object) 3, (object) 3, (object) 18000, (object) 3, (object) 2000);
                    }
                  }
                  for (int index = 0; index < this.CargoWarehouses.Count; ++index)
                  {
                    if (this.SS_Warehouse1Index != index && this.SS_Warehouse2Index != index && (this.SS_Warehouse3Index != index && this.SS_Warehouse4Index != index) && this.SS_Warehouse5Index != index)
                    {
                      this.CargoWarehouses[index].ID = this.SS_WarehousesOwned + index;
                      this.GUIscaleform.CallFunction("SET_WAREHOUSE_DATA", (object) -1, (object) 1, (object) 2, (object) 3, (object) 4, (object) 6, (object) 7);
                      this.GUIscaleform.CallFunction("ADD_WAREHOUSE", (object) (this.SS_WarehousesOwned + index), (object) this.CargoWarehouses[index].Location.X, (object) this.CargoWarehouses[index].Location.Y, (object) this.CargoWarehouses[index].DiscountCost, (object) this.CargoWarehouses[index].WarehouseName, (object) this.CargoWarehouses[index].WarehouseLocation, (object) this.CargoWarehouses[index].WarehouseDescription, (object) this.CargoWarehouses[index].PicTexture, (object) this.CargoWarehouses[index].Owned, (object) this.CargoWarehouses[index].Size, (object) this.CargoWarehouses[index].Maxcrates, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0, (object) this.CargoWarehouses[index].Cost, (object) 0, (object) 0, (object) 0, (object) 0);
                    }
                  }
                  this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) this.SS_Name, (object) 0, (object) this.SS_TotalEarnings, (object) this.SS_CollectionsCompleted, (object) this.SS_SuccessRate, (object) this.SS_VehicleSalesMade, (object) this.SS_SaleSuccessRate, (object) this.SS_Name, (object) this.SS_VehiclesStolenSuccess, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0, (object) -63, (object) -787);
                  this.GUIscaleform.CallFunction("IS_WAREHOUSE_PANEL_SHOWING");
                  this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                  this.frame = 2;
                }
                if (this.SellType == 2)
                {
                  this.GUIscaleform.CallFunction("SHOW_EXPORT_SCREEN");
                  this.GUIscaleform.CallFunction("SHOW_BUYERS", (object) 1, (object) 2, (object) 3, (object) 4, (object) 5, (object) 6, (object) true, (object) true, (object) true);
                  this.GUIscaleform.CallFunction("UPDATE_COLLECTION", (object) 1, (object) 2, (object) false);
                  this.GUIscaleform.CallFunction("UPDATE_VEHICLE", (object) 4, (object) 13, (object) 5, (object) false, (object) true, (object) 1, (object) 0);
                  this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) this.SS_Name, (object) 0, (object) this.SS_TotalEarnings, (object) this.SS_CollectionsCompleted, (object) this.SS_SuccessRate, (object) this.SS_VehicleSalesMade, (object) this.SS_SaleSuccessRate, (object) this.SS_Name, (object) this.SS_VehiclesStolenTotal, (object) this.SS_StealSuccessTotal, (object) this.SS_StealSuccessTotal, (object) this.SS_VehiclesExportedSuccess, (object) this.SS_VehiclesExportedTotal, (object) 242000, (object) 0, (object) -63, (object) -787, (object) "Test2", (object) "Test3");
                  Vector2 vector2 = new Vector2(-376f, -1868f);
                  int num2 = 1;
                  for (int index = 0; index < this.VehicleWarehouses.Count; ++index)
                  {
                    if (this.VehicleWarehouseBought == 1 && this.VehicleWarehouseIndex == index)
                      this.GUIscaleform.CallFunction("ADD_VEHICLE_WAREHOUSE", (object) index, (object) this.VehicleWarehouses[index].VehicleWarehouseCoords.X, (object) this.VehicleWarehouses[index].VehicleWarehouseCoords.Y, (object) this.VehicleWarehouses[index].Price, (object) this.VehicleWarehouses[index].DiscountPrice, (object) this.VehicleWarehouses[index].Price, (object) this.VehicleWarehouses[index].DiscountPrice, (object) this.VehicleWarehouses[index].Price, (object) this.VehicleWarehouses[index].DiscountPrice, (object) this.VehicleWarehouses[index].VehicleWarehouseName, (object) this.VehicleWarehouses[index].VehicleWarehouseLocationName, (object) this.VehicleWarehouses[index].VehicleWarehouseDescription, (object) this.VehicleWarehouses[index].VehicleWarehousePicTex, (object) num2, (object) 40, (object) this.SS_CurrentVehiclesAmt, (object) this.SS_VehiclesTotalCurrentValue, (object) this.SS_SourceVehicleWait, (object) 1, (object) 0, (object) 0, (object) 0, (object) 0);
                    else
                      this.GUIscaleform.CallFunction("ADD_VEHICLE_WAREHOUSE", (object) index, (object) this.VehicleWarehouses[index].VehicleWarehouseCoords.X, (object) this.VehicleWarehouses[index].VehicleWarehouseCoords.Y, (object) this.VehicleWarehouses[index].Price, (object) this.VehicleWarehouses[index].DiscountPrice, (object) this.VehicleWarehouses[index].Price, (object) this.VehicleWarehouses[index].DiscountPrice, (object) this.VehicleWarehouses[index].Price, (object) this.VehicleWarehouses[index].DiscountPrice, (object) this.VehicleWarehouses[index].VehicleWarehouseName, (object) this.VehicleWarehouses[index].VehicleWarehouseLocationName, (object) this.VehicleWarehouses[index].VehicleWarehouseDescription, (object) this.VehicleWarehouses[index].VehicleWarehousePicTex, (object) 0, (object) 40, (object) 0, (object) 0, (object) false, (object) 0, (object) 1, (object) 0, (object) 0.0f, (object) 1);
                  }
                  this.GUIscaleform.CallFunction("SET_WAREHOUSE_DATA", (object) 6, (object) 4, (object) 8, (object) 10, (object) 16, (object) 32, (object) 2, (object) 64, (object) true, (object) true, (object) true);
                  this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 1, (object) "DYN_MPWH_1", (object) 2, (object) "DYN_MPWH_5", (object) 3, (object) "DYN_MPWH_6", (object) 1, (object) true, (object) -1, (object) -1, (object) -1);
                  this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                  this.frame = 2;
                }
                this.frame = 2;
              }
              if (this.frame == 2)
              {
                if (!this.ShowingOverlay)
                {
                  if ((double) this.Screen == 1.0)
                  {
                    float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (Game.IsControlJustPressed(2, this.Key))
                    {
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.503f, 0.332f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.503f, 0.332f)) < 0.100000001490116)
                      {
                        this.Screen = 2f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.928f, 0.926f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.928f, 0.926f)) < 0.100000001490116)
                      {
                        this.Screen = 2f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                    }
                  }
                  else if ((double) this.Screen == 2.0)
                  {
                    float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (this.WarehouseSelected != this.SS_Warehouse1Index && this.WarehouseSelected != this.SS_Warehouse2Index && (this.WarehouseSelected != this.SS_Warehouse3Index && this.WarehouseSelected != this.SS_Warehouse4Index) && (this.WarehouseSelected != this.SS_Warehouse1Index && this.GUIBIX == 3007))
                    {
                      if (this.SS_WarehousesOwned < 5)
                      {
                        this.GUIBIX = 0;
                        this.OverlayIndex = 4;
                        this.ShowingOverlay = true;
                        this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Purchase Warehouse", (object) ("Are you sure you'd like to purchase " + this.CargoWarehouses[this.WarehouseSelected].WarehouseName + " Warehouse, for $" + this.CargoWarehouses[this.WarehouseSelected].Cost.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                      }
                      else
                      {
                        this.OverlayIndex = 4;
                        this.ShowingOverlay = true;
                        this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Player Owns 5 Warehouses", (object) "You already have 5 Warehouses, at any one time the player can only have this many Cargo Warehouses", (object) "OK", (object) "OK", (object) false, (object) false);
                      }
                    }
                    for (int index = 0; index < this.CargoWarehouses.Count; ++index)
                    {
                      if (this.GUIBIX == 3008)
                      {
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 1)
                        {
                          this.CratesToSource = 1;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 1 Crate", (object) ("Are you sure you'd like to source 1 crate and store it in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source1Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 2)
                        {
                          this.CratesToSource = 1;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 1 Crate", (object) ("Are you sure you'd like to source 1 crate and store it in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source1Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 3)
                        {
                          this.CratesToSource = 1;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 1 Crate", (object) ("Are you sure you'd like to source 1 crate and store it in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source1Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 4)
                        {
                          this.CratesToSource = 1;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 1 Crate", (object) ("Are you sure you'd like to source 1 crate and store it in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source1Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 5)
                        {
                          this.CratesToSource = 1;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 1 Crate", (object) ("Are you sure you'd like to source 1 crate and store it in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source1Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                      }
                      if (this.GUIBIX == 3009)
                      {
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 1)
                        {
                          this.CratesToSource = 2;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 2 Crates", (object) ("Are you sure you'd like to source 2 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source2Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 2)
                        {
                          this.CratesToSource = 2;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 2 Crates", (object) ("Are you sure you'd like to source 2 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source2Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 3)
                        {
                          this.CratesToSource = 2;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 1 Crates", (object) ("Are you sure you'd like to source 2 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source2Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 4)
                        {
                          this.CratesToSource = 2;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 1 Crates", (object) ("Are you sure you'd like to source 2 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source2Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 5)
                        {
                          this.CratesToSource = 2;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 1 Crates", (object) ("Are you sure you'd like to source 2 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source2Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                      }
                      if (this.GUIBIX == 3010)
                      {
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 1)
                        {
                          this.CratesToSource = 3;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 3 Crates", (object) ("Are you sure you'd like to source 3 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source3Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 2)
                        {
                          this.CratesToSource = 3;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 3 Crates", (object) ("Are you sure you'd like to source 3 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source3Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 3)
                        {
                          this.CratesToSource = 3;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 3 Crates", (object) ("Are you sure you'd like to source 3 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source3Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 4)
                        {
                          this.CratesToSource = 3;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 3 Crates", (object) ("Are you sure you'd like to source 3 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source3Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                        if (this.WarehouseSelected == this.CargoWarehouses[index].ID && this.SS_WarehousesOwned >= 5)
                        {
                          this.CratesToSource = 3;
                          this.OverlayIndex = 6;
                          this.ShowingOverlay = true;
                          this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source 3 Crates", (object) ("Are you sure you'd like to source 3 crates and store them in " + this.CargoWarehouses[this.CargoWarehouses[index].Index].WarehouseName + " Warehouse, for $" + this.Source3Price.ToString("N")), (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                        }
                      }
                    }
                    if (Game.IsControlJustPressed(2, this.Key) && ((double) new Vector2(x, y).DistanceTo(new Vector2(0.802f, 0.93f)) < 0.0700000002980232 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.802f, 0.93f)) < 0.0700000002980232))
                    {
                      this.Screen = 1f;
                      this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                      this.frame = 0;
                    }
                  }
                  else if ((double) this.Screen == 3.0)
                  {
                    float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (Game.IsControlJustPressed(2, this.Key))
                    {
                      if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.28f, 0.492f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.28f, 0.492f)) < 0.100000001490116)
                      {
                        this.GUIscaleform.Unload();
                        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "securoserv"));
                        this.SellType = 1;
                        this.Screen = 0.0f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                      else if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.49f, 0.49f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.49f, 0.49f)) < 0.100000001490116)
                      {
                        this.GUIscaleform.Unload();
                        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "securoserv"));
                        this.SellType = 2;
                        this.Screen = 0.0f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                    }
                  }
                  if ((double) this.Screen == 0.0)
                  {
                    float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (Game.IsControlJustPressed(2, this.Key) && ((double) new Vector2(x, y).DistanceTo(new Vector2(0.583f, 0.635f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.583f, 0.635f)) < 0.100000001490116))
                    {
                      if (this.SellType == 2)
                      {
                        this.Screen = 4f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                      else if (this.SellType == 1)
                      {
                        this.Screen = 1f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                    }
                  }
                  else if ((double) this.Screen == 4.0)
                  {
                    float num2 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float num3 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (Game.IsControlJustPressed(2, this.Key))
                    {
                      if ((double) num3 > 0.129999995231628 && (double) num3 < 0.303999990224838 && ((double) num2 > 0.0520000010728836 && (double) num2 < 0.0829999968409538) || (double) this.GUIPosX > 0.129999995231628 && (double) this.GUIPosX < 0.303999990224838 && ((double) this.GUIPosY > 0.0520000010728836 && (double) this.GUIPosY < 0.0829999968409538))
                      {
                        this.GUIscaleform.Unload();
                        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "securoserv"));
                        this.Screen = 5f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                      if ((double) num3 > 0.373600006103516 && (double) num3 < 0.568400025367737 && ((double) num2 > 0.697499990463257 && (double) num2 < 0.755999982357025) || (double) this.GUIPosX > 0.373600006103516 && (double) this.GUIPosX < 0.568400025367737 && ((double) this.GUIPosY > 0.697499990463257 && (double) this.GUIPosY < 0.755999982357025))
                      {
                        this.GUIscaleform.Unload();
                        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "securoserv"));
                        this.Screen = 5f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                    }
                  }
                  else if ((double) this.Screen == 5.0)
                  {
                    float num2 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                    float num3 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                    if (Game.IsControlJustPressed(2, this.Key))
                    {
                      if (((double) num3 > 0.0121999997645617 && (double) num3 < 0.246999993920326 && ((double) num2 > 0.800000011920929 && (double) num2 < 0.861000001430511) || (double) this.GUIPosX > 0.0121999997645617 && (double) this.GUIPosX < 0.246999993920326 && ((double) this.GUIPosY > 0.800000011920929 && (double) this.GUIPosY < 0.861000001430511)) && this.GUIBIX != this.VehicleWarehouseIndex)
                      {
                        this.OverlayIndex = 5;
                        this.ShowingOverlay = true;
                        Scaleform guIscaleform = this.GUIscaleform;
                        object[] objArray = new object[6];
                        objArray[0] = (object) "Purchase Vehicle Warehouse";
                        string vehicleWarehouseName = this.VehicleWarehouses[this.GUIBIX].VehicleWarehouseName;
                        num10 = this.VehicleWarehouses[this.GUIBIX].DiscountPrice;
                        string str = num10.ToString("N");
                        objArray[1] = (object) ("Are you sure you'd like to purchase " + vehicleWarehouseName + ", for $" + str);
                        objArray[2] = (object) "Confirm";
                        objArray[3] = (object) "Cancel";
                        objArray[4] = (object) false;
                        objArray[5] = (object) false;
                        guIscaleform.CallFunction("SHOW_OVERLAY", objArray);
                      }
                      if ((double) num3 > 1.0 / 1000.0 && (double) num3 < 0.126000002026558 && ((double) num2 > 0.0531000010669231 && (double) num2 < 0.800000011920929) || (double) this.GUIPosX > 1.0 / 1000.0 && (double) this.GUIPosX < 0.126000002026558 && ((double) this.GUIPosY > 0.0531000010669231 && (double) this.GUIPosY < 0.800000011920929))
                      {
                        this.GUIscaleform.Unload();
                        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "securoserv"));
                        this.Screen = 4f;
                        this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                        this.frame = 0;
                      }
                      if ((double) num3 > 0.0148000000044703 && (double) num3 < 0.248999997973442 && ((double) num2 > 0.569400012493134 && (double) num2 < 0.628799974918365) || (double) this.GUIPosX > 0.0148000000044703 && (double) this.GUIPosX < 0.248999997973442 && ((double) this.GUIPosY > 0.569400012493134 && (double) this.GUIPosY < 0.628799974918365))
                      {
                        this.OverlayIndex = 1;
                        this.ShowingOverlay = true;
                        this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Souce Vehicle", (object) "Are you sure you'd like to source a vehicle to steal?", (object) "Confirm", (object) "Cancel", (object) false, (object) false);
                      }
                    }
                  }
                }
                if (this.ShowingOverlay)
                {
                  float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                  float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                  if (this.OverlayIndex == 1 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 4 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.3034f, 0.5701f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.3034f, 0.5701f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.6907f, 0.5665f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.6907f, 0.5665f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 5 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.3034f, 0.5701f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.3034f, 0.5701f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.6907f, 0.5665f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.6907f, 0.5665f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                  if (this.OverlayIndex == 6)
                  {
                    if (this.GUIBIX == 3013)
                    {
                      this.GUIBIX = 0;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if (this.GUIBIX == 3012)
                    {
                      this.GUIBIX = 0;
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                  }
                }
                this.GUIscaleform.Render2D();
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num2;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num2 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num2 = 1;
                  if (num2 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num3;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num3 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num3 = 1;
                  if (num3 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
            }
          }
          if (this.SecuroservVehicleOn)
          {
            if (this.frame == 0)
            {
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "IMPORT_EXPORT_WAREHOUSE"));
              this.Tab = 1f;
            }
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
                this.frame = 1;
              if (this.frame == 1)
              {
                this.GUIscaleform.CallFunction("SHOW_EXPORT_SCREEN");
                this.GUIscaleform.CallFunction("UPDATE_COLLECTION", (object) 1, (object) 42, (object) true);
                for (int iParam0 = 0; iParam0 < 97; num10 = iParam0++)
                {
                  this.func_280(iParam0);
                  this.GUIscaleform.CallFunction("UPDATE_VEHICLE", (object) iParam0, (object) 0, (object) 1, (object) false, (object) true, (object) 0, (object) 1);
                }
                this.frame = 2;
              }
              if (this.frame == 2)
              {
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 197, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 198, (InputArgument) 1);
                int controlValue1 = Game.GetControlValue(2, GTA.Control.FrontendRightAxisX);
                int controlValue2 = Game.GetControlValue(2, GTA.Control.FrontendRightAxisY);
                bool flag = Game.IsControlPressed(2, GTA.Control.CursorScrollDown) || Game.IsDisabledControlPressed(2, GTA.Control.CursorScrollDown);
                if (!flag)
                  flag = Game.IsControlPressed(2, GTA.Control.CursorScrollUp) || Game.IsDisabledControlPressed(2, GTA.Control.CursorScrollUp);
                this.GUIscaleform.CallFunction("SET_ANALOG_STICK_INPUT", (object) false, (object) controlValue1, (object) controlValue2, (object) flag);
                if (!this.ADV_LoadFirsttime)
                {
                  this.ADV_LoadFirsttime = true;
                  for (int index = 0; index < 7; num10 = index++)
                  {
                    if ((double) this.Screen > 6.0)
                    {
                      ++this.Screen;
                      this.frame = 1;
                      this.Screen = 0.0f;
                    }
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen, (object) -1f, (object) -1f, (object) -1f, (object) -1f);
                  }
                }
                this.GUIscaleform.Render2D();
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num2;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num2 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num2 = 1;
                  if (num2 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num3;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num3 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num3 = 1;
                  if (num3 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
            }
          }
          if (this.AdhawlScaleOn)
          {
            if (this.frame == 0)
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "warehouse"));
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
                this.frame = 1;
              if (this.frame == 1)
              {
                int warehouseId = this.GetWarehouseID(this.CurrentWarehouse);
                this.GUIscaleform.CallFunction("ADD_WAREHOUSE", (object) 1, (object) 10000f, (object) 10000f, (object) 2, (object) "DYN_MPWH_10", (object) true, (object) 3, (object) 4, (object) 5, (object) 6, (object) 7, (object) 8, (object) 9, (object) 10);
                this.SS_Name = Game.Player.Name;
                this.SS_SpecialItems = (int) this.GetSpecialItemsCount();
                if (warehouseId == 1)
                {
                  this.SS_Warehouse1Rating = this.SS_Warehouse1SalesMade <= 0 ? 0.0f : (float) ((double) this.SS_Warehouse1SalesFailed / (double) this.SS_Warehouse1SalesMade * 100.0);
                  this.SS_Warehouse1Rating = 100f - this.SS_Warehouse1Rating;
                  this.SS_Warehouse1Rating = (float) (int) this.SS_Warehouse1Rating;
                  this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) this.SS_Name, (object) this.AHC_Company, (object) (int) this.SS_Warehouse1Rating, (object) this.SS_Warehouse1SalesMade, (object) this.SS_Warehouse1LifetimeEarnings);
                  this.CurrentPrice = this.GetWarehouseValue();
                  this.CurrentStock = (float) this.GetCrateCountByID(1);
                }
                if (warehouseId == 2)
                {
                  this.SS_Warehouse2Rating = this.SS_Warehouse2SalesMade <= 0 ? 0.0f : (float) ((double) this.SS_Warehouse2SalesFailed / (double) this.SS_Warehouse2SalesMade * 100.0);
                  this.SS_Warehouse2Rating = 100f - this.SS_Warehouse2Rating;
                  this.SS_Warehouse2Rating = (float) (int) this.SS_Warehouse2Rating;
                  this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) this.SS_Name, (object) this.AHC_Company, (object) (int) this.SS_Warehouse2Rating, (object) this.SS_Warehouse2SalesMade, (object) this.SS_Warehouse2LifetimeEarnings, (object) 1f, (object) 2f);
                  this.CurrentPrice = this.GetWarehouseValue();
                  this.CurrentStock = (float) this.GetCrateCountByID(2);
                }
                if (warehouseId == 3)
                {
                  this.SS_Warehouse3Rating = this.SS_Warehouse3SalesMade <= 0 ? 0.0f : (float) ((double) this.SS_Warehouse3SalesFailed / (double) this.SS_Warehouse3SalesMade * 100.0);
                  this.SS_Warehouse3Rating = 100f - this.SS_Warehouse3Rating;
                  this.SS_Warehouse3Rating = (float) (int) this.SS_Warehouse3Rating;
                  this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) this.SS_Name, (object) this.AHC_Company, (object) (int) this.SS_Warehouse3Rating, (object) this.SS_Warehouse3SalesMade, (object) this.SS_Warehouse3LifetimeEarnings);
                  this.CurrentPrice = this.GetWarehouseValue();
                  this.CurrentStock = (float) this.GetCrateCountByID(3);
                }
                if (warehouseId == 4)
                {
                  this.SS_Warehouse4Rating = this.SS_Warehouse4SalesMade <= 0 ? 0.0f : (float) ((double) this.SS_Warehouse4SalesFailed / (double) this.SS_Warehouse4SalesMade * 100.0);
                  this.SS_Warehouse4Rating = 100f - this.SS_Warehouse4Rating;
                  this.SS_Warehouse4Rating = (float) (int) this.SS_Warehouse4Rating;
                  this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) this.SS_Name, (object) this.AHC_Company, (object) (int) this.SS_Warehouse4Rating, (object) this.SS_Warehouse4SalesMade, (object) this.SS_Warehouse4LifetimeEarnings);
                  this.CurrentPrice = this.GetWarehouseValue();
                  this.CurrentStock = (float) this.GetCrateCountByID(4);
                }
                if (warehouseId == 5)
                {
                  this.SS_Warehouse5Rating = this.SS_Warehouse5SalesMade <= 0 ? 0.0f : (float) ((double) this.SS_Warehouse5SalesFailed / (double) this.SS_Warehouse5SalesMade * 100.0);
                  this.SS_Warehouse5Rating = 100f - this.SS_Warehouse5Rating;
                  this.SS_Warehouse5Rating = (float) (int) this.SS_Warehouse5Rating;
                  this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) this.SS_Name, (object) this.AHC_Company, (object) (int) this.SS_Warehouse5Rating, (object) this.SS_Warehouse5SalesMade, (object) this.SS_Warehouse5LifetimeEarnings);
                  this.CurrentPrice = this.GetWarehouseValue();
                  this.CurrentStock = (float) this.GetCrateCountByID(5);
                }
                Scaleform guIscaleform = this.GUIscaleform;
                object[] objArray = new object[9];
                objArray[0] = (object) "East Carraway Holdings";
                objArray[1] = (object) (this.CurrentStock.ToString() + " Crates").ToString();
                objArray[2] = (object) this.CurrentPrice;
                objArray[3] = (object) "Chiliad International";
                num10 = (int) ((double) this.CurrentStock / 100.0 * 50.0);
                objArray[4] = (object) (num10.ToString() + " Crates").ToString();
                objArray[5] = (object) (float) ((double) this.CurrentPrice / 100.0 * 50.0);
                objArray[6] = (object) "Tsetse Import Exports";
                num10 = (int) ((double) this.CurrentStock / 100.0 * 20.0);
                objArray[7] = (object) (num10.ToString() + " Crates").ToString();
                objArray[8] = (object) (float) ((double) this.CurrentPrice / 100.0 * 20.0);
                guIscaleform.CallFunction("SET_BUYER_DATA", objArray);
                this.GUIscaleform.CallFunction("UPDATE_COOLDOWN", (object) 220);
                string warehouseName = this.CargoWarehouses[this.CurrentWarehouse].WarehouseName;
                string warehouseLocation = this.CargoWarehouses[this.CurrentWarehouse].WarehouseLocation;
                int size = this.CargoWarehouses[this.CurrentWarehouse].Size;
                int maxcrates = this.CargoWarehouses[this.CurrentWarehouse].Maxcrates;
                if (warehouseId == 1)
                {
                  this.GUIscaleform.CallFunction("SET_WAREHOUSE_DATA", (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseName, (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseLocation, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Maxcrates, (object) this.SS_Warehouse1Stock, (object) 2, (object) this.SS_SpecialItems, (object) true, (object) true, (object) true);
                  this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 1, (object) "DYN_MPWH_1", (object) 2, (object) "DYN_MPWH_5", (object) 3, (object) "DYN_MPWH_6", (object) 1, (object) true, (object) -1, (object) -1, (object) -1);
                }
                if (warehouseId == 2)
                {
                  this.GUIscaleform.CallFunction("SET_WAREHOUSE_DATA", (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseName, (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseLocation, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Maxcrates, (object) this.SS_Warehouse2Stock, (object) 2, (object) this.SS_SpecialItems, (object) true, (object) true, (object) true);
                  this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 1, (object) "DYN_MPWH_1", (object) 2, (object) "DYN_MPWH_5", (object) 3, (object) "DYN_MPWH_6", (object) 1, (object) true, (object) -1, (object) -1, (object) -1);
                }
                if (warehouseId == 3)
                {
                  this.GUIscaleform.CallFunction("SET_WAREHOUSE_DATA", (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseName, (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseLocation, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Maxcrates, (object) this.SS_Warehouse3Stock, (object) 2, (object) this.SS_SpecialItems, (object) true, (object) true, (object) true);
                  this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 1, (object) "DYN_MPWH_1", (object) 2, (object) "DYN_MPWH_5", (object) 3, (object) "DYN_MPWH_6", (object) 1, (object) true, (object) -1, (object) -1, (object) -1);
                }
                if (warehouseId == 4)
                {
                  this.GUIscaleform.CallFunction("SET_WAREHOUSE_DATA", (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseName, (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseLocation, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Maxcrates, (object) this.SS_Warehouse4Stock, (object) 2, (object) this.SS_SpecialItems, (object) true, (object) true, (object) true);
                  this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 1, (object) "DYN_MPWH_1", (object) 2, (object) "DYN_MPWH_5", (object) 3, (object) "DYN_MPWH_6", (object) 1, (object) true, (object) -1, (object) -1, (object) -1);
                }
                if (warehouseId == 5)
                {
                  this.GUIscaleform.CallFunction("SET_WAREHOUSE_DATA", (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseName, (object) this.CargoWarehouses[this.CurrentWarehouse].WarehouseLocation, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Size, (object) this.CargoWarehouses[this.CurrentWarehouse].Maxcrates, (object) this.SS_Warehouse5Stock, (object) 2, (object) this.SS_SpecialItems, (object) true, (object) true, (object) true);
                  this.GUIscaleform.CallFunction("ADD_WAREHOUSE_SHIPMENTS", (object) 1, (object) "DYN_MPWH_1", (object) 2, (object) "DYN_MPWH_5", (object) 3, (object) "DYN_MPWH_6", (object) 1, (object) true, (object) -1, (object) -1, (object) -1);
                }
                this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                this.frame = 2;
              }
              if (this.frame == 2)
              {
                if (!this.ShowingOverlay)
                {
                  float num2 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                  float num3 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                  if (Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) num3 > 0.690999984741211 && (double) num3 < 0.828999996185303 && ((double) num2 > 0.541000008583069 && (double) num2 < 0.620999991893768) || (double) this.GUIPosX > 0.690999984741211 && (double) this.GUIPosX < 0.828999996185303 && ((double) this.GUIPosY > 0.541000008583069 && (double) this.GUIPosY < 0.620999991893768))
                    {
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 1;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Warehouse", (object) ("Sell " + (this.CurrentStock.ToString() + " Crates").ToString() + " Crates"), (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                    }
                    else if ((double) num3 > 0.690999984741211 && (double) num3 < 0.828999996185303 && ((double) num2 > 0.625999987125397 && (double) num2 < 0.703999996185303) || (double) this.GUIPosX > 0.690999984741211 && (double) this.GUIPosX < 0.828999996185303 && ((double) this.GUIPosY > 0.625999987125397 && (double) this.GUIPosY < 0.703999996185303))
                    {
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 2;
                      Scaleform guIscaleform = this.GUIscaleform;
                      object[] objArray = new object[6];
                      objArray[0] = (object) "Warehouse";
                      num10 = (int) ((double) this.CurrentStock / 100.0 * 50.0);
                      objArray[1] = (object) ("Sell " + num10.ToString() + " Crates");
                      objArray[2] = (object) "Confirm";
                      objArray[3] = (object) "Cancel";
                      objArray[4] = (object) true;
                      objArray[5] = (object) false;
                      guIscaleform.CallFunction("SHOW_OVERLAY", objArray);
                    }
                    else if ((double) num3 > 0.690999984741211 && (double) num3 < 0.828999996185303 && ((double) num2 > 0.716000020503998 && (double) num2 < 0.791000008583069) || (double) this.GUIPosX > 0.690999984741211 && (double) this.GUIPosX < 0.828999996185303 && ((double) this.GUIPosY > 0.716000020503998 && (double) this.GUIPosY < 0.791000008583069))
                    {
                      this.ShowingOverlay = true;
                      this.OverlayIndex = 3;
                      Scaleform guIscaleform = this.GUIscaleform;
                      object[] objArray = new object[6];
                      objArray[0] = (object) "Warehouse";
                      num10 = (int) ((double) this.CurrentStock / 100.0 * 20.0);
                      objArray[1] = (object) ("Sell " + num10.ToString() + " Crates");
                      objArray[2] = (object) "Confirm";
                      objArray[3] = (object) "Cancel";
                      objArray[4] = (object) true;
                      objArray[5] = (object) false;
                      guIscaleform.CallFunction("SHOW_OVERLAY", objArray);
                    }
                  }
                }
                if (this.ShowingOverlay)
                {
                  float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                  float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                  if (this.OverlayIndex == 1 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                      this.PercentageSell = 1f;
                      System.Random random1 = new System.Random();
                      int num2 = random1.Next(0, 300);
                      int num3 = 0;
                      if (num2 <= 100)
                      {
                        num3 = 1;
                        if ((Entity) this.SupplyMissionMainVehicle != (Entity) null)
                          this.SupplyMissionMainVehicle.Delete();
                        this.PointstoGoto = 0;
                        this.Selectedpoints = 0;
                        this.PointsBeenAt = 0;
                        this.AmttoDeliver = 0;
                        this.WaitingForDrop = false;
                        foreach (SubBusinesses.Flare flare in this.Cargo)
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
                        if (this.SupplyMissionPeds.Count > 0)
                          this.SupplyMissionPeds.Clear();
                        if (this.SupplyMissionBlips.Count > 0)
                          this.SupplyMissionBlips.Clear();
                        if (this.SupplyMissionProps.Count > 0)
                          this.SupplyMissionProps.Clear();
                        if (this.SupplyMissionVehicles.Count > 0)
                          this.SupplyMissionVehicles.Clear();
                        System.Random random2 = new System.Random();
                        int index = random2.Next(0, this.TugSpawnH.Count);
                        this.SupplyMissionMainVehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Tug), this.TugSpawnH[index].Position, this.TugSpawnH[index].Heading);
                        this.SupplyMissionMainVehicle.IsInvincible = true;
                        this.SupplyMissionVehicles.Add(this.SupplyMissionMainVehicle);
                        Vector3 position = this.SupplyMissionMainVehicle.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 3;
                      }
                      if (num2 > 100 && num2 <= 200)
                      {
                        System.Random random2 = new System.Random();
                        num3 = 2;
                        List<Vector3> vector3List = new List<Vector3>();
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
                        this.Deliveries = 0;
                        random1.Next(0, 100);
                        random1.Next(0, 100);
                        this.DeliveryVehicle1 = (Vehicle) null;
                        this.DeliveryVehicle2 = (Vehicle) null;
                        this.DeliveryVehicle3 = (Vehicle) null;
                        this.DeliveryVehicle4 = (Vehicle) null;
                        int index = random1.Next(0, this.BrickadeSpawnH.Count);
                        float num4 = 9999f;
                        Vector3 vector3 = this.BrickadeSpawnH[index].Position;
                        foreach (Vector3 brickadeSpawnPo in this.BrickadeSpawnPos)
                        {
                          if ((double) num4 > (double) World.GetDistance(this.CurrentWarehousePos, brickadeSpawnPo))
                          {
                            vector3 = brickadeSpawnPo;
                            num4 = World.GetDistance(this.CurrentWarehousePos, brickadeSpawnPo);
                          }
                        }
                        this.DeliveryVehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.BrickadeSpawnH[index].Heading);
                        this.SupplyMissionVehicles.Add(this.DeliveryVehicle1);
                        ++this.Deliveries;
                        Script.Wait(1);
                        if (random1.Next(0, 100) > 50)
                        {
                          this.DeliveryVehicle2 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.DeliveryVehicle1.Heading);
                          this.SupplyMissionVehicles.Add(this.DeliveryVehicle2);
                          this.DeliveryVehicle2.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, 0.0f));
                          ++this.Deliveries;
                          Script.Wait(1);
                        }
                        if (random1.Next(0, 100) > 60 && this.Deliveries == 2)
                        {
                          this.DeliveryVehicle3 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.DeliveryVehicle1.Heading);
                          this.SupplyMissionVehicles.Add(this.DeliveryVehicle3);
                          this.DeliveryVehicle3.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -7f, 0.0f));
                          ++this.Deliveries;
                          Script.Wait(1);
                        }
                        Vector3 position = this.DeliveryVehicle1.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate Brickades";
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate Brickades";
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        Script.Wait(1);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 2;
                        foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                        {
                          if ((Entity) supplyMissionPed != (Entity) null)
                          {
                            int num5 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) supplyMissionPed, (InputArgument) num5);
                            Function.Call(Hash._0x9F7794730795E019, (InputArgument) supplyMissionPed, (InputArgument) 0, (InputArgument) 0);
                            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) supplyMissionPed, (InputArgument) 1);
                            supplyMissionPed.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
                            if ((Entity) supplyMissionPed.CurrentVehicle.Driver != (Entity) supplyMissionPed)
                              supplyMissionPed.Task.FightAgainst(Game.Player.Character);
                          }
                        }
                      }
                      if (num2 > 200)
                      {
                        num3 = 3;
                        if ((Entity) this.SupplyMissionMainVehicle != (Entity) null)
                          this.SupplyMissionMainVehicle.Delete();
                        this.PointstoGoto = 0;
                        this.Selectedpoints = 0;
                        this.PointsBeenAt = 0;
                        this.AmttoDeliver = 0;
                        this.WaitingForDrop = false;
                        foreach (SubBusinesses.Flare flare in this.Cargo)
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
                        if (this.SupplyMissionPeds.Count > 0)
                          this.SupplyMissionPeds.Clear();
                        if (this.SupplyMissionBlips.Count > 0)
                          this.SupplyMissionBlips.Clear();
                        if (this.SupplyMissionProps.Count > 0)
                          this.SupplyMissionProps.Clear();
                        if (this.SupplyMissionVehicles.Count > 0)
                          this.SupplyMissionVehicles.Clear();
                        System.Random random2 = new System.Random();
                        int index = random2.Next(0, this.Cuban800SpawnH.Count);
                        this.SupplyMissionMainVehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Cuban800), this.Cuban800SpawnH[index].Position, this.Cuban800SpawnH[index].Heading);
                        this.SupplyMissionMainVehicle.IsInvincible = true;
                        this.SupplyMissionMainVehicle.PlaceOnGround();
                        this.SupplyMissionVehicles.Add(this.SupplyMissionMainVehicle);
                        Vector3 position = this.SupplyMissionMainVehicle.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 1;
                      }
                    }
                  }
                  if (this.OverlayIndex == 2 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                      this.PercentageSell = 0.5f;
                      System.Random random1 = new System.Random();
                      int num2 = random1.Next(0, 300);
                      int num3 = 0;
                      if (num2 <= 100)
                      {
                        num3 = 1;
                        if ((Entity) this.SupplyMissionMainVehicle != (Entity) null)
                          this.SupplyMissionMainVehicle.Delete();
                        this.PointstoGoto = 0;
                        this.Selectedpoints = 0;
                        this.PointsBeenAt = 0;
                        this.AmttoDeliver = 0;
                        this.WaitingForDrop = false;
                        foreach (SubBusinesses.Flare flare in this.Cargo)
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
                        if (this.SupplyMissionPeds.Count > 0)
                          this.SupplyMissionPeds.Clear();
                        if (this.SupplyMissionBlips.Count > 0)
                          this.SupplyMissionBlips.Clear();
                        if (this.SupplyMissionProps.Count > 0)
                          this.SupplyMissionProps.Clear();
                        if (this.SupplyMissionVehicles.Count > 0)
                          this.SupplyMissionVehicles.Clear();
                        System.Random random2 = new System.Random();
                        int index = random2.Next(0, this.TugSpawnH.Count);
                        this.SupplyMissionMainVehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Tug), this.TugSpawnH[index].Position, this.TugSpawnH[index].Heading);
                        this.SupplyMissionMainVehicle.IsInvincible = true;
                        this.SupplyMissionVehicles.Add(this.SupplyMissionMainVehicle);
                        Vector3 position = this.SupplyMissionMainVehicle.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 3;
                      }
                      if (num2 > 100 && num2 <= 200)
                      {
                        System.Random random2 = new System.Random();
                        num3 = 2;
                        List<Vector3> vector3List = new List<Vector3>();
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
                        this.Deliveries = 0;
                        random1.Next(0, 100);
                        random1.Next(0, 100);
                        this.DeliveryVehicle1 = (Vehicle) null;
                        this.DeliveryVehicle2 = (Vehicle) null;
                        this.DeliveryVehicle3 = (Vehicle) null;
                        this.DeliveryVehicle4 = (Vehicle) null;
                        int index = random1.Next(0, this.BrickadeSpawnH.Count);
                        float num4 = 9999f;
                        Vector3 vector3 = this.BrickadeSpawnH[index].Position;
                        foreach (Vector3 brickadeSpawnPo in this.BrickadeSpawnPos)
                        {
                          if ((double) num4 > (double) World.GetDistance(this.CurrentWarehousePos, brickadeSpawnPo))
                          {
                            vector3 = brickadeSpawnPo;
                            num4 = World.GetDistance(this.CurrentWarehousePos, brickadeSpawnPo);
                          }
                        }
                        this.DeliveryVehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.BrickadeSpawnH[index].Heading);
                        this.SupplyMissionVehicles.Add(this.DeliveryVehicle1);
                        ++this.Deliveries;
                        Script.Wait(1);
                        if (random1.Next(0, 100) > 50)
                        {
                          this.DeliveryVehicle2 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.DeliveryVehicle1.Heading);
                          this.SupplyMissionVehicles.Add(this.DeliveryVehicle2);
                          this.DeliveryVehicle2.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, 0.0f));
                          ++this.Deliveries;
                          Script.Wait(1);
                        }
                        if (random1.Next(0, 100) > 60 && this.Deliveries == 2)
                        {
                          this.DeliveryVehicle3 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.DeliveryVehicle1.Heading);
                          this.SupplyMissionVehicles.Add(this.DeliveryVehicle3);
                          this.DeliveryVehicle3.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -7f, 0.0f));
                          ++this.Deliveries;
                          Script.Wait(1);
                        }
                        Vector3 position = this.DeliveryVehicle1.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate Brickades";
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate Brickades";
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        Script.Wait(1);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 2;
                        foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                        {
                          if ((Entity) supplyMissionPed != (Entity) null)
                          {
                            int num5 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) supplyMissionPed, (InputArgument) num5);
                            Function.Call(Hash._0x9F7794730795E019, (InputArgument) supplyMissionPed, (InputArgument) 0, (InputArgument) 0);
                            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) supplyMissionPed, (InputArgument) 1);
                            supplyMissionPed.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
                            if ((Entity) supplyMissionPed.CurrentVehicle.Driver != (Entity) supplyMissionPed)
                              supplyMissionPed.Task.FightAgainst(Game.Player.Character);
                          }
                        }
                      }
                      if (num2 > 200)
                      {
                        num3 = 3;
                        if ((Entity) this.SupplyMissionMainVehicle != (Entity) null)
                          this.SupplyMissionMainVehicle.Delete();
                        this.PointstoGoto = 0;
                        this.Selectedpoints = 0;
                        this.PointsBeenAt = 0;
                        this.AmttoDeliver = 0;
                        this.WaitingForDrop = false;
                        foreach (SubBusinesses.Flare flare in this.Cargo)
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
                        if (this.SupplyMissionPeds.Count > 0)
                          this.SupplyMissionPeds.Clear();
                        if (this.SupplyMissionBlips.Count > 0)
                          this.SupplyMissionBlips.Clear();
                        if (this.SupplyMissionProps.Count > 0)
                          this.SupplyMissionProps.Clear();
                        if (this.SupplyMissionVehicles.Count > 0)
                          this.SupplyMissionVehicles.Clear();
                        System.Random random2 = new System.Random();
                        int index = random2.Next(0, this.Cuban800SpawnH.Count);
                        this.SupplyMissionMainVehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Cuban800), this.Cuban800SpawnH[index].Position, this.Cuban800SpawnH[index].Heading);
                        this.SupplyMissionMainVehicle.IsInvincible = true;
                        this.SupplyMissionMainVehicle.PlaceOnGround();
                        this.SupplyMissionVehicles.Add(this.SupplyMissionMainVehicle);
                        Vector3 position = this.SupplyMissionMainVehicle.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 1;
                      }
                    }
                  }
                  if (this.OverlayIndex == 3 && Game.IsControlJustPressed(2, this.Key))
                  {
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.376f, 0.562f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                    }
                    if ((double) new Vector2(x, y).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116 || (double) new Vector2(this.GUIPosX, this.GUIPosY).DistanceTo(new Vector2(0.622f, 0.555f)) < 0.100000001490116)
                    {
                      this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                      this.ShowingOverlay = false;
                      this.PercentageSell = 0.2f;
                      System.Random random1 = new System.Random();
                      int num2 = random1.Next(0, 300);
                      int num3 = 0;
                      if (num2 <= 100)
                      {
                        num3 = 1;
                        if ((Entity) this.SupplyMissionMainVehicle != (Entity) null)
                          this.SupplyMissionMainVehicle.Delete();
                        this.PointstoGoto = 0;
                        this.Selectedpoints = 0;
                        this.PointsBeenAt = 0;
                        this.AmttoDeliver = 0;
                        this.WaitingForDrop = false;
                        foreach (SubBusinesses.Flare flare in this.Cargo)
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
                        if (this.SupplyMissionPeds.Count > 0)
                          this.SupplyMissionPeds.Clear();
                        if (this.SupplyMissionBlips.Count > 0)
                          this.SupplyMissionBlips.Clear();
                        if (this.SupplyMissionProps.Count > 0)
                          this.SupplyMissionProps.Clear();
                        if (this.SupplyMissionVehicles.Count > 0)
                          this.SupplyMissionVehicles.Clear();
                        System.Random random2 = new System.Random();
                        int index = random2.Next(0, this.TugSpawnH.Count);
                        this.SupplyMissionMainVehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Tug), this.TugSpawnH[index].Position, this.TugSpawnH[index].Heading);
                        this.SupplyMissionMainVehicle.IsInvincible = true;
                        this.SupplyMissionVehicles.Add(this.SupplyMissionMainVehicle);
                        Vector3 position = this.SupplyMissionMainVehicle.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 3;
                      }
                      if (num2 > 100 && num2 <= 200)
                      {
                        System.Random random2 = new System.Random();
                        num3 = 2;
                        List<Vector3> vector3List = new List<Vector3>();
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
                        this.Deliveries = 0;
                        random1.Next(0, 100);
                        random1.Next(0, 100);
                        this.DeliveryVehicle1 = (Vehicle) null;
                        this.DeliveryVehicle2 = (Vehicle) null;
                        this.DeliveryVehicle3 = (Vehicle) null;
                        this.DeliveryVehicle4 = (Vehicle) null;
                        int index = random1.Next(0, this.BrickadeSpawnH.Count);
                        float num4 = 9999f;
                        Vector3 vector3 = this.BrickadeSpawnH[index].Position;
                        foreach (Vector3 brickadeSpawnPo in this.BrickadeSpawnPos)
                        {
                          if ((double) num4 > (double) World.GetDistance(this.CurrentWarehousePos, brickadeSpawnPo))
                          {
                            vector3 = brickadeSpawnPo;
                            num4 = World.GetDistance(this.CurrentWarehousePos, brickadeSpawnPo);
                          }
                        }
                        this.DeliveryVehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.BrickadeSpawnH[index].Heading);
                        this.SupplyMissionVehicles.Add(this.DeliveryVehicle1);
                        ++this.Deliveries;
                        Script.Wait(1);
                        if (random1.Next(0, 100) > 50)
                        {
                          this.DeliveryVehicle2 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.DeliveryVehicle1.Heading);
                          this.SupplyMissionVehicles.Add(this.DeliveryVehicle2);
                          this.DeliveryVehicle2.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, 0.0f));
                          ++this.Deliveries;
                          Script.Wait(1);
                        }
                        if (random1.Next(0, 100) > 60 && this.Deliveries == 2)
                        {
                          this.DeliveryVehicle3 = World.CreateVehicle(this.RequestModel(VehicleHash.Brickade), this.BrickadeSpawnH[index].Position, this.DeliveryVehicle1.Heading);
                          this.SupplyMissionVehicles.Add(this.DeliveryVehicle3);
                          this.DeliveryVehicle3.Position = this.DeliveryVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -7f, 0.0f));
                          ++this.Deliveries;
                          Script.Wait(1);
                        }
                        Vector3 position = this.DeliveryVehicle1.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate Brickades";
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate Brickades";
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        Script.Wait(1);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 2;
                        foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                        {
                          if ((Entity) supplyMissionPed != (Entity) null)
                          {
                            int num5 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) supplyMissionPed, (InputArgument) num5);
                            Function.Call(Hash._0x9F7794730795E019, (InputArgument) supplyMissionPed, (InputArgument) 0, (InputArgument) 0);
                            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) supplyMissionPed, (InputArgument) 1);
                            supplyMissionPed.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
                            if ((Entity) supplyMissionPed.CurrentVehicle.Driver != (Entity) supplyMissionPed)
                              supplyMissionPed.Task.FightAgainst(Game.Player.Character);
                          }
                        }
                      }
                      if (num2 > 200)
                      {
                        num3 = 3;
                        if ((Entity) this.SupplyMissionMainVehicle != (Entity) null)
                          this.SupplyMissionMainVehicle.Delete();
                        this.PointstoGoto = 0;
                        this.Selectedpoints = 0;
                        this.PointsBeenAt = 0;
                        this.AmttoDeliver = 0;
                        this.WaitingForDrop = false;
                        foreach (SubBusinesses.Flare flare in this.Cargo)
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
                        if (this.SupplyMissionPeds.Count > 0)
                          this.SupplyMissionPeds.Clear();
                        if (this.SupplyMissionBlips.Count > 0)
                          this.SupplyMissionBlips.Clear();
                        if (this.SupplyMissionProps.Count > 0)
                          this.SupplyMissionProps.Clear();
                        if (this.SupplyMissionVehicles.Count > 0)
                          this.SupplyMissionVehicles.Clear();
                        System.Random random2 = new System.Random();
                        int index = random2.Next(0, this.Cuban800SpawnH.Count);
                        this.SupplyMissionMainVehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Cuban800), this.Cuban800SpawnH[index].Position, this.Cuban800SpawnH[index].Heading);
                        this.SupplyMissionMainVehicle.IsInvincible = true;
                        this.SupplyMissionMainVehicle.PlaceOnGround();
                        this.SupplyMissionVehicles.Add(this.SupplyMissionMainVehicle);
                        Vector3 position = this.SupplyMissionMainVehicle.Position.Around((float) random2.Next(0, 15));
                        Blip blip1 = World.CreateBlip(position);
                        blip1.Sprite = BlipSprite.Standard;
                        blip1.Color = BlipColor.Blue;
                        blip1.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip1.Alpha = (int) byte.MaxValue;
                        blip1.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip1);
                        Blip blip2 = World.CreateBlip(position);
                        blip2.Sprite = BlipSprite.BigCircle;
                        blip2.Color = BlipColor.Blue;
                        blip2.Name = "Locate " + this.SupplyMissionMainVehicle.FriendlyName;
                        blip2.Alpha = 144;
                        blip2.IsShortRange = true;
                        Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip2, (InputArgument) true);
                        this.SupplyMissionBlips.Add(blip2);
                        this.SupplyMissionStage = 1;
                        this.SupplyMissionOn = true;
                        this.SupplyMissionID = 1;
                      }
                    }
                  }
                }
                this.GUIscaleform.Render2D();
                this.GUIscaleform.CallFunction("showScreen", (object) 4);
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num2;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num2 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num2 = 1;
                  if (num2 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num3;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num3 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num3 = 1;
                  if (num3 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
              this.ShowGUIInsrucitons();
            }
          }
          if (this.ArcadeHubGUIon)
          {
            if (this.frame == 0)
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "ARCADE_BUSINESS_HUB"));
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
                this.frame = 1;
              if (this.frame == 1)
              {
                this.frame = 2;
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 0, (object) "COCAINE LOCKUP", (object) "COCAINE_LOCKUP", (object) "Manage Business", (object) 10f, (object) "", (object) 10f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 2, (object) "METH LAB", (object) "METH_LAB", (object) "Manage Business", (object) 20f, (object) "", (object) 10f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 3, (object) "FAKE CASH", (object) "FAKE_CASH", (object) "Manage Business", (object) 20f, (object) "", (object) 10f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 4, (object) "WEED FARM", (object) "WEED_FARM", (object) "Manage Business", (object) 20f, (object) "", (object) 10f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 5, (object) "DOCUMENT FORGERY", (object) "DOC_FORGERY", (object) "Manage Business", (object) 20f, (object) "", (object) 10f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 6, (object) "GUNRUNNING SUPPLIES", (object) "GUNRUNNING", (object) "Manage Business", (object) 20f, (object) "", (object) 10f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 7, (object) "AIR FREIGHT", (object) "AIR_FREIGHT", (object) "Manage Business", (object) 20f, (object) "", (object) 10f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) "NIGHTCLUB", (object) "NIGHTCLUB", (object) "Manage Business", (object) 20f, (object) "", (object) 1f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 8, (object) "SPECIAL CARGO", (object) "SPECIAL_CARGO", (object) "Manage Business", (object) 20f, (object) "", (object) 10f, (object) true, (object) false);
                this.GUIscaleform.CallFunction("SET_PLAYER", (object) Function.Call<string>(Hash._0x6D0DE6A7B5DA71F8, (InputArgument) Function.Call<Player>(Hash._0x4F8644AF03D0E0D6)), (object) "HKH191");
                this.frame = 2;
              }
              if (this.frame == 2)
              {
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 197, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 198, (InputArgument) 1);
                int controlValue1 = Game.GetControlValue(2, GTA.Control.FrontendRightAxisX);
                int controlValue2 = Game.GetControlValue(2, GTA.Control.FrontendRightAxisY);
                bool flag = Game.IsControlPressed(2, GTA.Control.CursorScrollDown) || Game.IsDisabledControlPressed(2, GTA.Control.CursorScrollDown);
                if (!flag)
                  flag = Game.IsControlPressed(2, GTA.Control.CursorScrollUp) || Game.IsDisabledControlPressed(2, GTA.Control.CursorScrollUp);
                this.GUIscaleform.CallFunction("SET_ANALOG_STICK_INPUT", (object) false, (object) controlValue1, (object) controlValue2, (object) flag);
                if (!this.AH_LoadFirsttime)
                {
                  this.AH_LoadFirsttime = true;
                  for (int index = 0; index < 7; num10 = index++)
                  {
                    if ((double) this.Screen > 6.0)
                    {
                      ++this.Screen;
                      this.frame = 1;
                      this.Screen = 0.0f;
                    }
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen, (object) -1f, (object) -1f, (object) -1f, (object) -1f);
                  }
                }
                this.GUIscaleform.Render2D();
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num2;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num2 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num2 = 1;
                  if (num2 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num3;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num3 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num3 = 1;
                  if (num3 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
            }
          }
          if (this.ArcadeManagementGUIon)
          {
            if (this.frame == 0)
            {
              this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "ARCADE_MANAGEMENT"));
              this.GUIscaleform.CallFunction("SHOW_SCREEN", (object) 4);
            }
            while (!this.GUIscaleform.IsLoaded)
              Script.Wait(0);
            if (this.GUIscaleform.IsLoaded)
            {
              if (this.frame == 0)
                this.frame = 1;
              if (this.frame == 1)
              {
                this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) "HKH191", (object) "", (object) "MP_ARC1");
                this.GUIscaleform.CallFunction("ADD_UPGRADE", (object) 0, (object) "UPGRADE_1", (object) 10, (object) 20, (object) true);
                this.GUIscaleform.CallFunction("ADD_CABINET", (object) 0, (object) "CABINET_3", (object) 10, (object) 20, (object) true);
                this.frame = 2;
              }
              if (this.frame == 2)
              {
                if (Game.IsControlJustPressed(2, GTA.Control.Context))
                {
                  ++this.Screen;
                  if ((double) this.Screen > 6.0)
                  {
                    this.frame = 1;
                    this.Screen = 0.0f;
                  }
                  UI.Notify("Next Screen " + this.Screen.ToString());
                  this.GUIscaleform.CallFunction("showScreen", (object) this.Screen, (object) -1f, (object) -1f, (object) -1f, (object) -1f);
                }
                this.GUIscaleform.Render2D();
                if (Game.CurrentInputMode == InputMode.MouseAndKeyboard)
                  this.GUIscaleform.CallFunction("SET_MOUSE_INPUT", (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 239), (object) Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 0, (InputArgument) 240));
                if (Game.CurrentInputMode == InputMode.GamePad && this.GUIMT < Game.GameTime)
                {
                  int num2;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                    num2 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                  else
                    num2 = 1;
                  if (num2 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 8);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY > -10.5)
                      this.GUIPosY -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num3;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                    num3 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                  else
                    num3 = 1;
                  if (num3 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 9);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    if ((double) this.GUIPosY < 10.5)
                      this.GUIPosY += 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num4;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                    num4 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                  else
                    num4 = 1;
                  if (num4 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 10);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    if ((double) this.GUIPosX > -10.5)
                      this.GUIPosX -= 0.01f;
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                  int num5;
                  if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                    num5 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                  else
                    num5 = 1;
                  if (num5 != 0)
                  {
                    this.GUIMT = Game.GameTime + 2;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_INPUT_EVENT");
                    Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 11);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                    if ((double) this.GUIPosX < 10.5)
                      this.GUIPosX += 0.01f;
                    Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.GUIscaleform.Handle, (InputArgument) "SET_MOUSE_INPUT");
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosX);
                    Function.Call(Hash._0xD69736AAE04DB51A, (InputArgument) this.GUIPosY);
                    Function.Call(Hash._0xC6796A8FFA375E53);
                  }
                }
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 201, (InputArgument) 1);
                Function.Call(Hash._0x351220255D64C155, (InputArgument) 2, (InputArgument) 237, (InputArgument) 1);
              }
            }
          }
        }
      }
      catch
      {
        UI.Notify("Error Detected");
      }
      if (!this.Firsttime)
      {
        this.Firsttime = true;
        if ((Entity) this.ChairProp_1 != (Entity) null)
          this.ChairProp_1.Delete();
        this.ChairProp_1 = World.CreateProp(this.RequestModel("ex_prop_offchair_exec_02"), this.ChairPos_1, new Vector3(0.0f, 0.0f, this.P_Rotation_1 - 180f), false, false);
        this.ChairProp_1.FreezePosition = true;
        if ((Entity) this.ChairProp_2 != (Entity) null)
          this.ChairProp_2.Delete();
        this.ChairProp_2 = World.CreateProp(this.RequestModel("ex_prop_offchair_exec_02"), this.ChairPos_2, new Vector3(0.0f, 0.0f, this.P_Rotation_2 - 180f), false, false);
        this.ChairProp_2.FreezePosition = true;
        if ((Entity) this.ChairProp_3 != (Entity) null)
          this.ChairProp_3.Delete();
        this.ChairProp_3 = World.CreateProp(this.RequestModel("ex_prop_offchair_exec_02"), this.ChairPos_3, new Vector3(0.0f, 0.0f, this.P_Rotation_3 - 180f), false, false);
        this.ChairProp_3.FreezePosition = true;
      }
      this.SubLoc = this.SubbusinessLocVector3;
      this.onKeyDown();
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      if (this.WarehouseMenu != null && this.WarehouseMenu.IsAnyMenuOpen())
        this.WarehouseMenu.ProcessMenus();
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_3) < 10.0)
      {
        this.ChairProp = this.ChairProp_3;
        this.ChairLoc = this.ChairPos_3;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_2) < 10.0)
      {
        this.ChairProp = this.ChairProp_2;
        this.ChairLoc = this.ChairPos_2;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_1) < 10.0)
      {
        this.ChairProp = this.ChairProp_1;
        this.ChairLoc = this.ChairPos_1;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_3) < 30.0)
      {
        Prop[] nearbyProps = World.GetNearbyProps(Game.Player.Character.Position, 30f, this.RequestModel(1268458364));
        if (nearbyProps.Length != 0)
        {
          foreach (Prop prop in nearbyProps)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_2) < 30.0)
      {
        Prop[] nearbyProps = World.GetNearbyProps(Game.Player.Character.Position, 30f, this.RequestModel(2040839490));
        if (nearbyProps.Length != 0)
        {
          foreach (Prop prop in nearbyProps)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairLoc) < 2.0)
      {
        if (this.IsSittinginCeoSeat)
        {
          if (Game.IsControlJustPressed(2, GTA.Control.FrontendPauseAlternate) && this.AdhawlScaleOn)
          {
            Prop chairProp = this.ChairProp;
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_exit", (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num, (InputArgument) "computer_exit_chair", (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            this.Screen = 0.0f;
            this.frame = 0;
            this.GUIOn = false;
            this.GUIscaleform.Unload();
            this.AdhawlScaleOn = false;
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Context) && !this.AdhawlScaleOn)
          {
            Prop chairProp = this.ChairProp;
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(100);
            this.Screen = 0.0f;
            this.frame = 0;
            this.NightclubManagementOn = false;
            this.SecuroservCargoOn = false;
            this.SecuroservVehicleOn = false;
            this.HangerCargoCrateGUION = false;
            this.AdhawlScaleOn = false;
            this.BunkerLogisiticsGUIOn = false;
            this.AdhawlScaleOn = true;
            this.GUIOn = true;
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            this.modMenuPool.CloseAllMenus();
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ChairProp.Position.X, (InputArgument) this.ChairProp.Position.Y, (InputArgument) this.ChairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ChairProp.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "exit", (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ChairProp, (InputArgument) num, (InputArgument) "exit_chair", (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(4000);
            Game.Player.Character.Task.ClearAll();
            this.IsSittinginCeoSeat = false;
            if (this.AdhawlScaleOn)
            {
              this.Screen = 0.0f;
              this.frame = 0;
              this.GUIOn = false;
              this.GUIscaleform.Unload();
              this.AdhawlScaleOn = false;
            }
          }
        }
        else if (!this.IsSittinginCeoSeat && Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          Script.Wait(100);
          string str = "anim@amb@office@boss@male@";
          SubBusinesses.LoadDict("anim@amb@office@boss@male@");
          if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) str))
          {
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ChairProp.Position.X, (InputArgument) this.ChairProp.Position.Y, (InputArgument) this.ChairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ChairProp.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "enter", (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ChairProp, (InputArgument) num, (InputArgument) "enter_chair", (InputArgument) SubBusinesses.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(5000);
            this.IsSittinginCeoSeat = true;
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairLoc) < 2.0)
      {
        if (this.IsSittinginCeoSeat)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open Menu, Press ~INPUT_COVER~ to Exit");
        else
          this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to sit on chair to access Menu");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairLoc) > 4.0 && this.IsSittinginCeoSeat)
      {
        this.IsSittinginCeoSeat = false;
        Game.Player.Character.FreezePosition = true;
        Game.FadeScreenOut(500);
        Script.Wait(500);
        Game.Player.Character.Position = new Vector3(this.ChairLoc.X + 2f, this.ChairLoc.Y, this.ChairLoc.Z);
        Game.Player.Character.Heading = 0.0f;
        Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
        Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
        Game.Player.Character.Task.ClearAnimation("anim@amb@office@laptops@male@var_c@base@", "base");
        Game.Player.Character.FreezePosition = false;
        Script.Wait(500);
        Game.FadeScreenIn(500);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2399.7f, 718.1f, 221.4f)) < 2.0 && Game.Player.Character.Alpha == 15)
      {
        Script.Wait(600);
        this.MainModDestroy();
        this.MainModRefresh();
      }
      if (this.SubbusinessBought != 1 || !this.PlayingMission || (this.missionnum != 1 || !((Entity) this.DropVehicle != (Entity) null)))
        return;
      if (this.DropVehicle.IsAlive)
      {
        if (this.DropVehicleBlip != (Blip) null)
          this.DropVehicleBlip.Position = this.DropVehicle.Position;
        foreach (Blip blip in this.DropBlip)
        {
          if (blip != (Blip) null && blip.Color == BlipColor.Blue && this.PointsBeenAt != this.DeliverPointsReq)
          {
            if ((double) World.GetDistance(Game.Player.Character.Position, blip.Position) < 200.0)
              World.DrawMarker(MarkerType.VerticalCylinder, blip.Position, Vector3.Zero, Vector3.Zero, new Vector3(4f, 6f, 4f), Color.DodgerBlue);
            if ((double) World.GetDistance(Game.Player.Character.Position, blip.Position) < 10.0 && blip.Color == BlipColor.Blue)
            {
              ++this.PointsBeenAt;
              blip.Color = BlipColor.White;
              blip.IsShortRange = true;
              blip.Remove();
              UI.Notify(this.GetHostName() + " Another package successfuly delivered, ~b~" + this.PointsBeenAt.ToString() + "~w~ delivered / ~b~" + (--this.DeliverPointsReqLeft).ToString() + "~w~ left, ~b~" + this.DeliverPointsReq.ToString() + "~w~ Deliveries needed");
            }
          }
        }
        if (this.PointsBeenAt == this.DeliverPointsReq)
        {
          UI.Notify("Office Assistant  :Ok selling all stock to buyers ");
          UI.Notify("Amount to Sell $" + this.amountToSell.ToString());
          UI.Notify("Stock Level " + this.StockAmount.ToString());
          Game.Player.Money += (int) this.amountToSell;
          UI.Notify(this.GetHostName() + " Good job out there we have been able to sell some stock, hopefully we did not lose to much!");
          this.amountToSell = 0.0f;
          this.StockAmount = 0;
          this.missionnum = 0;
          this.Droptype = 0;
          foreach (Blip blip in this.DropBlip)
          {
            if (blip != (Blip) null)
              blip.Remove();
          }
          if ((Entity) this.DropVehicle != (Entity) null)
            this.DropVehicle.Delete();
          if (this.DropVehicleBlip != (Blip) null)
            this.DropVehicleBlip.Remove();
          this.PlayingMission = false;
        }
      }
      if (!((Entity) this.DropVehicle != (Entity) null) || this.DropVehicle.IsAlive)
        return;
      foreach (Blip blip in this.DropBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      if ((Entity) this.DropVehicle != (Entity) null)
        this.DropVehicle.Delete();
      if (this.DropVehicleBlip != (Blip) null)
        this.DropVehicleBlip.Remove();
      UI.Notify(this.GetHostName() + " Dammit! we will have to start producing again and try to resell later!");
      this.amountToSell = 0.0f;
      this.StockAmount = 0;
      this.missionnum = 0;
      this.PlayingMission = false;
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    private void onKeyDown()
    {
      int subbusinessBought = this.SubbusinessBought;
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

      public Blip blip { get; set; }

      public int ID { get; set; }

      public int Index { get; set; }

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

      public int Price { get; set; }

      public int DiscountPrice { get; set; }

      public Blip blip { get; set; }

      public VehicleWarehouseData()
      {
      }

      public VehicleWarehouseData(
        int O,
        Vector3 wLoc,
        string Wn,
        string Wln,
        string Pictex,
        int p,
        int Dp,
        string Desc)
      {
        this.Owned = O;
        this.VehicleWarehouseCoords = wLoc;
        this.VehicleWarehouseName = Wn;
        this.VehicleWarehouseLocationName = Wln;
        this.VehicleWarehousePicTex = Pictex;
        this.VehicleWarehouseDescription = Desc;
        this.Price = p;
        this.DiscountPrice = Dp;
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
