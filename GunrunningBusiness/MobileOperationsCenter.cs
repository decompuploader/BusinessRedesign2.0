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

namespace GunRunningBusiness
{
  public class MobileOperationsCenter : Script
  {
    private ScriptSettings MainConfigFile;
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private UIMenu Options;
    private ScriptSettings Config;
    public Vector3 Spawn = new Vector3(2347f, 3219f, 47f);
    public Vehicle Cab;
    public Vehicle Trailer;
    public bool Created;
    public int Weapons;
    public int Livery;
    public Vector3 MOCPosSave;
    public Blip MOCBlip;
    public float X;
    public float Y;
    public int Tintscount = 4;
    public float Z;
    public Vector3 ExitMoc = new Vector3(1103.59f, -3009.95f, -40f);
    public bool IsInInterior;
    public Vector3 Gunlockerpos = new Vector3(1101.3f, -3002.38f, -40f);
    public string VehicleToUse;
    private MenuPool modMenuPool2;
    private UIMenu mainMenu2;
    private UIMenu Options2;
    public Vector3 CabOptions = new Vector3(1105.3f, -3002.38f, -40f);
    public SaveCar SaveLoad;
    public SaveCar WheelsSaveLoad = new SaveCar();
    public Vehicle VehicleinCargoBay;
    public VehicleColor CabPrimary;
    public VehicleColor CabSecondary;
    public VehicleColor TrailerPrimary;
    public VehicleColor TrailerSecondary;
    public bool SpawnedFromBunker;
    public bool ReadIni;
    public bool ResetMoc;
    public Vector3 FortZancudo = new Vector3(-2999.54f, 3314.41f, 10f);
    public Vector3 Paleto = new Vector3(-707f, 5974f, 15f);
    public Vector3 RatonCanyon = new Vector3(-379.58f, 4307f, 54f);
    public Vector3 Chumash = new Vector3(-3116f, 1366f, 22f);
    public Vector3 GrapeSeed = new Vector3(1778f, 4711f, 41f);
    public Vector3 GSD1 = new Vector3(653f, 3066f, 41f);
    public Vector3 GSD2 = new Vector3(2073f, 3319f, 45f);
    public Vector3 GSD3 = new Vector3(1573f, 2198f, 79f);
    public Vector3 GSD4 = new Vector3(49f, 2909f, 54f);
    public Vector3 GSD5 = new Vector3(2488f, 3202f, 49f);
    public Vector3 GSD6 = new Vector3(519f, 3056f, 41f);
    public float VHeading;
    public bool SavedVehicle = true;
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public bool CreatePeds;
    public bool boughtvehicle;
    public int num;
    private MenuPool VMmodMenuPool;
    private UIMenu VMmainMenu;
    private UIMenu vehicleMenu;
    public static Vector3 Agent = new Vector3(1713.17f, 3229f, 41.45f);
    public int purchasedvehicle = 0;
    public int wantedlevelprice;
    public bool invunrablewait;
    public int invunrabletimer;
    public bool offradarbool;
    public int offradartimer;
    public bool mobileoptions;
    private Blip Enemy;
    private Ped EnemyPed;
    private Vector3 EnemyLoc;
    public bool EnemySetup;
    public int Chooseenemynum;
    public bool createdPed;
    public Ped ClayPed;
    public int PurchasedSecondBusiness;
    public Blip blip;
    public string ListPath = "scripts\\HKH191sBusinessMods\\GunRunningBusiness\\WorkingMOC\\MilitaryTrader\\AllVehicles.ini";
    public float M = 0.0f;
    public string Price = "000";
    public string Model = "";
    public string man = "";
    public Vector3 VehSpawn;
    public Vector3 TurretCamA;
    public Vector3 TurretCamB;
    public Vector3 TurretCamC;
    public bool IsUsingSam;
    public int MissilesFired;
    public bool CanFire;
    public Camera DroneCam;
    public bool usePrecision;
    public float PrecisionLevel = 1f;
    public float AmounttoDecrease = 0.5f;
    public int TurretTimer;
    private Keys Key1;
    private UIMenu weaponsMenu;
    public Vector3 GunLockerMarker = new Vector3(1101.3f, -3002.38f, -40f);
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
    private MenuPool GunmodMenuPool;
    private UIMenu GunmainMenu;
    public int GunTintscount = 32;
    public int LiveryColor;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public int Timer;
    public int TurretMode;
    public bool IsInCab;
    public ScriptSettings CheckOcciConfig;
    public bool CreatedChairs;
    public int Scene1;
    public int SeatSittingin;
    public bool SittinginSeat;
    public int MocBay = 0;
    public int MocBay2 = 0;
    public int MocBay3 = 0;
    public Prop Chair1;
    public Prop Chair2;
    public Prop Chair3;
    public Prop ExitChair;
    public int Chairin;
    public int CmdOn;
    public Vector3 ExitOutside = new Vector3(1103.5f, -2990.4f, -40f);

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

    public Vector3 ToVector3(string Name)
    {
      Vector3 vector3 = new Vector3(0.0f, 0.0f, 0.0f);
      string[] separator = new string[3]{ "X:", "Y:", "Z:" };
      string[] strArray = Name.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      try
      {
        vector3 = new Vector3(float.Parse(strArray[0]), float.Parse(strArray[1]), float.Parse(strArray[2]));
      }
      catch (Exception ex)
      {
      }
      return vector3;
    }

