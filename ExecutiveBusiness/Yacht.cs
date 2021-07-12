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

namespace ExecutiveBusiness
{
  public class Yacht : Script
  {
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    private Vector3 PlayerYachtPos1 = new Vector3(-3551.974f, 1477.896f, 12.77976f);
    private Vector3 PlayerYachtPos2 = new Vector3(-3148.379f, 2807.555f, 5.42997f);
    private Vector3 PlayerYachtPos3 = new Vector3(-3280.501f, 2140.507f, 5.42997f);
    private Vector3 PlayerYachtPos4 = new Vector3(-2814.49f, 4072.74f, 5.42997f);
    private Vector3 PlayerYachtPos5 = new Vector3(-3254.552f, 3685.677f, 5.42997f);
    private Vector3 PlayerYachtPos6 = new Vector3(-2368.441f, 4697.874f, 5.42997f);
    private Vector3 PlayerYachtPos7 = new Vector3(-3205.344f, -219.0104f, 5.42997f);
    private Vector3 PlayerYachtPos8 = new Vector3(-3448.254f, 311.5018f, 5.42997f);
    private Vector3 PlayerYachtPos9 = new Vector3(-2697.862f, -540.6123f, 5.42997f);
    private Vector3 PlayerYachtPos10 = new Vector3(-1995.725f, -1523.694f, 5.429955f);
    private Vector3 PlayerYachtPos11 = new Vector3(-2117.581f, -2543.346f, 5.42997f);
    private Vector3 PlayerYachtPos12 = new Vector3(-1605.074f, -1872.468f, 5.42997f);
    private Vector3 PlayerYachtPos13 = new Vector3(-753.0817f, -3919.068f, 5.42997f);
    private Vector3 PlayerYachtPos14 = new Vector3(-351.0608f, -3553.323f, 5.42997f);
    private Vector3 PlayerYachtPos15 = new Vector3(-1460.536f, -3761.467f, 5.42997f);
    private Vector3 PlayerYachtPos16 = new Vector3(1546.892f, -3045.627f, 5.42997f);
    private Vector3 PlayerYachtPos17 = new Vector3(2490.885f, -2428.848f, 5.42997f);
    private Vector3 PlayerYachtPos18 = new Vector3(2049.79f, -2821.624f, 5.42997f);
    private Vector3 PlayerYachtPos19 = new Vector3(3029.018f, -1495.702f, 5.42997f);
    private Vector3 PlayerYachtPos20 = new Vector3(3021.254f, -723.3903f, 5.42997f);
    private Vector3 PlayerYachtPos21 = new Vector3(2976.622f, -1994.76f, 5.42997f);
    private Vector3 PlayerYachtPos22 = new Vector3(3404.51f, 1977.044f, 5.42997f);
    private Vector3 PlayerYachtPos23 = new Vector3(3411.1f, 1193.445f, 5.42997f);
    private Vector3 PlayerYachtPos24 = new Vector3(3784.802f, 2548.541f, 5.42997f);
    private Vector3 PlayerYachtPos25 = new Vector3(4225.028f, 3988.002f, 5.42997f);
    private Vector3 PlayerYachtPos26 = new Vector3(4250.581f, 4576.565f, 5.42997f);
    private Vector3 PlayerYachtPos27 = new Vector3(4204.355f, 3373.7f, 5.42997f);
    private Vector3 PlayerYachtPos28 = new Vector3(3751.681f, 5753.501f, 5.42997f);
    private Vector3 PlayerYachtPos29 = new Vector3(3490.105f, 6305.785f, 5.42997f);
    private Vector3 PlayerYachtPos30 = new Vector3(3684.853f, 5212.238f, 5.42997f);
    private Vector3 PlayerYachtPos31 = new Vector3(581.5955f, 7124.558f, 5.42997f);
    private Vector3 PlayerYachtPos32 = new Vector3(2004.462f, 6907.157f, 5.429955f);
    private Vector3 PlayerYachtPos33 = new Vector3(1396.638f, 6860.203f, 5.42997f);
    private Vector3 PlayerYachtPos34 = new Vector3(-1170.69f, 5980.682f, 5.42997f);
    private Vector3 PlayerYachtPos35 = new Vector3(-777.4865f, 6566.907f, 5.42997f);
    private Vector3 PlayerYachtPos36 = new Vector3(-381.7739f, 6946.96f, 5.42997f);
    public List<Vector3> YachtPos = new List<Vector3>();
    public List<string> YachtHashs = new List<string>();
    public List<string> YachtHashs2 = new List<string>();
    public List<Blip> Blips = new List<Blip>();
    public List<string> YachtLocSring = new List<string>();
    public List<Prop> Props = new List<Prop>();
    private string Rail = "apa_MP_Apa_Yacht_O3_Rail_B";
    private string YachtTop = "apa_mp_apa_yacht_option3";
    private string YachtLauncher = "apa_mp_apa_yacht_launcher_01a";
    private ScriptSettings Config;
    public Vector3 MenuMarker;
    public Vector3 SleepPos1;
    public Vector3 SleepPos2;
    public Vector3 HeliPosA;
    public Vector3 HeliPosB;
    public Vehicle HeliA;
    public Vehicle HeliB;
    public Vector3 Jacuzzi;
    public Vector3 BarEnter;
    public Vector3 BarExit;
    public Vector3 CaptinsQuartersEnter;
    public Vector3 CaptinsQuartersExit;
    public Vector3 BackEntranceOffset = new Vector3(-37.78258f, -1.999345f, -0.5f);
    public Vector3 BackIntOffset = new Vector3(-12.50842f, -1.944044f, -0.5f);
    public Vector3 CaptEntranceOffset = new Vector3(-1.029798f, -1.807718f, 5.5f);
    public Vector3 CaptIntOffset = new Vector3(5.697177f, -1.996299f, 5.5f);
    public Vector3 CaptComputerOffset = new Vector3(13.66955f, -2.026101f, 6.5f);
    public Vector3 MenuOffset = new Vector3(13.66955f, -6.5f, -0.5f);
    public Vector3 HeliPadAOffset;
    public Vector3 HeliPadBOffset;
    public int MaxHelis;
    public bool GoldRails;
    public int ShipColor;
    public int RailsColor;
    public Vector3 ChangeLocMarker;
    public int Purchased;
    public int YachtType;
    public int Location;
    public int Lighting;
    public int LightingColor;
    public bool Created;
    public int DoorType;
    public Prop DoorA;
    public Prop DoorB;
    public Prop DoorC;
    public int H1;
    public int H2;
    public Vector3 jacuzziSeat1 = new Vector3(950.1906f, 8.564717f, 115f);
    public float J_rot1 = 40f;
    public Vector3 jacuzziSeat2 = new Vector3(950.6779f, 9.216393f, 115f);
    public float J_rot2 = 71f;
    public Vector3 jacuzziSeat3 = new Vector3(949.2539f, 8.049603f, 115f);
    public float J_rot3 = -5.3f;
    public Vector3 jacuzziSeat4 = new Vector3(947.048f, 10.22428f, 115f);
    public float J_rot4 = -117f;
    public Vector3 jacuzziSeat5 = new Vector3(947.7902f, 9.3316f, 115f);
    public float J_rot5 = -71f;
    public Vector3 jacuzziSeat6 = new Vector3(950.5591f, 10.92737f, 115f);
    public float J_rot6 = 103f;
    public bool IsinHottub;
    public List<Ped> Peds = new List<Ped>();
    private float Speed;
    private Vehicle Car;
    public int PedType = 1;
    private MenuPool ChangePosPool;
    private UIMenu ChangePosMainMenu;
    private UIMenu ChangePosMenu;
    public WeaponTint Liv;
    public int ID_O;
    public string ID_C;
    public int Comp;
    public Vector3 Bed1;
    public Vector3 Bed2;
    public Vector3 Bed3;
    public Vector3 BarPos;
    public Vector3 BarDrinkPos;
    public Ped Bargirl;
    public List<string> FlagList = new List<string>();
    public int CurrentFlag = 2;
    public Prop FlagA;
    public Prop FlagB;
    public Prop FlagC;
    public Vector3 FlagPosA;
    public Vector3 FlagPosB;
    public Vector3 FlagPosC;
    public Vector3 ShowerAPos;
    public Vector3 ShowerAPosEnter;
    public Vector3 ShowerBPos;
    public Vector3 ShowerBPosEnter;
    public Vector3 ShowerCPos;
    public Vector3 ShowerCPosEnter;
    public bool InShower;
    public int AmountOfSeaSharks;
    public Vector3 SeaSharkPosA;
    public Vector3 SeaSharkPosB;
    public Vector3 SeaSharkPosC;
    public Vector3 SeaSharkPosD;
    public Vehicle SeaSharkA;
    public Vehicle SeaSharkB;
    public Vehicle SeaSharkC;
    public Vehicle SeaSharkD;
    public Vector3 BoatAPos;
    public Vector3 BoatBPos;
    public Vehicle BoatA;
    public Vehicle BoatB;
    public int BoatAType;
    public int BoatBType;
    public bool ShowTestBlips;
    public bool WaitForCreated;
    public Vector3 WoredrobeAPos;
    public Vector3 WoredrobeBPos;
    public Vector3 WoredrobeCPos;
    public MenuPool Woredrobepool;
    public UIMenu WoredrobeMainMenu;
    public UIMenu WoredrobeMenu;
    public int CompMax;
    public int DrawableMax;
    public MenuPool DrinksPool;
    public UIMenu DrinksMenu;
    public UIMenu DrinksMainMenu;
    public Prop Champaine;
    public bool IsDrinking;
    public int DrinkTimer;
    public List<Prop> Champ = new List<Prop>();
    public int Effect;
    public Model OldCharacter;
    public bool isDrinking;
    public Prop Base;
    private string YachtHash;
    public int SpawnDist;
    public bool ShowDistWhenClose;
    public bool RadioOn;
    public int Station;
    public List<Vector3> RadioPos = new List<Vector3>();
    public Vector3 CurrentRadio;
    public int CurrentInt;
    public float Z_min;
    public float Z_max;
    public Vector3 MarkerEnter;
    public Vector3 MarkerExit;
    public Vector3 RoofEnterMarker;
    public Vector3 RoofExitMarker;
    public Vector3 HeliSpawn;
    public Vector3 GarageMarker;
    public Vector3 CarSpawn;
    public Vector3 WherehouseMarker;
    public Vector3 WherehouseEnter;
    private Keys Key1;
    public Vector3 BuyMarker;
    public Vector3 BuyMarker2;
    public int num;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private UIMenu methgarage;
    private UIMenu ProductStock;
    public bool bought;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public int stockstimer;
    public int waittime = 3200;
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
    public System.Random VehicleLoc;
    public System.Random VehicleRan;
    public Vehicle VehicleMissioncar;
    public Vector3 VehicleLocation;
    public int Missionnum;
    public Blip DestoryVehicle;
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
    public Vehicle Vehicle1;
    public Vehicle Vehicle2;
    public Vehicle Vehicle3;
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
    public string Design;
    public Vector3 SleepPos;
    public Vector3 MBTOfficeSitRespawnPos;
    public Vector3 MBTOfficeSitPos;
    public bool sitting;
    public UIMenu Sourcingmenu2;
    public string SourcedVehicle;
    public bool NewVehicleSourcing;
    public float increaseGain;
    public AllStocks Allstocks;
    public bool ShowMarker;
    public bool InModGarage;
    public UIMenu SpecialMissions;
    public List<Ped> Guards = new List<Ped>();
    public List<Ped> Driver = new List<Ped>();
    public Vehicle VtoGet;
    public Blip VtoGetBlip;
    public bool GotCar;
    public Vehicle VtoGet1;
    public Vehicle VtoGet2;
    public Vehicle VtoGet3;
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
    public bool IsScriptEnabled;
    public Vector3 ChairPos = new Vector3(-1555.582f, -575.1f, 107.1f);
    public float P_Rotation = 124f;
    public bool IsSittinginCeoSeat;
    public string WarehousePos;
    public Camera WarehouseCam;
    public bool WCamOn;
    public bool MenuOn;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public bool Firsttime;
    public bool Foundyacht;
    public bool DeletedYacht;
    public Prop PropYachtBase;
    public int Scene1;
    public string AnimDict;
    public int animtype;
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

