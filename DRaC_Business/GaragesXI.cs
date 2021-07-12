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
using System.Runtime.CompilerServices;

namespace DRaC_Business
{
  internal class GaragesXl : Script
  {
    public SaveCar SC;
    public Vector3 EnterMarkerA;
    public Vector3 EnterMarkerB;
    public Vector3 EnterMarkerC;
    public Vector3 ExitMarker;
    public Vector3 Vehicle1Loc = new Vector3(1366f, 200.0053f, -49f);
    public Vehicle Vehicle1;
    public Vector3 Vehicle2Loc = new Vector3(1366f, 205.3288f, -49f);
    public Vehicle Vehicle2;
    public Vector3 Vehicle3Loc = new Vector3(1366f, 208.8129f, -49f);
    public Vehicle Vehicle3;
    public Vector3 Vehicle4Loc = new Vector3(1366f, 212.8502f, -49f);
    public Vehicle Vehicle4;
    public Vector3 Vehicle5Loc = new Vector3(1366f, 216.993f, -49f);
    public Vehicle Vehicle5;
    public Vector3 Vehicle6Loc = new Vector3(1366f, 221.3514f, -49f);
    public Vehicle Vehicle6;
    public Vector3 Vehicle7Loc = new Vector3(1366f, 225.1411f, -49f);
    public Vehicle Vehicle7;
    public Vector3 Vehicle8Loc = new Vector3(1366f, 229.2602f, -49f);
    public Vehicle Vehicle8;
    public Vector3 Vehicle9Loc = new Vector3(1366f, 233.6262f, -49f);
    public Vehicle Vehicle9;
    public Vector3 Vehicle10Loc = new Vector3(1366f, 237.8518f, -49f);
    public Vehicle Vehicle10;
    public Vector3 Vehicle11Loc = new Vector3(1366f, 241.9215f, -49f);
    public Vehicle Vehicle11;
    public Vector3 Vehicle12Loc = new Vector3(1366f, 246.182f, -49f);
    public Vehicle Vehicle12;
    public Vector3 Vehicle13Loc = new Vector3(1366f, 250.7189f, -49f);
    public Vehicle Vehicle13;
    public Vector3 Vehicle14Loc = new Vector3(1366f, 254.2859f, -49f);
    public Vehicle Vehicle14;
    public Vector3 Vehicle15Loc = new Vector3(1393.5f, 254.5622f, -49f);
    public Vehicle Vehicle15;
    public Vector3 Vehicle16Loc = new Vector3(1394f, 250.4043f, -49f);
    public Vehicle Vehicle16;
    public Vector3 Vehicle17Loc = new Vector3(1394f, 246.1132f, -49f);
    public Vehicle Vehicle17;
    public Vector3 Vehicle18Loc = new Vector3(1394f, 241.8095f, -49f);
    public Vehicle Vehicle18;
    public Vector3 Vehicle19Loc = new Vector3(1394f, 237.8313f, -49f);
    public Vehicle Vehicle19;
    public Vector3 Vehicle20Loc = new Vector3(1394f, 233.8423f, -49f);
    public Vehicle Vehicle20;
    public Vector3 Vehicle21Loc = new Vector3(1394f, 229.4567f, -49f);
    public Vehicle Vehicle21;
    public Vector3 Vehicle22Loc = new Vector3(1394f, 225.4585f, -49f);
    public Vehicle Vehicle22;
    public Vector3 Vehicle23Loc = new Vector3(1394f, 221.242f, -49f);
    public Vehicle Vehicle23;
    public Vector3 Vehicle24Loc = new Vector3(1394f, 217.1142f, -49f);
    public Vehicle Vehicle24;
    public Vector3 Vehicle25Loc = new Vector3(1394f, 212.6096f, -49f);
    public Vehicle Vehicle25;
    public Vector3 Vehicle26Loc = new Vector3(1394f, 208.7203f, -49f);
    public Vehicle Vehicle26;
    public Vector3 Vehicle27Loc = new Vector3(1394f, 204.3846f, -49f);
    public Vehicle Vehicle27;
    public Vector3 Vehicle28Loc = new Vector3(1394f, 200.1248f, -49f);
    public Vehicle Vehicle28;
    public Vector3 Vehicle29Loc = new Vector3(1380.35f, 208.4899f, -49f);
    public Vehicle Vehicle29;
    public Vector3 Vehicle30Loc = new Vector3(1380.35f, 212.6263f, -49f);
    public Vehicle Vehicle30;
    public Vector3 Vehicle31Loc = new Vector3(1380.35f, 217.0614f, -49f);
    public Vehicle Vehicle31;
    public Vector3 Vehicle32Loc = new Vector3(1380.35f, 221.2078f, -49f);
    public Vehicle Vehicle32;
    public Vector3 Vehicle33Loc = new Vector3(1380.35f, 225.4231f, -49f);
    public Vehicle Vehicle33;
    public Vector3 Vehicle34Loc = new Vector3(1380.35f, 229.4963f, -49f);
    public Vehicle Vehicle34;
    public Vector3 Vehicle35Loc = new Vector3(1380.35f, 233.8908f, -49f);
    public Vehicle Vehicle35;
    public Vector3 Vehicle36Loc = new Vector3(1380.35f, 237.8443f, -49f);
    public Vehicle Vehicle36;
    public Vector3 Vehicle37Loc = new Vector3(1380.35f, 242.2055f, -49f);
    public Vehicle Vehicle37;
    public Vector3 Vehicle38Loc = new Vector3(1380.35f, 246.2027f, -49f);
    public Vehicle Vehicle38;
    private MenuPool modMenuPool;
    private UIMenu GarageMenu;
    private UIMenu mainMenu;
    public Vector3 EntryMarker = new Vector3(-1574.64f, -569.683f, 108f);
    public Vector3 ExitMarker2 = new Vector3(-71.949f, -831.736f, 222.001f);
    private string path = "scripts//HKH191sBusinessMods//DC&R//CasinoGarage//";
    public Vehicle SaveVehicle;
    public Vector3 RemoveMarker = new Vector3(1380.131f, 186.0907f, -50f);
    private MenuPool modMenuPool2;
    private UIMenu RemoveMenu;
    private UIMenu mainMenu2;
    public string GarageNum;
    public bool DeliveringVehicle;
    public Vehicle VehicleToDeliver;
    public string SlotToDelete;
    public bool IsInInterior;
    private MenuPool modMenuPool3;
    private UIMenu BuyCar1;
    private UIMenu mainMenu3;
    private ScriptSettings Config;
    public Blip VehicleWarehouseMarker;
    public Vector3 WherehouseMarker = new Vector3(930.546f, -8.284f, 78f);
    public Vector3 MenuMarker;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public string HostName;
    public BlipColor Blip_Colour;
    public string Uicolour;
    public Color MarkerColor;
    public string MarkerColorString;
    public int Casino_level;
    public Vector3 GarageEnt = new Vector3(1119.526f, 262.2122f, -50f);
    public Vector3 GarageExit = new Vector3(1380.048f, 177.9697f, -50f);
    public Vehicle CarToDelete;
    public int ONscreens;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public float M = 0.0f;
    public string Price = "000";
    public string Model = "";
    public string man = "";
    public string ListPath = "scripts\\HKH191sBusinessMods\\DC&R\\MilitaryTrader\\AllVehicles.ini";
    public bool OnMission;

    public string GetHostName() => "~" + this.Uicolour + "~ " + this.HostName + "~w~ ";

    public void UpdateValues() => this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Main.ini");

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Diamond Resort & Casino DLC", "Diamond Resort & Casino", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public GaragesXl()
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.SC = new SaveCar();
      this.CreateBanner();
      this.Setup();
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Tick += new EventHandler(this.OnTick);
      this.Interval = 1;
    }

    private void SetupMarker()
    {
      if (this.Casino_level < 3)
        return;
      this.VehicleWarehouseMarker = World.CreateBlip(this.WherehouseMarker);
      this.VehicleWarehouseMarker.Sprite = BlipSprite.Garage;
      this.VehicleWarehouseMarker.Color = this.Blip_Colour;
      this.VehicleWarehouseMarker.Name = "Casino Garage";
      this.VehicleWarehouseMarker.IsShortRange = true;
    }

