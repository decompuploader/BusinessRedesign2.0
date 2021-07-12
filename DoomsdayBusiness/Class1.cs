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

namespace DoomsdayBusiness
{
  public class Class1 : Script
  {
    public ScriptSettings ConfigDesign;
    public string FacilityGraphic;
    public string FacilityOrbitalCannon;
    public string FacilitySecurityRoom;
    public string FacilityLounge;
    public string FacilitySleepingQuarters;
    public int FacilityShellColor;
    public int FacilityGraphicColor;
    public int FacilityOrbitalCannonColor;
    public int FacilitySecurityRoomColor;
    public int FacilityLoungeColor;
    public int FacilitySleepingQuartersColor;
    public Vector3 MenuMarker2 = new Vector3(472f, 4788f, -59.5f);
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    private ScriptSettings MainConfigFile;
    public float BusinessUpgradeIncreaseGain = 75000f;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    public int BusinessLocation = 0;
    public bool bought;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public int stockstimer;
    public int waittime = 3200;
    public int DisplayWait;
    public Blip Facility;
    public SaveCar SC;
    public Vector3 Entry = new Vector3(-2228.79f, 2399.25f, 11f);
    public Vector3 Exit = new Vector3(486.59f, 4819.87f, -59.4f);
    private ScriptSettings Config;
    private Keys Key1;
    public Vector3 ThrusterPos = new Vector3(470.977f, 4800.9f, -53.9f);
    public Vehicle ThrusterV;
    public Vector3 ChernobogPos = new Vector3(512.772f, 4786.44f, -52f);
    public Vehicle ChernobogV;
    public Vector3 KhanjalIpos = new Vector3(476.432f, 4846.24f, -52f);
    public Vehicle KhanjalIV;
    public Vector3 Akulapos = new Vector3(478.85f, 4825.403f, -58f);
    public Vehicle AkulaV;
    public Vector3 Strombergpos = new Vector3(467.277f, 4810.27f, -58f);
    public Vehicle StrombergV;
    public Vector3 Deluxopos = new Vector3(467.02f, 4815.15f, -58f);
    public Vehicle DeluxoV;
    public Vector3 Barragepos = new Vector3(455.597f, 4819.05f, -53f);
    public Vehicle BarrageV;
    public Vector3 Avengerpos = new Vector3(488.663f, 4789.05f, -57f);
    public Vehicle AvengerV;
    public Vector3 Vehicle1Loc = new Vector3(471.78f, 4843.6f, -54.6f);
    public Vehicle Vehicle1;
    public Vector3 Vehicle2Loc = new Vector3(468.07f, 4842.2f, -54.6f);
    public Vehicle Vehicle2;
    public Vector3 Vehicle3Loc = new Vector3(465.45f, 4839.092f, -54.6f);
    public Vehicle Vehicle3;
    public Vector3 Vehicle4Loc = new Vector3(463.6f, 4835.5f, -54.6f);
    public Vehicle Vehicle4;
    public Vector3 Vehicle5Loc = new Vector3(481.3f, 4846.2f, -54.6f);
    public Vehicle Vehicle5;
    public Vector3 Vehicle6Loc = new Vector3(485.88f, 4845.8f, -54.6f);
    public Vehicle Vehicle6;
    public Vector3 Vehicle7Loc = new Vector3(489.9f, 4844.32f, -54.6f);
    public Vehicle Vehicle7;
    public bool createdVehicles;
    public Vehicle VehicleInUse;
    public Vector3 OutsideSpawn = new Vector3(-2231.41f, 2418.56f, 15f);
    public Vector3 MenuMarker = new Vector3(407.22f, 4825.9f, -60f);
    public Vector3 OrbitalCannonMarker = new Vector3(330.541f, 4830.42f, -59f);
    public Vector3 Agent14Spawn = new Vector3(408.731f, 4829.46f, -59f);
    public Ped Agent14;
    public Vector3 LesterSpawn = new Vector3(352.514f, 4874.36f, -61f);
    public Ped Lester;
    public Vector3 Gunlockerpos = new Vector3(422.667f, 4811.28f, -60f);
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private UIMenu Extras;
    private UIMenu methgarage;
    private UIMenu Missions;
    private UIMenu ProductStock;
    public int GunlockerBought;
    public int VehicleBayBought;
    public int AvengerBought;
    public int AkulaBought;
    public int ThrusterBought;
    public int ChernobogBought;
    public int BarrageBought;
    public int DeluxoBought;
    public int StrombergBought;
    public int KhanjaliBought;
    public Vector3 SourcingMenu = new Vector3(479.459f, 4768.66f, -60f);
    private MenuPool modMenuPool2;
    private UIMenu mainMenu2;
    private UIMenu Customization;
    private UIMenu source;
    public Vector3 VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
    public Vehicle VehicleToGet;
    public bool GotVehicle;
    public Blip MillitaryAsset;
    public float increaseGain;
    public int missionnum;
    public Vehicle EnemyV;
    public Blip EnemyVehicleBLip;
    public Vector3 EnemySpawn;
    public bool MissionSetup;
    public UIMenu SamSites;
    public Vector3 Sam1Loc;
    public Vector3 Sam2Loc;
    public Vector3 Sam3Loc;
    public Vehicle Sam1;
    public Vehicle Sam2;
    public Vehicle Sam3;
    public Blip Sam1blip;
    public Blip Sam2blip;
    public Blip Sam3blip;
    public UIMenu Elimination;
    public Vector3 EndPoint;
    public Blip EndPointBlip;
    public UIMenu WeaponizedCargo;
    public bool triggerWeaponizedCargo;
    public VehicleHash VehicleId;
    public int timer;
    public bool triggerWeaponizedCargo2;
    public bool iscloaked;
    public int vehiclemissionid;
    public bool VehicleSetup2;
    public UIMenu CoopElimination;
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
    private Vehicle DeliveryVehicle;
    public Vector3 Agent14SpawnCar;
    public bool isInInterior;
    public AllStocks AllStocks;
    public UIMenu SpecialMissions;
    public List<Ped> Guards = new List<Ped>();
    public Vehicle VtoGet;
    public Blip VtoGetBlip;
    public Prop ChairProp;
    public int checkpointat;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public List<Prop> Props = new List<Prop>();
    public List<string> PropIds = new List<string>();
    public List<Vehicle> CaptureVehicle = new List<Vehicle>();
    public List<Vector3> SamPoints = new List<Vector3>();
    public List<Blip> SamBips = new List<Blip>();
    public float Payout;
    public int SamsTakenOut;
    public Vector3 MarkerPos;
    public bool NearSam;
    public bool IsHacking;
    public int HackingTimer;
    public int MissileTimer;
    public int HeliTimer;
    public int Maxhelis = 10;
    public int numberofHelis = 0;
    public List<Vehicle> Dinghys = new List<Vehicle>();
    public List<Vehicle> Truck_Trailer = new List<Vehicle>();
    public Vector3 DropZoneVector = new Vector3();
    private UIMenu RemoveMenu;
    public Vehicle Heli;
    public Ped Avon;
    public Ped Jugg1;
    public Ped Jugg2;
    public bool CloseTotarget;
    private UIMenu GarageMenu;
    public int Stage;
    public Vehicle MissionVehicle1;
    public Vehicle MissionVehicle2;
    public Vehicle MissionVehicle3;
    public Vehicle MissionVehicle4;
    public Vehicle MissionVehicle5;
    public Vehicle MissionVehicle6;
    public bool HackDone;
    public bool IsSittinginCeoSeat;
    public Vector3 ChairPos = new Vector3(359.98f, 4843.29f, -60.5f);
    public float P_Rotation = 60f;
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
    private MenuPool MVmodMenuPool;
    private UIMenu MVmainMenu;
    public int Tintscount = 32;
    public List<Vector3> RIpPostion = new List<Vector3>();
    public List<float> RIpRotation = new List<float>();
    public List<Ped> RIPeds = new List<Ped>();
    public bool RICreatedPeds;
    public List<Prop> RIProps = new List<Prop>();
    public List<string> RIPropIds = new List<string>();
    public bool CreatedProp;
    public ScriptSettings IniSettings;
    public ScriptSettings ConfigInteriorD;
    public Vector3 RIMenuMarker = new Vector3(472f, 4788f, -59.5f);
    private MenuPool RImodMenuPool;
    private UIMenu RImainMenu;
    private UIMenu RIMenu;
    private Vector3 Fz = new Vector3(-2255.79f, 243.25f, 16f);
    private Vector3 GSD1 = new Vector3(1320f, 2846f, 50f);
    private Vector3 GSD2 = new Vector3(2045f, 1720f, 108f);
    private Vector3 GSD3 = new Vector3(2804f, 3926f, 52f);
    private Vector3 GSD4 = new Vector3(54f, 2624f, 90f);
    private Vector3 MountGordo = new Vector3(3432f, 5497f, 31f);
    private Vector3 Paleto = new Vector3(-28f, 6836f, 19f);
    private Vector3 Resorvior = new Vector3(1898f, 302f, 167f);
    private Vector3 ZancudoRiver = new Vector3(1.8f, 3358f, 48f);
    private Vector3 ChiliadFacilityEntryPos = new Vector3(-361.57f, 4827.75f, 143.17f);
    private Vector3 ChiliadFacilityExitPos = new Vector3(1256.17f, 4799.07f, -40.17f);
    private Vector3 ChiliadFacilitySpawnPosIn = new Vector3(1256.17f, 4799.07f, -40.17f);
    private Vector3 ChiliadFacilitySpawnPosOut = new Vector3(-364.94f, 4828.87f, 142.41f);
    public List<Prop> Chairs = new List<Prop>();
    public Prop LDoor;
    public Prop RDoor;
    public Prop EnterProp;
    public bool CreatedEnter;
    public int nextDrawTime;
    public int FireWait;
    public int Countdown;
    public int changezoomtimer;
    public Vector3 StartCoord = new Vector3(-2228.79f, 2399.25f, 11f);
    public Vector3 DetectPos;
    public int Timer;
    public Vector3 OrbitalCannonPos = new Vector3(327.6f, 4826f, -60.4f);
    public Camera CannonCamera;
    public Vector3 FirePos;
    public Vector3 DefaultFirePos;
    public bool IsInViewMode;
    public Entity Missile;
    public bool CanFire;
    public bool IsON;
    public Vehicle LockedVehicle;
    private Vector3 ran;
    public Scaleform ORBITALSCALEFORM;
    public int ORBITAL = 0;
    public float Height = 0.0f;
    public int MaxHeight;
    public int MinHeight;
    public float FireTimer = 0.0f;
    private MenuPool GLmodMenuPool;
    private UIMenu GLmainMenu;
    public int MoneyVaultBought = 1;
    public float MoneyStored;
    public float Commission;
    public UIMenu MoneyMenu;
    public Vector3 MoneyStorageMarker = new Vector3(424f, 4827f, -60f);
    public int currentbank;
    public bool read;
    public Blip Range;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public UIMenu SamArray;
    public Prop SamArray1;
    public Prop SamArray2;
    public Prop SamArray3;
    public Prop SamArray4;
    public Prop SamArray5;
    public Prop SamArray6;
    public Prop SamArray7;
    public bool SourcingMissionOn;
    public List<Ped> SourcingmissionPeds = new List<Ped>();
    public Vehicle VehicleInuse;
    public bool SetInterior;
    public List<Prop> OSHatch = new List<Prop>();
    public Prop OShatchDoorL;
    public Prop OShatchDoorR;
    public Prop OShatchBase;
    public Prop OSRig;
    public Prop ClosedHatch;
    public bool GrabbedHatch;
    public Vector3 CurrentHatch;
    public bool HatchOpen;
    public bool HatchClosed;
    public bool HatchClosed_final;
    public Vector3 HatchLastPos;
    public bool UseOldMarker = false;
    public Vector3 MBTOfficeSitPos1 = new Vector3(366.4245f, 4844.531f, -60.46f);
    public float MBTOfficeSitRot1 = 137.78f;
    public Vector3 MBTOfficeSitPos2 = new Vector3(364.83f, 4845.075f, -60.46f);
    public float MBTOfficeSitRot2 = 176.288f;
    public Vector3 MBTOfficeSitPos3 = new Vector3(362.56f, 4841.89f, -60.46f);
    public float MBTOfficeSitRot3 = -65f;
    public Vector3 MBTOfficeSitPos4 = new Vector3(366.56f, 4840.77f, -60.46f);
    public float MBTOfficeSitRot4 = 24.95f;
    public bool sitting;
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
    public int SupplyMission = 1;
    public Blip SupplyGarageBlip;
    public Prop BaseHatch;
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public bool AtHAtch;
    public bool CreatedChair;
    public bool Active;
    public int Amt;
    public int iLocal_8077;
    public bool FirstTime;
    public string ChairPropModel = "ex_prop_offchair_exec_01";
    private Vector3 Chair1 = new Vector3(404.7962f, 4829.388f, -59.9f);
    private Vector3 Chair2 = new Vector3(409.214f, 4829.651f, -59.9f);
    private Vector3 Chair3 = new Vector3(418.0879f, 4826.04f, -59.9f);
    private Vector3 Chair4 = new Vector3(419.4717f, 4815.391f, -59.9f);
    private Vector3 Chair5 = new Vector3(413.7146f, 4811.048f, -59.9f);
    private Vector3 Chair6 = new Vector3(431.1785f, 4825.258f, -59.9f);
    private Vector3 Chair7 = new Vector3(430.357f, 4824.09f, -59.9f);
    public List<Prop> PrivacyGlass = new List<Prop>();
    public bool GotPrivacyBase;
    public bool PrivacyGlassOn;
    public Prop glass1;
    public Prop glass2;
    public Prop glass3;
    public int PrivacyGlassBought = 0;
    public bool GotGlassBase1;
    public bool GotGlassBase2;
    public bool GotGlassBase3;
    public Prop KeyPad;
    public int ElevatorSwitch = 0;
    public bool ElevatorLift;
    public int Elevator;
    public int BigStage;
    public int BigScreen;
    public bool CleanUpBigScreen;
    public string ScreenGUITex = "CS_NHP_IAA_INT_01";
    public string ScreenGUIDIC = "IAA_INT_01";
    public List<string> Dicts = new List<string>()
    {
      "IAA_INT_01",
      "IAA_INT_02",
      "IAA_INT_03",
      "IAA_INT_04",
      "IAA_INT_05",
      "IAA_INT_06",
      "IAA_INT_07",
      "IAA_INT_08",
      "IAA_INT_09",
      "IAA_INT_10",
      "IAA_INT_11",
      "IAA_INT_12",
      "IAAJ_INT_02",
      "IAAJ_INT_03",
      "SIL_INT_01",
      "SIL_INT_02",
      "SIL_INT_03",
      "SUB_INT_01",
      "SUB_INT_02",
      "SUB_INT_03",
      "SUB_INT_05",
      "SUB_INT_06",
      "SUB_INT_07",
      "SUB_INT_08"
    };
    public List<string> Texture = new List<string>()
    {
      "CS_NHP_IAA_INT_01",
      "CS_NHP_IAA_INT_02",
      "CS_NHP_IAA_INT_03",
      "CS_NHP_IAA_INT_04",
      "CS_NHP_IAA_INT_05",
      "CS_NHP_IAA_INT_06",
      "CS_NHP_IAA_INT_07",
      "CS_NHP_IAA_INT_08",
      "CS_NHP_IAA_INT_09",
      "CS_NHP_IAA_INT_10",
      "CS_NHP_IAA_INT_11",
      "CS_NHP_IAA_INT_12",
      "CS_NHP_IAAJ_INT_02",
      "CS_NHP_IAAJ_INT_03",
      "CS_NHP_SIL_INT_01",
      "CS_NHP_SIL_INT_02",
      "CS_NHP_SIL_INT_03",
      "CS_NHP_SUB_INT_01",
      "CS_NHP_SUB_INT_02",
      "CS_NHP_SUB_INT_03",
      "CS_NHP_SUB_INT_05",
      "CS_NHP_SUB_INT_06",
      "CS_NHP_SUB_INT_07",
      "CS_NHP_SUB_INT_08"
    };
    public int TextDicID = 2;
    public int OCstage;
    private bool cannonactive = false;
    private int cannon_index = -1;
    private Scaleform Cannon_Scale;
    private Camera _mainCamera;
    private int newsoundid = -1;
    private Vector3 LocationMem;
    private Vector3 rotationmem;
    private int Cannon_countdown;
    private int canin = -1;
    private float cannoncharge = 1f;
    private int rechargerate;
    private float camerazoom = 400f;
    private int zoomindex = 0;
    private float zoomscale = 1f;
    public int LiveryColor;

