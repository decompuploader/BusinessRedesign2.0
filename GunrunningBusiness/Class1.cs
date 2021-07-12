using GTA;
using GTA.Math;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GunRunningBusiness
{
  public class Class1 : Script
  {
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public float BusinessUpgradeIncreaseGain = 75000f;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    private ScriptSettings MainConfigFile;
    public int BusinessLocation = 0;
    public bool bought;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public int stockstimer;
    public int waittime;
    public int DisplayWait;
    public SaveCar SC = new SaveCar();
    private ScriptSettings Config;
    private Keys Key1;
    public Vector3 Entry = new Vector3(-3023.31f, 3334.41f, 9f);
    public Vector3 Exit;
    public Blip LabMarker;
    public string Style;
    public string Upgrade1;
    public string Upgrade2;
    public string Upgrade3;
    public int GunlockerBought;
    public int VehicleBayBought = 1;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private MenuPool modMenuPool2;
    private UIMenu mainMenu2;
    private MenuPool modMenuPool3;
    private UIMenu mainMenu3;
    private UIMenu MilitaryAsset;
    private UIMenu Extras;
    private UIMenu Customize;
    private UIMenu Use;
    private UIMenu methgarage;
    private UIMenu ProductStock;
    private UIMenu Buy;
    private UIMenu Missions;
    private UIMenu Customizer;
    public Vector3 MenuMarker = new Vector3(899.322f, -3224.98f, -99.5f);
    public Vector3 GunLockerpos = new Vector3(897.129f, -3217.97f, -99.5f);
    public Vector3 VehicleBaypos = new Vector3(1100.331f, -2999.446f, -40.1f);
    public Vector3 VehicleSpawn = new Vector3(853.661f, -3235.2f, -98f);
    public Vector3 CaddySpawn = new Vector3(881.958f, -3239.24f, -99f);
    public Vector3 AATrailerSpawn = new Vector3(852.24f, -3246.9f, -99f);
    public bool SelectedAAtrailer = false;
    public Vehicle Caddy;
    public Vehicle MillitaryAssetToRetrieve;
    public Vector3 OutsideVehicleSpawn = new Vector3(-3022f, 3336f, 11f);
    public float OutsideVehicleHeading = 0.0f;
    public string VehicleToRetrieve;
    public bool CurrentlyModifingVehicle;
    public Vehicle VehicleToModify;
    public Vehicle VehicleinUse;
    public Blip MilitaryVehicleBlip;
    public bool NotifyPlayer;
    public bool StartedVehicleSourcing;
    public bool Notifyplayer2;
    public int Trailersmall2Retrieved;
    public int Dune3Bought;
    public int APCBought;
    public int HalftrackBought;
    public int InsurgentBought;
    public int OppressorBought;
    public int TechnicalBought;
    public int NightSharkBought;
    public int TampaBought;
    private Blip Enemy;
    private Ped EnemyPed;
    private Vector3 EnemyLoc;
    public int assassinationmission;
    public int assassinationpayout;
    public bool EnemySetup;
    public int Chooseenemynum;
    public int MOCBought;
    public Vector3 Moc1Loc = new Vector3(850.214f, -3243.01f, -99.69f);
    public Vector3 Moc2Loc = new Vector3(843.214f, -3237.8f, -97.69f);
    public Vehicle Moc1;
    public Vehicle Moc2;
    public string carid;
    public Vector3 Vehicleloc;
    public System.Random VehicleLoc;
    public System.Random VehicleRan;
    public Vehicle VehicleMissioncar;
    public Vector3 VehicleLocation;
    public int Missionnum;
    public Blip DestoryVehicle;
    public Vehicle VehicleId;
    private System.Random RandomWanted;
    public bool setupdelivery;
    private System.Random randomwantedwait;
    public bool setupwantedfordelivery;
    public bool VehicleSetup;
    public UIMenu ShipmentDelivery;
    public Vector3 DropPoint = new Vector3(2700.28f, 3452.02f, 55.79f);
    public List<Vector3> STDropPointBC = new List<Vector3>()
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
    public List<Vector3> STDropPointLS = new List<Vector3>()
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
    public Blip DropPointBlip;
    public int DeliveryMission;
    public Vehicle DeliveryVehicle;
    public Vehicle[] EnemyVehicles;
    public bool SetupVehicles;
    public UIMenu AssetRecoveryMenu;
    public bool TriggeredWanted;
    public bool warnedplayer;
    public bool MarkerSetup;
    public bool hasgotvehicle;
    public float increaseGain;
    public UIMenu BikerRivallry;
    public Vehicle Bike1;
    public Blip Bike1Blip;
    public Vehicle Bike2;
    public Blip Bike2Blip;
    public Vehicle Bike3;
    public Blip Bike3Blip;
    public Vehicle Bike4;
    public Blip Bike4Blip;
    public Vehicle Bike5;
    public Blip Bike5Blip;
    public Vector3 PointA = new Vector3(993.299f, 3537.02f, 35f);
    public Vector3 PointB = new Vector3(1753.16f, 4568.55f, 39f);
    public Vector3 PointC = new Vector3(-1525.76f, 4696.35f, 42f);
    public Vector3 Spawn = new Vector3(2688.31f, 5127.53f, 45f);
    public Vector3 Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
    public Vector3 Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
    public Vector3 Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
    public Vector3 Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
    public Vector3 SpawnPos = new Vector3(-2033.25f, 4494.38f, 57f);
    public int vehiclemissionid;
    public bool VehicleSetup2;
    public UIMenu CoopElimination;
    public int Livery;
    public VehicleColor CabPrimary;
    public VehicleColor CabSecondary;
    public VehicleColor TrailerPrimary;
    public VehicleColor TrailerSecondary;
    public int Weapons;
    public string VehicleToUse;
    private ScriptSettings SetMocConfig;
    public bool IsInInterior;
    public AllStocks Allstocks;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    private UIMenu SpecialMissions;
    public Vehicle Trailer;
    public Vehicle[] Vehicles;
    public List<Ped> Peds;
    public Vector3 LeftProjSpawn;
    public Vector3 MiddileProjSpawn;
    public Vector3 RightProjSpawn;
    public int MissilesFired;
    public int BulletsFired;
    public int MissileTimer;
    public int GunTimer;
    public int LeftWait;
    public int RightWait;
    public Prop LeftMissileLauncher;
    public Prop RightMissileLauncher;
    public Vehicle Vulcan;
    public List<Prop> VulcanAntiMissileNode = new List<Prop>();
    public List<Prop> Props = new List<Prop>();
    public bool IsSittinginCeoSeat;
    public Vector3 ChairPos = new Vector3(908.62f, -3207.389f, -98.5f);
    public float P_Rotation = -164f;
    public bool StockSupplyRunMission;
    public bool SellStockDeliveryMission;
    public Vehicle StockVeh;
    public List<Vector3> SellStockLoc = new List<Vector3>();
    public int SellStockPointsBeenAt;
    public List<Prop> SellStockProps = new List<Prop>();
    public Prop SellStockProp1;
    public Prop SellStockProp2;
    public Prop SellStockProp3;
    public Prop SellStockProp4;
    public Prop SellStockProp5;
    public Prop SellStockProp6;
    public Prop SellStockProp7;
    public Prop SellStockProp8;
    public Prop SellStockProp9;
    public List<string> CrateProps = new List<string>()
    {
      "ex_prop_crate_xldiam",
      "ex_prop_crate_wlife_sc",
      "ex_prop_crate_wlife_bc",
      "ex_prop_crate_watch",
      "ex_prop_crate_tob_sc",
      "ex_prop_crate_tob_bc",
      "ex_prop_crate_shide",
      "ex_prop_crate_pharma_sc",
      "ex_prop_crate_pharma_bc",
      "ex_prop_crate_oegg",
      "ex_prop_crate_narc_sc",
      "ex_prop_crate_narc_bc",
      "ex_prop_crate_money_sc",
      "ex_prop_crate_money_bc",
      "ex_prop_crate_minig",
      "ex_prop_crate_med_sc",
      "ex_prop_crate_med_bc",
      "ex_prop_crate_jewels_sc",
      "ex_prop_crate_jewels_racks_sc",
      "ex_prop_crate_jewels_racks_bc",
      "ex_prop_crate_jewels_bc",
      "ex_prop_crate_highend_pharma_sc",
      "ex_prop_crate_highend_pharma_bc",
      "ex_prop_crate_gems_sc",
      "ex_prop_crate_gems_bc",
      "ex_prop_crate_furjacket_sc",
      "ex_prop_crate_furjacket_bc",
      "ex_prop_crate_freel",
      "ex_prop_crate_expl_sc",
      "ex_prop_crate_expl_bc",
      "ex_prop_crate_elec_sc",
      "ex_prop_crate_elec_bc",
      "ex_prop_crate_clothing_sc",
      "ex_prop_crate_clothing_bc",
      "ex_prop_crate_closed_sc",
      "ex_prop_crate_closed_rw",
      "ex_prop_crate_closed_mw",
      "ex_prop_crate_closed_ms",
      "ex_prop_crate_closed_bc",
      "ex_prop_crate_bull_sc_02",
      "ex_prop_crate_bull_bc_02",
      "ex_prop_crate_biohazard_sc",
      "ex_prop_crate_biohazard_bc",
      "ex_prop_crate_art_sc",
      "ex_prop_crate_art_bc",
      "ex_prop_crate_art_02_sc",
      "ex_prop_crate_art_02_bc",
      "ex_prop_crate_ammo_sc",
      "ex_prop_crate_ammo_bc"
    };
    public int AmttoDeliver;
    public List<Vector3> DropPointSupply = new List<Vector3>();
    public List<Blip> DropBlip = new List<Blip>();
    public List<Ped> SuppyGuards = new List<Ped>();
    public bool CreateSupplyVehicle;
    public bool GotVehicle;
    public int SupplyMission = 1;
    public int missionnum;
    public Blip SupplyGarageBlip;
    public Vector3 Sam1Loc;
    public Vector3 Sam2Loc;
    public Vector3 Sam3Loc;
    public Vehicle Sam1;
    public Vehicle Sam2;
    public Vehicle Sam3;
    public Blip Sam1blip;
    public Blip Sam2blip;
    public Blip Sam3blip;
    public Blip EndPointBlip;
    public Vector3 EndPointVec;
    public Blip Range;
    public List<Ped> PedsAI = new List<Ped>();
    public int Timer;
    public int Wave;
    public int EnemiesSpawned;
    public int Max;
    public Vector3 StartMarker = new Vector3(890f, -3173f, -98f);
    public bool HasBeenStarted;
    public long MoneyIncrease;
    public Vector3 Spawn1AI = new Vector3(911f, -3066f, -98f);
    public Vector3 Spawn2AI = new Vector3(912.5f, -3066f, -98f);
    public Vector3 Spawn3AI = new Vector3(914f, -3066f, -98f);
    public Vector3 Spawn4AI = new Vector3(915.5f, -3066f, -98f);
    public Vector3 Spawn5AI = new Vector3(917f, -3066f, -98f);
    private Vector3 LocationVar;
    private Vector3 LocationVar2;
    public float health;
    public int killed;
    public int MaxArmour = 400;
    public int MaxHp = 300;
    public int MinTimer;
    public bool on;
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
    private MenuPool MVmodMenuPool;
    private UIMenu MVmainMenu;
    public int MoneyVaultBought = 1;
    public float MoneyStored;
    public float Commission;
    public UIMenu MoneyMenu;
    public Vector3 MoneyStorageMarker = new Vector3(902f, -3182f, -98.5f);
    public int currentbank;
    public bool read;
    public Blip MVRange;
    public List<Vector3> IPpPostion = new List<Vector3>();
    public List<float> IPpRotation = new List<float>();
    public List<Ped> IPPeds = new List<Ped>();
    private ScriptSettings IPConfig;
    public bool IPCreatedPeds;
    public Vector3 CassidyCreekBunker = new Vector3(-387f, 4337f, 55f);
    public Vector3 ChumashBunker = new Vector3(-3157f, 1377f, 16f);
    public Vector3 IPClass1 = new Vector3(-3023.31f, 3334.41f, 9f);
    public Vector3 GreapseedBunker = new Vector3(1800.755f, 4705f, 39f);
    public Vector3 GSD1Bunker = new Vector3(850.755f, 3026f, 40f);
    public Vector3 GSD2Bunker = new Vector3(2103.755f, 3322f, 44f);
    public Vector3 GSD3Bunker = new Vector3(1570f, 2224f, 77f);
    public Vector3 GSD4Bunker = new Vector3(40.7f, 2927f, 54f);
    public Vector3 GSD5Bunker = new Vector3(2488f, 3167f, 48f);
    public Vector3 GSD6Bunker = new Vector3(494f, 3015f, 40f);
    public Vector3 PaletoBunker = new Vector3(-752.755f, 5944f, 19f);
    private int ttt;
    public int PropsMax;
    public List<Vector3> IPcPosition = new List<Vector3>();
    public List<Prop> IPProps = new List<Prop>();
    public List<string> CrateIds = new List<string>();
    public bool UseEXandOCcrates;
    public Prop Base;
    public Prop oldBase;
    public Prop Hatch;
    public Vector3 BunkerRot;
    public Vector3 CurrentBunker;
    public Vector3 SavePos;
    public float X;
    public float Z;
    public float Y;
    public float MinmumRot;
    public float MaxmumRot;
    public Prop ChairProp;
    public string ChairPropModel = "ex_prop_offchair_exec_01";
    public bool Explosive;
    public bool UseOldMarker = false;
    private ScriptSettings JuggConfig;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public VehicleHash ShipmentVehicleID;
    public string ShipmentName;
    public int LiveryColor;
    public bool SourcingMissionOn;
    public List<Ped> SourcingmissionPeds = new List<Ped>();
    public List<Vehicle> SourcingmissionVehicles = new List<Vehicle>();
    public int ChangeTimer;
    public bool MovedChair;
    public bool MovedChair2;
    public bool FirsTTIME;
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
    public int BNKr_ResupplySuccessRate = 0;
    public int BNKr_SellSuccess_BCTotal = 0;
    public int BNKr_SellSuccess_LSTotal = 0;
    public int BNKr_ResearchToComplete = 51;
    public int BNKr_FastTrackResearchPrice = 88000;
    public int BNKr_BCSellPrice = 234000;
    public int BNKr_LSSellPrice = 132000;
    public string BNKr_BunkerImage = "UA_BUNKER_TXD_0";
    public string BNKr_BunkerLocation = "Grand Senora Desert";
    public string BNKr_BunkerName = "Farmhouse Bunker";
    public string BNKr_Name = "HKH191";
    public int BNKr_Upgrade1FullPrice = 1550000;
    public int BNKr_Upgrade1DiscountPrice = 1450000;
    public int BNKr_Upgrade2FullPrice = 598000;
    public int BNKr_Upgrade2DiscountPrice = 572000;
    public int BNKr_Upgrade3FullPrice = 351000;
    public int BNKr_Upgrade3DiscountPrice = 345000;
    public int BNKr_MultiplierSell = 1;
    public int BNKr_MultiplierBuyCrate = 1;
    public int BNKr_MultiplierBuyFt = 1;
    public int BNKr_MultiplierUpg = 1;
    public int BNKr_BunkerOperationStatus = 0;
    public int BNKr_ResearchStatus = 0;
    public int BNKr_StockLevel = 0;
    public int BNKr_ResearchProgress = 0;
    public int BNKr_SuppliesLevel = 0;
    public int BNKr_TotalEarnings = 0;
    public int BNKr_TotalSales = 0;
    public int BNKr_ResupplySuccess = 0;
    public int BNKr_ResupplyFails = 0;
    public int BNKr_SellSuccess_BCSuccess = 0;
    public int BNKr_SellSuccess_BCFails = 0;
    public int BNKr_SellSuccess_LSSuccess = 0;
    public int BNKr_SellSuccess_LSFails = 0;
    public int BNKr_ResearchCompletedCrt = 0;
    public int BNKr_UnitsManufactured = 0;
    public int BNKr_StaffAssignment = 2;
    public int BNKr_Upgrade1Unlocked = 2;
    public int BNKr_Upgrade2Unlocked = 2;
    public int BNKr_Upgrade3Unlocked = 2;
    public int BNKr_CurrentResearch = 0;
    public List<Class1.ResearchItem> UnownedResearchItems = new List<Class1.ResearchItem>();
    public List<Class1.ResearchItem> ResearchItems = new List<Class1.ResearchItem>()
    {
      new Class1.ResearchItem(0, 0, false, "APC SAM Battery", "", "UA_UNLOCK_1", VehicleHash.APC, VehicleMod.Roof, 0),
      new Class1.ResearchItem(1, 0, false, "Juggernaut Suit", "", "UA_UNLOCK_2"),
      new Class1.ResearchItem(2, 0, false, "Halftrack 20mm Quad Autocannon", "", "UA_UNLOCK_3", VehicleHash.HalfTrack, VehicleMod.Roof, 0),
      new Class1.ResearchItem(3, 0, false, "Weaponized Tampa Dual Remote Minigun", "", "UA_UNLOCK_4", VehicleHash.Tampa3, VehicleMod.Roof, 0),
      new Class1.ResearchItem(4, 0, false, "Weaponized Tampa Rear-Firing Mortar", "", "UA_UNLOCK_5", VehicleHash.Tampa3, VehicleMod.RearBumper, 0),
      new Class1.ResearchItem(5, 0, false, "Weaponized Tampa Front Missile Launchers", "", "UA_UNLOCK_6", VehicleHash.Tampa3, VehicleMod.FrontBumper, 0),
      new Class1.ResearchItem(6, 0, false, "Weaponized Tampa Heavy Chassis Upgrade", "", "UA_UNLOCK_7", VehicleHash.Tampa3, VehicleMod.Frame, 2),
      new Class1.ResearchItem(7, 0, false, "Dune FAV 40mm Grenade Launcher", "", "UA_UNLOCK_8", VehicleHash.Dune3, VehicleMod.Roof, 0),
      new Class1.ResearchItem(8, 0, false, "Dune FAV 7.62mm Minigun", "", "UA_UNLOCK_9", VehicleHash.Dune3, VehicleMod.Roof, 1),
      new Class1.ResearchItem(9, 0, false, "Insurgent Pick-Up Custom .50 Cal Minigun", "", "UA_UNLOCK_10", VehicleHash.Insurgent3, VehicleMod.Roof, 0),
      new Class1.ResearchItem(10, 0, false, "Insurgent Pick-Up Custom Heavy Armor Plating", "", "UA_UNLOCK_11", VehicleHash.Insurgent3, VehicleMod.Frame, 2),
      new Class1.ResearchItem(11, 0, false, "Technical Custom 7.62mm Minigun", "", "UA_UNLOCK_12", VehicleHash.Technical3, VehicleMod.Roof, 0),
      new Class1.ResearchItem(12, 0, false, "Technical Custom Ram-bar", "", "UA_UNLOCK_13", VehicleHash.Technical3, VehicleMod.Grille, 3),
      new Class1.ResearchItem(13, 0, false, "Technical Custom Brute-bar", "", "UA_UNLOCK_14", VehicleHash.Technical3, VehicleMod.Grille, 4),
      new Class1.ResearchItem(14, 0, false, "Technical Custom Heavy Chassis Upgrade", "", "UA_UNLOCK_15", VehicleHash.Technical3, VehicleMod.Frame, 2),
      new Class1.ResearchItem(15, 0, false, "Oppressor Missile Launchers", "", "UA_UNLOCK_16", VehicleHash.Oppressor, VehicleMod.Roof, 0),
      new Class1.ResearchItem(16, 1, false, "Fractal Livery Set", "", "UA_UNLOCK_17", VehicleHash.Oppressor, VehicleMod.Livery, 15, 16),
      new Class1.ResearchItem(17, 1, false, "Digital Livery Set", "", "UA_UNLOCK_18", VehicleHash.Oppressor, VehicleMod.Livery, 17, 18, 19),
      new Class1.ResearchItem(18, 1, false, "Geometric Livery Set", "", "UA_UNLOCK_19", VehicleHash.Oppressor, VehicleMod.Livery, 11, 12, 13, 14),
      new Class1.ResearchItem(19, 1, false, "Nature Reserve Livery Set", "", "UA_UNLOCK_20", VehicleHash.Oppressor, VehicleMod.Livery, 9, 30, 31, 32, 33, 34, 26),
      new Class1.ResearchItem(20, 1, false, "Naval Battle Livery Set", "", "UA_UNLOCK_21", VehicleHash.Oppressor, VehicleMod.Livery, 10)
    };
    public List<Class1.ResearchItem> Vehicle_ResearchItems = new List<Class1.ResearchItem>()
    {
      new Class1.ResearchItem(0, 0, false, "APC SAM Battery", "", "UA_UNLOCK_1", VehicleHash.APC, VehicleMod.Roof, 0),
      new Class1.ResearchItem(16, 1, false, "Fractal Livery Set", "", "UA_UNLOCK_17", VehicleHash.APC, VehicleMod.Livery, 15, 16),
      new Class1.ResearchItem(17, 1, false, "Digital Livery Set", "", "UA_UNLOCK_18", VehicleHash.APC, VehicleMod.Livery, 17, 18, 19),
      new Class1.ResearchItem(18, 1, false, "Geometric Livery Set", "", "UA_UNLOCK_19", VehicleHash.APC, VehicleMod.Livery, 11, 12, 13, 14),
      new Class1.ResearchItem(19, 1, false, "Nature Reserve Livery Set", "", "UA_UNLOCK_20", VehicleHash.APC, VehicleMod.Livery, 9, 30, 31, 32, 33, 34, 26),
      new Class1.ResearchItem(20, 1, false, "Naval Battle Livery Set", "", "UA_UNLOCK_21", VehicleHash.APC, VehicleMod.Livery, 10),
      new Class1.ResearchItem(1, 0, false, "Juggernaut Suit", "", "UA_UNLOCK_2"),
      new Class1.ResearchItem(2, 0, false, "Halftrack 20mm Quad Autocannon", "", "UA_UNLOCK_3", VehicleHash.HalfTrack, VehicleMod.Roof, 0),
      new Class1.ResearchItem(16, 1, false, "Fractal Livery Set", "", "UA_UNLOCK_17", VehicleHash.HalfTrack, VehicleMod.Livery, 15, 16),
      new Class1.ResearchItem(17, 1, false, "Digital Livery Set", "", "UA_UNLOCK_18", VehicleHash.HalfTrack, VehicleMod.Livery, 17, 18, 19),
      new Class1.ResearchItem(18, 1, false, "Geometric Livery Set", "", "UA_UNLOCK_19", VehicleHash.HalfTrack, VehicleMod.Livery, 11, 12, 13, 14),
      new Class1.ResearchItem(19, 1, false, "Nature Reserve Livery Set", "", "UA_UNLOCK_20", VehicleHash.HalfTrack, VehicleMod.Livery, 9, 30, 31, 32, 33, 34, 26),
      new Class1.ResearchItem(20, 1, false, "Naval Battle Livery Set", "", "UA_UNLOCK_21", VehicleHash.HalfTrack, VehicleMod.Livery, 10),
      new Class1.ResearchItem(3, 0, false, "Weaponized Tampa Dual Remote Minigun", "", "UA_UNLOCK_4", VehicleHash.Tampa3, VehicleMod.Roof, 0),
      new Class1.ResearchItem(4, 0, false, "Weaponized Tampa Rear-Firing Mortar", "", "UA_UNLOCK_5", VehicleHash.Tampa3, VehicleMod.RearBumper, 0),
      new Class1.ResearchItem(5, 0, false, "Weaponized Tampa Front Missile Launchers", "", "UA_UNLOCK_6", VehicleHash.Tampa3, VehicleMod.FrontBumper, 0),
      new Class1.ResearchItem(6, 0, false, "Weaponized Tampa Heavy Chassis Upgrade", "", "UA_UNLOCK_7", VehicleHash.Tampa3, VehicleMod.Frame, 2),
      new Class1.ResearchItem(16, 1, false, "Fractal Livery Set", "", "UA_UNLOCK_17", VehicleHash.Tampa3, VehicleMod.Livery, 15, 16),
      new Class1.ResearchItem(17, 1, false, "Digital Livery Set", "", "UA_UNLOCK_18", VehicleHash.Tampa3, VehicleMod.Livery, 17, 18, 19),
      new Class1.ResearchItem(18, 1, false, "Geometric Livery Set", "", "UA_UNLOCK_19", VehicleHash.Tampa3, VehicleMod.Livery, 11, 12, 13, 14),
      new Class1.ResearchItem(19, 1, false, "Nature Reserve Livery Set", "", "UA_UNLOCK_20", VehicleHash.Tampa3, VehicleMod.Livery, 9, 30, 31, 32, 33, 34, 26),
      new Class1.ResearchItem(20, 1, false, "Naval Battle Livery Set", "", "UA_UNLOCK_21", VehicleHash.Tampa3, VehicleMod.Livery, 10),
      new Class1.ResearchItem(7, 0, false, "Dune FAV 40mm Grenade Launcher", "", "UA_UNLOCK_8", VehicleHash.Dune3, VehicleMod.Roof, 0),
      new Class1.ResearchItem(8, 0, false, "Dune FAV 7.62mm Minigun", "", "UA_UNLOCK_9", VehicleHash.Dune3, VehicleMod.Roof, 1),
      new Class1.ResearchItem(16, 1, false, "Fractal Livery Set", "", "UA_UNLOCK_17", VehicleHash.Dune3, VehicleMod.Livery, 15, 16),
      new Class1.ResearchItem(17, 1, false, "Digital Livery Set", "", "UA_UNLOCK_18", VehicleHash.Dune3, VehicleMod.Livery, 17, 18, 19),
      new Class1.ResearchItem(18, 1, false, "Geometric Livery Set", "", "UA_UNLOCK_19", VehicleHash.Dune3, VehicleMod.Livery, 11, 12, 13, 14),
      new Class1.ResearchItem(19, 1, false, "Nature Reserve Livery Set", "", "UA_UNLOCK_20", VehicleHash.Dune3, VehicleMod.Livery, 9, 30, 31, 32, 33, 34, 26),
      new Class1.ResearchItem(20, 1, false, "Naval Battle Livery Set", "", "UA_UNLOCK_21", VehicleHash.Dune3, VehicleMod.Livery, 10),
      new Class1.ResearchItem(9, 0, false, "Insurgent Pick-Up Custom .50 Cal Minigun", "", "UA_UNLOCK_10", VehicleHash.Insurgent3, VehicleMod.Roof, 0),
      new Class1.ResearchItem(10, 0, false, "Insurgent Pick-Up Custom Heavy Armor Plating", "", "UA_UNLOCK_11", VehicleHash.Insurgent3, VehicleMod.Frame, 2),
      new Class1.ResearchItem(16, 1, false, "Fractal Livery Set", "", "UA_UNLOCK_17", VehicleHash.Insurgent3, VehicleMod.Livery, 15, 16),
      new Class1.ResearchItem(17, 1, false, "Digital Livery Set", "", "UA_UNLOCK_18", VehicleHash.Insurgent3, VehicleMod.Livery, 17, 18, 19),
      new Class1.ResearchItem(18, 1, false, "Geometric Livery Set", "", "UA_UNLOCK_19", VehicleHash.Insurgent3, VehicleMod.Livery, 11, 12, 13, 14),
      new Class1.ResearchItem(19, 1, false, "Nature Reserve Livery Set", "", "UA_UNLOCK_20", VehicleHash.Insurgent3, VehicleMod.Livery, 9, 30, 31, 32, 33, 34, 26),
      new Class1.ResearchItem(20, 1, false, "Naval Battle Livery Set", "", "UA_UNLOCK_21", VehicleHash.Insurgent3, VehicleMod.Livery, 10),
      new Class1.ResearchItem(11, 0, false, "Technical Custom 7.62mm Minigun", "", "UA_UNLOCK_12", VehicleHash.Technical3, VehicleMod.Roof, 0),
      new Class1.ResearchItem(12, 0, false, "Technical Custom Ram-bar", "", "UA_UNLOCK_13", VehicleHash.Technical3, VehicleMod.Grille, 3),
      new Class1.ResearchItem(13, 0, false, "Technical Custom Brute-bar", "", "UA_UNLOCK_14", VehicleHash.Technical3, VehicleMod.Grille, 4),
      new Class1.ResearchItem(14, 0, false, "Technical Custom Heavy Chassis Upgrade", "", "UA_UNLOCK_15", VehicleHash.Technical3, VehicleMod.Frame, 2),
      new Class1.ResearchItem(16, 1, false, "Fractal Livery Set", "", "UA_UNLOCK_17", VehicleHash.Technical3, VehicleMod.Livery, 15, 16),
      new Class1.ResearchItem(17, 1, false, "Digital Livery Set", "", "UA_UNLOCK_18", VehicleHash.Technical3, VehicleMod.Livery, 17, 18, 19),
      new Class1.ResearchItem(18, 1, false, "Geometric Livery Set", "", "UA_UNLOCK_19", VehicleHash.Technical3, VehicleMod.Livery, 11, 12, 13, 14),
      new Class1.ResearchItem(19, 1, false, "Nature Reserve Livery Set", "", "UA_UNLOCK_20", VehicleHash.Technical3, VehicleMod.Livery, 9, 30, 31, 32, 33, 34, 26),
      new Class1.ResearchItem(20, 1, false, "Naval Battle Livery Set", "", "UA_UNLOCK_21", VehicleHash.Technical3, VehicleMod.Livery, 10),
      new Class1.ResearchItem(15, 0, false, "Oppressor Missile Launchers", "", "UA_UNLOCK_16", VehicleHash.Oppressor, VehicleMod.Roof, 0),
      new Class1.ResearchItem(16, 1, false, "Fractal Livery Set", "", "UA_UNLOCK_17", VehicleHash.Oppressor, VehicleMod.Livery, 15, 16),
      new Class1.ResearchItem(17, 1, false, "Digital Livery Set", "", "UA_UNLOCK_18", VehicleHash.Oppressor, VehicleMod.Livery, 17, 18, 19),
      new Class1.ResearchItem(18, 1, false, "Geometric Livery Set", "", "UA_UNLOCK_19", VehicleHash.Oppressor, VehicleMod.Livery, 11, 12, 13, 14),
      new Class1.ResearchItem(19, 1, false, "Nature Reserve Livery Set", "", "UA_UNLOCK_20", VehicleHash.Oppressor, VehicleMod.Livery, 9, 30, 31, 32, 33, 34, 26),
      new Class1.ResearchItem(20, 1, false, "Naval Battle Livery Set", "", "UA_UNLOCK_21", VehicleHash.Oppressor, VehicleMod.Livery, 10)
    };
    public int WarehouseSelected;
    public int SS_WarehousesOwned;
    public bool SupplyMissionOn;
    public int SupplyMissionID;
    public int SupplyMissionStage;
    public List<Vehicle> SupplyMissionVehicles = new List<Vehicle>();
    public List<Ped> SupplyMissionPeds = new List<Ped>();
    public List<Prop> SupplyMissionProps = new List<Prop>();
    public List<Blip> SupplyMissionBlips = new List<Blip>();
    public Vehicle SupplyMissionMainVehicle;
    public Vector3 AreaOffset;
    public Blip DeliverLocBlip1;
    public bool DeliveredtoLoc1;
    public Vector3 AreaOffset1;
    public Blip DeliverLocBlip2;
    public bool DeliveredtoLoc2;
    public Vector3 AreaOffset2;
    public Blip DeliverLocBlip3;
    public bool DeliveredtoLoc3;
    public Vector3 AreaOffset3;
    public Blip DeliverLocBlip4;
    public bool DeliveredtoLoc4;
    public Vector3 AreaOffset4;
    public int EnemySpawnSet;
    public bool WaitingForEnemySpawn;
    public int StockIncrease;
    public bool FirstSetStockIncrease;
    public int StockWait;
    public bool DisplayCrateStockIncrease = true;
    public Vehicle DeliveryVehicle1;
    public Vehicle DeliveryVehicle2;
    public Vehicle DeliveryVehicle3;
    public Vehicle DeliveryVehicle4;
    public bool DeliveredVehicle1;
    public bool DeliveredVehicle2;
    public bool DeliveredVehicle3;
    public bool DeliveredVehicle4;
    public int WheelType;
    public int Delivered;
    public int Deliveries;
    public Ped DeliverPed;
    public bool InMoc;
    public int MocBay = 0;
    public int MocBay2 = 0;
    public int MocBay3 = 0;
    public ScriptSettings CheckOcciConfig;
    public List<int> SmokeParticles = new List<int>();
    public int SellMission = 1;
    private int id;
    public bool NearLoc1;
    public bool NearLoc2;
    public bool NearLoc3;
    public bool NearLoc4;
    public Ped JuggernautPed;
    public Blip CrateBlip;
    public Blip JuggBlip;
    private string JuggColor;
    public Prop Crate;
    public Model OldCharacter;
    public bool UsingSuit;
    public WeaponTint Liv;
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
      this.CheckHostName("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
      this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
      this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      string str = "~" + this.Uicolour + "~";
      return this.HostName;
    }

    public Model RequestModel(string Name)
    {
      Model model = new Model(Name);
      model.Request(10000);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        return model;
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public Model RequestModel(VehicleHash Name)
    {
      Model model = new Model(Name);
      model.Request(10000);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        return model;
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public Model RequestModel(PedHash Name)
    {
      Model model = new Model(Name);
      model.Request(10000);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        return model;
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    private void LoadMain(string iniName)
    {
      try
      {
        this.MainConfigFile = ScriptSettings.Load(iniName);
        this.Blip_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        this.MarkerColorString = this.MainConfigFile.GetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        if (this.MarkerColorString.Contains("ARGB"))
        {
          string[] strArray = this.MarkerColorString.Split(new string[1]
          {
            "_"
          }, StringSplitOptions.None);
          this.MarkerColor = Color.FromArgb(int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
        }
        if (!this.MarkerColorString.Contains("ARGB"))
          this.MarkerColor = Color.FromName(this.MarkerColorString);
        this.BusinessUpgradeIncreaseGain = this.MainConfigFile.GetValue<float>("Prices", "BusinessUpgradeIncreaseGain", this.BusinessUpgradeIncreaseGain);
        this.BusinessUpgradeBasePrice = this.MainConfigFile.GetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
        this.IncreaseStockMinAmount = this.MainConfigFile.GetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
        this.IncreaseStockMaxAmount = this.MainConfigFile.GetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
        this.DecreaseStockMinAmount = this.MainConfigFile.GetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
        this.DecreaseStockMaxAmount = this.MainConfigFile.GetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
        this.BusinessLocation = this.MainConfigFile.GetValue<int>("Misc", "BusinessLocation", this.BusinessLocation);
        if (this.BusinessLocation == 0)
        {
          this.Entry = new Vector3(-3023.31f, 3334.41f, 9f);
          this.OutsideVehicleSpawn = new Vector3(-3022f, 3336f, 11f);
          this.OutsideVehicleHeading = -77f;
          this.BNKr_BunkerLocation = "Fort Zancudo";
          this.BNKr_BunkerName = "Lago Zancudo Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_9";
        }
        if (this.BusinessLocation == 1)
        {
          this.Entry = new Vector3(-387f, 4337f, 55f);
          this.OutsideVehicleSpawn = new Vector3(-387f, 4337f, 55f);
          this.OutsideVehicleHeading = -173f;
          this.BNKr_BunkerLocation = "Raton Canyon";
          this.BNKr_BunkerName = "Raton Canyon Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_8";
        }
        if (this.BusinessLocation == 2)
        {
          this.Entry = new Vector3(-3157f, 1377f, 16f);
          this.OutsideVehicleSpawn = new Vector3(-3156f, 1377f, 16f);
          this.OutsideVehicleHeading = -80f;
          this.BNKr_BunkerLocation = "Chumash ";
          this.BNKr_BunkerName = "Chumash Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_10";
        }
        if (this.BusinessLocation == 3)
        {
          this.Entry = new Vector3(1800.755f, 4705f, 39f);
          this.OutsideVehicleSpawn = new Vector3(1800.755f, 4705f, 39f);
          this.OutsideVehicleHeading = 90f;
          this.BNKr_BunkerLocation = "Grapeseed";
          this.BNKr_BunkerName = "Grapeseed Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_6";
        }
        if (this.BusinessLocation == 4)
        {
          this.Entry = new Vector3(850.755f, 3026f, 40f);
          this.OutsideVehicleSpawn = new Vector3(850.755f, 3026f, 41f);
          this.OutsideVehicleHeading = 0.0f;
          this.BNKr_BunkerLocation = "Grand Senora Desert";
          this.BNKr_BunkerName = "Grand Senora Desert Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_1";
        }
        if (this.BusinessLocation == 5)
        {
          this.Entry = new Vector3(2103.755f, 3322f, 44f);
          this.OutsideVehicleSpawn = new Vector3(2103.755f, 3322f, 44f);
          this.OutsideVehicleHeading = 119f;
          this.BNKr_BunkerLocation = "Grand Senora Desert";
          this.BNKr_BunkerName = "Smoke Tree Rd Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_4";
        }
        if (this.BusinessLocation == 6)
        {
          this.Entry = new Vector3(1570f, 2224f, 77f);
          this.OutsideVehicleSpawn = new Vector3(1570f, 2224f, 77f);
          this.OutsideVehicleHeading = -176f;
          this.BNKr_BunkerLocation = "Grand Senora Desert";
          this.BNKr_BunkerName = "Farm House Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_3";
        }
        if (this.BusinessLocation == 7)
        {
          this.Entry = new Vector3(40.7f, 2927f, 54f);
          this.OutsideVehicleSpawn = new Vector3(40.7f, 2927f, 54f);
          this.OutsideVehicleHeading = -161f;
          this.BNKr_BunkerLocation = "Grand Senora Desert";
          this.BNKr_BunkerName = "Route 68 Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_2";
        }
        if (this.BusinessLocation == 8)
        {
          this.Entry = new Vector3(2488f, 3167f, 48f);
          this.OutsideVehicleSpawn = new Vector3(2488f, 3167f, 48f);
          this.OutsideVehicleHeading = 14f;
          this.BNKr_BunkerLocation = "Grand Senora Desert";
          this.BNKr_BunkerName = "Thompson Scrapyard Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_5";
        }
        if (this.BusinessLocation == 9)
        {
          this.Entry = new Vector3(494f, 3015f, 40f);
          this.OutsideVehicleSpawn = new Vector3(494f, 3015f, 40f);
          this.OutsideVehicleHeading = -35f;
          this.BNKr_BunkerLocation = "Grand Senora Desert";
          this.BNKr_BunkerName = "Oil Fields Bunker";
          this.BNKr_BunkerImage = "UA_BUNKER_TXD_0";
        }
        if (this.BusinessLocation != 10)
          return;
        this.Entry = new Vector3(-752.755f, 5944f, 19f);
        this.OutsideVehicleSpawn = new Vector3(-752.755f, 5944f, 19f);
        this.OutsideVehicleHeading = -71f;
        this.BNKr_BunkerLocation = "Paleto Forest";
        this.BNKr_BunkerName = "Paleto Bay Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_7";
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    public void MainModRefresh()
    {
      UI.Notify("~g~ Found Refresh Sequence~w~");
      this.LoadMain("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
      this.BusinessLocation = this.MainConfigFile.GetValue<int>("Misc", "BusinessLocation", this.BusinessLocation);
      if (this.BusinessLocation == 0)
      {
        this.Entry = new Vector3(-3023.31f, 3334.41f, 9f);
        this.OutsideVehicleSpawn = new Vector3(-3022f, 3336f, 11f);
        this.OutsideVehicleHeading = -77f;
        this.BNKr_BunkerLocation = "Fort Zancudo";
        this.BNKr_BunkerName = "Lago Zancudo Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_9";
      }
      if (this.BusinessLocation == 1)
      {
        this.Entry = new Vector3(-387f, 4337f, 55f);
        this.OutsideVehicleSpawn = new Vector3(-387f, 4337f, 55f);
        this.OutsideVehicleHeading = -173f;
        this.BNKr_BunkerLocation = "Raton Canyon";
        this.BNKr_BunkerName = "Raton Canyon Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_8";
      }
      if (this.BusinessLocation == 2)
      {
        this.Entry = new Vector3(-3157f, 1377f, 16f);
        this.OutsideVehicleSpawn = new Vector3(-3156f, 1377f, 16f);
        this.OutsideVehicleHeading = -80f;
        this.BNKr_BunkerLocation = "Chumash ";
        this.BNKr_BunkerName = "Chumash Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_10";
      }
      if (this.BusinessLocation == 3)
      {
        this.Entry = new Vector3(1800.755f, 4705f, 39f);
        this.OutsideVehicleSpawn = new Vector3(1800.755f, 4705f, 39f);
        this.OutsideVehicleHeading = 90f;
        this.BNKr_BunkerLocation = "Grapeseed";
        this.BNKr_BunkerName = "Grapeseed Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_6";
      }
      if (this.BusinessLocation == 4)
      {
        this.Entry = new Vector3(850.755f, 3026f, 40f);
        this.OutsideVehicleSpawn = new Vector3(850.755f, 3026f, 41f);
        this.OutsideVehicleHeading = 0.0f;
        this.BNKr_BunkerLocation = "Grand Senora Desert";
        this.BNKr_BunkerName = "Grand Senora Desert Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_1";
      }
      if (this.BusinessLocation == 5)
      {
        this.Entry = new Vector3(2103.755f, 3322f, 44f);
        this.OutsideVehicleSpawn = new Vector3(2103.755f, 3322f, 44f);
        this.OutsideVehicleHeading = 119f;
        this.BNKr_BunkerLocation = "Grand Senora Desert";
        this.BNKr_BunkerName = "Smoke Tree Rd Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_4";
      }
      if (this.BusinessLocation == 6)
      {
        this.Entry = new Vector3(1570f, 2224f, 77f);
        this.OutsideVehicleSpawn = new Vector3(1570f, 2224f, 77f);
        this.OutsideVehicleHeading = -176f;
        this.BNKr_BunkerLocation = "Grand Senora Desert";
        this.BNKr_BunkerName = "Farm House Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_3";
      }
      if (this.BusinessLocation == 7)
      {
        this.Entry = new Vector3(40.7f, 2927f, 54f);
        this.OutsideVehicleSpawn = new Vector3(40.7f, 2927f, 54f);
        this.OutsideVehicleHeading = -161f;
        this.BNKr_BunkerLocation = "Grand Senora Desert";
        this.BNKr_BunkerName = "Route 68 Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_2";
      }
      if (this.BusinessLocation == 8)
      {
        this.Entry = new Vector3(2488f, 3167f, 48f);
        this.OutsideVehicleSpawn = new Vector3(2488f, 3167f, 48f);
        this.OutsideVehicleHeading = 14f;
        this.BNKr_BunkerLocation = "Grand Senora Desert";
        this.BNKr_BunkerName = "Thompson Scrapyard Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_5";
      }
      if (this.BusinessLocation == 9)
      {
        this.Entry = new Vector3(494f, 3015f, 40f);
        this.OutsideVehicleSpawn = new Vector3(494f, 3015f, 40f);
        this.OutsideVehicleHeading = -35f;
        this.BNKr_BunkerLocation = "Grand Senora Desert";
        this.BNKr_BunkerName = "Oil Fields Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_0";
      }
      if (this.BusinessLocation == 10)
      {
        this.Entry = new Vector3(-752.755f, 5944f, 19f);
        this.OutsideVehicleSpawn = new Vector3(-752.755f, 5944f, 19f);
        this.OutsideVehicleHeading = -71f;
        this.BNKr_BunkerLocation = "Paleto Forest";
        this.BNKr_BunkerName = "Paleto Bay Bunker";
        this.BNKr_BunkerImage = "UA_BUNKER_TXD_7";
      }
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.SetupMarker();
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
      this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      if (!(this.LabMarker != (Blip) null))
        return;
      if (this.purchaselvl > 0)
      {
        this.LabMarker.Color = this.Blip_Colour;
        this.LabMarker.Alpha = (int) byte.MaxValue;
      }
      if (this.purchaselvl == 0)
      {
        this.LabMarker.Color = BlipColor.White;
        this.LabMarker.Alpha = 0;
      }
    }

    public void MainModDestroy()
    {
      if (!(this.LabMarker != (Blip) null))
        return;
      this.LabMarker.Remove();
    }

    private void SetMocLoadIniFile(string iniName)
    {
      try
      {
        this.SetMocConfig = ScriptSettings.Load(iniName);
        this.VehicleToUse = this.SetMocConfig.GetValue<string>("Setup", "VehicleToUse", this.VehicleToUse);
        this.Livery = this.SetMocConfig.GetValue<int>("Setup", "Livery", this.Livery);
        this.Weapons = this.SetMocConfig.GetValue<int>("Setup", "Weapons", this.Weapons);
        this.CabPrimary = this.SetMocConfig.GetValue<VehicleColor>("CAB", "Primary", this.CabPrimary);
        this.CabSecondary = this.SetMocConfig.GetValue<VehicleColor>("CAB", "Secondary", this.CabPrimary);
        this.TrailerPrimary = this.SetMocConfig.GetValue<VehicleColor>("Trailer", "Primary", this.TrailerPrimary);
        this.TrailerSecondary = this.SetMocConfig.GetValue<VehicleColor>("Trailer", "Secondary", this.TrailerPrimary);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~:  SM Config.ini Failed To Load.");
      }
    }

    public Vector3 SelectSpawn()
    {
      Vector3 vector3 = new Vector3();
      System.Random random = new System.Random();
      if (random.Next(1, 13) == 1)
        vector3 = new Vector3(-1069.32f, -72.28f, 19f);
      if (random.Next(1, 13) == 2)
        vector3 = new Vector3(-1579.93f, -155.28f, 55f);
      if (random.Next(1, 13) == 3)
        vector3 = new Vector3(-711.74f, -28.28f, 37f);
      if (random.Next(1, 13) == 4)
        vector3 = new Vector3(6f, 253.58f, 109f);
      if (random.Next(1, 13) == 5)
        vector3 = new Vector3(703f, 32f, 84f);
      if (random.Next(1, 13) == 6)
        vector3 = new Vector3(1197f, -421.5f, 68f);
      if (random.Next(1, 13) == 7)
        vector3 = new Vector3(1257f, -1428f, 35f);
      if (random.Next(1, 13) == 8)
        vector3 = new Vector3(1264f, -2039f, 45f);
      if (random.Next(1, 13) == 9)
        vector3 = new Vector3(527f, -2052f, 28f);
      if (random.Next(1, 13) == 10)
        vector3 = new Vector3(-161f, -2087.8f, 26f);
      if (random.Next(1, 13) == 11)
        vector3 = new Vector3(756f, -1723f, 30f);
      if (random.Next(1, 13) == 12)
        vector3 = new Vector3(-816f, -2300f, 11f);
      if (random.Next(1, 13) == 13)
        vector3 = new Vector3(-1839f, 136f, 78f);
      return vector3;
    }

    public Model RequestModel(int Name)
    {
      Model model = new Model(Name);
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

    public void MVsetupMarker()
    {
      this.MVRange = World.CreateBlip(this.MoneyStorageMarker);
      this.MVRange.Sprite = BlipSprite.DollarSign;
      this.MVRange.Color = this.Blip_Colour;
      this.MVRange.Name = "Gunrunning Money Vault";
      this.MVRange.IsShortRange = true;
    }

    public void MVDeleteMarker()
    {
      if (!(this.MVRange != (Blip) null))
        return;
      this.MVRange.Remove();
    }

    public void SetupMoneyMenu()
    {
      List<object> items = new List<object>();
      items.Add((object) "1");
      items.Add((object) "2");
      items.Add((object) "3");
      items.Add((object) "4");
      items.Add((object) "5");
      items.Add((object) "6");
      items.Add((object) "7");
      items.Add((object) "8");
      items.Add((object) "9");
      items.Add((object) "10");
      UIMenu uiMenu = this.MVmodMenuPool.AddSubMenu(this.MoneyMenu, "Money Options");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem list5 = new UIMenuListItem("Vault: ", items, 0);
      uiMenu.AddItem((UIMenuItem) list5);
      UIMenuItem GetColor2 = new UIMenuItem("Change Bank Vault Number");
      uiMenu.AddItem(GetColor2);
      UIMenuItem WithDraw = new UIMenuItem("Withdraw");
      uiMenu.AddItem(WithDraw);
      UIMenuItem Deposit2 = new UIMenuItem("Deposit");
      uiMenu.AddItem(Deposit2);
      UIMenuItem balance = new UIMenuItem("Show Balance");
      uiMenu.AddItem(balance);
      UIMenuItem SFAB = new UIMenuItem("Show Total Account Balance");
      uiMenu.AddItem(SFAB);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == SFAB)
        {
          long num1 = 0;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 1.ToString() + "]", this.MoneyStored);
          long num2 = num1 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 2.ToString() + "]", this.MoneyStored);
          long num3 = num2 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 3.ToString() + "]", this.MoneyStored);
          long num4 = num3 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 4.ToString() + "]", this.MoneyStored);
          long num5 = num4 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 5.ToString() + "]", this.MoneyStored);
          long num6 = num5 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 6.ToString() + "]", this.MoneyStored);
          long num7 = num6 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 7.ToString() + "]", this.MoneyStored);
          long num8 = num7 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 8.ToString() + "]", this.MoneyStored);
          long num9 = num8 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 9.ToString() + "]", this.MoneyStored);
          long num10 = num9 + (long) this.MoneyStored;
          this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + 10.ToString() + "]", this.MoneyStored);
          UI.Notify("Money in Account ~g~$" + (num10 + (long) this.MoneyStored).ToString("N"));
        }
        if (item == GetColor2)
        {
          this.currentbank = list5.Index + 1;
          UI.Notify(this.GetHostName() + " Vault Changed to:  " + this.currentbank.ToString());
        }
        if (item == WithDraw)
          this.Withdrawl();
        if (item == Deposit2)
          this.Deposit();
        if (item != balance)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
        this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + this.currentbank.ToString() + "]", this.MoneyStored);
        UI.Notify(this.GetHostName() + " Moeny in Vault  ~b~" + this.currentbank.ToString() + "~w~, ~g~$" + this.MoneyStored.ToString("N"));
      });
    }

    private void Deposit()
    {
      string userInput = Game.GetUserInput(12);
      if (!(userInput != ""))
        return;
      if (int.Parse(userInput) <= Game.Player.Money)
      {
        this.MoneyStored = (float) int.Parse(userInput);
        Game.Player.Money -= int.Parse(userInput);
        float num = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + this.currentbank.ToString() + "]", this.MoneyStored);
        this.Config.SetValue<float>("ADDON2", "MONEYSTORED[" + this.currentbank.ToString() + "]", this.MoneyStored + num);
        this.Config.Save();
      }
      else
        UI.Notify(this.GetHostName() + " boss you dont have that amount of money to deposit: value: " + int.Parse(userInput).ToString());
    }

    private void Withdrawl()
    {
      string userInput = Game.GetUserInput(12);
      if (!(userInput != ""))
        return;
      if ((double) int.Parse(userInput) <= (double) this.MoneyStored)
      {
        this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + this.currentbank.ToString() + "]", this.MoneyStored) - (float) int.Parse(userInput);
        Game.Player.Money += int.Parse(userInput);
        this.Config.SetValue<float>("ADDON2", "MONEYSTORED[" + this.currentbank.ToString() + "]", this.MoneyStored);
        this.Config.Save();
      }
      else
        UI.Notify(this.GetHostName() + " boss you dont have that amount of money stored to withdraw, value: " + this.MoneyStored.ToString());
    }

    public void SetupPropSpawns()
    {
      this.IPcPosition.Add(new Vector3(928.787f, -3240.357f, -99.2f));
      this.IPcPosition.Add(new Vector3(918.5767f, -3233.527f, -99.2f));
      this.IPcPosition.Add(new Vector3(918.8289f, -3230.965f, -99.2f));
      this.IPcPosition.Add(new Vector3(917.7759f, -3228.698f, -99.2f));
      this.IPcPosition.Add(new Vector3(916.2993f, -3226.778f, -99.2f));
      this.IPcPosition.Add(new Vector3(917.0598f, -3221.834f, -99.2f));
      this.IPcPosition.Add(new Vector3(916.2154f, -3218.953f, -99.2f));
      this.IPcPosition.Add(new Vector3(915.1477f, -3217.008f, -99.2f));
      this.IPcPosition.Add(new Vector3(914.0033f, -3212.967f, -99.2f));
      this.IPcPosition.Add(new Vector3(916.2867f, -3212.837f, -99.2f));
      this.IPcPosition.Add(new Vector3(918.7871f, -3212.301f, -99.2f));
      this.IPcPosition.Add(new Vector3(919.7648f, -3210.528f, -99.2f));
      this.IPcPosition.Add(new Vector3(920.4871f, -3207.966f, -99.2f));
      this.IPcPosition.Add(new Vector3(920.8289f, -3205.748f, -99.2f));
      this.IPcPosition.Add(new Vector3(921.6584f, -3203.711f, -99.2f));
      this.IPcPosition.Add(new Vector3(917.6918f, -3201.486f, -99.2f));
      this.IPcPosition.Add(new Vector3(917.5944f, -3199.624f, -99.2f));
      this.IPcPosition.Add(new Vector3(917.6058f, -3197.552f, -99.2f));
      this.IPcPosition.Add(new Vector3(917.407f, -3195.495f, -99.2f));
      this.IPcPosition.Add(new Vector3(918.9667f, -3195.29f, -99.2f));
      this.IPcPosition.Add(new Vector3(920.4226f, -3194.858f, -99.2f));
      this.IPcPosition.Add(new Vector3(924.5738f, -3196.244f, -99.2f));
      this.IPcPosition.Add(new Vector3(925.5612f, -3196.713f, -99.2f));
      this.IPcPosition.Add(new Vector3(925.9111f, -3196.921f, -99.2f));
      this.IPcPosition.Add(new Vector3(928.1417f, -3196.892f, -99.2f));
      this.IPcPosition.Add(new Vector3(930.0519f, -3197.042f, -99.2f));
      this.IPcPosition.Add(new Vector3(932.6321f, -3196.505f, -99.2f));
      this.IPcPosition.Add(new Vector3(934.2321f, -3194.872f, -99.2f));
      this.IPcPosition.Add(new Vector3(936.2353f, -3193.049f, -99.2f));
      this.IPcPosition.Add(new Vector3(935.7553f, -3193.034f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.6017f, -3193.113f, -99.2f));
      this.IPcPosition.Add(new Vector3(939.2759f, -3192.988f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.3411f, -3192.505f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.3411f, -3192.505f, -99.2f));
      this.IPcPosition.Add(new Vector3(944.0327f, -3192.571f, -99.2f));
      this.IPcPosition.Add(new Vector3(944.4015f, -3194.941f, -99.2f));
      this.IPcPosition.Add(new Vector3(936.804f, -3197.543f, -99.2f));
      this.IPcPosition.Add(new Vector3(934.8651f, -3197.738f, -99.2f));
      this.IPcPosition.Add(new Vector3(932.9659f, -3197.702f, -99.2f));
      this.IPcPosition.Add(new Vector3(931.6348f, -3197.642f, -99.2f));
      this.IPcPosition.Add(new Vector3(930.2621f, -3197.564f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.6904f, -3199.032f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.752f, -3200.878f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7339f, -3202.698f, -99.2f));
      this.IPcPosition.Add(new Vector3(931.4281f, -3203.285f, -99.2f));
      this.IPcPosition.Add(new Vector3(933.2151f, -3202.827f, -99.2f));
      this.IPcPosition.Add(new Vector3(936.6198f, -3202.421f, -99.2f));
      this.IPcPosition.Add(new Vector3(936.649f, -3202.489f, -99.2f));
      this.IPcPosition.Add(new Vector3(938.3192f, -3202.735f, -99.2f));
      this.IPcPosition.Add(new Vector3(944.8453f, -3207.935f, -99.2f));
      this.IPcPosition.Add(new Vector3(945.2711f, -3212.796f, -99.2f));
      this.IPcPosition.Add(new Vector3(945.2679f, -3212.818f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.2468f, -3215.549f, -99.2f));
      this.IPcPosition.Add(new Vector3(940.3831f, -3215.735f, -99.2f));
      this.IPcPosition.Add(new Vector3(938.0397f, -3215.78f, -99.2f));
      this.IPcPosition.Add(new Vector3(938.296f, -3215.787f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.7855f, -3213.349f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.517f, -3211.155f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.494f, -3208.818f, -99.2f));
      this.IPcPosition.Add(new Vector3(947.8777f, -3228.87f, -99.2f));
      this.IPcPosition.Add(new Vector3(947.6162f, -3230.994f, -99.2f));
      this.IPcPosition.Add(new Vector3(947.8896f, -3232.946f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.2978f, -3234.677f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.4362f, -3236.42f, -99.2f));
      this.IPcPosition.Add(new Vector3(946.0728f, -3240.197f, -99.2f));
      this.IPcPosition.Add(new Vector3(944.2456f, -3240.048f, -99.2f));
      this.IPcPosition.Add(new Vector3(923.123f, -3207.693f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.4594f, -3240.178f, -99.2f));
      this.IPcPosition.Add(new Vector3(941.0333f, -3240.299f, -99.2f));
      this.IPcPosition.Add(new Vector3(938.8956f, -3240.107f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.1875f, -3240.042f, -99.2f));
      this.IPcPosition.Add(new Vector3(935.5846f, -3239.931f, -99.2f));
      this.IPcPosition.Add(new Vector3(933.7335f, -3239.842f, -99.2f));
      this.IPcPosition.Add(new Vector3(932.2042f, -3239.769f, -99.2f));
      this.IPcPosition.Add(new Vector3(930.5182f, -3239.879f, -99.2f));
      this.IPcPosition.Add(new Vector3(921.7933f, -3219.167f, -99.2f));
      this.IPcPosition.Add(new Vector3(921.7654f, -3219.125f, -99.2f));
      this.IPcPosition.Add(new Vector3(921.0737f, -3220.979f, -99.2f));
      this.IPcPosition.Add(new Vector3(921.992f, -3222.852f, -99.2f));
      this.IPcPosition.Add(new Vector3(920.8765f, -3224.505f, -99.2f));
      this.IPcPosition.Add(new Vector3(923.7269f, -3226.658f, -99.2f));
      this.IPcPosition.Add(new Vector3(925.2927f, -3226.407f, -99.2f));
      this.IPcPosition.Add(new Vector3(926.8829f, -3226.295f, -99.2f));
      this.IPcPosition.Add(new Vector3(926.8821f, -3226.295f, -99.2f));
      this.IPcPosition.Add(new Vector3(928.8093f, -3225.801f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.3098f, -3223.866f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7457f, -3222.045f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7344f, -3222.05f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7344f, -3222.05f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7344f, -3222.05f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7344f, -3222.05f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7344f, -3222.05f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7344f, -3222.05f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7344f, -3222.05f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.7344f, -3222.05f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.9103f, -3220.264f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.9579f, -3218.702f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.4021f, -3216.945f, -99.2f));
      this.IPcPosition.Add(new Vector3(927.4073f, -3216.278f, -99.2f));
      this.IPcPosition.Add(new Vector3(925.6667f, -3215.671f, -99.2f));
      this.IPcPosition.Add(new Vector3(923.6161f, -3215.785f, -99.2f));
      this.IPcPosition.Add(new Vector3(921.6724f, -3215.699f, -99.2f));
      this.IPcPosition.Add(new Vector3(928.1303f, -3210.48f, -99.2f));
      this.IPcPosition.Add(new Vector3(927.9536f, -3208.744f, -99.2f));
      this.IPcPosition.Add(new Vector3(927.9141f, -3206.548f, -99.2f));
      this.IPcPosition.Add(new Vector3(926.5017f, -3204.635f, -99.2f));
      this.IPcPosition.Add(new Vector3(924.79f, -3205.222f, -99.2f));
      this.IPcPosition.Add(new Vector3(939.0565f, -3218.331f, -99.2f));
      this.IPcPosition.Add(new Vector3(941.1657f, -3218.18f, -99.2f));
      this.IPcPosition.Add(new Vector3(941.1663f, -3218.18f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9301f, -3215.537f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(942.9328f, -3215.533f, -99.2f));
      this.IPcPosition.Add(new Vector3(945.148f, -3214.906f, -99.2f));
      this.IPcPosition.Add(new Vector3(945.1569f, -3214.899f, -99.2f));
      this.IPcPosition.Add(new Vector3(945.1569f, -3214.899f, -99.2f));
      this.IPcPosition.Add(new Vector3(945.1569f, -3214.899f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.6087f, -3216.068f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.7267f, -3217.824f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.5392f, -3219.663f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.4823f, -3221.554f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.2568f, -3223.282f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.5538f, -3224.921f, -99.2f));
      this.IPcPosition.Add(new Vector3(950.4805f, -3226.663f, -99.2f));
      this.IPcPosition.Add(new Vector3(945.3636f, -3222.312f, -99.2f));
      this.IPcPosition.Add(new Vector3(943.4683f, -3222.422f, -99.2f));
      this.IPcPosition.Add(new Vector3(941.6592f, -3223.1f, -99.2f));
      this.IPcPosition.Add(new Vector3(939.9389f, -3223.192f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.9515f, -3221.665f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.2198f, -3219.559f, -99.2f));
      this.IPcPosition.Add(new Vector3(933.5025f, -3226.506f, -99.2f));
      this.IPcPosition.Add(new Vector3(935.3034f, -3226.577f, -99.2f));
      this.IPcPosition.Add(new Vector3(935.3034f, -3226.577f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.4033f, -3226.592f, -99.2f));
      this.IPcPosition.Add(new Vector3(921.9548f, -3238.935f, -99.2f));
      this.IPcPosition.Add(new Vector3(920.2654f, -3238.806f, -99.2f));
      this.IPcPosition.Add(new Vector3(918.1668f, -3238.544f, -99.2f));
      this.IPcPosition.Add(new Vector3(918.1668f, -3238.544f, -99.2f));
      this.IPcPosition.Add(new Vector3(916.33f, -3238.496f, -99.2f));
      this.IPcPosition.Add(new Vector3(926.923f, -3235.311f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.0695f, -3235.383f, -99.2f));
      this.IPcPosition.Add(new Vector3(931.0109f, -3235.235f, -99.2f));
      this.IPcPosition.Add(new Vector3(931.0204f, -3235.245f, -99.2f));
      this.IPcPosition.Add(new Vector3(933.823f, -3234.21f, -99.2f));
      this.IPcPosition.Add(new Vector3(935.438f, -3233.404f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.3343f, -3233.041f, -99.2f));
      this.IPcPosition.Add(new Vector3(937.3333f, -3233.041f, -99.2f));
      this.IPcPosition.Add(new Vector3(939.0501f, -3232.486f, -99.2f));
      this.IPcPosition.Add(new Vector3(939.5822f, -3230.508f, -99.2f));
      this.IPcPosition.Add(new Vector3(944.3725f, -3199.837f, -99.2f));
      this.IPcPosition.Add(new Vector3(944.3696f, -3199.841f, -99.2f));
      this.IPcPosition.Add(new Vector3(946.1682f, -3199.769f, -99.2f));
      this.IPcPosition.Add(new Vector3(946.1682f, -3199.769f, -99.2f));
      this.IPcPosition.Add(new Vector3(946.1682f, -3199.769f, -99.2f));
      this.IPcPosition.Add(new Vector3(948.2677f, -3199.814f, -99.2f));
      this.IPcPosition.Add(new Vector3(948.99f, -3201.634f, -99.2f));
      this.IPcPosition.Add(new Vector3(948.5519f, -3203.591f, -99.2f));
      this.IPcPosition.Add(new Vector3(946.8632f, -3204.868f, -99.2f));
      this.IPcPosition.Add(new Vector3(939.2069f, -3200.457f, -99.2f));
      this.IPcPosition.Add(new Vector3(925.6222f, -3230.263f, -99.2f));
      this.IPcPosition.Add(new Vector3(927.4003f, -3229.859f, -99.2f));
      this.IPcPosition.Add(new Vector3(927.3935f, -3229.852f, -99.2f));
      this.IPcPosition.Add(new Vector3(927.3935f, -3229.852f, -99.2f));
      this.IPcPosition.Add(new Vector3(927.5007f, -3229.878f, -99.2f));
      this.IPcPosition.Add(new Vector3(929.553f, -3229.819f, -99.2f));
      this.IPcPosition.Add(new Vector3(923.6625f, -3211.516f, -99.2f));
      this.IPcPosition.Add(new Vector3(923.6709f, -3211.542f, -99.2f));
      this.IPcPosition.Add(new Vector3(922.8199f, -3209.777f, -99.2f));
      this.IPcPosition.Add(new Vector3(923.1234f, -3207.693f, -99.2f));
      this.IPcPosition.Add(new Vector3(877.1562f, -3239.874f, -98.04729f));
      this.IPcPosition.Add(new Vector3(875.6797f, -3239.924f, -98.0137f));
      this.IPcPosition.Add(new Vector3(873.5574f, -3240.052f, -98.04721f));
      this.IPcPosition.Add(new Vector3(863.6418f, -3248.14f, -98.29435f));
      this.IPcPosition.Add(new Vector3(865.5265f, -3248.118f, -98.29444f));
      this.IPcPosition.Add(new Vector3(867.7203f, -3248.037f, -98.29324f));
      this.IPcPosition.Add(new Vector3(869.6429f, -3248.034f, -98.2918f));
      this.IPcPosition.Add(new Vector3(871.6057f, -3248.164f, -98.29199f));
      this.IPcPosition.Add(new Vector3(871.6029f, -3248.162f, -98.29199f));
      this.IPcPosition.Add(new Vector3(873.675f, -3248.246f, -98.29214f));
      this.IPcPosition.Add(new Vector3(875.764f, -3248.117f, -98.2909f));
      this.IPcPosition.Add(new Vector3(875.7011f, -3248.154f, -98.29098f));
      this.IPcPosition.Add(new Vector3(877.7568f, -3248.153f, -98.29029f));
      this.IPcPosition.Add(new Vector3(879.8864f, -3248.161f, -98.2894f));
      this.IPcPosition.Add(new Vector3(866.3953f, -3236.461f, -98.29399f));
      this.IPcPosition.Add(new Vector3(866.3953f, -3236.461f, -98.29399f));
      this.IPcPosition.Add(new Vector3(866.3964f, -3238.699f, -98.29338f));
      this.IPcPosition.Add(new Vector3(866.4697f, -3240.756f, -98.2928f));
      this.IPcPosition.Add(new Vector3(866.4929f, -3242.808f, -98.2923f));
    }

    public void IPCrateProps()
    {
      this.CrateIds.Add("gr_prop_gr_crates_pistols_01a");
      this.CrateIds.Add("gr_prop_gr_crates_rifles_01a");
      this.CrateIds.Add("gr_prop_gr_crates_rifles_02a");
      this.CrateIds.Add("gr_prop_gr_crates_rifles_03a");
      this.CrateIds.Add("gr_prop_gr_crates_rifles_04a");
      this.CrateIds.Add("gr_prop_gr_crates_sam_01a.ydr");
      this.CrateIds.Add("gr_prop_gr_crates_weapon_mix_01a");
      this.CrateIds.Add("gr_prop_gr_crates_weapon_mix_01b");
      if (!this.UseEXandOCcrates)
        return;
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
      this.CrateIds.Add("ex_prop_crate_minig.");
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
        Pos = new Vector3(Pos.X, Pos.Y, -99.2f);
        this.IPProps.Add(World.CreateProp(model, Pos, Rot, true, false));
      }
      model.MarkAsNoLongerNeeded();
    }

    public void IPSpawnProp(string Crate, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Crate);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        Pos = new Vector3(Pos.X, Pos.Y, Pos.Z);
        Prop prop = World.CreateProp(model, Pos, Rot, true, false);
        Game.Player.Character.Position = prop.Position;
        this.IPProps.Add(prop);
      }
      model.MarkAsNoLongerNeeded();
    }

    public void SpawnBase(string Crate, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Crate);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        if ((Entity) this.Base != (Entity) null)
          this.Base.Delete();
        Pos = new Vector3(Pos.X, Pos.Y, Pos.Z);
        this.Base = World.CreateProp(model, Pos, Rot, true, false);
      }
      model.MarkAsNoLongerNeeded();
    }

    public void SpawnHatch(string Crate, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Crate);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        if ((Entity) this.Hatch != (Entity) null)
          this.Hatch.Delete();
        Pos = new Vector3(Pos.X, Pos.Y, Pos.Z);
        this.Hatch = World.CreateProp(model, Pos, Rot, true, false);
      }
      model.MarkAsNoLongerNeeded();
    }

    public void CreateGRCratesInBunker()
    {
    }

    public void DeleteGRCratesInBunker()
    {
      foreach (Prop ipProp in this.IPProps)
      {
        if ((Entity) ipProp != (Entity) null)
          ipProp.Delete();
      }
    }

    private void IPLoadIniFile2(string iniName)
    {
      try
      {
        this.IPConfig = ScriptSettings.Load(iniName);
        this.stockscount = this.IPConfig.GetValue<int>("Setup", "stockslevel", this.stockscount);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~:IP Config.ini Failed To Load.");
      }
    }

    private void IPLoadIniFile(string iniName)
    {
      try
      {
        this.IPConfig = ScriptSettings.Load(iniName);
        this.Style = this.IPConfig.GetValue<string>("Design", "Style", this.Style);
        this.Upgrade1 = this.IPConfig.GetValue<string>("Design", "Upgrade1", this.Upgrade1);
        this.Upgrade2 = this.IPConfig.GetValue<string>("Design", "Upgrade2", this.Upgrade2);
        this.Upgrade3 = this.IPConfig.GetValue<string>("Design", "Upgrade3", this.Upgrade3);
        this.PropsMax = this.IPConfig.GetValue<int>("Design", "PropsMax", this.PropsMax);
        this.UseEXandOCcrates = this.IPConfig.GetValue<bool>("Design", "UseEXandOCcrates", this.UseEXandOCcrates);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~:IP Config.ini Failed To Load.");
      }
    }

    public void SetupPeds()
    {
      this.IPpPostion.Add(new Vector3(888.48f, -3212.05f, -99f));
      this.IPpRotation.Add(-176f);
      this.IPpPostion.Add(new Vector3(884.48f, -3207.05f, -99f));
      this.IPpRotation.Add(91f);
      this.IPpPostion.Add(new Vector3(884.946f, -3200.84f, -99f));
      this.IPpRotation.Add(45f);
      this.IPpPostion.Add(new Vector3(894.946f, -3200.84f, -99f));
      this.IPpRotation.Add(104f);
      this.IPpPostion.Add(new Vector3(892.946f, -3204.84f, -99f));
      this.IPpRotation.Add(49f);
      this.IPpPostion.Add(new Vector3(902.2572f, -3215.496f, -99f));
      this.IPpRotation.Add(-5f);
      this.IPpPostion.Add(new Vector3(908.024f, -3211.529f, -99f));
      this.IPpRotation.Add(17f);
      this.IPpPostion.Add(new Vector3(906.0095f, -3230.486f, -99f));
      this.IPpRotation.Add(161f);
      this.IPpPostion.Add(new Vector3(915.2809f, -3236.846f, -99f));
      this.IPpRotation.Add(90f);
      this.IPpPostion.Add(new Vector3(894.8354f, -3235.303f, -98f));
      this.IPpRotation.Add(156f);
      this.IPpPostion.Add(new Vector3(871.7452f, -3239.418f, -98f));
      this.IPpRotation.Add(-173f);
      this.IPpPostion.Add(new Vector3(897.8397f, -3178.108f, -98f));
      this.IPpRotation.Add(79f);
      this.IPpPostion.Add(new Vector3(886.8f, -3189.219f, -99f));
      this.IPpRotation.Add(-170f);
      this.IPpPostion.Add(new Vector3(892.97f, -3175.809f, -98.5f));
      this.IPpRotation.Add(-34f);
      this.IPpPostion.Add(new Vector3(894.2885f, -3175.816f, -98.5f));
      this.IPpRotation.Add(17f);
      this.IPpPostion.Add(new Vector3(0.0f, 0.0f, 0.0f));
      this.IPpRotation.Add(-158f);
      this.IPpPostion.Add(new Vector3(901.857f, -3205.218f, -97.6f));
      this.IPpRotation.Add(165f);
      this.IPpPostion.Add(new Vector3(871.9813f, -3185.881f, -98.5f));
      this.IPpRotation.Add(-81f);
    }

    public void LoadPeds()
    {
    }

    public void setupMarker()
    {
      this.Range = World.CreateBlip(this.StartMarker);
      this.Range.Sprite = BlipSprite.MachineGun;
      this.Range.Color = this.Blip_Colour;
      this.Range.Name = "Gun Range";
      this.Range.IsShortRange = true;
    }

    public void DeleteMarker()
    {
      if (!(this.Range != (Blip) null))
        return;
      this.Range.Remove();
    }

    public Vector3 Location()
    {
      int num = new System.Random().Next(1, 1500);
      if (num < 100)
        this.LocationVar = this.Spawn1AI;
      if (num > 100 && num < 200)
        this.LocationVar = this.Spawn2AI;
      if (num > 200 && num < 300)
        this.LocationVar = this.Spawn3AI;
      if (num > 300 && num < 400)
        this.LocationVar = this.Spawn4AI;
      if (num > 400 && num < 500)
        this.LocationVar = this.Spawn5AI;
      if (num > 500 && num < 600)
        this.LocationVar = new Vector3(903f, -3109f, -98f);
      if (num > 600 && num < 700)
        this.LocationVar = new Vector3(904.5f, -3109f, -98f);
      if (num > 700 && num < 800)
        this.LocationVar = new Vector3(906f, -3109f, -98f);
      if (num > 800 && num < 900)
        this.LocationVar = new Vector3(908f, -3109f, -98f);
      if (num > 900 && num < 1000)
        this.LocationVar = new Vector3(909.5f, -3109f, -98f);
      if (num > 1000 && num < 1100)
        this.LocationVar = new Vector3(906f, -3129f, -98f);
      if (num > 1100 && num < 1200)
        this.LocationVar = new Vector3(905f, -3129f, -98f);
      if (num > 1200 && num < 1300)
        this.LocationVar = new Vector3(903f, -3129f, -98f);
      if (num > 1300 && num < 1400)
        this.LocationVar = new Vector3(901f, -3129f, -98f);
      if (num > 1400 && num < 1500)
        this.LocationVar = new Vector3(900f, -3129f, -98f);
      UI.Notify("Loc " + this.LocationVar.ToString());
      return this.LocationVar;
    }

    public Vector3 FinalLocation()
    {
      int num = new System.Random().Next(1, 500);
      if (num < 100)
        this.LocationVar2 = new Vector3(899f, -3172f, -97f);
      if (num > 100 && num < 200)
        this.LocationVar2 = new Vector3(897f, -3172f, -97f);
      if (num > 200 && num < 300)
        this.LocationVar2 = new Vector3(895f, -3172f, -97f);
      if (num > 300 && num < 400)
        this.LocationVar2 = new Vector3(893f, -3172f, -97f);
      if (num > 400 && num < 500)
        this.LocationVar2 = new Vector3(891f, -3172f, -97f);
      return this.LocationVar2;
    }

    public void SpawnEnemy()
    {
      if (this.EnemiesSpawned >= this.Max)
        return;
      Ped ped1 = World.CreatePed(this.RequestModel(PedHash.Zombie01), this.Location());
      ped1.Armor = this.MaxArmour;
      ped1.Health = this.MaxHp;
      Ped ped2 = ped1;
      ped1.IsPersistent = true;
      int num1 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
      Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num1);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
      ped1.Task.RunTo(this.FinalLocation(), true, 9999);
      Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
      ped1.CanWrithe = false;
      this.PedsAI.Add(ped1);
      int num2 = new System.Random().Next(1, 1000);
      if (this.Wave >= 1 && this.Wave <= 5 && num2 < 50)
        ped1.CanSufferCriticalHits = false;
      if (this.Wave >= 5 && this.Wave <= 10 && num2 < 200)
        ped1.CanSufferCriticalHits = false;
      if (this.Wave >= 10 && this.Wave <= 15 && num2 < 300)
        ped1.CanSufferCriticalHits = false;
      if (this.Wave >= 15 && this.Wave <= 20 && num2 < 400)
        ped1.CanSufferCriticalHits = false;
      if (this.Wave >= 20 && this.Wave <= 25 && num2 < 500)
        ped1.CanSufferCriticalHits = false;
    }

    public void SpawnProp(string Crate, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Crate);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        Pos = new Vector3(Pos.X, Pos.Y, Pos.Z);
        Prop prop = World.CreateProp(model, Pos, Rot, true, false);
        prop.HasCollision = true;
        prop.IsInvincible = true;
        this.Props.Add(prop);
      }
      model.MarkAsNoLongerNeeded();
    }

    private void FireGun(Vector3 Source, Ped Owner, Vector3 Target)
    {
      Model model = (Model) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "VEHICLE_WEAPON_TURRET_TECHNICAL");
      if (!Function.Call<bool>(Hash._0x36E353271F0E90EE, (InputArgument) model))
      {
        Function.Call(Hash._0x5443438F033E29C3, (InputArgument) model);
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x36E353271F0E90EE, (InputArgument) model))
            Script.Wait(0);
          else
            break;
        }
      }
      World.ShootBullet(Source, Target, Owner, model, 3);
      World.ShootBullet(Source, Target, Owner, model, 3);
      World.ShootBullet(Source, Target, Owner, model, 3);
      foreach (Entity nearbyEntity in World.GetNearbyEntities(Source, 30f))
      {
        if (nearbyEntity != (Entity) null)
          nearbyEntity.Alpha = 254;
      }
    }

    private void FireMissile(Vector3 Source, Ped Owner, Vector3 Target)
    {
      Model model = (Model) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "WEAPON_AIRSTRIKE_ROCKET");
      if (!Function.Call<bool>(Hash._0x36E353271F0E90EE, (InputArgument) model))
      {
        Function.Call(Hash._0x5443438F033E29C3, (InputArgument) model);
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x36E353271F0E90EE, (InputArgument) model))
            Script.Wait(0);
          else
            break;
        }
      }
      World.ShootBullet(Source, Target, Owner, model, 15000);
      foreach (Entity nearbyEntity in World.GetNearbyEntities(Source, 30f))
      {
        if (nearbyEntity != (Entity) null)
          nearbyEntity.Alpha = 254;
      }
    }

    public void SetupSpecialMissions()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SpecialMissions, "Special Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Brothers in Arms (EASY)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Brothers in Arms (MEDIUM)");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Brothers in Arms (HARD)");
      uiMenu.AddItem(Mission3);
      UIMenuItem uiMenuItem = new UIMenuItem("The Vulcan");
      uiMenu.AddItem(uiMenuItem);
      uiMenuItem.Description = "~y~ Warning : ~w~ This Mission is Extremely Difficult, and Requires Doomsday Heist Content!";
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (this.Bike1Blip != (Blip) null)
          this.Bike1Blip.Remove();
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        Vector3 vector3_1 = new Vector3(444.9f, 2257f, 88f);
        foreach (Prop prop in this.Props)
        {
          if ((Entity) prop != (Entity) null)
            prop.Delete();
        }
        foreach (Prop prop in this.VulcanAntiMissileNode)
        {
          if ((Entity) prop != (Entity) null)
            prop.Delete();
        }
        if (this.VulcanAntiMissileNode.Count > 0)
          this.VulcanAntiMissileNode.Clear();
        if ((Entity) this.Vulcan != (Entity) null)
          this.Vulcan.Delete();
        this.Vulcan = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, vector3_1);
        this.Vulcan.PrimaryColor = VehicleColor.UtilSilver;
        this.Vulcan.SecondaryColor = VehicleColor.UtilSilver;
        this.Vulcan.BodyHealth = 3000f;
        this.SpawnProp("xm_prop_sam_turret_01", vector3_1, new Vector3(-90f, 0.0f, 90f));
        this.Props[this.Props.Count - 1].AttachTo((Entity) this.Vulcan, 29, new Vector3(1f, 0.0f, 0.0f), new Vector3(-90f, 0.0f, 90f));
        this.SpawnProp("xm_prop_sam_turret_01", vector3_1, new Vector3(90f, 0.0f, 90f));
        this.Props[this.Props.Count - 1].AttachTo((Entity) this.Vulcan, 28, new Vector3(-1f, 0.0f, 0.0f), new Vector3(90f, 0.0f, 90f));
        this.SpawnProp("xm_prop_sam_turret_01", vector3_1, new Vector3(-90f, 0.0f, 90f));
        Prop prop1 = this.Props[this.Props.Count - 1];
        prop1.AttachTo((Entity) this.Vulcan, 31, new Vector3(1.4f, -0.4f, -0.1f), new Vector3(-90f, -90f, -90f));
        this.LeftMissileLauncher = prop1;
        this.SpawnProp("xm_prop_sam_turret_01", vector3_1, new Vector3(90f, 0.0f, 90f));
        Prop prop2 = this.Props[this.Props.Count - 1];
        prop2.AttachTo((Entity) this.Vulcan, 31, new Vector3(-1.4f, -0.4f, -0.1f), new Vector3(90f, -90f, -90f));
        this.RightMissileLauncher = prop2;
        this.Vulcan.CreateRandomPedOnSeat(VehicleSeat.Driver);
        this.LeftProjSpawn = this.LeftMissileLauncher.GetOffsetInWorldCoords(new Vector3(0.0f, 0.8f, 0.0f));
        this.RightProjSpawn = this.RightMissileLauncher.GetOffsetInWorldCoords(new Vector3(0.0f, 0.8f, 0.0f));
        this.MiddileProjSpawn = this.LeftMissileLauncher.GetOffsetInWorldCoords(new Vector3(-1.4f, 0.8f, 0.0f));
        Vector3 position1 = Game.Player.Character.Position;
        Game.Player.Character.Position = this.Vulcan.Position;
        Vector3 vector3_2;
        for (int index1 = 0; index1 < 7; ++index1)
        {
          vector3_2 = this.Vulcan.Position;
          Vector3 vector3_3 = vector3_2.Around(20f);
          this.SpawnProp("xm_prop_sam_turret_01", vector3_3, new Vector3(0.0f, 0.0f, 0.0f));
          Prop prop3 = this.Props[this.Props.Count - 1];
          this.VulcanAntiMissileNode.Add(prop3);
          float groundHeight = World.GetGroundHeight(vector3_3);
          prop3.Position = new Vector3(prop3.Position.X, prop3.Position.Y, groundHeight);
          prop3.AddBlip();
          prop3.CurrentBlip.Sprite = BlipSprite.Rocket;
          prop3.CurrentBlip.Color = BlipColor.Red;
          prop3.CurrentBlip.Name = "Vulcan Anti Projectile Node";
          prop3.Health = 200;
          prop3.IsInvincible = false;
          prop3.IsExplosionProof = false;
          Script.Wait(1);
        }
        Game.Player.Character.Position = position1;
        this.Vulcan.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleShootAtPed(Game.Player.Character);
        Ped pedOnSeat = this.Vulcan.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Script.Wait(1);
        this.Vulcan.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleShootAtPed(Game.Player.Character);
        this.Bike1Blip = World.CreateBlip(this.Vulcan.Position);
        this.Bike1Blip.Sprite = BlipSprite.Detonator;
        this.Bike1Blip.Color = BlipColor.Red;
        this.Bike1Blip.Name = "Destroy : Experemental AA Gun - Vulcan";
        this.Bike1Blip.ShowRoute = true;
        this.VehicleSetup2 = true;
        this.vehiclemissionid = 14;
        UI.Notify(this.GetHostName() + " We have spotted some sort of custom made AA gun, we have no idea how dangerous it is, Destroy it!");
        UI.Notify(this.GetHostName() + " Some stuff you might want to know, on the Vulcan! \\/");
        UI.Notify("~o~(1)~w~ : The Vulcan is armed with a ~o~Mingun~w~, and ~o~2x Missile Pods~w~, it can fire ~o~6 Missiles~w~ before needing a quick reload");
        UI.Notify("~o~(2)~w~ : its Minigun can fire ~o~1000 Rounds~w~, before needing a lengthy reload ");
        UI.Notify("~o~(3)~w~ : The Vulcan is surrounded by ~o~Anti Ordanance Nodes~w~ so incomming missiles will be destroyed if they not taken out");
        this.Vulcan.GetPedOnSeat(VehicleSeat.Driver).CanBeTargetted = false;
        this.Vulcan.IsPersistent = true;
        this.Vulcan.Livery = 1;
        if (item == Mission1)
        {
          if ((Entity) this.Trailer != (Entity) null)
            this.Trailer.Delete();
          if ((Entity) this.Bike1 != (Entity) null)
            this.Bike1.Delete();
          if ((Entity) this.Bike2 != (Entity) null)
            this.Bike2.Delete();
          if ((Entity) this.Bike3 != (Entity) null)
            this.Bike3.Delete();
          if ((Entity) this.Bike4 != (Entity) null)
            this.Bike4.Delete();
          if ((Entity) this.Bike5 != (Entity) null)
            this.Bike5.Delete();
          if (this.Bike1Blip != (Blip) null)
            this.Bike1Blip.Remove();
          if (this.Bike2Blip != (Blip) null)
            this.Bike2Blip.Remove();
          if (this.Bike3Blip != (Blip) null)
            this.Bike3Blip.Remove();
          if (this.Bike4Blip != (Blip) null)
            this.Bike4Blip.Remove();
          if (this.Bike5Blip != (Blip) null)
            this.Bike5Blip.Remove();
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.Tampa3, new Vector3(1384f, 3696f, 33f));
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.Tampa3, new Vector3(1389f, 3704f, 32f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.Phantom3, new Vector3(1397f, 3717f, 32f));
          Model model = (Model) VehicleHash.TrailerLarge;
          vector3_2 = new Vector3();
          Vector3 position2 = vector3_2;
          this.Trailer = World.CreateVehicle(model, position2);
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.Tampa3, new Vector3(1410f, 3743f, 32f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.Tampa3, new Vector3(1418f, 3759f, 32f));
          this.Bike1.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike2.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike3.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike5.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike4.Rotation = new Vector3(8f, 0.0f, 156f);
          Function.Call(Hash._0x3C7D42D58F770B54, (InputArgument) this.Bike3, (InputArgument) this.Trailer, (InputArgument) 10);
          this.Bike1.PlaceOnGround();
          this.Bike2.PlaceOnGround();
          this.Bike3.PlaceOnGround();
          this.Bike4.PlaceOnGround();
          this.Bike5.PlaceOnGround();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          System.Random random = new System.Random();
          this.Bike1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike4.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike5.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike1.SetMod(VehicleMod.Roof, -1, true);
          this.Bike2.SetMod(VehicleMod.Roof, -1, true);
          this.Bike3.SetMod(VehicleMod.Roof, -1, true);
          this.Bike4.SetMod(VehicleMod.Roof, -1, true);
          this.Bike5.SetMod(VehicleMod.Roof, -1, true);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.WeaponizedTampa;
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike1Blip.Name = "Enemy Tampa";
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.WeaponizedTampa;
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike2Blip.Name = "Enemy Tampa";
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.MobileOperationsCenter;
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike3Blip.Name = "Enemy MOC";
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.WeaponizedTampa;
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike4Blip.Name = "Enemy Tampa";
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.WeaponizedTampa;
          this.Bike5Blip.Color = BlipColor.Red;
          this.Bike5Blip.Name = "Enemy Tampa";
          this.Peds.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver));
          this.Trailer.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Trailer.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Trailer.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Driver));
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Trailer.Handle, (InputArgument) 0);
          this.Trailer.SetMod(VehicleMod.Roof, 1, true);
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
            {
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
              ped.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
              ped.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
              this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 60f, 1);
              this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 60f, 1);
              this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 60f, 1);
              this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 60f, 1);
              this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 60f, 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped, (InputArgument) 1);
            }
          }
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 10;
          UI.Notify(this.GetHostName() + " Boss weve spotted a convoy of Weaponized Tampas, and A MOC, we dont know what thier up to but we need them gone");
          this.SC.SetupVehicle(this.Bike1, 0);
          this.SC.SetupVehicle(this.Bike2, 0);
          this.SC.SetupVehicle(this.Bike4, 0);
          this.SC.SetupVehicle(this.Bike5, 0);
        }
        if (item == Mission2)
        {
          if ((Entity) this.Trailer != (Entity) null)
            this.Trailer.Delete();
          if ((Entity) this.Bike1 != (Entity) null)
            this.Bike1.Delete();
          if ((Entity) this.Bike2 != (Entity) null)
            this.Bike2.Delete();
          if ((Entity) this.Bike3 != (Entity) null)
            this.Bike3.Delete();
          if ((Entity) this.Bike4 != (Entity) null)
            this.Bike4.Delete();
          if ((Entity) this.Bike5 != (Entity) null)
            this.Bike5.Delete();
          if (this.Bike1Blip != (Blip) null)
            this.Bike1Blip.Remove();
          if (this.Bike2Blip != (Blip) null)
            this.Bike2Blip.Remove();
          if (this.Bike3Blip != (Blip) null)
            this.Bike3Blip.Remove();
          if (this.Bike4Blip != (Blip) null)
            this.Bike4Blip.Remove();
          if (this.Bike5Blip != (Blip) null)
            this.Bike5Blip.Remove();
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.Insurgent3, new Vector3(1384f, 3696f, 33f));
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.Insurgent3, new Vector3(1389f, 3704f, 32f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.Phantom3, new Vector3(1397f, 3717f, 32f));
          Model model = (Model) VehicleHash.TrailerLarge;
          vector3_2 = new Vector3();
          Vector3 position2 = vector3_2;
          this.Trailer = World.CreateVehicle(model, position2);
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.Insurgent3, new Vector3(1410f, 3743f, 32f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.Insurgent3, new Vector3(1418f, 3759f, 32f));
          this.Bike1.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike2.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike3.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike5.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike4.Rotation = new Vector3(8f, 0.0f, 156f);
          this.Bike1.PlaceOnGround();
          this.Bike2.PlaceOnGround();
          this.Bike3.PlaceOnGround();
          this.Bike4.PlaceOnGround();
          this.Bike5.PlaceOnGround();
          Function.Call(Hash._0x3C7D42D58F770B54, (InputArgument) this.Bike3, (InputArgument) this.Trailer, (InputArgument) 10);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.ExtraSeat5, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.ExtraSeat5, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.ExtraSeat5, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.ExtraSeat5, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          System.Random random = new System.Random();
          this.Bike1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike4.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike5.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike1.SetMod(VehicleMod.Roof, -1, true);
          this.Bike2.SetMod(VehicleMod.Roof, -1, true);
          this.Bike3.SetMod(VehicleMod.Roof, -1, true);
          this.Bike4.SetMod(VehicleMod.Roof, -1, true);
          this.Bike5.SetMod(VehicleMod.Roof, -1, true);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike1Blip.Name = "Enemy Tampa";
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike2Blip.Name = "Enemy Tampa";
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.MobileOperationsCenter;
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike3Blip.Name = "Enemy MOC";
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike4Blip.Name = "Enemy Tampa";
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Color = BlipColor.Red;
          this.Bike5Blip.Name = "Enemy Tampa";
          this.Peds.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver));
          this.Trailer.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Trailer.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Trailer.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Passenger));
          this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Driver));
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Trailer.Handle, (InputArgument) 0);
          this.Trailer.SetMod(VehicleMod.Roof, 1, true);
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
            {
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
              ped.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
              ped.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
              this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 60f, 1);
              this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 60f, 1);
              this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 60f, 1);
              this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 60f, 1);
              this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 60f, 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped, (InputArgument) 1);
            }
          }
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 10;
          UI.Notify(this.GetHostName() + " Boss weve spotted a convoy of Insurgent Customs, and A MOC, we dont know what thier up to but we need them gone");
          this.SC.SetupVehicle(this.Bike1, 0);
          this.SC.SetupVehicle(this.Bike2, 0);
          this.SC.SetupVehicle(this.Bike4, 0);
          this.SC.SetupVehicle(this.Bike5, 0);
        }
        if (item != Mission3)
          return;
        if ((Entity) this.Trailer != (Entity) null)
          this.Trailer.Delete();
        if ((Entity) this.Bike1 != (Entity) null)
          this.Bike1.Delete();
        if ((Entity) this.Bike2 != (Entity) null)
          this.Bike2.Delete();
        if ((Entity) this.Bike3 != (Entity) null)
          this.Bike3.Delete();
        if ((Entity) this.Bike4 != (Entity) null)
          this.Bike4.Delete();
        if ((Entity) this.Bike5 != (Entity) null)
          this.Bike5.Delete();
        if (this.Bike1Blip != (Blip) null)
          this.Bike1Blip.Remove();
        if (this.Bike2Blip != (Blip) null)
          this.Bike2Blip.Remove();
        if (this.Bike3Blip != (Blip) null)
          this.Bike3Blip.Remove();
        if (this.Bike4Blip != (Blip) null)
          this.Bike4Blip.Remove();
        if (this.Bike5Blip != (Blip) null)
          this.Bike5Blip.Remove();
        this.Bike1 = World.CreateVehicle((Model) VehicleHash.APC, new Vector3(1384f, 3696f, 33f));
        this.Bike2 = World.CreateVehicle((Model) VehicleHash.APC, new Vector3(1389f, 3704f, 32f));
        this.Bike3 = World.CreateVehicle((Model) VehicleHash.Phantom3, new Vector3(1397f, 3717f, 32f));
        Model model1 = (Model) VehicleHash.TrailerLarge;
        vector3_2 = new Vector3();
        Vector3 position3 = vector3_2;
        this.Trailer = World.CreateVehicle(model1, position3);
        this.Bike4 = World.CreateVehicle((Model) VehicleHash.APC, new Vector3(1410f, 3743f, 32f));
        this.Bike5 = World.CreateVehicle((Model) VehicleHash.APC, new Vector3(1418f, 3759f, 32f));
        this.Bike1.Rotation = new Vector3(8f, 0.0f, 156f);
        this.Bike2.Rotation = new Vector3(8f, 0.0f, 156f);
        this.Bike3.Rotation = new Vector3(8f, 0.0f, 156f);
        this.Bike5.Rotation = new Vector3(8f, 0.0f, 156f);
        this.Bike4.Rotation = new Vector3(8f, 0.0f, 156f);
        this.Bike1.PlaceOnGround();
        this.Bike2.PlaceOnGround();
        this.Bike3.PlaceOnGround();
        this.Bike4.PlaceOnGround();
        this.Bike5.PlaceOnGround();
        Function.Call(Hash._0x3C7D42D58F770B54, (InputArgument) this.Bike3, (InputArgument) this.Trailer, (InputArgument) 10);
        this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
        this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
        this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
        this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        System.Random random1 = new System.Random();
        this.Bike1.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike2.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike3.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike4.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike5.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike1.SetMod(VehicleMod.Roof, -1, true);
        this.Bike2.SetMod(VehicleMod.Roof, -1, true);
        this.Bike3.SetMod(VehicleMod.Roof, -1, true);
        this.Bike4.SetMod(VehicleMod.Roof, -1, true);
        this.Bike5.SetMod(VehicleMod.Roof, -1, true);
        this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
        this.Bike1Blip.Sprite = BlipSprite.APC;
        this.Bike1Blip.Color = BlipColor.Red;
        this.Bike1Blip.Name = "Enemy Tampa";
        this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
        this.Bike2Blip.Sprite = BlipSprite.APC;
        this.Bike2Blip.Color = BlipColor.Red;
        this.Bike2Blip.Name = "Enemy Tampa";
        this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
        this.Bike3Blip.Sprite = BlipSprite.MobileOperationsCenter;
        this.Bike3Blip.Color = BlipColor.Red;
        this.Bike3Blip.Name = "Enemy MOC";
        this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
        this.Bike4Blip.Sprite = BlipSprite.APC;
        this.Bike4Blip.Color = BlipColor.Red;
        this.Bike4Blip.Name = "Enemy Tampa";
        this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
        this.Bike5Blip.Sprite = BlipSprite.APC;
        this.Bike5Blip.Color = BlipColor.Red;
        this.Bike5Blip.Name = "Enemy Tampa";
        this.Peds.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger));
        this.Peds.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver));
        this.Peds.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger));
        this.Peds.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver));
        this.Peds.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger));
        this.Peds.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver));
        this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger));
        this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver));
        this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger));
        this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver));
        this.Peds.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver));
        this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger));
        this.Peds.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver));
        this.Trailer.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
        this.Trailer.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Trailer.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Driver));
        this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Passenger));
        this.Peds.Add(this.Trailer.GetPedOnSeat(VehicleSeat.Driver));
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Trailer.Handle, (InputArgument) 0);
        this.Trailer.SetMod(VehicleMod.Roof, 1, true);
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
          {
            int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
            ped.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
            ped.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
            Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped, (InputArgument) 1);
          }
        }
        this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 60f, 1);
        this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 60f, 1);
        this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 60f, 1);
        this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 60f, 1);
        this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 60f, 1);
        this.VehicleSetup2 = true;
        this.vehiclemissionid = 10;
        UI.Notify(this.GetHostName() + " Boss weve spotted a convoy of APCs, and A MOC, we dont know what thier up to but we need them gone");
        this.SC.SetupVehicle(this.Bike1, 0);
        this.SC.SetupVehicle(this.Bike2, 0);
        this.SC.SetupVehicle(this.Bike4, 0);
        this.SC.SetupVehicle(this.Bike5, 0);
      });
    }

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Gunrunning Business", "GunrunningBusinessMain", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: C1 Config.ini Failed To Load.");
      }
    }

    public Class1(bool B)
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
    }

    public Class1()
    {
      this.Peds = new List<Ped>();
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
      this.Allstocks = new AllStocks();
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Interval = 1;
      this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
      this.CreateBanner();
      this.Setup();
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if (this.BlipItem_SetupMission != (Blip) null)
        this.BlipItem_SetupMission.Remove();
      if (this.CrateBlip != (Blip) null)
        this.CrateBlip.Remove();
      if (this.JuggBlip != (Blip) null)
        this.JuggBlip.Remove();
      if (this.UsingSuit)
      {
        Model model = new Model(this.OldCharacter.Hash);
        model.Request(500);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(100);
          Function.Call(Hash._0x00A1CADD00108836, (InputArgument) Game.Player, (InputArgument) model.Hash);
          Function.Call(Hash._0x45EEE61580806D63, (InputArgument) Game.Player.Character.Handle);
        }
        model.MarkAsNoLongerNeeded();
        this.UsingSuit = false;
        Game.Player.MaxArmor = 400;
        Game.Player.Character.Armor = 0;
        Game.Player.Character.Health = 200;
        Game.Player.Character.MaxHealth = 200;
      }
      if ((Entity) this.Crate != (Entity) null)
        this.Crate.Delete();
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
      if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
        this.MillitaryAssetToRetrieve.Delete();
      if (this.MilitaryVehicleBlip != (Blip) null)
        this.MilitaryVehicleBlip.Remove();
      foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
      {
        if ((Entity) sourcingmissionPed != (Entity) null)
          sourcingmissionPed.Delete();
      }
      foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
      {
        if ((Entity) sourcingmissionVehicle != (Entity) null)
          sourcingmissionVehicle.Delete();
      }
      if ((Entity) this.DeliveryVehicle != (Entity) null)
        this.DeliveryVehicle.Delete();
      foreach (Ped ipPed in this.IPPeds)
      {
        if ((Entity) ipPed != (Entity) null)
          ipPed.Delete();
      }
      if ((Entity) this.Base != (Entity) null)
        this.Base.Delete();
      if ((Entity) this.Hatch != (Entity) null)
        this.Hatch.Delete();
      if ((Entity) this.ChairProp != (Entity) null)
        this.ChairProp.Delete();
      if (this.MVRange != (Blip) null)
        this.MVRange.Remove();
      try
      {
        Game.Player.Character.CanSwitchWeapons = true;
        Game.Player.Character.FreezePosition = false;
        foreach (Ped ped in this.PedsAI)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        if (this.Range != (Blip) null)
          this.Range.Remove();
        if (this.EndPointBlip != (Blip) null)
          this.EndPointBlip.Remove();
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
        if (this.SuppyGuards.Count > 0)
        {
          foreach (Ped suppyGuard in this.SuppyGuards)
          {
            if ((Entity) suppyGuard != (Entity) null)
              suppyGuard.Delete();
          }
        }
        if (this.DropBlip.Count > 0)
        {
          foreach (Blip blip in this.DropBlip)
          {
            if (blip != (Blip) null)
              blip.Remove();
          }
        }
        if ((Entity) this.StockVeh != (Entity) null)
          this.StockVeh.Delete();
        if (this.SellStockProps.Count > 0)
        {
          foreach (Prop sellStockProp in this.SellStockProps)
          {
            if ((Entity) sellStockProp != (Entity) null)
              sellStockProp.Delete();
          }
        }
        if (this.SupplyGarageBlip != (Blip) null)
          this.SupplyGarageBlip.Remove();
      }
      catch
      {
      }
      foreach (Prop prop in this.VulcanAntiMissileNode)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if ((Entity) this.Vulcan != (Entity) null)
        this.Vulcan.Delete();
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if ((Entity) this.Trailer != (Entity) null)
        this.Trailer.Delete();
      if ((Entity) this.Bike1 != (Entity) null)
        this.Bike1.Delete();
      if ((Entity) this.Bike2 != (Entity) null)
        this.Bike2.Delete();
      if ((Entity) this.Bike3 != (Entity) null)
        this.Bike3.Delete();
      if ((Entity) this.Bike4 != (Entity) null)
        this.Bike4.Delete();
      if ((Entity) this.Bike5 != (Entity) null)
        this.Bike5.Delete();
      if (this.Bike1Blip != (Blip) null)
        this.Bike1Blip.Remove();
      if (this.Bike2Blip != (Blip) null)
        this.Bike2Blip.Remove();
      if (this.Bike3Blip != (Blip) null)
        this.Bike3Blip.Remove();
      if (this.Bike4Blip != (Blip) null)
        this.Bike4Blip.Remove();
      if (this.Bike5Blip != (Blip) null)
        this.Bike5Blip.Remove();
      if (this.LabMarker != (Blip) null)
        this.LabMarker.Remove();
      if (this.DropPointBlip != (Blip) null)
        this.DropPointBlip.Remove();
      if ((Entity) this.Caddy != (Entity) null)
        this.Caddy.Delete();
      if ((Entity) this.JuggernautPed != (Entity) null)
        this.JuggernautPed.Delete();
      if ((Entity) this.Moc2 != (Entity) null)
        this.Moc2.Delete();
      if ((Entity) this.Moc1 != (Entity) null)
        this.Moc1.Delete();
    }

    private void SetupProduct()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.ProductStock, "Buy/Sell Product");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Buy2 = new UIMenuItem("Buy X10: -$" + 2500000.ToString());
      uiMenu.AddItem(Buy2);
      UIMenuItem Buy = new UIMenuItem("Buy X1: -$" + 250000.ToString());
      uiMenu.AddItem(Buy);
      UIMenuItem Sell = new UIMenuItem("Instant Sell - All Stocks (75% Return)");
      uiMenu.AddItem(Sell);
      UIMenuItem SupplySell = new UIMenuItem("Supply Mission - Sell  (125% Return)");
      uiMenu.AddItem(SupplySell);
      UIMenuItem SupplySteal = new UIMenuItem("Supply Mission - Steal Cargo Crates ");
      uiMenu.AddItem(SupplySteal);
      UIMenuItem SupplyDestoy = new UIMenuItem("Supply Mission - Destroy Cargo Crates ");
      uiMenu.AddItem(SupplyDestoy);
      UIMenuItem Show = new UIMenuItem("Show Product Value/Count");
      uiMenu.AddItem(Show);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Show)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
          UI.Notify(this.GetHostName() + "  Here is where we are at");
          UI.Notify("Level: " + this.purchaselvl.ToString() + "/20");
          UI.Notify("Max Stocks: " + this.maxstocks.ToString());
          UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
          UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
          UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
        }
        if (item == Buy2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
          if (this.stockscount + 10 <= this.maxstocks)
          {
            if (Game.Player.Money > 2500000)
            {
              Game.Player.Money -= 2500000;
              this.stocksvalue += 1750000f;
              this.stockscount += 10;
              this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
              this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " ok i can deal with that, one new container of product");
              UI.Notify("Stocks Avalable: " + this.stockscount.ToString());
            }
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss, were full, we canot store any more stocks, please sell stocks or upgrade ");
        }
        if (item == Buy)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
          if (this.stockscount != this.maxstocks)
          {
            if (Game.Player.Money > 250000)
            {
              Game.Player.Money -= 250000;
              this.stocksvalue += 175000f;
              ++this.stockscount;
              this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
              this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " ok i can deal with that, one new container of product");
              UI.Notify("Stocks Avalable: " + this.stockscount.ToString());
            }
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss, were full, we canot store any more stocks, please sell stocks or upgrade ");
        }
        if (item == SupplySell)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
          if (this.SupplyGarageBlip != (Blip) null)
            this.SupplyGarageBlip.Remove();
          foreach (Ped suppyGuard in this.SuppyGuards)
          {
            if ((Entity) suppyGuard != (Entity) null)
              suppyGuard.Delete();
          }
          if (this.SellStockProps.Count > 0)
          {
            foreach (Prop sellStockProp in this.SellStockProps)
            {
              if ((Entity) sellStockProp != (Entity) null)
                sellStockProp.Delete();
            }
          }
          foreach (Blip blip in this.DropBlip)
          {
            if (blip != (Blip) null)
              blip.Remove();
          }
          this.DropBlip.Clear();
          if ((Entity) this.StockVeh != (Entity) null)
            this.StockVeh.Delete();
          Script.Wait(100);
          this.AmttoDeliver = 0;
          if (this.stockscount > 100 && this.stockscount < 200)
          {
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.TipTruck, this.OutsideVehicleSpawn, 0.0f);
            this.StockVeh.ToggleExtra(2, false);
            Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
            Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
            this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
            System.Random random = new System.Random();
            Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp1 = prop1;
            this.SellStockProps.Add(prop1);
            Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp2 = prop2;
            this.SellStockProps.Add(prop2);
            this.SellStockProp1.HasCollision = false;
            this.SellStockProp2.HasCollision = false;
          }
          if (this.stockscount > 200)
          {
            System.Random random = new System.Random();
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Flatbed, this.OutsideVehicleSpawn, 0.0f);
            Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
            Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
            Vector3 offsetInWorldCoords3 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
            Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp1 = prop1;
            this.SellStockProps.Add(prop1);
            Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp2 = prop2;
            this.SellStockProps.Add(prop2);
            Prop prop3 = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords3, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp3 = prop3;
            this.SellStockProps.Add(prop3);
            this.SellStockProp1.HasCollision = false;
            this.SellStockProp2.HasCollision = false;
            this.SellStockProp3.HasCollision = false;
          }
          if (this.stockscount < 100)
          {
            System.Random random = new System.Random();
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Guardian, this.OutsideVehicleSpawn, 0.0f);
            Vector3 offsetInWorldCoords = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.1f));
            Prop prop = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp1 = prop;
            this.SellStockProps.Add(prop);
            this.SellStockProp1.HasCollision = false;
          }
          if (this.stockscount < 30)
            this.AmttoDeliver = 2;
          if (this.stockscount >= 30 && this.stockscount < 70)
            this.AmttoDeliver = 3;
          if (this.stockscount >= 70 && this.stockscount < 120)
            this.AmttoDeliver = 4;
          if (this.stockscount >= 120 && this.stockscount < 150)
            this.AmttoDeliver = 5;
          if (this.stockscount >= 150 && this.stockscount < 190)
            this.AmttoDeliver = 6;
          if (this.stockscount >= 190 && this.stockscount < 230)
            this.AmttoDeliver = 7;
          if (this.stockscount >= 230 && this.stockscount < 260)
            this.AmttoDeliver = 8;
          if (this.stockscount >= 260 && this.stockscount < 290)
            this.AmttoDeliver = 9;
          if (this.stockscount >= 290 && this.stockscount < 330)
            this.AmttoDeliver = 10;
          if (this.stockscount >= 330 && this.stockscount < 360)
            this.AmttoDeliver = 12;
          if (this.stockscount >= 360 && this.stockscount < 400)
            this.AmttoDeliver = 14;
          if (this.stockscount >= 400)
            this.AmttoDeliver = 16;
          foreach (Vector3 position in this.DropPointSupply)
          {
            Blip blip = World.CreateBlip(position);
            blip.Sprite = BlipSprite.SpecialCargo;
            blip.Name = "Cargo Sell Deliver Point";
            blip.Color = BlipColor.BlueLight;
            this.DropBlip.Add(blip);
            blip.IsShortRange = true;
          }
          UI.Notify(this.GetHostName() + " : Because your Stock Level is " + this.stockscount.ToString() + ", you need to deliver to a minimum of " + this.AmttoDeliver.ToString() + " drop points~w~, each drop point is indicated by a yellow crate icon on your map, good luck");
          if ((Entity) this.StockVeh != (Entity) null)
          {
            this.StockVeh.AddBlip();
            this.StockVeh.CurrentBlip.Sprite = BlipSprite.ArmoredTruck;
            this.StockVeh.CurrentBlip.Name = "Cargo Deliver Vehicle";
            this.StockVeh.CurrentBlip.Color = BlipColor.Blue4;
          }
          this.CreateSupplyVehicle = false;
          this.GotVehicle = false;
          this.SellStockDeliveryMission = true;
          this.missionnum = 2222;
          this.SellStockPointsBeenAt = 0;
        }
        if (item == SupplySteal)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
          if (this.SupplyGarageBlip != (Blip) null)
            this.SupplyGarageBlip.Remove();
          foreach (Ped suppyGuard in this.SuppyGuards)
          {
            if ((Entity) suppyGuard != (Entity) null)
              suppyGuard.Delete();
          }
          if (this.SellStockProps.Count > 0)
          {
            foreach (Prop sellStockProp in this.SellStockProps)
            {
              if ((Entity) sellStockProp != (Entity) null)
                sellStockProp.Delete();
            }
          }
          foreach (Blip blip in this.DropBlip)
          {
            if (blip != (Blip) null)
              blip.Remove();
          }
          this.DropBlip.Clear();
          if ((Entity) this.StockVeh != (Entity) null)
            this.StockVeh.Delete();
          Script.Wait(100);
          this.AmttoDeliver = 0;
          if (this.stockscount < 30)
            this.AmttoDeliver = 2;
          if (this.stockscount >= 30 && this.stockscount < 70)
            this.AmttoDeliver = 3;
          if (this.stockscount >= 70 && this.stockscount < 120)
            this.AmttoDeliver = 4;
          if (this.stockscount >= 120 && this.stockscount < 150)
            this.AmttoDeliver = 5;
          if (this.stockscount >= 150 && this.stockscount < 190)
            this.AmttoDeliver = 6;
          if (this.stockscount >= 190 && this.stockscount < 230)
            this.AmttoDeliver = 7;
          if (this.stockscount >= 230 && this.stockscount < 260)
            this.AmttoDeliver = 8;
          if (this.stockscount >= 260 && this.stockscount < 290)
            this.AmttoDeliver = 9;
          if (this.stockscount >= 290 && this.stockscount < 330)
            this.AmttoDeliver = 10;
          if (this.stockscount >= 330 && this.stockscount < 360)
            this.AmttoDeliver = 12;
          if (this.stockscount >= 360 && this.stockscount < 400)
            this.AmttoDeliver = 14;
          if (this.stockscount >= 400)
            this.AmttoDeliver = 16;
          foreach (Vector3 position in this.DropPointSupply)
          {
            Blip blip = World.CreateBlip(position);
            blip.Sprite = BlipSprite.SpecialCargo;
            blip.Name = "Steal Cargo Vehicle";
            blip.Color = BlipColor.BlueLight;
            this.DropBlip.Add(blip);
            blip.IsShortRange = true;
          }
          UI.Notify(this.GetHostName() + " : I have marked out several locations where, weve spotted rival Businesses, shipping Stock, steal as much you want");
          this.CreateSupplyVehicle = false;
          this.GotVehicle = false;
          this.SellStockDeliveryMission = true;
          this.missionnum = 3333;
          this.SellStockPointsBeenAt = 0;
        }
        if (item == SupplyDestoy)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
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
          if (this.EndPointBlip != (Blip) null)
            this.EndPointBlip.Remove();
          this.EndPointVec = new Vector3(-1286.58f, 2529.48f, 20f);
          this.Sam1Loc = new Vector3(-2168.24f, -343f, 14f);
          this.Sam2Loc = new Vector3(2199f, 3015.55f, 45f);
          this.Sam3Loc = new Vector3(-155f, 6216.85f, 32f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Flatbed, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Flatbed, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Flatbed, this.Sam3Loc);
          System.Random random1 = new System.Random();
          Vector3 offsetInWorldCoords1 = this.Sam1.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
          Vector3 offsetInWorldCoords2 = this.Sam1.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
          Vector3 offsetInWorldCoords3 = this.Sam1.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
          Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.Sam1.Heading), false, false);
          this.SellStockProp1 = prop1;
          this.SellStockProps.Add(prop1);
          Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.Sam1.Heading), false, false);
          this.SellStockProp2 = prop2;
          this.SellStockProps.Add(prop2);
          Prop prop3 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords3, new Vector3(0.0f, 0.0f, this.Sam1.Heading), false, false);
          this.SellStockProp3 = prop3;
          this.SellStockProps.Add(prop3);
          this.SellStockProp1.HasCollision = false;
          this.SellStockProp2.HasCollision = false;
          this.SellStockProp3.HasCollision = false;
          Vector3 offsetInWorldCoords4 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
          Vector3 offsetInWorldCoords5 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
          Vector3 offsetInWorldCoords6 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
          Prop prop4 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords4, new Vector3(0.0f, 0.0f, this.Sam2.Heading), false, false);
          this.SellStockProp4 = prop4;
          this.SellStockProps.Add(prop4);
          Prop prop5 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords5, new Vector3(0.0f, 0.0f, this.Sam2.Heading), false, false);
          this.SellStockProp5 = prop5;
          this.SellStockProps.Add(prop5);
          Prop prop6 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords6, new Vector3(0.0f, 0.0f, this.Sam2.Heading), false, false);
          this.SellStockProp6 = prop6;
          this.SellStockProps.Add(prop6);
          this.SellStockProp4.HasCollision = false;
          this.SellStockProp5.HasCollision = false;
          this.SellStockProp6.HasCollision = false;
          Vector3 offsetInWorldCoords7 = this.Sam3.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
          Vector3 offsetInWorldCoords8 = this.Sam3.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
          Vector3 offsetInWorldCoords9 = this.Sam3.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
          Prop prop7 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords7, new Vector3(0.0f, 0.0f, this.Sam3.Heading), false, false);
          this.SellStockProp7 = prop7;
          this.SellStockProps.Add(prop7);
          Prop prop8 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords8, new Vector3(0.0f, 0.0f, this.Sam3.Heading), false, false);
          this.SellStockProp8 = prop8;
          this.SellStockProps.Add(prop8);
          Prop prop9 = World.CreateProp(this.RequestModel(this.CrateProps[random1.Next(0, this.CrateProps.Count)]), offsetInWorldCoords9, new Vector3(0.0f, 0.0f, this.Sam3.Heading), false, false);
          this.SellStockProp9 = prop9;
          this.SellStockProps.Add(prop9);
          this.SellStockProp7.HasCollision = false;
          this.SellStockProp8.HasCollision = false;
          this.SellStockProp9.HasCollision = false;
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPointVec, 20f, 120f, 1);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.EndPointVec, 20f, 120f, 1);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.EndPointVec, 20f, 120f, 1);
          System.Random random2 = new System.Random();
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.ArmoredTruck;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Armored Truck A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          this.Sam2blip.Sprite = BlipSprite.ArmoredTruck;
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "Armored Truck B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          this.Sam3blip.Sprite = BlipSprite.ArmoredTruck;
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "Armored Truck C";
          this.EndPointBlip = World.CreateBlip(this.EndPointVec);
          this.EndPointBlip.Sprite = BlipSprite.CaptureFlag;
          this.EndPointBlip.Color = BlipColor.White;
          this.EndPointBlip.Name = "Delivery Point";
          this.missionnum = 4444;
          this.SellStockDeliveryMission = true;
          UI.Notify(this.GetHostName() + " : Boss I've spotted 3 vehicles on route to Fort Zancudo, Destroy All Three, Before they reach their destination for a 25% Boost to Stock Value");
        }
        if (item != Sell)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
        UI.Notify(this.GetHostName() + " ok i can deal with that, selling all product avalable");
        Game.Player.Money += (int) ((double) this.stocksvalue * 0.75);
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
    }

    private void Setupbuisness()
    {
      List<object> items = new List<object>();
      int num1 = 1;
      for (int index = 1; index < 100; ++index)
        items.Add((object) (num1 + index));
      List<object> Chairs = new List<object>();
      Chairs.Add((object) "ex_prop_offchair_exec_01");
      Chairs.Add((object) "ex_prop_offchair_exec_02");
      Chairs.Add((object) "ex_prop_offchair_exec_03");
      Chairs.Add((object) "ex_prop_offchair_exec_04");
      Chairs.Add((object) "ba_prop_battle_club_chair_01");
      Chairs.Add((object) "ba_prop_battle_club_chair_02");
      Chairs.Add((object) "ba_prop_battle_club_chair_03");
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.methgarage, "Change Chair Prop Model ");
      this.GUIMenus.Add(uiMenu1);
      UIMenuItem MainChair = new UIMenuItem("Set Main Chair ");
      uiMenu1.AddItem(MainChair);
      UIMenuListItem MainChairlist = new UIMenuListItem("", Chairs, 1);
      uiMenu1.AddItem((UIMenuItem) MainChairlist);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != MainChair)
          return;
        Vector3 vector3 = new Vector3();
        float num2 = 0.0f;
        if ((Entity) this.ChairProp != (Entity) null)
        {
          vector3 = this.ChairProp.Position;
          num2 = this.ChairProp.Heading;
        }
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__340.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__340.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.ChairPropModel = Class1.\u003C\u003Eo__340.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__340.\u003C\u003Ep__0, Chairs[MainChairlist.Index]);
        this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
        this.Config.Save();
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__340.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__340.\u003C\u003Ep__2 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, System.Type, object> target = Class1.\u003C\u003Eo__340.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, System.Type, object>> p2 = Class1.\u003C\u003Eo__340.\u003C\u003Ep__2;
        System.Type type = typeof (UI);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__340.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__340.\u003C\u003Ep__1 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__340.\u003C\u003Ep__1.Target((CallSite) Class1.\u003C\u003Eo__340.\u003C\u003Ep__1, "~g~ HKH191~w~  : Main Chair Model has been set to ", Chairs[MainChairlist.Index]);
        target((CallSite) p2, type, obj);
        if ((Entity) this.ChairProp != (Entity) null)
          this.ChairProp.Delete();
        Prop prop = World.CreateProp(this.RequestModel(this.ChairPropModel), new Vector3(909.03f, -3206.8f, -98.1f), new Vector3(0.0f, 0.0f, 0.0f), false, false);
        prop.FreezePosition = true;
        prop.Heading = -45f;
        this.ChairProp = prop;
        if ((Entity) this.ChairProp != (Entity) null)
        {
          this.ChairProp.Position = vector3;
          this.ChairProp.Heading = num2;
        }
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.methgarage, "Expand Business ");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.methgarage, "Buy/Sell Gun Running Business");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem Sell = new UIMenuItem("Sell");
      uiMenu3.AddItem(Sell);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Sell)
          return;
        if (!this.bought)
        {
          UI.Notify(this.GetHostName() + " Get out of here!, you dont own any of these buisnesses ");
        }
        else
        {
          this.bought = false;
          this.purchaselvl = 0;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
          this.Config.Save();
          UI.Notify(this.GetHostName() + " I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        }
      });
      UIMenuItem Update = new UIMenuItem("Update Stats");
      uiMenu2.AddItem(Update);
      UIMenuItem BuyNewLevel = new UIMenuItem(" Buy Level ");
      uiMenu2.AddItem(BuyNewLevel);
      UIMenuListItem list2 = new UIMenuListItem("Select Level: ", items, 1);
      uiMenu2.AddItem((UIMenuItem) list2);
      UIMenuItem Jump = new UIMenuItem("Jump Straight to Level");
      uiMenu2.AddItem(Jump);
      UIMenuItem Show = new UIMenuItem("Show Payouts");
      uiMenu2.AddItem(Show);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Jump)
        {
          int num2 = list2.Index + 1;
          if (num2 > this.purchaselvl)
          {
            int num3 = 0;
            int num4 = 0;
            this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
            for (int purchaselvl = this.purchaselvl; purchaselvl < num2; ++purchaselvl)
            {
              double num5 = 1.75;
              if (this.purchaselvl < 25)
                num5 = 1.75;
              if (this.purchaselvl > 25 && index < 50)
                num5 = 2.25;
              if (this.purchaselvl > 50 && this.purchaselvl < 70)
                num5 = 3.5;
              if (this.purchaselvl > 75 && this.purchaselvl < 100)
                num5 = 4.75;
              num3 += (int) ((double) this.BusinessUpgradeBasePrice * num5 * (double) num2);
              ++num4;
            }
            UI.Notify("OK your new level will be " + (this.purchaselvl += num4 + 1).ToString() + ", at a price of $" + num3.ToString("N") + ", Do u want to continue Enter Y or N");
            Script.Wait(1000);
            try
            {
              if (Game.GetUserInput(WindowTitle.CELL_EMAIL_BOD, 1).Equals("Y"))
              {
                if (Game.Player.Money >= num3)
                {
                  Game.Player.Money -= num3;
                  this.purchaselvl = num2;
                  this.maxstocks = 10 * this.purchaselvl;
                  float num5 = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
                  this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
                  this.increaseGain = num5;
                  this.Config.SetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
                  this.Config.Save();
                }
                else
                {
                  this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
                  UI.Notify("You dont have enough money to purchase this upgrade");
                }
              }
              else
              {
                this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
                UI.Notify(" You Entered the Wrong key or N");
              }
            }
            catch (NullReferenceException ex)
            {
              this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
              UI.Notify("You did not enter a key!");
            }
          }
        }
        int num6;
        if (item == Update)
        {
          int num2 = list2.Index + 1;
          double num3 = 1.75;
          if (this.purchaselvl < 25)
            num3 = 1.75;
          if (this.purchaselvl > 25 && index < 50)
            num3 = 2.25;
          if (this.purchaselvl > 50 && this.purchaselvl < 70)
            num3 = 3.5;
          if (this.purchaselvl > 75 && this.purchaselvl < 100)
            num3 = 4.75;
          UI.Notify("Price " + ((double) this.BusinessUpgradeBasePrice * num3 * (double) num2).ToString("N"));
          num6 = num2 + 1;
          UI.Notify("Level to Buy " + num6.ToString());
          UI.Notify("increaseGain : $" + ((float) ((double) this.BusinessUpgradeIncreaseGain * (double) num2 / 0.75)).ToString());
          UI.Notify("Profit Margin :" + (0.85 * (double) num2 + 0.0).ToString() + "%");
          num6 = 10 * num2;
          UI.Notify("Max Stocks : " + num6.ToString());
        }
        if (item == BuyNewLevel)
        {
          int num2 = list2.Index + 1;
          this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
          if (this.purchaselvl + 1 == num2)
          {
            double num3 = 1.75;
            if (this.purchaselvl < 25)
              num3 = 1.75;
            if (this.purchaselvl > 25 && index < 50)
              num3 = 2.25;
            if (this.purchaselvl > 50 && this.purchaselvl < 70)
              num3 = 3.5;
            if (this.purchaselvl > 75 && this.purchaselvl < 100)
              num3 = 4.75;
            if ((double) Game.Player.Money >= (double) this.BusinessUpgradeBasePrice * num3 * (double) num2)
            {
              Game.Player.Money -= (int) ((double) this.BusinessUpgradeBasePrice * num3 * (double) num2);
              ++this.purchaselvl;
              this.maxstocks = 10 * this.purchaselvl;
              float num4 = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
              this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
              this.increaseGain = num4;
              this.Config.SetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
              this.Config.Save();
            }
            else
              UI.Notify("You dont have enough money to purchase this upgrade");
          }
          else
            UI.Notify("The level you are trying to purchase is either to high or to low!, please purchase the level before, to purchase this level");
        }
        if (item != Show)
          return;
        double num7 = 1.75;
        if (this.purchaselvl < 25)
          num7 = 1.75;
        if (this.purchaselvl > 25 && index < 50)
          num7 = 2.25;
        if (this.purchaselvl > 50 && this.purchaselvl < 70)
          num7 = 3.5;
        if (this.purchaselvl > 75 && this.purchaselvl < 100)
          num7 = 4.75;
        UI.Notify("Price for Next Level $" + ((double) this.BusinessUpgradeBasePrice * num7 * (double) this.purchaselvl).ToString("N"));
        num6 = this.purchaselvl + 1;
        UI.Notify("Next Level " + num6.ToString());
        UI.Notify("increaseGain : $" + ((float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75)).ToString());
        UI.Notify("Profit Margin :" + (0.85 * (double) this.purchaselvl + 0.0).ToString() + "%");
        num6 = 10 * this.purchaselvl;
        UI.Notify("Max Stocks : " + num6.ToString());
      });
      List<object> MColour = new List<object>();
      MColour.Add((object) "Green");
      MColour.Add((object) "Blue");
      MColour.Add((object) "Yellow");
      MColour.Add((object) "Red");
      MColour.Add((object) "Purple");
      MColour.Add((object) "Pink");
      List<object> BColour = new List<object>();
      BColour.Add((object) BlipColor.Green);
      BColour.Add((object) BlipColor.Blue);
      BColour.Add((object) BlipColor.Yellow);
      BColour.Add((object) BlipColor.Red);
      BColour.Add((object) BlipColor.Purple);
      BColour.Add((object) BlipColor.Pink);
      List<object> UiColour = new List<object>();
      UiColour.Add((object) "   g   ");
      UiColour.Add((object) "   b   ");
      UiColour.Add((object) "   y  ");
      UiColour.Add((object) "   r   ");
      UiColour.Add((object) "   p   ");
      UiColour.Add((object) "   m   ");
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.methgarage, "Misc");
      this.GUIMenus.Add(uiMenu4);
      UIMenuListItem MC = new UIMenuListItem("Marker Color : ", MColour, 0);
      uiMenu4.AddItem((UIMenuItem) MC);
      UIMenuListItem BC = new UIMenuListItem("Blip Color : ", BColour, 0);
      uiMenu4.AddItem((UIMenuItem) BC);
      UIMenuItem uiMenuItem = new UIMenuItem("Current Host : " + this.GetHostName());
      uiMenu4.AddItem(uiMenuItem);
      UIMenuItem SetHN = new UIMenuItem("Set Host Name");
      uiMenu4.AddItem(SetHN);
      UIMenuListItem uiC = new UIMenuListItem("UI Color : ", UiColour, 0);
      uiMenu4.AddItem((UIMenuItem) uiC);
      UIMenuItem Setall = new UIMenuItem("Save All");
      uiMenu4.AddItem(Setall);
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == SetHN)
        {
          this.HostName = Game.GetUserInput(WindowTitle.CELL_EMAIL_BOD, 16);
          this.Config.SetValue<string>("Misc", "HostName", this.HostName);
          this.Config.Save();
          UI.Notify(this.GetHostName() + " : Hi im your new boss!");
        }
        if (item != Setall)
          return;
        this.Config.SetValue<string>("Misc", "HostName", this.HostName);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__340.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__340.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, BlipColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (BlipColor), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Blip_Colour = Class1.\u003C\u003Eo__340.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__340.\u003C\u003Ep__3, BColour[BC.Index]);
        this.Config.SetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__340.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__340.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Uicolour = Class1.\u003C\u003Eo__340.\u003C\u003Ep__4.Target((CallSite) Class1.\u003C\u003Eo__340.\u003C\u003Ep__4, UiColour[uiC.Index]);
        this.Config.SetValue<string>("Misc", "Uicolour", this.Uicolour);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__340.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__340.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.MarkerColorString = Class1.\u003C\u003Eo__340.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__340.\u003C\u003Ep__5, MColour[MC.Index]);
        this.Config.SetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " : Settings Changed they will take effect when you reload the mod!");
      });
    }

    private void LoadJuggSuit(string iniName)
    {
      try
      {
        this.JuggConfig = ScriptSettings.Load(iniName);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~:C1 Config.ini Failed To Load.");
      }
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.Key1 = this.Config.GetValue<Keys>("Configurations", "Key1", this.Key1);
        this.Style = this.Config.GetValue<string>("Design", "Style", this.Style);
        this.Upgrade1 = this.Config.GetValue<string>("Design", "Upgrade1", this.Upgrade1);
        this.Upgrade2 = this.Config.GetValue<string>("Design", "Upgrade2", this.Upgrade2);
        this.Upgrade3 = this.Config.GetValue<string>("Design", "Upgrade3", this.Upgrade3);
        this.GunlockerBought = this.Config.GetValue<int>("Extra", "GunLockerBought", this.GunlockerBought);
        this.Trailersmall2Retrieved = this.Config.GetValue<int>("SPECIALVEHICLES", "TRAILERSMALL2", this.Trailersmall2Retrieved);
        this.Dune3Bought = this.Config.GetValue<int>("SPECIALVEHICLES", "DUNEFAVBought", this.Dune3Bought);
        this.APCBought = this.Config.GetValue<int>("SPECIALVEHICLES", "APCBought", this.APCBought);
        this.HalftrackBought = this.Config.GetValue<int>("SPECIALVEHICLES", "HALFTRACKBought", this.HalftrackBought);
        this.InsurgentBought = this.Config.GetValue<int>("SPECIALVEHICLES", "INSURGENT3Bought", this.InsurgentBought);
        this.OppressorBought = this.Config.GetValue<int>("SPECIALVEHICLES", "OPPRESSORBought", this.OppressorBought);
        this.TechnicalBought = this.Config.GetValue<int>("SPECIALVEHICLES", "TECHNICAL3Bought", this.TechnicalBought);
        this.NightSharkBought = this.Config.GetValue<int>("SPECIALVEHICLES", "NIGHTSHARKBought", this.NightSharkBought);
        this.TampaBought = this.Config.GetValue<int>("SPECIALVEHICLES", "TAMPA3Bought", this.TampaBought);
        this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
        this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
        this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.UseOldMarker = this.Config.GetValue<bool>("Setup", "UseOldMarker", this.UseOldMarker);
        this.waittime = this.Config.GetValue<int>("Setup", "WaitTime", this.waittime);
        this.UseOldMarker = this.Config.GetValue<bool>("Setup", "UseOldMarker", this.UseOldMarker);
        this.MOCBought = this.Config.GetValue<int>("MOC", "bought", this.MOCBought);
        this.maxstocks = 10 * this.purchaselvl;
        float num = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
        this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
        this.increaseGain = num;
        this.BNKr_BunkerOperationStatus = this.Config.GetValue<int>("DisruptionLogistics", "BunkerOperationStatus", this.BNKr_BunkerOperationStatus);
        this.BNKr_ResearchStatus = this.Config.GetValue<int>("MOC", "ResearchStatus", this.BNKr_ResearchStatus);
        this.BNKr_StockLevel = this.Config.GetValue<int>("DisruptionLogistics", "StockLevel", this.BNKr_StockLevel);
        this.BNKr_ResearchProgress = this.Config.GetValue<int>("DisruptionLogistics", "ResearchProgress", this.BNKr_ResearchProgress);
        this.BNKr_SuppliesLevel = this.Config.GetValue<int>("DisruptionLogistics", "SuppliesLevel", this.BNKr_SuppliesLevel);
        this.BNKr_TotalEarnings = this.Config.GetValue<int>("DisruptionLogistics", "TotalEarnings", this.BNKr_TotalEarnings);
        this.BNKr_TotalSales = this.Config.GetValue<int>("DisruptionLogistics", "TotalSales", this.BNKr_TotalSales);
        this.BNKr_ResupplySuccess = this.Config.GetValue<int>("DisruptionLogistics", "ResupplySuccess", this.BNKr_ResupplySuccess);
        this.BNKr_ResupplyFails = this.Config.GetValue<int>("DisruptionLogistics", "ResupplyFails", this.BNKr_ResupplyFails);
        this.BNKr_SellSuccess_BCSuccess = this.Config.GetValue<int>("DisruptionLogistics", "SellSuccess_BCSuccess", this.BNKr_SellSuccess_BCSuccess);
        this.BNKr_SellSuccess_BCFails = this.Config.GetValue<int>("DisruptionLogistics", "SellSuccess_BCFails", this.BNKr_SellSuccess_BCFails);
        this.BNKr_SellSuccess_LSSuccess = this.Config.GetValue<int>("DisruptionLogistics", "SellSuccess_LSSuccess", this.BNKr_SellSuccess_LSSuccess);
        this.BNKr_SellSuccess_LSFails = this.Config.GetValue<int>("DisruptionLogistics", "SellSuccess_LSFails", this.BNKr_SellSuccess_LSFails);
        this.BNKr_ResearchCompletedCrt = this.Config.GetValue<int>("DisruptionLogistics", "ResearchCompletedCrt", this.BNKr_ResearchCompletedCrt);
        this.BNKr_UnitsManufactured = this.Config.GetValue<int>("DisruptionLogistics", "UnitsManufactured", this.BNKr_UnitsManufactured);
        this.BNKr_StaffAssignment = this.Config.GetValue<int>("DisruptionLogistics", "StaffAssignment", this.BNKr_StaffAssignment);
        this.BNKr_Upgrade1Unlocked = this.Config.GetValue<int>("DisruptionLogistics", "Upgrade1Unlocked", this.BNKr_Upgrade1Unlocked);
        this.BNKr_Upgrade2Unlocked = this.Config.GetValue<int>("DisruptionLogistics", "Upgrade2Unlocked", this.BNKr_Upgrade2Unlocked);
        this.BNKr_Upgrade3Unlocked = this.Config.GetValue<int>("DisruptionLogistics", "Upgrade3Unlocked", this.BNKr_Upgrade3Unlocked);
        this.BNKr_MultiplierSell = this.Config.GetValue<int>("DisruptionLogistics-misc", "MultiplierSell", this.BNKr_MultiplierSell);
        this.BNKr_MultiplierBuyCrate = this.Config.GetValue<int>("DisruptionLogistics-misc", "MultiplierBuyCrate", this.BNKr_MultiplierBuyCrate);
        this.BNKr_MultiplierBuyFt = this.Config.GetValue<int>("DisruptionLogistics-misc", "MultiplierBuyFt", this.BNKr_MultiplierBuyFt);
        this.BNKr_MultiplierUpg = this.Config.GetValue<int>("DisruptionLogistics-misc", "MultiplierUpg", this.BNKr_MultiplierUpg);
        this.BNKr_CurrentResearch = this.Config.GetValue<int>("DisruptionLogistics", "CurrentResearch", this.BNKr_CurrentResearch);
        this.ChairPropModel = this.Config.GetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~:C1 Config.ini Failed To Load.");
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
      this.modMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Vehicle Bay", "Select an Option");
      this.GUIMenus.Add(this.mainMenu2);
      this.modMenuPool2.Add(this.mainMenu2);
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Gun Runnning", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      UIMenuItem OpenGUI = new UIMenuItem("      Open Disruption Logistics Panel     ");
      this.mainMenu.AddItem(OpenGUI);
      this.mainMenu.AddItem(new UIMenuItem("                                        "));
      this.mainMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != OpenGUI)
          return;
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
        UI.Notify("Open GUI");
      });
      this.methgarage = this.modMenuPool.AddSubMenu(this.mainMenu, "Purchase Options");
      this.GUIMenus.Add(this.methgarage);
      this.ProductStock = this.modMenuPool.AddSubMenu(this.mainMenu, "Product Options");
      this.GUIMenus.Add(this.ProductStock);
      this.ShipmentDelivery = this.modMenuPool.AddSubMenu(this.mainMenu, "Shipment Missions");
      this.GUIMenus.Add(this.ShipmentDelivery);
      this.CoopElimination = this.modMenuPool.AddSubMenu(this.mainMenu, "Co-op Eliminaton (Missions)");
      this.GUIMenus.Add(this.CoopElimination);
      this.BikerRivallry = this.modMenuPool.AddSubMenu(this.mainMenu, "Fast Track (Missions)");
      this.GUIMenus.Add(this.BikerRivallry);
      this.AssetRecoveryMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Asset Recovery (Missions)");
      this.GUIMenus.Add(this.AssetRecoveryMenu);
      this.SpecialMissions = this.modMenuPool.AddSubMenu(this.mainMenu, "Special Missions (Missions)");
      this.GUIMenus.Add(this.SpecialMissions);
      this.Extras = this.modMenuPool.AddSubMenu(this.mainMenu, "Extras");
      this.GUIMenus.Add(this.Extras);
      this.MilitaryAsset = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Source a Military Vehicle");
      this.GUIMenus.Add(this.MilitaryAsset);
      this.Buy = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Buy a Gunrunning Vehicle");
      this.GUIMenus.Add(this.Buy);
      this.Customize = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Use a Gunrunning Vehicle");
      this.GUIMenus.Add(this.Customize);
      this.Missions = this.modMenuPool.AddSubMenu(this.mainMenu, "Missions");
      this.GUIMenus.Add(this.Missions);
      this.GunLockerMarker = new Vector3(897.129f, -3217.97f, -99.5f);
      this.GLmodMenuPool = new MenuPool();
      this.GLmainMenu = new UIMenu("Gunlocker", "Select an Option");
      this.GUIMenus.Add(this.GLmainMenu);
      this.GLmodMenuPool.Add(this.GLmainMenu);
      this.weaponsMenu = this.GLmodMenuPool.AddSubMenu(this.GLmainMenu, "Weapons");
      this.GUIMenus.Add(this.weaponsMenu);
      this.SetupWeapons();
      this.currentbank = 1;
      this.MVmodMenuPool = new MenuPool();
      this.MVmainMenu = new UIMenu("Gunrunning Business", "Select an Option");
      this.GUIMenus.Add(this.MVmainMenu);
      this.MVmodMenuPool.Add(this.MVmainMenu);
      this.MoneyMenu = this.MVmodMenuPool.AddSubMenu(this.MVmainMenu, "Money Options");
      this.GUIMenus.Add(this.MoneyMenu);
      this.SetupMoneyMenu();
      this.Exit = new Vector3(891.8754f, -3246.281f, -99.5f);
      this.DropPointSupply.Add(new Vector3(966f, -126f, 74f));
      this.DropPointSupply.Add(new Vector3(200f, 383f, 107f));
      this.DropPointSupply.Add(new Vector3(-606f, 338f, 84f));
      this.DropPointSupply.Add(new Vector3(-606f, 338f, 84f));
      this.DropPointSupply.Add(new Vector3(-1539f, -76f, 53f));
      this.DropPointSupply.Add(new Vector3(-2077f, -313f, 12f));
      this.DropPointSupply.Add(new Vector3(-1451f, -364f, 43f));
      this.DropPointSupply.Add(new Vector3(-587f, -1112f, 22f));
      this.DropPointSupply.Add(new Vector3(102.6f, 6634.6f, 30f));
      this.DropPointSupply.Add(new Vector3(-172.8f, 6452.8f, 29f));
      this.DropPointSupply.Add(new Vector3(-265.1f, 6335.5f, 30f));
      this.DropPointSupply.Add(new Vector3(-697.3f, 5772.9f, 15f));
      this.DropPointSupply.Add(new Vector3(-575.2f, 5335.6f, 68f));
      this.DropPointSupply.Add(new Vector3(35.9f, 6284.5f, 29f));
      this.DropPointSupply.Add(new Vector3(1724f, 6399.4f, 31f));
      this.DropPointSupply.Add(new Vector3(2467.7f, 4961.9f, 43f));
      this.DropPointSupply.Add(new Vector3(2104.9f, 4767.5f, 39f));
      this.DropPointSupply.Add(new Vector3(1501.6f, 3763.7f, 31f));
      this.DropPointSupply.Add(new Vector3(1374.5f, 3602.9f, 33f));
      this.DropPointSupply.Add(new Vector3(1689.4f, 3310.9f, 39f));
      this.DropPointSupply.Add(new Vector3(1989f, 3032f, 46f));
      this.DropPointSupply.Add(new Vector3(2320.1f, 2499.5f, 45f));
      this.DropPointSupply.Add(new Vector3(2365.2f, 2644.9f, 45f));
      this.DropPointSupply.Add(new Vector3(2411.1f, 3058.2f, 46f));
      this.DropPointSupply.Add(new Vector3(2812.8f, 1589.4f, 22f));
      this.DropPointSupply.Add(new Vector3(-1567.1f, 2770.7f, 15f));
      this.DropPointSupply.Add(new Vector3(-1911.4f, 2061f, 138f));
      this.DropPointSupply.Add(new Vector3(-310.8f, 2739.6f, 65f));
      this.DropPointSupply.Add(new Vector3(-288.5f, 2568.7f, 70f));
      this.DropPointSupply.Add(new Vector3(-85.6f, 2805.1f, 51f));
      this.DropPointSupply.Add(new Vector3(42.2f, 2786f, 56f));
      this.DropPointSupply.Add(new Vector3(216.7f, 2462.3f, 54f));
      this.IPCreatedPeds = false;
      this.SetupPeds();
      this.IPLoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//InteriorDesign.ini");
      this.IPCrateProps();
      this.SetupPropSpawns();
      this.SetupMarker();
      this.SetupCustomisation();
      this.SetupVehicleBay();
      this.SetupBuy();
      this.SetupVehicleCustomize();
      this.SetupProduct();
      this.Setupbuisness();
      this.setupmissions();
      this.SetupShipment();
      this.SetupAssetRecovery();
      this.SetupBikerRivalry();
      this.CoopEliminationmissions();
      this.SetupSpecialMissions();
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    private void CoopEliminationmissions()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.CoopElimination, "Co-op Elimination Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (Dune FAV) ");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 (HalfTrack) ");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Mission 3 (Technical Custom) ");
      uiMenu.AddItem(Mission3);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission3)
        {
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          if ((Entity) this.Bike1 != (Entity) null)
            this.Bike1.Delete();
          if (this.Bike1Blip != (Blip) null)
            this.Bike1Blip.Remove();
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.Technical3, this.SpawnPos);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 120f, 1);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.HalfTrack;
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike1Blip.Name = "Enemy Technical Custom A";
          this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.Technical3, this.Entry);
          Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.LeftRear);
          this.DeliveryVehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Agent14);
          this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = 0;
          Ped pedOnSeat = this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
          this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(this.Bike1.GetPedOnSeat(VehicleSeat.Driver));
          this.DeliveryVehicle.IsDriveable = true;
          this.DeliveryVehicle.SetMod(VehicleMod.Roof, 1, true);
          if ((Entity) this.Caddy != (Entity) null)
            this.Caddy.Delete();
          if ((Entity) this.JuggernautPed != (Entity) null)
            this.JuggernautPed.Delete();
          if ((Entity) this.Moc1 != (Entity) null)
            this.Moc1.Delete();
          if ((Entity) this.Moc2 != (Entity) null)
            this.Moc2.Delete();
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
        }
        if (item == Mission2)
        {
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          if ((Entity) this.Bike1 != (Entity) null)
            this.Bike1.Delete();
          if (this.Bike1Blip != (Blip) null)
            this.Bike1Blip.Remove();
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.SpawnPos);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 120f, 1);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.HalfTrack;
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike1Blip.Name = "Enemy Half Track A";
          this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Entry);
          Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.LeftRear);
          this.DeliveryVehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Agent14);
          this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = 0;
          Ped pedOnSeat = this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
          this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(this.Bike1.GetPedOnSeat(VehicleSeat.Driver));
          this.DeliveryVehicle.IsDriveable = true;
          this.DeliveryVehicle.SetMod(VehicleMod.Roof, 1, true);
          if ((Entity) this.Caddy != (Entity) null)
            this.Caddy.Delete();
          if ((Entity) this.JuggernautPed != (Entity) null)
            this.JuggernautPed.Delete();
          if ((Entity) this.Moc1 != (Entity) null)
            this.Moc1.Delete();
          if ((Entity) this.Moc2 != (Entity) null)
            this.Moc2.Delete();
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
        }
        if (item != Mission1)
          return;
        if ((Entity) this.DeliveryVehicle != (Entity) null)
          this.DeliveryVehicle.Delete();
        if ((Entity) this.Bike1 != (Entity) null)
          this.Bike1.Delete();
        if (this.Bike1Blip != (Blip) null)
          this.Bike1Blip.Remove();
        this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
        this.Bike1 = World.CreateVehicle((Model) VehicleHash.Dune3, this.SpawnPos);
        this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
        this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 120f, 1);
        this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
        this.Bike1Blip.Sprite = BlipSprite.DuneFAV;
        this.Bike1Blip.Color = BlipColor.Red;
        this.Bike1Blip.Name = "Enemy Dune Fav A";
        this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.Dune3, this.Entry);
        Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Passenger);
        this.DeliveryVehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Agent14);
        this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = 0;
        Ped pedOnSeat1 = this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
        this.DeliveryVehicle.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(this.Bike1.GetPedOnSeat(VehicleSeat.Driver));
        this.DeliveryVehicle.IsDriveable = true;
        this.DeliveryVehicle.SetMod(VehicleMod.Roof, 1, true);
        if ((Entity) this.Caddy != (Entity) null)
          this.Caddy.Delete();
        if ((Entity) this.JuggernautPed != (Entity) null)
          this.JuggernautPed.Delete();
        if ((Entity) this.Moc1 != (Entity) null)
          this.Moc1.Delete();
        if ((Entity) this.Moc2 != (Entity) null)
          this.Moc2.Delete();
        this.VehicleSetup2 = true;
        this.vehiclemissionid = 9;
      });
    }

    private void SetupBikerRivalry()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.BikerRivallry, "Fast Track Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (Dune FAV)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 (HalfTrack)");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Mission 3 (Technical Custom)");
      uiMenu.AddItem(Mission3);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission3)
        {
          if ((Entity) this.Bike1 != (Entity) null)
            this.Bike1.Delete();
          if ((Entity) this.Bike2 != (Entity) null)
            this.Bike2.Delete();
          if ((Entity) this.Bike3 != (Entity) null)
            this.Bike3.Delete();
          if ((Entity) this.Bike4 != (Entity) null)
            this.Bike4.Delete();
          if ((Entity) this.Bike5 != (Entity) null)
            this.Bike5.Delete();
          if (this.Bike1Blip != (Blip) null)
            this.Bike1Blip.Remove();
          if (this.Bike2Blip != (Blip) null)
            this.Bike2Blip.Remove();
          if (this.Bike3Blip != (Blip) null)
            this.Bike3Blip.Remove();
          if (this.Bike4Blip != (Blip) null)
            this.Bike4Blip.Remove();
          if (this.Bike5Blip != (Blip) null)
            this.Bike5Blip.Remove();
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.Technical3, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.Technical3, this.Spawn1);
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.Technical3, this.Spawn2);
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.Technical3, this.Spawn3);
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.Technical3, this.Spawn4);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmLieut01GMM);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmBoss01GMM);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          System.Random random = new System.Random();
          this.Bike1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike4.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike5.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike1.SetMod(VehicleMod.Roof, -1, true);
          this.Bike2.SetMod(VehicleMod.Roof, -1, true);
          this.Bike3.SetMod(VehicleMod.Roof, -1, true);
          this.Bike4.SetMod(VehicleMod.Roof, -1, true);
          this.Bike5.SetMod(VehicleMod.Roof, -1, true);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.TechnicalAqua;
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike1Blip.Name = "Enemy Technical Custom A";
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.TechnicalAqua;
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike2Blip.Name = "Enemy Technical Custom B";
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.TechnicalAqua;
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike3Blip.Name = "Enemy Technical Custom C";
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.TechnicalAqua;
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike4Blip.Name = "Enemy Technical Custom D";
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.TechnicalAqua;
          this.Bike5Blip.Color = BlipColor.Red;
          this.Bike5Blip.Name = "Enemy Technical Custom E";
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 8;
          UI.Notify(this.GetHostName() + " Boss weve spotted a bunch of Technical Customs moving very fast,destroying anything that comes near we need to destroy them!");
        }
        if (item == Mission2)
        {
          if ((Entity) this.Bike1 != (Entity) null)
            this.Bike1.Delete();
          if ((Entity) this.Bike2 != (Entity) null)
            this.Bike2.Delete();
          if ((Entity) this.Bike3 != (Entity) null)
            this.Bike3.Delete();
          if ((Entity) this.Bike4 != (Entity) null)
            this.Bike4.Delete();
          if ((Entity) this.Bike5 != (Entity) null)
            this.Bike5.Delete();
          if (this.Bike1Blip != (Blip) null)
            this.Bike1Blip.Remove();
          if (this.Bike2Blip != (Blip) null)
            this.Bike2Blip.Remove();
          if (this.Bike3Blip != (Blip) null)
            this.Bike3Blip.Remove();
          if (this.Bike4Blip != (Blip) null)
            this.Bike4Blip.Remove();
          if (this.Bike5Blip != (Blip) null)
            this.Bike5Blip.Remove();
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Spawn1);
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Spawn2);
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Spawn3);
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Spawn4);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmLieut01GMM);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmBoss01GMM);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          System.Random random = new System.Random();
          this.Bike1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike4.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike5.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Bike1.SetMod(VehicleMod.Roof, -1, true);
          this.Bike2.SetMod(VehicleMod.Roof, -1, true);
          this.Bike3.SetMod(VehicleMod.Roof, -1, true);
          this.Bike4.SetMod(VehicleMod.Roof, -1, true);
          this.Bike5.SetMod(VehicleMod.Roof, -1, true);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.HalfTrack;
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike1Blip.Name = "Enemy Halftrack A";
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.HalfTrack;
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike2Blip.Name = "Enemy Halftrack B";
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.HalfTrack;
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike3Blip.Name = "Enemy Halftrack C";
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.HalfTrack;
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike4Blip.Name = "Enemy Halftrack D";
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.HalfTrack;
          this.Bike5Blip.Color = BlipColor.Red;
          this.Bike5Blip.Name = "Enemy Halftrack E";
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 8;
          UI.Notify(this.GetHostName() + " Boss weve spotted a bunch of HalfTracks moving very fast,destroying anything that comes near we need to destroy them!");
        }
        if (item != Mission1)
          return;
        if ((Entity) this.Bike1 != (Entity) null)
          this.Bike1.Delete();
        if ((Entity) this.Bike2 != (Entity) null)
          this.Bike2.Delete();
        if ((Entity) this.Bike3 != (Entity) null)
          this.Bike3.Delete();
        if ((Entity) this.Bike4 != (Entity) null)
          this.Bike4.Delete();
        if ((Entity) this.Bike5 != (Entity) null)
          this.Bike5.Delete();
        if (this.Bike1Blip != (Blip) null)
          this.Bike1Blip.Remove();
        if (this.Bike2Blip != (Blip) null)
          this.Bike2Blip.Remove();
        if (this.Bike3Blip != (Blip) null)
          this.Bike3Blip.Remove();
        if (this.Bike4Blip != (Blip) null)
          this.Bike4Blip.Remove();
        if (this.Bike5Blip != (Blip) null)
          this.Bike5Blip.Remove();
        this.Bike1 = World.CreateVehicle((Model) VehicleHash.Dune3, this.Spawn);
        this.Bike2 = World.CreateVehicle((Model) VehicleHash.Dune3, this.Spawn1);
        this.Bike3 = World.CreateVehicle((Model) VehicleHash.Dune3, this.Spawn2);
        this.Bike4 = World.CreateVehicle((Model) VehicleHash.Dune3, this.Spawn3);
        this.Bike5 = World.CreateVehicle((Model) VehicleHash.Dune3, this.Spawn4);
        this.Bike1.PlaceOnNextStreet();
        this.Bike2.PlaceOnNextStreet();
        this.Bike3.PlaceOnNextStreet();
        this.Bike4.PlaceOnNextStreet();
        this.Bike5.PlaceOnNextStreet();
        this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
        this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
        this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmLieut01GMM);
        this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 150f, 1);
        this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
        this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 150f, 1);
        this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
        this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 150f, 1);
        this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
        this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmBoss01GMM);
        this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 150f, 1);
        this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        System.Random random1 = new System.Random();
        this.Bike1.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike2.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike3.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike4.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike5.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Bike1.SetMod(VehicleMod.Roof, -1, true);
        this.Bike2.SetMod(VehicleMod.Roof, -1, true);
        this.Bike3.SetMod(VehicleMod.Roof, -1, true);
        this.Bike4.SetMod(VehicleMod.Roof, -1, true);
        this.Bike5.SetMod(VehicleMod.Roof, -1, true);
        this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
        this.Bike1Blip.Sprite = BlipSprite.DuneFAV;
        this.Bike1Blip.Color = BlipColor.Red;
        this.Bike1Blip.Name = "Enemy Dune Fav A";
        this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
        this.Bike2Blip.Sprite = BlipSprite.DuneFAV;
        this.Bike2Blip.Color = BlipColor.Red;
        this.Bike2Blip.Name = "Enemy Dune Fav B";
        this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
        this.Bike3Blip.Sprite = BlipSprite.DuneFAV;
        this.Bike3Blip.Color = BlipColor.Red;
        this.Bike3Blip.Name = "Enemy Dune Fav C";
        this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
        this.Bike4Blip.Sprite = BlipSprite.DuneFAV;
        this.Bike4Blip.Color = BlipColor.Red;
        this.Bike4Blip.Name = "Enemy Dune Fav D";
        this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
        this.Bike5Blip.Sprite = BlipSprite.DuneFAV;
        this.Bike5Blip.Color = BlipColor.Red;
        this.Bike5Blip.Name = "Enemy Dune Fav E";
        this.VehicleSetup2 = true;
        this.vehiclemissionid = 8;
        UI.Notify(this.GetHostName() + " Boss weve spotted a bunch of Dune FAVs moving very fast,destroying anything that comes near we need to destroy them!");
      });
    }

    private void SetupAssetRecovery()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.AssetRecoveryMenu, "Asset Recovery Options");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 Target: Hard");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 Target: Hard");
      uiMenu.AddItem(Mission2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission2)
        {
          this.TriggeredWanted = false;
          this.Missionnum = 4;
          if ((Entity) this.VehicleId != (Entity) null)
            this.VehicleId.Delete();
          this.VehicleLoc = new System.Random();
          if (this.VehicleLoc.Next(1, 2) == 1)
            this.VehicleLocation = new Vector3(-1933f, 3128.89f, 33f);
          if (this.VehicleLoc.Next(1, 2) == 2)
            this.VehicleLocation = new Vector3(-1837.171f, 2995.09f, 33f);
          this.VehicleRan = new System.Random();
          if (this.VehicleRan.Next(1, 4) == 1)
          {
            this.carid = "Halftrack";
            this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.VehicleLocation);
            this.VehicleMissioncar.PlaceOnGround();
          }
          if (this.VehicleRan.Next(1, 4) == 2)
          {
            this.carid = "APC";
            this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.APC, this.VehicleLocation);
            this.VehicleMissioncar.PlaceOnGround();
          }
          if (this.VehicleRan.Next(1, 4) == 3)
          {
            this.carid = "Khanjari";
            this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Khanjari, this.VehicleLocation);
            this.VehicleMissioncar.PlaceOnGround();
          }
          if (this.VehicleRan.Next(1, 4) == 4)
          {
            this.carid = "Chernobog";
            this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Chernobog, this.VehicleLocation);
            this.VehicleMissioncar.PlaceOnGround();
          }
          if (this.DestoryVehicle != (Blip) null)
            this.DestoryVehicle.Remove();
          this.DestoryVehicle = World.CreateBlip(this.VehicleLocation);
          this.DestoryVehicle.Sprite = BlipSprite.Tank;
          this.DestoryVehicle.Color = BlipColor.White;
          this.DestoryVehicle.Name = "Retreive Vehicle";
          this.setupdelivery = true;
          this.RandomWanted = new System.Random();
          this.randomwantedwait = new System.Random();
          this.setupwantedfordelivery = true;
          this.VehicleSetup = true;
          float num = (float) (225000.0 + 225000.0 * (double) this.profitMargin / 100.0);
          UI.Notify(this.GetHostName() + " Retreive this vehicle and bring it to the Vehicle Stoage and we earn " + num.ToString() + " in stock value");
          UI.Notify(this.GetHostName() + " id on car is a " + this.carid);
        }
        if (item != Mission1)
          return;
        this.TriggeredWanted = false;
        this.Missionnum = 3;
        this.VehicleLoc = new System.Random();
        if (this.VehicleLoc.Next(1, 2) == 1)
          this.VehicleLocation = new Vector3((float) byte.MaxValue, 3633.3f, 33f);
        if (this.VehicleLoc.Next(1, 2) == 2)
          this.VehicleLocation = new Vector3(200f, 3515f, 34f);
        this.VehicleRan = new System.Random();
        if (this.VehicleRan.Next(1, 2) == 1)
        {
          this.carid = "Techcal Aqua";
          this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Technical2, this.VehicleLocation);
          this.VehicleMissioncar.PlaceOnGround();
        }
        if (this.VehicleRan.Next(1, 2) == 2)
        {
          this.carid = "Blazer Aqua";
          this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Blazer5, this.VehicleLocation);
          this.VehicleMissioncar.PlaceOnGround();
        }
        if (this.DestoryVehicle != (Blip) null)
          this.DestoryVehicle.Remove();
        this.DestoryVehicle = World.CreateBlip(this.VehicleLocation);
        this.DestoryVehicle.Sprite = BlipSprite.GunCar;
        this.DestoryVehicle.Color = BlipColor.White;
        this.DestoryVehicle.Name = "Retreive Vehicle";
        this.setupdelivery = true;
        this.RandomWanted = new System.Random();
        this.randomwantedwait = new System.Random();
        this.setupwantedfordelivery = true;
        this.VehicleSetup = true;
        this.warnedplayer = true;
        float num1 = (float) (425000.0 + 425000.0 * (double) this.profitMargin / 100.0);
        UI.Notify(this.GetHostName() + " Retreive this vehicle and bring it to the Vehicle Stoage and we earn " + num1.ToString() + " in stock value");
        UI.Notify(this.GetHostName() + " id on car is a " + this.carid);
      });
    }

    private void setupmissions()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.Missions, "Assassination Missions");
      this.GUIMenus.Add(uiMenu1);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1: pay out = 25,000");
      uiMenu1.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2:s pay out = 100,000");
      uiMenu1.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Mission 3: pay out = 250,000");
      uiMenu1.AddItem(Mission3);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.Missions, "Product Missions");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem Mission1p = new UIMenuItem("Mission 1 Moving Target: Easy");
      uiMenu2.AddItem(Mission1p);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Mission1p)
          return;
        this.Missionnum = 1;
        if ((Entity) this.VehicleId != (Entity) null)
          this.VehicleId.Delete();
        this.VehicleLoc = new System.Random();
        if (this.VehicleLoc.Next(1, 3) == 1)
          this.VehicleLocation = new Vector3(-569.666f, 5688.05f, 38f);
        if (this.VehicleLoc.Next(1, 3) == 2)
          this.VehicleLocation = new Vector3(-1500.38f, 4999.26f, 63f);
        if (this.VehicleLoc.Next(1, 3) == 3)
          this.VehicleLocation = new Vector3(-2449.21f, 3774.93f, 19f);
        this.VehicleRan = new System.Random();
        if (this.VehicleRan.Next(1, 2) == 1)
        {
          this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Barracks, this.VehicleLocation);
          this.VehicleMissioncar.PlaceOnGround();
          this.VehicleMissioncar.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Highsec01SMM);
          this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
          this.carid = "Barracks";
        }
        if (this.VehicleRan.Next(1, 2) == 2)
        {
          this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Barracks2, this.VehicleLocation);
          this.VehicleMissioncar.PlaceOnGround();
          this.VehicleMissioncar.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Highsec01SMM);
          this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
          this.carid = "Barracks 2";
        }
        if (this.DestoryVehicle != (Blip) null)
          this.DestoryVehicle.Remove();
        this.DestoryVehicle = World.CreateBlip(this.VehicleLocation);
        this.DestoryVehicle.Sprite = BlipSprite.GunCar;
        this.DestoryVehicle.Color = BlipColor.White;
        this.DestoryVehicle.Name = "Destroy Target";
        this.setupdelivery = true;
        this.RandomWanted = new System.Random();
        this.randomwantedwait = new System.Random();
        this.setupwantedfordelivery = true;
        this.VehicleSetup = true;
        float num = (float) (25000.0 + 25000.0 * (double) this.profitMargin / 100.0);
        UI.Notify(this.GetHostName() + " Destroy this vehicle and we earn " + num.ToString() + " in stock value");
        UI.Notify(this.GetHostName() + " id on car is a " + this.carid);
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission1)
        {
          if (this.Enemy != (Blip) null)
            this.Enemy.Remove();
          if ((Entity) this.EnemyPed != (Entity) null)
            this.EnemyPed.Delete();
          this.EnemyLoc = new Vector3(-486.84f, 263f, 83f);
          this.EnemyPed = World.CreatePed((Model) PedHash.Genfat02AMM, this.EnemyLoc);
          this.EnemyPed.Task.WanderAround();
          this.EnemyPed.Weapons.Give(WeaponHash.APPistol, 9999, true, true);
          this.Enemy = World.CreateBlip(this.EnemyPed.Position);
          this.Enemy.Sprite = BlipSprite.Enemy;
          this.Enemy.Color = BlipColor.Red;
          this.EnemySetup = true;
          this.assassinationmission = 1;
          this.assassinationpayout = 25000;
          UI.Notify(this.GetHostName() + " OK i got an easy target, $25000 pay out");
          this.Chooseenemynum = 1;
        }
        if (item == Mission2)
        {
          if (this.Enemy != (Blip) null)
            this.Enemy.Remove();
          if ((Entity) this.EnemyPed != (Entity) null)
            this.EnemyPed.Delete();
          this.EnemyLoc = new Vector3(-1715.58f, -219.9f, 57.94f);
          this.EnemyPed = World.CreatePed((Model) PedHash.Eastsa02AFM, this.EnemyLoc);
          this.EnemyPed.Task.WanderAround();
          this.EnemyPed.Weapons.Give(WeaponHash.SMG, 9999, true, true);
          this.Enemy = World.CreateBlip(this.EnemyPed.Position);
          this.Enemy.Sprite = BlipSprite.Enemy;
          this.Enemy.Color = BlipColor.Red;
          this.EnemySetup = true;
          this.assassinationmission = 2;
          this.assassinationpayout = 100000;
          UI.Notify(this.GetHostName() + " OK i got an easy target, $100000 pay out");
          this.Chooseenemynum = 2;
        }
        if (item != Mission3)
          return;
        if (this.Enemy != (Blip) null)
          this.Enemy.Remove();
        if ((Entity) this.EnemyPed != (Entity) null)
          this.EnemyPed.Delete();
        this.EnemyLoc = new Vector3(-0.17f, -303.9f, 45.94f);
        this.EnemyPed = World.CreatePed((Model) PedHash.CounterfeitMale01, this.EnemyLoc);
        this.EnemyPed.Task.WanderAround();
        Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) this.EnemyPed, (InputArgument) 3686625920U, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
        this.Enemy = World.CreateBlip(this.EnemyPed.Position);
        this.Enemy.Sprite = BlipSprite.Enemy;
        this.Enemy.Color = BlipColor.Red;
        this.EnemySetup = true;
        this.assassinationmission = 3;
        this.assassinationpayout = 250000;
        UI.Notify(this.GetHostName() + " OK i got an medium target, $250000 pay out");
        this.Chooseenemynum = 3;
      });
    }

    public void SetupShipment()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.ShipmentDelivery, "Delivery");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.ShipmentDelivery, "Pickup");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem Mission1D = new UIMenuItem("(Delivery), Dune FAV ");
      uiMenu1.AddItem(Mission1D);
      UIMenuItem Mission2D = new UIMenuItem("(Delivery), APC");
      uiMenu1.AddItem(Mission2D);
      UIMenuItem Mission3D = new UIMenuItem("(Delivery), Halftrack ");
      uiMenu1.AddItem(Mission3D);
      UIMenuItem Mission4D = new UIMenuItem("(Delivery), Weaponized Tampa ");
      uiMenu1.AddItem(Mission4D);
      UIMenuItem Mission1S = new UIMenuItem("(Collection), Halftrack");
      uiMenu2.AddItem(Mission1S);
      UIMenuItem Mission2S = new UIMenuItem("(Collection), APC");
      uiMenu2.AddItem(Mission2S);
      UIMenuItem Mission3S = new UIMenuItem("(Collection), Weaponized Tampa");
      uiMenu2.AddItem(Mission3S);
      UIMenuItem Mission4S = new UIMenuItem("(Collection), Dune Fav");
      uiMenu2.AddItem(Mission4S);
      UIMenuItem Mission5S = new UIMenuItem("(Collection), Ardent");
      uiMenu2.AddItem(Mission5S);
      UIMenuItem Mission6S = new UIMenuItem("(Collection), Insurgent Custom");
      uiMenu2.AddItem(Mission6S);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission1D)
        {
          this.IsSittinginCeoSeat = false;
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          if (this.DropPointBlip != (Blip) null)
            this.DropPointBlip.Remove();
          this.DeliveryMission = 1;
          this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.Dune3, this.Entry);
          Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Driver);
          this.DeliveryVehicle.IsDriveable = true;
          this.ShipmentName = this.DeliveryVehicle.FriendlyName;
          this.DropPointBlip = World.CreateBlip(this.DropPoint);
          this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
          this.DropPointBlip.Color = BlipColor.Red;
          this.DropPointBlip.Name = "Deliver Vehicle";
          if ((Entity) this.Caddy != (Entity) null)
            this.Caddy.Delete();
          if ((Entity) this.JuggernautPed != (Entity) null)
            this.JuggernautPed.Delete();
          if ((Entity) this.Moc1 != (Entity) null)
            this.Moc1.Delete();
          if ((Entity) this.Moc2 != (Entity) null)
            this.Moc2.Delete();
          Script.Wait(1000);
          Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Driver);
          UI.Notify(this.GetHostName() + " ok boss deliver this vehicle it to the location for a reward");
        }
        if (item == Mission2D)
        {
          this.IsSittinginCeoSeat = false;
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          if (this.DropPointBlip != (Blip) null)
            this.DropPointBlip.Remove();
          this.DeliveryMission = 1;
          this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.APC, this.Entry);
          Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Driver);
          this.DeliveryVehicle.IsDriveable = true;
          this.ShipmentName = this.DeliveryVehicle.FriendlyName;
          this.DropPointBlip = World.CreateBlip(this.DropPoint);
          this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
          this.DropPointBlip.Color = BlipColor.Red;
          this.DropPointBlip.Name = "Deliver Vehicle";
          if ((Entity) this.Caddy != (Entity) null)
            this.Caddy.Delete();
          if ((Entity) this.JuggernautPed != (Entity) null)
            this.JuggernautPed.Delete();
          if ((Entity) this.Moc1 != (Entity) null)
            this.Moc1.Delete();
          if ((Entity) this.Moc2 != (Entity) null)
            this.Moc2.Delete();
          Script.Wait(1000);
          Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Driver);
          UI.Notify(this.GetHostName() + " ok boss deliver this vehicle it to the location for a reward");
        }
        if (item == Mission3D)
        {
          this.IsSittinginCeoSeat = false;
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          if (this.DropPointBlip != (Blip) null)
            this.DropPointBlip.Remove();
          this.DeliveryMission = 1;
          this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Entry);
          Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Driver);
          this.DeliveryVehicle.IsDriveable = true;
          this.ShipmentName = this.DeliveryVehicle.FriendlyName;
          this.DropPointBlip = World.CreateBlip(this.DropPoint);
          this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
          this.DropPointBlip.Color = BlipColor.Red;
          this.DropPointBlip.Name = "Deliver Vehicle";
          if ((Entity) this.Caddy != (Entity) null)
            this.Caddy.Delete();
          if ((Entity) this.JuggernautPed != (Entity) null)
            this.JuggernautPed.Delete();
          if ((Entity) this.Moc1 != (Entity) null)
            this.Moc1.Delete();
          if ((Entity) this.Moc2 != (Entity) null)
            this.Moc2.Delete();
          Script.Wait(1000);
          Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Driver);
          UI.Notify(this.GetHostName() + " ok boss deliver this vehicle it to the location for a reward");
        }
        if (item != Mission4D)
          return;
        this.IsSittinginCeoSeat = false;
        if ((Entity) this.DeliveryVehicle != (Entity) null)
          this.DeliveryVehicle.Delete();
        if (this.DropPointBlip != (Blip) null)
          this.DropPointBlip.Remove();
        this.DeliveryMission = 1;
        this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.Tampa3, this.Entry);
        Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Driver);
        this.DeliveryVehicle.IsDriveable = true;
        this.ShipmentName = this.DeliveryVehicle.FriendlyName;
        this.DropPointBlip = World.CreateBlip(this.DropPoint);
        this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
        this.DropPointBlip.Color = BlipColor.Red;
        this.DropPointBlip.Name = "Deliver Vehicle";
        if ((Entity) this.Caddy != (Entity) null)
          this.Caddy.Delete();
        if ((Entity) this.JuggernautPed != (Entity) null)
          this.JuggernautPed.Delete();
        if ((Entity) this.Moc1 != (Entity) null)
          this.Moc1.Delete();
        if ((Entity) this.Moc2 != (Entity) null)
          this.Moc2.Delete();
        Script.Wait(1000);
        Game.Player.Character.SetIntoVehicle(this.DeliveryVehicle, VehicleSeat.Driver);
        UI.Notify(this.GetHostName() + " ok boss deliver this vehicle it to the location for a reward");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission1S)
        {
          if (this.DropPointBlip != (Blip) null)
            this.DropPointBlip.Remove();
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          this.DropPointBlip = World.CreateBlip(this.DropPoint);
          this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
          this.DropPointBlip.Color = BlipColor.Red;
          this.DropPointBlip.Name = "Collect Vehicle";
          this.IsSittinginCeoSeat = false;
          this.DeliveryMission = 2;
          this.SetupVehicles = true;
          this.ShipmentVehicleID = VehicleHash.HalfTrack;
          UI.Notify(this.GetHostName() + " ok go retrieve the vehicle and bring it back to the bunker, the vehicle is located at the drop off point");
        }
        if (item == Mission2S)
        {
          if (this.DropPointBlip != (Blip) null)
            this.DropPointBlip.Remove();
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          this.DropPointBlip = World.CreateBlip(this.DropPoint);
          this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
          this.DropPointBlip.Color = BlipColor.Red;
          this.DropPointBlip.Name = "Collect Vehicle";
          this.IsSittinginCeoSeat = false;
          this.DeliveryMission = 2;
          this.SetupVehicles = true;
          this.ShipmentVehicleID = VehicleHash.APC;
          UI.Notify(this.GetHostName() + " ok go retrieve the vehicle and bring it back to the bunker, the vehicle is located at the drop off point");
        }
        if (item == Mission3S)
        {
          if (this.DropPointBlip != (Blip) null)
            this.DropPointBlip.Remove();
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          this.DropPointBlip = World.CreateBlip(this.DropPoint);
          this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
          this.DropPointBlip.Color = BlipColor.Red;
          this.DropPointBlip.Name = "Collect Vehicle";
          this.IsSittinginCeoSeat = false;
          this.DeliveryMission = 2;
          this.SetupVehicles = true;
          this.ShipmentVehicleID = VehicleHash.Tampa3;
          UI.Notify(this.GetHostName() + " ok go retrieve the vehicle and bring it back to the bunker, the vehicle is located at the drop off point");
        }
        if (item == Mission4S)
        {
          if (this.DropPointBlip != (Blip) null)
            this.DropPointBlip.Remove();
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          this.DropPointBlip = World.CreateBlip(this.DropPoint);
          this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
          this.DropPointBlip.Color = BlipColor.Red;
          this.DropPointBlip.Name = "Collect Vehicle";
          this.IsSittinginCeoSeat = false;
          this.DeliveryMission = 2;
          this.SetupVehicles = true;
          this.ShipmentVehicleID = VehicleHash.Dune3;
          UI.Notify(this.GetHostName() + " ok go retrieve the vehicle and bring it back to the bunker, the vehicle is located at the drop off point");
        }
        if (item == Mission5S)
        {
          if (this.DropPointBlip != (Blip) null)
            this.DropPointBlip.Remove();
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          this.DropPointBlip = World.CreateBlip(this.DropPoint);
          this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
          this.DropPointBlip.Color = BlipColor.Red;
          this.DropPointBlip.Name = "Collect Vehicle";
          this.IsSittinginCeoSeat = false;
          this.DeliveryMission = 2;
          this.SetupVehicles = true;
          this.ShipmentVehicleID = VehicleHash.Ardent;
          UI.Notify(this.GetHostName() + " ok go retrieve the vehicle and bring it back to the bunker, the vehicle is located at the drop off point");
        }
        if (item != Mission6S)
          return;
        if (this.DropPointBlip != (Blip) null)
          this.DropPointBlip.Remove();
        if ((Entity) this.DeliveryVehicle != (Entity) null)
          this.DeliveryVehicle.Delete();
        this.DropPointBlip = World.CreateBlip(this.DropPoint);
        this.DropPointBlip.Sprite = BlipSprite.CrateDrop;
        this.DropPointBlip.Color = BlipColor.Red;
        this.DropPointBlip.Name = "Collect Vehicle";
        this.IsSittinginCeoSeat = false;
        this.DeliveryMission = 2;
        this.SetupVehicles = true;
        this.ShipmentVehicleID = VehicleHash.Insurgent3;
        UI.Notify(this.GetHostName() + " ok go retrieve the vehicle and bring it back to the bunker, the vehicle is located at the drop off point");
      });
    }

    public void SetupBuy()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Buy, "Buy a Vehicle");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem DuneFav = new UIMenuItem("DuneFav : $850,000");
      uiMenu.AddItem(DuneFav);
      UIMenuItem WT = new UIMenuItem("Weaponized Tampa : $1,585,000");
      uiMenu.AddItem(WT);
      UIMenuItem TC = new UIMenuItem("Technical Custom :$1,142,500");
      uiMenu.AddItem(TC);
      UIMenuItem IC = new UIMenuItem("Insurgent Custom : $1,202,500");
      uiMenu.AddItem(IC);
      UIMenuItem HT = new UIMenuItem("Half Track : $1,695,000");
      uiMenu.AddItem(HT);
      UIMenuItem NS = new UIMenuItem("NightShark : $1,245,000");
      uiMenu.AddItem(NS);
      UIMenuItem OP = new UIMenuItem("Oppressor : $2,650,000");
      uiMenu.AddItem(OP);
      UIMenuItem APC = new UIMenuItem("APC : $2,325,000");
      uiMenu.AddItem(APC);
      UIMenuItem uiMenuItem1 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem1);
      UIMenuItem MOC = new UIMenuItem("Mobile Operations Center : $4,000,000");
      uiMenu.AddItem(MOC);
      UIMenuItem AAT = new UIMenuItem("Purchase AA Trailer : $1,350,000");
      uiMenu.AddItem(AAT);
      UIMenuItem uiMenuItem2 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == AAT && this.Config.GetValue<int>("SPECIALVEHICLES", "TRAILERSMALL2", this.Trailersmall2Retrieved) == 0 && Game.Player.Money >= 1350000)
        {
          Game.Player.Money -= 1350000;
          this.Trailersmall2Retrieved = 1;
          this.Config.SetValue<int>("SPECIALVEHICLES", "TRAILERSMALL2", this.Trailersmall2Retrieved);
          this.Config.Save();
        }
        if (item == MOC && this.MOCBought == 0 && Game.Player.Money >= 4000000)
        {
          Game.Player.Money -= 4000000;
          this.MOCBought = 1;
          this.Config.SetValue<int>("MOC", "bought", this.MOCBought);
          this.Config.Save();
          this.SpawnMOC();
        }
        if (item == DuneFav)
        {
          if (this.Dune3Bought == 0)
          {
            if (Game.Player.Money >= 850000)
            {
              Game.Player.Money -= 850000;
              this.Dune3Bought = 1;
              this.Config.SetValue<int>("SPECIALVEHICLES", "DUNEFAVBought", this.Dune3Bought);
              this.Config.Save();
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\BunkerStorage\\dunefav.ini");
              this.ResetSourcedVehicle();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enought to purchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you have already purchased this vehicle");
        }
        if (item == WT)
        {
          if (this.TampaBought == 0)
          {
            if (Game.Player.Money >= 1585000)
            {
              Game.Player.Money -= 1585000;
              this.TampaBought = 1;
              this.Config.SetValue<int>("SPECIALVEHICLES", "TAMPA3Bought", this.TampaBought);
              this.Config.Save();
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\BunkerStorage\\weaponizedtampa.ini");
              this.ResetSourcedVehicle();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enought to purchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you have already purchased this vehicle");
        }
        if (item == TC)
        {
          if (this.TechnicalBought == 0)
          {
            if (Game.Player.Money >= 1142500)
            {
              Game.Player.Money -= 1142500;
              this.TechnicalBought = 1;
              this.Config.SetValue<int>("SPECIALVEHICLES", "TECHNICAL3Bought", this.TechnicalBought);
              this.Config.Save();
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\BunkerStorage\\technicalcustom.ini");
              this.ResetSourcedVehicle();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enought to purchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you have already purchased this vehicle");
        }
        if (item == IC)
        {
          if (this.InsurgentBought == 0)
          {
            if (Game.Player.Money >= 1202500)
            {
              Game.Player.Money -= 1202500;
              this.InsurgentBought = 1;
              this.Config.SetValue<int>("SPECIALVEHICLES", "INSURGENT3Bought", this.InsurgentBought);
              this.Config.Save();
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\BunkerStorage\\Insurgentcustom.ini");
              this.ResetSourcedVehicle();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enought to purchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you have already purchased this vehicle");
        }
        if (item == HT)
        {
          if (this.HalftrackBought == 0)
          {
            if (Game.Player.Money >= 1695000)
            {
              Game.Player.Money -= 1695000;
              this.HalftrackBought = 1;
              this.Config.GetValue<int>("SPECIALVEHICLES", "HALFTRACKBought", this.HalftrackBought);
              this.Config.Save();
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\BunkerStorage\\halftrack.ini");
              this.ResetSourcedVehicle();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enought to purchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you have already purchased this vehicle");
        }
        if (item == NS)
        {
          if (this.NightSharkBought == 0)
          {
            if (Game.Player.Money >= 1245000)
            {
              Game.Player.Money -= 1245000;
              this.NightSharkBought = 1;
              this.Config.SetValue<int>("SPECIALVEHICLES", "NIGHTSHARKBought", this.NightSharkBought);
              this.Config.Save();
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\BunkerStorage\\nightshark.ini");
              this.ResetSourcedVehicle();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enought to purchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you have already purchased this vehicle");
        }
        if (item == OP)
        {
          if (this.OppressorBought == 0)
          {
            if (Game.Player.Money >= 2650000)
            {
              Game.Player.Money -= 2650000;
              this.OppressorBought = 1;
              this.Config.SetValue<int>("SPECIALVEHICLES", "OPPRESSORBought", this.OppressorBought);
              this.Config.Save();
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\BunkerStorage\\oppressor.ini");
              this.ResetSourcedVehicle();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enought to purchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you have already purchased this vehicle");
        }
        if (item != APC)
          return;
        if (this.APCBought == 0)
        {
          if (Game.Player.Money >= 2325000)
          {
            Game.Player.Money -= 2325000;
            this.APCBought = 1;
            this.Config.SetValue<int>("SPECIALVEHICLES", "APCBought", this.APCBought);
            this.Config.Save();
            this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\BunkerStorage\\apc.ini");
            this.ResetSourcedVehicle();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you dont have enought to purchase this vehicle!");
        }
        else
          UI.Notify(this.GetHostName() + " Sorry Boss you have already purchased this vehicle");
      });
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

    public void SpawnMOC()
    {
      try
      {
        this.SetMocLoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
        if (this.VehicleToUse == "HAULER2")
          this.Moc1 = World.CreateVehicle(this.RequestModel(VehicleHash.Hauler2), this.Moc1Loc, -120f);
        if (this.VehicleToUse == "PHANTOM2")
          this.Moc1 = World.CreateVehicle(this.RequestModel(VehicleHash.Phantom2), this.Moc1Loc, -120f);
        if (this.VehicleToUse == "PHANTOM3")
          this.Moc1 = World.CreateVehicle(this.RequestModel(VehicleHash.Phantom3), this.Moc1Loc, -120f);
        this.Moc2 = World.CreateVehicle(this.RequestModel(VehicleHash.TrailerLarge), this.Moc2Loc, -120f);
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Moc1.Handle, (InputArgument) 0);
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Moc2.Handle, (InputArgument) 0);
        this.Moc1.PrimaryColor = this.CabPrimary;
        this.Moc1.SecondaryColor = this.CabSecondary;
        this.Moc2.PrimaryColor = this.TrailerPrimary;
        this.Moc2.SecondaryColor = this.TrailerSecondary;
        this.Moc2.SetMod(VehicleMod.Livery, this.Livery, true);
        this.Moc2.SetMod(VehicleMod.Roof, this.Weapons, true);
        Function.Call(Hash._0x3C7D42D58F770B54, (InputArgument) this.Moc1, (InputArgument) this.Moc2, (InputArgument) 10);
      }
      catch
      {
        UI.Notify("~r~ Error ~w~ MOC Failed to spawn please Exit & ReEnter Bunker!");
      }
    }

    public void SetupVehicleCustomize()
    {
      UIMenuItem DuneFav = new UIMenuItem("DuneFav");
      this.Customize.AddItem(DuneFav);
      UIMenuItem WT = new UIMenuItem("Weaponized Tampa");
      this.Customize.AddItem(WT);
      UIMenuItem TC = new UIMenuItem("Technical Custom");
      this.Customize.AddItem(TC);
      UIMenuItem IC = new UIMenuItem("Insurgent Custom");
      this.Customize.AddItem(IC);
      UIMenuItem HT = new UIMenuItem("Half Track");
      this.Customize.AddItem(HT);
      UIMenuItem NS = new UIMenuItem("NightShark");
      this.Customize.AddItem(NS);
      UIMenuItem OP = new UIMenuItem("Oppressor");
      this.Customize.AddItem(OP);
      UIMenuItem APC = new UIMenuItem("APC");
      this.Customize.AddItem(APC);
      UIMenuItem AAT2 = new UIMenuItem("AA Trailer");
      this.Customize.AddItem(AAT2);
      this.Customize.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == AAT2)
        {
          if (this.Trailersmall2Retrieved == 1)
          {
            UI.Notify(this.GetHostName() + " AATrailer");
            if ((Entity) this.VehicleToModify != (Entity) null)
              this.VehicleToModify.Delete();
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//MISC//AATrailer.ini");
            this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.VehicleSpawn, -120f);
            this.SC.Load(this.VehicleToModify);
            this.VehicleToModify.IsDriveable = false;
            this.CurrentlyModifingVehicle = true;
            this.Notifyplayer2 = true;
            this.SelectedAAtrailer = true;
            this.GetPositions();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you will need to purchase this vehicle first");
        }
        if (item == DuneFav)
        {
          if (this.Dune3Bought == 1)
          {
            UI.Notify(this.GetHostName() + " Loading Dune FAV");
            if ((Entity) this.VehicleToModify != (Entity) null)
              this.VehicleToModify.Delete();
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//dunefav.ini");
            this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.Dune3, this.VehicleSpawn, -120f);
            this.SC.Load(this.VehicleToModify);
            this.VehicleToModify.IsDriveable = false;
            this.CurrentlyModifingVehicle = true;
            this.Notifyplayer2 = true;
            this.GetPositions();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you will have to purchased this vehicle before using it!");
        }
        if (item == WT)
        {
          if (this.TampaBought == 1)
          {
            UI.Notify(this.GetHostName() + " Loading Weaponized Tampa");
            if ((Entity) this.VehicleToModify != (Entity) null)
              this.VehicleToModify.Delete();
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//weaponizedtampa.ini");
            this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.Tampa3, this.VehicleSpawn, -120f);
            this.SC.Load(this.VehicleToModify);
            this.VehicleToModify.IsDriveable = false;
            this.CurrentlyModifingVehicle = true;
            this.Notifyplayer2 = true;
            this.GetPositions();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you will have to purchased this vehicle before using it!");
        }
        if (item == TC)
        {
          if (this.TechnicalBought == 1)
          {
            UI.Notify(this.GetHostName() + " Loading Technical Custom");
            if ((Entity) this.VehicleToModify != (Entity) null)
              this.VehicleToModify.Delete();
            this.SC.Delete();
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//technicalcustom.ini");
            this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.Technical3, this.VehicleSpawn, -120f);
            this.SC.Load(this.VehicleToModify);
            this.VehicleToModify.IsDriveable = false;
            this.CurrentlyModifingVehicle = true;
            this.Notifyplayer2 = true;
            this.GetPositions();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you will have to purchased this vehicle before using it!");
        }
        if (item == IC)
        {
          if (this.InsurgentBought == 1)
          {
            UI.Notify(this.GetHostName() + " Loading Insurgent Custom");
            if ((Entity) this.VehicleToModify != (Entity) null)
              this.VehicleToModify.Delete();
            this.SC.Delete();
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//Insurgentcustom.ini");
            this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.Insurgent3, this.VehicleSpawn, -120f);
            this.SC.Load(this.VehicleToModify);
            this.VehicleToModify.IsDriveable = false;
            this.CurrentlyModifingVehicle = true;
            this.Notifyplayer2 = true;
            this.GetPositions();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you will have to purchased this vehicle before using it!");
        }
        if (item == HT)
        {
          if (this.HalftrackBought == 1)
          {
            UI.Notify(this.GetHostName() + " Loading Halftrack ");
            if ((Entity) this.VehicleToModify != (Entity) null)
              this.VehicleToModify.Delete();
            this.SC.Delete();
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//halftrack.ini");
            this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.VehicleSpawn, -120f);
            this.SC.Load(this.VehicleToModify);
            this.VehicleToModify.IsDriveable = false;
            this.CurrentlyModifingVehicle = true;
            this.Notifyplayer2 = true;
            this.GetPositions();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you will have to purchased this vehicle before using it!");
        }
        if (item == NS)
        {
          if (this.NightSharkBought == 1)
          {
            UI.Notify(this.GetHostName() + " Loading Nightshark ");
            if ((Entity) this.VehicleToModify != (Entity) null)
              this.VehicleToModify.Delete();
            this.SC.Delete();
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//nightshark.ini");
            this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.NightShark, this.VehicleSpawn, -120f);
            this.SC.Load(this.VehicleToModify);
            this.VehicleToModify.IsDriveable = false;
            this.CurrentlyModifingVehicle = true;
            this.Notifyplayer2 = true;
            this.GetPositions();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you will have to purchased this vehicle before using it!");
        }
        if (item == OP)
        {
          if (this.OppressorBought == 1)
          {
            UI.Notify(this.GetHostName() + " Loading Oppressor ");
            if ((Entity) this.VehicleToModify != (Entity) null)
              this.VehicleToModify.Delete();
            this.SC.Delete();
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//oppressor.ini");
            this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.Oppressor, this.VehicleSpawn, -120f);
            this.SC.Load(this.VehicleToModify);
            this.VehicleToModify.IsDriveable = false;
            this.CurrentlyModifingVehicle = true;
            this.Notifyplayer2 = true;
            this.GetPositions();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you will have to purchased this vehicle before using it!");
        }
        if (item != APC)
          return;
        if (this.APCBought == 1)
        {
          UI.Notify(this.GetHostName() + " Loading APC ");
          if ((Entity) this.VehicleToModify != (Entity) null)
            this.VehicleToModify.Delete();
          this.SC.Delete();
          this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//apc.ini");
          this.VehicleToModify = World.CreateVehicle((Model) VehicleHash.APC, this.VehicleSpawn, -120f);
          this.SC.Load(this.VehicleToModify);
          this.VehicleToModify.IsDriveable = false;
          this.CurrentlyModifingVehicle = true;
          this.Notifyplayer2 = true;
          this.GetPositions();
        }
        else
          UI.Notify(this.GetHostName() + " Sorry Boss you will have to purchased this vehicle before using it!");
      });
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public void SetupCustomisation()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Extras, "Extra Additions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem GunLocker = new UIMenuItem("Gun Locker : $1,000,000");
      uiMenu.AddItem(GunLocker);
      UIMenuItem MOC = new UIMenuItem("Mobile Operations Center : $4,000,000");
      uiMenu.AddItem(MOC);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == MOC && this.MOCBought == 0 && Game.Player.Money >= 4000000)
        {
          Game.Player.Money -= 4000000;
          this.MOCBought = 1;
          this.Config.SetValue<int>("MOC", "bought", this.MOCBought);
          this.Config.Save();
          this.SpawnMOC();
        }
        if (item != GunLocker)
          return;
        if (this.Config.GetValue<int>("EXTRA", "GUNLOCKERBOUGHT", this.GunlockerBought) == 0)
        {
          if (Game.Player.Money >= 1000000)
          {
            Game.Player.Money -= 1000000;
            this.GunlockerBought = 1;
            this.Config.SetValue<int>("EXTRA", "GUNLOCKERBOUGHT", this.GunlockerBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You Dont Have Enought Money For a gun locker");
        }
        else
          UI.Notify(this.GetHostName() + " Sorry boss you have allready bought this upgrade");
      });
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
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p1 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__0 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__0, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
          if (target1((CallSite) p1, obj1))
          {
            Components.Clear();
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__368.\u003C\u003Ep__2 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__2.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__2, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
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
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target2 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__4.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p4 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__4;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__3, Components[C.Index]);
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
        if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__368.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target = Class1.\u003C\u003Eo__368.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p6 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__368.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__368.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__5, Components[C.Index]);
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
        if (str1.Contains("Independence"))
        {
          CPrice = 100500f;
          Enable.Text = "Enable Component : $" + CPrice.ToString("N");
        }
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
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target1 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p8 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__7.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__7, Components[C.Index]);
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
            if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__368.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, bool> target2 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__10.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, bool>> p10 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__10;
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__9 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__368.\u003C\u003Ep__9 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__9.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__9, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
            if (target2((CallSite) p10, obj2))
            {
              if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) W.IndexToItem(W.Index).GetHashCode(), (InputArgument) C.IndexToItem(C.Index).GetHashCode()))
              {
                // ISSUE: reference to a compiler-generated field
                if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__11 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  Class1.\u003C\u003Eo__368.\u003C\u003Ep__11 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Class1.\u003C\u003Eo__368.\u003C\u003Ep__11.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__11, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
                // ISSUE: reference to a compiler-generated field
                if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__12 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  Class1.\u003C\u003Eo__368.\u003C\u003Ep__12 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Class1.\u003C\u003Eo__368.\u003C\u003Ep__12.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__12, Game.Player.Character.Weapons.Current, Components[C.Index], true);
              }
            }
          }
        }
        if (item != DIsable)
          return;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__368.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__14.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p14 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__14;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__368.\u003C\u003Ep__13 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__13.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__13, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
        if (target3((CallSite) p14, obj3))
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__19 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__19.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p19 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__19;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__18 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool, object> target2 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__18.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool, object>> p18 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__18;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__17 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__17 = CallSite<Func<CallSite, System.Type, Hash, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Call", (IEnumerable<System.Type>) new System.Type[1]
            {
              typeof (bool)
            }, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, System.Type, Hash, object, object, object> target4 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__17.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, System.Type, Hash, object, object, object>> p17 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__17;
          System.Type type = typeof (Function);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__15 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__15.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__15, Mk2Weapons[W.Index]);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__16 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = Class1.\u003C\u003Eo__368.\u003C\u003Ep__16.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__16, Components[C.Index]);
          object obj4 = target4((CallSite) p17, type, Hash._0x5CEE3DF569CECAB0, obj1, obj2);
          object obj5 = target2((CallSite) p18, obj4, true);
          if (target1((CallSite) p19, obj5))
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__20 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__368.\u003C\u003Ep__20 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__20.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__20, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__368.\u003C\u003Ep__21 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__368.\u003C\u003Ep__21 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__368.\u003C\u003Ep__21.Target((CallSite) Class1.\u003C\u003Eo__368.\u003C\u003Ep__21, Game.Player.Character.Weapons.Current, Components[C.Index], false);
          }
        }
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
        int num;
        switch (hash)
        {
          case WeaponHash.HeavySniperMk2:
          case WeaponHash.AssaultrifleMk2:
          case WeaponHash.PumpShotgunMk2:
          case WeaponHash.MarksmanRifleMk2:
          case WeaponHash.SMGMk2:
          case WeaponHash.BullpupRifleMk2:
          case WeaponHash.SpecialCarbineMk2:
          case WeaponHash.PistolMk2:
          case WeaponHash.RevolverMk2:
          case WeaponHash.CombatMGMk2:
          case WeaponHash.CarbineRifleMk2:
            num = 1;
            break;
          default:
            num = hash == WeaponHash.SNSPistolMk2 ? 1 : 0;
            break;
        }
        if (num != 0)
        {
          UI.Notify(this.GetHostName() + " Boss, this is a MKII weapon please perchase it from the MkII page");
        }
        else
        {
          Game.Player.Character.Weapons.Give(hash, 9999, true, true);
          Game.Player.Money -= 10000;
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

    public void SetupVehicleBay()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.MilitaryAsset, "Source A Military Vehicle");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem DV = new UIMenuItem("Dune FAV");
      uiMenu.AddItem(DV);
      UIMenuItem WT = new UIMenuItem("Weaponized Tampa");
      uiMenu.AddItem(WT);
      UIMenuItem TC = new UIMenuItem("Technical Custom");
      uiMenu.AddItem(TC);
      UIMenuItem IC = new UIMenuItem("Insurgent Custom");
      uiMenu.AddItem(IC);
      UIMenuItem HT = new UIMenuItem("Half Track");
      uiMenu.AddItem(HT);
      UIMenuItem NS = new UIMenuItem("NightShark");
      uiMenu.AddItem(NS);
      UIMenuItem OP = new UIMenuItem("Oppressor");
      uiMenu.AddItem(OP);
      UIMenuItem APC = new UIMenuItem("APC");
      uiMenu.AddItem(APC);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == DV)
        {
          if (this.Dune3Bought == 0)
          {
            foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
            {
              if ((Entity) sourcingmissionPed != (Entity) null)
                sourcingmissionPed.Delete();
            }
            foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
            {
              if ((Entity) sourcingmissionVehicle != (Entity) null)
                sourcingmissionVehicle.Delete();
            }
            if (this.SourcingmissionVehicles.Count > 0)
              this.SourcingmissionVehicles.Clear();
            if (this.SourcingmissionPeds.Count > 0)
              this.SourcingmissionPeds.Clear();
            UI.Notify(this.GetHostName() + " Ok find and retrieve the vehicle, and bring it back to the bunker so we can store it, so u can use and modify it ");
            this.SelectSpawn();
            if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
              this.MillitaryAssetToRetrieve.Delete();
            if (this.MilitaryVehicleBlip != (Blip) null)
              this.MilitaryVehicleBlip.Remove();
            this.MillitaryAssetToRetrieve = World.CreateVehicle((Model) VehicleHash.Dune3, new Vector3(620.4908f, 2934.228f, 39.849f));
            System.Random random = new System.Random();
            int num1 = random.Next(3, 12);
            Vector3 position1;
            for (int index1 = 0; index1 < num1; ++index1)
            {
              Model model = (Model) PedHash.Armymech01SMY;
              position1 = this.MillitaryAssetToRetrieve.Position;
              Vector3 position2 = position1.Around((float) random.Next(3, 10));
              Ped ped = World.CreatePed(model, position2);
              ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
              ped.RelationshipGroup = 5;
              ped.IsEnemy = true;
              this.SourcingmissionPeds.Add(ped);
              ped.Task.WanderAround(ped.Position, 15f);
            }
            int num2 = random.Next(1, 4);
            for (int index1 = 0; index1 < num2; ++index1)
            {
              List<VehicleHash> vehicleHashList = new List<VehicleHash>();
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.APC);
              vehicleHashList.Add(VehicleHash.APC);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Barracks);
              int index2 = random.Next(0, vehicleHashList.Count);
              Model model = this.RequestModel(vehicleHashList[index2]);
              position1 = this.MillitaryAssetToRetrieve.Position;
              Vector3 position2 = position1.Around((float) random.Next(10, 20));
              Vehicle vehicle = World.CreateVehicle(model, position2);
              int num3 = random.Next(0, 360);
              vehicle.Heading = (float) num3;
              this.SourcingmissionVehicles.Add(vehicle);
            }
            this.StartedVehicleSourcing = true;
            this.NotifyPlayer = true;
            this.VehicleToRetrieve = "DuneFAV";
            this.MilitaryVehicleBlip = World.CreateBlip(this.MillitaryAssetToRetrieve.Position);
            this.MilitaryVehicleBlip.Sprite = BlipSprite.DuneFAV;
            this.MilitaryVehicleBlip.Name = "Retrieve Dune Fav";
            this.MilitaryVehicleBlip.Position = this.MillitaryAssetToRetrieve.Position;
            this.MilitaryVehicleBlip.Color = BlipColor.White;
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss We have allready got this vehicle");
        }
        if (item == WT)
        {
          if (this.TampaBought == 0)
          {
            foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
            {
              if ((Entity) sourcingmissionPed != (Entity) null)
                sourcingmissionPed.Delete();
            }
            foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
            {
              if ((Entity) sourcingmissionVehicle != (Entity) null)
                sourcingmissionVehicle.Delete();
            }
            if (this.SourcingmissionVehicles.Count > 0)
              this.SourcingmissionVehicles.Clear();
            if (this.SourcingmissionPeds.Count > 0)
              this.SourcingmissionPeds.Clear();
            UI.Notify(this.GetHostName() + " Ok find and retrieve the vehicle, and bring it back to the bunker so we can store it, so u can use and modify it ");
            Vector3 position = this.SelectSpawn();
            if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
              this.MillitaryAssetToRetrieve.Delete();
            if (this.MilitaryVehicleBlip != (Blip) null)
              this.MilitaryVehicleBlip.Remove();
            this.MillitaryAssetToRetrieve = World.CreateVehicle((Model) VehicleHash.Tampa3, position);
            this.MillitaryAssetToRetrieve.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
            this.MillitaryAssetToRetrieve.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.BullpupRifleMk2, 9999, true, true);
            this.StartedVehicleSourcing = true;
            this.NotifyPlayer = true;
            this.VehicleToRetrieve = "Weaponized Tampa";
            this.MilitaryVehicleBlip = World.CreateBlip(this.MillitaryAssetToRetrieve.Position);
            this.MilitaryVehicleBlip.Sprite = BlipSprite.WeaponizedTampa;
            this.MilitaryVehicleBlip.Name = "Retrieve Weaponized Tampa";
            this.MilitaryVehicleBlip.Position = this.MillitaryAssetToRetrieve.Position;
            this.MilitaryVehicleBlip.Color = BlipColor.White;
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss We have allready got this vehicle");
        }
        if (item == TC)
        {
          if (this.TechnicalBought == 0)
          {
            foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
            {
              if ((Entity) sourcingmissionPed != (Entity) null)
                sourcingmissionPed.Delete();
            }
            foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
            {
              if ((Entity) sourcingmissionVehicle != (Entity) null)
                sourcingmissionVehicle.Delete();
            }
            if (this.SourcingmissionVehicles.Count > 0)
              this.SourcingmissionVehicles.Clear();
            if (this.SourcingmissionPeds.Count > 0)
              this.SourcingmissionPeds.Clear();
            UI.Notify(this.GetHostName() + " Ok find and retrieve the vehicle, and bring it back to the bunker so we can store it, so u can use and modify it ");
            this.SelectSpawn();
            if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
              this.MillitaryAssetToRetrieve.Delete();
            if (this.MilitaryVehicleBlip != (Blip) null)
              this.MilitaryVehicleBlip.Remove();
            this.MillitaryAssetToRetrieve = World.CreateVehicle((Model) VehicleHash.Technical3, new Vector3(1963.746f, 4962.135f, 42.6f));
            System.Random random = new System.Random();
            int num1 = random.Next(3, 12);
            Vector3 position1;
            for (int index1 = 0; index1 < num1; ++index1)
            {
              Model model = (Model) PedHash.Armymech01SMY;
              position1 = this.MillitaryAssetToRetrieve.Position;
              Vector3 position2 = position1.Around((float) random.Next(3, 10));
              Ped ped = World.CreatePed(model, position2);
              ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
              ped.RelationshipGroup = 5;
              ped.IsEnemy = true;
              this.SourcingmissionPeds.Add(ped);
              ped.Task.WanderAround(ped.Position, 15f);
            }
            int num2 = random.Next(1, 4);
            for (int index1 = 0; index1 < num2; ++index1)
            {
              List<VehicleHash> vehicleHashList = new List<VehicleHash>();
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.APC);
              vehicleHashList.Add(VehicleHash.APC);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Barracks);
              int index2 = random.Next(0, vehicleHashList.Count);
              Model model = this.RequestModel(vehicleHashList[index2]);
              position1 = this.MillitaryAssetToRetrieve.Position;
              Vector3 position2 = position1.Around((float) random.Next(3, 10));
              this.SourcingmissionVehicles.Add(World.CreateVehicle(model, position2));
            }
            this.StartedVehicleSourcing = true;
            this.NotifyPlayer = true;
            this.VehicleToRetrieve = "Techncial Custom";
            this.MilitaryVehicleBlip = World.CreateBlip(this.MillitaryAssetToRetrieve.Position);
            this.MilitaryVehicleBlip.Sprite = BlipSprite.TechnicalAqua;
            this.MilitaryVehicleBlip.Name = "Retrieve Technical Custom";
            this.MilitaryVehicleBlip.Position = this.MillitaryAssetToRetrieve.Position;
            this.MilitaryVehicleBlip.Color = BlipColor.White;
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss We have allready got this vehicle");
        }
        if (item == IC)
        {
          if (this.InsurgentBought == 0)
          {
            foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
            {
              if ((Entity) sourcingmissionPed != (Entity) null)
                sourcingmissionPed.Delete();
            }
            foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
            {
              if ((Entity) sourcingmissionVehicle != (Entity) null)
                sourcingmissionVehicle.Delete();
            }
            if (this.SourcingmissionVehicles.Count > 0)
              this.SourcingmissionVehicles.Clear();
            if (this.SourcingmissionPeds.Count > 0)
              this.SourcingmissionPeds.Clear();
            UI.Notify(this.GetHostName() + " Ok find and retrieve the vehicle, and bring it back to the bunker so we can store it, so u can use and modify it ");
            this.SelectSpawn();
            if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
              this.MillitaryAssetToRetrieve.Delete();
            if (this.MilitaryVehicleBlip != (Blip) null)
              this.MilitaryVehicleBlip.Remove();
            this.MillitaryAssetToRetrieve = World.CreateVehicle((Model) VehicleHash.Insurgent3, new Vector3(2943.965f, 2797.127f, 40.69f));
            System.Random random = new System.Random();
            int num1 = random.Next(3, 12);
            Vector3 position1;
            for (int index1 = 0; index1 < num1; ++index1)
            {
              Model model = (Model) PedHash.Armymech01SMY;
              position1 = this.MillitaryAssetToRetrieve.Position;
              Vector3 position2 = position1.Around((float) random.Next(3, 10));
              Ped ped = World.CreatePed(model, position2);
              ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
              ped.RelationshipGroup = 5;
              ped.IsEnemy = true;
              this.SourcingmissionPeds.Add(ped);
              ped.Task.WanderAround(ped.Position, 15f);
            }
            int num2 = random.Next(1, 4);
            for (int index1 = 0; index1 < num2; ++index1)
            {
              List<VehicleHash> vehicleHashList = new List<VehicleHash>();
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.APC);
              vehicleHashList.Add(VehicleHash.APC);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Barracks);
              int index2 = random.Next(0, vehicleHashList.Count);
              Model model = this.RequestModel(vehicleHashList[index2]);
              position1 = this.MillitaryAssetToRetrieve.Position;
              Vector3 position2 = position1.Around((float) random.Next(10, 20));
              Vehicle vehicle = World.CreateVehicle(model, position2);
              int num3 = random.Next(0, 360);
              vehicle.Heading = (float) num3;
              this.SourcingmissionVehicles.Add(vehicle);
            }
            this.StartedVehicleSourcing = true;
            this.NotifyPlayer = true;
            this.VehicleToRetrieve = "Insurgent Custom";
            this.MilitaryVehicleBlip = World.CreateBlip(this.MillitaryAssetToRetrieve.Position);
            this.MilitaryVehicleBlip.Sprite = BlipSprite.GunCar;
            this.MilitaryVehicleBlip.Name = "Retrieve Insurgent Custom";
            this.MilitaryVehicleBlip.Position = this.MillitaryAssetToRetrieve.Position;
            this.MilitaryVehicleBlip.Color = BlipColor.White;
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss We have allready got this vehicle");
        }
        if (item == HT)
        {
          if (this.HalftrackBought == 0)
          {
            foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
            {
              if ((Entity) sourcingmissionPed != (Entity) null)
                sourcingmissionPed.Delete();
            }
            foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
            {
              if ((Entity) sourcingmissionVehicle != (Entity) null)
                sourcingmissionVehicle.Delete();
            }
            if (this.SourcingmissionVehicles.Count > 0)
              this.SourcingmissionVehicles.Clear();
            if (this.SourcingmissionPeds.Count > 0)
              this.SourcingmissionPeds.Clear();
            UI.Notify(this.GetHostName() + " Ok find and retrieve the vehicle, and bring it back to the bunker so we can store it, so u can use and modify it ");
            Vector3 position = this.SelectSpawn();
            if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
              this.MillitaryAssetToRetrieve.Delete();
            if (this.MilitaryVehicleBlip != (Blip) null)
              this.MilitaryVehicleBlip.Remove();
            this.MillitaryAssetToRetrieve = World.CreateVehicle((Model) VehicleHash.HalfTrack, position);
            this.MillitaryAssetToRetrieve.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
            this.MillitaryAssetToRetrieve.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
            this.MillitaryAssetToRetrieve.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.BullpupRifleMk2, 9999, true, true);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.BullpupRifleMk2, 9999, true, true);
            this.StartedVehicleSourcing = true;
            this.NotifyPlayer = true;
            this.VehicleToRetrieve = "HalfTrack";
            this.MilitaryVehicleBlip = World.CreateBlip(this.MillitaryAssetToRetrieve.Position);
            this.MilitaryVehicleBlip.Sprite = BlipSprite.HalfTrack;
            this.MilitaryVehicleBlip.Name = "Retrieve HalfTrack";
            this.MilitaryVehicleBlip.Position = this.MillitaryAssetToRetrieve.Position;
            this.MilitaryVehicleBlip.Color = BlipColor.White;
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss We have allready got this vehicle");
        }
        if (item == NS)
        {
          if (this.NightSharkBought == 0)
          {
            foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
            {
              if ((Entity) sourcingmissionPed != (Entity) null)
                sourcingmissionPed.Delete();
            }
            foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
            {
              if ((Entity) sourcingmissionVehicle != (Entity) null)
                sourcingmissionVehicle.Delete();
            }
            if (this.SourcingmissionVehicles.Count > 0)
              this.SourcingmissionVehicles.Clear();
            if (this.SourcingmissionPeds.Count > 0)
              this.SourcingmissionPeds.Clear();
            UI.Notify(this.GetHostName() + " Ok find and retrieve the vehicle, and bring it back to the bunker so we can store it, so u can use and modify it ");
            this.SelectSpawn();
            if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
              this.MillitaryAssetToRetrieve.Delete();
            if (this.MilitaryVehicleBlip != (Blip) null)
              this.MilitaryVehicleBlip.Remove();
            this.MillitaryAssetToRetrieve = World.CreateVehicle((Model) VehicleHash.NightShark, new Vector3(3039.097f, 3346.066f, 76.47f));
            System.Random random = new System.Random();
            int num1 = random.Next(3, 12);
            Vector3 position1;
            for (int index1 = 0; index1 < num1; ++index1)
            {
              Model model = (Model) PedHash.Armymech01SMY;
              position1 = this.MillitaryAssetToRetrieve.Position;
              Vector3 position2 = position1.Around((float) random.Next(3, 10));
              Ped ped = World.CreatePed(model, position2);
              ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
              ped.RelationshipGroup = 5;
              ped.IsEnemy = true;
              this.SourcingmissionPeds.Add(ped);
              ped.Task.WanderAround(ped.Position, 15f);
            }
            int num2 = random.Next(1, 4);
            for (int index1 = 0; index1 < num2; ++index1)
            {
              List<VehicleHash> vehicleHashList = new List<VehicleHash>();
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.Dune3);
              vehicleHashList.Add(VehicleHash.APC);
              vehicleHashList.Add(VehicleHash.APC);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Insurgent);
              vehicleHashList.Add(VehicleHash.Insurgent2);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Crusader);
              vehicleHashList.Add(VehicleHash.Barracks);
              int index2 = random.Next(0, vehicleHashList.Count);
              Model model = this.RequestModel(vehicleHashList[index2]);
              position1 = this.MillitaryAssetToRetrieve.Position;
              Vector3 position2 = position1.Around((float) random.Next(10, 20));
              Vehicle vehicle = World.CreateVehicle(model, position2);
              int num3 = random.Next(0, 360);
              vehicle.Heading = (float) num3;
              this.SourcingmissionVehicles.Add(vehicle);
            }
            this.StartedVehicleSourcing = true;
            this.NotifyPlayer = true;
            this.VehicleToRetrieve = "Nightshark";
            this.MilitaryVehicleBlip = World.CreateBlip(this.MillitaryAssetToRetrieve.Position);
            this.MilitaryVehicleBlip.Sprite = BlipSprite.GunCar;
            this.MilitaryVehicleBlip.Name = "Retrieve NightShark";
            this.MilitaryVehicleBlip.Position = this.MillitaryAssetToRetrieve.Position;
            this.MilitaryVehicleBlip.Color = BlipColor.White;
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss We have allready got this vehicle");
        }
        if (item == OP)
        {
          if (this.OppressorBought == 0)
          {
            foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
            {
              if ((Entity) sourcingmissionPed != (Entity) null)
                sourcingmissionPed.Delete();
            }
            foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
            {
              if ((Entity) sourcingmissionVehicle != (Entity) null)
                sourcingmissionVehicle.Delete();
            }
            if (this.SourcingmissionVehicles.Count > 0)
              this.SourcingmissionVehicles.Clear();
            if (this.SourcingmissionPeds.Count > 0)
              this.SourcingmissionPeds.Clear();
            UI.Notify(this.GetHostName() + " Ok find and retrieve the vehicle, and bring it back to the bunker so we can store it, so u can use and modify it ");
            Vector3 position = this.SelectSpawn();
            if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
              this.MillitaryAssetToRetrieve.Delete();
            if (this.MilitaryVehicleBlip != (Blip) null)
              this.MilitaryVehicleBlip.Remove();
            this.MillitaryAssetToRetrieve = World.CreateVehicle((Model) VehicleHash.Oppressor, position);
            this.MillitaryAssetToRetrieve.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
            this.MillitaryAssetToRetrieve.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
            this.StartedVehicleSourcing = true;
            this.NotifyPlayer = true;
            this.VehicleToRetrieve = "Oppressor";
            this.MilitaryVehicleBlip = World.CreateBlip(this.MillitaryAssetToRetrieve.Position);
            this.MilitaryVehicleBlip.Sprite = BlipSprite.Oppressor;
            this.MilitaryVehicleBlip.Name = "Retrieve Oppressor";
            this.MilitaryVehicleBlip.Position = this.MillitaryAssetToRetrieve.Position;
            this.MilitaryVehicleBlip.Color = BlipColor.White;
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss We have allready got this vehicle");
        }
        if (item != APC)
          return;
        if (this.APCBought == 0)
        {
          foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
          {
            if ((Entity) sourcingmissionPed != (Entity) null)
              sourcingmissionPed.Delete();
          }
          foreach (Vehicle sourcingmissionVehicle in this.SourcingmissionVehicles)
          {
            if ((Entity) sourcingmissionVehicle != (Entity) null)
              sourcingmissionVehicle.Delete();
          }
          if (this.SourcingmissionVehicles.Count > 0)
            this.SourcingmissionVehicles.Clear();
          if (this.SourcingmissionPeds.Count > 0)
            this.SourcingmissionPeds.Clear();
          UI.Notify(this.GetHostName() + " Ok find and retrieve the vehicle, and bring it back to the bunker so we can store it, so u can use and modify it ");
          this.SelectSpawn();
          if ((Entity) this.MillitaryAssetToRetrieve != (Entity) null)
            this.MillitaryAssetToRetrieve.Delete();
          if (this.MilitaryVehicleBlip != (Blip) null)
            this.MilitaryVehicleBlip.Remove();
          this.MillitaryAssetToRetrieve = World.CreateVehicle((Model) VehicleHash.APC, new Vector3(1049.66f, 4278.291f, 37.62f));
          System.Random random = new System.Random();
          int num1 = random.Next(6, 15);
          Vector3 position1;
          for (int index1 = 0; index1 < num1; ++index1)
          {
            Model model = (Model) PedHash.Armymech01SMY;
            position1 = this.MillitaryAssetToRetrieve.Position;
            Vector3 position2 = position1.Around((float) random.Next(3, 10));
            Ped ped = World.CreatePed(model, position2);
            ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            ped.RelationshipGroup = 5;
            ped.IsEnemy = true;
            this.SourcingmissionPeds.Add(ped);
            ped.Task.WanderAround(ped.Position, 15f);
          }
          int num2 = random.Next(1, 4);
          for (int index1 = 0; index1 < num2; ++index1)
          {
            List<VehicleHash> vehicleHashList = new List<VehicleHash>();
            vehicleHashList.Add(VehicleHash.Dune3);
            vehicleHashList.Add(VehicleHash.Dune3);
            vehicleHashList.Add(VehicleHash.Dune3);
            vehicleHashList.Add(VehicleHash.APC);
            vehicleHashList.Add(VehicleHash.APC);
            vehicleHashList.Add(VehicleHash.Insurgent);
            vehicleHashList.Add(VehicleHash.Insurgent2);
            vehicleHashList.Add(VehicleHash.Insurgent);
            vehicleHashList.Add(VehicleHash.Insurgent2);
            vehicleHashList.Add(VehicleHash.Insurgent);
            vehicleHashList.Add(VehicleHash.Insurgent2);
            vehicleHashList.Add(VehicleHash.Crusader);
            vehicleHashList.Add(VehicleHash.Crusader);
            vehicleHashList.Add(VehicleHash.Crusader);
            vehicleHashList.Add(VehicleHash.Crusader);
            vehicleHashList.Add(VehicleHash.Barracks);
            int index2 = random.Next(0, vehicleHashList.Count);
            Model model = this.RequestModel(vehicleHashList[index2]);
            position1 = this.MillitaryAssetToRetrieve.Position;
            Vector3 position2 = position1.Around((float) random.Next(10, 20));
            Vehicle vehicle = World.CreateVehicle(model, position2);
            int num3 = random.Next(0, 360);
            vehicle.Heading = (float) num3;
            this.SourcingmissionVehicles.Add(vehicle);
          }
          this.StartedVehicleSourcing = true;
          this.NotifyPlayer = true;
          this.VehicleToRetrieve = "APC";
          this.MilitaryVehicleBlip = World.CreateBlip(this.MillitaryAssetToRetrieve.Position);
          this.MilitaryVehicleBlip.Sprite = BlipSprite.APC;
          this.MilitaryVehicleBlip.Name = "Retrieve APC";
          this.MilitaryVehicleBlip.Position = this.MillitaryAssetToRetrieve.Position;
          this.MilitaryVehicleBlip.Color = BlipColor.White;
        }
        else
          UI.Notify(this.GetHostName() + " Sorry Boss We have allready got this vehicle");
      });
    }

    private void OnKeyDown()
    {
      try
      {
        if ((Entity) this.Moc1 != (Entity) null)
        {
          if (this.Moc1.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            Script.Wait(1000);
            Game.Player.Character.Position = this.Exit;
            this.IsInInterior = false;
            Vector3 entry = this.Entry;
            entry.X += 5f;
            Game.Player.Character.Position = entry;
            Game.Player.Character.Position = this.Entry;
            if ((Entity) this.Caddy != (Entity) null)
              this.Caddy.Delete();
            if ((Entity) this.JuggernautPed != (Entity) null)
              this.JuggernautPed.Delete();
            if ((Entity) this.Moc2 != (Entity) null)
              this.Moc2.Delete();
            if ((Entity) this.Moc1 != (Entity) null)
              this.Moc1.Delete();
          }
        }
      }
      catch
      {
        UI.Notify("OnKeyDown 1");
      }
      try
      {
        if (this.CurrentlyModifingVehicle)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (Entity) Game.Player.Character.CurrentVehicle == (Entity) this.VehicleToModify)
          {
            if (Game.IsControlJustPressed(2, GTA.Control.Cover))
            {
              Game.FadeScreenOut(300);
              Script.Wait(300);
              this.SC.Save();
              this.Notifyplayer2 = false;
              this.CurrentlyModifingVehicle = false;
              Script.Wait(300);
              Game.FadeScreenIn(300);
            }
            else if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              this.SC.SaveWithoutDelete();
              Game.FadeScreenOut(300);
              Script.Wait(300);
              this.Notifyplayer2 = false;
              Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
              Game.Player.Character.CurrentVehicle.Position = this.OutsideVehicleSpawn;
              Game.Player.Character.CurrentVehicle.Heading = this.OutsideVehicleHeading;
              Game.Player.Character.SetIntoVehicle(currentVehicle, VehicleSeat.Driver);
              Game.Player.Character.CurrentVehicle.IsDriveable = true;
              if (this.SelectedAAtrailer)
              {
                if (this.NightSharkBought == 1)
                {
                  this.SC.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//nightshark.ini");
                  Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.NightShark, this.VehicleSpawn + new Vector3(0.0f, 15f, 0.0f), 0.0f);
                  this.SC.Load(vehicle);
                  vehicle.Position = this.Entry;
                  vehicle.IsDriveable = true;
                  Function.Call(Hash._0x3C7D42D58F770B54, (InputArgument) vehicle, (InputArgument) this.VehicleToModify, (InputArgument) 10);
                  if ((Entity) this.Caddy != (Entity) null)
                    this.Caddy.Delete();
                  if ((Entity) this.JuggernautPed != (Entity) null)
                    this.JuggernautPed.Delete();
                  if ((Entity) this.Moc1 != (Entity) null)
                    this.Moc1.Delete();
                  if ((Entity) this.Moc2 != (Entity) null)
                    this.Moc2.Delete();
                }
                else
                {
                  Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.NightShark, this.VehicleSpawn + new Vector3(0.0f, 15f, 0.0f), 0.0f);
                  vehicle.Position = this.Entry;
                  vehicle.TowVehicle(Game.Player.Character.CurrentVehicle, true);
                  if ((Entity) this.Caddy != (Entity) null)
                    this.Caddy.Delete();
                  if ((Entity) this.JuggernautPed != (Entity) null)
                    this.JuggernautPed.Delete();
                  if ((Entity) this.Moc1 != (Entity) null)
                    this.Moc1.Delete();
                  if ((Entity) this.Moc2 != (Entity) null)
                    this.Moc2.Delete();
                }
              }
              Script.Wait(300);
              Game.FadeScreenIn(300);
              this.CurrentlyModifingVehicle = false;
              if ((Entity) this.Caddy != (Entity) null)
                this.Caddy.Delete();
              if ((Entity) this.JuggernautPed != (Entity) null)
                this.JuggernautPed.Delete();
              if ((Entity) this.Moc1 != (Entity) null)
                this.Moc1.Delete();
              if ((Entity) this.Moc2 != (Entity) null)
                this.Moc2.Delete();
              this.VehicleToModify = (Vehicle) null;
            }
          }
        }
      }
      catch
      {
        UI.Notify("OnKeyDown 2");
      }
      try
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.VehicleBaypos) < 2.0)
        {
          if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.IsInInterior && this.VehicleBayBought == 1)
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
            if (!this.mainMenu2.Visible)
              this.mainMenu2.Visible = !this.mainMenu2.Visible;
            this.mainMenu.Visible = false;
          }
        }
      }
      catch
      {
        UI.Notify("OnKeyDown 3");
      }
      try
      {
        if (this.Notifyplayer2)
        {
          if (!this.IsInInterior)
            ;
        }
      }
      catch
      {
        UI.Notify("OnKeyDown 4");
      }
      try
      {
        if (this.UseOldMarker)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) < 2.0 && this.IsInInterior && Game.IsControlJustPressed(2, GTA.Control.Context))
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
            if (!this.mainMenu.Visible)
              this.mainMenu.Visible = !this.mainMenu.Visible;
          }
        }
      }
      catch
      {
        UI.Notify("OnKeyDown 5");
      }
      try
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 2.0)
        {
          if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.purchaselvl >= 1 && !this.IsInInterior)
          {
            if ((Entity) this.Caddy != (Entity) null)
              this.Caddy.Delete();
            if ((Entity) this.JuggernautPed != (Entity) null)
              this.JuggernautPed.Delete();
            if ((Entity) this.Moc1 != (Entity) null)
              this.Moc1.Delete();
            if ((Entity) this.Moc2 != (Entity) null)
              this.Moc2.Delete();
            this.IsInInterior = true;
            if (this.MOCBought == 1)
              this.SpawnMOC();
            Script.Wait(300);
            this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
            this.Caddy = World.CreateVehicle((Model) VehicleHash.Caddy3, this.CaddySpawn, 90f);
            if (this.Config.GetValue<bool>("RESEARCH", "JUGGERNAUT_SUIT", false))
            {
              this.JuggernautPed = World.CreatePed(this.RequestModel(PedHash.FreemodeMale01), new Vector3(825.31f, -3236.95f, -100.0118f), -51.04f);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.JuggernautPed, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
              this.JuggernautPed.RelationshipGroup = 2;
              this.JuggernautPed.CanBeTargetted = false;
              this.JuggernautPed.IsInvincible = true;
              this.JuggernautPed.FreezePosition = true;
            }
            Game.FadeScreenOut(300);
            Script.Wait(300);
            Game.Player.Character.Position = this.Exit;
            Game.FadeScreenIn(300);
          }
        }
      }
      catch
      {
        UI.Notify("OnKeyDown 6");
      }
      try
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.Exit) >= 2.0 || !Game.IsControlJustPressed(2, GTA.Control.Context) || !this.IsInInterior)
          return;
        if ((Entity) this.VehicleToModify != (Entity) null)
          this.VehicleToModify.Delete();
        Game.FadeScreenOut(300);
        Script.Wait(300);
        Game.Player.Character.Position = this.Entry;
        Script.Wait(300);
        Game.FadeScreenIn(300);
        this.IsInInterior = false;
      }
      catch
      {
        UI.Notify("OnKeyDown 7  ");
      }
    }

    public void SetupMarker()
    {
      this.LabMarker = World.CreateBlip(this.Entry);
      this.LabMarker.Sprite = BlipSprite.Bunker;
      this.LabMarker.Color = BlipColor.White;
      this.LabMarker.Name = this.BNKr_BunkerName + " Bunker";
      this.LabMarker.IsShortRange = true;
      if (!(this.LabMarker != (Blip) null))
        return;
      if (this.purchaselvl > 0)
      {
        this.LabMarker.Sprite = BlipSprite.Bunker;
        this.LabMarker.Color = this.Blip_Colour;
        this.LabMarker.Name = this.BNKr_BunkerName + " Bunker";
        this.LabMarker.IsShortRange = true;
        this.LabMarker.Alpha = (int) byte.MaxValue;
      }
      if (this.purchaselvl == 0)
      {
        this.LabMarker.Sprite = BlipSprite.Bunker;
        this.LabMarker.Color = BlipColor.White;
        this.LabMarker.Name = "Gun Running Business Bunker";
        this.LabMarker.IsShortRange = true;
        this.LabMarker.Alpha = 0;
      }
    }

    public void ResetSourcedVehicle()
    {
      this.SC.Config.SetValue<int>("Configurations", "Roof", -1);
      this.SC.Config.SetValue<int>("Configurations", "AerialsId", -1);
      this.SC.Config.SetValue<int>("Configurations", "AirfilterId", -1);
      this.SC.Config.SetValue<int>("Configurations", "ArchCoverId", -1);
      this.SC.Config.SetValue<int>("Configurations", "ArmorId", -1);
      this.SC.Config.SetValue<int>("Configurations", "BackWheelsId", -1);
      this.SC.Config.SetValue<int>("Configurations", "BrakesId", -1);
      this.SC.Config.SetValue<int>("Configurations", "ColumnShifterLeversId", -1);
      this.SC.Config.SetValue<int>("Configurations", "DashboardId", -1);
      this.SC.Config.SetValue<int>("Configurations", "DialDesignId", -1);
      this.SC.Config.SetValue<int>("Configurations", "DoorSpeekersId", -1);
      this.SC.Config.SetValue<int>("Configurations", "EngineId", -1);
      this.SC.Config.SetValue<int>("Configurations", "EngineBlockId", -1);
      this.SC.Config.SetValue<int>("Configurations", "ExaustId", -1);
      this.SC.Config.SetValue<int>("Configurations", "FenderId", -1);
      this.SC.Config.SetValue<int>("Configurations", "FrameId", -1);
      this.SC.Config.SetValue<int>("Configurations", "FrontBumperId", -1);
      this.SC.Config.SetValue<int>("Configurations", "FrontWheelsId", -1);
      this.SC.Config.SetValue<int>("Configurations", "GrilleId", -1);
      this.SC.Config.SetValue<int>("Configurations", "HoodId", -1);
      this.SC.Config.SetValue<int>("Configurations", "HornsId", -1);
      this.SC.Config.SetValue<int>("Configurations", "HydralicsId", -1);
      this.SC.Config.SetValue<int>("Configurations", "LiveryId", -1);
      this.SC.Config.SetValue<int>("Configurations", "SecondaryVehicleLivery", -1);
      this.SC.Config.SetValue<int>("Configurations", "OrnamentsId", -1);
      this.SC.Config.SetValue<int>("Configurations", "PlaquesId", -1);
      this.SC.Config.SetValue<int>("Configurations", "Plateholder", -1);
      this.SC.Config.SetValue<int>("Configurations", "RearBumperId", -1);
      this.SC.Config.SetValue<int>("Configurations", "RightFenderId", -1);
      this.SC.Config.SetValue<int>("Configurations", "SeatsId", -1);
      this.SC.Config.SetValue<int>("Configurations", "speakers", -1);
      this.SC.Config.SetValue<int>("Configurations", "speakers", -1);
      this.SC.Config.SetValue<int>("Configurations", "SpoilersId", -1);
      this.SC.Config.SetValue<int>("Configurations", "SteeringWheelId", -1);
      this.SC.Config.SetValue<int>("Configurations", "StrutId", -1);
      this.SC.Config.SetValue<int>("Configurations", "RoofId", -1);
      this.SC.Config.SetValue<int>("Configurations", "SuspensionId", -1);
      this.SC.Config.SetValue<int>("Configurations", "TransmissionId", -1);
      this.SC.Config.SetValue<int>("Configurations", "TrimDesignId", -1);
      this.SC.Config.SetValue<int>("Configurations", "TrimDesignId", -1);
      this.SC.Config.SetValue<int>("Configurations", "TrunkId", -1);
      this.SC.Config.SetValue<int>("Configurations", "VanityPlatesId", -1);
      this.SC.Config.SetValue<int>("Configurations", "WindowId", -1);
      this.SC.Config.SetValue<VehicleWindowTint>("Configurations", "TintId", VehicleWindowTint.None);
      this.SC.Config.SetValue<VehicleColor>("Configurations", "Wheelcolour", VehicleColor.MatteBlack);
      this.SC.Config.SetValue<VehicleColor>("Configurations", "DashBoardColour", VehicleColor.MatteBlack);
      this.SC.Config.SetValue<VehicleColor>("Configurations", "PearlCent", VehicleColor.MatteBlack);
      this.SC.Config.SetValue<Color>("Configurations", "NeonColour", Color.Black);
      this.SC.Config.SetValue<string>("Configurations", "PlanteNo", "");
      this.SC.Config.SetValue<bool>("Configurations", "CustomTiresOn", false);
      this.SC.Config.SetValue<int>("Configurations", "Blades", -1);
      this.SC.Config.SetValue<bool>("Configurations", "HasXenonLights", false);
      this.SC.Config.SetValue<bool>("Configurations", "TurboActive", false);
      this.SC.Config.SetValue<int>("Configurations", "LightColor", -1);
      this.SC.Config.SetValue<Color>("Configurations", "NeonColor", Color.Black);
      this.SC.Config.SetValue<bool>("Configurations", "RightNeonOn", false);
      this.SC.Config.SetValue<bool>("Configurations", "LeftNeonOn", false);
      this.SC.Config.SetValue<bool>("Configurations", "FrontNeonOn", false);
      this.SC.Config.SetValue<bool>("Configurations", "BackNeonOn", false);
      this.SC.Config.SetValue<VehicleColor>("Configurations", "Wheelcolour", VehicleColor.MatteBlack);
      this.SC.Config.SetValue<VehicleColor>("Configurations", "DashBoardColour", VehicleColor.MatteBlack);
      this.SC.Config.SetValue<Color>("Configurations", "TireSmokeColor", Color.Black);
      this.SC.Config.SetValue<bool>("Configurations", "TireSmoke", false);
      this.SC.Config.SetValue<VehicleColor>("Configurations", "TrimColor", VehicleColor.MatteBlack);
      this.SC.Config.SetValue<bool>("Configurations", "BulletProofTires", false);
      this.SC.Config.SetValue<int>("Configurations", "WheelType", -1);
      this.SC.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", false);
      this.SC.Config.SetValue<VehicleColor>("Configurations", "PrimaryColor", VehicleColor.DefaultAlloyColor);
      this.SC.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", false);
      this.SC.Config.SetValue<VehicleColor>("Configurations", "SecondaryColor", VehicleColor.DefaultAlloyColor);
      this.SC.Config.Save();
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

    public static Vector3 GenerateSpawnPos(
      Vector3 desiredPos,
      Class1.Nodetype roadtype,
      bool sidewalk)
    {
      Vector3 zero = Vector3.Zero;
      bool flag = false;
      OutputArgument outputArgument = new OutputArgument();
      int num1 = 1;
      int num2 = 0;
      if (roadtype == Class1.Nodetype.AnyRoad)
        num2 = 1;
      if (roadtype == Class1.Nodetype.Road)
        num2 = 0;
      if (roadtype == Class1.Nodetype.Offroad)
      {
        num2 = 1;
        flag = true;
      }
      if (roadtype == Class1.Nodetype.Water)
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

    public void SaveRandomMods(Vehicle newvehicle)
    {
      System.Random random = new System.Random();
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) newvehicle.Handle, (InputArgument) 0);
      Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) newvehicle, (InputArgument) this.WheelType);
      newvehicle.SetMod(VehicleMod.Livery, random.Next(-1, newvehicle.GetModCount(VehicleMod.Livery)), false);
      newvehicle.SetMod(VehicleMod.Roof, random.Next(-1, newvehicle.GetModCount(VehicleMod.Roof)), true);
      newvehicle.SetMod(VehicleMod.Aerials, random.Next(-1, newvehicle.GetModCount(VehicleMod.Aerials)), true);
      newvehicle.SetMod(VehicleMod.AirFilter, random.Next(-1, newvehicle.GetModCount(VehicleMod.AirFilter)), true);
      newvehicle.SetMod(VehicleMod.ArchCover, random.Next(-1, newvehicle.GetModCount(VehicleMod.ArchCover)), true);
      newvehicle.SetMod(VehicleMod.Armor, random.Next(-1, newvehicle.GetModCount(VehicleMod.Armor)), true);
      newvehicle.SetMod(VehicleMod.Brakes, random.Next(-1, newvehicle.GetModCount(VehicleMod.Livery)), true);
      newvehicle.SetMod(VehicleMod.ColumnShifterLevers, random.Next(-1, newvehicle.GetModCount(VehicleMod.ColumnShifterLevers)), true);
      newvehicle.SetMod(VehicleMod.Dashboard, random.Next(-1, newvehicle.GetModCount(VehicleMod.Dashboard)), true);
      newvehicle.SetMod(VehicleMod.DialDesign, random.Next(-1, newvehicle.GetModCount(VehicleMod.DialDesign)), true);
      newvehicle.SetMod(VehicleMod.DoorSpeakers, random.Next(-1, newvehicle.GetModCount(VehicleMod.DoorSpeakers)), true);
      newvehicle.SetMod(VehicleMod.Engine, random.Next(-1, newvehicle.GetModCount(VehicleMod.Engine)), true);
      newvehicle.SetMod(VehicleMod.EngineBlock, random.Next(-1, newvehicle.GetModCount(VehicleMod.EngineBlock)), true);
      newvehicle.SetMod(VehicleMod.Exhaust, random.Next(-1, newvehicle.GetModCount(VehicleMod.Exhaust)), true);
      newvehicle.SetMod(VehicleMod.Fender, random.Next(-1, newvehicle.GetModCount(VehicleMod.Fender)), true);
      newvehicle.SetMod(VehicleMod.Frame, random.Next(-1, newvehicle.GetModCount(VehicleMod.Frame)), true);
      newvehicle.SetMod(VehicleMod.FrontBumper, random.Next(-1, newvehicle.GetModCount(VehicleMod.FrontBumper)), true);
      newvehicle.SetMod(VehicleMod.Grille, random.Next(-1, newvehicle.GetModCount(VehicleMod.Grille)), true);
      newvehicle.SetMod(VehicleMod.Hood, random.Next(-1, newvehicle.GetModCount(VehicleMod.Hood)), true);
      newvehicle.SetMod(VehicleMod.Horns, random.Next(-1, newvehicle.GetModCount(VehicleMod.Horns)), true);
      newvehicle.SetMod(VehicleMod.Hydraulics, random.Next(-1, newvehicle.GetModCount(VehicleMod.Hydraulics)), true);
      newvehicle.SetMod(VehicleMod.Livery, random.Next(-1, 22), false);
      newvehicle.SetMod(VehicleMod.Ornaments, random.Next(-1, newvehicle.GetModCount(VehicleMod.Ornaments)), true);
      newvehicle.SetMod(VehicleMod.Plaques, random.Next(-1, newvehicle.GetModCount(VehicleMod.Plaques)), true);
      newvehicle.SetMod(VehicleMod.PlateHolder, random.Next(-1, newvehicle.GetModCount(VehicleMod.PlateHolder)), true);
      newvehicle.SetMod(VehicleMod.RearBumper, random.Next(-1, newvehicle.GetModCount(VehicleMod.RearBumper)), true);
      newvehicle.SetMod(VehicleMod.RightFender, random.Next(-1, newvehicle.GetModCount(VehicleMod.RightFender)), true);
      newvehicle.SetMod(VehicleMod.Seats, random.Next(-1, newvehicle.GetModCount(VehicleMod.Seats)), true);
      newvehicle.SetMod(VehicleMod.SideSkirt, random.Next(-1, newvehicle.GetModCount(VehicleMod.SideSkirt)), true);
      newvehicle.SetMod(VehicleMod.Speakers, random.Next(-1, newvehicle.GetModCount(VehicleMod.Speakers)), true);
      newvehicle.SetMod(VehicleMod.Spoilers, random.Next(-1, newvehicle.GetModCount(VehicleMod.Spoilers)), true);
      newvehicle.SetMod(VehicleMod.SteeringWheels, random.Next(-1, newvehicle.GetModCount(VehicleMod.SteeringWheels)), true);
      newvehicle.SetMod(VehicleMod.Struts, random.Next(-1, newvehicle.GetModCount(VehicleMod.Struts)), true);
      newvehicle.SetMod(VehicleMod.Suspension, random.Next(-1, newvehicle.GetModCount(VehicleMod.Suspension)), true);
      newvehicle.SetMod(VehicleMod.Tank, random.Next(-1, newvehicle.GetModCount(VehicleMod.Tank)), true);
      newvehicle.SetMod(VehicleMod.Transmission, random.Next(-1, newvehicle.GetModCount(VehicleMod.Transmission)), true);
      newvehicle.SetMod(VehicleMod.Trim, random.Next(-1, newvehicle.GetModCount(VehicleMod.Trim)), true);
      newvehicle.SetMod(VehicleMod.TrimDesign, random.Next(-1, newvehicle.GetModCount(VehicleMod.TrimDesign)), true);
      newvehicle.SetMod(VehicleMod.Trunk, random.Next(-1, newvehicle.GetModCount(VehicleMod.Trunk)), true);
      newvehicle.SetMod(VehicleMod.VanityPlates, random.Next(-1, newvehicle.GetModCount(VehicleMod.VanityPlates)), true);
      newvehicle.SetMod(VehicleMod.Windows, random.Next(-1, newvehicle.GetModCount(VehicleMod.Windows)), true);
    }

    public void CheckOcci(string iniName)
    {
      try
      {
        this.CheckOcciConfig = ScriptSettings.Load(iniName);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Terrobyte.ini Failed To Load.");
      }
    }

    private void SetColor(int particle, float r, float g, float b, bool p1) => Function.Call(Hash._0x7F8F65877F88783B, (InputArgument) particle, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) p1);

    private void SetRange(int handle, float range) => Function.Call(Hash._0xDCB194B85EF7B541, (InputArgument) handle, (InputArgument) range);

    private int GetBoneByName(Entity entity, string name) => Function.Call<int>(Hash._0xFB71170B7E76ACBA, (InputArgument) entity, (InputArgument) name);

    public void GetPositions()
    {
      this.CheckOcci("scripts//OpenCommandCenterInteriors.ini");
      this.MocBay = this.CheckOcciConfig.GetValue<int>("MOC", "ModBay1", this.MocBay);
      this.MocBay2 = this.CheckOcciConfig.GetValue<int>("MOC", "ModBay2", this.MocBay2);
      this.MocBay3 = this.CheckOcciConfig.GetValue<int>("MOC", "ModBay3", this.MocBay3);
      Vector3 vector3 = new Vector3();
      if (this.MocBay == 0 && this.MocBay2 == 4 && this.MocBay3 == 8)
      {
        this.VehicleBaypos = new Vector3(1104.476f, -3001.171f, -40f);
        vector3 = new Vector3(1102.159f, -2999.108f, -40f);
        this.GunLockerMarker = new Vector3(1102.159f, -2999.108f, -40f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Heading = 0.0f;
        this.VehicleToModify.Position = new Vector3(1103.518f, -2990.131f, -40f);
      }
      else if (this.MocBay == 0 && this.MocBay2 == 5 && this.MocBay3 == 0)
      {
        this.VehicleBaypos = new Vector3(1106.22f, -2992.623f, -40f);
        this.GunLockerMarker = new Vector3(1101.537f, -3002.34f, -40f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Heading = 0.0f;
        this.VehicleToModify.Position = new Vector3(1103.498f, -2996.4f, -40f);
      }
      else if (this.MocBay == 1 && this.MocBay2 == 2 && this.MocBay3 == 8)
      {
        this.VehicleBaypos = new Vector3(0.0f, 0.0f, 0.0f);
        vector3 = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Heading = 0.0f;
        this.VehicleToModify.Position = new Vector3(1103.518f, -2990.131f, -40f);
      }
      else if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 6)
      {
        this.VehicleBaypos = new Vector3(1104.608f, -2999.139f, -40f);
        vector3 = new Vector3(1102.228f, -2999.026f, -40f);
        this.GunLockerMarker = new Vector3(1102.228f, -2999.026f, -40f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 8)
      {
        this.VehicleBaypos = new Vector3(1104.476f, -3001.171f, -40f);
        vector3 = new Vector3(1102.228f, -2999.026f, -40f);
        this.GunLockerMarker = new Vector3(1102.228f, -2999.026f, -40f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Heading = 0.0f;
        this.VehicleToModify.Position = new Vector3(1103.518f, -2990.131f, -40f);
      }
      else if (this.MocBay == 1 && this.MocBay2 == 5 && this.MocBay3 == 0)
      {
        this.VehicleBaypos = new Vector3(1106.22f, -2992.623f, -40f);
        vector3 = new Vector3(1101.537f, -3002.34f, -40f);
        this.GunLockerMarker = new Vector3(1101.537f, -3002.34f, -40f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Heading = 0.0f;
        this.VehicleToModify.Position = new Vector3(1103.498f, -2996.4f, -40f);
      }
      else if (this.MocBay == 0 && this.MocBay2 == 4 && this.MocBay3 == 7)
      {
        this.VehicleBaypos = new Vector3(1104.476f, -3001.171f, -40f);
        vector3 = new Vector3(1102.404f, -2999.357f, -40f);
        this.GunLockerMarker = new Vector3(1102.404f, -2999.357f, -40f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 7)
      {
        this.VehicleBaypos = new Vector3(1104.476f, -3001.171f, -40f);
        vector3 = new Vector3(1102.404f, -2999.357f, -40f);
        this.GunLockerMarker = new Vector3(1102.404f, -2999.357f, -40f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 2 && this.MocBay3 == 7)
      {
        this.VehicleBaypos = new Vector3(0.0f, 0.0f, 0.0f);
        vector3 = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Delete();
      }
      else if (this.MocBay == 0 && this.MocBay2 == 3 && this.MocBay3 == 8)
      {
        this.VehicleBaypos = new Vector3(0.0f, 0.0f, 0.0f);
        vector3 = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Heading = 0.0f;
        this.VehicleToModify.Position = new Vector3(1103.518f, -2990.131f, -40f);
      }
      else if (this.MocBay == 0 && this.MocBay2 == 3 && this.MocBay3 == 7)
      {
        this.VehicleBaypos = new Vector3(0.0f, 0.0f, 0.0f);
        vector3 = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 3 && this.MocBay3 == 7)
      {
        this.VehicleBaypos = new Vector3(0.0f, 0.0f, 0.0f);
        vector3 = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 3 && this.MocBay3 == 6)
      {
        this.VehicleBaypos = new Vector3(0.0f, 0.0f, 0.0f);
        vector3 = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleToModify != (Entity) null))
          return;
        this.VehicleToModify.Delete();
      }
      else
      {
        if (this.MocBay != 1 || this.MocBay2 != 3 || this.MocBay3 != 8)
          return;
        this.VehicleBaypos = new Vector3(1104.543f, -3001.188f, -40f);
        vector3 = new Vector3(1102.159f, -2999.108f, -40f);
        this.GunLockerMarker = new Vector3(1102.159f, -2999.108f, -40f);
        if ((Entity) this.VehicleToModify != (Entity) null)
        {
          this.VehicleToModify.Heading = 0.0f;
          this.VehicleToModify.Position = new Vector3(1103.518f, -2990.131f, -40f);
        }
      }
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
      this.SupplyMissionProps.Add(World.CreateProp(this.RequestModel("prop_flare_01b"), X, false, false));
      int num = Function.Call<int>(Hash._0xE184F4F0DC5910E7, (InputArgument) "scr_crate_drop_flare", (InputArgument) X.X, (InputArgument) X.Y, (InputArgument) X.Z, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 5f, (InputArgument) false, (InputArgument) false, (InputArgument) false, (InputArgument) false);
      this.SetRange(num, 100000f);
      this.SetColor(num, (float) byte.MaxValue, (float) byte.MaxValue, 0.0f, true);
      this.SmokeParticles.Add(num);
    }

    private float progresswidth(float percent) => 0.08f * percent;

    private void drawText(string text, float x, float y, float scale, int r, int g, int b)
    {
      Function.Call(Hash._0x25FBB336DF1804CB, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0xBE6B23FFA53FB442, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) (int) byte.MaxValue);
      Function.Call(Hash._0x07C837F9A01C34C9, (InputArgument) 0.0f, (InputArgument) scale);
      Function.Call(Hash._0xCD015E5BB0D96A57, (InputArgument) x, (InputArgument) y, (InputArgument) 0.1);
    }

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

    public int GetHour() => Function.Call<int>(Hash._0x25223CA6B4D20B7F);

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
      int num = new System.Random().Next(0, 100);
      if (num >= 60)
        this.RaidEnemyTime = 1;
      if (num < 59)
        this.RaidEnemyTime = 0;
      this.WaitingForRaid = false;
      this.CurrentTime = this.GetHour();
      this.CurrentTime = this.GetHour();
      this.RaidHour = Game.GameTime + new System.Random().Next(225000, 880000);
      Class1.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Bunker Supply Raid", "Our Bunker is Under attack, we cannot afford to lose supplies!");
      Vector3 entry = this.Entry;
      this.RaidLocation = entry;
      Blip blip = World.CreateBlip(entry);
      blip.Sprite = BlipSprite.PropertyVagos;
      blip.Color = this.Blip_Colour;
      blip.Name = "Business Raid";
      blip.IsShortRange = true;
      this.SupplyMissionBlips.Add(blip);
      this.SupplyMissionOn = true;
      this.SupplyMissionID = 100;
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

    private void OnTick(object sender, EventArgs e)
    {
      // ISSUE: The method is too long to display (56149 instructions)
    }

    public class ResearchItem : Script
    {
      public ResearchItem()
      {
      }

      public int ActualIndex { get; set; }

      public int Index { get; set; }

      public bool Owned { get; set; }

      public string PicTex { get; set; }

      public new string Name { get; set; }

      public string Discription { get; set; }

      public VehicleHash ModifyVehicle { get; set; }

      public VehicleMod Modication { get; set; }

      public int ModicationID1 { get; set; }

      public int ModicationID2 { get; set; }

      public int ModicationID3 { get; set; }

      public int ModicationID4 { get; set; }

      public int ModicationID5 { get; set; }

      public int ModicationID6 { get; set; }

      public int ModicationID7 { get; set; }

      public int ModicationID8 { get; set; }

      public int ModicationID9 { get; set; }

      public int ModicationID10 { get; set; }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID1 = Id2;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2,
        int Id3)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID2 = Id2;
        this.ModicationID3 = Id3;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2,
        int Id3,
        int Id4)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID2 = Id2;
        this.ModicationID3 = Id3;
        this.ModicationID4 = Id4;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2,
        int Id3,
        int Id4,
        int Id5)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID2 = Id2;
        this.ModicationID3 = Id3;
        this.ModicationID4 = Id4;
        this.ModicationID5 = Id5;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2,
        int Id3,
        int Id4,
        int Id5,
        int Id6)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID2 = Id2;
        this.ModicationID3 = Id3;
        this.ModicationID4 = Id4;
        this.ModicationID5 = Id5;
        this.ModicationID6 = Id6;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2,
        int Id3,
        int Id4,
        int Id5,
        int Id6,
        int Id7)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID2 = Id2;
        this.ModicationID3 = Id3;
        this.ModicationID4 = Id4;
        this.ModicationID5 = Id5;
        this.ModicationID6 = Id6;
        this.ModicationID7 = Id7;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2,
        int Id3,
        int Id4,
        int Id5,
        int Id6,
        int Id7,
        int Id8)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID2 = Id2;
        this.ModicationID3 = Id3;
        this.ModicationID4 = Id4;
        this.ModicationID5 = Id5;
        this.ModicationID6 = Id6;
        this.ModicationID7 = Id7;
        this.ModicationID8 = Id8;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2,
        int Id3,
        int Id4,
        int Id5,
        int Id6,
        int Id7,
        int Id8,
        int Id9)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID2 = Id2;
        this.ModicationID3 = Id3;
        this.ModicationID4 = Id4;
        this.ModicationID5 = Id5;
        this.ModicationID6 = Id6;
        this.ModicationID7 = Id7;
        this.ModicationID8 = Id8;
        this.ModicationID9 = Id9;
      }

      public ResearchItem(
        int AI,
        int I,
        bool O,
        string N,
        string D,
        string Pt,
        VehicleHash Vh,
        VehicleMod Vm,
        int Id1,
        int Id2,
        int Id3,
        int Id4,
        int Id5,
        int Id6,
        int Id7,
        int Id8,
        int Id9,
        int Id10)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
        this.ModifyVehicle = Vh;
        this.Modication = Vm;
        this.ModicationID1 = Id1;
        this.ModicationID2 = Id2;
        this.ModicationID3 = Id3;
        this.ModicationID4 = Id4;
        this.ModicationID5 = Id5;
        this.ModicationID6 = Id6;
        this.ModicationID7 = Id7;
        this.ModicationID8 = Id8;
        this.ModicationID9 = Id9;
        this.ModicationID10 = Id10;
      }

      public ResearchItem(int AI, int I, bool O, string N, string D, string Pt)
      {
        this.ActualIndex = AI;
        this.Index = I;
        this.Owned = O;
        this.Name = N;
        this.Discription = D;
        this.PicTex = Pt;
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
