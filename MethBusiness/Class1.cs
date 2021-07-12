using GTA;
using GTA.Math;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MethBuisness
{
  public class Class1 : Script
  {
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public BlipColor Safehouse_Colour;
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    public Color SafehouseMColor;
    public string SafehouseMColorString;
    private ScriptSettings MainConfigFile;
    private bool firstTime = true;
    private string ModName = "Biker Business";
    private string Developer = "HKH191";
    private string Version = "1";
    private ScriptSettings Config;
    private Keys Key1;
    public Vector3 BuyMarker;
    public Vector3 BuyMarker2;
    public int num;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private UIMenu methgarage;
    private UIMenu BikesGarage;
    private UIMenu WeaponsShop;
    private UIMenu ProductStock;
    private UIMenu Missions;
    public bool bought;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public int stockstimer;
    private Weapon currentWeapon;
    public int waittime;
    public int DisplayWait;
    private Blip Enemy;
    private Ped EnemyPed;
    private Vector3 EnemyLoc;
    public bool EnemySetup;
    public bool EnemySetup2;
    public int Chooseenemynum;
    public Vehicle VehicleId;
    public bool VehicleSetup;
    public bool VehicleSetup2;
    private List<WeaponHash> weapons = Enum.GetValues(typeof (WeaponHash)).Cast<WeaponHash>().ToList<WeaponHash>();
    private Vector3 VehicleLoc;
    private System.Random randomvehicle;
    private System.Random randomlocation;
    public string carid;
    public int vehiclemissionid;
    public bool setupdelivery;
    public Vector3 DeliveryMaker;
    public Blip DeliveryLoc;
    public Blip ballasBlip1;
    public Vector3 Deliverypoint;
    public bool setupwantedfordelivery;
    public int waittimeforwanted;
    private System.Random RandomWanted;
    private System.Random randomwantedwait;
    private int triggerwanted;
    public int HexerBought;
    public int AvurusBought;
    public int ChimeaBought;
    public int SanctusBought;
    public int InnovationBought;
    public int lccdaemonBought;
    public int DaemonBought;
    public int NightbladeBought;
    public int WolfsbaneBought;
    public int ratbikebought;
    public int duneBought;
    public int DuneLoaderBought;
    public int SlamvanBought;
    public int ZombieCBought;
    public int ZombieBBought;
    public bool createdPed;
    public Ped ClayPed;
    public int UseCustomWaitTime;
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
    public Vector3 PointA = new Vector3(2779.51f, 4403.84f, 49f);
    public Vector3 PointB = new Vector3(-78.89f, 6295.56f, 32f);
    public Vector3 PointC = new Vector3(1152.06f, 3263.91f, 40f);
    public Vector3 PointD = new Vector3(2293f, 3016.64f, 47f);
    public Vector3 PointE = new Vector3(2527.61f, 2844.2f, 3.3f);
    public Vector3 Spawn = new Vector3(2688.31f, 5127.53f, 45f);
    public Vector3 Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
    public Vector3 Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
    public Vector3 Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
    public Vector3 Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
    public PedGroup PG;
    public UIMenu FalseProfit;
    public Vector3 FPspawn;
    public bool GotBreefCase;
    public Model BreefCaseModel;
    public Prop BreefCase;
    public bool SpawnedBreefcase;
    public bool WaitingforPlayertoPickupCase;
    public Vehicle PedtoCheck;
    private int LodDistance = 3000;
    public Blip CaseBlip;
    public string VehicleWithCargo;
    public AllStock AllStocks;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public UIMenu PlayerConvoy;
    public UIMenu SpecialMissions;
    public List<Vector3> pPostion = new List<Vector3>();
    public List<Ped> Peds = new List<Ped>();
    public List<Ped> Guards = new List<Ped>();
    public int MaxGuards;
    public Ped Target;
    public Vehicle TargetsCar;
    public Blip TargetCarBlip;
    public List<Vehicle> VIPcars = new List<Vehicle>();
    public List<Blip> GuardBlips = new List<Blip>();
    public Vector3 Courthouse;
    public Blip CourthouseBlip;
    public bool ChoosenTargert;
    public int TimetoWait;
    public int Fail;
    public int ForgeryBought;
    public int MoneyPrinterBought;
    public int WeedFarmBought;
    public int CocaineBought;
    public int MethLabBought;
    public int Timer;
    public bool StartTimer;
    public float BusinessUpgradeIncreaseGain = 75000f;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    public List<Prop> Crates = new List<Prop>();
    private Func<int, Vector3, Vector3, bool, int> createProp = (Func<int, Vector3, Vector3, bool, int>) ((hash, pos, rot, dynamic) =>
    {
      Model model = new Model(hash);
      model.Request(10000);
      Prop prop = World.CreateProp(model, pos, rot, dynamic, false);
      prop.Position = pos;
      if (!dynamic)
        prop.FreezePosition = true;
      return prop.Handle;
    });
    private bool Initialized = false;
    public Vehicle ActiveTarget;
    public List<Ped> PlaneTargetPositions = new List<Ped>();
    public List<Vehicle> AIPlanes = new List<Vehicle>();
    public Vehicle Plane;
    public Ped CurrentTarget;
    public int PackagesRecieved;
    public int DropTimer;
    public int Payout;
    public int MissionTime;
    public Vehicle LastV;
    public UIMenu GangTakeOver;
    public Vector3 VehicleSpawn;
    public Vehicle Sam1;
    public Vehicle Sam2;
    public Vehicle Sam3;
    public Blip Sam1blip;
    public Blip Sam2blip;
    public Blip Sam3blip;
    public bool MissionSetup;
    public int mission;
    public Vector3 CurrentPoint;
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
    public int timer;
    public bool StartedRaid;
    public Vector3 SubBusinessLoc = new Vector3(856.399f, -2091f, 29f);
    public int SpawnAttackerTimer;
    public bool RaidSetup;
    public bool UseOldMarker;
    public bool IsSittinginCeoSeat;
    public Vector3 ChairPos = new Vector3(1007.805f, -3169.93f, -39f);
    public float P_Rotation = 90f;
    public Prop ChairProp;
    public int CurrentSafehouse;
    public Vector3 GrapeseedClubhouse = new Vector3(2479.4f, 4086.53f, 37f);
    public Vector3 DelPerroClubhouse = new Vector3(-1471f, -921f, 9f);
    public Vector3 HowikClubhouse = new Vector3(-22.3f, -192.7f, 51.5f);
    public Vector3 LaMesaClubhouse = new Vector3(939.7f, -1457.07f, 30.5f);
    public Vector3 PaletoClubhouse = new Vector3(-359f, 6062f, 30f);
    public Vector3 PillboxHillClubHouse = new Vector3(36f, -1027f, 28f);
    public Vector3 RanchoClubhouse = new Vector3(252f, -1808f, 26f);
    public Vector3 SandyShoresClubhouse1 = new Vector3(1737f, 3710f, 33f);
    public Vector3 SandyShoresClubhouse2 = new Vector3(-37.8f, 6419.2f, 30.5f);
    public Vector3 VespucciClubhouse = new Vector3(-1156f, -1575f, 7.5f);
    public Vector3 VinewoodClubhouse = new Vector3(190f, 307.7f, 104f);
    public Vector3 GreatChaparral = new Vector3(45.9f, 2788.5f, 56.5f);
    public Vector3 CurrentGarage;
    public List<string> CrateString = new List<string>();
    public int ClubhouseChoosen;
    public UIMenu SwitchClubhouseInt;
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
    public List<Vector3> DropPoint = new List<Vector3>();
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
    public Blip EndPointBlip;
    public Vector3 EndPointVec;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public List<Class1.MCBusinessLocations> MCSubLocMeth = new List<Class1.MCBusinessLocations>()
    {
      new Class1.MCBusinessLocations(1, "Meth Lab", new Vector3(201.931f, 2461.831f, 54.7f), new Vector3(212.0342f, 2469.23f, 55.88f), 8f, 910000f, "Grand Senora", new Vector3(219.4f, 2451.9f, 57f), 54f),
      new Class1.MCBusinessLocations(1, "Meth Lab", new Vector3(48.67f, 6305.617f, 30.6f), new Vector3(39.9f, 6295.227f, 31f), 118f, 1024000f, "Paleto", new Vector3(53.77f, 6291.101f, 31f), 24f),
      new Class1.MCBusinessLocations(1, "Meth Lab", new Vector3(1181.139f, -3113.849f, 5.5f), new Vector3(1189.169f, -3104.305f, 6f), 0.0f, 1365000f, "Terminal", new Vector3(1167.325f, -3110.371f, 5.8f), -102f),
      new Class1.MCBusinessLocations(1, "Meth Lab", new Vector3(1440.672f, -1669.23f, 65.5f), new Vector3(1452.362f, -1687.526f, 66f), 148f, 1729000f, "El Burro Heights", new Vector3(1433.046f, -1679.214f, 68f), -43f),
      new Class1.MCBusinessLocations(1, "Meth Lab", new Vector3(917.3094f, 3576.815f, 32.5f), new Vector3(913.4601f, 3589.332f, 33.5f), -90f, 1950000f, "Sandy Shores", new Vector3(936.0736f, 3586.559f, 34f), 102f)
    };
    public List<Class1.MCBusinessLocations> MCSubLocCocaine = new List<Class1.MCBusinessLocations>()
    {
      new Class1.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(1701.833f, 4857.689f, 41.1f), new Vector3(1709.077f, 4807.59f, 42f), 88f, 745000f, "Grapeseed", new Vector3(1717.16f, 4866.677f, 45f), 115f),
      new Class1.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(387.5449f, 3585.162f, 32.5f), new Vector3(379.3169f, 3592.716f, 33.5f), -73f, 975000f, "Alamo Sea", new Vector3(390.55f, 3604.774f, 33.2f), 167f),
      new Class1.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(52.163f, 6486.41f, 30.5f), new Vector3(61.58f, 6474.956f, 31f), 134f, 1098000f, "Paleto", new Vector3(71.51f, 6470.393f, 31f), 50f),
      new Class1.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(-253.4037f, -2591.267f, 5f), new Vector3(-256.4055f, -2578.896f, 6f), -4f, 1462000f, "Elysian Island", new Vector3(-217.13f, -2486.512f, 6f), -94f),
      new Class1.MCBusinessLocations(2, "Cocaine Lockup", new Vector3(-1462.221f, -382.029f, 37.5f), new Vector3(-1468.424f, -390.9298f, 38.8f), 139f, 1852000f, "Morningwood", new Vector3(-1450.121f, -385.002f, 38.1f), 94f)
    };
    public List<Class1.MCBusinessLocations> MCSubLocWeed = new List<Class1.MCBusinessLocations>()
    {
      new Class1.MCBusinessLocations(3, "Weed Farm", new Vector3(1351.31f, 3609.881f, 34f), new Vector3(1358.324f, 3519.502f, 35f), 111f, 760000f, "Sandy Shores", new Vector3(1348.934f, 3586.757f, 34.8f), -23f),
      new Class1.MCBusinessLocations(3, "Weed Farm", new Vector3(2848.095f, 4450.078f, 48f), new Vector3(2882.437f, 4462.606f, 48f), -40f, 715000f, "San Chianski", new Vector3(2829.663f, 4444.71f, 48.6f), -73f),
      new Class1.MCBusinessLocations(3, "Weed Farm", new Vector3(416.8681f, 6520.77f, 27.2f), new Vector3(408.06f, 6492.118f, 29f), 179f, 802000f, "Paleto", new Vector3(435.45f, 6516.217f, 28.5f), 78f),
      new Class1.MCBusinessLocations(3, "Weed Farm", new Vector3(134.326f, -2476.311f, 5f), new Vector3(136.3743f, -2480.311f, 6.2f), -36f, 1072000f, "Elysian Island", new Vector3(146.1162f, -2483.212f, 6f), 51f),
      new Class1.MCBusinessLocations(3, "Weed Farm", new Vector3(115.4127f, 170.6449f, 111.5f), new Vector3(122.78f, 163.2095f, 104.8f), 70f, 1358000f, "Downtown Vinewood", new Vector3(84.97f, 164.24f, 108f), -75f)
    };
    public List<Class1.MCBusinessLocations> MCSubLocCounterfiet = new List<Class1.MCBusinessLocations>()
    {
      new Class1.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(-433.8169f, -160.37f, 36.4f), new Vector3(-386.42f, -150.4592f, 38.7f), 30f, 762000f, "Burton", new Vector3(-444.2199f, -167.07f, 37.5f), -56f),
      new Class1.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(636.8149f, 2784.972f, 41.1f), new Vector3(647.5464f, 2757.564f, 42f), -175f, 845000f, "Grand Senora", new Vector3(644.7108f, 2773.031f, 42f), 35f),
      new Class1.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(-413.6141f, 6171.856f, 30.5f), new Vector3(-420.3352f, 6173.263f, 31f), -44f, 951000f, "Paleto", new Vector3(-406.74f, 6179.357f, 31.4f), 178f),
      new Class1.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(671.34f, -2667.699f, 5.4f), new Vector3(665.9106f, -2676.63f, 6f), 88f, 1267000f, "Cypress Flats", new Vector3(652.5844f, -2669.22f, 6f), -92f),
      new Class1.MCBusinessLocations(4, "Counterfeit Factory", new Vector3(-1154.091f, -1391.368f, 4.2f), new Vector3(-1173.426f, -1388.985f, 5f), 33f, 1605000f, "Vespucci Canals", new Vector3(-1149.638f, -1399.331f, 6f), 29f)
    };
    public List<Class1.MCBusinessLocations> MCSubLocForgery = new List<Class1.MCBusinessLocations>()
    {
      new Class1.MCBusinessLocations(5, "Forgery Office", new Vector3(1658.18f, 4851.34f, 41f), new Vector3(1637.37f, 4847.85f, 42f), -171f, 650000f, "Grapeseed", new Vector3(1675.548f, 4852.028f, 42.02f), 91f),
      new Class1.MCBusinessLocations(5, "Forgery Office", new Vector3(-163.4019f, 6334.985f, 30.5f), new Vector3(-170.1115f, 6311.16f, 31f), -132f, 732000f, "Paleto", new Vector3(-151.96f, 6344.84f, 31.4f), 132f),
      new Class1.MCBusinessLocations(5, "Forgery Office", new Vector3(-331.6698f, -2779.057f, 4.5f), new Vector3(-327.4135f, -2764.174f, 5f), 90f, 975000f, "Elysian Island", new Vector3(-344.46f, -2774.822f, 5f), -104f),
      new Class1.MCBusinessLocations(5, "Forgery Office", new Vector3(-1100.831f, 2723.169f, 18f), new Vector3(-1138.623f, 2685.009f, 18.6f), 166f, 995000f, "Zancudo River", new Vector3(-1101.594f, 2734.426f, 20f), 177f),
      new Class1.MCBusinessLocations(5, "Forgery Office", new Vector3(300.1986f, -759.1166f, 28.5f), new Vector3(305.54f, -696.8333f, 29f), -113f, 1235000f, "Textile City", new Vector3(316.1743f, -764.25f, 30f), 70f)
    };
    public int MethMCbusinessLoc = 0;
    public int WeedMCbusinessLoc = 0;
    public int CocaineMCbusinessLoc = 0;
    public int CounterfietMCbusinessLoc = 0;
    public int ForgeryMCbusinessLoc = 0;
    public Camera WarehouseCam;
    public bool WCamOn;
    public Blip CurrentViewingBusinessBlip;
    public string ChairPropModel = "ex_prop_offchair_exec_01";

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
        this.Safehouse_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "Safehouse_Colour", this.Safehouse_Colour);
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
        this.CurrentSafehouse = this.MainConfigFile.GetValue<int>("Misc", "CurrentSafehouse", this.CurrentSafehouse);
        this.SafehouseMColorString = this.MainConfigFile.GetValue<string>("Misc", "SafehouseMColor", this.SafehouseMColorString);
        if (this.SafehouseMColorString.Contains("ARGB"))
        {
          string[] strArray = this.SafehouseMColorString.Split(new string[1]
          {
            "_"
          }, StringSplitOptions.None);
          this.SafehouseMColor = Color.FromArgb(int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
        }
        if (!this.SafehouseMColorString.Contains("ARGB"))
          this.SafehouseMColor = Color.FromName(this.SafehouseMColorString);
        this.BusinessUpgradeIncreaseGain = this.MainConfigFile.GetValue<float>("Prices", "BusinessUpgradeIncreaseGain", this.BusinessUpgradeIncreaseGain);
        this.BusinessUpgradeBasePrice = this.MainConfigFile.GetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
        this.IncreaseStockMinAmount = this.MainConfigFile.GetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
        this.IncreaseStockMaxAmount = this.MainConfigFile.GetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
        this.DecreaseStockMinAmount = this.MainConfigFile.GetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
        this.DecreaseStockMaxAmount = this.MainConfigFile.GetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
        if (this.CurrentSafehouse == 0)
          this.CurrentGarage = this.GrapeseedClubhouse;
        if (this.CurrentSafehouse == 1)
          this.CurrentGarage = this.VespucciClubhouse;
        if (this.CurrentSafehouse == 2)
          this.CurrentGarage = this.HowikClubhouse;
        if (this.CurrentSafehouse == 3)
          this.CurrentGarage = this.LaMesaClubhouse;
        if (this.CurrentSafehouse == 4)
          this.CurrentGarage = this.PaletoClubhouse;
        if (this.CurrentSafehouse == 5)
          this.CurrentGarage = this.PillboxHillClubHouse;
        if (this.CurrentSafehouse == 6)
          this.CurrentGarage = this.RanchoClubhouse;
        if (this.CurrentSafehouse == 7)
          this.CurrentGarage = this.SandyShoresClubhouse1;
        if (this.CurrentSafehouse == 8)
          this.CurrentGarage = this.SandyShoresClubhouse2;
        if (this.CurrentSafehouse == 9)
          this.CurrentGarage = this.DelPerroClubhouse;
        if (this.CurrentSafehouse == 10)
          this.CurrentGarage = this.VinewoodClubhouse;
        if (this.CurrentSafehouse != 11)
          return;
        this.CurrentGarage = this.GreatChaparral;
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    public void MainModRefresh()
    {
      UI.Notify("~g~ Found Refresh Sequence~w~");
      this.IsScriptEnabled = true;
      bool flag = false;
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      if (this.CurrentSafehouse == 0)
      {
        this.CurrentGarage = this.GrapeseedClubhouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 1)
      {
        this.CurrentGarage = this.VespucciClubhouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 2)
      {
        this.CurrentGarage = this.HowikClubhouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 3)
      {
        this.CurrentGarage = this.LaMesaClubhouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 4)
      {
        this.CurrentGarage = this.PaletoClubhouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 5)
      {
        this.CurrentGarage = this.PillboxHillClubHouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 6)
      {
        this.CurrentGarage = this.RanchoClubhouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 7)
      {
        this.CurrentGarage = this.SandyShoresClubhouse1;
        flag = true;
      }
      if (this.CurrentSafehouse == 8)
      {
        this.CurrentGarage = this.SandyShoresClubhouse2;
        flag = true;
      }
      if (this.CurrentSafehouse == 9)
      {
        this.CurrentGarage = this.DelPerroClubhouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 10)
      {
        this.CurrentGarage = this.VinewoodClubhouse;
        flag = true;
      }
      if (this.CurrentSafehouse == 11)
      {
        this.CurrentGarage = this.GreatChaparral;
        flag = true;
      }
    }

    public void MainModDestroy()
    {
    }

    public void Addcoordsforpeds()
    {
      if (this.pPostion.Count > 0)
        this.pPostion.Clear();
      this.pPostion.Add(new Vector3(239.9219f, -391.0443f, 46.30545f));
      this.pPostion.Add(new Vector3(236.2484f, -389.6876f, 46.30545f));
      this.pPostion.Add(new Vector3(233.5761f, -389.2189f, 46.30582f));
      this.pPostion.Add(new Vector3(232.8379f, -392.0612f, 46.99816f));
      this.pPostion.Add(new Vector3(234.4297f, -394.8257f, 47.76475f));
      this.pPostion.Add(new Vector3(234.7243f, -398.2318f, 47.92435f));
      this.pPostion.Add(new Vector3(237.0339f, -399.61f, 47.92435f));
      this.pPostion.Add(new Vector3(240.1324f, -400.4513f, 47.92435f));
      this.pPostion.Add(new Vector3(245.1847f, -400.9407f, 47.92435f));
      this.pPostion.Add(new Vector3(247.2614f, -398.3486f, 47.43824f));
      this.pPostion.Add(new Vector3(248.2685f, -394.2352f, 46.30333f));
      this.pPostion.Add(new Vector3(252.0319f, -395.1376f, 46.30519f));
      this.pPostion.Add(new Vector3(256.8378f, -391.3466f, 45.40636f));
      this.pPostion.Add(new Vector3(255.8704f, -390.5818f, 45.40382f));
      this.pPostion.Add(new Vector3(253.2088f, -389.1288f, 45.40383f));
      this.pPostion.Add(new Vector3(250.4466f, -385.1119f, 44.65292f));
      this.pPostion.Add(new Vector3(249.501f, -384.5762f, 44.64069f));
      this.pPostion.Add(new Vector3(245.7016f, -385.6426f, 45.24415f));
      this.pPostion.Add(new Vector3(238.3f, -384.5841f, 45.40351f));
      this.pPostion.Add(new Vector3(235.5585f, -381.7093f, 45.1715f));
      this.pPostion.Add(new Vector3(231.1489f, -380.7896f, 45.37854f));
      this.pPostion.Add(new Vector3(229.6973f, -378.3413f, 44.80029f));
      this.pPostion.Add(new Vector3(235.301f, -392.6026f, 47.02602f));
      this.pPostion.Add(new Vector3(241.1147f, -391.6578f, 46.30562f));
      this.pPostion.Add(new Vector3(248.8011f, -394.766f, 46.30576f));
      this.pPostion.Add(new Vector3(250.0507f, -383.0063f, 44.61914f));
      this.pPostion.Add(new Vector3(246.9238f, -380.4474f, 44.53527f));
      this.pPostion.Add(new Vector3(243.6988f, -380.0899f, 44.50198f));
      this.pPostion.Add(new Vector3(234.9022f, -375.3924f, 44.36639f));
      this.pPostion.Add(new Vector3(233.5388f, -377.4519f, 44.39967f));
      this.pPostion.Add(new Vector3(252.3451f, -384.3543f, 44.66223f));
      this.pPostion.Add(new Vector3(255.2235f, -385.3559f, 44.71171f));
      this.pPostion.Add(new Vector3(255.0657f, -386.6884f, 44.71878f));
      this.pPostion.Add(new Vector3(258.0521f, -386.4732f, 44.74367f));
      this.pPostion.Add(new Vector3(259.7411f, -386.9255f, 44.76192f));
      this.pPostion.Add(new Vector3(258.0701f, -388.2597f, 44.75479f));
      this.pPostion.Add(new Vector3(238.5595f, -380.0944f, 44.47414f));
    }

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Biker Business", "BikerBusinessMain", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public Class1(bool B)
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts/HKH191sBusinessMods///MethBusiness//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
    }

    public Class1()
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts/HKH191sBusinessMods///MethBusiness//Main.ini");
      this.AllStocks = new AllStock();
      this.PG = new PedGroup();
      this.CreateBanner();
      this.Setup();
      this.waittime = this.AllStocks.waittime;
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Interval = 1;
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
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

    public void SpawnProp(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        World.CreateProp(model, Pos, Rot, true, true);
        foreach (Prop nearbyProp in World.GetNearbyProps(Pos, 2f))
        {
          if ((Entity) nearbyProp != (Entity) null)
          {
            this.BreefCase = nearbyProp;
            nearbyProp.FreezePosition = true;
          }
        }
      }
      model.MarkAsNoLongerNeeded();
    }

    public void SpawnCrate(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        World.CreateProp(model, Pos, Rot, true, true);
        foreach (Prop nearbyProp in World.GetNearbyProps(Pos, 2f))
        {
          if ((Entity) nearbyProp != (Entity) null)
            this.Crates.Add(nearbyProp);
        }
      }
      model.MarkAsNoLongerNeeded();
    }

    public void SetActiveTarget2(Vehicle Plane, Ped P)
    {
      Vector3 position = P.Position;
      Function.Call(Hash._0x23703CD154E83B88, (InputArgument) Plane.GetPedOnSeat(VehicleSeat.Driver).Handle, (InputArgument) Plane.Handle, (InputArgument) P, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 6, (InputArgument) 70.0, (InputArgument) -1.0, (InputArgument) 30, (InputArgument) 1000, (InputArgument) 250);
    }

    public void SetActiveTarget(Vehicle Plane, Ped P)
    {
      Vector3 position = P.Position;
      Function.Call(Hash._0x23703CD154E83B88, (InputArgument) Plane.GetPedOnSeat(VehicleSeat.Driver).Handle, (InputArgument) Plane.Handle, (InputArgument) P, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 6, (InputArgument) 70.0, (InputArgument) -1.0, (InputArgument) 30, (InputArgument) 1000, (InputArgument) 250);
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
              int num = index + 50;
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

    public void SpawnDrugCrate(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        this.Crates.Add(World.CreateProp(model, Pos, Rot, true, false));
        foreach (Prop crate in this.Crates)
        {
          crate.HasCollision = true;
          crate.HasGravity = true;
          crate.FreezePosition = false;
          crate.LodDistance = 3000;
          crate.ApplyForce(Vector3.WorldDown);
          crate.HasCollision = true;
          crate.HasGravity = true;
          crate.ApplyForceRelative(Vector3.WorldDown, new Vector3(0.0f, 0.0f, 0.0f), ForceType.ForceNoRot);
        }
      }
      model.MarkAsNoLongerNeeded();
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

    public void AddCrates()
    {
      this.CrateString.Add("bkr_prop_moneypack_01a");
      this.CrateString.Add("bkr_prop_meth_bigbag_01a");
      this.CrateString.Add("bkr_prop_fakeid_boxdriverl_01a");
      this.CrateString.Add("bkr_prop_fakeid_boxpassport_01a");
      this.CrateString.Add("bkr_prop_coke_block_01a");
      this.CrateString.Add("bkr_prop_weed_bigbag_03a");
      this.CrateString.Add("bkr_prop_meth_pseudoephedrine");
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      this.AddCrates();
      this.createdPed = false;
      this.BuyMarker = new Vector3(1001.9f, -3163.9f, -35.5f);
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Biker Buisness", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.methgarage = this.modMenuPool.AddSubMenu(this.mainMenu, "Purchase Options");
      this.GUIMenus.Add(this.methgarage);
      this.ProductStock = this.modMenuPool.AddSubMenu(this.mainMenu, "Product Options");
      this.GUIMenus.Add(this.ProductStock);
      this.BikerRivallry = this.modMenuPool.AddSubMenu(this.mainMenu, "Biker Rivalry (Missions)");
      this.GUIMenus.Add(this.BikerRivallry);
      this.FalseProfit = this.modMenuPool.AddSubMenu(this.mainMenu, "False Profit (Missions)");
      this.GUIMenus.Add(this.FalseProfit);
      this.SpecialMissions = this.modMenuPool.AddSubMenu(this.mainMenu, "Special Missions (Missions)");
      this.GUIMenus.Add(this.SpecialMissions);
      this.GangTakeOver = this.modMenuPool.AddSubMenu(this.mainMenu, "Gang Take Over (Missions)");
      this.GUIMenus.Add(this.GangTakeOver);
      this.FailedPeaceTreaty = this.modMenuPool.AddSubMenu(this.mainMenu, "Peace Treaty (Missions)");
      this.GUIMenus.Add(this.FailedPeaceTreaty);
      this.BikesGarage = this.modMenuPool.AddSubMenu(this.mainMenu, "Bikes Shop");
      this.GUIMenus.Add(this.BikesGarage);
      this.WeaponsShop = this.modMenuPool.AddSubMenu(this.mainMenu, "WeaponsShop");
      this.GUIMenus.Add(this.WeaponsShop);
      this.SwitchClubhouseInt = this.modMenuPool.AddSubMenu(this.mainMenu, "Clubhouse options");
      this.GUIMenus.Add(this.SwitchClubhouseInt);
      this.SwitchClubhouseInterior();
      this.SetupGangTakeOver();
      this.SetupFPTM();
      this.Setupbuisness();
      this.SetupGarage();
      this.SetupProduct();
      this.SetupWeaponsShop();
      this.SetupBikerRivalry();
      this.SetupFalseProfit();
      this.SetupSpecialMissions();
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
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void SwitchClubhouseInterior()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SwitchClubhouseInt, "Switch Clubhouse Interior");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Loc1 = new UIMenuItem("2 Floor Clubhouse ");
      uiMenu.AddItem(Loc1);
      UIMenuItem Loc2 = new UIMenuItem("1 Floor Clubhouse ");
      uiMenu.AddItem(Loc2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Loc1)
        {
          this.ClubhouseChoosen = 1;
          this.Config.SetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
          this.Config.Save();
          UI.Notify(this.GetHostName() + " Ive organised to redesign the inteiror of our clubhouse! to 2 Floor Clubhouse, please Exit and Enter The ClubHouse");
          Game.Player.Character.Position = this.ChairPos.Around(2f);
          this.IsSittinginCeoSeat = false;
          Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
          Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
          Game.Player.Character.Task.ClearAnimation("anim@amb@office@laptops@male@var_c@base@", "base");
          Game.Player.Character.FreezePosition = false;
          this.firstTime = true;
          this.modMenuPool.CloseAllMenus();
        }
        if (item != Loc2)
          return;
        this.ClubhouseChoosen = 2;
        this.Config.SetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " Ive organised to redesign the inteiror of our clubhouse! to 1 Floor Clubhouse, please Exit and Enter The ClubHouse");
        Game.Player.Character.Position = this.ChairPos.Around(2f);
        this.IsSittinginCeoSeat = false;
        Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
        Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
        Game.Player.Character.Task.ClearAnimation("anim@amb@office@laptops@male@var_c@base@", "base");
        Game.Player.Character.FreezePosition = false;
        this.firstTime = true;
        this.modMenuPool.CloseAllMenus();
      });
    }

    private void SubBusinesRaids()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SubBusinessRaid, "MC Business Raids");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Loc1 = new UIMenuItem("Location 1");
      uiMenu.AddItem(Loc1);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Loc1)
          return;
        this.RaidSetup = true;
        this.isAtSubBusiness = true;
        this.mission = 1;
        UI.Notify(this.GetHostName() + " boss quickly get to our MC Business, we are expecting to be raided by the gangs of Los Santos");
      });
    }

    private void SetupFPTM()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.FailedPeaceTreaty, "Peace Treaties");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Loc1 = new UIMenuItem("Location 1");
      uiMenu.AddItem(Loc1);
      UIMenuItem Loc2 = new UIMenuItem("Location 2");
      uiMenu.AddItem(Loc2);
      UIMenuItem Loc3 = new UIMenuItem("Location 3");
      uiMenu.AddItem(Loc3);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Loc3)
        {
          this.ExitVehicle = true;
          this.BallasSpawn = new Vector3(-2037f, -367f, 48f);
          this.VagosSpawn = new Vector3(-2025f, -348f, 48f);
          this.FamiliesSpawn = new Vector3(-2013f, -352f, 48f);
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          if ((Entity) this.Sam2 != (Entity) null)
            this.Sam2.Delete();
          if (this.Sam2blip != (Blip) null)
            this.Sam2blip.Remove();
          if ((Entity) this.Sam3 != (Entity) null)
            this.Sam3.Delete();
          if (this.Sam3blip != (Blip) null)
            this.Sam3blip.Remove();
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Faction2, this.FamiliesSpawn);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Families01GFY);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Buccaneer2, this.BallasSpawn);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Ballas01GFY);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Chino2, this.VagosSpawn);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Vagos01GFY);
          this.ArmedPed(this.Sam1.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam1.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam2.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam2.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam3.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam3.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
          this.Gang.Add(this.Sam1.GetPedOnSeat(VehicleSeat.Driver));
          this.Gang.Add(this.Sam1.GetPedOnSeat(VehicleSeat.Passenger));
          this.Gang.Add(this.Sam2.GetPedOnSeat(VehicleSeat.Driver));
          this.Gang.Add(this.Sam2.GetPedOnSeat(VehicleSeat.Passenger));
          this.Gang.Add(this.Sam3.GetPedOnSeat(VehicleSeat.Driver));
          this.Gang.Add(this.Sam3.GetPedOnSeat(VehicleSeat.Passenger));
          this.SetupFamilies(this.Sam1, 1);
          this.SetupBallas(this.Sam3, 1);
          this.SetupVagos(this.Sam2, 1);
          this.CurrentPoint = this.GetLocation();
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.TargetA;
          this.Sam1blip.Color = BlipColor.Green;
          this.Sam1blip.Name = "Peace Treaty Car A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          this.Sam2blip.Sprite = BlipSprite.TargetB;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam2blip, (InputArgument) 7);
          this.Sam2blip.Name = "Peace Treaty Car B";
          this.Sam3blip = World.CreateBlip(this.Sam2.Position);
          this.Sam3blip.Sprite = BlipSprite.TargetC;
          this.Sam3blip.Color = BlipColor.Yellow;
          this.Sam3blip.Name = "Peace Treaty Car C";
          this.MissionSetup = true;
          this.mission = 3;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " boss we have spotted that the Families, Vagos, and the ballas are meeting for some sort of peace treaty, we have to stop this!");
        }
        if (item == Loc2)
        {
          this.ExitVehicle = true;
          this.BallasSpawn = new Vector3(-462.735f, -760f, 44f);
          this.VagosSpawn = new Vector3(-453f, -775f, 44f);
          this.FamiliesSpawn = new Vector3(-468f, -781f, 44f);
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          if ((Entity) this.Sam2 != (Entity) null)
            this.Sam2.Delete();
          if (this.Sam2blip != (Blip) null)
            this.Sam2blip.Remove();
          if ((Entity) this.Sam3 != (Entity) null)
            this.Sam3.Delete();
          if (this.Sam3blip != (Blip) null)
            this.Sam3blip.Remove();
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Faction2, this.FamiliesSpawn);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Families01GFY);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Buccaneer2, this.BallasSpawn);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Ballas01GFY);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Chino2, this.VagosSpawn);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Vagos01GFY);
          this.ArmedPed(this.Sam1.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam1.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam2.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam2.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam3.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
          this.ArmedPed(this.Sam3.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
          this.Gang.Add(this.Sam1.GetPedOnSeat(VehicleSeat.Driver));
          this.Gang.Add(this.Sam1.GetPedOnSeat(VehicleSeat.Passenger));
          this.Gang.Add(this.Sam2.GetPedOnSeat(VehicleSeat.Driver));
          this.Gang.Add(this.Sam2.GetPedOnSeat(VehicleSeat.Passenger));
          this.Gang.Add(this.Sam3.GetPedOnSeat(VehicleSeat.Driver));
          this.Gang.Add(this.Sam3.GetPedOnSeat(VehicleSeat.Passenger));
          this.SetupFamilies(this.Sam1, 1);
          this.SetupBallas(this.Sam3, 1);
          this.SetupVagos(this.Sam2, 1);
          this.CurrentPoint = this.GetLocation();
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.TargetA;
          this.Sam1blip.Color = BlipColor.Green;
          this.Sam1blip.Name = "Peace Treaty Car A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          this.Sam2blip.Sprite = BlipSprite.TargetB;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam2blip, (InputArgument) 7);
          this.Sam2blip.Name = "Peace Treaty Car B";
          this.Sam3blip = World.CreateBlip(this.Sam2.Position);
          this.Sam3blip.Sprite = BlipSprite.TargetC;
          this.Sam3blip.Color = BlipColor.Yellow;
          this.Sam3blip.Name = "Peace Treaty Car C";
          this.MissionSetup = true;
          this.mission = 3;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " boss we have spotted that the Families, Vagos, and the ballas are meeting for some sort of peace treaty, we have to stop this!");
        }
        if (item != Loc1)
          return;
        this.ExitVehicle = true;
        this.BallasSpawn = new Vector3(-792f, -2372.08f, 14f);
        this.VagosSpawn = new Vector3(-799f, -2369f, 14f);
        this.FamiliesSpawn = new Vector3(-802f, -2378f, 14f);
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        if ((Entity) this.Sam2 != (Entity) null)
          this.Sam2.Delete();
        if (this.Sam2blip != (Blip) null)
          this.Sam2blip.Remove();
        if ((Entity) this.Sam3 != (Entity) null)
          this.Sam3.Delete();
        if (this.Sam3blip != (Blip) null)
          this.Sam3blip.Remove();
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.Faction2, this.FamiliesSpawn);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Families01GFY);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.Buccaneer2, this.BallasSpawn);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Ballas01GFY);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.Chino2, this.VagosSpawn);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Vagos01GFY);
        this.ArmedPed(this.Sam1.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
        this.ArmedPed(this.Sam1.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
        this.ArmedPed(this.Sam2.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
        this.ArmedPed(this.Sam2.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
        this.ArmedPed(this.Sam3.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
        this.ArmedPed(this.Sam3.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
        this.Gang.Add(this.Sam1.GetPedOnSeat(VehicleSeat.Driver));
        this.Gang.Add(this.Sam1.GetPedOnSeat(VehicleSeat.Passenger));
        this.Gang.Add(this.Sam2.GetPedOnSeat(VehicleSeat.Driver));
        this.Gang.Add(this.Sam2.GetPedOnSeat(VehicleSeat.Passenger));
        this.Gang.Add(this.Sam3.GetPedOnSeat(VehicleSeat.Driver));
        this.Gang.Add(this.Sam3.GetPedOnSeat(VehicleSeat.Passenger));
        this.SetupFamilies(this.Sam1, 1);
        this.SetupBallas(this.Sam3, 1);
        this.SetupVagos(this.Sam2, 1);
        this.CurrentPoint = this.GetLocation();
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.TargetA;
        this.Sam1blip.Color = BlipColor.Green;
        this.Sam1blip.Name = "Peace Treaty Car A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        this.Sam2blip.Sprite = BlipSprite.TargetB;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam2blip, (InputArgument) 7);
        this.Sam2blip.Name = "Peace Treaty Car B";
        this.Sam3blip = World.CreateBlip(this.Sam2.Position);
        this.Sam3blip.Sprite = BlipSprite.TargetC;
        this.Sam3blip.Color = BlipColor.Yellow;
        this.Sam3blip.Name = "Peace Treaty Car C";
        this.MissionSetup = true;
        this.mission = 3;
        this.killedDriver = true;
        this.NOTIFY = true;
        UI.Notify(this.GetHostName() + " boss we have spotted that the Families, Vagos, and the ballas are meeting for some sort of peace treaty, we have to stop this!");
      });
    }

    private void ArmedPed(Ped Ped, WeaponHash Weapon) => Ped.Weapons.Give(Weapon, 9999, true, true);

    private void SetupGangTakeOver()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.GangTakeOver, "Vagos Gang ");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.GangTakeOver, "Ballas Gang ");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.GangTakeOver, "Families Gang ");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem Vagos = new UIMenuItem("Vagos 1");
      uiMenu1.AddItem(Vagos);
      UIMenuItem Vagos1 = new UIMenuItem("Vagos 2");
      uiMenu1.AddItem(Vagos1);
      UIMenuItem Ballas = new UIMenuItem("Ballas 1");
      uiMenu2.AddItem(Ballas);
      UIMenuItem Ballas2 = new UIMenuItem("Ballas 2");
      uiMenu2.AddItem(Ballas2);
      UIMenuItem Families = new UIMenuItem("Families 1");
      uiMenu3.AddItem(Families);
      UIMenuItem Families2 = new UIMenuItem("Families 2");
      uiMenu3.AddItem(Families2);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Families)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          if ((Entity) this.Sam2 != (Entity) null)
            this.Sam2.Delete();
          if (this.Sam2blip != (Blip) null)
            this.Sam2blip.Remove();
          if ((Entity) this.Sam3 != (Entity) null)
            this.Sam3.Delete();
          if (this.Sam3blip != (Blip) null)
            this.Sam3blip.Remove();
          Vector3 location = this.GetLocation();
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Faction2, location);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Faction2, location);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Faction2, location);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Sam2.PlaceOnNextStreet();
          this.Sam3.PlaceOnNextStreet();
          this.SetupFamilies(this.Sam1, 1);
          this.SetupFamilies(this.Sam3, 1);
          this.SetupFamilies(this.Sam2, 1);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.TargetA;
          this.Sam1blip.Color = BlipColor.Green;
          this.Sam1blip.Name = "Families Patrol A";
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          this.Sam2blip.Sprite = BlipSprite.TargetB;
          this.Sam2blip.Color = BlipColor.Green;
          this.Sam2blip.Name = "Families Patrol B";
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
          this.Sam3blip = World.CreateBlip(this.Sam2.Position);
          this.Sam3blip.Sprite = BlipSprite.TargetC;
          this.Sam3blip.Color = BlipColor.Green;
          this.Sam3blip.Name = "Families Patrol C";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " weve spotted a Families patrol, go destroy them and their cars for a reward");
        }
        if (item != Families2)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        if ((Entity) this.Sam2 != (Entity) null)
          this.Sam2.Delete();
        if (this.Sam2blip != (Blip) null)
          this.Sam2blip.Remove();
        if ((Entity) this.Sam3 != (Entity) null)
          this.Sam3.Delete();
        if (this.Sam3blip != (Blip) null)
          this.Sam3blip.Remove();
        Vector3 location1 = this.GetLocation();
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.SabreGT2, location1);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.SabreGT2, location1);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.SabreGT2, location1);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Sam2.PlaceOnNextStreet();
        this.Sam3.PlaceOnNextStreet();
        this.SetupFamilies(this.Sam1, 2);
        this.SetupFamilies(this.Sam3, 2);
        this.SetupFamilies(this.Sam2, 2);
        this.CurrentPoint = this.GetLocation();
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.TargetA;
        this.Sam1blip.Color = BlipColor.Green;
        this.Sam1blip.Name = "Families Patrol A";
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        this.Sam2blip.Sprite = BlipSprite.TargetB;
        this.Sam2blip.Color = BlipColor.Green;
        this.Sam2blip.Name = "Families Patrol B";
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
        this.Sam3blip = World.CreateBlip(this.Sam2.Position);
        this.Sam3blip.Sprite = BlipSprite.TargetC;
        this.Sam3blip.Color = BlipColor.Green;
        this.Sam3blip.Name = "Families Patrol C";
        this.MissionSetup = true;
        this.mission = 2;
        this.killedDriver = true;
        this.NOTIFY = true;
        UI.Notify(this.GetHostName() + " weve spotted a Families patrol, go destroy them and their cars for a reward");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Ballas)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          if ((Entity) this.Sam2 != (Entity) null)
            this.Sam2.Delete();
          if (this.Sam2blip != (Blip) null)
            this.Sam2blip.Remove();
          if ((Entity) this.Sam3 != (Entity) null)
            this.Sam3.Delete();
          if (this.Sam3blip != (Blip) null)
            this.Sam3blip.Remove();
          Vector3 location = this.GetLocation();
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Buccaneer2, location);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Buccaneer2, location);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Buccaneer2, location);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Sam2.PlaceOnNextStreet();
          this.Sam3.PlaceOnNextStreet();
          this.SetupBallas(this.Sam1, 1);
          this.SetupBallas(this.Sam3, 1);
          this.SetupBallas(this.Sam2, 1);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.TargetA;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam1blip, (InputArgument) 7);
          this.Sam1blip.Name = "Ballas Patrol A";
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          this.Sam2blip.Sprite = BlipSprite.TargetB;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam2blip, (InputArgument) 7);
          this.Sam2blip.Name = "Ballas Patrol B";
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
          this.Sam3blip = World.CreateBlip(this.Sam2.Position);
          this.Sam3blip.Sprite = BlipSprite.TargetC;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam3blip, (InputArgument) 7);
          this.Sam3blip.Name = "Ballas Patrol C";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " weve spotted a Ballas patrol, go destroy them and their cars for a reward");
        }
        if (item != Ballas2)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        if ((Entity) this.Sam2 != (Entity) null)
          this.Sam2.Delete();
        if (this.Sam2blip != (Blip) null)
          this.Sam2blip.Remove();
        if ((Entity) this.Sam3 != (Entity) null)
          this.Sam3.Delete();
        if (this.Sam3blip != (Blip) null)
          this.Sam3blip.Remove();
        Vector3 location1 = this.GetLocation();
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.Moonbeam2, location1);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.Moonbeam2, location1);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.Moonbeam2, location1);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Ballas01GFY);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Sam2.PlaceOnNextStreet();
        this.Sam3.PlaceOnNextStreet();
        this.SetupBallas(this.Sam1, 2);
        this.SetupBallas(this.Sam3, 2);
        this.SetupBallas(this.Sam2, 2);
        this.CurrentPoint = this.GetLocation();
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.TargetA;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam1blip, (InputArgument) 7);
        this.Sam1blip.Name = "Ballas Patrol A";
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        this.Sam2blip.Sprite = BlipSprite.TargetB;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam2blip, (InputArgument) 7);
        this.Sam2blip.Name = "Ballas Patrol B";
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
        this.Sam3blip = World.CreateBlip(this.Sam2.Position);
        this.Sam3blip.Sprite = BlipSprite.TargetC;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.Sam3blip, (InputArgument) 7);
        this.Sam3blip.Name = "Ballas Patrol C";
        this.MissionSetup = true;
        this.mission = 2;
        this.killedDriver = true;
        this.NOTIFY = true;
        UI.Notify(this.GetHostName() + " weve spotted a Ballas patrol, go destroy them and their cars for a reward");
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Vagos)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          if ((Entity) this.Sam2 != (Entity) null)
            this.Sam2.Delete();
          if (this.Sam2blip != (Blip) null)
            this.Sam2blip.Remove();
          if ((Entity) this.Sam3 != (Entity) null)
            this.Sam3.Delete();
          if (this.Sam3blip != (Blip) null)
            this.Sam3blip.Remove();
          Vector3 location = this.GetLocation();
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Chino2, location);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Chino2, location);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Chino2, location);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Sam2.PlaceOnNextStreet();
          this.Sam3.PlaceOnNextStreet();
          this.SetupVagos(this.Sam1, 1);
          this.SetupVagos(this.Sam3, 1);
          this.SetupVagos(this.Sam2, 1);
          this.CurrentPoint = this.GetLocation();
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.TargetA;
          this.Sam1blip.Color = BlipColor.Yellow;
          this.Sam1blip.Name = "Vagos Patrol A";
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          this.Sam2blip.Sprite = BlipSprite.TargetB;
          this.Sam2blip.Color = BlipColor.Yellow;
          this.Sam2blip.Name = "Vagos Patrol B";
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
          this.Sam3blip = World.CreateBlip(this.Sam2.Position);
          this.Sam3blip.Sprite = BlipSprite.TargetC;
          this.Sam3blip.Color = BlipColor.Yellow;
          this.Sam3blip.Name = "Vagos Patrol C";
          this.MissionSetup = true;
          this.mission = 2;
          this.killedDriver = true;
          this.NOTIFY = true;
          UI.Notify(this.GetHostName() + " weve spotted a Vagos patrol, go destroy them and their cars for a reward");
        }
        if (item != Vagos1)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        if ((Entity) this.Sam2 != (Entity) null)
          this.Sam2.Delete();
        if (this.Sam2blip != (Blip) null)
          this.Sam2blip.Remove();
        if ((Entity) this.Sam3 != (Entity) null)
          this.Sam3.Delete();
        if (this.Sam3blip != (Blip) null)
          this.Sam3blip.Remove();
        Vector3 location1 = this.GetLocation();
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.Virgo2, location1);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.Virgo2, location1);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.Virgo2, location1);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Sam3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Sam2.PlaceOnNextStreet();
        this.Sam3.PlaceOnNextStreet();
        this.SetupVagos(this.Sam1, 2);
        this.SetupVagos(this.Sam3, 2);
        this.SetupVagos(this.Sam2, 2);
        this.CurrentPoint = this.GetLocation();
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.TargetA;
        this.Sam1blip.Color = BlipColor.Yellow;
        this.Sam1blip.Name = "Vagos Patrol A";
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        this.Sam2blip.Sprite = BlipSprite.TargetB;
        this.Sam2blip.Color = BlipColor.Yellow;
        this.Sam2blip.Name = "Vagos Patrol B";
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
        this.Sam3blip = World.CreateBlip(this.Sam2.Position);
        this.Sam3blip.Sprite = BlipSprite.TargetC;
        this.Sam3blip.Color = BlipColor.Yellow;
        this.Sam3blip.Name = "Vagos Patrol C";
        this.MissionSetup = true;
        this.mission = 2;
        this.killedDriver = true;
        this.NOTIFY = true;
        UI.Notify(this.GetHostName() + " weve spotted a Vagos patrol, go destroy them and their cars for a reward");
      });
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

    private Vector3 GetLocation()
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

    public void SetupSpecialMissions()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SpecialMissions, "Special Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("The Courthouse Dilema");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("The Air Drop");
      uiMenu.AddItem(Mission2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission2)
        {
          foreach (Prop crate in this.Crates)
          {
            if ((Entity) crate != (Entity) null)
              crate.Delete();
          }
          if (this.TargetCarBlip != (Blip) null)
            this.TargetCarBlip.Remove();
          if ((Entity) this.TargetsCar != (Entity) null)
            this.TargetsCar.Delete();
          this.PackagesRecieved = 0;
          this.Payout = 0;
          this.MissionTime = 0;
          foreach (Vehicle viPcar in this.VIPcars)
          {
            if ((Entity) viPcar != (Entity) null)
              viPcar.Delete();
          }
          Ped ped1 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(1325.7f, 2204.9f, 200f));
          ped1.FreezePosition = true;
          ped1.IsInvincible = true;
          ped1.IsVisible = false;
          this.PlaneTargetPositions.Add(ped1);
          Ped ped2 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(997.2f, 2829.3f, 200f));
          ped2.FreezePosition = true;
          ped2.IsInvincible = true;
          ped2.IsVisible = false;
          this.PlaneTargetPositions.Add(ped2);
          Ped ped3 = World.CreatePed((Model) PedHash.AbigailCutscene, new Vector3(1561.9f, 3277.5f, 200f));
          ped3.FreezePosition = true;
          ped3.IsInvincible = true;
          ped3.IsVisible = false;
          this.PlaneTargetPositions.Add(ped3);
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 11;
          UI.Notify(this.GetHostName() + " we have spotted a drug plane, dropping packages, collect as many you can, to earn cash, so head over to Trevors Airfield and grab some packages!");
        }
        if (item != Mission1)
          return;
        this.MaxGuards = 8;
        this.Addcoordsforpeds();
        if ((Entity) this.Target != (Entity) null)
          this.Target.Delete();
        foreach (Vehicle viPcar in this.VIPcars)
        {
          if ((Entity) viPcar != (Entity) null)
            viPcar.Delete();
        }
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        foreach (Blip guardBlip in this.GuardBlips)
        {
          if (guardBlip != (Blip) null)
            guardBlip.Remove();
        }
        foreach (Ped guard in this.Guards)
        {
          if ((Entity) guard != (Entity) null)
            guard.Delete();
        }
        if (this.CourthouseBlip != (Blip) null)
          this.CourthouseBlip.Remove();
        if (this.TargetCarBlip != (Blip) null)
          this.TargetCarBlip.Remove();
        System.Random random = new System.Random();
        random.Next(1, 100);
        random.Next(1, 100);
        foreach (Vector3 position in this.pPostion)
        {
          int num = random.Next(1, 100);
          if ((Entity) this.Target == (Entity) null && num < 10)
          {
            this.Target = World.CreateRandomPed(position);
            this.Target.Heading = -31f;
            this.Target.IsPersistent = true;
          }
          if (this.Guards.Count < this.MaxGuards && num < 25)
            this.Guards.Add(World.CreatePed((Model) PedHash.FbiSuit01, position, -31f));
          if (num > 25 || this.Guards.Count >= this.MaxGuards)
          {
            Ped randomPed = World.CreateRandomPed(position);
            randomPed.Heading = -31f;
            this.Peds.Add(randomPed);
            randomPed.IsPersistent = true;
          }
        }
        if ((Entity) this.Target == (Entity) null)
        {
          this.Target = World.CreateRandomPed(new Vector3(241f, -394f, 46f));
          this.Target.Heading = -31f;
          this.Target.IsPersistent = true;
        }
        this.Courthouse = new Vector3(241f, -394f, 46f);
        this.CourthouseBlip = World.CreateBlip(this.Courthouse);
        this.CourthouseBlip.Sprite = BlipSprite.VIP;
        this.CourthouseBlip.Color = BlipColor.Yellow;
        this.CourthouseBlip.Name = "Kill VIP";
        this.VehicleSetup2 = true;
        this.vehiclemissionid = 10;
        this.StartTimer = false;
        this.VIPcars.Add(World.CreateVehicle((Model) VehicleHash.Primo, new Vector3(237f, -370f, 43f), -110f));
        this.VIPcars.Add(World.CreateVehicle((Model) VehicleHash.Glendale, new Vector3(232f, -368f, 43f), -110f));
        this.VIPcars.Add(World.CreateVehicle((Model) VehicleHash.Asea, new Vector3(253f, -375f, 44f), -110f));
        this.VIPcars.Add(World.CreateVehicle((Model) VehicleHash.Tailgater, new Vector3(258f, -377f, 44f), -110f));
        this.VIPcars.Add(World.CreateVehicle((Model) VehicleHash.Cognoscenti, new Vector3(265f, -380f, 44f), -110f));
        int num1 = random.Next(1, 5);
        if (num1 == 1)
          this.TargetsCar = this.VIPcars[0];
        if (num1 == 2)
          this.TargetsCar = this.VIPcars[1];
        if (num1 == 3)
          this.TargetsCar = this.VIPcars[2];
        if (num1 == 4)
          this.TargetsCar = this.VIPcars[3];
        if (num1 == 5)
          this.TargetsCar = this.VIPcars[4];
        this.Timer = random.Next(1500, 3000);
        this.ChoosenTargert = false;
        UI.Notify(this.GetHostName() + " A rival VIP has come out of hiding, at the Courthouse, kill him!, ~y~but dont kill any of the civilians around, we want to make this look like a accident ~w~");
        this.Fail = 0;
        foreach (Ped guard in this.Guards)
        {
          if ((Entity) guard != (Entity) null)
          {
            guard.IsPersistent = true;
            int num2 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) guard, (InputArgument) num2);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) guard, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) guard, (InputArgument) 1);
            guard.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
          }
        }
      });
    }

    public int ChooseCar()
    {
      System.Random random = new System.Random();
      int num = 0;
      if (random.Next(1, 100) < 20)
        num = 1;
      if (random.Next(1, 100) >= 20 && random.Next(1, 100) < 40)
        num = 2;
      if (random.Next(1, 100) >= 40 && random.Next(1, 100) < 60)
        num = 3;
      if (random.Next(1, 100) >= 60 && random.Next(1, 100) < 80)
        num = 4;
      if (random.Next(1, 100) >= 80 && random.Next(1, 100) < 100)
        num = 5;
      return num;
    }

    public Vector3 GetRandomlocation()
    {
      int num = new System.Random().Next(1, 13);
      Vector3 vector3 = new Vector3(-1069.32f, -72.28f, 19f);
      if (num == 1)
        vector3 = new Vector3(-1069.32f, -72.28f, 19f);
      if (num == 2)
        vector3 = new Vector3(-1579.93f, -155.28f, 55f);
      if (num == 3)
        vector3 = new Vector3(-711.74f, -28.28f, 37f);
      if (num == 4)
        vector3 = new Vector3(6f, 253.58f, 109f);
      if (num == 5)
        vector3 = new Vector3(703f, 32f, 84f);
      if (num == 6)
        vector3 = new Vector3(1197f, -421.5f, 68f);
      if (num == 7)
        vector3 = new Vector3(1257f, -1428f, 35f);
      if (num == 8)
        vector3 = new Vector3(1264f, -2039f, 45f);
      if (num == 9)
        vector3 = new Vector3(527f, -2052f, 28f);
      if (num == 10)
        vector3 = new Vector3(-161f, -2087.8f, 26f);
      if (num == 11)
        vector3 = new Vector3(756f, -1723f, 30f);
      if (num == 12)
        vector3 = new Vector3(-816f, -2300f, 11f);
      if (num == 13)
        vector3 = new Vector3(-1839f, 136f, 78f);
      if (num > 13)
        vector3 = new Vector3(756f, -1723f, 30f);
      return vector3;
    }

    private void SetupFalseProfit()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.FalseProfit, "False Profit Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Sandy Shores 1");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Sandy Shores 2");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Los Santos 1");
      uiMenu.AddItem(Mission3);
      UIMenuItem Mission4 = new UIMenuItem("Los Santos 2");
      uiMenu.AddItem(Mission4);
      UIMenuItem Mission5 = new UIMenuItem("Blaine County 1");
      uiMenu.AddItem(Mission5);
      UIMenuItem Mission6 = new UIMenuItem("Blaine County 2");
      uiMenu.AddItem(Mission6);
      UIMenuItem Mission8 = new UIMenuItem("Paleto Bay 1");
      uiMenu.AddItem(Mission8);
      UIMenuItem Mission9 = new UIMenuItem("Paleto Bay 2");
      uiMenu.AddItem(Mission9);
      UIMenuItem Mission7 = new UIMenuItem("Random Location");
      uiMenu.AddItem(Mission7);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission1)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
          if ((Entity) this.BreefCase != (Entity) null)
            this.BreefCase.Delete();
          if (this.CaseBlip != (Blip) null)
            this.CaseBlip.Remove();
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
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn1);
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn2);
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn3);
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn4);
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.GunCar;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          int num1 = this.ChooseCar();
          if (num1 == 1)
          {
            this.VehicleWithCargo = "A";
            this.PedtoCheck = this.Bike1;
          }
          if (num1 == 2)
          {
            this.VehicleWithCargo = "B";
            this.PedtoCheck = this.Bike2;
          }
          if (num1 == 3)
          {
            this.VehicleWithCargo = "C";
            this.PedtoCheck = this.Bike3;
          }
          if (num1 == 4)
          {
            this.VehicleWithCargo = "D";
            this.PedtoCheck = this.Bike4;
          }
          if (num1 == 5)
          {
            this.VehicleWithCargo = "E";
            this.PedtoCheck = this.Bike5;
          }
          this.GotBreefCase = false;
          this.SpawnedBreefcase = false;
          this.WaitingforPlayertoPickupCase = false;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
        }
        if (item == Mission2)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
          if ((Entity) this.BreefCase != (Entity) null)
            this.BreefCase.Delete();
          if (this.CaseBlip != (Blip) null)
            this.CaseBlip.Remove();
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
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(250f));
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn1.Around(250f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn2.Around(250f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn3.Around(250f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn4.Around(250f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.GunCar;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          int num1 = this.ChooseCar();
          if (num1 == 1)
          {
            this.VehicleWithCargo = "A";
            this.PedtoCheck = this.Bike1;
          }
          if (num1 == 2)
          {
            this.VehicleWithCargo = "B";
            this.PedtoCheck = this.Bike2;
          }
          if (num1 == 3)
          {
            this.VehicleWithCargo = "C";
            this.PedtoCheck = this.Bike3;
          }
          if (num1 == 4)
          {
            this.VehicleWithCargo = "D";
            this.PedtoCheck = this.Bike4;
          }
          if (num1 == 5)
          {
            this.VehicleWithCargo = "E";
            this.PedtoCheck = this.Bike5;
          }
          this.GotBreefCase = false;
          this.SpawnedBreefcase = false;
          this.WaitingforPlayertoPickupCase = false;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
        }
        if (item == Mission3)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
          if ((Entity) this.BreefCase != (Entity) null)
            this.BreefCase.Delete();
          if (this.CaseBlip != (Blip) null)
            this.CaseBlip.Remove();
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
          this.Spawn = new Vector3(-267f, -1135f, 23f);
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.GunCar;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          int num1 = this.ChooseCar();
          if (num1 == 1)
          {
            this.VehicleWithCargo = "A";
            this.PedtoCheck = this.Bike1;
          }
          if (num1 == 2)
          {
            this.VehicleWithCargo = "B";
            this.PedtoCheck = this.Bike2;
          }
          if (num1 == 3)
          {
            this.VehicleWithCargo = "C";
            this.PedtoCheck = this.Bike3;
          }
          if (num1 == 4)
          {
            this.VehicleWithCargo = "D";
            this.PedtoCheck = this.Bike4;
          }
          if (num1 == 5)
          {
            this.VehicleWithCargo = "E";
            this.PedtoCheck = this.Bike5;
          }
          this.GotBreefCase = false;
          this.SpawnedBreefcase = false;
          this.WaitingforPlayertoPickupCase = false;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
        }
        if (item == Mission4)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
          if ((Entity) this.BreefCase != (Entity) null)
            this.BreefCase.Delete();
          if (this.CaseBlip != (Blip) null)
            this.CaseBlip.Remove();
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
          this.Spawn = new Vector3(-267f, -1135f, 23f);
          this.Spawn = this.Spawn.Around((float) new System.Random().Next(50, 600));
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.GunCar;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          int num1 = this.ChooseCar();
          if (num1 == 1)
          {
            this.VehicleWithCargo = "A";
            this.PedtoCheck = this.Bike1;
          }
          if (num1 == 2)
          {
            this.VehicleWithCargo = "B";
            this.PedtoCheck = this.Bike2;
          }
          if (num1 == 3)
          {
            this.VehicleWithCargo = "C";
            this.PedtoCheck = this.Bike3;
          }
          if (num1 == 4)
          {
            this.VehicleWithCargo = "D";
            this.PedtoCheck = this.Bike4;
          }
          if (num1 == 5)
          {
            this.VehicleWithCargo = "E";
            this.PedtoCheck = this.Bike5;
          }
          this.GotBreefCase = false;
          this.SpawnedBreefcase = false;
          this.WaitingforPlayertoPickupCase = false;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
        }
        if (item == Mission5)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
          if ((Entity) this.BreefCase != (Entity) null)
            this.BreefCase.Delete();
          if (this.CaseBlip != (Blip) null)
            this.CaseBlip.Remove();
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
          this.Spawn = new Vector3(918.912f, 3536.173f, 34f);
          this.Spawn = this.Spawn.Around((float) new System.Random().Next(50, 600));
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.GunCar;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          int num1 = this.ChooseCar();
          if (num1 == 1)
          {
            this.VehicleWithCargo = "A";
            this.PedtoCheck = this.Bike1;
          }
          if (num1 == 2)
          {
            this.VehicleWithCargo = "B";
            this.PedtoCheck = this.Bike2;
          }
          if (num1 == 3)
          {
            this.VehicleWithCargo = "C";
            this.PedtoCheck = this.Bike3;
          }
          if (num1 == 4)
          {
            this.VehicleWithCargo = "D";
            this.PedtoCheck = this.Bike4;
          }
          if (num1 == 5)
          {
            this.VehicleWithCargo = "E";
            this.PedtoCheck = this.Bike5;
          }
          this.GotBreefCase = false;
          this.SpawnedBreefcase = false;
          this.WaitingforPlayertoPickupCase = false;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
        }
        if (item == Mission6)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
          if ((Entity) this.BreefCase != (Entity) null)
            this.BreefCase.Delete();
          if (this.CaseBlip != (Blip) null)
            this.CaseBlip.Remove();
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
          this.Spawn = new Vector3(-1355f, 2022f, 50f);
          this.Spawn = this.Spawn.Around((float) new System.Random().Next(50, 600));
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.GunCar;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          int num1 = this.ChooseCar();
          if (num1 == 1)
          {
            this.VehicleWithCargo = "A";
            this.PedtoCheck = this.Bike1;
          }
          if (num1 == 2)
          {
            this.VehicleWithCargo = "B";
            this.PedtoCheck = this.Bike2;
          }
          if (num1 == 3)
          {
            this.VehicleWithCargo = "C";
            this.PedtoCheck = this.Bike3;
          }
          if (num1 == 4)
          {
            this.VehicleWithCargo = "D";
            this.PedtoCheck = this.Bike4;
          }
          if (num1 == 5)
          {
            this.VehicleWithCargo = "E";
            this.PedtoCheck = this.Bike5;
          }
          this.GotBreefCase = false;
          this.SpawnedBreefcase = false;
          this.WaitingforPlayertoPickupCase = false;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
        }
        if (item == Mission8)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
          if ((Entity) this.BreefCase != (Entity) null)
            this.BreefCase.Delete();
          if (this.CaseBlip != (Blip) null)
            this.CaseBlip.Remove();
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
          this.Spawn = new Vector3(-173.6f, 6354.377f, 31.4f);
          this.Spawn = this.Spawn.Around((float) new System.Random().Next(50, 600));
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.GunCar;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          int num1 = this.ChooseCar();
          if (num1 == 1)
          {
            this.VehicleWithCargo = "A";
            this.PedtoCheck = this.Bike1;
          }
          if (num1 == 2)
          {
            this.VehicleWithCargo = "B";
            this.PedtoCheck = this.Bike2;
          }
          if (num1 == 3)
          {
            this.VehicleWithCargo = "C";
            this.PedtoCheck = this.Bike3;
          }
          if (num1 == 4)
          {
            this.VehicleWithCargo = "D";
            this.PedtoCheck = this.Bike4;
          }
          if (num1 == 5)
          {
            this.VehicleWithCargo = "E";
            this.PedtoCheck = this.Bike5;
          }
          this.GotBreefCase = false;
          this.SpawnedBreefcase = false;
          this.WaitingforPlayertoPickupCase = false;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
        }
        if (item == Mission9)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
          if ((Entity) this.BreefCase != (Entity) null)
            this.BreefCase.Delete();
          if (this.CaseBlip != (Blip) null)
            this.CaseBlip.Remove();
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
          this.Spawn = new Vector3(2071.485f, 5007.042f, 40.99f);
          this.Spawn = this.Spawn.Around((float) new System.Random().Next(50, 600));
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(50f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.GunCar;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.GunCar;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.GunCar;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.GunCar;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          int num1 = this.ChooseCar();
          if (num1 == 1)
          {
            this.VehicleWithCargo = "A";
            this.PedtoCheck = this.Bike1;
          }
          if (num1 == 2)
          {
            this.VehicleWithCargo = "B";
            this.PedtoCheck = this.Bike2;
          }
          if (num1 == 3)
          {
            this.VehicleWithCargo = "C";
            this.PedtoCheck = this.Bike3;
          }
          if (num1 == 4)
          {
            this.VehicleWithCargo = "D";
            this.PedtoCheck = this.Bike4;
          }
          if (num1 == 5)
          {
            this.VehicleWithCargo = "E";
            this.PedtoCheck = this.Bike5;
          }
          this.GotBreefCase = false;
          this.SpawnedBreefcase = false;
          this.WaitingforPlayertoPickupCase = false;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
        }
        if (item != Mission7)
          return;
        this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
        this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
        this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
        this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
        this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
        if ((Entity) this.BreefCase != (Entity) null)
          this.BreefCase.Delete();
        if (this.CaseBlip != (Blip) null)
          this.CaseBlip.Remove();
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
        this.Spawn = this.GetRandomlocation();
        Script.Wait(1);
        this.Spawn1 = this.GetRandomlocation();
        Script.Wait(1);
        this.Spawn2 = this.GetRandomlocation();
        Script.Wait(1);
        this.Spawn3 = this.GetRandomlocation();
        Script.Wait(1);
        this.Spawn4 = this.GetRandomlocation();
        this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn.Around(250f));
        this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn1.Around(250f));
        this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn2.Around(250f));
        this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn3.Around(250f));
        this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan2, this.Spawn4.Around(250f));
        Script.Wait(500);
        this.Bike1.PlaceOnNextStreet();
        this.Bike2.PlaceOnNextStreet();
        this.Bike3.PlaceOnNextStreet();
        this.Bike4.PlaceOnNextStreet();
        this.Bike5.PlaceOnNextStreet();
        this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike1.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
        this.Bike1.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
        this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike2.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
        this.Bike2.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
        this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike3.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
        this.Bike3.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
        this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike4.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
        this.Bike4.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
        this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike5.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.BallaEast01GMY);
        this.Bike5.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ArmGoon02GMY);
        this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
        this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear), false);
        this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.RightRear), false);
        this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
        this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear), false);
        this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.RightRear), false);
        this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
        this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear), false);
        this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.RightRear), false);
        this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
        this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear), false);
        this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.RightRear), false);
        this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
        this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear), false);
        this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.RightRear), false);
        foreach (Ped ped1 in this.PG)
        {
          if ((Entity) ped1 != (Entity) null)
          {
            Ped ped2 = ped1;
            int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
            Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
          }
        }
        this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
        this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike1.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
        this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike1.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 150f, 1);
        this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
        this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike2.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
        this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike2.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 150f, 1);
        this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike3.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
        this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike3.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 150f, 1);
        this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
        this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike4.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
        this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike4.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 150f, 1);
        this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike5.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(Game.Player.Character);
        this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
        this.Bike5.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(Game.Player.Character);
        this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
        this.Bike1Blip.Sprite = BlipSprite.GunCar;
        this.Bike1Blip.Name = "Enemy Biker A";
        this.Bike1Blip.Color = BlipColor.Red;
        this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
        this.Bike2Blip.Sprite = BlipSprite.GunCar;
        this.Bike2Blip.Name = "Enemy Biker B";
        this.Bike2Blip.Color = BlipColor.Red;
        this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
        this.Bike3Blip.Sprite = BlipSprite.GunCar;
        this.Bike3Blip.Name = "Enemy Biker C";
        this.Bike3Blip.Color = BlipColor.Red;
        this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
        this.Bike4Blip.Sprite = BlipSprite.GunCar;
        this.Bike4Blip.Name = "Enemy Biker D";
        this.Bike4Blip.Color = BlipColor.Red;
        this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
        this.Bike5Blip.Sprite = BlipSprite.GunCar;
        this.Bike5Blip.Name = "Enemy Biker E";
        this.Bike5Blip.Color = BlipColor.Red;
        int num2 = this.ChooseCar();
        if (num2 == 1)
        {
          this.VehicleWithCargo = "A";
          this.PedtoCheck = this.Bike1;
        }
        if (num2 == 2)
        {
          this.VehicleWithCargo = "B";
          this.PedtoCheck = this.Bike2;
        }
        if (num2 == 3)
        {
          this.VehicleWithCargo = "C";
          this.PedtoCheck = this.Bike3;
        }
        if (num2 == 4)
        {
          this.VehicleWithCargo = "D";
          this.PedtoCheck = this.Bike4;
        }
        if (num2 == 5)
        {
          this.VehicleWithCargo = "E";
          this.PedtoCheck = this.Bike5;
        }
        this.GotBreefCase = false;
        this.SpawnedBreefcase = false;
        this.WaitingforPlayertoPickupCase = false;
        this.VehicleSetup2 = true;
        this.vehiclemissionid = 9;
        UI.Notify(this.GetHostName() + " one of these vehicles is carring special cargo, destroy each one, till the cargo drops, collect the case to finish");
      });
    }

    private void SetupBikerRivalry()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.BikerRivallry, "Biker Rivally Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (Zombie Bobber)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 (Slamvan)");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Mission 3 (Duneloader)");
      uiMenu.AddItem(Mission3);
      UIMenuItem Mission4 = new UIMenuItem("Mission 4 (Innovation)");
      uiMenu.AddItem(Mission4);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission1)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
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
          this.Spawn = this.GetRandomlocation();
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.ZombieB, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.ZombieB, this.Spawn1);
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.ZombieB, this.Spawn2);
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.ZombieB, this.Spawn3);
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.ZombieB, this.Spawn4);
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.PersonalVehicleBike;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.PersonalVehicleBike;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.PersonalVehicleBike;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.PersonalVehicleBike;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.PersonalVehicleBike;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 8;
          UI.Notify(this.GetHostName() + " A bunch of bikers are riding around LS , go teach them a lesson");
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
        }
        if (item == Mission2)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
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
          this.Spawn = this.GetRandomlocation();
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.SlamVan, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.SlamVan, this.Spawn.Around(5f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.SlamVan, this.Spawn.Around(5f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.SlamVan, this.Spawn.Around(5f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.SlamVan, this.Spawn.Around(5f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.Truck;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.Truck;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.Truck;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.Truck;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.Truck;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 8;
          UI.Notify(this.GetHostName() + " A bunch of bikers are riding around LS , go teach them a lesson");
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
        }
        if (item == Mission3)
        {
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
          this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
          this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
          this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
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
          this.Spawn = this.GetRandomlocation();
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.DLoader, this.Spawn);
          this.Bike2 = World.CreateVehicle((Model) VehicleHash.DLoader, this.Spawn.Around(5f));
          this.Bike3 = World.CreateVehicle((Model) VehicleHash.DLoader, this.Spawn.Around(5f));
          this.Bike4 = World.CreateVehicle((Model) VehicleHash.DLoader, this.Spawn.Around(5f));
          this.Bike5 = World.CreateVehicle((Model) VehicleHash.DLoader, this.Spawn.Around(5f));
          Script.Wait(500);
          this.Bike1.PlaceOnNextStreet();
          this.Bike2.PlaceOnNextStreet();
          this.Bike3.PlaceOnNextStreet();
          this.Bike4.PlaceOnNextStreet();
          this.Bike5.PlaceOnNextStreet();
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
          this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
          this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
          this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 150f, 1);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 150f, 1);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 150f, 1);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
          this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 150f, 1);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
          this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.Truck;
          this.Bike1Blip.Name = "Enemy Biker A";
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
          this.Bike2Blip.Sprite = BlipSprite.Truck;
          this.Bike2Blip.Name = "Enemy Biker B";
          this.Bike2Blip.Color = BlipColor.Red;
          this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
          this.Bike3Blip.Sprite = BlipSprite.Truck;
          this.Bike3Blip.Name = "Enemy Biker C";
          this.Bike3Blip.Color = BlipColor.Red;
          this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
          this.Bike4Blip.Sprite = BlipSprite.Truck;
          this.Bike4Blip.Name = "Enemy Biker D";
          this.Bike4Blip.Color = BlipColor.Red;
          this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
          this.Bike5Blip.Sprite = BlipSprite.Truck;
          this.Bike5Blip.Name = "Enemy Biker E";
          this.Bike5Blip.Color = BlipColor.Red;
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 8;
          UI.Notify(this.GetHostName() + " A bunch of bikers are riding around LS , go teach them a lesson");
          foreach (Ped ped1 in this.PG)
          {
            if ((Entity) ped1 != (Entity) null)
            {
              Ped ped2 = ped1;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
            }
          }
        }
        if (item != Mission4)
          return;
        this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
        this.Spawn1 = new Vector3(2688.31f, 5127.53f, 45f);
        this.Spawn2 = new Vector3(2694.31f, 5127.53f, 45f);
        this.Spawn3 = new Vector3(2696.31f, 5127.53f, 45f);
        this.Spawn4 = new Vector3(2700.31f, 5127.53f, 45f);
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
        this.Spawn = this.GetRandomlocation();
        this.Bike1 = World.CreateVehicle((Model) VehicleHash.Innovation, this.Spawn);
        this.Bike2 = World.CreateVehicle((Model) VehicleHash.Innovation, this.Spawn.Around(5f));
        this.Bike3 = World.CreateVehicle((Model) VehicleHash.Innovation, this.Spawn.Around(5f));
        this.Bike4 = World.CreateVehicle((Model) VehicleHash.Innovation, this.Spawn.Around(5f));
        this.Bike5 = World.CreateVehicle((Model) VehicleHash.Innovation, this.Spawn.Around(5f));
        Script.Wait(500);
        this.Bike1.PlaceOnNextStreet();
        this.Bike2.PlaceOnNextStreet();
        this.Bike3.PlaceOnNextStreet();
        this.Bike4.PlaceOnNextStreet();
        this.Bike5.PlaceOnNextStreet();
        this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike4.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike4.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.Bike5.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
        this.Bike5.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ArmGoon02GMY);
        this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Driver), true);
        this.PG.Add(this.Bike1.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Driver), false);
        this.PG.Add(this.Bike2.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Driver), false);
        this.PG.Add(this.Bike3.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Driver), false);
        this.PG.Add(this.Bike4.GetPedOnSeat(VehicleSeat.Passenger), false);
        this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Driver), false);
        this.PG.Add(this.Bike5.GetPedOnSeat(VehicleSeat.Passenger), false);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike1.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 150f, 1);
        this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike2.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 150f, 1);
        this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
        this.Bike2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike3.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointB, 60f, 150f, 1);
        this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike4.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 150f, 1);
        this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
        this.Bike4.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Bike5.GetPedOnSeat(VehicleSeat.Driver), (InputArgument) 17, (InputArgument) 1);
        this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 150f, 1);
        this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
        this.Bike5.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
        this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
        this.Bike1Blip.Sprite = BlipSprite.PersonalVehicleBike;
        this.Bike1Blip.Name = "Enemy Biker A";
        this.Bike1Blip.Color = BlipColor.Red;
        this.Bike2Blip = World.CreateBlip(this.Bike2.Position);
        this.Bike2Blip.Sprite = BlipSprite.PersonalVehicleBike;
        this.Bike2Blip.Name = "Enemy Biker B";
        this.Bike2Blip.Color = BlipColor.Red;
        this.Bike3Blip = World.CreateBlip(this.Bike3.Position);
        this.Bike3Blip.Sprite = BlipSprite.PersonalVehicleBike;
        this.Bike3Blip.Name = "Enemy Biker C";
        this.Bike3Blip.Color = BlipColor.Red;
        this.Bike4Blip = World.CreateBlip(this.Bike4.Position);
        this.Bike4Blip.Sprite = BlipSprite.PersonalVehicleBike;
        this.Bike4Blip.Name = "Enemy Biker D";
        this.Bike4Blip.Color = BlipColor.Red;
        this.Bike5Blip = World.CreateBlip(this.Bike5.Position);
        this.Bike5Blip.Sprite = BlipSprite.PersonalVehicleBike;
        this.Bike5Blip.Name = "Enemy Biker E";
        this.Bike5Blip.Color = BlipColor.Red;
        this.VehicleSetup2 = true;
        this.vehiclemissionid = 8;
        UI.Notify(this.GetHostName() + " A bunch of bikers are riding around LS , go teach them a lesson");
        foreach (Ped ped1 in this.PG)
        {
          if ((Entity) ped1 != (Entity) null)
          {
            Ped ped2 = ped1;
            int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped2, (InputArgument) num);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped2, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped2, (InputArgument) 1);
            Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped2, (InputArgument) 1);
          }
        }
      });
    }

    private void SetupWeaponsShop()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.WeaponsShop, "Weapons");
      this.GUIMenus.Add(uiMenu1);
      UIMenuItem DBS = new UIMenuItem("Double Barrel Shotgun: $15,450");
      uiMenu1.AddItem(DBS);
      UIMenuItem Autoshotgun = new UIMenuItem("Sweeper Shotgun: $14,900");
      uiMenu1.AddItem(Autoshotgun);
      UIMenuItem CGrenadeLauncher = new UIMenuItem("Compact Grenade Launcher: $45,000");
      uiMenu1.AddItem(CGrenadeLauncher);
      UIMenuItem CRifle = new UIMenuItem("Compact Rifle: $14,650");
      uiMenu1.AddItem(CRifle);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.WeaponsShop, "Ammo");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem ShotgunShells = new UIMenuItem("Shotgun Shells x24: $96");
      uiMenu2.AddItem(ShotgunShells);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == CRifle)
        {
          if (Game.Player.Money > 14650)
          {
            Game.Player.Money -= 14650;
            Game.Player.Character.Weapons.Give(WeaponHash.CompactRifle, 300, true, true);
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this weapon");
        }
        if (item == Autoshotgun)
        {
          if (Game.Player.Money > 14900)
          {
            Game.Player.Money -= 14900;
            Game.Player.Character.Weapons.Give(WeaponHash.SweeperShotgun, 300, true, true);
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this weapon");
        }
        if (item == CGrenadeLauncher)
        {
          if (Game.Player.Money > 45000)
          {
            Game.Player.Money -= 45000;
            Game.Player.Character.Weapons.Give(WeaponHash.CompactGrenadeLauncher, 20, true, true);
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this weapon");
        }
        if (item != DBS)
          return;
        if (Game.Player.Money > 15450)
        {
          Game.Player.Money -= 15450;
          Game.Player.Character.Weapons.Give(WeaponHash.DoubleBarrelShotgun, 300, true, true);
        }
        else
          UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this weapon");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != ShotgunShells)
          return;
        if (Game.Player.Money > 96)
        {
          Game.Player.Money -= 96;
          Game.Player.Character.Weapons.Give(WeaponHash.DoubleBarrelShotgun, 0, true, true);
          this.currentWeapon = Game.Player.Character.Weapons.Current;
          this.currentWeapon.Ammo += 96;
        }
        else
          UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this weapon");
      });
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      try
      {
        if (this.CurrentViewingBusinessBlip != (Blip) null)
          this.CurrentViewingBusinessBlip.Remove();
        if (this.WarehouseCam != (Camera) null)
        {
          World.RenderingCamera = this.WarehouseCam;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.WarehouseCam.IsActive = false;
          this.WarehouseCam.Destroy();
          Game.Player.Character.FreezePosition = false;
        }
        if ((Entity) this.ChairProp != (Entity) null)
          this.ChairProp.Delete();
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
      if ((Entity) this.ChairProp != (Entity) null)
        this.ChairProp.Delete();
      if (this.CaseBlip != (Blip) null)
        this.CaseBlip.Remove();
      if (this.Enemy != (Blip) null)
        this.Enemy.Remove();
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
      if ((Entity) this.ClayPed != (Entity) null)
        this.ClayPed.Delete();
      if (this.ballasBlip1 != (Blip) null)
        this.ballasBlip1.Remove();
      if (this.CaseBlip != (Blip) null)
        this.CaseBlip.Remove();
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
      if (this.Sam1blip != (Blip) null)
        this.Sam1blip.Remove();
      if (this.Sam2blip != (Blip) null)
        this.Sam2blip.Remove();
      if (this.Sam3blip != (Blip) null)
        this.Sam3blip.Remove();
      if ((Entity) this.ClayPed != (Entity) null)
        this.ClayPed.Delete();
      if (this.ballasBlip1 != (Blip) null)
        this.ballasBlip1.Remove();
      if ((Entity) this.LastV != (Entity) null)
        this.LastV.Delete();
      if ((Entity) this.VehicleId != (Entity) null)
        this.VehicleId.Delete();
      if (this.Enemy != (Blip) null)
        this.Enemy.Remove();
      if (this.DeliveryLoc != (Blip) null)
        this.DeliveryLoc.Remove();
      foreach (Prop crate in this.Crates)
      {
        if ((Entity) crate != (Entity) null)
        {
          if (crate.CurrentBlip != (Blip) null)
            crate.CurrentBlip.Remove();
          crate.Delete();
        }
      }
      if ((Entity) this.Plane != (Entity) null)
        this.Plane.Delete();
      if ((Entity) this.Target != (Entity) null)
        this.Target.Delete();
      if ((Entity) this.TargetsCar != (Entity) null)
        this.TargetsCar.Delete();
      if (this.TargetCarBlip != (Blip) null)
        this.TargetCarBlip.Remove();
      foreach (Vehicle viPcar in this.VIPcars)
      {
        if ((Entity) viPcar != (Entity) null)
          viPcar.Delete();
      }
      if (this.CourthouseBlip != (Blip) null)
        this.CourthouseBlip.Remove();
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      foreach (Blip guardBlip in this.GuardBlips)
      {
        if (guardBlip != (Blip) null)
          guardBlip.Remove();
      }
      foreach (Ped guard in this.Guards)
      {
        if ((Entity) guard != (Entity) null)
          guard.Delete();
      }
      if (this.CaseBlip != (Blip) null)
        this.CaseBlip.Remove();
      if (this.Enemy != (Blip) null)
        this.Enemy.Remove();
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
      if ((Entity) this.ClayPed != (Entity) null)
        this.ClayPed.Delete();
    }

    public void SetupMarker()
    {
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
        this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
        this.HexerBought = this.Config.GetValue<int>("Setup", "HexerBought", this.HexerBought);
        this.AvurusBought = this.Config.GetValue<int>("Setup", "AvurusBought", this.AvurusBought);
        this.ChimeaBought = this.Config.GetValue<int>("Setup", "ChimeaBought", this.ChimeaBought);
        this.SanctusBought = this.Config.GetValue<int>("Setup", "SanctusBought", this.SanctusBought);
        this.InnovationBought = this.Config.GetValue<int>("Setup", "InnovationBought", this.InnovationBought);
        this.lccdaemonBought = this.Config.GetValue<int>("Setup", "lccdaemonBought", this.lccdaemonBought);
        this.DaemonBought = this.Config.GetValue<int>("Setup", "DaemonBought", this.DaemonBought);
        this.NightbladeBought = this.Config.GetValue<int>("Setup", "NightbladeBought", this.NightbladeBought);
        this.WolfsbaneBought = this.Config.GetValue<int>("Setup", "WolfsbaneBought", this.WolfsbaneBought);
        this.ratbikebought = this.Config.GetValue<int>("Setup", "ratbikebought", this.ratbikebought);
        this.duneBought = this.Config.GetValue<int>("Setup", "duneBought", this.duneBought);
        this.DuneLoaderBought = this.Config.GetValue<int>("Setup", "DuneLoaderBought", this.DuneLoaderBought);
        this.SlamvanBought = this.Config.GetValue<int>("Setup", "SlamvanBought", this.SlamvanBought);
        this.ZombieCBought = this.Config.GetValue<int>("Setup", "ZombieCBought", this.ZombieCBought);
        this.ZombieBBought = this.Config.GetValue<int>("Setup", "ZombieBBought", this.ZombieBBought);
        this.ForgeryBought = this.Config.GetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought);
        this.WeedFarmBought = this.Config.GetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought);
        this.MoneyPrinterBought = this.Config.GetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought);
        this.MethLabBought = this.Config.GetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought);
        this.CocaineBought = this.Config.GetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought);
        this.maxstocks = 10 * this.purchaselvl;
        float num = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
        this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
        this.increaseGain = num;
        this.ChairPropModel = this.Config.GetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void SetupProduct()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.ProductStock, "Buy/Sell Product");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Buy2 = new UIMenuItem("Buy X10: +250000");
      uiMenu.AddItem(Buy2);
      UIMenuItem Buy = new UIMenuItem("Buy X1: +25000");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          UI.Notify(this.GetHostName() + " Here is where we are at");
          UI.Notify("Level: " + this.purchaselvl.ToString() + "/10");
          UI.Notify("Max Stocks: " + this.maxstocks.ToString());
          UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
          UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
          UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
        }
        if (item == Buy2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          if (this.stockscount + 10 < this.maxstocks)
          {
            if (Game.Player.Money > 250000)
            {
              Game.Player.Money -= 250000;
              this.stocksvalue += 250000f;
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          if (this.stockscount != this.maxstocks)
          {
            if (Game.Player.Money > 25000)
            {
              Game.Player.Money -= 25000;
              this.stocksvalue += 25000f;
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
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
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.TipTruck, this.CurrentGarage, 0.0f);
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
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Flatbed, this.CurrentGarage, 0.0f);
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
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Guardian, this.CurrentGarage, 0.0f);
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
          foreach (Vector3 position in this.DropPoint)
          {
            Blip blip = World.CreateBlip(position);
            blip.Sprite = BlipSprite.SpecialCargo;
            blip.Name = "Cargo Sell Deliver Point";
            blip.Color = BlipColor.Blue4;
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
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
          foreach (Vector3 position in this.DropPoint)
          {
            Blip blip = World.CreateBlip(position);
            blip.Name = "Steal Cargo Vehicle";
            blip.Color = BlipColor.Blue4;
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
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
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        UI.Notify(this.GetHostName() + " ok i can deal with that, selling all product avalable");
        Game.Player.Money += (int) ((double) this.stocksvalue * 0.75);
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
    }

    private void SetupGarage()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.BikesGarage, "Bikes");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.BikesGarage, "Cars");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem Avarus = new UIMenuItem("Avarus : $116,000, " + this.AvurusBought.ToString());
      uiMenu1.AddItem(Avarus);
      UIMenuItem Hexer = new UIMenuItem("Hexer: $15,000, Stock: " + this.HexerBought.ToString());
      uiMenu1.AddItem(Hexer);
      UIMenuItem Chimera = new UIMenuItem("Chimera: $210,000, Stock: " + this.ChimeaBought.ToString());
      uiMenu1.AddItem(Chimera);
      UIMenuItem Sanctus = new UIMenuItem("Sanctus: $1,995,000, Stock: " + this.SanctusBought.ToString());
      uiMenu1.AddItem(Sanctus);
      UIMenuItem inovation = new UIMenuItem("Innovation: $92,500, Stock: " + this.InnovationBought.ToString());
      uiMenu1.AddItem(inovation);
      UIMenuItem Daemon = new UIMenuItem("Daemon : $145,000, Stock: " + this.DaemonBought.ToString());
      uiMenu1.AddItem(Daemon);
      UIMenuItem LccDaemon = new UIMenuItem("Lcc Daemon : $45,000, Stock: " + this.lccdaemonBought.ToString());
      uiMenu1.AddItem(LccDaemon);
      UIMenuItem NightBlade = new UIMenuItem("NightBlade : $100,000, Stock: " + this.NightbladeBought.ToString());
      uiMenu1.AddItem(NightBlade);
      UIMenuItem RatBike = new UIMenuItem("RatBike : $48,000, Stock: " + this.ratbikebought.ToString());
      uiMenu1.AddItem(RatBike);
      UIMenuItem Wolfsbane = new UIMenuItem("Wolfsbane : $95,000, Stock: " + this.WolfsbaneBought.ToString());
      uiMenu1.AddItem(Wolfsbane);
      UIMenuItem ZombieB = new UIMenuItem("Zombie Bobber : $99,000, Stock: " + this.ZombieBBought.ToString());
      uiMenu1.AddItem(ZombieB);
      UIMenuItem ZombieC = new UIMenuItem("Zombie Chopper : $122,000, Stock: " + this.ZombieCBought.ToString());
      uiMenu1.AddItem(ZombieC);
      UIMenuItem Dune = new UIMenuItem("Dune : $12,000, Stock: " + this.duneBought.ToString());
      uiMenu2.AddItem(Dune);
      UIMenuItem DuneLoader = new UIMenuItem("Dune Loader : $14,000, Stock: " + this.DuneLoaderBought.ToString());
      uiMenu2.AddItem(DuneLoader);
      UIMenuItem Slamvan = new UIMenuItem("Lost Slamvan : 22,000, Stock: " + this.SlamvanBought.ToString());
      uiMenu2.AddItem(Slamvan);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Slamvan)
        {
          if (this.SlamvanBought != 1)
          {
            if (Game.Player.Money > 22000)
            {
              Game.Player.Money -= 22000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.SlamVan2, new Vector3(1333f, 4375f, 44f), -83f);
              this.SlamvanBought = 1;
              this.Config.SetValue<int>("Setup", "SlamvanBought", this.SlamvanBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.SlamvanBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.SlamVan2, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == DuneLoader)
        {
          if (this.DuneLoaderBought != 1)
          {
            if (Game.Player.Money > 14000)
            {
              Game.Player.Money -= 14000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.DLoader, new Vector3(1333f, 4375f, 44f), -83f);
              this.DuneLoaderBought = 1;
              this.Config.SetValue<int>("Setup", "DuneLoaderBought", this.DuneLoaderBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.DuneLoaderBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.DLoader, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item != Dune)
          return;
        if (this.duneBought != 1)
        {
          if (Game.Player.Money > 12000)
          {
            Game.Player.Money -= 12000;
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Dune2, new Vector3(1333f, 4375f, 44f), -83f);
            this.duneBought = 1;
            this.Config.SetValue<int>("Setup", "duneBought", this.duneBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
        }
        if (this.duneBought == 1)
        {
          if ((Entity) this.LastV != (Entity) null)
            this.LastV.Delete();
          this.LastV = World.CreateVehicle((Model) VehicleHash.DLoader, new Vector3(1333f, 4375f, 44f), -83f);
        }
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ZombieC)
        {
          if (this.ZombieCBought != 1)
          {
            if (Game.Player.Money > 122000)
            {
              Game.Player.Money -= 122000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.ZombieB, new Vector3(1333f, 4375f, 44f), -83f);
              this.ZombieCBought = 1;
              this.Config.SetValue<int>("Setup", "ZombieCBought", this.ZombieCBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.ZombieCBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.ZombieB, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == ZombieB)
        {
          if (this.ZombieBBought != 1)
          {
            if (Game.Player.Money > 99000)
            {
              Game.Player.Money -= 99000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.ZombieA, new Vector3(1333f, 4375f, 44f), -83f);
              this.ZombieBBought = 1;
              this.Config.SetValue<int>("Setup", "ZombieBBought", this.ZombieBBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.ZombieBBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.ZombieA, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == Wolfsbane)
        {
          if (this.WolfsbaneBought != 1)
          {
            if (Game.Player.Money > 95000)
            {
              Game.Player.Money -= 95000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.Wolfsbane, new Vector3(1333f, 4375f, 44f), -83f);
              this.WolfsbaneBought = 1;
              this.Config.SetValue<int>("Setup", "WolfsbaneBought", this.WolfsbaneBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.WolfsbaneBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Wolfsbane, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == RatBike)
        {
          if (this.ratbikebought != 1)
          {
            if (Game.Player.Money > 48000)
            {
              Game.Player.Money -= 48000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.RatBike, new Vector3(1333f, 4375f, 44f), -83f);
              this.ratbikebought = 1;
              this.Config.SetValue<int>("Setup", "ratbikebought", this.ratbikebought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.ratbikebought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.RatBike, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == NightBlade)
        {
          if (this.NightbladeBought != 1)
          {
            if (Game.Player.Money > 100000)
            {
              Game.Player.Money -= 100000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.Nightblade, new Vector3(1333f, 4375f, 44f), -83f);
              this.NightbladeBought = 1;
              this.Config.SetValue<int>("Setup", "NightbladeBought", this.NightbladeBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.NightbladeBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Nightblade, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == LccDaemon)
        {
          if (this.lccdaemonBought != 1)
          {
            if (Game.Player.Money > 45000)
            {
              Game.Player.Money -= 45000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.Daemon2, new Vector3(1333f, 4375f, 44f), -83f);
              this.lccdaemonBought = 1;
              this.Config.SetValue<int>("Setup", "lccdaemonBought", this.lccdaemonBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.lccdaemonBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Daemon2, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == Daemon)
        {
          if (this.DaemonBought != 1)
          {
            if (Game.Player.Money > 145000)
            {
              Game.Player.Money -= 145000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.Daemon, new Vector3(1333f, 4375f, 44f), -83f);
              this.DaemonBought = 1;
              this.Config.SetValue<int>("Setup", "DaemonBought", this.DaemonBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.DaemonBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Daemon, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == inovation)
        {
          if (this.InnovationBought != 1)
          {
            if (Game.Player.Money > 92500)
            {
              Game.Player.Money -= 92500;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.Innovation, new Vector3(1333f, 4375f, 44f), -83f);
              this.InnovationBought = 1;
              this.Config.SetValue<int>("Setup", "InnovationBought", this.InnovationBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.InnovationBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Innovation, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == Sanctus)
        {
          if (this.SanctusBought != 1)
          {
            if (Game.Player.Money > 1995000)
            {
              Game.Player.Money -= 1995000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.Sanctus, new Vector3(1333f, 4375f, 44f), -83f);
              this.SanctusBought = 1;
              this.Config.SetValue<int>("Setup", "SanctusBought", this.SanctusBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.SanctusBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Sanctus, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == Avarus)
        {
          if (this.AvurusBought != 1)
          {
            if (Game.Player.Money > 116000)
            {
              Game.Player.Money -= 116000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.Avarus, new Vector3(1333f, 4375f, 44f), -83f);
              this.AvurusBought = 1;
              this.Config.SetValue<int>("Setup", "AvurusBought", this.AvurusBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.AvurusBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Avarus, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item == Hexer)
        {
          if (this.HexerBought != 1)
          {
            if (Game.Player.Money > 15000)
            {
              Game.Player.Money -= 15000;
              if ((Entity) this.LastV != (Entity) null)
                this.LastV.Delete();
              this.LastV = World.CreateVehicle((Model) VehicleHash.Hexer, new Vector3(1333f, 4375f, 44f), -83f);
              this.HexerBought = 1;
              this.Config.SetValue<int>("Setup", "HexerBought", this.HexerBought);
              this.Config.Save();
            }
            else
              UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
          }
          if (this.HexerBought == 1)
          {
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Hexer, new Vector3(1333f, 4375f, 44f), -83f);
          }
        }
        if (item != Chimera)
          return;
        if (this.ChimeaBought != 1)
        {
          if (Game.Player.Money > 210000)
          {
            Game.Player.Money -= 210000;
            if ((Entity) this.LastV != (Entity) null)
              this.LastV.Delete();
            this.LastV = World.CreateVehicle((Model) VehicleHash.Chimera, new Vector3(1333f, 4375f, 44f), -83f);
            this.ChimeaBought = 1;
            this.Config.SetValue<int>("Setup", "ChimeaBought", this.ChimeaBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " Sorry Boss you dont have enough money to purchase this bike");
        }
        if (this.ChimeaBought == 1)
        {
          if ((Entity) this.LastV != (Entity) null)
            this.LastV.Delete();
          this.LastV = World.CreateVehicle((Model) VehicleHash.Chimera, new Vector3(1333f, 4375f, 44f), -83f);
        }
      });
    }

    private void Setupbuisness()
    {
      List<object> objectList = new List<object>()
      {
        (object) false,
        (object) true
      };
      List<object> items1 = new List<object>();
      int num1 = 1;
      for (int index = 1; index < 100; ++index)
        items1.Add((object) (num1 + index));
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
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__299.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__299.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.ChairPropModel = Class1.\u003C\u003Eo__299.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__299.\u003C\u003Ep__0, Chairs[MainChairlist.Index]);
        this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
        this.Config.Save();
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__299.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__299.\u003C\u003Ep__2 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, System.Type, object> target = Class1.\u003C\u003Eo__299.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, System.Type, object>> p2 = Class1.\u003C\u003Eo__299.\u003C\u003Ep__2;
        System.Type type = typeof (UI);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__299.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__299.\u003C\u003Ep__1 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__299.\u003C\u003Ep__1.Target((CallSite) Class1.\u003C\u003Eo__299.\u003C\u003Ep__1, "~g~ HKH191~w~  : Main Chair Model has been set to ", Chairs[MainChairlist.Index]);
        target((CallSite) p2, type, obj);
        if (this.ClubhouseChoosen == 1)
        {
          try
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
            if ((Entity) this.ChairProp != (Entity) null)
            {
              vector3 = this.ChairProp.Position;
              num2 = this.ChairProp.Heading;
            }
            this.ChairPos = new Vector3(1008.1f, -3170.258f, -39.93f);
            this.P_Rotation = 90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -129f), false, false);
            this.ChairProp.FreezePosition = true;
            if ((Entity) this.ChairProp != (Entity) null)
            {
              this.ChairProp.Position = vector3;
              this.ChairProp.Heading = num2;
            }
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Error~w~ Could not find Chair Prop Model!, Model has been added to ini, no need to take action");
            UI.Notify("~g~ HKH191~w~ Chair Prop Models Were not found, please Reload the mod ");
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
            this.ChairPropModel = "ex_prop_offchair_exec_01";
            this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
            this.Config.Save();
            this.Config.SetValue<string>("Chair Model", "POSSIBLECHAIRPROPMODELS", "'ex_prop_offchair_exec_01', 'ex_prop_offchair_exec_02', 'ex_prop_offchair_exec_03', 'ex_prop_offchair_exec_04', 'ba_prop_battle_club_chair_01', 'ba_prop_battle_club_chair_02', 'ba_prop_battle_club_chair_03' ");
            this.Config.Save();
          }
        }
        if (this.ClubhouseChoosen == 2)
        {
          try
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
            if ((Entity) this.ChairProp != (Entity) null)
            {
              vector3 = this.ChairProp.Position;
              num2 = this.ChairProp.Heading;
            }
            this.ChairPos = new Vector3(1116.2f, -3161f, -37.8f);
            this.P_Rotation = -90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 60f), false, false);
            this.ChairProp.FreezePosition = true;
            if ((Entity) this.ChairProp != (Entity) null)
            {
              this.ChairProp.Position = vector3;
              this.ChairProp.Heading = num2;
            }
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Error~w~ Could not find Chair Prop Model!, Model has been added to ini, no need to take action");
            UI.Notify("~g~ HKH191~w~ Chair Prop Models Were not found, please Reload the mod ");
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
            this.ChairPropModel = "ex_prop_offchair_exec_01";
            this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
            this.Config.Save();
            this.Config.SetValue<string>("Chair Model", "POSSIBLECHAIRPROPMODELS", "'ex_prop_offchair_exec_01', 'ex_prop_offchair_exec_02', 'ex_prop_offchair_exec_03', 'ex_prop_offchair_exec_04', 'ba_prop_battle_club_chair_01', 'ba_prop_battle_club_chair_02', 'ba_prop_battle_club_chair_03' ");
            this.Config.Save();
          }
        }
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.methgarage, "Expand Business ");
      this.GUIMenus.Add(uiMenu2);
      List<object> items2 = new List<object>();
      foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocMeth)
        items2.Add((object) businessLocations.Name);
      List<object> items3 = new List<object>();
      foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocCocaine)
        items3.Add((object) businessLocations.Name);
      List<object> items4 = new List<object>();
      foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocWeed)
        items4.Add((object) businessLocations.Name);
      List<object> items5 = new List<object>();
      foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocForgery)
        items5.Add((object) businessLocations.Name);
      List<object> items6 = new List<object>();
      foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocCounterfiet)
        items6.Add((object) businessLocations.Name);
      UIMenu menu = this.modMenuPool.AddSubMenu(this.methgarage, "Buy a MC Business");
      this.GUIMenus.Add(menu);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(menu, "Meth Lab");
      this.GUIMenus.Add(uiMenu3);
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(menu, "Cocaine Lockup");
      this.GUIMenus.Add(uiMenu4);
      UIMenu uiMenu5 = this.modMenuPool.AddSubMenu(menu, "Weed Farm");
      this.GUIMenus.Add(uiMenu5);
      UIMenu uiMenu6 = this.modMenuPool.AddSubMenu(menu, "Counterfeit Office");
      this.GUIMenus.Add(uiMenu6);
      UIMenu uiMenu7 = this.modMenuPool.AddSubMenu(menu, "Fogery Office");
      this.GUIMenus.Add(uiMenu7);
      UIMenuListItem Locations1 = new UIMenuListItem("Location : ", items2, 0);
      uiMenu3.AddItem((UIMenuItem) Locations1);
      UIMenuItem BuyMC1 = new UIMenuItem("Buy MC Business : $0");
      uiMenu3.AddItem(BuyMC1);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != BuyMC1 || !(this.WarehouseCam != (Camera) null))
          return;
        if (this.CurrentViewingBusinessBlip != (Blip) null)
          this.CurrentViewingBusinessBlip.Remove();
        float price = this.MCSubLocMeth[Locations1.Index].Price;
        if ((double) Game.Player.Money >= (double) price)
        {
          this.WCamOn = false;
          Game.Player.Money -= (int) price;
          Game.Player.Character.IsVisible = true;
          this.WarehouseCam.Position = this.MCSubLocMeth[Locations1.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocMeth[Locations1.Index].CameraHeading);
          World.RenderingCamera = this.WarehouseCam;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.WarehouseCam.FarClip = 2000f;
          this.WarehouseCam.IsActive = false;
          this.WarehouseCam.Destroy();
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.FreezePosition = false;
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          Script.Wait(10);
          this.MethMCbusinessLoc = Locations1.Index;
          this.MethLabBought = 1;
          this.Config.SetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought);
          this.Config.Save();
          this.Config.SetValue<int>("SubBusiness", "METHMCBUSINESSLOC", this.MethMCbusinessLoc);
          this.Config.Save();
          Vector3 position = Game.Player.Character.Position;
          Game.Player.Character.Position = new Vector3(274f, 273f, 272f);
          Script.Wait(1);
          Game.Player.Character.Position = position;
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          Script.Wait(1000);
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -100f), false, false);
          this.ChairProp.FreezePosition = true;
          this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
          if (this.ClubhouseChoosen == 1)
          {
            this.ChairPos = new Vector3(1008.1f, -3170.258f, -39.93f);
            this.P_Rotation = 90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -129f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          if (this.ClubhouseChoosen == 2)
          {
            this.ChairPos = new Vector3(1116.2f, -3161f, -37.8f);
            this.P_Rotation = -90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 60f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          Prop chairProp = this.ChairProp;
          Game.Player.Character.Position = chairProp.Position;
          int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num2, (InputArgument) "computer_exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          Game.Player.Character.Alpha = (int) byte.MaxValue;
          Game.Player.Character.IsVisible = true;
          Game.Player.Character.IsVisible = true;
          this.IsSittinginCeoSeat = true;
        }
      });
      uiMenu3.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != Locations1)
          return;
        if (this.WarehouseCam != (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocMeth[Locations1.Index].Enterance);
          blip.Sprite = BlipSprite.Meth;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam.Position = this.MCSubLocMeth[Locations1.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocMeth[Locations1.Index].CameraHeading);
          Game.Player.Character.Position = this.MCSubLocMeth[Locations1.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.IsActive = true;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          BuyMC1.Text = "Buy MC Business : $" + this.MCSubLocMeth[Locations1.Index].Price.ToString("N");
        }
        if (this.WarehouseCam == (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocMeth[Locations1.Index].Enterance);
          blip.Sprite = BlipSprite.Meth;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam = World.CreateCamera(this.MCSubLocMeth[Locations1.Index].CameraPos, new Vector3(0.0f, 0.0f, this.MCSubLocMeth[Locations1.Index].CameraHeading), 100f);
          this.WarehouseCam.Position = this.MCSubLocMeth[Locations1.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocMeth[Locations1.Index].CameraHeading);
          this.WarehouseCam.IsActive = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.Position = this.MCSubLocMeth[Locations1.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
          BuyMC1.Text = "Buy MC Business : $" + this.MCSubLocMeth[Locations1.Index].Price.ToString("N");
        }
      });
      UIMenuListItem Locations2 = new UIMenuListItem("Location : ", items3, 0);
      uiMenu4.AddItem((UIMenuItem) Locations2);
      UIMenuItem BuyMC2 = new UIMenuItem("Buy MC Business : $0");
      uiMenu4.AddItem(BuyMC2);
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != BuyMC2 || !(this.WarehouseCam != (Camera) null))
          return;
        if (this.CurrentViewingBusinessBlip != (Blip) null)
          this.CurrentViewingBusinessBlip.Remove();
        float price = this.MCSubLocCocaine[Locations2.Index].Price;
        if ((double) Game.Player.Money >= (double) price)
        {
          this.WCamOn = false;
          Game.Player.Money -= (int) price;
          Game.Player.Character.IsVisible = true;
          this.WarehouseCam.Position = this.MCSubLocCocaine[Locations2.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocCocaine[Locations2.Index].CameraHeading);
          World.RenderingCamera = this.WarehouseCam;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.WarehouseCam.FarClip = 2000f;
          this.WarehouseCam.IsActive = false;
          this.WarehouseCam.Destroy();
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.FreezePosition = false;
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          Script.Wait(10);
          this.CocaineMCbusinessLoc = Locations2.Index;
          this.CocaineBought = 1;
          this.Config.SetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought);
          this.Config.Save();
          this.Config.SetValue<int>("SubBusiness", "CocaineMCbusinessLoc", this.CocaineMCbusinessLoc);
          this.Config.Save();
          Vector3 position = Game.Player.Character.Position;
          Game.Player.Character.Position = new Vector3(274f, 273f, 272f);
          Script.Wait(1);
          Game.Player.Character.Position = position;
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          Script.Wait(1000);
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -100f), false, false);
          this.ChairProp.FreezePosition = true;
          this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
          if (this.ClubhouseChoosen == 1)
          {
            this.ChairPos = new Vector3(1008.1f, -3170.258f, -39.93f);
            this.P_Rotation = 90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -129f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          if (this.ClubhouseChoosen == 2)
          {
            this.ChairPos = new Vector3(1116.2f, -3161f, -37.8f);
            this.P_Rotation = -90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 60f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          Prop chairProp = this.ChairProp;
          Game.Player.Character.Position = chairProp.Position;
          int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num2, (InputArgument) "computer_exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          Game.Player.Character.Alpha = (int) byte.MaxValue;
          Game.Player.Character.IsVisible = true;
          Game.Player.Character.IsVisible = true;
          this.IsSittinginCeoSeat = true;
        }
      });
      uiMenu4.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != Locations2)
          return;
        if (this.WarehouseCam != (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocCocaine[Locations2.Index].Enterance);
          blip.Sprite = BlipSprite.Cocaine;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam.Position = this.MCSubLocCocaine[Locations2.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocCocaine[Locations2.Index].CameraHeading);
          Game.Player.Character.Position = this.MCSubLocCocaine[Locations2.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.IsActive = true;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          BuyMC2.Text = "Buy MC Business : $" + this.MCSubLocCocaine[Locations2.Index].Price.ToString("N");
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
        }
        if (this.WarehouseCam == (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocCocaine[Locations2.Index].Enterance);
          blip.Sprite = BlipSprite.Cocaine;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam = World.CreateCamera(this.MCSubLocCocaine[Locations2.Index].CameraPos, new Vector3(0.0f, 0.0f, this.MCSubLocCocaine[Locations2.Index].CameraHeading), 100f);
          this.WarehouseCam.Position = this.MCSubLocCocaine[Locations2.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocCocaine[Locations2.Index].CameraHeading);
          this.WarehouseCam.IsActive = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.Position = this.MCSubLocCocaine[Locations2.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
          BuyMC2.Text = "Buy MC Business : $" + this.MCSubLocCocaine[Locations2.Index].Price.ToString("N");
        }
      });
      UIMenuListItem Locations3 = new UIMenuListItem("Location : ", items4, 0);
      uiMenu5.AddItem((UIMenuItem) Locations3);
      UIMenuItem BuyMC3 = new UIMenuItem("Buy MC Business : $0");
      uiMenu5.AddItem(BuyMC3);
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != BuyMC3 || !(this.WarehouseCam != (Camera) null))
          return;
        if (this.CurrentViewingBusinessBlip != (Blip) null)
          this.CurrentViewingBusinessBlip.Remove();
        float price = this.MCSubLocWeed[Locations3.Index].Price;
        if ((double) Game.Player.Money >= (double) price)
        {
          this.WCamOn = false;
          Game.Player.Money -= (int) price;
          Game.Player.Character.IsVisible = true;
          this.WarehouseCam.Position = this.MCSubLocWeed[Locations3.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocWeed[Locations3.Index].CameraHeading);
          World.RenderingCamera = this.WarehouseCam;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.WarehouseCam.FarClip = 2000f;
          this.WarehouseCam.IsActive = false;
          this.WarehouseCam.Destroy();
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.FreezePosition = false;
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          Script.Wait(10);
          this.WeedMCbusinessLoc = Locations3.Index;
          this.WeedFarmBought = 1;
          this.Config.SetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought);
          this.Config.Save();
          this.Config.SetValue<int>("SubBusiness", "WeedMCbusinessLoc", this.WeedMCbusinessLoc);
          this.Config.Save();
          Vector3 position = Game.Player.Character.Position;
          Game.Player.Character.Position = new Vector3(274f, 273f, 272f);
          Script.Wait(1);
          Game.Player.Character.Position = position;
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          Script.Wait(1000);
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -100f), false, false);
          this.ChairProp.FreezePosition = true;
          this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
          if (this.ClubhouseChoosen == 1)
          {
            this.ChairPos = new Vector3(1008.1f, -3170.258f, -39.93f);
            this.P_Rotation = 90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -129f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          if (this.ClubhouseChoosen == 2)
          {
            this.ChairPos = new Vector3(1116.2f, -3161f, -37.8f);
            this.P_Rotation = -90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 60f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          Prop chairProp = this.ChairProp;
          Game.Player.Character.Position = chairProp.Position;
          int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num2, (InputArgument) "computer_exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          Game.Player.Character.Alpha = (int) byte.MaxValue;
          Game.Player.Character.IsVisible = true;
          Game.Player.Character.IsVisible = true;
          this.IsSittinginCeoSeat = true;
        }
      });
      uiMenu5.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != Locations3)
          return;
        if (this.WarehouseCam != (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocWeed[Locations3.Index].Enterance);
          blip.Sprite = BlipSprite.Weed;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam.Position = this.MCSubLocWeed[Locations3.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocWeed[Locations3.Index].CameraHeading);
          Game.Player.Character.Position = this.MCSubLocWeed[Locations3.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.IsActive = true;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          BuyMC3.Text = "Buy MC Business : $" + this.MCSubLocWeed[Locations3.Index].Price.ToString("N");
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
        }
        if (this.WarehouseCam == (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocWeed[Locations3.Index].Enterance);
          blip.Sprite = BlipSprite.Weed;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam = World.CreateCamera(this.MCSubLocWeed[Locations3.Index].CameraPos, new Vector3(0.0f, 0.0f, this.MCSubLocWeed[Locations3.Index].CameraHeading), 100f);
          this.WarehouseCam.Position = this.MCSubLocWeed[Locations3.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocWeed[Locations3.Index].CameraHeading);
          this.WarehouseCam.IsActive = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.Position = this.MCSubLocWeed[Locations3.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
          BuyMC3.Text = "Buy MC Business : $" + this.MCSubLocWeed[Locations3.Index].Price.ToString("N");
        }
      });
      UIMenuListItem Locations4 = new UIMenuListItem("Location : ", items6, 0);
      uiMenu6.AddItem((UIMenuItem) Locations4);
      UIMenuItem BuyMC4 = new UIMenuItem("Buy MC Business : $0");
      uiMenu6.AddItem(BuyMC4);
      uiMenu6.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != BuyMC4 || !(this.WarehouseCam != (Camera) null))
          return;
        if (this.CurrentViewingBusinessBlip != (Blip) null)
          this.CurrentViewingBusinessBlip.Remove();
        float price = this.MCSubLocCounterfiet[Locations4.Index].Price;
        if ((double) Game.Player.Money >= (double) price)
        {
          this.WCamOn = false;
          Game.Player.Money -= (int) price;
          Game.Player.Character.IsVisible = true;
          this.WarehouseCam.Position = this.MCSubLocCounterfiet[Locations4.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocCounterfiet[Locations4.Index].CameraHeading);
          World.RenderingCamera = this.WarehouseCam;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.WarehouseCam.FarClip = 2000f;
          this.WarehouseCam.IsActive = false;
          this.WarehouseCam.Destroy();
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.FreezePosition = false;
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          Script.Wait(10);
          this.CounterfietMCbusinessLoc = Locations4.Index;
          this.MoneyPrinterBought = 1;
          this.Config.SetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought);
          this.Config.Save();
          this.Config.SetValue<int>("SubBusiness", "COUNTERFIETMCBUSINESSLOC", this.CounterfietMCbusinessLoc);
          this.Config.Save();
          Vector3 position = Game.Player.Character.Position;
          Game.Player.Character.Position = new Vector3(274f, 273f, 272f);
          Script.Wait(1);
          Game.Player.Character.Position = position;
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          Script.Wait(1000);
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -100f), false, false);
          this.ChairProp.FreezePosition = true;
          this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
          if (this.ClubhouseChoosen == 1)
          {
            this.ChairPos = new Vector3(1008.1f, -3170.258f, -39.93f);
            this.P_Rotation = 90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -129f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          if (this.ClubhouseChoosen == 2)
          {
            this.ChairPos = new Vector3(1116.2f, -3161f, -37.8f);
            this.P_Rotation = -90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 60f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          Prop chairProp = this.ChairProp;
          Game.Player.Character.Position = chairProp.Position;
          int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num2, (InputArgument) "computer_exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          Game.Player.Character.Alpha = (int) byte.MaxValue;
          Game.Player.Character.IsVisible = true;
          Game.Player.Character.IsVisible = true;
          this.IsSittinginCeoSeat = true;
        }
      });
      uiMenu6.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != Locations4)
          return;
        if (this.WarehouseCam != (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocCounterfiet[Locations4.Index].Enterance);
          blip.Sprite = BlipSprite.DollarBill;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam.Position = this.MCSubLocCounterfiet[Locations4.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocCounterfiet[Locations4.Index].CameraHeading);
          Game.Player.Character.Position = this.MCSubLocCounterfiet[Locations4.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.IsActive = true;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          BuyMC4.Text = "Buy MC Business : $" + this.MCSubLocCounterfiet[Locations4.Index].Price.ToString("N");
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
        }
        if (this.WarehouseCam == (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocCounterfiet[Locations4.Index].Enterance);
          blip.Sprite = BlipSprite.DollarBill;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam = World.CreateCamera(this.MCSubLocCounterfiet[Locations4.Index].CameraPos, new Vector3(0.0f, 0.0f, this.MCSubLocCounterfiet[Locations4.Index].CameraHeading), 100f);
          this.WarehouseCam.Position = this.MCSubLocCounterfiet[Locations4.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocCounterfiet[Locations4.Index].CameraHeading);
          this.WarehouseCam.IsActive = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.Position = this.MCSubLocCounterfiet[Locations4.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
          BuyMC4.Text = "Buy MC Business : $" + this.MCSubLocCounterfiet[Locations4.Index].Price.ToString("N");
        }
      });
      UIMenuListItem Locations5 = new UIMenuListItem("Location : ", items5, 0);
      uiMenu7.AddItem((UIMenuItem) Locations5);
      UIMenuItem BuyMC5 = new UIMenuItem("Buy MC Business : $0");
      uiMenu7.AddItem(BuyMC5);
      uiMenu7.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != BuyMC5 || !(this.WarehouseCam != (Camera) null))
          return;
        if (this.CurrentViewingBusinessBlip != (Blip) null)
          this.CurrentViewingBusinessBlip.Remove();
        float price = this.MCSubLocForgery[Locations5.Index].Price;
        if ((double) Game.Player.Money >= (double) price)
        {
          this.WCamOn = false;
          Game.Player.Money -= (int) price;
          Game.Player.Character.IsVisible = true;
          this.WarehouseCam.Position = this.MCSubLocForgery[Locations5.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocForgery[Locations5.Index].CameraHeading);
          World.RenderingCamera = this.WarehouseCam;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.WarehouseCam.FarClip = 2000f;
          this.WarehouseCam.IsActive = false;
          this.WarehouseCam.Destroy();
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.FreezePosition = false;
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          Script.Wait(10);
          this.ForgeryMCbusinessLoc = Locations5.Index;
          this.ForgeryBought = 1;
          this.Config.SetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought);
          this.Config.Save();
          this.Config.SetValue<int>("SubBusiness", "ForgeryMCbusinessLoc", this.ForgeryMCbusinessLoc);
          this.Config.Save();
          Vector3 position = Game.Player.Character.Position;
          Game.Player.Character.Position = new Vector3(274f, 273f, 272f);
          Script.Wait(1);
          Game.Player.Character.Position = position;
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          Script.Wait(1000);
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -100f), false, false);
          this.ChairProp.FreezePosition = true;
          this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
          if (this.ClubhouseChoosen == 1)
          {
            this.ChairPos = new Vector3(1008.1f, -3170.258f, -39.93f);
            this.P_Rotation = 90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -129f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          if (this.ClubhouseChoosen == 2)
          {
            this.ChairPos = new Vector3(1116.2f, -3161f, -37.8f);
            this.P_Rotation = -90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 60f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          Prop chairProp = this.ChairProp;
          Game.Player.Character.Position = chairProp.Position;
          int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num2, (InputArgument) "computer_exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          Game.Player.Character.Alpha = (int) byte.MaxValue;
          Game.Player.Character.IsVisible = true;
          Game.Player.Character.IsVisible = true;
          this.IsSittinginCeoSeat = true;
        }
      });
      uiMenu7.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != Locations5)
          return;
        if (this.WarehouseCam != (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocForgery[Locations5.Index].Enterance);
          blip.Sprite = BlipSprite.IdentityCard;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam.Position = this.MCSubLocForgery[Locations5.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocForgery[Locations5.Index].CameraHeading);
          Game.Player.Character.Position = this.MCSubLocForgery[Locations5.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.IsActive = true;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          BuyMC5.Text = "Buy MC Business : $" + this.MCSubLocForgery[Locations5.Index].Price.ToString("N");
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
        }
        if (this.WarehouseCam == (Camera) null)
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          Blip blip = World.CreateBlip(this.MCSubLocForgery[Locations5.Index].Enterance);
          blip.Sprite = BlipSprite.IdentityCard;
          blip.Color = BlipColor.Yellow6;
          blip.IsFlashing = true;
          blip.IsShortRange = true;
          this.CurrentViewingBusinessBlip = blip;
          this.WCamOn = true;
          this.WarehouseCam = World.CreateCamera(this.MCSubLocForgery[Locations5.Index].CameraPos, new Vector3(0.0f, 0.0f, this.MCSubLocForgery[Locations5.Index].CameraHeading), 100f);
          this.WarehouseCam.Position = this.MCSubLocForgery[Locations5.Index].CameraPos;
          this.WarehouseCam.Rotation = new Vector3(0.0f, 0.0f, this.MCSubLocForgery[Locations5.Index].CameraHeading);
          this.WarehouseCam.IsActive = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.Position = this.MCSubLocForgery[Locations5.Index].CameraPos;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.Heading = this.WarehouseCam.Rotation.Z;
          BuyMC5.Text = "Buy MC Business : $" + this.MCSubLocForgery[Locations5.Index].Price.ToString("N");
        }
      });
      UIMenuItem Update = new UIMenuItem("Update Stats");
      uiMenu2.AddItem(Update);
      UIMenuItem BuyNewLevel = new UIMenuItem(" Buy Level ");
      uiMenu2.AddItem(BuyNewLevel);
      UIMenuListItem list2 = new UIMenuListItem("Select Level: ", items1, 1);
      uiMenu2.AddItem((UIMenuItem) list2);
      UIMenuItem Jump = new UIMenuItem("Jump Straight to Level");
      uiMenu2.AddItem(Jump);
      UIMenuItem Show = new UIMenuItem("Show Level");
      uiMenu2.AddItem(Show);
      UIMenu uiMenu8 = this.modMenuPool.AddSubMenu(this.methgarage, "Sell Business");
      this.GUIMenus.Add(uiMenu8);
      UIMenuItem Sell = new UIMenuItem("Sell");
      uiMenu8.AddItem(Sell);
      uiMenu8.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
            UI.Notify("OK your new level will be " + (this.purchaselvl += num4 + 1).ToString() + ", at a price of $" + num3.ToString() + ", Do u want to continue Enter Y or N");
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
            Vector3 position = Game.Player.Character.Position;
            Game.Player.Character.Position = new Vector3(274f, 273f, 272f);
            Script.Wait(1);
            Game.Player.Character.Position = position;
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          }
        }
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
          UI.Notify("Price " + ((double) this.BusinessUpgradeBasePrice * num3 * (double) num2).ToString());
          UI.Notify("Level to Buy " + (num2 + 1).ToString());
          UI.Notify("increaseGain : $" + ((float) ((double) this.BusinessUpgradeIncreaseGain * (double) num2 / 0.75)).ToString());
          UI.Notify("Profit Margin :" + (0.85 * (double) num2 + 0.0).ToString() + "%");
          UI.Notify("Max Stocks : " + (10 * num2).ToString());
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
            Vector3 position = Game.Player.Character.Position;
            Game.Player.Character.Position = new Vector3(274f, 273f, 272f);
            Script.Wait(1);
            Game.Player.Character.Position = position;
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          }
          else
            UI.Notify("The level you are trying to purchase is either to high or to low!, please purchase the level before, to purchase this level");
        }
        if (item != Show)
          return;
        double num6 = 1.75;
        if (this.purchaselvl < 25)
          num6 = 1.75;
        if (this.purchaselvl > 25 && index < 50)
          num6 = 2.25;
        if (this.purchaselvl > 50 && this.purchaselvl < 70)
          num6 = 3.5;
        if (this.purchaselvl > 75 && this.purchaselvl < 100)
          num6 = 4.75;
        UI.Notify("Price for Next Level $" + ((double) this.BusinessUpgradeBasePrice * num6 * (double) this.purchaselvl).ToString());
        int num7 = this.purchaselvl + 1;
        UI.Notify("Next Level " + num7.ToString());
        UI.Notify("increaseGain : $" + ((float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75)).ToString());
        UI.Notify("Profit Margin :" + (0.85 * (double) this.purchaselvl + 0.0).ToString() + "%");
        num7 = 10 * this.purchaselvl;
        UI.Notify("Max Stocks : " + num7.ToString());
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
      UIMenu uiMenu9 = this.modMenuPool.AddSubMenu(this.methgarage, "Misc");
      this.GUIMenus.Add(uiMenu9);
      UIMenuListItem MC = new UIMenuListItem("Marker Color : ", MColour, 0);
      uiMenu9.AddItem((UIMenuItem) MC);
      UIMenuListItem BC = new UIMenuListItem("Blip Color : ", BColour, 0);
      uiMenu9.AddItem((UIMenuItem) BC);
      UIMenuItem SetHN = new UIMenuItem("Set Host Name");
      uiMenu9.AddItem(SetHN);
      UIMenuListItem uiC = new UIMenuListItem("UI Color : ", UiColour, 0);
      uiMenu9.AddItem((UIMenuItem) uiC);
      UIMenuItem Setall = new UIMenuItem("Save All");
      uiMenu9.AddItem(Setall);
      uiMenu9.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
        if (Class1.\u003C\u003Eo__299.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__299.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, BlipColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (BlipColor), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Blip_Colour = Class1.\u003C\u003Eo__299.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__299.\u003C\u003Ep__3, BColour[BC.Index]);
        this.Config.SetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__299.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__299.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Uicolour = Class1.\u003C\u003Eo__299.\u003C\u003Ep__4.Target((CallSite) Class1.\u003C\u003Eo__299.\u003C\u003Ep__4, UiColour[uiC.Index]);
        this.Config.SetValue<string>("Misc", "Uicolour", this.Uicolour);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__299.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__299.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.MarkerColorString = Class1.\u003C\u003Eo__299.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__299.\u003C\u003Ep__5, MColour[MC.Index]);
        this.Config.SetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " : Settings Changed they will take effect when you reload the mod!");
      });
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    private void DisplayHelpTextThisFrameNoSound(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) -1);
    }

    public void OnTick(object sender, EventArgs e)
    {
      if (this.WarehouseCam != (Camera) null)
      {
        if (this.WCamOn && this.modMenuPool.IsAnyMenuOpen())
        {
          foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocMeth)
            World.DrawMarker(MarkerType.VerticalCylinder, businessLocations.Enterance, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), Color.Goldenrod);
          foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocCocaine)
            World.DrawMarker(MarkerType.VerticalCylinder, businessLocations.Enterance, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), Color.Goldenrod);
          foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocWeed)
            World.DrawMarker(MarkerType.VerticalCylinder, businessLocations.Enterance, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), Color.Goldenrod);
          foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocForgery)
            World.DrawMarker(MarkerType.VerticalCylinder, businessLocations.Enterance, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), Color.Goldenrod);
          foreach (Class1.MCBusinessLocations businessLocations in this.MCSubLocCounterfiet)
            World.DrawMarker(MarkerType.VerticalCylinder, businessLocations.Enterance, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), Color.Goldenrod);
        }
        if (this.WCamOn && !this.modMenuPool.IsAnyMenuOpen())
        {
          if (this.CurrentViewingBusinessBlip != (Blip) null)
            this.CurrentViewingBusinessBlip.Remove();
          this.WCamOn = false;
          this.modMenuPool.CloseAllMenus();
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.WarehouseCam.IsActive = false;
          this.WarehouseCam.Destroy();
          Game.Player.Character.FreezePosition = false;
          Game.Player.Character.IsVisible = true;
          Game.Player.Character.Position = this.ChairPos;
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          Script.Wait(1000);
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -100f), false, false);
          this.ChairProp.FreezePosition = true;
          this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
          if (this.ClubhouseChoosen == 1)
          {
            this.ChairPos = new Vector3(1008.1f, -3170.258f, -39.93f);
            this.P_Rotation = 90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -129f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          if (this.ClubhouseChoosen == 2)
          {
            this.ChairPos = new Vector3(1116.2f, -3161f, -37.8f);
            this.P_Rotation = -90f;
            if ((Entity) this.ChairProp != (Entity) null)
              this.ChairProp.Delete();
            this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 60f), false, false);
            this.ChairProp.FreezePosition = true;
          }
          Prop chairProp = this.ChairProp;
          this.IsSittinginCeoSeat = true;
          int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num, (InputArgument) "computer_exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        }
      }
      int num1;
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
              num1 = (int) ((double) this.stocksvalue * 1.25);
              UI.Notify("~g~Stock Value Now: +$" + num1.ToString("N"));
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
              if (!this.SellStockDeliveryMission)
              {
                if ((double) World.GetDistance(this.StockVeh.Position, this.CurrentGarage) < 200.0)
                  World.DrawMarker(MarkerType.VerticalCylinder, this.CurrentGarage, Vector3.Zero, Vector3.Zero, new Vector3(6f, 6f, 4f), Color.White);
                if ((double) World.GetDistance(this.StockVeh.Position, this.CurrentGarage) < 5.0)
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
            }
            for (int index1 = 0; index1 < this.DropPoint.Count; num1 = index1++)
            {
              if (this.DropBlip[index1] != (Blip) null)
              {
                if (this.DropBlip[index1].Alpha == (int) byte.MaxValue)
                {
                  try
                  {
                    if ((double) World.GetDistance(Game.Player.Character.Position, this.DropPoint[index1]) < 200.0)
                      World.DrawMarker(MarkerType.VerticalCylinder, this.DropPoint[index1], Vector3.Zero, Vector3.Zero, new Vector3(4f, 6f, 4f), Color.White);
                    if ((double) World.GetDistance(Game.Player.Character.Position, this.DropPoint[index1]) < 100.0)
                    {
                      if (!this.CreateSupplyVehicle)
                      {
                        UI.Notify(this.GetHostName() + " You have Located a nearby adversary Cargo Vehicle, steal it and return it to the Garage");
                        if (this.SupplyGarageBlip != (Blip) null)
                          this.SupplyGarageBlip.Remove();
                        this.SupplyGarageBlip = World.CreateBlip(this.CurrentGarage);
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
                        float num2 = (float) random.Next(0, 100);
                        if ((double) num2 < 33.0)
                        {
                          this.StockVeh = World.CreateVehicle((Model) VehicleHash.TipTruck, this.DropPoint[index1], 0.0f);
                          this.StockVeh.ToggleExtra(2, false);
                          Vector3 offsetInWorldCoords1 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.5f));
                          Vector3 offsetInWorldCoords2 = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -3f, 0.5f));
                          this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -4f, 0.5f));
                          Prop prop1 = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords1, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                          this.SellStockProp1 = prop1;
                          this.SellStockProps.Add(prop1);
                          Prop prop2 = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords2, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                          this.SellStockProp2 = prop2;
                          this.SellStockProps.Add(prop2);
                          this.SellStockProp1.HasCollision = false;
                          this.SellStockProp2.HasCollision = false;
                        }
                        if ((double) num2 > 33.0 && (double) num2 < 66.0)
                        {
                          this.StockVeh = World.CreateVehicle((Model) VehicleHash.Flatbed, this.DropPoint[index1], 0.0f);
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
                        if ((double) num2 > 66.0)
                        {
                          this.StockVeh = World.CreateVehicle((Model) VehicleHash.Guardian, this.DropPoint[index1], 0.0f);
                          Vector3 offsetInWorldCoords = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.1f));
                          Prop prop = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                          this.SellStockProp1 = prop;
                          this.SellStockProps.Add(prop);
                          this.SellStockProp1.HasCollision = false;
                        }
                        float num3 = (float) random.Next(6, 8);
                        for (int index2 = 0; (double) index2 < (double) num3; ++index2)
                        {
                          Ped ped = World.CreatePed(this.RequestModel(PedHash.Polynesian01AMM), this.DropPoint[index1].Around(20f));
                          this.SuppyGuards.Add(ped);
                          int num4 = new System.Random().Next(0, 300);
                          if (num4 < 50)
                            ped.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
                          if (num4 > 50 && num4 < 100)
                            ped.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
                          if (num4 > 100 && num4 < 150)
                            ped.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
                          if (num4 > 150 && num4 < 200)
                            ped.Weapons.Give(WeaponHash.SMG, 9999, true, true);
                          if (num4 > 200 && num4 < 250)
                            ped.Weapons.Give(WeaponHash.DoubleBarrelShotgun, 9999, true, true);
                          if (num4 > 250 && num4 < 300)
                            ped.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
                          ped.Accuracy = 400;
                          int num5 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                          Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num5);
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
                    num1 = this.DropBlip.Count;
                    string str1 = num1.ToString();
                    num1 = this.DropPoint.Count;
                    string str2 = num1.ToString();
                    UI.Notify("Crash1 " + str1 + "__" + str2);
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
                for (int index = 0; index < this.DropBlip.Count; num1 = index++)
                {
                  if (this.DropBlip[index] != (Blip) null && this.DropBlip[index].Alpha == (int) byte.MaxValue)
                  {
                    if (this.SellStockPointsBeenAt != this.AmttoDeliver)
                    {
                      if ((double) World.GetDistance(this.StockVeh.Position, this.DropPoint[index]) < 200.0)
                        World.DrawMarker(MarkerType.VerticalCylinder, this.DropPoint[index], Vector3.Zero, Vector3.Zero, new Vector3(4f, 6f, 4f), Color.White);
                      if ((double) World.GetDistance(this.StockVeh.Position, this.DropPoint[index]) < 10.0)
                      {
                        num1 = this.SellStockPointsBeenAt++;
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
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2399.7f, 718.1f, 221.4f)) < 2.0 && Game.Player.Character.Alpha == 15)
      {
        this.MainModDestroy();
        this.MainModRefresh();
      }
      if (this.firstTime)
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        if ((Entity) this.ChairProp != (Entity) null)
          this.ChairProp.Delete();
        this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -100f), false, false);
        this.ChairProp.FreezePosition = true;
        this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
        if (this.ClubhouseChoosen == 1)
        {
          this.ChairPos = new Vector3(1008.1f, -3170.258f, -39.93f);
          this.P_Rotation = 90f;
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, -129f), false, false);
          this.ChairProp.FreezePosition = true;
        }
        if (this.ClubhouseChoosen == 2)
        {
          this.ChairPos = new Vector3(1116.2f, -3161f, -37.8f);
          this.P_Rotation = -90f;
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 60f), false, false);
          this.ChairProp.FreezePosition = true;
        }
        this.firstTime = false;
      }
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      this.OnKeyDown();
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) < 1.5)
      {
        if (this.IsSittinginCeoSeat)
        {
          if ((Game.IsControlJustPressed(2, GTA.Control.FrontendPauseAlternate) || Game.IsControlJustPressed(2, GTA.Control.PhoneCancel)) && this.mainMenu.Visible)
          {
            Prop chairProp = this.ChairProp;
            int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num2, (InputArgument) "computer_exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Context))
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
            if (!this.mainMenu.Visible)
            {
              Prop chairProp = this.ChairProp;
              int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "computer_enter", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num2, (InputArgument) "computer_enter_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(100);
              this.mainMenu.Visible = !this.mainMenu.Visible;
            }
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            this.modMenuPool.CloseAllMenus();
            int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ChairProp.Position.X, (InputArgument) this.ChairProp.Position.Y, (InputArgument) this.ChairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ChairProp.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ChairProp, (InputArgument) num2, (InputArgument) "exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(4000);
            Game.Player.Character.Task.ClearAll();
            this.IsSittinginCeoSeat = false;
          }
        }
        else if (!this.IsSittinginCeoSeat && Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          Script.Wait(100);
          string str = "anim@amb@office@boss@male@";
          Class1.LoadDict("anim@amb@office@boss@male@");
          if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) str))
          {
            int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ChairProp.Position.X, (InputArgument) this.ChairProp.Position.Y, (InputArgument) this.ChairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ChairProp.Rotation.Z, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "enter", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ChairProp, (InputArgument) num2, (InputArgument) "enter_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(5000);
            this.IsSittinginCeoSeat = true;
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) < 1.45000004768372)
      {
        if (this.IsSittinginCeoSeat)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open Menu, Press ~INPUT_COVER~ to Exit");
        else
          this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to sit on chair to access Menu");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) > 4.0 && this.IsSittinginCeoSeat)
      {
        this.IsSittinginCeoSeat = false;
        Game.Player.Character.FreezePosition = true;
        Game.FadeScreenOut(500);
        Script.Wait(500);
        Game.Player.Character.Position = this.ChairPos.Around(2f);
        Game.Player.Character.Heading = this.P_Rotation;
        Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
        Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
        Game.Player.Character.Task.ClearAnimation("anim@amb@office@laptops@male@var_c@base@", "base");
        Game.Player.Character.FreezePosition = false;
        Script.Wait(500);
        Game.FadeScreenIn(500);
      }
      if (this.RaidSetup && this.mission == 1)
      {
        if (Game.Player.Character.IsAlive)
        {
          if (this.isAtSubBusiness)
          {
            if ((double) World.GetDistance(Game.Player.Character.Position, this.SubBusinessLoc) < 5.0)
            {
              UI.Notify(this.GetHostName() + " ok incoming enemies, stay sharp boss");
              this.isAtSubBusiness = false;
              this.timer = 4500;
              this.StartedRaid = true;
              this.SpawnAttackerTimer = 300;
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.SubBusinessLoc) < 60.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.SubBusinessLoc, Vector3.Zero, Vector3.Zero, new Vector3(6f, 6f, 1f), Color.Red);
          }
          if (this.StartedRaid)
          {
            this.DisplayHelpTextThisFrame(this.GetHostName() + " time until raid finishs : " + this.timer.ToString() + " , time until next Attack : " + this.SpawnAttackerTimer.ToString());
            if ((double) World.GetDistance(Game.Player.Character.Position, this.SubBusinessLoc) < 60.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.SubBusinessLoc, Vector3.Zero, Vector3.Zero, new Vector3(6f, 6f, 1f), Color.Red);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.SubBusinessLoc) >= 4.0)
              ;
            if ((uint) this.timer > 0U)
            {
              num1 = this.timer--;
              foreach (Ped ped in this.Gang)
              {
                if ((Entity) ped != (Entity) null)
                {
                  int num2 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                  Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) ped, (InputArgument) num2);
                  Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
                  Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
                  ped.Task.FightAgainst(Game.Player.Character);
                  Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped, (InputArgument) 1);
                }
              }
            }
            if (this.timer == 0)
            {
              this.SpawnAttackerTimer = 0;
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
              this.mission = 0;
              this.MissionSetup = false;
              this.StartedRaid = false;
              Game.Player.Money += 1000000;
              this.DisplayHelpTextThisFrame(this.GetHostName() + " Good job boss, you just prevented a raid!");
              UI.Notify(this.GetHostName() + " Good job boss, you just prevented a raid!");
            }
            if ((uint) this.SpawnAttackerTimer > 0U)
              num1 = this.SpawnAttackerTimer--;
            if (this.SpawnAttackerTimer == 0)
            {
              this.SpawnAttackerTimer = 300;
              System.Random random1 = new System.Random();
              if (random1.Next(1, 100) < 25)
              {
                System.Random random2 = new System.Random();
                System.Random random3 = new System.Random();
                Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Chino2, Game.Player.Character.GetOffsetInWorldCoords(new Vector3((float) random2.Next(-5, 5), (float) random3.Next(-100, 100), 0.0f)));
                vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Vagos01GFY);
                vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Vagos01GFY);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.MicroSMG);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.MicroSMG);
                vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                this.SetupVagos(vehicle, 1);
                this.GangVehicles.Add(vehicle);
                vehicle.PlaceOnNextStreet();
              }
              if (random1.Next(1, 100) > 25 && random1.Next(1, 100) < 50)
              {
                System.Random random2 = new System.Random();
                System.Random random3 = new System.Random();
                Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Faction2, Game.Player.Character.GetOffsetInWorldCoords(new Vector3((float) random2.Next(-5, 5), (float) random3.Next(-100, 100), 0.0f)));
                vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Families01GFY);
                vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Families01GFY);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
                vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.MicroSMG);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.MicroSMG);
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                this.SetupFamilies(vehicle, 1);
                this.GangVehicles.Add(vehicle);
                vehicle.PlaceOnNextStreet();
              }
              if (random1.Next(1, 100) > 50 && random1.Next(1, 100) < 75)
              {
                System.Random random2 = new System.Random();
                System.Random random3 = new System.Random();
                Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Buccaneer2, Game.Player.Character.GetOffsetInWorldCoords(new Vector3((float) random2.Next(-5, 5), (float) random3.Next(-100, 100), 0.0f)));
                vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.BallaEast01GMY);
                vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.BallaEast01GMY);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.AssaultRifle);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.AssaultRifle);
                vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
                vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Driver), WeaponHash.MicroSMG);
                this.ArmedPed(vehicle.GetPedOnSeat(VehicleSeat.Passenger), WeaponHash.MicroSMG);
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                this.SetupBallas(vehicle, 1);
                this.GangVehicles.Add(vehicle);
                vehicle.PlaceOnNextStreet();
              }
              if (random1.Next(1, 100) > 75 && random1.Next(1, 100) < 100)
              {
                System.Random random2 = new System.Random();
                System.Random random3 = new System.Random();
                Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Moonbeam2, Game.Player.Character.GetOffsetInWorldCoords(new Vector3((float) random2.Next(-5, 5), (float) random3.Next(-100, 100), 0.0f)));
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
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.RightRear));
                this.Gang.Add(vehicle.GetPedOnSeat(VehicleSeat.LeftRear));
                this.SetupBallas(vehicle, 2);
                this.GangVehicles.Add(vehicle);
                vehicle.PlaceOnNextStreet();
              }
            }
          }
        }
        if (!Game.Player.Character.IsAlive)
        {
          this.SpawnAttackerTimer = 0;
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
          this.mission = 0;
          this.MissionSetup = false;
          this.StartedRaid = false;
          this.DisplayHelpTextThisFrame(this.GetHostName() + " the raid was not stopped, we cannot aford to do this again");
          UI.Notify(this.GetHostName() + " the raid was not stopped, we cannot aford to do this again");
        }
      }
      if (this.MissionSetup)
      {
        if (this.mission == 3)
        {
          UI.ShowSubtitle("Eliminate all ~r~ Enemies~w~");
          if ((Entity) this.Sam1 != (Entity) null && (Entity) this.Sam2 != (Entity) null && (Entity) this.Sam3 != (Entity) null)
          {
            if ((double) World.GetDistance(Game.Player.Character.Position, this.Sam1.Position) < 100.0 && this.ExitVehicle)
            {
              this.ExitVehicle = false;
              this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
              this.Sam1.GetPedOnSeat(VehicleSeat.Passenger).Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
              this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
              this.Sam2.GetPedOnSeat(VehicleSeat.Passenger).Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
              this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
              this.Sam3.GetPedOnSeat(VehicleSeat.Passenger).Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
              this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              this.Sam1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              this.Sam2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              this.Sam3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.Sam1.Position) < 80.0)
            {
              this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              this.Sam1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              this.Sam2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              this.Sam3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
            }
          }
        }
        foreach (Ped ped in this.Gang)
        {
          if ((Entity) ped != (Entity) null)
            this.AllEliminated = !ped.IsAlive;
        }
        if (!this.Sam1.IsAlive && !this.Sam2.IsAlive && !this.Sam3.IsAlive && this.AllEliminated)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          foreach (Ped ped in this.Gang)
          {
            if ((Entity) ped != (Entity) null)
              ped.Delete();
          }
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          if (this.Sam2blip != (Blip) null)
            this.Sam2blip.Remove();
          if (this.Sam3blip != (Blip) null)
            this.Sam3blip.Remove();
          this.mission = 0;
          this.MissionSetup = false;
          this.Sam1.Delete();
          this.Sam2.Delete();
          this.Sam3.Delete();
          Script.Wait(300);
          Game.FadeScreenIn(300);
          Game.Player.Money += 495000;
          UI.Notify(this.GetHostName() + " Good job boss, on destroying those gang vehicles");
        }
        if (this.mission == 2)
        {
          UI.ShowSubtitle("Destory all gang ~r~ Vehicles");
          if ((Entity) this.Sam1 != (Entity) null && (Entity) this.Sam2 != (Entity) null && (Entity) this.Sam3 != (Entity) null)
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
                  if ((Entity) this.Sam1 != (Entity) null)
                    this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
                  if ((Entity) this.Sam2 != (Entity) null)
                    this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
                  if ((Entity) this.Sam3 != (Entity) null)
                    this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
                  UI.Notify("tEstw");
                }
                if (!this.Sam1.GetPedOnSeat(VehicleSeat.Driver).IsAlive)
                  this.killedDriver = false;
              }
            }
            if (this.Sam2.IsAlive)
            {
              if (this.Sam2blip != (Blip) null)
                this.Sam2blip.Position = this.Sam2.Position;
              if (this.killedDriver)
              {
                if ((double) World.GetDistance(this.Sam2.Position, this.CurrentPoint) < 40.0)
                {
                  this.CurrentPoint = this.GetLocation();
                  if ((Entity) this.Sam1 != (Entity) null)
                    this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
                  if ((Entity) this.Sam2 != (Entity) null)
                    this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
                  if ((Entity) this.Sam3 != (Entity) null)
                    this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
                }
                if (!this.Sam2.GetPedOnSeat(VehicleSeat.Driver).IsAlive)
                  this.killedDriver = false;
              }
            }
            if (this.Sam3.IsAlive)
            {
              if (this.Sam3blip != (Blip) null)
                this.Sam3blip.Position = this.Sam3.Position;
              if (this.killedDriver)
              {
                if ((double) World.GetDistance(this.Sam3.Position, this.CurrentPoint) < 40.0)
                {
                  this.CurrentPoint = this.GetLocation();
                  if ((Entity) this.Sam1 != (Entity) null)
                    this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.CurrentPoint, 40f, 100f, 6);
                  if ((Entity) this.Sam2 != (Entity) null)
                    this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.CurrentPoint, 40f, 100f, 6);
                  if ((Entity) this.Sam3 != (Entity) null)
                    this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.CurrentPoint, 40f, 100f, 6);
                }
                if (!this.Sam3.GetPedOnSeat(VehicleSeat.Driver).IsAlive)
                  this.killedDriver = false;
              }
            }
            if (!this.Sam1.IsAlive && !this.Sam2.IsAlive && !this.Sam3.IsAlive)
            {
              Game.FadeScreenOut(300);
              Script.Wait(300);
              if (this.Sam1blip != (Blip) null)
                this.Sam1blip.Remove();
              if (this.Sam2blip != (Blip) null)
                this.Sam2blip.Remove();
              if (this.Sam3blip != (Blip) null)
                this.Sam3blip.Remove();
              this.mission = 0;
              this.MissionSetup = false;
              this.Sam1.Delete();
              this.Sam2.Delete();
              this.Sam3.Delete();
              Script.Wait(300);
              Game.FadeScreenIn(300);
              Game.Player.Money += 225000;
              UI.Notify(this.GetHostName() + " Good job boss, on destroying those gang vehicles");
            }
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(274f, 273f, 272f)) < 5.0)
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      if (this.UseOldMarker)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.BuyMarker) < 4.0)
        {
          if (this.purchaselvl == 0)
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          if ((uint) this.purchaselvl > 0U)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Enter Menu");
          if (this.purchaselvl == 0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to purchase Biker Business  :$1,000,000");
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.BuyMarker) < 100.0 && !this.createdPed)
        {
          this.ClayPed = World.CreatePed(this.RequestModel(PedHash.Clay), this.BuyMarker, 180f);
          this.ClayPed.FreezePosition = true;
          Script.Wait(1);
          this.ClayPed.FreezePosition = false;
          this.ClayPed.CanBeTargetted = false;
          this.ClayPed.BlockPermanentEvents = true;
          this.createdPed = true;
        }
        else if ((double) World.GetDistance(Game.Player.Character.Position, this.BuyMarker) > 101.0 && this.createdPed)
        {
          if ((Entity) this.ClayPed != (Entity) null)
            this.ClayPed.Delete();
          this.createdPed = false;
        }
        if ((Entity) this.ClayPed == (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.BuyMarker) < 100.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.BuyMarker, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), this.MarkerColor);
      }
      if (this.VehicleSetup2)
      {
        if (this.vehiclemissionid == 11)
        {
          if ((Entity) this.Plane == (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, new Vector3(1561.9f, 3330.5f, 225f)) < 750.0)
          {
            this.Plane = World.CreateVehicle((Model) VehicleHash.Cuban800, new Vector3(1561.9f, 3330.5f, 225f));
            this.Plane.Repair();
            this.Plane.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Agent14);
            this.SetActiveTarget2(this.Plane, this.PlaneTargetPositions[0]);
            this.FightAgainst(this.PlaneTargetPositions[0], this.Plane.GetPedOnSeat(VehicleSeat.Driver));
            this.CurrentTarget = this.PlaneTargetPositions[0];
            this.Plane.GetPedOnSeat(VehicleSeat.Driver).BlockPermanentEvents = true;
            this.Plane.GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = Game.Player.Character.RelationshipGroup;
            this.Plane.GetPedOnSeat(VehicleSeat.Driver).NeverLeavesGroup = true;
            this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsEnemy = false;
            this.Plane.GetPedOnSeat(VehicleSeat.Driver);
            this.Plane.AddBlip();
            this.Plane.CurrentBlip.Sprite = BlipSprite.Plane;
            this.Plane.CurrentBlip.Color = BlipColor.Yellow;
            this.Plane.CurrentBlip.Name = "Drug Plane";
            this.TargetCarBlip = this.Plane.CurrentBlip;
            this.Plane.BodyHealth = 120000f;
          }
          if ((Entity) this.Plane != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.Plane.Position) < 10000.0)
          {
            if (((double) World.GetDistance(this.Plane.Position, this.PlaneTargetPositions[1].Position) < 250.0 || (double) World.GetDistance(this.Plane.Position, this.PlaneTargetPositions[2].Position) < 250.0 || (double) World.GetDistance(this.Plane.Position, this.PlaneTargetPositions[0].Position) < 250.0) && this.DropTimer != 40)
              num1 = this.DropTimer++;
            if (this.MissionTime != 4500)
              num1 = this.MissionTime++;
            if (this.MissionTime == 4500)
            {
              this.PackagesRecieved = 0;
              this.MissionTime = 0;
              if (this.TargetCarBlip != (Blip) null)
                this.TargetCarBlip.Remove();
              if ((Entity) this.TargetsCar != (Entity) null)
                this.TargetsCar.Delete();
              foreach (Prop crate in this.Crates)
              {
                if ((Entity) crate != (Entity) null)
                {
                  if (crate.CurrentBlip != (Blip) null)
                    crate.CurrentBlip.Remove();
                  crate.Delete();
                }
              }
              foreach (Vehicle viPcar in this.VIPcars)
              {
                if ((Entity) viPcar != (Entity) null)
                  viPcar.Delete();
              }
              this.VehicleSetup2 = false;
              this.vehiclemissionid = 0;
              new MissionScreen().SetPass("The Air Drop", this.Payout, "");
              UI.Notify(this.GetHostName() + " Mission Complete, The you have earned : " + this.Payout.ToString());
              Game.Player.Money += this.Payout;
              this.Payout = 0;
            }
            if (this.Plane.IsAlive)
            {
              this.DisplayHelpTextThisFrameNoSound("Collect Crates to earn cash , Payout : ~y~$" + this.Payout.ToString("N") + "~w~, Time left : ~y~" + this.MissionTime.ToString() + "/4500");
              if ((double) World.GetDistance(this.Plane.Position, this.PlaneTargetPositions[2].Position) < 450.0 && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[2]))
              {
                UI.Notify("Checkpoint 1");
                this.SetActiveTarget(this.Plane, this.PlaneTargetPositions[1]);
                if (this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[2]))
                  this.FightAgainst(this.PlaneTargetPositions[1], this.Plane.GetPedOnSeat(VehicleSeat.Driver));
              }
              if ((double) World.GetDistance(this.Plane.Position, this.PlaneTargetPositions[1].Position) < 450.0 && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[1]))
              {
                UI.Notify("Checkpoint 2");
                this.SetActiveTarget(this.Plane, this.PlaneTargetPositions[0]);
                if (this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[1]))
                  this.FightAgainst(this.PlaneTargetPositions[0], this.Plane.GetPedOnSeat(VehicleSeat.Driver));
              }
              if ((double) World.GetDistance(this.Plane.Position, this.PlaneTargetPositions[0].Position) < 450.0 && this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[0]))
              {
                UI.Notify("Checkpoint 3s");
                this.SetActiveTarget(this.Plane, this.PlaneTargetPositions[2]);
                if (this.Plane.GetPedOnSeat(VehicleSeat.Driver).IsInCombatAgainst(this.PlaneTargetPositions[0]))
                  this.FightAgainst(this.PlaneTargetPositions[2], this.Plane.GetPedOnSeat(VehicleSeat.Driver));
              }
              if (this.DropTimer == 40)
              {
                this.DropTimer = 0;
                Vector3 position = this.Plane.Position;
                Vector3 Pos = new Vector3(position.X, position.Y -= 50f, position.Z -= 50f);
                this.SpawnDrugCrate(this.CrateString[new System.Random().Next(0, this.CrateString.Count)], Pos, new Vector3(0.0f, 0.0f, 0.0f));
              }
              foreach (Prop crate in this.Crates)
              {
                if ((Entity) crate != (Entity) null)
                {
                  if ((double) World.GetDistance(Game.Player.Character.Position, crate.Position) < 75.0 && crate.CurrentBlip == (Blip) null)
                  {
                    crate.AddBlip();
                    crate.CurrentBlip.Sprite = BlipSprite.SpecialCargo;
                    crate.CurrentBlip.Color = BlipColor.Yellow;
                  }
                  if ((double) World.GetDistance(Game.Player.Character.Position, crate.Position) < 5.0)
                  {
                    num1 = this.PackagesRecieved++;
                    this.Payout += 125000;
                    if (crate.CurrentBlip != (Blip) null)
                      crate.CurrentBlip.Remove();
                    crate.Delete();
                  }
                }
              }
              foreach (Prop crate in this.Crates)
              {
                if ((Entity) crate != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, crate.Position) < 100.0)
                {
                  Vector3 pos = crate.Position;
                  pos = new Vector3(pos.X, pos.Y, pos.Z += 3f);
                  World.DrawMarker(MarkerType.UpsideDownCone, pos, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), Color.Yellow);
                }
              }
            }
            else if (!this.Plane.IsAlive)
            {
              this.PackagesRecieved = 0;
              this.MissionTime = 0;
              if (this.TargetCarBlip != (Blip) null)
                this.TargetCarBlip.Remove();
              if ((Entity) this.TargetsCar != (Entity) null)
                this.TargetsCar.Delete();
              foreach (Prop crate in this.Crates)
              {
                if ((Entity) crate != (Entity) null)
                {
                  if (crate.CurrentBlip != (Blip) null)
                    crate.CurrentBlip.Remove();
                  crate.Delete();
                }
              }
              foreach (Vehicle viPcar in this.VIPcars)
              {
                if ((Entity) viPcar != (Entity) null)
                  viPcar.Delete();
              }
              this.VehicleSetup2 = false;
              this.vehiclemissionid = 0;
              new MissionScreen().SetPass("The Air Drop", this.Payout, "");
              UI.Notify(this.GetHostName() + " The you have earned : " + this.Payout.ToString());
              Game.Player.Money += this.Payout;
              this.Payout = 0;
              UI.Notify(this.GetHostName() + " Mission Failed!, The Drop plane was destroyed!");
            }
          }
        }
        if (this.vehiclemissionid == 10)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Courthouse) < 400.0 && !this.ChoosenTargert)
          {
            this.ChoosenTargert = true;
            this.StartTimer = true;
            UI.Notify(this.GetHostName() + " The VIP has hidden himself with crowd at the Court house, ~b~ 1:~w~ you can either approch and he will flee, ~r~ 2:~w~ or wait for someone to enter a vehicle");
            System.Random random = new System.Random();
            int num2 = random.Next(1, 8);
            int num3 = random.Next(0, 360);
            if (num2 == 1)
            {
              this.Target.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
              this.Target.Task.StartScenario("WORLD_HUMAN_AA_COFFEE", this.Target.Position);
              num2 = random.Next(1, 8);
              num3 = random.Next(0, 360);
            }
            if (num2 == 2)
            {
              this.Target.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
              this.Target.Task.StartScenario("WORLD_HUMAN_AA_SMOKE", this.Target.Position);
              num2 = random.Next(1, 8);
              num3 = random.Next(0, 360);
            }
            if (num2 == 3)
            {
              this.Target.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
              this.Target.Task.StartScenario("WORLD_HUMAN_DRINKING", this.Target.Position);
              num2 = random.Next(1, 8);
              num3 = random.Next(0, 360);
            }
            if (num2 == 4)
            {
              this.Target.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
              this.Target.Task.StartScenario("WORLD_HUMAN_PAPARAZZI", this.Target.Position);
              num2 = random.Next(1, 8);
              num3 = random.Next(0, 360);
            }
            if (num2 == 5)
            {
              this.Target.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
              this.Target.Task.StartScenario("WORLD_HUMAN_SMOKING", this.Target.Position);
              num2 = random.Next(1, 8);
              num3 = random.Next(0, 360);
            }
            if (num2 == 6)
            {
              this.Target.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
              this.Target.Task.StartScenario("WORLD_HUMAN_STAND_IMPATIENT", this.Target.Position);
              num2 = random.Next(1, 8);
              num3 = random.Next(0, 360);
            }
            if (num2 == 7)
            {
              this.Target.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
              this.Target.Task.StartScenario("WORLD_HUMAN_TOURIST_MOBILE", this.Target.Position);
              num2 = random.Next(1, 8);
              num3 = random.Next(0, 360);
            }
            if (num2 == 8)
            {
              this.Target.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
              this.Target.Task.ChatTo(this.Peds[new System.Random().Next(0, this.Peds.Count - 1)]);
              num2 = random.Next(1, 8);
              num3 = random.Next(0, 360);
            }
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Target, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) this.Target, (InputArgument) 1);
            Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) this.Target, (InputArgument) 1);
            foreach (Ped ped in this.Peds)
            {
              if ((Entity) ped != (Entity) null)
              {
                if (num2 == 1)
                {
                  ped.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
                  ped.Task.StartScenario("WORLD_HUMAN_AA_COFFEE", ped.Position);
                  num2 = random.Next(1, 8);
                  num3 = random.Next(0, 360);
                }
                if (num2 == 2)
                {
                  ped.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
                  ped.Task.StartScenario("WORLD_HUMAN_AA_SMOKE", ped.Position);
                  num2 = random.Next(1, 8);
                  num3 = random.Next(0, 360);
                }
                if (num2 == 3)
                {
                  ped.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
                  ped.Task.StartScenario("WORLD_HUMAN_DRINKING", ped.Position);
                  num2 = random.Next(1, 8);
                  num3 = random.Next(0, 360);
                }
                if (num2 == 4)
                {
                  ped.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
                  ped.Task.StartScenario("WORLD_HUMAN_PAPARAZZI", ped.Position);
                  num2 = random.Next(1, 8);
                  num3 = random.Next(0, 360);
                }
                if (num2 == 5)
                {
                  ped.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
                  ped.Task.StartScenario("WORLD_HUMAN_SMOKING", ped.Position);
                  num2 = random.Next(1, 8);
                  num3 = random.Next(0, 360);
                }
                if (num2 == 6)
                {
                  ped.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
                  ped.Task.StartScenario("WORLD_HUMAN_STAND_IMPATIENT", ped.Position);
                  num2 = random.Next(1, 8);
                  num3 = random.Next(0, 360);
                }
                if (num2 == 7)
                {
                  ped.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
                  this.Target.Task.ChatTo(this.Peds[new System.Random().Next(0, this.Peds.Count - 1)]);
                  num3 = random.Next(0, 360);
                }
                if (num2 == 8)
                {
                  ped.Rotation = new Vector3(0.0f, 0.0f, (float) num3);
                  ped.Task.StartScenario("WORLD_HUMAN_STAND_MOBI\uFEFFLE\uFEFF\uFEFF\uFEFF", ped.Position);
                  num2 = random.Next(1, 8);
                  num3 = random.Next(0, 360);
                }
              }
            }
            foreach (Ped guard in this.Guards)
            {
              if ((Entity) guard != (Entity) null)
                guard.Task.StartScenario("WO\uFEFFRLD_HUMAN_GUARD_STA\uFEFFND_ARM\uFEFFY\uFEFF\uFEFF\uFEFF\uFEFF\uFEFF\uFEFF\uFEFF\uFEFF\uFEFF\uFEFF", guard.Position);
            }
          }
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null && !ped.IsAlive)
            {
              this.Fail = 1;
              break;
            }
          }
          if ((Entity) this.Target != (Entity) null)
          {
            if ((double) World.GetDistance(this.Courthouse, this.Target.Position) > 300.0 && (double) World.GetDistance(Game.Player.Character.Position, this.Target.Position) > 300.0)
              this.Fail = 3;
            if (!this.Target.IsAlive)
              this.Fail = 2;
            if (this.Fail == 3)
            {
              this.StartTimer = false;
              this.VehicleSetup2 = false;
              this.vehiclemissionid = 0;
              Game.FadeScreenOut(600);
              Script.Wait(600);
              this.MaxGuards = 0;
              if (this.CourthouseBlip != (Blip) null)
                this.CourthouseBlip.Remove();
              if (this.TargetCarBlip != (Blip) null)
                this.TargetCarBlip.Remove();
              foreach (Vehicle viPcar in this.VIPcars)
              {
                if ((Entity) viPcar != (Entity) null)
                  viPcar.Delete();
              }
              foreach (Ped ped in this.Peds)
              {
                if ((Entity) ped != (Entity) null)
                  ped.Delete();
              }
              foreach (Blip guardBlip in this.GuardBlips)
              {
                if (guardBlip != (Blip) null)
                  guardBlip.Remove();
              }
              if ((Entity) this.Target != (Entity) null)
                this.Target.Delete();
              foreach (Ped guard in this.Guards)
              {
                if ((Entity) guard != (Entity) null)
                  guard.Delete();
              }
              if (this.CourthouseBlip != (Blip) null)
                this.CourthouseBlip.Remove();
              if ((Entity) this.Target != (Entity) null)
                this.Target.Delete();
              if ((Entity) this.TargetsCar != (Entity) null)
                this.TargetsCar.Delete();
              this.Fail = 0;
              Script.Wait(600);
              Game.FadeScreenIn(1200);
              Script.Wait(100);
              new MissionScreen().SetFail("The Courthouse Dilema", this.Payout, "");
              UI.Notify(this.GetHostName() + " The VIP has escaped, we needed him dead!");
            }
            if (this.Fail == 2 && !this.Target.IsAlive)
            {
              this.StartTimer = false;
              Game.FadeScreenOut(600);
              Script.Wait(600);
              this.MaxGuards = 0;
              if (this.CourthouseBlip != (Blip) null)
                this.CourthouseBlip.Remove();
              if (this.TargetCarBlip != (Blip) null)
                this.TargetCarBlip.Remove();
              if ((Entity) this.Target != (Entity) null)
                this.Target.Delete();
              foreach (Vehicle viPcar in this.VIPcars)
              {
                if ((Entity) viPcar != (Entity) null)
                  viPcar.Delete();
              }
              foreach (Ped ped in this.Peds)
              {
                if ((Entity) ped != (Entity) null)
                  ped.Delete();
              }
              foreach (Blip guardBlip in this.GuardBlips)
              {
                if (guardBlip != (Blip) null)
                  guardBlip.Remove();
              }
              foreach (Ped guard in this.Guards)
              {
                if ((Entity) guard != (Entity) null)
                  guard.Delete();
              }
              if (this.CourthouseBlip != (Blip) null)
                this.CourthouseBlip.Remove();
              if ((Entity) this.Target != (Entity) null)
                this.Target.Delete();
              if ((Entity) this.TargetsCar != (Entity) null)
                this.TargetsCar.Delete();
              this.VehicleSetup2 = false;
              this.vehiclemissionid = 0;
              this.Fail = 0;
              Script.Wait(600);
              Game.FadeScreenIn(1200);
              Script.Wait(100);
              new MissionScreen().SetPass("The Courthouse Dilema", 2500000, "");
              Game.Player.Money += 2500000;
              UI.Notify(this.GetHostName() + " Good the VIP has been kiled! we can continue with our work easier now that he is dead");
            }
            if (this.Fail == 1)
            {
              this.StartTimer = false;
              this.VehicleSetup2 = false;
              this.vehiclemissionid = 0;
              Game.FadeScreenOut(600);
              Script.Wait(600);
              this.MaxGuards = 0;
              if (this.CourthouseBlip != (Blip) null)
                this.CourthouseBlip.Remove();
              if (this.TargetCarBlip != (Blip) null)
                this.TargetCarBlip.Remove();
              if ((Entity) this.Target != (Entity) null)
                this.Target.Delete();
              foreach (Vehicle viPcar in this.VIPcars)
              {
                if ((Entity) viPcar != (Entity) null)
                  viPcar.Delete();
              }
              foreach (Ped ped in this.Peds)
              {
                if ((Entity) ped != (Entity) null)
                  ped.Delete();
              }
              foreach (Blip guardBlip in this.GuardBlips)
              {
                if (guardBlip != (Blip) null)
                  guardBlip.Remove();
              }
              foreach (Ped guard in this.Guards)
              {
                if ((Entity) guard != (Entity) null)
                  guard.Delete();
              }
              if (this.CourthouseBlip != (Blip) null)
                this.CourthouseBlip.Remove();
              if ((Entity) this.Target != (Entity) null)
                this.Target.Delete();
              if ((Entity) this.TargetsCar != (Entity) null)
                this.TargetsCar.Delete();
              this.Fail = 0;
              Script.Wait(600);
              Game.FadeScreenIn(1200);
              Script.Wait(100);
              new MissionScreen().SetFail("The Courthouse Dilema", 2500000, "");
              UI.Notify(this.GetHostName() + " We needed this to look like an accident!, get out of there!");
            }
            if ((double) World.GetDistance(this.Courthouse, this.TargetsCar.Position) > 200.0 && (Entity) this.TargetsCar.GetPedOnSeat(VehicleSeat.Driver) == (Entity) this.Target && this.Timer == 36000)
            {
              UI.Notify("Check4");
              this.Timer = 42000;
              Ped target = this.Target;
              this.Target.Task.FleeFrom(Game.Player.Character);
            }
            if ((double) World.GetDistance(this.Target.Position, this.TargetsCar.Position) < 5.0 && this.Timer == 12000)
            {
              UI.Notify("Check2");
              this.Timer = 24000;
              this.Target.Task.ClearAll();
              this.Target.Task.ClearAllImmediately();
              Ped target = this.Target;
              Function.Call(Hash._0x90D2156198831D69, (InputArgument) target, (InputArgument) true);
              Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) target, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) target, (InputArgument) 17, (InputArgument) 1);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) target, (InputArgument) 1);
              Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) target, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) target, (InputArgument) 17, (InputArgument) 1);
              this.Target.Task.EnterVehicle(this.TargetsCar, VehicleSeat.Driver, 9999);
            }
            if ((Entity) this.TargetsCar.GetPedOnSeat(VehicleSeat.Driver) == (Entity) this.Target)
            {
              if (this.Timer == 24000)
              {
                UI.Notify("Check3");
                this.Timer = 36000;
                this.Target.Task.ClearAll();
                this.Target.Task.ClearAllImmediately();
                Script.Wait(10);
                Ped target = this.Target;
                Function.Call(Hash._0x90D2156198831D69, (InputArgument) target, (InputArgument) true);
                Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) target, (InputArgument) 0, (InputArgument) 0);
                Function.Call(Hash._0x9F7794730795E019, (InputArgument) target, (InputArgument) 17, (InputArgument) 1);
                Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) target, (InputArgument) 1);
                Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) target, (InputArgument) 0, (InputArgument) 0);
                Function.Call(Hash._0x9F7794730795E019, (InputArgument) target, (InputArgument) 17, (InputArgument) 1);
                this.Target.Task.DriveTo(this.TargetsCar, new Vector3(40.7f, 2927f, 54f), 20f, 100f);
              }
              if (this.TargetCarBlip == (Blip) null)
              {
                UI.Notify(this.GetHostName() + " The Vip has entered a vehicle!");
                this.TargetCarBlip = World.CreateBlip(this.TargetsCar.Position);
                this.TargetCarBlip.Sprite = BlipSprite.GetawayCar;
                this.TargetCarBlip.Color = BlipColor.Yellow;
                this.TargetCarBlip.Name = "Target in Car";
              }
              if (this.TargetCarBlip != (Blip) null && (Entity) this.TargetsCar != (Entity) null)
              {
                this.TargetCarBlip.ShowRoute = true;
                this.CourthouseBlip.ShowRoute = false;
                this.TargetCarBlip.Position = this.TargetsCar.Position;
              }
            }
            if (this.Target.IsAlive)
            {
              Vector3 position = Game.Player.Character.Position;
              if ((double) World.GetDistance(position, this.Courthouse) > 100.0)
              {
                this.CourthouseBlip.ShowRoute = true;
                this.CourthouseBlip.IsShortRange = false;
              }
              if (this.StartTimer)
              {
                if (this.TimetoWait <= this.Timer && this.Timer < 12000)
                  ++this.TimetoWait;
                if (this.TimetoWait >= this.Timer && this.Timer < 12000)
                {
                  UI.Notify("Check1");
                  this.Timer = 12000;
                  this.Target.Task.ClearAll();
                  this.Target.Task.ClearAllImmediately();
                  Ped target = this.Target;
                  Function.Call(Hash._0x90D2156198831D69, (InputArgument) target, (InputArgument) true);
                  Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) target, (InputArgument) 0, (InputArgument) 0);
                  Function.Call(Hash._0x9F7794730795E019, (InputArgument) target, (InputArgument) 17, (InputArgument) 1);
                  Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) target, (InputArgument) 1);
                  Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) target, (InputArgument) 0, (InputArgument) 0);
                  Function.Call(Hash._0x9F7794730795E019, (InputArgument) target, (InputArgument) 17, (InputArgument) 1);
                  this.Target.Task.GoTo(this.TargetsCar.Position, true, 99999);
                }
              }
              if ((double) World.GetDistance(position, this.Courthouse) < 40.0)
              {
                foreach (Ped guard in this.Guards)
                {
                  if ((Entity) guard != (Entity) null)
                  {
                    int num2 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                    Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) guard, (InputArgument) num2);
                    Function.Call(Hash._0x9F7794730795E019, (InputArgument) guard, (InputArgument) 0, (InputArgument) 0);
                    Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) guard, (InputArgument) 1);
                    guard.Task.FightAgainst(Game.Player.Character);
                    Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) guard, (InputArgument) 1);
                  }
                }
                if (this.Timer < 12000)
                {
                  UI.Notify("Check1");
                  this.Timer = 12000;
                  this.Target.Task.ClearAll();
                  this.Target.Task.ClearAllImmediately();
                  Ped target = this.Target;
                  Function.Call(Hash._0x90D2156198831D69, (InputArgument) target, (InputArgument) true);
                  Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) target, (InputArgument) 0, (InputArgument) 0);
                  Function.Call(Hash._0x9F7794730795E019, (InputArgument) target, (InputArgument) 17, (InputArgument) 1);
                  Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) target, (InputArgument) 1);
                  Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) target, (InputArgument) 0, (InputArgument) 0);
                  Function.Call(Hash._0x9F7794730795E019, (InputArgument) target, (InputArgument) 17, (InputArgument) 1);
                  this.Target.Task.GoTo(this.TargetsCar.Position, true, 99999);
                }
              }
            }
          }
        }
        if (this.vehiclemissionid == 9)
        {
          UI.ShowSubtitle("Destroy the ~r~ Vehicle ~w~ with the goods");
          if (this.VehicleWithCargo == "A" && (Entity) this.Bike1 != (Entity) null && (!this.Bike1.IsAlive && !this.SpawnedBreefcase))
          {
            this.WaitingforPlayertoPickupCase = true;
            this.SpawnedBreefcase = true;
            Vector3 position = this.Bike1.Position;
            position.X += 10f;
            ++position.Z;
            this.SpawnProp("bkr_prop_coke_block_01a", position, new Vector3(0.0f, 0.0f, 0.0f));
            this.CaseBlip = World.CreateBlip(position);
            this.CaseBlip.Position = position;
            this.CaseBlip.Sprite = BlipSprite.SpecialCargo;
            this.CaseBlip.Name = "Case";
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
          }
          if (this.VehicleWithCargo == "B" && (Entity) this.Bike2 != (Entity) null && (!this.Bike2.IsAlive && !this.SpawnedBreefcase))
          {
            this.WaitingforPlayertoPickupCase = true;
            this.SpawnedBreefcase = true;
            Vector3 position = this.Bike2.Position;
            position.X += 10f;
            ++position.Z;
            this.SpawnProp("bkr_prop_coke_block_01a", position, new Vector3(0.0f, 0.0f, 0.0f));
            this.CaseBlip = World.CreateBlip(position);
            this.CaseBlip.Position = position;
            this.CaseBlip.Sprite = BlipSprite.SpecialCargo;
            this.CaseBlip.Name = "Case";
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
          }
          if (this.VehicleWithCargo == "C" && (Entity) this.Bike3 != (Entity) null && (!this.Bike3.IsAlive && !this.SpawnedBreefcase))
          {
            this.WaitingforPlayertoPickupCase = true;
            this.SpawnedBreefcase = true;
            Vector3 position = this.Bike3.Position;
            position.X += 10f;
            ++position.Z;
            this.SpawnProp("bkr_prop_coke_block_01a", position, new Vector3(0.0f, 0.0f, 0.0f));
            this.CaseBlip = World.CreateBlip(position);
            this.CaseBlip.Position = position;
            this.CaseBlip.Sprite = BlipSprite.SpecialCargo;
            this.CaseBlip.Name = "Case";
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
          }
          if (this.VehicleWithCargo == "D" && (Entity) this.Bike4 != (Entity) null && (!this.Bike4.IsAlive && !this.SpawnedBreefcase))
          {
            this.WaitingforPlayertoPickupCase = true;
            this.SpawnedBreefcase = true;
            Vector3 position = this.Bike4.Position;
            position.X += 10f;
            ++position.Z;
            this.SpawnProp("bkr_prop_coke_block_01a", position, new Vector3(0.0f, 0.0f, 0.0f));
            this.CaseBlip = World.CreateBlip(position);
            this.CaseBlip.Position = position;
            this.CaseBlip.Sprite = BlipSprite.SpecialCargo;
            this.CaseBlip.Name = "Case";
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
          }
          if (this.VehicleWithCargo == "E" && (Entity) this.Bike5 != (Entity) null && (!this.Bike5.IsAlive && !this.SpawnedBreefcase))
          {
            this.WaitingforPlayertoPickupCase = true;
            this.SpawnedBreefcase = true;
            Vector3 position = this.Bike5.Position;
            position.X += 10f;
            position.Z += 10f;
            this.SpawnProp("bkr_prop_coke_block_01a", position, new Vector3(0.0f, 0.0f, 0.0f));
            this.CaseBlip = World.CreateBlip(position);
            this.CaseBlip.Position = position;
            this.CaseBlip.Sprite = BlipSprite.SpecialCargo;
            this.CaseBlip.Name = "Case";
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
          }
          if ((Entity) this.BreefCase != (Entity) null && (this.SpawnedBreefcase && this.WaitingforPlayertoPickupCase && (double) World.GetDistance(Game.Player.Character.Position, this.BreefCase.Position) < 2.0))
          {
            Game.Player.Money += 50000;
            this.GotBreefCase = true;
            this.vehiclemissionid = 0;
            this.VehicleSetup = false;
            Game.FadeScreenOut(700);
            Script.Wait(600);
            Script.Wait(600);
            Game.FadeScreenIn(700);
            this.stocksvalue += 100000f;
            UI.Notify(this.GetHostName() + " Good you have got the case back!");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
            this.setupdelivery = false;
            if ((Entity) this.BreefCase != (Entity) null)
              this.BreefCase.Delete();
            if (this.CaseBlip != (Blip) null)
              this.CaseBlip.Remove();
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
          }
          if ((Entity) this.Bike1 != (Entity) null)
          {
            if (this.Bike1Blip != (Blip) null)
              this.Bike1Blip.Position = this.Bike1.Position;
            if (this.Bike1.IsAlive)
            {
              if ((double) World.GetDistance(this.Bike1.Position, this.PointB) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointC, 60f, 160f);
              if ((double) World.GetDistance(this.Bike1.Position, this.PointC) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointD, 60f, 160f);
              if ((double) World.GetDistance(this.Bike1.Position, this.PointA) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 160f);
              if ((double) World.GetDistance(this.Bike1.Position, this.PointD) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointE, 60f, 160f);
              if ((double) World.GetDistance(this.Bike1.Position, this.PointE) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointA, 60f, 160f);
            }
            if (!this.Bike1.IsAlive)
              this.Bike1Blip.Remove();
            if ((Entity) this.Bike1 != (Entity) null)
            {
              if (this.Bike1Blip != (Blip) null)
                this.Bike1Blip.Position = this.Bike1.Position;
              if (this.Bike1.IsAlive)
              {
                if ((double) World.GetDistance(this.Bike1.Position, this.PointB) < 60.0)
                  this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointA, 60f, 160f);
                if ((double) World.GetDistance(this.Bike1.Position, this.PointC) < 60.0)
                  this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointE, 60f, 160f);
                if ((double) World.GetDistance(this.Bike1.Position, this.PointA) < 60.0)
                  this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointD, 60f, 160f);
                if ((double) World.GetDistance(this.Bike1.Position, this.PointD) < 60.0)
                  this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 160f);
                if ((double) World.GetDistance(this.Bike1.Position, this.PointE) < 60.0)
                  this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointC, 60f, 160f);
              }
              if (!this.Bike1.IsAlive)
                this.Bike1Blip.Remove();
            }
            if ((Entity) this.Bike2 != (Entity) null)
            {
              if (this.Bike2Blip != (Blip) null)
                this.Bike2Blip.Position = this.Bike2.Position;
              if (this.Bike2.IsAlive)
              {
                if ((double) World.GetDistance(this.Bike2.Position, this.PointB) < 60.0)
                  this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointC, 60f, 160f);
                if ((double) World.GetDistance(this.Bike2.Position, this.PointC) < 60.0)
                  this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointD, 60f, 160f);
                if ((double) World.GetDistance(this.Bike2.Position, this.PointA) < 60.0)
                  this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 160f);
                if ((double) World.GetDistance(this.Bike2.Position, this.PointD) < 60.0)
                  this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointE, 60f, 160f);
                if ((double) World.GetDistance(this.Bike2.Position, this.PointE) < 60.0)
                  this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 160f);
              }
              if (!this.Bike2.IsAlive)
                this.Bike2Blip.Remove();
            }
            if ((Entity) this.Bike3 != (Entity) null)
            {
              if (this.Bike3Blip != (Blip) null)
                this.Bike3Blip.Position = this.Bike3.Position;
              if (this.Bike3.IsAlive)
              {
                if ((double) World.GetDistance(this.Bike3.Position, this.PointB) < 60.0)
                  this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointA, 60f, 160f);
                if ((double) World.GetDistance(this.Bike3.Position, this.PointC) < 60.0)
                  this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointD, 60f, 160f);
                if ((double) World.GetDistance(this.Bike3.Position, this.PointA) < 60.0)
                  this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointE, 60f, 160f);
                if ((double) World.GetDistance(this.Bike3.Position, this.PointD) < 60.0)
                  this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointA, 60f, 160f);
                if ((double) World.GetDistance(this.Bike3.Position, this.PointE) < 60.0)
                  this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 160f);
              }
              if (!this.Bike3.IsAlive)
                this.Bike3Blip.Remove();
            }
            if ((Entity) this.Bike4 != (Entity) null)
            {
              if (this.Bike4Blip != (Blip) null)
                this.Bike4Blip.Position = this.Bike4.Position;
              if (this.Bike4.IsAlive)
              {
                if ((double) World.GetDistance(this.Bike4.Position, this.PointB) < 60.0)
                  this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointA, 60f, 160f);
                if ((double) World.GetDistance(this.Bike4.Position, this.PointC) < 60.0)
                  this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 160f);
                if ((double) World.GetDistance(this.Bike4.Position, this.PointA) < 60.0)
                  this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointB, 60f, 160f);
                if ((double) World.GetDistance(this.Bike4.Position, this.PointD) < 60.0)
                  this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointE, 60f, 160f);
                if ((double) World.GetDistance(this.Bike4.Position, this.PointE) < 60.0)
                  this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointC, 60f, 160f);
              }
              if (!this.Bike4.IsAlive)
                this.Bike4Blip.Remove();
            }
            if ((Entity) this.Bike5 != (Entity) null)
            {
              if (this.Bike5Blip != (Blip) null)
                this.Bike5Blip.Position = this.Bike5.Position;
              if (this.Bike5.IsAlive)
              {
                if ((double) World.GetDistance(this.Bike5.Position, this.PointB) < 60.0)
                  this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 160f);
                if ((double) World.GetDistance(this.Bike5.Position, this.PointC) < 60.0)
                  this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointD, 60f, 160f);
                if ((double) World.GetDistance(this.Bike5.Position, this.PointA) < 60.0)
                  this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 160f);
                if ((double) World.GetDistance(this.Bike5.Position, this.PointA) < 60.0)
                  this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 160f);
                if ((double) World.GetDistance(this.Bike5.Position, this.PointD) < 60.0)
                  this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointA, 60f, 160f);
                if ((double) World.GetDistance(this.Bike5.Position, this.PointE) < 60.0)
                  this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointC, 60f, 160f);
              }
              if (!this.Bike5.IsAlive)
                this.Bike5Blip.Remove();
            }
          }
        }
        if (this.vehiclemissionid == 8)
        {
          UI.ShowSubtitle("Destroy all enemy ~r~ Vehicles");
          if ((Entity) this.Bike1 != (Entity) null && (Entity) this.Bike2 != (Entity) null && ((Entity) this.Bike3 != (Entity) null && (Entity) this.Bike4 != (Entity) null) && (Entity) this.Bike5 != (Entity) null && (!this.Bike1.IsAlive && !this.Bike2.IsAlive && (!this.Bike3.IsAlive && !this.Bike4.IsAlive) && !this.Bike5.IsAlive))
          {
            this.vehiclemissionid = 0;
            this.VehicleSetup = false;
            Game.FadeScreenOut(700);
            Script.Wait(600);
            Script.Wait(600);
            Game.FadeScreenIn(700);
            this.stocksvalue += 250000f;
            UI.Notify(this.GetHostName() + " Ok all Enemy Bikers have been eliminated ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
            this.setupdelivery = false;
            this.Bike1.Delete();
            this.Bike2.Delete();
            this.Bike3.Delete();
            this.Bike4.Delete();
            this.Bike5.Delete();
          }
          if ((Entity) this.Bike1 != (Entity) null)
          {
            if (this.Bike1Blip != (Blip) null)
              this.Bike1Blip.Position = this.Bike1.Position;
            if (this.Bike1.IsAlive)
            {
              if ((double) World.GetDistance(this.Bike1.Position, this.PointB) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointC, 60f, 160f);
              if ((double) World.GetDistance(this.Bike1.Position, this.PointC) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointD, 60f, 160f);
              if ((double) World.GetDistance(this.Bike1.Position, this.PointA) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 160f);
              if ((double) World.GetDistance(this.Bike1.Position, this.PointD) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointE, 60f, 160f);
              if ((double) World.GetDistance(this.Bike1.Position, this.PointE) < 60.0)
                this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointA, 60f, 160f);
            }
            if (!this.Bike1.IsAlive)
              this.Bike1Blip.Remove();
          }
          if ((Entity) this.Bike2 != (Entity) null)
          {
            if (this.Bike2Blip != (Blip) null)
              this.Bike2Blip.Position = this.Bike2.Position;
            if (this.Bike2.IsAlive)
            {
              if ((double) World.GetDistance(this.Bike2.Position, this.PointB) < 60.0)
                this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointC, 60f, 160f);
              if ((double) World.GetDistance(this.Bike2.Position, this.PointC) < 60.0)
                this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointD, 60f, 160f);
              if ((double) World.GetDistance(this.Bike2.Position, this.PointA) < 60.0)
                this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointB, 60f, 160f);
              if ((double) World.GetDistance(this.Bike2.Position, this.PointD) < 60.0)
                this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointE, 60f, 160f);
              if ((double) World.GetDistance(this.Bike2.Position, this.PointE) < 60.0)
                this.Bike2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike2, this.PointA, 60f, 160f);
            }
            if (!this.Bike2.IsAlive)
              this.Bike2Blip.Remove();
          }
          if ((Entity) this.Bike3 != (Entity) null)
          {
            if (this.Bike3Blip != (Blip) null)
              this.Bike3Blip.Position = this.Bike3.Position;
            if (this.Bike3.IsAlive)
            {
              if ((double) World.GetDistance(this.Bike3.Position, this.PointB) < 60.0)
                this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointC, 60f, 160f);
              if ((double) World.GetDistance(this.Bike3.Position, this.PointC) < 60.0)
                this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointA, 60f, 160f);
              if ((double) World.GetDistance(this.Bike3.Position, this.PointA) < 60.0)
                this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointD, 60f, 160f);
              if ((double) World.GetDistance(this.Bike3.Position, this.PointD) < 60.0)
                this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointE, 60f, 160f);
              if ((double) World.GetDistance(this.Bike3.Position, this.PointE) < 60.0)
                this.Bike3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike3, this.PointA, 60f, 160f);
            }
            if (!this.Bike3.IsAlive)
              this.Bike3Blip.Remove();
          }
          if ((Entity) this.Bike4 != (Entity) null)
          {
            if (this.Bike4Blip != (Blip) null)
              this.Bike4Blip.Position = this.Bike4.Position;
            if (this.Bike4.IsAlive)
            {
              if ((double) World.GetDistance(this.Bike4.Position, this.PointB) < 60.0)
                this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointC, 60f, 160f);
              if ((double) World.GetDistance(this.Bike4.Position, this.PointC) < 60.0)
                this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointA, 60f, 160f);
              if ((double) World.GetDistance(this.Bike4.Position, this.PointA) < 60.0)
                this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointD, 60f, 160f);
              if ((double) World.GetDistance(this.Bike4.Position, this.PointD) < 60.0)
                this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointE, 60f, 160f);
              if ((double) World.GetDistance(this.Bike4.Position, this.PointE) < 60.0)
                this.Bike4.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike4, this.PointA, 60f, 160f);
            }
            if (!this.Bike4.IsAlive)
              this.Bike4Blip.Remove();
          }
          if ((Entity) this.Bike5 != (Entity) null)
          {
            if (this.Bike5Blip != (Blip) null)
              this.Bike5Blip.Position = this.Bike5.Position;
            if (this.Bike5.IsAlive)
            {
              if ((double) World.GetDistance(this.Bike5.Position, this.PointB) < 60.0)
                this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointC, 60f, 160f);
              if ((double) World.GetDistance(this.Bike5.Position, this.PointC) < 60.0)
                this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointA, 60f, 160f);
              if ((double) World.GetDistance(this.Bike5.Position, this.PointA) < 60.0)
                this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointB, 60f, 160f);
              if ((double) World.GetDistance(this.Bike5.Position, this.PointA) < 60.0)
                this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointD, 60f, 160f);
              if ((double) World.GetDistance(this.Bike5.Position, this.PointD) < 60.0)
                this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointE, 60f, 160f);
              if ((double) World.GetDistance(this.Bike5.Position, this.PointE) < 60.0)
                this.Bike5.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike5, this.PointA, 60f, 160f);
            }
            if (!this.Bike5.IsAlive)
              this.Bike5Blip.Remove();
          }
        }
      }
      if (this.VehicleSetup)
      {
        if (this.DeliveryLoc != (Blip) null && (Entity) this.VehicleId != (Entity) null && this.VehicleId.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
        {
          this.DeliveryLoc.IsShortRange = true;
          this.DeliveryLoc.ShowRoute = true;
        }
        if (!Game.Player.Character.IsAlive && this.vehiclemissionid != 8)
        {
          UI.Notify(this.GetHostName() + " Shit kid,you died, better luck next time, with the mission");
          if (this.DeliveryLoc != (Blip) null)
            this.DeliveryLoc.Remove();
          if (this.Enemy != (Blip) null)
            this.Enemy.Remove();
          if ((Entity) this.VehicleId != (Entity) null)
            this.VehicleId = (Vehicle) null;
          this.setupdelivery = false;
          this.VehicleSetup = false;
        }
        if (this.vehiclemissionid == 7)
        {
          this.setupdelivery = Game.Player.WantedLevel <= 0;
          if (this.setupwantedfordelivery)
          {
            num1 = this.waittimeforwanted++;
            if (this.triggerwanted == this.waittimeforwanted)
            {
              this.waittimeforwanted = 0;
              Game.Player.WantedLevel = this.RandomWanted.Next(3, 5);
              this.setupwantedfordelivery = false;
              UI.Notify(this.GetHostName() + " Shit kid, escape the cops, then head to the drop off");
              Vehicle vehicle1 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1351.74f, 4496f, 57f));
              vehicle1.IsDriveable = true;
              vehicle1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
              Vehicle vehicle2 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1714.99f, 4580f, 39.9f));
              vehicle2.IsDriveable = true;
              vehicle2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
              Vehicle vehicle3 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1715.99f, 4565f, 39.9f));
              vehicle3.IsDriveable = true;
              vehicle3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
            }
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Deliverypoint) < 100.0 && this.setupdelivery)
          {
            Game.FadeScreenOut(700);
            Script.Wait(600);
            this.VehicleId.Delete();
            Game.Player.Character.Position = this.Deliverypoint;
            Script.Wait(600);
            Game.FadeScreenIn(700);
            this.stocksvalue += 75000f;
            UI.Notify(this.GetHostName() + " ok the goods have been delivered ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
            this.setupdelivery = false;
            this.DeliveryLoc.Remove();
            if (this.Enemy != (Blip) null)
              this.Enemy.Remove();
            this.VehicleSetup = false;
          }
        }
        if (this.vehiclemissionid == 6)
        {
          this.setupdelivery = Game.Player.WantedLevel <= 0;
          if (this.setupwantedfordelivery)
          {
            num1 = this.waittimeforwanted++;
            if (this.triggerwanted == this.waittimeforwanted)
            {
              this.waittimeforwanted = 0;
              Game.Player.WantedLevel = this.RandomWanted.Next(2, 4);
              this.setupwantedfordelivery = false;
              UI.Notify(this.GetHostName() + " Shit kid, escape the cops, then head to the drop off");
              Vehicle vehicle1 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1351.74f, 4496f, 57f));
              vehicle1.IsDriveable = true;
              vehicle1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
              Vehicle vehicle2 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1714.99f, 4580f, 39.9f));
              vehicle2.IsDriveable = true;
              vehicle2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
              Vehicle vehicle3 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1715.99f, 4565f, 39.9f));
              vehicle3.IsDriveable = true;
              vehicle3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
            }
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Deliverypoint) < 100.0 && this.setupdelivery)
          {
            Game.FadeScreenOut(700);
            Script.Wait(600);
            this.VehicleId.Delete();
            Game.Player.Character.Position = this.Deliverypoint;
            Script.Wait(600);
            Game.FadeScreenIn(700);
            this.stocksvalue += 75000f;
            UI.Notify(this.GetHostName() + " ok the goods have been delivered ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
            this.setupdelivery = false;
            this.DeliveryLoc.Remove();
            if (this.Enemy != (Blip) null)
              this.Enemy.Remove();
            this.VehicleSetup = false;
          }
        }
        if (this.vehiclemissionid == 5)
        {
          this.setupdelivery = Game.Player.WantedLevel <= 0;
          if (this.setupwantedfordelivery)
          {
            num1 = this.waittimeforwanted++;
            if (this.triggerwanted == this.waittimeforwanted)
            {
              this.waittimeforwanted = 0;
              Game.Player.WantedLevel = this.RandomWanted.Next(0, 3);
              this.setupwantedfordelivery = false;
              Vehicle vehicle1 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1351.74f, 4496f, 57f));
              vehicle1.IsDriveable = true;
              vehicle1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle1.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle1.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
              Vehicle vehicle2 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1714.99f, 4580f, 39.9f));
              vehicle2.IsDriveable = true;
              vehicle2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle2.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle2.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
              Vehicle vehicle3 = World.CreateVehicle((Model) VehicleHash.Police, new Vector3(1715.99f, 4565f, 39.9f));
              vehicle3.IsDriveable = true;
              vehicle3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Cop01SFY);
              vehicle3.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Cop01SMY);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Weapons.Give(WeaponHash.APPistol, 999, true, true);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Driver).Task.ShootAt(Game.Player.Character);
              vehicle3.GetPedOnSeat(VehicleSeat.Passenger).Task.ShootAt(Game.Player.Character);
              UI.Notify(this.GetHostName() + " Shit kid, escape the cops, then head to the drop off");
            }
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Deliverypoint) < 100.0 && this.setupdelivery)
          {
            Game.FadeScreenOut(700);
            Script.Wait(600);
            this.VehicleId.Delete();
            Game.Player.Character.Position = this.Deliverypoint;
            Script.Wait(600);
            Game.FadeScreenIn(700);
            this.stocksvalue += 75000f;
            UI.Notify(this.GetHostName() + " ok the goods have been delivered ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
            this.setupdelivery = false;
            this.DeliveryLoc.Remove();
            if (this.Enemy != (Blip) null)
              this.Enemy.Remove();
            this.VehicleSetup = false;
          }
        }
        if (this.vehiclemissionid == 4 && ((double) World.GetDistance(Game.Player.Character.Position, this.Deliverypoint) < 100.0 && this.setupdelivery))
        {
          Game.FadeScreenOut(700);
          Script.Wait(600);
          this.VehicleId.Delete();
          Game.Player.Character.Position = this.Deliverypoint;
          Script.Wait(600);
          Game.FadeScreenIn(700);
          this.stocksvalue += 25000f;
          UI.Notify(this.GetHostName() + " ok the goods have been delivered ");
          UI.Notify(this.GetHostName() + " Stocks just Increased");
          UI.Notify("Max Stocks: " + this.maxstocks.ToString());
          UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
          UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
          UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
          this.setupdelivery = false;
          this.DeliveryLoc.Remove();
          if (this.Enemy != (Blip) null)
            this.Enemy.Remove();
          this.VehicleSetup = false;
        }
        if (!this.VehicleId.IsAlive)
        {
          if (this.vehiclemissionid == 1)
          {
            this.VehicleId = (Vehicle) null;
            this.VehicleSetup = false;
            if (this.Enemy != (Blip) null)
              this.Enemy.Remove();
            this.stocksvalue += 25000f;
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is destoryed ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.vehiclemissionid == 2)
          {
            this.VehicleId = (Vehicle) null;
            this.VehicleSetup = false;
            if (this.Enemy != (Blip) null)
              this.Enemy.Remove();
            this.stocksvalue += 75000f;
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is destoryed ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Max Stocks: " + this.maxstocks.ToString());
            UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
            UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
            UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
            Game.Player.WantedLevel = new System.Random().Next(0, 3);
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.vehiclemissionid == 3)
          {
            this.VehicleId = (Vehicle) null;
            this.VehicleSetup = false;
            if (this.Enemy != (Blip) null)
              this.Enemy.Remove();
            this.stocksvalue += 250000f;
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is destoryed ");
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
      if (!this.EnemySetup)
        return;
      if ((this.Chooseenemynum == 2 || this.Chooseenemynum == 3) && ((double) (int) Game.Player.Character.Position.DistanceTo(this.EnemyPed.Position) > 100.0 ? 1 : 0) == 0)
      {
        UI.Notify(this.GetHostName() + " right, you found the target");
        this.EnemyPed.Task.FightAgainst(Game.Player.Character);
      }
      if (!this.EnemyPed.IsAlive)
      {
        if (this.Chooseenemynum == 1)
        {
          this.Enemy.Remove();
          Game.Player.Money += 25000;
          this.EnemySetup = false;
          UI.Notify(this.GetHostName() + " right, job done here is your cash");
        }
        else if (this.Chooseenemynum == 2)
        {
          this.Enemy.Remove();
          Game.Player.Money += 100000;
          this.EnemySetup = false;
          UI.Notify(this.GetHostName() + " right, job done here is your cash");
        }
        if (this.Chooseenemynum == 3)
        {
          this.Enemy.Remove();
          Game.Player.Money += 250000;
          this.EnemySetup = false;
          UI.Notify(this.GetHostName() + " right, job done here is your cash");
        }
      }
    }

    public void OnKeyDown()
    {
      if (!Game.IsControlJustPressed(2, GTA.Control.VehicleDuck))
        ;
      if (!Game.IsControlJustPressed(2, GTA.Control.Context) || (double) World.GetDistance(Game.Player.Character.Position, this.BuyMarker) >= 4.0)
        return;
      if (this.purchaselvl == 0)
      {
        if (Game.Player.Money >= 1000000)
        {
          Game.Player.Money -= 1000000;
          this.bought = true;
          this.purchaselvl = 1;
          this.maxstocks = 10;
          this.profitMargin = 1.2f;
          this.Config.SetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
          this.Config.Save();
          UI.Notify(this.GetHostName() + " I just heard, your my new boss, well welcome aboard, we will hopefully do great things together");
          UI.Notify("Max Stocks: " + this.maxstocks.ToString());
          UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
          UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
          UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
        }
        else
          UI.Notify(this.GetHostName() + " You dont have enought money for this Business!");
      }
      else
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        if (!this.mainMenu.Visible)
          this.mainMenu.Visible = !this.mainMenu.Visible;
      }
    }

    public class MCBusinessLocations : Script
    {
      public int TypeNo { get; set; }

      public string TypeName { get; set; }

      public Vector3 Enterance { get; set; }

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
        this.SupplyTruckSpawn = STS;
        this.SupplyTruckHeading = STH;
        this.Price = P;
        this.Name = N;
        this.CameraPos = CP;
        this.CameraHeading = CH;
      }
    }
  }
}