    private void requestCasinoScreens(string TVChannel, int model)
    {
      Function.Call(Hash._0x57D9C12635E25CE3, (InputArgument) "CasinoScreen_01", (InputArgument) 0);
      Function.Call(Hash._0xF6C09E276AEB3F2D, (InputArgument) model);
      this.ONscreens = Function.Call<int>(Hash._0x1A6478B61C6BDC3B, (InputArgument) "CasinoScreen_01");
      if (TVChannel != "Default")
      {
        Function.Call(Hash._0xF7B38B8305F1FE8B, (InputArgument) 0, (InputArgument) TVChannel, (InputArgument) 1);
      }
      else
      {
        OutputArgument outputArgument1 = new OutputArgument();
        OutputArgument outputArgument2 = new OutputArgument();
        OutputArgument outputArgument3 = new OutputArgument();
        OutputArgument outputArgument4 = new OutputArgument();
        OutputArgument outputArgument5 = new OutputArgument();
        OutputArgument outputArgument6 = new OutputArgument();
        Function.Call(Hash._0xDA488F299A5B164E, (InputArgument) outputArgument1, (InputArgument) outputArgument2, (InputArgument) outputArgument3, (InputArgument) outputArgument4, (InputArgument) outputArgument5, (InputArgument) outputArgument6);
        int result1 = outputArgument2.GetResult<int>();
        int result2 = outputArgument3.GetResult<int>();
        if (result1 == 10 || result2 == 31)
          Function.Call(Hash._0xF7B38B8305F1FE8B, (InputArgument) 0, (InputArgument) "CASINO_HLW_PL", (InputArgument) 1);
        else if (result1 == 12)
          Function.Call(Hash._0xF7B38B8305F1FE8B, (InputArgument) 0, (InputArgument) "CASINO_HLW_PL", (InputArgument) 1);
        else
          Function.Call(Hash._0xF7B38B8305F1FE8B, (InputArgument) 0, (InputArgument) "CASINO_DIA_PL", (InputArgument) 1);
      }
      Function.Call(Hash._0x113D2C5DC57E1774, (InputArgument) 1);
      Function.Call(Hash._0x2982BF73F66E9DDC, (InputArgument) -5f);
      Function.Call(Hash._0xBAABBB23EB6E484E, (InputArgument) 0);
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Main.ini");
      this.SetupMarker();
      this.ExitMarker = new Vector3(1336f, 190.9267f, -49f);
      this.modMenuPool3 = new MenuPool();
      this.mainMenu3 = new UIMenu("Buy a special Vehicle", "Select an Option");
      this.GUIMenus.Add(this.mainMenu3);
      this.modMenuPool3.Add(this.mainMenu3);
      this.BuyCar1 = this.modMenuPool3.AddSubMenu(this.mainMenu3, "Special Vehicles");
      this.GUIMenus.Add(this.BuyCar1);
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("DC&R Business", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.GarageMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Garage Options");
      this.GUIMenus.Add(this.GarageMenu);
      this.modMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Remove a Vehicle", "Select an Option");
      this.GUIMenus.Add(this.mainMenu2);
      this.modMenuPool2.Add(this.mainMenu2);
      this.RemoveMenu = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Remove A Vehicle");
      this.GUIMenus.Add(this.RemoveMenu);
      this.SetupGarage();
      this.RemoveCar();
      for (int index = 0; index < this.GUIMenus.Count<UIMenu>(); ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
        this.Blip_Colour = this.Config.GetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
        this.MarkerColorString = this.Config.GetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
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
        this.Casino_level = this.Config.GetValue<int>("Setup", "Casinoi_Upgrade_Level", this.Casino_level);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: DC&R/GarageXL - Main.ini Failed To Load.");
      }
    }

    public void DeleteCarinSlot(string Slot, Vehicle V)
    {
      this.SC.LoadIniFile(this.path + "GarageA//" + Slot + ".ini");
      if (this.SC.VehicleName != "null")
      {
        if (V.DisplayName == "ZTYPE")
          Game.Player.Money += new System.Random().Next(10000000, 11000000);
        if (V.ClassType == VehicleClass.Coupes)
          Game.Player.Money += new System.Random().Next(85000, 125000);
        else if (V.ClassType == VehicleClass.Military)
          Game.Player.Money += new System.Random().Next(500000, 750000);
        else if (V.ClassType == VehicleClass.Super)
          Game.Player.Money += new System.Random().Next(345000, 400000);
        else if (V.ClassType == VehicleClass.SUVs)
          Game.Player.Money += new System.Random().Next(75000, 150000);
        else if (V.ClassType == VehicleClass.OffRoad)
          Game.Player.Money += new System.Random().Next(100000, 250000);
        else if (V.ClassType == VehicleClass.Sports)
          Game.Player.Money += new System.Random().Next(150000, 400000);
        else if (V.ClassType == VehicleClass.SportsClassics)
          Game.Player.Money += new System.Random().Next(240000, 350000);
        else if (V.ClassType == VehicleClass.Sedans)
          Game.Player.Money += new System.Random().Next(50000, 200000);
        else if (V.ClassType == VehicleClass.Muscle)
          Game.Player.Money += new System.Random().Next(225000, 300000);
        else if (V.ClassType == VehicleClass.Motorcycles)
          Game.Player.Money += new System.Random().Next(60000, 200000);
        else
          Game.Player.Money += new System.Random().Next(50000, 120000);
        UI.Notify("Office Assistant : Vehicle Sold");
      }
      if (this.SC.VehicleName == "null")
        UI.Notify("Office Assistant : There is no Vehicle in " + Slot);
      this.SC.SaveName();
      this.VehicleToDeliver = (Vehicle) null;
      V.Delete();
    }

    public void DeleteCarinSlot2(string Slot, Vehicle V)
    {
      this.SC.LoadIniFile(this.path + "GarageA//" + Slot + ".ini");
      if (this.SC.VehicleName != "null")
      {
        if (V.DisplayName == "ZTYPE")
          Game.Player.Money += new System.Random().Next(10000000, 11000000);
        if (V.ClassType == VehicleClass.Coupes)
          Game.Player.Money += new System.Random().Next(140000, 400000);
        else if (V.ClassType == VehicleClass.Military)
          Game.Player.Money += new System.Random().Next(750000, 1500000);
        else if (V.ClassType == VehicleClass.Super)
          Game.Player.Money += new System.Random().Next(640000, 900000);
        else if (V.ClassType == VehicleClass.SUVs)
          Game.Player.Money += new System.Random().Next(125000, 400000);
        else if (V.ClassType == VehicleClass.OffRoad)
          Game.Player.Money += new System.Random().Next(200000, 600000);
        else if (V.ClassType == VehicleClass.Sports)
          Game.Player.Money += new System.Random().Next(340000, 500000);
        else if (V.ClassType == VehicleClass.SportsClassics)
          Game.Player.Money += new System.Random().Next(450000, 1200000);
        else if (V.ClassType == VehicleClass.Sedans)
          Game.Player.Money += new System.Random().Next(120000, 400000);
        else if (V.ClassType == VehicleClass.Muscle)
          Game.Player.Money += new System.Random().Next(450000, 800000);
        else if (V.ClassType == VehicleClass.Motorcycles)
          Game.Player.Money += new System.Random().Next(100000, 400000);
        else
          Game.Player.Money += new System.Random().Next(100000, 320000);
        UI.Notify("Office Assistant : Vehicle Sold");
      }
      if (this.SC.VehicleName == "null")
        UI.Notify("Office Assistant : There is no Vehicle in " + Slot);
      if (Game.Player.Character.Model == (GTA.Model) PedHash.Franklin)
        UI.Notify("Buyer: Thank you Mr " + "Clinton" + " For your donation");
      if (Game.Player.Character.Model == (GTA.Model) PedHash.Michael)
        UI.Notify("Buyer: Thank you Mr " + "De Santa" + " For your donation");
      if (Game.Player.Character.Model == (GTA.Model) PedHash.Trevor)
        UI.Notify("Buyer: Thank you Mr " + "Philips" + " For your donation");
      UI.Notify("Buyer: Calculating Bonus");
      int num = 0;
      if (V.GetMod(VehicleMod.Livery) >= 1)
        num += 10000;
      if (V.GetMod(VehicleMod.Engine) > 0)
      {
        if (V.GetMod(VehicleMod.Engine) == 1)
          num += 5000;
        if (V.GetMod(VehicleMod.Engine) == 2)
          num += 10000;
        if (V.GetMod(VehicleMod.Engine) == 3)
          num += 15000;
      }
      if (V.GetMod(VehicleMod.Transmission) > 0)
      {
        if (V.GetMod(VehicleMod.Transmission) == 1)
          num += 5000;
        if (V.GetMod(VehicleMod.Transmission) == 2)
          num += 10000;
        if (V.GetMod(VehicleMod.Transmission) == 3)
          num += 15000;
      }
      if (V.GetMod(VehicleMod.Armor) > 0)
      {
        if (V.GetMod(VehicleMod.Armor) == 1)
          num += 5000;
        if (V.GetMod(VehicleMod.Armor) == 2)
          num += 10000;
        if (V.GetMod(VehicleMod.Armor) == 3)
          num += 15000;
      }
      if (V.GetMod(VehicleMod.Brakes) > 0)
      {
        if (V.GetMod(VehicleMod.Brakes) == 1)
          num += 5000;
        if (V.GetMod(VehicleMod.Brakes) == 2)
          num += 10000;
        if (V.GetMod(VehicleMod.Brakes) == 3)
          num += 15500;
      }
      if (V.GetMod(VehicleMod.Roof) == 1 || V.GetMod(VehicleMod.Roof) == -1)
        num += 35000;
      UI.Notify("Buyer : Bonus for mods: $" + num.ToString());
      Game.Player.Money += num;
      this.SC.SaveName();
      this.DeliveringVehicle = false;
      this.VehicleToDeliver = (Vehicle) null;
      V.Delete();
    }

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

    public void RemoveCar()
    {
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1");
      Slots.Add((object) "Slot2");
      Slots.Add((object) "Slot3");
      Slots.Add((object) "Slot4");
      Slots.Add((object) "Slot5");
      Slots.Add((object) "Slot6");
      Slots.Add((object) "Slot7");
      Slots.Add((object) "Slot8");
      Slots.Add((object) "Slot9");
      Slots.Add((object) "Slot10");
      Slots.Add((object) "Slot11");
      Slots.Add((object) "Slot12");
      Slots.Add((object) "Slot13");
      Slots.Add((object) "Slot14");
      Slots.Add((object) "Slot15");
      Slots.Add((object) "Slot16");
      Slots.Add((object) "Slot17");
      Slots.Add((object) "Slot18");
      Slots.Add((object) "Slot19");
      Slots.Add((object) "Slot20");
      Slots.Add((object) "Slot21");
      Slots.Add((object) "Slot22");
      Slots.Add((object) "Slot23");
      Slots.Add((object) "Slot24");
      Slots.Add((object) "Slot25");
      Slots.Add((object) "Slot26");
      Slots.Add((object) "Slot27");
      Slots.Add((object) "Slot28");
      Slots.Add((object) "Slot29");
      Slots.Add((object) "Slot30");
      Slots.Add((object) "Slot31");
      Slots.Add((object) "Slot32");
      Slots.Add((object) "Slot33");
      Slots.Add((object) "Slot34");
      Slots.Add((object) "Slot35");
      Slots.Add((object) "Slot36");
      Slots.Add((object) "Slot37");
      Slots.Add((object) "Slot38");
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Sell Vehicle Option A (Worse)");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem s = new UIMenuListItem("Slot : ", Slots, 0);
      uiMenu1.AddItem((UIMenuItem) s);
      UIMenuItem CarinSlot = new UIMenuItem("Car : ");
      uiMenu1.AddItem(CarinSlot);
      UIMenuItem Delete1 = new UIMenuItem("Sell and Remove");
      uiMenu1.AddItem(Delete1);
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != s)
          return;
        Vehicle vehicle = (Vehicle) null;
        // ISSUE: reference to a compiler-generated field
        if (GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (GaragesXl)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string str = GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__0.Target((CallSite) GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__0, Slots[s.Index]);
        if (str.Equals("Slot1"))
          vehicle = this.Vehicle1;
        if (str.Equals("Slot2"))
          vehicle = this.Vehicle2;
        if (str.Equals("Slot3"))
          vehicle = this.Vehicle3;
        if (str.Equals("Slot4"))
          vehicle = this.Vehicle4;
        if (str.Equals("Slot5"))
          vehicle = this.Vehicle5;
        if (str.Equals("Slot6"))
          vehicle = this.Vehicle6;
        if (str.Equals("Slot7"))
          vehicle = this.Vehicle7;
        if (str.Equals("Slot8"))
          vehicle = this.Vehicle8;
        if (str.Equals("Slot9"))
          vehicle = this.Vehicle9;
        if (str.Equals("Slot10"))
          vehicle = this.Vehicle10;
        if (str.Equals("Slot11"))
          vehicle = this.Vehicle11;
        if (str.Equals("Slot12"))
          vehicle = this.Vehicle12;
        if (str.Equals("Slot13"))
          vehicle = this.Vehicle13;
        if (str.Equals("Slot14"))
          vehicle = this.Vehicle14;
        if (str.Equals("Slot15"))
          vehicle = this.Vehicle15;
        if (str.Equals("Slot16"))
          vehicle = this.Vehicle16;
        if (str.Equals("Slot17"))
          vehicle = this.Vehicle17;
        if (str.Equals("Slot18"))
          vehicle = this.Vehicle18;
        if (str.Equals("Slot19"))
          vehicle = this.Vehicle19;
        if (str.Equals("Slot20"))
          vehicle = this.Vehicle20;
        if (str.Equals("Slot21"))
          vehicle = this.Vehicle21;
        if (str.Equals("Slot22"))
          vehicle = this.Vehicle22;
        if (str.Equals("Slot23"))
          vehicle = this.Vehicle23;
        if (str.Equals("Slot24"))
          vehicle = this.Vehicle24;
        if (str.Equals("Slot25"))
          vehicle = this.Vehicle25;
        if (str.Equals("Slot26"))
          vehicle = this.Vehicle26;
        if (str.Equals("Slot27"))
          vehicle = this.Vehicle27;
        if (str.Equals("Slot28"))
          vehicle = this.Vehicle28;
        if (str.Equals("Slot29"))
          vehicle = this.Vehicle29;
        if (str.Equals("Slot30"))
          vehicle = this.Vehicle30;
        if (str.Equals("Slot31"))
          vehicle = this.Vehicle31;
        if (str.Equals("Slot32"))
          vehicle = this.Vehicle32;
        if (str.Equals("Slot33"))
          vehicle = this.Vehicle33;
        if (str.Equals("Slot34"))
          vehicle = this.Vehicle34;
        if (str.Equals("Slot35"))
          vehicle = this.Vehicle35;
        if (str.Equals("Slot36"))
          vehicle = this.Vehicle36;
        if (str.Equals("Slot37"))
          vehicle = this.Vehicle37;
        if (str.Equals("Slot38"))
          vehicle = this.Vehicle38;
        if ((Entity) vehicle != (Entity) null)
          this.CarToDelete = vehicle;
        this.SC.LoadIniFile(this.path + "GarageA//" + s.IndexToItem(s.Index)?.ToString() + ".ini");
        if (!this.SC.VehicleName.Equals("null"))
          CarinSlot.Text = this.SC.VehicleName;
        else if (this.SC.VehicleName.Equals("null"))
          CarinSlot.Text = "No car in slot";
      });
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        Vehicle vehicle = (Vehicle) null;
        // ISSUE: reference to a compiler-generated field
        if (GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (GaragesXl)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string str = GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__1.Target((CallSite) GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__1, Slots[s.Index]);
        if (str.Equals("Slot1"))
          vehicle = this.Vehicle1;
        if (str.Equals("Slot2"))
          vehicle = this.Vehicle2;
        if (str.Equals("Slot3"))
          vehicle = this.Vehicle3;
        if (str.Equals("Slot4"))
          vehicle = this.Vehicle4;
        if (str.Equals("Slot5"))
          vehicle = this.Vehicle5;
        if (str.Equals("Slot6"))
          vehicle = this.Vehicle6;
        if (str.Equals("Slot7"))
          vehicle = this.Vehicle7;
        if (str.Equals("Slot8"))
          vehicle = this.Vehicle8;
        if (str.Equals("Slot9"))
          vehicle = this.Vehicle9;
        if (str.Equals("Slot10"))
          vehicle = this.Vehicle10;
        if (str.Equals("Slot11"))
          vehicle = this.Vehicle11;
        if (str.Equals("Slot12"))
          vehicle = this.Vehicle12;
        if (str.Equals("Slot13"))
          vehicle = this.Vehicle13;
        if (str.Equals("Slot14"))
          vehicle = this.Vehicle14;
        if (str.Equals("Slot15"))
          vehicle = this.Vehicle15;
        if (str.Equals("Slot16"))
          vehicle = this.Vehicle16;
        if (str.Equals("Slot17"))
          vehicle = this.Vehicle17;
        if (str.Equals("Slot18"))
          vehicle = this.Vehicle18;
        if (str.Equals("Slot19"))
          vehicle = this.Vehicle19;
        if (str.Equals("Slot20"))
          vehicle = this.Vehicle20;
        if (str.Equals("Slot21"))
          vehicle = this.Vehicle21;
        if (str.Equals("Slot22"))
          vehicle = this.Vehicle22;
        if (str.Equals("Slot23"))
          vehicle = this.Vehicle23;
        if (str.Equals("Slot24"))
          vehicle = this.Vehicle24;
        if (str.Equals("Slot25"))
          vehicle = this.Vehicle25;
        if (str.Equals("Slot26"))
          vehicle = this.Vehicle26;
        if (str.Equals("Slot27"))
          vehicle = this.Vehicle27;
        if (str.Equals("Slot28"))
          vehicle = this.Vehicle28;
        if (str.Equals("Slot29"))
          vehicle = this.Vehicle29;
        if (str.Equals("Slot30"))
          vehicle = this.Vehicle30;
        if (str.Equals("Slot31"))
          vehicle = this.Vehicle31;
        if (str.Equals("Slot32"))
          vehicle = this.Vehicle32;
        if (str.Equals("Slot33"))
          vehicle = this.Vehicle33;
        if (str.Equals("Slot34"))
          vehicle = this.Vehicle34;
        if (str.Equals("Slot35"))
          vehicle = this.Vehicle35;
        if (str.Equals("Slot36"))
          vehicle = this.Vehicle36;
        if (str.Equals("Slot37"))
          vehicle = this.Vehicle37;
        if (str.Equals("Slot38"))
          vehicle = this.Vehicle38;
        if (!((Entity) vehicle != (Entity) null))
          return;
        this.CarToDelete = vehicle;
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Delete1)
          return;
        Vehicle vehicle = (Vehicle) null;
        // ISSUE: reference to a compiler-generated field
        if (GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (GaragesXl)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        string str = GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__2.Target((CallSite) GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__2, Slots[s.Index]);
        if (str.Equals("Slot1"))
          vehicle = this.Vehicle1;
        if (str.Equals("Slot2"))
          vehicle = this.Vehicle2;
        if (str.Equals("Slot3"))
          vehicle = this.Vehicle3;
        if (str.Equals("Slot4"))
          vehicle = this.Vehicle4;
        if (str.Equals("Slot5"))
          vehicle = this.Vehicle5;
        if (str.Equals("Slot6"))
          vehicle = this.Vehicle6;
        if (str.Equals("Slot7"))
          vehicle = this.Vehicle7;
        if (str.Equals("Slot8"))
          vehicle = this.Vehicle8;
        if (str.Equals("Slot9"))
          vehicle = this.Vehicle9;
        if (str.Equals("Slot10"))
          vehicle = this.Vehicle10;
        if (str.Equals("Slot11"))
          vehicle = this.Vehicle11;
        if (str.Equals("Slot12"))
          vehicle = this.Vehicle12;
        if (str.Equals("Slot13"))
          vehicle = this.Vehicle13;
        if (str.Equals("Slot14"))
          vehicle = this.Vehicle14;
        if (str.Equals("Slot15"))
          vehicle = this.Vehicle15;
        if (str.Equals("Slot16"))
          vehicle = this.Vehicle16;
        if (str.Equals("Slot17"))
          vehicle = this.Vehicle17;
        if (str.Equals("Slot18"))
          vehicle = this.Vehicle18;
        if (str.Equals("Slot19"))
          vehicle = this.Vehicle19;
        if (str.Equals("Slot20"))
          vehicle = this.Vehicle20;
        if (str.Equals("Slot21"))
          vehicle = this.Vehicle21;
        if (str.Equals("Slot22"))
          vehicle = this.Vehicle22;
        if (str.Equals("Slot23"))
          vehicle = this.Vehicle23;
        if (str.Equals("Slot24"))
          vehicle = this.Vehicle24;
        if (str.Equals("Slot25"))
          vehicle = this.Vehicle25;
        if (str.Equals("Slot26"))
          vehicle = this.Vehicle26;
        if (str.Equals("Slot27"))
          vehicle = this.Vehicle27;
        if (str.Equals("Slot28"))
          vehicle = this.Vehicle28;
        if (str.Equals("Slot29"))
          vehicle = this.Vehicle29;
        if (str.Equals("Slot30"))
          vehicle = this.Vehicle30;
        if (str.Equals("Slot31"))
          vehicle = this.Vehicle31;
        if (str.Equals("Slot32"))
          vehicle = this.Vehicle32;
        if (str.Equals("Slot33"))
          vehicle = this.Vehicle33;
        if (str.Equals("Slot34"))
          vehicle = this.Vehicle34;
        if (str.Equals("Slot35"))
          vehicle = this.Vehicle35;
        if (str.Equals("Slot36"))
          vehicle = this.Vehicle36;
        if (str.Equals("Slot37"))
          vehicle = this.Vehicle37;
        if (str.Equals("Slot38"))
          vehicle = this.Vehicle38;
        if ((Entity) vehicle != (Entity) null)
        {
          // ISSUE: reference to a compiler-generated field
          if (GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__3 = CallSite<Action<CallSite, GaragesXl, object, Vehicle>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "DeleteCarinSlot", (IEnumerable<Type>) null, typeof (GaragesXl), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__3.Target((CallSite) GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__3, this, Slots[s.Index], vehicle);
        }
      });
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.RemoveMenu, "Add vehicle in Slot");
      this.GUIMenus.Add(uiMenu2);
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
      UIMenuListItem Ve = new UIMenuListItem("Vehicle : ", LogList, 0);
      uiMenu2.AddItem((UIMenuItem) Ve);
      UIMenuItem VDName = new UIMenuItem("Vehicle Spawn Name  : Dukes2");
      uiMenu2.AddItem(VDName);
      UIMenuItem VName = new UIMenuItem("Vehicle Full Name  : Imponte Dukes");
      uiMenu2.AddItem(VName);
      UIMenuItem PuchaseV = new UIMenuItem("Purchase Vehicle : $0");
      uiMenu2.AddItem(PuchaseV);
      List<object> STlist = new List<object>();
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      STlist.Add((object) "NULL");
      UIMenuItem uiMenuItem1 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu2.AddItem(uiMenuItem1);
      UIMenuItem Search = new UIMenuItem("Enter Vehicle Name");
      uiMenu2.AddItem(Search);
      UIMenuListItem Ve2 = new UIMenuListItem("Vehicle : ", STlist, 0);
      uiMenu2.AddItem((UIMenuItem) Ve2);
      UIMenuItem uiMenuItem2 = new UIMenuItem("Search Term  : NULL");
      uiMenu2.AddItem(uiMenuItem2);
      UIMenuItem VDName2 = new UIMenuItem("Vehicle Spawn Name  : NULL");
      uiMenu2.AddItem(VDName2);
      UIMenuItem VName2 = new UIMenuItem("Vehicle Full Name  : NULL");
      uiMenu2.AddItem(VName2);
      UIMenuItem PuchaseV2 = new UIMenuItem("Purchase Vehicle : NULL");
      uiMenu2.AddItem(PuchaseV2);
      UIMenuItem uiMenuItem3 = new UIMenuItem("-----------------------------------------------------------");
      uiMenu2.AddItem(uiMenuItem3);
      UIMenuListItem ListSlot = new UIMenuListItem("Slot: ", Slots, 0);
      uiMenu2.AddItem((UIMenuItem) ListSlot);
      uiMenu2.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == Ve)
        {
          try
          {
            string[] separator = new string[2]{ " = ", "," };
            // ISSUE: reference to a compiler-generated field
            if (GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__4 == null)
            {
              // ISSUE: reference to a compiler-generated field
              GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (GaragesXl)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            string[] strArray = GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__4.Target((CallSite) GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__4, LogList[Ve.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
          if (GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (GaragesXl)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string[] strArray = GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__5.Target((CallSite) GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__5, STlist[Ve2.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
              this.DestoryCars();
              // ISSUE: reference to a compiler-generated field
              if (GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__6 == null)
              {
                // ISSUE: reference to a compiler-generated field
                GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (GaragesXl)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              string str = GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__6.Target((CallSite) GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__6, Slots[ListSlot.Index]);
              this.SC.LoadIniFile(this.path + this.GarageNum + "//" + str + ".ini");
              UI.Notify(this.path + this.GarageNum + "//" + str + ".ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.SC.LoadIniFile(this.path + this.GarageNum + "//" + str + ".ini");
              try
              {
                Vehicle vehicle = World.CreateVehicle(this.RequestModel(this.man), new Vector3(), 0.0f);
                this.SC.SaveName(vehicle.DisplayName);
                UI.Notify("Test3");
                this.CreateCars(this.GarageNum);
                vehicle.Delete();
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
            UI.Notify("Agent 14: you do not have enought money to purchase this vehicle!");
        }
        if (item != PuchaseV)
          return;
        if ((double) Game.Player.Money > (double) this.M)
        {
          try
          {
            Game.Player.Money -= (int) this.M;
            this.DestoryCars();
            // ISSUE: reference to a compiler-generated field
            if (GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__7 == null)
            {
              // ISSUE: reference to a compiler-generated field
              GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (GaragesXl)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            string str = GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__7.Target((CallSite) GaragesXl.\u003C\u003Eo__136.\u003C\u003Ep__7, Slots[ListSlot.Index]);
            this.SC.LoadIniFile(this.path + this.GarageNum + "//" + str + ".ini");
            UI.Notify(this.path + this.GarageNum + "//" + str + ".ini");
            Vector3 position = Game.Player.Character.Position;
            this.SC.Save();
            try
            {
              this.SC.LoadIniFile(this.path + this.GarageNum + "//" + str + ".ini");
              Vehicle vehicle = World.CreateVehicle(this.RequestModel(this.man), new Vector3(), 0.0f);
              this.SC.SaveName(vehicle.DisplayName);
              UI.Notify("Test3");
              this.CreateCars(this.GarageNum);
              vehicle.Delete();
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
          UI.Notify("Agent 14: you do not have enought money to purchase this vehicle!");
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
          string str = G;
          this.GarageNum = G;
          UI.Notify(this.path + str + "//" + Slot + ".ini");
          this.SC.LoadIniFile(this.path + str + "//" + Slot + ".ini");
          this.SC.SaveWithoutDelete();
          Script.Wait(1000);
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
            Game.Player.Character.CurrentVehicle.Delete();
          if (!((Entity) Game.Player.Character.LastVehicle != (Entity) null))
            return;
          Game.Player.Character.LastVehicle.Delete();
        }
        else
          this.DisplayHelpTextThisFrame("You cannot save this vehicle");
      }
      else
        this.DisplayHelpTextThisFrame("Bring a vehicle to save");
    }

    private void SetupGarage()
    {
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1");
      Slots.Add((object) "Slot2");
      Slots.Add((object) "Slot3");
      Slots.Add((object) "Slot4");
      Slots.Add((object) "Slot5");
      Slots.Add((object) "Slot6");
      Slots.Add((object) "Slot7");
      Slots.Add((object) "Slot8");
      Slots.Add((object) "Slot9");
      Slots.Add((object) "Slot10");
      Slots.Add((object) "Slot11");
      Slots.Add((object) "Slot12");
      Slots.Add((object) "Slot13");
      Slots.Add((object) "Slot14");
      Slots.Add((object) "Slot15");
      Slots.Add((object) "Slot16");
      Slots.Add((object) "Slot17");
      Slots.Add((object) "Slot18");
      Slots.Add((object) "Slot19");
      Slots.Add((object) "Slot20");
      Slots.Add((object) "Slot21");
      Slots.Add((object) "Slot22");
      Slots.Add((object) "Slot23");
      Slots.Add((object) "Slot24");
      Slots.Add((object) "Slot25");
      Slots.Add((object) "Slot26");
      Slots.Add((object) "Slot27");
      Slots.Add((object) "Slot28");
      Slots.Add((object) "Slot29");
      Slots.Add((object) "Slot30");
      Slots.Add((object) "Slot31");
      Slots.Add((object) "Slot32");
      Slots.Add((object) "Slot33");
      Slots.Add((object) "Slot34");
      Slots.Add((object) "Slot35");
      Slots.Add((object) "Slot36");
      Slots.Add((object) "Slot37");
      Slots.Add((object) "Slot38");
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.GarageMenu, "Enter Garage");
      this.GUIMenus.Add(uiMenu);
      UIMenuListItem s = new UIMenuListItem("Slot : ", Slots, 0);
      uiMenu.AddItem((UIMenuItem) s);
      UIMenuItem CarinSlot = new UIMenuItem("Car : ");
      uiMenu.AddItem(CarinSlot);
      UIMenuItem Set = new UIMenuItem("Save Current Car");
      uiMenu.AddItem(Set);
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != s)
          return;
        this.SC.LoadIniFile(this.path + "GarageA//" + s.IndexToItem(s.Index)?.ToString() + ".ini");
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
        if (GaragesXl.\u003C\u003Eo__138.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          GaragesXl.\u003C\u003Eo__138.\u003C\u003Ep__0 = CallSite<Action<CallSite, GaragesXl, string, Vehicle, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "SaveLocalcar", (IEnumerable<Type>) null, typeof (GaragesXl), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        GaragesXl.\u003C\u003Eo__138.\u003C\u003Ep__0.Target((CallSite) GaragesXl.\u003C\u003Eo__138.\u003C\u003Ep__0, this, "GarageA", this.Vehicle1, Slots[s.Index]);
      });
    }

    public void ReReadIni() => this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Main.ini");

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if (this.VehicleWarehouseMarker != (Blip) null)
        this.VehicleWarehouseMarker.Remove();
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
      if ((Entity) this.Vehicle13 != (Entity) null)
        this.Vehicle13.Delete();
      if ((Entity) this.Vehicle14 != (Entity) null)
        this.Vehicle14.Delete();
      if ((Entity) this.Vehicle15 != (Entity) null)
        this.Vehicle15.Delete();
      if ((Entity) this.Vehicle16 != (Entity) null)
        this.Vehicle16.Delete();
      if ((Entity) this.Vehicle17 != (Entity) null)
        this.Vehicle17.Delete();
      if ((Entity) this.Vehicle18 != (Entity) null)
        this.Vehicle18.Delete();
      if ((Entity) this.Vehicle19 != (Entity) null)
        this.Vehicle19.Delete();
      if ((Entity) this.Vehicle20 != (Entity) null)
        this.Vehicle20.Delete();
      if ((Entity) this.Vehicle21 != (Entity) null)
        this.Vehicle21.Delete();
      if ((Entity) this.Vehicle22 != (Entity) null)
        this.Vehicle22.Delete();
      if ((Entity) this.Vehicle23 != (Entity) null)
        this.Vehicle23.Delete();
      if ((Entity) this.Vehicle24 != (Entity) null)
        this.Vehicle24.Delete();
      if ((Entity) this.Vehicle25 != (Entity) null)
        this.Vehicle25.Delete();
      if ((Entity) this.Vehicle26 != (Entity) null)
        this.Vehicle26.Delete();
      if ((Entity) this.Vehicle27 != (Entity) null)
        this.Vehicle27.Delete();
      if ((Entity) this.Vehicle28 != (Entity) null)
        this.Vehicle28.Delete();
      if ((Entity) this.Vehicle29 != (Entity) null)
        this.Vehicle29.Delete();
      if ((Entity) this.Vehicle30 != (Entity) null)
        this.Vehicle30.Delete();
      if ((Entity) this.Vehicle31 != (Entity) null)
        this.Vehicle31.Delete();
      if ((Entity) this.Vehicle32 != (Entity) null)
        this.Vehicle32.Delete();
      if ((Entity) this.Vehicle33 != (Entity) null)
        this.Vehicle33.Delete();
      if ((Entity) this.Vehicle34 != (Entity) null)
        this.Vehicle34.Delete();
      if ((Entity) this.Vehicle35 != (Entity) null)
        this.Vehicle35.Delete();
      if ((Entity) this.Vehicle36 != (Entity) null)
        this.Vehicle36.Delete();
      if ((Entity) this.Vehicle37 != (Entity) null)
        this.Vehicle37.Delete();
      if ((Entity) this.Vehicle38 != (Entity) null)
        this.Vehicle38.Delete();
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    private void OnTick(object sender, EventArgs e)
    {
      this.OnKeyDown();
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      if (this.modMenuPool2 != null && this.modMenuPool2.IsAnyMenuOpen())
        this.modMenuPool2.ProcessMenus();
      if (this.modMenuPool3 != null && this.modMenuPool3.IsAnyMenuOpen())
        this.modMenuPool3.ProcessMenus();
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(3000f, 1000f, 2000f)) < 3.0)
        this.ReReadIni();
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(404f, 404f, 404f)) < 3.0 && this.IsInInterior)
      {
        UI.Notify("Delete");
        this.DestoryCars();
        this.IsInInterior = false;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(808f, 808f, 808f)) < 3.0 && !this.IsInInterior)
      {
        UI.Notify("Load");
        this.DestoryCars();
        this.CreateCars("GarageA");
        this.IsInInterior = true;
      }
      if (!this.OnMission)
      {
        if (this.Casino_level >= 3 && (double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker) < 60.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.ExitMarker, Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 1f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker) < 5.0 && this.Casino_level >= 3)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to exit the garage ");
        if ((double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 5.0 && this.Casino_level >= 3)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to save a vehicle into Garage the or Press ~INPUT_COVER~ to Enter Garage ");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.RemoveMarker) < 2.0 && this.IsInInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sell/Buy a vehicle");
      if (this.Casino_level >= 3 && this.IsInInterior)
        World.DrawMarker(MarkerType.VerticalCylinder, this.RemoveMarker, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), this.MarkerColor);
      if ((Entity) this.VehicleToDeliver != (Entity) null)
      {
        if (this.VehicleToDeliver.IsAlive && ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(862.92f, 2171.73f, 53f)) < 20.0 && (Entity) this.VehicleToDeliver != (Entity) null))
        {
          this.DeliveringVehicle = false;
          this.DeleteCarinSlot2(this.SlotToDelete, this.VehicleToDeliver);
          this.SlotToDelete = (string) null;
        }
        if ((Entity) this.VehicleToDeliver != (Entity) null && (!this.VehicleToDeliver.IsAlive && (Entity) this.VehicleToDeliver != (Entity) null))
        {
          this.DeliveringVehicle = false;
          this.GarageNum = "GarageA";
          this.SC.LoadIniFile(this.path + "GarageA//" + this.SlotToDelete + ".ini");
          UI.Notify(this.path + "GarageA//" + this.SlotToDelete + ".ini");
          this.SC.SaveName();
          this.VehicleToDeliver.Delete();
          this.SlotToDelete = (string) null;
          UI.Notify("Office Assistant : Sorry boss, there is no pay for a destroyed vehicle");
        }
      }
      if (!this.IsInInterior || !((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
        return;
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      if (Game.IsControlJustPressed(2, Control.Cover) && (Entity) currentVehicle != (Entity) null)
        currentVehicle.FreezePosition = false;
      if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle11)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle12)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle13 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle13)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle14 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle14)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle15 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle15)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle16 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle16)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle17 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle17)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle18 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle18)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle19 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle19)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle20 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle20)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle21 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle21)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle22 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle22)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle23 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle23)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle24 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle24)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle25 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle25)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle26 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle26)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle27 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle27)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle28 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle28)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle29 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle29)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle30 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle30)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle31 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle31)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle32 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle32)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle33 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle33)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle34 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle34)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle35 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle35)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle36 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle36)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle37 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle37)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
      if ((Entity) this.Vehicle38 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle38)
      {
        currentVehicle.FreezePosition = true;
        currentVehicle.EngineRunning = true;
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or ~INPUT_COVER~ to save this vehicle ");
      }
    }

    public void LoadCarinToRealWorld(Vehicle V)
    {
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      this.IsInInterior = false;
      currentVehicle.Position = this.WherehouseMarker;
      Game.Player.Character.SetIntoVehicle(currentVehicle, VehicleSeat.Driver);
      this.DestoryCars();
      currentVehicle.Heading = 147f;
      currentVehicle.IsDriveable = true;
      this.SaveVehicle = currentVehicle;
      this.SaveVehicle.IsDriveable = true;
      this.SaveVehicle.Repair();
      this.SaveVehicle.FreezePosition = false;
    }

    public void LoadCarinToRealWorld2(Vehicle V, string Slot)
    {
      this.SC.LoadIniFile(this.path + "GarageA//" + Slot + ".ini");
      V = World.CreateVehicle((GTA.Model) V.DisplayName, this.MenuMarker, 147f);
      this.SC.Load(V);
      V.IsDriveable = true;
      V.Position = this.MenuMarker;
      this.VehicleToDeliver = V;
      V = (Vehicle) null;
      this.IsInInterior = false;
      this.VehicleToDeliver.Position = this.WherehouseMarker;
      Game.Player.Character.SetIntoVehicle(this.VehicleToDeliver, VehicleSeat.Driver);
      this.DestoryCars();
      this.VehicleToDeliver.Heading = 147f;
      this.VehicleToDeliver.IsDriveable = true;
      this.SaveVehicle = this.VehicleToDeliver;
      this.SaveVehicle.IsDriveable = true;
      this.SaveVehicle.Repair();
      this.SaveVehicle.FreezePosition = false;
    }

    private void OnKeyDown()
    {
      if (Game.IsControlJustPressed(2, Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 5.0 && (this.Casino_level >= 3 && Game.Player.WantedLevel == 0) && !this.mainMenu.Visible)
        this.mainMenu.Visible = !this.mainMenu.Visible;
      if (Game.IsControlJustPressed(2, Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.RemoveMarker) < 2.0 && (this.Casino_level >= 3 && this.IsInInterior) && !this.mainMenu2.Visible)
        this.mainMenu2.Visible = !this.mainMenu2.Visible;
      if (Game.IsControlJustPressed(2, Control.Cover) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle1 = Game.Player.Character.CurrentVehicle;
      }
      if (Game.IsControlJustPressed(2, Control.Cover) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle2 = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle1)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot1.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle2)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot2.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle3)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot3.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle4)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot4.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle5)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot5.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle6)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot6.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle7)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot7.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle8)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot8.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle9)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot9.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle10)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot10.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle11)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot11.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle12)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot12.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle13 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle13)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot13.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle14 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle14)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot14.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle15 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle15)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot15.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle16 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle16)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot16.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle17 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle17)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot17.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle18 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle18)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot18.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle19 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle19)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot19.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle20 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle20)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot20.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle21 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle21)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot21.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle22 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle22)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot22.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle23 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle23)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot23.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle24 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle24)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot24.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle25 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle25)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot25.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle26 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle26)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot26.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle27 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle27)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot27.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle28 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle28)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot28.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle29 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle29)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot29.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle30 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle30)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot30.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle31 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle31)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot31.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle32 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle32)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot32.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle33 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle33)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot33.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle34 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle34)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot34.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle35 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle35)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot35.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle36 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle36)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot36.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle37 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle37)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot37.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
        if ((Entity) this.Vehicle38 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle38)
        {
          this.SC.LoadIniFile(this.path + "GarageA//Slot38.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " : Saved Current vehicle");
        }
      }
      if (Game.IsControlJustPressed(2, Control.Context) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle2 = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle1)
        {
          this.Vehicle1 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle1);
        }
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle2)
        {
          this.Vehicle2 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle2);
        }
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle3)
        {
          this.Vehicle3 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle3);
        }
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle4)
        {
          this.Vehicle4 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle4);
        }
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle5)
        {
          this.Vehicle5 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle5);
        }
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle6)
        {
          this.Vehicle6 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle6);
        }
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle7)
        {
          this.Vehicle7 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle7);
        }
        if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle8)
        {
          this.Vehicle8 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle8);
        }
        if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle9)
        {
          this.Vehicle9 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle9);
        }
        if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle10)
        {
          this.Vehicle10 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle10);
        }
        if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle11)
        {
          this.Vehicle11 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle11);
        }
        if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle12)
        {
          this.Vehicle12 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle12);
        }
        if ((Entity) this.Vehicle13 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle13)
        {
          this.Vehicle13 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle13);
        }
        if ((Entity) this.Vehicle14 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle14)
        {
          this.Vehicle14 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle14);
        }
        if ((Entity) this.Vehicle15 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle15)
        {
          this.Vehicle15 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle15);
        }
        if ((Entity) this.Vehicle16 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle16)
        {
          this.Vehicle16 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle16);
        }
        if ((Entity) this.Vehicle17 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle17)
        {
          this.Vehicle17 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle17);
        }
        if ((Entity) this.Vehicle18 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle18)
        {
          this.Vehicle18 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle18);
        }
        if ((Entity) this.Vehicle19 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle19)
        {
          this.Vehicle19 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle19);
        }
        if ((Entity) this.Vehicle20 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle20)
        {
          this.Vehicle20 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle20);
        }
        if ((Entity) this.Vehicle21 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle21)
        {
          this.Vehicle21 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle21);
        }
        if ((Entity) this.Vehicle22 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle22)
        {
          this.Vehicle22 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle22);
        }
        if ((Entity) this.Vehicle23 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle23)
        {
          this.Vehicle23 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle23);
        }
        if ((Entity) this.Vehicle24 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle24)
        {
          this.Vehicle24 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle24);
        }
        if ((Entity) this.Vehicle25 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle25)
        {
          this.Vehicle25 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle25);
        }
        if ((Entity) this.Vehicle26 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle26)
        {
          this.Vehicle26 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle26);
        }
        if ((Entity) this.Vehicle27 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle27)
        {
          this.Vehicle27 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle27);
        }
        if ((Entity) this.Vehicle28 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle28)
        {
          this.Vehicle28 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle28);
        }
        if ((Entity) this.Vehicle29 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle29)
        {
          this.Vehicle29 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle29);
        }
        if ((Entity) this.Vehicle30 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle30)
        {
          this.Vehicle30 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle30);
        }
        if ((Entity) this.Vehicle31 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle31)
        {
          this.Vehicle31 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle31);
        }
        if ((Entity) this.Vehicle32 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle32)
        {
          this.Vehicle32 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle32);
        }
        if ((Entity) this.Vehicle33 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle33)
        {
          this.Vehicle33 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle33);
        }
        if ((Entity) this.Vehicle34 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle34)
        {
          this.Vehicle34 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle34);
        }
        if ((Entity) this.Vehicle35 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle35)
        {
          this.Vehicle35 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle35);
        }
        if ((Entity) this.Vehicle36 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle36)
        {
          this.Vehicle36 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle36);
        }
        if ((Entity) this.Vehicle37 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle37)
        {
          this.Vehicle37 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle37);
        }
        if ((Entity) this.Vehicle38 != (Entity) null && (Entity) currentVehicle2 == (Entity) this.Vehicle38)
        {
          this.Vehicle38 = (Vehicle) null;
          this.LoadCarinToRealWorld(this.Vehicle38);
        }
      }
      if (Game.IsControlJustPressed(2, Control.Cover) && !this.OnMission && (double) World.GetDistance(Game.Player.Character.Position, this.WherehouseMarker) < 2.0)
      {
        if (this.IsInInterior)
          ;
        Game.Player.Character.Position = this.ExitMarker;
        this.DestoryCars();
        this.IsInInterior = true;
        this.CreateCars("GarageA");
        UI.Notify("Loading in Cars this may take a minute");
      }
      if (Game.IsControlJustPressed(2, Control.Context) && this.IsInInterior && (double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker) < 2.0)
      {
        this.IsInInterior = false;
        Script.Wait(300);
        this.DestoryCars();
        Game.Player.Character.Position = this.WherehouseMarker;
      }
      if (!Game.IsControlJustPressed(2, Control.Cover) || !this.IsInInterior || (double) World.GetDistance(Game.Player.Character.Position, this.ExitMarker2) >= 2.0)
        return;
      this.IsInInterior = false;
      Script.Wait(300);
      this.DestoryCars();
      Game.Player.Character.Position = this.MenuMarker;
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
      if ((Entity) this.Vehicle13 != (Entity) null)
        this.Vehicle13.Delete();
      if ((Entity) this.Vehicle14 != (Entity) null)
        this.Vehicle14.Delete();
      if ((Entity) this.Vehicle15 != (Entity) null)
        this.Vehicle15.Delete();
      if ((Entity) this.Vehicle16 != (Entity) null)
        this.Vehicle16.Delete();
      if ((Entity) this.Vehicle17 != (Entity) null)
        this.Vehicle17.Delete();
      if ((Entity) this.Vehicle18 != (Entity) null)
        this.Vehicle18.Delete();
      if ((Entity) this.Vehicle19 != (Entity) null)
        this.Vehicle19.Delete();
      if ((Entity) this.Vehicle20 != (Entity) null)
        this.Vehicle20.Delete();
      if ((Entity) this.Vehicle21 != (Entity) null)
        this.Vehicle21.Delete();
      if ((Entity) this.Vehicle22 != (Entity) null)
        this.Vehicle22.Delete();
      if ((Entity) this.Vehicle23 != (Entity) null)
        this.Vehicle23.Delete();
      if ((Entity) this.Vehicle24 != (Entity) null)
        this.Vehicle24.Delete();
      if ((Entity) this.Vehicle25 != (Entity) null)
        this.Vehicle25.Delete();
      if ((Entity) this.Vehicle26 != (Entity) null)
        this.Vehicle26.Delete();
      if ((Entity) this.Vehicle27 != (Entity) null)
        this.Vehicle27.Delete();
      if ((Entity) this.Vehicle28 != (Entity) null)
        this.Vehicle28.Delete();
      if ((Entity) this.Vehicle29 != (Entity) null)
        this.Vehicle29.Delete();
      if ((Entity) this.Vehicle30 != (Entity) null)
        this.Vehicle30.Delete();
      if ((Entity) this.Vehicle31 != (Entity) null)
        this.Vehicle31.Delete();
      if ((Entity) this.Vehicle32 != (Entity) null)
        this.Vehicle32.Delete();
      if ((Entity) this.Vehicle33 != (Entity) null)
        this.Vehicle33.Delete();
      if ((Entity) this.Vehicle34 != (Entity) null)
        this.Vehicle34.Delete();
      if ((Entity) this.Vehicle35 != (Entity) null)
        this.Vehicle35.Delete();
      if ((Entity) this.Vehicle36 != (Entity) null)
        this.Vehicle36.Delete();
      if ((Entity) this.Vehicle37 != (Entity) null)
        this.Vehicle37.Delete();
      if (!((Entity) this.Vehicle38 != (Entity) null))
        return;
      this.Vehicle38.Delete();
    }

    public void CreateCars(string Garage)
    {
      try
      {
        Function.Call(Hash._0xEE6C5AD3ECE0A82D, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "urban_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "branded_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "basic_style_set");
        Function.Call(Hash._0x420BD37289EEE162, (InputArgument) 252673, (InputArgument) "car_floor_hatch");
        Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) 252673);
        Function.Call(Hash._0x41B4893843BBDB74, (InputArgument) "imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_");
        Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 994.5925, (InputArgument) -3002.594, (InputArgument) -39.64699);
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Main.ini");
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
        this.SC.LoadIniFile(this.path + Garage + "//Slot11.ini");
        GTA.Model model11 = this.SC.CheckCar(this.path + Garage + "//Slot11.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot12.ini");
        GTA.Model model12 = this.SC.CheckCar(this.path + Garage + "//Slot12.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot13.ini");
        GTA.Model model13 = this.SC.CheckCar(this.path + Garage + "//Slot13.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot14.ini");
        GTA.Model model14 = this.SC.CheckCar(this.path + Garage + "//Slot14.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot15.ini");
        GTA.Model model15 = this.SC.CheckCar(this.path + Garage + "//Slot15.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot16.ini");
        GTA.Model model16 = this.SC.CheckCar(this.path + Garage + "//Slot15.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot17.ini");
        GTA.Model model17 = this.SC.CheckCar(this.path + Garage + "//Slot17.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot18.ini");
        GTA.Model model18 = this.SC.CheckCar(this.path + Garage + "//Slot18.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot19.ini");
        GTA.Model model19 = this.SC.CheckCar(this.path + Garage + "//Slot19.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot20.ini");
        GTA.Model model20 = this.SC.CheckCar(this.path + Garage + "//Slot20.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot21.ini");
        GTA.Model model21 = this.SC.CheckCar(this.path + Garage + "//Slot21.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot22.ini");
        GTA.Model model22 = this.SC.CheckCar(this.path + Garage + "//Slot22.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot23.ini");
        GTA.Model model23 = this.SC.CheckCar(this.path + Garage + "//Slot23.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot24.ini");
        GTA.Model model24 = this.SC.CheckCar(this.path + Garage + "//Slot24.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot25.ini");
        GTA.Model model25 = this.SC.CheckCar(this.path + Garage + "//Slot25.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot26.ini");
        GTA.Model model26 = this.SC.CheckCar(this.path + Garage + "//Slot26.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot27.ini");
        GTA.Model model27 = this.SC.CheckCar(this.path + Garage + "//Slot27.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot28.ini");
        GTA.Model model28 = this.SC.CheckCar(this.path + Garage + "//Slot28.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot29.ini");
        GTA.Model model29 = this.SC.CheckCar(this.path + Garage + "//Slot29.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot30.ini");
        GTA.Model model30 = this.SC.CheckCar(this.path + Garage + "//Slot30.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot31.ini");
        GTA.Model model31 = this.SC.CheckCar(this.path + Garage + "//Slot31.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot32.ini");
        GTA.Model model32 = this.SC.CheckCar(this.path + Garage + "//Slot32.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot33.ini");
        GTA.Model model33 = this.SC.CheckCar(this.path + Garage + "//Slot33.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot34.ini");
        GTA.Model model34 = this.SC.CheckCar(this.path + Garage + "//Slot34.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot35.ini");
        GTA.Model model35 = this.SC.CheckCar(this.path + Garage + "//Slot35.ini");
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Main.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot36.ini");
        GTA.Model model36 = this.SC.CheckCar(this.path + Garage + "//Slot36.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot37.ini");
        GTA.Model model37 = this.SC.CheckCar(this.path + Garage + "//Slot37.ini");
        this.SC.LoadIniFile(this.path + Garage + "//Slot38.ini");
        GTA.Model model38 = this.SC.CheckCar(this.path + Garage + "//Slot38.ini");
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Main.ini");
        Script.Wait(100);
        if (model1 != (GTA.Model) "null" && model1 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot1.ini");
          this.Vehicle1 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot1.ini"), this.Vehicle1Loc, -90f);
          this.SC.Load(this.Vehicle1);
          this.Vehicle1.IsDriveable = false;
        }
        Script.Wait(100);
        if (model2 != (GTA.Model) "null" && model2 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot2.ini");
          this.Vehicle2 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot2.ini"), this.Vehicle2Loc, -90f);
          this.SC.Load(this.Vehicle2);
          this.Vehicle2.IsDriveable = false;
        }
        Script.Wait(100);
        if (model3 != (GTA.Model) "null" && model3 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot3.ini");
          this.Vehicle3 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot3.ini"), this.Vehicle3Loc, -90f);
          this.SC.Load(this.Vehicle3);
          this.Vehicle3.IsDriveable = false;
        }
        Script.Wait(100);
        if (model4 != (GTA.Model) "null" && model4 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot4.ini");
          this.Vehicle4 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot4.ini"), this.Vehicle4Loc, -90f);
          this.SC.Load(this.Vehicle4);
          this.Vehicle4.IsDriveable = false;
        }
        Script.Wait(100);
        if (model5 != (GTA.Model) "null" && model5 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot5.ini");
          this.Vehicle5 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot5.ini"), this.Vehicle5Loc, -90f);
          this.SC.Load(this.Vehicle5);
          this.Vehicle5.IsDriveable = false;
        }
        Script.Wait(100);
        if (model6 != (GTA.Model) "null" && model6 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot6.ini");
          this.Vehicle6 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot6.ini"), this.Vehicle6Loc, -90f);
          this.SC.Load(this.Vehicle6);
          this.Vehicle6.IsDriveable = false;
        }
        Script.Wait(100);
        if (model7 != (GTA.Model) "null" && model7 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot7.ini");
          this.Vehicle7 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot7.ini"), this.Vehicle7Loc, -90f);
          this.SC.Load(this.Vehicle7);
          this.Vehicle7.IsDriveable = false;
        }
        Script.Wait(100);
        if (model8 != (GTA.Model) "null" && model8 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot8.ini");
          this.Vehicle8 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot8.ini"), this.Vehicle8Loc, -90f);
          this.SC.Load(this.Vehicle8);
          this.Vehicle8.IsDriveable = false;
        }
        Script.Wait(100);
        if (model9 != (GTA.Model) "null" && model9 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot9.ini");
          this.Vehicle9 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot9.ini"), this.Vehicle9Loc, -90f);
          this.SC.Load(this.Vehicle9);
          this.Vehicle9.IsDriveable = false;
        }
        Script.Wait(100);
        if (model10 != (GTA.Model) "null" && model10 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot10.ini");
          this.Vehicle10 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot10.ini"), this.Vehicle10Loc, -90f);
          this.SC.Load(this.Vehicle10);
          this.Vehicle10.IsDriveable = false;
        }
        Script.Wait(100);
        if (model11 != (GTA.Model) "null" && model11 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot11.ini");
          this.Vehicle11 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot11.ini"), this.Vehicle11Loc, -90f);
          this.SC.Load(this.Vehicle11);
          this.Vehicle11.IsDriveable = false;
        }
        Script.Wait(100);
        if (model12 != (GTA.Model) "null" && model12 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot12.ini");
          this.Vehicle12 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot12.ini"), this.Vehicle12Loc, -90f);
          this.SC.Load(this.Vehicle12);
          this.Vehicle12.IsDriveable = false;
        }
        Script.Wait(100);
        if (model13 != (GTA.Model) "null" && model13 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot13.ini");
          this.Vehicle13 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot13.ini"), this.Vehicle13Loc, -90f);
          this.SC.Load(this.Vehicle13);
          this.Vehicle13.IsDriveable = false;
        }
        Script.Wait(100);
        if (model14 != (GTA.Model) "null" && model14 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot14.ini");
          this.Vehicle14 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot14.ini"), this.Vehicle14Loc, -90f);
          this.SC.Load(this.Vehicle14);
          this.Vehicle14.IsDriveable = false;
        }
        Script.Wait(100);
        if (model15 != (GTA.Model) "null" && model15 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot15.ini");
          this.Vehicle15 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot15.ini"), this.Vehicle15Loc, 90f);
          this.SC.Load(this.Vehicle15);
          this.Vehicle15.IsDriveable = false;
        }
        Script.Wait(100);
        if (model16 != (GTA.Model) "null" && model16 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot16.ini");
          this.Vehicle16 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot16.ini"), this.Vehicle16Loc, 90f);
          this.SC.Load(this.Vehicle16);
          this.Vehicle16.IsDriveable = false;
        }
        Script.Wait(100);
        if (model17 != (GTA.Model) "null" && model17 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot17.ini");
          this.Vehicle17 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot17.ini"), this.Vehicle17Loc, 90f);
          this.SC.Load(this.Vehicle17);
          this.Vehicle17.IsDriveable = false;
        }
        Script.Wait(100);
        if (model18 != (GTA.Model) "null" && model18 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot18.ini");
          this.Vehicle18 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot18.ini"), this.Vehicle18Loc, 90f);
          this.SC.Load(this.Vehicle18);
          this.Vehicle18.IsDriveable = false;
        }
        Script.Wait(100);
        if (model19 != (GTA.Model) "null" && model19 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot19.ini");
          this.Vehicle19 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot19.ini"), this.Vehicle19Loc, 90f);
          this.SC.Load(this.Vehicle19);
          this.Vehicle19.IsDriveable = false;
        }
        Script.Wait(100);
        if (model20 != (GTA.Model) "null" && model20 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot20.ini");
          this.Vehicle20 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot20.ini"), this.Vehicle20Loc, 90f);
          this.SC.Load(this.Vehicle20);
          this.Vehicle20.IsDriveable = false;
        }
        Script.Wait(100);
        if (model21 != (GTA.Model) "null" && model21 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot21.ini");
          this.Vehicle21 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot21.ini"), this.Vehicle21Loc, 90f);
          this.SC.Load(this.Vehicle21);
          this.Vehicle21.IsDriveable = false;
        }
        Script.Wait(100);
        if (model22 != (GTA.Model) "null" && model22 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot22.ini");
          this.Vehicle22 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot22.ini"), this.Vehicle22Loc, 90f);
          this.SC.Load(this.Vehicle22);
          this.Vehicle22.IsDriveable = false;
        }
        Script.Wait(100);
        if (model23 != (GTA.Model) "null" && model23 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot23.ini");
          this.Vehicle23 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot23.ini"), this.Vehicle23Loc, 90f);
          this.SC.Load(this.Vehicle23);
          this.Vehicle23.IsDriveable = false;
        }
        Script.Wait(100);
        if (model24 != (GTA.Model) "null" && model24 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot24.ini");
          this.Vehicle24 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot24.ini"), this.Vehicle24Loc, 90f);
          this.SC.Load(this.Vehicle24);
          this.Vehicle24.IsDriveable = false;
        }
        Script.Wait(100);
        if (model25 != (GTA.Model) "null" && model25 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot25.ini");
          this.Vehicle25 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot25.ini"), this.Vehicle25Loc, 90f);
          this.SC.Load(this.Vehicle25);
          this.Vehicle25.IsDriveable = false;
        }
        Script.Wait(100);
        if (model26 != (GTA.Model) "null" && model26 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot26.ini");
          this.Vehicle26 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot26.ini"), this.Vehicle26Loc, 90f);
          this.SC.Load(this.Vehicle26);
          this.Vehicle26.IsDriveable = false;
        }
        Script.Wait(100);
        if (model27 != (GTA.Model) "null" && model27 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot27.ini");
          this.Vehicle27 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot27.ini"), this.Vehicle27Loc, 90f);
          this.SC.Load(this.Vehicle27);
          this.Vehicle27.IsDriveable = false;
        }
        Script.Wait(100);
        if (model28 != (GTA.Model) "null" && model28 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot28.ini");
          this.Vehicle28 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot28.ini"), this.Vehicle28Loc, 90f);
          this.SC.Load(this.Vehicle28);
          this.Vehicle28.IsDriveable = false;
        }
        Script.Wait(100);
        if (model29 != (GTA.Model) "null" && model29 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot29.ini");
          this.Vehicle29 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot29.ini"), this.Vehicle29Loc, 90f);
          this.SC.Load(this.Vehicle29);
          this.Vehicle29.IsDriveable = false;
        }
        Script.Wait(100);
        if (model30 != (GTA.Model) "null" && model30 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot30.ini");
          this.Vehicle30 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot30.ini"), this.Vehicle30Loc, 90f);
          this.SC.Load(this.Vehicle30);
          this.Vehicle30.IsDriveable = false;
        }
        Script.Wait(100);
        if (model31 != (GTA.Model) "null" && model31 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot31.ini");
          this.Vehicle31 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot31.ini"), this.Vehicle31Loc, 90f);
          this.SC.Load(this.Vehicle31);
          this.Vehicle31.IsDriveable = false;
        }
        Script.Wait(100);
        if (model32 != (GTA.Model) "null" && model32 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot32.ini");
          this.Vehicle32 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot32.ini"), this.Vehicle32Loc, 90f);
          this.SC.Load(this.Vehicle32);
          this.Vehicle32.IsDriveable = false;
        }
        Script.Wait(100);
        if (model33 != (GTA.Model) "null" && model33 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot33.ini");
          this.Vehicle33 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot33.ini"), this.Vehicle33Loc, 90f);
          this.SC.Load(this.Vehicle33);
          this.Vehicle33.IsDriveable = false;
        }
        Script.Wait(100);
        if (model34 != (GTA.Model) "null" && model34 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot34.ini");
          this.Vehicle34 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot34.ini"), this.Vehicle34Loc, 90f);
          this.SC.Load(this.Vehicle34);
          this.Vehicle34.IsDriveable = false;
        }
        Script.Wait(100);
        if (model35 != (GTA.Model) "null" && model35 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot35.ini");
          this.Vehicle35 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot35.ini"), this.Vehicle35Loc, 90f);
          this.SC.Load(this.Vehicle35);
          this.Vehicle35.IsDriveable = false;
        }
        Script.Wait(100);
        if (model36 != (GTA.Model) "null" && model36 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot36.ini");
          this.Vehicle36 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot36.ini"), this.Vehicle36Loc, 90f);
          this.SC.Load(this.Vehicle36);
          this.Vehicle36.IsDriveable = false;
        }
        Script.Wait(100);
        if (model37 != (GTA.Model) "null" && model37 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot37.ini");
          this.Vehicle37 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot37.ini"), this.Vehicle37Loc, 90f);
          this.SC.Load(this.Vehicle37);
          this.Vehicle37.IsDriveable = false;
        }
        Script.Wait(100);
        if (model38 != (GTA.Model) "null" && model38 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + Garage + "//Slot38.ini");
          this.Vehicle38 = World.CreateVehicle(this.SC.CheckCar(this.path + Garage + "//Slot38.ini"), this.Vehicle38Loc, 90f);
          this.SC.Load(this.Vehicle38);
          this.Vehicle38.IsDriveable = false;
        }
        this.GarageNum = Garage;
      }
      catch (NullReferenceException ex)
      {
        UI.Notify("~r~ DC&R Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
      }
    }
  }
}
