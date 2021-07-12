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

namespace DoomsdayBusiness
{
  public class WrokingAvenger : Script
  {
    private ScriptSettings MainConfigFile;
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    private ScriptSettings Config;
    private ScriptSettings Config2;
    public SaveCar SaveLoad;
    public SaveCar SC;
    private MenuPool modMenuPool;
    private UIMenu mainMenu;
    private UIMenu Options;
    public Vehicle Avenger;
    public Vehicle Moc1;
    public Vehicle Moc2;
    public bool createdPed;
    public Ped ClayPed;
    public Vector3 Pedspawn;
    public Vector3 AvengerSpawn;
    public Blip AvengerBlip;
    public Vector3 MOCLOC;
    public Vector3 MOCLOC2;
    public string CurrentCommandCenter;
    public Vector3 ExitAvenger;
    public Vector3 AvengerPos;
    public bool CheckformobileAvenger;
    public Vehicle VehicleinCargoBay;
    public Vector3 AvengerPosSave;
    public int AvengerBought;
    public int Livery;
    public float X;
    public float Y;
    public float Z;
    public bool AvengerAllreadyCreated;
    public Vehicle Avenger2;
    public int Tintscount = 40;
    public int Weapons;
    public bool InInterior;
    public bool checkavenger;
    public bool LookingforAvenger;
    public Vector3 Gunlockerpos = new Vector3(518f, 4751f, -70f);
    private MenuPool modMenuPool2;
    private UIMenu mainMenu2;
    private UIMenu Options2;
    public Vector3 CabOptions = new Vector3(508.7f, 4752.7f, -70f);
    public bool ReadIni;
    public bool ResetMoc;
    public Vector3 ZuncudoRiver = new Vector3(-7.8f, 3326f, 41f);
    public Vector3 Paleto = new Vector3(5.41f, 6831f, 16f);
    public Vector3 ZuncudoRiver1 = new Vector3(-2231.41f, 2418.56f, 15f);
    public Vector3 GSD1 = new Vector3(1288f, 2847f, 48f);
    public Vector3 GSD2 = new Vector3(2075f, 1750f, 104f);
    public Vector3 GSD3 = new Vector3(2765f, 3916f, 45f);
    public Vector3 GSD4 = new Vector3(16f, 2606f, 86f);
    public Vector3 MountGordo = new Vector3(3400f, 5506f, 26f);
    public Vector3 Resorvoir = new Vector3(1875f, 285f, 164f);
    public Vector3 NewAvengerLoc;
    public Vector3 OutsideSpawn;
    public VehicleColor CabPrimary;
    public VehicleColor CabSecondary;
    public Vector3 TurretCamA;
    public Vector3 TurretCamB;
    public Vector3 TurretCamC;
    public float VHeading;
    private Keys Key1;
    private UIMenu weaponsMenu;
    public Vector3 GunLockerMarker = new Vector3(518.9f, 4751.8f, -70f);
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
    public bool IsInInterior;
    public string HostName = "Alan";
    public string Uicolour = "b";
    public ScriptSettings HostNameSettings;
    public int LiveryColor;
    public bool IsScriptEnabled;
    public ScriptSettings ScriptConfig;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public bool IsUsingSam;
    public int MissilesFired;
    public bool CanFire;
    public Camera DroneCam;
    public bool usePrecision;
    public float PrecisionLevel = 1f;
    public float AmounttoDecrease = 0.5f;
    public int TurretTimer;
    public int Timer;
    public int TurretMode;
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
    public Vehicle Cab;
    public int PurchasedSecondBusiness;
    public Blip blip;
    public string ListPath = "scripts\\HKH191sBusinessMods\\DoomsdayBusiness\\WorkingAvenger\\MilitaryTrader\\AllVehicles.ini";
    public float M = 0.0f;
    public string Price = "000";
    public string Model = "";
    public string man = "";
    public Vector3 VehSpawn;
    public bool IsInCab;
    public ScriptSettings CheckOcciConfig;
    public bool CreatedChairs;
    public int Scene1;
    public int SeatSittingin;
    public bool SittinginSeat;
    public Prop Chair1;
    public Prop Chair2;
    public Prop Chair3;
    public Prop Console1;
    public Prop Console2;
    public Prop Console3;
    public Prop ExitChair;
    public int Chairin;
    public int av7 = 0;
    public bool CheckGunlocker;
    public bool Av4 = false;
    public bool Respawn;
    public Vector3 Entry = new Vector3(-2228.79f, 2399.25f, 11f);
    public Vector3 VehicleSpawn;
    public int BusinessLocation;
    public ScriptSettings MainScriptConfig;

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
      this.CheckHostName("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
      this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
      string str = "~" + this.Uicolour + "~";
      return this.HostName;
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
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p1 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__0 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__0.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__0, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
          if (target1((CallSite) p1, obj1))
          {
            Components.Clear();
            // ISSUE: reference to a compiler-generated field
            if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__2 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__2.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__2, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
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
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (WrokingAvenger)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target2 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__4.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p4 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__4;
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__3.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__3, Components[C.Index]);
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
        if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (WrokingAvenger)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__6.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p6 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__6;
        // ISSUE: reference to a compiler-generated field
        if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__5.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__5, Components[C.Index]);
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
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (WrokingAvenger)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target1 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p8 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__7.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__7, Components[C.Index]);
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
            if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__10 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, bool> target2 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__10.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, bool>> p10 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__10;
            // ISSUE: reference to a compiler-generated field
            if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__9 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__9 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__9.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__9, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
            if (target2((CallSite) p10, obj2))
            {
              if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) W.IndexToItem(W.Index).GetHashCode(), (InputArgument) C.IndexToItem(C.Index).GetHashCode()))
              {
                // ISSUE: reference to a compiler-generated field
                if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__11 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__11 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__11.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__11, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
                // ISSUE: reference to a compiler-generated field
                if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__12 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__12 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__12.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__12, Game.Player.Character.Weapons.Current, Components[C.Index], true);
              }
            }
          }
        }
        if (item != DIsable)
          return;
        // ISSUE: reference to a compiler-generated field
        if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__14 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target3 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__14.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p14 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__14;
        // ISSUE: reference to a compiler-generated field
        if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__13 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__13 = CallSite<Func<CallSite, WeaponCollection, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "HasWeapon", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__13.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__13, Game.Player.Character.Weapons, Mk2Weapons[W.Index]);
        if (target3((CallSite) p14, obj3))
        {
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__19 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__19.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p19 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__19;
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__18 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool, object> target2 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__18.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool, object>> p18 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__18;
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__17 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__17 = CallSite<Func<CallSite, System.Type, Hash, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Call", (IEnumerable<System.Type>) new System.Type[1]
            {
              typeof (bool)
            }, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, System.Type, Hash, object, object, object> target4 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__17.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, System.Type, Hash, object, object, object>> p17 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__17;
          System.Type type = typeof (Function);
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__15 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__15.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__15, Mk2Weapons[W.Index]);
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__16 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetHashCode", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__16.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__16, Components[C.Index]);
          object obj4 = target4((CallSite) p17, type, Hash._0x5CEE3DF569CECAB0, obj1, obj2);
          object obj5 = target2((CallSite) p18, obj4, true);
          if (target1((CallSite) p19, obj5))
          {
            // ISSUE: reference to a compiler-generated field
            if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__20 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__20 = CallSite<Action<CallSite, WeaponCollection, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Select", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__20.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__20, Game.Player.Character.Weapons, Mk2Weapons[W.Index], true);
            // ISSUE: reference to a compiler-generated field
            if (WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__21 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__21 = CallSite<Action<CallSite, Weapon, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetComponent", (IEnumerable<System.Type>) null, typeof (WrokingAvenger), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__21.Target((CallSite) WrokingAvenger.\u003C\u003Eo__95.\u003C\u003Ep__21, Game.Player.Character.Weapons.Current, Components[C.Index], false);
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

    public void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Doomsday Heist Business", "Avenger", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: 3 Config.ini Failed To Load.");
      }
    }

    public WrokingAvenger()
    {
      this.LoadMain("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.Interval = 1;
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Avenger.ini");
      this.CheckifBought();
      this.SC = new SaveCar();
      this.SaveLoad = new SaveCar();
      this.CreateBanner();
      this.Setup();
      this.checkavenger = false;
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Avenger.ini");
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

    public void CheckifBought()
    {
      this.LoadIniFile2("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
      if (this.AvengerBought == 1)
        this.AvengerBought = 1;
      else
        this.AvengerBought = 0;
    }

    public void Save(float x, float y, float z)
    {
      this.X = x;
      this.Config.SetValue<float>("Setup", "X", this.X);
      this.Y = y;
      this.Config.SetValue<float>("Setup", "Y", this.Y);
      this.Z = z;
      this.Config.SetValue<float>("Setup", "Z", this.Z);
      this.AvengerSpawn = new Vector3(x, y, z);
      this.AvengerPosSave = new Vector3(this.X, this.Y, this.Z);
      this.Config.SetValue<Vector3>("Setup", "AvengerPosition", this.AvengerSpawn);
      this.Config.Save();
      this.VehicleOptions();
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    private void Setup()
    {
      this.AvengerAllreadyCreated = false;
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Command Center", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.Options = this.modMenuPool.AddSubMenu(this.mainMenu, "Options");
      this.GUIMenus.Add(this.Options);
      this.modMenuPool2 = new MenuPool();
      this.mainMenu2 = new UIMenu("Saved Vehcile Options", "Select an Option");
      this.GUIMenus.Add(this.mainMenu2);
      this.modMenuPool2.Add(this.mainMenu2);
      this.Options2 = this.modMenuPool2.AddSubMenu(this.mainMenu2, "Stored Vehicle");
      this.GUIMenus.Add(this.Options2);
      this.X = this.Config.GetValue<float>(nameof (Setup), "X", this.X);
      this.Y = this.Config.GetValue<float>(nameof (Setup), "Y", this.Y);
      this.Z = this.Config.GetValue<float>(nameof (Setup), "Z", this.Z);
      this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
      this.Pedspawn = new Vector3(-1841.3f, -3141.83f, 13f);
      this.MOCLOC = new Vector3(-1836.03f, -3148.64f, 13f);
      this.MOCLOC2 = new Vector3(-1836.03f, -3140f, 13f);
      this.ExitAvenger = new Vector3(507.3f, 4750.3f, -70f);
      this.LoadIniFile("scripts//DoomsdayBusiness//WorkingAvenger//Avenger.ini");
      this.setupoptions();
      this.SetupMarker();
      this.VehicleOptions();
      this.GunmodMenuPool = new MenuPool();
      this.GunmainMenu = new UIMenu("Gunlocker", "Select an Option");
      this.GUIMenus.Add(this.GunmainMenu);
      this.GunmodMenuPool.Add(this.GunmainMenu);
      this.weaponsMenu = this.GunmodMenuPool.AddSubMenu(this.GunmainMenu, "Weapons");
      this.GUIMenus.Add(this.weaponsMenu);
      this.SetupWeapons();
      this.LoadIniFile("scripts//DoomsdayBusiness//WorkingAvenger//Avenger.ini");
      this.VMmodMenuPool = new MenuPool();
      this.VMmainMenu = new UIMenu("Military Trader", "Select an Option");
      this.GUIMenus.Add(this.VMmainMenu);
      this.VMmodMenuPool.Add(this.VMmainMenu);
      this.vehicleMenu = this.VMmodMenuPool.AddSubMenu(this.VMmainMenu, "Vehicles");
      this.GUIMenus.Add(this.vehicleMenu);
      this.SetupVehicles();
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void VehicleOptions()
    {
      UIMenu uiMenu1 = this.modMenuPool2.AddSubMenu(this.Options2, "Special Vehicles");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool2.AddSubMenu(this.Options2, "Stored Vehicle");
      this.GUIMenus.Add(uiMenu2);
      UIMenuItem PlayersVehicle = new UIMenuItem("Player's Stored Vehicle");
      uiMenu2.AddItem(PlayersVehicle);
      UIMenuItem DuneFav = new UIMenuItem("DuneFav");
      uiMenu1.AddItem(DuneFav);
      UIMenuItem WT = new UIMenuItem("Weaponized Tampa");
      uiMenu1.AddItem(WT);
      UIMenuItem TC = new UIMenuItem("Technical Custom");
      uiMenu1.AddItem(TC);
      UIMenuItem IC = new UIMenuItem("Insurgent Custom");
      uiMenu1.AddItem(IC);
      UIMenuItem HT = new UIMenuItem("Half Track");
      uiMenu1.AddItem(HT);
      UIMenuItem NS = new UIMenuItem("NightShark");
      uiMenu1.AddItem(NS);
      UIMenuItem OP = new UIMenuItem("Oppressor");
      uiMenu1.AddItem(OP);
      UIMenuItem APC = new UIMenuItem("APC");
      uiMenu1.AddItem(APC);
      UIMenuItem Deluxo = new UIMenuItem("Deluxo");
      uiMenu1.AddItem(Deluxo);
      UIMenuItem Barrage = new UIMenuItem("Barrage");
      uiMenu1.AddItem(Barrage);
      UIMenuItem Khanjali = new UIMenuItem("Khanjali");
      uiMenu1.AddItem(Khanjali);
      UIMenuItem Stromberg = new UIMenuItem("Stromberg");
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != PlayersVehicle)
          return;
        UI.Notify(this.GetHostName() + " Player's Saved Vehicle");
        if ((Entity) this.VehicleinCargoBay != (Entity) null)
          this.VehicleinCargoBay.Delete();
        this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Storage//Vehicle.ini");
        this.SaveLoad.LoadAvengerVehicle();
        this.VehicleinCargoBay.IsDriveable = false;
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == DuneFav)
        {
          UI.Notify(this.GetHostName() + " Loading Dune FAV");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//dunefav.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Dune3, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == WT)
        {
          UI.Notify(this.GetHostName() + " Loading Weaponized Tampa");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//weaponizedtampa.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Tampa3, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == TC)
        {
          UI.Notify(this.GetHostName() + " Loading Technical Custom");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//technicalcustom.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Technical3, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == IC)
        {
          UI.Notify(this.GetHostName() + " Loading Insurgent Custom");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//Insurgentcustom.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Insurgent3, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == HT)
        {
          UI.Notify(this.GetHostName() + " Loading Halftrack ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//halftrack.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.HalfTrack, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == NS)
        {
          UI.Notify(this.GetHostName() + " Loading Nightshark ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//nightshark.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.NightShark, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == OP)
        {
          UI.Notify(this.GetHostName() + " Loading Oppressor ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//oppressor.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Oppressor, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == APC)
        {
          UI.Notify(this.GetHostName() + " Loading APC ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//apc.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.APC, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == Deluxo)
        {
          UI.Notify(this.GetHostName() + " Loading Delxuo ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//Deluxo.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Deluxo, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == Barrage)
        {
          UI.Notify(this.GetHostName() + " Loading Barrage ");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//Barrage.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Barrage, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item == Khanjali)
        {
          UI.Notify(this.GetHostName() + " Loading khanjali");
          if ((Entity) this.VehicleinCargoBay != (Entity) null)
            this.VehicleinCargoBay.Delete();
          this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//Khanjali.ini");
          this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Khanjari, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
          this.SaveLoad.Load(this.VehicleinCargoBay);
          this.VehicleinCargoBay.IsDriveable = false;
        }
        if (item != Stromberg)
          return;
        UI.Notify(this.GetHostName() + " Loading Stromberg");
        if ((Entity) this.VehicleinCargoBay != (Entity) null)
          this.VehicleinCargoBay.Delete();
        this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Special Vehicles//Stromberg.ini");
        this.VehicleinCargoBay = World.CreateVehicle((GTA.Model) VehicleHash.Stromberg, new Vector3(522.645f, 4750.41f, -68.996f), -90f);
        this.SaveLoad.Load(this.VehicleinCargoBay);
        this.VehicleinCargoBay.IsDriveable = false;
      });
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if ((Entity) this.Console1 != (Entity) null)
        this.Console1.Delete();
      if ((Entity) this.Console2 != (Entity) null)
        this.Console2.Delete();
      if ((Entity) this.Console3 != (Entity) null)
        this.Console3.Delete();
      if ((Entity) this.Chair1 != (Entity) null)
        this.Chair1.Delete();
      if ((Entity) this.Chair2 != (Entity) null)
        this.Chair2.Delete();
      if ((Entity) this.Chair3 != (Entity) null)
        this.Chair3.Delete();
      if ((Entity) this.Avenger != (Entity) null)
        this.Avenger.Delete();
      if (this.AvengerBlip != (Blip) null)
        this.AvengerBlip.Remove();
      if ((Entity) this.VehicleinCargoBay != (Entity) null)
        this.VehicleinCargoBay.Delete();
    }

    public void SetupMarker()
    {
      if (this.AvengerBought != 1 || !(this.AvengerBlip == (Blip) null))
        return;
      this.AvengerBlip = World.CreateBlip(this.AvengerSpawn);
      this.AvengerBlip.Position = new Vector3(this.X, this.Y, this.Z);
      this.AvengerBlip.Sprite = BlipSprite.Avenger;
      this.AvengerBlip.Name = "Personal Avenger (DHB MOD)";
      this.AvengerBlip.IsShortRange = true;
      this.AvengerBlip.Color = this.Blip_Colour;
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.AvengerPosSave = this.Config.GetValue<Vector3>("Setup", "AvengerPosition", this.AvengerPosSave);
        this.X = this.Config.GetValue<float>("Setup", "X", this.X);
        this.Y = this.Config.GetValue<float>("Setup", "Y", this.Y);
        this.Z = this.Config.GetValue<float>("Setup", "Z", this.Z);
        this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
        this.Livery = this.Config.GetValue<int>("Setup", "Livery", this.Livery);
        this.Weapons = this.Config.GetValue<int>("Setup", "Weapons", this.Weapons);
        this.AvengerSpawn = this.AvengerPosSave;
        this.VHeading = this.Config.GetValue<float>("Setup", "VHeading", this.VHeading);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Avenger.ini Failed To Load.");
      }
    }

    private void LoadIniFile2(string iniName)
    {
      try
      {
        this.Config2 = ScriptSettings.Load(iniName);
        this.AvengerBought = this.Config2.GetValue<int>("SpecialVehicles", "AvengerBought", this.AvengerBought);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Avenger.ini Failed To Load.");
      }
    }

    private void setupoptions()
    {
      List<object> items = new List<object>();
      for (int index = 0; index < this.Tintscount; ++index)
        items.Add((object) index);
      UIMenu uiMenu1 = this.modMenuPool.AddSubMenu(this.Options, "Options");
      this.GUIMenus.Add(uiMenu1);
      UIMenu uiMenu2 = this.modMenuPool.AddSubMenu(this.Options, "Customization");
      this.GUIMenus.Add(uiMenu2);
      UIMenuListItem list = new UIMenuListItem("Tint ", items, 0);
      uiMenu2.AddItem((UIMenuItem) list);
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
      List<object> listofColors = new List<object>();
      foreach (int num in (VehicleColor[]) Enum.GetValues(typeof (VehicleColor)))
        listofColors.Add((object) (VehicleColor) num);
      UIMenu uiMenu3 = this.modMenuPool.AddSubMenu(this.Options, "Customization 2");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem CabColor1 = new UIMenuListItem("Primary Color ", listofColors, 0);
      uiMenu3.AddItem((UIMenuItem) CabColor1);
      UIMenuItem GetCabColor1 = new UIMenuItem("Get Avenger Primary Color");
      uiMenu3.AddItem(GetCabColor1);
      UIMenuItem GetCabColor2 = new UIMenuItem("Get Avenger Secondary Color");
      uiMenu3.AddItem(GetCabColor2);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == GetCabColor1 && (Entity) this.Avenger != (Entity) null)
        {
          this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Avenger.ini");
          int index1 = CabColor1.Index;
          Vehicle avenger = this.Avenger;
          // ISSUE: reference to a compiler-generated field
          if (WrokingAvenger.\u003C\u003Eo__113.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__113.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (WrokingAvenger)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num = (int) WrokingAvenger.\u003C\u003Eo__113.\u003C\u003Ep__0.Target((CallSite) WrokingAvenger.\u003C\u003Eo__113.\u003C\u003Ep__0, listofColors[index1]);
          avenger.PrimaryColor = (VehicleColor) num;
          this.CabPrimary = this.Avenger.PrimaryColor;
          this.SC.PrimaryColor = this.Avenger.PrimaryColor;
          this.SC.Config.SetValue<VehicleColor>("Configurations", "PrimaryColor", this.SC.PrimaryColor);
          this.SC.Config.Save();
        }
        if (item != GetCabColor2 || !((Entity) this.Avenger != (Entity) null))
          return;
        this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Avenger.ini");
        int index2 = CabColor1.Index;
        Vehicle avenger1 = this.Avenger;
        // ISSUE: reference to a compiler-generated field
        if (WrokingAvenger.\u003C\u003Eo__113.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WrokingAvenger.\u003C\u003Eo__113.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (WrokingAvenger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        int num1 = (int) WrokingAvenger.\u003C\u003Eo__113.\u003C\u003Ep__1.Target((CallSite) WrokingAvenger.\u003C\u003Eo__113.\u003C\u003Ep__1, listofColors[index2]);
        avenger1.SecondaryColor = (VehicleColor) num1;
        this.CabSecondary = this.Avenger.SecondaryColor;
        this.SC.SecondaryColor = this.Avenger.SecondaryColor;
        this.SC.Config.SetValue<VehicleColor>("Configurations", "SecondaryColor", this.SC.SecondaryColor);
        this.SC.Config.Save();
      });
      uiMenu2.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == noweapons)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          currentVehicle.SetMod(VehicleMod.Roof, -1, true);
          this.Weapons = -1;
          this.Config.SetValue<int>("Setup", "Weapons", this.Weapons);
          this.Config.Save();
        }
        if (item == Weapons2)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          currentVehicle.SetMod(VehicleMod.Roof, 1, true);
          this.Weapons = 1;
          this.Config.SetValue<int>("Setup", "Weapons", this.Weapons);
          this.Config.Save();
        }
        if (item == Weapons1)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          currentVehicle.SetMod(VehicleMod.Roof, 0, true);
          this.Weapons = 0;
          this.Config.SetValue<int>("Setup", "Weapons", this.Weapons);
          this.Config.Save();
        }
        if (item != Buy)
          return;
        this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Avenger.ini");
        int index1 = list.Index;
        Vehicle currentVehicle1 = Game.Player.Character.CurrentVehicle;
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle1.Handle, (InputArgument) 0);
        currentVehicle1.SetMod(VehicleMod.Livery, list.Index, true);
        this.Livery = list.Index;
        this.SC.LiveryId = list.Index;
        this.SC.Config.SetValue<int>("Configurations", "LiveryId", this.SC.LiveryId);
        this.SC.Config.Save();
      });
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Options3 && (Entity) this.Avenger != (Entity) null)
        {
          if (!this.Avenger.FreezePosition)
          {
            UI.Notify("Avenger Auto Pilot On");
            this.Avenger.FreezePosition = true;
          }
          else
          {
            UI.Notify("Avenger Auto Pilot Off");
            this.Avenger.FreezePosition = false;
          }
        }
        if (item == Options1 && (Entity) this.Avenger != (Entity) null)
          this.Avenger.OpenDoor(VehicleDoor.Trunk, false, false);
        if (item == Options0 && (Entity) this.Avenger != (Entity) null)
          this.Avenger.CloseDoor(VehicleDoor.Trunk, false);
        if (item != Options2)
          return;
        if ((Entity) this.Avenger != (Entity) null)
        {
          try
          {
            this.AvengerPos = this.Avenger.Position;
            this.Avenger.FreezePosition = true;
            this.InInterior = true;
            Game.Player.Character.Position = this.ExitAvenger;
            if ((Entity) this.VehicleinCargoBay != (Entity) null)
              this.VehicleinCargoBay.Delete();
            this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Storage//Vehicle.ini");
            this.SaveLoad.LoadAvengerVehicle();
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Critical Error~w~ : Oopps! somthing has gone wrong, please retry, ifGTAV has just loaded, this is normal, if it continues after please contact ~g~HKH191~w~");
          }
        }
      });
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

    public void SaveAvenger()
    {
      this.AvengerBought = 1;
      this.Config2.SetValue<int>("SpecialVehicles", "AvengerBought", this.AvengerBought);
      this.Config2.Save();
    }

    public void SpawnAvengerFromFacility(Vector3 Spawn)
    {
      if ((Entity) this.Avenger != (Entity) null)
        this.Avenger.Delete();
      this.AvengerSpawn = Spawn;
      this.AvengerPosSave = this.AvengerSpawn;
      this.X = this.AvengerPosSave.X;
      this.Config.SetValue<float>("Setup", "X", this.X);
      this.Y = this.AvengerPosSave.Y;
      this.Config.SetValue<float>("Setup", "Y", this.Y);
      this.Z = this.AvengerPosSave.Z;
      this.Config.SetValue<float>("Setup", "Z", this.Z);
      this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
      this.Config.SetValue<Vector3>("Setup", "AvengerPosition", this.AvengerPosSave);
      this.Config.Save();
      this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Avenger.ini");
      if (!((Entity) this.Avenger != (Entity) null))
        return;
      this.Avenger.Heading = this.VHeading;
    }

    public void SpawnAvengerAtFacility(Vector3 Spawn)
    {
      if ((Entity) this.Avenger != (Entity) null)
        this.Avenger.Delete();
      this.AvengerSpawn = Spawn;
      this.AvengerPosSave = this.AvengerSpawn;
      this.X = this.AvengerPosSave.X;
      this.Config.SetValue<float>("Setup", "X", this.X);
      this.Y = this.AvengerPosSave.Y;
      this.Config.SetValue<float>("Setup", "Y", this.Y);
      this.Z = this.AvengerPosSave.Z;
      this.Config.SetValue<float>("Setup", "Z", this.Z);
      this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
      this.Config.SetValue<Vector3>("Setup", "AvengerPosition", this.AvengerPosSave);
      this.Config.Save();
      this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Avenger.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Avenger.ini");
      this.LoadIniFile2("scripts//HKH191sBusinessMods//DoomsdayBusiness//FortZuncudo.ini");
      UI.Notify("Game : your Avenger will spawn at this Facility Next time you reload mods");
      Game.Player.Character.Position = Spawn;
      if (!((Entity) this.Avenger != (Entity) null))
        return;
      this.Avenger.Heading = this.VHeading;
    }

    public void SpawnAvenger()
    {
      if ((Entity) this.Avenger != (Entity) null)
        this.Avenger.Delete();
      if (this.CheckformobileAvenger)
      {
        Script.Wait(10);
        this.CheckformobileAvenger = false;
      }
      else if (!this.CheckformobileAvenger && this.AvengerBought == 1)
      {
        this.SC.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//FacilityStorage//Avenger.ini");
        this.X = this.Config.GetValue<float>("Setup", "X", this.X);
        this.Y = this.Config.GetValue<float>("Setup", "Y", this.Y);
        this.Z = this.Config.GetValue<float>("Setup", "Z", this.Z);
        this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
        this.Avenger = World.CreateVehicle(this.RequestModel(VehicleHash.Avenger), new Vector3(this.X, this.Y, this.Z));
        this.SC.Load(this.Avenger);
        this.Avenger.IsDriveable = true;
      }
      if (!((Entity) this.Avenger != (Entity) null))
        return;
      this.Avenger.Heading = this.VHeading;
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
            if (WrokingAvenger.\u003C\u003Eo__159.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              WrokingAvenger.\u003C\u003Eo__159.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (WrokingAvenger)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            string[] strArray = WrokingAvenger.\u003C\u003Eo__159.\u003C\u003Ep__0.Target((CallSite) WrokingAvenger.\u003C\u003Eo__159.\u003C\u003Ep__0, LogList[V.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
          if (WrokingAvenger.\u003C\u003Eo__159.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WrokingAvenger.\u003C\u003Eo__159.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (WrokingAvenger)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          string[] strArray = WrokingAvenger.\u003C\u003Eo__159.\u003C\u003Ep__1.Target((CallSite) WrokingAvenger.\u003C\u003Eo__159.\u003C\u003Ep__1, STlist[V2.Index]).Split(separator, StringSplitOptions.RemoveEmptyEntries);
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

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
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

    private void LoadinifileAvengerLoc(string iniName)
    {
      try
      {
        this.MainScriptConfig = ScriptSettings.Load(iniName);
        this.BusinessLocation = this.MainScriptConfig.GetValue<int>("Misc", "BusinessLocation", this.BusinessLocation);
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

    private void OnTick(object sender, EventArgs e)
    {
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(505f, 505f, 2505f)) < 10.0)
      {
        this.LoadinifileAvengerLoc("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
        this.X = this.OutsideSpawn.X;
        this.Config.SetValue<float>("Setup", "X", this.X);
        this.Y = this.OutsideSpawn.Y;
        this.Config.SetValue<float>("Setup", "Y", this.Y);
        this.Z = this.OutsideSpawn.Z;
        this.Config.SetValue<float>("Setup", "Z", this.Z);
        Script.Wait(1);
        this.SpawnAvenger();
        Script.Wait(1);
        Game.Player.Character.SetIntoVehicle(this.Avenger, VehicleSeat.Driver);
        Script.Wait(1);
      }
      if (!this.InInterior)
      {
        this.CheckGunlocker = false;
        if (this.CreatedChairs && !this.IsUsingSam)
        {
          this.CreatedChairs = false;
          if ((Entity) this.Chair1 != (Entity) null)
            this.Chair1.Delete();
          if ((Entity) this.Chair2 != (Entity) null)
            this.Chair2.Delete();
          if ((Entity) this.Chair3 != (Entity) null)
            this.Chair3.Delete();
          if ((Entity) this.Console1 != (Entity) null)
            this.Console1.Delete();
          if ((Entity) this.Console2 != (Entity) null)
            this.Console2.Delete();
          if ((Entity) this.Console3 != (Entity) null)
            this.Console3.Delete();
        }
      }
      if (this.InInterior)
      {
        if (this.SittinginSeat && !this.IsUsingSam)
        {
          int num = new System.Random().Next(0, 100);
          if (num < 33)
          {
            if (Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1) >= 1065353216)
            {
              string dict = "anim@amb@trailer@turret_controls@";
              WrokingAvenger.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              WrokingAvenger.LoadDict(dict);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "idle_a", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "idle_a", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "idle_a_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            }
          }
          if (num >= 33 && num < 66)
          {
            if (Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1) >= 1065353216)
            {
              string dict = "anim@amb@trailer@turret_controls@";
              WrokingAvenger.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              WrokingAvenger.LoadDict(dict);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "idle_b", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "idle_b", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "idle_b_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            }
          }
          if (num >= 66 && num < 100)
          {
            if (Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1) >= 1065353216)
            {
              string dict = "anim@amb@trailer@turret_controls@";
              WrokingAvenger.LoadDict(dict);
              Prop exitChair = this.ExitChair;
              WrokingAvenger.LoadDict(dict);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "idle_c", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "idle_c", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "idle_c_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
            }
          }
        }
        if (this.CreatedChairs)
        {
          if ((Entity) this.Chair1 != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.Chair1.Position) < 1.35000002384186)
          {
            if (!this.SittinginSeat)
              this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to Sit on Seat");
            if (this.SittinginSeat)
            {
              this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ Exit, ~INPUT_CONTEXT~ to use this Avenger Turret");
              if (Game.IsControlJustPressed(2, GTA.Control.Context))
              {
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop exitChair = this.ExitChair;
                WrokingAvenger.LoadDict(dict);
                int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.Console1, (InputArgument) num, (InputArgument) "computer_enter_control", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(3000);
                UI.Notify("Pos Rot " + this.Console1.Position.ToString() + "__" + this.Console1.Rotation.Z.ToString());
                this.CanFire = true;
                Game.Player.Character.IsVisible = false;
                this.IsUsingSam = true;
                Vector3 avengerSpawn = this.AvengerSpawn;
                avengerSpawn.Z += 4f;
                avengerSpawn.Y -= 6f;
                Game.Player.Character.Position = avengerSpawn;
                this.InInterior = false;
                avengerSpawn.X += 5f;
                this.Avenger.IsVisible = true;
                this.Avenger.IsInvincible = true;
                this.Avenger.FreezePosition = true;
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
                this.Chairin = 1;
                this.SittinginSeat = true;
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop chair1 = this.Chair1;
                this.ExitChair = this.Chair1;
                this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chair1.Position.X, (InputArgument) chair1.Position.Y, (InputArgument) chair1.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chair1.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "enter_left", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "enter_left", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chair1, (InputArgument) this.Scene1, (InputArgument) "enter_left_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              }
              else if (this.SittinginSeat)
              {
                this.SittinginSeat = false;
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop exitChair = this.ExitChair;
                this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "exit_left", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "exit_left", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "exit_left_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(3000);
                Game.Player.Character.Task.ClearAll();
              }
            }
          }
          if ((Entity) this.Chair2 != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.Chair2.Position) < 1.35000002384186)
          {
            if (!this.SittinginSeat)
              this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to Sit on Seat");
            if (this.SittinginSeat)
            {
              this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~Exit, ~INPUT_CONTEXT~  to use this Avenger Turret");
              if (Game.IsControlJustPressed(2, GTA.Control.Context))
              {
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop exitChair = this.ExitChair;
                WrokingAvenger.LoadDict(dict);
                int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.Console2, (InputArgument) num, (InputArgument) "computer_enter_control", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(3000);
                UI.Notify("Pos Rot " + this.Console2.Position.ToString() + "__" + this.Console2.Rotation.Z.ToString());
                this.CanFire = true;
                Game.Player.Character.IsVisible = false;
                this.IsUsingSam = true;
                Vector3 avengerSpawn = this.AvengerSpawn;
                avengerSpawn.Z += 4f;
                avengerSpawn.Y -= 6f;
                Game.Player.Character.Position = avengerSpawn;
                this.InInterior = false;
                avengerSpawn.X += 5f;
                this.Avenger.IsVisible = true;
                this.Avenger.IsInvincible = true;
                this.Avenger.FreezePosition = true;
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
                this.Chairin = 2;
                this.SittinginSeat = true;
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop chair2 = this.Chair2;
                this.ExitChair = this.Chair2;
                this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chair2.Position.X, (InputArgument) chair2.Position.Y, (InputArgument) chair2.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chair2.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "enter", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chair2, (InputArgument) this.Scene1, (InputArgument) "enter_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              }
              else if (this.SittinginSeat)
              {
                this.SittinginSeat = false;
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop exitChair = this.ExitChair;
                this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "exit", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) this.Scene1, (InputArgument) "exit_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(3000);
                Game.Player.Character.Task.ClearAll();
              }
            }
          }
          if ((Entity) this.Chair3 != (Entity) null && (double) World.GetDistance(Game.Player.Character.Position, this.Chair3.Position) < 1.35000002384186)
          {
            if (!this.SittinginSeat)
              this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to Sit on Seat");
            if (this.SittinginSeat)
            {
              this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~Exit, ~INPUT_CONTEXT~  to use this Avenger Turret");
              if (Game.IsControlJustPressed(2, GTA.Control.Context))
              {
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop exitChair = this.ExitChair;
                WrokingAvenger.LoadDict(dict);
                int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "computer_enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_enter", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) num, (InputArgument) "computer_enter_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) this.Console3, (InputArgument) num, (InputArgument) "computer_enter_control", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(3000);
                UI.Notify("Pos Rot " + this.Console3.Position.ToString() + "__" + this.Console3.Rotation.Z.ToString());
                this.CanFire = true;
                Game.Player.Character.IsVisible = false;
                this.IsUsingSam = true;
                Vector3 avengerSpawn = this.AvengerSpawn;
                avengerSpawn.Z += 4f;
                avengerSpawn.Y -= 6f;
                Game.Player.Character.Position = avengerSpawn;
                this.InInterior = false;
                avengerSpawn.X += 5f;
                this.Avenger.IsVisible = true;
                this.Avenger.IsInvincible = true;
                this.Avenger.FreezePosition = true;
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
                this.SittinginSeat = true;
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop chair3 = this.Chair3;
                this.ExitChair = this.Chair3;
                int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) chair3.Position.X, (InputArgument) chair3.Position.Y, (InputArgument) chair3.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) chair3.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "enter", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) chair3, (InputArgument) num, (InputArgument) "enter_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              }
              else if (this.SittinginSeat)
              {
                this.SittinginSeat = false;
                string dict = "anim@amb@trailer@turret_controls@";
                WrokingAvenger.LoadDict(dict);
                Prop exitChair = this.ExitChair;
                int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "exit", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) num, (InputArgument) "exit_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(3000);
                Game.Player.Character.Task.ClearAll();
              }
            }
          }
        }
      }
      if (this.InInterior && !this.CreatedChairs)
      {
        this.CreatedChairs = true;
        if ((Entity) this.Chair1 != (Entity) null)
          this.Chair1.Delete();
        if ((Entity) this.Chair2 != (Entity) null)
          this.Chair2.Delete();
        if ((Entity) this.Console1 != (Entity) null)
          this.Console1.Delete();
        if ((Entity) this.Console2 != (Entity) null)
          this.Console2.Delete();
        if ((Entity) this.Console3 != (Entity) null)
          this.Console3.Delete();
        this.CheckOcci("scripts//OpenCommandCenterInteriors.ini");
        bool flag1 = this.CheckOcciConfig.GetValue<bool>("Avenger", "Av1Active", false);
        bool flag2 = this.CheckOcciConfig.GetValue<bool>("Avenger", "Av2Active", false);
        bool flag3 = this.CheckOcciConfig.GetValue<bool>("Avenger", "Av3Active", false);
        if (flag2)
        {
          this.Chair1 = World.CreateProp(this.RequestModel("gr_prop_highendchair_gr_01a"), new Vector3(513.3959f, 4749.747f, -70f), new Vector3(0.0f, 0.0f, 27f), false, false);
          this.Chair1.FreezePosition = true;
          this.Console1 = World.CreateProp(this.RequestModel("gr_prop_gr_console_01"), new Vector3(513.3597f, 4748.983f, -69.25018f), new Vector3(0.0f, 0.0f, 170f), false, false);
        }
        if (flag1)
        {
          this.Chair2 = World.CreateProp(this.RequestModel("gr_prop_highendchair_gr_01a"), new Vector3(512.1855f, 4749.549f, -70f), new Vector3(0.0f, 0.0f, -60f), false, false);
          this.Chair2.FreezePosition = true;
          this.Console2 = World.CreateProp(this.RequestModel("gr_prop_gr_console_01"), new Vector3(511.4209f, 4749.545f, -69.25018f), new Vector3(0.0f, 0.0f, 82.68f), false, false);
        }
        if (flag3)
        {
          this.Chair3 = World.CreateProp(this.RequestModel("gr_prop_highendchair_gr_01a"), new Vector3(515.845f, 4751.207f, -70f), new Vector3(0.0f, 0.0f, -146f), false, false);
          this.Chair3.FreezePosition = true;
          this.Console3 = World.CreateProp(this.RequestModel("gr_prop_gr_console_01"), new Vector3(515.7878f, 4751.969f, -69.25018f), new Vector3(0.0f, 0.0f, -3.316f), false, false);
        }
        this.CheckOcci("scripts//OpenCommandCenterInteriors.ini");
        this.av7 = this.CheckOcciConfig.GetValue<int>("Avenger", "avcolor", this.av7);
        Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Chair1, (InputArgument) this.av7);
        Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Chair2, (InputArgument) this.av7);
        Function.Call(Hash._0x971DA0055324D033, (InputArgument) this.Chair3, (InputArgument) this.av7);
      }
      if ((Entity) this.Avenger != (Entity) null)
      {
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
          this.IsInCab = false;
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (Entity) Game.Player.Character.CurrentVehicle == (Entity) this.Avenger && !this.IsInCab)
        {
          this.IsInCab = true;
          this.Avenger.IsDriveable = true;
        }
      }
      this.OnKeyDown();
      if (this.InInterior)
      {
        if (!this.CheckGunlocker)
        {
          this.CheckGunlocker = true;
          this.CheckOcci("scripts//OpenCommandCenterInteriors.ini");
          this.Av4 = this.CheckOcciConfig.GetValue<bool>("Avenger", "Av4Active", this.Av4);
        }
        if (this.Av4)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to open Gun Locker");
          if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 80.0)
            World.DrawMarker(MarkerType.VerticalCylinder, this.GunLockerMarker, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 0.8f), this.MarkerColor);
          if ((double) World.GetDistance(Game.Player.Character.Position, this.GunLockerMarker) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context) && !this.weaponsMenu.Visible)
            this.weaponsMenu.Visible = !this.weaponsMenu.Visible;
        }
      }
      if (this.InInterior)
      {
        Vector3 vector3 = new Vector3(528.5f, 4750f, -70f);
        World.DrawMarker(MarkerType.VerticalCylinder, vector3, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 1f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, vector3) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ To Exit Avenger");
      }
      if ((Entity) this.Avenger != (Entity) null && (double) this.Avenger.Speed < 10.0)
      {
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
        {
          Vector3 offsetInWorldCoords = this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -8f, -3f));
          if ((double) World.GetDistance(Game.Player.Character.Position, offsetInWorldCoords) < 40.0)
            World.DrawMarker(MarkerType.VerticalCylinder, offsetInWorldCoords, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 1f), this.MarkerColor);
          if ((double) World.GetDistance(Game.Player.Character.Position, offsetInWorldCoords) < 2.0)
            this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to Enter the cargo bay, or ~INPUT_CONTEXT~ to enter Vehicle Menu");
          if (Game.IsControlJustPressed(2, GTA.Control.Context) && (double) World.GetDistance(Game.Player.Character.Position, offsetInWorldCoords) < 2.0)
          {
            this.Cab = this.Avenger;
            this.VehSpawn = this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, -3f));
            this.VMmainMenu.Visible = true;
          }
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vector3 offsetInWorldCoords = this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, -3f));
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
      if ((Entity) this.Avenger != (Entity) null && this.IsUsingSam)
      {
        Game.Player.Character.Position = this.Avenger.Position;
        this.TurretCamA = this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, 9.5f, -2.3f));
        this.TurretCamB = this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -1.8f, 1.2f));
        this.TurretCamC = this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -9.3f, -0.2f));
      }
      if (this.IsUsingSam || !this.InInterior)
        ;
      if (this.IsUsingSam)
      {
        WrokingAvenger.DrawScaleformTurret();
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
          this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ to Exit ~INPUT_JUMP~ to Fire");
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
      if (this.ResetMoc)
      {
        if ((Entity) this.Avenger != (Entity) null)
          this.Avenger.Delete();
        this.AvengerPosSave = this.NewAvengerLoc;
        this.X = this.NewAvengerLoc.X;
        this.Config.SetValue<float>("Setup", "X", this.X);
        this.Y = this.NewAvengerLoc.Y;
        this.Config.SetValue<float>("Setup", "Y", this.Y);
        this.Z = this.NewAvengerLoc.Z;
        this.Config.SetValue<float>("Setup", "Z", this.Z);
        this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
        this.Config.SetValue<Vector3>("Setup", "AvengerPosition", this.AvengerSpawn);
        this.Config.Save();
        this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Avenger.ini");
        Game.Player.Character.Position = this.AvengerSpawn;
        this.createdPed = false;
        this.AvengerAllreadyCreated = false;
        this.ResetMoc = false;
        this.SpawnAvenger();
        Script.Wait(100);
        if ((Entity) this.Avenger != (Entity) null)
        {
          Game.Player.Character.Position = this.OutsideSpawn;
          Game.Player.Character.SetIntoVehicle(this.Avenger, VehicleSeat.Driver);
        }
      }
      if (this.ReadIni)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2228f, 2399f, 12f)) < 10.0)
        {
          this.NewAvengerLoc = this.ZuncudoRiver1;
          this.OutsideSpawn = new Vector3(-2228f, 2399f, 12f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(-2f, 3346f, 40f)) < 10.0)
        {
          this.NewAvengerLoc = this.ZuncudoRiver;
          this.OutsideSpawn = new Vector3(-2f, 3346f, 40f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(20f, 6823f, 15f)) < 10.0)
        {
          this.NewAvengerLoc = this.Paleto;
          this.OutsideSpawn = new Vector3(20f, 6823f, 15f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1272f, 2833f, 48f)) < 10.0)
        {
          this.NewAvengerLoc = this.GSD1;
          this.OutsideSpawn = new Vector3(1272f, 2833f, 48f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2088f, 1760f, 104f)) < 10.0)
        {
          this.NewAvengerLoc = this.GSD2;
          this.OutsideSpawn = new Vector3(2088f, 1760f, 104f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(2754f, 3903f, 45f)) < 10.0)
        {
          this.NewAvengerLoc = this.GSD3;
          this.OutsideSpawn = new Vector3(2754f, 3903f, 45f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1.3f, 2598f, 85f)) < 10.0)
        {
          this.NewAvengerLoc = this.GSD4;
          this.OutsideSpawn = new Vector3(1.3f, 2598f, 85f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(3387f, 5508f, 25f)) < 10.0)
        {
          this.NewAvengerLoc = this.MountGordo;
          this.OutsideSpawn = new Vector3(3387f, 5508f, 25f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(1884f, 303f, 163f)) < 10.0)
        {
          this.NewAvengerLoc = this.Resorvoir;
          this.OutsideSpawn = new Vector3(1884f, 303f, 163f);
          this.ResetMoc = true;
          this.ReadIni = false;
        }
      }
      if (this.InInterior)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CabOptions) < 100.0)
          World.DrawMarker(MarkerType.VerticalCylinder, this.CabOptions, Vector3.Zero, Vector3.Zero, new Vector3(0.8f, 0.8f, 1f), this.MarkerColor);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.ExitAvenger) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_COVER~ To Exit Avenger");
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CabOptions) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ To Change Stored Vehicle");
      }
      if (this.LookingforAvenger && Game.Player.Character.CurrentVehicle.DisplayName == "AVENGER")
      {
        this.Avenger = Game.Player.Character.CurrentVehicle;
        this.LookingforAvenger = false;
      }
      if (!this.checkavenger)
      {
        if (this.AvengerBought == 0)
          this.AvengerBought = this.Config2.GetValue<int>("SpecialVehicles", "AvengerBought", this.AvengerBought);
        else if (this.AvengerBought == 1)
        {
          this.checkavenger = true;
          this.SetupMarker();
        }
      }
      if ((Entity) this.Avenger != (Entity) null)
        this.AvengerBlip.Position = this.Avenger.Position;
      if ((Entity) this.SaveLoad.SavedVehicle != (Entity) null)
        this.VehicleinCargoBay = this.SaveLoad.SavedVehicle;
      if ((Entity) this.VehicleinCargoBay != (Entity) null && this.VehicleinCargoBay.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
        this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Use Vehicle, Press ~INPUT_COVER~ to Save Vehicle");
      if (this.InInterior)
        World.DrawMarker(MarkerType.VerticalCylinder, this.ExitAvenger, Vector3.Zero, Vector3.Zero, new Vector3(1f, 1f, 0.8f), this.MarkerColor);
      Vector3 avengerSpawn1 = this.AvengerSpawn;
      if ((double) World.GetDistance(Game.Player.Character.Position, new Vector3(this.X, this.Y, this.Z)) < 100.0 && !this.createdPed && !this.AvengerAllreadyCreated)
      {
        this.AvengerAllreadyCreated = true;
        this.SpawnAvenger();
        this.createdPed = true;
      }
      if ((double) World.GetDistance(Game.Player.Character.Position, this.AvengerSpawn) <= 101.0 || !this.createdPed)
        return;
      if ((Entity) this.ClayPed != (Entity) null)
        this.ClayPed.Delete();
      this.createdPed = false;
    }

    public void Destroy()
    {
    }

    private void OnKeyDown()
    {
      if (this.InInterior && Game.IsControlJustPressed(2, GTA.Control.Cover) && (double) World.GetDistance(Game.Player.Character.Position, new Vector3(528.5f, 4750f, -70f)) < 2.0)
      {
        Script.Wait(200);
        this.InInterior = false;
        this.CheckformobileAvenger = true;
        this.AvengerAllreadyCreated = true;
        this.InInterior = false;
        if (this.SaveLoad != null)
          this.SaveLoad.Delete();
        this.X = this.AvengerPosSave.X;
        this.Config.SetValue<float>("Setup", "X", this.X);
        this.Y = this.AvengerPosSave.Y;
        this.Config.SetValue<float>("Setup", "Y", this.Y);
        this.Z = this.AvengerPosSave.Z;
        this.Config.SetValue<float>("Setup", "Z", this.Z);
        this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
        this.Avenger.FreezePosition = false;
        Game.Player.Character.Position = this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -8f, -3f));
      }
      if ((Entity) this.Avenger != (Entity) null && Game.IsControlJustPressed(2, GTA.Control.Cover) && (double) this.Avenger.Speed < 10.0)
      {
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -8f, -3f))) < 2.0)
          {
            try
            {
              this.AvengerPos = this.Avenger.Position;
              this.Avenger.FreezePosition = true;
              this.InInterior = true;
              Game.Player.Character.Position = new Vector3(528.5f, 4750f, -70f);
              if ((Entity) this.VehicleinCargoBay != (Entity) null)
                this.VehicleinCargoBay.Delete();
              this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Storage//Vehicle.ini");
              this.SaveLoad.LoadAvengerVehicle();
            }
            catch (Exception ex)
            {
              UI.Notify("~r~ Critical Error~w~ : Oopps! somthing has gone wrong, please retry, ifGTAV has just loaded, this is normal, if it continues after please contact ~g~HKH191~w~");
            }
          }
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -14f, -3f))) < 3.0)
          {
            try
            {
              this.InInterior = true;
              this.AvengerPos = this.Avenger.Position;
              this.AvengerPosSave = this.Avenger.Position;
              this.X = this.AvengerPosSave.X;
              this.Config.SetValue<float>("Setup", "X", this.X);
              this.Y = this.AvengerPosSave.Y;
              this.Config.SetValue<float>("Setup", "Y", this.Y);
              this.Z = this.AvengerPosSave.Z;
              this.Config.SetValue<float>("Setup", "Z", this.Z);
              this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
              this.Config.SetValue<Vector3>("Setup", "AvengerPosition", this.AvengerPosSave);
              this.Config.Save();
              this.VHeading = this.Avenger.Heading;
              this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
              this.Config.Save();
              this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Storage//Vehicle.ini");
              this.SaveLoad.SaveWithoutDelete();
              Script.Wait(50);
              Game.Player.Character.Position = this.ExitAvenger;
              this.InInterior = true;
              if ((Entity) this.VehicleinCargoBay != (Entity) null)
                this.VehicleinCargoBay.Delete();
              this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Storage//Vehicle.ini");
              this.SaveLoad.LoadAvengerVehicle();
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
        if (Game.IsControlPressed(2, GTA.Control.Duck))
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
            UI.Notify("Doomsday Heist Business - Working Avenger : Precission Off");
          }
          else if (!this.usePrecision)
          {
            this.usePrecision = true;
            UI.Notify("Doomsday Heist Business - Working Avenger : Precission On");
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
      if (Game.IsControlJustPressed(2, GTA.Control.Cover))
      {
        if (this.IsUsingSam)
        {
          this.IsUsingSam = false;
          Game.Player.Character.IsInvincible = false;
          Game.Player.Character.IsVisible = true;
          this.InInterior = true;
          Game.Player.Character.Position = this.CabOptions;
          Function.Call(Hash._0x07E5B515DB0636FC, (InputArgument) 0, (InputArgument) 0, (InputArgument) 3000, (InputArgument) 1, (InputArgument) 0);
          this.DroneCam.Destroy();
          this.DisplayHelpTextThisFrame("Deactivating SAM");
          string dict = "anim@amb@trailer@turret_controls@";
          WrokingAvenger.LoadDict(dict);
          Prop exitChair = this.ExitChair;
          WrokingAvenger.LoadDict(dict);
          int num = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) exitChair.Position.X, (InputArgument) exitChair.Position.Y, (InputArgument) exitChair.Position.Z, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) exitChair.Rotation.Z, (InputArgument) 2);
          Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) "computer_exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) num, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) num));
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) num, (InputArgument) "computer_exit", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) exitChair, (InputArgument) num, (InputArgument) "computer_exit_chair", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
          Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Function.Call<Prop>(Hash._0xE143FA2249364369, (InputArgument) this.ExitChair.Position.X, (InputArgument) this.ExitChair.Position.Y, (InputArgument) this.ExitChair.Position.Z, (InputArgument) 3f, (InputArgument) Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) "gr_prop_gr_console_01"), (InputArgument) 0, (InputArgument) 0, (InputArgument) 0), (InputArgument) num, (InputArgument) "computer_enter_control", (InputArgument) WrokingAvenger.LoadDict(dict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
        }
        else if (this.IsUsingSam)
          ;
      }
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
      if ((Game.IsControlPressed(2, GTA.Control.Jump) || Game.IsControlPressed(2, GTA.Control.Attack)) && (this.IsUsingSam && this.CanFire))
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
      if (Game.IsControlJustPressed(2, GTA.Control.Context) && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null && (Game.Player.Character.CurrentVehicle.DisplayName == "AVENGER" && (double) World.GetDistance(Game.Player.Character.Position, new Vector3(488f, 4789f, -56f)) < 10.0))
        this.ReadIni = true;
      if (this.InInterior)
      {
        if ((Entity) this.VehicleinCargoBay != (Entity) null && this.VehicleinCargoBay.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && Game.IsControlJustPressed(2, GTA.Control.Cover))
          this.SaveLoad.SaveWithoutDelete();
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CabOptions) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context) && !this.mainMenu2.Visible)
          this.mainMenu2.Visible = !this.mainMenu2.Visible;
      }
      if ((Entity) this.Avenger != (Entity) null && this.Avenger.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && (Game.IsControlJustPressed(2, GTA.Control.VehicleExit) && this.Avenger.IsAlive))
      {
        this.AvengerPosSave = this.Avenger.Position;
        this.X = this.AvengerPosSave.X;
        this.Config.SetValue<float>("Setup", "X", this.X);
        this.Y = this.AvengerPosSave.Y;
        this.Config.SetValue<float>("Setup", "Y", this.Y);
        this.Z = this.AvengerPosSave.Z;
        this.Config.SetValue<float>("Setup", "Z", this.Z);
        this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
        this.Config.SetValue<Vector3>("Setup", "AvengerPosition", this.AvengerPosSave);
        this.Config.Save();
        this.VHeading = this.Avenger.Heading;
        this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
        this.Config.Save();
      }
      if ((Entity) this.VehicleinCargoBay != (Entity) null && this.VehicleinCargoBay.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && Game.IsControlJustPressed(2, GTA.Control.Context))
      {
        this.CheckformobileAvenger = true;
        this.AvengerAllreadyCreated = true;
        Game.Player.Character.CurrentVehicle.IsDriveable = true;
        Game.Player.Character.CurrentVehicle.Position = this.Avenger.GetOffsetInWorldCoords(new Vector3(0.0f, -25f, 0.0f));
        this.Avenger.FreezePosition = false;
        Game.Player.Character.CurrentVehicle.PlaceOnGround();
        this.AvengerPosSave = this.Avenger.Position;
        this.X = this.AvengerPosSave.X;
        this.Config.SetValue<float>("Setup", "X", this.X);
        this.Y = this.AvengerPosSave.Y;
        this.Config.SetValue<float>("Setup", "Y", this.Y);
        this.Z = this.AvengerPosSave.Z;
        this.Config.SetValue<float>("Setup", "Z", this.Z);
        this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
        this.InInterior = false;
        this.Config.SetValue<Vector3>("Setup", "AvengerPosition", this.AvengerPosSave);
        this.Config.Save();
        this.VHeading = this.Avenger.Heading;
        this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
        this.Config.Save();
        this.VehicleinCargoBay = (Vehicle) null;
        this.SaveLoad.SavedVehicle = (Vehicle) null;
      }
      if (Game.IsControlJustPressed(2, GTA.Control.VehicleHeadlight))
      {
        if (this.modMenuPool != null)
          this.modMenuPool.ProcessMenus();
        if ((Entity) this.Avenger != (Entity) null && this.Avenger.GetPedOnSeat(VehicleSeat.Driver).IsPlayer)
        {
          if (!this.mainMenu.Visible)
            this.mainMenu.Visible = !this.mainMenu.Visible;
          this.CurrentCommandCenter = "Avenger";
        }
      }
      if (!Game.IsControlJustPressed(2, GTA.Control.Cover))
        return;
      if (this.InInterior && (double) World.GetDistance(Game.Player.Character.Position, this.ExitAvenger) < 2.0)
      {
        this.InInterior = false;
        this.CheckformobileAvenger = true;
        this.AvengerAllreadyCreated = true;
        this.InInterior = false;
        this.SaveLoad.Delete();
        this.X = this.AvengerPosSave.X;
        this.Config.SetValue<float>("Setup", "X", this.X);
        this.Y = this.AvengerPosSave.Y;
        this.Config.SetValue<float>("Setup", "Y", this.Y);
        this.Z = this.AvengerPosSave.Z;
        this.Config.SetValue<float>("Setup", "Z", this.Z);
        this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
        Game.Player.Character.SetIntoVehicle(this.Avenger, VehicleSeat.Driver);
        this.Avenger.FreezePosition = false;
      }
      if ((Entity) this.Avenger != (Entity) null && ((double) World.GetDistance(Game.Player.Character.Position, this.Avenger.Position) < 5.0 && !this.Avenger.GetPedOnSeat(VehicleSeat.Driver).IsPlayer && this.Avenger.IsDoorOpen(VehicleDoor.Trunk)))
      {
        if (this.Avenger.IsAlive)
        {
          try
          {
            this.InInterior = true;
            this.AvengerPos = this.Avenger.Position;
            this.AvengerPosSave = this.Avenger.Position;
            this.X = this.AvengerPosSave.X;
            this.Config.SetValue<float>("Setup", "X", this.X);
            this.Y = this.AvengerPosSave.Y;
            this.Config.SetValue<float>("Setup", "Y", this.Y);
            this.Z = this.AvengerPosSave.Z;
            this.Config.SetValue<float>("Setup", "Z", this.Z);
            this.AvengerSpawn = new Vector3(this.X, this.Y, this.Z);
            this.Config.SetValue<Vector3>("Setup", "AvengerPosition", this.AvengerPosSave);
            this.Config.Save();
            this.VHeading = this.Avenger.Heading;
            this.Config.SetValue<float>("Setup", "VHeading", this.VHeading);
            this.Config.Save();
            this.SaveLoad.VehicleId = Game.Player.Character.CurrentVehicle;
            this.SaveLoad.RoofId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Roof);
            this.SaveLoad.Save();
            Script.Wait(50);
            this.InInterior = true;
            Game.Player.Character.Position = this.ExitAvenger;
            this.InInterior = true;
            if ((Entity) this.VehicleinCargoBay != (Entity) null)
              this.VehicleinCargoBay.Delete();
            this.SaveLoad.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//WorkingAvenger//Storage//Vehicle.ini");
            this.SaveLoad.LoadAvengerVehicle();
          }
          catch (Exception ex)
          {
            UI.Notify("~r~ Critical Error~w~ : Oopps! somthing has gone wrong, please retry, ifGTAV has just loaded, this is normal, if it continues after please contact ~g~HKH191~w~");
          }
        }
      }
    }
  }
}
