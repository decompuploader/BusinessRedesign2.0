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

namespace Smuggler_s_Run_Business
{
  public class Hanger : Script
  {
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    private ScriptSettings MainConfigFile;
    public SaveCar SC;
    public Vector3 EnterMarkerA;
    public Vector3 EnterMarkerB;
    public Vector3 EnterMarkerC;
    public Vector3 ExitMarker;
    public Vector3 Vehicle1Loc = new Vector3(-1266.4f, -3014.55f, -48f);
    public Vehicle Vehicle1;
    public Vector3 Vehicle2Loc = new Vector3(-1279.21f, -3031.65f, -48f);
    public Vehicle Vehicle2;
    public Vector3 Vehicle3Loc = new Vector3(-1254.5f, -3034.5f, -48f);
    public Vehicle Vehicle3;
    public Vector3 Vehicle4Loc = new Vector3(-1276.6f, -3003.17f, -48f);
    public Vehicle Vehicle4;
    public Vector3 Vehicle5Loc = new Vector3(-1255.51f, -3003.06f, -48f);
    public Vehicle Vehicle5;
    public Vector3 Vehicle6Loc = new Vector3(-1266.44f, -2990.81f, -48f);
    public Vehicle Vehicle6;
    public Vector3 Vehicle7Loc = new Vector3(-1278.36f, -2989.93f, -48f);
    public Vehicle Vehicle7;
    public Vector3 Vehicle8Loc = new Vector3(-1254.87f, -2986.58f, -48f);
    public Vehicle Vehicle8;
    public Vector3 Vehicle9Loc = new Vector3(-1266.9f, -2978.2f, -48f);
    public Vehicle Vehicle9;
    public Vector3 Vehicle10Loc = new Vector3(-1256.58f, -2973.8f, -48f);
    public Vehicle Vehicle10;
    public Vector3 Vehicle11Loc = new Vector3(-1276.78f, -2972.16f, -48f);
    public Vehicle Vehicle11;
    public Vector3 Vehicle12Loc = new Vector3(-1266.9f, -3043.39f, -48f);
    public Vehicle Vehicle12;
    public Vector3 MenuMarker = new Vector3(0.0f, 0.0f, 0.0f);
    public MenuPool modMenuPool;
    public UIMenu GarageMenu;
    public UIMenu mainMenu;
    public Vector3 EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
    public Vector3 ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
    private string path = "scripts//HKH191sBusinessMods//Smuggler's Run Business//HangerStorage//Hanger//";
    private string path2 = "scripts//HKH191sBusinessMods//Smuggler's Run Business//HangerStorage//Garage//";
    public Vehicle SaveVehicle;
    public Vector3 RemoveMarker = new Vector3(-1243.91f, -2995.03f, -44f);
    public MenuPool modMenuPool2;
    public UIMenu RemoveMenu;
    public UIMenu mainMenu2;
    public string GarageNum;
    public Vector3 Entry = new Vector3(-1146.24f, -3409.77f, 13f);
    public Vector3 Exit = new Vector3(-1266.63f, -2965.281f, -49.5f);
    public Blip Hanger1;
    public ScriptSettings Config;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public int stockstimer;
    public int waittime = 3200;
    public int DisplayWait;
    public float increaseGain;
    public int GunlockerBought;
    public int VehicleBayBought;
    public string[] vehicleNames;
    public int UnrestictedAccessInFortZancudo;
    public int UnrestictedAccessInFortZancudoVIP;
    public Vector3 Car1Loc = new Vector3(-1241.94f, -2982.58f, -48f);
    public Vehicle Car1;
    public Vector3 Car2Loc = new Vector3(-1238.94f, -2982.58f, -48f);
    public Vehicle Car2;
    public Vector3 Car3Loc = new Vector3(-1235.94f, -2982.58f, -48f);
    public Vehicle Car3;
    public Vector3 Car4Loc = new Vector3(-1232.94f, -2982.58f, -48f);
    public Vehicle Car4;
    public MenuPool CarMenuPool;
    public UIMenu CarMenu;
    public UIMenu BuyCar;
    public Vector3 CarMarker = new Vector3(-1245.72f, -2982.82f, -49.5f);
    public int CycloneBought;
    public int RapidGTBought;
    public int RetinueBought;
    public int VisioneBought;
    public List<Ped> PlaneTargetPositions = new List<Ped>();
    public bool IsInInterior;
    public bool IsScriptEnabled;
    public bool ISinviewMode;
    public Camera Cam;
    public bool CameraOn;
    public Vector3 PlayerPos = new Vector3(-1264.92f, -3012.03f, 1000.98f);
    public Vector3 CamAPos = new Vector3(-1257f, -3012f, 1004f);
    public Vector3 CamBPos = new Vector3(-1287f, -3012f, 1004f);
    public Vector3 P;
    public int BusinessLocation;
    public ScriptSettings ScriptConfig;
    public float BusinessUpgradeIncreaseGain = 75000f;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    private ScriptSettings ConfigCustomizeHanger;
    public Vector3 Marker = new Vector3(-1243.65f, -2988.09f, -42.3f);
    private MenuPool CHmodMenuPool;
    private UIMenu FloorMenu;
    private UIMenu CHmainMenu;
    public UIMenu ColorMenu;
    public string HangarLighting;
    public string HangarFloor;
    public string HangarFloorDecal;
    public string HangarBedroom;
    public string HangarOffice;
    public string HangarBedroomBlinds;
    public string HangarLightingWallTint;
    public string HangarNeutralLighting = "DISABLED";
    public int HangarFloorDecalColor;
    public int HangarShellColor;
    public int HangarBedroomColor;
    public int HangarCraneColor;
    public int HangarWorkshopColor;
    public int HangarLightingTintPropsColor;
    public int MaxColors = 8;
    public bool bought;
    public MenuPool BSmodMenuPool;
    public MenuPool BSmodMenuPool2;
    public UIMenu BSmainMenu2;
    public UIMenu BSGarageMenu;
    public UIMenu BSGarageMenu2;
    public Vector3 BSMarker = new Vector3(-1243.65f, -3018.09f, -44f);
    public Vector3 Marker2 = new Vector3(-1293.48f, -3022.18f, -49.5f);
    public UIMenu BSmainMenu;
    public UIMenu methgarage;
    public UIMenu ProductStock;
    public Vector3 Gunlockerpos = new Vector3(-1298.7f, -3016.9f, -49.7f);
    public UIMenu Extra;
    public UIMenu AirAssault;
    public Vehicle Plane;
    public Blip PlaneBlip;
    public UIMenu MovingAA;
    public Vector3 Sam1Loc;
    public Vector3 Sam2Loc;
    public Vector3 Sam3Loc;
    public Vehicle Sam1;
    public Vehicle Sam2;
    public Vehicle Sam3;
    public Blip Sam1blip;
    public Blip Sam2blip;
    public Blip Sam3blip;
    public Vector3 PointA = new Vector3(1449.81f, -1055.17f, 56f);
    public Vector3 PointB = new Vector3(261.564f, 6566.24f, 31f);
    public Vector3 PointC = new Vector3(-2161.85f, -365.008f, 13f);
    public UIMenu Smuggling;
    public bool MissionSetup;
    public int missionnum;
    public Blip DropPoint;
    public bool Notify;
    public Vector3 MissionMarker;
    public bool DeliveryMissionOn;
    public UIMenu DeliveyMission;
    public int shipmentsDElivered;
    public Vector3 Spawn;
    public Blip LocationBlip;
    public AllStocks Allstocks;
    public UIMenu Specialmissions;
    public List<Ped> Peds;
    public Vehicle Aircraft;
    public int Enemies;
    public UIMenu AiralCheckpointRace;
    public int checkpointReaced;
    public Vector3 NextCheckPoint;
    public int maxCheckpoints;
    public int Race;
    public Vector3[] CheckPoints;
    public float[] Rotation;
    public int CurrentPoint;
    public int MaxTimer;
    public int Timer;
    public int IntervalTimer;
    public Vector3 BSEntry = new Vector3(-1146.24f, -3409.77f, 13f);
    public List<Vector3> pPosition = new List<Vector3>();
    public List<Prop> Props = new List<Prop>();
    public List<string> CrateIds = new List<string>();
    public Vehicle ActiveTarget;
    public Vehicle AIplane;
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
    public List<string> CrateProps2 = new List<string>()
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
    public int PointsBeenAt;
    public List<Vector3> DropPoint2 = new List<Vector3>();
    public List<Blip> DropBlip = new List<Blip>();
    public List<Ped> SuppyGuards = new List<Ped>();
    public bool CreateSupplyVehicle;
    public bool GotVehicle;
    public int SupplyMission = 1;
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public Blip SupplyGarageBlip;
    public List<Blip> PlaneBlips = new List<Blip>();
    public List<Vehicle> AIPlanes = new List<Vehicle>();
    public int NumberOfPlanes;
    public int TargetTimer;
    public Ped CurrentTarget;
    public Vector3 ChairPos = new Vector3(-1240.082f, -3001.823f, -44.3f);
    public float P_Rotation = 175f;
    public bool IsSittinginCeoSeat;
    public bool UseOldMarker;
    public Blip EndPointBlip;
    public Vector3 EndPointVec;
    public Vector3 SleepPos1 = new Vector3(-1295.88f, -3024.98f, -44f);
    public Vector3 SleepPos2 = new Vector3(-1237.88f, -2983.98f, -41f);
    public Prop ExChair;
    public Vector3 ExChairPos = new Vector3(-1239.825f, -3001.835f, -43.8f);
    public float ExP_Rotation = -7f;
    public bool FirstTime;
    private Keys Key1;
    private UIMenu weaponsMenu;
    public Vector3 GunLockerMarker;
    public int GunLockerBought;
    public int GunLockerBought2;
    public int GunLockerBought3;
    public int GunLockerBought4;
    public int GunLockerBought5;
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
    private Keys Key3;
    private MenuPool MVmodMenuPool;
    private UIMenu MVmainMenu;
    public int MoneyVaultBought = 1;
    public float MoneyStored;
    public float Commission;
    public UIMenu MoneyMenu;
    public Vector3 MoneyStorageMarker = new Vector3(-1235.4f, -3003.132f, -44f);
    public int currentbank;
    public bool read;
    public Blip Range;
    public int FZHanger1Bought;
    public int FZHanger2Bought;
    public int FZHanger3Bought;
    public Vector3 FZHanger1Pos = new Vector3(-2021f, 3158f, 31.5f);
    public Vector3 FZHanger2Pos = new Vector3(-2472f, 3266f, 31.5f);
    public Vector3 FZHanger3Pos = new Vector3(-1923f, 3129f, 31.5f);
    public bool Warned;
    public bool IsInRestictedZone;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public int SMG_StealsCompleted = 2;
    public int SMG_StealsFailed = 1;
    public int SMG_SalesCompleted = 4;
    public int SMG_SalesFailed = 1;
    public int SMG_MaxCratesPerCargo = 50;
    public int SMG_Narcotics_CurrentStock;
    public int SMG_Narcotics_StockMax = 50;
    public int SMG_Chemicals_CurrentStock;
    public int SMG_Chemicals_StockMax = 50;
    public int SMG_MedicalSupplies_CurrentStock;
    public int SMG_MedicalSupplies_StockMax = 50;
    public int SMG_AnimalMaterials_CurrentStock;
    public int SMG_AnimalMaterials_StockMax = 50;
    public int SMG_ArtaAntiques_CurrentStock;
    public int SMG_ArtaAntiques_StockMax = 50;
    public int SMG_JewelryaGemstones_CurrentStock;
    public int SMG_JewelryaGemstones_StockMax = 50;
    public int SMG_TabaccoaAlcohol_CurrentStock;
    public int SMG_TabaccoaAlcohol_StockMax = 50;
    public int SMG_CounterfeitGoods_CurrentStock;
    public int SMG_CounterfeitGoods_StockMax = 50;
    public int SMG_RivalCratesStolen = 6;
    public int SMG_Earnings = 24000;
    public int SMG_MaxCrates;
    public int SMG_CurrentCrates;
    public float SMG_ValueTotal;
    public float SMG_SellMultiplier = 1f;
    public float SMG_CargoTypeBonus = 14000f;
    public string SMG_Name = "HKH191";
    public int SMG_StealSuccessRate = 98;
    public int SMG_SalesSuccessRate = 94;
    public float SMG_Narcotics_Bonus;
    public float SMG_Narcotics_Value = 100000f;
    public float SMG_Chemicals_Bonus;
    public float SMG_Chemicals_Value = 98000f;
    public float SMG_MedicalSupplies_Bonus;
    public float SMG_MedicalSupplies_Value = 62562f;
    public float SMG_AnimalMaterials_Bonus;
    public float SMG_AnimalMaterials_Value = 51251f;
    public float SMG_ArtaAntiques_Bonus;
    public float SMG_ArtaAntiques_Value = 15151f;
    public float SMG_JewelryaGemstones_Bonus;
    public float SMG_JewelryaGemstones_Value = 62661f;
    public float SMG_TabaccoaAlcohol_Bonus;
    public float SMG_TabaccoaAlcohol_Value = 107333f;
    public float SMG_CounterfeitGoods_Bonus;
    public float SMG_CounterfeitGoods_Value = 34468f;
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
    public string ChairPropModel = "ex_prop_offchair_exec_01";
    public int LiveryColor;
    public int TimerCheck;
    public bool isWanted;
    public Vector3 CurrentSleepPos;
    public int CrateSelected;
    public List<Vector3> SelectedSellPoints = new List<Vector3>();
    public List<Vector3> CompletedSellPoints = new List<Vector3>();
    public List<Vector3> SellPoints = new List<Vector3>()
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
    public List<Hanger.Flare> SellPointsSmoke = new List<Hanger.Flare>();
    public List<Hanger.Flare> Cargo = new List<Hanger.Flare>();
    public List<Vector3> CargoDropped = new List<Vector3>();
    public List<Vector3> SourcePoints = new List<Vector3>()
    {
      new Vector3(338.3716f, 3568.881f, 32.44322f),
      new Vector3(1066.584f, 3589.798f, 30.43499f),
      new Vector3(1356.851f, 3701.854f, 31.84735f),
      new Vector3(1989.795f, 4554.337f, 32.16304f),
      new Vector3(2102.935f, 4855.352f, 40.38426f),
      new Vector3(2183.893f, 5017.904f, 41.51529f),
      new Vector3(2613.139f, 4871.473f, 33.86034f),
      new Vector3(2806.946f, 4764.055f, 45.81653f),
      new Vector3(2495.035f, 3298.332f, 50.60514f),
      new Vector3(2056.551f, 2806.174f, 49.2865f),
      new Vector3(1620.27f, 3150.115f, 41.89102f),
      new Vector3(1413.395f, 3065.493f, 42.31926f),
      new Vector3(918.3222f, 3014.121f, 38.58064f),
      new Vector3(413.3119f, 2860.105f, 40.394f),
      new Vector3(97.93906f, 2984.388f, 48.72215f),
      new Vector3(-1979.634f, 2580.193f, 1.88986f),
      new Vector3(-2540.238f, 2683.019f, 1.895788f),
      new Vector3(-2745.847f, 2808.593f, 1.289007f),
      new Vector3(-2866.743f, 3480.825f, 8.088282f),
      new Vector3(-1638.438f, 4576.119f, 41.96694f),
      new Vector3(255.4173f, 3599.532f, 33.38441f),
      new Vector3(1037.875f, 2259.396f, 42.7439f),
      new Vector3(1529.753f, 1528.534f, 106.6355f),
      new Vector3(1807.44f, 1741.793f, 71.92943f),
      new Vector3(2944.245f, 2787.209f, 39.04476f),
      new Vector3(2552.683f, 5539.616f, 44.59539f),
      new Vector3(1537.987f, 6629.451f, 1.405873f),
      new Vector3(1066.54f, 6609.184f, 2.093187f),
      new Vector3(361.7027f, 6878.283f, 4.316709f)
    };
    private int num;
    public int CrateSpawn;
    public List<int> SmokeParticles = new List<int>();
    public List<Hanger.Flare> SmokePropaParticles = new List<Hanger.Flare>();
    public bool SupplyMissionOn;
    public int SupplyMissionID;
    public int SupplyMissionStage;
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
    public int CratesToCollect;
    public int CratesCollected;
    public bool WaitingForDrop;
    public bool Firsttime;
    public int Selectedpoints;
    public int PointstoGoto;
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
    public Vehicle SourceVehicle1;
    public Blip DeliverPointBlip;
    public int SourcingMissionType;
    public bool GotCrate1;
    public bool DeliveredCrate1;
    public bool CreatedDeliverPoint;
    public int SupplyMissionType;
    public string Crate1StringID;
    public string Crate2StringID;
    public string Crate3StringID;
    public int CargoMissionTimer;
    public int SpecialCargoMissionEndTimer;
    public int MissionWait;
    public int MissionWait2;
    public float PlaneHeading;

    private void LoadMain(string iniName)
    {
      try
      {
        this.MainConfigFile = ScriptSettings.Load(iniName);
        this.BusinessLocation = this.MainConfigFile.GetValue<int>("Misc", "BusinessLocation", this.BusinessLocation);
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
        if (this.BusinessLocation == 0)
        {
          this.Entry = new Vector3(-1146.24f, -3409.77f, 13f);
          this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
          this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
        }
        if (this.BusinessLocation == 1)
        {
          this.Entry = new Vector3(-1418f, -3252f, 13f);
          this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
          this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
        }
        if (this.BusinessLocation == 2)
        {
          this.Entry = new Vector3(-2021f, 3158f, 31.5f);
          this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
          this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
        }
        if (this.BusinessLocation == 3)
        {
          this.Entry = new Vector3(-2472f, 3266f, 31.5f);
          this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
          this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
        }
        if (this.BusinessLocation != 4)
          return;
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: SRB Main.ini Failed To Load.");
      }
    }

    public void MainModRefresh()
    {
      UI.Notify("~g~ Found Refresh Sequence~w~");
      this.LoadMain("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
      this.BusinessLocation = this.MainConfigFile.GetValue<int>("Misc", "BusinessLocation", this.BusinessLocation);
      if (this.BusinessLocation == 0)
      {
        this.Entry = new Vector3(-1146.24f, -3409.77f, 13f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.BusinessLocation == 1)
      {
        this.Entry = new Vector3(-1418f, -3252f, 13f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.BusinessLocation == 2)
      {
        this.Entry = new Vector3(-2021f, 3158f, 31.5f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.BusinessLocation == 3)
      {
        this.Entry = new Vector3(-2472f, 3266f, 31.5f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.BusinessLocation == 4)
      {
        this.Entry = new Vector3(-1923f, 3129f, 31.5f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.Hanger1 != (Blip) null)
        this.Hanger1.Remove();
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.Hanger1 = World.CreateBlip(this.Entry);
      if (this.purchaselvl >= 1)
      {
        this.Hanger1.Sprite = BlipSprite.GTAOHangar;
        this.Hanger1.Color = this.Blip_Colour;
        this.Hanger1.Name = "Smuggler's Run Business";
        this.Hanger1.IsShortRange = true;
        this.Hanger1.Alpha = (int) byte.MaxValue;
      }
      else
      {
        this.Hanger1.Sprite = BlipSprite.GTAOHangar;
        this.Hanger1.Color = BlipColor.White;
        this.Hanger1.Name = "Hamger for Sale";
        this.Hanger1.IsShortRange = true;
        this.Hanger1.Alpha = 0;
      }
    }

    public void MainModDestroy()
    {
      if (!(this.Hanger1 != (Blip) null))
        return;
      this.Hanger1.Remove();
    }

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
      this.CheckHostName("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
      this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
      this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      string str = "~" + this.Uicolour + "~";
      return this.HostName;
    }

    public Model RequestModel(string Name)
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

    public Model RequestModel(VehicleHash Name)
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

    public Model RequestModel(PedHash Name)
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

    public void SetupPropSpawns()
    {
      this.pPosition.Add(new Vector3(-1242.911f, -3008.842f, -49.5f));
      this.pPosition.Add(new Vector3(-1243.189f, -3009.366f, -49.5f));
      this.pPosition.Add(new Vector3(-1243.129f, -3012f, -49.5f));
      this.pPosition.Add(new Vector3(-1242.911f, -3008.842f, -49.5f));
      this.pPosition.Add(new Vector3(-1236.713f, -3012.439f, -49.5f));
      this.pPosition.Add(new Vector3(-1237.033f, -3009.266f, -49.5f));
      this.pPosition.Add(new Vector3(-1239.588f, -3001.01f, -49.5f));
      this.pPosition.Add(new Vector3(-1239.252f, -2998.022f, -49.5f));
      this.pPosition.Add(new Vector3(-1237.197f, -2998.335f, -49.5f));
      this.pPosition.Add(new Vector3(-1230.477f, -2995.406f, -49.5f));
      this.pPosition.Add(new Vector3(-1230.265f, -2997.903f, -49.5f));
      this.pPosition.Add(new Vector3(-1230.352f, -3005.285f, -49.5f));
      this.pPosition.Add(new Vector3(-1230.458f, -3007.861f, -49.5f));
      this.pPosition.Add(new Vector3(-1229.646f, -3013.228f, -49.5f));
      this.pPosition.Add(new Vector3(-1229.797f, -3016.1f, -49.5f));
      this.pPosition.Add(new Vector3(-1224.946f, -3016.531f, -49.5f));
      this.pPosition.Add(new Vector3(-1222.274f, -3016.504f, -49.5f));
      this.pPosition.Add(new Vector3(-1221.946f, -3014.043f, -49.5f));
      this.pPosition.Add(new Vector3(-1224.873f, -3013.977f, -49.5f));
      this.pPosition.Add(new Vector3(-1237.722f, -3018.171f, -49.5f));
      this.pPosition.Add(new Vector3(-1240.338f, -3017.891f, -49.5f));
      this.pPosition.Add(new Vector3(-1243.283f, -3006.923f, -49.5f));
      this.pPosition.Add(new Vector3(-1236.943f, -3006.873f, -49.5f));
      this.pPosition.Add(new Vector3(-1234.441f, -3001.103f, -49.5f));
      this.pPosition.Add(new Vector3(-1237.073f, -3000.856f, -49.5f));
      this.pPosition.Add(new Vector3(-1222.214f, -2997.915f, -49.5f));
      this.pPosition.Add(new Vector3(-1222.085f, -2995.37f, -49.5f));
    }

    public int GetCrateProp(string S)
    {
      int num = 0;
      string str = S;
      List<string> stringList = new List<string>();
      stringList.Add("sm_prop_smug_crate_l_antiques");
      stringList.Add("sm_prop_smug_crate_l_bones");
      stringList.Add("sm_prop_smug_crate_l_fake");
      stringList.Add("sm_prop_smug_crate_l_hazard");
      stringList.Add("sm_prop_smug_crate_l_jewellery");
      stringList.Add("sm_prop_smug_crate_l_medical");
      stringList.Add("sm_prop_smug_crate_l_narc");
      stringList.Add("sm_prop_smug_crate_l_tobacco");
      stringList.Add("sm_prop_smug_crate_m_antiques");
      stringList.Add("sm_prop_smug_crate_m_bones");
      stringList.Add("sm_prop_smug_crate_m_fake");
      stringList.Add("sm_prop_smug_crate_m_hazard");
      stringList.Add("sm_prop_smug_crate_m_jewellery");
      stringList.Add("sm_prop_smug_crate_m_medical");
      stringList.Add("sm_prop_smug_crate_m_narc");
      stringList.Add("sm_prop_smug_crate_m_tobacco");
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
      stringList.Add("sm_prop_smug_crate_l_antiques");
      stringList.Add("sm_prop_smug_crate_l_bones");
      stringList.Add("sm_prop_smug_crate_l_fake");
      stringList.Add("sm_prop_smug_crate_l_hazard");
      stringList.Add("sm_prop_smug_crate_l_jewellery");
      stringList.Add("sm_prop_smug_crate_l_medical");
      stringList.Add("sm_prop_smug_crate_l_narc");
      stringList.Add("sm_prop_smug_crate_l_tobacco");
      stringList.Add("sm_prop_smug_crate_m_antiques");
      stringList.Add("sm_prop_smug_crate_m_bones");
      stringList.Add("sm_prop_smug_crate_m_fake");
      stringList.Add("sm_prop_smug_crate_m_hazard");
      stringList.Add("sm_prop_smug_crate_m_jewellery");
      stringList.Add("sm_prop_smug_crate_m_medical");
      stringList.Add("sm_prop_smug_crate_m_narc");
      stringList.Add("sm_prop_smug_crate_m_tobacco");
      for (int index = 0; index < stringList.Count; ++index)
        str = stringList[I];
      return str;
    }

    public void CrateProps()
    {
      this.CrateIds.Add("sm_prop_smug_crate_l_antiques");
      this.CrateIds.Add("sm_prop_smug_crate_l_bones");
      this.CrateIds.Add("sm_prop_smug_crate_l_fake");
      this.CrateIds.Add("sm_prop_smug_crate_l_hazard");
      this.CrateIds.Add("sm_prop_smug_crate_l_jewellery");
      this.CrateIds.Add("sm_prop_smug_crate_l_medical");
      this.CrateIds.Add("sm_prop_smug_crate_l_narc");
      this.CrateIds.Add("sm_prop_smug_crate_l_tobacco");
      this.CrateIds.Add("sm_prop_smug_crate_m_antiques");
      this.CrateIds.Add("sm_prop_smug_crate_m_bones");
      this.CrateIds.Add("sm_prop_smug_crate_m_fake");
      this.CrateIds.Add("sm_prop_smug_crate_m_hazard");
      this.CrateIds.Add("sm_prop_smug_crate_m_jewellery");
      this.CrateIds.Add("sm_prop_smug_crate_m_medical");
      this.CrateIds.Add("sm_prop_smug_crate_m_narc");
      this.CrateIds.Add("sm_prop_smug_crate_m_tobacco");
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

    public void CreateSGRCratesInHanger(int Stock)
    {
      int num1 = 0;
      this.SMG_MaxCrates = this.SMG_Narcotics_StockMax + this.SMG_Chemicals_StockMax + this.SMG_MedicalSupplies_StockMax + this.SMG_AnimalMaterials_StockMax + this.SMG_ArtaAntiques_StockMax + this.SMG_JewelryaGemstones_StockMax + this.SMG_TabaccoaAlcohol_StockMax + this.SMG_CounterfeitGoods_StockMax;
      this.SMG_CurrentCrates = this.SMG_Narcotics_CurrentStock + this.SMG_Chemicals_CurrentStock + this.SMG_MedicalSupplies_CurrentStock + this.SMG_AnimalMaterials_CurrentStock + this.SMG_ArtaAntiques_CurrentStock + this.SMG_JewelryaGemstones_CurrentStock + this.SMG_TabaccoaAlcohol_CurrentStock + this.SMG_CounterfeitGoods_CurrentStock;
      Stock = this.SMG_MaxCrates;
      int num2 = 0;
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      System.Random random = new System.Random();
      int num3 = 1;
      int num4 = 1;
      for (int index = 0; index < 26; ++index)
      {
        if (num3 == 1)
        {
          if (num2 + this.SMG_MaxCrates / this.SMG_MaxCratesPerCargo <= Stock)
          {
            this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + num4.ToString(), this.CrateSpawn);
            if (this.CrateSpawn != -1)
            {
              this.SpawnCrates(this.GetCrateProp(this.CrateSpawn), this.pPosition[index], new Vector3(0.0f, 0.0f, 180f));
              num2 += this.SMG_MaxCrates / this.SMG_MaxCratesPerCargo;
              ++num1;
            }
            ++num4;
          }
          num3 = 2;
        }
        if (num3 == 2)
        {
          if (num2 + this.SMG_MaxCrates / this.SMG_MaxCratesPerCargo <= Stock)
          {
            this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + num4.ToString(), this.CrateSpawn);
            if (this.CrateSpawn != -1)
            {
              this.SpawnCrates(this.GetCrateProp(this.CrateSpawn), new Vector3(this.pPosition[index].X, this.pPosition[index].Y, this.pPosition[index].Z + 2.25f), new Vector3(0.0f, 0.0f, 180f));
              num2 += this.SMG_MaxCrates / this.SMG_MaxCratesPerCargo;
              ++num1;
            }
            ++num4;
          }
          num3 = 1;
        }
      }
      UI.Notify("Counted " + num1.ToString() + "/" + 50.ToString());
    }

    public void DeleteSGRCratesInHanger()
    {
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
    }

    public void SetupProduct()
    {
      UIMenu uiMenu = this.BSmodMenuPool.AddSubMenu(this.ProductStock, "Buy/Sell Product");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
          UI.Notify(this.GetHostName() + "  Here is where we are at");
          UI.Notify("Level: " + this.purchaselvl.ToString() + "/20");
          UI.Notify("Max Stocks: " + this.maxstocks.ToString());
          UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
          UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
          UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
        }
        if (item == Buy2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
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
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.TipTruck, this.Spawn, 0.0f);
            this.StockVeh.ToggleExtra(2, false);
            Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
            Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
            this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
            System.Random random = new System.Random();
            Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp1 = prop1;
            this.SellStockProps.Add(prop1);
            Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp2 = prop2;
            this.SellStockProps.Add(prop2);
            this.SellStockProp1.HasCollision = false;
            this.SellStockProp2.HasCollision = false;
          }
          if (this.stockscount > 200)
          {
            System.Random random = new System.Random();
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Flatbed, this.Spawn, 0.0f);
            Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
            Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
            Vector3 offsetInWorldCoords3 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
            Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp1 = prop1;
            this.SellStockProps.Add(prop1);
            Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp2 = prop2;
            this.SellStockProps.Add(prop2);
            Prop prop3 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords3, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
            this.SellStockProp3 = prop3;
            this.SellStockProps.Add(prop3);
            this.SellStockProp1.HasCollision = false;
            this.SellStockProp2.HasCollision = false;
            this.SellStockProp3.HasCollision = false;
          }
          if (this.stockscount < 100)
          {
            System.Random random = new System.Random();
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Guardian, this.Spawn, 0.0f);
            Vector3 offsetInWorldCoords = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.1f));
            Prop prop = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
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
          foreach (Vector3 position in this.DropPoint2)
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
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
          foreach (Vector3 position in this.DropPoint2)
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
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
          Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.Sam1.Heading), false, false);
          this.SellStockProp1 = prop1;
          this.SellStockProps.Add(prop1);
          Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.Sam1.Heading), false, false);
          this.SellStockProp2 = prop2;
          this.SellStockProps.Add(prop2);
          Prop prop3 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords3, new Vector3(0.0f, 0.0f, this.Sam1.Heading), false, false);
          this.SellStockProp3 = prop3;
          this.SellStockProps.Add(prop3);
          this.SellStockProp1.HasCollision = false;
          this.SellStockProp2.HasCollision = false;
          this.SellStockProp3.HasCollision = false;
          Vector3 offsetInWorldCoords4 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
          Vector3 offsetInWorldCoords5 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
          Vector3 offsetInWorldCoords6 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
          Prop prop4 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords4, new Vector3(0.0f, 0.0f, this.Sam2.Heading), false, false);
          this.SellStockProp4 = prop4;
          this.SellStockProps.Add(prop4);
          Prop prop5 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords5, new Vector3(0.0f, 0.0f, this.Sam2.Heading), false, false);
          this.SellStockProp5 = prop5;
          this.SellStockProps.Add(prop5);
          Prop prop6 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords6, new Vector3(0.0f, 0.0f, this.Sam2.Heading), false, false);
          this.SellStockProp6 = prop6;
          this.SellStockProps.Add(prop6);
          this.SellStockProp4.HasCollision = false;
          this.SellStockProp5.HasCollision = false;
          this.SellStockProp6.HasCollision = false;
          Vector3 offsetInWorldCoords7 = this.Sam3.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
          Vector3 offsetInWorldCoords8 = this.Sam3.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
          Vector3 offsetInWorldCoords9 = this.Sam3.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
          Prop prop7 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords7, new Vector3(0.0f, 0.0f, this.Sam3.Heading), false, false);
          this.SellStockProp7 = prop7;
          this.SellStockProps.Add(prop7);
          Prop prop8 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords8, new Vector3(0.0f, 0.0f, this.Sam3.Heading), false, false);
          this.SellStockProp8 = prop8;
          this.SellStockProps.Add(prop8);
          Prop prop9 = World.CreateProp(this.RequestModel(this.CrateProps2[random1.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords9, new Vector3(0.0f, 0.0f, this.Sam3.Heading), false, false);
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
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
        UI.Notify(this.GetHostName() + " ok i can deal with that, selling all product avalable");
        Game.Player.Money += (int) ((double) this.stocksvalue * 0.75);
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
    }

    public void Setupbuisness()
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
      UIMenu uiMenu1 = this.BSmodMenuPool.AddSubMenu(this.methgarage, "Change Chair Prop Model ");
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
        if ((Entity) this.ExChair != (Entity) null)
        {
          vector3 = this.ExChair.Position;
          num2 = this.ExChair.Heading;
        }
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__238.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__238.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.ChairPropModel = Hanger.\u003C\u003Eo__238.\u003C\u003Ep__0.Target((CallSite) Hanger.\u003C\u003Eo__238.\u003C\u003Ep__0, Chairs[MainChairlist.Index]);
        this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
        this.Config.Save();
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__238.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__238.\u003C\u003Ep__2 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, System.Type, object> target = Hanger.\u003C\u003Eo__238.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, System.Type, object>> p2 = Hanger.\u003C\u003Eo__238.\u003C\u003Ep__2;
        System.Type type = typeof (UI);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__238.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__238.\u003C\u003Ep__1 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Hanger.\u003C\u003Eo__238.\u003C\u003Ep__1.Target((CallSite) Hanger.\u003C\u003Eo__238.\u003C\u003Ep__1, "~g~ HKH191~w~  : Main Chair Model has been set to ", Chairs[MainChairlist.Index]);
        target((CallSite) p2, type, obj);
        if ((Entity) this.ExChair != (Entity) null)
          this.ExChair.Delete();
        this.ExChairPos = new Vector3(-1239.287f, -3001.7f, -43.8f);
        this.ExChair = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ExChairPos, new Vector3(0.0f, 0.0f, -66f), false, false);
        this.ExChair.FreezePosition = true;
        if (!((Entity) this.ExChair != (Entity) null))
          return;
        this.ExChair.Position = vector3;
        this.ExChair.Heading = num2;
      });
      UIMenu uiMenu2 = this.BSmodMenuPool.AddSubMenu(this.methgarage, "Expand Business ");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.BSmodMenuPool.AddSubMenu(this.methgarage, "Sell Business");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
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
                  float num5 = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
                  this.maxstocks = 10 * this.purchaselvl;
                  this.maxstocks = 10 * this.purchaselvl;
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
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
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
        double num7 = 1.75;
        if (this.purchaselvl < 25)
          num7 = 1.75;
        if (this.purchaselvl > 25 && index < 50)
          num7 = 2.25;
        if (this.purchaselvl > 50 && this.purchaselvl < 70)
          num7 = 3.5;
        if (this.purchaselvl > 75 && this.purchaselvl < 100)
          num7 = 4.75;
        double num8 = (double) this.BusinessUpgradeBasePrice * num7 * (double) this.purchaselvl;
        UI.Notify("Price for Next Level $" + num8.ToString("N"));
        num6 = this.purchaselvl + 1;
        UI.Notify("Next Level " + num6.ToString());
        UI.Notify("increaseGain : $" + ((float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75)).ToString());
        num8 = 0.85 * (double) this.purchaselvl + 0.0;
        UI.Notify("Profit Margin :" + num8.ToString() + "%");
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
        if (Hanger.\u003C\u003Eo__238.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__238.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, BlipColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (BlipColor), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Blip_Colour = Hanger.\u003C\u003Eo__238.\u003C\u003Ep__3.Target((CallSite) Hanger.\u003C\u003Eo__238.\u003C\u003Ep__3, BColour[BC.Index]);
        this.Config.SetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__238.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__238.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Uicolour = Hanger.\u003C\u003Eo__238.\u003C\u003Ep__4.Target((CallSite) Hanger.\u003C\u003Eo__238.\u003C\u003Ep__4, UiColour[uiC.Index]);
        this.Config.SetValue<string>("Misc", "Uicolour", this.Uicolour);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__238.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__238.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.MarkerColorString = Hanger.\u003C\u003Eo__238.\u003C\u003Ep__5.Target((CallSite) Hanger.\u003C\u003Eo__238.\u003C\u003Ep__5, MColour[MC.Index]);
        this.Config.SetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " : Settings Changed they will take effect when you reload the mod!");
      });
    }

    public void SetActiveTarget2(Vehicle Plane, Ped P)
    {
      Vector3 position = P.Position;
      Function.Call(Hash._0x23703CD154E83B88, (InputArgument) Plane.GetPedOnSeat(VehicleSeat.Driver).Handle, (InputArgument) Plane.Handle, (InputArgument) P, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 6, (InputArgument) 70.0, (InputArgument) -1.0, (InputArgument) 30.0, (InputArgument) 1000, (InputArgument) 150);
    }

    public void SetActiveTarget(Vehicle Plane, Ped P)
    {
      Vector3 position = P.Position;
      Function.Call(Hash._0x23703CD154E83B88, (InputArgument) Plane.GetPedOnSeat(VehicleSeat.Driver).Handle, (InputArgument) Plane.Handle, (InputArgument) P, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 6, (InputArgument) 25.0, (InputArgument) -1.0, (InputArgument) 60, (InputArgument) 1000, (InputArgument) 150);
    }

    public void PickNewTarget(Ped Pilot, int Enemys)
    {
      bool flag = false;
      for (int index = 0; index < Enemys; ++index)
      {
        if ((Entity) this.AIPlanes[index] != (Entity) null)
        {
          if (this.AIPlanes[index].IsAlive)
          {
            if (!Pilot.IsInCombatAgainst(this.AIPlanes[index].GetPedOnSeat(VehicleSeat.Driver)))
            {
              if (flag)
                break;
              UI.Notify("Getting New Target : Ai Plane " + index.ToString());
              Pilot.BlockPermanentEvents = true;
              Pilot.RelationshipGroup = Game.Player.Character.RelationshipGroup;
              Pilot.NeverLeavesGroup = true;
              Pilot.IsEnemy = false;
              this.SetActiveTarget2(this.Plane, this.AIPlanes[index].GetPedOnSeat(VehicleSeat.Driver));
              this.FightAgainst(this.AIPlanes[index].GetPedOnSeat(VehicleSeat.Driver), Pilot);
              this.CurrentTarget = this.AIPlanes[index].GetPedOnSeat(VehicleSeat.Driver);
              index += 50;
              break;
            }
            if (flag)
              break;
          }
          if (flag)
            break;
        }
        if (flag)
          break;
      }
    }

    public void FightAgainst(Ped Target, Ped Enemy)
    {
      Enemy.Task.ClearAll();
      Enemy.Task.FightAgainst(Target);
    }

    public void SetupDelivery()
    {
      UIMenu uiMenu = this.BSmodMenuPool2.AddSubMenu(this.DeliveyMission, "Delivery Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (Havok)");
      uiMenu.AddItem(Mission1);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Mission1)
          return;
        if ((Entity) this.Plane != (Entity) null)
          this.Plane.Delete();
        if (this.PlaneBlip != (Blip) null)
          this.PlaneBlip.Remove();
        if (this.LocationBlip != (Blip) null)
          this.LocationBlip.Remove();
        this.Spawn = new Vector3(-1057.46f, -3490.06f, 15f);
        System.Random random = new System.Random();
        if (random.Next(1, 200) < 10)
          this.MissionMarker = new Vector3(352.317f, -588.422f, 75f);
        if (random.Next(1, 200) > 10 && random.Next(1, 200) < 20)
          this.MissionMarker = new Vector3(1390.55f, -475.575f, 91f);
        if (random.Next(1, 200) > 20 && random.Next(1, 200) < 30)
          this.MissionMarker = new Vector3(-913.852f, -379.479f, 137f);
        if (random.Next(1, 200) > 30 && random.Next(1, 200) < 40)
          this.MissionMarker = new Vector3(-143.393f, -592.794f, 212f);
        if (random.Next(1, 200) > 40 && random.Next(1, 200) < 50)
          this.MissionMarker = new Vector3(-204.066f, -849.04f, 118.653f);
        if (random.Next(1, 200) > 50 && random.Next(1, 200) < 60)
          this.MissionMarker = new Vector3(-1580.98f, -569.994f, 117.653f);
        if (random.Next(1, 200) > 60 && random.Next(1, 200) < 70)
          this.MissionMarker = new Vector3(-606.385f, -1769.89f, 43f);
        if (random.Next(1, 200) > 70 && random.Next(1, 200) < 80)
          this.MissionMarker = new Vector3(300f, -1453.89f, 46f);
        if (random.Next(1, 200) > 80 && random.Next(1, 200) < 90)
          this.MissionMarker = new Vector3(343f, -1419.89f, 76f);
        if (random.Next(1, 200) > 90 && random.Next(1, 200) < 100)
          this.MissionMarker = new Vector3(18f, -922f, 124f);
        if (random.Next(1, 200) > 100 && random.Next(1, 200) < 110)
          this.MissionMarker = new Vector3(871.142f, -1928f, 96f);
        if (random.Next(1, 200) > 110 && random.Next(1, 200) < 120)
          this.MissionMarker = new Vector3(968f, 40f, 108f);
        if (random.Next(1, 200) > 120 && random.Next(1, 200) < 130)
          this.MissionMarker = new Vector3(-179.233f, -156.882f, 94f);
        if (random.Next(1, 200) > 130 && random.Next(1, 200) < 140)
          this.MissionMarker = new Vector3(-518.76f, 211f, 95f);
        if (random.Next(1, 200) > 140 && random.Next(1, 200) < 150)
          this.MissionMarker = new Vector3(-1738.36f, 157.402f, 65f);
        if (random.Next(1, 200) > 150 && random.Next(1, 200) < 160)
          this.MissionMarker = new Vector3(-2209.58f, 251.899f, 198.689f);
        if (random.Next(1, 200) > 160 && random.Next(1, 200) < 170)
          this.MissionMarker = new Vector3(1272.27f, 208f, 83f);
        if (random.Next(1, 200) > 170 && random.Next(1, 200) < 180)
          this.MissionMarker = new Vector3(-1014f, -1924f, 21f);
        if (random.Next(1, 200) > 180 && random.Next(1, 200) < 190)
          this.MissionMarker = new Vector3(-974.201f, -2970f, 54f);
        if (random.Next(1, 200) > 180 && random.Next(1, 200) < 190)
          this.MissionMarker = new Vector3(244f, -3185f, 42f);
        this.MissionMarker = random.Next(1, 200) <= 190 || random.Next(1, 200) >= 200 ? new Vector3(352.317f, -588.422f, 75f) : new Vector3(-974.201f, -2970f, 54f);
        this.shipmentsDElivered = 0;
        this.DeliveryMissionOn = true;
        this.Plane = World.CreateVehicle((Model) VehicleHash.Havok, this.Spawn);
        this.PlaneBlip = World.CreateBlip(this.Spawn);
        this.PlaneBlip.Sprite = BlipSprite.HelicopterAnimated;
        this.PlaneBlip.Color = BlipColor.Red;
        this.PlaneBlip.Name = "Havok";
        this.LocationBlip = World.CreateBlip(this.MissionMarker);
        this.LocationBlip.Sprite = BlipSprite.Briefcase2;
        this.LocationBlip.Color = BlipColor.White;
        this.LocationBlip.Name = "Delivery Point";
        UI.Notify(this.GetHostName() + " Boss we need someone to deliver a bunch of packages to location spread around LS, we have provided a havok, just go to each location, one by one to complete the mission");
      });
    }

    public void SmugglingCargo()
    {
      UIMenu uiMenu = this.BSmodMenuPool2.AddSubMenu(this.Smuggling, "Smuggling Cargo");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (Cuban 800)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 (Mogul)");
      uiMenu.AddItem(Mission2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission2)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.DropPoint != (Blip) null)
            this.DropPoint.Remove();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          Vector3 position = new Vector3(-979.49f, -3340.52f, 14f);
          this.Sam1 = World.CreateVehicle(this.RequestModel(VehicleHash.Mogul), position);
          this.Sam1.IsInvincible = true;
          this.Sam1.PlaceOnGround();
          this.DropPoint = World.CreateBlip(new Vector3(1678.99f, 3238.1f, 41f));
          this.DropPoint.Sprite = BlipSprite.SpecialCargo;
          this.DropPoint.Name = "Drop Point";
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.Plane;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Retrieve Aircraft";
          this.missionnum = 3;
          this.MissionSetup = true;
          this.Notify = true;
        }
        if (item != Mission1)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if (this.DropPoint != (Blip) null)
          this.DropPoint.Remove();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        this.Sam2Loc = new Vector3(1109.75f, 3053f, 41f);
        this.Sam3Loc = new Vector3(1159.96f, 3068.22f, 41f);
        this.Sam2 = World.CreateVehicle(this.RequestModel(VehicleHash.TrailerSmall2), this.Sam2Loc);
        this.Sam3 = World.CreateVehicle(this.RequestModel(VehicleHash.TrailerSmall2), this.Sam3Loc);
        this.Sam2.SetMod(VehicleMod.Roof, 0, true);
        this.Sam3.SetMod(VehicleMod.Roof, 0, true);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        Vector3 position1 = new Vector3(-979.49f, -3340.52f, 14f);
        this.Sam1 = World.CreateVehicle(this.RequestModel(VehicleHash.Cuban800), position1);
        this.Sam1.IsInvincible = true;
        this.Sam1.PlaceOnGround();
        this.DropPoint = World.CreateBlip(new Vector3(1678.99f, 3238.1f, 41f));
        this.DropPoint.Sprite = BlipSprite.SpecialCargo;
        this.DropPoint.Name = "Drop Point";
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.Plane;
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "Retrieve Aircraft";
        this.missionnum = 3;
        this.MissionSetup = true;
        this.Notify = true;
      });
    }

    public void AirAssaultFun()
    {
      UIMenu uiMenu = this.BSmodMenuPool2.AddSubMenu(this.AirAssault, "Air Assault");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (Havok)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 1 (Hunter)");
      uiMenu.AddItem(Mission2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission2)
        {
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
          this.Sam1Loc = new Vector3(1417.52f, 3018.44f, 41f);
          this.Sam2Loc = new Vector3(1256.96f, 3118.28f, 42f);
          this.Sam3Loc = new Vector3(1072f, 3065.77f, 42f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Hunter, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Hunter, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Hunter, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 9), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 9), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 9), true);
          this.Sam1.SetMod(VehicleMod.Roof, 0, true);
          this.Sam2.SetMod(VehicleMod.Roof, 0, true);
          this.Sam3.SetMod(VehicleMod.Roof, 0, true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.HelicopterAnimated;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Vehicle A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          this.Sam2blip.Sprite = BlipSprite.HelicopterAnimated;
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "Vehicle B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          this.Sam3blip.Sprite = BlipSprite.HelicopterAnimated;
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "Vehicle C";
          this.missionnum = 2;
          this.MissionSetup = true;
        }
        if (item != Mission1)
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
        this.Sam1Loc = new Vector3(1417.52f, 3018.44f, 41f);
        this.Sam2Loc = new Vector3(1256.96f, 3118.28f, 42f);
        this.Sam3Loc = new Vector3(1072f, 3065.77f, 42f);
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.Havok, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.Havok, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.Havok, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        System.Random random1 = new System.Random();
        this.Sam1.SetMod(VehicleMod.Livery, random1.Next(1, 9), true);
        this.Sam2.SetMod(VehicleMod.Livery, random1.Next(1, 9), true);
        this.Sam3.SetMod(VehicleMod.Livery, random1.Next(1, 9), true);
        this.Sam1.SetMod(VehicleMod.Roof, 0, true);
        this.Sam2.SetMod(VehicleMod.Roof, 0, true);
        this.Sam3.SetMod(VehicleMod.Roof, 0, true);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.HelicopterAnimated;
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "Vehicle A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        this.Sam2blip.Sprite = BlipSprite.HelicopterAnimated;
        this.Sam2blip.Color = BlipColor.Red;
        this.Sam2blip.Name = "Vehicle B";
        this.Sam3blip = World.CreateBlip(this.Sam3.Position);
        this.Sam3blip.Sprite = BlipSprite.HelicopterAnimated;
        this.Sam3blip.Color = BlipColor.Red;
        this.Sam3blip.Name = "Vehicle C";
        this.missionnum = 2;
        this.MissionSetup = true;
      });
    }

    public void SetupElimination()
    {
      UIMenu uiMenu = this.BSmodMenuPool2.AddSubMenu(this.MovingAA, "Moving Convoy");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (HalfTrack)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 (Technical Custom)");
      uiMenu.AddItem(Mission2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission2)
        {
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
          this.Sam1Loc = new Vector3(1541.6f, 860.917f, 78f);
          this.Sam2Loc = new Vector3(1539.24f, 853f, 78f);
          this.Sam3Loc = new Vector3(1522.11f, 820f, 78f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Technical3, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Technical3, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Technical3, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.PointB, 20f, 160f);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.PointB, 20f, 160f);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.PointB, 20f, 160f);
          this.Sam1.SetMod(VehicleMod.Roof, 0, true);
          this.Sam1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmLieut01GMM);
          this.Sam1.GetPedOnSeat(VehicleSeat.LeftRear).Task.VehicleShootAtPed(Game.Player.Character);
          this.Sam2.SetMod(VehicleMod.Roof, 0, true);
          this.Sam2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmLieut01GMM);
          this.Sam2.GetPedOnSeat(VehicleSeat.LeftRear).Task.VehicleShootAtPed(Game.Player.Character);
          this.Sam3.SetMod(VehicleMod.Roof, 0, true);
          this.Sam3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmLieut01GMM);
          this.Sam3.GetPedOnSeat(VehicleSeat.LeftRear).Task.VehicleShootAtPed(Game.Player.Character);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.GunCar;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Vehicle A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          this.Sam2blip.Sprite = BlipSprite.GunCar;
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "Vehicle B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          this.Sam3blip.Sprite = BlipSprite.GunCar;
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "Vehicle C";
          this.missionnum = 1;
          this.MissionSetup = true;
        }
        if (item != Mission1)
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
        this.Sam1Loc = new Vector3(1541.6f, 860.917f, 78f);
        this.Sam2Loc = new Vector3(1539.24f, 853f, 78f);
        this.Sam3Loc = new Vector3(1522.11f, 820f, 78f);
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.PointB, 20f, 160f);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.PointB, 20f, 160f);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.PointB, 20f, 160f);
        this.Sam1.SetMod(VehicleMod.Roof, 0, true);
        this.Sam1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmLieut01GMM);
        this.Sam1.GetPedOnSeat(VehicleSeat.LeftRear).Task.VehicleShootAtPed(Game.Player.Character);
        this.Sam2.SetMod(VehicleMod.Roof, 0, true);
        this.Sam2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmLieut01GMM);
        this.Sam2.GetPedOnSeat(VehicleSeat.LeftRear).Task.VehicleShootAtPed(Game.Player.Character);
        this.Sam3.SetMod(VehicleMod.Roof, 0, true);
        this.Sam3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmLieut01GMM);
        this.Sam3.GetPedOnSeat(VehicleSeat.LeftRear).Task.VehicleShootAtPed(Game.Player.Character);
        System.Random random1 = new System.Random();
        this.Sam1.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam2.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam3.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.GunCar;
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "Vehicle A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        this.Sam2blip.Sprite = BlipSprite.GunCar;
        this.Sam2blip.Color = BlipColor.Red;
        this.Sam2blip.Name = "Vehicle B";
        this.Sam3blip = World.CreateBlip(this.Sam3.Position);
        this.Sam3blip.Sprite = BlipSprite.GunCar;
        this.Sam3blip.Color = BlipColor.Red;
        this.Sam3blip.Name = "Vehicle C";
        this.missionnum = 1;
        this.MissionSetup = true;
      });
    }

    public void SetupSourcingCivilian()
    {
      UIMenu uiMenu = this.BSmodMenuPool.AddSubMenu(this.BSGarageMenu2, "Aircraft");
      this.GUIMenus.Add(uiMenu);
      List<object> listofvehicles2 = new List<object>();
      listofvehicles2.Add((object) VehicleHash.Cuban800);
      listofvehicles2.Add((object) VehicleHash.Mammatus);
      listofvehicles2.Add((object) VehicleHash.Seabreeze);
      listofvehicles2.Add((object) VehicleHash.Howard);
      listofvehicles2.Add((object) VehicleHash.Vestra);
      UIMenuListItem list = new UIMenuListItem("Vehicle: ", listofvehicles2, 0);
      uiMenu.AddItem((UIMenuItem) list);
      UIMenuItem getvehicle2 = new UIMenuItem("Source Vehicle");
      uiMenu.AddItem(getvehicle2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != getvehicle2)
          return;
        if ((Entity) this.Plane != (Entity) null)
          this.Plane.Delete();
        if (this.PlaneBlip != (Blip) null)
          this.PlaneBlip.Remove();
        int index1 = list.Index;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__247.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__247.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        VehicleHash vehicleHash = Hanger.\u003C\u003Eo__247.\u003C\u003Ep__0.Target((CallSite) Hanger.\u003C\u003Eo__247.\u003C\u003Ep__0, listofvehicles2[list.Index]);
        Vector3 position = new Vector3(1558.32f, 3205.76f, 41f);
        this.Plane = World.CreateVehicle((Model) vehicleHash, position, 90f);
        this.Plane.PlaceOnGround();
        this.PlaneBlip = World.CreateBlip(position);
        this.PlaneBlip.Color = BlipColor.Red;
        this.PlaneBlip.Sprite = BlipSprite.Plane;
        this.PlaneBlip.Name = "Retreive Air Vehicle";
        UI.Notify(this.GetHostName() + " ok the vehicle has been located at Trevor Phillip's Airfield ");
      });
    }

    public void SetupSourcingMilitary()
    {
      UIMenu uiMenu = this.BSmodMenuPool.AddSubMenu(this.BSGarageMenu, "Aircraft");
      this.GUIMenus.Add(uiMenu);
      List<object> listofvehicles2 = new List<object>();
      listofvehicles2.Add((object) VehicleHash.Bombushka);
      listofvehicles2.Add((object) VehicleHash.Pyro);
      listofvehicles2.Add((object) VehicleHash.Molotok);
      listofvehicles2.Add((object) VehicleHash.Buzzard2);
      listofvehicles2.Add((object) VehicleHash.Starling);
      listofvehicles2.Add((object) VehicleHash.Tula);
      listofvehicles2.Add((object) VehicleHash.Havok);
      listofvehicles2.Add((object) VehicleHash.Rogue);
      listofvehicles2.Add((object) VehicleHash.Hunter);
      listofvehicles2.Add((object) VehicleHash.Mogul);
      listofvehicles2.Add((object) VehicleHash.Nokota);
      listofvehicles2.Add((object) VehicleHash.Volatol);
      listofvehicles2.Add((object) VehicleHash.Akula);
      listofvehicles2.Add((object) VehicleHash.Lazer);
      listofvehicles2.Add((object) VehicleHash.Valkyrie);
      listofvehicles2.Add((object) VehicleHash.Savage);
      listofvehicles2.Add((object) VehicleHash.Hydra);
      UIMenuListItem list2 = new UIMenuListItem("Vehicle: ", listofvehicles2, 0);
      uiMenu.AddItem((UIMenuItem) list2);
      UIMenuItem getvehicle2 = new UIMenuItem("Source Vehicle");
      uiMenu.AddItem(getvehicle2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != getvehicle2)
          return;
        if ((Entity) this.Plane != (Entity) null)
          this.Plane.Delete();
        if (this.PlaneBlip != (Blip) null)
          this.PlaneBlip.Remove();
        int index1 = list2.Index;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__248.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__248.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, VehicleHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleHash), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        VehicleHash vehicleHash = Hanger.\u003C\u003Eo__248.\u003C\u003Ep__0.Target((CallSite) Hanger.\u003C\u003Eo__248.\u003C\u003Ep__0, listofvehicles2[list2.Index]);
        Vector3 position = new Vector3(-2049.89f, 2882.5f, 33f);
        this.Plane = World.CreateVehicle((Model) vehicleHash, position, 90f);
        this.Plane.PlaceOnGround();
        this.PlaneBlip = World.CreateBlip(position);
        this.PlaneBlip.Color = BlipColor.Red;
        this.PlaneBlip.Sprite = BlipSprite.Plane;
        this.PlaneBlip.Name = "Retreive Air Vehicle";
        UI.Notify(this.GetHostName() + " ok the vehicle has been located at Fort Zancudo ");
      });
    }

    public void SetupCustomisation()
    {
      UIMenu uiMenu = this.BSmodMenuPool.AddSubMenu(this.Extra, "Extra Additions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem GunLocker = new UIMenuItem("Gun Locker : $1,000,000");
      uiMenu.AddItem(GunLocker);
      UIMenuItem UAIFZ2 = new UIMenuItem("Unresticted Fort Zancudo : $3,000,000");
      uiMenu.AddItem(UAIFZ2);
      UAIFZ2.Description = "No Wanted Level on Entering Fort Zancudo, (already Enabled if Hanger is in Fort Zancudo)";
      UIMenuItem UAIFZ = new UIMenuItem("Unresticted Fort Zancudo VIP : $8,000,000");
      uiMenu.AddItem(UAIFZ);
      UAIFZ.Description = "No Wanted Level on Shooting Peds/Stealing Vehicles in Fort Zancudo";
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == UAIFZ2)
        {
          if (this.BusinessLocation != 2 && this.BusinessLocation != 3 && this.BusinessLocation != 4)
          {
            if (this.Config.GetValue<int>("Setup", "UnrestictedAccessInFortZancudo", this.UnrestictedAccessInFortZancudo) == 0)
            {
              if (Game.Player.Money >= 3000000)
              {
                Game.Player.Money -= 3000000;
                this.UnrestictedAccessInFortZancudo = 1;
                this.Config.SetValue<int>("Setup", "UnrestictedAccessInFortZancudo", this.UnrestictedAccessInFortZancudo);
                this.Config.Save();
              }
              else
                UI.Notify(this.GetHostName() + " You Dont Have Enought Money For a gun locker");
            }
            else
              UI.Notify(this.GetHostName() + " Sorry boss you have allready bought this upgrade");
          }
          else
            UI.Notify(this.GetHostName() + " Due to the fact that you own a Hanger already in Fort Zancudo, this Upgrade is not needed");
        }
        if (item == UAIFZ)
        {
          if (this.Config.GetValue<int>("Setup", "UnrestictedAccessInFortZancudoVIP", this.UnrestictedAccessInFortZancudoVIP) == 0)
          {
            if (Game.Player.Money >= 8000000)
            {
              Game.Player.Money -= 8000000;
              this.UnrestictedAccessInFortZancudo = 1;
              this.Config.SetValue<int>("Setup", "UnrestictedAccessInFortZancudoVIP", this.UnrestictedAccessInFortZancudoVIP);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " You Dont Have Enought Money For a gun locker");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you have allready bought this upgrade");
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

    public void setupMarker()
    {
      this.Range = World.CreateBlip(this.MoneyStorageMarker);
      this.Range.Sprite = BlipSprite.DollarSign;
      this.Range.Color = this.Blip_Colour;
      this.Range.Name = "Smuggler's Run Money Vault";
      this.Range.IsShortRange = true;
    }

    public void DeleteMarker()
    {
      if (!(this.Range != (Blip) null))
        return;
      this.Range.Remove();
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
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
        this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + this.currentbank.ToString() + "]", this.MoneyStored);
        UI.Notify(this.GetHostName() + " Moeny in Vault ~b~" + this.currentbank.ToString() + "~w~, ~g~$" + this.MoneyStored.ToString("N"));
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

    public void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Smuggler's Run Business", "SmugglersRunBusinessMain", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: 3 Config.ini Failed To Load.");
      }
    }

    public Hanger()
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
      this.LoadIniFileCustomizeHanger("scripts//HKH191sBusinessMods//Smuggler's Run Business//HangerDesign.ini");
      this.SC = new SaveCar();
      this.CreateBanner();
      this.Setup();
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Interval = 1;
      if (this.BusinessLocation == 0)
      {
        this.Entry = new Vector3(-1146.24f, -3409.77f, 13f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.BusinessLocation == 1)
      {
        this.Entry = new Vector3(-1418f, -3252f, 13f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.BusinessLocation == 2)
      {
        this.Entry = new Vector3(-2021f, 3158f, 31.5f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.BusinessLocation == 3)
      {
        this.Entry = new Vector3(-2472f, 3266f, 31.5f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      if (this.BusinessLocation == 4)
      {
        this.Entry = new Vector3(-1923f, 3129f, 31.5f);
        this.EntryMarker = new Vector3(-139.402f, -627.819f, 167f);
        this.ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
      }
      this.GunLockerMarker = new Vector3(-1298.7f, -3016.9f, -50.5f);
      if (this.Hanger1 != (Blip) null)
        this.Hanger1.Remove();
      this.Hanger1 = World.CreateBlip(this.Entry);
      if (this.purchaselvl >= 1)
      {
        this.Hanger1.Sprite = BlipSprite.GTAOHangar;
        this.Hanger1.Color = this.Blip_Colour;
        this.Hanger1.Name = "Smuggler's Run Business";
        this.Hanger1.IsShortRange = true;
        this.Hanger1.Alpha = (int) byte.MaxValue;
      }
      else
      {
        this.Hanger1.Sprite = BlipSprite.GTAOHangar;
        this.Hanger1.Color = BlipColor.White;
        this.Hanger1.Name = "Hanger for Sale";
        this.Hanger1.IsShortRange = true;
        this.Hanger1.Alpha = 0;
      }
    }

    private void LoadIniFileCustomizeHanger(string iniName)
    {
      try
      {
        this.ConfigCustomizeHanger = ScriptSettings.Load(iniName);
        this.HangarLighting = this.ConfigCustomizeHanger.GetValue<string>("Setup", "HangarLighting", this.HangarLighting);
        this.HangarFloor = this.ConfigCustomizeHanger.GetValue<string>("Setup", "HangarFloor", this.HangarFloor);
        this.HangarFloorDecal = this.ConfigCustomizeHanger.GetValue<string>("Setup", "HangarFloorDecal", this.HangarFloorDecal);
        this.HangarBedroom = this.ConfigCustomizeHanger.GetValue<string>("Setup", "HangarBedroom", this.HangarBedroom);
        this.HangarOffice = this.ConfigCustomizeHanger.GetValue<string>("Setup", "HangarOffice", this.HangarOffice);
        this.HangarBedroomBlinds = this.ConfigCustomizeHanger.GetValue<string>("Setup", "HangarBedroomBlinds", this.HangarBedroomBlinds);
        this.HangarLightingWallTint = this.ConfigCustomizeHanger.GetValue<string>("Setup", "HangarLightingWallTint", this.HangarLightingWallTint);
        this.HangarFloorDecalColor = this.ConfigCustomizeHanger.GetValue<int>("Setup", "HangarFloorDecalColor", this.HangarFloorDecalColor);
        this.HangarShellColor = this.ConfigCustomizeHanger.GetValue<int>("Setup", "HangarShellColor", this.HangarShellColor);
        this.HangarBedroomColor = this.ConfigCustomizeHanger.GetValue<int>("Setup", "HangarBedroomColor", this.HangarBedroomColor);
        this.HangarCraneColor = this.ConfigCustomizeHanger.GetValue<int>("Setup", "HangarCraneColor", this.HangarCraneColor);
        this.HangarWorkshopColor = this.ConfigCustomizeHanger.GetValue<int>("Setup", "HangarWorkshopColor", this.HangarWorkshopColor);
        this.HangarLightingTintPropsColor = this.ConfigCustomizeHanger.GetValue<int>("Setup", "HangarLightingTintPropsColor", this.HangarLightingTintPropsColor);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
        this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
        this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.UseOldMarker = this.Config.GetValue<bool>("Setup", "UseOldMarker", this.UseOldMarker);
        this.UnrestictedAccessInFortZancudo = this.Config.GetValue<int>("Setup", "UnrestictedAccessInFortZancudo", this.UnrestictedAccessInFortZancudo);
        this.UnrestictedAccessInFortZancudoVIP = this.Config.GetValue<int>("Setup", "UnrestictedAccessInFortZancudoVIP", this.UnrestictedAccessInFortZancudoVIP);
        this.GunlockerBought = this.Config.GetValue<int>("Extra", "GunLockerBought", this.GunlockerBought);
        this.VehicleBayBought = this.Config.GetValue<int>("Extra", "VehicleBayBought", this.VehicleBayBought);
        this.CycloneBought = this.Config.GetValue<int>("EXTRACARS", "CycloneBought", this.CycloneBought);
        this.RapidGTBought = this.Config.GetValue<int>("EXTRACARS", "RapidGTBought", this.RapidGTBought);
        this.RetinueBought = this.Config.GetValue<int>("EXTRACARS", "RetinueBought", this.RetinueBought);
        this.VisioneBought = this.Config.GetValue<int>("EXTRACARS", "VisioneBought", this.RetinueBought);
        this.SMG_StealsCompleted = this.Config.GetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
        this.SMG_StealsFailed = this.Config.GetValue<int>("FreeTradeShipping", "StealsFailed", this.SMG_StealsFailed);
        this.SMG_SalesCompleted = this.Config.GetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
        this.SMG_SalesFailed = this.Config.GetValue<int>("FreeTradeShipping", "SalesFailed", this.SMG_SalesFailed);
        this.SMG_MaxCratesPerCargo = this.Config.GetValue<int>("FreeTradeShipping", "MaxCratesPerCargo", this.SMG_MaxCratesPerCargo);
        this.SMG_Narcotics_CurrentStock = this.Config.GetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
        this.SMG_Narcotics_StockMax = this.SMG_MaxCratesPerCargo;
        this.SMG_Chemicals_CurrentStock = this.Config.GetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
        this.SMG_Chemicals_StockMax = this.SMG_MaxCratesPerCargo;
        this.SMG_MedicalSupplies_CurrentStock = this.Config.GetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
        this.SMG_MedicalSupplies_StockMax = this.SMG_MaxCratesPerCargo;
        this.SMG_AnimalMaterials_CurrentStock = this.Config.GetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
        this.SMG_AnimalMaterials_StockMax = this.SMG_MaxCratesPerCargo;
        this.SMG_ArtaAntiques_CurrentStock = this.Config.GetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
        this.SMG_ArtaAntiques_StockMax = this.SMG_MaxCratesPerCargo;
        this.SMG_JewelryaGemstones_CurrentStock = this.Config.GetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
        this.SMG_JewelryaGemstones_StockMax = this.SMG_MaxCratesPerCargo;
        this.SMG_TabaccoaAlcohol_CurrentStock = this.Config.GetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
        this.SMG_TabaccoaAlcohol_StockMax = this.SMG_MaxCratesPerCargo;
        this.SMG_CounterfeitGoods_CurrentStock = this.Config.GetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
        this.SMG_CounterfeitGoods_StockMax = this.SMG_MaxCratesPerCargo;
        this.SMG_RivalCratesStolen = this.Config.GetValue<int>("FreeTradeShipping", "RivalCratesStolen", this.SMG_RivalCratesStolen);
        this.SMG_Earnings = this.Config.GetValue<int>("FreeTradeShipping", "Earnings", this.SMG_Earnings);
        this.SMG_SellMultiplier = this.Config.GetValue<float>("FreeTradeShipping", "SellMultiplier", this.SMG_SellMultiplier);
        this.ChairPropModel = this.Config.GetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
        this.maxstocks = 10 * this.purchaselvl;
        float num = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
        this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
        this.increaseGain = num;
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: 1 Config.ini Failed To Load.");
      }
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
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

    private void Setup()
    {
      this.modMenuPool = new MenuPool();
      this.CarMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Smuggler's Run", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.GarageMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Garage Options");
      this.GUIMenus.Add(this.GarageMenu);
      this.modMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Remove a Vehicle", "Select an Option");
      this.GUIMenus.Add(this.mainMenu2);
      this.modMenuPool2.Add(this.mainMenu2);
      this.CarMenu = new UIMenu("Buy A SR Car", "Select an Option");
      this.GUIMenus.Add(this.CarMenu);
      this.CarMenuPool.Add(this.CarMenu);
      this.BuyCar = this.CarMenuPool.AddSubMenu(this.CarMenu, "Buy a Car");
      this.GUIMenus.Add(this.BuyCar);
      this.RemoveMenu = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Remove/Add a Vehicle");
      this.GUIMenus.Add(this.RemoveMenu);
      this.SetupGarage();
      this.RemoveCar();
      this.BuyACar();
      this.CHmodMenuPool = new MenuPool();
      this.CHmainMenu = new UIMenu("Customize Interior", "Select an Option");
      this.GUIMenus.Add(this.CHmainMenu);
      this.CHmodMenuPool.Add(this.CHmainMenu);
      this.FloorMenu = this.CHmodMenuPool.AddSubMenu(this.CHmainMenu, "Hanger Customization");
      this.GUIMenus.Add(this.FloorMenu);
      this.ChangeColor();
      this.LoadIniFileCustomizeHanger("scripts//HKH191sBusinessMods//Smuggler's Run Business//HangerDesign.ini");
      this.BSmodMenuPool = new MenuPool();
      this.BSmainMenu = new UIMenu("Smuggler's Run", "Select an Option");
      this.GUIMenus.Add(this.BSmainMenu);
      this.BSmodMenuPool.Add(this.BSmainMenu);
      this.BSmodMenuPool2 = new MenuPool();
      this.BSmainMenu2 = new UIMenu("Source A Vehicle", "Select an Option");
      this.GUIMenus.Add(this.BSmainMenu2);
      this.BSmodMenuPool2.Add(this.BSmainMenu2);
      this.BSGarageMenu = this.BSmodMenuPool2.AddSubMenu(this.BSmainMenu2, "Source Military");
      this.GUIMenus.Add(this.BSGarageMenu);
      this.BSGarageMenu2 = this.BSmodMenuPool2.AddSubMenu(this.BSmainMenu2, "Source Civilian");
      this.GUIMenus.Add(this.BSGarageMenu2);
      UIMenuItem OpenGUI = new UIMenuItem("          Open Free Trade Shipping Co           ");
      this.BSmainMenu.AddItem(OpenGUI);
      this.BSmainMenu.AddItem(new UIMenuItem("                                              "));
      this.BSmainMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
        this.HangerCargoCrateGUION = true;
        this.GUIOn = true;
        UI.Notify("Open GUI");
      });
      this.methgarage = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Purchase Options");
      this.GUIMenus.Add(this.methgarage);
      this.ProductStock = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Product Options");
      this.GUIMenus.Add(this.ProductStock);
      this.Extra = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Extra");
      this.GUIMenus.Add(this.Extra);
      this.DeliveyMission = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Shipment Delivery (Missions)");
      this.GUIMenus.Add(this.DeliveyMission);
      this.MovingAA = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Moving Convoy (Missions)");
      this.GUIMenus.Add(this.MovingAA);
      this.Smuggling = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Smuggling Cargo (Missions)");
      this.GUIMenus.Add(this.Smuggling);
      this.Specialmissions = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Special Missions (Missions)");
      this.GUIMenus.Add(this.Specialmissions);
      this.AiralCheckpointRace = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Check Point Race (Missions)");
      this.GUIMenus.Add(this.AiralCheckpointRace);
      this.AirAssault = this.BSmodMenuPool.AddSubMenu(this.BSmainMenu, "Air Assault (Missions)");
      this.GUIMenus.Add(this.AirAssault);
      this.SetupCustomizations();
      this.SetupProduct();
      this.Setupbuisness();
      this.SetupCustomisation();
      this.SetupSourcingMilitary();
      this.SetupSourcingCivilian();
      this.SetupElimination();
      this.AirAssaultFun();
      this.SmugglingCargo();
      this.SetupDelivery();
      this.SetupSpecialMissions();
      this.CheckpointRace();
      this.SetupPropSpawns();
      this.CrateProps();
      this.GunLockerMarker = new Vector3(-1298.7f, -3016.9f, -50.5f);
      this.DropPoint2.Add(new Vector3(966f, -126f, 74f));
      this.DropPoint2.Add(new Vector3(200f, 383f, 107f));
      this.DropPoint2.Add(new Vector3(-606f, 338f, 84f));
      this.DropPoint2.Add(new Vector3(-606f, 338f, 84f));
      this.DropPoint2.Add(new Vector3(-1539f, -76f, 53f));
      this.DropPoint2.Add(new Vector3(-2077f, -313f, 12f));
      this.DropPoint2.Add(new Vector3(-1451f, -364f, 43f));
      this.DropPoint2.Add(new Vector3(-587f, -1112f, 22f));
      this.DropPoint2.Add(new Vector3(102.6f, 6634.6f, 30f));
      this.DropPoint2.Add(new Vector3(-172.8f, 6452.8f, 29f));
      this.DropPoint2.Add(new Vector3(-265.1f, 6335.5f, 30f));
      this.DropPoint2.Add(new Vector3(-697.3f, 5772.9f, 15f));
      this.DropPoint2.Add(new Vector3(-575.2f, 5335.6f, 68f));
      this.DropPoint2.Add(new Vector3(35.9f, 6284.5f, 29f));
      this.DropPoint2.Add(new Vector3(1724f, 6399.4f, 31f));
      this.DropPoint2.Add(new Vector3(2467.7f, 4961.9f, 43f));
      this.DropPoint2.Add(new Vector3(2104.9f, 4767.5f, 39f));
      this.DropPoint2.Add(new Vector3(1501.6f, 3763.7f, 31f));
      this.DropPoint2.Add(new Vector3(1374.5f, 3602.9f, 33f));
      this.DropPoint2.Add(new Vector3(1689.4f, 3310.9f, 39f));
      this.DropPoint2.Add(new Vector3(1989f, 3032f, 46f));
      this.DropPoint2.Add(new Vector3(2320.1f, 2499.5f, 45f));
      this.DropPoint2.Add(new Vector3(2365.2f, 2644.9f, 45f));
      this.DropPoint2.Add(new Vector3(2411.1f, 3058.2f, 46f));
      this.DropPoint2.Add(new Vector3(2812.8f, 1589.4f, 22f));
      this.DropPoint2.Add(new Vector3(-1567.1f, 2770.7f, 15f));
      this.DropPoint2.Add(new Vector3(-1911.4f, 2061f, 138f));
      this.DropPoint2.Add(new Vector3(-310.8f, 2739.6f, 65f));
      this.DropPoint2.Add(new Vector3(-288.5f, 2568.7f, 70f));
      this.DropPoint2.Add(new Vector3(-85.6f, 2805.1f, 51f));
      this.DropPoint2.Add(new Vector3(42.2f, 2786f, 56f));
      this.DropPoint2.Add(new Vector3(216.7f, 2462.3f, 54f));
      this.GLmodMenuPool = new MenuPool();
      this.GLmainMenu = new UIMenu("Gunlocker", "Select an Option");
      this.GUIMenus.Add(this.GLmainMenu);
      this.GLmodMenuPool.Add(this.GLmainMenu);
      this.weaponsMenu = this.GLmodMenuPool.AddSubMenu(this.GLmainMenu, "Weapons");
      this.GUIMenus.Add(this.weaponsMenu);
      this.SetupWeapons();
      this.currentbank = 1;
      this.MVmodMenuPool = new MenuPool();
      this.MVmainMenu = new UIMenu("Smuggler's Run", "Select an Option");
      this.GUIMenus.Add(this.MVmainMenu);
      this.MVmodMenuPool.Add(this.MVmainMenu);
      this.MoneyMenu = this.MVmodMenuPool.AddSubMenu(this.MVmainMenu, "Money Options");
      this.GUIMenus.Add(this.MoneyMenu);
      this.SetupMoneyMenu();
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void CheckpointRace()
    {
      UIMenu uiMenu = this.BSmodMenuPool2.AddSubMenu(this.AiralCheckpointRace, "Checkpoint Race ");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Air Race 1 (Recommend : Heli, Medium)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Air Race 2 (Recommend : Plane, Medium)");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Air Race 3 (Recommend: Plane, Medium)");
      uiMenu.AddItem(Mission3);
      UIMenuItem Mission4 = new UIMenuItem("Air Race 4 (Recommend: Heli, Medium)");
      uiMenu.AddItem(Mission4);
      UIMenuItem Mission5 = new UIMenuItem("Air Race 5 (Recommend: Heli, Medium)");
      uiMenu.AddItem(Mission5);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission1)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          this.Sam1blip = World.CreateBlip(new Vector3(752f, -17f, 65f));
          this.Sam1blip.Sprite = BlipSprite.TransformRace;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Start Point";
          this.NextCheckPoint = new Vector3(752f, -17f, 65f);
          this.checkpointReaced = 1;
          this.maxCheckpoints = 8;
          this.Race = 1;
          this.missionnum = 7;
          this.CurrentPoint = 0;
          this.CheckPoints = new Vector3[8];
          this.Rotation = new float[8];
          this.CheckPoints[0] = new Vector3(755f, -12f, 70f);
          this.Rotation[0] = 140f;
          this.CheckPoints[1] = new Vector3(703f, -120f, 84f);
          this.Rotation[1] = 140f;
          this.CheckPoints[2] = new Vector3(571f, -264f, 84f);
          this.Rotation[2] = 124f;
          this.CheckPoints[3] = new Vector3(292f, -554f, 84f);
          this.Rotation[3] = 135f;
          this.CheckPoints[4] = new Vector3(163f, -674f, 121f);
          this.Rotation[4] = 109f;
          this.CheckPoints[5] = new Vector3(76f, -830f, 105f);
          this.Rotation[5] = 159f;
          this.CheckPoints[6] = new Vector3(40f, -1008f, 73f);
          this.Rotation[6] = 151f;
          this.CheckPoints[7] = new Vector3(-26f, -1351f, 66f);
          this.Rotation[7] = 165f;
          this.MaxTimer = 80;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " see if you can beat this race!, be careful its dangerous");
        }
        if (item == Mission2)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          this.Sam1blip = World.CreateBlip(new Vector3(-1205f, -1915f, 21f));
          this.Sam1blip.Sprite = BlipSprite.TransformRace;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Start Point";
          this.NextCheckPoint = new Vector3(-1205f, -1915f, 21f);
          this.checkpointReaced = 1;
          this.maxCheckpoints = 9;
          this.Race = 1;
          this.missionnum = 7;
          this.CurrentPoint = 0;
          this.CheckPoints = new Vector3[9];
          this.Rotation = new float[9];
          this.CheckPoints[0] = new Vector3(-1205f, -1915f, 21f);
          this.Rotation[0] = -48f;
          this.CheckPoints[1] = new Vector3(-906f, -1679f, 22f);
          this.Rotation[1] = -53f;
          this.CheckPoints[2] = new Vector3(-666f, -1518f, 39f);
          this.Rotation[2] = -81f;
          this.CheckPoints[3] = new Vector3(-446f, -1591f, 15f);
          this.Rotation[3] = -130f;
          this.CheckPoints[4] = new Vector3(-371f, -1665f, 9f);
          this.Rotation[4] = -141f;
          this.CheckPoints[5] = new Vector3(-208f, -1800f, 10f);
          this.Rotation[5] = -130f;
          this.CheckPoints[6] = new Vector3(52f, -2036f, 6f);
          this.Rotation[6] = -169f;
          this.CheckPoints[7] = new Vector3(62f, -2118f, 6f);
          this.Rotation[7] = 165f;
          this.CheckPoints[8] = new Vector3(-13f, -2573f, 53f);
          this.Rotation[8] = 165f;
          this.MaxTimer = 45;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " see if you can beat this race!, be careful its dangerous");
        }
        if (item == Mission3)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          this.Sam1blip = World.CreateBlip(new Vector3(-619f, -2844f, 37f));
          this.Sam1blip.Sprite = BlipSprite.TransformRace;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Start Point";
          this.NextCheckPoint = new Vector3(-619f, -2844f, 37f);
          this.checkpointReaced = 1;
          this.maxCheckpoints = 9;
          this.Race = 1;
          this.missionnum = 7;
          this.CurrentPoint = 0;
          this.CheckPoints = new Vector3[9];
          this.Rotation = new float[9];
          this.CheckPoints[0] = new Vector3(-619f, -2844f, 37f);
          this.Rotation[0] = -23f;
          this.CheckPoints[1] = new Vector3(-343f, -2387f, 46f);
          this.Rotation[1] = -23f;
          this.CheckPoints[2] = new Vector3(209f, -2318f, 32f);
          this.Rotation[2] = -91f;
          this.CheckPoints[3] = new Vector3(339f, -2317f, 57f);
          this.Rotation[3] = -130f;
          this.CheckPoints[4] = new Vector3(503f, -2407f, 69f);
          this.Rotation[4] = -137f;
          this.CheckPoints[5] = new Vector3(730f, -2605f, 8f);
          this.Rotation[5] = -101f;
          this.CheckPoints[6] = new Vector3(994f, -2713f, 30f);
          this.Rotation[6] = -118f;
          this.CheckPoints[7] = new Vector3(1099f, -2914f, 17f);
          this.Rotation[7] = -178f;
          this.CheckPoints[8] = new Vector3(1114f, -3060f, 35f);
          this.Rotation[8] = -178f;
          this.MaxTimer = 65;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " see if you can beat this race!, be careful its dangerous");
        }
        if (item == Mission4)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          this.Sam1blip = World.CreateBlip(new Vector3(317f, -577f, 100f));
          this.Sam1blip.Sprite = BlipSprite.TransformRace;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Start Point";
          this.NextCheckPoint = new Vector3(317f, -577f, 100f);
          this.checkpointReaced = 1;
          this.maxCheckpoints = 11;
          this.Race = 1;
          this.missionnum = 7;
          this.CurrentPoint = 0;
          this.CheckPoints = new Vector3[11];
          this.Rotation = new float[11];
          this.CheckPoints[0] = new Vector3(317f, -577f, 100f);
          this.Rotation[0] = 47f;
          this.CheckPoints[1] = new Vector3(154f, -483f, 62f);
          this.Rotation[1] = 58f;
          this.CheckPoints[2] = new Vector3(43f, -415f, 62f);
          this.Rotation[2] = 69f;
          this.CheckPoints[3] = new Vector3(-123f, -377f, 62f);
          this.Rotation[3] = 85f;
          this.CheckPoints[4] = new Vector3(-233f, -394f, 33f);
          this.Rotation[4] = 85f;
          this.CheckPoints[5] = new Vector3(-424f, -375f, 36f);
          this.Rotation[5] = 85f;
          this.CheckPoints[6] = new Vector3(-514f, -365f, 39f);
          this.Rotation[6] = 85f;
          this.CheckPoints[7] = new Vector3(-552f, -312f, 42f);
          this.Rotation[7] = 30f;
          this.CheckPoints[8] = new Vector3(-594f, -236f, 45f);
          this.Rotation[8] = 30f;
          this.CheckPoints[9] = new Vector3(-644f, -149f, 50f);
          this.Rotation[9] = 30f;
          this.CheckPoints[10] = new Vector3(-767f, -21f, 70f);
          this.Rotation[10] = 41f;
          this.MaxTimer = 55;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " see if you can beat this race!, be careful its dangerous");
        }
        if (item != Mission5)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        this.Sam1blip = World.CreateBlip(new Vector3(317f, -577f, 100f));
        this.Sam1blip.Sprite = BlipSprite.TransformRace;
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "Start Point";
        this.NextCheckPoint = new Vector3(317f, -577f, 100f);
        this.checkpointReaced = 1;
        this.maxCheckpoints = 8;
        this.Race = 1;
        this.missionnum = 7;
        this.CurrentPoint = 0;
        this.CheckPoints = new Vector3[8];
        this.Rotation = new float[8];
        this.CheckPoints[0] = new Vector3(775f, -538f, 91f);
        this.Rotation[0] = 168f;
        this.CheckPoints[1] = new Vector3(780f, -772f, 54f);
        this.Rotation[1] = 168f;
        this.CheckPoints[2] = new Vector3(777f, -845f, 30f);
        this.Rotation[2] = 168f;
        this.CheckPoints[3] = new Vector3(780f, -392f, 30f);
        this.Rotation[3] = 168f;
        this.CheckPoints[4] = new Vector3(787f, -1040f, 30f);
        this.Rotation[4] = 168f;
        this.CheckPoints[5] = new Vector3(795f, -1113f, 50f);
        this.Rotation[5] = 168f;
        this.CheckPoints[6] = new Vector3(805f, -1266f, 72f);
        this.Rotation[6] = 168f;
        this.CheckPoints[7] = new Vector3(806f, -1476f, 62f);
        this.Rotation[7] = 168f;
        this.MaxTimer = 45;
        this.MissionSetup = true;
        UI.Notify(this.GetHostName() + " see if you can beat this race!, be careful its dangerous");
      });
    }

    public void SetupSpecialMissions()
    {
      UIMenu uiMenu = this.BSmodMenuPool2.AddSubMenu(this.Specialmissions, "Special Missions ");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Raising The Flag (P-45 Nakota)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Under Fire (B-11 Strikeforce)");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Invasion Force (Mogul)");
      uiMenu.AddItem(Mission3);
      UIMenuItem Mission4 = new UIMenuItem("Dawn Raid (Mogul)");
      uiMenu.AddItem(Mission4);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission4)
        {
          foreach (Vehicle aiPlane in this.AIPlanes)
          {
            if ((Entity) aiPlane != (Entity) null)
              aiPlane.Delete();
          }
          foreach (Blip planeBlip in this.PlaneBlips)
          {
            if (planeBlip != (Blip) null)
              planeBlip.Remove();
          }
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
              ped.Delete();
          }
          if ((Entity) this.Plane != (Entity) null)
            this.Plane.Delete();
          this.NumberOfPlanes = 0;
          if (this.AIPlanes.Count > 0)
            this.AIPlanes.Clear();
          if (this.PlaneBlips.Count > 0)
            this.PlaneBlips.Clear();
          Ped ped1 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(2017f, -1868f, 360f));
          ped1.FreezePosition = true;
          ped1.IsInvincible = true;
          ped1.IsVisible = false;
          this.PlaneTargetPositions.Add(ped1);
          Ped ped2 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(-74f, 843f, 361f));
          ped2.FreezePosition = true;
          ped2.IsInvincible = true;
          ped2.IsVisible = false;
          this.PlaneTargetPositions.Add(ped2);
          Ped ped3 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(-2583f, -1065f, 359f));
          ped3.FreezePosition = true;
          ped3.IsInvincible = true;
          ped3.IsVisible = false;
          this.PlaneTargetPositions.Add(ped3);
          Vehicle vehicle1 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(52f, -3896f, 150f));
          vehicle1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle1, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle1.GetPedOnSeat(VehicleSeat.Driver));
          vehicle1.AddBlip();
          vehicle1.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle1.CurrentBlip.Color = BlipColor.Red;
          vehicle1.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle1.CurrentBlip);
          this.AIPlanes.Add(vehicle1);
          ++this.NumberOfPlanes;
          Vehicle vehicle2 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(40f, -3896f, 150f));
          vehicle2.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle2, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle2.GetPedOnSeat(VehicleSeat.Driver));
          vehicle2.AddBlip();
          vehicle2.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle2.CurrentBlip.Color = BlipColor.Red;
          vehicle2.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle2.CurrentBlip);
          this.AIPlanes.Add(vehicle2);
          ++this.NumberOfPlanes;
          Vehicle vehicle3 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(45f, -3910f, 150f));
          vehicle3.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle3, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle3.GetPedOnSeat(VehicleSeat.Driver));
          vehicle3.AddBlip();
          vehicle3.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle3.CurrentBlip.Color = BlipColor.Red;
          vehicle3.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle3.CurrentBlip);
          this.AIPlanes.Add(vehicle3);
          ++this.NumberOfPlanes;
          Vehicle vehicle4 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(45f, -3840f, 150f));
          vehicle4.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle4, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle4.GetPedOnSeat(VehicleSeat.Driver));
          vehicle4.AddBlip();
          vehicle4.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle4.CurrentBlip.Color = BlipColor.Red;
          vehicle4.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle4.CurrentBlip);
          this.AIPlanes.Add(vehicle4);
          ++this.NumberOfPlanes;
          Vehicle vehicle5 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(58f, -3840f, 150f));
          vehicle5.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle5, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle5.GetPedOnSeat(VehicleSeat.Driver));
          vehicle5.AddBlip();
          vehicle5.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle5.CurrentBlip.Color = BlipColor.Red;
          vehicle5.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle5.CurrentBlip);
          this.AIPlanes.Add(vehicle5);
          ++this.NumberOfPlanes;
          Vehicle vehicle6 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(58f, -3910f, 150f));
          vehicle6.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle6, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle6.GetPedOnSeat(VehicleSeat.Driver));
          vehicle6.AddBlip();
          vehicle6.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle6.CurrentBlip.Color = BlipColor.Red;
          vehicle6.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle6.CurrentBlip);
          this.AIPlanes.Add(vehicle6);
          ++this.NumberOfPlanes;
          Vehicle vehicle7 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(64f, -3896f, 150f));
          vehicle7.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle7, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle7.GetPedOnSeat(VehicleSeat.Driver));
          vehicle7.AddBlip();
          vehicle7.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle7.CurrentBlip.Color = BlipColor.Red;
          vehicle7.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle7.CurrentBlip);
          this.AIPlanes.Add(vehicle7);
          ++this.NumberOfPlanes;
          Vehicle vehicle8 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(70f, -3910f, 150f));
          vehicle8.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle8, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle8.GetPedOnSeat(VehicleSeat.Driver));
          vehicle8.AddBlip();
          vehicle8.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle8.CurrentBlip.Color = BlipColor.Red;
          vehicle8.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle8.CurrentBlip);
          this.AIPlanes.Add(vehicle8);
          ++this.NumberOfPlanes;
          Vehicle vehicle9 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(35f, -3896f, 150f));
          vehicle9.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle9, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle9.GetPedOnSeat(VehicleSeat.Driver));
          vehicle9.AddBlip();
          vehicle9.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle9.CurrentBlip.Color = BlipColor.Red;
          vehicle9.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle9.CurrentBlip);
          this.AIPlanes.Add(vehicle9);
          ++this.NumberOfPlanes;
          Vehicle vehicle10 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(35f, -3910f, 150f));
          vehicle10.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle10, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle10.GetPedOnSeat(VehicleSeat.Driver));
          vehicle10.AddBlip();
          vehicle10.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle10.CurrentBlip.Color = BlipColor.Red;
          vehicle10.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle10.CurrentBlip);
          this.AIPlanes.Add(vehicle10);
          ++this.NumberOfPlanes;
          Vehicle vehicle11 = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(70f, -3896f, 150f));
          vehicle11.CreateRandomPedOnSeat(VehicleSeat.Driver);
          this.SetActiveTarget(vehicle11, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle11.GetPedOnSeat(VehicleSeat.Driver));
          vehicle11.AddBlip();
          vehicle11.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle11.CurrentBlip.Color = BlipColor.Red;
          vehicle11.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle11.CurrentBlip);
          this.AIPlanes.Add(vehicle11);
          ++this.NumberOfPlanes;
          foreach (Vehicle aiPlane in this.AIPlanes)
          {
            if ((Entity) aiPlane != (Entity) null)
            {
              aiPlane.MaxSpeed = 250f;
              aiPlane.Livery = 4;
              aiPlane.IsInvincible = true;
              aiPlane.BodyHealth = 400f;
              aiPlane.LodDistance = 6000;
              aiPlane.IsPersistent = true;
              if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
                this.Peds.Add(aiPlane.GetPedOnSeat(VehicleSeat.Driver));
              if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.Passenger) != (Entity) null)
                this.Peds.Add(aiPlane.GetPedOnSeat(VehicleSeat.Passenger));
              if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.LeftRear) != (Entity) null)
                this.Peds.Add(aiPlane.GetPedOnSeat(VehicleSeat.LeftRear));
            }
          }
          this.Plane = World.CreateVehicle((Model) VehicleHash.Mogul, new Vector3(-830f, -3360f, 500f));
          this.Plane.Repair();
          this.Plane.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Agent14);
          this.SetActiveTarget2(this.Plane, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], this.Plane.GetPedOnSeat(VehicleSeat.Driver));
          this.CurrentTarget = this.AIPlanes[3].GetPedOnSeat(VehicleSeat.Driver);
          this.Plane.GetPedOnSeat(VehicleSeat.Driver).BlockPermanentEvents = true;
          this.Plane.GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = Game.Player.Character.RelationshipGroup;
          this.Plane.GetPedOnSeat(VehicleSeat.Driver).NeverLeavesGroup = true;
          this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsEnemy = false;
          this.Plane.GetPedOnSeat(VehicleSeat.Driver);
          if ((Entity) this.CurrentTarget == (Entity) null)
            UI.Notify("CHECK");
          this.Plane.AddBlip();
          this.Plane.CurrentBlip.Sprite = BlipSprite.Plane;
          this.Plane.CurrentBlip.Color = BlipColor.Red;
          this.Plane.CurrentBlip.Name = "Player Aircraft";
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Plane.Handle, (InputArgument) 0);
          this.Plane.SetMod(VehicleMod.Roof, 0, false);
          this.Plane.SetMod(VehicleMod.Livery, 7, false);
          this.Plane.SetMod(VehicleMod.Frame, 0, false);
          this.Plane.PrimaryColor = VehicleColor.MetallicDarkSilver;
          this.Plane.SecondaryColor = VehicleColor.MetallicDarkSilver;
          this.Plane.BodyHealth = 4500f;
          this.Plane.EngineHealth = 2500f;
          Game.Player.Character.SetIntoVehicle(this.Plane, VehicleSeat.LeftRear);
          this.MissionSetup = true;
          this.missionnum = 9;
          UI.Notify(this.GetHostName() + " we have spotted a bunch of WW2 era aircraft, circling the city, shoot them down!, with this Mogul");
        }
        if (item == Mission3)
        {
          foreach (Vehicle aiPlane in this.AIPlanes)
          {
            if ((Entity) aiPlane != (Entity) null)
              aiPlane.Delete();
          }
          foreach (Blip planeBlip in this.PlaneBlips)
          {
            if (planeBlip != (Blip) null)
              planeBlip.Remove();
          }
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
              ped.Delete();
          }
          this.NumberOfPlanes = 0;
          if (this.AIPlanes.Count > 0)
            this.AIPlanes.Clear();
          if (this.PlaneBlips.Count > 0)
            this.PlaneBlips.Clear();
          Ped ped1 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(2017f, -1868f, 360f));
          ped1.FreezePosition = true;
          ped1.IsInvincible = true;
          ped1.IsVisible = false;
          this.PlaneTargetPositions.Add(ped1);
          Ped ped2 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(-74f, 843f, 361f));
          ped2.FreezePosition = true;
          ped2.IsInvincible = true;
          ped2.IsVisible = false;
          this.PlaneTargetPositions.Add(ped2);
          Ped ped3 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(-2583f, -1065f, 359f));
          ped3.FreezePosition = true;
          ped3.IsInvincible = true;
          ped3.IsVisible = false;
          this.PlaneTargetPositions.Add(ped3);
          Vehicle vehicle1 = World.CreateVehicle((Model) VehicleHash.Mogul, new Vector3(52f, -3896f, 150f));
          vehicle1.CreateRandomPedOnSeat(VehicleSeat.Driver);
          vehicle1.CreateRandomPedOnSeat(VehicleSeat.Passenger);
          vehicle1.CreateRandomPedOnSeat(VehicleSeat.LeftRear);
          this.SetActiveTarget(vehicle1, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle1.GetPedOnSeat(VehicleSeat.Driver));
          vehicle1.AddBlip();
          vehicle1.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle1.CurrentBlip.Color = BlipColor.Red;
          vehicle1.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle1.CurrentBlip);
          this.AIPlanes.Add(vehicle1);
          ++this.NumberOfPlanes;
          Vehicle vehicle2 = World.CreateVehicle((Model) VehicleHash.Mogul, new Vector3(40f, -3896f, 150f));
          vehicle2.CreateRandomPedOnSeat(VehicleSeat.Driver);
          vehicle2.CreateRandomPedOnSeat(VehicleSeat.Passenger);
          vehicle2.CreateRandomPedOnSeat(VehicleSeat.LeftRear);
          this.SetActiveTarget(vehicle2, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle2.GetPedOnSeat(VehicleSeat.Driver));
          vehicle2.AddBlip();
          vehicle2.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle2.CurrentBlip.Color = BlipColor.Red;
          vehicle2.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle2.CurrentBlip);
          this.AIPlanes.Add(vehicle2);
          ++this.NumberOfPlanes;
          Vehicle vehicle3 = World.CreateVehicle((Model) VehicleHash.Mogul, new Vector3(45f, -3910f, 150f));
          vehicle3.CreateRandomPedOnSeat(VehicleSeat.Driver);
          vehicle3.CreateRandomPedOnSeat(VehicleSeat.Passenger);
          vehicle3.CreateRandomPedOnSeat(VehicleSeat.LeftRear);
          this.SetActiveTarget(vehicle3, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle3.GetPedOnSeat(VehicleSeat.Driver));
          vehicle3.AddBlip();
          vehicle3.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle3.CurrentBlip.Color = BlipColor.Red;
          vehicle3.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle3.CurrentBlip);
          this.AIPlanes.Add(vehicle3);
          ++this.NumberOfPlanes;
          Vehicle vehicle4 = World.CreateVehicle((Model) VehicleHash.Mogul, new Vector3(45f, -3840f, 150f));
          vehicle4.CreateRandomPedOnSeat(VehicleSeat.Driver);
          vehicle4.CreateRandomPedOnSeat(VehicleSeat.Passenger);
          vehicle4.CreateRandomPedOnSeat(VehicleSeat.LeftRear);
          this.SetActiveTarget(vehicle4, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle4.GetPedOnSeat(VehicleSeat.Driver));
          vehicle4.AddBlip();
          vehicle4.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle4.CurrentBlip.Color = BlipColor.Red;
          vehicle4.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle4.CurrentBlip);
          this.AIPlanes.Add(vehicle4);
          ++this.NumberOfPlanes;
          Vehicle vehicle5 = World.CreateVehicle((Model) VehicleHash.Mogul, new Vector3(58f, -3840f, 150f));
          vehicle5.CreateRandomPedOnSeat(VehicleSeat.Driver);
          vehicle5.CreateRandomPedOnSeat(VehicleSeat.Passenger);
          vehicle5.CreateRandomPedOnSeat(VehicleSeat.LeftRear);
          this.SetActiveTarget(vehicle5, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle5.GetPedOnSeat(VehicleSeat.Driver));
          vehicle5.AddBlip();
          vehicle5.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle5.CurrentBlip.Color = BlipColor.Red;
          vehicle5.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle5.CurrentBlip);
          this.AIPlanes.Add(vehicle5);
          ++this.NumberOfPlanes;
          Vehicle vehicle6 = World.CreateVehicle((Model) VehicleHash.Mogul, new Vector3(58f, -3910f, 150f));
          vehicle6.CreateRandomPedOnSeat(VehicleSeat.Driver);
          vehicle6.CreateRandomPedOnSeat(VehicleSeat.Passenger);
          vehicle6.CreateRandomPedOnSeat(VehicleSeat.LeftRear);
          this.SetActiveTarget(vehicle6, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle6.GetPedOnSeat(VehicleSeat.Driver));
          vehicle6.AddBlip();
          vehicle6.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle6.CurrentBlip.Color = BlipColor.Red;
          vehicle6.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle6.CurrentBlip);
          this.AIPlanes.Add(vehicle6);
          ++this.NumberOfPlanes;
          Vehicle vehicle7 = World.CreateVehicle((Model) VehicleHash.Mogul, new Vector3(64f, -3896f, 150f));
          vehicle7.CreateRandomPedOnSeat(VehicleSeat.Driver);
          vehicle7.CreateRandomPedOnSeat(VehicleSeat.Passenger);
          vehicle7.CreateRandomPedOnSeat(VehicleSeat.LeftRear);
          this.SetActiveTarget(vehicle7, this.PlaneTargetPositions[0]);
          this.FightAgainst(this.PlaneTargetPositions[0], vehicle7.GetPedOnSeat(VehicleSeat.Driver));
          vehicle7.AddBlip();
          vehicle7.CurrentBlip.Sprite = BlipSprite.Plane;
          vehicle7.CurrentBlip.Color = BlipColor.Red;
          vehicle7.CurrentBlip.Name = "Enemy Aircraft";
          this.PlaneBlips.Add(vehicle7.CurrentBlip);
          this.AIPlanes.Add(vehicle7);
          ++this.NumberOfPlanes;
          foreach (Vehicle aiPlane in this.AIPlanes)
          {
            if ((Entity) aiPlane != (Entity) null)
            {
              aiPlane.IsPersistent = true;
              if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
                this.Peds.Add(aiPlane.GetPedOnSeat(VehicleSeat.Driver));
              if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.Passenger) != (Entity) null)
                this.Peds.Add(aiPlane.GetPedOnSeat(VehicleSeat.Passenger));
              if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.LeftRear) != (Entity) null)
                this.Peds.Add(aiPlane.GetPedOnSeat(VehicleSeat.LeftRear));
            }
          }
          this.missionnum = 8;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " we have spotted a bunch of WW2 era aircraft, circling the city, shoot them down!");
        }
        if (item == Mission2)
        {
          this.Enemies = 0;
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
              ped.Delete();
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(411f, 2994f, 40f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(394f, 2993f, 40f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(399f, 2975f, 40f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(399f, 2955f, 41f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(437f, 2969f, 40f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(359f, 3003f, 40f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(353f, 2979f, 40f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(404f, 2943f, 40f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          for (int index1 = 0; index1 < 5; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Acult01AMO, new Vector3(454f, 2980f, 40f));
            ped.Weapons.Give(WeaponHash.AssaultRifle, 999, true, true);
            ped.RelationshipGroup = 4;
            ped.Task.WanderAround(ped.Position, 40f);
            ped.AddBlip();
            ped.CurrentBlip.Color = BlipColor.Blue;
            ped.CurrentBlip.Sprite = BlipSprite.Juggernaut;
            this.Peds.Add(ped);
            ++this.Enemies;
          }
          if ((Entity) this.Aircraft != (Entity) null)
            this.Aircraft.Delete();
          this.Aircraft = World.CreateVehicle((Model) VehicleHash.Strikeforce, new Vector3(-959f, -3357f, 13f));
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Aircraft.Handle, (InputArgument) 0);
          this.Aircraft.SetMod(VehicleMod.Livery, 6, true);
          this.Aircraft.PrimaryColor = VehicleColor.MatteDesertBrown;
          this.Aircraft.SecondaryColor = VehicleColor.MatteDesertBrown;
          Game.Player.Character.SetIntoVehicle(this.Aircraft, VehicleSeat.Driver);
          this.missionnum = 5;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " we have found a enemy encampment, show them what the SrikeForce can do!");
        }
        if (item != Mission1)
          return;
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
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
        if ((Entity) this.Aircraft != (Entity) null)
          this.Aircraft.Delete();
        this.Aircraft = World.CreateVehicle((Model) VehicleHash.Nokota, new Vector3(-959f, -3357f, 13f));
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Aircraft.Handle, (InputArgument) 0);
        this.Aircraft.SetMod(VehicleMod.Livery, 6, true);
        this.Aircraft.PrimaryColor = VehicleColor.MetallicSilver;
        this.Aircraft.SecondaryColor = VehicleColor.MetallicSilver;
        Game.Player.Character.SetIntoVehicle(this.Aircraft, VehicleSeat.Driver);
        this.Sam1Loc = new Vector3(-413f, 1580f, 355f);
        this.Sam2Loc = new Vector3(-413f, 1573f, 355f);
        this.Sam3Loc = new Vector3(-430f, 1577f, 357f);
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.HalfTrack, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
        this.Sam2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
        this.Sam3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
        this.Peds.Add(this.Sam1.GetPedOnSeat(VehicleSeat.LeftRear));
        this.Peds.Add(this.Sam2.GetPedOnSeat(VehicleSeat.LeftRear));
        this.Peds.Add(this.Sam3.GetPedOnSeat(VehicleSeat.LeftRear));
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.HalfTrack;
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "HalfTrack A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        this.Sam2blip.Sprite = BlipSprite.HalfTrack;
        this.Sam2blip.Color = BlipColor.Red;
        this.Sam2blip.Name = "HalfTrack B";
        this.Sam3blip = World.CreateBlip(this.Sam3.Position);
        this.Sam3blip.Sprite = BlipSprite.HalfTrack;
        this.Sam3blip.Color = BlipColor.Red;
        this.Sam3blip.Name = "HalfTrack C";
        this.missionnum = 4;
        this.MissionSetup = true;
        UI.Notify(this.GetHostName() + " we have spotted a couple of trucks shooting down aircraft in Grand Senora Desert, lets pay them a visit");
      });
    }

    private void ChangeColor()
    {
    }

    private void SetupCustomizations()
    {
      float totalcost = 0.0f;
      Function.Call((Hash) 3590001984630001091, (InputArgument) 260353, (InputArgument) this.HangarFloorDecal, (InputArgument) this.HangarFloorDecalColor);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 260353);
      this.Config.SetValue<int>("Setup", "HangarFloorDecalColor", this.HangarFloorDecalColor);
      this.Config.Save();
      this.UpdateInterior();
      List<object> objectList = new List<object>();
      for (int index = 0; index < this.MaxColors; ++index)
        objectList.Add((object) index);
      List<object> items1 = new List<object>();
      List<object> StyleP = new List<object>();
      List<object> StyleID = new List<object>();
      items1.Add((object) "Green/Pink");
      StyleP.Add((object) 0);
      StyleID.Add((object) 0);
      items1.Add((object) "Yellow/Red");
      StyleP.Add((object) 0);
      StyleID.Add((object) 1);
      items1.Add((object) "Blue/Yellow");
      StyleP.Add((object) 100000);
      StyleID.Add((object) 2);
      items1.Add((object) "Orange/White");
      StyleP.Add((object) 133000);
      StyleID.Add((object) 3);
      items1.Add((object) "Blue/Blue");
      StyleP.Add((object) 167000);
      StyleID.Add((object) 4);
      items1.Add((object) "Red/Yellow");
      StyleP.Add((object) 200500);
      StyleID.Add((object) 5);
      items1.Add((object) "Gray/Yellow");
      StyleP.Add((object) 234000);
      StyleID.Add((object) 6);
      items1.Add((object) "Black/White");
      StyleP.Add((object) 267500);
      StyleID.Add((object) 7);
      items1.Add((object) "Gray/White");
      StyleP.Add((object) 301000);
      StyleID.Add((object) 8);
      items1.Add((object) "Gray/White");
      StyleP.Add((object) 320000);
      StyleID.Add((object) 9);
      List<object> items2 = new List<object>();
      List<object> LightingP = new List<object>();
      List<object> LightingID = new List<object>();
      items2.Add((object) "Style 1");
      LightingP.Add((object) 0);
      LightingID.Add((object) "set_lighting_hangar_a");
      items2.Add((object) "Style 2");
      LightingP.Add((object) 50000);
      LightingID.Add((object) "set_lighting_hangar_b");
      items2.Add((object) "Style 3");
      LightingP.Add((object) 150000);
      LightingID.Add((object) "set_lighting_hangar_c");
      items2.Add((object) "Style 4");
      LightingP.Add((object) 250000);
      LightingID.Add((object) "set_lighting_hangar_d");
      List<object> items3 = new List<object>();
      List<object> FloorMaterialP = new List<object>();
      List<object> FloorMaterialID = new List<object>();
      items3.Add((object) "Rough");
      FloorMaterialP.Add((object) 0);
      FloorMaterialID.Add((object) "set_floor_1");
      items3.Add((object) "Smooth");
      FloorMaterialP.Add((object) 250000);
      FloorMaterialID.Add((object) "set_floor_2");
      List<object> items4 = new List<object>();
      List<object> DecalP = new List<object>();
      List<object> DecalID = new List<object>();
      items4.Add((object) "Default");
      DecalP.Add((object) 0);
      DecalID.Add((object) "set_floor_decal_1");
      items4.Add((object) "Style 1");
      DecalP.Add((object) 95000);
      DecalID.Add((object) "set_floor_decal_2");
      items4.Add((object) "Style 2");
      DecalP.Add((object) 110000);
      DecalID.Add((object) "set_floor_decal_3");
      items4.Add((object) "Style 3");
      DecalP.Add((object) 125000);
      DecalID.Add((object) "set_floor_decal_4");
      items4.Add((object) "Style 4");
      DecalP.Add((object) 140000);
      DecalID.Add((object) "set_floor_decal_5");
      items4.Add((object) "Style 5");
      DecalP.Add((object) 155000);
      DecalID.Add((object) "set_floor_decal_6");
      items4.Add((object) "Style 6");
      DecalP.Add((object) 170000);
      DecalID.Add((object) "set_floor_decal_7");
      items4.Add((object) "Style 7");
      DecalP.Add((object) 185000);
      DecalID.Add((object) "set_floor_decal_8");
      items4.Add((object) "Style 8");
      DecalP.Add((object) 200000);
      DecalID.Add((object) "set_floor_decal_9");
      List<object> items5 = new List<object>();
      List<object> OfficeStyleP = new List<object>();
      List<object> OfficeStyleID = new List<object>();
      items5.Add((object) "Standard");
      OfficeStyleP.Add((object) 0);
      OfficeStyleID.Add((object) "set_office_basic");
      items5.Add((object) "Traditional");
      OfficeStyleP.Add((object) 195000);
      OfficeStyleID.Add((object) "set_office_traditional");
      items5.Add((object) "Modern");
      OfficeStyleP.Add((object) 280000);
      OfficeStyleID.Add((object) "set_office_modern");
      List<object> items6 = new List<object>();
      List<object> LivingQuartersStyleP = new List<object>();
      List<object> LivingQuartersStyleID = new List<object>();
      items6.Add((object) "None");
      LivingQuartersStyleP.Add((object) 0);
      LivingQuartersStyleID.Add((object) "set_bedroom_clutter");
      items6.Add((object) "Traditional");
      LivingQuartersStyleP.Add((object) 235000);
      LivingQuartersStyleID.Add((object) "set_bedroom_traditional");
      items6.Add((object) "Modern");
      LivingQuartersStyleP.Add((object) 375000);
      LivingQuartersStyleID.Add((object) "set_bedroom_modern");
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.FloorMenu, "Hanger Customisation");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem ColorUI = new UIMenuListItem("Style ", items1, 0);
      uiMenu.AddItem((UIMenuItem) ColorUI);
      UIMenuListItem LightingUI = new UIMenuListItem("Lighting ", items2, 0);
      uiMenu.AddItem((UIMenuItem) LightingUI);
      UIMenuListItem FloorMaterialUI = new UIMenuListItem("Floor Material ", items3, 0);
      uiMenu.AddItem((UIMenuItem) FloorMaterialUI);
      UIMenuListItem DecalUI = new UIMenuListItem("Floor Decal ", items4, 0);
      uiMenu.AddItem((UIMenuItem) DecalUI);
      UIMenuListItem OfficeStyleUI = new UIMenuListItem("Office Style", items5, 0);
      uiMenu.AddItem((UIMenuItem) OfficeStyleUI);
      UIMenuListItem LivingQuartersStyleUI = new UIMenuListItem("Living Quarters Style", items6, 0);
      uiMenu.AddItem((UIMenuItem) LivingQuartersStyleUI);
      UIMenuItem Buy = new UIMenuItem("Buy : ~g~$0");
      uiMenu.AddItem(Buy);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, float>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (float), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float> target1 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__5.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float>> p5 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__5;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target2 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__4.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p4 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__4;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target3 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p3 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target4 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p2 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__2;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target5 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p1 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__0.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__0, StyleP[ColorUI.Index], FloorMaterialP[FloorMaterialUI.Index]);
        object obj2 = DecalP[DecalUI.Index];
        object obj3 = target5((CallSite) p1, obj1, obj2);
        object obj4 = LivingQuartersStyleP[LivingQuartersStyleUI.Index];
        object obj5 = target4((CallSite) p2, obj3, obj4);
        object obj6 = OfficeStyleP[OfficeStyleUI.Index];
        object obj7 = target3((CallSite) p3, obj5, obj6);
        object obj8 = LightingP[LightingUI.Index];
        object obj9 = target2((CallSite) p4, obj7, obj8);
        totalcost = target1((CallSite) p5, obj9);
        Buy.Text = "Buy : ~g~$" + totalcost.ToString("N");
        if (item != Buy || (double) Game.Player.Money < (double) totalcost)
          return;
        Game.Player.Money -= (int) totalcost;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarFloor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__6.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__6, FloorMaterialID[FloorMaterialUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarFloorDecal = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__7.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__7, DecalID[DecalUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarBedroom = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__8.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__8, LivingQuartersStyleID[LivingQuartersStyleUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__9 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarOffice = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__9.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__9, OfficeStyleID[OfficeStyleUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarLighting = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__10.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__10, LightingID[LightingUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__11 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarFloorDecalColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__11.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__11, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__12 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarShellColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__12.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__12, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarBedroomColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__13.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__13, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarCraneColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__14.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__14, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__15 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarWorkshopColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__15.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__15, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__16 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarLightingTintPropsColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__16.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__16, StyleID[ColorUI.Index]);
        this.UpdateInterior();
        this.LoadInterior();
      });
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__22 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, float>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (float), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float> target1 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__22.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float>> p22 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__22;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__21 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target2 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__21.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p21 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__21;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target3 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__20.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p20 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__20;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__19 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target4 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__19.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p19 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__19;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__18 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target5 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__18.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p18 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__18;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__17.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__17, StyleP[ColorUI.Index], FloorMaterialP[FloorMaterialUI.Index]);
        object obj2 = DecalP[DecalUI.Index];
        object obj3 = target5((CallSite) p18, obj1, obj2);
        object obj4 = LivingQuartersStyleP[LivingQuartersStyleUI.Index];
        object obj5 = target4((CallSite) p19, obj3, obj4);
        object obj6 = OfficeStyleP[OfficeStyleUI.Index];
        object obj7 = target3((CallSite) p20, obj5, obj6);
        object obj8 = LightingP[LightingUI.Index];
        object obj9 = target2((CallSite) p21, obj7, obj8);
        totalcost = target1((CallSite) p22, obj9);
        Buy.Text = "Buy : ~g~$" + totalcost.ToString("N");
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__23 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__23 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarFloor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__23.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__23, FloorMaterialID[FloorMaterialUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__24 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__24 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarFloorDecal = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__24.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__24, DecalID[DecalUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__25 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__25 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarBedroom = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__25.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__25, LivingQuartersStyleID[LivingQuartersStyleUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__26 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__26 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarOffice = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__26.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__26, OfficeStyleID[OfficeStyleUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__27 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__27 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarLighting = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__27.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__27, LightingID[LightingUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__28 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__28 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarFloorDecalColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__28.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__28, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__29 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__29 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarShellColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__29.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__29, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__30 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__30 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarBedroomColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__30.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__30, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__31 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__31 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarCraneColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__31.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__31, StyleID[ColorUI.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__394.\u003C\u003Ep__32 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__394.\u003C\u003Ep__32 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.HangarLightingTintPropsColor = Hanger.\u003C\u003Eo__394.\u003C\u003Ep__32.Target((CallSite) Hanger.\u003C\u003Eo__394.\u003C\u003Ep__32, StyleID[ColorUI.Index]);
        this.LoadInterior();
      });
    }

    public void UpdateInterior()
    {
      this.ConfigCustomizeHanger.SetValue<string>("Setup", "HangarLighting", this.HangarLighting);
      this.ConfigCustomizeHanger.SetValue<string>("Setup", "HangarFloor", this.HangarFloor);
      this.ConfigCustomizeHanger.SetValue<string>("Setup", "HangarFloorDecal", this.HangarFloorDecal);
      this.ConfigCustomizeHanger.SetValue<string>("Setup", "HangarBedroom", this.HangarBedroom);
      this.ConfigCustomizeHanger.SetValue<string>("Setup", "HangarOffice", this.HangarOffice);
      this.ConfigCustomizeHanger.SetValue<string>("Setup", "HangarBedroomBlinds", this.HangarBedroomBlinds);
      this.ConfigCustomizeHanger.SetValue<string>("Setup", "HangarLightingWallTint", this.HangarLightingWallTint);
      this.ConfigCustomizeHanger.SetValue<int>("Setup", "HangarFloorDecalColor", this.HangarFloorDecalColor);
      this.ConfigCustomizeHanger.SetValue<int>("Setup", "HangarShellColor", this.HangarShellColor);
      this.ConfigCustomizeHanger.SetValue<int>("Setup", "HangarBedroomColor", this.HangarBedroomColor);
      this.ConfigCustomizeHanger.SetValue<int>("Setup", "HangarCrwaneColor", this.HangarCraneColor);
      this.ConfigCustomizeHanger.SetValue<int>("Setup", "HangarWorkshopColor", this.HangarWorkshopColor);
      this.ConfigCustomizeHanger.SetValue<int>("Setup", "HangarLightingTintPropsColor", this.HangarLightingTintPropsColor);
      this.ConfigCustomizeHanger.Save();
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 260353);
      this.LoadInterior();
    }

    public void SetInInterior(bool Interior)
    {
      if (Interior)
        this.IsInInterior = true;
      if (Interior)
        return;
      this.IsInInterior = false;
    }

    public void LoadInterior()
    {
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_lighting_hangar_a");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_lighting_hangar_b");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_lighting_hangar_c");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_lighting_hangar_d");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_1");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_2");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_office_basic");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_office_traditional");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_office_modern");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_bedroom_clutter");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_bedroom_traditional");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_bedroom_modern");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) this.HangarFloorDecal);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 260353);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_1");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_2");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_3");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_4");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_5");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_6");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_7");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_8");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 260353, (InputArgument) "set_floor_decal_9");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) this.HangarLighting);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) this.HangarFloor);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) this.HangarFloorDecal);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) this.HangarBedroom);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) this.HangarOffice);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) this.HangarBedroomBlinds);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) this.HangarLightingWallTint);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) this.HangarNeutralLighting);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) "set_tint_shell");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) "set_bedroom_tint");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) "set_crane_tint");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 260353, (InputArgument) "set_modarea");
      Function.Call((Hash) 3590001984630001091, (InputArgument) 260353, (InputArgument) this.HangarFloorDecal, (InputArgument) this.HangarFloorDecalColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) 260353, (InputArgument) "set_tint_shell", (InputArgument) this.HangarShellColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) 260353, (InputArgument) "set_bedroom_tint", (InputArgument) this.HangarBedroomColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) 260353, (InputArgument) "set_crane_tint", (InputArgument) this.HangarCraneColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) 260353, (InputArgument) "set_modarea", (InputArgument) this.HangarWorkshopColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) 260353, (InputArgument) "set_lighting_tint_props", (InputArgument) this.HangarLightingTintPropsColor);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 260353);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 260353);
    }

    public void BuyACar()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.BuyCar, "Buy a S.R car");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Cyclone = new UIMenuItem("Cyclone : $1,890,000");
      uiMenu.AddItem(Cyclone);
      UIMenuItem RapidGT = new UIMenuItem("RapidGT Classic : $885,000 ");
      uiMenu.AddItem(RapidGT);
      UIMenuItem Retinue = new UIMenuItem("Retinue : $615,000");
      uiMenu.AddItem(Retinue);
      UIMenuItem Visione = new UIMenuItem("Visione : $2,250,000");
      uiMenu.AddItem(Visione);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Cyclone && this.CycloneBought == 0 && Game.Player.Money >= 1890000)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
          Game.Player.Money -= 1890000;
          this.CycloneBought = 1;
          this.Config.SetValue<int>("EXTRACARS", "CycloneBought", this.CycloneBought);
          this.Config.Save();
          UI.Notify(this.GetHostName() + " Your new Cyclone will be delivered next time you enter the Hanger");
        }
        if (item == RapidGT && this.RapidGTBought == 0 && Game.Player.Money >= 885000)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
          Game.Player.Money -= 885000;
          this.RapidGTBought = 1;
          this.Config.SetValue<int>("EXTRACARS", "RapidGTBought", this.RapidGTBought);
          this.Config.Save();
          UI.Notify(this.GetHostName() + " Your new Rapid GT Classic will be delivered next time you enter the Hanger");
        }
        if (item == Retinue && this.RetinueBought == 0 && Game.Player.Money >= 615000)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
          Game.Player.Money -= 615000;
          this.RetinueBought = 1;
          this.Config.SetValue<int>("EXTRACARS", "RetinueBought", this.RetinueBought);
          this.Config.Save();
          UI.Notify(this.GetHostName() + " Your new Retinue will be delivered next time you enter the Hanger");
        }
        if (item != Visione || this.VisioneBought != 0 || Game.Player.Money < 2250000)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
        Game.Player.Money -= 2250000;
        this.VisioneBought = 1;
        this.Config.SetValue<int>("EXTRACARS", "VisioneBought", this.VisioneBought);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " Your new Visione will be delivered next time you enter the Hanger");
      });
    }

    public void DeleteCarinSlot(string Slot, Vehicle V)
    {
      this.SC.LoadIniFile(this.path + this.GarageNum + "//" + Slot + ".ini");
      UI.Notify(this.path + this.GarageNum + "//" + Slot + ".ini");
      this.SC.SaveName();
      V.Delete();
    }

    public void RemoveCar()
    {
      float PPrice = 0.0f;
      List<object> Slotsid = new List<object>();
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1");
      Slotsid.Add((object) "L");
      Slots.Add((object) "Slot2");
      Slotsid.Add((object) "M");
      Slots.Add((object) "Slot3");
      Slotsid.Add((object) "M");
      Slots.Add((object) "Slot4");
      Slotsid.Add((object) "S");
      Slots.Add((object) "Slot5");
      Slotsid.Add((object) "S");
      Slots.Add((object) "Slot6");
      Slotsid.Add((object) "M");
      Slots.Add((object) "Slot7");
      Slotsid.Add((object) "S");
      Slots.Add((object) "Slot8");
      Slotsid.Add((object) "S");
      Slots.Add((object) "Slot9");
      Slotsid.Add((object) "M");
      Slots.Add((object) "Slot10");
      Slotsid.Add((object) "S");
      Slots.Add((object) "Slot11");
      Slotsid.Add((object) "M");
      Slots.Add((object) "Slot12");
      Slotsid.Add((object) "S");
      List<object> PCost = new List<object>();
      List<object> PVehicle = new List<object>();
      List<object> items = new List<object>();
      List<object> PSize = new List<object>();
      items.Add((object) "Alpha Z1");
      PVehicle.Add((object) "AlphaZ1");
      PCost.Add((object) 2121350);
      PSize.Add((object) "S");
      items.Add((object) "Besra");
      PVehicle.Add((object) "Besra");
      PCost.Add((object) 1150000);
      PSize.Add((object) "S");
      items.Add((object) "Buzzard Attack Chopper");
      PVehicle.Add((object) "Buzzard");
      PCost.Add((object) 2000000);
      PSize.Add((object) "S");
      items.Add((object) "Buzzard Chopper");
      PVehicle.Add((object) "Buzzard2");
      PCost.Add((object) 1200000);
      PSize.Add((object) "S");
      items.Add((object) "Cuban 800");
      PVehicle.Add((object) "Cuban800");
      PCost.Add((object) 240000);
      PSize.Add((object) "S");
      items.Add((object) "Duster");
      PVehicle.Add((object) "Duster");
      PCost.Add((object) 275000);
      PSize.Add((object) "S");
      items.Add((object) "Frogger");
      PVehicle.Add((object) "Frogger");
      PCost.Add((object) 1300000);
      PSize.Add((object) "S");
      items.Add((object) "Havok");
      PVehicle.Add((object) "Havok");
      PCost.Add((object) 2300900);
      PSize.Add((object) "S");
      items.Add((object) "Howard NX-25");
      PVehicle.Add((object) "Howard");
      PCost.Add((object) 1296750);
      PSize.Add((object) "S");
      items.Add((object) "LF-22 Starling");
      PVehicle.Add((object) "Starling");
      PCost.Add((object) 3657500);
      PSize.Add((object) "S");
      items.Add((object) "Mallard");
      PVehicle.Add((object) "Stunt");
      PCost.Add((object) 250000);
      PSize.Add((object) "S");
      items.Add((object) "Mammatus");
      PVehicle.Add((object) "Mammatus");
      PCost.Add((object) 300000);
      PSize.Add((object) "S");
      items.Add((object) "Maverick");
      PVehicle.Add((object) "Maverick");
      PCost.Add((object) 780000);
      PSize.Add((object) "S");
      items.Add((object) "P-45 Nokota");
      PVehicle.Add((object) "Nokota");
      PCost.Add((object) 2653350);
      PSize.Add((object) "S");
      items.Add((object) "P-996 LAZER");
      PVehicle.Add((object) "Lazer");
      PCost.Add((object) 6500000);
      PSize.Add((object) "S");
      items.Add((object) "Pyro");
      PVehicle.Add((object) "Pyro");
      PCost.Add((object) 4455500);
      PSize.Add((object) "S");
      items.Add((object) "Rogue");
      PVehicle.Add((object) "Rogue");
      PCost.Add((object) 1596000);
      PSize.Add((object) "S");
      items.Add((object) "Seabreeze");
      PVehicle.Add((object) "Seabreeze");
      PCost.Add((object) 1130500);
      PSize.Add((object) "S");
      items.Add((object) "Sea Sparrow");
      PVehicle.Add((object) "SeaSparrow");
      PCost.Add((object) 1815000);
      PSize.Add((object) "S");
      items.Add((object) "SuperVolito");
      PVehicle.Add((object) "Supervolito");
      PCost.Add((object) 2113000);
      PSize.Add((object) "S");
      items.Add((object) "SuperVolito Carbon");
      PVehicle.Add((object) "Supervolito2");
      PCost.Add((object) 3330000);
      PSize.Add((object) "S");
      items.Add((object) "Ultralight");
      PVehicle.Add((object) "Microlight");
      PCost.Add((object) 665000);
      PSize.Add((object) "S");
      items.Add((object) "V-65 Molotok");
      PVehicle.Add((object) "Molotok");
      PCost.Add((object) 4788000);
      PSize.Add((object) "S");
      items.Add((object) "Velum");
      PVehicle.Add((object) "Velum");
      PCost.Add((object) 450000);
      PSize.Add((object) "S");
      items.Add((object) "Velum 5-Seater");
      PVehicle.Add((object) "Velum2");
      PCost.Add((object) 1323350);
      PSize.Add((object) "S");
      items.Add((object) "Vestra");
      PVehicle.Add((object) "Vestra");
      PCost.Add((object) 950000);
      PSize.Add((object) "S");
      items.Add((object) "Volatus");
      PVehicle.Add((object) "Volatus");
      PCost.Add((object) 2295000);
      PSize.Add((object) "S");
      items.Add((object) "Akula");
      PVehicle.Add((object) "Akula");
      PCost.Add((object) 3704050);
      PSize.Add((object) "M");
      items.Add((object) "Annihilator");
      PVehicle.Add((object) "Annihilator");
      PCost.Add((object) 1825000);
      PSize.Add((object) "M");
      items.Add((object) "B-11 Strikeforce");
      PVehicle.Add((object) "Strikeforce");
      PCost.Add((object) 3800000);
      PSize.Add((object) "M");
      items.Add((object) "Cargobob 1");
      PVehicle.Add((object) "Cargobob");
      PCost.Add((object) 2200000);
      PSize.Add((object) "M");
      items.Add((object) "Cargobob 2");
      PVehicle.Add((object) "Cargobob2");
      PCost.Add((object) 2200000);
      PSize.Add((object) "M");
      items.Add((object) "Cargobob 3");
      PVehicle.Add((object) "Cargobob3");
      PCost.Add((object) 2200000);
      PSize.Add((object) "M");
      items.Add((object) "Cargobob 4");
      PVehicle.Add((object) "Cargobob4");
      PCost.Add((object) 2200000);
      PSize.Add((object) "M");
      items.Add((object) "Dodo");
      PVehicle.Add((object) "Dodo");
      PCost.Add((object) 500000);
      PSize.Add((object) "M");
      items.Add((object) "FH-1 Hunter");
      PVehicle.Add((object) "Hunter");
      PCost.Add((object) 4123000);
      PSize.Add((object) "M");
      items.Add((object) "Hydra");
      PVehicle.Add((object) "Hydra");
      PCost.Add((object) 3990000);
      PSize.Add((object) "M");
      items.Add((object) "Luxor Deluxe");
      PVehicle.Add((object) "Luxor2");
      PCost.Add((object) 10000000);
      PSize.Add((object) "M");
      items.Add((object) "Luxor");
      PVehicle.Add((object) "Luxor");
      PCost.Add((object) 1625000);
      PSize.Add((object) "M");
      items.Add((object) "Mogul");
      PVehicle.Add((object) "Mogul");
      PCost.Add((object) 3125500);
      PSize.Add((object) "M");
      items.Add((object) "Nimbus");
      PVehicle.Add((object) "Nimbus");
      PCost.Add((object) 1900000);
      PSize.Add((object) "M");
      items.Add((object) "Savage");
      PVehicle.Add((object) "Savage");
      PCost.Add((object) 2593500);
      PSize.Add((object) "M");
      items.Add((object) "Shamal");
      PVehicle.Add((object) "Shamal");
      PCost.Add((object) 1150000);
      PSize.Add((object) "M");
      items.Add((object) "Swift");
      PVehicle.Add((object) "Swift");
      PCost.Add((object) 1600000);
      PSize.Add((object) "M");
      items.Add((object) "Swift Deluxe");
      PVehicle.Add((object) "Swift2");
      PCost.Add((object) 5150000);
      PSize.Add((object) "M");
      items.Add((object) "Tula");
      PVehicle.Add((object) "Tula");
      PCost.Add((object) 5173700);
      PSize.Add((object) "M");
      items.Add((object) "Valkyrie");
      PVehicle.Add((object) "Valkyrie");
      PCost.Add((object) 3790500);
      PSize.Add((object) "M");
      items.Add((object) "Miljet");
      PVehicle.Add((object) "Miljet");
      PCost.Add((object) 1700000);
      PSize.Add((object) "L");
      items.Add((object) "RM-10 Bombushka");
      PVehicle.Add((object) "Bombushka");
      PCost.Add((object) 5918500);
      PSize.Add((object) "L");
      items.Add((object) "Titan");
      PVehicle.Add((object) "Titan");
      PCost.Add((object) 2000000);
      PSize.Add((object) "L");
      items.Add((object) "Volatol");
      PVehicle.Add((object) "Volatol");
      PCost.Add((object) 3724000);
      PSize.Add((object) "L");
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Add Aircraft To Hanger");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem list2 = new UIMenuListItem("Slot ", Slots, 0);
      uiMenu1.AddItem((UIMenuItem) list2);
      UIMenuListItem VListN = new UIMenuListItem("Vehicle ", items, 0);
      uiMenu1.AddItem((UIMenuItem) VListN);
      UIMenuItem VehinSlot = new UIMenuItem("Vehicle in Slot : null");
      uiMenu1.AddItem(VehinSlot);
      UIMenuItem GetVehicle = new UIMenuItem("Get Vehicle ~g~$" + PPrice.ToString("N"));
      uiMenu1.AddItem(GetVehicle);
      UIMenuItem SlotSize = new UIMenuItem("Slot Size : ~b~ L");
      uiMenu1.AddItem(SlotSize);
      UIMenuItem VehicleSize = new UIMenuItem("Vehicle Size : ~b~ L");
      uiMenu1.AddItem(VehicleSize);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != GetVehicle)
          return;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__0 = CallSite<Action<CallSite, Hanger, object, object, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "SaveNewVehicle", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[6]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Hanger.\u003C\u003Eo__400.\u003C\u003Ep__0.Target((CallSite) Hanger.\u003C\u003Eo__400.\u003C\u003Ep__0, this, Slots[list2.Index], PVehicle[VListN.Index], Slotsid[list2.Index], PSize[VListN.Index], PCost[VListN.Index]);
      });
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        UIMenuItem uiMenuItem1 = SlotSize;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target1 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p2 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__2;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__1 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__1.Target((CallSite) Hanger.\u003C\u003Eo__400.\u003C\u003Ep__1, "Slot Size : ~b~", Slotsid[list2.Index]);
        string str1 = target1((CallSite) p2, obj1);
        uiMenuItem1.Text = str1;
        UIMenuItem uiMenuItem2 = VehicleSize;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target2 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__4.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p4 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__4;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__3 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__3.Target((CallSite) Hanger.\u003C\u003Eo__400.\u003C\u003Ep__3, "Vehicle Size : ~b~", PSize[VListN.Index]);
        string str2 = target2((CallSite) p4, obj2);
        uiMenuItem2.Text = str2;
        this.GarageNum = "Hanger1";
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__7 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, SaveCar, object> target3 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__7.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, SaveCar, object>> p7 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__7;
        SaveCar sc = this.SC;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string, object> target4 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string, object>> p6 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__5 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__5.Target((CallSite) Hanger.\u003C\u003Eo__400.\u003C\u003Ep__5, this.path + this.GarageNum + "//", Slots[list2.Index]);
        object obj4 = target4((CallSite) p6, obj3, ".ini");
        target3((CallSite) p7, sc, obj4);
        VehinSlot.Text = "Vehicle in Slot: " + this.SC.VehicleName;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__400.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__400.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, float>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (float), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        PPrice = Hanger.\u003C\u003Eo__400.\u003C\u003Ep__8.Target((CallSite) Hanger.\u003C\u003Eo__400.\u003C\u003Ep__8, PCost[VListN.Index]);
        GetVehicle.Text = "Get Vehicle ~g~$" + PPrice.ToString("N");
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Remove Vehicle");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem Slot1A = new UIMenuItem("Slot 1");
      uiMenu2.AddItem(Slot1A);
      UIMenuItem Slot2A = new UIMenuItem("Slot 2");
      uiMenu2.AddItem(Slot2A);
      UIMenuItem Slot3A = new UIMenuItem("Slot 3");
      uiMenu2.AddItem(Slot3A);
      UIMenuItem Slot4A = new UIMenuItem("Slot 4");
      uiMenu2.AddItem(Slot4A);
      UIMenuItem Slot5A = new UIMenuItem("Slot 5");
      uiMenu2.AddItem(Slot5A);
      UIMenuItem Slot6A = new UIMenuItem("Slot 6");
      uiMenu2.AddItem(Slot6A);
      UIMenuItem Slot7A = new UIMenuItem("Slot 7");
      uiMenu2.AddItem(Slot7A);
      UIMenuItem Slot8A = new UIMenuItem("Slot 8");
      uiMenu2.AddItem(Slot8A);
      UIMenuItem Slot9A = new UIMenuItem("Slot 9");
      uiMenu2.AddItem(Slot9A);
      UIMenuItem Slot10A = new UIMenuItem("Slot 10");
      uiMenu2.AddItem(Slot10A);
      UIMenuItem Slot11A = new UIMenuItem("Slot 11");
      uiMenu2.AddItem(Slot11A);
      UIMenuItem Slot12A = new UIMenuItem("Slot 12");
      uiMenu2.AddItem(Slot12A);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Slot1A && (Entity) this.Vehicle1 != (Entity) null)
          this.DeleteCarinSlot("Slot1", this.Vehicle1);
        if (item == Slot2A && (Entity) this.Vehicle2 != (Entity) null)
          this.DeleteCarinSlot("Slot2", this.Vehicle2);
        if (item == Slot3A && (Entity) this.Vehicle3 != (Entity) null)
          this.DeleteCarinSlot("Slot3", this.Vehicle3);
        if (item == Slot4A && (Entity) this.Vehicle4 != (Entity) null)
          this.DeleteCarinSlot("Slot4", this.Vehicle4);
        if (item == Slot5A && (Entity) this.Vehicle5 != (Entity) null)
          this.DeleteCarinSlot("Slot5", this.Vehicle5);
        if (item == Slot6A && (Entity) this.Vehicle6 != (Entity) null)
          this.DeleteCarinSlot("Slot6", this.Vehicle6);
        if (item == Slot7A && (Entity) this.Vehicle7 != (Entity) null)
          this.DeleteCarinSlot("Slot7", this.Vehicle7);
        if (item == Slot8A && (Entity) this.Vehicle8 != (Entity) null)
          this.DeleteCarinSlot("Slot8", this.Vehicle8);
        if (item == Slot9A && (Entity) this.Vehicle9 != (Entity) null)
          this.DeleteCarinSlot("Slot9", this.Vehicle9);
        if (item == Slot10A && (Entity) this.Vehicle10 != (Entity) null)
          this.DeleteCarinSlot("Slot10", this.Vehicle10);
        if (item == Slot11A && (Entity) this.Vehicle11 != (Entity) null)
          this.DeleteCarinSlot("Slot11", this.Vehicle11);
        if (item != Slot12A || !((Entity) this.Vehicle12 != (Entity) null))
          return;
        this.DeleteCarinSlot("Slot12", this.Vehicle12);
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
          this.SetInInterior(true);
          this.IsInInterior = true;
          string Garage = G;
          this.GarageNum = G;
          string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
          this.SC.LoadIniFile(this.path + Garage + "//" + Slot + ".ini");
          this.SC.Save();
          this.DestoryCars();
          Game.Player.Character.Position = this.Exit;
          this.CreateCars(Garage);
        }
        else
          this.DisplayHelpTextThisFrame("You cannot save this vehicle");
      }
      else
        this.DisplayHelpTextThisFrame("Bring a vehicle to save");
    }

    public void SetupGarage()
    {
      List<object> items1 = new List<object>();
      items1.Add((object) "False");
      items1.Add((object) "True");
      List<object> items2 = new List<object>();
      items2.Add((object) "Small");
      items2.Add((object) "Medium");
      items2.Add((object) "Large");
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot4");
      Slots.Add((object) "Slot5");
      Slots.Add((object) "Slot7");
      Slots.Add((object) "Slot8");
      Slots.Add((object) "Slot10");
      Slots.Add((object) "Slot12");
      UIMenu menu = this.modMenuPool.AddSubMenu(this.GarageMenu, "Vehicle Slots");
      this.GUIMenus.Add(menu);
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(menu, "Small Slots");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(menu, "Medium Slots");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(menu, "Large Slots");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem Slot1 = new UIMenuItem("Slot1");
      uiMenu3.AddItem(Slot1);
      UIMenuItem Slot2 = new UIMenuItem("Slot2");
      uiMenu2.AddItem(Slot2);
      UIMenuItem Slot3 = new UIMenuItem("Slot3");
      uiMenu2.AddItem(Slot3);
      UIMenuItem Slot6 = new UIMenuItem("Slot6");
      uiMenu2.AddItem(Slot6);
      UIMenuItem Slot9 = new UIMenuItem("Slot9");
      uiMenu2.AddItem(Slot9);
      UIMenuItem Slot11 = new UIMenuItem("Slot11");
      uiMenu2.AddItem(Slot11);
      UIMenuItem Slot4 = new UIMenuItem("Slot4");
      uiMenu1.AddItem(Slot4);
      UIMenuItem Slot5 = new UIMenuItem("Slot5");
      uiMenu1.AddItem(Slot5);
      UIMenuItem Slot7 = new UIMenuItem("Slot7");
      uiMenu1.AddItem(Slot7);
      UIMenuItem Slot8 = new UIMenuItem("Slot8");
      uiMenu1.AddItem(Slot8);
      UIMenuItem Slot10 = new UIMenuItem("Slot10");
      uiMenu1.AddItem(Slot10);
      UIMenuItem Slot12 = new UIMenuItem("Slot12");
      uiMenu1.AddItem(Slot12);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Slot1)
        {
          if (!((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
            return;
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z < 60)
            return;
          this.SaveLocalcar("Hanger1", this.Vehicle1, "Slot1");
        }
        else
          UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Slot2 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z >= 25)
            this.SaveLocalcar("Hanger1", this.Vehicle2, "Slot2");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item == Slot3 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z >= 25)
            this.SaveLocalcar("Hanger1", this.Vehicle3, "Slot3");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item == Slot6 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z >= 25)
            this.SaveLocalcar("Hanger1", this.Vehicle6, "Slot6");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item == Slot9 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z >= 25)
            this.SaveLocalcar("Hanger1", this.Vehicle9, "Slot9");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item != Slot11 || !((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
          return;
        Vector3 dimensions1 = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
        if ((int) dimensions1.X + (int) dimensions1.Y + (int) dimensions1.Z >= 25)
          this.SaveLocalcar("Hanger1", this.Vehicle11, "Slot11");
        else
          UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Slot4 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z < 25)
            this.SaveLocalcar("Hanger1", this.Vehicle4, "Slot4");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item == Slot5 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z < 25)
            this.SaveLocalcar("Hanger1", this.Vehicle5, "Slot5");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item == Slot7 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z < 25)
            this.SaveLocalcar("Hanger1", this.Vehicle7, "Slot7");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item == Slot8 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z < 25)
            this.SaveLocalcar("Hanger1", this.Vehicle8, "Slot8");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item == Slot10 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 dimensions = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
          if ((int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z < 25)
            this.SaveLocalcar("Hanger1", this.Vehicle10, "Slot10");
          else
            UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
        }
        if (item != Slot12 || !((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
          return;
        Vector3 dimensions1 = Game.Player.Character.CurrentVehicle.Model.GetDimensions();
        if ((int) dimensions1.X + (int) dimensions1.Y + (int) dimensions1.Z < 25)
          this.SaveLocalcar("Hanger1", this.Vehicle12, "Slot12");
        else
          UI.Notify(this.GetHostName() + " you cannot store this vehicle in this slot or you cannot store this vehicle in this hanger");
      });
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.GarageMenu, "View Vehicle");
      this.GUIMenus.Add(uiMenu4);
      UIMenuListItem E = new UIMenuListItem("View Area: ", items1, 0);
      uiMenu4.AddItem((UIMenuItem) E);
      UIMenuListItem g1 = new UIMenuListItem("Slot Size : ", items2, 0);
      uiMenu4.AddItem((UIMenuItem) g1);
      UIMenuListItem s1 = new UIMenuListItem("Slot : ", Slots, 0);
      uiMenu4.AddItem((UIMenuItem) s1);
      UIMenuItem CarinSlot1 = new UIMenuItem("Aircraft : ");
      uiMenu4.AddItem(CarinSlot1);
      UIMenuItem Drive = new UIMenuItem("Fly this Aircraft");
      uiMenu4.AddItem(Drive);
      uiMenu4.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == E)
        {
          if (E.IndexToItem(E.Index) == (object) "True")
          {
            this.ISinviewMode = true;
            this.P = Game.Player.Character.Position;
            if (this.Cam != (Camera) null)
            {
              World.RenderingCamera = this.Cam;
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              this.Cam.IsActive = false;
              this.Cam.Destroy();
            }
            this.Cam = World.CreateCamera(this.CamAPos, new Vector3(0.0f, 0.0f, 86f), 90f);
            Game.Player.Character.Position = this.Cam.Position;
            Game.Player.Character.Rotation = this.Cam.Rotation;
            Game.Player.Character.IsVisible = false;
            Game.Player.Character.FreezePosition = true;
            this.Cam.IsActive = true;
            this.Cam.FarClip = 2000f;
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          }
          else if (E.IndexToItem(E.Index) == (object) "False")
          {
            this.ISinviewMode = false;
            Game.Player.Character.Position = this.Entry;
            Game.Player.Character.IsVisible = true;
            Game.Player.Character.FreezePosition = false;
            if (this.Cam != (Camera) null)
            {
              if ((Entity) this.Vehicle1 != (Entity) null)
                this.Vehicle1.Delete();
              World.RenderingCamera = this.Cam;
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              this.Cam.IsActive = false;
              this.Cam.Destroy();
            }
          }
        }
        if (item == g1)
        {
          if (g1.IndexToItem(g1.Index).Equals((object) "Small"))
          {
            Slots.Clear();
            Slots.Add((object) "Slot4");
            Slots.Add((object) "Slot5");
            Slots.Add((object) "Slot7");
            Slots.Add((object) "Slot8");
            Slots.Add((object) "Slot10");
            Slots.Add((object) "Slot12");
          }
          if (g1.IndexToItem(g1.Index).Equals((object) "Medium"))
          {
            Slots.Clear();
            Slots.Add((object) "Slot2");
            Slots.Add((object) "Slot3");
            Slots.Add((object) "Slot6");
            Slots.Add((object) "Slot9");
            Slots.Add((object) "Slot11");
          }
          if (g1.IndexToItem(g1.Index).Equals((object) "Large"))
          {
            Slots.Clear();
            Slots.Add((object) "Slot1");
          }
        }
        if (item != s1)
          return;
        if ((Entity) this.Vehicle1 != (Entity) null)
          this.Vehicle1.Delete();
        this.SC.LoadIniFile(this.path + "//Hanger1//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini");
        if (!this.SC.VehicleName.Equals("null"))
          CarinSlot1.Text = this.SC.VehicleName;
        else if (this.SC.VehicleName.Equals("null"))
          CarinSlot1.Text = "No car in slot";
        try
        {
          if (!(this.SC.CheckCar(this.path + "//Hanger1//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini") != (Model) "null"))
            return;
          this.SC.LoadIniFile(this.path + "//Hanger1//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini");
          this.Vehicle1 = World.CreateVehicle(this.SC.CheckCar(this.path + "//Hanger1//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini"), new Vector3(-1267f, -3012f, 1004f), -90f);
          Game.Player.Character.SetIntoVehicle(this.Vehicle1, VehicleSeat.Driver);
          this.SC.Load(this.Vehicle1);
          this.Vehicle1.FreezePosition = true;
          this.Vehicle1.IsDriveable = true;
          this.Vehicle1.EngineRunning = true;
          this.Vehicle1.HighBeamsOn = true;
        }
        catch (Exception ex)
        {
          UI.Notify("~r~ Could Not Load Vehicle, Please Try Again ~w~");
        }
      });
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Drive)
          return;
        if ((Entity) this.Vehicle2 != (Entity) null)
          this.Vehicle2.Delete();
        this.Vehicle2 = this.Vehicle1;
        this.Vehicle1 = (Vehicle) null;
        this.ISinviewMode = false;
        Game.Player.Character.Position = this.Entry;
        Game.Player.Character.IsVisible = true;
        Game.Player.Character.FreezePosition = false;
        if (this.Cam != (Camera) null)
        {
          World.RenderingCamera = this.Cam;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.Cam.IsActive = false;
          this.Cam.Destroy();
        }
        this.SC.LoadIniFile(this.path + "//Hanger1//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini");
        if (!this.SC.VehicleName.Equals("null"))
        {
          CarinSlot1.Text = this.SC.VehicleName;
          try
          {
            if (!(this.SC.CheckCar(this.path + "//Hanger1//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini") != (Model) "null"))
              return;
            this.SC.LoadIniFile(this.path + "//Hanger1//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini");
            this.Vehicle2 = World.CreateVehicle(this.SC.CheckCar(this.path + "//Hanger1//" + s1.IndexToItem(s1.Index)?.ToString() + ".ini"), new Vector3(0.0f, 0.0f, 0.0f), -90f);
            this.SC.Load(this.Vehicle2);
            Script.Wait(20);
            Game.Player.Character.SetIntoVehicle(this.Vehicle2, VehicleSeat.Driver);
            this.Vehicle2.FreezePosition = true;
            this.Vehicle2.IsDriveable = true;
            this.Vehicle2.EngineRunning = true;
            this.Vehicle2.HighBeamsOn = true;
            this.Vehicle2 = (Vehicle) null;
            Script.Wait(20);
            this.LoadCarinToRealWorld(this.Vehicle2);
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Could Not Load Vehicle, Please Try Again ~w~");
          }
        }
        else
        {
          if (!this.SC.VehicleName.Equals("null"))
            return;
          CarinSlot1.Text = "No car in slot";
        }
      });
    }

    public void LoadVehicels()
    {
    }

    public void SaveNewVehicle(string Slot, string Name, string SType, string vType, float Price)
    {
      this.GarageNum = "Hanger1";
      UI.Notify("Slot Type  : " + SType);
      UI.Notify("Vehicle Type  : " + vType);
      vType.Equals("S");
      vType.Equals("M");
      vType.Equals("L");
      if ((double) Game.Player.Money > (double) Price)
      {
        if (Slot.Equals("Slot4") || Slot.Equals("Slot5") || (Slot.Equals("Slot7") || Slot.Equals("Slot8")) || (Slot.Equals("Slot10") || Slot.Equals("Slot12")))
        {
          if (SType.Equals("S") && SType.Equals(vType))
          {
            this.SC.LoadIniFile(this.path + this.GarageNum + "//" + Slot + ".ini");
            this.SC.VehicleName = Name;
            this.SC.Config.SetValue<string>("Configurations", "VehicleName", this.SC.VehicleName);
            this.SC.Config.Save();
            Game.Player.Money -= (int) Price;
            this.DestoryCars();
            this.CreateCars("Hanger1");
          }
          else
            UI.Notify(this.GetHostName() + " Vehicle Size and Slot Size have to match! to purchase Vehicle in this Slot");
        }
        if (Slot.Equals("Slot2") || Slot.Equals("Slot3") || (Slot.Equals("Slot6") || Slot.Equals("Slot9")) || Slot.Equals("Slot11"))
        {
          if (SType.Equals("M") && SType.Equals(vType))
          {
            this.SC.LoadIniFile(this.path + this.GarageNum + "//" + Slot + ".ini");
            this.SC.VehicleName = Name;
            this.SC.Config.SetValue<string>("Configurations", "VehicleName", this.SC.VehicleName);
            this.SC.Config.Save();
            Game.Player.Money -= (int) Price;
            this.DestoryCars();
            this.CreateCars("Hanger1");
          }
          else
            UI.Notify(this.GetHostName() + " Vehicle Size and Slot Size have to match! to purchase Vehicle in this Slot");
        }
        if (!Slot.Equals("Slot1"))
          return;
        if (SType.Equals("L") && SType.Equals(vType))
        {
          this.SC.LoadIniFile(this.path + this.GarageNum + "//" + Slot + ".ini");
          this.SC.VehicleName = Name;
          this.SC.Config.SetValue<string>("Configurations", "VehicleName", this.SC.VehicleName);
          this.SC.Config.Save();
          Game.Player.Money -= (int) Price;
          this.DestoryCars();
          this.CreateCars("Hanger1");
        }
        else
          UI.Notify(this.GetHostName() + " Vehicle Size and Slot Size have to match! to purchase Vehicle in this Slot");
      }
      else
        UI.Notify(this.GetHostName() + " You do not have enough Money to purchase this Aircraft");
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if (this.BlipItem_SetupMission != (Blip) null)
        this.BlipItem_SetupMission.Remove();
      foreach (Hanger.Flare flare in this.SellPointsSmoke)
      {
        if ((Entity) flare.FlareProp != (Entity) null)
        {
          Function.Call(Hash._0x8F75998877616996, (InputArgument) flare.FlareID_1, (InputArgument) false);
          flare.FlareProp.Delete();
        }
      }
      foreach (Hanger.Flare flare in this.Cargo)
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
      if (this.Hanger1 != (Blip) null)
        this.Hanger1.Remove();
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
      if ((Entity) this.Car1 != (Entity) null)
        this.Car1.Delete();
      if ((Entity) this.Car2 != (Entity) null)
        this.Car2.Delete();
      if ((Entity) this.Car3 != (Entity) null)
        this.Car3.Delete();
      if ((Entity) this.Car4 != (Entity) null)
        this.Car4.Delete();
      try
      {
        if (this.Range != (Blip) null)
          this.Range.Remove();
        if ((Entity) this.ExChair != (Entity) null)
          this.ExChair.Delete();
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
      foreach (Vehicle aiPlane in this.AIPlanes)
      {
        if ((Entity) aiPlane != (Entity) null)
          aiPlane.Delete();
      }
      foreach (Blip planeBlip in this.PlaneBlips)
      {
        if (planeBlip != (Blip) null)
          planeBlip.Remove();
      }
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if ((Entity) this.Aircraft != (Entity) null)
        this.Aircraft.Delete();
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
      if ((Entity) this.Plane != (Entity) null)
      {
        if ((Entity) this.Plane.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
          this.Plane.GetPedOnSeat(VehicleSeat.Driver).Delete();
        this.Plane.Delete();
      }
      foreach (Ped ped in this.Peds)
      {
        if (ped.CurrentBlip != (Blip) null)
          ped.CurrentBlip.Remove();
      }
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if (this.Cam != (Camera) null)
      {
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        this.Cam.IsActive = false;
        this.Cam.Destroy();
        Game.Player.Character.FreezePosition = false;
        Game.Player.Character.IsVisible = true;
      }
      if (this.Hanger1 != (Blip) null)
        this.Hanger1.Remove();
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
      if ((Entity) this.Car1 != (Entity) null)
        this.Car1.Delete();
      if ((Entity) this.Car2 != (Entity) null)
        this.Car2.Delete();
      if ((Entity) this.Car3 != (Entity) null)
        this.Car3.Delete();
      if (!((Entity) this.Car4 != (Entity) null))
        return;
      this.Car4.Delete();
    }

    public void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public void SaveCarInSlot(string Slot)
    {
      this.SC.LoadIniFile(this.path2 + "Garage1//" + Slot + ".ini");
      this.SC.SaveWithoutDelete();
      UI.Notify(this.GetHostName() + " Vehicle Saved!");
    }

    public void SaveCurrentVehicleInSlot(string Slot)
    {
      this.SC.LoadIniFile(this.path + this.GarageNum + "//" + Slot + ".ini");
      this.SC.SaveWithoutDelete();
      UI.Notify(this.GetHostName() + " Vehicle Saved!");
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
          if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Hanger.\u003C\u003Eo__415.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p1 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Hanger.\u003C\u003Eo__415.\u003C\u003Ep__0 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__0.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__0, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
          if (target1((CallSite) p1, obj1))
          {
            Components.Clear();
            // ISSUE: reference to a compiler-generated field
            if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Hanger.\u003C\u003Eo__415.\u003C\u003Ep__2 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Hanger.\u003C\u003Eo__415.\u003C\u003Ep__2.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__2, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
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
          if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Hanger.\u003C\u003Eo__415.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target2 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__4.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p4 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__4;
          // ISSUE: reference to a compiler-generated field
          if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Hanger.\u003C\u003Eo__415.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__3.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__3, Components[C.Index]);
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
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p6 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__5.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__5, Components[C.Index]);
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
          if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Hanger.\u003C\u003Eo__415.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Hanger)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target1 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p8 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Hanger.\u003C\u003Eo__415.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__7.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__7, Components[C.Index]);
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
            if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Hanger.\u003C\u003Eo__415.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, bool> target2 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__10.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, bool>> p10 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__10;
            // ISSUE: reference to a compiler-generated field
            if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__9 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Hanger.\u003C\u003Eo__415.\u003C\u003Ep__9 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__9.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__9, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
            if (target2((CallSite) p10, obj2))
            {
              if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) W.IndexToItem(W.Index).GetHashCode(), (InputArgument) C.IndexToItem(C.Index).GetHashCode()))
              {
                // ISSUE: reference to a compiler-generated field
                if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__11 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  Hanger.\u003C\u003Eo__415.\u003C\u003Ep__11 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Hanger.\u003C\u003Eo__415.\u003C\u003Ep__11.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__11, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
                // ISSUE: reference to a compiler-generated field
                if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__12 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  Hanger.\u003C\u003Eo__415.\u003C\u003Ep__12 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Hanger.\u003C\u003Eo__415.\u003C\u003Ep__12.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__12, Game.Player.Character.Weapons.Current, Components[C.Index], true);
              }
            }
          }
        }
        if (item != DIsable)
          return;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__14.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p14 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__14;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__13 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__13.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__13, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
        if (!target3((CallSite) p14, obj3))
          return;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__19 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target4 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__19.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p19 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__19;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__18 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool, object> target5 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__18.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool, object>> p18 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__18;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__17 = CallSite<Func<CallSite, System.Type, Hash, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Call", (IEnumerable<System.Type>) new System.Type[1]
          {
            typeof (bool)
          }, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, System.Type, Hash, object, object, object> target6 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__17.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, System.Type, Hash, object, object, object>> p17 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__17;
        System.Type type = typeof (Function);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__15 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__15.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__15, Mk2Weapons[W.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__16 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj5 = Hanger.\u003C\u003Eo__415.\u003C\u003Ep__16.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__16, Components[C.Index]);
        object obj6 = target6((CallSite) p17, type, Hash._0x5CEE3DF569CECAB0, obj4, obj5);
        object obj7 = target5((CallSite) p18, obj6, true);
        if (!target4((CallSite) p19, obj7))
          return;
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__20 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Hanger.\u003C\u003Eo__415.\u003C\u003Ep__20.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__20, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
        // ISSUE: reference to a compiler-generated field
        if (Hanger.\u003C\u003Eo__415.\u003C\u003Ep__21 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Hanger.\u003C\u003Eo__415.\u003C\u003Ep__21 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (Hanger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Hanger.\u003C\u003Eo__415.\u003C\u003Ep__21.Target((CallSite) Hanger.\u003C\u003Eo__415.\u003C\u003Ep__21, Game.Player.Character.Weapons.Current, Components[C.Index], false);
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

    public void DrawTexture(string File)
    {
      int num = Game.ScreenResolution.Width;
      string str1 = num.ToString();
      num = Game.ScreenResolution.Height;
      string str2 = num.ToString();
      UI.Notify(str1 + "/" + str2);
      UI.DrawTexture(File, 0, 0, 100, new Point(800, 200), new Size(900, 600), 0.0f, Color.White);
    }

    private void SetColor(int particle, float r, float g, float b, bool p1) => Function.Call(Hash._0x7F8F65877F88783B, (InputArgument) particle, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) p1);

    private void SetRange(int handle, float range) => Function.Call(Hash._0xDCB194B85EF7B541, (InputArgument) handle, (InputArgument) range);

    private int GetBoneByName(Entity entity, string name) => Function.Call<int>(Hash._0xFB71170B7E76ACBA, (InputArgument) entity, (InputArgument) name);

    public static Vector3 GenerateSpawnPos(
      Vector3 desiredPos,
      Hanger.Nodetype roadtype,
      bool sidewalk)
    {
      Vector3 zero = Vector3.Zero;
      bool flag = false;
      OutputArgument outputArgument = new OutputArgument();
      int num1 = 1;
      int num2 = 0;
      if (roadtype == Hanger.Nodetype.AnyRoad)
        num2 = 1;
      if (roadtype == Hanger.Nodetype.Road)
        num2 = 0;
      if (roadtype == Hanger.Nodetype.Offroad)
      {
        num2 = 1;
        flag = true;
      }
      if (roadtype == Hanger.Nodetype.Water)
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
      this.SmokePropaParticles.Add(new Hanger.Flare(prop, num, true));
    }

    public void CreateSmoke_SellMission(Hanger.Flare X)
    {
      Vector3 location = X.Location;
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
      X.Created = true;
      Prop prop = World.CreateProp(this.RequestModel("prop_flare_01b"), X.Location, false, false);
      X.FlareProp = prop;
      this.SupplyMissionProps.Add(prop);
      int num = Function.Call<int>(Hash._0xE184F4F0DC5910E7, (InputArgument) "scr_crate_drop_flare", (InputArgument) X.Location.X, (InputArgument) X.Location.Y, (InputArgument) X.Location.Z, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 5f, (InputArgument) false, (InputArgument) false, (InputArgument) false, (InputArgument) false);
      this.SetRange(num, 100000f);
      this.SetColor(num, (float) byte.MaxValue, 0.0f, 0.0f, true);
      X.FlareID_1 = num;
      this.SmokeParticles.Add(num);
    }

    public void DrawStockBar(string Name, float X, float Y, float CrntValue, float MaxValue)
    {
      this.drawSprite2("timerbars", "all_black_bg", X, Y, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.drawSprite2("timerbars", "all_black_bg", X - 0.1f, Y, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.drawSprite2("timerbars", "damagebarfill_128", X + 0.05f, Y, 0.08f, 0.03f, (int) this.MarkerColor.R, (int) this.MarkerColor.G, (int) this.MarkerColor.B, 130);
      this.drawSprite2("timerbars", "damagebarfill_128", this.progressxcoord(CrntValue / MaxValue), Y, this.progresswidth(CrntValue / MaxValue), 0.03f, (int) this.MarkerColor.R, (int) this.MarkerColor.G, (int) this.MarkerColor.B, (int) byte.MaxValue);
      this.drawSprite2("timerbar_lines", "LineMarker20_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, (int) byte.MaxValue);
      this.drawSprite2("timerbar_lines", "LineMarker40_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, (int) byte.MaxValue);
      this.drawSprite2("timerbar_lines", "LineMarker60_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, (int) byte.MaxValue);
      this.drawSprite2("timerbar_lines", "LineMarker80_128", X + 0.05f, Y, 0.08f, 0.03f, 0, 0, 0, (int) byte.MaxValue);
      this.drawText(Name, X - 0.1f, Y - 0.016f, 0.3f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
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
      Hanger.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Hangar Cargo Raid", "Our Hangar is Under attack, we cannot afford to lose cargo!");
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

    public void FailSourceMission(string Reason)
    {
      foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
      {
        if ((Entity) supplyMissionVehicle != (Entity) null)
          supplyMissionVehicle.MarkAsNoLongerNeeded();
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
          supplyMissionPed.MarkAsNoLongerNeeded();
      }
      if (this.SupplyMissionBlips.Count > 0)
        this.SupplyMissionBlips.Clear();
      if (this.SupplyMissionPeds.Count > 0)
        this.SupplyMissionPeds.Clear();
      if (this.SupplyMissionVehicles.Count > 0)
        this.SupplyMissionVehicles.Clear();
      if (this.SupplyMissionProps.Count > 0)
        this.SupplyMissionProps.Clear();
      if (this.DeliverPointBlip != (Blip) null)
        this.DeliverPointBlip.Remove();
      new MissionScreen().SetFail("Sourcing Crates", 360000, Reason);
      this.Config.Save();
      this.SupplyMissionID = 0;
      this.SupplyMissionOn = false;
    }

    public void SaveThreeCrate(int Warehouse, string Crate1, string Crate2, string Crate3)
    {
      if ((Entity) this.SourceVehicle1 != (Entity) null)
      {
        if (this.SourceVehicle1.CurrentBlip != (Blip) null)
          this.SourceVehicle1.CurrentBlip.Remove();
        this.SourceVehicle1.MarkAsNoLongerNeeded();
      }
      int crateProp1 = this.GetCrateProp(Crate1);
      int crateProp2 = this.GetCrateProp(Crate2);
      int crateProp3 = this.GetCrateProp(Crate3);
      int num = 3;
      for (int index = 1; index < 51; ++index)
      {
        int defaultvalue = -1;
        if (this.Config.GetValue<int>("FREETRADESHIPPING_CRATES", "CRATEID_" + index.ToString(), defaultvalue) == -1)
        {
          switch (num)
          {
            case 1:
              this.Config.SetValue<int>("FREETRADESHIPPING_CRATES", "CRATEID_" + index.ToString(), this.GetCrateProp(Crate3));
              this.Config.Save();
              --num;
              goto label_12;
            case 2:
              this.Config.SetValue<int>("FREETRADESHIPPING_CRATES", "CRATEID_" + index.ToString(), this.GetCrateProp(Crate2));
              this.Config.Save();
              --num;
              continue;
            case 3:
              this.Config.SetValue<int>("FREETRADESHIPPING_CRATES", "CRATEID_" + index.ToString(), this.GetCrateProp(Crate1));
              this.Config.Save();
              --num;
              continue;
            default:
              continue;
          }
        }
      }
label_12:
      ++this.SMG_RivalCratesStolen;
      this.Config.SetValue<int>("FreeTradeShipping", "RivalCratesStolen", this.SMG_RivalCratesStolen);
      this.Config.Save();
      if (crateProp3 == 0 && this.SMG_ArtaAntiques_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_ArtaAntiques_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
        this.Config.Save();
      }
      if (crateProp3 == 1 && this.SMG_AnimalMaterials_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_AnimalMaterials_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
        this.Config.Save();
      }
      if (crateProp3 == 2 && this.SMG_CounterfeitGoods_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_CounterfeitGoods_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
        this.Config.Save();
      }
      if (crateProp3 == 3 && this.SMG_Chemicals_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_Chemicals_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
        this.Config.Save();
      }
      if (crateProp3 == 4 && this.SMG_JewelryaGemstones_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_JewelryaGemstones_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
        this.Config.Save();
      }
      if (crateProp3 == 5 && this.SMG_MedicalSupplies_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_MedicalSupplies_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
        this.Config.Save();
      }
      if (crateProp3 == 6 && this.SMG_Narcotics_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_Narcotics_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
        this.Config.Save();
      }
      if (crateProp3 == 7 && this.SMG_TabaccoaAlcohol_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_TabaccoaAlcohol_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
        this.Config.Save();
      }
      if (crateProp2 == 0 && this.SMG_ArtaAntiques_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_ArtaAntiques_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
        this.Config.Save();
      }
      if (crateProp2 == 1 && this.SMG_AnimalMaterials_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_AnimalMaterials_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
        this.Config.Save();
      }
      if (crateProp2 == 2 && this.SMG_CounterfeitGoods_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_CounterfeitGoods_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
        this.Config.Save();
      }
      if (crateProp2 == 3 && this.SMG_Chemicals_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_Chemicals_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
        this.Config.Save();
      }
      if (crateProp2 == 4 && this.SMG_JewelryaGemstones_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_JewelryaGemstones_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
        this.Config.Save();
      }
      if (crateProp2 == 5 && this.SMG_MedicalSupplies_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_MedicalSupplies_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
        this.Config.Save();
      }
      if (crateProp2 == 6 && this.SMG_Narcotics_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_Narcotics_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
        this.Config.Save();
      }
      if (crateProp2 == 7 && this.SMG_TabaccoaAlcohol_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_TabaccoaAlcohol_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
        this.Config.Save();
      }
      if (crateProp1 == 0 && this.SMG_ArtaAntiques_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_ArtaAntiques_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
        this.Config.Save();
      }
      if (crateProp1 == 1 && this.SMG_AnimalMaterials_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_AnimalMaterials_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
        this.Config.Save();
      }
      if (crateProp1 == 2 && this.SMG_CounterfeitGoods_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_CounterfeitGoods_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
        this.Config.Save();
      }
      if (crateProp1 == 3 && this.SMG_Chemicals_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_Chemicals_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
        this.Config.Save();
      }
      if (crateProp1 == 4 && this.SMG_JewelryaGemstones_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_JewelryaGemstones_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
        this.Config.Save();
      }
      if (crateProp1 == 5 && this.SMG_MedicalSupplies_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_MedicalSupplies_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
        this.Config.Save();
      }
      if (crateProp1 == 6 && this.SMG_Narcotics_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_Narcotics_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
        this.Config.Save();
      }
      if (crateProp1 == 7 && this.SMG_TabaccoaAlcohol_CurrentStock < this.SMG_MaxCratesPerCargo)
      {
        this.SMG_TabaccoaAlcohol_CurrentStock += new System.Random().Next(2, 8);
        this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
        this.Config.Save();
      }
      if (num > 0)
        Hanger.TextNotification("CHAR_LESTER", this.GetHostName(), "Hangar Full of Crates", "Boss, your Hangar is full of crates");
      foreach (Vehicle supplyMissionVehicle in this.SupplyMissionVehicles)
      {
        if ((Entity) supplyMissionVehicle != (Entity) null)
          supplyMissionVehicle.MarkAsNoLongerNeeded();
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
          supplyMissionPed.MarkAsNoLongerNeeded();
      }
      if (this.SupplyMissionBlips.Count > 0)
        this.SupplyMissionBlips.Clear();
      if (this.SupplyMissionPeds.Count > 0)
        this.SupplyMissionPeds.Clear();
      if (this.SupplyMissionVehicles.Count > 0)
        this.SupplyMissionVehicles.Clear();
      if (this.SupplyMissionProps.Count > 0)
        this.SupplyMissionProps.Clear();
      if (this.DeliverPointBlip != (Blip) null)
        this.DeliverPointBlip.Remove();
      if (this.DeliverPointBlip != (Blip) null)
        this.DeliverPointBlip.Remove();
      new MissionScreen().SetPass("Sourcing Crates", 8000, "");
      this.SupplyMissionID = 0;
      this.SupplyMissionOn = false;
      this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
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

    public void OnTick(object sender, EventArgs e)
    {
      if (this.CargoMissionTimer < Game.GameTime)
      {
        System.Random random = new System.Random();
        int num1 = random.Next(42000, 1025000);
        int num2 = random.Next(0, 100);
        this.CargoMissionTimer = Game.GameTime + num1;
        if (this.MissionWait == 1)
        {
          if (!this.SupplyMissionOn && num2 < 40)
          {
            this.GotCrate1 = false;
            this.DeliveredCrate1 = false;
            Vector3 spawnPos = Hanger.GenerateSpawnPos(new Vector3(-452.3921f, -346.3056f, 34.36f).Around((float) random.Next(5, 3500)), Hanger.Nodetype.AnyRoad, false);
            this.SourceVehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.Flatbed), spawnPos);
            this.SourceVehicle1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
            this.SourceVehicle1.AddBlip();
            this.SourceVehicle1.CurrentBlip.Sprite = BlipSprite.Cargo;
            this.SourceVehicle1.CurrentBlip.Name = "Source Cargo (Smuggler's)";
            this.SourceVehicle1.CurrentBlip.Color = BlipColor.Yellow;
            this.SupplyMissionVehicles.Add(this.SourceVehicle1);
            this.SupplyMissionPeds.Add(this.SourceVehicle1.GetPedOnSeat(VehicleSeat.Driver));
            Vector3 offsetInWorldCoords1 = this.SourceVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
            Vector3 offsetInWorldCoords2 = this.SourceVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
            Vector3 offsetInWorldCoords3 = this.SourceVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
            List<string> stringList = new List<string>();
            stringList.Add("sm_prop_smug_crate_l_antiques");
            stringList.Add("sm_prop_smug_crate_l_bones");
            stringList.Add("sm_prop_smug_crate_l_fake");
            stringList.Add("sm_prop_smug_crate_l_hazard");
            stringList.Add("sm_prop_smug_crate_l_jewellery");
            stringList.Add("sm_prop_smug_crate_l_medical");
            stringList.Add("sm_prop_smug_crate_l_narc");
            stringList.Add("sm_prop_smug_crate_l_tobacco");
            this.Crate1StringID = stringList[random.Next(0, stringList.Count)];
            this.Crate2StringID = stringList[random.Next(0, stringList.Count)];
            this.Crate3StringID = stringList[random.Next(0, stringList.Count)];
            Prop prop1 = World.CreateProp(this.RequestModel(this.Crate1StringID), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.SourceVehicle1.Heading), false, false);
            this.SellStockProp1 = prop1;
            this.SellStockProps.Add(prop1);
            Prop prop2 = World.CreateProp(this.RequestModel(this.Crate2StringID), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.SourceVehicle1.Heading), false, false);
            this.SellStockProp2 = prop2;
            this.SellStockProps.Add(prop2);
            Prop prop3 = World.CreateProp(this.RequestModel(this.Crate3StringID), offsetInWorldCoords3, new Vector3(0.0f, 0.0f, this.SourceVehicle1.Heading), false, false);
            this.SellStockProp3 = prop3;
            this.SellStockProps.Add(prop3);
            this.SellStockProp1.HasCollision = false;
            this.SellStockProp2.HasCollision = false;
            this.SellStockProp3.HasCollision = false;
            this.SupplyMissionProps.Add(this.SellStockProp1);
            this.SupplyMissionProps.Add(this.SellStockProp2);
            this.SupplyMissionProps.Add(this.SellStockProp3);
            foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
            {
              if ((Entity) supplyMissionPed != (Entity) null)
              {
                int num3 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) supplyMissionPed, (InputArgument) num3);
                Function.Call(Hash._0x9F7794730795E019, (InputArgument) supplyMissionPed, (InputArgument) 0, (InputArgument) 0);
                Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) supplyMissionPed, (InputArgument) 1);
                supplyMissionPed.Weapons.Give(WeaponHash.SMG, 9999, true, true);
              }
            }
            Function.Call(Hash._0x480142959D337D00, (InputArgument) this.SourceVehicle1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) this.SourceVehicle1, (InputArgument) 80f, (InputArgument) 786603);
            this.SupplyMissionOn = true;
            this.SupplyMissionID = 7;
            this.SourcingMissionType = 4;
            this.SpecialCargoMissionEndTimer = Game.GameTime + random.Next(172000, 225000);
            Hanger.TextNotification("CHAR_LESTER", this.GetHostName(), "Ambient Crate Mission", "Boss, Weve spotted a vehicle carring some Crates, return it to the Hangar for a reward");
          }
        }
        else
          this.MissionWait = 1;
      }
      if (this.SupplyMissionOn && (this.SupplyMissionID == 6 || this.SupplyMissionID == 7) && this.SpecialCargoMissionEndTimer < Game.GameTime)
      {
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
        {
          this.SupplyMissionOn = false;
          this.SupplyMissionID = 0;
          this.GotCrate1 = false;
          this.DeliveredCrate1 = false;
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
          if (this.DeliverPointBlip != (Blip) null)
            this.DeliverPointBlip.Remove();
          Hanger.TextNotification("CHAR_LESTER", this.GetHostName(), "Special Crate Mission", "Boss, the Cargo Vehicle has vanished");
        }
        if ((Entity) this.SourceVehicle1 != (Entity) null && (Entity) Game.Player.Character.CurrentVehicle != (Entity) this.SourceVehicle1)
        {
          this.SupplyMissionOn = false;
          this.SupplyMissionID = 0;
          this.GotCrate1 = false;
          this.DeliveredCrate1 = false;
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
          if (this.DeliverPointBlip != (Blip) null)
            this.DeliverPointBlip.Remove();
          Hanger.TextNotification("CHAR_LESTER", this.GetHostName(), "Special Crate Mission", "Boss, the Special Cargo Vehicle has vanished");
        }
      }
      if (Game.GameTime > this.NextRaidTimer)
      {
        System.Random random = new System.Random();
        this.NextRaidTimer = Game.GameTime + random.Next(800000, 1395000);
        int num = random.Next(0, 100);
        if (this.RaidCounter == 1)
        {
          if (this.purchaselvl >= 1)
          {
            this.SMG_ValueTotal = this.SMG_Narcotics_Value + this.SMG_Chemicals_Value + this.SMG_MedicalSupplies_Value + this.SMG_AnimalMaterials_Value + this.SMG_ArtaAntiques_Value + this.SMG_JewelryaGemstones_Value + this.SMG_TabaccoaAlcohol_Value + this.SMG_CounterfeitGoods_Value;
            if ((double) this.SMG_ValueTotal >= 100000.0 && num < 15)
              this.SetupRaid(1);
          }
        }
        else
          this.RaidCounter = 1;
      }
      if (this.IsInInterior)
      {
        Vector3 position = Game.Player.Character.Position;
        if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) != 0)
        {
          if (Game.Player.Character.Weapons.Current != null && Game.Player.Character.Weapons.Current.Hash != WeaponHash.Unarmed)
          {
            this.DisplayHelpTextThisFrame("You cannot use weapons while inside your Hangar");
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed, true);
          }
          if (Game.IsControlPressed(2, GTA.Control.SelectWeapon))
          {
            Game.DisableControlThisFrame(2, GTA.Control.SelectWeapon);
            this.DisplayHelpTextThisFrame("You cannot use weapons while inside your Hangar");
          }
        }
      }
      if (!this.Firsttime)
      {
        this.Firsttime = true;
        foreach (Vector3 sellPoint in this.SellPoints)
          this.SellPointsSmoke.Add(new Hanger.Flare(sellPoint, false));
      }
      if (this.IsInInterior)
      {
        this.DrawStockBar("Narcotics            ", 0.89f, 0.76f, (float) this.SMG_Narcotics_CurrentStock, (float) this.SMG_MaxCratesPerCargo);
        this.DrawStockBar("Chemicals            ", 0.89f, 0.79f, (float) this.SMG_Chemicals_CurrentStock, (float) this.SMG_MaxCratesPerCargo);
        this.DrawStockBar("Medical Supplies     ", 0.89f, 0.82f, (float) this.SMG_MedicalSupplies_CurrentStock, (float) this.SMG_MaxCratesPerCargo);
        this.DrawStockBar("Animal Materials     ", 0.89f, 0.85f, (float) this.SMG_AnimalMaterials_CurrentStock, (float) this.SMG_MaxCratesPerCargo);
        this.DrawStockBar("Art & Antiques       ", 0.89f, 0.88f, (float) this.SMG_ArtaAntiques_CurrentStock, (float) this.SMG_MaxCratesPerCargo);
        this.DrawStockBar("Jewelry & Gemstones  ", 0.89f, 0.91f, (float) this.SMG_JewelryaGemstones_CurrentStock, (float) this.SMG_MaxCratesPerCargo);
        this.DrawStockBar("Tobacco & Alcohol    ", 0.89f, 0.94f, (float) this.SMG_TabaccoaAlcohol_CurrentStock, (float) this.SMG_MaxCratesPerCargo);
        this.DrawStockBar("Counterfeit Goods    ", 0.89f, 0.97f, (float) this.SMG_CounterfeitGoods_CurrentStock, (float) this.SMG_MaxCratesPerCargo);
      }
      if (this.Firsttime && this.SellPointsSmoke.Count > 0)
      {
        foreach (Hanger.Flare X in this.SellPointsSmoke)
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
      if (this.SupplyMissionOn)
      {
        if (this.SupplyMissionID == 100)
        {
          Game.Player.WantedLevel = 0;
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
                  new MissionScreen().SetPass("Smuggler's Run Hangar Raid", 550000, "The Player did not respond to the raid");
                  this.DisplayHelpTextThisFrame(this.GetHostName() + " Good job boss, you just prevented a raid!");
                  UI.Notify(this.GetHostName() + " Good job boss, you just prevented a raid!");
                }
                if ((double) this.SpawnAttackerTimer != 0.0)
                  this.SpawnAttackerTimer -= 0.75f;
                if ((double) this.SpawnAttackerTimer <= 0.0)
                {
                  System.Random random1 = new System.Random();
                  this.SpawnAttackerTimer = (float) random1.Next(100, 300);
                  Vector3 position1;
                  if (this.RaidEnemyTime == 1)
                  {
                    if (random1.Next(1, 100) < 25)
                    {
                      System.Random random2 = new System.Random();
                      System.Random random3 = new System.Random();
                      Model model = (Model) VehicleHash.Chino2;
                      position1 = Game.Player.Character.Position;
                      Vector3 position2 = position1.Around((float) random1.Next(100, 500));
                      Vehicle vehicle = World.CreateVehicle(model, position2);
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
                      Model model = (Model) VehicleHash.Faction2;
                      position1 = Game.Player.Character.Position;
                      Vector3 position2 = position1.Around((float) random1.Next(100, 500));
                      Vehicle vehicle = World.CreateVehicle(model, position2);
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
                      Model model = (Model) VehicleHash.Buccaneer2;
                      position1 = Game.Player.Character.Position;
                      Vector3 position2 = position1.Around((float) random1.Next(100, 500));
                      Vehicle vehicle = World.CreateVehicle(model, position2);
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
                      Model model = (Model) VehicleHash.Moonbeam2;
                      position1 = Game.Player.Character.Position;
                      Vector3 position2 = position1.Around((float) random1.Next(100, 500));
                      Vehicle vehicle = World.CreateVehicle(model, position2);
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
                      Model model = (Model) VehicleHash.Police;
                      position1 = Game.Player.Character.Position;
                      Vector3 position2 = position1.Around((float) random1.Next(100, 500));
                      Vehicle vehicle = World.CreateVehicle(model, position2);
                      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) vehicle.Handle, (InputArgument) 0);
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
                      Model model = (Model) VehicleHash.Police3;
                      position1 = Game.Player.Character.Position;
                      Vector3 position2 = position1.Around((float) random1.Next(100, 500));
                      Vehicle vehicle = World.CreateVehicle(model, position2);
                      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) vehicle.Handle, (InputArgument) 0);
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
                      Model model = (Model) VehicleHash.Police4;
                      position1 = Game.Player.Character.Position;
                      Vector3 position2 = position1.Around((float) random1.Next(100, 500));
                      Vehicle vehicle = World.CreateVehicle(model, position2);
                      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) vehicle.Handle, (InputArgument) 0);
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
                      Model model = (Model) VehicleHash.PoliceT;
                      position1 = Game.Player.Character.Position;
                      Vector3 position2 = position1.Around((float) random1.Next(100, 500));
                      Vehicle vehicle = World.CreateVehicle(model, position2);
                      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) vehicle.Handle, (InputArgument) 0);
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
              if (this.BlipItem_SetupMission != (Blip) null)
                this.BlipItem_SetupMission.Remove();
              this.NextHour = -1;
              this.SupplyMissionOn = false;
              this.SupplyMissionID = 0;
              this.SupplyMissionOn = false;
              new MissionScreen().SetFail("Smuggler's Run Hangar Raid", 0, "The Player did not respond to the raid");
              Hanger.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Smuggler's Run Hangar", "Raid Failed, We've lost all supplies!");
              this.NextHour = -1;
              this.SMG_AnimalMaterials_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
              this.Config.Save();
              this.SMG_ArtaAntiques_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
              this.Config.Save();
              this.SMG_Chemicals_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
              this.Config.Save();
              this.SMG_CounterfeitGoods_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
              this.Config.Save();
              this.SMG_JewelryaGemstones_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
              this.Config.Save();
              this.SMG_MedicalSupplies_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
              this.Config.Save();
              this.SMG_Narcotics_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
              this.Config.Save();
              this.SMG_TabaccoaAlcohol_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
              this.Config.Save();
              for (int index = 1; index < 51; ++index)
              {
                int num = -1;
                this.Config.SetValue<int>("FREETRADESHIPPING_CRATES", "CRATEID_" + index.ToString(), num);
                this.Config.Save();
              }
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
                Hanger.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Smuggler's Run Hangar", "A Raid has been started, kill all enemies to complete the raid");
              }
            }
            else
            {
              this.SupplyMissionID = 0;
              this.SupplyMissionOn = false;
              new MissionScreen().SetFail("Smuggler's Run Hangar Raid", 0, "The Player did not respond to the raid");
              Hanger.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Smuggler's Run Hangar", "Raid Failed, We've lost all supplies!");
              this.NextHour = -1;
              this.SMG_AnimalMaterials_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
              this.Config.Save();
              this.SMG_ArtaAntiques_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
              this.Config.Save();
              this.SMG_Chemicals_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
              this.Config.Save();
              this.SMG_CounterfeitGoods_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
              this.Config.Save();
              this.SMG_JewelryaGemstones_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
              this.Config.Save();
              this.SMG_MedicalSupplies_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
              this.Config.Save();
              this.SMG_Narcotics_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
              this.Config.Save();
              this.SMG_TabaccoaAlcohol_CurrentStock = 0;
              this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
              this.Config.Save();
              for (int index = 1; index < 51; ++index)
              {
                int num = -1;
                this.Config.SetValue<int>("FREETRADESHIPPING_CRATES", "CRATEID_" + index.ToString(), num);
                this.Config.Save();
              }
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
          if (this.SupplyMissionID == 7)
          {
            if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (Entity) Game.Player.Character.CurrentVehicle == (Entity) this.SourceVehicle1)
              UI.ShowSubtitle("Deliver the ~y~Crate Vehicle~w~ to the~y~ Hangar");
            if (this.SourcingMissionType == 4)
            {
              if ((Entity) this.SourceVehicle1 != (Entity) null)
              {
                if (!this.SourceVehicle1.IsAlive && (Entity) this.SourceVehicle1 != (Entity) null && this.SourceVehicle1.Exists())
                  this.FailSourceMission("A Vehicle was Destroyed");
                if (!this.GotCrate1 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (Entity) Game.Player.Character.CurrentVehicle == (Entity) this.SourceVehicle1)
                {
                  this.GotCrate1 = true;
                  if (this.SourcingMissionType == 2)
                    Game.Player.WantedLevel = 3;
                  UI.Notify(this.GetHostName() + " : That is the Vehicle carrying the Crates, return it to the Hangar ");
                  if (!this.CreatedDeliverPoint)
                    this.CreatedDeliverPoint = true;
                }
                if (this.GotCrate1 && !this.DeliveredCrate1 && (double) World.GetDistance(this.SourceVehicle1.Position, this.Entry) < 15.0)
                {
                  this.DeliveredCrate1 = true;
                  this.CreatedDeliverPoint = false;
                  if (this.DeliverPointBlip != (Blip) null)
                    this.DeliverPointBlip.Remove();
                  UI.Notify(this.GetHostName() + " : Thats all we need, successfully completed a source Crate mission");
                  Game.Player.Character.Task.LeaveVehicle(this.SourceVehicle1, true);
                  this.SourceVehicle1.LockStatus = VehicleLockStatus.Locked;
                  this.SourceVehicle1.Speed = 0.0f;
                  if (this.SourceVehicle1.CurrentBlip != (Blip) null)
                    this.SourceVehicle1.CurrentBlip.Remove();
                  this.SourceVehicle1.MarkAsNoLongerNeeded();
                  this.SourceVehicle1 = (Vehicle) null;
                  this.SaveThreeCrate(1, this.Crate1StringID, this.Crate2StringID, this.Crate3StringID);
                  this.SupplyMissionOn = false;
                  this.SupplyMissionStage = 0;
                  this.SupplyMissionType = 0;
                }
              }
              if ((Entity) this.SourceVehicle1 == (Entity) null)
              {
                if ((Entity) this.SellStockProp1 != (Entity) null)
                {
                  this.SellStockProp1.IsVisible = false;
                  this.SellStockProp1.HasCollision = false;
                }
                if ((Entity) this.SellStockProp2 != (Entity) null)
                {
                  this.SellStockProp2.IsVisible = false;
                  this.SellStockProp2.HasCollision = false;
                }
                if ((Entity) this.SellStockProp3 != (Entity) null)
                {
                  this.SellStockProp3.IsVisible = false;
                  this.SellStockProp3.HasCollision = false;
                }
              }
              if ((Entity) this.SourceVehicle1 != (Entity) null && this.SourceVehicle1.IsAlive && this.SourceVehicle1.Model == (Model) VehicleHash.Flatbed)
              {
                Vector3 offsetInWorldCoords1 = this.SourceVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, 0.5f));
                Vector3 offsetInWorldCoords2 = this.SourceVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -2.25f, 0.5f));
                Vector3 offsetInWorldCoords3 = this.SourceVehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                this.SellStockProp1.Position = offsetInWorldCoords1;
                this.SellStockProp1.Rotation = new Vector3(this.SourceVehicle1.Rotation.X, this.SourceVehicle1.Rotation.Y, this.SourceVehicle1.Heading);
                this.SellStockProp2.Position = offsetInWorldCoords2;
                this.SellStockProp2.Rotation = new Vector3(this.SourceVehicle1.Rotation.X, this.SourceVehicle1.Rotation.Y, this.SourceVehicle1.Heading);
                this.SellStockProp3.Position = offsetInWorldCoords3;
                this.SellStockProp3.Rotation = new Vector3(this.SourceVehicle1.Rotation.X, this.SourceVehicle1.Rotation.Y, this.SourceVehicle1.Heading);
              }
            }
          }
          if (this.SupplyMissionID == 1)
          {
            if (this.SupplyMissionStage == 1)
            {
              if ((double) World.GetDistance(Game.Player.Character.Position, this.AreaOffset) > 250.0)
                UI.ShowSubtitle("Go to the Marked ~y~Location~w~");
              if ((double) World.GetDistance(Game.Player.Character.Position, this.AreaOffset) < 1250.0)
              {
                this.SupplyMissionStage = 2;
                this.CreateSmoke(this.AreaOffset);
              }
            }
            if (this.SupplyMissionStage == 2)
            {
              if ((double) World.GetDistance(Game.Player.Character.Position, this.AreaOffset) > 250.0)
                UI.ShowSubtitle("Go to the Marked ~y~Location~w~");
              if ((double) World.GetDistance(Game.Player.Character.Position, this.AreaOffset) < 250.0)
              {
                foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                {
                  if (supplyMissionBlip != (Blip) null)
                    supplyMissionBlip.Remove();
                }
                System.Random random = new System.Random();
                for (int index = 0; index < 22; ++index)
                {
                  int num1 = random.Next(0, 100);
                  if (num1 > 65)
                  {
                    Vehicle vehicle = World.CreateVehicle(this.RequestModel(this.EnemyVehiclehashes[random.Next(0, this.EnemyVehiclehashes.Count)]), this.AreaOffset.Around((float) random.Next(2, 25)));
                    vehicle.Heading = (float) random.Next(0, 360);
                    this.SupplyMissionVehicles.Add(vehicle);
                  }
                  if (num1 < 65)
                  {
                    Ped ped = World.CreatePed(this.RequestModel(this.EnemyPedhashes[random.Next(0, this.EnemyPedhashes.Count)]), this.AreaOffset.Around((float) random.Next(2, 25)));
                    this.SupplyMissionPeds.Add(ped);
                    int num2 = random.Next(0, 300);
                    if (num2 < 50)
                      ped.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
                    if (num2 > 50 && num2 < 100)
                      ped.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
                    if (num2 > 100 && num2 < 150)
                      ped.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
                    if (num2 > 150 && num2 < 200)
                      ped.Weapons.Give(WeaponHash.SMG, 9999, true, true);
                    if (num2 > 200 && num2 < 250)
                      ped.Weapons.Give(WeaponHash.DoubleBarrelShotgun, 9999, true, true);
                    if (num2 > 250 && num2 < 300)
                      ped.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
                    int num3 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                    Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num3);
                    Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
                    ped.RelationshipGroup = num3;
                    ped.Task.WanderAround(ped.Position, (float) random.Next(7, 35));
                    ped.AddBlip();
                    ped.CurrentBlip.Sprite = BlipSprite.Enemy;
                    ped.CurrentBlip.Color = BlipColor.Red;
                    ped.CurrentBlip.Scale = 0.5f;
                    ped.CurrentBlip.IsShortRange = true;
                  }
                }
                Vector3 vector3_1 = this.AreaOffset.Around((float) random.Next(0, 40));
                if (this.CrateSelected == 1)
                {
                  for (int index = 0; index < 9; ++index)
                  {
                    if (index == 0)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_narc"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                    else if (random.Next(0, 100) - index * 5 > 35)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_narc"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                  }
                }
                if (this.CrateSelected == 2)
                {
                  for (int index = 0; index < 9; ++index)
                  {
                    if (index == 0)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_hazard"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                    else if (random.Next(0, 100) - index * 5 > 35)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_hazard"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                  }
                }
                if (this.CrateSelected == 3)
                {
                  for (int index = 0; index < 9; ++index)
                  {
                    if (index == 0)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_medical"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                    else if (random.Next(0, 100) - index * 5 > 35)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_medical"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                  }
                }
                if (this.CrateSelected == 4)
                {
                  for (int index = 0; index < 9; ++index)
                  {
                    if (index == 0)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_bones"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                    else if (random.Next(0, 100) - index * 5 > 35)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_bones"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                  }
                }
                if (this.CrateSelected == 5)
                {
                  for (int index = 0; index < 9; ++index)
                  {
                    if (index == 0)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_antiques"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                    else if (random.Next(0, 100) - index * 5 > 35)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_antiques"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                  }
                }
                if (this.CrateSelected == 6)
                {
                  for (int index = 0; index < 9; ++index)
                  {
                    if (index == 0)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_jewellery"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                    else if (random.Next(0, 100) - index * 5 > 35)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_jewellery"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                  }
                }
                if (this.CrateSelected == 7)
                {
                  for (int index = 0; index < 9; ++index)
                  {
                    if (index == 0)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_tobacco"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                    else if (random.Next(0, 100) - index * 5 > 35)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_tobacco"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                  }
                }
                if (this.CrateSelected == 8)
                {
                  for (int index = 0; index < 9; ++index)
                  {
                    if (index == 0)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_fake"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                    else if (random.Next(0, 100) - index * 5 > 35)
                    {
                      Prop prop = World.CreateProp(this.RequestModel("sm_prop_smug_crate_s_fake"), new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z + 50f), false, true);
                      this.SupplyMissionProps.Add(prop);
                      Vector3 vector3_2 = prop.Position.Around((float) random.Next(0, 5));
                      Vector3 position = new Vector3(vector3_2.X, vector3_2.Y, vector3_1.Z + 500f);
                      position = new Vector3(position.X, position.Y, World.GetGroundHeight(position) + 0.25f);
                      prop.Position = position;
                      ++this.CratesToCollect;
                    }
                  }
                }
                this.SupplyMissionStage = 3;
              }
            }
            if (this.SupplyMissionStage == 3)
            {
              if ((double) World.GetDistance(Game.Player.Character.Position, this.AreaOffset) > 450.0)
                UI.ShowSubtitle("Return to the ~y~Marked Location~w~");
              if ((double) World.GetDistance(Game.Player.Character.Position, this.AreaOffset) < 450.0)
              {
                UI.ShowSubtitle("Take out the ~r~Enemies~w~ to find the Cargo");
                bool flag = false;
                foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                {
                  if (supplyMissionPed.IsAlive)
                  {
                    flag = false;
                    break;
                  }
                  if (!supplyMissionPed.IsAlive)
                    flag = true;
                }
                foreach (Ped supplyMissionPed in this.SupplyMissionPeds)
                {
                  if (supplyMissionPed.IsAlive)
                  {
                    if (!supplyMissionPed.IsInCombatAgainst(Game.Player.Character))
                      supplyMissionPed.Alpha = (int) byte.MaxValue;
                    if (supplyMissionPed.IsInCombatAgainst(Game.Player.Character) && supplyMissionPed.Alpha == (int) byte.MaxValue)
                    {
                      supplyMissionPed.Task.FightAgainst(Game.Player.Character);
                      supplyMissionPed.Alpha = 254;
                    }
                  }
                  if (!supplyMissionPed.IsAlive && supplyMissionPed.CurrentBlip != (Blip) null)
                    supplyMissionPed.CurrentBlip.Alpha = 0;
                }
                if (flag)
                {
                  this.SupplyMissionStage = 4;
                  foreach (Entity supplyMissionProp in this.SupplyMissionProps)
                  {
                    Blip blip = World.CreateBlip(supplyMissionProp.Position);
                    blip.Sprite = BlipSprite.Enemy;
                    blip.Color = BlipColor.Green;
                    blip.Name = "Cargo";
                    blip.Alpha = (int) byte.MaxValue;
                    blip.IsShortRange = true;
                    blip.Scale = 0.5f;
                    this.SupplyMissionBlips.Add(blip);
                  }
                }
              }
            }
            if (this.SupplyMissionStage == 4)
            {
              UI.ShowSubtitle("Find the ~g~Cargo~w~");
              foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
              {
                if ((double) World.GetDistance(Game.Player.Character.Position, supplyMissionBlip.Position) < 10.0)
                  supplyMissionBlip.Alpha = (int) byte.MaxValue;
                if ((double) World.GetDistance(Game.Player.Character.Position, supplyMissionBlip.Position) >= 10.0)
                  supplyMissionBlip.Alpha = 0;
              }
              foreach (Prop supplyMissionProp in this.SupplyMissionProps)
              {
                if ((Entity) supplyMissionProp != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, supplyMissionProp.Position) < 1.25 && supplyMissionProp.Alpha == (int) byte.MaxValue)
                {
                  ++this.CratesCollected;
                  supplyMissionProp.Alpha = 0;
                  supplyMissionProp.SetNoCollision((Entity) Game.Player.Character, true);
                  Game.Player.Character.SetNoCollision((Entity) supplyMissionProp, true);
                  supplyMissionProp.HasCollision = true;
                  Audio.SetAudioFlag("LoadMPData", true);
                  Audio.PlaySoundFrontend("LOCAL_PLYR_CASH_COUNTER_COMPLETE", "DLC_HEISTS_GENERAL_FRONTEND_SOUNDS");
                  Audio.SetAudioFlag("LoadMPData", false);
                }
              }
              if (this.CratesCollected >= this.CratesToCollect)
              {
                foreach (Blip supplyMissionBlip in this.SupplyMissionBlips)
                {
                  if (supplyMissionBlip != (Blip) null)
                    supplyMissionBlip.Remove();
                }
                Blip blip = World.CreateBlip(this.Entry);
                blip.Sprite = BlipSprite.Standard;
                blip.Color = BlipColor.Yellow;
                blip.Name = "Return to Hangar";
                blip.Alpha = (int) byte.MaxValue;
                blip.IsShortRange = true;
                this.SupplyMissionBlips.Add(blip);
                this.SupplyMissionStage = 5;
              }
            }
            if (this.SupplyMissionStage == 5)
            {
              UI.ShowSubtitle("Return to the ~y~Hangar~w~");
              if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 10.0)
              {
                List<string> stringList = new List<string>();
                if (this.CrateSelected == 1)
                {
                  if ((this.SMG_Narcotics_CurrentStock += this.CratesCollected) <= this.SMG_MaxCratesPerCargo)
                  {
                    this.SMG_Narcotics_CurrentStock += this.CratesCollected;
                    this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_narc");
                        stringList.Add("sm_prop_smug_crate_m_narc");
                      }
                    }
                  }
                  else
                  {
                    this.SMG_Narcotics_CurrentStock = this.SMG_MaxCratesPerCargo;
                    this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_narc");
                        stringList.Add("sm_prop_smug_crate_m_narc");
                      }
                    }
                  }
                  new MissionScreen().SetPass("Free Trade Shipping Co : Source Cargo", (int) this.SMG_Narcotics_Value * this.CratesCollected, "The Player Died");
                  ++this.SMG_StealsCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
                  this.Config.Save();
                  Script.Wait(6000);
                  this.SupplyMissionStage = 6;
                }
                if (this.CrateSelected == 2)
                {
                  if ((this.SMG_Chemicals_CurrentStock += this.CratesCollected) <= this.SMG_MaxCratesPerCargo)
                  {
                    this.SMG_Chemicals_CurrentStock += this.CratesCollected;
                    this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_hazard");
                        stringList.Add("sm_prop_smug_crate_m_hazard");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  else
                  {
                    this.SMG_Chemicals_CurrentStock = this.SMG_MaxCratesPerCargo;
                    this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_hazard");
                        stringList.Add("sm_prop_smug_crate_m_hazard");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  new MissionScreen().SetPass("Free Trade Shipping Co : Source Cargo", (int) this.SMG_Chemicals_Value * this.CratesCollected, "The Player Died");
                  ++this.SMG_StealsCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
                  this.Config.Save();
                  Script.Wait(6000);
                  this.SupplyMissionStage = 6;
                }
                if (this.CrateSelected == 3)
                {
                  if ((this.SMG_MedicalSupplies_CurrentStock += this.CratesCollected) <= this.SMG_MaxCratesPerCargo)
                  {
                    this.SMG_MedicalSupplies_CurrentStock += this.CratesCollected;
                    this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_medical");
                        stringList.Add("sm_prop_smug_crate_m_medical");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  else
                  {
                    this.SMG_MedicalSupplies_CurrentStock = this.SMG_MaxCratesPerCargo;
                    this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_medical");
                        stringList.Add("sm_prop_smug_crate_m_medical");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  new MissionScreen().SetPass("Free Trade Shipping Co : Source Cargo", (int) this.SMG_MedicalSupplies_Value * this.CratesCollected, "The Player Died");
                  ++this.SMG_StealsCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
                  this.Config.Save();
                  Script.Wait(6000);
                  this.SupplyMissionStage = 6;
                }
                if (this.CrateSelected == 4)
                {
                  if ((this.SMG_AnimalMaterials_CurrentStock += this.CratesCollected) <= this.SMG_MaxCratesPerCargo)
                  {
                    this.SMG_AnimalMaterials_CurrentStock += this.CratesCollected;
                    this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_bones");
                        stringList.Add("sm_prop_smug_crate_m_bones");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  else
                  {
                    this.SMG_AnimalMaterials_CurrentStock = this.SMG_MaxCratesPerCargo;
                    this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_bones");
                        stringList.Add("sm_prop_smug_crate_m_bones");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  new MissionScreen().SetPass("Free Trade Shipping Co : Source Cargo", (int) this.SMG_AnimalMaterials_Value * this.CratesCollected, "The Player Died");
                  ++this.SMG_StealsCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
                  this.Config.Save();
                  Script.Wait(6000);
                  this.SupplyMissionStage = 6;
                }
                if (this.CrateSelected == 5)
                {
                  if ((this.SMG_ArtaAntiques_CurrentStock += this.CratesCollected) <= this.SMG_MaxCratesPerCargo)
                  {
                    this.SMG_ArtaAntiques_CurrentStock += this.CratesCollected;
                    this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_antiques");
                        stringList.Add("sm_prop_smug_crate_m_antiques");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  else
                  {
                    this.SMG_ArtaAntiques_CurrentStock = this.SMG_MaxCratesPerCargo;
                    this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_antiques");
                        stringList.Add("sm_prop_smug_crate_m_antiques");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  new MissionScreen().SetPass("Free Trade Shipping Co : Source Cargo", (int) this.SMG_ArtaAntiques_Value * this.CratesCollected, "The Player Died");
                  ++this.SMG_StealsCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
                  this.Config.Save();
                  Script.Wait(6000);
                  this.SupplyMissionStage = 6;
                }
                if (this.CrateSelected == 6)
                {
                  if ((this.SMG_JewelryaGemstones_CurrentStock += this.CratesCollected) <= this.SMG_MaxCratesPerCargo)
                  {
                    this.SMG_JewelryaGemstones_CurrentStock += this.CratesCollected;
                    this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_jewellery");
                        stringList.Add("sm_prop_smug_crate_m_jewellery");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  else
                  {
                    this.SMG_JewelryaGemstones_CurrentStock = this.SMG_MaxCratesPerCargo;
                    this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_jewellery");
                        stringList.Add("sm_prop_smug_crate_m_jewellery");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  new MissionScreen().SetPass("Free Trade Shipping Co : Source Cargo", (int) this.SMG_JewelryaGemstones_Value * this.CratesCollected, "The Player Died");
                  ++this.SMG_StealsCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
                  this.Config.Save();
                  Script.Wait(6000);
                  this.SupplyMissionStage = 6;
                }
                if (this.CrateSelected == 7)
                {
                  if ((this.SMG_TabaccoaAlcohol_CurrentStock += this.CratesCollected) <= this.SMG_MaxCratesPerCargo)
                  {
                    this.SMG_TabaccoaAlcohol_CurrentStock += this.CratesCollected;
                    this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_tobacco");
                        stringList.Add("sm_prop_smug_crate_m_tobacco");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  else
                  {
                    this.SMG_TabaccoaAlcohol_CurrentStock = this.SMG_MaxCratesPerCargo;
                    this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_tobacco");
                        stringList.Add("sm_prop_smug_crate_m_tobacco");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  new MissionScreen().SetPass("Free Trade Shipping Co : Source Cargo", (int) this.SMG_TabaccoaAlcohol_Value * this.CratesCollected, "The Player Died");
                  ++this.SMG_StealsCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
                  this.Config.Save();
                  Script.Wait(6000);
                  this.SupplyMissionStage = 6;
                }
                if (this.CrateSelected == 8)
                {
                  if ((this.SMG_CounterfeitGoods_CurrentStock += this.CratesCollected) <= this.SMG_MaxCratesPerCargo)
                  {
                    this.SMG_CounterfeitGoods_CurrentStock += this.CratesCollected;
                    this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_fake");
                        stringList.Add("sm_prop_smug_crate_m_fake");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  else
                  {
                    this.SMG_CounterfeitGoods_CurrentStock = this.SMG_MaxCratesPerCargo;
                    this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
                    this.Config.Save();
                    int cratesCollected = this.CratesCollected;
                    for (int index = 1; index < 51; ++index)
                    {
                      this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                      if (this.CrateSpawn == -1)
                      {
                        stringList.Add("sm_prop_smug_crate_l_fake");
                        stringList.Add("sm_prop_smug_crate_m_fake");
                        --cratesCollected;
                        if (cratesCollected > 0)
                        {
                          System.Random random = new System.Random();
                          int crateProp = this.GetCrateProp(stringList[random.Next(0, stringList.Count)]);
                          this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), crateProp);
                          this.Config.Save();
                        }
                      }
                    }
                  }
                  new MissionScreen().SetPass("Free Trade Shipping Co : Source Cargo", (int) this.SMG_CounterfeitGoods_Value * this.CratesCollected, "The Player Died");
                  ++this.SMG_StealsCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "StealsCompleted", this.SMG_StealsCompleted);
                  this.Config.Save();
                  Script.Wait(6000);
                  this.SupplyMissionStage = 6;
                }
              }
            }
            if (this.SupplyMissionStage == 6)
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
              if (this.IsInInterior)
              {
                if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
                  UI.ShowSubtitle("Enter a ~y~Aircraft~w~ with a ~b~Bomb bay~w~");
                if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
                {
                  Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
                  if (currentVehicle.DisplayName == "ALKONOST" || currentVehicle.DisplayName == "STRIKEFORCE" || (currentVehicle.DisplayName == "AVENGER" || currentVehicle.DisplayName == "MOGUL") || (currentVehicle.DisplayName == "AKULA" || currentVehicle.DisplayName == "VOLATOL" || (currentVehicle.DisplayName == "BOMBUSHKA" || currentVehicle.DisplayName == "CUBAN800")) || (currentVehicle.DisplayName == "CUBAN800" || currentVehicle.DisplayName == "ROGUE" || (currentVehicle.DisplayName == "STARLING" || currentVehicle.DisplayName == "SEEBREAZE") || (currentVehicle.DisplayName == "TULA" || currentVehicle.DisplayName == "HUNTER")))
                  {
                    this.SupplyMissionMainVehicle = currentVehicle;
                    UI.ShowSubtitle("Exit with the ~b~" + currentVehicle.FriendlyName + "~w~");
                    this.SupplyMissionStage = 2;
                  }
                  else
                    UI.ShowSubtitle("Enter a ~y~ Aircraft~w~ with a ~b~Bomb bay~w~");
                }
              }
              if (!this.IsInInterior)
                UI.ShowSubtitle("Enter you ~y~Hangar~w~");
            }
            if (this.SupplyMissionStage == 2)
            {
              if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
              {
                Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
                if (currentVehicle.DisplayName == "ALKONOST" || currentVehicle.DisplayName == "STRIKEFORCE" || (currentVehicle.DisplayName == "AVENGER" || currentVehicle.DisplayName == "MOGUL") || (currentVehicle.DisplayName == "AKULA" || currentVehicle.DisplayName == "VOLATOL" || (currentVehicle.DisplayName == "BOMBUSHKA" || currentVehicle.DisplayName == "CUBAN800")) || (currentVehicle.DisplayName == "CUBAN800" || currentVehicle.DisplayName == "ROGUE" || (currentVehicle.DisplayName == "STARLING" || currentVehicle.DisplayName == "SEEBREAZE") || (currentVehicle.DisplayName == "TULA" || currentVehicle.DisplayName == "HUNTER")))
                {
                  if (this.IsInInterior)
                  {
                    this.SupplyMissionMainVehicle = currentVehicle;
                    UI.ShowSubtitle("Exit with ~b~" + currentVehicle.FriendlyName + "~w~");
                    if (Game.IsControlPressed(2, GTA.Control.Context))
                    {
                      foreach (Hanger.Flare flare in this.Cargo)
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
                      float num = 0.0f;
                      if (this.CrateSelected == 1)
                        num = (float) (this.SMG_Narcotics_CurrentStock / this.SMG_MaxCratesPerCargo * 100);
                      if (this.CrateSelected == 2)
                        num = (float) (this.SMG_Chemicals_CurrentStock / this.SMG_MaxCratesPerCargo * 100);
                      if (this.CrateSelected == 3)
                        num = (float) (this.SMG_MedicalSupplies_CurrentStock / this.SMG_MaxCratesPerCargo * 100);
                      if (this.CrateSelected == 4)
                        num = (float) (this.SMG_AnimalMaterials_CurrentStock / this.SMG_MaxCratesPerCargo * 100);
                      if (this.CrateSelected == 5)
                        num = (float) (this.SMG_ArtaAntiques_CurrentStock / this.SMG_MaxCratesPerCargo * 100);
                      if (this.CrateSelected == 6)
                        num = (float) (this.SMG_JewelryaGemstones_CurrentStock / this.SMG_MaxCratesPerCargo * 100);
                      if (this.CrateSelected == 7)
                        num = (float) (this.SMG_TabaccoaAlcohol_CurrentStock / this.SMG_MaxCratesPerCargo * 100);
                      if (this.CrateSelected == 8)
                        num = (float) (this.SMG_CounterfeitGoods_CurrentStock / this.SMG_MaxCratesPerCargo * 100);
                      if (this.CrateSelected == 9)
                        num = (float) ((double) (this.SMG_Narcotics_CurrentStock + this.SMG_Chemicals_CurrentStock + this.SMG_MedicalSupplies_CurrentStock + this.SMG_AnimalMaterials_CurrentStock + this.SMG_ArtaAntiques_CurrentStock + this.SMG_JewelryaGemstones_CurrentStock + this.SMG_TabaccoaAlcohol_CurrentStock + this.SMG_CounterfeitGoods_CurrentStock) / (double) (this.SMG_MaxCratesPerCargo * 8) * 100.0);
                      if (this.CrateSelected != 9)
                      {
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
                      }
                      if (this.CrateSelected == 9)
                      {
                        if ((double) num <= 10.0)
                          this.Selectedpoints = 6;
                        if ((double) num > 10.0 && (double) num <= 25.0)
                          this.Selectedpoints = 9;
                        if ((double) num > 25.0 && (double) num <= 35.0)
                          this.Selectedpoints = 12;
                        if ((double) num > 35.0 && (double) num <= 50.0)
                          this.Selectedpoints = 15;
                        if ((double) num > 50.0 && (double) num <= 65.0)
                          this.Selectedpoints = 18;
                        if ((double) num > 65.0 && (double) num <= 80.0)
                          this.Selectedpoints = 22;
                        if ((double) num > 80.0 && (double) num <= 100.0)
                          this.Selectedpoints = 24;
                      }
                      this.PointstoGoto = this.Selectedpoints;
                      System.Random random = new System.Random();
                      for (int index = 0; index < 1000; ++index)
                      {
                        if (this.Selectedpoints > 0)
                        {
                          Vector3 sellPoint = this.SellPoints[random.Next(0, this.SellPoints.Count)];
                          if (!this.SelectedSellPoints.Contains(sellPoint))
                          {
                            --this.Selectedpoints;
                            this.SelectedSellPoints.Add(sellPoint);
                            Blip blip1 = World.CreateBlip(sellPoint);
                            blip1.Sprite = BlipSprite.Standard;
                            blip1.Color = BlipColor.Yellow;
                            blip1.Name = "Drop Off";
                            blip1.Alpha = (int) byte.MaxValue;
                            blip1.IsShortRange = true;
                            Function.Call(Hash._0x2B6D467DAB714E8D, (InputArgument) blip1, (InputArgument) true);
                            this.SupplyMissionBlips.Add(blip1);
                            Blip blip2 = World.CreateBlip(sellPoint);
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
                  }
                }
                else if ((Entity) this.SupplyMissionMainVehicle.Driver != (Entity) null)
                {
                  if ((Entity) this.SupplyMissionMainVehicle.Driver != (Entity) Game.Player.Character)
                  {
                    this.SupplyMissionStage = 1;
                    UI.ShowSubtitle("Enter a ~y~ Aircraft~w~ with a ~b~Bomb bay~w~");
                  }
                }
                else
                {
                  this.SupplyMissionStage = 1;
                  UI.ShowSubtitle("Enter a ~y~ Aircraft~w~ with a ~b~Bomb bay~w~");
                }
              }
              else if ((Entity) this.SupplyMissionMainVehicle.Driver != (Entity) null)
              {
                if ((Entity) this.SupplyMissionMainVehicle.Driver != (Entity) Game.Player.Character)
                {
                  this.SupplyMissionStage = 1;
                  UI.ShowSubtitle("Enter a ~y~ Aircraft~w~ with a ~b~Bomb bay~w~");
                }
              }
              else
              {
                this.SupplyMissionStage = 1;
                UI.ShowSubtitle("Enter a ~y~ Aircraft~w~ with a ~b~Bomb bay~w~");
              }
            }
            if (this.SupplyMissionStage == 3)
            {
              this.drawSprite2("timerbars", "all_black_bg", 0.89f, 0.97f, 0.21f, 0.04f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 130);
              this.drawText(("TOTAL DELIVERED   " + this.PointsBeenAt.ToString() + "/" + this.PointstoGoto.ToString()).ToString(), 0.82f, 0.961f, 0.4f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              if (this.PointsBeenAt < this.PointstoGoto)
                UI.ShowSubtitle("Deliver the " + this.SMG_Screen2ButtonType[this.CrateSelected - 1] + " to the ~y~drop-offs");
              if (this.PointsBeenAt >= this.PointstoGoto)
              {
                this.SupplyMissionStage = 4;
                UI.ShowSubtitle("Deliver the " + this.SMG_Screen2ButtonType[this.CrateSelected - 1] + " to the ~y~drop-offs");
              }
              if (this.Cargo.Count > 0)
              {
                foreach (Hanger.Flare flare1 in this.Cargo)
                {
                  if (!flare1.Created && (Entity) flare1.FlareProp != (Entity) null)
                  {
                    if ((double) World.GetDistance(flare1.FlareProp.Position, flare1.Location) < 30.0 && (double) flare1.FlareProp.HeightAboveGround < 10.0)
                    {
                      foreach (Hanger.Flare flare2 in this.SellPointsSmoke)
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
                      foreach (Hanger.Flare flare2 in this.SellPointsSmoke)
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
                    this.Cargo.Add(new Hanger.Flare(this.DeliverCrate1, selectedSellPoint, false));
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
              UI.ShowSubtitle("Return the delivery vehicle to the ~y~Hangar");
              if ((double) World.GetDistance(this.SupplyMissionMainVehicle.Position, this.Entry) < 20.0)
              {
                List<string> stringList = new List<string>();
                MissionScreen missionScreen = new MissionScreen();
                float num1 = 0.0f;
                if (this.CrateSelected == 1)
                {
                  num1 = (float) this.SMG_Narcotics_CurrentStock * this.SMG_Narcotics_Value;
                  this.SMG_Narcotics_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_narc") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_narc"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                if (this.CrateSelected == 2)
                {
                  num1 = (float) this.SMG_Chemicals_CurrentStock * this.SMG_Chemicals_Value;
                  this.SMG_Chemicals_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
                  this.Config.Save();
                  int cratesCollected = this.CratesCollected;
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_hazard") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_hazard"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                if (this.CrateSelected == 3)
                {
                  num1 = (float) this.SMG_MedicalSupplies_CurrentStock * this.SMG_MedicalSupplies_Value;
                  this.SMG_MedicalSupplies_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
                  this.Config.Save();
                  int cratesCollected = this.CratesCollected;
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_medical") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_medical"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                if (this.CrateSelected == 4)
                {
                  num1 = (float) this.SMG_AnimalMaterials_CurrentStock * this.SMG_AnimalMaterials_Value;
                  this.SMG_AnimalMaterials_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
                  this.Config.Save();
                  int cratesCollected = this.CratesCollected;
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_bones") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_bones"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                if (this.CrateSelected == 5)
                {
                  num1 = (float) this.SMG_ArtaAntiques_CurrentStock * this.SMG_ArtaAntiques_Value;
                  this.SMG_ArtaAntiques_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
                  this.Config.Save();
                  int cratesCollected = this.CratesCollected;
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_antiques") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_antiques"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                if (this.CrateSelected == 6)
                {
                  num1 = (float) this.SMG_JewelryaGemstones_CurrentStock * this.SMG_JewelryaGemstones_Value;
                  this.SMG_JewelryaGemstones_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
                  this.Config.Save();
                  int cratesCollected = this.CratesCollected;
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_jewellery") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_jewellery"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                if (this.CrateSelected == 7)
                {
                  num1 = (float) this.SMG_TabaccoaAlcohol_CurrentStock * this.SMG_TabaccoaAlcohol_Value;
                  this.SMG_TabaccoaAlcohol_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
                  this.Config.Save();
                  int cratesCollected = this.CratesCollected;
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_tobacco") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_tobacco"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                if (this.CrateSelected == 8)
                {
                  num1 = (float) this.SMG_CounterfeitGoods_CurrentStock * this.SMG_CounterfeitGoods_Value;
                  this.SMG_CounterfeitGoods_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
                  this.Config.Save();
                  int cratesCollected = this.CratesCollected;
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_fake") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_fake"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                if (this.CrateSelected == 9)
                {
                  float num2 = num1 + (float) this.SMG_Narcotics_CurrentStock * this.SMG_Narcotics_Value;
                  this.SMG_Narcotics_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "Narcotics_CurrentStock", this.SMG_Narcotics_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_narc") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_narc"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  float num3 = num2 + (float) this.SMG_Chemicals_CurrentStock * this.SMG_Chemicals_Value;
                  this.SMG_Chemicals_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "Chemicals_CurrentStock", this.SMG_Chemicals_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_hazard") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_hazard"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  float num4 = num3 + (float) this.SMG_MedicalSupplies_CurrentStock * this.SMG_MedicalSupplies_Value;
                  this.SMG_MedicalSupplies_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "MedicalSupplies_CurrentStock", this.SMG_MedicalSupplies_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_medical") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_medical"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  float num5 = num4 + (float) this.SMG_AnimalMaterials_CurrentStock * this.SMG_AnimalMaterials_Value;
                  this.SMG_AnimalMaterials_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "AnimalMaterials_CurrentStock", this.SMG_AnimalMaterials_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_bones") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_bones"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  float num6 = num5 + (float) this.SMG_ArtaAntiques_CurrentStock * this.SMG_ArtaAntiques_Value;
                  this.SMG_ArtaAntiques_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "ArtaAntiques_CurrentStock", this.SMG_ArtaAntiques_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_antiques") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_antiques"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  float num7 = num6 + (float) this.SMG_JewelryaGemstones_CurrentStock * this.SMG_JewelryaGemstones_Value;
                  this.SMG_JewelryaGemstones_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "JewelryaGemstones_CurrentStock", this.SMG_JewelryaGemstones_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_jewellery") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_jewellery"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  float num8 = num7 + (float) this.SMG_TabaccoaAlcohol_CurrentStock * this.SMG_TabaccoaAlcohol_Value;
                  this.SMG_TabaccoaAlcohol_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "TabaccoaAlcohol_CurrentStock", this.SMG_TabaccoaAlcohol_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_tobacco") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_tobacco"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  num1 = num8 + (float) this.SMG_CounterfeitGoods_CurrentStock * this.SMG_CounterfeitGoods_Value;
                  this.SMG_CounterfeitGoods_CurrentStock = 0;
                  this.Config.SetValue<int>("FreeTradeShipping", "CounterfeitGoods_CurrentStock", this.SMG_CounterfeitGoods_CurrentStock);
                  this.Config.Save();
                  for (int index = 1; index < 51; ++index)
                  {
                    this.CrateSpawn = this.Config.GetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), this.CrateSpawn);
                    if (this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_m_fake") || this.CrateSpawn == this.GetCrateProp("sm_prop_smug_crate_l_fake"))
                    {
                      this.Config.SetValue<int>("FreeTradeShipping_Crates", "CRATEID_" + index.ToString(), -1);
                      this.Config.Save();
                    }
                  }
                  ++this.SMG_SalesCompleted;
                  this.Config.SetValue<int>("FreeTradeShipping", "SalesCompleted", this.SMG_SalesCompleted);
                  this.Config.Save();
                }
                float num9 = (float) this.AmttoDeliver / (float) this.PointsBeenAt;
                float num10 = num1 * num9;
                missionScreen.SetPass2("Free Trade Shipping Co : Sell Cargo", (int) num10, this.AmttoDeliver.ToString() + " of " + this.PointsBeenAt.ToString() + " " + this.SMG_Screen2ButtonType[this.CrateSelected - 1] + " delivered");
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
          MissionScreen missionScreen = new MissionScreen();
          if (this.SupplyMissionID == 1)
          {
            ++this.SMG_StealsFailed;
            this.Config.SetValue<int>("FreeTradeShipping", "StealsFailed", this.SMG_StealsFailed);
            this.Config.Save();
            missionScreen.SetFail("Free Trade Shipping Co : Source Cargo", 8000, "The Player Died");
          }
          if (this.SupplyMissionID == 2)
          {
            ++this.SMG_SalesFailed;
            this.Config.SetValue<int>("FreeTradeShipping", "SalesFailed", this.SMG_SalesFailed);
            this.Config.Save();
            missionScreen.SetFail("Free Trade Shipping Co : Sell Cargo", 8000, "The Player Died");
          }
          if (this.SupplyMissionID == 3)
            missionScreen.SetFail("Free Trade Shipping Co : Sell Crates", 8000, "The Player Died");
          this.SupplyMissionStage = 0;
          this.SupplyMissionOn = false;
          this.SupplyMissionID = 0;
        }
      }
      try
      {
        if (this.HangerCargoCrateGUION)
        {
          float num1 = (float) (1.0 + 1.39999997615814 * (double) this.SMG_Narcotics_CurrentStock / 100.0);
          float num2 = (float) (1.0 + 1.39999997615814 * (double) this.SMG_Chemicals_CurrentStock / 100.0);
          float num3 = (float) (1.0 + 1.39999997615814 * (double) this.SMG_MedicalSupplies_CurrentStock / 100.0);
          float num4 = (float) (1.0 + 1.20000004768372 * (double) this.SMG_AnimalMaterials_CurrentStock / 100.0);
          float num5 = (float) (1.0 + 1.20000004768372 * (double) this.SMG_ArtaAntiques_CurrentStock / 100.0);
          double num6 = 1.20000004768372 * (double) this.SMG_JewelryaGemstones_CurrentStock / 100.0;
          float num7 = (float) (1.0 + 1.0 * (double) this.SMG_TabaccoaAlcohol_CurrentStock / 100.0);
          float num8 = (float) (1.0 + 1.0 * (double) this.SMG_CounterfeitGoods_CurrentStock / 100.0);
          this.SMG_CargoTypeBonus = num1 + num2 + num3 + num4 + num5 + num7 + num8;
          this.SMG_Narcotics_Bonus = 1.4f * (float) this.SMG_Narcotics_CurrentStock;
          this.SMG_Narcotics_Value = (float) (17000 * this.SMG_Narcotics_CurrentStock) * this.SMG_SellMultiplier;
          this.SMG_Chemicals_Bonus = 1.4f * (float) this.SMG_Chemicals_CurrentStock;
          this.SMG_Chemicals_Value = (float) (17000 * this.SMG_Chemicals_CurrentStock) * this.SMG_SellMultiplier;
          this.SMG_MedicalSupplies_Bonus = 1.4f * (float) this.SMG_MedicalSupplies_CurrentStock;
          this.SMG_MedicalSupplies_Value = (float) (17000 * this.SMG_MedicalSupplies_CurrentStock) * this.SMG_SellMultiplier;
          this.SMG_AnimalMaterials_Bonus = 1.2f * (float) this.SMG_AnimalMaterials_CurrentStock;
          this.SMG_AnimalMaterials_Value = (float) (16000 * this.SMG_AnimalMaterials_CurrentStock) * this.SMG_SellMultiplier;
          this.SMG_ArtaAntiques_Bonus = 1.2f * (float) this.SMG_ArtaAntiques_CurrentStock;
          this.SMG_ArtaAntiques_Value = (float) (16000 * this.SMG_ArtaAntiques_CurrentStock) * this.SMG_SellMultiplier;
          this.SMG_JewelryaGemstones_Bonus = 1.2f * (float) this.SMG_JewelryaGemstones_CurrentStock;
          this.SMG_JewelryaGemstones_Value = (float) (16000 * this.SMG_JewelryaGemstones_CurrentStock) * this.SMG_SellMultiplier;
          this.SMG_TabaccoaAlcohol_Bonus = 1f * (float) this.SMG_TabaccoaAlcohol_CurrentStock;
          this.SMG_TabaccoaAlcohol_Value = (float) (15000 * this.SMG_TabaccoaAlcohol_CurrentStock) * this.SMG_SellMultiplier;
          this.SMG_CounterfeitGoods_Bonus = 1f * (float) this.SMG_CounterfeitGoods_CurrentStock;
          this.SMG_CounterfeitGoods_Value = (float) (15000 * this.SMG_CounterfeitGoods_CurrentStock) * this.SMG_SellMultiplier;
          this.SMG_MaxCrates = this.SMG_Narcotics_StockMax + this.SMG_Chemicals_StockMax + this.SMG_MedicalSupplies_StockMax + this.SMG_AnimalMaterials_StockMax + this.SMG_ArtaAntiques_StockMax + this.SMG_JewelryaGemstones_StockMax + this.SMG_TabaccoaAlcohol_StockMax + this.SMG_CounterfeitGoods_StockMax;
          this.SMG_CurrentCrates = this.SMG_Narcotics_CurrentStock + this.SMG_Chemicals_CurrentStock + this.SMG_MedicalSupplies_CurrentStock + this.SMG_AnimalMaterials_CurrentStock + this.SMG_ArtaAntiques_CurrentStock + this.SMG_JewelryaGemstones_CurrentStock + this.SMG_TabaccoaAlcohol_CurrentStock + this.SMG_CounterfeitGoods_CurrentStock;
          this.SMG_Name = Game.Player.Name.ToUpper();
          this.SMG_StealSuccessRate = this.SMG_StealsCompleted <= 0 ? 0 : 100 - this.SMG_StealsFailed / this.SMG_StealsCompleted * 100;
          this.SMG_SalesSuccessRate = this.SMG_SalesCompleted <= 0 ? 0 : 100 - this.SMG_SalesFailed / this.SMG_SalesCompleted * 100;
          if (!this.IsSittinginCeoSeat)
          {
            this.Screen = 0.0f;
            this.frame = 0;
            this.GUIOn = false;
            this.GUIscaleform.Unload();
            this.HangerCargoCrateGUION = false;
          }
          if (Game.IsControlJustPressed(2, GTA.Control.FrontendPauseAlternate))
          {
            Prop exChair = this.ExChair;
            int num9 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exChair.Position.X, (InputArgument) exChair.Position.Y, (InputArgument) exChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exChair.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num9, (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num9, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num9));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num9, (InputArgument) "computer_exit", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exChair, (InputArgument) num9, (InputArgument) "computer_exit_chair", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            this.Screen = 0.0f;
            this.frame = 0;
            this.GUIOn = false;
            this.GUIscaleform.Unload();
            this.HangerCargoCrateGUION = false;
          }
          if (this.IsSittinginCeoSeat)
            this.BSmodMenuPool.CloseAllMenus();
          int num10;
          if (!Function.Call<bool>(Hash._0x580417101DDB492F, (InputArgument) 2, (InputArgument) 201))
            num10 = Function.Call<bool>(Hash._0x580417101DDB492F, (InputArgument) 2, (InputArgument) 237) ? 1 : 0;
          else
            num10 = 1;
          if (num10 != 0)
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
            }
          }
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
              Vector2 vector2;
              if (!this.ShowingOverlay)
              {
                if ((double) this.Screen == 0.0)
                {
                  float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                  float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                  if (Game.IsControlJustPressed(2, this.Key))
                  {
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.49f, 0.097f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.49f, 0.097f)) >= 0.100000001490116)
                        goto label_923;
                    }
                    this.Screen = 0.0f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
label_923:
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.628f, 0.102f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.802f, 0.102f)) >= 0.100000001490116)
                        goto label_926;
                    }
                    this.Screen = 1f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
label_926:
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.773f, 0.097f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.773f, 0.097f)) >= 0.100000001490116)
                        goto label_967;
                    }
                    this.Screen = 2f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
                  }
                }
                else if ((double) this.Screen == 1.0)
                {
                  float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                  float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                  if (Game.IsControlJustPressed(2, this.Key))
                  {
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.49f, 0.097f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.49f, 0.097f)) >= 0.100000001490116)
                        goto label_934;
                    }
                    this.Screen = 0.0f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
label_934:
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.628f, 0.102f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.802f, 0.102f)) >= 0.100000001490116)
                        goto label_937;
                    }
                    this.Screen = 1f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
label_937:
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.773f, 0.097f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.773f, 0.097f)) >= 0.100000001490116)
                        goto label_940;
                    }
                    this.Screen = 2f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
label_940:
                    for (int index = 0; index < this.SMG_Screen1ButtonPos.Count; ++index)
                    {
                      vector2 = new Vector2(x, y);
                      if ((double) vector2.DistanceTo(new Vector2(this.SMG_Screen1ButtonPos[index].X, this.SMG_Screen1ButtonPos[index].Y)) >= 0.100000001490116)
                      {
                        vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                        if ((double) vector2.DistanceTo(new Vector2(this.SMG_Screen1ButtonPos[index].X, this.SMG_Screen1ButtonPos[index].Y)) >= 0.100000001490116)
                          continue;
                      }
                      this.OverlayIndex = 1;
                      this.ShowingOverlay = true;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) this.SMG_Screen2ButtonType[index], (object) "Souce Crate", (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                      this.CrateSelected = index + 1;
                    }
                    if ((double) x > 0.164000004529953 && (double) x < 0.934000015258789 && ((double) y > 0.839999973773956 && (double) y < 0.899999976158142) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.934000015258789 && ((double) this.GUIPosY > 0.839999973773956 && (double) this.GUIPosY < 0.899999976158142))
                    {
                      this.OverlayIndex = 1;
                      this.ShowingOverlay = true;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Source Any", (object) "Source Any Crate?", (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                      this.CrateSelected = 9;
                    }
                  }
                }
                else if ((double) this.Screen == 2.0)
                {
                  float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                  float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                  if (Game.IsControlJustPressed(2, this.Key))
                  {
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.49f, 0.097f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.49f, 0.097f)) >= 0.100000001490116)
                        goto label_953;
                    }
                    this.Screen = 0.0f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
label_953:
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.628f, 0.102f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.802f, 0.102f)) >= 0.100000001490116)
                        goto label_956;
                    }
                    this.Screen = 1f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
label_956:
                    vector2 = new Vector2(x, y);
                    if ((double) vector2.DistanceTo(new Vector2(0.773f, 0.097f)) >= 0.100000001490116)
                    {
                      vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                      if ((double) vector2.DistanceTo(new Vector2(0.773f, 0.097f)) >= 0.100000001490116)
                        goto label_959;
                    }
                    this.Screen = 2f;
                    this.GUIscaleform.CallFunction("showScreen", (object) this.Screen);
                    this.frame = 1;
label_959:
                    for (int index = 0; index < this.SMG_Screen2ButtonPos.Count; ++index)
                    {
                      vector2 = new Vector2(x, y);
                      if ((double) vector2.DistanceTo(new Vector2(this.SMG_Screen2ButtonPos[index].X, this.SMG_Screen2ButtonPos[index].Y)) >= 0.100000001490116)
                      {
                        vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                        if ((double) vector2.DistanceTo(new Vector2(this.SMG_Screen2ButtonPos[index].X, this.SMG_Screen2ButtonPos[index].Y)) >= 0.100000001490116)
                          continue;
                      }
                      this.OverlayIndex = 2;
                      this.ShowingOverlay = true;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) this.SMG_Screen2ButtonType[index], (object) "Sell Crates", (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                      this.CrateSelected = index + 1;
                    }
                    if ((double) x > 0.164000004529953 && (double) x < 0.934000015258789 && ((double) y > 0.899999976158142 && (double) y < 0.962999999523163) || (double) this.GUIPosX > 0.164000004529953 && (double) this.GUIPosX < 0.934000015258789 && ((double) this.GUIPosY > 0.899999976158142 && (double) this.GUIPosY < 0.962999999523163))
                    {
                      this.OverlayIndex = 2;
                      this.ShowingOverlay = true;
                      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) "Sell All", (object) "Sell All Crates", (object) "Confirm", (object) "Cancel", (object) true, (object) false);
                      this.CrateSelected = 9;
                    }
                  }
                }
              }
label_967:
              if (this.ShowingOverlay)
              {
                float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
                float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
                if (this.OverlayIndex == 1 && Game.IsControlJustPressed(2, this.Key))
                {
                  vector2 = new Vector2(x, y);
                  if ((double) vector2.DistanceTo(new Vector2(0.376f, 0.562f)) >= 0.100000001490116)
                  {
                    vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                    if ((double) vector2.DistanceTo(new Vector2(0.376f, 0.562f)) >= 0.100000001490116)
                      goto label_972;
                  }
                  this.SellingCargo = false;
                  this.StealingCargo = false;
                  this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                  this.ShowingOverlay = false;
label_972:
                  vector2 = new Vector2(x, y);
                  if ((double) vector2.DistanceTo(new Vector2(0.622f, 0.555f)) >= 0.100000001490116)
                  {
                    vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                    if ((double) vector2.DistanceTo(new Vector2(0.622f, 0.555f)) >= 0.100000001490116)
                      goto label_1014;
                  }
                  this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                  this.ShowingOverlay = false;
                  this.SellingCargo = false;
                  this.StealingCargo = true;
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
                  this.CratesCollected = 0;
                  this.CratesToCollect = 0;
                  System.Random random = new System.Random();
                  if (this.CrateSelected == 9)
                    this.CrateSelected = random.Next(0, 8);
                  this.AreaOffset = this.SourcePoints[random.Next(0, this.SourcePoints.Count)];
                  Blip blip = World.CreateBlip(this.AreaOffset);
                  blip.Sprite = BlipSprite.Standard;
                  blip.Color = BlipColor.Yellow;
                  blip.Name = "Cargo Location";
                  blip.Alpha = (int) byte.MaxValue;
                  blip.IsShortRange = true;
                  this.SupplyMissionBlips.Add(blip);
                  this.SupplyMissionStage = 1;
                  this.SupplyMissionOn = true;
                  this.SupplyMissionID = 1;
                }
label_1014:
                if (this.OverlayIndex == 2 && Game.IsControlJustPressed(2, this.Key))
                {
                  vector2 = new Vector2(x, y);
                  if ((double) vector2.DistanceTo(new Vector2(0.376f, 0.562f)) >= 0.100000001490116)
                  {
                    vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                    if ((double) vector2.DistanceTo(new Vector2(0.376f, 0.562f)) >= 0.100000001490116)
                      goto label_1018;
                  }
                  this.SellingCargo = false;
                  this.StealingCargo = false;
                  this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                  this.ShowingOverlay = false;
label_1018:
                  vector2 = new Vector2(x, y);
                  if ((double) vector2.DistanceTo(new Vector2(0.622f, 0.555f)) >= 0.100000001490116)
                  {
                    vector2 = new Vector2(this.GUIPosX, this.GUIPosY);
                    if ((double) vector2.DistanceTo(new Vector2(0.622f, 0.555f)) >= 0.100000001490116)
                      goto label_1066;
                  }
                  this.GUIscaleform.CallFunction("HIDE_OVERLAY");
                  this.ShowingOverlay = false;
                  this.SellingCargo = true;
                  this.StealingCargo = false;
                  this.PointstoGoto = 0;
                  this.Selectedpoints = 0;
                  this.PointsBeenAt = 0;
                  this.AmttoDeliver = 0;
                  this.WaitingForDrop = false;
                  foreach (Hanger.Flare flare in this.Cargo)
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
                  this.SupplyMissionStage = 1;
                  this.SupplyMissionOn = true;
                  this.SupplyMissionID = 2;
                }
              }
label_1066:
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
                int num9;
                if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 32))
                  num9 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 172) ? 1 : 0;
                else
                  num9 = 1;
                if (num9 != 0)
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
                int num11;
                if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 33))
                  num11 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 173) ? 1 : 0;
                else
                  num11 = 1;
                if (num11 != 0)
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
                int num12;
                if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 34))
                  num12 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 174) ? 1 : 0;
                else
                  num12 = 1;
                if (num12 != 0)
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
                int num13;
                if (!Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 35))
                  num13 = Function.Call<bool>(Hash._0xF3A21BCD95725A4A, (InputArgument) 2, (InputArgument) 175) ? 1 : 0;
                else
                  num13 = 1;
                if (num13 != 0)
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
      }
      catch
      {
      }
      if (Game.IsControlPressed(2, GTA.Control.Cover))
      {
        Prop exChair1 = this.ExChair;
      }
      this.OnKeyDown();
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      if (this.modMenuPool2 != null && this.modMenuPool2.IsAnyMenuOpen())
        this.modMenuPool2.ProcessMenus();
      if (this.CarMenuPool != null && this.CarMenuPool.IsAnyMenuOpen())
        this.CarMenuPool.ProcessMenus();
      try
      {
        if (this.SellStockDeliveryMission)
        {
          if (Game.Player.IsAlive)
          {
            if (this.missionnum == 4444)
            {
              if (!this.Sam1.IsAlive)
              {
                if (this.Sam1blip != (Blip) null)
                  this.Sam1blip.Remove();
              }
              else
              {
                if (this.Sam1.Model == (Model) VehicleHash.Flatbed)
                {
                  Vector3 offsetInWorldCoords1 = this.Sam1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, 0.5f));
                  Vector3 offsetInWorldCoords2 = this.Sam1.GetOffsetInWorldCoords(new Vector3(0.0f, -2.25f, 0.5f));
                  Vector3 offsetInWorldCoords3 = this.Sam1.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                  World.DrawMarker(MarkerType.DebugSphere, offsetInWorldCoords1, Vector3.Zero, Vector3.Zero, new Vector3(0.15f, 0.15f, 0.15f), Color.Green);
                  this.SellStockProp1.Position = offsetInWorldCoords1;
                  this.SellStockProp1.Rotation = new Vector3(this.Sam1.Rotation.X, this.Sam1.Rotation.Y, this.Sam1.Heading);
                  this.SellStockProp2.Position = offsetInWorldCoords2;
                  this.SellStockProp2.Rotation = new Vector3(this.Sam1.Rotation.X, this.Sam1.Rotation.Y, this.Sam1.Heading);
                  this.SellStockProp3.Position = offsetInWorldCoords3;
                  this.SellStockProp3.Rotation = new Vector3(this.Sam1.Rotation.X, this.Sam1.Rotation.Y, this.Sam1.Heading);
                }
                this.Sam1blip.Position = this.Sam1.Position;
              }
              if (!this.Sam2.IsAlive)
              {
                if (this.Sam2blip != (Blip) null)
                  this.Sam2blip.Remove();
              }
              else
              {
                if (this.Sam2.Model == (Model) VehicleHash.Flatbed)
                {
                  Vector3 offsetInWorldCoords1 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, 0.5f));
                  Vector3 offsetInWorldCoords2 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -2.25f, 0.5f));
                  Vector3 offsetInWorldCoords3 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                  World.DrawMarker(MarkerType.DebugSphere, offsetInWorldCoords1, Vector3.Zero, Vector3.Zero, new Vector3(0.15f, 0.15f, 0.15f), Color.Green);
                  this.SellStockProp4.Position = offsetInWorldCoords1;
                  this.SellStockProp4.Rotation = new Vector3(this.Sam2.Rotation.X, this.Sam2.Rotation.Y, this.Sam2.Heading);
                  this.SellStockProp5.Position = offsetInWorldCoords2;
                  this.SellStockProp5.Rotation = new Vector3(this.Sam2.Rotation.X, this.Sam2.Rotation.Y, this.Sam2.Heading);
                  this.SellStockProp6.Position = offsetInWorldCoords3;
                  this.SellStockProp6.Rotation = new Vector3(this.Sam2.Rotation.X, this.Sam2.Rotation.Y, this.Sam2.Heading);
                }
                this.Sam2blip.Position = this.Sam2.Position;
              }
              if (!this.Sam3.IsAlive)
              {
                if (this.Sam3blip != (Blip) null)
                  this.Sam3blip.Remove();
              }
              else
              {
                if (this.Sam3.Model == (Model) VehicleHash.Flatbed)
                {
                  Vector3 offsetInWorldCoords1 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, 0.5f));
                  Vector3 offsetInWorldCoords2 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -2.25f, 0.5f));
                  Vector3 offsetInWorldCoords3 = this.Sam2.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                  World.DrawMarker(MarkerType.DebugSphere, offsetInWorldCoords1, Vector3.Zero, Vector3.Zero, new Vector3(0.15f, 0.15f, 0.15f), Color.Green);
                  this.SellStockProp7.Position = offsetInWorldCoords1;
                  this.SellStockProp7.Rotation = new Vector3(this.Sam3.Rotation.X, this.Sam3.Rotation.Y, this.Sam3.Heading);
                  this.SellStockProp8.Position = offsetInWorldCoords2;
                  this.SellStockProp8.Rotation = new Vector3(this.Sam3.Rotation.X, this.Sam3.Rotation.Y, this.Sam3.Heading);
                  this.SellStockProp9.Position = offsetInWorldCoords3;
                  this.SellStockProp9.Rotation = new Vector3(this.Sam3.Rotation.X, this.Sam3.Rotation.Y, this.Sam3.Heading);
                }
                this.Sam3blip.Position = this.Sam3.Position;
              }
              if (!this.Sam1.IsAlive && !this.Sam2.IsAlive && !this.Sam3.IsAlive)
              {
                Game.FadeScreenOut(500);
                Script.Wait(500);
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
                Script.Wait(500);
                Game.FadeScreenIn(500);
                UI.Notify(this.GetHostName() + " : All Enemy vehicle Destroyed ");
                UI.Notify(this.GetHostName() + " : Stocks Value just Increased");
                UI.Notify("~g~Stock Value :  $" + this.stocksvalue.ToString("N"));
                UI.Notify("~g~Stock Increase : +$" + ((int) ((double) this.stocksvalue * 0.25)).ToString("N"));
                UI.Notify("~g~Stock Value Now: +$" + ((int) ((double) this.stocksvalue * 1.25)).ToString("N"));
                this.missionnum = 0;
                this.stocksvalue = (float) (int) ((double) this.stocksvalue * 1.25);
                this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                this.Config.Save();
              }
              if ((double) World.GetDistance(this.Sam1.Position, this.EndPointVec) < 20.0 || (double) World.GetDistance(this.Sam2.Position, this.EndPointVec) < 20.0 || (double) World.GetDistance(this.Sam3.Position, this.EndPointVec) < 20.0)
              {
                Game.FadeScreenOut(500);
                Script.Wait(500);
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
                Script.Wait(500);
                Game.FadeScreenIn(500);
                UI.Notify(this.GetHostName() + " : Boss a vehicle Reached the destination!, We cannot aford to have the millitary come after us!");
                this.missionnum = 0;
                this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                this.Config.Save();
              }
            }
            if (this.missionnum == 3333)
            {
              if (this.SupplyGarageBlip != (Blip) null)
                this.SupplyGarageBlip.ShowRoute = true;
              if (this.CreateSupplyVehicle && (Entity) this.StockVeh != (Entity) null)
              {
                if (!this.StockVeh.IsAlive)
                {
                  if (this.StockVeh.CurrentBlip != (Blip) null)
                    this.StockVeh.CurrentBlip.Remove();
                  this.CreateSupplyVehicle = false;
                  this.StockVeh.MarkAsNoLongerNeeded();
                  if ((Entity) this.SellStockProp1 != (Entity) null)
                    this.SellStockProp1.MarkAsNoLongerNeeded();
                  if ((Entity) this.SellStockProp2 != (Entity) null)
                    this.SellStockProp2.MarkAsNoLongerNeeded();
                  if ((Entity) this.SellStockProp3 != (Entity) null)
                    this.SellStockProp3.MarkAsNoLongerNeeded();
                  this.SellStockProp1 = (Prop) null;
                  this.SellStockProp2 = (Prop) null;
                  this.SellStockProp3 = (Prop) null;
                  this.StockVeh = (Vehicle) null;
                  UI.Notify(this.GetHostName() + " A rival supply vehicle was destroyed, search for another one!");
                  return;
                }
                if (this.StockVeh.Model == (Model) VehicleHash.Flatbed)
                {
                  Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, 0.5f));
                  Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2.25f, 0.5f));
                  Vector3 offsetInWorldCoords3 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                  this.SellStockProp1.Position = offsetInWorldCoords1;
                  this.SellStockProp1.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                  this.SellStockProp2.Position = offsetInWorldCoords2;
                  this.SellStockProp2.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                  this.SellStockProp3.Position = offsetInWorldCoords3;
                  this.SellStockProp3.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                }
                if (this.StockVeh.Model == (Model) VehicleHash.TipTruck)
                {
                  Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -0.75f, 0.75f));
                  Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2.25f, 0.75f));
                  this.SellStockProp1.Position = offsetInWorldCoords1;
                  this.SellStockProp1.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                  this.SellStockProp2.Position = offsetInWorldCoords2;
                  this.SellStockProp2.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                }
                if (this.StockVeh.Model == (Model) VehicleHash.Guardian)
                {
                  this.SellStockProp1.Position = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
                  this.SellStockProp1.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                }
                if ((double) World.GetDistance(this.StockVeh.Position, this.Spawn) < 200.0)
                  World.DrawMarker(MarkerType.VerticalCylinder, this.Spawn, Vector3.Zero, Vector3.Zero, new Vector3(6f, 6f, 4f), Color.White);
                if ((double) World.GetDistance(this.StockVeh.Position, this.Spawn) < 5.0)
                {
                  this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Deliver Cargo ~INPUT_COVER~ to Quit mission");
                  if (Game.IsControlPressed(2, GTA.Control.Context))
                  {
                    this.maxstocks = 10 * this.purchaselvl;
                    if (this.stockscount <= this.maxstocks)
                    {
                      if (this.StockVeh.Model == (Model) VehicleHash.Flatbed)
                      {
                        this.stocksvalue += this.IncreaseStockMinAmount * 9f;
                        this.stockscount += 3;
                        UI.Notify(this.GetHostName() + " Ok you have stolen a 3 crates worth ~g~$" + (this.IncreaseStockMinAmount * 9f).ToString("N"));
                        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
                        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                        this.Config.Save();
                      }
                      if (this.StockVeh.Model == (Model) VehicleHash.TipTruck)
                      {
                        this.stocksvalue += this.IncreaseStockMinAmount * 6f;
                        this.stockscount += 2;
                        UI.Notify(this.GetHostName() + " Ok you have stolen 2 singles crate worth ~g~$" + (this.IncreaseStockMinAmount * 6f).ToString("N"));
                        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
                        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                        this.Config.Save();
                      }
                      if (this.StockVeh.Model == (Model) VehicleHash.Guardian)
                      {
                        this.stocksvalue += this.IncreaseStockMinAmount * 3f;
                        ++this.stockscount;
                        UI.Notify(this.GetHostName() + " Ok you have stolen a single crate worth ~g~$" + (this.IncreaseStockMinAmount * 3f).ToString("N"));
                        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
                        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                        this.Config.Save();
                      }
                      if ((Entity) this.StockVeh != (Entity) null)
                      {
                        this.StockVeh.CurrentBlip.Remove();
                        this.StockVeh.IsPersistent = false;
                        this.StockVeh.MarkAsNoLongerNeeded();
                      }
                      if (this.SellStockProps.Count > 0)
                      {
                        foreach (Prop sellStockProp in this.SellStockProps)
                        {
                          if ((Entity) sellStockProp != (Entity) null)
                            sellStockProp.Delete();
                        }
                      }
                      this.CreateSupplyVehicle = false;
                    }
                    if (this.stockscount >= this.maxstocks)
                    {
                      if (this.SupplyGarageBlip != (Blip) null)
                        this.SupplyGarageBlip.Remove();
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
                      if (this.EndPointBlip != (Blip) null)
                        this.EndPointBlip.Remove();
                      if ((Entity) this.StockVeh != (Entity) null)
                        this.StockVeh.Delete();
                      UI.Notify("Weve gotten as much as we can hold");
                    }
                  }
                  if (Game.IsControlPressed(2, GTA.Control.Cover))
                  {
                    if (this.EndPointBlip != (Blip) null)
                      this.EndPointBlip.Remove();
                    if (this.SupplyGarageBlip != (Blip) null)
                      this.SupplyGarageBlip.Remove();
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
                    if ((Entity) this.StockVeh != (Entity) null)
                      this.StockVeh = (Vehicle) null;
                    UI.Notify("You have cancelled the mission");
                  }
                }
              }
              for (int index1 = 0; index1 < this.DropPoint2.Count; ++index1)
              {
                if (this.DropBlip[index1] != (Blip) null)
                {
                  if (this.DropBlip[index1].Alpha == (int) byte.MaxValue)
                  {
                    try
                    {
                      if ((double) World.GetDistance(Game.Player.Character.Position, this.DropPoint2[index1]) < 200.0)
                        World.DrawMarker(MarkerType.VerticalCylinder, this.DropPoint2[index1], Vector3.Zero, Vector3.Zero, new Vector3(4f, 6f, 4f), Color.White);
                      if ((double) World.GetDistance(Game.Player.Character.Position, this.DropPoint2[index1]) < 100.0)
                      {
                        if (!this.CreateSupplyVehicle)
                        {
                          UI.Notify(this.GetHostName() + " You have Located a nearby adversary Cargo Vehicle, steal it and return it to the Garage");
                          if (this.SupplyGarageBlip != (Blip) null)
                            this.SupplyGarageBlip.Remove();
                          this.SupplyGarageBlip = World.CreateBlip(this.Spawn);
                          this.SupplyGarageBlip.Sprite = BlipSprite.Briefcase2;
                          this.SupplyGarageBlip.Color = BlipColor.Blue4;
                          this.SupplyGarageBlip.Name = "Cargo Deliver Point";
                          this.SupplyGarageBlip.Scale = 1.5f;
                          this.DropBlip[index1].Alpha = 0;
                          this.CreateSupplyVehicle = true;
                          if (this.SellStockProps.Count > 0)
                          {
                            foreach (Prop sellStockProp in this.SellStockProps)
                            {
                              if ((Entity) sellStockProp != (Entity) null)
                                sellStockProp.Delete();
                            }
                          }
                          if ((Entity) this.StockVeh != (Entity) null)
                            this.StockVeh.Delete();
                          foreach (Ped suppyGuard in this.SuppyGuards)
                          {
                            if ((Entity) suppyGuard != (Entity) null)
                              suppyGuard.Delete();
                          }
                          System.Random random = new System.Random();
                          float num1 = (float) random.Next(0, 100);
                          if ((double) num1 < 33.0)
                          {
                            this.StockVeh = World.CreateVehicle((Model) VehicleHash.TipTruck, this.DropPoint2[index1], 0.0f);
                            this.StockVeh.ToggleExtra(2, false);
                            Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
                            Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
                            this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                            Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                            this.SellStockProp1 = prop1;
                            this.SellStockProps.Add(prop1);
                            Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                            this.SellStockProp2 = prop2;
                            this.SellStockProps.Add(prop2);
                            this.SellStockProp1.HasCollision = false;
                            this.SellStockProp2.HasCollision = false;
                          }
                          if ((double) num1 > 33.0 && (double) num1 < 66.0)
                          {
                            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Flatbed, this.DropPoint2[index1], 0.0f);
                            Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
                            Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
                            Vector3 offsetInWorldCoords3 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                            Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                            this.SellStockProp1 = prop1;
                            this.SellStockProps.Add(prop1);
                            Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                            this.SellStockProp2 = prop2;
                            this.SellStockProps.Add(prop2);
                            Prop prop3 = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords3, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                            this.SellStockProp3 = prop3;
                            this.SellStockProps.Add(prop3);
                            this.SellStockProp1.HasCollision = false;
                            this.SellStockProp2.HasCollision = false;
                            this.SellStockProp3.HasCollision = false;
                          }
                          if ((double) num1 > 66.0)
                          {
                            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Guardian, this.DropPoint2[index1], 0.0f);
                            Vector3 offsetInWorldCoords = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.1f));
                            Prop prop = World.CreateProp(this.RequestModel(this.CrateProps2[random.Next(0, this.CrateProps2.Count)]), offsetInWorldCoords, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                            this.SellStockProp1 = prop;
                            this.SellStockProps.Add(prop);
                            this.SellStockProp1.HasCollision = false;
                          }
                          float num2 = (float) random.Next(6, 8);
                          for (int index2 = 0; (double) index2 < (double) num2; ++index2)
                          {
                            Ped ped = World.CreatePed(this.RequestModel(PedHash.Polynesian01AMM), this.DropPoint2[index1].Around(20f));
                            this.SuppyGuards.Add(ped);
                            int num3 = new System.Random().Next(0, 300);
                            if (num3 < 50)
                              ped.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
                            if (num3 > 50 && num3 < 100)
                              ped.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
                            if (num3 > 100 && num3 < 150)
                              ped.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
                            if (num3 > 150 && num3 < 200)
                              ped.Weapons.Give(WeaponHash.SMG, 9999, true, true);
                            if (num3 > 200 && num3 < 250)
                              ped.Weapons.Give(WeaponHash.DoubleBarrelShotgun, 9999, true, true);
                            if (num3 > 250 && num3 < 300)
                              ped.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
                            ped.Accuracy = 400;
                            int num4 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num4);
                            Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
                            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
                            ped.Task.FightAgainst(Game.Player.Character);
                          }
                          if ((Entity) this.StockVeh != (Entity) null)
                          {
                            this.StockVeh.AddBlip();
                            this.StockVeh.CurrentBlip.Sprite = BlipSprite.ArmoredTruck;
                            this.StockVeh.CurrentBlip.Color = BlipColor.Blue4;
                            this.StockVeh.CurrentBlip.Name = "Cargo Vehicle";
                          }
                        }
                      }
                    }
                    catch
                    {
                      UI.Notify("Crash1 " + this.DropBlip.Count.ToString() + "__" + this.DropPoint2.Count.ToString());
                    }
                  }
                }
              }
            }
            if (this.missionnum == 2222 && (Entity) this.StockVeh != (Entity) null)
            {
              if (this.StockVeh.Model == (Model) VehicleHash.Flatbed)
              {
                Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, 0.5f));
                Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2.25f, 0.5f));
                Vector3 offsetInWorldCoords3 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                World.DrawMarker(MarkerType.DebugSphere, offsetInWorldCoords1, Vector3.Zero, Vector3.Zero, new Vector3(0.15f, 0.15f, 0.15f), Color.Green);
                this.SellStockProp1.Position = offsetInWorldCoords1;
                this.SellStockProp1.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                this.SellStockProp2.Position = offsetInWorldCoords2;
                this.SellStockProp2.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                this.SellStockProp3.Position = offsetInWorldCoords3;
                this.SellStockProp3.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
              }
              if (this.StockVeh.Model == (Model) VehicleHash.TipTruck)
              {
                Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -0.75f, 0.75f));
                Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2.25f, 0.75f));
                World.DrawMarker(MarkerType.DebugSphere, offsetInWorldCoords1, Vector3.Zero, Vector3.Zero, new Vector3(0.15f, 0.15f, 0.15f), Color.Green);
                this.SellStockProp1.Position = offsetInWorldCoords1;
                this.SellStockProp1.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
                this.SellStockProp2.Position = offsetInWorldCoords2;
                this.SellStockProp2.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
              }
              if (this.StockVeh.Model == (Model) VehicleHash.Guardian)
              {
                Vector3 offsetInWorldCoords = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
                World.DrawMarker(MarkerType.DebugSphere, offsetInWorldCoords, Vector3.Zero, Vector3.Zero, new Vector3(0.15f, 0.15f, 0.15f), Color.Green);
                this.SellStockProp1.Position = offsetInWorldCoords;
                this.SellStockProp1.Rotation = new Vector3(this.StockVeh.Rotation.X, this.StockVeh.Rotation.Y, this.StockVeh.Heading);
              }
              if (this.StockVeh.IsAlive)
              {
                try
                {
                  for (int index = 0; index < this.DropBlip.Count; ++index)
                  {
                    if (this.DropBlip[index] != (Blip) null && this.DropBlip[index].Alpha == (int) byte.MaxValue)
                    {
                      if (this.SellStockPointsBeenAt != this.AmttoDeliver)
                      {
                        if ((double) World.GetDistance(this.StockVeh.Position, this.DropPoint2[index]) < 200.0)
                          World.DrawMarker(MarkerType.VerticalCylinder, this.DropPoint2[index], Vector3.Zero, Vector3.Zero, new Vector3(4f, 6f, 4f), Color.White);
                        if ((double) World.GetDistance(this.StockVeh.Position, this.DropPoint2[index]) < 10.0)
                        {
                          ++this.SellStockPointsBeenAt;
                          this.DropBlip[index].Alpha = 0;
                          this.DropBlip[index].IsShortRange = true;
                          this.DropBlip[index].Remove();
                          UI.Notify(this.GetHostName() + " : Another package successfuly delivered");
                        }
                      }
                      if (this.SellStockPointsBeenAt == this.AmttoDeliver)
                      {
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
                        if ((Entity) this.StockVeh != (Entity) null)
                          this.StockVeh.Delete();
                        ++this.SellStockPointsBeenAt;
                        this.SellStockDeliveryMission = false;
                        UI.Notify(this.GetHostName() + " : All Packages successfuly delivered");
                        Game.Player.Money += (int) ((double) this.stocksvalue * 1.25);
                        this.stocksvalue = 0.0f;
                        this.stockscount = 0;
                        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
                        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                        this.Config.Save();
                      }
                    }
                  }
                }
                catch
                {
                  UI.Notify("Crash2");
                }
              }
              if (!this.StockVeh.IsAlive && this.SellStockDeliveryMission)
              {
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
                if ((Entity) this.StockVeh != (Entity) null)
                  this.StockVeh.Delete();
                this.SellStockDeliveryMission = false;
              }
            }
          }
          if (!Game.Player.IsAlive)
          {
            if (this.SupplyGarageBlip != (Blip) null)
              this.SupplyGarageBlip.Remove();
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
            if ((Entity) this.StockVeh != (Entity) null)
              this.StockVeh.Delete();
            this.SellStockDeliveryMission = false;
            this.missionnum = 0;
            UI.Notify(this.GetHostName() + " : Stock Supply Mission has been cancelled");
          }
        }
      }
      catch
      {
        UI.Notify("Erorr 408");
      }
      if (this.IsInInterior)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) < 2.0)
        {
          if (this.IsSittinginCeoSeat)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open Menu, Press ~INPUT_COVER~ to Exit");
          else
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to sit on CEO chair to access Menu");
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) > 4.0 && this.IsSittinginCeoSeat)
        {
          this.IsSittinginCeoSeat = false;
          Game.Player.Character.FreezePosition = true;
          Game.FadeScreenOut(500);
          Script.Wait(500);
          Game.Player.Character.Position = this.ChairPos;
          Game.Player.Character.Heading = this.P_Rotation;
          Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
          Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
          Game.Player.Character.Task.ClearAnimation("anim@amb@office@laptops@male@var_c@base@", "base");
          Game.Player.Character.FreezePosition = false;
          Script.Wait(500);
          Game.FadeScreenIn(500);
        }
      }
      if (this.BSmodMenuPool != null && this.BSmodMenuPool.IsAnyMenuOpen())
        this.BSmodMenuPool.ProcessMenus();
      if (this.BSmodMenuPool2 != null && this.BSmodMenuPool2.IsAnyMenuOpen())
        this.BSmodMenuPool2.ProcessMenus();
      if (this.IsInInterior)
      {
        if (this.UseOldMarker)
          World.DrawMarker(MarkerType.VerticalCylinder, this.BSMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
        World.DrawMarker(MarkerType.VerticalCylinder, this.Marker2, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
      }
      if (this.DeliveryMissionOn)
      {
        this.LocationBlip.Position = this.MissionMarker;
        if ((double) World.GetDistance(Game.Player.Character.Position, this.MissionMarker) < 500.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.MissionMarker, Vector3.Zero, Vector3.Zero, new Vector3(9f, 9f, 40f), Color.Red);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.MissionMarker) < 20.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to deliver package");
      }
      else
      {
        if (this.missionnum != 9 && (Entity) this.Plane != (Entity) null)
          this.Plane.Delete();
        if (this.PlaneBlip != (Blip) null)
          this.PlaneBlip.Remove();
        if (this.LocationBlip != (Blip) null)
          this.LocationBlip.Remove();
      }
      if (!this.MissionSetup)
        return;
      try
      {
        if (this.missionnum == 9)
        {
          if ((Entity) this.Plane != (Entity) null)
          {
            if (this.NumberOfPlanes != 0)
            {
              if (this.Plane.IsAlive)
              {
                if (this.TargetTimer <= 100)
                  ++this.TargetTimer;
                if (this.TargetTimer >= 100)
                {
                  this.TargetTimer = 0;
                  this.Plane.GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = Game.Player.Character.RelationshipGroup;
                  this.Plane.GetPedOnSeat(VehicleSeat.Driver).NeverLeavesGroup = true;
                  this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsEnemy = false;
                  this.Plane.GetPedOnSeat(VehicleSeat.Driver).BlockPermanentEvents = true;
                  if ((Entity) this.CurrentTarget != (Entity) this.PlaneTargetPositions[0])
                  {
                    this.SetActiveTarget2(this.Plane, this.CurrentTarget);
                    this.FightAgainst(this.CurrentTarget, this.Plane.GetPedOnSeat(VehicleSeat.Driver));
                  }
                  else
                  {
                    UI.Notify("Attacking Plane 6");
                    this.SetActiveTarget2(this.Plane, this.AIPlanes[6].GetPedOnSeat(VehicleSeat.Driver));
                    this.FightAgainst(this.AIPlanes[6].GetPedOnSeat(VehicleSeat.Driver), this.Plane.GetPedOnSeat(VehicleSeat.Driver));
                  }
                }
                if ((Entity) this.AIPlanes[0] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[0].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[0].IsAlive && this.AIPlanes[0].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[1] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[1].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[1].IsAlive && this.AIPlanes[1].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[2] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[2].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[2].IsAlive && this.AIPlanes[2].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[3] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[3].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[3].IsAlive && this.AIPlanes[3].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[4] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[4].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[4].IsAlive && this.AIPlanes[4].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), 6);
                if ((Entity) this.AIPlanes[5] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[5].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[5].IsAlive && this.AIPlanes[5].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[6] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[6].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[6].IsAlive && this.AIPlanes[6].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[7] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[6].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[7].IsAlive && this.AIPlanes[7].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[8] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[6].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[8].IsAlive && this.AIPlanes[8].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[9] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[6].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[9].IsAlive && this.AIPlanes[9].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                if ((Entity) this.AIPlanes[10] != (Entity) null && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.AIPlanes[6].GetPedOnSeat(VehicleSeat.Driver)) && (!this.AIPlanes[10].IsAlive && this.AIPlanes[10].IsPersistent))
                  this.PickNewTarget(this.Plane.GetPedOnSeat(VehicleSeat.Driver), this.AIPlanes.Count);
                foreach (Vehicle aiPlane in this.AIPlanes)
                {
                  if ((Entity) aiPlane != (Entity) null)
                  {
                    if (!aiPlane.IsAlive && aiPlane.IsPersistent)
                    {
                      --this.NumberOfPlanes;
                      aiPlane.CurrentBlip.Remove();
                      aiPlane.IsPersistent = false;
                      UI.Notify("Enemy Aircraft Destroyed");
                    }
                    if ((double) World.GetDistance(aiPlane.Position, this.PlaneTargetPositions[2].Position) < 750.0)
                    {
                      this.SetActiveTarget(aiPlane, this.PlaneTargetPositions[1]);
                      if (aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[2]))
                        this.FightAgainst(this.PlaneTargetPositions[1], aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                    }
                    if ((double) World.GetDistance(aiPlane.Position, this.PlaneTargetPositions[1].Position) < 750.0)
                    {
                      this.SetActiveTarget(aiPlane, this.PlaneTargetPositions[0]);
                      if (aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[1]))
                        this.FightAgainst(this.PlaneTargetPositions[0], aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                    }
                    if ((double) World.GetDistance(aiPlane.Position, this.PlaneTargetPositions[0].Position) < 750.0)
                    {
                      this.SetActiveTarget(aiPlane, this.PlaneTargetPositions[2]);
                      if (aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[0]))
                        this.FightAgainst(this.PlaneTargetPositions[2], aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                    }
                    if ((double) World.GetDistance(aiPlane.Position, Game.Player.Character.Position) < 750.0 && aiPlane.IsInvincible)
                    {
                      UI.Notify("Check 2");
                      aiPlane.IsInvincible = false;
                    }
                    if ((double) World.GetDistance(aiPlane.Position, Game.Player.Character.Position) < 750.0)
                    {
                      if (!aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(Game.Player.Character))
                      {
                        this.SetActiveTarget(aiPlane, Game.Player.Character);
                        this.FightAgainst(Game.Player.Character, aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                        if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.Passenger) != (Entity) null)
                          this.FightAgainst(Game.Player.Character, aiPlane.GetPedOnSeat(VehicleSeat.Passenger));
                        if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.LeftRear) != (Entity) null)
                          this.FightAgainst(Game.Player.Character, aiPlane.GetPedOnSeat(VehicleSeat.LeftRear));
                      }
                    }
                    else if ((double) World.GetDistance(aiPlane.Position, Game.Player.Character.Position) > 750.0 && aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(Game.Player.Character))
                    {
                      int index = new System.Random().Next(0, 2);
                      this.SetActiveTarget(aiPlane, this.PlaneTargetPositions[index]);
                      this.FightAgainst(this.PlaneTargetPositions[index], aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                    }
                  }
                }
              }
              else
              {
                if ((Entity) this.Plane != (Entity) null)
                {
                  if ((Entity) this.Plane.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
                    this.Plane.GetPedOnSeat(VehicleSeat.Driver).Delete();
                  this.Plane.Delete();
                }
                foreach (Vehicle aiPlane in this.AIPlanes)
                {
                  if ((Entity) aiPlane != (Entity) null)
                    aiPlane.Delete();
                }
                foreach (Blip planeBlip in this.PlaneBlips)
                {
                  if (planeBlip != (Blip) null)
                    planeBlip.Remove();
                }
                foreach (Ped ped in this.Peds)
                {
                  if ((Entity) ped != (Entity) null)
                    ped.Delete();
                }
                UI.Notify(this.GetHostName() + " Mission Failed!");
                new MissionScreen().SetFail("The Dawn Raid", 2500000, "Your Aircraft was destroyed");
                this.MissionSetup = false;
                this.missionnum = 0;
              }
            }
            else
            {
              if ((Entity) this.Plane != (Entity) null)
              {
                if ((Entity) this.Plane.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
                  this.Plane.GetPedOnSeat(VehicleSeat.Driver).Delete();
                this.Plane.Delete();
              }
              foreach (Vehicle aiPlane in this.AIPlanes)
              {
                if ((Entity) aiPlane != (Entity) null)
                  aiPlane.Delete();
              }
              foreach (Blip planeBlip in this.PlaneBlips)
              {
                if (planeBlip != (Blip) null)
                  planeBlip.Remove();
              }
              foreach (Ped ped in this.Peds)
              {
                if ((Entity) ped != (Entity) null)
                  ped.Delete();
              }
              UI.Notify(this.GetHostName() + " ok good all enemy aircraft have been destroyed");
              UI.Notify(this.GetHostName() + " Stocks just Increased");
              UI.Notify("Max Stocks: " + this.maxstocks.ToString());
              UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
              UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
              UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
              this.MissionSetup = false;
              this.missionnum = 0;
              new MissionScreen().SetPass("The Dawn Raid", 2500000, "Your Aircraft was destroyed");
              this.stocksvalue = (float) ((double) this.stocksvalue + 4200000.0 + 4200000.0 * (double) this.profitMargin / 100.0);
              this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
              this.Config.Save();
            }
          }
        }
      }
      catch
      {
        UI.Notify("Erorr 409");
      }
      try
      {
        if (this.missionnum == 8)
        {
          if (this.NumberOfPlanes != 0)
          {
            foreach (Vehicle aiPlane in this.AIPlanes)
            {
              if ((Entity) aiPlane != (Entity) null)
              {
                if (!aiPlane.IsAlive && aiPlane.IsPersistent)
                {
                  --this.NumberOfPlanes;
                  aiPlane.CurrentBlip.Remove();
                  aiPlane.IsPersistent = false;
                  UI.Notify("Enemy Aircraft Destroyed");
                }
                if ((double) World.GetDistance(aiPlane.Position, this.PlaneTargetPositions[2].Position) < 750.0)
                {
                  this.SetActiveTarget(aiPlane, this.PlaneTargetPositions[1]);
                  if (aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[2]))
                    this.FightAgainst(this.PlaneTargetPositions[1], aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                }
                if ((double) World.GetDistance(aiPlane.Position, this.PlaneTargetPositions[1].Position) < 750.0)
                {
                  this.SetActiveTarget(aiPlane, this.PlaneTargetPositions[0]);
                  if (aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[1]))
                    this.FightAgainst(this.PlaneTargetPositions[0], aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                }
                if ((double) World.GetDistance(aiPlane.Position, this.PlaneTargetPositions[0].Position) < 750.0)
                {
                  this.SetActiveTarget(aiPlane, this.PlaneTargetPositions[2]);
                  if (aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[0]))
                    this.FightAgainst(this.PlaneTargetPositions[2], aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                }
                if ((double) World.GetDistance(aiPlane.Position, Game.Player.Character.Position) < 750.0)
                {
                  if (!aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(Game.Player.Character))
                  {
                    this.SetActiveTarget(aiPlane, Game.Player.Character);
                    this.FightAgainst(Game.Player.Character, aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                    if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.Passenger) != (Entity) null)
                      this.FightAgainst(Game.Player.Character, aiPlane.GetPedOnSeat(VehicleSeat.Passenger));
                    if ((Entity) aiPlane.GetPedOnSeat(VehicleSeat.LeftRear) != (Entity) null)
                      this.FightAgainst(Game.Player.Character, aiPlane.GetPedOnSeat(VehicleSeat.LeftRear));
                  }
                }
                else if ((double) World.GetDistance(aiPlane.Position, Game.Player.Character.Position) > 750.0 && aiPlane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(Game.Player.Character))
                {
                  int index = new System.Random().Next(0, 2);
                  this.SetActiveTarget(aiPlane, this.PlaneTargetPositions[index]);
                  this.FightAgainst(this.PlaneTargetPositions[index], aiPlane.GetPedOnSeat(VehicleSeat.Driver));
                }
              }
            }
          }
          else
          {
            foreach (Vehicle aiPlane in this.AIPlanes)
            {
              if ((Entity) aiPlane != (Entity) null)
                aiPlane.Delete();
            }
            foreach (Blip planeBlip in this.PlaneBlips)
            {
              if (planeBlip != (Blip) null)
                planeBlip.Remove();
            }
            foreach (Ped ped in this.Peds)
            {
              if ((Entity) ped != (Entity) null)
                ped.Delete();
            }
            UI.Notify(this.GetHostName() + " ok good all enemy aircraft have been destroyed");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            this.MissionSetup = false;
            this.missionnum = 0;
            new MissionScreen().SetPass("The Invasion Force", 3200000, "Your Aircraft was destroyed");
            this.stocksvalue = (float) ((double) this.stocksvalue + 3200000.0 + 3200000.0 * (double) this.profitMargin / 100.0);
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
        }
      }
      catch
      {
        UI.Notify("Erorr 410");
      }
      try
      {
        if (this.missionnum == 7)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
            if (currentVehicle.IsAlive && (currentVehicle.ClassType == VehicleClass.Planes || currentVehicle.ClassType == VehicleClass.Helicopters))
            {
              if (this.Race == 1)
              {
                if (this.CurrentPoint >= 1)
                {
                  if (this.IntervalTimer != 24)
                    ++this.IntervalTimer;
                  if (this.IntervalTimer == 24)
                  {
                    --this.MaxTimer;
                    this.IntervalTimer = 0;
                    this.DisplayHelpTextThisFrame("Time Left :" + this.MaxTimer.ToString() + "  Check Points :" + this.CurrentPoint.ToString() + "/" + this.maxCheckpoints.ToString() + " Altitude of next Checkpoint : " + this.CheckPoints[this.CurrentPoint].Z.ToString());
                  }
                }
                if (this.MaxTimer != 0)
                {
                  World.DrawMarker(MarkerType.HorizontalCircleSkinny_Arrow, this.CheckPoints[this.CurrentPoint], Vector3.WorldDown, new Vector3(0.0f, this.Rotation[this.CurrentPoint], 0.0f), new Vector3(9f, 9f, 2f), Color.Red);
                  if ((double) World.GetDistance(Game.Player.Character.Position, this.CheckPoints[this.CurrentPoint]) < 10.0)
                  {
                    if (this.checkpointReaced < this.maxCheckpoints)
                    {
                      ++this.CurrentPoint;
                      ++this.checkpointReaced;
                      this.NextCheckPoint = this.CheckPoints[this.CurrentPoint];
                      this.Sam1blip.Position = this.NextCheckPoint;
                      this.Sam1blip.Sprite = BlipSprite.TransformCheckpoint;
                      this.Sam1blip.Color = BlipColor.Red;
                      this.Sam1blip.Name = "CheckPoint";
                    }
                    else
                    {
                      Script.Wait(500);
                      Game.FadeScreenIn(500);
                      if (this.Sam1blip != (Blip) null)
                        this.Sam1blip.Remove();
                      this.MissionSetup = false;
                      this.missionnum = 0;
                      if (this.MaxTimer >= 20)
                      {
                        UI.Notify(this.GetHostName() + " Good Job you won Gold");
                        this.stocksvalue = (float) ((double) this.stocksvalue + 400000.0 + 400000.0 * (double) this.profitMargin / 100.0);
                      }
                      else if (this.MaxTimer >= 10 && this.MaxTimer < 20)
                      {
                        UI.Notify(this.GetHostName() + " Good Job you won Silver");
                        this.stocksvalue = (float) ((double) this.stocksvalue + 300000.0 + 300000.0 * (double) this.profitMargin / 100.0);
                      }
                      else if (this.MaxTimer >= 5 && this.MaxTimer < 10)
                      {
                        UI.Notify(this.GetHostName() + " Good Job you won Bronze");
                        this.stocksvalue = (float) ((double) this.stocksvalue + 200000.0 + 200000.0 * (double) this.profitMargin / 100.0);
                      }
                      UI.Notify(this.GetHostName() + " Stocks just Increased");
                      UI.Notify("Max Stocks: " + this.maxstocks.ToString());
                      UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
                      UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
                      UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
                      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                      this.Config.Save();
                    }
                  }
                }
                else if (this.MaxTimer <= 0)
                {
                  if (this.CurrentPoint >= 1)
                  {
                    Script.Wait(500);
                    Game.FadeScreenIn(500);
                    if (this.Sam1blip != (Blip) null)
                      this.Sam1blip.Remove();
                    this.MissionSetup = false;
                    this.missionnum = 0;
                    UI.Notify(this.GetHostName() + " You failed to qualify for this Air Race");
                  }
                }
              }
            }
            else if (this.CurrentPoint == 0)
              this.DisplayHelpTextThisFrame("You will need a Aircraft for this type of mission");
            else if (this.CurrentPoint >= 1)
            {
              Script.Wait(500);
              Game.FadeScreenIn(500);
              if (this.Sam1blip != (Blip) null)
                this.Sam1blip.Remove();
              this.MissionSetup = false;
              this.missionnum = 0;
              UI.Notify(this.GetHostName() + " You failed to qualify for this Air Race");
            }
          }
        }
      }
      catch
      {
        UI.Notify("Erorr 411");
      }
      try
      {
        if (this.missionnum == 5)
        {
          foreach (Ped ped in this.Peds)
          {
            if (ped.CurrentBlip != (Blip) null)
            {
              ped.CurrentBlip.Color = BlipColor.Blue;
              ped.LodDistance = 10000;
            }
          }
          this.DisplayHelpTextThisFrame("Enemies Left :" + this.Enemies.ToString());
          if (!this.Aircraft.IsAlive)
          {
            this.MissionSetup = false;
            this.missionnum = 0;
            Game.FadeScreenOut(500);
            Script.Wait(500);
            foreach (Ped ped in this.Peds)
            {
              if (ped.CurrentBlip != (Blip) null)
                ped.CurrentBlip.Remove();
            }
            foreach (Ped ped in this.Peds)
            {
              if ((Entity) ped != (Entity) null)
                ped.Delete();
            }
            Script.Wait(500);
            Game.FadeScreenIn(500);
            UI.Notify(this.GetHostName() + " your aircraft was destroyed ");
            new MissionScreen().SetFail("Under Fire", 3200000, "Your Aircraft was destroyed");
          }
          if (this.Enemies == 0)
          {
            UI.Notify(this.GetHostName() + " ok good enemies killed ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            this.MissionSetup = false;
            this.missionnum = 0;
            foreach (Ped ped in this.Peds)
            {
              if (ped.CurrentBlip != (Blip) null)
                ped.CurrentBlip.Remove();
            }
            foreach (Ped ped in this.Peds)
            {
              if ((Entity) ped != (Entity) null)
                ped.Delete();
            }
            new MissionScreen().SetPass("Under Fire", 2200000, "Your Aircraft was destroyed");
            this.stocksvalue = (float) ((double) this.stocksvalue + 2200000.0 + 100000.0 * (double) this.profitMargin / 100.0);
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
            {
              if (ped.IsAlive)
              {
                int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num);
                Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
                Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
                ped.IsPersistent = true;
              }
              else if (!ped.IsAlive && ped.IsPersistent)
              {
                ped.CurrentBlip.Remove();
                --this.Enemies;
                ped.IsPersistent = false;
              }
            }
          }
        }
      }
      catch
      {
        UI.Notify("Erorr 412");
      }
      try
      {
        if (this.missionnum == 4)
        {
          if ((Entity) this.Aircraft != (Entity) null && this.Aircraft.IsAlive && this.Aircraft.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
            Game.Player.SetExplosiveAmmoThisFrame();
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
            {
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
              ped.Task.FightAgainst(Game.Player.Character);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped, (InputArgument) 1);
            }
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
          if (!this.Aircraft.IsAlive)
          {
            this.MissionSetup = false;
            this.missionnum = 0;
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
            Script.Wait(500);
            Game.FadeScreenIn(500);
            UI.Notify(this.GetHostName() + "your aircraft was destroyed ");
            new MissionScreen().SetFail("Raising The Flag", 2200000, "Your Aircraft was destroyed");
          }
          if (!this.Sam1.IsAlive)
          {
            if (!this.Sam2.IsAlive)
            {
              if (!this.Sam3.IsAlive)
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
                Script.Wait(500);
                Game.FadeScreenIn(500);
                UI.Notify(this.GetHostName() + " ok good enemy vehicle Destroyed ");
                UI.Notify(this.GetHostName() + " Stocks just Increased");
                UI.Notify("Max Stocks: " + this.maxstocks.ToString());
                UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
                UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
                UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
                this.MissionSetup = false;
                this.missionnum = 0;
                new MissionScreen().SetPass("Raising The Flag", 1200000, "Your Aircraft was destroyed");
                this.stocksvalue = (float) ((double) this.stocksvalue + 1200000.0 + 100000.0 * (double) this.profitMargin / 100.0);
                this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                this.Config.Save();
              }
            }
          }
        }
      }
      catch
      {
        UI.Notify("Erorr 413");
      }
      try
      {
        if (this.missionnum == 3)
        {
          try
          {
            if (!this.Notify && Game.Player.WantedLevel == 0)
            {
              if ((Entity) this.Sam2 != (Entity) null)
                this.Sam2.Delete();
              if ((Entity) this.Sam3 != (Entity) null)
                this.Sam3.Delete();
            }
            if ((Entity) this.Sam1 != (Entity) null && this.Sam1.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && this.Notify)
            {
              Game.Player.WantedLevel = 4;
              this.Notify = false;
              UI.Notify(this.GetHostName() + " Boss Lose the cops before delivering the plane");
            }
            if ((Entity) this.Sam1 != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.Sam1.Position) < 100.0)
              this.Sam1.IsInvincible = false;
            if ((Entity) this.Sam1 != (Entity) null)
            {
              if (!this.Sam1.IsAlive)
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
                Script.Wait(500);
                Game.FadeScreenIn(500);
                UI.Notify(this.GetHostName() + " Boss we needed that vehicle");
                this.MissionSetup = false;
                this.missionnum = 0;
                this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                this.Config.Save();
              }
              if (this.Sam1.IsAlive)
              {
                if ((double) World.GetDistance(this.Sam1.Position, new Vector3(1678.99f, 3238.1f, 40f)) < 60.0)
                {
                  if (Game.Player.WantedLevel < 1)
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
                    if (this.DropPoint != (Blip) null)
                      this.DropPoint.Remove();
                    Script.Wait(500);
                    Game.FadeScreenIn(500);
                    UI.Notify(this.GetHostName() + " ok good shipment delivered");
                    UI.Notify(this.GetHostName() + " Stocks just Increased");
                    UI.Notify("Max Stocks: " + this.maxstocks.ToString());
                    UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
                    UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
                    UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
                    this.MissionSetup = false;
                    this.missionnum = 0;
                    Game.Player.Character.Position = new Vector3(1678.99f, 3238.1f, 40f);
                    this.stocksvalue = (float) ((double) this.stocksvalue + 100000.0 + 100000.0 * (double) this.profitMargin / 100.0);
                    this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                    this.Config.Save();
                  }
                  else
                    UI.Notify(this.GetHostName() + " Lose the cops before delivering the plane");
                }
              }
            }
          }
          catch
          {
            UI.Notify("Error 3");
          }
        }
        if (this.missionnum == 2)
        {
          try
          {
            if ((Entity) this.Sam1 != (Entity) null)
            {
              if (!this.Sam1.IsAlive)
              {
                if (this.Sam1blip != (Blip) null)
                  this.Sam1blip.Remove();
              }
              else
                this.Sam1blip.Position = this.Sam1.Position;
            }
            if ((Entity) this.Sam2 != (Entity) null)
            {
              if (!this.Sam2.IsAlive)
              {
                if (this.Sam2blip != (Blip) null)
                  this.Sam2blip.Remove();
              }
              else
                this.Sam2blip.Position = this.Sam2.Position;
            }
            if ((Entity) this.Sam3 != (Entity) null)
            {
              if (!this.Sam3.IsAlive)
              {
                if (this.Sam3blip != (Blip) null)
                  this.Sam3blip.Remove();
              }
              else
                this.Sam3blip.Position = this.Sam3.Position;
            }
            if ((Entity) this.Sam1 != (Entity) null)
            {
              if ((Entity) this.Sam2 != (Entity) null)
              {
                if ((Entity) this.Sam3 != (Entity) null)
                {
                  if (!this.Sam1.IsAlive)
                  {
                    if (!this.Sam2.IsAlive)
                    {
                      if (!this.Sam3.IsAlive)
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
                        Script.Wait(500);
                        Game.FadeScreenIn(500);
                        UI.Notify(this.GetHostName() + " ok good enemy vehicle Destroyed ");
                        UI.Notify(this.GetHostName() + " Stocks just Increased");
                        UI.Notify("Max Stocks: " + this.maxstocks.ToString());
                        UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
                        UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
                        UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
                        this.MissionSetup = false;
                        this.missionnum = 0;
                        this.stocksvalue = (float) ((double) this.stocksvalue + 100000.0 + 100000.0 * (double) this.profitMargin / 100.0);
                        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                        this.Config.Save();
                      }
                    }
                  }
                }
              }
            }
          }
          catch
          {
            UI.Notify("Error 2");
          }
        }
        if (this.missionnum == 1)
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
          if (!this.Sam1.IsAlive)
          {
            if (!this.Sam2.IsAlive)
            {
              if (!this.Sam3.IsAlive)
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
                Script.Wait(500);
                Game.FadeScreenIn(500);
                UI.Notify(this.GetHostName() + " ok good enemy vehicle Destroyed ");
                UI.Notify(this.GetHostName() + " Stocks just Increased");
                UI.Notify("Max Stocks: " + this.maxstocks.ToString());
                UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
                UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
                UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
                this.MissionSetup = false;
                this.missionnum = 0;
                this.stocksvalue = (float) ((double) this.stocksvalue + 100000.0 + 100000.0 * (double) this.profitMargin / 100.0);
                this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                this.Config.Save();
              }
            }
          }
        }
      }
      catch
      {
        UI.Notify("Erorr 414");
      }
      if (this.UseOldMarker && (double) World.GetDistance(Game.Player.Character.Position, this.BSMarker) < 2.0)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open the Business Menu");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Marker2) < 2.0)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Source a plane or heli");
      if (!((Entity) this.Plane != (Entity) null))
        return;
      if (!this.Plane.IsAlive)
      {
        this.Plane.Delete();
        if (this.PlaneBlip != (Blip) null)
          this.PlaneBlip.Remove();
      }
      if (!(this.PlaneBlip != (Blip) null))
        return;
      this.PlaneBlip.Position = this.Plane.Position;
    }

    public void LoadCarinToRealWorld(Vehicle V)
    {
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      this.SetInInterior(false);
      this.IsInInterior = false;
      if (this.BusinessLocation == 0)
      {
        currentVehicle.Position = new Vector3(-979.49f, -3340.52f, 14f);
        this.PlaneHeading = 55f;
      }
      if (this.BusinessLocation == 1)
      {
        currentVehicle.Position = new Vector3(-979.49f, -3340.52f, 14f);
        this.PlaneHeading = 55f;
      }
      if (this.BusinessLocation == 2)
      {
        currentVehicle.Position = new Vector3(-1963f, 2833f, 33f);
        this.PlaneHeading = 49f;
      }
      if (this.BusinessLocation == 3)
      {
        currentVehicle.Position = new Vector3(-1963f, 2833f, 33f);
        this.PlaneHeading = 49f;
      }
      if (this.BusinessLocation == 4)
      {
        currentVehicle.Position = new Vector3(-1963f, 2833f, 33f);
        this.PlaneHeading = 49f;
      }
      Game.Player.Character.SetIntoVehicle(currentVehicle, VehicleSeat.Driver);
      this.DestoryCars();
      currentVehicle.IsDriveable = true;
      this.SaveVehicle = currentVehicle;
      this.SaveVehicle.FreezePosition = false;
      this.SaveVehicle.IsDriveable = true;
      this.SaveVehicle.IsInvincible = false;
      this.SaveVehicle.Heading = this.PlaneHeading;
      this.SaveVehicle.Repair();
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

    public void OnKeyDown()
    {
      if (this.IsInInterior && (double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) < 2.0)
      {
        if (this.IsSittinginCeoSeat)
        {
          if (Game.IsControlJustPressed(2, GTA.Control.FrontendPauseAlternate) && this.mainMenu.Visible)
          {
            Prop exChair = this.ExChair;
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exChair.Position.X, (InputArgument) exChair.Position.Y, (InputArgument) exChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exChair.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_exit", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exChair, (InputArgument) num, (InputArgument) "computer_exit_chair", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Context) && !this.BSmainMenu.Visible)
          {
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ExChair.Position.X, (InputArgument) this.ExChair.Position.Y, (InputArgument) this.ExChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ExChair.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ExChair, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(100);
            this.BSmainMenu.Visible = !this.BSmainMenu.Visible;
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            this.BSmodMenuPool.CloseAllMenus();
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ExChair.Position.X, (InputArgument) this.ExChair.Position.Y, (InputArgument) this.ExChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ExChair.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "exit", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ExChair, (InputArgument) num, (InputArgument) "exit_chair", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(4000);
            Game.Player.Character.Task.ClearAll();
            this.IsSittinginCeoSeat = false;
          }
        }
        else if (!this.IsSittinginCeoSeat && Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          Script.Wait(100);
          string str = "anim@amb@office@boss@male@";
          Hanger.LoadDict("anim@amb@office@boss@male@");
          if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) str))
          {
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ExChair.Position.X, (InputArgument) this.ExChair.Position.Y, (InputArgument) this.ExChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ExChair.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "enter", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ExChair, (InputArgument) num, (InputArgument) "enter_chair", (InputArgument) Hanger.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(5000);
            this.IsSittinginCeoSeat = true;
          }
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MissionMarker) < 30.0)
      {
        Model model = (Model) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "WEAPON_BRIEFCASE");
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
        World.ShootBullet(Game.Player.Character.Position, this.MissionMarker, Game.Player.Character, model, 15000);
        System.Random random = new System.Random();
        if (random.Next(1, 200) < 10)
          this.MissionMarker = new Vector3(352.317f, -588.422f, 75f);
        if (random.Next(1, 200) > 10 && random.Next(1, 200) < 20)
          this.MissionMarker = new Vector3(1390.55f, -475.575f, 91f);
        if (random.Next(1, 200) > 20 && random.Next(1, 200) < 30)
          this.MissionMarker = new Vector3(-913.852f, -379.479f, 137f);
        if (random.Next(1, 200) > 30 && random.Next(1, 200) < 40)
          this.MissionMarker = new Vector3(-143.393f, -592.794f, 212f);
        if (random.Next(1, 200) > 40 && random.Next(1, 200) < 50)
          this.MissionMarker = new Vector3(-204.066f, -849.04f, 118.653f);
        if (random.Next(1, 200) > 50 && random.Next(1, 200) < 60)
          this.MissionMarker = new Vector3(-1580.98f, -569.994f, 117.653f);
        if (random.Next(1, 200) > 60 && random.Next(1, 200) < 70)
          this.MissionMarker = new Vector3(-606.385f, -1769.89f, 43f);
        if (random.Next(1, 200) > 70 && random.Next(1, 200) < 80)
          this.MissionMarker = new Vector3(300f, -1453.89f, 46f);
        if (random.Next(1, 200) > 80 && random.Next(1, 200) < 90)
          this.MissionMarker = new Vector3(343f, -1419.89f, 76f);
        if (random.Next(1, 200) > 90 && random.Next(1, 200) < 100)
          this.MissionMarker = new Vector3(18f, -922f, 124f);
        if (random.Next(1, 200) > 100 && random.Next(1, 200) < 110)
          this.MissionMarker = new Vector3(871.142f, -1928f, 96f);
        if (random.Next(1, 200) > 110 && random.Next(1, 200) < 120)
          this.MissionMarker = new Vector3(968f, 40f, 108f);
        if (random.Next(1, 200) > 120 && random.Next(1, 200) < 130)
          this.MissionMarker = new Vector3(-179.233f, -156.882f, 94f);
        if (random.Next(1, 200) > 130 && random.Next(1, 200) < 140)
          this.MissionMarker = new Vector3(-518.76f, 211f, 95f);
        if (random.Next(1, 200) > 140 && random.Next(1, 200) < 150)
          this.MissionMarker = new Vector3(-1738.36f, 157.402f, 65f);
        if (random.Next(1, 200) > 150 && random.Next(1, 200) < 160)
          this.MissionMarker = new Vector3(-2209.58f, 251.899f, 198.689f);
        if (random.Next(1, 200) > 160 && random.Next(1, 200) < 170)
          this.MissionMarker = new Vector3(1272.27f, 208f, 83f);
        if (random.Next(1, 200) > 170 && random.Next(1, 200) < 180)
          this.MissionMarker = new Vector3(-1014f, -1924f, 21f);
        if (random.Next(1, 200) > 180 && random.Next(1, 200) < 190)
          this.MissionMarker = new Vector3(-974.201f, -2970f, 54f);
        if (random.Next(1, 200) > 180 && random.Next(1, 200) < 190)
          this.MissionMarker = new Vector3(244f, -3185f, 42f);
        if (random.Next(1, 200) > 190 && random.Next(1, 200) < 200)
          this.MissionMarker = new Vector3(-974.201f, -2970f, 54f);
        if (this.shipmentsDElivered != 4)
        {
          ++this.shipmentsDElivered;
          UI.Notify(this.GetHostName() + " Ok a shipment has been delivered");
        }
        else
        {
          this.shipmentsDElivered = 0;
          this.DeliveryMissionOn = false;
          UI.Notify(this.GetHostName() + " Ok all shipments have been delivered");
          UI.Notify(this.GetHostName() + " Stocks just Increased");
          UI.Notify("Max Stocks: " + this.maxstocks.ToString());
          UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
          UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
          UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
          this.MissionSetup = false;
          this.missionnum = 0;
          this.stocksvalue = (float) ((double) this.stocksvalue + 150000.0 + 150000.0 * (double) this.profitMargin / 100.0);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.BSMarker) < 2.0 && this.IsInInterior)
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
        if (!this.BSmainMenu.Visible)
          this.BSmainMenu.Visible = !this.BSmainMenu.Visible;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.Marker2) < 2.0 && this.IsInInterior)
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
        if (!this.BSmainMenu.Visible)
          this.BSmainMenu2.Visible = !this.BSmainMenu2.Visible;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.Marker) < 2.0 && (this.IsInInterior && !this.CHmainMenu.Visible))
        this.CHmainMenu.Visible = !this.CHmainMenu.Visible;
      if (this.CHmodMenuPool != null && this.CHmodMenuPool.IsAnyMenuOpen())
        this.CHmodMenuPool.ProcessMenus();
      if (this.IsInInterior)
        World.DrawMarker(MarkerType.VerticalCylinder, this.Marker, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Marker) < 2.0)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open Interior Customize Menu");
      if (!this.FirstTime)
      {
        this.FirstTime = true;
        try
        {
          this.ExChairPos = new Vector3(-1239.287f, -3001.7f, -43.8f);
          this.ExChair = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ExChairPos, new Vector3(0.0f, 0.0f, -66f), false, false);
          this.ExChair.FreezePosition = true;
        }
        catch (Exception ex)
        {
          UI.Notify("~r~ Error~w~ Could not find Chair Prop Model!, Model has been added to ini, no need to take action");
          UI.Notify("~g~ HKH191~w~ Chair Prop Models Were not found, please Reload the mod ");
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
          this.ChairPropModel = "ex_prop_offchair_exec_01";
          this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
          this.Config.Save();
          this.Config.SetValue<string>("Chair Model", "POSSIBLECHAIRPROPMODELS", "'ex_prop_offchair_exec_01', 'ex_prop_offchair_exec_02', 'ex_prop_offchair_exec_03', 'ex_prop_offchair_exec_04', 'ba_prop_battle_club_chair_01', 'ba_prop_battle_club_chair_02', 'ba_prop_battle_club_chair_03' ");
          this.Config.Save();
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SleepPos2) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        Game.Player.Character.FreezePosition = true;
        Game.FadeScreenOut(500);
        Script.Wait(500);
        Function.Call(Hash._0xC8CA9670B9D83B3B, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0);
        Game.Player.WantedLevel = 0;
        Function.Call(Hash._0x8FE22675A5A45817, (InputArgument) Game.Player.Character);
        Function.Call(Hash._0x9C720776DAA43E7E, (InputArgument) Game.Player.Character);
        Game.Player.Character.Position = this.SleepPos2;
        Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
        Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
        Game.Player.Character.FreezePosition = false;
        Script.Wait(1500);
        Game.FadeScreenIn(500);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SleepPos2) < 2.0)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sleep");
      if (this.GLmodMenuPool != null && this.GLmodMenuPool.IsAnyMenuOpen())
        this.GLmodMenuPool.ProcessMenus();
      if (this.GunlockerBought == 1)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.Gunlockerpos) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context) && !this.GLmainMenu.Visible)
          this.GLmainMenu.Visible = !this.GLmainMenu.Visible;
        if ((double) World.GetDistance(Game.Player.Character.Position, this.Gunlockerpos) < 3.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ open Gun Locker");
        World.DrawMarker(MarkerType.VerticalCylinder, this.Gunlockerpos, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
      }
      int gunLockerBought = this.GunLockerBought;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 2.0 && !this.MVmainMenu.Visible)
        this.MVmainMenu.Visible = !this.MVmainMenu.Visible;
      if (this.MVmodMenuPool != null && this.MVmodMenuPool.IsAnyMenuOpen())
        this.MVmodMenuPool.ProcessMenus();
      if ((double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 40.0)
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
      if (this.MoneyVaultBought == 1)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 3.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ open money vault");
        if ((double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 40.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.MoneyStorageMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 100.0)
      {
        if (this.Range == (Blip) null)
          this.setupMarker();
      }
      else if ((double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) >= 100.0 && this.Range != (Blip) null)
        this.DeleteMarker();
      if (this.BusinessLocation != 2 && this.BusinessLocation != 3 && (this.BusinessLocation != 4 && (double) World.GetDistance(Game.Player.Character.Position, this.FZHanger1Pos) < 1250.0) && !this.Warned)
      {
        Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "am_armybase");
        Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "re_armybase");
        Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "RestrictedAreas");
        this.Warned = true;
      }
      if (this.BusinessLocation == 2 || this.BusinessLocation == 3 || (this.BusinessLocation == 4 || this.UnrestictedAccessInFortZancudo == 1))
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.FZHanger1Pos) < 1250.0)
        {
          if (this.UnrestictedAccessInFortZancudoVIP == 0)
          {
            Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "am_armybase");
            Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "re_armybase");
            Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "RestrictedAreas");
          }
          if (this.UnrestictedAccessInFortZancudoVIP == 1)
          {
            if (this.TimerCheck != 1200)
              ++this.TimerCheck;
            if (this.TimerCheck == 1200)
            {
              if (Game.Player.WantedLevel != 0)
                this.isWanted = true;
              if (Game.Player.WantedLevel == 0)
                this.isWanted = false;
              this.TimerCheck = 0;
            }
            if (!this.isWanted)
            {
              Game.Player.IgnoredByEveryone = true;
              Game.Player.IgnoredByPolice = true;
              Game.Player.WantedLevel = 0;
              Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "am_armybase");
              Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "re_armybase");
              Function.Call(Hash._0x9DC711BC69C548DF, (InputArgument) "RestrictedAreas");
            }
          }
          if (!this.Warned)
          {
            this.Warned = true;
            if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (Game.Player.Character.CurrentVehicle.ClassType == VehicleClass.Helicopters || Game.Player.Character.CurrentVehicle.ClassType == VehicleClass.Planes))
              this.DisplayHelpTextThisFrame("Entering Fort Zancudo Air Space, Player will not be targeted");
          }
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.FZHanger1Pos) > 1250.0 && this.Warned)
        {
          Game.Player.IgnoredByEveryone = false;
          Game.Player.IgnoredByPolice = false;
          this.Warned = false;
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (Game.Player.Character.CurrentVehicle.ClassType == VehicleClass.Helicopters || Game.Player.Character.CurrentVehicle.ClassType == VehicleClass.Planes))
            this.DisplayHelpTextThisFrame("Exiting Fort Zancudo Air Space, Player will be targeted");
        }
      }
      if (this.FZHanger3Bought == 1 || this.FZHanger2Bought == 1 || this.FZHanger1Bought == 1)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.FZHanger3Pos) < 1000.0)
        {
          Function.Call(Hash._0xAA5F02DB48D704B9, (InputArgument) 0);
          Function.Call(Hash._0xDB172424876553F4, (InputArgument) false);
          Game.Player.Character.CanBeTargetted = false;
          this.IsInRestictedZone = true;
          Function.Call(Hash._0x32C62AA929C2DA6A, (InputArgument) Game.Player, (InputArgument) true);
          Vehicle[] nearbyVehicles = World.GetNearbyVehicles(Game.Player.Character, 2000f);
          for (int index = 0; index < nearbyVehicles.Length; ++index)
          {
            if ((Entity) nearbyVehicles[index] != (Entity) Game.Player.Character.CurrentVehicle && nearbyVehicles[index].DisplayName.Equals("LAZER") && (Entity) nearbyVehicles[index].GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
            {
              UI.Notify("Deleted Vehicle");
              if ((Entity) nearbyVehicles[index].GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
                nearbyVehicles[index].Delete();
            }
          }
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.FZHanger2Pos) > 1000.0 && this.IsInRestictedZone)
        {
          this.IsInRestictedZone = false;
          Game.Player.Character.CanBeShotInVehicle = true;
          Function.Call(Hash._0xAA5F02DB48D704B9, (InputArgument) 5);
          Function.Call(Hash._0xDB172424876553F4, (InputArgument) true);
          Game.Player.Character.CanBeTargetted = true;
          Function.Call(Hash._0x32C62AA929C2DA6A, (InputArgument) Game.Player, (InputArgument) false);
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.FZHanger1Pos) > 1000.0 && this.IsInRestictedZone)
        {
          this.IsInRestictedZone = false;
          Function.Call(Hash._0xAA5F02DB48D704B9, (InputArgument) 5);
          Function.Call(Hash._0xDB172424876553F4, (InputArgument) true);
          Game.Player.Character.CanBeTargetted = true;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.FZHanger3Pos) > 1000.0 && this.IsInRestictedZone)
        {
          this.IsInRestictedZone = false;
          Function.Call(Hash._0xAA5F02DB48D704B9, (InputArgument) 5);
          Function.Call(Hash._0xDB172424876553F4, (InputArgument) true);
          Game.Player.Character.CanBeTargetted = true;
          Function.Call(Hash._0x32C62AA929C2DA6A, (InputArgument) Game.Player, (InputArgument) false);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2399.7f, 718.1f, 221.4f)) < 2.0 && Game.Player.Character.Alpha == 15)
      {
        this.MainModDestroy();
        this.MainModRefresh();
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 100.0)
        World.DrawMarker(MarkerType.VerticalCylinder, this.Entry, Vector3.Zero, Vector3.Zero, new Vector3(5f, 5f, 0.65f), this.MarkerColor);
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 2.0)
      {
        if (this.purchaselvl == 0)
          this.DisplayHelpTextThisFrame("Purchase this Business via ~g~ HKH191s Business Helper ~w~~INPUT_CONTEXT~ Set Waypoint to Marker");
        if (this.purchaselvl >= 1)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Enter Hanger or press ~INPUT_COVER~ to open the vehicle menu");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 40.0 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Model model = Game.Player.Character.CurrentVehicle.Model;
        if (!model.IsHelicopter)
        {
          model = Game.Player.Character.CurrentVehicle.Model;
          if (!model.IsPlane)
            goto label_162;
        }
        model = Game.Player.Character.CurrentVehicle.Model;
        Vector3 dimensions = model.GetDimensions();
        int num = (int) dimensions.X + (int) dimensions.Y + (int) dimensions.Z;
        if (num >= 60)
          UI.ShowSubtitle("Player In Large Aircraft");
        if (num >= 25 && num < 60)
          UI.ShowSubtitle("Player In Medium Sized Aircraft");
        if (num < 25)
          UI.ShowSubtitle("Player In Small Aircraft");
label_162:
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Save this vehicle into the Hanger");
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        int purchaselvl = this.purchaselvl;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.CamAPos) < 20.0 && this.ISinviewMode)
      {
        if ((Entity) this.Vehicle1 != (Entity) null)
        {
          this.Vehicle1.Rotation = new Vector3(0.0f, 0.0f, this.Vehicle1.Rotation.Z);
          Vector3 vector3 = this.Vehicle1.Rotation;
          float z = this.Vehicle1.Rotation.Z;
          float num;
          vector3 = new Vector3(0.0f, 0.0f, num = z + 0.5f);
          this.Vehicle1.Rotation = vector3;
        }
        if (!this.modMenuPool.IsAnyMenuOpen())
        {
          this.ISinviewMode = false;
          Game.Player.Character.Position = this.Entry;
          Game.Player.Character.IsVisible = true;
          Game.Player.Character.FreezePosition = false;
          if (this.Cam != (Camera) null)
          {
            if ((Entity) this.Vehicle1 != (Entity) null)
              this.Vehicle1.Delete();
            World.RenderingCamera = this.Cam;
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.Cam.IsActive = false;
            this.Cam.Destroy();
          }
        }
      }
      if (this.IsInInterior && (double) World.GetDistance(Game.Player.Character.Position, this.Exit) < 100.0)
      {
        World.DrawMarker(MarkerType.VerticalCylinder, this.Exit, Vector3.Zero, Vector3.Zero, new Vector3(5f, 5f, 0.65f), this.MarkerColor);
        World.DrawMarker(MarkerType.VerticalCylinder, this.CarMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CarMarker) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Buy a Smuggler's Run Car");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker) < 2.0)
        this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to exit the garage");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.RemoveMarker) < 2.0)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Remove/Add a vehicle");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Exit) < 2.0)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Exit Hanger");
      if (this.IsInInterior)
        World.DrawMarker(MarkerType.VerticalCylinder, this.RemoveMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
      if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle11)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle12)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Car1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car1)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Car2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car2)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Car3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car3)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
        if ((Entity) this.Car4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car4)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 2.0)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Cover) && this.purchaselvl >= 1 && ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null && !this.mainMenu.Visible))
          this.mainMenu.Visible = !this.mainMenu.Visible;
        if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.purchaselvl >= 1)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
          {
            this.DestoryCars();
            this.LoadInterior();
            this.CreateCars("Hanger1");
            Game.FadeScreenOut(1500);
            Script.Wait(3500);
            this.SetInInterior(true);
            this.IsInInterior = true;
            Game.Player.Character.Position = this.Exit;
            Script.Wait(3500);
            Game.FadeScreenIn(1500);
            this.DeleteSGRCratesInHanger();
            this.CreateSGRCratesInHanger(this.stockscount);
            if ((Entity) this.SaveVehicle != (Entity) null)
              this.SaveVehicle.Delete();
          }
          else if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            if (!this.mainMenu.Visible)
              this.mainMenu.Visible = !this.mainMenu.Visible;
          }
          else if (!this.mainMenu.Visible)
            this.mainMenu.Visible = false;
          if ((Entity) this.Vehicle1 != (Entity) null)
            this.Vehicle1.IsInvincible = false;
          if ((Entity) this.Vehicle2 != (Entity) null)
            this.Vehicle2.IsInvincible = false;
          if ((Entity) this.Vehicle3 != (Entity) null)
            this.Vehicle3.IsInvincible = false;
          if ((Entity) this.Vehicle4 != (Entity) null)
            this.Vehicle4.IsInvincible = false;
          if ((Entity) this.Vehicle5 != (Entity) null)
            this.Vehicle5.IsInvincible = false;
          if ((Entity) this.Vehicle6 != (Entity) null)
            this.Vehicle6.IsInvincible = false;
          if ((Entity) this.Vehicle7 != (Entity) null)
            this.Vehicle7.IsInvincible = false;
          if ((Entity) this.Vehicle8 != (Entity) null)
            this.Vehicle8.IsInvincible = false;
          if ((Entity) this.Vehicle9 != (Entity) null)
            this.Vehicle9.IsInvincible = false;
          if ((Entity) this.Vehicle10 != (Entity) null)
            this.Vehicle10.IsInvincible = false;
          if ((Entity) this.Vehicle11 != (Entity) null)
            this.Vehicle11.IsInvincible = false;
          if ((Entity) this.Vehicle12 != (Entity) null)
            this.Vehicle12.IsInvincible = false;
        }
      }
      else if ((double) World.GetDistance(Game.Player.Character.Position, this.Exit) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context) && this.IsInInterior)
      {
        Game.FadeScreenOut(1500);
        Script.Wait(3500);
        this.DeleteSGRCratesInHanger();
        this.DestoryCars();
        Game.Player.Character.Position = this.Entry;
        this.mainMenu.Visible = false;
        this.SetInInterior(false);
        this.SetInInterior(false);
        this.IsInInterior = false;
        Script.Wait(3500);
        Game.FadeScreenIn(1500);
        this.mainMenu.Visible = false;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 40.0 && ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && !this.IsInInterior) && !this.mainMenu.Visible)
        this.mainMenu.Visible = !this.mainMenu.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) < 2.0 && (this.IsInInterior && !this.mainMenu.Visible))
        this.mainMenu.Visible = !this.mainMenu.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.RemoveMarker) < 2.0 && (this.IsInInterior && !this.mainMenu2.Visible))
        this.mainMenu2.Visible = !this.mainMenu2.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.CarMarker) < 2.0 && (this.IsInInterior && !this.CarMenu.Visible))
        this.CarMenu.Visible = !this.CarMenu.Visible;
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
        if ((Entity) this.Car1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car1)
        {
          this.Car1 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Car1);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Car2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car2)
        {
          this.Car2 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Car2);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Car3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car3)
        {
          this.Car3 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Car3);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
        if ((Entity) this.Car4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car4)
        {
          this.Car4 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Car4);
          this.DisplayHelpTextThisFrame("Press E to use this vehicle");
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
          this.SaveCurrentVehicleInSlot("Slot1");
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
          this.SaveCurrentVehicleInSlot("Slot2");
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
          this.SaveCurrentVehicleInSlot("Slot3");
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
          this.SaveCurrentVehicleInSlot("Slot4");
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
          this.SaveCurrentVehicleInSlot("Slot5");
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
          this.SaveCurrentVehicleInSlot("Slot6");
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
          this.SaveCurrentVehicleInSlot("Slot7");
        if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
          this.SaveCurrentVehicleInSlot("Slot8");
        if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
          this.SaveCurrentVehicleInSlot("Slot9");
        if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
          this.SaveCurrentVehicleInSlot("Slot10");
        if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle11)
          this.SaveCurrentVehicleInSlot("Slot11");
        if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle12)
          this.SaveCurrentVehicleInSlot("Slot12");
        if ((Entity) this.Car1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car1)
          this.SaveCarInSlot("Cyclone");
        if ((Entity) this.Car2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car2)
          this.SaveCarInSlot("RapidGT");
        if ((Entity) this.Car3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car3)
          this.SaveCarInSlot("Retinue");
        if ((Entity) this.Car4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Car4)
          this.SaveCarInSlot("Visione");
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker) < 2.0)
      {
        Script.Wait(300);
        this.DestoryCars();
        this.SetInInterior(false);
        this.IsInInterior = false;
        Game.Player.Character.Position = this.EntryMarker;
      }
      Game.IsControlJustPressed(2, GTA.Control.Cover);
    }

    public void DestoryCars()
    {
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
      if ((Entity) this.Car1 != (Entity) null)
        this.Car1.Delete();
      if ((Entity) this.Car2 != (Entity) null)
        this.Car2.Delete();
      if ((Entity) this.Car3 != (Entity) null)
        this.Car3.Delete();
      if (!((Entity) this.Car4 != (Entity) null))
        return;
      this.Car4.Delete();
    }

    public void CreateCars(string Garage)
    {
      this.DestoryCars();
      try
      {
        this.SC.LoadIniFile(this.path + Garage + "//Slot1.ini");
        Model model1 = this.SC.CheckCar(this.path + Garage + "//Slot1.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot2.ini");
        Model model2 = this.SC.CheckCar(this.path + Garage + "//Slot2.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot3.ini");
        Model model3 = this.SC.CheckCar(this.path + Garage + "//Slot3.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot4.ini");
        Model model4 = this.SC.CheckCar(this.path + Garage + "//Slot4.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot5.ini");
        Model model5 = this.SC.CheckCar(this.path + Garage + "//Slot5.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot6.ini");
        Model model6 = this.SC.CheckCar(this.path + Garage + "//Slot6.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot7.ini");
        Model model7 = this.SC.CheckCar(this.path + Garage + "//Slot7.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot8.ini");
        Model model8 = this.SC.CheckCar(this.path + Garage + "//Slot8.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot9.ini");
        Model model9 = this.SC.CheckCar(this.path + Garage + "//Slot9.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot10.ini");
        Model model10 = this.SC.CheckCar(this.path + Garage + "//Slot10.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot11.ini");
        Model model11 = this.SC.CheckCar(this.path + Garage + "//Slot11.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot12.ini");
        Model model12 = this.SC.CheckCar(this.path + Garage + "//Slot12.ini");
        this.SC.LoadIniFile(this.path2 + "Garage1//Cyclone.ini");
        Model model13 = this.SC.CheckCar(this.path2 + "Garage1//Cyclone.ini");
        this.SC.LoadIniFile(this.path2 + "Garage1//RapidGT.ini");
        Model model14 = this.SC.CheckCar(this.path2 + "Garage1//RapidGT.ini");
        this.SC.LoadIniFile(this.path2 + "Garage1//Retinue.ini");
        Model model15 = this.SC.CheckCar(this.path2 + "Garage1//Retinue.ini");
        this.SC.LoadIniFile(this.path2 + "Garage1//Visione.ini");
        Model model16 = this.SC.CheckCar(this.path2 + "Garage1//Visione.ini");
        if (model2 != (Model) "null" && model2 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot2.ini");
          this.Vehicle2 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot2.ini"), this.Vehicle2Loc, -45f);
          this.SC.Load(this.Vehicle2);
          this.Vehicle2.IsDriveable = false;
        }
        if (model3 != (Model) "null" && model3 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot3.ini");
          this.Vehicle3 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot3.ini"), this.Vehicle3Loc, 45f);
          this.SC.Load(this.Vehicle3);
          this.Vehicle3.IsDriveable = false;
        }
        if (model1 != (Model) "null" && model1 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot1.ini");
          Model model17 = this.SC.CheckCar2(this.path + Garage + "//Slot1.ini");
          if (model17 == (Model) "VOLATOL")
          {
            if ((Entity) this.Vehicle2 != (Entity) null)
              this.Vehicle2.Delete();
            if ((Entity) this.Vehicle3 != (Entity) null)
              this.Vehicle3.Delete();
          }
          this.Vehicle1 = World.CreateVehicle(model17, this.Vehicle1Loc, 0.0f);
          this.SC.Load(this.Vehicle1);
          this.Vehicle1.IsDriveable = false;
        }
        if (model4 != (Model) "null" && model4 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot4.ini");
          this.Vehicle4 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot4.ini"), this.Vehicle4Loc, -45f);
          this.SC.Load(this.Vehicle4);
          this.Vehicle4.IsDriveable = false;
        }
        if (model5 != (Model) "null" && model5 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot5.ini");
          this.Vehicle5 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot5.ini"), this.Vehicle5Loc, 45f);
          this.SC.Load(this.Vehicle5);
          this.Vehicle5.IsDriveable = false;
        }
        if (model6 != (Model) "null" && model6 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot6.ini");
          this.Vehicle6 = World.CreateVehicle((Model) this.SC.VehicleName, this.Vehicle6Loc, 0.0f);
          this.SC.Load(this.Vehicle6);
          this.Vehicle6.IsDriveable = false;
        }
        if (model7 != (Model) "null" && model7 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot7.ini");
          this.Vehicle7 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot7.ini"), this.Vehicle7Loc, -45f);
          this.SC.Load(this.Vehicle7);
          this.Vehicle7.IsDriveable = false;
        }
        if (model8 != (Model) "null" && model8 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot8.ini");
          this.Vehicle8 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot8.ini"), this.Vehicle8Loc, 45f);
          this.SC.Load(this.Vehicle8);
          this.Vehicle8.IsDriveable = false;
        }
        if (model9 != (Model) "null" && model9 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot9.ini");
          this.Vehicle9 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot9.ini"), this.Vehicle9Loc, 0.0f);
          this.SC.Load(this.Vehicle9);
          this.Vehicle9.IsDriveable = false;
        }
        if (model10 != (Model) "null" && model10 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot10.ini");
          this.Vehicle10 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot10.ini"), this.Vehicle10Loc, 45f);
          this.SC.Load(this.Vehicle10);
          this.Vehicle10.IsDriveable = false;
        }
        if (model11 != (Model) "null" && model11 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot11.ini");
          this.Vehicle11 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot11.ini"), this.Vehicle11Loc, -45f);
          this.SC.Load(this.Vehicle11);
          this.Vehicle11.IsDriveable = false;
        }
        if (model12 != (Model) "null" && model12 != (Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot12.ini");
          this.Vehicle12 = World.CreateVehicle(this.SC.CheckCar2(this.path + Garage + "//Slot12.ini"), this.Vehicle12Loc, 0.0f);
          this.SC.Load(this.Vehicle12);
          this.Vehicle12.IsDriveable = false;
        }
        Model model18 = (Model) "null";
        if (model13 != model18 && this.CycloneBought == 1)
        {
          this.SC.LoadIniFile(this.path2 + "Garage1//Cyclone.ini");
          this.Car1 = World.CreateVehicle(this.SC.CheckCar2(this.path2 + "Garage1//Cyclone.ini"), this.Car1Loc, 180f);
          this.SC.Load(this.Car1);
          this.Car1.IsDriveable = false;
        }
        if (model14 != (Model) "null" && this.RapidGTBought == 1)
        {
          this.SC.LoadIniFile(this.path2 + "Garage1//RapidGT.ini");
          this.Car2 = World.CreateVehicle(this.SC.CheckCar2(this.path2 + "Garage1//RapidGT.ini"), this.Car2Loc, 180f);
          this.SC.Load(this.Car2);
          this.Car2.IsDriveable = false;
        }
        if (model15 != (Model) "null" && this.RetinueBought == 1)
        {
          this.SC.LoadIniFile(this.path2 + "Garage1//Retinue.ini");
          this.Car3 = World.CreateVehicle(this.SC.CheckCar2(this.path2 + "Garage1//Retinue.ini"), this.Car3Loc, 180f);
          this.SC.Load(this.Car3);
          this.Car3.IsDriveable = false;
        }
        if (model16 != (Model) "null" && this.VisioneBought == 1)
        {
          this.SC.LoadIniFile(this.path2 + "Garage1//Visione.ini");
          this.Car4 = World.CreateVehicle(this.SC.CheckCar2(this.path2 + "Garage1//Visione.ini"), this.Car4Loc, 180f);
          this.SC.Load(this.Car4);
          this.Car4.IsDriveable = false;
        }
        this.GarageNum = Garage;
      }
      catch (NullReferenceException ex)
      {
        UI.Notify("Smuggler's Run Business Hanger : Somthing went wrong while loading The Hanger Vehiles, please exit hanger and re enter, if this persists check your Hanger inis for invalid vehicle names");
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

    public enum Nodetype
    {
      AnyRoad,
      Road,
      Offroad,
      Water,
    }
  }
}