    public Model RequestModel(int Name)
    {
      Model model = new Model(Name);
      model.Request(10000);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(100);
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
      this.CheckHostName("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
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

    public void Drinks()
    {
      UIMenu uiMenu = this.DrinksPool.AddSubMenu(this.DrinksMenu, nameof (Drinks));
      this.GUIMenus.Add(uiMenu);
      UIMenuItem DrinkA = new UIMenuItem("Pisswasser                                               $25");
      uiMenu.AddItem(DrinkA);
      UIMenuItem DrinkB = new UIMenuItem("Vodka Shot                                              $75");
      uiMenu.AddItem(DrinkB);
      UIMenuItem DrinkC = new UIMenuItem("The Mount Whiskey Shot                       $250");
      uiMenu.AddItem(DrinkC);
      UIMenuItem DrinkD = new UIMenuItem("Richard's Whiskey Shot                       $1,000");
      uiMenu.AddItem(DrinkD);
      UIMenuItem DrinkE = new UIMenuItem("Macbeth Whiskey Shot                       $5,000");
      uiMenu.AddItem(DrinkE);
      UIMenuItem DrinkF = new UIMenuItem("Bleuter'd Champaine Slver                $30,000");
      uiMenu.AddItem(DrinkF);
      UIMenuItem DrinkG = new UIMenuItem("Bleuter'd Champaine Gold                $50,000");
      uiMenu.AddItem(DrinkG);
      UIMenuItem DrinkH = new UIMenuItem("Bleuter'd Champaine Diamond        $150,000");
      uiMenu.AddItem(DrinkH);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == DrinkH)
        {
          if (Game.Player.Money >= 150000)
          {
            Game.Player.Money -= 150000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("ba_prop_battle_champ_closed_03"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 4500, false, 0.0f);
            this.Effect = 6;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.Weapons.Select(WeaponHash.BZGas);
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.IsDrinking = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkG)
        {
          if (Game.Player.Money >= 50000)
          {
            Game.Player.Money -= 50000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("ba_prop_battle_champ_closed_02"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 4500, false, 0.0f);
            this.Effect = 6;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.Weapons.Select(WeaponHash.BZGas);
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.IsDrinking = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkF)
        {
          if (Game.Player.Money >= 30000)
          {
            Game.Player.Money -= 30000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("ba_prop_battle_champ_closed"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 4500, false, 0.0f);
            this.Effect = 6;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.Weapons.Select(WeaponHash.BZGas);
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.IsDrinking = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkE)
        {
          if (Game.Player.Money >= 5000)
          {
            Game.Player.Money -= 5000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 4500, false, 0.0f);
            this.Effect = 3;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.IsDrinking = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
          }
          else
            UI.Notify(" You do not have enough money for this Drink!");
        }
        if (item == DrinkD)
        {
          if (Game.Player.Money >= 1000)
          {
            Game.Player.Money -= 1000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 4500, false, 0.0f);
            this.Effect = 2;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.IsDrinking = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkC)
        {
          if (Game.Player.Money >= 250)
          {
            Game.Player.Money -= 250;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 4500, false, 0.0f);
            this.Effect = 1;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.IsDrinking = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkB)
        {
          if (Game.Player.Money >= 75)
          {
            Game.Player.Money -= 75;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_sh_beer_pissh_01"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 4500, false, 0.0f);
            this.Effect = 0;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.modMenuPool.CloseAllMenus();
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.IsDrinking = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item != DrinkA)
          return;
        if (Game.Player.Money >= 25)
        {
          Game.Player.Money -= 25;
          Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
          Prop prop = World.CreateProp(this.RequestModel("prop_sh_beer_pissh_01"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
          prop.FreezePosition = true;
          prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
          this.Champaine = prop;
          this.Champ.Add(prop);
          this.IsDrinking = true;
          Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 4500, false, 0.0f);
          this.Effect = -1;
          Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
          this.modMenuPool.CloseAllMenus();
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
          Script.Wait(5000);
          Game.Player.Character.HasGravity = true;
          Game.Player.Character.FreezePosition = false;
          this.Champaine.FreezePosition = false;
          this.IsDrinking = false;
          this.Champaine.HasCollision = true;
          this.DrinkTimer = 0;
          Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
          Game.Player.Character.Task.ClearAll();
          Game.Player.Character.Task.ClearAllImmediately();
          this.Champaine.Detach();
        }
        else
          UI.Notify("You do not have enough money for this Drink!");
      });
    }

    public int CheckClothes(int T, int RComp, int RDraw)
    {
      int num = 0;
      if (T == 1)
      {
        if (Function.Call<bool>(Hash._0xE825F6B6CEA7671D, (InputArgument) Game.Player.Character, (InputArgument) RComp, (InputArgument) RDraw))
          num = Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Game.Player.Character, (InputArgument) RComp);
      }
      if (T == 2)
      {
        if (Function.Call<bool>(Hash._0xE825F6B6CEA7671D, (InputArgument) Game.Player.Character, (InputArgument) RComp, (InputArgument) RDraw))
          num = Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Game.Player.Character, (InputArgument) RComp, (InputArgument) RDraw);
      }
      return num;
    }

    public void Setoutfit(int i)
    {
      Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
      if (Game.Player.Character.Model != (Model) PedHash.FreemodeMale01)
        this.OldCharacter = Game.Player.Character.Model;
      Function.Call(Hash._0xAA74EC0CB0AAEA2C, (InputArgument) Game.Player.Character, (InputArgument) 1.0);
      Function.Call(Hash._0x20510814175EA477, (InputArgument) Game.Player.Character);
      Model model = new Model(PedHash.FreemodeMale01);
      model.Request(500);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(100);
        Function.Call(Hash._0x00A1CADD00108836, (InputArgument) Game.Player, (InputArgument) model.Hash);
      }
      model.MarkAsNoLongerNeeded();
      Ped character = Game.Player.Character;
      Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) -1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 17);
      bool flag = false;
      string idC = this.ID_C;
      if (i == 0)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 1)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 89, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 55, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 54, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 89, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 55, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 54, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 2 && idC.Equals("Outfit Default"))
      {
        if (!flag && !idC.Equals("Outfit Default"))
          UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num = new System.Random().Next(1, 100);
        if (num <= 25)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 38, (InputArgument) 0, (InputArgument) 1);
        if (num > 25 && num <= 50)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 112, (InputArgument) 0, (InputArgument) 1);
        if (num > 50 && num <= 75)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
        if (num > 75)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 104, (InputArgument) 25, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 68, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (i == 3)
      {
        if (idC.Equals("Blue"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Black") || idC.Equals("Outfit Default"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 4)
      {
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 12, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 13, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 15, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 5)
      {
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 12, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 13, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 15, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 6)
      {
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 134, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 147, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 167, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 113, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 90, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 286, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 135, (InputArgument) 0);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 134, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 147, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 167, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 113, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 90, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 286, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 135, (InputArgument) 0);
        }
      }
      if (i == 7)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 4, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 6, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 7, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 5, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 8)
      {
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 8, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 10, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 11, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 9, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i != 9)
        return;
      if (idC.Equals("Outfit Default"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 0, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (idC.Equals("Green"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 1, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 1, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (idC.Equals("White"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 9, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 7, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 7, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 7, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (idC.Equals("Blue"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 3, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 3, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (idC.Equals("Black"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 10, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 10, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 10, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 10, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (flag)
        return;
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 0, (InputArgument) 17);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 0, (InputArgument) 0);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 0, (InputArgument) 1);
      Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
    }

    public void WareDrobe()
    {
      List<object> items1 = new List<object>();
      items1.Add((object) "Save");
      items1.Add((object) "Load");
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1.ini");
      Slots.Add((object) "Slot2.ini");
      Slots.Add((object) "Slot3.ini");
      Slots.Add((object) "Slot4.ini");
      Slots.Add((object) "Slot5.ini");
      Slots.Add((object) "Slot6.ini");
      Slots.Add((object) "Slot7.ini");
      Slots.Add((object) "Slot8.ini");
      Slots.Add((object) "Slot9.ini");
      Slots.Add((object) "Slot10.ini");
      List<object> objectList = new List<object>()
      {
        (object) WeaponHash.Unarmed,
        (object) WeaponHash.Knife,
        (object) WeaponHash.Nightstick,
        (object) WeaponHash.Hammer,
        (object) WeaponHash.Hatchet,
        (object) WeaponHash.KnuckleDuster,
        (object) WeaponHash.Machete,
        (object) WeaponHash.PoolCue,
        (object) WeaponHash.Wrench,
        (object) WeaponHash.SwitchBlade,
        (object) WeaponHash.GolfClub,
        (object) WeaponHash.Flashlight
      };
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
      List<object> Outfits = new List<object>();
      Outfits.Add((object) "Soldier");
      Outfits.Add((object) "Cloaker");
      Outfits.Add((object) "Hacker");
      Outfits.Add((object) "Juggernaut");
      Outfits.Add((object) "Arena War A");
      Outfits.Add((object) "Arena War B");
      Outfits.Add((object) "Space Marine");
      Outfits.Add((object) "Commando");
      Outfits.Add((object) "Space Suit");
      Outfits.Add((object) "Tron");
      List<object> Draw = new List<object>();
      List<object> Tex = new List<object>();
      Draw.Add((object) 0);
      Draw.Add((object) 1);
      Tex.Add((object) 0);
      List<object> items2 = new List<object>();
      items2.Add((object) " 0 FACE");
      items2.Add((object) "1 BEARD");
      items2.Add((object) "2 HAIRCUT");
      items2.Add((object) "3 SHIRT");
      items2.Add((object) "4 PANTS");
      items2.Add((object) "5 Hands / Gloves");
      items2.Add((object) "6 SHOES");
      items2.Add((object) "7 Eyes");
      items2.Add((object) "8 Accessories");
      items2.Add((object) "9 Mission Items/ Tasks");
      items2.Add((object) "10 Decals");
      items2.Add((object) "11 Collars and Inner Shirts");
      UIMenu uiMenu1 = this.Woredrobepool.AddSubMenu(this.WoredrobeMenu, "Change Outfit");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem O = new UIMenuListItem("", Outfits, 0);
      uiMenu1.AddItem((UIMenuItem) O);
      O.Description = "While Using this outfit you will not be able to purchase anything due to being the MP male";
      UIMenuListItem C = new UIMenuListItem("Color : ", Colours, 0);
      uiMenu1.AddItem((UIMenuItem) C);
      C.Description = "Use this Colour Whenever possible or use Default";
      UIMenuItem Set = new UIMenuItem("Wear Outfit ");
      uiMenu1.AddItem(Set);
      Set.Description = "~y~ Warning ~w~ Lag is normal while applying outfits, simple alt tab out to avoid crash";
      UIMenuItem Remove = new UIMenuItem("Remove Outift ");
      uiMenu1.AddItem(Remove);
      UIMenu uiMenu2 = this.Woredrobepool.AddSubMenu(this.WoredrobeMenu, "Change Clothes");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.Woredrobepool.AddSubMenu(this.WoredrobeMenu, "Save/Load Outfit");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem SVL = new UIMenuListItem("Function ", items1, 0);
      uiMenu3.AddItem((UIMenuItem) SVL);
      UIMenuListItem Sl = new UIMenuListItem("Slot ", Slots, 0);
      uiMenu3.AddItem((UIMenuItem) Sl);
      UIMenuItem Get = new UIMenuItem("Save");
      uiMenu3.AddItem(Get);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Get)
          return;
        string str = "";
        if (Game.Player.Character.Model == (Model) PedHash.Franklin)
          str = "scripts//HKH191sBusinessMods//ExecutiveBusiness//YachtWaredrobe//Waredrobe//Franklin//";
        if (Game.Player.Character.Model == (Model) PedHash.Michael)
          str = "scripts//HKH191sBusinessMods//ExecutiveBusiness//YachtWaredrobe//Waredrobe//Michael//";
        if (Game.Player.Character.Model == (Model) PedHash.Trevor)
          str = "scripts//HKH191sBusinessMods//ExecutiveBusiness//YachtWaredrobe//Waredrobe//Trevor//";
        if (Game.Player.Character.Model == (Model) PedHash.FreemodeFemale01 || Game.Player.Character.Model == (Model) PedHash.FreemodeMale01)
          str = "scripts//HKH191sBusinessMods//ExecutiveBusiness//YachtWaredrobe//Waredrobe//Mp//";
        if (SVL.Index == 0)
        {
          Ped character = Game.Player.Character;
          Get.Text = "Save";
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__174.\u003C\u003Ep__1 = CallSite<Action<CallSite, Yacht, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Action<CallSite, Yacht, object> target = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Action<CallSite, Yacht, object>> p1 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__174.\u003C\u003Ep__0 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__0.Target((CallSite) Yacht.\u003C\u003Eo__174.\u003C\u003Ep__0, str, Slots[Sl.Index]);
          target((CallSite) p1, this, obj);
          int num1 = Function.Call<int>(Hash._0x898CC20EA75BACD8, (InputArgument) character, (InputArgument) 0);
          int num2 = Function.Call<int>(Hash._0xE131A28626F81AB2, (InputArgument) character, (InputArgument) 0);
          int num3 = Function.Call<int>(Hash._0xE3DD5F2A84B42281, (InputArgument) character, (InputArgument) 0);
          this.Config.SetValue<int>("-1 HAT", "Hat_Drawable", num1);
          this.Config.SetValue<int>("-1 Hat", "Hat_Tex", num2);
          this.Config.SetValue<int>("-1 Hat", "Hat_Palette", num3);
          int num4 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 0);
          int num5 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 0);
          this.Config.SetValue<int>("0 FACE", "Head_Drawable", num4);
          this.Config.SetValue<int>("0 FACE", "Head_Palette", num5);
          int num6 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 1);
          int num7 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 1);
          this.Config.SetValue<int>("1 BEARD", "BEARD_Drawable", num6);
          this.Config.SetValue<int>("1 BEARD", "BEARD_Palette", num7);
          int num8 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 2);
          int num9 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 2);
          this.Config.SetValue<int>("2 HAIRCUT", "HAIRCUT_Drawable", num8);
          this.Config.SetValue<int>("2 HAIRCUT", "HAIRCUT_Palette", num9);
          int num10 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 3);
          int num11 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 3);
          this.Config.SetValue<int>("3 SHIRT", "SHIRT_Drawable", num10);
          this.Config.SetValue<int>("3 SHIRT", "SHIRT_Palette", num11);
          int num12 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 4);
          int num13 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 4);
          this.Config.SetValue<int>("4 PANTS", "PANTS_Drawable", num12);
          this.Config.SetValue<int>("4 PANTS", "PANTS_Palette", num13);
          int num14 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 5);
          int num15 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 5);
          this.Config.SetValue<int>("5 Hands / Gloves", "Gloves_Drawable", num14);
          this.Config.SetValue<int>("5 Hands / Gloves", "Gloves_Palette", num15);
          int num16 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 6);
          int num17 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 6);
          this.Config.SetValue<int>("6 SHOES", "SHOES_Drawable", num16);
          this.Config.SetValue<int>("6 SHOES", "SHOES_Palette", num17);
          int num18 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 7);
          int num19 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 7);
          this.Config.SetValue<int>("7 Eyes", "Eyes_Drawable", num18);
          this.Config.SetValue<int>("7 Eyes", "Eyes_Palette", num19);
          int num20 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 8);
          int num21 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 8);
          this.Config.SetValue<int>("8 Accessories", "Accessories_Drawable", num20);
          this.Config.SetValue<int>("8 Accessories", "Accessories_Palette", num21);
          int num22 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 9);
          int num23 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 9);
          this.Config.SetValue<int>("9 Mission Items/ Tasks", "Mission_Drawable", num22);
          this.Config.SetValue<int>("9 Mission Items/ Tasks", "Mission_Palette", num23);
          int num24 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 10);
          int num25 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 10);
          this.Config.SetValue<int>("10 Decals", "Decals_Drawable", num24);
          this.Config.SetValue<int>("10 Decals", "Decals_Palette", num25);
          int num26 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 11);
          int num27 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 11);
          this.Config.SetValue<int>("11 Collars and Inner Shirts", "InnerShirts_Drawable", num26);
          this.Config.SetValue<int>("11 Collars and Inner Shirts", "InnerShirts_Palette", num27);
          this.Config.Save();
          UI.Notify("Outfit saved!");
        }
        if (SVL.Index != 1)
          return;
        Get.Text = "Load";
        Ped character1 = Game.Player.Character;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__174.\u003C\u003Ep__3 = CallSite<Action<CallSite, Yacht, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, Yacht, object> target1 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, Yacht, object>> p3 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__174.\u003C\u003Ep__2 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__2.Target((CallSite) Yacht.\u003C\u003Eo__174.\u003C\u003Ep__2, str, Slots[Sl.Index]);
        target1((CallSite) p3, this, obj1);
        int num28 = this.Config.GetValue<int>("0 FACE", "Head_Drawable", 0);
        int num29 = this.Config.GetValue<int>("0 FACE", "Head_Palette", 0);
        int num30 = this.Config.GetValue<int>("1 BEARD", "BEARD_Drawable", 0);
        int num31 = this.Config.GetValue<int>("1 BEARD", "BEARD_Palette", 0);
        int num32 = this.Config.GetValue<int>("2 HAIRCUT", "HAIRCUT_Drawable", 0);
        int num33 = this.Config.GetValue<int>("2 HAIRCUT", "HAIRCUT_Palette", 0);
        int num34 = this.Config.GetValue<int>("3 SHIRT", "SHIRT_Drawable", 0);
        int num35 = this.Config.GetValue<int>("3 SHIRT", "SHIRT_Palette", 0);
        int num36 = this.Config.GetValue<int>("4 PANTS", "PANTS_Drawable", 0);
        int num37 = this.Config.GetValue<int>("4 PANTS", "PANTS_Palette", 0);
        int num38 = this.Config.GetValue<int>("5 Hands / Gloves", "Gloves_Drawable", 0);
        int num39 = this.Config.GetValue<int>("5 Hands / Gloves", "Gloves_Palette", 0);
        int num40 = this.Config.GetValue<int>("6 SHOES", "SHOES_Drawable", 0);
        int num41 = this.Config.GetValue<int>("6 SHOES", "SHOES_Palette", 0);
        int num42 = this.Config.GetValue<int>("7 Eyes", "Eyes_Drawable", 0);
        int num43 = this.Config.GetValue<int>("7 Eyes", "Eyes_Palette", 0);
        int num44 = this.Config.GetValue<int>("8 Accessories", "Accessories_Drawable", 0);
        int num45 = this.Config.GetValue<int>("8 Accessories", "Accessories_Palette", 0);
        int num46 = this.Config.GetValue<int>("9 Mission Items/ Tasks", "Mission_Drawable", 0);
        int num47 = this.Config.GetValue<int>("9 Mission Items/ Tasks", "Mission_Palette", 0);
        int num48 = this.Config.GetValue<int>("10 Decals", "Decals_Drawable", 0);
        int num49 = this.Config.GetValue<int>("10 Decals", "Decals_Palette", 0);
        int num50 = this.Config.GetValue<int>("11 Collars and Inner Shirts", "InnerShirts_Drawable", 0);
        int num51 = this.Config.GetValue<int>("11 Collars and Inner Shirts", "InnerShirts_Palette", 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 0, (InputArgument) num28, (InputArgument) num29, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 1, (InputArgument) num30, (InputArgument) num31, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 2, (InputArgument) num32, (InputArgument) num33, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 3, (InputArgument) num34, (InputArgument) num35, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 4, (InputArgument) num36, (InputArgument) num37, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 5, (InputArgument) num38, (InputArgument) num39, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 6, (InputArgument) num40, (InputArgument) num41, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 7, (InputArgument) num42, (InputArgument) num43, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 8, (InputArgument) num44, (InputArgument) num45, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 9, (InputArgument) num46, (InputArgument) num47, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 10, (InputArgument) num48, (InputArgument) num49, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character1, (InputArgument) 11, (InputArgument) num50, (InputArgument) num51, (InputArgument) 1);
        int num52 = this.Config.GetValue<int>("-1 HAT", "Hat_Drawable", 0);
        int num53 = this.Config.GetValue<int>("-1 Hat", "Hat_Tex", 0);
        int num54 = this.Config.GetValue<int>("-1 Hat", "Hat_Palette", 0);
        if (num52 >= 1)
        {
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character1, (InputArgument) 0, (InputArgument) num52, (InputArgument) num53, (InputArgument) num54);
        }
        else
        {
          if (num52 >= 1)
            return;
          Function.Call(Hash._0xCD8A7537A9B52F06, (InputArgument) Game.Player.Character);
        }
      });
      uiMenu3.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (SVL.Index == 0)
          Get.Text = "Save";
        if (SVL.Index != 1)
          return;
        Get.Text = "Load";
      });
      UIMenuListItem Comp1 = new UIMenuListItem("", items2, 0);
      uiMenu2.AddItem((UIMenuItem) Comp1);
      UIMenuListItem Drawable = new UIMenuListItem("Item : ", Draw, 0);
      uiMenu2.AddItem((UIMenuItem) Drawable);
      UIMenuListItem Texture = new UIMenuListItem("Texture : ", Tex, 0);
      uiMenu2.AddItem((UIMenuItem) Texture);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Set)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//YachtWaredrobe//Wardrobe//Weapons.ini");
          foreach (WeaponHash weaponHash in (WeaponHash[]) Enum.GetValues(typeof (WeaponHash)))
          {
            if (Game.Player.Character.Weapons.HasWeapon(weaponHash))
            {
              Game.Player.Character.Weapons.Select(weaponHash, false);
              this.Config.SetValue<WeaponHash>(weaponHash.ToString(), "WeaponName", weaponHash);
              int hash = (int) Game.Player.Character.Weapons.Current.Hash;
              this.Liv = Game.Player.Character.Weapons.Current.Tint;
              int num = 0;
              foreach (WeaponComponent component in (WeaponComponent[]) Enum.GetValues(typeof (WeaponComponent)))
              {
                try
                {
                  if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) weaponHash.GetHashCode(), (InputArgument) component.GetHashCode()))
                  {
                    if (Game.Player.Character.Weapons.Current.IsComponentActive(component))
                    {
                      this.Config.SetValue<bool>(weaponHash.ToString(), "HasComponent" + num.ToString(), true);
                      this.Config.SetValue<WeaponComponent>(weaponHash.ToString(), "Component" + num.ToString(), component);
                      ++num;
                      this.Config.Save();
                    }
                    if (!Game.Player.Character.Weapons.Current.IsComponentActive(component))
                    {
                      this.Config.SetValue<bool>(weaponHash.ToString(), "HasComponent" + num.ToString(), false);
                      this.Config.SetValue<WeaponComponent>(weaponHash.ToString(), "Component" + num.ToString(), component);
                      ++num;
                      this.Config.Save();
                    }
                  }
                }
                catch
                {
                  ++num;
                  UI.Notify("~y~ Warning ~w~: Weapon : " + weaponHash.ToString() + " Failed to save");
                }
              }
              this.Config.SetValue<WeaponTint>(weaponHash.ToString(), "Tint", this.Liv);
              this.Config.Save();
            }
          }
          this.ID_O = O.Index;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__174.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Yacht)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.ID_C = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__4.Target((CallSite) Yacht.\u003C\u003Eo__174.\u003C\u003Ep__4, Colours[C.Index]);
          this.Setoutfit(O.Index);
          UI.Notify("~y~ Warning ~w~ Lag is normal while applying outfits");
          Script.Wait(2000);
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__9 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__174.\u003C\u003Ep__9 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Action<CallSite, System.Type, object> target1 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__9.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Action<CallSite, System.Type, object>> p9 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__9;
          System.Type type = typeof (UI);
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__174.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string, object> target2 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string, object>> p8 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__174.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object, object> target3 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__7.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object, object>> p7 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__7;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__6 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__174.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string, object> target4 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__6.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string, object>> p6 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__6;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__174.\u003C\u003Ep__5 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__5.Target((CallSite) Yacht.\u003C\u003Eo__174.\u003C\u003Ep__5, "Player is wearing outfit : ~y~", Outfits[O.Index]);
          object obj2 = target4((CallSite) p6, obj1, "~w~ with colour : ~y~");
          object obj3 = Colours[C.Index];
          object obj4 = target3((CallSite) p7, obj2, obj3);
          object obj5 = target2((CallSite) p8, obj4, "~y~");
          target1((CallSite) p9, type, obj5);
          this.LoadIniFile("scripts//HKH191sBusinessMods//YachtWaredrobe//Wardrobe//Weapons.ini");
          foreach (WeaponHash weaponHash1 in (WeaponHash[]) Enum.GetValues(typeof (WeaponHash)))
          {
            WeaponHash weaponHash2 = this.Config.GetValue<WeaponHash>(weaponHash1.ToString(), "WeaponName", weaponHash1);
            if (weaponHash1 == weaponHash2)
            {
              Game.Player.Character.Weapons.Give(weaponHash1, 9999, true, true);
              Game.Player.Character.Weapons.Select(weaponHash1, true);
              this.Liv = this.Config.GetValue<WeaponTint>(weaponHash1.ToString(), "Tint", this.Liv);
              int hash = (int) Game.Player.Character.Weapons.Current.Hash;
              Game.Player.Character.Weapons.Current.Tint = this.Liv;
              this.Comp = 0;
              foreach (WeaponComponent component in (WeaponComponent[]) Enum.GetValues(typeof (WeaponComponent)))
              {
                try
                {
                  if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) weaponHash1.GetHashCode(), (InputArgument) component.GetHashCode()))
                  {
                    if (this.Config.GetValue<bool>(weaponHash1.ToString(), "HasComponent" + this.Comp.ToString(), true))
                    {
                      Game.Player.Character.Weapons.Current.SetComponent(component, true);
                      ++this.Comp;
                    }
                    else if (!this.Config.GetValue<bool>(weaponHash1.ToString(), "HasComponent" + this.Comp.ToString(), true))
                      ++this.Comp;
                  }
                }
                catch
                {
                  ++this.Comp;
                }
              }
            }
          }
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 9999);
          Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 9999, true, true);
        }
        if (item != Remove || !(Game.Player.Character.Model == (Model) PedHash.FreemodeMale01))
          return;
        UI.Notify("taking off Outfit, this may take some time, lag spikes are normal");
        Model model = new Model(this.OldCharacter.Hash);
        model.Request(500);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(100);
          Function.Call(Hash._0x00A1CADD00108836, (InputArgument) Game.Player, (InputArgument) model.Hash);
        }
        model.MarkAsNoLongerNeeded();
        this.LoadIniFile("scripts//HKH191sBusinessMods//YachtWaredrobe//Waredrobe//Weapons.ini");
        foreach (WeaponHash weaponHash1 in (WeaponHash[]) Enum.GetValues(typeof (WeaponHash)))
        {
          WeaponHash weaponHash2 = this.Config.GetValue<WeaponHash>(weaponHash1.ToString(), "WeaponName", weaponHash1);
          if (weaponHash1 == weaponHash2)
          {
            Game.Player.Character.Weapons.Give(weaponHash1, 9999, true, true);
            Game.Player.Character.Weapons.Select(weaponHash1, true);
            this.Liv = this.Config.GetValue<WeaponTint>(weaponHash1.ToString(), "Tint", this.Liv);
            int hash = (int) Game.Player.Character.Weapons.Current.Hash;
            Game.Player.Character.Weapons.Current.Tint = this.Liv;
            this.Comp = 0;
            foreach (WeaponComponent component in (WeaponComponent[]) Enum.GetValues(typeof (WeaponComponent)))
            {
              try
              {
                if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) weaponHash1.GetHashCode(), (InputArgument) component.GetHashCode()))
                {
                  if (this.Config.GetValue<bool>(weaponHash1.ToString(), "HasComponent" + this.Comp.ToString(), true))
                  {
                    Game.Player.Character.Weapons.Current.SetComponent(component, true);
                    ++this.Comp;
                  }
                  else if (!this.Config.GetValue<bool>(weaponHash1.ToString(), "HasComponent" + this.Comp.ToString(), true))
                    ++this.Comp;
                }
              }
              catch
              {
                ++this.Comp;
              }
            }
          }
        }
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 9999);
        Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 9999, true, true);
        UI.Notify("Removed Outfit!");
      });
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == O)
          this.ID_O = O.Index;
        if (item != C || C != O)
          return;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__174.\u003C\u003Ep__10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__174.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.ID_C = Yacht.\u003C\u003Eo__174.\u003C\u003Ep__10.Target((CallSite) Yacht.\u003C\u003Eo__174.\u003C\u003Ep__10, Colours[C.Index]);
      });
      uiMenu2.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == Comp1)
        {
          Draw.Clear();
          Tex.Clear();
          int num1 = this.CheckClothes(1, Comp1.Index, 0);
          if (num1 > 0)
          {
            for (int index1 = 0; index1 < num1; ++index1)
              Draw.Add((object) index1);
          }
          int num2 = this.CheckClothes(2, Comp1.Index, 0);
          if (num2 > 0)
          {
            for (int index1 = 0; index1 < num2; ++index1)
              Tex.Add((object) index1);
          }
        }
        if (item == Drawable)
        {
          Tex.Clear();
          int num = this.CheckClothes(2, Comp1.Index, 0);
          if (num > 0)
          {
            for (int index1 = 0; index1 < num; ++index1)
              Tex.Add((object) index1);
          }
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) Comp1.Index, (InputArgument) Drawable.Index, (InputArgument) Texture.Index, (InputArgument) 1);
        }
        if (item != Texture)
          return;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) Comp1.Index, (InputArgument) Drawable.Index, (InputArgument) Texture.Index, (InputArgument) 1);
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
        this.BuzzardBought = this.Config.GetValue<int>("Setup", "BuzzardBought", this.BuzzardBought);
        this.FMJBought = this.Config.GetValue<int>("Setup", "FMJBought", this.FMJBought);
        this.A911Bought = this.Config.GetValue<int>("Setup", "911Bought", this.A911Bought);
        this.X80Bought = this.Config.GetValue<int>("Setup", "X80Bought", this.X80Bought);
        this.SEVEN70Bought = this.Config.GetValue<int>("Setup", "SEVEN70Bought", this.SEVEN70Bought);
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
        this.maxstocks = 10 * this.purchaselvl;
        float num = (float) (125000 * this.purchaselvl) / 0.75f;
        this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
        this.increaseGain = num;
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Yacht.ini Failed To Load.");
      }
    }

    private void LoadIniFile2(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.Purchased = this.Config.GetValue<int>(nameof (Yacht), "Purchased", this.Purchased);
        this.GoldRails = this.Config.GetValue<bool>(nameof (Yacht), "GoldRails", this.GoldRails);
        this.ShipColor = this.Config.GetValue<int>(nameof (Yacht), "ShipColor", this.ShipColor);
        this.RailsColor = this.Config.GetValue<int>(nameof (Yacht), "RailsColor", this.RailsColor);
        this.YachtType = this.Config.GetValue<int>(nameof (Yacht), "YachtType", this.YachtType);
        this.Location = this.Config.GetValue<int>(nameof (Yacht), "Location", this.Location);
        this.Lighting = this.Config.GetValue<int>(nameof (Yacht), "Lighting", this.Lighting);
        this.LightingColor = this.Config.GetValue<int>(nameof (Yacht), "LightingColor", this.LightingColor);
        this.H1 = this.Config.GetValue<int>(nameof (Yacht), "HeliA", this.H1);
        this.H2 = this.Config.GetValue<int>(nameof (Yacht), "HeliB", this.H2);
        this.PedType = this.Config.GetValue<int>(nameof (Yacht), "PedType", this.PedType);
        this.CurrentFlag = this.Config.GetValue<int>(nameof (Yacht), "CurrentFlag", this.CurrentFlag);
        this.ShowTestBlips = this.Config.GetValue<bool>(nameof (Yacht), "ShowTestBlips", this.ShowTestBlips);
        this.AmountOfSeaSharks = this.Config.GetValue<int>(nameof (Yacht), "AmountOfSeaSharks", this.AmountOfSeaSharks);
        this.BoatAType = this.Config.GetValue<int>(nameof (Yacht), "BoatAType", this.BoatAType);
        this.BoatBType = this.Config.GetValue<int>(nameof (Yacht), "BoatBType", this.BoatBType);
        this.SpawnDist = this.Config.GetValue<int>(nameof (Yacht), "SpawnDist", this.SpawnDist);
        this.ShowDistWhenClose = this.Config.GetValue<bool>(nameof (Yacht), "ShowDistWhenClose", this.ShowDistWhenClose);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Yacht.ini Failed To Load.");
      }
    }

    public void Reset()
    {
      this.Delete();
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
      this.Created = false;
      Blip blip = World.CreateBlip(new Vector3(this.YachtPos[this.Location].X, this.YachtPos[this.Location].Y, this.YachtPos[this.Location].Z));
      blip.Sprite = BlipSprite.Yacht;
      blip.Name = "Yacht : " + this.Location.ToString() + ", " + this.YachtLocSring[this.Location];
      blip.Color = BlipColor.Blue;
      this.Blips.Add(blip);
    }

    public void SpawnProp(string Prop, Vector3 Pos, Vector3 Rot, int i)
    {
      try
      {
        Model model = new Model(Prop);
        model.Request(250);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(50);
          World.GetNearbyProps(Pos, 100f, model);
          World.CreateProp(model, Pos, true, false);
          Prop[] propArray = i == 4 || i == 5 || i == 6 ? World.GetNearbyProps(Pos, 2f, model) : World.GetNearbyProps(Pos, 100f, model);
          if (i != 4 && i != 5)
          {
            foreach (Prop prop in propArray)
            {
              if ((Entity) this.Base != (Entity) null)
              {
                if (i == 1)
                {
                  prop.AttachTo((Entity) this.Base, 0, new Vector3(0.0f, 0.0f, 14.5f), new Vector3(0.0f, 0.0f, this.GetRoationalAxis()));
                  prop.HasCollision = true;
                  this.Props.Add(prop);
                  Function.Call(Hash._0x971DA0055324D033, (InputArgument) prop, (InputArgument) this.ShipColor);
                }
                if (i == 2)
                {
                  prop.AttachTo((Entity) this.Base, 0, new Vector3(0.0f, 0.0f, 14.5f), new Vector3(0.0f, 0.0f, this.GetRoationalAxis()));
                  prop.HasCollision = true;
                  this.Props.Add(prop);
                  if (!this.GoldRails)
                    Function.Call(Hash._0x971DA0055324D033, (InputArgument) prop, (InputArgument) this.RailsColor);
                  else if (this.GoldRails)
                    Function.Call(Hash._0x971DA0055324D033, (InputArgument) prop, (InputArgument) 0);
                }
                if (i == 3)
                {
                  prop.AttachTo((Entity) this.Base, 0, new Vector3(0.0f, 0.0f, 14.5f), new Vector3(0.0f, 0.0f, this.GetRoationalAxis()));
                  prop.HasCollision = true;
                  this.Props.Add(prop);
                }
                if (i == 6)
                {
                  prop.AttachTo((Entity) this.Base, 0, new Vector3(-36.8f, -2.7f, 0.6f), new Vector3(0.0f, 0.0f, 90f));
                  prop.HasCollision = true;
                  if ((Entity) this.DoorA == (Entity) null)
                    this.DoorA = prop;
                  this.Props.Add(prop);
                  Function.Call(Hash._0x971DA0055324D033, (InputArgument) prop, (InputArgument) this.ShipColor);
                }
                if (i == 7)
                {
                  prop.AttachTo((Entity) this.Base, 0, new Vector3(-51f, -2f, 0.3f), new Vector3(0.0f, 0.0f, this.GetRoationalAxis()));
                  prop.HasCollision = true;
                  this.Props.Add(prop);
                }
              }
            }
          }
          else if (i == 4 || i == 5)
          {
            foreach (Prop prop in propArray)
            {
              if ((Entity) this.Base != (Entity) null)
              {
                switch (i)
                {
                  case 4:
                    if ((Entity) this.DoorB == (Entity) null)
                    {
                      this.DoorB = prop;
                      goto label_33;
                    }
                    else
                      goto label_33;
                  case 5:
                    if ((Entity) this.DoorC == (Entity) null)
                    {
                      this.DoorC = prop;
                      goto label_33;
                    }
                    else
                      goto label_33;
                  default:
                    continue;
                }
              }
            }
          }
        }
label_33:
        model.MarkAsNoLongerNeeded();
      }
      catch (Exception ex)
      {
        UI.Notify("~r~ Prop : ~w~" + Prop + "~r~ Failed to spawn");
      }
    }

    public void SpawnDoor(string Prop, Vector3 Pos, Vector3 Rot, int i)
    {
      try
      {
        Model model = new Model(Prop);
        model.Request(250);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(50);
          World.GetNearbyProps(Pos, 100f, model);
          if ((Entity) this.DoorB == (Entity) null)
            this.DoorB = World.CreateProp(model, Pos, false, false);
          if ((Entity) this.DoorC == (Entity) null)
            this.DoorC = World.CreateProp(model, Pos, false, false);
        }
        model.MarkAsNoLongerNeeded();
      }
      catch (Exception ex)
      {
        UI.Notify("~r~ Prop : ~w~" + Prop + "~r~ Failed to spawn");
      }
    }

    public void SpawnFlagA(string Prop, Vector3 Pos, Vector3 Rot, int i)
    {
      try
      {
        Model model = new Model(Prop);
        model.Request(250);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(50);
          World.GetNearbyProps(Pos, 100f, model);
          if ((Entity) this.FlagA == (Entity) null)
          {
            this.FlagA = World.CreateProp(model, Pos, Rot, false, false);
          }
          else
          {
            this.FlagA.Delete();
            this.FlagA = World.CreateProp(model, Pos, Rot, false, false);
          }
        }
        model.MarkAsNoLongerNeeded();
      }
      catch (Exception ex)
      {
        UI.Notify("~r~ Prop : ~w~" + Prop + "~r~ Failed to spawn");
      }
    }

    public void SpawnFlagB(string Prop, Vector3 Pos, Vector3 Rot, int i)
    {
      try
      {
        Model model = new Model(Prop);
        model.Request(250);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(50);
          World.GetNearbyProps(Pos, 100f, model);
          if ((Entity) this.FlagB == (Entity) null)
          {
            this.FlagB = World.CreateProp(model, Pos, Rot, false, false);
          }
          else
          {
            this.FlagB.Delete();
            this.FlagB = World.CreateProp(model, Pos, Rot, false, false);
          }
        }
        model.MarkAsNoLongerNeeded();
      }
      catch (Exception ex)
      {
        UI.Notify("~r~ Prop : ~w~" + Prop + "~r~ Failed to spawn");
      }
    }

    public void SpawnFlagC(string Prop, Vector3 Pos, Vector3 Rot, int i)
    {
      try
      {
        Model model = new Model(Prop);
        model.Request(250);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(50);
          World.GetNearbyProps(Pos, 100f, model);
          if ((Entity) this.FlagC == (Entity) null)
          {
            this.FlagC = World.CreateProp(model, Pos, Rot, false, false);
          }
          else
          {
            this.FlagC.Delete();
            this.FlagC = World.CreateProp(model, Pos, Rot, false, false);
          }
        }
        model.MarkAsNoLongerNeeded();
      }
      catch (Exception ex)
      {
        UI.Notify("~r~ Prop : ~w~" + Prop + "~r~ Failed to spawn");
      }
    }

    public Yacht()
    {
      this.Allstocks = new AllStocks();
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Interval = 1;
      this.CreateBanner();
      this.Setup();
    }

    public void AddPeds()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if ((Entity) this.Bargirl != (Entity) null)
        this.Bargirl.Delete();
      int pedType = this.PedType;
      if (this.PedType == 1)
      {
        System.Random random = new System.Random();
        int num1 = random.Next(1, 100);
        if (num1 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat2, this.Base.Rotation.Z - 5f), 2);
        else if (num1 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat2, this.Base.Rotation.Z - 5f), 1);
        Script.Wait(1);
        this.IsinHottub = false;
        int num2 = random.Next(1, 100);
        if (num2 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat3, this.Base.Rotation.Z + 150f), 2);
        else if (num2 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat3, this.Base.Rotation.Z + 150f), 1);
        Script.Wait(1);
        int num3 = random.Next(1, 100);
        if (num3 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat4, this.Base.Rotation.Z + 220f), 2);
        else if (num3 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat4, this.Base.Rotation.Z + 200f), 1);
        Script.Wait(1);
        int num4 = random.Next(1, 100);
        if (num4 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat5, this.Base.Rotation.Z - 30f), 2);
        else if (num4 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat5, this.Base.Rotation.Z - 30f), 1);
        Script.Wait(1);
        int num5 = random.Next(1, 100);
        if (num5 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat5, this.Base.Rotation.Z + 280f), 2);
        else if (num5 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat5, this.Base.Rotation.Z + 280f), 1);
        Script.Wait(1);
      }
      if (this.PedType == 2)
      {
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat2, this.Base.Rotation.Z - 5f), 1);
        Script.Wait(1);
        this.IsinHottub = false;
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat3, this.Base.Rotation.Z + 150f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat4, this.Base.Rotation.Z + 220f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat5, this.Base.Rotation.Z - 30f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat6, this.Base.Rotation.Z + 280f), 1);
        Script.Wait(1);
      }
      if (this.PedType == 3)
      {
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat2, this.Base.Rotation.Z - 5f), 1);
        Script.Wait(1);
        this.IsinHottub = false;
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat3, this.Base.Rotation.Z + 150f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat4, this.Base.Rotation.Z + 220f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat5, this.Base.Rotation.Z - 30f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AFY, this.jacuzziSeat6, this.Base.Rotation.Z + 280f), 1);
        Script.Wait(1);
      }
      if (this.PedType == 4)
      {
        this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat2, this.Base.Rotation.Z - 5f), 1);
        Script.Wait(1);
        this.IsinHottub = false;
        this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat3, this.Base.Rotation.Z + 150f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat4, this.Base.Rotation.Z + 220f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat5, this.Base.Rotation.Z - 30f), 1);
        Script.Wait(1);
        this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat6, this.Base.Rotation.Z + 280f), 1);
        Script.Wait(1);
      }
      if (this.PedType == 5)
      {
        System.Random random = new System.Random();
        int num1 = random.Next(1, 100);
        if (num1 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat2, this.Base.Rotation.Z - 5f), 2);
        else if (num1 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat2, this.Base.Rotation.Z - 5f), 1);
        Script.Wait(1);
        this.IsinHottub = false;
        int num2 = random.Next(1, 100);
        if (num2 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat3, this.Base.Rotation.Z + 150f), 2);
        else if (num2 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat3, this.Base.Rotation.Z + 150f), 1);
        Script.Wait(1);
        int num3 = random.Next(1, 100);
        if (num3 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat4, this.Base.Rotation.Z + 220f), 2);
        else if (num3 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat4, this.Base.Rotation.Z + 200f), 1);
        Script.Wait(1);
        int num4 = random.Next(1, 100);
        if (num4 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat5, this.Base.Rotation.Z - 30f), 2);
        else if (num4 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat5, this.Base.Rotation.Z - 30f), 1);
        Script.Wait(1);
        int num5 = random.Next(1, 100);
        if (num5 < 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Beach01AMM, this.jacuzziSeat6, this.Base.Rotation.Z + 280f), 2);
        else if (num5 > 50)
          this.PlayAnim(World.CreatePed((Model) PedHash.Topless01AFY, this.jacuzziSeat6, this.Base.Rotation.Z + 280f), 1);
        Script.Wait(1);
      }
      this.Bargirl = World.CreatePed((Model) PedHash.BoatStaff01F, this.BarPos);
      this.Bargirl.Rotation = new Vector3(0.0f, 0.0f, this.Base.Rotation.Z + 90f);
      this.Bargirl.Task.PlayAnimation("anim@amb@yacht@bow@female@variation_01@", "base", 8f, -1, true, -1f);
    }

    public void YachtMenu()
    {
      List<object> Dist = new List<object>();
      Dist.Add((object) 200);
      Dist.Add((object) 250);
      Dist.Add((object) 300);
      Dist.Add((object) 350);
      Dist.Add((object) 400);
      Dist.Add((object) 450);
      Dist.Add((object) 500);
      Dist.Add((object) 550);
      Dist.Add((object) 600);
      Dist.Add((object) 650);
      Dist.Add((object) 700);
      Dist.Add((object) 750);
      Dist.Add((object) 800);
      Dist.Add((object) 900);
      Dist.Add((object) 1000);
      Dist.Add((object) 1100);
      Dist.Add((object) 1200);
      Dist.Add((object) 1300);
      Dist.Add((object) 1400);
      Dist.Add((object) 1500);
      Dist.Add((object) 1600);
      Dist.Add((object) 1700);
      Dist.Add((object) 1800);
      Dist.Add((object) 1900);
      Dist.Add((object) 2000);
      Dist.Add((object) 2100);
      Dist.Add((object) 2200);
      Dist.Add((object) 2300);
      Dist.Add((object) 2400);
      Dist.Add((object) 2500);
      Dist.Add((object) "Spawn on game Load");
      List<object> items1 = new List<object>();
      items1.Add((object) "None");
      items1.Add((object) "Male & Female");
      items1.Add((object) "Male");
      items1.Add((object) "Female");
      items1.Add((object) "Female - Topless");
      items1.Add((object) "Male & Female - Topless");
      List<object> TF = new List<object>();
      TF.Add((object) false);
      TF.Add((object) true);
      List<object> items2 = new List<object>();
      foreach (string str in this.YachtLocSring)
        items2.Add((object) str);
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.ChangePosMenu, "Change Position");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem Yloc = new UIMenuListItem("Location : ", items2, 0);
      uiMenu1.AddItem((UIMenuItem) Yloc);
      UIMenuItem ChangeLoc = new UIMenuItem("Change Location  -$25000");
      uiMenu1.AddItem(ChangeLoc);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != ChangeLoc || Game.Player.Money < 25000)
          return;
        this.Delete();
        this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
        Game.Player.Money -= 25000;
        if (Yloc.Index == 0)
          this.Location = Yloc.Index + 1;
        else if (Yloc.Index > 0)
          this.Location = Yloc.Index;
        this.Config.SetValue<int>(nameof (Yacht), "Location", this.Location);
        this.Config.Save();
        foreach (Blip blip in this.Blips)
        {
          if (blip != (Blip) null)
            blip.Remove();
        }
        if ((Entity) this.FlagA != (Entity) null)
          this.FlagA.Delete();
        if ((Entity) this.FlagB != (Entity) null)
          this.FlagB.Delete();
        if ((Entity) this.FlagC != (Entity) null)
          this.FlagC.Delete();
        if ((Entity) this.DoorC != (Entity) null)
          this.DoorC.Delete();
        if ((Entity) this.DoorB != (Entity) null)
          this.DoorB.Delete();
        if ((Entity) this.Bargirl != (Entity) null)
          this.Bargirl.Delete();
        this.Created = false;
        Game.Player.Character.Position = this.YachtPos[this.Location];
        Blip blip1 = World.CreateBlip(new Vector3(this.YachtPos[this.Location].X, this.YachtPos[this.Location].Y, this.YachtPos[this.Location].Z));
        blip1.Sprite = BlipSprite.Yacht;
        blip1.Name = "Yacht : " + this.Location.ToString() + ", " + this.YachtLocSring[this.Location];
        blip1.Color = BlipColor.Blue;
        this.Blips.Add(blip1);
        this.WaitForCreated = true;
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.ChangePosMenu, "Jacuzzi Options");
      this.GUIMenus.Add(uiMenu2);
      UIMenuListItem PedO = new UIMenuListItem("Ped  : ", items1, 0);
      uiMenu2.AddItem((UIMenuItem) PedO);
      UIMenuItem ChangePeds = new UIMenuItem("Change peds in Jacuzzi");
      uiMenu2.AddItem(ChangePeds);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != ChangePeds)
          return;
        this.PedType = PedO.Index;
        this.Config.SetValue<int>(nameof (Yacht), "PedType", this.PedType);
        this.Config.Save();
        this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
        this.AddPeds();
      });
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.ChangePosMenu, "Misc");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem TM = new UIMenuListItem("Show Test Markers  : ", TF, 0);
      uiMenu3.AddItem((UIMenuItem) TM);
      UIMenuListItem Int = new UIMenuListItem("Spawn Dist : ", Dist, 0);
      uiMenu3.AddItem((UIMenuItem) Int);
      UIMenuListItem Sd = new UIMenuListItem("Show Dist When Close : ", TF, 0);
      uiMenu3.AddItem((UIMenuItem) Sd);
      uiMenu3.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == Sd)
        {
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__351.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__351.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (bool), typeof (Yacht)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.ShowDistWhenClose = Yacht.\u003C\u003Eo__351.\u003C\u003Ep__0.Target((CallSite) Yacht.\u003C\u003Eo__351.\u003C\u003Ep__0, TF[Sd.Index]);
          this.Config.SetValue<bool>(nameof (Yacht), "ShowDistWhenClose", this.ShowDistWhenClose);
          this.Config.Save();
          UI.Notify("Show Dist When close set to : " + Sd.IndexToItem(Sd.Index)?.ToString());
        }
        if (item == TM)
        {
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__351.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__351.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (bool), typeof (Yacht)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.ShowTestBlips = Yacht.\u003C\u003Eo__351.\u003C\u003Ep__1.Target((CallSite) Yacht.\u003C\u003Eo__351.\u003C\u003Ep__1, TF[TM.Index]);
          this.Config.SetValue<bool>(nameof (Yacht), "ShowTestBlips", this.ShowTestBlips);
          this.Config.Save();
          UI.Notify("Test Markers : " + TM.IndexToItem(TM.Index)?.ToString());
        }
        if (item != Int)
          return;
        try
        {
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__351.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__351.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Yacht)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.SpawnDist = Yacht.\u003C\u003Eo__351.\u003C\u003Ep__2.Target((CallSite) Yacht.\u003C\u003Eo__351.\u003C\u003Ep__2, Dist[Int.Index]);
          this.Config.SetValue<int>(nameof (Yacht), "SpawnDist", this.SpawnDist);
          this.Config.Save();
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__351.\u003C\u003Ep__5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__351.\u003C\u003Ep__5 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Action<CallSite, System.Type, object> target1 = Yacht.\u003C\u003Eo__351.\u003C\u003Ep__5.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Action<CallSite, System.Type, object>> p5 = Yacht.\u003C\u003Eo__351.\u003C\u003Ep__5;
          System.Type type = typeof (UI);
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__351.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__351.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string, object> target2 = Yacht.\u003C\u003Eo__351.\u003C\u003Ep__4.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string, object>> p4 = Yacht.\u003C\u003Eo__351.\u003C\u003Ep__4;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__351.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__351.\u003C\u003Ep__3 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Yacht.\u003C\u003Eo__351.\u003C\u003Ep__3.Target((CallSite) Yacht.\u003C\u003Eo__351.\u003C\u003Ep__3, "The Yacht will now load when the player is : ~b~", Dist[Int.Index]);
          object obj2 = target2((CallSite) p4, obj1, "m~w~ away");
          target1((CallSite) p5, type, obj2);
        }
        catch (Exception ex)
        {
          this.SpawnDist = 100000;
          this.Config.SetValue<int>(nameof (Yacht), "SpawnDist", this.SpawnDist);
          this.Config.Save();
          UI.Notify("The Yacht will now load when on game load/mods reload");
        }
      });
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      this.FlagList.Add("apa_prop_flag_wales");
      this.FlagList.Add("apa_prop_flag_us_yt");
      this.FlagList.Add("apa_prop_flag_uk_yt");
      this.FlagList.Add("apa_prop_flag_turkey");
      this.FlagList.Add("apa_prop_flag_switzerland");
      this.FlagList.Add("apa_prop_flag_sweden");
      this.FlagList.Add("apa_prop_flag_spain");
      this.FlagList.Add("apa_prop_flag_southkorea");
      this.FlagList.Add("apa_prop_flag_southafrica");
      this.FlagList.Add("apa_prop_flag_slovenia");
      this.FlagList.Add("apa_prop_flag_slovakia");
      this.FlagList.Add("apa_prop_flag_script");
      this.FlagList.Add("apa_prop_flag_scotland_yt");
      this.FlagList.Add("apa_prop_flag_russia_yt");
      this.FlagList.Add("apa_prop_flag_puertorico");
      this.FlagList.Add("apa_prop_flag_portugal");
      this.FlagList.Add("apa_prop_flag_poland");
      this.FlagList.Add("apa_prop_flag_palestine");
      this.FlagList.Add("apa_prop_flag_norway");
      this.FlagList.Add("apa_prop_flag_nigeria");
      this.FlagList.Add("apa_prop_flag_newzealand");
      this.FlagList.Add("apa_prop_flag_netherlands");
      this.FlagList.Add("apa_prop_flag_mexico_yt");
      this.FlagList.Add("apa_prop_flag_malta");
      this.FlagList.Add("apa_prop_flag_lstein");
      this.FlagList.Add("apa_prop_flag_japan_yt");
      this.FlagList.Add("apa_prop_flag_jamaica");
      this.FlagList.Add("apa_prop_flag_italy");
      this.FlagList.Add("apa_prop_flag_israel");
      this.FlagList.Add("apa_prop_flag_ireland");
      this.FlagList.Add("apa_prop_flag_hungary");
      this.FlagList.Add("apa_prop_flag_german_yt");
      this.FlagList.Add("apa_prop_flag_france");
      this.FlagList.Add("apa_prop_flag_finland");
      this.FlagList.Add("apa_prop_flag_eu_yt");
      this.FlagList.Add("apa_prop_flag_england");
      this.FlagList.Add("apa_prop_flag_denmark");
      this.FlagList.Add("apa_prop_flag_czechrep");
      this.FlagList.Add("apa_prop_flag_croatia");
      this.FlagList.Add("apa_prop_flag_colombia");
      this.FlagList.Add("apa_prop_flag_china");
      this.FlagList.Add("apa_prop_flag_canada_yt");
      this.FlagList.Add("apa_prop_flag_brazil");
      this.FlagList.Add("apa_prop_flag_belgium");
      this.FlagList.Add("apa_prop_flag_austria");
      this.FlagList.Add("apa_prop_flag_australia");
      this.FlagList.Add("apa_prop_flag_argentina");
      this.YachtLocSring.Add("");
      this.YachtLocSring.Add(" Zancudo River 1 ");
      this.YachtLocSring.Add("Zancudo River 2 ");
      this.YachtLocSring.Add("Zancudo River 3 ");
      this.YachtLocSring.Add("Zancudo Base 1 ");
      this.YachtLocSring.Add("Zancudo Base 2 ");
      this.YachtLocSring.Add("Zancudo Base 3 ");
      this.YachtLocSring.Add("North Chumash 1 ");
      this.YachtLocSring.Add("North Chumash 2 ");
      this.YachtLocSring.Add("North Chumash 3 ");
      this.YachtLocSring.Add("Vespucci Beach 1 ");
      this.YachtLocSring.Add("Vespucci Beach 2 ");
      this.YachtLocSring.Add("Vespucci Beach 3 ");
      this.YachtLocSring.Add("LSIA 1 ");
      this.YachtLocSring.Add("LSIA 2 ");
      this.YachtLocSring.Add("LSIA 3 ");
      this.YachtLocSring.Add("Docks 1 ");
      this.YachtLocSring.Add("Docks 2 ");
      this.YachtLocSring.Add("Docks 3 ");
      this.YachtLocSring.Add("Palomino Highlands 1 ");
      this.YachtLocSring.Add("Palomino Highlands 2 ");
      this.YachtLocSring.Add("Palomino Highlands 3 ");
      this.YachtLocSring.Add("Tavarium Mountains 1 ");
      this.YachtLocSring.Add("Tavarium Mountains 2 ");
      this.YachtLocSring.Add("Tavarium Mountains 3 ");
      this.YachtLocSring.Add("San Chianski Mountain Range 1 ");
      this.YachtLocSring.Add("San Chianski Mountain Range 2 ");
      this.YachtLocSring.Add("San Chianski Mountain Range 3 ");
      this.YachtLocSring.Add("Mount Gordo 1 ");
      this.YachtLocSring.Add("Mount Gordo 2 ");
      this.YachtLocSring.Add("Mount Gordo 3 ");
      this.YachtLocSring.Add("Propocio Beach 1 ");
      this.YachtLocSring.Add("Propocio Beach 2 ");
      this.YachtLocSring.Add("Propocio Beach 3 ");
      this.YachtLocSring.Add("Paleto Bay 1 ");
      this.YachtLocSring.Add("Paleto Bay 2 ");
      this.YachtLocSring.Add("Paleto Bay 3 ");
      this.YachtLocSring.Add("Summer Update Yacht");
      this.YachtPos.Add(new Vector3(0.0f, 0.0f, 0.0f));
      this.YachtPos.Add(this.PlayerYachtPos1);
      this.YachtPos.Add(this.PlayerYachtPos2);
      this.YachtPos.Add(this.PlayerYachtPos3);
      this.YachtPos.Add(this.PlayerYachtPos4);
      this.YachtPos.Add(this.PlayerYachtPos5);
      this.YachtPos.Add(this.PlayerYachtPos6);
      this.YachtPos.Add(this.PlayerYachtPos7);
      this.YachtPos.Add(this.PlayerYachtPos8);
      this.YachtPos.Add(this.PlayerYachtPos9);
      this.YachtPos.Add(this.PlayerYachtPos10);
      this.YachtPos.Add(this.PlayerYachtPos11);
      this.YachtPos.Add(this.PlayerYachtPos12);
      this.YachtPos.Add(this.PlayerYachtPos13);
      this.YachtPos.Add(this.PlayerYachtPos14);
      this.YachtPos.Add(this.PlayerYachtPos15);
      this.YachtPos.Add(this.PlayerYachtPos16);
      this.YachtPos.Add(this.PlayerYachtPos17);
      this.YachtPos.Add(this.PlayerYachtPos18);
      this.YachtPos.Add(this.PlayerYachtPos19);
      this.YachtPos.Add(this.PlayerYachtPos20);
      this.YachtPos.Add(this.PlayerYachtPos21);
      this.YachtPos.Add(this.PlayerYachtPos22);
      this.YachtPos.Add(this.PlayerYachtPos23);
      this.YachtPos.Add(this.PlayerYachtPos24);
      this.YachtPos.Add(this.PlayerYachtPos25);
      this.YachtPos.Add(this.PlayerYachtPos26);
      this.YachtPos.Add(this.PlayerYachtPos27);
      this.YachtPos.Add(this.PlayerYachtPos28);
      this.YachtPos.Add(this.PlayerYachtPos29);
      this.YachtPos.Add(this.PlayerYachtPos30);
      this.YachtPos.Add(this.PlayerYachtPos31);
      this.YachtPos.Add(this.PlayerYachtPos32);
      this.YachtPos.Add(this.PlayerYachtPos33);
      this.YachtPos.Add(this.PlayerYachtPos34);
      this.YachtPos.Add(this.PlayerYachtPos35);
      this.YachtPos.Add(this.PlayerYachtPos36);
      this.YachtPos.Add(new Vector3(3615.523f, -4779.021f, 5.433739f));
      this.YachtHashs.Add("");
      this.YachtHashs2.Add("");
      this.YachtHashs.Add("apa_yacht_grp01_1");
      this.YachtHashs2.Add("apa_yacht_grp01_1_int");
      this.YachtHashs.Add("apa_yacht_grp01_2");
      this.YachtHashs2.Add("apa_yacht_grp01_2_int");
      this.YachtHashs.Add("apa_yacht_grp01_3");
      this.YachtHashs2.Add("apa_yacht_grp01_3_int");
      this.YachtHashs.Add("apa_yacht_grp02_1");
      this.YachtHashs2.Add("apa_yacht_grp02_1_int");
      this.YachtHashs.Add("apa_yacht_grp02_2");
      this.YachtHashs2.Add("apa_yacht_grp02_2_int");
      this.YachtHashs.Add("apa_yacht_grp02_3");
      this.YachtHashs2.Add("apa_yacht_grp02_3_int");
      this.YachtHashs.Add("apa_yacht_grp03_1");
      this.YachtHashs2.Add("apa_yacht_grp03_1_int");
      this.YachtHashs.Add("apa_yacht_grp03_2");
      this.YachtHashs2.Add("apa_yacht_grp03_2_int");
      this.YachtHashs.Add("apa_yacht_grp03_3");
      this.YachtHashs2.Add("apa_yacht_grp03_3_int");
      this.YachtHashs.Add("apa_yacht_grp04_1");
      this.YachtHashs2.Add("apa_yacht_grp04_1_int");
      this.YachtHashs.Add("apa_yacht_grp04_2");
      this.YachtHashs2.Add("apa_yacht_grp04_2_int");
      this.YachtHashs.Add("apa_yacht_grp04_3");
      this.YachtHashs2.Add("apa_yacht_grp04_3_int");
      this.YachtHashs.Add("apa_yacht_grp05_1");
      this.YachtHashs2.Add("apa_yacht_grp05_1_int");
      this.YachtHashs.Add("apa_yacht_grp05_2");
      this.YachtHashs2.Add("apa_yacht_grp05_2_int");
      this.YachtHashs.Add("apa_yacht_grp05_3");
      this.YachtHashs2.Add("apa_yacht_grp05_3_int");
      this.YachtHashs.Add("apa_yacht_grp06_1");
      this.YachtHashs2.Add("apa_yacht_grp06_1_int");
      this.YachtHashs.Add("apa_yacht_grp06_2");
      this.YachtHashs2.Add("apa_yacht_grp06_2_int");
      this.YachtHashs.Add("apa_yacht_grp06_3");
      this.YachtHashs2.Add("apa_yacht_grp06_3_int");
      this.YachtHashs.Add("apa_yacht_grp07_1");
      this.YachtHashs2.Add("apa_yacht_grp07_1_int");
      this.YachtHashs.Add("apa_yacht_grp07_2");
      this.YachtHashs2.Add("apa_yacht_grp07_2_int");
      this.YachtHashs.Add("apa_yacht_grp07_3");
      this.YachtHashs2.Add("apa_yacht_grp07_3_int");
      this.YachtHashs.Add("apa_yacht_grp08_1");
      this.YachtHashs2.Add("apa_yacht_grp08_1_int");
      this.YachtHashs.Add("apa_yacht_grp08_2");
      this.YachtHashs2.Add("apa_yacht_grp08_2_int");
      this.YachtHashs.Add("apa_yacht_grp08_3");
      this.YachtHashs2.Add("apa_yacht_grp08_3_int");
      this.YachtHashs.Add("apa_yacht_grp09_1");
      this.YachtHashs2.Add("apa_yacht_grp09_1_int");
      this.YachtHashs.Add("apa_yacht_grp09_2");
      this.YachtHashs2.Add("apa_yacht_grp09_2_int");
      this.YachtHashs.Add("apa_yacht_grp09_3");
      this.YachtHashs2.Add("apa_yacht_grp09_3_int");
      this.YachtHashs.Add("apa_yacht_grp10_1");
      this.YachtHashs2.Add("apa_yacht_grp10_1_int");
      this.YachtHashs.Add("apa_yacht_grp10_2");
      this.YachtHashs2.Add("apa_yacht_grp10_2_int");
      this.YachtHashs.Add("apa_yacht_grp10_3");
      this.YachtHashs2.Add("apa_yacht_grp10_3_int");
      this.YachtHashs.Add("apa_yacht_grp11_1");
      this.YachtHashs2.Add("apa_yacht_grp11_1_int");
      this.YachtHashs.Add("apa_yacht_grp11_2");
      this.YachtHashs2.Add("apa_yacht_grp11_2_int");
      this.YachtHashs.Add("apa_yacht_grp11_3");
      this.YachtHashs2.Add("apa_yacht_grp11_3_int");
      this.YachtHashs.Add("apa_yacht_grp12_1");
      this.YachtHashs2.Add("apa_yacht_grp12_1_int");
      this.YachtHashs.Add("apa_yacht_grp12_2");
      this.YachtHashs2.Add("apa_yacht_grp12_2_int");
      this.YachtHashs.Add("apa_yacht_grp12_3");
      this.YachtHashs2.Add("apa_yacht_grp12_3_int");
      this.YachtHashs.Add("sum_lost_yacht");
      this.YachtHashs2.Add("sum_lost_yacht_int");
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
      this.Created = false;
      if (this.Purchased == 1)
      {
        Blip blip = World.CreateBlip(new Vector3(this.YachtPos[this.Location].X, this.YachtPos[this.Location].Y, this.YachtPos[this.Location].Z));
        blip.Sprite = BlipSprite.Yacht;
        blip.Name = "Yacht : " + this.Location.ToString() + ", " + this.YachtLocSring[this.Location];
        blip.Color = BlipColor.Blue;
        this.Blips.Add(blip);
      }
      this.ChangePosPool = new MenuPool();
      this.ChangePosMainMenu = new UIMenu(nameof (Yacht), "Select an Option");
      this.GUIMenus.Add(this.ChangePosMainMenu);
      this.ChangePosPool.Add(this.ChangePosMainMenu);
      this.ChangePosMenu = this.ChangePosPool.AddSubMenu(this.ChangePosMainMenu, "Yacht Options");
      this.GUIMenus.Add(this.ChangePosMenu);
      this.Woredrobepool = new MenuPool();
      this.WoredrobeMainMenu = new UIMenu("Wardrobe", "Select an Option");
      this.GUIMenus.Add(this.WoredrobeMainMenu);
      this.Woredrobepool.Add(this.WoredrobeMainMenu);
      this.WoredrobeMenu = this.Woredrobepool.AddSubMenu(this.WoredrobeMainMenu, "Change Clothes");
      this.GUIMenus.Add(this.WoredrobeMenu);
      this.WareDrobe();
      this.IsSittinginCeoSeat = false;
      this.waittime = this.Allstocks.waittime;
      this.MarkerEnter = new Vector3(-1539.5f, -610.789f, 30f);
      this.MarkerExit = new Vector3(-1573.788f, -571.0647f, 107.5f);
      this.MenuMarker = new Vector3(-1574.97f, -584.364f, 107f);
      this.RoofEnterMarker = new Vector3(-1565f, -575f, 107f);
      this.RoofExitMarker = new Vector3(-1563.06f, -569f, 114f);
      this.HeliSpawn = new Vector3(-1581.08f, -570.092f, 116f);
      this.CarSpawn = new Vector3(-1541.52f, -570.96f, 25f);
      this.GarageMarker = new Vector3(-1541.52f, -570.96f, 25f);
      this.VehicleSpawn = new Vector3(-36f, -939.158f, 29.5f);
      this.WherehouseMarker = new Vector3(254.6f, -3057f, 5.7f);
      this.AircraftStorageLoc = new Vector3(1679f, 3238f, 40f);
      this.Dockloc = new Vector3(3865f, 4463.66f, 2f);
      this.LotLoc = new Vector3(863f, 2173f, 51f);
      this.Radiopos = new Vector3(-79.33f, -804.844f, 243f);
      this.SleepPos = new Vector3(-1560f, -568f, 108f);
      this.MBTOfficeSitRespawnPos = new Vector3(-1564.72f, -583.497f, 107f);
      this.MBTOfficeSitPos = new Vector3(-1564.72f, -583.497f, 107f);
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Executive Business", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.methgarage = this.modMenuPool.AddSubMenu(this.mainMenu, "Purchase Options");
      this.GUIMenus.Add(this.methgarage);
      this.ProductStock = this.modMenuPool.AddSubMenu(this.mainMenu, "Product Options");
      this.GUIMenus.Add(this.ProductStock);
      this.SpecialMissions = this.modMenuPool.AddSubMenu(this.mainMenu, "Special Missions (Missions)");
      this.GUIMenus.Add(this.SpecialMissions);
      this.YachtMenu();
      this.Setupbuisness();
      this.SetupProduct();
      this.SetupSpecialMissions();
      this.DrinksPool = new MenuPool();
      this.DrinksMainMenu = new UIMenu("Galaxy Super Yacht", "Select an Option");
      this.GUIMenus.Add(this.DrinksMainMenu);
      this.DrinksPool.Add(this.DrinksMainMenu);
      this.DrinksMenu = this.DrinksPool.AddSubMenu(this.mainMenu, "Purchase Options");
      this.GUIMenus.Add(this.DrinksMenu);
      this.Drinks();
      for (int index = 0; index < this.GUIMenus.Count<UIMenu>(); ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void ShowIncrease()
    {
      UI.Notify("Level: " + this.purchaselvl.ToString());
      UI.Notify("Max Stocks: " + this.maxstocks.ToString());
      UI.Notify("Annual Gain: $" + this.increaseGain.ToString("N"));
      UI.Notify("Mission Gain: " + this.profitMargin.ToString() + "%");
      UI.Notify("Stock Value: $" + this.stocksvalue.ToString("N"));
    }

    public VehicleHash RandomVehicleFun()
    {
      int num = new System.Random().Next(1, 13);
      if (num == 1)
        this.RandomVehicle = VehicleHash.Baller;
      if (num == 2)
        this.RandomVehicle = VehicleHash.Dominator;
      if (num == 3)
        this.RandomVehicle = VehicleHash.Dukes;
      if (num == 4)
        this.RandomVehicle = VehicleHash.Comet2;
      if (num == 5)
        this.RandomVehicle = VehicleHash.SabreGT;
      if (num == 6)
        this.RandomVehicle = VehicleHash.Schafter2;
      if (num == 7)
        this.RandomVehicle = VehicleHash.Stalion;
      if (num == 8)
        this.RandomVehicle = VehicleHash.Taco;
      if (num == 9)
        this.RandomVehicle = VehicleHash.Voltic;
      if (num == 10)
        this.RandomVehicle = VehicleHash.XLS;
      if (num == 11)
        this.RandomVehicle = VehicleHash.Vader;
      if (num == 12)
        this.RandomVehicle = VehicleHash.Sultan;
      if (num == 13)
        this.RandomVehicle = VehicleHash.Sanchez;
      if (num > 13)
        this.RandomVehicle = VehicleHash.Chino;
      return this.RandomVehicle;
    }

    public Vector3 Randomlocation()
    {
      System.Random random = new System.Random();
      int num = random.Next(1, 13);
      if (num == 1)
        this.VehicleSpawn = new Vector3(-1069.32f, -72.28f, 19f);
      if (num == 2)
        this.VehicleSpawn = new Vector3(-1579.93f, -155.28f, 55f);
      if (num == 3)
        this.VehicleSpawn = new Vector3(-711.74f, -28.28f, 37f);
      if (num == 4)
        this.VehicleSpawn = new Vector3(6f, 253.58f, 109f);
      if (num == 5)
        this.VehicleSpawn = new Vector3(703f, 32f, 84f);
      if (num == 6)
        this.VehicleSpawn = new Vector3(1197f, -421.5f, 68f);
      if (num == 7)
        this.VehicleSpawn = new Vector3(1257f, -1428f, 35f);
      if (num == 8)
        this.VehicleSpawn = new Vector3(1264f, -2039f, 45f);
      if (num == 9)
        this.VehicleSpawn = new Vector3(527f, -2052f, 28f);
      if (num == 10)
        this.VehicleSpawn = new Vector3(-161f, -2087.8f, 26f);
      if (random.Next(1, 13) == 11)
        this.VehicleSpawn = new Vector3(756f, -1723f, 30f);
      if (num == 12)
        this.VehicleSpawn = new Vector3(-816f, -2300f, 11f);
      if (num == 13)
        this.VehicleSpawn = new Vector3(-1839f, 136f, 78f);
      if (num > 13)
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
      if (Yacht.\u003C\u003Eo__360.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Yacht.\u003C\u003Eo__360.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (Yacht)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      return Yacht.\u003C\u003Eo__360.\u003C\u003Ep__0.Target((CallSite) Yacht.\u003C\u003Eo__360.\u003C\u003Ep__0, objectList[index1]);
    }

    public void SetupSpecialMissions()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.SpecialMissions, "Special Missions");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Race1 = new UIMenuItem("ExPatriot");
      uiMenu.AddItem(Race1);
      UIMenuItem Race2 = new UIMenuItem("Electrical Discharge");
      uiMenu.AddItem(Race2);
      UIMenuItem Race3 = new UIMenuItem("Piracy Scam ");
      uiMenu.AddItem(Race3);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Race3)
        {
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.VtoGetBlip != (Blip) null)
            this.VtoGetBlip.Remove();
          Vector3 position = this.Randomlocation();
          this.VtoGet = World.CreateVehicle((Model) this.RandomVehicleFun(), position, 45f);
          UI.Notify(this.GetHostName() + " Boss weve got some Joker trying to hack into out server to steal stock, find them! and destroy there vehicle");
          UI.Notify("test1");
          this.VtoGetBlip = World.CreateBlip(position);
          UI.Notify("test2");
          this.VtoGetBlip.Name = "Find Vehicle";
          this.VtoGetBlip.Sprite = BlipSprite.Wifi;
          this.VtoGetBlip.Color = BlipColor.Blue;
          this.VtoGetBlip.Name = "Find Vehicle";
          UI.Notify("test3");
          this.stocktoloose = 0.0f;
          this.ISinPiracyScamMission = true;
          this.Piracymission = 1;
          this.HackhasStarted = false;
          this.GoPoint = this.VtoGet.Position;
          this.TimerLeft = 4000;
          this.VehicleSetup = true;
        }
        if (item == Race1)
        {
          UI.Notify(this.GetHostName() + " Retrieve the Patriot Stretch and bring it to the Combined Vehicle Storage");
          if ((Entity) this.VtoGet != (Entity) null)
            this.VtoGet.Delete();
          if (this.VtoGetBlip != (Blip) null)
            this.VtoGetBlip.Remove();
          foreach (Ped guard in this.Guards)
          {
            if ((Entity) guard != (Entity) null)
              guard.Delete();
          }
          foreach (Ped ped in this.Driver)
          {
            if (this.Driver != null)
              ped.Delete();
          }
          this.VtoGet = World.CreateVehicle((Model) "PATRIOT2", new Vector3(-1490f, 147f, 54f), 45f);
          this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
          this.VtoGet.IsPersistent = true;
          this.VtoGetBlip.Name = "Retrieve Patriot Stretch";
          this.VtoGetBlip.Sprite = BlipSprite.SportsCar;
          this.VtoGetBlip.Color = BlipColor.White;
          this.VtoGetBlip.Name = "Retrieve Patriot Stretch";
          this.VehicleSetup = true;
          this.Missionnum = 12;
          this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(-1467f, 157f, 54f)));
          this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(-1491f, 165f, 54f)));
          this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(-1483f, 158f, 54f)));
          this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(-1467f, 145f, 45f)));
          this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(-1500f, 144f, 55f)));
          this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(-1480f, 138f, 55f)));
          this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(-1477f, 165f, 55f)));
          this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(-1466f, 164f, 55f)));
          foreach (Ped guard in this.Guards)
          {
            guard.Weapons.Give(WeaponHash.SpecialCarbineMk2, 9999, true, true);
            guard.RelationshipGroup = 4;
            guard.IsEnemy = true;
          }
          this.Driver.Add(World.CreatePed((Model) "CSB_TonyPrince", new Vector3(-1186.21f, 282f, 69f)));
          this.GotCar = false;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.VtoGet.Handle, (InputArgument) 0);
          this.VtoGet.PrimaryColor = VehicleColor.MatteWhite;
          this.VtoGet.SecondaryColor = VehicleColor.MetallicWhite;
          this.VtoGet.SetMod(VehicleMod.Livery, 17, true);
          this.VtoGet.SetMod(VehicleMod.Struts, 8, true);
          this.VtoGet.SetMod(VehicleMod.Hood, 2, true);
          this.VtoGet.NumberPlate = "PR2NCE";
          this.VtoGet.SetMod(VehicleMod.ArchCover, 4, true);
          this.VtoGet.WindowTint = VehicleWindowTint.PureBlack;
        }
        if (item != Race2)
          return;
        UI.Notify(this.GetHostName() + " Retrieve Each Electric Car from the 10 car garage, and bring it back to Combined Vehicle Storage");
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        if (this.VtoGetBlip != (Blip) null)
          this.VtoGetBlip.Remove();
        foreach (Ped guard in this.Guards)
        {
          if ((Entity) guard != (Entity) null)
            guard.Delete();
        }
        foreach (Ped ped in this.Driver)
        {
          if (this.Driver != null)
            ped.Delete();
        }
        this.VtoGet = World.CreateVehicle((Model) VehicleHash.Tezeract, new Vector3(222f, -999f, -99f), -50f);
        this.VtoGet1 = World.CreateVehicle((Model) VehicleHash.Neon, new Vector3(223f, -993f, -99f), -50f);
        this.VtoGet2 = World.CreateVehicle((Model) VehicleHash.Raiden, new Vector3(223f, -986f, -99f), -50f);
        this.VtoGet3 = World.CreateVehicle((Model) VehicleHash.Cyclone, new Vector3(223f, -981f, -99f), -50f);
        this.VtoGetBlip = World.CreateBlip(new Vector3(213f, -936f, 24f));
        this.VtoGet.IsPersistent = true;
        this.VtoGetBlip.Name = "Retrieve Eletric cars from Impound";
        this.VtoGetBlip.Sprite = BlipSprite.SportsCar;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Retrieve Eletric cars from Impound";
        this.VehicleSetup = true;
        this.Missionnum = 13;
        this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(233f, -942f, 29f)));
        this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3((float) byte.MaxValue, -886f, 29f)));
        this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(214f, -1003f, 29f)));
        this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(212f, -946f, 24f)));
        this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(210f, -944f, 24f)));
        this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(218f, -939f, 24f)));
        this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(224f, -930f, 24f)));
        this.Guards.Add(World.CreatePed((Model) PedHash.Bouncer01SMM, new Vector3(221f, -927f, 24f)));
        foreach (Ped guard in this.Guards)
        {
          guard.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);
          guard.RelationshipGroup = 4;
          guard.IsEnemy = true;
        }
        this.GotCar = false;
        this.VtoGet.PrimaryColor = VehicleColor.MetallicBlack;
        this.VtoGet.SecondaryColor = VehicleColor.MetallicOrange;
        this.VtoGet1.PrimaryColor = VehicleColor.MetallicRaceYellow;
        this.VtoGet1.SecondaryColor = VehicleColor.MetallicRaceYellow;
        this.VtoGet2.PrimaryColor = VehicleColor.MetallicBlue;
        this.VtoGet2.SecondaryColor = VehicleColor.MetallicBlue;
        this.VtoGet3.PrimaryColor = VehicleColor.MetallicCabernetRed;
        this.VtoGet3.SecondaryColor = VehicleColor.MetallicGraphiteBlack;
        this.Vehiclesleft = 4;
      });
    }

    public void OpenMenu()
    {
      Script.Wait(25);
      UI.Notify("Menu");
      this.MenuOn = true;
    }

    public void ChooseVehicle(int i)
    {
      if (i == 1)
      {
        this.carid = "Mogul";
        this.VehicleMissioncar = World.CreateVehicle(new Model(-749299473), this.VehicleLocation);
        this.VehicleMissioncar.PlaceOnGround();
      }
      if (i == 2)
      {
        this.carid = "Cuban 800";
        this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Cuban800, this.VehicleLocation);
        this.VehicleMissioncar.PlaceOnGround();
      }
      if (i == 3)
      {
        this.carid = "Duster";
        this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Duster, this.VehicleLocation);
        this.VehicleMissioncar.PlaceOnGround();
      }
      if (i != 4)
        return;
      this.carid = "Mammatus";
      this.VehicleMissioncar = World.CreateVehicle((Model) VehicleHash.Mammatus, this.VehicleLocation);
      this.VehicleMissioncar.PlaceOnGround();
    }

    public void SetupProduct()
    {
      List<object> items = new List<object>();
      items.Add((object) "Maze Bank");
      items.Add((object) "Arcadius");
      items.Add((object) "Maze Bank West");
      items.Add((object) "Lombok");
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.ProductStock, "Buy/Sell Product");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem B = new UIMenuListItem("Business : ", items, 0);
      uiMenu.AddItem((UIMenuItem) B);
      UIMenuItem Buy2 = new UIMenuItem("Buy X10: -$" + 500000.ToString());
      uiMenu.AddItem(Buy2);
      UIMenuItem Buy = new UIMenuItem("Buy X1: -$" + 100000.ToString());
      uiMenu.AddItem(Buy);
      UIMenuItem Sell = new UIMenuItem("Sell - All Stocks (Low)");
      uiMenu.AddItem(Sell);
      UIMenuItem Sell2 = new UIMenuItem("Sell - All Stocks (High)");
      uiMenu.AddItem(Sell2);
      UIMenuItem Show = new UIMenuItem("Show Product Value/Count");
      uiMenu.AddItem(Show);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Show)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify(this.GetHostName() + " Here is where we are at");
          UI.Notify("Level: " + this.purchaselvl.ToString() + "/20");
          this.ShowIncrease();
        }
        if (item == Buy2)
        {
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
        if (item == Sell)
        {
          UI.Notify(this.GetHostName() + " ok i can deal with that, selling all product avalable");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item != Sell2)
          return;
        if ((Entity) this.VtoGet != (Entity) null)
          this.VtoGet.Delete();
        if (this.VtoGetBlip != (Blip) null)
          this.VtoGetBlip.Remove();
        UI.Notify(this.GetHostName() + " ok get the mule from the Combined Vehicle Storage and deliver it to the drop zone");
        this.Missionnum = 14;
        this.VtoGet = World.CreateVehicle((Model) VehicleHash.Mule, this.LotLoc);
        this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, 44f);
        this.VtoGetBlip = World.CreateBlip(this.VtoGet.Position);
        this.VtoGetBlip.Name = "Take Mule to drop point";
        this.VtoGetBlip.Sprite = BlipSprite.Trailer;
        this.VtoGetBlip.Color = BlipColor.White;
        this.VtoGetBlip.Name = "Take Mule to drop point";
        this.VehicleisDamaged = false;
        this.Vehiclehealth = this.VtoGet.Health;
        this.VehicleSetup = true;
        this.GotCar = false;
      });
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != B)
          return;
        if (B.Index == 0)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~b~ Maze Bank~w~");
        }
        if (B.Index == 1)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~y~ Arcadius ~w~");
        }
        if (B.Index == 2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~r~ Maze Bank West ~w~");
        }
        if (B.Index != 3)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        UI.Notify("~w~Selected ~g~ Lombok ~w~");
      });
    }

    public void Setupbuisness()
    {
      List<object> items1 = new List<object>();
      items1.Add((object) "Maze Bank");
      items1.Add((object) "Arcadius");
      items1.Add((object) "Maze Bank West");
      items1.Add((object) "Lombok");
      List<object> CamP = new List<object>();
      List<object> CamR = new List<object>();
      List<object> Options = new List<object>();
      List<object> Price = new List<object>();
      List<object> Location = new List<object>();
      Options.Add((object) "Option1");
      Price.Add((object) 1580000);
      Location.Add((object) "Elysian Island");
      CamP.Add((object) new Vector3(296f, -3092f, 8f));
      CamR.Add((object) 43);
      Options.Add((object) "Option2");
      Price.Add((object) 2380000);
      Location.Add((object) "La Mesa");
      CamP.Add((object) new Vector3(946f, -1506f, 32f));
      CamR.Add((object) 11);
      Options.Add((object) "Option3");
      Price.Add((object) 2675000);
      Location.Add((object) "Cypress Flats");
      CamP.Add((object) new Vector3(795f, -2243f, 33f));
      CamR.Add((object) -15);
      Options.Add((object) "Option4");
      Price.Add((object) 1635000);
      Location.Add((object) "El Burro Heights");
      CamP.Add((object) new Vector3(1778f, -1665f, 116f));
      CamR.Add((object) 39);
      Options.Add((object) "Option5");
      Price.Add((object) 1950000);
      Location.Add((object) "Elysian Island");
      CamP.Add((object) new Vector3(158f, -2962f, 14f));
      CamR.Add((object) 160);
      Options.Add((object) "Option6");
      Price.Add((object) 1500000);
      Location.Add((object) "La Mesa");
      CamP.Add((object) new Vector3(999f, -1875f, 37f));
      CamR.Add((object) -8);
      Options.Add((object) "Option7");
      Price.Add((object) 2730000);
      Location.Add((object) "La Puerta");
      CamP.Add((object) new Vector3(-648f, -1793f, 27f));
      CamR.Add((object) -61);
      Options.Add((object) "Option8");
      Price.Add((object) 2170000);
      Location.Add((object) "LSIA");
      CamP.Add((object) new Vector3(-1171f, -2195f, 20f));
      CamR.Add((object) -42);
      Options.Add((object) "Option9");
      Price.Add((object) 2300000);
      Location.Add((object) "LSIA");
      CamP.Add((object) new Vector3(-489f, -2178f, 10f));
      CamR.Add((object) 128);
      Options.Add((object) "Option10");
      Price.Add((object) 2850000);
      Location.Add((object) "Murrieta Heights");
      CamP.Add((object) new Vector3(1200f, -1273f, 37f));
      CamR.Add((object) -43);
      Options.Add((object) "Option11");
      Price.Add((object) 4550000);
      Location.Add((object) "Pacific Bluffs");
      CamP.Add((object) new Vector3(-2059f, -257f, 26.5f));
      CamR.Add((object) -113);
      Options.Add((object) "Option12");
      Price.Add((object) 4850000);
      Location.Add((object) "Hawick");
      CamP.Add((object) new Vector3(541.3f, -229f, 56f));
      CamR.Add((object) -22);
      Options.Add((object) "Option13");
      Price.Add((object) 2350000);
      Location.Add((object) "Strawberry");
      CamP.Add((object) new Vector3(62f, -1283f, 32f));
      CamR.Add((object) 85);
      Options.Add((object) "Option14");
      Price.Add((object) 1150000);
      Location.Add((object) "La Mesa");
      CamP.Add((object) new Vector3(511f, -624f, 28f));
      CamR.Add((object) 129);
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.methgarage, "Change Warehouse Position");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem Positions = new UIMenuListItem("Option : ", Options, 0);
      uiMenu1.AddItem((UIMenuItem) Positions);
      UIMenuItem Loc = new UIMenuItem("Location : ");
      uiMenu1.AddItem(Loc);
      UIMenuItem pr1 = new UIMenuItem("Price : $0");
      uiMenu1.AddItem(pr1);
      UIMenuItem uiMenuItem1 = new UIMenuItem("Current");
      uiMenu1.AddItem(uiMenuItem1);
      UIMenuItem Set = new UIMenuItem("Set");
      uiMenu1.AddItem(Set);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Set || !(this.WarehouseCam != (Camera) null))
          return;
        object obj1 = Price[Positions.Index];
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__1 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Action<CallSite, System.Type, object> target1 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Action<CallSite, System.Type, object>> p1 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__1;
        System.Type type = typeof (UI);
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__0 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__0.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__0, "Cash ", obj1);
        target1((CallSite) p1, type, obj2);
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target2 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p3 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__2 = CallSite<Func<CallSite, int, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThanOrEqual, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__2.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__2, Game.Player.Money, obj1);
        if (!target2((CallSite) p3, obj3))
          return;
        this.WCamOn = false;
        Player player1 = Game.Player;
        Player player2 = player1;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (int), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, int> target3 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__5.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, int>> p5 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__5;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__4 = CallSite<Func<CallSite, int, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.SubtractAssign, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__4.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__4, player1.Money, obj1);
        int num = target3((CallSite) p5, obj4);
        player2.Money = num;
        Game.Player.Character.IsVisible = true;
        Camera warehouseCam1 = this.WarehouseCam;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, Vector3>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Vector3), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Vector3 vector3_1 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__6.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__6, CamP[Positions.Index]);
        warehouseCam1.Position = vector3_1;
        Camera warehouseCam2 = this.WarehouseCam;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__7 = CallSite<Func<CallSite, System.Type, int, int, object, Vector3>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Vector3 vector3_2 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__7.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__7, typeof (Vector3), 0, 0, CamR[Positions.Index]);
        warehouseCam2.Rotation = vector3_2;
        this.WarehouseCam.FarClip = 2000f;
        this.WarehouseCam.IsActive = false;
        this.WarehouseCam.Destroy();
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        this.modMenuPool.CloseAllMenus();
        Game.Player.Character.FreezePosition = false;
        Game.Player.Character.Position = this.MenuMarker;
        this.modMenuPool.CloseAllMenus();
        this.WarehouseCam.Destroy();
        this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Warehouse.ini");
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.WarehousePos = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__8.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__8, Options[Positions.Index]);
        this.Config.SetValue<string>("Position", "WarehousePos", this.WarehousePos);
        this.Config.Save();
        UI.Notify("~g~HKH191~w~ : Please reload the mod for the changes to take effect, thank you");
      });
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != Positions)
          return;
        if (this.WarehouseCam != (Camera) null)
        {
          this.WCamOn = true;
          Camera warehouseCam1 = this.WarehouseCam;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__9 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__365.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, Vector3>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Vector3), typeof (Yacht)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Vector3 vector3_1 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__9.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__9, CamP[Positions.Index]);
          warehouseCam1.Position = vector3_1;
          Camera warehouseCam2 = this.WarehouseCam;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__10 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__365.\u003C\u003Ep__10 = CallSite<Func<CallSite, System.Type, int, int, object, Vector3>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Vector3 vector3_2 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__10.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__10, typeof (Vector3), 0, 0, CamR[Positions.Index]);
          warehouseCam2.Rotation = vector3_2;
          Ped character = Game.Player.Character;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__11 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__365.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, Vector3>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Vector3), typeof (Yacht)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Vector3 vector3_3 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__11.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__11, CamP[Positions.Index]);
          character.Position = vector3_3;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.IsVisible = false;
          this.WarehouseCam.IsActive = true;
          this.WarehouseCam.FarClip = 2000f;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          World.RenderingCamera = this.WarehouseCam;
          UIMenuItem uiMenuItem2 = pr1;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__14 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__365.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Yacht)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target1 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__14.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p14 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__14;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__13 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__365.\u003C\u003Ep__13 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, string, object, object> target2 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__13.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, string, object, object>> p13 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__13;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__12 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__365.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__12.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__12, Price[Positions.Index], "N");
          object obj2 = target2((CallSite) p13, "Price : $", obj1);
          string str1 = target1((CallSite) p14, obj2);
          uiMenuItem2.Text = str1;
          UIMenuItem uiMenuItem3 = Loc;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__16 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__365.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Yacht)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target3 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__16.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p16 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__16;
          // ISSUE: reference to a compiler-generated field
          if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__15 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Yacht.\u003C\u003Eo__365.\u003C\u003Ep__15 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj3 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__15.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__15, "Location : ", Location[Positions.Index]);
          string str2 = target3((CallSite) p16, obj3);
          uiMenuItem3.Text = str2;
        }
        if (!(this.WarehouseCam == (Camera) null))
          return;
        this.WCamOn = true;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__19 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, Camera>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Camera), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, Camera> target4 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__19.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, Camera>> p19 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__19;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__18 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__18 = CallSite<Func<CallSite, System.Type, object, Vector3, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "CreateCamera", (IEnumerable<System.Type>) null, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, System.Type, object, Vector3, int, object> target5 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__18.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, System.Type, object, Vector3, int, object>> p18 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__18;
        System.Type type = typeof (World);
        object obj4 = CamP[Positions.Index];
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__17 = CallSite<Func<CallSite, System.Type, int, int, object, Vector3>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Vector3 vector3_4 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__17.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__17, typeof (Vector3), 0, 0, CamR[Positions.Index]);
        object obj5 = target5((CallSite) p18, type, obj4, vector3_4, 100);
        this.WarehouseCam = target4((CallSite) p19, obj5);
        Camera warehouseCam3 = this.WarehouseCam;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, Vector3>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Vector3), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Vector3 vector3_5 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__20.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__20, CamP[Positions.Index]);
        warehouseCam3.Position = vector3_5;
        Camera warehouseCam4 = this.WarehouseCam;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__21 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__21 = CallSite<Func<CallSite, System.Type, int, int, object, Vector3>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Vector3 vector3_6 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__21.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__21, typeof (Vector3), 0, 0, CamR[Positions.Index]);
        warehouseCam4.Rotation = vector3_6;
        Game.Player.Character.IsVisible = false;
        this.WarehouseCam.IsActive = true;
        this.WarehouseCam.FarClip = 2000f;
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        World.RenderingCamera = this.WarehouseCam;
        Ped character1 = Game.Player.Character;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__22 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, Vector3>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Vector3), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Vector3 vector3_7 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__22.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__22, CamP[Positions.Index]);
        character1.Position = vector3_7;
        Game.Player.Character.FreezePosition = true;
        UIMenuItem uiMenuItem4 = pr1;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__25 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__25 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target6 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__25.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p25 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__25;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__24 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__24 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, string, object, object> target7 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__24.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, string, object, object>> p24 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__24;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__23 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__23 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj6 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__23.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__23, Price[Positions.Index], "N");
        object obj7 = target7((CallSite) p24, "Price : $", obj6);
        string str3 = target6((CallSite) p25, obj7);
        uiMenuItem4.Text = str3;
        UIMenuItem uiMenuItem5 = Loc;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__27 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__27 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Yacht)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target8 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__27.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p27 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__27;
        // ISSUE: reference to a compiler-generated field
        if (Yacht.\u003C\u003Eo__365.\u003C\u003Ep__26 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Yacht.\u003C\u003Eo__365.\u003C\u003Ep__26 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (Yacht), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj8 = Yacht.\u003C\u003Eo__365.\u003C\u003Ep__26.Target((CallSite) Yacht.\u003C\u003Eo__365.\u003C\u003Ep__26, "Location : ", Location[Positions.Index]);
        string str4 = target8((CallSite) p27, obj8);
        uiMenuItem5.Text = str4;
      });
      List<object> items2 = new List<object>();
      int num1 = 1;
      for (int index = 1; index < 100; ++index)
        items2.Add((object) (num1 + index));
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.methgarage, "Expand Business ");
      this.GUIMenus.Add(uiMenu2);
      UIMenuListItem B = new UIMenuListItem("Business : ", items1, 0);
      uiMenu2.AddItem((UIMenuItem) B);
      UIMenuItem Update = new UIMenuItem("Update Stats");
      uiMenu2.AddItem(Update);
      UIMenuItem BuyNewLevel = new UIMenuItem(" Buy Level ");
      uiMenu2.AddItem(BuyNewLevel);
      UIMenuListItem list2 = new UIMenuListItem("Select Level: ", items2, 1);
      uiMenu2.AddItem((UIMenuItem) list2);
      UIMenuItem Jump = new UIMenuItem("Jump Straight to Level");
      uiMenu2.AddItem(Jump);
      UIMenuItem Show = new UIMenuItem("Show Level");
      uiMenu2.AddItem(Show);
      uiMenu2.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != B)
          return;
        if (B.Index == 0)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~b~ Maze Bank~w~");
        }
        if (B.Index == 1)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~y~ Arcadius ~w~");
        }
        if (B.Index == 2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~r~ Maze Bank West ~w~");
        }
        if (B.Index != 3)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        UI.Notify("~w~Selected ~g~ Lombok ~w~");
      });
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.methgarage, "Sell  Business");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem B1 = new UIMenuListItem("Business : ", items1, 0);
      uiMenu3.AddItem((UIMenuItem) B1);
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
      uiMenu3.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != B1)
          return;
        if (B1.Index == 0)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~b~ Maze Bank~w~");
        }
        if (B1.Index == 1)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~y~ Arcadius ~w~");
        }
        if (B1.Index == 2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("~w~Selected ~r~ Maze Bank West ~w~");
        }
        if (B1.Index != 3)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        UI.Notify("~w~Selected ~g~ Lombok ~w~");
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
              num3 += (int) (200000.0 * num5 * (double) num2);
              ++num4;
            }
            UI.Notify(this.GetHostName() + " OK your new level will be " + (this.purchaselvl += num4 + 1).ToString() + ", at a price of $" + num3.ToString("N") + ", Do u want to continue Enter Y or N");
            Script.Wait(1000);
            try
            {
              if (Game.GetUserInput(WindowTitle.CELL_EMAIL_BOD, 1).Equals("Y"))
              {
                if (Game.Player.Money >= num3)
                {
                  Game.Player.Money -= num3;
                  this.purchaselvl = num2;
                  float num5 = (float) (125000 * this.purchaselvl) / 0.75f;
                  this.maxstocks = 10 * this.purchaselvl;
                  this.maxstocks = 10 * this.purchaselvl;
                  this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
                  this.increaseGain = num5;
                  this.Config.SetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
                  this.Config.Save();
                }
                else
                  UI.Notify("You dont have enough money to purchase this upgrade");
              }
              else
              {
                this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
                UI.Notify(this.GetHostName() + " You Entered the Wrong key or N");
              }
            }
            catch (NullReferenceException ex)
            {
              this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
              UI.Notify("You did not enter a key!");
            }
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
          UI.Notify("Price " + (200000.0 * num3 * (double) num2).ToString("N"));
          UI.Notify("Level to Buy " + (num2 + 1).ToString());
          UI.Notify("increaseGain : $" + ((float) (125000 * num2) / 0.75f).ToString());
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
            if ((double) Game.Player.Money >= 200000.0 * num3 * (double) num2)
            {
              Game.Player.Money -= (int) (200000.0 * num3 * (double) num2);
              ++this.purchaselvl;
              this.maxstocks = 10 * this.purchaselvl;
              float num4 = (float) (125000 * this.purchaselvl) / 0.75f;
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
        double num6 = 1.75;
        if (this.purchaselvl < 25)
          num6 = 1.75;
        if (this.purchaselvl > 25 && index < 50)
          num6 = 2.25;
        if (this.purchaselvl > 50 && this.purchaselvl < 70)
          num6 = 3.5;
        if (this.purchaselvl > 75 && this.purchaselvl < 100)
          num6 = 4.75;
        UI.Notify("Price for Next Level $" + (200000.0 * num6 * (double) this.purchaselvl).ToString("N"));
        UI.Notify("Next Level " + (this.purchaselvl + 1).ToString());
        UI.Notify("increaseGain : $" + ((float) (125000 * this.purchaselvl) / 0.75f).ToString());
        UI.Notify("Profit Margin :" + (0.85 * (double) this.purchaselvl + 0.0).ToString() + "%");
        UI.Notify("Max Stocks : " + (10 * this.purchaselvl).ToString());
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

    public void Delete()
    {
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.YachtHashs[this.Location]);
      Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) this.YachtHashs2[this.Location]);
      if ((Entity) this.Base != (Entity) null)
        this.Base.Delete();
      this.Created = false;
      this.DeletedYacht = false;
      this.Foundyacht = false;
      if ((Entity) this.BoatA != (Entity) null)
        this.BoatA.Delete();
      if ((Entity) this.BoatB != (Entity) null)
        this.BoatB.Delete();
      if ((Entity) this.SeaSharkA != (Entity) null)
        this.SeaSharkA.Delete();
      if ((Entity) this.SeaSharkB != (Entity) null)
        this.SeaSharkB.Delete();
      if ((Entity) this.SeaSharkC != (Entity) null)
        this.SeaSharkC.Delete();
      if ((Entity) this.SeaSharkD != (Entity) null)
        this.SeaSharkD.Delete();
      if ((Entity) this.FlagA != (Entity) null)
        this.FlagA.Delete();
      if ((Entity) this.FlagB != (Entity) null)
        this.FlagB.Delete();
      if ((Entity) this.FlagC != (Entity) null)
        this.FlagC.Delete();
      if ((Entity) this.DoorC != (Entity) null)
        this.DoorC.Delete();
      if ((Entity) this.DoorB != (Entity) null)
        this.DoorB.Delete();
      if ((Entity) this.Bargirl != (Entity) null)
        this.Bargirl.Delete();
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if ((Entity) this.HeliA != (Entity) null)
        this.HeliA.Delete();
      if ((Entity) this.HeliB != (Entity) null)
        this.HeliB.Delete();
      if ((Entity) this.Base != (Entity) null)
        this.Base.Delete();
      foreach (Prop nearbyProp in World.GetNearbyProps(this.YachtPos[this.Location], 500f))
      {
        if ((Entity) nearbyProp != (Entity) null)
          nearbyProp.Delete();
      }
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      foreach (Prop prop in this.Champ)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (this.WarehouseCam != (Camera) null)
      {
        World.RenderingCamera = this.WarehouseCam;
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        this.WarehouseCam.IsActive = false;
        this.WarehouseCam.Destroy();
        Game.Player.Character.FreezePosition = false;
      }
      if (this.DestoryVehicle != (Blip) null)
        this.DestoryVehicle.Remove();
      if ((Entity) this.VehicleMissioncar != (Entity) null)
        this.VehicleMissioncar.Delete();
      if ((Entity) this.VehicleId != (Entity) null)
        this.VehicleId.Delete();
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
      if (this.DropzoneBlip != (Blip) null)
        this.DropzoneBlip.Remove();
      if ((Entity) this.RentedVehicle != (Entity) null)
        this.RentedVehicle.Delete();
      if ((Entity) this.BoatA != (Entity) null)
        this.BoatA.Delete();
      if ((Entity) this.BoatB != (Entity) null)
        this.BoatB.Delete();
      if ((Entity) this.SeaSharkA != (Entity) null)
        this.SeaSharkA.Delete();
      if ((Entity) this.SeaSharkB != (Entity) null)
        this.SeaSharkB.Delete();
      if ((Entity) this.SeaSharkC != (Entity) null)
        this.SeaSharkC.Delete();
      if ((Entity) this.SeaSharkD != (Entity) null)
        this.SeaSharkD.Delete();
      if ((Entity) this.FlagA != (Entity) null)
        this.FlagA.Delete();
      if ((Entity) this.FlagB != (Entity) null)
        this.FlagB.Delete();
      if ((Entity) this.FlagC != (Entity) null)
        this.FlagC.Delete();
      if ((Entity) this.DoorC != (Entity) null)
        this.DoorC.Delete();
      if ((Entity) this.DoorB != (Entity) null)
        this.DoorB.Delete();
      if ((Entity) this.Bargirl != (Entity) null)
        this.Bargirl.Delete();
      foreach (Ped ped in this.Peds)
      {
        if ((Entity) ped != (Entity) null)
          ped.Delete();
      }
      if ((Entity) this.HeliA != (Entity) null)
        this.HeliA.Delete();
      if ((Entity) this.HeliB != (Entity) null)
        this.HeliB.Delete();
      foreach (Prop prop in this.Props)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      foreach (Blip blip in this.Blips)
      {
        if (blip != (Blip) null)
          blip.Remove();
      }
    }

    public void PlayAnim(Ped p, int Gender)
    {
      System.Random random = new System.Random();
      int num1 = random.Next(1, 5);
      p.FreezePosition = true;
      p.AlwaysKeepTask = true;
      if (Gender == 1)
      {
        if (num1 == 1)
        {
          int num2 = random.Next(1, 4);
          if (num2 == 1)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_01@", "base", 8f, -1, true, -1f);
          if (num2 == 2)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_01@", "base_a", 8f, -1, true, -1f);
          if (num2 == 3)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_01@", "base_b", 8f, -1, true, -1f);
          if (num2 == 4)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_01@", "base_c", 8f, -1, true, -1f);
        }
        if (num1 == 2)
        {
          int num2 = random.Next(1, 4);
          if (num2 == 1)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_02@", "base", 8f, -1, true, -1f);
          if (num2 == 2)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_02@", "base_a", 8f, -1, true, -1f);
          if (num2 == 3)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_02@", "base_b", 8f, -1, true, -1f);
          if (num2 == 4)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_02@", "base_c", 8f, -1, true, -1f);
        }
        if (num1 == 3)
        {
          int num2 = random.Next(1, 4);
          if (num2 == 1)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base", 8f, -1, true, -1f);
          if (num2 == 2)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base_a", 8f, -1, true, -1f);
          if (num2 == 3)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base_b", 8f, -1, true, -1f);
          if (num2 == 4)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_03@", "base_c", 8f, -1, true, -1f);
        }
        if (num1 == 4)
          p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_04@", "base", 8f, -1, true, -1f);
        if (num1 == 5)
          p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@female@variation_05@", "base", 8f, -1, true, -1f);
      }
      if (Gender == 2)
      {
        if (num1 == 1)
        {
          int num2 = random.Next(1, 4);
          if (num2 == 1)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_01@", "base", 8f, -1, true, -1f);
          if (num2 == 2)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_01@", "base_a", 8f, -1, true, -1f);
          if (num2 == 3)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_01@", "base_b", 8f, -1, true, -1f);
          if (num2 == 4)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_01@", "base_c", 8f, -1, true, -1f);
        }
        if (num1 == 2)
        {
          int num2 = random.Next(1, 4);
          if (num2 == 1)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_02@", "base", 8f, -1, true, -1f);
          if (num2 == 2)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_02@", "base_a", 8f, -1, true, -1f);
          if (num2 == 3)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_02@", "base_b", 8f, -1, true, -1f);
          if (num2 == 4)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_02@", "base_c", 8f, -1, true, -1f);
        }
        if (num1 == 3)
        {
          int num2 = random.Next(1, 4);
          if (num2 == 1)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_03@", "base", 8f, -1, true, -1f);
          if (num2 == 2)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_03@", "base_a", 8f, -1, true, -1f);
          if (num2 == 3)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_03@", "base_b", 8f, -1, true, -1f);
          if (num2 == 4)
            p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_03@", "base_c", 8f, -1, true, -1f);
        }
        if (num1 == 4)
          p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_05@", "base", 8f, -1, true, -1f);
        if (num1 == 5)
          p.Task.PlayAnimation("anim@amb@yacht@jacuzzi@seated@male@variation_05@", "base", 8f, -1, true, -1f);
      }
      this.Peds.Add(p);
      p = (Ped) null;
    }

    public float GetRoationalAxis()
    {
      Vector3 rotation = this.Base.Rotation;
      return 0.0f;
    }

    public void OnTick(object sender, EventArgs e)
    {
      if (this.ChangePosPool != null && this.ChangePosPool.IsAnyMenuOpen())
        this.ChangePosPool.ProcessMenus();
      if (this.Woredrobepool != null && this.Woredrobepool.IsAnyMenuOpen())
        this.Woredrobepool.ProcessMenus();
      this.OnKeyDown();
      if (this.DrinksPool != null && this.DrinksPool.IsAnyMenuOpen())
        this.DrinksPool.ProcessMenus();
      foreach (Vector3 radioPo in this.RadioPos)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, radioPo) < 80.0)
          World.DrawMarker(MarkerType.VerticalCylinder, radioPo, Vector3.Zero, Vector3.Zero, new Vector3(0.4f, 0.4f, 0.3f), Color.Yellow);
        if ((double) World.GetDistance(Game.Player.Character.Position, radioPo) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to turn Radio On/Off, ~INPUT_COVER~ to change station");
        if ((double) World.GetDistance(Game.Player.Character.Position, radioPo) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if (this.RadioOn)
          {
            this.RadioOn = false;
            Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
            Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
          }
          else if (!this.RadioOn)
          {
            this.CurrentRadio = Game.Player.Character.Position;
            Vector3 position = Game.Player.Character.Position;
            this.CurrentInt = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z);
            this.Z_min = Game.Player.Character.Position.Z - 7f;
            this.Z_max = Game.Player.Character.Position.Z + 7f;
            this.RadioOn = true;
            Function.Call(Hash._0xA619B168B8A8570F, (InputArgument) 1);
            Function.Call(Hash._0x1098355A16064BB3, (InputArgument) true);
          }
        }
      }
      if (this.RadioOn)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentRadio) > 150.0)
        {
          UI.Notify("Radio Off, due to Player being to far away from Radio");
          this.RadioOn = false;
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
          Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
        }
        Vector3 position = Game.Player.Character.Position;
        if ((double) position.Z > (double) this.Z_max || (double) position.Z < (double) this.Z_min)
        {
          UI.Notify("Radio Off, due to Player Height, being too low or too High");
          this.RadioOn = false;
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
          Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
        }
        if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) != Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) this.CurrentRadio.X, (InputArgument) this.CurrentRadio.Y, (InputArgument) this.CurrentRadio.Z))
        {
          UI.Notify("Radio Off, due to exiting Interior");
          this.RadioOn = false;
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
          Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          UI.Notify("Radio Off, due to being in Vehicle");
          this.RadioOn = false;
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
          Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
        }
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) true);
      }
      if ((Entity) this.Base != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.YachtPos[this.Location]) < 200.0)
        Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
      float num1;
      if (this.ShowDistWhenClose && (double) World.GetDistance(Game.Player.Character.Position, this.YachtPos[this.Location]) < (double) (this.SpawnDist + 200) && (double) World.GetDistance(Game.Player.Character.Position, this.YachtPos[this.Location]) > (double) this.SpawnDist)
      {
        string[] strArray = new string[5]
        {
          "Distance to Yacht ~b~",
          null,
          null,
          null,
          null
        };
        num1 = World.GetDistance(Game.Player.Character.Position, this.YachtPos[this.Location]);
        strArray[1] = num1.ToString();
        strArray[2] = "m ~w~, Dist to spawn :~b~";
        strArray[3] = this.SpawnDist.ToString();
        strArray[4] = "m~w~";
        this.DisplayHelpTextThisFrameNoSound(string.Concat(strArray));
      }
      if (this.Purchased == 1)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2000f, 2000f, 1000f)) < 2.0)
          this.Reset();
        if ((Entity) this.Base != (Entity) null)
        {
          if (this.ShowTestBlips)
          {
            if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeBPos) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.WoredrobeBPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Pink);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeCPos) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.WoredrobeCPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Purple);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeAPos) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.WoredrobeAPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Lime);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.SeaSharkPosA) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.SeaSharkPosA, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.SeaSharkPosB) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.SeaSharkPosB, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.SeaSharkPosC) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.SeaSharkPosC, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.SeaSharkPosD) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.SeaSharkPosD, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.BoatAPos) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.BoatAPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.BoatBPos) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.BoatBPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.ShowerAPos) < 80.0)
            {
              World.DrawMarker(MarkerType.VerticalCylinder, this.ShowerAPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Yellow);
              World.DrawMarker(MarkerType.VerticalCylinder, this.ShowerAPosEnter, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Red);
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.ShowerBPos) < 80.0)
            {
              World.DrawMarker(MarkerType.VerticalCylinder, this.ShowerBPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Yellow);
              World.DrawMarker(MarkerType.VerticalCylinder, this.ShowerBPosEnter, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Red);
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.ShowerCPos) < 80.0)
            {
              World.DrawMarker(MarkerType.VerticalCylinder, this.ShowerCPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Yellow);
              World.DrawMarker(MarkerType.VerticalCylinder, this.ShowerCPosEnter, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Red);
            }
            if ((double) World.GetDistance(Game.Player.Character.Position, this.BarPos) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.BarPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Yellow);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.BarPos) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.BarPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Yellow);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.BarDrinkPos) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.BarDrinkPos, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed1) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.Bed1, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Green);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed2) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.Bed2, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed3) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.Bed3, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Yellow);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.HeliPosA) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.HeliPosA, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Red);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.HeliPosB) < 80.0 && this.MaxHelis != 1)
              World.DrawMarker(MarkerType.VerticalCylinder, this.HeliPosB, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Red);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.jacuzziSeat1) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.jacuzziSeat1, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Yellow);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.jacuzziSeat2) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.jacuzziSeat2, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Red);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.jacuzziSeat3) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.jacuzziSeat3, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.jacuzziSeat4) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.jacuzziSeat4, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Green);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.jacuzziSeat5) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.jacuzziSeat5, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Purple);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.jacuzziSeat6) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.jacuzziSeat6, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.YellowGreen);
            if ((Entity) this.DoorC != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.DoorC.Position) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.DoorC.Position, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Blue);
            if ((Entity) this.DoorB != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.DoorB.Position) < 80.0)
              World.DrawMarker(MarkerType.VerticalCylinder, this.DoorB.Position, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.Red);
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, this.ChangeLocMarker) < 80.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.ChangeLocMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.6f, 0.6f, 0.4f), Color.FromArgb(0, 147, (int) byte.MaxValue));
          if ((double) World.GetDistance(Game.Player.Character.Position, this.BarEnter) < 80.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.BarEnter, Vector3.Zero, Vector3.Zero, new Vector3(0.6f, 0.6f, 0.4f), Color.FromArgb(0, 147, (int) byte.MaxValue));
          if ((double) World.GetDistance(Game.Player.Character.Position, this.BarExit) < 80.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.BarExit, Vector3.Zero, Vector3.Zero, new Vector3(0.6f, 0.6f, 0.4f), Color.FromArgb(0, 147, (int) byte.MaxValue));
          if ((double) World.GetDistance(Game.Player.Character.Position, this.CaptinsQuartersEnter) < 80.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.CaptinsQuartersEnter, Vector3.Zero, Vector3.Zero, new Vector3(0.6f, 0.6f, 0.4f), Color.FromArgb(0, 147, (int) byte.MaxValue));
          if ((double) World.GetDistance(Game.Player.Character.Position, this.CaptinsQuartersExit) < 80.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.CaptinsQuartersExit, Vector3.Zero, Vector3.Zero, new Vector3(0.6f, 0.6f, 0.4f), Color.FromArgb(0, 147, (int) byte.MaxValue));
          if ((double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) < 80.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.MenuMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.6f, 0.6f, 0.4f), Color.FromArgb(0, 147, (int) byte.MaxValue));
          if ((double) World.GetDistance(Game.Player.Character.Position, this.BarDrinkPos) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to buy a drink");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.ShowerAPos) < 3.0 || (double) World.GetDistance(Game.Player.Character.Position, this.ShowerBPos) < 3.0 || (double) World.GetDistance(Game.Player.Character.Position, this.ShowerCPos) < 3.0)
          {
            if (this.InShower)
              this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get out of shower");
            if (!this.InShower)
              this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to take a shower");
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, this.jacuzziSeat1) < 4.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to sit in Jacuzzi ");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.ChangeLocMarker) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to Open Menu to Change Location of Yacht ");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.BarEnter) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to Enter Bar and Lounge Area ");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.BarExit) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to Exit Bar and Lounge Area ");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.CaptinsQuartersEnter) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to Enter Captain's Quarters ");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.CaptinsQuartersExit) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to Exit Captain's Quarters ");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to Open the Business Menu ");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed1) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to Sleep");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed2) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to Sleep");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed3) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sleep");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeAPos) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to access Wardrobe");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeBPos) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~  to access Wardrobe");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeCPos) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to access Wardrobe");
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.YachtPos[this.Location]) < 750.0)
        {
          if ((Entity) this.BoatA != (Entity) null && !((Entity) this.BoatA.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character))
            this.BoatA.FreezePosition = false;
          if ((Entity) this.BoatB != (Entity) null && !((Entity) this.BoatB.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character))
            this.BoatB.FreezePosition = false;
          if ((Entity) this.SeaSharkA != (Entity) null && !((Entity) this.SeaSharkA.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character))
            this.SeaSharkA.FreezePosition = false;
          if ((Entity) this.SeaSharkB != (Entity) null && !((Entity) this.SeaSharkB.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character))
            this.SeaSharkB.FreezePosition = false;
          if ((Entity) this.SeaSharkC != (Entity) null && !((Entity) this.SeaSharkC.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character))
            this.SeaSharkC.FreezePosition = false;
          if ((Entity) this.SeaSharkD != (Entity) null && !((Entity) this.HeliA.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character))
            this.SeaSharkD.FreezePosition = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.YachtPos[this.Location]) > (double) this.SpawnDist && this.Created)
          this.Delete();
        if ((double) World.GetDistance(Game.Player.Character.Position, this.YachtPos[this.Location]) < (double) this.SpawnDist)
        {
          if (!this.Created)
          {
            if (!this.DeletedYacht)
            {
              if ((Entity) this.HeliA != (Entity) null)
                this.HeliA.Delete();
              if ((Entity) this.HeliB != (Entity) null)
                this.HeliB.Delete();
              this.DoorA = (Prop) null;
              this.DoorB = (Prop) null;
              this.DoorC = (Prop) null;
              this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
              string str1 = this.YachtHashs[this.Location];
              string str2 = this.YachtHashs2[this.Location];
              Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) str1);
              Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) str2);
              if (Function.Call<bool>(Hash._0x88A741E44A2B3495, (InputArgument) str1))
              {
                if (Function.Call<bool>(Hash._0x88A741E44A2B3495, (InputArgument) str2))
                  this.DeletedYacht = true;
              }
            }
            if (this.DeletedYacht)
            {
              string str1 = this.YachtHashs[this.Location];
              string str2 = this.YachtHashs2[this.Location];
              Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) str1);
              Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) str2);
              Script.Wait(500);
              this.Base = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) this.YachtPos[this.Location].X, (InputArgument) this.YachtPos[this.Location].Y, (InputArgument) this.YachtPos[this.Location].Z, (InputArgument) 25f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "apa_mp_apa_yacht"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
              if ((Entity) this.Base != (Entity) null)
              {
                this.Foundyacht = false;
                this.Created = true;
                Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Base, (InputArgument) this.ShipColor);
              }
            }
          }
          if (this.Created)
          {
            if (!this.Foundyacht)
            {
              try
              {
                if (this.Location != 37)
                {
                  try
                  {
                    string str1 = this.YachtHashs[this.Location];
                    string str2 = this.YachtHashs2[this.Location];
                    Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) str1);
                    Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) str2);
                    Script.Wait(500);
                    this.Base = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) this.YachtPos[this.Location].X, (InputArgument) this.YachtPos[this.Location].Y, (InputArgument) this.YachtPos[this.Location].Z, (InputArgument) 25f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "apa_mp_apa_yacht"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
                  }
                  catch
                  {
                    UI.Notify("1");
                  }
                  try
                  {
                    if ((Entity) this.Base != (Entity) null)
                    {
                      this.Foundyacht = false;
                      this.Created = true;
                      Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Base, (InputArgument) this.ShipColor);
                    }
                  }
                  catch
                  {
                    UI.Notify("2");
                  }
                  try
                  {
                    if ((Entity) this.Base == (Entity) null)
                    {
                      UI.Notify("Test Case Scenario Failed, Trying Again");
                      Prop[] nearbyProps = World.GetNearbyProps(this.YachtPos[this.Location], 50f, this.RequestModel(1338692320));
                      if (nearbyProps.Length != 0)
                      {
                        foreach (Prop prop in nearbyProps)
                        {
                          if ((Entity) prop != (Entity) null)
                          {
                            this.Foundyacht = true;
                            this.Created = true;
                            this.Base = prop;
                            if ((Entity) this.Base != (Entity) null)
                              Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Base, (InputArgument) this.ShipColor);
                          }
                        }
                      }
                      if ((Entity) this.Base == (Entity) null)
                      {
                        UI.Notify("Test Case Scenario Failed, Trying Again (2)");
                        if (World.GetNearbyProps(this.YachtPos[this.Location], 100f).Length != 0)
                        {
                          foreach (Prop prop in nearbyProps)
                          {
                            if ((Entity) prop != (Entity) null && prop.Model == this.RequestModel(1338692320))
                            {
                              this.Foundyacht = true;
                              this.Created = true;
                              this.Base = prop;
                              if ((Entity) this.Base != (Entity) null)
                                Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Base, (InputArgument) this.ShipColor);
                            }
                          }
                        }
                      }
                    }
                  }
                  catch
                  {
                    UI.Notify("3");
                  }
                  try
                  {
                    if ((Entity) this.Base == (Entity) null)
                      UI.Notify("Test Case Scenario Failed, Yacht Base Could not be found!");
                  }
                  catch
                  {
                    UI.Notify("4");
                  }
                  if ((Entity) this.Base != (Entity) null)
                  {
                    try
                    {
                      if ((Entity) this.Base != (Entity) null)
                      {
                        this.PropYachtBase = this.Base;
                        UI.Notify("Test Case Scenario Succeeded");
                        this.SpawnYacht();
                      }
                    }
                    catch
                    {
                    }
                    this.Foundyacht = true;
                    if ((Entity) this.Base != (Entity) null)
                    {
                      try
                      {
                        this.ChangeYachtPositions();
                      }
                      catch
                      {
                        UI.Notify("6");
                      }
                      Script.Wait(500);
                      try
                      {
                        if (this.MaxHelis != 1)
                        {
                          if (this.H1 == 1)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Swift), this.HeliPosA);
                          if (this.H1 == 2)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Maverick), this.HeliPosA);
                          if (this.H1 == 3)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito), this.HeliPosA);
                          if (this.H1 == 4)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Volatus), this.HeliPosA);
                          if (this.H1 == 5)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito2), this.HeliPosA);
                          if (this.H1 == 6)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Swift2), this.HeliPosA);
                          if (this.H2 == 1)
                            this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Swift), this.HeliPosB);
                          if (this.H2 == 2)
                            this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Maverick), this.HeliPosB);
                          if (this.H2 == 3)
                            this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito), this.HeliPosB);
                          if (this.H2 == 4)
                            this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Volatus), this.HeliPosB);
                          if (this.H2 == 5)
                            this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito2), this.HeliPosB);
                          if (this.H2 == 6)
                            this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Swift2), this.HeliPosB);
                          if ((Entity) this.HeliA != (Entity) null)
                          {
                            this.HeliA.IsInvincible = true;
                            this.HeliA.Position = this.HeliPosA;
                            this.HeliA.Rotation = this.Base.Rotation;
                            this.HeliA.IsPersistent = true;
                            Vector3 rotation = this.HeliA.Rotation;
                            this.HeliA.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z - 90f);
                            Script.Wait(25);
                            this.HeliA.IsInvincible = false;
                          }
                          if ((Entity) this.HeliB != (Entity) null)
                          {
                            this.HeliB.Position = this.HeliPosB;
                            this.HeliB.IsInvincible = true;
                            this.HeliB.Rotation = this.Base.Rotation;
                            Vector3 rotation = this.HeliB.Rotation;
                            this.HeliB.IsPersistent = true;
                            this.HeliB.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z + 150f);
                            Script.Wait(25);
                            this.HeliB.IsInvincible = false;
                          }
                        }
                        else if (this.MaxHelis == 1)
                        {
                          if (this.H1 == 1)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Swift), this.HeliPosA);
                          if (this.H1 == 2)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Maverick), this.HeliPosA);
                          if (this.H1 == 3)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito), this.HeliPosA);
                          if (this.H1 == 4)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Volatus), this.HeliPosA);
                          if (this.H1 == 5)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito2), this.HeliPosA);
                          if (this.H1 == 6)
                            this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Swift2), this.HeliPosA);
                          if ((Entity) this.HeliA != (Entity) null)
                          {
                            this.HeliA.Position = this.HeliPosA;
                            this.HeliA.IsInvincible = true;
                            this.HeliA.Rotation = this.Base.Rotation;
                            this.HeliA.IsPersistent = true;
                            Vector3 rotation = this.HeliA.Rotation;
                            this.HeliA.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z - 90f);
                            Script.Wait(25);
                            this.HeliA.IsInvincible = false;
                          }
                        }
                        if ((Entity) this.BoatA != (Entity) null)
                          this.BoatA.Delete();
                        if ((Entity) this.BoatB != (Entity) null)
                          this.BoatB.Delete();
                        if ((Entity) this.SeaSharkA != (Entity) null)
                          this.SeaSharkA.Delete();
                        if ((Entity) this.SeaSharkB != (Entity) null)
                          this.SeaSharkB.Delete();
                        if ((Entity) this.SeaSharkC != (Entity) null)
                          this.SeaSharkC.Delete();
                        if ((Entity) this.SeaSharkD != (Entity) null)
                          this.SeaSharkD.Delete();
                        if (this.BoatAType != 0)
                        {
                          if (this.BoatAType == 1)
                            this.BoatA = World.CreateVehicle((Model) VehicleHash.Speeder, this.BoatAPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatAType == 2)
                            this.BoatA = World.CreateVehicle((Model) VehicleHash.Jetmax, this.BoatAPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatAType == 3)
                            this.BoatA = World.CreateVehicle((Model) VehicleHash.Dinghy, this.BoatAPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatAType == 4)
                            this.BoatA = World.CreateVehicle((Model) VehicleHash.Dinghy3, this.BoatAPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatAType == 5)
                            this.BoatA = World.CreateVehicle((Model) VehicleHash.Toro, this.BoatAPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatAType == 6)
                            this.BoatA = World.CreateVehicle((Model) VehicleHash.Toro2, this.BoatAPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatAType == 7)
                            this.BoatA = World.CreateVehicle((Model) VehicleHash.Marquis, this.BoatAPos, this.Base.Rotation.Z + 90f);
                        }
                        if (this.BoatBType != 0)
                        {
                          if (this.BoatBType == 1)
                            this.BoatB = World.CreateVehicle((Model) VehicleHash.Speeder, this.BoatBPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatBType == 2)
                            this.BoatB = World.CreateVehicle((Model) VehicleHash.Jetmax, this.BoatBPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatBType == 3)
                            this.BoatB = World.CreateVehicle((Model) VehicleHash.Dinghy, this.BoatBPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatBType == 4)
                            this.BoatB = World.CreateVehicle((Model) VehicleHash.Jetmax, this.BoatBPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatBType == 5)
                            this.BoatB = World.CreateVehicle((Model) VehicleHash.Toro, this.BoatBPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatBType == 6)
                            this.BoatB = World.CreateVehicle((Model) VehicleHash.Toro2, this.BoatBPos, this.Base.Rotation.Z + 90f);
                          if (this.BoatBType == 7)
                            this.BoatB = World.CreateVehicle((Model) VehicleHash.Marquis, this.BoatBPos, this.Base.Rotation.Z - 90f);
                        }
                        if (this.AmountOfSeaSharks != 0)
                        {
                          if (this.AmountOfSeaSharks >= 1)
                            this.SeaSharkA = World.CreateVehicle((Model) VehicleHash.Seashark, this.SeaSharkPosA, this.Base.Rotation.Z + 90f);
                          if (this.AmountOfSeaSharks >= 2)
                            this.SeaSharkB = World.CreateVehicle((Model) VehicleHash.Seashark, this.SeaSharkPosB, this.Base.Rotation.Z + 90f);
                          if (this.AmountOfSeaSharks >= 3)
                            this.SeaSharkC = World.CreateVehicle((Model) VehicleHash.Seashark, this.SeaSharkPosC, this.Base.Rotation.Z + 90f);
                          if (this.AmountOfSeaSharks >= 4)
                            this.SeaSharkD = World.CreateVehicle((Model) VehicleHash.Seashark, this.SeaSharkPosD, this.Base.Rotation.Z + 90f);
                        }
                        if ((Entity) this.BoatA != (Entity) null)
                          this.BoatA.FreezePosition = true;
                        if ((Entity) this.BoatB != (Entity) null)
                          this.BoatB.FreezePosition = true;
                        if ((Entity) this.SeaSharkA != (Entity) null)
                          this.SeaSharkA.FreezePosition = true;
                        if ((Entity) this.SeaSharkB != (Entity) null)
                          this.SeaSharkB.FreezePosition = true;
                        if ((Entity) this.SeaSharkC != (Entity) null)
                          this.SeaSharkC.FreezePosition = true;
                        if ((Entity) this.SeaSharkD != (Entity) null)
                          this.SeaSharkD.FreezePosition = true;
                      }
                      catch
                      {
                        UI.Notify("7");
                      }
                      try
                      {
                        this.AddPeds();
                      }
                      catch
                      {
                        UI.Notify("8");
                      }
                      try
                      {
                        UI.Notify("~b~ Finished Spawning In Yacht~w~");
                        if (this.WaitForCreated)
                        {
                          this.WaitForCreated = false;
                          Game.Player.Character.Position = this.YachtPos[this.Location];
                          Game.Player.Character.Position = this.ChangeLocMarker;
                        }
                      }
                      catch
                      {
                        UI.Notify("9");
                      }
                    }
                    if ((Entity) this.Base == (Entity) null)
                      UI.Notify("Test Case Scenario Failed");
                  }
                }
                if (this.Location == 37)
                {
                  string str1 = this.YachtHashs[this.Location];
                  string str2 = this.YachtHashs2[this.Location];
                  Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) str1);
                  Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) str2);
                  Script.Wait(500);
                  this.Base = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) this.YachtPos[this.Location].X, (InputArgument) this.YachtPos[this.Location].Y, (InputArgument) this.YachtPos[this.Location].Z, (InputArgument) 25f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "sum_mp_apa_yacht"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
                  if ((Entity) this.Base != (Entity) null)
                  {
                    this.Foundyacht = false;
                    this.Created = true;
                    Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Base, (InputArgument) this.ShipColor);
                  }
                  if ((Entity) this.Base == (Entity) null)
                  {
                    UI.Notify("Test Case Scenario Failed, Trying Again");
                    Prop[] nearbyProps = World.GetNearbyProps(this.YachtPos[this.Location], 50f, this.RequestModel(1338692320));
                    if (nearbyProps.Length != 0)
                    {
                      foreach (Prop prop in nearbyProps)
                      {
                        if ((Entity) prop != (Entity) null)
                        {
                          this.Foundyacht = true;
                          this.Created = true;
                          this.Base = prop;
                          if ((Entity) this.Base != (Entity) null)
                            Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Base, (InputArgument) this.ShipColor);
                        }
                      }
                    }
                    if ((Entity) this.Base == (Entity) null)
                    {
                      UI.Notify("Test Case Scenario Failed, Trying Again (2)");
                      if (World.GetNearbyProps(this.YachtPos[this.Location], 100f).Length != 0)
                      {
                        foreach (Prop prop in nearbyProps)
                        {
                          if ((Entity) prop != (Entity) null && prop.Model == this.RequestModel(1338692320))
                          {
                            this.Foundyacht = true;
                            this.Created = true;
                            this.Base = prop;
                            if ((Entity) this.Base != (Entity) null)
                              Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Base, (InputArgument) this.ShipColor);
                          }
                        }
                      }
                    }
                  }
                  if ((Entity) this.Base == (Entity) null)
                    UI.Notify("Test Case Scenario Failed, Yacht Base Could not be found!");
                  if ((Entity) this.Base != (Entity) null)
                  {
                    if ((Entity) this.Base != (Entity) null)
                    {
                      this.PropYachtBase = this.Base;
                      UI.Notify("Test Case Scenario Succeeded");
                      this.SpawnYacht();
                    }
                    this.Foundyacht = true;
                    if ((Entity) this.Base != (Entity) null)
                    {
                      this.ChangeYachtPositions();
                      Script.Wait(500);
                      if (this.MaxHelis != 1)
                      {
                        if (this.H1 == 1)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Swift), this.HeliPosA);
                        if (this.H1 == 2)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Maverick), this.HeliPosA);
                        if (this.H1 == 3)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito), this.HeliPosA);
                        if (this.H1 == 4)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Volatus), this.HeliPosA);
                        if (this.H1 == 5)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito2), this.HeliPosA);
                        if (this.H1 == 6)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Swift2), this.HeliPosA);
                        if (this.H2 == 1)
                          this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Swift), this.HeliPosB);
                        if (this.H2 == 2)
                          this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Maverick), this.HeliPosB);
                        if (this.H2 == 3)
                          this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito), this.HeliPosB);
                        if (this.H2 == 4)
                          this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Volatus), this.HeliPosB);
                        if (this.H2 == 5)
                          this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito2), this.HeliPosB);
                        if (this.H2 == 6)
                          this.HeliB = World.CreateVehicle(this.RequestModel(VehicleHash.Swift2), this.HeliPosB);
                        if ((Entity) this.HeliA != (Entity) null)
                        {
                          this.HeliA.IsInvincible = true;
                          this.HeliA.Position = this.HeliPosA;
                          this.HeliA.Rotation = this.Base.Rotation;
                          this.HeliA.IsPersistent = true;
                          Vector3 rotation = this.HeliA.Rotation;
                          this.HeliA.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z - 90f);
                          Script.Wait(25);
                          this.HeliA.IsInvincible = false;
                        }
                        if ((Entity) this.HeliB != (Entity) null)
                        {
                          this.HeliB.Position = this.HeliPosB;
                          this.HeliB.IsInvincible = true;
                          this.HeliB.Rotation = this.Base.Rotation;
                          Vector3 rotation = this.HeliB.Rotation;
                          this.HeliB.IsPersistent = true;
                          this.HeliB.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z + 150f);
                          Script.Wait(25);
                          this.HeliB.IsInvincible = false;
                        }
                      }
                      else if (this.MaxHelis == 1)
                      {
                        if (this.H1 == 1)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Swift), this.HeliPosA);
                        if (this.H1 == 2)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Maverick), this.HeliPosA);
                        if (this.H1 == 3)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito), this.HeliPosA);
                        if (this.H1 == 4)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Volatus), this.HeliPosA);
                        if (this.H1 == 5)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Supervolito2), this.HeliPosA);
                        if (this.H1 == 6)
                          this.HeliA = World.CreateVehicle(this.RequestModel(VehicleHash.Swift2), this.HeliPosA);
                        if ((Entity) this.HeliA != (Entity) null)
                        {
                          this.HeliA.Position = this.HeliPosA;
                          this.HeliA.IsInvincible = true;
                          this.HeliA.Rotation = this.Base.Rotation;
                          this.HeliA.IsPersistent = true;
                          Vector3 rotation = this.HeliA.Rotation;
                          this.HeliA.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z - 90f);
                          Script.Wait(25);
                          this.HeliA.IsInvincible = false;
                        }
                      }
                      if ((Entity) this.BoatA != (Entity) null)
                        this.BoatA.Delete();
                      if ((Entity) this.BoatB != (Entity) null)
                        this.BoatB.Delete();
                      if ((Entity) this.SeaSharkA != (Entity) null)
                        this.SeaSharkA.Delete();
                      if ((Entity) this.SeaSharkB != (Entity) null)
                        this.SeaSharkB.Delete();
                      if ((Entity) this.SeaSharkC != (Entity) null)
                        this.SeaSharkC.Delete();
                      if ((Entity) this.SeaSharkD != (Entity) null)
                        this.SeaSharkD.Delete();
                      if (this.BoatAType != 0)
                      {
                        if (this.BoatAType == 1)
                          this.BoatA = World.CreateVehicle((Model) VehicleHash.Speeder, this.BoatAPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatAType == 2)
                          this.BoatA = World.CreateVehicle((Model) VehicleHash.Jetmax, this.BoatAPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatAType == 3)
                          this.BoatA = World.CreateVehicle((Model) VehicleHash.Dinghy, this.BoatAPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatAType == 4)
                          this.BoatA = World.CreateVehicle((Model) VehicleHash.Dinghy3, this.BoatAPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatAType == 5)
                          this.BoatA = World.CreateVehicle((Model) VehicleHash.Toro, this.BoatAPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatAType == 6)
                          this.BoatA = World.CreateVehicle((Model) VehicleHash.Toro2, this.BoatAPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatAType == 7)
                          this.BoatA = World.CreateVehicle((Model) VehicleHash.Marquis, this.BoatAPos, this.Base.Rotation.Z + 90f);
                      }
                      if (this.BoatBType != 0)
                      {
                        if (this.BoatBType == 1)
                          this.BoatB = World.CreateVehicle((Model) VehicleHash.Speeder, this.BoatBPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatBType == 2)
                          this.BoatB = World.CreateVehicle((Model) VehicleHash.Jetmax, this.BoatBPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatBType == 3)
                          this.BoatB = World.CreateVehicle((Model) VehicleHash.Dinghy, this.BoatBPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatBType == 4)
                          this.BoatB = World.CreateVehicle((Model) VehicleHash.Jetmax, this.BoatBPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatBType == 5)
                          this.BoatB = World.CreateVehicle((Model) VehicleHash.Toro, this.BoatBPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatBType == 6)
                          this.BoatB = World.CreateVehicle((Model) VehicleHash.Toro2, this.BoatBPos, this.Base.Rotation.Z + 90f);
                        if (this.BoatBType == 7)
                          this.BoatB = World.CreateVehicle((Model) VehicleHash.Marquis, this.BoatBPos, this.Base.Rotation.Z - 90f);
                      }
                      if (this.AmountOfSeaSharks != 0)
                      {
                        if (this.AmountOfSeaSharks >= 1)
                          this.SeaSharkA = World.CreateVehicle((Model) VehicleHash.Seashark, this.SeaSharkPosA, this.Base.Rotation.Z + 90f);
                        if (this.AmountOfSeaSharks >= 2)
                          this.SeaSharkB = World.CreateVehicle((Model) VehicleHash.Seashark, this.SeaSharkPosB, this.Base.Rotation.Z + 90f);
                        if (this.AmountOfSeaSharks >= 3)
                          this.SeaSharkC = World.CreateVehicle((Model) VehicleHash.Seashark, this.SeaSharkPosC, this.Base.Rotation.Z + 90f);
                        if (this.AmountOfSeaSharks >= 4)
                          this.SeaSharkD = World.CreateVehicle((Model) VehicleHash.Seashark, this.SeaSharkPosD, this.Base.Rotation.Z + 90f);
                      }
                      if ((Entity) this.BoatA != (Entity) null)
                        this.BoatA.FreezePosition = true;
                      if ((Entity) this.BoatB != (Entity) null)
                        this.BoatB.FreezePosition = true;
                      if ((Entity) this.SeaSharkA != (Entity) null)
                        this.SeaSharkA.FreezePosition = true;
                      if ((Entity) this.SeaSharkB != (Entity) null)
                        this.SeaSharkB.FreezePosition = true;
                      if ((Entity) this.SeaSharkC != (Entity) null)
                        this.SeaSharkC.FreezePosition = true;
                      if ((Entity) this.SeaSharkD != (Entity) null)
                        this.SeaSharkD.FreezePosition = true;
                      this.AddPeds();
                      UI.Notify("~b~ Finished Spawning In Yacht~w~");
                      if (this.WaitForCreated)
                      {
                        this.WaitForCreated = false;
                        Game.Player.Character.Position = this.YachtPos[this.Location];
                        Game.Player.Character.Position = this.ChangeLocMarker;
                      }
                    }
                    if ((Entity) this.Base == (Entity) null)
                      UI.Notify("Test Case Scenario Failed");
                  }
                }
              }
              catch
              {
                UI.Notify("~r~ Error ~w~ Yacht Failed to Spawn!");
                this.Delete();
                this.Created = false;
              }
            }
          }
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.YachtPos[this.Location]) >= (double) this.SpawnDist && this.Created)
        {
          this.Delete();
          this.Created = false;
          if ((Entity) this.BoatA != (Entity) null)
          {
            if ((Entity) this.BoatA.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character)
            {
              this.BoatA.Delete();
            }
            else
            {
              this.BoatA.FreezePosition = false;
              this.BoatA.IsPersistent = false;
              this.BoatA = (Vehicle) null;
            }
          }
          if ((Entity) this.BoatB != (Entity) null)
          {
            if ((Entity) this.BoatB.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character)
            {
              this.BoatB.Delete();
            }
            else
            {
              this.BoatB.FreezePosition = false;
              this.BoatB.IsPersistent = false;
              this.BoatB = (Vehicle) null;
            }
          }
          if ((Entity) this.SeaSharkA != (Entity) null)
          {
            if ((Entity) this.SeaSharkA.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character)
            {
              this.SeaSharkA.Delete();
            }
            else
            {
              this.SeaSharkA.FreezePosition = false;
              this.SeaSharkA.IsPersistent = false;
              this.SeaSharkA = (Vehicle) null;
            }
          }
          if ((Entity) this.SeaSharkB != (Entity) null)
          {
            if ((Entity) this.SeaSharkB.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character)
            {
              this.SeaSharkB.Delete();
            }
            else
            {
              this.SeaSharkB.FreezePosition = false;
              this.SeaSharkB.IsPersistent = false;
              this.SeaSharkB = (Vehicle) null;
            }
          }
          if ((Entity) this.SeaSharkC != (Entity) null)
          {
            if ((Entity) this.SeaSharkC.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character)
            {
              this.SeaSharkC.Delete();
            }
            else
            {
              this.SeaSharkC.FreezePosition = false;
              this.SeaSharkC.IsPersistent = false;
              this.SeaSharkC = (Vehicle) null;
            }
          }
          if ((Entity) this.SeaSharkD != (Entity) null)
          {
            if ((Entity) this.HeliA.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character)
            {
              this.SeaSharkD.Delete();
            }
            else
            {
              this.SeaSharkD.FreezePosition = false;
              this.SeaSharkD.IsPersistent = false;
              this.SeaSharkD = (Vehicle) null;
            }
          }
          if ((Entity) this.HeliA != (Entity) null)
          {
            if ((Entity) this.HeliA.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character)
            {
              this.HeliA.Delete();
            }
            else
            {
              this.HeliA.IsPersistent = false;
              this.HeliA = (Vehicle) null;
            }
          }
          if ((Entity) this.HeliB != (Entity) null)
          {
            if ((Entity) this.HeliB.GetPedOnSeat(VehicleSeat.Driver) != (Entity) Game.Player.Character)
            {
              this.HeliB.Delete();
            }
            else
            {
              this.HeliB.IsPersistent = false;
              this.HeliB = (Vehicle) null;
            }
          }
          this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
          int location = this.Location;
          for (int index = 1; index < 37; ++index)
          {
            foreach (Prop prop in this.Props)
            {
              if ((Entity) prop != (Entity) null)
                prop.Delete();
            }
          }
        }
      }
      if (this.modMenuPool != null)
        this.modMenuPool.ProcessMenus();
      if (this.WarehouseCam != (Camera) null && this.WCamOn && !this.modMenuPool.IsAnyMenuOpen())
      {
        this.WCamOn = false;
        this.modMenuPool.CloseAllMenus();
        this.WarehouseCam.IsActive = false;
        this.WarehouseCam.Destroy();
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        Game.Player.Character.FreezePosition = false;
        Game.Player.Character.IsVisible = true;
        Game.Player.Character.Position = this.MenuMarker;
      }
      if ((Entity) this.VehicleMissioncar != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.VehicleMissioncar.Position) < 100.0)
        this.VehicleMissioncar.IsInvincible = false;
      if ((Entity) this.RentedVehicle != (Entity) null && this.startedRent)
      {
        if (this.RentalvehicleHealth != this.RentedVehicle.Health)
        {
          this.RentalvehicleHealth = this.RentedVehicle.Health;
          UI.Notify(this.GetHostName() + " That is a rental!, be more carefull, we get billed each time you damage it! ");
          if (Game.Player.Money >= 300)
            Game.Player.Money -= 300;
        }
        if (this.RentTimer != 0)
        {
          --this.RentTimer;
        }
        else
        {
          this.startedRent = false;
          UI.Notify(this.GetHostName() + " ok Boss, the Rent for that vehicle has expired");
          this.RentedVehicle.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(LeaveVehicleFlags.BailOut);
          this.RentedVehicle.LockStatus = VehicleLockStatus.Locked;
        }
      }
      if (this.checkforconvoy)
      {
        if (this.convoysetup == 1 || this.convoysetup == 2 || this.convoysetup == 3)
        {
          this.ConvoyBlip1.Position = this.Vehicle1.Position;
          this.ConvoyBlip2.Position = this.Vehicle2.Position;
          this.ConvoyBlip3.Position = this.Vehicle3.Position;
        }
        if ((this.convoysetup == 1 || this.convoysetup == 2) && (!this.Vehicle1.IsAlive && !this.Vehicle2.IsAlive) && !this.Vehicle3.IsAlive)
        {
          Game.FadeScreenOut(500);
          Script.Wait(500);
          if (this.ConvoyBlip1 != (Blip) null)
            this.ConvoyBlip1.Remove();
          if (this.ConvoyBlip2 != (Blip) null)
            this.ConvoyBlip2.Remove();
          if (this.ConvoyBlip3 != (Blip) null)
            this.ConvoyBlip3.Remove();
          if ((Entity) this.Vehicle1 != (Entity) null)
            this.Vehicle1.Delete();
          if ((Entity) this.Vehicle2 != (Entity) null)
            this.Vehicle2.Delete();
          if ((Entity) this.Vehicle3 != (Entity) null)
            this.Vehicle3.Delete();
          Script.Wait(500);
          Game.FadeScreenIn(500);
          this.stocksvalue = (float) ((double) this.stocksvalue + 750000.0 + 750000.0 * (double) this.profitMargin / 100.0);
          UI.Notify(this.GetHostName() + " Great convoy Destoryed");
          UI.Notify(this.GetHostName() + " Stocks just Increased");
          this.ShowIncrease();
          this.checkforconvoy = false;
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (this.convoysetup == 3 && !this.Vehicle1.IsAlive && (!this.Vehicle2.IsAlive && !this.Vehicle3.IsAlive))
        {
          Game.FadeScreenOut(500);
          Script.Wait(500);
          if (this.ConvoyBlip1 != (Blip) null)
            this.ConvoyBlip1.Remove();
          if (this.ConvoyBlip2 != (Blip) null)
            this.ConvoyBlip2.Remove();
          if (this.ConvoyBlip3 != (Blip) null)
            this.ConvoyBlip3.Remove();
          if ((Entity) this.Vehicle1 != (Entity) null)
            this.Vehicle1.Delete();
          if ((Entity) this.Vehicle2 != (Entity) null)
            this.Vehicle2.Delete();
          if ((Entity) this.Vehicle3 != (Entity) null)
            this.Vehicle3.Delete();
          Script.Wait(500);
          Game.FadeScreenIn(500);
          this.stocksvalue = (float) ((double) this.stocksvalue + 500000.0 + 500000.0 * (double) this.profitMargin / 100.0);
          UI.Notify(this.GetHostName() + " Great convoy Destoryed");
          UI.Notify(this.GetHostName() + " Stocks just Increased");
          this.ShowIncrease();
          this.checkforconvoy = false;
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
      }
      if (this.VehicleSetup)
      {
        if (this.Missionnum == 14)
        {
          if (!this.GotCar && this.VtoGet.IsAlive && this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
          {
            this.GotCar = true;
            System.Random random = new System.Random();
            if (random.Next(1, 100) < 20)
            {
              this.Dropzone = new Vector3(1737f, 3291f, 41f);
              this.DropzoneBlip = World.CreateBlip(this.Dropzone);
              this.DropzoneBlip.Name = "Drop Zone";
              this.DropzoneBlip.Sprite = BlipSprite.SpecialCargo;
              this.DropzoneBlip.Color = BlipColor.White;
              this.DropzoneBlip.Name = "Drop Zone";
            }
            if (random.Next(1, 100) > 20 && random.Next(1, 100) < 40)
            {
              this.Dropzone = new Vector3(141f, 6619f, 31f);
              this.DropzoneBlip = World.CreateBlip(this.Dropzone);
              this.DropzoneBlip.Name = "Drop Zone";
              this.DropzoneBlip.Sprite = BlipSprite.SpecialCargo;
              this.DropzoneBlip.Color = BlipColor.White;
              this.DropzoneBlip.Name = "Drop Zone";
            }
            if (random.Next(1, 100) > 40 && random.Next(1, 100) < 60)
            {
              this.Dropzone = new Vector3(2143f, 4801f, 41f);
              this.DropzoneBlip = World.CreateBlip(this.Dropzone);
              this.DropzoneBlip.Name = "Drop Zone";
              this.DropzoneBlip.Sprite = BlipSprite.SpecialCargo;
              this.DropzoneBlip.Color = BlipColor.White;
              this.DropzoneBlip.Name = "Drop Zone";
            }
            if (random.Next(1, 100) > 60 && random.Next(1, 100) < 80)
            {
              this.Dropzone = new Vector3(2817f, 1695f, 24f);
              this.DropzoneBlip = World.CreateBlip(this.Dropzone);
              this.DropzoneBlip.Name = "Drop Zone";
              this.DropzoneBlip.Sprite = BlipSprite.SpecialCargo;
              this.DropzoneBlip.Color = BlipColor.White;
              this.DropzoneBlip.Name = "Drop Zone";
            }
            if (random.Next(1, 100) > 80 && random.Next(1, 100) < 100)
            {
              this.Dropzone = new Vector3(-1154f, 2674f, 18f);
              this.DropzoneBlip = World.CreateBlip(this.Dropzone);
              this.DropzoneBlip.Name = "Drop Zone";
              this.DropzoneBlip.Sprite = BlipSprite.SpecialCargo;
              this.DropzoneBlip.Color = BlipColor.White;
              this.DropzoneBlip.Name = "Drop Zone";
            }
            if (this.DropzoneBlip != (Blip) null)
              this.DropzoneBlip.ShowRoute = true;
          }
          if (this.VtoGet.IsAlive)
          {
            if (this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
            {
              if (this.VtoGetBlip != (Blip) null)
                this.VtoGetBlip.Position = this.VtoGet.Position;
              if (this.VtoGet.IsDamaged)
                this.VehicleisDamaged = true;
              if (this.Vehiclehealth != this.VtoGet.Health)
              {
                this.Vehiclehealth = this.VtoGet.Health;
                this.stocksvalue = (float) ((int) this.stocksvalue - (int) this.stocksvalue / 100);
                UI.Notify(this.GetHostName() + " damaging the Mule, will decrease stock value, value : " + this.stocksvalue.ToString());
              }
              if ((double) World.GetDistance(Game.Player.Character.Position, this.Dropzone) < 5.0)
              {
                if ((Entity) this.VtoGet != (Entity) null)
                  this.VtoGet.Delete();
                if (this.VtoGetBlip != (Blip) null)
                  this.VtoGetBlip.Remove();
                if (this.DropzoneBlip != (Blip) null)
                  this.DropzoneBlip.Remove();
                this.VehicleSetup = false;
                this.Missionnum = 0;
                this.stocksvalue = (float) ((int) this.stocksvalue + (int) this.stocksvalue / new System.Random().Next(5, 10));
                Script.Wait(200);
                Game.Player.Money += (int) this.stocksvalue;
                this.stocksvalue = 0.0f;
                this.stockscount = 0;
                this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
                this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                this.Config.Save();
                UI.Notify(this.GetHostName() + " ok we got the delivery to the location, there is a little boost in there");
              }
              if ((double) World.GetDistance(Game.Player.Character.Position, this.Dropzone) < 5.0)
                World.DrawMarker(MarkerType.VerticalCylinder, this.Dropzone, Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 2f), Color.White);
            }
          }
          else
          {
            if ((Entity) this.VtoGet != (Entity) null)
              this.VtoGet.Delete();
            if (this.VtoGetBlip != (Blip) null)
              this.VtoGetBlip.Remove();
            if (this.DropzoneBlip != (Blip) null)
              this.DropzoneBlip.Remove();
            this.VehicleSetup = false;
            this.Missionnum = 0;
            this.stocksvalue = (float) ((int) this.stocksvalue - (int) this.stocksvalue / 2);
            Script.Wait(200);
            UI.Notify(this.GetHostName() + " What were you doing out there we just lost 50% of out stock!");
          }
        }
        if (this.ISinPiracyScamMission && this.Piracymission == 1 && (Entity) this.VtoGet != (Entity) null)
        {
          if (this.VtoGet.IsAlive)
          {
            float distance = World.GetDistance(Game.Player.Character.Position, this.VtoGet.Position);
            if ((double) World.GetDistance(Game.Player.Character.Position, this.GoPoint) < 1500.0)
            {
              if (!this.HackhasStarted)
              {
                UI.Notify(this.GetHostName() + " Ok Boss find the vehicle that is hacking into out system, watch out for erratic driving");
                this.HackhasStarted = true;
                this.VtoGet.CreateRandomPedOnSeat(VehicleSeat.Driver);
                this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.FleeFrom(Game.Player.Character);
              }
              if (this.HackhasStarted)
              {
                --this.TimerLeft;
                this.DisplayHelpTextThisFrame("Distance to vehicle : " + distance.ToString() + " Stocks to Lose : $ " + this.stocktoloose.ToString() + " Time to finish : " + this.TimerLeft.ToString());
                if (this.StockTimer != 24)
                  ++this.StockTimer;
                else if (this.StockTimer == 24)
                {
                  this.StockTimer = 0;
                  this.stocktoloose += 2500f;
                }
                if (this.StockTimer2 != 90)
                  ++this.StockTimer2;
                else if (this.StockTimer2 == 90)
                {
                  this.StockTimer2 = 0;
                  if ((Entity) this.VtoGet != (Entity) null && this.VtoGetBlip != (Blip) null)
                    this.VtoGetBlip.Position = this.VtoGet.Position;
                }
              }
            }
            if (this.TimerLeft == 0 && this.HackhasStarted)
            {
              if ((Entity) this.VtoGet != (Entity) null)
                this.VtoGet.Delete();
              if (this.VtoGetBlip != (Blip) null)
                this.VtoGetBlip.Remove();
              this.VehicleSetup = false;
              this.HackhasStarted = false;
              this.ISinPiracyScamMission = false;
              this.Piracymission = 0;
              this.TimerLeft = 0;
              Script.Wait(200);
              this.stocksvalue -= this.stocktoloose;
              this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
              this.Config.Save();
              new MissionScreen().SetFail("The Piracy Scam", 1000000, "The Hacker has escaped");
              UI.Notify(this.GetHostName() + " the hacker has escaped! we lost :$" + this.stocktoloose.ToString("N"));
            }
            if ((double) distance > 1500.0 && this.HackhasStarted)
            {
              if ((Entity) this.VtoGet != (Entity) null)
                this.VtoGet.Delete();
              if (this.VtoGetBlip != (Blip) null)
                this.VtoGetBlip.Remove();
              this.VehicleSetup = false;
              this.HackhasStarted = false;
              this.ISinPiracyScamMission = false;
              this.Piracymission = 0;
              this.TimerLeft = 0;
              Script.Wait(200);
              this.stocksvalue -= this.stocktoloose;
              this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
              this.Config.Save();
              new MissionScreen().SetFail("The Piracy Scam", 1000000, "The Hacker has escaped");
              UI.Notify(this.GetHostName() + " the hacker has escaped! we lost :$" + this.stocktoloose.ToString("N"));
            }
          }
          else
          {
            if ((Entity) this.VtoGet != (Entity) null)
              this.VtoGet.Delete();
            if (this.VtoGetBlip != (Blip) null)
              this.VtoGetBlip.Remove();
            this.VehicleSetup = false;
            this.HackhasStarted = false;
            this.ISinPiracyScamMission = false;
            this.Piracymission = 0;
            this.TimerLeft = 0;
            Script.Wait(200);
            this.stocksvalue = num1 = this.stocksvalue - this.stocktoloose;
            this.stocksvalue = num1;
            new MissionScreen().SetPass("The Piracy Scam", 1000000, "The Player has died");
            UI.Notify(this.GetHostName() + " ok the hacker is dead, here is what we lost :  " + this.stocktoloose.ToString());
            Game.Player.Money += 1000000;
          }
        }
        if (this.Missionnum == 13 && (Entity) this.VtoGet != (Entity) null)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(241f, -979f, 29f)) < 100.0)
          {
            foreach (Ped guard in this.Guards)
            {
              Ped ped = guard;
              int num2 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) guard, (InputArgument) num2);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
              guard.Task.FightAgainst(Game.Player.Character);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped, (InputArgument) 1);
            }
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(213f, -936f, 24f)) < 3.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to enter 10 car garage");
          if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(227f, -1001f, -99f)) < 4.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to exit 10 car garage");
          if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(227f, -1001f, -100f)) < 40.0)
            World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(227f, -1001f, -100f), Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 1f), Color.White);
          if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(213f, -936f, 24f)) < 40.0)
            World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(213f, -936f, 23f), Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), Color.White);
          if (this.VtoGet.IsAlive && this.VtoGet1.IsAlive && (this.VtoGet2.IsAlive && this.VtoGet3.IsAlive))
          {
            if (this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).IsPlayer || this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).IsPlayer || (this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).IsPlayer || this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).IsPlayer) || this.Vehiclesleft == 0)
            {
              if (!this.GotCar)
              {
                this.GotCar = true;
                UI.Notify(this.GetHostName() + " Nice bro! you got the car now bring it back to the Combined Vehicle Storage");
              }
              double distance = (double) World.GetDistance(Game.Player.Character.Position, new Vector3(-1158f, 287f, 67f));
              if ((double) World.GetDistance(Game.Player.Character.Position, this.LotLoc) < 40.0)
              {
                if (this.Vehiclesleft == 0)
                {
                  int num2 = 7590000;
                  if (this.VtoGet.IsDamaged)
                    num2 -= 750000;
                  if (this.VtoGet1.IsDamaged)
                    num2 -= 750000;
                  if (this.VtoGet2.IsDamaged)
                    num2 -= 750000;
                  if (this.VtoGet3.IsDamaged)
                    num2 -= 750000;
                  Game.Player.Money += num2;
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
                  foreach (Ped guard in this.Guards)
                  {
                    if ((Entity) guard != (Entity) null)
                      guard.Delete();
                  }
                  this.VehicleSetup = false;
                  this.Missionnum = 0;
                  Script.Wait(200);
                  new MissionScreen().SetPass("Electircal Discharge", 7590000, "One of the cars was destroyed");
                  UI.Notify(this.GetHostName() + " We got the pickup, nice driving out there");
                }
                else
                {
                  if (this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
                  {
                    this.VtoGet.Position = new Vector3(253f, -3058f, 5f);
                    this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(LeaveVehicleFlags.WarpOut);
                    this.VtoGet.LockStatus = VehicleLockStatus.Locked;
                    this.VtoGet.Rotation = new Vector3(0.0f, 0.0f, 46f);
                    Game.Player.Character.Position = new Vector3(247f, -3058f, 6f);
                    Script.Wait(1000);
                    --this.Vehiclesleft;
                    UI.Notify(this.GetHostName() + " Nice boss thats one down, " + this.Vehiclesleft.ToString() + " to go");
                  }
                  if (this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
                  {
                    this.VtoGet1.Position = new Vector3(250f, -3061f, 5f);
                    this.VtoGet1.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(LeaveVehicleFlags.WarpOut);
                    this.VtoGet1.LockStatus = VehicleLockStatus.Locked;
                    this.VtoGet1.Rotation = new Vector3(0.0f, 0.0f, 46f);
                    Game.Player.Character.Position = new Vector3(247f, -3058f, 6f);
                    Script.Wait(1000);
                    --this.Vehiclesleft;
                    UI.Notify(this.GetHostName() + " Nice boss thats one down, " + this.Vehiclesleft.ToString() + " to go");
                  }
                  if (this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
                  {
                    this.VtoGet2.Position = new Vector3(247f, -3063f, 5f);
                    this.VtoGet2.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(LeaveVehicleFlags.WarpOut);
                    this.VtoGet2.LockStatus = VehicleLockStatus.Locked;
                    this.VtoGet2.Rotation = new Vector3(0.0f, 0.0f, 46f);
                    Game.Player.Character.Position = new Vector3(247f, -3058f, 6f);
                    Script.Wait(1000);
                    --this.Vehiclesleft;
                    UI.Notify(this.GetHostName() + " Nice boss thats one down, " + this.Vehiclesleft.ToString() + " to go");
                  }
                  if (this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
                  {
                    this.VtoGet3.Position = new Vector3(245f, -3066f, 5f);
                    this.VtoGet3.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(LeaveVehicleFlags.WarpOut);
                    this.VtoGet3.LockStatus = VehicleLockStatus.Locked;
                    this.VtoGet3.Rotation = new Vector3(0.0f, 0.0f, 46f);
                    Game.Player.Character.Position = new Vector3(247f, -3058f, 6f);
                    Script.Wait(1000);
                    --this.Vehiclesleft;
                    UI.Notify(this.GetHostName() + " Nice boss thats one down, " + this.Vehiclesleft.ToString() + " to go");
                  }
                }
              }
            }
          }
          else
          {
            if ((Entity) this.VtoGet != (Entity) null)
              this.VtoGet.Delete();
            if (this.VtoGetBlip != (Blip) null)
              this.VtoGetBlip.Remove();
            foreach (Ped guard in this.Guards)
            {
              if ((Entity) guard != (Entity) null)
                guard.Delete();
            }
            this.VehicleSetup = false;
            this.Missionnum = 0;
            Script.Wait(200);
            new MissionScreen().SetFail("Electircal Discharge", 1000000, "One of the cars was destroyed");
            UI.Notify(this.GetHostName() + " ok we lost the car, the dealer will not be happy");
          }
        }
        if (this.Missionnum == 12 && (Entity) this.VtoGet != (Entity) null)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-1544f, 161f, 56f)) < 250.0 || (double) World.GetDistance(Game.Player.Character.Position, new Vector3(-1445f, 224f, 58f)) < 250.0 || (double) World.GetDistance(Game.Player.Character.Position, new Vector3(-1606f, 99f, 61f)) < 250.0)
          {
            foreach (Ped guard in this.Guards)
            {
              Ped ped = guard;
              int num2 = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "HATES_PLAYER");
              Function.Call(Hash._0xC80A74AC829DDD92, (InputArgument) guard, (InputArgument) num2);
              Function.Call(Hash._0x9F7794730795E019, (InputArgument) ped, (InputArgument) 0, (InputArgument) 0);
              Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) ped, (InputArgument) 1);
              guard.Task.FightAgainst(Game.Player.Character);
              Function.Call(Hash._0x971D38760FBC02EF, (InputArgument) ped, (InputArgument) 1);
            }
          }
          if (this.VtoGet.IsAlive)
          {
            if (this.VtoGet.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
            {
              if (this.VtoGetBlip != (Blip) null)
                this.VtoGetBlip.Position = this.VtoGet.Position;
              if (!this.GotCar)
              {
                this.GotCar = true;
                UI.Notify(this.GetHostName() + " Nice bro! you got the car now bring it back to the Combined Vehicle Storage");
              }
              double distance = (double) World.GetDistance(Game.Player.Character.Position, new Vector3(-1158f, 287f, 67f));
              if ((double) World.GetDistance(Game.Player.Character.Position, this.LotLoc) < 40.0)
              {
                int num2 = 7590000;
                if (this.VtoGet.IsDamaged)
                  num2 -= 750000;
                Game.Player.Money += num2;
                if ((Entity) this.VtoGet != (Entity) null)
                  this.VtoGet.Delete();
                if (this.VtoGetBlip != (Blip) null)
                  this.VtoGetBlip.Remove();
                foreach (Ped guard in this.Guards)
                {
                  if ((Entity) guard != (Entity) null)
                    guard.Delete();
                }
                this.VehicleSetup = false;
                this.Missionnum = 0;
                Script.Wait(200);
                new MissionScreen().SetPass("ExPatriot", 7590000, "The Patriot was destroyed");
                UI.Notify(this.GetHostName() + " We got the pickup, nice driving out there");
              }
            }
          }
          else
          {
            if ((Entity) this.VtoGet != (Entity) null)
              this.VtoGet.Delete();
            if (this.VtoGetBlip != (Blip) null)
              this.VtoGetBlip.Remove();
            foreach (Ped guard in this.Guards)
            {
              if ((Entity) guard != (Entity) null)
                guard.Delete();
            }
            this.VehicleSetup = false;
            this.Missionnum = 0;
            Script.Wait(200);
            new MissionScreen().SetPass("ExPatriot", 7590000, "The Patriot was destroyed");
            UI.Notify(this.GetHostName() + " ok we lost the car, the dealer will not be happy");
          }
        }
        if (this.Missionnum == 11 && this.VehicleMissioncar.IsAlive)
        {
          if (this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
          {
            this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
            if (!this.TriggeredWanted)
            {
              Game.Player.WantedLevel = 4;
              this.TriggeredWanted = true;
            }
          }
          if ((Entity) this.VehicleMissioncar != (Entity) null)
            this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
          if (this.warnedplayer)
          {
            UI.Notify(this.GetHostName() + " ok boss bring the vehicle to its designated storage and we can sell it ");
            this.warnedplayer = false;
          }
          if (this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && (double) World.GetDistance(Game.Player.Character.Position, this.Dockloc) < 60.0)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
            {
              this.VehicleMissioncar.IsDriveable = false;
              this.Missionnum = 0;
              Game.FadeScreenOut(300);
              Script.Wait(300);
              this.DestoryVehicle.Remove();
              this.VehicleSetup = false;
              Script.Wait(400);
              this.VehicleMissioncar.Delete();
              Game.Player.Character.Position = this.Dockloc;
              Script.Wait(300);
              Game.FadeScreenIn(300);
            }
            this.stocksvalue = (float) ((double) this.stocksvalue + 325000.0 + 325000.0 * (double) this.profitMargin / 100.0);
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is in our possesion we will sell it when we get a chance ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
        }
        if (this.Missionnum == 10 && this.VehicleMissioncar.IsAlive)
        {
          if (this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
          {
            this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
            if (!this.TriggeredWanted)
            {
              Game.Player.WantedLevel = 4;
              this.TriggeredWanted = true;
            }
          }
          if ((Entity) this.VehicleMissioncar != (Entity) null)
            this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
          if (this.warnedplayer)
          {
            UI.Notify(this.GetHostName() + " ok boss bring the vehicle to its designated storage and we can sell it ");
            this.warnedplayer = false;
          }
          if (this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
            {
              this.VehicleMissioncar.IsDriveable = false;
              this.Missionnum = 0;
              Game.FadeScreenOut(300);
              Script.Wait(300);
              this.DestoryVehicle.Remove();
              this.VehicleSetup = false;
              Script.Wait(400);
              this.VehicleMissioncar.Delete();
              Game.Player.Character.Position = this.AircraftStorageLoc;
              Script.Wait(300);
              Game.FadeScreenIn(300);
            }
            this.stocksvalue = (float) ((double) this.stocksvalue + 425000.0 + 425000.0 * (double) this.profitMargin / 100.0);
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is in our possesion we will sell it when we get a chance ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
        }
        if (this.Missionnum == 9 && this.VehicleMissioncar.IsAlive)
        {
          if (this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
          {
            this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
            if (!this.TriggeredWanted)
            {
              Game.Player.WantedLevel = 4;
              this.TriggeredWanted = true;
            }
          }
          if ((Entity) this.VehicleMissioncar != (Entity) null)
            this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
          if (this.warnedplayer)
          {
            UI.Notify(this.GetHostName() + " ok boss bring the vehicle to its designated storage and we can sell it ");
            this.warnedplayer = false;
          }
          if (this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && (double) World.GetDistance(Game.Player.Character.Position, this.LotLoc) < 60.0)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
            {
              this.VehicleMissioncar.IsDriveable = false;
              this.Missionnum = 0;
              Game.FadeScreenOut(300);
              Script.Wait(300);
              this.DestoryVehicle.Remove();
              this.VehicleSetup = false;
              this.VehicleMissioncar.Delete();
              Game.Player.Character.Position = this.LotLoc;
              Script.Wait(300);
              Game.FadeScreenIn(300);
            }
            this.stocksvalue = (float) ((double) this.stocksvalue + 225000.0 + 225000.0 * (double) this.profitMargin / 100.0);
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is in our possesion we will sell it when we get a chance ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
        }
        if ((this.Missionnum == 7 || this.Missionnum == 6 || this.Missionnum == 8) && (Entity) this.VehicleMissioncar != (Entity) null)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.VehicleMissioncar.Position) < 500.0)
          {
            this.VehicleMissioncar.IsInvincible = false;
            this.VehicleMissioncar.IsVisible = true;
          }
          if ((double) World.GetDistance(Game.Player.Character.Position, this.VehicleMissioncar.Position) > 500.0)
          {
            this.VehicleMissioncar.IsInvincible = true;
            this.VehicleMissioncar.IsVisible = true;
          }
          if (this.VehicleMissioncar.IsAlive)
          {
            if (this.DestoryVehicle != (Blip) null && (Entity) this.VehicleMissioncar != (Entity) null)
              this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
            if (this.warnedplayer)
            {
              UI.Notify(this.GetHostName() + " ok boss bring the vehicle to its designated storage and we can sell it ");
              this.warnedplayer = false;
            }
            if (this.VehicleMissioncar.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
            {
              Vector3 destination = this.LotLoc;
              if (this.Missionnum == 7)
                destination = this.LotLoc;
              if (this.Missionnum == 6)
                destination = this.AircraftStorageLoc;
              if (this.Missionnum == 8)
                destination = this.Dockloc;
              if ((double) World.GetDistance(Game.Player.Character.Position, destination) < 60.0)
              {
                if (this.DestoryVehicle != (Blip) null)
                  this.DestoryVehicle.Remove();
                if ((Entity) this.VehicleMissioncar != (Entity) null)
                {
                  this.VehicleMissioncar.IsDriveable = false;
                  Game.FadeScreenOut(300);
                  Script.Wait(300);
                  this.VehicleSetup = false;
                  this.VehicleMissioncar.Delete();
                  Game.Player.Character.Position = destination;
                  Script.Wait(300);
                  Game.FadeScreenIn(300);
                }
                this.stocksvalue = (float) ((double) this.stocksvalue + 25000.0 + 25000.0 * (double) this.profitMargin / 100.0);
                UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is in our possesion we will sell it when we get a chance ");
                UI.Notify(this.GetHostName() + " Stocks just Increased");
                this.ShowIncrease();
                this.VehicleSetup = false;
                this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
                this.Config.Save();
              }
            }
          }
          else
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
            {
              this.VehicleMissioncar.IsDriveable = false;
              Game.FadeScreenOut(300);
              Script.Wait(300);
              this.VehicleSetup = false;
              this.VehicleMissioncar.Delete();
              Script.Wait(300);
              Game.FadeScreenIn(300);
            }
            UI.Notify(this.GetHostName() + " We lost the vehicle!, we will have to find another one! ");
            this.ShowIncrease();
            this.VehicleSetup = false;
          }
        }
        if (this.Missionnum == 5 && (Entity) this.VehicleMissioncar != (Entity) null)
          this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
        if (this.Missionnum == 5 && (Entity) this.VehicleMissioncar != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.VehicleMissioncar.Position) < 500.0)
        {
          this.VehicleMissioncar.IsInvincible = false;
          this.VehicleMissioncar.IsVisible = true;
        }
        if (this.Missionnum == 2 || this.Missionnum == 3)
          this.DestoryVehicle.Position = this.VehicleMissioncar.Position;
        if ((Entity) this.VehicleMissioncar != (Entity) null && !this.VehicleMissioncar.IsAlive)
        {
          if (this.Missionnum == 11)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
              this.VehicleMissioncar.Delete();
            Game.FadeScreenOut(500);
            Script.Wait(500);
            Script.Wait(500);
            Game.FadeScreenIn(500);
            UI.Notify(this.GetHostName() + " boss we needed that vehicle!, we will now have to do with out it ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.VehicleSetup = false;
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.Missionnum == 10)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
              this.VehicleMissioncar.Delete();
            Game.FadeScreenOut(500);
            Script.Wait(500);
            Script.Wait(500);
            Game.FadeScreenIn(500);
            UI.Notify(this.GetHostName() + " boss we needed that vehicle!, we will now have to do with out it ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.VehicleSetup = false;
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.Missionnum == 9)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            Game.FadeScreenOut(500);
            Script.Wait(500);
            this.VehicleMissioncar.Delete();
            Script.Wait(500);
            Game.FadeScreenIn(500);
            UI.Notify(this.GetHostName() + " boss we needed that vehicle!, we will now have to do with out it ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.VehicleSetup = false;
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.Missionnum == 5)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
              this.VehicleMissioncar.Delete();
            this.stocksvalue = (float) ((double) this.stocksvalue + 125000.0 + 125000.0 * (double) this.profitMargin / 100.0);
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is destoryed ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.VehicleSetup = false;
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.Missionnum == 4)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
              this.VehicleMissioncar.Delete();
            this.stocksvalue = (float) ((double) this.stocksvalue + 75000.0 + 75000.0 * (double) this.profitMargin / 100.0);
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is destoryed ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.VehicleSetup = false;
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.Missionnum == 3)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            this.stocksvalue = (float) ((double) this.stocksvalue + 50000.0 + 50000.0 * (double) this.profitMargin / 100.0);
            if ((Entity) this.VehicleMissioncar != (Entity) null)
              this.VehicleMissioncar.Delete();
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is destoryed ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.VehicleSetup = false;
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.Missionnum == 1)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
              this.VehicleMissioncar.Delete();
            this.stocksvalue = (float) ((double) this.stocksvalue + 25000.0 + 25000.0 * (double) this.profitMargin / 100.0);
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is destoryed ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.VehicleSetup = false;
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
          if (this.Missionnum == 2)
          {
            if (this.DestoryVehicle != (Blip) null)
              this.DestoryVehicle.Remove();
            if ((Entity) this.VehicleMissioncar != (Entity) null)
              this.VehicleMissioncar.Delete();
            this.stocksvalue = (float) ((double) this.stocksvalue + 25000.0 + 25000.0 * (double) this.profitMargin / 100.0);
            UI.Notify(this.GetHostName() + " ok good, the enemy vehicle is destoryed ");
            UI.Notify(this.GetHostName() + " Stocks just Increased");
            this.ShowIncrease();
            this.VehicleSetup = false;
            this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
            this.Config.Save();
          }
        }
      }
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
          UI.Notify(this.GetHostName() + " Boss that is the car we need, bring it back to the vehicle warehouse to sell it");
          this.foundvehicleyet = false;
          this.hasgotvehicle = true;
        }
      }
      if (!this.foundvehicleyet || !this.NewVehicleSourcing || (!((Entity) Game.Player.Character.CurrentVehicle != (Entity) null) || !(Game.Player.Character.CurrentVehicle.DisplayName == this.SourcedVehicle)))
        return;
      this.Vehicletoget = Game.Player.Character.CurrentVehicle;
      if (!this.Vehicletoget.GetPedOnSeat(VehicleSeat.Driver).IsPlayer || !this.foundvehicleyet)
        return;
      this.foundvehicleyet = true;
      this.Vehicletoget.IsDriveable = true;
      UI.Notify(this.GetHostName() + " Boss that is the car we need, bring it back to the vehicle warehouse to sell it");
      this.foundvehicleyet = false;
      this.hasgotvehicle = true;
    }

    public void ChangeYachtPositions()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
      if (!((Entity) this.Base != (Entity) null))
        return;
      this.MenuMarker = this.Base.GetOffsetInWorldCoords(this.MenuOffset);
      this.ChangeLocMarker = this.Base.GetOffsetInWorldCoords(this.CaptComputerOffset);
      this.SleepPos1 = new Vector3(0.0f, 0.0f, 0.0f);
      this.SleepPos2 = new Vector3(0.0f, 0.0f, 0.0f);
      if (this.YachtType == 0)
      {
        this.HeliPadAOffset = new Vector3(-51.5f, -1.999345f, 3f);
        this.HeliPadBOffset = new Vector3(-37.78258f, -1.999345f, -0.5f);
        this.MaxHelis = 1;
        this.HeliPosA = this.Base.GetOffsetInWorldCoords(this.HeliPadAOffset);
        this.HeliPosB = new Vector3(0.0f, 0.0f, 0.0f);
      }
      if (this.YachtType == 1)
      {
        this.HeliPadAOffset = new Vector3(-29.5f, -1.999345f, 6f);
        this.HeliPadBOffset = new Vector3(36f, -1.999345f, 4.5f);
        this.MaxHelis = 2;
        this.HeliPosA = this.Base.GetOffsetInWorldCoords(this.HeliPadAOffset);
        this.HeliPosB = this.Base.GetOffsetInWorldCoords(this.HeliPadBOffset);
      }
      if (this.YachtType == 2)
      {
        this.HeliPadAOffset = new Vector3(-29.5f, -1.999345f, 6f);
        this.HeliPadBOffset = new Vector3(36f, -1.999345f, 4.5f);
        this.MaxHelis = 2;
        this.HeliPosA = this.Base.GetOffsetInWorldCoords(this.HeliPadAOffset);
        this.HeliPosB = this.Base.GetOffsetInWorldCoords(this.HeliPadBOffset);
      }
      this.jacuzziSeat1 = this.Base.GetOffsetInWorldCoords(new Vector3(-49.5f, -1.999345f, -1.1f));
      this.jacuzziSeat2 = this.Base.GetOffsetInWorldCoords(new Vector3(-50f, -4f, -1.1f));
      this.jacuzziSeat3 = this.Base.GetOffsetInWorldCoords(new Vector3(-50f, 0.0f, -1.1f));
      this.jacuzziSeat4 = this.Base.GetOffsetInWorldCoords(new Vector3(-52f, 0.0f, -1.1f));
      this.jacuzziSeat5 = this.Base.GetOffsetInWorldCoords(new Vector3(-52f, -4f, -1.1f));
      this.jacuzziSeat6 = this.Base.GetOffsetInWorldCoords(new Vector3(-53f, -1.999345f, -1.1f));
      this.Bed1 = this.Base.GetOffsetInWorldCoords(new Vector3(27f, -4f, 0.0f));
      this.Bed2 = this.Base.GetOffsetInWorldCoords(new Vector3(19f, -6.5f, 0.0f));
      this.Bed3 = this.Base.GetOffsetInWorldCoords(new Vector3(0.0f, -2f, 0.0f));
      this.BarPos = this.Base.GetOffsetInWorldCoords(new Vector3(23.2f, -2.026101f, 2.5f));
      this.BarDrinkPos = this.Base.GetOffsetInWorldCoords(new Vector3(21.66955f, -2.026101f, 2.5f));
      Vector3 offset1 = new Vector3(31.5f, -6.5f, -0.5f);
      Vector3 offset2 = new Vector3(30.5f, -7.5f, -0.5f);
      this.ShowerAPos = this.Base.GetOffsetInWorldCoords(offset1);
      this.ShowerAPosEnter = this.Base.GetOffsetInWorldCoords(offset2);
      Vector3 offset3 = new Vector3(20.5f, 0.2f, -0.5f);
      Vector3 offset4 = new Vector3(19.5f, -1f, -0.5f);
      this.ShowerBPos = this.Base.GetOffsetInWorldCoords(offset3);
      this.ShowerBPosEnter = this.Base.GetOffsetInWorldCoords(offset4);
      Vector3 offset5 = new Vector3(8.5f, -1f, -0.5f);
      Vector3 offset6 = new Vector3(7f, -2.026101f, -0.5f);
      this.ShowerCPos = this.Base.GetOffsetInWorldCoords(offset5);
      this.ShowerCPosEnter = this.Base.GetOffsetInWorldCoords(offset6);
      this.BarEnter = this.Base.GetOffsetInWorldCoords(this.BackEntranceOffset);
      this.BarExit = this.Base.GetOffsetInWorldCoords(this.BackIntOffset);
      this.CaptinsQuartersEnter = this.Base.GetOffsetInWorldCoords(this.CaptEntranceOffset);
      this.CaptinsQuartersExit = this.Base.GetOffsetInWorldCoords(this.CaptIntOffset);
      this.SeaSharkPosA = this.Base.GetOffsetInWorldCoords(new Vector3(-62f, 1f, -5.6f));
      this.SeaSharkPosB = this.Base.GetOffsetInWorldCoords(new Vector3(-62f, -1f, -5.6f));
      this.SeaSharkPosC = this.Base.GetOffsetInWorldCoords(new Vector3(-62f, -3f, -5.6f));
      this.SeaSharkPosD = this.Base.GetOffsetInWorldCoords(new Vector3(-62f, -5f, -5.6f));
      this.BoatAPos = this.Base.GetOffsetInWorldCoords(new Vector3(-58f, -12f, -5.6f));
      this.BoatBPos = this.Base.GetOffsetInWorldCoords(new Vector3(-58f, 8f, -5.6f));
      this.ChangeLocMarker = this.Base.GetOffsetInWorldCoords(this.CaptComputerOffset);
      this.WoredrobeAPos = this.Base.GetOffsetInWorldCoords(new Vector3(23f, -4f, -0.5f));
      this.WoredrobeBPos = this.Base.GetOffsetInWorldCoords(new Vector3(17f, -6f, -0.5f));
      this.WoredrobeCPos = this.Base.GetOffsetInWorldCoords(new Vector3(-1f, -6f, -0.5f));
      if ((Entity) this.FlagA != (Entity) null)
        this.FlagA.Delete();
      if ((Entity) this.FlagB != (Entity) null)
        this.FlagB.Delete();
      if ((Entity) this.FlagC != (Entity) null)
        this.FlagC.Delete();
      if ((Entity) this.DoorC != (Entity) null)
        this.DoorC.Delete();
      if ((Entity) this.DoorB != (Entity) null)
        this.DoorB.Delete();
      if ((Entity) this.Bargirl != (Entity) null)
        this.Bargirl.Delete();
      if (this.DoorType == 0 && (Entity) this.Base != (Entity) null)
      {
        this.SpawnDoor("apa_mp_apa_yacht_door", this.Base.GetOffsetInWorldCoords(new Vector3(-1f, -1.996299f, 5.5f)), new Vector3(0.0f, 0.0f, this.Base.Rotation.Z - 90f), 4);
        this.SpawnDoor("apa_mp_apa_yacht_door", this.Base.GetOffsetInWorldCoords(new Vector3(-1f, -1.996299f, 5.5f)), new Vector3(0.0f, 0.0f, this.Base.Rotation.Z - 90f), 5);
      }
      if (this.DoorType == 1 && (Entity) this.Base != (Entity) null)
      {
        this.SpawnDoor("apa_mp_apa_yacht_door2", this.Base.GetOffsetInWorldCoords(new Vector3(-1f, -1.996299f, 5.5f)), new Vector3(0.0f, 0.0f, this.Base.Rotation.Z - 90f), 4);
        this.SpawnDoor("apa_mp_apa_yacht_door2", this.Base.GetOffsetInWorldCoords(new Vector3(-1f, -1.996299f, 5.5f)), new Vector3(0.0f, 0.0f, this.Base.Rotation.Z - 90f), 5);
      }
      if (this.CurrentFlag != 0)
      {
        this.SpawnFlagA(this.FlagList[this.CurrentFlag], this.Base.GetOffsetInWorldCoords(new Vector3(-3f, -0.45f, 9.8f)), new Vector3(0.0f, -50f, this.Base.Rotation.Z + 0.0f), 5);
        this.SpawnFlagB(this.FlagList[this.CurrentFlag], this.Base.GetOffsetInWorldCoords(new Vector3(-3f, -3.55f, 9.8f)), new Vector3(0.0f, -50f, this.Base.Rotation.Z + 0.0f), 5);
        this.SpawnFlagC(this.FlagList[this.CurrentFlag], this.Base.GetOffsetInWorldCoords(new Vector3(-56.5f, -1.996299f, 0.5f)), new Vector3(0.0f, -50f, this.Base.Rotation.Z - 0.0f), 5);
      }
      if ((Entity) this.DoorB != (Entity) null)
      {
        this.DoorB.Detach();
        this.DoorB.AttachTo((Entity) this.Base, 0, new Vector3(0.0f, -3.3f, 6.6f), new Vector3(0.0f, 0.0f, 90f));
        this.DoorB.HasCollision = true;
        this.Props.Add(this.DoorB);
        Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.DoorB, (InputArgument) this.ShipColor);
      }
      Script.Wait(1);
      if ((Entity) this.DoorC != (Entity) null)
      {
        this.DoorC.Detach();
        this.DoorC.AttachTo((Entity) this.Base, 0, new Vector3(0.0f, -0.6f, 6.6f), new Vector3(0.0f, 0.0f, -90f));
        this.DoorC.HasCollision = true;
        this.Props.Add(this.DoorC);
        Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.DoorC, (InputArgument) this.ShipColor);
      }
      this.RadioPos.Clear();
      this.RadioPos.Add(this.Base.GetOffsetInWorldCoords(new Vector3(27.5f, -8f, -0.5f)));
      this.RadioPos.Add(this.Base.GetOffsetInWorldCoords(new Vector3(12f, -1f, -0.5f)));
      this.RadioPos.Add(this.Base.GetOffsetInWorldCoords(new Vector3(4.5f, -1.5f, -0.5f)));
      this.RadioPos.Add(this.Base.GetOffsetInWorldCoords(new Vector3(3f, -2.2f, 2.8f)));
      this.RadioPos.Add(this.Base.GetOffsetInWorldCoords(new Vector3(5.2f, -4.1f, 2.8f)));
    }

    public void SpawnYacht()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Yacht.ini");
      for (int index = 1; index < 38; ++index)
      {
        if (index != this.Location)
        {
          foreach (Prop prop in this.Props)
          {
            if ((Entity) prop != (Entity) null)
              prop.Delete();
          }
        }
      }
      int location = this.Location;
      if (this.Location <= 0 || this.Location >= 38)
        return;
      if (this.YachtType == 0)
      {
        if (!this.GoldRails)
          this.Rail = "apa_mp_apa_yacht_o1_rail_a";
        else if (this.GoldRails)
          this.Rail = "apa_mp_apa_yacht_o1_rail_b";
        this.Rail = "apa_MP_Apa_Yacht_O1_Rail_B";
        this.YachtTop = "apa_mp_apa_yacht_option1";
        this.YachtLauncher = "apa_mp_apa_yacht_launcher_01a";
      }
      if (this.YachtType == 1)
      {
        if (!this.GoldRails)
          this.Rail = "apa_mp_apa_yacht_o2_rail_a";
        else if (this.GoldRails)
          this.Rail = "apa_mp_apa_yacht_o2_rail_b";
        this.YachtTop = "apa_mp_apa_yacht_option2";
        this.YachtLauncher = "apa_mp_apa_yacht_launcher_02a";
      }
      if (this.YachtType == 2)
      {
        if (!this.GoldRails)
          this.Rail = "apa_mp_apa_yacht_o3_rail_a";
        else if (this.GoldRails)
          this.Rail = "apa_mp_apa_yacht_o3_rail_b";
        this.YachtTop = "apa_mp_apa_yacht_option3";
        this.YachtLauncher = "apa_mp_apa_yacht_launcher_02a";
      }
      if (!((Entity) this.Base != (Entity) null))
        return;
      UI.Notify("~b~ Starting Yacht Spawning, please be patient");
      this.SpawnProp(this.YachtTop, this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 1);
      this.SpawnProp(this.Rail, this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 2);
      if (this.YachtType == 0)
      {
        if (this.Lighting == 1)
        {
          if (this.LightingColor == 1)
            this.SpawnProp("apa_mp_apa_y1_l1a", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 2)
            this.SpawnProp("apa_mp_apa_y1_l1b", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 3)
            this.SpawnProp("apa_mp_apa_y1_l1c", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 4)
            this.SpawnProp("apa_mp_apa_y1_l1d", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        }
        if (this.Lighting == 2)
        {
          if (this.LightingColor == 1)
            this.SpawnProp("apa_mp_apa_y1_l2a", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 2)
            this.SpawnProp("apa_mp_apa_y1_l2b", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 3)
            this.SpawnProp("apa_mp_apa_y1_l2c", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 4)
            this.SpawnProp("apa_mp_apa_y1_l2d", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        }
        if (this.DoorType == 0)
          this.SpawnProp("apa_mp_apa_yacht_door", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 6);
        if (this.DoorType == 1)
          this.SpawnProp("apa_mp_apa_yacht_door2", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 6);
        this.SpawnProp("apa_mp_apa_yacht_jacuzzi_ripple1", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 7);
        this.SpawnProp("apa_mp_apa_yacht_jacuzzi_ripple2", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 7);
      }
      if (this.YachtType == 1)
      {
        this.SpawnProp("apa_mp_apa_yacht_option2_cola", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 1);
        this.SpawnProp("apa_mp_apa_yacht_option2_colb", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 2);
        if (this.Lighting == 1)
        {
          if (this.LightingColor == 1)
            this.SpawnProp("apa_mp_apa_y2_l1a", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 2)
            this.SpawnProp("apa_mp_apa_y2_l1b", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 3)
            this.SpawnProp("apa_mp_apa_y2_l1c", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 4)
            this.SpawnProp("apa_mp_apa_y2_l1d", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        }
        if (this.Lighting == 2)
        {
          if (this.LightingColor == 1)
            this.SpawnProp("apa_mp_apa_y2_l2a", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 2)
            this.SpawnProp("apa_mp_apa_y2_l2b", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 3)
            this.SpawnProp("apa_mp_apa_y2_l2c", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
          if (this.LightingColor == 4)
            this.SpawnProp("apa_mp_apa_y2_l2d", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        }
        if (this.DoorType == 0)
          this.SpawnProp("apa_mp_apa_yacht_door", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 6);
        if (this.DoorType == 1)
          this.SpawnProp("apa_mp_apa_yacht_door2", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 6);
        this.SpawnProp("apa_mp_apa_yacht_jacuzzi_ripple1", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 7);
        this.SpawnProp("apa_mp_apa_yacht_jacuzzi_ripple2", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 7);
      }
      if (this.YachtType != 2)
        return;
      this.SpawnProp("apa_mp_apa_yacht_option3_cola", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 1);
      this.SpawnProp("apa_mp_apa_yacht_option3_colb", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 2);
      this.SpawnProp("apa_mp_apa_yacht_option3_colc", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 1);
      this.SpawnProp("apa_mp_apa_yacht_option3_cold", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 2);
      this.SpawnProp("apa_mp_apa_yacht_option3_cole", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 1);
      if (this.Lighting == 1)
      {
        if (this.LightingColor == 1)
          this.SpawnProp("apa_mp_apa_y3_l1a", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        if (this.LightingColor == 2)
          this.SpawnProp("apa_mp_apa_y3_l1b", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        if (this.LightingColor == 3)
          this.SpawnProp("apa_mp_apa_y3_l1c", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        if (this.LightingColor == 4)
          this.SpawnProp("apa_mp_apa_y3_l1d", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
      }
      if (this.Lighting == 2)
      {
        if (this.LightingColor == 1)
          this.SpawnProp("apa_mp_apa_y3_l2a", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        if (this.LightingColor == 2)
          this.SpawnProp("apa_mp_apa_y3_l2b", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        if (this.LightingColor == 3)
          this.SpawnProp("apa_mp_apa_y3_l2c", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
        if (this.LightingColor == 4)
          this.SpawnProp("apa_mp_apa_y3_l2d", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 3);
      }
      if (this.DoorType == 0)
        this.SpawnProp("apa_mp_apa_yacht_door", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 6);
      if (this.DoorType == 1)
        this.SpawnProp("apa_mp_apa_yacht_door2", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 6);
      this.SpawnProp("apa_mp_apa_yacht_jacuzzi_ripple1", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 7);
      this.SpawnProp("apa_mp_apa_yacht_jacuzzi_ripple2", this.YachtPos[this.Location], new Vector3(0.0f, 0.0f, 0.0f), 7);
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

    public void OnKeyDown()
    {
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
      if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeAPos) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
        this.WoredrobeMainMenu.Visible = !this.WoredrobeMainMenu.Visible;
      if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeBPos) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
        this.WoredrobeMainMenu.Visible = !this.WoredrobeMainMenu.Visible;
      if ((double) World.GetDistance(Game.Player.Character.Position, this.WoredrobeCPos) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
        this.WoredrobeMainMenu.Visible = !this.WoredrobeMainMenu.Visible;
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ShowerAPos) < 3.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if (!this.InShower)
        {
          this.SetPedOutfitCutscene("MP_1", Game.Player.Character);
          Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_fbi5a");
          Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_fbi5a");
          Function.Call(Hash._0x0D53A3B8DA0809D2, (InputArgument) "scr_fbi5_ped_water_splash", (InputArgument) Game.Player.Character, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) -0.5, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 1.0, (InputArgument) false, (InputArgument) false, (InputArgument) false);
          this.InShower = true;
          Game.Player.Character.Position = this.ShowerAPos;
          Game.Player.Character.FreezePosition = true;
          if (Game.Player.Character.Model == (Model) PedHash.Franklin || Game.Player.Character.Model == (Model) PedHash.Michael)
          {
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 26, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          }
          else
          {
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 16, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 16, (InputArgument) 17, (InputArgument) 1);
          }
          Game.Player.Character.Task.PlayAnimation("anim@mp_yacht@shower@male@", "male_shower_idle_a", 8f, -1, true, -1f);
        }
        else if (this.InShower)
        {
          this.InShower = false;
          Game.Player.Character.Position = this.ShowerAPosEnter;
          Game.Player.Character.FreezePosition = false;
          Game.Player.Character.Health = 500;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Game.Player.Character.Task.ClearAnimation("anim@mp_yacht@shower@male@", "male_shower_idle_a");
          Function.Call(Hash._0xB8FEAEEBCC127425, (InputArgument) Game.Player.Character);
          this.GetPedOutfitCutscene("MP_1", Game.Player.Character);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ShowerBPos) < 3.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if (!this.InShower)
        {
          this.SetPedOutfitCutscene("MP_1", Game.Player.Character);
          Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_fbi5a");
          Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_fbi5a");
          Function.Call(Hash._0x0D53A3B8DA0809D2, (InputArgument) "scr_fbi5_ped_water_splash", (InputArgument) Game.Player.Character, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) -0.5, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 1.0, (InputArgument) false, (InputArgument) false, (InputArgument) false);
          this.InShower = true;
          Game.Player.Character.Position = this.ShowerBPos;
          Game.Player.Character.FreezePosition = true;
          if (Game.Player.Character.Model == (Model) PedHash.Franklin || Game.Player.Character.Model == (Model) PedHash.Michael)
          {
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 26, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          }
          else
          {
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 16, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 16, (InputArgument) 17, (InputArgument) 1);
          }
          Game.Player.Character.Task.PlayAnimation("anim@mp_yacht@shower@male@", "male_shower_idle_a", 8f, -1, true, -1f);
        }
        else if (this.InShower)
        {
          this.InShower = false;
          Game.Player.Character.Position = this.ShowerBPosEnter;
          Game.Player.Character.FreezePosition = false;
          Game.Player.Character.Health = 500;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Game.Player.Character.Task.ClearAnimation("anim@mp_yacht@shower@male@", "male_shower_idle_a");
          Function.Call(Hash._0xB8FEAEEBCC127425, (InputArgument) Game.Player.Character);
          this.GetPedOutfitCutscene("MP_1", Game.Player.Character);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.ShowerCPos) < 3.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        if (!this.InShower)
        {
          this.SetPedOutfitCutscene("MP_1", Game.Player.Character);
          Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_fbi5a");
          Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_fbi5a");
          Function.Call(Hash._0x0D53A3B8DA0809D2, (InputArgument) "scr_fbi5_ped_water_splash", (InputArgument) Game.Player.Character, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) -0.5, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 1.0, (InputArgument) false, (InputArgument) false, (InputArgument) false);
          this.InShower = true;
          Game.Player.Character.Position = this.ShowerCPos;
          Game.Player.Character.FreezePosition = true;
          if (Game.Player.Character.Model == (Model) PedHash.Franklin || Game.Player.Character.Model == (Model) PedHash.Michael)
          {
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 26, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          }
          else
          {
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 16, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 16, (InputArgument) 17, (InputArgument) 1);
          }
          Game.Player.Character.Task.PlayAnimation("anim@mp_yacht@shower@male@", "male_shower_idle_a", 8f, -1, true, -1f);
        }
        else if (this.InShower)
        {
          this.InShower = false;
          Game.Player.Character.Position = this.ShowerCPosEnter;
          Game.Player.Character.FreezePosition = false;
          Game.Player.Character.Health = 500;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Game.Player.Character.Task.ClearAnimation("anim@mp_yacht@shower@male@", "male_shower_idle_a");
          Function.Call(Hash._0xB8FEAEEBCC127425, (InputArgument) Game.Player.Character);
          this.GetPedOutfitCutscene("MP_1", Game.Player.Character);
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.BarDrinkPos) < 2.0)
        this.DrinksMenu.Visible = !this.DrinksMenu.Visible;
      if (this.IsinHottub)
      {
        if (Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1) >= 1065353216)
        {
          this.AnimDict = "anim@amb@yacht@jacuzzi@seated@male@variation_0" + this.animtype.ToString() + "@";
          string str = "idle_a";
          int num = new System.Random().Next(0, 125);
          if (num < 25)
            str = "idle_a";
          if (num >= 25 && num < 50)
            str = "idle_b";
          if (num >= 50 && num < 75)
            str = "idle_c";
          if (num >= 75 && num < 100)
            str = "idle_d";
          if (num >= 100 && num < 124)
            str = "idle_e";
          Yacht.LoadDict(this.AnimDict);
          Vector3 jacuzziSeat1 = this.jacuzziSeat1;
          Ped character = Game.Player.Character;
          this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) jacuzziSeat1.X, (InputArgument) jacuzziSeat1.Y, (InputArgument) (jacuzziSeat1.Z + 0.25f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) character.Heading, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) character, (InputArgument) this.Scene1, (InputArgument) Yacht.LoadDict(this.AnimDict), (InputArgument) str, (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) character, (InputArgument) this.Scene1, (InputArgument) str, (InputArgument) Yacht.LoadDict(this.AnimDict), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) character.Rotation.Z, (InputArgument) 1148846080, (InputArgument) 0);
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.jacuzziSeat1) < 4.0)
      {
        if (!this.IsinHottub)
        {
          this.SetPedOutfitCutscene("MP_1", Game.Player.Character);
          Game.Player.Character.Position = this.jacuzziSeat1;
          Game.Player.Character.Rotation = new Vector3(0.0f, 0.0f, this.Base.Rotation.Z + 90f);
          Script.Wait(1);
          int num = new System.Random().Next(0, 125);
          if (num < 25)
            this.animtype = 1;
          if (num >= 25 && num < 50)
            this.animtype = 2;
          if (num >= 50 && num < 75)
            this.animtype = 3;
          if (num >= 75 && num < 100)
            this.animtype = 4;
          if (num >= 100 && num < 124)
            this.animtype = 5;
          this.AnimDict = "anim@amb@yacht@jacuzzi@seated@male@variation_0" + this.animtype.ToString() + "@";
          Yacht.LoadDict(this.AnimDict);
          Game.Player.Character.Position = this.jacuzziSeat1;
          Game.Player.Character.Rotation = new Vector3(0.0f, 0.0f, this.Base.Rotation.Z + 90f);
          Vector3 jacuzziSeat1 = this.jacuzziSeat1;
          Ped character = Game.Player.Character;
          this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) jacuzziSeat1.X, (InputArgument) jacuzziSeat1.Y, (InputArgument) (jacuzziSeat1.Z + 0.25f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) character.Heading, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) character, (InputArgument) this.Scene1, (InputArgument) Yacht.LoadDict(this.AnimDict), (InputArgument) "enter", (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) character, (InputArgument) this.Scene1, (InputArgument) "enter", (InputArgument) Yacht.LoadDict(this.AnimDict), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) character.Rotation.Z, (InputArgument) 1148846080, (InputArgument) 0);
          if (Game.Player.Character.Model == (Model) PedHash.Franklin || Game.Player.Character.Model == (Model) PedHash.Michael)
          {
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 26, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
          }
          else
          {
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 16, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 16, (InputArgument) 17, (InputArgument) 1);
          }
          this.IsinHottub = true;
        }
        else if (this.IsinHottub)
        {
          Game.Player.Character.Position = this.jacuzziSeat1;
          Game.Player.Character.Rotation = new Vector3(0.0f, 0.0f, this.Base.Rotation.Z + 90f);
          Script.Wait(1);
          this.AnimDict = "anim@amb@yacht@jacuzzi@seated@male@variation_0" + this.animtype.ToString() + "@";
          Yacht.LoadDict(this.AnimDict);
          Vector3 jacuzziSeat1 = this.jacuzziSeat1;
          Ped character = Game.Player.Character;
          this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) jacuzziSeat1.X, (InputArgument) jacuzziSeat1.Y, (InputArgument) (jacuzziSeat1.Z + 0.25f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) character.Heading, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) character, (InputArgument) this.Scene1, (InputArgument) Yacht.LoadDict(this.AnimDict), (InputArgument) "exit", (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) character, (InputArgument) this.Scene1, (InputArgument) "exit", (InputArgument) Yacht.LoadDict(this.AnimDict), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) character.Rotation.Z, (InputArgument) 1148846080, (InputArgument) 0);
          Script.Wait(3000);
          Game.Player.Character.Task.ClearAllImmediately();
          Game.Player.Character.Task.ClearAll();
          Game.Player.Character.FreezePosition = false;
          this.GetPedOutfitCutscene("MP_1", Game.Player.Character);
          this.IsinHottub = false;
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.ChangeLocMarker) < 2.0)
      {
        this.DisplayHelpTextThisFrame("Change Location");
        this.ChangePosMainMenu.Visible = !this.ChangePosMainMenu.Visible;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) < 2.0)
        this.mainMenu.Visible = !this.mainMenu.Visible;
      if (!Game.IsControlJustPressed(2, GTA.Control.Context))
        return;
      if ((double) World.GetDistance(Game.Player.Character.Position, this.BarEnter) < 2.0)
      {
        Game.FadeScreenOut(300);
        Script.Wait(300);
        Game.Player.Character.Position = this.BarExit;
        Script.Wait(300);
        Game.FadeScreenIn(300);
      }
      else if ((double) World.GetDistance(Game.Player.Character.Position, this.BarExit) < 2.0)
      {
        Game.FadeScreenOut(300);
        Script.Wait(300);
        Game.Player.Character.Position = this.BarEnter;
        Script.Wait(300);
        Game.FadeScreenIn(300);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.CaptinsQuartersEnter) < 2.0)
      {
        Game.FadeScreenOut(300);
        Script.Wait(300);
        Game.Player.Character.Position = this.CaptinsQuartersExit;
        Script.Wait(300);
        Game.FadeScreenIn(300);
      }
      else if ((double) World.GetDistance(Game.Player.Character.Position, this.CaptinsQuartersExit) < 2.0)
      {
        Game.FadeScreenOut(300);
        Script.Wait(300);
        Game.Player.Character.Position = this.CaptinsQuartersEnter;
        Script.Wait(300);
        Game.FadeScreenIn(300);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed1) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        Game.Player.Character.FreezePosition = true;
        Game.FadeScreenOut(500);
        Script.Wait(500);
        Function.Call(Hash._0xC8CA9670B9D83B3B, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0);
        Game.Player.WantedLevel = 0;
        Function.Call(Hash._0x8FE22675A5A45817, (InputArgument) Game.Player.Character);
        Function.Call(Hash._0x9C720776DAA43E7E, (InputArgument) Game.Player.Character);
        Game.Player.Character.Position = this.Bed1;
        Game.Player.Character.Heading = 248.15f;
        Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
        Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
        Game.Player.Character.FreezePosition = false;
        Script.Wait(1500);
        Game.FadeScreenIn(500);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed2) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        Game.Player.Character.FreezePosition = true;
        Game.FadeScreenOut(500);
        Script.Wait(500);
        Function.Call(Hash._0xC8CA9670B9D83B3B, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0);
        Game.Player.WantedLevel = 0;
        Function.Call(Hash._0x8FE22675A5A45817, (InputArgument) Game.Player.Character);
        Function.Call(Hash._0x9C720776DAA43E7E, (InputArgument) Game.Player.Character);
        Game.Player.Character.Position = this.Bed2;
        Game.Player.Character.Heading = 248.15f;
        Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
        Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
        Game.Player.Character.FreezePosition = false;
        Script.Wait(1500);
        Game.FadeScreenIn(500);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Bed3) >= 2.0 || !Game.IsControlJustPressed(2, GTA.Control.Context))
        return;
      Game.Player.Character.FreezePosition = true;
      Game.FadeScreenOut(500);
      Script.Wait(500);
      Function.Call(Hash._0xC8CA9670B9D83B3B, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0);
      Game.Player.WantedLevel = 0;
      Function.Call(Hash._0x8FE22675A5A45817, (InputArgument) Game.Player.Character);
      Function.Call(Hash._0x9C720776DAA43E7E, (InputArgument) Game.Player.Character);
      Game.Player.Character.Position = this.Bed3;
      Game.Player.Character.Heading = 248.15f;
      Function.Call(Hash._0xB4EC2312F4E5B1F1, (InputArgument) 0.0f);
      Function.Call(Hash._0x6D0858B8EDFD2B7D, (InputArgument) 0.0f);
      Game.Player.Character.FreezePosition = false;
      Script.Wait(1500);
      Game.FadeScreenIn(500);
    }
  }
}