    private void SetupVehicles()
    {
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.vehicleMenu, "Weaponized");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.vehicleMenu, "Armoured");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.vehicleMenu, "misc");
      this.GUIMenus.Add(uiMenu3);
      List<object> LogList = new List<object>();
      string[] logFile = File.ReadAllLines(this.ListPath);
      foreach (string str in logFile)
        LogList.Add((object) str);
      this.LoadIniFile(this.ListPath);
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
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.vehicleMenu, "All");
      this.GUIMenus.Add(uiMenu4);
      UIMenuListItem V = new UIMenuListItem("Vehicle : ", LogList, 0);
      uiMenu4.AddItem((UIMenuItem) V);
      UIMenuItem VDName = new UIMenuItem("Vehicle Spawn Name  : Dukes2");
      uiMenu4.AddItem(VDName);
      UIMenuItem VName = new UIMenuItem("Vehicle Full Name  : Imponte Dukes");
      uiMenu4.AddItem(VName);
      UIMenuItem PuchaseV = new UIMenuItem("Purchase Vehicle : $0");
      uiMenu4.AddItem(PuchaseV);
      List<object> STlist = new List<object>();
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      UIMenuItem uiMenuItem1 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu4.AddItem(uiMenuItem1);
      UIMenuItem Search = new UIMenuItem("Enter Vehicle Name");
      uiMenu4.AddItem(Search);
      UIMenuListItem V2 = new UIMenuListItem("Vehicle : ", STlist, 0);
      uiMenu4.AddItem((UIMenuItem) V2);
      UIMenuItem uiMenuItem2 = new UIMenuItem("Search Term  : NULL");
      uiMenu4.AddItem(uiMenuItem2);
      UIMenuItem VDName2 = new UIMenuItem("Vehicle Spawn Name  : NULL");
      uiMenu4.AddItem(VDName2);
      UIMenuItem VName2 = new UIMenuItem("Vehicle Full Name  : NULL");
      uiMenu4.AddItem(VName2);
      UIMenuItem PuchaseV2 = new UIMenuItem("Purchase Vehicle : NULL");
      uiMenu4.AddItem(PuchaseV2);
      uiMenu4.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == V)
        {
          try
          {
            string[] separator = new string[2]{ " = ", "," };
            // ISSUE: reference to a compiler-generated field
            if (MobileOperationsCenter.\u003C\u003Eo__86.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              MobileOperationsCenter.\u003C\u003Eo__86.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (MobileOperationsCenter)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            string[] strArray = MobileOperationsCenter.\u003C\u003Eo__86.\u003C\u003Ep__0.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__86.\u003C\u003Ep__0, LogList[V.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
        if (item != V2)
          return;
        try
        {
          string[] separator = new string[2]{ " = ", "," };
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__86.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__86.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (MobileOperationsCenter)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string[] strArray = MobileOperationsCenter.\u003C\u003Eo__86.\u003C\u003Ep__1.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__86.\u003C\u003Ep__1, STlist[V2.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
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
              World.CreateVehicle(this.RequestModel(this.man), this.VehSpawn, this.Cab.Heading);
              UI.Notify(this.GetHostName() + " Have fun with your new, ~g~" + this.Model);
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
            World.CreateVehicle(this.RequestModel(this.man), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new, ~g~" + this.Model);
          }
          catch (Exception ex)
          {
          }
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
      });
      UIMenuItem Deluxo = new UIMenuItem("Deluxo: $3,550,000");
      uiMenu1.AddItem(Deluxo);
      UIMenuItem Oppressor = new UIMenuItem("Oppressor: $2,650,000");
      uiMenu1.AddItem(Oppressor);
      UIMenuItem OppressorMk2 = new UIMenuItem("Oppressor  MK2: $2,950,000");
      uiMenu1.AddItem(OppressorMk2);
      UIMenuItem WeaponizedTampa = new UIMenuItem("Weaponized Tampa: $1,585,000");
      uiMenu1.AddItem(WeaponizedTampa);
      UIMenuItem DuneFav = new UIMenuItem("Dune FAV : $850,000");
      uiMenu1.AddItem(DuneFav);
      UIMenuItem Ruiner2000 = new UIMenuItem("Ruiner 2000 : $4,320,000");
      uiMenu1.AddItem(Ruiner2000);
      UIMenuItem RampBuggy = new UIMenuItem("Ramp Buggy : $2,400,000");
      uiMenu1.AddItem(RampBuggy);
      UIMenuItem phantomW = new UIMenuItem("Phantom Wedge : $1,920,000");
      uiMenu1.AddItem(phantomW);
      UIMenuItem AquaBlazer = new UIMenuItem("Aqua Blazer : $1,320,000");
      uiMenu1.AddItem(AquaBlazer);
      UIMenuItem TurretedLimo = new UIMenuItem("Turreted Limo : $1,650,000");
      uiMenu1.AddItem(TurretedLimo);
      UIMenuItem insurgentPickup = new UIMenuItem("Insurgent Pickup: $645,000");
      uiMenu2.AddItem(insurgentPickup);
      UIMenuItem insurgent = new UIMenuItem("Insurgent : $600,000");
      uiMenu2.AddItem(insurgent);
      UIMenuItem Kuruma = new UIMenuItem("Armoured Kuruma : $525,000");
      uiMenu2.AddItem(Kuruma);
      UIMenuItem kightshark = new UIMenuItem("Nightshark : $1,245,000");
      uiMenu2.AddItem(kightshark);
      UIMenuItem Rhino = new UIMenuItem("Rhino : $3,000,000");
      uiMenu2.AddItem(Rhino);
      UIMenuItem Chernobog = new UIMenuItem("Chernobog : $2,490,000");
      uiMenu2.AddItem(Chernobog);
      UIMenuItem Barrage = new UIMenuItem("Barrage : $1,595,000");
      uiMenu2.AddItem(Barrage);
      UIMenuItem menacer = new UIMenuItem("Menacer : $1,775,000");
      uiMenu2.AddItem(menacer);
      UIMenuItem boxville = new UIMenuItem("Armoured Boxville : $2,200,000");
      uiMenu2.AddItem(boxville);
      UIMenuItem Technical1 = new UIMenuItem("Technical : $950,000");
      uiMenu2.AddItem(Technical1);
      UIMenuItem Technical2 = new UIMenuItem("Technical Aqua : $1,120,000");
      uiMenu2.AddItem(Technical2);
      UIMenuItem Technical3 = new UIMenuItem("Technical Custom: $1,200,000");
      uiMenu2.AddItem(Technical3);
      UIMenuItem APC = new UIMenuItem("APC: $2,325,000");
      uiMenu2.AddItem(APC);
      UIMenuItem Halftrack = new UIMenuItem("Half Track: $1,695,000");
      uiMenu2.AddItem(Halftrack);
      UIMenuItem Khanjali = new UIMenuItem("TM-02 Khanjali: $2,895,000 ");
      uiMenu2.AddItem(Khanjali);
      UIMenuItem AATrailer = new UIMenuItem("AA Trailer : $1,400,000");
      uiMenu3.AddItem(AATrailer);
      UIMenuItem Wastelander = new UIMenuItem("Wastelander : $495,000");
      uiMenu3.AddItem(Wastelander);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        Vehicle[] nearbyVehicles = World.GetNearbyVehicles(this.VehSpawn, 10f);
        if ((uint) nearbyVehicles.Length > 0U)
        {
          foreach (Vehicle vehicle in nearbyVehicles)
          {
            if ((Entity) vehicle != (Entity) null)
              vehicle.Delete();
          }
        }
        if (item == TurretedLimo)
        {
          if (Game.Player.Money > 1650000)
          {
            Game.Player.Money -= 1650000;
            World.CreateVehicle(new GTA.Model(-114627507), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Deluxo)
        {
          if (Game.Player.Money > 3550000)
          {
            Game.Player.Money -= 3550000;
            World.CreateVehicle(new GTA.Model(1483171323), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Oppressor)
        {
          if (Game.Player.Money > 2650000)
          {
            Game.Player.Money -= 2650000;
            World.CreateVehicle(new GTA.Model(884483972), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == OppressorMk2)
        {
          if (Game.Player.Money > 2950000)
          {
            Game.Player.Money -= 2950000;
            World.CreateVehicle((GTA.Model) VehicleHash.Oppressor2, this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == WeaponizedTampa)
        {
          if (Game.Player.Money > 1585000)
          {
            Game.Player.Money -= 1585000;
            World.CreateVehicle(new GTA.Model(-1210451983), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == DuneFav)
        {
          if (Game.Player.Money > 850000)
          {
            Game.Player.Money -= 850000;
            World.CreateVehicle(new GTA.Model(1897744184), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Ruiner2000)
        {
          if (Game.Player.Money > 4320000)
          {
            Game.Player.Money -= 4320000;
            World.CreateVehicle(new GTA.Model(941494461), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == RampBuggy)
        {
          if (Game.Player.Money > 2400000)
          {
            Game.Player.Money -= 2400000;
            World.CreateVehicle(new GTA.Model(-312295511), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == phantomW)
        {
          if (Game.Player.Money > 1920000)
          {
            Game.Player.Money -= 1920000;
            World.CreateVehicle(new GTA.Model(-1649536104), this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item != AquaBlazer)
          return;
        if (Game.Player.Money > 1320000)
        {
          Game.Player.Money -= 1320000;
          World.CreateVehicle(new GTA.Model(-1590337689), this.VehSpawn, this.Cab.Heading);
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == insurgent)
        {
          if (Game.Player.Money > 600000)
          {
            Game.Player.Money -= 600000;
            World.CreateVehicle((GTA.Model) VehicleHash.Insurgent2, this.VehSpawn, this.Cab.Heading);
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == insurgentPickup)
        {
          if (Game.Player.Money > 695000)
          {
            World.CreateVehicle((GTA.Model) VehicleHash.Insurgent, this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 695000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Kuruma)
        {
          if (Game.Player.Money > 525000)
          {
            World.CreateVehicle((GTA.Model) VehicleHash.Kuruma2, this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 525000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == kightshark)
        {
          if (Game.Player.Money > 1245000)
          {
            World.CreateVehicle(new GTA.Model(433954513), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 1245000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Rhino)
        {
          if (Game.Player.Money > 3000000)
          {
            World.CreateVehicle((GTA.Model) VehicleHash.Rhino, this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 3000000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == menacer)
        {
          if (Game.Player.Money > 1775000)
          {
            World.CreateVehicle((GTA.Model) VehicleHash.Menacer, this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 1775000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Chernobog)
        {
          if (Game.Player.Money > 2490000)
          {
            World.CreateVehicle(new GTA.Model(-692292317), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 2490000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Barrage)
        {
          if (Game.Player.Money > 1595000)
          {
            World.CreateVehicle(new GTA.Model(-212993243), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 1595000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == boxville)
        {
          if (Game.Player.Money > 2200000)
          {
            World.CreateVehicle(new GTA.Model(682434785), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 2200000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Technical1)
        {
          if (Game.Player.Money > 950000)
          {
            World.CreateVehicle(new GTA.Model(-2096818938), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 950000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Technical2)
        {
          if (Game.Player.Money > 1120000)
          {
            World.CreateVehicle(new GTA.Model(1180875963), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 1120000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Technical3)
        {
          if (Game.Player.Money > 1200000)
          {
            World.CreateVehicle(new GTA.Model(1356124575), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 1200000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == APC)
        {
          if (Game.Player.Money > 2350000)
          {
            World.CreateVehicle(new GTA.Model(562680400), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 2350000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item == Halftrack)
        {
          if (Game.Player.Money > 1695000)
          {
            World.CreateVehicle(new GTA.Model(-32236122), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 1695000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item != Khanjali)
          return;
        if (Game.Player.Money > 2895000)
        {
          World.CreateVehicle(new GTA.Model(-1435527158), this.VehSpawn, this.Cab.Heading);
          Game.Player.Money -= 2895000;
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        Vehicle[] nearbyVehicles = World.GetNearbyVehicles(this.VehSpawn, 10f);
        if ((uint) nearbyVehicles.Length > 0U)
        {
          foreach (Vehicle vehicle in nearbyVehicles)
          {
            if ((Entity) vehicle != (Entity) null)
              vehicle.Delete();
          }
        }
        if (item == AATrailer)
        {
          if (Game.Player.Money > 1400000)
          {
            World.CreateVehicle(new GTA.Model(-1881846085), this.VehSpawn, this.Cab.Heading);
            Game.Player.Money -= 1400000;
            UI.Notify(this.GetHostName() + " Have fun with your new toy");
          }
          else
            UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
        }
        if (item != Wastelander)
          return;
        if (Game.Player.Money > 495000)
        {
          World.CreateVehicle(new GTA.Model(-1912017790), this.VehSpawn, this.Cab.Heading);
          Game.Player.Money -= 495000;
          UI.Notify(this.GetHostName() + " Have fun with your new toy");
        }
        else
          UI.Notify(this.GetHostName() + " you do not have enought money to purchase this vehicle!");
      });
    }

    public static void DrawScaleformTurret()
    {
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("turret_cam");
      scaleform.Render2D();
    }

    public static void DrawScaleformDrone()
    {
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("drone_cam");
      scaleform.Render2D();
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
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.weaponsMenu, "Mk2 Weapons (Advanced)");
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
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p1 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__0 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__0.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__0, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
          if (target1((CallSite) p1, obj1))
          {
            Components.Clear();
            // ISSUE: reference to a compiler-generated field
            if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__2 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__2.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__2, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
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
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (MobileOperationsCenter)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target2 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__4.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p4 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__4;
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__3.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__3, Components[C.Index]);
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
        if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (MobileOperationsCenter)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p6 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__5.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__5, Components[C.Index]);
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
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (MobileOperationsCenter)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target1 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p8 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__7.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__7, Components[C.Index]);
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
            if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, bool> target2 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__10.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, bool>> p10 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__10;
            // ISSUE: reference to a compiler-generated field
            if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__9 == null)
            {
              // ISSUE: reference to a compiler-generated field
              MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__9 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__9.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__9, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
            if (target2((CallSite) p10, obj2))
            {
              if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) W.IndexToItem(W.Index).GetHashCode(), (InputArgument) C.IndexToItem(C.Index).GetHashCode()))
              {
                // ISSUE: reference to a compiler-generated field
                if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__11 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__11 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__11.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__11, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
                // ISSUE: reference to a compiler-generated field
                if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__12 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__12 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__12.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__12, Game.Player.Character.Weapons.Current, Components[C.Index], true);
              }
            }
          }
        }
        if (item != DIsable)
          return;
        // ISSUE: reference to a compiler-generated field
        if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__14.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p14 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__14;
        // ISSUE: reference to a compiler-generated field
        if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__13 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__13.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__13, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
        if (target3((CallSite) p14, obj3))
        {
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__19 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__19.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p19 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__19;
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__18 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool, object> target2 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__18.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool, object>> p18 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__18;
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__17 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__17 = CallSite<Func<CallSite, System.Type, Hash, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Call", (IEnumerable<System.Type>) new System.Type[1]
            {
              typeof (bool)
            }, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, System.Type, Hash, object, object, object> target4 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__17.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, System.Type, Hash, object, object, object>> p17 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__17;
          System.Type type = typeof (Function);
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__15 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__15.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__15, Mk2Weapons[W.Index]);
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__16 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__16.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__16, Components[C.Index]);
          object obj4 = target4((CallSite) p17, type, Hash._0x5CEE3DF569CECAB0, obj1, obj2);
          object obj5 = target2((CallSite) p18, obj4, true);
          if (target1((CallSite) p19, obj5))
          {
            // ISSUE: reference to a compiler-generated field
            if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__20 == null)
            {
              // ISSUE: reference to a compiler-generated field
              MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__20 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__20.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__20, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
            // ISSUE: reference to a compiler-generated field
            if (MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__21 == null)
            {
              // ISSUE: reference to a compiler-generated field
              MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__21 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (MobileOperationsCenter), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__21.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__126.\u003C\u003Ep__21, Game.Player.Character.Weapons.Current, Components[C.Index], false);
          }
        }
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.weaponsMenu, "Scifi Weapons");
      this.GUIMenus.Add(uiMenu2);
      UIMenu menu = this.modMenuPool.AddSubMenu(this.weaponsMenu, "Mk2 Weapons");
      this.GUIMenus.Add(menu);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.weaponsMenu, "Normal Weapons");
      this.GUIMenus.Add(uiMenu3);
      List<object> items3 = new List<object>();
      for (int index = 0; index < this.Tintscount; ++index)
        items3.Add((object) index);
      this.MK2Pumpshotgun = this.modMenuPool.AddSubMenu(menu, "MK2 Pump Shotgun");
      this.GUIMenus.Add(this.MK2Pumpshotgun);
      this.MK2SNSPistol = this.modMenuPool.AddSubMenu(menu, "MK2 SNS Pistol");
      this.GUIMenus.Add(this.MK2SNSPistol);
      this.MK2Revolver = this.modMenuPool.AddSubMenu(menu, "MK2 Revolver");
      this.GUIMenus.Add(this.MK2Revolver);
      this.Mk2SpecialCarbine = this.modMenuPool.AddSubMenu(menu, "MK2 Special Carbine");
      this.GUIMenus.Add(this.Mk2SpecialCarbine);
      this.MK2Bullpup = this.modMenuPool.AddSubMenu(menu, "MK2 Bullpup Rifle");
      this.GUIMenus.Add(this.MK2Bullpup);
      this.MK2MarksmanRifle = this.modMenuPool.AddSubMenu(menu, "MK2 Marksmans Rifle");
      this.GUIMenus.Add(this.MK2MarksmanRifle);
      this.MK2Pistol = this.modMenuPool.AddSubMenu(menu, "MK2 Pistol");
      this.GUIMenus.Add(this.MK2Pistol);
      this.MK2SMG = this.modMenuPool.AddSubMenu(menu, "MK2 SMG");
      this.GUIMenus.Add(this.MK2SMG);
      this.MK2LMG = this.modMenuPool.AddSubMenu(menu, "MK2 LMG");
      this.GUIMenus.Add(this.MK2LMG);
      this.MK2Carbine = this.modMenuPool.AddSubMenu(menu, "MK2 Carbine");
      this.GUIMenus.Add(this.MK2Carbine);
      this.MK2AssaultRifle = this.modMenuPool.AddSubMenu(menu, "MK2 Assault Rifle");
      this.GUIMenus.Add(this.MK2AssaultRifle);
      this.MK2Sniper = this.modMenuPool.AddSubMenu(menu, "MK2 Sniper");
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

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Gunrunning Business", "Moc", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: C1 Config.ini Failed To Load.");
      }
    }

    public MobileOperationsCenter()
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
      this.SaveLoad = new SaveCar();
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Interval = 1;
      this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
      this.Spawn = new Vector3(this.X, this.Y, this.Z);
      this.MOCPosSave = new Vector3(this.X, this.Y, this.Z);
      this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
      this.CreateBanner();
      this.Setup();
    }

    public void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.MOCPosSave = this.Config.GetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
        this.VehicleToUse = this.Config.GetValue<string>("Setup", "VehicleToUse", this.VehicleToUse);
        this.Livery = this.Config.GetValue<int>("Setup", "Livery", this.Livery);
        this.Weapons = this.Config.GetValue<int>("Setup", "Weapons", this.Weapons);
        this.CabPrimary = this.Config.GetValue<VehicleColor>("CAB", "Primary", this.CabPrimary);
        this.CabSecondary = this.Config.GetValue<VehicleColor>("CAB", "Secondary", this.CabPrimary);
        this.TrailerPrimary = this.Config.GetValue<VehicleColor>("Trailer", "Primary", this.TrailerPrimary);
        this.TrailerSecondary = this.Config.GetValue<VehicleColor>("Trailer", "Secondary", this.TrailerPrimary);
        this.X = this.Config.GetValue<float>("Setup", "X", this.X);
        this.Y = this.Config.GetValue<float>("Setup", "Y", this.Y);
        this.Z = this.Config.GetValue<float>("Setup", "Z", this.Z);
        this.Spawn = this.MOCPosSave;
        this.VHeading = this.Config.GetValue<float>("Setup", "VHeading", this.VHeading);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: MOC Config.ini Failed To Load.");
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
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Command Center", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.Options = this.modMenuPool.AddSubMenu(this.mainMenu, "Options");
      this.GUIMenus.Add(this.Options);
      this.modMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Cab Options", "Select an Option");
      this.GUIMenus.Add(this.mainMenu2);
      this.modMenuPool2.Add(this.mainMenu2);
      this.Options2 = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Cab Vehicle / Stored Vehicle");
      this.GUIMenus.Add(this.Options2);
      this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
      this.SetupMarker();
      this.setupoptions();
      this.VehicleOptions();
      this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
      this.VMmodMenuPool = new MenuPool();
      this.VMmainMenu = new UIMenu("Military Trader", "Select an Option");
      this.GUIMenus.Add(this.VMmainMenu);
      this.VMmodMenuPool.Add(this.VMmainMenu);
      this.vehicleMenu = this.VMmodMenuPool.AddSubMenu(this.VMmainMenu, "Vehicles");
      this.GUIMenus.Add(this.vehicleMenu);
      this.SetupVehicles();
      this.GunmodMenuPool = new MenuPool();
      this.GunmainMenu = new UIMenu("Gunlocker", "Select an Option");
      this.GUIMenus.Add(this.GunmainMenu);
      this.GunmodMenuPool.Add(this.GunmainMenu);
      this.weaponsMenu = this.GunmodMenuPool.AddSubMenu(this.GunmainMenu, "Weapons");
      this.GUIMenus.Add(this.weaponsMenu);
      this.SetupWeapons();
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void SetupMarker()
    {
      this.MOCBlip = World.CreateBlip(this.Spawn);
      this.MOCBlip.Name = "Mobile Operations Center (TGB)";
      this.MOCBlip.Sprite = BlipSprite.MobileOperationsCenter;
      this.MOCBlip.Color = this.Blip_Colour;
      this.MOCBlip.IsShortRange = true;
    }

    public void SavePos()
    {
      this.Cab.Position = this.Spawn;
      this.MOCPosSave = this.Cab.Position;
      this.Spawn = this.MOCPosSave;
      this.X = this.Spawn.X;
      this.Config.SetValue<float>("Setup", "X", this.X);
      this.Y = this.Spawn.Y;
      this.Config.SetValue<float>("Setup", "Y", this.Y);
      this.Z = this.Spawn.Z;
      this.Config.SetValue<float>("Setup", "Z", this.Z);
      this.Config.SetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
      this.Config.Save();
      this.VHeading = this.Cab.Heading;
      this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
      this.Config.Save();
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public void VehicleOptions()
    {
      UIMenu uiMenu1 = this.modMenuPool2.AddSubMenu(this.Options2, "Cab Vehicles");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool2.AddSubMenu(this.Options2, "Special Vehicles");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool2.AddSubMenu(this.Options2, "Stored Vehicle");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem uiMenuItem = new UIMenuItem("Player's Stored Vehicle");
      uiMenu3.AddItem(uiMenuItem);
      UIMenuItem DuneFav = new UIMenuItem("DuneFav");
      uiMenu2.AddItem(DuneFav);
      UIMenuItem WT = new UIMenuItem("Weaponized Tampa");
      uiMenu2.AddItem(WT);
      UIMenuItem TC = new UIMenuItem("Technical Custom");
      uiMenu2.AddItem(TC);
      UIMenuItem IC = new UIMenuItem("Insurgent Custom");
      uiMenu2.AddItem(IC);
      UIMenuItem HT = new UIMenuItem("Half Track");
      uiMenu2.AddItem(HT);
      UIMenuItem NS = new UIMenuItem("NightShark");
      uiMenu2.AddItem(NS);
      UIMenuItem OP = new UIMenuItem("Oppressor");
      uiMenu2.AddItem(OP);
      UIMenuItem APC = new UIMenuItem("APC");
      uiMenu2.AddItem(APC);
      UIMenuItem Deluxo = new UIMenuItem("Deluxo");
      uiMenu2.AddItem(Deluxo);
      UIMenuItem Barrage = new UIMenuItem("Barrage");
      uiMenu2.AddItem(Barrage);
      UIMenuItem Khanjali = new UIMenuItem("Khanjali");
      uiMenu2.AddItem(Khanjali);
      UIMenuItem Stromberg = new UIMenuItem("Stromberg");
      uiMenu2.AddItem(Stromberg);
      UIMenuItem Hauler2 = new UIMenuItem("Hauler Custom");
      uiMenu1.AddItem(Hauler2);
      UIMenuItem Phantom3 = new UIMenuItem("Phantom Custom");
      uiMenu1.AddItem(Phantom3);
      UIMenuItem Phantom2 = new UIMenuItem("Phantom Wedge");
      uiMenu1.AddItem(Phantom2);
      UIMenu uiMenu4 = this.modMenuPool2.AddSubMenu(this.Options2, "Extra");
      this.GUIMenus.Add(uiMenu4);
      UIMenuItem PlayersVehicle1 = new UIMenuItem("Delete");
      uiMenu4.AddItem(PlayersVehicle1);
      UIMenuItem PlayersVehicle2 = new UIMenuItem("Backup and Delete");
      uiMenu4.AddItem(PlayersVehicle2);
      UIMenuItem PlayersVehicle3 = new UIMenuItem("Reload From Backup");
      uiMenu4.AddItem(PlayersVehicle3);
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == PlayersVehicle3)
        {
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Storage//Backup.ini");
          if (this.SaveLoad.VehicleName != "null")
          {
            if ((Entity) this.VehicleinCargoBay != (Entity) null)
              this.VehicleinCargoBay.Delete();
            this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) this.SaveLoad.VehicleName, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
            this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
            this.VehicleinCargoBay.Heading = 0.0f;
            this.VehicleinCargoBay.IsDriveable = false;
            UI.Notify(this.GetHostName() + " Loaded Backup");
            this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Storage//Vehicle.ini");
            Vector3 position = Game.Player.Character.Position;
            Game.Player.Character.SetIntoVehicle(this.VehicleinCargoBay, VehicleSeat.Driver);
            this.SaveLoad.SaveWithoutDelete();
            Game.Player.Character.Task.LeaveVehicle(this.VehicleinCargoBay, LeaveVehicleFlags.WarpOut);
            UI.Notify("TestC");
          }
        }
        if (item == PlayersVehicle1)
        {
          UI.Notify(this.GetHostName() + " Deleteing Saved Vehicle");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
        }
        if (item != PlayersVehicle2 || !((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        UI.Notify(this.GetHostName() + " Deleteing Saved Vehicle");
        Vector3 position1 = Game.Player.Character.Position;
        Game.Player.Character.SetIntoVehicle(this.VehicleinCargoBay, VehicleSeat.Driver);
        Game.Player.Character.Task.LeaveVehicle(this.VehicleinCargoBay, LeaveVehicleFlags.WarpOut);
        UI.Notify("TestC");
        this.VehicleinCargoBay.Delete();
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) => { });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == DuneFav)
        {
          UI.Notify(this.GetHostName() + " Loading Dune FAV");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//dunefav.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Dune3, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == WT)
        {
          UI.Notify(this.GetHostName() + " Loading Weaponized Tampa");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//weaponizedtampa.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Tampa3, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == TC)
        {
          UI.Notify(this.GetHostName() + " Loading Technical Custom");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//technicalcustom.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Technical3, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == IC)
        {
          UI.Notify(this.GetHostName() + " Loading Insurgent Custom");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//Insurgentcustom.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Insurgent3, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == HT)
        {
          UI.Notify(this.GetHostName() + " Loading Halftrack ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//halftrack.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.HalfTrack, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == NS)
        {
          UI.Notify(this.GetHostName() + " Loading Nightshark ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//nightshark.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.NightShark, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == OP)
        {
          UI.Notify(this.GetHostName() + " Loading Oppressor ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//oppressor.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Oppressor, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == APC)
        {
          UI.Notify(this.GetHostName() + " Loading APC ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//BunkerStorage//apc.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.APC, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == Deluxo)
        {
          UI.Notify(this.GetHostName() + " Loading Delxuo ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Special Vehicles//Deluxo.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Deluxo, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == Barrage)
        {
          UI.Notify(this.GetHostName() + " Loading Barrage ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Special Vehicles//Barrage.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Barrage, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == Khanjali)
        {
          UI.Notify(this.GetHostName() + " Loading khanjali");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Special Vehicles//Khanjali.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Khanjari, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
          this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item != Stromberg)
          return;
        UI.Notify(this.GetHostName() + " Loading Stromberg");
        if ((Entity) this.VehicleinCargoBay != (Entity) null)
          this.VehicleinCargoBay.Delete();
        this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Special Vehicles//Stromberg.ini");
        this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Stromberg, new Vector3(1103.44f, -2994.398f, -40f), 0.0f);
        this.SaveLoad.LoadVehicleInCargoBay(this.VehicleinCargoBay);
        this.VehicleinCargoBay.IsDriveable = false;
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Hauler2)
        {
          this.VehicleToUse = "HAULER2";
          this.Config.SetValue<string>("Setup", "VehicleToUse", this.VehicleToUse);
          this.Config.Save();
        }
        if (item == Phantom3)
        {
          this.VehicleToUse = "PHANTOM3";
          this.Config.SetValue<string>("Setup", "VehicleToUse", this.VehicleToUse);
          this.Config.Save();
        }
        if (item != Phantom2)
          return;
        this.VehicleToUse = "PHANTOM2";
        this.Config.SetValue<string>("Setup", "VehicleToUse", this.VehicleToUse);
        this.Config.Save();
      });
    }

    public void setupoptions()
    {
      List<object> items = new List<object>();
      for (int index = 0; index < this.Tintscount; ++index)
        items.Add((object) index);
      List<object> listofColors = new List<object>();
      foreach (int num in (VehicleColor[]) Enum.GetValues(typeof (VehicleColor)))
        listofColors.Add((object) (VehicleColor) num);
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.Options, "Options");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.Options, "Customization");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.Options, "Cab Colours");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem CabColor1 = new UIMenuListItem("Primary Color ", listofColors, 0);
      uiMenu3.AddItem((UIMenuItem) CabColor1);
      UIMenuItem GetCabColor1 = new UIMenuItem("Get Cab Primary Color");
      uiMenu3.AddItem(GetCabColor1);
      UIMenuItem GetCabColor2 = new UIMenuItem("Get Cab Secondary Color");
      uiMenu3.AddItem(GetCabColor2);
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.Options, "TrailerColours");
      this.GUIMenus.Add(uiMenu4);
      UIMenuListItem list = new UIMenuListItem("Tint ", items, 0);
      UIMenuListItem uiMenuListItem = new UIMenuListItem("Primary Color ", listofColors, 0);
      uiMenu4.AddItem((UIMenuItem) CabColor1);
      UIMenuItem GetTrailerColor1 = new UIMenuItem("Get Trailer Primary Color");
      uiMenu4.AddItem(GetTrailerColor1);
      UIMenuItem GetTrailerColor2 = new UIMenuItem("Get Trailer Secondary Color");
      uiMenu4.AddItem(GetTrailerColor2);
      uiMenu2.AddItem((UIMenuItem) list);
      UIMenuItem noLivery = new UIMenuItem("No Livery");
      uiMenu2.AddItem(noLivery);
      UIMenuItem Buy = new UIMenuItem("Buy Livery: $10,000");
      uiMenu2.AddItem(Buy);
      UIMenuItem noweapons = new UIMenuItem("No weapons ");
      uiMenu2.AddItem(noweapons);
      UIMenuItem Weapons1 = new UIMenuItem("Front Turret");
      uiMenu2.AddItem(Weapons1);
      UIMenuItem Weapons2 = new UIMenuItem("Front, Rear, Side Turrets");
      uiMenu2.AddItem(Weapons2);
      UIMenuItem Options1 = new UIMenuItem("Open Cargo Bay");
      uiMenu1.AddItem(Options1);
      UIMenuItem Options0 = new UIMenuItem("Close Cargo Bay");
      uiMenu1.AddItem(Options0);
      UIMenuItem Options2 = new UIMenuItem("Enter Cargo Bay");
      uiMenu1.AddItem(Options2);
      UIMenuItem Options3 = new UIMenuItem("AutoPilot");
      uiMenu1.AddItem(Options3);
      UIMenuItem Options4 = new UIMenuItem("Re-Attach Trailer");
      uiMenu1.AddItem(Options4);
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == GetTrailerColor1 && (Entity) this.Trailer != (Entity) null)
        {
          int index1 = CabColor1.Index;
          Vehicle trailer = this.Trailer;
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (MobileOperationsCenter)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num = (int) MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__0.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__0, listofColors[index1]);
          trailer.PrimaryColor = (VehicleColor) num;
          this.TrailerPrimary = this.Trailer.PrimaryColor;
          this.Config.SetValue<VehicleColor>("Trailer", "Primary", this.TrailerPrimary);
          this.Config.Save();
        }
        if (item != GetTrailerColor2 || !((Entity) this.Trailer != (Entity) null))
          return;
        int index2 = CabColor1.Index;
        Vehicle trailer1 = this.Trailer;
        // ISSUE: reference to a compiler-generated field
        if (MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (MobileOperationsCenter)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        int num1 = (int) MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__1.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__1, listofColors[index2]);
        trailer1.SecondaryColor = (VehicleColor) num1;
        this.TrailerSecondary = this.Trailer.SecondaryColor;
        this.Config.SetValue<VehicleColor>("Trailer", "Secondary", this.TrailerSecondary);
        this.Config.Save();
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == GetCabColor1 && (Entity) this.Cab != (Entity) null)
        {
          int index1 = CabColor1.Index;
          Vehicle cab = this.Cab;
          // ISSUE: reference to a compiler-generated field
          if (MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (MobileOperationsCenter)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num = (int) MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__2.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__2, listofColors[index1]);
          cab.PrimaryColor = (VehicleColor) num;
          this.CabPrimary = this.Cab.PrimaryColor;
          this.Config.SetValue<VehicleColor>("CAB", "Primary", this.CabPrimary);
          this.Config.Save();
        }
        if (item != GetCabColor2 || !((Entity) this.Cab != (Entity) null))
          return;
        int index2 = CabColor1.Index;
        Vehicle cab1 = this.Cab;
        // ISSUE: reference to a compiler-generated field
        if (MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (MobileOperationsCenter)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        int num1 = (int) MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__3.Target((CallSite) MobileOperationsCenter.\u003C\u003Eo__141.\u003C\u003Ep__3, listofColors[index2]);
        cab1.SecondaryColor = (VehicleColor) num1;
        this.CabSecondary = this.Cab.SecondaryColor;
        this.Config.SetValue<VehicleColor>("CAB", "Secondary", this.CabSecondary);
        this.Config.Save();
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == noLivery && (Entity) this.Trailer != (Entity) null)
        {
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Trailer.Handle, (InputArgument) 0);
          this.Trailer.SetMod(VehicleMod.Livery, -1, true);
          this.Livery = -1;
          this.Config.SetValue<int>("Setup", "Livery", this.Livery);
          this.Config.Save();
        }
        if (item == noweapons)
        {
          Vehicle trailer = this.Trailer;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) trailer.Handle, (InputArgument) 0);
          trailer.SetMod(VehicleMod.Roof, -1, true);
          this.Weapons = -1;
          this.Config.SetValue<int>("Setup", "Weapons", this.Weapons);
          this.Config.Save();
        }
        if (item == Weapons2)
        {
          Vehicle trailer = this.Trailer;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) trailer.Handle, (InputArgument) 0);
          trailer.SetMod(VehicleMod.Roof, 1, true);
          this.Weapons = 1;
          this.Config.SetValue<int>("Setup", "Weapons", this.Weapons);
          this.Config.Save();
        }
        if (item == Weapons1)
        {
          Vehicle trailer = this.Trailer;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) trailer.Handle, (InputArgument) 0);
          trailer.SetMod(VehicleMod.Roof, 0, true);
          this.Weapons = 0;
          this.Config.SetValue<int>("Setup", "Weapons", this.Weapons);
          this.Config.Save();
        }
        if (item != Buy)
          return;
        int index1 = list.Index;
        Vehicle trailer1 = this.Trailer;
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) trailer1.Handle, (InputArgument) 0);
        trailer1.SetMod(VehicleMod.Livery, list.Index, true);
        this.Livery = list.Index;
        this.Config.SetValue<int>("Setup", "Livery", this.Livery);
        this.Config.Save();
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Options3)
          ;
        if (item == Options1 && (Entity) this.Trailer != (Entity) null)
          this.Trailer.OpenDoor(VehicleDoor.Trunk, false, false);
        if (item == Options0 && (Entity) this.Trailer != (Entity) null)
          this.Trailer.CloseDoor(VehicleDoor.Trunk, false);
        if (item == Options4)
          Function.Call(Hash._0x3C7D42D58F770B54, (InputArgument) this.Cab, (InputArgument) this.Trailer, (InputArgument) 10);
        if (item == Options3 && ((Entity) this.Cab != (Entity) null && (Entity) this.Trailer != (Entity) null))
        {
          if (this.Cab.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
          {
            Game.Player.Character.SetIntoVehicle(this.Trailer, VehicleSeat.Driver);
            this.Cab.CreatePedOnSeat(VehicleSeat.Driver, (GTA.Model) PedHash.Agent14);
            Ped pedOnSeat = this.Cab.GetPedOnSeat(VehicleSeat.Driver);
            Function.Call(Hash._0x90D2156198831D69, (InputArgument) pedOnSeat, (InputArgument) true);
            Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
            Function.Call(Hash._0x9F8AA94D6D97DBF4, (InputArgument) pedOnSeat, (InputArgument) 1);
            Function.Call(Hash._0x70A2D1137C8ED7C9, (InputArgument) pedOnSeat, (InputArgument) 0, (InputArgument) 0);
            Function.Call(Hash._0x9F7794730795E019, (InputArgument) pedOnSeat, (InputArgument) 17, (InputArgument) 1);
            Vector3 waypointPosition = World.GetWaypointPosition();
            this.Cab.GetPedOnSeat(VehicleSeat.Driver).Task.DriveTo(this.Cab, waypointPosition, 20f, 80f, 6);
          }
          else if (this.Trailer.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
          {
            this.Cab.GetPedOnSeat(VehicleSeat.Driver).Task.LeaveVehicle(this.Cab, LeaveVehicleFlags.LeaveDoorOpen);
            Game.Player.Character.SetIntoVehicle(this.Cab, VehicleSeat.Driver);
          }
        }
        if (item != Options2)
          return;
        if ((Entity) this.Cab != (Entity) null)
        {
          try
          {
            this.MOCPosSave = this.Cab.Position;
            this.Spawn = this.MOCPosSave;
            this.X = this.Spawn.X;
            this.Config.SetValue<float>("Setup", "X", this.X);
            this.Y = this.Spawn.Y;
            this.Config.SetValue<float>("Setup", "Y", this.Y);
            this.Z = this.Spawn.Z;
            this.Config.SetValue<float>("Setup", "Z", this.Z);
            this.Config.SetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
            this.Config.Save();
            this.Cab.FreezePosition = true;
            this.IsInInterior = true;
            this.GetPositions();
            Game.Player.Character.Position = this.ExitMoc;
            this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Storage//Vehicle.ini");
            if (this.SaveLoad.VehicleName != "null")
              this.SaveLoad.LoadMocVehicle();
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Critical Error~w~ : Oopps! somthing has gone wrong, please retry, ifGTAV has just loaded, this is normal, if it continues after please contact ~g~HKH191~w~");
          }
        }
      });
    }

    public void TeleportintoCab() => Game.Player.Character.SetIntoVehicle(this.Cab, VehicleSeat.Driver);

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

    public void SpawnMOC()
    {
      try
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
        if ((Entity) this.Cab != (Entity) null)
          this.Cab.Delete();
        if ((Entity) this.Trailer != (Entity) null)
          this.Trailer.Delete();
        this.MOCPosSave = this.Config.GetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
        this.Spawn = this.MOCPosSave;
        this.X = this.Config.GetValue<float>("Setup", "X", this.X);
        this.Y = this.Config.GetValue<float>("Setup", "Y", this.Y);
        this.Z = this.Config.GetValue<float>("Setup", "Z", this.Z);
        Script.Wait(10);
        if (this.Config.GetValue<string>("Setup", "VehicleToUse", this.VehicleToUse) == "HAULER2")
          this.Cab = World.CreateVehicle(this.RequestModel(VehicleHash.Hauler2), new Vector3(this.X, this.Y, this.Z));
        if (this.Config.GetValue<string>("Setup", "VehicleToUse", this.VehicleToUse) == "PHANTOM3")
          this.Cab = World.CreateVehicle(this.RequestModel(VehicleHash.Phantom3), new Vector3(this.X, this.Y, this.Z));
        if (this.Config.GetValue<string>("Setup", "VehicleToUse", this.VehicleToUse) == "PHANTOM2")
          this.Cab = World.CreateVehicle(this.RequestModel(VehicleHash.Phantom2), new Vector3(this.X, this.Y, this.Z));
        this.Trailer = World.CreateVehicle(this.RequestModel(VehicleHash.TrailerLarge), this.Cab.GetOffsetInWorldCoords(new Vector3(0.0f, 10f, 0.0f)));
        this.Cab.PrimaryColor = this.CabPrimary;
        this.Cab.SecondaryColor = this.CabSecondary;
        Function.Call(Hash._0x3C7D42D58F770B54, (InputArgument) this.Cab, (InputArgument) this.Trailer, (InputArgument) 10);
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.Trailer.Handle, (InputArgument) 0);
        this.Trailer.SetMod(VehicleMod.Roof, this.Weapons, true);
        this.Trailer.SetMod(VehicleMod.Livery, this.Livery, true);
        this.Trailer.PrimaryColor = this.TrailerPrimary;
        this.Trailer.SecondaryColor = this.TrailerSecondary;
        this.Created = true;
        this.WheelsSaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
        this.WheelsSaveLoad.SaveWithoutDelete();
        this.WheelsSaveLoad.Load(this.Cab);
        Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) this.Cab, (InputArgument) this.WheelsSaveLoad.WheelType);
        this.Cab.WheelType = (VehicleWheelType) this.WheelsSaveLoad.WheelType;
        this.Trailer.WheelType = (VehicleWheelType) this.WheelsSaveLoad.WheelType;
        this.Cab.SetMod(VehicleMod.FrontWheels, this.WheelsSaveLoad.FrontWheelsId, true);
        this.Cab.SetMod(VehicleMod.BackWheels, this.WheelsSaveLoad.BackWheelsId, true);
        this.Trailer.SetMod(VehicleMod.FrontWheels, this.WheelsSaveLoad.FrontWheelsId, true);
        this.Trailer.SetMod(VehicleMod.BackWheels, this.WheelsSaveLoad.BackWheelsId, true);
        this.Trailer.RimColor = this.WheelsSaveLoad.Wheelcolour;
        this.Trailer.DashboardColor = this.WheelsSaveLoad.DashBoardColour;
        this.Trailer.TireSmokeColor = this.WheelsSaveLoad.TireSmokeColor;
        this.Trailer.TrimColor = this.WheelsSaveLoad.TrimColor;
        this.Trailer.CanTiresBurst = this.WheelsSaveLoad.BulletProofTires;
        this.Trailer.ToggleMod(VehicleToggleMod.TireSmoke, this.WheelsSaveLoad.TireSmoke);
        Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) this.Trailer, (InputArgument) this.WheelsSaveLoad.WheelType);
        if (!((Entity) this.Cab != (Entity) null))
          return;
        this.Cab.Heading = this.VHeading;
      }
      catch (NullReferenceException ex)
      {
        UI.Notify("~r~Gunrunning Business - Working MOC: Somthing has gone wrong with the mod please reload the mod, please try again, if this persitsts contact HKH191 on Discord ~w~");
      }
    }

    private void ChangeBlipPos(float x, float y, float z)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
      this.X = this.Config.GetValue<float>("Setup", "X", this.X);
      this.Y = this.Config.GetValue<float>("Setup", "Y", this.Y);
      this.Z = this.Config.GetValue<float>("Setup", "Z", this.Z);
      UI.Notify("Pos3 " + this.X.ToString() + " " + this.Y.ToString() + " " + this.Z.ToString());
      this.MOCBlip.Position = new Vector3(this.X, this.Y, this.Z);
      UI.Notify("Pos Save" + this.MOCBlip.Position.ToString());
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

    public void GetPositions()
    {
      int num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
      if (this.MocBay == 1 && this.MocBay2 == 2 && this.MocBay3 == 8)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3008.938f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3005.438f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.811f, (InputArgument) -3005.638f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = 176f;
        this.Chair2.Heading = -1f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 6)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3008.938f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3005.438f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.811f, (InputArgument) -3005.638f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = 176f;
        this.Chair2.Heading = -1f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 8)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3008.938f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3005.438f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.811f, (InputArgument) -3005.638f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = 176f;
        this.Chair2.Heading = -1f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 1 && this.MocBay2 == 5 && this.MocBay3 == 0)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.151f, (InputArgument) -3009.138f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.651f, (InputArgument) -3008.938f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.451f, (InputArgument) -3011.84f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = -6f;
        this.Chair2.Heading = 168f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 7)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3008.938f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3005.438f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.811f, (InputArgument) -3005.638f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = 176f;
        this.Chair2.Heading = -1f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 1 && this.MocBay2 == 2 && this.MocBay3 == 7)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3008.938f, (InputArgument) -39.19909f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3005.438f, (InputArgument) -39.19909f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.811f, (InputArgument) -3005.638f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = 176f;
        this.Chair2.Heading = -1f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 1 && this.MocBay2 == 3 && this.MocBay3 == 7)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.173f, (InputArgument) -3009.273f, (InputArgument) -39.19909f, (InputArgument) -39.19909f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.451f, (InputArgument) -3011.84f, (InputArgument) -39.19909f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.651f, (InputArgument) -3008.938f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = -11f;
        this.Chair2.Heading = 171f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 1 && this.MocBay2 == 3 && this.MocBay3 == 6)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3008.938f, (InputArgument) -39.19909f, (InputArgument) -39.19909f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3005.438f, (InputArgument) -39.19909f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        num = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a");
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.811f, (InputArgument) -3005.638f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = 176f;
        this.Chair2.Heading = -1f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 1 && this.MocBay2 == 3 && this.MocBay3 == 8)
      {
        this.Chair1 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3008.938f, (InputArgument) -39.19909f, (InputArgument) -39.19909f, (InputArgument) -39.42f, (InputArgument) 1.35f, (InputArgument) num, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair2 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1102.111f, (InputArgument) -3005.438f, (InputArgument) -39.19909f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair3 = Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) 1104.811f, (InputArgument) -3005.638f, (InputArgument) -39.4f, (InputArgument) 1.35f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_highendchair_gr_01a"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        this.Chair1.Heading = 176f;
        this.Chair2.Heading = -1f;
        this.Chair3.Heading = 175f;
      }
      if (this.MocBay == 0 && this.MocBay2 == 4 && this.MocBay3 == 8)
      {
        this.ExitMoc = new Vector3(1103.423f, -3009.289f, -40f);
        this.ExitOutside = new Vector3(1103.768f, -2986.985f, -40f);
        this.CabOptions = new Vector3(1104.476f, -3001.171f, -40f);
        this.Gunlockerpos = new Vector3(1102.159f, -2999.108f, -40f);
        this.GunLockerMarker = new Vector3(1102.159f, -2999.108f, -40f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Heading = 0.0f;
        this.VehicleinCargoBay.Position = new Vector3(1103.518f, -2990.131f, -40f);
      }
      else if (this.MocBay == 0 && this.MocBay2 == 5 && this.MocBay3 == 0)
      {
        this.ExitMoc = new Vector3(1103.548f, -3012.562f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(1106.22f, -2992.623f, -40f);
        this.Gunlockerpos = new Vector3(1101.537f, -3002.34f, -40f);
        this.GunLockerMarker = new Vector3(1101.537f, -3002.34f, -40f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Heading = 0.0f;
        this.VehicleinCargoBay.Position = new Vector3(1103.498f, -2996.4f, -40f);
      }
      else if (this.MocBay == 1 && this.MocBay2 == 2 && this.MocBay3 == 8)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(0.0f, 0.0f, 0.0f);
        this.Gunlockerpos = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Heading = 0.0f;
        this.VehicleinCargoBay.Position = new Vector3(1103.518f, -2990.131f, -40f);
      }
      else if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 6)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(1104.608f, -2999.139f, -40f);
        this.Gunlockerpos = new Vector3(1102.228f, -2999.026f, -40f);
        this.GunLockerMarker = new Vector3(1102.228f, -2999.026f, -40f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 8)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2987.002f, -40f);
        this.CabOptions = new Vector3(1104.476f, -3001.171f, -40f);
        this.Gunlockerpos = new Vector3(1102.228f, -2999.026f, -40f);
        this.GunLockerMarker = new Vector3(1102.228f, -2999.026f, -40f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Heading = 0.0f;
        this.VehicleinCargoBay.Position = new Vector3(1103.518f, -2990.131f, -40f);
      }
      else if (this.MocBay == 1 && this.MocBay2 == 5 && this.MocBay3 == 0)
      {
        this.ExitMoc = new Vector3(1103.548f, -3012.562f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(1106.22f, -2992.623f, -40f);
        this.Gunlockerpos = new Vector3(1101.537f, -3002.34f, -40f);
        this.GunLockerMarker = new Vector3(1101.537f, -3002.34f, -40f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Heading = 0.0f;
        this.VehicleinCargoBay.Position = new Vector3(1103.498f, -2996.4f, -40f);
      }
      else if (this.MocBay == 0 && this.MocBay2 == 4 && this.MocBay3 == 7)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(1104.476f, -3001.171f, -40f);
        this.Gunlockerpos = new Vector3(1102.404f, -2999.357f, -40f);
        this.GunLockerMarker = new Vector3(1102.404f, -2999.357f, -40f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 4 && this.MocBay3 == 7)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(1104.476f, -3001.171f, -40f);
        this.Gunlockerpos = new Vector3(1102.404f, -2999.357f, -40f);
        this.GunLockerMarker = new Vector3(1102.404f, -2999.357f, -40f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 2 && this.MocBay3 == 7)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(0.0f, 0.0f, 0.0f);
        this.Gunlockerpos = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Delete();
      }
      else if (this.MocBay == 0 && this.MocBay2 == 3 && this.MocBay3 == 8)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(0.0f, 0.0f, 0.0f);
        this.Gunlockerpos = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Heading = 0.0f;
        this.VehicleinCargoBay.Position = new Vector3(1103.518f, -2990.131f, -40f);
      }
      else if (this.MocBay == 0 && this.MocBay2 == 3 && this.MocBay3 == 7)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(0.0f, 0.0f, 0.0f);
        this.Gunlockerpos = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 3 && this.MocBay3 == 7)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(0.0f, 0.0f, 0.0f);
        this.Gunlockerpos = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Delete();
      }
      else if (this.MocBay == 1 && this.MocBay2 == 3 && this.MocBay3 == 6)
      {
        this.ExitMoc = new Vector3(1103.617f, -3009.279f, -40f);
        this.ExitOutside = new Vector3(1103.577f, -2990.219f, -40f);
        this.CabOptions = new Vector3(0.0f, 0.0f, 0.0f);
        this.Gunlockerpos = new Vector3(0.0f, 0.0f, 0.0f);
        this.GunLockerMarker = new Vector3(0.0f, 0.0f, 0.0f);
        if (!((Entity) this.VehicleinCargoBay != (Entity) null))
          return;
        this.VehicleinCargoBay.Delete();
      }
      else
      {
        if (this.MocBay != 1 || this.MocBay2 != 3 || this.MocBay3 != 8)
          return;
        this.ExitMoc = new Vector3(1103.423f, -3009.289f, -40f);
        this.ExitOutside = new Vector3(1103.768f, -2986.985f, -40f);
        this.CabOptions = new Vector3(1104.543f, -3001.188f, -40f);
        this.Gunlockerpos = new Vector3(1102.159f, -2999.108f, -40f);
        this.GunLockerMarker = new Vector3(1102.159f, -2999.108f, -40f);
        if ((Entity) this.VehicleinCargoBay != (Entity) null)
        {
          this.VehicleinCargoBay.Heading = 0.0f;
          this.VehicleinCargoBay.Position = new Vector3(1103.518f, -2990.131f, -40f);
        }
      }
    }

    private void OnTick(object sender, EventArgs e)
    {
      if (!this.IsInInterior)
        this.CreatedChairs = false;
      if (this.IsInInterior)
      {
        if (this.SittinginSeat && !this.IsUsingSam)
        {
          int num = new System.Random().Next(0, 100);
          if (num < 33)
          {
            if (Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1) >= 1065353216)
            {
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              MobileOperationsCenter.LoadDict(dict);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "idle_a", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "idle_a", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "idle_a_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            }
          }
          if (num >= 33 && num < 66)
          {
            if (Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1) >= 1065353216)
            {
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              MobileOperationsCenter.LoadDict(dict);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "idle_b", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "idle_b", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "idle_b_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            }
          }
          if (num >= 66 && num < 100)
          {
            if (Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1) >= 1065353216)
            {
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              MobileOperationsCenter.LoadDict(dict);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "idle_c", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "idle_c", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "idle_c_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            }
          }
        }
        if (!this.CreatedChairs)
        {
          Script.Wait(1000);
          this.CreatedChairs = true;
          this.CheckOcci("scripts//OpenCommandCenterInteriors.ini");
          this.MocBay = this.CheckOcciConfig.GetValue<int>("MOC", "ModBay1", this.MocBay);
          this.MocBay2 = this.CheckOcciConfig.GetValue<int>("MOC", "ModBay2", this.MocBay2);
          this.MocBay3 = this.CheckOcciConfig.GetValue<int>("MOC", "ModBay3", this.MocBay3);
          this.GetPositions();
        }
      }
      if (this.IsInInterior)
        this.GetPositions();
      if (this.MocBay == 1)
      {
        if ((Entity) this.Chair1 != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.Chair1.Position) < 1.35000002384186)
        {
          if (!this.SittinginSeat)
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to sit in seat");
          if (this.SittinginSeat)
          {
            this.DisplayHelpTextThisFrame("~INPUT_COVER~ exit, ~INPUT_CONTEXT~ to use turret");
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              MobileOperationsCenter.LoadDict(dict);
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) this.ExitChair.Position.X, (InputArgument) this.ExitChair.Position.Y, (InputArgument) this.ExitChair.Position.Z, (InputArgument) 3f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_gr_console_01"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0), (InputArgument) num, (InputArgument) "computer_enter_control", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(3000);
              this.CanFire = true;
              Game.Player.Character.IsVisible = false;
              this.IsUsingSam = true;
              Vector3 position = this.Trailer.Position;
              position.Z += 4f;
              position.Y -= 6f;
              Game.Player.Character.Position = position;
              this.IsInInterior = false;
              position.X += 5f;
              this.Trailer.IsVisible = true;
              this.Trailer.IsInvincible = true;
              this.Trailer.FreezePosition = false;
              this.Cab.IsVisible = true;
              this.Cab.IsInvincible = true;
              this.Cab.FreezePosition = false;
              Game.Player.Character.IsInvincible = true;
              this.DroneCam = World.CreateCamera(this.TurretCamB, new Vector3(0.0f, 0.0f, 0.0f), 30f);
              this.DroneCam.FieldOfView = 30f;
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              World.RenderingCamera = this.DroneCam;
              UI.Notify("~b~W, A, S, D~w~ = Rotate ,~b~Space~w~ = FireA,   ~b~Shift~w~ = Precision, ~b~X~w~ = Change Precision : (LVL :" + this.PrecisionLevel.ToString() + ", AMT : " + this.AmounttoDecrease.ToString() + ") ~b~Q~w~  = Exit");
            }
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            if (!this.SittinginSeat)
            {
              this.Chairin = 1;
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop chair1 = this.Chair1;
              this.ExitChair = this.Chair1;
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chair1.Position.X, (InputArgument) chair1.Position.Y, (InputArgument) chair1.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chair1.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "enter_left", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "enter_left", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chair1, (InputArgument) this.Scene1, (InputArgument) "enter_left_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(100);
              this.SittinginSeat = true;
            }
            else if (this.SittinginSeat)
            {
              this.SittinginSeat = false;
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "exit_left", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "exit_left", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "exit_left_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(3000);
              Game.Player.Character.Task.ClearAll();
            }
          }
        }
        if ((Entity) this.Chair2 != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.Chair2.Position) < 1.35000002384186)
        {
          if (!this.SittinginSeat)
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to sit in seat");
          if (this.SittinginSeat)
          {
            this.DisplayHelpTextThisFrame("~INPUT_COVER~ exit, ~INPUT_CONTEXT~ to use turret");
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              MobileOperationsCenter.LoadDict(dict);
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) this.ExitChair.Position.X, (InputArgument) this.ExitChair.Position.Y, (InputArgument) this.ExitChair.Position.Z, (InputArgument) 3f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_gr_console_01"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0), (InputArgument) num, (InputArgument) "computer_enter_control", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(3000);
              this.CanFire = true;
              Game.Player.Character.IsVisible = false;
              this.IsUsingSam = true;
              Vector3 position = this.Trailer.Position;
              position.Z += 4f;
              position.Y -= 6f;
              Game.Player.Character.Position = position;
              this.IsInInterior = false;
              position.X += 5f;
              this.Trailer.IsVisible = true;
              this.Trailer.IsInvincible = true;
              this.Trailer.FreezePosition = true;
              this.Cab.IsVisible = true;
              this.Cab.IsInvincible = true;
              this.Cab.FreezePosition = false;
              Game.Player.Character.IsInvincible = true;
              this.DroneCam = World.CreateCamera(this.TurretCamA, new Vector3(0.0f, 0.0f, 0.0f), 30f);
              this.DroneCam.FieldOfView = 30f;
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              World.RenderingCamera = this.DroneCam;
              UI.Notify("~b~W, A, S, D~w~ = Rotate ,~b~Space~w~ = FireA,   ~b~Shift~w~ = Precision, ~b~X~w~ = Change Precision : (LVL :" + this.PrecisionLevel.ToString() + ", AMT : " + this.AmounttoDecrease.ToString() + ") ~b~Q~w~  = Exit");
            }
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            if (!this.SittinginSeat)
            {
              this.Chairin = 2;
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop chair2 = this.Chair2;
              this.ExitChair = this.Chair2;
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chair2.Position.X, (InputArgument) chair2.Position.Y, (InputArgument) chair2.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chair2.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "enter_left", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "enter_left", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chair2, (InputArgument) this.Scene1, (InputArgument) "enter_left_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(100);
              this.SittinginSeat = true;
            }
            else if (this.SittinginSeat)
            {
              this.SittinginSeat = false;
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "exit_left", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "exit_left", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "exit_left_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(3000);
              Game.Player.Character.Task.ClearAll();
            }
          }
        }
        if ((Entity) this.Chair3 != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.Chair3.Position) < 1.35000002384186)
        {
          if (!this.SittinginSeat)
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to sit in seat");
          if (this.SittinginSeat)
          {
            this.DisplayHelpTextThisFrame("~INPUT_COVER~ exit, ~INPUT_CONTEXT~ to use turret");
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              MobileOperationsCenter.LoadDict(dict);
              int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) this.ExitChair.Position.X, (InputArgument) this.ExitChair.Position.Y, (InputArgument) this.ExitChair.Position.Z, (InputArgument) 3f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_gr_console_01"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0), (InputArgument) num, (InputArgument) "computer_enter_control", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(3000);
              this.CanFire = true;
              Game.Player.Character.IsVisible = false;
              this.IsUsingSam = true;
              Vector3 position = this.Trailer.Position;
              position.Z += 4f;
              position.Y -= 6f;
              Game.Player.Character.Position = position;
              this.IsInInterior = false;
              position.X += 5f;
              this.Trailer.IsVisible = true;
              this.Trailer.IsInvincible = true;
              this.Trailer.FreezePosition = false;
              this.Cab.IsVisible = true;
              this.Cab.IsInvincible = true;
              this.Cab.FreezePosition = false;
              Game.Player.Character.IsInvincible = true;
              this.DroneCam = World.CreateCamera(this.TurretCamC, new Vector3(0.0f, 0.0f, 0.0f), 30f);
              this.DroneCam.FieldOfView = 30f;
              Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
              World.RenderingCamera = this.DroneCam;
              UI.Notify("~b~W, A, S, D~w~ = Rotate ,~b~Space~w~ = FireA,   ~b~Shift~w~ = Precision, ~b~X~w~ = Change Precision : (LVL :" + this.PrecisionLevel.ToString() + ", AMT : " + this.AmounttoDecrease.ToString() + ") ~b~Q~w~  = Exit");
            }
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            if (!this.SittinginSeat)
            {
              this.Chairin = 3;
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop chair3 = this.Chair3;
              this.ExitChair = this.Chair3;
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chair3.Position.X, (InputArgument) chair3.Position.Y, (InputArgument) chair3.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chair3.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "enter", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chair3, (InputArgument) this.Scene1, (InputArgument) "enter_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(100);
              this.SittinginSeat = true;
            }
            else if (this.SittinginSeat)
            {
              this.SittinginSeat = false;
              string dict = "anim@amb@trailer@turret_controls@";
              MobileOperationsCenter.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "exit", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "exit_chair", (InputArgument) MobileOperationsCenter.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Script.Wait(3000);
              Game.Player.Character.Task.ClearAll();
            }
          }
        }
      }
      if ((Entity) this.Cab != (Entity) null)
      {
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
          this.IsInCab = false;
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (Entity) Game.Player.Character.CurrentVehicle == (Entity) this.Cab && !this.IsInCab)
        {
          this.IsInCab = true;
          this.Cab.IsDriveable = true;
        }
      }
      this.OnKeyDown();
      if (this.IsInInterior)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to open Gun Locker");
        if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 80.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.GunLockerMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 1f), this.MarkerColor);
      }
      if (this.IsInInterior)
      {
        Vector3 vector3 = new Vector3(1103.5f, -2990.4f, -40f);
        World.DrawMarker(MarkerType.VerticalCylinder, this.ExitOutside, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 1f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitOutside) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ To Exit MOC");
      }
      if ((Entity) this.Trailer != (Entity) null && (double) this.Trailer.Speed < 10.0)
      {
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
        {
          Vector3 offsetInWorldCoords = this.Trailer.GetOffsetInWorldCoords(new Vector3(0.0f, -8f, -3f));
          if ((double) World.GetDistance(Game.Player.Character.Position, offsetInWorldCoords) < 40.0)
            World.DrawMarker(MarkerType.VerticalCylinder, offsetInWorldCoords, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), this.MarkerColor);
          if ((double) World.GetDistance(Game.Player.Character.Position, offsetInWorldCoords) < 2.0)
          {
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to Enter the cargo bay, or ~INPUT_CONTEXT~ to enter Vehicle Menu");
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              this.VehSpawn = this.Trailer.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, -3f));
              if (!this.VMmainMenu.Visible)
                this.VMmainMenu.Visible = true;
            }
          }
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 offsetInWorldCoords = this.Trailer.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, -3f));
          if ((double) World.GetDistance(Game.Player.Character.Position, offsetInWorldCoords) < 10.0)
            World.DrawMarker(MarkerType.VerticalCylinder, offsetInWorldCoords, Vector3.Zero, Vector3.Zero, new Vector3(7f, 7f, 1.2f), this.MarkerColor);
          if ((double) World.GetDistance(Game.Player.Character.Position, offsetInWorldCoords) < 3.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to Enter the cargo bay with this vehicle");
        }
      }
      if (this.TurretTimer >= 0)
        --this.TurretTimer;
      if (this.TurretTimer <= 0)
        this.CanFire = true;
      if ((Entity) this.Trailer != (Entity) null)
      {
        this.TurretCamA = this.Trailer.GetOffsetInWorldCoords(new Vector3(0.0f, 8.4f, 1f));
        this.TurretCamB = this.Trailer.GetOffsetInWorldCoords(new Vector3(2.5f, -8f, 1f));
        this.TurretCamC = this.Trailer.GetOffsetInWorldCoords(new Vector3(-2.5f, -8f, 1f));
      }
      if (!this.IsUsingSam && this.IsInInterior && ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1102.099f, -3008.6f, -39f)) < 2.0 && this.Weapons != -1))
        this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~, ~INPUT_CONTEXT~ or ~INPUT_VEH_DUCK~ to Operate an MOC Turret");
      if (this.IsUsingSam)
      {
        MobileOperationsCenter.DrawScaleformTurret();
        Vector3 position1 = this.DroneCam.Position;
        Vector3 position2 = Game.Player.Character.Position;
        Vector3 position3 = this.DroneCam.Position;
        Vector3 rotation = this.DroneCam.Rotation;
        float num1 = rotation.Z * ((float) System.Math.PI / 180f);
        float num2 = rotation.X * ((float) System.Math.PI / 180f);
        float num3 = (float) System.Math.Abs(System.Math.Cos((double) num2));
        Vector3 vector3 = new Vector3((float) (System.Math.Sin((double) num1) * (double) num3 * -1.0), (float) System.Math.Cos((double) num1) * num3, (float) System.Math.Sin((double) num2));
        Vector3 hitCoords = World.Raycast(position3, position3 + vector3 * 100000f, IntersectOptions.Everything).HitCoords;
        float z = hitCoords.Z - 25f;
        World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(hitCoords.X, hitCoords.Y, z), Vector3.Zero, Vector3.Zero, new Vector3(0.5f, 0.5f, 50f), Color.Blue);
        World.DrawMarker(MarkerType.VerticalCylinder, hitCoords, Vector3.Zero, Vector3.Zero, new Vector3(0.6f, 0.6f, 1f), Color.Red);
        if (this.Timer != 300)
          ++this.Timer;
        if (this.Timer == 50)
        {
          ++this.Timer;
          this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to Exit ~INPUT_Jump~ to Fire");
        }
        if (this.Timer == 100)
        {
          ++this.Timer;
          this.DisplayHelpTextThisFrame("~INPUT_MOVE_UP_ONLY~ , ~INPUT_VEH_BRAKE~ , ~INPUT_MOVE_LEFT_ONLY~ , ~INPUT_MOVE_RIGHT_ONLY~ to move");
        }
        if (this.Timer == 150)
          this.DisplayHelpTextThisFrame("Press ~INPUT_SPRINT~ to Toggle Precision mode, Precision: (LVL :" + this.PrecisionLevel.ToString() + ", AMT: " + this.AmounttoDecrease.ToString() + " )");
        if (this.Timer == 200)
          this.DisplayHelpTextThisFrame("Press ~INPUT_SPRINT~ to Toggle Precision mode, Precision: (LVL :" + this.PrecisionLevel.ToString() + ", AMT: " + this.AmounttoDecrease.ToString() + " )");
        if (this.Timer == 250)
        {
          ++this.Timer;
          this.DisplayHelpTextThisFrame("Press ~INPUT_VEH_HEADLIGHT~ to Switch turret mode");
        }
        if (this.Timer == 300)
          this.Timer = 0;
      }
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      if (this.modMenuPool2 != null && this.modMenuPool2.IsAnyMenuOpen())
        this.modMenuPool2.ProcessMenus();
      if (this.GunmodMenuPool != null && this.GunmodMenuPool.IsAnyMenuOpen())
        this.GunmodMenuPool.ProcessMenus();
      if (this.VMmodMenuPool != null && this.VMmodMenuPool.IsAnyMenuOpen())
        this.VMmodMenuPool.ProcessMenus();
      Vector3 vector3_1 = new Vector3();
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-3157f, 1376f, 17f)) < 40.0)
        vector3_1 = this.Chumash;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-3023f, 3334f, 11f)) < 40.0)
        vector3_1 = this.FortZancudo;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-752.755f, 5944f, 19f)) < 40.0)
        vector3_1 = this.Paleto;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-387f, 4337f, 55f)) < 40.0)
        vector3_1 = this.RatonCanyon;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1800.755f, 4705f, 39f)) < 40.0)
        vector3_1 = this.GrapeSeed;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(850.755f, 3026f, 40f)) < 40.0)
        vector3_1 = this.GSD1;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2103.755f, 3322f, 44f)) < 40.0)
        vector3_1 = this.GSD2;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1570f, 2224f, 77f)) < 40.0)
        vector3_1 = this.GSD3;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(40.7f, 2927f, 54f)) < 40.0)
        vector3_1 = this.GSD4;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2488f, 3167f, 48f)) < 40.0)
        vector3_1 = this.GSD5;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(494f, 3015f, 40f)) < 40.0)
        vector3_1 = this.GSD6;
      if (this.ResetMoc)
      {
        if ((Entity) this.Cab != (Entity) null)
          this.Cab.Delete();
        if ((Entity) this.Trailer != (Entity) null)
          this.Trailer.Delete();
        Game.Player.Character.Position = this.Spawn;
        this.X = this.Spawn.X;
        this.Config.SetValue<float>("Setup", "X", this.X);
        this.Y = this.Spawn.Y;
        this.Config.SetValue<float>("Setup", "Y", this.Y);
        this.Z = this.Spawn.Z;
        this.Config.SetValue<float>("Setup", "Z", this.Z);
        this.Config.SetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
        this.Config.Save();
        this.Created = false;
        this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
        Game.Player.Character.Position = this.Spawn;
        this.ResetMoc = false;
        Game.Player.Character.SetIntoVehicle(this.Cab, VehicleSeat.Driver);
      }
      if (this.ReadIni)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-3157f, 1376f, 17f)) < 10.0)
        {
          this.Spawn = this.Chumash;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-3023f, 3334f, 11f)) < 10.0)
        {
          this.Spawn = this.FortZancudo;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-752.755f, 5944f, 19f)) < 10.0)
        {
          this.Spawn = this.Paleto;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-387f, 4337f, 55f)) < 10.0)
        {
          this.Spawn = this.RatonCanyon;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1800.755f, 4705f, 39f)) < 10.0)
        {
          this.Spawn = this.GrapeSeed;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(850.755f, 3026f, 40f)) < 10.0)
        {
          this.Spawn = this.GSD1;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2103.755f, 3322f, 44f)) < 10.0)
        {
          this.Spawn = this.GSD2;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1570f, 2224f, 77f)) < 10.0)
        {
          this.Spawn = this.GSD3;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(40.7f, 2927f, 54f)) < 10.0)
        {
          this.Spawn = this.GSD4;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2488f, 3167f, 48f)) < 10.0)
        {
          this.Spawn = this.GSD5;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(494f, 3015f, 40f)) < 10.0)
        {
          this.Spawn = this.GSD6;
          this.MOCPosSave = this.Spawn;
          this.Spawn = this.MOCPosSave;
          this.ResetMoc = true;
          this.ReadIni = false;
        }
      }
      if ((Entity) this.Trailer != (Entity) null && ((double) World.GetDistance(Game.Player.Character.Position, this.Trailer.Position) < 5.0 && !this.Cab.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && this.Trailer.IsDoorOpen(VehicleDoor.Trunk) && this.Trailer.IsAlive))
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ save current vehicle into MOC");
      if ((Entity) this.SaveLoad.SavedVehicle != (Entity) null && ((Entity) this.SaveLoad.SavedVehicle != (Entity) this.Cab && (Entity) this.SaveLoad.SavedVehicle != (Entity) this.Trailer))
        this.VehicleinCargoBay = this.SaveLoad.SavedVehicle;
      if ((Entity) this.VehicleinCargoBay != (Entity) null && this.VehicleinCargoBay.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Use Vehicle, Press ~INPUT_COVER~ to Save Vehicle");
      if (this.IsInInterior)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitMoc) < 100.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.ExitMoc, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 0.8f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CabOptions) < 100.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.CabOptions, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 1f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitMoc) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ Exit the MOC");
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CabOptions) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ To Change Cab Vehicle / Stored Vehicle");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.Spawn) < 100.0 && !this.Created)
        this.SpawnMOC();
      if (!((Entity) this.Trailer != (Entity) null))
        return;
      this.MOCBlip.Position = this.Trailer.Position;
    }

    private void OnKeyDown()
    {
      if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context) && !this.GunmainMenu.Visible)
        this.GunmainMenu.Visible = !this.GunmainMenu.Visible;
      if (this.IsInInterior && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        Vector3 vector3 = new Vector3(1103.5f, -2990.4f, -39f);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitOutside) < 2.0)
        {
          this.IsInInterior = false;
          this.SpawnMOC();
          this.SaveLoad.Delete();
          Game.Player.Character.Position = this.Trailer.GetOffsetInWorldCoords(new Vector3(0.0f, -8f, -3f));
        }
      }
      if ((Entity) this.Trailer != (Entity) null && Game.IsControlJustPressed(2, GTA.Control.Cover) && (double) this.Trailer.Speed < 10.0)
      {
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Trailer.GetOffsetInWorldCoords(new Vector3(0.0f, -8f, -3f))) < 2.0)
          {
            try
            {
              this.MOCPosSave = this.Cab.Position;
              Vector3 mocPosSave = this.MOCPosSave;
              this.X = mocPosSave.X;
              this.Config.SetValue<float>("Setup", "X", this.X);
              this.Y = mocPosSave.Y;
              this.Config.SetValue<float>("Setup", "Y", this.Y);
              this.Z = mocPosSave.Z;
              this.Config.SetValue<float>("Setup", "Z", this.Z);
              this.Config.SetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
              this.Config.Save();
              this.VHeading = this.Cab.Heading;
              this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
              this.Config.Save();
              this.Cab.FreezePosition = true;
              this.IsInInterior = true;
              Game.Player.Character.Task.LeaveVehicle(this.Cab, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = new Vector3(1103.5f, -2990.4f, -39f);
              this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Storage//Vehicle.ini");
              if (this.SaveLoad.VehicleName != "null")
                this.SaveLoad.LoadMocVehicle();
            }
            catch (Exception ex)
            {
              UI.Notify("~r~ Critical Error~w~ : Oopps! somthing has gone wrong, please retry, if GTAV has just loaded, this is normal, if it continues after please contact ~g~HKH191~w~");
            }
          }
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Trailer.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, -3f))) < 3.0)
          {
            try
            {
              this.MOCPosSave = this.Cab.Position;
              Vector3 mocPosSave = this.MOCPosSave;
              this.X = mocPosSave.X;
              this.Config.SetValue<float>("Setup", "X", this.X);
              this.Y = mocPosSave.Y;
              this.Config.SetValue<float>("Setup", "Y", this.Y);
              this.Z = mocPosSave.Z;
              this.Config.SetValue<float>("Setup", "Z", this.Z);
              this.Config.SetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
              this.Config.Save();
              this.VHeading = this.Cab.Heading;
              this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
              this.Config.Save();
              this.IsInInterior = true;
              this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Storage//Vehicle.ini");
              this.SaveLoad.SaveWithoutDelete();
              Script.Wait(50);
              this.GetPositions();
              Game.Player.Character.Position = this.ExitMoc;
              this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Storage//Vehicle.ini");
              if (this.SaveLoad.VehicleName != "null")
                this.SaveLoad.LoadMocVehicle();
              this.IsInInterior = true;
              Game.Player.Character.SetIntoVehicle(this.SaveLoad.SavedVehicle, VehicleSeat.Driver);
            }
            catch (Exception ex)
            {
              UI.Notify("~r~ Critical Error~w~ : Oopps! somthing has gone wrong, please retry, if GTAV has just loaded, this is normal, if it continues after please contact ~g~HKH191~w~");
            }
          }
        }
      }
      if (this.IsUsingSam)
      {
        if (Game.IsControlPressed(2, GTA.Control.VehicleDuck))
        {
          if ((double) this.PrecisionLevel != 15.0)
            ++this.PrecisionLevel;
          else
            this.PrecisionLevel = 0.0f;
          if ((double) this.PrecisionLevel == 0.0)
            this.AmounttoDecrease = 0.01f;
          if ((double) this.PrecisionLevel == 1.0)
            this.AmounttoDecrease = 0.1f;
          if ((double) this.PrecisionLevel == 2.0)
            this.AmounttoDecrease = 0.25f;
          if ((double) this.PrecisionLevel == 3.0)
            this.AmounttoDecrease = 0.5f;
          if ((double) this.PrecisionLevel == 4.0)
            this.AmounttoDecrease = 0.75f;
          if ((double) this.PrecisionLevel == 5.0)
            this.AmounttoDecrease = 1f;
          if ((double) this.PrecisionLevel == 6.0)
            this.AmounttoDecrease = 1.25f;
          if ((double) this.PrecisionLevel == 7.0)
            this.AmounttoDecrease = 1.5f;
          if ((double) this.PrecisionLevel == 8.0)
            this.AmounttoDecrease = 1.75f;
          if ((double) this.PrecisionLevel == 9.0)
            this.AmounttoDecrease = 2f;
          if ((double) this.PrecisionLevel == 10.0)
            this.AmounttoDecrease = 2.25f;
          if ((double) this.PrecisionLevel == 11.0)
            this.AmounttoDecrease = 2.5f;
          if ((double) this.PrecisionLevel == 12.0)
            this.AmounttoDecrease = 2.75f;
          if ((double) this.PrecisionLevel == 13.0)
            this.AmounttoDecrease = 3f;
          if ((double) this.PrecisionLevel == 14.0)
            this.AmounttoDecrease = 3.25f;
          if ((double) this.PrecisionLevel == 15.0)
            this.AmounttoDecrease = 3.5f;
        }
        if (Game.IsControlPressed(2, GTA.Control.ParachutePrecisionLanding))
        {
          if (this.usePrecision)
          {
            this.usePrecision = false;
            UI.Notify("Gunrunning Business - Working MOC : Precission Off");
          }
          else if (!this.usePrecision)
          {
            this.usePrecision = true;
            UI.Notify("Gunrunning Business - Working MOC : Precission On");
          }
        }
        if (this.usePrecision)
        {
          if (Game.IsControlPressed(2, GTA.Control.MoveRightOnly))
          {
            Vector3 rotation = this.DroneCam.Rotation;
            this.DroneCam.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z - this.AmounttoDecrease);
          }
          if (Game.IsControlPressed(2, GTA.Control.MoveDownOnly) && ((double) this.DroneCam.Rotation.X != 70.0 || (double) this.DroneCam.Rotation.X != -15.0))
          {
            Vector3 rotation = this.DroneCam.Rotation;
            this.DroneCam.Rotation = new Vector3(rotation.X - this.AmounttoDecrease, rotation.Y, rotation.Z);
          }
          if (Game.IsControlPressed(2, GTA.Control.MoveLeftOnly))
          {
            Vector3 rotation = this.DroneCam.Rotation;
            this.DroneCam.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z + this.AmounttoDecrease);
          }
          if (Game.IsControlPressed(2, GTA.Control.MoveUpOnly) && ((double) this.DroneCam.Rotation.X != 70.0 || (double) this.DroneCam.Rotation.X != -15.0))
          {
            Vector3 rotation = this.DroneCam.Rotation;
            this.DroneCam.Rotation = new Vector3(rotation.X + this.AmounttoDecrease, rotation.Y, rotation.Z);
          }
        }
        if (!this.usePrecision)
        {
          if (Game.IsControlPressed(2, GTA.Control.MoveRightOnly))
          {
            Vector3 rotation = this.DroneCam.Rotation;
            this.DroneCam.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z - 2f);
          }
          if (Game.IsControlPressed(2, GTA.Control.MoveDownOnly) && ((double) this.DroneCam.Rotation.X != 70.0 || (double) this.DroneCam.Rotation.X != -15.0))
          {
            Vector3 rotation = this.DroneCam.Rotation;
            this.DroneCam.Rotation = new Vector3(rotation.X - 2f, rotation.Y, rotation.Z);
          }
          if (Game.IsControlPressed(2, GTA.Control.MoveLeftOnly))
          {
            Vector3 rotation = this.DroneCam.Rotation;
            this.DroneCam.Rotation = new Vector3(rotation.X, rotation.Y, rotation.Z + 2f);
          }
          if (Game.IsControlPressed(2, GTA.Control.MoveUpOnly) && ((double) this.DroneCam.Rotation.X != 70.0 || (double) this.DroneCam.Rotation.X != -15.0))
          {
            Vector3 rotation = this.DroneCam.Rotation;
            this.DroneCam.Rotation = new Vector3(rotation.X + 2f, rotation.Y, rotation.Z);
          }
        }
      }
      if (this.IsUsingSam)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          this.IsUsingSam = false;
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.IsVisible = true;
          this.IsInInterior = true;
          Game.Player.Character.Position = this.CabOptions;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DroneCam.Destroy();
          this.DisplayHelpTextThisFrame("Deactivating SAM");
          this.GetPositions();
          Game.Player.Character.Position = this.ExitMoc;
          Script.Wait(100);
          this.SittinginSeat = false;
          this.SeatSittingin = 0;
        }
      }
      else if (this.IsUsingSam || !this.IsInInterior)
        ;
      if (this.IsUsingSam && Game.IsControlJustPressed(2, GTA.Control.VehicleHeadlight))
      {
        if (this.TurretMode == 0)
        {
          this.TurretMode = 1;
          UI.Notify("Sentry : Vulcan Mode Active");
        }
        else if (this.TurretMode == 1)
        {
          this.TurretMode = 0;
          UI.Notify("Sentry : Cannon Mode Active");
        }
      }
      if (Game.IsControlPressed(2, GTA.Control.Jump) && (this.IsUsingSam && this.CanFire))
      {
        if (this.TurretMode == 0)
        {
          this.CanFire = false;
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
          Vector3 position1 = this.DroneCam.Position;
          Vector3 position2 = Game.Player.Character.Position;
          Vector3 position3 = this.DroneCam.Position;
          Vector3 rotation = this.DroneCam.Rotation;
          float num1 = rotation.Z * ((float) System.Math.PI / 180f);
          float num2 = rotation.X * ((float) System.Math.PI / 180f);
          float num3 = (float) System.Math.Abs(System.Math.Cos((double) num2));
          Vector3 vector3 = new Vector3((float) (System.Math.Sin((double) num1) * (double) num3 * -1.0), (float) System.Math.Cos((double) num1) * num3, (float) System.Math.Sin((double) num2));
          RaycastResult raycastResult = World.Raycast(position3, position3 + vector3 * 100000f, IntersectOptions.Everything);
          World.AddOwnedExplosion(Game.Player.Character, raycastResult.HitCoords, ExplosionType.BZGas, 0.5f, 0.0f);
          Vector3 hitCoords1 = raycastResult.HitCoords;
          if (true)
          {
            float num4 = (float) (new System.Random().Next(-100, 100) / 100);
            Vector3 hitCoords2 = raycastResult.HitCoords;
            World.ShootBullet(position1, hitCoords2, Game.Player.Character, model, 15000);
            this.TurretTimer = 25;
          }
        }
        if (this.TurretMode == 1)
        {
          this.CanFire = false;
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
          Vector3 position1 = this.DroneCam.Position;
          Vector3 vector3_1 = Game.Player.Character.Position;
          Vector3 position2 = this.DroneCam.Position;
          Vector3 rotation = this.DroneCam.Rotation;
          float num1 = rotation.Z * ((float) System.Math.PI / 180f);
          float num2 = rotation.X * ((float) System.Math.PI / 180f);
          float num3 = (float) System.Math.Abs(System.Math.Cos((double) num2));
          Vector3 vector3_2 = new Vector3((float) (System.Math.Sin((double) num1) * (double) num3 * -1.0), (float) System.Math.Cos((double) num1) * num3, (float) System.Math.Sin((double) num2));
          RaycastResult raycastResult = World.Raycast(position2, position2 + vector3_2 * 100000f, IntersectOptions.Everything);
          World.AddOwnedExplosion(Game.Player.Character, raycastResult.HitCoords, ExplosionType.BZGas, 0.5f, 0.0f);
          Vector3 hitCoords = raycastResult.HitCoords;
          if (true)
          {
            float num4 = (float) (new System.Random().Next(-100, 100) / 100);
            vector3_1 = raycastResult.HitCoords;
            World.ShootBullet(position1, raycastResult.HitCoords.Around(1f), Game.Player.Character, model, 5);
            World.ShootBullet(position1, raycastResult.HitCoords.Around(1f), Game.Player.Character, model, 5);
            World.ShootBullet(position1, raycastResult.HitCoords.Around(1f), Game.Player.Character, model, 5);
            this.TurretTimer = 3;
          }
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, new Vector3(853.661f, -3235.2f, -98f)) < 10.0 && (Game.Player.Character.CurrentVehicle.Model == (GTA.Model) VehicleHash.APC || Game.Player.Character.CurrentVehicle.Model == (GTA.Model) VehicleHash.HalfTrack || (Game.Player.Character.CurrentVehicle.Model == (GTA.Model) VehicleHash.Oppressor || Game.Player.Character.CurrentVehicle.Model == (GTA.Model) VehicleHash.Insurgent3) || (Game.Player.Character.CurrentVehicle.Model == (GTA.Model) VehicleHash.Technical3 || Game.Player.Character.CurrentVehicle.Model == (GTA.Model) VehicleHash.NightShark || Game.Player.Character.CurrentVehicle.Model == (GTA.Model) VehicleHash.Dune3) || Game.Player.Character.CurrentVehicle.Model == (GTA.Model) VehicleHash.Tampa3))
      {
        Game.FadeScreenIn(800);
        Vector3 position1 = new Vector3();
        float num1 = 120f;
        Script.Wait(500);
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-3157f, 1376f, 17f)) < 10.0)
        {
          position1 = this.Chumash;
          num1 = 129f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-3023f, 3334f, 11f)) < 10.0)
        {
          position1 = this.FortZancudo;
          num1 = 133f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-752.755f, 5944f, 19f)) < 10.0)
        {
          position1 = this.Paleto;
          num1 = 120f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-387f, 4337f, 55f)) < 10.0)
        {
          position1 = this.RatonCanyon;
          num1 = 12f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1800.755f, 4705f, 39f)) < 10.0)
        {
          position1 = this.GrapeSeed;
          num1 = -72f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(850.755f, 3026f, 40f)) < 10.0)
        {
          position1 = this.GSD1;
          num1 = -171f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2103.755f, 3322f, 44f)) < 10.0)
        {
          position1 = this.GSD2;
          num1 = -44f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1570f, 2224f, 77f)) < 10.0)
        {
          position1 = this.GSD3;
          num1 = -33f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(40.7f, 2927f, 54f)) < 10.0)
        {
          position1 = this.GSD4;
          num1 = 53f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2488f, 3167f, 48f)) < 10.0)
        {
          position1 = this.GSD5;
          num1 = 159f;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(494f, 3015f, 40f)) < 10.0)
        {
          position1 = this.GSD6;
          num1 = 136f;
        }
        Script.Wait(300);
        Vector3 position2 = position1;
        Vector3 rotation1 = Game.Player.Character.CurrentVehicle.Rotation;
        float num2;
        Vector3 rotation2 = new Vector3(rotation1.X, rotation1.Y, num2 = num1 + 3f);
        Camera camera = World.CreateCamera(position2, rotation2, 60f);
        camera.IsActive = true;
        camera.FarClip = 2000f;
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        Script.Wait(500);
        Game.Player.Character.Task.DriveTo(Game.Player.Character.CurrentVehicle, position1, 5f, 100f);
        Script.Wait(7000);
        Game.Player.Character.Task.ClearAll();
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        camera.IsActive = false;
        camera.Destroy();
        Game.Player.Character.FreezePosition = false;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null && ((Game.Player.Character.CurrentVehicle.DisplayName == "HAULER2" || Game.Player.Character.CurrentVehicle.DisplayName == "PHANTOM3" || Game.Player.Character.CurrentVehicle.DisplayName == "PHANTOM2") && (double) World.GetDistance(Game.Player.Character.Position, new Vector3(850f, -3243f, -98f)) < 10.0))
        this.ReadIni = true;
      if ((Entity) this.VehicleinCargoBay != (Entity) null && this.VehicleinCargoBay.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Cover))
        {
          UI.Notify(this.GetHostName() + " Saved Vehicle");
          this.SaveLoad.SaveWithoutDelete();
        }
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          this.IsInInterior = false;
          this.SpawnMOC();
          Game.Player.Character.CurrentVehicle.IsDriveable = true;
          Game.Player.Character.CurrentVehicle.Position = this.Cab.GetOffsetInWorldCoords(new Vector3(0.0f, -25f, 0.0f));
          this.IsInInterior = false;
          this.VehicleinCargoBay = (Vehicle) null;
          this.SaveLoad.SavedVehicle = (Vehicle) null;
          if (!((Entity) this.Trailer != (Entity) null))
            ;
        }
      }
      if (this.IsInInterior)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitMoc) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          this.IsInInterior = false;
          this.SpawnMOC();
          Game.Player.Character.SetIntoVehicle(this.Cab, VehicleSeat.Driver);
          this.SaveLoad.Delete();
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CabOptions) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context) && (this.IsInInterior && !this.mainMenu2.Visible))
          this.mainMenu2.Visible = !this.mainMenu2.Visible;
      }
      if ((Entity) this.Trailer != (Entity) null && ((double) World.GetDistance(Game.Player.Character.Position, this.Trailer.Position) < 5.0 && !this.Cab.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && this.Trailer.IsDoorOpen(VehicleDoor.Trunk) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
      {
        if (Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          try
          {
            this.MOCPosSave = this.Cab.Position;
            this.Spawn = this.MOCPosSave;
            this.X = this.Spawn.X;
            this.Config.SetValue<float>("Setup", "X", this.X);
            this.Y = this.Spawn.Y;
            this.Config.SetValue<float>("Setup", "Y", this.Y);
            this.Z = this.Spawn.Z;
            this.Config.SetValue<float>("Setup", "Z", this.Z);
            this.Config.SetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
            this.Config.Save();
            this.VHeading = this.Cab.Heading;
            this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
            this.Config.Save();
            this.IsInInterior = true;
            this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Storage//Vehicle.ini");
            this.SaveLoad.SaveWithoutDelete();
            Game.Player.Character.CurrentVehicle.Delete();
            Script.Wait(50);
            this.GetPositions();
            Game.Player.Character.Position = this.ExitMoc;
            this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//Storage//Vehicle.ini");
            if (this.SaveLoad.VehicleName != "null")
              this.SaveLoad.LoadMocVehicle();
            this.IsInInterior = true;
            Game.Player.Character.SetIntoVehicle(this.SaveLoad.SavedVehicle, VehicleSeat.Driver);
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Critical Error~w~ : Oopps! somthing has gone wrong, please retry, ifGTAV has just loaded, this is normal, if it continues after please contact ~g~HKH191~w~");
          }
        }
      }
      if (!((Entity) this.Cab != (Entity) null) || !this.Cab.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && !this.Trailer.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
        return;
      if (Game.IsControlJustPressed(2, GTA.Control.VehicleHeadlight) && !this.mainMenu.Visible)
        this.mainMenu.Visible = !this.mainMenu.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.VehicleExit))
      {
        try
        {
          this.MOCPosSave = this.Cab.Position;
          this.Spawn = this.MOCPosSave;
          this.X = this.Spawn.X;
          this.Config.SetValue<float>("Setup", "X", this.X);
          this.Y = this.Spawn.Y;
          this.Config.SetValue<float>("Setup", "Y", this.Y);
          this.Z = this.Spawn.Z;
          this.Config.SetValue<float>("Setup", "Z", this.Z);
          this.Config.SetValue<Vector3>("Setup", "MOCPosition", this.MOCPosSave);
          this.Config.Save();
          this.VHeading = this.Cab.Heading;
          this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
          this.Config.Save();
        }
        catch (Exception ex)
        {
          UI.Notify("~r~ Critical Error~w~ : Oopps! somthing has gone wrong, please retry, ifGTAV has just loaded, this is normal, if it continues after please contact ~g~HKH191~w~");
        }
      }
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      this.IsInInterior = false;
      if (this.MOCBlip != (Blip) null)
        this.MOCBlip.Remove();
      if ((Entity) this.Cab != (Entity) null)
        this.Cab.Delete();
      if ((Entity) this.Trailer != (Entity) null)
        this.Trailer.Delete();
      if ((Entity) this.VehicleinCargoBay != (Entity) null)
        this.VehicleinCargoBay.Delete();
    }
  }
}
