using GTA;
using GTA.Math;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MethBuisness
{
  public class SafeHouse1 : Script
  {
    public BlipColor Safehouse_Colour;
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    public Color SafehouseMColor;
    public string SafehouseMColorString;
    private ScriptSettings MainConfigFile;
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private MenuPool GarageMenuPool;
    private UIMenu GarageMenu;
    private ScriptSettings Config;
    private ScriptSettings Config2;
    private ScriptSettings Config3;
    private UIMenu ProductStock;
    public Keys Key1;
    public Blip ballasBlip1;
    public Vector3 SafeHouseEnter;
    public Vector3 SafeHouseExit;
    public Vector3 SleepPos;
    public Vector3 StockMenu;
    private UIMenu methgarage;
    public Ped Clay;
    public string Vehiclename;
    public Vector3 GarageLoc;
    public UIMenu Garage;
    public Vector3 Vehicle1Loc = new Vector3(1004.98f, -3159.65f, -40f);
    public Vector3 Vehicle2Loc = new Vector3(1004.98f, -3162.65f, -40f);
    public Vector3 Vehicle3Loc = new Vector3(1000.51f, -3170.82f, -40f);
    public Vector3 Vehicle4Loc = new Vector3(1002.88f, -3170.65f, -40f);
    public Vector3 Vehicle5Loc = new Vector3(1000.51f, -3170.82f, -40f);
    public Vector3 Vehicle6Loc = new Vector3(1002.88f, -3170.65f, -40f);
    public Vector3 Vehicle7Loc = new Vector3(1000.51f, -3170.82f, -40f);
    public Vector3 Vehicle8Loc = new Vector3(1002.88f, -3170.65f, -40f);
    public Vector3 Vehicle9Loc = new Vector3(1000.51f, -3170.82f, -40f);
    public Vector3 Vehicle10Loc = new Vector3(1002.88f, -3170.65f, -40f);
    public Vector3 Vehicle11Loc = new Vector3(1000.51f, -3170.82f, -40f);
    public Vector3 Vehicle12Loc = new Vector3(1002.88f, -3170.65f, -40f);
    public float Vehicle1Rot;
    public float Vehicle2Rot;
    public float Vehicle3Rot;
    public float Vehicle4Rot;
    public float Vehicle5Rot;
    public float Vehicle6Rot;
    public float Vehicle7Rot;
    public float Vehicle8Rot;
    public float Vehicle9Rot;
    public float Vehicle10Rot;
    public float Vehicle11Rot;
    public float Vehicle12Rot;
    public Vehicle Vehicle1;
    public Vehicle Vehicle2;
    public Vehicle Vehicle3;
    public Vehicle Vehicle4;
    public Vehicle Vehicle5;
    public Vehicle Vehicle6;
    public Vehicle Vehicle7;
    public Vehicle Vehicle8;
    public Vehicle Vehicle9;
    public Vehicle Vehicle10;
    public Vehicle Vehicle11;
    public Vehicle Vehicle12;
    public SaveCar SC;
    public string VehicleName;
    public Vector3 GarageMarker = new Vector3(2465.14f, 4102.16f, 37f);
    public Vector3 removeMarker = new Vector3(1012.49f, -3158.18f, -40f);
    private MenuPool RemoveMenuPool;
    private UIMenu RemoveMenu;
    private UIMenu RemovAVehicle;
    public string path = "scripts//HKH191sBusinessMods//MethBusiness//Clubhouse";
    public bool IsInterior;
    private ScriptSettings ScriptConfig;
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
    public bool IsScriptEnabled;
    public List<Blip> ClubhouseBlips = new List<Blip>();
    public Vector3 LastknownPos;
    public Blip GarageEntryBlip;
    public int GarageMarkerOn;
    public Vector3 Sitpos = new Vector3(1005.5f, -3165.7f, -35.5f);
    public Vector3 Sitpos2 = new Vector3(1008f, -3168.09f, -35.5f);
    public bool IsSitting;
    public int stockscount;
    public int stockstimer;
    public bool bought;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public float increaseGain;
    public Vector3 BarMaidLoc = new Vector3(997.9f, -3170.3f, -35.2f);
    public Ped BarMaid;
    public Vector3 BarLoc = new Vector3(996.39f, -3168.149f, -34f);
    public bool isDrinking;
    public float BusinessUpgradeIncreaseGain = 75000f;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    public int CurrentSafehouse;
    public float ChairSitRot1;
    public float ChairSitRot2;
    public float BartenderRot;
    public int ClubhouseChoosen;
    public bool RadioOn;
    public Vector3 RadioPos = new Vector3(2721.3f, -381.3f, -50f);
    public bool PlayRadioMusic;
    public bool RadioMusicOn;
    public string DefaultRadioStation = "1_";
    public int CurrentRadioStation;
    public bool RefreshingRadio;
    public List<string> RadioStat = new List<string>();
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public static Prop Whiskey;
    public static Prop WhiskeyGlass;
    public static Prop Wheat;
    public float DrunkLevel;
    public int DrinkScene;
    public int DrinkType;
    public static Prop Wine;
    public static Prop WineGlass;
    public static Vector3 WinePosition;
    public static Vector3 WineGlassPosition;
    public static Vector3 WineRotation;
    public static Vector3 WineGlassRotation;
    public static int DrunkStage = 1;
    public static int WhiskeyTaskScriptStatus = -1;
    public static int WineTaskScriptStatus = -1;
    public static int WheatTaskScriptStatus = -1;
    public static List<GTA.Model> WineModels = new List<GTA.Model>()
    {
      (GTA.Model) 21833643
    };
    public static List<GTA.Model> WineGlassModels = new List<GTA.Model>()
    {
      (GTA.Model) -35679191
    };
    public static List<GTA.Model> WheatModels = new List<GTA.Model>()
    {
      (GTA.Model) 469594741
    };
    public static List<GTA.Model> WhiskeyModels = new List<GTA.Model>()
    {
      (GTA.Model) 488156118
    };
    public static List<GTA.Model> WhiskeyGlassModels = new List<GTA.Model>()
    {
      (GTA.Model) -1533900808,
      (GTA.Model) 1480049515
    };
    public static Vector3 WhiskeyPosition;
    public static Vector3 WhiskeyGlassPosition;
    public static Vector3 WhiskeyRotation;
    public static Vector3 WhiskeyGlassRotation;
    public static Vector3 WheatPosition;
    public static Vector3 WheatRotation;
    public int DrunkCamTimer;
    public int BottleType;
    public Prop Bottle;
    public Prop Glass;
    public float M = 0.0f;
    public string Price = "000";
    public string Model = "";
    public string man = "";
    public string ListPath = "scripts\\HKH191sBusinessMods\\MethBusiness\\MilitaryTrader\\AllVehicles.ini";
    public UIMenu DrinksMainMenu;
    public UIMenu DrinksMenu;
    public Prop Champaine;
    public bool IsDrinking;
    public int DrinkTimer;
    public List<Prop> Champ = new List<Prop>();
    public int Effect;
    public bool UseOldMarker;

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
        this.CurrentSafehouse = this.MainConfigFile.GetValue<int>("Misc", "CurrentSafehouse", this.CurrentSafehouse);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    private void CheckForScriptEnabled(string iniName, string ClubhouseName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Biker Business", "BikerBusinessMain", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: DisableBusiness.ini Failed To Load.");
      }
    }

    public void MainModRefresh()
    {
      UI.Notify("~g~ Found Refresh Sequence~w~");
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GrapeseedClubhouse");
      bool flag = false;
      if (this.IsScriptEnabled)
      {
        this.LoadMain("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "DelPerroClubHouse");
        if (this.CurrentSafehouse == 0)
        {
          this.SetupMarker(this.GrapeseedClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "DelPerroClubHouse");
        if (this.CurrentSafehouse == 1)
        {
          this.SetupMarker(this.VespucciClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "HowickClubHouse");
        if (this.CurrentSafehouse == 2)
        {
          this.SetupMarker(this.HowikClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "LaMesaClubHouse");
        if (this.CurrentSafehouse == 3)
        {
          this.SetupMarker(this.LaMesaClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse");
        if (this.CurrentSafehouse == 4)
        {
          this.SetupMarker(this.PaletoClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PillboxHillClubHouse");
        if (this.CurrentSafehouse == 5)
        {
          this.SetupMarker(this.PillboxHillClubHouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "RanchoClubHouse");
        if (this.CurrentSafehouse == 6)
        {
          this.SetupMarker(this.RanchoClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "SandyShoresClubHouse");
        if (this.CurrentSafehouse == 7)
        {
          this.SetupMarker(this.SandyShoresClubhouse1);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse2");
        if (this.CurrentSafehouse == 8)
        {
          this.SetupMarker(this.SandyShoresClubhouse2);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VespucciClubHouse");
        if (this.CurrentSafehouse == 9)
        {
          this.SetupMarker(this.DelPerroClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VineWoodClubHouse");
        if (this.CurrentSafehouse == 10)
        {
          this.SetupMarker(this.VinewoodClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GreatChaparral");
        if (this.CurrentSafehouse == 11)
        {
          this.SetupMarker(this.GreatChaparral);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GrapeseedClubhouse");
        if (this.CurrentSafehouse == 0)
        {
          this.SafeHouseEnter = this.GrapeseedClubhouse;
          this.LastknownPos = this.GrapeseedClubhouse;
          this.GarageMarker = new Vector3(2466.14f, 4102.16f, 37f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "DelPerroClubHouse");
        if (this.CurrentSafehouse == 1)
        {
          this.SafeHouseEnter = this.DelPerroClubhouse;
          this.LastknownPos = this.DelPerroClubhouse;
          this.GarageMarker = new Vector3(-1146f, -1579f, 4f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "HowickClubHouse");
        if (this.CurrentSafehouse == 2)
        {
          this.SafeHouseEnter = this.HowikClubhouse;
          this.LastknownPos = this.HowikClubhouse;
          this.GarageMarker = new Vector3(-26.7f, -192.3f, 51.5f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "LaMesaClubHouse");
        if (this.CurrentSafehouse == 3)
        {
          this.SafeHouseEnter = this.LaMesaClubhouse;
          this.LastknownPos = this.LaMesaClubhouse;
          this.GarageMarker = new Vector3(943.1f, -1452.7f, 30.5f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse");
        if (this.CurrentSafehouse == 4)
        {
          this.SafeHouseEnter = this.PaletoClubhouse;
          this.LastknownPos = this.PaletoClubhouse;
          this.GarageMarker = new Vector3(-357f, 6069f, 31f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PillboxHillClubHouse");
        if (this.CurrentSafehouse == 5)
        {
          this.SafeHouseEnter = this.PillboxHillClubHouse;
          this.LastknownPos = this.PillboxHillClubHouse;
          this.GarageMarker = new Vector3(32f, -1032f, 29.4f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "RanchoClubHouse");
        if (this.CurrentSafehouse == 6)
        {
          this.SafeHouseEnter = this.RanchoClubhouse;
          this.LastknownPos = this.RanchoClubhouse;
          this.GarageMarker = new Vector3(257f, -1800f, 27f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "SandyShoresClubHouse");
        if (this.CurrentSafehouse == 7)
        {
          this.SafeHouseEnter = this.SandyShoresClubhouse1;
          this.LastknownPos = this.SandyShoresClubhouse1;
          this.GarageMarker = new Vector3(1728f, 3711f, 33f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse2");
        if (this.CurrentSafehouse == 8)
        {
          this.SafeHouseEnter = this.SandyShoresClubhouse2;
          this.LastknownPos = this.SandyShoresClubhouse2;
          this.GarageMarker = new Vector3(-37.9f, 6414.5f, 30.5f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VespucciClubHouse");
        if (this.CurrentSafehouse == 9)
        {
          this.SafeHouseEnter = this.VespucciClubhouse;
          this.LastknownPos = this.VespucciClubhouse;
          this.GarageMarker = new Vector3(-1467f, -925f, 9f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VineWoodClubHouse");
        if (this.CurrentSafehouse == 10)
        {
          this.SafeHouseEnter = this.VinewoodClubhouse;
          this.LastknownPos = this.VinewoodClubhouse;
          this.GarageMarker = new Vector3(178.6f, 301.1f, 104.5f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GreatChaparral");
        if (this.CurrentSafehouse == 11)
        {
          this.SafeHouseEnter = this.GreatChaparral;
          this.LastknownPos = this.GreatChaparral;
          this.GarageMarker = new Vector3(62.9f, 2795.7f, 56.5f);
        }
      }
      this.GetLocation();
      if (this.purchaselvl >= 1)
      {
        this.ballasBlip1.Color = this.Safehouse_Colour;
        this.ballasBlip1.Alpha = (int) byte.MaxValue;
      }
      if (this.purchaselvl != 0)
        return;
      this.ballasBlip1.Color = BlipColor.White;
      this.ballasBlip1.Alpha = 0;
    }

    public void GetLocation()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
      if (this.ClubhouseChoosen == 1)
      {
        this.SafeHouseExit = new Vector3(1004.71f, -3154.16f, -40f);
        this.SleepPos = new Vector3(1009.89f, -3170.97f, -38f);
        this.Sitpos = new Vector3(1005.5f, -3165.7f, -35.5f);
        this.Sitpos2 = new Vector3(1008f, -3168.09f, -35.5f);
        this.BarMaidLoc = new Vector3(997.9f, -3170.3f, -35.2f);
        this.BarLoc = new Vector3(996.39f, -3168.149f, -34f);
        this.Vehicle1Rot = 140f;
        this.Vehicle2Rot = 144f;
        this.Vehicle3Rot = 145f;
        this.Vehicle4Rot = 144f;
        this.Vehicle5Rot = 144f;
        this.Vehicle6Rot = 40f;
        this.Vehicle7Rot = 40f;
        this.Vehicle8Rot = 40f;
        this.Vehicle9Rot = 40f;
        this.Vehicle10Rot = 40f;
        this.Vehicle11Rot = 0.0f;
        this.Vehicle12Rot = 0.0f;
        this.Vehicle1Loc = new Vector3(1008.32f, -3159.5f, -40f);
        this.Vehicle2Loc = new Vector3(1006.16f, -3159.39f, -40f);
        this.Vehicle3Loc = new Vector3(1004.177f, -3159.22f, -40f);
        this.Vehicle4Loc = new Vector3(1002.027f, -3159.25f, -40f);
        this.Vehicle5Loc = new Vector3(1000.207f, -3159.135f, -40f);
        this.Vehicle6Loc = new Vector3(1007.9f, -3162.6f, -40f);
        this.Vehicle7Loc = new Vector3(1005.9f, -3162.5f, -40f);
        this.Vehicle8Loc = new Vector3(1004.12f, -3162.41f, -40f);
        this.Vehicle9Loc = new Vector3(1002.3f, -3162.47f, -40f);
        this.Vehicle10Loc = new Vector3(1000.2f, -3162.35f, -40f);
        this.Vehicle11Loc = new Vector3(1000.51f, -3170.82f, -40f);
        this.Vehicle12Loc = new Vector3(1002.88f, -3170.65f, -40f);
        this.ChairSitRot1 = -90f;
        this.ChairSitRot2 = 0.0f;
        this.BartenderRot = 0.0f;
        this.removeMarker = new Vector3(1012.49f, -3158.18f, -40f);
        this.RadioPos = new Vector3(1001.119f, -3170.21f, -34.9f);
      }
      if (this.ClubhouseChoosen != 2)
        return;
      this.SafeHouseExit = new Vector3(1111.8f, -3166.66f, -38.5f);
      this.SleepPos = new Vector3(1119.9f, -3162.5f, -36f);
      this.Sitpos = new Vector3(1125.4f, -3144.34f, -38.6f);
      this.Sitpos2 = new Vector3(1114.4f, -3150.7f, -38.6f);
      this.BarMaidLoc = new Vector3(1121.1f, -3144.1f, -38.2f);
      this.BarLoc = new Vector3(1122.5f, -3144.1f, -37.5f);
      this.Vehicle1Rot = -117f;
      this.Vehicle2Rot = -117f;
      this.Vehicle3Rot = -121f;
      this.Vehicle4Rot = -112f;
      this.Vehicle5Rot = -140f;
      this.Vehicle6Rot = 126f;
      this.Vehicle7Rot = 122f;
      this.Vehicle8Rot = 115f;
      this.Vehicle9Rot = 106f;
      this.Vehicle10Rot = 110f;
      this.Vehicle11Rot = 0.0f;
      this.Vehicle12Rot = -89f;
      this.Vehicle1Loc = new Vector3(1099.25f, -3142.59f, -38.5f);
      this.Vehicle2Loc = new Vector3(1099.245f, -3144.522f, -38.5f);
      this.Vehicle3Loc = new Vector3(1099.32f, -3146.45f, -38.5f);
      this.Vehicle4Loc = new Vector3(1099.249f, -3148.42f, -38.5f);
      this.Vehicle5Loc = new Vector3(1098.929f, -3150.045f, -38.5f);
      this.Vehicle6Loc = new Vector3(1102.561f, -3142.525f, -38.5f);
      this.Vehicle7Loc = new Vector3(1103.732f, -3144.066f, -38.5f);
      this.Vehicle8Loc = new Vector3(1103.856f, -3145.718f, -38.5f);
      this.Vehicle9Loc = new Vector3(1103.68f, -3148.077f, -38.5f);
      this.Vehicle10Loc = new Vector3(1103.377f, -3150.186f, -38.5f);
      this.Vehicle11Loc = new Vector3(1108.9f, -3163.39f, -39f);
      this.Vehicle12Loc = new Vector3(1101.9f, -3157.013f, -39f);
      this.ChairSitRot1 = 90f;
      this.ChairSitRot2 = -90f;
      this.BartenderRot = -90f;
      this.removeMarker = new Vector3(1102.6f, -3152.9f, -39.1f);
      this.RadioPos = new Vector3(1122.5f, -3151.9f, -37.9f);
    }

    public void MainModDestroy()
    {
      foreach (Blip clubhouseBlip in this.ClubhouseBlips)
      {
        if (clubhouseBlip != (Blip) null)
          clubhouseBlip.Remove();
      }
    }

    public SafeHouse1()
    {
      this.LoadMain("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      bool flag = false;
      foreach (Blip clubhouseBlip in this.ClubhouseBlips)
      {
        if (clubhouseBlip != (Blip) null)
          clubhouseBlip.Remove();
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", nameof (GrapeseedClubhouse));
      if (!this.IsScriptEnabled)
        return;
      if (this.CurrentSafehouse == 0)
      {
        this.SetupMarker(this.GrapeseedClubhouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "DelPerroClubHouse");
      if (this.CurrentSafehouse == 1)
      {
        this.SetupMarker(this.VespucciClubhouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "HowickClubHouse");
      if (this.CurrentSafehouse == 2)
      {
        this.SetupMarker(this.HowikClubhouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "LaMesaClubHouse");
      if (this.CurrentSafehouse == 3)
      {
        this.SetupMarker(this.LaMesaClubhouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse");
      if (this.CurrentSafehouse == 4)
      {
        this.SetupMarker(this.PaletoClubhouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", nameof (PillboxHillClubHouse));
      if (this.CurrentSafehouse == 5)
      {
        this.SetupMarker(this.PillboxHillClubHouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "RanchoClubHouse");
      if (this.CurrentSafehouse == 6)
      {
        this.SetupMarker(this.RanchoClubhouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "SandyShoresClubHouse");
      if (this.CurrentSafehouse == 7)
      {
        this.SetupMarker(this.SandyShoresClubhouse1);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse2");
      if (this.CurrentSafehouse == 8)
      {
        this.SetupMarker(this.SandyShoresClubhouse2);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VespucciClubHouse");
      if (this.CurrentSafehouse == 9)
      {
        this.SetupMarker(this.DelPerroClubhouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VineWoodClubHouse");
      if (this.CurrentSafehouse == 10)
      {
        this.SetupMarker(this.VinewoodClubhouse);
        flag = true;
      }
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", nameof (GreatChaparral));
      if (this.CurrentSafehouse == 11)
      {
        this.SetupMarker(this.GreatChaparral);
        flag = true;
      }
      if (flag)
      {
        this.SC = new SaveCar();
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        this.CreateBanner();
        this.Setup();
        this.Tick += new EventHandler(this.OnTick);
        this.Aborted += new EventHandler(this.OnShutdown);
        this.Interval = 1;
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
      this.GarageMarkerOn = 0;
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Biker Safehouse", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.DrinksMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Drinks");
      this.GUIMenus.Add(this.DrinksMenu);
      this.RemoveMenuPool = new MenuPool();
      this.GarageMenuPool = new MenuPool();
      this.GarageMenu = new UIMenu("Garage", "Select an Option");
      this.GUIMenus.Add(this.GarageMenu);
      this.GarageMenuPool.Add(this.GarageMenu);
      this.RemoveMenu = new UIMenu("Garage", "Remove A vehicle");
      this.GUIMenus.Add(this.RemoveMenu);
      this.RemoveMenuPool.Add(this.RemoveMenu);
      this.RemovAVehicle = this.RemoveMenuPool.AddSubMenu(this.RemoveMenu, "Options");
      this.GUIMenus.Add(this.RemovAVehicle);
      this.SafeHouseEnter = new Vector3(0.0f, 0.0f, 0.0f);
      this.GetLocation();
      this.SetupGarage();
      this.AddRatioStations();
      this.RemoveAvehicle();
      this.Drinks();
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    private void SetupProduct()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.ProductStock, "Buy/Sell Product");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Buy2 = new UIMenuItem("Buy X10: +250000");
      uiMenu.AddItem(Buy2);
      UIMenuItem Buy = new UIMenuItem("Buy X1: +25000");
      uiMenu.AddItem(Buy);
      UIMenuItem Sell = new UIMenuItem("Sell - All Stocks");
      uiMenu.AddItem(Sell);
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
        if (item != Sell)
          return;
        UI.Notify(this.GetHostName() + " ok i can deal with that, selling all product avalable");
        Game.Player.Money += (int) this.stocksvalue;
        this.stocksvalue = 0.0f;
        this.stockscount = 0;
        this.Config.SetValue<int>("Setup", "stockslevel", this.stockscount);
        this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.Config.Save();
      });
    }

    public void WhiskeyMethod()
    {
      try
      {
        switch (SafeHouse1.WhiskeyTaskScriptStatus)
        {
          case 0:
            this.Bottle.IsVisible = false;
            this.Glass.IsVisible = false;
            SafeHouse1.WhiskeyTaskScriptStatus = 1;
            break;
          case 1:
            SafeHouse1.Whiskey = this.Bottle;
            SafeHouse1.WhiskeyGlass = this.Glass;
            SafeHouse1.WhiskeyPosition = SafeHouse1.Whiskey.Position;
            SafeHouse1.WhiskeyRotation = SafeHouse1.Whiskey.Rotation;
            SafeHouse1.WhiskeyTaskScriptStatus = 2;
            break;
          case 2:
            Game.Player.Character.Task.PlayAnimation("mp_safehousewhiskey@", "enter", 2f, 15500, false, -1f);
            Script.Wait(1500);
            this.Bottle.IsVisible = true;
            if (this.BottleType == 0)
              SafeHouse1.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            if (this.BottleType == 1)
              SafeHouse1.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            else if (this.BottleType == 2)
              SafeHouse1.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            else if (this.BottleType == 3)
              SafeHouse1.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            else if (this.BottleType == 4)
              SafeHouse1.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            else
              SafeHouse1.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            SafeHouse1.WhiskeyTaskScriptStatus = 3;
            break;
          case 3:
            if (SafeHouse1.Whiskey.IsAttachedTo((Entity) Game.Player.Character))
            {
              Script.Wait(2000);
              SafeHouse1.WhiskeyGlass.Position = SafeHouse1.Whiskey.GetOffsetInWorldCoords(new Vector3(0.0f, 0.2f, 0.0f));
              SafeHouse1.WhiskeyGlass.IsVisible = true;
              SafeHouse1.WhiskeyGlassPosition = SafeHouse1.WhiskeyGlass.Position;
              SafeHouse1.WhiskeyGlassRotation = SafeHouse1.WhiskeyGlass.Rotation;
              Script.Wait(1000);
              SafeHouse1.WhiskeyGlass.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.IK_L_Hand), new Vector3(0.1f, 0.0f, 0.04f), new Vector3(-100f, 10f, 0.0f));
              Script.Wait(2000);
              SafeHouse1.Whiskey.Detach();
              SafeHouse1.Whiskey.Position = SafeHouse1.WhiskeyPosition;
              SafeHouse1.Whiskey.Rotation = SafeHouse1.WhiskeyRotation;
              SafeHouse1.WhiskeyTaskScriptStatus = 4;
              SafeHouse1.Whiskey.IsVisible = false;
              break;
            }
            break;
          case 4:
            if (SafeHouse1.WhiskeyGlass.IsAttachedTo((Entity) Game.Player.Character))
            {
              Script.Wait(4000);
              SafeHouse1.WhiskeyGlass.Detach();
              SafeHouse1.WhiskeyGlass.Position = SafeHouse1.WhiskeyGlassPosition;
              SafeHouse1.WhiskeyGlass.Rotation = SafeHouse1.WhiskeyGlassRotation;
              SafeHouse1.WhiskeyTaskScriptStatus = 5;
              this.DrunkLevel += 2f;
              break;
            }
            break;
          case 5:
            if (SafeHouse1.DrunkStage == 1)
              ++SafeHouse1.DrunkStage;
            SafeHouse1.WhiskeyTaskScriptStatus = -1;
            this.Bottle.Delete();
            this.Glass.Delete();
            break;
        }
        if (!Game.Player.IsDead && !Game.Player.Character.IsRagdoll)
          return;
        SafeHouse1.Whiskey.Detach();
        SafeHouse1.WhiskeyGlass.Detach();
        SafeHouse1.Whiskey.Position = SafeHouse1.WhiskeyPosition;
        SafeHouse1.Whiskey.Rotation = SafeHouse1.WhiskeyRotation;
        SafeHouse1.WhiskeyGlass.Position = SafeHouse1.WhiskeyGlassPosition;
        SafeHouse1.WhiskeyGlass.Rotation = SafeHouse1.WhiskeyGlassRotation;
        SafeHouse1.WhiskeyTaskScriptStatus = -1;
      }
      catch (Exception ex)
      {
      }
    }

    public void WineMethod()
    {
      try
      {
        Ped character = Game.Player.Character;
        switch (SafeHouse1.WineTaskScriptStatus)
        {
          case 0:
            this.Bottle.IsVisible = false;
            this.Glass.IsVisible = false;
            SafeHouse1.Wine = this.Bottle;
            SafeHouse1.WineGlass = this.Glass;
            SafeHouse1.WineTaskScriptStatus = 1;
            break;
          case 1:
            SafeHouse1.WinePosition = SafeHouse1.Wine.Position;
            SafeHouse1.WineRotation = SafeHouse1.Wine.Rotation;
            SafeHouse1.WineTaskScriptStatus = 2;
            break;
          case 2:
            Game.Player.Character.Task.PlayAnimation("mp_safehousewine@", "drinking_wine", 2f, 15500, false, -1f);
            Script.Wait(1000);
            this.Bottle.IsVisible = true;
            SafeHouse1.Wine.AttachTo((Entity) character, character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.13f, 0.05f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            SafeHouse1.WineTaskScriptStatus = 3;
            break;
          case 3:
            if (SafeHouse1.Wine.IsAttachedTo((Entity) character))
            {
              SafeHouse1.WineGlassPosition = SafeHouse1.WineGlass.Position;
              SafeHouse1.WineGlassRotation = SafeHouse1.WineGlass.Rotation;
              Script.Wait(500);
              this.Glass.IsVisible = true;
              SafeHouse1.WineGlass.AttachTo((Entity) character, character.GetBoneIndex(Bone.PH_L_Hand), new Vector3(0.1f, 0.0f, 0.04f), new Vector3(-100f, 10f, 0.0f));
              SafeHouse1.WineTaskScriptStatus = 4;
              ++this.DrunkLevel;
              break;
            }
            break;
          case 4:
            if (SafeHouse1.WineGlass.IsAttachedTo((Entity) character))
            {
              Script.Wait(5000);
              SafeHouse1.Wine.Detach();
              this.Bottle.IsVisible = false;
              SafeHouse1.Wine.Position = SafeHouse1.WinePosition;
              SafeHouse1.Wine.Rotation = SafeHouse1.WineRotation;
              Script.Wait(9000);
              this.Glass.IsVisible = false;
              SafeHouse1.WineGlass.Detach();
              SafeHouse1.WineGlass.Position = SafeHouse1.WineGlassPosition;
              SafeHouse1.WineGlass.Rotation = SafeHouse1.WineGlassRotation;
              SafeHouse1.WineTaskScriptStatus = 5;
              break;
            }
            break;
          case 5:
            SafeHouse1.WineTaskScriptStatus = -1;
            break;
        }
        if (!Game.Player.IsDead && !Game.Player.Character.IsRagdoll)
          return;
        SafeHouse1.Wine.Detach();
        SafeHouse1.WineGlass.Detach();
        SafeHouse1.Wine.Position = SafeHouse1.WinePosition;
        SafeHouse1.Wine.Rotation = SafeHouse1.WineRotation;
        SafeHouse1.WineGlass.Position = SafeHouse1.WineGlassPosition;
        SafeHouse1.WineGlass.Rotation = SafeHouse1.WineGlassRotation;
        SafeHouse1.WineTaskScriptStatus = -1;
      }
      catch
      {
      }
    }

    public void Drinks()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.DrinksMenu, nameof (Drinks));
      this.GUIMenus.Add(uiMenu);
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
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 5f, 4500, AnimationFlags.UpperBodyOnly, 0.0f);
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
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
            this.DrunkLevel += 5f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
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
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 5f, 4500, AnimationFlags.UpperBodyOnly, 0.0f);
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
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
            this.DrunkLevel += 5f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
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
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 5f, 4500, AnimationFlags.UpperBodyOnly, 0.0f);
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
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
            this.DrunkLevel += 5f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkE)
        {
          if (Game.Player.Money >= 5000)
          {
            SafeHouse1.WineTaskScriptStatus = 0;
            SafeHouse1.WhiskeyTaskScriptStatus = 0;
            Game.Player.Money -= 5000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            SafeHouse1.WhiskeyTaskScriptStatus = 0;
            this.Bottle = this.Champaine;
            this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
            this.IsDrinking = true;
            this.Effect = 3;
            this.modMenuPool.CloseAllMenus();
            this.BottleType = 1;
            this.DrunkLevel += 9f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify(" : You do not have enough money for this Drink!");
        }
        if (item == DrinkD)
        {
          if (Game.Player.Money >= 1000)
          {
            SafeHouse1.WineTaskScriptStatus = 0;
            SafeHouse1.WhiskeyTaskScriptStatus = 0;
            Game.Player.Money -= 1000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            SafeHouse1.WhiskeyTaskScriptStatus = 0;
            this.Bottle = this.Champaine;
            this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
            this.IsDrinking = true;
            this.Effect = 3;
            this.modMenuPool.CloseAllMenus();
            this.DrunkLevel += 12f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkC)
        {
          if (Game.Player.Money >= 250)
          {
            SafeHouse1.WineTaskScriptStatus = 0;
            SafeHouse1.WhiskeyTaskScriptStatus = 0;
            Game.Player.Money -= 250;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            SafeHouse1.WhiskeyTaskScriptStatus = 0;
            this.Bottle = this.Champaine;
            this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
            this.IsDrinking = true;
            this.Effect = 1;
            this.BottleType = 1;
            this.modMenuPool.CloseAllMenus();
            this.DrunkLevel += 14f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkB)
        {
          if (Game.Player.Money >= 75)
          {
            SafeHouse1.WineTaskScriptStatus = 0;
            SafeHouse1.WhiskeyTaskScriptStatus = 0;
            Game.Player.Money -= 75;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_vodka_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            SafeHouse1.WhiskeyTaskScriptStatus = 0;
            this.Bottle = this.Champaine;
            this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
            this.IsDrinking = true;
            this.Effect = 0;
            this.modMenuPool.CloseAllMenus();
            this.DrunkLevel += 16f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item != DrinkA)
          return;
        if (Game.Player.Money >= 25)
        {
          SafeHouse1.WineTaskScriptStatus = 0;
          SafeHouse1.WhiskeyTaskScriptStatus = 0;
          Game.Player.Money -= 25;
          Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
          Prop prop = World.CreateProp(this.RequestModel("prop_sh_beer_pissh_01"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
          prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
          this.Champaine = prop;
          this.Champ.Add(prop);
          SafeHouse1.WhiskeyTaskScriptStatus = 0;
          this.Bottle = this.Champaine;
          this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
          this.IsDrinking = true;
          this.Effect = 0;
          this.modMenuPool.CloseAllMenus();
          this.DrunkLevel += 6f;
          if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
          {
            Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
            Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          }
          if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
          {
            Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
            Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          }
          if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
          {
            Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
            Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          }
        }
        else
          UI.Notify("You do not have enough money for this Drink!");
      });
    }

    private void RemoveAvehicle()
    {
      List<object> objectList1 = new List<object>();
      foreach (int num in (VehicleHash[]) Enum.GetValues(typeof (VehicleHash)))
        objectList1.Add((object) (VehicleHash) num);
      List<object> objectList2 = new List<object>();
      foreach (int num in (VehicleColor[]) Enum.GetValues(typeof (VehicleColor)))
        objectList2.Add((object) (VehicleColor) num);
      List<object> LogList = new List<object>();
      string[] logFile = File.ReadAllLines(this.ListPath);
      foreach (string str in logFile)
        LogList.Add((object) str);
      this.LoadIniFile(this.ListPath);
      List<object> objectList3 = new List<object>()
      {
        (object) "NULL",
        (object) "NULL",
        (object) "NULL",
        (object) "NULL",
        (object) "NULL",
        (object) "NULL"
      };
      List<object> listofSlots = new List<object>();
      listofSlots.Add((object) "Slot1");
      listofSlots.Add((object) "Slot2");
      listofSlots.Add((object) "Slot3");
      listofSlots.Add((object) "Slot4");
      listofSlots.Add((object) "Slot5");
      listofSlots.Add((object) "Slot6");
      listofSlots.Add((object) "Slot7");
      listofSlots.Add((object) "Slot8");
      listofSlots.Add((object) "Slot9");
      listofSlots.Add((object) "Slot10");
      listofSlots.Add((object) "Slot11");
      listofSlots.Add((object) "Slot12");
      UIMenu uiMenu1 = this.RemoveMenuPool.AddSubMenu(this.RemovAVehicle, "Request A New vehicle in Slot");
      this.GUIMenus.Add(uiMenu1);
      UIMenuItem uiMenuItem1 = new UIMenuItem("------------------Reset List-----------------------------");
      uiMenu1.AddItem(uiMenuItem1);
      UIMenuItem ResetL = new UIMenuItem("Reset Vehicle List");
      uiMenu1.AddItem(ResetL);
      UIMenuItem uiMenuItem2 = new UIMenuItem("------------------Search Method 1--------------------------");
      uiMenu1.AddItem(uiMenuItem2);
      UIMenuListItem Ve = new UIMenuListItem("Vehicle : ", LogList, 0);
      uiMenu1.AddItem((UIMenuItem) Ve);
      UIMenuItem VDName = new UIMenuItem("Vehicle Spawn Name  : Dukes2");
      uiMenu1.AddItem(VDName);
      UIMenuItem VName = new UIMenuItem("Vehicle Full Name  : Imponte Dukes");
      uiMenu1.AddItem(VName);
      UIMenuItem uiMenuItem3 = new UIMenuItem("------------------Search Method 2--------------------------");
      uiMenu1.AddItem(uiMenuItem3);
      UIMenuItem Search = new UIMenuItem("Enter Vehicle Name");
      uiMenu1.AddItem(Search);
      UIMenuItem uiMenuItem4 = new UIMenuItem("Search Term  : NULL");
      uiMenu1.AddItem(uiMenuItem4);
      UIMenuItem uiMenuItem5 = new UIMenuItem("Vehicle Spawn Name  : NULL");
      uiMenu1.AddItem(uiMenuItem5);
      UIMenuItem uiMenuItem6 = new UIMenuItem("Vehicle Full Name  : NULL");
      uiMenu1.AddItem(uiMenuItem6);
      UIMenuItem uiMenuItem7 = new UIMenuItem("------------------Purchase Vehicle--------------------------");
      uiMenu1.AddItem(uiMenuItem7);
      UIMenuItem PuchaseV = new UIMenuItem("Purchase Vehicle : $0");
      uiMenu1.AddItem(PuchaseV);
      UIMenuListItem ListSlot = new UIMenuListItem("Slot  : ", listofSlots, 0);
      uiMenu1.AddItem((UIMenuItem) ListSlot);
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item != Ve)
          return;
        try
        {
          string[] separator = new string[2]{ " = ", "," };
          // ISSUE: reference to a compiler-generated field
          if (SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SafeHouse1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string[] strArray = SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__0.Target((CallSite) SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__0, LogList[Ve.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
      });
      string SearchTerm;
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == ResetL)
        {
          if (LogList.Count > 0)
            LogList.Clear();
          logFile = File.ReadAllLines(this.ListPath);
          foreach (object obj in logFile)
            LogList.Add(obj);
          UI.Notify("Clay Reset Vehicle List");
        }
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
                if (SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__1 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SafeHouse1)));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                string[] strArray = SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__1.Target((CallSite) SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__1, LogList[Ve.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
              if (SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__2 == null)
              {
                // ISSUE: reference to a compiler-generated field
                SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SafeHouse1)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              string[] strArray = SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__2.Target((CallSite) SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__2, LogList[Ve.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
        if (item != PuchaseV)
          ;
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != PuchaseV)
          return;
        if ((double) Game.Player.Money > (double) this.M)
        {
          // ISSUE: reference to a compiler-generated field
          if (SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SafeHouse1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string[] strArray = SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__3.Target((CallSite) SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__3, LogList[Ve.Index]).Split(new string[2]
          {
            " = ",
            ","
          }, StringSplitOptions.RemoveEmptyEntries);
          for (int index1 = 0; index1 < strArray.Length; ++index1)
          {
            this.Price = strArray[1];
            this.Model = strArray[2];
            this.man = strArray[0];
            VDName.Text = "Vehicle Spawn Name : " + this.Model;
            VName.Text = "Vehicle Full Name  : " + this.man;
            PuchaseV.Text = "Purchase Vehicle : " + this.Price;
          }
          Game.Player.Money -= int.Parse(this.Price);
          string man = this.man;
          // ISSUE: reference to a compiler-generated field
          if (SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SafeHouse1)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string str = SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__4.Target((CallSite) SafeHouse1.\u003C\u003Eo__179.\u003C\u003Ep__4, listofSlots[ListSlot.Index]);
          if (str.Equals("Slot1"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle1 != (Entity) null)
                this.Vehicle1.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot1.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle1 = World.CreateVehicle(this.RequestModel(man), this.Vehicle1Loc, this.Vehicle1Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle1, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot1.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle1, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle1.IsDriveable = true;
              this.Vehicle1.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot2"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle2 != (Entity) null)
                this.Vehicle2.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot2.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle2 = World.CreateVehicle(this.RequestModel(man), this.Vehicle2Loc, this.Vehicle2Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle2, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot2.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle2, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle2.IsDriveable = true;
              this.Vehicle2.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot3"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle3 != (Entity) null)
                this.Vehicle3.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot3.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle3 = World.CreateVehicle(this.RequestModel(man), this.Vehicle3Loc, this.Vehicle3Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle3, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot3.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle3, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle3.IsDriveable = true;
              this.Vehicle3.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot4"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle4 != (Entity) null)
                this.Vehicle4.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot4.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle4 = World.CreateVehicle(this.RequestModel(man), this.Vehicle4Loc, this.Vehicle4Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle4, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot4.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle4, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle4.IsDriveable = true;
              this.Vehicle4.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot5"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle5 != (Entity) null)
                this.Vehicle5.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot5.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle5 = World.CreateVehicle(this.RequestModel(man), this.Vehicle5Loc, this.Vehicle5Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle5, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot5.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle5, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle5.IsDriveable = true;
              this.Vehicle5.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot6"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle6 != (Entity) null)
                this.Vehicle6.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot6.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle6 = World.CreateVehicle(this.RequestModel(man), this.Vehicle6Loc, this.Vehicle6Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle6, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot6.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle6, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle6.IsDriveable = true;
              this.Vehicle6.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot7"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle7 != (Entity) null)
                this.Vehicle7.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot7.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle7 = World.CreateVehicle(this.RequestModel(man), this.Vehicle7Loc, this.Vehicle7Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle7, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot7.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle7, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle7.IsDriveable = true;
              this.Vehicle7.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot8"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle8 != (Entity) null)
                this.Vehicle8.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot8.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle8 = World.CreateVehicle(this.RequestModel(man), this.Vehicle8Loc, this.Vehicle8Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle8, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot8.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle8, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle8.IsDriveable = true;
              this.Vehicle8.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot9"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle9 != (Entity) null)
                this.Vehicle9.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot9.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle9 = World.CreateVehicle(this.RequestModel(man), this.Vehicle9Loc, this.Vehicle9Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle9, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot9.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle9, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle9.IsDriveable = true;
              this.Vehicle9.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot10"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle10 != (Entity) null)
                this.Vehicle10.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot10.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle10 = World.CreateVehicle(this.RequestModel(man), this.Vehicle10Loc, this.Vehicle10Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle10, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot10.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle10, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle10.IsDriveable = true;
              this.Vehicle10.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          if (str.Equals("Slot11"))
          {
            if ((Entity) this.Vehicle11 != (Entity) null)
              this.Vehicle11.Delete();
            this.SC.LoadIniFile(this.path + "//Garage//Slot11.ini");
            Vector3 position = Game.Player.Character.Position;
            this.SC.Save();
            this.Vehicle11 = World.CreateVehicle(this.RequestModel(man), this.Vehicle11Loc, this.Vehicle11Rot);
            Game.Player.Character.SetIntoVehicle(this.Vehicle11, VehicleSeat.Driver);
            this.SC.LoadIniFile(this.path + "//Garage//Slot11.ini");
            this.SC.SaveWithoutDelete();
            Game.Player.Character.Task.LeaveVehicle(this.Vehicle11, LeaveVehicleFlags.WarpOut);
            Game.Player.Character.Position = position;
            this.Vehicle11.IsDriveable = true;
            this.Vehicle11.FreezePosition = false;
          }
          if (str.Equals("Slot12"))
          {
            if (this.CheckifBike(this.man))
            {
              if ((Entity) this.Vehicle12 != (Entity) null)
                this.Vehicle12.Delete();
              this.SC.LoadIniFile(this.path + "//Garage//Slot12.ini");
              Vector3 position = Game.Player.Character.Position;
              this.SC.Save();
              this.Vehicle12 = World.CreateVehicle(this.RequestModel(man), this.Vehicle12Loc, this.Vehicle12Rot);
              Game.Player.Character.SetIntoVehicle(this.Vehicle12, VehicleSeat.Driver);
              this.SC.LoadIniFile(this.path + "//Garage//Slot12.ini");
              this.SC.SaveWithoutDelete();
              Game.Player.Character.Task.LeaveVehicle(this.Vehicle12, LeaveVehicleFlags.WarpOut);
              Game.Player.Character.Position = position;
              this.Vehicle12.IsDriveable = true;
              this.Vehicle12.FreezePosition = false;
            }
            else
              UI.Notify(this.GetHostName() + "  You can only have a bike in this Slot!");
          }
          logFile = File.ReadAllLines(this.ListPath);
          foreach (object obj in logFile)
            LogList.Add(obj);
        }
        else
          UI.Notify(this.GetHostName() + "  You do not have enought money to purchase this vehicle!");
      });
      UIMenu uiMenu2 = this.RemoveMenuPool.AddSubMenu(this.RemovAVehicle, "Remove A vehicle in Slot");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem Slot1 = new UIMenuItem("Remove Slot 1 ");
      uiMenu2.AddItem(Slot1);
      UIMenuItem Slot2 = new UIMenuItem("Remove Slot 2 ");
      uiMenu2.AddItem(Slot2);
      UIMenuItem Slot3 = new UIMenuItem("Remove Slot 3 ");
      uiMenu2.AddItem(Slot3);
      UIMenuItem Slot4 = new UIMenuItem("Remove Slot 4 ");
      uiMenu2.AddItem(Slot4);
      UIMenuItem Slot5 = new UIMenuItem("Remove Slot 5 ");
      uiMenu2.AddItem(Slot5);
      UIMenuItem Slot6 = new UIMenuItem("Remove Slot 6 ");
      uiMenu2.AddItem(Slot6);
      UIMenuItem Slot7 = new UIMenuItem("Remove Slot 7 ");
      uiMenu2.AddItem(Slot7);
      UIMenuItem Slot8 = new UIMenuItem("Remove Slot 8 ");
      uiMenu2.AddItem(Slot8);
      UIMenuItem Slot9 = new UIMenuItem("Remove Slot 9 ");
      uiMenu2.AddItem(Slot9);
      UIMenuItem Slot10 = new UIMenuItem("Remove Slot 10 ");
      uiMenu2.AddItem(Slot10);
      UIMenuItem Slot11 = new UIMenuItem("Remove Slot 11 ");
      uiMenu2.AddItem(Slot11);
      UIMenuItem Slot12 = new UIMenuItem("Remove Slot 12 ");
      uiMenu2.AddItem(Slot12);
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Slot1)
        {
          if ((Entity) this.Vehicle1 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot1.ini");
            this.SC.SaveName("null");
            this.Vehicle1.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 1 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 1");
        }
        if (item == Slot2)
        {
          if ((Entity) this.Vehicle2 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot2.ini");
            this.SC.SaveName("null");
            this.Vehicle2.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 2 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 2");
        }
        if (item == Slot3)
        {
          if ((Entity) this.Vehicle3 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot3.ini");
            this.SC.SaveName("null");
            this.Vehicle3.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 3 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 3");
        }
        if (item == Slot4)
        {
          if ((Entity) this.Vehicle4 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot4.ini");
            this.SC.SaveName("null");
            this.SC.Delete();
            this.Vehicle4.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 4 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 4");
        }
        if (item == Slot5)
        {
          if ((Entity) this.Vehicle5 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot5.ini");
            this.SC.SaveName("null");
            this.Vehicle5.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 5 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 5");
        }
        if (item == Slot6)
        {
          if ((Entity) this.Vehicle6 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot6.ini");
            this.SC.SaveName("null");
            this.Vehicle6.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 6 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 6");
        }
        if (item == Slot7)
        {
          if ((Entity) this.Vehicle7 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot7.ini");
            this.SC.SaveName("null");
            this.Vehicle7.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 7 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 7");
        }
        if (item == Slot8)
        {
          if ((Entity) this.Vehicle8 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot8.ini");
            this.SC.SaveName("null");
            this.Vehicle8.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 8 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 8");
        }
        if (item == Slot9)
        {
          if ((Entity) this.Vehicle9 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot9.ini");
            this.SC.SaveName("null");
            this.Vehicle9.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 9 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 9");
        }
        if (item == Slot10)
        {
          if ((Entity) this.Vehicle10 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot10.ini");
            this.SC.SaveName("null");
            this.Vehicle10.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 10 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 10");
        }
        if (item == Slot11)
        {
          if ((Entity) this.Vehicle11 != (Entity) null)
          {
            this.SC.LoadIniFile(this.path + "//Garage//Slot11.ini");
            this.SC.SaveName("null");
            this.Vehicle11.Delete();
            UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 11 has been removed");
          }
          else
            UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 11");
        }
        if (item != Slot12)
          return;
        if ((Entity) this.Vehicle12 != (Entity) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot12.ini");
          this.SC.SaveName("null");
          this.Vehicle12.Delete();
          UI.Notify(this.GetHostName() + " Ok Vehicle in Slot 12 has been removed");
        }
        else
          UI.Notify(this.GetHostName() + " There is no vehicle ins Slot 12");
      });
    }

    private void SetupGarage()
    {
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.GarageMenu, "Save Current Vehicle");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem Slot1 = new UIMenuItem("Slot 1 (Bike)");
      uiMenu.AddItem(Slot1);
      UIMenuItem Slot2 = new UIMenuItem("Slot 2 (Bike)");
      uiMenu.AddItem(Slot2);
      UIMenuItem Slot3 = new UIMenuItem("Slot 3 (Bike)");
      uiMenu.AddItem(Slot3);
      UIMenuItem Slot4 = new UIMenuItem("Slot 4 (Bike)");
      uiMenu.AddItem(Slot4);
      UIMenuItem Slot5 = new UIMenuItem("Slot 5 (Bike)");
      uiMenu.AddItem(Slot5);
      UIMenuItem Slot6 = new UIMenuItem("Slot 6 (Bike)");
      uiMenu.AddItem(Slot6);
      UIMenuItem Slot7 = new UIMenuItem("Slot 7 (Bike)");
      uiMenu.AddItem(Slot7);
      UIMenuItem Slot8 = new UIMenuItem("Slot 8 (Bike)");
      uiMenu.AddItem(Slot8);
      UIMenuItem Slot9 = new UIMenuItem("Slot 9 (Bike)");
      uiMenu.AddItem(Slot9);
      UIMenuItem Slot10 = new UIMenuItem("Slot 10 (Bike)");
      uiMenu.AddItem(Slot10);
      UIMenuItem Slot11 = new UIMenuItem("Slot 11 (Bike/Car)");
      uiMenu.AddItem(Slot11);
      UIMenuItem Slot12 = new UIMenuItem("Slot 12 (Bike/Car)");
      uiMenu.AddItem(Slot12);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Slot1)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot1.ini");
                this.SC.Save();
                UI.Notify(this.GetHostName() + "  Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot2)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot2.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot3)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot3.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot4)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot4.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot5)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot5.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot6)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot6.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot7)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot7.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot8)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot8.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot9)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot9.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot10)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              if (Game.Player.Character.CurrentVehicle.Model.IsBike)
              {
                string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
                this.SC.LoadIniFile(this.path + "//Garage//Slot10.ini");
                this.SC.Save();
                UI.Notify("Clay Vehicle has been Saved into Clubhouse");
              }
              else
                UI.Notify(this.GetHostName() + " Can only save a motorcycle in this Slot!");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item == Slot11)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            try
            {
              string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
              this.SC.LoadIniFile(this.path + "//Garage//Slot11.ini");
              this.SC.Save();
              UI.Notify("Clay Vehicle has been Saved into Clubhouse");
            }
            catch (NullReferenceException ex)
            {
              UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
            }
          }
        }
        if (item != Slot12)
          return;
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          try
          {
            string displayName = Game.Player.Character.CurrentVehicle.DisplayName;
            this.SC.LoadIniFile(this.path + "//Garage//Slot12.ini");
            this.SC.Save();
            UI.Notify("Clay Vehicle has been Saved into Clubhouse");
          }
          catch (NullReferenceException ex)
          {
            UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
          }
        }
      });
    }

    public GTA.Model RequestModel(GTA.Model model)
    {
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

    public bool CheckifBike(string Name)
    {
      bool flag = false;
      GTA.Model model = new GTA.Model(Name);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
      }
      if (model.IsBike)
        flag = true;
      if (!model.IsBike)
        flag = false;
      model.MarkAsNoLongerNeeded();
      return flag;
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

    private string CheckCar(string iniName)
    {
      try
      {
        this.Config3 = ScriptSettings.Load(iniName);
        this.VehicleName = this.Config.GetValue<string>("Configurations", "VehicleName", this.VehicleName);
        return this.VehicleName;
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: " + iniName + "Failed To Load.");
        return (string) null;
      }
    }

    private void Enter()
    {
      this.SetRadioOff();
      this.SetRadioOn();
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GrapeseedClubhouse");
      bool flag = false;
      if (this.IsScriptEnabled)
      {
        this.LoadMain("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "DelPerroClubHouse");
        if (this.CurrentSafehouse == 0)
        {
          this.SetupMarker(this.GrapeseedClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "DelPerroClubHouse");
        if (this.CurrentSafehouse == 1)
        {
          this.SetupMarker(this.VespucciClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "HowickClubHouse");
        if (this.CurrentSafehouse == 2)
        {
          this.SetupMarker(this.HowikClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "LaMesaClubHouse");
        if (this.CurrentSafehouse == 3)
        {
          this.SetupMarker(this.LaMesaClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse");
        if (this.CurrentSafehouse == 4)
        {
          this.SetupMarker(this.PaletoClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PillboxHillClubHouse");
        if (this.CurrentSafehouse == 5)
        {
          this.SetupMarker(this.PillboxHillClubHouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "RanchoClubHouse");
        if (this.CurrentSafehouse == 6)
        {
          this.SetupMarker(this.RanchoClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "SandyShoresClubHouse");
        if (this.CurrentSafehouse == 7)
        {
          this.SetupMarker(this.SandyShoresClubhouse1);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse2");
        if (this.CurrentSafehouse == 8)
        {
          this.SetupMarker(this.SandyShoresClubhouse2);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VespucciClubHouse");
        if (this.CurrentSafehouse == 9)
        {
          this.SetupMarker(this.DelPerroClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VineWoodClubHouse");
        if (this.CurrentSafehouse == 10)
        {
          this.SetupMarker(this.VinewoodClubhouse);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GreatChaparral");
        if (this.CurrentSafehouse == 11)
        {
          this.SetupMarker(this.GreatChaparral);
          flag = true;
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GrapeseedClubhouse");
        if (this.CurrentSafehouse == 0)
        {
          this.SafeHouseEnter = this.GrapeseedClubhouse;
          this.LastknownPos = this.GrapeseedClubhouse;
          this.GarageMarker = new Vector3(2466.14f, 4102.16f, 37f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "DelPerroClubHouse");
        if (this.CurrentSafehouse == 1)
        {
          this.SafeHouseEnter = this.DelPerroClubhouse;
          this.LastknownPos = this.DelPerroClubhouse;
          this.GarageMarker = new Vector3(-1146f, -1579f, 4f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "HowickClubHouse");
        if (this.CurrentSafehouse == 2)
        {
          this.SafeHouseEnter = this.HowikClubhouse;
          this.LastknownPos = this.HowikClubhouse;
          this.GarageMarker = new Vector3(-26.7f, -192.3f, 51.5f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "LaMesaClubHouse");
        if (this.CurrentSafehouse == 3)
        {
          this.SafeHouseEnter = this.LaMesaClubhouse;
          this.LastknownPos = this.LaMesaClubhouse;
          this.GarageMarker = new Vector3(943.1f, -1452.7f, 30.5f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse");
        if (this.CurrentSafehouse == 4)
        {
          this.SafeHouseEnter = this.PaletoClubhouse;
          this.LastknownPos = this.PaletoClubhouse;
          this.GarageMarker = new Vector3(-357f, 6069f, 31f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PillboxHillClubHouse");
        if (this.CurrentSafehouse == 5)
        {
          this.SafeHouseEnter = this.PillboxHillClubHouse;
          this.LastknownPos = this.PillboxHillClubHouse;
          this.GarageMarker = new Vector3(32f, -1032f, 29.4f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "RanchoClubHouse");
        if (this.CurrentSafehouse == 6)
        {
          this.SafeHouseEnter = this.RanchoClubhouse;
          this.LastknownPos = this.RanchoClubhouse;
          this.GarageMarker = new Vector3(257f, -1800f, 27f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "SandyShoresClubHouse");
        if (this.CurrentSafehouse == 7)
        {
          this.SafeHouseEnter = this.SandyShoresClubhouse1;
          this.LastknownPos = this.SandyShoresClubhouse1;
          this.GarageMarker = new Vector3(1728f, 3711f, 33f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse2");
        if (this.CurrentSafehouse == 8)
        {
          this.SafeHouseEnter = this.SandyShoresClubhouse2;
          this.LastknownPos = this.SandyShoresClubhouse2;
          this.GarageMarker = new Vector3(-37.9f, 6414.5f, 30.5f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VespucciClubHouse");
        if (this.CurrentSafehouse == 9)
        {
          this.SafeHouseEnter = this.VespucciClubhouse;
          this.LastknownPos = this.VespucciClubhouse;
          this.GarageMarker = new Vector3(-1467f, -925f, 9f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VineWoodClubHouse");
        if (this.CurrentSafehouse == 10)
        {
          this.SafeHouseEnter = this.VinewoodClubhouse;
          this.LastknownPos = this.VinewoodClubhouse;
          this.GarageMarker = new Vector3(178.6f, 301.1f, 104.5f);
        }
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GreatChaparral");
        if (this.CurrentSafehouse == 11)
        {
          this.SafeHouseEnter = this.GreatChaparral;
          this.LastknownPos = this.GreatChaparral;
          this.GarageMarker = new Vector3(62.9f, 2795.7f, 56.5f);
        }
      }
      this.GetLocation();
      this.Delete();
      Script.Wait(500);
      try
      {
        this.BarMaid = World.CreatePed((GTA.Model) PedHash.Barman01SMY, this.BarMaidLoc, this.BartenderRot);
        this.BarMaid.FreezePosition = true;
        this.SC.LoadIniFile(this.path + "//Garage//Slot1.ini");
        GTA.Model model1 = this.SC.CheckCar(this.path + "//Garage//Slot1.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot2.ini");
        GTA.Model model2 = this.SC.CheckCar(this.path + "//Garage//Slot2.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot3.ini");
        GTA.Model model3 = this.SC.CheckCar(this.path + "//Garage//Slot3.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot4.ini");
        GTA.Model model4 = this.SC.CheckCar(this.path + "//Garage//Slot4.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot5.ini");
        GTA.Model model5 = this.SC.CheckCar(this.path + "//Garage//Slot5.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot6.ini");
        GTA.Model model6 = this.SC.CheckCar(this.path + "//Garage//Slot6.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot7.ini");
        GTA.Model model7 = this.SC.CheckCar(this.path + "//Garage//Slot7.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot8.ini");
        GTA.Model model8 = this.SC.CheckCar(this.path + "//Garage//Slot8.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot9.ini");
        GTA.Model model9 = this.SC.CheckCar(this.path + "//Garage//Slot9.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot10.ini");
        GTA.Model model10 = this.SC.CheckCar(this.path + "//Garage//Slot10.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot11.ini");
        GTA.Model model11 = this.SC.CheckCar(this.path + "//Garage//Slot11.ini");
        this.SC.LoadIniFile(this.path + "//Garage//Slot12.ini");
        GTA.Model model12 = this.SC.CheckCar(this.path + "//Garage//Slot12.ini");
        if (model1 != (GTA.Model) "null" && model1 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot1.ini");
          this.Vehicle1 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot1.ini")), this.Vehicle1Loc, this.Vehicle1Rot);
          this.SC.Load(this.Vehicle1);
          this.Vehicle1.IsDriveable = false;
        }
        if (model2 != (GTA.Model) "null" && model2 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot2.ini");
          this.Vehicle2 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot2.ini")), this.Vehicle2Loc, this.Vehicle2Rot);
          this.SC.Load(this.Vehicle2);
          this.Vehicle2.IsDriveable = false;
        }
        if (model3 != (GTA.Model) "null" && model3 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot3.ini");
          this.Vehicle3 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot3.ini")), this.Vehicle3Loc, this.Vehicle3Rot);
          this.SC.Load(this.Vehicle3);
          this.Vehicle3.IsDriveable = false;
        }
        if (model4 != (GTA.Model) "null" && model4 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot4.ini");
          this.Vehicle4 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot4.ini")), this.Vehicle4Loc, this.Vehicle4Rot);
          this.SC.Load(this.Vehicle4);
          this.Vehicle4.IsDriveable = false;
        }
        if (model5 != (GTA.Model) "null" && model5 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot5.ini");
          this.Vehicle5 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot5.ini")), this.Vehicle5Loc, this.Vehicle5Rot);
          this.SC.Load(this.Vehicle5);
          this.Vehicle5.IsDriveable = false;
        }
        if (model6 != (GTA.Model) "null" && model6 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot6.ini");
          this.Vehicle6 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot6.ini")), this.Vehicle6Loc, this.Vehicle6Rot);
          this.SC.Load(this.Vehicle6);
          this.Vehicle6.IsDriveable = false;
        }
        if (model7 != (GTA.Model) "null" && model7 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot7.ini");
          this.Vehicle7 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot7.ini")), this.Vehicle7Loc, this.Vehicle7Rot);
          this.SC.Load(this.Vehicle7);
          this.Vehicle7.IsDriveable = false;
        }
        if (model8 != (GTA.Model) "null" && model8 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot8.ini");
          this.Vehicle8 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot8.ini")), this.Vehicle8Loc, this.Vehicle8Rot);
          this.SC.Load(this.Vehicle8);
          this.Vehicle8.IsDriveable = false;
        }
        if (model9 != (GTA.Model) "null" && model9 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot9.ini");
          this.Vehicle9 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot9.ini")), this.Vehicle9Loc, this.Vehicle9Rot);
          this.SC.Load(this.Vehicle9);
          this.Vehicle9.IsDriveable = false;
        }
        if (model10 != (GTA.Model) "null" && model10 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot10.ini");
          this.Vehicle10 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot10.ini")), this.Vehicle10Loc, this.Vehicle10Rot);
          this.SC.Load(this.Vehicle10);
          this.Vehicle10.IsDriveable = false;
        }
        if (model11 != (GTA.Model) "null" && model11 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot11.ini");
          this.Vehicle11 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot11.ini")), this.Vehicle11Loc, this.Vehicle11Rot);
          this.SC.Load(this.Vehicle11);
          this.Vehicle11.IsDriveable = false;
        }
        if (model12 != (GTA.Model) "null" && model12 != (GTA.Model) (string) null)
        {
          this.SC.LoadIniFile(this.path + "//Garage//Slot12.ini");
          this.Vehicle12 = World.CreateVehicle(this.RequestModel(this.SC.CheckCar(this.path + "//Garage//Slot12.ini")), this.Vehicle12Loc, this.Vehicle12Rot);
          this.SC.Load(this.Vehicle12);
          this.Vehicle12.IsDriveable = false;
        }
      }
      catch (NullReferenceException ex)
      {
        UI.Notify("~r~ Biker Business Clubhouse Garage : Somthing went wrong while loading these vehicles, please retry, if it persists check the vehicle ini files for invald vehiclenames or contact HKH~w~");
      }
      Game.Player.Character.Position = this.SafeHouseExit;
    }

    private void Delete()
    {
      this.SetRadioOff();
      this.SetRadioOn();
      if ((Entity) this.BarMaid != (Entity) null)
        this.BarMaid.Delete();
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
      if (!((Entity) this.Vehicle12 != (Entity) null))
        return;
      this.Vehicle12.Delete();
    }

    private void OnKeyDown()
    {
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.IsInterior && ((double) World.GetDistance(Game.Player.Character.Position, this.BarLoc) < 2.0 && !this.DrinksMenu.Visible))
        this.DrinksMenu.Visible = !this.DrinksMenu.Visible;
      if (Game.IsControlJustPressed(2, GTA.Control.Cover) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot1.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot2.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot3.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot4.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot5.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot6.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot7.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot8.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot9.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot10.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle11)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot11.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
        if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle12)
        {
          this.SC.LoadIniFile(this.path + "Garage//Slot12.ini");
          this.SC.SaveWithoutDelete();
          UI.Notify(this.GetHostName() + " Vehicle Saved");
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle1 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle2 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle3 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle4 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle5 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle6 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle7 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle8 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle9 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle10 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle11)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle11 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
        if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle12)
        {
          Vehicle vehicle = currentVehicle;
          this.Vehicle12 = (Vehicle) null;
          Game.FadeScreenOut(600);
          Script.Wait(600);
          Game.Player.Character.Position = this.SafeHouseEnter;
          this.Delete();
          if ((Entity) this.Clay != (Entity) null)
            this.Clay.Delete();
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.IsInterior = false;
          this.SetRadioOff();
          this.SetRadioOff();
          vehicle.Position = this.GarageMarker;
          Game.Player.Character.SetIntoVehicle(vehicle, VehicleSeat.Driver);
          this.Delete();
          vehicle.IsDriveable = true;
          vehicle.FreezePosition = false;
          this.SetRadioOff();
        }
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseEnter) < 2.0)
      {
        if (this.purchaselvl >= 1)
        {
          Game.FadeScreenOut(600);
          Script.Wait(600);
          int num = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 998.4809, (InputArgument) -3164.711, (InputArgument) -38.90733);
          Function.Call(Hash._0x55E86AF2712B36A1, (InputArgument) num, (InputArgument) "bkr_biker_interior_placement_interior_1_biker_dlc_int_02_milol");
          Function.Call(Hash._0x41F37C3427C75AE0, (InputArgument) num);
          Game.Player.Character.Position = this.SafeHouseExit;
          this.IsInterior = true;
          Script.Wait(600);
          Game.FadeScreenIn(1200);
          this.Enter();
        }
      }
      else if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.IsInterior && (double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseExit) < 2.0)
      {
        Game.FadeScreenOut(600);
        Script.Wait(600);
        if (this.CurrentSafehouse == 0)
        {
          this.SafeHouseEnter = this.GrapeseedClubhouse;
          this.LastknownPos = this.GrapeseedClubhouse;
          this.GarageMarker = new Vector3(2466.14f, 4102.16f, 37f);
        }
        if (this.CurrentSafehouse == 1)
        {
          this.SafeHouseEnter = this.VespucciClubhouse;
          this.LastknownPos = this.VespucciClubhouse;
          this.GarageMarker = new Vector3(-1146f, -1579f, 4f);
        }
        if (this.CurrentSafehouse == 2)
        {
          this.SafeHouseEnter = this.HowikClubhouse;
          this.LastknownPos = this.HowikClubhouse;
          this.GarageMarker = new Vector3(-26.7f, -192.3f, 51.5f);
        }
        if (this.CurrentSafehouse == 3)
        {
          this.SafeHouseEnter = this.LaMesaClubhouse;
          this.LastknownPos = this.LaMesaClubhouse;
          this.GarageMarker = new Vector3(943.1f, -1452.7f, 30.5f);
        }
        if (this.CurrentSafehouse == 4)
        {
          this.SafeHouseEnter = this.PaletoClubhouse;
          this.LastknownPos = this.PaletoClubhouse;
          this.GarageMarker = new Vector3(-357f, 6069f, 31f);
        }
        if (this.CurrentSafehouse == 5)
        {
          this.SafeHouseEnter = this.PillboxHillClubHouse;
          this.LastknownPos = this.PillboxHillClubHouse;
          this.GarageMarker = new Vector3(32f, -1032f, 29.4f);
        }
        if (this.CurrentSafehouse == 6)
        {
          this.SafeHouseEnter = this.RanchoClubhouse;
          this.LastknownPos = this.RanchoClubhouse;
          this.GarageMarker = new Vector3(257f, -1800f, 27f);
        }
        if (this.CurrentSafehouse == 7)
        {
          this.SafeHouseEnter = this.SandyShoresClubhouse1;
          this.LastknownPos = this.SandyShoresClubhouse1;
          this.GarageMarker = new Vector3(1728f, 3711f, 33f);
        }
        if (this.CurrentSafehouse == 8)
        {
          this.SafeHouseEnter = this.SandyShoresClubhouse2;
          this.LastknownPos = this.SandyShoresClubhouse2;
          this.GarageMarker = new Vector3(-37.9f, 6414.5f, 30.5f);
        }
        if (this.CurrentSafehouse == 9)
        {
          this.SafeHouseEnter = this.DelPerroClubhouse;
          this.LastknownPos = this.DelPerroClubhouse;
          this.GarageMarker = new Vector3(-1467f, -925f, 9f);
        }
        if (this.CurrentSafehouse == 10)
        {
          this.SafeHouseEnter = this.VinewoodClubhouse;
          this.LastknownPos = this.VinewoodClubhouse;
          this.GarageMarker = new Vector3(178.6f, 301.1f, 104.5f);
        }
        if (this.CurrentSafehouse == 11)
        {
          this.SafeHouseEnter = this.GreatChaparral;
          this.LastknownPos = this.GreatChaparral;
          this.GarageMarker = new Vector3(62.9f, 2795.7f, 56.5f);
        }
        Game.Player.Character.Position = this.LastknownPos;
        this.Delete();
        if ((Entity) this.Clay != (Entity) null)
          this.Clay.Delete();
        Script.Wait(600);
        Game.FadeScreenIn(1200);
        this.IsInterior = false;
        this.SetRadioOff();
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.GarageMarker) < 5.0)
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
        if (this.purchaselvl >= 1)
        {
          if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          {
            this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
            if (!this.GarageMenu.Visible)
              this.GarageMenu.Visible = !this.GarageMenu.Visible;
          }
          else
            UI.Notify(this.GetHostName() + " get a vehicle if you wish to enter the Clubhouse this way");
        }
        else
          UI.Notify(this.GetHostName() + " Please purchase this Clubhouse first!");
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, this.removeMarker) < 2.0 && this.IsInterior)
      {
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
        if (!this.RemoveMenu.Visible)
          this.RemoveMenu.Visible = !this.RemoveMenu.Visible;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && this.purchaselvl >= 1 && ((double) World.GetDistance(Game.Player.Character.Position, this.StockMenu) < 2.0 && this.IsInterior))
        this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SleepPos) >= 2.0 || !Game.IsControlJustPressed(2, GTA.Control.Context) || !this.IsInterior)
        return;
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

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.Key1 = this.Config.GetValue<Keys>("Configurations", "Key1", this.Key1);
        this.Vehiclename = this.Config.GetValue<string>("Setup", "vehicle", this.Vehiclename);
        this.ClubhouseChoosen = this.Config.GetValue<int>("Setup", "ClubhouseChoosen", this.ClubhouseChoosen);
        this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
        this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
        this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
        this.UseOldMarker = this.Config.GetValue<bool>("Setup", "UseOldMarker", this.UseOldMarker);
        int num1;
        if (this.purchaselvl == 0)
        {
          int purchaselvl = this.purchaselvl;
          num1 = 1;
        }
        else
          num1 = 1;
        if (num1 == 0)
          return;
        this.maxstocks = 10 * this.purchaselvl;
        float num2 = (float) ((double) this.BusinessUpgradeIncreaseGain * (double) this.purchaselvl / 0.75);
        this.profitMargin = (float) (0.85 * (double) this.purchaselvl + 0.0);
        this.increaseGain = num2;
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if ((Entity) this.Glass != (Entity) null)
        this.Glass.Delete();
      if ((Entity) this.Bottle != (Entity) null)
        this.Bottle.Delete();
      foreach (Prop prop in this.Champ)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if ((Entity) this.Champaine != (Entity) null)
        this.Champaine.Delete();
      if ((Entity) this.BarMaid != (Entity) null)
        this.BarMaid.Delete();
      if (this.GarageEntryBlip != (Blip) null)
        this.GarageEntryBlip.Remove();
      foreach (Blip clubhouseBlip in this.ClubhouseBlips)
      {
        if (clubhouseBlip != (Blip) null)
          clubhouseBlip.Remove();
      }
      if (this.ballasBlip1 != (Blip) null)
        this.ballasBlip1.Remove();
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
    }

    private void SetupMarker(Vector3 Pos)
    {
      if (!this.IsScriptEnabled)
        return;
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.ballasBlip1 = World.CreateBlip(Pos);
      this.ballasBlip1.Sprite = BlipSprite.Safehouse;
      this.ballasBlip1.Name = "Biker Safe House";
      this.ballasBlip1.Color = BlipColor.White;
      this.ballasBlip1.IsShortRange = true;
      if (this.purchaselvl >= 1)
      {
        this.ballasBlip1.Sprite = BlipSprite.BikerClubhouse;
        this.ballasBlip1.Color = this.Safehouse_Colour;
        this.ballasBlip1.Alpha = (int) byte.MaxValue;
      }
      if (this.purchaselvl == 0)
      {
        this.ballasBlip1.Sprite = BlipSprite.BikerClubhouse;
        this.ballasBlip1.Color = BlipColor.White;
        this.ballasBlip1.Alpha = 0;
      }
      this.ClubhouseBlips.Add(this.ballasBlip1);
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public void SetRadioOff()
    {
      Function.Call(Hash._0x19F21E63AE6EAE4E, (InputArgument) true);
      this.RadioOn = false;
      Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) true);
      Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
      Function.Call(Hash._0xF7F26C6E9CC9EBB8, (InputArgument) true);
      this.RefreshingRadio = false;
    }

    public void SetRadioOn()
    {
      Function.Call(Hash._0x19F21E63AE6EAE4E, (InputArgument) true);
      this.RadioOn = true;
      string[] strArray = this.DefaultRadioStation.Split('_');
      int num = 1;
      try
      {
        num = int.Parse(strArray[0]);
      }
      catch
      {
      }
      Function.Call(Hash._0x19F21E63AE6EAE4E, (InputArgument) true);
      Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) true);
      Function.Call(Hash._0x1098355A16064BB3, (InputArgument) true);
      Function.Call(Hash._0xF7F26C6E9CC9EBB8, (InputArgument) true);
      Function.Call(Hash._0xA619B168B8A8570F, (InputArgument) this.CurrentRadioStation);
    }

    public void AddRatioStations()
    {
      this.RadioStat.Add("Los Santos Rock Radio");
      this.RadioStat.Add("Non-Stop-Pop FM");
      this.RadioStat.Add("Radio Los Santos");
      this.RadioStat.Add("Channel X");
      this.RadioStat.Add("West Coast Talk Radio");
      this.RadioStat.Add("Rebel Radio");
      this.RadioStat.Add("Soulwax FM");
      this.RadioStat.Add("East Los FM");
      this.RadioStat.Add("West Coast Classics");
      this.RadioStat.Add("Blue Ark");
      this.RadioStat.Add("World Wide FM");
      this.RadioStat.Add("FlyLo FM");
      this.RadioStat.Add("The Lowdown 91.1");
      this.RadioStat.Add("The Lab");
      this.RadioStat.Add("Radio Mirror Park");
      this.RadioStat.Add("Space 103.2");
      this.RadioStat.Add("Vinewood Boulevard Radio");
      this.RadioStat.Add("Blonded Los Santos 97.8 FM");
      this.RadioStat.Add("Los Santos Underground Radio");
      this.RadioStat.Add("IFruit Radio");
      this.RadioStat.Add("Self Radio");
    }

    private void OnTick(object sender, EventArgs e)
    {
      if (this.IsInterior)
      {
        Vector3 position = Game.Player.Character.Position;
        if ((uint) Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) > 0U)
        {
          if (Game.Player.Character.Weapons.Current != null && Game.Player.Character.Weapons.Current.Hash != WeaponHash.Unarmed)
          {
            this.DisplayHelpTextThisFrame("You cannot use weapons while inside your Clubhouse");
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed, true);
          }
          if (Game.IsControlPressed(2, GTA.Control.SelectWeapon))
          {
            Game.DisableControlThisFrame(2, GTA.Control.SelectWeapon);
            this.DisplayHelpTextThisFrame("You cannot use weapons while inside your Clubhouse");
          }
        }
      }
      this.OnKeyDown();
      if (this.IsDrinking)
      {
        if (this.BottleType == 1)
          this.WineMethod();
        else
          this.WhiskeyMethod();
        if (this.Effect == 6)
          Game.Player.Character.Health += 10;
        if (this.Effect == 5)
          Game.Player.Character.Health += 5;
        if (this.Effect == 4)
          Game.Player.Character.Health += 2;
        if (this.Effect == 3)
        {
          for (int index = 0; index <= 1000; ++index)
          {
            System.Random random = new System.Random();
            if ((index == 250 || index == 500 || index == 750) && Game.Player.Character.Health > 25)
              Game.Player.Character.Health -= 10;
            if (index == 1000)
              this.Effect = -1;
          }
        }
        if (this.Effect == 2)
          Game.Player.Character.HasGravity = false;
        if (this.Effect != 1)
          ;
        if (this.Effect != 0)
          ;
        if (this.Effect != -1)
          ;
        if ((double) this.DrunkLevel >= 0.0)
          this.DrunkLevel -= 0.01f;
        if ((double) this.DrunkLevel <= 0.0)
        {
          Function.Call(Hash._0x0F07E7745A236711);
          Function.Call(Hash._0x3C8938D7D872211E);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "default");
          if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
            Function.Call(Hash._0x0F07E7745A236711);
          SafeHouse1.WineTaskScriptStatus = 0;
          SafeHouse1.WhiskeyTaskScriptStatus = 0;
          this.IsDrinking = false;
          if ((Entity) this.Glass != (Entity) null)
            this.Glass.Delete();
          if ((Entity) this.Bottle != (Entity) null)
            this.Bottle.Delete();
          Function.Call(Hash._0xD75ACCF5E0FB5367, (InputArgument) Game.Player.Character, (InputArgument) false, (InputArgument) -1, (InputArgument) 0);
          Function.Call(Hash._0xAA74EC0CB0AAEA2C, (InputArgument) Game.Player.Character, (InputArgument) 1.0);
        }
        if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
        {
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "default");
          if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
            Function.Call(Hash._0x0F07E7745A236711);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "Drunk");
          Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) (this.DrunkLevel / 100f * 4f));
          Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "Drunk", (InputArgument) (this.DrunkLevel / 100f * 4f));
        }
        if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
        {
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
            Function.Call(Hash._0x0F07E7745A236711);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "Drunk");
          Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) (this.DrunkLevel / 100f * 4f));
          Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "Drunk", (InputArgument) (this.DrunkLevel / 100f * 4f));
        }
        if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
        {
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
            Function.Call(Hash._0x0F07E7745A236711);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "Drunk");
          Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) (this.DrunkLevel / 100f * 4f));
          Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "Drunk", (InputArgument) (this.DrunkLevel / 100f * 4f));
        }
        ++this.DrinkTimer;
        if (this.DrinkTimer < 100)
          ;
      }
      if (!this.IsInterior && this.RadioOn)
      {
        this.SetRadioOff();
        this.RadioOn = false;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2399.7f, 718.1f, 221.4f)) < 2.0 && Game.Player.Character.Alpha == 15)
      {
        this.MainModDestroy();
        this.MainModRefresh();
      }
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      if (this.GarageMenuPool != null && this.GarageMenuPool.IsAnyMenuOpen())
        this.GarageMenuPool.ProcessMenus();
      if (this.RemoveMenuPool != null && this.RemoveMenuPool.IsAnyMenuOpen())
        this.RemoveMenuPool.ProcessMenus();
      if ((double) World.GetDistance(Game.Player.Character.Position, this.BarLoc) > 50.0)
      {
        if (this.IsInterior)
          World.DrawMarker(MarkerType.VerticalCylinder, this.BarLoc, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.SafehouseMColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.BarLoc) < 1.25)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get a drink");
      }
      if (this.IsInterior)
      {
        Function.Call(Hash._0x1098355A16064BB3, (InputArgument) true);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.RadioPos) < 60.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.RadioPos, Vector3.Zero, Vector3.Zero, new Vector3(0.65f, 0.65f, 0.45f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.RadioPos) < 1.25)
          Function.Call(Hash._0x19F21E63AE6EAE4E, (InputArgument) true);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.RadioPos) > 1.25)
          Function.Call(Hash._0x19F21E63AE6EAE4E, (InputArgument) false);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.RadioPos) < 1.25)
        {
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Turn Radio On/Off ~INPUT_COVER~ to Switch Radio Station");
          if (Game.IsControlJustPressed(2, GTA.Control.Context))
          {
            if (this.RadioOn)
            {
              this.RadioOn = false;
              this.SetRadioOff();
              UI.Notify(" Radio has been Set to Off");
            }
            else if (!this.RadioOn)
            {
              this.RadioOn = true;
              this.SetRadioOff();
              this.SetRadioOn();
              UI.Notify("  Radio has been Set to On");
            }
          }
          if (Game.IsControlJustPressed(2, GTA.Control.Cover))
          {
            this.CurrentRadioStation = Function.Call<int>(Hash._0xE8AF77C4C06ADC93);
            this.DefaultRadioStation = (this.CurrentRadioStation.ToString() + "_" + this.RadioStat[this.CurrentRadioStation]).ToString();
            this.Config.SetValue<string>("Radio", "DefaultRadioStation", this.DefaultRadioStation);
            this.Config.SetValue<int>("Radio", "CurrentRadioStation", this.CurrentRadioStation);
            this.Config.SetValue<bool>("Radio", "PlayRadioMusic", this.PlayRadioMusic);
            this.Config.Save();
            UI.Notify(" Radio has been Changed: " + this.DefaultRadioStation);
            this.SetRadioOff();
            this.SetRadioOn();
          }
        }
        if (this.UseOldMarker)
          World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(997.2f, -3168.2f, -40f), Vector3.Zero, Vector3.Zero, new Vector3(0.65f, 0.65f, 0.65f), this.SafehouseMColor);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.BarLoc) < 2.0 && this.IsInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to buy a drink");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.GarageMarker) > 50.0)
      {
        if (this.GarageMarkerOn == 2)
          this.GarageMarkerOn = 1;
        if (this.GarageEntryBlip != (Blip) null)
          this.GarageEntryBlip.Remove();
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.GarageMarker) < 50.0 && (double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseEnter) < 100.0)
      {
        if (this.GarageMarkerOn == 0)
          this.GarageMarkerOn = 1;
        Vector3 garageMarker = this.GarageMarker;
        if (this.GarageMarker != new Vector3(0.0f, 0.0f, 0.0f) && (this.GarageMarkerOn == 1 && (uint) this.purchaselvl > 0U))
        {
          this.GarageMarkerOn = 2;
          if (this.GarageEntryBlip == (Blip) null)
          {
            this.GarageEntryBlip = World.CreateBlip(this.GarageMarker);
            this.GarageEntryBlip.Sprite = BlipSprite.Garage;
            this.GarageEntryBlip.Name = "Biker Safe Garage";
            this.GarageEntryBlip.Color = BlipColor.White;
            this.GarageEntryBlip.IsShortRange = true;
            if (this.purchaselvl >= 1)
            {
              this.GarageEntryBlip.Sprite = BlipSprite.Garage;
              this.GarageEntryBlip.Color = this.Safehouse_Colour;
            }
            if (this.purchaselvl == 0)
            {
              this.GarageEntryBlip.Sprite = BlipSprite.GarageForSale;
              this.GarageEntryBlip.Color = BlipColor.White;
            }
          }
          else if (this.GarageEntryBlip != (Blip) null)
          {
            this.GarageEntryBlip = World.CreateBlip(this.GarageMarker);
            this.GarageEntryBlip.Sprite = BlipSprite.Garage;
            this.GarageEntryBlip.Name = "Biker Safe Garage";
            this.GarageEntryBlip.Color = BlipColor.White;
            this.GarageEntryBlip.IsShortRange = true;
            if (this.purchaselvl >= 1)
            {
              this.GarageEntryBlip.Sprite = BlipSprite.Garage;
              this.GarageEntryBlip.Color = this.Safehouse_Colour;
            }
            if (this.purchaselvl == 0)
            {
              this.GarageEntryBlip.Sprite = BlipSprite.GarageForSale;
              this.GarageEntryBlip.Color = BlipColor.White;
            }
          }
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.GrapeseedClubhouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GrapeseedClubhouse");
        if (this.CurrentSafehouse == 0)
        {
          this.SafeHouseEnter = this.GrapeseedClubhouse;
          this.LastknownPos = this.GrapeseedClubhouse;
          this.GarageMarker = new Vector3(2466.14f, 4102.16f, 37f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.VespucciClubhouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "DelPerroClubHouse");
        if (this.CurrentSafehouse == 1)
        {
          this.SafeHouseEnter = this.VespucciClubhouse;
          this.LastknownPos = this.VespucciClubhouse;
          this.GarageMarker = new Vector3(-1146f, -1579f, 3.5f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.HowikClubhouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "HowickClubHouse");
        if (this.CurrentSafehouse == 2)
        {
          this.SafeHouseEnter = this.HowikClubhouse;
          this.LastknownPos = this.HowikClubhouse;
          this.GarageMarker = new Vector3(-26.7f, -192.3f, 51.5f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.LaMesaClubhouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "LaMesaClubHouse");
        if (this.CurrentSafehouse == 3)
        {
          this.SafeHouseEnter = this.LaMesaClubhouse;
          this.LastknownPos = this.LaMesaClubhouse;
          this.GarageMarker = new Vector3(943.1f, -1452.7f, 30.5f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.PaletoClubhouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse");
        if (this.CurrentSafehouse == 4)
        {
          this.SafeHouseEnter = this.PaletoClubhouse;
          this.LastknownPos = this.PaletoClubhouse;
          this.GarageMarker = new Vector3(-357f, 6069f, 31f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.PillboxHillClubHouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PillboxHillClubHouse");
        if (this.CurrentSafehouse == 5)
        {
          this.SafeHouseEnter = this.PillboxHillClubHouse;
          this.LastknownPos = this.PillboxHillClubHouse;
          this.GarageMarker = new Vector3(32f, -1032f, 29.4f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.RanchoClubhouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "RanchoClubHouse");
        if (this.CurrentSafehouse == 6)
        {
          this.SafeHouseEnter = this.RanchoClubhouse;
          this.LastknownPos = this.RanchoClubhouse;
          this.GarageMarker = new Vector3(257f, -1800f, 27f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SandyShoresClubhouse1) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "SandyShoresClubHouse");
        if (this.CurrentSafehouse == 7)
        {
          this.SafeHouseEnter = this.SandyShoresClubhouse1;
          this.LastknownPos = this.SandyShoresClubhouse1;
          this.GarageMarker = new Vector3(1728f, 3711f, 33f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SandyShoresClubhouse2) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "PaletoClubHouse2");
        if (this.CurrentSafehouse == 8)
        {
          this.SafeHouseEnter = this.SandyShoresClubhouse2;
          this.LastknownPos = this.SandyShoresClubhouse2;
          this.GarageMarker = new Vector3(-37.9f, 6414.5f, 30.5f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.DelPerroClubhouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VespucciClubHouse");
        if (this.CurrentSafehouse == 9)
        {
          this.SafeHouseEnter = this.DelPerroClubhouse;
          this.LastknownPos = this.DelPerroClubhouse;
          this.GarageMarker = new Vector3(-1467f, -925f, 9f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.VinewoodClubhouse) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "VineWoodClubHouse");
        if (this.CurrentSafehouse == 10)
        {
          this.SafeHouseEnter = this.VinewoodClubhouse;
          this.LastknownPos = this.VinewoodClubhouse;
          this.GarageMarker = new Vector3(178.6f, 301.1f, 104.5f);
        }
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.GreatChaparral) < 50.0)
      {
        this.CheckForScriptEnabled("scripts//DisableBusinesses.ini", "GreatChaparral");
        if (this.CurrentSafehouse == 11)
        {
          this.SafeHouseEnter = this.GreatChaparral;
          this.LastknownPos = this.GreatChaparral;
          this.GarageMarker = new Vector3(62.9f, 2795.7f, 56.5f);
        }
      }
      if (this.IsInterior && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
        if ((Entity) this.Vehicle1 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle1)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle2 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle2)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle3 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle3)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle4 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle4)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle5 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle5)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle6 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle6)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle7 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle7)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle8 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle8)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle9 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle9)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle10 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle10)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle11 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle11)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
        if ((Entity) this.Vehicle12 != (Entity) null && (Entity) currentVehicle == (Entity) this.Vehicle12)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to use this vehicle or press ~INPUT_COVER~ to Save this Vehicle");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseEnter) < 4.0)
      {
        if (this.purchaselvl == 0)
          this.DisplayHelpTextThisFrame("Purchase this Clubhouse via ~g~ HKH191s Business Helper ~w~~INPUT_CONTEXT~ Set Waypoint to Marker");
        else if (this.purchaselvl >= 1)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Enter Safe House");
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseExit) < 4.0 && this.IsInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Exit Safe House");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SleepPos) < 1.25 && this.IsInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sleep");
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseEnter) < 60.0)
        World.DrawMarker(MarkerType.VerticalCylinder, this.SafeHouseEnter, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.SafehouseMColor);
      if ((double) World.GetDistance(Game.Player.Character.Position, this.removeMarker) < 2.0 && this.IsInterior)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Open Vehicle Menu");
      if ((uint) this.purchaselvl > 0U)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.GarageMarker) < 2.0 && (double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseEnter) < 100.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Save a vehicle");
        if ((double) World.GetDistance(Game.Player.Character.Position, this.GarageMarker) < 50.0 && (double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseEnter) < 100.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.GarageMarker, Vector3.Zero, Vector3.Zero, new Vector3(3f, 3f, 1f), this.SafehouseMColor);
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.SafeHouseExit) >= 40.0 || !this.IsInterior)
        return;
      World.DrawMarker(MarkerType.VerticalCylinder, this.SafeHouseExit, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.SafehouseMColor);
      World.DrawMarker(MarkerType.VerticalCylinder, this.removeMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.85f, 0.85f, 0.65f), this.SafehouseMColor);
    }
  }
}
