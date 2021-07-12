using GTA;
using GTA.Math;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace HKH191SBusinessHelper
{
  internal class SpecializationMenu : Script
  {
    public MenuPool modMenuPool;
    public UIMenu mainMenu;
    public UIMenu VehicleMenu;
    public ScriptSettings Config;
    public Vehicle VehicleId;
    public string VehicleName;
    public int[] RoofId;
    public int[] AerialsId;
    public int[] AirfilterId;
    public int[] ArchCoverId;
    public int[] ArmorId;
    public int[] BackWheelsId;
    public int[] BrakesId;
    public int[] ColumnShifterLeversId;
    public int[] DashboardId;
    public int[] DialDesignId;
    public int[] DoorSpeekersId;
    public int[] EngineId;
    public int[] EngineBlockId;
    public int[] ExaustId;
    public int[] FenderId;
    public int[] FrameId;
    public int[] FrontBumperId;
    public int[] FrontWheelsId;
    public int[] GrilleId;
    public int[] HoodId;
    public int[] HornsId;
    public int[] HydralicsId;
    public int[] LiveryId;
    public int[] OrnamentsId;
    public int[] PlaquesId;
    public int[] Plateholder;
    public int[] RearBumperId;
    public int[] RightFenderId;
    public int[] SeatsId;
    public int[] SideSkirt;
    public int[] speakers;
    public int[] SpoilersId;
    public int[] SteeringWheelId;
    public int[] StrutId;
    public int[] SuspensionId;
    public int[] TankId;
    public int[] TransmissionId;
    public int[] TrimId;
    public int[] TrimDesignId;
    public int[] TrunkId;
    public int[] VanityPlatesId;
    public int[] WindowId;
    public VehicleColor[] Wheelcolour;
    public VehicleColor[] DashBoardColour;
    public VehicleColor[] PearlCent;
    public Color NeonColour;
    public VehicleColor[] PrimaryColor;
    public VehicleColor[] SecondaryColor;
    public bool HasTurbo;
    public bool HasXenonLights;
    public bool HasTireSmoke;
    public VehicleWindowTint TintId;
    public string PlanteNo;
    public int Blades;
    public int LightColor;
    public string VehicleHash;
    public bool TurboActive;
    public Color NeonColor;
    public bool RightNeonOn;
    public bool LeftNeonOn;
    public bool FrontNeonOn;
    public bool BackNeonOn;
    public string ModNamestring;
    private List<object> TypeOfMod = new List<object>();
    public List<Vector3> InteriorLocs = new List<Vector3>();
    public Keys Key1;
    public bool UseAnywhere;
    public bool IsDisabled;
    public List<Vector3> VehicleLocations = new List<Vector3>();
    public bool isinInterior;
    public Vector3 CurrentInt;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();

    public void SetupVehicleLocs()
    {
      this.VehicleLocations.Add(new Vector3(1004.98f, -3159.65f, -40f));
      this.VehicleLocations.Add(new Vector3(1004.98f, -3162.65f, -40f));
      this.VehicleLocations.Add(new Vector3(1000.51f, -3170.82f, -40f));
      this.VehicleLocations.Add(new Vector3(1002.88f, -3170.65f, -40f));
      this.VehicleLocations.Add(new Vector3(-75f, -819f, 284f));
      this.VehicleLocations.Add(new Vector3(-1578f, -577f, 104f));
      this.VehicleLocations.Add(new Vector3(-144f, -594f, 166f));
      this.VehicleLocations.Add(new Vector3(-1389f, -473f, 78f));
      this.VehicleLocations.Add(new Vector3(853.661f, -3235.2f, -98f));
      this.VehicleLocations.Add(new Vector3(-1266.4f, -3014.55f, -48f));
      this.VehicleLocations.Add(new Vector3(-1279.21f, -3031.65f, -48f));
      this.VehicleLocations.Add(new Vector3(-1254.5f, -3034.5f, -48f));
      this.VehicleLocations.Add(new Vector3(-1276.6f, -3003.17f, -48f));
      this.VehicleLocations.Add(new Vector3(-1255.51f, -3003.06f, -48f));
      this.VehicleLocations.Add(new Vector3(-1266.44f, -2990.81f, -48f));
      this.VehicleLocations.Add(new Vector3(-1278.36f, -2989.93f, -48f));
      this.VehicleLocations.Add(new Vector3(-1254.87f, -2986.58f, -48f));
      this.VehicleLocations.Add(new Vector3(-1266.9f, -2978.2f, -48f));
      this.VehicleLocations.Add(new Vector3(-1256.58f, -2973.8f, -48f));
      this.VehicleLocations.Add(new Vector3(-1276.78f, -2972.16f, -48f));
      this.VehicleLocations.Add(new Vector3(-1266.9f, -3043.39f, -48f));
      this.VehicleLocations.Add(new Vector3(-1241.94f, -2982.58f, -48f));
      this.VehicleLocations.Add(new Vector3(-1238.94f, -2982.58f, -48f));
      this.VehicleLocations.Add(new Vector3(-1235.94f, -2982.58f, -48f));
      this.VehicleLocations.Add(new Vector3(-1232.94f, -2982.58f, -48f));
      this.VehicleLocations.Add(new Vector3(470.977f, 4800.9f, -53.9f));
      this.VehicleLocations.Add(new Vector3(512.772f, 4786.44f, -52f));
      this.VehicleLocations.Add(new Vector3(476.432f, 4846.24f, -52f));
      this.VehicleLocations.Add(new Vector3(478.85f, 4825.403f, -58f));
      this.VehicleLocations.Add(new Vector3(467.277f, 4810.27f, -58f));
      this.VehicleLocations.Add(new Vector3(467.02f, 4815.15f, -58f));
      this.VehicleLocations.Add(new Vector3(455.597f, 4819.05f, -53f));
      this.VehicleLocations.Add(new Vector3(488.663f, 4789.05f, -57f));
      this.VehicleLocations.Add(new Vector3(159f, 5180f, -90f));
      this.VehicleLocations.Add(new Vector3(178f, 5189.4f, -90f));
      this.VehicleLocations.Add(new Vector3(161f, 5171f, -90f));
      this.VehicleLocations.Add(new Vector3(177f, 5171f, -90f));
      this.VehicleLocations.Add(new Vector3(159f, 5158f, -90f));
      this.VehicleLocations.Add(new Vector3(160f, 5201f, -90f));
      this.VehicleLocations.Add(new Vector3(160f, 5189f, -90f));
      this.VehicleLocations.Add(new Vector3(178f, 5201f, -90f));
      this.VehicleLocations.Add(new Vector3(160f, 5207f, -90f));
      this.VehicleLocations.Add(new Vector3(178f, 5158f, -90f));
      this.VehicleLocations.Add(new Vector3(159f, 5187f, 10f));
      this.VehicleLocations.Add(new Vector3(162f, 5196f, 10f));
      this.VehicleLocations.Add(new Vector3(163f, 5208f, 10f));
      this.VehicleLocations.Add(new Vector3(163f, 5214f, 10f));
      this.VehicleLocations.Add(new Vector3(180f, 5208f, 10f));
      this.VehicleLocations.Add(new Vector3(181f, 5196f, 10f));
      this.VehicleLocations.Add(new Vector3(183f, 5187f, 10f));
      this.VehicleLocations.Add(new Vector3(181f, 5177f, 10f));
      this.VehicleLocations.Add(new Vector3(181f, 5165f, 10f));
      this.VehicleLocations.Add(new Vector3(163f, 5165f, 10f));
      this.VehicleLocations.Add(new Vector3(1103f, -2996f, -39f));
      this.VehicleLocations.Add(new Vector3(-1420f, -3016f, -79f));
      this.VehicleLocations.Add(new Vector3(522.645f, 4750.41f, -68.996f));
    }

    public void SetupInteriors()
    {
      this.InteriorLocs.Add(new Vector3(483f, 4810f, -59f));
      this.InteriorLocs.Add(new Vector3(1004f, -3154f, -39f));
      this.InteriorLocs.Add(new Vector3(853f, -3235f, -99f));
      this.InteriorLocs.Add(new Vector3(975f, -3001f, -39f));
      this.InteriorLocs.Add(new Vector3(-1267f, -3013f, -48f));
      this.InteriorLocs.Add(new Vector3(205f, 5180f, -89f));
      this.InteriorLocs.Add(new Vector3(170f, 5190f, 11f));
      this.InteriorLocs.Add(new Vector3(-143f, -596f, 166f));
      this.InteriorLocs.Add(new Vector3(-73f, -821f, 284f));
      this.InteriorLocs.Add(new Vector3(-1578f, -576f, 105f));
      this.InteriorLocs.Add(new Vector3(-1391f, -473f, 78f));
      this.InteriorLocs.Add(new Vector3(-1420f, -3016f, -79f));
      this.InteriorLocs.Add(new Vector3(522f, 4750f, -70f));
      this.InteriorLocs.Add(new Vector3(1103f, -2996f, -39f));
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    public SpecializationMenu()
    {
      this.CreateBanner();
      this.LoadIniFile("scripts//HKH191sBusinessMods//BusinessHelper//SpecializationMenu.ini");
      this.SetupInteriors();
      this.SetupVehicleLocs();
      this.TypeOfMod.Add((object) -1);
      this.TypeOfMod.Add((object) 0);
      this.TypeOfMod.Add((object) 1);
      this.Tick += new EventHandler(this.OnTick);
      this.KeyDown += new KeyEventHandler(this.onKeyDown);
      this.Interval = 1;
      this.modMenuPool = new MenuPool();
      this.mainMenu = new UIMenu("Specialization Menu", "Select an Option");
      this.GUIMenus.Add(this.mainMenu);
      this.modMenuPool.Add(this.mainMenu);
      this.VehicleMenu = this.modMenuPool.AddSubMenu(this.mainMenu, "Vehicle Options");
      this.GUIMenus.Add(this.VehicleMenu);
      this.SetupMenu();
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    public void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.Key1 = this.Config.GetValue<Keys>("Configurations", "Key1", this.Key1);
        this.UseAnywhere = this.Config.GetValue<bool>("Configurations", "UseAnywhere", this.UseAnywhere);
        this.IsDisabled = this.Config.GetValue<bool>("Configurations", "IsDisabled", this.IsDisabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void onKeyDown(object sender, KeyEventArgs e)
    {
      if (this.IsDisabled)
        return;
      if (!this.UseAnywhere)
      {
        if (this.isinInterior && e.KeyCode == this.Key1)
          this.SetupVehicle();
        foreach (Vector3 interiorLoc in this.InteriorLocs)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, interiorLoc) < 30.0)
          {
            this.isinInterior = true;
            this.CurrentInt = interiorLoc;
          }
        }
        foreach (Vector3 interiorLoc in this.InteriorLocs)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, interiorLoc) < 300.0 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null && e.KeyCode == Keys.E)
          {
            this.isinInterior = false;
            this.CurrentInt = new Vector3(0.0f, 0.0f, -1000f);
          }
        }
      }
      if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null && this.UseAnywhere && e.KeyCode == this.Key1)
        this.SetupVehicle();
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public void CheckIfInterior(Vector3 Pos)
    {
      bool flag = false;
      if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        foreach (Vector3 vehicleLocation in this.VehicleLocations)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, vehicleLocation) < 5.0)
          {
            flag = true;
            break;
          }
        }
      }
      if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
        flag = false;
      if (flag)
      {
        this.CurrentInt = Pos;
        this.isinInterior = true;
        if (this.modMenuPool.IsAnyMenuOpen() && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Game.Player.Character.CurrentVehicle.IsDriveable = true;
          Game.Player.Character.CurrentVehicle.FreezePosition = true;
        }
        if (!this.modMenuPool.IsAnyMenuOpen() && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Game.Player.Character.CurrentVehicle.IsDriveable = false;
          Game.Player.Character.CurrentVehicle.FreezePosition = false;
        }
      }
      if (flag)
        return;
      this.isinInterior = false;
      this.CurrentInt = new Vector3(0.0f, 0.0f, -1000f);
      if (!this.modMenuPool.IsAnyMenuOpen() && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
      {
        Game.Player.Character.CurrentVehicle.IsDriveable = true;
        Game.Player.Character.CurrentVehicle.FreezePosition = false;
      }
      if (this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.CloseAllMenus();
    }

    public void OnTick(object sender, EventArgs e)
    {
      if (this.modMenuPool != null && this.modMenuPool.IsAnyMenuOpen())
        this.modMenuPool.ProcessMenus();
      foreach (Vector3 interiorLoc in this.InteriorLocs)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, interiorLoc) < 100.0)
          this.CheckIfInterior(Game.Player.Character.Position);
      }
      Vector3 currentInt = this.CurrentInt;
      if (true)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentInt) > 100.0 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          this.CheckIfInterior(Game.Player.Character.Position);
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentInt) < 100.0 && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
          this.CheckIfInterior(Game.Player.Character.Position);
      }
      if (!((Entity) Game.Player.Character.CurrentVehicle == (Entity) null) || !this.modMenuPool.IsAnyMenuOpen())
        return;
      this.modMenuPool.CloseAllMenus();
    }

    public void SetupVehicle()
    {
      if (!((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
        return;
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      this.RoofId = new int[currentVehicle.GetModCount(VehicleMod.Roof)];
      for (int index = 0; index < this.RoofId.Length; ++index)
        this.RoofId[index] = index;
      this.AerialsId = new int[currentVehicle.GetModCount(VehicleMod.Aerials)];
      for (int index = 0; index < this.AerialsId.Length; ++index)
        this.AerialsId[index] = index;
      this.AirfilterId = new int[currentVehicle.GetModCount(VehicleMod.AirFilter)];
      for (int index = 0; index < this.AirfilterId.Length; ++index)
        this.AirfilterId[index] = index;
      this.ArchCoverId = new int[currentVehicle.GetModCount(VehicleMod.ArchCover)];
      for (int index = 0; index < this.ArchCoverId.Length; ++index)
        this.ArchCoverId[index] = index;
      this.ArmorId = new int[currentVehicle.GetModCount(VehicleMod.Armor)];
      for (int index = 0; index < this.ArmorId.Length; ++index)
        this.ArmorId[index] = index;
      this.BackWheelsId = new int[currentVehicle.GetModCount(VehicleMod.BackWheels)];
      for (int index = 0; index < this.BackWheelsId.Length; ++index)
        this.BackWheelsId[index] = index;
      this.BrakesId = new int[currentVehicle.GetModCount(VehicleMod.Brakes)];
      for (int index = 0; index < this.BrakesId.Length; ++index)
        this.BrakesId[index] = index;
      this.ColumnShifterLeversId = new int[currentVehicle.GetModCount(VehicleMod.ColumnShifterLevers)];
      for (int index = 0; index < this.ColumnShifterLeversId.Length; ++index)
        this.ColumnShifterLeversId[index] = index;
      this.DashboardId = new int[currentVehicle.GetModCount(VehicleMod.Dashboard)];
      for (int index = 0; index < this.DashboardId.Length; ++index)
        this.DashboardId[index] = index;
      this.DialDesignId = new int[currentVehicle.GetModCount(VehicleMod.DialDesign)];
      for (int index = 0; index < this.DialDesignId.Length; ++index)
        this.DialDesignId[index] = index;
      this.DoorSpeekersId = new int[currentVehicle.GetModCount(VehicleMod.DoorSpeakers)];
      for (int index = 0; index < this.DoorSpeekersId.Length; ++index)
        this.DoorSpeekersId[index] = index;
      this.EngineId = new int[currentVehicle.GetModCount(VehicleMod.Engine)];
      for (int index = 0; index < this.EngineId.Length; ++index)
        this.EngineId[index] = index;
      this.EngineBlockId = new int[currentVehicle.GetModCount(VehicleMod.EngineBlock)];
      for (int index = 0; index < this.EngineBlockId.Length; ++index)
        this.EngineBlockId[index] = index;
      this.ExaustId = new int[currentVehicle.GetModCount(VehicleMod.Exhaust)];
      for (int index = 0; index < this.ExaustId.Length; ++index)
        this.ExaustId[index] = index;
      this.FenderId = new int[currentVehicle.GetModCount(VehicleMod.Fender)];
      for (int index = 0; index < this.FenderId.Length; ++index)
        this.FenderId[index] = index;
      this.FrameId = new int[currentVehicle.GetModCount(VehicleMod.Frame)];
      for (int index = 0; index < this.FrameId.Length; ++index)
        this.FrameId[index] = index;
      this.FrontBumperId = new int[currentVehicle.GetModCount(VehicleMod.FrontBumper)];
      for (int index = 0; index < this.FrontBumperId.Length; ++index)
        this.FrontBumperId[index] = index;
      this.FrontWheelsId = new int[currentVehicle.GetModCount(VehicleMod.FrontWheels)];
      for (int index = 0; index < this.FrontWheelsId.Length; ++index)
        this.FrontWheelsId[index] = index;
      this.GrilleId = new int[currentVehicle.GetModCount(VehicleMod.Grille)];
      for (int index = 0; index < this.GrilleId.Length; ++index)
        this.GrilleId[index] = index;
      this.HoodId = new int[currentVehicle.GetModCount(VehicleMod.Hood)];
      for (int index = 0; index < this.HoodId.Length; ++index)
        this.HoodId[index] = index;
      this.HornsId = new int[currentVehicle.GetModCount(VehicleMod.Horns)];
      for (int index = 0; index < this.HornsId.Length; ++index)
        this.HornsId[index] = index;
      this.HydralicsId = new int[currentVehicle.GetModCount(VehicleMod.Hydraulics)];
      for (int index = 0; index < this.HydralicsId.Length; ++index)
        this.HydralicsId[index] = index;
      this.LiveryId = new int[currentVehicle.GetModCount(VehicleMod.Livery)];
      for (int index = 0; index < this.LiveryId.Length; ++index)
        this.LiveryId[index] = index;
      this.OrnamentsId = new int[currentVehicle.GetModCount(VehicleMod.Ornaments)];
      for (int index = 0; index < this.OrnamentsId.Length; ++index)
        this.OrnamentsId[index] = index;
      this.PlaquesId = new int[currentVehicle.GetModCount(VehicleMod.Plaques)];
      for (int index = 0; index < this.PlaquesId.Length; ++index)
        this.PlaquesId[index] = index;
      this.Plateholder = new int[currentVehicle.GetModCount(VehicleMod.PlateHolder)];
      for (int index = 0; index < this.Plateholder.Length; ++index)
        this.Plateholder[index] = index;
      this.RearBumperId = new int[currentVehicle.GetModCount(VehicleMod.RearBumper)];
      for (int index = 0; index < this.RearBumperId.Length; ++index)
        this.RearBumperId[index] = index;
      this.RightFenderId = new int[currentVehicle.GetModCount(VehicleMod.RightFender)];
      for (int index = 0; index < this.RightFenderId.Length; ++index)
        this.RightFenderId[index] = index;
      this.SeatsId = new int[currentVehicle.GetModCount(VehicleMod.Seats)];
      for (int index = 0; index < this.SeatsId.Length; ++index)
        this.SeatsId[index] = index;
      this.SideSkirt = new int[currentVehicle.GetModCount(VehicleMod.SideSkirt)];
      for (int index = 0; index < this.SideSkirt.Length; ++index)
        this.SideSkirt[index] = index;
      this.speakers = new int[currentVehicle.GetModCount(VehicleMod.Speakers)];
      for (int index = 0; index < this.speakers.Length; ++index)
        this.speakers[index] = index;
      this.SpoilersId = new int[currentVehicle.GetModCount(VehicleMod.Speakers)];
      for (int index = 0; index < this.SpoilersId.Length; ++index)
        this.SpoilersId[index] = index;
      this.SteeringWheelId = new int[currentVehicle.GetModCount(VehicleMod.SteeringWheels)];
      for (int index = 0; index < this.SteeringWheelId.Length; ++index)
        this.SteeringWheelId[index] = index;
      this.StrutId = new int[currentVehicle.GetModCount(VehicleMod.Struts)];
      for (int index = 0; index < this.StrutId.Length; ++index)
        this.StrutId[index] = index;
      this.SuspensionId = new int[currentVehicle.GetModCount(VehicleMod.Suspension)];
      for (int index = 0; index < this.SuspensionId.Length; ++index)
        this.SuspensionId[index] = index;
      this.TankId = new int[currentVehicle.GetModCount(VehicleMod.Tank)];
      for (int index = 0; index < this.TankId.Length; ++index)
        this.TankId[index] = index;
      this.TransmissionId = new int[currentVehicle.GetModCount(VehicleMod.Transmission)];
      for (int index = 0; index < this.TransmissionId.Length; ++index)
        this.TransmissionId[index] = index;
      this.TrimId = new int[currentVehicle.GetModCount(VehicleMod.Trim)];
      for (int index = 0; index < this.TrimId.Length; ++index)
        this.TrimId[index] = index;
      this.TrimDesignId = new int[currentVehicle.GetModCount(VehicleMod.TrimDesign)];
      for (int index = 0; index < this.TrimDesignId.Length; ++index)
        this.TrimDesignId[index] = index;
      this.TrunkId = new int[currentVehicle.GetModCount(VehicleMod.Trunk)];
      for (int index = 0; index < this.TrunkId.Length; ++index)
        this.TrunkId[index] = index;
      this.VanityPlatesId = new int[currentVehicle.GetModCount(VehicleMod.VanityPlates)];
      for (int index = 0; index < this.VanityPlatesId.Length; ++index)
        this.VanityPlatesId[index] = index;
      this.WindowId = new int[currentVehicle.GetModCount(VehicleMod.Windows)];
      for (int index = 0; index < this.WindowId.Length; ++index)
        this.WindowId[index] = index;
      if (!this.modMenuPool.IsAnyMenuOpen())
        this.mainMenu.Visible = !this.mainMenu.Visible;
    }

    public int[] GetModsforType(VehicleMod mod) => (Entity) Game.Player.Character.CurrentVehicle != (Entity) null ? new int[Game.Player.Character.CurrentVehicle.GetModCount(mod)] : (int[]) null;

    public void SetupMenu()
    {
      List<object> items = new List<object>();
      items.Add((object) 0);
      items.Add((object) 1);
      items.Add((object) 2);
      items.Add((object) 3);
      items.Add((object) 4);
      items.Add((object) 5);
      items.Add((object) 6);
      items.Add((object) 7);
      items.Add((object) 8);
      items.Add((object) 9);
      items.Add((object) 10);
      items.Add((object) 11);
      items.Add((object) 12);
      items.Add((object) (int) byte.MaxValue);
      List<object> listofMods = new List<object>();
      foreach (int num in (VehicleMod[]) Enum.GetValues(typeof (VehicleMod)))
        listofMods.Add((object) (VehicleMod) num);
      List<object> Colors = new List<object>();
      foreach (int num in (VehicleColor[]) Enum.GetValues(typeof (VehicleColor)))
        Colors.Add((object) (VehicleColor) num);
      List<object> DColors = new List<object>();
      foreach (KnownColor color1 in Enum.GetValues(typeof (KnownColor)))
      {
        Color color2 = Color.FromKnownColor(color1);
        DColors.Add((object) color2);
      }
      List<object> TF = new List<object>();
      TF.Add((object) true);
      TF.Add((object) false);
      UIMenu submenu1 = this.modMenuPool.AddSubMenu(this.VehicleMenu, "Basic Part Mods ");
      this.GUIMenus.Add(submenu1);
      UIMenu uiMenu = this.modMenuPool.AddSubMenu(this.VehicleMenu, "Advanced Part Mods ");
      this.GUIMenus.Add(uiMenu);
      UIMenuItem ModName = new UIMenuItem("Modification Name : ");
      submenu1.AddItem(ModName);
      UIMenuListItem ModType = new UIMenuListItem("Modification Type : ", listofMods, 0);
      submenu1.AddItem((UIMenuItem) ModType);
      UIMenuListItem Modification = new UIMenuListItem("Modification : ", this.TypeOfMod, 0);
      submenu1.AddItem((UIMenuItem) Modification);
      UIMenuListItem FNeon = new UIMenuListItem("Front Neon : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) FNeon);
      UIMenuListItem LNeon = new UIMenuListItem("Left Neon : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) LNeon);
      UIMenuListItem RNeon = new UIMenuListItem("Right Neon : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) RNeon);
      UIMenuListItem RRNeon = new UIMenuListItem("Rear Neon : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) RRNeon);
      UIMenuListItem NeonC = new UIMenuListItem("Neon Color : ", DColors, 0);
      uiMenu.AddItem((UIMenuItem) NeonC);
      UIMenuListItem Primary = new UIMenuListItem("Primary : ", Colors, 0);
      uiMenu.AddItem((UIMenuItem) Primary);
      UIMenuListItem Secondary = new UIMenuListItem("Seconary : ", Colors, 0);
      uiMenu.AddItem((UIMenuItem) Secondary);
      UIMenuListItem DashboardC = new UIMenuListItem("DashBoard Color : ", Colors, 0);
      uiMenu.AddItem((UIMenuItem) DashboardC);
      UIMenuListItem TrimC = new UIMenuListItem("Trim Color : ", Colors, 0);
      uiMenu.AddItem((UIMenuItem) TrimC);
      UIMenuListItem WheelC = new UIMenuListItem("Rim Color : ", Colors, 0);
      uiMenu.AddItem((UIMenuItem) WheelC);
      UIMenuListItem XenonH = new UIMenuListItem("Xenon Headlights : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) XenonH);
      UIMenuListItem XenonC = new UIMenuListItem("Xenon Headlights : ", items, 0);
      uiMenu.AddItem((UIMenuItem) XenonC);
      UIMenuListItem TIreon = new UIMenuListItem("TireSmoke : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) TIreon);
      UIMenuListItem Smokec = new UIMenuListItem("Tire Smoke Color : ", DColors, 0);
      uiMenu.AddItem((UIMenuItem) Smokec);
      UIMenuListItem Turbo = new UIMenuListItem("Turbo : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) Turbo);
      UIMenuListItem BulletproofTires = new UIMenuListItem("Bullet Proof Tires : ", TF, 0);
      uiMenu.AddItem((UIMenuItem) BulletproofTires);
      uiMenu.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == TrimC)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num = (int) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__0.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__0, Colors[TrimC.Index]);
          vehicle.TrimColor = (VehicleColor) num;
        }
        if (item == BulletproofTires)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (bool), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__1.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__1, TF[BulletproofTires.Index]) ? 1 : 0;
          vehicle.CanTiresBurst = num != 0;
        }
        if (item == Turbo)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__2 = CallSite<Action<CallSite, Vehicle, VehicleToggleMod, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ToggleMod", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__2.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__2, currentVehicle, VehicleToggleMod.Turbo, TF[Turbo.Index]);
        }
        if (item == Smokec)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, Color>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Color), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Color color = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__3.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__3, DColors[Smokec.Index]);
          vehicle.TireSmokeColor = color;
        }
        if (item == TIreon)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__4 = CallSite<Action<CallSite, Vehicle, VehicleToggleMod, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ToggleMod", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__4.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__4, currentVehicle, VehicleToggleMod.TireSmoke, TF[TIreon.Index]);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, Color>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Color), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Color color = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__5.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__5, DColors[Smokec.Index]);
          vehicle.TireSmokeColor = color;
        }
        if (item == XenonC)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__6 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__6 = CallSite<Action<CallSite, Vehicle, VehicleToggleMod, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ToggleMod", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__6.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__6, currentVehicle, VehicleToggleMod.XenonHeadlights, TF[XenonH.Index]);
          Function.Call((Hash) 16433691881432431111, (InputArgument) currentVehicle, (InputArgument) XenonC.Index);
        }
        if (item == XenonH)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__7 = CallSite<Action<CallSite, Vehicle, VehicleToggleMod, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ToggleMod", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__7.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__7, currentVehicle, VehicleToggleMod.XenonHeadlights, TF[XenonH.Index]);
        }
        if (item == WheelC)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num = (int) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__8.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__8, Colors[WheelC.Index]);
          vehicle.RimColor = (VehicleColor) num;
        }
        if (item == DashboardC)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__9 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num = (int) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__9.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__9, Colors[DashboardC.Index]);
          vehicle.DashboardColor = (VehicleColor) num;
        }
        if (item == RRNeon && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__10 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__10 = CallSite<Action<CallSite, Vehicle, VehicleNeonLight, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetNeonLightsOn", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__10.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__10, currentVehicle, VehicleNeonLight.Back, TF[RRNeon.Index]);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__11 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, Color>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Color), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Color color = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__11.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__11, DColors[NeonC.Index]);
          vehicle.NeonLightsColor = color;
        }
        if (item == FNeon && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__12 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__12 = CallSite<Action<CallSite, Vehicle, VehicleNeonLight, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetNeonLightsOn", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__12.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__12, currentVehicle, VehicleNeonLight.Front, TF[FNeon.Index]);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__13 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, Color>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Color), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Color color = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__13.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__13, DColors[NeonC.Index]);
          vehicle.NeonLightsColor = color;
        }
        if (item == RNeon && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__14 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__14 = CallSite<Action<CallSite, Vehicle, VehicleNeonLight, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetNeonLightsOn", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__14.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__14, currentVehicle, VehicleNeonLight.Right, TF[RNeon.Index]);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__15 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, Color>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Color), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Color color = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__15.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__15, DColors[NeonC.Index]);
          vehicle.NeonLightsColor = color;
        }
        if (item == LNeon && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__16 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__16 = CallSite<Action<CallSite, Vehicle, VehicleNeonLight, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetNeonLightsOn", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__16.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__16, currentVehicle, VehicleNeonLight.Left, TF[LNeon.Index]);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__17 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, Color>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Color), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Color color = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__17.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__17, DColors[NeonC.Index]);
          vehicle.NeonLightsColor = color;
        }
        if (item == NeonC)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__18 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, Color>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (Color), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Color color = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__18.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__18, DColors[NeonC.Index]);
          vehicle.NeonLightsColor = color;
        }
        if (item == Primary && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle.Handle, (InputArgument) 0);
          Vehicle vehicle = currentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__19 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          int num = (int) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__19.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__19, Colors[Primary.Index]);
          vehicle.PrimaryColor = (VehicleColor) num;
        }
        if (item != Secondary || !((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
          return;
        Vehicle currentVehicle1 = Game.Player.Character.CurrentVehicle;
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle1.Handle, (InputArgument) 0);
        Vehicle vehicle1 = currentVehicle1;
        // ISSUE: reference to a compiler-generated field
        if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__20 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, VehicleColor>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (VehicleColor), typeof (SpecializationMenu)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        int num1 = (int) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__20.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__20, Colors[Secondary.Index]);
        vehicle1.SecondaryColor = (VehicleColor) num1;
      });
      submenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == ModType && (Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__22 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertArrayIndex, typeof (int), typeof (SpecializationMenu)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, int> target = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__22.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, int>> p22 = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__22;
          // ISSUE: reference to a compiler-generated field
          if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__21 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__21 = CallSite<Func<CallSite, Vehicle, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetModCount", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__21.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__21, currentVehicle, listofMods[ModType.Index]);
          int[] numArray = new int[target((CallSite) p22, obj)];
          this.TypeOfMod.Clear();
          this.TypeOfMod.Capacity = numArray.Length;
          if (numArray.Length >= 1)
          {
            for (int index1 = -1; index1 < numArray.Length; ++index1)
              this.TypeOfMod.Add((object) index1);
            submenu1.RefreshIndex();
            submenu1.RemoveItemAt(2);
            Modification = new UIMenuListItem("Modification : ", this.TypeOfMod, 0);
            submenu1.AddItem((UIMenuItem) Modification);
          }
          else
            this.TypeOfMod.Add((object) 0);
        }
        if (item != Modification || !((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
          return;
        Vehicle currentVehicle1 = Game.Player.Character.CurrentVehicle;
        // ISSUE: reference to a compiler-generated field
        if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__24 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__24 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SpecializationMenu)));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string> target1 = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__24.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string>> p24 = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__24;
        // ISSUE: reference to a compiler-generated field
        if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__23 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__23 = CallSite<Func<CallSite, Vehicle, object, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetModName", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__23.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__23, currentVehicle1, listofMods[ModType.Index], Modification.Index);
        this.ModNamestring = target1((CallSite) p24, obj1);
        ModName.Text = "Modification Name : " + this.ModNamestring;
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) currentVehicle1.Handle, (InputArgument) 0);
        // ISSUE: reference to a compiler-generated field
        if (SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__25 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__25 = CallSite<Action<CallSite, Vehicle, object, int, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetMod", (IEnumerable<System.Type>) null, typeof (SpecializationMenu), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[4]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__25.Target((CallSite) SpecializationMenu.\u003C\u003Eo__91.\u003C\u003Ep__25, currentVehicle1, listofMods[ModType.Index], Modification.Index, true);
      });
    }
  }
}