    public Model RequestModel(Model model)
    {
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

    public Model RequestModel(string Name)
    {
      Model model = new Model(Name);
      model.Request(10000);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(150);
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

    private void LoadIniFileDesign(string iniName)
    {
      try
      {
        this.ConfigDesign = ScriptSettings.Load(iniName);
        this.FacilityGraphic = this.ConfigDesign.GetValue<string>("Configurations", "FacilityGraphic", this.FacilityGraphic);
        this.FacilityOrbitalCannon = this.ConfigDesign.GetValue<string>("Configurations", "FacilityOrbitalCannon", this.FacilityOrbitalCannon);
        this.FacilitySecurityRoom = this.ConfigDesign.GetValue<string>("Configurations", "FacilitySecurityRoom", this.FacilitySecurityRoom);
        this.FacilityLounge = this.ConfigDesign.GetValue<string>("Configurations", "FacilityLounge", this.FacilityLounge);
        this.FacilitySleepingQuarters = this.Config.GetValue<string>("Configurations", "FacilitySleepingQuarters", this.FacilitySleepingQuarters);
        this.FacilityShellColor = this.ConfigDesign.GetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
        this.FacilityGraphicColor = this.ConfigDesign.GetValue<int>("Configurations", "FacilityGraphicColor", this.FacilityGraphicColor);
        this.FacilityOrbitalCannonColor = this.ConfigDesign.GetValue<int>("Configurations", "FacilityOrbitalCannonColor", this.FacilityOrbitalCannonColor);
        this.FacilitySecurityRoomColor = this.ConfigDesign.GetValue<int>("Configurations", "FacilitySecurityRoomColor", this.FacilitySecurityRoomColor);
        this.FacilityLoungeColor = this.ConfigDesign.GetValue<int>("Configurations", "FacilityLoungeColor", this.FacilityLoungeColor);
        this.FacilitySleepingQuartersColor = this.ConfigDesign.GetValue<int>("Configurations", "FacilitySleepingQuartersColor", this.FacilitySleepingQuartersColor);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: InteriorDesign.ini Failed To Load.");
      }
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
          this.Entry = new Vector3(-2228.79f, 2399.25f, 11f);
          this.OutsideSpawn = new Vector3(-2231.41f, 2418.56f, 15f);
          this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
        }
        if (this.BusinessLocation == 1)
        {
          this.Entry = new Vector3(1272f, 2833f, 48f);
          this.OutsideSpawn = new Vector3(1288f, 2847f, 48f);
          this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
        }
        if (this.BusinessLocation == 2)
        {
          this.Entry = new Vector3(2088f, 1761f, 103f);
          this.OutsideSpawn = new Vector3(2075f, 1750f, 104f);
          this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
        }
        if (this.BusinessLocation == 3)
        {
          this.Entry = new Vector3(2754f, 3904f, 44f);
          this.OutsideSpawn = new Vector3(2765f, 3916f, 45f);
          this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
        }
        if (this.BusinessLocation == 4)
        {
          this.Entry = new Vector3(1.3f, 2599f, 85f);
          this.OutsideSpawn = new Vector3(16f, 2606f, 86f);
          this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
        }
        if (this.BusinessLocation == 5)
        {
          this.Entry = new Vector3(3387f, 5509f, 24f);
          this.OutsideSpawn = new Vector3(3400f, 5506f, 26f);
          this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
        }
        if (this.BusinessLocation == 6)
        {
          this.Entry = new Vector3(21f, 6824f, 14f);
          this.OutsideSpawn = new Vector3(5.41f, 6831f, 17f);
          this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
        }
        if (this.BusinessLocation == 7)
        {
          this.Entry = new Vector3(1885f, 303f, 162f);
          this.OutsideSpawn = new Vector3(1875f, 285f, 164f);
          this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
        }
        if (this.BusinessLocation != 8)
          return;
        this.Entry = new Vector3(-2f, 3347f, 40f);
        this.OutsideSpawn = new Vector3(-7.8f, 3326f, 41f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    public void MainModRefresh()
    {
      UI.Notify("~g~ Found Refresh Sequence~w~");
      this.LoadMain("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      this.BusinessLocation = this.MainConfigFile.GetValue<int>("Misc", "BusinessLocation", this.BusinessLocation);
      this.GrabbedHatch = false;
      this.HatchClosed = false;
      this.HatchOpen = false;
      if (this.BusinessLocation == 0)
      {
        this.Entry = new Vector3(-2228.79f, 2399.25f, 11f);
        this.OutsideSpawn = new Vector3(-2231.41f, 2418.56f, 15f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      if (this.BusinessLocation == 1)
      {
        this.Entry = new Vector3(1272f, 2833f, 48f);
        this.OutsideSpawn = new Vector3(1288f, 2847f, 48f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      if (this.BusinessLocation == 2)
      {
        this.Entry = new Vector3(2088f, 1761f, 103f);
        this.OutsideSpawn = new Vector3(2075f, 1750f, 104f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      if (this.BusinessLocation == 3)
      {
        this.Entry = new Vector3(2754f, 3904f, 44f);
        this.OutsideSpawn = new Vector3(2765f, 3916f, 45f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      if (this.BusinessLocation == 4)
      {
        this.Entry = new Vector3(1.3f, 2599f, 85f);
        this.OutsideSpawn = new Vector3(16f, 2606f, 86f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      if (this.BusinessLocation == 5)
      {
        this.Entry = new Vector3(3387f, 5509f, 24f);
        this.OutsideSpawn = new Vector3(3400f, 5506f, 26f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      if (this.BusinessLocation == 6)
      {
        this.Entry = new Vector3(21f, 6824f, 14f);
        this.OutsideSpawn = new Vector3(5.41f, 6831f, 17f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      if (this.BusinessLocation == 7)
      {
        this.Entry = new Vector3(1885f, 303f, 162f);
        this.OutsideSpawn = new Vector3(1875f, 285f, 164f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      if (this.BusinessLocation == 8)
      {
        this.Entry = new Vector3(-2f, 3347f, 40f);
        this.OutsideSpawn = new Vector3(-7.8f, 3326f, 41f);
        this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
      }
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.SetupMarker();
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
      this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      if (this.purchaselvl > 0)
      {
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Facility, (InputArgument) 590);
        this.Facility.Color = this.Blip_Colour;
        this.Facility.Name = "Doomsday Heist Business Facility";
        this.Facility.IsShortRange = true;
        this.Facility.Alpha = (int) byte.MaxValue;
      }
      if (this.purchaselvl != 0)
        return;
      Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Facility, (InputArgument) 590);
      this.Facility.Color = BlipColor.White;
      this.Facility.Name = "Doomsday Heist Business Facility";
      this.Facility.IsShortRange = true;
      this.Facility.Alpha = 0;
    }

    public void MainModDestroy()
    {
      if (!(this.Facility != (Blip) null))
        return;
      this.Facility.Remove();
    }

    public void SpawnProp(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        World.CreateProp(model, Pos, Rot, true, false);
        foreach (Prop nearbyProp in World.GetNearbyProps(Pos, 60f, model))
        {
          nearbyProp.SetNoCollision((Entity) nearbyProp, false);
          nearbyProp.LodDistance = 3000;
          nearbyProp.IsInvincible = true;
          this.Props.Add(nearbyProp);
        }
        Script.Wait(1);
      }
      model.MarkAsNoLongerNeeded();
    }

    public void RISpawnProp(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        World.CreateProp(model, Pos, Rot, true, false);
        foreach (Prop nearbyProp in World.GetNearbyProps(Pos, 80f))
        {
          nearbyProp.SetNoCollision((Entity) nearbyProp, false);
          nearbyProp.LodDistance = 3000;
          nearbyProp.IsInvincible = true;
          this.RIProps.Add(nearbyProp);
        }
      }
      model.MarkAsNoLongerNeeded();
    }

    public void RISpawnPropChair(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        this.Chairs.Add(World.CreateProp(model, Pos, Rot, true, false));
      }
      model.MarkAsNoLongerNeeded();
    }

    public float GetDistance()
    {
      Vector3 position = Game.Player.Character.Position;
      return World.GetDistance(new Vector3(position.X, position.Y, World.GetGroundHeight(position)), this.CannonCamera.Position);
    }

    public void DrawScaleform()
    {
      this.MinHeight = (int) ((double) World.GetGroundHeight(this.FirePos) + 50.0);
      this.MaxHeight = (int) ((double) World.GetGroundHeight(this.FirePos) + 200.0);
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      Convert.ToInt32(resolutionMantainRatio.Width);
      Convert.ToInt32(resolutionMantainRatio.Height);
      this.ORBITALSCALEFORM = new Scaleform(Function.Call<int>((Hash) 7343092289874906331, (InputArgument) "ORBITAL_CANNON_CAM"));
      if ((double) this.FireTimer == 0.0)
        this.ORBITALSCALEFORM.CallFunction("SET_CHARGING_LEVEL", (object) 1f);
      if ((double) this.FireTimer < 1.0 && this.FireWait < Game.GameTime)
      {
        this.FireTimer += 0.01f;
        this.FireWait = Game.GameTime + 10;
        this.ORBITALSCALEFORM.CallFunction("SET_CHARGING_LEVEL", (object) this.FireTimer);
      }
      if (this.Countdown == 1)
        this.ORBITALSCALEFORM.CallFunction("SET_COUNTDOWN", (object) 3);
      if (this.Countdown == 2)
        this.ORBITALSCALEFORM.CallFunction("SET_COUNTDOWN", (object) 2);
      if (this.Countdown == 3)
        this.ORBITALSCALEFORM.CallFunction("SET_COUNTDOWN", (object) 1);
      if (this.Countdown == 0)
        this.ORBITALSCALEFORM.CallFunction("SET_COUNTDOWN", (object) 0);
      if (this.changezoomtimer < Game.GameTime)
      {
        this.changezoomtimer = Game.GameTime + 100;
        if ((double) this.GetDistance() < 60.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 1f);
        if ((double) this.GetDistance() >= 60.0 && (double) this.GetDistance() < 65.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.95f);
        if ((double) this.GetDistance() >= 65.0 && (double) this.GetDistance() < 70.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.9f);
        if ((double) this.GetDistance() >= 70.0 && (double) this.GetDistance() < 75.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.85f);
        if ((double) this.GetDistance() >= 75.0 && (double) this.GetDistance() < 80.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.8f);
        if ((double) this.GetDistance() >= 80.0 && (double) this.GetDistance() < 85.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.75f);
        if ((double) this.GetDistance() >= 85.0 && (double) this.GetDistance() < 90.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.7f);
        if ((double) this.GetDistance() >= 90.0 && (double) this.GetDistance() < 95.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.65f);
        if ((double) this.GetDistance() >= 95.0 && (double) this.GetDistance() < 100.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.6f);
        if ((double) this.GetDistance() >= 100.0 && (double) this.GetDistance() < 105.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.55f);
        if ((double) this.GetDistance() >= 105.0 && (double) this.GetDistance() < 110.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.5f);
        if ((double) this.GetDistance() >= 110.0 && (double) this.GetDistance() < 115.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.45f);
        if ((double) this.GetDistance() >= 115.0 && (double) this.GetDistance() < 120.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.4f);
        if ((double) this.GetDistance() >= 120.0 && (double) this.GetDistance() < 125.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.35f);
        if ((double) this.GetDistance() >= 125.0 && (double) this.GetDistance() < 130.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.3f);
        if ((double) this.GetDistance() >= 135.0 && (double) this.GetDistance() < 140.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.25f);
        if ((double) this.GetDistance() >= 140.0 && (double) this.GetDistance() < 145.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.2f);
        if ((double) this.GetDistance() >= 145.0 && (double) this.GetDistance() < 150.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.15f);
        if ((double) this.GetDistance() >= 150.0 && (double) this.GetDistance() < 155.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.1f);
        if ((double) this.GetDistance() >= 155.0 && (double) this.GetDistance() < 160.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.05f);
        if ((double) this.GetDistance() >= 160.0)
          this.ORBITALSCALEFORM.CallFunction("SET_ZOOM_LEVEL", (object) 0.0f);
      }
      if (!Game.IsControlPressed(2, GTA.Control.Attack))
      {
        if ((double) this.FireTimer > 1.0)
        {
          this.FireTimer = 1f;
          this.DisplayHelpTextThisFrame("Orbital Cannon Loaded, Ready to Fire");
          this.CanFire = false;
        }
        this.Countdown = 0;
      }
      if (Game.IsControlPressed(2, GTA.Control.Attack) && this.IsInViewMode)
      {
        if (Game.Player.Money >= 750000)
        {
          switch (this.Countdown)
          {
            case 0:
              if (this.FireWait < Game.GameTime)
              {
                this.ORBITALSCALEFORM.CallFunction("SET_COUNTDOWN", (object) 3);
                this.Countdown = 1;
                this.FireWait = Game.GameTime + 800;
                break;
              }
              break;
            case 1:
              if (this.FireWait < Game.GameTime)
              {
                this.ORBITALSCALEFORM.CallFunction("SET_COUNTDOWN", (object) 2);
                this.Countdown = 2;
                this.FireWait = Game.GameTime + 800;
                break;
              }
              break;
            case 2:
              if (this.FireWait < Game.GameTime)
              {
                this.ORBITALSCALEFORM.CallFunction("SET_COUNTDOWN", (object) 1);
                this.Countdown = 3;
                this.FireWait = Game.GameTime + 800;
                break;
              }
              break;
            case 3:
              if (this.FireWait < Game.GameTime && !this.CanFire)
              {
                this.ORBITALSCALEFORM.CallFunction("SET_COUNTDOWN", (object) 0);
                this.Countdown = 0;
                this.DetectPos = new Vector3(0.0f, 0.0f, 0.0f);
                this.CanFire = true;
                this.FireTimer = 0.0f;
                Game.Player.Money -= 750000;
                Vector3 position = Game.Player.Character.Position;
                Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_xm_orbital");
                Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_xm_orbital");
                Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_xm_orbital");
                Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_xm_orbital");
                Function.Call(Hash._0x25129531F77B9ED3, (InputArgument) "scr_xm_orbital_blast", (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) World.GetGroundHeight(position), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 3f, (InputArgument) false, (InputArgument) false, (InputArgument) false);
                Function.Call(Hash._0xE3AD2BDBAEE269AC, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) World.GetGroundHeight(position), (InputArgument) 60, (InputArgument) 100f, (InputArgument) true, (InputArgument) 0.0f, (InputArgument) 1f, (InputArgument) false);
                World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, World.GetGroundHeight(position)), ExplosionType.GasTank, 0.5f, 0.0f);
                System.Random random = new System.Random();
                if ((Entity) this.LockedVehicle != (Entity) null)
                {
                  for (int index = 0; index < 600; ++index)
                  {
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X, position.Y, this.LockedVehicle.Position.Z), ExplosionType.GasTank, 1725f, 0.0f);
                  }
                }
                if ((Entity) this.LockedVehicle == (Entity) null)
                {
                  for (int index = 0; index < 325; ++index)
                  {
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-3, 3), position.Y + (float) random.Next(-3, 3), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-4, 4), position.Y + (float) random.Next(-4, 4), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-5, 5), position.Y + (float) random.Next(-5, 5), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-6, 6), position.Y + (float) random.Next(-6, 6), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-7, 7), position.Y + (float) random.Next(-7, 7), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-8, 8), position.Y + (float) random.Next(-8, 8), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-9, 9), position.Y + (float) random.Next(-9, 9), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-9, 9), position.Y + (float) random.Next(-9, 9), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                    World.AddOwnedExplosion(Game.Player.Character, new Vector3(position.X + (float) random.Next(-8, 8), position.Y + (float) random.Next(-8, 8), World.GetGroundHeight(position)), ExplosionType.GasTank, 1725f, 0.0f);
                  }
                }
                Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_CHRISTMAS2017/XM_ION_CANNON", (InputArgument) false, (InputArgument) -1);
                Function.Call(Hash._0x8D8686B622B88120, (InputArgument) -1, (InputArgument) "DLC_XM_Explosions_Orbital_Cannon", (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) World.GetGroundHeight(position), (InputArgument) 0, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0);
                this.DisplayHelpTextThisFrame("Orbital Cannon Re-Loading");
                Vector3 firePos = this.FirePos;
                break;
              }
              break;
          }
        }
        else
          this.DisplayHelpTextThisFrame("You do not Have Enought Money To fire");
      }
      if (Game.IsControlPressed(2, GTA.Control.NextWeapon) && this.IsInViewMode && (double) this.FirePos.Z - 10.0 > (double) this.MinHeight)
      {
        this.Height -= 0.1f;
        this.FirePos.Z -= 10f;
        Game.Player.Character.Position = this.FirePos;
        if (this.CannonCamera != (Camera) null)
        {
          this.LockedVehicle = (Vehicle) null;
          this.DetectPos = new Vector3(0.0f, 0.0f, 0.0f);
          this.CannonCamera.Position = this.FirePos;
        }
      }
      if (Game.IsControlPressed(2, GTA.Control.PrevWeapon) && this.IsInViewMode && (double) this.FirePos.Z + 10.0 < (double) this.MaxHeight)
      {
        this.Height += 0.1f;
        this.FirePos.Z += 10f;
        Game.Player.Character.Position = this.FirePos;
        if (this.CannonCamera != (Camera) null)
        {
          this.LockedVehicle = (Vehicle) null;
          this.DetectPos = new Vector3(0.0f, 0.0f, 0.0f);
          this.CannonCamera.Position = this.FirePos;
        }
      }
      Function.Call(Hash._0x61BB1D9B3A95D802, (InputArgument) 0);
      this.ORBITALSCALEFORM.Render2D();
    }

    public void RefreshInterior()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 462.09f, (InputArgument) 4820.42f, (InputArgument) -59f);
      foreach (object obj in new List<object>()
      {
        (object) "set_int_02_decal_01",
        (object) "set_int_02_decal_02",
        (object) "set_int_02_decal_03",
        (object) "set_int_02_decal_04",
        (object) "set_int_02_decal_05",
        (object) "set_int_02_decal_06",
        (object) "set_int_02_decal_07",
        (object) "set_int_02_decal_08",
        (object) "set_int_02_decal_09",
        (object) "set_int_02_no_cannon",
        (object) "set_int_02_cannon",
        (object) "set_int_02_no_security",
        (object) "set_int_02_no_security",
        (object) "set_int_02_lounge1",
        (object) "set_int_02_lounge2",
        (object) "set_int_02_lounge3",
        (object) "set_int_02_no_sleep",
        (object) "set_int_02_sleep",
        (object) "set_int_02_sleep2",
        (object) "set_int_02_sleep3"
      })
      {
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__294.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__294.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string str = Class1.\u003C\u003Eo__294.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__294.\u003C\u003Ep__0, obj);
        if (str != null)
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) str);
      }
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_int_02_shell");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) this.FacilityGraphic);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) this.FacilityOrbitalCannon);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) this.FacilitySecurityRoom);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) this.FacilityLounge);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) this.FacilitySleepingQuarters);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num, (InputArgument) "set_int_02_shell", (InputArgument) this.FacilityShellColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num, (InputArgument) this.FacilityGraphic, (InputArgument) this.FacilityGraphicColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num, (InputArgument) this.FacilityOrbitalCannon, (InputArgument) this.FacilityOrbitalCannonColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num, (InputArgument) this.FacilitySecurityRoom, (InputArgument) this.FacilitySecurityRoomColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num, (InputArgument) this.FacilityLounge, (InputArgument) this.FacilityLoungeColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num, (InputArgument) this.FacilitySleepingQuarters, (InputArgument) this.FacilitySleepingQuartersColor);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
    }

    private void SetupSpecialMission()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SpecialMissions, "Special Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race1 = new UIMenuItem("Nuclear Meltdown");
      uiMenu.AddItem(Race1);
      UIMenuItem Race2 = new UIMenuItem("Storming The Barge");
      uiMenu.AddItem(Race2);
      UIMenuItem Race3 = new UIMenuItem("Taking The Mountain");
      uiMenu.AddItem(Race3);
      UIMenuItem Race4 = new UIMenuItem("Chemical Annihilation");
      uiMenu.AddItem(Race4);
      UIMenuItem Race5 = new UIMenuItem("Traitor to the cause");
      uiMenu.AddItem(Race5);
      UIMenuItem uiMenuItem = new UIMenuItem("Signal Interceptor");
      uiMenu.AddItem(uiMenuItem);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race5)
        {
          if ((Entity) this.Avon != (Entity) null)
            this.Avon.Delete();
          if ((Entity) this.Jugg1 != (Entity) null)
            this.Jugg1.Delete();
          if ((Entity) this.Jugg2 != (Entity) null)
            this.Jugg2.Delete();
          if ((Entity) this.Heli != (Entity) null)
            this.Heli.Delete();
          this.Avon = World.CreatePed((Model) PedHash.Avon, new Vector3(-1355f, 4417f, 30f));
          this.Jugg1 = World.CreatePed((Model) PedHash.FreemodeMale01, new Vector3(-1352f, 4421f, 30f));
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg1, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          this.Jugg2 = World.CreatePed((Model) PedHash.FreemodeMale01, new Vector3(-1359f, 4420f, 30f));
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) this.Jugg2, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC");
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0xD2A71E1A77418A49, (InputArgument) "move_ballistic_2h");
          Function.Call(Hash._0xD75ACCF5E0FB5367, (InputArgument) this.Jugg1, (InputArgument) true, (InputArgument) -1, (InputArgument) 0);
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) this.Jugg1, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC", (InputArgument) 5f);
          Function.Call(Hash._0x29A28F3F8CF6D854, (InputArgument) this.Jugg1, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0x1055AC3A667F09D9, (InputArgument) this.Jugg1, (InputArgument) 1429513766);
          Function.Call(Hash._0xD75ACCF5E0FB5367, (InputArgument) this.Jugg2, (InputArgument) true, (InputArgument) -1, (InputArgument) 0);
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) this.Jugg2, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC", (InputArgument) 5f);
          Function.Call(Hash._0x29A28F3F8CF6D854, (InputArgument) this.Jugg2, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0x1055AC3A667F09D9, (InputArgument) this.Jugg2, (InputArgument) 1429513766);
          this.Jugg1.Armor = 400;
          this.Jugg1.Health = 200;
          this.Jugg1.MaxHealth = 200;
          this.Jugg2.Armor = 400;
          this.Jugg2.Health = 200;
          this.Jugg2.MaxHealth = 200;
          this.Heli = World.CreateVehicle((Model) VehicleHash.Akula, new Vector3(-1360f, 4381f, 40f));
          this.CloseTotarget = false;
          this.missionnum = 25;
          this.MissionSetup = true;
          this.Payout = 6250000f;
          this.Avon.AddBlip();
          this.Avon.CurrentBlip.Sprite = BlipSprite.Enemy;
          this.Avon.CurrentBlip.Color = BlipColor.Red;
          this.Avon.CurrentBlip.Name = "Enemy : Avon";
          this.Jugg1.AddBlip();
          this.Jugg1.CurrentBlip.Sprite = BlipSprite.Juggernaut;
          this.Jugg1.CurrentBlip.Color = BlipColor.Red;
          this.Jugg1.CurrentBlip.Name = "Enemy : Avon bodyguard";
          this.Jugg2.AddBlip();
          this.Jugg2.CurrentBlip.Sprite = BlipSprite.Juggernaut;
          this.Jugg2.CurrentBlip.Color = BlipColor.Red;
          this.Jugg2.CurrentBlip.Name = "Enemy : Avon bodyguard";
          this.Jugg1.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
          this.Jugg2.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
          this.Avon.Weapons.Give(WeaponHash.PistolMk2, 9999, true, true);
          this.Heli.AddBlip();
          this.Heli.CurrentBlip.Sprite = BlipSprite.HelicopterAnimated;
          this.Heli.CurrentBlip.Color = BlipColor.Red;
          this.Heli.CurrentBlip.Name = "Avon's Heli";
          Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) this.Jugg1, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER"));
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Jugg1, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) this.Jugg1, (InputArgument) 1);
          Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) this.Jugg2, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER"));
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Jugg2, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) this.Jugg2, (InputArgument) 1);
          Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) this.Avon, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER"));
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.Avon, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) this.Avon, (InputArgument) 1);
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          this.SpawnProp("xm_prop_x17_trail_01a", new Vector3(-1381.43f, 4438f, 27f), new Vector3(0.0f, 0.0f, 0.0f));
          this.SpawnProp("xm_prop_x17_trail_02a", new Vector3(-1343.81f, 4420f, 29f), new Vector3(0.0f, 0.0f, 0.0f));
          this.SpawnProp("xm_prop_x17_trail_02a", new Vector3(-1362.23f, 4432.71f, 29f), new Vector3(0.0f, 0.0f, 0.0f));
          this.SpawnProp("xm_prop_x17_trail_01a", new Vector3(-1391.99f, 4463f, 22f), new Vector3(0.0f, 0.0f, 0.0f));
          UI.Notify(this.GetHostName() + " an old enemy of mine, has resurfaced, he thretens to tear our business apart, for revenge, we cannot let that happen!, kill him!");
        }
        if (item == Race4)
        {
          foreach (Blip samBip in this.SamBips)
          {
            if (samBip != (Blip) null)
              samBip.Remove();
          }
          foreach (Ped guard in this.Guards)
          {
            if ((Entity) guard != (Entity) null)
              guard.Delete();
          }
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_0_x17dlc_int_base_ent_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_1_x17dlc_int_base_loop_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_2_x17dlc_int_bse_tun_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_3_x17dlc_int_base_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_6_x17dlc_int_silo_01_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_7_x17dlc_int_silo_02_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_10_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_11_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_12_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_13_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_14_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_15_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_16_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_17_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_18_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_19_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_20_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_21_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_22_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_23_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_24_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_25_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_26_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_27_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_28_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_29_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_34_x17dlc_int_lab_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_35_x17dlc_int_tun_entry_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_strm_0");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_0_x17dlc_int_base_ent_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_1_x17dlc_int_base_loop_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_2_x17dlc_int_bse_tun_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_3_x17dlc_int_base_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_6_x17dlc_int_silo_01_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_7_x17dlc_int_silo_02_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_10_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_11_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_12_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_13_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_14_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_15_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_16_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_17_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_18_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_19_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_20_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_21_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_22_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_23_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_24_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_25_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_26_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_27_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_28_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_29_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_34_x17dlc_int_lab_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_35_x17dlc_int_tun_entry_milo_");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_strm_0");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_0_x17dlc_int_base_ent_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_1_x17dlc_int_base_loop_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_2_x17dlc_int_bse_tun_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_3_x17dlc_int_base_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_6_x17dlc_int_silo_01_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_7_x17dlc_int_silo_02_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_10_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_11_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_12_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_13_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_14_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_15_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_16_x17dlc_int_tun_straight_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_17_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_18_x17dlc_int_tun_slope_flat_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_19_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_20_x17dlc_int_tun_flat_slope_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_21_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_22_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_23_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_24_x17dlc_int_tun_30d_r_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_25_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_26_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_27_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_28_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_29_x17dlc_int_tun_30d_l_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_34_x17dlc_int_lab_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_35_x17dlc_int_tun_entry_milo_");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_strm_0");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "CS1_02_cf_onmission1");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "CS1_02_cf_onmission2");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "CS1_02_cf_onmission3");
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "CS1_02_cf_onmission4");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "CS1_02_cf_onmission1");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "CS1_02_cf_onmission2");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "CS1_02_cf_onmission3");
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "CS1_02_cf_onmission4");
          Vector3 position1 = new Vector3(212f, 6163f, -155f);
          Vector3 position2 = new Vector3(251f, 6155f, -147f);
          Vector3 position3 = new Vector3(275f, 6164f, -155f);
          this.SpawnProp("prop_biotech_store", new Vector3(212f, 6163f, -155f), new Vector3(0.0f, -60f, 180f));
          this.SpawnProp("prop_biotech_store", new Vector3(251f, 6155f, -147f), new Vector3(0.0f, 0.0f, 180f));
          this.SpawnProp("prop_biotech_store", new Vector3(275f, 6164f, -155f), new Vector3(0.0f, 0.0f, 180f));
          Blip blip1 = World.CreateBlip(new Vector3(-361f, 4827f, 144f));
          blip1.Sprite = BlipSprite.Castle;
          blip1.Color = BlipColor.Blue;
          blip1.Name = "Lab Enterance ";
          blip1.IsShortRange = false;
          this.SamBips.Add(blip1);
          Blip blip2 = World.CreateBlip(position1);
          blip2.Sprite = BlipSprite.Bomb;
          blip2.Color = BlipColor.Purple;
          blip2.Name = "Cryo Storage A";
          blip2.IsShortRange = false;
          this.SamBips.Add(blip2);
          Blip blip3 = World.CreateBlip(position2);
          blip3.Sprite = BlipSprite.Bomb;
          blip3.Color = BlipColor.Purple;
          blip3.Name = "Cryo Storage B";
          blip3.IsShortRange = false;
          this.SamBips.Add(blip3);
          Blip blip4 = World.CreateBlip(position3);
          blip4.Sprite = BlipSprite.Bomb;
          blip4.Color = BlipColor.Purple;
          blip4.Name = "Cryo Storage C";
          blip4.IsShortRange = false;
          this.SamBips.Add(blip4);
          this.missionnum = 23;
          this.MissionSetup = true;
          this.IsHacking = true;
          this.Payout = 3600000f;
          this.timer = 300;
          this.NearSam = false;
          UI.Notify(this.GetHostName() + " we have found the location of a hidden underground base, we believe they are manufacturing chemical bombs!, stop them ");
          this.GotVehicle = false;
          UI.Notify("The Enterance for the Lab is the ~b~Castle blip~w~, once inside follow the path down till you find the lab ");
          Script.Wait(3000);
          UI.Notify("When inside, stand in the purple marker next to each ~p~bomb~w~, to examine it, if fake, the real bombs timer will be activated");
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(561.2916f, 5959.292f, -158.0513f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(558.73f, 5937.522f, -158.0869f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(543.0069f, 5933.418f, -158.0754f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(524.6627f, 5918.637f, -158.071f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(521.1674f, 5915.044f, -158.0728f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(467.7516f, 5942.916f, -158.2725f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(429.9449f, 5900.704f, -158.1404f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(419.2828f, 5902.862f, -158.1557f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(405.2405f, 5912.996f, -158.1408f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(355.8906f, 5921.789f, -158.1031f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(330.9041f, 5914.557f, -158.3162f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(307.2319f, 5908.608f, -158.161f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(296.2804f, 5912.223f, -158.5519f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(272.9622f, 5918.234f, -159.4196f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(256.4842f, 5937.044f, -159.5214f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(254.0668f, 5965.798f, -159.4491f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(252.0962f, 5981.408f, -159.4168f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(249.2776f, 6009.625f, -159.4271f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(246.5637f, 6031.764f, -159.4343f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(241.118f, 6045.746f, -159.4295f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(236.8502f, 6044.968f, -159.4244f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(307.1096f, 6012.938f, -158.9676f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(313.6908f, 5957.316f, -158.2718f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(309.6252f, 5955.591f, -158.2718f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(357.0732f, 5947.178f, -158.2718f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(356.0363f, 5940.733f, -158.2423f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(442.4662f, 5954.884f, -158.259f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(312.6888f, 6004.643f, -158.9112f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(305.2613f, 6023.103f, -159.0356f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(277.0551f, 6028.523f, -159.2269f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(262.5737f, 6101.796f, -159.4272f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(254.3778f, 6099.718f, -159.4272f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(260.2216f, 6125.033f, -159.4221f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(256.3546f, 6124.692f, -159.4221f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(262.0991f, 6148.282f, -160.4222f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(262.3585f, 6153.442f, -160.4222f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(262.3092f, 6172.482f, -160.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(262.5339f, 6179.315f, -160.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(259.2458f, 6182.304f, -160.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(232.9578f, 6182.078f, -160.4224f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(229.4026f, 6181.965f, -160.4224f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(226.9926f, 6179.571f, -160.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(226.6212f, 6175.277f, -160.4222f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(226.8314f, 6172.98f, -160.4222f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(226.676f, 6156.759f, -160.4221f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(226.5098f, 6154.222f, -160.4221f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(226.538f, 6148.865f, -160.4222f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(228.9846f, 6145.416f, -160.4224f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(230.8563f, 6145.73f, -160.4224f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(218.3588f, 6155.545f, -154.4167f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(224.4696f, 6162.296f, -154.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(219.4229f, 6172.283f, -154.4224f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(270.0448f, 6172.243f, -154.4201f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(274.5043f, 6169.119f, -154.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(275.2462f, 6159.04f, -154.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(265.4183f, 6161.549f, -154.4224f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(245.9794f, 6165.524f, -159.4212f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(245.6968f, 6161.024f, -159.4212f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(244.8469f, 6167.229f, -154.4225f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(236.7219f, 6172.198f, -154.4224f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(237.5539f, 6181.364f, -154.4212f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(250.335f, 6167.692f, -154.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(251.1033f, 6177.804f, -154.4223f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(243.3278f, 6168.117f, -150.4224f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(244.4633f, 6162.89f, -148.4229f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(247.3639f, 6159.941f, -146.4226f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(240.8847f, 6160.598f, -146.4226f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(253.146f, 6157.187f, -146.3681f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(238.394f, 6156.956f, -146.4226f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(235.8217f, 6170.451f, -146.3692f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(252.3653f, 6176.363f, -146.3681f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(252.293f, 6184.561f, -146.4226f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(245.9992f, 6184.017f, -146.4219f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(236.9871f, 6183.142f, -146.4226f), 90f));
          foreach (Ped guard in this.Guards)
          {
            if ((Entity) guard != (Entity) null)
            {
              guard.Weapons.Give(WeaponHash.SMG, 9999, true, true);
              guard.Health = 60;
              guard.Armor = 0;
              guard.MaxHealth = 60;
              guard.AddBlip();
              guard.CurrentBlip.Sprite = BlipSprite.Beast;
              guard.CurrentBlip.Color = BlipColor.Red;
              guard.CurrentBlip.Name = "Lab Enemy";
              guard.CurrentBlip.Scale = 0.5f;
              this.SamBips.Add(guard.CurrentBlip);
            }
          }
        }
        if (item == Race1)
        {
          foreach (Ped guard in this.Guards)
          {
            if ((Entity) guard != (Entity) null)
              guard.Delete();
          }
          foreach (Vehicle vehicle in this.CaptureVehicle)
          {
            if ((Entity) vehicle != (Entity) null)
              vehicle.Delete();
          }
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          foreach (Blip samBip in this.SamBips)
          {
            if (samBip != (Blip) null)
              samBip.Remove();
          }
          this.SpawnProp("xm_prop_x17_silo_open_01a", new Vector3(609f, 2885f, 35f), new Vector3(0.0f, 0.0f, 180f));
          this.SpawnProp("xm_prop_x17_silo_rocket_01", new Vector3(609f, 2885f, -3f), new Vector3(0.0f, 0.0f, 180f));
          this.SpawnProp("xm_prop_x17_silo_door_l_01a", new Vector3(599.6f, 2884.4f, 43f), new Vector3(0.0f, -60f, 180f));
          this.SpawnProp("xm_prop_x17_silo_door_r_01a", new Vector3(618.6f, 2886.7f, 43f), new Vector3(0.0f, 60f, 180f));
          this.SpawnProp("xm_prop_x17_silo_01a", new Vector3(524f, 2946f, 30f), new Vector3(0.0f, 0.0f, 180f));
          this.SpawnProp("xm_prop_x17_silo_01a", new Vector3(500f, 2855f, 36f), new Vector3(0.0f, 0.0f, 180f));
          this.SpawnProp("xm_prop_x17_silo_01a", new Vector3(730f, 273f, 36f), new Vector3(0.0f, 0.0f, 180f));
          this.SpawnProp("xm_prop_x17_silo_01a", new Vector3(653f, 2952f, 32f), new Vector3(0.0f, 0.0f, 180f));
          Blip blip = World.CreateBlip(new Vector3(609f, 2885f, 35f));
          this.DropZoneVector = new Vector3(609f, 2885f, 35f);
          blip.Sprite = BlipSprite.Rocket;
          blip.Color = BlipColor.Purple;
          blip.Name = "Nuclear Silo";
          blip.IsShortRange = false;
          this.SamBips.Add(blip);
          this.missionnum = 22;
          this.MissionSetup = true;
          this.Payout = 6600000f;
          UI.Notify(this.GetHostName() + " Someone is attempting to launch a nuclear missile from a silo, in Grand Senora Desert, get close so i can shut down the procedure");
        }
        if (item == Race2)
        {
          foreach (Ped guard in this.Guards)
          {
            if ((Entity) guard != (Entity) null)
              guard.Delete();
          }
          foreach (Vehicle vehicle in this.CaptureVehicle)
          {
            if ((Entity) vehicle != (Entity) null)
              vehicle.Delete();
          }
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          foreach (Blip samBip in this.SamBips)
          {
            if (samBip != (Blip) null)
              samBip.Remove();
          }
          foreach (Vehicle dinghy in this.Dinghys)
          {
            if ((Entity) dinghy != (Entity) null)
              dinghy.Delete();
          }
          foreach (Vehicle vehicle in this.Truck_Trailer)
          {
            if ((Entity) vehicle != (Entity) null)
              vehicle.Delete();
          }
          this.SpawnProp("xm_prop_x17_barge_01", new Vector3(3714.004f, -677.9f, -32f), new Vector3(0.0f, 0.0f, 90f));
          this.SpawnProp("xm_prop_x17_barge_01", new Vector3(3641.264f, -824f, -32f), new Vector3(0.0f, 0.0f, 90f));
          this.SpawnProp("xm_prop_x17_barge_01", new Vector3(3495f, -877f, -32f), new Vector3(0.0f, 0.0f, 90f));
          Vector3 position1 = new Vector3(3497.43f, -857.9072f, 3.9f);
          Vector3 position2 = new Vector3(3644.887f, -804.0897f, 3.9f);
          Vector3 position3 = new Vector3(3716.408f, -662.1811f, 3.9f);
          this.SamPoints.Add(new Vector3(3497.43f, -857.9072f, 3.9f));
          Blip blip1 = World.CreateBlip(position1);
          blip1.Sprite = BlipSprite.Yacht;
          blip1.Color = BlipColor.Purple;
          blip1.Name = "Barge";
          blip1.IsShortRange = false;
          this.SamBips.Add(blip1);
          this.SamPoints.Add(new Vector3(3644.887f, -804.0897f, 3.9f));
          Blip blip2 = World.CreateBlip(position2);
          blip2.Sprite = BlipSprite.Yacht;
          blip2.Color = BlipColor.Purple;
          blip2.Name = "Barge";
          blip2.IsShortRange = false;
          this.SamBips.Add(blip2);
          this.SamPoints.Add(new Vector3(3716.408f, -662.1811f, 3.9f));
          Blip blip3 = World.CreateBlip(position3);
          blip3.Sprite = BlipSprite.Yacht;
          blip3.Color = BlipColor.Purple;
          blip3.Name = "Barge";
          blip3.IsShortRange = false;
          this.SamBips.Add(blip3);
          this.Dinghys.Add(World.CreateVehicle((Model) VehicleHash.Dinghy3, new Vector3(2845f, -585f, 0.0f), -88f));
          this.Dinghys.Add(World.CreateVehicle((Model) VehicleHash.Dinghy3, new Vector3(2846f, -589f, 0.0f), -88f));
          this.Dinghys.Add(World.CreateVehicle((Model) VehicleHash.Dinghy3, new Vector3(2845f, -580f, 0.0f), -88f));
          this.Truck_Trailer.Add(World.CreateVehicle((Model) VehicleHash.Hauler, new Vector3(2820f, -629f, 1f), 1f));
          this.Truck_Trailer.Add(World.CreateVehicle((Model) VehicleHash.ArmyTrailer, new Vector3(2840f, -629f, 1f), 1f));
          Function.Call(Hash._0x3C7D42D58F770B54, (InputArgument) this.Truck_Trailer[0], (InputArgument) this.Truck_Trailer[1], (InputArgument) 10);
          if (this.SamPoints.Count > 0)
            this.SamPoints.Clear();
          this.CaptureVehicle.Add(World.CreateVehicle((Model) VehicleHash.Stromberg, new Vector3(3636f, -825f, 4f), 0.0f));
          this.CaptureVehicle.Add(World.CreateVehicle((Model) VehicleHash.Stromberg, new Vector3(3709f, -679f, 4f), 0.0f));
          this.CaptureVehicle.Add(World.CreateVehicle((Model) VehicleHash.Stromberg, new Vector3(3489f, -876f, 4f), 0.0f));
          this.DropZoneVector = new Vector3(2829f, -652f, 0.5f);
          this.SamPoints.Add(this.DropZoneVector);
          foreach (Vehicle vehicle in this.CaptureVehicle)
          {
            if ((Entity) vehicle != (Entity) null)
              vehicle.PearlescentColor = VehicleColor.Blue;
          }
          foreach (Vector3 samPoint in this.SamPoints)
          {
            if (samPoint == this.DropZoneVector)
            {
              Blip blip4 = World.CreateBlip(samPoint);
              blip4.Sprite = BlipSprite.SpecialCargo;
              blip4.Color = BlipColor.Purple;
              blip4.Name = "Stromberg Drop zone";
              blip4.IsShortRange = false;
              this.SamBips.Add(blip4);
            }
          }
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3708f, -684f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3721f, -676f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3710f, -667f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3719f, -657f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3714f, -689f, 8f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3637f, -804f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3644f, -820f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3637f, -828f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3637f, -818f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3642f, -835f, 8f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3489f, -880f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3495f, -882f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3490f, -858f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3497f, -857f, 4f), 90f));
          this.Guards.Add(World.CreatePed((Model) PedHash.ArmGoon01GMM, new Vector3(3494f, -887f, 8f), 90f));
          foreach (Ped guard in this.Guards)
          {
            if ((Entity) guard != (Entity) null)
              guard.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          }
          this.SamsTakenOut = 3;
          this.missionnum = 21;
          this.MissionSetup = true;
          this.Payout = 2250000f;
          UI.Notify(this.GetHostName() + " We have spotted a couple of barges of the coast, they are carring Strombergs, steal each one and deliver each one to the drop point");
          System.Random random = new System.Random();
        }
        if (item != Race3)
          return;
        foreach (Vehicle vehicle in this.CaptureVehicle)
        {
          if ((Entity) vehicle != (Entity) null)
          {
            if ((Entity) vehicle.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
              vehicle.GetPedOnSeat(VehicleSeat.Driver).Delete();
            if (vehicle.CurrentBlip != (Blip) null)
              vehicle.CurrentBlip.Remove();
            vehicle.Delete();
          }
        }
        foreach (Prop prop in this.Props)
        {
          if ((Entity) prop != (Entity) null)
            prop.Delete();
        }
        this.numberofHelis = 0;
        if (this.SamPoints.Count > 0)
          this.SamPoints.Clear();
        foreach (Blip samBip in this.SamBips)
        {
          if (samBip != (Blip) null)
            samBip.Remove();
        }
        this.IsHacking = false;
        this.SamsTakenOut = 5;
        this.SpawnProp("xm_prop_sam_turret_01", new Vector3(-390f, 4709f, 261f), new Vector3(0.0f, 0.0f, 15f));
        this.SpawnProp("xm_prop_sam_turret_01", new Vector3(-656f, 4738f, 241f), new Vector3(0.0f, 0.0f, 15f));
        this.SpawnProp("xm_prop_sam_turret_01", new Vector3(-861f, 4726f, 274f), new Vector3(0.0f, 0.0f, 15f));
        this.SpawnProp("xm_prop_sam_turret_01", new Vector3(-568f, 4178f, 190f), new Vector3(0.0f, 0.0f, 15f));
        this.SpawnProp("xm_prop_sam_turret_01", new Vector3(-1190f, 3856f, 488f), new Vector3(0.0f, 0.0f, 15f));
        this.SamPoints.Add(new Vector3(-390f, 4709f, 261f));
        this.SamPoints.Add(new Vector3(-656f, 4738f, 241f));
        this.SamPoints.Add(new Vector3(-861f, 4726f, 274f));
        this.SamPoints.Add(new Vector3(-568f, 4178f, 190f));
        this.SamPoints.Add(new Vector3(-1190f, 3856f, 488f));
        this.NearSam = false;
        foreach (Vector3 samPoint in this.SamPoints)
        {
          Blip blip = World.CreateBlip(samPoint);
          blip.Sprite = BlipSprite.Rocket;
          blip.Color = BlipColor.Purple;
          blip.Name = "Sam Battery";
          blip.IsShortRange = false;
          this.SamBips.Add(blip);
        }
        this.missionnum = 20;
        this.MissionSetup = true;
        this.Payout = 1250000f;
        UI.Notify(this.GetHostName() + " We have found an array of sam batteries around Mt Gordo, get close to each one so i can hack into it and take it over for us");
      });
    }

    private Vector3 RandomMinePos(Vector3 Pos)
    {
      System.Random random = new System.Random();
      int num1 = random.Next(-100, 100);
      int num2 = random.Next(-100, 100);
      int num3 = random.Next(-100, 0);
      return new Vector3(Pos.X + (float) num1, Pos.Y + (float) num2, Pos.Z + (float) num3);
    }

    public void SpawnNewBarrage()
    {
      ++this.numberofHelis;
      Ped character = Game.Player.Character;
      System.Random random = new System.Random();
      random.Next(-1750, 1750);
      random.Next(-1750, 1750);
      Vector3 position = new Vector3();
      int num = random.Next(1, 5);
      if (num == 1)
        position = new Vector3(878f, 2822f, 57f);
      if (num == 2)
        position = new Vector3(1041f, 2971f, 42f);
      if (num == 3)
        position = new Vector3(801f, 3099f, 43f);
      if (num == 4)
        position = new Vector3(2861f, 3135f, 43f);
      if (num == 5)
        position = new Vector3(257f, 2922f, 43f);
      Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Insurgent2, position);
      vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ExArmy01);
      vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.ExArmy01);
      vehicle.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.ExArmy01);
      vehicle.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.ExArmy01);
      vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(character);
      vehicle.GetPedOnSeat(VehicleSeat.Passenger).Task.FightAgainst(character);
      vehicle.GetPedOnSeat(VehicleSeat.LeftRear).Task.FightAgainst(character);
      vehicle.GetPedOnSeat(VehicleSeat.RightRear).Task.FightAgainst(character);
      this.Guards.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
      this.Guards.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
      this.Guards.Add(vehicle.GetPedOnSeat(VehicleSeat.LeftRear));
      this.Guards.Add(vehicle.GetPedOnSeat(VehicleSeat.RightRear));
      this.CaptureVehicle.Add(vehicle);
      vehicle.AddBlip();
      vehicle.CurrentBlip.Sprite = BlipSprite.Barrage;
      this.CaptureVehicle.Add(vehicle);
      this.HeliTimer = 0;
      foreach (Ped guard in this.Guards)
      {
        if ((Entity) guard != (Entity) null)
        {
          guard.Weapons.Give(WeaponHash.AssaultrifleMk2, 9999, true, true);
          guard.Weapons.Give(WeaponHash.MiniSMG, 9999, true, true);
        }
      }
    }

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Doomsday Heist Business", "DoomsdayHeistBusiness", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public Vector3 ChooseRandomPos(Vector3 Original)
    {
      Script.Wait(1);
      System.Random random = new System.Random();
      int num1 = random.Next(-25, 25);
      int num2 = random.Next(-25, 25);
      this.ran = new Vector3(Original.X - (float) num2, Original.Y - (float) num1, Original.Z - (float) num1);
      return this.ran;
    }

    public Class1()
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.SetupPeds();
      this.AllStocks = new AllStocks();
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Interval = 1;
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      this.LoadIniFileInteriorD("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
      this.SC = new SaveCar();
      this.RICreatedPeds = false;
      this.CreatedProp = false;
      this.LoadMain("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      this.Setup();
    }

    private void CoopEliminationmissions()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.CoopElimination, "Co-op Elimination Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (Barrage) ");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 (Khanjali) ");
      uiMenu.AddItem(Mission2);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission1)
        {
          this.Agent14SpawnCar = new Vector3(-2221f, 2312f, 32f);
          this.DeleteVehicles();
          if ((Entity) this.DeliveryVehicle != (Entity) null)
            this.DeliveryVehicle.Delete();
          if ((Entity) this.Bike1 != (Entity) null)
            this.Bike1.Delete();
          if (this.Bike1Blip != (Blip) null)
            this.Bike1Blip.Remove();
          this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
          this.Bike1 = World.CreateVehicle((Model) VehicleHash.Barrage, this.SpawnPos);
          this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
          this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 120f, 1);
          this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
          this.Bike1Blip.Sprite = BlipSprite.GunCar;
          this.Bike1Blip.Color = BlipColor.Red;
          this.Bike1Blip.Name = "Enemy Barrage A";
          this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.Barrage, this.Agent14SpawnCar);
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
          this.VehicleSetup2 = true;
          this.vehiclemissionid = 9;
          UI.Notify(this.GetHostName() + " take out the enemy vehicle for a reward");
        }
        if (item != Mission2)
          return;
        this.Agent14SpawnCar = new Vector3(-2221f, 2312f, 32f);
        this.DeleteVehicles();
        if ((Entity) this.DeliveryVehicle != (Entity) null)
          this.DeliveryVehicle.Delete();
        if ((Entity) this.Bike1 != (Entity) null)
          this.Bike1.Delete();
        if (this.Bike1Blip != (Blip) null)
          this.Bike1Blip.Remove();
        this.Spawn = new Vector3(2688.31f, 5127.53f, 45f);
        this.Bike1 = World.CreateVehicle((Model) VehicleHash.Khanjari, this.SpawnPos);
        this.Bike1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon01GMM);
        this.Bike1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Bike1, this.PointB, 60f, 120f, 1);
        this.Bike1Blip = World.CreateBlip(this.Bike1.Position);
        this.Bike1Blip.Sprite = BlipSprite.GunCar;
        this.Bike1Blip.Color = BlipColor.Red;
        this.Bike1Blip.Name = "Enemy Barrage A";
        this.DeliveryVehicle = World.CreateVehicle((Model) VehicleHash.Khanjari, this.Agent14SpawnCar);
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
        this.VehicleSetup2 = true;
        this.vehiclemissionid = 9;
        UI.Notify(this.GetHostName() + " take out the enemy vehicle for a reward");
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
        if (Class1.\u003C\u003Eo__302.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__302.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.ChairPropModel = Class1.\u003C\u003Eo__302.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__302.\u003C\u003Ep__0, Chairs[MainChairlist.Index]);
        this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
        this.Config.Save();
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__302.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__302.\u003C\u003Ep__2 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, System.Type, object> target = Class1.\u003C\u003Eo__302.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, System.Type, object>> p2 = Class1.\u003C\u003Eo__302.\u003C\u003Ep__2;
        System.Type type = typeof (UI);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__302.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__302.\u003C\u003Ep__1 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__302.\u003C\u003Ep__1.Target((CallSite) Class1.\u003C\u003Eo__302.\u003C\u003Ep__1, "~g~ HKH191~w~  : Main Chair Model has been set to ", Chairs[MainChairlist.Index]);
        target((CallSite) p2, type, obj);
        if ((Entity) this.ChairProp != (Entity) null)
          this.ChairProp.Delete();
        this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), new Vector3(359.93f, 4842.88f, -60f), new Vector3(0.0f, 0.0f, -158f), false, false);
        this.ChairProp.FreezePosition = true;
        if ((Entity) this.ChairProp != (Entity) null)
        {
          this.ChairProp.Position = vector3;
          this.ChairProp.Heading = num2;
        }
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.methgarage, "Expand Business ");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.methgarage, "Sell Business");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem Sell = new UIMenuItem("Sell");
      uiMenu3.AddItem(Sell);
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
            UI.Notify(" OK your new level will be " + (this.purchaselvl += num4 + 1).ToString() + ", at a price of $" + num3.ToString("N") + ", Do u want to continue Enter Y or N");
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
        UI.Notify("Max Stocks: " + this.maxstocks.ToString());
        UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
        UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
        UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
      });
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
        if (Class1.\u003C\u003Eo__302.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__302.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, BlipColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (BlipColor), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Blip_Colour = Class1.\u003C\u003Eo__302.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__302.\u003C\u003Ep__3, BColour[BC.Index]);
        this.Config.SetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__302.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__302.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Uicolour = Class1.\u003C\u003Eo__302.\u003C\u003Ep__4.Target((CallSite) Class1.\u003C\u003Eo__302.\u003C\u003Ep__4, UiColour[uiC.Index]);
        this.Config.SetValue<string>("Misc", "Uicolour", this.Uicolour);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__302.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__302.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.MarkerColorString = Class1.\u003C\u003Eo__302.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__302.\u003C\u003Ep__5, MColour[MC.Index]);
        this.Config.SetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " : Settings Changed they will take effect when you reload the mod!");
      });
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
        this.Commission = this.Config.GetValue<float>("ADDON2", "COMMISSION", this.Commission);
        this.GunlockerBought = this.Config.GetValue<int>("Extra", "GunLockerBought", this.GunlockerBought);
        this.VehicleBayBought = this.Config.GetValue<int>("Extra", "VehicleBayBought", this.VehicleBayBought);
        this.AvengerBought = this.Config.GetValue<int>("SpecialVehicles", "AvengerBought", this.AvengerBought);
        this.AkulaBought = this.Config.GetValue<int>("SpecialVehicles", "AkulaBought", this.AkulaBought);
        this.ThrusterBought = this.Config.GetValue<int>("SpecialVehicles", "ThrusterBought", this.ThrusterBought);
        this.ChernobogBought = this.Config.GetValue<int>("SpecialVehicles", "ChernobogBought", this.ChernobogBought);
        this.BarrageBought = this.Config.GetValue<int>("SpecialVehicles", "BarrageBought", this.BarrageBought);
        this.DeluxoBought = this.Config.GetValue<int>("SpecialVehicles", "DeluxoBought", this.DeluxoBought);
        this.StrombergBought = this.Config.GetValue<int>("SpecialVehicles", "StrombergBought", this.StrombergBought);
        this.KhanjaliBought = this.Config.GetValue<int>("SpecialVehicles", "KhanjaliBought", this.KhanjaliBought);
        this.PrivacyGlassOn = this.Config.GetValue<bool>("PrivacyGlass", "PrivacyGlassOn", this.PrivacyGlassOn);
        this.PrivacyGlassBought = this.Config.GetValue<int>("PrivacyGlass", "PrivacyGlassBought", this.PrivacyGlassBought);
        this.maxstocks = 10 * this.purchaselvl;
        float num = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
        this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
        this.increaseGain = num;
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
          UI.Notify(this.GetHostName() + "  Here is where we are at");
          UI.Notify("Level: " + this.purchaselvl.ToString() + "/20");
          UI.Notify("Max Stocks: " + this.maxstocks.ToString());
          UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
          UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
          UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
        }
        if (item == Buy2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
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
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.TipTruck, this.OutsideSpawn, 0.0f);
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
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Flatbed, this.OutsideSpawn, 0.0f);
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
            this.StockVeh = World.CreateVehicle((Model) VehicleHash.Guardian, this.OutsideSpawn, 0.0f);
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
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
          this.EndPoint = new Vector3(-1286.58f, 2529.48f, 20f);
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
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPoint, 20f, 120f, 1);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.EndPoint, 20f, 120f, 1);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.EndPoint, 20f, 120f, 1);
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
          this.EndPointBlip = World.CreateBlip(this.EndPoint);
          this.EndPointBlip.Sprite = BlipSprite.CaptureFlag;
          this.EndPointBlip.Color = BlipColor.White;
          this.EndPointBlip.Name = "Delivery Point";
          this.missionnum = 4444;
          this.SellStockDeliveryMission = true;
          UI.Notify(this.GetHostName() + " : Boss I've spotted 3 vehicles on route to Fort Zancudo, Destroy All Three, Before they reach their destination for a 25% Boost to Stock Value");
        }
        if (item != Sell)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
        UI.Notify(this.GetHostName() + " ok i can deal with that, selling all product avalable");
        Game.Player.Money += (int) ((double) this.stocksvalue * 0.75);
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
    }

    public void SetupMarker()
    {
      if (this.Facility != (Blip) null)
        this.Facility.Remove();
      this.Facility = World.CreateBlip(this.Entry);
      Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Facility, (InputArgument) 590);
      this.Facility.Color = this.Blip_Colour;
      this.Facility.Name = "Doomsday Heist Business Facility";
      this.Facility.IsShortRange = true;
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
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
        this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + this.currentbank.ToString() + "]", this.MoneyStored);
        UI.Notify(this.GetHostName() + " Money in Vault  ~b~" + this.currentbank.ToString() + "~w~, ~g~$" + this.MoneyStored.ToString("N"));
      });
    }

    public void setupMarker()
    {
      this.Range = World.CreateBlip(this.MoneyStorageMarker);
      this.Range.Sprite = BlipSprite.DollarSign;
      this.Range.Color = this.Blip_Colour;
      this.Range.Name = "Gunrunning Money Vault";
      this.Range.IsShortRange = true;
    }

    public void DeleteMarker()
    {
      if (!(this.Range != (Blip) null))
        return;
      this.Range.Remove();
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_33_x17dlc_int_02_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_33_x17dlc_int_02_milo_");
      this.waittime = this.AllStocks.waittime;
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Doomsday Facility", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.RIMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Facility Customization");
      this.GUIMenus.Add(this.RIMenu);
      this.methgarage = this.modMenuPool.AddSubMenu(this.mainMenu, "Purchase Options");
      this.GUIMenus.Add(this.methgarage);
      this.ProductStock = this.modMenuPool.AddSubMenu(this.mainMenu, "Product Options");
      this.GUIMenus.Add(this.ProductStock);
      this.SamSites = this.modMenuPool.AddSubMenu(this.mainMenu, "SAM Sites (Missions)");
      this.GUIMenus.Add(this.SamSites);
      this.CoopElimination = this.modMenuPool.AddSubMenu(this.mainMenu, "Co-op Eliminaton (Missions)");
      this.GUIMenus.Add(this.CoopElimination);
      this.WeaponizedCargo = this.modMenuPool.AddSubMenu(this.mainMenu, "Weaponized Cargo (Missions)");
      this.GUIMenus.Add(this.WeaponizedCargo);
      this.Elimination = this.modMenuPool.AddSubMenu(this.mainMenu, "Elimination (Missions)");
      this.GUIMenus.Add(this.Elimination);
      this.SpecialMissions = this.modMenuPool.AddSubMenu(this.mainMenu, "Special Missions ");
      this.GUIMenus.Add(this.SpecialMissions);
      this.Extras = this.modMenuPool.AddSubMenu(this.mainMenu, "Extras");
      this.GUIMenus.Add(this.Extras);
      this.modMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Source a Vehicle", "Select an Option");
      this.GUIMenus.Add(this.mainMenu2);
      this.modMenuPool2.Add(this.mainMenu2);
      this.source = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Source a vehicle");
      this.GUIMenus.Add(this.source);
      this.Customization = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Purchase a vehicle");
      this.GUIMenus.Add(this.Customization);
      this.GarageMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Garage Options");
      this.GUIMenus.Add(this.GarageMenu);
      this.RemoveMenu = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Remove A Vehicle");
      this.GUIMenus.Add(this.RemoveMenu);
      this.SetupSpecialMission();
      this.GunLockerMarker = new Vector3(422.667f, 4811.28f, -60f);
      this.MVmodMenuPool = new MenuPool();
      this.MVmainMenu = new UIMenu("Gunlocker", "Select an Option");
      this.GUIMenus.Add(this.MVmainMenu);
      this.MVmodMenuPool.Add(this.MVmainMenu);
      this.weaponsMenu = this.MVmodMenuPool.AddSubMenu(this.MVmainMenu, "Weapons");
      this.GUIMenus.Add(this.weaponsMenu);
      this.currentbank = 1;
      this.GLmodMenuPool = new MenuPool();
      this.GLmainMenu = new UIMenu("Doomsday Heist", "Select an Option");
      this.GUIMenus.Add(this.GLmainMenu);
      this.GLmodMenuPool.Add(this.GLmainMenu);
      this.MoneyMenu = this.GLmodMenuPool.AddSubMenu(this.GLmainMenu, "Money Options");
      this.GUIMenus.Add(this.MoneyMenu);
      this.SetupMoneyMenu();
      this.SetupWeapons();
      this.RefreshInterior();
      this.SetupGarage();
      this.RemoveCar();
      this.RImodMenuPool = new MenuPool();
      this.RImainMenu = new UIMenu("Doomsday Facility", "Select an Option");
      this.GUIMenus.Add(this.RImainMenu);
      this.RImodMenuPool.Add(this.RImainMenu);
      this.SetupInteriorMenu();
      this.RefreshInterior();
      this.LoadIniFileInteriorD("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
      int num1 = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 462.09f, (InputArgument) 4820.42f, (InputArgument) -59f);
      foreach (object obj in new List<object>()
      {
        (object) "set_int_02_decal_01",
        (object) "set_int_02_decal_02",
        (object) "set_int_02_decal_03",
        (object) "set_int_02_decal_04",
        (object) "set_int_02_decal_05",
        (object) "set_int_02_decal_06",
        (object) "set_int_02_decal_07",
        (object) "set_int_02_decal_08",
        (object) "set_int_02_decal_09",
        (object) "set_int_02_no_cannon",
        (object) "set_int_02_cannon",
        (object) "set_int_02_no_security",
        (object) "set_int_02_no_security",
        (object) "set_int_02_lounge1",
        (object) "set_int_02_lounge2",
        (object) "set_int_02_lounge3",
        (object) "set_int_02_no_sleep",
        (object) "set_int_02_sleep",
        (object) "set_int_02_sleep2",
        (object) "set_int_02_sleep3"
      })
      {
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__314.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__314.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string str = Class1.\u003C\u003Eo__314.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__314.\u003C\u003Ep__0, obj);
        if (str != null)
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) str);
      }
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num1);
      this.LoadIniFileInteriorD("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_33_x17dlc_int_02_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_33_x17dlc_int_02_milo_");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "set_int_02_shell");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilityGraphic);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilityOrbitalCannon);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilitySecurityRoom);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilityLounge);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilitySleepingQuarters);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) "set_int_02_shell", (InputArgument) this.FacilityShellColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilityGraphic, (InputArgument) this.FacilityGraphicColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilityOrbitalCannon, (InputArgument) this.FacilityOrbitalCannonColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilitySecurityRoom, (InputArgument) this.FacilitySecurityRoomColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilityLounge, (InputArgument) this.FacilityLoungeColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilitySleepingQuarters, (InputArgument) this.FacilitySleepingQuartersColor);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num1);
      int num2 = Function.Call<int>(Hash._0xA6575914D2A0B450);
      Function.Call(Hash._0x52923C4710DD9907, (InputArgument) Game.Player.Character, (InputArgument) num1, (InputArgument) num2);
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
      this.CreateBanner();
      this.SetupCustomisation();
      this.SetupProduct();
      this.Buy();
      this.Setupbuisness();
      this.Source();
      this.SetupSam();
      this.SetupElimination();
      this.SetupWeaponizedCargo();
      this.CoopEliminationmissions();
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      this.LoadIniFileDesign("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
      this.SetupMarker();
      for (int index = 0; index < this.GUIMenus.Count<UIMenu>(); ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void SaveInterior()
    {
      this.Config.SetValue<string>("Configurations", "FacilityGraphic", this.FacilityGraphic);
      this.Config.SetValue<string>("Configurations", "FacilityOrbitalCannon", this.FacilityOrbitalCannon);
      this.Config.SetValue<string>("Configurations", "FacilitySecurityRoom", this.FacilitySecurityRoom);
      this.Config.SetValue<string>("Configurations", "FacilityLounge", this.FacilityLounge);
      this.Config.SetValue<string>("Configurations", "FacilitySleepingQuarters", this.FacilitySleepingQuarters);
      this.Config.SetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
      this.Config.SetValue<int>("Configurations", "FacilityGraphicColor", this.FacilityGraphicColor);
      this.Config.SetValue<int>("Configurations", "FacilityOrbitalCannonColor", this.FacilityOrbitalCannonColor);
      this.Config.SetValue<int>("Configurations", "FacilitySecurityRoomColor", this.FacilitySecurityRoomColor);
      this.Config.SetValue<int>("Configurations", "FacilityLoungeColor", this.FacilityLoungeColor);
      this.Config.SetValue<int>("Configurations", "FacilitySleepingQuartersColor", this.FacilitySleepingQuartersColor);
      this.Config.Save();
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
    }

    public void SetupInteriorMenu()
    {
      float TotalCost = 0.0f;
      List<object> Graphic = new List<object>();
      List<object> items1 = new List<object>();
      List<object> GraphicP = new List<object>();
      Graphic.Add((object) "set_int_02_decal_01");
      items1.Add((object) "Default");
      GraphicP.Add((object) 0);
      Graphic.Add((object) "set_int_02_decal_02");
      items1.Add((object) "Decal 1");
      GraphicP.Add((object) 77000);
      Graphic.Add((object) "set_int_02_decal_03");
      items1.Add((object) "Decal 2");
      GraphicP.Add((object) 90000);
      Graphic.Add((object) "set_int_02_decal_04");
      items1.Add((object) "Decal 3");
      GraphicP.Add((object) 106000);
      Graphic.Add((object) "set_int_02_decal_05");
      items1.Add((object) "Decal 4");
      GraphicP.Add((object) 124000);
      Graphic.Add((object) "set_int_02_decal_06");
      items1.Add((object) "Decal 5");
      GraphicP.Add((object) 134000);
      Graphic.Add((object) "set_int_02_decal_07");
      items1.Add((object) "Decal 6");
      GraphicP.Add((object) 145000);
      Graphic.Add((object) "set_int_02_decal_08");
      items1.Add((object) "Decal 7");
      GraphicP.Add((object) 159000);
      Graphic.Add((object) "set_int_02_decal_09");
      items1.Add((object) "Decal 8");
      GraphicP.Add((object) 175000);
      List<object> Item = new List<object>();
      Item.Add((object) "None");
      Item.Add((object) "Utility");
      Item.Add((object) "Prestige");
      Item.Add((object) "Premier");
      List<object> TF = new List<object>();
      TF.Add((object) false);
      TF.Add((object) true);
      List<object> items2 = new List<object>();
      List<object> ColorsPrice = new List<object>();
      items2.Add((object) "Color 1");
      ColorsPrice.Add((object) 0);
      items2.Add((object) "Utility");
      ColorsPrice.Add((object) 0);
      items2.Add((object) "Expertise");
      ColorsPrice.Add((object) 187000);
      items2.Add((object) "Altitude");
      ColorsPrice.Add((object) 225000);
      items2.Add((object) "Power");
      ColorsPrice.Add((object) 262500);
      items2.Add((object) "Authority");
      ColorsPrice.Add((object) 300000);
      items2.Add((object) "Influence");
      ColorsPrice.Add((object) 337500);
      items2.Add((object) "Order");
      ColorsPrice.Add((object) 375000);
      items2.Add((object) "Empire");
      ColorsPrice.Add((object) 412500);
      items2.Add((object) "Supremacy");
      ColorsPrice.Add((object) 450000);
      UIMenu uiMenu = this.RImodMenuPool.AddSubMenu(this.RIMenu, "Interior Design");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem SColour = new UIMenuListItem("Main Color : ", items2, 0);
      uiMenu.AddItem((UIMenuItem) SColour);
      UIMenuListItem G = new UIMenuListItem("Graphic : ", items1, 0);
      uiMenu.AddItem((UIMenuItem) G);
      float ORBITALcost = 0.0f;
      UIMenuListItem ORBITAL = new UIMenuListItem("Orbital Cannon : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) ORBITAL);
      float SecurityRoomcost = 0.0f;
      UIMenuListItem SecurityRoom = new UIMenuListItem("Security Room : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) SecurityRoom);
      float LoungeRoomcost = 0.0f;
      UIMenuListItem Lounge = new UIMenuListItem("Lounge : ", Item, 0);
      uiMenu.AddItem((UIMenuItem) Lounge);
      float SleepingQuarterscost = 0.0f;
      UIMenuListItem SleepingQuarters = new UIMenuListItem("Sleeping Quarters : ", Item, 0);
      uiMenu.AddItem((UIMenuItem) SleepingQuarters);
      float PrivacyGlasscost = 0.0f;
      UIMenuListItem PrivacyGlass = new UIMenuListItem("Privacy Glass  : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) PrivacyGlass);
      UIMenuItem BuyFacilityCustomization = new UIMenuItem("Buy ~g~$0");
      uiMenu.AddItem(BuyFacilityCustomization);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != BuyFacilityCustomization)
          return;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, float>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (float), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float> target1 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float>> p6 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target2 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__5.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p5 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__5;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target3 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__4.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p4 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__4;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target4 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p3 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target5 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p2 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__2;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target6 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p1 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__0, GraphicP[G.Index], ColorsPrice[SColour.Index]);
        double num1 = (double) ORBITALcost;
        object obj2 = target6((CallSite) p1, obj1, (float) num1);
        double num2 = (double) SecurityRoomcost;
        object obj3 = target5((CallSite) p2, obj2, (float) num2);
        double num3 = (double) LoungeRoomcost;
        object obj4 = target4((CallSite) p3, obj3, (float) num3);
        double num4 = (double) SleepingQuarterscost;
        object obj5 = target3((CallSite) p4, obj4, (float) num4);
        double num5 = (double) PrivacyGlasscost;
        object obj6 = target2((CallSite) p5, obj5, (float) num5);
        TotalCost = target1((CallSite) p6, obj6);
        TotalCost = (float) (int) TotalCost;
        BuyFacilityCustomization.Text = "Buy ~g~$" + TotalCost.ToString("N");
        if ((double) Game.Player.Money >= (double) TotalCost)
        {
          Game.Player.Money -= (int) TotalCost;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.FacilityGraphic = Class1.\u003C\u003Eo__316.\u003C\u003Ep__7.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__7, Graphic[G.Index]);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__9 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__9.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p9 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__9;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__8.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__8, TF[SecurityRoom.Index], false);
          if (target7((CallSite) p9, obj7))
          {
            SecurityRoomcost = 0.0f;
            this.FacilitySecurityRoom = "set_int_02_no_security";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__11 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__11.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p11 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__11;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__10 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__10.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__10, TF[SecurityRoom.Index], true);
          if (target8((CallSite) p11, obj8))
          {
            SecurityRoomcost = 775000f;
            this.FacilitySecurityRoom = "set_int_02_security";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__13 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target9 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__13.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p13 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__13;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__12 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj9 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__12.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__12, Item[SleepingQuarters.Index], "None");
          if (target9((CallSite) p13, obj9))
          {
            SleepingQuarterscost = 0.0f;
            this.FacilitySleepingQuarters = "set_int_02_no_sleep";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__15 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target10 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__15.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p15 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__15;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__14 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj10 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__14.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__14, Item[SleepingQuarters.Index], "Utility");
          if (target10((CallSite) p15, obj10))
          {
            SleepingQuarterscost = 150000f;
            this.FacilitySleepingQuarters = "set_int_02_sleep";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__17 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target11 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__17.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p17 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__17;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__16 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj11 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__16.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__16, Item[SleepingQuarters.Index], "Prestige");
          if (target11((CallSite) p17, obj11))
          {
            SleepingQuarterscost = 235000f;
            this.FacilitySleepingQuarters = "set_int_02_sleep2";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__19 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target12 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__19.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p19 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__19;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__18 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj12 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__18.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__18, Item[SleepingQuarters.Index], "Premier");
          if (target12((CallSite) p19, obj12))
          {
            SleepingQuarterscost = 290000f;
            this.FacilitySleepingQuarters = "set_int_02_sleep3";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__21 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target13 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__21.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p21 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__21;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__20 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj13 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__20.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__20, Item[Lounge.Index], "None");
          if (target13((CallSite) p21, obj13))
          {
            LoungeRoomcost = 0.0f;
            this.FacilityLounge = "";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__23 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__23 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target14 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__23.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p23 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__23;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__22 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj14 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__22.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__22, Item[Lounge.Index], "Utility");
          if (target14((CallSite) p23, obj14))
          {
            LoungeRoomcost = 0.0f;
            this.FacilityLounge = "set_int_02_lounge1";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__25 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__25 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target15 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__25.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p25 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__25;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__24 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__24 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj15 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__24.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__24, Item[Lounge.Index], "Prestige");
          if (target15((CallSite) p25, obj15))
          {
            LoungeRoomcost = 186000f;
            this.FacilityLounge = "set_int_02_lounge2";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__27 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__27 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target16 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__27.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p27 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__27;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__26 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__26 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj16 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__26.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__26, Item[Lounge.Index], "Premier");
          if (target16((CallSite) p27, obj16))
          {
            LoungeRoomcost = 245000f;
            this.FacilityLounge = "set_int_02_lounge3";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__29 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__29 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target17 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__29.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p29 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__29;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__28 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__28 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj17 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__28.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__28, TF[ORBITAL.Index], true);
          if (target17((CallSite) p29, obj17))
          {
            ORBITALcost = 900000f;
            this.FacilityOrbitalCannon = "set_int_02_cannon";
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__31 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__31 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target18 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__31.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p31 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__31;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__30 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__30 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj18 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__30.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__30, TF[ORBITAL.Index], false);
          if (target18((CallSite) p31, obj18))
          {
            ORBITALcost = 0.0f;
            this.FacilityOrbitalCannon = "set_int_02_no_cannon";
          }
          this.FacilityShellColor = SColour.Index;
          this.FacilityGraphicColor = SColour.Index;
          this.FacilityOrbitalCannonColor = SColour.Index;
          this.FacilitySecurityRoomColor = SColour.Index;
          this.FacilityLoungeColor = SColour.Index;
          this.FacilitySleepingQuartersColor = SColour.Index;
          this.RefreshInterior();
          this.SaveInterior();
          this.RefreshInterior();
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
          this.PrivacyGlassBought = PrivacyGlass.Index;
          this.Config.SetValue<int>("PrivacyGlass", "PrivacyGlassBought", this.PrivacyGlassBought);
          this.Config.Save();
        }
      });
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__38 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__38 = CallSite<Func<CallSite, object, float>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (float), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float> target1 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__38.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float>> p38 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__38;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__37 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__37 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target2 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__37.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p37 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__37;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__36 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__36 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target3 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__36.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p36 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__36;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__35 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__35 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target4 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__35.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p35 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__35;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__34 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__34 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target5 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__34.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p34 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__34;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__33 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__33 = CallSite<Func<CallSite, object, float, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, float, object> target6 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__33.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, float, object>> p33 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__33;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__32 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__316.\u003C\u003Ep__32 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__32.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__32, GraphicP[G.Index], ColorsPrice[SColour.Index]);
        double num1 = (double) ORBITALcost;
        object obj2 = target6((CallSite) p33, obj1, (float) num1);
        double num2 = (double) SecurityRoomcost;
        object obj3 = target5((CallSite) p34, obj2, (float) num2);
        double num3 = (double) LoungeRoomcost;
        object obj4 = target4((CallSite) p35, obj3, (float) num3);
        double num4 = (double) SleepingQuarterscost;
        object obj5 = target3((CallSite) p36, obj4, (float) num4);
        double num5 = (double) PrivacyGlasscost;
        object obj6 = target2((CallSite) p37, obj5, (float) num5);
        TotalCost = target1((CallSite) p38, obj6);
        TotalCost = (float) (int) TotalCost;
        BuyFacilityCustomization.Text = "Buy ~g~$" + TotalCost.ToString("N");
        if (item == G)
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__39 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__39 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.FacilityGraphic = Class1.\u003C\u003Eo__316.\u003C\u003Ep__39.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__39, Graphic[G.Index]);
          this.RefreshInterior();
        }
        if (item == SecurityRoom)
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__41 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__41 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__41.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p41 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__41;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__40 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__40 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__40.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__40, TF[SecurityRoom.Index], false);
          if (target7((CallSite) p41, obj7))
          {
            SecurityRoomcost = 0.0f;
            this.FacilitySecurityRoom = "set_int_02_no_security";
            this.RefreshInterior();
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__43 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__43 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__43.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p43 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__43;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__42 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__42 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__42.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__42, TF[SecurityRoom.Index], true);
          if (target8((CallSite) p43, obj8))
          {
            SecurityRoomcost = 775000f;
            this.FacilitySecurityRoom = "set_int_02_security";
            this.RefreshInterior();
          }
        }
        if (item == SleepingQuarters)
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__45 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__45 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__45.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p45 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__45;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__44 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__44 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__44.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__44, Item[SleepingQuarters.Index], "None");
          if (target7((CallSite) p45, obj7))
          {
            SleepingQuarterscost = 0.0f;
            this.FacilitySleepingQuarters = "set_int_02_no_sleep";
            this.RefreshInterior();
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__47 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__47 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__47.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p47 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__47;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__46 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__46 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__46.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__46, Item[SleepingQuarters.Index], "Utility");
          if (target8((CallSite) p47, obj8))
          {
            SleepingQuarterscost = 150000f;
            this.FacilitySleepingQuarters = "set_int_02_sleep";
            this.RefreshInterior();
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__49 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__49 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target9 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__49.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p49 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__49;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__48 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__48 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj9 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__48.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__48, Item[SleepingQuarters.Index], "Prestige");
          if (target9((CallSite) p49, obj9))
          {
            SleepingQuarterscost = 235000f;
            this.FacilitySleepingQuarters = "set_int_02_sleep2";
            this.RefreshInterior();
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__51 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__51 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target10 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__51.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p51 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__51;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__50 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__50 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj10 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__50.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__50, Item[SleepingQuarters.Index], "Premier");
          if (target10((CallSite) p51, obj10))
          {
            SleepingQuarterscost = 290000f;
            this.FacilitySleepingQuarters = "set_int_02_sleep3";
            this.RefreshInterior();
          }
        }
        if (item == Lounge)
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__53 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__53 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__53.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p53 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__53;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__52 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__52 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__52.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__52, Item[Lounge.Index], "None");
          if (target7((CallSite) p53, obj7))
          {
            LoungeRoomcost = 0.0f;
            this.FacilityLounge = "";
            this.RefreshInterior();
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__55 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__55 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__55.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p55 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__55;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__54 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__54 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__54.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__54, Item[Lounge.Index], "Utility");
          if (target8((CallSite) p55, obj8))
          {
            LoungeRoomcost = 0.0f;
            this.FacilityLounge = "set_int_02_lounge1";
            this.RefreshInterior();
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__57 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__57 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target9 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__57.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p57 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__57;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__56 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__56 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj9 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__56.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__56, Item[Lounge.Index], "Prestige");
          if (target9((CallSite) p57, obj9))
          {
            LoungeRoomcost = 186000f;
            this.FacilityLounge = "set_int_02_lounge2";
            this.RefreshInterior();
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__59 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__59 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target10 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__59.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p59 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__59;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__58 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__58 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj10 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__58.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__58, Item[Lounge.Index], "Premier");
          if (target10((CallSite) p59, obj10))
          {
            LoungeRoomcost = 245000f;
            this.FacilityLounge = "set_int_02_lounge3";
            this.RefreshInterior();
          }
        }
        if (item == ORBITAL)
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__61 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__61 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__61.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p61 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__61;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__60 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__60 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__60.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__60, TF[ORBITAL.Index], true);
          if (target7((CallSite) p61, obj7))
          {
            ORBITALcost = 900000f;
            this.FacilityOrbitalCannon = "set_int_02_cannon";
            this.RefreshInterior();
          }
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__63 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__63 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__63.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p63 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__63;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__316.\u003C\u003Ep__62 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__316.\u003C\u003Ep__62 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj8 = Class1.\u003C\u003Eo__316.\u003C\u003Ep__62.Target((CallSite) Class1.\u003C\u003Eo__316.\u003C\u003Ep__62, TF[ORBITAL.Index], false);
          if (target8((CallSite) p63, obj8))
          {
            ORBITALcost = 0.0f;
            this.FacilityOrbitalCannon = "set_int_02_no_cannon";
            this.RefreshInterior();
          }
        }
        if (item == PrivacyGlass)
        {
          if (PrivacyGlass.Index == 0)
            PrivacyGlasscost = 0.0f;
          if (PrivacyGlass.Index == 1)
            PrivacyGlasscost = 100000f;
        }
        if (item == SColour)
        {
          this.FacilityShellColor = SColour.Index;
          this.FacilityGraphicColor = SColour.Index;
          this.FacilityOrbitalCannonColor = SColour.Index;
          this.FacilitySecurityRoomColor = SColour.Index;
          this.FacilityLoungeColor = SColour.Index;
          this.FacilitySleepingQuartersColor = SColour.Index;
          this.RefreshInterior();
        }
        int num6 = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 462.09f, (InputArgument) 4820.42f, (InputArgument) -59f);
        int num7 = Function.Call<int>(Hash._0x47C2A06D4F5F424B, (InputArgument) Game.Player.Character);
        Function.Call(Hash._0x52923C4710DD9907, (InputArgument) Game.Player.Character, (InputArgument) num6, (InputArgument) num7);
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num6);
      });
    }

    private void LoadIniFileInteriorD(string iniName)
    {
      try
      {
        this.ConfigInteriorD = ScriptSettings.Load(iniName);
        this.FacilityGraphic = this.ConfigInteriorD.GetValue<string>("Configurations", "FacilityGraphic", this.FacilityGraphic);
        this.FacilityOrbitalCannon = this.ConfigInteriorD.GetValue<string>("Configurations", "FacilityOrbitalCannon", this.FacilityOrbitalCannon);
        this.FacilitySecurityRoom = this.ConfigInteriorD.GetValue<string>("Configurations", "FacilitySecurityRoom", this.FacilitySecurityRoom);
        this.FacilityLounge = this.ConfigInteriorD.GetValue<string>("Configurations", "FacilityLounge", this.FacilityLounge);
        this.FacilitySleepingQuarters = this.ConfigInteriorD.GetValue<string>("Configurations", "FacilitySleepingQuarters", this.FacilitySleepingQuarters);
        this.FacilityShellColor = this.ConfigInteriorD.GetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
        this.FacilityGraphicColor = this.ConfigInteriorD.GetValue<int>("Configurations", "FacilityGraphicColor", this.FacilityGraphicColor);
        this.FacilityOrbitalCannonColor = this.ConfigInteriorD.GetValue<int>("Configurations", "FacilityOrbitalCannonColor", this.FacilityOrbitalCannonColor);
        this.FacilitySecurityRoomColor = this.ConfigInteriorD.GetValue<int>("Configurations", "FacilitySecurityRoomColor", this.FacilitySecurityRoomColor);
        this.FacilityLoungeColor = this.ConfigInteriorD.GetValue<int>("Configurations", "FacilityLoungeColor", this.FacilityLoungeColor);
        this.FacilitySleepingQuartersColor = this.ConfigInteriorD.GetValue<int>("Configurations", "FacilitySleepingQuartersColor", this.FacilitySleepingQuartersColor);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: InteriorDesign.ini Failed To Load.");
      }
    }

    private void LoadIniFile2(string iniName)
    {
      try
      {
        this.IniSettings = ScriptSettings.Load(iniName);
        this.IniSettings.SetValue<string>("Facility Configuration", "Facility Graphic Configuration", this.FacilityGraphic);
        this.IniSettings.SetValue<string>("Facility Configuration", "Orbital Cannon", this.FacilityOrbitalCannon);
        this.IniSettings.SetValue<string>("Facility Configuration", "Security Room", this.FacilitySecurityRoom);
        this.IniSettings.SetValue<string>("Facility Configuration", "Lounge", this.FacilityLounge);
        this.IniSettings.SetValue<string>("Facility Configuration", "Sleeping Quarters", this.FacilitySleepingQuarters);
        this.IniSettings.SetValue<int>("Facility Tint Configuration", "Facility Shell Color", this.FacilityShellColor);
        this.IniSettings.SetValue<int>("Facility Tint Configuration", "Graphic Color", this.FacilityGraphicColor);
        this.IniSettings.SetValue<int>("Facility Tint Configuration", "Orbital Cannon Color", this.FacilityOrbitalCannonColor);
        this.IniSettings.SetValue<int>("Facility Tint Configuration", "Security Room Color", this.FacilitySecurityRoomColor);
        this.IniSettings.SetValue<int>("Facility Tint Configuration", "Lounge Color", this.FacilityLoungeColor);
        this.IniSettings.SetValue<int>("Facility Tint Configuration", "Sleeping Quarters Color", this.FacilitySleepingQuartersColor);
        this.IniSettings.Save();
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: InteriorDesign.ini Failed To Load.");
      }
    }

    private void SetupWeaponizedCargo()
    {
      UIMenu uiMenu = this.modMenuPool2.AddSubMenu(this.WeaponizedCargo, "Elimination Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 EMP");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 Retro-Reflection Panels");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Mission 3 heavy Armour Plating");
      uiMenu.AddItem(Mission3);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission3)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          if (this.EndPointBlip != (Blip) null)
            this.EndPointBlip.Remove();
          this.EndPoint = new Vector3(-1286.58f, 2529.48f, 20f);
          System.Random random = new System.Random();
          if (random.Next(1, 30) < 10)
            this.Sam1Loc = new Vector3(-2168.24f, -343f, 14f);
          if (random.Next(1, 30) > 10 && random.Next(1, 30) < 20)
            this.Sam1Loc = new Vector3(2199f, 3015.55f, 45f);
          if (random.Next(1, 30) > 20 && random.Next(1, 30) < 30)
            this.Sam1Loc = new Vector3(-155f, 6216.85f, 32f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.NightShark, this.Sam1Loc);
          this.Sam1.SetMod(VehicleMod.Roof, 1, true);
          this.Sam1.BodyHealth = 1000f;
          this.Sam1.PrimaryColor = VehicleColor.Chrome;
          this.Sam1.SecondaryColor = VehicleColor.Chrome;
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPoint, 20f, 120f, 1);
          this.Sam1.SetMod(VehicleMod.Livery, new System.Random().Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.SportsCar;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Vehicle A";
          this.EndPointBlip = World.CreateBlip(this.EndPoint);
          this.EndPointBlip.Sprite = BlipSprite.Castle;
          this.EndPointBlip.Name = "Delivery Point";
          this.missionnum = 4;
          this.MissionSetup = true;
          this.iscloaked = false;
          UI.Notify(this.GetHostName() + " Boss I've spotted a vehicle on route to Fort Zancudo, Destroy it, Before it reachs its destination for a reward");
          UI.Notify(this.GetHostName() + " also boss, i've heard that is carrying some sort of weaponized cargo");
          UI.Notify(this.GetHostName() + " Id on the vehicle is a NightShark");
        }
        if (item == Mission2)
        {
          if ((Entity) this.Sam1 != (Entity) null)
            this.Sam1.Delete();
          if (this.Sam1blip != (Blip) null)
            this.Sam1blip.Remove();
          if (this.EndPointBlip != (Blip) null)
            this.EndPointBlip.Remove();
          this.EndPoint = new Vector3(-1286.58f, 2529.48f, 20f);
          System.Random random = new System.Random();
          if (random.Next(1, 30) < 10)
            this.Sam1Loc = new Vector3(-2168.24f, -343f, 14f);
          if (random.Next(1, 30) > 10 && random.Next(1, 30) < 20)
            this.Sam1Loc = new Vector3(2199f, 3015.55f, 45f);
          if (random.Next(1, 30) > 20 && random.Next(1, 30) < 30)
            this.Sam1Loc = new Vector3(-155f, 6216.85f, 32f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Deluxo, this.Sam1Loc);
          this.Sam1.PrimaryColor = VehicleColor.Chrome;
          this.Sam1.SecondaryColor = VehicleColor.Chrome;
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPoint, 20f, 120f, 1);
          this.Sam1.SetMod(VehicleMod.Livery, new System.Random().Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          this.Sam1blip.Sprite = BlipSprite.SportsCar;
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "Vehicle A";
          this.EndPointBlip = World.CreateBlip(this.EndPoint);
          this.EndPointBlip.Sprite = BlipSprite.Castle;
          this.EndPointBlip.Name = "Delivery Point";
          this.missionnum = 5;
          this.triggerWeaponizedCargo2 = true;
          this.MissionSetup = true;
          this.iscloaked = false;
          UI.Notify(this.GetHostName() + " Boss I've spotted a vehicle on route to Fort Zancudo, Destroy it, Before it reachs its destination for a reward");
          UI.Notify(this.GetHostName() + " also boss, i've heard that is carrying some sort of weaponized cargo");
          UI.Notify(this.GetHostName() + " Id on the vehicle is a Deluxo");
        }
        if (item != Mission1)
          return;
        if ((Entity) this.Sam1 != (Entity) null)
          this.Sam1.Delete();
        if (this.Sam1blip != (Blip) null)
          this.Sam1blip.Remove();
        if (this.EndPointBlip != (Blip) null)
          this.EndPointBlip.Remove();
        this.EndPoint = new Vector3(-1286.58f, 2529.48f, 20f);
        System.Random random1 = new System.Random();
        if (random1.Next(1, 30) < 10)
          this.Sam1Loc = new Vector3(-2168.24f, -343f, 14f);
        if (random1.Next(1, 30) > 10 && random1.Next(1, 30) < 20)
          this.Sam1Loc = new Vector3(2199f, 3015.55f, 45f);
        if (random1.Next(1, 30) > 20 && random1.Next(1, 30) < 30)
          this.Sam1Loc = new Vector3(-155f, 6216.85f, 32f);
        System.Random random2 = new System.Random();
        if (random2.Next(1, 100) < 10)
          this.VehicleId = VehicleHash.Mule;
        if (random2.Next(1, 100) > 10 && random2.Next(1, 100) < 20)
          this.VehicleId = VehicleHash.Mule2;
        if (random2.Next(1, 100) > 20 && random2.Next(1, 100) < 30)
          this.VehicleId = VehicleHash.Mule3;
        if (random2.Next(1, 100) > 30 && random2.Next(1, 100) < 40)
          this.VehicleId = VehicleHash.Boxville;
        if (random2.Next(1, 100) > 40 && random2.Next(1, 100) < 50)
          this.VehicleId = VehicleHash.Pounder;
        if (random2.Next(1, 100) > 50 && random2.Next(1, 100) < 60)
          this.VehicleId = VehicleHash.Boxville2;
        if (random2.Next(1, 100) > 60 && random2.Next(1, 100) < 70)
          this.VehicleId = VehicleHash.Benson;
        if (random2.Next(1, 100) > 70 && random2.Next(1, 100) < 80)
          this.VehicleId = VehicleHash.Biff;
        if (random2.Next(1, 100) > 80 && random2.Next(1, 100) < 90)
          this.VehicleId = VehicleHash.Boxville3;
        if (random2.Next(1, 100) > 90 && random2.Next(1, 100) < 100)
          this.VehicleId = VehicleHash.Boxville4;
        this.Sam1 = World.CreateVehicle((Model) this.VehicleId, this.Sam1Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPoint, 20f, 70f, 1);
        this.Sam1.SetMod(VehicleMod.Livery, new System.Random().Next(1, 30), true);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        this.Sam1blip.Sprite = BlipSprite.GunCar;
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "Vehicle A";
        this.EndPointBlip = World.CreateBlip(this.EndPoint);
        this.EndPointBlip.Sprite = BlipSprite.Castle;
        this.EndPointBlip.Name = "Delivery Point";
        this.missionnum = 4;
        this.triggerWeaponizedCargo = true;
        this.MissionSetup = true;
        UI.Notify(this.GetHostName() + " Boss I've spotted a vehicle on route to Fort Zancudo, Destroy it, Before it reachs its destination for a reward");
        UI.Notify(this.GetHostName() + " also boss, i've heard that is carrying some sort of weaponized cargo");
        UI.Notify(this.GetHostName() + " Id on the vehicle is some sort of truck or semi, sorry i cant give you any more info");
      });
    }

    public void SetupElimination()
    {
      UIMenu uiMenu = this.modMenuPool2.AddSubMenu(this.Elimination, "Elimination Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Mission 1 (Chernobog)");
      uiMenu.AddItem(Mission1);
      UIMenuItem Mission2 = new UIMenuItem("Mission 2 (Barrage)");
      uiMenu.AddItem(Mission2);
      UIMenuItem Mission3 = new UIMenuItem("Mission 3 (Khanjali)");
      uiMenu.AddItem(Mission3);
      UIMenuItem Mission4 = new UIMenuItem("Mission 4 (Deluxo)");
      uiMenu.AddItem(Mission4);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission1)
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
          this.EndPoint = new Vector3(-1286.58f, 2529.48f, 20f);
          this.Sam1Loc = new Vector3(-2168.24f, -343f, 14f);
          this.Sam2Loc = new Vector3(2199f, 3015.55f, 45f);
          this.Sam3Loc = new Vector3(-155f, 6216.85f, 32f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPoint, 20f, 120f, 1);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.EndPoint, 20f, 120f, 1);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.EndPoint, 20f, 120f, 1);
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
          this.EndPointBlip = World.CreateBlip(this.EndPoint);
          this.EndPointBlip.Sprite = BlipSprite.Castle;
          this.EndPointBlip.Name = "Delivery Point";
          this.missionnum = 3;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " Boss I've spotted 3 vehicles on route to Fort Zancudo, Destroy All Three, Before they reach their destination for a reward");
          UI.Notify(this.GetHostName() + " id on the vehicle says its a Chernobog");
        }
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
          this.EndPoint = new Vector3(-1286.58f, 2529.48f, 20f);
          this.Sam1Loc = new Vector3(-2168.24f, -343f, 14f);
          this.Sam2Loc = new Vector3(2199f, 3015.55f, 45f);
          this.Sam3Loc = new Vector3(-155f, 6216.85f, 32f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Barrage, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Barrage, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Barrage, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPoint, 20f, 140f, 1);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.EndPoint, 20f, 140f, 1);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.EndPoint, 20f, 140f, 1);
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
          this.EndPointBlip = World.CreateBlip(this.EndPoint);
          this.EndPointBlip.Sprite = BlipSprite.Castle;
          this.EndPointBlip.Name = "Delivery Point";
          this.missionnum = 3;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " Boss I've spotted 3 vehicles on route to Fort Zancudo, Destroy All Three, Before they reach their destination for a reward");
          UI.Notify(this.GetHostName() + " id on the vehicle says its a Barrage");
        }
        if (item == Mission3)
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
          this.EndPoint = new Vector3(-1286.58f, 2529.48f, 20f);
          this.Sam1Loc = new Vector3(-2168.24f, -343f, 14f);
          this.Sam2Loc = new Vector3(2199f, 3015.55f, 45f);
          this.Sam3Loc = new Vector3(-155f, 6216.85f, 32f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Khanjari, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Khanjari, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Khanjari, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPoint, 20f, 120f, 1);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.EndPoint, 20f, 120f, 1);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.EndPoint, 20f, 120f, 1);
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
          this.EndPointBlip = World.CreateBlip(this.EndPoint);
          this.EndPointBlip.Sprite = BlipSprite.Castle;
          this.EndPointBlip.Name = "Delivery Point";
          this.missionnum = 3;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " Boss I've spotted 3 vehicles on route to Fort Zancudo, Destroy All Three, Before they reach their destination for a reward");
          UI.Notify(this.GetHostName() + " id on the vehicle says its a Khanjali tank");
        }
        if (item != Mission4)
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
        this.EndPoint = new Vector3(-1286.58f, 2529.48f, 20f);
        this.Sam1Loc = new Vector3(-2168.24f, -343f, 14f);
        this.Sam2Loc = new Vector3(2199f, 3015.55f, 45f);
        this.Sam3Loc = new Vector3(-155f, 6216.85f, 32f);
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.Deluxo, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.Deluxo, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.Deluxo, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPoint, 20f, 150f, 1);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.EndPoint, 20f, 150f, 1);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam3, this.EndPoint, 20f, 150f, 1);
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
        this.EndPointBlip = World.CreateBlip(this.EndPoint);
        this.EndPointBlip.Sprite = BlipSprite.Castle;
        this.EndPointBlip.Name = "Delivery Point";
        this.missionnum = 3;
        this.MissionSetup = true;
        UI.Notify(this.GetHostName() + " Boss I've spotted 3 vehicles on route to Fort Zancudo, Destroy All Three, Before they reach their destination for a reward");
        UI.Notify(this.GetHostName() + " id on the vehicle says its a Deluxo");
      });
    }

    public void SetupSam()
    {
      UIMenu uiMenu1 = this.modMenuPool2.AddSubMenu(this.SamSites, "AA Trailer (50Cal)");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool2.AddSubMenu(this.SamSites, "AA Trailer (Missile)");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool2.AddSubMenu(this.SamSites, "AA Trailer (Flak)");
      this.GUIMenus.Add(uiMenu3);
      UIMenu uiMenu4 = this.modMenuPool2.AddSubMenu(this.SamSites, "Chernobog");
      this.GUIMenus.Add(uiMenu4);
      UIMenuItem Mission1 = new UIMenuItem("SAM Site 1");
      uiMenu1.AddItem(Mission1);
      UIMenuItem Mission4 = new UIMenuItem("SAM Site 2");
      uiMenu1.AddItem(Mission4);
      UIMenuItem Mission7 = new UIMenuItem("SAM Site 3");
      uiMenu1.AddItem(Mission7);
      UIMenuItem Mission2 = new UIMenuItem("SAM Site 1");
      uiMenu2.AddItem(Mission2);
      UIMenuItem Mission5 = new UIMenuItem("SAM Site 2");
      uiMenu2.AddItem(Mission5);
      UIMenuItem Mission8 = new UIMenuItem("SAM Site 3");
      uiMenu2.AddItem(Mission8);
      UIMenuItem Mission3 = new UIMenuItem("SAM Site 1");
      uiMenu3.AddItem(Mission3);
      UIMenuItem Mission6 = new UIMenuItem("SAM Site 2");
      uiMenu3.AddItem(Mission6);
      UIMenuItem Mission9 = new UIMenuItem("SAM Site 3");
      uiMenu3.AddItem(Mission9);
      UIMenuItem Mission10 = new UIMenuItem("SAM Site 1");
      uiMenu4.AddItem(Mission10);
      UIMenuItem Mission11 = new UIMenuItem("SAM Site 2");
      uiMenu4.AddItem(Mission11);
      UIMenuItem Mission12 = new UIMenuItem("SAM Site 3");
      uiMenu4.AddItem(Mission12);
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission10)
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
          this.Sam1Loc = new Vector3(2446.45f, 3253.99f, 50f);
          this.Sam2Loc = new Vector3(2526.39f, 3245.52f, 53f);
          this.Sam3Loc = new Vector3(2519.17f, 3325.22f, 53f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.SetMod(VehicleMod.Roof, 1, true);
          this.Sam2.SetMod(VehicleMod.Roof, 1, true);
          this.Sam3.SetMod(VehicleMod.Roof, 1, true);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "SAM Site A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "SAM Site B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "SAM Site C";
          this.missionnum = 2;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
        }
        if (item == Mission11)
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
          this.Sam1Loc = new Vector3(2685.48f, 4504.99f, 41f);
          this.Sam2Loc = new Vector3(2598.29f, 4474.98f, 38f);
          this.Sam3Loc = new Vector3(2640.05f, 4586.71f, 37f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.SetMod(VehicleMod.Roof, 1, true);
          this.Sam2.SetMod(VehicleMod.Roof, 1, true);
          this.Sam3.SetMod(VehicleMod.Roof, 1, true);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "SAM Site A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "SAM Site B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "SAM Site C";
          this.missionnum = 2;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
        }
        if (item != Mission12)
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
        this.Sam1Loc = new Vector3(1821.51f, 4916.71f, 45f);
        this.Sam2Loc = new Vector3(1871.9f, 4902.4f, 45f);
        this.Sam3Loc = new Vector3(1843.31f, 4909.71f, 44f);
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.Chernobog, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.SetMod(VehicleMod.Roof, 1, true);
        this.Sam2.SetMod(VehicleMod.Roof, 1, true);
        this.Sam3.SetMod(VehicleMod.Roof, 1, true);
        System.Random random1 = new System.Random();
        this.Sam1.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam2.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam3.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "SAM Site A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
        this.Sam2blip.Color = BlipColor.Red;
        this.Sam2blip.Name = "SAM Site B";
        this.Sam3blip = World.CreateBlip(this.Sam3.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
        this.Sam3blip.Color = BlipColor.Red;
        this.Sam3blip.Name = "SAM Site C";
        this.missionnum = 2;
        this.MissionSetup = true;
        UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission8)
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
          this.Sam1Loc = new Vector3(2446.45f, 3253.99f, 50f);
          this.Sam2Loc = new Vector3(2526.39f, 3245.52f, 53f);
          this.Sam3Loc = new Vector3(2519.17f, 3325.22f, 53f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam1.SetMod(VehicleMod.Roof, 0, true);
          this.Sam2.SetMod(VehicleMod.Roof, 0, true);
          this.Sam3.SetMod(VehicleMod.Roof, 0, true);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "SAM Site A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "SAM Site B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "SAM Site C";
          this.missionnum = 2;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
        }
        if (item == Mission5)
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
          this.Sam1Loc = new Vector3(2685.48f, 4504.99f, 41f);
          this.Sam2Loc = new Vector3(2598.29f, 4474.98f, 38f);
          this.Sam3Loc = new Vector3(2640.05f, 4586.71f, 37f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam1.SetMod(VehicleMod.Roof, 0, true);
          this.Sam2.SetMod(VehicleMod.Roof, 0, true);
          this.Sam3.SetMod(VehicleMod.Roof, 0, true);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "SAM Site A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "SAM Site B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "SAM Site C";
          this.missionnum = 2;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
        }
        if (item != Mission2)
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
        this.Sam1Loc = new Vector3(1821.51f, 4916.71f, 45f);
        this.Sam2Loc = new Vector3(1871.9f, 4902.4f, 45f);
        this.Sam3Loc = new Vector3(1843.31f, 4909.71f, 44f);
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam1.SetMod(VehicleMod.Roof, 0, true);
        this.Sam2.SetMod(VehicleMod.Roof, 0, true);
        this.Sam3.SetMod(VehicleMod.Roof, 0, true);
        System.Random random1 = new System.Random();
        this.Sam1.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam2.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam3.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "SAM Site A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
        this.Sam2blip.Color = BlipColor.Red;
        this.Sam2blip.Name = "SAM Site B";
        this.Sam3blip = World.CreateBlip(this.Sam3.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
        this.Sam3blip.Color = BlipColor.Red;
        this.Sam3blip.Name = "SAM Site C";
        this.missionnum = 2;
        this.MissionSetup = true;
        UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission9)
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
          this.Sam1Loc = new Vector3(2446.45f, 3253.99f, 50f);
          this.Sam2Loc = new Vector3(2526.39f, 3245.52f, 53f);
          this.Sam3Loc = new Vector3(2519.17f, 3325.22f, 53f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam1.SetMod(VehicleMod.Roof, 1, true);
          this.Sam2.SetMod(VehicleMod.Roof, 1, true);
          this.Sam3.SetMod(VehicleMod.Roof, 1, true);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "SAM Site A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "SAM Site B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "SAM Site C";
          this.missionnum = 2;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
        }
        if (item == Mission6)
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
          this.Sam1Loc = new Vector3(2685.48f, 4504.99f, 41f);
          this.Sam2Loc = new Vector3(2598.29f, 4474.98f, 38f);
          this.Sam3Loc = new Vector3(2640.05f, 4586.71f, 37f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam1.SetMod(VehicleMod.Roof, 1, true);
          this.Sam2.SetMod(VehicleMod.Roof, 1, true);
          this.Sam3.SetMod(VehicleMod.Roof, 1, true);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "SAM Site A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "SAM Site B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "SAM Site C";
          this.missionnum = 2;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
        }
        if (item != Mission3)
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
        this.Sam1Loc = new Vector3(1821.51f, 4916.71f, 45f);
        this.Sam2Loc = new Vector3(1871.9f, 4902.4f, 45f);
        this.Sam3Loc = new Vector3(1843.31f, 4909.71f, 44f);
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam1.SetMod(VehicleMod.Roof, 1, true);
        this.Sam2.SetMod(VehicleMod.Roof, 1, true);
        this.Sam3.SetMod(VehicleMod.Roof, 1, true);
        System.Random random1 = new System.Random();
        this.Sam1.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam2.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam3.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "SAM Site A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
        this.Sam2blip.Color = BlipColor.Red;
        this.Sam2blip.Name = "SAM Site B";
        this.Sam3blip = World.CreateBlip(this.Sam3.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
        this.Sam3blip.Color = BlipColor.Red;
        this.Sam3blip.Name = "SAM Site C";
        this.missionnum = 2;
        this.MissionSetup = true;
        UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Mission7)
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
          this.Sam1Loc = new Vector3(2685.48f, 4504.99f, 41f);
          this.Sam2Loc = new Vector3(2598.29f, 4474.98f, 38f);
          this.Sam3Loc = new Vector3(2640.05f, 4586.71f, 37f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "SAM Site A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "SAM Site B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "SAM Site C";
          this.missionnum = 2;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
        }
        if (item == Mission4)
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
          this.Sam1Loc = new Vector3(2446.45f, 3253.99f, 50f);
          this.Sam2Loc = new Vector3(2526.39f, 3245.52f, 53f);
          this.Sam3Loc = new Vector3(2519.17f, 3325.22f, 53f);
          this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
          this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          System.Random random = new System.Random();
          this.Sam1.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam2.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam3.SetMod(VehicleMod.Livery, random.Next(1, 30), true);
          this.Sam1blip = World.CreateBlip(this.Sam1.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
          this.Sam1blip.Color = BlipColor.Red;
          this.Sam1blip.Name = "SAM Site A";
          this.Sam2blip = World.CreateBlip(this.Sam2.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
          this.Sam2blip.Color = BlipColor.Red;
          this.Sam2blip.Name = "SAM Site B";
          this.Sam3blip = World.CreateBlip(this.Sam3.Position);
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
          this.Sam3blip.Color = BlipColor.Red;
          this.Sam3blip.Name = "SAM Site C";
          this.missionnum = 2;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
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
        this.Sam1Loc = new Vector3(1821.51f, 4916.71f, 45f);
        this.Sam2Loc = new Vector3(1871.9f, 4902.4f, 45f);
        this.Sam3Loc = new Vector3(1843.31f, 4909.71f, 44f);
        this.Sam1 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam1Loc);
        this.Sam2 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam2Loc);
        this.Sam3 = World.CreateVehicle((Model) VehicleHash.TrailerSmall2, this.Sam3Loc);
        this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.ArmGoon02GMY);
        this.Sam3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        System.Random random1 = new System.Random();
        this.Sam1.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam2.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam3.SetMod(VehicleMod.Livery, random1.Next(1, 30), true);
        this.Sam1blip = World.CreateBlip(this.Sam1.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam1blip, (InputArgument) 548);
        this.Sam1blip.Color = BlipColor.Red;
        this.Sam1blip.Name = "SAM Site A";
        this.Sam2blip = World.CreateBlip(this.Sam2.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam2blip, (InputArgument) 548);
        this.Sam2blip.Color = BlipColor.Red;
        this.Sam2blip.Name = "SAM Site B";
        this.Sam3blip = World.CreateBlip(this.Sam3.Position);
        Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Sam3blip, (InputArgument) 548);
        this.Sam3blip.Color = BlipColor.Red;
        this.Sam3blip.Name = "SAM Site C";
        this.missionnum = 2;
        this.MissionSetup = true;
        UI.Notify(this.GetHostName() + " I've located a SAM site, go destroy All vehicles for a reward");
      });
    }

    public Vector3 SpawnLocAir()
    {
      System.Random random = new System.Random();
      if (random.Next(1, 2) == 1)
        this.EnemySpawn = new Vector3(2029.54f, 4764.26f, 42f);
      if (random.Next(1, 2) == 2)
        this.EnemySpawn = new Vector3(1338.6f, 3118.47f, 42f);
      return this.EnemySpawn;
    }

    public void SetupMissions()
    {
      UIMenu uiMenu = this.modMenuPool2.AddSubMenu(this.Missions, "Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Mission1 = new UIMenuItem("Chilliad Mountain");
      uiMenu.AddItem(Mission1);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Mission1)
          return;
        if ((Entity) this.SamArray1 != (Entity) null)
          this.SamArray1.Delete();
        if ((Entity) this.SamArray2 != (Entity) null)
          this.SamArray2.Delete();
        if ((Entity) this.SamArray3 != (Entity) null)
          this.SamArray3.Delete();
        if ((Entity) this.SamArray4 != (Entity) null)
          this.SamArray4.Delete();
        if ((Entity) this.SamArray5 != (Entity) null)
          this.SamArray5.Delete();
        if ((Entity) this.SamArray6 != (Entity) null)
          this.SamArray6.Delete();
        if ((Entity) this.SamArray7 != (Entity) null)
          this.SamArray7.Delete();
        Vector3 position1 = new Vector3(138.55f, 5178.39f, 552.6f);
        position1 = new Vector3(position1.X, position1.Y, World.GetGroundHeight(position1));
        Vector3 position2 = new Vector3(254.64f, 5264.979f, 609.9f);
        position2 = new Vector3(position2.X, position2.Y, World.GetGroundHeight(position2));
        Vector3 position3 = new Vector3(380.7737f, 5514.5f, 726.6193f);
        position3 = new Vector3(position3.X, position3.Y, World.GetGroundHeight(position3));
        Vector3 position4 = new Vector3(472.79f, 5484.919f, 754.0187f);
        position4 = new Vector3(position4.X, position4.Y, World.GetGroundHeight(position4));
        Vector3 position5 = new Vector3(472.79f, 5484.919f, 754.0187f);
        position5 = new Vector3(position5.X, position5.Y, World.GetGroundHeight(position5));
        this.SamArray1 = World.CreateProp(this.RequestModel("xm_prop_sam_turret_01"), position1, false, false);
        this.SamArray2 = World.CreateProp(this.RequestModel("xm_prop_sam_turret_01"), position2, false, false);
        this.SamArray3 = World.CreateProp(this.RequestModel("xm_prop_sam_turret_01"), position3, false, false);
        this.SamArray4 = World.CreateProp(this.RequestModel("xm_prop_sam_turret_01"), position4, false, false);
        this.SamArray5 = World.CreateProp(this.RequestModel("xm_prop_sam_turret_01"), position4, false, false);
        this.missionnum = 241;
        this.MissionSetup = true;
      });
    }

    public void Buy()
    {
      UIMenu uiMenu = this.modMenuPool2.AddSubMenu(this.Customization, "Buy a vehicle");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Akula = new UIMenuItem("Akula : $2,785,000");
      uiMenu.AddItem(Akula);
      UIMenuItem Avenger = new UIMenuItem("Avenger : $3,450,000");
      uiMenu.AddItem(Avenger);
      UIMenuItem Barrage = new UIMenuItem("Barrage : $1,595,000");
      uiMenu.AddItem(Barrage);
      UIMenuItem Chernobog = new UIMenuItem("Chernobog : $2,490,000");
      uiMenu.AddItem(Chernobog);
      UIMenuItem Deluxo = new UIMenuItem("Deluxo : $3,550,000");
      uiMenu.AddItem(Deluxo);
      UIMenuItem Khanjali = new UIMenuItem("Khanjali : $2,895,000");
      uiMenu.AddItem(Khanjali);
      UIMenuItem Stromberg = new UIMenuItem("Stromberg : $2,395,000");
      uiMenu.AddItem(Stromberg);
      UIMenuItem Thruster = new UIMenuItem("Thruster : $2,750,000");
      uiMenu.AddItem(Thruster);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Akula)
        {
          if (this.AkulaBought == 0)
          {
            if (Game.Player.Money >= 2785000)
            {
              Game.Player.Money -= 2785000;
              this.AkulaBought = 1;
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\FacilityStorage\\Akula.ini");
              this.ResetSourcedVehicle();
              this.Config.SetValue<int>("SpecialVehicles", "AkulaBought", this.AkulaBought);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " puchase sucsessful, your new vehicle will be here next time you enter the facility");
            }
            else
              UI.Notify(this.GetHostName() + " you do not have enought money to puchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " you have all ready purchased this vehicle!");
        }
        if (item == Avenger)
        {
          if (this.AvengerBought == 0)
          {
            if (Game.Player.Money >= 3450000)
            {
              Game.Player.Money -= 3450000;
              this.AvengerBought = 1;
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\FacilityStorage\\Avenger.ini");
              this.ResetSourcedVehicle();
              this.Config.SetValue<int>("SpecialVehicles", "AvengerBought", this.AvengerBought);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " puchase sucsessful, your new vehicle will be here next time you enter the facility");
            }
            else
              UI.Notify(this.GetHostName() + " you do not have enought money to puchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " you have all ready purchased this vehicle!");
        }
        if (item == Barrage)
        {
          if (this.BarrageBought == 0)
          {
            if (Game.Player.Money >= 1595000)
            {
              Game.Player.Money -= 1595000;
              this.BarrageBought = 1;
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\FacilityStorage\\Barrage.ini");
              this.ResetSourcedVehicle();
              this.Config.SetValue<int>("SpecialVehicles", "BarrageBought", this.BarrageBought);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " puchase sucsessful, your new vehicle will be here next time you enter the facility");
            }
            else
              UI.Notify(this.GetHostName() + " you do not have enought money to puchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " you have all ready purchased this vehicle!");
        }
        if (item == Chernobog)
        {
          if (this.ChernobogBought == 0)
          {
            if (Game.Player.Money >= 2490000)
            {
              Game.Player.Money -= 2490000;
              this.ChernobogBought = 1;
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\FacilityStorage\\Chernobog.ini");
              this.ResetSourcedVehicle();
              this.Config.SetValue<int>("SpecialVehicles", "ChernobogBought", this.ChernobogBought);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " puchase sucsessful, your new vehicle will be here next time you enter the facility");
            }
            else
              UI.Notify(this.GetHostName() + " you do not have enought money to puchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " you have all ready purchased this vehicle!");
        }
        if (item == Deluxo)
        {
          if (this.DeluxoBought == 0)
          {
            if (Game.Player.Money >= 3550000)
            {
              Game.Player.Money -= 35500000;
              this.DeluxoBought = 1;
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\FacilityStorage\\Deluxo.ini");
              this.ResetSourcedVehicle();
              this.Config.SetValue<int>("SpecialVehicles", "DeluxoBought", this.DeluxoBought);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " puchase sucsessful, your new vehicle will be here next time you enter the facility");
            }
            else
              UI.Notify(this.GetHostName() + " you do not have enought money to puchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " you have all ready purchased this vehicle!");
        }
        if (item == Khanjali)
        {
          if (this.KhanjaliBought == 0)
          {
            if (Game.Player.Money >= 2895000)
            {
              Game.Player.Money -= 2895000;
              this.KhanjaliBought = 1;
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\FacilityStorage\\Khanjali.ini");
              this.ResetSourcedVehicle();
              this.Config.SetValue<int>("SpecialVehicles", "KhanjaliBought", this.KhanjaliBought);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " puchase sucsessful, your new vehicle will be here next time you enter the facility");
            }
            else
              UI.Notify(this.GetHostName() + " you do not have enought money to puchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " you have all ready purchased this vehicle!");
        }
        if (item == Stromberg)
        {
          if (this.StrombergBought == 0)
          {
            if (Game.Player.Money >= 2395000)
            {
              Game.Player.Money -= 2395000;
              this.StrombergBought = 1;
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\FacilityStorage\\Stromberg.ini");
              this.ResetSourcedVehicle();
              this.Config.SetValue<int>("SpecialVehicles", "StrombergBought", this.StrombergBought);
              this.Config.Save();
              UI.Notify(this.GetHostName() + " puchase sucsessful, your new vehicle will be here next time you enter the facility");
            }
            else
              UI.Notify(this.GetHostName() + " you do not have enought money to puchase this vehicle!");
          }
          else
            UI.Notify(this.GetHostName() + " you have all ready purchased this vehicle!");
        }
        if (item != Thruster)
          return;
        if (this.ThrusterBought == 0)
        {
          if (Game.Player.Money >= 2750000)
          {
            Game.Player.Money -= 2750000;
            this.ThrusterBought = 1;
            this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\FacilityStorage\\Thruster.ini");
            this.ResetSourcedVehicle();
            this.Config.SetValue<int>("SpecialVehicles", "ThrusterBought", this.ThrusterBought);
            this.Config.Save();
            UI.Notify(this.GetHostName() + " puchase sucsessful, your new vehicle will be here next time you enter the facility");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to puchase this vehicle!");
        }
        else
          UI.Notify(this.GetHostName() + " you have all ready purchased this vehicle!");
      });
    }

    public void Source()
    {
      UIMenu uiMenu = this.modMenuPool2.AddSubMenu(this.source, "Source a vehicle");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Akula = new UIMenuItem("Akula");
      uiMenu.AddItem(Akula);
      UIMenuItem Avenger = new UIMenuItem("Avenger");
      uiMenu.AddItem(Avenger);
      UIMenuItem Barrage = new UIMenuItem("Barrage");
      uiMenu.AddItem(Barrage);
      UIMenuItem Chernobog = new UIMenuItem("Chernobog");
      uiMenu.AddItem(Chernobog);
      UIMenuItem Deluxo = new UIMenuItem("Deluxo");
      uiMenu.AddItem(Deluxo);
      UIMenuItem Khanjali = new UIMenuItem("Khanjali");
      uiMenu.AddItem(Khanjali);
      UIMenuItem Stromberg = new UIMenuItem("Stromberg");
      uiMenu.AddItem(Stromberg);
      UIMenuItem Thruster = new UIMenuItem("Thruster");
      uiMenu.AddItem(Thruster);
      UIMenuItem ALL = new UIMenuItem("Rapid Source all $3m - $24m");
      uiMenu.AddItem(ALL);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ALL)
        {
          int num = 0;
          bool flag1 = false;
          bool flag2 = false;
          bool flag3 = false;
          bool flag4 = false;
          bool flag5 = false;
          bool flag6 = false;
          bool flag7 = false;
          bool flag8 = false;
          if (this.AkulaBought == 0)
          {
            num += 3000000;
            flag1 = true;
          }
          if (this.AvengerBought == 0)
          {
            num += 3000000;
            flag2 = true;
          }
          if (this.BarrageBought == 0)
          {
            num += 3000000;
            flag3 = true;
          }
          if (this.ChernobogBought == 0)
          {
            num += 3000000;
            flag4 = true;
          }
          if (this.DeluxoBought == 0)
          {
            num += 3000000;
            flag5 = true;
          }
          if (this.KhanjaliBought == 0)
          {
            num += 3000000;
            flag6 = true;
          }
          if (this.StrombergBought == 0)
          {
            num += 3000000;
            flag8 = true;
          }
          if (this.ThrusterBought == 0)
          {
            num += 3000000;
            flag7 = true;
          }
          try
          {
            this.DisplayHelpTextThisFrame("Enter Y or N, Grand total is $" + num.ToString());
            string userInput = Game.GetUserInput(WindowTitle.CELL_EMAIL_BOD, "", 1);
            if (userInput == "Y")
            {
              UI.Notify("You entered Y, proceding with request! ");
              if (Game.Player.Money >= num)
              {
                Game.Player.Money -= num;
                if (flag2)
                  this.AvengerBought = 1;
                this.Config.SetValue<int>("SpecialVehicles", "AvengerBought", this.AvengerBought);
                if (flag1)
                  this.AkulaBought = 1;
                this.Config.SetValue<int>("SpecialVehicles", "AkulaBought", this.AkulaBought);
                if (flag7)
                  this.ThrusterBought = 1;
                this.Config.SetValue<int>("SpecialVehicles", "ThrusterBought", this.ThrusterBought);
                if (flag4)
                  this.ChernobogBought = 1;
                this.Config.SetValue<int>("SpecialVehicles", "ChernobogBought", this.ChernobogBought);
                if (flag3)
                  this.BarrageBought = 1;
                this.Config.SetValue<int>("SpecialVehicles", "BarrageBought", this.BarrageBought);
                if (flag5)
                  this.DeluxoBought = 1;
                this.Config.SetValue<int>("SpecialVehicles", "DeluxoBought", this.DeluxoBought);
                if (flag8)
                  this.StrombergBought = 1;
                this.Config.SetValue<int>("SpecialVehicles", "StrombergBought", this.StrombergBought);
                if (flag6)
                  this.KhanjaliBought = 1;
                this.Config.SetValue<int>("SpecialVehicles", "KhanjaliBought", this.KhanjaliBought);
                this.Config.Save();
                UI.Notify("Successfuly sourced all vehicles that you have not got");
              }
              else
                UI.Notify("you dont have enough money to source all vehicles that you have not got! ");
            }
            if (userInput == "N")
              UI.Notify("You entered N, cancelling request! ");
            else
              UI.Notify("You did not enter a correct key, cancelling request! ");
          }
          catch (NullReferenceException ex)
          {
            UI.Notify("You did not enter a key, cancelling request! ");
          }
        }
        if (item == Khanjali)
        {
          foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
          {
            if ((Entity) sourcingmissionPed != (Entity) null)
              sourcingmissionPed.Delete();
          }
          if (this.SourcingmissionPeds.Count > 0)
            this.SourcingmissionPeds.Clear();
          if ((Entity) this.VehicleToGet != (Entity) null)
            this.VehicleToGet.Delete();
          if (this.MillitaryAsset != (Blip) null)
            this.MillitaryAsset.Remove();
          this.VehicleToGet = World.CreateVehicle(this.RequestModel(VehicleHash.Khanjari), new Vector3(-2153.827f, 3263.586f, 33.36f));
          this.VehicleToGet.Heading = 180f;
          this.VehicleToGet.PlaceOnGround();
          this.VehicleToGet.IsInvincible = true;
          this.GotVehicle = true;
          this.MillitaryAsset = World.CreateBlip(this.VehicleToGet.Position);
          this.MillitaryAsset.Sprite = BlipSprite.Khanjali;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.MillitaryAsset, (InputArgument) 7);
          this.MillitaryAsset.Name = "Retrieve vehicle";
          this.MillitaryAsset.IsShortRange = true;
          UI.Notify(this.GetHostName() + " Ok retrieve this millitary asset, and you can buy and modify it for use");
          this.SourcingMissionOn = true;
          System.Random random = new System.Random();
          int num = random.Next(3, 12);
          for (int index1 = 0; index1 < num; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Armymech01SMY, this.MillitaryAsset.Position.Around((float) random.Next(3, 10)));
            ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            ped.RelationshipGroup = 5;
            ped.IsEnemy = true;
            this.SourcingmissionPeds.Add(ped);
            ped.Task.WanderAround(ped.Position, 15f);
          }
        }
        if (item == Barrage)
        {
          foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
          {
            if ((Entity) sourcingmissionPed != (Entity) null)
              sourcingmissionPed.Delete();
          }
          if (this.SourcingmissionPeds.Count > 0)
            this.SourcingmissionPeds.Clear();
          if ((Entity) this.VehicleToGet != (Entity) null)
            this.VehicleToGet.Delete();
          if (this.MillitaryAsset != (Blip) null)
            this.MillitaryAsset.Remove();
          this.VehicleToGet = World.CreateVehicle(this.RequestModel(VehicleHash.Barrage), new Vector3(529.5886f, 2952.885f, 39.98f));
          this.VehicleToGet.Heading = -76f;
          this.VehicleToGet.PlaceOnGround();
          this.VehicleToGet.IsInvincible = true;
          this.GotVehicle = true;
          this.MillitaryAsset = World.CreateBlip(this.VehicleToGet.Position);
          this.MillitaryAsset.Sprite = BlipSprite.Barrage;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.MillitaryAsset, (InputArgument) 7);
          this.MillitaryAsset.Name = "Retrieve vehicle";
          this.MillitaryAsset.IsShortRange = true;
          UI.Notify(this.GetHostName() + " Ok retrieve this millitary asset, and you can buy and modify it for use");
          this.SourcingMissionOn = true;
          System.Random random = new System.Random();
          int num = random.Next(3, 12);
          for (int index1 = 0; index1 < num; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Armymech01SMY, this.MillitaryAsset.Position.Around((float) random.Next(3, 10)));
            ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            ped.RelationshipGroup = 5;
            ped.IsEnemy = true;
            this.SourcingmissionPeds.Add(ped);
            ped.Task.WanderAround(ped.Position, 15f);
          }
        }
        if (item == Chernobog)
        {
          foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
          {
            if ((Entity) sourcingmissionPed != (Entity) null)
              sourcingmissionPed.Delete();
          }
          if (this.SourcingmissionPeds.Count > 0)
            this.SourcingmissionPeds.Clear();
          if ((Entity) this.VehicleToGet != (Entity) null)
            this.VehicleToGet.Delete();
          if (this.MillitaryAsset != (Blip) null)
            this.MillitaryAsset.Remove();
          this.VehicleToGet = World.CreateVehicle(this.RequestModel(VehicleHash.Chernobog), new Vector3(-725.8947f, 2657.424f, 57.24f));
          this.VehicleToGet.Heading = -167f;
          this.VehicleToGet.PlaceOnGround();
          this.VehicleToGet.IsInvincible = true;
          this.GotVehicle = true;
          this.MillitaryAsset = World.CreateBlip(this.VehicleToGet.Position);
          this.MillitaryAsset.Sprite = BlipSprite.Chernobog;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.MillitaryAsset, (InputArgument) 7);
          this.MillitaryAsset.Name = "Retrieve vehicle";
          this.MillitaryAsset.IsShortRange = true;
          UI.Notify(this.GetHostName() + " Ok retrieve this millitary asset, and you can buy and modify it for use");
          this.SourcingMissionOn = true;
          System.Random random = new System.Random();
          int num = random.Next(3, 12);
          for (int index1 = 0; index1 < num; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Armymech01SMY, this.MillitaryAsset.Position.Around((float) random.Next(3, 10)));
            ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            ped.RelationshipGroup = 5;
            ped.IsEnemy = true;
            this.SourcingmissionPeds.Add(ped);
            ped.Task.WanderAround(ped.Position, 15f);
          }
        }
        if (item == Deluxo)
        {
          foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
          {
            if ((Entity) sourcingmissionPed != (Entity) null)
              sourcingmissionPed.Delete();
          }
          if (this.SourcingmissionPeds.Count > 0)
            this.SourcingmissionPeds.Clear();
          if ((Entity) this.VehicleToGet != (Entity) null)
            this.VehicleToGet.Delete();
          if (this.MillitaryAsset != (Blip) null)
            this.MillitaryAsset.Remove();
          this.VehicleToGet = World.CreateVehicle(this.RequestModel(VehicleHash.Deluxo), new Vector3(-1913.971f, 2055.713f, 140f));
          this.VehicleToGet.Heading = -166f;
          this.VehicleToGet.PlaceOnGround();
          this.VehicleToGet.IsInvincible = true;
          this.GotVehicle = true;
          this.MillitaryAsset = World.CreateBlip(this.VehicleToGet.Position);
          this.MillitaryAsset.Sprite = BlipSprite.Deluxo;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.MillitaryAsset, (InputArgument) 7);
          this.MillitaryAsset.Name = "Retrieve vehicle";
          this.MillitaryAsset.IsShortRange = true;
          UI.Notify(this.GetHostName() + " Ok retrieve this millitary asset, and you can buy and modify it for use");
          this.SourcingMissionOn = true;
          System.Random random = new System.Random();
          int num = random.Next(3, 12);
          for (int index1 = 0; index1 < num; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Armymech01SMY, this.MillitaryAsset.Position.Around((float) random.Next(3, 10)));
            ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            ped.RelationshipGroup = 5;
            ped.IsEnemy = true;
            this.SourcingmissionPeds.Add(ped);
            ped.Task.WanderAround(ped.Position, 15f);
          }
        }
        if (item == Stromberg)
        {
          foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
          {
            if ((Entity) sourcingmissionPed != (Entity) null)
              sourcingmissionPed.Delete();
          }
          if (this.SourcingmissionPeds.Count > 0)
            this.SourcingmissionPeds.Clear();
          if ((Entity) this.VehicleToGet != (Entity) null)
            this.VehicleToGet.Delete();
          if (this.MillitaryAsset != (Blip) null)
            this.MillitaryAsset.Remove();
          this.VehicleToGet = World.CreateVehicle(this.RequestModel(VehicleHash.Stromberg), new Vector3(-2106.521f, 4578.142f, 1.74f));
          this.VehicleToGet.Heading = 94f;
          this.VehicleToGet.PlaceOnGround();
          this.VehicleToGet.IsInvincible = true;
          this.GotVehicle = true;
          this.MillitaryAsset = World.CreateBlip(this.VehicleToGet.Position);
          this.MillitaryAsset.Sprite = BlipSprite.Stromberg;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.MillitaryAsset, (InputArgument) 7);
          this.MillitaryAsset.Name = "Retrieve vehicle";
          this.MillitaryAsset.IsShortRange = true;
          UI.Notify(this.GetHostName() + " Ok retrieve this millitary asset, and you can buy and modify it for use");
          this.SourcingMissionOn = true;
          System.Random random = new System.Random();
          int num = random.Next(3, 12);
          for (int index1 = 0; index1 < num; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Armymech01SMY, this.MillitaryAsset.Position.Around((float) random.Next(3, 10)));
            ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            ped.RelationshipGroup = 5;
            ped.IsEnemy = true;
            this.SourcingmissionPeds.Add(ped);
          }
        }
        if (item == Avenger)
        {
          foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
          {
            if ((Entity) sourcingmissionPed != (Entity) null)
              sourcingmissionPed.Delete();
          }
          if (this.SourcingmissionPeds.Count > 0)
            this.SourcingmissionPeds.Clear();
          if ((Entity) this.VehicleToGet != (Entity) null)
            this.VehicleToGet.Delete();
          if (this.MillitaryAsset != (Blip) null)
            this.MillitaryAsset.Remove();
          this.VehicleToGet = World.CreateVehicle(this.RequestModel(VehicleHash.Avenger), new Vector3(3042.899f, -4698.106f, 16.908f));
          this.VehicleToGet.Heading = 14f;
          this.VehicleToGet.IsInvincible = true;
          this.GotVehicle = true;
          this.MillitaryAsset = World.CreateBlip(this.VehicleToGet.Position);
          this.MillitaryAsset.Sprite = BlipSprite.Avenger;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.MillitaryAsset, (InputArgument) 7);
          this.MillitaryAsset.Name = "Retrieve vehicle";
          this.MillitaryAsset.IsShortRange = true;
          UI.Notify(this.GetHostName() + " Ok retrieve this millitary asset, and you can buy and modify it for use");
          this.SourcingMissionOn = true;
          System.Random random = new System.Random();
          int num = random.Next(3, 12);
          for (int index1 = 0; index1 < num; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Armymech01SMY, this.MillitaryAsset.Position.Around((float) random.Next(3, 10)));
            ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            ped.RelationshipGroup = 5;
            ped.IsEnemy = true;
            this.SourcingmissionPeds.Add(ped);
            ped.Task.WanderAround(ped.Position, 15f);
          }
        }
        if (item == Akula)
        {
          foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
          {
            if ((Entity) sourcingmissionPed != (Entity) null)
              sourcingmissionPed.Delete();
          }
          if (this.SourcingmissionPeds.Count > 0)
            this.SourcingmissionPeds.Clear();
          if ((Entity) this.VehicleToGet != (Entity) null)
            this.VehicleToGet.Delete();
          if (this.MillitaryAsset != (Blip) null)
            this.MillitaryAsset.Remove();
          this.VehicleToGet = World.CreateVehicle(this.RequestModel(VehicleHash.Avenger), new Vector3(-1826.006f, 2974.195f, 33.93f));
          this.VehicleToGet.Heading = 71f;
          this.VehicleToGet.PlaceOnGround();
          this.VehicleToGet.IsInvincible = true;
          this.GotVehicle = true;
          this.MillitaryAsset = World.CreateBlip(this.VehicleToGet.Position);
          this.MillitaryAsset.Sprite = BlipSprite.Akula;
          Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.MillitaryAsset, (InputArgument) 7);
          this.MillitaryAsset.Name = "Retrieve vehicle";
          this.MillitaryAsset.IsShortRange = true;
          UI.Notify(this.GetHostName() + " Ok retrieve this millitary asset, and you can buy and modify it for use");
          this.SourcingMissionOn = true;
          System.Random random = new System.Random();
          int num = random.Next(3, 12);
          for (int index1 = 0; index1 < num; ++index1)
          {
            Ped ped = World.CreatePed((Model) PedHash.Armymech01SMY, this.MillitaryAsset.Position.Around((float) random.Next(3, 10)));
            ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
            ped.RelationshipGroup = 5;
            ped.IsEnemy = true;
            this.SourcingmissionPeds.Add(ped);
            ped.Task.WanderAround(ped.Position, 15f);
          }
        }
        if (item != Thruster)
          return;
        foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
        {
          if ((Entity) sourcingmissionPed != (Entity) null)
            sourcingmissionPed.Delete();
        }
        if (this.SourcingmissionPeds.Count > 0)
          this.SourcingmissionPeds.Clear();
        if ((Entity) this.VehicleToGet != (Entity) null)
          this.VehicleToGet.Delete();
        if (this.MillitaryAsset != (Blip) null)
          this.MillitaryAsset.Remove();
        this.VehicleToGet = World.CreateVehicle(this.RequestModel(VehicleHash.Thruster), new Vector3(-1949.664f, 3324.734f, 32.8f));
        this.VehicleToGet.Heading = 56f;
        this.VehicleToGet.PlaceOnGround();
        this.VehicleToGet.IsInvincible = true;
        this.GotVehicle = true;
        this.MillitaryAsset = World.CreateBlip(this.VehicleToGet.Position);
        this.MillitaryAsset.Sprite = BlipSprite.Thruster;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.MillitaryAsset, (InputArgument) 7);
        this.MillitaryAsset.Name = "Retrieve vehicle";
        this.MillitaryAsset.IsShortRange = true;
        UI.Notify(this.GetHostName() + " Ok retrieve this millitary asset, and you can buy and modify it for use");
        this.SourcingMissionOn = true;
        System.Random random1 = new System.Random();
        int num1 = random1.Next(3, 12);
        for (int index1 = 0; index1 < num1; ++index1)
        {
          Ped ped = World.CreatePed((Model) PedHash.Armymech01SMY, this.MillitaryAsset.Position.Around((float) random1.Next(3, 10)));
          ped.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
          ped.RelationshipGroup = 5;
          ped.IsEnemy = true;
          this.SourcingmissionPeds.Add(ped);
          ped.Task.WanderAround(ped.Position, 15f);
        }
      });
    }

    public void SetupCustomisation()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Extras, "Extra Additions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem GunLocker = new UIMenuItem("Gun Locker : $1,000,000");
      uiMenu.AddItem(GunLocker);
      UIMenuItem VehicleBay = new UIMenuItem("Vehicle Bay: $1,250,000");
      uiMenu.AddItem(VehicleBay);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == GunLocker)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
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
        }
        if (item != VehicleBay)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
        if (this.Config.GetValue<int>("EXTRA", "VEHICLEBAYBOUGHT", this.VehicleBayBought) == 0)
        {
          if (Game.Player.Money >= 1250000)
          {
            Game.Player.Money -= 1250000;
            this.VehicleBayBought = 1;
            this.Config.SetValue<int>("EXTRA", "VEHICLEBAYBOUGHT", this.VehicleBayBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You Dont Have Enought Money For a vehicle storage bay");
        }
        else
          UI.Notify(this.GetHostName() + " Sorry boss you have allready bought this upgrade");
      });
    }

    private void SetupGarage()
    {
      string path = "scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//";
      List<object> objectList = new List<object>()
      {
        (object) "False",
        (object) "True"
      };
      List<object> garage = new List<object>();
      garage.Add((object) "PersonalStorage");
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1");
      Slots.Add((object) "Slot2");
      Slots.Add((object) "Slot3");
      Slots.Add((object) "Slot4");
      Slots.Add((object) "Slot5");
      Slots.Add((object) "Slot6");
      Slots.Add((object) "Slot7");
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.GarageMenu, "Enter Garage");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem g = new UIMenuListItem("Garage : ", garage, 0);
      uiMenu.AddItem((UIMenuItem) g);
      UIMenuListItem s = new UIMenuListItem("Slot : ", Slots, 0);
      uiMenu.AddItem((UIMenuItem) s);
      UIMenuItem CarinSlot = new UIMenuItem("Car : ");
      uiMenu.AddItem(CarinSlot);
      UIMenuItem Set = new UIMenuItem("Save Current Car");
      uiMenu.AddItem(Set);
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == g)
        {
          this.SC.LoadIniFile(path + g.IndexToItem(g.Index)?.ToString() + "//" + s.IndexToItem(s.Index)?.ToString() + ".ini");
          if (!this.SC.VehicleName.Equals("null"))
            CarinSlot.Text = this.SC.VehicleName;
          else if (this.SC.VehicleName.Equals("null"))
            CarinSlot.Text = "No car in slot";
        }
        if (item != s)
          return;
        this.SC.LoadIniFile(path + g.IndexToItem(g.Index)?.ToString() + "//" + s.IndexToItem(s.Index)?.ToString() + ".ini");
        if (!this.SC.VehicleName.Equals("null"))
          CarinSlot.Text = this.SC.VehicleName;
        else if (this.SC.VehicleName.Equals("null"))
          CarinSlot.Text = "No car in slot";
      });
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Set)
          return;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__336.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__336.\u003C\u003Ep__0 = CallSite<Action<CallSite, Class1, object, Vehicle, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "SaveLocalcar", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Class1.\u003C\u003Eo__336.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__336.\u003C\u003Ep__0, this, garage[g.Index], this.Vehicle1, Slots[s.Index]);
      });
    }

    public void RemoveCar()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Remove Vehicle");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Slot1A = new UIMenuItem("Slot 1");
      uiMenu.AddItem(Slot1A);
      UIMenuItem Slot2A = new UIMenuItem("Slot 2");
      uiMenu.AddItem(Slot2A);
      UIMenuItem Slot3A = new UIMenuItem("Slot 3");
      uiMenu.AddItem(Slot3A);
      UIMenuItem Slot4A = new UIMenuItem("Slot 4");
      uiMenu.AddItem(Slot4A);
      UIMenuItem Slot5A = new UIMenuItem("Slot 5");
      uiMenu.AddItem(Slot5A);
      UIMenuItem Slot6A = new UIMenuItem("Slot 6");
      uiMenu.AddItem(Slot6A);
      UIMenuItem Slot7A = new UIMenuItem("Slot 7");
      uiMenu.AddItem(Slot7A);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
        if (item != Slot7A || !((Entity) this.Vehicle7 != (Entity) null))
          return;
        this.DeleteCarinSlot("Slot7", this.Vehicle7);
      });
    }

    public void SpawnVehicles()
    {
      try
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
        if (this.VehicleBayBought == 1)
        {
          if (this.ChernobogBought == 1)
          {
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Chernobog.ini");
            this.ChernobogV = World.CreateVehicle(this.RequestModel(VehicleHash.Chernobog), this.ChernobogPos, 180f);
            this.SC.Load(this.ChernobogV);
            if ((Entity) this.ChernobogV != (Entity) null)
              this.ChernobogV.IsInvincible = true;
          }
          if (this.ThrusterBought == 1)
          {
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Thruster.ini");
            this.ThrusterV = World.CreateVehicle(this.RequestModel(VehicleHash.Thruster), this.ThrusterPos, 90f);
            this.SC.Load(this.ThrusterV);
            if ((Entity) this.ThrusterV != (Entity) null)
              this.ThrusterV.IsInvincible = true;
          }
          if (this.KhanjaliBought == 1)
          {
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Khanjali.ini");
            this.KhanjalIV = World.CreateVehicle(this.RequestModel(VehicleHash.Khanjari), this.KhanjalIpos, 170f);
            this.SC.Load(this.KhanjalIV);
            if ((Entity) this.KhanjalIV != (Entity) null)
              this.KhanjalIV.IsInvincible = true;
          }
          if (this.AvengerBought == 1)
          {
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Avenger.ini");
            this.AvengerV = World.CreateVehicle(this.RequestModel(VehicleHash.Avenger), this.Avengerpos, 0.0f);
            this.SC.Load(this.AvengerV);
            if ((Entity) this.AvengerV != (Entity) null)
              this.AvengerV.IsInvincible = true;
          }
          if (this.AkulaBought == 1)
          {
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Akula.ini");
            this.AkulaV = World.CreateVehicle(this.RequestModel(VehicleHash.Akula), this.Akulapos, -166f);
            this.SC.Load(this.AkulaV);
            if ((Entity) this.AkulaV != (Entity) null)
              this.AkulaV.IsInvincible = true;
          }
          if (this.StrombergBought == 1)
          {
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Stromberg.ini");
            this.StrombergV = World.CreateVehicle(this.RequestModel(VehicleHash.Stromberg), this.Strombergpos, -90f);
            this.SC.Load(this.StrombergV);
            if ((Entity) this.BarrageV != (Entity) null)
              this.BarrageV.IsInvincible = true;
          }
          if (this.DeluxoBought == 1)
          {
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Deluxo.ini");
            this.DeluxoV = World.CreateVehicle(this.RequestModel(VehicleHash.Deluxo), this.Deluxopos, -90f);
            this.SC.Load(this.DeluxoV);
            if ((Entity) this.DeluxoV != (Entity) null)
              this.DeluxoV.IsInvincible = true;
          }
          if (this.BarrageBought == 1)
          {
            this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Barrage.ini");
            this.BarrageV = World.CreateVehicle(this.RequestModel(VehicleHash.Barrage), this.Barragepos, 200f);
            this.SC.Load(this.BarrageV);
            if ((Entity) this.BarrageV != (Entity) null)
              this.BarrageV.IsInvincible = true;
          }
        }
      }
      catch (NullReferenceException ex)
      {
      }
      try
      {
        string str1 = "scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//";
        string str2 = "PersonalStorage";
        this.SC.LoadIniFile(str1 + str2 + "//Slot1.ini");
        Model model1 = this.SC.CheckCar(str1 + str2 + "//Slot1.ini");
        this.SC.LoadIniFile(str1 + str2 + "//Slot2.ini");
        Model model2 = this.SC.CheckCar(str1 + str2 + "//Slot2.ini");
        this.SC.LoadIniFile(str1 + str2 + "//Slot3.ini");
        Model model3 = this.SC.CheckCar(str1 + str2 + "//Slot3.ini");
        this.SC.LoadIniFile(str1 + str2 + "//Slot4.ini");
        Model model4 = this.SC.CheckCar(str1 + str2 + "//Slot4.ini");
        this.SC.LoadIniFile(str1 + str2 + "//Slot5.ini");
        Model model5 = this.SC.CheckCar(str1 + str2 + "//Slot5.ini");
        this.SC.LoadIniFile(str1 + str2 + "//Slot6.ini");
        Model model6 = this.SC.CheckCar(str1 + str2 + "//Slot6.ini");
        this.SC.LoadIniFile(str1 + str2 + "//Slot7.ini");
        Model model7 = this.SC.CheckCar(str1 + str2 + "//Slot7.ini");
        if (model1 != (Model) "null" && model1 != (Model) (string) null)
        {
          this.SC.LoadIniFile(str1 + str2 + "//Slot1.ini");
          this.Vehicle1 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(str1 + str2 + "//Slot1.ini")), this.Vehicle1Loc, -148f);
          this.SC.Load(this.Vehicle1);
          this.Vehicle1.IsDriveable = false;
        }
        if (model2 != (Model) "null" && model2 != (Model) (string) null)
        {
          this.SC.LoadIniFile(str1 + str2 + "//Slot2.ini");
          this.Vehicle2 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(str1 + str2 + "//Slot2.ini")), this.Vehicle2Loc, -137f);
          this.SC.Load(this.Vehicle2);
          this.Vehicle2.IsDriveable = false;
        }
        if (model3 != (Model) "null" && model3 != (Model) (string) null)
        {
          this.SC.LoadIniFile(str1 + str2 + "//Slot3.ini");
          this.Vehicle3 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(str1 + str2 + "//Slot3.ini")), this.Vehicle3Loc, -119f);
          this.SC.Load(this.Vehicle3);
          this.Vehicle3.IsDriveable = false;
        }
        if (model4 != (Model) "null" && model4 != (Model) (string) null)
        {
          this.SC.LoadIniFile(str1 + str2 + "//Slot4.ini");
          this.Vehicle4 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(str1 + str2 + "//Slot4.ini")), this.Vehicle4Loc, -112f);
          this.SC.Load(this.Vehicle4);
          this.Vehicle4.IsDriveable = false;
        }
        if (model5 != (Model) "null" && model5 != (Model) (string) null)
        {
          this.SC.LoadIniFile(str1 + str2 + "//Slot5.ini");
          this.Vehicle5 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(str1 + str2 + "//Slot5.ini")), this.Vehicle5Loc, -178f);
          this.SC.Load(this.Vehicle5);
          this.Vehicle5.IsDriveable = false;
        }
        if (model6 != (Model) "null" && model6 != (Model) (string) null)
        {
          this.SC.LoadIniFile(str1 + str2 + "//Slot6.ini");
          this.Vehicle6 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(str1 + str2 + "//Slot6.ini")), this.Vehicle6Loc, 162f);
          this.SC.Load(this.Vehicle6);
          this.Vehicle6.IsDriveable = false;
        }
        if (!(model7 != (Model) "null") || !(model7 != (Model) (string) null))
          return;
        this.SC.LoadIniFile(str1 + str2 + "//Slot7.ini");
        this.Vehicle7 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(str1 + str2 + "//Slot7.ini")), this.Vehicle7Loc, 151f);
        this.SC.Load(this.Vehicle7);
        this.Vehicle7.IsDriveable = false;
      }
      catch (NullReferenceException ex)
      {
        UI.Notify("~r~Doomsday Heist Business : somthing has gone wrong while spawning Player Stored Vehicles, please exit facility and re-enter ~w~");
      }
    }

    public void SaveLocalcar(string G, Vehicle V, string Slot)
    {
      string str1 = "scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//";
      string str2 = "PersonalStorage";
      if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        if (Game.Player.Character.CurrentVehicle.DisplayName != "RHINO" || Game.Player.Character.CurrentVehicle.DisplayName != "KHANJALI" || Game.Player.Character.CurrentVehicle.DisplayName != "CHERNOBOG")
        {
          string str3 = G;
          str2 = G;
          UI.Notify(str1 + str3 + "//" + Slot + ".ini");
          this.SC.LoadIniFile(str1 + str3 + "//" + Slot + ".ini");
          this.SC.VehicleName = "null";
          Script.Wait(50);
          this.SC.SaveWithoutDelete();
          Script.Wait(50);
          V = Game.Player.Character.CurrentVehicle;
          Script.Wait(50);
          UI.Notify(this.GetHostName() + " your " + V.FriendlyName + ", has been Saved into the Facility");
          Script.Wait(50);
          this.SC.Save();
        }
        else
          this.DisplayHelpTextThisFrame("You cannot save this vehicle");
      }
      else
        this.DisplayHelpTextThisFrame("Bring a vehicle to save");
    }

    public void DeleteCarinSlot(string Slot, Vehicle V)
    {
      string str1 = "scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//";
      string str2 = "PersonalStorage";
      this.SC.LoadIniFile(str1 + str2 + "//" + Slot + ".ini");
      UI.Notify(str1 + str2 + "//" + Slot + ".ini");
      this.SC.SaveName();
      V.Delete();
    }

    public void DeleteVehicles()
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
      if ((Entity) this.ThrusterV != (Entity) null)
        this.ThrusterV.Delete();
      if ((Entity) this.ChernobogV != (Entity) null)
        this.ChernobogV.Delete();
      if ((Entity) this.KhanjalIV != (Entity) null)
        this.KhanjalIV.Delete();
      if ((Entity) this.AvengerV != (Entity) null)
        this.AvengerV.Delete();
      if ((Entity) this.AkulaV != (Entity) null)
        this.AkulaV.Delete();
      if ((Entity) this.BarrageV != (Entity) null)
        this.BarrageV.Delete();
      if ((Entity) this.StrombergV != (Entity) null)
        this.StrombergV.Delete();
      if ((Entity) this.DeluxoV != (Entity) null)
        this.DeluxoV.Delete();
      if ((Entity) this.Agent14 != (Entity) null)
        this.Agent14.Delete();
      if (!((Entity) this.Lester != (Entity) null))
        return;
      this.Lester.Delete();
    }

    public void LoadCarinToRealWorld(Vehicle V)
    {
      if ((Entity) this.VehicleInUse != (Entity) null)
        this.VehicleInuse.Delete();
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      this.isInInterior = false;
      currentVehicle.Position = this.OutsideSpawn;
      Game.Player.Character.SetIntoVehicle(currentVehicle, VehicleSeat.Driver);
      currentVehicle.IsDriveable = true;
      currentVehicle.Rotation = new Vector3(0.0f, 0.0f, -12f);
      currentVehicle.IsDriveable = true;
      currentVehicle.Repair();
      this.VehicleInuse = currentVehicle;
      this.DeleteVehicles();
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

    private void FireMissile(Vector3 Source, Ped Owner)
    {
      Model model = (Model) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "WEAPON_HOMINGLAUNCHER");
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
      Script.Wait(200);
      World.ShootBullet(Source, Game.Player.Character.Position, Owner, model, 15000);
      Script.Wait(600);
      World.ShootBullet(Source, Game.Player.Character.Position, Owner, model, 15000);
      Script.Wait(600);
      World.ShootBullet(Source, Game.Player.Character.Position, Owner, model, 15000);
      Script.Wait(600);
      World.ShootBullet(Source, Game.Player.Character.Position, Owner, model, 15000);
      Script.Wait(600);
      World.ShootBullet(Source, Game.Player.Character.Position, Owner, model, 15000);
      Script.Wait(1000);
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if ((Entity) this.VehicleToGet != (Entity) null)
        this.VehicleToGet.Delete();
      if (this.MillitaryAsset != (Blip) null)
        this.MillitaryAsset.Remove();
      foreach (Ped sourcingmissionPed in this.SourcingmissionPeds)
      {
        if ((Entity) sourcingmissionPed != (Entity) null)
          sourcingmissionPed.Delete();
      }
      if ((Entity) this.SamArray1 != (Entity) null)
        this.SamArray1.Delete();
      if ((Entity) this.SamArray2 != (Entity) null)
        this.SamArray2.Delete();
      if ((Entity) this.SamArray3 != (Entity) null)
        this.SamArray3.Delete();
      if ((Entity) this.SamArray4 != (Entity) null)
        this.SamArray4.Delete();
      if ((Entity) this.SamArray5 != (Entity) null)
        this.SamArray5.Delete();
      if ((Entity) this.SamArray6 != (Entity) null)
        this.SamArray6.Delete();
      if ((Entity) this.SamArray7 != (Entity) null)
        this.SamArray7.Delete();
      if ((Entity) this.KeyPad != (Entity) null)
        this.KeyPad.Delete();
      foreach (Prop prop in this.PrivacyGlass)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      try
      {
        if (this.Range != (Blip) null)
          this.Range.Remove();
        if (this.CannonCamera != (Camera) null)
        {
          this.StopScreenEffectsORBITALCANNON();
          Game.Player.WantedLevel = 0;
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.Position = this.OrbitalCannonPos;
          Game.Player.Character.FreezePosition = false;
        }
        if ((Entity) this.LDoor != (Entity) null)
          this.LDoor.Delete();
        if ((Entity) this.RDoor != (Entity) null)
          this.RDoor.Delete();
        if ((Entity) this.EnterProp != (Entity) null)
          this.EnterProp.Delete();
        foreach (Prop chair in this.Chairs)
        {
          if ((Entity) chair != (Entity) null)
            chair.Delete();
        }
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        foreach (Prop riProp in this.RIProps)
        {
          if ((Entity) riProp != (Entity) null)
            riProp.Delete();
        }
        foreach (Ped riPed in this.RIPeds)
        {
          if ((Entity) riPed != (Entity) null)
            riPed.Delete();
        }
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
      foreach (Ped guard in this.Guards)
      {
        if ((Entity) guard != (Entity) null)
          guard.Delete();
      }
      foreach (Vehicle dinghy in this.Dinghys)
      {
        if ((Entity) dinghy != (Entity) null)
          dinghy.Delete();
      }
      foreach (Vehicle vehicle in this.Truck_Trailer)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      foreach (Vehicle vehicle in this.CaptureVehicle)
      {
        if ((Entity) vehicle != (Entity) null)
        {
          if ((Entity) vehicle.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
            vehicle.GetPedOnSeat(VehicleSeat.Driver).Delete();
          if ((Entity) vehicle.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
            vehicle.GetPedOnSeat(VehicleSeat.Driver).Delete();
          vehicle.Delete();
        }
      }
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.SamPoints.Count > 0)
        this.SamPoints.Clear();
      foreach (Blip samBip in this.SamBips)
      {
        if (samBip != (Blip) null)
          samBip.Remove();
      }
      if ((Entity) this.ChairProp != (Entity) null)
        this.ChairProp.Delete();
      if ((Entity) this.VehicleInUse != (Entity) null)
        this.VehicleInuse.IsPersistent = false;
      this.StopScreenEffects();
      foreach (Prop prop in this.OSHatch)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
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
      foreach (Ped guard in this.Guards)
      {
        if ((Entity) guard != (Entity) null)
          guard.Delete();
      }
      foreach (Vehicle dinghy in this.Dinghys)
      {
        if ((Entity) dinghy != (Entity) null)
          dinghy.Delete();
      }
      foreach (Vehicle vehicle in this.Truck_Trailer)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      foreach (Vehicle vehicle in this.CaptureVehicle)
      {
        if ((Entity) vehicle != (Entity) null)
        {
          if ((Entity) vehicle.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
            vehicle.GetPedOnSeat(VehicleSeat.Driver).Delete();
          if ((Entity) vehicle.GetPedOnSeat(VehicleSeat.Driver) != (Entity) null)
            vehicle.GetPedOnSeat(VehicleSeat.Driver).Delete();
          vehicle.Delete();
        }
      }
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.SamPoints.Count > 0)
        this.SamPoints.Clear();
      foreach (Blip samBip in this.SamBips)
      {
        if (samBip != (Blip) null)
          samBip.Remove();
      }
      if (this.Facility != (Blip) null)
        this.Facility.Remove();
      if ((Entity) this.ThrusterV != (Entity) null)
        this.ThrusterV.Delete();
      if ((Entity) this.ChernobogV != (Entity) null)
        this.ChernobogV.Delete();
      if ((Entity) this.KhanjalIV != (Entity) null)
        this.KhanjalIV.Delete();
      if ((Entity) this.AvengerV != (Entity) null)
        this.AvengerV.Delete();
      if ((Entity) this.AkulaV != (Entity) null)
        this.AkulaV.Delete();
      if ((Entity) this.BarrageV != (Entity) null)
        this.BarrageV.Delete();
      if ((Entity) this.StrombergV != (Entity) null)
        this.StrombergV.Delete();
      if ((Entity) this.DeluxoV != (Entity) null)
        this.DeluxoV.Delete();
      if ((Entity) this.Agent14 != (Entity) null)
        this.Agent14.Delete();
      if ((Entity) this.Lester != (Entity) null)
        this.Lester.Delete();
      if ((Entity) this.VtoGet != (Entity) null)
        this.VtoGet.Delete();
      if (this.VtoGetBlip != (Blip) null)
        this.VtoGetBlip.Remove();
    }

    public void StartScreenEffectORBITALCANNON()
    {
      Function.Call(Hash._0xA0EBB943C300E693, (InputArgument) false);
      Function.Call(Hash._0xA6294919E56FF02A, (InputArgument) false);
      Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "OrbitalCannon");
      Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) 0.8f);
      Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "OrbitalCannon", (InputArgument) 0.8f);
    }

    public void StopScreenEffectsORBITALCANNON()
    {
      Function.Call(Hash._0xA0EBB943C300E693, (InputArgument) true);
      Function.Call(Hash._0xA6294919E56FF02A, (InputArgument) true);
      Function.Call(Hash._0x0F07E7745A236711);
      Function.Call(Hash._0x3C8938D7D872211E);
      Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "default");
    }

    public void StartScreenEffect()
    {
      Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "MP_job_load");
      Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) 1.15f);
      Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "MP_job_load", (InputArgument) 0.8f);
    }

    public void StopScreenEffects()
    {
      Function.Call(Hash._0x0F07E7745A236711);
      Function.Call(Hash._0x3C8938D7D872211E);
      Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "default");
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
      this.CheckHostName("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
      this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      string str = "~" + this.Uicolour + "~";
      return this.HostName;
    }

    public int DrawFIBHack(string amt)
    {
      this.iLocal_8077 = Function.Call<int>(Hash._0xC514489CFB8AF806, (InputArgument) "MORGUE_LAPTOP");
      if (!Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.iLocal_8077))
        return 0;
      Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) amt, (InputArgument) "SET_PROGRESS_PERCENT");
      Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) 0);
      Function.Call(Hash._0xC6796A8FFA375E53);
      return 1;
    }

    public void SetupPeds()
    {
    }

    private void DeleteBScreen()
    {
      if (Function.Call<bool>(Hash._0x78DCDC15C9F116B4, (InputArgument) "Prop_x17DLC_Monitor_Wall_01a"))
        Function.Call(Hash._0xE9F6FFE837354DD4, (InputArgument) "Prop_x17DLC_Monitor_Wall_01a");
      for (int index = 0; index < 24; ++index)
      {
        if (Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) this.ScreenGUITex))
          Function.Call(Hash._0xBE2CACCF5A8AA805, (InputArgument) this.ScreenGUITex);
      }
    }

    private void DeleteBScreen1()
    {
      if (!this.CleanUpBigScreen)
        return;
      Ped character = Game.Player.Character;
      Vector3 position = Game.Player.Character.Position;
      if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) == 0)
      {
        if (!Function.Call<bool>(Hash._0x78DCDC15C9F116B4, (InputArgument) "Prop_x17DLC_Monitor_Wall_01a"))
          Function.Call(Hash._0xE9F6FFE837354DD4, (InputArgument) "Prop_x17DLC_Monitor_Wall_01a");
        for (int index = 0; index < 24; ++index)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) this.ScreenGUITex))
            Function.Call(Hash._0xBE2CACCF5A8AA805, (InputArgument) this.ScreenGUITex);
        }
        this.CleanUpBigScreen = false;
      }
    }

    private void CreateBScreen(string texture, string id)
    {
      switch (this.BigStage)
      {
        case 0:
          this.DeleteBScreen();
          this.BigStage = 1;
          break;
        case 1:
          if (!Function.Call<bool>(Hash._0x78DCDC15C9F116B4, (InputArgument) "Prop_x17DLC_Monitor_Wall_01a"))
          {
            Function.Call(Hash._0x57D9C12635E25CE3, (InputArgument) "Prop_x17DLC_Monitor_Wall_01a", (InputArgument) 0);
            Function.Call(Hash._0xF6C09E276AEB3F2D, (InputArgument) 1080309276);
            this.BigScreen = Function.Call<int>(Hash._0x1A6478B61C6BDC3B, (InputArgument) "Prop_x17DLC_Monitor_Wall_01a");
          }
          Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "CS_NHP_OVERLAY_GRID", (InputArgument) 0);
          Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) texture, (InputArgument) 0);
          Function.Call(Hash._0x5F15302936E07111, (InputArgument) this.BigScreen);
          Function.Call(Hash._0x61BB1D9B3A95D802, (InputArgument) 4);
          Function.Call(Hash._0xC6372ECD45D73BCD, (InputArgument) 1);
          Function.Call(Hash._0x3A618A217E5154F0, (InputArgument) 0.5f, (InputArgument) 0.5f, (InputArgument) 1f, (InputArgument) 1f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) (int) byte.MaxValue);
          if (Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) texture))
            Function.Call((Hash) 2868108930036635362, (InputArgument) texture, (InputArgument) id, (InputArgument) 0.5f, (InputArgument) 0.5f, (InputArgument) 1f, (InputArgument) 1f, (InputArgument) 0.0f, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);
          if (Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "CS_NHP_OVERLAY_GRID"))
            Function.Call((Hash) 2868108930036635362, (InputArgument) "CS_NHP_OVERLAY_GRID", (InputArgument) "OVERLAY_GRID", (InputArgument) 0.5f, (InputArgument) 0.5f, (InputArgument) 1f, (InputArgument) 1f, (InputArgument) 0.0f, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);
          Function.Call(Hash._0x5F15302936E07111, (InputArgument) Function.Call<int>(Hash._0x52F0982D7FD156B6));
          break;
      }
    }

    private Camera MainCamera => this._mainCamera;

    private unsafe void FireCannon(Vector3 camerapos)
    {
      float num = 0.0f;
      Function.Call(Hash._0xC906A7DAB05C8D2B, (InputArgument) camerapos.X, (InputArgument) camerapos.Y, (InputArgument) camerapos.Z, (InputArgument) &num, (InputArgument) 0, (InputArgument) 0);
      Vector3 vector3;
      Function.Call(Hash._0x8BDC7BFC57A81E76, (InputArgument) camerapos.X, (InputArgument) camerapos.Y, (InputArgument) camerapos.Z, (InputArgument) &num, (InputArgument) &vector3.X, (InputArgument) &vector3.Y, (InputArgument) &vector3.Z);
      for (int index = 0; index < 100; ++index)
      {
        System.Random random = new System.Random();
        camerapos.Around((float) random.Next(1, 35));
        Function.Call(Hash._0xE3AD2BDBAEE269AC, (InputArgument) camerapos.X, (InputArgument) camerapos.Y, (InputArgument) World.GetGroundHeight(this.MainCamera.Position), (InputArgument) 60, (InputArgument) 100f, (InputArgument) true, (InputArgument) 0, (InputArgument) 1f, (InputArgument) false);
      }
      Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_xm_orbital");
      Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_xm_orbital");
      Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_xm_orbital");
      Function.Call(Hash._0x25129531F77B9ED3, (InputArgument) "scr_xm_orbital_blast", (InputArgument) camerapos.X, (InputArgument) camerapos.Y, (InputArgument) num, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 2.3f, (InputArgument) false, (InputArgument) false, (InputArgument) false);
      Function.Call(Hash._0x8D8686B622B88120, (InputArgument) -1, (InputArgument) "DLC_XM_Explosions_Orbital_Cannon", (InputArgument) camerapos.X, (InputArgument) camerapos.Y, (InputArgument) num, (InputArgument) 0, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0);
    }

    private float func_68(int iParam0)
    {
      float num = 100f;
      switch (iParam0)
      {
        case 0:
          num = 90f;
          break;
        case 1:
          num = 60f;
          break;
        case 2:
          num = 50f;
          break;
        case 3:
          num = 25f;
          break;
        case 4:
          num = 10f;
          break;
        case 5:
          num = 10f;
          break;
      }
      return num;
    }

    private void zoomcalculator(int zoomid)
    {
      switch (zoomid)
      {
        case 0:
          this.zoomscale = 1f;
          this.camerazoom = 300f;
          break;
        case 1:
          this.zoomscale = 0.8f;
          this.camerazoom = 220f;
          break;
        case 2:
          this.zoomscale = 0.6f;
          this.camerazoom = 150f;
          break;
        case 3:
          this.zoomscale = 0.4f;
          this.camerazoom = 100f;
          break;
        case 4:
          this.zoomscale = 0.2f;
          this.camerazoom = 70f;
          break;
        case 5:
          this.zoomscale = 0.0f;
          this.camerazoom = 40f;
          break;
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

    public unsafe void OnTick(object sender, EventArgs e)
    {
      if (this.isInInterior)
      {
        if (Game.Player.Character.Weapons.Current != null && Game.Player.Character.Weapons.Current.Hash != WeaponHash.Unarmed)
        {
          this.DisplayHelpTextThisFrame("You cannot use weapons while inside your Facility");
          Game.Player.Character.Weapons.Select(WeaponHash.Unarmed, true);
        }
        if (Game.IsControlPressed(2, GTA.Control.SelectWeapon))
        {
          Game.DisableControlThisFrame(2, GTA.Control.SelectWeapon);
          this.DisplayHelpTextThisFrame("You cannot use weapons while inside your Facility");
        }
      }
      if (this.isInInterior)
      {
        this.ScreenGUITex = this.Texture[this.TextDicID];
        this.ScreenGUIDIC = this.Dicts[this.TextDicID];
        this.CreateBScreen(this.ScreenGUITex, this.ScreenGUIDIC);
      }
      if (!this.isInInterior)
        this.DeleteBScreen1();
      switch (this.ElevatorSwitch)
      {
        case 22:
          if (this.ElevatorLift)
          {
            foreach (Prop nearbyProp in World.GetNearbyProps(new Vector3(483.9225f, 4818.696f, -58.38285f), 10f, this.RequestModel("xm_prop_base_hanger_lift")))
            {
              nearbyProp.Position = new Vector3(nearbyProp.Position.X, nearbyProp.Position.Y, nearbyProp.Position.Z + 0.01f);
              if ((double) nearbyProp.Position.DistanceTo(new Vector3(481.2233f, 4809.238f, -47.8803f)) < 5.0)
              {
                World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
                if (this.GrabbedHatch)
                {
                  Vector3 currentHatch = this.CurrentHatch;
                  if (true)
                  {
                    Prop[] nearbyProps = World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
                    if ((uint) nearbyProps.Length > 0U)
                    {
                      foreach (Prop prop in nearbyProps)
                      {
                        this.CurrentHatch = prop.Position;
                        prop.HasCollision = false;
                        prop.IsVisible = false;
                      }
                    }
                  }
                }
                this.HatchOpen = false;
                this.HatchClosed = false;
                if (!this.GrabbedHatch)
                {
                  Prop[] nearbyProps1 = World.GetNearbyProps(Game.Player.Character.Position, 200f, this.RequestModel("xm_prop_x17_osphatch_27m"));
                  if ((uint) nearbyProps1.Length > 0U)
                  {
                    foreach (Prop prop1 in nearbyProps1)
                    {
                      this.CurrentHatch = prop1.Position;
                      Prop[] nearbyProps2 = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_x17_rig_osphatch"));
                      if ((uint) nearbyProps2.Length > 0U)
                      {
                        foreach (Entity entity in nearbyProps2)
                          entity.Delete();
                      }
                      Prop[] nearbyProps3 = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_out_hanger_lift"));
                      if ((uint) nearbyProps3.Length > 0U)
                      {
                        foreach (Entity entity in nearbyProps3)
                          entity.Delete();
                      }
                      foreach (Prop prop2 in this.OSHatch)
                      {
                        if ((Entity) prop2 != (Entity) null)
                          prop2.Delete();
                      }
                      this.HatchClosed = false;
                      this.HatchOpen = false;
                      prop1.HasCollision = false;
                      prop1.IsVisible = false;
                      if ((Entity) this.OSRig != (Entity) null)
                        this.OSRig.Delete();
                      if ((Entity) this.OShatchBase != (Entity) null)
                        this.OShatchBase.Delete();
                      this.OSRig = World.CreateProp(this.RequestModel("xm_prop_x17_rig_osphatch"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, -18.3f)), new Vector3(prop1.Rotation.X, prop1.Rotation.Y, prop1.Rotation.Z), false, false);
                      this.OSHatch.Add(this.OSRig);
                      this.OSRig.FreezePosition = true;
                      this.OShatchBase = World.CreateProp(this.RequestModel("xm_prop_out_hanger_lift"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 2.1f)), new Vector3(prop1.Rotation.X, prop1.Rotation.Y, prop1.Rotation.Z - 105f), false, false);
                      this.OSHatch.Add(this.OShatchBase);
                      this.OShatchBase.FreezePosition = true;
                      this.GrabbedHatch = true;
                    }
                  }
                }
                if (this.HatchClosed && (double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) > 150.0)
                {
                  if (!Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) this.OSRig, (InputArgument) "anim@amb@facility@hanger_doors", (InputArgument) "close", (InputArgument) 1))
                  {
                    Prop[] nearbyProps1 = World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
                    if ((uint) nearbyProps1.Length > 0U)
                    {
                      foreach (Prop prop1 in nearbyProps1)
                      {
                        this.GrabbedHatch = false;
                        this.StopScreenEffects();
                        Prop[] nearbyProps2 = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_x17_rig_osphatch"));
                        if ((uint) nearbyProps2.Length > 0U)
                        {
                          foreach (Entity entity in nearbyProps2)
                            entity.IsVisible = false;
                        }
                        Prop[] nearbyProps3 = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_out_hanger_lift"));
                        if ((uint) nearbyProps3.Length > 0U)
                        {
                          foreach (Entity entity in nearbyProps3)
                            entity.IsVisible = false;
                        }
                        foreach (Prop prop2 in this.OSHatch)
                        {
                          if ((Entity) prop2 != (Entity) null)
                            prop2.Delete();
                        }
                        prop1.Alpha = 0;
                      }
                    }
                  }
                }
                Vector3 currentHatch1 = this.CurrentHatch;
                if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) < 400.0)
                {
                  if (this.HatchOpen)
                  {
                    if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) > 40.0)
                      this.HatchClosed_final = true;
                    if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) > 30.0 && (!this.HatchClosed && !this.HatchClosed_final))
                    {
                      Prop[] nearbyProps = World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
                      if ((uint) nearbyProps.Length > 0U)
                      {
                        foreach (Prop prop in nearbyProps)
                        {
                          this.CurrentHatch = prop.Position;
                          prop.HasCollision = false;
                          prop.IsVisible = false;
                        }
                      }
                      this.HatchOpen = false;
                      if (!Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) this.OSRig, (InputArgument) Class1.LoadDict("anim@amb@facility@hanger_doors"), (InputArgument) "close", (InputArgument) 1))
                        Function.Call(Hash._0x7FB218262B810701, (InputArgument) this.OSRig, (InputArgument) "close", (InputArgument) Class1.LoadDict("anim@amb@facility@hanger_doors"), (InputArgument) 4f, (InputArgument) false, (InputArgument) true, (InputArgument) 0, (InputArgument) 0.0f, (InputArgument) 8);
                      this.HatchClosed_final = true;
                    }
                  }
                  if (this.HatchClosed_final && (double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) > 200.0)
                  {
                    this.HatchClosed_final = false;
                    Prop[] nearbyProps = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_out_hanger_lift"));
                    if ((uint) nearbyProps.Length > 0U)
                    {
                      foreach (Entity entity in nearbyProps)
                        entity.IsVisible = true;
                    }
                    this.HatchClosed = true;
                  }
                }
                Class1.LoadDict("anim@amb@facility@hanger_doors");
                Class1.LoadDict("anim@amb@facility@hanger_doors");
                Script.Wait(50);
                Function.Call(Hash._0x7FB218262B810701, (InputArgument) this.OSRig, (InputArgument) "open", (InputArgument) Class1.LoadDict("anim@amb@facility@hanger_doors"), (InputArgument) 4f, (InputArgument) false, (InputArgument) true, (InputArgument) 0, (InputArgument) 0.0f, (InputArgument) 8);
                this.ElevatorLift = false;
                this.ElevatorSwitch = 23;
              }
            }
            break;
          }
          break;
        case 23:
          Game.Player.Character.FreezePosition = true;
          Game.FadeScreenOut(600);
          Script.Wait(5000);
          Game.Player.Character.Position = this.Entry;
          Script.Wait(5000);
          Game.Player.Character.FreezePosition = false;
          Game.FadeScreenIn(300);
          World.RenderingCamera = (Camera) null;
          this.ElevatorSwitch = 24;
          break;
      }
      if (!this.SellStockDeliveryMission)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.Exit) < 200.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.Exit, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.Exit) < 3.0)
        {
          this.DisplayHelpTextThisFrame("Press  ~INPUT_CONTEXT~  Exit Facility");
          if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.isInInterior)
          {
            Game.FadeScreenOut(100);
            Script.Wait(300);
            this.DeleteVehicles();
            this.createdVehicles = false;
            Script.Wait(300);
            Game.FadeScreenIn(100);
            this.DeleteVehicles();
            Function.Call(Hash._0xB9EFD5C25018725A, (InputArgument) "WantedMusicDisabled", (InputArgument) true);
            Class1.LoadDict("anim@amb@facility@hangerdoors@base@enter_exit@group@lift");
            Class1.LoadDict("anim@amb@facility@hangerdoors@base@enter_exit@group@lift");
            Script.Wait(50);
            Function.Call(Hash._0xA0EBB943C300E693, (InputArgument) false);
            Camera camera = World.CreateCamera(new Vector3(488.7494f, 4826.692f, -57.75795f), new Vector3(-7.585561f, 0.0f, 153.6609f), 50f);
            World.RenderingCamera = camera;
            this.Elevator = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) 480.3726f, (InputArgument) 4814.9f, (InputArgument) -59.30285f, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 340.5327f, (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Elevator, (InputArgument) Class1.LoadDict("anim@amb@facility@hangerdoors@base@enter_exit@group@lift"), (InputArgument) "exit_a", (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) camera, (InputArgument) this.Elevator, (InputArgument) "exit_cam", (InputArgument) Class1.LoadDict("anim@amb@facility@hangerdoors@base@enter_exit@group@lift"), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
            Function.Call(Hash._0xE32EFE9AB4A9AA0C, (InputArgument) camera, (InputArgument) this.Elevator, (InputArgument) "exit_cam", (InputArgument) Class1.LoadDict("anim@amb@facility@hangerdoors@base@enter_exit@group@lift"), (InputArgument) 0.0, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 1148846080, (InputArgument) 0);
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Elevator, (InputArgument) "exit_a", (InputArgument) Class1.LoadDict("anim@amb@facility@hangerdoors@base@enter_exit@group@lift"), (InputArgument) 0.0, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 1148846080, (InputArgument) 0);
            Script.Wait(10000);
            Game.Player.Character.Task.ClearAll();
            this.ElevatorSwitch = 22;
            this.ElevatorLift = true;
          }
        }
      }
      if (!this.GotGlassBase1 && !this.GotGlassBase2 && !this.GotGlassBase3 && (double) World.GetDistance(Game.Player.Character.Position, new Vector3(366f, 4843f, -59f)) < 200.0)
      {
        Prop[] nearbyProps1 = World.GetNearbyProps(new Vector3(371.0457f, 4841.392f, -60.2f), 1f);
        Prop[] nearbyProps2 = World.GetNearbyProps(new Vector3(366.6028f, 4847.132f, -60.2f), 1f);
        Prop[] nearbyProps3 = World.GetNearbyProps(new Vector3(358.5805f, 4845.74f, -60.2f), 1f);
        if ((uint) nearbyProps1.Length > 0U)
        {
          foreach (Prop prop in nearbyProps1)
          {
            this.glass1 = prop;
            this.GotGlassBase1 = true;
          }
        }
        if ((uint) nearbyProps2.Length > 0U)
        {
          foreach (Prop prop in nearbyProps2)
          {
            this.glass2 = prop;
            this.GotGlassBase2 = true;
          }
        }
        if ((uint) nearbyProps3.Length > 0U)
        {
          foreach (Prop prop in nearbyProps3)
          {
            this.glass3 = prop;
            this.GotGlassBase3 = true;
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(366f, 4843f, -59f)) < 200.0 && (this.GotGlassBase1 && this.GotGlassBase2 && this.GotGlassBase3 && !this.GotPrivacyBase))
      {
        foreach (Prop prop in this.PrivacyGlass)
        {
          if ((Entity) prop != (Entity) null)
            prop.Delete();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
        if (this.PrivacyGlassBought == 1 && this.PrivacyGlassOn)
        {
          if ((Entity) this.glass1 != (Entity) null)
          {
            this.GotPrivacyBase = true;
            this.PrivacyGlass.Add(World.CreateProp(this.RequestModel("xm_prop_x17_l_glass_03"), this.glass1.Position, new Vector3(0.0f, 0.0f, this.glass1.Rotation.Z), false, false));
          }
          if ((Entity) this.glass2 != (Entity) null)
            this.PrivacyGlass.Add(World.CreateProp(this.RequestModel("xm_prop_x17_l_glass_02"), this.glass2.Position, new Vector3(0.0f, 0.0f, this.glass2.Rotation.Z), false, false));
          if ((Entity) this.glass3 != (Entity) null)
            this.PrivacyGlass.Add(World.CreateProp(this.RequestModel("xm_prop_x17_l_glass_01"), this.glass3.Position, new Vector3(0.0f, 0.0f, this.glass3.Rotation.Z), false, false));
          Prop[] nearbyProps = World.GetNearbyProps(new Vector3(366f, 4843f, -59f), 40f, this.RequestModel("xm_prop_x17_l_door_frame_01"));
          if ((uint) nearbyProps.Length > 0U)
          {
            foreach (Prop prop1 in nearbyProps)
            {
              Prop prop2 = World.CreateProp(this.RequestModel(-562735186), new Vector3(prop1.Position.X, prop1.Position.Y, prop1.Position.Z - 1f), new Vector3(0.0f, 0.0f, prop1.Rotation.Z), false, false);
              prop2.AttachTo((Entity) prop1, 0);
              this.PrivacyGlass.Add(prop2);
            }
          }
        }
      }
      if ((Entity) this.KeyPad != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.KeyPad.Position) < 1.25 && this.PrivacyGlassBought == 1)
      {
        if (this.PrivacyGlassOn)
          this.DisplayHelpTextThisFrame("Press  ~INPUT_CONTEXT~ to Turn Privacy Glass Off");
        if (!this.PrivacyGlassOn)
          this.DisplayHelpTextThisFrame("Press  ~INPUT_CONTEXT~ to Turn Privacy Glass On");
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
          if (this.PrivacyGlassOn)
          {
            this.PrivacyGlassOn = false;
            this.Config.SetValue<bool>("PrivacyGlass", "PrivacyGlassOn", this.PrivacyGlassOn);
            this.Config.Save();
            foreach (Prop prop in this.PrivacyGlass)
            {
              if ((Entity) prop != (Entity) null)
                prop.Delete();
            }
          }
          else if (!this.PrivacyGlassOn)
          {
            this.PrivacyGlassOn = true;
            this.Config.SetValue<bool>("PrivacyGlass", "PrivacyGlassOn", this.PrivacyGlassOn);
            this.Config.Save();
            foreach (Prop prop in this.PrivacyGlass)
            {
              if ((Entity) prop != (Entity) null)
                prop.Delete();
            }
            Prop[] nearbyProps1 = World.GetNearbyProps(new Vector3(371.0457f, 4841.392f, -60.2f), 1f);
            Prop[] nearbyProps2 = World.GetNearbyProps(new Vector3(366.6028f, 4847.132f, -60.2f), 1f);
            Prop[] nearbyProps3 = World.GetNearbyProps(new Vector3(358.5805f, 4845.74f, -60.2f), 1f);
            if ((uint) nearbyProps1.Length > 0U)
            {
              foreach (Prop prop in nearbyProps1)
              {
                this.glass1 = prop;
                this.GotGlassBase1 = true;
              }
            }
            if ((uint) nearbyProps2.Length > 0U)
            {
              foreach (Prop prop in nearbyProps2)
              {
                this.glass2 = prop;
                this.GotGlassBase2 = true;
              }
            }
            if ((uint) nearbyProps3.Length > 0U)
            {
              foreach (Prop prop in nearbyProps3)
              {
                this.glass3 = prop;
                this.GotGlassBase3 = true;
              }
            }
            if (this.GotGlassBase1 && this.GotGlassBase2 && this.GotGlassBase3)
            {
              this.GotPrivacyBase = true;
              foreach (Prop prop in this.PrivacyGlass)
              {
                if ((Entity) prop != (Entity) null)
                  prop.Delete();
              }
              if (this.PrivacyGlassBought == 1)
              {
                if ((Entity) this.glass1 != (Entity) null)
                  this.PrivacyGlass.Add(World.CreateProp(this.RequestModel("xm_prop_x17_l_glass_03"), this.glass1.Position, new Vector3(0.0f, 0.0f, this.glass1.Rotation.Z), false, false));
                if ((Entity) this.glass2 != (Entity) null)
                  this.PrivacyGlass.Add(World.CreateProp(this.RequestModel("xm_prop_x17_l_glass_02"), this.glass2.Position, new Vector3(0.0f, 0.0f, this.glass2.Rotation.Z), false, false));
                if ((Entity) this.glass3 != (Entity) null)
                  this.PrivacyGlass.Add(World.CreateProp(this.RequestModel("xm_prop_x17_l_glass_01"), this.glass3.Position, new Vector3(0.0f, 0.0f, this.glass3.Rotation.Z), false, false));
                Prop[] nearbyProps4 = World.GetNearbyProps(new Vector3(366f, 4843f, -59f), 40f, this.RequestModel("xm_prop_x17_l_door_frame_01"));
                if ((uint) nearbyProps4.Length > 0U)
                {
                  foreach (Prop prop1 in nearbyProps4)
                  {
                    Prop prop2 = World.CreateProp(this.RequestModel(-562735186), new Vector3(prop1.Position.X, prop1.Position.Y, prop1.Position.Z - 1f), new Vector3(0.0f, 0.0f, prop1.Rotation.Z), false, false);
                    prop2.AttachTo((Entity) prop1, 0);
                    this.PrivacyGlass.Add(prop2);
                  }
                }
              }
            }
          }
        }
      }
      if (!this.FirstTime)
      {
        if ((Entity) this.KeyPad != (Entity) null)
          this.KeyPad.Delete();
        this.KeyPad = World.CreateProp(this.RequestModel("vw_prop_casino_keypad_01"), new Vector3(370.6042f, 4845.772f, -58.9f), false, false);
        this.KeyPad.Heading = -13f;
        this.KeyPad.FreezePosition = true;
        if (this.PrivacyGlassBought == 1)
        {
          foreach (Prop prop in this.PrivacyGlass)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
        }
        this.RISpawnPropChair("ex_prop_offchair_exec_02", this.Chair1, new Vector3(0.0f, 0.0f, 0.0f));
        this.RISpawnPropChair("ex_prop_offchair_exec_02", this.Chair2, new Vector3(0.0f, 0.0f, 61f));
        this.RISpawnPropChair("ex_prop_offchair_exec_02", this.Chair3, new Vector3(0.0f, 0.0f, -95f));
        this.RISpawnPropChair("ex_prop_offchair_exec_02", this.Chair4, new Vector3(0.0f, 0.0f, 180f));
        this.RISpawnPropChair("ex_prop_offchair_exec_02", this.Chair5, new Vector3(0.0f, 0.0f, -103f));
        this.RISpawnPropChair("ex_prop_offchair_exec_02", this.Chair6, new Vector3(0.0f, 0.0f, 80f));
        this.RISpawnPropChair("ex_prop_offchair_exec_02", this.Chair7, new Vector3(0.0f, 0.0f, -8f));
        foreach (Ped riPed in this.RIPeds)
        {
          if ((Entity) riPed != (Entity) null)
            riPed.Delete();
        }
        if (this.RIpPostion.Count == 0)
        {
          this.RIpPostion.Add(this.Chair1);
          this.RIpRotation.Add(180f);
          this.RIpPostion.Add(this.Chair2);
          this.RIpRotation.Add(-133f);
          this.RIpPostion.Add(this.Chair3);
          this.RIpRotation.Add(98f);
          this.RIpPostion.Add(this.Chair4);
          this.RIpRotation.Add(0.0f);
          this.RIpPostion.Add(this.Chair5);
          this.RIpRotation.Add(94f);
          this.RIpPostion.Add(this.Chair6);
          this.RIpRotation.Add(-73f);
          this.RIpPostion.Add(this.Chair7);
          this.RIpRotation.Add(-171f);
          this.RIpPostion.Add(new Vector3(355.7609f, 4847.644f, -63.5f));
          this.RIpRotation.Add(71f);
          this.RIpPostion.Add(new Vector3(357.7892f, 4852.62f, -63.5f));
          this.RIpRotation.Add(71f);
          this.RIpPostion.Add(new Vector3(380.2133f, 4846.17f, -63.5f));
          this.RIpRotation.Add(-93f);
          this.RIpPostion.Add(new Vector3(379.5031f, 4840.819f, -63.5f));
          this.RIpRotation.Add(-97f);
          this.RIpPostion.Add(new Vector3(390.8618f, 4839.983f, -63.5f));
          this.RIpRotation.Add(-83f);
          this.RIpPostion.Add(new Vector3(391.003f, 4845.464f, -63.5f));
          this.RIpRotation.Add(-94f);
          this.RIpPostion.Add(new Vector3(399.9906f, 4845.404f, -63.5f));
          this.RIpRotation.Add(-94f);
          this.RIpPostion.Add(new Vector3(399.8768f, 4840.058f, -63.5f));
          this.RIpRotation.Add(-87f);
          this.RIpPostion.Add(new Vector3(409.748f, 4845.406f, -63.5f));
          this.RIpRotation.Add(-90f);
          this.RIpPostion.Add(new Vector3(409.6551f, 4840.003f, -63.5f));
          this.RIpRotation.Add(-87f);
          this.RIpPostion.Add(new Vector3(344.5149f, 4853.27f, -63.5f));
          this.RIpRotation.Add(58f);
          this.RIpPostion.Add(new Vector3(347.5109f, 4857.704f, -63.5f));
          this.RIpRotation.Add(55f);
        }
        for (int index = 0; index <= 6; ++index)
        {
          Ped ped = World.CreatePed(this.RequestModel(PedHash.FibOffice01SMM), this.RIpPostion[index], this.RIpRotation[index]);
          this.RIPeds.Add(ped);
          ped.Position = this.Chairs[index].GetOffsetInWorldCoords(new Vector3(0.0f, -0.25f, -0.51f));
          ped.FreezePosition = true;
          ped.Task.PlayAnimation("anim@amb@office@pa@female@", "pa_base", 8f, -1, true, -1f);
          ped.AlwaysKeepTask = true;
          ped.BlockPermanentEvents = true;
          ped.CanRagdoll = false;
        }
        for (int index = 7; index < this.RIpPostion.Count; ++index)
        {
          Ped ped = World.CreatePed(this.RequestModel(PedHash.FibOffice01SMM), this.RIpPostion[index], this.RIpRotation[index]);
          this.RIPeds.Add(ped);
          ped.FreezePosition = true;
          ped.Task.PlayAnimation("anim@amb@office@pa@female@", "pa_base", 8f, -1, true, -1f);
          ped.AlwaysKeepTask = true;
          ped.BlockPermanentEvents = true;
          ped.CanRagdoll = false;
        }
        List<Vector3> vector3List = new List<Vector3>();
        List<float> floatList = new List<float>();
        vector3List.Add(new Vector3(468.3027f, 4822.113f, -59f));
        floatList.Add(86f);
        vector3List.Add(new Vector3(495.23f, 4805.353f, -59f));
        floatList.Add(20f);
        vector3List.Add(new Vector3(474.255f, 4787.266f, -59f));
        floatList.Add(0.0f);
        vector3List.Add(new Vector3(380.93f, 4833.033f, -59f));
        floatList.Add(-100f);
        vector3List.Add(new Vector3(348.97f, 4842.15f, -59f));
        floatList.Add(-120f);
        vector3List.Add(new Vector3(359.799f, 4848.611f, -59f));
        floatList.Add(64f);
        for (int index = 0; index < vector3List.Count; ++index)
        {
          Ped ped = World.CreatePed(this.RequestModel(PedHash.FibOffice01SMM), vector3List[index], floatList[index]);
          this.RIPeds.Add(ped);
          ped.Weapons.Give(WeaponHash.SpecialCarbineMk2, 9999, true, true);
          ped.AlwaysKeepTask = true;
          ped.BlockPermanentEvents = true;
          ped.CanRagdoll = false;
        }
        this.FirstTime = true;
      }
      if (!this.FirstTime && this.isInInterior && (!this.SellStockDeliveryMission && (double) World.GetDistance(Game.Player.Character.Position, this.Exit) < 30.0))
      {
        foreach (Prop chair in this.Chairs)
        {
          if ((Entity) chair != (Entity) null)
            chair.Delete();
        }
        this.FirstTime = true;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 2.0 && !this.GLmainMenu.Visible)
        this.GLmainMenu.Visible = !this.GLmainMenu.Visible;
      if (this.GLmodMenuPool != null && this.GLmodMenuPool.IsAnyMenuOpen())
        this.GLmodMenuPool.ProcessMenus();
      if ((double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 40.0)
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      if (this.MoneyVaultBought == 1)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 3.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ open Money Vault");
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
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2228.79f, 2399.25f, 11f)) < 3.0)
        this.StartCoord = new Vector3(-2228.79f, 2399.25f, 11f);
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1272f, 2833f, 48f)) < 3.0)
        this.StartCoord = new Vector3(1272f, 2833f, 48f);
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2088f, 1761f, 103f)) < 3.0)
        this.StartCoord = new Vector3(2088f, 1761f, 103f);
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2754f, 3904f, 44f)) < 3.0)
        this.StartCoord = new Vector3(2754f, 3904f, 44f);
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1.3f, 2599f, 85f)) < 3.0)
        this.StartCoord = new Vector3(1.3f, 2599f, 85f);
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(3387f, 5509f, 24f)) < 3.0)
        this.StartCoord = new Vector3(3387f, 5509f, 24f);
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(21f, 6824f, 14f)) < 3.0)
        this.StartCoord = new Vector3(21f, 6824f, 14f);
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1885f, 303f, 162f)) < 3.0)
        this.StartCoord = new Vector3(1885f, 303f, 162f);
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2f, 3347f, 40f)) < 3.0)
        this.StartCoord = new Vector3(-2f, 3347f, 40f);
      if (Game.IsControlPressed(2, GTA.Control.MoveRightOnly) && this.IsInViewMode)
      {
        this.FirePos = this.MainCamera.Position;
        this.FirePos.X += 3f;
        Game.Player.Character.Position = this.FirePos;
        if (this.MainCamera != (Camera) null)
        {
          this.LockedVehicle = (Vehicle) null;
          this.DetectPos = new Vector3(0.0f, 0.0f, 0.0f);
          this.MainCamera.Position = this.FirePos;
        }
      }
      if (Game.IsControlPressed(2, GTA.Control.MoveLeftOnly) && this.IsInViewMode)
      {
        this.FirePos = this.MainCamera.Position;
        this.FirePos.X -= 3f;
        Game.Player.Character.Position = this.FirePos;
        if (this.MainCamera != (Camera) null)
        {
          this.LockedVehicle = (Vehicle) null;
          this.DetectPos = new Vector3(0.0f, 0.0f, 0.0f);
          this.MainCamera.Position = this.FirePos;
        }
      }
      if (Game.IsControlPressed(2, GTA.Control.MoveUpOnly) && this.IsInViewMode)
      {
        this.FirePos = this.MainCamera.Position;
        this.FirePos.Y += 3f;
        Game.Player.Character.Position = this.FirePos;
        if (this.MainCamera != (Camera) null)
        {
          this.LockedVehicle = (Vehicle) null;
          this.DetectPos = new Vector3(0.0f, 0.0f, 0.0f);
          this.MainCamera.Position = this.FirePos;
        }
      }
      if (Game.IsControlPressed(2, GTA.Control.MoveDownOnly) && this.IsInViewMode)
      {
        this.FirePos = this.MainCamera.Position;
        this.FirePos.Y -= 3f;
        Game.Player.Character.Position = this.FirePos;
        if (this.MainCamera != (Camera) null)
        {
          this.LockedVehicle = (Vehicle) null;
          this.DetectPos = new Vector3(0.0f, 0.0f, 0.0f);
          this.MainCamera.Position = this.FirePos;
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.OrbitalCannonPos) < 5.0)
        {
          if (!this.IsInViewMode)
          {
            this.IsInViewMode = true;
            World.GetWaypointPosition();
            if (true)
            {
              if (this.BusinessLocation == 0)
              {
                this.Entry = new Vector3(-2228.79f, 2399.25f, 11f);
                this.OutsideSpawn = new Vector3(-2231.41f, 2418.56f, 15f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 1)
              {
                this.Entry = new Vector3(1272f, 2833f, 48f);
                this.OutsideSpawn = new Vector3(1288f, 2847f, 48f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 2)
              {
                this.Entry = new Vector3(2088f, 1761f, 103f);
                this.OutsideSpawn = new Vector3(2075f, 1750f, 104f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 3)
              {
                this.Entry = new Vector3(2754f, 3904f, 44f);
                this.OutsideSpawn = new Vector3(2765f, 3916f, 45f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 4)
              {
                this.Entry = new Vector3(1.3f, 2599f, 85f);
                this.OutsideSpawn = new Vector3(16f, 2606f, 86f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 5)
              {
                this.Entry = new Vector3(3387f, 5509f, 24f);
                this.OutsideSpawn = new Vector3(3400f, 5506f, 26f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 6)
              {
                this.Entry = new Vector3(21f, 6824f, 14f);
                this.OutsideSpawn = new Vector3(5.41f, 6831f, 17f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 7)
              {
                this.Entry = new Vector3(1885f, 303f, 162f);
                this.OutsideSpawn = new Vector3(1875f, 285f, 164f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 8)
              {
                this.Entry = new Vector3(-2f, 3347f, 40f);
                this.OutsideSpawn = new Vector3(-7.8f, 3326f, 41f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              this.StartCoord = this.OutsideSpawn;
              Game.FadeScreenOut(1000);
              Script.Wait(1000);
              Game.Player.Character.IsInvincible = true;
              Game.Player.Character.IsVisible = false;
              Function.Call(Hash._0xA0EBB943C300E693, (InputArgument) false);
              this.LocationMem = this.StartCoord;
              this.rotationmem = Game.Player.Character.Rotation;
              Function.Call(Hash._0x8D32347D6D4C40A2, (InputArgument) Game.Player.Character, (InputArgument) false, (InputArgument) 0);
              Game.Player.Character.FreezePosition = true;
              this.cannonactive = true;
              this.cannon_index = 0;
            }
            World.GetWaypointPosition();
            if (false)
            {
              if (this.BusinessLocation == 0)
              {
                this.Entry = new Vector3(-2228.79f, 2399.25f, 11f);
                this.OutsideSpawn = new Vector3(-2231.41f, 2418.56f, 15f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 1)
              {
                this.Entry = new Vector3(1272f, 2833f, 48f);
                this.OutsideSpawn = new Vector3(1288f, 2847f, 48f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 2)
              {
                this.Entry = new Vector3(2088f, 1761f, 103f);
                this.OutsideSpawn = new Vector3(2075f, 1750f, 104f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 3)
              {
                this.Entry = new Vector3(2754f, 3904f, 44f);
                this.OutsideSpawn = new Vector3(2765f, 3916f, 45f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 4)
              {
                this.Entry = new Vector3(1.3f, 2599f, 85f);
                this.OutsideSpawn = new Vector3(16f, 2606f, 86f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 5)
              {
                this.Entry = new Vector3(3387f, 5509f, 24f);
                this.OutsideSpawn = new Vector3(3400f, 5506f, 26f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 6)
              {
                this.Entry = new Vector3(21f, 6824f, 14f);
                this.OutsideSpawn = new Vector3(5.41f, 6831f, 17f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 7)
              {
                this.Entry = new Vector3(1885f, 303f, 162f);
                this.OutsideSpawn = new Vector3(1875f, 285f, 164f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              if (this.BusinessLocation == 8)
              {
                this.Entry = new Vector3(-2f, 3347f, 40f);
                this.OutsideSpawn = new Vector3(-7.8f, 3326f, 41f);
                this.VehicleSpawn = new Vector3(-2484.23f, 3020.69f, 33f);
              }
              this.StartCoord = this.OutsideSpawn;
              this.FirePos = this.StartCoord;
              UI.Notify("Pos" + this.FirePos.ToString());
              UI.Notify("Pos At Facility");
            }
          }
        }
        else if (((double) World.GetDistance(Game.Player.Character.Position, this.OrbitalCannonPos) < 5.0 || this.IsInViewMode) && this.IsInViewMode)
        {
          this.IsInViewMode = false;
          Game.FadeScreenOut(1000);
          Script.Wait(1500);
          Function.Call(Hash._0x068E835A1D0DC0E3, (InputArgument) "MP_OrbitalCannon");
          this._mainCamera.IsActive = false;
          this._mainCamera.Destroy();
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) false, (InputArgument) false, (InputArgument) 50, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x8D32347D6D4C40A2, (InputArgument) Game.Player.Character, (InputArgument) true, (InputArgument) 0);
          Game.Player.Character.FreezePosition = false;
          Game.Player.Character.Position = this.LocationMem;
          Game.Player.Character.Rotation = this.rotationmem;
          this.cannonactive = false;
          this.cannon_index = -1;
          Function.Call(Hash._0x198F77705FA0931D, (InputArgument) Game.Player.Character);
          Function.Call(Hash._0xA0EBB943C300E693, (InputArgument) true);
          Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.newsoundid);
          Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.newsoundid);
          this.newsoundid = -1;
          Script.Wait(1000);
          Game.FadeScreenIn(1000);
          Game.Player.Character.Position = this.OrbitalCannonPos;
          Game.Player.Character.IsVisible = true;
          Game.Player.Character.IsInvincible = false;
          Function.Call(Hash._0xA6294919E56FF02A, (InputArgument) true);
        }
      }
      if (!this.IsInViewMode)
        this.OCstage = 0;
      if (this.IsInViewMode)
      {
        if (this.cannonactive)
        {
          switch (this.cannon_index)
          {
            case 0:
              Function.Call(Hash._0xA43D5C6FE51ADBEF, (InputArgument) "Clear");
              Function.Call(Hash._0x2206BF9A37B7F724, (InputArgument) "MP_OrbitalCannon", (InputArgument) 0, (InputArgument) 1);
              this.Cannon_Scale = new Scaleform(Function.Call<int>((Hash) 7343092289874906331, (InputArgument) "ORBITAL_CANNON_CAM"));
              Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_CHRISTMAS2017/XM_ION_CANNON", (InputArgument) false, (InputArgument) -1);
              this.Cannon_Scale.CallFunction("SET_ZOOM_LEVEL", (object) 0.0f);
              this.cannon_index = 10;
              break;
            case 10:
              if (this.Cannon_Scale.IsLoaded)
              {
                this._mainCamera = Function.Call<Camera>(Hash._0xC3981DCE61D9E13F, (InputArgument) "DEFAULT_SCRIPTED_CAMERA", (InputArgument) false);
                Game.Player.Character.Position = new Vector3(this.OutsideSpawn.X, this.OutsideSpawn.Y, this.camerazoom);
                this.FirePos = new Vector3(this.OutsideSpawn.X, this.OutsideSpawn.Y, this.camerazoom);
                this.MainCamera.Position = new Vector3(Game.Player.Character.Position.X, Game.Player.Character.Position.Y, this.camerazoom);
                this.MainCamera.Rotation = new Vector3(-90f, 0.0f, 0.0f);
                this.MainCamera.FieldOfView = 100f;
                this.MainCamera.IsActive = true;
                World.RenderingCamera = this.MainCamera;
                this.cannon_index = 20;
                break;
              }
              break;
            case 20:
              this.Cannon_Scale.CallFunction("SET_STATE", (object) 3);
              this.Cannon_Scale.CallFunction("SET_COUNTDOWN", (object) 0);
              this.Cannon_Scale.CallFunction("SET_CHARGING_LEVEL", (object) 1f);
              Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_xm_orbital");
              Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_xm_orbital");
              Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_xm_orbital");
              Game.FadeScreenIn(1000);
              this.cannon_index = 30;
              break;
            case 30:
              Function.Call(Hash._0xFE99B66D079CF6BC, (InputArgument) 2, (InputArgument) 37);
              Function.Call(Hash._0xFE99B66D079CF6BC, (InputArgument) 2, (InputArgument) 27);
              Function.Call(Hash._0xFE99B66D079CF6BC, (InputArgument) 2, (InputArgument) 19);
              bool flag1 = false;
              Function.Call<float>(Hash._0xC3330A45CCCDB26A, (InputArgument) this.MainCamera);
              float num1 = 35f + this.func_68(this.zoomindex);
              float num2 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 218);
              float num3 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 219);
              Vector3 vector3_1 = Function.Call<Vector3>(Hash._0xBAC038F7459AE5AE, (InputArgument) this.MainCamera);
              if ((double) num2 > 0.100000001490116)
              {
                if ((double) vector3_1.X + (double) Function.Call<float>(Hash._0x73D57CFFDD12C355, (InputArgument) (num1 * num2)) * (double) Function.Call<float>(Hash._0x0000000050597EE2) <= 4000.0)
                {
                  flag1 = true;
                  vector3_1.X += (float) ((double) Function.Call<float>(Hash._0x73D57CFFDD12C355, (InputArgument) (num1 * num2)) * (double) Function.Call<float>(Hash._0x0000000050597EE2));
                }
              }
              else if ((double) num2 < -0.100000001490116)
              {
                if ((double) vector3_1.X - (double) Function.Call<float>(Hash._0x73D57CFFDD12C355, (InputArgument) (num1 * num2)) * (double) Function.Call<float>(Hash._0x0000000050597EE2) >= -4000.0)
                {
                  flag1 = true;
                  vector3_1.X -= (float) ((double) Function.Call<float>(Hash._0x73D57CFFDD12C355, (InputArgument) (num1 * num2)) * (double) Function.Call<float>(Hash._0x0000000050597EE2));
                }
              }
              if ((double) num3 > 0.100000001490116)
              {
                if ((double) vector3_1.Y - (double) Function.Call<float>(Hash._0x73D57CFFDD12C355, (InputArgument) (num1 * num3)) * (double) Function.Call<float>(Hash._0x0000000050597EE2) >= -4000.0)
                {
                  flag1 = true;
                  vector3_1.Y -= (float) ((double) Function.Call<float>(Hash._0x73D57CFFDD12C355, (InputArgument) (num1 * num3)) * (double) Function.Call<float>(Hash._0x0000000050597EE2));
                }
              }
              else if ((double) num3 < -0.100000001490116)
              {
                if ((double) vector3_1.Y + (double) Function.Call<float>(Hash._0x73D57CFFDD12C355, (InputArgument) (num1 * num3)) * (double) Function.Call<float>(Hash._0x0000000050597EE2) <= 8000.0)
                {
                  flag1 = true;
                  vector3_1.Y += (float) ((double) Function.Call<float>(Hash._0x73D57CFFDD12C355, (InputArgument) (num1 * num3)) * (double) Function.Call<float>(Hash._0x0000000050597EE2));
                }
              }
              Function.Call(Hash._0x61BB1D9B3A95D802, (InputArgument) 0);
              this.Cannon_Scale.Render2D();
              float num4 = 0.0f;
              float num5 = 0.0f;
              Vector3 vector3_2 = Function.Call<Vector3>(Hash._0xBAC038F7459AE5AE, (InputArgument) this.MainCamera);
              if ((double) vector3_2.X < (double) vector3_1.X)
                num4 = 50f;
              else if ((double) vector3_2.X > (double) vector3_1.X)
                num4 = -50f;
              if ((double) vector3_2.Y < (double) vector3_1.Y)
                num5 = 50f;
              else if ((double) vector3_2.Y > (double) vector3_1.Y)
                num5 = -50f;
              if ((double) this.cannoncharge < 0.990000009536743)
              {
                if (this.rechargerate < Game.GameTime)
                {
                  this.rechargerate = Game.GameTime + 25;
                  this.Cannon_Scale.CallFunction("SET_CHARGING_LEVEL", (object) this.cannoncharge);
                  this.cannoncharge += 0.01f;
                  if ((double) this.cannoncharge > 0.985000014305115)
                  {
                    this.cannoncharge = 1f;
                    this.Cannon_Scale.CallFunction("SET_CHARGING_LEVEL", (object) 1f);
                  }
                }
              }
              else if ((double) this.cannoncharge == 1.0)
              {
                bool flag2 = Game.IsControlPressed(2, GTA.Control.CursorAccept);
                if (Game.Player.Money >= 750000)
                {
                  if (Game.IsControlJustPressed(2, GTA.Control.CursorAccept))
                  {
                    this.Cannon_Scale.CallFunction("SET_COUNTDOWN", (object) 3);
                    this.newsoundid = Function.Call<int>(Hash._0x430386FE9BF80B45);
                    Function.Call(Hash._0x67C540AA08E4A6F5, (InputArgument) this.newsoundid, (InputArgument) "cannon_charge_fire_loop", (InputArgument) "dlc_xm_orbital_cannon_sounds", (InputArgument) true);
                    this.canin = 0;
                  }
                  if (flag2)
                  {
                    switch (this.canin)
                    {
                      case 0:
                        if (this.Cannon_countdown < Game.GameTime)
                        {
                          this.Cannon_Scale.CallFunction("SET_COUNTDOWN", (object) 3);
                          this.canin = 1;
                          this.Cannon_countdown = Game.GameTime + 1000;
                          break;
                        }
                        break;
                      case 1:
                        if (this.Cannon_countdown < Game.GameTime)
                        {
                          this.Cannon_Scale.CallFunction("SET_COUNTDOWN", (object) 2);
                          this.canin = 2;
                          this.Cannon_countdown = Game.GameTime + 1000;
                          break;
                        }
                        break;
                      case 2:
                        if (this.Cannon_countdown < Game.GameTime)
                        {
                          this.Cannon_Scale.CallFunction("SET_COUNTDOWN", (object) 1);
                          this.canin = 3;
                          this.Cannon_countdown = Game.GameTime + 1000;
                          break;
                        }
                        break;
                      case 3:
                        if (this.Cannon_countdown < Game.GameTime)
                        {
                          this.Cannon_Scale.CallFunction("SET_COUNTDOWN", (object) 0);
                          Game.Player.Money -= 750000;
                          this.FireCannon(Function.Call<Vector3>(Hash._0xBAC038F7459AE5AE, (InputArgument) this.MainCamera));
                          this.canin = -1;
                          this.cannoncharge = 0.0f;
                          this.rechargerate = Game.GameTime + 25;
                          break;
                        }
                        break;
                    }
                  }
                  else if (!flag2)
                  {
                    Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.newsoundid);
                    this.canin = -1;
                    this.Cannon_Scale.CallFunction("SET_COUNTDOWN", (object) 0);
                    this.Cannon_countdown = Game.GameTime;
                  }
                }
                else if (flag2)
                  this.DisplayHelpTextThisFrameNoSound("Player Does not have the funds to fire the Orbital Cannon");
              }
              float num6 = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 221);
              if (!Function.Call<bool>(Hash._0xA571D46727E2B718, (InputArgument) 2))
              {
                if ((double) num6 > 0.3)
                {
                  if (this.zoomindex < 5)
                  {
                    ++this.zoomindex;
                    this.zoomcalculator(this.zoomindex);
                    this.Cannon_Scale.CallFunction("SET_ZOOM_LEVEL", (object) this.zoomscale);
                  }
                }
                else if ((double) num6 < -0.300000011920929 && this.zoomindex > 0)
                {
                  --this.zoomindex;
                  this.zoomcalculator(this.zoomindex);
                  this.Cannon_Scale.CallFunction("SET_ZOOM_LEVEL", (object) this.zoomscale);
                }
              }
              else if (Function.Call<bool>(Hash._0x580417101DDB492F, (InputArgument) 2, (InputArgument) 242))
              {
                if (this.zoomindex > 0)
                {
                  --this.zoomindex;
                  this.zoomcalculator(this.zoomindex);
                  this.Cannon_Scale.CallFunction("SET_ZOOM_LEVEL", (object) this.zoomscale);
                }
              }
              else if (Function.Call<bool>(Hash._0x580417101DDB492F, (InputArgument) 2, (InputArgument) 241) && this.zoomindex < 5)
              {
                ++this.zoomindex;
                this.zoomcalculator(this.zoomindex);
                this.Cannon_Scale.CallFunction("SET_ZOOM_LEVEL", (object) this.zoomscale);
              }
              Function.Call(Hash._0x4D41783FB745E42E, (InputArgument) this.MainCamera, (InputArgument) vector3_1.X, (InputArgument) vector3_1.Y, (InputArgument) (World.GetGroundHeight(this.MainCamera.Position) + this.camerazoom));
              float num7 = 0.0f;
              Function.Call(Hash._0xC906A7DAB05C8D2B, (InputArgument) vector3_1.X, (InputArgument) vector3_1.Y, (InputArgument) vector3_1.Z, (InputArgument) &num7, (InputArgument) 1, (InputArgument) 0);
              Function.Call(Hash._0xBB7454BAFF08FE25, (InputArgument) (vector3_1.X + num4), (InputArgument) (vector3_1.Y + num5), (InputArgument) (num7 + 50f), (InputArgument) -90f, (InputArgument) 0.0f, (InputArgument) 0.0f);
              break;
          }
        }
        Function.Call(Hash._0xA0EBB943C300E693, (InputArgument) false);
        Function.Call(Hash._0xA6294919E56FF02A, (InputArgument) false);
        Game.Player.WantedLevel = 0;
        Game.Player.Character.IsInvincible = true;
        if (this.Timer != 200)
          ++this.Timer;
        if (this.Timer == 50)
        {
          ++this.Timer;
          this.DisplayHelpTextThisFrameNoSound("Press ~INPUT_CONTEXT~ to Exit, Hold ~INPUT_ATTACK~ to fire, $750,000/Volley");
        }
        if (this.Timer == 100)
        {
          ++this.Timer;
          this.DisplayHelpTextThisFrameNoSound("~INPUT_MOVE_UP_ONLY~ , ~INPUT_VEH_BRAKE~ , ~INPUT_MOVE_LEFT_ONLY~ , ~INPUT_MOVE_RIGHT_ONLY~ to Move");
        }
        if (this.Timer == 150)
        {
          ++this.Timer;
          this.DisplayHelpTextThisFrameNoSound(" ~INPUT_SELECT_NEXT_WEAPON~ / ~INPUT_SELECT_PREV_WEAPON~ Zoom Up/Down");
        }
        if (this.Timer == 200)
          this.Timer = 0;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.OrbitalCannonPos) < 89.0)
        World.DrawMarker(MarkerType.VerticalCylinder, this.OrbitalCannonPos, Vector3.Zero, Vector3.Zero, new Vector3(0.45f, 0.45f, 0.25f), this.MarkerColor);
      if ((double) World.GetDistance(Game.Player.Character.Position, this.OrbitalCannonPos) < 2.0 && !this.IsInViewMode)
        this.DisplayHelpTextThisFrameNoSound("Press ~INPUT_CONTEXT~ Orbital Cannon");
      if (this.RImodMenuPool != null && this.RImodMenuPool.IsAnyMenuOpen())
        this.RImodMenuPool.ProcessMenus();
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(374f, 6307.56f, 130f)) < 500.0 && !this.CreatedProp)
      {
        this.CreatedProp = true;
        foreach (Prop nearbyProp in World.GetNearbyProps(new Vector3(374f, 6307.56f, 130f), 80f))
        {
          if ((Entity) nearbyProp != (Entity) null)
            nearbyProp.Delete();
        }
        this.RISpawnProp("xm_prop_x17_silo_open_01a", new Vector3(374f, 6307.56f, 135f), new Vector3(0.0f, 0.0f, 180f));
        this.RISpawnProp("xm_prop_x17_silo_open_01a", new Vector3(374f, 6307.56f, 123f), new Vector3(180f, 0.0f, 180f));
        this.RISpawnProp("xm_prop_x17_silo_open_01a", new Vector3(374f, 6307.56f, 115f), new Vector3(180f, 0.0f, 180f));
        this.RISpawnProp("xm_prop_x17_silo_rocket_01", new Vector3(374f, 6307.56f, 100f), new Vector3(0.0f, 0.0f, 180f));
        this.RISpawnProp("xm_prop_x17_silo_door_l_01a", new Vector3(363f, 6307f, 144f), new Vector3(0.0f, -60f, 180f));
        this.RISpawnProp("xm_prop_x17_silo_door_r_01a", new Vector3(384f, 6307f, 144f), new Vector3(0.0f, 60f, 180f));
        Script.Wait(1000);
        this.RefreshInterior();
      }
      if (this.MVmodMenuPool != null && this.MVmodMenuPool.IsAnyMenuOpen())
        this.MVmodMenuPool.ProcessMenus();
      if (this.GunLockerBought == 1 && (double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 3.0)
        this.DisplayHelpTextThisFrame("Press E open gun locker");
      if (this.Active)
      {
        this.DrawFIBHack("MORGUE_LAPTOP");
        if (Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.iLocal_8077))
        {
          Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.iLocal_8077, (InputArgument) "SET_PROGRESS_PERCENT");
          int amt = this.Amt;
          if (amt < 100)
            ;
          Function.Call(Hash._0xC3D0841A0CC546A6, (InputArgument) amt);
          Function.Call(Hash._0xC6796A8FFA375E53);
          Function.Call(Hash._0x0DF606929C105BE1, (InputArgument) this.iLocal_8077, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);
        }
      }
      this.OnKeyDown();
      if (this.isInInterior)
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
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ChairPos) < 2.0)
        {
          if (this.IsSittinginCeoSeat)
          {
            if ((Game.IsControlJustPressed(2, GTA.Control.FrontendPauseAlternate) || Game.IsControlJustPressed(2, GTA.Control.PhoneCancel)) && this.mainMenu.Visible)
            {
              Prop chairProp = this.ChairProp;
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num, (InputArgument) "computer_exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            }
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Nightclub1.ini");
              if (!this.mainMenu.Visible)
              {
                Prop chairProp = this.ChairProp;
                int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chairProp.Position.X, (InputArgument) chairProp.Position.Y, (InputArgument) chairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chairProp.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chairProp, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(100);
                this.mainMenu.Visible = !this.mainMenu.Visible;
              }
            }
            if (Game.IsControlJustPressed(2, GTA.Control.Cover))
            {
              Game.Player.Character.HasCollision = true;
              this.modMenuPool.CloseAllMenus();
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ChairProp.Position.X, (InputArgument) this.ChairProp.Position.Y, (InputArgument) this.ChairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ChairProp.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "exit", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ChairProp, (InputArgument) num, (InputArgument) "exit_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
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
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) this.ChairProp.Position.X, (InputArgument) this.ChairProp.Position.Y, (InputArgument) this.ChairProp.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) this.ChairProp.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "enter", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.ChairProp, (InputArgument) num, (InputArgument) "enter_chair", (InputArgument) Class1.LoadDict("anim@amb@office@boss@male@"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(5000);
              this.IsSittinginCeoSeat = true;
            }
          }
        }
      }
      if (!this.CreatedChair)
      {
        try
        {
          if ((Entity) this.ChairProp != (Entity) null)
            this.ChairProp.Delete();
          this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), new Vector3(359.93f, 4842.88f, -60f), new Vector3(0.0f, 0.0f, -158f), false, false);
          this.ChairProp.FreezePosition = true;
          this.CreatedChair = true;
        }
        catch (Exception ex)
        {
          UI.Notify("~r~ Error~w~ Could not find Chair Prop Model!, Model has been added to ini, no need to take action");
          UI.Notify("~g~ HKH191~w~ Chair Prop Models Were not found, please Reload the mod ");
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
          this.ChairPropModel = "ex_prop_offchair_exec_01";
          this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
          this.Config.Save();
          this.Config.SetValue<string>("Chair Model", "POSSIBLECHAIRPROPMODELS", "'ex_prop_offchair_exec_01', 'ex_prop_offchair_exec_02', 'ex_prop_offchair_exec_03', 'ex_prop_offchair_exec_04', 'ba_prop_battle_club_chair_01', 'ba_prop_battle_club_chair_02', 'ba_prop_battle_club_chair_03' ");
          this.Config.Save();
        }
      }
      if (this.AtHAtch)
      {
        World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
        if (this.GrabbedHatch)
        {
          Vector3 currentHatch1 = this.CurrentHatch;
          if (true)
          {
            Prop[] nearbyProps = World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
            if ((uint) nearbyProps.Length > 0U)
            {
              foreach (Prop prop in nearbyProps)
              {
                this.CurrentHatch = prop.Position;
                prop.HasCollision = false;
                prop.IsVisible = false;
              }
            }
          }
          Vector3 currentHatch2 = this.CurrentHatch;
          if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) < 400.0)
          {
            if (!this.HatchOpen && (double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) < 30.0)
            {
              World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
              Prop[] nearbyProps = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_out_hanger_lift"));
              if ((uint) nearbyProps.Length > 0U)
              {
                foreach (Entity entity in nearbyProps)
                  entity.IsVisible = true;
              }
              Function.Call(Hash._0x7FB218262B810701, (InputArgument) this.OSRig, (InputArgument) "open", (InputArgument) Class1.LoadDict("anim@amb@facility@hanger_doors"), (InputArgument) 4f, (InputArgument) false, (InputArgument) true, (InputArgument) 0, (InputArgument) 0.0f, (InputArgument) 8);
              this.HatchClosed_final = false;
              this.HatchClosed = false;
              this.HatchOpen = true;
              if (this.OSHatch != null && (Entity) this.OSRig != (Entity) null)
              {
                this.LoadIniFileDesign("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
                this.FacilityShellColor = this.Config.GetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
                this.FacilityShellColor = this.Config.GetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
                Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.OShatchBase, (InputArgument) this.FacilityShellColor);
                Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.OSRig, (InputArgument) this.FacilityShellColor);
              }
            }
            if (this.HatchOpen)
            {
              if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) > 40.0)
                this.HatchClosed_final = true;
              if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) > 30.0 && (!this.HatchClosed && !this.HatchClosed_final))
              {
                Prop[] nearbyProps = World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
                if ((uint) nearbyProps.Length > 0U)
                {
                  foreach (Prop prop in nearbyProps)
                  {
                    this.CurrentHatch = prop.Position;
                    prop.HasCollision = false;
                    prop.IsVisible = false;
                  }
                }
                this.HatchOpen = false;
                if (!Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) this.OSRig, (InputArgument) Class1.LoadDict("anim@amb@facility@hanger_doors"), (InputArgument) "close", (InputArgument) 1))
                {
                  Function.Call(Hash._0x7FB218262B810701, (InputArgument) this.OSRig, (InputArgument) "close", (InputArgument) Class1.LoadDict("anim@amb@facility@hanger_doors"), (InputArgument) 4f, (InputArgument) false, (InputArgument) true, (InputArgument) 0, (InputArgument) 0.0f, (InputArgument) 8);
                  if (this.OSHatch != null && (Entity) this.OSRig != (Entity) null)
                  {
                    this.LoadIniFileDesign("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
                    this.FacilityShellColor = this.Config.GetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
                    Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.OShatchBase, (InputArgument) this.FacilityShellColor);
                    Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.OSRig, (InputArgument) this.FacilityShellColor);
                  }
                }
                this.HatchClosed_final = true;
              }
            }
            if (this.HatchClosed_final && (double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) > 200.0)
            {
              this.HatchClosed_final = false;
              Prop[] nearbyProps = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_out_hanger_lift"));
              this.LoadIniFileDesign("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
              if ((uint) nearbyProps.Length > 0U)
              {
                foreach (Prop prop in nearbyProps)
                {
                  if (this.OSHatch != null && (Entity) this.OSRig != (Entity) null)
                  {
                    this.LoadIniFileDesign("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
                    this.FacilityShellColor = this.Config.GetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
                    Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.OShatchBase, (InputArgument) this.FacilityShellColor);
                    Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.OSRig, (InputArgument) this.FacilityShellColor);
                  }
                  prop.IsVisible = true;
                }
              }
              this.HatchClosed = true;
            }
            if (this.HatchClosed && (double) World.GetDistance(Game.Player.Character.Position, this.CurrentHatch) > 150.0)
            {
              if (!Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) this.OSRig, (InputArgument) "anim@amb@facility@hanger_doors", (InputArgument) "close", (InputArgument) 1))
              {
                Prop[] nearbyProps1 = World.GetNearbyProps(Game.Player.Character.Position, 400f, this.RequestModel("xm_prop_x17_osphatch_27m"));
                if ((uint) nearbyProps1.Length > 0U)
                {
                  foreach (Prop prop1 in nearbyProps1)
                  {
                    this.GrabbedHatch = false;
                    this.StopScreenEffects();
                    Prop[] nearbyProps2 = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_x17_rig_osphatch"));
                    if ((uint) nearbyProps2.Length > 0U)
                    {
                      foreach (Entity entity in nearbyProps2)
                        entity.IsVisible = false;
                    }
                    Prop[] nearbyProps3 = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_out_hanger_lift"));
                    if ((uint) nearbyProps3.Length > 0U)
                    {
                      foreach (Entity entity in nearbyProps3)
                        entity.IsVisible = false;
                    }
                    foreach (Prop prop2 in this.OSHatch)
                    {
                      if ((Entity) prop2 != (Entity) null)
                        prop2.Delete();
                    }
                    prop1.Alpha = 0;
                  }
                }
              }
            }
          }
        }
        if (!this.GrabbedHatch)
        {
          Prop[] nearbyProps1 = World.GetNearbyProps(Game.Player.Character.Position, 200f, this.RequestModel("xm_prop_x17_osphatch_27m"));
          if ((uint) nearbyProps1.Length > 0U)
          {
            foreach (Prop prop1 in nearbyProps1)
            {
              this.CurrentHatch = prop1.Position;
              Prop[] nearbyProps2 = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_x17_rig_osphatch"));
              if ((uint) nearbyProps2.Length > 0U)
              {
                foreach (Entity entity in nearbyProps2)
                  entity.Delete();
              }
              Prop[] nearbyProps3 = World.GetNearbyProps(this.CurrentHatch, 400f, this.RequestModel("xm_prop_out_hanger_lift"));
              if ((uint) nearbyProps3.Length > 0U)
              {
                foreach (Entity entity in nearbyProps3)
                  entity.Delete();
              }
              foreach (Prop prop2 in this.OSHatch)
              {
                if ((Entity) prop2 != (Entity) null)
                  prop2.Delete();
              }
              this.HatchClosed = false;
              this.HatchOpen = false;
              prop1.HasCollision = false;
              prop1.IsVisible = false;
              if ((Entity) this.OSRig != (Entity) null)
                this.OSRig.Delete();
              if ((Entity) this.OShatchBase != (Entity) null)
                this.OShatchBase.Delete();
              this.OSRig = World.CreateProp(this.RequestModel("xm_prop_x17_rig_osphatch"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, -18.3f)), new Vector3(prop1.Rotation.X, prop1.Rotation.Y, prop1.Rotation.Z), false, false);
              this.OSHatch.Add(this.OSRig);
              this.OSRig.FreezePosition = true;
              this.OShatchBase = World.CreateProp(this.RequestModel("xm_prop_out_hanger_lift"), prop1.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 2.1f)), new Vector3(prop1.Rotation.X, prop1.Rotation.Y, prop1.Rotation.Z - 105f), false, false);
              this.OSHatch.Add(this.OShatchBase);
              this.OShatchBase.FreezePosition = true;
              this.LoadIniFileDesign("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
              if (this.OSHatch != null && (Entity) this.OSRig != (Entity) null)
              {
                this.LoadIniFileDesign("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
                this.FacilityShellColor = this.Config.GetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
                Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.OShatchBase, (InputArgument) this.FacilityShellColor);
                Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.OSRig, (InputArgument) this.FacilityShellColor);
              }
              this.GrabbedHatch = true;
            }
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) > 200.0)
        this.AtHAtch = false;
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 200.0)
        this.AtHAtch = true;
      int num8;
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
              num8 = (int) ((double) this.stocksvalue * 0.25);
              UI.Notify("~g~Stock Increase : +$" + num8.ToString("N"));
              num8 = (int) ((double) this.stocksvalue * 1.25);
              UI.Notify("~g~Stock Value Now: +$" + num8.ToString("N"));
              this.missionnum = 0;
              this.stocksvalue = (float) (int) ((double) this.stocksvalue * 1.25);
              this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
              this.Config.Save();
            }
            if ((double) World.GetDistance(this.Sam1.Position, this.EndPoint) < 20.0 || (double) World.GetDistance(this.Sam2.Position, this.EndPoint) < 20.0 || (double) World.GetDistance(this.Sam3.Position, this.EndPoint) < 20.0)
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
              if ((double) World.GetDistance(this.StockVeh.Position, this.Exit) < 200.0)
                World.DrawMarker(MarkerType.VerticalCylinder, this.Exit, Vector3.Zero, Vector3.Zero, new Vector3(6f, 6f, 4f), Color.White);
              if ((double) World.GetDistance(this.StockVeh.Position, this.Exit) < 5.0)
              {
                this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Deliver Cargo ~INPUT_COVER~ to Quit mission");
                if (Game.IsControlPressed(2, GTA.Control.Context))
                {
                  this.maxstocks = 10 * this.purchaselvl;
                  if (this.stockscount <= this.maxstocks)
                  {
                    float num1;
                    if (this.StockVeh.Model == (Model) VehicleHash.Flatbed)
                    {
                      this.stocksvalue += this.IncreaseStockMinAmount * 9f;
                      this.stockscount += 3;
                      string hostName = this.GetHostName();
                      num1 = this.IncreaseStockMinAmount * 9f;
                      string str = num1.ToString("N");
                      UI.Notify(hostName + " Ok you have stolen a 3 crates worth ~g~$" + str);
                      this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
                      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                      this.Config.Save();
                    }
                    if (this.StockVeh.Model == (Model) VehicleHash.TipTruck)
                    {
                      this.stocksvalue += this.IncreaseStockMinAmount * 6f;
                      this.stockscount += 2;
                      string hostName = this.GetHostName();
                      num1 = this.IncreaseStockMinAmount * 6f;
                      string str = num1.ToString("N");
                      UI.Notify(hostName + " Ok you have stolen 2 singles crate worth ~g~$" + str);
                      this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
                      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                      this.Config.Save();
                    }
                    if (this.StockVeh.Model == (Model) VehicleHash.Guardian)
                    {
                      this.stocksvalue += this.IncreaseStockMinAmount * 3f;
                      ++this.stockscount;
                      string hostName = this.GetHostName();
                      num1 = this.IncreaseStockMinAmount * 3f;
                      string str = num1.ToString("N");
                      UI.Notify(hostName + " Ok you have stolen a single crate worth ~g~$" + str);
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
            for (int index1 = 0; index1 < this.DropPoint.Count; num8 = index1++)
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
                        this.SupplyGarageBlip = World.CreateBlip(this.Exit);
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
                        if ((double) num1 > 33.0 && (double) num1 < 66.0)
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
                        if ((double) num1 > 66.0)
                        {
                          this.StockVeh = World.CreateVehicle((Model) VehicleHash.Guardian, this.DropPoint[index1], 0.0f);
                          Vector3 offsetInWorldCoords = this.StockVeh.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.1f));
                          Prop prop = World.CreateProp(this.RequestModel(this.CrateProps[random.Next(0, this.CrateProps.Count)]), offsetInWorldCoords, new Vector3(0.0f, 0.0f, this.StockVeh.Heading), false, false);
                          this.SellStockProp1 = prop;
                          this.SellStockProps.Add(prop);
                          this.SellStockProp1.HasCollision = false;
                        }
                        float num2 = (float) random.Next(6, 8);
                        for (int index2 = 0; (double) index2 < (double) num2; ++index2)
                        {
                          Ped ped = World.CreatePed(this.RequestModel(PedHash.Polynesian01AMM), this.DropPoint[index1].Around(20f));
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
                    int count = this.DropBlip.Count;
                    string str1 = count.ToString();
                    count = this.DropPoint.Count;
                    string str2 = count.ToString();
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
                for (int index = 0; index < this.DropBlip.Count; num8 = index++)
                {
                  if (this.DropBlip[index] != (Blip) null && this.DropBlip[index].Alpha == (int) byte.MaxValue)
                  {
                    if (this.SellStockPointsBeenAt != this.AmttoDeliver)
                    {
                      if ((double) World.GetDistance(this.StockVeh.Position, this.DropPoint[index]) < 200.0)
                        World.DrawMarker(MarkerType.VerticalCylinder, this.DropPoint[index], Vector3.Zero, Vector3.Zero, new Vector3(4f, 6f, 4f), Color.White);
                      if ((double) World.GetDistance(this.StockVeh.Position, this.DropPoint[index]) < 10.0)
                      {
                        num8 = this.SellStockPointsBeenAt++;
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
      if (!this.SetInterior)
      {
        this.SetInterior = true;
        int num1 = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 462.09f, (InputArgument) 4820.42f, (InputArgument) -59f);
        foreach (object obj in new List<object>()
        {
          (object) "set_int_02_decal_01",
          (object) "set_int_02_decal_02",
          (object) "set_int_02_decal_03",
          (object) "set_int_02_decal_04",
          (object) "set_int_02_decal_05",
          (object) "set_int_02_decal_06",
          (object) "set_int_02_decal_07",
          (object) "set_int_02_decal_08",
          (object) "set_int_02_decal_09",
          (object) "set_int_02_no_cannon",
          (object) "set_int_02_cannon",
          (object) "set_int_02_no_security",
          (object) "set_int_02_no_security",
          (object) "set_int_02_lounge1",
          (object) "set_int_02_lounge2",
          (object) "set_int_02_lounge3",
          (object) "set_int_02_no_sleep",
          (object) "set_int_02_sleep",
          (object) "set_int_02_sleep2",
          (object) "set_int_02_sleep3"
        })
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__468.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__468.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string str = Class1.\u003C\u003Eo__468.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__468.\u003C\u003Ep__0, obj);
          if (str != null)
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) str);
        }
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num1);
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//InteriorDesign.ini");
        this.FacilityGraphic = this.Config.GetValue<string>("Configurations", "FacilityGraphic", this.FacilityGraphic);
        this.FacilityOrbitalCannon = this.Config.GetValue<string>("Configurations", "FacilityOrbitalCannon", this.FacilityOrbitalCannon);
        this.FacilitySecurityRoom = this.Config.GetValue<string>("Configurations", "FacilitySecurityRoom", this.FacilitySecurityRoom);
        this.FacilityLounge = this.Config.GetValue<string>("Configurations", "FacilityLounge", this.FacilityLounge);
        this.FacilitySleepingQuarters = this.Config.GetValue<string>("Configurations", "FacilitySleepingQuarters", this.FacilitySleepingQuarters);
        this.FacilityShellColor = this.Config.GetValue<int>("Configurations", "FacilityShellColor", this.FacilityShellColor);
        this.FacilityGraphicColor = this.Config.GetValue<int>("Configurations", "FacilityGraphicColor", this.FacilityGraphicColor);
        this.FacilityOrbitalCannonColor = this.Config.GetValue<int>("Configurations", "FacilityOrbitalCannonColor", this.FacilityOrbitalCannonColor);
        this.FacilitySecurityRoomColor = this.Config.GetValue<int>("Configurations", "FacilitySecurityRoomColor", this.FacilitySecurityRoomColor);
        this.FacilityLoungeColor = this.Config.GetValue<int>("Configurations", "FacilityLoungeColor", this.FacilityLoungeColor);
        this.FacilitySleepingQuartersColor = this.Config.GetValue<int>("Configurations", "FacilitySleepingQuartersColor", this.FacilitySleepingQuartersColor);
        Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xm_x17dlc_int_placement_interior_33_x17dlc_int_02_milo_");
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xm_x17dlc_int_placement_interior_33_x17dlc_int_02_milo_");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "set_int_02_shell");
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilityGraphic);
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilityOrbitalCannon);
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilitySecurityRoom);
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilityLounge);
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.FacilitySleepingQuarters);
        Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) "set_int_02_shell", (InputArgument) this.FacilityShellColor);
        Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilityGraphic, (InputArgument) this.FacilityGraphicColor);
        Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilityOrbitalCannon, (InputArgument) this.FacilityOrbitalCannonColor);
        Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilitySecurityRoom, (InputArgument) this.FacilitySecurityRoomColor);
        Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilityLounge, (InputArgument) this.FacilityLoungeColor);
        Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.FacilitySleepingQuarters, (InputArgument) this.FacilitySleepingQuartersColor);
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num1);
        int num2 = Function.Call<int>(Hash._0xA6575914D2A0B450);
        Function.Call(Hash._0x52923C4710DD9907, (InputArgument) Game.Player.Character, (InputArgument) num1, (InputArgument) num2);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2399.7f, 718.1f, 221.4f)) < 2.0 && Game.Player.Character.Alpha == 15)
      {
        this.MainModDestroy();
        this.MainModRefresh();
      }
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      if (this.modMenuPool2 != null && this.modMenuPool2.IsAnyMenuOpen())
        this.modMenuPool2.ProcessMenus();
      if (this.Facility != (Blip) null)
      {
        if (this.purchaselvl > 0)
        {
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Facility, (InputArgument) 590);
          this.Facility.Color = this.Blip_Colour;
          this.Facility.Name = "Doomsday Heist Business Facility";
          this.Facility.IsShortRange = true;
          this.Facility.Alpha = (int) byte.MaxValue;
        }
        if (this.purchaselvl == 0)
        {
          Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.Facility, (InputArgument) 590);
          this.Facility.Color = BlipColor.White;
          this.Facility.Name = "Doomsday Heist Business Facility";
          this.Facility.IsShortRange = true;
          this.Facility.Alpha = 0;
        }
      }
      if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle1 = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle1)
        {
          currentVehicle1.FreezePosition = true;
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save Vehicle");
        }
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle2)
        {
          currentVehicle1.FreezePosition = true;
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save Vehicle");
        }
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle3)
        {
          currentVehicle1.FreezePosition = true;
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save Vehicle");
        }
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle4)
        {
          currentVehicle1.FreezePosition = true;
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save Vehicle");
        }
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle5)
        {
          currentVehicle1.FreezePosition = true;
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save Vehicle");
        }
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle6)
        {
          currentVehicle1.FreezePosition = true;
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save Vehicle");
        }
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle1 == (Entity) this.Vehicle7)
        {
          currentVehicle1.FreezePosition = true;
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save Vehicle");
        }
        if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          string str1 = "scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//";
          string str2 = "PersonalStorage";
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            Vehicle currentVehicle2 = Game.Player.Character.CurrentVehicle;
            if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle1)
            {
              UI.Notify(str1 + str2 + "//Slot1.ini");
              this.SC.LoadIniFile(str1 + str2 + "//Slot1.ini");
              this.SC.SaveWithoutDelete();
              UI.Notify(this.GetHostName() + " Saved Modifications to " + currentVehicle2.FriendlyName);
            }
            if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle2)
            {
              UI.Notify(str1 + str2 + "//Slot2.ini");
              this.SC.LoadIniFile(str1 + str2 + "//Slot2.ini");
              this.SC.SaveWithoutDelete();
              UI.Notify(this.GetHostName() + " Saved Modifications to " + currentVehicle2.FriendlyName);
            }
            if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle3)
            {
              UI.Notify(str1 + str2 + "//Slot3.ini");
              this.SC.LoadIniFile(str1 + str2 + "//Slot3.ini");
              this.SC.SaveWithoutDelete();
              UI.Notify(this.GetHostName() + " Saved Modifications to " + currentVehicle2.FriendlyName);
            }
            if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle4)
            {
              UI.Notify(str1 + str2 + "//Slot4.ini");
              this.SC.LoadIniFile(str1 + str2 + "//Slot4.ini");
              this.SC.SaveWithoutDelete();
              UI.Notify(this.GetHostName() + " Saved Modifications to " + currentVehicle2.FriendlyName);
            }
            if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle5)
            {
              UI.Notify(str1 + str2 + "//Slot5.ini");
              this.SC.LoadIniFile(str1 + str2 + "//Slot5.ini");
              this.SC.SaveWithoutDelete();
              UI.Notify(this.GetHostName() + " Saved Modifications to " + currentVehicle2.FriendlyName);
            }
            if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle6)
            {
              UI.Notify(str1 + str2 + "//Slot6.ini");
              this.SC.LoadIniFile(str1 + str2 + "//Slot6.ini");
              this.SC.SaveWithoutDelete();
              UI.Notify(this.GetHostName() + " Saved Modifications to " + currentVehicle2.FriendlyName);
            }
            if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle7)
            {
              UI.Notify(str1 + str2 + "//Slot7.ini");
              this.SC.LoadIniFile(str1 + str2 + "//Slot7.ini");
              this.SC.SaveWithoutDelete();
              UI.Notify(this.GetHostName() + " Saved Modifications to " + currentVehicle2.FriendlyName);
            }
          }
        }
        if (Game.IsControlJustPressed(2, GTA.Control.Context) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle2 = Game.Player.Character.CurrentVehicle;
          if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle1)
          {
            this.Vehicle1 = (Vehicle) null;
            this.LoadCarinToRealWorld(this.Vehicle1);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle2)
          {
            this.Vehicle2 = (Vehicle) null;
            this.LoadCarinToRealWorld(this.Vehicle2);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle3)
          {
            this.Vehicle3 = (Vehicle) null;
            this.LoadCarinToRealWorld(this.Vehicle3);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle4)
          {
            this.Vehicle4 = (Vehicle) null;
            this.LoadCarinToRealWorld(this.Vehicle4);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle5)
          {
            this.Vehicle5 = (Vehicle) null;
            this.LoadCarinToRealWorld(this.Vehicle5);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle6)
          {
            this.Vehicle6 = (Vehicle) null;
            this.LoadCarinToRealWorld(this.Vehicle6);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle7)
          {
            this.Vehicle7 = (Vehicle) null;
            this.LoadCarinToRealWorld(this.Vehicle7);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
        }
      }
      if (this.HatchOpen && (Entity) this.OShatchBase != (Entity) null)
      {
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
        {
          this.Entry = this.OShatchBase.GetOffsetInWorldCoords(new Vector3(4.5f, 7f, 0.0f));
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 200.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.Entry, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 3.0)
          {
            if (this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl) == 0)
              this.DisplayHelpTextThisFrame("Purchase this Business via ~g~ HKH191s Business Helper ~w~~INPUT_CONTEXT~ Set Waypoint to Marker");
            else
              this.DisplayHelpTextThisFrame("Press  ~INPUT_CONTEXT~  to Enter Facility ~INPUT_COVER~ to Open Vehicle Save Menu");
          }
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Entry = this.OShatchBase.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f));
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 200.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.Entry, Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 1f), this.MarkerColor);
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Entry) < 3.0)
          {
            if (this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl) == 0)
              this.DisplayHelpTextThisFrame("Purchase this Business via ~g~ HKH191s Business Helper ~w~~INPUT_CONTEXT~ Set Waypoint to Marker");
            else
              this.DisplayHelpTextThisFrame("Press  ~INPUT_CONTEXT~  to Enter Facility ~INPUT_COVER~ to Open Vehicle Save Menu");
          }
        }
      }
      if (this.UseOldMarker && (double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) < 3.0)
        this.DisplayHelpTextThisFrame("Press  ~INPUT_CONTEXT~ to Open Menu");
      if (!this.isInInterior && this.mainMenu.Visible)
        this.modMenuPool.CloseAllMenus();
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(470.8091f, 4837.7f, -54.9f)) < 200.0)
      {
        World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(470.8091f, 4837.7f, -54.9f), Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(470.8091f, 4837.7f, -54.9f)) < 2.0)
        {
          this.DisplayHelpTextThisFrame("Press  ~INPUT_CONTEXT~ to Open Vehicle Remove Menu");
          if (Game.IsControlJustPressed(2, GTA.Control.Context) && !this.RemoveMenu.Visible)
            this.RemoveMenu.Visible = !this.RemoveMenu.Visible;
        }
      }
      if (this.isInInterior)
      {
        if (this.UseOldMarker)
          World.DrawMarker(MarkerType.VerticalCylinder, this.MenuMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
        if (this.GunlockerBought == 1)
          World.DrawMarker(MarkerType.VerticalCylinder, this.Gunlockerpos, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
        if (this.VehicleBayBought == 1)
        {
          World.DrawMarker(MarkerType.VerticalCylinder, this.SourcingMenu, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.MarkerColor);
          if ((double) World.GetDistance(Game.Player.Character.Position, this.SourcingMenu) < 3.0)
            this.DisplayHelpTextThisFrame("Press  ~INPUT_CONTEXT~ to Open Menu");
        }
      }
      if ((Entity) this.VehicleToGet != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.VehicleToGet.Position) < 100.0)
      {
        this.VehicleToGet.IsVisible = true;
        this.VehicleToGet.IsInvincible = false;
      }
      if (this.VehicleSetup2)
      {
        if (this.vehiclemissionid == 10)
        {
          if ((Entity) this.VtoGet != (Entity) null && !this.VtoGet.IsAlive)
          {
            this.checkpointat = 7;
            if ((Entity) this.VtoGet != (Entity) null)
              this.VtoGet.Delete();
            if (this.VtoGetBlip != (Blip) null)
              this.VtoGetBlip.Remove();
            foreach (Ped guard in this.Guards)
            {
              if ((Entity) guard != (Entity) null)
                guard.Delete();
            }
            this.vehiclemissionid = 0;
            this.VehicleSetup2 = false;
            this.checkpointat = 0;
            UI.Notify(this.GetHostName() + " hmm ok we will have to replan this job ");
          }
          if ((Entity) this.VtoGet != (Entity) null && this.VtoGet.IsAlive)
          {
            if (this.checkpointat == 1 && (double) World.GetDistance(Game.Player.Character.Position, new Vector3(-1293f, 6589f, -105f)) < 250.0)
            {
              this.checkpointat = 2;
              this.VtoGet = (Vehicle) null;
              this.VtoGet = World.CreateVehicle((Model) VehicleHash.Stromberg, new Vector3(-1291f, 6875f, -69f), 0.0f);
              this.VtoGet.FreezePosition = true;
              this.VtoGet.LockStatus = VehicleLockStatus.Locked;
            }
            if (this.checkpointat == 0 && this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
            {
              this.checkpointat = 1;
              UI.Notify(this.GetHostName() + " Ok Excelent, head over to the Submarines location and dive down and retrieve the keys from the interior ");
            }
            if (this.checkpointat == 2)
            {
              if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(514f, 4888f, -62f)) < 10.0)
              {
                this.checkpointat = 3;
                this.Guards.Add(World.CreatePed((Model) PedHash.Armymech01SMY, new Vector3(514f, 4838f, -62f)));
                this.Guards.Add(World.CreatePed((Model) PedHash.ArmLieut01GMM, new Vector3(516f, 4834f, -62f)));
                this.Guards.Add(World.CreatePed((Model) PedHash.Armymech01SMY, new Vector3(513f, 4848f, -62f)));
                this.Guards.Add(World.CreatePed((Model) PedHash.Armymech01SMY, new Vector3(514f, 4876f, -62f)));
                this.Guards.Add(World.CreatePed((Model) PedHash.Armymech01SMY, new Vector3(517f, 4827f, -66f)));
                this.Guards.Add(World.CreatePed((Model) PedHash.Armymech01SMY, new Vector3(511f, 4839f, -66f)));
                this.Guards.Add(World.CreatePed((Model) PedHash.Armymech01SMY, new Vector3(513f, 4844f, -68f)));
                this.Guards.Add(World.CreatePed((Model) PedHash.Armymech01SMY, new Vector3(514f, 4824f, -68f)));
                foreach (Ped guard in this.Guards)
                {
                  guard.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
                  guard.RelationshipGroup = 4;
                  guard.IsEnemy = true;
                }
              }
              if (this.checkpointat == 3 || this.checkpointat == 4)
              {
                foreach (Ped guard in this.Guards)
                {
                  guard.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
                  Ped ped = guard;
                  int num1 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
                  Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) guard, (InputArgument) num1);
                
