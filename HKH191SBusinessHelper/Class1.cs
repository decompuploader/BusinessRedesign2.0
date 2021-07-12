using GTA;
using GTA.Math;
using GTA.Native;
using iFruitAddon2;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace HKH191SBusinessHelper
{
  public class Class1 : Script
  {
    public int stockscount;
    public float stocksvalue;
    private bool firstTime = true;
    private string ModName = "HKH191's Business Helper";
    private string Developer = "HKH191";
    private string Version = "1";
    private ScriptSettings Config;
    private Keys Key1;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    public Vector3 MenuMarker = new Vector3(236f, 217f, 105f);
    private CustomiFruit ifruit;
    public UIMenu Menu;
    public UIMenu Menu2;
    public UIMenu Menu3;
    public SaveCar SC;
    public Vehicle C;
    public Blip CarBlip;
    public Blip BankBlip;
    public List<object> GunrunningBunkers;
    public List<object> DoomsdayHiestFacilities;
    public Vector3 AvengerSpawn = new Vector3(-1230f, -2565f, 13f);
    public bool HasBeenChecked;
    public string Car;
    public int PurchaseLvl;
    public UIMenu DisableBusiness2enu;
    public UIMenu ResetMenu;
    public UIMenu BusinessPurhaseMenu;
    public Reset Reset = new Reset();
    public List<object> SLots = new List<object>();
    public List<object> LoadPaths = new List<object>();
    public List<object> Garage = new List<object>();
    public string C_LoadPath;
    public int Refreshtimer;
    public Vector3 Old;
    public Vehicle Veh;
    public UIMenu ExtraOptions;
    public int AddMinTick;
    public int AddHourTick;
    public int AddSecTick;
    public Vector3 OrbitalCannonPos = new Vector3(-1507.1f, -1067.4f, 48f);
    public Camera CannonCamera;
    public float CamRot = 91f;
    public bool CameraOn;
    public DateTime CurrentDate;
    public DateTime NextDate;
    public int DaysWait = 3;
    public int NextDay;
    public int NextMonth;
    public int NextYear;
    public bool BYPASS_NOSAVE_OR_CRASH = true;
    public int DAYSTORESET_UPDATETIME = 12;
    public int Now;
    public Vector3 LastPlayerPos;
    public List<Blip> VehicleBlips = new List<Blip>();
    public int Penthouse_Style;
    public int Penthouse_Media;
    public int Penthouse_Spa;
    public int Penthouse_Bar;
    public int Penthouse_Colour;
    public int Penthouse_Arcade;
    public int Penthouse_BarLight;
    public int Penthouse_PokerDealer;
    public int Penthouse_ExtraBedroom;
    public int ArcadeVersion;
    public int ArcadeOwned;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public bool TriggerIncrease;
    public bool DisplayMapOn;
    public int MapStage;
    public float screenaspectratio;
    public Vector2 MapPos = new Vector2(0.5f, 0.5f);
    public float Offset;
    public int ScreenOffset;
    public bool ShowingPurchaseOptions;
    public string BusinessName;
    public int BusinessCost;
    public int BusinessLocaiton;
    public Vector2 SelectedPos;
    public Class1.BusinessType CurrentBusinessType;

    public void SetDate()
    {
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
      }
    }

    public int GetHour() => Function.Call<int>(Hash._0x25223CA6B4D20B7F);

    public int GetMinutes() => Function.Call<int>(Hash._0x13D2B8ADD79640F2);

    public int GetDay() => Function.Call<int>(Hash._0x3D10BC92A4DB1D35);

    public int GetMonth() => Function.Call<int>(Hash._0xBBC72712E80257A1);

    public int GetYear() => Function.Call<int>(Hash._0x961777E64BDAF717);

    public int GetSecond() => Function.Call<int>(Hash._0x494E97C2EF27C470);

    public Class1()
    {
      this.SC = new SaveCar();
      this.ifruit = new CustomiFruit()
      {
        CenterButtonColor = Color.Orange,
        LeftButtonColor = Color.LimeGreen,
        RightButtonColor = Color.Purple,
        CenterButtonIcon = SoftKeyIcon.Fire,
        LeftButtonIcon = SoftKeyIcon.Police,
        RightButtonIcon = SoftKeyIcon.Website
      };
      if (this.BankBlip != (Blip) null)
        this.BankBlip.Remove();
      this.BankBlip = World.CreateBlip(this.MenuMarker);
      this.BankBlip.Sprite = BlipSprite.HeistSetup;
      this.BankBlip.Color = BlipColor.Green;
      this.BankBlip.Name = " HKH191's Business Helper Menu Location ";
      this.ifruit.SetWallpaper(new Wallpaper("char_facebook"));
      this.ifruit.SetWallpaper(Wallpaper.BadgerDefault);
      iFruitContact iFruitContact = new iFruitContact("Business Helper");
      iFruitContact.Answered += new ContactAnsweredEvent(this.loadMenu);
      iFruitContact.DialTimeout = 3000;
      iFruitContact.Active = true;
      iFruitContact.Icon = ContactIcon.MazeBank;
      iFruitContact.Name = "Business Helper";
      this.ifruit.Contacts.Add(iFruitContact);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Tick += new EventHandler(this.OnTick);
      this.Setup();
      this.AddBunkersAndFacilities();
    }

    public void ExtraO()
    {
      List<object> DaysT = new List<object>();
      for (int index = 1; index <= 60; ++index)
        DaysT.Add((object) index);
      List<object> inc = new List<object>();
      for (int index = 0; index <= 60; ++index)
        inc.Add((object) index);
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.ExtraOptions, "Pass Time");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem DaysTime = new UIMenuListItem("Days to Pass : ", DaysT, 0);
      uiMenu.AddItem((UIMenuItem) DaysTime);
      UIMenuListItem RefreshSpeedS = new UIMenuListItem("Add Seconds Per Tick : ", inc, 0);
      uiMenu.AddItem((UIMenuItem) RefreshSpeedS);
      UIMenuListItem RefreshSpeedM = new UIMenuListItem("Add Minutes Per Tick : ", inc, 0);
      uiMenu.AddItem((UIMenuItem) RefreshSpeedM);
      UIMenuListItem RefreshSpeedH = new UIMenuListItem("Add Hours Per Tick : ", inc, 0);
      uiMenu.AddItem((UIMenuItem) RefreshSpeedH);
      UIMenuItem PT = new UIMenuItem(" Pass Selected Time ");
      uiMenu.AddItem(PT);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != PT)
          return;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__75.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__75.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target = Class1.\u003C\u003Eo__75.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p1 = Class1.\u003C\u003Eo__75.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__75.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__75.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = Class1.\u003C\u003Eo__75.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__75.\u003C\u003Ep__0, DaysT[DaysTime.Index], 0);
        if (target((CallSite) p1, obj))
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__75.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__75.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.DaysWait = Class1.\u003C\u003Eo__75.\u003C\u003Ep__2.Target((CallSite) Class1.\u003C\u003Eo__75.\u003C\u003Ep__2, DaysT[DaysTime.Index]);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__75.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__75.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.AddMinTick = Class1.\u003C\u003Eo__75.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__75.\u003C\u003Ep__3, inc[RefreshSpeedM.Index]);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__75.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__75.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.AddHourTick = Class1.\u003C\u003Eo__75.\u003C\u003Ep__4.Target((CallSite) Class1.\u003C\u003Eo__75.\u003C\u003Ep__4, inc[RefreshSpeedH.Index]);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__75.\u003C\u003Ep__5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__75.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.AddSecTick = Class1.\u003C\u003Eo__75.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__75.\u003C\u003Ep__5, inc[RefreshSpeedS.Index]);
          UI.Notify("S/M/H " + this.AddSecTick.ToString() + "__" + this.AddMinTick.ToString() + "__" + this.AddHourTick.ToString());
          if (this.CannonCamera != (Camera) null)
          {
            Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
            this.CannonCamera.IsActive = false;
            this.CannonCamera.Destroy();
          }
          this.LastPlayerPos = Game.Player.Character.Position;
          this.CannonCamera = World.CreateCamera(this.OrbitalCannonPos, new Vector3(0.0f, 0.0f, this.CamRot), 100f);
          this.CannonCamera.IsActive = true;
          this.CannonCamera.FarClip = 2000f;
          Game.Player.Character.Position = this.CannonCamera.Position;
          Game.Player.Character.FreezePosition = true;
          Game.Player.Character.IsVisible = false;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 1, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.Now = this.GetDay();
          this.SetDate();
          World.RenderingCamera = this.CannonCamera;
          this.CameraOn = true;
        }
        else
          UI.Notify("Cannot Pass 0 Days!");
      });
    }

    public void AddBunkersAndFacilities()
    {
    }

    public void DrawScaleform()
    {
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      Convert.ToInt32(resolutionMantainRatio.Width);
      Convert.ToInt32(resolutionMantainRatio.Height);
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.CallFunction("CLEAR_ALL");
      scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", (object) 0);
      scaleform.CallFunction("CREATE_CONTAINER");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 0, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 44, (InputArgument) 0), (object) "Cancel Pass Time");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 1, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 202, (InputArgument) 0), (object) "");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 2, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 175, (InputArgument) 0), (object) "");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 3, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 174, (InputArgument) 0), (object) "");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 4, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 206, (InputArgument) 0), (object) "");
      scaleform.CallFunction("SET_DATA_SLOT", (object) 5, (object) Function.Call<string>(Hash._0x0499D7B09FC9B407, (InputArgument) 2, (InputArgument) 205, (InputArgument) 0), (object) "");
      scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", (object) -1);
      scaleform.Render2D();
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    public void Setup()
    {
      this.CreateBanner();
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.Garage.Add((object) "No Business Selected");
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Business Helper", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.BusinessPurhaseMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Purchase A Business");
      this.GUIMenus.Add(this.BusinessPurhaseMenu);
      this.Menu = this.modMenuPool.AddSubMenu(this.mainMenu, "Options");
      this.GUIMenus.Add(this.Menu);
      this.Menu2 = this.modMenuPool.AddSubMenu(this.mainMenu, "Vehicle Options");
      this.GUIMenus.Add(this.Menu2);
      this.ResetMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Reset Options");
      this.GUIMenus.Add(this.ResetMenu);
      this.ExtraOptions = this.modMenuPool.AddSubMenu(this.mainMenu, "Extra Options");
      this.GUIMenus.Add(this.ExtraOptions);
      this.SetupSellStocks();
      this.VehicleOptions();
      this.EnableMenu();
      this.SetupResetMenu();
      this.BusinessPurchaseMethod();
      this.ExtraO();
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void SetupResetMenu()
    {
      List<object> objectList = new List<object>()
      {
        (object) "Del Perro ClubHouse",
        (object) "Grapeseed Clubhouse",
        (object) "Great Chaparral Clubhouse",
        (object) "Howick ClubHouse",
        (object) "La Mesa ClubHouse",
        (object) "Paleto ClubHouse",
        (object) "Paleto ClubHouse2",
        (object) "Pillbox Hill ClubHouse",
        (object) "Rancho ClubHouse",
        (object) "Sandy Shores ClubHouse",
        (object) "Vespucci ClubHouse",
        (object) "Vinewood ClubHouse"
      };
      List<object> items1 = new List<object>();
      items1.Add((object) "Main");
      List<object> items2 = new List<object>();
      items2.Add((object) "Arcadius, Garage A");
      items2.Add((object) "Arcadius, Garage B");
      items2.Add((object) "Arcadius, Garage C");
      items2.Add((object) "MazeBank, Garage A");
      items2.Add((object) "MazeBank, Garage B");
      items2.Add((object) "MazeBank, Garage C");
      items2.Add((object) "MBW, Garage A");
      items2.Add((object) "MBW, Garage B");
      items2.Add((object) "MBW, Garage C");
      items2.Add((object) "Lombok, Garage A");
      items2.Add((object) "Lombok, Garage B");
      items2.Add((object) "Lombok, Garage C");
      List<object> items3 = new List<object>();
      items3.Add((object) "Main");
      List<object> items4 = new List<object>();
      items4.Add((object) "Main");
      List<object> items5 = new List<object>();
      items5.Add((object) "Main");
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset All");
      this.GUIMenus.Add(uiMenu1);
      UIMenuItem Reseta = new UIMenuItem("Reset All Business Mods");
      uiMenu1.AddItem(Reseta);
      Reseta.Description = "~y~ Warning~w~ This will Reset All Business mods/All Garages to Default";
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Reseta)
          return;
        this.Reset.ResetMCBusiness(1);
        this.Reset.ResetMCBusiness(2);
        this.Reset.ResetMCBusiness(3);
        this.Reset.ResetMCBusiness(4);
        this.Reset.ResetMCBusiness(5);
        this.Reset.ResetBikerBusinessOption("scripts\\HKH191sBusinessMods\\MethBusiness\\Main.ini");
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\DelPerroClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\GrapeseedClubhouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\GreatChaparral\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\HowickClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\LaMesaClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PaletoClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PaletoClubHouse2\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PillboxHillClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\RanchoClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\SandyShoresClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\VespucciClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\VineWoodClubHouse\\Garage\\", 12);
        this.Reset.ResetExecutiveBusinessOption("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\Main.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_1.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_2.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_3.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_4.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_5.ini");
        this.Reset.ResetWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\Main.ini");
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\WareHouses\\GarageA\\", 35);
        this.Reset.ResetExecutiveYacht("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\Yacht.ini");
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageA\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageB\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageC\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageA\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageB\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageC\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageA\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageB\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageC\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageA\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageB\\", 20);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageC\\", 20);
        this.Reset.ResetGunrunningBusinessOption("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\Main.ini");
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\Smuggler's Run Business\\HangerStorage\\Hanger\\Hanger1\\", 12);
        this.Reset.ResetSmugglersRunBusinessOption("scripts\\HKH191sBusinessMods\\Smuggler's Run Business\\Main.ini");
        this.Reset.ResetDoomsdayHeistBusinessOption("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\Main.ini");
        this.Reset.ResetWarehouse("scripts\\HKH191sBusinessMods\\LCC\\Main.ini");
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\LCC\\WareHouses\\GarageA\\", 35);
        this.Reset.ResetLCCBusinessOption("scripts\\HKH191sBusinessMods\\LCC\\Main.ini");
        this.Reset.ResetStockTimer("scripts\\HKH191sBusinessMods\\DC&R\\Main.ini");
        this.Reset.ResetDCARBusiness("scripts\\HKH191sBusinessMods\\DC&R\\Casino.ini");
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\DC&R\\CasinoGarage\\GarageA\\", 38);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\DC&R\\ArcadeGarage\\GarageA\\", 11);
        this.Reset.ResetArenaWarBusinessOption("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\Main.ini");
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\", 10);
        this.Reset.ResetStockTimer("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Main.ini");
        this.Reset.ResetStockTimer("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Main.ini");
        this.Reset.ResetAfterHoursBusiness("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Main.ini");
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Garage\\", 10);
        this.Reset.ResetAfterHoursHeavyStorage("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Main.ini");
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
        UI.Notify("~g~ HKH191~w~ Successfuly Reset All Business Mods");
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset Biker Business");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem BikerReset = new UIMenuItem("Reset Biker Business ");
      uiMenu2.AddItem(BikerReset);
      UIMenuItem uiMenuItem1 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu2.AddItem(uiMenuItem1);
      UIMenuItem ResetC = new UIMenuItem("Reset All Clubhouse Garage");
      uiMenu2.AddItem(ResetC);
      UIMenuItem uiMenuItem2 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu2.AddItem(uiMenuItem2);
      UIMenuItem ResetMCMeth = new UIMenuItem("Reset Meth Lab Business");
      uiMenu2.AddItem(ResetMCMeth);
      UIMenuItem ResetMCCocaine = new UIMenuItem("Reset Cocaine Lockup Business");
      uiMenu2.AddItem(ResetMCCocaine);
      UIMenuItem ResetMCWeed = new UIMenuItem("Reset Weed Farm Business");
      uiMenu2.AddItem(ResetMCWeed);
      UIMenuItem ResetMCCounterfeit = new UIMenuItem("Reset Counterfeit Office Business");
      uiMenu2.AddItem(ResetMCCounterfeit);
      UIMenuItem ResetMCForgery = new UIMenuItem("Reset Document Forgery Business");
      uiMenu2.AddItem(ResetMCForgery);
      UIMenuItem uiMenuItem3 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu2.AddItem(uiMenuItem3);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ResetMCMeth)
        {
          this.Reset.ResetMCBusiness(1);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Meth Lab Business");
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            this.Veh = Game.Player.Character.CurrentVehicle;
            this.Veh.IsPersistent = true;
          }
          this.Old = Game.Player.Character.Position;
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          this.Refreshtimer = 1;
        }
        if (item == ResetMCCocaine)
        {
          this.Reset.ResetMCBusiness(2);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Cocaine Lockup Business");
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            this.Veh = Game.Player.Character.CurrentVehicle;
            this.Veh.IsPersistent = true;
          }
          this.Old = Game.Player.Character.Position;
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          this.Refreshtimer = 1;
        }
        if (item == ResetMCWeed)
        {
          this.Reset.ResetMCBusiness(3);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Weed Farm Business");
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            this.Veh = Game.Player.Character.CurrentVehicle;
            this.Veh.IsPersistent = true;
          }
          this.Old = Game.Player.Character.Position;
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          this.Refreshtimer = 1;
        }
        if (item == ResetMCCounterfeit)
        {
          this.Reset.ResetMCBusiness(5);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Counterfeit Office Business");
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            this.Veh = Game.Player.Character.CurrentVehicle;
            this.Veh.IsPersistent = true;
          }
          this.Old = Game.Player.Character.Position;
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          this.Refreshtimer = 1;
        }
        if (item == ResetMCForgery)
        {
          this.Reset.ResetMCBusiness(4);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Document Forgery Business");
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            this.Veh = Game.Player.Character.CurrentVehicle;
            this.Veh.IsPersistent = true;
          }
          this.Old = Game.Player.Character.Position;
          Game.Player.Character.Alpha = 15;
          Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
          this.Refreshtimer = 1;
        }
        if (item == BikerReset)
        {
          this.Reset.ResetBikerBusinessOption("scripts\\HKH191sBusinessMods\\MethBusiness\\Main.ini");
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Biker Business");
        }
        if (item != ResetC)
          return;
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\DelPerroClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\GrapeseedClubhouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\GreatChaparral\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\HowickClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\LaMesaClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PaletoClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PaletoClubHouse2\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PillboxHillClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\RanchoClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\SandyShoresClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\VespucciClubHouse\\Garage\\", 12);
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\VineWoodClubHouse\\Garage\\", 12);
        UI.Notify("~g~ HKH191~w~ Successfuly Reset Clubhouse Garage");
      });
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset Executive Business");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem Tower = new UIMenuListItem("Tower : ", items1, 0);
      uiMenu3.AddItem((UIMenuItem) Tower);
      UIMenuItem ResetT = new UIMenuItem("Reset Tower");
      uiMenu3.AddItem(ResetT);
      UIMenuItem uiMenuItem4 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu3.AddItem(uiMenuItem4);
      UIMenuListItem ExGarage = new UIMenuListItem("Garage : ", items2, 0);
      uiMenu3.AddItem((UIMenuItem) ExGarage);
      UIMenuItem ResetExGarage = new UIMenuItem("Reset Garage");
      uiMenu3.AddItem(ResetExGarage);
      UIMenuItem uiMenuItem5 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu3.AddItem(uiMenuItem5);
      UIMenuItem ResetExSB = new UIMenuItem("Reset Cargo Warhouses");
      uiMenu3.AddItem(ResetExSB);
      UIMenuItem ResetExWH = new UIMenuItem("Reset Vehicle Warehouse");
      uiMenu3.AddItem(ResetExWH);
      UIMenuItem ResetExY = new UIMenuItem("Reset Yacht");
      uiMenu3.AddItem(ResetExY);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ResetExGarage)
        {
          if (ExGarage.Index == 0)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageA\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Arcadius Garage A");
          }
          if (ExGarage.Index == 1)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageB\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Arcadius Garage B");
          }
          if (ExGarage.Index == 2)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageC\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Arcadius Garage C");
          }
          if (ExGarage.Index == 3)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageA\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Maze Bank Garage A");
          }
          if (ExGarage.Index == 4)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageB\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Maze Bank Garage B");
          }
          if (ExGarage.Index == 5)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageC\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Maze Bank Garage C");
          }
          if (ExGarage.Index == 6)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageA\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Maze Bank West Garage A");
          }
          if (ExGarage.Index == 7)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageB\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Maze Bank West Garage B");
          }
          if (ExGarage.Index == 8)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageC\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Maze Bank West Garage C");
          }
          if (ExGarage.Index == 9)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageA\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Lombok Garage A");
          }
          if (ExGarage.Index == 10)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageB\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Lombok Garage B");
          }
          if (ExGarage.Index == 11)
          {
            this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageC\\", 20);
            UI.Notify("~g~ HKH191~w~ Successfuly Reset Lombok Garage C");
          }
        }
        if (item == ResetExY)
        {
          this.Reset.ResetExecutiveYacht("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\Yacht.ini");
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Executive Yacht");
        }
        if (item == ResetExWH)
        {
          this.Reset.ResetWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\Main.ini");
          this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\WareHouses\\GarageA\\", 35);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Executive Warehouse");
        }
        if (item == ResetExSB)
        {
          this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_1.ini");
          this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_2.ini");
          this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_3.ini");
          this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_4.ini");
          this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_5.ini");
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Executive Cargo Warehouses");
        }
        if (item != ResetT || Tower.Index != 0)
          return;
        this.Reset.ResetExecutiveBusinessOption("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\Main.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_1.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_2.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_3.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_4.ini");
        this.Reset.ResetExecutiveWarehouse("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\CargoWarehouses\\PlayerWarehouse_5.ini");
        UI.Notify("~g~ HKH191~w~ Successfuly Reset Executive Business");
      });
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset Gunrunnning Business");
      this.GUIMenus.Add(uiMenu4);
      UIMenuListItem Bunkers = new UIMenuListItem("Bunker : ", items3, 0);
      uiMenu4.AddItem((UIMenuItem) Bunkers);
      UIMenuItem ResetB = new UIMenuItem("Reset Bunker");
      uiMenu4.AddItem(ResetB);
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != ResetB || Bunkers.Index != 0)
          return;
        this.Reset.ResetGunrunningBusinessOption("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\Main.ini");
        UI.Notify("~g~ HKH191~w~ Successfuly Reset Gunrunning Business");
      });
      UIMenu uiMenu5 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset Smuggler's Run Business");
      this.GUIMenus.Add(uiMenu5);
      UIMenuListItem Hangers = new UIMenuListItem("Hanger : ", items5, 0);
      uiMenu5.AddItem((UIMenuItem) Hangers);
      UIMenuItem ResetH = new UIMenuItem("Reset Hanger");
      uiMenu5.AddItem(ResetH);
      UIMenuItem RA = new UIMenuItem("Remove All Aircraft From This Hanger");
      uiMenu5.AddItem(RA);
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == RA && Hangers.Index == 0)
        {
          this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\Smuggler's Run Business\\HangerStorage\\Hanger\\Hanger1\\", 12);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Smuggler's Run Business");
        }
        if (item != ResetH || Hangers.Index != 0)
          return;
        this.Reset.ResetSmugglersRunBusinessOption("scripts\\HKH191sBusinessMods\\Smuggler's Run Business\\Main.ini");
        UI.Notify("~g~ HKH191~w~ Successfuly Reset Smuggler's Run Hanger");
      });
      UIMenu uiMenu6 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset Doomsday Heist Business");
      this.GUIMenus.Add(uiMenu6);
      UIMenuListItem Facilities = new UIMenuListItem("Facility : ", items4, 0);
      uiMenu6.AddItem((UIMenuItem) Facilities);
      UIMenuItem ResetF = new UIMenuItem("Reset Facility");
      uiMenu6.AddItem(ResetF);
      uiMenu6.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != ResetF || Facilities.Index != 0)
          return;
        this.Reset.ResetDoomsdayHeistBusinessOption("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\Main.ini");
        UI.Notify("~g~ HKH191~w~ Successfuly Reset Doomsday Heist Business");
      });
      UIMenu uiMenu7 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset LCC Business");
      this.GUIMenus.Add(uiMenu7);
      UIMenuItem ResetBs = new UIMenuItem("Reset LCC Business");
      uiMenu7.AddItem(ResetBs);
      UIMenuItem ResetlccWH = new UIMenuItem("Reset LCC Warehouse");
      uiMenu7.AddItem(ResetlccWH);
      uiMenu7.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ResetlccWH)
        {
          this.Reset.ResetWarehouse("scripts\\HKH191sBusinessMods\\LCC\\Main.ini");
          this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\LCC\\WareHouses\\GarageA\\", 35);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset LCC Warehouse");
        }
        if (item != ResetBs)
          return;
        this.Reset.ResetLCCBusinessOption("scripts\\HKH191sBusinessMods\\LCC\\Main.ini");
        UI.Notify("~g~ HKH191~w~ Successfuly Reset LCC Business");
      });
      UIMenu uiMenu8 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset Arena War Business");
      this.GUIMenus.Add(uiMenu8);
      UIMenuItem ResetAWB = new UIMenuItem("Reset Arena War Business");
      uiMenu8.AddItem(ResetAWB);
      UIMenuItem ResetAWG = new UIMenuItem("Reset Arena War Garage");
      uiMenu8.AddItem(ResetAWG);
      uiMenu8.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ResetAWB)
        {
          this.Reset.ResetArenaWarBusinessOption("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\Main.ini");
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Arena War Business");
        }
        if (item != ResetAWG)
          return;
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\", 10);
        UI.Notify("~g~ HKH191~w~ Successfuly Reset Arena War 10 Car Garage");
      });
      UIMenu uiMenu9 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset Diamond Casino & Resort Business ");
      this.GUIMenus.Add(uiMenu9);
      UIMenuItem ResetDCARB = new UIMenuItem("Reset DC&R Business");
      uiMenu9.AddItem(ResetDCARB);
      UIMenuItem ResetDCARG = new UIMenuItem("Reset DC&R Garage");
      uiMenu9.AddItem(ResetDCARG);
      UIMenuItem ResetArcade = new UIMenuItem("Reset Arcade");
      uiMenu9.AddItem(ResetArcade);
      UIMenuItem ResetArcadeG = new UIMenuItem("Reset Arcade Garage");
      uiMenu9.AddItem(ResetArcadeG);
      uiMenu9.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ResetDCARB)
        {
          this.Reset.ResetStockTimer("scripts\\HKH191sBusinessMods\\DC&R\\Main.ini");
          this.Reset.ResetDCARBusiness("scripts\\HKH191sBusinessMods\\DC&R\\Casino.ini");
          UI.Notify("~g~ HKH191~w~ Successfuly Reset DC&R Business");
        }
        if (item == ResetDCARG)
        {
          this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\DC&R\\CasinoGarage\\GarageA\\", 38);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset DC&R 38 Garage");
        }
        if (item == ResetArcade)
        {
          this.Reset.ResetDCARARCADE("scripts\\HKH191sBusinessMods\\DC&R\\Casino.ini");
          UI.Notify("~g~ HKH191~w~ Successfuly Reset DC&R Arcade");
        }
        if (item != ResetArcadeG)
          return;
        this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\DC&R\\ArcadeGarage\\GarageA\\", 11);
        UI.Notify("~g~ HKH191~w~ Successfuly Reset DC&R Arcade Garage");
      });
      UIMenu uiMenu10 = this.modMenuPool.AddSubMenu(this.ResetMenu, "Reset After Hours ");
      this.GUIMenus.Add(uiMenu10);
      UIMenuItem ResetAFB = new UIMenuItem("Reset After Hours Business");
      uiMenu10.AddItem(ResetAFB);
      UIMenuItem ResetAFB10 = new UIMenuItem("Reset After Hours 10 Car Garage");
      uiMenu10.AddItem(ResetAFB10);
      UIMenuItem ResetAFB3 = new UIMenuItem("Reset Heavy Vehicle Storage");
      uiMenu10.AddItem(ResetAFB3);
      uiMenu10.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ResetAFB)
        {
          this.Reset.ResetStockTimer("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Main.ini");
          this.Reset.ResetStockTimer("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Main.ini");
          this.Reset.ResetAfterHoursBusiness("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Main.ini");
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Afterhours Business");
        }
        if (item == ResetAFB10)
        {
          this.Reset.ResetAGarage("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Garage\\", 10);
          UI.Notify("~g~ HKH191~w~ Successfuly Reset Afterhours Business 10 Car Garage");
        }
        if (item != ResetAFB3)
          return;
        this.Reset.ResetAfterHoursHeavyStorage("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Main.ini");
        UI.Notify("~g~ HKH191~w~ Successfuly Reset Afterhours Heavy Storage");
      });
    }

    public void EnableMenu()
    {
    }

    public void Purchase_BikerBusiness(int Dest)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      if (Dest == 11)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//GreatChaparral//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 10)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//VineWoodClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 9)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//DelPerroClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 8)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//PaletoClubHouse2//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 7)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//SandyShoresClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 6)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//RanchoClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 5)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//PillboxHillClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 4)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//PaletoClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 3)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//LaMesaClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 2)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//HowickClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest == 1)
      {
        this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//VespucciClubHouse//SafeHouse.ini");
        this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
        this.Config.Save();
      }
      if (Dest != 0)
        return;
      this.Config.SetValue<int>("Misc", "CurrentSafehouse", Dest);
      this.Config.Save();
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
        this.Config.Save();
      }
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//ClubHouses//GrapeseedClubhouse//SafeHouse.ini");
      this.Config.SetValue<int>("Setup", "PurchasedSafeHouse", 1);
      this.Config.Save();
    }

    public void Purchase_ExecutiveBusiness(int Dest)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      if (Dest == 3)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 2)
      {
        this.Config.SetValue<int>("Misc", "BusinessLocation", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 1)
      {
        this.Config.SetValue<int>("Misc", "BusinessLocation", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest != 0)
        return;
      this.Config.SetValue<int>("Misc", "BusinessLocation", Dest);
      this.Config.Save();
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
        this.Config.Save();
      }
    }

    public void Purchase_GunrunningBusiness(int Dest)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
      if (Dest == 10)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 9)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 8)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 7)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 6)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 5)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 4)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 3)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 2)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 1)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest != 0)
        return;
      this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
      this.Config.Save();
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
        this.Config.Save();
      }
    }

    public void Purchase_SmugglersRun(int Dest)
    {
      this.LoadIniFile("scripts\\HKH191sBusinessMods\\Smuggler's Run Business\\HangerStorage\\Hanger\\Hanger1\\Slot4.ini");
      this.Config.SetValue<string>("CONFIGURATIONS", "VEHICLENAME", "CUBAN800");
      this.Config.Save();
      this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
      if (Dest == 4)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 3)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 2)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 1)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest != 0)
        return;
      this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
      this.Config.Save();
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
        this.Config.Save();
      }
    }

    public void Purchase_DCAR(int Dest)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
      if (Dest == 4)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 10);
        this.Config.SetValue<int>("Setup", "Casinoi_Upgrade_Level", Dest);
        this.Config.Save();
      }
      if (Dest == 3)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 3);
        this.Config.SetValue<int>("Setup", "Casinoi_Upgrade_Level", Dest);
        this.Config.Save();
      }
      if (Dest == 2)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
        this.Config.SetValue<int>("Setup", "Casinoi_Upgrade_Level", Dest);
        this.Config.Save();
      }
      if (Dest != 1)
        return;
      this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
      this.Config.SetValue<int>("Setup", "Casinoi_Upgrade_Level", Dest);
      this.Config.Save();
    }

    public void Purchase_DoomsdayHeistBusiness(int Dest)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      if (Dest == 8)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 7)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 6)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 5)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 4)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 3)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 2)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 1)
      {
        this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest != 0)
        return;
      this.Config.SetValue<int>("Misc", "BUSINESSLOCATION", Dest);
      this.Config.Save();
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
        this.Config.Save();
      }
    }

    public void Purchase_AfterhoursBusiness(int Dest)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
      if (Dest == 9)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 8)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 7)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 6)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 5)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 4)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 3)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 2)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest == 1)
      {
        this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
        this.Config.Save();
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
        {
          this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
          this.Config.Save();
        }
      }
      if (Dest != 0)
        return;
      this.Config.SetValue<int>("Setup", "NightClubLoc", Dest);
      this.Config.Save();
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) == 0)
      {
        this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
        this.Config.Save();
      }
    }

    public void Purchase_ArenaWarBusiness()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) != 0)
        return;
      this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
      this.Config.Save();
    }

    public void Purchase_LCC()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//LCC//Main.ini");
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", 0) != 0)
        return;
      this.Config.SetValue<int>("Setup", "BuisnessLevel", 1);
      this.Config.Save();
    }

    public void BusinessPurchaseMethod()
    {
      float Cost = 0.0f;
      float StyleCost = 0.0f;
      float BarCost = 0.0f;
      float SpaCost = 0.0f;
      float MediaCost = 0.0f;
      float ExtraB_Cost = 0.0f;
      float PDcost = 0.0f;
      List<object> items1 = new List<object>();
      items1.Add((object) false);
      items1.Add((object) true);
      List<object> items2 = new List<object>();
      items2.Add((object) "Blank");
      items2.Add((object) "Art Deco");
      items2.Add((object) "Art Nouveau");
      items2.Add((object) "Classical");
      items2.Add((object) "Traditional");
      items2.Add((object) "Imperial");
      items2.Add((object) "Pop");
      items2.Add((object) "Latin");
      items2.Add((object) "Natural");
      items2.Add((object) "Intricate");
      List<object> items3 = new List<object>();
      items3.Add((object) "No Bar");
      items3.Add((object) "Bar Included");
      List<object> items4 = new List<object>();
      items4.Add((object) "No Spa");
      items4.Add((object) "Spa Included");
      List<object> items5 = new List<object>();
      items5.Add((object) "No Media Room");
      items5.Add((object) "Media Room Included");
      List<object> items6 = new List<object>();
      items6.Add((object) "No Extra Room");
      items6.Add((object) "Extra Room Included");
      List<object> items7 = new List<object>();
      items7.Add((object) "Bar Light 1");
      items7.Add((object) "Bar Light 2");
      items7.Add((object) "Bar Light 3");
      List<object> items8 = new List<object>();
      items8.Add((object) "No Poker/Blackjack Dealer");
      items8.Add((object) "Poker/Blackjack Dealer Included");
      List<object> items9 = new List<object>();
      items9.Add((object) "Retro Arcade");
      items9.Add((object) "Modern Arcade");
      List<object> items10 = new List<object>();
      items10.Add((object) "Multicolor");
      items10.Add((object) "Timeless");
      items10.Add((object) "Vibrent");
      items10.Add((object) "Sharp");
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "Business Time Saver Packs (Save 25%)");
      this.GUIMenus.Add(uiMenu1);
      UIMenuItem DHSourceAllV = new UIMenuItem("Doomsday Hiest Source & Buy  : ~g~ $16,432,500");
      uiMenu1.AddItem(DHSourceAllV);
      DHSourceAllV.Description = "Will Source and buy all vehicles in Doomsday Heist Business";
      UIMenuItem GRSourceAllV = new UIMenuItem("Gunrunning Source & Buy  : ~g~ $13,533,000");
      uiMenu1.AddItem(GRSourceAllV);
      GRSourceAllV.Description = "Will Source and buy all vehicles in Gunrunning Business";
      UIMenuItem ARWSourceAllV = new UIMenuItem("Arena War Source & Buy (All) : ~g~ $36,090,990");
      uiMenu1.AddItem(ARWSourceAllV);
      ARWSourceAllV.Description = "Will buy all Arena War Vehicles in Arena Business";
      UIMenuItem ARWSourceFutureShockV = new UIMenuItem("Arena War Source & Buy (Future Shock) : ~g~ $12,030,330");
      uiMenu1.AddItem(ARWSourceFutureShockV);
      ARWSourceFutureShockV.Description = "Will buy all Future Shock Arena War Vehicles in Arena Business";
      UIMenuItem ARWSourceApocalypseV = new UIMenuItem("Arena War Source & Buy (Apocalypse)  : ~g~ $12,030,330");
      uiMenu1.AddItem(ARWSourceApocalypseV);
      ARWSourceApocalypseV.Description = "Will buy all Apocalypse Arena War Vehicles in Arena Business";
      UIMenuItem ARWSourceNightmareV = new UIMenuItem("Arena War Source & Buy (Nightmare) : ~g~ $12,030,330");
      uiMenu1.AddItem(ARWSourceNightmareV);
      ARWSourceNightmareV.Description = "Will buy all Nightmare Arena War Vehicles in Arena Business";
      UIMenuItem AFBSourceAllV = new UIMenuItem("After Hours Source & Buy  : ~g~ $12,719,250");
      uiMenu1.AddItem(AFBSourceAllV);
      AFBSourceAllV.Description = "Will buy all After Hours Vehicles in After Hours Business";
      UIMenuItem ExecutiveFullKit = new UIMenuItem("Executive Full Kit  : ~g~ $3,825,000");
      uiMenu1.AddItem(ExecutiveFullKit);
      ExecutiveFullKit.Description = "Includes, Gunlocker, Money Vault, Garages A,B,C and Modshop";
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ARWSourceFutureShockV)
        {
          if (Game.Player.Money >= 12030330)
          {
            this.Reset.SourceAllFutureShockArenaWarVehicles("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            Game.Player.Money -= 12030330;
            UI.Notify("Purchased Time Savers Pass ~g~Arena War Source & Buy (Future Shock) ~w~, Please reload the mod for the changes to take effect! ");
          }
          else
            UI.Notify(" You do not have enought money for this Time Savers Pack! ");
        }
        if (item == ARWSourceApocalypseV)
        {
          if (Game.Player.Money >= 12030330)
          {
            this.Reset.SourceAllApocalypseArenaWarVehicles("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            Game.Player.Money -= 12030330;
            UI.Notify("Purchased Time Savers Pass ~g~Arena War Source & Buy (Apocalypse)~w~, Please reload the mod for the changes to take effect! ");
          }
          else
            UI.Notify(" You do not have enought money for this Time Savers Pack! ");
        }
        if (item == ARWSourceNightmareV)
        {
          if (Game.Player.Money >= 12030330)
          {
            this.Reset.SourceAllNightmareArenaWarVehicles("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            Game.Player.Money -= 12030330;
            UI.Notify("Purchased Time Savers Pass ~g~Arena War Source & Buy (Nightmare) ~w~, Please reload the mod for the changes to take effect! ");
          }
          else
            UI.Notify(" You do not have enought money for this Time Savers Pack! ");
        }
        if (item == DHSourceAllV)
        {
          if (Game.Player.Money >= 16432500)
          {
            this.Reset.SourceAllDoomsdayHeistVehicles("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
            Game.Player.Money -= 16432500;
            UI.Notify("Purchased Time Savers Pass ~g~Doomsday Hiest Source & Buy ~w~, Please reload the mod for the changes to take effect! ");
          }
          else
            UI.Notify(" You do not have enought money for this Time Savers Pack! ");
        }
        if (item == GRSourceAllV)
        {
          if (Game.Player.Money >= 13533000)
          {
            this.Reset.SourceAllGunrunningVehicles("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
            Game.Player.Money -= 13533000;
            UI.Notify("Purchased Time Savers Pass ~g~Gunrunning Source & Buy~w~, Please reload the mod for the changes to take effect! ");
          }
          else
            UI.Notify(" You do not have enought money for this Time Savers Pack! ");
        }
        if (item == ARWSourceAllV)
        {
          if (Game.Player.Money >= 36090990)
          {
            this.Reset.SourceAllArenaWarVehicles("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
            Game.Player.Money -= 36090990;
            UI.Notify("Purchased Time Savers Pass ~g~Arena War Source & Buy (All)~w~, Please reload the mod for the changes to take effect! ");
          }
          else
            UI.Notify(" You do not have enought money for this Time Savers Pack! ");
        }
        if (item == AFBSourceAllV)
        {
          if (Game.Player.Money >= 12719250)
          {
            this.Reset.SourceAllAfterHoursVehicles("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
            Game.Player.Money -= 12719250;
            UI.Notify("Purchased Time Savers Pass ~g~After Hours Source & Buy~w~, Please reload the mod for the changes to take effect! ");
          }
          else
            UI.Notify(" You do not have enought money for this Time Savers Pack! ");
        }
        if (item != ExecutiveFullKit)
          return;
        if (Game.Player.Money >= 3825000)
        {
          this.Reset.ExecutiveFullKit("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          Game.Player.Money -= 3825000;
          UI.Notify("Purchased Time Savers Pass ~g~Executive Full Kit  ~w~, Please reload the mod for the changes to take effect! ");
        }
        else
          UI.Notify(" You do not have enought money for this Time Savers Pack! ");
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "Business Passes");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem CheapBP = new UIMenuItem("Cheap Business Pass : ~g~ $9,315,000");
      uiMenu2.AddItem(CheapBP);
      CheapBP.Description = "Cheapest Locations of All Businesses";
      UIMenuItem CityBP = new UIMenuItem("Paleto & City Business Pass : ~g~ $12,380,000");
      uiMenu2.AddItem(CityBP);
      CityBP.Description = "Business Locations Range from the City to      Paleto Bay";
      UIMenuItem SandyShoresBP = new UIMenuItem("City & Sandy Shores Business Pass : ~g~ $13,742,000");
      uiMenu2.AddItem(SandyShoresBP);
      SandyShoresBP.Description = "Business Locations Range from the City to       Sandy Shores";
      UIMenuItem CondensedBP = new UIMenuItem("Condensed Business Pass : ~g~ $14,545,000");
      uiMenu2.AddItem(CondensedBP);
      CondensedBP.Description = "Bussiness Locations Closest to the City, but     not most expensive";
      UIMenuItem SpreadBP = new UIMenuItem("Spread Business Pass : ~g~ $15,820,000");
      uiMenu2.AddItem(SpreadBP);
      SpreadBP.Description = "Business locations spread across the map";
      UIMenuItem MostexpBP = new UIMenuItem("Expensive Business Pass : ~g~ $29,700,000");
      uiMenu2.AddItem(MostexpBP);
      MostexpBP.Description = "Most expensive Locations of All Businesses";
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == CheapBP)
        {
          if (Game.Player.Money >= 9315000)
          {
            Game.Player.Money -= 9315000;
            this.Purchase_BikerBusiness(11);
            this.Purchase_ExecutiveBusiness(3);
            this.Purchase_GunrunningBusiness(10);
            this.Purchase_SmugglersRun(0);
            this.Purchase_DoomsdayHeistBusiness(6);
            this.Purchase_ArenaWarBusiness();
            this.Purchase_LCC();
            this.Purchase_DCAR(1);
          }
          else
            UI.Notify(" You do not have enought money for this Business Pass");
        }
        if (item == SpreadBP)
        {
          if (Game.Player.Money >= 15820000)
          {
            Game.Player.Money -= 15820000;
            this.Purchase_BikerBusiness(7);
            this.Purchase_ExecutiveBusiness(0);
            this.Purchase_GunrunningBusiness(0);
            this.Purchase_SmugglersRun(4);
            this.Purchase_DoomsdayHeistBusiness(3);
            this.Purchase_ArenaWarBusiness();
            this.Purchase_LCC();
            this.Purchase_DCAR(1);
            this.Purchase_AfterhoursBusiness(3);
          }
          else
            UI.Notify(" You do not have enought money for this Business Pass");
        }
        if (item == MostexpBP)
        {
          if (Game.Player.Money >= 29700000)
          {
            Game.Player.Money -= 29700000;
            this.Purchase_BikerBusiness(2);
            this.Purchase_ExecutiveBusiness(1);
            this.Purchase_GunrunningBusiness(6);
            this.Purchase_SmugglersRun(4);
            this.Purchase_DoomsdayHeistBusiness(7);
            this.Purchase_ArenaWarBusiness();
            this.Purchase_LCC();
            this.Purchase_DCAR(4);
            this.Purchase_AfterhoursBusiness(2);
          }
          else
            UI.Notify(" You do not have enought money for this Business Pass");
        }
        if (item == CondensedBP)
        {
          if (Game.Player.Money >= 14545000)
          {
            Game.Player.Money -= 14545000;
            this.Purchase_BikerBusiness(2);
            this.Purchase_ExecutiveBusiness(0);
            this.Purchase_GunrunningBusiness(2);
            this.Purchase_SmugglersRun(0);
            this.Purchase_DoomsdayHeistBusiness(7);
            this.Purchase_ArenaWarBusiness();
            this.Purchase_LCC();
            this.Purchase_DCAR(1);
            this.Purchase_AfterhoursBusiness(0);
          }
          else
            UI.Notify(" You do not have enought money for this Business Pass");
        }
        if (item == CityBP)
        {
          if (Game.Player.Money >= 12380000)
          {
            Game.Player.Money -= 12380000;
            this.Purchase_BikerBusiness(8);
            this.Purchase_ExecutiveBusiness(0);
            this.Purchase_GunrunningBusiness(10);
            this.Purchase_SmugglersRun(1);
            this.Purchase_DoomsdayHeistBusiness(6);
            this.Purchase_ArenaWarBusiness();
            this.Purchase_LCC();
            this.Purchase_DCAR(1);
            this.Purchase_AfterhoursBusiness(5);
          }
          else
            UI.Notify(" You do not have enought money for this Business Pass");
        }
        if (item == SandyShoresBP)
        {
          if (Game.Player.Money >= 13742000)
          {
            Game.Player.Money -= 13742000;
            this.Purchase_BikerBusiness(0);
            this.Purchase_ExecutiveBusiness(3);
            this.Purchase_GunrunningBusiness(7);
            this.Purchase_SmugglersRun(3);
            this.Purchase_DoomsdayHeistBusiness(4);
            this.Purchase_ArenaWarBusiness();
            this.Purchase_LCC();
            this.Purchase_DCAR(1);
            this.Purchase_AfterhoursBusiness(1);
          }
          else
            UI.Notify(" You do not have enought money for this Business Pass");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "Biker Business Options");
      this.GUIMenus.Add(uiMenu3);
      UIMenuItem DELPERRO = new UIMenuItem("Del Perro Beach Clubhouse : ~g~ $365,000");
      uiMenu3.AddItem(DELPERRO);
      UIMenuItem DOWNTOWNVINEWOOD = new UIMenuItem("Downtown Vinewood Clubhouse : ~g~ $472,000");
      uiMenu3.AddItem(DOWNTOWNVINEWOOD);
      UIMenuItem GRAPESEEDC = new UIMenuItem("Grapeseed Clubhouse : ~g~ $225,000");
      uiMenu3.AddItem(GRAPESEEDC);
      UIMenuItem GREATCHAPARRAL = new UIMenuItem("Great Chaparral Clubhouse : ~g~ $200,000");
      uiMenu3.AddItem(GREATCHAPARRAL);
      UIMenuItem Hawick = new UIMenuItem("Hawick Clubhouse : ~g~ $495,000");
      uiMenu3.AddItem(Hawick);
      UIMenuItem LaMesa = new UIMenuItem("La Mesa Clubhouse : ~g~ $449,000");
      uiMenu3.AddItem(LaMesa);
      UIMenuItem PaletoBay1 = new UIMenuItem("Paleto Bay (1) Clubhouse : ~g~ $242,000");
      uiMenu3.AddItem(PaletoBay1);
      UIMenuItem PaletoBay2 = new UIMenuItem("Paleto Bay (2) Clubhouse : ~g~ $250,000");
      uiMenu3.AddItem(PaletoBay2);
      UIMenuItem PilboxHill = new UIMenuItem("Pilbox Hill Clubhouse : ~g~ $455,000");
      uiMenu3.AddItem(PilboxHill);
      UIMenuItem RANCHOc = new UIMenuItem("Rancho Clubhouse : ~g~ $420,000");
      uiMenu3.AddItem(RANCHOc);
      UIMenuItem SandyShoresC = new UIMenuItem("Sandy Shores Clubhouse : ~g~ $210,000");
      uiMenu3.AddItem(SandyShoresC);
      UIMenuItem VespucciBeach = new UIMenuItem("Vespucci Beach Clubhouse : ~g~ $395,000");
      uiMenu3.AddItem(VespucciBeach);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        if (item == DELPERRO)
        {
          if (Game.Player.Money >= 365000)
          {
            Game.Player.Money -= 365000;
            this.Purchase_BikerBusiness(9);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == DOWNTOWNVINEWOOD)
        {
          if (Game.Player.Money >= 472000)
          {
            Game.Player.Money -= 472000;
            this.Purchase_BikerBusiness(10);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == GRAPESEEDC)
        {
          if (Game.Player.Money >= 225000)
          {
            Game.Player.Money -= 225000;
            this.Purchase_BikerBusiness(0);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == GREATCHAPARRAL)
        {
          if (Game.Player.Money >= 200000)
          {
            Game.Player.Money -= 200000;
            this.Purchase_BikerBusiness(11);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Hawick)
        {
          if (Game.Player.Money >= 495000)
          {
            Game.Player.Money -= 495000;
            this.Purchase_BikerBusiness(2);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == LaMesa)
        {
          if (Game.Player.Money >= 449000)
          {
            Game.Player.Money -= 449000;
            this.Purchase_BikerBusiness(3);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == PaletoBay1)
        {
          if (Game.Player.Money >= 242000)
          {
            Game.Player.Money -= 242000;
            this.Purchase_BikerBusiness(4);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == PaletoBay2)
        {
          if (Game.Player.Money >= 250000)
          {
            Game.Player.Money -= 250000;
            this.Purchase_BikerBusiness(8);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == PilboxHill)
        {
          if (Game.Player.Money >= 455000)
          {
            Game.Player.Money -= 455000;
            this.Purchase_BikerBusiness(5);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == RANCHOc)
        {
          if (Game.Player.Money >= 420000)
          {
            Game.Player.Money -= 420000;
            this.Purchase_BikerBusiness(6);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == SandyShoresC)
        {
          if (Game.Player.Money >= 210000)
          {
            Game.Player.Money -= 210000;
            this.Purchase_BikerBusiness(7);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == VespucciBeach)
        {
          if (Game.Player.Money >= 395000)
          {
            Game.Player.Money -= 395000;
            this.Purchase_BikerBusiness(1);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          this.Veh = Game.Player.Character.CurrentVehicle;
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "Executive Business Options");
      this.GUIMenus.Add(uiMenu4);
      UIMenuItem MBW = new UIMenuItem("Maze Bank West : ~g~ $1,000,000");
      uiMenu4.AddItem(MBW);
      UIMenuItem ARC = new UIMenuItem("Arcadius : ~g~ $2,250,000");
      uiMenu4.AddItem(ARC);
      UIMenuItem LOM = new UIMenuItem("Lombok : ~g~ $3,100,000");
      uiMenu4.AddItem(LOM);
      UIMenuItem MBT = new UIMenuItem("Maze Bank Tower : ~g~ $4,000,000");
      uiMenu4.AddItem(MBT);
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        if (item == MBW)
        {
          if (Game.Player.Money >= 1000000)
          {
            Game.Player.Money -= 1000000;
            this.Purchase_ExecutiveBusiness(3);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == ARC)
        {
          if (Game.Player.Money >= 2250000)
          {
            Game.Player.Money -= 2250000;
            this.Purchase_ExecutiveBusiness(0);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == LOM)
        {
          if (Game.Player.Money >= 3100000)
          {
            Game.Player.Money -= 3100000;
            this.Purchase_ExecutiveBusiness(2);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == MBT)
        {
          if (Game.Player.Money >= 4000000)
          {
            Game.Player.Money -= 4000000;
            this.Purchase_ExecutiveBusiness(1);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          this.Veh = Game.Player.Character.CurrentVehicle;
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu5 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "Gunrunning Business Options");
      this.GUIMenus.Add(uiMenu5);
      UIMenuItem PALETO = new UIMenuItem("Paleto Forest Bunker : ~g~ $1,165,000");
      uiMenu5.AddItem(PALETO);
      UIMenuItem RATONCANYON = new UIMenuItem("Raton Canyon Bunker : ~g~ $1,450,000");
      uiMenu5.AddItem(RATONCANYON);
      UIMenuItem LAGOZANCUDO = new UIMenuItem("Lago Zancudo Bunker : ~g~ $1,550,000");
      uiMenu5.AddItem(LAGOZANCUDO);
      UIMenuItem CHUMASH = new UIMenuItem("Chumash Bunker : ~g~ $1,650,000");
      uiMenu5.AddItem(CHUMASH);
      UIMenuItem GRAPESEED = new UIMenuItem("Grapeseed Bunker : ~g~ $1,750,000");
      uiMenu5.AddItem(GRAPESEED);
      UIMenuItem ROUTE68 = new UIMenuItem("Route 68 Bunker : ~g~ $1,950,000");
      uiMenu5.AddItem(ROUTE68);
      UIMenuItem GSOilfields = new UIMenuItem("Senora Oil Fields Bunker : ~g~ $2,035,000");
      uiMenu5.AddItem(GSOilfields);
      UIMenuItem GS = new UIMenuItem("Grand Senora Desert Bunker : ~g~ $2,120,000");
      uiMenu5.AddItem(GS);
      UIMenuItem SMOKETREE = new UIMenuItem("Smoke Tree Road Bunker : ~g~ $2,205,000");
      uiMenu5.AddItem(SMOKETREE);
      UIMenuItem THOMSONSCRAPYARD = new UIMenuItem("Thomson Scrapyard Bunker : ~g~ $2,290,000");
      uiMenu5.AddItem(THOMSONSCRAPYARD);
      UIMenuItem FARMHOUSE = new UIMenuItem("Farm House Bunker : ~g~ $2,375,000");
      uiMenu5.AddItem(FARMHOUSE);
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//Main.ini");
        if (item == PALETO)
        {
          if (Game.Player.Money >= 1165000)
          {
            Game.Player.Money -= 1165000;
            this.Purchase_GunrunningBusiness(10);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == RATONCANYON)
        {
          if (Game.Player.Money >= 1450000)
          {
            Game.Player.Money -= 1450000;
            this.Purchase_GunrunningBusiness(1);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == LAGOZANCUDO)
        {
          if (Game.Player.Money >= 1550000)
          {
            Game.Player.Money -= 1550000;
            this.Purchase_GunrunningBusiness(0);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == CHUMASH)
        {
          if (Game.Player.Money >= 1650000)
          {
            Game.Player.Money -= 16500000;
            this.Purchase_GunrunningBusiness(2);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == GRAPESEED)
        {
          if (Game.Player.Money >= 1750000)
          {
            Game.Player.Money -= 1750000;
            this.Purchase_GunrunningBusiness(3);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == ROUTE68)
        {
          if (Game.Player.Money >= 1950000)
          {
            Game.Player.Money -= 1950000;
            this.Purchase_GunrunningBusiness(7);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == GSOilfields)
        {
          if (Game.Player.Money >= 2035000)
          {
            Game.Player.Money -= 2035000;
            this.Purchase_GunrunningBusiness(9);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == GS)
        {
          if (Game.Player.Money >= 2120000)
          {
            Game.Player.Money -= 2120000;
            this.Purchase_GunrunningBusiness(4);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == SMOKETREE)
        {
          if (Game.Player.Money >= 2205000)
          {
            Game.Player.Money -= 2205000;
            this.Purchase_GunrunningBusiness(5);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == THOMSONSCRAPYARD)
        {
          if (Game.Player.Money >= 2290000)
          {
            Game.Player.Money -= 2290000;
            this.Purchase_GunrunningBusiness(8);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == FARMHOUSE)
        {
          if (Game.Player.Money >= 2375000)
          {
            Game.Player.Money -= 2375000;
            this.Purchase_GunrunningBusiness(6);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu6 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "Smuggler's Run Business Options");
      this.GUIMenus.Add(uiMenu6);
      UIMenuItem LSIA1 = new UIMenuItem("LSIA 1 : ~g~ $1,200,000");
      uiMenu6.AddItem(LSIA1);
      UIMenuItem LSIA2 = new UIMenuItem("LSIA 2 : ~g~ $1,525,000");
      uiMenu6.AddItem(LSIA2);
      UIMenuItem FZ1 = new UIMenuItem("FZ1 1 : ~g~ $2,650,000");
      uiMenu6.AddItem(FZ1);
      UIMenuItem FZ2 = new UIMenuItem("FZ1 2 : ~g~ $2,085,000");
      uiMenu6.AddItem(FZ2);
      UIMenuItem FZ3 = new UIMenuItem("FZ1 3 : ~g~ $3,250,000");
      uiMenu6.AddItem(FZ3);
      uiMenu6.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
        if (item == LSIA1)
        {
          if (Game.Player.Money >= 1200000)
          {
            Game.Player.Money -= 1200000;
            this.Purchase_SmugglersRun(0);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == LSIA2)
        {
          if (Game.Player.Money >= 1525000)
          {
            Game.Player.Money -= 1525000;
            this.Purchase_SmugglersRun(1);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == FZ1)
        {
          if (Game.Player.Money >= 2650000)
          {
            Game.Player.Money -= 2650000;
            this.Purchase_SmugglersRun(2);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == FZ2)
        {
          if (Game.Player.Money >= 2085000)
          {
            Game.Player.Money -= 2085000;
            this.Purchase_SmugglersRun(3);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == FZ3)
        {
          if (Game.Player.Money >= 3250000)
          {
            Game.Player.Money -= 3250000;
            this.Purchase_SmugglersRun(4);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu7 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "Doomsday Heist Business Options");
      this.GUIMenus.Add(uiMenu7);
      UIMenuItem PALETO_F = new UIMenuItem("Paleto Bay Facility : ~g~ $1,250,000");
      uiMenu7.AddItem(PALETO_F);
      UIMenuItem MTGORDO_F = new UIMenuItem("Mt Gordo Facility : ~g~ $1,465,000");
      uiMenu7.AddItem(MTGORDO_F);
      UIMenuItem SANDYSHORES_F = new UIMenuItem("Sandy Shores Facility : ~g~ $2,740,000");
      uiMenu7.AddItem(SANDYSHORES_F);
      UIMenuItem ZANCUDO_F = new UIMenuItem("Zancudo River Facility : ~g~ $2,100,000");
      uiMenu7.AddItem(ZANCUDO_F);
      UIMenuItem GSENORA_F = new UIMenuItem("Grand Senora Facility : ~g~ $2,525,000");
      uiMenu7.AddItem(GSENORA_F);
      UIMenuItem LZANCUDO_F = new UIMenuItem("Lago Zancudo Facility : ~g~ $1,670,000");
      uiMenu7.AddItem(LZANCUDO_F);
      UIMenuItem ROUTE68_F = new UIMenuItem("Route 68 Facility : ~g~ $2,312,000");
      uiMenu7.AddItem(ROUTE68_F);
      UIMenuItem WindFarm_F = new UIMenuItem("Wind Farm Facility : ~g~ $1,855,000");
      uiMenu7.AddItem(WindFarm_F);
      UIMenuItem Reservoir_F = new UIMenuItem("Reservoir Facility : ~g~ $2,950,000");
      uiMenu7.AddItem(Reservoir_F);
      uiMenu7.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
        if (item == PALETO_F)
        {
          if (Game.Player.Money >= 1250000)
          {
            Game.Player.Money -= 1250000;
            this.Purchase_DoomsdayHeistBusiness(6);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == MTGORDO_F)
        {
          if (Game.Player.Money >= 1465000)
          {
            Game.Player.Money -= 1465000;
            this.Purchase_DoomsdayHeistBusiness(5);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == SANDYSHORES_F)
        {
          if (Game.Player.Money >= 2740000)
          {
            Game.Player.Money -= 2740000;
            this.Purchase_DoomsdayHeistBusiness(3);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == ZANCUDO_F)
        {
          if (Game.Player.Money >= 2100000)
          {
            Game.Player.Money -= 2100000;
            this.Purchase_DoomsdayHeistBusiness(8);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == GSENORA_F)
        {
          if (Game.Player.Money >= 2525000)
          {
            Game.Player.Money -= 2525000;
            this.Purchase_DoomsdayHeistBusiness(1);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == LZANCUDO_F)
        {
          if (Game.Player.Money >= 1670000)
          {
            Game.Player.Money -= 1670000;
            this.Purchase_DoomsdayHeistBusiness(0);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == ROUTE68_F)
        {
          if (Game.Player.Money >= 2312000)
          {
            Game.Player.Money -= 2312000;
            this.Purchase_DoomsdayHeistBusiness(4);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == WindFarm_F)
        {
          if (Game.Player.Money >= 1855000)
          {
            Game.Player.Money -= 1855000;
            this.Purchase_DoomsdayHeistBusiness(2);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Reservoir_F)
        {
          if (Game.Player.Money >= 2950000)
          {
            Game.Player.Money -= 2950000;
            this.Purchase_DoomsdayHeistBusiness(7);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu8 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "Arena War Business Options");
      this.GUIMenus.Add(uiMenu8);
      UIMenuItem ArenaWar1 = new UIMenuItem("Arena War Business : $1,000,000");
      uiMenu8.AddItem(ArenaWar1);
      uiMenu8.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != ArenaWar1)
          return;
        if (Game.Player.Money >= 1000000)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          this.Purchase_ArenaWarBusiness();
          Game.Player.Money -= 1000000;
        }
        else
          UI.Notify(" You do not have enought money for this Business ");
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu9 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "LCC Business Options");
      this.GUIMenus.Add(uiMenu9);
      UIMenuItem LCCBusiness = new UIMenuItem("LCC : $2,000,000");
      uiMenu9.AddItem(LCCBusiness);
      uiMenu9.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != LCCBusiness)
          return;
        if (Game.Player.Money >= 2000000)
        {
          Game.Player.Money -= 200000;
          this.Purchase_LCC();
        }
        else
          UI.Notify(" You do not have enought money for this Business ");
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu menu1 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "DC&R Business Options");
      this.GUIMenus.Add(menu1);
      UIMenu menu2 = this.modMenuPool.AddSubMenu(menu1, "Business Options");
      this.GUIMenus.Add(menu2);
      UIMenu menu3 = this.modMenuPool.AddSubMenu(menu1, "Penthouse Options");
      this.GUIMenus.Add(menu3);
      UIMenu menu4 = this.modMenuPool.AddSubMenu(menu1, "Arcade Business Options");
      this.GUIMenus.Add(menu4);
      UIMenu uiMenu10 = this.modMenuPool.AddSubMenu(menu3, "Penthouse");
      this.GUIMenus.Add(uiMenu10);
      UIMenuListItem S = new UIMenuListItem("Style : ", items2, 0);
      uiMenu10.AddItem((UIMenuItem) S);
      UIMenuListItem B = new UIMenuListItem("Bar : ", items3, 0);
      uiMenu10.AddItem((UIMenuItem) B);
      UIMenuListItem Sp = new UIMenuListItem("Spa : ", items4, 0);
      uiMenu10.AddItem((UIMenuItem) Sp);
      UIMenuListItem M = new UIMenuListItem("Media Room  : ", items5, 0);
      uiMenu10.AddItem((UIMenuItem) M);
      UIMenuListItem EB = new UIMenuListItem("Extra Bedroom : ", items6, 0);
      uiMenu10.AddItem((UIMenuItem) EB);
      UIMenuListItem BL = new UIMenuListItem("Bar Light : ", items7, 0);
      uiMenu10.AddItem((UIMenuItem) BL);
      UIMenuListItem PD = new UIMenuListItem("Poker Dealer: ", items8, 0);
      uiMenu10.AddItem((UIMenuItem) PD);
      UIMenuListItem A = new UIMenuListItem("Arcade : ", items9, 0);
      uiMenu10.AddItem((UIMenuItem) A);
      UIMenuListItem C = new UIMenuListItem("Colour : ", items10, 0);
      uiMenu10.AddItem((UIMenuItem) C);
      UIMenuItem Buy = new UIMenuItem("Buy " + Cost.ToString("N"));
      uiMenu10.AddItem(Buy);
      UIMenuItem uiMenuItem = new UIMenuItem("-----------------------------------------------------------");
      uiMenu10.AddItem(uiMenuItem);
      UIMenuListItem uiMenuListItem = new UIMenuListItem("Preview Design : ", items1, 0);
      uiMenu10.AddItem((UIMenuItem) uiMenuListItem);
      uiMenu10.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
        BarCost = B.Index != 1 ? 0.0f : 700000f;
        SpaCost = Sp.Index != 1 ? 0.0f : 600000f;
        ExtraB_Cost = EB.Index != 1 ? 0.0f : 200000f;
        PDcost = PD.Index != 1 ? 0.0f : 1065000f;
        MediaCost = M.Index != 1 ? 0.0f : 200000f;
        StyleCost = S.Index < 1 ? 0.0f : (float) (240000 * (int) (1.35 * (double) S.Index));
        Cost = BarCost + SpaCost + ExtraB_Cost + PDcost + MediaCost + StyleCost;
        Buy.Text = "Buy " + Cost.ToString("N");
        if (item == Buy)
        {
          if ((double) Game.Player.Character.Money <= (double) Cost)
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
            Game.Player.Money -= (int) Cost;
            this.Penthouse_Style = S.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_Style", this.Penthouse_Style);
            this.Penthouse_Media = M.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_Media", this.Penthouse_Media);
            this.Penthouse_Spa = Sp.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_Spa", this.Penthouse_Spa);
            this.Penthouse_Bar = B.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_Bar", this.Penthouse_Bar);
            this.Penthouse_Colour = C.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_Colour", this.Penthouse_Colour);
            this.Penthouse_Arcade = A.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_Arcade", this.Penthouse_Arcade);
            this.Penthouse_BarLight = BL.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_BarLight", this.Penthouse_BarLight);
            this.Penthouse_PokerDealer = PD.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_PokerDealer", this.Penthouse_PokerDealer);
            this.Penthouse_ExtraBedroom = EB.Index;
            this.Config.SetValue<int>("Penthouse", "Penthouse_ExtraBedroom", this.Penthouse_ExtraBedroom);
            this.Config.Save();
          }
          else
            UI.Notify("You do not have enough money for this Penthouse");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      uiMenu10.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
        BarCost = B.Index != 1 ? 0.0f : 700000f;
        SpaCost = Sp.Index != 1 ? 0.0f : 600000f;
        ExtraB_Cost = EB.Index != 1 ? 0.0f : 200000f;
        PDcost = PD.Index != 1 ? 0.0f : 1065000f;
        MediaCost = M.Index != 1 ? 0.0f : 200000f;
        StyleCost = S.Index < 1 ? 0.0f : (float) (240000 * (int) (1.35 * (double) S.Index));
        Cost = BarCost + SpaCost + ExtraB_Cost + PDcost + MediaCost + StyleCost;
        Buy.Text = "Buy " + Cost.ToString("N");
      });
      UIMenu uiMenu11 = this.modMenuPool.AddSubMenu(menu2, "Memberships");
      this.GUIMenus.Add(uiMenu11);
      UIMenuItem Basic = new UIMenuItem("Basic Membership : $500");
      uiMenu11.AddItem(Basic);
      Basic.Description = "Basic Membership, No Penthouse, No rooftop access, No garage, no Busines access, used for playing the games";
      UIMenuItem Business = new UIMenuItem("Business Membership : $1,500,000");
      uiMenu11.AddItem(Business);
      Business.Description = "Business Membership, No Penthouse, No rooftop access, No garage, full Business access starting on business level 1";
      UIMenuItem Vip = new UIMenuItem("VIP Membership : $6,000,000");
      uiMenu11.AddItem(Vip);
      Vip.Description = "Vip Membership, Full Penthouse, Full rooftop access, 35 car garage, full Business access starting on business level 1";
      UIMenuItem VipPlus = new UIMenuItem("VIP+  Membership : $12,000,000");
      uiMenu11.AddItem(VipPlus);
      VipPlus.Description = "Vip Membership, Full Penthouse, Full rooftop access, 35 car garage, full Business access starting on business level 10";
      uiMenu11.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
        if (item == Basic)
        {
          if (Game.Player.Money >= 500)
          {
            Game.Player.Money -= 500;
            this.Purchase_DCAR(1);
            UI.Notify(" Successfuly Purchased ~p~Basic~w~ Membership, Enjoy your Stay");
          }
          else
            UI.Notify(" : You do not have enough money for this!");
        }
        if (item == Business)
        {
          if (Game.Player.Money >= 1500000)
          {
            Game.Player.Money -= 1500000;
            this.Purchase_DCAR(2);
            UI.Notify("  Successfuly Purchased ~p~Business~w~ Membership, Enjoy your Stay");
          }
          else
            UI.Notify(" You do not have enough money for this!");
        }
        if (item == Vip)
        {
          if (Game.Player.Money >= 6000000)
          {
            Game.Player.Money -= 6000000;
            this.Purchase_DCAR(3);
            UI.Notify(" Successfuly Purchased ~p~Vip~w~ Membership, Enjoy your Stay");
          }
          else
            UI.Notify(" You do not have enough money for this!");
        }
        if (item == VipPlus)
        {
          if (Game.Player.Money >= 12000000)
          {
            Game.Player.Money -= 12000000;
            this.Purchase_DCAR(4);
            UI.Notify(" Successfuly Purchased ~p~Vip+~w~ Membership, Enjoy your Stay");
            this.modMenuPool.CloseAllMenus();
          }
          else
            UI.Notify(" You do not have enough money for this!");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu12 = this.modMenuPool.AddSubMenu(menu4, "Purchase Arcade Subbusiness");
      this.GUIMenus.Add(uiMenu12);
      UIMenuItem Arcade1 = new UIMenuItem("Pixel Pete's - Paleto Bay - $1,235,000");
      uiMenu12.AddItem(Arcade1);
      UIMenuItem Arcade2 = new UIMenuItem("Wonderama - Grapeseed - $1,565,000");
      uiMenu12.AddItem(Arcade2);
      UIMenuItem Arcade3 = new UIMenuItem("Videogeddon -La Mesa - $1,875,000");
      uiMenu12.AddItem(Arcade3);
      UIMenuItem Arcade4 = new UIMenuItem("Warehouse - Davis $2,135,000");
      uiMenu12.AddItem(Arcade4);
      UIMenuItem Arcade5 = new UIMenuItem("Insert Coin - Rockford Hills - $2,345,000");
      uiMenu12.AddItem(Arcade5);
      UIMenuItem Arcade6 = new UIMenuItem("Eight Bit - Vinewood - $2,530,000");
      uiMenu12.AddItem(Arcade6);
      uiMenu12.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
        if (item == Arcade1 && Game.Player.Money >= 1235000)
        {
          Game.Player.Money -= 1235000;
          UI.Notify("You have successfuly purchased Arcade : Pixel Pete's");
          if (this.ArcadeOwned != 1)
          {
            this.ArcadeOwned = 1;
            this.Config.SetValue<int>("Arcade", "ArcadeOwned", this.ArcadeOwned);
          }
          this.ArcadeVersion = 1;
          this.Config.SetValue<int>("Arcade", "ArcadeVersion", this.ArcadeVersion);
          this.Config.Save();
        }
        if (item == Arcade2 && Game.Player.Money >= 1565000)
        {
          Game.Player.Money -= 1565000;
          UI.Notify("You have successfuly purchased Arcade : Wonderama");
          if (this.ArcadeOwned != 1)
          {
            this.ArcadeOwned = 1;
            this.Config.SetValue<int>("Arcade", "ArcadeOwned", this.ArcadeOwned);
          }
          this.ArcadeVersion = 2;
          this.Config.SetValue<int>("Arcade", "ArcadeVersion", this.ArcadeVersion);
          this.Config.Save();
        }
        if (item == Arcade3 && Game.Player.Money >= 1875000)
        {
          Game.Player.Money -= 1875000;
          UI.Notify("You have successfuly purchased Arcade : Videogeddon");
          if (this.ArcadeOwned != 1)
          {
            this.ArcadeOwned = 1;
            this.Config.SetValue<int>("Arcade", "ArcadeOwned", this.ArcadeOwned);
          }
          this.ArcadeVersion = 3;
          this.Config.SetValue<int>("Arcade", "ArcadeVersion", this.ArcadeVersion);
          this.Config.Save();
        }
        if (item == Arcade4 && Game.Player.Money >= 2135000)
        {
          Game.Player.Money -= 2135000;
          UI.Notify("You have successfuly purchased Arcade : Warehouse");
          if (this.ArcadeOwned != 1)
          {
            this.ArcadeOwned = 1;
            this.Config.SetValue<int>("Arcade", "ArcadeOwned", this.ArcadeOwned);
          }
          this.ArcadeVersion = 4;
          this.Config.SetValue<int>("Arcade", "ArcadeVersion", this.ArcadeVersion);
          this.Config.Save();
        }
        if (item == Arcade5 && Game.Player.Money >= 2345000)
        {
          Game.Player.Money -= 2345000;
          UI.Notify("You have successfuly purchased Arcade : Insert Coin");
          if (this.ArcadeOwned != 1)
          {
            this.ArcadeOwned = 1;
            this.Config.SetValue<int>("Arcade", "ArcadeOwned", this.ArcadeOwned);
          }
          this.ArcadeVersion = 5;
          this.Config.SetValue<int>("Arcade", "ArcadeVersion", this.ArcadeVersion);
          this.Config.Save();
        }
        if (item == Arcade6 && Game.Player.Money >= 2530000)
        {
          Game.Player.Money -= 2530000;
          UI.Notify("You have successfuly purchased Arcade : Eight Bit");
          if (this.ArcadeOwned != 1)
          {
            this.ArcadeOwned = 1;
            this.Config.SetValue<int>("Arcade", "ArcadeOwned", this.ArcadeOwned);
          }
          this.ArcadeVersion = 6;
          this.Config.SetValue<int>("Arcade", "ArcadeVersion", this.ArcadeVersion);
          this.Config.Save();
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
      UIMenu uiMenu13 = this.modMenuPool.AddSubMenu(this.BusinessPurhaseMenu, "After Hours Business Options");
      this.GUIMenus.Add(uiMenu13);
      UIMenuItem Loc1 = new UIMenuItem("Del Perro : ~g~ $1,500,000");
      uiMenu13.AddItem(Loc1);
      UIMenuItem Loc2 = new UIMenuItem("Downtown Vinewood : ~g~ $1,670,000");
      uiMenu13.AddItem(Loc2);
      UIMenuItem Loc3 = new UIMenuItem("West Vinewood  :~g~ $1,700,000");
      uiMenu13.AddItem(Loc3);
      UIMenuItem Loc4 = new UIMenuItem("Vespucci Canals  :~g~ $1,320,000");
      uiMenu13.AddItem(Loc4);
      UIMenuItem Loc5 = new UIMenuItem("Strawberry  : ~g~$1,525,000");
      uiMenu13.AddItem(Loc5);
      UIMenuItem Loc6 = new UIMenuItem("Mission Row : ~g~$1,440,000");
      uiMenu13.AddItem(Loc6);
      UIMenuItem Loc7 = new UIMenuItem("La Mesa :~g~ $1,500,000");
      uiMenu13.AddItem(Loc7);
      UIMenuItem Loc8 = new UIMenuItem("Cypress Flats  : ~g~$1,370,000 ");
      uiMenu13.AddItem(Loc8);
      UIMenuItem Loc9 = new UIMenuItem("LSIA : ~g~$1,135,000");
      uiMenu13.AddItem(Loc9);
      UIMenuItem Loc10 = new UIMenuItem("Elysian Island :~g~ $1,080,000");
      uiMenu13.AddItem(Loc10);
      uiMenu13.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
        if (item == Loc1)
        {
          if (Game.Player.Money >= 1500000)
          {
            Game.Player.Money -= 1500000;
            this.Purchase_AfterhoursBusiness(0);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc2)
        {
          if (Game.Player.Money >= 1670000)
          {
            Game.Player.Money -= 1670000;
            this.Purchase_AfterhoursBusiness(1);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc3)
        {
          if (Game.Player.Money >= 1700000)
          {
            Game.Player.Money -= 1700000;
            this.Purchase_AfterhoursBusiness(2);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc4)
        {
          if (Game.Player.Money >= 1320000)
          {
            Game.Player.Money -= 1320000;
            this.Purchase_AfterhoursBusiness(3);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc5)
        {
          if (Game.Player.Money >= 1525000)
          {
            Game.Player.Money -= 1525000;
            this.Purchase_AfterhoursBusiness(4);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc6)
        {
          if (Game.Player.Money >= 1440000)
          {
            Game.Player.Money -= 1440000;
            this.Purchase_AfterhoursBusiness(5);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc7)
        {
          if (Game.Player.Money >= 1500000)
          {
            Game.Player.Money -= 1500000;
            this.Purchase_AfterhoursBusiness(6);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc8)
        {
          if (Game.Player.Money >= 1370000)
          {
            Game.Player.Money -= 1370000;
            this.Purchase_AfterhoursBusiness(7);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc9)
        {
          if (Game.Player.Money >= 1135000)
          {
            Game.Player.Money -= 1135000;
            this.Purchase_AfterhoursBusiness(8);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if (item == Loc10)
        {
          if (Game.Player.Money >= 1080000)
          {
            Game.Player.Money -= 1080000;
            this.Purchase_AfterhoursBusiness(9);
          }
          else
            UI.Notify(" You do not have enought money for this Business ");
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          this.Veh = Game.Player.Character.CurrentVehicle;
          this.Veh.IsPersistent = true;
        }
        this.Old = Game.Player.Character.Position;
        Game.Player.Character.Alpha = 15;
        Game.Player.Character.Position = new Vector3(-2399.7f, 718.1f, 221.4f);
        this.Refreshtimer = 1;
      });
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
        this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: " + iniName + " Failed To Load.");
      }
    }

    public void RequestCommandCenter()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Menu3, "Reset Positions to Player Position");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem A = new UIMenuItem("Avenger - Working Avenger Mod");
      uiMenu.AddItem(A);
      UIMenuItem M = new UIMenuItem("MOC - Working MOC Mod");
      uiMenu.AddItem(M);
      UIMenuItem T = new UIMenuItem("Terrobyte - Working Terrobyte Mod");
      uiMenu.AddItem(T);
      UIMenuItem A1 = new UIMenuItem("Avenger - Doomsday Heist Business Mod");
      uiMenu.AddItem(A1);
      UIMenuItem M1 = new UIMenuItem("MOC - Gunrunning Business Mod");
      uiMenu.AddItem(M1);
      UIMenuItem TAFB = new UIMenuItem("Terrobyte - After Hours Business Mod");
      uiMenu.AddItem(TAFB);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == A)
        {
          try
          {
            this.LoadIniFile("scripts//WorkingAvenger//Avenger.ini");
            Vector3 position = Game.Player.Character.Position;
            this.Config.SetValue<float>("Setup", "X", position.X);
            this.Config.SetValue<float>("Setup", "Y", position.Y);
            this.Config.SetValue<float>("Setup", "Z", position.Z);
            this.Config.SetValue<Vector3>("Setup", "AvengerPosition", position);
            this.Config.Save();
            UI.Notify("~b~ OCCI ~w~ : Vehicle location succesfully changed, please reload mods for the changes to take effect (~b~ WKN Avenger ~w~)");
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Error ~w~: Working Avenger Not installed!");
          }
        }
        if (item == M)
        {
          try
          {
            this.LoadIniFile("scripts//WorkingMOC//MOC.ini");
            Vector3 position = Game.Player.Character.Position;
            Vector3 vector3 = position;
            this.Config.SetValue<float>("Setup", "X", vector3.X);
            this.Config.SetValue<float>("Setup", "Y", vector3.Y);
            this.Config.SetValue<float>("Setup", "Z", vector3.Z);
            this.Config.SetValue<Vector3>("Setup", "MOCPosition", position);
            this.Config.Save();
            UI.Notify("~b~ OCCI ~w~ : Vehicle location succesfully changed, please reload mods for the changes to take effect (~r~ WKN MOC ~w~)");
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Error ~w~: Working MOC Not installed!");
          }
        }
        if (item == T)
        {
          try
          {
            this.LoadIniFile("scripts//AfterHours//Terrobyte//Terrobyte.ini");
            Vector3 position = Game.Player.Character.Position;
            Vector3 vector3 = position;
            this.Config.SetValue<float>("Setup", "X", vector3.X);
            this.Config.SetValue<float>("Setup", "Y", vector3.Y);
            this.Config.SetValue<float>("Setup", "Z", vector3.Z);
            this.Config.SetValue<Vector3>("Setup", "MOCPosition", position);
            this.Config.Save();
            UI.Notify("~b~ OCCI ~w~ : Vehicle location succesfully changed, please reload mods for the changes to take effect (~b~ WKN Terrobyte ~w~)");
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Error ~w~: Working Terrobyte Not installed!");
          }
        }
        if (item == A1)
        {
          try
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Avenger.ini");
            Vector3 position = Game.Player.Character.Position;
            this.Config.SetValue<float>("Setup", "X", position.X);
            this.Config.SetValue<float>("Setup", "Y", position.Y);
            this.Config.SetValue<float>("Setup", "Z", position.Z);
            this.Config.SetValue<Vector3>("Setup", "AvengerPosition", position);
            this.Config.Save();
            UI.Notify("~b~ OCCI ~w~ : Vehicle location succesfully changed, please reload mods for the changes to take effect (~p~ DBM Avenger ~w~)");
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Error ~w~: Doomsday Heist Business Not installed!");
          }
        }
        if (item == TAFB)
        {
          try
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//Terrobyte//Terrobyte.ini");
            Vector3 position = Game.Player.Character.Position;
            Vector3 vector3 = position;
            this.Config.SetValue<float>("Setup", "X", vector3.X);
            this.Config.SetValue<float>("Setup", "Y", vector3.Y);
            this.Config.SetValue<float>("Setup", "Z", vector3.Z);
            this.Config.SetValue<Vector3>("Setup", "MOCPosition", position);
            this.Config.Save();
            UI.Notify("~b~ OCCI ~w~ : Vehicle location succesfully changed, please reload mods for the changes to take effect (~y~ AFB Terrobyte ~w~)");
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Error ~w~: Working Terrobyte Not installed!");
          }
        }
        if (item != M1)
          return;
        try
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//WorkingMOC//MOC.ini");
          Vector3 position = Game.Player.Character.Position;
          Vector3 vector3 = position;
          this.Config.SetValue<float>("Setup", "X", vector3.X);
          this.Config.SetValue<float>("Setup", "Y", vector3.Y);
          this.Config.SetValue<float>("Setup", "Z", vector3.Z);
          this.Config.SetValue<Vector3>("Setup", "MOCPosition", position);
          this.Config.Save();
          UI.Notify("~b~ OCCI ~w~ : Vehicle location succesfully changed, please reload mods for the changes to take effect (~o~GBM MOC ~w~)");
        }
        catch (Exception ex)
        {
          UI.Notify("~r~ Error ~w~: Gunrunnning Business Not installed!");
        }
      });
      this.GUIMenus.Add(this.modMenuPool.AddSubMenu(this.Menu3, "Command Center"));
    }

    public void AddGarage(string Path, int Slots)
    {
      try
      {
        this.SLots.Clear();
        this.LoadPaths.Clear();
        int num1 = Slots;
        string str = "\\Slot";
        int num2 = num1 + 1;
        for (int index = 1; index < num2; ++index)
        {
          string iniName = Path + str + index.ToString() + ".ini";
          try
          {
            this.LoadIniFile(iniName);
            this.LoadPaths.Add((object) iniName);
            this.SC.LoadIniFile(iniName);
            this.SLots.Add((object) this.SC.VehicleName);
          }
          catch (Exception ex)
          {
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    public void ReturnAfterHoursStorage()
    {
      this.SLots.Clear();
      this.LoadPaths.Clear();
      this.LoadPaths.Add((object) "scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Storage\\MuleCustom.ini");
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Storage\\MuleCustom.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) "scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Storage\\PounderCustom.ini");
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Storage\\PounderCustom.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) "scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Storage\\SpeedoCustom.ini");
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Storage\\SpeedoCustom.ini");
      this.SLots.Add((object) this.SC.VehicleName);
    }

    public void ReturnGunnrunningVehicles(string Path)
    {
      this.SLots.Clear();
      this.LoadPaths.Clear();
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\apc.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\apc.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\dunefav.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\dunefav.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\halftrack.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\halftrack.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\Insurgentcustom.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\Insurgentcustom.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\nightshark.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\nightshark.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\vGunRunningBusiness\\" + Path + "\\oppressor.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\oppressor.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\technicalcustom.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\technicalcustom.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\weaponizedtampa.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\GunRunningBusiness\\" + Path + "\\weaponizedtampa.ini");
      this.SLots.Add((object) this.SC.VehicleName);
    }

    public void ReturnDoomsdayHeistVehicles(string Path)
    {
      this.SLots.Clear();
      this.LoadPaths.Clear();
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Akula.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Akula.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Avenger.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Avenger.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Barrage.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Barrage.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Chernobog.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Chernobog.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Deluxo.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Deluxo.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Khanjali.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Khanjali.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Stromberg.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Stromberg.ini");
      this.SLots.Add((object) this.SC.VehicleName);
      this.LoadPaths.Add((object) ("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Thruster.ini"));
      this.SC.LoadIniFile("scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\" + Path + "\\Thruster.ini");
      this.SLots.Add((object) this.SC.VehicleName);
    }

    public string ReturnGarageVehicle(string Path)
    {
      this.SC.LoadIniFile(Path);
      return this.SC.VehicleName;
    }

    public void VehicleOptions()
    {
      List<object> items = new List<object>();
      items.Add((object) "Biker Business");
      items.Add((object) "Executive Business");
      items.Add((object) "Gunrunning Business");
      items.Add((object) "Smuggler's Run Business");
      items.Add((object) "Doomsday Heist Business");
      items.Add((object) "LCC Business");
      items.Add((object) "Arena War Business");
      items.Add((object) "DC&R Business");
      items.Add((object) "After Hours Business");
      List<object> ClubHouses = new List<object>();
      ClubHouses.Add((object) "Del Perro ClubHouse");
      ClubHouses.Add((object) "Grapeseed Clubhouse");
      ClubHouses.Add((object) "Great Chaparral");
      ClubHouses.Add((object) "Howick ClubHouse");
      ClubHouses.Add((object) "La Mesa ClubHouse");
      ClubHouses.Add((object) "Paleto ClubHouse");
      ClubHouses.Add((object) "Paleto ClubHouse 2");
      ClubHouses.Add((object) "Pillbox Hill ClubHouse");
      ClubHouses.Add((object) "Rancho Club House");
      ClubHouses.Add((object) "Sandy Shores ClubHouse");
      ClubHouses.Add((object) "Vespucci ClubHouse");
      ClubHouses.Add((object) "VineWood ClubHouse");
      List<object> ExGarages = new List<object>();
      ExGarages.Add((object) "Arcadius, Garage A");
      ExGarages.Add((object) "Arcadius, Garage B");
      ExGarages.Add((object) "Arcadius, Garage C");
      ExGarages.Add((object) "MazeBank, Garage A");
      ExGarages.Add((object) "MazeBank, Garage B");
      ExGarages.Add((object) "MazeBank, Garage C");
      ExGarages.Add((object) "MBW, Garage A");
      ExGarages.Add((object) "MBW, Garage B");
      ExGarages.Add((object) "MBW, Garage C");
      ExGarages.Add((object) "Lombok, Garage A");
      ExGarages.Add((object) "Lombok, Garage B");
      ExGarages.Add((object) "Lombok, Garage C");
      ExGarages.Add((object) "Warehouse");
      List<object> Bunker = new List<object>();
      Bunker.Add((object) "Bunker Storage");
      Bunker.Add((object) "Bunker Storage");
      Bunker.Add((object) "Bunker Storage");
      Bunker.Add((object) "Bunker Storage");
      List<object> Facility = new List<object>();
      Facility.Add((object) "Facility Storage");
      Facility.Add((object) "Facility Storage");
      Facility.Add((object) "Facility Storage");
      Facility.Add((object) "Facility Storage");
      List<object> Hanger = new List<object>();
      Hanger.Add((object) "Hanger Storage");
      Hanger.Add((object) "Hanger Storage");
      Hanger.Add((object) "Hanger Storage");
      Hanger.Add((object) "Hanger Storage");
      List<object> LCC = new List<object>();
      LCC.Add((object) "Warehouse");
      List<object> Arena = new List<object>();
      Arena.Add((object) "10 Car Bay");
      List<object> DCAR = new List<object>();
      DCAR.Add((object) "38 Car Garage");
      List<object> AfterHours = new List<object>();
      AfterHours.Add((object) "10 Car Storage");
      AfterHours.Add((object) "Heavy Vehicle Storage");
      this.SLots.Add((object) "No Vehicle In Slot");
      this.LoadPaths.Add((object) "null");
      this.SLots.Add((object) "No Vehicle In Slot");
      this.LoadPaths.Add((object) "null");
      this.SLots.Add((object) "No Vehicle In Slot");
      this.LoadPaths.Add((object) "null");
      this.SLots.Add((object) "No Vehicle In Slot");
      this.LoadPaths.Add((object) "null");
      this.SLots.Add((object) "No Vehicle In Slot");
      this.LoadPaths.Add((object) "null");
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.Menu2, "Request A Vehicle");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem BS = new UIMenuListItem("Business : ", items, 0);
      uiMenu.AddItem((UIMenuItem) BS);
      UIMenuListItem G = new UIMenuListItem("Garage : ", this.Garage, 0);
      uiMenu.AddItem((UIMenuItem) G);
      UIMenuItem uiMenuItem1 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem1);
      UIMenuListItem V = new UIMenuListItem("Slot : ", this.SLots, 0);
      uiMenu.AddItem((UIMenuItem) V);
      UIMenuItem GetV = new UIMenuItem("Get Vehicle");
      uiMenu.AddItem(GetV);
      UIMenuItem uiMenuItem2 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu.AddItem(uiMenuItem2);
      UIMenuItem Slotf = new UIMenuItem("Slot : null");
      uiMenu.AddItem(Slotf);
      UIMenuItem VN = new UIMenuItem("Vehicle Name : null");
      uiMenu.AddItem(VN);
      UIMenuItem PC = new UIMenuItem("Primary Colour : null");
      uiMenu.AddItem(PC);
      UIMenuItem Sc = new UIMenuItem("Secondary Colour : null");
      uiMenu.AddItem(Sc);
      UIMenuItem Nump = new UIMenuItem("Number Plate : null");
      uiMenu.AddItem(Nump);
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        for (int index1 = 0; index1 < this.SLots.Count; ++index1)
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__102.\u003C\u003Ep__0 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__0.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__0, this.SC, this.LoadPaths[V.Index]);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__102.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.C_LoadPath = Class1.\u003C\u003Eo__102.\u003C\u003Ep__1.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__1, this.LoadPaths[V.Index]);
          Slotf.Text = "Slot : " + (V.Index + 1).ToString();
          VN.Text = "Vehicle Name : " + this.SC.VehicleName;
          PC.Text = "Primary Colour : " + this.SC.PrimaryColor.ToString();
          Sc.Text = "Secondary Colour : " + this.SC.SecondaryColor.ToString();
          Nump.Text = "Number Plate : " + this.SC.PlanteNo;
        }
        if (BS.Index == 0)
        {
          this.Garage.Clear();
          foreach (object obj in ClubHouses)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__2.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__2, obj));
          }
        }
        if (BS.Index == 1)
        {
          this.Garage.Clear();
          foreach (object obj in ExGarages)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__3.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__3, obj));
          }
        }
        if (BS.Index == 2)
        {
          this.Garage.Clear();
          foreach (object obj in Bunker)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__4 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__4.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__4, obj));
          }
        }
        if (BS.Index == 3)
        {
          this.Garage.Clear();
          foreach (object obj in Hanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__5 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__5.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__5, obj));
          }
        }
        if (BS.Index == 4)
        {
          this.Garage.Clear();
          foreach (object obj in Facility)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__6 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__6.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__6, obj));
          }
        }
        if (BS.Index == 5)
        {
          this.Garage.Clear();
          foreach (object obj in LCC)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__7 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__7.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__7, obj));
          }
        }
        if (BS.Index == 6)
        {
          this.Garage.Clear();
          foreach (object obj in Arena)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__8 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__8.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__8, obj));
          }
        }
        if (BS.Index == 7)
        {
          this.Garage.Clear();
          foreach (object obj in DCAR)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__9 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__9.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__9, obj));
          }
        }
        if (BS.Index == 8)
        {
          this.Garage.Clear();
          foreach (object obj in AfterHours)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__10.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__10, obj));
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__12 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target1 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__12.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p12 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__12;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__11 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__11.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__11, this.Garage[G.Index], "Del Perro ClubHouse");
        if (target1((CallSite) p12, obj1))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\DelPerroClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target2 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__14.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p14 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__14;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__13.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__13, this.Garage[G.Index], "Grapeseed Clubhouse");
        if (target2((CallSite) p14, obj2))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\GrapeseedClubhouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__16 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__16.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p16 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__16;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__15 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__15.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__15, this.Garage[G.Index], "Great Chaparral");
        if (target3((CallSite) p16, obj3))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\GreatChaparral\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__18 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target4 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__18.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p18 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__18;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__17 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__17.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__17, this.Garage[G.Index], "Howick ClubHouse");
        if (target4((CallSite) p18, obj4))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\HowickClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target5 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__20.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p20 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__20;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__19 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj5 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__19.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__19, this.Garage[G.Index], "La Mesa ClubHouse");
        if (target5((CallSite) p20, obj5))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\LaMesaClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__22 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target6 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__22.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p22 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__22;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__21 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj6 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__21.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__21, this.Garage[G.Index], "Paleto ClubHouse");
        if (target6((CallSite) p22, obj6))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PaletoClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__24 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__24 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target7 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__24.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p24 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__24;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__23 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__23 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj7 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__23.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__23, this.Garage[G.Index], "Paleto Club House 2");
        if (target7((CallSite) p24, obj7))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PaletoClubHouse2\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__26 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__26 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target8 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__26.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p26 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__26;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__25 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__25 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj8 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__25.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__25, this.Garage[G.Index], "Pillbox Hill ClubHouse");
        if (target8((CallSite) p26, obj8))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PillboxHillClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__28 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__28 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target9 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__28.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p28 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__28;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__27 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__27 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj9 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__27.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__27, this.Garage[G.Index], "Rancho ClubHouse");
        if (target9((CallSite) p28, obj9))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\RanchoClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__30 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__30 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target10 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__30.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p30 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__30;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__29 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__29 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj10 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__29.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__29, this.Garage[G.Index], "Sandy Shores ClubHouse");
        if (target10((CallSite) p30, obj10))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\SandyShoresClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__32 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__32 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target11 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__32.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p32 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__32;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__31 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__31 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj11 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__31.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__31, this.Garage[G.Index], "Vespucci ClubHouse");
        if (target11((CallSite) p32, obj11))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\VespucciClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__34 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__34 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target12 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__34.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p34 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__34;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__33 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__33 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj12 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__33.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__33, this.Garage[G.Index], "VineWood ClubHouse");
        if (target12((CallSite) p34, obj12))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\VineWoodClubHouse\\Garage\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__36 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__36 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target13 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__36.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p36 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__36;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__35 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__35 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj13 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__35.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__35, this.Garage[G.Index], "Arcadius, Garage A");
        if (target13((CallSite) p36, obj13))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageA\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__38 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__38 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target14 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__38.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p38 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__38;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__37 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__37 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj14 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__37.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__37, this.Garage[G.Index], "Arcadius, Garage B");
        if (target14((CallSite) p38, obj14))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageB\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__40 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__40 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target15 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__40.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p40 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__40;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__39 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__39 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj15 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__39.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__39, this.Garage[G.Index], "Arcadius, Garage C");
        if (target15((CallSite) p40, obj15))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageC\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__42 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__42 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target16 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__42.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p42 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__42;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__41 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__41 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj16 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__41.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__41, this.Garage[G.Index], "MazeBank, Garage A");
        if (target16((CallSite) p42, obj16))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageA\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__44 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__44 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target17 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__44.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p44 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__44;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__43 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__43 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj17 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__43.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__43, this.Garage[G.Index], "MazeBank, Garage B");
        if (target17((CallSite) p44, obj17))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageB\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__46 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__46 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target18 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__46.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p46 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__46;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__45 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__45 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj18 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__45.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__45, this.Garage[G.Index], "MazeBank, Garage C");
        if (target18((CallSite) p46, obj18))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageC\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__48 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__48 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target19 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__48.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p48 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__48;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__47 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__47 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj19 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__47.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__47, this.Garage[G.Index], "MBW, Garage A");
        if (target19((CallSite) p48, obj19))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageA\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__50 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__50 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target20 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__50.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p50 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__50;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__49 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__49 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj20 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__49.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__49, this.Garage[G.Index], "MBW, Garage B");
        if (target20((CallSite) p50, obj20))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageB\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__52 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__52 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target21 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__52.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p52 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__52;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__51 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__51 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj21 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__51.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__51, this.Garage[G.Index], "MBW, Garage C");
        if (target21((CallSite) p52, obj21))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageC\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__54 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__54 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target22 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__54.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p54 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__54;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__53 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__53 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj22 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__53.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__53, this.Garage[G.Index], "Lombok, Garage A");
        if (target22((CallSite) p54, obj22))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageA\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__56 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__56 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target23 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__56.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p56 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__56;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__55 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__55 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj23 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__55.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__55, this.Garage[G.Index], "Lombok, Garage B");
        if (target23((CallSite) p56, obj23))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageB\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__58 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__58 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target24 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__58.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p58 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__58;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__57 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__57 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj24 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__57.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__57, this.Garage[G.Index], "Lombok, Garage C");
        if (target24((CallSite) p58, obj24))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageC\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__60 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__60 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target25 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__60.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p60 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__60;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__59 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__59 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj25 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__59.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__59, this.Garage[G.Index], "Warehouse");
        if (target25((CallSite) p60, obj25))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\WareHouses\\GarageA\\", 35);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__62 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__62 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target26 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__62.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p62 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__62;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__61 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__61 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj26 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__61.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__61, this.Garage[G.Index], "Bunker Storage");
        if (target26((CallSite) p62, obj26))
          this.ReturnGunnrunningVehicles("BunkerStorage");
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__64 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__64 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target27 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__64.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p64 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__64;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__63 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__63 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj27 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__63.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__63, this.Garage[G.Index], "Facility Storage");
        if (target27((CallSite) p64, obj27))
          this.ReturnDoomsdayHeistVehicles("FacilityStorage");
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__66 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__66 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target28 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__66.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p66 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__66;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__65 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__65 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj28 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__65.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__65, this.Garage[G.Index], "Hanger Storage");
        if (target28((CallSite) p66, obj28))
          this.AddGarage("scripts\\HKH191sBusinessMods\\Smuggler's Run Business\\HangerStorage\\Hanger\\Hanger1\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__68 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__68 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target29 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__68.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p68 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__68;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__67 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__67 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj29 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__67.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__67, this.Garage[G.Index], "Warehouse");
        if (target29((CallSite) p68, obj29))
          this.AddGarage("scripts\\HKH191sBusinessMods\\LCC\\WareHouses\\GarageA\\", 35);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__70 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__70 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target30 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__70.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p70 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__70;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__69 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__69 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj30 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__69.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__69, this.Garage[G.Index], "10 Car Bay");
        if (target30((CallSite) p70, obj30))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\", 10);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__72 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__72 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target31 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__72.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p72 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__72;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__71 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__71 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj31 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__71.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__71, this.Garage[G.Index], "38 Car Garage");
        if (target31((CallSite) p72, obj31))
          this.AddGarage("scripts\\HKH191sBusinessMods\\DC&R\\CasinoGarage\\GarageA\\", 38);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__74 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__74 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target32 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__74.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p74 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__74;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__73 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__73 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj32 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__73.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__73, this.Garage[G.Index], "10 Car Storage");
        if (target32((CallSite) p74, obj32))
          this.AddGarage("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Garage\\", 10);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__76 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__76 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target33 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__76.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p76 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__76;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__75 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__75 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj33 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__75.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__75, this.Garage[G.Index], "Heavy Vehicle Storage");
        if (!target33((CallSite) p76, obj33))
          return;
        this.ReturnAfterHoursStorage();
      });
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != GetV)
          return;
        for (int index1 = 0; index1 < this.SLots.Count; ++index1)
        {
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__77 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__102.\u003C\u003Ep__77 = CallSite<Action<CallSite, SaveCar, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__77.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__77, this.SC, this.LoadPaths[V.Index]);
          // ISSUE: reference to a compiler-generated field
          if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__78 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Class1.\u003C\u003Eo__102.\u003C\u003Ep__78 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Class1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.C_LoadPath = Class1.\u003C\u003Eo__102.\u003C\u003Ep__78.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__78, this.LoadPaths[V.Index]);
          Slotf.Text = "Slot : " + (V.Index + 1).ToString();
          VN.Text = "Vehicle Name : " + this.SC.VehicleName;
          PC.Text = "Primary Colour : " + this.SC.PrimaryColor.ToString();
          Sc.Text = "Secondary Colour : " + this.SC.SecondaryColor.ToString();
          Nump.Text = "Number Plate : " + this.SC.PlanteNo;
        }
        if (BS.Index == 0)
        {
          this.Garage.Clear();
          foreach (object obj in ClubHouses)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__79 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__79 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__79.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__79, obj));
          }
        }
        if (BS.Index == 1)
        {
          this.Garage.Clear();
          foreach (object obj in ExGarages)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__80 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__80 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__80.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__80, obj));
          }
        }
        if (BS.Index == 2)
        {
          this.Garage.Clear();
          foreach (object obj in Bunker)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__81 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__81 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__81.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__81, obj));
          }
        }
        if (BS.Index == 3)
        {
          this.Garage.Clear();
          foreach (object obj in Hanger)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__82 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__82 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__82.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__82, obj));
          }
        }
        if (BS.Index == 4)
        {
          this.Garage.Clear();
          foreach (object obj in Facility)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__83 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__83 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__83.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__83, obj));
          }
        }
        if (BS.Index == 5)
        {
          this.Garage.Clear();
          foreach (object obj in LCC)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__84 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__84 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__84.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__84, obj));
          }
        }
        if (BS.Index == 6)
        {
          this.Garage.Clear();
          foreach (object obj in Arena)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__85 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__85 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__85.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__85, obj));
          }
        }
        if (BS.Index == 7)
        {
          this.Garage.Clear();
          foreach (object obj in DCAR)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__86 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__86 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__86.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__86, obj));
          }
        }
        if (BS.Index == 8)
        {
          this.Garage.Clear();
          foreach (object obj in AfterHours)
          {
            // ISSUE: reference to a compiler-generated field
            if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__87 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Class1.\u003C\u003Eo__102.\u003C\u003Ep__87 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (Class1)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.Garage.Add((object) Class1.\u003C\u003Eo__102.\u003C\u003Ep__87.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__87, obj));
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__89 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__89 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target1 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__89.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p89 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__89;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__88 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__88 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__88.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__88, this.Garage[G.Index], "Del Perro ClubHouse");
        if (target1((CallSite) p89, obj1))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\DelPerroClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__91 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__91 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target2 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__91.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p91 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__91;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__90 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__90 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__90.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__90, this.Garage[G.Index], "HowickClubHouse");
        if (target2((CallSite) p91, obj2))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\HowickClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__93 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__93 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__93.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p93 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__93;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__92 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__92 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__92.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__92, this.Garage[G.Index], "La Mesa ClubHouse");
        if (target3((CallSite) p93, obj3))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\LaMesaClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__95 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__95 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target4 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__95.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p95 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__95;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__94 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__94 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__94.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__94, this.Garage[G.Index], "Paleto ClubHouse");
        if (target4((CallSite) p95, obj4))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PaletoClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__97 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__97 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target5 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__97.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p97 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__97;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__96 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__96 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj5 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__96.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__96, this.Garage[G.Index], "Pillbox Hill ClubHouse");
        if (target5((CallSite) p97, obj5))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\PillboxHillClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__99 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__99 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target6 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__99.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p99 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__99;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__98 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__98 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj6 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__98.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__98, this.Garage[G.Index], "Rancho ClubHouse");
        if (target6((CallSite) p99, obj6))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\RanchoClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__101 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__101 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target7 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__101.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p101 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__101;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__100 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__100 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj7 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__100.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__100, this.Garage[G.Index], "Sandy Shores ClubHouse 1");
        if (target7((CallSite) p101, obj7))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\SafeHouse1\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__103 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__103 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target8 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__103.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p103 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__103;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__102 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__102 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj8 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__102.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__102, this.Garage[G.Index], "Sandy Shores ClubHouse 2");
        if (target8((CallSite) p103, obj8))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\SandyShoresClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__105 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__105 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target9 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__105.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p105 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__105;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__104 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__104 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj9 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__104.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__104, this.Garage[G.Index], "Sandy Shores ClubHouse 3");
        if (target9((CallSite) p105, obj9))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\SandyShoresClubHouse2\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__107 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__107 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target10 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__107.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p107 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__107;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__106 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__106 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj10 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__106.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__106, this.Garage[G.Index], "Vespucci ClubHouse");
        if (target10((CallSite) p107, obj10))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\VespucciClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__109 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__109 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target11 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__109.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p109 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__109;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__108 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__108 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj11 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__108.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__108, this.Garage[G.Index], "VineWood ClubHouse");
        if (target11((CallSite) p109, obj11))
          this.AddGarage("scripts\\HKH191sBusinessMods\\MethBusiness\\ClubHouses\\VineWoodClubHouse\\Garage\\", 4);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__111 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__111 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target12 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__111.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p111 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__111;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__110 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__110 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj12 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__110.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__110, this.Garage[G.Index], "Arcadius, Garage A");
        if (target12((CallSite) p111, obj12))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageA\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__113 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__113 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target13 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__113.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p113 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__113;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__112 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__112 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj13 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__112.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__112, this.Garage[G.Index], "Arcadius, Garage B");
        if (target13((CallSite) p113, obj13))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageB\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__115 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__115 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target14 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__115.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p115 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__115;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__114 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__114 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj14 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__114.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__114, this.Garage[G.Index], "Arcadius, Garage C");
        if (target14((CallSite) p115, obj14))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\ArcadiusGarage\\GarageC\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__117 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__117 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target15 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__117.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p117 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__117;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__116 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__116 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj15 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__116.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__116, this.Garage[G.Index], "MazeBank, Garage A");
        if (target15((CallSite) p117, obj15))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageA\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__119 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__119 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target16 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__119.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p119 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__119;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__118 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__118 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj16 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__118.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__118, this.Garage[G.Index], "MazeBank, Garage B");
        if (target16((CallSite) p119, obj16))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageB\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__121 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__121 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target17 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__121.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p121 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__121;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__120 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__120 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj17 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__120.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__120, this.Garage[G.Index], "MazeBank, Garage C");
        if (target17((CallSite) p121, obj17))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankGarage\\GarageC\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__123 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__123 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target18 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__123.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p123 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__123;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__122 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__122 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj18 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__122.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__122, this.Garage[G.Index], "MBW, Garage A");
        if (target18((CallSite) p123, obj18))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageA\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__125 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__125 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target19 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__125.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p125 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__125;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__124 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__124 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj19 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__124.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__124, this.Garage[G.Index], "MBW, Garage B");
        if (target19((CallSite) p125, obj19))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageB\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__127 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__127 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target20 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__127.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p127 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__127;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__126 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__126 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj20 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__126.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__126, this.Garage[G.Index], "MBW, Garage C");
        if (target20((CallSite) p127, obj20))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\MazeBankWestGarage\\GarageC\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__129 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__129 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target21 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__129.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p129 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__129;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__128 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__128 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj21 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__128.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__128, this.Garage[G.Index], "Lombok, Garage A");
        if (target21((CallSite) p129, obj21))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageA\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__131 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__131 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target22 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__131.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p131 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__131;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__130 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__130 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj22 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__130.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__130, this.Garage[G.Index], "Lombok, Garage B");
        if (target22((CallSite) p131, obj22))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageB\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__133 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__133 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target23 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__133.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p133 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__133;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__132 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__132 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj23 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__132.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__132, this.Garage[G.Index], "Lombok, Garage C");
        if (target23((CallSite) p133, obj23))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\LombokGarage\\GarageC\\", 20);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__135 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__135 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target24 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__135.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p135 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__135;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__134 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__134 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj24 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__134.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__134, this.Garage[G.Index], "Warehouse");
        if (target24((CallSite) p135, obj24))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ExecutiveBusiness\\WareHouses\\GarageA\\", 35);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__137 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__137 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target25 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__137.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p137 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__137;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__136 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__136 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj25 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__136.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__136, this.Garage[G.Index], "Bunker Storage");
        if (target25((CallSite) p137, obj25))
          this.ReturnGunnrunningVehicles("BunkerStorage");
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__139 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__139 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target26 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__139.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p139 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__139;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__138 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__138 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj26 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__138.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__138, this.Garage[G.Index], "Facility Storage");
        if (target26((CallSite) p139, obj26))
          this.ReturnDoomsdayHeistVehicles("FacilityStorage");
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__141 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__141 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target27 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__141.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p141 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__141;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__140 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__140 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj27 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__140.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__140, this.Garage[G.Index], "Hanger  Storage");
        if (target27((CallSite) p141, obj27))
          this.AddGarage("scripts\\HKH191sBusinessMods\\Smuggler's Run Business\\HangerStorage\\Hanger\\Hanger1\\", 12);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__143 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__143 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target28 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__143.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p143 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__143;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__142 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__142 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj28 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__142.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__142, this.Garage[G.Index], "Warehouse");
        if (target28((CallSite) p143, obj28))
          this.AddGarage("scripts\\HKH191sBusinessMods\\LCC\\WareHouses\\GarageA\\", 35);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__145 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__145 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target29 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__145.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p145 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__145;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__144 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__144 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj29 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__144.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__144, this.Garage[G.Index], "10 Car Bay");
        if (target29((CallSite) p145, obj29))
          this.AddGarage("scripts\\HKH191sBusinessMods\\ArenaWarBusiness\\PlayerGarage\\GarageA\\", 10);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__147 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__147 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target30 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__147.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p147 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__147;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__146 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__146 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj30 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__146.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__146, this.Garage[G.Index], "38 Car Garage");
        if (target30((CallSite) p147, obj30))
          this.AddGarage("scripts\\HKH191sBusinessMods\\DC&R\\CasinoGarage\\GarageA\\", 38);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__149 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__149 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target31 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__149.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p149 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__149;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__148 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__148 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj31 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__148.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__148, this.Garage[G.Index], "10 Car Storage");
        if (target31((CallSite) p149, obj31))
          this.AddGarage("scripts\\HKH191sBusinessMods\\AfterHoursBusiness\\NightClub1\\Garage\\", 10);
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__151 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__151 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target32 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__151.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p151 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__151;
        // ISSUE: reference to a compiler-generated field
        if (Class1.\u003C\u003Eo__102.\u003C\u003Ep__150 == null)
        {
          // ISSUE: reference to a compiler-generated field
          Class1.\u003C\u003Eo__102.\u003C\u003Ep__150 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Equals", (IEnumerable<System.Type>) null, typeof (Class1), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj32 = Class1.\u003C\u003Eo__102.\u003C\u003Ep__150.Target((CallSite) Class1.\u003C\u003Eo__102.\u003C\u003Ep__150, this.Garage[G.Index], "Heavy Vehicle Storage");
        if (target32((CallSite) p151, obj32))
          this.ReturnAfterHoursStorage();
        if ((Entity) this.C != (Entity) null)
          this.C.Delete();
        foreach (Blip vehicleBlip in this.VehicleBlips)
        {
          if (vehicleBlip != (Blip) null)
            vehicleBlip.Remove();
        }
        this.SC.LoadIniFile(this.C_LoadPath);
        this.C = World.CreateVehicle(this.SC.RequestModel(this.SC.VehicleName), new Vector3(2000f, 2000f, 2000f));
        this.SC.Load(this.C);
        Model model = this.C.Model;
        if (model.IsHelicopter)
        {
          this.C.Position = new Vector3(-745.6454f, -1433.558f, 5f);
          this.C.Heading = 137f;
          this.C.PlaceOnGround();
          this.C.AddBlip();
          this.C.CurrentBlip.Sprite = BlipSprite.HelicopterAnimated;
          this.C.CurrentBlip.Name = "Personal Heli (" + this.C.DisplayName + ")";
          this.C.CurrentBlip.ShowRoute = true;
          this.VehicleBlips.Add(this.C.CurrentBlip);
        }
        model = this.C.Model;
        if (model.IsPlane)
        {
          this.C.Position = new Vector3(-926.5521f, -3402.511f, 14.1f);
          this.C.Heading = 51f;
          this.C.PlaceOnGround();
          this.C.AddBlip();
          this.C.CurrentBlip.Sprite = BlipSprite.Plane;
          this.C.CurrentBlip.Name = "Personal Plane (" + this.C.DisplayName + ")";
          this.C.CurrentBlip.ShowRoute = true;
          this.VehicleBlips.Add(this.C.CurrentBlip);
        }
        else
        {
          Vehicle c1 = this.C;
          Vector3 position = Game.Player.Character.Position;
          Vector3 vector3 = position.Around(100f);
          c1.Position = vector3;
          this.C.PlaceOnNextStreet();
          this.C.PlaceOnGround();
          this.C.AddBlip();
          this.C.CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar;
          this.C.CurrentBlip.Name = "Personal Vehicle (" + this.C.DisplayName + ")";
          this.C.CurrentBlip.ShowRoute = true;
          this.C.PlaceOnNextStreet();
          Vehicle c2 = this.C;
          position = Game.Player.Character.Position;
          Vector3 positionOnStreet = World.GetNextPositionOnStreet(position.Around(50f));
          c2.Position = positionOnStreet;
          this.VehicleBlips.Add(this.C.CurrentBlip);
        }
      });
    }

    public void SetupSellStocks()
    {
      List<object> items1 = new List<object>();
      items1.Add((object) "Main.ini");
      List<object> items2 = new List<object>();
      items2.Add((object) "Main.ini");
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.Menu, "Biker Business");
      this.GUIMenus.Add(uiMenu1);
      UIMenuItem BikerSell = new UIMenuItem("Sell Stocks, Biker Business ");
      uiMenu1.AddItem(BikerSell);
      UIMenuItem BikerShow = new UIMenuItem("Show Stocks, Biker Business ");
      uiMenu1.AddItem(BikerShow);
      UIMenuItem BikerSellBusiness = new UIMenuItem("Sell Biker Business ");
      uiMenu1.AddItem(BikerSellBusiness);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.Menu, "Executive Business");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem ExecutiveSell1 = new UIMenuItem("Sell Stocks, Main ");
      uiMenu2.AddItem(ExecutiveSell1);
      UIMenuItem ExecutiveShow1 = new UIMenuItem("Show Stocks, Main ");
      uiMenu2.AddItem(ExecutiveShow1);
      UIMenuItem ExecutiveSellBusiness1 = new UIMenuItem("Sell Main ");
      uiMenu2.AddItem(ExecutiveSellBusiness1);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.Menu, "Gunrunning Business");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem list1 = new UIMenuListItem("Design: ", items2, 0);
      uiMenu3.AddItem((UIMenuItem) list1);
      UIMenuItem GetDesign = new UIMenuItem("Sell Stock ");
      uiMenu3.AddItem(GetDesign);
      UIMenuItem Show1 = new UIMenuItem("Show Stock");
      uiMenu3.AddItem(Show1);
      UIMenuItem SellBusiness1 = new UIMenuItem("Sell this Gunrunning Business");
      uiMenu3.AddItem(SellBusiness1);
      UIMenu uiMenu4 = this.modMenuPool.AddSubMenu(this.Menu, "Smuggler's Run Business");
      this.GUIMenus.Add(uiMenu4);
      UIMenuItem LSIA1Sell = new UIMenuItem("Sell Stocks, Main ");
      uiMenu4.AddItem(LSIA1Sell);
      UIMenuItem LSIA1Show = new UIMenuItem("Show Show, Main ");
      uiMenu4.AddItem(LSIA1Show);
      UIMenuItem LSIA1SellBusiness = new UIMenuItem("Sell, Main ");
      uiMenu4.AddItem(LSIA1SellBusiness);
      UIMenu uiMenu5 = this.modMenuPool.AddSubMenu(this.Menu, "Doomsday Heist Business");
      this.GUIMenus.Add(uiMenu5);
      UIMenuListItem list2 = new UIMenuListItem("Design: ", items1, 0);
      uiMenu5.AddItem((UIMenuItem) list2);
      UIMenuItem GetDesign2 = new UIMenuItem("Sell Stock ");
      uiMenu5.AddItem(GetDesign2);
      UIMenuItem Show2 = new UIMenuItem("Show Stock ");
      uiMenu5.AddItem(Show2);
      UIMenuItem SellBusiness2 = new UIMenuItem("Sell this Doomsday Heist Business ");
      uiMenu5.AddItem(SellBusiness2);
      UIMenu uiMenu6 = this.modMenuPool.AddSubMenu(this.Menu, "LCC Business");
      this.GUIMenus.Add(uiMenu6);
      UIMenuItem LCCSell = new UIMenuItem("Sell Stocks, LCC Business ");
      uiMenu6.AddItem(LCCSell);
      UIMenuItem LCCShow = new UIMenuItem("Show Stocks, LCC Business ");
      uiMenu6.AddItem(LCCShow);
      UIMenuItem LCCSellBusiness = new UIMenuItem("Sell LCC Business ");
      uiMenu6.AddItem(LCCSellBusiness);
      UIMenu uiMenu7 = this.modMenuPool.AddSubMenu(this.Menu, "Arena War Business");
      this.GUIMenus.Add(uiMenu7);
      UIMenuItem ArenaSell = new UIMenuItem("Sell Stocks, Arena War Business ");
      uiMenu7.AddItem(ArenaSell);
      UIMenuItem ArenaShow = new UIMenuItem("Show Stocks, Arena War Business ");
      uiMenu7.AddItem(ArenaShow);
      UIMenuItem ArenaSellBusiness = new UIMenuItem("Sell Arena War Business ");
      uiMenu7.AddItem(ArenaSellBusiness);
      UIMenu uiMenu8 = this.modMenuPool.AddSubMenu(this.Menu, "DC&R Business");
      this.GUIMenus.Add(uiMenu8);
      UIMenuItem DCRSell = new UIMenuItem("Sell Stocks, DC&R Business ");
      uiMenu8.AddItem(DCRSell);
      UIMenuItem DCRShow = new UIMenuItem("Show Stocks, DC&R Business ");
      uiMenu8.AddItem(DCRShow);
      UIMenuItem DCRSellBusiness = new UIMenuItem("Sell DC&R Business ");
      uiMenu8.AddItem(DCRSellBusiness);
      UIMenu uiMenu9 = this.modMenuPool.AddSubMenu(this.Menu, "AfterHours Business");
      this.GUIMenus.Add(uiMenu9);
      UIMenuItem AfterHoursSell = new UIMenuItem("Sell Stocks, AfterHours Business ");
      uiMenu9.AddItem(AfterHoursSell);
      UIMenuItem AfterHoursShow = new UIMenuItem("Show Stocks, AfterHours Business ");
      uiMenu9.AddItem(AfterHoursShow);
      UIMenuItem AfterHoursSellBusiness = new UIMenuItem("Sell AfterHours Business ");
      uiMenu9.AddItem(AfterHoursSellBusiness);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == BikerSell)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          UI.Notify("Clay: ok i can deal with that, selling all product avalable");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == BikerShow)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
          UI.Notify("Clay: ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != BikerSellBusiness)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        UI.Notify("Clay: I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
      uiMenu6.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == LCCSell)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//LCC//Main.ini");
          UI.Notify("Lamar: ok i can deal with that, selling all product avalable");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == LCCShow)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//LCC//Main.ini");
          UI.Notify("Lamar: ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != LCCSellBusiness)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//LCC//Main.ini");
        UI.Notify("Lamar: I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
      uiMenu7.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ArenaSell)
        {
          UI.Notify("Alan : ok i can deal with that, selling all product avalable");
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == ArenaShow)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
          UI.Notify("Alan: ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != ArenaSellBusiness)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//ArenaWarBusiness//Main.ini");
        UI.Notify("Alan: I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ExecutiveSell1)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("Office Assistant: ok i can deal with that, selling all product avalable");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == ExecutiveShow1)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          UI.Notify("Office Assistant: ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != ExecutiveSellBusiness1)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
        UI.Notify("Office Assistant: I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
      uiMenu4.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == LSIA1Sell)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
          UI.Notify("Ron: ok i can deal with that, selling all product avalable");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == LSIA1Show)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
          UI.Notify("Ron: ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != LSIA1SellBusiness)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//Smuggler's Run Business//Main.ini");
        UI.Notify("Ron: I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == GetDesign)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//" + list1.IndexToItem(list1.Index)?.ToString());
          UI.Notify("Agent 14: ok i can deal with that, selling all product avalable");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == Show1)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//" + list1.IndexToItem(list1.Index)?.ToString());
          UI.Notify("Agent 14: ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != SellBusiness1)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//GunRunningBusiness//" + list1.IndexToItem(list1.Index)?.ToString());
        UI.Notify("Agent 14: I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
      uiMenu5.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == GetDesign2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//" + list2.IndexToItem(list2.Index)?.ToString());
          UI.Notify("Lester: ok i can deal with that, selling all product avalable");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == Show2)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//" + list2.IndexToItem(list2.Index)?.ToString());
          UI.Notify("Lester : ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != SellBusiness2)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//" + list2.IndexToItem(list2.Index)?.ToString());
        UI.Notify("Lester : I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
      uiMenu9.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == AfterHoursSell)
        {
          UI.Notify("Gay Tony : ok i can deal with that, selling all product avalable");
          this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == AfterHoursShow)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
          UI.Notify("Gay Tony: ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != AfterHoursSellBusiness)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
        UI.Notify("Gay Tony: I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
      uiMenu8.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == DCRSell)
        {
          UI.Notify("Tao Cheng : ok i can deal with that, selling all product avalable");
          this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
          Game.Player.Money += (int) this.stocksvalue;
          this.stocksvalue = 0.0f;
          this.stockscount = 0;
          this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
          this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
          this.Config.Save();
        }
        if (item == DCRShow)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
          UI.Notify("Tao Cheng : ok here is where, we are at, Stock Value : " + this.stocksvalue.ToString());
        }
        if (item != DCRSellBusiness)
          return;
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
        UI.Notify("Tao Cheng : I just heard, you wanted to sell the buisness, i'm verry sorry, if i have upset you in any way");
        Game.Player.Money += (int) this.stocksvalue;
        this.PurchaseLvl = 0;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "BuisnessLevel", this.PurchaseLvl);
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
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

    private void drawSpriteAdv(
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
      float Heading,
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
      Function.Call((Hash) 10772944127051384614, (InputArgument) textureDict, (InputArgument) textureName, (InputArgument) this.GetRatio(screenX), (InputArgument) screenY, (InputArgument) (width / 1280f * num), (InputArgument) (height / 1280f), (InputArgument) x1, (InputArgument) y1, (InputArgument) x2, (InputArgument) y2, (InputArgument) Heading, (InputArgument) r, (InputArgument) g, (InputArgument) b, (InputArgument) alpha);
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

    public bool GetMouseXY(float X, float Y)
    {
      bool flag = false;
      float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
      float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
      if ((double) new Vector2(x, y).DistanceTo(new Vector2(X, Y)) <= 0.00999999977648258)
        flag = true;
      if ((double) new Vector2(x, y).DistanceTo(new Vector2(X, Y)) > 0.00999999977648258)
        flag = false;
      return flag;
    }

    private void OnTick(object sender, EventArgs e)
    {
      if (this.DisplayMapOn)
      {
        float y = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 240);
        float x = Function.Call<float>(Hash._0xEC3C9B8D5327B563, (InputArgument) 2, (InputArgument) 239);
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "mp_freemode_mc"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "mp_freemode_mc", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "orbital_cannon_map"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "orbital_cannon_map", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "minimap"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "minimap", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "trafficcam"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "trafficcam", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "securitycam"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "securitycam", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "mpkillquota"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "mpkillquota", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "mpaircraft"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "mpaircraft", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "digitaloverlay"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "digitaloverlay", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "mp_freemode_mc"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "mp_freemode_mc", (InputArgument) 0);
          }
          else
            break;
        }
        while (true)
        {
          if (!Function.Call<bool>(Hash._0x0145F696AAAAD2E4, (InputArgument) "foreclosures_maze_d_bank_com"))
          {
            Script.Wait(10);
            Function.Call(Hash._0xDFA2EF8E04127DD5, (InputArgument) "foreclosures_maze_d_bank_com", (InputArgument) 0);
          }
          else
            break;
        }
        this.drawSpriteRTA2("foreclosures_maze_d_bank_com", "map-tile-1", this.MapPos.X - 0.429f, this.MapPos.Y - 0.6f, 620f, 1220f, 155, 155, 155, (int) byte.MaxValue, 0.0f);
        this.drawSpriteRTA2("foreclosures_maze_d_bank_com", "map-tile-2", this.MapPos.X + 0.429f, this.MapPos.Y - 0.6f, 620f, 1220f, 155, 155, 155, (int) byte.MaxValue, 0.0f);
        this.drawSpriteRTA2("foreclosures_maze_d_bank_com", "map-tile-3", this.MapPos.X - 0.429f, this.MapPos.Y + 0.35f, 620f, 1220f, 155, 155, 155, (int) byte.MaxValue, 0.0f);
        this.drawSpriteRTA2("foreclosures_maze_d_bank_com", "map-tile-4", this.MapPos.X + 0.429f, this.MapPos.Y + 0.35f, 620f, 1220f, 155, 155, 155, (int) byte.MaxValue, 0.0f);
        this.drawSpriteRTA2("securitycam", "securitycam_scanlines", 0.25f, 0.2f, 200f, 150f, 0, 0, 0, (int) byte.MaxValue, 0.0f);
        Vector2 vector2_1;
        if (this.ShowingPurchaseOptions)
        {
          this.drawSpriteRTA2("pause_menu_pages_game", "shim", this.SelectedPos.X - 0.07f, this.SelectedPos.Y, 100f, 200f, 100, 100, 100, (int) byte.MaxValue, 0.0f);
          this.drawSpriteRTA2("securitycam", "securitycam_scanlines", this.SelectedPos.X - 0.07f, this.SelectedPos.Y, 100f, 200f, 100, 100, 100, (int) byte.MaxValue, 0.0f);
          this.drawText(this.BusinessName, this.SelectedPos.X + 0.03f, this.SelectedPos.Y - 0.04f, 0.3f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          this.drawText("Cost : ~g~$" + this.BusinessCost.ToString("N"), this.SelectedPos.X + 0.022f, this.SelectedPos.Y - 0.02f, 0.2f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          Vector2 vector2_2 = new Vector2(this.SelectedPos.X + 0.03f, this.SelectedPos.Y - 0.0f);
          Vector2 vector2_3 = new Vector2(this.SelectedPos.X + 0.03f, this.SelectedPos.Y + 0.05f);
          vector2_1 = new Vector2(x, y);
          if ((double) vector2_1.DistanceTo(new Vector2(vector2_2.X, vector2_2.Y - 0.01f)) <= 0.0299999993294477)
          {
            this.drawText("Purchase", vector2_2.X, vector2_2.Y, 0.3f, (int) byte.MaxValue, 0, 0);
            if (Game.IsControlJustPressed(2, GTA.Control.Attack) && Game.Player.Money >= this.BusinessCost)
            {
              Game.Player.Money -= this.BusinessCost;
              if (this.CurrentBusinessType != Class1.BusinessType.Executive)
                ;
              if (this.CurrentBusinessType != Class1.BusinessType.Biker)
                ;
              if (this.CurrentBusinessType != Class1.BusinessType.Afterhours)
                ;
              if (this.CurrentBusinessType != Class1.BusinessType.Casino)
                ;
              if (this.CurrentBusinessType != Class1.BusinessType.Arena)
                ;
              if (this.CurrentBusinessType != Class1.BusinessType.Smugglers)
                ;
              if (this.CurrentBusinessType != Class1.BusinessType.Doomsday)
                ;
              if (this.CurrentBusinessType != Class1.BusinessType.Gunrunning)
                ;
            }
          }
          else
            this.drawText("Purchase", vector2_2.X, vector2_2.Y, 0.3f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          vector2_1 = new Vector2(x, y);
          if ((double) vector2_1.DistanceTo(new Vector2(vector2_3.X, vector2_3.Y - 0.01f)) <= 0.0299999993294477)
          {
            this.drawText("Cancel", vector2_3.X, vector2_3.Y, 0.3f, (int) byte.MaxValue, 0, 0);
            if (Game.IsControlJustPressed(2, GTA.Control.Attack))
              this.ShowingPurchaseOptions = false;
          }
          else
            this.drawText("Cancel", vector2_3.X, vector2_3.Y, 0.3f, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        }
        Vector2 vector2_4 = new Vector2(x, y);
        Function.Call((Hash) 10772944127051384614, (InputArgument) "mp_freemode_mc", (InputArgument) "mouse", (InputArgument) vector2_4.X, (InputArgument) vector2_4.Y, (InputArgument) 0.012f, (InputArgument) (float) (0.0120000001043081 * (double) Function.Call<float>(Hash._0xF1307EF624A80D87, (InputArgument) true)), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 1f, (InputArgument) 1f, (InputArgument) 0.0f, (InputArgument) 235, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue, (InputArgument) (int) byte.MaxValue);
        float num = x * 3f;
        if (Game.IsControlPressed(2, GTA.Control.WeaponWheelNext) && (double) this.Offset < 0.519900023937225)
        {
          this.Offset += 0.01f;
          this.MapPos = new Vector2(this.MapPos.X, this.MapPos.Y + 0.01f);
          Game.DisableControlThisFrame(2, GTA.Control.PhoneUp);
        }
        if (Game.IsControlPressed(2, GTA.Control.WeaponWheelPrev) && (double) this.Offset > -0.300000011920929)
        {
          this.Offset -= 0.01f;
          this.MapPos = new Vector2(this.MapPos.X, this.MapPos.Y - 0.01f);
          Game.DisableControlThisFrame(2, GTA.Control.PhoneDown);
        }
        if (Game.IsControlPressed(2, GTA.Control.PhoneUp))
        {
          this.ScreenOffset = 2;
          this.MapPos = new Vector2(0.5f, 1.02f);
          this.Offset = 0.5199f;
        }
        if (Game.IsControlPressed(2, GTA.Control.PhoneDown))
        {
          this.ScreenOffset = 1;
          this.MapPos = new Vector2(0.5f, 0.19f);
          this.Offset = -0.31f;
        }
        SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
        int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
        Convert.ToInt32(resolutionMantainRatio.Height / 2f);
        new UIResText("Offset : " + this.Offset.ToString(), new Point(400, 40), 0.3f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
        vector2_1 = new Vector2(x + 0.19f, y + this.Offset);
        new UIResText("Offset X/Y : " + vector2_1.ToString(), new Point(400, 70), 0.3f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
        vector2_1 = new Vector2(x, y + this.Offset);
        new UIResText("Offset nXYo : " + vector2_1.ToString(), new Point(400, 100), 0.3f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
        new UIResText("X/Y : {" + x.ToString() + "," + y.ToString() + "}", new Point(400, 130), 0.3f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
        if (this.ScreenOffset == 1)
          new UIResText("Los Santos", new Point(int32, 70), 1f, Color.White, GTA.Font.HouseScript, UIResText.Alignment.Centered).Draw();
        if (this.ScreenOffset == 2)
          new UIResText("Blaine County", new Point(int32, 70), 1f, Color.White, GTA.Font.HouseScript, UIResText.Alignment.Centered).Draw();
        new UIResText("Map Pos : {" + this.MapPos.X.ToString() + "," + this.MapPos.Y.ToString() + "}", new Point(400, 160), 0.3f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      }
      if (!Game.IsControlPressed(2, GTA.Control.Sprint) || !Game.IsControlJustPressed(2, GTA.Control.SelectWeaponHandgun))
        ;
      this.OnKeyDown();
      this.ifruit.Update();
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      if (this.CameraOn)
      {
        this.DrawScaleform();
        try
        {
          if (this.GetHour() == 0 && !this.TriggerIncrease)
          {
            this.TriggerIncrease = true;
            Function.Call(Hash._0xB096419DF0D06CE7, (InputArgument) this.GetDay(), (InputArgument) this.GetMonth(), (InputArgument) this.GetYear());
            UI.Notify("Day " + World.CurrentDate.ToString());
          }
          if ((uint) this.GetHour() > 0U)
            this.TriggerIncrease = false;
          Function.Call(Hash._0xD716F30D8C8980E2, (InputArgument) this.AddHourTick, (InputArgument) this.AddMinTick, (InputArgument) this.AddSecTick);
        }
        catch
        {
        }
        this.GetDateRelative();
        if (this.GetDay() >= this.NextDay && this.GetMonth() >= this.NextMonth && this.CannonCamera != (Camera) null)
        {
          this.CameraOn = false;
          Game.Player.WantedLevel = 0;
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.Position = new Vector3(this.LastPlayerPos.X, this.LastPlayerPos.Y, World.GetGroundHeight(this.LastPlayerPos));
          Game.Player.Character.FreezePosition = false;
          Game.Player.Character.IsVisible = true;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.CannonCamera.IsActive = false;
          this.CannonCamera.Destroy();
          UI.Notify("Succefully passed " + this.DaysWait.ToString() + " days");
          this.Now = this.GetDay();
          this.SetDate();
        }
        if (Game.IsControlJustPressed(2, GTA.Control.Cover) && this.CannonCamera != (Camera) null)
        {
          this.CameraOn = false;
          Game.Player.WantedLevel = 0;
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.Position = new Vector3(this.LastPlayerPos.X, this.LastPlayerPos.Y, World.GetGroundHeight(this.LastPlayerPos));
          Game.Player.Character.FreezePosition = false;
          Game.Player.Character.IsVisible = true;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.CannonCamera.IsActive = false;
          this.CannonCamera.Destroy();
          this.Now = this.GetDay();
          this.SetDate();
        }
      }
      if (this.Refreshtimer >= 1)
        ++this.Refreshtimer;
      if (this.Refreshtimer == 6)
      {
        Game.Player.Character.Position = this.Old;
        Game.Player.Character.Alpha = (int) byte.MaxValue;
        this.Refreshtimer = -10;
        if ((Entity) this.Veh != (Entity) null)
        {
          Game.Player.Character.SetIntoVehicle(this.Veh, VehicleSeat.Driver);
          this.Veh.IsPersistent = false;
          this.Veh = (Vehicle) null;
        }
      }
      if ((Entity) this.C != (Entity) null)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.C.Position) > 30.0)
          this.C.CurrentBlip.ShowRoute = true;
        if ((double) World.GetDistance(Game.Player.Character.Position, this.C.Position) < 30.0)
          this.C.CurrentBlip.ShowRoute = false;
        if (this.C.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
        {
          if (this.CarBlip != (Blip) null)
            this.CarBlip.Remove();
          this.C.FreezePosition = false;
          this.C.IsInvincible = false;
          this.C.IsDriveable = true;
        }
      }
      if (this.firstTime)
      {
        UI.Notify(this.ModName + " " + this.Version + " by " + this.Developer + " Loaded");
        UI.Notify(this.ModName + ": Thank you for downloading!!");
        this.firstTime = false;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) < 30.0)
        World.DrawMarker(MarkerType.VerticalCylinder, this.MenuMarker, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), Color.Blue);
      if ((double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) >= 2.0)
        return;
      this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open the Business Helper Menu");
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    private void OnKeyDown()
    {
      if ((double) World.GetDistance(Game.Player.Character.Position, this.MenuMarker) >= 2.0 || !Game.IsControlJustPressed(2, GTA.Control.Context) || this.mainMenu.Visible)
        return;
      this.mainMenu.Visible = !this.mainMenu.Visible;
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      foreach (Blip vehicleBlip in this.VehicleBlips)
      {
        if (vehicleBlip != (Blip) null)
          vehicleBlip.Remove();
      }
      if (this.CannonCamera != (Camera) null)
      {
        Game.Player.WantedLevel = 0;
        Game.Player.Character.IsInvincible = false;
        Game.Player.Character.Position = new Vector3(this.LastPlayerPos.X, this.LastPlayerPos.Y, World.GetGroundHeight(this.LastPlayerPos));
        Game.Player.Character.FreezePosition = false;
        Game.Player.Character.IsVisible = true;
        Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
        this.CannonCamera.IsActive = false;
        this.CannonCamera.Destroy();
      }
      if (this.CarBlip != (Blip) null)
        this.CarBlip.Remove();
      if (this.BankBlip != (Blip) null)
        this.BankBlip.Remove();
      if ((Entity) this.C != (Entity) null)
        this.C.IsPersistent = false;
    }

    public void loadMenu(iFruitContact contact)
    {
      this.ifruit.Close();
      this.mainMenu.Visible = !this.mainMenu.Visible;
    }

    public enum BusinessType
    {
      Biker,
      Executive,
      Gunrunning,
      Doomsday,
      Smugglers,
      Arena,
      Afterhours,
      Casino,
    }
  }
}
