using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MethBuisness
{
  public class SecondBusiness : Script
  {
    public BlipColor Safehouse_Colour;
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    public Color SafehouseMColor;
    public string SafehouseMColorString;
    private ScriptSettings MainConfigFile;
    public bool UseNewEnterance;
    public Blip CocaineBlip;
    public Blip WeedBlip;
    public Blip MoneyForgeBlip;
    public Blip FakeIDBlip;
    public Blip MethBlip;
    public Vector3 WeedFarmExit = new Vector3(416.9f, 6520.6f, 26.5f);
    public Vector3 ForgeryExit = new Vector3(-1090.7f, 2715.4f, 18.5f);
    public Vector3 MoneyPrinterExit = new Vector3(-433.9f, -160f, 36.5f);
    public Vector3 CocaineExit = new Vector3(1701.4f, 4857.8f, 41.5f);
    public Vector3 MethLabExit = new Vector3(916.8f, 3576.8f, 32.5f);
    public Vector3 LastEnt;
    public bool CreatedChairs;
    private ScriptSettings Config;
    private Keys Key1;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private UIMenu Buy;
    private UIMenu Sell;
    private UIMenu Enter;
    public Blip ballasBlip1;
    public int waittime;
    public Vector3 SecondBusinessLoc = new Vector3(854.195f, -2095.18f, 29f);
    public int ForgeryBought;
    public int MoneyPrinterBought;
    public int WeedFarmBought;
    public int CocaineBought;
    public int MethLabBought;
    public Vector3 WeedFarmEnter;
    public Vector3 ForgeryEnter;
    public Vector3 MoneyPrinterEnter;
    public Vector3 CocaineEnter;
    public Vector3 MethLabEnter;
    public Vector3 WeedMenu;
    public Vector3 ForgeryMenu;
    public Vector3 MoneyPrinterMenu;
    public Vector3 CocaineMenu;
    public Vector3 MethMenu;
    private MenuPool MethMenuPool;
    private UIMenu MethUIMenu;
    private UIMenu MethProduce;
    private UIMenu MethSell;
    private MenuPool ForgeryMenuPool;
    private UIMenu ForgeryUIMenu;
    private UIMenu ForgeryProduce;
    private UIMenu ForgerySell;
    private MenuPool MoneyPrinterMenuPool;
    private UIMenu MoneyPrinterUIMenu;
    private UIMenu MoneyProduce;
    private UIMenu MoneySell;
    private MenuPool CocaineMenuPool;
    private UIMenu CocaineUIMenu;
    private UIMenu CocaineProduce;
    private UIMenu CocaineSell;
    private MenuPool WeedMenuPool;
    private UIMenu WeedUIMenu;
    private UIMenu WeedProduce;
    private UIMenu WeedSell;
    public Class1 Main = new Class1(false);
    public float timer;
    public AllStock AllStocks;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public List<Vector3> DropPoint;
    public List<Blip> DropBlip;
    public int Droptype;
    public Vehicle DropVehicle;
    public Blip DropVehicleBlip;
    public int missionnum;
    public bool PlayingMission;
    public int PointsBeenAt;
    public float amountToSell;
    public int StockAmount;
    public float vehicleHealth;
    public bool ShowCompletion;
    public int StockTimer;
    public bool ProducingMeth;
    public bool ProducingCocaine;
    public bool ProducingWeed;
    public bool ProducingCounterfeit;
    public bool ProducingForgery;
    public bool EnteredMethYet;
    public bool EnteredCocaineYet;
    public bool EnteredForgeryYet;
    public bool EnteredFakeIDYet;
    public bool EnteredWeedYet;
    public int AmttoDeliver;
    public bool killedDriver;
    public Vector3 BallasSpawn;
    public Vector3 VagosSpawn;
    public Vector3 FamiliesSpawn;
    public List<Ped> Gang = new List<Ped>();
    public UIMenu FailedPeaceTreaty;
    public bool NOTIFY;
    public bool AllEliminated;
    public bool ExitVehicle;
    public List<Vehicle> GangVehicles = new List<Vehicle>();
    private UIMenu SubBusinessRaid;
    public bool isAtSubBusiness;
    public bool MissionSetup;
    public int mission;
    public bool StartedRaid;
    public Vector3 SubBusinessLoc = new Vector3(856.399f, -2091f, 29f);
    public float SpawnAttackerTimer;
    public bool RaidSetup;
    public float BusinessUpgradeIncreaseGain = 75000f;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    public bool UseOldMarker;
    public bool IsSittinginCeoSeat;
    public Vector3 ChairPos_1 = new Vector3(1087.581f, -3194.409f, -39.95f);
    public float P_Rotation_1 = 45f;
    public Prop ChairProp_1;
    public Vector3 ChairPos_2 = new Vector3(1129.197f, -3194.384f, -41.4f);
    public float P_Rotation_2 = -60f;
    public Prop ChairProp_2;
    public Vector3 ChairPos_3 = new Vector3(1044.225f, -3194.555f, -39.1f);
    public float P_Rotation_3 = -135f;
    public Prop ChairProp_3;
    public Vector3 ChairPos_4 = new Vector3(1160.49f, -3192.012f, -39.95f);
    public float P_Rotation_4 = 130f;
    public Prop ChairProp_4;
    public Vector3 ChairPos_5 = new Vector3(1001.993f, -3195.327f, -39.95f);
    public float P_Rotation_5 = -30f;
    public Prop ChairProp_5;
    public int MethMCbusinessLoc = 0;
    public int WeedMCbusinessLoc = 0;
    public int CocaineMCbusinessLoc = 0;
    public int CounterfietMCbusinessLoc = 0;
    public int ForgeryMCbusinessLoc = 0;
    public bool SetupBlipsFT;
    public List<Blip> MCBusinessLocBlips = new List<Blip>();
    public List<SecondBusiness.MCBusinessLocations> MCSubLocMeth = new List<SecondBusiness.MCBusinessLocations>()
    {
      new SecondBusiness.MCBusinessLocations(1, "Meth Lab", new Vector3(202.045f, 2461.467f, 54.7f), 20f, "Right", new Vector3(212.0342f, 2469.23f, 54.2f), 8f, 910000f, "Grand Senora", new Vector3(219.4f, 2451.9f, 57f), 54f),
      new SecondBusiness.MCBusinessLocations(1, "Meth Lab", new Vector3(48.87f, 6304.659f, 30.6f), 38f, "Right", new Vector3(39.9f, 6295.227f, 30.3f), 27f, 1024000f, "Paleto", new Vector3(53.77f, 6291.101f, 31f), 24f),
      new SecondBusiness.MCBusinessLocations(1, "Meth Lab", new Vector3(1180.662f, -3113.671f, 5.1f), -93f, "Right", new Vector3(1189.169f, -3104.305f, 4.8f), 0.0f, 1365000f, "Terminal", new Vector3(1167.325f, -3110.371f, 5.8f), -102f),
      new SecondBusiness.MCBusinessLocations(1, "Meth Lab", new Vector3(1440.233f, -1669.454f, 65.5f), -65f, "Left", new Vector3(1452.362f, -1687.526f, 65f), 148f, 1729000f, "El Burro Heights", new Vector3(1433.046f, -1679.214f, 68f), -43f),
      new SecondBusiness.MCBusinessLocations(1, "Meth Lab", new Vector3(917.0491f, 3576.719f, 32.5f), 84f, "Right", new Vector3(913.4601f, 3589.332f, 32.5f), -90f, 1950000f, "Sandy Shores", new Vector3(936.0736f, 3586.559f, 34f), 102f)
    };
    public List<SecondBusiness.MCBusinessLocations> MCSubLocCocaine = new List<SecondBusiness.MCBusinessLocations>()
    {
      new SecondBusiness.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(1678.777f, 4863.57f, 41.1f), -93f, "Right", new Vector3(1709.077f, 4807.59f, 41f), 88f, 745000f, "Grapeseed", new Vector3(1717.16f, 4866.677f, 45f), 115f),
      new SecondBusiness.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(387.5449f, 3585.162f, 32.5f), 163f, "Right", new Vector3(379.3169f, 3592.716f, 32.2f), -73f, 975000f, "Alamo Sea", new Vector3(390.55f, 3604.774f, 33.2f), 167f),
      new SecondBusiness.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(52.163f, 6486.41f, 30.5f), 138f, "Right", new Vector3(56.68f, 6465.962f, 30.3f), 134f, 1098000f, "Paleto", new Vector3(71.51f, 6470.393f, 31f), 50f),
      new SecondBusiness.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(-210.7f, -2580.158f, 5f), 88f, "Right", new Vector3(-261.05f, -2578.6f, 5f), -4f, 1462000f, "Elysian Island", new Vector3(-217.13f, -2486.512f, 6f), -94f),
      new SecondBusiness.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(-1462.01f, -382.291f, 37.5f), 41f, "Right", new Vector3(-1468.424f, -390.9298f, 37.6f), 139f, 1852000f, "Morningwood", new Vector3(-1450.121f, -385.002f, 38.1f), 94f)
    };
    public List<SecondBusiness.MCBusinessLocations> MCSubLocWeed = new List<SecondBusiness.MCBusinessLocations>()
    {
      new SecondBusiness.MCBusinessLocations(3, "Weed Farm", new Vector3(1360.9f, 3603.283f, 34f), 20f, "Right", new Vector3(1375.448f, 3608.395f, 34f), -160f, 760000f, "Sandy Shores", new Vector3(1348.934f, 3586.757f, 34.8f), -23f),
      new SecondBusiness.MCBusinessLocations(3, "Weed Farm", new Vector3(2847.678f, 4449.97f, 47.5f), -70f, "Right", new Vector3(2882.437f, 4462.606f, 47.3f), -40f, 715000f, "San Chianski", new Vector3(2829.663f, 4444.71f, 48.6f), -73f),
      new SecondBusiness.MCBusinessLocations(3, "Weed Farm", new Vector3(417.2958f, 6520.75f, 26.6f), 82f, "Right", new Vector3(406.57f, 6487.349f, 27.3f), 179f, 802000f, "Paleto", new Vector3(435.45f, 6516.217f, 28.5f), 78f),
      new SecondBusiness.MCBusinessLocations(3, "Weed Farm", new Vector3(137.0862f, -2473.243f, 5f), 51f, "Right", new Vector3(136.3743f, -2480.311f, 5f), -36f, 1072000f, "Elysian Island", new Vector3(146.1162f, -2483.212f, 6f), 51f),
      new SecondBusiness.MCBusinessLocations(3, "Weed Farm", new Vector3(77.98f, 180.2876f, 103.5f), -30f, "Left", new Vector3(122.78f, 163.2095f, 103.8f), 70f, 1358000f, "Downtown Vinewood", new Vector3(84.97f, 164.24f, 108f), -75f)
    };
    public List<SecondBusiness.MCBusinessLocations> MCSubLocCounterfiet = new List<SecondBusiness.MCBusinessLocations>()
    {
      new SecondBusiness.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(-433.8169f, -160.37f, 36.7f), -60f, "Right", new Vector3(-393.089f, -139.269f, 37.4f), 30f, 762000f, "Burton", new Vector3(-444.2199f, -167.07f, 37.5f), -56f),
      new SecondBusiness.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(636.79f, 2784.694f, 41.1f), 8f, "Right", new Vector3(647.5464f, 2757.564f, 41f), -175f, 845000f, "Grand Senora", new Vector3(644.7108f, 2773.031f, 42f), 35f),
      new SecondBusiness.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(-413.068f, 6172.442f, 30.5f), 144f, "Right", new Vector3(-420.3352f, 6173.263f, 30.3f), -44f, 951000f, "Paleto", new Vector3(-406.74f, 6179.357f, 31.4f), 178f),
      new SecondBusiness.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(670.8732f, -2667.514f, 5.2f), -88f, "Right", new Vector3(665.9106f, -2676.63f, 5f), 88f, 1267000f, "Cypress Flats", new Vector3(652.5844f, -2669.22f, 6f), -92f),
      new SecondBusiness.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(-1154.091f, -1391.368f, 4.2f), 31f, "Right", new Vector3(-1173.426f, -1388.985f, 3.6f), 33f, 1605000f, "Vespucci Canals", new Vector3(-1149.638f, -1399.331f, 6f), 29f)
    };
    public List<SecondBusiness.MCBusinessLocations> MCSubLocForgery = new List<SecondBusiness.MCBusinessLocations>()
    {
      new SecondBusiness.MCBusinessLocations(5, "Forgery Office", new Vector3(1655.9f, 4862.316f, 41f), 101f, "Right", new Vector3(1637.37f, 4847.85f, 41f), -171f, 650000f, "Grapeseed", new Vector3(1675.548f, 4852.028f, 42.02f), 91f),
      new SecondBusiness.MCBusinessLocations(5, "Forgery Office", new Vector3(-163.4019f, 6334.985f, 30.5f), 131f, "Right", new Vector3(-170.1115f, 6311.16f, 30.3f), -132f, 732000f, "Paleto", new Vector3(-151.96f, 6344.84f, 31.4f), 132f),
      new SecondBusiness.MCBusinessLocations(5, "Forgery Office", new Vector3(-332.5401f, -2792.72f, 4.3f), -90f, "Right", new Vector3(-327.4135f, -2764.174f, 4f), 90f, 975000f, "Elysian Island", new Vector3(-344.46f, -2774.822f, 5f), -104f),
      new SecondBusiness.MCBusinessLocations(5, "Forgery Office", new Vector3(-1100.831f, 2723.169f, 18f), -138f, "Left", new Vector3(-1138.623f, 2685.009f, 17.7f), 166f, 995000f, "Zancudo River", new Vector3(-1101.594f, 2734.426f, 20f), 177f),
      new SecondBusiness.MCBusinessLocations(5, "Forgery Office", new Vector3(300.1986f, -759.1166f, 28.5f), 67f, "Left", new Vector3(305.54f, -696.8333f, 28f), -113f, 1235000f, "Textile City", new Vector3(316.1743f, -764.25f, 30f), 70f)
    };
    public List<Ped> Peds;
    public List<Vector3> pPosition;
    public List<float> pRotation;
    public bool ReadIni;
    public bool Createdpeds;
    public bool MaxWaitBasedonPurchaseLevel;
    public int VehiclesToDeliver;
    public Vehicle DeliverVehicle_1;
    public Vehicle DeliverVehicle_2;
    public Vehicle DeliverVehicle_3;
    public Vehicle DeliverVehicle_4;
    public UIMenu UpgradeBusiness;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public Prop Chair;
    public int Attacktimer;
    public List<Vehicle> AttackVehicles = new List<Vehicle>();
    public List<Ped> AttackPeds = new List<Ped>();
    public float increaseGain;
    public bool bought;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public int stockstimer;
    public ScriptSettings Config3;
    public bool ShowStockIncrease;
    public DateTime CurrentDate;
    public DateTime NextDate;
    public int DaysWait = 3;
    public int NextDay;
    public int NextMonth;
    public int NextYear;
    public bool BYPASS_NOSAVE_OR_CRASH = true;
    public int DAYSTORESET_UPDATETIME = 12;
    public bool TriggeredWeedStage2;
    public bool TriggeredWeedStage3;
    public int Now;
    public bool RefreshInt = true;
    public bool EnableBikerMethLab = true;
    public bool EnableBikerWeedFarm = true;
    public bool EnableBikerCocaineLab = true;
    public bool EnableBikerForgeryOffice = true;
    public bool EnableBikerMoneyPrinter = true;
    public bool UseGTAO_ProductMax;
    public bool MethLab_InitialSetupDone = false;
    public bool MethLab_EquipmentUpgrade;
    public bool MethLab_StaffUpgrade;
    public bool MethLab_SecurityUpgrade;
    public float MethLab_TotalEarnings = 0.0f;
    public int MethLab_TotalResupplySuccess = 0;
    public int MethLab_TotalResupplyFails = 0;
    public int MethLab_TotalSales_LS = 0;
    public int MethLab_TotalFails_LS = 0;
    public int MethLab_TotalSales_BC = 0;
    public int MethLab_TotalFails_BC = 0;
    public int MethLab_Supplies = 0;
    public int MethLab_ProductionCeased_NoSupplies = 0;
    public int MethLab_ProductionCeased_NoRaided = 0;
    public int MethLab_ProductionCeased_NoCapacity = 0;
    public bool MethLab_StoppedProducing;
    public float MethLab_BuySuppliesMultiplier = 1f;
    public float MethLab_SellProductMutliplier = 1f;
    public int MethLab_ProductMax = 100;
    public int MethLab_ProductBags = 0;
    public float MethLab_ProductValue = 0.0f;
    public float SETMethLab_ProductValue = 0.0f;
    private float SETMethLab_SellPrice;
    public List<SecondBusiness.PedSpawn> MethLab_ActiveSpawns = new List<SecondBusiness.PedSpawn>();
    public List<SecondBusiness.PedSpawn> MethLab_NotActiveSpawns = new List<SecondBusiness.PedSpawn>();
    public bool WeedFarm_InitialSetupDone = false;
    public bool WeedFarm_EquipmentUpgrade;
    public bool WeedFarm_StaffUpgrade;
    public bool WeedFarm_SecurityUpgrade;
    public float WeedFarm_TotalEarnings = 0.0f;
    public int WeedFarm_TotalResupplySuccess = 0;
    public int WeedFarm_TotalResupplyFails = 0;
    public int WeedFarm_TotalSales_LS = 0;
    public int WeedFarm_TotalFails_LS = 0;
    public int WeedFarm_TotalSales_BC = 0;
    public int WeedFarm_TotalFails_BC = 0;
    public int WeedFarm_Supplies = 0;
    public int WeedFarm_ProductionCeased_NoSupplies = 0;
    public int WeedFarm_ProductionCeased_NoRaided = 0;
    public int WeedFarm_ProductionCeased_NoCapacity = 0;
    public bool WeedFarm_StoppedProducing;
    public float WeedFarm_BuySuppliesMultiplier = 1f;
    public float WeedFarm_SellProductMutliplier = 1f;
    public int WeedFarm_ProductMax = 100;
    public int WeedFarm_ProductBags = 0;
    public float WeedFarm_ProductValue = 0.0f;
    public float SETWeedFarm_ProductValue = 0.0f;
    private float SETWeedFarm_SellPrice;
    public List<SecondBusiness.PedSpawn> WeedFarm_NotActiveSpawns = new List<SecondBusiness.PedSpawn>();
    public List<SecondBusiness.PedSpawn> WeedFarm_ActiveSpawns = new List<SecondBusiness.PedSpawn>();
    public bool CocaineLockup_InitialSetupDone;
    public bool CocaineLockup_EquipmentUpgrade;
    public bool CocaineLockup_StaffUpgrade;
    public bool CocaineLockup_SecurityUpgrade;
    public float CocaineLockup_TotalEarnings;
    public int CocaineLockup_TotalResupplySuccess;
    public int CocaineLockup_TotalResupplyFails;
    public int CocaineLockup_TotalSales_LS = 0;
    public int CocaineLockup_TotalFails_LS = 0;
    public int CocaineLockup_TotalSales_BC = 0;
    public int CocaineLockup_TotalFails_BC = 0;
    public int CocaineLockup_Supplies = 0;
    public int CocaineLockup_ProductionCeased_NoSupplies;
    public int CocaineLockup_ProductionCeased_NoRaided;
    public int CocaineLockup_ProductionCeased_NoCapacity;
    public bool CocaineLockup_StoppedProducing;
    public float CocaineLockup_BuySuppliesMultiplier = 1f;
    public float CocaineLockup_SellProductMutliplier = 1f;
    public int CocaineLockup_ProductMax = 100;
    public int CocaineLockup_ProductBags = 0;
    public float CocaineLockup_ProductValue = 0.0f;
    public float SETCocaineLockup_ProductValue = 0.0f;
    private float SETCocaineLockup_SellPrice;
    public List<SecondBusiness.PedSpawn> CocaineLockup_NotActiveSpawns = new List<SecondBusiness.PedSpawn>();
    public List<SecondBusiness.PedSpawn> CocaineLockup_ActiveSpawns = new List<SecondBusiness.PedSpawn>()
    {
      new SecondBusiness.PedSpawn(new Vector3(1090.189f, -3191.248f, -39.4f), -11f),
      new SecondBusiness.PedSpawn(new Vector3(1099.549f, -3194.2f, -38.99344f), 99.86244f),
      new SecondBusiness.PedSpawn(new Vector3(1095.407f, -3196.616f, -38.99344f), 358.3549f),
      new SecondBusiness.PedSpawn(new Vector3(1093.495f, -3196.669f, -38.99344f), 358.5891f),
      new SecondBusiness.PedSpawn(new Vector3(1090.971f, -3196.684f, -38.99344f), 359.8737f),
      new SecondBusiness.PedSpawn(new Vector3(1089.828f, -3196.61f, -38.99344f), 1.603552f),
      new SecondBusiness.PedSpawn(new Vector3(1092.486f, -3196.584f, -38.99344f), 345.0735f),
      new SecondBusiness.PedSpawn(new Vector3(1088.683f, -3196.114f, -38.99344f), 278.4438f),
      new SecondBusiness.PedSpawn(new Vector3(1090.24f, -3194.675f, -38.99344f), 191.1207f),
      new SecondBusiness.PedSpawn(new Vector3(1092.473f, -3194.918f, -38.99344f), 179.8266f),
      new SecondBusiness.PedSpawn(new Vector3(1093.432f, -3194.917f, -38.99344f), 172.7995f),
      new SecondBusiness.PedSpawn(new Vector3(1094.812f, -3194.861f, -38.99344f), 194.5334f),
      new SecondBusiness.PedSpawn(new Vector3(1096.109f, -3194.825f, -38.99344f), 173.2655f),
      new SecondBusiness.PedSpawn(new Vector3(1097.029f, -3195.612f, -38.99344f), 88.36512f)
    };
    public bool CounterfeitOffice_InitialSetupDone = false;
    public bool CounterfeitOffice_EquipmentUpgrade;
    public bool CounterfeitOffice_StaffUpgrade;
    public bool CounterfeitOffice_SecurityUpgrade;
    public float CounterfeitOffice_TotalEarnings = 0.0f;
    public int CounterfeitOffice_TotalResupplySuccess = 0;
    public int CounterfeitOffice_TotalResupplyFails = 0;
    public int CounterfeitOffice_TotalSales_LS = 0;
    public int CounterfeitOffice_TotalFails_LS = 0;
    public int CounterfeitOffice_TotalSales_BC = 0;
    public int CounterfeitOffice_TotalFails_BC = 0;
    public int CounterfeitOffice_Supplies = 0;
    public int CounterfeitOffice_ProductionCeased_NoSupplies = 0;
    public int CounterfeitOffice_ProductionCeased_NoRaided = 0;
    public int CounterfeitOffice_ProductionCeased_NoCapacity = 0;
    public bool CounterfeitOffice_StoppedProducing;
    public float CounterfeitOffice_BuySuppliesMultiplier = 1f;
    public float CounterfeitOffice_SellProductMutliplier = 1f;
    public int CounterfeitOffice_ProductMax = 100;
    public int CounterfeitOffice_ProductBags = 0;
    public float CounterfeitOffice_ProductValue = 0.0f;
    public float SETCounterfeitOffice_ProductValue = 0.0f;
    private float SETCounterfeitOffice_SellPrice;
    public List<SecondBusiness.PedSpawn> CounterfeitOffice_NotActiveSpawns = new List<SecondBusiness.PedSpawn>();
    public List<SecondBusiness.PedSpawn> CounterfeitOffice_ActiveSpawns = new List<SecondBusiness.PedSpawn>();
    public bool DocumentForgery_InitialSetupDone = false;
    public bool DocumentForgery_EquipmentUpgrade;
    public bool DocumentForgery_StaffUpgrade;
    public bool DocumentForgery_SecurityUpgrade;
    public float DocumentForgery_TotalEarnings = 0.0f;
    public int DocumentForgery_TotalResupplySuccess = 0;
    public int DocumentForgery_TotalResupplyFails = 0;
    public int DocumentForgery_TotalSales_LS = 0;
    public int DocumentForgery_TotalFails_LS = 0;
    public int DocumentForgery_TotalSales_BC = 0;
    public int DocumentForgery_TotalFails_BC = 0;
    public int DocumentForgery_Supplies = 0;
    public int DocumentForgery_ProductionCeased_NoSupplies = 0;
    public int DocumentForgery_ProductionCeased_NoRaided = 0;
    public int DocumentForgery_ProductionCeased_NoCapacity = 0;
    public bool DocumentForgery_StoppedProducing;
    public float DocumentForgery_BuySuppliesMultiplier = 1f;
    public float DocumentForgery_SellProductMutliplier = 1f;
    public int DocumentForgery_ProductMax = 100;
    public int DocumentForgery_ProductBags = 0;
    public float DocumentForgery_ProductValue = 0.0f;
    public float SETDocumentForgery_ProductValue = 0.0f;
    private float SETDocumentForgery_SellPrice;
    public List<SecondBusiness.PedSpawn> DocumentForgery_NotActiveSpawns = new List<SecondBusiness.PedSpawn>();
    public List<SecondBusiness.PedSpawn> DocumentForgery_ActiveSpawns = new List<SecondBusiness.PedSpawn>()
    {
      new SecondBusiness.PedSpawn(new Vector3(1170.115f, -3196.448f, -39.95631f), 270f),
      new SecondBusiness.PedSpawn(new Vector3(1167.173f, -3196.401f, -39.95631f), 90f),
      new SecondBusiness.PedSpawn(new Vector3(1165.655f, -3197.064f, -39.95553f), 270f),
      new SecondBusiness.PedSpawn(new Vector3(1162.715f, -3196.934f, -39.95631f), 90f),
      new SecondBusiness.PedSpawn(new Vector3(1160.879f, -3198.542f, -39.95631f), 270f),
      new SecondBusiness.PedSpawn(new Vector3(1159.19f, -3195.834f, -39.95536f), 0.0f),
      new SecondBusiness.PedSpawn(new Vector3(1157.964f, -3198.534f, -39.95631f), 90f)
    };
    public Prop Weedblocker;
    public List<SecondBusiness.PedaSyncronisedScene> PedScenes = new List<SecondBusiness.PedaSyncronisedScene>();
    public List<Prop> PedSyncSeceneProps_group1 = new List<Prop>();
    public List<Prop> PedSyncSeceneProps_group2 = new List<Prop>();
    public List<Prop> PedSyncSeceneProps_group3 = new List<Prop>();
    public List<Prop> MCBusinessSupplies = new List<Prop>();
    public Prop Pallet1;
    public Prop Pallet2;
    public Prop Pallet3;
    public Prop Pallet4;
    public Prop Pallet5;
    public Prop Pallet6;
    public Prop Pallet7;
    public Prop Pallet8;
    public Prop Pallet9;
    public Prop Pallet10;
    public bool GottenProps;
    public Ped worker;
    private int MethLabId = 247041;
    private int WeedFarmId = 247297;
    private int CocaineLockupId = 247553;
    private int DocumentForgeryId = 246785;
    private int CounterfeitOfficeId = 247809;
    public float f;
    public bool GUION;
    public int GUIFrame;
    public int GUIBChoice;
    public bool CUIHasStarted;
    public Scaleform GUIscaleform;
    public int GUIMT;
    public float GUIPosY;
    public float GUIPosX;
    public bool GUIHasStarted;
    public int GUIAPP;
    public int GUIBIY;
    public int GUIBIX;
    public bool GUICheckBool;
    public int MCBusinessIn = 0;
    public bool GotItem_SetupMission;
    public Prop PropItem_SetupMission;
    public Vehicle VehicleItem_SetupMission;
    public Blip BlipItem_SetupMission;
    public bool MissionOn;
    public int MissionNum;
    public int MissionLoc;
    public List<Vector3> Positions = new List<Vector3>();
    public int nextpos;
    public int NextHour = -1;
    public bool SpawnedInitialAttackers;
    public bool SpawnedEndAttackers;
    public int EndAttackersTimer;
    public int EndAttackersTimerFinish;
    public List<Ped> SuppyGuards = new List<Ped>();
    public bool CreatedBlips;
    public bool ShowAllMarkersAnBlips = false;
    public int Supplies = 0;
    public int Counted = 0;
    public int MaxCounted = 0;
    public Vector3 SellPoint;
    public float SellAmt;
    public List<Prop> supplySellProps = new List<Prop>();
    public List<Vehicle> supplySellVehicles = new List<Vehicle>();
    public int VehiclestoDeliver;
    public int VehiclesDelivered;
    public Vehicle DeliverVehicleA;
    public Vehicle DeliverVehicleB;
    public Vehicle DeliverVehicleC;
    public Vehicle DeliverVehicleD;
    public Vector3 DeliverPointA;
    public Vector3 DeliverPointB;
    public Vector3 DeliverPointC;
    public Vector3 DeliverPointD;
    public bool DeliveredVehicleA;
    public bool DeliveredVehicleB;
    public bool DeliveredVehicleC;
    public bool DeliveredVehicleD;
    public bool CreatedVehicle;
    public Camera DoorCamera;
    public int DoorScene;
    public bool WaitingForRaid = false;
    public int RaidType = 0;
    public int RaidEnemyTime;
    public int CurrentTime;
    public int RaidHour;
    public bool AwaitingAraid;
    public int RaidCurrentTime;
    public int RaidTiggerHour = 1;
    public bool MISC_DisableRaids = false;
    public bool PlayingRaid;
    public bool LeanAnimOn;
    public int LeanScene1;
    public string LeanDict;
    public int Type = 0;

    private void LoadMain(string iniName)
    {
      try
      {
        this.MainConfigFile = ScriptSettings.Load(iniName);
        this.Safehouse_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "Safehouse_Colour", this.Safehouse_Colour);
        this.Blip_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        this.MarkerColorString = this.MainConfigFile.GetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        this.MarkerColor = Color.FromName(this.MarkerColorString);
        this.SafehouseMColorString = this.MainConfigFile.GetValue<string>("Misc", "SafehouseMColor", this.SafehouseMColorString);
        this.SafehouseMColor = Color.FromName(this.SafehouseMColorString);
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

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Biker Business", "SubBusiness", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public void SetupPeds()
    {
      this.pPosition.Add(new Vector3(1093f, -3194f, -38f));
      this.pRotation.Add(154f);
      this.pPosition.Add(new Vector3(1090f, -3194f, -38f));
      this.pRotation.Add(154f);
      this.pPosition.Add(new Vector3(1095f, -3197f, -38f));
      this.pRotation.Add(0.0f);
      this.pPosition.Add(new Vector3(1100f, -3194f, -38f));
      this.pRotation.Add(81f);
      this.pPosition.Add(new Vector3(1167.437f, -3196.408f, -40f));
      this.pRotation.Add(-87f);
      this.pPosition.Add(new Vector3(1169.823f, -3196.467f, -40f));
      this.pRotation.Add(87f);
      this.pPosition.Add(new Vector3(1158.011f, -3198.448f, -40f));
      this.pRotation.Add(-86f);
      this.pPosition.Add(new Vector3(1159.129f, -3196.105f, -40f));
      this.pRotation.Add(172f);
      this.pPosition.Add(new Vector3(1160.769f, -3198.582f, -40f));
      this.pRotation.Add(84f);
      this.pPosition.Add(new Vector3(1162.887f, -3196.997f, -40f));
      this.pRotation.Add(-84f);
      this.pPosition.Add(new Vector3(1165.357f, -3197.096f, -40f));
      this.pRotation.Add(84f);
      this.pPosition.Add(new Vector3(1120.079f, -3198.07f, -41.4f));
      this.pRotation.Add(157f);
      this.pPosition.Add(new Vector3(1116.43f, -3194.962f, -41.4f));
      this.pRotation.Add(91f);
      this.pPosition.Add(new Vector3(1116.389f, -3196.323f, -41.4f));
      this.pRotation.Add(98f);
      this.pPosition.Add(new Vector3(1123.873f, -3195.238f, -40f));
      this.pRotation.Add(0.0f);
      this.pPosition.Add(new Vector3(1134.519f, -3196.513f, -40f));
      this.pRotation.Add(-171f);
      this.pPosition.Add(new Vector3(1125.333f, -3196.832f, -40f));
      this.pRotation.Add(-134f);
      this.pPosition.Add(new Vector3(1137.873f, -3194.238f, -40f));
      this.pRotation.Add(0.0f);
      this.pPosition.Add(new Vector3(1039.211f, -3206.006f, -39.2f));
      this.pRotation.Add(80f);
      this.pPosition.Add(new Vector3(1037.416f, -3205.98f, -39.2f));
      this.pRotation.Add(-90f);
      this.pPosition.Add(new Vector3(1033.001f, -3206.13f, -39.2f));
      this.pRotation.Add(-93f);
      this.pPosition.Add(new Vector3(1034.508f, -3206.195f, -39.2f));
      this.pRotation.Add(95f);
      this.pPosition.Add(new Vector3(1042.87f, -3198.295f, -39f));
      this.pRotation.Add(-103f);
      this.pPosition.Add(new Vector3(1052.594f, -3201.896f, -40f));
      this.pRotation.Add(0.0f);
      this.pPosition.Add(new Vector3(1058.301f, -3195.802f, -40f));
      this.pRotation.Add(-114f);
      this.pPosition.Add(new Vector3(1062.224f, -3190.102f, -40f));
      this.pRotation.Add(-151f);
      this.pPosition.Add(new Vector3(1010.769f, -3196.145f, -39f));
      this.pRotation.Add(164f);
      this.pPosition.Add(new Vector3(1003.241f, -3199.503f, -39f));
      this.pRotation.Add(133f);
      this.pPosition.Add(new Vector3(1005.872f, -3195.428f, -39f));
      this.pRotation.Add(-8f);
      this.pPosition.Add(new Vector3(1010.238f, -3200.516f, -39f));
      this.pRotation.Add(7f);
    }

    public SecondBusiness()
    {
      this.LoadMain("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.Peds = new List<Ped>();
      this.DropBlip = new List<Blip>();
      this.DropPoint = new List<Vector3>();
      this.DeliverPoints();
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.AllStocks = new AllStock();
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.CreateBanner();
      this.Setup();
      this.waittime = this.AllStocks.waittime;
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Interval = 1;
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
      this.DropPoint.Add(new Vector3(102.6f, 6634.6f, 30f));
      this.DropPoint.Add(new Vector3(-172.8f, 6452.8f, 29f));
      this.DropPoint.Add(new Vector3(-265.1f, 6335.5f, 30f));
      this.DropPoint.Add(new Vector3(-697.3f, 5772.9f, 15f));
      this.DropPoint.Add(new Vector3(-575.2f, 5335.6f, 68f));
      this.DropPoint.Add(new Vector3(35.9f, 6284.5f, 29f));
      this.DropPoint.Add(new Vector3(1724f, 6399.4f, 31f));
      this.DropPoint.Add(new Vector3(2467.7f, 4961.9f, 43f));
      this.DropPoint.Add(new Vector3(2104.9f, 4767.5f, 39f));
      this.DropPoint.Add(new Vector3(1501.6f, 3763.7f, 31f));
      this.DropPoint.Add(new Vector3(1374.5f, 3602.9f, 33f));
      this.DropPoint.Add(new Vector3(1689.4f, 3310.9f, 39f));
      this.DropPoint.Add(new Vector3(1989f, 3032f, 46f));
      this.DropPoint.Add(new Vector3(2320.1f, 2499.5f, 45f));
      this.DropPoint.Add(new Vector3(2365.2f, 2644.9f, 45f));
      this.DropPoint.Add(new Vector3(2411.1f, 3058.2f, 46f));
      this.DropPoint.Add(new Vector3(2812.8f, 1589.4f, 22f));
      this.DropPoint.Add(new Vector3(-1567.1f, 2770.7f, 15f));
      this.DropPoint.Add(new Vector3(-1911.4f, 2061f, 138f));
      this.DropPoint.Add(new Vector3(-310.8f, 2739.6f, 65f));
      this.DropPoint.Add(new Vector3(-288.5f, 2568.7f, 70f));
      this.DropPoint.Add(new Vector3(-85.6f, 2805.1f, 51f));
      this.DropPoint.Add(new Vector3(42.2f, 2786f, 56f));
      this.DropPoint.Add(new Vector3(216.7f, 2462.3f, 54f));
      this.DropPoint.Add(new Vector3(1505.795f, 6336.398f, 23.99496f));
      this.DropPoint.Add(new Vector3(3283.368f, 5160.103f, 18.72222f));
      this.DropPoint.Add(new Vector3(2602.081f, 4893.493f, 36.27444f));
      this.DropPoint.Add(new Vector3(2527.971f, 4486.609f, 37.54001f));
      this.DropPoint.Add(new Vector3(2429.851f, 4021.68f, 36.79293f));
      this.DropPoint.Add(new Vector3(1917.294f, 3901.058f, 32.64089f));
      this.DropPoint.Add(new Vector3(1533.271f, 3915.06f, 31.68931f));
      this.DropPoint.Add(new Vector3(339.8648f, 3565.048f, 33.43684f));
      this.DropPoint.Add(new Vector3(55.61508f, 3713.52f, 39.747f));
      this.DropPoint.Add(new Vector3(-666.4503f, 4148.554f, 158.9823f));
      this.DropPoint.Add(new Vector3(-1217.05f, 4451.783f, 30.41781f));
      this.DropPoint.Add(new Vector3(-1681.906f, 4599.693f, 49.14717f));
      this.DropPoint.Add(new Vector3(-1633.101f, 4735.637f, 53.301f));
      this.DropPoint.Add(new Vector3(-1962.065f, 4581.604f, 2.842246f));
      this.DropPoint.Add(new Vector3(-1731.579f, 5050.326f, 26.03668f));
      this.DropPoint.Add(new Vector3(-2200.426f, 5121.706f, 12.25019f));
      this.DropPoint.Add(new Vector3(-1579.333f, 5164.068f, 19.52285f));
      this.DropPoint.Add(new Vector3(-1467.83f, 5416.208f, 23.60886f));
      this.DropPoint.Add(new Vector3(-1069.668f, 5452.821f, 5.940477f));
      this.DropPoint.Add(new Vector3(-2539.26f, 3909.428f, 3.662833f));
      this.DropPoint.Add(new Vector3(-3032.201f, 3525.799f, 2.067003f));
      this.DropPoint.Add(new Vector3(-2607.909f, 1684.244f, 139.667f));
      this.DropPoint.Add(new Vector3(-3074.967f, 550.7738f, 2.319568f));
      this.DropPoint.Add(new Vector3(-2990.662f, 83.55144f, 11.61019f));
      this.DropPoint.Add(new Vector3(-1647.762f, -200.6317f, 55.12602f));
      this.DropPoint.Add(new Vector3(-1257.586f, -261.8219f, 39.11664f));
      this.DropPoint.Add(new Vector3(-928.0646f, -165.6178f, 41.76316f));
      this.DropPoint.Add(new Vector3(232.2361f, -786.5168f, 30.65059f));
      this.DropPoint.Add(new Vector3(18.29151f, -1065.977f, 38.15215f));
      this.DropPoint.Add(new Vector3(-347.6806f, -1355.161f, 31.28552f));
      this.DropPoint.Add(new Vector3(-47.45924f, -1680.785f, 29.438f));
      this.DropPoint.Add(new Vector3(353.3791f, -1694.438f, 48.30305f));
      this.DropPoint.Add(new Vector3(571.4122f, -844.5917f, 10.91388f));
      this.DropPoint.Add(new Vector3(637.9606f, -435.9931f, 24.63415f));
      this.DropPoint.Add(new Vector3(721.2916f, -582.1443f, 27.27202f));
      this.DropPoint.Add(new Vector3(915.3647f, -1247.816f, 25.43036f));
      this.DropPoint.Add(new Vector3(993.0587f, -1536.594f, 30.83576f));
      this.DropPoint.Add(new Vector3(1001.795f, -1956.197f, 30.89874f));
      this.DropPoint.Add(new Vector3(1094.131f, -2114.35f, 32.83114f));
      this.DropPoint.Add(new Vector3(1425.845f, -2295.59f, 66.74454f));
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      this.Now = this.GetDay();
      this.LoadIniFile3("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.pPosition = new List<Vector3>();
      this.pRotation = new List<float>();
      this.SetupPeds();
      this.SetupMarker();
      this.modMenuPool = new MenuPool();
      this.MethMenuPool = new MenuPool();
      this.WeedMenuPool = new MenuPool();
      this.CocaineMenuPool = new MenuPool();
      this.MoneyPrinterMenuPool = new MenuPool();
      this.ForgeryMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Biker Buisness", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.Buy = this.modMenuPool.AddSubMenu(this.mainMenu, "Buy");
      this.GUIMenus.Add(this.Buy);
      this.Sell = this.modMenuPool.AddSubMenu(this.mainMenu, "Sell");
      this.GUIMenus.Add(this.Sell);
      this.Enter = this.modMenuPool.AddSubMenu(this.mainMenu, "Enter");
      this.GUIMenus.Add(this.Enter);
      this.WeedFarmEnter = new Vector3(1065.95f, -3183.58f, -40.5f);
      this.ForgeryEnter = new Vector3(1173.056f, -3196.576f, -40f);
      this.MoneyPrinterEnter = new Vector3(1138.06f, -3198.819f, -40.7f);
      this.CocaineEnter = new Vector3(1088.69f, -3188.02f, -39.8f);
      this.MethLabEnter = new Vector3(997.17f, -3200.7f, -37.3f);
      this.MethMenu = new Vector3(1002.34f, -3195.09f, -40f);
      this.CocaineMenu = new Vector3(1087.35f, -3194.24f, -40f);
      this.MoneyPrinterMenu = new Vector3(1135.23f, -3194.26f, -41f);
      this.WeedMenu = new Vector3(1041.62f, -3204.12f, -39f);
      this.ForgeryMenu = new Vector3(1160.96f, -3197.57f, -40f);
      this.MethUIMenu = new UIMenu("Meth Lab", "Select an Option");
      this.GUIMenus.Add(this.MethUIMenu);
      this.MethMenuPool.Add(this.MethUIMenu);
      if (this.MethLab_InitialSetupDone)
      {
        this.MethProduce = this.MethMenuPool.AddSubMenu(this.MethUIMenu, "Produce");
        this.GUIMenus.Add(this.MethProduce);
        this.MethSell = this.MethMenuPool.AddSubMenu(this.MethUIMenu, "Sell");
        this.GUIMenus.Add(this.MethSell);
      }
      if (!this.MethLab_InitialSetupDone)
      {
        this.MethUIMenu.AddItem(new UIMenuItem(" Run Setup Mission "));
        this.MethUIMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) => { });
      }
      this.ForgeryUIMenu = new UIMenu("Forgery Office", "Select an Option");
      this.GUIMenus.Add(this.ForgeryUIMenu);
      this.ForgeryMenuPool.Add(this.ForgeryUIMenu);
      if (this.DocumentForgery_InitialSetupDone)
      {
        this.ForgeryProduce = this.ForgeryMenuPool.AddSubMenu(this.ForgeryUIMenu, "Produce");
        this.GUIMenus.Add(this.ForgeryProduce);
        this.ForgerySell = this.ForgeryMenuPool.AddSubMenu(this.ForgeryUIMenu, "Sell");
        this.GUIMenus.Add(this.ForgerySell);
      }
      if (!this.DocumentForgery_InitialSetupDone)
      {
        this.ForgeryUIMenu.AddItem(new UIMenuItem(" Run Setup Mission "));
        this.ForgeryUIMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) => { });
      }
      this.CocaineUIMenu = new UIMenu("Cocaine Lockup", "Select an Option");
      this.GUIMenus.Add(this.CocaineUIMenu);
      this.CocaineMenuPool.Add(this.CocaineUIMenu);
      if (this.CocaineLockup_InitialSetupDone)
      {
        this.CocaineProduce = this.CocaineMenuPool.AddSubMenu(this.CocaineUIMenu, "Produce");
        this.GUIMenus.Add(this.CocaineProduce);
        this.CocaineSell = this.CocaineMenuPool.AddSubMenu(this.CocaineUIMenu, "Sell");
        this.GUIMenus.Add(this.CocaineSell);
      }
      if (!this.CocaineLockup_InitialSetupDone)
      {
        this.CocaineUIMenu.AddItem(new UIMenuItem(" Run Setup Mission "));
        this.CocaineUIMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) => { });
      }
      this.WeedUIMenu = new UIMenu("Weed Farm", "Select an Option");
      this.GUIMenus.Add(this.WeedUIMenu);
      this.WeedMenuPool.Add(this.WeedUIMenu);
      if (this.WeedFarm_InitialSetupDone)
      {
        this.WeedProduce = this.WeedMenuPool.AddSubMenu(this.WeedUIMenu, "Produce");
        this.GUIMenus.Add(this.WeedProduce);
        this.WeedSell = this.WeedMenuPool.AddSubMenu(this.WeedUIMenu, "Sell");
        this.GUIMenus.Add(this.WeedSell);
      }
      if (!this.WeedFarm_InitialSetupDone)
      {
        this.WeedUIMenu.AddItem(new UIMenuItem(" Run Setup Mission "));
        this.WeedUIMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) => { });
      }
      this.MoneyPrinterUIMenu = new UIMenu("Money Printer", "Select an Option");
      this.GUIMenus.Add(this.MoneyPrinterUIMenu);
      this.MoneyPrinterMenuPool.Add(this.MoneyPrinterUIMenu);
      if (this.CounterfeitOffice_InitialSetupDone)
      {
        this.MoneyProduce = this.MoneyPrinterMenuPool.AddSubMenu(this.MoneyPrinterUIMenu, "Produce");
        this.GUIMenus.Add(this.MoneyProduce);
        this.MoneySell = this.MoneyPrinterMenuPool.AddSubMenu(this.MoneyPrinterUIMenu, "Sell");
        this.GUIMenus.Add(this.MoneySell);
      }
      if (!this.CounterfeitOffice_InitialSetupDone)
      {
        this.MoneyPrinterUIMenu.AddItem(new UIMenuItem(" Run Setup Mission "));
        this.MoneyPrinterUIMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) => { });
      }
      this.SetupBuy();
      this.SetupEnter();
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
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
      this.CheckHostName("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
      this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      string str = "~" + this.Uicolour + "~";
      return this.HostName;
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

    public void SetupSellStock(int Type)
    {
      this.Droptype = Type;
      if ((Entity) this.DropVehicle != (Entity) null)
        this.DropVehicle.Delete();
      if (this.DropVehicleBlip != (Blip) null)
        this.DropVehicleBlip.Remove();
      foreach (Blip blip in this.DropBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      this.DropBlip.Clear();
      if (!this.UseNewEnterance)
      {
        this.DropVehicle = World.CreateVehicle((Model) VehicleHash.Mule, new Vector3(864f, -2118f, 30f));
        this.DropVehicleBlip = World.CreateBlip(this.DropVehicle.Position);
        this.DropVehicleBlip.Sprite = BlipSprite.Truck;
        this.DropVehicleBlip.Name = "Delivery Vehicle";
        this.DropVehicleBlip.Color = BlipColor.Yellow;
      }
      if (this.UseNewEnterance)
      {
        if ((Entity) this.DropVehicle != (Entity) null)
          this.DropVehicle.Delete();
        if (this.DropVehicleBlip != (Blip) null)
          this.DropVehicleBlip.Remove();
        if (this.LastEnt == this.MethLabExit)
        {
          this.DropVehicle = World.CreateVehicle((Model) VehicleHash.Mule, this.MCSubLocMeth[this.MethMCbusinessLoc].SupplyTruckSpawn, this.MCSubLocMeth[this.MethMCbusinessLoc].SupplyTruckHeading);
          this.DropVehicleBlip = World.CreateBlip(this.DropVehicle.Position);
          this.DropVehicleBlip.Sprite = BlipSprite.Truck;
          this.DropVehicleBlip.Name = "Delivery Vehicle";
          this.DropVehicleBlip.Color = BlipColor.Yellow;
          this.DropVehicle.BodyHealth = 3000f;
        }
        if (this.LastEnt == this.MoneyPrinterExit)
        {
          this.DropVehicle = World.CreateVehicle((Model) VehicleHash.Mule, this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].SupplyTruckSpawn, this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].SupplyTruckHeading);
          this.DropVehicleBlip = World.CreateBlip(this.DropVehicle.Position);
          this.DropVehicleBlip.Sprite = BlipSprite.Truck;
          this.DropVehicleBlip.Name = "Delivery Vehicle";
          this.DropVehicleBlip.Color = BlipColor.Yellow;
          this.DropVehicle.BodyHealth = 3000f;
        }
        if (this.LastEnt == this.CocaineExit)
        {
          this.DropVehicle = World.CreateVehicle((Model) VehicleHash.Mule, this.MCSubLocCocaine[this.CocaineMCbusinessLoc].SupplyTruckSpawn, this.MCSubLocCocaine[this.CocaineMCbusinessLoc].SupplyTruckHeading);
          this.DropVehicleBlip = World.CreateBlip(this.DropVehicle.Position);
          this.DropVehicleBlip.Sprite = BlipSprite.Truck;
          this.DropVehicleBlip.Name = "Delivery Vehicle";
          this.DropVehicleBlip.Color = BlipColor.Yellow;
          this.DropVehicle.BodyHealth = 3000f;
        }
        if (this.LastEnt == this.WeedFarmExit)
        {
          this.DropVehicle = World.CreateVehicle((Model) VehicleHash.Mule, this.MCSubLocWeed[this.WeedMCbusinessLoc].SupplyTruckSpawn, this.MCSubLocWeed[this.WeedMCbusinessLoc].SupplyTruckHeading);
          this.DropVehicleBlip = World.CreateBlip(this.DropVehicle.Position);
          this.DropVehicleBlip.Sprite = BlipSprite.Truck;
          this.DropVehicleBlip.Name = "Delivery Vehicle";
          this.DropVehicleBlip.Color = BlipColor.Yellow;
          this.DropVehicle.BodyHealth = 3000f;
        }
        if (this.LastEnt == this.ForgeryExit)
        {
          this.DropVehicle = World.CreateVehicle((Model) VehicleHash.Mule, this.MCSubLocForgery[this.ForgeryMCbusinessLoc].SupplyTruckSpawn, this.MCSubLocForgery[this.ForgeryMCbusinessLoc].SupplyTruckHeading);
          this.DropVehicleBlip = World.CreateBlip(this.DropVehicle.Position);
          this.DropVehicleBlip.Sprite = BlipSprite.Truck;
          this.DropVehicleBlip.Name = "Delivery Vehicle";
          this.DropVehicleBlip.Color = BlipColor.Yellow;
          this.DropVehicle.BodyHealth = 3000f;
        }
      }
      if (this.Droptype == 1)
      {
        this.amountToSell = this.MethLab_ProductValue;
        this.StockAmount = this.MethLab_ProductBags;
        UI.Notify(this.GetHostName() + " Ok Boss you have choosen to sell all ~y~Meth~w~ product, there is a Mule parked outside, if the Mule gets destroyed, we lose everything! be careful");
        if (this.StockAmount < 30)
          this.AmttoDeliver = 2;
        if (this.StockAmount >= 30 && this.StockAmount < 70)
          this.AmttoDeliver = 3;
        if (this.StockAmount >= 70 && this.StockAmount < 120)
          this.AmttoDeliver = 4;
        if (this.StockAmount >= 120 && this.StockAmount < 150)
          this.AmttoDeliver = 5;
        if (this.StockAmount >= 150 && this.StockAmount < 190)
          this.AmttoDeliver = 6;
        if (this.StockAmount >= 190 && this.StockAmount < 230)
          this.AmttoDeliver = 7;
        if (this.StockAmount >= 230 && this.StockAmount < 260)
          this.AmttoDeliver = 8;
        if (this.StockAmount >= 260 && this.StockAmount < 290)
          this.AmttoDeliver = 9;
        if (this.StockAmount >= 290 && this.StockAmount < 330)
          this.AmttoDeliver = 10;
        if (this.StockAmount >= 330 && this.StockAmount < 360)
          this.AmttoDeliver = 12;
        if (this.StockAmount >= 360 && this.StockAmount < 400)
          this.AmttoDeliver = 14;
        if (this.StockAmount >= 400)
          this.AmttoDeliver = 16;
        UI.Notify(this.GetHostName() + "  ~b~Because your Stock Level is " + this.StockAmount.ToString() + ", you need to deliver to a minimum of " + this.AmttoDeliver.ToString() + " drop points~w~, each drop point is indicated by a yellow crate icon on your map, good luck");
      }
      if (this.Droptype == 2)
      {
        this.amountToSell = this.CocaineLockup_ProductValue;
        this.StockAmount = this.CocaineLockup_ProductBags;
        UI.Notify(this.GetHostName() + " Ok Boss you have choosen to sell all ~y~Cocaine ~w~ product, there is a Mule parked outside, if the Mule gets destroyed, we lose everything! be careful");
        if (this.StockAmount < 30)
          this.AmttoDeliver = 2;
        if (this.StockAmount >= 30 && this.StockAmount < 70)
          this.AmttoDeliver = 3;
        if (this.StockAmount >= 70 && this.StockAmount < 120)
          this.AmttoDeliver = 4;
        if (this.StockAmount >= 120 && this.StockAmount < 150)
          this.AmttoDeliver = 5;
        if (this.StockAmount >= 150 && this.StockAmount < 190)
          this.AmttoDeliver = 6;
        if (this.StockAmount >= 190 && this.StockAmount < 230)
          this.AmttoDeliver = 7;
        if (this.StockAmount >= 230 && this.StockAmount < 260)
          this.AmttoDeliver = 8;
        if (this.StockAmount >= 260 && this.StockAmount < 290)
          this.AmttoDeliver = 9;
        if (this.StockAmount >= 290 && this.StockAmount < 330)
          this.AmttoDeliver = 10;
        if (this.StockAmount >= 330 && this.StockAmount < 360)
          this.AmttoDeliver = 12;
        if (this.StockAmount >= 360 && this.StockAmount < 400)
          this.AmttoDeliver = 14;
        if (this.StockAmount >= 400)
          this.AmttoDeliver = 16;
        UI.Notify(this.GetHostName() + "  ~b~Because your Stock Level is " + this.StockAmount.ToString() + ", you need to deliver to a minimum of " + this.AmttoDeliver.ToString() + " drop points~w~, each drop point is indicated by a yellow crate icon on your map, good luck");
      }
      if (this.Droptype == 3)
      {
        this.amountToSell = this.WeedFarm_ProductValue;
        this.StockAmount = this.WeedFarm_ProductBags;
        UI.Notify(this.GetHostName() + " Ok Boss you have choosen to sell all ~y~Weed~w~ product, there is a Mule parked outside, if the Mule gets destroyed, we lose everything! be careful");
        if (this.StockAmount < 30)
          this.AmttoDeliver = 2;
        if (this.StockAmount >= 30 && this.StockAmount < 70)
          this.AmttoDeliver = 3;
        if (this.StockAmount >= 70 && this.StockAmount < 120)
          this.AmttoDeliver = 4;
        if (this.StockAmount >= 120 && this.StockAmount < 150)
          this.AmttoDeliver = 5;
        if (this.StockAmount >= 150 && this.StockAmount < 190)
          this.AmttoDeliver = 6;
        if (this.StockAmount >= 190 && this.StockAmount < 230)
          this.AmttoDeliver = 7;
        if (this.StockAmount >= 230 && this.StockAmount < 260)
          this.AmttoDeliver = 8;
        if (this.StockAmount >= 260 && this.StockAmount < 290)
          this.AmttoDeliver = 9;
        if (this.StockAmount >= 290 && this.StockAmount < 330)
          this.AmttoDeliver = 10;
        if (this.StockAmount >= 330 && this.StockAmount < 360)
          this.AmttoDeliver = 12;
        if (this.StockAmount >= 360 && this.StockAmount < 400)
          this.AmttoDeliver = 14;
        if (this.StockAmount >= 400)
          this.AmttoDeliver = 16;
        UI.Notify(this.GetHostName() + "  ~b~Because your Stock Level is " + this.StockAmount.ToString() + ", you need to deliver to a minimum of " + this.AmttoDeliver.ToString() + " drop points~w~, each drop point is indicated by a yellow crate icon on your map, good luck");
      }
      if (this.Droptype == 4)
      {
        this.amountToSell = this.DocumentForgery_ProductValue;
        this.StockAmount = this.DocumentForgery_ProductBags;
        UI.Notify(this.GetHostName() + " Ok Boss you have choosen to sell all ~y~Forgery Documents~w~ product, there is a Mule parked outside, if the Mule gets destroyed, we lose everything! be careful");
        if (this.StockAmount < 30)
          this.AmttoDeliver = 2;
        if (this.StockAmount >= 30 && this.StockAmount < 70)
          this.AmttoDeliver = 3;
        if (this.StockAmount >= 70 && this.StockAmount < 120)
          this.AmttoDeliver = 4;
        if (this.StockAmount >= 120 && this.StockAmount < 150)
          this.AmttoDeliver = 5;
        if (this.StockAmount >= 150 && this.StockAmount < 190)
          this.AmttoDeliver = 6;
        if (this.StockAmount >= 190 && this.StockAmount < 230)
          this.AmttoDeliver = 7;
        if (this.StockAmount >= 230 && this.StockAmount < 260)
          this.AmttoDeliver = 8;
        if (this.StockAmount >= 260 && this.StockAmount < 290)
          this.AmttoDeliver = 9;
        if (this.StockAmount >= 290 && this.StockAmount < 330)
          this.AmttoDeliver = 10;
        if (this.StockAmount >= 330 && this.StockAmount < 360)
          this.AmttoDeliver = 12;
        if (this.StockAmount >= 360 && this.StockAmount < 400)
          this.AmttoDeliver = 14;
        if (this.StockAmount >= 400)
          this.AmttoDeliver = 16;
        UI.Notify(this.GetHostName() + "  ~b~Because your Stock Level is " + this.StockAmount.ToString() + ", you need to deliver to a minimum of " + this.AmttoDeliver.ToString() + " drop points~w~, each drop point is indicated by a yellow crate icon on your map, good luck");
      }
      if (this.Droptype == 5)
      {
        this.amountToSell = this.CounterfeitOffice_ProductValue;
        this.StockAmount = this.CounterfeitOffice_ProductBags;
        UI.Notify(this.GetHostName() + " Ok Boss you have choosen to sell all ~y~Counterfeit Money~w~ product, there is a Mule parked outside, if the Mule gets destroyed, we lose everything! be careful");
        if (this.StockAmount < 30)
          this.AmttoDeliver = 2;
        if (this.StockAmount >= 30 && this.StockAmount < 70)
          this.AmttoDeliver = 3;
        if (this.StockAmount >= 70 && this.StockAmount < 120)
          this.AmttoDeliver = 4;
        if (this.StockAmount >= 120 && this.StockAmount < 150)
          this.AmttoDeliver = 5;
        if (this.StockAmount >= 150 && this.StockAmount < 190)
          this.AmttoDeliver = 6;
        if (this.StockAmount >= 190 && this.StockAmount < 230)
          this.AmttoDeliver = 7;
        if (this.StockAmount >= 230 && this.StockAmount < 260)
          this.AmttoDeliver = 8;
        if (this.StockAmount >= 260 && this.StockAmount < 290)
          this.AmttoDeliver = 9;
        if (this.StockAmount >= 290 && this.StockAmount < 330)
          this.AmttoDeliver = 10;
        if (this.StockAmount >= 330 && this.StockAmount < 360)
          this.AmttoDeliver = 12;
        if (this.StockAmount >= 360 && this.StockAmount < 400)
          this.AmttoDeliver = 14;
        if (this.StockAmount >= 400)
          this.AmttoDeliver = 16;
        UI.Notify(this.GetHostName() + "  ~b~Because your Stock Level is " + this.StockAmount.ToString() + ", you need to deliver to a minimum of " + this.AmttoDeliver.ToString() + " drop points~w~, each drop point is indicated by a yellow crate icon on your map, good luck");
      }
      this.missionnum = 1;
      this.PointsBeenAt = 0;
      this.PlayingMission = true;
      foreach (Vector3 position in this.DropPoint)
      {
        Blip blip = World.CreateBlip(position);
        blip.Sprite = BlipSprite.SpecialCargo;
        blip.Name = "Sell Drop Point";
        blip.Color = BlipColor.Yellow;
        this.DropBlip.Add(blip);
        blip.IsShortRange = true;
      }
    }

    private void SetupBuy()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Buy, "Business Type");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Buy1 = new UIMenuItem("Buy Forgery : $950,000");
      uiMenu.AddItem(Buy1);
      UIMenuItem Buy2 = new UIMenuItem("Buy Money Printer : $1,250,000");
      uiMenu.AddItem(Buy2);
      UIMenuItem Buy3 = new UIMenuItem("Buy Weed Farm : $2,350,000");
      uiMenu.AddItem(Buy3);
      UIMenuItem Buy4 = new UIMenuItem("Buy Cocaine Lockup : $2,650,000");
      uiMenu.AddItem(Buy4);
      UIMenuItem Buy5 = new UIMenuItem("Buy Meth Lab : $3,000,000");
      uiMenu.AddItem(Buy5);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Buy1)
        {
          if (this.Config.GetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought) != 1)
          {
            if (Game.Player.Money >= 950000)
            {
              Game.Player.Money -= 950000;
              this.ForgeryBought = 1;
              this.Config.SetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this Sub Business");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you allready own this business");
        }
        if (item == Buy2)
        {
          if (this.Config.GetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought) != 1)
          {
            if (Game.Player.Money >= 1250000)
            {
              Game.Player.Money -= 1250000;
              this.MoneyPrinterBought = 1;
              this.Config.SetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this Sub Business");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you allready own this business");
        }
        if (item == Buy3)
        {
          if (this.Config.GetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought) != 1)
          {
            if (Game.Player.Money >= 2350000)
            {
              Game.Player.Money -= 2350000;
              this.WeedFarmBought = 1;
              this.Config.SetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this Sub Business");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you allready own this business");
        }
        if (item == Buy4)
        {
          if (this.Config.GetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought) != 1)
          {
            if (Game.Player.Money >= 2650000)
            {
              Game.Player.Money -= 2650000;
              this.CocaineBought = 1;
              this.Config.SetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this Sub Business");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you allready own this business");
        }
        if (item != Buy5)
          return;
        if (this.Config.GetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought) != 1)
        {
          if (Game.Player.Money >= 3000000)
          {
            Game.Player.Money -= 3000000;
            this.MethLabBought = 1;
            this.Config.SetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this Sub Business");
        }
        else
          UI.Notify(this.GetHostName() + " Sorry Boss you allready own this business");
      });
    }

    private void SetupEnter()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Enter, "Business Type");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Enter1 = new UIMenuItem("Enter Forgery ");
      uiMenu.AddItem(Enter1);
      UIMenuItem Enter2 = new UIMenuItem("Enter Money Printer ");
      uiMenu.AddItem(Enter2);
      UIMenuItem Enter3 = new UIMenuItem("Enter Weed Farm ");
      uiMenu.AddItem(Enter3);
      UIMenuItem Enter4 = new UIMenuItem("Enter Meth Lab ");
      uiMenu.AddItem(Enter4);
      UIMenuItem Enter5 = new UIMenuItem("Enter Cocaine Lockup");
      uiMenu.AddItem(Enter5);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Enter1)
        {
          if (this.Config.GetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought) == 1)
          {
            Game.FadeScreenOut(300);
            Script.Wait(300);
            Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_6_biker_dlc_int_ware05_milo");
            Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 1165, (InputArgument) -3196.6, (InputArgument) -39.01306));
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.Position = this.ForgeryEnter;
            Script.Wait(300);
            Game.FadeScreenIn(1200);
            if (!this.EnteredFakeIDYet)
              this.EnteredFakeIDYet = true;
          }
          else
            UI.Notify(this.GetHostName() + " sorry boss you do not own this sub business, please purchase it first");
        }
        if (item == Enter2)
        {
          if (this.Config.GetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought) == 1)
          {
            Game.FadeScreenOut(300);
            Script.Wait(300);
            Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_5_biker_dlc_int_ware04_milo");
            Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 1121.897, (InputArgument) -3195.338, (InputArgument) -40.4025));
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.Position = this.MoneyPrinterEnter;
            Script.Wait(300);
            Game.FadeScreenIn(1200);
            if (!this.EnteredForgeryYet)
              this.EnteredForgeryYet = true;
          }
          else
            UI.Notify(this.GetHostName() + " sorry boss you do not own this sub business, please purchase it first");
        }
        if (item == Enter3)
        {
          if (this.Config.GetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought) == 1)
          {
            Game.FadeScreenOut(300);
            Script.Wait(300);
            Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_3_biker_dlc_int_ware02_milo");
            Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 1051.491, (InputArgument) -3196.536, (InputArgument) -39.14842));
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.Position = this.WeedFarmEnter;
            Script.Wait(300);
            Game.FadeScreenIn(1200);
            if (!this.EnteredWeedYet)
              this.EnteredWeedYet = true;
          }
          else
            UI.Notify(this.GetHostName() + " sorry boss you do not own this sub business, please purchase it first");
        }
        if (item == Enter4)
        {
          if (this.Config.GetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought) == 1)
          {
            Game.FadeScreenOut(300);
            Script.Wait(300);
            Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_2_biker_dlc_int_ware01_milo");
            Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 1009.5, (InputArgument) -3196.6, (InputArgument) -38.99682));
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.Position = this.MethLabEnter;
            Script.Wait(300);
            Game.FadeScreenIn(1200);
            if (!this.EnteredMethYet)
              this.EnteredMethYet = true;
          }
          else
            UI.Notify(this.GetHostName() + " sorry boss you do not own this sub business, please purchase it first");
        }
        if (item != Enter5)
          return;
        if (this.Config.GetValue<int>("SubBusiness", "CocaineBought", this.CocaineBought) == 1)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_4_biker_dlc_int_ware03_milo");
          int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 1093.6, (InputArgument) -3196.6, (InputArgument) -38.99841);
          this.modMenuPool.CloseAllMenus();
          Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
          Game.Player.Character.Position = this.CocaineEnter;
          Script.Wait(300);
          Game.FadeScreenIn(1200);
          if (!this.EnteredCocaineYet)
            this.EnteredCocaineYet = true;
        }
        else
          UI.Notify(this.GetHostName() + " sorry boss you do not own this sub business, please purchase it first");
      });
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if ((Entity) this.ChairProp_1 != (Entity) null)
        this.ChairProp_1.Delete();
      if ((Entity) this.ChairProp_2 != (Entity) null)
        this.ChairProp_2.Delete();
      if ((Entity) this.ChairProp_3 != (Entity) null)
        this.ChairProp_3.Delete();
      if ((Entity) this.ChairProp_4 != (Entity) null)
        this.ChairProp_4.Delete();
      if ((Entity) this.ChairProp_5 != (Entity) null)
        this.ChairProp_5.Delete();
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if (this.Peds.Count > 0)
        this.Peds.Clear();
      if ((Entity) this.Pallet1 != (Entity) null)
        this.Pallet1.Delete();
      if ((Entity) this.Pallet2 != (Entity) null)
        this.Pallet2.Delete();
      if ((Entity) this.Pallet3 != (Entity) null)
        this.Pallet3.Delete();
      if ((Entity) this.Pallet4 != (Entity) null)
        this.Pallet4.Delete();
      if ((Entity) this.Pallet5 != (Entity) null)
        this.Pallet5.Delete();
      if ((Entity) this.Pallet6 != (Entity) null)
        this.Pallet6.Delete();
      if ((Entity) this.Pallet7 != (Entity) null)
        this.Pallet7.Delete();
      if ((Entity) this.Pallet8 != (Entity) null)
        this.Pallet8.Delete();
      if ((Entity) this.Pallet9 != (Entity) null)
        this.Pallet9.Delete();
      if ((Entity) this.Pallet10 != (Entity) null)
        this.Pallet10.Delete();
      foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
      {
        if ((Entity) mcBusinessSupply != (Entity) null)
          mcBusinessSupply.Delete();
      }
      if (this.MCBusinessSupplies.Count > 0)
        this.MCBusinessSupplies.Clear();
      if (this.DoorCamera != (Camera) null)
      {
        Game.Player.Character.IsInvincible = false;
        Game.Player.Character.FreezePosition = false;
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        this.DoorCamera.IsActive = false;
        this.DoorCamera.Destroy();
      }
      if (this.supplySellProps.Count > 0)
      {
        foreach (Prop supplySellProp in this.supplySellProps)
        {
          if ((Entity) supplySellProp != (Entity) null)
            supplySellProp.Delete();
        }
      }
      if (this.supplySellProps.Count > 0)
        this.supplySellProps.Clear();
      if (this.supplySellVehicles.Count > 0)
      {
        foreach (Vehicle supplySellVehicle in this.supplySellVehicles)
        {
          if ((Entity) supplySellVehicle != (Entity) null)
            supplySellVehicle.Delete();
        }
      }
      if (this.supplySellVehicles.Count > 0)
        this.supplySellVehicles.Clear();
      if (this.SuppyGuards.Count > 0)
      {
        foreach (Ped suppyGuard in this.SuppyGuards)
        {
          if ((Entity) suppyGuard != (Entity) null)
            suppyGuard.Delete();
        }
      }
      foreach (Prop prop in this.PedSyncSeceneProps_group1)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.PedSyncSeceneProps_group1.Count > 0)
        this.PedSyncSeceneProps_group1.Clear();
      foreach (Prop prop in this.PedSyncSeceneProps_group2)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.PedSyncSeceneProps_group2.Count > 0)
        this.PedSyncSeceneProps_group2.Clear();
      foreach (Prop prop in this.PedSyncSeceneProps_group3)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.PedSyncSeceneProps_group3.Count > 0)
        this.PedSyncSeceneProps_group3.Clear();
      if ((Entity) this.PropItem_SetupMission != (Entity) null)
        this.PropItem_SetupMission.Delete();
      if (this.BlipItem_SetupMission != (Blip) null)
        this.BlipItem_SetupMission.Remove();
      if ((Entity) this.VehicleItem_SetupMission != (Entity) null)
        this.VehicleItem_SetupMission.Delete();
      foreach (Blip mcBusinessLocBlip in this.MCBusinessLocBlips)
      {
        if (mcBusinessLocBlip != (Blip) null)
          mcBusinessLocBlip.Remove();
      }
      if ((Entity) this.Weedblocker != (Entity) null)
        this.Weedblocker.Delete();
      foreach (Ped attackPed in this.AttackPeds)
      {
        if ((Entity) attackPed != (Entity) null)
          attackPed.Delete();
      }
      foreach (Vehicle attackVehicle in this.AttackVehicles)
      {
        if ((Entity) attackVehicle != (Entity) null)
          attackVehicle.Delete();
      }
      foreach (Blip blip in this.DropBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      if ((Entity) this.ChairProp_5 != (Entity) null)
        this.ChairProp_5.Delete();
      if ((Entity) this.ChairProp_4 != (Entity) null)
        this.ChairProp_4.Delete();
      if ((Entity) this.ChairProp_3 != (Entity) null)
        this.ChairProp_3.Delete();
      if ((Entity) this.ChairProp_2 != (Entity) null)
        this.ChairProp_2.Delete();
      if ((Entity) this.ChairProp_1 != (Entity) null)
        this.ChairProp_1.Delete();
      foreach (Ped ped in this.Gang)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      foreach (Vehicle gangVehicle in this.GangVehicles)
      {
        if ((Entity) gangVehicle != (Entity) null)
          gangVehicle.Delete();
      }
      if (this.MethBlip != (Blip) null)
        this.MethBlip.Remove();
      if (this.CocaineBlip != (Blip) null)
        this.CocaineBlip.Remove();
      if (this.WeedBlip != (Blip) null)
        this.WeedBlip.Remove();
      if (this.MoneyForgeBlip != (Blip) null)
        this.MoneyForgeBlip.Remove();
      if (this.FakeIDBlip != (Blip) null)
        this.FakeIDBlip.Remove();
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      foreach (Blip blip in this.DropBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      if ((Entity) this.DropVehicle != (Entity) null)
        this.DropVehicle.Delete();
      if (this.DropVehicleBlip != (Blip) null)
        this.DropVehicleBlip.Remove();
      if (this.ballasBlip1 != (Blip) null)
        this.ballasBlip1.Remove();
    }

    private void SetupMarker()
    {
      if (this.UseNewEnterance)
        return;
      this.ballasBlip1 = World.CreateBlip(this.SecondBusinessLoc);
      this.ballasBlip1.Sprite = BlipSprite.DrugPackage;
      this.ballasBlip1.Name = "Biker's Sub Business 1";
      this.ballasBlip1.Color = BlipColor.Yellow;
      this.ballasBlip1.IsShortRange = true;
      UI.Notify("NEW ENTERANCE ON");
    }

    private void OnKeyDown()
    {
      if (!Game.IsControlJustPressed(2, GTA.Control.Context))
        ;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && ((this.Config.GetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought) == 1 || this.Config.GetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought) == 1 || (this.Config.GetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought) == 1 || this.Config.GetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought) == 1) || this.Config.GetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought) == 1) && (double) World.GetDistance(Game.Player.Character.Position, this.SecondBusinessLoc) < 2.0 && !this.mainMenu.Visible))
        this.mainMenu.Visible = !this.mainMenu.Visible;
      if (!this.UseOldMarker)
      {
        Vector3 destination = new Vector3(0.0f, 0.0f, 0.0f);
        float num1 = 0.0f;
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_1) < 2.0)
        {
          destination = this.ChairPos_1;
          num1 = this.P_Rotation_1;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_2) < 2.0)
        {
          destination = this.ChairPos_2;
          num1 = this.P_Rotation_2;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_3) < 2.0)
        {
          destination = this.ChairPos_3;
          num1 = this.P_Rotation_3;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_4) < 2.0)
        {
          destination = this.ChairPos_4;
          num1 = this.P_Rotation_4;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_5) < 2.0)
        {
          destination = this.ChairPos_5;
          num1 = this.P_Rotation_5;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, destination) < 2.0)
        {
          if (this.IsSittinginCeoSeat)
          {
            if ((Game.IsControlJustPressed(2, GTA.Control.FrontendPauseAlternate) || Game.IsControlJustPressed(2, GTA.Control.PhoneCancel)) && this.GUION)
            {
              SecondBusiness.LoadDict("anim@amb@office@boss@male@");
              Prop chair = this.Chair;
              int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chair.Position.X, (InputArgument) chair.Position.Y, (InputArgument) chair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_exit", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chair, (InputArgument) num2, (InputArgument) "computer_exit_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(500);
              this.GUION = false;
              this.GUIHasStarted = false;
              this.GUIFrame = 0;
              if (this.GUIscaleform != null)
                this.GUIscaleform.CallFunction("HIDE_OVERLAY");
            }
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              if (!this.GUION && !this.GUIHasStarted)
              {
                if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_1) < 2.0 && !this.GUION)
                {
                  SecondBusiness.LoadDict("anim@amb@office@boss@male@");
                  Prop chairProp1 = this.ChairProp_1;
                  int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp1.Position.X, (InputArgument) chairProp1.Position.Y, (InputArgument) chairProp1.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp1.Rotation.Z, (InputArgument) 2);
                  Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_enter", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp1, (InputArgument) num2, (InputArgument) "computer_enter_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Script.Wait(500);
                  this.GUION = true;
                  this.GUIHasStarted = false;
                  this.GUIFrame = 0;
                }
                if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_2) < 2.0 && !this.GUION)
                {
                  SecondBusiness.LoadDict("anim@amb@office@boss@male@");
                  Prop chairProp2 = this.ChairProp_2;
                  int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp2.Position.X, (InputArgument) chairProp2.Position.Y, (InputArgument) chairProp2.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp2.Rotation.Z, (InputArgument) 2);
                  Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_enter", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp2, (InputArgument) num2, (InputArgument) "computer_enter_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Script.Wait(500);
                  this.GUION = true;
                  this.GUIHasStarted = false;
                  this.GUIFrame = 0;
                }
                if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_3) < 2.0 && !this.GUION)
                {
                  SecondBusiness.LoadDict("anim@amb@office@boss@male@");
                  Prop chairProp3 = this.ChairProp_3;
                  int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp3.Position.X, (InputArgument) chairProp3.Position.Y, (InputArgument) chairProp3.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp3.Rotation.Z, (InputArgument) 2);
                  Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_enter", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp3, (InputArgument) num2, (InputArgument) "computer_enter_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Script.Wait(500);
                  this.GUION = true;
                  this.GUIHasStarted = false;
                  this.GUIFrame = 0;
                }
                if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_4) < 2.0 && !this.GUION)
                {
                  SecondBusiness.LoadDict("anim@amb@office@boss@male@");
                  Prop chairProp4 = this.ChairProp_4;
                  int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp4.Position.X, (InputArgument) chairProp4.Position.Y, (InputArgument) chairProp4.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp4.Rotation.Z, (InputArgument) 2);
                  Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_enter", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp4, (InputArgument) num2, (InputArgument) "computer_enter_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Script.Wait(500);
                  this.GUION = true;
                  this.GUIHasStarted = false;
                  this.GUIFrame = 0;
                }
                if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_5) < 2.0 && !this.GUION)
                {
                  SecondBusiness.LoadDict("anim@amb@office@boss@male@");
                  Prop chairProp5 = this.ChairProp_5;
                  int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp5.Position.X, (InputArgument) chairProp5.Position.Y, (InputArgument) chairProp5.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp5.Rotation.Z, (InputArgument) 2);
                  Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_enter", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp5, (InputArgument) num2, (InputArgument) "computer_enter_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                  Script.Wait(500);
                  this.GUION = true;
                  this.GUIHasStarted = false;
                  this.GUIFrame = 0;
                }
              }
              else if (this.GUION || this.GUIHasStarted)
              {
                SecondBusiness.LoadDict("anim@amb@office@boss@male@");
                Prop chair = this.Chair;
                int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chair.Position.X, (InputArgument) chair.Position.Y, (InputArgument) chair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chair.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_exit", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chair, (InputArgument) num2, (InputArgument) "computer_exit_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(500);
                this.GUION = false;
                this.GUIHasStarted = false;
                this.GUIFrame = 0;
                if (this.GUIscaleform != null)
                  this.GUIscaleform.CallFunction("HIDE_OVERLAY");
              }
            }
            if (Game.IsControlJustPressed(2, GTA.Control.Cover))
            {
              Script.Wait(500);
              this.GUION = false;
              this.GUIHasStarted = false;
              this.GUIFrame = 0;
              if (this.GUIscaleform != null)
                this.GUIscaleform.CallFunction("HIDE_OVERLAY");
              this.modMenuPool.CloseAllMenus();
              Prop prop = this.ChairProp_1;
              if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_1) < 10.0)
                prop = this.ChairProp_1;
              if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_2) < 10.0)
                prop = this.ChairProp_2;
              if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_3) < 10.0)
                prop = this.ChairProp_3;
              if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_4) < 10.0)
                prop = this.ChairProp_4;
              if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_5) < 10.0)
                prop = this.ChairProp_5;
              int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) prop.Position.X, (InputArgument) prop.Position.Y, (InputArgument) prop.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) prop.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "exit", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) prop, (InputArgument) num2, (InputArgument) "exit_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(4000);
              Game.Player.Character.Task.ClearAll();
              this.IsSittinginCeoSeat = false;
            }
          }
          else if (!this.IsSittinginCeoSeat && Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            Script.Wait(500);
            this.GUION = false;
            this.GUIHasStarted = false;
            this.GUIFrame = 0;
            if (this.GUIscaleform != null)
              this.GUIscaleform.CallFunction("HIDE_OVERLAY");
            this.modMenuPool.CloseAllMenus();
            Prop prop = this.ChairProp_1;
            if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_1) < 10.0)
            {
              prop = this.ChairProp_1;
              this.Chair = prop;
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_2) < 10.0)
            {
              prop = this.ChairProp_2;
              this.Chair = prop;
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_3) < 10.0)
            {
              prop = this.ChairProp_3;
              this.Chair = prop;
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_4) < 10.0)
            {
              prop = this.ChairProp_4;
              this.Chair = prop;
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos_5) < 10.0)
            {
              prop = this.ChairProp_5;
              this.Chair = prop;
            }
            Script.Wait(100);
            string str = "anim@amb@office@boss@male@";
            SecondBusiness.LoadDict("anim@amb@office@boss@male@");
            if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) str))
            {
              int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) prop.Position.X, (InputArgument) prop.Position.Y, (InputArgument) prop.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) prop.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "enter", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) prop, (InputArgument) num2, (InputArgument) "enter_chair", (InputArgument) SecondBusiness.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(5000);
              this.IsSittinginCeoSeat = true;
            }
          }
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, destination) < 2.0)
        {
          if (this.IsSittinginCeoSeat)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open Menu, Press ~INPUT_COVER~ to Exit");
          else
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to sit on chair to access Menu");
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, destination) > 4.0 && this.IsSittinginCeoSeat)
        {
          this.IsSittinginCeoSeat = false;
          Game.Player.Character.FreezePosition = true;
          Game.FadeScreenOut(500);
          Script.Wait(500);
          Game.Player.Character.Position = new Vector3(destination.X, destination.Y, destination.Z - 0.5f);
          Game.Player.Character.Heading = num1;
          Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
          Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
          Game.Player.Character.Task.ClearAnimation("anim@amb@office@laptops@male@var_c@base@", "base");
          Game.Player.Character.FreezePosition = false;
          Script.Wait(500);
          Game.FadeScreenIn(500);
        }
      }
      if (this.UseOldMarker)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.Config.GetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought) == 1 && ((double) World.GetDistance(Game.Player.Character.Position, this.MethMenu) < 2.0 && !this.MethUIMenu.Visible))
          this.MethUIMenu.Visible = !this.MethUIMenu.Visible;
        if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.Config.GetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought) == 1 && ((double) World.GetDistance(Game.Player.Character.Position, this.CocaineMenu) < 2.0 && !this.CocaineUIMenu.Visible))
          this.CocaineUIMenu.Visible = !this.CocaineUIMenu.Visible;
        if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.Config.GetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought) == 1 && ((double) World.GetDistance(Game.Player.Character.Position, this.WeedMenu) < 2.0 && !this.WeedUIMenu.Visible))
          this.WeedUIMenu.Visible = !this.WeedUIMenu.Visible;
        if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.Config.GetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought) == 1 && ((double) World.GetDistance(Game.Player.Character.Position, this.ForgeryMenu) < 2.0 && !this.ForgeryUIMenu.Visible))
          this.ForgeryUIMenu.Visible = !this.ForgeryUIMenu.Visible;
        if (Game.IsControlJustPressed(2, GTA.Control.Context) && !this.MoneyPrinterMenuPool.IsAnyMenuOpen() && this.Config.GetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought) == 1 && ((double) World.GetDistance(Game.Player.Character.Position, this.MoneyPrinterMenu) < 2.0 && !this.MoneyPrinterUIMenu.Visible))
          this.MoneyPrinterUIMenu.Visible = !this.MoneyPrinterUIMenu.Visible;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.ForgeryEnter) < 2.0 && this.Config.GetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought) == 1)
      {
        if (!this.UseNewEnterance)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SecondBusinessLoc;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
        }
        if (this.UseNewEnterance)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.ForgeryExit;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.WeedFarmEnter) < 2.0 && this.Config.GetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought) == 1)
      {
        if (!this.UseNewEnterance)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SecondBusinessLoc;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
        }
        if (this.UseNewEnterance)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.WeedFarmExit;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MoneyPrinterEnter) < 2.0 && this.Config.GetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought) == 1)
      {
        if (!this.UseNewEnterance)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SecondBusinessLoc;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
        }
        if (this.UseNewEnterance)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.MoneyPrinterExit;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.CocaineEnter) < 2.0 && this.Config.GetValue<int>("SubBusiness", "CocaineBought", this.CocaineBought) == 1)
      {
        if (!this.UseNewEnterance)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SecondBusinessLoc;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
        }
        if (this.UseNewEnterance)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.CocaineExit;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MethLabEnter) < 2.0 && this.Config.GetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought) == 1 && this.UseNewEnterance)
      {
        Game.FadeScreenOut(600);
        Script.Wait(600);
        Game.Player.Character.Position = this.MethLabExit;
        Script.Wait(600);
        Game.FadeScreenIn(1200);
      }
      if (this.MissionOn)
        return;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MCSubLocForgery[this.ForgeryMCbusinessLoc].Enterance) < 2.0 && this.Config.GetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought) == 1 && this.UseNewEnterance)
      {
        Vector3 enterance = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].Enterance;
        float enteranceHeading = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].EnteranceHeading;
        Game.Player.Character.Position = enterance;
        Game.Player.Character.Heading = enteranceHeading;
        Vector3 offsetInWorldCoords = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0.0f, 1.4f, 0.0f));
        Game.Player.Character.Position = offsetInWorldCoords;
        if (this.DoorCamera != (Camera) null)
        {
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        if (this.MCSubLocForgery[this.ForgeryMCbusinessLoc].DoorEnter.Equals("Right"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading + 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        if (this.MCSubLocForgery[this.ForgeryMCbusinessLoc].DoorEnter.Equals("Left"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(-3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading - 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        SecondBusiness.LoadDict("anim@apt_trans@hinge_l");
        float heading = Game.Player.Character.Heading;
        this.DoorScene = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) offsetInWorldCoords.X, (InputArgument) offsetInWorldCoords.Y, (InputArgument) (offsetInWorldCoords.Z - 1f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) heading, (InputArgument) 2);
        Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) "ext_player", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.DoorScene, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.DoorScene));
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) "ext_player", (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Script.Wait(3000);
        if (this.DoorCamera != (Camera) null)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        this.LastEnt = this.ForgeryExit;
        Game.Player.Character.Position = this.ForgeryEnter;
        Script.Wait(600);
        Game.FadeScreenIn(1200);
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MCSubLocWeed[this.WeedMCbusinessLoc].Enterance) < 2.0 && this.Config.GetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought) == 1 && this.UseNewEnterance)
      {
        Vector3 enterance = this.MCSubLocWeed[this.WeedMCbusinessLoc].Enterance;
        float enteranceHeading = this.MCSubLocWeed[this.WeedMCbusinessLoc].EnteranceHeading;
        Game.Player.Character.Position = enterance;
        Game.Player.Character.Heading = enteranceHeading;
        Vector3 offsetInWorldCoords = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0.0f, 1.4f, 0.0f));
        Game.Player.Character.Position = offsetInWorldCoords;
        if (this.DoorCamera != (Camera) null)
        {
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        if (this.MCSubLocWeed[this.WeedMCbusinessLoc].DoorEnter.Equals("Right"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading + 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        if (this.MCSubLocWeed[this.WeedMCbusinessLoc].DoorEnter.Equals("Left"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(-3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading - 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        SecondBusiness.LoadDict("anim@apt_trans@hinge_l");
        float heading = Game.Player.Character.Heading;
        this.DoorScene = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) offsetInWorldCoords.X, (InputArgument) offsetInWorldCoords.Y, (InputArgument) (offsetInWorldCoords.Z - 1f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) heading, (InputArgument) 2);
        Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) "ext_player", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.DoorScene, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.DoorScene));
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) "ext_player", (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Script.Wait(3000);
        if (this.DoorCamera != (Camera) null)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        this.LastEnt = this.WeedFarmExit;
        Game.Player.Character.Position = this.WeedFarmEnter;
        Script.Wait(600);
        Game.FadeScreenIn(1200);
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].Enterance) < 2.0 && this.Config.GetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought) == 1 && this.UseNewEnterance)
      {
        Vector3 enterance = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].Enterance;
        float enteranceHeading = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].EnteranceHeading;
        Game.Player.Character.Position = enterance;
        Game.Player.Character.Heading = enteranceHeading;
        Vector3 offsetInWorldCoords = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0.0f, 1.4f, 0.0f));
        Game.Player.Character.Position = offsetInWorldCoords;
        if (this.DoorCamera != (Camera) null)
        {
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        if (this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].DoorEnter.Equals("Right"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading + 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        if (this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].DoorEnter.Equals("Left"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(-3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading - 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        SecondBusiness.LoadDict("anim@apt_trans@hinge_l");
        float heading = Game.Player.Character.Heading;
        this.DoorScene = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) offsetInWorldCoords.X, (InputArgument) offsetInWorldCoords.Y, (InputArgument) (offsetInWorldCoords.Z - 1f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) heading, (InputArgument) 2);
        Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) "ext_player", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.DoorScene, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.DoorScene));
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) "ext_player", (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Script.Wait(3000);
        if (this.DoorCamera != (Camera) null)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        this.LastEnt = this.MoneyPrinterExit;
        Game.Player.Character.Position = this.MoneyPrinterEnter;
        Script.Wait(600);
        Game.FadeScreenIn(1200);
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MCSubLocCocaine[this.CocaineMCbusinessLoc].Enterance) < 2.0 && this.Config.GetValue<int>("SubBusiness", "CocaineBought", this.CocaineBought) == 1 && this.UseNewEnterance)
      {
        Vector3 enterance = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].Enterance;
        float enteranceHeading = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].EnteranceHeading;
        Game.Player.Character.Position = enterance;
        Game.Player.Character.Heading = enteranceHeading;
        Vector3 offsetInWorldCoords = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0.0f, 1.4f, 0.0f));
        Game.Player.Character.Position = offsetInWorldCoords;
        if (this.DoorCamera != (Camera) null)
        {
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        if (this.MCSubLocCocaine[this.CocaineMCbusinessLoc].DoorEnter.Equals("Right"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading + 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        if (this.MCSubLocCocaine[this.CocaineMCbusinessLoc].DoorEnter.Equals("Left"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(-3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading - 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        SecondBusiness.LoadDict("anim@apt_trans@hinge_l");
        float heading = Game.Player.Character.Heading;
        this.DoorScene = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) offsetInWorldCoords.X, (InputArgument) offsetInWorldCoords.Y, (InputArgument) (offsetInWorldCoords.Z - 1f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) heading, (InputArgument) 2);
        Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) "ext_player", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.DoorScene, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.DoorScene));
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) "ext_player", (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Script.Wait(3000);
        if (this.DoorCamera != (Camera) null)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        this.LastEnt = this.CocaineExit;
        Game.Player.Character.Position = this.CocaineEnter;
        Script.Wait(600);
        Game.FadeScreenIn(1200);
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MCSubLocMeth[this.MethMCbusinessLoc].Enterance) < 2.0 && this.Config.GetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought) == 1 && this.UseNewEnterance)
      {
        Vector3 enterance = this.MCSubLocMeth[this.MethMCbusinessLoc].Enterance;
        float enteranceHeading = this.MCSubLocMeth[this.MethMCbusinessLoc].EnteranceHeading;
        Game.Player.Character.Position = enterance;
        Game.Player.Character.Heading = enteranceHeading;
        Vector3 offsetInWorldCoords = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0.0f, 1.4f, 0.0f));
        Game.Player.Character.Position = offsetInWorldCoords;
        if (this.DoorCamera != (Camera) null)
        {
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        if (this.MCSubLocMeth[this.MethMCbusinessLoc].DoorEnter.Equals("Right"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading + 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        if (this.MCSubLocMeth[this.MethMCbusinessLoc].DoorEnter.Equals("Left"))
        {
          this.DoorCamera = World.CreateCamera(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(-3f, -0.35f, -0.5f)), new Vector3(0.0f, 0.0f, enteranceHeading - 90f), 20f);
          World.RenderingCamera = this.DoorCamera;
          this.DoorCamera.IsActive = true;
          this.DoorCamera.FarClip = 2000f;
        }
        SecondBusiness.LoadDict("anim@apt_trans@hinge_l");
        float heading = Game.Player.Character.Heading;
        this.DoorScene = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) offsetInWorldCoords.X, (InputArgument) offsetInWorldCoords.Y, (InputArgument) (offsetInWorldCoords.Z - 1f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) heading, (InputArgument) 2);
        Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) "ext_player", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.DoorScene, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.DoorScene));
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.DoorScene, (InputArgument) "ext_player", (InputArgument) SecondBusiness.LoadDict("anim@apt_trans@hinge_l"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        Script.Wait(3000);
        if (this.DoorCamera != (Camera) null)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.FreezePosition = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DoorCamera.IsActive = false;
          this.DoorCamera.Destroy();
        }
        this.LastEnt = this.MethLabExit;
        Game.Player.Character.Position = this.MethLabEnter;
        Script.Wait(600);
        Game.FadeScreenIn(1200);
      }
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

    public void ResetMCBusines(int b)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      if (b == 1)
      {
        Game.FadeScreenOut(600);
        Script.Wait(600);
        Script.Wait(600);
        Game.FadeScreenIn(1200);
        if (this.MethMCbusinessLoc <= this.MCSubLocMeth.Count)
        {
          this.MethLabExit = this.MCSubLocMeth[this.MethMCbusinessLoc].Enterance;
          Game.Player.Character.Position = this.MethLabExit;
          this.IsSittinginCeoSeat = false;
          this.GUIHasStarted = false;
          this.GUIFrame = -1;
          this.GUION = false;
          if (this.MethBlip != (Blip) null)
            this.MethBlip.Remove();
          this.MethLabExit = new Vector3(0.0f, 0.0f, 0.0f);
        }
        this.MethLabBought = 0;
        this.Config.SetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought);
        this.MethMCbusinessLoc = 0;
        this.Config.SetValue<int>("SubBusiness", "MethMCbusinessLoc", this.MethMCbusinessLoc);
        this.MethLab_InitialSetupDone = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "MethLab_InitialSetupDone", this.MethLab_InitialSetupDone);
        this.MethLab_EquipmentUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "MethLab_EquipmentUpgrade", this.MethLab_EquipmentUpgrade);
        this.MethLab_StaffUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "MethLab_StaffUpgrade", this.MethLab_StaffUpgrade);
        this.MethLab_SecurityUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "MethLab_SecurityUpgrade", this.MethLab_SecurityUpgrade);
        this.MethLab_TotalEarnings = 0.0f;
        this.Config.SetValue<float>("SubBusiness-MethLab-Stats", "MethLab_TotalEarnings", this.MethLab_TotalEarnings);
        this.MethLab_TotalResupplySuccess = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalResupplySuccess", this.MethLab_TotalResupplySuccess);
        this.MethLab_TotalResupplyFails = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalResupplyFails", this.MethLab_TotalResupplyFails);
        this.MethLab_TotalSales_LS = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalSales_LS", this.MethLab_TotalSales_LS);
        this.MethLab_TotalFails_LS = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalFails_LS", this.MethLab_TotalFails_LS);
        this.MethLab_TotalSales_BC = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalSales_BC", this.MethLab_TotalSales_BC);
        this.MethLab_TotalFails_BC = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalFails_BC", this.MethLab_TotalFails_BC);
        this.MethLab_Supplies = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_Supplies", this.MethLab_Supplies);
        this.MethLab_ProductionCeased_NoSupplies = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoSupplies", this.MethLab_ProductionCeased_NoSupplies);
        this.MethLab_ProductionCeased_NoRaided = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoRaided", this.MethLab_ProductionCeased_NoRaided);
        this.MethLab_ProductionCeased_NoCapacity = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoCapacity", this.MethLab_ProductionCeased_NoCapacity);
        this.MethLab_StoppedProducing = false;
        this.Config.SetValue<bool>("SubBusiness-MethLab-Stats", "MethLab_StoppedProducing", this.MethLab_StoppedProducing);
        this.MethLab_BuySuppliesMultiplier = 1f;
        this.Config.SetValue<float>("SubBusiness-MethLab-Stats", "MethLab_BuySuppliesMultiplier", this.MethLab_BuySuppliesMultiplier);
        this.MethLab_SellProductMutliplier = 1f;
        this.Config.SetValue<float>("SubBusiness-MethLab-Stats", "MethLab_SellProductMutliplier", this.MethLab_SellProductMutliplier);
        this.MethLab_ProductMax = 100;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductMax", this.MethLab_ProductMax);
        this.MethLab_ProductBags = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductBags", this.MethLab_ProductBags);
        this.SETMethLab_ProductValue = 0.0f;
        this.Config.SetValue<float>("SubBusiness-MethLab-Stats", "MethLab_ProductValue", this.SETMethLab_ProductValue);
        this.Config.Save();
        UI.Notify("Meth Lab MC Business has been Fully Reset");
      }
      if (b == 3)
      {
        Game.FadeScreenOut(600);
        Script.Wait(600);
        Script.Wait(600);
        Game.FadeScreenIn(1200);
        if (this.WeedMCbusinessLoc <= this.MCSubLocWeed.Count)
        {
          this.WeedFarmExit = this.MCSubLocWeed[this.WeedMCbusinessLoc].Enterance;
          Game.Player.Character.Position = this.WeedFarmExit;
          this.IsSittinginCeoSeat = false;
          this.GUIHasStarted = false;
          this.GUIFrame = -1;
          this.GUION = false;
          if (this.WeedBlip != (Blip) null)
            this.WeedBlip.Remove();
          this.WeedFarmExit = new Vector3(0.0f, 0.0f, 0.0f);
        }
        this.WeedFarmBought = 0;
        this.Config.SetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought);
        this.WeedMCbusinessLoc = 0;
        this.Config.SetValue<int>("SubBusiness", "WeedMCbusinessLoc", this.WeedMCbusinessLoc);
        this.WeedFarm_InitialSetupDone = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "WeedFarm_InitialSetupDone", this.WeedFarm_InitialSetupDone);
        this.WeedFarm_EquipmentUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "WeedFarm_EquipmentUpgrade", this.WeedFarm_EquipmentUpgrade);
        this.WeedFarm_StaffUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "WeedFarm_StaffUpgrade", this.WeedFarm_StaffUpgrade);
        this.WeedFarm_SecurityUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "WeedFarm_SecurityUpgrade", this.WeedFarm_SecurityUpgrade);
        this.WeedFarm_TotalEarnings = 0.0f;
        this.Config.SetValue<float>("SubBusiness-Weedfarm-Stats", "MethLab_TotalEarnings", this.MethLab_TotalEarnings);
        this.WeedFarm_TotalResupplySuccess = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalResupplySuccess", this.WeedFarm_TotalResupplySuccess);
        this.WeedFarm_TotalResupplyFails = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalResupplyFails", this.WeedFarm_TotalResupplyFails);
        this.WeedFarm_TotalSales_LS = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalSales_LS", this.WeedFarm_TotalSales_LS);
        this.WeedFarm_TotalFails_LS = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalFails_LS", this.WeedFarm_TotalFails_LS);
        this.WeedFarm_TotalSales_BC = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalSales_BC", this.WeedFarm_TotalSales_BC);
        this.WeedFarm_TotalFails_BC = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalFails_BC", this.WeedFarm_TotalFails_BC);
        this.WeedFarm_Supplies = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_Supplies", this.WeedFarm_Supplies);
        this.WeedFarm_ProductionCeased_NoSupplies = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoSupplies", this.WeedFarm_ProductionCeased_NoSupplies);
        this.WeedFarm_ProductionCeased_NoRaided = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoRaided", this.WeedFarm_ProductionCeased_NoRaided);
        this.WeedFarm_ProductionCeased_NoCapacity = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoCapacity", this.WeedFarm_ProductionCeased_NoCapacity);
        this.WeedFarm_StoppedProducing = false;
        this.Config.SetValue<bool>("SubBusiness-Weedfarm-Stats", "WeedFarm_StoppedProducing", this.WeedFarm_StoppedProducing);
        this.WeedFarm_BuySuppliesMultiplier = 1f;
        this.Config.SetValue<float>("SubBusiness-Weedfarm-Stats", "WeedFarm_BuySuppliesMultiplier", this.WeedFarm_BuySuppliesMultiplier);
        this.WeedFarm_SellProductMutliplier = 1f;
        this.Config.SetValue<float>("SubBusiness-Weedfarm-Stats", "WeedFarm_SellProductMutliplier", this.WeedFarm_SellProductMutliplier);
        this.WeedFarm_ProductMax = 100;
        this.Config.SetValue<int>("SubBusiness-WeedFarm-Weedfarm-Stats", "WeedFarm_ProductMax", this.WeedFarm_ProductMax);
        this.WeedFarm_ProductBags = 0;
        this.Config.SetValue<int>("SubBusiness-WeedFarm-Stats", "WeedFarm_ProductBags", this.WeedFarm_ProductBags);
        this.SETWeedFarm_ProductValue = 0.0f;
        this.Config.SetValue<float>("SubBusiness-WeedFarm-Stats", "WeedFarm_ProductValue", this.SETWeedFarm_ProductValue);
        this.Config.Save();
        UI.Notify("Weed Farm MC Business has been Fully Reset");
      }
      if (b == 2)
      {
        Game.FadeScreenOut(600);
        Script.Wait(600);
        Script.Wait(600);
        Game.FadeScreenIn(1200);
        if (this.CocaineMCbusinessLoc <= this.MCSubLocCocaine.Count)
        {
          this.CocaineExit = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].Enterance;
          Game.Player.Character.Position = this.CocaineExit;
          this.IsSittinginCeoSeat = false;
          this.GUIHasStarted = false;
          this.GUIFrame = -1;
          this.GUION = false;
          if (this.CocaineBlip != (Blip) null)
            this.CocaineBlip.Remove();
          this.CocaineExit = new Vector3(0.0f, 0.0f, 0.0f);
        }
        this.CocaineBought = 0;
        this.Config.SetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought);
        this.CocaineMCbusinessLoc = 0;
        this.Config.SetValue<int>("SubBusiness", "CocaineMCbusinessLoc", this.CocaineMCbusinessLoc);
        this.CocaineLockup_InitialSetupDone = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_InitialSetupDone", this.CocaineLockup_InitialSetupDone);
        this.CocaineLockup_EquipmentUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_EquipmentUpgrade", this.CocaineLockup_EquipmentUpgrade);
        this.CocaineLockup_StaffUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_StaffUpgrade", this.CocaineLockup_StaffUpgrade);
        this.CocaineLockup_SecurityUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_SecurityUpgrade", this.CocaineLockup_SecurityUpgrade);
        this.CocaineLockup_TotalEarnings = 0.0f;
        this.Config.SetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalEarnings", this.CocaineLockup_TotalEarnings);
        this.CocaineLockup_TotalResupplySuccess = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalResupplySuccess", this.CocaineLockup_TotalResupplySuccess);
        this.CocaineLockup_TotalResupplyFails = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalResupplyFails", this.CocaineLockup_TotalResupplyFails);
        this.CocaineLockup_TotalSales_LS = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalSales_LS", this.CocaineLockup_TotalSales_LS);
        this.CocaineLockup_TotalFails_LS = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalFails_LS", this.CocaineLockup_TotalFails_LS);
        this.CocaineLockup_TotalSales_BC = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalSales_BC", this.CocaineLockup_TotalSales_BC);
        this.CocaineLockup_TotalFails_BC = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalFails_BC", this.CocaineLockup_TotalFails_BC);
        this.CocaineLockup_Supplies = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_Supplies", this.CocaineLockup_Supplies);
        this.CocaineLockup_ProductionCeased_NoSupplies = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoSupplies", this.CocaineLockup_ProductionCeased_NoSupplies);
        this.CocaineLockup_ProductionCeased_NoRaided = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoRaided", this.CocaineLockup_ProductionCeased_NoRaided);
        this.CocaineLockup_ProductionCeased_NoCapacity = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoCapacity", this.CocaineLockup_ProductionCeased_NoCapacity);
        this.CocaineLockup_StoppedProducing = false;
        this.Config.SetValue<bool>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_StoppedProducing", this.CocaineLockup_StoppedProducing);
        this.CocaineLockup_BuySuppliesMultiplier = 1f;
        this.Config.SetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_BuySuppliesMultiplier", this.CocaineLockup_BuySuppliesMultiplier);
        this.CocaineLockup_SellProductMutliplier = 1f;
        this.Config.SetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_SellProductMutliplier", this.CocaineLockup_SellProductMutliplier);
        this.CocaineLockup_ProductMax = 100;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductMax", this.CocaineLockup_ProductMax);
        this.CocaineLockup_ProductBags = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductBags", this.CocaineLockup_ProductBags);
        this.SETCocaineLockup_ProductValue = 0.0f;
        this.Config.SetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductValue", this.SETCocaineLockup_ProductValue);
        this.Config.Save();
        UI.Notify("Cocaine Lockup MC Business has been Fully Reset");
      }
      if (b == 5)
      {
        Game.FadeScreenOut(600);
        Script.Wait(600);
        Script.Wait(600);
        Game.FadeScreenIn(1200);
        if (this.CounterfietMCbusinessLoc <= this.MCSubLocCounterfiet.Count)
        {
          this.MoneyPrinterExit = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].Enterance;
          Game.Player.Character.Position = this.MoneyPrinterExit;
          this.IsSittinginCeoSeat = false;
          this.GUIHasStarted = false;
          this.GUIFrame = -1;
          this.GUION = false;
          if (this.MoneyForgeBlip != (Blip) null)
            this.MoneyForgeBlip.Remove();
          this.MoneyPrinterExit = new Vector3(0.0f, 0.0f, 0.0f);
        }
        this.MoneyPrinterBought = 0;
        this.Config.SetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought);
        this.CounterfietMCbusinessLoc = 0;
        this.Config.SetValue<int>("SubBusiness", "CounterfietMCbusinessLoc", this.CounterfietMCbusinessLoc);
        this.CounterfeitOffice_InitialSetupDone = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_InitialSetupDone", this.CounterfeitOffice_InitialSetupDone);
        this.CounterfeitOffice_EquipmentUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_EquipmentUpgrade", this.CounterfeitOffice_EquipmentUpgrade);
        this.CounterfeitOffice_StaffUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_StaffUpgrade", this.CounterfeitOffice_StaffUpgrade);
        this.CounterfeitOffice_SecurityUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_SecurityUpgrade", this.CounterfeitOffice_SecurityUpgrade);
        this.CounterfeitOffice_TotalEarnings = 0.0f;
        this.Config.SetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalEarnings", this.CounterfeitOffice_TotalEarnings);
        this.CounterfeitOffice_TotalResupplySuccess = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalResupplySuccess", this.CounterfeitOffice_TotalResupplySuccess);
        this.CounterfeitOffice_TotalResupplyFails = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalResupplyFails", this.CounterfeitOffice_TotalResupplyFails);
        this.CounterfeitOffice_TotalSales_LS = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalSales_LS", this.CounterfeitOffice_TotalSales_LS);
        this.CounterfeitOffice_TotalFails_LS = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalFails_LS", this.CounterfeitOffice_TotalFails_LS);
        this.CounterfeitOffice_TotalSales_BC = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalSales_BC", this.CounterfeitOffice_TotalSales_BC);
        this.CounterfeitOffice_TotalFails_BC = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalFails_BC", this.CounterfeitOffice_TotalFails_BC);
        this.CounterfeitOffice_Supplies = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_Supplies", this.CounterfeitOffice_Supplies);
        this.CounterfeitOffice_ProductionCeased_NoSupplies = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoSupplies", this.CounterfeitOffice_ProductionCeased_NoSupplies);
        this.CounterfeitOffice_ProductionCeased_NoRaided = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoRaided", this.CounterfeitOffice_ProductionCeased_NoRaided);
        this.CounterfeitOffice_ProductionCeased_NoCapacity = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoCapacity", this.CounterfeitOffice_ProductionCeased_NoCapacity);
        this.CounterfeitOffice_StoppedProducing = false;
        this.Config.SetValue<bool>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_StoppedProducing", this.CounterfeitOffice_StoppedProducing);
        this.CounterfeitOffice_BuySuppliesMultiplier = 1f;
        this.Config.SetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_BuySuppliesMultiplier", this.CounterfeitOffice_BuySuppliesMultiplier);
        this.CounterfeitOffice_SellProductMutliplier = 1f;
        this.Config.SetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_SellProductMutliplier", this.CounterfeitOffice_SellProductMutliplier);
        this.CounterfeitOffice_ProductMax = 100;
        this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "CounterfeitOffice_ProductMax", this.CounterfeitOffice_ProductMax);
        this.CounterfeitOffice_ProductBags = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductBags", this.CounterfeitOffice_ProductBags);
        this.SETCounterfeitOffice_ProductValue = 0.0f;
        this.Config.SetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductValue", this.SETCounterfeitOffice_ProductValue);
        this.Config.Save();
        UI.Notify("Counterfeit Office MC Business has been Fully Reset");
      }
      if (b != 4)
        return;
      Game.FadeScreenOut(600);
      Script.Wait(600);
      Script.Wait(600);
      Game.FadeScreenIn(1200);
      if (this.ForgeryMCbusinessLoc <= this.MCSubLocForgery.Count)
      {
        this.ForgeryExit = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].Enterance;
        Game.Player.Character.Position = this.ForgeryExit;
        this.IsSittinginCeoSeat = false;
        this.GUIHasStarted = false;
        this.GUIFrame = -1;
        this.GUION = false;
        if (this.FakeIDBlip != (Blip) null)
          this.FakeIDBlip.Remove();
        this.ForgeryExit = new Vector3(0.0f, 0.0f, 0.0f);
      }
      this.ForgeryBought = 0;
      this.Config.SetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought);
      this.ForgeryMCbusinessLoc = 0;
      this.Config.SetValue<int>("SubBusiness", "ForgeryMCbusinessLoc", this.ForgeryMCbusinessLoc);
      this.DocumentForgery_InitialSetupDone = false;
      this.Config.SetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_InitialSetupDone", this.DocumentForgery_InitialSetupDone);
      this.DocumentForgery_EquipmentUpgrade = false;
      this.Config.SetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_EquipmentUpgrade", this.DocumentForgery_EquipmentUpgrade);
      this.DocumentForgery_StaffUpgrade = false;
      this.Config.SetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_StaffUpgrade", this.DocumentForgery_StaffUpgrade);
      this.DocumentForgery_SecurityUpgrade = false;
      this.Config.SetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_SecurityUpgrade", this.DocumentForgery_SecurityUpgrade);
      this.DocumentForgery_TotalEarnings = 0.0f;
      this.Config.SetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalEarnings", this.DocumentForgery_TotalEarnings);
      this.DocumentForgery_TotalResupplySuccess = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalResupplySuccess", this.DocumentForgery_TotalResupplySuccess);
      this.DocumentForgery_TotalResupplyFails = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalResupplyFails", this.DocumentForgery_TotalResupplyFails);
      this.DocumentForgery_TotalSales_LS = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalSales_LS", this.DocumentForgery_TotalSales_LS);
      this.DocumentForgery_TotalFails_LS = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalFails_LS", this.DocumentForgery_TotalFails_LS);
      this.DocumentForgery_TotalSales_BC = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalSales_BC", this.DocumentForgery_TotalSales_BC);
      this.DocumentForgery_TotalFails_BC = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalFails_BC", this.DocumentForgery_TotalFails_BC);
      this.DocumentForgery_Supplies = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_Supplies", this.DocumentForgery_Supplies);
      this.DocumentForgery_ProductionCeased_NoSupplies = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoSupplies", this.DocumentForgery_ProductionCeased_NoSupplies);
      this.DocumentForgery_ProductionCeased_NoRaided = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoRaided", this.DocumentForgery_ProductionCeased_NoRaided);
      this.DocumentForgery_ProductionCeased_NoCapacity = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoCapacity", this.DocumentForgery_ProductionCeased_NoCapacity);
      this.DocumentForgery_BuySuppliesMultiplier = 1f;
      this.Config.SetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_BuySuppliesMultiplier", this.DocumentForgery_BuySuppliesMultiplier);
      this.DocumentForgery_SellProductMutliplier = 1f;
      this.Config.SetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_SellProductMutliplier", this.DocumentForgery_SellProductMutliplier);
      this.DocumentForgery_StoppedProducing = false;
      this.Config.SetValue<bool>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_StoppedProducing", this.DocumentForgery_StoppedProducing);
      this.DocumentForgery_ProductMax = 100;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductMax", this.DocumentForgery_ProductMax);
      this.DocumentForgery_ProductBags = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductBags", this.DocumentForgery_ProductBags);
      this.SETDocumentForgery_ProductValue = 0.0f;
      this.Config.SetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductValue", this.SETDocumentForgery_ProductValue);
      this.Config.Save();
      UI.Notify("Document Forgery MC Business has been Fully Reset");
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.Key1 = this.Config.GetValue<Keys>("Configurations", "Key1", this.Key1);
        this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
        this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
        this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.UseOldMarker = this.Config.GetValue<bool>("Setup", "UseOldMarker", this.UseOldMarker);
        this.UseNewEnterance = this.Config.GetValue<bool>("Setup", "UseNewEnterance", this.UseNewEnterance);
        this.ForgeryBought = this.Config.GetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought);
        this.WeedFarmBought = this.Config.GetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought);
        this.MoneyPrinterBought = this.Config.GetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought);
        this.MethLabBought = this.Config.GetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought);
        this.CocaineBought = this.Config.GetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought);
        this.UseGTAO_ProductMax = this.Config.GetValue<bool>("SubBusiness", "UseGTAO_ProductMax", this.UseGTAO_ProductMax);
        this.MethMCbusinessLoc = this.Config.GetValue<int>("SubBusiness", "MethMCbusinessLoc", this.MethMCbusinessLoc);
        this.MethLab_InitialSetupDone = this.Config.GetValue<bool>("SubBusiness-Upgrades", "MethLab_InitialSetupDone", this.MethLab_InitialSetupDone);
        this.MethLab_EquipmentUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "MethLab_EquipmentUpgrade", this.MethLab_EquipmentUpgrade);
        this.MethLab_StaffUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "MethLab_StaffUpgrade", this.MethLab_StaffUpgrade);
        this.MethLab_SecurityUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "MethLab_SecurityUpgrade", this.MethLab_SecurityUpgrade);
        this.WeedMCbusinessLoc = this.Config.GetValue<int>("SubBusiness", "WeedMCbusinessLoc", this.WeedMCbusinessLoc);
        this.WeedFarm_InitialSetupDone = this.Config.GetValue<bool>("SubBusiness-Upgrades", "WeedFarm_InitialSetupDone", this.WeedFarm_InitialSetupDone);
        this.WeedFarm_EquipmentUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "WeedFarm_EquipmentUpgrade", this.WeedFarm_EquipmentUpgrade);
        this.WeedFarm_StaffUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "WeedFarm_StaffUpgrade", this.WeedFarm_StaffUpgrade);
        this.WeedFarm_SecurityUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "WeedFarm_SecurityUpgrade", this.WeedFarm_SecurityUpgrade);
        this.CocaineMCbusinessLoc = this.Config.GetValue<int>("SubBusiness", "CocaineMCbusinessLoc", this.CocaineMCbusinessLoc);
        this.CocaineLockup_InitialSetupDone = this.Config.GetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_InitialSetupDone", this.CocaineLockup_InitialSetupDone);
        this.CocaineLockup_EquipmentUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_EquipmentUpgrade", this.CocaineLockup_EquipmentUpgrade);
        this.CocaineLockup_StaffUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_StaffUpgrade", this.CocaineLockup_StaffUpgrade);
        this.CocaineLockup_SecurityUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_SecurityUpgrade", this.CocaineLockup_SecurityUpgrade);
        this.CounterfietMCbusinessLoc = this.Config.GetValue<int>("SubBusiness", "CounterfietMCbusinessLoc", this.CounterfietMCbusinessLoc);
        this.CounterfeitOffice_InitialSetupDone = this.Config.GetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_InitialSetupDone", this.CounterfeitOffice_InitialSetupDone);
        this.CounterfeitOffice_EquipmentUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_EquipmentUpgrade", this.CounterfeitOffice_EquipmentUpgrade);
        this.CounterfeitOffice_StaffUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_StaffUpgrade", this.CounterfeitOffice_StaffUpgrade);
        this.CounterfeitOffice_SecurityUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_SecurityUpgrade", this.CounterfeitOffice_SecurityUpgrade);
        this.ForgeryMCbusinessLoc = this.Config.GetValue<int>("SubBusiness", "ForgeryMCbusinessLoc", this.ForgeryMCbusinessLoc);
        this.DocumentForgery_InitialSetupDone = this.Config.GetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_InitialSetupDone", this.DocumentForgery_InitialSetupDone);
        this.DocumentForgery_EquipmentUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_EquipmentUpgrade", this.DocumentForgery_EquipmentUpgrade);
        this.DocumentForgery_StaffUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_StaffUpgrade", this.DocumentForgery_StaffUpgrade);
        this.DocumentForgery_SecurityUpgrade = this.Config.GetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_SecurityUpgrade", this.DocumentForgery_SecurityUpgrade);
        this.MethLab_TotalEarnings = this.Config.GetValue<float>("SubBusiness-MethLab-Stats", "MethLab_TotalEarnings", this.MethLab_TotalEarnings);
        this.MethLab_TotalResupplySuccess = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalResupplySuccess", this.MethLab_TotalResupplySuccess);
        this.MethLab_TotalResupplyFails = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalResupplyFails", this.MethLab_TotalResupplyFails);
        this.MethLab_TotalSales_LS = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalSales_LS", this.MethLab_TotalSales_LS);
        this.MethLab_TotalFails_LS = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalFails_LS", this.MethLab_TotalFails_LS);
        this.MethLab_TotalSales_BC = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalSales_BC", this.MethLab_TotalSales_BC);
        this.MethLab_TotalFails_BC = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalFails_BC", this.MethLab_TotalFails_BC);
        this.MethLab_Supplies = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_Supplies", this.MethLab_Supplies);
        this.MethLab_ProductionCeased_NoSupplies = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoSupplies", this.MethLab_ProductionCeased_NoSupplies);
        this.MethLab_ProductionCeased_NoRaided = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoRaided", this.MethLab_ProductionCeased_NoRaided);
        this.MethLab_ProductionCeased_NoCapacity = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoCapacity", this.MethLab_ProductionCeased_NoCapacity);
        this.MethLab_StoppedProducing = this.Config.GetValue<bool>("SubBusiness-MethLab-Stats", "MethLab_StoppedProducing", this.MethLab_StoppedProducing);
        this.MethLab_BuySuppliesMultiplier = this.Config.GetValue<float>("SubBusiness-MethLab-Stats", "MethLab_BuySuppliesMultiplier", this.MethLab_BuySuppliesMultiplier);
        this.MethLab_SellProductMutliplier = this.Config.GetValue<float>("SubBusiness-MethLab-Stats", "MethLab_SellProductMutliplier", this.MethLab_SellProductMutliplier);
        this.MethLab_ProductMax = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductMax", this.MethLab_ProductMax);
        this.MethLab_ProductBags = this.Config.GetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductBags", this.MethLab_ProductBags);
        this.SETMethLab_ProductValue = this.Config.GetValue<float>("SubBusiness-MethLab-Stats", "MethLab_ProductValue", this.SETMethLab_ProductValue);
        this.WeedFarm_TotalEarnings = this.Config.GetValue<float>("SubBusiness-Weedfarm-Stats", "MethLab_TotalEarnings", this.MethLab_TotalEarnings);
        this.WeedFarm_TotalResupplySuccess = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalResupplySuccess", this.WeedFarm_TotalResupplySuccess);
        this.WeedFarm_TotalResupplyFails = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalResupplyFails", this.WeedFarm_TotalResupplyFails);
        this.WeedFarm_TotalSales_LS = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalSales_LS", this.WeedFarm_TotalSales_LS);
        this.WeedFarm_TotalFails_LS = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalFails_LS", this.WeedFarm_TotalFails_LS);
        this.WeedFarm_TotalSales_BC = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalSales_BC", this.WeedFarm_TotalSales_BC);
        this.WeedFarm_TotalFails_BC = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalFails_BC", this.WeedFarm_TotalFails_BC);
        this.WeedFarm_Supplies = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_Supplies", this.WeedFarm_Supplies);
        this.WeedFarm_ProductionCeased_NoSupplies = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoSupplies", this.WeedFarm_ProductionCeased_NoSupplies);
        this.WeedFarm_ProductionCeased_NoRaided = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoRaided", this.WeedFarm_ProductionCeased_NoRaided);
        this.WeedFarm_ProductionCeased_NoCapacity = this.Config.GetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoCapacity", this.WeedFarm_ProductionCeased_NoCapacity);
        this.WeedFarm_StoppedProducing = this.Config.GetValue<bool>("SubBusiness-Weedfarm-Stats", "WeedFarm_StoppedProducing", this.WeedFarm_StoppedProducing);
        this.WeedFarm_BuySuppliesMultiplier = this.Config.GetValue<float>("SubBusiness-Weedfarm-Stats", "WeedFarm_BuySuppliesMultiplier", this.WeedFarm_BuySuppliesMultiplier);
        this.WeedFarm_SellProductMutliplier = this.Config.GetValue<float>("SubBusiness-Weedfarm-Stats", "WeedFarm_SellProductMutliplier", this.WeedFarm_SellProductMutliplier);
        this.WeedFarm_ProductMax = this.Config.GetValue<int>("SubBusiness-WeedFarm-Weedfarm-Stats", "WeedFarm_ProductMax", this.WeedFarm_ProductMax);
        this.WeedFarm_ProductBags = this.Config.GetValue<int>("SubBusiness-WeedFarm-Stats", "WeedFarm_ProductBags", this.WeedFarm_ProductBags);
        this.SETWeedFarm_ProductValue = this.Config.GetValue<float>("SubBusiness-WeedFarm-Stats", "WeedFarm_ProductValue", this.SETWeedFarm_ProductValue);
        this.CocaineLockup_TotalEarnings = this.Config.GetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalEarnings", this.CocaineLockup_TotalEarnings);
        this.CocaineLockup_TotalResupplySuccess = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalResupplySuccess", this.CocaineLockup_TotalResupplySuccess);
        this.CocaineLockup_TotalResupplyFails = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalResupplyFails", this.CocaineLockup_TotalResupplyFails);
        this.CocaineLockup_TotalSales_LS = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalSales_LS", this.CocaineLockup_TotalSales_LS);
        this.CocaineLockup_TotalFails_LS = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalFails_LS", this.CocaineLockup_TotalFails_LS);
        this.CocaineLockup_TotalSales_BC = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalSales_BC", this.CocaineLockup_TotalSales_BC);
        this.CocaineLockup_TotalFails_BC = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalFails_BC", this.CocaineLockup_TotalFails_BC);
        this.CocaineLockup_Supplies = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_Supplies", this.CocaineLockup_Supplies);
        this.CocaineLockup_ProductionCeased_NoSupplies = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoSupplies", this.CocaineLockup_ProductionCeased_NoSupplies);
        this.CocaineLockup_ProductionCeased_NoRaided = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoRaided", this.CocaineLockup_ProductionCeased_NoRaided);
        this.CocaineLockup_ProductionCeased_NoCapacity = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoCapacity", this.CocaineLockup_ProductionCeased_NoCapacity);
        this.CocaineLockup_StoppedProducing = this.Config.GetValue<bool>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_StoppedProducing", this.CocaineLockup_StoppedProducing);
        this.CocaineLockup_BuySuppliesMultiplier = this.Config.GetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_BuySuppliesMultiplier", this.CocaineLockup_BuySuppliesMultiplier);
        this.CocaineLockup_SellProductMutliplier = this.Config.GetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_SellProductMutliplier", this.CocaineLockup_SellProductMutliplier);
        this.CocaineLockup_ProductMax = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductMax", this.CocaineLockup_ProductMax);
        this.CocaineLockup_ProductBags = this.Config.GetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductBags", this.CocaineLockup_ProductBags);
        this.SETCocaineLockup_ProductValue = this.Config.GetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductValue", this.SETCocaineLockup_ProductValue);
        this.CounterfeitOffice_TotalEarnings = this.Config.GetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalEarnings", this.CounterfeitOffice_TotalEarnings);
        this.CounterfeitOffice_TotalResupplySuccess = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalResupplySuccess", this.CounterfeitOffice_TotalResupplySuccess);
        this.CounterfeitOffice_TotalResupplyFails = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalResupplyFails", this.CounterfeitOffice_TotalResupplyFails);
        this.CounterfeitOffice_TotalSales_LS = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalSales_LS", this.CounterfeitOffice_TotalSales_LS);
        this.CounterfeitOffice_TotalFails_LS = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalFails_LS", this.CounterfeitOffice_TotalFails_LS);
        this.CounterfeitOffice_TotalSales_BC = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalSales_BC", this.CounterfeitOffice_TotalSales_BC);
        this.CounterfeitOffice_TotalFails_BC = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalFails_BC", this.CounterfeitOffice_TotalFails_BC);
        this.CounterfeitOffice_Supplies = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_Supplies", this.CounterfeitOffice_Supplies);
        this.CounterfeitOffice_ProductionCeased_NoSupplies = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoSupplies", this.CounterfeitOffice_ProductionCeased_NoSupplies);
        this.CounterfeitOffice_ProductionCeased_NoRaided = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoRaided", this.CounterfeitOffice_ProductionCeased_NoRaided);
        this.CounterfeitOffice_ProductionCeased_NoCapacity = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoCapacity", this.CounterfeitOffice_ProductionCeased_NoCapacity);
        this.CounterfeitOffice_StoppedProducing = this.Config.GetValue<bool>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_StoppedProducing", this.CounterfeitOffice_StoppedProducing);
        this.CounterfeitOffice_BuySuppliesMultiplier = this.Config.GetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_BuySuppliesMultiplier", this.CounterfeitOffice_BuySuppliesMultiplier);
        this.CounterfeitOffice_SellProductMutliplier = this.Config.GetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_SellProductMutliplier", this.CounterfeitOffice_SellProductMutliplier);
        this.CounterfeitOffice_ProductMax = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "CounterfeitOffice_ProductMax", this.CounterfeitOffice_ProductMax);
        this.CounterfeitOffice_ProductBags = this.Config.GetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductBags", this.CounterfeitOffice_ProductBags);
        this.SETCounterfeitOffice_ProductValue = this.Config.GetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductValue", this.SETCounterfeitOffice_ProductValue);
        this.DocumentForgery_TotalEarnings = this.Config.GetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalEarnings", this.DocumentForgery_TotalEarnings);
        this.DocumentForgery_TotalResupplySuccess = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalResupplySuccess", this.DocumentForgery_TotalResupplySuccess);
        this.DocumentForgery_TotalResupplyFails = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalResupplyFails", this.DocumentForgery_TotalResupplyFails);
        this.DocumentForgery_TotalSales_LS = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalSales_LS", this.DocumentForgery_TotalSales_LS);
        this.DocumentForgery_TotalFails_LS = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalFails_LS", this.DocumentForgery_TotalFails_LS);
        this.DocumentForgery_TotalSales_BC = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalSales_BC", this.DocumentForgery_TotalSales_BC);
        this.DocumentForgery_TotalFails_BC = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalFails_BC", this.DocumentForgery_TotalFails_BC);
        this.DocumentForgery_Supplies = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_Supplies", this.DocumentForgery_Supplies);
        this.DocumentForgery_ProductionCeased_NoSupplies = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoSupplies", this.DocumentForgery_ProductionCeased_NoSupplies);
        this.DocumentForgery_ProductionCeased_NoRaided = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoRaided", this.DocumentForgery_ProductionCeased_NoRaided);
        this.DocumentForgery_ProductionCeased_NoCapacity = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoCapacity", this.DocumentForgery_ProductionCeased_NoCapacity);
        this.DocumentForgery_BuySuppliesMultiplier = this.Config.GetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_BuySuppliesMultiplier", this.DocumentForgery_BuySuppliesMultiplier);
        this.DocumentForgery_SellProductMutliplier = this.Config.GetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_SellProductMutliplier", this.DocumentForgery_SellProductMutliplier);
        this.DocumentForgery_StoppedProducing = this.Config.GetValue<bool>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_StoppedProducing", this.DocumentForgery_StoppedProducing);
        this.DocumentForgery_ProductMax = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductMax", this.DocumentForgery_ProductMax);
        this.DocumentForgery_ProductBags = this.Config.GetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductBags", this.DocumentForgery_ProductBags);
        this.SETDocumentForgery_ProductValue = this.Config.GetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductValue", this.SETDocumentForgery_ProductValue);
        this.MISC_DisableRaids = this.Config.GetValue<bool>("Misc", "MISC_DisableRaids", this.MISC_DisableRaids);
        this.MethLab_ProductValue = 17000f;
        if (!this.MethLab_StaffUpgrade && !this.MethLab_EquipmentUpgrade)
        {
          this.MethLab_ProductValue = 17000f;
          this.SETMethLab_ProductValue = (float) this.MethLab_ProductBags * this.MethLab_ProductValue * this.MethLab_SellProductMutliplier;
        }
        if (!this.MethLab_StaffUpgrade && this.MethLab_EquipmentUpgrade)
        {
          this.MethLab_ProductValue = 25000f;
          this.SETMethLab_ProductValue = (float) this.MethLab_ProductBags * this.MethLab_ProductValue * this.MethLab_SellProductMutliplier;
        }
        if (this.MethLab_StaffUpgrade && !this.MethLab_EquipmentUpgrade)
        {
          this.MethLab_ProductValue = 25000f;
          this.SETMethLab_ProductValue = (float) this.MethLab_ProductBags * this.MethLab_ProductValue * this.MethLab_SellProductMutliplier;
        }
        if (this.MethLab_StaffUpgrade && this.MethLab_EquipmentUpgrade)
        {
          this.MethLab_ProductValue = 39666f;
          this.SETMethLab_ProductValue = (float) this.MethLab_ProductBags * this.MethLab_ProductValue * this.MethLab_SellProductMutliplier;
        }
        this.CocaineLockup_ProductValue = 24000f;
        if (!this.CocaineLockup_StaffUpgrade && !this.CocaineLockup_EquipmentUpgrade)
        {
          this.CocaineLockup_ProductValue = 24000f;
          this.SETCocaineLockup_ProductValue = (float) this.CocaineLockup_ProductBags * this.CocaineLockup_ProductValue * this.CocaineLockup_SellProductMutliplier;
        }
        if (!this.CocaineLockup_StaffUpgrade && this.CocaineLockup_EquipmentUpgrade)
        {
          this.CocaineLockup_ProductValue = 36000f;
          this.SETCocaineLockup_ProductValue = (float) this.CocaineLockup_ProductBags * this.CocaineLockup_ProductValue * this.CocaineLockup_SellProductMutliplier;
        }
        if (this.CocaineLockup_StaffUpgrade && !this.CocaineLockup_EquipmentUpgrade)
        {
          this.CocaineLockup_ProductValue = 36000f;
          this.SETCocaineLockup_ProductValue = (float) this.CocaineLockup_ProductBags * this.CocaineLockup_ProductValue * this.CocaineLockup_SellProductMutliplier;
        }
        if (this.CocaineLockup_StaffUpgrade && this.CocaineLockup_EquipmentUpgrade)
        {
          this.CocaineLockup_ProductValue = 56000f;
          this.SETCocaineLockup_ProductValue = (float) this.CocaineLockup_ProductBags * this.CocaineLockup_ProductValue * this.CocaineLockup_SellProductMutliplier;
        }
        this.WeedFarm_ProductValue = 15000f;
        if (!this.WeedFarm_StaffUpgrade && !this.WeedFarm_EquipmentUpgrade)
        {
          this.WeedFarm_ProductValue = 15000f;
          this.SETWeedFarm_ProductValue = (float) this.WeedFarm_ProductBags * this.DocumentForgery_ProductValue * this.WeedFarm_SellProductMutliplier;
        }
        if (!this.WeedFarm_StaffUpgrade && this.WeedFarm_EquipmentUpgrade)
        {
          this.WeedFarm_ProductValue = 21600f;
          this.SETWeedFarm_ProductValue = (float) this.WeedFarm_ProductBags * this.DocumentForgery_ProductValue * this.WeedFarm_SellProductMutliplier;
        }
        if (this.WeedFarm_StaffUpgrade && !this.WeedFarm_EquipmentUpgrade)
        {
          this.WeedFarm_ProductValue = 21600f;
          this.SETWeedFarm_ProductValue = (float) this.WeedFarm_ProductBags * this.DocumentForgery_ProductValue * this.WeedFarm_SellProductMutliplier;
        }
        if (this.WeedFarm_StaffUpgrade && this.WeedFarm_EquipmentUpgrade)
        {
          this.WeedFarm_ProductValue = 31500f;
          this.SETWeedFarm_ProductValue = (float) this.WeedFarm_ProductBags * this.DocumentForgery_ProductValue * this.WeedFarm_SellProductMutliplier;
        }
        this.DocumentForgery_ProductValue = 15000f;
        if (!this.DocumentForgery_StaffUpgrade && !this.DocumentForgery_EquipmentUpgrade)
        {
          this.DocumentForgery_ProductValue = 15000f;
          this.SETDocumentForgery_ProductValue = (float) this.DocumentForgery_ProductBags * this.DocumentForgery_ProductValue * this.DocumentForgery_SellProductMutliplier;
        }
        if (!this.DocumentForgery_StaffUpgrade && this.DocumentForgery_EquipmentUpgrade)
        {
          this.DocumentForgery_ProductValue = 14400f;
          this.SETDocumentForgery_ProductValue = (float) this.DocumentForgery_ProductBags * this.DocumentForgery_ProductValue * this.DocumentForgery_SellProductMutliplier;
        }
        if (this.DocumentForgery_StaffUpgrade && !this.DocumentForgery_EquipmentUpgrade)
        {
          this.DocumentForgery_ProductValue = 14400f;
          this.SETDocumentForgery_ProductValue = (float) this.DocumentForgery_ProductBags * this.DocumentForgery_ProductValue * this.DocumentForgery_SellProductMutliplier;
        }
        if (this.DocumentForgery_StaffUpgrade && this.DocumentForgery_EquipmentUpgrade)
        {
          this.DocumentForgery_ProductValue = 31500f;
          this.SETDocumentForgery_ProductValue = (float) this.DocumentForgery_ProductBags * this.DocumentForgery_ProductValue * this.DocumentForgery_SellProductMutliplier;
        }
        this.CounterfeitOffice_ProductValue = 17500f;
        if (!this.CounterfeitOffice_StaffUpgrade && !this.CounterfeitOffice_EquipmentUpgrade)
        {
          this.CounterfeitOffice_ProductValue = 17500f;
          this.SETCounterfeitOffice_ProductValue = (float) this.CounterfeitOffice_ProductBags * this.CounterfeitOffice_ProductValue * this.CounterfeitOffice_SellProductMutliplier;
        }
        if (!this.CounterfeitOffice_StaffUpgrade && this.CounterfeitOffice_EquipmentUpgrade)
        {
          this.CounterfeitOffice_ProductValue = 25200f;
          this.SETCounterfeitOffice_ProductValue = (float) this.CounterfeitOffice_ProductBags * this.CounterfeitOffice_ProductValue * this.CounterfeitOffice_SellProductMutliplier;
        }
        if (this.CounterfeitOffice_StaffUpgrade && !this.CounterfeitOffice_EquipmentUpgrade)
        {
          this.CounterfeitOffice_ProductValue = 25200f;
          this.SETCounterfeitOffice_ProductValue = (float) this.CounterfeitOffice_ProductBags * this.CounterfeitOffice_ProductValue * this.CounterfeitOffice_SellProductMutliplier;
        }
        if (this.CounterfeitOffice_StaffUpgrade && this.CounterfeitOffice_EquipmentUpgrade)
        {
          this.CounterfeitOffice_ProductValue = 36750f;
          this.SETCounterfeitOffice_ProductValue = (float) this.CounterfeitOffice_ProductBags * this.CounterfeitOffice_ProductValue * this.CounterfeitOffice_SellProductMutliplier;
        }
        if (this.UseGTAO_ProductMax)
        {
          this.MethLab_ProductMax = 20;
          this.CocaineLockup_ProductMax = 10;
          this.WeedFarm_ProductMax = 80;
          this.DocumentForgery_ProductMax = 60;
          this.CounterfeitOffice_ProductMax = 40;
        }
        if (this.MethMCbusinessLoc <= this.MCSubLocMeth.Count)
          this.MethLabExit = this.MCSubLocMeth[this.MethMCbusinessLoc].Enterance;
        if (this.WeedMCbusinessLoc <= this.MCSubLocWeed.Count)
          this.WeedFarmExit = this.MCSubLocWeed[this.WeedMCbusinessLoc].Enterance;
        if (this.CocaineMCbusinessLoc <= this.MCSubLocCocaine.Count)
          this.CocaineExit = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].Enterance;
        if (this.ForgeryMCbusinessLoc <= this.MCSubLocForgery.Count)
          this.ForgeryExit = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].Enterance;
        if (this.CounterfietMCbusinessLoc > this.MCSubLocCounterfiet.Count)
          return;
        this.MoneyPrinterExit = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].Enterance;
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void LoadIniFile3(string iniName)
    {
      try
      {
        this.Config3 = ScriptSettings.Load(iniName);
        this.ShowStockIncrease = this.Config3.GetValue<bool>("Setup", "ShowStockIncrease", this.ShowStockIncrease);
        try
        {
          this.NextDay = this.Config3.GetValue<int>("Setup", "NextDay", this.NextDay);
          this.NextMonth = this.Config3.GetValue<int>("Setup", "NextMonth", this.NextMonth);
          this.NextYear = this.Config3.GetValue<int>("Setup", "NextYear", this.NextYear);
          this.DaysWait = this.Config3.GetValue<int>("Setup", "DaysWait", this.DaysWait);
          this.BYPASS_NOSAVE_OR_CRASH = this.Config3.GetValue<bool>("Setup", "BYPASS_NOSAVE_OR_CRASH", this.BYPASS_NOSAVE_OR_CRASH);
          this.DAYSTORESET_UPDATETIME = this.Config3.GetValue<int>("Setup", "DAYSTORESET_UPDATETIME", this.DAYSTORESET_UPDATETIME);
        }
        catch (Exception ex)
        {
          this.NextDay = 10;
          this.Config3.SetValue<int>("Setup", "NextDay", this.NextDay);
          this.NextMonth = 10;
          this.Config3.SetValue<int>("Setup", "NextMonth", this.NextMonth);
          this.NextYear = 2010;
          this.Config3.SetValue<int>("Setup", "NextYear", this.NextYear);
          this.DaysWait = 3;
          this.Config3.SetValue<int>("Setup", "DaysWait", this.DaysWait);
          this.BYPASS_NOSAVE_OR_CRASH = true;
          this.Config3.SetValue<bool>("Setup", "BYPASS_NOSAVE_OR_CRASH", this.BYPASS_NOSAVE_OR_CRASH);
          this.DAYSTORESET_UPDATETIME = 12;
          this.Config3.SetValue<int>("Setup", "DAYSTORESET_UPDATETIME", this.DAYSTORESET_UPDATETIME);
          this.Config3.Save();
        }
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void DisplayHelpTextThisFrameNoSound(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) -1);
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public int GetHour() => Function.Call<int>(Hash._0x25223CA6B4D20B7F);

    public int GetMinutes() => Function.Call<int>(Hash._0x13D2B8ADD79640F2);

    public int GetDay() => Function.Call<int>(Hash._0x3D10BC92A4DB1D35);

    public int GetMonth() => Function.Call<int>(Hash._0xBBC72712E80257A1);

    public int GetYear() => Function.Call<int>(Hash._0x961777E64BDAF717);

    public void SetDate()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.CurrentDate = World.CurrentDate;
      if (this.CurrentDate.Day + this.DaysWait <= 30)
      {
        this.NextDay = this.CurrentDate.Day + this.DaysWait;
        this.NextMonth = this.CurrentDate.Month;
      }
      if (this.CurrentDate.Day + this.DaysWait > 30)
      {
        this.NextDay = -(30 - (this.CurrentDate.Day + this.DaysWait));
        if (this.CurrentDate.Month + 1 <= 12)
          this.NextMonth = this.CurrentDate.Month + 1;
        if (this.CurrentDate.Month + 1 > 12)
          this.NextMonth = 1;
      }
      this.NextYear = World.CurrentDate.Year;
      this.Config3.SetValue<int>("Setup", "NextYear", this.NextYear);
      this.Config3.SetValue<int>("Setup", "NextDay", this.NextDay);
      this.Config3.SetValue<int>("Setup", "NextMonth", this.NextMonth);
      this.Config3.Save();
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
      if (num1 <= this.NextDay && num2 <= this.NextMonth || (num2 < this.NextMonth || num2 > this.NextMonth) || year != this.NextYear)
      {
        this.NextMonth = this.GetMonth();
        this.NextDay = this.GetDay() + this.DaysWait;
        this.NextYear = this.GetYear();
        this.Config.SetValue<int>("Setup", "NextYear", this.NextYear);
        this.Config.SetValue<int>("Setup", "NextDay", this.NextDay);
        this.Config.SetValue<int>("Setup", "NextMonth", this.NextMonth);
        this.Config.Save();
      }
    }

    public void MainModDestroy()
    {
      if (this.MethBlip != (Blip) null)
        this.MethBlip.Remove();
      if (this.CocaineBlip != (Blip) null)
        this.CocaineBlip.Remove();
      if (this.WeedBlip != (Blip) null)
        this.WeedBlip.Remove();
      if (this.MoneyForgeBlip != (Blip) null)
        this.MoneyForgeBlip.Remove();
      if (!(this.FakeIDBlip != (Blip) null))
        return;
      this.FakeIDBlip.Remove();
    }

    public void MainModRefresh()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      if (this.WeedFarmBought == 1)
      {
        this.WeedBlip = World.CreateBlip(this.WeedFarmExit);
        this.WeedBlip.Sprite = BlipSprite.Weed;
        this.WeedBlip.Color = this.Blip_Colour;
        this.WeedBlip.Name = this.MCSubLocWeed[this.WeedMCbusinessLoc].Name + " " + this.MCSubLocWeed[this.WeedMCbusinessLoc].TypeName;
        this.WeedBlip.IsShortRange = true;
      }
      if (this.MoneyPrinterBought == 1)
      {
        this.MoneyForgeBlip = World.CreateBlip(this.MoneyPrinterExit);
        this.MoneyForgeBlip.Sprite = BlipSprite.DollarBill;
        this.MoneyForgeBlip.Color = this.Blip_Colour;
        this.MoneyForgeBlip.Name = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].Name + " " + this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].TypeName;
        this.MoneyForgeBlip.IsShortRange = true;
      }
      if (this.ForgeryBought == 1)
      {
        this.FakeIDBlip = World.CreateBlip(this.ForgeryExit);
        this.FakeIDBlip.Sprite = BlipSprite.IdentityCard;
        this.FakeIDBlip.Color = this.Blip_Colour;
        this.FakeIDBlip.Name = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].Name + " " + this.MCSubLocForgery[this.ForgeryMCbusinessLoc].TypeName;
        this.FakeIDBlip.IsShortRange = true;
      }
      if (this.MethLabBought == 1)
      {
        this.MethBlip = World.CreateBlip(this.MethLabExit);
        this.MethBlip.Sprite = BlipSprite.Meth;
        this.MethBlip.Color = this.Blip_Colour;
        this.MethBlip.Name = this.MCSubLocMeth[this.MethMCbusinessLoc].Name + " " + this.MCSubLocMeth[this.MethMCbusinessLoc].TypeName;
        this.MethBlip.IsShortRange = true;
      }
      if (this.CocaineBought != 1)
        return;
      this.CocaineBlip = World.CreateBlip(this.CocaineExit);
      this.CocaineBlip.Sprite = BlipSprite.Cocaine;
      this.CocaineBlip.Color = this.Blip_Colour;
      this.CocaineBlip.Name = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].Name + " " + this.MCSubLocCocaine[this.CocaineMCbusinessLoc].TypeName;
      this.CocaineBlip.IsShortRange = true;
    }

    public void SetupGaurd(Ped p)
    {
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 0, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 2, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 3, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 4, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 6, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 8, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) p, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
    }

    public void RandomizeOutfit(Ped Dancer)
    {
      System.Random random = new System.Random();
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 0, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 0)), (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 1, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 1)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 1)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 2, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 2)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 2)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 3, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 3)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 3)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 4, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 4)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 4)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 5, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 5)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 5)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 6, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 6)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 6)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 7, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 7)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 7)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 8, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 8)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 8)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 9, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 9)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 9)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 10, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 10)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 10)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 11, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 11)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 11)), (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Dancer, (InputArgument) 12, (InputArgument) random.Next(0, Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Dancer, (InputArgument) 12)), (InputArgument) random.Next(0, Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Dancer, (InputArgument) 12)), (InputArgument) 0);
    }

    public void CreatePeds2()
    {
      Vector3 position = Game.Player.Character.Position;
      if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) == this.WeedFarmId && !this.Createdpeds)
      {
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        if (this.Peds.Count > 0)
          this.Peds.Clear();
        if ((Entity) this.Pallet1 != (Entity) null)
          this.Pallet1.Delete();
        if ((Entity) this.Pallet2 != (Entity) null)
          this.Pallet2.Delete();
        if ((Entity) this.Pallet3 != (Entity) null)
          this.Pallet3.Delete();
        if ((Entity) this.Pallet4 != (Entity) null)
          this.Pallet4.Delete();
        if ((Entity) this.Pallet5 != (Entity) null)
          this.Pallet5.Delete();
        if ((Entity) this.Pallet6 != (Entity) null)
          this.Pallet6.Delete();
        if ((Entity) this.Pallet7 != (Entity) null)
          this.Pallet7.Delete();
        if ((Entity) this.Pallet8 != (Entity) null)
          this.Pallet8.Delete();
        if ((Entity) this.Pallet9 != (Entity) null)
          this.Pallet9.Delete();
        if ((Entity) this.Pallet10 != (Entity) null)
          this.Pallet10.Delete();
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        this.MCBusinessIn = 3;
        if (this.WeedFarm_InitialSetupDone)
        {
          UI.Notify("Entered Weed Farm");
          this.Createdpeds = true;
          if (this.WeedFarm_ProductBags != 100 && (uint) this.WeedFarm_Supplies > 0U)
          {
            for (int index = 22; index < 26; ++index)
            {
              Vector3 vector3 = this.pPosition[index];
              double num = (double) this.pRotation[index];
              if (true)
              {
                Ped ped = World.CreatePed(this.RequestModel(PedHash.MethMale01), this.pPosition[index], this.pRotation[index]);
                ped.AlwaysKeepTask = true;
                ped.BlockPermanentEvents = true;
                ped.CanRagdoll = false;
                ped.SetDefaultClothes();
                Function.Call(Hash._0x142A02425FF02BD9, (InputArgument) ped.Handle, (InputArgument) "WORLD_HUMAN_CLIPBOARD", (InputArgument) -1, (InputArgument) false);
                this.Peds.Add(ped);
              }
              else
                UI.Notify("~r~error Missing Component~w~");
            }
            if (this.WeedFarm_StaffUpgrade)
            {
              for (int index = 18; index < 22; ++index)
              {
                Vector3 vector3 = this.pPosition[index];
                double num1 = (double) this.pRotation[index];
                if (true)
                {
                  Ped ped = World.CreatePed(this.RequestModel(PedHash.Abigail), new Vector3());
                  this.Peds.Add(ped);
                  int num2 = new System.Random().Next(1, 5);
                  if (num2 == 1)
                    ped = World.CreatePed(this.RequestModel(PedHash.Business01AMM), this.pPosition[index], this.pRotation[index]);
                  if (num2 == 2)
                    ped = World.CreatePed(this.RequestModel(PedHash.Business02AFM), this.pPosition[index], this.pRotation[index]);
                  if (num2 == 3)
                    ped = World.CreatePed(this.RequestModel(PedHash.Business03AFY), this.pPosition[index], this.pRotation[index]);
                  if (num2 == 4)
                    ped = World.CreatePed(this.RequestModel(PedHash.Business04AFY), this.pPosition[index], this.pRotation[index]);
                  if (num2 == 5)
                    ped = World.CreatePed(this.RequestModel(PedHash.Business01AFY), this.pPosition[index], this.pRotation[index]);
                  ped.AlwaysKeepTask = true;
                  ped.BlockPermanentEvents = true;
                  ped.CanRagdoll = false;
                  ped.FreezePosition = true;
                  ped.Task.PlayAnimation("anim@amb@office@pa@female@", "pa_base", 8f, -1, true, -1f);
                  this.Peds.Add(ped);
                }
                else
                  UI.Notify("~r~error Missing Component~w~");
              }
            }
          }
          else
          {
            Ped ped1 = World.CreatePed(this.RequestModel(PedHash.MethMale01), new Vector3(1065.8f, -3185.573f, -40f), -1f);
            ped1.FreezePosition = true;
            ped1.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@smoking@base", "base", -1f, -1, true, 1f);
            ped1.BlockPermanentEvents = true;
            ped1.AlwaysKeepTask = true;
            this.Peds.Add(ped1);
            Ped ped2 = World.CreatePed(this.RequestModel(PedHash.MethMale01), new Vector3(1048.161f, -3201.958f, -40f), 173f);
            ped2.FreezePosition = true;
            ped2.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@foot_up@idle_b", "idle_d", -1f, -1, true, 1f);
            ped2.BlockPermanentEvents = true;
            ped2.AlwaysKeepTask = true;
            this.Peds.Add(ped2);
          }
        }
        this.Createdpeds = true;
      }
      if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) == this.CocaineLockupId && !this.Createdpeds)
      {
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        if (this.Peds.Count > 0)
          this.Peds.Clear();
        if ((Entity) this.Pallet1 != (Entity) null)
          this.Pallet1.Delete();
        if ((Entity) this.Pallet2 != (Entity) null)
          this.Pallet2.Delete();
        if ((Entity) this.Pallet3 != (Entity) null)
          this.Pallet3.Delete();
        if ((Entity) this.Pallet4 != (Entity) null)
          this.Pallet4.Delete();
        if ((Entity) this.Pallet5 != (Entity) null)
          this.Pallet5.Delete();
        if ((Entity) this.Pallet6 != (Entity) null)
          this.Pallet6.Delete();
        if ((Entity) this.Pallet7 != (Entity) null)
          this.Pallet7.Delete();
        if ((Entity) this.Pallet8 != (Entity) null)
          this.Pallet8.Delete();
        if ((Entity) this.Pallet9 != (Entity) null)
          this.Pallet9.Delete();
        if ((Entity) this.Pallet10 != (Entity) null)
          this.Pallet10.Delete();
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        this.MCBusinessIn = 2;
        if (this.CocaineLockup_InitialSetupDone)
        {
          if (this.PedScenes.Count > 0)
            this.PedScenes.Clear();
          foreach (Prop prop in this.PedSyncSeceneProps_group1)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          if (this.PedSyncSeceneProps_group1.Count > 0)
            this.PedSyncSeceneProps_group1.Clear();
          foreach (Prop prop in this.PedSyncSeceneProps_group2)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          if (this.PedSyncSeceneProps_group2.Count > 0)
            this.PedSyncSeceneProps_group2.Clear();
          foreach (Prop prop in this.PedSyncSeceneProps_group3)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          if (this.PedSyncSeceneProps_group3.Count > 0)
            this.PedSyncSeceneProps_group3.Clear();
          UI.Notify("Entered Cocaine Lab");
          this.Createdpeds = true;
          if (this.CocaineLockup_ProductBags != 100 && (uint) this.CocaineLockup_Supplies > 0U)
          {
            if (this.CocaineLockup_SecurityUpgrade)
            {
              Ped ped = World.CreatePed(this.RequestModel("mp_m_cocaine_01"), this.CocaineLockup_ActiveSpawns[0].Spawn, this.CocaineLockup_ActiveSpawns[0].Heading);
              ped.AlwaysKeepTask = true;
              ped.BlockPermanentEvents = true;
              ped.CanRagdoll = false;
              this.SetupGaurd(ped);
              ped.Task.PlayAnimation("mini@strip_club@idles@bouncer@base", "base", 8f, -1, true, -1f);
              this.Peds.Add(ped);
            }
            if (this.CocaineLockup_StaffUpgrade)
            {
              for (int index = 1; index < 14; ++index)
              {
                System.Random random = new System.Random();
                Ped ped = World.CreatePed(this.RequestModel("mp_f_cocaine_01"), this.CocaineLockup_ActiveSpawns[index].Spawn, this.CocaineLockup_ActiveSpawns[index].Heading);
                ped.AlwaysKeepTask = true;
                ped.BlockPermanentEvents = true;
                ped.CanRagdoll = false;
                this.Peds.Add(ped);
                this.PedScenes.Add(new SecondBusiness.PedaSyncronisedScene(ped, 0));
                int num = random.Next(0, 700);
                if (num > 0 && num <= 100)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v1_cokecutter", 8f, -1, true, -1f);
                if (num > 100 && num <= 200)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v2_cokecutter", 8f, -1, true, -1f);
                if (num > 200 && num <= 300)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v3_cokecutter", 8f, -1, true, -1f);
                if (num > 300 && num <= 400)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v4_cokecutter", 8f, -1, true, -1f);
                if (num > 400 && num <= 500)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v5_cokecutter", 8f, -1, true, -1f);
                if (num > 500 && num <= 600)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v6_cokecutter", 8f, -1, true, -1f);
                if (num > 600 && num <= 700)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v7_cokecutter", 8f, -1, true, -1f);
                Script.Wait(1);
              }
            }
            if (!this.CocaineLockup_StaffUpgrade)
            {
              for (int index = 1; index < 14; ++index)
              {
                Ped ped = World.CreatePed(this.RequestModel("mp_f_cocaine_01"), this.CocaineLockup_ActiveSpawns[index].Spawn, this.CocaineLockup_ActiveSpawns[index].Heading);
                System.Random random = new System.Random();
                if (random.Next(0, 100) > 50)
                {
                  ped.FreezePosition = true;
                  ped.Position = new Vector3(0.0f, 0.0f, 0.0f);
                }
                ped.AlwaysKeepTask = true;
                ped.BlockPermanentEvents = true;
                ped.CanRagdoll = false;
                int num = random.Next(0, 700);
                if (num > 0 && num <= 100)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v1_cokecutter", 8f, -1, true, -1f);
                if (num > 100 && num <= 200)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v2_cokecutter", 8f, -1, true, -1f);
                if (num > 200 && num <= 300)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v3_cokecutter", 8f, -1, true, -1f);
                if (num > 300 && num <= 400)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v4_cokecutter", 8f, -1, true, -1f);
                if (num > 400 && num <= 500)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v5_cokecutter", 8f, -1, true, -1f);
                if (num > 500 && num <= 600)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v6_cokecutter", 8f, -1, true, -1f);
                if (num > 600 && num <= 700)
                  ped.Task.PlayAnimation("anim@amb@business@coc@coc_unpack_cut@", "fullcut_cycle_v7_cokecutter", 8f, -1, true, -1f);
                this.Peds.Add(ped);
                Script.Wait(1);
              }
            }
          }
          else
          {
            Ped ped1 = World.CreatePed(this.RequestModel("mp_f_cocaine_01"), new Vector3(1090.154f, -3192.09f, -40f), -175f);
            ped1.FreezePosition = true;
            ped1.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@smoking@base", "base", -1f, -1, true, 1f);
            ped1.BlockPermanentEvents = true;
            ped1.AlwaysKeepTask = true;
            this.Peds.Add(ped1);
            Script.Wait(5);
            Ped ped2 = World.CreatePed(this.RequestModel("mp_f_cocaine_01"), new Vector3(1096.64f, -3199.862f, -40f), 16f);
            ped2.FreezePosition = true;
            ped2.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@smoking@base", "base", -1f, -1, true, 1f);
            ped2.BlockPermanentEvents = true;
            ped2.AlwaysKeepTask = true;
            this.Peds.Add(ped2);
            Script.Wait(5);
            Ped ped3 = World.CreatePed(this.RequestModel("mp_f_cocaine_01"), new Vector3(1095.823f, -3199.299f, -40f), 5f);
            ped3.FreezePosition = true;
            ped3.Task.PlayAnimation("switch@michael@sitting", "idle", -1f, -1, true, 1f);
            ped3.BlockPermanentEvents = true;
            ped3.AlwaysKeepTask = true;
            this.Peds.Add(ped3);
            if (this.CocaineLockup_SecurityUpgrade)
            {
              this.worker = World.CreatePed(this.RequestModel("mp_m_cocaine_01"), new Vector3(1087.352f, -3190.88f, -39.35f), -62f);
              this.worker.AlwaysKeepTask = true;
              this.worker.BlockPermanentEvents = true;
              this.worker.CanRagdoll = false;
              this.SetupGaurd(this.worker);
              this.worker.Task.PlayAnimation("switch@michael@sitting", "idle", -1f, -1, true, 1f);
              this.Peds.Add(this.worker);
            }
          }
        }
        this.Createdpeds = true;
      }
      if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) == this.MethLabId && !this.Createdpeds)
      {
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        if (this.Peds.Count > 0)
          this.Peds.Clear();
        if ((Entity) this.Pallet1 != (Entity) null)
          this.Pallet1.Delete();
        if ((Entity) this.Pallet2 != (Entity) null)
          this.Pallet2.Delete();
        if ((Entity) this.Pallet3 != (Entity) null)
          this.Pallet3.Delete();
        if ((Entity) this.Pallet4 != (Entity) null)
          this.Pallet4.Delete();
        if ((Entity) this.Pallet5 != (Entity) null)
          this.Pallet5.Delete();
        if ((Entity) this.Pallet6 != (Entity) null)
          this.Pallet6.Delete();
        if ((Entity) this.Pallet7 != (Entity) null)
          this.Pallet7.Delete();
        if ((Entity) this.Pallet8 != (Entity) null)
          this.Pallet8.Delete();
        if ((Entity) this.Pallet9 != (Entity) null)
          this.Pallet9.Delete();
        if ((Entity) this.Pallet10 != (Entity) null)
          this.Pallet10.Delete();
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        this.MCBusinessIn = 1;
        if (this.MethLab_InitialSetupDone)
        {
          UI.Notify("Entered Meth Lab");
          this.Createdpeds = true;
          if (this.MethLab_ProductBags != 100 && (uint) this.MethLab_Supplies > 0U)
          {
            if (this.MethLab_EquipmentUpgrade)
            {
              Ped ped = World.CreatePed(this.RequestModel(PedHash.MethMale01), new Vector3(1016.886f, -3197.006f, -40f), 87f);
              ped.FreezePosition = true;
              ped.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@foot_up@idle_b", "idle_d", -1f, -1, true, 1f);
              ped.BlockPermanentEvents = true;
              ped.AlwaysKeepTask = true;
              this.Peds.Add(ped);
              this.RandomizeOutfit(ped);
              Script.Wait(5);
            }
            for (int index = 26; index < 28; ++index)
            {
              Vector3 vector3 = this.pPosition[index];
              double num = (double) this.pRotation[index];
              if (true)
              {
                Ped ped = World.CreatePed(this.RequestModel(PedHash.MethMale01), this.pPosition[index], this.pRotation[index]);
                ped.AlwaysKeepTask = true;
                ped.BlockPermanentEvents = true;
                ped.CanRagdoll = false;
                ped.SetDefaultClothes();
                Function.Call(Hash._0x142A02425FF02BD9, (InputArgument) ped.Handle, (InputArgument) "WORLD_HUMAN_CLIPBOARD", (InputArgument) -1, (InputArgument) false);
                this.Peds.Add(ped);
              }
              else
                UI.Notify("~r~error Missing Component~w~");
            }
            if (this.MethLab_StaffUpgrade)
            {
              for (int index = 28; index < 30; ++index)
              {
                Vector3 vector3 = this.pPosition[index];
                double num = (double) this.pRotation[index];
                if (true)
                {
                  Ped ped = World.CreatePed(this.RequestModel(PedHash.MethMale01), this.pPosition[index], this.pRotation[index]);
                  ped.AlwaysKeepTask = true;
                  ped.BlockPermanentEvents = true;
                  ped.CanRagdoll = false;
                  ped.SetDefaultClothes();
                  Function.Call(Hash._0x142A02425FF02BD9, (InputArgument) ped.Handle, (InputArgument) "WORLD_HUMAN_CLIPBOARD", (InputArgument) -1, (InputArgument) false);
                  this.Peds.Add(ped);
                }
                else
                  UI.Notify("~r~error Missing Component~w~");
              }
            }
          }
          else
          {
            if (this.MethLab_SecurityUpgrade)
            {
              Ped ped = World.CreatePed(this.RequestModel("mp_m_cocaine_01"), new Vector3(998.37f, -3202.271f, -37.2f), 8f);
              ped.AlwaysKeepTask = true;
              ped.BlockPermanentEvents = true;
              ped.CanRagdoll = false;
              this.SetupGaurd(ped);
              ped.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@foot_up@idle_b", "idle_d", -1f, -1, true, 1f);
              this.Peds.Add(ped);
            }
            Ped ped1 = World.CreatePed(this.RequestModel(PedHash.MethMale01), new Vector3(1001.73f, -3198.173f, -40f), -6f);
            ped1.FreezePosition = true;
            ped1.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@foot_up@idle_b", "idle_d", -1f, -1, true, 1f);
            ped1.BlockPermanentEvents = true;
            ped1.AlwaysKeepTask = true;
            this.Peds.Add(ped1);
            this.RandomizeOutfit(ped1);
            Script.Wait(5);
            if (this.MethLab_EquipmentUpgrade)
            {
              Ped ped2 = World.CreatePed(this.RequestModel(PedHash.MethMale01), new Vector3(1016.886f, -3197.006f, -40f), 87f);
              ped2.FreezePosition = true;
              ped2.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@foot_up@idle_b", "idle_d", -1f, -1, true, 1f);
              ped2.BlockPermanentEvents = true;
              ped2.AlwaysKeepTask = true;
              this.Peds.Add(ped2);
              this.RandomizeOutfit(ped2);
              Script.Wait(5);
            }
            Ped ped3 = World.CreatePed(this.RequestModel(PedHash.MethMale01), new Vector3(1014.222f, -3202.195f, -40f), -1f);
            ped3.FreezePosition = true;
            ped3.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@smoking@base", "base", -1f, -1, true, 1f);
            ped3.BlockPermanentEvents = true;
            ped3.AlwaysKeepTask = true;
            this.Peds.Add(ped3);
            this.RandomizeOutfit(ped3);
          }
        }
        this.Createdpeds = true;
      }
      if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) == this.CounterfeitOfficeId && !this.Createdpeds)
      {
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        if (this.Peds.Count > 0)
          this.Peds.Clear();
        if ((Entity) this.Pallet1 != (Entity) null)
          this.Pallet1.Delete();
        if ((Entity) this.Pallet2 != (Entity) null)
          this.Pallet2.Delete();
        if ((Entity) this.Pallet3 != (Entity) null)
          this.Pallet3.Delete();
        if ((Entity) this.Pallet4 != (Entity) null)
          this.Pallet4.Delete();
        if ((Entity) this.Pallet5 != (Entity) null)
          this.Pallet5.Delete();
        if ((Entity) this.Pallet6 != (Entity) null)
          this.Pallet6.Delete();
        if ((Entity) this.Pallet7 != (Entity) null)
          this.Pallet7.Delete();
        if ((Entity) this.Pallet8 != (Entity) null)
          this.Pallet8.Delete();
        if ((Entity) this.Pallet9 != (Entity) null)
          this.Pallet9.Delete();
        if ((Entity) this.Pallet10 != (Entity) null)
          this.Pallet10.Delete();
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        this.MCBusinessIn = 4;
        if (this.CounterfeitOffice_InitialSetupDone)
        {
          UI.Notify("Entered Money Printer");
          if (this.CounterfeitOffice_ProductBags != 100 && (uint) this.CounterfeitOffice_Supplies > 0U)
          {
            this.Createdpeds = true;
            if (this.CounterfeitOffice_StaffUpgrade)
            {
              for (int index = 14; index < 17; ++index)
              {
                Vector3 vector3 = this.pPosition[index];
                double num = (double) this.pRotation[index];
                if (true)
                {
                  Ped ped = World.CreatePed(this.RequestModel(-1739208332), this.pPosition[index], this.pRotation[index]);
                  ped.AlwaysKeepTask = true;
                  ped.BlockPermanentEvents = true;
                  ped.CanRagdoll = false;
                  ped.SetDefaultClothes();
                  Function.Call(Hash._0x142A02425FF02BD9, (InputArgument) ped.Handle, (InputArgument) "WORLD_HUMAN_CLIPBOARD", (InputArgument) -1, (InputArgument) false);
                  this.Peds.Add(ped);
                }
                else
                  UI.Notify("~r~error Missing Component~w~");
              }
            }
            if (this.CounterfeitOffice_EquipmentUpgrade)
            {
              Ped ped1 = World.CreatePed(this.RequestModel(-1739208332), new Vector3(1125.067f, -3198.243f, -41f), -92f);
              ped1.FreezePosition = true;
              ped1.Task.PlayAnimation("anim@amb@business@meth@meth_monitoring_cooking@monitoring@", "check_guages_monitor", 1f, -1, true, 1f);
              ped1.BlockPermanentEvents = true;
              ped1.AlwaysKeepTask = true;
              this.Peds.Add(ped1);
              Ped ped2 = World.CreatePed(this.RequestModel(-1739208332), new Vector3(1129.984f, -3197.366f, -40.3757f), 169.3241f);
              ped2.FreezePosition = true;
              ped2.Task.PlayAnimation("anim@amb@business@cfm@cfm_machine_oversee@", "watch_production_v2_operator", 1f, -1, true, 1f);
              ped2.BlockPermanentEvents = true;
              ped2.AlwaysKeepTask = true;
              this.Peds.Add(ped2);
            }
            Ped ped3 = World.CreatePed(this.RequestModel(-1739208332), new Vector3(1116.53f, -3194.96f, -41.4f), 89f);
            ped3.FreezePosition = true;
            ped3.Task.PlayAnimation("anim@amb@business@cfm@cfm_counting_notes@", "tired_counting_counter", 8f, -1, true, -1f);
            this.Peds.Add(ped3);
            ped3.AlwaysKeepTask = true;
            ped3.BlockPermanentEvents = true;
            ped3.CanRagdoll = false;
            Ped ped4 = World.CreatePed(this.RequestModel(-1739208332), new Vector3(1116.53f, -3196.203f, -41.4f), 81f);
            ped4.FreezePosition = true;
            ped4.Task.PlayAnimation("anim@amb@business@cfm@cfm_counting_notes@", "tired_counting_counter", 8f, -1, true, -1f);
            this.Peds.Add(ped4);
            ped4.AlwaysKeepTask = true;
            ped4.BlockPermanentEvents = true;
            ped4.CanRagdoll = false;
          }
          else
          {
            Ped ped1 = World.CreatePed(this.RequestModel(-1739208332), new Vector3(1124.876f, -3199.203f, -41.3f), -5f);
            ped1.FreezePosition = true;
            ped1.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@foot_up@idle_b", "idle_d", -1f, -1, true, 1f);
            ped1.BlockPermanentEvents = true;
            ped1.AlwaysKeepTask = true;
            this.Peds.Add(ped1);
            Ped ped2 = World.CreatePed(this.RequestModel(-1739208332), new Vector3(1137.92f, -3193.61f, -41.3f), -173f);
            ped2.FreezePosition = true;
            ped2.Task.PlayAnimation("amb@world_human_leaning@male@wall@back@smoking@base", "base", -1f, -1, true, 1f);
            ped2.BlockPermanentEvents = true;
            ped2.AlwaysKeepTask = true;
            this.Peds.Add(ped2);
          }
        }
        this.Createdpeds = true;
      }
      if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) == this.DocumentForgeryId && !this.Createdpeds)
      {
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        if (this.Peds.Count > 0)
          this.Peds.Clear();
        if ((Entity) this.Pallet1 != (Entity) null)
          this.Pallet1.Delete();
        if ((Entity) this.Pallet2 != (Entity) null)
          this.Pallet2.Delete();
        if ((Entity) this.Pallet3 != (Entity) null)
          this.Pallet3.Delete();
        if ((Entity) this.Pallet4 != (Entity) null)
          this.Pallet4.Delete();
        if ((Entity) this.Pallet5 != (Entity) null)
          this.Pallet5.Delete();
        if ((Entity) this.Pallet6 != (Entity) null)
          this.Pallet6.Delete();
        if ((Entity) this.Pallet7 != (Entity) null)
          this.Pallet7.Delete();
        if ((Entity) this.Pallet8 != (Entity) null)
          this.Pallet8.Delete();
        if ((Entity) this.Pallet9 != (Entity) null)
          this.Pallet9.Delete();
        if ((Entity) this.Pallet10 != (Entity) null)
          this.Pallet10.Delete();
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        this.MCBusinessIn = 5;
        if (this.DocumentForgery_InitialSetupDone)
        {
          UI.Notify("Entered Forgery Office");
          this.Createdpeds = true;
          if (this.DocumentForgery_ProductBags != 100 && (uint) this.DocumentForgery_Supplies > 0U)
          {
            foreach (SecondBusiness.PedSpawn forgeryActiveSpawn in this.DocumentForgery_ActiveSpawns)
            {
              System.Random random = new System.Random();
              int num1 = random.Next(0, 100);
              if (num1 <= 50)
                this.worker = World.CreatePed(this.RequestModel("mp_f_forgery_01"), forgeryActiveSpawn.Spawn, forgeryActiveSpawn.Heading - 180f);
              if (num1 > 50)
                this.worker = World.CreatePed(this.RequestModel("mp_m_forgery_01"), forgeryActiveSpawn.Spawn, forgeryActiveSpawn.Heading - 180f);
              this.RandomizeOutfit(this.worker);
              this.Peds.Add(this.worker);
              this.worker.AlwaysKeepTask = true;
              this.worker.BlockPermanentEvents = true;
              this.worker.CanRagdoll = false;
              this.worker.HasCollision = false;
              this.worker.Position = this.worker.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, -1f));
              Script.Wait(1);
              this.worker.FreezePosition = true;
              int num2 = random.Next(0, 100);
              if (num2 <= 20)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "close_inspection_idartist", 8f, -1, true, -1f);
              if (num2 > 20 && num2 <= 40)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "close_inspection_idartistfemale", 8f, -1, true, -1f);
              if (num2 > 40 && num2 <= 60)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "doc_inspection_idartist", 8f, -1, true, -1f);
              if (num2 > 60 && num2 <= 80)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "look_around_idartist", 8f, -1, true, -1f);
              if (num2 > 80 && num2 <= 100)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "simple_inspect_idartist", 8f, -1, true, -1f);
            }
          }
          else
          {
            foreach (SecondBusiness.PedSpawn forgeryActiveSpawn in this.DocumentForgery_ActiveSpawns)
            {
              System.Random random = new System.Random();
              int num1 = random.Next(0, 100);
              if (num1 <= 50)
                this.worker = World.CreatePed(this.RequestModel("mp_f_forgery_01"), forgeryActiveSpawn.Spawn, forgeryActiveSpawn.Heading - 180f);
              if (num1 > 50)
                this.worker = World.CreatePed(this.RequestModel("mp_m_forgery_01"), forgeryActiveSpawn.Spawn, forgeryActiveSpawn.Heading - 180f);
              this.RandomizeOutfit(this.worker);
              this.Peds.Add(this.worker);
              this.worker.AlwaysKeepTask = true;
              this.worker.BlockPermanentEvents = true;
              this.worker.CanRagdoll = false;
              this.worker.HasCollision = false;
              this.worker.Position = this.worker.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, -1f));
              Script.Wait(1);
              this.worker.FreezePosition = true;
              int num2 = random.Next(0, 100);
              if (num2 <= 20)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "close_inspection_idartist", 8f, -1, true, -1f);
              if (num2 > 20 && num2 <= 40)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "close_inspection_idartistfemale", 8f, -1, true, -1f);
              if (num2 > 40 && num2 <= 60)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "doc_inspection_idartist", 8f, -1, true, -1f);
              if (num2 > 60 && num2 <= 80)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "look_around_idartist", 8f, -1, true, -1f);
              if (num2 > 80 && num2 <= 100)
                this.worker.Task.PlayAnimation("anim@amb@business@cfid@cfid_desk_docs@", "simple_inspect_idartist", 8f, -1, true, -1f);
            }
          }
        }
        this.Createdpeds = true;
      }
      if (this.EnableBikerMethLab)
      {
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_2_biker_dlc_int_ware01_milo");
        if (!this.MethLab_InitialSetupDone)
        {
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247041, (InputArgument) "meth_lab_empty");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_basic");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_production");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_production");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_setup");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_setup");
        }
        if (this.MethLab_InitialSetupDone)
        {
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_empty");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247041, (InputArgument) "meth_lab_basic");
          if (this.MethLab_EquipmentUpgrade)
          {
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_basic");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247041, (InputArgument) "meth_lab_upgrade");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247041, (InputArgument) "meth_lab_production");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247041, (InputArgument) "meth_lab_setup");
          }
          else if (!this.MethLab_EquipmentUpgrade)
          {
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_upgrade");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247041, (InputArgument) "meth_lab_production");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247041, (InputArgument) "meth_lab_setup");
          }
          if (this.MethLab_SecurityUpgrade)
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) "meth_lab_security_high");
          else if (!this.MethLab_SecurityUpgrade)
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247041, (InputArgument) "meth_lab_security_high");
        }
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 247041);
      }
      if (this.EnableBikerWeedFarm)
      {
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_3_biker_dlc_int_ware02_milo");
        if (!this.WeedFarm_InitialSetupDone)
        {
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) "weed_security_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_upgrade_equip");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_upgrade_equip");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_drying");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_production");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_set_up");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_chairs");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage1");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage2");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage3");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hosea");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hoseb");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hosec");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hosed");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hosee");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hosef");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hoseg");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hoseh");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_hosei");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growtha_stage23_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growthb_stage23_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growthc_stage23_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growthd_stage23_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growthe_stage23_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growthf_stage23_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growthg_stage23_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growthh_stage23_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "light_growthi_stage23_upgrade");
        }
        if (this.WeedFarm_InitialSetupDone)
        {
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_upgrade_equip");
          if (this.WeedFarm_EquipmentUpgrade)
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_upgrade_equip");
          else if (!this.WeedFarm_EquipmentUpgrade)
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_upgrade_equip");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_drying");
          if (this.WeedFarm_SecurityUpgrade)
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) "weed_security_upgrade");
          else if (!this.WeedFarm_SecurityUpgrade)
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_security_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_production");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_set_up");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_chairs");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growtha_stage1");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthb_stage1");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthc_stage1");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthd_stage1");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthe_stage1");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthf_stage1");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthg_stage1");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthh_stage1");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthi_stage1");
          if (!this.TriggeredWeedStage2)
          {
            if (this.WeedFarm_ProductBags / this.WeedFarm_ProductMax * 90 >= 33 && this.WeedFarm_ProductBags / this.WeedFarm_ProductMax <= 66)
            {
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growtha_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthb_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthc_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthd_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthe_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthf_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthg_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthh_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthi_stage1");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage3");
            }
            else
            {
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage2");
            }
          }
          if (!this.TriggeredWeedStage3)
          {
            if (this.WeedFarm_ProductBags / this.WeedFarm_ProductMax * 90 >= 66 && this.WeedFarm_ProductBags / this.WeedFarm_ProductMax <= 100)
            {
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growtha_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthb_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthc_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthd_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthe_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthf_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthg_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthh_stage1");
              Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_growthi_stage1");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage3");
            }
            else
            {
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage3");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growtha_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthb_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthc_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthd_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthe_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthf_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthg_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthh_stage2");
              Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247297, (InputArgument) "weed_growthi_stage2");
            }
          }
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hosea");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hoseb");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hosec");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hosed");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hosee");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hosef");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hoseg");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hoseh");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "weed_hosei");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growtha_stage23_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growthb_stage23_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growthc_stage23_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growthd_stage23_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growthe_stage23_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growthf_stage23_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growthg_stage23_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growthh_stage23_upgrade");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247297, (InputArgument) "light_growthi_stage23_upgrade");
        }
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 247297);
      }
      if (this.EnableBikerCocaineLab)
      {
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_4_biker_dlc_int_ware03_milo");
        if (!this.CocaineLockup_InitialSetupDone)
        {
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_01");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "security_high");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_01");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_02");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_03");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_04");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_05");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "equipment_basic");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_press_basic");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "table_equipment");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_press_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "production_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "equipment_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "table_equipment_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_04");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_05");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_press_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "production_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "equipment_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "table_equipment_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "security_high");
        }
        if (this.CocaineLockup_InitialSetupDone)
        {
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_01");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "security_high");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_01");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_02");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_03");
          if (this.CocaineLockup_SecurityUpgrade)
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "security_high");
          else if (!this.CocaineLockup_EquipmentUpgrade)
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "security_high");
          if (this.CocaineLockup_EquipmentUpgrade)
          {
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_04");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_05");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "equipment_basic");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_press_basic");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "table_equipment");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_press_upgrade");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "production_upgrade");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "equipment_upgrade");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "table_equipment_upgrade");
          }
          else if (!this.CocaineLockup_EquipmentUpgrade)
          {
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_04");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_cut_05");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "equipment_basic");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_press_basic");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "table_equipment");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "coke_press_upgrade");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "production_upgrade");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "equipment_upgrade");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247553, (InputArgument) "table_equipment_upgrade");
          }
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_01");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_02");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "coke_cut_03");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247553, (InputArgument) "set_up");
        }
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 247553);
      }
      if (this.EnableBikerForgeryOffice)
      {
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_6_biker_dlc_int_ware05_milo");
        if (!this.DocumentForgery_InitialSetupDone)
        {
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "interior_basic");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "clutter");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "clutter");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "equipment_basic");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "interior_basic");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "interior_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "equipment_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "clutter");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "interior_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "equipment_upgrade");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "security_high");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "production");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "set_up");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "chair01");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "chair02");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "chair03");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "chair04");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "chair05");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "chair06");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "chair07");
        }
        if (this.DocumentForgery_InitialSetupDone)
        {
          if (this.DocumentForgery_EquipmentUpgrade)
          {
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "clutter");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "equipment_basic");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "interior_basic");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "interior_upgrade");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "equipment_upgrade");
          }
          else if (!this.DocumentForgery_EquipmentUpgrade)
          {
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "equipment_basic");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "interior_basic");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "clutter");
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "interior_upgrade");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "equipment_upgrade");
          }
          if (this.DocumentForgery_SecurityUpgrade)
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "security_high");
          else if (!this.DocumentForgery_SecurityUpgrade)
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 246785, (InputArgument) "security_high");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "production");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "set_up");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "chair01");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "chair02");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "chair03");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "chair04");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "chair05");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "chair06");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 246785, (InputArgument) "chair07");
        }
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 246785);
      }
      if (!this.EnableBikerMoneyPrinter)
        return;
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "bkr_biker_interior_placement_interior_5_biker_dlc_int_ware04_milo");
      if (!this.CounterfeitOffice_InitialSetupDone)
      {
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryerc_on");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryerd_on");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_security");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile100a");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile20a");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile10a");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile100b");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile100c");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile100d");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile20b");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile20c");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile20d");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile10b");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile10c");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile10d");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_setup");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryera_on");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryerb_on");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_upgrade_equip");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryerc_on");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryerd_on");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "money_cutter");
      }
      if (this.CounterfeitOffice_InitialSetupDone)
      {
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "dryerc_on");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryerd_on");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_security");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile100a");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile20a");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile10a");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile100b");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile100c");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile100d");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile20b");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile20c");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile20d");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile10b");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile10c");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_cashpile10d");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_setup");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "dryera_on");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "dryerb_on");
        if (this.CounterfeitOffice_EquipmentUpgrade)
        {
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "counterfeit_upgrade_equip");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "dryerc_on");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "dryerd_on");
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "money_cutter");
        }
        if (!this.CounterfeitOffice_EquipmentUpgrade)
        {
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "counterfeit_upgrade_equip");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryerc_on");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "dryerd_on");
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 247809, (InputArgument) "money_cutter");
        }
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) 247809, (InputArgument) "special_chairs");
      }
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 247809);
    }

    public int GI()
    {
      Vector3 position = Game.Player.Character.Position;
      return Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z);
    }

    public void DisplayStats(int Product, int Supplies)
    {
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

    public void CreatePeds()
    {
      Vector3 position = Game.Player.Character.Position;
      if ((uint) Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) <= 0U || (this.GI() != this.MethLabId && this.GI() != this.WeedFarmId && (this.GI() != this.CocaineLockupId && this.GI() != this.DocumentForgeryId) && this.GI() != this.CounterfeitOfficeId || this.Createdpeds))
        return;
      this.CreatePeds2();
    }

    public int GetPercentage(int _1, int _2)
    {
      this.f = 0.0f;
      float num1 = (float) _1;
      float num2 = (float) _2;
      if ((double) num1 > (double) num2 && ((double) num1 != 0.0 && (double) num2 != 0.0))
        this.f = (float) (((double) num1 - (double) num2) / (double) num1 * 100.0);
      if ((double) num1 < (double) num2 && ((double) num1 != 0.0 && (double) num2 != 0.0))
        this.f = (float) (((double) num2 - (double) num1) / (double) num2 * 100.0);
      if ((double) num1 == 0.0)
      {
        float num3 = num1;
        if ((double) num3 == (double) this.MethLab_TotalResupplySuccess)
          this.f = 0.0f;
        if ((double) num3 == (double) this.MethLab_TotalResupplyFails)
          this.f = 100f;
        if ((double) num3 == (double) this.MethLab_TotalSales_LS)
          this.f = 0.0f;
        if ((double) num3 == (double) this.MethLab_TotalFails_LS)
          this.f = 100f;
        if ((double) num3 == (double) this.MethLab_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.MethLab_TotalFails_BC)
          this.f = 100f;
        if ((double) num3 == (double) this.MethLab_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.MethLab_TotalFails_BC)
          this.f = 100f;
        if ((double) num3 == (double) this.WeedFarm_TotalResupplySuccess)
          this.f = 0.0f;
        if ((double) num3 == (double) this.WeedFarm_TotalResupplyFails)
          this.f = 100f;
        if ((double) num3 == (double) this.WeedFarm_TotalSales_LS)
          this.f = 0.0f;
        if ((double) num3 == (double) this.WeedFarm_TotalFails_LS)
          this.f = 100f;
        if ((double) num3 == (double) this.WeedFarm_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.WeedFarm_TotalFails_BC)
          this.f = 100f;
        if ((double) num3 == (double) this.WeedFarm_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.WeedFarm_TotalFails_BC)
          this.f = 100f;
        if ((double) num3 == (double) this.CocaineLockup_TotalResupplySuccess)
          this.f = 0.0f;
        if ((double) num3 == (double) this.CocaineLockup_TotalResupplyFails)
          this.f = 100f;
        if ((double) num3 == (double) this.CocaineLockup_TotalSales_LS)
          this.f = 0.0f;
        if ((double) num3 == (double) this.CocaineLockup_TotalFails_LS)
          this.f = 100f;
        if ((double) num3 == (double) this.CocaineLockup_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.CocaineLockup_TotalFails_BC)
          this.f = 100f;
        if ((double) num3 == (double) this.CocaineLockup_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.CocaineLockup_TotalFails_BC)
          this.f = 100f;
        if (this.CocaineLockup_TotalFails_BC == 0 && this.CocaineLockup_TotalSales_BC == 0)
          this.f = 0.0f;
        if (this.CocaineLockup_TotalFails_LS == 0 && this.CocaineLockup_TotalSales_LS == 0)
          this.f = 0.0f;
        if (this.CocaineLockup_TotalResupplyFails == 0 && this.CocaineLockup_TotalResupplySuccess == 0)
          this.f = 0.0f;
        if ((double) num3 == (double) this.DocumentForgery_TotalResupplySuccess)
          this.f = 0.0f;
        if ((double) num3 == (double) this.DocumentForgery_TotalResupplyFails)
          this.f = 100f;
        if ((double) num3 == (double) this.DocumentForgery_TotalSales_LS)
          this.f = 0.0f;
        if ((double) num3 == (double) this.DocumentForgery_TotalFails_LS)
          this.f = 100f;
        if ((double) num3 == (double) this.DocumentForgery_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.DocumentForgery_TotalFails_BC)
          this.f = 100f;
        if ((double) num3 == (double) this.DocumentForgery_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.DocumentForgery_TotalFails_BC)
          this.f = 100f;
        if ((double) num3 == (double) this.CounterfeitOffice_TotalResupplySuccess)
          this.f = 0.0f;
        if ((double) num3 == (double) this.CounterfeitOffice_TotalResupplyFails)
          this.f = 100f;
        if ((double) num3 == (double) this.CounterfeitOffice_TotalSales_LS)
          this.f = 0.0f;
        if ((double) num3 == (double) this.CounterfeitOffice_TotalFails_LS)
          this.f = 100f;
        if ((double) num3 == (double) this.CounterfeitOffice_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.CounterfeitOffice_TotalFails_BC)
          this.f = 100f;
        if ((double) num3 == (double) this.CounterfeitOffice_TotalSales_BC)
          this.f = 0.0f;
        if ((double) num3 == (double) this.CounterfeitOffice_TotalFails_BC)
          this.f = 100f;
      }
      if ((double) num2 != 0.0)
        ;
      if ((double) this.f >= 100.0)
        this.f = 100f;
      if ((double) this.f <= 0.0)
        this.f = 0.0f;
      if ((double) num1 == 0.0 && (double) num2 == 0.0)
        this.f = 0.0f;
      return (int) this.f;
    }

    public int GetTotalSales(int _1_1, int _1_2) => _1_1 + _1_2;

    public float CaluclateSellCost(int Mission, int LowHigh, bool Upg)
    {
      float num = 0.0f;
      if (Mission == 1)
      {
        if (LowHigh == 0)
        {
          int methMcbusinessLoc = this.MethMCbusinessLoc;
          if (methMcbusinessLoc == 0)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 100.0);
          if (methMcbusinessLoc == 1)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 100.0);
          if (methMcbusinessLoc == 2)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 70.0);
          if (methMcbusinessLoc == 3)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 90.0);
          if (methMcbusinessLoc == 4)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 100.0);
          num = this.SETMethLab_SellPrice;
        }
        if (LowHigh == 1)
        {
          int methMcbusinessLoc = this.MethMCbusinessLoc;
          if (methMcbusinessLoc == 0)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 60.0);
          if (methMcbusinessLoc == 1)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 70.0);
          if (methMcbusinessLoc == 2)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 100.0);
          if (methMcbusinessLoc == 3)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 90.0);
          if (methMcbusinessLoc == 4)
            this.SETMethLab_SellPrice = (float) ((double) this.SETMethLab_ProductValue / 100.0 * 60.0);
          num = this.SETMethLab_SellPrice;
        }
      }
      if (Mission == 2)
      {
        if (LowHigh == 0)
        {
          int cocaineMcbusinessLoc = this.CocaineMCbusinessLoc;
          if (cocaineMcbusinessLoc == 0)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 100.0);
          if (cocaineMcbusinessLoc == 1)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 100.0);
          if (cocaineMcbusinessLoc == 2)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 100.0);
          if (cocaineMcbusinessLoc == 3)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 70.0);
          if (cocaineMcbusinessLoc == 4)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 60.0);
          num = this.SETCocaineLockup_SellPrice;
        }
        if (LowHigh == 1)
        {
          int cocaineMcbusinessLoc = this.CocaineMCbusinessLoc;
          if (cocaineMcbusinessLoc == 0)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 60.0);
          if (cocaineMcbusinessLoc == 1)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 50.0);
          if (cocaineMcbusinessLoc == 2)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 70.0);
          if (cocaineMcbusinessLoc == 3)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 100.0);
          if (cocaineMcbusinessLoc == 4)
            this.SETCocaineLockup_SellPrice = (float) ((double) this.SETCocaineLockup_ProductValue / 100.0 * 100.0);
          num = this.SETCocaineLockup_SellPrice;
        }
      }
      if (Mission == 3)
      {
        if (LowHigh == 0)
        {
          int weedMcbusinessLoc = this.WeedMCbusinessLoc;
          if (weedMcbusinessLoc == 0)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 90.0);
          if (weedMcbusinessLoc == 1)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 80.0);
          if (weedMcbusinessLoc == 2)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 100.0);
          if (weedMcbusinessLoc == 3)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 60.0);
          if (weedMcbusinessLoc == 4)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 50.0);
          num = this.SETWeedFarm_SellPrice;
        }
        if (LowHigh == 1)
        {
          int weedMcbusinessLoc = this.WeedMCbusinessLoc;
          if (weedMcbusinessLoc == 0)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 50.0);
          if (weedMcbusinessLoc == 1)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 60.0);
          if (weedMcbusinessLoc == 2)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 70.0);
          if (weedMcbusinessLoc == 3)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 100.0);
          if (weedMcbusinessLoc == 4)
            this.SETWeedFarm_SellPrice = (float) ((double) this.SETWeedFarm_ProductValue / 100.0 * 90.0);
          num = this.SETWeedFarm_SellPrice;
        }
      }
      if (Mission == 4)
      {
        if (LowHigh == 0)
        {
          int counterfietMcbusinessLoc = this.CounterfietMCbusinessLoc;
          if (counterfietMcbusinessLoc == 0)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 50.0);
          if (counterfietMcbusinessLoc == 1)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 70.0);
          if (counterfietMcbusinessLoc == 2)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 100.0);
          if (counterfietMcbusinessLoc == 3)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 60.0);
          if (counterfietMcbusinessLoc == 4)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 40.0);
          num = this.SETCounterfeitOffice_SellPrice;
        }
        if (LowHigh == 1)
        {
          int counterfietMcbusinessLoc = this.CounterfietMCbusinessLoc;
          if (counterfietMcbusinessLoc == 0)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 100.0);
          if (counterfietMcbusinessLoc == 1)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 60.0);
          if (counterfietMcbusinessLoc == 2)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 90.0);
          if (counterfietMcbusinessLoc == 3)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 100.0);
          if (counterfietMcbusinessLoc == 4)
            this.SETCounterfeitOffice_SellPrice = (float) ((double) this.SETCounterfeitOffice_ProductValue / 100.0 * 100.0);
          num = this.SETCounterfeitOffice_SellPrice;
        }
      }
      if (Mission == 5)
      {
        if (LowHigh == 0)
        {
          int forgeryMcbusinessLoc = this.ForgeryMCbusinessLoc;
          if (forgeryMcbusinessLoc == 0)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 70.0);
          if (forgeryMcbusinessLoc == 1)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 100.0);
          if (forgeryMcbusinessLoc == 2)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 60.0);
          if (forgeryMcbusinessLoc == 3)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 90.0);
          if (forgeryMcbusinessLoc == 4)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 50.0);
          num = this.SETDocumentForgery_SellPrice;
        }
        if (LowHigh == 1)
        {
          int forgeryMcbusinessLoc = this.ForgeryMCbusinessLoc;
          if (forgeryMcbusinessLoc == 0)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 60.0);
          if (forgeryMcbusinessLoc == 1)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 70.0);
          if (forgeryMcbusinessLoc == 2)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 100.0);
          if (forgeryMcbusinessLoc == 3)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 80.0);
          if (forgeryMcbusinessLoc == 4)
            this.SETDocumentForgery_SellPrice = (float) ((double) this.SETDocumentForgery_ProductValue / 100.0 * 100.0);
          num = this.SETDocumentForgery_SellPrice;
        }
      }
      return num;
    }

    public void SellProduct(int Mission)
    {
      if (Mission != 1)
        ;
      if (Mission != 2)
        ;
      if (Mission != 3)
        ;
      if (Mission != 4)
        ;
      if (Mission != 5)
        ;
    }

    public int MCBusinessGUI(string scale, int ID)
    {
      int num = 0;
      if (ID == 1)
      {
        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) scale));
        while (!this.GUIscaleform.IsLoaded)
          Script.Wait(100);
        if (!this.GUIscaleform.IsLoaded)
        {
          num = 0;
        }
        else
        {
          this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) Game.Player.Name.ToUpper().ToString(), (object) true);
          if (!this.MethLab_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 3, (object) "MP_BWH_METH_1", (object) "MP_BWH_METH_2", (object) "MP_BWH_METH_3", (object) 4, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0, (object) false, (object) 0, (object) 0, (object) 0, (object) true, (object) 0);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0);
          }
          if (this.MethLab_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 3, (object) "MP_BWH_METH_1", (object) "MP_BWH_METH_2", (object) "MP_BWH_METH_3", (object) 1, (object) 0, (object) 0, (object) this.MethLab_ProductBags, (object) 0, (object) this.MethLab_Supplies, (object) true, (object) this.MethLab_TotalEarnings, (object) this.MethLab_ProductionCeased_NoRaided, (object) this.GetTotalSales(this.MethLab_TotalSales_BC, this.MethLab_TotalSales_LS), (object) true, (object) (float) (75000.0 * (double) this.MethLab_BuySuppliesMultiplier));
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) this.GetPercentage(this.MethLab_TotalResupplySuccess, this.MethLab_TotalResupplyFails), (object) this.GetPercentage(this.MethLab_TotalFails_LS, this.MethLab_TotalSales_LS), (object) this.GetPercentage(this.MethLab_TotalFails_BC, this.MethLab_TotalSales_BC), (object) this.MethLab_ProductionCeased_NoSupplies, (object) this.MethLab_ProductionCeased_NoCapacity);
          }
          if (!this.MethLab_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (1100000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_0");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (331000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_2");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (513000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_1");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) false);
          }
          if (this.MethLab_InitialSetupDone)
          {
            if (!this.MethLab_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (1100000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) true);
            }
            if (this.MethLab_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (1100000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            }
            if (!this.MethLab_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (331000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) true);
            }
            if (this.MethLab_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (331000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            }
            if (!this.MethLab_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (513000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) true);
            }
            if (this.MethLab_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (513000.0 * (double) this.MethLab_BuySuppliesMultiplier), (object) "meth_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            }
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) true);
          }
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 1, (object) "OR_BYR_DETAILS2", (object) "OR_GOODS_BYR2", (object) this.CaluclateSellCost(1, 0, true));
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 2, (object) "OR_BYR_DETAILS1", (object) "OR_GOODS_BYR1", (object) this.CaluclateSellCost(1, 1, true));
          if (!this.MethLab_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) false);
          }
          if (this.MethLab_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) true);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) true);
          }
          this.GUIscaleform.CallFunction("showScreen", (object) 5);
          num = 1;
        }
      }
      if (ID == 2)
      {
        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) scale));
        while (!this.GUIscaleform.IsLoaded)
          Script.Wait(100);
        if (!this.GUIscaleform.IsLoaded)
        {
          num = 0;
        }
        else
        {
          this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) Game.Player.Name.ToUpper().ToString(), (object) true);
          UI.Notify("CocaineLockup_InitialSetupDone " + this.CocaineLockup_InitialSetupDone.ToString());
          if (!this.CocaineLockup_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 0, (object) 4, (object) "MP_BWH_CRACK_1", (object) "MP_BWH_CRACK_2", (object) "MP_BWH_CRACK_3", (object) 4, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0, (object) false, (object) 0, (object) 0, (object) 0, (object) true, (object) 0);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 0, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0);
          }
          if (this.CocaineLockup_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 4, (object) "MP_BWH_CRACK_1", (object) "MP_BWH_CRACK_2", (object) "MP_BWH_CRACK_3", (object) 1, (object) 0, (object) 0, (object) this.CocaineLockup_ProductBags, (object) 0, (object) this.CocaineLockup_Supplies, (object) true, (object) this.CocaineLockup_TotalEarnings, (object) this.CocaineLockup_ProductionCeased_NoRaided, (object) this.GetTotalSales(this.CocaineLockup_TotalSales_BC, this.CocaineLockup_TotalSales_LS), (object) true, (object) (float) (75000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier));
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) this.GetPercentage(this.CocaineLockup_TotalResupplySuccess, this.CocaineLockup_TotalResupplyFails), (object) this.GetPercentage(this.CocaineLockup_TotalFails_LS, this.CocaineLockup_TotalSales_LS), (object) this.GetPercentage(this.CocaineLockup_TotalFails_BC, this.CocaineLockup_TotalSales_BC), (object) this.CocaineLockup_ProductionCeased_NoSupplies, (object) this.CocaineLockup_ProductionCeased_NoCapacity);
          }
          if (!this.CocaineLockup_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (935000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_0");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (390000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_2");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (570000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_1");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) false);
          }
          if (this.CocaineLockup_InitialSetupDone)
          {
            if (!this.CocaineLockup_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (935000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) true);
            }
            if (this.CocaineLockup_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (935000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            }
            if (!this.CocaineLockup_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (390000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) true);
            }
            if (this.CocaineLockup_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (390000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            }
            if (!this.CocaineLockup_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (570000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) true);
            }
            if (this.CocaineLockup_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (570000.0 * (double) this.CocaineLockup_BuySuppliesMultiplier), (object) "coke_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            }
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) true);
          }
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 1, (object) "OR_BYR_DETAILS2", (object) "OR_GOODS_BYR2", (object) this.CaluclateSellCost(2, 0, true));
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 2, (object) "OR_BYR_DETAILS1", (object) "OR_GOODS_BYR1", (object) this.CaluclateSellCost(2, 1, true));
          if (!this.CocaineLockup_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) false);
          }
          if (this.CocaineLockup_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) true);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) true);
          }
          this.GUIscaleform.CallFunction("showScreen", (object) 5);
          num = 1;
        }
      }
      if (ID == 3)
      {
        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) scale));
        while (!this.GUIscaleform.IsLoaded)
          Script.Wait(100);
        if (!this.GUIscaleform.IsLoaded)
        {
          num = 0;
        }
        else
        {
          this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) Game.Player.Name.ToUpper().ToString(), (object) true);
          if (!this.WeedFarm_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 1, (object) "MP_BWH_WEED_1", (object) "MP_BWH_WEED_1", (object) "MP_BWH_WEED_1", (object) 4, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0, (object) false, (object) 0, (object) 0, (object) 0, (object) true, (object) 0);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0);
          }
          if (this.WeedFarm_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 1, (object) "MP_BWH_WEED_1", (object) "MP_BWH_WEED_1", (object) "MP_BWH_WEED_1", (object) 1, (object) 0, (object) 0, (object) this.WeedFarm_ProductBags, (object) 0, (object) this.WeedFarm_Supplies, (object) true, (object) this.WeedFarm_TotalEarnings, (object) this.WeedFarm_ProductionCeased_NoRaided, (object) this.GetTotalSales(this.WeedFarm_TotalSales_BC, this.WeedFarm_TotalSales_LS), (object) true, (object) (float) (75000.0 * (double) this.WeedFarm_BuySuppliesMultiplier));
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) this.GetPercentage(this.WeedFarm_TotalResupplySuccess, this.WeedFarm_TotalResupplyFails), (object) this.GetPercentage(this.WeedFarm_TotalFails_LS, this.WeedFarm_TotalSales_LS), (object) this.GetPercentage(this.WeedFarm_TotalFails_BC, this.WeedFarm_TotalSales_BC), (object) this.WeedFarm_ProductionCeased_NoSupplies, (object) this.WeedFarm_ProductionCeased_NoCapacity);
          }
          if (!this.WeedFarm_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (990000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_0");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (273000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_2");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (313000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_1");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) false);
          }
          if (this.WeedFarm_InitialSetupDone)
          {
            if (!this.WeedFarm_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (990000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) true);
            }
            if (this.WeedFarm_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (990000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            }
            if (!this.WeedFarm_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (273000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) true);
            }
            if (this.WeedFarm_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (273000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            }
            if (!this.WeedFarm_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (313000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) true);
            }
            if (this.WeedFarm_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (313000.0 * (double) this.WeedFarm_BuySuppliesMultiplier), (object) "weed_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            }
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) true);
          }
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 1, (object) "OR_BYR_DETAILS2", (object) "OR_GOODS_BYR2", (object) this.CaluclateSellCost(3, 0, true));
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 2, (object) "OR_BYR_DETAILS1", (object) "OR_GOODS_BYR1", (object) this.CaluclateSellCost(3, 1, true));
          if (!this.WeedFarm_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) false);
          }
          if (this.WeedFarm_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) true);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) true);
          }
          this.GUIscaleform.CallFunction("showScreen", (object) 5);
          num = 1;
        }
      }
      if (ID == 4)
      {
        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) scale));
        while (!this.GUIscaleform.IsLoaded)
          Script.Wait(100);
        if (!this.GUIscaleform.IsLoaded)
        {
          num = 0;
        }
        else
        {
          this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) Game.Player.Name.ToUpper().ToString(), (object) true);
          if (!this.CounterfeitOffice_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 2, (object) "MP_BWH_FCASH_1", (object) "MP_BWH_FCASH_1", (object) "MP_BWH_FCASH_1", (object) 4, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0, (object) false, (object) 0, (object) 0, (object) 0, (object) true, (object) 0);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0);
          }
          if (this.CounterfeitOffice_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 2, (object) "MP_BWH_FCASH_1", (object) "MP_BWH_FCASH_1", (object) "MP_BWH_FCASH_1", (object) 1, (object) 0, (object) 0, (object) this.CounterfeitOffice_ProductBags, (object) 0, (object) this.CounterfeitOffice_Supplies, (object) true, (object) this.CounterfeitOffice_TotalEarnings, (object) this.CounterfeitOffice_ProductionCeased_NoRaided, (object) this.GetTotalSales(this.CounterfeitOffice_TotalSales_BC, this.CounterfeitOffice_TotalSales_LS), (object) true, (object) (float) (75000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier));
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) this.GetPercentage(this.CounterfeitOffice_TotalResupplySuccess, this.CounterfeitOffice_TotalResupplyFails), (object) this.GetPercentage(this.CounterfeitOffice_TotalFails_LS, this.CounterfeitOffice_TotalSales_LS), (object) this.GetPercentage(this.CounterfeitOffice_TotalFails_BC, this.CounterfeitOffice_TotalSales_BC), (object) this.CounterfeitOffice_ProductionCeased_NoSupplies, (object) this.CounterfeitOffice_ProductionCeased_NoCapacity);
          }
          if (!this.CounterfeitOffice_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (880000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_0");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (273000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_2");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (456000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_1");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) false);
          }
          if (this.CounterfeitOffice_InitialSetupDone)
          {
            if (!this.CounterfeitOffice_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (880000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) true);
            }
            if (this.CounterfeitOffice_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (880000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            }
            if (this.CounterfeitOffice_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (273000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            }
            if (!this.CounterfeitOffice_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (273000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) true);
            }
            if (!this.CounterfeitOffice_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (456000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) true);
            }
            if (this.CounterfeitOffice_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (456000.0 * (double) this.CounterfeitOffice_BuySuppliesMultiplier), (object) "fakecash_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            }
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) true);
          }
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 1, (object) "OR_BYR_DETAILS2", (object) "OR_GOODS_BYR2", (object) this.CaluclateSellCost(4, 0, true));
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 2, (object) "OR_BYR_DETAILS1", (object) "OR_GOODS_BYR1", (object) this.CaluclateSellCost(4, 1, true));
          if (!this.CounterfeitOffice_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) false);
          }
          if (this.CounterfeitOffice_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) true);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) true);
          }
          this.GUIscaleform.CallFunction("showScreen", (object) 5);
          num = 1;
        }
      }
      if (ID == 5)
      {
        this.GUIscaleform = new Scaleform(Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) scale));
        while (!this.GUIscaleform.IsLoaded)
          Script.Wait(100);
        if (!this.GUIscaleform.IsLoaded)
        {
          num = 0;
        }
        else
        {
          this.GUIscaleform.CallFunction("SET_PLAYER_DATA", (object) Game.Player.Name.ToUpper().ToString(), (object) true);
          if (!this.DocumentForgery_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 0, (object) "MP_BWH_FID_1", (object) "MP_BWH_FID_1", (object) "MP_BWH_FID_1", (object) 4, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0, (object) false, (object) 0, (object) 0, (object) 0, (object) true, (object) 0);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) 0, (object) 0, (object) 0, (object) 0, (object) 0);
          }
          if (this.DocumentForgery_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS", (object) 1, (object) 0, (object) "MP_BWH_FID_1", (object) "MP_BWH_FID_1", (object) "MP_BWH_FID_1", (object) 1, (object) 0, (object) 0, (object) this.DocumentForgery_ProductBags, (object) 0, (object) this.DocumentForgery_Supplies, (object) true, (object) this.DocumentForgery_TotalEarnings, (object) this.DocumentForgery_ProductionCeased_NoRaided, (object) this.GetTotalSales(this.DocumentForgery_TotalSales_BC, this.DocumentForgery_TotalSales_LS), (object) true, (object) (float) (75000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier));
            this.GUIscaleform.CallFunction("ADD_BUSINESS_STATS", (object) 1, (object) this.GetPercentage(this.DocumentForgery_TotalResupplySuccess, this.DocumentForgery_TotalResupplyFails), (object) this.GetPercentage(this.DocumentForgery_TotalFails_LS, this.DocumentForgery_TotalSales_LS), (object) this.GetPercentage(this.DocumentForgery_TotalFails_BC, this.DocumentForgery_TotalSales_BC), (object) this.DocumentForgery_ProductionCeased_NoSupplies, (object) this.DocumentForgery_ProductionCeased_NoCapacity);
          }
          if (!this.DocumentForgery_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (550000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_0");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (195000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_2");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (285000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_1");
            this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) false);
          }
          if (this.DocumentForgery_InitialSetupDone)
          {
            if (!this.DocumentForgery_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (550000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) true);
            }
            if (this.DocumentForgery_EquipmentUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 1, (object) "OR_UPG_0", (object) (float) (550000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_0");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 1, (object) false);
            }
            if (!this.DocumentForgery_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (195000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) true);
            }
            if (this.DocumentForgery_SecurityUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 3, (object) "OR_UPG_1", (object) (float) (195000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_2");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 3, (object) false);
            }
            if (!this.DocumentForgery_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (285000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) true);
            }
            if (this.DocumentForgery_StaffUpgrade)
            {
              this.GUIscaleform.CallFunction("ADD_BUSINESS_UPGRADE", (object) 1, (object) 2, (object) "OR_UPG_2", (object) (float) (285000.0 * (double) this.DocumentForgery_BuySuppliesMultiplier), (object) "fake_id_upg_1");
              this.GUIscaleform.CallFunction("SET_BUSINESS_UPGRADE_STATUS", (object) 1, (object) 2, (object) false);
            }
            this.GUIscaleform.CallFunction("SET_START_PRODUCTION_STATUS", (object) true);
          }
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 1, (object) "OR_BYR_DETAILS2", (object) "OR_GOODS_BYR2", (object) this.CaluclateSellCost(5, 0, true));
          this.GUIscaleform.CallFunction("ADD_BUSINESS_BUYER", (object) 1, (object) 2, (object) "OR_BYR_DETAILS1", (object) "OR_GOODS_BYR1", (object) this.CaluclateSellCost(5, 1, true));
          if (!this.DocumentForgery_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) false);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) false);
          }
          if (this.DocumentForgery_InitialSetupDone)
          {
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 1, (object) true);
            this.GUIscaleform.CallFunction("SET_BUSINESS_BUYER_STATUS", (object) 1, (object) 2, (object) true);
          }
          this.GUIscaleform.CallFunction("showScreen", (object) 5);
          num = 1;
        }
      }
      return num;
    }

    public void Overlay(
      int mindex,
      string param1,
      string param2,
      string param3,
      int textcom,
      bool clickfail)
    {
      --this.GUIBIX;
      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) param1, (object) param2, (object) param3);
      if (textcom != -1)
        Function.Call(Hash._0x03B504CF259931BC, (InputArgument) textcom);
      if (!clickfail)
        return;
      Function.Call(Hash._0x67C540AA08E4A6F5, (InputArgument) -1, (InputArgument) "Click_Fail", (InputArgument) "DLC_Biker_Computer_Sounds", (InputArgument) true);
    }

    public void Overlay2(
      int mindex,
      string param1,
      string param2,
      string param3,
      int textcom,
      bool clickfail)
    {
      --this.GUIBIX;
      this.GUIscaleform.CallFunction("SHOW_OVERLAY", (object) param1, (object) param2, (object) param3);
      if (textcom != -1)
      {
        UI.Notify("Test 1");
        Function.Call(Hash._0x03B504CF259931BC, (InputArgument) textcom);
      }
      if (!clickfail)
        return;
      UI.Notify("Test 2");
      Function.Call(Hash._0x67C540AA08E4A6F5, (InputArgument) -1, (InputArgument) "Click_Fail", (InputArgument) "DLC_Biker_Computer_Sounds", (InputArgument) true);
    }

    public void SetupPassed()
    {
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 350), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Setup Passed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 199, 168, 87), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void StealSuppliesPassed()
    {
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 350), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Steal Supplies Complete", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 199, 168, 87), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void StealSuppliesFail()
    {
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 350), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Steal Supplies Failed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 148, 27, 46), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void SetupFailed()
    {
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 350), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Setup Failed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 148, 27, 46), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void SellSuppliesPassed()
    {
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 350), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Sell Supplies Complete", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 199, 168, 87), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void SellSuppliesFail()
    {
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 350), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Sell Supplies Failed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 148, 27, 46), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void StartSupplyRun(int Mission)
    {
      this.mission = Mission;
      Vector3 vector3 = new Vector3(0.0f, 0.0f, 0.0f);
      Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
      System.Random random = new System.Random();
      if (Mission == 1)
      {
        Vector3 destination = this.MCSubLocMeth[this.MethMCbusinessLoc].SupplyTruckSpawn.Around((float) random.Next(1500, 6000));
        position = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position = origin;
          }
        }
      }
      if (Mission == 2)
      {
        Vector3 destination = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].SupplyTruckSpawn.Around((float) random.Next(1500, 6000));
        position = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position = origin;
          }
        }
      }
      if (Mission == 3)
      {
        Vector3 destination = this.MCSubLocWeed[this.MethMCbusinessLoc].SupplyTruckSpawn.Around((float) random.Next(1500, 6000));
        position = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position = origin;
          }
        }
      }
      if (Mission == 4)
      {
        Vector3 destination = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].SupplyTruckSpawn.Around((float) random.Next(1500, 6000));
        position = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position = origin;
          }
        }
      }
      if (Mission == 5)
      {
        Vector3 destination = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].SupplyTruckSpawn.Around((float) random.Next(1500, 6000));
        position = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position = origin;
          }
        }
      }
      this.MissionNum = 10;
      if ((Entity) this.VehicleItem_SetupMission != (Entity) null)
        this.VehicleItem_SetupMission.Delete();
      if ((Entity) this.PropItem_SetupMission != (Entity) null)
        this.PropItem_SetupMission.Delete();
      if (this.BlipItem_SetupMission != (Blip) null)
        this.BlipItem_SetupMission.Remove();
      position = new Vector3(position.X, position.Y, position.Z + 2f);
      this.VehicleItem_SetupMission = World.CreateVehicle((Model) VehicleHash.GBurrito2, position, 0.0f);
      this.VehicleItem_SetupMission.ToggleExtra(2, false);
      Vector3 offsetInWorldCoords = this.VehicleItem_SetupMission.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
      this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords, new Vector3(0.0f, 0.0f, this.VehicleItem_SetupMission.Heading), false, false);
      this.PropItem_SetupMission.HasCollision = false;
      this.PropItem_SetupMission.SetNoCollision((Entity) this.VehicleItem_SetupMission, true);
      this.VehicleItem_SetupMission.SetNoCollision((Entity) this.PropItem_SetupMission, true);
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.VehicleItem_SetupMission.Handle, (InputArgument) 0);
      this.VehicleItem_SetupMission.PrimaryColor = VehicleColor.MetallicDarkSilver;
      this.VehicleItem_SetupMission.SecondaryColor = VehicleColor.BrushedBlackSteel;
      this.VehicleItem_SetupMission.PlaceOnGround();
      this.BlipItem_SetupMission = World.CreateBlip(position);
      this.BlipItem_SetupMission.Sprite = BlipSprite.SpecialCargo;
      this.BlipItem_SetupMission.Name = "Steal Supplies";
      this.BlipItem_SetupMission.Color = this.Blip_Colour;
      this.BlipItem_SetupMission.IsShortRange = true;
      foreach (Blip blip in this.DropBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      this.DropBlip.Clear();
      this.PointsBeenAt = 0;
      this.MissionOn = true;
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

    public float GD(Vector3 Y, Vector3 X) => World.GetDistance(Y, X);

    public void SetupSellSupplies(int Mission, int DeliveryLoc, int CurrentLoc)
    {
      this.MissionLoc = DeliveryLoc;
      this.mission = Mission;
      Vector3 vector3_1 = new Vector3(-191.29f, -893.1881f, 33f);
      Vector3 vector3_2 = new Vector3(1139.337f, 3980.917f, 54f);
      Vector3 vector3_3 = new Vector3(0.0f, 0.0f, 0.0f);
      if (DeliveryLoc == 0)
        vector3_3 = vector3_1;
      if (DeliveryLoc == 1)
        vector3_3 = vector3_2;
      this.mission = Mission;
      Vector3 destination = new Vector3(0.0f, 0.0f, 0.0f);
      Vector3 position1 = new Vector3(0.0f, 0.0f, 0.0f);
      Vector3 position2 = new Vector3(0.0f, 0.0f, 0.0f);
      float heading = 0.0f;
      System.Random random = new System.Random();
      if (Mission == 1)
      {
        position2 = this.MCSubLocMeth[this.MethMCbusinessLoc].SupplyTruckSpawn;
        heading = this.MCSubLocMeth[this.MethMCbusinessLoc].SupplyTruckHeading;
        this.Supplies = this.MethLab_ProductBags;
        if (this.Supplies < 25)
          this.MaxCounted = 1;
        if (this.Supplies > 25 && this.Supplies <= 50)
          this.MaxCounted = 2;
        if (this.Supplies > 50 && this.Supplies <= 75)
          this.MaxCounted = 3;
        if (this.Supplies > 75 && this.Supplies <= 100)
          this.MaxCounted = 4;
      }
      if (Mission == 2)
      {
        position2 = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].SupplyTruckSpawn;
        heading = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].SupplyTruckHeading;
        this.Supplies = this.CocaineLockup_ProductBags;
        if (this.Supplies < 25)
          this.MaxCounted = 1;
        if (this.Supplies > 25 && this.Supplies <= 50)
          this.MaxCounted = 2;
        if (this.Supplies > 50 && this.Supplies <= 75)
          this.MaxCounted = 3;
        if (this.Supplies > 75 && this.Supplies <= 100)
          this.MaxCounted = 4;
      }
      if (Mission == 3)
      {
        position2 = this.MCSubLocWeed[this.WeedMCbusinessLoc].SupplyTruckSpawn;
        heading = this.MCSubLocWeed[this.WeedMCbusinessLoc].SupplyTruckHeading;
        this.Supplies = this.WeedFarm_ProductBags;
        if (this.Supplies < 25)
          this.MaxCounted = 1;
        if (this.Supplies > 25 && this.Supplies <= 50)
          this.MaxCounted = 2;
        if (this.Supplies > 50 && this.Supplies <= 75)
          this.MaxCounted = 3;
        if (this.Supplies > 75 && this.Supplies <= 100)
          this.MaxCounted = 4;
      }
      if (Mission == 4)
      {
        position2 = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].SupplyTruckSpawn;
        heading = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].SupplyTruckHeading;
        this.Supplies = this.CounterfeitOffice_ProductBags;
        if (this.Supplies < 25)
          this.MaxCounted = 1;
        if (this.Supplies > 25 && this.Supplies <= 50)
          this.MaxCounted = 2;
        if (this.Supplies > 50 && this.Supplies <= 75)
          this.MaxCounted = 3;
        if (this.Supplies > 75 && this.Supplies <= 100)
          this.MaxCounted = 4;
      }
      if (Mission == 5)
      {
        position2 = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].SupplyTruckSpawn;
        heading = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].SupplyTruckHeading;
        this.Supplies = this.DocumentForgery_ProductBags;
        if (this.Supplies < 25)
          this.MaxCounted = 1;
        if (this.Supplies > 25 && this.Supplies <= 50)
          this.MaxCounted = 2;
        if (this.Supplies > 50 && this.Supplies <= 75)
          this.MaxCounted = 3;
        if (this.Supplies > 75 && this.Supplies <= 100)
          this.MaxCounted = 4;
      }
      if (Mission == 1)
      {
        destination = vector3_3.Around((float) random.Next(150, 2000));
        position1 = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position1 = origin;
          }
        }
      }
      if (Mission == 2)
      {
        destination = vector3_3.Around((float) random.Next(150, 2000));
        position1 = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position1 = origin;
          }
        }
      }
      if (Mission == 3)
      {
        destination = vector3_3.Around((float) random.Next(150, 2000));
        position1 = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position1 = origin;
          }
        }
      }
      if (Mission == 4)
      {
        destination = vector3_3.Around((float) random.Next(150, 2000));
        position1 = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position1 = origin;
          }
        }
      }
      if (Mission == 5)
      {
        destination = vector3_3.Around((float) random.Next(150, 2000));
        position1 = destination;
        float num = 1E+07f;
        foreach (Vector3 origin in this.DropPoint)
        {
          if ((double) World.GetDistance(origin, destination) < (double) num)
          {
            num = World.GetDistance(origin, destination);
            position1 = origin;
          }
        }
      }
      foreach (Ped ped in this.Gang)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if (this.Gang.Count > 0)
        this.Gang.Clear();
      foreach (Vehicle gangVehicle in this.GangVehicles)
      {
        if ((Entity) gangVehicle != (Entity) null)
          gangVehicle.Delete();
      }
      if (this.GangVehicles.Count > 0)
        this.GangVehicles.Clear();
      foreach (Ped suppyGuard in this.SuppyGuards)
      {
        if ((Entity) suppyGuard != (Entity) null)
          suppyGuard.Delete();
      }
      if (this.SuppyGuards.Count > 0)
        this.SuppyGuards.Clear();
      if ((Entity) this.PropItem_SetupMission != (Entity) null)
        this.PropItem_SetupMission.Delete();
      if (this.BlipItem_SetupMission != (Blip) null)
        this.BlipItem_SetupMission.Remove();
      if ((Entity) this.VehicleItem_SetupMission != (Entity) null)
        this.VehicleItem_SetupMission.Delete();
      if (this.MCBusinessLocBlips.Count > 0)
      {
        foreach (Blip mcBusinessLocBlip in this.MCBusinessLocBlips)
        {
          if (mcBusinessLocBlip != (Blip) null)
            mcBusinessLocBlip.Remove();
        }
      }
      if (this.MCBusinessLocBlips.Count > 0)
        this.MCBusinessLocBlips.Clear();
      if (this.supplySellProps.Count > 0)
      {
        foreach (Prop supplySellProp in this.supplySellProps)
        {
          if ((Entity) supplySellProp != (Entity) null)
            supplySellProp.Delete();
        }
      }
      if (this.supplySellProps.Count > 0)
        this.supplySellProps.Clear();
      if (this.supplySellVehicles.Count > 0)
      {
        foreach (Vehicle supplySellVehicle in this.supplySellVehicles)
        {
          if ((Entity) supplySellVehicle != (Entity) null)
            supplySellVehicle.Delete();
        }
      }
      if (this.supplySellVehicles.Count > 0)
        this.supplySellVehicles.Clear();
      Script.Wait(500);
      this.SellPoint = position1;
      this.BlipItem_SetupMission = World.CreateBlip(position1);
      this.BlipItem_SetupMission.Sprite = BlipSprite.SpecialCargo;
      this.BlipItem_SetupMission.Color = BlipColor.Yellow;
      this.BlipItem_SetupMission.Name = "Deliver Product";
      this.BlipItem_SetupMission.IsShortRange = true;
      this.MaxCounted = 3;
      if (this.MaxCounted == 1)
      {
        int num = random.Next(0, 500);
        if (num >= 0 && num <= 100)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 2f, 0.0f)), heading));
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num > 100 && num <= 200)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Dune), position2, heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 200 && num <= 300)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.RatLoader2), position2, heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num > 300 && num <= 400)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Mule), position2, heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num > 400 && num <= 500)
        {
          Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), position2, heading);
          this.supplySellVehicles.Add(vehicle);
          Vector3 offsetInWorldCoords = vehicle.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords, new Vector3(0.0f, 0.0f, vehicle.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle, true);
          vehicle.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
      }
      if (this.MaxCounted == 2)
      {
        int num = random.Next(0, 500);
        if (num >= 0 && num <= 100)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 4f, 0.0f)), heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), this.supplySellVehicles[1].GetOffsetInWorldCoords(new Vector3(3f, 0.0f, 0.0f)), heading));
          this.VehiclesToDeliver = 3;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = this.supplySellVehicles[2];
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 100 && num <= 200)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Dune), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Dune), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 5f, 0.0f)), heading));
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num > 200 && num <= 300)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.RatLoader2), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.RatLoader2), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 5f, 0.0f)), heading));
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num > 300 && num <= 400)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Mule), position2, heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num > 400 && num <= 500)
        {
          Vehicle vehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), position2, heading);
          this.supplySellVehicles.Add(vehicle1);
          Vehicle vehicle2 = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 7f, 0.0f)), heading);
          this.supplySellVehicles.Add(vehicle2);
          Vector3 offsetInWorldCoords1 = vehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, vehicle1.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle1, true);
          vehicle1.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          Vector3 offsetInWorldCoords2 = vehicle2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, vehicle2.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle2, true);
          vehicle2.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
      }
      if (this.MaxCounted == 3)
      {
        int num = random.Next(0, 600);
        if (num >= 0 && num <= 100)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 4f, 0.0f)), heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), this.supplySellVehicles[1].GetOffsetInWorldCoords(new Vector3(3f, 0.0f, 0.0f)), heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Bagger), this.supplySellVehicles[1].GetOffsetInWorldCoords(new Vector3(3f, -4f, 0.0f)), heading));
          this.VehiclesToDeliver = 4;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = this.supplySellVehicles[2];
          this.DeliverVehicle_4 = this.supplySellVehicles[3];
        }
        if (num >= 100 && num <= 200)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Dune), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Dune), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 5f, 0.0f)), heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 200 && num <= 300)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Mule), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Mule), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 10f, 0.0f)), heading));
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 300 && num <= 400)
        {
          Vehicle vehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), position2, heading);
          this.supplySellVehicles.Add(vehicle1);
          Vehicle vehicle2 = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 7f, 0.0f)), heading);
          this.supplySellVehicles.Add(vehicle2);
          Vector3 offsetInWorldCoords1 = vehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, vehicle1.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle1, true);
          vehicle1.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          Vector3 offsetInWorldCoords2 = vehicle2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, vehicle2.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle2, true);
          vehicle2.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 400 && num <= 500)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Pounder), position2, heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 500 && num <= 600)
        {
          Vehicle vehicle = World.CreateVehicle(this.RequestModel(VehicleHash.Boxville), position2, heading);
          this.supplySellVehicles.Add(vehicle);
          Vector3 offsetInWorldCoords = vehicle.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords, new Vector3(0.0f, 0.0f, vehicle.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle, true);
          vehicle.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
      }
      if (this.MaxCounted == 4)
      {
        int num = random.Next(0, 400);
        if (num >= 0 && num <= 100)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Mule), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Mule), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 10f, 0.0f)), heading));
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 100 && num <= 200)
        {
          Vehicle vehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), position2, heading);
          this.supplySellVehicles.Add(vehicle1);
          Vehicle vehicle2 = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 7f, 0.0f)), heading);
          this.supplySellVehicles.Add(vehicle2);
          Vector3 offsetInWorldCoords1 = vehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, vehicle1.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle1, true);
          vehicle1.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          Vector3 offsetInWorldCoords2 = vehicle2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, vehicle2.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle2, true);
          vehicle2.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 200 && num <= 300)
        {
          Vehicle vehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.Boxville), position2, heading);
          this.supplySellVehicles.Add(vehicle1);
          Vehicle vehicle2 = World.CreateVehicle(this.RequestModel(VehicleHash.Boxville), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 7f, 0.0f)), heading);
          this.supplySellVehicles.Add(vehicle2);
          Vector3 offsetInWorldCoords1 = vehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, vehicle1.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle1, true);
          vehicle1.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          Vector3 offsetInWorldCoords2 = vehicle2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, vehicle2.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle2, true);
          vehicle2.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 300 && num <= 400)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Trash), position2, heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
      }
      if (this.MaxCounted == 5)
      {
        int num = random.Next(0, 400);
        if (num >= 0 && num <= 100)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Mule), position2, heading));
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Mule), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 10f, 0.0f)), heading));
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 100 && num <= 200)
        {
          Vehicle vehicle1 = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), position2, heading);
          this.supplySellVehicles.Add(vehicle1);
          Vehicle vehicle2 = World.CreateVehicle(this.RequestModel(VehicleHash.GBurrito2), this.supplySellVehicles[0].GetOffsetInWorldCoords(new Vector3(0.0f, 7f, 0.0f)), heading);
          this.supplySellVehicles.Add(vehicle2);
          Vector3 offsetInWorldCoords1 = vehicle1.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, vehicle1.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle1, true);
          vehicle1.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          Vector3 offsetInWorldCoords2 = vehicle2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, -0.2f));
          this.PropItem_SetupMission = World.CreateProp(this.RequestModel("ex_prop_crate_closed_bc"), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, vehicle2.Heading), false, false);
          this.PropItem_SetupMission.HasCollision = false;
          this.PropItem_SetupMission.SetNoCollision((Entity) vehicle2, true);
          vehicle2.SetNoCollision((Entity) this.PropItem_SetupMission, true);
          this.supplySellProps.Add(this.PropItem_SetupMission);
          this.VehiclesToDeliver = 2;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = this.supplySellVehicles[1];
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 200 && num <= 300)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Pounder), position2, heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
        if (num >= 300 && num <= 400)
        {
          this.supplySellVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Trash), position2, heading));
          this.VehiclesToDeliver = 1;
          this.DeliverVehicle_1 = this.supplySellVehicles[0];
          this.DeliverVehicle_2 = (Vehicle) null;
          this.DeliverVehicle_3 = (Vehicle) null;
          this.DeliverVehicle_4 = (Vehicle) null;
        }
      }
      if (this.supplySellVehicles.Count > 0)
      {
        foreach (Vehicle supplySellVehicle in this.supplySellVehicles)
        {
          if ((Entity) supplySellVehicle != (Entity) null)
          {
            supplySellVehicle.AddBlip();
            supplySellVehicle.CurrentBlip.Sprite = BlipSprite.Package2;
            supplySellVehicle.CurrentBlip.Color = BlipColor.Blue;
            supplySellVehicle.CurrentBlip.Name = "Deliver Product Vehicle";
            supplySellVehicle.CurrentBlip.IsShortRange = true;
            supplySellVehicle.CurrentBlip.Scale = 0.8f;
          }
        }
      }
      UI.Notify("Sell Mission Active " + this.mission.ToString());
      this.MissionNum = 11;
      this.MissionOn = true;
    }

    public void UpdateStatProps()
    {
      if ((Entity) this.Pallet1 != (Entity) null)
        this.Pallet1.Delete();
      if ((Entity) this.Pallet2 != (Entity) null)
        this.Pallet2.Delete();
      if ((Entity) this.Pallet3 != (Entity) null)
        this.Pallet3.Delete();
      if ((Entity) this.Pallet4 != (Entity) null)
        this.Pallet4.Delete();
      if ((Entity) this.Pallet5 != (Entity) null)
        this.Pallet5.Delete();
      if ((Entity) this.Pallet6 != (Entity) null)
        this.Pallet6.Delete();
      if ((Entity) this.Pallet7 != (Entity) null)
        this.Pallet7.Delete();
      if ((Entity) this.Pallet8 != (Entity) null)
        this.Pallet8.Delete();
      if ((Entity) this.Pallet9 != (Entity) null)
        this.Pallet9.Delete();
      if ((Entity) this.Pallet10 != (Entity) null)
        this.Pallet10.Delete();
      if (this.GI() == this.CocaineLockupId)
      {
        if ((Entity) this.Pallet1 != (Entity) null)
          this.Pallet1.Delete();
        if ((Entity) this.Pallet2 != (Entity) null)
          this.Pallet2.Delete();
        if ((Entity) this.Pallet3 != (Entity) null)
          this.Pallet3.Delete();
        if ((Entity) this.Pallet4 != (Entity) null)
          this.Pallet4.Delete();
        if ((Entity) this.Pallet5 != (Entity) null)
          this.Pallet5.Delete();
        if ((Entity) this.Pallet6 != (Entity) null)
          this.Pallet6.Delete();
        if ((Entity) this.Pallet7 != (Entity) null)
          this.Pallet7.Delete();
        if ((Entity) this.Pallet8 != (Entity) null)
          this.Pallet8.Delete();
        if ((Entity) this.Pallet9 != (Entity) null)
          this.Pallet9.Delete();
        if ((Entity) this.Pallet10 != (Entity) null)
          this.Pallet10.Delete();
        this.Pallet1 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), new Vector3(1103.091f, -3195.116f, -39.9f), new Vector3(0.0f, 0.0f, -90f), false, false);
        this.Pallet2 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(2f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, -90f), false, false);
        this.GottenProps = true;
      }
      if (this.GI() == this.WeedFarmId)
      {
        if ((Entity) this.Pallet1 != (Entity) null)
          this.Pallet1.Delete();
        if ((Entity) this.Pallet2 != (Entity) null)
          this.Pallet2.Delete();
        if ((Entity) this.Pallet3 != (Entity) null)
          this.Pallet3.Delete();
        if ((Entity) this.Pallet4 != (Entity) null)
          this.Pallet4.Delete();
        if ((Entity) this.Pallet5 != (Entity) null)
          this.Pallet5.Delete();
        if ((Entity) this.Pallet6 != (Entity) null)
          this.Pallet6.Delete();
        if ((Entity) this.Pallet7 != (Entity) null)
          this.Pallet7.Delete();
        if ((Entity) this.Pallet8 != (Entity) null)
          this.Pallet8.Delete();
        if ((Entity) this.Pallet9 != (Entity) null)
          this.Pallet9.Delete();
        if ((Entity) this.Pallet10 != (Entity) null)
          this.Pallet10.Delete();
        foreach (Prop nearbyProp in World.GetNearbyProps(new Vector3(1041f, -3196.596f, -40f), 20f, (Model) "bkr_prop_coke_pallet_01a"))
        {
          if ((Entity) nearbyProp != (Entity) null)
            nearbyProp.Delete();
        }
        this.Pallet1 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), new Vector3(1039.643f, -3199.073f, -39.1f), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.Pallet2 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(2f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.Pallet3 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), new Vector3(1044.747f, -3198.6f, -39.1f), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.Pallet4 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), new Vector3(1039.503f, -3192.783f, -39.1f), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.Pallet5 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), new Vector3(1040.132f, -3194.906f, -39f), new Vector3(0.0f, 0.0f, 70f), false, false);
        this.Pallet6 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), this.Pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f)), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.Pallet7 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), this.Pallet6.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f)), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.Pallet8 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), this.Pallet7.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f)), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.Pallet9 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), new Vector3(1043.27f, -3200.721f, -39.1f), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.Pallet10 = World.CreateProp(this.RequestModel("bkr_prop_coke_pallet_01a"), new Vector3(1040.289f, -3201.064f, -39.1f), new Vector3(0.0f, 0.0f, 90f), false, false);
        this.GottenProps = true;
      }
      if (this.GI() == this.CounterfeitOfficeId)
      {
        if ((Entity) this.Pallet1 != (Entity) null)
          this.Pallet1.Delete();
        if ((Entity) this.Pallet2 != (Entity) null)
          this.Pallet2.Delete();
        if ((Entity) this.Pallet3 != (Entity) null)
          this.Pallet3.Delete();
        if ((Entity) this.Pallet4 != (Entity) null)
          this.Pallet4.Delete();
        if ((Entity) this.Pallet5 != (Entity) null)
          this.Pallet5.Delete();
        if ((Entity) this.Pallet6 != (Entity) null)
          this.Pallet6.Delete();
        if ((Entity) this.Pallet7 != (Entity) null)
          this.Pallet7.Delete();
        if ((Entity) this.Pallet8 != (Entity) null)
          this.Pallet8.Delete();
        if ((Entity) this.Pallet9 != (Entity) null)
          this.Pallet9.Delete();
        if ((Entity) this.Pallet10 != (Entity) null)
          this.Pallet10.Delete();
        this.Pallet1 = World.CreateProp(this.RequestModel("bkr_prop_cashtrolley_01a"), new Vector3(1117.611f, -3193.33f, -41.4f), new Vector3(0.0f, 0.0f, 0.0f), false, false);
        this.Pallet2 = World.CreateProp(this.RequestModel("bkr_prop_cashtrolley_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(1.3f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false);
        this.Pallet3 = World.CreateProp(this.RequestModel("bkr_prop_cashtrolley_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(1.3f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false);
        this.Pallet4 = World.CreateProp(this.RequestModel("bkr_prop_cashtrolley_01a"), new Vector3(1121.14f, -3194.461f, -41.4f), new Vector3(0.0f, 0.0f, -36f), false, false);
        this.Pallet5 = World.CreateProp(this.RequestModel("bkr_prop_cashtrolley_01a"), new Vector3(1121.939f, -3198.426f, -41.4f), new Vector3(0.0f, 0.0f, 166f), false, false);
        this.GottenProps = true;
      }
      if (this.GI() == this.CocaineLockupId)
      {
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 10.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-0.4f, 0.2f, 0.3f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 20.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.4f, 0.2f, 0.3f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 30.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-0.4f, 0.2f, 0.6f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 40.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.4f, 0.2f, 0.6f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 50.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.2f, 0.9f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 60.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(-0.4f, 0.2f, 0.3f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 70.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.4f, 0.2f, 0.3f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 80.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(-0.4f, 0.2f, 0.6f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 >= 90.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.4f, 0.2f, 0.6f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
        if ((double) this.CocaineLockup_ProductBags / (double) this.CocaineLockup_ProductMax * 100.0 == 100.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_coke_block_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.2f, 0.9f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      }
      if (this.GI() == this.WeedFarmId)
      {
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 10.0)
        {
          float heading = this.Pallet1.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 20.0)
        {
          float heading = this.Pallet2.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 30.0)
        {
          float heading = this.Pallet3.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet3.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 40.0)
        {
          float heading = this.Pallet4.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet4.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 50.0)
        {
          float heading = this.Pallet5.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet5.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 60.0)
        {
          float heading = this.Pallet6.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet6.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 70.0)
        {
          float heading = this.Pallet7.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet7.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 80.0)
        {
          float heading = this.Pallet8.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet8.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 90.0)
        {
          float heading = this.Pallet9.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet9.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
        if ((double) this.WeedFarm_ProductBags / (double) this.WeedFarm_ProductMax * 100.0 >= 100.0)
        {
          float heading = this.Pallet10.Heading;
          Prop prop1 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), this.Pallet10.GetOffsetInWorldCoords(new Vector3(-0.3f, 0.3f, 0.25f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop1);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          Prop prop2 = World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false);
          this.MCBusinessSupplies.Add(prop2);
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.0f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop1.GetOffsetInWorldCoords(new Vector3(0.5f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_weed_bigbag_01a"), prop2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.7f, 0.3f)), new Vector3(0.0f, 0.0f, heading), false, false));
        }
      }
      if (this.GI() == this.MethLabId)
      {
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 5.0)
        {
          this.Pallet1 = World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), new Vector3(1018.158f, -3197.751f, -39.9f), new Vector3(0.0f, 0.0f, -90f), false, false);
          this.MCBusinessSupplies.Add(this.Pallet1);
        }
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 10.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 15.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 20.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 25.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 1.2f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 30.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 1.2f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 35.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 1.8f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 40.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 1.8f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 45.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 2.4f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 50.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 2.4f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 55.0)
        {
          this.Pallet2 = World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(2.2f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, -90f), false, false);
          this.MCBusinessSupplies.Add(this.Pallet2);
        }
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 60.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 65.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 70.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 75.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 1.2f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 80.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 1.2f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 85.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 1.8f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 90.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 1.8f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 95.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 2.4f)), new Vector3(0.0f, 0.0f, -90f), false, false));
        if ((double) this.MethLab_ProductBags / (double) this.MethLab_ProductMax * 100.0 >= 100.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_meth_bigbag_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.9f, 0.0f, 2.4f)), new Vector3(0.0f, 0.0f, -90f), false, false));
      }
      if (this.GI() == this.CounterfeitOfficeId)
      {
        foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
        {
          if ((Entity) mcBusinessSupply != (Entity) null)
            mcBusinessSupply.Delete();
        }
        if (this.MCBusinessSupplies.Count > 0)
          this.MCBusinessSupplies.Clear();
        Prop pallet1 = this.Pallet1;
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 2.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.2f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 4.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.25f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 6.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 8.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.35f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 10.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.4f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 12.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.45f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 14.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.5f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 16.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.55f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 18.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 20.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.65f)), new Vector3(0.0f, 0.0f, pallet1.Heading), false, false));
        Prop pallet2 = this.Pallet2;
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 22.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.2f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 24.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.25f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 26.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 28.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.35f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 30.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.4f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 32.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.45f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 34.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.5f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 36.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.55f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 38.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 40.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.65f)), new Vector3(0.0f, 0.0f, pallet2.Heading), false, false));
        Prop pallet3 = this.Pallet3;
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 42.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.2f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 44.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.25f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 46.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 48.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.35f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 50.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.4f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 52.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.45f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 54.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.5f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 56.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.55f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 58.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 60.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet3.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.65f)), new Vector3(0.0f, 0.0f, pallet3.Heading), false, false));
        Prop pallet4 = this.Pallet4;
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 62.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.2f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 64.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.25f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 66.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 68.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.35f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 70.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.4f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 72.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.45f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 74.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.5f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 76.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.55f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 78.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 80.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet4.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.65f)), new Vector3(0.0f, 0.0f, pallet4.Heading), false, false));
        Prop pallet5 = this.Pallet5;
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 82.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.2f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 84.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.25f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 86.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.3f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 88.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.35f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 90.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.4f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 92.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.45f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 94.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.5f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 96.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.55f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 98.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.6f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
        if ((double) this.CounterfeitOffice_ProductBags / (double) this.CounterfeitOffice_ProductMax * 100.0 >= 100.0)
          this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_moneypack_02a"), pallet5.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.65f)), new Vector3(0.0f, 0.0f, pallet5.Heading), false, false));
      }
      if (this.GI() != this.DocumentForgeryId)
        return;
      foreach (Prop mcBusinessSupply in this.MCBusinessSupplies)
      {
        if ((Entity) mcBusinessSupply != (Entity) null)
          mcBusinessSupply.Delete();
      }
      if (this.MCBusinessSupplies.Count > 0)
        this.MCBusinessSupplies.Clear();
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 1.0)
      {
        this.Pallet1 = World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), new Vector3(1163.77f, -3190.077f, -39.9f), new Vector3(0.0f, 0.0f, 0.0f), false, false);
        this.MCBusinessSupplies.Add(this.Pallet1);
      }
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 2.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-0.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 4.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-1f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 5.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-1.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 7.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-2f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 8.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-3f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 10.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-3.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 12.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-4f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 13.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-4.5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 15.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-5f, 0.0f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      float z1 = 0.6f;
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 17.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 18.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-0.5f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 20.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-1f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 22.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-1.5f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 25.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-2f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 27.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-3f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 29.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-3.5f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 30.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-4f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 31.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-4.5f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 32.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-5f, 0.0f, z1)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      float z2 = 1.2f;
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 33.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 35.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-0.5f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 37.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-1f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 39.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-1.5f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 40.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-2f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 42.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-3f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 44.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-3.5f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 46.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-4f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 47.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-4.5f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 49.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-5f, 0.0f, z2)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      float z3 = 1.75f;
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 51.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 53.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-0.5f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 55.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-1f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 57.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-1.5f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 59.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-2f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 61.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-3f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 63.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-3.5f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 64.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-4f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 66.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-4.5f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 68.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet1.GetOffsetInWorldCoords(new Vector3(-5f, 0.0f, z3)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 70.0)
      {
        this.Pallet2 = World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), new Vector3(1157.038f, -3190.031f, -39.9f), new Vector3(0.0f, 0.0f, 0.0f), false, false);
        this.MCBusinessSupplies.Add(this.Pallet2);
      }
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 72.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 73.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -1f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 75.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 77.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      float z4 = 0.6f;
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 79.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, z4)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 80.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, z4)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 82.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -1f, z4)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 84.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, z4)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 86.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, z4)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      float z5 = 1.2f;
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 87.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, z5)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 89.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, z5)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 90.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -1f, z5)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 91.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, z5)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 92.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, z5)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      float z6 = 1.8f;
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 94.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, z6)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 96.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -0.5f, z6)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 97.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -1f, z6)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 99.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -1.5f, z6)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
      if ((double) this.DocumentForgery_ProductBags / (double) this.DocumentForgery_ProductMax * 100.0 >= 100.0)
        this.MCBusinessSupplies.Add(World.CreateProp(this.RequestModel("bkr_prop_fakeid_boxdriverl_01a"), this.Pallet2.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, z6)), new Vector3(0.0f, 0.0f, 0.0f), false, false));
    }

    public void SetupRaid(int RaidTypeMission)
    {
      this.RaidType = RaidTypeMission;
      int num = new System.Random().Next(0, 100);
      if (num >= 60)
        this.RaidEnemyTime = 1;
      if (num < 59)
        this.RaidEnemyTime = 0;
      this.WaitingForRaid = false;
      if (this.MethBlip != (Blip) null)
        this.MethBlip.Remove();
      if (this.CocaineBlip != (Blip) null)
        this.CocaineBlip.Remove();
      if (this.WeedBlip != (Blip) null)
        this.WeedBlip.Remove();
      if (this.MoneyForgeBlip != (Blip) null)
        this.MoneyForgeBlip.Remove();
      if (this.FakeIDBlip != (Blip) null)
        this.FakeIDBlip.Remove();
      this.CurrentTime = this.GetHour();
      this.RaidHour = this.CurrentTime + 8;
      if (this.RaidHour + 1 < 24)
        this.RaidHour = this.GetHour() + 8;
      else if (this.RaidHour + 1 == 24)
        this.RaidHour = 8;
      else if (this.RaidHour == 0)
        this.RaidHour = 8;
      if (this.RaidType == 1)
      {
        if (this.BlipItem_SetupMission != (Blip) null)
          this.BlipItem_SetupMission.Remove();
        this.BlipItem_SetupMission = World.CreateBlip(this.MCSubLocMeth[this.MethMCbusinessLoc].Enterance);
        this.BlipItem_SetupMission.Sprite = BlipSprite.Joust;
        this.BlipItem_SetupMission.Color = this.Blip_Colour;
        this.BlipItem_SetupMission.Name = "Business Raid";
        this.BlipItem_SetupMission.Scale = 2f;
        SecondBusiness.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Meth Lab", "Our business is under attack!, you have 8 hours to respond");
      }
      if (this.RaidType == 2)
      {
        if (this.BlipItem_SetupMission != (Blip) null)
          this.BlipItem_SetupMission.Remove();
        this.BlipItem_SetupMission = World.CreateBlip(this.MCSubLocCocaine[this.CocaineMCbusinessLoc].Enterance);
        this.BlipItem_SetupMission.Sprite = BlipSprite.Joust;
        this.BlipItem_SetupMission.Color = this.Blip_Colour;
        this.BlipItem_SetupMission.Name = "Business Raid";
        this.BlipItem_SetupMission.Scale = 2f;
        SecondBusiness.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Cocaine Lockup", "Our business is under attack!, you have 8 hours to respond");
      }
      if (this.RaidType == 3)
      {
        if (this.BlipItem_SetupMission != (Blip) null)
          this.BlipItem_SetupMission.Remove();
        this.BlipItem_SetupMission = World.CreateBlip(this.MCSubLocWeed[this.WeedMCbusinessLoc].Enterance);
        this.BlipItem_SetupMission.Sprite = BlipSprite.Joust;
        this.BlipItem_SetupMission.Color = this.Blip_Colour;
        this.BlipItem_SetupMission.Name = "Business Raid";
        this.BlipItem_SetupMission.Scale = 2f;
        SecondBusiness.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Weed Farm", "Our business is under attack!, you have 8 hours to respond");
      }
      if (this.RaidType == 4)
      {
        if (this.BlipItem_SetupMission != (Blip) null)
          this.BlipItem_SetupMission.Remove();
        this.BlipItem_SetupMission = World.CreateBlip(this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].Enterance);
        this.BlipItem_SetupMission.Sprite = BlipSprite.Joust;
        this.BlipItem_SetupMission.Color = this.Blip_Colour;
        this.BlipItem_SetupMission.Name = "Business Raid";
        this.BlipItem_SetupMission.Scale = 2f;
        SecondBusiness.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Counterfiet Office", "Our business is under attack!, you have 8 hours to respond");
      }
      if (this.RaidType == 5)
      {
        if (this.BlipItem_SetupMission != (Blip) null)
          this.BlipItem_SetupMission.Remove();
        this.BlipItem_SetupMission = World.CreateBlip(this.MCSubLocForgery[this.ForgeryMCbusinessLoc].Enterance);
        this.BlipItem_SetupMission.Sprite = BlipSprite.Joust;
        this.BlipItem_SetupMission.Color = this.Blip_Colour;
        this.BlipItem_SetupMission.Name = "Business Raid";
        this.BlipItem_SetupMission.Scale = 2f;
        SecondBusiness.TextNotification("CHAR_LESTER", ("~g~ " + this.GetHostName()).ToString(), "Document Forgery", "Our business is under attack!, you have 8 hours to respond");
      }
      if (this.WeedFarmBought == 1)
      {
        this.WeedBlip = World.CreateBlip(this.WeedFarmExit);
        this.WeedBlip.Sprite = BlipSprite.Weed;
        this.WeedBlip.Color = this.Blip_Colour;
        this.WeedBlip.Name = this.MCSubLocWeed[this.WeedMCbusinessLoc].Name + " " + this.MCSubLocWeed[this.WeedMCbusinessLoc].TypeName;
        this.WeedBlip.IsShortRange = true;
      }
      if (this.MoneyPrinterBought == 1)
      {
        this.MoneyForgeBlip = World.CreateBlip(this.MoneyPrinterExit);
        this.MoneyForgeBlip.Sprite = BlipSprite.DollarBill;
        this.MoneyForgeBlip.Color = this.Blip_Colour;
        this.MoneyForgeBlip.Name = this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].Name + " " + this.MCSubLocCounterfiet[this.CounterfietMCbusinessLoc].TypeName;
        this.MoneyForgeBlip.IsShortRange = true;
      }
      if (this.ForgeryBought == 1)
      {
        this.FakeIDBlip = World.CreateBlip(this.ForgeryExit);
        this.FakeIDBlip.Sprite = BlipSprite.IdentityCard;
        this.FakeIDBlip.Color = this.Blip_Colour;
        this.FakeIDBlip.Name = this.MCSubLocForgery[this.ForgeryMCbusinessLoc].Name + " " + this.MCSubLocForgery[this.ForgeryMCbusinessLoc].TypeName;
        this.FakeIDBlip.IsShortRange = true;
      }
      if (this.MethLabBought == 1)
      {
        this.MethBlip = World.CreateBlip(this.MethLabExit);
        this.MethBlip.Sprite = BlipSprite.Meth;
        this.MethBlip.Color = this.Blip_Colour;
        this.MethBlip.Name = this.MCSubLocMeth[this.MethMCbusinessLoc].Name + " " + this.MCSubLocMeth[this.MethMCbusinessLoc].TypeName;
        this.MethBlip.IsShortRange = true;
      }
      if (this.CocaineBought == 1)
      {
        this.CocaineBlip = World.CreateBlip(this.CocaineExit);
        this.CocaineBlip.Sprite = BlipSprite.Cocaine;
        this.CocaineBlip.Color = this.Blip_Colour;
        this.CocaineBlip.Name = this.MCSubLocCocaine[this.CocaineMCbusinessLoc].Name + " " + this.MCSubLocCocaine[this.CocaineMCbusinessLoc].TypeName;
        this.CocaineBlip.IsShortRange = true;
      }
      this.MissionOn = true;
      this.MissionNum = 12;
    }

    public void OnTick(object sender, EventArgs e)
    {
      // ISSUE: The method is too long to display (88348 instructions)
    }

    private void SubBusinesRaids(UIMenu Menu)
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(Menu, "Sub Business Raids");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Loc1 = new UIMenuItem("Defend LS Subbusiness | Hard |");
      uiMenu.AddItem(Loc1);
      UIMenuItem Loc2 = new UIMenuItem("Defend Cocaine Lab | Medium |");
      uiMenu.AddItem(Loc2);
      UIMenuItem Loc3 = new UIMenuItem("Defend Meth Lab | Medium |");
      uiMenu.AddItem(Loc3);
      UIMenuItem Loc4 = new UIMenuItem("Defend Weed Farm | Medium |");
      uiMenu.AddItem(Loc4);
      UIMenuItem Loc5 = new UIMenuItem("Defend Money Forgery | Easy |");
      uiMenu.AddItem(Loc5);
      UIMenuItem Loc6 = new UIMenuItem("Defend Fake ID forgery | Easy |");
      uiMenu.AddItem(Loc6);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Loc1)
        {
          this.RaidSetup = true;
          this.isAtSubBusiness = true;
          this.mission = 1;
          UI.Notify(this.GetHostName() + " boss quickly get to our sub business, we are expecting to be raided by the gangs of Los Santos");
        }
        if (item == Loc2)
        {
          this.RaidSetup = true;
          this.isAtSubBusiness = true;
          this.mission = 2;
          UI.Notify(this.GetHostName() + " boss quickly get to our sub business, we are expecting to be raided by the gangs of Los Santos");
        }
        if (item == Loc3)
        {
          this.RaidSetup = true;
          this.isAtSubBusiness = true;
          this.mission = 3;
          UI.Notify(this.GetHostName() + " boss quickly get to our sub business, we are expecting to be raided by the gangs of Los Santos");
        }
        if (item == Loc4)
        {
          this.RaidSetup = true;
          this.isAtSubBusiness = true;
          this.mission = 4;
          UI.Notify(this.GetHostName() + " boss quickly get to our sub business, we are expecting to be raided by the gangs of Los Santos");
        }
        if (item == Loc5)
        {
          this.RaidSetup = true;
          this.isAtSubBusiness = true;
          this.mission = 5;
          UI.Notify(this.GetHostName() + " boss quickly get to our sub business, we are expecting to be raided by the gangs of Los Santos");
        }
        if (item != Loc6)
          return;
        this.RaidSetup = true;
        this.isAtSubBusiness = true;
        this.mission = 6;
        UI.Notify(this.GetHostName() + " boss quickly get to our sub business, we are expecting to be raided by the gangs of Los Santos");
      });
    }

    public class MCBusinessLocations : Script
    {
      public int TypeNo { get; set; }

      public string TypeName { get; set; }

      public Vector3 Enterance { get; set; }

      public float EnteranceHeading { get; set; }

      public string DoorEnter { get; set; }

      public Vector3 SupplyTruckSpawn { get; set; }

      public float SupplyTruckHeading { get; set; }

      public float Price { get; set; }

      public new string Name { get; set; }

      public Vector3 CameraPos { get; set; }

      public float CameraHeading { get; set; }

      public MCBusinessLocations(
        int TI,
        string TN,
        Vector3 E,
        float EH,
        string DE,
        Vector3 STS,
        float STH,
        float P,
        string N,
        Vector3 CP,
        float CH)
      {
        this.TypeNo = TI;
        this.TypeName = TN;
        this.Enterance = E;
        this.DoorEnter = DE;
        this.EnteranceHeading = EH;
        this.SupplyTruckSpawn = STS;
        this.SupplyTruckHeading = STH;
        this.Price = P;
        this.Name = N;
        this.CameraPos = CP;
        this.CameraHeading = CH;
      }
    }

    public class PedSpawn : Script
    {
      public Vector3 Spawn { get; set; }

      public float Heading { get; set; }

      public int Scene { get; set; }

      public PedSpawn()
      {
      }

      public PedSpawn(Vector3 P, float S)
      {
        this.Spawn = P;
        this.Heading = S;
      }
    }

    public class PedaSyncronisedScene : Script
    {
      public Ped Ped { get; set; }

      public Prop Prop { get; set; }

      public int Scene { get; set; }

      public PedaSyncronisedScene()
      {
      }

      public PedaSyncronisedScene(Ped P, int S)
      {
        this.Ped = P;
        this.Scene = S;
      }

      public PedaSyncronisedScene(Ped P, int S, Prop Pr)
      {
        this.Ped = P;
        this.Scene = S;
        this.Prop = Pr;
      }
    }
  }
}
