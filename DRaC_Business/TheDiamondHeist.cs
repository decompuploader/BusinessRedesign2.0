using GTA;
using GTA.Math;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DRaC_Business
{
  internal class TheDiamondHeist : Script
  {
    public bool RequestEndCutscene;
    public Keys GetinVehicleKey = Keys.Decimal;
    public Keys HoldPositionKey = Keys.OemBackslash;
    public float HTime;
    public Ped CutsenePed1;
    public Ped CutsenePed2;
    public Ped CutsenePed3;
    public Ped CutsenePed4;
    public bool PlayingCutscene;
    public List<Prop> Props = new List<Prop>();
    public Class1 Main = new Class1(false);
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    private MenuPool modMenuPool2;
    private UIMenu mainMenu2;
    private UIMenu Heists2;
    public bool CameraON;
    public Camera HeistStartCam;
    public PedHash RobberASkin;
    public PedHash RobberBSkin;
    public PedHash RobberCSkin;
    public bool MissionOn;
    public Blip Bank;
    public Vector3 FactoryPos = new Vector3(718f, -981f, 22f);
    public Vector3 FleecaBankMarker = new Vector3(-13.7145f, -687.805f, 32f);
    public Vector3 FleecaJammerSpawm = new Vector3(455f, -987f, 25f);
    public Vector3 FleecaJammerPos = new Vector3(-3.63722f, -687.673f, 15.1f);
    public Vector3 FleecaInsurgentSpawn = new Vector3(-1731.9f, 2838f, 33f);
    public Blip InsurgentBLip;
    public Vehicle Insurgent;
    public Vector3 FleecaKurumaSpawn = new Vector3(-13.62394f, -1067.724f, 38f);
    public Blip KurumaBlip;
    public Vehicle Kuruma;
    public Vector3 FleecaVaultDoor = new Vector3();
    public Vehicle Riot1;
    public Vehicle Riot2;
    public Vehicle Riot3;
    public Vehicle Riot4;
    public int VaultDoorTimer;
    public bool triggerPatrol;
    public Vehicle PatrolCar;
    public Vehicle PatrolCar1;
    public Vehicle PatrolCar2;
    public Ped TargetPed;
    public Vector3 PatrolCarDeletePos = new Vector3(515.366f, 83.88f, 95f);
    public bool PatrolCarEnitiated;
    public bool headingbacktofactory;
    public bool SecutingJammer;
    public bool returningtofactroy;
    public bool SecuringVehicle;
    public bool GotVehicle;
    public bool placedJammer;
    public string VehicleChoosen;
    public bool WaitingForVaultdoortoOpen;
    public int Waittime;
    public bool VaultOpen;
    public bool DefendingCops;
    public int timer;
    public bool escapingcops;
    public bool HeadingtoFactory;
    public bool TriggerUINotify;
    public Ped RobberA;
    public int RobberAskill;
    public Ped RobberB;
    public int RobberBskill;
    public Ped RobberC;
    public int RobberCskill;
    public int Hackerskill;
    public float TotalCost;
    public float HackerCost = 3500000f;
    public float TeamAI1Cost = 0.0f;
    public float TeamAI2Cost = 0.0f;
    public float TeamAI3Cost = 0.0f;
    public float TeamAI4Cost = 0.0f;
    public Vector3 DoorApos = new Vector3(233.12f, 215.95f, 105f);
    public Vector3 DoorBPos = new Vector3(259.755f, 204.6733f, 105f);
    public Vector3 DoorCPos = new Vector3(257.027f, 220.4003f, 105f);
    public Vector3 DoorDPos = new Vector3(261.93f, 221.79f, 105f);
    public bool DoorALocked;
    public bool DoorBLocked;
    public bool FoundKeyCard;
    public bool DoorCLocked;
    public bool DoorDLocked;
    public bool GotKeyCard;
    public Ped Manager;
    public bool LockedDoors;
    public bool CivsAreFreakingOut;
    public int TargetingTime;
    public Blip DoorAblip;
    public Blip DoorBblip;
    public Blip DoorCblip;
    public Blip DoorDblip;
    public bool CreatedBlips;
    public Vector3 DoorLoc;
    public Vector3 VaultLoc;
    public List<Ped> Tellers = new List<Ped>();
    public List<Ped> Civs = new List<Ped>();
    public List<Ped> Guards = new List<Ped>();
    public bool InHeist;
    public Prop VaultDoor;
    public int MaxPay;
    public int CurrentPay;
    public List<Ped> Peds = new List<Ped>();
    public bool AtPosA = false;
    public bool AtPosB = false;
    public bool AtPosC = false;
    public SaveCar SaveCar = new SaveCar();
    public bool CreateEnemy;
    public int JuggerNautTimer;
    public int SwatTimer;
    public int BreachTimer;
    public float HeistTime;
    public int HeistTimer;
    public Prop Vent;
    public Vector3 Ent_FrontUp = new Vector3(-7.56f, -742.096f, 44f);
    public Vector3 Ent_FrontDown = new Vector3(0.9095f, -741.01f, 31f);
    public Vector3 Ent_Side = new Vector3(-88.82f, -661.114f, 35f);
    public Vector3 Ent_Back = new Vector3(53.8223f, -642.084f, 31f);
    public int FirstStage;
    public Prop P;
    public Prop P2;
    public int ENT_Used;
    public bool GotPlans;
    public bool GotC4_1;
    public bool GotC4_2;
    public Prop Crate_1;
    public Prop Crate_2;
    public List<Vehicle> Veh = new List<Vehicle>();
    public Vehicle ExBankPedVehicle;
    public bool LookingForVehicle;
    public Blip DeliveryPoint;
    public Vector3 DeliveryLoc = new Vector3(692.4743f, -1004.749f, 21f);
    public Vehicle GetawayCar;
    public bool C4_1Detonated;
    public bool C4_2Detonated;
    public Vector3 Gen1 = new Vector3(64.6155f, -770.726f, 17f);
    public Vector3 Gen2 = new Vector3(50.6583f, -776.297f, 17f);
    public Vector3 CameraPos1 = new Vector3(72.588f, -781.2409f, 21f);
    public float CameraRot1 = 39f;
    public Vector3 CameraPos2 = new Vector3(1052.889f, -287.9034f, 55f);
    public float CameraRot2 = 64f;
    public Vector3 ExplosivePos2 = new Vector3(1029.871f, -264.4223f, 50f);
    public Vehicle PlayerVehicle;
    public Prop C4_1;
    public Prop C4_2;
    public Blip C4_1Blip;
    public Blip C4_2Blip;
    public Camera Cam;
    public bool Detonated;
    public Prop VaultD;
    public bool TriggerVault;
    public bool VaultUnlocked;
    public bool DeletedElv2;
    public bool DeletedElv1;
    public Prop CasinoVaultDoor;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private UIMenu Heists;
    public int HeistMissson = 13;
    public int HeistStage;
    public bool HasntFailed;
    private ScriptSettings Config;
    public bool GotPL;
    public bool TriggerInfo;
    public bool MissionDone;
    public bool sitting;
    public List<Vehicle> AircraftCarrierVehicles2 = new List<Vehicle>();
    public List<Vehicle> AircraftCarrierVehicles = new List<Vehicle>();
    public List<Ped> AircarftCarrierPeds = new List<Ped>();
    public List<Ped> AircarftCarrierPeds2 = new List<Ped>();
    public List<Vehicle> ReinforcementsVehicles = new List<Vehicle>();
    public List<Ped> ReinforcementsPeds = new List<Ped>();
    public List<Vehicle> AttackAircraft = new List<Vehicle>();
    public List<Ped> AttackPed = new List<Ped>();
    public List<Ped> PlaneTargetPositions = new List<Ped>();
    public List<Vehicle> SwatVehicles = new List<Vehicle>();
    public List<Ped> SwatPeds = new List<Ped>();
    public bool AirConvoyOn;
    public bool ForcedCargotoland;
    public bool ForcedCargotoland2;
    public Vehicle CargoPlane;
    public Vehicle AvengerA;
    public Vehicle AvengerB;
    public Vehicle AvengerC;
    public Vehicle AvengerD;
    public Vehicle AvengerE;
    public Vehicle AvengerF;
    public Vehicle AvengerG;
    public Vehicle AvengerH;
    public Vehicle AvengerI;
    public Vehicle Hydra;
    public bool GotHydra;
    public bool DestroyedHydras;
    public bool TriggeredAttack;
    public Blip HangerB;
    public bool GotGetawayVeh;
    public Vehicle ChoosenVeh;
    public List<Vector3> RobPositions = new List<Vector3>();
    public bool TriggerNotifyNear;
    public bool TriggerNotifyVehicle;
    public bool TrackingBlip;
    public List<Blip> HubPointsBlip = new List<Blip>();
    public bool GotMaxPay;
    public bool TriggeredWantedLevelEscape;
    public bool TriggeredWantedLevelReinforcement;
    public bool FreezeGetawayCar;
    public Vector3 LastPos;
    public List<Ped> Peds2 = new List<Ped>();
    public List<Vector3> Spawns = new List<Vector3>();
    public Vehicle Prizecar = (Vehicle) null;
    public Ped ped;
    public List<Vector3> PokerTables = new List<Vector3>();
    public List<float> PokerTablesRot = new List<float>();
    public List<Vector3> BlackJackTables = new List<Vector3>();
    public List<float> BlackJackRot = new List<float>();
    public List<Vector3> SlotMachines = new List<Vector3>();
    public List<float> SlotMachinesRot = new List<float>();
    public List<Vector3> RouletteTables = new List<Vector3>();
    public List<float> RouletteTablesRot = new List<float>();
    public List<Prop> Tables = new List<Prop>();
    public List<Prop> Tables2 = new List<Prop>();
    public Prop WheelProp;
    public Prop WheelProp2;
    public Prop BasePlate;
    public Prop BasePlate2;
    public Vector3 ThraxPos = new Vector3(1099.792f, 219.5638f, -49.1f);
    public Prop WheelWinMarker;
    public List<Prop> WheelMarkers = new List<Prop>();
    public Vector3 LuckyWheel = new Vector3(1111.045f, 228.6406f, -50.5f);
    public Vector3 MarkerExit = new Vector3(1089.677f, 205.8681f, -50f);
    public Vector3 MarkerEnter = new Vector3(935.9782f, 47.018f, 80.2f);
    public Ped Vendor1;
    public Ped Vendor2;
    public List<Ped> MainPed = new List<Ped>();
    public List<Ped> SMPed = new List<Ped>();
    public bool UsingCasino;
    public int EnteranceUsed;
    public int ExitUsed;
    public bool InCasino;
    public bool VaultClosed;
    public bool EscapingCasino;
    public int LocAt;
    public Ped Lester;
    public Vehicle StockadeA;
    public Vehicle StockadeB;
    public Vehicle StockadeC;
    public Vector3 LesterSpawn = new Vector3(721.7867f, -977.5983f, 24f);
    public bool SecuredAsset_C4;
    public bool SecuredAsset_Stockade;
    public bool SecuredAsset_Vip;
    public int Hacktime;
    public int HackProg;
    public bool isDriving;
    public int DriveStage;
    public Vehicle FollowCar;
    public Ped FollowPed;
    public Ped MeetPed;
    public bool EnteredNormalCasino;
    public bool EnteredOffice;
    public bool MetalDetectorOn;
    public bool IsInterior;
    public bool BypassMetalDetector;
    public Prop BombSewer;
    public Prop BombVault_A;
    public Prop BombVault_B;
    public Prop BombVault_C;
    public Prop BombVault_D;
    public bool PlacedBomb;
    public Vehicle SecondaryGetawayVeh;
    public bool FreezeGetawayCar2;
    public bool IsPlanting;
    public bool AlarmsGoingOff;
    public int AlarmTimer;
    public bool GotCash;
    public List<Prop> Crate_Valuables = new List<Prop>();
    public bool NotifyOutVault;
    public bool NotifyOutVault2;
    public List<Vector3> Crate_loc = new List<Vector3>();
    public List<float> Crate_Rot = new List<float>();
    public List<float> Crate_Type = new List<float>();
    public int Scene1;
    public Prop bagProp;
    public Prop _cashGrabTray1;
    public Prop MoneyProp;
    public bool PlayingAnim;
    public bool CreatedCrates;
    public int CurrentType;
    public int CashCount;
    public int RobTimer;
    public bool InNormalCasino;
    public bool OverideAlarm;
    public int ReportTimer;
    public bool TriggerFullResponce;
    public bool TriggerFullResponce2;
    public bool TriggerFullResponce3;
    public bool ReportedtoGuardA;
    public bool ReportedtoGuardB;
    public Prop ExtraValuable;
    public bool RobbedExtraValuable;
    public bool ExtraVaultOpen;
    public int ExtraValuableType;
    public bool DebugTimeOn;
    public bool ShowTimeronShiftX;
    public int MetalDetectorTimer;
    public bool hackedDataPad;
    public bool NotifyHack;
    public Prop HackConsole;
    public bool AIinCasinoHeistCanWander;
    public int AIinCasinoWanderChance;
    public int AIinCasinoWanderRadius;
    public List<Vector3> AI_Pos = new List<Vector3>();
    public List<Vector3> AI_Rot = new List<Vector3>();
    public List<int> AI_Type = new List<int>();
    public bool Active;
    public int Amt;
    public int iLocal_8077;
    private bool justrecieved = true;
    private int scaleformloading;
    private bool loadingin = true;
    private bool up = false;
    private bool up1 = false;
    private bool up2 = false;
    private bool up3 = false;
    private bool up4 = true;
    private bool up5 = true;
    private bool up6 = true;
    private bool up7 = true;
    private bool active = false;
    private int indexx = -1;
    private int currentbar = 0;
    private float colOneY = 0.4f;
    private float colTwoY = 0.4f;
    private float colThreeY = 0.4f;
    private float colFourY = 0.4f;
    private float colFiveY = 0.74f;
    private float colSixY = 0.74f;
    private float colSevenY = 0.74f;
    private float colEightY = 0.74f;
    private int GameTimeReference1 = Game.GameTime;
    private float fLocal_240 = 0.53f;
    private float fLocal_239 = 0.62f;
    private bool collumn1 = false;
    private bool collumn2 = false;
    private bool collumn3 = false;
    private bool collumn4 = false;
    private bool collumn5 = false;
    private bool collumn6 = false;
    private bool collumn7 = false;
    private bool collumn8 = false;
    private int sound = 2;
    private bool skip1 = false;
    private bool skip2 = false;
    private bool skip3 = false;
    public List<Prop> SmokeEmitters = new List<Prop>();
    public bool PlantedBZGas;
    public bool ActiveHack;
    private int hackingScalwform = 0;
    private int uLocal_70 = 0;
    private int Hacking_Index = -1;
    private float Hacking_Lives = 3f;
    private int FeedBackNumber = -1;
    private bool DrawHackScaleform = false;
    private int ErrorTimer = Game.GameTime;
    private bool TRYDL = false;
    private bool IpTry = false;
    private int IpTryTimer = Game.GameTime;
    private int IpTryFailedTimer = Game.GameTime;
    private bool PlayBoth = true;
    private int IPSound = 0;
    private int MoveSound = 0;
    private int MoveTimer = Game.GameTime;
    private int MoveSoundTimer = Game.GameTime;
    private int Anim_Timer = Game.GameTime;
    private TheDiamondHeist.VariableTimer MyHackingTimer;
    public bool HackingSuccess;
    public bool HackDone;
    private List<object> HackingProps = new List<object>()
    {
      (object) "hei_prop_hei_securitypanel",
      (object) "hei_prop_hei_keypad_01",
      (object) "hei_prop_hei_keypad_02",
      (object) "hei_prop_hei_keypad_03",
      (object) "prop_ld_keypad_01",
      (object) "prop_ld_keypad_01b",
      (object) "prop_ld_keypad_01b_lod",
      (object) "hei_prop_hei_cs_keyboard",
      (object) "prop_cs_keyboard_01",
      (object) "prop_keyboard_01a",
      (object) "prop_keyboard_01b",
      (object) "prop_laptop_jimmy",
      (object) "prop_laptop_lester",
      (object) "prop_laptop_lester2",
      (object) "p_amb_lap_top_02",
      (object) "p_cs_laptop_02",
      (object) "p_laptop_02_s",
      (object) "prop_laptop_01a"
    };
    public FiringPattern RobberAFP = FiringPattern.BurstFire;
    public FiringPattern RobberBFP = FiringPattern.BurstFire;
    public FiringPattern RobberCFP = FiringPattern.BurstFire;
    public int RobberAtimer = 0;
    public int RobberBtimer = 0;
    public int RobberCtimer = 0;
    public string OutfitReq = "No Requirement";
    public int RobberA_C;
    public int RobberB_C;
    public int RobberC_C;
    public string ID_C;
    public float BaseCrewCost = 765000f;
    public bool SetupAi;
    public bool TriggeredReinforcments;
    public bool SpawnedReinforcements;
    public bool SetupReinforcments;
    public bool SetSewerBomb;
    public bool DetonatedSewerBomb;
    public Vector3 PointA = new Vector3(108.4f, -1355.4f, 30f);
    public Vector3 PointB = new Vector3(791.5f, -1388.8f, 27f);
    public Vector3 PointC = new Vector3(504.6f, -333.5f, 44f);
    public bool isInterior;
    public int LightNode = 0;
    public bool SetRob = false;
    public bool InitialAnimDone = false;
    public Vector3 V1 = new Vector3(2500.4f, -238.5f, -70.7f);
    public bool DrillComplete;
    public bool VaultOpenedByDrill;
    public List<string> CutscenePed1Comp = new List<string>()
    {
      "0_0_0",
      "1_0_0",
      "2_0_0",
      "3_0_0",
      "4_0_0",
      "5_0_0",
      "6_0_0",
      "7_0_0",
      "8_0_0",
      "9_0_0",
      "10_0_0",
      "11_0_0"
    };
    public List<string> CutscenePed2Comp = new List<string>()
    {
      "0_0_0",
      "1_0_0",
      "2_0_0",
      "3_0_0",
      "4_0_0",
      "5_0_0",
      "6_0_0",
      "7_0_0",
      "8_0_0",
      "9_0_0",
      "10_0_0",
      "11_0_0"
    };
    public List<string> CutscenePed3Comp = new List<string>()
    {
      "0_0_0",
      "1_0_0",
      "2_0_0",
      "3_0_0",
      "4_0_0",
      "5_0_0",
      "6_0_0",
      "7_0_0",
      "8_0_0",
      "9_0_0",
      "10_0_0",
      "11_0_0"
    };
    public List<string> CutscenePed4Comp = new List<string>()
    {
      "0_0_0",
      "1_0_0",
      "2_0_0",
      "3_0_0",
      "4_0_0",
      "5_0_0",
      "6_0_0",
      "7_0_0",
      "8_0_0",
      "9_0_0",
      "10_0_0",
      "11_0_0"
    };
    public Prop Drill;
    public bool Isdrilliing;
    public int DrillFX;
    public int Sound;
    public float Zone;
    public int FailSound;
    public float Speed;
    public float Temp;
    public float Pos;
    public int scale;
    public bool triggerLockA;
    public bool triggerLockB;
    public bool triggerLockC;
    public bool triggerLockD;
    public int PinSound;
    public bool StartDrill;
    public bool DrillDone;
    public int EndTimer;
    public bool firsttime = true;
    public float drillspeed;
    public float temperature = 0.0f;
    public float discs = 4f;
    public float fvar0 = 1f;
    public float depth;
    public float paramf_12 = 1f;
    public float DrillPos = 1f;
    public bool activeCasLaser = false;
    public bool activeCasDrill = false;
    public bool frozen = false;
    public bool pin_one = false;
    public bool pin_two = false;
    public bool pin_three = false;
    public bool pin_four = false;
    public bool pin_five = false;
    public bool pin_six = false;
    public bool pin_seven = false;
    public bool pin_eight = false;
    public float NumOfDiscs = 6f;
    public int Drillstage = 1;
    public bool PlayDrillFXSound;
    public bool DrillingComplete;
    public bool UseCasinoDrill = false;
    public bool Intunnel;
    public Vector3 PracticeHackPos = new Vector3(2696.77f, -368.41f, -55.8f);
    public Vector3 PracticeDrill = new Vector3(2688.67f, -368.558f, -55.8f);

    public Model SpawnProp(string Prop)
    {
      Model model = new Model(Prop);
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

    public void SpawnProp(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(10000);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        this.Props.Add(World.CreateProp(model, Pos, Rot, true, false));
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

    public void SpawnPropBombSewer(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(10000);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        Prop prop = World.CreateProp(model, Pos, Rot, true, false);
        this.Props.Add(prop);
        this.BombSewer = prop;
        foreach (Prop nearbyProp in World.GetNearbyProps(Pos, 60f, model))
        {
          nearbyProp.SetNoCollision((Entity) nearbyProp, false);
          nearbyProp.LodDistance = 3000;
          nearbyProp.IsInvincible = true;
          nearbyProp.FreezePosition = true;
          this.Props.Add(nearbyProp);
        }
        Script.Wait(1);
      }
      model.MarkAsNoLongerNeeded();
    }

    public void SpawnPropBombVault(string Prop, Vector3 Pos, Vector3 Rot)
    {
      Model model = new Model(Prop);
      model.Request(10000);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        Prop prop = World.CreateProp(model, Pos, Rot, true, false);
        this.Props.Add(prop);
        if ((Entity) this.BombVault_A == (Entity) null)
        {
          this.BombVault_A = prop;
          return;
        }
        if ((Entity) this.BombVault_B == (Entity) null)
        {
          this.BombVault_B = prop;
          return;
        }
        if ((Entity) this.BombVault_C == (Entity) null)
        {
          this.BombVault_C = prop;
          return;
        }
        if ((Entity) this.BombVault_D == (Entity) null)
        {
          this.BombVault_D = prop;
          return;
        }
        foreach (Prop nearbyProp in World.GetNearbyProps(Pos, 60f, model))
        {
          nearbyProp.SetNoCollision((Entity) nearbyProp, false);
          nearbyProp.LodDistance = 3000;
          nearbyProp.IsInvincible = true;
          nearbyProp.FreezePosition = true;
          this.Props.Add(nearbyProp);
        }
        Script.Wait(1);
      }
      model.MarkAsNoLongerNeeded();
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

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb(0, 0, 0, 0);
    }

    public TheDiamondHeist()
    {
      if (this.Main.CheckArcadeOwned() == 1)
        this.FactoryPos = this.Main.GetArcadeLoc();
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Tick += new EventHandler(this.OnTick);
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.Interval = 1;
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Casino Heist", "Select an Option");
      this.modMenuPool.Add(this.mainMenu);
      this.Heists = this.modMenuPool.AddSubMenu(this.mainMenu, "Start Heist");
      this.GUIMenus.Add(this.Heists);
      this.modMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Casino Heist", "Select an Option");
      this.modMenuPool2.Add(this.mainMenu2);
      this.Heists2 = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Choose Enterance/Exit");
      this.GUIMenus.Add(this.Heists2);
      this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//CasinoHeist//Heist.ini");
      this.SetupHeists();
      this.GetLocation();
      for (int index = 0; index < this.GUIMenus.Count<UIMenu>(); ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
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

    private int check(float name) => (double) name >= (double) this.fLocal_240 && (double) name <= (double) this.fLocal_239 ? 1 : 0;

    private int activatescale(string scale)
    {
      this.scaleformloading = Function.Call<int>(Hash._0xC514489CFB8AF806, (InputArgument) scale);
      return Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.scaleformloading) ? 1 : 0;
    }

    public void SetFollow(Vehicle Plane, Ped P)
    {
      Vector3 position = P.Position;
      Function.Call(Hash._0x23703CD154E83B88, (InputArgument) Plane.GetPedOnSeat(VehicleSeat.Driver).Handle, (InputArgument) Plane.Handle, (InputArgument) P, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 7, (InputArgument) 0.0, (InputArgument) -1.0, (InputArgument) 0.0, (InputArgument) 1000, (InputArgument) 150);
    }

    public void SetActiveTarget2(Vehicle Plane, Ped P)
    {
      Vector3 position = P.Position;
      Function.Call(Hash._0x23703CD154E83B88, (InputArgument) Plane.GetPedOnSeat(VehicleSeat.Driver).Handle, (InputArgument) Plane.Handle, (InputArgument) P, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 6, (InputArgument) 0.0, (InputArgument) -1.0, (InputArgument) 0.0, (InputArgument) 1000, (InputArgument) 150);
    }

    public void SetActiveTarget(Vehicle Plane, Ped P)
    {
      Vector3 position = P.Position;
      Function.Call(Hash._0x23703CD154E83B88, (InputArgument) Plane.GetPedOnSeat(VehicleSeat.Driver).Handle, (InputArgument) Plane.Handle, (InputArgument) P, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z, (InputArgument) 6, (InputArgument) 0.0, (InputArgument) -1.0, (InputArgument) 0, (InputArgument) 1000, (InputArgument) 150);
    }

    public void FightAgainst(Ped Target, Ped Enemy)
    {
      Enemy.Task.ClearAll();
      Enemy.Task.FightAgainst(Target);
    }

    private void Loadehacker(bool playBoth)
    {
      this.PlayBoth = playBoth;
      this.IpTryFailedTimer = Game.GameTime;
      this.TRYDL = false;
      this.Hacking_Lives = 3f;
      this.IpTry = false;
      this.DrawHackScaleform = false;
      Function.Call(Hash._0x61BB1D9B3A95D802, (InputArgument) 1);
      Function.Call(Hash._0x71A78003C8E71424, (InputArgument) "HACK", (InputArgument) 3);
      this.hackingScalwform = Function.Call<int>(Hash._0xBD06C611BB9048C2, (InputArgument) "Hacking_PC");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.hackingScalwform))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) this.hackingScalwform, (InputArgument) "SET_CURSOR_VISIBILITY");
      Function.Call(Hash._0xC58424BA936EB458, (InputArgument) false);
      Function.Call(Hash._0xC6796A8FFA375E53);
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "HACKING_PC_desktop_0", (InputArgument) 0);
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "HACKING_PC_desktop_0"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "HACKING_PC_desktop_1", (InputArgument) 0);
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "HACKING_PC_desktop_1"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "HACKING_PC_desktop_2", (InputArgument) 0);
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "HACKING_PC_desktop_2"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "HACKING_PC_desktop_3", (InputArgument) 0);
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "HACKING_PC_desktop_3"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "HACKING_PC_desktop_4", (InputArgument) 0);
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "HACKING_PC_desktop_4"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "HACKING_PC_desktop_5", (InputArgument) 0);
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "HACKING_PC_desktop_5"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xD3BD40951412FEF6, (InputArgument) "anim@heists@keypad@");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "anim@heists@keypad@"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xD3BD40951412FEF6, (InputArgument) "missheist_jewel@hacking");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "missheist_jewel@hacking"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xD3BD40951412FEF6, (InputArgument) "anim@heists@ornate_bank@hack");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "anim@heists@ornate_bank@hack"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xD3BD40951412FEF6, (InputArgument) "anim@heists@keypad@");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "anim@heists@keypad@"))
          Script.Wait(10);
        else
          break;
      }
      Function.Call(Hash._0xD3BD40951412FEF6, (InputArgument) "missheist_jewel@hacking");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "missheist_jewel@hacking"))
          Script.Wait(10);
        else
          break;
      }
      this.Hacking_Index = 0;
    }

    private unsafe void UnloadLoadehacker()
    {
      if (!Function.Call<bool>(Hash._0xFCBDCE714A7C88E5, (InputArgument) this.IPSound))
      {
        Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.IPSound);
        this.IPSound = -1;
      }
      if (!Function.Call<bool>(Hash._0xFCBDCE714A7C88E5, (InputArgument) this.MoveSound))
      {
        Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.MoveSound);
        this.MoveSound = -1;
      }
      Function.Call(Hash._0x1D132D614DD86811, (InputArgument) &this.hackingScalwform);
      this.hackingScalwform = 0;
      this.Hacking_Index = -1;
      Game.Player.CanControlCharacter = true;
      Script.Wait(1000);
      Game.Player.Character.Task.Wait(0);
    }

    public void DisplayReq()
    {
      Convert.ToInt32(UIMenu.GetScreenResolutionMantainRatio().Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(4, 10), new Size(200, 200), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText(" !   Outfit Requirement   !", new Point(1700, 30), 0.76f, Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      new UIResText(this.OutfitReq, new Point(1700, 90), 0.76f, Color.FromArgb((int) byte.MaxValue, 199, 168, 87), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public Model RequestPed(PedHash Name)
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

    public void PlayAnimation(Ped ped)
    {
      int num = new System.Random().Next(1, 44);
      ped.Task.ClearAll();
      ped.Task.ClearAllImmediately();
      if (num == 1)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationfemale@banging_tunes_right", "banging_tunes", 50f, 2500, false, 0.0f);
      if (num == 1)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@air_synth", "air_synth", 25f, 7500, false, 0.0f);
      if (num == 2)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@blow_kiss", "blow_kiss", 25f, 7500, false, 0.0f);
      if (num == 3)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@bro_love", "bro_love", 25f, 7500, false, 0.0f);
      if (num == 4)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@cats_cradle", "cats_cradle", 25f, 7500, false, 0.0f);
      if (num == 5)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@chicken_taunt", "chicken_taunt", 25f, 7500, false, 0.0f);
      if (num == 6)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@chin_brush", "chin_brush", 25f, 7500, false, 0.0f);
      if (num == 7)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@cry_baby", "cry_baby", 25f, 7500, false, 0.0f);
      if (num == 8)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@dj", "dj", 25f, 7500, false, 0.0f);
      if (num == 9)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@dock", "dock", 25f, 7500, false, 0.0f);
      if (num == 10)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@face_palm", "face_palm", 25f, 7500, false, 0.0f);
      if (num == 11)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@find_the_fish", "find_the_fish", 25f, 7500, false, 0.0f);
      if (num == 12)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@finger", "finger", 25f, 7500, false, 0.0f);
      if (num == 13)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@finger_kiss", "finger_kiss", 25f, 7500, false, 0.0f);
      if (num == 14)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@freakout", "freakout", 25f, 7500, false, 0.0f);
      if (num == 15)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@heart_pumping", "heart_pumping", 25f, 7500, false, 0.0f);
      if (num == 16)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@jazz_hands", "jazz_hands", 25f, 7500, false, 0.0f);
      if (num == 17)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@karate_chops", "karate_chops", 25f, 7500, false, 0.0f);
      if (num == 18)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@knuckle_crunch", "knuckle_crunch", 25f, 7500, false, 0.0f);
      if (num == 19)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@mind_blown", "mind_blown", 25f, 7500, false, 0.0f);
      if (num == 20)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@no_way", "no_way", 25f, 7500, false, 0.0f);
      if (num == 21)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@nose_pick", "nose_pick", 25f, 7500, false, 0.0f);
      if (num == 22)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@oh_snap", "oh_snap", 25f, 7500, false, 0.0f);
      if (num == 23)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@peace", "peace", 25f, 7500, false, 0.0f);
      if (num == 24)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@photography", "photography", 25f, 7500, false, 0.0f);
      if (num == 25)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@raining_cash", "raining_cash", 25f, 7500, false, 0.0f);
      if (num == 26)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@raise_the_roof", "raise_the_roof", 25f, 7500, false, 0.0f);
      if (num == 27)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@rock", "rock", 25f, 7500, false, 0.0f);
      if (num == 28)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@salsa_roll", "salsa_roll", 25f, 7500, false, 0.0f);
      if (num == 29)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@salute", "salute", 25f, 7500, false, 0.0f);
      if (num == 30)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@shadow_boxing", "shadow_boxing", 25f, 7500, false, 0.0f);
      if (num == 31)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@shush", "shush", 25f, 7500, false, 0.0f);
      if (num == 32)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@slow_clap", "slow_clap", 25f, 7500, false, 0.0f);
      if (num == 33)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@smoke_flick", "smoke_flick", 25f, 7500, false, 0.0f);
      if (num == 34)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@spray_champagne", "spray_champagne", 25f, 7500, false, 0.0f);
      if (num == 35)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@stinker", "stinker", 25f, 7500, false, 0.0f);
      if (num == 36)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@surrender", "surrender", 25f, 7500, false, 0.0f);
      if (num == 37)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@the_woogie", "the_woogie", 25f, 7500, false, 0.0f);
      if (num == 38)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@thumb_on_ears", "thumb_on_ears", 25f, 7500, false, 0.0f);
      if (num == 39)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@thumbs_up", "thumbs_up", 25f, 7500, false, 0.0f);
      if (num == 40)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@uncle_disco", "uncle_disco", 25f, 7500, false, 0.0f);
      if (num == 41)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@v_sign", "v_sign", 25f, 7500, false, 0.0f);
      if (num == 42)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@wank", "wank", 25f, 7500, false, 0.0f);
      if (num == 43)
        ped.Task.PlayAnimation("anim@mp_player_intcelebrationmale@wave", "wave", 25f, 7500, false, 0.0f);
      if (num != 44)
        return;
      ped.Task.PlayAnimation("aanim@mp_player_intcelebrationmale@you_loco", "you_loco", 25f, 7500, false, 0.0f);
    }

    public void Setoutfit(Ped p, int i)
    {
      if (!(p.Model == (Model) PedHash.FreemodeMale01))
        return;
      Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) p, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
      Ped ped = p;
      Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) -1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 17);
      bool flag = false;
      string idC = this.ID_C;
      if (i == 9)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 125, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 125, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 125, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 125, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 10)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 89, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 55, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 54, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 89, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 55, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 54, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 11 && idC.Equals("Outfit Default"))
      {
        if (!flag && !idC.Equals("Outfit Default"))
          UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num = new System.Random().Next(1, 100);
        if (num <= 25)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 38, (InputArgument) 0, (InputArgument) 1);
        if (num > 25 && num <= 50)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 112, (InputArgument) 0, (InputArgument) 1);
        if (num > 50 && num <= 75)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
        if (num > 75)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 104, (InputArgument) 25, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 68, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (i == 12)
      {
        if (idC.Equals("Blue"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 91, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 84, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 97, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 186, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 91, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 97, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 186, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 91, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 84, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 97, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 186, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 91, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 97, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 186, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 91, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 84, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 97, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 186, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 91, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 97, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 186, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 91, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 84, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 97, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 186, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Black") || idC.Equals("Outfit Default"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 13)
      {
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 12, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 13, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 15, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 275, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
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
      }
      if (i == 14)
      {
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 276, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 276, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 12, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 276, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 13, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 276, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 276, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 15, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 276, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 107, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 276, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
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
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 276, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 15)
      {
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 134, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 147, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 167, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 113, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 90, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 286, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 135, (InputArgument) 0);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 134, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 147, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 167, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 113, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 90, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 286, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 135, (InputArgument) 0);
        }
      }
      if (i == 16)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 115, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 115, (InputArgument) 4, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 115, (InputArgument) 6, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 115, (InputArgument) 7, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 115, (InputArgument) 5, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 115, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 17)
      {
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 133, (InputArgument) 8, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 166, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 110, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 88, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 133, (InputArgument) 10, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 166, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 110, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 88, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 283, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 133, (InputArgument) 11, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 166, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 110, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 88, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 283, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 133, (InputArgument) 9, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 166, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 110, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 88, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 283, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 133, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 166, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 110, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 88, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 133, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 166, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 110, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 88, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 18)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 91, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 77, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 55, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 178, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 91, (InputArgument) 1, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 77, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 55, (InputArgument) 1, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 178, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 91, (InputArgument) 9, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 77, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 55, (InputArgument) 7, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 178, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Blue"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 91, (InputArgument) 3, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 77, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 55, (InputArgument) 3, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 178, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 91, (InputArgument) 10, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 77, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 55, (InputArgument) 10, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 178, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 91, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 77, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 55, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 178, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 19)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 134, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 106, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 152, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 274, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Blue"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 134, (InputArgument) 1, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 3, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 106, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 152, (InputArgument) 1, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 274, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 134, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 106, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 152, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 274, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 20)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 139, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 164, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 33, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 277, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Blue"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 139, (InputArgument) 6, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 164, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 108, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 33, (InputArgument) 6, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 277, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 139, (InputArgument) 1, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 164, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 108, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 33, (InputArgument) 1, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 277, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 139, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 164, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 33, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 277, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 139, (InputArgument) 4, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 164, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 108, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 33, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 277, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 139, (InputArgument) 1, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 164, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 108, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 33, (InputArgument) 1, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 277, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 139, (InputArgument) 8, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 164, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 108, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 33, (InputArgument) 8, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 277, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 139, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 164, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 33, (InputArgument) 0, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 277, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 21)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (i == 25)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 134, (InputArgument) 8, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 106, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 152, (InputArgument) 8, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 274, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 134, (InputArgument) 9, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 3, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 106, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 152, (InputArgument) 9, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 274, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 134, (InputArgument) 8, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 106, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 152, (InputArgument) 8, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 274, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 134, (InputArgument) 8, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 106, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 152, (InputArgument) 8, (InputArgument) 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 83, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 274, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
    }

    private void DisplayHelpTextThisFrameNoSound(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) -1);
    }

    public void SetOutift(Ped ped, int Type)
    {
      if (Type == 1)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (Type == 2)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 6, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 6, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (Type == 3)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 5, (InputArgument) 2, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 5, (InputArgument) 2, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (Type == 4)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 6, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 6, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (Type == 5)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (Type == 6)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 5, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 5, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (Type != 7)
        return;
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 6, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
    }

    private void SetupHeists()
    {
      this.HackerCost = 90000f;
      this.TeamAI1Cost = 0.0f;
      this.TeamAI2Cost = 0.0f;
      this.TeamAI3Cost = 0.0f;
      this.TeamAI4Cost = 0.0f;
      List<object> Colours = new List<object>();
      Colours.Add((object) "Outfit Default");
      Colours.Add((object) "Blue");
      Colours.Add((object) "Green");
      Colours.Add((object) "Red");
      Colours.Add((object) "Orange");
      Colours.Add((object) "Pink");
      Colours.Add((object) "Purple");
      Colours.Add((object) "White");
      Colours.Add((object) "Black");
      List<object> items1 = new List<object>();
      items1.Add((object) "Robber (Default)");
      items1.Add((object) "Franklin Clinton");
      items1.Add((object) "Micheal De Santa");
      items1.Add((object) "Trevor Phillips");
      items1.Add((object) "Lamar Davis");
      items1.Add((object) "Clown");
      items1.Add((object) "Zombie");
      items1.Add((object) "Alien");
      items1.Add((object) "Juggernaut v2");
      items1.Add((object) "Doomsday Armour");
      items1.Add((object) "Heist Gear");
      items1.Add((object) "Heist Gear 2");
      items1.Add((object) "Juggernaut (Cosmetic)");
      items1.Add((object) "Arena War 1");
      items1.Add((object) "Arena War 2");
      items1.Add((object) "Space Monkey");
      items1.Add((object) "Commando");
      items1.Add((object) "Space Suit");
      items1.Add((object) "Tron");
      items1.Add((object) "Scifi Suit");
      items1.Add((object) "Alien 2");
      items1.Add((object) "Pogo ");
      items1.Add((object) "R. Space Range");
      items1.Add((object) "Mime ");
      items1.Add((object) "Mariachi ");
      items1.Add((object) "UBO ");
      items1.Add((object) "Sasquatch");
      items1.Add((object) "Dave Norton");
      items1.Add((object) "Steve Haines");
      items1.Add((object) "Devon Weston");
      items1.Add((object) "Paige");
      items1.Add((object) "Agent 14");
      items1.Add((object) "Lester");
      items1.Add((object) "Denise Clinton");
      items1.Add((object) "Nervous Ron");
      items1.Add((object) "Chef");
      items1.Add((object) "Eddie Toh");
      items1.Add((object) "Fabien");
      items1.Add((object) "Clay Simmons");
      items1.Add((object) "Norm Richards");
      items1.Add((object) "Patrick McReary");
      items1.Add((object) "Daryl Johns");
      items1.Add((object) "Gustavo Mota");
      items1.Add((object) "Hugo Welsh");
      items1.Add((object) "Karl Abolaji");
      items1.Add((object) "Chef (Heist)");
      items1.Add((object) "Lazlow Jones");
      items1.Add((object) "Amanda De Santa");
      items1.Add((object) "Tracy De Santa ");
      items1.Add((object) "Jimmy De Santa ");
      items1.Add((object) "Stretch");
      items1.Add((object) "Johnny Klebitz");
      List<object> AIskin = new List<object>();
      AIskin.Add((object) PedHash.Robber01SMY);
      AIskin.Add((object) PedHash.Franklin);
      AIskin.Add((object) PedHash.Michael);
      AIskin.Add((object) PedHash.Trevor);
      AIskin.Add((object) PedHash.LamarDavis);
      AIskin.Add((object) PedHash.Clown01SMY);
      AIskin.Add((object) PedHash.Zombie01);
      AIskin.Add((object) PedHash.MovAlien01);
      AIskin.Add((object) PedHash.Juggernaut01M);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.Pogo01);
      AIskin.Add((object) PedHash.RsRanger01AMO);
      AIskin.Add((object) PedHash.MimeSMY);
      AIskin.Add((object) PedHash.Mariachi01SMM);
      AIskin.Add((object) PedHash.FreemodeMale01);
      AIskin.Add((object) PedHash.Orleans);
      AIskin.Add((object) PedHash.DaveNorton);
      AIskin.Add((object) PedHash.SteveHains);
      AIskin.Add((object) PedHash.Devin);
      AIskin.Add((object) PedHash.Paige);
      AIskin.Add((object) PedHash.Agent14);
      AIskin.Add((object) PedHash.LesterCrest);
      AIskin.Add((object) PedHash.Denise);
      AIskin.Add((object) PedHash.NervousRon);
      AIskin.Add((object) PedHash.Chef);
      AIskin.Add((object) PedHash.EdToh);
      AIskin.Add((object) PedHash.Fabien);
      AIskin.Add((object) PedHash.Clay);
      AIskin.Add((object) PedHash.PestContGunman);
      AIskin.Add((object) PedHash.PestContGunman);
      AIskin.Add((object) PedHash.PestContGunman);
      AIskin.Add((object) PedHash.PestContGunman);
      AIskin.Add((object) PedHash.PestContGunman);
      AIskin.Add((object) PedHash.PestContGunman);
      AIskin.Add((object) PedHash.PestContGunman);
      AIskin.Add((object) PedHash.Lazlow);
      AIskin.Add((object) PedHash.AmandaTownley);
      AIskin.Add((object) PedHash.TracyDisanto);
      AIskin.Add((object) PedHash.JimmyDisanto);
      AIskin.Add((object) PedHash.Stretch);
      AIskin.Add((object) PedHash.JohnnyKlebitzCutscene);
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Heists, "Crew Setup");
      this.GUIMenus.Add(uiMenu);
      List<object> items2 = new List<object>();
      items2.Add((object) "No AI");
      items2.Add((object) "AI");
      List<object> items3 = new List<object>();
      items3.Add((object) "Poor");
      items3.Add((object) "Average");
      items3.Add((object) "Moderate");
      items3.Add((object) "Semi-Pro");
      items3.Add((object) "Pro");
      items3.Add((object) "Unbeatable");
      items3.Add((object) "Juggernaut");
      List<object> FP = new List<object>();
      foreach (FiringPattern firingPattern in (FiringPattern[]) Enum.GetValues(typeof (FiringPattern)))
        FP.Add((object) firingPattern);
      UIMenuListItem H = new UIMenuListItem("Hacker Lvl : ", items3, 0);
      uiMenu.AddItem((UIMenuItem) H);
      UIMenuItem uiMenuItem1 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem1);
      UIMenuListItem C = new UIMenuListItem("Color : ", Colours, 0);
      uiMenu.AddItem((UIMenuItem) C);
      C.Description = "Use this Colour Whenever possible For AI or use Default";
      UIMenuItem uiMenuItem2 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem2);
      UIMenuListItem T1 = new UIMenuListItem("Team Mate 1  : ", items2, 0);
      uiMenu.AddItem((UIMenuItem) T1);
      UIMenuListItem T1S = new UIMenuListItem("Team Mate 1  Skill : ", items3, 0);
      uiMenu.AddItem((UIMenuItem) T1S);
      UIMenuListItem T1Skin = new UIMenuListItem("Team Mate 1 Skin : ", items1, 0);
      uiMenu.AddItem((UIMenuItem) T1Skin);
      UIMenuListItem T1FP = new UIMenuListItem("Team Mate 1 Fire Mode : ", FP, 0);
      uiMenu.AddItem((UIMenuItem) T1FP);
      UIMenuItem uiMenuItem3 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem3);
      UIMenuListItem T2 = new UIMenuListItem("Team Mate 2  : ", items2, 0);
      uiMenu.AddItem((UIMenuItem) T2);
      UIMenuListItem T2S = new UIMenuListItem("Team Mate 2  Skill : ", items3, 0);
      uiMenu.AddItem((UIMenuItem) T2S);
      UIMenuListItem T2Skin = new UIMenuListItem("Team Mate 2 Skin : ", items1, 0);
      uiMenu.AddItem((UIMenuItem) T2Skin);
      UIMenuListItem T2FP = new UIMenuListItem("Team Mate 2 Fire Mode : ", FP, 0);
      uiMenu.AddItem((UIMenuItem) T2FP);
      UIMenuItem uiMenuItem4 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem4);
      UIMenuListItem T3 = new UIMenuListItem("Team Mate 3  : ", items2, 0);
      uiMenu.AddItem((UIMenuItem) T3);
      UIMenuListItem T3S = new UIMenuListItem("Team Mate 3  Skill : ", items3, 0);
      uiMenu.AddItem((UIMenuItem) T3S);
      UIMenuListItem T3Skin = new UIMenuListItem("Team Mate 3 Skin : ", items1, 0);
      uiMenu.AddItem((UIMenuItem) T3Skin);
      UIMenuListItem T3FP = new UIMenuListItem("Team Mate 3 Fire Mode : ", FP, 0);
      uiMenu.AddItem((UIMenuItem) T3FP);
      UIMenuItem uiMenuItem5 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem5);
      UIMenuItem CrewCut = new UIMenuItem("CrewCut : $" + (this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost).ToString("N"));
      uiMenu.AddItem(CrewCut);
      UIMenuItem Start = new UIMenuItem("Start");
      uiMenu.AddItem(Start);
      // ISSUE: reference to a compiler-generated field
      if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (TheDiamondHeist)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.ID_C = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__0.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__0, Colours[C.Index]);
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == C)
        {
          // ISSUE: reference to a compiler-generated field
          if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (TheDiamondHeist)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.ID_C = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__1.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__1, Colours[C.Index]);
        }
        if ((item == T1Skin || item == T1S || item == T1) && (Entity) this.RobberA != (Entity) null)
        {
          Script.Wait(5);
          this.PlayAnimation(this.RobberA);
        }
        if ((item == T2Skin || item == T2S || item == T2) && (Entity) this.RobberB != (Entity) null)
        {
          Script.Wait(5);
          this.PlayAnimation(this.RobberB);
        }
        if ((item == T3Skin || item == T3S || item == T3) && (Entity) this.RobberC != (Entity) null)
        {
          Script.Wait(5);
          this.PlayAnimation(this.RobberC);
        }
        if (item == T1 || item == T1Skin)
        {
          if (T1.Index == 1)
          {
            if ((Entity) this.RobberA != (Entity) null)
              this.RobberA.Delete();
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, Ped>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Ped), typeof (TheDiamondHeist)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, Ped> target = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__3.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, Ped>> p3 = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__3;
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__2 = CallSite<Func<CallSite, System.Type, object, Vector3, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "CreatePed", (IEnumerable<System.Type>) null, typeof (TheDiamondHeist), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__2.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__2, typeof (World), AIskin[T1Skin.Index], new Vector3(400.3f, -960.1f, -100f), -88);
            this.RobberA = target((CallSite) p3, obj);
            this.RobberA.FreezePosition = true;
            this.Setoutfit(this.RobberA, T1Skin.Index);
            this.PlayAnimation(this.RobberA);
            this.OutfitReq = "No Requirement";
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__4 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, PedHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (PedHash), typeof (TheDiamondHeist)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.RobberASkin = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__4.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__4, AIskin[T1Skin.Index]);
            this.RobberA_C = T1Skin.Index;
            if (T1Skin.Index == 6)
            {
              this.Setoutfit(this.RobberA, 21);
              this.RobberA_C = 21;
            }
            if (T1Skin.Index > 26)
            {
              this.OutfitReq = "No Requirement";
              // ISSUE: reference to a compiler-generated field
              if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__5 == null)
              {
                // ISSUE: reference to a compiler-generated field
                TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, PedHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (PedHash), typeof (TheDiamondHeist)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.RobberASkin = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__5.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__5, AIskin[T1Skin.Index]);
              this.RobberA_C = T1Skin.Index;
              if (this.RobberA_C == 39)
                this.SetOutift(this.RobberA, 1);
              if (this.RobberA_C == 40)
                this.SetOutift(this.RobberA, 2);
              if (this.RobberA_C == 41)
                this.SetOutift(this.RobberA, 3);
              if (this.RobberA_C == 42)
                this.SetOutift(this.RobberA, 4);
              if (this.RobberA_C == 43)
                this.SetOutift(this.RobberA, 5);
              if (this.RobberA_C == 44)
                this.SetOutift(this.RobberA, 6);
              if (this.RobberA_C == 45)
                this.SetOutift(this.RobberA, 7);
            }
          }
          else
          {
            if ((Entity) this.RobberA != (Entity) null)
              this.RobberA.Delete();
            this.RobberA_C = 0;
          }
        }
        if (item == T2 || item == T2Skin)
        {
          if (T2.Index == 1)
          {
            if ((Entity) this.RobberB != (Entity) null)
              this.RobberB.Delete();
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__7 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, Ped>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Ped), typeof (TheDiamondHeist)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, Ped> target = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__7.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, Ped>> p7 = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__7;
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__6 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__6 = CallSite<Func<CallSite, System.Type, object, Vector3, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "CreatePed", (IEnumerable<System.Type>) null, typeof (TheDiamondHeist), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__6.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__6, typeof (World), AIskin[T2Skin.Index], new Vector3(400.3f, -957.5f, -100f), -88);
            this.RobberB = target((CallSite) p7, obj);
            this.RobberB.FreezePosition = true;
            this.Setoutfit(this.RobberB, T2Skin.Index);
            this.PlayAnimation(this.RobberB);
            this.OutfitReq = "No Requirement";
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__8 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, PedHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (PedHash), typeof (TheDiamondHeist)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.RobberBSkin = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__8.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__8, AIskin[T2Skin.Index]);
            this.RobberB_C = T2Skin.Index;
            if (T2Skin.Index == 6)
            {
              this.Setoutfit(this.RobberB, 21);
              this.RobberB_C = 21;
            }
            if (T2Skin.Index > 26)
            {
              this.OutfitReq = "No Requirement";
              // ISSUE: reference to a compiler-generated field
              if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__9 == null)
              {
                // ISSUE: reference to a compiler-generated field
                TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, PedHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (PedHash), typeof (TheDiamondHeist)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.RobberBSkin = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__9.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__9, AIskin[T2Skin.Index]);
              this.RobberB_C = T2Skin.Index;
              if (this.RobberB_C == 39)
                this.SetOutift(this.RobberB, 1);
              if (this.RobberB_C == 40)
                this.SetOutift(this.RobberB, 2);
              if (this.RobberB_C == 41)
                this.SetOutift(this.RobberB, 3);
              if (this.RobberB_C == 42)
                this.SetOutift(this.RobberB, 4);
              if (this.RobberB_C == 43)
                this.SetOutift(this.RobberB, 5);
              if (this.RobberB_C == 44)
                this.SetOutift(this.RobberB, 6);
              if (this.RobberB_C == 45)
                this.SetOutift(this.RobberB, 7);
            }
          }
          else
          {
            if ((Entity) this.RobberB != (Entity) null)
              this.RobberB.Delete();
            this.RobberB_C = 0;
          }
        }
        if (item == T3 || item == T3Skin)
        {
          if (T3.Index == 1)
          {
            if ((Entity) this.RobberC != (Entity) null)
              this.RobberC.Delete();
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__11 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, Ped>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Ped), typeof (TheDiamondHeist)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, Ped> target = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__11.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, Ped>> p11 = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__11;
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__10 = CallSite<Func<CallSite, System.Type, object, Vector3, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "CreatePed", (IEnumerable<System.Type>) null, typeof (TheDiamondHeist), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__10.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__10, typeof (World), AIskin[T3Skin.Index], new Vector3(400.3f, -956.5f, -100f), -88);
            this.RobberC = target((CallSite) p11, obj);
            this.RobberC.FreezePosition = true;
            this.Setoutfit(this.RobberC, T3Skin.Index);
            this.PlayAnimation(this.RobberC);
            if (T3Skin.Index > 26)
            {
              this.OutfitReq = "No Requirement";
              // ISSUE: reference to a compiler-generated field
              if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__12 == null)
              {
                // ISSUE: reference to a compiler-generated field
                TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, PedHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (PedHash), typeof (TheDiamondHeist)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.RobberCSkin = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__12.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__12, AIskin[T3Skin.Index]);
              this.RobberC_C = T3Skin.Index;
              if (this.RobberC_C == 39)
                this.SetOutift(this.RobberC, 1);
              if (this.RobberC_C == 40)
                this.SetOutift(this.RobberC, 2);
              if (this.RobberC_C == 41)
                this.SetOutift(this.RobberC, 3);
              if (this.RobberC_C == 42)
                this.SetOutift(this.RobberC, 4);
              if (this.RobberC_C == 43)
                this.SetOutift(this.RobberC, 5);
              if (this.RobberC_C == 44)
                this.SetOutift(this.RobberC, 6);
              if (this.RobberC_C == 45)
                this.SetOutift(this.RobberC, 7);
            }
            this.OutfitReq = "No Requirement";
            // ISSUE: reference to a compiler-generated field
            if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__13 == null)
            {
              // ISSUE: reference to a compiler-generated field
              TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, PedHash>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (PedHash), typeof (TheDiamondHeist)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.RobberCSkin = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__13.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__13, AIskin[T3Skin.Index]);
            this.RobberC_C = T3Skin.Index;
            if (T3Skin.Index == 6)
            {
              this.Setoutfit(this.RobberC, 21);
              this.RobberC_C = 21;
            }
          }
          else
          {
            if ((Entity) this.RobberC != (Entity) null)
              this.RobberC.Delete();
            this.RobberC_C = 0;
          }
        }
        float num;
        if ((item == T3S || item == T3) && T3.Index == 1)
        {
          this.TeamAI3Cost = (uint) T3S.Index <= 0U ? this.BaseCrewCost : this.BaseCrewCost + (float) ((double) this.BaseCrewCost * (double) T3S.Index * (double) T3S.Index / 10.0);
          this.TotalCost = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
          UIMenuItem uiMenuItem6 = CrewCut;
          num = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
          string str = "CrewCut : $" + num.ToString("N");
          uiMenuItem6.Text = str;
        }
        if ((item == T2S || item == T2) && T2.Index == 1)
        {
          this.TeamAI2Cost = (uint) T2S.Index <= 0U ? this.BaseCrewCost : this.BaseCrewCost + (float) ((double) this.BaseCrewCost * (double) T2S.Index * (double) T2S.Index / 10.0);
          this.TotalCost = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
          UIMenuItem uiMenuItem6 = CrewCut;
          num = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
          string str = "CrewCut : $" + num.ToString("N");
          uiMenuItem6.Text = str;
        }
        if ((item == T1S || item == T1) && T1.Index == 1)
        {
          this.TeamAI1Cost = (uint) T1S.Index <= 0U ? this.BaseCrewCost : this.BaseCrewCost + (float) ((double) this.BaseCrewCost * (double) T1S.Index * (double) T1S.Index / 10.0);
          this.TotalCost = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
          UIMenuItem uiMenuItem6 = CrewCut;
          num = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
          string str = "CrewCut : $" + num.ToString("N");
          uiMenuItem6.Text = str;
        }
        if (item != H)
          return;
        this.HackerCost = (uint) H.Index <= 0U ? 90000f : (float) (90000 + 90000 * H.Index * H.Index / 10);
        this.TotalCost = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
        UIMenuItem uiMenuItem7 = CrewCut;
        num = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
        string str1 = "CrewCut : $" + num.ToString("N");
        uiMenuItem7.Text = str1;
      });
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Start)
          return;
        // ISSUE: reference to a compiler-generated field
        if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, FiringPattern>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (FiringPattern), typeof (TheDiamondHeist)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.RobberAFP = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__14.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__14, FP[T1FP.Index]);
        // ISSUE: reference to a compiler-generated field
        if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__15 == null)
        {
          // ISSUE: reference to a compiler-generated field
          TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, FiringPattern>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (FiringPattern), typeof (TheDiamondHeist)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.RobberBFP = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__15.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__15, FP[T2FP.Index]);
        // ISSUE: reference to a compiler-generated field
        if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__16 == null)
        {
          // ISSUE: reference to a compiler-generated field
          TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, FiringPattern>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (FiringPattern), typeof (TheDiamondHeist)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.RobberCFP = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__16.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__16, FP[T3FP.Index]);
        this.SetupAi = true;
        // ISSUE: reference to a compiler-generated field
        if (TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (TheDiamondHeist)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.ID_C = TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__17.Target((CallSite) TheDiamondHeist.\u003C\u003Eo__427.\u003C\u003Ep__17, Colours[C.Index]);
        if ((Entity) this.RobberA != (Entity) null)
          this.RobberA.Delete();
        if ((Entity) this.RobberB != (Entity) null)
          this.RobberB.Delete();
        if ((Entity) this.RobberC != (Entity) null)
          this.RobberC.Delete();
        if (this.HeistStartCam != (Camera) null)
        {
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.HeistStartCam.IsActive = false;
          this.HeistStartCam.Destroy();
          Game.Player.Character.FreezePosition = false;
          Game.Player.CanControlCharacter = true;
        }
        if (T3.Index == 1)
        {
          if (T3.Index == 1)
            this.TeamAI3Cost = (uint) T3S.Index <= 0U ? this.BaseCrewCost : this.BaseCrewCost + (float) ((double) this.BaseCrewCost * (double) T3S.Index * (double) T3S.Index / 10.0);
        }
        else
          this.TeamAI3Cost = 0.0f;
        if (T2.Index == 1)
        {
          if (T2.Index == 1)
            this.TeamAI2Cost = (uint) T2S.Index <= 0U ? this.BaseCrewCost : this.BaseCrewCost + (float) ((double) this.BaseCrewCost * (double) T2S.Index * (double) T2S.Index / 10.0);
        }
        else
          this.TeamAI2Cost = 0.0f;
        if (T1.Index == 1)
        {
          if (T1.Index == 1)
            this.TeamAI1Cost = (uint) T1S.Index <= 0U ? this.BaseCrewCost : this.BaseCrewCost + (float) ((double) this.BaseCrewCost * (double) T1S.Index * (double) T1S.Index / 10.0);
        }
        else
          this.TeamAI1Cost = 0.0f;
        this.HackerCost = (uint) H.Index <= 0U ? 90000f : (float) (90000 + 90000 * H.Index * H.Index / 10);
        this.TotalCost = this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost;
        CrewCut.Text = "CrewCut : $" + (this.HackerCost + this.TeamAI1Cost + this.TeamAI2Cost + this.TeamAI3Cost + this.TeamAI4Cost).ToString("N");
        this.RobberAskill = (uint) T1.Index <= 0U ? 0 : T1S.Index + 1;
        this.RobberBskill = (uint) T2.Index <= 0U ? 0 : T2S.Index + 1;
        this.RobberCskill = (uint) T3.Index <= 0U ? 0 : T3S.Index + 1;
        if (H.Index != 6)
          this.Hackerskill = H.Index;
        if (H.Index == 6)
          this.Hackerskill = 5;
        if ((Entity) this.RobberC != (Entity) null)
          this.RobberC.Delete();
        if ((Entity) this.RobberB != (Entity) null)
          this.RobberB.Delete();
        if ((Entity) this.RobberA != (Entity) null)
          this.RobberA.Delete();
        this.CameraON = false;
        if (this.HeistStartCam != (Camera) null)
        {
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.HeistStartCam.IsActive = false;
          this.HeistStartCam.Destroy();
        }
        if (!this.SetupAi)
        {
          if ((Entity) this.RobberC != (Entity) null)
          {
            UI.Notify("DELETE");
            this.RobberC.Delete();
          }
          if ((Entity) this.RobberB != (Entity) null)
            this.RobberB.Delete();
          if ((Entity) this.RobberA != (Entity) null)
            this.RobberA.Delete();
        }
        Game.Player.Character.Position = new Vector3(2713.18f, -369.25f, -54.5f);
        Game.Player.Character.FreezePosition = false;
        Game.Player.CanControlCharacter = true;
        this.modMenuPool.CloseAllMenus();
        Script.Wait(50);
        this.EndofHiest();
        Script.Wait(50);
        this.SetupAi = false;
      });
    }

    public void PlayDealerAnim(Ped ped)
    {
      System.Random random = new System.Random();
      float num = (float) random.Next(1, 27);
      ped.BlockPermanentEvents = true;
      if ((double) num < 2.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@threecardpoker@dealer", "deck_shuffle", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 2.0 && (double) num < 5.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@blackjack@dealer_female", "dealer_idle", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 5.0 && (double) num < 7.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@blackjack@dealer_female", "dealer_focus_player_01_idle", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 7.0 && (double) num < 10.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@shared@dealer@", "female_idle_var_01", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 10.0 && (double) num < 12.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@shared@dealer@", "female_idle_var_02", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 12.0 && (double) num < 14.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@shared@dealer@", "female_idle_var_03", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 14.0 && (double) num < 17.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@shared@dealer@", "female_idle_var_04", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 17.0 && (double) num < 20.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@shared@dealer@", "female_idle_var_05", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 20.0 && (double) num < 23.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@shared@dealer@", "female_idle_var_06", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 23.0 && (double) num < 25.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@shared@dealer@", "female_idle_var_07", (float) random.Next(64, 320), -1, true, -1f);
      if ((double) num >= 25.0 && (double) num < 28.0)
        ped.Task.PlayAnimation("anim_casino_b@amb@casino@games@shared@dealer@", "female_idle_var_08", (float) random.Next(64, 320), -1, true, -1f);
      ped.AlwaysKeepTask = true;
    }

    public void SetPedOutfit(Ped ped)
    {
      System.Random random = new System.Random();
      int num1 = random.Next(1, 9);
      if (num1 == 1)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num2 = random.Next(0, 5);
        int num3 = random.Next(0, 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num2, (InputArgument) num3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
        int num4 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num4, (InputArgument) 0, (InputArgument) 1);
        int num5 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) num5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num6 = random.Next(0, 1);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) num6, (InputArgument) 1);
      }
      if (num1 == 2)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num2 = random.Next(0, 5);
        int num3 = random.Next(0, 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num2, (InputArgument) num3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num4 = random.Next(0, 2);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num4, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      }
      if (num1 == 3)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num2 = random.Next(0, 5);
        int num3 = random.Next(0, 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num2, (InputArgument) num3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num4 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num4, (InputArgument) 0, (InputArgument) 1);
        int num5 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) num5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num6 = random.Next(0, 1);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) num6, (InputArgument) 1);
      }
      if (num1 == 4)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num2 = random.Next(0, 5);
        int num3 = random.Next(0, 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num2, (InputArgument) num3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 1, (InputArgument) 2, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num4 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num4, (InputArgument) 0, (InputArgument) 1);
        int num5 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) num5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num6 = random.Next(0, 1);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) num6, (InputArgument) 1);
      }
      if (num1 == 5)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num2 = random.Next(0, 5);
        int num3 = random.Next(0, 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num2, (InputArgument) num3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 1, (InputArgument) 2, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num4 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num4, (InputArgument) 0, (InputArgument) 1);
        int num5 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) num5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num6 = random.Next(0, 1);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) num6, (InputArgument) 1);
      }
      if (num1 == 6)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num2 = random.Next(0, 5);
        int num3 = random.Next(0, 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num2, (InputArgument) num3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
        int num4 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num4, (InputArgument) 0, (InputArgument) 1);
        int num5 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) num5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        random.Next(0, 1);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
      }
      if (num1 == 7)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num2 = random.Next(0, 5);
        int num3 = random.Next(0, 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num2, (InputArgument) num3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
        int num4 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num4, (InputArgument) 0, (InputArgument) 1);
        random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        random.Next(0, 1);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
      }
      if (num1 == 8)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num2 = random.Next(0, 5);
        int num3 = random.Next(0, 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num2, (InputArgument) num3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 1, (InputArgument) 2, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num4 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num4, (InputArgument) 0, (InputArgument) 1);
        int num5 = random.Next(0, 2);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) num5, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        random.Next(0, 1);
        Script.Wait(1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
      }
      if (num1 != 9)
        return;
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 0, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      int num7 = random.Next(0, 5);
      int num8 = random.Next(0, 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 2, (InputArgument) num7, (InputArgument) num8, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 3, (InputArgument) 1, (InputArgument) 2, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 4, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      int num9 = random.Next(0, 2);
      Script.Wait(1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 7, (InputArgument) num9, (InputArgument) 0, (InputArgument) 1);
      random.Next(0, 2);
      Script.Wait(1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 9, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      random.Next(0, 1);
      Script.Wait(1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) ped, (InputArgument) 11, (InputArgument) 0, (InputArgument) 1, (InputArgument) 1);
    }

    public void SetupPedCostume(Ped p)
    {
      float num = (float) new System.Random().Next(0, 275);
      if ((double) num < 200.0)
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) p, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) false);
      if ((double) num > 200.0)
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) p, (InputArgument) 0, (InputArgument) 1, (InputArgument) 0, (InputArgument) false);
      if ((double) num > 225.0)
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) p, (InputArgument) 0, (InputArgument) 2, (InputArgument) 0, (InputArgument) false);
      if ((double) num <= 250.0)
        return;
      Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) p, (InputArgument) 0, (InputArgument) 3, (InputArgument) 0, (InputArgument) false);
    }

    public void SetupHeiststuff()
    {
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "vw_int_placement_vw_interior_0_dlc_casino_main_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "vw_int_placement_vw_interior_2_dlc_casino_garage_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "vw_int_placement_vw_interior_4_dlc_casino_carpark_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "vw_casino_carpark");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "vw_casino_main");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "vw_casino_garage");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "vw_int_placement_vw_interior_0_dlc_casino_main_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "vw_int_placement_vw_interior_2_dlc_casino_garage_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "vw_int_placement_vw_interior_4_dlc_casino_carpark_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "vw_casino_carpark");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "vw_casino_main");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "vw_casino_garage");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_9_dlc_casino_shaft_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_8_dlc_tunnel_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_6_dlc_casino_vault_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_5_dlc_casino_loading_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_4_dlc_casino_hotel_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_3_dlc_casino_back_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_2_dlc_plan_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_1_dlc_arcade_milo_");
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "ch_int_placement_ch_interior_0_dlc_casino_heist_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_9_dlc_casino_shaft_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_8_dlc_tunnel_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_6_dlc_casino_vault_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_5_dlc_casino_loading_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_4_dlc_casino_hotel_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_3_dlc_casino_back_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_2_dlc_plan_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_1_dlc_arcade_milo_");
      Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "ch_int_placement_ch_interior_0_dlc_casino_heist_milo_");
      int num1 = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 2488.348, (InputArgument) -267.3637, (InputArgument) -71.64563);
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_Vault_Door");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "set_vault_dressing");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_vault_cash_01");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_vault_cash_02");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_vault_gold_01");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_vault_gold_02");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_vault_art_01");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_vault_art_02");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_vault_diamonds_01");
      Function.Call(Hash._0x420BD37289EEE162, (InputArgument) num1, (InputArgument) "Set_vault_diamonds_02");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_Vault_Door");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_vault_cash_01");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_vault_cash_02");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_vault_gold_01");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_vault_gold_02");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_vault_art_01");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_vault_art_02");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_vault_diamonds_01");
      Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num1, (InputArgument) "Set_vault_diamonds_02");
      if ((Entity) this.VaultDoor != (Entity) null)
        this.VaultDoor.Delete();
      if ((Entity) this.HackConsole != (Entity) null)
        this.HackConsole.Delete();
      this.HackConsole = World.CreateProp(this.RequestModel("ch_prop_fingerprint_scanner_01e"), new Vector3(2464.9f, -276.05f, -70.6f), new Vector3(0.0f, 0.0f, 70f), false, false);
      this.HackConsole.FreezePosition = true;
      if ((Entity) this.Vent != (Entity) null)
        this.Vent.Delete();
      this.Vent = World.CreateProp(this.RequestModel("prop_roofvent_07a"), new Vector3(2493.1f, -252.6f, -72f), new Vector3(0.0f, 0.0f, -90f), true, false);
      this.Vent.FreezePosition = true;
      foreach (Prop smokeEmitter in this.SmokeEmitters)
      {
        if ((Entity) smokeEmitter != (Entity) null)
          smokeEmitter.Delete();
      }
      foreach (Blip blip in this.HubPointsBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      foreach (Prop crateValuable in this.Crate_Valuables)
      {
        if ((Entity) crateValuable != (Entity) null)
          crateValuable.Delete();
      }
      foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
      {
        if ((Entity) aircarftCarrierPed != (Entity) null)
          aircarftCarrierPed.Delete();
      }
      foreach (Vehicle aircraftCarrierVehicle in this.AircraftCarrierVehicles)
      {
        if ((Entity) aircraftCarrierVehicle != (Entity) null)
          aircraftCarrierVehicle.Delete();
      }
      if ((Entity) this.WheelProp != (Entity) null)
        this.WheelProp.Delete();
      if ((Entity) this.WheelProp2 != (Entity) null)
        this.WheelProp2.Delete();
      if ((Entity) this.BasePlate != (Entity) null)
        this.BasePlate.Delete();
      foreach (Ped ped in this.MainPed)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      foreach (Prop table in this.Tables)
      {
        if ((Entity) table != (Entity) null)
          table.Delete();
      }
      foreach (Prop prop in this.Tables2)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if ((Entity) this.Prizecar != (Entity) null)
        this.Prizecar.Delete();
      foreach (Ped ped in this.SMPed)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      this.AI_Pos.Clear();
      this.AI_Type.Clear();
      this.AI_Rot.Clear();
      Script.Wait(1000);
      this.SpawnProp("ch_prop_ch_metal_detector_01a", new Vector3(2525.6f, -270f, -59.8f), new Vector3(0.0f, 0.0f, -90f));
      this.SpawnProp("ch_prop_ch_metal_detector_01a", new Vector3(2525.6f, -268.4f, -59.8f), new Vector3(0.0f, 0.0f, -90f));
      this.SpawnProp("ch_prop_baggage_scanner_01a", new Vector3(2525.6f, -267.3f, -59.8f), new Vector3(0.0f, 0.0f, -90f));
      this.SpawnProp("ch_prop_ch_sec_cabinet_04a", new Vector3(2525.6f, -271.6f, -59.8f), new Vector3(0.0f, 0.0f, -90f));
      this.SpawnProp("ch_prop_ch_sec_cabinet_04a", new Vector3(2525.9f, -271.6f, -59.8f), new Vector3(0.0f, 0.0f, 90f));
      this.PlantedBZGas = false;
      Vector3 position1 = Game.Player.Character.Position;
      this.AircraftCarrierVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Stockade), new Vector3(2524.9f, -271f, -65f), 180f));
      this.AircraftCarrierVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Stockade), new Vector3(2533.4f, -288.1f, -65.1f), 0.0f));
      this.AircraftCarrierVehicles.Add(World.CreateVehicle(this.RequestModel(VehicleHash.Stockade), new Vector3(2542.5f, -288.5f, -65.1f), 0.0f));
      Ped ped1 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2496.8f, -243.9f, -70f), -2f);
      this.AircarftCarrierPeds.Add(ped1);
      this.SetupPedCostume(ped1);
      this.AI_Pos.Add(ped1.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped1.Rotation);
      Ped ped2 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2483.2f, -273.3f, -70f), 88f);
      this.AircarftCarrierPeds.Add(ped2);
      this.SetupPedCostume(ped2);
      this.AI_Pos.Add(ped2.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped2.Rotation);
      Ped ped3 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2492.9f, -268.9f, -70f), 92f);
      this.AircarftCarrierPeds.Add(ped3);
      this.SetupPedCostume(ped3);
      this.AI_Pos.Add(ped3.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped3.Rotation);
      Ped ped4 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2486.8f, -281.8f, -72.3f), -1f);
      this.AircarftCarrierPeds.Add(ped4);
      this.SetupPedCostume(ped4);
      ped4.Task.PlayAnimation("anim@amb@office@seating@male@var_e@base@", "base", 8f, -1, true, -1f);
      ped4.FreezePosition = true;
      this.AI_Pos.Add(ped4.Position);
      this.AI_Type.Add(1);
      this.AI_Rot.Add(ped4.Rotation);
      Ped ped5 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2485.7f, -276.1f, -71.8f), 165f);
      this.AircarftCarrierPeds.Add(ped5);
      this.SetupPedCostume(ped5);
      ped5.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped5.FreezePosition = true;
      this.AI_Pos.Add(ped5.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped5.Rotation);
      Ped ped6 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2479.7f, 268.1f, -70f), 179f);
      this.AircarftCarrierPeds.Add(ped6);
      this.SetupPedCostume(ped6);
      this.AI_Pos.Add(ped6.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped6.Rotation);
      Ped ped7 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2486.2f, -255.1f, -70f), -83f);
      this.AircarftCarrierPeds.Add(ped7);
      this.SetupPedCostume(ped7);
      this.AI_Pos.Add(ped7.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped7.Rotation);
      Ped ped8 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2552f, -286.6f, -59.6f), 15f);
      this.AircarftCarrierPeds.Add(ped8);
      this.SetupPedCostume(ped8);
      ped8.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped8.FreezePosition = true;
      this.AI_Pos.Add(ped8.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped8.Rotation);
      Ped ped9 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2548.3f, -289.2f, -59.6f), 116f);
      this.AircarftCarrierPeds.Add(ped9);
      this.SetupPedCostume(ped9);
      ped9.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped9.FreezePosition = true;
      this.AI_Pos.Add(ped9.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped9.Rotation);
      Ped ped10 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2550.2f, -292f, -59.6f), -64f);
      this.AircarftCarrierPeds.Add(ped10);
      this.SetupPedCostume(ped10);
      ped10.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped10.FreezePosition = true;
      this.AI_Pos.Add(ped10.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped10.Rotation);
      Ped ped11 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2527.9f, -278f, -59.6f), -93f);
      this.AircarftCarrierPeds.Add(ped11);
      this.SetupPedCostume(ped11);
      ped11.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped11.FreezePosition = true;
      this.AI_Pos.Add(ped11.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped11.Rotation);
      Ped ped12 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2531.8f, -279.2f, -59.6f), -91f);
      this.AircarftCarrierPeds.Add(ped12);
      this.SetupPedCostume(ped12);
      ped12.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped12.FreezePosition = true;
      this.AI_Pos.Add(ped12.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped12.Rotation);
      Ped ped13 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2538.7f, -275.7f, -59.6f), -73f);
      this.AircarftCarrierPeds.Add(ped13);
      this.SetupPedCostume(ped13);
      ped13.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped13.FreezePosition = true;
      this.AI_Pos.Add(ped13.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped13.Rotation);
      Ped ped14 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2533.3f, -271.8f, -59.6f), -4f);
      this.AircarftCarrierPeds.Add(ped14);
      this.SetupPedCostume(ped14);
      ped14.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped14.FreezePosition = true;
      this.AI_Pos.Add(ped14.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped14.Rotation);
      Ped ped15 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2536.7f, -266.6f, -60f), 169f);
      this.AircarftCarrierPeds.Add(ped15);
      this.SetupPedCostume(ped15);
      this.AI_Pos.Add(ped15.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped15.Rotation);
      Ped ped16 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2544.9f, -281.9f, -60f), 82f);
      this.AircarftCarrierPeds.Add(ped16);
      this.SetupPedCostume(ped16);
      this.AI_Pos.Add(ped16.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped16.Rotation);
      Ped ped17 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2532.4f, -285.3f, -60f), -180f);
      this.AircarftCarrierPeds.Add(ped17);
      this.SetupPedCostume(ped17);
      this.AI_Pos.Add(ped17.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped17.Rotation);
      Ped ped18 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2521.5f, -296.9f, -60f), 180f);
      this.AircarftCarrierPeds.Add(ped18);
      this.SetupPedCostume(ped18);
      this.AI_Pos.Add(ped18.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped18.Rotation);
      Ped ped19 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2537.2f, -300f, -60f), 0.0f);
      this.AircarftCarrierPeds.Add(ped19);
      this.SetupPedCostume(ped19);
      this.AI_Pos.Add(ped19.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped19.Rotation);
      Ped ped20 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2505.9f, -284.5f, -60f), 80f);
      this.AircarftCarrierPeds.Add(ped20);
      this.SetupPedCostume(ped20);
      this.AI_Pos.Add(ped20.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped20.Rotation);
      Ped ped21 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2503.6f, -267.8f, -59.7f), 8f);
      this.AircarftCarrierPeds.Add(ped21);
      this.SetupPedCostume(ped21);
      ped21.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped21.FreezePosition = true;
      this.AI_Pos.Add(ped21.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped21.Rotation);
      Ped ped22 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2523.1f, -276.5f, -60f), 96f);
      this.AircarftCarrierPeds.Add(ped22);
      this.SetupPedCostume(ped22);
      this.AI_Pos.Add(ped22.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped22.Rotation);
      Ped ped23 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2546.5f, -249.8f, -60f), -6f);
      this.AircarftCarrierPeds.Add(ped23);
      this.SetupPedCostume(ped23);
      this.AI_Pos.Add(ped23.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped23.Rotation);
      Ped ped24 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2551.2f, -237f, -60f), 91f);
      this.AircarftCarrierPeds.Add(ped24);
      this.SetupPedCostume(ped24);
      this.AI_Pos.Add(ped24.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped24.Rotation);
      Ped ped25 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2547.5f, -265.6f, -60f), 180f);
      this.AircarftCarrierPeds.Add(ped25);
      this.SetupPedCostume(ped25);
      this.AI_Pos.Add(ped25.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped25.Rotation);
      Ped ped26 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2506f, -238.8f, -56f), -12f);
      this.AircarftCarrierPeds.Add(ped26);
      this.SetupPedCostume(ped26);
      this.AI_Pos.Add(ped26.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped26.Rotation);
      Ped ped27 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2510.9f, -252.9f, -56f), 82f);
      this.AircarftCarrierPeds.Add(ped27);
      this.SetupPedCostume(ped27);
      this.AI_Pos.Add(ped27.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped27.Rotation);
      Ped ped28 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2507.6f, -260f, -56f), -18f);
      this.AircarftCarrierPeds.Add(ped28);
      this.SetupPedCostume(ped28);
      this.AI_Pos.Add(ped28.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped28.Rotation);
      Ped ped29 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2488.4f, -256.2f, -40f), 164f);
      this.AircarftCarrierPeds.Add(ped29);
      this.SetupPedCostume(ped29);
      this.AI_Pos.Add(ped29.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped29.Rotation);
      Ped ped30 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2506.2f, -254.1f, -40f), 180f);
      this.AircarftCarrierPeds.Add(ped30);
      this.SetupPedCostume(ped30);
      this.AI_Pos.Add(ped30.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped30.Rotation);
      Ped ped31 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2520.7f, -255.1f, -24f), -180f);
      this.AircarftCarrierPeds.Add(ped31);
      this.SetupPedCostume(ped31);
      this.AI_Pos.Add(ped31.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped31.Rotation);
      Ped ped32 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2521.1f, -260.3f, -40f), -88f);
      this.AircarftCarrierPeds.Add(ped32);
      this.SetupPedCostume(ped32);
      this.AI_Pos.Add(ped32.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped32.Rotation);
      Ped ped33 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2504.2f, -287.4f, -40f), -175f);
      this.AircarftCarrierPeds.Add(ped33);
      this.SetupPedCostume(ped33);
      this.AI_Pos.Add(ped33.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped33.Rotation);
      Ped ped34 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2486.8f, -260.6f, -40f), -90f);
      this.AircarftCarrierPeds.Add(ped34);
      this.SetupPedCostume(ped34);
      this.AI_Pos.Add(ped34.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped34.Rotation);
      Ped ped35 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2489.4f, -286.6f, -40f), 90f);
      this.AircarftCarrierPeds.Add(ped35);
      this.SetupPedCostume(ped35);
      this.AI_Pos.Add(ped35.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped35.Rotation);
      Ped ped36 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2505.1f, -291.1f, -40f), 0.0f);
      this.AircarftCarrierPeds.Add(ped36);
      this.SetupPedCostume(ped36);
      this.AI_Pos.Add(ped36.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped36.Rotation);
      Ped ped37 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2522.2f, -286.1f, -40f), -90f);
      this.AircarftCarrierPeds.Add(ped37);
      this.SetupPedCostume(ped37);
      this.AI_Pos.Add(ped37.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped37.Rotation);
      Ped ped38 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2524.8f, -246.6f, -40f), 90f);
      this.AircarftCarrierPeds.Add(ped38);
      this.SetupPedCostume(ped38);
      this.AI_Pos.Add(ped38.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped38.Rotation);
      Ped ped39 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2516.5f, -232f, -40f), 180f);
      this.AircarftCarrierPeds.Add(ped39);
      this.SetupPedCostume(ped39);
      this.AI_Pos.Add(ped39.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped39.Rotation);
      Ped ped40 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2502.3f, -250.5f, -40f), -90f);
      this.AircarftCarrierPeds.Add(ped40);
      this.SetupPedCostume(ped40);
      this.AI_Pos.Add(ped40.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped40.Rotation);
      Ped ped41 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2524.8f, -254.3f, -40f), 90f);
      this.AircarftCarrierPeds.Add(ped41);
      this.SetupPedCostume(ped41);
      this.AI_Pos.Add(ped41.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped41.Rotation);
      Ped ped42 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2519.8f, -267.5f, -60f), 90f);
      this.AircarftCarrierPeds.Add(ped42);
      this.SetupPedCostume(ped42);
      this.AI_Pos.Add(ped42.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped42.Rotation);
      Ped ped43 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2532.4f, -292.9f, -60f), 0.0f);
      this.AircarftCarrierPeds.Add(ped43);
      this.SetupPedCostume(ped43);
      this.AI_Pos.Add(ped43.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped43.Rotation);
      Ped ped44 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2513.4f, -292.8f, -60f), 0.0f);
      this.AircarftCarrierPeds.Add(ped44);
      this.SetupPedCostume(ped44);
      this.AI_Pos.Add(ped44.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped44.Rotation);
      Ped ped45 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2552.7f, -284.8f, -60f), 0.0f);
      this.AircarftCarrierPeds.Add(ped45);
      this.SetupPedCostume(ped45);
      this.AI_Pos.Add(ped45.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped45.Rotation);
      Ped ped46 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2546.7f, -290.3f, -60f), 90f);
      this.AircarftCarrierPeds.Add(ped46);
      this.SetupPedCostume(ped46);
      this.AI_Pos.Add(ped46.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped46.Rotation);
      Ped ped47 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2514.7f, -273.5f, -60f), -180f);
      this.AircarftCarrierPeds.Add(ped47);
      this.SetupPedCostume(ped47);
      this.AI_Pos.Add(ped47.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped47.Rotation);
      Ped ped48 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2537.2f, -288.8f, -60f), 0.0f);
      this.AircarftCarrierPeds.Add(ped48);
      this.SetupPedCostume(ped48);
      this.AI_Pos.Add(ped48.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped48.Rotation);
      Ped ped49 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2520.8f, -278.2f, -70f), -90f);
      this.AircarftCarrierPeds.Add(ped49);
      this.SetupPedCostume(ped49);
      this.AI_Pos.Add(ped49.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped49.Rotation);
      Ped ped50 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2528.4f, -276.7f, -72.3f), -176f);
      this.AircarftCarrierPeds.Add(ped50);
      this.SetupPedCostume(ped50);
      ped50.Task.PlayAnimation("anim@amb@office@seating@male@var_e@base@", "base", 8f, -1, true, -1f);
      ped50.FreezePosition = true;
      this.AI_Pos.Add(ped50.Position);
      this.AI_Type.Add(1);
      this.AI_Rot.Add(ped50.Rotation);
      Ped ped51 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2531.7f, -280.7f, -72.3f), 46f);
      this.AircarftCarrierPeds.Add(ped51);
      this.SetupPedCostume(ped51);
      ped51.Task.PlayAnimation("anim@amb@office@seating@male@var_e@base@", "base", 8f, -1, true, -1f);
      ped51.FreezePosition = true;
      this.AI_Pos.Add(ped51.Position);
      this.AI_Type.Add(1);
      this.AI_Rot.Add(ped51.Rotation);
      Ped ped52 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2501.5f, -274.2f, -70f), -90f);
      this.AircarftCarrierPeds.Add(ped52);
      this.SetupPedCostume(ped52);
      this.AI_Pos.Add(ped52.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped52.Rotation);
      Ped ped53 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2474.1f, -268.1f, -71.8f), -97f);
      this.AircarftCarrierPeds.Add(ped53);
      this.SetupPedCostume(ped53);
      ped53.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped53.FreezePosition = true;
      this.AI_Pos.Add(ped53.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped53.Rotation);
      Ped ped54 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2472.6f, -271.1f, -71.8f), 171f);
      this.AircarftCarrierPeds.Add(ped54);
      this.SetupPedCostume(ped54);
      ped54.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped54.FreezePosition = true;
      this.AI_Pos.Add(ped54.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped54.Rotation);
      Ped ped55 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2498.3f, -234.5f, -71.8f), 177f);
      this.AircarftCarrierPeds.Add(ped55);
      this.SetupPedCostume(ped55);
      ped55.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped55.FreezePosition = true;
      this.AI_Pos.Add(ped55.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped55.Rotation);
      Ped ped56 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2552.1f, -286.5f, -65.8f), 18f);
      this.AircarftCarrierPeds.Add(ped56);
      this.SetupPedCostume(ped56);
      ped56.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped56.FreezePosition = true;
      this.AI_Pos.Add(ped56.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped56.Rotation);
      Ped ped57 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2548.4f, -289.2f, -65.8f), 109f);
      this.AircarftCarrierPeds.Add(ped57);
      this.SetupPedCostume(ped57);
      ped57.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped57.FreezePosition = true;
      this.AI_Pos.Add(ped57.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped57.Rotation);
      Ped ped58 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2550.5f, -291.9f, -65.8f), -58f);
      this.AircarftCarrierPeds.Add(ped58);
      this.SetupPedCostume(ped58);
      ped58.Task.PlayAnimation("anim@amb@office@pa@male@", "pa_base", 8f, -1, true, -1f);
      ped58.FreezePosition = true;
      this.AI_Pos.Add(ped58.Position);
      this.AI_Type.Add(2);
      this.AI_Rot.Add(ped58.Rotation);
      Ped ped59 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(2520.8f, -277.5f, -65f), -96f);
      this.AircarftCarrierPeds.Add(ped59);
      this.SetupPedCostume(ped59);
      this.AI_Pos.Add(ped59.Position);
      this.AI_Type.Add(0);
      this.AI_Rot.Add(ped59.Rotation);
      this.VaultDoor = World.CreateProp(this.RequestModel("prop_com_gar_door_01"), new Vector3(2506.7f, -269.5f, -58f), new Vector3(0.0f, 0.0f, 90f), true, false);
      this.VaultDoor.IsVisible = false;
      this.VaultDoor.FreezePosition = true;
      this.CreatedCrates = false;
      this.HubPointsBlip.Clear();
      this.Crate_loc.Clear();
      this.Crate_Rot.Clear();
      this.Crate_Type.Clear();
      Script.Wait(10);
      this.Crate_loc.Add(new Vector3(2514.2f, -218.6f, -71.8f));
      this.Crate_Rot.Add(19f);
      this.Crate_loc.Add(new Vector3(2516.9f, -217.9f, -71.8f));
      this.Crate_Rot.Add(10f);
      this.Crate_loc.Add(new Vector3(2519.6f, -217.4f, -71.8f));
      this.Crate_Rot.Add(4f);
      this.Crate_loc.Add(new Vector3(2522.4f, -217.5f, -71.8f));
      this.Crate_Rot.Add(-6f);
      this.Crate_loc.Add(new Vector3(2525.2f, -217.8f, -71.8f));
      this.Crate_Rot.Add(-10f);
      this.Crate_loc.Add(new Vector3(2527.9f, -218.5f, -71.8f));
      this.Crate_Rot.Add(-20f);
      this.Crate_loc.Add(new Vector3(2541.1f, -231.6f, -71.8f));
      this.Crate_Rot.Add(-72f);
      this.Crate_loc.Add(new Vector3(2541.7f, -234.3f, -71.8f));
      this.Crate_Rot.Add(-69f);
      this.Crate_loc.Add(new Vector3(2542.2f, -237.2f, -71.8f));
      this.Crate_Rot.Add(-90f);
      this.Crate_loc.Add(new Vector3(2542.2f, -239.9f, -71.8f));
      this.Crate_Rot.Add(-92f);
      this.Crate_loc.Add(new Vector3(2541.7f, -242.6f, -71.8f));
      this.Crate_Rot.Add(-97f);
      this.Crate_loc.Add(new Vector3(2541.1f, -245.4f, -71.8f));
      this.Crate_Rot.Add(-105f);
      this.Crate_loc.Add(new Vector3(2527.8f, -258.5f, -71.8f));
      this.Crate_Rot.Add(-164f);
      this.Crate_loc.Add(new Vector3(2525.06f, -259.1f, -71.8f));
      this.Crate_Rot.Add(-166f);
      this.Crate_loc.Add(new Vector3(2522.3f, -259.6f, -71.8f));
      this.Crate_Rot.Add(-176f);
      this.Crate_loc.Add(new Vector3(2519.5f, -259.4f, -71.8f));
      this.Crate_Rot.Add(176f);
      this.Crate_loc.Add(new Vector3(2516.9f, -259.1f, -71.8f));
      this.Crate_Rot.Add(163f);
      this.Crate_loc.Add(new Vector3(2514.2f, -258.4f, -71.8f));
      this.Crate_Rot.Add(159f);
      Script.Wait(10);
      System.Random random1 = new System.Random();
      for (int index = 0; index < this.Crate_loc.Count; ++index)
      {
        Vector3 vector3 = this.Crate_loc[index];
        if (true)
        {
          int num2 = random1.Next(0, 300);
          if (num2 < 33)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_ch_cash_trolly_01a"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(1f);
          }
          if (num2 >= 33 && num2 < 67)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_gold_trolly_01a"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(2f);
          }
          if (num2 >= 67 && num2 < 100)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_diamond_trolly_01a"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(3f);
          }
          if (num2 >= 100 && num2 < 133)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_ch_cash_trolly_01b"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(1f);
          }
          if (num2 >= 133 && num2 < 167)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_gold_trolly_01b"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(2f);
          }
          if (num2 >= 167 && num2 < 200)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_diamond_trolly_01b"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(3f);
          }
          if (num2 >= 200 && num2 < 233)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_ch_cash_trolly_01c"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(1f);
          }
          if (num2 >= 233 && num2 < 267)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_gold_trolly_01c"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(2f);
          }
          if (num2 >= 267 && num2 < 300)
          {
            Prop prop = World.CreateProp(this.RequestModel("ch_prop_diamond_trolly_01c"), this.Crate_loc[index], new Vector3(0.0f, 0.0f, this.Crate_Rot[index] - 180f), true, false);
            prop.FreezePosition = true;
            this.Crate_Valuables.Add(prop);
            this.Crate_Type.Add(3f);
          }
        }
      }
      this.CreatedCrates = true;
      if (this.EnteranceUsed == 0)
      {
        Ped ped60 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1086.9f, 210.2f, -49f), -103f);
        this.AircarftCarrierPeds.Add(ped60);
        this.SetupPedCostume(ped60);
        this.AI_Pos.Add(ped60.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped60.Rotation);
        Ped ped61 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1100.26f, 206.3f, -49.4f), -20f);
        this.AircarftCarrierPeds.Add(ped61);
        this.SetupPedCostume(ped61);
        this.AI_Pos.Add(ped61.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped61.Rotation);
        Ped ped62 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1117.4f, 216.6f, -49.4f), 135f);
        this.AircarftCarrierPeds.Add(ped62);
        this.SetupPedCostume(ped62);
        this.AI_Pos.Add(ped62.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped62.Rotation);
        Ped ped63 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1102.1f, 226.9f, -48.9f), -96f);
        this.AircarftCarrierPeds.Add(ped63);
        this.SetupPedCostume(ped63);
        this.AI_Pos.Add(ped63.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped63.Rotation);
        Ped ped64 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1098.8f, 238.1f, -50.4f), -39f);
        this.AircarftCarrierPeds.Add(ped64);
        this.SetupPedCostume(ped64);
        this.AI_Pos.Add(ped64.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped64.Rotation);
        Ped ped65 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1101.4f, 244.3f, -50.4f), 40f);
        this.AircarftCarrierPeds.Add(ped65);
        this.SetupPedCostume(ped65);
        this.AI_Pos.Add(ped65.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped65.Rotation);
        Ped ped66 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1109.4f, 257.8f, -50.4f), -97f);
        this.AircarftCarrierPeds.Add(ped66);
        this.SetupPedCostume(ped66);
        this.AI_Pos.Add(ped66.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped66.Rotation);
        Ped ped67 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1122.1f, 269.8f, -50.4f), -165f);
        this.AircarftCarrierPeds.Add(ped67);
        this.SetupPedCostume(ped67);
        this.AI_Pos.Add(ped67.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped67.Rotation);
        Ped ped68 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1139.8f, 243.6f, -50.4f), 130f);
        this.AircarftCarrierPeds.Add(ped68);
        this.SetupPedCostume(ped68);
        this.AI_Pos.Add(ped68.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped68.Rotation);
        Ped ped69 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1128.6f, 235.4f, -50.4f), -29f);
        this.AircarftCarrierPeds.Add(ped69);
        this.SetupPedCostume(ped69);
        this.AI_Pos.Add(ped69.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped69.Rotation);
        Ped ped70 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1122.9f, 262.5f, -51f), -81f);
        this.AircarftCarrierPeds.Add(ped70);
        this.SetupPedCostume(ped70);
        this.AI_Pos.Add(ped70.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped70.Rotation);
        Ped ped71 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1123f, 266.5f, -51f), -95f);
        this.AircarftCarrierPeds.Add(ped71);
        this.SetupPedCostume(ped71);
        this.AI_Pos.Add(ped71.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped71.Rotation);
        Ped ped72 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1138.1f, 270.5f, -51.4f), -165f);
        this.AircarftCarrierPeds.Add(ped72);
        this.SetupPedCostume(ped72);
        this.AI_Pos.Add(ped72.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped72.Rotation);
        Ped ped73 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1152.8f, 258.1f, -51.4f), 91f);
        this.AircarftCarrierPeds.Add(ped73);
        this.SetupPedCostume(ped73);
        this.AI_Pos.Add(ped73.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped73.Rotation);
        Ped ped74 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1111.077f, 264.44f, -50.6f), -93f);
        this.AircarftCarrierPeds.Add(ped74);
        this.SetupPedCostume(ped74);
        this.AI_Pos.Add(ped74.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped74.Rotation);
        Ped ped75 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1115.1f, 263.5f, -45.8f), 0.0f);
        this.AircarftCarrierPeds.Add(ped75);
        this.SetupPedCostume(ped75);
        this.AI_Pos.Add(ped75.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped75.Rotation);
        Ped ped76 = World.CreatePed(this.RequestModel("s_m_y_westsec_02"), new Vector3(1117.4f, 251.55f, -45.8f), -7.6f);
        this.AircarftCarrierPeds.Add(ped76);
        this.SetupPedCostume(ped76);
        this.AI_Pos.Add(ped76.Position);
        this.AI_Type.Add(0);
        this.AI_Rot.Add(ped76.Rotation);
        this.SlotMachines.Clear();
        this.SlotMachinesRot.Clear();
        this.SlotMachines.Add(new Vector3(1105.959f, 228.7872f, -49.8f));
        this.SlotMachinesRot.Add(35f);
        this.SlotMachines.Add(new Vector3(1106.344f, 230.4661f, -49.8f));
        this.SlotMachinesRot.Add(108f);
        this.SlotMachines.Add(new Vector3(1105.047f, 231.4999f, -49.8f));
        this.SlotMachinesRot.Add(178f);
        this.SlotMachines.Add(new Vector3(1103.892f, 230.5018f, -49.8f));
        this.SlotMachinesRot.Add(-107f);
        this.SlotMachines.Add(new Vector3(1101.564f, 230.6477f, -49.8f));
        this.SlotMachinesRot.Add(63f);
        this.SlotMachines.Add(new Vector3(1100.822f, 230.105f, -49.8f));
        this.SlotMachinesRot.Add(45f);
        this.SlotMachines.Add(new Vector3(1101.661f, 231.5672f, -49.8f));
        this.SlotMachinesRot.Add(73f);
        this.SlotMachines.Add(new Vector3(1101.94f, 232.4414f, -49.8f));
        this.SlotMachinesRot.Add(87f);
        this.SlotMachines.Add(new Vector3(1101.775f, 233.3168f, -49.8f));
        this.SlotMachinesRot.Add(101f);
        this.SlotMachines.Add(new Vector3(1107.15f, 234.9417f, -49.8f));
        this.SlotMachinesRot.Add(-111f);
        this.SlotMachines.Add(new Vector3(1107.558f, 233.311f, -49.8f));
        this.SlotMachinesRot.Add(-34f);
        this.SlotMachines.Add(new Vector3(1109.176f, 233.5511f, -49.8f));
        this.SlotMachinesRot.Add(32f);
        this.SlotMachines.Add(new Vector3(1109.793f, 234.9457f, -49.8f));
        this.SlotMachinesRot.Add(109f);
        this.SlotMachines.Add(new Vector3(1108.582f, 239.1074f, -49.8f));
        this.SlotMachinesRot.Add(-48f);
        this.SlotMachines.Add(new Vector3(1109.164f, 238.4004f, -49.8f));
        this.SlotMachinesRot.Add(-34f);
        this.SlotMachines.Add(new Vector3(1110.082f, 238.1253f, -49.8f));
        this.SlotMachinesRot.Add(-20f);
        this.SlotMachines.Add(new Vector3(1110.956f, 238.1476f, -49.8f));
        this.SlotMachinesRot.Add(-3f);
        this.SlotMachines.Add(new Vector3(1111.801f, 238.1584f, -49.8f));
        this.SlotMachinesRot.Add(25f);
        this.SlotMachines.Add(new Vector3(1112.645f, 238.5698f, -49.8f));
        this.SlotMachinesRot.Add(32f);
        this.SlotMachines.Add(new Vector3(1113.419f, 238.9962f, -49.8f));
        this.SlotMachinesRot.Add(46f);
        this.SlotMachines.Add(new Vector3(1115.422f, 234.7188f, -49.8f));
        this.SlotMachinesRot.Add(109f);
        this.SlotMachines.Add(new Vector3(1114.047f, 235.7146f, -49.8f));
        this.SlotMachinesRot.Add(-170f);
        this.SlotMachines.Add(new Vector3(1112.701f, 234.7498f, -49.8f));
        this.SlotMachinesRot.Add(-107f);
        this.SlotMachines.Add(new Vector3(1113.335f, 233.1384f, -49.8f));
        this.SlotMachinesRot.Add(-37f);
        this.SlotMachines.Add(new Vector3(1114.964f, 233.0724f, -49.8f));
        this.SlotMachinesRot.Add(25f);
        this.SlotMachines.Add(new Vector3(1116.269f, 228.2968f, -49.8f));
        this.SlotMachinesRot.Add(-39f);
        this.SlotMachines.Add(new Vector3(1117.877f, 2278.357f, -49.8f));
        this.SlotMachinesRot.Add(44f);
        this.SlotMachines.Add(new Vector3(1118.452f, 229.9547f, -49.8f));
        this.SlotMachinesRot.Add(103f);
        this.SlotMachines.Add(new Vector3(1117.169f, 230.8778f, -49.8f));
        this.SlotMachinesRot.Add(-175f);
        this.SlotMachines.Add(new Vector3(1117.169f, 230.8778f, -49.8f));
        this.SlotMachinesRot.Add(-175f);
        this.SlotMachines.Add(new Vector3(1129.584f, 250.9299f, -51.2f));
        this.SlotMachinesRot.Add(-173f);
        this.SlotMachines.Add(new Vector3(1130.55f, 251.0233f, -51.2f));
        this.SlotMachinesRot.Add(165f);
        this.SlotMachines.Add(new Vector3(1131.325f, 250.5148f, -51.2f));
        this.SlotMachinesRot.Add(154f);
        this.SlotMachines.Add(new Vector3(1132.006f, 249.9666f, -51.2f));
        this.SlotMachinesRot.Add(133f);
        this.SlotMachines.Add(new Vector3(1132.541f, 249.3008f, -51.2f));
        this.SlotMachinesRot.Add(119f);
        this.SlotMachines.Add(new Vector3(1132.924f, 248.4754f, -51.2f));
        this.SlotMachinesRot.Add(105f);
        this.SlotMachines.Add(new Vector3(1133.166f, 247.5615f, -51.2f));
        this.SlotMachinesRot.Add(84f);
        this.SlotMachines.Add(new Vector3(1137.762f, 251.4668f, -51.2f));
        this.SlotMachinesRot.Add(-44f);
        this.SlotMachines.Add(new Vector3(1139.381f, 251.0917f, -51.2f));
        this.SlotMachinesRot.Add(25f);
        this.SlotMachines.Add(new Vector3(1140.171f, 252.5691f, -51.2f));
        this.SlotMachinesRot.Add(102f);
        this.SlotMachines.Add(new Vector3(1138.972f, 253.6587f, -51.2f));
        this.SlotMachinesRot.Add(175f);
        this.SlotMachines.Add(new Vector3(1135.809f, 256.7634f, -51.2f));
        this.SlotMachinesRot.Add(98f);
        this.SlotMachines.Add(new Vector3(1134.669f, 257.789f, -51.2f));
        this.SlotMachinesRot.Add(168f);
        this.SlotMachines.Add(new Vector3(1133.367f, 257.0611f, -51.2f));
        this.SlotMachinesRot.Add(-117f);
        try
        {
          this.WheelProp = World.CreateProp(this.SpawnProp("vw_prop_vw_luckywheel_02a"), new Vector3(this.LuckyWheel.X, this.LuckyWheel.Y + 1.17f, this.LuckyWheel.Z + 0.12f), true, false);
          this.WheelProp.FreezePosition = true;
          this.WheelProp.Rotation = new Vector3(0.0f, -10f, 0.0f);
          this.WheelProp2 = World.CreateProp(this.SpawnProp("vw_prop_vw_luckywheel_02a"), new Vector3(1110.771f, 223.5515f, -50f), true, false);
          this.WheelProp2.Rotation = new Vector3(0.0f, -90f, 0.0f);
          this.WheelProp2.FreezePosition = true;
          this.WheelProp2.Rotation = new Vector3(0.0f, -10f, 0.0f);
          this.WheelProp2.IsVisible = false;
          this.WheelProp2.HasCollision = false;
          Vector3 position2 = this.ThraxPos;
          position2 = new Vector3(position2.X, position2.Y, position2.Z - 5.1f);
          this.BasePlate = World.CreateProp(this.SpawnProp("xs_prop_arena_flipper_small_01a_sf"), position2, true, false);
          this.BasePlate.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
          this.BasePlate.FreezePosition = true;
          this.BasePlate.IsVisible = false;
          this.BasePlate.HasCollision = true;
        }
        catch (Exception ex)
        {
          UI.Notify("~r~Error 3~");
        }
        try
        {
          this.WheelWinMarker = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.18f, -0.3f, 1.15f)), true, false);
          Prop prop1 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop1.AttachTo((Entity) this.WheelProp, 0, new Vector3(0.0f, -0.3f, 1.15f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop1);
          Prop prop2 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop2.AttachTo((Entity) this.WheelProp, 0, new Vector3(0.4f, -0.3f, 1.1f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop2);
          Prop prop3 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop3.AttachTo((Entity) this.WheelProp, 0, new Vector3(0.7f, -0.3f, 0.9f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop3);
          Prop prop4 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop4.AttachTo((Entity) this.WheelProp, 0, new Vector3(0.95f, -0.3f, 0.6f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop4);
          Prop prop5 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop5.AttachTo((Entity) this.WheelProp, 0, new Vector3(1.1f, -0.3f, 0.3f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop5);
          Prop prop6 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop6.AttachTo((Entity) this.WheelProp, 0, new Vector3(1.15f, -0.3f, 0.0f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop6);
          Prop prop7 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop7.AttachTo((Entity) this.WheelProp, 0, new Vector3(1.1f, -0.3f, -0.3f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop7);
          Prop prop8 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop8.AttachTo((Entity) this.WheelProp, 0, new Vector3(0.95f, -0.3f, -0.6f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop8);
          Prop prop9 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop9.AttachTo((Entity) this.WheelProp, 0, new Vector3(0.7f, -0.3f, -0.9f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop9);
          Prop prop10 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop10.AttachTo((Entity) this.WheelProp, 0, new Vector3(0.35f, -0.3f, -1.1f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop10);
          Prop prop11 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop11.AttachTo((Entity) this.WheelProp, 0, new Vector3(0.0f, -0.3f, -1.15f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop11);
          Prop prop12 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop12.AttachTo((Entity) this.WheelProp, 0, new Vector3(-0.35f, -0.3f, -1.1f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop12);
          Prop prop13 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop13.AttachTo((Entity) this.WheelProp, 0, new Vector3(-0.7f, -0.3f, 0.9f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop13);
          Prop prop14 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop14.AttachTo((Entity) this.WheelProp, 0, new Vector3(-0.95f, -0.3f, 0.6f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop14);
          Prop prop15 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop15.AttachTo((Entity) this.WheelProp, 0, new Vector3(-1.1f, -0.3f, 0.3f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop15);
          Prop prop16 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop16.AttachTo((Entity) this.WheelProp, 0, new Vector3(-1.15f, -0.3f, 0.0f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop16);
          Prop prop17 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop17.AttachTo((Entity) this.WheelProp, 0, new Vector3(-1.1f, -0.3f, -0.3f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop17);
          Prop prop18 = World.CreateProp((Model) "vw_prop_roulette_marker", this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop18.AttachTo((Entity) this.WheelProp, 0, new Vector3(-0.95f, -0.3f, -0.6f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop18);
          Prop prop19 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop19.AttachTo((Entity) this.WheelProp, 0, new Vector3(-0.7f, -0.3f, -0.9f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop19);
          Prop prop20 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop20.AttachTo((Entity) this.WheelProp, 0, new Vector3(-0.4f, -0.3f, -1.1f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop20);
          Prop prop21 = World.CreateProp(this.SpawnProp("vw_prop_roulette_marker"), this.WheelProp.GetOffsetInWorldCoords(new Vector3(0.0f, 0.0f, 0.0f)), true, false);
          prop21.AttachTo((Entity) this.WheelProp, 0, new Vector3(-0.4f, -0.3f, 1.1f), new Vector3(90f, 0.0f, 0.0f));
          this.WheelMarkers.Add(prop21);
          foreach (Prop wheelMarker in this.WheelMarkers)
          {
            if ((Entity) wheelMarker != (Entity) null)
              wheelMarker.IsVisible = false;
          }
        }
        catch (Exception ex)
        {
          UI.Notify("~r~Prize Wheel Markers failed to spawn~");
        }
        try
        {
          this.Vendor1 = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(967.0132f, 29.35624f, 115f), 56f);
          this.Vendor2 = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(969.15f, 33.19205f, 115f), 56f);
          this.SetPedOutfit(this.Vendor1);
          this.PlayDealerAnim(this.Vendor1);
          this.SetPedOutfit(this.Vendor2);
          this.PlayDealerAnim(this.Vendor2);
          this.MainPed.Add(this.Vendor1);
          this.MainPed.Add(this.Vendor2);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1118.256f, 219.4535f, -49.5f), 103f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          Vector3 position2 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position2.X, position2.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1101.027f, 195.2306f, -49.5f), -48f);
          this.SetPedOutfit(this.ped);
          Vector3 position3 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position3.X, position3.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.MainPed.Add(this.ped);
          this.ped = World.CreatePed(this.RequestModel("ig_tomcasino"), new Vector3(1087.711f, 221.1435f, -49.5f), 177f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1145.633f, 261.8369f, -49.5f), -136f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          Vector3 position4 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position4.X, position4.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1151.171f, 267.3671f, -49.5f), -136f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          Vector3 position5 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position5.X, position5.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1149.443f, 269.1333f, -49.5f), 39f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          Vector3 position6 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position6.X, position6.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1144.041f, 263.6831f, -49.5f), 48f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          Vector3 position7 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position7.X, position7.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1149.349f, 252.3492f, -49.5f), 137f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          Vector3 position8 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position8.X, position8.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1143.853f, 246.481f, -49.5f), -38f);
          this.ped.FreezePosition = true;
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          Vector3 position9 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position9.X, position9.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1110.818f, 209.2807f, -49.5f), 34f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.ped.Task.PlayAnimation("anim@amb@casino@mini@drinking@bar@drink_v2@heels@idle_a", "idle_a_bartender", 8f, -1, true, -1f);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1113.457f, 208.9917f, -49.5f), -63f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.ped.Task.PlayAnimation("anim@amb@casino@mini@drinking@bar@drink_v2@heels@idle_a", "idle_a_bartender", 8f, -1, true, -1f);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1112.64f, 206.597f, -49.5f), -178f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.ped.Task.PlayAnimation("anim@amb@casino@mini@drinking@bar@drink_v2@heels@idle_a", "idle_a_bartender", 8f, -1, true, -1f);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1148.878f, 264.5572f, -49.5f), 44f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1147.896f, 246.8535f, -49.5f), -51f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1134.328f, 267.3924f, -49.5f), 134f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(958.8818f, 71.53243f, 111f), 154f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.ped.Task.PlayAnimation("anim@amb@casino@mini@drinking@bar@drink_v2@heels@idle_a", "idle_a_bartender", 8f, -1, true, -1f);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1128.806f, 261.6401f, -50f), -42f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel(PedHash.TaoCheng), new Vector3(1113.545f, 249.2349f, -46f), -179f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.ped.Task.PlayAnimation("move_drunk_m", "idle", 1900f, -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreatePed(this.RequestModel(PedHash.TaosTranslator), new Vector3(1113.671f, 247.5057f, -46f), -32f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.ped.Task.StartScenario("WORLD_HUMAN_MOBILE_FILM_SHOCKING", this.ped.Position);
          this.SetPedOutfit(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1131.212f, 268.1662f, -50f), 111f);
          this.MainPed.Add(this.ped);
          Vector3 position10 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = new Vector3(position10.X, position10.Y, -52f);
          this.PlayDealerAnim(this.ped);
          this.ped = World.CreatePed(this.RequestModel("s_f_y_casino_01"), new Vector3(1128.704f, 211f, -49f), -43f);
          this.SetPedOutfit(this.ped);
          this.MainPed.Add(this.ped);
          this.SetPedOutfit(this.ped);
          this.ped = World.CreatePed((Model) "s_f_y_casino_01", new Vector3(945.3591f, 13.48792f, 115f), 52f);
          this.ped.Task.PlayAnimation("anim@amb@casino@mini@drinking@bar@drink_v2@heels@idle_a", "idle_a_bartender", 8f, -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreatePed(this.RequestModel("csb_agatha"), new Vector3(1114.801f, 253.6271f, -46.4f), -90f);
          this.ped.AlwaysKeepTask = true;
          this.MainPed.Add(this.ped);
          this.ped.Task.PlayAnimation("anim@amb@office@pa@female@", "pa_base", 8f, -1, true, -1f);
          this.ped = World.CreateRandomPed(new Vector3(1134.131f, 278.7511f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1134.131f, 278.7511f, -52.1f);
          this.ped.FreezePosition = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, -90f);
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.PlayAnimation("missfam5_blackout", "vomit", 128f, -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1135.075f, 280.4876f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1134.134f, 280.4636f, -52.1f);
          this.ped.FreezePosition = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, 90f);
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.PlayAnimation("switch@trevor@on_toilet", "trev_on_toilet_loop", 8f, -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1134.012f, 282.1808f, -52.1f);
          this.ped.FreezePosition = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, 90f);
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.PlayAnimation("switch@trevor@puking_into_fountain", "trev_fountain_puke_loop", 128f, -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1133.018f, 276.7346f, -52f);
          this.ped.FreezePosition = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, -90f);
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.PlayAnimation("switch@michael@wash_face", "loop_michael", 128f, -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50.5f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1105.535f, 217.0142f, -49.9f);
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, 62f);
          this.ped.Task.StartScenario("WORLD_HUMAN_PAPARAZZI", this.ped.Position);
          this.MainPed.Add(this.ped);
          this.ped.Rotation = new Vector3(0.0f, 0.0f, 62f);
          this.ped.Task.StartScenario("WORLD_HUMAN_TOURIST_MOBILE", this.ped.Position);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50.5f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1104.666f, 215.5959f, -49.9f);
          this.ped.FreezePosition = true;
          this.ped.Heading = 38f;
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.StartScenario("WORLD_HUMAN_PAPARAZZI", this.ped.Position);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -49.8f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1106.087f, 218.7728f, -49.9f);
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, 82f);
          this.ped.Task.StartScenario("WORLD_HUMAN_PAPARAZZI", this.ped.Position);
          this.MainPed.Add(this.ped);
          this.ped.Heading = 82f;
          this.ped.Task.StartScenario("WORLD_HUMAN_TOURIST_MOBILE", this.ped.Position);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1102.207f, 200.4515f, -50.4f);
          this.ped.FreezePosition = true;
          this.ped.Heading = 136f;
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.StartScenario("WORLD_HUMAN_TOURIST_MOBILE", this.ped.Position);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1103.912f, 197.4887f, -50.4f);
          this.ped.FreezePosition = true;
          this.ped.Heading = -81f;
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.StartScenario("WORLD_HUMAN_AA_COFFEE", this.ped.Position);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1096.842f, 208.2964f, -50f);
          this.ped.FreezePosition = true;
          this.ped.Heading = 75f;
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.StartScenario("WORLD_HUMAN_AA_COFFEE", this.ped.Position);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1094.77f, 208.3848f, -50f);
          this.ped.FreezePosition = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, -90f);
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.StartScenario("WORLD_HUMAN_HANG_OUT_STREET", this.ped.Position);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1096.422f, 209.5439f, -50f);
          this.ped.FreezePosition = true;
          this.ped.Heading = 146f;
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.StartScenario("WORLD_HUMAN_HANG_OUT_STREET", this.ped.Position);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1134.012f, 282.1808f, -50f));
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1106.37f, 212.0176f, -50.3f);
          this.ped.FreezePosition = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, 146f);
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.PlayAnimation("amb@world_human_sunbathe@female@back@base", "base", 8f, -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreatePed((Model) PedHash.Paramedic01SMM, new Vector3(1134.012f, 282.1808f, -51f), 1f);
          this.ped.Position = this.MarkerEnter;
          Script.Wait(1);
          this.ped.Position = new Vector3(1106.548f, 211.8759f, -50.3f);
          this.ped.FreezePosition = true;
          this.ped.Rotation = new Vector3(0.0f, 0.0f, 122f);
          this.ped.AlwaysKeepTask = true;
          this.ped.Task.PlayAnimation("missheistfbi3b_ig8_2", "cpr_loop_paramedic", 8f, -1, true, -1f);
          this.MainPed.Add(this.ped);
          foreach (Ped ped77 in this.MainPed)
          {
            if ((Entity) ped77 != (Entity) null)
            {
              Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) ped77, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped77, (InputArgument) 17, (InputArgument) 1);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped77, (InputArgument) 1);
              Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) ped77, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped77, (InputArgument) 17, (InputArgument) 1);
              ped77.RelationshipGroup = 1;
              ped77.AlwaysKeepTask = true;
            }
          }
          System.Random random2 = new System.Random();
          Vector3 markerEnter = this.MarkerEnter;
          Vector3 vector3 = new Vector3(0.0f, 0.0f, 0.0f);
          this.ped = World.CreateRandomPed(new Vector3(1111.493f, 211.5376f, -51.5f));
          this.ped.Heading = -174f;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Vector3 position11 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position11;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1110.145f, 210.9409f, -51.5f));
          this.ped.Heading = -147f;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Vector3 position12 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position12;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1109.086f, 209.9584f, -51.5f));
          this.ped.Heading = -122f;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Vector3 position13 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position13;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1108.59f, 206.8573f, -51.5f));
          this.ped.Heading = -73f;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Vector3 position14 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position14;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1109.433f, 205.567f, -51.5f));
          this.ped.Heading = -38f;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Vector3 position15 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position15;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1110.84f, 204.7336f, -51.5f));
          this.ped.Heading = -28f;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Vector3 position16 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position16;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1112.326f, 204.5824f, -51.5f));
          this.ped.Heading = -3f;
          Vector3 position17 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position17;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1114.798f, 206.2514f, -51.5f));
          this.ped.Heading = 45f;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Vector3 position18 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position18;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
          this.ped = World.CreateRandomPed(new Vector3(1115.477f, 20.6416f, -51.5f));
          this.ped.Heading = 45f;
          this.ped.FreezePosition = true;
          this.ped.AlwaysKeepTask = true;
          this.ped.IsPersistent = true;
          Vector3 position19 = this.ped.Position;
          Script.Wait(1);
          this.ped.Position = position10;
          Script.Wait(1);
          this.ped.Position = position19;
          Script.Wait(1);
          this.ped.Task.PlayAnimation("anim@special_peds@casino@bar@ped_male@sit_withdrink@01a@base", "base", (float) random2.Next(162, 1000), -1, true, -1f);
          this.MainPed.Add(this.ped);
        }
        catch
        {
        }
        foreach (Ped ped77 in this.MainPed)
        {
          if ((Entity) ped77 != (Entity) null)
          {
            Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) ped77, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped77, (InputArgument) 17, (InputArgument) 1);
            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped77, (InputArgument) 1);
            Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) ped77, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped77, (InputArgument) 17, (InputArgument) 1);
            ped77.RelationshipGroup = 1;
            ped77.AlwaysKeepTask = true;
          }
        }
        try
        {
          try
          {
            foreach (Prop nearbyProp in World.GetNearbyProps(this.MarkerExit, 3000f, this.RequestModel("vw_prop_casino_3cardpoker_01")))
            {
              if ((Entity) nearbyProp != (Entity) null)
                this.Tables.Add(nearbyProp);
            }
            foreach (Prop nearbyProp in World.GetNearbyProps(this.MarkerExit, 3000f, this.RequestModel("vw_prop_casino_3cardpoker_01b")))
            {
              if ((Entity) nearbyProp != (Entity) null)
                this.Tables.Add(nearbyProp);
            }
            foreach (Prop nearbyProp in World.GetNearbyProps(this.MarkerExit, 3000f, this.RequestModel("vw_prop_casino_blckjack_01")))
            {
              if ((Entity) nearbyProp != (Entity) null)
                this.Tables.Add(nearbyProp);
            }
            foreach (Prop nearbyProp in World.GetNearbyProps(this.MarkerExit, 3000f, this.RequestModel("vw_prop_casino_blckjack_01b")))
            {
              if ((Entity) nearbyProp != (Entity) null)
                this.Tables.Add(nearbyProp);
            }
          }
          catch
          {
            UI.Notify("~r~ Error 10");
          }
          Prop prop1 = World.CreateProp(this.SpawnProp("vw_prop_casino_blckjack_01b"), new Vector3(968.2f, 33.75655f, 115f), true, false);
          prop1.Rotation = new Vector3(0.0f, 0.0f, -124f);
          this.Tables.Add(prop1);
          Prop prop2 = World.CreateProp(this.SpawnProp("vw_prop_casino_3cardpoker_01b"), new Vector3(966.2f, 29.93874f, 115f), true, false);
          prop2.Rotation = new Vector3(0.0f, 0.0f, -124f);
          this.Tables.Add(prop2);
          Prop prop3 = World.CreateProp(this.SpawnProp("vw_prop_casino_roulette_01"), new Vector3(1147.584f, 265.6707f, -52.8f), true, false);
          prop3.Rotation = new Vector3(0.0f, 0.0f, 133f);
          this.Tables2.Add(prop3);
          Prop prop4 = World.CreateProp(this.SpawnProp("vw_prop_casino_roulette_01b"), new Vector3(1148.889f, 248.0665f, -52f), true, false);
          prop4.Rotation = new Vector3(0.0f, 0.0f, 43f);
          this.Tables2.Add(prop4);
          Prop prop5 = World.CreateProp(this.SpawnProp("vw_prop_casino_roulette_01b"), new Vector3(1129.883f, 267.433f, -52f), true, false);
          prop5.Rotation = new Vector3(0.0f, 0.0f, -159f);
          this.Tables2.Add(prop5);
        }
        catch (Exception ex)
        {
          UI.Notify("~r~ Error 5");
        }
        try
        {
          for (int index = 0; index < this.SlotMachines.Count; ++index)
          {
            System.Random random2 = new System.Random();
            int num2 = random2.Next(0, 100);
            int num3 = random2.Next(1, 6);
            if (num2 <= 100)
            {
              Ped randomPed = World.CreateRandomPed(this.SlotMachines[index]);
              randomPed.Heading = this.SlotMachinesRot[index];
              randomPed.FreezePosition = true;
              randomPed.AlwaysKeepTask = true;
              randomPed.IsPersistent = true;
              this.SMPed.Add(randomPed);
              if (num3 == 1)
                randomPed.Task.PlayAnimation("anim_casino_a@amb@casino@games@slots@male", "base_idle_a", 16f, -1, true, -1f);
              if (num3 == 2)
                randomPed.Task.PlayAnimation("anim_casino_a@amb@casino@games@slots@male", "base_idle_b", 16f, -1, true, -1f);
              if (num3 == 3)
                randomPed.Task.PlayAnimation("anim_casino_a@amb@casino@games@slots@male", "base_idle_c", 16f, -1, true, -1f);
              if (num3 == 4)
                randomPed.Task.PlayAnimation("anim_casino_a@amb@casino@games@slots@male", "base_idle_d", 16f, -1, true, -1f);
              if (num3 == 5)
                randomPed.Task.PlayAnimation("anim_casino_a@amb@casino@games@slots@male", "base_idle_e", 16f, -1, true, -1f);
              if (num3 == 6)
                randomPed.Task.PlayAnimation("anim_casino_a@amb@casino@games@slots@male", "base_idle_f", 16f, -1, true, -1f);
              if (num3 > 6)
                randomPed.Task.PlayAnimation("anim_casino_a@amb@casino@games@slots@male", "base_idle_b", 16f, -1, true, -1f);
              if (num3 < 0)
                randomPed.Task.PlayAnimation("anim_casino_a@amb@casino@games@slots@male", "base_idle_e", 16f, -1, true, -1f);
            }
          }
          for (int index = 0; index < this.SlotMachines.Count; ++index)
          {
            if ((Entity) this.SMPed[index] != (Entity) null)
            {
              Vector3 vector3 = this.SMPed[index].Position;
              vector3 = new Vector3(vector3.X, vector3.Y, vector3.Z - 2.3f);
              this.SMPed[index].Position = this.MarkerEnter;
              Vector3 position2 = this.SMPed[index].Position;
              this.SMPed[index].Position = vector3;
              Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.SMPed[index], (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.SMPed[index], (InputArgument) 17, (InputArgument) 1);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) this.SMPed[index], (InputArgument) 1);
              Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) this.SMPed[index], (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) this.SMPed[index], (InputArgument) 17, (InputArgument) 1);
              this.SMPed[index].RelationshipGroup = 1;
              this.SMPed[index].AlwaysKeepTask = true;
            }
          }
          foreach (Ped ped77 in this.SMPed)
          {
            if ((Entity) ped77 != (Entity) null)
            {
              Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) ped77, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped77, (InputArgument) 17, (InputArgument) 1);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped77, (InputArgument) 1);
              Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) ped77, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped77, (InputArgument) 17, (InputArgument) 1);
              ped77.RelationshipGroup = 1;
              ped77.AlwaysKeepTask = true;
            }
          }
        }
        catch (Exception ex)
        {
        }
        try
        {
          this.Prizecar = World.CreateVehicle(this.RequestModel("thrax"), this.ThraxPos, 9.5f);
          this.Prizecar.IsPersistent = true;
        }
        catch (Exception ex)
        {
          UI.Notify("~r~Error 4~");
        }
      }
      System.Random random3 = new System.Random();
      foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
      {
        if ((Entity) aircarftCarrierPed != (Entity) null)
        {
          aircarftCarrierPed.IsPersistent = true;
          if (Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) aircarftCarrierPed, (InputArgument) "anim@amb@office@pa@male@", (InputArgument) "pa_base", (InputArgument) 1))
          {
            aircarftCarrierPed.Weapons.Give(WeaponHash.SMG, 9999, false, true);
            aircarftCarrierPed.BlockPermanentEvents = true;
          }
          else if (Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) aircarftCarrierPed, (InputArgument) "anim@amb@office@seating@male@var_e@base@", (InputArgument) "base", (InputArgument) 1))
          {
            aircarftCarrierPed.Weapons.Give(WeaponHash.SMG, 9999, false, true);
            aircarftCarrierPed.BlockPermanentEvents = true;
          }
          else
            aircarftCarrierPed.Weapons.Give(WeaponHash.SMG, 9999, true, true);
          aircarftCarrierPed.Accuracy = 450;
          aircarftCarrierPed.Health = 200;
          aircarftCarrierPed.Armor = 100;
          int num2 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "SECURITY_GUARD");
          Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) aircarftCarrierPed, (InputArgument) num2);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) aircarftCarrierPed, (InputArgument) 0, (InputArgument) 0);
          aircarftCarrierPed.RelationshipGroup = num2;
          aircarftCarrierPed.AddBlip();
          aircarftCarrierPed.CurrentBlip.Scale = 0.6f;
          aircarftCarrierPed.CurrentBlip.Sprite = BlipSprite.Enemy;
          aircarftCarrierPed.CurrentBlip.Name = "DC Guard";
          aircarftCarrierPed.CurrentBlip.Color = BlipColor.Red;
          aircarftCarrierPed.CurrentBlip.IsShortRange = true;
          Function.Call(Hash._0xF29CF591C4BF6CEE, (InputArgument) aircarftCarrierPed, (InputArgument) 35f);
          Function.Call(Hash._0x33A8F7F7D5F7F33C, (InputArgument) aircarftCarrierPed, (InputArgument) 30f);
          if (random3.Next(0, 100) < 15)
          {
            aircarftCarrierPed.CurrentBlip.Scale = 0.6f;
            aircarftCarrierPed.CurrentBlip.Sprite = BlipSprite.Enemy;
            aircarftCarrierPed.CurrentBlip.Name = "DC Elite Guard";
            aircarftCarrierPed.CurrentBlip.Color = BlipColor.Blue;
            aircarftCarrierPed.CurrentBlip.IsShortRange = true;
          }
          if (!Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) aircarftCarrierPed, (InputArgument) "anim@amb@office@pa@male@", (InputArgument) "pa_base", (InputArgument) 1))
          {
            if (!Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) aircarftCarrierPed, (InputArgument) "anim@amb@office@seating@male@var_e@base@", (InputArgument) "base", (InputArgument) 1) && this.AIinCasinoHeistCanWander && new System.Random().Next(0, 100) <= this.AIinCasinoWanderChance)
              aircarftCarrierPed.Task.WanderAround(aircarftCarrierPed.Position, (float) this.AIinCasinoWanderRadius);
          }
        }
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

    public void EndofHiest()
    {
      this.HeistTime = 0.0f;
      UI.Notify("~g~ HKH191 ~w~ : Loading Heist, Please be Patient");
      this.SetupHeiststuff();
      if ((Entity) this.RobberC != (Entity) null)
        this.RobberC.Delete();
      if ((Entity) this.RobberB != (Entity) null)
        this.RobberB.Delete();
      if ((Entity) this.RobberA != (Entity) null)
        this.RobberA.Delete();
      Game.Player.Character.Alpha = 0;
      Vector3 position1 = Game.Player.Character.Position;
      Game.Player.Character.Position = new Vector3(152f, 322f, 612f);
      Script.Wait(1);
      Game.Player.Character.Position = position1;
      Game.Player.Character.Alpha = (int) byte.MaxValue;
      if (this.HeistStartCam != (Camera) null)
      {
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        this.HeistStartCam.IsActive = false;
        this.HeistStartCam.Destroy();
      }
      Game.Player.Character.FreezePosition = false;
      Game.Player.CanControlCharacter = true;
      Vector3 position2;
      if ((uint) this.RobberAskill > 0U)
      {
        if (this.RobberAskill != 7)
        {
          if (this.EnteranceUsed != 1 && this.EnteranceUsed != 5)
          {
            this.RobberA = World.CreatePed(this.RequestPed(this.RobberASkin), Game.Player.Character.Position.Around(5f), 168f);
            this.Setoutfit(this.RobberA, this.RobberA_C);
            if (this.RobberA_C == 39)
              this.SetOutift(this.RobberA, 1);
            if (this.RobberA_C == 40)
              this.SetOutift(this.RobberA, 2);
            if (this.RobberA_C == 41)
              this.SetOutift(this.RobberA, 3);
            if (this.RobberA_C == 42)
              this.SetOutift(this.RobberA, 4);
            if (this.RobberA_C == 43)
              this.SetOutift(this.RobberA, 5);
            if (this.RobberA_C == 44)
              this.SetOutift(this.RobberA, 6);
            if (this.RobberA_C == 45)
              this.SetOutift(this.RobberA, 7);
          }
          if (this.EnteranceUsed == 1)
          {
            Model model = this.RequestPed(PedHash.Armoured01SMM);
            position2 = Game.Player.Character.Position;
            Vector3 position3 = position2.Around(5f);
            this.RobberA = World.CreatePed(model, position3, 168f);
          }
          if (this.EnteranceUsed == 5)
          {
            Model model = this.RequestPed(PedHash.PestContDriver);
            position2 = Game.Player.Character.Position;
            Vector3 position3 = position2.Around(5f);
            this.RobberA = World.CreatePed(model, position3, 168f);
          }
        }
        if (this.RobberAskill == 7)
        {
          Model model = (Model) PedHash.FreemodeMale01;
          position2 = Game.Player.Character.Position;
          Vector3 position3 = position2.Around(5f);
          this.RobberA = World.CreatePed(model, position3, 168f);
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC");
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0xD2A71E1A77418A49, (InputArgument) "move_ballistic_2h");
          Ped robberA = this.RobberA;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberA, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0xD75ACCF5E0FB5367, (InputArgument) robberA, (InputArgument) true, (InputArgument) -1, (InputArgument) 0);
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) robberA, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC", (InputArgument) 5f);
          Function.Call(Hash._0x29A28F3F8CF6D854, (InputArgument) robberA, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0x1055AC3A667F09D9, (InputArgument) robberA, (InputArgument) 1429513766);
        }
        if (this.RobberAskill == 1)
        {
          this.RobberA.Health = 300;
          this.RobberA.Armor = 500;
          this.RobberA.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.RobberA.CanSufferCriticalHits = true;
          this.RobberA.CanRagdoll = true;
        }
        if (this.RobberAskill == 2)
        {
          this.RobberA.Health = 500;
          this.RobberA.Armor = 700;
          this.RobberA.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
          this.RobberA.CanSufferCriticalHits = true;
          this.RobberA.CanRagdoll = true;
        }
        if (this.RobberAskill == 3)
        {
          this.RobberA.Health = 600;
          this.RobberA.Armor = 800;
          this.RobberA.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);
          this.RobberA.CanSufferCriticalHits = true;
          this.RobberA.CanRagdoll = true;
        }
        if (this.RobberAskill == 4)
        {
          this.RobberA.Health = 800;
          this.RobberA.Armor = 800;
          this.RobberA.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);
          this.RobberA.CanRagdoll = false;
          this.RobberA.CanSufferCriticalHits = true;
        }
        if (this.RobberAskill == 5)
        {
          this.RobberA.Health = 1100;
          this.RobberA.Armor = 1000;
          this.RobberA.Weapons.Give(WeaponHash.CombatMG, 9999, true, true);
          this.RobberA.CanRagdoll = false;
          this.RobberA.CanSufferCriticalHits = true;
        }
        if (this.RobberAskill == 6)
        {
          this.RobberA.Health = 1300;
          this.RobberA.Armor = 1400;
          this.RobberA.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
          this.RobberA.CanRagdoll = false;
          this.RobberA.CanSufferCriticalHits = false;
        }
        if (this.RobberAskill == 7)
        {
          this.RobberA.Health = 1600;
          this.RobberA.Armor = 1800;
          this.RobberA.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
          this.RobberA.CanRagdoll = false;
          this.RobberA.CanSufferCriticalHits = false;
        }
      }
      if ((uint) this.RobberBskill > 0U)
      {
        if (this.RobberBskill != 7)
        {
          if (this.EnteranceUsed != 1 && this.EnteranceUsed != 5)
          {
            Model model = this.RequestPed(this.RobberBSkin);
            position2 = Game.Player.Character.Position;
            Vector3 position3 = position2.Around(5f);
            this.RobberB = World.CreatePed(model, position3, 168f);
            this.Setoutfit(this.RobberB, this.RobberB_C);
            if (this.RobberB_C == 39)
              this.SetOutift(this.RobberB, 1);
            if (this.RobberB_C == 40)
              this.SetOutift(this.RobberB, 2);
            if (this.RobberB_C == 41)
              this.SetOutift(this.RobberB, 3);
            if (this.RobberB_C == 42)
              this.SetOutift(this.RobberB, 4);
            if (this.RobberB_C == 43)
              this.SetOutift(this.RobberB, 5);
            if (this.RobberB_C == 44)
              this.SetOutift(this.RobberB, 6);
            if (this.RobberB_C == 45)
              this.SetOutift(this.RobberB, 7);
          }
          if (this.EnteranceUsed == 1)
          {
            Model model = this.RequestPed(PedHash.Armoured01SMM);
            position2 = Game.Player.Character.Position;
            Vector3 position3 = position2.Around(5f);
            this.RobberB = World.CreatePed(model, position3, 168f);
          }
          if (this.EnteranceUsed == 5)
          {
            Model model = this.RequestPed(PedHash.PestContDriver);
            position2 = Game.Player.Character.Position;
            Vector3 position3 = position2.Around(5f);
            this.RobberB = World.CreatePed(model, position3, 168f);
          }
        }
        if (this.RobberBskill == 7)
        {
          Model model = (Model) PedHash.FreemodeMale01;
          position2 = Game.Player.Character.Position;
          Vector3 position3 = position2.Around(5f);
          this.RobberB = World.CreatePed(model, position3, 168f);
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC");
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0xD2A71E1A77418A49, (InputArgument) "move_ballistic_2h");
          Ped robberB = this.RobberB;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberB, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0xD75ACCF5E0FB5367, (InputArgument) robberB, (InputArgument) true, (InputArgument) -1, (InputArgument) 0);
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) robberB, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC", (InputArgument) 5f);
          Function.Call(Hash._0x29A28F3F8CF6D854, (InputArgument) robberB, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0x1055AC3A667F09D9, (InputArgument) robberB, (InputArgument) 1429513766);
        }
        if (this.RobberBskill == 1)
        {
          this.RobberB.Health = 300;
          this.RobberB.Armor = 500;
          this.RobberB.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.RobberB.CanRagdoll = true;
          this.RobberB.CanSufferCriticalHits = true;
        }
        if (this.RobberBskill == 2)
        {
          this.RobberB.Health = 500;
          this.RobberB.Armor = 700;
          this.RobberB.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
          this.RobberB.CanRagdoll = true;
          this.RobberB.CanSufferCriticalHits = true;
        }
        if (this.RobberBskill == 3)
        {
          this.RobberB.Health = 600;
          this.RobberB.Armor = 800;
          this.RobberB.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);
          this.RobberB.CanRagdoll = true;
          this.RobberB.CanSufferCriticalHits = true;
        }
        if (this.RobberBskill == 4)
        {
          this.RobberB.Health = 800;
          this.RobberB.Armor = 800;
          this.RobberB.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);
          this.RobberB.CanRagdoll = false;
          this.RobberB.CanSufferCriticalHits = true;
        }
        if (this.RobberBskill == 5)
        {
          this.RobberB.Health = 1100;
          this.RobberB.Armor = 1000;
          this.RobberB.Weapons.Give(WeaponHash.CombatMG, 9999, true, true);
          this.RobberB.CanRagdoll = false;
          this.RobberB.CanSufferCriticalHits = true;
        }
        if (this.RobberBskill == 6)
        {
          this.RobberB.Health = 1300;
          this.RobberB.Armor = 1400;
          this.RobberB.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
          this.RobberB.CanRagdoll = false;
          this.RobberB.CanSufferCriticalHits = false;
        }
        if (this.RobberBskill == 7)
        {
          this.RobberB.Health = 1600;
          this.RobberB.Armor = 1800;
          this.RobberB.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
          this.RobberB.CanRagdoll = false;
          this.RobberB.CanSufferCriticalHits = false;
        }
      }
      if ((uint) this.RobberCskill > 0U)
      {
        if (this.RobberCskill != 7)
        {
          if (this.EnteranceUsed != 1 && this.EnteranceUsed != 5)
          {
            Model model = this.RequestPed(this.RobberCSkin);
            position2 = Game.Player.Character.Position;
            Vector3 position3 = position2.Around(5f);
            this.RobberC = World.CreatePed(model, position3, 168f);
            this.Setoutfit(this.RobberC, this.RobberC_C);
            if (this.RobberC_C == 39)
              this.SetOutift(this.RobberC, 1);
            if (this.RobberC_C == 40)
              this.SetOutift(this.RobberC, 2);
            if (this.RobberC_C == 41)
              this.SetOutift(this.RobberC, 3);
            if (this.RobberC_C == 42)
              this.SetOutift(this.RobberC, 4);
            if (this.RobberC_C == 43)
              this.SetOutift(this.RobberC, 5);
            if (this.RobberC_C == 44)
              this.SetOutift(this.RobberC, 6);
            if (this.RobberC_C == 45)
              this.SetOutift(this.RobberC, 7);
          }
          if (this.EnteranceUsed == 1)
          {
            Model model = this.RequestPed(PedHash.Armoured01SMM);
            position2 = Game.Player.Character.Position;
            Vector3 position3 = position2.Around(5f);
            this.RobberC = World.CreatePed(model, position3, 168f);
          }
          if (this.EnteranceUsed == 5)
          {
            Model model = this.RequestPed(PedHash.PestCont01SMY);
            position2 = Game.Player.Character.Position;
            Vector3 position3 = position2.Around(5f);
            this.RobberC = World.CreatePed(model, position3, 168f);
          }
        }
        if (this.RobberCskill == 7)
        {
          Model model = (Model) PedHash.FreemodeMale01;
          position2 = Game.Player.Character.Position;
          Vector3 position3 = position2.Around(5f);
          this.RobberC = World.CreatePed(model, position3, 168f);
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC");
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0xD2A71E1A77418A49, (InputArgument) "move_ballistic_2h");
          Ped robberC = this.RobberC;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) robberC, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0xD75ACCF5E0FB5367, (InputArgument) robberC, (InputArgument) true, (InputArgument) -1, (InputArgument) 0);
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) robberC, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC", (InputArgument) 5f);
          Function.Call(Hash._0x29A28F3F8CF6D854, (InputArgument) robberC, (InputArgument) "MOVE_STRAFE_BALLISTIC");
          Function.Call(Hash._0x1055AC3A667F09D9, (InputArgument) robberC, (InputArgument) 1429513766);
        }
        if (this.RobberCskill == 1)
        {
          this.RobberC.Health = 300;
          this.RobberC.Armor = 500;
          this.RobberC.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
          this.RobberC.CanRagdoll = true;
          this.RobberC.CanSufferCriticalHits = true;
        }
        if (this.RobberBskill == 2)
        {
          this.RobberC.Health = 500;
          this.RobberC.Armor = 700;
          this.RobberC.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
          this.RobberC.CanRagdoll = true;
          this.RobberC.CanSufferCriticalHits = true;
        }
        if (this.RobberCskill == 3)
        {
          this.RobberC.Health = 600;
          this.RobberC.Armor = 800;
          this.RobberC.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);
          this.RobberC.CanRagdoll = true;
          this.RobberC.CanSufferCriticalHits = true;
        }
        if (this.RobberCskill == 4)
        {
          this.RobberC.Health = 800;
          this.RobberC.Armor = 800;
          this.RobberC.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);
          this.RobberC.CanRagdoll = false;
          this.RobberC.CanSufferCriticalHits = true;
        }
        if (this.RobberCskill == 5)
        {
          this.RobberC.Health = 1100;
          this.RobberC.Armor = 1000;
          this.RobberC.Weapons.Give(WeaponHash.CombatMG, 9999, true, true);
          this.RobberC.CanRagdoll = false;
          this.RobberC.CanSufferCriticalHits = false;
        }
        if (this.RobberCskill == 6)
        {
          this.RobberC.Health = 1300;
          this.RobberC.Armor = 1400;
          this.RobberC.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
          this.RobberC.CanRagdoll = false;
          this.RobberC.CanSufferCriticalHits = false;
        }
        if (this.RobberCskill == 7)
        {
          this.RobberC.Health = 1600;
          this.RobberC.Armor = 1800;
          this.RobberC.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
          this.RobberC.CanRagdoll = false;
          this.RobberC.CanSufferCriticalHits = false;
        }
      }
      if ((Entity) this.RobberA != (Entity) null)
      {
        Ped robberA1 = this.RobberA;
        position2 = Game.Player.Character.Position;
        Vector3 vector3 = position2.Around(5f);
        robberA1.Position = vector3;
        Ped robberA2 = this.RobberA;
        PedGroup currentPedGroup = Game.Player.Character.CurrentPedGroup;
        Function.Call(Hash._0x9F3480FE65DB31B5, (InputArgument) robberA2, (InputArgument) currentPedGroup);
        Function.Call(Hash._0xC7622C0D36B2FDA8, (InputArgument) robberA2, (InputArgument) 100);
        robberA2.AddBlip();
        robberA2.CurrentBlip.Sprite = BlipSprite.Enemy;
        robberA2.CurrentBlip.Color = BlipColor.Blue;
        robberA2.CurrentBlip.Name = "Heist Partner";
        this.RobberA.CanWrithe = false;
        Function.Call(Hash._0xDBA71115ED9941A6, (InputArgument) this.RobberA, (InputArgument) 3);
      }
      if ((Entity) this.RobberB != (Entity) null)
      {
        Ped robberB1 = this.RobberB;
        position2 = Game.Player.Character.Position;
        Vector3 vector3 = position2.Around(5f);
        robberB1.Position = vector3;
        Ped robberB2 = this.RobberB;
        PedGroup currentPedGroup = Game.Player.Character.CurrentPedGroup;
        Function.Call(Hash._0x9F3480FE65DB31B5, (InputArgument) robberB2, (InputArgument) currentPedGroup);
        Function.Call(Hash._0xC7622C0D36B2FDA8, (InputArgument) robberB2, (InputArgument) 100);
        robberB2.AddBlip();
        robberB2.CurrentBlip.Sprite = BlipSprite.Enemy;
        robberB2.CurrentBlip.Color = BlipColor.Blue;
        robberB2.CurrentBlip.Name = "Heist Partner";
        this.RobberB.CanWrithe = false;
        Function.Call(Hash._0xDBA71115ED9941A6, (InputArgument) this.RobberB, (InputArgument) 3);
      }
      if ((Entity) this.RobberC != (Entity) null)
      {
        Ped robberC1 = this.RobberC;
        position2 = Game.Player.Character.Position;
        Vector3 vector3 = position2.Around(5f);
        robberC1.Position = vector3;
        Ped robberC2 = this.RobberC;
        PedGroup currentPedGroup = Game.Player.Character.CurrentPedGroup;
        Function.Call(Hash._0x9F3480FE65DB31B5, (InputArgument) robberC2, (InputArgument) currentPedGroup);
        Function.Call(Hash._0xC7622C0D36B2FDA8, (InputArgument) robberC2, (InputArgument) 100);
        robberC2.AddBlip();
        robberC2.CurrentBlip.Sprite = BlipSprite.Enemy;
        robberC2.CurrentBlip.Color = BlipColor.Blue;
        robberC2.CurrentBlip.Name = "Heist Partner";
        this.RobberC.CanWrithe = false;
        Function.Call(Hash._0xDBA71115ED9941A6, (InputArgument) this.RobberC, (InputArgument) 3);
      }
      if ((Entity) this.RobberA != (Entity) null)
      {
        this.RobberA.FiringPattern = this.RobberAFP;
        this.RobberA.Weapons.Give(WeaponHash.Pistol, 9999, false, true);
        this.RobberA.Weapons.Give(WeaponHash.MicroSMG, 9999, false, true);
        this.RobberA.Weapons.Give(WeaponHash.Parachute, 9999, false, true);
        this.RobberA.DrownsInWater = false;
        this.RobberA.AlwaysDiesOnLowHealth = false;
        this.RobberA.CanFlyThroughWindscreen = false;
        this.RobberA.CanSufferCriticalHits = false;
        this.RobberA.CanWrithe = false;
        this.RobberA.DrownsInSinkingVehicle = false;
        this.RobberA.DiesInstantlyInWater = false;
        this.RobberA.CanSwitchWeapons = true;
        this.RobberA.DrivingSpeed = 200f;
      }
      if ((Entity) this.RobberB != (Entity) null)
      {
        this.RobberB.FiringPattern = this.RobberBFP;
        this.RobberB.Weapons.Give(WeaponHash.Pistol, 9999, false, true);
        this.RobberB.Weapons.Give(WeaponHash.MicroSMG, 9999, false, true);
        this.RobberB.Weapons.Give(WeaponHash.Parachute, 9999, false, true);
        this.RobberB.DrownsInWater = false;
        this.RobberB.AlwaysDiesOnLowHealth = false;
        this.RobberB.CanFlyThroughWindscreen = false;
        this.RobberB.CanSufferCriticalHits = false;
        this.RobberB.CanWrithe = false;
        this.RobberB.DrownsInSinkingVehicle = false;
        this.RobberB.DiesInstantlyInWater = false;
        this.RobberB.CanSwitchWeapons = true;
        this.RobberB.DrivingSpeed = 200f;
      }
      if ((Entity) this.RobberC != (Entity) null)
      {
        this.RobberC.FiringPattern = this.RobberCFP;
        this.RobberC.Weapons.Give(WeaponHash.Pistol, 9999, false, true);
        this.RobberC.Weapons.Give(WeaponHash.MicroSMG, 9999, false, true);
        this.RobberC.Weapons.Give(WeaponHash.Parachute, 9999, false, true);
        this.RobberC.DrownsInWater = false;
        this.RobberC.AlwaysDiesOnLowHealth = false;
        this.RobberC.CanFlyThroughWindscreen = false;
        this.RobberC.CanSufferCriticalHits = false;
        this.RobberC.CanWrithe = false;
        this.RobberC.DrownsInSinkingVehicle = false;
        this.RobberC.DiesInstantlyInWater = false;
        this.RobberC.CanSwitchWeapons = true;
        this.RobberC.DrivingSpeed = 200f;
      }
      this.hackedDataPad = false;
      this.FreezeGetawayCar = false;
      this.FreezeGetawayCar2 = false;
      this.TriggerNotifyNear = false;
      this.PlacedBomb = false;
      this.EscapingCasino = false;
      this.VaultClosed = true;
      this.InCasino = true;
      this.MetalDetectorOn = true;
      this.MissionOn = true;
      this.IsInterior = false;
      this.BypassMetalDetector = false;
      this.AlarmsGoingOff = false;
      this.GotCash = false;
      this.TriggeredWantedLevelEscape = false;
      this.IsPlanting = false;
      this.NotifyOutVault = false;
      this.CurrentPay = 0;
      this.AlarmsGoingOff = false;
      this.HeadingtoFactory = false;
      this.SetSewerBomb = false;
      this.DetonatedSewerBomb = false;
      this.EnteredNormalCasino = false;
      this.EnteredOffice = false;
      this.TriggeredAttack = false;
      this.NotifyOutVault2 = false;
      this.InNormalCasino = false;
      this.OverideAlarm = false;
      this.AlarmTimer = 0;
      this.TriggerFullResponce = false;
      this.TriggerFullResponce2 = false;
      this.TriggerFullResponce3 = false;
      this.ReportedtoGuardA = false;
      this.ReportedtoGuardB = false;
      this.NotifyHack = false;
      this.ExtraVaultOpen = false;
      this.ExtraValuableType = 0;
      this.RobbedExtraValuable = false;
      this.ReportTimer = 0;
      this.MaxPay = new System.Random().Next(15000000, 45000000);
      if (this.Bank != (Blip) null)
        this.Bank.Remove();
      if ((Entity) this.GetawayCar != (Entity) null)
        this.GetawayCar.Delete();
      try
      {
        if (this.EnteranceUsed == 0 || this.EnteranceUsed == 2)
        {
          this.SaveCar.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//CasinoHeist//DiamondCasinoHeist_GetawayCars//DiamondHeist_Land.ini");
          this.VehicleChoosen = this.SaveCar.VehicleName;
          this.isInterior = true;
          this.GetawayCar = World.CreateVehicle(this.RequestModel(VehicleHash.Burrito2), new Vector3(2708.4f, -388.0075f, -55f), 90f);
          this.GetawayCar.AddBlip();
          this.GetawayCar.CurrentBlip.Sprite = BlipSprite.GetawayCar;
          this.GetawayCar.CurrentBlip.Color = BlipColor.Yellow;
          this.GetawayCar.CurrentBlip.Name = "Stockade";
          this.GetawayCar.FreezePosition = false;
          this.GetawayCar.Repair();
          this.GetawayCar.FreezePosition = false;
          this.GetawayCar.EngineRunning = true;
          this.GetawayCar.IsDriveable = true;
          this.GetawayCar.IsInvincible = true;
          this.GetawayCar.FreezePosition = true;
          UI.Notify("~y~ Lester ~w~ Get in your getaway car and make your way up to the Casino and I'll breif you on the way");
        }
        if (this.EnteranceUsed == 1)
        {
          this.SaveCar.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//CasinoHeist//DiamondHeist_Special.ini");
          this.VehicleChoosen = this.SaveCar.VehicleName;
          this.isInterior = true;
          this.GetawayCar = World.CreateVehicle(this.RequestModel(VehicleHash.Burrito2), new Vector3(2708.4f, -388.0075f, -55f), 90f);
          this.GetawayCar.AddBlip();
          this.GetawayCar.CurrentBlip.Sprite = BlipSprite.GetawayCar;
          this.GetawayCar.CurrentBlip.Color = BlipColor.Yellow;
          this.GetawayCar.CurrentBlip.Name = "Stockade";
          this.GetawayCar.FreezePosition = false;
          this.GetawayCar.Repair();
          this.GetawayCar.FreezePosition = false;
          this.GetawayCar.EngineRunning = true;
          this.GetawayCar.IsDriveable = true;
          this.GetawayCar.IsInvincible = true;
          this.GetawayCar.FreezePosition = true;
          UI.Notify("~y~ Lester ~w~ Get in the Stockade, and make your way to the Casino Desgised as Groupe6");
        }
        if (this.EnteranceUsed == 3 || this.EnteranceUsed == 4)
        {
          this.SaveCar.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//CasinoHeist//DiamondHeist_Air.ini");
          this.VehicleChoosen = this.SaveCar.VehicleName;
          this.GetawayCar = World.CreateVehicle(this.RequestModel(this.VehicleChoosen), new Vector3(-987.7f, -2992.6f, 14f), -90f);
          this.GetawayCar.AddBlip();
          this.GetawayCar.CurrentBlip.Sprite = BlipSprite.Helicopter;
          this.GetawayCar.CurrentBlip.Color = BlipColor.Yellow;
          this.GetawayCar.CurrentBlip.Name = "Getaway Heli";
          this.GetawayCar.FreezePosition = false;
          this.GetawayCar.Repair();
          this.GetawayCar.FreezePosition = false;
          this.GetawayCar.EngineRunning = true;
          this.GetawayCar.IsDriveable = true;
          this.GetawayCar.IsInvincible = true;
          this.GetawayCar.FreezePosition = true;
          UI.Notify("~y~ Lester ~w~ head to LSIA to retrieve your Getaway Heli and make your way to the Casino rooftop after");
        }
        if (this.EnteranceUsed == 5)
        {
          this.SaveCar.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//CasinoHeist//DiamondHeist_Special.ini");
          this.VehicleChoosen = this.SaveCar.VehicleName;
          this.isInterior = true;
          this.GetawayCar = World.CreateVehicle(this.RequestModel(VehicleHash.Burrito2), new Vector3(2708.4f, -388.0075f, -55f), 90f);
          this.GetawayCar.AddBlip();
          this.GetawayCar.CurrentBlip.Sprite = BlipSprite.GetawayCar;
          this.GetawayCar.CurrentBlip.Color = BlipColor.Yellow;
          this.GetawayCar.CurrentBlip.Name = "Bugstars Van";
          this.GetawayCar.FreezePosition = false;
          this.GetawayCar.Repair();
          this.GetawayCar.FreezePosition = false;
          this.GetawayCar.EngineRunning = true;
          this.GetawayCar.IsDriveable = true;
          this.GetawayCar.IsInvincible = true;
          this.GetawayCar.FreezePosition = true;
          UI.Notify("~y~ Lester ~w~ Get in the Bugstars Van, and make your way to the Casino Desgised as Bugstars Exterminator");
        }
      }
      catch
      {
        UI.Notify("~r~ Error ~w~ : Could not spawn in vehicle, please check ini for incorrect name");
      }
      if (this.EnteranceUsed == 0)
      {
        if (this.Bank != (Blip) null)
          this.Bank.Remove();
        this.Bank = World.CreateBlip(new Vector3(925.7f, 45.8f, 80.3f));
        this.Bank.Sprite = BlipSprite.Jewel;
        this.Bank.Color = BlipColor.Yellow;
        this.Bank.Name = "Diamond Casino Enterance (Main)";
      }
      if (this.EnteranceUsed == 1)
      {
        if (this.Bank != (Blip) null)
          this.Bank.Remove();
        this.Bank = World.CreateBlip(new Vector3(932.7f, -4.23f, 78.7f));
        this.Bank.Sprite = BlipSprite.Jewel;
        this.Bank.Color = BlipColor.Yellow;
        this.Bank.Name = "Diamond Casino Enterance (Loading Bay)";
      }
      if (this.EnteranceUsed == 2)
      {
        if (this.Bank != (Blip) null)
          this.Bank.Remove();
        this.Bank = World.CreateBlip(new Vector3(992.7f, -141.7f, 34f));
        this.Bank.Sprite = BlipSprite.Jewel;
        this.Bank.Color = BlipColor.Yellow;
        this.Bank.Name = "Diamond Casino Enterance (Sewer)";
      }
      if (this.EnteranceUsed == 3)
      {
        if (this.Bank != (Blip) null)
          this.Bank.Remove();
        this.Bank = World.CreateBlip(new Vector3(953.7f, 3.98f, 110f));
        this.Bank.Sprite = BlipSprite.Jewel;
        this.Bank.Color = BlipColor.Yellow;
        this.Bank.Name = "Diamond Casino Enterance (Roof)";
      }
      if (this.EnteranceUsed == 4)
      {
        if (this.Bank != (Blip) null)
          this.Bank.Remove();
        this.Bank = World.CreateBlip(new Vector3(959.6f, 32.2f, 119f));
        this.Bank.Sprite = BlipSprite.Jewel;
        this.Bank.Color = BlipColor.Yellow;
        this.Bank.Name = "Diamond Casino Enterance (Roof)";
      }
      if (this.EnteranceUsed == 5)
      {
        if (this.Bank != (Blip) null)
          this.Bank.Remove();
        this.Bank = World.CreateBlip(new Vector3(932.7f, -4.23f, 78.7f));
        this.Bank.Sprite = BlipSprite.Jewel;
        this.Bank.Color = BlipColor.Yellow;
        this.Bank.Name = "Diamond Casino Enterance (Loading Bay)";
      }
      if (this.EnteranceUsed == 1)
      {
        if (Game.Player.Character.Model == (Model) PedHash.Michael)
        {
          Ped character = Game.Player.Character;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 5, (InputArgument) 0, (InputArgument) false);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 11, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 14, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (Game.Player.Character.Model == (Model) PedHash.Trevor)
        {
          Ped character = Game.Player.Character;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 6, (InputArgument) 0, (InputArgument) false);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 8, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 14, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (Game.Player.Character.Model == (Model) PedHash.Franklin)
          UI.Notify("Franklin Has No Groupe6 Outfit");
        Game.Player.Character.Weapons.Give(WeaponHash.CeramicPistol, 9999, true, true);
      }
      if (this.EnteranceUsed == 5 && this.ExitUsed == 4)
      {
        if (Game.Player.Character.Model == (Model) PedHash.Michael)
        {
          Ped character = Game.Player.Character;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 6, (InputArgument) 0, (InputArgument) false);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 12, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 11, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 6, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (Game.Player.Character.Model == (Model) PedHash.Trevor)
          UI.Notify("Trevpr Has No Bugstar Outfit Outfit");
        if (Game.Player.Character.Model == (Model) PedHash.Franklin)
        {
          Ped character = Game.Player.Character;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 15, (InputArgument) 0, (InputArgument) false);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 4, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 1, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 1, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 8, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        Game.Player.Character.Weapons.Give(WeaponHash.CeramicPistol, 9999, true, true);
      }
      Ped character1 = Game.Player.Character;
      if (Game.Player.Character.Model == (Model) PedHash.Trevor)
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 9, (InputArgument) 1, (InputArgument) 0, (InputArgument) 1);
      if (Game.Player.Character.Model == (Model) PedHash.Michael)
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 9, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
      if (Game.Player.Character.Model == (Model) PedHash.Franklin)
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 9, (InputArgument) 6, (InputArgument) 0, (InputArgument) 1);
      UI.Notify("~y~ Lester ~w~ Weve gotten intel on the Casino using Elite Guards, marked with a ~b~Blue~w~ Dot, they will able to detect you, if you get too close!");
    }

    public void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.HeistStage = this.Config.GetValue<int>("TheDiamondHiest", "HeistStage", this.HeistStage);
        this.EnteranceUsed = this.Config.GetValue<int>("TheDiamondHiest", "EnteranceUsed", this.EnteranceUsed);
        this.ExitUsed = this.Config.GetValue<int>("TheDiamondHiest", "ExitUsed", this.ExitUsed);
        this.ShowTimeronShiftX = this.Config.GetValue<bool>("Misc", "ShowTimeronShiftX", this.ShowTimeronShiftX);
        this.AIinCasinoHeistCanWander = this.Config.GetValue<bool>("Misc", "AIinCasinoHeistCanWander", this.AIinCasinoHeistCanWander);
        this.AIinCasinoWanderChance = this.Config.GetValue<int>("Misc", "AIinCasinoWanderChance", this.AIinCasinoWanderChance);
        this.AIinCasinoWanderRadius = this.Config.GetValue<int>("Misc", "AIinCasinoWanderRadius", this.AIinCasinoWanderRadius);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void GetLocation()
    {
      UIMenu uiMenu = this.modMenuPool2.AddSubMenu(this.Heists2, "Enterance/Exit");
      this.GUIMenus.Add(uiMenu);
      List<object> items1 = new List<object>();
      items1.Add((object) "Main Entrance");
      items1.Add((object) "Loading Bay - Using Stockade");
      items1.Add((object) "Sewer");
      items1.Add((object) "Rooftop Right - Using Helicopter ");
      items1.Add((object) "Rooftop Left - Using Helicopter ");
      items1.Add((object) "Loading Bay - Bugstars");
      List<object> items2 = new List<object>();
      items2.Add((object) "Main Entrance");
      items2.Add((object) "Sewer");
      items2.Add((object) "Rooftop Right - Using Helicopter ");
      items2.Add((object) "Rooftop Left - Using Helicopter ");
      items2.Add((object) "Loading Bay - Bugstars");
      UIMenuListItem L = new UIMenuListItem("Enterance : ", items1, 0);
      uiMenu.AddItem((UIMenuItem) L);
      UIMenuListItem E = new UIMenuListItem("Exit : ", items2, 0);
      uiMenu.AddItem((UIMenuItem) E);
      UIMenuItem uiMenuItem = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem);
      UIMenuItem Start = new UIMenuItem("Set Enterance & Exit");
      uiMenu.AddItem(Start);
      Start.Description = "Enterance & Exit determines what Gear is needed for the Heist";
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Start)
          return;
        if (E.Index == 4 && L.Index != 5)
          UI.Notify("~y~ Lester ~w~ : if Choosing Bugstars for Exit, Enterance and Exit have to be Bugstars!");
        if (E.Index == 1 && L.Index != 2)
          UI.Notify("~y~ Lester ~w~ : if Choosing Sewer for Exit, Enterance and Exit have to be Sewer!");
        if (E.Index == 1 && L.Index == 2)
        {
          this.LocAt = 7;
          this.EnteranceUsed = L.Index;
          this.Config.SetValue<int>("TheDiamondHiest", "EnteranceUsed", this.EnteranceUsed);
          this.ExitUsed = E.Index;
          this.Config.SetValue<int>("TheDiamondHiest", "ExitUsed", this.ExitUsed);
          this.Config.Save();
          if (this.HeistStartCam != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.HeistStartCam.IsActive = false;
            this.HeistStartCam.Destroy();
            Game.Player.Character.FreezePosition = false;
            Game.Player.CanControlCharacter = true;
            Game.Player.Character.Position = this.FactoryPos;
            this.modMenuPool2.CloseAllMenus();
          }
        }
        if (E.Index == 4 && L.Index == 5)
        {
          this.LocAt = 7;
          this.EnteranceUsed = L.Index;
          this.Config.SetValue<int>("TheDiamondHiest", "EnteranceUsed", this.EnteranceUsed);
          this.ExitUsed = E.Index;
          this.Config.SetValue<int>("TheDiamondHiest", "ExitUsed", this.ExitUsed);
          this.Config.Save();
          if (this.HeistStartCam != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.HeistStartCam.IsActive = false;
            this.HeistStartCam.Destroy();
            Game.Player.Character.FreezePosition = false;
            Game.Player.CanControlCharacter = true;
            Game.Player.Character.Position = this.FactoryPos;
            this.modMenuPool2.CloseAllMenus();
          }
        }
        if (E.Index != 1)
        {
          this.LocAt = 7;
          this.EnteranceUsed = L.Index;
          this.Config.SetValue<int>("TheDiamondHiest", "EnteranceUsed", this.EnteranceUsed);
          this.ExitUsed = E.Index;
          this.Config.SetValue<int>("TheDiamondHiest", "ExitUsed", this.ExitUsed);
          this.Config.Save();
          if (this.HeistStartCam != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.HeistStartCam.IsActive = false;
            this.HeistStartCam.Destroy();
            Game.Player.Character.FreezePosition = false;
            Game.Player.CanControlCharacter = true;
            Game.Player.Character.Position = this.FactoryPos;
            this.modMenuPool2.CloseAllMenus();
          }
        }
        UI.Notify("~y~ Lester ~w~ : Enterance and Exit have been set");
      });
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == L)
        {
          if (L.Index == 0)
          {
            if (this.HeistStartCam != (Camera) null)
            {
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              this.HeistStartCam.IsActive = false;
              this.HeistStartCam.Destroy();
              Game.Player.Character.FreezePosition = false;
              Game.Player.CanControlCharacter = true;
            }
            this.HeistStartCam = World.CreateCamera(new Vector3(910.9f, 43.3f, 82.5f), new Vector3(0.0f, 0.0f, -80f), 60f);
            this.HeistStartCam.IsActive = true;
            this.HeistStartCam.FarClip = 2000f;
            Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            Game.Player.Character.FreezePosition = true;
            Game.Player.CanControlCharacter = false;
            World.RenderingCamera = this.HeistStartCam;
          }
          if (L.Index == 1)
          {
            if (this.HeistStartCam != (Camera) null)
            {
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              this.HeistStartCam.IsActive = false;
              this.HeistStartCam.Destroy();
              Game.Player.Character.FreezePosition = false;
              Game.Player.CanControlCharacter = true;
            }
            this.HeistStartCam = World.CreateCamera(new Vector3(918.4f, -37.6f, 82.5f), new Vector3(0.0f, 0.0f, -28f), 60f);
            this.HeistStartCam.IsActive = true;
            this.HeistStartCam.FarClip = 2000f;
            Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            Game.Player.Character.FreezePosition = true;
            Game.Player.CanControlCharacter = false;
            World.RenderingCamera = this.HeistStartCam;
          }
          if (L.Index == 2)
          {
            if (this.HeistStartCam != (Camera) null)
            {
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              this.HeistStartCam.IsActive = false;
              this.HeistStartCam.Destroy();
              Game.Player.Character.FreezePosition = false;
              Game.Player.CanControlCharacter = true;
            }
            this.HeistStartCam = World.CreateCamera(new Vector3(1039f, -285.2f, 52.3f), new Vector3(0.0f, 0.0f, 18f), 60f);
            this.HeistStartCam.IsActive = true;
            this.HeistStartCam.FarClip = 2000f;
            Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            Game.Player.Character.FreezePosition = true;
            Game.Player.CanControlCharacter = false;
            World.RenderingCamera = this.HeistStartCam;
          }
          if (L.Index == 3)
          {
            if (this.HeistStartCam != (Camera) null)
            {
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              this.HeistStartCam.IsActive = false;
              this.HeistStartCam.Destroy();
              Game.Player.Character.FreezePosition = false;
              Game.Player.CanControlCharacter = true;
            }
            this.HeistStartCam = World.CreateCamera(new Vector3(961.4f, -17.2f, 113.4f), new Vector3(0.0f, 0.0f, 30f), 60f);
            this.HeistStartCam.IsActive = true;
            this.HeistStartCam.FarClip = 2000f;
            Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            Game.Player.Character.FreezePosition = true;
            Game.Player.CanControlCharacter = false;
            World.RenderingCamera = this.HeistStartCam;
          }
          if (L.Index == 4)
          {
            if (this.HeistStartCam != (Camera) null)
            {
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              this.HeistStartCam.IsActive = false;
              this.HeistStartCam.Destroy();
              Game.Player.Character.FreezePosition = false;
              Game.Player.CanControlCharacter = true;
            }
            this.HeistStartCam = World.CreateCamera(new Vector3(949.9f, 30.6f, 121.2f), new Vector3(0.0f, 0.0f, -85f), 60f);
            this.HeistStartCam.IsActive = true;
            this.HeistStartCam.FarClip = 2000f;
            Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            Game.Player.Character.FreezePosition = true;
            Game.Player.CanControlCharacter = false;
            World.RenderingCamera = this.HeistStartCam;
          }
          if (L.Index == 5)
          {
            if (this.HeistStartCam != (Camera) null)
            {
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              this.HeistStartCam.IsActive = false;
              this.HeistStartCam.Destroy();
              Game.Player.Character.FreezePosition = false;
              Game.Player.CanControlCharacter = true;
            }
            this.HeistStartCam = World.CreateCamera(new Vector3(918.4f, -37.6f, 82.5f), new Vector3(0.0f, 0.0f, -28f), 60f);
            this.HeistStartCam.IsActive = true;
            this.HeistStartCam.FarClip = 2000f;
            Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            Game.Player.Character.FreezePosition = true;
            Game.Player.CanControlCharacter = false;
            World.RenderingCamera = this.HeistStartCam;
          }
          if (L.Index == 1)
            UI.Notify("~y~ Lester ~w~ Choosing this Enterance requires a Stockade to be stolen in Setup 2");
          if (L.Index == 3)
          {
            UI.Notify("~y~ Lester ~w~ Choosing this Enterance requires a VIP pass to be stolen in Setup 2");
            UI.Notify("~y~ Lester ~w~ Choosing this Enterance requires a Helicopter to be stolen in Setup 3");
          }
          if (L.Index == 4)
          {
            UI.Notify("~y~ Lester ~w~ Choosing this Enterance requires a VIP pass to be stolen in Setup 2");
            UI.Notify("~y~ Lester ~w~ Choosing this Enterance requires a Helicopter to be stolen in Setup 3");
          }
          if (L.Index == 5)
            UI.Notify("~y~ Lester ~w~ Choosing this Enterance requires a Bugstars Van to be stolen in Setup 3");
        }
        if (item != E)
          return;
        if (E.Index == 0)
        {
          if (this.HeistStartCam != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.HeistStartCam.IsActive = false;
            this.HeistStartCam.Destroy();
            Game.Player.Character.FreezePosition = false;
            Game.Player.CanControlCharacter = true;
          }
          this.HeistStartCam = World.CreateCamera(new Vector3(910.9f, 43.3f, 82.5f), new Vector3(0.0f, 0.0f, -80f), 60f);
          this.HeistStartCam.IsActive = true;
          this.HeistStartCam.FarClip = 2000f;
          Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.FreezePosition = true;
          Game.Player.CanControlCharacter = false;
          World.RenderingCamera = this.HeistStartCam;
        }
        if (E.Index == 1)
        {
          if (this.HeistStartCam != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.HeistStartCam.IsActive = false;
            this.HeistStartCam.Destroy();
            Game.Player.Character.FreezePosition = false;
            Game.Player.CanControlCharacter = true;
          }
          this.HeistStartCam = World.CreateCamera(new Vector3(1039f, -285.2f, 52.3f), new Vector3(0.0f, 0.0f, 18f), 60f);
          this.HeistStartCam.IsActive = true;
          this.HeistStartCam.FarClip = 2000f;
          Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.FreezePosition = true;
          Game.Player.CanControlCharacter = false;
          World.RenderingCamera = this.HeistStartCam;
        }
        if (E.Index == 2)
        {
          if (this.HeistStartCam != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.HeistStartCam.IsActive = false;
            this.HeistStartCam.Destroy();
            Game.Player.Character.FreezePosition = false;
            Game.Player.CanControlCharacter = true;
          }
          this.HeistStartCam = World.CreateCamera(new Vector3(961.4f, -17.2f, 113.4f), new Vector3(0.0f, 0.0f, 30f), 60f);
          this.HeistStartCam.IsActive = true;
          this.HeistStartCam.FarClip = 2000f;
          Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.FreezePosition = true;
          Game.Player.CanControlCharacter = false;
          World.RenderingCamera = this.HeistStartCam;
        }
        if (E.Index == 3)
        {
          if (this.HeistStartCam != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.HeistStartCam.IsActive = false;
            this.HeistStartCam.Destroy();
            Game.Player.Character.FreezePosition = false;
            Game.Player.CanControlCharacter = true;
          }
          this.HeistStartCam = World.CreateCamera(new Vector3(949.9f, 30.6f, 121.2f), new Vector3(0.0f, 0.0f, -85f), 60f);
          this.HeistStartCam.IsActive = true;
          this.HeistStartCam.FarClip = 2000f;
          Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.FreezePosition = true;
          Game.Player.CanControlCharacter = false;
          World.RenderingCamera = this.HeistStartCam;
        }
        if (L.Index == 4)
        {
          if (this.HeistStartCam != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.HeistStartCam.IsActive = false;
            this.HeistStartCam.Destroy();
            Game.Player.Character.FreezePosition = false;
            Game.Player.CanControlCharacter = true;
          }
          this.HeistStartCam = World.CreateCamera(new Vector3(918.4f, -37.6f, 82.5f), new Vector3(0.0f, 0.0f, -28f), 60f);
          this.HeistStartCam.IsActive = true;
          this.HeistStartCam.FarClip = 2000f;
          Game.Player.Character.Position = this.HeistStartCam.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          Game.Player.Character.FreezePosition = true;
          Game.Player.CanControlCharacter = false;
          World.RenderingCamera = this.HeistStartCam;
        }
        if (E.Index == 1)
          UI.Notify("~y~ Lester ~w~ Choosing this Exit requires Enterace to be the same");
        if (E.Index == 2)
          UI.Notify("~y~ Lester ~w~ Choosing this Exit requires a Helicopter to be stolen in Setup 3");
        if (E.Index == 3)
          UI.Notify("~y~ Lester ~w~ Choosing this Exit requires a Helicopter to be stolen in Setup 3");
        if (E.Index == 4)
          UI.Notify("~y~ Lester ~w~ Choosing this Exit requires a Bugstars Van to be stolen in Setup 3");
      });
    }

    public void START() => this.SetuptHeist();

    public void SetuptHeist()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//CasinoHeist//Heist.ini");
      if (this.HeistStage == 1)
      {
        if (this.Main.CheckArcadeOwned() == 1)
          this.FactoryPos = this.Main.GetArcadeLoc();
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        if (this.Bank != (Blip) null)
          this.Bank.Remove();
        if ((Entity) this.Lester != (Entity) null)
          this.Lester.Delete();
        if ((Entity) this.StockadeA != (Entity) null)
          this.StockadeA.Delete();
        if ((Entity) this.StockadeB != (Entity) null)
          this.StockadeB.Delete();
        if ((Entity) this.StockadeC != (Entity) null)
          this.StockadeC.Delete();
        this.Lester = World.CreatePed((Model) PedHash.LesterCrest, Game.Player.Character.Position.Around(5f));
        Ped lester = this.Lester;
        PedGroup currentPedGroup = Game.Player.Character.CurrentPedGroup;
        Function.Call(Hash._0x9F3480FE65DB31B5, (InputArgument) lester, (InputArgument) currentPedGroup);
        Function.Call(Hash._0xC7622C0D36B2FDA8, (InputArgument) lester, (InputArgument) 100);
        this.Bank = World.CreateBlip(new Vector3(921.5f, 49.3f, 79f));
        this.Bank.Sprite = BlipSprite.Jewel;
        this.Bank.Scale = 1.25f;
        this.Bank.Name = "Possible Enterance/Exit";
        this.Bank.ShowRoute = true;
        this.LocAt = 1;
        this.MissionOn = true;
        UI.Notify("~y~ Lester ~w~ :  Let's go take a look at the Casino so we know what were dealing with");
      }
      if (this.HeistStage == 2)
      {
        if (this.Main.CheckArcadeOwned() == 1)
          this.FactoryPos = this.Main.GetArcadeLoc();
        if (this.Bank != (Blip) null)
          this.Bank.Remove();
        if ((Entity) this.Lester != (Entity) null)
          this.Lester.Delete();
        if ((Entity) this.MeetPed != (Entity) null)
          this.MeetPed.Delete();
        foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
        {
          if ((Entity) aircarftCarrierPed != (Entity) null)
            aircarftCarrierPed.Delete();
        }
        foreach (Vehicle aircraftCarrierVehicle in this.AircraftCarrierVehicles)
        {
          if ((Entity) aircraftCarrierVehicle != (Entity) null)
            aircraftCarrierVehicle.Delete();
        }
        foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
        {
          if ((Entity) aircarftCarrierPed != (Entity) null)
            aircarftCarrierPed.Delete();
        }
        foreach (Vehicle aircraftCarrierVehicle in this.AircraftCarrierVehicles)
        {
          if ((Entity) aircraftCarrierVehicle != (Entity) null)
            aircraftCarrierVehicle.Delete();
        }
        if ((Entity) this.StockadeA != (Entity) null)
          this.StockadeA.Delete();
        if ((Entity) this.StockadeB != (Entity) null)
          this.StockadeB.Delete();
        if ((Entity) this.StockadeC != (Entity) null)
          this.StockadeC.Delete();
        foreach (Ped ped in this.Peds)
        {
          if ((Entity) ped != (Entity) null)
            ped.Delete();
        }
        if ((Entity) this.Crate_1 != (Entity) null)
          this.Crate_1.Delete();
        if ((Entity) this.Crate_2 != (Entity) null)
          this.Crate_2.Delete();
        foreach (Vehicle vehicle in this.Veh)
        {
          if ((Entity) vehicle != (Entity) null)
            vehicle.Delete();
        }
        this.GotC4_1 = false;
        this.GotC4_2 = false;
        this.returningtofactroy = false;
        this.isDriving = false;
        this.SecuredAsset_C4 = false;
        this.SecuredAsset_Stockade = false;
        this.SecuredAsset_Vip = false;
        this.Crate_1 = World.CreateProp((Model) "p_secret_weapon_02", new Vector3(461.5811f, -3257.675f, 5.1f), true, false);
        this.Crate_1.FreezePosition = true;
        this.Crate_1.AddBlip();
        this.Crate_1.CurrentBlip.Sprite = BlipSprite.BarrelBomb;
        this.Crate_1.CurrentBlip.Color = BlipColor.Yellow;
        this.Crate_1.CurrentBlip.Name = "C4 Crate";
        this.Crate_2 = World.CreateProp((Model) "p_secret_weapon_02", new Vector3(461.5811f, -3245.603f, 5.1f), true, false);
        this.Crate_2.FreezePosition = true;
        this.Crate_2.AddBlip();
        this.Crate_2.CurrentBlip.Sprite = BlipSprite.BarrelBomb;
        this.Crate_2.CurrentBlip.Color = BlipColor.Yellow;
        this.Crate_2.CurrentBlip.Name = "C4 Crate";
        this.Crate_1.CurrentBlip.ShowRoute = true;
        this.Crate_2.CurrentBlip.ShowRoute = true;
        this.GotC4_1 = false;
        this.GotC4_2 = false;
        this.TriggerUINotify = false;
        Vehicle vehicle1 = World.CreateVehicle((Model) VehicleHash.Valkyrie, new Vector3(470.587f, -3299.076f, 5.1f), -88f);
        vehicle1.PlaceOnGround();
        this.Veh.Add(vehicle1);
        Vehicle vehicle2 = World.CreateVehicle((Model) VehicleHash.Valkyrie, new Vector3(508.5804f, -3358.695f, 5.1f), 87f);
        vehicle2.PlaceOnGround();
        this.Veh.Add(vehicle2);
        Vehicle vehicle3 = World.CreateVehicle((Model) VehicleHash.Valkyrie, new Vector3(506.5158f, -3301.819f, 5.1f), 92f);
        vehicle3.PlaceOnGround();
        this.Veh.Add(vehicle3);
        UI.Notify("~y~ Lester ~w~ : Unfortunatly i have run into a sort of barrier, the Vault, it uses Electro magnetic technology, meaning that a Hacker, or Thirmite will not work on the Vault, at least not alone");
        Script.Wait(1000);
        this.SecuredAsset_C4 = false;
        this.SecuredAsset_Stockade = false;
        this.SecuredAsset_Vip = false;
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//CasinoHeist////Heist.ini");
        if (this.EnteranceUsed == 1)
        {
          foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
          {
            if ((Entity) aircarftCarrierPed != (Entity) null)
              aircarftCarrierPed.Delete();
          }
          foreach (Vehicle aircraftCarrierVehicle in this.AircraftCarrierVehicles)
          {
            if ((Entity) aircraftCarrierVehicle != (Entity) null)
              aircraftCarrierVehicle.Delete();
          }
          if ((Entity) this.StockadeA != (Entity) null)
            this.StockadeA.Delete();
          if ((Entity) this.StockadeB != (Entity) null)
            this.StockadeB.Delete();
          if ((Entity) this.StockadeC != (Entity) null)
            this.StockadeC.Delete();
          UI.Notify("~y~ Lester ~w~ : You will also need to Steal one of the 3, Stockades patroling around LS");
          this.StockadeA = World.CreateVehicle(this.RequestModel(VehicleHash.Stockade), new Vector3(791.5f, -1388.8f, 27.3f), -176f);
          this.StockadeB = World.CreateVehicle(this.RequestModel(VehicleHash.Stockade), this.StockadeA.GetOffsetInWorldCoords(new Vector3(0.0f, -20f, 0.0f)), -176f);
          this.StockadeC = World.CreateVehicle(this.RequestModel(VehicleHash.Stockade), this.StockadeA.GetOffsetInWorldCoords(new Vector3(0.0f, -10f, 0.0f)), -176f);
          this.AircraftCarrierVehicles.Add(this.StockadeA);
          this.AircraftCarrierVehicles.Add(this.StockadeB);
          this.AircraftCarrierVehicles.Add(this.StockadeC);
          foreach (Vehicle aircraftCarrierVehicle in this.AircraftCarrierVehicles)
          {
            if ((Entity) aircraftCarrierVehicle != (Entity) null)
            {
              aircraftCarrierVehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.Armoured01SMM);
              this.AircarftCarrierPeds.Add(aircraftCarrierVehicle.GetPedOnSeat(VehicleSeat.Driver));
              aircraftCarrierVehicle.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.Armoured01SMM);
              this.AircarftCarrierPeds.Add(aircraftCarrierVehicle.GetPedOnSeat(VehicleSeat.LeftRear));
              aircraftCarrierVehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.Armoured01SMM);
              this.AircarftCarrierPeds.Add(aircraftCarrierVehicle.GetPedOnSeat(VehicleSeat.Passenger));
              aircraftCarrierVehicle.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.Armoured01SMM);
              this.AircarftCarrierPeds.Add(aircraftCarrierVehicle.GetPedOnSeat(VehicleSeat.RightRear));
              aircraftCarrierVehicle.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(aircraftCarrierVehicle, this.PointA, 60f, 80f, 786603);
              aircraftCarrierVehicle.AddBlip();
              aircraftCarrierVehicle.CurrentBlip.Sprite = BlipSprite.ArmoredTruck;
              aircraftCarrierVehicle.CurrentBlip.Color = BlipColor.Yellow;
              aircraftCarrierVehicle.CurrentBlip.Name = "Steal A Stockade";
              aircraftCarrierVehicle.CurrentBlip.IsShortRange = true;
            }
          }
          foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
          {
            if ((Entity) aircarftCarrierPed != (Entity) null)
            {
              aircarftCarrierPed.IsPersistent = true;
              aircarftCarrierPed.Weapons.Give(WeaponHash.CarbineRifle, 9999, false, true);
              aircarftCarrierPed.Health = 200;
              aircarftCarrierPed.Armor = 200;
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "SECURITY_GUARD");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) aircarftCarrierPed, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) aircarftCarrierPed, (InputArgument) 0, (InputArgument) 0);
              aircarftCarrierPed.RelationshipGroup = num;
            }
          }
        }
        if (this.EnteranceUsed == 3 || this.EnteranceUsed == 4)
        {
          UI.Notify("~y~ Lester ~w~ :  Because you are using a Rooftop enternace we will need a electronic VIP pass");
          UI.Notify("~y~ Lester ~w~ :  head up to the Casino and see if you can aquire one there");
          if (this.Bank != (Blip) null)
            this.Bank.Remove();
          this.HeistMissson = 1;
          this.Bank = World.CreateBlip(new Vector3(962.9f, 189.9f, 80f));
          this.Bank.Sprite = BlipSprite.Firewall;
          this.Bank.Scale = 1.25f;
          this.Bank.Name = "Search Point";
          this.Bank.ShowRoute = true;
          this.MissionOn = true;
        }
        if (this.EnteranceUsed != 5 || this.ExitUsed != 4)
          ;
        this.MissionOn = true;
      }
      if (this.HeistStage == 3)
      {
        if (this.Main.CheckArcadeOwned() == 1)
          this.FactoryPos = this.Main.GetArcadeLoc();
        if (this.EnteranceUsed != 3 && this.EnteranceUsed != 4 && (this.ExitUsed != 2 && this.ExitUsed != 3) && this.EnteranceUsed != 5)
        {
          if (this.DeliveryPoint != (Blip) null)
            this.DeliveryPoint.Remove();
          this.DeliveryLoc = this.FactoryPos;
          this.DeliveryPoint = World.CreateBlip(this.DeliveryLoc);
          this.DeliveryPoint.Sprite = BlipSprite.CriminalCarstealLost;
          this.DeliveryPoint.Color = BlipColor.Yellow;
          this.DeliveryPoint.Name = "Heist Getaway Car Delivery Point";
          this.DeliveryPoint.ShowRoute = true;
          UI.Notify("~y~ Lester ~w~ : Ok we are all set for the Heist, but we need a getaway car, you will need to provide a car");
          Script.Wait(2000);
          UI.Notify("~y~ Lester ~w~ : You can use any car, even a bike, but it all depends on how many gun men you will be taking");
          Script.Wait(2000);
          UI.Notify("~y~ Lester ~w~ : Deliver the vehicle to the Marked location on your map");
          this.LookingForVehicle = true;
          this.MissionOn = true;
        }
        if (this.EnteranceUsed == 3 || this.EnteranceUsed == 4 || this.ExitUsed == 2 || this.ExitUsed == 3 && this.ExitUsed != 4 && this.EnteranceUsed != 5)
        {
          if (this.DeliveryPoint != (Blip) null)
            this.DeliveryPoint.Remove();
          this.DeliveryPoint = World.CreateBlip(new Vector3(-987.7f, -2992.6f, 14f));
          this.DeliveryPoint.Sprite = BlipSprite.Helicopter;
          this.DeliveryPoint.Color = BlipColor.Yellow;
          this.DeliveryPoint.Name = "Heist Getaway Heli Delivery Point";
          this.DeliveryPoint.ShowRoute = true;
          UI.Notify("~y~ Lester ~w~ : Ok we are all set for the Heist, but we need a getaway car, because you choose Rooftop Enterance or Exit");
          Script.Wait(2000);
          UI.Notify("~y~ Lester ~w~ : You will need to provide a Helicopter, you can use any Helicopter can be weaponized or not, up to you");
          Script.Wait(2000);
          UI.Notify("~y~ Lester ~w~ : Deliver the vehicle to the Marked location on your map");
          this.LookingForVehicle = true;
          this.MissionOn = true;
        }
        if (this.EnteranceUsed == 5 && this.ExitUsed == 4)
        {
          if (this.DeliveryPoint != (Blip) null)
            this.DeliveryPoint.Remove();
          this.DeliveryLoc = this.FactoryPos;
          this.DeliveryPoint = World.CreateBlip(this.DeliveryLoc);
          this.DeliveryPoint.Sprite = BlipSprite.CriminalCarstealLost;
          this.DeliveryPoint.Color = BlipColor.Yellow;
          this.DeliveryPoint.Name = "Heist Getaway Car Delivery Point";
          this.DeliveryPoint.ShowRoute = true;
          UI.Notify("~y~ Lester ~w~ : Ok we are all set for the Heist, but we need a getaway car, you will need to provide a Bugstars Van");
          Script.Wait(2000);
          UI.Notify("~y~ Lester ~w~ : Deliver the vehicle to the Marked location on your map");
          this.LookingForVehicle = true;
          this.MissionOn = true;
        }
      }
      if (this.HeistStage != 4)
        return;
      if (this.Main.CheckArcadeOwned() == 1)
        this.FactoryPos = this.Main.GetArcadeLoc();
      Game.Player.Character.Position = new Vector3(405.9228f, -954.1149f, -99.6627f);
      Script.Wait(1);
      Game.Player.Character.Position = new Vector3(400.4847f, -958.757f, -100f);
      Game.Player.Character.Rotation = new Vector3(0.0f, 0.0f, -73f);
      this.mainMenu.Visible = !this.mainMenu.Visible;
      this.CameraON = true;
      this.HeistStartCam = World.CreateCamera(new Vector3(404.3f, -958.6f, -99f), new Vector3(0.0f, 0.0f, 85f), 60f);
      this.HeistStartCam.IsActive = true;
      this.HeistStartCam.FarClip = 2000f;
      Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
      Game.Player.Character.FreezePosition = true;
      Game.Player.CanControlCharacter = false;
      World.RenderingCamera = this.HeistStartCam;
    }

    public void SetAiAttack()
    {
      if (this.ReinforcementsPeds.Count > 0)
      {
        foreach (Ped reinforcementsPed in this.ReinforcementsPeds)
        {
          if ((Entity) reinforcementsPed != (Entity) null)
          {
            if ((double) World.GetDistance(Game.Player.Character.Position, reinforcementsPed.Position) < 30.0)
            {
              reinforcementsPed.Task.ClearAll();
              int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "SECURITY_GUARD");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) reinforcementsPed, (InputArgument) num);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) reinforcementsPed, (InputArgument) 0, (InputArgument) 0);
              reinforcementsPed.RelationshipGroup = num;
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, reinforcementsPed.Position) > 30.0)
            {
              reinforcementsPed.Task.ClearAll();
              reinforcementsPed.Task.GuardCurrentPosition();
            }
          }
        }
      }
      foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
      {
        if ((Entity) aircarftCarrierPed != (Entity) null)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, aircarftCarrierPed.Position) < 30.0)
          {
            aircarftCarrierPed.Task.ClearAll();
            int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "SECURITY_GUARD");
            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) aircarftCarrierPed, (InputArgument) num);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) aircarftCarrierPed, (InputArgument) 0, (InputArgument) 0);
            aircarftCarrierPed.RelationshipGroup = num;
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, aircarftCarrierPed.Position) > 30.0)
          {
            aircarftCarrierPed.Task.ClearAll();
            aircarftCarrierPed.Task.GuardCurrentPosition();
          }
        }
      }
    }

    public void SpawnReinforcments()
    {
      if (!((Entity) this.CargoPlane != (Entity) null))
        return;
      foreach (Ped reinforcementsPed in this.ReinforcementsPeds)
      {
        if ((Entity) reinforcementsPed != (Entity) null)
          reinforcementsPed.Delete();
      }
      foreach (Vehicle reinforcementsVehicle in this.ReinforcementsVehicles)
      {
        if ((Entity) reinforcementsVehicle != (Entity) null)
          reinforcementsVehicle.Delete();
      }
      Script.Wait(500);
      for (int index = 0; index < 3; ++index)
      {
        Vehicle vehicle = World.CreateVehicle((Model) VehicleHash.Menacer, new Vector3(-1565.4f, -2593.6f, 13f).Around(20f), 143f);
        this.ReinforcementsVehicles.Add(vehicle);
        vehicle.CreatePedOnSeat(VehicleSeat.Driver, (Model) PedHash.MerryWeatherCutscene);
        this.ReinforcementsPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Driver));
        vehicle.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(vehicle, this.CargoPlane.Position, 20f, 120f);
        vehicle.CreatePedOnSeat(VehicleSeat.Passenger, (Model) PedHash.MerryWeatherCutscene);
        this.ReinforcementsPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.Passenger));
        vehicle.CreatePedOnSeat(VehicleSeat.LeftRear, (Model) PedHash.MerryWeatherCutscene);
        this.ReinforcementsPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.LeftRear));
        vehicle.CreatePedOnSeat(VehicleSeat.RightRear, (Model) PedHash.MerryWeatherCutscene);
        this.ReinforcementsPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.RightRear));
        vehicle.CreatePedOnSeat(VehicleSeat.ExtraSeat1, (Model) PedHash.MerryWeatherCutscene);
        this.ReinforcementsPeds.Add(vehicle.GetPedOnSeat(VehicleSeat.ExtraSeat1));
        Script.Wait(1);
      }
      foreach (Ped reinforcementsPed in this.ReinforcementsPeds)
      {
        if ((Entity) reinforcementsPed != (Entity) null)
        {
          reinforcementsPed.IsPersistent = true;
          reinforcementsPed.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);
          if (reinforcementsPed.Model == (Model) PedHash.FreemodeMale01)
          {
            reinforcementsPed.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
            reinforcementsPed.CanSufferCriticalHits = false;
            reinforcementsPed.CanWrithe = false;
            reinforcementsPed.Health = 215;
            reinforcementsPed.Armor = 500;
            Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC");
            Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_STRAFE_BALLISTIC");
            Function.Call(Hash._0xD2A71E1A77418A49, (InputArgument) "move_ballistic_2h");
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) reinforcementsPed, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0xD75ACCF5E0FB5367, (InputArgument) reinforcementsPed, (InputArgument) true, (InputArgument) -1, (InputArgument) 0);
            Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) reinforcementsPed, (InputArgument) "ANIM_GROUP_MOVE_BALLISTIC", (InputArgument) 5f);
            Function.Call(Hash._0x29A28F3F8CF6D854, (InputArgument) reinforcementsPed, (InputArgument) "MOVE_STRAFE_BALLISTIC");
            Function.Call(Hash._0x1055AC3A667F09D9, (InputArgument) reinforcementsPed, (InputArgument) 1429513766);
          }
          if (reinforcementsPed.Model == (Model) PedHash.MerryWeatherCutscene)
          {
            reinforcementsPed.Health = 200;
            reinforcementsPed.Armor = 100;
          }
          if (reinforcementsPed.Model == (Model) PedHash.ArmBoss01GMM)
          {
            reinforcementsPed.Health = 200;
            reinforcementsPed.Armor = 100;
          }
          int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "SECURITY_GUARD");
          Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) reinforcementsPed, (InputArgument) num);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) reinforcementsPed, (InputArgument) 0, (InputArgument) 0);
          reinforcementsPed.RelationshipGroup = num;
        }
      }
    }

    public void SwitchtoHostile()
    {
      if (this.AircarftCarrierPeds.Count <= 0)
        return;
      foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
      {
        if ((Entity) aircarftCarrierPed != (Entity) null && aircarftCarrierPed.IsAlive)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, aircarftCarrierPed.Position) < 5.0)
          {
            int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "Hates_Player");
            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) aircarftCarrierPed, (InputArgument) num);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) aircarftCarrierPed, (InputArgument) 0, (InputArgument) 0);
            aircarftCarrierPed.RelationshipGroup = num;
            aircarftCarrierPed.Task.StandStill(1);
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, aircarftCarrierPed.Position) > 5.0 && (double) World.GetDistance(Game.Player.Character.Position, aircarftCarrierPed.Position) < 25.0)
          {
            int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "SECURITY_GUARD");
            Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) aircarftCarrierPed, (InputArgument) num);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) aircarftCarrierPed, (InputArgument) 0, (InputArgument) 0);
            aircarftCarrierPed.RelationshipGroup = num;
            aircarftCarrierPed.Task.RunTo(Game.Player.Character.Position);
          }
        }
      }
    }

    public void SetupSwat()
    {
      foreach (Ped swatPed in this.SwatPeds)
      {
        if ((Entity) swatPed != (Entity) null)
          swatPed.Delete();
      }
      foreach (Vehicle swatVehicle in this.SwatVehicles)
      {
        if ((Entity) swatVehicle != (Entity) null)
          swatVehicle.Delete();
      }
      this.SwatVehicles.Add(World.CreateVehicle((Model) VehicleHash.Riot, new Vector3(899.4f, 8f, 78.5f), -34f));
      this.SwatVehicles.Add(World.CreateVehicle((Model) VehicleHash.Riot, new Vector3(927.2f, 68.5f, 79.3f), -111f));
      this.SwatVehicles.Add(World.CreateVehicle((Model) VehicleHash.Riot, new Vector3(874.9f, 19.9f, 78.4f), -43f));
      this.SwatVehicles.Add(World.CreateVehicle((Model) VehicleHash.Riot, new Vector3(953.2f, -27.9f, 78.4f), -32f));
      this.SwatVehicles.Add(World.CreateVehicle((Model) VehicleHash.Riot, new Vector3(902.2f, 15.3f, 78.6f), 152f));
      this.SwatVehicles.Add(World.CreateVehicle((Model) VehicleHash.Riot, new Vector3(880.2f, -86f, 79.4f), -135f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(898.9f, 10.6f, 78.8f), 58.9f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(897.2f, 8.24f, 78.8f), 58.9f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(902.6f, 8.79f, 78.8f), -121f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(901.3f, 6.9f, 78.8f), -122f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(901.35f, 6.9f, 78.8f), -122f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(900f, 4.9f, 78.8f), -122f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(899.2f, 3.5f, 78.8f), -122f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(952.5f, -25.7f, 78.7f), 58f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(951.4f, -27.3f, 78.7f), 58f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(950.4f, -29f, 78.8f), 58f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(953f, -24.4f, 78.8f), 58f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(927.6f, 66.2f, 79.9f), 168f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(926f, 66.7f, 79.9f), 160f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(924.5f, 67.2f, 80f), 163f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(880.2f, -85.115f, 78.8f), -30f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(881.5f, -85.9f, 78.8f), -33f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(879.7f, -84.8f, 78.7f), -29f));
      this.SwatPeds.Add(World.CreatePed((Model) PedHash.Swat01SMY, new Vector3(878.1f, -84f, 78.7f), -29f));
      if (this.SwatPeds.Count <= 0)
        return;
      foreach (Ped swatPed in this.SwatPeds)
      {
        if ((Entity) swatPed != (Entity) null && swatPed.IsAlive)
        {
          int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "COP");
          Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) swatPed, (InputArgument) num);
          Function.Call(Hash._0x9F7794730795E019, (InputArgument) swatPed, (InputArgument) 0, (InputArgument) 0);
          swatPed.RelationshipGroup = num;
          swatPed.Health = 200;
          swatPed.Armor = 200;
          swatPed.Weapons.Give(WeaponHash.SMG, 9999, true, true);
        }
      }
    }

    public void CheckCrate(Prop P, Vector3 Pos, Vector3 Rot, int type)
    {
      if (Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1) >= 1024802024)
        this.InitialAnimDone = true;
      if (!this.InitialAnimDone)
        return;
      if (!Function.Call<bool>(Hash._0x1F0B79228E461EC9, (InputArgument) Game.Player.Character, (InputArgument) "anim@heists@ornate_bank@grab_cash", (InputArgument) "bag_intro", (InputArgument) 1) && this.SetRob)
      {
        if (this.CurrentType == 1)
        {
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "anim@heists@ornate_bank@grab_cash", (InputArgument) "grab", (InputArgument) 1000.0, (InputArgument) -4.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.bagProp, (InputArgument) this.Scene1, (InputArgument) "bag_grab", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 1000.0, (InputArgument) -8f, (InputArgument) -8f, (InputArgument) (Rot.Z + 180f), (InputArgument) 1148846080, (InputArgument) 0);
          this.MoneyProp = World.CreateProp(this.RequestModel("ch_prop_20dollar_pile_01a"), Game.Player.Character.Position, new Vector3(), false, false);
          this.MoneyProp.FreezePosition = true;
          this.MoneyProp.HasCollision = false;
          this.MoneyProp.IsInvincible = true;
          this.PlayingAnim = true;
          this.MoneyProp.Position = Game.Player.Character.GetBoneCoord(Bone.IK_L_Hand);
          this.SetRob = false;
          this.InitialAnimDone = false;
        }
        if (this.CurrentType == 2)
        {
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "anim@heists@ornate_bank@grab_cash", (InputArgument) "grab", (InputArgument) 1000.0, (InputArgument) -4.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.bagProp, (InputArgument) this.Scene1, (InputArgument) "bag_grab", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 1000.0, (InputArgument) -8f, (InputArgument) -8f, (InputArgument) (Rot.Z + 180f), (InputArgument) 1148846080, (InputArgument) 0);
          this.MoneyProp = World.CreateProp(this.RequestModel("ch_prop_gold_bar_01a"), Game.Player.Character.Position, new Vector3(), false, false);
          this.MoneyProp.FreezePosition = true;
          this.MoneyProp.HasCollision = false;
          this.MoneyProp.IsInvincible = true;
          this.PlayingAnim = true;
          this.MoneyProp.Position = Game.Player.Character.GetBoneCoord(Bone.IK_L_Hand);
          this.CurrentType = 2;
          this.SetRob = false;
          this.InitialAnimDone = false;
        }
        if (this.CurrentType == 3)
        {
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "anim@heists@ornate_bank@grab_cash", (InputArgument) "grab", (InputArgument) 1000.0, (InputArgument) -4.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.bagProp, (InputArgument) this.Scene1, (InputArgument) "bag_grab", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 1000.0, (InputArgument) -8f, (InputArgument) -8f, (InputArgument) (Rot.Z + 180f), (InputArgument) 1148846080, (InputArgument) 0);
          this.MoneyProp = World.CreateProp(this.RequestModel("ch_prop_vault_dimaondbox_01a"), Game.Player.Character.Position, new Vector3(), false, false);
          this.MoneyProp.FreezePosition = true;
          this.MoneyProp.HasCollision = false;
          this.MoneyProp.IsInvincible = true;
          this.MoneyProp.Position = Game.Player.Character.GetBoneCoord(Bone.IK_L_Hand);
          this.CurrentType = 3;
          this.SetRob = false;
          this.InitialAnimDone = false;
        }
      }
    }

    public void RobCrate(Prop P, Vector3 Pos, Vector3 Rot, int type)
    {
      Ped character = Game.Player.Character;
      if (Game.Player.Character.Model == (Model) PedHash.Trevor)
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      if (Game.Player.Character.Model == (Model) PedHash.Michael)
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      if (Game.Player.Character.Model == (Model) PedHash.Franklin)
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      if ((Entity) this.MoneyProp != (Entity) null)
        this.MoneyProp.Delete();
      if ((Entity) this.bagProp != (Entity) null)
        this.bagProp.Delete();
      if (type == 1)
      {
        this.PlayingAnim = true;
        this.RobTimer = 0;
        this.bagProp = World.CreateProp(this.RequestModel("hei_p_m_bag_var22_arm_s"), Game.Player.Character.Position, false, false);
        this.bagProp.HasCollision = false;
        this.bagProp.IsInvincible = true;
        this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) P.Position.X, (InputArgument) P.Position.Y, (InputArgument) P.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) Rot.Z, (InputArgument) 2);
        Function.Call(Hash._0x6ACF6B7225801CD7, (InputArgument) this.Scene1, (InputArgument) P.Position.X, (InputArgument) P.Position.Y, (InputArgument) P.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) Rot.Z, (InputArgument) true);
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.bagProp, (InputArgument) this.Scene1, (InputArgument) "bag_intro", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 1000.0, (InputArgument) -8f, (InputArgument) -8f, (InputArgument) (Rot.Z + 180f), (InputArgument) 1148846080, (InputArgument) 0);
        Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "anim@heists@ornate_bank@grab_cash", (InputArgument) "intro", (InputArgument) 1000.0, (InputArgument) -4.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
        Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) P, (InputArgument) this.Scene1, (InputArgument) "cart_cash_dissapear", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        this.SetRob = true;
        this.CurrentType = 1;
      }
      if (type == 2)
      {
        this.RobTimer = 0;
        if ((Entity) this.MoneyProp != (Entity) null)
          this.MoneyProp.Delete();
        if ((Entity) this.bagProp != (Entity) null)
          this.bagProp.Delete();
        this.bagProp = World.CreateProp(this.RequestModel("hei_p_m_bag_var22_arm_s"), Game.Player.Character.Position, false, false);
        this.bagProp.HasCollision = false;
        this.bagProp.IsInvincible = true;
        this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) P.Position.X, (InputArgument) P.Position.Y, (InputArgument) P.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) Rot.Z, (InputArgument) 2);
        Function.Call(Hash._0x6ACF6B7225801CD7, (InputArgument) this.Scene1, (InputArgument) P.Position.X, (InputArgument) P.Position.Y, (InputArgument) P.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) Rot.Z, (InputArgument) true);
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.bagProp, (InputArgument) this.Scene1, (InputArgument) "bag_intro", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 1000.0, (InputArgument) -8f, (InputArgument) -8f, (InputArgument) (Rot.Z + 180f), (InputArgument) 1148846080, (InputArgument) 0);
        Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "anim@heists@ornate_bank@grab_cash", (InputArgument) "intro", (InputArgument) 1000.0, (InputArgument) -4.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
        Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
        Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) P, (InputArgument) this.Scene1, (InputArgument) "cart_cash_dissapear", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        this.SetRob = true;
        this.CurrentType = 2;
      }
      if (type != 3)
        return;
      this.RobTimer = 0;
      if ((Entity) this.MoneyProp != (Entity) null)
        this.MoneyProp.Delete();
      if ((Entity) this.bagProp != (Entity) null)
        this.bagProp.Delete();
      this.bagProp = World.CreateProp(this.RequestModel("hei_p_m_bag_var22_arm_s"), Game.Player.Character.Position, false, false);
      this.bagProp.HasCollision = false;
      this.bagProp.IsInvincible = true;
      this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) P.Position.X, (InputArgument) P.Position.Y, (InputArgument) P.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) Rot.Z, (InputArgument) 2);
      Function.Call(Hash._0x6ACF6B7225801CD7, (InputArgument) this.Scene1, (InputArgument) P.Position.X, (InputArgument) P.Position.Y, (InputArgument) P.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) Rot.Z, (InputArgument) true);
      Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.bagProp, (InputArgument) this.Scene1, (InputArgument) "bag_intro", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 1000.0, (InputArgument) -8f, (InputArgument) -8f, (InputArgument) (Rot.Z + 180f), (InputArgument) 1148846080, (InputArgument) 0);
      Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "anim@heists@ornate_bank@grab_cash", (InputArgument) "intro", (InputArgument) 1000.0, (InputArgument) -4.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
      Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
      Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) P, (InputArgument) this.Scene1, (InputArgument) "cart_cash_dissapear", (InputArgument) TheDiamondHeist.LoadDict("anim@heists@ornate_bank@grab_cash"), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
      this.SetRob = true;
      this.CurrentType = 3;
    }

    public void SetPedOutfitCutscene(string MP, Ped NonCutscene)
    {
      if (MP.Equals("MP_1"))
      {
        this.CutscenePed1Comp[0] = "0_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 0).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 0).ToString();
        this.CutscenePed1Comp[1] = "1_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 1).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 1).ToString();
        this.CutscenePed1Comp[2] = "2_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 2).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 2).ToString();
        this.CutscenePed1Comp[3] = "3_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 3).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 3).ToString();
        this.CutscenePed1Comp[4] = "4_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 4).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 4).ToString();
        this.CutscenePed1Comp[5] = "5_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 5).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 5).ToString();
        this.CutscenePed1Comp[6] = "6_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 6).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 6).ToString();
        this.CutscenePed1Comp[7] = "7_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 7).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 7).ToString();
        this.CutscenePed1Comp[8] = "8_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 8).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 8).ToString();
        this.CutscenePed1Comp[9] = "9_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 9).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 9).ToString();
        this.CutscenePed1Comp[10] = "10_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 10).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 10).ToString();
        this.CutscenePed1Comp[11] = "11_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 11).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 11).ToString();
      }
      if (MP.Equals("MP_2"))
      {
        this.CutscenePed2Comp[0] = "0_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 0).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 0).ToString();
        this.CutscenePed2Comp[1] = "1_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 1).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 1).ToString();
        this.CutscenePed2Comp[2] = "2_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 2).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 2).ToString();
        this.CutscenePed2Comp[3] = "3_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 3).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 3).ToString();
        this.CutscenePed2Comp[4] = "4_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 4).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 4).ToString();
        this.CutscenePed2Comp[5] = "5_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 5).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 5).ToString();
        this.CutscenePed2Comp[6] = "6_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 6).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 6).ToString();
        this.CutscenePed2Comp[7] = "7_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 7).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 7).ToString();
        this.CutscenePed2Comp[8] = "8_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 8).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 8).ToString();
        this.CutscenePed2Comp[9] = "9_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 9).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 9).ToString();
        this.CutscenePed2Comp[10] = "10_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 10).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 10).ToString();
        this.CutscenePed2Comp[11] = "11_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 11).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 11).ToString();
      }
      if (MP.Equals("MP_3"))
      {
        this.CutscenePed3Comp[0] = "0_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 0).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 0).ToString();
        this.CutscenePed3Comp[1] = "1_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 1).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 1).ToString();
        this.CutscenePed3Comp[2] = "2_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 2).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 2).ToString();
        this.CutscenePed3Comp[3] = "3_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 3).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 3).ToString();
        this.CutscenePed3Comp[4] = "4_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 4).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 4).ToString();
        this.CutscenePed3Comp[5] = "5_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 5).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 5).ToString();
        this.CutscenePed3Comp[6] = "6_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 6).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 6).ToString();
        this.CutscenePed3Comp[7] = "7_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 7).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 7).ToString();
        this.CutscenePed3Comp[8] = "8_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 8).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 8).ToString();
        this.CutscenePed3Comp[9] = "9_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 9).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 9).ToString();
        this.CutscenePed3Comp[10] = "10_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 10).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 10).ToString();
        this.CutscenePed3Comp[11] = "11_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 11).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 11).ToString();
      }
      if (!MP.Equals("MP_4"))
        return;
      this.CutscenePed4Comp[0] = "0_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 0).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 0).ToString();
      this.CutscenePed4Comp[1] = "1_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 1).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 1).ToString();
      this.CutscenePed4Comp[2] = "2_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 2).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 2).ToString();
      this.CutscenePed4Comp[3] = "3_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 3).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 3).ToString();
      this.CutscenePed4Comp[4] = "4_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 4).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 4).ToString();
      this.CutscenePed4Comp[5] = "5_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 5).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 5).ToString();
      this.CutscenePed4Comp[6] = "6_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 6).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 6).ToString();
      this.CutscenePed4Comp[7] = "7_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 7).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 7).ToString();
      this.CutscenePed4Comp[8] = "8_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 8).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 8).ToString();
      this.CutscenePed4Comp[9] = "9_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 9).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 9).ToString();
      this.CutscenePed4Comp[10] = "10_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 10).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 10).ToString();
      this.CutscenePed4Comp[11] = "11_" + Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) NonCutscene, (InputArgument) 11).ToString() + "_" + Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) NonCutscene, (InputArgument) 11).ToString();
    }

    public void GetPedOutfitCutscene(string MP, Ped NonCutscene)
    {
      if (MP.Equals("MP_1"))
      {
        string[] strArray1 = this.CutscenePed1Comp[0].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 0, (InputArgument) int.Parse(strArray1[1]), (InputArgument) int.Parse(strArray1[2]), (InputArgument) 1);
        string[] strArray2 = this.CutscenePed1Comp[1].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 1, (InputArgument) int.Parse(strArray2[1]), (InputArgument) int.Parse(strArray2[2]), (InputArgument) 1);
        string[] strArray3 = this.CutscenePed1Comp[2].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 2, (InputArgument) int.Parse(strArray3[1]), (InputArgument) int.Parse(strArray3[2]), (InputArgument) 1);
        string[] strArray4 = this.CutscenePed1Comp[3].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 3, (InputArgument) int.Parse(strArray4[1]), (InputArgument) int.Parse(strArray4[2]), (InputArgument) 1);
        string[] strArray5 = this.CutscenePed1Comp[4].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 4, (InputArgument) int.Parse(strArray5[1]), (InputArgument) int.Parse(strArray5[2]), (InputArgument) 1);
        string[] strArray6 = this.CutscenePed1Comp[5].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 5, (InputArgument) int.Parse(strArray6[1]), (InputArgument) int.Parse(strArray6[2]), (InputArgument) 1);
        string[] strArray7 = this.CutscenePed1Comp[6].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 6, (InputArgument) int.Parse(strArray7[1]), (InputArgument) int.Parse(strArray7[2]), (InputArgument) 1);
        string[] strArray8 = this.CutscenePed1Comp[7].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 7, (InputArgument) int.Parse(strArray8[1]), (InputArgument) int.Parse(strArray8[2]), (InputArgument) 1);
        string[] strArray9 = this.CutscenePed1Comp[8].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 8, (InputArgument) int.Parse(strArray9[1]), (InputArgument) int.Parse(strArray9[2]), (InputArgument) 1);
        string[] strArray10 = this.CutscenePed1Comp[9].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 9, (InputArgument) int.Parse(strArray10[1]), (InputArgument) int.Parse(strArray10[2]), (InputArgument) 1);
        string[] strArray11 = this.CutscenePed1Comp[10].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 10, (InputArgument) int.Parse(strArray11[1]), (InputArgument) int.Parse(strArray11[2]), (InputArgument) 1);
        string[] strArray12 = this.CutscenePed1Comp[11].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 11, (InputArgument) int.Parse(strArray12[1]), (InputArgument) int.Parse(strArray12[2]), (InputArgument) 1);
      }
      if (MP.Equals("MP_2"))
      {
        string[] strArray1 = this.CutscenePed2Comp[0].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 0, (InputArgument) int.Parse(strArray1[1]), (InputArgument) int.Parse(strArray1[2]), (InputArgument) 1);
        string[] strArray2 = this.CutscenePed2Comp[1].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 1, (InputArgument) int.Parse(strArray2[1]), (InputArgument) int.Parse(strArray2[2]), (InputArgument) 1);
        string[] strArray3 = this.CutscenePed2Comp[2].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 2, (InputArgument) int.Parse(strArray3[1]), (InputArgument) int.Parse(strArray3[2]), (InputArgument) 1);
        string[] strArray4 = this.CutscenePed2Comp[3].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 3, (InputArgument) int.Parse(strArray4[1]), (InputArgument) int.Parse(strArray4[2]), (InputArgument) 1);
        string[] strArray5 = this.CutscenePed2Comp[4].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 4, (InputArgument) int.Parse(strArray5[1]), (InputArgument) int.Parse(strArray5[2]), (InputArgument) 1);
        string[] strArray6 = this.CutscenePed2Comp[5].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 5, (InputArgument) int.Parse(strArray6[1]), (InputArgument) int.Parse(strArray6[2]), (InputArgument) 1);
        string[] strArray7 = this.CutscenePed2Comp[6].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 6, (InputArgument) int.Parse(strArray7[1]), (InputArgument) int.Parse(strArray7[2]), (InputArgument) 1);
        string[] strArray8 = this.CutscenePed2Comp[7].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 7, (InputArgument) int.Parse(strArray8[1]), (InputArgument) int.Parse(strArray8[2]), (InputArgument) 1);
        string[] strArray9 = this.CutscenePed2Comp[8].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 8, (InputArgument) int.Parse(strArray9[1]), (InputArgument) int.Parse(strArray9[2]), (InputArgument) 1);
        string[] strArray10 = this.CutscenePed2Comp[9].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 9, (InputArgument) int.Parse(strArray10[1]), (InputArgument) int.Parse(strArray10[2]), (InputArgument) 1);
        string[] strArray11 = this.CutscenePed2Comp[10].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 10, (InputArgument) int.Parse(strArray11[1]), (InputArgument) int.Parse(strArray11[2]), (InputArgument) 1);
        string[] strArray12 = this.CutscenePed2Comp[11].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 11, (InputArgument) int.Parse(strArray12[1]), (InputArgument) int.Parse(strArray12[2]), (InputArgument) 1);
      }
      if (MP.Equals("MP_3"))
      {
        string[] strArray1 = this.CutscenePed2Comp[0].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 0, (InputArgument) int.Parse(strArray1[1]), (InputArgument) int.Parse(strArray1[2]), (InputArgument) 1);
        string[] strArray2 = this.CutscenePed3Comp[1].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 1, (InputArgument) int.Parse(strArray2[1]), (InputArgument) int.Parse(strArray2[2]), (InputArgument) 1);
        string[] strArray3 = this.CutscenePed3Comp[2].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 2, (InputArgument) int.Parse(strArray3[1]), (InputArgument) int.Parse(strArray3[2]), (InputArgument) 1);
        string[] strArray4 = this.CutscenePed3Comp[3].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 3, (InputArgument) int.Parse(strArray4[1]), (InputArgument) int.Parse(strArray4[2]), (InputArgument) 1);
        string[] strArray5 = this.CutscenePed3Comp[4].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 4, (InputArgument) int.Parse(strArray5[1]), (InputArgument) int.Parse(strArray5[2]), (InputArgument) 1);
        string[] strArray6 = this.CutscenePed3Comp[5].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 5, (InputArgument) int.Parse(strArray6[1]), (InputArgument) int.Parse(strArray6[2]), (InputArgument) 1);
        string[] strArray7 = this.CutscenePed3Comp[6].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 6, (InputArgument) int.Parse(strArray7[1]), (InputArgument) int.Parse(strArray7[2]), (InputArgument) 1);
        string[] strArray8 = this.CutscenePed3Comp[7].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 7, (InputArgument) int.Parse(strArray8[1]), (InputArgument) int.Parse(strArray8[2]), (InputArgument) 1);
        string[] strArray9 = this.CutscenePed3Comp[8].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 8, (InputArgument) int.Parse(strArray9[1]), (InputArgument) int.Parse(strArray9[2]), (InputArgument) 1);
        string[] strArray10 = this.CutscenePed3Comp[9].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 9, (InputArgument) int.Parse(strArray10[1]), (InputArgument) int.Parse(strArray10[2]), (InputArgument) 1);
        string[] strArray11 = this.CutscenePed3Comp[10].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 10, (InputArgument) int.Parse(strArray11[1]), (InputArgument) int.Parse(strArray11[2]), (InputArgument) 1);
        string[] strArray12 = this.CutscenePed3Comp[11].Split('_');
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 11, (InputArgument) int.Parse(strArray12[1]), (InputArgument) int.Parse(strArray12[2]), (InputArgument) 1);
      }
      if (!MP.Equals("MP_4"))
        return;
      string[] strArray13 = this.CutscenePed1Comp[0].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 0, (InputArgument) int.Parse(strArray13[1]), (InputArgument) int.Parse(strArray13[2]), (InputArgument) 1);
      string[] strArray14 = this.CutscenePed4Comp[1].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 1, (InputArgument) int.Parse(strArray14[1]), (InputArgument) int.Parse(strArray14[2]), (InputArgument) 1);
      string[] strArray15 = this.CutscenePed4Comp[2].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 2, (InputArgument) int.Parse(strArray15[1]), (InputArgument) int.Parse(strArray15[2]), (InputArgument) 1);
      string[] strArray16 = this.CutscenePed4Comp[3].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 3, (InputArgument) int.Parse(strArray16[1]), (InputArgument) int.Parse(strArray16[2]), (InputArgument) 1);
      string[] strArray17 = this.CutscenePed4Comp[4].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 4, (InputArgument) int.Parse(strArray17[1]), (InputArgument) int.Parse(strArray17[2]), (InputArgument) 1);
      string[] strArray18 = this.CutscenePed4Comp[5].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 5, (InputArgument) int.Parse(strArray18[1]), (InputArgument) int.Parse(strArray18[2]), (InputArgument) 1);
      string[] strArray19 = this.CutscenePed4Comp[6].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 6, (InputArgument) int.Parse(strArray19[1]), (InputArgument) int.Parse(strArray19[2]), (InputArgument) 1);
      string[] strArray20 = this.CutscenePed4Comp[7].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 7, (InputArgument) int.Parse(strArray20[1]), (InputArgument) int.Parse(strArray20[2]), (InputArgument) 1);
      string[] strArray21 = this.CutscenePed4Comp[8].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 8, (InputArgument) int.Parse(strArray21[1]), (InputArgument) int.Parse(strArray21[2]), (InputArgument) 1);
      string[] strArray22 = this.CutscenePed4Comp[9].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 9, (InputArgument) int.Parse(strArray22[1]), (InputArgument) int.Parse(strArray22[2]), (InputArgument) 1);
      string[] strArray23 = this.CutscenePed4Comp[10].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 10, (InputArgument) int.Parse(strArray23[1]), (InputArgument) int.Parse(strArray23[2]), (InputArgument) 1);
      string[] strArray24 = this.CutscenePed4Comp[11].Split('_');
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) NonCutscene, (InputArgument) 11, (InputArgument) int.Parse(strArray24[1]), (InputArgument) int.Parse(strArray24[2]), (InputArgument) 1);
    }

    public void runCasinoDrill(int scaleform)
    {
      if (this.firsttime)
      {
        Function.Call(Hash._0xFBD96D87AC96D533, (InputArgument) scaleform, (InputArgument) "REVEAL");
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_HOLE_DEPTH", (InputArgument) (this.DrillPos - 0.09f), (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        this.firsttime = false;
      }
      Function.Call(Hash._0xC6796A8FFA375E53);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_POSITION", (InputArgument) 1f, (InputArgument) 0.725f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_NUM_DISCS", (InputArgument) this.NumOfDiscs, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_SPEED", (InputArgument) this.drillspeed, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_DRILL_POSITION", (InputArgument) this.DrillPos, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_TEMPERATURE", (InputArgument) this.temperature, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0x0DF606929C105BE1, (InputArgument) scaleform, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);
    }

    public void runCasinoLaser(int scaleform)
    {
      if (this.firsttime)
      {
        Function.Call(Hash._0xFBD96D87AC96D533, (InputArgument) scaleform, (InputArgument) "REVEAL");
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_HOLE_DEPTH", (InputArgument) (this.DrillPos - 0.09f), (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        this.firsttime = false;
      }
      Function.Call(Hash._0xF6E48914C7A8694E, (InputArgument) scaleform, (InputArgument) "SET_LASER_VISIBLE");
      if ((double) this.drillspeed > 0.00999999977648258)
        Function.Call(Hash._0xC58424BA936EB458, (InputArgument) true);
      else
        Function.Call(Hash._0xC58424BA936EB458, (InputArgument) false);
      Function.Call(Hash._0xC6796A8FFA375E53);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_POSITION", (InputArgument) 1f, (InputArgument) 0.725f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_NUM_DISCS", (InputArgument) this.NumOfDiscs, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_SPEED", (InputArgument) 1f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      if ((double) this.drillspeed != 99.0)
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_LASER_WIDTH", (InputArgument) this.DrillPos, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_DRILL_POSITION", (InputArgument) this.DrillPos, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) scaleform, (InputArgument) "SET_TEMPERATURE", (InputArgument) this.temperature, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0x0DF606929C105BE1, (InputArgument) scaleform, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);
    }

    public int activatescaleCas(string scale)
    {
      this.scaleformloading = Function.Call<int>(Hash._0xC514489CFB8AF806, (InputArgument) scale);
      return Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.scaleformloading) ? 1 : 0;
    }

    public void DestroyScaleform(string scale)
    {
      Function.Call(Hash._0x1D132D614DD86811, (InputArgument) scale);
      this.scaleformloading = Function.Call<int>(Hash._0xC514489CFB8AF806, (InputArgument) scale);
    }

    public void DestoryDrill()
    {
      if (this.scaleformloading != -1)
      {
        Function.Call(Hash._0xFBD96D87AC96D533, (InputArgument) this.scaleformloading, (InputArgument) "RESET");
        this.scaleformloading = -1;
      }
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.Sound);
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.FailSound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.Sound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.FailSound);
      Function.Call(Hash._0x77ED170667F50170, (InputArgument) "DLC_HEIST3\\HEIST_FINALE_LASER_DRILL");
      Function.Call(Hash._0x77ED170667F50170, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL");
      Function.Call(Hash._0x77ED170667F50170, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2");
      this.PlayDrillFXSound = false;
      this.pin_one = false;
      this.pin_two = false;
      this.pin_three = false;
      this.pin_four = false;
      this.pin_five = false;
      this.pin_six = false;
      this.pin_seven = false;
      this.pin_eight = false;
      this.pin_six = false;
      this.pin_seven = false;
      this.pin_eight = false;
      this.UseCasinoDrill = false;
      this.activeCasDrill = false;
      this.activeCasLaser = false;
      this.triggerLockA = false;
      this.triggerLockB = false;
      this.triggerLockC = false;
      this.triggerLockD = false;
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.Pos = 0.0f;
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.Zone = 551f;
      this.Sound = -1;
      if (Function.Call<bool>(Hash._0x74AFEF0D2E1E409B, (InputArgument) this.DrillFX))
        Function.Call(Hash._0xC401503DFE8D53CF, (InputArgument) this.DrillFX, (InputArgument) 0);
      if ((Entity) this.Drill != (Entity) null)
      {
        this.Drill.Position = new Vector3(1000f, 1000f, -300f);
        Script.Wait(500);
        this.Drill.Delete();
      }
      if ((Entity) this.Drill != (Entity) null)
        this.Drill.Delete();
      Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 0, true, true);
      Function.Call(Hash._0xED7F7EFE9FABF340, (InputArgument) false);
      Game.Player.Character.FreezePosition = true;
      while (true)
      {
        int num;
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "anim@heists@fleeca_bank@drilling"))
        {
          if (!Function.Call<bool>(Hash._0x8702416E512EC454, (InputArgument) "fm_mission_controler"))
          {
            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
            {
              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
              {
                if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
                {
                  if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
                  {
                    if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "SAFE_CRACK", (InputArgument) 0, (InputArgument) -1))
                    {
                      if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_Biker_Cracked_Sounds", (InputArgument) 0, (InputArgument) -1))
                      {
                        if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HUD_MINI_GAME_SOUNDSET", (InputArgument) 0, (InputArgument) -1))
                        {
                          if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "MissionFailedSounds", (InputArgument) 0, (InputArgument) -1))
                          {
                            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "dlc_heist_fleeca_bank_door_sounds", (InputArgument) 0, (InputArgument) -1))
                            {
                              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "vault_door", (InputArgument) 0, (InputArgument) -1))
                              {
                                if (!Function.Call<bool>(Hash._0x2F844A8B08D76685, (InputArgument) "Alarms", (InputArgument) 0, (InputArgument) -1))
                                {
                                  num = !Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_HEIST_FLEECA_SOUNDSET", (InputArgument) 0, (InputArgument) -1) ? 1 : 0;
                                  goto label_25;
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        num = 0;
label_25:
        if (num != 0)
          Script.Wait(100);
        else
          break;
      }
      Script.Wait(1);
      this.triggerLockA = false;
      this.triggerLockB = false;
      this.triggerLockC = false;
      this.triggerLockD = false;
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.Pos = 0.0f;
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.scale = Function.Call<int>(Hash._0xC514489CFB8AF806, (InputArgument) "DRILLING");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.scale))
          Script.Wait(100);
        else
          break;
      }
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_SPEED", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_HOLE_DEPTH", (InputArgument) 0.1f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_DRILL_POSITION", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_TEMPERATURE", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      this.Zone = 551f;
      if (Function.Call<bool>(Hash._0x74AFEF0D2E1E409B, (InputArgument) this.DrillFX))
        Function.Call(Hash._0xC401503DFE8D53CF, (InputArgument) this.DrillFX, (InputArgument) 0);
      if ((Entity) this.Drill != (Entity) null)
        this.Drill.Delete();
      Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 0, true, true);
      Function.Call(Hash._0xED7F7EFE9FABF340, (InputArgument) false);
      Game.Player.Character.FreezePosition = true;
      while (true)
      {
        int num;
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "anim@heists@fleeca_bank@drilling"))
        {
          if (!Function.Call<bool>(Hash._0x8702416E512EC454, (InputArgument) "fm_mission_controler"))
          {
            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
            {
              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
              {
                if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
                {
                  if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
                  {
                    if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "SAFE_CRACK", (InputArgument) 0, (InputArgument) -1))
                    {
                      if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_Biker_Cracked_Sounds", (InputArgument) 0, (InputArgument) -1))
                      {
                        if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HUD_MINI_GAME_SOUNDSET", (InputArgument) 0, (InputArgument) -1))
                        {
                          if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "MissionFailedSounds", (InputArgument) 0, (InputArgument) -1))
                          {
                            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "dlc_heist_fleeca_bank_door_sounds", (InputArgument) 0, (InputArgument) -1))
                            {
                              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "vault_door", (InputArgument) 0, (InputArgument) -1))
                              {
                                if (!Function.Call<bool>(Hash._0x2F844A8B08D76685, (InputArgument) "Alarms", (InputArgument) 0, (InputArgument) -1))
                                {
                                  num = !Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_HEIST_FLEECA_SOUNDSET", (InputArgument) 0, (InputArgument) -1) ? 1 : 0;
                                  goto label_50;
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        num = 0;
label_50:
        if (num != 0)
          Script.Wait(100);
        else
          break;
      }
      Model model = new Model("hei_prop_heist_drill");
      model.Request(10000);
      Prop prop = World.CreateProp(model, Game.Player.Character.Position, false, false);
      prop.IsVisible = false;
      this.Isdrilliing = true;
      prop.FreezePosition = true;
      prop.HasCollision = false;
      Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) prop, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
      prop.IsInvincible = true;
      model.MarkAsNoLongerNeeded();
      this.Drill = prop;
      Vector3 vector3 = Game.Player.Character.Position + Game.Player.Character.ForwardVector * 1f;
      Script.Wait(1);
      if ((Entity) this.Drill != (Entity) null)
      {
        this.Drill.Position = new Vector3(1000f, 1000f, -300f);
        Script.Wait(500);
        if ((Entity) this.Drill != (Entity) null)
          this.Drill.Delete();
        if (Function.Call<bool>(Hash._0x74AFEF0D2E1E409B, (InputArgument) this.DrillFX))
          Function.Call(Hash._0xC401503DFE8D53CF, (InputArgument) this.DrillFX, (InputArgument) 0);
        Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 0, true, true);
        this.Speed = 0.0f;
        this.Temp = 0.0f;
        this.Pos = 0.0f;
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_TEMPERATURE", (InputArgument) this.Temp, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_DRILL_POSITION", (InputArgument) this.Pos, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_SPEED", (InputArgument) this.Speed, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        this.Isdrilliing = false;
        Game.Player.Character.Task.ClearAll();
        Game.Player.Character.Task.ClearAllImmediately();
        Function.Call(Hash._0xED7F7EFE9FABF340, (InputArgument) true);
        Game.Player.Character.FreezePosition = false;
      }
      UI.ShowSubtitle("~b~ Drill Delete Complete!");
    }

    public void StartFleecaDrill()
    {
      Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL", (InputArgument) false, (InputArgument) -1);
      Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2", (InputArgument) false, (InputArgument) -1);
      this.DestroyScaleform("DRILLING");
      this.DestoryDrill();
      this.DrillingComplete = false;
      this.UseCasinoDrill = false;
      this.activeCasDrill = false;
      this.activeCasLaser = false;
      this.triggerLockA = false;
      this.triggerLockB = false;
      this.triggerLockC = false;
      this.triggerLockD = false;
      this.pin_one = false;
      this.pin_two = false;
      this.pin_three = false;
      this.pin_four = false;
      this.pin_five = false;
      this.pin_six = false;
      this.pin_seven = false;
      this.pin_eight = false;
      this.pin_six = false;
      this.pin_seven = false;
      this.pin_eight = false;
      this.temperature = 0.0f;
      this.drillspeed = 0.0f;
      this.drillspeed = 0.0f;
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.Pos = 0.0f;
      if (this.Isdrilliing)
        this.DrillScreenStart();
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.scale = Function.Call<int>(Hash._0xC514489CFB8AF806, (InputArgument) "DRILLING");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.scale))
          Script.Wait(100);
        else
          break;
      }
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_SPEED", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_HOLE_DEPTH", (InputArgument) 0.1f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_DRILL_POSITION", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_TEMPERATURE", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      this.Zone = 551f;
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.Sound);
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.FailSound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.Sound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.FailSound);
      if (Function.Call<bool>(Hash._0x74AFEF0D2E1E409B, (InputArgument) this.DrillFX))
        Function.Call(Hash._0xC401503DFE8D53CF, (InputArgument) this.DrillFX, (InputArgument) 0);
      Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 0, true, true);
      Function.Call(Hash._0xED7F7EFE9FABF340, (InputArgument) false);
      Game.Player.Character.FreezePosition = true;
      this.Sound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      this.PinSound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      this.FailSound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      while (true)
      {
        int num;
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "anim@heists@fleeca_bank@drilling"))
        {
          if (!Function.Call<bool>(Hash._0x8702416E512EC454, (InputArgument) "fm_mission_controler"))
          {
            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
            {
              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
              {
                if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
                {
                  if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
                  {
                    if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "SAFE_CRACK", (InputArgument) 0, (InputArgument) -1))
                    {
                      if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_Biker_Cracked_Sounds", (InputArgument) 0, (InputArgument) -1))
                      {
                        if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HUD_MINI_GAME_SOUNDSET", (InputArgument) 0, (InputArgument) -1))
                        {
                          if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "MissionFailedSounds", (InputArgument) 0, (InputArgument) -1))
                          {
                            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "dlc_heist_fleeca_bank_door_sounds", (InputArgument) 0, (InputArgument) -1))
                            {
                              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "vault_door", (InputArgument) 0, (InputArgument) -1))
                              {
                                if (!Function.Call<bool>(Hash._0x2F844A8B08D76685, (InputArgument) "Alarms", (InputArgument) 0, (InputArgument) -1))
                                {
                                  num = !Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_HEIST_FLEECA_SOUNDSET", (InputArgument) 0, (InputArgument) -1) ? 1 : 0;
                                  goto label_24;
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        num = 0;
label_24:
        if (num != 0)
          Script.Wait(100);
        else
          break;
      }
      if ((Entity) this.Drill != (Entity) null)
        this.Drill.Delete();
      Model model = new Model("hei_prop_heist_drill");
      model.Request(10000);
      Prop prop = World.CreateProp(model, Game.Player.Character.Position, false, false);
      this.Isdrilliing = true;
      prop.FreezePosition = true;
      prop.HasCollision = false;
      Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) prop, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
      prop.IsInvincible = true;
      model.MarkAsNoLongerNeeded();
      this.Drill = prop;
      Vector3 vector3 = Game.Player.Character.Position + Game.Player.Character.ForwardVector * 1f;
      Game.Player.Character.Task.PlayAnimation("anim@heists@fleeca_bank@drilling", "drill_right_end", 1f, -1, true, -1f);
      UI.ShowSubtitle("~b~ Drill Start Complete!");
    }

    public void StartCasinoDrill()
    {
      this.Drillstage = 0;
      Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_HEIST3\\HEIST_FINALE_LASER_DRILL", (InputArgument) false, (InputArgument) -1);
      Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL", (InputArgument) false, (InputArgument) -1);
      Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2", (InputArgument) false, (InputArgument) -1);
      this.DestroyScaleform("VAULT_DRILL");
      this.DestoryDrill();
      if (!this.Isdrilliing)
      {
        this.PlayDrillFXSound = false;
        this.DrillingComplete = false;
        this.Temp = 0.0f;
        this.firsttime = false;
        this.UseCasinoDrill = false;
        this.activeCasDrill = false;
        this.activeCasLaser = false;
        this.Isdrilliing = false;
        this.triggerLockA = false;
        this.triggerLockB = false;
        this.triggerLockC = false;
        this.triggerLockD = false;
        this.activatescaleCas("VAULT_DRILL");
        Function.Call(Hash._0xC6796A8FFA375E53);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_NUM_DISCS", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_HOLE_DEPTH", (InputArgument) 99f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_SPEED", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_DRILL_POSITION", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_TEMPERATURE", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_LASER_WIDTH", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_POSITION", (InputArgument) 1f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0x0DF606929C105BE1, (InputArgument) this.scaleformloading, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);
        Function.Call(Hash._0x960C9FF8F616E41C, (InputArgument) "MC_LASER_4", (InputArgument) 1);
        this.depth = this.DrillPos - 0.09f;
        this.drillspeed = 0.0f;
        this.DrillPos = 0.0f;
        this.temperature = 0.0f;
        this.activeCasDrill = !this.activeCasDrill;
        this.UseCasinoDrill = true;
      }
      this.triggerLockA = false;
      this.triggerLockB = false;
      this.triggerLockC = false;
      this.triggerLockD = false;
      this.pin_one = false;
      this.pin_two = false;
      this.pin_three = false;
      this.pin_four = false;
      this.pin_five = false;
      this.temperature = 0.0f;
      this.drillspeed = 0.0f;
      this.drillspeed = 0.0f;
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.Pos = 0.0f;
      if (!this.UseCasinoDrill && this.Isdrilliing)
        this.DrillScreenStart();
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.scale = Function.Call<int>(Hash._0xC514489CFB8AF806, (InputArgument) "DRILLING");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.scale))
          Script.Wait(0);
        else
          break;
      }
      this.activatescaleCas("VAULT_DRILL");
      Function.Call(Hash._0xC6796A8FFA375E53);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_NUM_DISCS", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_HOLE_DEPTH", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_SPEED", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_DRILL_POSITION", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_TEMPERATURE", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_LASER_WIDTH", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_POSITION", (InputArgument) 1f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0x0DF606929C105BE1, (InputArgument) this.scaleformloading, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);
      Function.Call(Hash._0x960C9FF8F616E41C, (InputArgument) "MC_DRILL_4", (InputArgument) 1);
      this.Zone = 551f;
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.Sound);
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.FailSound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.Sound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.FailSound);
      if (Function.Call<bool>(Hash._0x74AFEF0D2E1E409B, (InputArgument) this.DrillFX))
        Function.Call(Hash._0xC401503DFE8D53CF, (InputArgument) this.DrillFX, (InputArgument) 0);
      Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 0, true, true);
      Function.Call(Hash._0xED7F7EFE9FABF340, (InputArgument) false);
      Game.Player.Character.FreezePosition = true;
      this.Sound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      this.PinSound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      this.FailSound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      while (true)
      {
        int num;
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "anim@heists@fleeca_bank@drilling"))
        {
          if (!Function.Call<bool>(Hash._0x8702416E512EC454, (InputArgument) "fm_mission_controler"))
          {
            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
            {
              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
              {
                if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
                {
                  if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
                  {
                    if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "SAFE_CRACK", (InputArgument) 0, (InputArgument) -1))
                    {
                      if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_Biker_Cracked_Sounds", (InputArgument) 0, (InputArgument) -1))
                      {
                        if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HUD_MINI_GAME_SOUNDSET", (InputArgument) 0, (InputArgument) -1))
                        {
                          if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "MissionFailedSounds", (InputArgument) 0, (InputArgument) -1))
                          {
                            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "dlc_heist_fleeca_bank_door_sounds", (InputArgument) 0, (InputArgument) -1))
                            {
                              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "vault_door", (InputArgument) 0, (InputArgument) -1))
                              {
                                if (!Function.Call<bool>(Hash._0x2F844A8B08D76685, (InputArgument) "Alarms", (InputArgument) 0, (InputArgument) -1))
                                {
                                  num = !Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_HEIST_FLEECA_SOUNDSET", (InputArgument) 0, (InputArgument) -1) ? 1 : 0;
                                  goto label_26;
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        num = 0;
label_26:
        if (num != 0)
          Script.Wait(0);
        else
          break;
      }
      if ((Entity) this.Drill != (Entity) null)
        this.Drill.Delete();
      Model model = new Model("hei_prop_heist_drill");
      model.Request(10000);
      Prop prop = World.CreateProp(model, Game.Player.Character.Position, false, false);
      this.Isdrilliing = true;
      prop.FreezePosition = true;
      prop.HasCollision = false;
      Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) prop, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
      prop.IsInvincible = true;
      model.MarkAsNoLongerNeeded();
      this.Drill = prop;
      Vector3 vector3 = Game.Player.Character.Position + Game.Player.Character.ForwardVector * 1f;
      Game.Player.Character.Task.PlayAnimation("anim@heists@fleeca_bank@drilling", "drill_right_end", 1f, -1, true, -1f);
      this.firsttime = true;
      UI.ShowSubtitle("~b~ Drill Start Complete!");
    }

    public void StartCasinoLaser()
    {
      this.Drillstage = 0;
      Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_HEIST3\\HEIST_FINALE_LASER_DRILL", (InputArgument) false, (InputArgument) -1);
      Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_HEIST3\\HEIST_FINALE_LASER_DRILL", (InputArgument) false, (InputArgument) -1);
      Function.Call(Hash._0x2F844A8B08D76685, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2", (InputArgument) false, (InputArgument) -1);
      this.DestroyScaleform("VAULT_LASER");
      this.DestoryDrill();
      if (!this.Isdrilliing)
      {
        this.PlayDrillFXSound = false;
        this.DrillingComplete = false;
        this.Temp = 0.0f;
        this.firsttime = false;
        this.UseCasinoDrill = false;
        this.activeCasDrill = false;
        this.activeCasLaser = false;
        this.Isdrilliing = false;
        this.triggerLockA = false;
        this.triggerLockB = false;
        this.triggerLockC = false;
        this.triggerLockD = false;
        this.activatescaleCas("VAULT_LASER");
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_NUM_DISCS", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_HOLE_DEPTH", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_SPEED", (InputArgument) 0, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_DRILL_POSITION", (InputArgument) 0, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_TEMPERATURE", (InputArgument) 0, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_LASER_WIDTH", (InputArgument) 0, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_POSITION", (InputArgument) 1f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
        this.depth = this.DrillPos - 0.09f;
        this.drillspeed = 0.0f;
        this.DrillPos = 0.0f;
        this.temperature = 0.0f;
        Game.Player.Character.FreezePosition = true;
        this.activeCasLaser = !this.activeCasLaser;
        this.UseCasinoDrill = true;
      }
      this.triggerLockA = false;
      this.triggerLockB = false;
      this.triggerLockC = false;
      this.triggerLockD = false;
      this.pin_one = false;
      this.pin_two = false;
      this.pin_three = false;
      this.pin_four = false;
      this.pin_five = false;
      this.pin_six = false;
      this.pin_seven = false;
      this.pin_eight = false;
      this.temperature = 0.0f;
      this.drillspeed = 0.0f;
      this.drillspeed = 0.0f;
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.Pos = 0.0f;
      if (!this.UseCasinoDrill && this.Isdrilliing)
        this.DrillScreenStart();
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.scale = Function.Call<int>(Hash._0xC514489CFB8AF806, (InputArgument) "DRILLING");
      while (true)
      {
        if (!Function.Call<bool>(Hash._0x85F01B8D5B90570E, (InputArgument) this.scale))
          Script.Wait(0);
        else
          break;
      }
      this.activatescaleCas("VAULT_LASER");
      Function.Call(Hash._0xC6796A8FFA375E53);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_NUM_DISCS", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_HOLE_DEPTH", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_SPEED", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_DRILL_POSITION", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_TEMPERATURE", (InputArgument) 0.0f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_LASER_WIDTH", (InputArgument) -1f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scaleformloading, (InputArgument) "SET_POSITION", (InputArgument) 1f, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0x0DF606929C105BE1, (InputArgument) this.scaleformloading, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) 0);
      Function.Call(Hash._0x960C9FF8F616E41C, (InputArgument) "MC_LASER_4", (InputArgument) 1);
      this.Zone = 551f;
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.Sound);
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.FailSound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.Sound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.FailSound);
      if (Function.Call<bool>(Hash._0x74AFEF0D2E1E409B, (InputArgument) this.DrillFX))
        Function.Call(Hash._0xC401503DFE8D53CF, (InputArgument) this.DrillFX, (InputArgument) 0);
      Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 0, true, true);
      Function.Call(Hash._0xED7F7EFE9FABF340, (InputArgument) false);
      Game.Player.Character.FreezePosition = true;
      this.Sound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      this.PinSound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      this.FailSound = Function.Call<int>(Hash._0x430386FE9BF80B45);
      while (true)
      {
        int num;
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) "anim@heists@fleeca_bank@drilling"))
        {
          if (!Function.Call<bool>(Hash._0x8702416E512EC454, (InputArgument) "fm_mission_controler"))
          {
            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
            {
              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
              {
                if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL", (InputArgument) 0, (InputArgument) -1))
                {
                  if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_MPHEIST\\HEIST_FLEECA_DRILL_2", (InputArgument) 0, (InputArgument) -1))
                  {
                    if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "SAFE_CRACK", (InputArgument) 0, (InputArgument) -1))
                    {
                      if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_Biker_Cracked_Sounds", (InputArgument) 0, (InputArgument) -1))
                      {
                        if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "HUD_MINI_GAME_SOUNDSET", (InputArgument) 0, (InputArgument) -1))
                        {
                          if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "MissionFailedSounds", (InputArgument) 0, (InputArgument) -1))
                          {
                            if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "dlc_heist_fleeca_bank_door_sounds", (InputArgument) 0, (InputArgument) -1))
                            {
                              if (!Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "vault_door", (InputArgument) 0, (InputArgument) -1))
                              {
                                if (!Function.Call<bool>(Hash._0x2F844A8B08D76685, (InputArgument) "Alarms", (InputArgument) 0, (InputArgument) -1))
                                {
                                  num = !Function.Call<bool>(Hash._0xFE02FFBED8CA9D99, (InputArgument) "DLC_HEIST_FLEECA_SOUNDSET", (InputArgument) 0, (InputArgument) -1) ? 1 : 0;
                                  goto label_26;
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        num = 0;
label_26:
        if (num != 0)
          Script.Wait(0);
        else
          break;
      }
      if ((Entity) this.Drill != (Entity) null)
        this.Drill.Delete();
      Model model = new Model("ch_prop_laserdrill_01a");
      model.Request(10000);
      Prop prop = World.CreateProp(model, Game.Player.Character.Position, false, false);
      this.Isdrilliing = true;
      prop.FreezePosition = true;
      prop.HasCollision = false;
      Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) prop, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
      prop.IsInvincible = true;
      model.MarkAsNoLongerNeeded();
      this.Drill = prop;
      Vector3 vector3 = Game.Player.Character.Position + Game.Player.Character.ForwardVector * 1f;
      Game.Player.Character.Task.PlayAnimation("anim@heists@fleeca_bank@drilling", "drill_right_end", 1f, -1, true, -1f);
      this.firsttime = true;
    }

    public void OnTick(object sender, EventArgs e)
    {
      // ISSUE: The method is too long to display (77891 instructions)
    }

    public void DrillScreen(float z)
    {
      Convert.ToInt32(UIMenu.GetScreenResolutionMantainRatio().Width / 2f);
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.CallFunction("CLEAR_ALL");
      scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", (object) 0);
      scaleform.CallFunction("CREATE_CONTAINER");
      Function.Call(Hash._0x0DF606929C105BE1, (InputArgument) this.scale, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_TEMPERATURE", (InputArgument) this.Temp, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_DRILL_POSITION", (InputArgument) this.Pos, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_SPEED", (InputArgument) this.Speed, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      scaleform.CallFunction("SET_DATA_SLOT", (object) 0, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 32, (InputArgument) 0), (object) "More Power");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 1, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 33, (InputArgument) 0), (object) "Less Power");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 2, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 76, (InputArgument) 0), (object) "Use Drill");
      scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", (object) -1);
      scaleform.Render2D();
    }

    public void DrillScreenStart()
    {
      Convert.ToInt32(UIMenu.GetScreenResolutionMantainRatio().Width / 2f);
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.CallFunction("CLEAR_ALL");
      scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", (object) 0);
      scaleform.CallFunction("CREATE_CONTAINER");
      Function.Call(Hash._0x0DF606929C105BE1, (InputArgument) this.scale, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue);
      this.Speed = 0.0f;
      this.Temp = 0.0f;
      this.Pos = 0.0f;
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_TEMPERATURE", (InputArgument) this.Temp, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_DRILL_POSITION", (InputArgument) this.Pos, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      Function.Call(Hash._0xD0837058AE2E4BEE, (InputArgument) this.scale, (InputArgument) "SET_SPEED", (InputArgument) this.Speed, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432, (InputArgument) -1082130432);
      scaleform.CallFunction("SET_DATA_SLOT", (object) 0, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 32, (InputArgument) 0), (object) "More Power");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 1, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 33, (InputArgument) 0), (object) "Less Power");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 2, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 76, (InputArgument) 0), (object) "Use Drill");
      scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", (object) -1);
      scaleform.Render2D();
      scaleform.Unload();
      scaleform.Dispose();
    }

    public void OnKeyDown(object sender, KeyEventArgs e)
    {
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.Sound);
      Function.Call(Hash._0xA3B0C41BA5CC0BB5, (InputArgument) this.FailSound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.Sound);
      Function.Call(Hash._0x353FC880830B88FA, (InputArgument) this.FailSound);
      if ((Entity) this.Drill != (Entity) null)
        this.Drill.Delete();
      if (Function.Call<bool>(Hash._0x74AFEF0D2E1E409B, (InputArgument) this.DrillFX))
        Function.Call(Hash._0xC401503DFE8D53CF, (InputArgument) this.DrillFX, (InputArgument) 0);
      if ((Entity) this.CutsenePed1 != (Entity) null)
        this.CutsenePed1.Delete();
      if ((Entity) this.CutsenePed2 != (Entity) null)
        this.CutsenePed2.Delete();
      if ((Entity) this.CutsenePed3 != (Entity) null)
        this.CutsenePed3.Delete();
      if ((Entity) this.CutsenePed4 != (Entity) null)
        this.CutsenePed4.Delete();
      foreach (Prop smokeEmitter in this.SmokeEmitters)
      {
        if ((Entity) smokeEmitter != (Entity) null)
          smokeEmitter.Delete();
      }
      if ((Entity) this.Vent != (Entity) null)
        this.Vent.Delete();
      Function.Call(Hash._0xB8FEAEEBCC127425, (InputArgument) Game.Player.Character);
      if ((Entity) this.HackConsole != (Entity) null)
        this.HackConsole.Delete();
      if ((Entity) this.ExtraValuable != (Entity) null)
        this.ExtraValuable.Delete();
      if ((Entity) this.VaultDoor != (Entity) null)
        this.VaultDoor.Delete();
      foreach (Ped swatPed in this.SwatPeds)
      {
        if ((Entity) swatPed != (Entity) null)
          swatPed.Delete();
      }
      foreach (Vehicle swatVehicle in this.SwatVehicles)
      {
        if ((Entity) swatVehicle != (Entity) null)
          swatVehicle.Delete();
      }
      if ((Entity) this.MoneyProp != (Entity) null)
        this.MoneyProp.Delete();
      if ((Entity) this._cashGrabTray1 != (Entity) null)
        this._cashGrabTray1.Delete();
      if ((Entity) this.bagProp != (Entity) null)
        this.bagProp.Delete();
      foreach (Prop crateValuable in this.Crate_Valuables)
      {
        if ((Entity) crateValuable != (Entity) null)
          crateValuable.Delete();
      }
      if ((Entity) this.SecondaryGetawayVeh != (Entity) null)
        this.SecondaryGetawayVeh.Delete();
      if (this.DeliveryPoint != (Blip) null)
        this.DeliveryPoint.Remove();
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if ((Entity) this.Crate_1 != (Entity) null)
        this.Crate_1.Delete();
      if ((Entity) this.Crate_2 != (Entity) null)
        this.Crate_2.Delete();
      foreach (Vehicle vehicle in this.Veh)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if ((Entity) this.StockadeA != (Entity) null)
        this.StockadeA.Delete();
      if ((Entity) this.StockadeB != (Entity) null)
        this.StockadeB.Delete();
      if ((Entity) this.StockadeC != (Entity) null)
        this.StockadeC.Delete();
      if ((Entity) this.Lester != (Entity) null)
        this.Lester.Delete();
      if ((Entity) this.Prizecar != (Entity) null)
        this.Prizecar.Delete();
      foreach (Ped ped in this.SMPed)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if ((Entity) this.WheelProp != (Entity) null)
        this.WheelProp.Delete();
      if ((Entity) this.WheelProp2 != (Entity) null)
        this.WheelProp2.Delete();
      if ((Entity) this.BasePlate != (Entity) null)
        this.BasePlate.Delete();
      foreach (Ped ped in this.MainPed)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      foreach (Prop table in this.Tables)
      {
        if ((Entity) table != (Entity) null)
          table.Delete();
      }
      foreach (Prop prop in this.Tables2)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      foreach (Ped reinforcementsPed in this.ReinforcementsPeds)
      {
        if ((Entity) reinforcementsPed != (Entity) null)
          reinforcementsPed.Delete();
      }
      foreach (Vehicle reinforcementsVehicle in this.ReinforcementsVehicles)
      {
        if ((Entity) reinforcementsVehicle != (Entity) null)
          reinforcementsVehicle.Delete();
      }
      foreach (Blip blip in this.HubPointsBlip)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
      if (this.Bank != (Blip) null)
        this.Bank.Remove();
      if ((Entity) this.GetawayCar != (Entity) null)
        this.GetawayCar.Delete();
      foreach (Vehicle vehicle in this.AircraftCarrierVehicles2)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      foreach (Ped aircarftCarrierPed in this.AircarftCarrierPeds)
      {
        if ((Entity) aircarftCarrierPed != (Entity) null)
          aircarftCarrierPed.Delete();
      }
      foreach (Vehicle aircraftCarrierVehicle in this.AircraftCarrierVehicles)
      {
        if ((Entity) aircraftCarrierVehicle != (Entity) null)
          aircraftCarrierVehicle.Delete();
      }
      foreach (Vehicle vehicle in this.AttackAircraft)
      {
        if ((Entity) vehicle != (Entity) null)
          vehicle.Delete();
      }
      foreach (Ped ped in this.AttackPed)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if (this.HeistStartCam != (Camera) null)
      {
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        this.HeistStartCam.IsActive = false;
        this.HeistStartCam.Destroy();
        Game.Player.Character.FreezePosition = false;
        Game.Player.CanControlCharacter = true;
      }
      if ((Entity) this.RobberC != (Entity) null)
        this.RobberC.Delete();
      if ((Entity) this.RobberB != (Entity) null)
        this.RobberB.Delete();
      if ((Entity) this.RobberA != (Entity) null)
        this.RobberA.Delete();
      if (this.Bank != (Blip) null)
        this.Bank.Remove();
      if ((Entity) this.PatrolCar1 != (Entity) null)
        this.PatrolCar1.Delete();
      if ((Entity) this.PatrolCar2 != (Entity) null)
        this.PatrolCar2.Delete();
      if ((Entity) this.PatrolCar != (Entity) null)
        this.PatrolCar.Delete();
    }

    public class VariableTimer
    {
      private int TimerMax;
      private Decimal TimerCounter;
      private bool IsRunning;
      public bool AutoReset;

      public event TheDiamondHeist.VariableTimer.TimerExpired OnTimerExpired;

      public VariableTimer(int interval)
      {
        this.TimerCounter = (Decimal) interval;
        this.TimerMax = interval;
      }

      public void AddTime(Decimal amount) => this.TimerCounter += amount;

      public void RemoveTime(Decimal amount)
      {
        this.TimerCounter -= amount;
        if (!(this.TimerCounter < 0M))
          return;
        this.TimerCounter = 0M;
      }

      public void Update(float timescale)
      {
        if (!this.IsRunning)
          return;
        this.TimerCounter -= (Decimal) (Game.LastFrameTime * 1000f * timescale);
        if (!(this.TimerCounter <= 0M))
          return;
        TheDiamondHeist.VariableTimer.TimerExpired onTimerExpired = this.OnTimerExpired;
        if (onTimerExpired != null)
          onTimerExpired((object) this);
        if (this.AutoReset)
          this.TimerCounter += (Decimal) this.TimerMax;
        else
          this.Stop();
      }

      public void Stop() => this.IsRunning = false;

      public void Start() => this.IsRunning = true;

      public void Reset() => this.TimerCounter = (Decimal) this.TimerMax;

      public int Counter => (int) this.TimerCounter;

      public delegate void TimerExpired(object sender);
    }
  }
}
