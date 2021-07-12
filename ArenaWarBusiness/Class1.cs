using GTA;
using GTA.Math;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ArenaWarBusiness
{
  public class Class1 : Script
  {
    public BlipColor Blip_Colour;
    private ScriptSettings MainConfigFile;
    private bool firstTime = true;
    public Vector3 MarkerEnter;
    public Vector3 MarkerExit;
    public Vector3 MenuMarker;
    public Vector3 RoofEnterMarker;
    public Vector3 RoofExitMarker;
    public Vector3 HeliSpawn;
    public Vector3 GarageMarker;
    public Vector3 CarSpawn;
    public Vector3 WherehouseMarker;
    public Vector3 WherehouseEnter;
    private ScriptSettings Config;
    private ScriptSettings OnlineInteriorsConfig;
    private Keys Key1;
    public Vector3 BuyMarker;
    public Vector3 BuyMarker2;
    public int num;
    private MenuPool modMenuPool;
    private UIMenu Missions;
    private UIMenu VehicleGaragePool;
    private UIMenu mainMenu;
    private UIMenu methgarage;
    private UIMenu VehicleWherehouseOptions;
    private UIMenu ProductStock;
    public bool bought;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public int stockstimer;
    public int waittime;
    public int DisplayWait;
    public bool EnemySetup;
    public int Chooseenemynum;
    public Vehicle VehicleId;
    public bool VehicleSetup;
    private List<WeaponHash> weapons = Enum.GetValues(typeof (WeaponHash)).Cast<WeaponHash>().ToList<WeaponHash>();
    public string carid;
    public int vehiclemissionid;
    public bool setupdelivery;
    public Vector3 DeliveryMaker;
    public Blip DeliveryLoc;
    public Blip ballasBlip1;
    public Vector3 Deliverypoint;
    public UIMenu Garage;
    public UIMenu Sourcingmenu;
    public UIMenu SupplyRunsmenu;
    public UIMenu OrganizationOptions;
    public bool setupwantedfordelivery;
    public int waittimeforwanted;
    public Vehicle AirVehicle;
    public int BuzzardBought;
    public int FMJBought;
    public int A911Bought;
    public int X80Bought;
    public int SEVEN70Bought;
    public int wherehosuebought;
    public int cargaragebought;
    public VehicleHash VehicleIdentifier;
    public Vehicle VehicleName;
    public bool foundvehicleyet;
    public Vector3 Vehicleloc;
    public Blip VehicleMarker;
    public Vehicle Vehicletoget;
    public Vector3 VehicleSpawn;
    public bool hasgotvehicle;
    private Blip Enemy;
    private Ped EnemyPed;
    private Vector3 EnemyLoc;
    public System.Random VehicleLoc;
    public System.Random VehicleRan;
    public Vehicle VehicleMissioncar;
    public Vector3 VehicleLocation;
    public int Missionnum;
    public Blip DestoryVehicle;
    private System.Random RandomWanted;
    private System.Random randomwantedwait;
    private int triggerwanted;
    public int Aircraftstorage;
    public bool warnedplayer;
    public Vector3 AircraftStorageLoc;
    public Blip AircraftStorageMarker;
    public Blip VehicleWarehouseMarker;
    public int GunLockerBought;
    public int MoneyVaultBought;
    public int DockBought;
    public int VehicleLotBought;
    public Vector3 Dockloc;
    public Blip DockBlip;
    public Vector3 LotLoc;
    public Blip LotBlip;
    public float SourcingPayout;
    public bool SourcingCheckingforDamage;
    public int AATrailerABought;
    public int AATrailerBBought;
    public int AATrailerCBought;
    public string OrganizationName;
    public UIMenu AssetRecoveryMenu;
    public bool TriggeredWanted;
    public int ValkyrieBought;
    public int AkulaBought;
    public int HunterBought;
    public int SavageBought;
    public int AnnihilatorBought;
    public Blip ConvoyBlip1;
    public Blip ConvoyBlip2;
    public Blip ConvoyBlip3;
    public int convoysetup;
    public bool checkforconvoy;
    public int UseCustomWaitTime;
    public bool setWaittime;
    public Vector3 Radiopos;
    public int turretedlimo;
    public int assassinationmission;
    public int assassinationpayout;
    public Blip TowerBlip;
    public Blip TowerBlip2;
    public Blip TowerBlip3;
    public string Design;
    public UIMenu Sourcingmenu2;
    public string SourcedVehicle;
    public bool NewVehicleSourcing;
    public float increaseGain;
    public AllStocks Allstocks;
    public UIMenu SpecialMissions;
    public List<Ped> Guards = new List<Ped>();
    public List<Ped> Driver = new List<Ped>();
    public Vehicle VtoGet;
    public Blip VtoGetBlip;
    public Blip VtoGetBlip1;
    public Blip VtoGetBlip2;
    public Blip VtoGetBlip3;
    public Blip VtoGetBlip4;
    public Blip VtoGetBlip5;
    public Blip VtoGetBlip6;
    public Blip VtoGetBlip7;
    public bool GotCar;
    public Vehicle VtoGet1;
    public Vehicle VtoGet2;
    public Vehicle VtoGet3;
    public Vehicle VtoGet4;
    public Vehicle VtoGet5;
    public Vehicle VtoGet6;
    public Vehicle VtoGet7;
    public int Vehiclesleft;
    public Blip DropzoneBlip;
    public Vector3 Dropzone;
    public bool VehicleisDamaged;
    public int Vehiclehealth;
    public Vehicle RentedVehicle;
    public bool startedRent;
    public int RentTimer;
    public int RentalvehicleHealth;
    public bool ISinPiracyScamMission;
    public int Piracymission;
    public int TimerLeft;
    public VehicleHash RandomVehicle;
    public bool HackhasStarted;
    public Vector3 GoPoint;
    public int StockTimer;
    public int StockTimer2;
    public float stocktoloose;
    public UIMenu PointtoPointMenu;
    private MenuPool GarageMenuPool;
    public UIMenu GarageMenu;
    public UIMenu VehicleMenu;
    public Vector3 GarageMenuSpawn;
    public bool IsInInterior;
    public SaveCar SC;
    public string Loadpath = "scripts//HKH191sBusinessMods//ArenaWarBusiness//Vehicles//";
    public Vector3 GarageAMarkerOuside = new Vector3(-365f, -1871f, 19f);
    public Vector3 GarageBMarkerOuside = new Vector3(-388f, -1880f, 19.52f);
    public Vector3 GarageAMarkerInside = new Vector3(172f, 5163f, 10f);
    public Vector3 GarageBMarkerInside = new Vector3(172f, 5216f, 10f);
    public Vector3 GarageAMarkerExit = new Vector3(172f, 5217f, 10f);
    public Vector3 GarageBMarkerExit;
    public Vector3 SecondEntry = new Vector3(168f, 5210f, -90f);
    public Vector3 Racemarker2 = new Vector3(2800f, -3800f, 140f);
    public bool isinsecondVehicleBay;
    private MenuPool GarageMenuPool2;
    public UIMenu GarageMenu2;
    public UIMenu VehicleMenu2;
    public Vector3 VehicleBayMarker = new Vector3(169f, 5157f, -90f);
    public float vehiclehealth;
    public List<string> NStadium;
    public int timer;
    public int TimeLeft;
    public float moneytobeawarded;
    public Vector3 RamdomLocationVar;
    public Vector3 CheckPointPosition;
    public int CheckPointsreached;
    public Vector3 MineLoc1;
    public Vector3 MineLoc2;
    public Vector3 MineLoc3;
    public Vector3 MineLoc4;
    public Vector3 MineLoc5;
    public Vector3 MineLoc6;
    public Vector3 MineLoc7;
    public Vector3 MineLoc8;
    public Vector3 MineLoc9;
    public int missiletimer;
    public Vector3 ArenaExit = new Vector3(2810f, -3897f, 139f);
    public Vector3 ArenaEntry = new Vector3(221f, 5180f, -89f);
    private MenuPool ArenaGarageMenuPool;
    public UIMenu ArenaGarageMenu;
    public UIMenu ArenaVehicleMenu;
    public Vector3 ArenaVehicleMenuMarker = new Vector3(-394f, -1871f, 19f);
    public Vector3 ArenaVehicleMarker = new Vector3(2815f, -3909f, 140f);
    public List<Ped> Peds;
    public Vector3 StadiumUpperExit = new Vector3(211.903f, 5199.94f, -89.59f);
    public Vector3 StadiumUpperEntry = new Vector3(-242.472f, -1995.96f, 24f);
    public Vector3 VipEntry = new Vector3(217.034f, 5159.5f, -90f);
    public Vector3 VipExit = new Vector3(2797.71f, -3942.01f, 184f);
    public UIMenu DeathMatch;
    public Vector3 Startpos;
    public int vehicleHealth;
    public UIMenu RCKing;
    public UIMenu DeathMatch2;
    public List<Blip> PedBlips;
    public Vector3 JackpotTable = new Vector3(2796.17f, -3933.43f, 182f);
    public bool lockz;
    public Vector3 EndPointPos = new Vector3(-382f, -1835f, 20f);
    public bool SetupPed;
    public int PedsCounted;
    public Vector3 CarSpawn1;
    public Vector3 CarSpawn2;
    public Vector3 CarSpawn3;
    public Vector3 CarSpawn4;
    public string MarkerColorString;
    public Color MarkerColor;
    public int Timer2;
    public bool DropedVehicleA;
    public bool DropedVehicleB;
    public bool DropedVehicleC;
    public List<Vehicle> VehiclestoCarryA;
    public List<Vehicle> VehiclestoCarryB;
    public List<Vehicle> VehiclestoCarryC;
    private UIMenu VehicleSoccer;
    private UIMenu SmashandGrab;
    public Vector3 Goal1 = new Vector3(2665f, -3800f, 140f);
    public Vector3 Goal2 = new Vector3(2926f, -3800f, 140f);
    public UIMenu HotRing;
    public Vector3 TargettoFireAt;
    public List<Vector3> TrapsPos;
    public bool UseMIssilesInVDM;
    public int CheckPointstoProceed;
    public List<int> HeadlightColor;
    public UIMenu VehicleLoadMenu;
    public Vector3 SleepPos = new Vector3(209f, 5164f, -90f);
    public Vector3 CharacterSwitchPos = new Vector3(205.8f, 5165.22f, -90.4f);
    public Vector3 Sitpos = new Vector3(210f, 5166.3f, -87f);
    public Vector3 CurrentPos;
    public bool isSeated;
    public string SeatDict;
    public bool IsSitting;
    public UIMenu BeastWars;
    public Vehicle PLayerVehicle2;
    public Ped Friendlyped;
    public Vector3 DrinkPos = new Vector3(2810f, -3929f, 183f);
    public Vehicle Cerberus;
    public int CurrentCerberus;
    public int NightmareCerberusBought;
    public int ApocalypseCerberusBought;
    public int FutureShockCerberusBought;
    public Vector3 CerberusSpawn = new Vector3(159f, 5180f, -90f);
    public Vehicle Scarab;
    public int CurrentScarab;
    public int NightmareScarabBought;
    public int ApocalypseScarabBought;
    public int FutureShockScarabBought;
    public Vector3 ScarabSpawn = new Vector3(178f, 5189.4f, -90f);
    public Vehicle Dominator;
    public int CurrentDominator;
    public int NightmareDominatorBought;
    public int ApocalypseDominatorBought;
    public int FutureShockDominatorBought;
    public Vector3 DominatorSpawn = new Vector3(161f, 5171f, -90f);
    public Vehicle Imperator;
    public int CurrentImperator;
    public int NightmareImperatorBought;
    public int ApocalypseImperatorBought;
    public int FutureShockImperatorBought;
    public Vector3 ImperatorSpawn = new Vector3(177f, 5171f, -90f);
    public Vehicle Deathbike;
    public int CurrentDeathbike;
    public int NightmareDeathbikeBought;
    public int ApocalypseDeathbikeBought;
    public int FutureShockDeathbikeBought;
    public Vector3 DeathbikeSpawn = new Vector3(159f, 5158f, -90f);
    public Vehicle Issi;
    public int CurrentIssi;
    public int NightmareIssiBought;
    public int ApocalypseIssiBought;
    public int FutureShockIssiBought;
    public Vector3 IssiSpawn = new Vector3(160f, 5201f, -90f);
    public Vehicle Monster;
    public int CurrentMonster;
    public int NightmareMonsterBought;
    public int ApocalypseMonsterBought;
    public int FutureShockMonsterBought;
    public Vector3 MonsterSpawn = new Vector3(160f, 5189f, -90f);
    public Vehicle Impaler;
    public int CurrentImpaler;
    public int NightmareImpalerBought;
    public int ApocalypseImpalerBought;
    public int FutureShockImpalerBought;
    public Vector3 ImpalerSpawn = new Vector3(178f, 5201f, -90f);
    public Vehicle Slamvan;
    public int CurrentSlamvan;
    public int NightmareSlamvanBought;
    public int ApocalypseSlamvanBought;
    public int FutureShockSlamvanBought;
    public Vector3 SlamvanSpawn = new Vector3(160f, 5207f, -90f);
    public Vehicle Bruitus;
    public int CurrentBruitus = 1;
    public int NightmareBruitusBought = 1;
    public int ApocalypseBruitusBought = 1;
    public int FutureShockBruitusBought = 1;
    public Vector3 BruitusSpawn = new Vector3(178f, 5158f, -90f);
    public Vehicle Bruiser;
    public int CurrentBruiser;
    public int NightmareBruiserBought;
    public int ApocalypseBruiserBought;
    public int FutureShockBruiserBought;
    public Vector3 BruiserSpawn = new Vector3(159f, 5187f, 10f);
    public Vehicle ZR380;
    public int CurrentZR380;
    public int NightmareZR380Bought;
    public int ApocalypseZR380Bought;
    public int FutureShockZR380Bought;
    public Vector3 ZR380Spawn = new Vector3(182f, 5187f, 10f);
    public Vehicle Clique;
    public int CliqueBought;
    public Vector3 CliqueSpawn = new Vector3(180f, 5196f, 10f);
    public Vehicle Italigto;
    public int ItaligtoBought;
    public Vector3 ItaligtoSpawn = new Vector3(163f, 5196f, 10f);
    public Vehicle Tulip;
    public int TulipBought;
    public Vector3 TulipSpawn = new Vector3(163.48f, 5208.43f, 10f);
    public Vehicle Vamos;
    public int VamosBought;
    public Vector3 VamosSpawn = new Vector3(164.1225f, 5214.5f, 10f);
    public Vehicle Schlagen;
    public int SchlagenBought;
    public Vector3 SchlagenSpawn = new Vector3(180f, 5208f, 10f);
    public Vehicle Deviant;
    public int DeviantBought;
    public Vector3 DeviantSpawn = new Vector3(163f, 5177f, 10f);
    public Vehicle Toros;
    public int TorosBought;
    public Vector3 TorosSpawn = new Vector3(181.2755f, 5177.701f, 10f);
    public Vehicle Deveste;
    public int DevesteBought;
    public Vector3 DevesteSpawn = new Vector3(163f, 5165f, 10f);
    public Vehicle RcBandito;
    public int RcBanditoBought;
    public Vector3 RcBanditoSpawn = new Vector3(182f, 5165f, 11f);
    public Vector3 EnterMarkerA;
    public Vector3 EnterMarkerB;
    public Vector3 EnterMarkerC;
    public Vector3 ExitMarker;
    public Vector3 Vehicle1Loc = new Vector3(159f, 5187f, 10f);
    public Vehicle Vehicle1;
    public Vector3 Vehicle2Loc = new Vector3(162f, 5196f, 10f);
    public Vehicle Vehicle2;
    public Vector3 Vehicle3Loc = new Vector3(163f, 5208f, 10f);
    public Vehicle Vehicle3;
    public Vector3 Vehicle4Loc = new Vector3(163f, 5214f, 10f);
    public Vehicle Vehicle4;
    public Vector3 Vehicle5Loc = new Vector3(180f, 5208f, 10f);
    public Vehicle Vehicle5;
    public Vector3 Vehicle6Loc = new Vector3(181f, 5196f, 10f);
    public Vehicle Vehicle6;
    public Vector3 Vehicle7Loc = new Vector3(183f, 5187f, 10f);
    public Vehicle Vehicle7;
    public Vector3 Vehicle8Loc = new Vector3(181f, 5177f, 10f);
    public Vehicle Vehicle8;
    public Vector3 Vehicle9Loc = new Vector3(181f, 5165f, 10f);
    public Vehicle Vehicle9;
    public Vector3 Vehicle10Loc = new Vector3(163f, 5165f, 10f);
    public Vehicle Vehicle10;
    public Vector3 OutsideMenuMarker = new Vector3(-371.8876f, -1850f, 21f);
    private MenuPool PlayerGaragemodMenuPool;
    private UIMenu PlayerGarageMenu;
    private UIMenu PlayerGaragemainMenu;
    public Vector3 EntryMarker = new Vector3(-365f, -1871f, 20f);
    public Vector3 ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
    private string path = "scripts//HKH191sBusinessMods//ArenaWarBusiness//PlayerGarage//";
    public Vehicle SaveVehicle;
    public Vector3 RemoveMarker = new Vector3(172.388f, 5186.858f, 10f);
    public Vector3 ExitMarker3 = new Vector3(172f, 5216f, 10f);
    public Vector3 GarageAEntryOutside = new Vector3(-365f, -1817f, 19f);
    private MenuPool RemoveMenuPool2;
    private UIMenu RemoveMenu;
    private UIMenu mainMenu2;
    public string GarageNum;
    public bool isInGarage;
    public Vector3 EnterGarageMarker = new Vector3(-371.8876f, -1850f, 21f);
    public Vector3 GarageEntry = new Vector3(-364.8876f, -1871f, 19.52f);
    public float VehicleABet;
    public float VehicleBBet;
    public float VehicleCBet;
    public float VehicleDBet;
    public Vehicle VehicleATarget;
    public Vehicle VehicleBTarget;
    public Vehicle VehicleCTarget;
    public Vehicle VehicleDTarget;
    public bool IsSpectatingMatch;
    public bool MissionSetup;
    public int MissionId;
    public int Race;
    public Vector3 FinishLine;
    public Vehicle VehicleA;
    public Vehicle VehicleB;
    public Vehicle VehicleC;
    public Vector3 RaceMarker;
    public int PlayersPos;
    public bool StartedRace;
    public bool IsLeading;
    public bool FinishedRace;
    public bool inRace;
    public Blip RaceBlip;
    public Blip FinishLineBLip;
    public int checkpointReaced;
    public bool TimeTrialOn;
    public UIMenu TimeTrial;
    public int TimeTrialTimer;
    public int TimeTrialTime;
    public VehicleHash VehicleChoosen;
    public int Damage;
    public int Damage2;
    public int CheckDamage;
    public bool IsCheck;
    public Vehicle Semi;
    public Vehicle Trailer;
    public UIMenu longhaul;
    public Vector3 Spawn = new Vector3(-50.3f, -1074f, 27f);
    public Vector3 End;
    public Blip EndPoint;
    public UIMenu Rivals;
    public UIMenu SpeedCam;
    public float Speedtobeat;
    public bool ClearVehiclsinRivalsRace;
    public Vector3 PointA;
    public Vector3 CheckPoint;
    public bool AiatCheckpoint;
    public Vehicle Chaser2;
    public bool ChaserActive;
    public int lap;
    public int checkpoint;
    public Vector3[] Route;
    public bool CircuitRace;
    public bool CircuitRace2;
    public int ACheck;
    public int BCheck;
    public int CCheck;
    public int Alap;
    public int Blap;
    public int Clap;
    public Vehicle PLayerVehicle;
    public bool PedsDieinPufofSmoke;
    public bool GotCargo;
    public UIMenu DemoltionMenMenu;
    private ScriptSettings ScriptConfig;
    public MenuPool ArenaMenuPool;
    public UIMenu ArenaMainMenu;
    public UIMenu ArenaMenu;
    public Vector3 ArenaMenuMarker = new Vector3(2789.97f, -3903.44f, 139f);
    public List<Prop> Props = new List<Prop>();
    public List<Vehicle> ExtraV = new List<Vehicle>();
    public List<Prop> Trap_Mines = new List<Prop>();
    public List<Prop> Trap_Spike = new List<Prop>();
    public List<Prop> Trap_Flipper = new List<Prop>();
    public List<Prop> Trap_Flipper2 = new List<Prop>();
    public List<Prop> Trap_Flame = new List<Prop>();
    public List<Prop> Trap_Turning = new List<Prop>();
    public List<Prop> Trap_GunTower = new List<Prop>();
    public UIMenu SkyWars;
    public UIMenu ChampionchipMatch;
    public UIMenu TurretMayhem;
    public bool TriggerEscape;
    public bool IsScriptEnabled;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    public float BusinessUpgradeIncreaseGain = 75000f;
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
    public Vehicle Sam1;
    public Vehicle Sam2;
    public Vehicle Sam3;
    public Blip Sam1blip;
    public Blip Sam2blip;
    public Blip Sam3blip;
    public Blip EndPointBlip;
    public Vector3 EndPointVec;
    public bool UseOldMarker = false;
    public Vector3 ChairPos = new Vector3(204.5093f, 5165.092f, -86.4f);
    public float P_Rotation = 0.0f;
    public Prop ChairProp;
    public bool IsSittinginCeoSeat;
    private MenuPool EImodMenuPool;
    private UIMenu EImainMenu;
    private UIMenu EIInteriorOptions;
    public List<string> Workshop = new List<string>();
    public List<string> B1Garage = new List<string>();
    public string WorkGraphic;
    public string WorkOff;
    public string WorkMechanic;
    public int WColor;
    public int WColor1;
    public bool WLiving;
    public bool nopeds;
    public Vector3 Marker = new Vector3(221.088f, 5168.41f, -89.59f);
    public string LoadPath = "scripts//HKH191sBusinessMods//ArenaWarBusiness//Interior//Main.ini";
    public List<string> TrinketsAndTrophies = new List<string>();
    public bool TrinketsAndTrophiesEnabled;
    private UIMenu weaponsMenu;
    public Vector3 GunLockerMarker = new Vector3(209.179f, 5162.07f, -87f);
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
    private UIMenu Scifi;
    private MenuPool GLmodMenuPool;
    private UIMenu GLmainMenu;
    public int Tintscount = 32;
    private Keys Key3;
    private MenuPool MVmodMenuPool;
    private UIMenu MVmainMenu;
    public float MoneyStored;
    public float Commission;
    public UIMenu MoneyMenu;
    public Vector3 MoneyStorageMarker = new Vector3(195f, 5191f, -90f);
    public int currentbank;
    public bool read;
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public int LiveryColor;
    public float M = 0.0f;
    public string Price = "000";
    public string Model = "";
    public string man = "";
    public string ListPath = "scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\MilitaryTrader\\AllVehicles.ini";
    public Vehicle Current;
    public Vehicle LastVehicle;
    public bool EffectOn;
    public bool Createchair;
    public bool Getcolor;
    public Prop ComputerProp;
    public string ChairPropModel = "ex_prop_offchair_exec_01";
    public bool ChoosenToUpgradeVeh;
    public float screenaspectratio;
    public Vector2 MousePosXY;
    public bool isModifingStockVehicle;

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
        if (this.MarkerColorString.Contains("ARGB"))
          return;
        this.MarkerColor = Color.FromName(this.MarkerColorString);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    public void SetupStadium()
    {
      this.NStadium = new List<string>();
      this.NStadium.Add("Set_Pit_Fence_Closed");
      this.NStadium.Add("Set_Pit_Fence_Demolition");
      this.NStadium.Add("Set_Pit_Fence_Oval");
      this.NStadium.Add("set_pit_fence_ovala");
      this.NStadium.Add("set_pit_fence_ovalb");
      this.NStadium.Add("Set_Pit_Fence_Wall");
      this.NStadium.Add("set_wall_no_pit");
      this.NStadium.Add("set_centreline_dystopian_05");
      this.NStadium.Add("set_centreline_scifi_05");
      this.NStadium.Add("Set_CentreLine_Wasteland_05");
      this.NStadium.Add("Set_Turrets");
      this.NStadium.Add("set_turrets_scifi");
      this.NStadium.Add("set_turrets_wasteland");
      this.NStadium.Add("Set_Team_Band_A");
      this.NStadium.Add("Set_Team_Band_B");
      this.NStadium.Add("Set_Team_Band_C");
      this.NStadium.Add("Set_Team_Band_D");
      this.NStadium.Add("Set_Lights_atlantis");
      this.NStadium.Add("Set_Lights_evening");
      this.NStadium.Add("Set_Lights_hell");
      this.NStadium.Add("Set_Lights_midday");
      this.NStadium.Add("Set_Lights_morning");
      this.NStadium.Add("Set_Lights_night");
      this.NStadium.Add("set_lights_sfnight");
      this.NStadium.Add("Set_Lights_saccharine");
      this.NStadium.Add("Set_Lights_sandstorm");
      this.NStadium.Add("Set_Lights_storm");
      this.NStadium.Add("Set_Lights_toxic");
      this.NStadium.Add("Set_Dystopian_01");
      this.NStadium.Add("Set_Dystopian_02");
      this.NStadium.Add("Set_Dystopian_03");
      this.NStadium.Add("Set_Dystopian_04");
      this.NStadium.Add("Set_Dystopian_05");
      this.NStadium.Add("Set_Dystopian_06");
      this.NStadium.Add("Set_Dystopian_07");
      this.NStadium.Add("Set_Dystopian_08");
      this.NStadium.Add("Set_Dystopian_09");
      this.NStadium.Add("Set_Dystopian_10");
      this.NStadium.Add("Set_Dystopian_11");
      this.NStadium.Add("Set_Dystopian_12");
      this.NStadium.Add("Set_Dystopian_13");
      this.NStadium.Add("Set_Dystopian_14");
      this.NStadium.Add("Set_Dystopian_15");
      this.NStadium.Add("Set_Dystopian_16");
      this.NStadium.Add("Set_Dystopian_17");
      this.NStadium.Add("Set_Scifi_01");
      this.NStadium.Add("Set_Scifi_02");
      this.NStadium.Add("Set_Scifi_03");
      this.NStadium.Add("Set_Scifi_04");
      this.NStadium.Add("Set_Scifi_05");
      this.NStadium.Add("Set_Scifi_06");
      this.NStadium.Add("Set_Scifi_07");
      this.NStadium.Add("Set_Scifi_08");
      this.NStadium.Add("Set_Scifi_09");
      this.NStadium.Add("Set_Scifi_10");
      this.NStadium.Add("Set_Wasteland_01");
      this.NStadium.Add("Set_Wasteland_02");
      this.NStadium.Add("Set_Wasteland_03");
      this.NStadium.Add("Set_Wasteland_04");
      this.NStadium.Add("Set_Wasteland_05");
      this.NStadium.Add("Set_Wasteland_06");
      this.NStadium.Add("Set_Wasteland_07");
      this.NStadium.Add("Set_Wasteland_08");
      this.NStadium.Add("Set_Wasteland_09");
      this.NStadium.Add("Set_Wasteland_10");
      this.NStadium.Add("Set_Dystopian_Scene");
      this.NStadium.Add("Set_Scifi_Scene");
      this.NStadium.Add("Set_Wasteland_Scene");
      this.NStadium.Add("Set_Crowd_A");
      this.NStadium.Add("Set_Crowd_B");
      this.NStadium.Add("Set_Crowd_C");
      this.NStadium.Add("Set_Crowd_D");
    }

    public void SetupTrapsPositions()
    {
      this.TrapsPos = new List<Vector3>();
      this.TrapsPos.Add(new Vector3(2759.76f, -3849f, 130f));
      this.TrapsPos.Add(new Vector3(2814.76f, -3853f, 130f));
      this.TrapsPos.Add(new Vector3(2870.76f, -3852f, 130f));
      this.TrapsPos.Add(new Vector3(2925.76f, -3838f, 130f));
      this.TrapsPos.Add(new Vector3(2949f, -3799f, 130f));
      this.TrapsPos.Add(new Vector3(2925f, -3754f, 130f));
      this.TrapsPos.Add(new Vector3(2867f, -3744f, 130f));
      this.TrapsPos.Add(new Vector3(2800f, -3745f, 130f));
      this.TrapsPos.Add(new Vector3(2742f, -3746f, 130f));
      this.TrapsPos.Add(new Vector3(2688f, -3752f, 130f));
      this.TrapsPos.Add(new Vector3(2653f, -3782f, 130f));
      this.TrapsPos.Add(new Vector3(2657f, -3727f, 130f));
      this.TrapsPos.Add(new Vector3(2710.01f, -3856f, 130f));
      this.TrapsPos.Add(new Vector3(2740.01f, -3873f, 136f));
      this.TrapsPos.Add(new Vector3(2772.01f, -3874f, 136f));
      this.TrapsPos.Add(new Vector3(2822.01f, -3876f, 136f));
      this.TrapsPos.Add(new Vector3(2885.01f, -3875f, 136f));
      this.TrapsPos.Add(new Vector3(2934.01f, -3858f, 136f));
      this.TrapsPos.Add(new Vector3(2962.01f, -3806f, 136f));
      this.TrapsPos.Add(new Vector3(2950.01f, -3754f, 136f));
      this.TrapsPos.Add(new Vector3(2903.01f, -3726f, 136f));
      this.TrapsPos.Add(new Vector3(2776.01f, -3722f, 136f));
      this.TrapsPos.Add(new Vector3(2649f, -3760f, 136f));
      this.TrapsPos.Add(new Vector3(2638f, -3827f, 136f));
      this.TrapsPos.Add(new Vector3(2704f, -3876f, 136f));
    }

    public void SpawnProp(string Prop, Vector3 Pos, Vector3 Rot, int i)
    {
      try
      {
        GTA.Model model = new GTA.Model(Prop);
        model.Request(250);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(50);
          World.GetNearbyProps(Pos, 100f, model);
          Prop prop = World.CreateProp(model, Pos, Rot, false, false);
          prop.FreezePosition = true;
          this.Props.Add(prop);
        }
        model.MarkAsNoLongerNeeded();
      }
      catch (Exception ex)
      {
        UI.Notify("~r~ Prop : ~w~" + Prop + "~r~ Failed to spawn");
      }
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

    public GTA.Model RequestModel(int Name)
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
      this.CheckHostName("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
      this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
      this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      string str = "~" + this.Uicolour + "~";
      return this.HostName;
    }

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("ArenaWarBusiness", "MazeBankArena", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: DisableBusiness.ini Failed To Load.");
      }
    }

    public Class1()
    {
      this.VehiclestoCarryA = new List<Vehicle>();
      this.VehiclestoCarryB = new List<Vehicle>();
      this.VehiclestoCarryC = new List<Vehicle>();
      this.HeadlightColor = new List<int>();
      this.PedBlips = new List<Blip>();
      this.Peds = new List<Ped>();
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
      this.LoadMain("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
      if (!this.IsScriptEnabled)
        return;
      this.Allstocks = new AllStocks();
      this.SC = new SaveCar();
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.CreateBanner();
      this.Setup();
    }

    private void SetupT_T()
    {
      this.TrinketsAndTrophies = new List<string>();
      this.TrinketsAndTrophies.Add("SET_XMAS_DECORATIONS");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_CAREER");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_SCORE");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_WAGEWORKER");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_TIME_SERVED");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_GOT_ONE");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_OUTTA_HERE");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_SHUNT");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_BOBBY");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_KILLED");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_CROWD");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_DUCK");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_BANDITO");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_SPINNER");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_LENS");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_WAR");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_UNSTOPPABLE");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_CONTACT");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_TOWER");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_STEP");
      this.TrinketsAndTrophies.Add("Set_Int_MOD_TROPHY_PEGASUS");
      this.TrinketsAndTrophies.Add("SET_BANDITO_RC");
      this.TrinketsAndTrophies.Add("SET_OFFICE_TRINKET_07");
      this.TrinketsAndTrophies.Add("SET_OFFICE_TRINKET_06");
      this.TrinketsAndTrophies.Add("SET_OFFICE_TRINKET_03");
      this.TrinketsAndTrophies.Add("SET_OFFICE_TRINKET_04");
      this.TrinketsAndTrophies.Add("SET_OFFICE_TRINKET_02");
    }

    public void SetupInteriorDesignsMenu()
    {
      List<object> listofDesigns = new List<object>();
      listofDesigns.Add((object) "Set_Mod1_Style_01");
      listofDesigns.Add((object) "Set_Mod1_Style_02");
      listofDesigns.Add((object) "Set_Mod1_Style_03");
      listofDesigns.Add((object) "Set_Mod1_Style_04");
      listofDesigns.Add((object) "Set_Mod1_Style_05");
      listofDesigns.Add((object) "Set_Mod1_Style_06");
      listofDesigns.Add((object) "Set_Mod1_Style_07");
      listofDesigns.Add((object) "Set_Mod1_Style_08");
      listofDesigns.Add((object) "Set_Mod1_Style_09");
      List<object> listofOfficeDesigns = new List<object>();
      listofOfficeDesigns.Add((object) "SET_OFFICE_STANDARD");
      listofOfficeDesigns.Add((object) "SET_OFFICE_HITECH");
      listofOfficeDesigns.Add((object) "SET_OFFICE_INDUSTRIAL");
      List<object> listofMechanics = new List<object>();
      listofMechanics.Add((object) "Set_Int_MOD_BOOTH_DEF");
      listofMechanics.Add((object) "Set_Int_MOD_BOOTH_BEN");
      listofMechanics.Add((object) "Set_Int_MOD_BOOTH_WP");
      listofMechanics.Add((object) "Set_Int_MOD_BOOTH_COMBO");
      List<object> listofColors = new List<object>();
      listofColors.Add((object) "0");
      listofColors.Add((object) "1");
      listofColors.Add((object) "1");
      listofColors.Add((object) "2");
      listofColors.Add((object) "3");
      listofColors.Add((object) "4");
      listofColors.Add((object) "6");
      listofColors.Add((object) "7");
      listofColors.Add((object) "8");
      listofColors.Add((object) "9");
      UIMenu menu1 = this.EImodMenuPool.AddSubMenu(this.EIInteriorOptions, "Workshop");
      this.GUIMenus.Add(menu1);
      UIMenu uiMenu1 = this.EImodMenuPool.AddSubMenu(menu1, "Trinkets And Trophies");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.EImodMenuPool.AddSubMenu(menu1, "Design");
      this.GUIMenus.Add(uiMenu2);
      UIMenuListItem list1 = new UIMenuListItem("Design: ", listofDesigns, 0);
      uiMenu2.AddItem((UIMenuItem) list1);
      UIMenuItem GetDesign = new UIMenuItem("Get Design");
      uiMenu2.AddItem(GetDesign);
      UIMenu uiMenu3 = this.EImodMenuPool.AddSubMenu(menu1, "Office Design");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem list2 = new UIMenuListItem("Office Design: ", listofOfficeDesigns, 0);
      uiMenu3.AddItem((UIMenuItem) list2);
      UIMenuItem GetOfficeDesign = new UIMenuItem("Get Office Design");
      uiMenu3.AddItem(GetOfficeDesign);
      UIMenu uiMenu4 = this.EImodMenuPool.AddSubMenu(menu1, "Mechanic");
      this.GUIMenus.Add(uiMenu4);
      UIMenuListItem list3 = new UIMenuListItem("Mechanic: ", listofMechanics, 0);
      uiMenu4.AddItem((UIMenuItem) list3);
      UIMenuItem GetMechanic = new UIMenuItem("Mechanic");
      uiMenu4.AddItem(GetMechanic);
      UIMenu uiMenu5 = this.EImodMenuPool.AddSubMenu(menu1, "Main Color");
      this.GUIMenus.Add(uiMenu5);
      UIMenuListItem list4 = new UIMenuListItem("Color: ", listofColors, 0);
      uiMenu5.AddItem((UIMenuItem) list4);
      UIMenuItem GetColor1 = new UIMenuItem("Get Color");
      uiMenu5.AddItem(GetColor1);
      UIMenu menu2 = this.EImodMenuPool.AddSubMenu(this.EIInteriorOptions, "Workshop B1");
      this.GUIMenus.Add(menu2);
      UIMenu uiMenu6 = this.EImodMenuPool.AddSubMenu(menu2, "Main Color");
      this.GUIMenus.Add(uiMenu6);
      UIMenuListItem list5 = new UIMenuListItem("Color: ", listofColors, 0);
      uiMenu6.AddItem((UIMenuItem) list4);
      UIMenuItem GetColor2 = new UIMenuItem("Get Color");
      uiMenu6.AddItem(GetColor2);
      UIMenuItem EnableAll = new UIMenuItem("Enable All Trinkets And Trophies ");
      uiMenu1.AddItem(EnableAll);
      UIMenuItem DisableAll = new UIMenuItem("Disable All Trinkets And Trophies ");
      uiMenu1.AddItem(DisableAll);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == EnableAll)
        {
          this.TrinketsAndTrophiesEnabled = true;
          Game.Player.Character.FreezePosition = true;
          Script.Wait(100);
          this.ReloadInterior();
          Script.Wait(100);
          Game.Player.Character.FreezePosition = false;
          UI.Notify(this.GetHostName() + " All trinkets and Trophies have been enabled ");
        }
        if (item != DisableAll)
          return;
        this.TrinketsAndTrophiesEnabled = false;
        Game.Player.Character.FreezePosition = true;
        Script.Wait(100);
        this.ReloadInterior();
        Script.Wait(100);
        Game.Player.Character.FreezePosition = false;
        UI.Notify(this.GetHostName() + " All trinkets and Trophies have been disabled ");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != GetDesign)
          return;
        int index1 = list1.Index;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__590.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__590.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.WorkGraphic = Class1.\u003C\u003Eo__590.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__590.\u003C\u003Ep__0, listofDesigns[index1]);
        this.Config.SetValue<string>("Workshop", "WorkGraphic", this.WorkGraphic);
        this.Config.Save();
        this.Enableinterior();
        UI.Notify(this.GetHostName() + " Changed Interior, please reload mod to allow interior to refresh");
        Game.Player.Character.FreezePosition = true;
        Script.Wait(100);
        this.ReloadInterior();
        Script.Wait(100);
        Game.Player.Character.FreezePosition = false;
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != GetOfficeDesign)
          return;
        int index1 = list2.Index;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__590.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__590.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.WorkOff = Class1.\u003C\u003Eo__590.\u003C\u003Ep__1.Target((CallSite) Class1.\u003C\u003Eo__590.\u003C\u003Ep__1, listofOfficeDesigns[index1]);
        this.Config.SetValue<string>("Workshop", "WorkOff", this.WorkOff);
        this.Config.Save();
        this.Enableinterior();
        UI.Notify(this.GetHostName() + " Changed Interior, please reload mod to allow interior to refresh");
        Game.Player.Character.FreezePosition = true;
        Script.Wait(100);
        this.ReloadInterior();
        Script.Wait(100);
        Game.Player.Character.FreezePosition = false;
      });
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != GetMechanic)
          return;
        int index1 = list3.Index;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__590.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__590.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.WorkMechanic = Class1.\u003C\u003Eo__590.\u003C\u003Ep__2.Target((CallSite) Class1.\u003C\u003Eo__590.\u003C\u003Ep__2, listofMechanics[index1]);
        this.Config.SetValue<string>("Workshop", "WorkMechanic", this.WorkMechanic);
        this.Config.Save();
        this.Enableinterior();
        UI.Notify(this.GetHostName() + " Changed Interior, please reload mod to allow interior to refresh");
        Game.Player.Character.FreezePosition = true;
        Script.Wait(100);
        this.ReloadInterior();
        Script.Wait(100);
        Game.Player.Character.FreezePosition = false;
      });
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != GetColor1)
          return;
        int index1 = list4.Index;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__590.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__590.\u003C\u003Ep__3 = CallSite<Func<CallSite, System.Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Parse", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__590.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__590.\u003C\u003Ep__3, typeof (int), listofColors[index1]);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__590.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__590.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.WColor = Class1.\u003C\u003Eo__590.\u003C\u003Ep__4.Target((CallSite) Class1.\u003C\u003Eo__590.\u003C\u003Ep__4, obj);
        this.Config.SetValue<int>("Workshop", "WColor", this.WColor);
        this.Config.Save();
        this.Enableinterior();
        UI.Notify(this.GetHostName() + " Changed Interior, please reload mod to allow interior to refresh");
        Game.Player.Character.FreezePosition = true;
        Script.Wait(100);
        this.ReloadInterior();
        Script.Wait(100);
        Game.Player.Character.FreezePosition = false;
      });
      uiMenu6.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != GetColor2)
          return;
        int index1 = list5.Index;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__590.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__590.\u003C\u003Ep__5 = CallSite<Func<CallSite, System.Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Parse", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__590.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__590.\u003C\u003Ep__5, typeof (int), listofColors[index1]);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__590.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__590.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.WColor1 = Class1.\u003C\u003Eo__590.\u003C\u003Ep__6.Target((CallSite) Class1.\u003C\u003Eo__590.\u003C\u003Ep__6, obj);
        this.Config.SetValue<int>("Garage", "WColor1", this.WColor1);
        this.Config.Save();
        this.Enableinterior();
        UI.Notify(this.GetHostName() + " Changed Interior, please reload mod to allow interior to refresh");
        Game.Player.Character.FreezePosition = true;
        Script.Wait(100);
        this.ReloadInterior();
        Script.Wait(100);
        Game.Player.Character.FreezePosition = false;
      });
    }

    private void SetupWorkshop()
    {
      this.Workshop = new List<string>();
      this.Workshop.Add("Set_Int_MOD_BOOTH_DEF");
      this.Workshop.Add("Set_Int_MOD_BOOTH_BEN");
      this.Workshop.Add("Set_Int_MOD_BOOTH_WP");
      this.Workshop.Add("Set_Int_MOD_BOOTH_COMBO");
      this.Workshop.Add("Set_Int_MOD_BEDROOM_BLOCKER");
      this.Workshop.Add("Set_Int_MOD_CONSTRUCTION_01");
      this.Workshop.Add("Set_Int_MOD_CONSTRUCTION_02");
      this.Workshop.Add("Set_Int_MOD_CONSTRUCTION_03");
      this.Workshop.Add("SET_OFFICE_STANDARD");
      this.Workshop.Add("SET_OFFICE_INDUSTRIAL");
      this.Workshop.Add("SET_OFFICE_HITECH");
      this.Workshop.Add("Set_Mod1_Style_01");
      this.Workshop.Add("Set_Mod1_Style_02");
      this.Workshop.Add("Set_Mod1_Style_03");
      this.Workshop.Add("Set_Mod1_Style_04");
      this.Workshop.Add("Set_Mod1_Style_05");
      this.Workshop.Add("Set_Mod1_Style_06");
      this.Workshop.Add("Set_Mod1_Style_07");
      this.Workshop.Add("Set_Mod1_Style_08");
      this.Workshop.Add("Set_Mod1_Style_09");
      this.Workshop.Add("set_arena_peds");
      this.Workshop.Add("set_arena_no peds");
    }

    private void SetupB1Garage()
    {
    }

    public void Enableinterior()
    {
      this.LoadIniFile(this.LoadPath);
      int num1 = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 205f, (InputArgument) 5180f, (InputArgument) -90f);
      for (int index = 0; index < this.Workshop.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) this.Workshop[index]);
      for (int index = 0; index < this.TrinketsAndTrophies.Count; ++index)
      {
        if (this.TrinketsAndTrophiesEnabled)
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.TrinketsAndTrophies[index]);
        else if (!this.TrinketsAndTrophiesEnabled)
          Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) this.TrinketsAndTrophies[index]);
      }
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_Int_MOD_SHELL_DEF");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.WorkGraphic);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.WorkOff);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) this.WorkMechanic);
      if (!this.WLiving)
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_Int_MOD_BEDROOM_BLOCKER");
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) "Set_Int_MOD_SHELL_DEF", (InputArgument) this.WColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.WorkOff, (InputArgument) this.WColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.WorkMechanic, (InputArgument) this.WColor);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num1, (InputArgument) this.WorkGraphic, (InputArgument) this.WColor);
      if (!this.nopeds)
        Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "set_arena_no peds");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_mod_2");
      int num2 = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 170f, (InputArgument) 5190f, (InputArgument) 10f);
      for (int index = 0; index < 9; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num2, (InputArgument) this.WorkGraphic);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num2, (InputArgument) "Set_Int_MOD2_B2");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num2, (InputArgument) "Set_Int_MOD2_B_TINT");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num2, (InputArgument) "Set_Int_MOD2_B1");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num2, (InputArgument) this.WorkGraphic);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num2, (InputArgument) "Set_Int_MOD2_B_Tint", (InputArgument) this.WColor1);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num2, (InputArgument) "Set_Int_MOD2_B1", (InputArgument) this.WColor1);
      Function.Call((Hash) 3590001984630001091, (InputArgument) num2, (InputArgument) this.WorkGraphic, (InputArgument) this.WColor1);
    }

    public void ReloadInterior()
    {
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_mod");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_Mod_2");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_mod");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_vip");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_Mod_2");
      this.Enableinterior();
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.UseMIssilesInVDM = this.Config.GetValue<bool>("Setup", "UseMIssilesInVDM", this.UseMIssilesInVDM);
        this.Key1 = this.Config.GetValue<Keys>("Configurations", "Key1", this.Key1);
        this.MoneyVaultBought = this.Config.GetValue<int>("Setup", "MoneyVaultBought", this.MoneyVaultBought);
        this.Key3 = this.Config.GetValue<Keys>("ADDON2", "Key3", this.Key3);
        this.Commission = this.Config.GetValue<float>("ADDON2", "COMMISSION", this.Commission);
        this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
        this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
        this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.UseOldMarker = this.Config.GetValue<bool>("Setup", "UseOldMarker", this.UseOldMarker);
        this.BuzzardBought = this.Config.GetValue<int>("Setup", "BuzzardBought", this.BuzzardBought);
        this.FMJBought = this.Config.GetValue<int>("Setup", "FMJBought", this.FMJBought);
        this.A911Bought = this.Config.GetValue<int>("Setup", "911Bought", this.A911Bought);
        this.X80Bought = this.Config.GetValue<int>("Setup", "X80Bought", this.X80Bought);
        this.SEVEN70Bought = this.Config.GetValue<int>("Setup", "SEVEN70Bought", this.SEVEN70Bought);
        this.WorkGraphic = this.Config.GetValue<string>("Workshop", "WorkGraphic", this.WorkGraphic);
        this.WorkOff = this.Config.GetValue<string>("Workshop", "WorkOff", this.WorkOff);
        this.WorkMechanic = this.Config.GetValue<string>("Workshop", "WorkMechanic", this.WorkMechanic);
        this.WColor = this.Config.GetValue<int>("Workshop", "WColor", this.WColor);
        this.WColor1 = this.Config.GetValue<int>("Garage", "WColor1", this.WColor1);
        this.WLiving = this.Config.GetValue<bool>("Workshop", "WLiving", this.WLiving);
        this.nopeds = this.Config.GetValue<bool>("Workshop", "nopeds", this.nopeds);
        this.TrinketsAndTrophiesEnabled = this.Config.GetValue<bool>("Workshop", "TrinketsAndTrophiesEnabled", this.TrinketsAndTrophiesEnabled);
        this.GunLockerBought = this.Config.GetValue<int>("Setup", "GunLockerBought", this.GunLockerBought);
        this.MoneyVaultBought = this.Config.GetValue<int>("Setup", " MoneyVaultBought", this.MoneyVaultBought);
        this.AATrailerABought = this.Config.GetValue<int>("Setup", "AATrailerABought", this.AATrailerABought);
        this.AATrailerBBought = this.Config.GetValue<int>("Setup", "AATrailerBBought", this.AATrailerBBought);
        this.AATrailerCBought = this.Config.GetValue<int>("Setup", " AATrailerCBought", this.AATrailerCBought);
        this.ValkyrieBought = this.Config.GetValue<int>("Setup", "ValkyrieBought", this.ValkyrieBought);
        this.SavageBought = this.Config.GetValue<int>("Setup", "SavageBought", this.SavageBought);
        this.HunterBought = this.Config.GetValue<int>("Setup", "HunterBought", this.HunterBought);
        this.AkulaBought = this.Config.GetValue<int>("Setup", "AkulaBought", this.AkulaBought);
        this.AnnihilatorBought = this.Config.GetValue<int>("Setup", "AnnihilatorBought", this.AnnihilatorBought);
        this.UseCustomWaitTime = this.Config.GetValue<int>("Setup", "UseCustomWaitTime", this.UseCustomWaitTime);
        this.turretedlimo = this.Config.GetValue<int>("Setup", "turretedlimo", this.turretedlimo);
        this.Design = this.Config.GetValue<string>("Design", "InteriorDesign", this.Design);
        this.ChairPropModel = this.Config.GetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
        this.CurrentCerberus = this.Config.GetValue<int>("Vehicles", "CurrentCerberus", this.CurrentCerberus);
        this.CurrentScarab = this.Config.GetValue<int>("Vehicles", "CurrentScarab", this.CurrentScarab);
        this.CurrentDominator = this.Config.GetValue<int>("Vehicles", "CurrentDominator", this.CurrentDominator);
        this.CurrentImperator = this.Config.GetValue<int>("Vehicles", "CurrentImperator", this.CurrentImperator);
        this.CurrentDeathbike = this.Config.GetValue<int>("Vehicles", "CurrentDeathbike", this.CurrentDeathbike);
        this.CurrentIssi = this.Config.GetValue<int>("Vehicles", "CurrentIssi", this.CurrentIssi);
        this.CurrentMonster = this.Config.GetValue<int>("Vehicles", "CurrentMonster", this.CurrentMonster);
        this.CurrentImpaler = this.Config.GetValue<int>("Vehicles", "CurrentImpaler", this.CurrentImpaler);
        this.CurrentSlamvan = this.Config.GetValue<int>("Vehicles", "CurrentSlamvan", this.CurrentSlamvan);
        this.CurrentBruitus = this.Config.GetValue<int>("Vehicles", "CurrentBrutus", this.CurrentBruitus);
        this.CurrentZR380 = this.Config.GetValue<int>("Vehicles", "CurrentZR380", this.CurrentZR380);
        this.CurrentBruiser = this.Config.GetValue<int>("Vehicles", "CurrentBruiser", this.CurrentBruiser);
        this.NightmareCerberusBought = this.Config.GetValue<int>("Vehicles", "NightmareCerberusBought", this.NightmareCerberusBought);
        this.ApocalypseCerberusBought = this.Config.GetValue<int>("Vehicles", "ApocalypseCerberusBought", this.ApocalypseCerberusBought);
        this.FutureShockCerberusBought = this.Config.GetValue<int>("Vehicles", "FutureShockCerberusBought", this.FutureShockCerberusBought);
        this.NightmareScarabBought = this.Config.GetValue<int>("Vehicles", "NightmareScarabBought", this.NightmareScarabBought);
        this.ApocalypseScarabBought = this.Config.GetValue<int>("Vehicles", "ApocalypseScarabBought", this.ApocalypseScarabBought);
        this.FutureShockScarabBought = this.Config.GetValue<int>("Vehicles", "FutureShockScarabBought", this.FutureShockScarabBought);
        this.NightmareDominatorBought = this.Config.GetValue<int>("Vehicles", "NightmareDominatorBought", this.NightmareDominatorBought);
        this.ApocalypseDominatorBought = this.Config.GetValue<int>("Vehicles", "ApocalypseDominatorBought", this.ApocalypseDominatorBought);
        this.FutureShockDominatorBought = this.Config.GetValue<int>("Vehicles", "FutureShockDominatorBought", this.FutureShockDominatorBought);
        this.NightmareImperatorBought = this.Config.GetValue<int>("Vehicles", "NightmareImperatorBought", this.NightmareImperatorBought);
        this.ApocalypseImperatorBought = this.Config.GetValue<int>("Vehicles", "ApocalypseImperatorBought", this.ApocalypseImperatorBought);
        this.FutureShockImperatorBought = this.Config.GetValue<int>("Vehicles", "FutureShockImperatorBought", this.FutureShockImperatorBought);
        this.NightmareDeathbikeBought = this.Config.GetValue<int>("Vehicles", "NightmareDeathbikeBought", this.NightmareDeathbikeBought);
        this.ApocalypseDeathbikeBought = this.Config.GetValue<int>("Vehicles", "ApocalypseDeathbikeBought", this.ApocalypseDeathbikeBought);
        this.FutureShockDeathbikeBought = this.Config.GetValue<int>("Vehicles", "FutureShockDeathbikeBought", this.FutureShockDeathbikeBought);
        this.NightmareIssiBought = this.Config.GetValue<int>("Vehicles", "NightmareIssiBought", this.NightmareIssiBought);
        this.ApocalypseIssiBought = this.Config.GetValue<int>("Vehicles", "ApocalypseIssiBought", this.ApocalypseIssiBought);
        this.FutureShockIssiBought = this.Config.GetValue<int>("Vehicles", "FutureShockIssiBought", this.FutureShockIssiBought);
        this.NightmareMonsterBought = this.Config.GetValue<int>("Vehicles", "NightmareMonsterBought", this.NightmareMonsterBought);
        this.ApocalypseMonsterBought = this.Config.GetValue<int>("Vehicles", "ApocalypseMonsterBought", this.ApocalypseMonsterBought);
        this.FutureShockMonsterBought = this.Config.GetValue<int>("Vehicles", "FutureShockMonsterBought", this.FutureShockMonsterBought);
        this.NightmareImpalerBought = this.Config.GetValue<int>("Vehicles", "NightmareImpalerBought", this.NightmareImpalerBought);
        this.ApocalypseImpalerBought = this.Config.GetValue<int>("Vehicles", "ApocalypseImpalerBought", this.ApocalypseImpalerBought);
        this.FutureShockImpalerBought = this.Config.GetValue<int>("Vehicles", "FutureShockImpalerBought", this.FutureShockImpalerBought);
        this.NightmareSlamvanBought = this.Config.GetValue<int>("Vehicles", "NightmareSlamvanBought", this.NightmareSlamvanBought);
        this.ApocalypseSlamvanBought = this.Config.GetValue<int>("Vehicles", "ApocalypseSlamvanBought", this.ApocalypseSlamvanBought);
        this.FutureShockSlamvanBought = this.Config.GetValue<int>("Vehicles", "FutureShockSlamvanBought", this.FutureShockSlamvanBought);
        this.NightmareBruitusBought = this.Config.GetValue<int>("Vehicles", "NightmareBrutusBought", this.NightmareBruitusBought);
        this.ApocalypseBruitusBought = this.Config.GetValue<int>("Vehicles", "ApocalypseBrutusBought", this.ApocalypseBruitusBought);
        this.FutureShockBruitusBought = this.Config.GetValue<int>("Vehicles", "FutureShockBrutusBought", this.FutureShockBruitusBought);
        this.CurrentBruiser = this.Config.GetValue<int>("Vehicles", "CurrentBruiser", this.CurrentBruiser);
        this.NightmareBruiserBought = this.Config.GetValue<int>("Vehicles", "NightmareBruiserBought", this.NightmareBruiserBought);
        this.ApocalypseBruiserBought = this.Config.GetValue<int>("Vehicles", "ApocalypseBruiserBought", this.ApocalypseBruiserBought);
        this.FutureShockBruiserBought = this.Config.GetValue<int>("Vehicles", "FutureShockBruiserBought", this.FutureShockBruiserBought);
        this.NightmareZR380Bought = this.Config.GetValue<int>("Vehicles", "NightmareZR380Bought", this.NightmareZR380Bought);
        this.ApocalypseZR380Bought = this.Config.GetValue<int>("Vehicles", "ApocalypseZR380Bought", this.ApocalypseZR380Bought);
        this.FutureShockZR380Bought = this.Config.GetValue<int>("Vehicles", "FutureShockZR380Bought", this.FutureShockZR380Bought);
        this.CliqueBought = this.Config.GetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
        this.ItaligtoBought = this.Config.GetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
        this.TulipBought = this.Config.GetValue<int>("Vehicles", "TulipBought", this.TulipBought);
        this.VamosBought = this.Config.GetValue<int>("Vehicles", "VamosBought", this.VamosBought);
        this.SchlagenBought = this.Config.GetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
        this.DeviantBought = this.Config.GetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
        this.TorosBought = this.Config.GetValue<int>("Vehicles", "TorosBought", this.TorosBought);
        this.DevesteBought = this.Config.GetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
        this.RcBanditoBought = this.Config.GetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
        if (this.CurrentBruiser == 0)
          this.CurrentBruiser = 1;
        if (this.CurrentBruitus == 0)
          this.CurrentBruitus = 1;
        if (this.CurrentCerberus == 0)
          this.CurrentCerberus = 1;
        if (this.CurrentDeathbike == 0)
          this.CurrentDeathbike = 1;
        if (this.CurrentDominator == 0)
          this.CurrentDominator = 1;
        if (this.CurrentImpaler == 0)
          this.CurrentImpaler = 1;
        if (this.CurrentImperator == 0)
          this.CurrentImperator = 1;
        if (this.CurrentIssi == 0)
          this.CurrentIssi = 1;
        if (this.CurrentMonster == 0)
          this.CurrentMonster = 1;
        if (this.CurrentScarab == 0)
          this.CurrentScarab = 1;
        if (this.CurrentSlamvan == 0)
          this.CurrentSlamvan = 1;
        if (this.CurrentZR380 == 0)
          this.CurrentZR380 = 1;
        this.maxstocks = 10 * this.purchaselvl;
        float num = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
        this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
        this.increaseGain = num;
        this.BusinessUpgradeBasePrice = this.Config.GetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
        this.IncreaseStockMinAmount = this.Config.GetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
        this.IncreaseStockMaxAmount = this.Config.GetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
        this.DecreaseStockMinAmount = this.Config.GetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
        this.DecreaseStockMaxAmount = this.Config.GetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: MazeBank.ini Failed To Load.");
      }
    }

    public GTA.Model RequestModel(string Prop)
    {
      GTA.Model model = new GTA.Model(Prop);
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

    public GTA.Model RequestModel(VehicleHash Prop)
    {
      GTA.Model model = new GTA.Model(Prop);
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

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_mod");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_Mod_2");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_mod");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_vip");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_Mod_2");
      this.SetupWorkshop();
      this.SetupB1Garage();
      this.SetupT_T();
      this.Enableinterior();
      this.EImodMenuPool = new MenuPool();
      this.EImainMenu = new UIMenu("Arena War ", "Select an Option");
      this.GUIMenus.Add(this.EImainMenu);
      this.EImodMenuPool.Add(this.EImainMenu);
      this.EIInteriorOptions = this.EImodMenuPool.AddSubMenu(this.EImainMenu, "Interiors");
      this.GUIMenus.Add(this.EIInteriorOptions);
      this.SetupInteriorDesignsMenu();
      this.ArenaMenuPool = new MenuPool();
      this.ArenaMainMenu = new UIMenu("Arena War ", "Select an Option");
      this.GUIMenus.Add(this.ArenaMainMenu);
      this.ArenaMenuPool.Add(this.ArenaMainMenu);
      this.ArenaMenu = this.ArenaMenuPool.AddSubMenu(this.ArenaMainMenu, "Arena Vehicles");
      this.GUIMenus.Add(this.ArenaMenu);
      this.Enableinterior();
      this.ReloadInterior();
      this.waittime = this.Allstocks.waittime;
      this.MarkerEnter = new Vector3(-377f, -1877f, 19.52f);
      this.MarkerExit = new Vector3(216f, 5205f, -89.59f);
      this.MenuMarker = new Vector3(205f, 5163f, -87f);
      this.RoofEnterMarker = new Vector3(-74f, -809f, 242.5f);
      this.RoofExitMarker = new Vector3(-66f, -819.158f, 320.5f);
      this.HeliSpawn = new Vector3(-75f, -818.158f, 325.5f);
      this.CarSpawn = new Vector3(-83f, -815.158f, 35f);
      this.WherehouseEnter = new Vector3(926f, -2306.158f, 28.5f);
      this.VehicleSpawn = new Vector3(-36f, -939.158f, 29.5f);
      this.WherehouseMarker = new Vector3(254.6f, -3057f, 5.7f);
      this.AircraftStorageLoc = new Vector3(1679f, 3238f, 40f);
      this.Dockloc = new Vector3(3865f, 4463.66f, 2f);
      this.LotLoc = new Vector3(863f, 2173f, 51f);
      this.Radiopos = new Vector3(-79.33f, -804.844f, 243f);
      this.GarageMenuSpawn = new Vector3(169f, 5180f, -90f);
      this.SetupMarker();
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Arena War ", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.ArenaGarageMenuPool = new MenuPool();
      this.ArenaGarageMenu = new UIMenu("Arena War ", "Select an Option");
      this.GUIMenus.Add(this.ArenaGarageMenu);
      this.ArenaGarageMenuPool.Add(this.ArenaGarageMenu);
      this.ArenaVehicleMenu = this.ArenaGarageMenuPool.AddSubMenu(this.ArenaGarageMenu, "Arena Vehicles");
      this.GUIMenus.Add(this.ArenaVehicleMenu);
      this.GLmodMenuPool = new MenuPool();
      this.GLmainMenu = new UIMenu("Arena War", "Select an Option");
      this.GUIMenus.Add(this.GLmainMenu);
      this.GLmodMenuPool.Add(this.GLmainMenu);
      this.weaponsMenu = this.GLmodMenuPool.AddSubMenu(this.GLmainMenu, "Weapons");
      this.GUIMenus.Add(this.weaponsMenu);
      this.SetupWeapons();
      this.currentbank = 1;
      this.MVmodMenuPool = new MenuPool();
      this.MVmainMenu = new UIMenu("Arena War", "Select an Option");
      this.GUIMenus.Add(this.MVmainMenu);
      this.MVmodMenuPool.Add(this.MVmainMenu);
      this.MoneyMenu = this.MVmodMenuPool.AddSubMenu(this.MVmainMenu, "Money Options");
      this.GUIMenus.Add(this.MoneyMenu);
      this.SetupMoneyMenu();
      this.methgarage = this.modMenuPool.AddSubMenu(this.mainMenu, "Purchase Options");
      this.GUIMenus.Add(this.methgarage);
      this.ProductStock = this.modMenuPool.AddSubMenu(this.mainMenu, "Product Options");
      this.GUIMenus.Add(this.ProductStock);
      this.SpecialMissions = this.modMenuPool.AddSubMenu(this.mainMenu, "Arena War Races (Missions)");
      this.GUIMenus.Add(this.SpecialMissions);
      this.SupplyRunsmenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Special Missions (Missions)");
      this.GUIMenus.Add(this.SupplyRunsmenu);
      this.PointtoPointMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Point to Point (Missions)");
      this.GUIMenus.Add(this.PointtoPointMenu);
      this.DeathMatch = this.modMenuPool.AddSubMenu(this.mainMenu, "Vehicle Death Matches (Missions)");
      this.GUIMenus.Add(this.DeathMatch);
      this.ChampionchipMatch = this.modMenuPool.AddSubMenu(this.mainMenu, "Championchip Matches (Missions)");
      this.GUIMenus.Add(this.ChampionchipMatch);
      this.SkyWars = this.modMenuPool.AddSubMenu(this.mainMenu, "Sky Wars Death Matches (Missions)");
      this.GUIMenus.Add(this.SkyWars);
      this.TurretMayhem = this.modMenuPool.AddSubMenu(this.mainMenu, "Turret Mayhem Matches (Missions)");
      this.GUIMenus.Add(this.TurretMayhem);
      this.RCKing = this.modMenuPool.AddSubMenu(this.mainMenu, "RC King (Missions)");
      this.GUIMenus.Add(this.RCKing);
      this.HotRing = this.modMenuPool.AddSubMenu(this.mainMenu, "Hot Ring (Missions)");
      this.GUIMenus.Add(this.HotRing);
      this.SmashandGrab = this.modMenuPool.AddSubMenu(this.mainMenu, "Smash And Grab (Missions)");
      this.GUIMenus.Add(this.SmashandGrab);
      this.DemoltionMenMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Demoltion Men (Missions)");
      this.GUIMenus.Add(this.DemoltionMenMenu);
      this.GarageMenuPool = new MenuPool();
      this.GarageMenu = new UIMenu("Vehicles Menu ", "Select an Option");
      this.GUIMenus.Add(this.GarageMenu);
      this.GarageMenuPool.Add(this.GarageMenu);
      this.VehicleMenu = this.GarageMenuPool.AddSubMenu(this.GarageMenu, "Vehicle Options");
      this.GUIMenus.Add(this.VehicleMenu);
      this.VehicleLoadMenu = this.GarageMenuPool.AddSubMenu(this.GarageMenu, "Vehicle Load Options");
      this.GUIMenus.Add(this.VehicleLoadMenu);
      this.GarageMenuPool2 = new MenuPool();
      this.GarageMenu2 = new UIMenu("Vehicles Menu ", "Select an Option");
      this.GUIMenus.Add(this.GarageMenu2);
      this.GarageMenuPool2.Add(this.GarageMenu2);
      this.VehicleMenu2 = this.GarageMenuPool2.AddSubMenu(this.GarageMenu2, "Vehicle Options");
      this.GUIMenus.Add(this.VehicleMenu2);
      this.Setupbuisness();
      this.SetupStadium();
      this.SetupProduct();
      this.SetupTrapsPositions();
      this.SetupArenaMenu();
      this.PlayerGaragemodMenuPool = new MenuPool();
      this.PlayerGarageMenu = new UIMenu("Arena War", "Select an Option");
      this.GUIMenus.Add(this.PlayerGarageMenu);
      this.PlayerGaragemodMenuPool.Add(this.PlayerGarageMenu);
      this.PlayerGaragemainMenu = this.PlayerGaragemodMenuPool.AddSubMenu(this.PlayerGarageMenu, "Garage Options");
      this.GUIMenus.Add(this.PlayerGaragemainMenu);
      this.RemoveMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Remove a Vehicle", "Select an Option");
      this.GUIMenus.Add(this.mainMenu2);
      this.RemoveMenuPool2.Add(this.mainMenu2);
      this.RemoveMenu = this.RemoveMenuPool2.AddSubMenu(this.mainMenu2, "Remove A Vehicle");
      this.GUIMenus.Add(this.RemoveMenu);
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_mod");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_Arena_Interior_Mod_2");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_mod");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_Arena_Interior_Mod_2");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2799.529, (InputArgument) -3930.539, (InputArgument) 182.235);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "xs_x18int01_pit_fenceoval_col");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "xs_dystopian_17");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "xs_dystopian_17");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "xs_x18int01_pit_fenceoval_col");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      this.SetUpVehicles();
      this.SetUpVehicles2();
      this.SetupGarage();
      this.RemoveCar();
      this.SetupRaces();
      this.SetupSkyWars();
      this.SetupTurretMayhem();
      this.ChampionChipMatch();
      this.SetupSpecialMissions();
      this.SetupSpecialMissions2();
      this.SetupSpecialMissions3();
      this.SetupSpecialMissions4();
      this.SetupSpecialMissions5();
      this.SetupSpecialMissions6();
      this.SetupSpecialMissions8();
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
      for (int index = 0; index < this.GUIMenus.Count<UIMenu>(); ++index)
        this.SetBanner(this.GUIMenus[index]);
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
        UI.Notify("Agent 14  : boss you dont have that amount of money to deposit: value: " + int.Parse(userInput).ToString());
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

    public void Check()
    {
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
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p1 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__0 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__0, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
          if (target1((CallSite) p1, obj1))
          {
            Components.Clear();
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__612.\u003C\u003Ep__2 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__2.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__2, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
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
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target2 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__4.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p4 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__4;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__3, Components[C.Index]);
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
        if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__612.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target = Class1.\u003C\u003Eo__612.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p6 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__612.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__612.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__5, Components[C.Index]);
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
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target1 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p8 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__7.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__7, Components[C.Index]);
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
            if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__612.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, bool> target2 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__10.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, bool>> p10 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__10;
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__9 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__612.\u003C\u003Ep__9 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__9.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__9, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
            if (target2((CallSite) p10, obj2))
            {
              if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) W.IndexToItem(W.Index).GetHashCode(), (InputArgument) C.IndexToItem(C.Index).GetHashCode()))
              {
                // ISSUE: reference to a compiler-generated field
                if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__11 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  Class1.\u003C\u003Eo__612.\u003C\u003Ep__11 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Class1.\u003C\u003Eo__612.\u003C\u003Ep__11.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__11, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
                // ISSUE: reference to a compiler-generated field
                if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__12 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  Class1.\u003C\u003Eo__612.\u003C\u003Ep__12 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Class1.\u003C\u003Eo__612.\u003C\u003Ep__12.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__12, Game.Player.Character.Weapons.Current, Components[C.Index], true);
              }
            }
          }
        }
        if (item != DIsable)
          return;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__612.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__14.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p14 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__14;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__612.\u003C\u003Ep__13 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__13.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__13, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
        if (target3((CallSite) p14, obj3))
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__19 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__19.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p19 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__19;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__18 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool, object> target2 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__18.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool, object>> p18 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__18;
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__17 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__17 = CallSite<Func<CallSite, System.Type, Hash, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Call", (IEnumerable<System.Type>) new System.Type[1]
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
          Func<CallSite, System.Type, Hash, object, object, object> target4 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__17.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, System.Type, Hash, object, object, object>> p17 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__17;
          System.Type type = typeof (Function);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__15 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__15.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__15, Mk2Weapons[W.Index]);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__16 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = Class1.\u003C\u003Eo__612.\u003C\u003Ep__16.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__16, Components[C.Index]);
          object obj4 = target4((CallSite) p17, type, Hash._0x5CEE3DF569CECAB0, obj1, obj2);
          object obj5 = target2((CallSite) p18, obj4, true);
          if (target1((CallSite) p19, obj5))
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__20 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__612.\u003C\u003Ep__20 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__20.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__20, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__612.\u003C\u003Ep__21 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__612.\u003C\u003Ep__21 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__612.\u003C\u003Ep__21.Target((CallSite) Class1.\u003C\u003Eo__612.\u003C\u003Ep__21, Game.Player.Character.Weapons.Current, Components[C.Index], false);
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

    public void SetupTurretMayhem()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.TurretMayhem, "Turret Mayhem");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("Turret Mayhem 1 (Wasteland 4)");
      uiMenu.AddItem(Race4);
      UIMenuItem Race5 = new UIMenuItem("Turret Mayhem 2 (Scifi 4)");
      uiMenu.AddItem(Race5);
      UIMenuItem Race6 = new UIMenuItem("Turret Mayhem 3 (Dystopian 4)");
      uiMenu.AddItem(Race6);
      UIMenuItem Race7 = new UIMenuItem("Turret Mayhem 4 (Dystopian 8)");
      uiMenu.AddItem(Race7);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race6)
        {
          this.MissionSetup = true;
          this.MissionId = 28;
          this.Race = 2;
          this.RaceMarker = new Vector3(2790f, -3879.2f, 140f);
          this.StartedRace = false;
          this.RaceBlip = World.CreateBlip(this.RaceMarker);
          this.RaceBlip.Name = "Turret Mayhem Race";
          this.RaceBlip.Sprite = BlipSprite.Race;
          UI.Notify(this.GetHostName() + " Race around around the Circuit, all the while avoiding the Turret that are shooting at you");
          Game.Player.Character.Position = this.RaceMarker;
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          Game.Player.Character.IsInvincible = true;
          this.LoadDystopian_4();
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race7)
        {
          this.MissionSetup = true;
          this.MissionId = 28;
          this.Race = 2;
          this.RaceMarker = new Vector3(2790f, -3879.2f, 140f);
          this.StartedRace = false;
          this.RaceBlip = World.CreateBlip(this.RaceMarker);
          this.RaceBlip.Name = "Turret Mayhem Race";
          this.RaceBlip.Sprite = BlipSprite.Race;
          UI.Notify(this.GetHostName() + " Race around around the Circuit, all the while avoiding the Turret that are shooting at you");
          Game.Player.Character.Position = this.RaceMarker;
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          Game.Player.Character.IsInvincible = true;
          this.LoadDystopian_8();
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race5)
        {
          this.MissionSetup = true;
          this.MissionId = 28;
          this.Race = 1;
          this.RaceMarker = new Vector3(2773f, -3853.73f, 130f);
          this.StartedRace = false;
          this.RaceBlip = World.CreateBlip(this.RaceMarker);
          this.RaceBlip.Name = "Turret Mayhem Race";
          this.RaceBlip.Sprite = BlipSprite.Race;
          UI.Notify(this.GetHostName() + " Race around around the Circuit, all the while avoiding the Turret that are shooting at you");
          Game.Player.Character.Position = this.RaceMarker;
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          Game.Player.Character.IsInvincible = true;
          this.LoadScifi_4();
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race4)
          return;
        this.MissionSetup = true;
        this.MissionId = 28;
        this.Race = 1;
        this.RaceMarker = new Vector3(2773f, -3853.73f, 130f);
        this.StartedRace = false;
        this.RaceBlip = World.CreateBlip(this.RaceMarker);
        this.RaceBlip.Name = "Turret Mayhem Race";
        this.RaceBlip.Sprite = BlipSprite.Race;
        UI.Notify(this.GetHostName() + " Race around around the Circuit, all the while avoiding the Turret that are shooting at you");
        Game.Player.Character.Position = this.RaceMarker;
        GTA.Model vehicle1 = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle1, new Vector3(2782.99f, -3898.15f, 140f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        Game.Player.Character.IsInvincible = true;
        this.LoadWasteland_4();
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
      });
    }

    public void SetupSkyWars()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SkyWars, "Sky Wars Matches");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("Death Match (Dystopian A) 4x Opp");
      uiMenu.AddItem(Race4);
      UIMenuItem Race5 = new UIMenuItem("Death Match (Dystopian A) 8x Opp");
      uiMenu.AddItem(Race5);
      UIMenuItem Race6 = new UIMenuItem("Death Match (Scifi A) 4x Opp");
      uiMenu.AddItem(Race6);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race6)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          this.Race = 1;
          this.MissionId = 27;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
          this.SpawnProp("xs_propint2_set_scifi_10", new Vector3(-58.9f, -861f, 1000f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          this.SpawnProp("xs_prop_arena_turret_01a", new Vector3(-59.29f, -861.218f, 1002f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(113f, -873f, 1005f), 85f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          foreach (Prop prop in this.Trap_Flipper2)
          {
            if ((Entity) prop != (Entity) null)
            {
              prop.HasCollision = false;
              prop.IsVisible = false;
              prop.FreezePosition = true;
            }
          }
          if (this.Trap_Flame.Count > 0)
            this.Trap_Flame.Clear();
          if (this.Trap_Flipper.Count > 0)
            this.Trap_Flipper.Clear();
          if (this.Trap_Mines.Count > 0)
            this.Trap_Mines.Clear();
          if (this.Trap_Spike.Count > 0)
            this.Trap_Spike.Clear();
          if (this.Trap_Turning.Count > 0)
            this.Trap_Turning.Clear();
          if (this.Trap_GunTower.Count > 0)
            this.Trap_GunTower.Clear();
          List<string> stringList = new List<string>();
          List<Vector3> vector3List = new List<Vector3>();
          vector3List.Add(new Vector3(23f, -915f, 1002f));
          vector3List.Add(new Vector3(45f, -863f, 1002f));
          vector3List.Add(new Vector3(31f, -810f, 1002f));
          vector3List.Add(new Vector3(-24f, -811f, 1002f));
          vector3List.Add(new Vector3(63f, -826f, 1002f));
          vector3List.Add(new Vector3(86f, -837.7f, 1002f));
          vector3List.Add(new Vector3(83.4f, -895.5f, 1001.5f));
          vector3List.Add(new Vector3(32.1f, -931.4f, 1002f));
          vector3List.Add(new Vector3(6f, -919.6f, 1002f));
          vector3List.Add(new Vector3(-32.1f, -942.1f, 1002f));
          vector3List.Add(new Vector3(-128.021f, -898.6f, 1002f));
          vector3List.Add(new Vector3(-124.2f, -856.3f, 1002f));
          vector3List.Add(new Vector3(108.6f, -830f, 1002f));
          vector3List.Add(new Vector3(-79.7f, -794f, 1002f));
          vector3List.Add(new Vector3(-123.3f, -791.4f, 1002f));
          vector3List.Add(new Vector3(-145.8f, -808.2f, 1002f));
          vector3List.Add(new Vector3(-155.6f, -836.8f, 1002f));
          vector3List.Add(new Vector3(-166.6f, -872.9f, 1002f));
          vector3List.Add(new Vector3(-196.814f, -913.4f, 1002f));
          vector3List.Add(new Vector3(-206.149f, -823.8f, 1002f));
          vector3List.Add(new Vector3(-74.46f, -794.8f, 1002f));
          vector3List.Add(new Vector3(-217.8f, -866.8f, 1002f));
          vector3List.Add(new Vector3(-151.7f, -919.1f, 1002f));
          vector3List.Add(new Vector3(-48.01f, -924.8f, 1002f));
          vector3List.Add(new Vector3(8.4f, -792.5f, 1002f));
          vector3List.Add(new Vector3(-122.2f, -833.44f, 1002f));
          vector3List.Add(new Vector3(-66.15f, 871.2f, 1002f));
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
            {
              prop.HasCollision = true;
              prop.FreezePosition = true;
            }
          }
          System.Random random = new System.Random();
          foreach (Vector3 Pos in vector3List)
          {
            int num1 = random.Next(0, 360);
            int num2 = random.Next(1, 150);
            if (num2 < 25)
            {
              this.SpawnProp("xs_prop_arena_spikes_01a_sf", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Spike.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 25 && num2 < 50)
            {
              this.SpawnProp("xs_prop_arena_pit_fire_04a_sf", new Vector3(Pos.X, Pos.Y, Pos.Z), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Flame.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 50 && num2 < 60)
            {
              this.SpawnProp("xs_prop_arena_landmine_01c_sf", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Mines.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 60 && num2 < 80)
            {
              this.SpawnProp("xs_prop_arena_landmine_01c_sf", new Vector3(Pos.X, Pos.Y, Pos.Z), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Mines.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 80 && num2 < 100)
            {
              this.SpawnProp("xs_prop_arena_pressure_plate_01a_sf", new Vector3(Pos.X, Pos.Y, Pos.Z), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Flipper.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 100 && num2 < 120)
            {
              this.SpawnProp("xs_prop_arena_pressure_plate_01a_sf", new Vector3(Pos.X, Pos.Y, Pos.Z), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Flipper.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 120 && num2 < 145)
            {
              this.SpawnProp("xs_prop_arena_turntable_03a", new Vector3(Pos.X, Pos.Y, Pos.Z), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Turning.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 145)
            {
              this.SpawnProp("xs_prop_arena_turret_post_01a_sf", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_GunTower.Add(this.Props[this.Props.Count - 1]);
            }
          }
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
            {
              prop.HasCollision = true;
              prop.FreezePosition = true;
            }
          }
          foreach (Prop prop in this.Trap_Flipper2)
          {
            if ((Entity) prop != (Entity) null)
            {
              prop.HasCollision = false;
              prop.IsVisible = false;
              prop.FreezePosition = true;
            }
          }
          this.SpawnProp("xs_prop_arena_turret_01a_sf", new Vector3(43.732f, -807.727f, 1002f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          this.SpawnProp("xs_prop_ar_tower_01a_sf", new Vector3(68.5992f, -902.283f, 1002f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          this.SpawnProp("xs_prop_arena_turret_post_01a_sf", new Vector3(-59.1016f, -930.229f, 1001f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          this.SpawnProp("xs_prop_ar_tower_01a_sf", new Vector3(-186.72f, -902.875f, 1002f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          this.SpawnProp("xs_prop_arena_turret_01a_sf", new Vector3(-160.349f, -809f, 1002f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          this.SpawnProp("xs_prop_arena_turret_post_01a_sf", new Vector3(10.74f, -862.239f, 1001f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          this.SpawnProp("xs_prop_arena_turret_post_01a_sf", new Vector3(-128.801f, -861.418f, 1001f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
            {
              prop.HasCollision = true;
              prop.FreezePosition = true;
            }
          }
          this.ArenaGarageMenuPool.CloseAllMenus();
          this.modMenuPool.CloseAllMenus();
          this.GarageMenuPool.CloseAllMenus();
          this.GarageMenuPool2.CloseAllMenus();
          this.StopScreenEffects();
          this.StartScreenEffect(3);
        }
        if (item == Race5)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          this.Race = 2;
          this.MissionId = 27;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
          this.SpawnProp("xs_terrain_set_dystopian_10", new Vector3(-58.9f, -861f, 1000f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          this.SpawnProp("xs_prop_arena_turret_01a", new Vector3(-42f, -871f, 1009f), new Vector3(0.0f, 0.0f, 0.0f), 1);
          if (this.Trap_Flame.Count > 0)
            this.Trap_Flame.Clear();
          if (this.Trap_Flipper.Count > 0)
            this.Trap_Flipper.Clear();
          if (this.Trap_Mines.Count > 0)
            this.Trap_Mines.Clear();
          if (this.Trap_Spike.Count > 0)
            this.Trap_Spike.Clear();
          if (this.Trap_Turning.Count > 0)
            this.Trap_Turning.Clear();
          if (this.Trap_GunTower.Count > 0)
            this.Trap_GunTower.Clear();
          List<string> stringList = new List<string>();
          List<Vector3> vector3List = new List<Vector3>();
          vector3List.Add(new Vector3(23f, -915f, 1001.5f));
          vector3List.Add(new Vector3(45f, -863f, 1001.5f));
          vector3List.Add(new Vector3(31f, -810f, 1001.5f));
          vector3List.Add(new Vector3(-24f, -811f, 1001.5f));
          vector3List.Add(new Vector3(63f, -826f, 1001.5f));
          vector3List.Add(new Vector3(86f, -837.7f, 1001.5f));
          vector3List.Add(new Vector3(83.4f, -895.5f, 1001.5f));
          vector3List.Add(new Vector3(32.1f, -931.4f, 1001.5f));
          vector3List.Add(new Vector3(6f, -919.6f, 1001.5f));
          vector3List.Add(new Vector3(-32.1f, -942.1f, 1001.5f));
          vector3List.Add(new Vector3(-128.021f, -898.6f, 1001.5f));
          vector3List.Add(new Vector3(-124.2f, -856.3f, 1001.5f));
          vector3List.Add(new Vector3(108.6f, -830f, 1001.5f));
          vector3List.Add(new Vector3(-79.7f, -794f, 1001.5f));
          vector3List.Add(new Vector3(-123.3f, -791.4f, 1001.5f));
          vector3List.Add(new Vector3(-145.8f, -808.2f, 1001.5f));
          vector3List.Add(new Vector3(-155.6f, -836.8f, 1001.5f));
          vector3List.Add(new Vector3(-166.6f, -872.9f, 1001.5f));
          vector3List.Add(new Vector3(-196.814f, -913.4f, 1001.5f));
          vector3List.Add(new Vector3(-206.149f, -823.8f, 1001.5f));
          vector3List.Add(new Vector3(-74.46f, -794.8f, 1001.5f));
          vector3List.Add(new Vector3(-217.8f, -866.8f, 1001.5f));
          vector3List.Add(new Vector3(-151.7f, -919.1f, 1001.5f));
          vector3List.Add(new Vector3(-48.01f, -924.8f, 1001.5f));
          vector3List.Add(new Vector3(8.4f, -792.5f, 1001.5f));
          vector3List.Add(new Vector3(-122.2f, -833.44f, 1001.5f));
          vector3List.Add(new Vector3(-66.15f, 871.2f, 1001.5f));
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
            {
              prop.HasCollision = true;
              prop.FreezePosition = true;
            }
          }
          System.Random random = new System.Random();
          foreach (Vector3 Pos in vector3List)
          {
            int num1 = random.Next(0, 360);
            int num2 = random.Next(1, 150);
            if (num2 < 25)
            {
              this.SpawnProp("xs_prop_arena_spikes_01a", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Spike.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 25 && num2 < 50)
            {
              this.SpawnProp("xs_prop_arena_pit_fire_01a", new Vector3(Pos.X, Pos.Y, Pos.Z - 0.6f), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Flame.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 50 && num2 < 60)
            {
              this.SpawnProp("xs_prop_arena_landmine_01a", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Mines.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 60 && num2 < 80)
            {
              this.SpawnProp("xs_prop_arena_landmine_03a_wl", new Vector3(Pos.X, Pos.Y, Pos.Z - 0.4f), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Mines.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 80 && num2 < 100)
            {
              this.SpawnProp("xs_prop_arena_flipper_small_01a", new Vector3(Pos.X, Pos.Y, Pos.Z - 3f), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Flipper.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 100 && num2 < 120)
            {
              this.SpawnProp("xs_prop_arena_flipper_small_01a", new Vector3(Pos.X, Pos.Y, Pos.Z - 3f), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Flipper.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 120 && num2 < 145)
            {
              this.SpawnProp("xs_prop_arena_turntable_03a", new Vector3(Pos.X, Pos.Y, Pos.Z - 0.4f), new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_Turning.Add(this.Props[this.Props.Count - 1]);
            }
            if (num2 > 145)
            {
              this.SpawnProp("xs_prop_arena_turret_post_01a", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
              this.Trap_GunTower.Add(this.Props[this.Props.Count - 1]);
            }
          }
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
            {
              prop.HasCollision = true;
              prop.FreezePosition = true;
            }
          }
          foreach (Prop prop in this.Trap_Flipper2)
          {
            if ((Entity) prop != (Entity) null)
            {
              prop.HasCollision = false;
              prop.IsVisible = false;
              prop.FreezePosition = true;
            }
          }
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(113f, -873f, 1005f), 85f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.ArenaGarageMenuPool.CloseAllMenus();
          this.modMenuPool.CloseAllMenus();
          this.GarageMenuPool.CloseAllMenus();
          this.GarageMenuPool2.CloseAllMenus();
          this.StopScreenEffects();
          this.StartScreenEffect(1);
        }
        if (item != Race4)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        foreach (Prop prop in this.Props)
        {
          if ((Entity) prop != (Entity) null)
            prop.Delete();
        }
        UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
        this.RaceMarker = new Vector3(2640f, -3801f, 140f);
        this.Race = 1;
        this.MissionId = 27;
        this.MissionSetup = true;
        this.StartedRace = false;
        this.TimeLeft = 40;
        Game.Player.Character.IsInvincible = true;
        this.checkpointReaced = 0;
        this.moneytobeawarded = 0.0f;
        this.vehicleHealth = 600;
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
        this.SpawnProp("xs_terrain_set_dystopian_10", new Vector3(-58.9f, -861f, 1000f), new Vector3(0.0f, 0.0f, 0.0f), 1);
        this.SpawnProp("xs_prop_arena_turret_01a", new Vector3(-42f, -871f, 1009f), new Vector3(0.0f, 0.0f, 0.0f), 1);
        if (this.Trap_Flame.Count > 0)
          this.Trap_Flame.Clear();
        if (this.Trap_Flipper.Count > 0)
          this.Trap_Flipper.Clear();
        if (this.Trap_Mines.Count > 0)
          this.Trap_Mines.Clear();
        if (this.Trap_Spike.Count > 0)
          this.Trap_Spike.Clear();
        if (this.Trap_Turning.Count > 0)
          this.Trap_Turning.Clear();
        if (this.Trap_GunTower.Count > 0)
          this.Trap_GunTower.Clear();
        List<string> stringList1 = new List<string>();
        List<Vector3> vector3List1 = new List<Vector3>();
        vector3List1.Add(new Vector3(23f, -915f, 1001.5f));
        vector3List1.Add(new Vector3(45f, -863f, 1001.5f));
        vector3List1.Add(new Vector3(31f, -810f, 1001.5f));
        vector3List1.Add(new Vector3(-24f, -811f, 1001.5f));
        vector3List1.Add(new Vector3(63f, -826f, 1001.5f));
        vector3List1.Add(new Vector3(86f, -837.7f, 1001.5f));
        vector3List1.Add(new Vector3(83.4f, -895.5f, 1001.5f));
        vector3List1.Add(new Vector3(32.1f, -931.4f, 1001.5f));
        vector3List1.Add(new Vector3(6f, -919.6f, 1001.5f));
        vector3List1.Add(new Vector3(-32.1f, -942.1f, 1001.5f));
        vector3List1.Add(new Vector3(-128.021f, -898.6f, 1001.5f));
        vector3List1.Add(new Vector3(-124.2f, -856.3f, 1001.5f));
        vector3List1.Add(new Vector3(108.6f, -830f, 1001.5f));
        vector3List1.Add(new Vector3(-79.7f, -794f, 1001.5f));
        vector3List1.Add(new Vector3(-123.3f, -791.4f, 1001.5f));
        vector3List1.Add(new Vector3(-145.8f, -808.2f, 1001.5f));
        vector3List1.Add(new Vector3(-155.6f, -836.8f, 1001.5f));
        vector3List1.Add(new Vector3(-166.6f, -872.9f, 1001.5f));
        vector3List1.Add(new Vector3(-196.814f, -913.4f, 1001.5f));
        vector3List1.Add(new Vector3(-206.149f, -823.8f, 1001.5f));
        vector3List1.Add(new Vector3(-74.46f, -794.8f, 1001.5f));
        vector3List1.Add(new Vector3(-217.8f, -866.8f, 1001.5f));
        vector3List1.Add(new Vector3(-151.7f, -919.1f, 1001.5f));
        vector3List1.Add(new Vector3(-48.01f, -924.8f, 1001.5f));
        vector3List1.Add(new Vector3(8.4f, -792.5f, 1001.5f));
        vector3List1.Add(new Vector3(-122.2f, -833.44f, 1001.5f));
        vector3List1.Add(new Vector3(-66.15f, 871.2f, 1001.5f));
        foreach (Prop prop in this.Props)
        {
          if ((Entity) prop != (Entity) null)
          {
            prop.HasCollision = true;
            prop.FreezePosition = true;
          }
        }
        System.Random random1 = new System.Random();
        foreach (Vector3 Pos in vector3List1)
        {
          int num1 = random1.Next(0, 360);
          int num2 = random1.Next(1, 150);
          if (num2 < 25)
          {
            this.SpawnProp("xs_prop_arena_spikes_01a", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
            this.Trap_Spike.Add(this.Props[this.Props.Count - 1]);
          }
          if (num2 > 25 && num2 < 50)
          {
            this.SpawnProp("xs_prop_arena_pit_fire_01a", new Vector3(Pos.X, Pos.Y, Pos.Z - 0.6f), new Vector3(0.0f, 0.0f, (float) num1), 1);
            this.Trap_Flame.Add(this.Props[this.Props.Count - 1]);
          }
          if (num2 > 50 && num2 < 60)
          {
            this.SpawnProp("xs_prop_arena_landmine_01a", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
            this.Trap_Mines.Add(this.Props[this.Props.Count - 1]);
          }
          if (num2 > 60 && num2 < 80)
          {
            this.SpawnProp("xs_prop_arena_landmine_03a_wl", new Vector3(Pos.X, Pos.Y, Pos.Z - 0.4f), new Vector3(0.0f, 0.0f, (float) num1), 1);
            this.Trap_Mines.Add(this.Props[this.Props.Count - 1]);
          }
          if (num2 > 80 && num2 < 100)
          {
            this.SpawnProp("xs_prop_arena_flipper_small_01a", new Vector3(Pos.X, Pos.Y, Pos.Z - 3f), new Vector3(0.0f, 0.0f, (float) num1), 1);
            this.Trap_Flipper.Add(this.Props[this.Props.Count - 1]);
          }
          if (num2 > 100 && num2 < 120)
          {
            this.SpawnProp("xs_prop_arena_flipper_small_01a", new Vector3(Pos.X, Pos.Y, Pos.Z - 3f), new Vector3(0.0f, 0.0f, (float) num1), 1);
            this.Trap_Flipper.Add(this.Props[this.Props.Count - 1]);
          }
          if (num2 > 120 && num2 < 145)
          {
            this.SpawnProp("xs_prop_arena_turntable_03a", new Vector3(Pos.X, Pos.Y, Pos.Z - 0.4f), new Vector3(0.0f, 0.0f, (float) num1), 1);
            this.Trap_Turning.Add(this.Props[this.Props.Count - 1]);
          }
          if (num2 > 145)
          {
            this.SpawnProp("xs_prop_arena_turret_post_01a", Pos, new Vector3(0.0f, 0.0f, (float) num1), 1);
            this.Trap_GunTower.Add(this.Props[this.Props.Count - 1]);
          }
        }
        foreach (Prop prop in this.Props)
        {
          if ((Entity) prop != (Entity) null)
          {
            prop.HasCollision = true;
            prop.FreezePosition = true;
          }
        }
        foreach (Prop prop in this.Trap_Flipper2)
        {
          if ((Entity) prop != (Entity) null)
          {
            prop.HasCollision = false;
            prop.IsVisible = false;
            prop.FreezePosition = true;
          }
        }
        GTA.Model vehicle1 = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle1, new Vector3(113f, -873f, 1005f), 85f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        this.ArenaGarageMenuPool.CloseAllMenus();
        this.modMenuPool.CloseAllMenus();
        this.GarageMenuPool.CloseAllMenus();
        this.GarageMenuPool2.CloseAllMenus();
        this.StopScreenEffects();
        this.StartScreenEffect(1);
      });
    }

    public void ChampionChipMatch()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.ChampionchipMatch, "Championchip Matches");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("Death Match (Scifi 2) 4x Opp");
      uiMenu.AddItem(Race4);
      UIMenuItem Race11 = new UIMenuItem("Death Match (Scifi 5) 4x Opp");
      uiMenu.AddItem(Race11);
      UIMenuItem Race12 = new UIMenuItem("Death Match (Scifi 10) 4x Opp");
      uiMenu.AddItem(Race12);
      UIMenuItem Race5 = new UIMenuItem("Death Match (Dystopian 5) 4x Opp");
      uiMenu.AddItem(Race5);
      UIMenuItem Race6 = new UIMenuItem("Death Match (Dystopian 10) 4x Opp");
      uiMenu.AddItem(Race6);
      UIMenuItem Race9 = new UIMenuItem("Death Match (Wasteland 5) 4x Opp");
      uiMenu.AddItem(Race9);
      UIMenuItem Race16 = new UIMenuItem("Death Match (Dystopian 7) 4x Opp");
      uiMenu.AddItem(Race16);
      UIMenuItem Race17 = new UIMenuItem("Death Match (Dystopian 12) 4x Opp");
      uiMenu.AddItem(Race17);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race17)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_12();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 26;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race16)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_8();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 26;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race12)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_10();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 26;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race11)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 26;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race9)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadWasteland_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 26;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race6)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_10();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 26;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race5)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 26;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race4)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        foreach (Prop prop in this.Props)
        {
          if ((Entity) prop != (Entity) null)
            prop.Delete();
        }
        Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
        this.LoadScifi_2();
        UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
        this.RaceMarker = new Vector3(2640f, -3801f, 140f);
        Script.Wait(200);
        GTA.Model vehicle1 = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle1, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
        this.VtoGetBlip.Name = "Start Marker";
        this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Start Marker";
        this.Race = 1;
        this.MissionId = 26;
        this.MissionSetup = true;
        this.StartedRace = false;
        this.TimeLeft = 40;
        Game.Player.Character.IsInvincible = true;
        this.checkpointReaced = 0;
        this.moneytobeawarded = 0.0f;
        this.vehicleHealth = 600;
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
      });
    }

    public void SetupArenaMenu()
    {
      List<object> TF = new List<object>();
      TF.Add((object) false);
      TF.Add((object) true);
      List<object> Type = new List<object>();
      Type.Add((object) "Apocalypse");
      Type.Add((object) "Nightmare");
      Type.Add((object) "Future Shock");
      List<object> VEH = new List<object>();
      VEH.Add((object) "Bruiser");
      VEH.Add((object) "Bruitus");
      VEH.Add((object) "Cerberus");
      VEH.Add((object) "DeathBike");
      VEH.Add((object) "Dominator");
      VEH.Add((object) "Impaler");
      VEH.Add((object) "Imperator");
      VEH.Add((object) "Issi");
      VEH.Add((object) "Monster");
      VEH.Add((object) "Scarab");
      VEH.Add((object) "Slamvan");
      VEH.Add((object) "ZR380");
      UIMenu uiMenu1 = this.ArenaMenuPool.AddSubMenu(this.ArenaMenu, "Request Vehicle");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem V = new UIMenuListItem("Vehicle : ", VEH, 0);
      uiMenu1.AddItem((UIMenuItem) V);
      UIMenuListItem T = new UIMenuListItem("Type : ", Type, 0);
      uiMenu1.AddItem((UIMenuItem) T);
      UIMenuItem RequestV1 = new UIMenuItem("Request Vehicle");
      uiMenu1.AddItem(RequestV1);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != RequestV1)
          return;
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__616.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__616.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string str1 = Class1.\u003C\u003Eo__616.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__616.\u003C\u003Ep__0, VEH[V.Index]);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__616.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__616.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string str2 = Class1.\u003C\u003Eo__616.\u003C\u003Ep__1.Target((CallSite) Class1.\u003C\u003Eo__616.\u003C\u003Ep__1, Type[T.Index]);
        string str3 = "";
        VehicleHash vehicleHash = VehicleHash.Adder;
        if (str2.Equals("Apocalypse"))
        {
          str3 = "1Apocalypse.ini";
          if (str1.Equals("Bruiser"))
            vehicleHash = VehicleHash.Bruiser;
          if (str1.Equals("Bruitus"))
            vehicleHash = VehicleHash.Brutus;
          if (str1.Equals("Cerberus"))
            vehicleHash = VehicleHash.Cerberus;
          if (str1.Equals("DeathBike"))
            vehicleHash = VehicleHash.Deathbike;
          if (str1.Equals("Dominator"))
            vehicleHash = VehicleHash.Dominator4;
          if (str1.Equals("Impaler"))
            vehicleHash = VehicleHash.Impaler2;
          if (str1.Equals("Imperator"))
            vehicleHash = VehicleHash.Imperator;
          if (str1.Equals("Issi"))
            vehicleHash = VehicleHash.Issi4;
          if (str1.Equals("Monster"))
            vehicleHash = VehicleHash.Monster3;
          if (str1.Equals("Scarab"))
            vehicleHash = VehicleHash.Scarab;
          if (str1.Equals("Slamvan"))
            vehicleHash = VehicleHash.SlamVan4;
          if (str1.Equals("ZR380"))
            vehicleHash = VehicleHash.ZR380;
        }
        if (str2.Equals("Nightmare"))
        {
          str3 = "2NIghtmare.ini";
          if (str1.Equals("Bruiser"))
            vehicleHash = VehicleHash.Bruiser3;
          if (str1.Equals("Bruitus"))
            vehicleHash = VehicleHash.Brutus3;
          if (str1.Equals("Cerberus"))
            vehicleHash = VehicleHash.Cerberus3;
          if (str1.Equals("DeathBike"))
            vehicleHash = VehicleHash.Deathbike3;
          if (str1.Equals("Dominator"))
            vehicleHash = VehicleHash.Dominator6;
          if (str1.Equals("Impaler"))
            vehicleHash = VehicleHash.Impaler4;
          if (str1.Equals("Imperator"))
            vehicleHash = VehicleHash.Imperator3;
          if (str1.Equals("Issi"))
            vehicleHash = VehicleHash.Issi6;
          if (str1.Equals("Monster"))
            vehicleHash = VehicleHash.Monster5;
          if (str1.Equals("Scarab"))
            vehicleHash = VehicleHash.Scarab3;
          if (str1.Equals("Slamvan"))
            vehicleHash = VehicleHash.SlamVan6;
          if (str1.Equals("ZR380"))
            vehicleHash = VehicleHash.ZR3803;
        }
        if (str2.Equals("Future Shock"))
        {
          str3 = "3FutureShock.ini";
          if (str1.Equals("Bruiser"))
            vehicleHash = VehicleHash.Bruiser2;
          if (str1.Equals("Bruitus"))
            vehicleHash = VehicleHash.Brutus2;
          if (str1.Equals("Cerberus"))
            vehicleHash = VehicleHash.Cerberus2;
          if (str1.Equals("DeathBike"))
            vehicleHash = VehicleHash.Deathbike2;
          if (str1.Equals("Dominator"))
            vehicleHash = VehicleHash.Dominator5;
          if (str1.Equals("Impaler"))
            vehicleHash = VehicleHash.Impaler3;
          if (str1.Equals("Imperator"))
            vehicleHash = VehicleHash.Imperator2;
          if (str1.Equals("Issi"))
            vehicleHash = VehicleHash.Issi5;
          if (str1.Equals("Monster"))
            vehicleHash = VehicleHash.Monster4;
          if (str1.Equals("Scarab"))
            vehicleHash = VehicleHash.Scarab2;
          if (str1.Equals("Slamvan"))
            vehicleHash = VehicleHash.SlamVan5;
          if (str1.Equals("ZR380"))
            vehicleHash = VehicleHash.ZR3802;
        }
        this.SC.LoadIniFile(this.Loadpath + str1 + "//" + str3);
        Script.Wait(1);
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle((GTA.Model) vehicleHash, new Vector3(2785f, -3909.6f, 140f), 0.0f);
        Script.Wait(20);
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.SC.Load(this.PLayerVehicle);
      });
      UIMenu uiMenu2 = this.ArenaMenuPool.AddSubMenu(this.ArenaMenu, "Request Random Vehicle");
      this.GUIMenus.Add(uiMenu2);
      UIMenuListItem RNDMods = new UIMenuListItem("Random Mods : ", TF, 0);
      uiMenu2.AddItem((UIMenuItem) RNDMods);
      UIMenuItem RequestV2 = new UIMenuItem("Request Vehicle");
      uiMenu2.AddItem(RequestV2);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != RequestV2)
          return;
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(this.getVehicle(), new Vector3(2785f, -3909.6f, 140f), 0.0f);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__616.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__616.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target = Class1.\u003C\u003Eo__616.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p3 = Class1.\u003C\u003Eo__616.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__616.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__616.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__616.\u003C\u003Ep__2.Target((CallSite) Class1.\u003C\u003Eo__616.\u003C\u003Ep__2, TF[RNDMods.Index], true);
        if (target((CallSite) p3, obj))
          this.SetupRivalCar(0, this.PLayerVehicle);
      });
    }

    private void SetupMarker()
    {
      this.TowerBlip = World.CreateBlip(new Vector3(-371f, -1850f, 20f));
      Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.TowerBlip, (InputArgument) 458);
      this.TowerBlip.Color = this.Blip_Colour;
      this.TowerBlip.Name = "Arena War Business ";
      this.TowerBlip.IsShortRange = true;
      this.TowerBlip2 = World.CreateBlip(new Vector3(-393f, -1870f, 20f));
      Function.Call(Hash._0xDF735600A4696DAF, (InputArgument) this.TowerBlip2, (InputArgument) 269);
      this.TowerBlip2.Color = this.Blip_Colour;
      this.TowerBlip2.Name = "Arena War Business (Arena Teleport)";
      this.TowerBlip2.IsShortRange = true;
    }

    private void SetupRaces()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SpecialMissions, "Races");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race5 = new UIMenuItem("Arena War Race (3 Lap, RaceTrack)");
      uiMenu.AddItem(Race5);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Race5)
          return;
        this.MissionSetup = true;
        this.MissionId = 3;
        this.Race = 5;
        this.RaceMarker = new Vector3(1099f, 163f, 81f);
        this.StartedRace = false;
        this.RaceBlip = World.CreateBlip(this.RaceMarker);
        this.RaceBlip.Name = "Arena War Race";
        this.RaceBlip.Sprite = BlipSprite.Race;
        UI.Notify(this.GetHostName() + " i just heard of a race down at the race track, teach thos fools a lesson!");
        Game.Player.Character.Position = this.RaceMarker;
        GTA.Model vehicle = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(1108f, 188f, 81f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
      });
    }

    public void LoadCarinToRealWorld(Vehicle V)
    {
      if ((Entity) V == (Entity) this.ZR380)
        this.ZR380 = (Vehicle) null;
      if ((Entity) V == (Entity) this.Bruiser)
        this.Bruiser = (Vehicle) null;
      if ((Entity) V == (Entity) this.Clique)
        this.Clique = (Vehicle) null;
      if ((Entity) V == (Entity) this.Italigto)
        this.Italigto = (Vehicle) null;
      if ((Entity) V == (Entity) this.Vamos)
        this.Vamos = (Vehicle) null;
      if ((Entity) V == (Entity) this.Tulip)
        this.Tulip = (Vehicle) null;
      if ((Entity) V == (Entity) this.Schlagen)
        this.Schlagen = (Vehicle) null;
      if ((Entity) V == (Entity) this.Deviant)
        this.Deviant = (Vehicle) null;
      if ((Entity) V == (Entity) this.Toros)
        this.Toros = (Vehicle) null;
      if ((Entity) V == (Entity) this.Deveste)
        this.Deveste = (Vehicle) null;
      if ((Entity) V == (Entity) this.RcBandito)
        this.RcBandito = (Vehicle) null;
      if ((Entity) V == (Entity) this.Cerberus)
        this.Cerberus = (Vehicle) null;
      if ((Entity) V == (Entity) this.Deathbike)
        this.Deathbike = (Vehicle) null;
      if ((Entity) V == (Entity) this.Scarab)
        this.Scarab = (Vehicle) null;
      if ((Entity) V == (Entity) this.Dominator)
        this.Dominator = (Vehicle) null;
      if ((Entity) V == (Entity) this.Slamvan)
        this.Slamvan = (Vehicle) null;
      if ((Entity) V == (Entity) this.Monster)
        this.Monster = (Vehicle) null;
      if ((Entity) V == (Entity) this.Issi)
        this.Issi = (Vehicle) null;
      if ((Entity) V == (Entity) this.Impaler)
        this.Impaler = (Vehicle) null;
      if ((Entity) V == (Entity) this.Imperator)
        this.Imperator = (Vehicle) null;
      if ((Entity) V == (Entity) this.Bruitus)
        this.Bruitus = (Vehicle) null;
      Vehicle vehicle = V;
      V = (Vehicle) null;
      this.IsInInterior = false;
      vehicle.Position = new Vector3(-371.8876f, -1850f, 21f);
      vehicle.Rotation = new Vector3(6f, -1f, 10f);
      Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
      vehicle.IsDriveable = true;
      this.DeleteVehicles();
      if ((Entity) this.SaveVehicle != (Entity) null)
        this.SaveVehicle.MarkAsNoLongerNeeded();
      this.SaveVehicle = vehicle;
      this.SaveVehicle.IsDriveable = true;
      this.SaveVehicle.Repair();
      this.SaveVehicle.FreezePosition = false;
      this.SaveVehicle.HighBeamsOn = false;
      this.SaveVehicle.FreezePosition = false;
      this.isInGarage = false;
      this.isinsecondVehicleBay = false;
      this.IsInInterior = false;
      this.LastVehicle = (Vehicle) null;
    }

    public void LoadCarinToRealWorld2(Vehicle V)
    {
      this.isInGarage = false;
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      currentVehicle.Position = new Vector3(-371.8876f, -1850f, 21f);
      Game.Player.Character.SetIntoVehicle(currentVehicle, VehicleSeat.Driver);
      this.DestoryCars();
      this.DeleteVehicles();
      currentVehicle.IsDriveable = true;
      currentVehicle.Rotation = new Vector3(6f, -1f, 10f);
      if ((Entity) this.SaveVehicle != (Entity) null)
        this.SaveVehicle.MarkAsNoLongerNeeded();
      this.SaveVehicle = currentVehicle;
      this.SaveVehicle.IsDriveable = true;
      this.SaveVehicle.FreezePosition = false;
      this.SaveVehicle.Repair();
      this.SaveVehicle.FreezePosition = false;
      this.SaveVehicle.HighBeamsOn = false;
      this.isInGarage = false;
      this.isinsecondVehicleBay = false;
      this.IsInInterior = false;
      this.LastVehicle = (Vehicle) null;
    }

    public void SaveLocalcar(string iniFile, Vehicle V, string FileName)
    {
      if (!((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
        return;
      UI.Notify(this.Loadpath + FileName + "//" + iniFile + ".ini");
      this.SC.LoadIniFile(this.Loadpath + FileName + "//" + iniFile + ".ini");
      this.SC.SaveWithoutDelete();
      UI.Notify(this.GetHostName() + " Save current vehicle");
    }

    public void LoadVehicles()
    {
      this.DeleteVehicles();
      try
      {
        this.Cerberus = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Scarab = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Dominator = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Imperator = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Deathbike = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Issi = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Monster = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Impaler = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Slamvan = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Bruitus = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.DeleteVehicles();
        if (this.CurrentCerberus == 1)
        {
          if (this.ApocalypseCerberusBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Cerberus//1Apocalypse.ini");
            this.Cerberus = World.CreateVehicle(this.RequestModel(VehicleHash.Cerberus), this.CerberusSpawn, -90f);
            this.SC.Load(this.Cerberus);
          }
        }
        else if (this.CurrentCerberus == 3)
        {
          if (this.FutureShockCerberusBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Cerberus//3FutureShock.ini");
            this.Cerberus = World.CreateVehicle(this.RequestModel(VehicleHash.Cerberus2), this.CerberusSpawn, -90f);
            this.SC.Load(this.Cerberus);
          }
        }
        else if (this.CurrentCerberus == 2 && this.NightmareCerberusBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Cerberus//2NIghtmare.ini");
          this.Cerberus = World.CreateVehicle(this.RequestModel(VehicleHash.Cerberus3), this.CerberusSpawn, -90f);
          this.SC.Load(this.Cerberus);
        }
        if (this.CurrentScarab == 1)
        {
          if (this.ApocalypseScarabBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Scarab//1Apocalypse.ini");
            this.Scarab = World.CreateVehicle(this.RequestModel(VehicleHash.Scarab), this.ScarabSpawn, 90f);
            this.SC.Load(this.Scarab);
          }
        }
        else if (this.CurrentScarab == 3)
        {
          if (this.FutureShockScarabBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Scarab//3FutureShock.ini");
            this.Scarab = World.CreateVehicle(this.RequestModel(VehicleHash.Scarab2), this.ScarabSpawn, 90f);
            this.SC.Load(this.Scarab);
          }
        }
        else if (this.CurrentScarab == 2 && this.NightmareScarabBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Scarab//2NIghtmare.ini");
          this.Scarab = World.CreateVehicle(this.RequestModel(VehicleHash.Scarab3), this.ScarabSpawn, 90f);
          this.SC.Load(this.Scarab);
        }
        if (this.CurrentDominator == 1)
        {
          if (this.ApocalypseDominatorBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Dominator//1Apocalypse.ini");
            this.Dominator = World.CreateVehicle(this.RequestModel(VehicleHash.Dominator4), this.DominatorSpawn, -90f);
            this.SC.Load(this.Dominator);
          }
        }
        else if (this.CurrentDominator == 3)
        {
          if (this.FutureShockDominatorBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Dominator//3FutureShock.ini");
            this.Dominator = World.CreateVehicle(this.RequestModel(VehicleHash.Dominator5), this.DominatorSpawn, -90f);
            this.SC.Load(this.Dominator);
          }
        }
        else if (this.CurrentDominator == 2 && this.NightmareDominatorBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Dominator//2NIghtmare.ini");
          this.Dominator = World.CreateVehicle(this.RequestModel(VehicleHash.Dominator6), this.DominatorSpawn, -90f);
          this.SC.Load(this.Dominator);
        }
        if (this.CurrentImperator == 1)
        {
          if (this.ApocalypseDominatorBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Imperator//1Apocalypse.ini");
            this.Imperator = World.CreateVehicle(this.RequestModel(VehicleHash.Imperator), this.ImperatorSpawn, 90f);
            this.SC.Load(this.Imperator);
          }
        }
        else if (this.CurrentImperator == 3)
        {
          if (this.FutureShockImperatorBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Imperator//3FutureShock.ini");
            this.Imperator = World.CreateVehicle(this.RequestModel(VehicleHash.Imperator2), this.ImperatorSpawn, 90f);
            this.SC.Load(this.Imperator);
          }
        }
        else if (this.CurrentImperator == 2 && this.NightmareImperatorBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Imperator//2NIghtmare.ini");
          this.Imperator = World.CreateVehicle(this.RequestModel(VehicleHash.Imperator3), this.ImperatorSpawn, 90f);
          this.SC.Load(this.Imperator);
        }
        if (this.CurrentDeathbike == 1)
        {
          if (this.ApocalypseDeathbikeBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Deathbike//1Apocalypse.ini");
            this.Deathbike = World.CreateVehicle(this.RequestModel(VehicleHash.Deathbike), this.DeathbikeSpawn, -90f);
            this.SC.Load(this.Deathbike);
          }
        }
        else if (this.CurrentDeathbike == 3)
        {
          if (this.FutureShockDeathbikeBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Deathbike//3FutureShock.ini");
            this.Deathbike = World.CreateVehicle(this.RequestModel(VehicleHash.Deathbike2), this.DeathbikeSpawn, -90f);
            this.SC.Load(this.Deathbike);
          }
        }
        else if (this.CurrentDeathbike == 2 && this.NightmareDeathbikeBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Deathbike//2NIghtmare.ini");
          this.Deathbike = World.CreateVehicle(this.RequestModel(VehicleHash.Deathbike3), this.DeathbikeSpawn, -90f);
          this.SC.Load(this.Deathbike);
        }
        if (this.CurrentIssi == 1)
        {
          if (this.ApocalypseIssiBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Issi//1Apocalypse.ini");
            this.Issi = World.CreateVehicle(this.RequestModel(VehicleHash.Issi4), this.IssiSpawn, -90f);
            this.SC.Load(this.Issi);
          }
        }
        else if (this.CurrentIssi == 3)
        {
          if (this.FutureShockIssiBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Issi//3FutureShock.ini");
            this.Issi = World.CreateVehicle(this.RequestModel(VehicleHash.Issi5), this.IssiSpawn, -90f);
            this.SC.Load(this.Issi);
          }
        }
        else if (this.CurrentIssi == 2 && this.NightmareIssiBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Issi//2NIghtmare.ini");
          this.Issi = World.CreateVehicle(this.RequestModel(VehicleHash.Issi6), this.IssiSpawn, -90f);
          this.SC.Load(this.Issi);
        }
        if (this.CurrentMonster == 1)
        {
          if (this.ApocalypseMonsterBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Monster//1Apocalypse.ini");
            this.Monster = World.CreateVehicle(this.RequestModel(VehicleHash.Monster3), this.MonsterSpawn, -90f);
            this.SC.Load(this.Monster);
          }
        }
        else if (this.CurrentMonster == 3)
        {
          if (this.FutureShockMonsterBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Monster//3FutureShock.ini");
            this.Monster = World.CreateVehicle(this.RequestModel(VehicleHash.Monster4), this.MonsterSpawn, -90f);
            this.SC.Load(this.Monster);
          }
        }
        else if (this.CurrentMonster == 2 && this.NightmareMonsterBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Monster//2NIghtmare.ini");
          this.Monster = World.CreateVehicle(this.RequestModel(VehicleHash.Monster5), this.MonsterSpawn, -90f);
          this.SC.Load(this.Monster);
        }
        if (this.CurrentImpaler == 1)
        {
          if (this.ApocalypseImpalerBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Impaler//1Apocalypse.ini");
            this.Impaler = World.CreateVehicle(this.RequestModel(VehicleHash.Impaler2), this.ImpalerSpawn, 90f);
            this.SC.Load(this.Impaler);
          }
        }
        else if (this.CurrentImpaler == 3)
        {
          if (this.FutureShockImpalerBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Impaler//3FutureShock.ini");
            this.Impaler = World.CreateVehicle(this.RequestModel(VehicleHash.Impaler3), this.ImpalerSpawn, 90f);
            this.SC.Load(this.Impaler);
          }
        }
        else if (this.CurrentImpaler == 2 && this.NightmareImpalerBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Impaler//2NIghtmare.ini");
          this.Impaler = World.CreateVehicle(this.RequestModel(VehicleHash.Impaler4), this.ImpalerSpawn, 90f);
          this.SC.Load(this.Impaler);
        }
        if (this.CurrentSlamvan == 1)
        {
          if (this.ApocalypseSlamvanBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Slamvan//1Apocalypse.ini");
            this.Slamvan = World.CreateVehicle(this.RequestModel(VehicleHash.SlamVan4), this.SlamvanSpawn, -90f);
            this.SC.Load(this.Slamvan);
          }
        }
        else if (this.CurrentSlamvan == 3)
        {
          if (this.FutureShockSlamvanBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Slamvan//3FutureShock.ini");
            this.Slamvan = World.CreateVehicle(this.RequestModel(VehicleHash.SlamVan5), this.SlamvanSpawn, -90f);
            this.SC.Load(this.Slamvan);
          }
        }
        else if (this.CurrentSlamvan == 2 && this.NightmareSlamvanBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Slamvan//2NIghtmare.ini");
          this.Slamvan = World.CreateVehicle(this.RequestModel(VehicleHash.SlamVan6), this.SlamvanSpawn, -90f);
          this.SC.Load(this.Slamvan);
        }
        if (this.CurrentBruitus == 1)
        {
          if (this.ApocalypseBruitusBought != 1)
            return;
          this.SC.LoadIniFile(this.Loadpath + "Brutus//1Apocalypse.ini");
          this.Bruitus = World.CreateVehicle(this.RequestModel(VehicleHash.Brutus), this.BruitusSpawn, 90f);
          this.SC.Load(this.Bruitus);
        }
        else if (this.CurrentBruitus == 3)
        {
          if (this.FutureShockBruitusBought != 1)
            return;
          this.SC.LoadIniFile(this.Loadpath + "Brutus//3FutureShock.ini");
          this.Bruitus = World.CreateVehicle(this.RequestModel(VehicleHash.Brutus2), this.BruitusSpawn, 90f);
          this.SC.Load(this.Bruitus);
        }
        else
        {
          if (this.CurrentBruitus != 2 || this.NightmareBruitusBought != 1)
            return;
          this.SC.LoadIniFile(this.Loadpath + "Brutus//2NIghtmare.ini");
          this.Bruitus = World.CreateVehicle(this.RequestModel(VehicleHash.Brutus3), this.BruitusSpawn, 90f);
          this.SC.Load(this.Bruitus);
        }
      }
      catch (NullReferenceException ex)
      {
        UI.Notify("~r~ Arena War Main Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
      }
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
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        this.MoneyStored = this.Config.GetValue<float>("ADDON2", "MONEYSTORED[" + this.currentbank.ToString() + "]", this.MoneyStored);
        UI.Notify("Agent 14  : Moeny in Vault  ~b~" + this.currentbank.ToString() + "~w~, ~g~$" + this.MoneyStored.ToString("N"));
      });
    }

    public void LoadVehicles2()
    {
      this.DeleteVehicles();
      try
      {
        this.ZR380 = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Bruiser = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Clique = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Italigto = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Tulip = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Vamos = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Schlagen = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Deveste = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Deviant = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.Toros = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.RcBandito = World.CreateVehicle((GTA.Model) VehicleHash.Adder, new Vector3(0.0f, 0.0f, 0.0f));
        this.DeleteVehicles();
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        if (this.CurrentZR380 == 1)
        {
          if (this.ApocalypseZR380Bought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "ZR380//1Apocalypse.ini");
            this.ZR380 = World.CreateVehicle(this.RequestModel(VehicleHash.ZR380), this.ZR380Spawn, 90f);
            this.SC.Load(this.ZR380);
          }
        }
        else if (this.CurrentZR380 == 3)
        {
          if (this.FutureShockZR380Bought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "ZR380//3FutureShock.ini");
            this.ZR380 = World.CreateVehicle(this.RequestModel(VehicleHash.ZR3802), this.ZR380Spawn, 90f);
            this.SC.Load(this.ZR380);
          }
        }
        else if (this.CurrentZR380 == 2 && this.NightmareZR380Bought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "ZR380//2NIghtmare.ini");
          this.ZR380 = World.CreateVehicle(this.RequestModel(VehicleHash.ZR3803), this.ZR380Spawn, 90f);
          this.SC.Load(this.ZR380);
        }
        Script.Wait(50);
        if (this.CurrentBruiser == 1)
        {
          if (this.ApocalypseBruiserBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Bruiser//1Apocalypse.ini");
            this.Bruiser = World.CreateVehicle(this.RequestModel(VehicleHash.Bruiser), this.BruiserSpawn, -90f);
            this.SC.Load(this.Bruiser);
          }
        }
        else if (this.CurrentBruiser == 3)
        {
          if (this.FutureShockBruiserBought == 1)
          {
            this.SC.LoadIniFile(this.Loadpath + "Bruiser//3FutureShock.ini");
            this.Bruiser = World.CreateVehicle(this.RequestModel(VehicleHash.Bruiser2), this.BruiserSpawn, -90f);
            this.SC.Load(this.Bruiser);
          }
        }
        else if (this.CurrentBruiser == 2 && this.NightmareBruiserBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Bruiser//2NIghtmare.ini");
          this.Bruiser = World.CreateVehicle(this.RequestModel(VehicleHash.Bruiser3), this.BruiserSpawn, -90f);
          this.SC.Load(this.Bruiser);
        }
        Script.Wait(50);
        if (this.CliqueBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Clique//Car.ini");
          this.Clique = World.CreateVehicle(this.RequestModel(VehicleHash.Clique), this.CliqueSpawn, 90f);
          this.SC.Load(this.Clique);
        }
        Script.Wait(50);
        if (this.ItaligtoBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Italigto//Car.ini");
          this.Italigto = World.CreateVehicle(this.RequestModel(VehicleHash.ItaliGTO), this.ItaligtoSpawn, -90f);
          this.SC.Load(this.Italigto);
        }
        Script.Wait(50);
        if (this.TulipBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Tulip//Car.ini");
          this.Tulip = World.CreateVehicle(this.RequestModel(VehicleHash.Tulip), this.TulipSpawn, -90f);
          this.SC.Load(this.Tulip);
        }
        Script.Wait(50);
        if (this.VamosBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Vamos//Car.ini");
          this.Vamos = World.CreateVehicle(this.RequestModel(VehicleHash.Vamos), this.VamosSpawn, -90f);
          this.SC.Load(this.Vamos);
        }
        Script.Wait(50);
        if (this.SchlagenBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Schlagen//Car.ini");
          this.Schlagen = World.CreateVehicle(this.RequestModel(VehicleHash.Schlagen), this.SchlagenSpawn, 90f);
          this.SC.Load(this.Schlagen);
        }
        Script.Wait(50);
        if (this.DeviantBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Deviant//Car.ini");
          this.Deviant = World.CreateVehicle(this.RequestModel(VehicleHash.Deviant), this.DeviantSpawn, -90f);
          this.SC.Load(this.Deviant);
        }
        Script.Wait(50);
        if (this.TorosBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Toros//Car.ini");
          this.Toros = World.CreateVehicle(this.RequestModel(VehicleHash.Toros), this.TorosSpawn, 90f);
          this.SC.Load(this.Toros);
        }
        Script.Wait(50);
        if (this.DevesteBought == 1)
        {
          this.SC.LoadIniFile(this.Loadpath + "Deveste//Car.ini");
          this.Deveste = World.CreateVehicle(this.RequestModel(VehicleHash.Deveste), this.DevesteSpawn, -90f);
          this.SC.Load(this.Deveste);
        }
        Script.Wait(50);
        if (this.RcBanditoBought != 1)
          return;
        this.SC.LoadIniFile(this.Loadpath + "rcbandito//Car.ini");
        this.RcBandito = World.CreateVehicle(this.RequestModel(VehicleHash.RCBandito), this.RcBanditoSpawn, 90f);
        this.SC.Load(this.RcBandito);
      }
      catch (NullReferenceException ex)
      {
        UI.Notify("~r~ Arena War Second Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
      }
    }

    private void SetupSpecialMissions8()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.DemoltionMenMenu, "Demolition Men");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race6 = new UIMenuItem("Demolition Men, 4x Opp (Dystopian 5)");
      uiMenu.AddItem(Race6);
      UIMenuItem Race7 = new UIMenuItem("Demolition Men, 4x Opp (Dystopian 10)");
      uiMenu.AddItem(Race7);
      UIMenuItem Race8 = new UIMenuItem("Demolition Men, 4x Opp (Scifi 5)");
      uiMenu.AddItem(Race8);
      UIMenuItem Race9 = new UIMenuItem("Demolition Men, 4x Opp (Scifi 10)");
      uiMenu.AddItem(Race9);
      UIMenuItem Race5 = new UIMenuItem("Demolition Men, 4x Opp (Wasteland 2)");
      uiMenu.AddItem(Race5);
      UIMenuItem Race4 = new UIMenuItem("Demolition Men, 4x Opp (Wasteland 5)");
      uiMenu.AddItem(Race4);
      UIMenuItem Race10 = new UIMenuItem("Demolition Men, 4x Opp (Random Track & Car)");
      uiMenu.AddItem(Race10);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race10)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.FinishLineBLip != (Blip) null)
            this.FinishLineBLip.Remove();
          int num = new System.Random().Next(1, 80);
          if (num < 10)
            this.LoadDystopian_10();
          if (num > 10 && num < 20)
            this.LoadDystopian_5();
          if (num > 20 && num < 30)
            this.LoadScifi_2();
          if (num > 30 && num < 40)
            this.LoadScifi_5();
          if (num > 40 && num < 50)
            this.LoadScifi_10();
          if (num > 50 && num < 60)
            this.LoadWasteland_5();
          if (num > 60 && num < 70)
            this.LoadWasteland_5();
          if (num > 70 && num < 80)
            this.LoadDystopian_12();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          UI.Notify(this.GetHostName() + " ok boss, avoid the opponents to earn money, survive for aslong as possible");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 2;
          this.MissionId = 20;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race8)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.FinishLineBLip != (Blip) null)
            this.FinishLineBLip.Remove();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_5();
          UI.Notify(this.GetHostName() + " ok boss, avoid the rc banditos to earn money, survive for aslong as possible");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 20;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race9)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.FinishLineBLip != (Blip) null)
            this.FinishLineBLip.Remove();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_10();
          UI.Notify(this.GetHostName() + " ok boss, avoid the rc banditos to earn money, survive for aslong as possible");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 20;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race6)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.FinishLineBLip != (Blip) null)
            this.FinishLineBLip.Remove();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_5();
          UI.Notify(this.GetHostName() + " ok boss, avoid the rc banditos to earn money, survive for aslong as possible");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 20;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race7)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.FinishLineBLip != (Blip) null)
            this.FinishLineBLip.Remove();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_10();
          UI.Notify(this.GetHostName() + " ok boss, avoid the rc banditos to earn money, survive for aslong as possible");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 20;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race5)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.FinishLineBLip != (Blip) null)
            this.FinishLineBLip.Remove();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadWasteland_2();
          UI.Notify(this.GetHostName() + " ok boss, avoid the rc banditos to earn money, survive for aslong as possible");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 20;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race4)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        if (this.FinishLineBLip != (Blip) null)
          this.FinishLineBLip.Remove();
        Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
        this.LoadWasteland_5();
        UI.Notify(this.GetHostName() + " ok boss, avoid the rc banditos to earn money, survive for aslong as possible");
        this.RaceMarker = new Vector3(2640f, -3801f, 140f);
        Script.Wait(200);
        GTA.Model vehicle1 = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle1, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
        this.VtoGetBlip.Name = "Start Marker";
        this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Start Marker";
        this.Race = 1;
        this.MissionId = 20;
        this.MissionSetup = true;
        this.StartedRace = false;
        this.TimeLeft = 40;
        Game.Player.Character.IsInvincible = true;
        this.checkpointReaced = 0;
        this.moneytobeawarded = 0.0f;
        this.vehicleHealth = 600;
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
      });
    }

    private void SetupSpecialMissions7()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.BeastWars, "Beast Wars");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("Beast Wars  1, 4x Opp (Scifi 5)");
      uiMenu.AddItem(Race4);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Race4)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        if ((Entity) this.PLayerVehicle2 != (Entity) null)
          this.PLayerVehicle2.Delete();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null && (Entity) ped.CurrentVehicle == (Entity) null)
            ped.Delete();
        }
        Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
        this.LoadScifi_5();
        UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
        this.RaceMarker = new Vector3(2640f, -3801f, 140f);
        Script.Wait(200);
        new System.Random().Next(1, 100);
        GTA.Model vehicle2 = this.getVehicle2();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle2, Game.Player.Character.Position);
        this.PLayerVehicle2 = World.CreateVehicle((GTA.Model) VehicleHash.TrailerSmall2, Game.Player.Character.Position);
        this.PLayerVehicle2.AttachTo((Entity) this.PLayerVehicle, 0);
        this.PLayerVehicle2.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        this.Friendlyped = this.PLayerVehicle2.GetPedOnSeat(VehicleSeat.Driver);
        this.Friendlyped.IsInvincible = true;
        this.PLayerVehicle2.GetPedOnSeat(VehicleSeat.Driver).IsInvincible = true;
        this.PLayerVehicle2.GetPedOnSeat(VehicleSeat.Driver).CanBeTargetted = false;
        this.Peds.Add(this.PLayerVehicle2.GetPedOnSeat(VehicleSeat.Driver));
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        Ped pedOnSeat = this.PLayerVehicle2.GetPedOnSeat(VehicleSeat.Driver);
        int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "RESPECT_PLAYER");
        Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) pedOnSeat, (InputArgument) num);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        this.SetupRivalCar(0, this.PLayerVehicle);
        this.PLayerVehicle2.PrimaryColor = this.PLayerVehicle.PrimaryColor;
        this.PLayerVehicle2.SecondaryColor = this.PLayerVehicle.SecondaryColor;
        new System.Random().Next(1, 300);
        this.PLayerVehicle2.SetMod(VehicleMod.Roof, -1, true);
        this.PLayerVehicle2.SetNoCollision((Entity) this.PLayerVehicle, true);
        this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
        this.VtoGetBlip.Name = "Start Marker";
        this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Start Marker";
        this.Race = 1;
        this.MissionId = 16;
        this.MissionSetup = true;
        this.StartedRace = false;
        this.TimeLeft = 40;
        Game.Player.Character.IsInvincible = true;
        this.checkpointReaced = 0;
        this.moneytobeawarded = 0.0f;
        this.vehicleHealth = 600;
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
        this.PLayerVehicle.BodyHealth = 2000f;
        this.PLayerVehicle2.BodyHealth = 2000f;
      });
    }

    private void SetupSpecialMissions6()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SmashandGrab, "Smash And Grab");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("Smash and Grab 1, 4x Opp (Wasteland 5)");
      uiMenu.AddItem(Race4);
      UIMenuItem Race5 = new UIMenuItem("Smash and Grab 1, 8x Opp (Wasteland 5)");
      uiMenu.AddItem(Race5);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race5)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.FinishLineBLip != (Blip) null)
            this.FinishLineBLip.Remove();
          this.LoadWasteland_5();
          Game.Player.Character.Position = new Vector3(2773f, -3853.73f, 130f);
          UI.Notify(this.GetHostName() + " ok boss, ok boss grab the loot from the opposite goal and bring it back to ours for money");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          this.PLayerVehicle = World.CreateVehicle(this.getVehicle(), new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.FinishLineBLip = World.CreateBlip(this.RaceMarker);
          this.FinishLineBLip.Name = "Start Marker";
          this.FinishLineBLip.Sprite = BlipSprite.RaceFinish;
          this.FinishLineBLip.Color = BlipColor.White;
          this.FinishLineBLip.Name = "Start Marker";
          this.Race = 2;
          this.MissionId = 15;
          this.MissionSetup = true;
          this.StartedRace = false;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race4)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        if (this.FinishLineBLip != (Blip) null)
          this.FinishLineBLip.Remove();
        this.LoadWasteland_5();
        Game.Player.Character.Position = new Vector3(2773f, -3853.73f, 130f);
        UI.Notify(this.GetHostName() + " ok boss, ok boss grab the loot from the opposite goal and bring it back to ours for money");
        this.RaceMarker = new Vector3(2640f, -3801f, 140f);
        Script.Wait(200);
        GTA.Model vehicle1 = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle1, new Vector3(2782.99f, -3898.15f, 140f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        this.FinishLineBLip = World.CreateBlip(this.RaceMarker);
        this.FinishLineBLip.Name = "Start Marker";
        this.FinishLineBLip.Sprite = BlipSprite.RaceFinish;
        this.FinishLineBLip.Color = BlipColor.White;
        this.FinishLineBLip.Name = "Start Marker";
        this.Race = 1;
        this.MissionId = 15;
        this.MissionSetup = true;
        this.StartedRace = false;
        Game.Player.Character.IsInvincible = true;
        this.checkpointReaced = 0;
        this.moneytobeawarded = 0.0f;
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
      });
    }

    private void SetupSpecialMissions5()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.HotRing, "Hot Ring Circuits");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("Hot Ring Circuit 1 (Wasteland 4)");
      uiMenu.AddItem(Race4);
      UIMenuItem Race5 = new UIMenuItem("Hot Ring Circuit 2 (Scifi 4)");
      uiMenu.AddItem(Race5);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race5)
        {
          this.MissionSetup = true;
          this.MissionId = 13;
          this.Race = 1;
          this.RaceMarker = new Vector3(2773f, -3853.73f, 130f);
          this.StartedRace = false;
          this.RaceBlip = World.CreateBlip(this.RaceMarker);
          this.RaceBlip.Name = "Hot Ring Circuit Race";
          this.RaceBlip.Sprite = BlipSprite.Race;
          UI.Notify(this.GetHostName() + " Race around around the Circuit, all the while avoiding the ");
          Game.Player.Character.Position = this.RaceMarker;
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          Game.Player.Character.IsInvincible = true;
          this.LoadScifi_4();
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race4)
          return;
        this.MissionSetup = true;
        this.MissionId = 13;
        this.Race = 1;
        this.RaceMarker = new Vector3(2773f, -3853.73f, 130f);
        this.StartedRace = false;
        this.RaceBlip = World.CreateBlip(this.RaceMarker);
        this.RaceBlip.Name = "Hot Ring Circuit Race";
        this.RaceBlip.Sprite = BlipSprite.Race;
        UI.Notify(this.GetHostName() + " Race around around the Circuit, all the while avoiding the ");
        Game.Player.Character.Position = this.RaceMarker;
        GTA.Model vehicle1 = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle1, new Vector3(2782.99f, -3898.15f, 140f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        Game.Player.Character.IsInvincible = true;
        this.LoadWasteland_4();
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
      });
    }

    private void SetupSpecialMissions4()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.RCKing, "RC King");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("RC King (Scifi 2)");
      uiMenu.AddItem(Race4);
      UIMenuItem Race5 = new UIMenuItem("RC King (Dystopian 3)");
      uiMenu.AddItem(Race5);
      UIMenuItem Race6 = new UIMenuItem("RC King (Wasteland 9)");
      uiMenu.AddItem(Race6);
      UIMenuItem Race7 = new UIMenuItem("RC King (Dystopian 7)");
      uiMenu.AddItem(Race7);
      UIMenuItem Race8 = new UIMenuItem("RC King (Scifi 9)");
      uiMenu.AddItem(Race8);
      UIMenuItem Race9 = new UIMenuItem("RC King (Wasteland 7)");
      uiMenu.AddItem(Race9);
      UIMenuItem Race10 = new UIMenuItem("RC King (BMX Park)");
      uiMenu.AddItem(Race10);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race10)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(-888f, -802f, 14f);
          UI.Notify(this.GetHostName() + " ok boss, drive this RC Bandito around, flipping it jumping over stuff to earn cash, in the given time limit");
          this.RaceMarker = new Vector3(-888f, -802f, 14f);
          Script.Wait(200);
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle((GTA.Model) "rcbandito", new Vector3(-888f, -802f, 14f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 2;
          this.MissionId = 4;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 80;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.PLayerVehicle.FreezePosition = false;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race9)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadWasteland_7();
          UI.Notify(this.GetHostName() + " ok boss, drive this RC Bandito around, flipping it jumping over stuff to earn cash, in the given time limit");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle((GTA.Model) "rcbandito", new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 4;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 80;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.PLayerVehicle.FreezePosition = false;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race8)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_9();
          UI.Notify(this.GetHostName() + " ok boss, drive this RC Bandito around, flipping it jumping over stuff to earn cash, in the given time limit");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle((GTA.Model) "rcbandito", new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 4;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 80;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.PLayerVehicle.FreezePosition = false;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race7)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_7();
          UI.Notify(this.GetHostName() + " ok boss, drive this RC Bandito around, flipping it jumping over stuff to earn cash, in the given time limit");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle((GTA.Model) "rcbandito", new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 4;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 80;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.PLayerVehicle.FreezePosition = false;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race6)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadWasteland_9();
          UI.Notify(this.GetHostName() + " ok boss, drive this RC Bandito around, flipping it jumping over stuff to earn cash, in the given time limit");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle((GTA.Model) "rcbandito", new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 4;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 80;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.PLayerVehicle.FreezePosition = false;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race5)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_3();
          UI.Notify(this.GetHostName() + " ok boss, drive this RC Bandito around, flipping it jumping over stuff to earn cash, in the given time limit");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle((GTA.Model) "rcbandito", new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 4;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 80;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.PLayerVehicle.FreezePosition = false;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race4)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
        this.LoadScifi_2();
        UI.Notify(this.GetHostName() + " ok boss, drive this RC Bandito around, flipping it jumping over stuff to earn cash, in the given time limit");
        this.RaceMarker = new Vector3(2731f, -3882f, 140f);
        Script.Wait(200);
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle((GTA.Model) "rcbandito", new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
        this.VtoGetBlip.Name = "Start Marker";
        this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Start Marker";
        this.Race = 1;
        this.MissionId = 4;
        this.MissionSetup = true;
        this.StartedRace = false;
        this.TimeLeft = 80;
        Game.Player.Character.IsInvincible = true;
        this.checkpointReaced = 0;
        this.moneytobeawarded = 0.0f;
        this.PLayerVehicle.FreezePosition = false;
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
      });
    }

    private void SetupSpecialMissions3()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.DeathMatch, "Vehicle Death Match");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("Death Match (Scifi 2) 4x Opp");
      uiMenu.AddItem(Race4);
      UIMenuItem Race11 = new UIMenuItem("Death Match (Scifi 5) 4x Opp");
      uiMenu.AddItem(Race11);
      UIMenuItem Race12 = new UIMenuItem("Death Match (Scifi 10) 4x Opp");
      uiMenu.AddItem(Race12);
      UIMenuItem Race5 = new UIMenuItem("Death Match (Dystopian 5) 4x Opp");
      uiMenu.AddItem(Race5);
      UIMenuItem Race6 = new UIMenuItem("Death Match (Dystopian 10) 4x Opp");
      uiMenu.AddItem(Race6);
      UIMenuItem Race9 = new UIMenuItem("Death Match (Wasteland 5) 4x Opp");
      uiMenu.AddItem(Race9);
      UIMenuItem Race16 = new UIMenuItem("Death Match (Dystopian 7) 4x Opp");
      uiMenu.AddItem(Race16);
      UIMenuItem Race17 = new UIMenuItem("Death Match (Dystopian 12) 4x Opp");
      uiMenu.AddItem(Race17);
      UIMenuItem Race8 = new UIMenuItem("Death Match (Scifi 2) 8x Opp");
      uiMenu.AddItem(Race8);
      UIMenuItem Race14 = new UIMenuItem("Death Match (Scifi 5) 8x Opp");
      uiMenu.AddItem(Race14);
      UIMenuItem Race15 = new UIMenuItem("Death Match (Scifi 10) 8x Opp");
      uiMenu.AddItem(Race15);
      UIMenuItem Race13 = new UIMenuItem("Death Match (Dystopian 5) 8x Opp");
      uiMenu.AddItem(Race13);
      UIMenuItem Race7 = new UIMenuItem("Death Match (Dystopian 10) 8x Opp");
      uiMenu.AddItem(Race7);
      UIMenuItem Race10 = new UIMenuItem("Death Match (Wasteland 5) 8x Opp");
      uiMenu.AddItem(Race10);
      UIMenuItem Race18 = new UIMenuItem("Death Match (Dystopian 7) 8x Opp");
      uiMenu.AddItem(Race18);
      UIMenuItem Race19 = new UIMenuItem("Death Match (Dystopian 12) 8x Opp");
      uiMenu.AddItem(Race19);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race19)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_12();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 5;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race18)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_8();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 5;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race17)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_12();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 2;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race16)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_8();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 2;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race15)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_10();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 5;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race14)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 5;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race13)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 5;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race12)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_10();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 2;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race11)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 2;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race10)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadWasteland_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 5;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race9)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadWasteland_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 2;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race8)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_2();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 5;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race7)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_10();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 5;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race6)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_10();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 2;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race5)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_5();
          UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
          this.RaceMarker = new Vector3(2640f, -3801f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 1;
          this.MissionId = 2;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.vehicleHealth = 600;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race4)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
        this.LoadScifi_2();
        UI.Notify(this.GetHostName() + " ok boss, destroy each vehicle to progress to the next wave to earn money, each wave vehicles are harded to destroy");
        this.RaceMarker = new Vector3(2640f, -3801f, 140f);
        Script.Wait(200);
        GTA.Model vehicle1 = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle1, new Vector3(2782.99f, -3898.15f, 140.001f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
        this.VtoGetBlip.Name = "Start Marker";
        this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Start Marker";
        this.Race = 1;
        this.MissionId = 2;
        this.MissionSetup = true;
        this.StartedRace = false;
        this.TimeLeft = 40;
        Game.Player.Character.IsInvincible = true;
        this.checkpointReaced = 0;
        this.moneytobeawarded = 0.0f;
        this.vehicleHealth = 600;
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
      });
    }

    private void SetupSpecialMissions2()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.PointtoPointMenu, "Point to Point");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race4 = new UIMenuItem("40 Second Start (Dystopian 2)");
      uiMenu.AddItem(Race4);
      UIMenuItem Race8 = new UIMenuItem("50 Second Start (Dystopian 3)");
      uiMenu.AddItem(Race8);
      UIMenuItem Race6 = new UIMenuItem("40 Second Start (Scifi 2)");
      uiMenu.AddItem(Race6);
      UIMenuItem Race9 = new UIMenuItem("50 Second Start (Scifi 9)");
      uiMenu.AddItem(Race9);
      UIMenuItem Race7 = new UIMenuItem("40 Second Start (Wasteland 2)");
      uiMenu.AddItem(Race7);
      UIMenuItem Race10 = new UIMenuItem("50 Second Start (Wasteland 9)");
      uiMenu.AddItem(Race10);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race4)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_2();
          UI.Notify(this.GetHostName() + " ok boss drive through the checkpoints to earn cash, while a timer counts to 0, good luck, oh and avoid the mines!");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 4;
          this.MissionId = 10;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race6)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_2();
          UI.Notify(this.GetHostName() + " ok boss drive through the checkpoints to earn cash, while a timer counts to 0, good luck, oh and avoid the mines!");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 6;
          this.MissionId = 10;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race7)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadWasteland_2();
          UI.Notify(this.GetHostName() + " ok boss drive through the checkpoints to earn cash, while a timer counts to 0, good luck, oh and avoid the mines!");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 7;
          this.MissionId = 10;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 40;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race8)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadDystopian_3();
          UI.Notify(this.GetHostName() + " ok boss drive through the checkpoints to earn cash, while a timer counts to 0, good luck, oh and avoid the mines!");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 8;
          this.MissionId = 10;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 50;
          Game.Player.Character.IsInvincible = true;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race9)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
          this.LoadScifi_9();
          UI.Notify(this.GetHostName() + " ok boss drive through the checkpoints to earn cash, while a timer counts to 0, good luck, oh and avoid the mines!");
          this.RaceMarker = new Vector3(2731f, -3882f, 140f);
          Script.Wait(200);
          GTA.Model vehicle = this.getVehicle();
          if ((Entity) this.PLayerVehicle != (Entity) null)
            this.PLayerVehicle.Delete();
          this.PLayerVehicle = World.CreateVehicle(vehicle, new Vector3(2782.99f, -3898.15f, 140f), 148f);
          Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
          this.SetupRivalCar(0, this.PLayerVehicle);
          this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
          this.VtoGetBlip.Name = "Start Marker";
          this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Start Marker";
          this.Race = 9;
          this.MissionId = 10;
          this.MissionSetup = true;
          this.StartedRace = false;
          this.TimeLeft = 50;
          Game.Player.Character.IsInvincible = true;
          this.checkpointReaced = 0;
          this.moneytobeawarded = 0.0f;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race10)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        Game.Player.Character.Position = new Vector3(2782.99f, -3898.15f, 140.001f);
        this.LoadWasteland_9();
        UI.Notify(this.GetHostName() + " ok boss drive through the checkpoints to earn cash, while a timer counts to 0, good luck, oh and avoid the mines!");
        this.RaceMarker = new Vector3(2731f, -3882f, 140f);
        Script.Wait(200);
        GTA.Model vehicle1 = this.getVehicle();
        if ((Entity) this.PLayerVehicle != (Entity) null)
          this.PLayerVehicle.Delete();
        this.PLayerVehicle = World.CreateVehicle(vehicle1, new Vector3(2782.99f, -3898.15f, 140f), 148f);
        Game.Player.Character.SetIntoVehicle(this.PLayerVehicle, VehicleSeat.Driver);
        this.SetupRivalCar(0, this.PLayerVehicle);
        this.VtoGetBlip = World.CreateBlip(this.RaceMarker);
        this.VtoGetBlip.Name = "Start Marker";
        this.VtoGetBlip.Sprite = BlipSprite.RaceFinish;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Start Marker";
        this.Race = 10;
        this.MissionId = 10;
        this.MissionSetup = true;
        this.StartedRace = false;
        this.TimeLeft = 50;
        Game.Player.Character.IsInvincible = true;
        this.checkpointReaced = 0;
        this.moneytobeawarded = 0.0f;
        this.IsInInterior = false;
        this.isInGarage = false;
        this.isinsecondVehicleBay = false;
      });
    }

    public void SetPedOutfit(Ped ped)
    {
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
    }

    public Ped CreatePed(Vector3 Loc)
    {
      Ped ped = World.CreatePed((GTA.Model) PedHash.FreemodeMale01, Loc);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      this.Peds.Add(ped);
      return ped;
    }

    private void SetupSpecialMissions()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SupplyRunsmenu, "Special Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race3 = new UIMenuItem("Rogue Contestant");
      uiMenu.AddItem(Race3);
      UIMenuItem Race4 = new UIMenuItem("The Rookie");
      uiMenu.AddItem(Race4);
      UIMenuItem Race5 = new UIMenuItem("The Oil Fued");
      uiMenu.AddItem(Race5);
      UIMenuItem Race6 = new UIMenuItem("The Air Tanker");
      uiMenu.AddItem(Race6);
      UIMenuItem Race7 = new UIMenuItem("The Beast");
      uiMenu.AddItem(Race7);
      UIMenuItem Race8 = new UIMenuItem("Traning Day");
      uiMenu.AddItem(Race8);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race8)
        {
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
              ped.Delete();
          }
          foreach (Vehicle vehicle in this.ExtraV)
          {
            if ((Entity) vehicle != (Entity) null)
              vehicle.Delete();
          }
          if (this.VtoGetBlip != (Blip) null)
            this.VtoGetBlip.Remove();
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if ((Entity) this.VtoGet1 != (Entity) null)
            this.VtoGet1.Delete();
          this.TriggerEscape = false;
          try
          {
            this.VtoGet = World.CreateVehicle(this.getVehicle2(), new Vector3(1891f, 2786f, 44f));
            this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, 33f);
            this.CreatePed(this.VtoGet.Position).Task.WarpIntoVehicle(this.VtoGet, VehicleSeat.Driver);
            this.VtoGet1 = World.CreateVehicle(this.getVehicle2(), new Vector3(1895f, 2789f, 44f));
            this.VtoGet1.Rotation = new Vector3(0.0f, 0.0f, 33f);
            this.CreatePed(this.VtoGet1.Position).Task.WarpIntoVehicle(this.VtoGet1, VehicleSeat.Driver);
            this.UpgradeVehicle3(this.VtoGet);
            this.SetupModifications(this.VtoGet);
            Script.Wait(1);
            this.UpgradeVehicle3(this.VtoGet1);
            this.SetupModifications(this.VtoGet1);
          }
          catch (Exception ex)
          {
            this.VtoGet = World.CreateVehicle((GTA.Model) VehicleHash.ZR3802, new Vector3(1895f, 2789f, 44f));
            this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, 33f);
            this.CreatePed(this.VtoGet.Position).Task.WarpIntoVehicle(this.VtoGet, VehicleSeat.Driver);
            this.VtoGet1 = World.CreateVehicle((GTA.Model) VehicleHash.Imperator2, new Vector3(1891f, 2786f, 44f));
            this.VtoGet1.Rotation = new Vector3(0.0f, 0.0f, 33f);
            this.CreatePed(this.VtoGet1.Position).Task.WarpIntoVehicle(this.VtoGet1, VehicleSeat.Driver);
            this.UpgradeVehicle3(this.VtoGet);
            this.SetupModifications(this.VtoGet);
            Script.Wait(1);
            this.UpgradeVehicle3(this.VtoGet1);
            this.SetupModifications(this.VtoGet1);
          }
          this.VtoGetBlip = World.CreateBlip(new Vector3(1882f, 2801f, 43f));
          this.VtoGetBlip.Name = "Destroy Both Racing vehicles";
          this.VtoGetBlip.Sprite = BlipSprite.RaceArenaWar;
          this.VtoGetBlip.Color = BlipColor.Pink;
          this.VtoGetBlip.Name = "Destroy Both Racing vehicles";
          this.VtoGetBlip.ShowRoute = true;
          this.VtoGet1.Alpha = (int) byte.MaxValue;
          this.VtoGet.Alpha = (int) byte.MaxValue;
          this.SpawnProp("stt_prop_race_gantry_01", new Vector3(1886f, 2804f, 43f), new Vector3(0.0f, 0.0f, -66f), 1);
          this.MissionId = 25;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " boss we have got some wanabies doing laps, out side LS, go destroy their vehicles and any other around them");
          foreach (Vector3 position in new List<Vector3>()
          {
            new Vector3(1841f, 2769.2f, 46f),
            new Vector3(1844f, 2751f, 46f),
            new Vector3(1830f, 2767f, 46f),
            new Vector3(1879f, 2831f, 46f),
            new Vector3(1897f, 2830f, 46f),
            new Vector3(1907f, 2812f, 46f),
            new Vector3(1959f, 2725f, 46f),
            new Vector3(1944f, 2739f, 46f),
            new Vector3(1727f, 2800f, 46f),
            new Vector3(1715f, 2793f, 46f),
            new Vector3(1692f, 2809f, 45f),
            new Vector3(1689f, 2822f, 45f)
          })
          {
            Script.Wait(1);
            Vehicle vehicle = World.CreateVehicle(this.getVehicle(), position, 0.0f);
            this.SetupRivalCar(0, vehicle);
            vehicle.EngineRunning = true;
            vehicle.HighBeamsOn = true;
            int num = new System.Random().Next(0, 360);
            vehicle.Rotation = new Vector3(0.0f, 0.0f, (float) num);
            this.ExtraV.Add(vehicle);
          }
        }
        if (item == Race7)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if ((Entity) this.VtoGet1 != (Entity) null)
            this.VtoGet1.Delete();
          if ((Entity) this.VtoGet2 != (Entity) null)
            this.VtoGet2.Delete();
          if ((Entity) this.VtoGet3 != (Entity) null)
            this.VtoGet3.Delete();
          if (this.VtoGetBlip != (Blip) null)
            this.VtoGetBlip.Remove();
          Vector3 position = this.Randomlocation();
          this.VtoGet = World.CreateVehicle(this.getVehicle2(), this.Randomlocation());
          this.VtoGet1 = World.CreateVehicle((GTA.Model) VehicleHash.TrailerSmall2, position);
          this.VtoGet1.AttachTo((Entity) this.VtoGet, 0);
          this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
          this.VtoGet1.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
          this.Peds.Add(this.VtoGet.GetPedOnSeat(VehicleSeat.Driver));
          this.Peds.Add(this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver));
          Ped pedOnSeat = this.VtoGet.GetPedOnSeat(VehicleSeat.Driver);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
          this.SetupRivalCar(0, this.VtoGet);
          this.VtoGet1.PrimaryColor = this.VtoGet.PrimaryColor;
          this.VtoGet1.SecondaryColor = this.VtoGet.SecondaryColor;
          this.VtoGet.SetMod(VehicleMod.Roof, 0, true);
          UI.Notify(this.GetHostName() + " boss we have got some sort of custom vehicle, running wild with the cops, go destroy it, be carefull its heavily armed");
          this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
          this.VtoGetBlip.Name = "Find Vehicle";
          this.VtoGetBlip.Sprite = BlipSprite.Tank;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Find Vehicle";
          this.MissionId = 18;
          this.MissionSetup = true;
          this.Piracymission = 1;
          this.VtoGet.Health = 1300;
          this.VtoGet.BodyHealth = 1300f;
          this.VtoGet1.Health = 1300;
          this.VtoGet1.BodyHealth = 1300f;
        }
        if (item == Race6)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if ((Entity) this.VtoGet3 != (Entity) null)
            this.VtoGet3.Delete();
          if ((Entity) this.VtoGet2 != (Entity) null)
            this.VtoGet2.Delete();
          if ((Entity) this.VtoGet6 != (Entity) null)
            this.VtoGet6.Delete();
          if ((Entity) this.VtoGet4 != (Entity) null)
            this.VtoGet4.Delete();
          if ((Entity) this.VtoGet5 != (Entity) null)
            this.VtoGet5.Delete();
          if (this.VtoGetBlip != (Blip) null)
            this.VtoGetBlip.Remove();
          if (this.VtoGetBlip2 != (Blip) null)
            this.VtoGetBlip2.Remove();
          if (this.VtoGetBlip1 != (Blip) null)
            this.VtoGetBlip1.Remove();
          this.EndPointPos = new Vector3(-382f, -1835f, 20f);
          Vector3 position1 = new Vector3(-2499f, 3155f, 33f);
          Vector3 position2 = new Vector3(2026f, 4748f, 41f);
          Vector3 position3 = new Vector3(1094f, 3044f, 40f);
          this.VtoGet = World.CreateVehicle((GTA.Model) VehicleHash.Skylift, position1);
          this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, -169f);
          this.VtoGet4 = World.CreateVehicle((GTA.Model) "Scarab", position1);
          this.UpgradeVehicle3(this.VtoGet4);
          this.VtoGet.IsInvincible = true;
          this.VtoGet4.IsInvincible = true;
          this.VtoGet3 = World.CreateVehicle((GTA.Model) VehicleHash.Skylift, position2);
          this.VtoGet3.Rotation = new Vector3(0.0f, 0.0f, 172f);
          this.VtoGet5 = World.CreateVehicle((GTA.Model) "Scarab", position2);
          this.VtoGet3.IsInvincible = true;
          this.VtoGet5.IsInvincible = true;
          this.UpgradeVehicle3(this.VtoGet5);
          this.VtoGet2 = World.CreateVehicle((GTA.Model) VehicleHash.Skylift, position3);
          this.VtoGet2.Rotation = new Vector3(0.0f, 0.0f, 172f);
          this.VtoGet6 = World.CreateVehicle((GTA.Model) "Scarab", position3);
          this.VtoGet2.IsInvincible = true;
          this.VtoGet6.IsInvincible = true;
          this.UpgradeVehicle3(this.VtoGet6);
          this.SetupRivalCar(0, this.VtoGet4);
          this.SetupRivalCar(0, this.VtoGet5);
          this.SetupRivalCar(0, this.VtoGet6);
          Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.VtoGet4, (InputArgument) this.VtoGet, (InputArgument) 0, (InputArgument) 0.0, (InputArgument) -3.0, (InputArgument) -1.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) true, (InputArgument) true, (InputArgument) true, (InputArgument) true, (InputArgument) 1, (InputArgument) true);
          Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.VtoGet5, (InputArgument) this.VtoGet3, (InputArgument) 0, (InputArgument) 0.0, (InputArgument) -3.0, (InputArgument) -1.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) true, (InputArgument) true, (InputArgument) true, (InputArgument) true, (InputArgument) 1, (InputArgument) true);
          Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.VtoGet6, (InputArgument) this.VtoGet2, (InputArgument) 0, (InputArgument) 0.0, (InputArgument) -3.0, (InputArgument) -1.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) true, (InputArgument) true, (InputArgument) true, (InputArgument) true, (InputArgument) 1, (InputArgument) true);
          this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
          this.VtoGet2.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
          this.VtoGet3.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
          this.DropedVehicleA = false;
          this.DropedVehicleB = false;
          this.DropedVehicleC = false;
          Ped randomPed = World.CreateRandomPed(this.EndPointPos);
          randomPed.IsInvincible = true;
          randomPed.IsVisible = false;
          randomPed.FreezePosition = true;
          this.Peds.Add(randomPed);
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(randomPed);
          this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(randomPed);
          this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(randomPed);
          this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
          this.VtoGetBlip.Sprite = BlipSprite.HelicopterAnimated;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Destroy Skylift A";
          this.VtoGetBlip3 = World.CreateBlip(this.VtoGet3.Position);
          this.VtoGetBlip3.Sprite = BlipSprite.HelicopterAnimated;
          this.VtoGetBlip3.Color = BlipColor.White;
          this.VtoGetBlip3.Name = "Destroy Skylift B";
          this.VtoGetBlip2 = World.CreateBlip(this.VtoGet2.Position);
          this.VtoGetBlip2.Sprite = BlipSprite.HelicopterAnimated;
          this.VtoGetBlip2.Color = BlipColor.White;
          this.VtoGetBlip2.Name = "Destroy Skylift C";
          this.EndPointBlip = World.CreateBlip(new Vector3(-382f, -1835f, 20f));
          this.EndPointBlip.Sprite = BlipSprite.Castle;
          this.EndPointBlip.Name = "Delivery Point";
          this.MissionId = 11;
          this.Race = 1;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " Boss I've spotted 3 vehicles on route to Stadium, Destroy All Three, Before they reach their destination for a reward, there carring some sort of luxury tank");
          UI.Notify(this.GetHostName() + " id on the vehicle says its a Skylift Helicopter, Carryng a Scarab");
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race5)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if ((Entity) this.VtoGet3 != (Entity) null)
            this.VtoGet3.Delete();
          if ((Entity) this.VtoGet2 != (Entity) null)
            this.VtoGet2.Delete();
          if (this.VtoGetBlip != (Blip) null)
            this.VtoGetBlip.Remove();
          if (this.VtoGetBlip2 != (Blip) null)
            this.VtoGetBlip2.Remove();
          if (this.VtoGetBlip1 != (Blip) null)
            this.VtoGetBlip1.Remove();
          this.EndPointPos = new Vector3(-382f, -1835f, 20f);
          Vector3 position1 = new Vector3(-2173f, -346f, 12f);
          Vector3 position2 = new Vector3(-217f, 260f, 91f);
          Vector3 position3 = new Vector3(1201f, -379f, 58f);
          this.VtoGet = World.CreateVehicle((GTA.Model) "Cerberus", position1);
          this.VtoGet3 = World.CreateVehicle((GTA.Model) "Cerberus", position2);
          this.VtoGet2 = World.CreateVehicle((GTA.Model) "Cerberus", position3);
          this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
          this.VtoGet2.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
          this.VtoGet3.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
          Ped pedOnSeat1 = this.VtoGet.GetPedOnSeat(VehicleSeat.Driver);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
          Ped pedOnSeat2 = this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat2, (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat2, (InputArgument) 1);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
          Ped pedOnSeat3 = this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver);
          Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat3, (InputArgument) true);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
          Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat3, (InputArgument) 1);
          Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VtoGet, this.EndPointPos, 20f, 120f, 1);
          this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VtoGet3, this.EndPointPos, 20f, 120f, 1);
          this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VtoGet2, this.EndPointPos, 20f, 120f, 1);
          this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
          this.VtoGetBlip.Sprite = BlipSprite.GunCar;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Vehicle A";
          this.VtoGetBlip3 = World.CreateBlip(this.VtoGet3.Position);
          this.VtoGetBlip3.Sprite = BlipSprite.GunCar;
          this.VtoGetBlip3.Color = BlipColor.White;
          this.VtoGetBlip3.Name = "Vehicle B";
          this.VtoGetBlip2 = World.CreateBlip(this.VtoGet2.Position);
          this.VtoGetBlip2.Sprite = BlipSprite.GunCar;
          this.VtoGetBlip2.Color = BlipColor.White;
          this.VtoGetBlip2.Name = "Vehicle A";
          this.EndPointBlip = World.CreateBlip(this.EndPointPos);
          this.EndPointBlip.Sprite = BlipSprite.Castle;
          this.EndPointBlip.Name = "Delivery Point";
          this.MissionId = 7;
          this.Race = 1;
          this.MissionSetup = true;
          UI.Notify(this.GetHostName() + " Boss I've spotted 3 vehicles on route to Stadium, Destroy All Three, Before they reach their destination for a reward, there carring vital oil supplies for our rivals");
          UI.Notify(this.GetHostName() + " id on the vehicle says its a Cerberus Oil Tanker");
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item == Race4)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if ((Entity) this.VtoGet1 != (Entity) null)
            this.VtoGet1.Delete();
          if ((Entity) this.VtoGet2 != (Entity) null)
            this.VtoGet2.Delete();
          if (this.VtoGetBlip != (Blip) null)
            this.VtoGetBlip.Remove();
          foreach (Ped ped in this.Peds)
          {
            if ((Entity) ped != (Entity) null)
              ped.Delete();
          }
          this.VtoGet = World.CreateVehicle((GTA.Model) VehicleHash.Glendale, new Vector3(-2037f, -466f, 11f), 11f);
          this.VtoGet1 = World.CreateVehicle((GTA.Model) VehicleHash.Dominator, new Vector3(-2033f, -457f, 10f), 93f);
          this.VtoGet2 = World.CreateVehicle((GTA.Model) VehicleHash.SlamVan, new Vector3(-2044f, -459f, 11f), 58f);
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2042f, -464f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2033f, -454f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2034f, -462f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2024f, -463f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2034f, -447f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2044f, -445f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2053f, -453f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2035f, -460f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2021f, -455f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2027f, -448f, 11f)));
          this.Peds.Add(World.CreateRandomPed(new Vector3(-2013f, -460f, 11f)));
          this.VtoGetBlip = World.CreateBlip(new Vector3(-2040f, -456f, 11f));
          this.SetupRivalCar(0, this.VtoGet);
          this.VtoGetBlip.Name = "Destroy vehicles";
          this.VtoGetBlip.Sprite = BlipSprite.Bomb;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Destroy  Vehicle";
          this.SetupPed = false;
          this.PedsCounted = 0;
          this.MissionId = 6;
          this.Race = 1;
          this.MissionSetup = true;
          this.IsInInterior = false;
          this.isInGarage = false;
          this.isinsecondVehicleBay = false;
        }
        if (item != Race3)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        if (this.VtoGetBlip != (Blip) null)
          this.VtoGetBlip.Remove();
        Vector3 position4 = this.Randomlocation();
        this.RandomVehicleFun();
        this.VtoGet = World.CreateVehicle(this.getVehicle(), position4, 45f);
        UI.Notify(this.GetHostName() + " boss we have got some lunatic playing with the cops!, go teach him a lesson, damage his vehicle, but dont destroy it!");
        this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        this.VtoGet.CreatePedOnSeat(VehicleSeat.Passenger, this.RequestModel(PedHash.FreemodeMale01));
        this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
        this.VtoGetBlip = World.CreateBlip(position4);
        this.SetupRivalCar(0, this.VtoGet);
        this.VtoGetBlip.Name = "Find Vehicle";
        this.VtoGetBlip.Sprite = BlipSprite.GunCar;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Find Vehicle";
        this.MissionId = 8;
        this.MissionSetup = true;
        this.Piracymission = 1;
        this.VtoGet.Health = 12000;
        this.VtoGet.BodyHealth = 12000f;
        this.vehiclehealth = (float) this.VtoGet.Health;
      });
    }

    public void AddCar(string Slot)
    {
      string str = Slot;
      if (str.Equals("Slot1"))
      {
        Vector3 vehicle1Loc = this.Vehicle1Loc;
        float heading = -90f;
        if ((Entity) this.Vehicle1 != (Entity) null)
          this.Vehicle1.Delete();
        this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot1.ini");
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot1.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot1.ini");
          this.Vehicle1 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot1.ini"), vehicle1Loc, heading);
          this.SC.Load(this.Vehicle1);
          this.Vehicle1.IsDriveable = false;
        }
      }
      if (str.Equals("Slot2"))
      {
        Vector3 vehicle2Loc = this.Vehicle2Loc;
        float heading = -90f;
        if ((Entity) this.Vehicle2 != (Entity) null)
          this.Vehicle2.Delete();
        this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot2.ini");
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot2.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot2.ini");
          this.Vehicle2 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot2.ini"), vehicle2Loc, heading);
          this.SC.Load(this.Vehicle2);
          this.Vehicle2.IsDriveable = false;
        }
      }
      if (str.Equals("Slot3"))
      {
        Vector3 vehicle3Loc = this.Vehicle3Loc;
        float heading = -90f;
        if ((Entity) this.Vehicle3 != (Entity) null)
          this.Vehicle3.Delete();
        this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot3.ini");
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot3.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot3.ini");
          this.Vehicle3 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot3.ini"), vehicle3Loc, heading);
          this.SC.Load(this.Vehicle3);
          this.Vehicle3.IsDriveable = false;
        }
      }
      if (str.Equals("Slot4"))
      {
        Vector3 vehicle4Loc = this.Vehicle4Loc;
        float heading = -90f;
        if ((Entity) this.Vehicle4 != (Entity) null)
          this.Vehicle4.Delete();
        this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot4.ini");
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot4.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot4.ini");
          this.Vehicle4 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot4.ini"), vehicle4Loc, heading);
          this.SC.Load(this.Vehicle4);
          this.Vehicle4.IsDriveable = false;
        }
      }
      if (str.Equals("Slot5"))
      {
        Vector3 vehicle5Loc = this.Vehicle5Loc;
        float heading = 90f;
        if ((Entity) this.Vehicle5 != (Entity) null)
          this.Vehicle5.Delete();
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot5.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot5.ini");
          this.Vehicle5 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot5.ini"), vehicle5Loc, heading);
          this.SC.Load(this.Vehicle5);
          this.Vehicle5.IsDriveable = false;
        }
      }
      if (str.Equals("Slot6"))
      {
        Vector3 vehicle6Loc = this.Vehicle6Loc;
        float heading = 90f;
        if ((Entity) this.Vehicle6 != (Entity) null)
          this.Vehicle6.Delete();
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot6.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot6.ini");
          this.Vehicle6 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot6.ini"), vehicle6Loc, heading);
          this.SC.Load(this.Vehicle6);
          this.Vehicle6.IsDriveable = false;
        }
      }
      if (str.Equals("Slot7"))
      {
        Vector3 vehicle7Loc = this.Vehicle7Loc;
        float heading = 90f;
        if ((Entity) this.Vehicle7 != (Entity) null)
          this.Vehicle7.Delete();
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot7.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot7.ini");
          this.Vehicle7 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot7.ini"), vehicle7Loc, heading);
          this.SC.Load(this.Vehicle7);
          this.Vehicle7.IsDriveable = false;
        }
      }
      if (str.Equals("Slot8"))
      {
        Vector3 vehicle8Loc = this.Vehicle8Loc;
        float heading = 90f;
        if ((Entity) this.Vehicle8 != (Entity) null)
          this.Vehicle8.Delete();
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot8.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot8.ini");
          this.Vehicle8 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot8.ini"), vehicle8Loc, heading);
          this.SC.Load(this.Vehicle8);
          this.Vehicle8.IsDriveable = false;
        }
      }
      if (str.Equals("Slot9"))
      {
        Vector3 vehicle9Loc = this.Vehicle9Loc;
        float heading = 90f;
        if ((Entity) this.Vehicle9 != (Entity) null)
          this.Vehicle9.Delete();
        GTA.Model model = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot9.ini");
        if (model != (GTA.Model) "null" && model != (GTA.Model) (string) null && model != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot9.ini");
          this.Vehicle9 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot9.ini"), vehicle9Loc, heading);
          this.SC.Load(this.Vehicle9);
          this.Vehicle9.IsDriveable = false;
        }
      }
      if (!str.Equals("Slot10"))
        return;
      Vector3 vehicle10Loc = this.Vehicle10Loc;
      float heading1 = -90f;
      if ((Entity) this.Vehicle10 != (Entity) null)
        this.Vehicle10.Delete();
      GTA.Model model1 = this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot10.ini");
      if (model1 != (GTA.Model) "null" && model1 != (GTA.Model) (string) null && model1 != (GTA.Model) (string) null)
      {
        this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot10.ini");
        this.Vehicle10 = World.CreateVehicle(this.SC.CheckCar("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\Slot10.ini"), vehicle10Loc, heading1);
        this.SC.Load(this.Vehicle10);
        this.Vehicle10.IsDriveable = false;
      }
    }

    public void RemoveCar()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Remove Vehicle");
      this.GUIMenus.Add(uiMenu1);
      UIMenuItem Slot1A = new UIMenuItem("Slot 1");
      uiMenu1.AddItem(Slot1A);
      UIMenuItem Slot2A = new UIMenuItem("Slot 2");
      uiMenu1.AddItem(Slot2A);
      UIMenuItem Slot3A = new UIMenuItem("Slot 3");
      uiMenu1.AddItem(Slot3A);
      UIMenuItem Slot4A = new UIMenuItem("Slot 4");
      uiMenu1.AddItem(Slot4A);
      UIMenuItem Slot5A = new UIMenuItem("Slot 5");
      uiMenu1.AddItem(Slot5A);
      UIMenuItem Slot6A = new UIMenuItem("Slot 6");
      uiMenu1.AddItem(Slot6A);
      UIMenuItem Slot7A = new UIMenuItem("Slot 7");
      uiMenu1.AddItem(Slot7A);
      UIMenuItem Slot8A = new UIMenuItem("Slot 8");
      uiMenu1.AddItem(Slot8A);
      UIMenuItem Slot9A = new UIMenuItem("Slot 9");
      uiMenu1.AddItem(Slot9A);
      UIMenuItem Slot10A = new UIMenuItem("Slot 10");
      uiMenu1.AddItem(Slot10A);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
        if (item != Slot10A || !((Entity) this.Vehicle10 != (Entity) null))
          return;
        this.DeleteCarinSlot("Slot10", this.Vehicle10);
      });
      List<object> LogList = new List<object>();
      string[] logFile = File.ReadAllLines(this.ListPath);
      foreach (string str in logFile)
        LogList.Add((object) str);
      List<object> STlist = new List<object>();
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      List<object> objectList = new List<object>()
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
      List<object> Slots = new List<object>();
      for (int index = 1; index <= 10; ++index)
        Slots.Add((object) ("Slot" + index.ToString()));
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Add Car To Slot");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem uiMenuItem1 = new UIMenuItem("------------------Reset List-----------------------------");
      uiMenu2.AddItem(uiMenuItem1);
      UIMenuItem uiMenuItem2 = new UIMenuItem("Reset Vehicle List");
      uiMenu2.AddItem(uiMenuItem2);
      UIMenuItem uiMenuItem3 = new UIMenuItem("------------------Search Method 1--------------------------");
      uiMenu2.AddItem(uiMenuItem3);
      UIMenuListItem Ve = new UIMenuListItem("Vehicle : ", LogList, 0);
      uiMenu2.AddItem((UIMenuItem) Ve);
      UIMenuItem VDName = new UIMenuItem("Vehicle Spawn Name  : Dukes2");
      uiMenu2.AddItem(VDName);
      UIMenuItem VName = new UIMenuItem("Vehicle Full Name  : Imponte Dukes");
      uiMenu2.AddItem(VName);
      UIMenuItem PuchaseV = new UIMenuItem("Purchase Vehicle : $0");
      uiMenu2.AddItem(PuchaseV);
      UIMenuItem uiMenuItem4 = new UIMenuItem("------------------Search Method 2--------------------------");
      uiMenu2.AddItem(uiMenuItem4);
      UIMenuItem Search = new UIMenuItem("Enter Vehicle Name");
      uiMenu2.AddItem(Search);
      UIMenuListItem Ve2 = new UIMenuListItem("Vehicle : ", STlist, 0);
      uiMenu2.AddItem((UIMenuItem) Ve2);
      UIMenuItem uiMenuItem5 = new UIMenuItem("Search Term  : NULL");
      uiMenu2.AddItem(uiMenuItem5);
      UIMenuItem VDName2 = new UIMenuItem("Vehicle Spawn Name  : NULL");
      uiMenu2.AddItem(VDName2);
      UIMenuItem VName2 = new UIMenuItem("Vehicle Full Name  : NULL");
      uiMenu2.AddItem(VName2);
      UIMenuItem PuchaseV2 = new UIMenuItem("Purchase Vehicle : NULL");
      uiMenu2.AddItem(PuchaseV2);
      UIMenuItem uiMenuItem6 = new UIMenuItem("-------------------Slot Selection-------------------------");
      uiMenu2.AddItem(uiMenuItem6);
      UIMenuListItem ListSlot = new UIMenuListItem("Slot: ", Slots, 0);
      uiMenu2.AddItem((UIMenuItem) ListSlot);
      uiMenu2.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == ListSlot)
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__642.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__642.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string str = Class1.\u003C\u003Eo__642.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__642.\u003C\u003Ep__0, Slots[ListSlot.Index]);
          if (str.Equals("Slot1"))
            this.Current = this.Vehicle1;
          if (str.Equals("Slot2"))
            this.Current = this.Vehicle2;
          if (str.Equals("Slot3"))
            this.Current = this.Vehicle3;
          if (str.Equals("Slot4"))
            this.Current = this.Vehicle4;
          if (str.Equals("Slot5"))
            this.Current = this.Vehicle5;
          if (str.Equals("Slot6"))
            this.Current = this.Vehicle6;
          if (str.Equals("Slot7"))
            this.Current = this.Vehicle7;
          if (str.Equals("Slot8"))
            this.Current = this.Vehicle8;
          if (str.Equals("Slot9"))
            this.Current = this.Vehicle9;
          if (str.Equals("Slot10"))
            this.Current = this.Vehicle10;
        }
        if (item == Ve)
        {
          try
          {
            string[] separator = new string[2]{ " = ", "," };
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__642.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__642.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            string[] strArray = Class1.\u003C\u003Eo__642.\u003C\u003Ep__1.Target((CallSite) Class1.\u003C\u003Eo__642.\u003C\u003Ep__1, LogList[Ve.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
          if (Class1.\u003C\u003Eo__642.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__642.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string[] strArray = Class1.\u003C\u003Eo__642.\u003C\u003Ep__2.Target((CallSite) Class1.\u003C\u003Eo__642.\u003C\u003Ep__2, STlist[Ve2.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Search)
        {
          try
          {
            if (LogList.Count > 0)
              LogList.Clear();
            SearchTerm = Game.GetUserInput(32);
            SearchTerm = SearchTerm.ToUpper();
            UI.Notify("Search Term : " + SearchTerm);
            bool flag = false;
            foreach (string str in logFile)
            {
              if (str.ToUpper().Contains(SearchTerm))
              {
                UI.Notify("Found Match");
                LogList.Add((object) str);
                flag = true;
                string[] separator = new string[2]
                {
                  " = ",
                  ","
                };
                // ISSUE: reference to a compiler-generated field
                if (Class1.\u003C\u003Eo__642.\u003C\u003Ep__3 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  Class1.\u003C\u003Eo__642.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                string[] strArray = Class1.\u003C\u003Eo__642.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__642.\u003C\u003Ep__3, LogList[Ve.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
            }
            if (!flag)
            {
              UI.Notify("Found No Match");
              logFile = File.ReadAllLines(this.ListPath);
              foreach (object obj in logFile)
                LogList.Add(obj);
              string[] separator = new string[2]
              {
                " = ",
                ","
              };
              // ISSUE: reference to a compiler-generated field
              if (Class1.\u003C\u003Eo__642.\u003C\u003Ep__4 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Class1.\u003C\u003Eo__642.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              string[] strArray = Class1.\u003C\u003Eo__642.\u003C\u003Ep__4.Target((CallSite) Class1.\u003C\u003Eo__642.\u003C\u003Ep__4, LogList[Ve.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
              // ISSUE: reference to a compiler-generated field
              if (Class1.\u003C\u003Eo__642.\u003C\u003Ep__5 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Class1.\u003C\u003Eo__642.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              string Slot = Class1.\u003C\u003Eo__642.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__642.\u003C\u003Ep__5, Slots[ListSlot.Index]);
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\" + Slot + ".ini");
              UI.Notify("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\" + Slot + ".ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\" + Slot + ".ini");
              try
              {
                Vehicle vehicle = World.CreateVehicle(this.RequestModel(this.man), new Vector3(), 0.0f);
                this.SC.SaveName(vehicle.DisplayName);
                vehicle.Delete();
                UI.Notify("~b~SR :~w~ Bought New Car, reloading Garage");
                this.AddCar(Slot);
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
            UI.Notify(" you do not have enought money to purchase this vehicle!");
        }
        if (item != PuchaseV)
          return;
        if ((double) Game.Player.Money > (double) this.M)
        {
          try
          {
            Game.Player.Money -= (int) this.M;
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__642.\u003C\u003Ep__6 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__642.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            string Slot = Class1.\u003C\u003Eo__642.\u003C\u003Ep__6.Target((CallSite) Class1.\u003C\u003Eo__642.\u003C\u003Ep__6, Slots[ListSlot.Index]);
            this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\" + Slot + ".ini");
            UI.Notify("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\" + Slot + ".ini");
            Vector3 position = Game.Player.Character.Position;
            this.SC.Save();
            try
            {
              this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\" + Slot + ".ini");
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(this.man), new Vector3(), 0.0f);
              this.SC.SaveName(vehicle.DisplayName);
              vehicle.Delete();
              UI.Notify("~b~SR :~w~ Bought New Car, relaoding Garage");
              this.AddCar(Slot);
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
          UI.Notify("you do not have enought money to purchase this vehicle!");
      });
    }

    public void DeleteCarinSlot(string Slot, Vehicle V)
    {
      this.SC.LoadIniFile(this.path + this.GarageNum + "//" + Slot + ".ini");
      UI.Notify(this.path + this.GarageNum + "//" + Slot + ".ini");
      this.SC.SaveName();
      V.Delete();
    }

    public void LoadGarageVehicles()
    {
      this.DeleteVehicles();
      this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
      if (this.CurrentZR380 == 1 && this.ApocalypseZR380Bought == 1)
      {
        this.SC.LoadIniFile(this.Loadpath + "ZR380//1Apocalypse.ini");
        this.ZR380 = World.CreateVehicle((GTA.Model) "ZR380", this.ZR380Spawn, 90f);
        this.SC.Load(this.ZR380);
      }
      if (this.CurrentZR380 == 2 && this.NightmareZR380Bought == 1)
      {
        this.SC.LoadIniFile(this.Loadpath + "ZR380//2NIghtmare.ini");
        this.ZR380 = World.CreateVehicle((GTA.Model) "ZR3802", this.ZR380Spawn, 90f);
        this.SC.Load(this.ZR380);
      }
      if (this.CurrentZR380 == 3 && this.FutureShockZR380Bought == 1)
      {
        this.SC.LoadIniFile(this.Loadpath + "ZR380//3FutureShock.ini");
        this.ZR380 = World.CreateVehicle((GTA.Model) "ZR3803", this.ZR380Spawn, 90f);
        this.SC.Load(this.ZR380);
      }
      if (this.CurrentBruiser == 1 && this.ApocalypseBruiserBought == 1)
      {
        this.SC.LoadIniFile(this.Loadpath + "Bruiser//1Apocalypse.ini");
        this.Bruiser = World.CreateVehicle((GTA.Model) "Bruiser", this.BruiserSpawn, -90f);
        this.SC.Load(this.Bruiser);
      }
      if (this.CurrentBruiser == 2 && this.NightmareBruiserBought == 1)
      {
        this.SC.LoadIniFile(this.Loadpath + "Bruiser//2NIghtmare.ini");
        this.Bruiser = World.CreateVehicle((GTA.Model) "Bruiser2", this.BruiserSpawn, -90f);
        this.SC.Load(this.Bruiser);
      }
      if (this.CurrentBruiser != 3 || this.FutureShockBruiserBought != 1)
        return;
      this.SC.LoadIniFile(this.Loadpath + "Bruiser//3FutureShock.ini");
      this.Bruiser = World.CreateVehicle((GTA.Model) "Bruiser3", this.BruiserSpawn, -90f);
      this.SC.Load(this.Bruiser);
    }

    public void SaveLocalcarinGarageA(string G, Vehicle V, string Slot)
    {
      if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        if (Game.Player.Character.CurrentVehicle.DisplayName != "RHINO" || Game.Player.Character.CurrentVehicle.DisplayName != "KHANJALI" || Game.Player.Character.CurrentVehicle.DisplayName != "CHERNOBOG")
        {
          this.DeleteVehicles();
          this.DestoryCars();
          if ((Entity) this.SaveVehicle != (Entity) null)
            this.SaveVehicle = (Vehicle) null;
          string Garage = G;
          this.GarageNum = G;
          UI.Notify(this.path + Garage + "//" + Slot + ".ini");
          this.SC.LoadIniFile(this.path + Garage + "//" + Slot + ".ini");
          this.SC.VehicleName = "null";
          Script.Wait(50);
          this.SC.SaveWithoutDelete();
          Script.Wait(50);
          V = Game.Player.Character.CurrentVehicle;
          Script.Wait(50);
          UI.Notify(this.GetHostName() + " your " + V.FriendlyName + ", has been Saved into  " + G + ", " + Slot);
          Script.Wait(50);
          this.SC.Save();
          this.DestoryCars();
          Script.Wait(50);
          this.CreateCars(Garage);
          Script.Wait(50);
          Game.Player.Character.Position = this.ExitMarker3;
          Script.Wait(100);
          this.isInGarage = true;
          this.Getcolor = false;
        }
        else
          this.DisplayHelpTextThisFrame("You cannot save this vehicle");
      }
      else
        this.DisplayHelpTextThisFrame("Bring a vehicle to save");
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
      if (!((Entity) this.Vehicle10 != (Entity) null))
        return;
      this.Vehicle10.Delete();
    }

    public void CreateCars(string Garage)
    {
      try
      {
        Garage = "GarageA";
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
        if (model1 != (GTA.Model) "null" && model1 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot1.ini");
          this.Vehicle1 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot1.ini"), this.Vehicle1Loc, -90f);
          this.SC.Load(this.Vehicle1);
          this.Vehicle1.IsDriveable = false;
        }
        Script.Wait(50);
        if (model2 != (GTA.Model) "null" && model2 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot2.ini");
          this.Vehicle2 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot2.ini"), this.Vehicle2Loc, -90f);
          this.SC.Load(this.Vehicle2);
          this.Vehicle2.IsDriveable = false;
        }
        Script.Wait(50);
        if (model3 != (GTA.Model) "null" && model3 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot3.ini");
          this.Vehicle3 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot3.ini"), this.Vehicle3Loc, -90f);
          this.SC.Load(this.Vehicle3);
          this.Vehicle3.IsDriveable = false;
        }
        Script.Wait(50);
        if (model4 != (GTA.Model) "null" && model4 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot4.ini");
          this.Vehicle4 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot4.ini"), this.Vehicle4Loc, -90f);
          this.SC.Load(this.Vehicle4);
          this.Vehicle4.IsDriveable = false;
        }
        Script.Wait(50);
        if (model5 != (GTA.Model) "null" && model5 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot5.ini");
          this.Vehicle5 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot5.ini"), this.Vehicle5Loc, 90f);
          this.SC.Load(this.Vehicle5);
          this.Vehicle5.IsDriveable = false;
        }
        Script.Wait(50);
        if (model6 != (GTA.Model) "null" && model6 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot6.ini");
          this.Vehicle6 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot6.ini"), this.Vehicle6Loc, 90f);
          this.SC.Load(this.Vehicle6);
          this.Vehicle6.IsDriveable = false;
        }
        Script.Wait(50);
        if (model7 != (GTA.Model) "null" && model7 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot7.ini");
          this.Vehicle7 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot7.ini"), this.Vehicle7Loc, 100f);
          this.SC.Load(this.Vehicle7);
          this.Vehicle7.IsDriveable = false;
        }
        Script.Wait(50);
        if (model8 != (GTA.Model) "null" && model8 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot8.ini");
          this.Vehicle8 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot8.ini"), this.Vehicle8Loc, 90f);
          this.SC.Load(this.Vehicle8);
          this.Vehicle8.IsDriveable = false;
        }
        Script.Wait(50);
        if (model9 != (GTA.Model) "null" && model9 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot9.ini");
          this.Vehicle9 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot9.ini"), this.Vehicle9Loc, 90f);
          this.SC.Load(this.Vehicle9);
          this.Vehicle9.IsDriveable = false;
        }
        Script.Wait(50);
        if (model10 != (GTA.Model) "null" && model10 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot10.ini");
          this.Vehicle10 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot10.ini"), this.Vehicle10Loc, -90f);
          this.SC.Load(this.Vehicle10);
          this.Vehicle10.IsDriveable = false;
        }
        this.GarageNum = Garage;
      }
      catch (NullReferenceException ex)
      {
        UI.Notify("~r~ Arena War Player Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
      }
    }

    private void SetupGarage()
    {
      UIMenu uiMenu = this.PlayerGaragemodMenuPool.AddSubMenu(this.PlayerGaragemainMenu, "Enter Garage A");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Slot1A = new UIMenuItem("Slot 1A");
      uiMenu.AddItem(Slot1A);
      UIMenuItem Slot2A = new UIMenuItem("Slot 2A");
      uiMenu.AddItem(Slot2A);
      UIMenuItem Slot3A = new UIMenuItem("Slot 3A");
      uiMenu.AddItem(Slot3A);
      UIMenuItem Slot4A = new UIMenuItem("Slot 4A");
      uiMenu.AddItem(Slot4A);
      UIMenuItem Slot5A = new UIMenuItem("Slot 5A");
      uiMenu.AddItem(Slot5A);
      UIMenuItem Slot6A = new UIMenuItem("Slot 6A");
      uiMenu.AddItem(Slot6A);
      UIMenuItem Slot7A = new UIMenuItem("Slot 7A");
      uiMenu.AddItem(Slot7A);
      UIMenuItem Slot8A = new UIMenuItem("Slot 8A");
      uiMenu.AddItem(Slot8A);
      UIMenuItem Slot9A = new UIMenuItem("Slot 9A");
      uiMenu.AddItem(Slot9A);
      UIMenuItem Slot10A = new UIMenuItem("Slot 10A");
      uiMenu.AddItem(Slot10A);
      UIMenuItem uiMenuItem1 = new UIMenuItem("Slot 11A");
      uiMenu.AddItem(uiMenuItem1);
      UIMenuItem uiMenuItem2 = new UIMenuItem("Slot 12A");
      uiMenu.AddItem(uiMenuItem2);
      UIMenuItem uiMenuItem3 = new UIMenuItem("Slot 13A");
      uiMenu.AddItem(uiMenuItem3);
      UIMenuItem uiMenuItem4 = new UIMenuItem("Slot 14A");
      uiMenu.AddItem(uiMenuItem4);
      UIMenuItem uiMenuItem5 = new UIMenuItem("Slot 15A");
      uiMenu.AddItem(uiMenuItem5);
      UIMenuItem uiMenuItem6 = new UIMenuItem("Slot 16A");
      uiMenu.AddItem(uiMenuItem6);
      UIMenuItem uiMenuItem7 = new UIMenuItem("Slot 17A");
      uiMenu.AddItem(uiMenuItem7);
      UIMenuItem uiMenuItem8 = new UIMenuItem("Slot 18A");
      uiMenu.AddItem(uiMenuItem8);
      UIMenuItem uiMenuItem9 = new UIMenuItem("Slot 19A");
      uiMenu.AddItem(uiMenuItem9);
      UIMenuItem uiMenuItem10 = new UIMenuItem("Slot 20A");
      uiMenu.AddItem(uiMenuItem10);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Slot1A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle1, "Slot1");
        if (item == Slot2A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle2, "Slot2");
        if (item == Slot3A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle3, "Slot3");
        if (item == Slot4A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle4, "Slot4");
        if (item == Slot5A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle5, "Slot5");
        if (item == Slot6A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle6, "Slot6");
        if (item == Slot7A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle7, "Slot7");
        if (item == Slot8A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle8, "Slot8");
        if (item == Slot9A)
          this.SaveLocalcarinGarageA("GarageA", this.Vehicle9, "Slot9");
        if (item != Slot10A)
          return;
        this.SaveLocalcarinGarageA("GarageA", this.Vehicle10, "Slot10");
      });
    }

    public void DeleteVehicles()
    {
      if ((Entity) this.RcBandito != (Entity) null)
        this.RcBandito.Delete();
      if ((Entity) this.Italigto != (Entity) null)
        this.Italigto.Delete();
      if ((Entity) this.Deveste != (Entity) null)
        this.Deveste.Delete();
      if ((Entity) this.Deviant != (Entity) null)
        this.Deviant.Delete();
      if ((Entity) this.Toros != (Entity) null)
        this.Toros.Delete();
      if ((Entity) this.Schlagen != (Entity) null)
        this.Schlagen.Delete();
      if ((Entity) this.Vamos != (Entity) null)
        this.Vamos.Delete();
      if ((Entity) this.Tulip != (Entity) null)
        this.Tulip.Delete();
      if ((Entity) this.Clique != (Entity) null)
        this.Clique.Delete();
      if ((Entity) this.ZR380 != (Entity) null)
        this.ZR380.Delete();
      if ((Entity) this.Bruiser != (Entity) null)
        this.Bruiser.Delete();
      if ((Entity) this.Cerberus != (Entity) null)
        this.Cerberus.Delete();
      if ((Entity) this.Scarab != (Entity) null)
        this.Scarab.Delete();
      if ((Entity) this.Dominator != (Entity) null)
        this.Dominator.Delete();
      if ((Entity) this.Imperator != (Entity) null)
        this.Imperator.Delete();
      if ((Entity) this.Deathbike != (Entity) null)
        this.Deathbike.Delete();
      if ((Entity) this.Issi != (Entity) null)
        this.Issi.Delete();
      if ((Entity) this.Monster != (Entity) null)
        this.Monster.Delete();
      if ((Entity) this.Bruitus != (Entity) null)
        this.Bruitus.Delete();
      if ((Entity) this.Impaler != (Entity) null)
        this.Impaler.Delete();
      if ((Entity) this.Slamvan != (Entity) null)
        this.Slamvan.Delete();
      if (!((Entity) this.ZR380 != (Entity) null))
        return;
      this.ZR380.Delete();
    }

    public void SetUpVehicles2()
    {
      UIMenu menu1 = this.GarageMenuPool2.AddSubMenu(this.VehicleMenu2, "ZR380");
      this.GUIMenus.Add(menu1);
      UIMenu menu2 = this.GarageMenuPool2.AddSubMenu(this.VehicleMenu2, "Bruiser");
      this.GUIMenus.Add(menu2);
      UIMenu menu3 = this.GarageMenuPool2.AddSubMenu(this.VehicleMenu2, "Secondary Vehicles");
      this.GUIMenus.Add(menu3);
      UIMenu uiMenu1 = this.GarageMenuPool.AddSubMenu(menu1, "Buy");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.GarageMenuPool.AddSubMenu(menu1, "Use");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem ApocalypseZR380Use = new UIMenuItem("Apocalypse ZR380");
      uiMenu2.AddItem(ApocalypseZR380Use);
      UIMenuItem NightmareZR380Use = new UIMenuItem("Nightmare ZR380");
      uiMenu2.AddItem(NightmareZR380Use);
      UIMenuItem FutureShockZR380Use = new UIMenuItem("Future Shock ZR380");
      uiMenu2.AddItem(FutureShockZR380Use);
      UIMenuItem ApocalypseZR380Buy = new UIMenuItem("Apocalypse ZR380 : $2,910,000");
      uiMenu1.AddItem(ApocalypseZR380Buy);
      UIMenuItem NightmareZR380Buy = new UIMenuItem("Nightmare ZR380 : $2,910,000 ");
      uiMenu1.AddItem(NightmareZR380Buy);
      UIMenuItem FutureShockZR380Buy = new UIMenuItem("Future Shock ZR380 : $2,910,000");
      uiMenu1.AddItem(FutureShockZR380Buy);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseZR380Use)
        {
          if (this.ApocalypseZR380Bought == 1)
          {
            this.ZR380.Delete();
            this.SC.LoadIniFile(this.Loadpath + "ZR380//1Apocalypse.ini");
            this.ZR380 = World.CreateVehicle((GTA.Model) "ZR380", this.ZR380Spawn, 90f);
            this.SC.Load(this.ZR380);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.ZR380?.ToString());
            this.CurrentZR380 = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentZR380", this.CurrentZR380);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareZR380Use)
        {
          if (this.NightmareZR380Bought == 1)
          {
            this.ZR380.Delete();
            this.SC.LoadIniFile(this.Loadpath + "ZR380//2NIghtmare.ini");
            this.ZR380 = World.CreateVehicle((GTA.Model) "ZR3803", this.ZR380Spawn, 90f);
            this.SC.Load(this.ZR380);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.ZR380?.ToString());
            this.CurrentZR380 = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentZR380", this.CurrentZR380);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockZR380Use)
          return;
        if (this.FutureShockZR380Bought == 1)
        {
          this.ZR380.Delete();
          this.SC.LoadIniFile(this.Loadpath + "ZR380//3FutureShock.ini");
          this.ZR380 = World.CreateVehicle((GTA.Model) "ZR3802", this.ZR380Spawn, 90f);
          this.SC.Load(this.ZR380);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.ZR380?.ToString());
          this.CurrentZR380 = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentZR380", this.CurrentZR380);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseZR380Buy)
        {
          if (this.ApocalypseZR380Bought != 1)
          {
            if (Game.Player.Money >= 2910000)
            {
              this.SC.LoadIniFile(this.Loadpath + "ZR380//1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseZR380Bought = 1;
              Game.Player.Money -= 2910000;
              this.Config.SetValue<int>("Vehicles", "ApocalypseZR380Bought", this.ApocalypseZR380Bought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareZR380Buy)
        {
          if (this.NightmareZR380Bought != 1)
          {
            if (Game.Player.Money >= 2910000)
            {
              this.SC.LoadIniFile(this.Loadpath + "ZR380//2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareZR380Bought = 1;
              Game.Player.Money -= 2910000;
              this.Config.SetValue<int>("Vehicles", "NightmareZR380Bought", this.NightmareZR380Bought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockZR380Buy)
          return;
        if (this.FutureShockZR380Bought != 1)
        {
          if (Game.Player.Money >= 2910000)
          {
            this.SC.LoadIniFile(this.Loadpath + "ZR380//3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockZR380Bought = 1;
            Game.Player.Money -= 2910000;
            this.Config.SetValue<int>("Vehicles", "FutureShockZR380Bought", this.FutureShockZR380Bought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu3 = this.GarageMenuPool.AddSubMenu(menu2, "Buy");
      this.GUIMenus.Add(uiMenu3);
      UIMenu uiMenu4 = this.GarageMenuPool.AddSubMenu(menu2, "Use");
      this.GUIMenus.Add(uiMenu4);
      UIMenuItem ApocalypseBruiserUse = new UIMenuItem("Apocalypse Bruiser");
      uiMenu4.AddItem(ApocalypseBruiserUse);
      UIMenuItem NightmareBruiserUse = new UIMenuItem("Nightmare Bruiser");
      uiMenu4.AddItem(NightmareBruiserUse);
      UIMenuItem FutureShockBruiserUse = new UIMenuItem("Future Shock Bruiser");
      uiMenu4.AddItem(FutureShockBruiserUse);
      UIMenuItem ApocalypseBruiserBuy = new UIMenuItem("Apocalypse Bruiser: $2,910,000");
      uiMenu3.AddItem(ApocalypseBruiserBuy);
      UIMenuItem NightmareBruiserBuy = new UIMenuItem("Nightmare Bruiser : $2,910,000 ");
      uiMenu3.AddItem(NightmareBruiserBuy);
      UIMenuItem FutureShockBruiserBuy = new UIMenuItem("Future Shock Bruiser : $2,910,000");
      uiMenu3.AddItem(FutureShockBruiserBuy);
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseBruiserUse)
        {
          if (this.ApocalypseBruiserBought == 1)
          {
            this.Bruiser.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Bruiser/1Apocalypse.ini");
            this.Bruiser = World.CreateVehicle((GTA.Model) "Bruiser", this.BruiserSpawn, -90f);
            this.SC.Load(this.Bruiser);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Bruiser?.ToString());
            this.CurrentBruiser = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentBruiser", this.CurrentBruiser);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareBruiserUse)
        {
          if (this.NightmareBruiserBought == 1)
          {
            this.Bruiser.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Bruiser/2NIghtmare.ini");
            this.Bruiser = World.CreateVehicle((GTA.Model) "Bruiser3", this.BruiserSpawn, -90f);
            this.SC.Load(this.Bruiser);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Bruiser?.ToString());
            this.CurrentBruiser = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentBruiser", this.CurrentBruiser);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockBruiserUse)
          return;
        if (this.FutureShockBruiserBought == 1)
        {
          this.Bruiser.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Bruiser/3FutureShock.ini");
          this.Bruiser = World.CreateVehicle((GTA.Model) "Bruiser2", this.BruiserSpawn, -90f);
          this.SC.Load(this.Bruiser);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Bruiser?.ToString());
          this.CurrentBruiser = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentBruiser", this.CurrentBruiser);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseBruiserBuy)
        {
          if (this.ApocalypseBruiserBought != 1)
          {
            if (Game.Player.Money >= 2313000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Bruiser/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseBruiserBought = 1;
              Game.Player.Money -= 2313000;
              this.Config.SetValue<int>("Vehicles", "ApocalypseBruiserBought", this.ApocalypseBruiserBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareBruiserBuy)
        {
          if (this.NightmareBruiserBought != 1)
          {
            if (Game.Player.Money >= 2313000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Bruiser/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareBruiserBought = 1;
              Game.Player.Money -= 2313000;
              this.Config.SetValue<int>("Vehicles", "NightmareBruiserBought", this.NightmareBruiserBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockBruiserBuy)
          return;
        if (this.FutureShockBruiserBought != 1)
        {
          if (Game.Player.Money >= 2313000)
          {
            this.SC.LoadIniFile(this.Loadpath + "Bruiser/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockBruiserBought = 1;
            Game.Player.Money -= 2313000;
            this.Config.SetValue<int>("Vehicles", "FutureShockBruiserBought", this.FutureShockBruiserBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu5 = this.GarageMenuPool.AddSubMenu(menu3, "Buy");
      this.GUIMenus.Add(uiMenu5);
      UIMenuItem Clique = new UIMenuItem("Clique $909,000 ");
      uiMenu5.AddItem(Clique);
      UIMenuItem ItlaiGto = new UIMenuItem("Itali GTO $1,965,000 ");
      uiMenu5.AddItem(ItlaiGto);
      UIMenuItem Tulip = new UIMenuItem("Tulip $718,000");
      uiMenu5.AddItem(Tulip);
      UIMenuItem Vamos = new UIMenuItem("Vamos $596,000");
      uiMenu5.AddItem(Vamos);
      UIMenuItem Schalgen = new UIMenuItem("Schlagen $1,300,000");
      uiMenu5.AddItem(Schalgen);
      UIMenuItem Deviant = new UIMenuItem("Deviant $512,000");
      uiMenu5.AddItem(Deviant);
      UIMenuItem Toros = new UIMenuItem("Toros $498,000 ");
      uiMenu5.AddItem(Toros);
      UIMenuItem Deveste = new UIMenuItem("Deveste $1,795,000");
      uiMenu5.AddItem(Deveste);
      UIMenuItem Rcbandito = new UIMenuItem("RC Bandito $1,590,000");
      uiMenu5.AddItem(Rcbandito);
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Clique)
        {
          if (Game.Player.Money >= 909000 && this.CliqueBought != 1)
          {
            Game.Player.Money -= 909000;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.CliqueBought = 1;
            this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
            this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
            this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
            this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
            this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
            this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
            this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
            this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
            this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
        }
        if (item == ItlaiGto)
        {
          if (Game.Player.Money >= 1965000 && this.ItaligtoBought != 1)
          {
            Game.Player.Money -= 1965000;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.ItaligtoBought = 1;
            this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
            this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
            this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
            this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
            this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
            this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
            this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
            this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
            this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
        }
        if (item == Tulip)
        {
          if (Game.Player.Money >= 718000 && this.TulipBought != 1)
          {
            Game.Player.Money -= 718000;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.TulipBought = 1;
            this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
            this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
            this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
            this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
            this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
            this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
            this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
            this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
            this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
        }
        if (item == Vamos)
        {
          if (Game.Player.Money >= 596000 && this.VamosBought != 1)
          {
            Game.Player.Money -= 596000;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.VamosBought = 1;
            this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
            this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
            this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
            this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
            this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
            this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
            this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
            this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
            this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
        }
        if (item == Schalgen)
        {
          if (Game.Player.Money >= 1300000 && this.SchlagenBought != 1)
          {
            Game.Player.Money -= 1300000;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.SchlagenBought = 1;
            this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
            this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
            this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
            this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
            this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
            this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
            this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
            this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
            this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
        }
        if (item == Deviant)
        {
          if (Game.Player.Money >= 512000 && this.DevesteBought != 1)
          {
            Game.Player.Money -= 512000;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.DeviantBought = 1;
            this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
            this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
            this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
            this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
            this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
            this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
            this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
            this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
            this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
        }
        if (item == Toros)
        {
          if (Game.Player.Money >= 498000 && this.TorosBought != 1)
          {
            Game.Player.Money -= 498000;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.TorosBought = 1;
            this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
            this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
            this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
            this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
            this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
            this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
            this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
            this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
            this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
        }
        if (item == Deveste)
        {
          if (Game.Player.Money >= 1795000 && this.DevesteBought != 1)
          {
            Game.Player.Money -= 1795000;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.DevesteBought = 1;
            this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
            this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
            this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
            this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
            this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
            this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
            this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
            this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
            this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
        }
        if (item != Rcbandito)
          return;
        if (Game.Player.Money >= 1595000 && this.DevesteBought != 1)
        {
          Game.Player.Money -= 1595000;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.DevesteBought = 1;
          this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
          this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
          this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
          this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
          this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
          this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
          this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
          this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
          this.Config.SetValue<int>("Vehicles", "RcBanditoBought", this.RcBanditoBought);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " You dont have enought money for this vehicle, or you have already bought this vehicle ");
      });
    }

    public void SetUpVehicles()
    {
      UIMenu uiMenu1 = this.GarageMenuPool.AddSubMenu(this.VehicleLoadMenu, "Vehicle Load Menu");
      this.GUIMenus.Add(uiMenu1);
      UIMenu menu1 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Cerberus");
      this.GUIMenus.Add(menu1);
      UIMenu menu2 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Scarab");
      this.GUIMenus.Add(menu2);
      UIMenu menu3 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Impaler");
      this.GUIMenus.Add(menu3);
      UIMenu menu4 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Deathbike");
      this.GUIMenus.Add(menu4);
      UIMenu menu5 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Dominator");
      this.GUIMenus.Add(menu5);
      UIMenu menu6 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Slamvan");
      this.GUIMenus.Add(menu6);
      UIMenu menu7 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Issi");
      this.GUIMenus.Add(menu7);
      UIMenu menu8 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Monster");
      this.GUIMenus.Add(menu8);
      UIMenu menu9 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Imperator");
      this.GUIMenus.Add(menu9);
      UIMenu menu10 = this.GarageMenuPool.AddSubMenu(this.VehicleMenu, "Bruitus");
      this.GUIMenus.Add(menu10);
      UIMenu uiMenu2 = this.GarageMenuPool.AddSubMenu(menu1, "Buy");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.GarageMenuPool.AddSubMenu(menu1, "Use");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem ApocalypseCerberusUse = new UIMenuItem("Apocalypse Cerberus");
      uiMenu3.AddItem(ApocalypseCerberusUse);
      UIMenuItem NightmareCerberusUse = new UIMenuItem("Nightmare Cerberus");
      uiMenu3.AddItem(NightmareCerberusUse);
      UIMenuItem FutureShockCerberusUse = new UIMenuItem("Future Shock Cerberus");
      uiMenu3.AddItem(FutureShockCerberusUse);
      UIMenuItem ApocalypseCerberusBuy = new UIMenuItem("Apocalypse Cerberus : $2,910,000");
      uiMenu2.AddItem(ApocalypseCerberusBuy);
      UIMenuItem NightmareCerberusBuy = new UIMenuItem("Nightmare Cerberus : $2,910,000 ");
      uiMenu2.AddItem(NightmareCerberusBuy);
      UIMenuItem FutureShockCerberusBuy = new UIMenuItem("Future Shock Cerberus : $2,910,000");
      uiMenu2.AddItem(FutureShockCerberusBuy);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseCerberusUse)
        {
          if (this.ApocalypseCerberusBought == 1)
          {
            this.Cerberus.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Cerberus//1Apocalypse.ini");
            this.Cerberus = World.CreateVehicle((GTA.Model) "Cerberus", this.CerberusSpawn, -90f);
            this.SC.Load(this.Cerberus);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Cerberus?.ToString());
            this.CurrentCerberus = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentCerberus", this.CurrentCerberus);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareCerberusUse)
        {
          if (this.NightmareCerberusBought == 1)
          {
            this.Cerberus.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Cerberus//2NIghtmare.ini");
            this.Cerberus = World.CreateVehicle((GTA.Model) "Cerberus3", this.CerberusSpawn, -90f);
            this.SC.Load(this.Cerberus);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Cerberus?.ToString());
            this.CurrentCerberus = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentCerberus", this.CurrentCerberus);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockCerberusUse)
          return;
        if (this.FutureShockCerberusBought == 1)
        {
          this.Cerberus.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Cerberus//3FutureShock.ini");
          this.Cerberus = World.CreateVehicle((GTA.Model) "Cerberus2", this.CerberusSpawn, -90f);
          this.SC.Load(this.Cerberus);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Cerberus?.ToString());
          this.CurrentCerberus = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentCerberus", this.CurrentCerberus);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseCerberusBuy)
        {
          if (this.ApocalypseCerberusBought != 1)
          {
            if (Game.Player.Money >= 2910000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Cerberus//1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseCerberusBought = 1;
              Game.Player.Money -= 2910000;
              this.Config.SetValue<int>("Vehicles", "ApocalypseCerberusBought", this.ApocalypseCerberusBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareCerberusBuy)
        {
          if (this.NightmareCerberusBought != 1)
          {
            if (Game.Player.Money >= 2910000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Cerberus//2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareCerberusBought = 1;
              Game.Player.Money -= 2910000;
              this.Config.SetValue<int>("Vehicles", "NightmareCerberusBought", this.NightmareCerberusBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockCerberusBuy)
          return;
        if (this.FutureShockCerberusBought != 1)
        {
          if (Game.Player.Money >= 2910000)
          {
            this.SC.LoadIniFile(this.Loadpath + "Cerberus//3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockCerberusBought = 1;
            Game.Player.Money -= 2910000;
            this.Config.SetValue<int>("Vehicles", "FutureShockCerberusBought", this.FutureShockCerberusBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu4 = this.GarageMenuPool.AddSubMenu(menu2, "Buy");
      this.GUIMenus.Add(uiMenu4);
      UIMenu uiMenu5 = this.GarageMenuPool.AddSubMenu(menu2, "Use");
      this.GUIMenus.Add(uiMenu5);
      UIMenuItem ApocalypseScarabUse = new UIMenuItem("Apocalypse Scarab");
      uiMenu5.AddItem(ApocalypseScarabUse);
      UIMenuItem NightmareScarabUse = new UIMenuItem("Nightmare Scarab");
      uiMenu5.AddItem(NightmareScarabUse);
      UIMenuItem FutureShockScarabUse = new UIMenuItem("Future Shock Scarab");
      uiMenu5.AddItem(FutureShockScarabUse);
      UIMenuItem ApocalypseScarabBuy = new UIMenuItem("Apocalypse Scarab: $2,910,000");
      uiMenu4.AddItem(ApocalypseScarabBuy);
      UIMenuItem NightmareScarabBuy = new UIMenuItem("Nightmare Scarab : $2,910,000 ");
      uiMenu4.AddItem(NightmareScarabBuy);
      UIMenuItem FutureShockScarabBuy = new UIMenuItem("Future Shock Scarab : $2,910,000");
      uiMenu4.AddItem(FutureShockScarabBuy);
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseScarabUse)
        {
          if (this.ApocalypseScarabBought == 1)
          {
            this.Scarab.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Scarab/1Apocalypse.ini");
            this.Scarab = World.CreateVehicle((GTA.Model) "Scarab", this.ScarabSpawn, 90f);
            this.SC.Load(this.Scarab);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Scarab?.ToString());
            this.CurrentScarab = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentScarab", this.CurrentScarab);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareScarabUse)
        {
          if (this.NightmareScarabBought == 1)
          {
            this.Scarab.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Scarab/2NIghtmare.ini");
            this.Scarab = World.CreateVehicle((GTA.Model) "Scarab3", this.ScarabSpawn, 90f);
            this.SC.Load(this.Scarab);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Scarab?.ToString());
            this.CurrentScarab = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentScarab", this.CurrentScarab);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockScarabUse)
          return;
        if (this.FutureShockScarabBought == 1)
        {
          this.Scarab.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Scarab/3FutureShock.ini");
          this.Scarab = World.CreateVehicle((GTA.Model) "Scarab2", this.ScarabSpawn, 90f);
          this.SC.Load(this.Scarab);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Scarab?.ToString());
          this.CurrentScarab = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentScarab", this.CurrentScarab);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseScarabBuy)
        {
          if (this.ApocalypseScarabBought != 1)
          {
            if (Game.Player.Money >= 2313000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Scarab/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseScarabBought = 1;
              Game.Player.Money -= 2313000;
              this.Config.SetValue<int>("Vehicles", "ApocalypseScarabBought", this.ApocalypseScarabBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareScarabBuy)
        {
          if (this.NightmareScarabBought != 1)
          {
            if (Game.Player.Money >= 2313000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Scarab/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareScarabBought = 1;
              Game.Player.Money -= 2313000;
              this.Config.SetValue<int>("Vehicles", "NightmareScarabBought", this.NightmareScarabBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockScarabBuy)
          return;
        if (this.FutureShockScarabBought != 1)
        {
          if (Game.Player.Money >= 2313000)
          {
            this.SC.LoadIniFile(this.Loadpath + "Scarab/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockScarabBought = 1;
            Game.Player.Money -= 2313000;
            this.Config.SetValue<int>("Vehicles", "FutureShockScarabBought", this.FutureShockScarabBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu6 = this.GarageMenuPool.AddSubMenu(menu5, "Buy");
      this.GUIMenus.Add(uiMenu6);
      UIMenu uiMenu7 = this.GarageMenuPool.AddSubMenu(menu5, "Use");
      this.GUIMenus.Add(uiMenu7);
      UIMenuItem ApocalypseDominatorUse = new UIMenuItem("Apocalypse Dominator");
      uiMenu7.AddItem(ApocalypseDominatorUse);
      UIMenuItem NightmareDominatorUse = new UIMenuItem("Nightmare Dominator");
      uiMenu7.AddItem(NightmareDominatorUse);
      UIMenuItem FutureShockDominatorUse = new UIMenuItem("Future Shock Dominator");
      uiMenu7.AddItem(FutureShockDominatorUse);
      UIMenuItem ApocalypseDominatorBuy = new UIMenuItem("Apocalypse Dominator: $1,075,400");
      uiMenu6.AddItem(ApocalypseDominatorBuy);
      UIMenuItem NightmareDominatorBuy = new UIMenuItem("Nightmare Dominator : $1,075,400 ");
      uiMenu6.AddItem(NightmareDominatorBuy);
      UIMenuItem FutureShockDominatorBuy = new UIMenuItem("Future Shock Dominator : $1,075,400");
      uiMenu6.AddItem(FutureShockDominatorBuy);
      uiMenu7.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseDominatorUse)
        {
          if (this.ApocalypseDominatorBought == 1)
          {
            this.Dominator.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Dominator/1Apocalypse.ini");
            this.Dominator = World.CreateVehicle((GTA.Model) "Dominator4", this.DominatorSpawn, -90f);
            this.SC.Load(this.Dominator);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Dominator?.ToString());
            this.CurrentDominator = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentDominator", this.CurrentDominator);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareDominatorUse)
        {
          if (this.NightmareDominatorBought == 1)
          {
            this.Dominator.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Dominator/2NIghtmare.ini");
            this.Dominator = World.CreateVehicle((GTA.Model) "Dominator6", this.DominatorSpawn, -90f);
            this.SC.Load(this.Dominator);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Dominator?.ToString());
            this.CurrentDominator = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentDominator", this.CurrentDominator);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockDominatorUse)
          return;
        if (this.FutureShockDominatorBought == 1)
        {
          this.Dominator.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Dominator/3FutureShock.ini");
          this.Dominator = World.CreateVehicle((GTA.Model) "Dominator5", this.DominatorSpawn, -90f);
          this.SC.Load(this.Dominator);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Dominator?.ToString());
          this.CurrentDominator = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentDominator", this.CurrentDominator);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu6.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseDominatorBuy)
        {
          if (this.ApocalypseDominatorBought != 1)
          {
            if (Game.Player.Money >= 2313000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Dominator/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseDominatorBought = 1;
              Game.Player.Money -= 2313000;
              this.Config.SetValue<int>("Vehicles", "ApocalypseDominatorBought", this.ApocalypseDominatorBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareDominatorBuy)
        {
          if (this.NightmareDominatorBought != 1)
          {
            if (Game.Player.Money >= 2313000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Dominator/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareDominatorBought = 1;
              Game.Player.Money -= 2313000;
              this.Config.SetValue<int>("Vehicles", "NightmareDominatorBought", this.NightmareDominatorBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockDominatorBuy)
          return;
        if (this.FutureShockDominatorBought != 1)
        {
          if (Game.Player.Money >= 2313000)
          {
            this.SC.LoadIniFile(this.Loadpath + "Dominator/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockDominatorBought = 1;
            Game.Player.Money -= 2313000;
            this.Config.SetValue<int>("Vehicles", "FutureShockDominatorBought", this.FutureShockDominatorBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu8 = this.GarageMenuPool.AddSubMenu(menu8, "Buy");
      this.GUIMenus.Add(uiMenu8);
      UIMenu uiMenu9 = this.GarageMenuPool.AddSubMenu(menu8, "Use");
      this.GUIMenus.Add(uiMenu9);
      UIMenuItem ApocalypseMonsterUse = new UIMenuItem("Apocalypse Monster");
      uiMenu9.AddItem(ApocalypseMonsterUse);
      UIMenuItem NightmareMonsterUse = new UIMenuItem("Nightmare Monster");
      uiMenu9.AddItem(NightmareMonsterUse);
      UIMenuItem FutureShockMonsterUse = new UIMenuItem("Future Shock Monster");
      uiMenu9.AddItem(FutureShockMonsterUse);
      UIMenuItem ApocalypseMonsterBuy = new UIMenuItem("Apocalypse Monster: $1,530,875");
      uiMenu8.AddItem(ApocalypseMonsterBuy);
      UIMenuItem NightmareMonsterBuy = new UIMenuItem("Nightmare Monster : $1,530,875 ");
      uiMenu8.AddItem(NightmareMonsterBuy);
      UIMenuItem FutureShockMonsterBuy = new UIMenuItem("Future Shock Monster : $1,530,875");
      uiMenu8.AddItem(FutureShockMonsterBuy);
      uiMenu9.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseMonsterUse)
        {
          if (this.ApocalypseMonsterBought == 1)
          {
            this.Monster.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Monster/1Apocalypse.ini");
            this.Monster = World.CreateVehicle((GTA.Model) "Monster3", this.MonsterSpawn, -90f);
            this.SC.Load(this.Monster);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Monster?.ToString());
            this.CurrentMonster = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentMonster", this.CurrentMonster);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareMonsterUse)
        {
          if (this.NightmareMonsterBought == 1)
          {
            this.Monster.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Monster/2NIghtmare.ini");
            this.Monster = World.CreateVehicle((GTA.Model) "Monster5", this.MonsterSpawn, -90f);
            this.SC.Load(this.Monster);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Monster?.ToString());
            this.CurrentMonster = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentMonster", this.CurrentMonster);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockMonsterUse)
          return;
        if (this.FutureShockMonsterBought == 1)
        {
          this.Monster.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Monster/3FutureShock.ini");
          this.Monster = World.CreateVehicle((GTA.Model) "Monster4", this.MonsterSpawn, -90f);
          this.SC.Load(this.Monster);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Monster?.ToString());
          this.CurrentMonster = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentMonster", this.CurrentMonster);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu8.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseMonsterBuy)
        {
          if (this.ApocalypseMonsterBought != 1)
          {
            if (Game.Player.Money >= 1530875)
            {
              this.SC.LoadIniFile(this.Loadpath + "Monster/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseMonsterBought = 1;
              Game.Player.Money -= 1530875;
              this.Config.SetValue<int>("Vehicles", "ApocalypseMonsterBought", this.ApocalypseMonsterBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareMonsterBuy)
        {
          if (this.NightmareMonsterBought != 1)
          {
            if (Game.Player.Money >= 1530875)
            {
              this.SC.LoadIniFile(this.Loadpath + "Monster/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareMonsterBought = 1;
              Game.Player.Money -= 1530875;
              this.Config.SetValue<int>("Vehicles", "NightmareMonsterBought", this.NightmareMonsterBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockMonsterBuy)
          return;
        if (this.FutureShockMonsterBought != 1)
        {
          if (Game.Player.Money >= 1530875)
          {
            this.SC.LoadIniFile(this.Loadpath + "Monster/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockMonsterBought = 1;
            Game.Player.Money -= 1530875;
            this.Config.SetValue<int>("Vehicles", "FutureShockMonsterBought", this.FutureShockMonsterBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu10 = this.GarageMenuPool.AddSubMenu(menu3, "Buy");
      this.GUIMenus.Add(uiMenu10);
      UIMenu uiMenu11 = this.GarageMenuPool.AddSubMenu(menu3, "Use");
      this.GUIMenus.Add(uiMenu11);
      UIMenuItem ApocalypseImpalerUse = new UIMenuItem("Apocalypse Impaler");
      uiMenu11.AddItem(ApocalypseImpalerUse);
      UIMenuItem NightmareImpalerUse = new UIMenuItem("Nightmare Impaler");
      uiMenu11.AddItem(NightmareImpalerUse);
      UIMenuItem FutureShockImpalerUse = new UIMenuItem("Future Shock Impaler");
      uiMenu11.AddItem(FutureShockImpalerUse);
      UIMenuItem ApocalypseImpalerBuy = new UIMenuItem("Apocalypse Impaler: $331,835");
      uiMenu10.AddItem(ApocalypseImpalerBuy);
      UIMenuItem NightmareImpalerBuy = new UIMenuItem("Nightmare Impaler : $331,835");
      uiMenu10.AddItem(NightmareImpalerBuy);
      UIMenuItem FutureShockImpalerBuy = new UIMenuItem("Future Shock Impaler : $331,835");
      uiMenu10.AddItem(FutureShockImpalerBuy);
      uiMenu11.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseImpalerUse)
        {
          if (this.ApocalypseImpalerBought == 1)
          {
            this.Impaler.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Impaler/1Apocalypse.ini");
            this.Impaler = World.CreateVehicle((GTA.Model) "Impaler2", this.ImpalerSpawn, 90f);
            this.SC.Load(this.Impaler);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Impaler?.ToString());
            this.CurrentImpaler = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentImpaler", this.CurrentImpaler);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareImpalerUse)
        {
          if (this.NightmareImpalerBought == 1)
          {
            this.Impaler.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Impaler/2NIghtmare.ini");
            this.Impaler = World.CreateVehicle((GTA.Model) "Impaler4", this.ImpalerSpawn, 90f);
            this.SC.Load(this.Impaler);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Impaler?.ToString());
            this.CurrentImpaler = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentImpaler", this.CurrentImpaler);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockImpalerUse)
          return;
        if (this.FutureShockImpalerBought == 1)
        {
          this.Impaler.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Impaler/3FutureShock.ini");
          this.Impaler = World.CreateVehicle((GTA.Model) "Impaler3", this.ImpalerSpawn, 90f);
          this.SC.Load(this.Impaler);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Impaler?.ToString());
          this.CurrentImpaler = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentImpaler", this.CurrentImpaler);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu10.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseImpalerBuy)
        {
          if (this.ApocalypseImpalerBought != 1)
          {
            if (Game.Player.Money >= 331835)
            {
              this.SC.LoadIniFile(this.Loadpath + "Impaler/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseImpalerBought = 1;
              Game.Player.Money -= 331835;
              this.Config.SetValue<int>("Vehicles", "ApocalypseImpalerBought", this.ApocalypseImpalerBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareImpalerBuy)
        {
          if (this.NightmareImpalerBought != 1)
          {
            if (Game.Player.Money >= 331835)
            {
              this.SC.LoadIniFile(this.Loadpath + "Impaler/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareImpalerBought = 1;
              Game.Player.Money -= 331835;
              this.Config.SetValue<int>("Vehicles", "NightmareImpalerBought", this.NightmareImpalerBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockImpalerBuy)
          return;
        if (this.FutureShockImpalerBought != 1)
        {
          if (Game.Player.Money >= 1530875)
          {
            this.SC.LoadIniFile(this.Loadpath + "Impaler/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockImpalerBought = 1;
            Game.Player.Money -= 1530875;
            this.Config.SetValue<int>("Vehicles", "FutureShockImpalerBought", this.FutureShockImpalerBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu12 = this.GarageMenuPool.AddSubMenu(menu9, "Buy");
      this.GUIMenus.Add(uiMenu12);
      UIMenu uiMenu13 = this.GarageMenuPool.AddSubMenu(menu9, "Use");
      this.GUIMenus.Add(uiMenu13);
      UIMenuItem ApocalypseImperatorUse = new UIMenuItem("Apocalypse Imperator");
      uiMenu13.AddItem(ApocalypseImperatorUse);
      UIMenuItem NightmareImperatorUse = new UIMenuItem("Nightmare Imperator");
      uiMenu13.AddItem(NightmareImperatorUse);
      UIMenuItem FutureShockImperatorUse = new UIMenuItem("Future Shock Imperator");
      uiMenu13.AddItem(FutureShockImperatorUse);
      UIMenuItem ApocalypseImperatorBuy = new UIMenuItem("Apocalypse Imperator: $1,718,000");
      uiMenu12.AddItem(ApocalypseImperatorBuy);
      UIMenuItem NightmareImperatorBuy = new UIMenuItem("Nightmare Imperator : $1,718,000");
      uiMenu12.AddItem(NightmareImperatorBuy);
      UIMenuItem FutureShockImperatorBuy = new UIMenuItem("Future Shock Imperator : $1,718,000");
      uiMenu12.AddItem(FutureShockImperatorBuy);
      uiMenu13.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseImperatorUse)
        {
          if (this.ApocalypseImperatorBought == 1)
          {
            this.Imperator.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Imperator/1Apocalypse.ini");
            this.Imperator = World.CreateVehicle((GTA.Model) "Imperator", this.ImperatorSpawn, 90f);
            this.SC.Load(this.Imperator);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Imperator?.ToString());
            this.CurrentImperator = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentImperator", this.CurrentImperator);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareImperatorUse)
        {
          if (this.NightmareImperatorBought == 1)
          {
            this.Imperator.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Imperator/2NIghtmare.ini");
            this.Imperator = World.CreateVehicle((GTA.Model) "Imperator3", this.ImperatorSpawn, 90f);
            this.SC.Load(this.Imperator);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Imperator?.ToString());
            this.CurrentImperator = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentImperator", this.CurrentImperator);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockImperatorUse)
          return;
        if (this.FutureShockImperatorBought == 1)
        {
          this.Imperator.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Imperator/3FutureShock.ini");
          this.Imperator = World.CreateVehicle((GTA.Model) "Imperator2", this.ImperatorSpawn, 90f);
          this.SC.Load(this.Imperator);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Imperator?.ToString());
          this.CurrentImperator = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentImperator", this.CurrentImperator);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu12.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseImperatorBuy)
        {
          if (this.ApocalypseImperatorBought != 1)
          {
            if (Game.Player.Money >= 1718000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Imperator/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseImperatorBought = 1;
              Game.Player.Money -= 1718000;
              this.Config.SetValue<int>("Vehicles", "ApocalypseImperatorBought", this.ApocalypseImperatorBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareImperatorBuy)
        {
          if (this.NightmareImperatorBought != 1)
          {
            if (Game.Player.Money >= 1718000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Imperator/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareImperatorBought = 1;
              Game.Player.Money -= 1718000;
              this.Config.SetValue<int>("Vehicles", "NightmareImperatorBought", this.NightmareImperatorBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockImperatorBuy)
          return;
        if (this.FutureShockImperatorBought != 1)
        {
          if (Game.Player.Money >= 1718000)
          {
            this.SC.LoadIniFile(this.Loadpath + "Imperator/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockImperatorBought = 1;
            Game.Player.Money -= 1718000;
            this.Config.SetValue<int>("Vehicles", "FutureShockImperatorBought", this.FutureShockImperatorBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu14 = this.GarageMenuPool.AddSubMenu(menu4, "Buy");
      this.GUIMenus.Add(uiMenu14);
      UIMenu uiMenu15 = this.GarageMenuPool.AddSubMenu(menu4, "Use");
      this.GUIMenus.Add(uiMenu15);
      UIMenuItem ApocalypseDeathbikeUse = new UIMenuItem("Apocalypse Deathbike");
      uiMenu15.AddItem(ApocalypseDeathbikeUse);
      UIMenuItem NightmareDeathbikeUse = new UIMenuItem("Nightmare Deathbike");
      uiMenu15.AddItem(NightmareDeathbikeUse);
      UIMenuItem FutureShockDeathbikeUse = new UIMenuItem("Future Shock Deathbike");
      uiMenu15.AddItem(FutureShockDeathbikeUse);
      UIMenuItem ApocalypseDeathbikeBuy = new UIMenuItem("Apocalypse Deathbike: $1,269,000");
      uiMenu14.AddItem(ApocalypseDeathbikeBuy);
      UIMenuItem NightmareDeathbikeBuy = new UIMenuItem("Nightmare Deathbike : $1,269,000");
      uiMenu14.AddItem(NightmareDeathbikeBuy);
      UIMenuItem FutureShockDeathbikeBuy = new UIMenuItem("Future Shock Deathbike : $1,269,000");
      uiMenu14.AddItem(FutureShockDeathbikeBuy);
      uiMenu15.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseDeathbikeUse)
        {
          if (this.ApocalypseDeathbikeBought == 1)
          {
            this.Deathbike.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Deathbike/1Apocalypse.ini");
            this.Deathbike = World.CreateVehicle((GTA.Model) "Deathbike", this.DeathbikeSpawn, -90f);
            this.SC.Load(this.Deathbike);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Deathbike?.ToString());
            this.CurrentDeathbike = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentDeathbike", this.CurrentDeathbike);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareDeathbikeUse)
        {
          if (this.NightmareDeathbikeBought == 1)
          {
            this.Deathbike.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Deathbike/2NIghtmare.ini");
            this.Deathbike = World.CreateVehicle((GTA.Model) "Deathbike3", this.DeathbikeSpawn, -90f);
            this.SC.Load(this.Deathbike);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Deathbike?.ToString());
            this.CurrentDeathbike = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentDeathbike", this.CurrentDeathbike);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockDeathbikeUse)
          return;
        if (this.FutureShockDeathbikeBought == 1)
        {
          this.Deathbike.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Deathbike/3FutureShock.ini");
          this.Deathbike = World.CreateVehicle((GTA.Model) "Deathbike2", this.DeathbikeSpawn, -90f);
          this.SC.Load(this.Deathbike);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Deathbike?.ToString());
          this.CurrentDeathbike = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentDeathbike", this.CurrentDeathbike);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu14.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseDeathbikeBuy)
        {
          if (this.ApocalypseDeathbikeBought != 1)
          {
            if (Game.Player.Money >= 1269000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Deathbike/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseDeathbikeBought = 1;
              Game.Player.Money -= 1269000;
              this.Config.SetValue<int>("Vehicles", "ApocalypseDeathbikeBought", this.ApocalypseDeathbikeBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareDeathbikeBuy)
        {
          if (this.NightmareDeathbikeBought != 1)
          {
            if (Game.Player.Money >= 1269000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Deathbike/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareDeathbikeBought = 1;
              Game.Player.Money -= 1269000;
              this.Config.SetValue<int>("Vehicles", "NightmareDeathbikeBought", this.NightmareDeathbikeBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockDeathbikeBuy)
          return;
        if (this.FutureShockDeathbikeBought != 1)
        {
          if (Game.Player.Money >= 1269000)
          {
            this.SC.LoadIniFile(this.Loadpath + "Deathbike/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockDeathbikeBought = 1;
            Game.Player.Money -= 1269000;
            this.Config.SetValue<int>("Vehicles", "FutureShockDeathbikeBought", this.FutureShockDeathbikeBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu16 = this.GarageMenuPool.AddSubMenu(menu6, "Buy");
      this.GUIMenus.Add(uiMenu16);
      UIMenu uiMenu17 = this.GarageMenuPool.AddSubMenu(menu6, "Use");
      this.GUIMenus.Add(uiMenu17);
      UIMenuItem ApocalypseSlamvanUse = new UIMenuItem("Apocalypse Slamvan");
      uiMenu17.AddItem(ApocalypseSlamvanUse);
      UIMenuItem NightmareSlamvanUse = new UIMenuItem("Nightmare Slamvan");
      uiMenu17.AddItem(NightmareSlamvanUse);
      UIMenuItem FutureShockSlamvanUse = new UIMenuItem("Future Shock Slamvan");
      uiMenu17.AddItem(FutureShockSlamvanUse);
      UIMenuItem ApocalypseSlamvanBuy = new UIMenuItem("Apocalypse Slamvan: $1,255,781");
      uiMenu16.AddItem(ApocalypseSlamvanBuy);
      UIMenuItem NightmareSlamvanBuy = new UIMenuItem("Nightmare Slamvan : $1,255,781");
      uiMenu16.AddItem(NightmareSlamvanBuy);
      UIMenuItem FutureShockSlamvanBuy = new UIMenuItem("Future Shock Slamvan : $1,255,781");
      uiMenu16.AddItem(FutureShockSlamvanBuy);
      uiMenu17.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseSlamvanUse)
        {
          if (this.ApocalypseSlamvanBought == 1)
          {
            this.Slamvan.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Slamvan/1Apocalypse.ini");
            this.Slamvan = World.CreateVehicle((GTA.Model) "Slamvan4", this.SlamvanSpawn, -90f);
            this.SC.Load(this.Slamvan);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Slamvan?.ToString());
            this.CurrentSlamvan = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentSlamvan", this.CurrentSlamvan);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareSlamvanUse)
        {
          if (this.NightmareSlamvanBought == 1)
          {
            this.Slamvan.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Slamvan/2NIghtmare.ini");
            this.Slamvan = World.CreateVehicle((GTA.Model) "Slamvan6", this.SlamvanSpawn, -90f);
            this.SC.Load(this.Slamvan);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Slamvan?.ToString());
            this.CurrentSlamvan = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentSlamvan", this.CurrentSlamvan);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockSlamvanUse)
          return;
        if (this.FutureShockSlamvanBought == 1)
        {
          this.Slamvan.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Slamvan/3FutureShock.ini");
          this.Slamvan = World.CreateVehicle((GTA.Model) "Slamvan5", this.SlamvanSpawn, -90f);
          this.SC.Load(this.Slamvan);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Slamvan?.ToString());
          this.CurrentSlamvan = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentSlamvan", this.CurrentSlamvan);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu16.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseSlamvanBuy)
        {
          if (this.ApocalypseSlamvanBought != 1)
          {
            if (Game.Player.Money >= 1255781)
            {
              this.SC.LoadIniFile(this.Loadpath + "Slamvan/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseSlamvanBought = 1;
              Game.Player.Money -= 1255781;
              this.Config.SetValue<int>("Vehicles", "ApocalypseSlamvanBought", this.ApocalypseSlamvanBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareSlamvanBuy)
        {
          if (this.NightmareSlamvanBought != 1)
          {
            if (Game.Player.Money >= 1255781)
            {
              this.SC.LoadIniFile(this.Loadpath + "Slamvan/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareSlamvanBought = 1;
              Game.Player.Money -= 1255781;
              this.Config.SetValue<int>("Vehicles", "NightmareSlamvanBought", this.NightmareSlamvanBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockSlamvanBuy)
          return;
        if (this.FutureShockSlamvanBought != 1)
        {
          if (Game.Player.Money >= 1255781)
          {
            this.SC.LoadIniFile(this.Loadpath + "Slamvan/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockSlamvanBought = 1;
            Game.Player.Money -= 1255781;
            this.Config.SetValue<int>("Vehicles", "FutureShockSlamvanBought", this.FutureShockSlamvanBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu18 = this.GarageMenuPool.AddSubMenu(menu7, "Buy");
      this.GUIMenus.Add(uiMenu18);
      UIMenu uiMenu19 = this.GarageMenuPool.AddSubMenu(menu7, "Use");
      this.GUIMenus.Add(uiMenu19);
      UIMenuItem ApocalypseIssiUse = new UIMenuItem("Apocalypse Issi");
      uiMenu19.AddItem(ApocalypseIssiUse);
      UIMenuItem NightmareIssiUse = new UIMenuItem("Nightmare Issi");
      uiMenu19.AddItem(NightmareIssiUse);
      UIMenuItem FutureShockIssiUse = new UIMenuItem("Future Shock Issi");
      uiMenu19.AddItem(FutureShockIssiUse);
      UIMenuItem ApocalypseIssiBuy = new UIMenuItem("Apocalypse Issi : $1,034,550");
      uiMenu18.AddItem(ApocalypseIssiBuy);
      UIMenuItem NightmareIssiBuy = new UIMenuItem("Nightmare Issi : $1,034,550");
      uiMenu18.AddItem(NightmareIssiBuy);
      UIMenuItem FutureShockIssiBuy = new UIMenuItem("Future Shock Issi : $1,034,550");
      uiMenu18.AddItem(FutureShockIssiBuy);
      uiMenu19.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseIssiUse)
        {
          if (this.ApocalypseIssiBought == 1)
          {
            this.Issi.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Issi/1Apocalypse.ini");
            this.Issi = World.CreateVehicle((GTA.Model) "Issi4", this.IssiSpawn, -90f);
            this.SC.Load(this.Issi);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Issi?.ToString());
            this.CurrentIssi = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentIssi", this.CurrentIssi);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareIssiUse)
        {
          if (this.NightmareIssiBought == 1)
          {
            this.Issi.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Issi/2NIghtmare.ini");
            this.Issi = World.CreateVehicle((GTA.Model) "Issi6", this.IssiSpawn, -90f);
            this.SC.Load(this.Issi);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Issi?.ToString());
            this.CurrentIssi = 3;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentIssi", this.CurrentIssi);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockIssiUse)
          return;
        if (this.FutureShockIssiBought == 1)
        {
          this.Issi.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Issi/3FutureShock.ini");
          this.Issi = World.CreateVehicle((GTA.Model) "Issi5", this.IssiSpawn, -90f);
          this.SC.Load(this.Issi);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Issi?.ToString());
          this.CurrentIssi = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentIssi", this.CurrentIssi);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu18.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseIssiBuy)
        {
          if (this.ApocalypseSlamvanBought != 1)
          {
            if (Game.Player.Money >= 1034550)
            {
              this.SC.LoadIniFile(this.Loadpath + "Issi/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseIssiBought = 1;
              Game.Player.Money -= 1034550;
              this.Config.SetValue<int>("Vehicles", "ApocalypseIssiBought", this.ApocalypseIssiBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareIssiBuy)
        {
          if (this.NightmareIssiBought != 1)
          {
            if (Game.Player.Money >= 1034550)
            {
              this.SC.LoadIniFile(this.Loadpath + "Issi/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareIssiBought = 1;
              Game.Player.Money -= 1034550;
              this.Config.SetValue<int>("Vehicles", "NightmareIssiBought", this.NightmareIssiBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockIssiBuy)
          return;
        if (this.FutureShockIssiBought != 1)
        {
          if (Game.Player.Money >= 1034550)
          {
            this.SC.LoadIniFile(this.Loadpath + "Issi/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockIssiBought = 1;
            Game.Player.Money -= 1034550;
            this.Config.SetValue<int>("Vehicles", "FutureShockIssiBought", this.FutureShockIssiBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenu uiMenu20 = this.GarageMenuPool.AddSubMenu(menu10, "Buy");
      this.GUIMenus.Add(uiMenu20);
      UIMenu uiMenu21 = this.GarageMenuPool.AddSubMenu(menu10, "Use");
      this.GUIMenus.Add(uiMenu21);
      UIMenuItem ApocalypseBruitusUse = new UIMenuItem("Apocalypse Brutus");
      uiMenu21.AddItem(ApocalypseBruitusUse);
      UIMenuItem NightmareBruitusUse = new UIMenuItem("Nightmare Brutus");
      uiMenu21.AddItem(NightmareBruitusUse);
      UIMenuItem FutureShockBruitusUse = new UIMenuItem("Future Shock  Brutus");
      uiMenu21.AddItem(FutureShockBruitusUse);
      UIMenuItem ApocalypseBruitusBuy = new UIMenuItem("Apocalypse Bruitus : $2,005,000");
      uiMenu20.AddItem(ApocalypseBruitusBuy);
      UIMenuItem NightmareBruitusBuy = new UIMenuItem("Nightmare Bruitus : $2,005,000");
      uiMenu20.AddItem(NightmareBruitusBuy);
      UIMenuItem FutureShockBruitusBuy = new UIMenuItem("Future Shock Bruitus : $2,005,000");
      uiMenu20.AddItem(FutureShockBruitusBuy);
      uiMenu21.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseBruitusUse)
        {
          if (this.ApocalypseBruitusBought == 1)
          {
            this.Bruitus.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Bruitus/1Apocalypse.ini");
            this.Bruitus = World.CreateVehicle((GTA.Model) "Brutus", this.BruitusSpawn, 90f);
            this.SC.Load(this.Bruitus);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Bruitus?.ToString());
            this.CurrentBruitus = 1;
            this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentBruitus", this.CurrentBruitus);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item == NightmareBruitusUse)
        {
          if (this.NightmareBruitusBought == 1)
          {
            this.Bruitus.Delete();
            this.SC.LoadIniFile(this.Loadpath + "Bruitus/2NIghtmare.ini");
            this.Bruitus = World.CreateVehicle((GTA.Model) "Brutus3", this.BruitusSpawn, 90f);
            this.SC.Load(this.Bruitus);
            this.SC.SaveWithoutDelete();
            UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Bruitus?.ToString());
            this.CurrentBruitus = 3;
            this.LoadIniFile("scripts/HKH191sBusinessMods///ArenaWarBusiness//Main.ini");
            this.Config.SetValue<int>("Vehicles", "CurrentBruitus", this.CurrentBruitus);
            this.Config.Save();
          }
          else
            UI.Notify(this.GetHostName() + " you dont own this vehicle");
        }
        if (item != FutureShockBruitusUse)
          return;
        if (this.FutureShockBruitusBought == 1)
        {
          this.Bruitus.Delete();
          this.SC.LoadIniFile(this.Loadpath + "Bruitus/3FutureShock.ini");
          this.Bruitus = World.CreateVehicle((GTA.Model) "Brutus2", this.BruitusSpawn, 90f);
          this.SC.Load(this.Bruitus);
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Loaded vehicle : " + this.Bruitus?.ToString());
          this.CurrentBruitus = 2;
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Config.SetValue<int>("Vehicles", "CurrentBruitus", this.CurrentBruitus);
          this.Config.Save();
        }
        else
          UI.Notify(this.GetHostName() + " you dont own this vehicle");
      });
      uiMenu20.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ApocalypseBruitusBuy)
        {
          if (this.ApocalypseBruitusBought != 1)
          {
            if (Game.Player.Money >= 2005000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Bruitus/1Apocalypse.ini");
              this.ResetSourcedVehicle();
              this.ApocalypseBruitusBought = 1;
              Game.Player.Money -= 2005000;
              this.Config.SetValue<int>("Vehicles", "ApocalypseBrutusBought", this.ApocalypseBruitusBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item == NightmareBruitusBuy)
        {
          if (this.NightmareBruitusBought != 1)
          {
            if (Game.Player.Money >= 2005000)
            {
              this.SC.LoadIniFile(this.Loadpath + "Bruitus/2NIghtmare.ini");
              this.ResetSourcedVehicle();
              this.NightmareBruitusBought = 1;
              Game.Player.Money -= 2005000;
              this.Config.SetValue<int>("Vehicles", "NightmareBrutusBought", this.NightmareBruitusBought);
              this.Config.Save();
            }
          }
          else
            UI.Notify(this.GetHostName() + " you already own this vehicle ");
        }
        if (item != FutureShockBruitusBuy)
          return;
        if (this.FutureShockBruitusBought != 1)
        {
          if (Game.Player.Money >= 2005000)
          {
            this.SC.LoadIniFile(this.Loadpath + "Bruitus/3FutureShock.ini");
            this.ResetSourcedVehicle();
            this.FutureShockBruitusBought = 1;
            Game.Player.Money -= 2005000;
            this.Config.SetValue<int>("Vehicles", "FutureShockBrutusBought", this.FutureShockBruitusBought);
            this.Config.Save();
          }
        }
        else
          UI.Notify(this.GetHostName() + " you already own this vehicle ");
      });
      UIMenuItem Apocalypse = new UIMenuItem("Apocalypse");
      uiMenu1.AddItem(Apocalypse);
      UIMenuItem Nightmare = new UIMenuItem("Nightmare");
      uiMenu1.AddItem(Nightmare);
      UIMenuItem FutureShock = new UIMenuItem("Future Shock");
      uiMenu1.AddItem(FutureShock);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Apocalypse)
        {
          this.CurrentCerberus = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentCerberus", this.CurrentCerberus);
          this.CurrentScarab = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentScarab", this.CurrentScarab);
          this.CurrentDominator = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentDominator", this.CurrentDominator);
          this.CurrentImperator = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentImperator", this.CurrentImperator);
          this.CurrentDeathbike = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentDeathbike", this.CurrentDeathbike);
          this.CurrentIssi = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentIssi", this.CurrentIssi);
          this.CurrentMonster = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentMonster", this.CurrentMonster);
          this.CurrentImpaler = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentImpaler", this.CurrentImpaler);
          this.CurrentSlamvan = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentSlamvan", this.CurrentSlamvan);
          this.CurrentBruitus = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentBrutus", this.CurrentBruitus);
          this.CurrentZR380 = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentZR380", this.CurrentZR380);
          this.CurrentBruiser = 1;
          this.Config.SetValue<int>("Vehicles", "CurrentBruiser", this.CurrentBruiser);
          this.Config.Save();
          this.DeleteVehicles();
          this.LoadVehicles();
        }
        if (item == Nightmare)
        {
          this.CurrentCerberus = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentCerberus", this.CurrentCerberus);
          this.CurrentScarab = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentScarab", this.CurrentScarab);
          this.CurrentDominator = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentDominator", this.CurrentDominator);
          this.CurrentImperator = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentImperator", this.CurrentImperator);
          this.CurrentDeathbike = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentDeathbike", this.CurrentDeathbike);
          this.CurrentIssi = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentIssi", this.CurrentIssi);
          this.CurrentMonster = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentMonster", this.CurrentMonster);
          this.CurrentImpaler = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentImpaler", this.CurrentImpaler);
          this.CurrentSlamvan = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentSlamvan", this.CurrentSlamvan);
          this.CurrentBruitus = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentBrutus", this.CurrentBruitus);
          this.CurrentZR380 = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentZR380", this.CurrentZR380);
          this.CurrentBruiser = 2;
          this.Config.SetValue<int>("Vehicles", "CurrentBruiser", this.CurrentBruiser);
          this.Config.Save();
          this.DeleteVehicles();
          this.LoadVehicles();
        }
        if (item != FutureShock)
          return;
        this.CurrentCerberus = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentCerberus", this.CurrentCerberus);
        this.CurrentScarab = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentScarab", this.CurrentScarab);
        this.CurrentDominator = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentDominator", this.CurrentDominator);
        this.CurrentImperator = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentImperator", this.CurrentImperator);
        this.CurrentDeathbike = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentDeathbike", this.CurrentDeathbike);
        this.CurrentIssi = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentIssi", this.CurrentIssi);
        this.CurrentMonster = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentMonster", this.CurrentMonster);
        this.CurrentImpaler = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentImpaler", this.CurrentImpaler);
        this.CurrentSlamvan = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentSlamvan", this.CurrentSlamvan);
        this.CurrentBruitus = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentBrutus", this.CurrentBruitus);
        this.CurrentZR380 = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentZR380", this.CurrentZR380);
        this.CurrentBruiser = 3;
        this.Config.SetValue<int>("Vehicles", "CurrentBruiser", this.CurrentBruiser);
        this.Config.Save();
        this.DeleteVehicles();
        this.LoadVehicles();
      });
    }

    public Vector3 RandomLocationFun2()
    {
      int num = new System.Random().Next(1, 110);
      if (num < 10)
        this.RamdomLocationVar = new Vector3(2774f, -3779f, 140f);
      if (num >= 10 && num <= 20)
        this.RamdomLocationVar = new Vector3(2899f, -3749f, 140f);
      if (num > 20 && num < 30)
        this.RamdomLocationVar = new Vector3(2962f, -3790f, 140f);
      if (num > 30 && num < 40)
        this.RamdomLocationVar = new Vector3(2874f, -3866f, 138f);
      if (num > 40 && num < 50)
        this.RamdomLocationVar = new Vector3(2850f, -3852f, 139f);
      if (num > 50 && num < 60)
        this.RamdomLocationVar = new Vector3(2676f, -3795f, 143f);
      if (num > 60 && num < 70)
        this.RamdomLocationVar = new Vector3(2670f, -3745f, 140f);
      if (num > 70 && num < 80)
        this.RamdomLocationVar = new Vector3(2738f, -3784f, 140f);
      if (num > 80 && num < 90)
        this.RamdomLocationVar = new Vector3(2820f, -3727f, 140f);
      if (num > 90 && num < 100)
        this.RamdomLocationVar = new Vector3(2887f, -3811f, 140f);
      if (num > 100 && num <= 110)
        this.RamdomLocationVar = new Vector3(2684f, -3871f, 140f);
      return this.RamdomLocationVar;
    }

    public Vector3 RandomLocationFun3()
    {
      int num = new System.Random().Next(1, 110);
      if (num < 10)
        this.RamdomLocationVar = new Vector3(2684f, -3853f, 140f);
      if (num > 10 && num < 20)
        this.RamdomLocationVar = new Vector3(2682f, -3796f, 140f);
      if (num > 20 && num < 30)
        this.RamdomLocationVar = new Vector3(2728f, -3758f, 140f);
      if (num > 30 && num < 40)
        this.RamdomLocationVar = new Vector3(2799f, -3799f, 140f);
      if (num > 40 && num < 50)
        this.RamdomLocationVar = new Vector3(2870f, -3841f, 140f);
      if (num > 50 && num < 60)
        this.RamdomLocationVar = new Vector3(2895f, -3825f, 140f);
      if (num > 60 && num < 70)
        this.RamdomLocationVar = new Vector3(2918f, -3803f, 140f);
      if (num > 70 && num < 80)
        this.RamdomLocationVar = new Vector3(2917f, -3749f, 140f);
      if (num > 80 && num < 90)
        this.RamdomLocationVar = new Vector3(2800f, -3758f, (float) sbyte.MaxValue);
      if (num > 90 && num < 100)
        this.RamdomLocationVar = new Vector3(2757f, -3800f, (float) sbyte.MaxValue);
      if (num > 100 && num < 110)
        this.RamdomLocationVar = new Vector3(2801f, -3836f, (float) sbyte.MaxValue);
      return this.RamdomLocationVar;
    }

    public Vector3 RandomLocationFun4()
    {
      int num = new System.Random().Next(1, 110);
      if (num < 10)
        this.RamdomLocationVar = new Vector3(2733f, -3803f, (float) sbyte.MaxValue);
      if (num > 10 && num < 20)
        this.RamdomLocationVar = new Vector3(2790f, -3754f, (float) sbyte.MaxValue);
      if (num > 20 && num < 30)
        this.RamdomLocationVar = new Vector3(2855f, -3790f, (float) sbyte.MaxValue);
      if (num > 30 && num < 40)
        this.RamdomLocationVar = new Vector3(2886f, -3878f, 140f);
      if (num > 40 && num < 50)
        this.RamdomLocationVar = new Vector3(2886f, -3826f, 140f);
      if (num > 50 && num < 60)
        this.RamdomLocationVar = new Vector3(2909f, -3755f, 140f);
      if (num > 60 && num < 70)
        this.RamdomLocationVar = new Vector3(2762f, -3779f, 141f);
      if (num > 70 && num < 80)
        this.RamdomLocationVar = new Vector3(2643f, -3821f, 140f);
      if (num > 80 && num < 90)
        this.RamdomLocationVar = new Vector3(2784f, -3728f, 140f);
      if (num > 90 && num < 100)
        this.RamdomLocationVar = new Vector3(2906f, -3752f, 140f);
      if (num > 100 && num < 110)
        this.RamdomLocationVar = new Vector3(2941f, -3786f, 140f);
      return this.RamdomLocationVar;
    }

    public Vector3 RandomLocationFun5()
    {
      int num = new System.Random().Next(1, 140);
      if (num < 10)
        this.RamdomLocationVar = new Vector3(2738f, -3853f, 140f);
      if (num > 10 && num < 20)
        this.RamdomLocationVar = new Vector3(2745f, -3808f, 140f);
      if (num > 20 && num < 30)
        this.RamdomLocationVar = new Vector3(2752f, -3742f, 137f);
      if (num > 30 && num < 40)
        this.RamdomLocationVar = new Vector3(2799f, -3825f, 147f);
      if (num > 40 && num < 50)
        this.RamdomLocationVar = new Vector3(2799f, -3749f, 147f);
      if (num > 50 && num < 60)
        this.RamdomLocationVar = new Vector3(2875f, -3761f, 140f);
      if (num > 60 && num < 70)
        this.RamdomLocationVar = new Vector3(2892f, -3821f, 140f);
      if (num > 70 && num < 80)
        this.RamdomLocationVar = new Vector3(2837f, -3795f, 157f);
      if (num > 80 && num < 90)
        this.RamdomLocationVar = new Vector3(2652f, -3763f, 142f);
      if (num > 90 && num < 100)
        this.RamdomLocationVar = new Vector3(2772f, -3797f, 157f);
      if (num > 100 && num < 110)
        this.RamdomLocationVar = new Vector3(2923f, -3727f, 139f);
      if (num > 110 && num < 120)
        this.RamdomLocationVar = new Vector3(2937f, -3837f, 141f);
      if (num > 120 && num < 130)
        this.RamdomLocationVar = new Vector3(2675f, -3796f, 144f);
      if (num > 130 && num <= 140)
        this.RamdomLocationVar = new Vector3(2926f, -3796f, 144f);
      return this.RamdomLocationVar;
    }

    public Vector3 RandomLocationFun6()
    {
      int num = new System.Random().Next(1, 150);
      if (num < 10)
        this.RamdomLocationVar = new Vector3(2931f, -3828f, 139f);
      if (num > 10 && num < 20)
        this.RamdomLocationVar = new Vector3(2932f, -3771f, 139f);
      if (num > 20 && num < 30)
        this.RamdomLocationVar = new Vector3(2901f, -3799f, 139f);
      if (num > 30 && num < 40)
        this.RamdomLocationVar = new Vector3(2880f, -3800f, 139f);
      if (num > 40 && num < 50)
        this.RamdomLocationVar = new Vector3(2842f, -3798f, 139f);
      if (num > 50 && num < 60)
        this.RamdomLocationVar = new Vector3(2800f, -3800f, 139f);
      if (num > 60 && num < 70)
        this.RamdomLocationVar = new Vector3(2761f, -3800f, 139f);
      if (num > 70 && num < 80)
        this.RamdomLocationVar = new Vector3(2720f, -3799f, 139f);
      if (num > 80 && num < 90)
        this.RamdomLocationVar = new Vector3(2668f, -3772f, 139f);
      if (num > 90 && num < 100)
        this.RamdomLocationVar = new Vector3(2667f, -3828f, 139f);
      if (num > 100 && num < 110)
        this.RamdomLocationVar = new Vector3(2822f, -3854f, 147f);
      if (num > 110 && num < 120)
        this.RamdomLocationVar = new Vector3(2776f, -3854f, 147f);
      if (num > 120 && num < 130)
        this.RamdomLocationVar = new Vector3(2823f, -3745f, 147f);
      if (num > 130 && num < 140)
        this.RamdomLocationVar = new Vector3(2777f, -3745f, 147f);
      if (num > 140 && num <= 150)
        this.RamdomLocationVar = new Vector3(2757f, -3800f, 126f);
      return this.RamdomLocationVar;
    }

    public Vector3 RandomLocationFun7()
    {
      int num = new System.Random().Next(1, 150);
      if (num < 10)
        this.RamdomLocationVar = new Vector3(2714f, -3871f, 139f);
      if (num > 10 && num < 20)
        this.RamdomLocationVar = new Vector3(2705f, -3803f, 137f);
      if (num > 20 && num < 30)
        this.RamdomLocationVar = new Vector3(2759f, -3745f, 139f);
      if (num > 30 && num < 40)
        this.RamdomLocationVar = new Vector3(2834f, -3782f, 146f);
      if (num > 40 && num < 50)
        this.RamdomLocationVar = new Vector3(2879f, -3796f, 136f);
      if (num > 50 && num < 60)
        this.RamdomLocationVar = new Vector3(2803f, -3800f, 150f);
      if (num > 60 && num < 70)
        this.RamdomLocationVar = new Vector3(2841f, -3739f, 148f);
      if (num > 70 && num < 80)
        this.RamdomLocationVar = new Vector3(2801f, -3847f, 149f);
      if (num > 80 && num < 90)
        this.RamdomLocationVar = new Vector3(2747f, -3753f, 139f);
      if (num > 90 && num < 100)
        this.RamdomLocationVar = new Vector3(2855f, -3744f, 139f);
      if (num > 100 && num < 110)
        this.RamdomLocationVar = new Vector3(2942f, -3835f, 139f);
      if (num > 110 && num < 120)
        this.RamdomLocationVar = new Vector3(2887f, -3849f, 139f);
      if (num > 120 && num < 130)
        this.RamdomLocationVar = new Vector3(2748f, -3862f, 139f);
      if (num > 130 && num < 140)
        this.RamdomLocationVar = new Vector3(2695f, -3744f, 147f);
      if (num > 140 && num <= 150)
        this.RamdomLocationVar = new Vector3(2757f, -3800f, 126f);
      return this.RamdomLocationVar;
    }

    public Vector3 RandomLocationFun8()
    {
      int num = new System.Random().Next(1, 110);
      if (num < 10)
        this.RamdomLocationVar = new Vector3(2748f, -3754f, 134f);
      if (num >= 10 && num <= 20)
        this.RamdomLocationVar = new Vector3(2797f, -3751f, 134f);
      if (num > 20 && num < 30)
        this.RamdomLocationVar = new Vector3(2845f, -3773f, 134f);
      if (num > 30 && num < 40)
        this.RamdomLocationVar = new Vector3(2840f, -3845f, 134f);
      if (num > 40 && num < 50)
        this.RamdomLocationVar = new Vector3(2850f, -3852f, 134f);
      if (num > 50 && num < 60)
        this.RamdomLocationVar = new Vector3(2779f, -3830f, 133f);
      if (num > 60 && num < 70)
        this.RamdomLocationVar = new Vector3(2722f, -3807f, 133f);
      if (num > 70 && num < 80)
        this.RamdomLocationVar = new Vector3(2759f, -3790f, 132f);
      if (num > 80 && num < 90)
        this.RamdomLocationVar = new Vector3(2777f, -3810f, 132f);
      if (num > 90 && num < 100)
        this.RamdomLocationVar = new Vector3(2816f, -3812f, 132f);
      if (num > 100 && num <= 110)
        this.RamdomLocationVar = new Vector3(2817f, -3785f, 132f);
      return this.RamdomLocationVar;
    }

    public VehicleHash RandomVehicleFun()
    {
      System.Random random = new System.Random();
      if (random.Next(1, 13) == 1)
        this.RandomVehicle = VehicleHash.Baller;
      if (random.Next(1, 13) == 2)
        this.RandomVehicle = VehicleHash.Dominator;
      if (random.Next(1, 13) == 3)
        this.RandomVehicle = VehicleHash.Dukes;
      if (random.Next(1, 13) == 4)
        this.RandomVehicle = VehicleHash.Comet2;
      if (random.Next(1, 13) == 5)
        this.RandomVehicle = VehicleHash.SabreGT;
      if (random.Next(1, 13) == 6)
        this.RandomVehicle = VehicleHash.Schafter2;
      if (random.Next(1, 13) == 7)
        this.RandomVehicle = VehicleHash.Stalion;
      if (random.Next(1, 13) == 8)
        this.RandomVehicle = VehicleHash.Taco;
      if (random.Next(1, 13) == 9)
        this.RandomVehicle = VehicleHash.Voltic;
      if (random.Next(1, 13) == 10)
        this.RandomVehicle = VehicleHash.XLS;
      if (random.Next(1, 13) == 11)
        this.RandomVehicle = VehicleHash.Vader;
      if (random.Next(1, 13) == 12)
        this.RandomVehicle = VehicleHash.Sultan;
      if (random.Next(1, 13) == 13)
        this.RandomVehicle = VehicleHash.Sanchez;
      if (random.Next(1, 13) > 13)
        this.RandomVehicle = VehicleHash.Chino;
      return this.RandomVehicle;
    }

    public Vector3 Randomlocation()
    {
      int num = new System.Random().Next(1, 1400);
      if (num < 100)
        this.VehicleSpawn = new Vector3(-1069.32f, -72.28f, 19f);
      if (num >= 100 && num < 200)
        this.VehicleSpawn = new Vector3(-1579.93f, -155.28f, 55f);
      if (num >= 200 && num < 300)
        this.VehicleSpawn = new Vector3(-711.74f, -28.28f, 37f);
      if (num >= 300 && num < 400)
        this.VehicleSpawn = new Vector3(6f, 253.58f, 109f);
      if (num >= 400 && num < 500)
        this.VehicleSpawn = new Vector3(703f, 32f, 84f);
      if (num >= 500 && num < 600)
        this.VehicleSpawn = new Vector3(1197f, -421.5f, 68f);
      if (num >= 600 && num < 700)
        this.VehicleSpawn = new Vector3(1257f, -1428f, 35f);
      if (num >= 700 && num < 800)
        this.VehicleSpawn = new Vector3(1264f, -2039f, 45f);
      if (num >= 800 && num < 900)
        this.VehicleSpawn = new Vector3(527f, -2052f, 28f);
      if (num >= 900 && num < 1000)
        this.VehicleSpawn = new Vector3(-161f, -2087.8f, 26f);
      if (num >= 1000 && num < 1100)
        this.VehicleSpawn = new Vector3(756f, -1723f, 30f);
      if (num >= 1100 && num < 1200)
        this.VehicleSpawn = new Vector3(-816f, -2300f, 11f);
      if (num >= 1200 && num < 1300)
        this.VehicleSpawn = new Vector3(-1839f, 136f, 78f);
      if (num >= 1300 && num < 1400)
        this.VehicleSpawn = new Vector3(756f, -1723f, 30f);
      return this.VehicleSpawn;
    }

    public VehicleColor GetColor()
    {
      List<object> objectList = new List<object>();
      VehicleColor[] values = (VehicleColor[]) Enum.GetValues(typeof (VehicleColor));
      for (int index = 0; index < values.Length; ++index)
        objectList.Add((object) values[index]);
      int index1 = new System.Random().Next(1, values.Length);
      // ISSUE: reference to a compiler-generated field
      if (Class1.\u003C\u003Eo__661.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Class1.\u003C\u003Eo__661.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (Class1)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      return Class1.\u003C\u003Eo__661.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__661.\u003C\u003Ep__0, objectList[index1]);
    }

    private void SetupOrganization()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.OrganizationOptions, "Change Design");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem D1 = new UIMenuItem("Executive Rich : Free");
      uiMenu.AddItem(D1);
      UIMenuItem D2 = new UIMenuItem("Executive Cool: $415,000");
      uiMenu.AddItem(D2);
      UIMenuItem D3 = new UIMenuItem("Executive Contrast: $500,000");
      uiMenu.AddItem(D3);
      UIMenuItem D4 = new UIMenuItem("Old Spice Warms: $950,000");
      uiMenu.AddItem(D4);
      UIMenuItem D5 = new UIMenuItem("Old Spice Classical: $685,000");
      uiMenu.AddItem(D5);
      UIMenuItem D6 = new UIMenuItem("Old Spice Vintage: $760,000");
      uiMenu.AddItem(D6);
      UIMenuItem D7 = new UIMenuItem("Power Broker Ice $1,000,000\t");
      uiMenu.AddItem(D7);
      UIMenuItem D8 = new UIMenuItem("Power Broker Conservative: $835,000");
      uiMenu.AddItem(D8);
      UIMenuItem D9 = new UIMenuItem("Power Broker Polished: $910,000");
      uiMenu.AddItem(D9);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == D1 && Game.Player.Money >= 0)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Game.Player.Character.Position = this.MarkerEnter;
          Player player = Game.Player;
          player.Money = player.Money;
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
          this.Design = "ex_dt1_11_office_02b";
          this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
          this.Config.Save();
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Script.Wait(300);
          Game.FadeScreenIn(300);
        }
        if (item == D2 && Game.Player.Money >= 415000)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Game.Player.Character.Position = this.MarkerEnter;
          Game.Player.Money -= 415000;
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
          this.Design = "ex_dt1_11_office_02c";
          this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
          this.Config.Save();
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Script.Wait(300);
          Game.FadeScreenIn(300);
        }
        if (item == D3 && Game.Player.Money >= 500000)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Game.Player.Character.Position = this.MarkerEnter;
          Game.Player.Money -= 500000;
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
          this.Design = "ex_dt1_11_office_02a";
          this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
          this.Config.Save();
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Script.Wait(300);
          Game.FadeScreenIn(300);
        }
        if (item == D4 && Game.Player.Money >= 950000)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Game.Player.Character.Position = this.MarkerEnter;
          Game.Player.Money -= 950000;
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
          this.Design = "ex_dt1_11_office_01a";
          this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
          this.Config.Save();
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Script.Wait(300);
          Game.FadeScreenIn(300);
        }
        if (item == D5 && Game.Player.Money >= 685000)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Game.Player.Character.Position = this.MarkerEnter;
          Game.Player.Money -= 685000;
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
          this.Design = "ex_dt1_11_office_01b";
          this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
          this.Config.Save();
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Script.Wait(300);
          Game.FadeScreenIn(300);
        }
        if (item == D6 && Game.Player.Money >= 760000)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Game.Player.Character.Position = this.MarkerEnter;
          Game.Player.Money -= 760000;
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
          this.Design = "ex_dt1_11_office_01c";
          this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
          this.Config.Save();
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Script.Wait(300);
          Game.FadeScreenIn(300);
        }
        if (item == D7 && Game.Player.Money >= 1000000)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Game.Player.Character.Position = this.MarkerEnter;
          Game.Player.Money -= 1000000;
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
          this.Design = "ex_dt1_11_office_03a";
          this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
          this.Config.Save();
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Script.Wait(300);
          Game.FadeScreenIn(300);
        }
        if (item == D8 && Game.Player.Money >= 835000)
        {
          Game.FadeScreenOut(300);
          Script.Wait(300);
          Game.Player.Character.Position = this.MarkerEnter;
          Game.Player.Money -= 835000;
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
          this.Design = "ex_dt1_11_office_03b";
          this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
          this.Config.Save();
          Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
          Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
          Script.Wait(300);
          Game.FadeScreenIn(300);
        }
        if (item != D9 || Game.Player.Money < 910000)
          return;
        Game.FadeScreenOut(300);
        Script.Wait(300);
        Game.Player.Character.Position = this.MarkerEnter;
        Game.Player.Money -= 910000;
        Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
        Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.Design);
        this.Design = "ex_dt1_11_office_03c";
        this.Config.SetValue<string>("Design", "InteriorDesign", this.Design);
        this.Config.Save();
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
        Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
        Script.Wait(300);
        Game.FadeScreenIn(300);
      });
    }

    private void ChooseVehicle(int i)
    {
      if (i == 1)
      {
        this.carid = "Mogul";
        this.VehicleMissioncar = World.CreateVehicle(new GTA.Model(-749299473), this.VehicleLocation);
        this.VehicleMissioncar.PlaceOnGround();
      }
      if (i == 2)
      {
        this.carid = "Cuban 800";
        this.VehicleMissioncar = World.CreateVehicle((GTA.Model) VehicleHash.Cuban800, this.VehicleLocation);
        this.VehicleMissioncar.PlaceOnGround();
      }
      if (i == 3)
      {
        this.carid = "Duster";
        this.VehicleMissioncar = World.CreateVehicle((GTA.Model) VehicleHash.Duster, this.VehicleLocation);
        this.VehicleMissioncar.PlaceOnGround();
      }
      if (i != 4)
        return;
      this.carid = "Mammatus";
      this.VehicleMissioncar = World.CreateVehicle((GTA.Model) VehicleHash.Mammatus, this.VehicleLocation);
      this.VehicleMissioncar.PlaceOnGround();
    }

    private void SetupProduct()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.ProductStock, "Buy/Sell Product");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Buy2 = new UIMenuItem("Buy X10: -$" + 500000.ToString());
      uiMenu.AddItem(Buy2);
      UIMenuItem Buy = new UIMenuItem("Buy X1: -$" + 100000.ToString());
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          UI.Notify(this.GetHostName() + " Here is where we are at");
          UI.Notify("Level: " + this.purchaselvl.ToString() + "/20");
          UI.Notify("Max Stocks: " + this.maxstocks.ToString());
          UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
          UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
          UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
        }
        if (item == Buy2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          if (this.stockscount + 10 <= this.maxstocks)
          {
            if (Game.Player.Money > 500000)
            {
              Game.Player.Money -= 500000;
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          if (this.stockscount != this.maxstocks)
          {
            if (Game.Player.Money > 100000)
            {
              Game.Player.Money -= 100000;
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
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
            this.StockVeh = World.CreateVehicle((GTA.Model) VehicleHash.TipTruck, this.GarageMarker, 0.0f);
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
            this.StockVeh = World.CreateVehicle((GTA.Model) VehicleHash.Flatbed, this.GarageMarker, 0.0f);
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
            this.StockVeh = World.CreateVehicle((GTA.Model) VehicleHash.Guardian, this.GarageMarker, 0.0f);
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
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
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
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
          this.Sam1 = World.CreateVehicle((GTA.Model) VehicleHash.Flatbed, this.Sam1Loc);
          this.Sam2 = World.CreateVehicle((GTA.Model) VehicleHash.Flatbed, this.Sam2Loc);
          this.Sam3 = World.CreateVehicle((GTA.Model) VehicleHash.Flatbed, this.Sam3Loc);
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
          this.Sam1.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
          this.Sam1.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam1, this.EndPointVec, 20f, 120f, 1);
          this.Sam2.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
          this.Sam2.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Sam2, this.EndPointVec, 20f, 120f, 1);
          this.Sam3.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.ArmGoon02GMY);
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
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        UI.Notify(this.GetHostName() + " ok i can deal with that, selling all product avalable");
        Game.Player.Money += (int) this.stocksvalue;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
    }

    private void SetupSourcing2()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Sourcingmenu2, "Source a vehicle ");
      this.GUIMenus.Add(uiMenu);
      List<object> items = new List<object>();
      VehicleHash[] allvehiclehashes = (VehicleHash[]) Enum.GetValues(typeof (VehicleHash));
      for (int index = 0; index < allvehiclehashes.Length; ++index)
        items.Add((object) allvehiclehashes[index]);
      items.Add((object) VehicleHash.EntityXXR);
      items.Add((object) VehicleHash.Rhino);
      items.Add((object) VehicleHash.Stromberg);
      items.Add((object) VehicleHash.ZType);
      items.Add((object) VehicleHash.Deluxo);
      items.Add((object) VehicleHash.Visione);
      items.Add((object) VehicleHash.Vigilante);
      items.Add((object) VehicleHash.Vagner);
      items.Add((object) VehicleHash.Phantom2);
      items.Add((object) VehicleHash.Dune4);
      items.Add((object) VehicleHash.Dune5);
      items.Add((object) VehicleHash.Dune5);
      items.Add((object) VehicleHash.Wastelander);
      items.Add((object) VehicleHash.Banshee2);
      items.Add((object) VehicleHash.Voltic2);
      items.Add((object) VehicleHash.Technical2);
      items.Add((object) VehicleHash.Technical3);
      items.Add((object) VehicleHash.Tezeract);
      items.Add((object) VehicleHash.Taipan);
      items.Add((object) VehicleHash.Tampa3);
      UIMenuListItem list = new UIMenuListItem("Vehicle: ", items, 0);
      uiMenu.AddItem((UIMenuItem) list);
      UIMenuItem getvehicle = new UIMenuItem("Source Vehicle");
      uiMenu.AddItem(getvehicle);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != getvehicle)
          return;
        VehicleHash v = allvehiclehashes[list.Index];
        int num1;
        switch (v)
        {
          case VehicleHash.Kuruma2:
          case VehicleHash.NightShark:
          case VehicleHash.APC:
          case VehicleHash.Oppressor:
          case VehicleHash.Technical2:
          case VehicleHash.Technical3:
          case VehicleHash.Dune3:
          case VehicleHash.Insurgent2:
          case VehicleHash.Technical:
          case VehicleHash.Insurgent3:
          case VehicleHash.Insurgent:
          case VehicleHash.HalfTrack:
            num1 = 1;
            break;
          default:
            num1 = v == VehicleHash.Chernobog ? 1 : 0;
            break;
        }
        if (num1 != 0)
        {
          int num2 = new System.Random().Next(125000, 350000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.EntityXXR || v == VehicleHash.LE7B || (v == VehicleHash.Nero2 || v == VehicleHash.Nero2) || (v == VehicleHash.T20 || v == VehicleHash.Tyrant || (v == VehicleHash.Tezeract || v == VehicleHash.NightShark)) || (v == VehicleHash.Tempesta || v == VehicleHash.Technical || (v == VehicleHash.Osiris || v == VehicleHash.GP1) || (v == VehicleHash.Autarch || v == VehicleHash.SultanRS || (v == VehicleHash.Banshee2 || v == VehicleHash.Taipan))) || (v == VehicleHash.Taipan || v == VehicleHash.Vagner || (v == VehicleHash.Visione || v == VehicleHash.Prototipo) || (v == VehicleHash.Reaper || v == VehicleHash.Pfister811 || (v == VehicleHash.FMJ || v == VehicleHash.Zentorno)) || (v == VehicleHash.ItaliGTB2 || v == VehicleHash.ItaliGTB)) || v == VehicleHash.Voltic2)
        {
          int num2 = new System.Random().Next(75000, 1000000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.ZType)
        {
          int num2 = new System.Random().Next(195000, 2300000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.Deluxo || v == VehicleHash.Stromberg || v == VehicleHash.Vigilante || v == VehicleHash.Dune2)
        {
          int num2 = new System.Random().Next(135000, 550000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.Phantom2 || v == VehicleHash.Dune4 || (v == VehicleHash.Dune5 || v == VehicleHash.Wastelander) || (v == VehicleHash.Tampa3 || v == VehicleHash.Caracara) || v == VehicleHash.Monster)
        {
          int num2 = new System.Random().Next(100000, 400000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.Rhino || v == VehicleHash.Khanjari)
        {
          int num2 = new System.Random().Next(290000, 2000000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        else
        {
          int num2 = new System.Random().Next(100000, 200000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        this.VehicleIdentifier = v;
        this.VehicleIdentiferfun2(v);
        UI.Notify(this.GetHostName() + " Ok the car is a " + v.ToString());
        UI.Notify(this.GetHostName() + " the pay is  $" + this.SourcingPayout.ToString());
      });
    }

    private void SetupSourcing()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Sourcingmenu, "Source a vehicle ");
      this.GUIMenus.Add(uiMenu);
      List<object> items = new List<object>();
      VehicleHash[] allvehiclehashes = (VehicleHash[]) Enum.GetValues(typeof (VehicleHash));
      for (int index = 0; index < allvehiclehashes.Length; ++index)
        items.Add((object) allvehiclehashes[index]);
      items.Add((object) VehicleHash.EntityXXR);
      items.Add((object) VehicleHash.Rhino);
      items.Add((object) VehicleHash.Stromberg);
      items.Add((object) VehicleHash.ZType);
      items.Add((object) VehicleHash.Deluxo);
      items.Add((object) VehicleHash.Visione);
      items.Add((object) VehicleHash.Vigilante);
      items.Add((object) VehicleHash.Vagner);
      items.Add((object) VehicleHash.Phantom2);
      items.Add((object) VehicleHash.Dune4);
      items.Add((object) VehicleHash.Dune5);
      items.Add((object) VehicleHash.Dune5);
      items.Add((object) VehicleHash.Wastelander);
      items.Add((object) VehicleHash.Banshee2);
      items.Add((object) VehicleHash.Voltic2);
      items.Add((object) VehicleHash.Technical2);
      items.Add((object) VehicleHash.Technical3);
      items.Add((object) VehicleHash.Tezeract);
      items.Add((object) VehicleHash.Taipan);
      items.Add((object) VehicleHash.Tampa3);
      UIMenuListItem list = new UIMenuListItem("Vehicle: ", items, 0);
      uiMenu.AddItem((UIMenuItem) list);
      UIMenuItem getvehicle = new UIMenuItem("Source Vehicle");
      uiMenu.AddItem(getvehicle);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != getvehicle)
          return;
        VehicleHash v = allvehiclehashes[list.Index];
        int num1;
        switch (v)
        {
          case VehicleHash.Kuruma2:
          case VehicleHash.NightShark:
          case VehicleHash.APC:
          case VehicleHash.Oppressor:
          case VehicleHash.Technical2:
          case VehicleHash.Technical3:
          case VehicleHash.Dune3:
          case VehicleHash.Insurgent2:
          case VehicleHash.Technical:
          case VehicleHash.Insurgent3:
          case VehicleHash.Insurgent:
          case VehicleHash.HalfTrack:
            num1 = 1;
            break;
          default:
            num1 = v == VehicleHash.Chernobog ? 1 : 0;
            break;
        }
        if (num1 != 0)
        {
          int num2 = new System.Random().Next(125000, 350000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.EntityXXR || v == VehicleHash.LE7B || (v == VehicleHash.Nero2 || v == VehicleHash.Nero2) || (v == VehicleHash.T20 || v == VehicleHash.Tyrant || (v == VehicleHash.Tezeract || v == VehicleHash.NightShark)) || (v == VehicleHash.Tempesta || v == VehicleHash.Technical || (v == VehicleHash.Osiris || v == VehicleHash.GP1) || (v == VehicleHash.Autarch || v == VehicleHash.SultanRS || (v == VehicleHash.Banshee2 || v == VehicleHash.Taipan))) || (v == VehicleHash.Taipan || v == VehicleHash.Vagner || (v == VehicleHash.Visione || v == VehicleHash.Prototipo) || (v == VehicleHash.Reaper || v == VehicleHash.Pfister811 || (v == VehicleHash.FMJ || v == VehicleHash.Zentorno)) || (v == VehicleHash.ItaliGTB2 || v == VehicleHash.ItaliGTB)) || v == VehicleHash.Voltic2)
        {
          int num2 = new System.Random().Next(75000, 1000000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.ZType)
        {
          int num2 = new System.Random().Next(195000, 2300000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.Deluxo || v == VehicleHash.Stromberg || v == VehicleHash.Vigilante || v == VehicleHash.Dune2)
        {
          int num2 = new System.Random().Next(135000, 550000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.Phantom2 || v == VehicleHash.Dune4 || (v == VehicleHash.Dune5 || v == VehicleHash.Wastelander) || (v == VehicleHash.Tampa3 || v == VehicleHash.Caracara) || v == VehicleHash.Monster)
        {
          int num2 = new System.Random().Next(100000, 400000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        if (v == VehicleHash.Rhino || v == VehicleHash.Khanjari)
        {
          int num2 = new System.Random().Next(290000, 2000000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        else
        {
          int num2 = new System.Random().Next(100000, 200000);
          this.SourcingPayout = (float) num2 + (float) ((double) num2 * (double) this.profitMargin / 100.0);
        }
        this.VehicleIdentifier = v;
        this.VehicleIdentiferfun(v);
        UI.Notify(this.GetHostName() + " Ok the car is a " + v.ToString());
        UI.Notify(this.GetHostName() + " the pay is  $" + this.SourcingPayout.ToString());
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
        if (Class1.\u003C\u003Eo__667.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__667.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.ChairPropModel = Class1.\u003C\u003Eo__667.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__667.\u003C\u003Ep__0, Chairs[MainChairlist.Index]);
        this.Config.SetValue<string>("Chair Model", "ChairPropModel", this.ChairPropModel);
        this.Config.Save();
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__667.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__667.\u003C\u003Ep__2 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, System.Type, object> target = Class1.\u003C\u003Eo__667.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, System.Type, object>> p2 = Class1.\u003C\u003Eo__667.\u003C\u003Ep__2;
        System.Type type = typeof (UI);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__667.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__667.\u003C\u003Ep__1 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__667.\u003C\u003Ep__1.Target((CallSite) Class1.\u003C\u003Eo__667.\u003C\u003Ep__1, "~g~ HKH191~w~  : Main Chair Model has been set to ", Chairs[MainChairlist.Index]);
        target((CallSite) p2, type, obj);
        if ((Entity) this.ChairProp != (Entity) null)
          this.ChairProp.Delete();
        this.ChairProp = World.CreateProp(this.RequestModel(this.ChairPropModel), this.ChairPos, new Vector3(0.0f, 0.0f, 139f), false, false);
        this.ChairProp.FreezePosition = true;
        if ((Entity) this.ChairProp != (Entity) null)
        {
          this.ChairProp.Position = vector3;
          this.ChairProp.Heading = num2;
        }
        this.Createchair = true;
        if ((Entity) this.ComputerProp != (Entity) null)
          this.ComputerProp.Delete();
        this.ComputerProp = World.CreateProp(this.RequestModel("ex_prop_trailer_monitor_01"), new Vector3(204.48f, 5166.3f, -85.7f), new Vector3(0.0f, 0.0f, 0.0f), false, false);
        this.ComputerProp.FreezePosition = true;
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
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.methgarage, "Misc");
      this.GUIMenus.Add(uiMenu2);
      UIMenuListItem MC = new UIMenuListItem("Marker Color : ", MColour, 0);
      uiMenu2.AddItem((UIMenuItem) MC);
      UIMenuListItem BC = new UIMenuListItem("Blip Color : ", BColour, 0);
      uiMenu2.AddItem((UIMenuItem) BC);
      UIMenuItem uiMenuItem = new UIMenuItem("Current Host : " + this.GetHostName());
      uiMenu2.AddItem(uiMenuItem);
      UIMenuItem SetHN = new UIMenuItem("Set Host Name");
      uiMenu2.AddItem(SetHN);
      UIMenuListItem uiC = new UIMenuListItem("UI Color : ", UiColour, 0);
      uiMenu2.AddItem((UIMenuItem) uiC);
      UIMenuItem Setall = new UIMenuItem("Save All");
      uiMenu2.AddItem(Setall);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
        if (Class1.\u003C\u003Eo__667.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__667.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, BlipColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (BlipColor), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Blip_Colour = Class1.\u003C\u003Eo__667.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__667.\u003C\u003Ep__3, BColour[BC.Index]);
        this.Config.SetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__667.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__667.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.Uicolour = Class1.\u003C\u003Eo__667.\u003C\u003Ep__4.Target((CallSite) Class1.\u003C\u003Eo__667.\u003C\u003Ep__4, UiColour[uiC.Index]);
        this.Config.SetValue<string>("Misc", "Uicolour", this.Uicolour);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__667.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__667.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.MarkerColorString = Class1.\u003C\u003Eo__667.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__667.\u003C\u003Ep__5, MColour[MC.Index]);
        this.Config.SetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        this.Config.Save();
        UI.Notify(this.GetHostName() + " : Settings Changed they will take effect when you reload the mod!");
      });
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.methgarage, "Expand Business ");
      this.GUIMenus.Add(uiMenu3);
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.methgarage, "Money Vault Options ");
      this.GUIMenus.Add(uiMenu4);
      UIMenuItem BuyVW = new UIMenuItem("Buy : $450,000");
      uiMenu4.AddItem(BuyVW);
      UIMenu uiMenu5 = this.modMenuPool.AddSubMenu(this.methgarage, "Gun Locker Options ");
      this.GUIMenus.Add(uiMenu5);
      UIMenuItem BuyGL = new UIMenuItem("Buy : $1,000,000");
      uiMenu5.AddItem(BuyGL);
      UIMenuItem SellGL = new UIMenuItem("Sell");
      uiMenu5.AddItem(SellGL);
      UIMenuItem Update = new UIMenuItem("Update Stats");
      uiMenu3.AddItem(Update);
      UIMenuItem BuyNewLevel = new UIMenuItem(" Buy Level ");
      uiMenu3.AddItem(BuyNewLevel);
      UIMenuListItem list2 = new UIMenuListItem("Select Level: ", items, 1);
      uiMenu3.AddItem((UIMenuItem) list2);
      UIMenuItem Jump = new UIMenuItem("Jump Straight to Level");
      uiMenu3.AddItem(Jump);
      UIMenuItem Show = new UIMenuItem("Show Level");
      uiMenu3.AddItem(Show);
      UIMenu uiMenu6 = this.modMenuPool.AddSubMenu(this.methgarage, "Sell Business");
      this.GUIMenus.Add(uiMenu6);
      UIMenuItem Sell = new UIMenuItem("Sell");
      uiMenu6.AddItem(Sell);
      uiMenu6.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (this.Config.GetValue<int>("Setup", "GunLockerBought", this.GunLockerBought) == 0)
        {
          if (item != BuyGL)
            return;
          if (Game.Player.Money > 1000000)
          {
            Game.Player.Money -= 1000000;
            this.GunLockerBought = 1;
            this.Config.SetValue<int>("Setup", "GunLockerBought", this.GunLockerBought);
            this.Config.Save();
            UI.Notify(this.GetHostName() + " Ok good you can buy MK2 Weapons now from your gun locker");
          }
          else
            UI.Notify(this.GetHostName() + " Sorry boss you don't have enought money to purchase a  gun locker");
        }
        else
        {
          if (this.Config.GetValue<int>("Setup", "GunLockerBought", this.GunLockerBought) != 1)
            return;
          if (item == SellGL)
          {
            this.GunLockerBought = 0;
            this.Config.SetValue<int>("Setup", "GunLockerBought", this.GunLockerBought);
            this.Config.Save();
            UI.Notify(this.GetHostName() + " Ok i can organize to sell the gun locker");
          }
          UI.Notify(this.GetHostName() + " Boss you have allready bought a gun locker");
        }
      });
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (this.Config.GetValue<int>("Setup", "MoneyVaultBought", this.MoneyVaultBought) != 0 || item != BuyVW)
          return;
        if (Game.Player.Money > 450000)
        {
          Game.Player.Money -= 450000;
          this.MoneyVaultBought = 1;
          this.Config.SetValue<int>("Setup", "MoneyVaultBought", this.MoneyVaultBought);
          this.Config.Save();
          UI.Notify(this.GetHostName() + " Ok good you can store money now");
        }
        else
          UI.Notify(this.GetHostName() + " Sorry boss you don't have enought money to purchase a vehicle Warehouse");
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
          UI.Notify("Profit Margin  : $" + ((float) ((double) this.BusinessUpgradeIncreaseGain * (double) num2 / 0.75)).ToString("N"));
          UI.Notify("increaseGain:" + (0.85 * (double) num2 + 0.0).ToString() + "%");
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
          num7 = 3.75;
        if (this.purchaselvl > 50 && this.purchaselvl < 70)
          num7 = 6.75;
        if (this.purchaselvl > 75 && this.purchaselvl < 100)
          num7 = 9.75;
        UI.Notify("Price for Next Level $" + ((double) this.BusinessUpgradeBasePrice * num7 * (double) this.purchaselvl).ToString("N"));
        num6 = this.purchaselvl + 1;
        UI.Notify("Next Level " + num6.ToString());
        UI.Notify("increaseGain : $" + ((float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75)).ToString());
        UI.Notify("Profit Margin :" + (0.85 * (double) this.purchaselvl + 0.0).ToString() + "%");
        num6 = 10 * this.purchaselvl;
        UI.Notify("Max Stocks : " + num6.ToString());
      });
    }

    private void List2_OnListChanged(UIMenuListItem sender, int newIndex) => throw new NotImplementedException();

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

    public void UpgradeVehicle2(Vehicle Car)
    {
      Car.SetMod(VehicleMod.Brakes, 3, true);
      Car.SetMod(VehicleMod.Suspension, 3, true);
      Car.SetMod(VehicleMod.Transmission, 3, true);
      Car.SetMod(VehicleMod.Engine, 3, true);
    }

    public void UpgradeVehicle3(Vehicle Car)
    {
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) Car.Handle, (InputArgument) 0);
      Car.SetMod(VehicleMod.Brakes, 3, true);
      Car.SetMod(VehicleMod.Suspension, 3, true);
      Car.SetMod(VehicleMod.Transmission, 3, true);
      Car.SetMod(VehicleMod.Engine, 3, true);
      Car.PrimaryColor = this.GetColor();
      Car.SecondaryColor = this.GetColor();
    }

    public void ChecktoSeeifinthelead()
    {
      if (!this.CircuitRace)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.FinishLine) < (double) World.GetDistance(this.VehicleA.Position, this.FinishLine) && (double) World.GetDistance(Game.Player.Character.Position, this.FinishLine) < (double) World.GetDistance(this.VehicleB.Position, this.FinishLine) && (double) World.GetDistance(Game.Player.Character.Position, this.FinishLine) < (double) World.GetDistance(this.VehicleC.Position, this.FinishLine))
          this.IsLeading = true;
        else
          this.IsLeading = false;
      }
      else
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.VehicleA.Position) < 20.0)
        {
          this.VehicleA.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        }
        else
        {
          if (this.ACheck == 0)
            this.VehicleA.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleA, new Vector3(1165f, 24f, 81f), 20f, 420f);
          if (this.ACheck == 1)
            this.VehicleA.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleA, new Vector3(1253f, 267f, 82f), 20f, 420f);
          if (this.ACheck == 2)
            this.VehicleA.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleA, new Vector3(1101f, 166f, 81f), 20f, 420f);
          if (this.ACheck == 3)
            this.VehicleA.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleA, new Vector3(1005f, -72f, 81f), 20f, 420f);
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.VehicleB.Position) < 20.0)
        {
          this.VehicleB.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        }
        else
        {
          if (this.BCheck == 0)
            this.VehicleB.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleB, new Vector3(1165f, 24f, 81f), 20f, 420f);
          if (this.BCheck == 1)
            this.VehicleB.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleB, new Vector3(1253f, 267f, 82f), 20f, 420f);
          if (this.BCheck == 2)
            this.VehicleB.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleB, new Vector3(1101f, 166f, 81f), 20f, 420f);
          if (this.BCheck == 3)
            this.VehicleB.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleB, new Vector3(1005f, -72f, 81f), 20f, 420f);
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.VehicleC.Position) < 20.0)
        {
          this.VehicleC.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
        }
        else
        {
          if (this.CCheck == 0)
            this.VehicleC.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleC, new Vector3(1165f, 24f, 81f), 20f, 420f);
          if (this.CCheck == 1)
            this.VehicleC.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleC, new Vector3(1253f, 267f, 82f), 20f, 420f);
          if (this.CCheck == 2)
            this.VehicleC.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleC, new Vector3(1101f, 166f, 81f), 20f, 420f);
          if (this.CCheck == 3)
            this.VehicleC.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.VehicleC, new Vector3(1005f, -72f, 81f), 20f, 420f);
        }
        this.IsLeading = (double) World.GetDistance(Game.Player.Character.Position, this.FinishLine) < (double) World.GetDistance(this.VehicleA.Position, this.FinishLine) && (double) World.GetDistance(Game.Player.Character.Position, this.FinishLine) < (double) World.GetDistance(this.VehicleB.Position, this.FinishLine) && (double) World.GetDistance(Game.Player.Character.Position, this.FinishLine) < (double) World.GetDistance(this.VehicleC.Position, this.FinishLine);
      }
    }

    public GTA.Model getVehicle()
    {
      int num = new System.Random().Next(1, 310);
      if (num < 10)
        this.VehicleChoosen = VehicleHash.Dominator4;
      else if (num >= 10 && num < 20)
        this.VehicleChoosen = VehicleHash.Dominator5;
      else if (num >= 20 && num < 30)
        this.VehicleChoosen = VehicleHash.ZR380;
      else if (num >= 30 && num < 40)
        this.VehicleChoosen = VehicleHash.ZR3802;
      else if (num >= 40 && num < 50)
        this.VehicleChoosen = VehicleHash.ZR3803;
      else if (num >= 50 && num < 60)
        this.VehicleChoosen = VehicleHash.ZR3802;
      else if (num >= 60 && num < 80)
        this.VehicleChoosen = VehicleHash.Imperator;
      else if (num >= 80 && num < 90)
        this.VehicleChoosen = VehicleHash.Imperator3;
      else if (num >= 90 && num < 100)
        this.VehicleChoosen = VehicleHash.Imperator2;
      else if (num >= 100 && num < 110)
        this.VehicleChoosen = VehicleHash.Impaler2;
      else if (num >= 110 && num < 120)
        this.VehicleChoosen = VehicleHash.Impaler3;
      else if (num >= 120 && num < 130)
        this.VehicleChoosen = VehicleHash.Impaler4;
      else if (num >= 130 && num < 140)
        this.VehicleChoosen = VehicleHash.Monster3;
      else if (num > 140 && num < 150)
        this.VehicleChoosen = VehicleHash.Monster4;
      else if (num >= 150 && num < 160)
        this.VehicleChoosen = VehicleHash.Monster5;
      else if (num >= 160 && num < 170)
        this.VehicleChoosen = VehicleHash.Brutus;
      else if (num >= 170 && num < 180)
        this.VehicleChoosen = VehicleHash.Issi4;
      else if (num >= 180 && num < 190)
        this.VehicleChoosen = VehicleHash.Deathbike;
      else if (num >= 190 && num < 200)
        this.VehicleChoosen = VehicleHash.Scarab;
      else if (num >= 200 && num < 210)
        this.VehicleChoosen = VehicleHash.RCBandito;
      else if (num >= 210 && num < 220)
        this.VehicleChoosen = VehicleHash.Cerberus2;
      else if (num >= 220 && num < 230)
        this.VehicleChoosen = VehicleHash.Cerberus;
      else if (num >= 230 && num < 240)
        this.VehicleChoosen = VehicleHash.Cerberus3;
      else if (num >= 240 && num < 250)
        this.VehicleChoosen = VehicleHash.Bruiser;
      else if (num >= 250 && num < 260)
        this.VehicleChoosen = VehicleHash.Bruiser2;
      else if (num >= 260 && num < 270)
        this.VehicleChoosen = VehicleHash.Bruiser3;
      else if (num >= 270 && num < 280)
        this.VehicleChoosen = VehicleHash.Brutus2;
      else if (num >= 280 && num < 290)
        this.VehicleChoosen = VehicleHash.Brutus3;
      else if (num >= 290 && num < 300)
        this.VehicleChoosen = VehicleHash.Deathbike2;
      else if (num >= 300 && num <= 310)
        this.VehicleChoosen = VehicleHash.Deathbike3;
      return this.RequestModel(this.VehicleChoosen);
    }

    public GTA.Model getVehicle2()
    {
      int num = new System.Random().Next(1, 150);
      if (num < 10)
        this.VehicleChoosen = VehicleHash.Dominator4;
      else if (num >= 10 && num < 20)
        this.VehicleChoosen = VehicleHash.Dominator5;
      else if (num >= 20 && num < 30)
        this.VehicleChoosen = VehicleHash.ZR380;
      else if (num >= 30 && num < 40)
        this.VehicleChoosen = VehicleHash.ZR3802;
      else if (num >= 40 && num < 50)
        this.VehicleChoosen = VehicleHash.ZR3803;
      else if (num >= 50 && num < 60)
        this.VehicleChoosen = VehicleHash.ZR380;
      else if (num >= 60 && num < 70)
        this.VehicleChoosen = VehicleHash.Imperator;
      else if (num >= 70 && num < 80)
        this.VehicleChoosen = VehicleHash.Imperator2;
      else if (num >= 80 && num < 90)
        this.VehicleChoosen = VehicleHash.Imperator3;
      else if (num >= 90 && num < 100)
        this.VehicleChoosen = VehicleHash.Impaler;
      else if (num >= 110 && num < 110)
        this.VehicleChoosen = VehicleHash.Impaler2;
      else if (num >= 110 && num < 120)
        this.VehicleChoosen = VehicleHash.Impaler3;
      else if (num >= 120 && num < 130)
        this.VehicleChoosen = VehicleHash.Imperator3;
      else if (num >= 130 && num < 140)
        this.VehicleChoosen = VehicleHash.Dominator4;
      if (num >= 140 && num < 150)
        this.VehicleChoosen = VehicleHash.Dominator6;
      return this.RequestModel(this.VehicleChoosen);
    }

    public void SetupModifications(Vehicle V)
    {
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) V.Handle, (InputArgument) 0);
      System.Random random = new System.Random();
      V.SetMod(VehicleMod.Exhaust, random.Next(0, 4), true);
      V.SetMod(VehicleMod.Grille, random.Next(0, 3), true);
      V.SetMod(VehicleMod.Frame, random.Next(0, 3), true);
      V.SetMod(VehicleMod.EngineBlock, random.Next(0, 4), true);
      V.SetMod(VehicleMod.ArchCover, random.Next(0, 3), true);
      V.SetMod(VehicleMod.Tank, random.Next(0, 2), true);
      V.SetMod(VehicleMod.Struts, random.Next(0, 3), true);
      V.SetMod(VehicleMod.AirFilter, random.Next(0, 3), true);
      V.SetMod(VehicleMod.Livery, random.Next(0, 17), true);
      Function.Call(Hash._0x6AF0636DDEDCB6DD, (InputArgument) V, (InputArgument) 44, (InputArgument) random.Next(0, 1), (InputArgument) true);
      V.PrimaryColor = this.GetColor();
      V.SecondaryColor = this.GetColor();
      V.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
      V.LightsOn = true;
      V.HighBeamsOn = true;
      int num = new System.Random().Next(1, 13);
      if (num == 1)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 1);
      if (num == 2)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 2);
      if (num == 3)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 3);
      if (num == 4)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 4);
      if (num == 5)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 5);
      if (num == 6)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 6);
      if (num == 7)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 7);
      if (num == 8)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 8);
      if (num == 9)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 9);
      if (num == 10)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 10);
      if (num == 11)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 11);
      if (num == 12)
        Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) 12);
      if (num != 13)
        return;
      Function.Call((Hash) 16433691881432431111, (InputArgument) V, (InputArgument) (int) byte.MaxValue);
    }

    public void SetupRivalCar(int i, Vehicle V)
    {
      Script.Wait(3);
      if (i == 0)
      {
        System.Random random1 = new System.Random();
        System.Random random2 = new System.Random();
        V.MaxSpeed = 400f;
        V.EngineTorqueMultiplier = (float) (random1.Next(15, 100) / 10);
        V.EnginePowerMultiplier = (float) (random2.Next(15, 100) / 10);
        this.SetupModifications(V);
      }
      if (i == 1)
      {
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) V.Handle, (InputArgument) 0);
        V.SetMod(VehicleMod.Spoilers, 0, true);
        V.SetMod(VehicleMod.FrontWheels, 4, true);
        V.PrimaryColor = VehicleColor.MetallicPurple;
        V.SecondaryColor = VehicleColor.MetallicPurple;
        V.PearlescentColor = VehicleColor.MetallicUltraBlue;
        V.SetMod(VehicleMod.Livery, 4, true);
        V.MaxSpeed = 400f;
        V.EngineTorqueMultiplier = 1.4f;
        V.EnginePowerMultiplier = 1.4f;
      }
      if (i == 2)
      {
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) V.Handle, (InputArgument) 0);
        V.SetMod(VehicleMod.Aerials, 10, true);
        V.SetMod(VehicleMod.AirFilter, 7, true);
        V.SetMod(VehicleMod.ArchCover, 5, true);
        V.SetMod(VehicleMod.Spoilers, 12, true);
        V.PrimaryColor = VehicleColor.BrushedAluminium;
        V.SecondaryColor = VehicleColor.BrushedAluminium;
        V.PearlescentColor = VehicleColor.MatteBlack;
        V.SetMod(VehicleMod.Livery, 3, true);
        V.MaxSpeed = 400f;
        V.EngineTorqueMultiplier = 2.2f;
        V.EnginePowerMultiplier = 2.4f;
      }
      if (i == 3)
      {
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) V.Handle, (InputArgument) 0);
        V.SetMod(VehicleMod.Hood, 4, true);
        V.PrimaryColor = VehicleColor.MetallicBlack;
        V.SecondaryColor = VehicleColor.Chrome;
        V.PearlescentColor = VehicleColor.MetallicBlack;
        V.MaxSpeed = 400f;
        V.EngineTorqueMultiplier = 5f;
        V.EnginePowerMultiplier = 5f;
      }
      if (i == 4)
      {
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) V.Handle, (InputArgument) 0);
        V.PrimaryColor = VehicleColor.MetallicTorinoRed;
        V.SecondaryColor = VehicleColor.MetallicTorinoRed;
        V.PearlescentColor = VehicleColor.MetallicBlack;
        V.MaxSpeed = 420f;
        V.EngineTorqueMultiplier = 2f;
        V.EnginePowerMultiplier = 2f;
      }
      if (i == 5)
      {
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) V.Handle, (InputArgument) 0);
        V.PrimaryColor = VehicleColor.MatteBlack;
        V.SecondaryColor = VehicleColor.MatteBlack;
        V.PearlescentColor = VehicleColor.MetallicBlack;
        V.SetMod(VehicleMod.Livery, 1, true);
        V.MaxSpeed = 420f;
        V.EngineTorqueMultiplier = 2.4f;
        V.EnginePowerMultiplier = 1.3f;
      }
      if (i != 6)
        return;
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) V.Handle, (InputArgument) 0);
      V.PrimaryColor = VehicleColor.MatteBlack;
      V.SecondaryColor = VehicleColor.MatteBlack;
      V.PearlescentColor = VehicleColor.MetallicBlack;
      V.SetMod(VehicleMod.Livery, 2, true);
      V.MaxSpeed = 420f;
      V.EngineTorqueMultiplier = 4f;
      V.EnginePowerMultiplier = 2.2f;
    }

    public void DeleteVehicleinPointtoPoint()
    {
      Game.Player.Money += (int) this.moneytobeawarded;
      Game.Player.Character.CurrentVehicle.Explode();
      Script.Wait(500);
      this.StartedRace = false;
      this.MissionSetup = false;
      this.Race = 0;
      if (this.VtoGetBlip != (Blip) null)
        this.VtoGetBlip.Remove();
      Script.Wait(200);
      UI.Notify(this.GetHostName() + " wow you just hit a mine, congrats on surviving for that long");
      Game.Player.Character.CurrentVehicle.Delete();
    }

    public void SetupDeathMatchCars()
    {
      if (this.VtoGetBlip != (Blip) null)
        this.VtoGetBlip.Remove();
      if (this.VtoGetBlip1 != (Blip) null)
        this.VtoGetBlip1.Remove();
      if (this.VtoGetBlip2 != (Blip) null)
        this.VtoGetBlip2.Remove();
      if (this.VtoGetBlip3 != (Blip) null)
        this.VtoGetBlip3.Remove();
      if ((Entity) this.VtoGet != (Entity) null)
        this.VtoGet.Delete();
      if ((Entity) this.VtoGet1 != (Entity) null)
        this.VtoGet1.Delete();
      if ((Entity) this.VtoGet2 != (Entity) null)
        this.VtoGet2.Delete();
      if ((Entity) this.VtoGet3 != (Entity) null)
        this.VtoGet3.Delete();
      Vector3 position1 = new Vector3(2736f, -3892f, 140f);
      Vector3 position2 = new Vector3(2866f, -3892f, 140f);
      Vector3 position3 = new Vector3(2865f, -3707f, 140f);
      Vector3 position4 = new Vector3(2732f, -3707f, 140f);
      Script.Wait(100);
      this.VtoGet = World.CreateVehicle(this.getVehicle(), position1, 10f);
      this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      Script.Wait(100);
      this.VtoGet1 = World.CreateVehicle(this.getVehicle(), position2, 10f);
      this.VtoGet1.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      Script.Wait(100);
      this.VtoGet2 = World.CreateVehicle(this.getVehicle(), position3, 10f);
      this.VtoGet2.Rotation = new Vector3(0.0f, 0.0f, 180f);
      Script.Wait(100);
      this.VtoGet3 = World.CreateVehicle(this.getVehicle(), position4, 10f);
      this.VtoGet3.Rotation = new Vector3(0.0f, 0.0f, 180f);
      this.SetupRivalCar(0, this.VtoGet);
      this.SetupRivalCar(0, this.VtoGet1);
      this.SetupRivalCar(0, this.VtoGet2);
      this.SetupRivalCar(0, this.VtoGet3);
      Script.Wait(50);
      Ped pedOnSeat1 = this.VtoGet.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat2 = this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat2, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat2, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat3 = this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat3, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat3, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat4 = this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat4, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat4, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Script.Wait(50);
      this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet1.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet2.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet3.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.Peds.Add(this.VtoGet.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver));
      Script.Wait(100);
      this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      Script.Wait(100);
      this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
      this.VtoGetBlip.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip, (InputArgument) 8);
      this.VtoGetBlip1 = World.CreateBlip(this.VtoGet1.Position);
      this.VtoGetBlip1.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip1, (InputArgument) 8);
      this.VtoGetBlip2 = World.CreateBlip(this.VtoGet2.Position);
      this.VtoGetBlip2.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip2, (InputArgument) 8);
      this.VtoGetBlip3 = World.CreateBlip(this.VtoGet3.Position);
      this.VtoGetBlip3.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip3, (InputArgument) 8);
    }

    public void SetupSkyWarsCars()
    {
      if (this.VtoGetBlip != (Blip) null)
        this.VtoGetBlip.Remove();
      if (this.VtoGetBlip1 != (Blip) null)
        this.VtoGetBlip1.Remove();
      if (this.VtoGetBlip2 != (Blip) null)
        this.VtoGetBlip2.Remove();
      if (this.VtoGetBlip3 != (Blip) null)
        this.VtoGetBlip3.Remove();
      if ((Entity) this.VtoGet != (Entity) null)
        this.VtoGet.Delete();
      if ((Entity) this.VtoGet1 != (Entity) null)
        this.VtoGet1.Delete();
      if ((Entity) this.VtoGet2 != (Entity) null)
        this.VtoGet2.Delete();
      if ((Entity) this.VtoGet3 != (Entity) null)
        this.VtoGet3.Delete();
      Vector3 position1 = new Vector3(-132f, -774f, 1005f);
      Vector3 position2 = new Vector3(-148f, -945f, 1005f);
      Vector3 position3 = new Vector3(14f, -944f, 1005f);
      Vector3 position4 = new Vector3(21f, -775f, 1005f);
      Script.Wait(100);
      this.VtoGet = World.CreateVehicle(this.getVehicle(), position1, 10f);
      this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, -180f);
      Script.Wait(100);
      this.VtoGet1 = World.CreateVehicle(this.getVehicle(), position2, 10f);
      this.VtoGet1.Rotation = new Vector3(0.0f, 0.0f, -180f);
      Script.Wait(100);
      this.VtoGet2 = World.CreateVehicle(this.getVehicle(), position3, 10f);
      this.VtoGet2.Rotation = new Vector3(0.0f, 0.0f, -180f);
      Script.Wait(100);
      this.VtoGet3 = World.CreateVehicle(this.getVehicle(), position4, 10f);
      this.VtoGet3.Rotation = new Vector3(0.0f, 0.0f, -180f);
      Script.Wait(100);
      this.SetupRivalCar(0, this.VtoGet);
      this.SetupRivalCar(0, this.VtoGet1);
      this.SetupRivalCar(0, this.VtoGet2);
      this.SetupRivalCar(0, this.VtoGet3);
      Script.Wait(50);
      Ped pedOnSeat1 = this.VtoGet.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat2 = this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat2, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat2, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat3 = this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat3, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat3, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat4 = this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat4, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat4, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Script.Wait(50);
      this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet1.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet2.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet3.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.Peds.Add(this.VtoGet.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver));
      Script.Wait(100);
      this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      Script.Wait(100);
      this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
      this.VtoGetBlip.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip, (InputArgument) 8);
      this.VtoGetBlip1 = World.CreateBlip(this.VtoGet1.Position);
      this.VtoGetBlip1.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip1, (InputArgument) 8);
      this.VtoGetBlip2 = World.CreateBlip(this.VtoGet2.Position);
      this.VtoGetBlip2.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip2, (InputArgument) 8);
      this.VtoGetBlip3 = World.CreateBlip(this.VtoGet3.Position);
      this.VtoGetBlip3.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip3, (InputArgument) 8);
    }

    public void SetupSkyWarsCars2()
    {
      if (this.VtoGetBlip4 != (Blip) null)
        this.VtoGetBlip4.Remove();
      if (this.VtoGetBlip5 != (Blip) null)
        this.VtoGetBlip5.Remove();
      if (this.VtoGetBlip6 != (Blip) null)
        this.VtoGetBlip6.Remove();
      if (this.VtoGetBlip7 != (Blip) null)
        this.VtoGetBlip7.Remove();
      if ((Entity) this.VtoGet4 != (Entity) null)
        this.VtoGet4.Delete();
      if ((Entity) this.VtoGet5 != (Entity) null)
        this.VtoGet5.Delete();
      if ((Entity) this.VtoGet6 != (Entity) null)
        this.VtoGet6.Delete();
      if ((Entity) this.VtoGet7 != (Entity) null)
        this.VtoGet7.Delete();
      Vector3 position1 = new Vector3(-122f, -774f, 1005f);
      Vector3 position2 = new Vector3(-138f, -945f, 1005f);
      Vector3 position3 = new Vector3(24f, -944f, 1005f);
      Vector3 position4 = new Vector3(31f, -775f, 1005f);
      Script.Wait(100);
      this.VtoGet4 = World.CreateVehicle(this.getVehicle(), position1, 10f);
      this.VtoGet4.Rotation = new Vector3(0.0f, 0.0f, -180f);
      Script.Wait(100);
      this.VtoGet5 = World.CreateVehicle(this.getVehicle(), position2, 10f);
      this.VtoGet5.Rotation = new Vector3(0.0f, 0.0f, -180f);
      Script.Wait(100);
      this.VtoGet6 = World.CreateVehicle(this.getVehicle(), position3, 10f);
      this.VtoGet6.Rotation = new Vector3(0.0f, 0.0f, -180f);
      Script.Wait(100);
      this.VtoGet7 = World.CreateVehicle(this.getVehicle(), position4, 10f);
      this.VtoGet7.Rotation = new Vector3(0.0f, 0.0f, -180f);
      Script.Wait(100);
      this.SetupRivalCar(0, this.VtoGet4);
      this.SetupRivalCar(0, this.VtoGet5);
      this.SetupRivalCar(0, this.VtoGet6);
      this.SetupRivalCar(0, this.VtoGet7);
      Script.Wait(100);
      this.VtoGet4.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet5.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet6.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet7.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.Peds.Add(this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver));
      Script.Wait(50);
      Ped pedOnSeat1 = this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat2 = this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat2, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat2, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat3 = this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat3, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat3, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat4 = this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat4, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat4, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Script.Wait(50);
      this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      Script.Wait(100);
      this.VtoGetBlip4 = World.CreateBlip(this.VtoGet4.Position);
      this.VtoGetBlip4.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip4, (InputArgument) 8);
      this.VtoGetBlip5 = World.CreateBlip(this.VtoGet5.Position);
      this.VtoGetBlip5.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip5, (InputArgument) 8);
      this.VtoGetBlip6 = World.CreateBlip(this.VtoGet6.Position);
      this.VtoGetBlip6.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip6, (InputArgument) 8);
      this.VtoGetBlip7 = World.CreateBlip(this.VtoGet7.Position);
      this.VtoGetBlip7.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip7, (InputArgument) 8);
    }

    public void SetupChampionchipCars(int I)
    {
      Vector3 position1 = new Vector3(2736f, -3892f, 140f);
      Vector3 position2 = new Vector3(2866f, -3892f, 140f);
      Vector3 position3 = new Vector3(2865f, -3707f, 140f);
      Vector3 vector3 = new Vector3(2732f, -3707f, 140f);
      if (I == 1)
      {
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        if (this.VtoGetBlip != (Blip) null)
          this.VtoGetBlip.Remove();
        this.VtoGet = World.CreateVehicle(this.getVehicle(), position1, 10f);
        this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
        this.SetupRivalCar(0, this.VtoGet);
        this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
        this.VtoGetBlip.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip, (InputArgument) 8);
        if (this.VtoGet.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 2)
      {
        if ((Entity) this.VtoGet1 != (Entity) null)
          this.VtoGet1.Delete();
        if (this.VtoGetBlip1 != (Blip) null)
          this.VtoGetBlip1.Remove();
        this.VtoGet1 = World.CreateVehicle(this.getVehicle(), position2, 10f);
        this.VtoGet1.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
        this.SetupRivalCar(0, this.VtoGet1);
        this.VtoGet1.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip1 = World.CreateBlip(this.VtoGet1.Position);
        this.VtoGetBlip1.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip1, (InputArgument) 8);
        if (this.VtoGet1.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet1.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet1.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 3)
      {
        if ((Entity) this.VtoGet2 != (Entity) null)
          this.VtoGet2.Delete();
        if (this.VtoGetBlip2 != (Blip) null)
          this.VtoGetBlip2.Remove();
        this.VtoGet2 = World.CreateVehicle(this.getVehicle(), position3, 10f);
        this.VtoGet2.Rotation = new Vector3(0.0f, 0.0f, 180f);
        this.SetupRivalCar(0, this.VtoGet2);
        this.VtoGet2.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip2 = World.CreateBlip(this.VtoGet2.Position);
        this.VtoGetBlip2.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip2, (InputArgument) 8);
        if (this.VtoGet2.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet2.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet2.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      this.moneytobeawarded += 75000f;
      ++this.checkpointReaced;
    }

    public void RespawnSkywarsCar(int I)
    {
      Vector3 position1 = new Vector3(-132f, -774f, 1005f);
      Vector3 position2 = new Vector3(-148f, -945f, 1005f);
      Vector3 position3 = new Vector3(14f, -944f, 1005f);
      Vector3 position4 = new Vector3(21f, -775f, 1005f);
      Vector3 position5 = new Vector3(-122f, -774f, 1005f);
      Vector3 position6 = new Vector3(-138f, -945f, 1005f);
      Vector3 position7 = new Vector3(24f, -944f, 1005f);
      Vector3 position8 = new Vector3(31f, -775f, 1005f);
      if (I == 1)
      {
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        if (this.VtoGetBlip != (Blip) null)
          this.VtoGetBlip.Remove();
        this.VtoGet = World.CreateVehicle(this.getVehicle(), position1, 10f);
        this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet);
        this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
        this.VtoGetBlip.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip, (InputArgument) 8);
        if (this.VtoGet.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 2)
      {
        if ((Entity) this.VtoGet1 != (Entity) null)
          this.VtoGet1.Delete();
        if (this.VtoGetBlip1 != (Blip) null)
          this.VtoGetBlip1.Remove();
        this.VtoGet1 = World.CreateVehicle(this.getVehicle(), position2, 10f);
        this.VtoGet1.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet1);
        this.VtoGet1.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip1 = World.CreateBlip(this.VtoGet1.Position);
        this.VtoGetBlip1.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip1, (InputArgument) 8);
        if (this.VtoGet1.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet1.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet1.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 3)
      {
        if ((Entity) this.VtoGet2 != (Entity) null)
          this.VtoGet2.Delete();
        if (this.VtoGetBlip2 != (Blip) null)
          this.VtoGetBlip2.Remove();
        this.VtoGet2 = World.CreateVehicle(this.getVehicle(), position3, 10f);
        this.VtoGet2.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet2);
        this.VtoGet2.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip2 = World.CreateBlip(this.VtoGet2.Position);
        this.VtoGetBlip2.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip2, (InputArgument) 8);
        if (this.VtoGet2.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet2.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet2.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 4)
      {
        if ((Entity) this.VtoGet3 != (Entity) null)
          this.VtoGet3.Delete();
        if (this.VtoGetBlip3 != (Blip) null)
          this.VtoGetBlip3.Remove();
        this.VtoGet3 = World.CreateVehicle(this.getVehicle(), position4, 10f);
        this.VtoGet3.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet3);
        this.VtoGet3.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip3 = World.CreateBlip(this.VtoGet3.Position);
        this.VtoGetBlip3.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip3, (InputArgument) 8);
        if (this.VtoGet3.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet3.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet3.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 4)
      {
        if ((Entity) this.VtoGet3 != (Entity) null)
          this.VtoGet3.Delete();
        if (this.VtoGetBlip3 != (Blip) null)
          this.VtoGetBlip3.Remove();
        this.VtoGet3 = World.CreateVehicle(this.getVehicle(), position4, 10f);
        this.VtoGet3.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet3);
        this.VtoGet3.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip3 = World.CreateBlip(this.VtoGet3.Position);
        this.VtoGetBlip3.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip3, (InputArgument) 8);
        if (this.VtoGet3.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet3.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet3.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 5)
      {
        if ((Entity) this.VtoGet4 != (Entity) null)
          this.VtoGet4.Delete();
        if (this.VtoGetBlip4 != (Blip) null)
          this.VtoGetBlip4.Remove();
        this.VtoGet4 = World.CreateVehicle(this.getVehicle(), position5, 10f);
        this.VtoGet4.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet4);
        this.VtoGet4.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip4 = World.CreateBlip(this.VtoGet4.Position);
        this.VtoGetBlip4.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip4, (InputArgument) 8);
        if (this.VtoGet4.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet4.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet4.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 6)
      {
        if ((Entity) this.VtoGet5 != (Entity) null)
          this.VtoGet5.Delete();
        if (this.VtoGetBlip5 != (Blip) null)
          this.VtoGetBlip5.Remove();
        this.VtoGet5 = World.CreateVehicle(this.getVehicle(), position6, 10f);
        this.VtoGet5.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet5);
        this.VtoGet5.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip5 = World.CreateBlip(this.VtoGet5.Position);
        this.VtoGetBlip5.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip4, (InputArgument) 8);
        if (this.VtoGet5.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet5.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet5.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 7)
      {
        if ((Entity) this.VtoGet6 != (Entity) null)
          this.VtoGet6.Delete();
        if (this.VtoGetBlip6 != (Blip) null)
          this.VtoGetBlip6.Remove();
        this.VtoGet6 = World.CreateVehicle(this.getVehicle(), position7, 10f);
        this.VtoGet6.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet6);
        this.VtoGet6.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip6 = World.CreateBlip(this.VtoGet6.Position);
        this.VtoGetBlip6.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip6, (InputArgument) 8);
        if (this.VtoGet6.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet6.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet6.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      if (I == 8)
      {
        if ((Entity) this.VtoGet7 != (Entity) null)
          this.VtoGet7.Delete();
        if (this.VtoGetBlip7 != (Blip) null)
          this.VtoGetBlip7.Remove();
        this.VtoGet7 = World.CreateVehicle(this.getVehicle(), position8, 10f);
        this.VtoGet7.Rotation = new Vector3(0.0f, 0.0f, -180f);
        this.SetupRivalCar(0, this.VtoGet7);
        this.VtoGet7.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
        Ped pedOnSeat = this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver);
        Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
        Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
        this.Peds.Add(this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver));
        this.VtoGetBlip7 = World.CreateBlip(this.VtoGet7.Position);
        this.VtoGetBlip7.Sprite = BlipSprite.GunCar;
        Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip7, (InputArgument) 8);
        if (this.VtoGet7.Model == (GTA.Model) VehicleHash.Deathbike)
          this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet7.Model == (GTA.Model) VehicleHash.Deathbike2)
          this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        if (this.VtoGet7.Model == (GTA.Model) VehicleHash.Deathbike3)
          this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).CanBeKnockedOffBike = false;
        this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      }
      this.moneytobeawarded += 25000f;
      ++this.checkpointReaced;
    }

    public void SetupDeathMatchCars2()
    {
      if (this.VtoGetBlip4 != (Blip) null)
        this.VtoGetBlip4.Remove();
      if (this.VtoGetBlip5 != (Blip) null)
        this.VtoGetBlip5.Remove();
      if (this.VtoGetBlip6 != (Blip) null)
        this.VtoGetBlip6.Remove();
      if (this.VtoGetBlip7 != (Blip) null)
        this.VtoGetBlip7.Remove();
      if ((Entity) this.VtoGet4 != (Entity) null)
        this.VtoGet4.Delete();
      if ((Entity) this.VtoGet5 != (Entity) null)
        this.VtoGet5.Delete();
      if ((Entity) this.VtoGet6 != (Entity) null)
        this.VtoGet6.Delete();
      if ((Entity) this.VtoGet7 != (Entity) null)
        this.VtoGet7.Delete();
      Vector3 position1 = new Vector3(2736f, -3892f, 140f);
      Vector3 position2 = new Vector3(2866f, -3892f, 140f);
      Vector3 position3 = new Vector3(2865f, -3707f, 140f);
      Vector3 position4 = new Vector3(2732f, -3707f, 140f);
      Script.Wait(100);
      this.VtoGet4 = World.CreateVehicle(this.getVehicle(), position1, 10f);
      this.VtoGet4.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      Script.Wait(100);
      this.VtoGet5 = World.CreateVehicle(this.getVehicle(), position2, 10f);
      this.VtoGet5.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      Script.Wait(100);
      this.VtoGet6 = World.CreateVehicle(this.getVehicle(), position3, 10f);
      this.VtoGet6.Rotation = new Vector3(0.0f, 0.0f, 180f);
      Script.Wait(100);
      this.VtoGet7 = World.CreateVehicle(this.getVehicle(), position4, 10f);
      this.VtoGet7.Rotation = new Vector3(0.0f, 0.0f, 180f);
      this.SetupRivalCar(0, this.VtoGet4);
      this.SetupRivalCar(0, this.VtoGet5);
      this.SetupRivalCar(0, this.VtoGet6);
      this.SetupRivalCar(0, this.VtoGet7);
      Script.Wait(100);
      this.VtoGet4.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet5.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet6.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet7.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.Peds.Add(this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver));
      Script.Wait(50);
      Ped pedOnSeat1 = this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat2 = this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat2, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat2, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat3 = this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat3, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat3, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat4 = this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat4, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat4, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Script.Wait(50);
      this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      Script.Wait(100);
      this.VtoGetBlip4 = World.CreateBlip(this.VtoGet4.Position);
      this.VtoGetBlip4.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip4, (InputArgument) 8);
      this.VtoGetBlip5 = World.CreateBlip(this.VtoGet5.Position);
      this.VtoGetBlip5.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip5, (InputArgument) 8);
      this.VtoGetBlip6 = World.CreateBlip(this.VtoGet6.Position);
      this.VtoGetBlip6.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip6, (InputArgument) 8);
      this.VtoGetBlip7 = World.CreateBlip(this.VtoGet7.Position);
      this.VtoGetBlip7.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip7, (InputArgument) 8);
    }

    public void SetRoof(Vehicle V)
    {
      int num = new System.Random().Next(1, 300);
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) V.Handle, (InputArgument) 0);
      if (num < 100)
        V.SetMod(VehicleMod.Roof, -1, true);
      if (num > 100 & num < 200)
        V.SetMod(VehicleMod.Roof, -1, true);
      if (!(num > 200 & num < 300))
        return;
      V.SetMod(VehicleMod.Roof, -1, true);
    }

    public void SetupBeastWarsCars()
    {
      if (this.VtoGetBlip != (Blip) null)
        this.VtoGetBlip.Remove();
      if (this.VtoGetBlip1 != (Blip) null)
        this.VtoGetBlip1.Remove();
      if (this.VtoGetBlip2 != (Blip) null)
        this.VtoGetBlip2.Remove();
      if (this.VtoGetBlip3 != (Blip) null)
        this.VtoGetBlip3.Remove();
      if ((Entity) this.VtoGet != (Entity) null)
        this.VtoGet.Delete();
      if ((Entity) this.VtoGet1 != (Entity) null)
        this.VtoGet1.Delete();
      if ((Entity) this.VtoGet2 != (Entity) null)
        this.VtoGet2.Delete();
      if ((Entity) this.VtoGet3 != (Entity) null)
        this.VtoGet3.Delete();
      if (this.VtoGetBlip4 != (Blip) null)
        this.VtoGetBlip4.Remove();
      if (this.VtoGetBlip5 != (Blip) null)
        this.VtoGetBlip5.Remove();
      if (this.VtoGetBlip6 != (Blip) null)
        this.VtoGetBlip6.Remove();
      if (this.VtoGetBlip7 != (Blip) null)
        this.VtoGetBlip7.Remove();
      if ((Entity) this.VtoGet4 != (Entity) null)
        this.VtoGet4.Delete();
      if ((Entity) this.VtoGet5 != (Entity) null)
        this.VtoGet5.Delete();
      if ((Entity) this.VtoGet6 != (Entity) null)
        this.VtoGet6.Delete();
      if ((Entity) this.VtoGet7 != (Entity) null)
        this.VtoGet7.Delete();
      Vector3 position1 = new Vector3(2736f, -3892f, 140f);
      Vector3 position2 = new Vector3(2866f, -3892f, 140f);
      Vector3 position3 = new Vector3(2865f, -3707f, 140f);
      Vector3 position4 = new Vector3(2732f, -3707f, 140f);
      this.VtoGet = World.CreateVehicle(this.getVehicle2(), position1);
      this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.SetupRivalCar(0, this.VtoGet);
      this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      this.VtoGet1 = World.CreateVehicle((GTA.Model) VehicleHash.TrailerSmall2, position1);
      this.VtoGet1.AttachTo((Entity) this.VtoGet, 0);
      this.VtoGet1.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet1.PrimaryColor = this.VtoGet.PrimaryColor;
      this.VtoGet1.SecondaryColor = this.VtoGet.SecondaryColor;
      this.VtoGet1.SetMod(VehicleMod.Roof, 0, true);
      this.VtoGet2 = World.CreateVehicle(this.getVehicle2(), position2);
      this.VtoGet2.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.SetupRivalCar(0, this.VtoGet2);
      this.VtoGet2.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      this.VtoGet3 = World.CreateVehicle((GTA.Model) VehicleHash.TrailerSmall2, position2);
      this.VtoGet3.AttachTo((Entity) this.VtoGet2, 0);
      this.VtoGet3.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet3.PrimaryColor = this.VtoGet2.PrimaryColor;
      this.VtoGet3.SecondaryColor = this.VtoGet2.SecondaryColor;
      this.VtoGet3.SetMod(VehicleMod.Roof, 0, true);
      this.VtoGet4 = World.CreateVehicle(this.getVehicle2(), position3);
      this.VtoGet4.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.SetupRivalCar(0, this.VtoGet4);
      this.VtoGet4.Rotation = new Vector3(0.0f, 0.0f, 180f);
      this.VtoGet5 = World.CreateVehicle((GTA.Model) VehicleHash.TrailerSmall2, position3);
      this.VtoGet5.AttachTo((Entity) this.VtoGet4, 0);
      this.VtoGet5.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet5.PrimaryColor = this.VtoGet4.PrimaryColor;
      this.VtoGet5.SecondaryColor = this.VtoGet4.SecondaryColor;
      this.VtoGet5.SetMod(VehicleMod.Roof, 0, true);
      this.VtoGet6 = World.CreateVehicle(this.getVehicle2(), position4);
      this.VtoGet6.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.SetupRivalCar(0, this.VtoGet6);
      this.VtoGet6.Rotation = new Vector3(0.0f, 0.0f, 180f);
      this.VtoGet7 = World.CreateVehicle((GTA.Model) VehicleHash.TrailerSmall2, position4);
      this.VtoGet7.AttachTo((Entity) this.VtoGet6, 0);
      this.VtoGet7.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet7.PrimaryColor = this.VtoGet6.PrimaryColor;
      this.VtoGet7.SecondaryColor = this.VtoGet6.SecondaryColor;
      this.VtoGet7.SetMod(VehicleMod.Roof, 0, true);
      this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.Peds.Add(this.VtoGet.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver));
      Ped pedOnSeat1 = this.VtoGet.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat2 = this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat2, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat2, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat3 = this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat3, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat3, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat4 = this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat4, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat4, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
      this.SetRoof(this.VtoGet1);
      this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
      this.SetRoof(this.VtoGet3);
      this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
      this.SetRoof(this.VtoGet5);
      this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).Task.VehicleChase(Game.Player.Character);
      this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
      this.SetRoof(this.VtoGet7);
      this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).IsInvincible = true;
      this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).IsInvincible = true;
      this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).IsInvincible = true;
      this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).IsInvincible = true;
      Script.Wait(100);
      this.VtoGetBlip4 = World.CreateBlip(this.VtoGet.Position);
      this.VtoGetBlip4.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip4, (InputArgument) 8);
      this.VtoGetBlip5 = World.CreateBlip(this.VtoGet2.Position);
      this.VtoGetBlip5.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip5, (InputArgument) 8);
      this.VtoGetBlip6 = World.CreateBlip(this.VtoGet4.Position);
      this.VtoGetBlip6.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip6, (InputArgument) 8);
      this.VtoGetBlip7 = World.CreateBlip(this.VtoGet6.Position);
      this.VtoGetBlip7.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip7, (InputArgument) 8);
    }

    public void SetupDeathMatchCars3()
    {
      if (this.VtoGetBlip4 != (Blip) null)
        this.VtoGetBlip4.Remove();
      if (this.VtoGetBlip5 != (Blip) null)
        this.VtoGetBlip5.Remove();
      if (this.VtoGetBlip6 != (Blip) null)
        this.VtoGetBlip6.Remove();
      if (this.VtoGetBlip7 != (Blip) null)
        this.VtoGetBlip7.Remove();
      if ((Entity) this.VtoGet4 != (Entity) null)
        this.VtoGet4.Delete();
      if ((Entity) this.VtoGet5 != (Entity) null)
        this.VtoGet5.Delete();
      if ((Entity) this.VtoGet6 != (Entity) null)
        this.VtoGet6.Delete();
      if ((Entity) this.VtoGet7 != (Entity) null)
        this.VtoGet7.Delete();
      Vector3 position1 = new Vector3(2736f, -3892f, 140f);
      Vector3 position2 = new Vector3(2866f, -3892f, 140f);
      Vector3 position3 = new Vector3(2865f, -3707f, 140f);
      Vector3 position4 = new Vector3(2732f, -3707f, 140f);
      Script.Wait(100);
      this.VtoGet4 = World.CreateVehicle((GTA.Model) VehicleHash.Panto, position1, 10f);
      this.VtoGet4.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      Script.Wait(100);
      this.VtoGet5 = World.CreateVehicle((GTA.Model) VehicleHash.Panto, position2, 10f);
      this.VtoGet5.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      Script.Wait(100);
      this.VtoGet6 = World.CreateVehicle((GTA.Model) VehicleHash.Panto, position3, 10f);
      this.VtoGet6.Rotation = new Vector3(0.0f, 0.0f, 180f);
      Script.Wait(100);
      this.VtoGet7 = World.CreateVehicle((GTA.Model) VehicleHash.Panto, position4, 10f);
      this.VtoGet7.Rotation = new Vector3(0.0f, 0.0f, 180f);
      this.SetupRivalCar(0, this.VtoGet4);
      this.SetupRivalCar(0, this.VtoGet5);
      this.SetupRivalCar(0, this.VtoGet6);
      this.SetupRivalCar(0, this.VtoGet7);
      Script.Wait(100);
      this.VtoGet4.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet5.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet6.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet7.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      Script.Wait(50);
      Ped pedOnSeat1 = this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat2 = this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat2, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat2, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat3 = this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat3, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat3, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat4 = this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat4, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat4, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Script.Wait(50);
      this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
      this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
      this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
      this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
      Script.Wait(100);
      this.VtoGetBlip4 = World.CreateBlip(this.VtoGet4.Position);
      this.VtoGetBlip4.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip4, (InputArgument) 8);
      this.VtoGetBlip5 = World.CreateBlip(this.VtoGet5.Position);
      this.VtoGetBlip5.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip5, (InputArgument) 8);
      this.VtoGetBlip6 = World.CreateBlip(this.VtoGet6.Position);
      this.VtoGetBlip6.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip6, (InputArgument) 8);
      this.VtoGetBlip7 = World.CreateBlip(this.VtoGet7.Position);
      this.VtoGetBlip7.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip7, (InputArgument) 8);
      this.Peds.Add(this.VtoGet4.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet5.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet6.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet7.GetPedOnSeat(VehicleSeat.Driver));
    }

    public void SetupDeathMatchCars4()
    {
      if (this.VtoGetBlip != (Blip) null)
        this.VtoGetBlip.Remove();
      if (this.VtoGetBlip1 != (Blip) null)
        this.VtoGetBlip1.Remove();
      if (this.VtoGetBlip2 != (Blip) null)
        this.VtoGetBlip2.Remove();
      if (this.VtoGetBlip3 != (Blip) null)
        this.VtoGetBlip3.Remove();
      if ((Entity) this.VtoGet != (Entity) null)
        this.VtoGet.Delete();
      if ((Entity) this.VtoGet1 != (Entity) null)
        this.VtoGet1.Delete();
      if ((Entity) this.VtoGet2 != (Entity) null)
        this.VtoGet2.Delete();
      if ((Entity) this.VtoGet3 != (Entity) null)
        this.VtoGet3.Delete();
      Vector3 position1 = new Vector3(2736f, -3892f, 140f);
      Vector3 position2 = new Vector3(2866f, -3892f, 140f);
      Vector3 position3 = new Vector3(2865f, -3707f, 140f);
      Vector3 position4 = new Vector3(2732f, -3707f, 140f);
      Script.Wait(100);
      this.VtoGet = World.CreateVehicle((GTA.Model) "RCBandito", position1, 10f);
      this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      Script.Wait(100);
      this.VtoGet1 = World.CreateVehicle((GTA.Model) "RCBandito", position2, 10f);
      this.VtoGet1.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
      Script.Wait(100);
      this.VtoGet2 = World.CreateVehicle((GTA.Model) "RCBandito", position3, 10f);
      this.VtoGet2.Rotation = new Vector3(0.0f, 0.0f, 180f);
      Script.Wait(100);
      this.VtoGet3 = World.CreateVehicle((GTA.Model) "RCBandito", position4, 10f);
      this.VtoGet3.Rotation = new Vector3(0.0f, 0.0f, 180f);
      this.SetupRivalCar(0, this.VtoGet);
      this.SetupRivalCar(0, this.VtoGet1);
      this.SetupRivalCar(0, this.VtoGet2);
      this.SetupRivalCar(0, this.VtoGet3);
      Script.Wait(50);
      Ped pedOnSeat1 = this.VtoGet.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat1, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat1, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat1, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat1, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat2 = this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat2, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat2, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat2, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat2, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat3 = this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat3, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat3, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat3, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat3, (InputArgument) 17, (InputArgument) 1);
      Ped pedOnSeat4 = this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver);
      Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat4, (InputArgument) true);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat4, (InputArgument) 1);
      Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat4, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat4, (InputArgument) 17, (InputArgument) 1);
      Script.Wait(50);
      this.VtoGet.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet1.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet2.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.VtoGet3.CreatePedOnSeat(VehicleSeat.Driver, this.RequestModel(PedHash.FreemodeMale01));
      this.Peds.Add(this.VtoGet.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver));
      this.Peds.Add(this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver));
      Script.Wait(100);
      this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
      this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
      this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
      this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(Game.Player.Character);
      Script.Wait(100);
      this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
      this.VtoGetBlip.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip, (InputArgument) 8);
      this.VtoGetBlip1 = World.CreateBlip(this.VtoGet1.Position);
      this.VtoGetBlip1.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip1, (InputArgument) 8);
      this.VtoGetBlip2 = World.CreateBlip(this.VtoGet2.Position);
      this.VtoGetBlip2.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip2, (InputArgument) 8);
      this.VtoGetBlip3 = World.CreateBlip(this.VtoGet3.Position);
      this.VtoGetBlip3.Sprite = BlipSprite.GunCar;
      Function.Call(Hash._0x03D7FB09E75D6B7E, (InputArgument) this.VtoGetBlip3, (InputArgument) 8);
      this.VtoGet.EngineTorqueMultiplier = 3f;
      this.VtoGet.EnginePowerMultiplier = 3f;
      this.VtoGet1.EngineTorqueMultiplier = 3f;
      this.VtoGet1.EnginePowerMultiplier = 3f;
      this.VtoGet2.EngineTorqueMultiplier = 3f;
      this.VtoGet2.EnginePowerMultiplier = 3f;
      this.VtoGet3.EngineTorqueMultiplier = 3f;
      this.VtoGet3.EnginePowerMultiplier = 3f;
    }

    public void ChangeMIneLoc(Vector3 CheckPoint)
    {
      Script.Wait(1);
      if (this.MissionId == 1)
      {
        if (this.Race == 4)
        {
          Vector3 origin1 = this.RandomLocationFun2();
          Script.Wait(10);
          Vector3 origin2 = this.RandomLocationFun2();
          Script.Wait(10);
          Vector3 origin3 = this.RandomLocationFun2();
          Script.Wait(10);
          Vector3 origin4 = this.RandomLocationFun2();
          Script.Wait(10);
          Vector3 origin5 = this.RandomLocationFun2();
          Script.Wait(10);
          Vector3 origin6 = this.RandomLocationFun2();
          if ((double) World.GetDistance(origin1, CheckPoint) < 10.0)
            this.MineLoc1 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin1, CheckPoint) > 10.0)
            this.MineLoc1 = origin1;
          if ((double) World.GetDistance(origin2, CheckPoint) < 10.0)
            this.MineLoc2 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin2, CheckPoint) > 10.0)
            this.MineLoc2 = origin2;
          if ((double) World.GetDistance(origin3, CheckPoint) < 10.0)
            this.MineLoc3 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin3, CheckPoint) > 10.0)
            this.MineLoc3 = origin3;
          if ((double) World.GetDistance(origin4, CheckPoint) < 10.0)
            this.MineLoc4 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin4, CheckPoint) > 10.0)
            this.MineLoc4 = origin4;
          if ((double) World.GetDistance(origin5, CheckPoint) < 10.0)
            this.MineLoc5 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin5, CheckPoint) > 10.0)
            this.MineLoc5 = origin5;
          if ((double) World.GetDistance(origin6, CheckPoint) < 10.0)
            this.MineLoc6 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin6, CheckPoint) > 10.0)
            this.MineLoc6 = origin6;
        }
        else if (this.Race == 6)
        {
          Vector3 origin1 = this.RandomLocationFun3();
          Script.Wait(10);
          Vector3 origin2 = this.RandomLocationFun3();
          Script.Wait(10);
          Vector3 origin3 = this.RandomLocationFun3();
          Script.Wait(10);
          Vector3 origin4 = this.RandomLocationFun3();
          Script.Wait(10);
          Vector3 origin5 = this.RandomLocationFun3();
          Script.Wait(10);
          Vector3 origin6 = this.RandomLocationFun3();
          if ((double) World.GetDistance(origin1, CheckPoint) < 10.0)
            this.MineLoc1 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin1, CheckPoint) > 10.0)
            this.MineLoc1 = origin1;
          if ((double) World.GetDistance(origin2, CheckPoint) < 10.0)
            this.MineLoc2 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin2, CheckPoint) > 10.0)
            this.MineLoc2 = origin2;
          if ((double) World.GetDistance(origin3, CheckPoint) < 10.0)
            this.MineLoc3 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin3, CheckPoint) > 10.0)
            this.MineLoc3 = origin3;
          if ((double) World.GetDistance(origin4, CheckPoint) < 10.0)
            this.MineLoc4 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin4, CheckPoint) > 10.0)
            this.MineLoc4 = origin4;
          if ((double) World.GetDistance(origin5, CheckPoint) < 10.0)
            this.MineLoc5 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin5, CheckPoint) > 10.0)
            this.MineLoc5 = origin5;
          if ((double) World.GetDistance(origin6, CheckPoint) < 10.0)
            this.MineLoc6 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin6, CheckPoint) > 10.0)
            this.MineLoc6 = origin6;
        }
        if (this.Race == 7)
        {
          Vector3 origin1 = this.RandomLocationFun4();
          Script.Wait(10);
          Vector3 origin2 = this.RandomLocationFun4();
          Script.Wait(10);
          Vector3 origin3 = this.RandomLocationFun4();
          Script.Wait(10);
          Vector3 origin4 = this.RandomLocationFun4();
          Script.Wait(10);
          Vector3 origin5 = this.RandomLocationFun4();
          Script.Wait(10);
          Vector3 origin6 = this.RandomLocationFun4();
          if ((double) World.GetDistance(origin1, CheckPoint) < 10.0)
            this.MineLoc1 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin1, CheckPoint) > 10.0)
            this.MineLoc1 = origin1;
          if ((double) World.GetDistance(origin2, CheckPoint) < 10.0)
            this.MineLoc2 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin2, CheckPoint) > 10.0)
            this.MineLoc2 = origin2;
          if ((double) World.GetDistance(origin3, CheckPoint) < 10.0)
            this.MineLoc3 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin3, CheckPoint) > 10.0)
            this.MineLoc3 = origin3;
          if ((double) World.GetDistance(origin4, CheckPoint) < 10.0)
            this.MineLoc4 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin4, CheckPoint) > 10.0)
            this.MineLoc4 = origin4;
          if ((double) World.GetDistance(origin5, CheckPoint) < 10.0)
            this.MineLoc5 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin5, CheckPoint) > 10.0)
            this.MineLoc5 = origin5;
          if ((double) World.GetDistance(origin6, CheckPoint) < 10.0)
            this.MineLoc6 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin6, CheckPoint) > 10.0)
            this.MineLoc6 = origin6;
        }
        if (this.Race == 8)
        {
          Vector3 origin1 = this.RandomLocationFun5();
          Script.Wait(10);
          Vector3 origin2 = this.RandomLocationFun5();
          Script.Wait(10);
          Vector3 origin3 = this.RandomLocationFun5();
          Script.Wait(10);
          Vector3 origin4 = this.RandomLocationFun5();
          Script.Wait(10);
          Vector3 origin5 = this.RandomLocationFun5();
          Script.Wait(10);
          Vector3 origin6 = this.RandomLocationFun5();
          if ((double) World.GetDistance(origin1, CheckPoint) < 10.0)
            this.MineLoc1 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin1, CheckPoint) > 10.0)
            this.MineLoc1 = origin1;
          if ((double) World.GetDistance(origin2, CheckPoint) < 10.0)
            this.MineLoc2 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin2, CheckPoint) > 10.0)
            this.MineLoc2 = origin2;
          if ((double) World.GetDistance(origin3, CheckPoint) < 10.0)
            this.MineLoc3 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin3, CheckPoint) > 10.0)
            this.MineLoc3 = origin3;
          if ((double) World.GetDistance(origin4, CheckPoint) < 10.0)
            this.MineLoc4 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin4, CheckPoint) > 10.0)
            this.MineLoc4 = origin4;
          if ((double) World.GetDistance(origin5, CheckPoint) < 10.0)
            this.MineLoc5 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin5, CheckPoint) > 10.0)
            this.MineLoc5 = origin5;
          if ((double) World.GetDistance(origin6, CheckPoint) < 10.0)
            this.MineLoc6 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin6, CheckPoint) > 10.0)
            this.MineLoc6 = origin6;
        }
        if (this.Race == 9)
        {
          Vector3 origin1 = this.RandomLocationFun6();
          Script.Wait(10);
          Vector3 origin2 = this.RandomLocationFun6();
          Script.Wait(10);
          Vector3 origin3 = this.RandomLocationFun6();
          Script.Wait(10);
          Vector3 origin4 = this.RandomLocationFun6();
          Script.Wait(10);
          Vector3 origin5 = this.RandomLocationFun6();
          Script.Wait(10);
          Vector3 origin6 = this.RandomLocationFun6();
          if ((double) World.GetDistance(origin1, CheckPoint) < 10.0)
            this.MineLoc1 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin1, CheckPoint) > 10.0)
            this.MineLoc1 = origin1;
          if ((double) World.GetDistance(origin2, CheckPoint) < 10.0)
            this.MineLoc2 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin2, CheckPoint) > 10.0)
            this.MineLoc2 = origin2;
          if ((double) World.GetDistance(origin3, CheckPoint) < 10.0)
            this.MineLoc3 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin3, CheckPoint) > 10.0)
            this.MineLoc3 = origin3;
          if ((double) World.GetDistance(origin4, CheckPoint) < 10.0)
            this.MineLoc4 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin4, CheckPoint) > 10.0)
            this.MineLoc4 = origin4;
          if ((double) World.GetDistance(origin5, CheckPoint) < 10.0)
            this.MineLoc5 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin5, CheckPoint) > 10.0)
            this.MineLoc5 = origin5;
          if ((double) World.GetDistance(origin6, CheckPoint) < 10.0)
            this.MineLoc6 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin6, CheckPoint) > 10.0)
            this.MineLoc6 = origin6;
        }
        if (this.Race == 10)
        {
          Vector3 origin1 = this.RandomLocationFun7();
          Script.Wait(10);
          Vector3 origin2 = this.RandomLocationFun7();
          Script.Wait(10);
          Vector3 origin3 = this.RandomLocationFun7();
          Script.Wait(10);
          Vector3 origin4 = this.RandomLocationFun7();
          Script.Wait(10);
          Vector3 origin5 = this.RandomLocationFun7();
          Script.Wait(10);
          Vector3 origin6 = this.RandomLocationFun7();
          if ((double) World.GetDistance(origin1, CheckPoint) < 10.0)
            this.MineLoc1 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin1, CheckPoint) > 10.0)
            this.MineLoc1 = origin1;
          if ((double) World.GetDistance(origin2, CheckPoint) < 10.0)
            this.MineLoc2 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin2, CheckPoint) > 10.0)
            this.MineLoc2 = origin2;
          if ((double) World.GetDistance(origin3, CheckPoint) < 10.0)
            this.MineLoc3 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin3, CheckPoint) > 10.0)
            this.MineLoc3 = origin3;
          if ((double) World.GetDistance(origin4, CheckPoint) < 10.0)
            this.MineLoc4 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin4, CheckPoint) > 10.0)
            this.MineLoc4 = origin4;
          if ((double) World.GetDistance(origin5, CheckPoint) < 10.0)
            this.MineLoc5 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin5, CheckPoint) > 10.0)
            this.MineLoc5 = origin5;
          if ((double) World.GetDistance(origin6, CheckPoint) < 10.0)
            this.MineLoc6 = new Vector3(0.0f, 0.0f, 0.0f);
          else if ((double) World.GetDistance(origin6, CheckPoint) > 10.0)
            this.MineLoc6 = origin6;
        }
      }
      if (this.MissionId != 2)
        return;
      if (this.Race == 2)
      {
        Vector3 origin1 = this.RandomLocationFun2();
        Script.Wait(10);
        Vector3 origin2 = this.RandomLocationFun2();
        Script.Wait(10);
        Vector3 origin3 = this.RandomLocationFun2();
        Script.Wait(10);
        Vector3 origin4 = this.RandomLocationFun2();
        Script.Wait(10);
        Vector3 origin5 = this.RandomLocationFun2();
        Script.Wait(10);
        Vector3 origin6 = this.RandomLocationFun2();
        if ((double) World.GetDistance(origin1, CheckPoint) < 10.0)
          this.MineLoc1 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin1, CheckPoint) > 10.0)
          this.MineLoc1 = origin1;
        if ((double) World.GetDistance(origin2, CheckPoint) < 10.0)
          this.MineLoc2 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin2, CheckPoint) > 10.0)
          this.MineLoc2 = origin2;
        if ((double) World.GetDistance(origin3, CheckPoint) < 10.0)
          this.MineLoc3 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin3, CheckPoint) > 10.0)
          this.MineLoc3 = origin3;
        if ((double) World.GetDistance(origin4, CheckPoint) < 10.0)
          this.MineLoc4 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin4, CheckPoint) > 10.0)
          this.MineLoc4 = origin4;
        if ((double) World.GetDistance(origin5, CheckPoint) < 10.0)
          this.MineLoc5 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin5, CheckPoint) > 10.0)
          this.MineLoc5 = origin5;
        if ((double) World.GetDistance(origin6, CheckPoint) < 10.0)
          this.MineLoc6 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin6, CheckPoint) > 10.0)
          this.MineLoc6 = origin6;
      }
      else if (this.Race == 1)
      {
        Vector3 origin1 = this.RandomLocationFun3();
        Script.Wait(10);
        Vector3 origin2 = this.RandomLocationFun3();
        Script.Wait(10);
        Vector3 origin3 = this.RandomLocationFun3();
        Script.Wait(10);
        Vector3 origin4 = this.RandomLocationFun3();
        Script.Wait(10);
        Vector3 origin5 = this.RandomLocationFun3();
        Script.Wait(10);
        Vector3 origin6 = this.RandomLocationFun3();
        if ((double) World.GetDistance(origin1, CheckPoint) < 10.0)
          this.MineLoc1 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin1, CheckPoint) > 10.0)
          this.MineLoc1 = origin1;
        if ((double) World.GetDistance(origin2, CheckPoint) < 10.0)
          this.MineLoc2 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin2, CheckPoint) > 10.0)
          this.MineLoc2 = origin2;
        if ((double) World.GetDistance(origin3, CheckPoint) < 10.0)
          this.MineLoc3 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin3, CheckPoint) > 10.0)
          this.MineLoc3 = origin3;
        if ((double) World.GetDistance(origin4, CheckPoint) < 10.0)
          this.MineLoc4 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin4, CheckPoint) > 10.0)
          this.MineLoc4 = origin4;
        if ((double) World.GetDistance(origin5, CheckPoint) < 10.0)
          this.MineLoc5 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin5, CheckPoint) > 10.0)
          this.MineLoc5 = origin5;
        if ((double) World.GetDistance(origin6, CheckPoint) < 10.0)
          this.MineLoc6 = new Vector3(0.0f, 0.0f, 0.0f);
        else if ((double) World.GetDistance(origin6, CheckPoint) > 10.0)
          this.MineLoc6 = origin6;
      }
    }

    public Ped ChooseTarget()
    {
      Ped closestPed = World.GetClosestPed(Game.Player.Character.Position, 1000f);
      if ((Entity) closestPed != (Entity) Game.Player.Character && (Entity) closestPed != (Entity) this.Friendlyped)
        closestPed = World.GetClosestPed(Game.Player.Character.Position, 1000f);
      return closestPed;
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

    private Vector2 World3DToScreen2d(Vector3 pos)
    {
      OutputArgument outputArgument1 = new OutputArgument();
      OutputArgument outputArgument2 = new OutputArgument();
      Function.Call<bool>(Hash._0x34E82F05DF2974F5, (InputArgument) pos.X, (InputArgument) pos.Y, (InputArgument) pos.Z, (InputArgument) outputArgument1, (InputArgument) outputArgument2);
      return new Vector2(outputArgument1.GetResult<float>(), outputArgument2.GetResult<float>());
    }

    private void drawSpriteRTA(
      string textureDict,
      string textureName,
      float screenX,
      float screenY,
      float width,
      float height,
      int r,
      int g,
      int b,
      int alpha,
      float Heading)
    {
      this.screenaspectratio = Function.Call<float>(Hash._0xF1307EF624A80D87, (InputArgument) true);
      float num = 1.778f / this.screenaspectratio;
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) textureDict, (InputArgument) 0);
      if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) textureDict))
        return;
      Function.Call(Hash._0xE7FFAE5EBF23D890, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) this.GetRatio(screenX), (InputArgument) screenY, (InputArgument) (width / 1280f * num), (InputArgument) (height / 1280f), (InputArgument) Heading, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha, (InputArgument) 0);
    }

    private void drawSpriteRTA2(
      string textureDict,
      string textureName,
      float screenX,
      float screenY,
      float width,
      float height,
      int r,
      int g,
      int b,
      int alpha,
      float Heading)
    {
      this.screenaspectratio = Function.Call<float>(Hash._0xF1307EF624A80D87, (InputArgument) true);
      float num = 1.778f / this.screenaspectratio;
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) textureDict, (InputArgument) 0);
      if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) textureDict))
        return;
      Function.Call(Hash._0xE7FFAE5EBF23D890, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) this.GetRatio(screenX), (InputArgument) screenY, (InputArgument) (width / 1280f * num), (InputArgument) (height / 1280f), (InputArgument) Heading, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha, (InputArgument) 0);
    }

    private void drawSpriteRTA3UV(
      string textureDict,
      string textureName,
      float screenX,
      float screenY,
      float width,
      float height,
      float x1,
      float y1,
      float x2,
      float y2,
      int r,
      int g,
      int b,
      int alpha,
      float Heading)
    {
      this.screenaspectratio = Function.Call<float>(Hash._0xF1307EF624A80D87, (InputArgument) true);
      float num = 1.778f / this.screenaspectratio;
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) textureDict, (InputArgument) 0);
      if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) textureDict))
        return;
      Function.Call((Hash) 10772944127051384614, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) this.GetRatio(screenX), (InputArgument) screenY, (InputArgument) (width / 1280f * num), (InputArgument) (height / 1280f), (InputArgument) x1, (InputArgument) y1, (InputArgument) x2, (InputArgument) y2, (InputArgument) Heading, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha);
    }

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
      int alpha,
      int alpha2)
    {
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) textureDict, (InputArgument) 0);
      if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) textureDict))
        return;
      Function.Call(Hash._0xE7FFAE5EBF23D890, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) screenX, (InputArgument) screenY, (InputArgument) width, (InputArgument) height, (InputArgument) 0, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha, (InputArgument) alpha2);
    }

    private void drawSprite2(
      string textureDict,
      string textureName,
      float screenX,
      float screenY,
      float width,
      float height,
      float r,
      int g,
      int b,
      int alpha,
      int alpha2)
    {
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) textureDict, (InputArgument) 0);
      if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) textureDict))
        return;
      Function.Call(Hash._0xE7FFAE5EBF23D890, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) screenX, (InputArgument) screenY, (InputArgument) width, (InputArgument) height, (InputArgument) 0, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha, (InputArgument) alpha2);
    }

    private void drawSprite3(
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
      this.screenaspectratio = Function.Call<float>(Hash._0xF1307EF624A80D87, (InputArgument) true);
      float num = 1.778f / this.screenaspectratio;
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) textureDict, (InputArgument) 0);
      if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) textureDict))
        return;
      Function.Call(Hash._0xE7FFAE5EBF23D890, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) this.GetRatio(screenX), (InputArgument) screenY, (InputArgument) (width / 1920f * num), (InputArgument) (height / 1920f), (InputArgument) 0, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha, (InputArgument) 0);
    }

    private void drawSprite4(
      string textureDict,
      string textureName,
      float screenX,
      float screenY,
      float width,
      float height,
      int r,
      int g,
      int b,
      int alpha,
      float heading)
    {
      this.screenaspectratio = Function.Call<float>(Hash._0xF1307EF624A80D87, (InputArgument) true);
      float num = 2.578f / this.screenaspectratio;
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) textureDict, (InputArgument) 0);
      if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) textureDict))
        return;
      Function.Call(Hash._0xE7FFAE5EBF23D890, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) this.GetRatio(screenX), (InputArgument) screenY, (InputArgument) (width / 1920f * num), (InputArgument) (height / 1920f), (InputArgument) heading, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha, (InputArgument) 0);
    }

    public float GetRatio(float num) => (float) (0.5 - (0.5 - (double) num) / (double) this.screenaspectratio);

    private void drawText(string text, float x, float y, float scale, int r, int g, int b)
    {
      Function.Call(Hash._0x25FBB336DF1804CB, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0xBE6B23FFA53FB442, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) (int) byte.MaxValue);
      Function.Call(Hash._0x07C837F9A01C34C9, (InputArgument) 0.0f, (InputArgument) scale);
      Function.Call(Hash._0xCD015E5BB0D96A57, (InputArgument) x, (InputArgument) y, (InputArgument) 0.1);
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

    public void OnTick(object sender, EventArgs e)
    {
      // ISSUE: The method is too long to display (63676 instructions)
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public void LoadDystopian_4()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Dystopian_02");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_04");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets");
      this.EffectOn = true;
      this.StartScreenEffect(1);
    }

    public void LoadDystopian_5()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Dystopian_02");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets");
      this.EffectOn = true;
      this.StartScreenEffect(1);
    }

    public void LoadDystopian_3()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Dystopian_04");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_03");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets");
      this.EffectOn = true;
      this.StartScreenEffect(1);
    }

    public void LoadDystopian_2()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Dystopian_04");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_02");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets");
      this.EffectOn = true;
      this.StartScreenEffect(1);
    }

    public void LoadDystopian_10()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Dystopian_04");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_10");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets");
      this.EffectOn = true;
      this.StartScreenEffect(1);
    }

    public void LoadDystopian_7()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Dystopian_04");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_07");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets");
      this.EffectOn = true;
      this.StartScreenEffect(1);
    }

    public void LoadDystopian_8()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Dystopian_04");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_08");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets");
      this.EffectOn = true;
      this.StartScreenEffect(1);
    }

    public void LoadDystopian_12()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Dystopian_04");
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_12");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Dystopian_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_dystopian_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets");
      this.EffectOn = true;
      this.StartScreenEffect(1);
    }

    public void LoadScifi_2()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_02");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_scifi_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_scifi");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    public void LoadScifi_4()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_04");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_scifi_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_scifi");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    public void LoadScifi_5()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_scifi_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_scifi");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    public void LoadScifi_10()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_10");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_scifi_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_scifi");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    public void LoadWasteland_2()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_02");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_CentreLine_Wasteland_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_wasteland");
      this.EffectOn = true;
      this.StartScreenEffect(3);
    }

    public void LoadScifi_9()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_09");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Scifi_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_centreline_scifi_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_scifi");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    public void LoadWasteland_9()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_09");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_CentreLine_Wasteland_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_wasteland");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    public void LoadWasteland_4()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_04");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_CentreLine_Wasteland_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_wasteland");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    public void LoadWasteland_5()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_CentreLine_Wasteland_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_wasteland");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    public void LoadWasteland_7()
    {
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
      int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
      Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
      for (int index = 0; index < this.NStadium.Count; ++index)
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) this.NStadium[index]);
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Crowd_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_a");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_b");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_c");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Team_band_d");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_07");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Wasteland_Scene");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_CentreLine_Wasteland_05");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "Set_Turrets_wasteland");
      this.EffectOn = true;
      this.StartScreenEffect(4);
    }

    private void FireGun(Vector3 Source, Ped Owner, Vector3 Target)
    {
      GTA.Model model = (GTA.Model) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "VEHICLE_WEAPON_TURRET_TECHNICAL");
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
    }

    private void FireMissile(Vector3 Source, Ped Owner, Vector3 Target)
    {
      GTA.Model model = (GTA.Model) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "WEAPON_AIRSTRIKE_ROCKET");
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
      World.ShootBullet(Source, Target, Game.Player.Character, model, 15000);
      World.ShootBullet(Source, Target, Game.Player.Character, model, 15000);
      World.ShootBullet(Source, Target, Game.Player.Character, model, 15000);
      UI.Notify("Firing missile");
    }

    private void FireMine(Vector3 Source, Ped Owner)
    {
      UI.Notify("player hit mine");
      GTA.Model model = (GTA.Model) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "VEHICLE_WEAPON_NOSE_TURRET_VALKYRIE");
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
      Vector3 targetPosition = Source;
      targetPosition.Z -= 5f;
      World.ShootBullet(Source, targetPosition, Owner, model, 25000);
    }

    private void FireTrap(Vector3 Source, Ped Owner)
    {
      UI.Notify("player hit Trap");
      GTA.Model model = (GTA.Model) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "DIR_FLAME_EXPLODE");
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
      Vector3 targetPosition = Source;
      targetPosition.Z -= 5f;
      World.ShootBullet(Source, targetPosition, Owner, model, 15000);
      World.ShootBullet(Source, targetPosition, Owner, model, 15000);
      World.ShootBullet(Source, targetPosition, Owner, model, 15000);
      World.ShootBullet(Source, targetPosition, Owner, model, 25000);
      World.ShootBullet(Source, targetPosition, Owner, model, 25000);
      World.ShootBullet(Source, targetPosition, Owner, model, 25000);
    }

    public void Firemissile()
    {
      int num = new System.Random().Next(1, 60);
      Ped ped = World.CreatePed((GTA.Model) PedHash.Fabien, new Vector3(0.0f, 0.0f, 0.0f), 90f);
      if (num < 10)
        this.FireMissile(new Vector3(2718f, -3870f, 154f), ped, Game.Player.Character.Position);
      if (num > 10 && num < 20)
        this.FireMissile(new Vector3(2629f, -3805f, 154f), ped, Game.Player.Character.Position);
      if (num > 20 && num < 30)
        this.FireMissile(new Vector3(2712f, -3717f, 154f), ped, Game.Player.Character.Position);
      if (num > 30 && num < 40)
        this.FireMissile(new Vector3(2884f, -3722f, 154f), ped, Game.Player.Character.Position);
      if (num > 40 && num < 50)
        this.FireMissile(new Vector3(2970f, -3799f, 154f), ped, Game.Player.Character.Position);
      if (num > 50 && num <= 60)
        this.FireMissile(new Vector3(2886f, -3883f, 154f), ped, Game.Player.Character.Position);
      ped.Delete();
    }

    public void Firemissile4_1()
    {
      int num1 = new System.Random().Next(1, 5);
      if (num1 == 1)
        this.TargettoFireAt = Game.Player.Character.Position;
      if (num1 == 2 && (Entity) this.VtoGet != (Entity) null)
        this.TargettoFireAt = this.VtoGet.Position;
      if (num1 == 3 && (Entity) this.VtoGet1 != (Entity) null)
        this.TargettoFireAt = this.VtoGet1.Position;
      if (num1 == 4 && (Entity) this.VtoGet2 != (Entity) null)
        this.TargettoFireAt = this.VtoGet2.Position;
      if (num1 == 5 && (Entity) this.VtoGet3 != (Entity) null)
        this.TargettoFireAt = this.VtoGet3.Position;
      Vector3 targettoFireAt = this.TargettoFireAt;
      if (false)
        return;
      int num2 = new System.Random().Next(1, 60);
      Ped ped = World.CreatePed((GTA.Model) PedHash.Fabien, new Vector3(0.0f, 0.0f, 0.0f), 90f);
      if (num2 < 10)
        this.FireMissile(new Vector3(2718f, -3870f, 154f), ped, this.TargettoFireAt);
      if (num2 > 10 && num2 < 20)
        this.FireMissile(new Vector3(2629f, -3805f, 154f), ped, this.TargettoFireAt);
      if (num2 > 20 && num2 < 30)
        this.FireMissile(new Vector3(2712f, -3717f, 154f), ped, this.TargettoFireAt);
      if (num2 > 30 && num2 < 40)
        this.FireMissile(new Vector3(2884f, -3722f, 154f), ped, this.TargettoFireAt);
      if (num2 > 40 && num2 < 50)
        this.FireMissile(new Vector3(2970f, -3799f, 154f), ped, this.TargettoFireAt);
      if (num2 > 50 && num2 <= 60)
        this.FireMissile(new Vector3(2886f, -3883f, 154f), ped, this.TargettoFireAt);
      ped.Delete();
    }

    public void Firemissile4_4()
    {
      System.Random random = new System.Random();
      int num1 = random.Next(1, 5);
      float distance = (float) random.Next(5, 20);
      if (num1 == 1)
        this.TargettoFireAt = Game.Player.Character.Position;
      if (num1 == 2 && (Entity) this.VtoGet != (Entity) null)
        this.TargettoFireAt = this.VtoGet.Position;
      if (num1 == 3 && (Entity) this.VtoGet1 != (Entity) null)
        this.TargettoFireAt = this.VtoGet1.Position;
      if (num1 == 4 && (Entity) this.VtoGet2 != (Entity) null)
        this.TargettoFireAt = this.VtoGet2.Position;
      if (num1 == 5 && (Entity) this.VtoGet3 != (Entity) null)
        this.TargettoFireAt = this.VtoGet3.Position;
      Vector3 targettoFireAt1 = this.TargettoFireAt;
      if (false)
        return;
      int num2 = new System.Random().Next(1, 60);
      Ped ped = World.CreatePed((GTA.Model) PedHash.Fabien, new Vector3(0.0f, 0.0f, 0.0f), 90f);
      if (num2 < 10)
      {
        Vector3 Source = new Vector3(2718f, -3870f, 154f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 10 && num2 < 20)
      {
        Vector3 Source = new Vector3(2629f, -3805f, 154f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 20 && num2 < 30)
      {
        Vector3 Source = new Vector3(2712f, -3717f, 154f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 30 && num2 < 40)
      {
        Vector3 Source = new Vector3(2884f, -3722f, 154f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 40 && num2 < 50)
      {
        Vector3 Source = new Vector3(2970f, -3799f, 154f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 50 && num2 <= 60)
      {
        Vector3 Source = new Vector3(2886f, -3883f, 154f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      ped.Delete();
    }

    public void Firemissile4_8()
    {
      System.Random random = new System.Random();
      int num1 = random.Next(1, 5);
      float distance = (float) random.Next(5, 20);
      if (num1 == 1)
        this.TargettoFireAt = Game.Player.Character.Position;
      if (num1 == 2 && (Entity) this.VtoGet != (Entity) null)
        this.TargettoFireAt = this.VtoGet.Position;
      if (num1 == 3 && (Entity) this.VtoGet1 != (Entity) null)
        this.TargettoFireAt = this.VtoGet1.Position;
      if (num1 == 4 && (Entity) this.VtoGet2 != (Entity) null)
        this.TargettoFireAt = this.VtoGet2.Position;
      if (num1 == 5 && (Entity) this.VtoGet3 != (Entity) null)
        this.TargettoFireAt = this.VtoGet3.Position;
      Vector3 targettoFireAt1 = this.TargettoFireAt;
      if (false)
        return;
      int num2 = new System.Random().Next(1, 60);
      Ped ped = World.CreatePed((GTA.Model) PedHash.Fabien, new Vector3(0.0f, 0.0f, 0.0f), 90f);
      if (num2 < 10)
      {
        Vector3 Source = new Vector3(-42f, -871f, 1014f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 10 && num2 < 20)
      {
        Vector3 Source = new Vector3(-42f, -871f, 1014f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 20 && num2 < 30)
      {
        Vector3 Source = new Vector3(-42f, -871f, 1014f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 30 && num2 < 40)
      {
        Vector3 Source = new Vector3(-42f, -871f, 1014f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 40 && num2 < 50)
      {
        Vector3 Source = new Vector3(-42f, -871f, 1014f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      if (num2 > 50 && num2 <= 60)
      {
        Vector3 Source = new Vector3(-42f, -871f, 1014f);
        Vector3 targettoFireAt2 = this.TargettoFireAt;
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
        Script.Wait(5);
        this.TargettoFireAt = targettoFireAt2.Around(distance);
        this.FireMissile(Source, ped, this.TargettoFireAt);
      }
      ped.Delete();
    }

    public void Firemissile4_12(Vector3 Pos, Vector3 FirePos)
    {
      System.Random random = new System.Random();
      random.Next(1, 5);
      float distance = (float) random.Next(2, 7);
      this.TargettoFireAt = Pos;
      Vector3 targettoFireAt1 = this.TargettoFireAt;
      if (false)
        return;
      new System.Random().Next(1, 60);
      Ped ped = World.CreatePed((GTA.Model) PedHash.Fabien, new Vector3(0.0f, 0.0f, 0.0f), 90f);
      Vector3 targettoFireAt2 = this.TargettoFireAt;
      this.TargettoFireAt = targettoFireAt2.Around(distance);
      this.FireGun(FirePos, ped, this.TargettoFireAt);
      this.TargettoFireAt = targettoFireAt2.Around(distance);
      this.FireGun(FirePos, ped, this.TargettoFireAt);
      this.TargettoFireAt = targettoFireAt2.Around(distance);
      this.FireGun(FirePos, ped, this.TargettoFireAt);
      this.TargettoFireAt = targettoFireAt2.Around(distance);
      this.FireGun(FirePos, ped, this.TargettoFireAt);
      ped.Delete();
    }

    public void Firemissile4_16()
    {
      System.Random random = new System.Random();
      random.Next(1, 5);
      float distance = (float) random.Next(1, 5);
      this.TargettoFireAt = Game.Player.Character.Position;
      Vector3 targettoFireAt = this.TargettoFireAt;
      if (false)
        return;
      new System.Random().Next(1, 60);
      Ped ped = World.CreatePed((GTA.Model) PedHash.Fabien, new Vector3(0.0f, 0.0f, 0.0f), 90f);
      Vector3 vector3_1 = new Vector3(2718f, -3870f, 154f);
      Vector3 vector3_2 = new Vector3(2629f, -3805f, 154f);
      Vector3 vector3_3 = new Vector3(2718f, -3870f, 154f);
      Vector3 vector3_4 = new Vector3(2884f, -3722f, 154f);
      Vector3 position = new Vector3(2970f, -3799f, 154f);
      Vector3 vector3_5 = new Vector3(2886f, -3883f, 154f);
      Vehicle[] nearbyVehicles1 = World.GetNearbyVehicles(vector3_1, 100f);
      Vehicle[] nearbyVehicles2 = World.GetNearbyVehicles(vector3_2, 100f);
      Vehicle[] nearbyVehicles3 = World.GetNearbyVehicles(vector3_3, 100f);
      Vehicle[] nearbyVehicles4 = World.GetNearbyVehicles(vector3_4, 100f);
      World.GetNearbyVehicles(position, 100f);
      Vehicle[] nearbyVehicles5 = World.GetNearbyVehicles(vector3_5, 100f);
      if ((uint) nearbyVehicles1.Length > 0U)
      {
        foreach (Entity entity in nearbyVehicles1)
        {
          if (entity != (Entity) null)
          {
            this.TargettoFireAt = this.TargettoFireAt.Around(distance);
            new System.Random().Next(0, nearbyVehicles1.Length - 1);
            Vector3 vector3_6 = vector3_1;
            vector3_6 = new Vector3(vector3_6.X, vector3_6.Y, vector3_6.Z + 5f);
            this.FireGun(vector3_1, ped, this.TargettoFireAt);
          }
        }
      }
      if ((uint) nearbyVehicles2.Length > 0U)
      {
        foreach (Entity entity in nearbyVehicles2)
        {
          if (entity != (Entity) null)
          {
            this.TargettoFireAt = this.TargettoFireAt.Around(distance);
            new System.Random().Next(0, nearbyVehicles2.Length - 1);
            Vector3 vector3_6 = vector3_2;
            vector3_6 = new Vector3(vector3_6.X, vector3_6.Y, vector3_6.Z + 5f);
            this.FireGun(vector3_2, ped, this.TargettoFireAt);
          }
        }
      }
      if ((uint) nearbyVehicles3.Length > 0U)
      {
        foreach (Entity entity in nearbyVehicles3)
        {
          if (entity != (Entity) null)
          {
            this.TargettoFireAt = this.TargettoFireAt.Around(distance);
            new System.Random().Next(0, nearbyVehicles3.Length - 1);
            Vector3 vector3_6 = vector3_3;
            vector3_6 = new Vector3(vector3_6.X, vector3_6.Y, vector3_6.Z + 5f);
            this.FireGun(vector3_3, ped, this.TargettoFireAt);
          }
        }
      }
      if ((uint) nearbyVehicles4.Length > 0U)
      {
        foreach (Entity entity in nearbyVehicles4)
        {
          if (entity != (Entity) null)
          {
            this.TargettoFireAt = this.TargettoFireAt.Around(distance);
            new System.Random().Next(0, nearbyVehicles4.Length - 1);
            Vector3 vector3_6 = vector3_4;
            vector3_6 = new Vector3(vector3_6.X, vector3_6.Y, vector3_6.Z + 5f);
            this.FireGun(vector3_4, ped, this.TargettoFireAt);
          }
        }
      }
      if ((uint) nearbyVehicles4.Length > 0U)
      {
        foreach (Entity entity in nearbyVehicles4)
        {
          if (entity != (Entity) null)
          {
            this.TargettoFireAt = this.TargettoFireAt.Around(distance);
            new System.Random().Next(0, nearbyVehicles4.Length - 1);
            Vector3 vector3_6 = vector3_4;
            vector3_6 = new Vector3(vector3_6.X, vector3_6.Y, vector3_6.Z + 5f);
            this.FireGun(vector3_4, ped, this.TargettoFireAt);
          }
        }
      }
      if ((uint) nearbyVehicles5.Length > 0U)
      {
        foreach (Entity entity in nearbyVehicles4)
        {
          if (entity != (Entity) null)
          {
            this.TargettoFireAt = this.TargettoFireAt.Around(distance);
            new System.Random().Next(0, nearbyVehicles5.Length - 1);
            Vector3 vector3_6 = vector3_5;
            vector3_6 = new Vector3(vector3_6.X, vector3_6.Y, vector3_6.Z + 5f);
            this.FireGun(vector3_5, ped, this.TargettoFireAt);
          }
        }
      }
      ped.Delete();
    }

    public void Firemissile8_1()
    {
      int num1 = new System.Random().Next(1, 9);
      if (num1 == 1)
        this.TargettoFireAt = Game.Player.Character.Position;
      if (num1 == 2 && (Entity) this.VtoGet != (Entity) null)
        this.TargettoFireAt = this.VtoGet.Position;
      if (num1 == 3 && (Entity) this.VtoGet1 != (Entity) null)
        this.TargettoFireAt = this.VtoGet1.Position;
      if (num1 == 4 && (Entity) this.VtoGet2 != (Entity) null)
        this.TargettoFireAt = this.VtoGet2.Position;
      if (num1 == 5 && (Entity) this.VtoGet3 != (Entity) null)
        this.TargettoFireAt = this.VtoGet3.Position;
      if (num1 == 6 && (Entity) this.VtoGet4 != (Entity) null)
        this.TargettoFireAt = this.VtoGet4.Position;
      if (num1 == 7 && (Entity) this.VtoGet5 != (Entity) null)
        this.TargettoFireAt = this.VtoGet5.Position;
      if (num1 == 8 && (Entity) this.VtoGet6 != (Entity) null)
        this.TargettoFireAt = this.VtoGet6.Position;
      if (num1 == 9 && (Entity) this.VtoGet7 != (Entity) null)
        this.TargettoFireAt = this.VtoGet7.Position;
      Vector3 targettoFireAt = this.TargettoFireAt;
      if (false)
        return;
      int num2 = new System.Random().Next(1, 60);
      Ped ped = World.CreatePed((GTA.Model) PedHash.Fabien, new Vector3(0.0f, 0.0f, 0.0f), 90f);
      if (num2 < 10)
        this.FireMissile(new Vector3(2718f, -3870f, 154f), ped, this.TargettoFireAt);
      if (num2 > 10 && num2 < 20)
        this.FireMissile(new Vector3(2629f, -3805f, 154f), ped, this.TargettoFireAt);
      if (num2 > 20 && num2 < 30)
        this.FireMissile(new Vector3(2712f, -3717f, 154f), ped, this.TargettoFireAt);
      if (num2 > 30 && num2 < 40)
        this.FireMissile(new Vector3(2884f, -3722f, 154f), ped, this.TargettoFireAt);
      if (num2 > 40 && num2 < 50)
        this.FireMissile(new Vector3(2970f, -3799f, 154f), ped, this.TargettoFireAt);
      if (num2 > 50 && num2 <= 60)
        this.FireMissile(new Vector3(2886f, -3883f, 154f), ped, this.TargettoFireAt);
      ped.Delete();
    }

    public void GetAJackPot()
    {
      int num = new System.Random().Next(1, 1500);
      if (num < 50)
      {
        Game.Player.Money += 1000000;
        UI.Notify(this.GetHostName() + " You won $1M Dollas!");
      }
      if (num > 50 && num <= 80)
      {
        this.CliqueBought = 1;
        this.Config.SetValue<int>("Vehicles", "CliqueBought", this.CliqueBought);
        UI.Notify(this.GetHostName() + " You won a Clique!");
      }
      if (num > 80 && num <= 120)
      {
        this.ItaligtoBought = 1;
        this.Config.SetValue<int>("Vehicles", "ItaligtoBought", this.ItaligtoBought);
        UI.Notify(this.GetHostName() + " You won a Itali GTO!");
      }
      if (num > 120 && num <= 170)
      {
        this.TulipBought = 1;
        this.Config.SetValue<int>("Vehicles", "TulipBought", this.TulipBought);
        UI.Notify(this.GetHostName() + " You won a Tulip");
      }
      if (num > 170 && num <= 220)
      {
        this.VamosBought = 1;
        this.Config.SetValue<int>("Vehicles", "VamosBought", this.VamosBought);
        UI.Notify(this.GetHostName() + " You won a Vamos");
      }
      if (num > 220 && num <= 240)
      {
        this.SchlagenBought = 1;
        this.Config.SetValue<int>("Vehicles", "SchlagenBought", this.SchlagenBought);
        UI.Notify(this.GetHostName() + " You won a Schlagen");
      }
      if (num > 240 && num <= 250)
      {
        this.DeviantBought = 1;
        this.Config.SetValue<int>("Vehicles", "DeviantBought", this.DeviantBought);
        UI.Notify(this.GetHostName() + " You won a Deviant!");
      }
      if (num > 250 && num <= 290)
      {
        this.TorosBought = 1;
        this.Config.SetValue<int>("Vehicles", "TorosBought", this.TorosBought);
        UI.Notify(this.GetHostName() + " You won a Toros!");
      }
      if (num > 290 && num <= 295)
      {
        this.DevesteBought = 1;
        this.Config.SetValue<int>("Vehicles", "DevesteBought", this.DevesteBought);
        UI.Notify(this.GetHostName() + " You won a Deveste!");
      }
      if (num > 295 && num <= 330)
      {
        this.stockscount *= 2;
        UI.Notify(this.GetHostName() + " You won Double current Stocks!");
      }
      if (num > 330 && num <= 350)
      {
        this.stockscount *= 3;
        UI.Notify(this.GetHostName() + " You won Tripple current Stocks!");
      }
      if (num > 350 && num <= 355)
      {
        this.stockscount *= 10;
        UI.Notify(this.GetHostName() + " You won 10x current Stocks!");
      }
      if (num > 355 && num <= 375)
      {
        Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 2939590305U, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
        UI.Notify(this.GetHostName() + " You won an Up-An-Atomizer!");
      }
      if (num > 375 && num <= 390)
      {
        Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 1198256469, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
        UI.Notify(this.GetHostName() + " You won an Unholy Hellbringer!");
      }
      if (num > 390 && num <= 400)
      {
        Function.Call(Hash._0xBF0FD6E56C964FCB, (InputArgument) Game.Player.Character, (InputArgument) 3056410471U, (InputArgument) 999999, (InputArgument) true, (InputArgument) true);
        UI.Notify(this.GetHostName() + " You won an Widow Maker!");
      }
      if (num > 390 && num <= 400)
      {
        this.FutureShockDominatorBought = 1;
        this.Config.SetValue<int>("Vehicles", "FutureShockDominatorBought", this.FutureShockDominatorBought);
        UI.Notify(this.GetHostName() + " You won a Future Shock Dominator!");
      }
      if (num > 400 && num <= 420)
      {
        this.ApocalypseZR380Bought = 1;
        this.Config.SetValue<int>("Vehicles", "ApocalypseZR380Bought", this.ApocalypseZR380Bought);
        UI.Notify(this.GetHostName() + " You won a Appocalypse ZR380!");
      }
      if (num > 420 && num <= 450)
      {
        this.NightmareImpalerBought = 1;
        this.Config.SetValue<int>("Vehicles", "NightmareImpalerBought", this.NightmareImpalerBought);
        UI.Notify(this.GetHostName() + " You won a Apocalypse ZR380!");
      }
      if (num > 450 && num <= 480)
      {
        this.NightmareImperatorBought = 1;
        this.Config.SetValue<int>("Vehicles", "NightmareImperatorBought", this.NightmareImperatorBought);
        UI.Notify(this.GetHostName() + " You won a Nightmare Imperator!");
      }
      if (num > 480 && num <= 500)
      {
        this.FutureShockMonsterBought = 1;
        this.Config.SetValue<int>("Vehicles", "FutureShockMonsterBought", this.FutureShockMonsterBought);
        UI.Notify(this.GetHostName() + " You won a Future Shock Sasquatch!");
      }
      if (num > 480 && num <= 540)
      {
        this.NightmareBruiserBought = 1;
        this.Config.SetValue<int>("Vehicles", "NightmareBruiserBought", this.NightmareBruiserBought);
        UI.Notify(this.GetHostName() + " You won a Nightmare Bruiser!");
      }
      if (num > 540 && num <= 580)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.AssaultrifleMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Assault Rifle MK2!");
      }
      if (num > 580 && num <= 600)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Carbine Rifle MK2!");
      }
      if (num > 600 && num <= 630)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Combat MG MK2!");
      }
      if (num > 630 && num <= 660)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.HeavySniperMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Heavy Sniper MK2!");
      }
      if (num > 630 && num <= 660)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.MarksmanRifleMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Marksman Rifle MK2!");
      }
      if (num > 660 && num <= 680)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.PumpShotgunMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Pump Shotgun MK2!");
      }
      if (num > 680 && num <= 710)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.RevolverMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Revolver MK2!");
      }
      if (num > 710 && num <= 740)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.SMGMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a SMG MK2!");
      }
      if (num > 740 && num <= 760)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.SpecialCarbineMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Special Carbine MK2!");
      }
      if (num > 760 && num <= 790)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.SNSPistolMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a SNS Pistol MK2!");
      }
      if (num > 790 && num <= 820)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.PistolMk2, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Pistol MK2!");
      }
      if (num > 820 && num <= 830)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.Minigun, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Minigun!");
      }
      if (num > 830 && num <= 850)
      {
        Game.Player.Character.Weapons.Give(WeaponHash.GrenadeLauncher, 9999, true, true);
        UI.Notify(this.GetHostName() + " You won a Grenade Launcher!");
      }
      if (num > 850 && num <= 870)
      {
        Game.Player.Character.Armor = Game.Player.MaxArmor;
        Game.Player.Character.Health = Game.Player.Character.MaxHealth;
        UI.Notify(this.GetHostName() + " You won a full health and armour!");
      }
      if (num > 870 && num <= 900)
      {
        Game.Player.Character.Health = Game.Player.Character.MaxHealth;
        UI.Notify(this.GetHostName() + " You won a full health!");
      }
      if (num > 900 && num <= 940)
      {
        Game.Player.Character.Armor = Game.Player.MaxArmor;
        UI.Notify(this.GetHostName() + " You won a full armour!");
      }
      if (num > 940 && num <= 960)
      {
        Game.Player.WantedLevel = 0;
        UI.Notify(this.GetHostName() + " You won a Police Bribe, Wanted level is now 0!");
      }
      if (num > 960 && num <= 1000)
      {
        this.FutureShockDeathbikeBought = 1;
        this.Config.SetValue<int>("Vehicles", "FutureShockDeathbikeBought", this.FutureShockDeathbikeBought);
        UI.Notify(this.GetHostName() + " You won a Future Shock Deathbike!");
      }
      else if (num > 1000)
        UI.Notify(this.GetHostName() + " You won a nothing...");
      UI.Notify("Prize : " + num.ToString());
      this.Config.Save();
    }

    public void StartScreenEffect(int Mission)
    {
      if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
        Function.Call(Hash._0x0F07E7745A236711);
      if (Mission == 1)
      {
        Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "MP_Arena_theme_sandstorm");
        Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) 1.15f);
        Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "MP_Arena_theme_sandstorm", (InputArgument) 0.8f);
      }
      if (Mission == 2)
      {
        Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "MP_Arena_theme_saccharine");
        Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) 1f);
        Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "MP_Arena_theme_saccharine", (InputArgument) 0.6f);
      }
      if (Mission == 3)
      {
        Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "MP_Arena_theme_hell");
        Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) 1f);
        Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "MP_Arena_theme_hell", (InputArgument) 0.6f);
      }
      if (Mission != 4)
        return;
      Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "MP_Arena_theme_atlantis");
      Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) 1f);
      Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "MP_Arena_theme_atlantis", (InputArgument) 0.6f);
    }

    public void StopScreenEffects()
    {
      Function.Call(Hash._0x0F07E7745A236711);
      Function.Call(Hash._0x3C8938D7D872211E);
      Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "default");
    }

    private void OnKeyDown()
    {
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MoneyStorageMarker) < 2.0 && (this.Config.GetValue<int>("Setup", "MoneyVaultBought", this.MoneyVaultBought) == 1 && !this.MVmainMenu.Visible))
        this.MVmainMenu.Visible = !this.MVmainMenu.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.Config.GetValue<int>("Setup", "GunLockerBought", this.GunLockerBought) == 1 && ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 2.0 && !this.GLmainMenu.Visible))
        this.GLmainMenu.Visible = !this.GLmainMenu.Visible;
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Marker) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context) && !this.EImainMenu.Visible)
        this.EImainMenu.Visible = !this.EImainMenu.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.EnterGarageMarker) < 2.0 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        if (!this.PlayerGaragemainMenu.Visible)
          this.PlayerGaragemainMenu.Visible = !this.PlayerGarageMenu.Visible;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (double) World.GetDistance(Game.Player.Character.Position, this.EnterGarageMarker) < 2.0 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Game.FadeScreenOut(1500);
        Script.Wait(2500);
        Game.Player.Character.CurrentVehicle.FreezePosition = false;
        Game.Player.Character.CurrentVehicle.Position = new Vector3(205.6087f, 5179.986f, -90f);
        Game.Player.Character.CurrentVehicle.Heading = -90f;
        this.isModifingStockVehicle = true;
        Game.Player.Character.CurrentVehicle.FreezePosition = true;
        this.IsInInterior = true;
        Script.Wait(2500);
        Game.FadeScreenIn(1500);
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.isInGarage && (double) World.GetDistance(Game.Player.Character.Position, this.RemoveMarker) < 2.0)
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        if (!this.RemoveMenu.Visible)
          this.RemoveMenu.Visible = !this.RemoveMenu.Visible;
      }
      if (this.isInGarage)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot1.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot2.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot3.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot4.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot5.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot6.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot7.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot8.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot9.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
          if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
          {
            this.SC.LoadIniFile(this.path + "GarageA//Slot10.ini");
            this.SC.SaveWithoutDelete();
            UI.Notify("Alan Vehice Saved");
          }
        }
        if (Game.IsControlJustPressed(2, GTA.Control.Context) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
          {
            this.Vehicle1 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle1);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
          {
            this.Vehicle2 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle2);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
          {
            this.Vehicle3 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle3);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
          {
            this.Vehicle4 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle4);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
          {
            this.Vehicle5 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle5);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
          {
            this.Vehicle6 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle6);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
          {
            this.Vehicle7 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle7);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
          {
            this.Vehicle8 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle8);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
          {
            this.Vehicle9 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle9);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
          if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
          {
            this.Vehicle10 = (Vehicle) null;
            this.LoadCarinToRealWorld2(this.Vehicle10);
            this.DisplayHelpTextThisFrame("Press E to use this vehicle");
          }
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.EnterMarkerA) < 2.0)
      {
        this.GarageNum = "GarageA";
        this.DestoryCars();
        Game.Player.Character.Position = this.ExitMarker;
        this.CreateCars("GarageA");
        Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "imp_dt1_11_cargarage_b");
        Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "imp_dt1_11_cargarage_c");
      }
      if ((Entity) this.Clique != (Entity) null && this.Clique.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.Clique, "Clique");
      }
      if ((Entity) this.Italigto != (Entity) null && this.Italigto.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.Italigto, "Italigto");
      }
      if ((Entity) this.RcBandito != (Entity) null && this.RcBandito.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
            this.RcBandito.FreezePosition = false;
            this.isinsecondVehicleBay = false;
            this.LoadCarinToRealWorld(currentVehicle);
          }
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.RcBandito, "RcBandito");
      }
      if ((Entity) this.Tulip != (Entity) null && this.Tulip.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.Tulip, "Tulip");
      }
      if ((Entity) this.Vamos != (Entity) null && this.Vamos.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.Vamos, "Vamos");
      }
      if ((Entity) this.Schlagen != (Entity) null && this.Schlagen.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.Schlagen, "Schlagen");
      }
      if ((Entity) this.Deviant != (Entity) null && this.Deviant.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.Deviant, "Deviant");
      }
      if ((Entity) this.Toros != (Entity) null && this.Toros.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.Toros, "Toros");
      }
      if ((Entity) this.Deveste != (Entity) null && this.Deveste.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLocalcar("Car", this.Deveste, "Deveste");
      }
      if ((Entity) this.Cerberus != (Entity) null && this.Cerberus.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Cerberus.DisplayName == "cerberus")
            this.SaveLocalcar("1Apocalypse", this.Cerberus, "Cerberus");
          if (this.Cerberus.DisplayName == "cerberus3")
            this.SaveLocalcar("2NIghtmare", this.Cerberus, "Cerberus");
          if (this.Cerberus.DisplayName == "cerberus2")
            this.SaveLocalcar("3FutureShock", this.Cerberus, "Cerberus");
          UI.Notify(this.Cerberus.DisplayName);
        }
      }
      if ((Entity) this.Impaler != (Entity) null && this.Impaler.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Impaler.DisplayName == "IMPALER2")
            this.SaveLocalcar("1Apocalypse", this.Impaler, "Impaler");
          if (this.Impaler.DisplayName == "IMPALER4")
            this.SaveLocalcar("2NIghtmare", this.Impaler, "Impaler");
          if (this.Impaler.DisplayName == "IMPALER3")
            this.SaveLocalcar("3FutureShock", this.Impaler, "Impaler");
        }
      }
      if ((Entity) this.Issi != (Entity) null && this.Issi.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Issi.DisplayName == "ISSI4")
            this.SaveLocalcar("1Apocalypse", this.Issi, "Issi");
          if (this.Issi.DisplayName == "ISSI6")
            this.SaveLocalcar("2NIghtmare", this.Issi, "Issi");
          if (this.Issi.DisplayName == "ISSI5")
            this.SaveLocalcar("3FutureShock", this.Issi, "Issi");
        }
      }
      if ((Entity) this.Slamvan != (Entity) null && this.Slamvan.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Slamvan.DisplayName == "SLAMVAN4")
            this.SaveLocalcar("1Apocalypse", this.Slamvan, "Slamvan");
          if (this.Slamvan.DisplayName == "SLAMVAN6")
            this.SaveLocalcar("2NIghtmare", this.Slamvan, "Slamvan");
          if (this.Slamvan.DisplayName == "SLAMVAN5")
            this.SaveLocalcar("3FutureShock", this.Slamvan, "Slamvan");
        }
      }
      if ((Entity) this.Dominator != (Entity) null && this.Dominator.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Dominator.DisplayName == "DOMINATOR4")
            this.SaveLocalcar("1Apocalypse", this.Dominator, "Dominator");
          if (this.Dominator.DisplayName == "DOMINATOR6")
            this.SaveLocalcar("2NIghtmare", this.Dominator, "Dominator");
          if (this.Dominator.DisplayName == "DOMINATOR5")
            this.SaveLocalcar("3FutureShock", this.Dominator, "Dominator");
        }
      }
      if ((Entity) this.Deathbike != (Entity) null && this.Deathbike.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Deathbike.DisplayName == "DEATHBIKE")
            this.SaveLocalcar("1Apocalypse", this.Deathbike, "Deathbike");
          if (this.Deathbike.DisplayName == "DEATHBIKE3")
            this.SaveLocalcar("2NIghtmare", this.Deathbike, "Deathbike");
          if (this.Deathbike.DisplayName == "DEATHBIKE2")
            this.SaveLocalcar("3FutureShock", this.Deathbike, "Deathbike");
        }
      }
      if ((Entity) this.Imperator != (Entity) null && this.Imperator.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Imperator.DisplayName == "IMPERATOR")
            this.SaveLocalcar("1Apocalypse", this.Imperator, "Imperator");
          if (this.Imperator.DisplayName == "IMPERATOR3")
            this.SaveLocalcar("2NIghtmare", this.Imperator, "Imperator");
          if (this.Imperator.DisplayName == "IMPERATOR2")
            this.SaveLocalcar("3FutureShock", this.Imperator, "Imperator");
        }
      }
      if ((Entity) this.Monster != (Entity) null && this.Monster.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Monster.DisplayName == "MONSTER3")
            this.SaveLocalcar("1Apocalypse", this.Monster, "Monster");
          if (this.Monster.DisplayName == "MONSTER5")
            this.SaveLocalcar("2NIghtmare", this.Monster, "Monster");
          if (this.Monster.DisplayName == "MONSTER4")
            this.SaveLocalcar("3FutureShock", this.Monster, "Monster");
          UI.Notify(this.Monster.DisplayName);
        }
      }
      if ((Entity) this.Scarab != (Entity) null && this.Scarab.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Scarab.DisplayName == "SCARAB")
            this.SaveLocalcar("1Apocalypse", this.Scarab, "Scarab");
          if (this.Scarab.DisplayName == "SCARAB2")
            this.SaveLocalcar("3FutureShock", this.Scarab, "Scarab");
          if (this.Scarab.DisplayName == "SCARAB3")
            this.SaveLocalcar("2NIghtmare", this.Scarab, "Scarab");
        }
      }
      if ((Entity) this.Bruitus != (Entity) null && this.Bruitus.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Bruitus.DisplayName == "BRUTUS")
            this.SaveLocalcar("1Apocalypse", this.Bruitus, "Bruitus");
          if (this.Bruitus.DisplayName == "BRUTUS3")
            this.SaveLocalcar("2NIghtmare", this.Bruitus, "Bruitus");
          if (this.Bruitus.DisplayName == "BRUTUS2")
            this.SaveLocalcar("3FutureShock", this.Bruitus, "Bruitus");
        }
      }
      if ((Entity) this.ZR380 != (Entity) null && this.ZR380.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.ZR380.DisplayName == "ZR380")
            this.SaveLocalcar("1Apocalypse", this.ZR380, "ZR380");
          if (this.ZR380.DisplayName == "ZR3803")
            this.SaveLocalcar("2NIghtmare", this.ZR380, "ZR380");
          if (this.ZR380.DisplayName == "ZR3802")
            this.SaveLocalcar("3FutureShock", this.ZR380, "ZR380");
          UI.Notify("DN " + this.ZR380.DisplayName);
        }
      }
      if ((Entity) this.Bruiser != (Entity) null && this.Bruiser.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            this.LoadCarinToRealWorld(Game.Player.Character.CurrentVehicle);
        }
        else if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          if (this.Bruiser.DisplayName == "BRUISER")
            this.SaveLocalcar("1Apocalypse", this.Bruiser, "Bruiser");
          if (this.Bruiser.DisplayName == "BRUISER3")
            this.SaveLocalcar("2NIghtmare", this.Bruiser, "Bruiser");
          if (this.Bruiser.DisplayName == "BRUISER2")
            this.SaveLocalcar("3FutureShock", this.Bruiser, "Bruiser");
          UI.Notify("DN " + this.Bruiser.DisplayName);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.DrinkPos) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        Function.Call(Hash._0x142A02425FF02BD9, (InputArgument) Game.Player.Character, (InputArgument) "WORLD_HUMAN_DRINKING", (InputArgument) 1, (InputArgument) true);
        Script.Wait(9000);
        Game.Player.Character.Task.ClearAll();
        Game.Player.Character.Task.ClearAllImmediately();
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Sitpos) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if (!this.IsSitting)
        {
          int num1 = new System.Random().Next(0, 5);
          if (num1 == 0)
            this.SeatDict = "anim@amb@office@seating@male@var_a@base@";
          if (num1 == 1)
            this.SeatDict = "anim@amb@office@seating@male@var_b@base@";
          if (num1 == 2)
            this.SeatDict = "anim@amb@office@seating@male@var_c@base@";
          if (num1 == 3)
            this.SeatDict = "anim@amb@office@seating@male@var_d@base@";
          if (num1 == 4)
            this.SeatDict = "anim@amb@office@seating@male@var_e@base@";
          Script.Wait(100);
          Class1.LoadDict(this.SeatDict);
          if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) this.SeatDict))
          {
            this.CurrentPos = new Vector3(this.Sitpos.X, this.Sitpos.Y, this.Sitpos.Z + 1f);
            Game.Player.Character.Position = this.CurrentPos;
            Game.Player.Character.Heading = 180f;
            this.IsSitting = true;
            int num2 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) Game.Player.Character.Position.X, (InputArgument) Game.Player.Character.Position.Y, (InputArgument) (Game.Player.Character.Position.Z - 1.4f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) (Game.Player.Character.Rotation.Z - 180f), (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) Class1.LoadDict(this.SeatDict), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num2, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num2));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num2, (InputArgument) "enter", (InputArgument) Class1.LoadDict(this.SeatDict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          }
        }
        else if (this.IsSitting)
        {
          Script.Wait(100);
          Class1.LoadDict(this.SeatDict);
          if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) this.SeatDict))
          {
            this.CurrentPos = new Vector3(this.Sitpos.X, this.Sitpos.Y, this.Sitpos.Z - 1f);
            this.IsSitting = false;
            int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) Game.Player.Character.Position.X, (InputArgument) Game.Player.Character.Position.Y, (InputArgument) (Game.Player.Character.Position.Z - 0.6f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) (Game.Player.Character.Rotation.Z - 180f), (InputArgument) 2);
            Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) Class1.LoadDict(this.SeatDict), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
            Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "exit", (InputArgument) Class1.LoadDict(this.SeatDict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            Script.Wait(3000);
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.FreezePosition = false;
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.CharacterSwitchPos) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
          Game.Player.ChangeModel((GTA.Model) PedHash.Michael);
        else if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
          Game.Player.ChangeModel((GTA.Model) PedHash.Trevor);
        else if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
          Game.Player.ChangeModel((GTA.Model) PedHash.Franklin);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SleepPos) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
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
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.JackpotTable) < 3.0)
      {
        if (Game.Player.Money >= 250000)
        {
          Game.Player.Money -= 250000;
          UI.Notify("Rolling!");
          Vector3 pos = new Vector3(2796.08f, -3930.3f, 183f);
          int num = new System.Random().Next(1, 7);
          if (num == 1)
          {
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(3f, 2.8f, 2f), Color.Red);
            UI.Notify("1");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(3f, 2.8f, 2f), Color.Green);
            UI.Notify("2");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(3f, 2.8f, 2f), Color.Blue);
            UI.Notify("3");
            Script.Wait(400);
          }
          if (num == 2)
          {
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.DeepSkyBlue);
            UI.Notify("1");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Magenta);
            UI.Notify("2");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Yellow);
            UI.Notify("3");
            Script.Wait(400);
          }
          if (num == 3)
          {
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Violet);
            UI.Notify("1");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.LightBlue);
            UI.Notify("2");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Orange);
            UI.Notify("3");
            Script.Wait(400);
          }
          if (num == 4)
          {
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Orange);
            UI.Notify("1");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.LimeGreen);
            UI.Notify("2");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Magenta);
            UI.Notify("3");
            Script.Wait(400);
          }
          if (num == 5)
          {
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Red);
            UI.Notify("1");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.White);
            UI.Notify("2");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Blue);
            UI.Notify("3");
            Script.Wait(400);
          }
          if (num == 6)
          {
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Fuchsia);
            UI.Notify("1");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Gainsboro);
            UI.Notify("2");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.PapayaWhip);
            UI.Notify("3");
            Script.Wait(400);
          }
          if (num == 7)
          {
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.PeachPuff);
            UI.Notify("1");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Teal);
            UI.Notify("2");
            Script.Wait(400);
            World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, new Vector3(2.8f, 2.8f, 2f), Color.Indigo);
            UI.Notify("3");
            Script.Wait(400);
          }
          this.GetAJackPot();
        }
        else
          UI.Notify(this.GetHostName() + " Come on boss, stop trying to steal from the rich!");
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.GarageBMarkerOuside) < 2.0)
        {
          this.ReloadInterior();
          this.IsInInterior = false;
          this.DeleteVehicles();
          this.isinsecondVehicleBay = true;
          Game.Player.Character.Position = this.ExitMarker3;
          this.LoadVehicles2();
          this.Getcolor = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ArenaEntry) < 2.0)
        {
          this.ReloadInterior();
          this.IsInInterior = false;
          this.DeleteVehicles();
          Game.Player.Character.Position = this.ArenaExit;
          int num = new System.Random().Next(1, 13);
          if (num == 1)
            this.LoadDystopian_2();
          if (num == 2)
            this.LoadScifi_2();
          if (num == 3)
            this.LoadWasteland_2();
          if (num == 4)
            this.LoadWasteland_9();
          if (num == 5)
            this.LoadScifi_9();
          if (num == 6)
            this.LoadDystopian_3();
          if (num == 7)
            this.LoadDystopian_4();
          if (num == 8)
            this.LoadDystopian_10();
          if (num == 9)
            this.LoadDystopian_5();
          if (num == 10)
            this.LoadScifi_5();
          if (num == 11)
            this.LoadScifi_10();
          if (num == 12)
            this.LoadDystopian_7();
          if (num == 13)
            this.LoadWasteland_7();
        }
        else if ((double) World.GetDistance(Game.Player.Character.Position, this.ArenaExit) < 2.0)
        {
          this.ReloadInterior();
          this.DeleteVehicles();
          this.LoadVehicles();
          this.IsInInterior = true;
          this.isinsecondVehicleBay = false;
          this.isInGarage = false;
          Script.Wait(1);
          Game.Player.Character.Position = this.ArenaEntry;
          this.Getcolor = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.VipEntry) < 2.0)
        {
          this.ReloadInterior();
          this.IsInInterior = false;
          this.DeleteVehicles();
          if (!this.IsSpectatingMatch)
          {
            int num = new System.Random().Next(1, 13);
            if (num == 1)
              this.LoadDystopian_2();
            if (num == 2)
              this.LoadScifi_2();
            if (num == 3)
              this.LoadWasteland_2();
            if (num == 4)
              this.LoadWasteland_9();
            if (num == 5)
              this.LoadScifi_9();
            if (num == 6)
              this.LoadDystopian_3();
            if (num == 7)
              this.LoadDystopian_4();
            if (num == 8)
              this.LoadDystopian_10();
            if (num == 9)
              this.LoadDystopian_5();
            if (num == 10)
              this.LoadScifi_5();
            if (num == 11)
              this.LoadScifi_10();
            if (num == 12)
              this.LoadDystopian_7();
            if (num == 13)
              this.LoadWasteland_7();
            Game.Player.Character.Position = this.VipExit;
            Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_vip");
          }
          else
          {
            int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2782.99f, (InputArgument) -3898.15f, (InputArgument) 140f);
            Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num, (InputArgument) "Set_Pit_Fence_Oval");
            Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "set_wall_no_pit");
            Game.Player.Character.Position = this.VipExit;
            Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "xs_arena_interior_vip");
          }
        }
        else if ((double) World.GetDistance(Game.Player.Character.Position, this.VipExit) < 2.0)
        {
          this.ReloadInterior();
          this.DeleteVehicles();
          this.LoadVehicles();
          this.IsInInterior = true;
          this.isinsecondVehicleBay = false;
          this.isInGarage = false;
          Script.Wait(1);
          Game.Player.Character.Position = this.VipEntry;
          Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "xs_arena_interior_vip");
        }
        else if ((double) World.GetDistance(Game.Player.Character.Position, this.ArenaVehicleMenuMarker) < 2.0)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
          {
            Script.Wait(1);
            Game.Player.Character.Position = this.ArenaExit;
            int num = new System.Random().Next(1, 13);
            if (num == 1)
              this.LoadDystopian_2();
            if (num == 2)
              this.LoadScifi_2();
            if (num == 3)
              this.LoadWasteland_2();
            if (num == 4)
              this.LoadWasteland_9();
            if (num == 5)
              this.LoadScifi_9();
            if (num == 6)
              this.LoadDystopian_3();
            if (num == 7)
              this.LoadDystopian_4();
            if (num == 8)
              this.LoadDystopian_10();
            if (num == 9)
              this.LoadDystopian_5();
            if (num == 10)
              this.LoadScifi_5();
            if (num == 11)
              this.LoadScifi_10();
            if (num == 12)
              this.LoadDystopian_7();
            if (num == 13)
              this.LoadWasteland_7();
          }
          else if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            Game.Player.Character.CurrentVehicle.Position = this.ArenaExit;
            Game.Player.Character.Position = this.ArenaExit;
            int num = new System.Random().Next(1, 13);
            if (num == 1)
              this.LoadDystopian_2();
            if (num == 2)
              this.LoadScifi_2();
            if (num == 3)
              this.LoadWasteland_2();
            if (num == 4)
              this.LoadWasteland_9();
            if (num == 5)
              this.LoadScifi_9();
            if (num == 6)
              this.LoadDystopian_3();
            if (num == 7)
              this.LoadDystopian_4();
            if (num == 8)
              this.LoadDystopian_10();
            if (num == 9)
              this.LoadDystopian_5();
            if (num == 10)
              this.LoadScifi_5();
            if (num == 11)
              this.LoadScifi_10();
            if (num == 12)
              this.LoadDystopian_7();
            if (num == 13)
              this.LoadWasteland_7();
          }
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (double) World.GetDistance(Game.Player.Character.Position, new Vector3(-365f, -1871f, 19f)) < 2.0)
      {
        this.ReloadInterior();
        this.DeleteVehicles();
        this.isinsecondVehicleBay = false;
        Script.Wait(300);
        this.DestoryCars();
        Game.Player.Character.Position = this.EntryMarker;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (double) World.GetDistance(Game.Player.Character.Position, this.GarageAMarkerInside) < 2.0)
      {
        this.ReloadInterior();
        this.DeleteVehicles();
        this.IsInInterior = false;
        this.LoadVehicles();
        if (this.isinsecondVehicleBay)
          Game.Player.Character.Position = this.GarageBMarkerOuside;
        else if (this.isInGarage)
          Game.Player.Character.Position = this.GarageAMarkerOuside;
        this.DeleteVehicles();
        this.DestoryCars();
        this.isInGarage = true;
        this.isinsecondVehicleBay = false;
        this.Getcolor = false;
        this.IsInInterior = false;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker3) < 2.0)
      {
        if (this.isinsecondVehicleBay)
        {
          this.ReloadInterior();
          this.DeleteVehicles();
          this.LoadVehicles();
          this.IsInInterior = true;
          this.isinsecondVehicleBay = false;
          this.isInGarage = false;
          Game.Player.Character.Position = this.VehicleBayMarker;
          this.Getcolor = false;
        }
        if (this.isInGarage)
        {
          this.ReloadInterior();
          this.DeleteVehicles();
          this.DestoryCars();
          this.LoadVehicles();
          this.IsInInterior = true;
          this.isInGarage = false;
          Game.Player.Character.Position = this.SecondEntry;
          this.Getcolor = false;
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.StadiumUpperExit) < 2.0)
        {
          this.ReloadInterior();
          this.IsInInterior = false;
          this.DeleteVehicles();
          Game.Player.Character.Position = this.StadiumUpperEntry;
        }
        else if ((double) World.GetDistance(Game.Player.Character.Position, this.StadiumUpperEntry) < 2.0)
        {
          this.ReloadInterior();
          this.DeleteVehicles();
          this.LoadVehicles();
          this.IsInInterior = true;
          this.isinsecondVehicleBay = false;
          this.isInGarage = false;
          Script.Wait(1);
          Game.Player.Character.Position = this.StadiumUpperExit;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.SecondEntry) < 2.0)
        {
          this.ReloadInterior();
          this.IsInInterior = false;
          this.DeleteVehicles();
          this.isInGarage = true;
          Game.Player.Character.Position = this.ExitMarker3;
          Script.Wait(100);
          this.CreateCars("GarageA");
          this.Getcolor = false;
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.GarageEntry) < 2.0)
      {
        this.ReloadInterior();
        this.IsInInterior = false;
        this.DeleteVehicles();
        this.isInGarage = true;
        Game.Player.Character.Position = this.GarageAMarkerInside;
        Script.Wait(100);
        this.CreateCars("GarageA");
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.VehicleBayMarker) < 2.0)
      {
        this.ReloadInterior();
        this.IsInInterior = false;
        this.DeleteVehicles();
        this.isinsecondVehicleBay = true;
        Game.Player.Character.Position = this.ExitMarker3;
        this.LoadVehicles2();
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ArenaMenuMarker) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        if (!this.ArenaMainMenu.Visible)
          this.ArenaMainMenu.Visible = !this.ArenaMainMenu.Visible;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.GarageMenuSpawn) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        if (!this.GarageMenu.Visible)
          this.GarageMenu.Visible = !this.GarageMenu.Visible;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.RemoveMarker) < 2.0 && this.isinsecondVehicleBay && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        if (!this.GarageMenu2.Visible)
          this.GarageMenu2.Visible = !this.GarageMenu2.Visible;
      }
      if (this.Missionnum == 13 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(213f, -936f, 24f)) < 3.0)
          Game.Player.Character.Position = new Vector3(227f, -1001f, -99f);
        else if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(227f, -1001f, -99f)) < 4.0)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            Game.Player.Character.CurrentVehicle.Position = new Vector3(213f, -936f, 24f);
            Game.Player.Character.CurrentVehicle.Rotation = new Vector3(0.0f, 0.0f, -34f);
            Game.Player.WantedLevel = 2;
          }
          else
            Game.Player.Character.Position = new Vector3(213f, -936f, 24f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.MarkerEnter) < 3.0)
      {
        if (!Game.IsControlJustPressed(2, GTA.Control.Context))
          return;
        if (this.purchaselvl == 0)
        {
          if (Game.Player.Money >= 1000000)
          {
            this.DisplayHelpTextThisFrame("Press E to Purchase ARB ; $1,000,000");
            this.purchaselvl = 1;
            Game.Player.Money -= 1000000;
            this.Config.SetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
            this.Config.Save();
          }
        }
        else if (this.purchaselvl > 0)
        {
          if (Game.Player.WantedLevel < 1)
          {
            Game.FadeScreenOut(300);
            Script.Wait(300);
            Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
            int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
            Game.Player.Character.Position = this.MarkerExit;
            Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
            Script.Wait(300);
            Game.FadeScreenIn(300);
            this.IsInInterior = true;
            this.LoadVehicles();
          }
          else
          {
            this.DisplayHelpTextThisFrame("Lose the cops");
            UI.Notify(this.GetHostName() + " Please lose the cops boss");
          }
        }
      }
      else if ((double) World.GetDistance(Game.Player.Character.Position, this.MarkerExit) < 3.0)
      {
        if (!Game.IsControlJustPressed(2, GTA.Control.Context))
          return;
        Game.FadeScreenOut(300);
        Script.Wait(300);
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) this.Design);
        Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) -75.8466, (InputArgument) -826.9893, (InputArgument) 243.3859);
        Game.Player.Character.Position = this.MarkerEnter;
        Script.Wait(300);
        Game.FadeScreenIn(300);
        this.IsInInterior = false;
        this.DeleteVehicles();
      }
      else
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) >= 2.0 || !this.UseOldMarker || !Game.IsControlJustPressed(2, GTA.Control.Context))
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        if (!this.mainMenu.Visible)
          this.mainMenu.Visible = !this.mainMenu.Visible;
      }
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if ((Entity) this.ComputerProp != (Entity) null)
        this.ComputerProp.Delete();
      try
      {
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
      this.StopScreenEffects();
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      foreach (Vehicle vehicle in this.ExtraV)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      if ((Entity) this.SaveVehicle != (Entity) null)
        this.SaveVehicle.MarkAsNoLongerNeeded();
      foreach (Vehicle vehicle in this.VehiclestoCarryA)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      foreach (Vehicle vehicle in this.VehiclestoCarryB)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      foreach (Vehicle vehicle in this.VehiclestoCarryC)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      if (this.Peds.Count > 0)
      {
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
      }
      if ((Entity) this.PLayerVehicle2 != (Entity) null)
        this.PLayerVehicle2.Delete();
      if ((Entity) this.PLayerVehicle != (Entity) null)
        this.PLayerVehicle.Delete();
      if (this.EndPointBlip != (Blip) null)
        this.EndPointBlip.Remove();
      if ((Entity) this.PLayerVehicle != (Entity) null)
        this.PLayerVehicle.Delete();
      if (this.FinishLineBLip != (Blip) null)
        this.FinishLineBLip.Remove();
      if ((Entity) this.RcBandito != (Entity) null)
        this.RcBandito.Delete();
      if ((Entity) this.VehicleA != (Entity) null)
        this.VehicleA.Delete();
      if ((Entity) this.VehicleB != (Entity) null)
        this.VehicleB.Delete();
      if ((Entity) this.VehicleC != (Entity) null)
        this.VehicleC.Delete();
      if (this.FinishLineBLip != (Blip) null)
        this.FinishLineBLip.Remove();
      if (this.RaceBlip != (Blip) null)
        this.RaceBlip.Remove();
      if ((Entity) this.Italigto != (Entity) null)
        this.Italigto.Delete();
      if ((Entity) this.Deveste != (Entity) null)
        this.Deveste.Delete();
      if ((Entity) this.Deviant != (Entity) null)
        this.Deviant.Delete();
      if ((Entity) this.Toros != (Entity) null)
        this.Toros.Delete();
      if ((Entity) this.Schlagen != (Entity) null)
        this.Schlagen.Delete();
      if ((Entity) this.Vamos != (Entity) null)
        this.Vamos.Delete();
      if ((Entity) this.Tulip != (Entity) null)
        this.Tulip.Delete();
      if ((Entity) this.Clique != (Entity) null)
        this.Clique.Delete();
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
      if ((Entity) this.ZR380 != (Entity) null)
        this.ZR380.Delete();
      if ((Entity) this.Bruiser != (Entity) null)
        this.Bruiser.Delete();
      if (this.TowerBlip3 != (Blip) null)
        this.TowerBlip3.Remove();
      if (this.TowerBlip != (Blip) null)
        this.TowerBlip.Remove();
      if (this.TowerBlip2 != (Blip) null)
        this.TowerBlip2.Remove();
      if ((Entity) this.Bruitus != (Entity) null)
        this.Bruitus.Delete();
      if ((Entity) this.Bruitus != (Entity) null)
        this.Bruitus.Delete();
      if ((Entity) this.Impaler != (Entity) null)
        this.Impaler.Delete();
      if ((Entity) this.Slamvan != (Entity) null)
        this.Slamvan.Delete();
      if ((Entity) this.Issi != (Entity) null)
        this.Issi.Delete();
      if ((Entity) this.Monster != (Entity) null)
        this.Monster.Delete();
      if ((Entity) this.Dominator != (Entity) null)
        this.Dominator.Delete();
      if ((Entity) this.Cerberus != (Entity) null)
        this.Cerberus.Delete();
      if ((Entity) this.Scarab != (Entity) null)
        this.Scarab.Delete();
      if ((Entity) this.Imperator != (Entity) null)
        this.Imperator.Delete();
      if ((Entity) this.Deathbike != (Entity) null)
        this.Deathbike.Delete();
      if ((Entity) this.VtoGet != (Entity) null)
        this.VtoGet.Delete();
      if ((Entity) this.VtoGet1 != (Entity) null)
        this.VtoGet1.Delete();
      if ((Entity) this.VtoGet2 != (Entity) null)
        this.VtoGet2.Delete();
      if ((Entity) this.VtoGet3 != (Entity) null)
        this.VtoGet3.Delete();
      if ((Entity) this.VtoGet4 != (Entity) null)
        this.VtoGet4.Delete();
      if ((Entity) this.VtoGet5 != (Entity) null)
        this.VtoGet5.Delete();
      if ((Entity) this.VtoGet6 != (Entity) null)
        this.VtoGet6.Delete();
      if ((Entity) this.VtoGet7 != (Entity) null)
        this.VtoGet7.Delete();
      if (this.VtoGetBlip != (Blip) null)
        this.VtoGetBlip.Remove();
      if (this.VtoGetBlip1 != (Blip) null)
        this.VtoGetBlip1.Remove();
      if (this.VtoGetBlip2 != (Blip) null)
        this.VtoGetBlip2.Remove();
      if (this.VtoGetBlip3 != (Blip) null)
        this.VtoGetBlip3.Remove();
      if (this.VtoGetBlip4 != (Blip) null)
        this.VtoGetBlip4.Remove();
      if (this.VtoGetBlip5 != (Blip) null)
        this.VtoGetBlip5.Remove();
      if (this.VtoGetBlip6 != (Blip) null)
        this.VtoGetBlip6.Remove();
      if (this.VtoGetBlip7 != (Blip) null)
        this.VtoGetBlip7.Remove();
      if (this.DropzoneBlip != (Blip) null)
        this.DropzoneBlip.Remove();
      if ((Entity) this.RentedVehicle != (Entity) null)
        this.RentedVehicle.Delete();
    }
  }
}
