using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AfterHoursBusiness
{
  public class SaveCar : Script
  {
    public ScriptSettings Config;
    public Vehicle VehicleId;
    public GTA.Native.VehicleHash VehicleNameHash;
    public string VehicleName;
    public int RoofId;
    public int AerialsId;
    public int AirfilterId;
    public int ArchCoverId;
    public int ArmorId;
    public int BackWheelsId;
    public int BrakesId;
    public int ColumnShifterLeversId;
    public int DashboardId;
    public int DialDesignId;
    public int DoorSpeekersId;
    public int EngineId;
    public int EngineBlockId;
    public int ExaustId;
    public int FenderId;
    public int FrameId;
    public int FrontBumperId;
    public int FrontWheelsId;
    public int GrilleId;
    public int HoodId;
    public int HornsId;
    public int HydralicsId;
    public int LiveryId;
    public int OrnamentsId;
    public int PlaquesId;
    public int Plateholder;
    public int RearBumperId;
    public int RightFenderId;
    public int SeatsId;
    public int SideSkirt;
    public int speakers;
    public int SpoilersId;
    public int SteeringWheelId;
    public int StrutId;
    public int SuspensionId;
    public int TankId;
    public int TransmissionId;
    public int TrimId;
    public int TrimDesignId;
    public int TrunkId;
    public int VanityPlatesId;
    public int WindowId;
    public bool CustomTiresOn;
    public int SecondaryVehicleLivery;
    public VehicleColor PearlCent;
    public Color NeonColour;
    public VehicleColor PrimaryColor;
    public VehicleColor SecondaryColor;
    public Vector3 Avenger_Vehicle_Loc = new Vector3(522.645f, 4750.41f, -68.996f);
    public float Avenger_Vehicle_Heading = -90f;
    public Vector3 MOC_Vehicle_Loc = new Vector3(1103.77f, -2995.365f, -39f);
    public float MOC_Vehicle_Heading = 0.0f;
    public Vehicle SavedVehicle;
    public Vehicle newvehicle;
    public Vehicle VehicletoCheck;
    public bool HasTurbo;
    public bool HasXenonLights;
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
    public List<bool> ExtraOn = new List<bool>();
    public bool HasTireSmoke;
    public VehicleColor Wheelcolour;
    public VehicleColor DashBoardColour;
    public Color TireSmokeColor;
    public bool TireSmoke;
    public bool BulletProofTires;
    public VehicleColor TrimColor;
    public float Torque;
    public float Power;
    public bool HasClanTag;
    public VehiclesEmblem VE = new VehiclesEmblem();
    public bool UseCustomPrimaryColor;
    public bool UseCustomSecondaryColor;
    public string CustomPrimaryColor;
    public string CustomSecondaryColor;
    public Color CustomPrimaryColorToUse;
    public Color CustomSecondaryColorToUse;
    public int SpawnHash;
    public string SpawnString;
    public string LoadedIniname;
    public int WheelType;

    public SaveCar()
    {
      this.Tick += new EventHandler(this.OnTick);
      this.KeyDown += new KeyEventHandler(this.onKeyDown);
      this.Setup();
    }

    public void SetupVehicle(Vehicle Car, int I)
    {
      if (I != 0)
        return;
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) Car.Handle, (InputArgument) 0);
      Car.SetMod(VehicleMod.Roof, 0, true);
      Car.SetMod(VehicleMod.Frame, 2, true);
      Car.SetMod(VehicleMod.Hood, 2, true);
    }

    public void SaveName()
    {
      this.VehicleName = "null";
      this.VehicleNameHash = (GTA.Native.VehicleHash) 0;
      this.Config.SetValue<GTA.Native.VehicleHash>("Configurations", "VehicleNameHash", this.VehicleNameHash);
      this.Config.SetValue<string>("Configurations", "VehicleName", this.VehicleName);
      this.Config.Save();
    }

    public void LoadIniFile(string iniName)
    {
      try
      {
        this.LoadedIniname = iniName;
        this.Config = ScriptSettings.Load(iniName);
        this.VehicleNameHash = this.Config.GetValue<GTA.Native.VehicleHash>("Configurations", "VehicleNameHash", this.VehicleNameHash);
        this.VehicleName = this.Config.GetValue<string>("Configurations", "VehicleName", this.VehicleName);
        this.RoofId = this.Config.GetValue<int>("Configurations", "RoofId", this.RoofId);
        this.AerialsId = this.Config.GetValue<int>("Configurations", "AerialsId", this.AerialsId);
        this.AirfilterId = this.Config.GetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
        this.ArchCoverId = this.Config.GetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
        this.ArmorId = this.Config.GetValue<int>("Configurations", "ArmorId", this.ArmorId);
        this.BackWheelsId = this.Config.GetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
        this.BrakesId = this.Config.GetValue<int>("Configurations", "BrakesId", this.BrakesId);
        this.ColumnShifterLeversId = this.Config.GetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
        this.DashboardId = this.Config.GetValue<int>("Configurations", "DashboardId", this.DashboardId);
        this.DialDesignId = this.Config.GetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
        this.DoorSpeekersId = this.Config.GetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
        this.EngineId = this.Config.GetValue<int>("Configurations", "EngineId", this.EngineId);
        this.EngineBlockId = this.Config.GetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
        this.ExaustId = this.Config.GetValue<int>("Configurations", "ExaustId", this.ExaustId);
        this.FenderId = this.Config.GetValue<int>("Configurations", "FenderId", this.FenderId);
        this.FrameId = this.Config.GetValue<int>("Configurations", "FrameId", this.FrameId);
        this.FrontBumperId = this.Config.GetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
        this.FrontWheelsId = this.Config.GetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
        this.GrilleId = this.Config.GetValue<int>("Configurations", "GrilleId", this.GrilleId);
        this.HoodId = this.Config.GetValue<int>("Configurations", "HoodId", this.HoodId);
        this.HornsId = this.Config.GetValue<int>("Configurations", "HornsId", this.HornsId);
        this.HydralicsId = this.Config.GetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
        this.LiveryId = this.Config.GetValue<int>("Configurations", "LiveryId", this.LiveryId);
        this.SecondaryVehicleLivery = this.Config.GetValue<int>("Configurations", "SecondaryVehicleLivery", this.SecondaryVehicleLivery);
        this.OrnamentsId = this.Config.GetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
        this.PlaquesId = this.Config.GetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
        this.Plateholder = this.Config.GetValue<int>("Configurations", "Plateholder", this.Plateholder);
        this.RearBumperId = this.Config.GetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
        this.RightFenderId = this.Config.GetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
        this.SeatsId = this.Config.GetValue<int>("Configurations", "SeatsId", this.SeatsId);
        this.SideSkirt = this.Config.GetValue<int>("Configurations", "SideSkirt", this.SideSkirt);
        this.speakers = this.Config.GetValue<int>("Configurations", "speakers", this.speakers);
        this.SpoilersId = this.Config.GetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
        this.SteeringWheelId = this.Config.GetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
        this.StrutId = this.Config.GetValue<int>("Configurations", "StrutId", this.StrutId);
        this.SuspensionId = this.Config.GetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
        this.TankId = this.Config.GetValue<int>("Configurations", "TankId", this.TankId);
        this.TransmissionId = this.Config.GetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
        this.TrimId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
        this.TrimDesignId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
        this.TrunkId = this.Config.GetValue<int>("Configurations", "TrunkId", this.TrunkId);
        this.VanityPlatesId = this.Config.GetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
        this.WindowId = this.Config.GetValue<int>("Configurations", "WindowId", this.WindowId);
        this.CustomTiresOn = this.Config.GetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
        if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
        {
          this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
          this.CustomPrimaryColor = this.Config.GetValue<string>("Configurations", "CustomPrimaryColor", this.CustomPrimaryColor);
        }
        if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
        {
          this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
          this.PrimaryColor = this.Config.GetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
        }
        if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
        {
          this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
          this.CustomSecondaryColor = this.Config.GetValue<string>("Configurations", "CustomSecondaryColor", this.CustomSecondaryColor);
        }
        if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
        {
          this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
          this.SecondaryColor = this.Config.GetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
        }
        this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
        this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
        this.PearlCent = this.Config.GetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
        this.NeonColour = this.Config.GetValue<Color>("Configurations", "NeonColour", this.NeonColour);
        this.TintId = this.Config.GetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
        this.PlanteNo = this.Config.GetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
        this.Blades = this.Config.GetValue<int>("Configurations", "Blades", this.Blades);
        this.LightColor = this.Config.GetValue<int>("Configurations", "LightColor", this.LightColor);
        this.HasXenonLights = this.Config.GetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
        this.TurboActive = this.Config.GetValue<bool>("Configurations", "TurboActive", this.TurboActive);
        this.NeonColor = this.Config.GetValue<Color>("Configurations", "NeonColor", this.NeonColor);
        this.RightNeonOn = this.Config.GetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
        this.LeftNeonOn = this.Config.GetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
        this.FrontNeonOn = this.Config.GetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
        this.BackNeonOn = this.Config.GetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
      }
      catch (Exception ex)
      {
        UI.Notify("No Valid Garage Selected (1)");
      }
    }

    private void Setup()
    {
    }

    public void Delete()
    {
      if (!((Entity) this.SavedVehicle != (Entity) null))
        return;
      this.VehicleId = this.SavedVehicle;
      this.SavedVehicle.Delete();
    }

    public void LoadAvengerVehicle()
    {
      this.RoofId = this.Config.GetValue<int>("Configurations", "RoofId", this.RoofId);
      this.AerialsId = this.Config.GetValue<int>("Configurations", "AerialsId", this.AerialsId);
      this.AirfilterId = this.Config.GetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
      this.ArchCoverId = this.Config.GetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
      this.ArmorId = this.Config.GetValue<int>("Configurations", "ArmorId", this.ArmorId);
      this.BackWheelsId = this.Config.GetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
      this.BrakesId = this.Config.GetValue<int>("Configurations", "BrakesId", this.BrakesId);
      this.ColumnShifterLeversId = this.Config.GetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
      this.DashboardId = this.Config.GetValue<int>("Configurations", "DashboardId", this.DashboardId);
      this.DialDesignId = this.Config.GetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
      this.DoorSpeekersId = this.Config.GetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
      this.EngineId = this.Config.GetValue<int>("Configurations", "EngineId", this.EngineId);
      this.EngineBlockId = this.Config.GetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
      this.ExaustId = this.Config.GetValue<int>("Configurations", "ExaustId", this.ExaustId);
      this.FenderId = this.Config.GetValue<int>("Configurations", "FenderId", this.FenderId);
      this.FrameId = this.Config.GetValue<int>("Configurations", "FrameId", this.FrameId);
      this.FrontBumperId = this.Config.GetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
      this.FrontWheelsId = this.Config.GetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
      this.GrilleId = this.Config.GetValue<int>("Configurations", "GrilleId", this.GrilleId);
      this.HoodId = this.Config.GetValue<int>("Configurations", "HoodId", this.HoodId);
      this.HornsId = this.Config.GetValue<int>("Configurations", "HornsId", this.HornsId);
      this.HydralicsId = this.Config.GetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
      this.LiveryId = this.Config.GetValue<int>("Configurations", "LiveryId", this.LiveryId);
      this.SecondaryVehicleLivery = this.Config.GetValue<int>("Configurations", "SecondaryVehicleLivery", this.SecondaryVehicleLivery);
      this.OrnamentsId = this.Config.GetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
      this.PlaquesId = this.Config.GetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
      this.Plateholder = this.Config.GetValue<int>("Configurations", "Plateholder", this.Plateholder);
      this.RearBumperId = this.Config.GetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
      this.RightFenderId = this.Config.GetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
      this.SeatsId = this.Config.GetValue<int>("Configurations", "SeatsId", this.SeatsId);
      this.SideSkirt = this.Config.GetValue<int>("Configurations", "SideSkirt", this.SideSkirt);
      this.speakers = this.Config.GetValue<int>("Configurations", "speakers", this.speakers);
      this.SpoilersId = this.Config.GetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
      this.SteeringWheelId = this.Config.GetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
      this.StrutId = this.Config.GetValue<int>("Configurations", "StrutId", this.StrutId);
      this.SuspensionId = this.Config.GetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
      this.TankId = this.Config.GetValue<int>("Configurations", "TankId", this.TankId);
      this.TransmissionId = this.Config.GetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
      this.TrimId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.TrimDesignId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.TrunkId = this.Config.GetValue<int>("Configurations", "TrunkId", this.TrunkId);
      this.VanityPlatesId = this.Config.GetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
      this.WindowId = this.Config.GetValue<int>("Configurations", "WindowId", this.WindowId);
      this.CustomTiresOn = this.Config.GetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
      if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.CustomPrimaryColor = this.Config.GetValue<string>("Configurations", "CustomPrimaryColor", this.CustomPrimaryColor);
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.PrimaryColor = this.Config.GetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
      }
      if (this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.CustomSecondaryColor = this.Config.GetValue<string>("Configurations", "CustomSecondaryColor", this.CustomSecondaryColor);
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.SecondaryColor = this.Config.GetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
      }
      this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.PearlCent = this.Config.GetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
      this.NeonColour = this.Config.GetValue<Color>("Configurations", "NeonColour", this.NeonColour);
      this.TintId = this.Config.GetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
      this.PlanteNo = this.Config.GetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
      this.Blades = this.Config.GetValue<int>("Configurations", "Blades", this.Blades);
      this.LightColor = this.Config.GetValue<int>("Configurations", "LightColor", this.LightColor);
      this.HasXenonLights = this.Config.GetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
      this.TurboActive = this.Config.GetValue<bool>("Configurations", "TurboActive", this.TurboActive);
      this.NeonColor = this.Config.GetValue<Color>("Configurations", "NeonColor", this.NeonColor);
      this.RightNeonOn = this.Config.GetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
      this.LeftNeonOn = this.Config.GetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
      this.FrontNeonOn = this.Config.GetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
      this.BackNeonOn = this.Config.GetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
      this.TrimColor = this.Config.GetValue<VehicleColor>("Configurations", "TrimColor", this.TrimColor);
      this.BulletProofTires = this.Config.GetValue<bool>("Configurations", "BulletProofTires", this.BulletProofTires);
      this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.TireSmokeColor = this.Config.GetValue<Color>("Configurations", "TireSmokeColor", this.TireSmokeColor);
      this.TireSmoke = this.Config.GetValue<bool>("Configurations", "TireSmoke", this.TireSmoke);
      try
      {
        this.Torque = this.Config.GetValue<float>("Configurations", "Torque", this.Torque);
        this.Power = this.Config.GetValue<float>("Configurations", "Power", this.Power);
      }
      catch
      {
        this.Torque = 1f;
        this.Config.SetValue<float>("Configurations", "Torque", this.Torque);
        this.Power = 1f;
        this.Config.SetValue<float>("Configurations", "Power", this.Power);
        this.Config.Save();
      }
      this.HasClanTag = this.Config.GetValue<bool>("Configurations", "CLanTagOn", this.HasClanTag);
      this.ExtraOn.Clear();
      for (int index = 0; index < 21; ++index)
      {
        if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), true))
          this.ExtraOn.Add(true);
        else
          this.ExtraOn.Add(false);
      }
      this.newvehicle = World.CreateVehicle(this.CheckCar(this.LoadedIniname), this.Avenger_Vehicle_Loc, this.Avenger_Vehicle_Heading);
      Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) this.newvehicle, (InputArgument) this.WheelType);
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.newvehicle.Handle, (InputArgument) 0);
      this.newvehicle.SetMod(VehicleMod.Roof, this.RoofId, true);
      this.newvehicle.SetMod(VehicleMod.Roof, this.RoofId, true);
      this.newvehicle.SetMod(VehicleMod.Aerials, this.AerialsId, true);
      this.newvehicle.SetMod(VehicleMod.AirFilter, this.AirfilterId, true);
      this.newvehicle.SetMod(VehicleMod.ArchCover, this.ArchCoverId, true);
      this.newvehicle.SetMod(VehicleMod.Armor, this.ArmorId, true);
      this.newvehicle.SetMod(VehicleMod.BackWheels, this.BackWheelsId, true);
      this.newvehicle.SetMod(VehicleMod.Brakes, this.BrakesId, true);
      this.newvehicle.SetMod(VehicleMod.ColumnShifterLevers, this.ColumnShifterLeversId, true);
      this.newvehicle.SetMod(VehicleMod.Dashboard, this.DashboardId, true);
      this.newvehicle.SetMod(VehicleMod.DialDesign, this.DialDesignId, true);
      this.newvehicle.SetMod(VehicleMod.DoorSpeakers, this.DoorSpeekersId, true);
      this.newvehicle.SetMod(VehicleMod.Engine, this.EngineId, true);
      this.newvehicle.SetMod(VehicleMod.EngineBlock, this.EngineBlockId, true);
      this.newvehicle.SetMod(VehicleMod.Exhaust, this.ExaustId, true);
      this.newvehicle.SetMod(VehicleMod.Fender, this.FenderId, true);
      this.newvehicle.SetMod(VehicleMod.Frame, this.FrameId, true);
      this.newvehicle.SetMod(VehicleMod.FrontBumper, this.FrontBumperId, true);
      this.newvehicle.SetMod(VehicleMod.FrontWheels, this.FrontWheelsId, true);
      this.newvehicle.SetMod(VehicleMod.Grille, this.GrilleId, true);
      this.newvehicle.SetMod(VehicleMod.Hood, this.HoodId, true);
      this.newvehicle.SetMod(VehicleMod.Horns, this.HornsId, true);
      this.newvehicle.SetMod(VehicleMod.Hydraulics, this.HydralicsId, true);
      this.newvehicle.SetMod(VehicleMod.Livery, this.LiveryId, true);
      Function.Call(Hash._0x60BF608F1B8CD1B6, (InputArgument) this.newvehicle, (InputArgument) this.SecondaryVehicleLivery);
      this.newvehicle.SetMod(VehicleMod.Ornaments, this.OrnamentsId, true);
      this.newvehicle.SetMod(VehicleMod.Plaques, this.PlaquesId, true);
      this.newvehicle.SetMod(VehicleMod.PlateHolder, this.Plateholder, true);
      this.newvehicle.SetMod(VehicleMod.RearBumper, this.RearBumperId, true);
      this.newvehicle.SetMod(VehicleMod.RightFender, this.RightFenderId, true);
      this.newvehicle.SetMod(VehicleMod.Seats, this.SeatsId, true);
      this.newvehicle.SetMod(VehicleMod.SideSkirt, this.SideSkirt, true);
      this.newvehicle.SetMod(VehicleMod.Speakers, this.speakers, true);
      this.newvehicle.SetMod(VehicleMod.Spoilers, this.SpoilersId, true);
      this.newvehicle.SetMod(VehicleMod.SteeringWheels, this.SteeringWheelId, true);
      this.newvehicle.SetMod(VehicleMod.Struts, this.StrutId, true);
      this.newvehicle.SetMod(VehicleMod.Suspension, this.SuspensionId, true);
      this.newvehicle.SetMod(VehicleMod.Tank, this.TankId, true);
      this.newvehicle.SetMod(VehicleMod.Transmission, this.TransmissionId, true);
      this.newvehicle.SetMod(VehicleMod.Trim, this.TrimId, true);
      this.newvehicle.SetMod(VehicleMod.TrimDesign, this.TrimDesignId, true);
      this.newvehicle.SetMod(VehicleMod.Trunk, this.TrunkId, true);
      this.newvehicle.SetMod(VehicleMod.VanityPlates, this.VanityPlatesId, true);
      this.newvehicle.SetMod(VehicleMod.Windows, this.WindowId, true);
      this.newvehicle.SetMod(VehicleMod.Trim, this.Blades, true);
      this.newvehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, this.HasXenonLights);
      this.newvehicle.ToggleMod(VehicleToggleMod.Turbo, this.TurboActive);
      Function.Call((Hash) 16433691881432431111, (InputArgument) this.newvehicle, (InputArgument) this.LightColor);
      Function.Call(Hash._0x6AF0636DDEDCB6DD, (InputArgument) this.newvehicle, (InputArgument) 23, (InputArgument) this.newvehicle.GetMod(VehicleMod.FrontWheels), (InputArgument) this.CustomTiresOn);
      try
      {
        if (this.HasClanTag)
        {
          this.VE.CheckforEmblem(this.newvehicle);
          this.VE.CreateVehEmblem(this.newvehicle, Game.Player.Character);
        }
      }
      catch (Exception ex)
      {
      }
      if (this.RightNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Right, true);
      }
      if (this.LeftNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Left, true);
      }
      if (this.BackNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Back, true);
      }
      if (this.FrontNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Front, true);
      }
      this.newvehicle.WindowTint = this.TintId;
      if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        try
        {
          string[] strArray = this.CustomPrimaryColor.Split('=', ',', ']');
          string s1 = strArray[3];
          string s2 = strArray[5];
          string s3 = strArray[7];
          this.CustomPrimaryColorToUse = Color.FromArgb(int.Parse(s1), int.Parse(s2), int.Parse(s3));
          this.newvehicle.CustomPrimaryColor = this.CustomPrimaryColorToUse;
        }
        catch
        {
        }
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
        this.newvehicle.PrimaryColor = this.PrimaryColor;
      if (this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        try
        {
          string[] strArray = this.CustomSecondaryColor.Split('=', ',', ']');
          string s1 = strArray[3];
          string s2 = strArray[5];
          string s3 = strArray[7];
          this.CustomSecondaryColorToUse = Color.FromArgb(int.Parse(s1), int.Parse(s2), int.Parse(s3));
          this.newvehicle.CustomSecondaryColor = this.CustomSecondaryColorToUse;
        }
        catch
        {
        }
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
        this.newvehicle.SecondaryColor = this.SecondaryColor;
      this.newvehicle.RimColor = this.Wheelcolour;
      this.newvehicle.DashboardColor = this.DashBoardColour;
      this.newvehicle.PearlescentColor = this.PearlCent;
      this.newvehicle.NeonLightsColor = this.NeonColour;
      this.newvehicle.NumberPlate = this.PlanteNo;
      this.newvehicle.IsDriveable = false;
      this.newvehicle.ToggleMod(VehicleToggleMod.TireSmoke, this.TireSmoke);
      this.newvehicle.RimColor = this.Wheelcolour;
      this.newvehicle.DashboardColor = this.DashBoardColour;
      this.newvehicle.TireSmokeColor = this.TireSmokeColor;
      this.newvehicle.EngineTorqueMultiplier = this.Torque;
      this.newvehicle.EnginePowerMultiplier = this.Power;
      this.newvehicle.TrimColor = this.TrimColor;
      this.newvehicle.CanTiresBurst = this.BulletProofTires;
      for (int index = 0; index < 21; ++index)
      {
        if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), this.ExtraOn[index]))
          this.newvehicle.ToggleExtra(index, this.ExtraOn[index]);
      }
      this.SavedVehicle = this.newvehicle;
    }

    public void LoadMocVehicle()
    {
      this.RoofId = this.Config.GetValue<int>("Configurations", "RoofId", this.RoofId);
      this.AerialsId = this.Config.GetValue<int>("Configurations", "AerialsId", this.AerialsId);
      this.AirfilterId = this.Config.GetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
      this.ArchCoverId = this.Config.GetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
      this.ArmorId = this.Config.GetValue<int>("Configurations", "ArmorId", this.ArmorId);
      this.BackWheelsId = this.Config.GetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
      this.BrakesId = this.Config.GetValue<int>("Configurations", "BrakesId", this.BrakesId);
      this.ColumnShifterLeversId = this.Config.GetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
      this.DashboardId = this.Config.GetValue<int>("Configurations", "DashboardId", this.DashboardId);
      this.DialDesignId = this.Config.GetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
      this.DoorSpeekersId = this.Config.GetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
      this.EngineId = this.Config.GetValue<int>("Configurations", "EngineId", this.EngineId);
      this.EngineBlockId = this.Config.GetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
      this.ExaustId = this.Config.GetValue<int>("Configurations", "ExaustId", this.ExaustId);
      this.FenderId = this.Config.GetValue<int>("Configurations", "FenderId", this.FenderId);
      this.FrameId = this.Config.GetValue<int>("Configurations", "FrameId", this.FrameId);
      this.FrontBumperId = this.Config.GetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
      this.FrontWheelsId = this.Config.GetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
      this.GrilleId = this.Config.GetValue<int>("Configurations", "GrilleId", this.GrilleId);
      this.HoodId = this.Config.GetValue<int>("Configurations", "HoodId", this.HoodId);
      this.HornsId = this.Config.GetValue<int>("Configurations", "HornsId", this.HornsId);
      this.HydralicsId = this.Config.GetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
      this.LiveryId = this.Config.GetValue<int>("Configurations", "LiveryId", this.LiveryId);
      this.SecondaryVehicleLivery = this.Config.GetValue<int>("Configurations", "SecondaryVehicleLivery", this.SecondaryVehicleLivery);
      this.OrnamentsId = this.Config.GetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
      this.PlaquesId = this.Config.GetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
      this.Plateholder = this.Config.GetValue<int>("Configurations", "Plateholder", this.Plateholder);
      this.RearBumperId = this.Config.GetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
      this.RightFenderId = this.Config.GetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
      this.SeatsId = this.Config.GetValue<int>("Configurations", "SeatsId", this.SeatsId);
      this.SideSkirt = this.Config.GetValue<int>("Configurations", "SideSkirt", this.SideSkirt);
      this.speakers = this.Config.GetValue<int>("Configurations", "speakers", this.speakers);
      this.SpoilersId = this.Config.GetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
      this.SteeringWheelId = this.Config.GetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
      this.StrutId = this.Config.GetValue<int>("Configurations", "StrutId", this.StrutId);
      this.SuspensionId = this.Config.GetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
      this.TankId = this.Config.GetValue<int>("Configurations", "TankId", this.TankId);
      this.TransmissionId = this.Config.GetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
      this.TrimId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.TrimDesignId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.TrunkId = this.Config.GetValue<int>("Configurations", "TrunkId", this.TrunkId);
      this.VanityPlatesId = this.Config.GetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
      this.WindowId = this.Config.GetValue<int>("Configurations", "WindowId", this.WindowId);
      this.CustomTiresOn = this.Config.GetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
      if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.CustomPrimaryColor = this.Config.GetValue<string>("Configurations", "CustomPrimaryColor", this.CustomPrimaryColor);
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.PrimaryColor = this.Config.GetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
      }
      if (this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.CustomSecondaryColor = this.Config.GetValue<string>("Configurations", "CustomSecondaryColor", this.CustomSecondaryColor);
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.SecondaryColor = this.Config.GetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
      }
      this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.PearlCent = this.Config.GetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
      this.NeonColour = this.Config.GetValue<Color>("Configurations", "NeonColour", this.NeonColour);
      this.TintId = this.Config.GetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
      this.PlanteNo = this.Config.GetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
      this.Blades = this.Config.GetValue<int>("Configurations", "Blades", this.Blades);
      this.LightColor = this.Config.GetValue<int>("Configurations", "LightColor", this.LightColor);
      this.HasXenonLights = this.Config.GetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
      this.TurboActive = this.Config.GetValue<bool>("Configurations", "TurboActive", this.TurboActive);
      this.NeonColor = this.Config.GetValue<Color>("Configurations", "NeonColor", this.NeonColor);
      this.RightNeonOn = this.Config.GetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
      this.LeftNeonOn = this.Config.GetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
      this.FrontNeonOn = this.Config.GetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
      this.BackNeonOn = this.Config.GetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
      this.TrimColor = this.Config.GetValue<VehicleColor>("Configurations", "TrimColor", this.TrimColor);
      this.BulletProofTires = this.Config.GetValue<bool>("Configurations", "BulletProofTires", this.BulletProofTires);
      this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.TireSmokeColor = this.Config.GetValue<Color>("Configurations", "TireSmokeColor", this.TireSmokeColor);
      this.TireSmoke = this.Config.GetValue<bool>("Configurations", "TireSmoke", this.TireSmoke);
      try
      {
        this.Torque = this.Config.GetValue<float>("Configurations", "Torque", this.Torque);
        this.Power = this.Config.GetValue<float>("Configurations", "Power", this.Power);
      }
      catch
      {
        this.Torque = 1f;
        this.Config.SetValue<float>("Configurations", "Torque", this.Torque);
        this.Power = 1f;
        this.Config.SetValue<float>("Configurations", "Power", this.Power);
        this.Config.Save();
      }
      this.HasClanTag = this.Config.GetValue<bool>("Configurations", "CLanTagOn", this.HasClanTag);
      this.ExtraOn.Clear();
      for (int index = 0; index < 21; ++index)
      {
        if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), true))
          this.ExtraOn.Add(true);
        else
          this.ExtraOn.Add(false);
      }
      this.newvehicle = World.CreateVehicle(this.CheckCar(this.LoadedIniname), this.MOC_Vehicle_Loc, this.MOC_Vehicle_Heading);
      Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) this.newvehicle, (InputArgument) this.WheelType);
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.newvehicle.Handle, (InputArgument) 0);
      this.newvehicle.SetMod(VehicleMod.Roof, this.RoofId, true);
      this.newvehicle.SetMod(VehicleMod.Roof, this.RoofId, true);
      this.newvehicle.SetMod(VehicleMod.Aerials, this.AerialsId, true);
      this.newvehicle.SetMod(VehicleMod.AirFilter, this.AirfilterId, true);
      this.newvehicle.SetMod(VehicleMod.ArchCover, this.ArchCoverId, true);
      this.newvehicle.SetMod(VehicleMod.Armor, this.ArmorId, true);
      this.newvehicle.SetMod(VehicleMod.BackWheels, this.BackWheelsId, true);
      this.newvehicle.SetMod(VehicleMod.Brakes, this.BrakesId, true);
      this.newvehicle.SetMod(VehicleMod.ColumnShifterLevers, this.ColumnShifterLeversId, true);
      this.newvehicle.SetMod(VehicleMod.Dashboard, this.DashboardId, true);
      this.newvehicle.SetMod(VehicleMod.DialDesign, this.DialDesignId, true);
      this.newvehicle.SetMod(VehicleMod.DoorSpeakers, this.DoorSpeekersId, true);
      this.newvehicle.SetMod(VehicleMod.Engine, this.EngineId, true);
      this.newvehicle.SetMod(VehicleMod.EngineBlock, this.EngineBlockId, true);
      this.newvehicle.SetMod(VehicleMod.Exhaust, this.ExaustId, true);
      this.newvehicle.SetMod(VehicleMod.Fender, this.FenderId, true);
      this.newvehicle.SetMod(VehicleMod.Frame, this.FrameId, true);
      this.newvehicle.SetMod(VehicleMod.FrontBumper, this.FrontBumperId, true);
      this.newvehicle.SetMod(VehicleMod.FrontWheels, this.FrontWheelsId, true);
      this.newvehicle.SetMod(VehicleMod.Grille, this.GrilleId, true);
      this.newvehicle.SetMod(VehicleMod.Hood, this.HoodId, true);
      this.newvehicle.SetMod(VehicleMod.Horns, this.HornsId, true);
      this.newvehicle.SetMod(VehicleMod.Hydraulics, this.HydralicsId, true);
      this.newvehicle.SetMod(VehicleMod.Livery, this.LiveryId, true);
      Function.Call(Hash._0x60BF608F1B8CD1B6, (InputArgument) this.newvehicle, (InputArgument) this.SecondaryVehicleLivery);
      this.newvehicle.SetMod(VehicleMod.Ornaments, this.OrnamentsId, true);
      this.newvehicle.SetMod(VehicleMod.Plaques, this.PlaquesId, true);
      this.newvehicle.SetMod(VehicleMod.PlateHolder, this.Plateholder, true);
      this.newvehicle.SetMod(VehicleMod.RearBumper, this.RearBumperId, true);
      this.newvehicle.SetMod(VehicleMod.RightFender, this.RightFenderId, true);
      this.newvehicle.SetMod(VehicleMod.Seats, this.SeatsId, true);
      this.newvehicle.SetMod(VehicleMod.SideSkirt, this.SideSkirt, true);
      this.newvehicle.SetMod(VehicleMod.Speakers, this.speakers, true);
      this.newvehicle.SetMod(VehicleMod.Spoilers, this.SpoilersId, true);
      this.newvehicle.SetMod(VehicleMod.SteeringWheels, this.SteeringWheelId, true);
      this.newvehicle.SetMod(VehicleMod.Struts, this.StrutId, true);
      this.newvehicle.SetMod(VehicleMod.Suspension, this.SuspensionId, true);
      this.newvehicle.SetMod(VehicleMod.Tank, this.TankId, true);
      this.newvehicle.SetMod(VehicleMod.Transmission, this.TransmissionId, true);
      this.newvehicle.SetMod(VehicleMod.Trim, this.TrimId, true);
      this.newvehicle.SetMod(VehicleMod.TrimDesign, this.TrimDesignId, true);
      this.newvehicle.SetMod(VehicleMod.Trunk, this.TrunkId, true);
      this.newvehicle.SetMod(VehicleMod.VanityPlates, this.VanityPlatesId, true);
      this.newvehicle.SetMod(VehicleMod.Windows, this.WindowId, true);
      this.newvehicle.SetMod(VehicleMod.Trim, this.Blades, true);
      this.newvehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, this.HasXenonLights);
      this.newvehicle.ToggleMod(VehicleToggleMod.Turbo, this.TurboActive);
      Function.Call((Hash) 16433691881432431111, (InputArgument) this.newvehicle, (InputArgument) this.LightColor);
      Function.Call(Hash._0x6AF0636DDEDCB6DD, (InputArgument) this.newvehicle, (InputArgument) 23, (InputArgument) this.newvehicle.GetMod(VehicleMod.FrontWheels), (InputArgument) this.CustomTiresOn);
      try
      {
        if (this.HasClanTag)
        {
          this.VE.CheckforEmblem(this.newvehicle);
          this.VE.CreateVehEmblem(this.newvehicle, Game.Player.Character);
        }
      }
      catch (Exception ex)
      {
      }
      if (this.RightNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Right, true);
      }
      if (this.LeftNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Left, true);
      }
      if (this.BackNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Back, true);
      }
      if (this.FrontNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Front, true);
      }
      this.newvehicle.WindowTint = this.TintId;
      if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        try
        {
          string[] strArray = this.CustomPrimaryColor.Split('=', ',', ']');
          string s1 = strArray[3];
          string s2 = strArray[5];
          string s3 = strArray[7];
          this.CustomPrimaryColorToUse = Color.FromArgb(int.Parse(s1), int.Parse(s2), int.Parse(s3));
          this.newvehicle.CustomPrimaryColor = this.CustomPrimaryColorToUse;
        }
        catch
        {
        }
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
        this.newvehicle.PrimaryColor = this.PrimaryColor;
      if (this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        try
        {
          string[] strArray = this.CustomSecondaryColor.Split('=', ',', ']');
          string s1 = strArray[3];
          string s2 = strArray[5];
          string s3 = strArray[7];
          this.CustomSecondaryColorToUse = Color.FromArgb(int.Parse(s1), int.Parse(s2), int.Parse(s3));
          this.newvehicle.CustomSecondaryColor = this.CustomSecondaryColorToUse;
        }
        catch
        {
        }
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
        this.newvehicle.SecondaryColor = this.SecondaryColor;
      this.newvehicle.RimColor = this.Wheelcolour;
      this.newvehicle.DashboardColor = this.DashBoardColour;
      this.newvehicle.PearlescentColor = this.PearlCent;
      this.newvehicle.NeonLightsColor = this.NeonColour;
      this.newvehicle.NumberPlate = this.PlanteNo;
      this.newvehicle.IsDriveable = false;
      this.newvehicle.ToggleMod(VehicleToggleMod.TireSmoke, this.TireSmoke);
      this.newvehicle.RimColor = this.Wheelcolour;
      this.newvehicle.DashboardColor = this.DashBoardColour;
      this.newvehicle.TireSmokeColor = this.TireSmokeColor;
      this.newvehicle.EngineTorqueMultiplier = this.Torque;
      this.newvehicle.EnginePowerMultiplier = this.Power;
      this.newvehicle.TrimColor = this.TrimColor;
      this.newvehicle.CanTiresBurst = this.BulletProofTires;
      for (int index = 0; index < 21; ++index)
      {
        if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), this.ExtraOn[index]))
          this.newvehicle.ToggleExtra(index, this.ExtraOn[index]);
      }
      this.SavedVehicle = this.newvehicle;
    }

    public void Load(Vehicle V, string VehicleName2, Vector3 VehicleLoc2, int Rot)
    {
      this.Config.SetValue<string>("Configurations", "VehicleName", this.newvehicle.DisplayName);
      this.Config.SetValue<int>("Configurations", "VehicleHash", this.newvehicle.Model.Hash);
      this.Config.Save();
      this.SpawnHash = this.newvehicle.Model.Hash;
      this.SpawnString = this.newvehicle.DisplayName;
      this.newvehicle = V;
      this.RoofId = this.Config.GetValue<int>("Configurations", "RoofId", this.RoofId);
      this.AerialsId = this.Config.GetValue<int>("Configurations", "AerialsId", this.AerialsId);
      this.AirfilterId = this.Config.GetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
      this.ArchCoverId = this.Config.GetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
      this.ArmorId = this.Config.GetValue<int>("Configurations", "ArmorId", this.ArmorId);
      this.BackWheelsId = this.Config.GetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
      this.BrakesId = this.Config.GetValue<int>("Configurations", "BrakesId", this.BrakesId);
      this.ColumnShifterLeversId = this.Config.GetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
      this.DashboardId = this.Config.GetValue<int>("Configurations", "DashboardId", this.DashboardId);
      this.DialDesignId = this.Config.GetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
      this.DoorSpeekersId = this.Config.GetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
      this.EngineId = this.Config.GetValue<int>("Configurations", "EngineId", this.EngineId);
      this.EngineBlockId = this.Config.GetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
      this.ExaustId = this.Config.GetValue<int>("Configurations", "ExaustId", this.ExaustId);
      this.FenderId = this.Config.GetValue<int>("Configurations", "FenderId", this.FenderId);
      this.FrameId = this.Config.GetValue<int>("Configurations", "FrameId", this.FrameId);
      this.FrontBumperId = this.Config.GetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
      this.FrontWheelsId = this.Config.GetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
      this.GrilleId = this.Config.GetValue<int>("Configurations", "GrilleId", this.GrilleId);
      this.HoodId = this.Config.GetValue<int>("Configurations", "HoodId", this.HoodId);
      this.HornsId = this.Config.GetValue<int>("Configurations", "HornsId", this.HornsId);
      this.HydralicsId = this.Config.GetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
      this.LiveryId = this.Config.GetValue<int>("Configurations", "LiveryId", this.LiveryId);
      this.SecondaryVehicleLivery = this.Config.GetValue<int>("Configurations", "SecondaryVehicleLivery", this.SecondaryVehicleLivery);
      this.OrnamentsId = this.Config.GetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
      this.PlaquesId = this.Config.GetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
      this.Plateholder = this.Config.GetValue<int>("Configurations", "Plateholder", this.Plateholder);
      this.RearBumperId = this.Config.GetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
      this.RightFenderId = this.Config.GetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
      this.SeatsId = this.Config.GetValue<int>("Configurations", "SeatsId", this.SeatsId);
      this.SideSkirt = this.Config.GetValue<int>("Configurations", "SideSkirt", this.SideSkirt);
      this.speakers = this.Config.GetValue<int>("Configurations", "speakers", this.speakers);
      this.SpoilersId = this.Config.GetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
      this.SteeringWheelId = this.Config.GetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
      this.StrutId = this.Config.GetValue<int>("Configurations", "StrutId", this.StrutId);
      this.SuspensionId = this.Config.GetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
      this.TankId = this.Config.GetValue<int>("Configurations", "TankId", this.TankId);
      this.TransmissionId = this.Config.GetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
      this.TrimId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.TrimDesignId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.TrunkId = this.Config.GetValue<int>("Configurations", "TrunkId", this.TrunkId);
      this.VanityPlatesId = this.Config.GetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
      this.WindowId = this.Config.GetValue<int>("Configurations", "WindowId", this.WindowId);
      this.CustomTiresOn = this.Config.GetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
      if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.CustomPrimaryColor = this.Config.GetValue<string>("Configurations", "CustomPrimaryColor", this.CustomPrimaryColor);
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.PrimaryColor = this.Config.GetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
      }
      if (this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.CustomSecondaryColor = this.Config.GetValue<string>("Configurations", "CustomSecondaryColor", this.CustomSecondaryColor);
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
        this.SecondaryColor = this.Config.GetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
      }
      this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.PearlCent = this.Config.GetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
      this.NeonColour = this.Config.GetValue<Color>("Configurations", "NeonColour", this.NeonColour);
      this.TintId = this.Config.GetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
      this.PlanteNo = this.Config.GetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
      this.Blades = this.Config.GetValue<int>("Configurations", "Blades", this.Blades);
      this.LightColor = this.Config.GetValue<int>("Configurations", "LightColor", this.LightColor);
      this.HasXenonLights = this.Config.GetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
      this.TurboActive = this.Config.GetValue<bool>("Configurations", "TurboActive", this.TurboActive);
      this.NeonColor = this.Config.GetValue<Color>("Configurations", "NeonColor", this.NeonColor);
      this.RightNeonOn = this.Config.GetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
      this.LeftNeonOn = this.Config.GetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
      this.FrontNeonOn = this.Config.GetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
      this.BackNeonOn = this.Config.GetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
      this.TrimColor = this.Config.GetValue<VehicleColor>("Configurations", "TrimColor", this.TrimColor);
      this.BulletProofTires = this.Config.GetValue<bool>("Configurations", "BulletProofTires", this.BulletProofTires);
      this.WheelType = this.Config.GetValue<int>("Configurations", "WheelType", this.WheelType);
      this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.TireSmokeColor = this.Config.GetValue<Color>("Configurations", "TireSmokeColor", this.TireSmokeColor);
      this.TireSmoke = this.Config.GetValue<bool>("Configurations", "TireSmoke", this.TireSmoke);
      try
      {
        this.Torque = this.Config.GetValue<float>("Configurations", "Torque", this.Torque);
        this.Power = this.Config.GetValue<float>("Configurations", "Power", this.Power);
      }
      catch
      {
        this.Torque = 1f;
        this.Config.SetValue<float>("Configurations", "Torque", this.Torque);
        this.Power = 1f;
        this.Config.SetValue<float>("Configurations", "Power", this.Power);
        this.Config.Save();
      }
      this.HasClanTag = this.Config.GetValue<bool>("Configurations", "CLanTagOn", this.HasClanTag);
      this.ExtraOn.Clear();
      for (int index = 0; index < 21; ++index)
      {
        if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), true))
          this.ExtraOn.Add(true);
        else
          this.ExtraOn.Add(false);
      }
      this.newvehicle = World.CreateVehicle((Model) VehicleName2, VehicleLoc2, (float) Rot);
      Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) this.newvehicle, (InputArgument) this.WheelType);
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) this.newvehicle.Handle, (InputArgument) 0);
      this.newvehicle.SetMod(VehicleMod.Roof, this.RoofId, true);
      this.newvehicle.SetMod(VehicleMod.Roof, this.RoofId, true);
      this.newvehicle.SetMod(VehicleMod.Aerials, this.AerialsId, true);
      this.newvehicle.SetMod(VehicleMod.AirFilter, this.AirfilterId, true);
      this.newvehicle.SetMod(VehicleMod.ArchCover, this.ArchCoverId, true);
      this.newvehicle.SetMod(VehicleMod.Armor, this.ArmorId, true);
      this.newvehicle.SetMod(VehicleMod.BackWheels, this.BackWheelsId, true);
      this.newvehicle.SetMod(VehicleMod.Brakes, this.BrakesId, true);
      this.newvehicle.SetMod(VehicleMod.ColumnShifterLevers, this.ColumnShifterLeversId, true);
      this.newvehicle.SetMod(VehicleMod.Dashboard, this.DashboardId, true);
      this.newvehicle.SetMod(VehicleMod.DialDesign, this.DialDesignId, true);
      this.newvehicle.SetMod(VehicleMod.DoorSpeakers, this.DoorSpeekersId, true);
      this.newvehicle.SetMod(VehicleMod.Engine, this.EngineId, true);
      this.newvehicle.SetMod(VehicleMod.EngineBlock, this.EngineBlockId, true);
      this.newvehicle.SetMod(VehicleMod.Exhaust, this.ExaustId, true);
      this.newvehicle.SetMod(VehicleMod.Fender, this.FenderId, true);
      this.newvehicle.SetMod(VehicleMod.Frame, this.FrameId, true);
      this.newvehicle.SetMod(VehicleMod.FrontBumper, this.FrontBumperId, true);
      this.newvehicle.SetMod(VehicleMod.FrontWheels, this.FrontWheelsId, true);
      this.newvehicle.SetMod(VehicleMod.Grille, this.GrilleId, true);
      this.newvehicle.SetMod(VehicleMod.Hood, this.HoodId, true);
      this.newvehicle.SetMod(VehicleMod.Horns, this.HornsId, true);
      this.newvehicle.SetMod(VehicleMod.Hydraulics, this.HydralicsId, true);
      this.newvehicle.SetMod(VehicleMod.Livery, this.LiveryId, true);
      Function.Call(Hash._0x60BF608F1B8CD1B6, (InputArgument) this.newvehicle, (InputArgument) this.SecondaryVehicleLivery);
      this.newvehicle.SetMod(VehicleMod.Ornaments, this.OrnamentsId, true);
      this.newvehicle.SetMod(VehicleMod.Plaques, this.PlaquesId, true);
      this.newvehicle.SetMod(VehicleMod.PlateHolder, this.Plateholder, true);
      this.newvehicle.SetMod(VehicleMod.RearBumper, this.RearBumperId, true);
      this.newvehicle.SetMod(VehicleMod.RightFender, this.RightFenderId, true);
      this.newvehicle.SetMod(VehicleMod.Seats, this.SeatsId, true);
      this.newvehicle.SetMod(VehicleMod.SideSkirt, this.SideSkirt, true);
      this.newvehicle.SetMod(VehicleMod.Speakers, this.speakers, true);
      this.newvehicle.SetMod(VehicleMod.Spoilers, this.SpoilersId, true);
      this.newvehicle.SetMod(VehicleMod.SteeringWheels, this.SteeringWheelId, true);
      this.newvehicle.SetMod(VehicleMod.Struts, this.StrutId, true);
      this.newvehicle.SetMod(VehicleMod.Suspension, this.SuspensionId, true);
      this.newvehicle.SetMod(VehicleMod.Tank, this.TankId, true);
      this.newvehicle.SetMod(VehicleMod.Transmission, this.TransmissionId, true);
      this.newvehicle.SetMod(VehicleMod.Trim, this.TrimId, true);
      this.newvehicle.SetMod(VehicleMod.TrimDesign, this.TrimDesignId, true);
      this.newvehicle.SetMod(VehicleMod.Trunk, this.TrunkId, true);
      this.newvehicle.SetMod(VehicleMod.VanityPlates, this.VanityPlatesId, true);
      this.newvehicle.SetMod(VehicleMod.Windows, this.WindowId, true);
      this.newvehicle.SetMod(VehicleMod.Trim, this.Blades, true);
      Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) this.newvehicle, (InputArgument) this.WheelType);
      this.newvehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, this.HasXenonLights);
      this.newvehicle.ToggleMod(VehicleToggleMod.Turbo, this.TurboActive);
      Function.Call((Hash) 16433691881432431111, (InputArgument) this.newvehicle, (InputArgument) this.LightColor);
      Function.Call(Hash._0x6AF0636DDEDCB6DD, (InputArgument) this.newvehicle, (InputArgument) 23, (InputArgument) this.newvehicle.GetMod(VehicleMod.FrontWheels), (InputArgument) this.CustomTiresOn);
      try
      {
        if (this.HasClanTag)
        {
          this.VE.CheckforEmblem(this.newvehicle);
          this.VE.CreateVehEmblem(this.newvehicle, Game.Player.Character);
        }
      }
      catch (Exception ex)
      {
      }
      if (this.RightNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Right, true);
      }
      if (this.LeftNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Left, true);
      }
      if (this.BackNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Back, true);
      }
      if (this.FrontNeonOn)
      {
        this.newvehicle.NeonLightsColor = this.NeonColor;
        this.newvehicle.SetNeonLightsOn(VehicleNeonLight.Front, true);
      }
      this.newvehicle.WindowTint = this.TintId;
      if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
      {
        try
        {
          string[] strArray = this.CustomPrimaryColor.Split('=', ',', ']');
          string s1 = strArray[3];
          string s2 = strArray[5];
          string s3 = strArray[7];
          this.CustomPrimaryColorToUse = Color.FromArgb(int.Parse(s1), int.Parse(s2), int.Parse(s3));
          this.newvehicle.CustomPrimaryColor = this.CustomPrimaryColorToUse;
        }
        catch
        {
        }
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
        this.newvehicle.PrimaryColor = this.PrimaryColor;
      if (this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
      {
        try
        {
          string[] strArray = this.CustomSecondaryColor.Split('=', ',', ']');
          string s1 = strArray[3];
          string s2 = strArray[5];
          string s3 = strArray[7];
          this.CustomSecondaryColorToUse = Color.FromArgb(int.Parse(s1), int.Parse(s2), int.Parse(s3));
          this.newvehicle.CustomSecondaryColor = this.CustomSecondaryColorToUse;
        }
        catch
        {
        }
      }
      if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
        this.newvehicle.SecondaryColor = this.SecondaryColor;
      this.newvehicle.PearlescentColor = this.PearlCent;
      this.newvehicle.NeonLightsColor = this.NeonColour;
      this.newvehicle.NumberPlate = this.PlanteNo;
      this.newvehicle.IsDriveable = false;
      this.SavedVehicle = this.newvehicle;
      this.newvehicle.EngineTorqueMultiplier = this.Torque;
      this.newvehicle.EnginePowerMultiplier = this.Power;
      this.newvehicle.ToggleMod(VehicleToggleMod.TireSmoke, this.TireSmoke);
      this.newvehicle.RimColor = this.Wheelcolour;
      this.newvehicle.DashboardColor = this.DashBoardColour;
      this.newvehicle.TireSmokeColor = this.TireSmokeColor;
      this.newvehicle.TrimColor = this.TrimColor;
      this.newvehicle.CanTiresBurst = this.BulletProofTires;
      for (int index = 0; index < 21; ++index)
      {
        if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), this.ExtraOn[index]))
          this.newvehicle.ToggleExtra(index, this.ExtraOn[index]);
      }
    }

    public void Load(Vehicle newvehicle)
    {
      this.VehicletoCheck = newvehicle;
      Model model;
      int num;
      if (newvehicle.Model.IsInCdImage)
      {
        model = newvehicle.Model;
        if (model.IsValid)
        {
          num = 1;
          goto label_4;
        }
      }
      num = (Entity) newvehicle != (Entity) null ? 1 : 0;
label_4:
      if (num != 0)
      {
        this.Config.SetValue<string>("Configurations", "VehicleName", newvehicle.DisplayName);
        ScriptSettings config = this.Config;
        model = newvehicle.Model;
        int hash = model.Hash;
        config.SetValue<int>("Configurations", "VehicleHash", hash);
        this.Config.Save();
        model = newvehicle.Model;
        this.SpawnHash = model.Hash;
        this.SpawnString = newvehicle.DisplayName;
        this.RoofId = this.Config.GetValue<int>("Configurations", "RoofId", this.RoofId);
        this.AerialsId = this.Config.GetValue<int>("Configurations", "AerialsId", this.AerialsId);
        this.AirfilterId = this.Config.GetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
        this.ArchCoverId = this.Config.GetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
        this.ArmorId = this.Config.GetValue<int>("Configurations", "ArmorId", this.ArmorId);
        this.BackWheelsId = this.Config.GetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
        this.BrakesId = this.Config.GetValue<int>("Configurations", "BrakesId", this.BrakesId);
        this.ColumnShifterLeversId = this.Config.GetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
        this.DashboardId = this.Config.GetValue<int>("Configurations", "DashboardId", this.DashboardId);
        this.DialDesignId = this.Config.GetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
        this.DoorSpeekersId = this.Config.GetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
        this.EngineId = this.Config.GetValue<int>("Configurations", "EngineId", this.EngineId);
        this.EngineBlockId = this.Config.GetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
        this.ExaustId = this.Config.GetValue<int>("Configurations", "ExaustId", this.ExaustId);
        this.FenderId = this.Config.GetValue<int>("Configurations", "FenderId", this.FenderId);
        this.FrameId = this.Config.GetValue<int>("Configurations", "FrameId", this.FrameId);
        this.FrontBumperId = this.Config.GetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
        this.FrontWheelsId = this.Config.GetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
        this.GrilleId = this.Config.GetValue<int>("Configurations", "GrilleId", this.GrilleId);
        this.HoodId = this.Config.GetValue<int>("Configurations", "HoodId", this.HoodId);
        this.HornsId = this.Config.GetValue<int>("Configurations", "HornsId", this.HornsId);
        this.HydralicsId = this.Config.GetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
        this.LiveryId = this.Config.GetValue<int>("Configurations", "LiveryId", this.LiveryId);
        Function.Call(Hash._0x60BF608F1B8CD1B6, (InputArgument) newvehicle, (InputArgument) this.SecondaryVehicleLivery);
        this.OrnamentsId = this.Config.GetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
        this.PlaquesId = this.Config.GetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
        this.Plateholder = this.Config.GetValue<int>("Configurations", "Plateholder", this.Plateholder);
        this.RearBumperId = this.Config.GetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
        this.RightFenderId = this.Config.GetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
        this.SeatsId = this.Config.GetValue<int>("Configurations", "SeatsId", this.SeatsId);
        this.SideSkirt = this.Config.GetValue<int>("Configurations", "SideSkirt", this.SideSkirt);
        this.speakers = this.Config.GetValue<int>("Configurations", "speakers", this.speakers);
        this.SpoilersId = this.Config.GetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
        this.SteeringWheelId = this.Config.GetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
        this.StrutId = this.Config.GetValue<int>("Configurations", "StrutId", this.StrutId);
        this.SuspensionId = this.Config.GetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
        this.TankId = this.Config.GetValue<int>("Configurations", "TankId", this.TankId);
        this.TransmissionId = this.Config.GetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
        this.TrimId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
        this.TrimDesignId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
        this.TrunkId = this.Config.GetValue<int>("Configurations", "TrunkId", this.TrunkId);
        this.VanityPlatesId = this.Config.GetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
        this.WindowId = this.Config.GetValue<int>("Configurations", "WindowId", this.WindowId);
        this.CustomTiresOn = this.Config.GetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
        if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
        {
          this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
          this.CustomPrimaryColor = this.Config.GetValue<string>("Configurations", "CustomPrimaryColor", this.CustomPrimaryColor);
        }
        if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
        {
          this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
          this.PrimaryColor = this.Config.GetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
        }
        if (this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
        {
          this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
          this.CustomSecondaryColor = this.Config.GetValue<string>("Configurations", "CustomSecondaryColor", this.CustomSecondaryColor);
        }
        if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
        {
          this.UseCustomPrimaryColor = this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor);
          this.SecondaryColor = this.Config.GetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
        }
        this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
        this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
        this.PearlCent = this.Config.GetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
        this.NeonColour = this.Config.GetValue<Color>("Configurations", "NeonColour", this.NeonColour);
        this.TintId = this.Config.GetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
        this.PlanteNo = this.Config.GetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
        this.Blades = this.Config.GetValue<int>("Configurations", "Blades", this.Blades);
        this.HasXenonLights = this.Config.GetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
        this.TurboActive = this.Config.GetValue<bool>("Configurations", "TurboActive", this.TurboActive);
        this.LightColor = this.Config.GetValue<int>("Configurations", "LightColor", this.LightColor);
        this.NeonColor = this.Config.GetValue<Color>("Configurations", "NeonColor", this.NeonColor);
        this.RightNeonOn = this.Config.GetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
        this.LeftNeonOn = this.Config.GetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
        this.FrontNeonOn = this.Config.GetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
        this.BackNeonOn = this.Config.GetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
        this.TrimColor = this.Config.GetValue<VehicleColor>("Configurations", "TrimColor", this.TrimColor);
        this.BulletProofTires = this.Config.GetValue<bool>("Configurations", "BulletProofTires", this.BulletProofTires);
        this.WheelType = this.Config.GetValue<int>("Configurations", "WheelType", this.WheelType);
        try
        {
          this.Torque = this.Config.GetValue<float>("Configurations", "Torque", this.Torque);
          this.Power = this.Config.GetValue<float>("Configurations", "Power", this.Power);
        }
        catch
        {
          this.Torque = 1f;
          this.Config.SetValue<float>("Configurations", "Torque", this.Torque);
          this.Power = 1f;
          this.Config.SetValue<float>("Configurations", "Power", this.Power);
          this.Config.Save();
        }
        this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
        this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
        this.TireSmokeColor = this.Config.GetValue<Color>("Configurations", "TireSmokeColor", this.TireSmokeColor);
        this.TireSmoke = this.Config.GetValue<bool>("Configurations", "TireSmoke", this.TireSmoke);
        this.HasClanTag = this.Config.GetValue<bool>("Configurations", "CLanTagOn", this.HasClanTag);
        this.ExtraOn.Clear();
        for (int index = 0; index < 21; ++index)
        {
          if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), true))
            this.ExtraOn.Add(true);
          else
            this.ExtraOn.Add(false);
        }
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) newvehicle.Handle, (InputArgument) 0);
        Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) newvehicle, (InputArgument) this.WheelType);
        newvehicle.SetMod(VehicleMod.Livery, this.LiveryId, false);
        Function.Call(Hash._0x60BF608F1B8CD1B6, (InputArgument) newvehicle, (InputArgument) this.SecondaryVehicleLivery);
        newvehicle.SetMod(VehicleMod.Roof, this.RoofId, true);
        newvehicle.SetMod(VehicleMod.Aerials, this.AerialsId, true);
        newvehicle.SetMod(VehicleMod.AirFilter, this.AirfilterId, true);
        newvehicle.SetMod(VehicleMod.ArchCover, this.ArchCoverId, true);
        newvehicle.SetMod(VehicleMod.Armor, this.ArmorId, true);
        newvehicle.SetMod(VehicleMod.BackWheels, this.BackWheelsId, true);
        newvehicle.SetMod(VehicleMod.Brakes, this.BrakesId, true);
        newvehicle.SetMod(VehicleMod.ColumnShifterLevers, this.ColumnShifterLeversId, true);
        newvehicle.SetMod(VehicleMod.Dashboard, this.DashboardId, true);
        newvehicle.SetMod(VehicleMod.DialDesign, this.DialDesignId, true);
        newvehicle.SetMod(VehicleMod.DoorSpeakers, this.DoorSpeekersId, true);
        newvehicle.SetMod(VehicleMod.Engine, this.EngineId, true);
        newvehicle.SetMod(VehicleMod.EngineBlock, this.EngineBlockId, true);
        newvehicle.SetMod(VehicleMod.Exhaust, this.ExaustId, true);
        newvehicle.SetMod(VehicleMod.Fender, this.FenderId, true);
        newvehicle.SetMod(VehicleMod.Frame, this.FrameId, true);
        newvehicle.SetMod(VehicleMod.FrontBumper, this.FrontBumperId, true);
        newvehicle.SetMod(VehicleMod.FrontWheels, this.FrontWheelsId, true);
        newvehicle.SetMod(VehicleMod.Grille, this.GrilleId, true);
        newvehicle.SetMod(VehicleMod.Hood, this.HoodId, true);
        newvehicle.SetMod(VehicleMod.Horns, this.HornsId, true);
        newvehicle.SetMod(VehicleMod.Hydraulics, this.HydralicsId, true);
        newvehicle.SetMod(VehicleMod.Livery, this.LiveryId, false);
        Function.Call(Hash._0x60BF608F1B8CD1B6, (InputArgument) newvehicle, (InputArgument) this.SecondaryVehicleLivery);
        newvehicle.SetMod(VehicleMod.Ornaments, this.OrnamentsId, true);
        newvehicle.SetMod(VehicleMod.Plaques, this.PlaquesId, true);
        newvehicle.SetMod(VehicleMod.PlateHolder, this.Plateholder, true);
        newvehicle.SetMod(VehicleMod.RearBumper, this.RearBumperId, true);
        newvehicle.SetMod(VehicleMod.RightFender, this.RightFenderId, true);
        newvehicle.SetMod(VehicleMod.Seats, this.SeatsId, true);
        newvehicle.SetMod(VehicleMod.SideSkirt, this.SideSkirt, true);
        newvehicle.SetMod(VehicleMod.Speakers, this.speakers, true);
        newvehicle.SetMod(VehicleMod.Spoilers, this.SpoilersId, true);
        newvehicle.SetMod(VehicleMod.SteeringWheels, this.SteeringWheelId, true);
        newvehicle.SetMod(VehicleMod.Struts, this.StrutId, true);
        newvehicle.SetMod(VehicleMod.Suspension, this.SuspensionId, true);
        newvehicle.SetMod(VehicleMod.Tank, this.TankId, true);
        newvehicle.SetMod(VehicleMod.Transmission, this.TransmissionId, true);
        newvehicle.SetMod(VehicleMod.Trim, this.TrimId, true);
        newvehicle.SetMod(VehicleMod.TrimDesign, this.TrimDesignId, true);
        newvehicle.SetMod(VehicleMod.Trunk, this.TrunkId, true);
        newvehicle.SetMod(VehicleMod.VanityPlates, this.VanityPlatesId, true);
        newvehicle.SetMod(VehicleMod.Windows, this.WindowId, true);
        newvehicle.SetMod(VehicleMod.Trim, this.Blades, true);
        newvehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, this.HasXenonLights);
        newvehicle.ToggleMod(VehicleToggleMod.Turbo, this.TurboActive);
        Function.Call((Hash) 16433691881432431111, (InputArgument) newvehicle, (InputArgument) this.LightColor);
        Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) newvehicle, (InputArgument) this.WheelType);
        Function.Call(Hash._0x6AF0636DDEDCB6DD, (InputArgument) newvehicle, (InputArgument) 23, (InputArgument) newvehicle.GetMod(VehicleMod.FrontWheels), (InputArgument) this.CustomTiresOn);
        newvehicle.EngineTorqueMultiplier = this.Torque;
        newvehicle.EnginePowerMultiplier = this.Power;
        try
        {
          if (this.HasClanTag)
          {
            this.VE.CheckforEmblem(newvehicle);
            this.VE.CreateVehEmblem(newvehicle, Game.Player.Character);
          }
        }
        catch (Exception ex)
        {
        }
        if (this.RightNeonOn)
        {
          newvehicle.NeonLightsColor = this.NeonColor;
          newvehicle.SetNeonLightsOn(VehicleNeonLight.Right, true);
        }
        if (this.LeftNeonOn)
        {
          newvehicle.NeonLightsColor = this.NeonColor;
          newvehicle.SetNeonLightsOn(VehicleNeonLight.Left, true);
        }
        if (this.BackNeonOn)
        {
          newvehicle.NeonLightsColor = this.NeonColor;
          newvehicle.SetNeonLightsOn(VehicleNeonLight.Back, true);
        }
        if (this.FrontNeonOn)
        {
          newvehicle.NeonLightsColor = this.NeonColor;
          newvehicle.SetNeonLightsOn(VehicleNeonLight.Front, true);
        }
        newvehicle.WindowTint = this.TintId;
        if (this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
        {
          try
          {
            string[] strArray = this.CustomPrimaryColor.Split('=', ',', ']');
            string s1 = strArray[3];
            string s2 = strArray[5];
            string s3 = strArray[7];
            this.CustomPrimaryColorToUse = Color.FromArgb(int.Parse(s1), int.Parse(s2), int.Parse(s3));
            newvehicle.CustomPrimaryColor = this.CustomPrimaryColorToUse;
          }
          catch
          {
          }
        }
        if (!this.Config.GetValue<bool>("Configurations", "UseCustomPrimaryColor", this.UseCustomPrimaryColor))
          newvehicle.PrimaryColor = this.PrimaryColor;
        if (this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
        {
          try
          {
            string[] strArray = this.CustomSecondaryColor.Split('=', ',', ']');
            string s1 = strArray[3];
            string s2 = strArray[5];
            string s3 = strArray[7];
            this.CustomSecondaryColorToUse = Color.FromArgb(int.Parse(s1), int.Parse(s2), int.Parse(s3));
            newvehicle.CustomSecondaryColor = this.CustomSecondaryColorToUse;
          }
          catch
          {
          }
        }
        if (!this.Config.GetValue<bool>("Configurations", "UseCustomSecondaryColor", this.UseCustomSecondaryColor))
          newvehicle.SecondaryColor = this.SecondaryColor;
        newvehicle.RimColor = this.Wheelcolour;
        newvehicle.DashboardColor = this.DashBoardColour;
        newvehicle.PearlescentColor = this.PearlCent;
        newvehicle.NeonLightsColor = this.NeonColour;
        newvehicle.NumberPlate = this.PlanteNo;
        newvehicle.IsDriveable = false;
        this.SavedVehicle = newvehicle;
        newvehicle.ToggleMod(VehicleToggleMod.TireSmoke, this.TireSmoke);
        newvehicle.RimColor = this.Wheelcolour;
        newvehicle.DashboardColor = this.DashBoardColour;
        newvehicle.TireSmokeColor = this.TireSmokeColor;
        newvehicle.TrimColor = this.TrimColor;
        newvehicle.CanTiresBurst = this.BulletProofTires;
        for (int index = 0; index < 21; ++index)
        {
          if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), this.ExtraOn[index]))
            newvehicle.ToggleExtra(index, this.ExtraOn[index]);
        }
        this.VehicleHash = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) newvehicle.DisplayName).ToString();
        this.Config.SetValue<string>("Configurations", "VehicleHash", this.VehicleHash);
        this.Config.Save();
      }
      else
        UI.Notify("~r~Error~w~: " + this.VehicletoCheck?.ToString() + " is not a Base Game vehicle or has issues with saving, contack HKH191 for more info or help!");
    }

    public Model RequestModel(GTA.Native.VehicleHash Name)
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

    public Model RequestModel(string Name)
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

    public Model CheckCar(string iniName)
    {
      Script.Wait(1);
      this.LoadIniFile(iniName);
      this.VehicleNameHash = this.Config.GetValue<GTA.Native.VehicleHash>("Configurations", "VehicleNameHash", this.VehicleNameHash);
      this.VehicleName = this.Config.GetValue<string>("Configurations", "VehicleName", this.VehicleName);
      if (this.VehicleName == "CARBON")
        this.VehicleName = "CARBONRS";
      if (this.VehicleName == "UTILTRUC")
        this.VehicleName = "UTILLITRUCK";
      if (this.VehicleName == "FORK")
        this.VehicleName = "FORKLIFT";
      if (this.VehicleName == "LANDSTAL")
        this.VehicleName = "LANDSTALKER";
      if (this.VehicleName == "CAVCADE")
        this.VehicleName = "CAVALCADE";
      if (this.VehicleName == "SANCHEZ02")
        this.VehicleName = "SANCHEZ2";
      if (this.VehicleName == "SANCHEZ01")
        this.VehicleName = "SANCHEZ";
      if (this.VehicleName == "FAGGION")
        this.VehicleName = "FAGGIO";
      if (this.VehicleName == "STINGERG")
        this.VehicleName = "FELTZER3";
      if (this.VehicleName == "SCHWARZE")
        this.VehicleName = "SCHWARZER";
      if (this.VehicleName == "SCHWARZE")
        this.VehicleName = "SCHWARZER";
      if (this.VehicleName == "KHAMEL")
        this.VehicleName = "KHAMELION";
      if (this.VehicleName == "FURORE")
        this.VehicleName = "FUROREGT";
      if (this.VehicleName == "COGCABRI")
        this.VehicleName = "COGCABRIO";
      if (this.VehicleName == "RLOADER")
        this.VehicleName = "RATLOADER";
      if (this.VehicleName == "RLOADER2")
        this.VehicleName = "RATLOADER2";
      if (this.VehicleName == "FELTZER")
        this.VehicleName = "FELTZER2";
      if (this.VehicleName == "WASHINGT")
        this.VehicleName = "WASHINGTON";
      if (this.VehicleName == "BUFFALO02")
        this.VehicleName = "BUFFALO2";
      if (this.VehicleName == "TAILGATE")
        this.VehicleName = "TAILGATER";
      if (this.VehicleName == "SCHAFTER")
        this.VehicleName = "SCHAFTER2";
      if (this.VehicleName == "SCHAFTER")
        this.VehicleName = "SCHAFTER2";
      if (this.VehicleName == "COGNOSC2")
        this.VehicleName = "COGNOSCENTI2";
      if (this.VehicleName == "COGNOSC2")
        this.VehicleName = "COGNOSCENTI2";
      if (this.VehicleName == "COGNOSC")
        this.VehicleName = "COGNOSCENTI";
      if (this.VehicleName == "COGNOSC")
        this.VehicleName = "COGNOSCENTI";
      if (this.VehicleName == "ASTROPE")
        this.VehicleName = "ASTEROPE";
      if (this.VehicleName == "SANDKIN2")
        this.VehicleName = "SANDKING2";
      if (this.VehicleName == "REBEL02")
        this.VehicleName = "REBEL2";
      if (this.VehicleName == "REBEL01")
        this.VehicleName = "REBEL";
      if (this.VehicleName == "RANCHERX")
        this.VehicleName = "RANCHERXL";
      if (this.VehicleName == "BFINJECT")
        this.VehicleName = "BFINJECTION";
      if (this.VehicleName == "DOMINATO2")
        this.VehicleName = "DOMINATOR2";
      if (this.VehicleName == "DILETTAN")
        this.VehicleName = "DILETTANTE";
      if (this.VehicleName == "VOODOO2")
        this.VehicleName = "VOODOO";
      else if (this.VehicleName == "VOODOO")
        this.VehicleName = "VOODOO2";
      if (this.VehicleName == "ABMULAN")
        this.VehicleName = "AMBULANCE";
      if (this.VehicleName == "Ruiner3")
        this.VehicleName = "Ruiner3";
      if (this.VehicleName == "BUCCANEE2")
        this.VehicleName = "BUCCANEER2";
      if (this.VehicleName == "BUCCANEE")
        this.VehicleName = "BUCCANEER";
      if (this.VehicleName == "CARBONIZ")
        this.VehicleName = "CARBONIZZARE";
      if (this.VehicleName == "penetrator")
        this.VehicleName = "PENETRATOR";
      if (this.VehicleName == "TROPHY")
        this.VehicleName = "TROPHYTRUCK";
      if (this.VehicleName == "TROPHY2")
        this.VehicleName = "TROPHYTRUCK2";
      if (this.VehicleName == "ROOSEVELT")
        this.VehicleName = "Btype";
      if (this.VehicleName == "VERLIER")
        this.VehicleName = "VERLIERER2";
      if (this.VehicleName == "BTYPE2")
        this.VehicleName = "Btype2";
      if (this.VehicleName == "ROOSEVELT2")
        this.VehicleName = "Btype3";
      if (this.VehicleName == "DOMINATO")
        this.VehicleName = "DOMINATOR";
      if (this.VehicleName == "NITESHAD")
        this.VehicleName = "NIGHTSHADE";
      Model model = new Model();
      if (!File.Exists(iniName))
        return (Model) (string) null;
      if (!this.VehicleName.Equals("null"))
      {
        model = new Model(this.VehicleName);
        model.Request(250);
        if (!model.IsValid && (this.VehicleNameHash != (GTA.Native.VehicleHash) 4294967295 || this.VehicleNameHash > (GTA.Native.VehicleHash) 0))
        {
          model = new Model(this.VehicleNameHash);
          model.Request(250);
          if (!model.IsValid && !this.VehicleName.Equals("null"))
          {
            UI.Notify("~r~ Error~w~ A Invalid Vehicle Name has been Detected in ~b~" + iniName);
            return (Model) (string) null;
          }
          if (!model.IsInCdImage || !model.IsValid)
            return (Model) (string) null;
          while (!model.IsLoaded)
            Script.Wait(50);
          return model;
        }
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(50);
          return model;
        }
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public void SaveWithoutDelete()
    {
      if (!((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
        return;
      this.VehicleName = Game.Player.Character.CurrentVehicle.DisplayName;
      this.VehicleNameHash = (GTA.Native.VehicleHash) Game.Player.Character.CurrentVehicle.Model.Hash;
      this.Config.SetValue<string>("Configurations", "VehicleName", Game.Player.Character.CurrentVehicle.DisplayName);
      this.Config.SetValue<int>("Configurations", "VehicleHash", Game.Player.Character.CurrentVehicle.Model.Hash);
      this.Config.Save();
      this.SpawnHash = Game.Player.Character.CurrentVehicle.Model.Hash;
      this.SpawnString = Game.Player.Character.CurrentVehicle.DisplayName;
      this.RoofId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Roof);
      this.AerialsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Aerials);
      this.AirfilterId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.AirFilter);
      this.ArchCoverId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.ArchCover);
      this.ArmorId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Armor);
      this.BackWheelsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.BackWheels);
      this.BrakesId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Brakes);
      this.ColumnShifterLeversId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.ColumnShifterLevers);
      this.DashboardId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Dashboard);
      this.DialDesignId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.DialDesign);
      this.DoorSpeekersId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.DoorSpeakers);
      this.EngineId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Engine);
      this.EngineBlockId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.EngineBlock);
      this.ExaustId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Exhaust);
      this.FenderId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Fender);
      this.FrameId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Frame);
      this.FrontBumperId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.FrontBumper);
      this.FrontWheelsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.FrontWheels);
      this.GrilleId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Grille);
      this.HoodId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Hood);
      this.HornsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Horns);
      this.HydralicsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Hydraulics);
      this.LiveryId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Livery);
      this.SecondaryVehicleLivery = Function.Call<int>(Hash._0x2BB9230590DA5E8A, (InputArgument) Game.Player.Character.CurrentVehicle);
      this.OrnamentsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Ornaments);
      this.PlaquesId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Plaques);
      this.Plateholder = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.PlateHolder);
      this.RearBumperId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.RearBumper);
      this.RightFenderId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.RightFender);
      this.SeatsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Seats);
      this.SideSkirt = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.SideSkirt);
      this.speakers = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Speakers);
      this.SpoilersId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Spoilers);
      this.SteeringWheelId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.SteeringWheels);
      this.StrutId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Struts);
      this.SuspensionId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Suspension);
      this.TankId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Tank);
      this.TransmissionId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Transmission);
      this.TrimId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Trim);
      this.TrimDesignId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.TrimDesign);
      this.TrunkId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Trunk);
      this.VanityPlatesId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.VanityPlates);
      this.WindowId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Windows);
      this.CustomTiresOn = Function.Call<bool>(Hash._0xB3924ECD70E095DC, (InputArgument) Game.Player.Character.CurrentVehicle, (InputArgument) 23);
      if (!Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
        this.PrimaryColor = Game.Player.Character.CurrentVehicle.PrimaryColor;
      if (!Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
        this.SecondaryColor = Game.Player.Character.CurrentVehicle.SecondaryColor;
      this.TintId = Game.Player.Character.CurrentVehicle.WindowTint;
      this.Wheelcolour = Game.Player.Character.CurrentVehicle.RimColor;
      this.DashBoardColour = Game.Player.Character.CurrentVehicle.DashboardColor;
      this.PearlCent = Game.Player.Character.CurrentVehicle.PearlescentColor;
      this.NeonColour = Game.Player.Character.CurrentVehicle.NeonLightsColor;
      this.PlanteNo = Game.Player.Character.CurrentVehicle.NumberPlate;
      this.Blades = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Trim);
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      this.HasXenonLights = currentVehicle.IsToggleModOn(VehicleToggleMod.XenonHeadlights);
      this.TurboActive = currentVehicle.IsToggleModOn(VehicleToggleMod.Turbo);
      this.LightColor = Function.Call<int>((Hash) 4467343895069330651, (InputArgument) currentVehicle);
      this.RightNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Right);
      this.LeftNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Left);
      this.BackNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Back);
      this.FrontNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Front);
      this.NeonColor = currentVehicle.NeonLightsColor;
      this.TireSmoke = currentVehicle.IsToggleModOn(VehicleToggleMod.TireSmoke);
      this.WheelType = Function.Call<int>(Hash._0xB3ED1BFB4BE636DC, (InputArgument) Game.Player.Character.CurrentVehicle);
      this.Wheelcolour = currentVehicle.RimColor;
      this.DashBoardColour = currentVehicle.DashboardColor;
      this.TireSmokeColor = currentVehicle.TireSmokeColor;
      this.VehicleHash = Game.Player.Character.CurrentVehicle.Model.Hash.ToString();
      this.BulletProofTires = currentVehicle.CanTiresBurst;
      this.TrimColor = currentVehicle.TrimColor;
      try
      {
        this.HasClanTag = this.VE.ReturnClanEmblemOn(currentVehicle);
        this.Config.SetValue<bool>("Configurations", "CLanTagOn", this.HasClanTag);
      }
      catch (Exception ex)
      {
      }
      this.Config.SetValue<string>("Configurations", "VehicleName", this.VehicleName);
      this.Config.SetValue<GTA.Native.VehicleHash>("Configurations", "VehicleNameHash", this.VehicleNameHash);
      this.Config.SetValue<int>("Configurations", "VehicleHash", Game.Player.Character.CurrentVehicle.Model.Hash);
      this.Config.Save();
      this.Config.SetValue<int>("Configurations", "Roof", this.RoofId);
      this.Config.SetValue<int>("Configurations", "AerialsId", this.AerialsId);
      this.Config.SetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
      this.Config.SetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
      this.Config.SetValue<int>("Configurations", "ArmorId", this.ArmorId);
      this.Config.SetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
      this.Config.SetValue<int>("Configurations", "BrakesId", this.BrakesId);
      this.Config.SetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
      this.Config.SetValue<int>("Configurations", "DashboardId", this.DashboardId);
      this.Config.SetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
      this.Config.SetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
      this.Config.SetValue<int>("Configurations", "EngineId", this.EngineId);
      this.Config.SetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
      this.Config.SetValue<int>("Configurations", "ExaustId", this.ExaustId);
      this.Config.SetValue<int>("Configurations", "FenderId", this.FenderId);
      this.Config.SetValue<int>("Configurations", "FrameId", this.FrameId);
      this.Config.SetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
      this.Config.SetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
      this.Config.SetValue<int>("Configurations", "GrilleId", this.GrilleId);
      this.Config.SetValue<int>("Configurations", "HoodId", this.HoodId);
      this.Config.SetValue<int>("Configurations", "HornsId", this.HornsId);
      this.Config.SetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
      this.Config.SetValue<int>("Configurations", "LiveryId", this.LiveryId);
      this.Config.SetValue<int>("Configurations", "SecondaryVehicleLivery", this.SecondaryVehicleLivery);
      this.Config.SetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
      this.Config.SetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
      this.Config.SetValue<int>("Configurations", "Plateholder", this.Plateholder);
      this.Config.SetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
      this.Config.SetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
      this.Config.SetValue<int>("Configurations", "SeatsId", this.SeatsId);
      this.Config.SetValue<int>("Configurations", "speakers", this.speakers);
      this.Config.SetValue<int>("Configurations", "speakers", this.speakers);
      this.Config.SetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
      this.Config.SetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
      this.Config.SetValue<int>("Configurations", "StrutId", this.StrutId);
      this.Config.SetValue<int>("Configurations", "RoofId", this.RoofId);
      this.Config.SetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
      this.Config.SetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
      this.Config.SetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.Config.SetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.Config.SetValue<int>("Configurations", "TrunkId", this.TrunkId);
      this.Config.SetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
      this.Config.SetValue<int>("Configurations", "WindowId", this.WindowId);
      this.Config.SetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
      this.Config.SetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.Config.SetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.Config.SetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
      this.Config.SetValue<Color>("Configurations", "NeonColour", this.NeonColour);
      this.Config.SetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
      this.Config.SetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
      this.PrimaryColor = Game.Player.Character.CurrentVehicle.PrimaryColor;
      this.SecondaryColor = Game.Player.Character.CurrentVehicle.SecondaryColor;
      if (Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom);
        Color customPrimaryColor = Game.Player.Character.CurrentVehicle.CustomPrimaryColor;
        this.Config.SetValue<string>("Configurations", "CustomPrimaryColor", "Color [A = 255, R = " + customPrimaryColor.R.ToString() + ", G = " + customPrimaryColor.G.ToString() + ", B = " + customPrimaryColor.B.ToString() + "]");
        this.Config.Save();
      }
      if (!Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom);
        this.Config.SetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
        this.Config.Save();
      }
      if (Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom);
        Color customSecondaryColor = Game.Player.Character.CurrentVehicle.CustomSecondaryColor;
        this.Config.SetValue<string>("Configurations", "CustomSecondaryColor", "Color [A = 255, R = " + customSecondaryColor.R.ToString() + ", G = " + customSecondaryColor.G.ToString() + ", B = " + customSecondaryColor.B.ToString() + "]");
        this.Config.Save();
      }
      if (!Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom);
        this.Config.SetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
        this.Config.Save();
      }
      this.Config.SetValue<int>("Configurations", "Blades", this.Blades);
      this.Config.SetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
      this.Config.SetValue<bool>("Configurations", "TurboActive", this.TurboActive);
      this.Config.SetValue<int>("Configurations", "LightColor", this.LightColor);
      this.Config.SetValue<string>("Configurations", "VehicleHash", this.VehicleHash);
      this.Config.SetValue<Color>("Configurations", "NeonColor", this.NeonColor);
      this.Config.SetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
      this.Config.SetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
      this.Config.SetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
      this.Config.SetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
      this.Config.SetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.Config.SetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.Config.SetValue<Color>("Configurations", "TireSmokeColor", this.TireSmokeColor);
      this.Config.SetValue<bool>("Configurations", "TireSmoke", this.TireSmoke);
      this.Config.SetValue<VehicleColor>("Configurations", "TrimColor", this.TrimColor);
      this.Config.SetValue<bool>("Configurations", "BulletProofTires", this.BulletProofTires);
      this.Config.SetValue<int>("Configurations", "WheelType", this.WheelType);
      if (this.ExtraOn.Count >= 1)
      {
        for (int index = 0; index < this.ExtraOn.Count; ++index)
          this.Config.SetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), this.ExtraOn[index]);
      }
      this.Config.Save();
    }

    public void Save()
    {
      if (!((Entity) Game.Player.Character.CurrentVehicle != (Entity) null))
        return;
      this.VehicleName = Game.Player.Character.CurrentVehicle.DisplayName;
      this.VehicleNameHash = (GTA.Native.VehicleHash) Game.Player.Character.CurrentVehicle.Model.Hash;
      this.Config.SetValue<string>("Configurations", "VehicleName", Game.Player.Character.CurrentVehicle.DisplayName);
      this.Config.SetValue<int>("Configurations", "VehicleHash", Game.Player.Character.CurrentVehicle.Model.Hash);
      this.Config.Save();
      this.SpawnHash = Game.Player.Character.CurrentVehicle.Model.Hash;
      this.SpawnString = Game.Player.Character.CurrentVehicle.DisplayName;
      this.CustomTiresOn = Function.Call<bool>(Hash._0xB3924ECD70E095DC, (InputArgument) Game.Player.Character.CurrentVehicle, (InputArgument) 23);
      this.RoofId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Roof);
      this.AerialsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Aerials);
      this.AirfilterId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.AirFilter);
      this.ArchCoverId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.ArchCover);
      this.ArmorId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Armor);
      this.BackWheelsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.BackWheels);
      this.BrakesId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Brakes);
      this.ColumnShifterLeversId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.ColumnShifterLevers);
      this.DashboardId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Dashboard);
      this.DialDesignId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.DialDesign);
      this.DoorSpeekersId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.DoorSpeakers);
      this.EngineId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Engine);
      this.EngineBlockId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.EngineBlock);
      this.ExaustId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Exhaust);
      this.FenderId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Fender);
      this.FrameId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Frame);
      this.FrontBumperId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.FrontBumper);
      this.FrontWheelsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.FrontWheels);
      this.GrilleId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Grille);
      this.HoodId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Hood);
      this.HornsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Horns);
      this.HydralicsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Hydraulics);
      this.LiveryId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Livery);
      this.SecondaryVehicleLivery = Function.Call<int>(Hash._0x2BB9230590DA5E8A, (InputArgument) Game.Player.Character.CurrentVehicle);
      this.OrnamentsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Ornaments);
      this.PlaquesId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Plaques);
      this.Plateholder = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.PlateHolder);
      this.RearBumperId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.RearBumper);
      this.RightFenderId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.RightFender);
      this.SeatsId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Seats);
      this.SideSkirt = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.SideSkirt);
      this.speakers = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Speakers);
      this.SpoilersId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Spoilers);
      this.SteeringWheelId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.SteeringWheels);
      this.StrutId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Struts);
      this.SuspensionId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Suspension);
      this.TankId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Tank);
      this.TransmissionId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Transmission);
      this.TrimId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Trim);
      this.TrimDesignId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.TrimDesign);
      this.TrunkId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Trunk);
      this.VanityPlatesId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.VanityPlates);
      this.WindowId = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Windows);
      this.PrimaryColor = Game.Player.Character.CurrentVehicle.PrimaryColor;
      this.SecondaryColor = Game.Player.Character.CurrentVehicle.SecondaryColor;
      if (Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom);
        Color customPrimaryColor = Game.Player.Character.CurrentVehicle.CustomPrimaryColor;
        this.Config.SetValue<string>("Configurations", "CustomPrimaryColor", "Color [A = 255, R = " + customPrimaryColor.R.ToString() + ", G = " + customPrimaryColor.G.ToString() + ", B = " + customPrimaryColor.B.ToString() + "]");
        this.Config.Save();
      }
      if (!Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom);
        this.Config.SetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
        this.Config.Save();
      }
      if (Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom);
        Color customSecondaryColor = Game.Player.Character.CurrentVehicle.CustomSecondaryColor;
        this.Config.SetValue<string>("Configurations", "CustomSecondaryColor", "Color [A = 255, R = " + customSecondaryColor.R.ToString() + ", G = " + customSecondaryColor.G.ToString() + ", B = " + customSecondaryColor.B.ToString() + "]");
        this.Config.Save();
      }
      if (!Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom);
        this.Config.SetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
        this.Config.Save();
      }
      this.Wheelcolour = Game.Player.Character.CurrentVehicle.RimColor;
      this.DashBoardColour = Game.Player.Character.CurrentVehicle.DashboardColor;
      this.PearlCent = Game.Player.Character.CurrentVehicle.PearlescentColor;
      this.NeonColour = Game.Player.Character.CurrentVehicle.NeonLightsColor;
      this.TintId = Game.Player.Character.CurrentVehicle.WindowTint;
      this.PlanteNo = Game.Player.Character.CurrentVehicle.NumberPlate;
      this.Blades = Game.Player.Character.CurrentVehicle.GetMod(VehicleMod.Trim);
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      this.HasXenonLights = currentVehicle.IsToggleModOn(VehicleToggleMod.XenonHeadlights);
      this.TurboActive = currentVehicle.IsToggleModOn(VehicleToggleMod.Turbo);
      this.LightColor = Function.Call<int>((Hash) 4467343895069330651, (InputArgument) currentVehicle);
      this.VehicleHash = Game.Player.Character.CurrentVehicle.Model.Hash.ToString();
      this.RightNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Right);
      this.LeftNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Left);
      this.BackNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Back);
      this.FrontNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Front);
      this.NeonColor = currentVehicle.NeonLightsColor;
      this.BulletProofTires = currentVehicle.CanTiresBurst;
      this.TrimColor = currentVehicle.TrimColor;
      this.TireSmoke = currentVehicle.IsToggleModOn(VehicleToggleMod.TireSmoke);
      this.Wheelcolour = currentVehicle.RimColor;
      this.DashBoardColour = currentVehicle.DashboardColor;
      this.TireSmokeColor = currentVehicle.TireSmokeColor;
      this.WheelType = Function.Call<int>(Hash._0xB3ED1BFB4BE636DC, (InputArgument) Game.Player.Character.CurrentVehicle);
      try
      {
        this.HasClanTag = this.VE.ReturnClanEmblemOn(currentVehicle);
        this.Config.SetValue<bool>("Configurations", "CLanTagOn", this.HasClanTag);
      }
      catch (Exception ex)
      {
      }
      if (this.VehicleName == "CARBON")
        this.VehicleName = "CARBONRS";
      if (this.VehicleName == "UTILTRUC")
        this.VehicleName = "UTILLITRUCK";
      if (this.VehicleName == "FORK")
        this.VehicleName = "FORKLIFT";
      if (this.VehicleName == "LANDSTAL")
        this.VehicleName = "LANDSTALKER";
      if (this.VehicleName == "CAVCADE")
        this.VehicleName = "CAVALCADE";
      if (this.VehicleName == "SANCHEZ02")
        this.VehicleName = "SANCHEZ2";
      if (this.VehicleName == "SANCHEZ01")
        this.VehicleName = "SANCHEZ";
      if (this.VehicleName == "FAGGION")
        this.VehicleName = "FAGGIO";
      if (this.VehicleName == "STINGERG")
        this.VehicleName = "FELTZER3";
      if (this.VehicleName == "SCHWARZE")
        this.VehicleName = "SCHWARZER";
      if (this.VehicleName == "SCHWARZE")
        this.VehicleName = "SCHWARZER";
      if (this.VehicleName == "KHAMEL")
        this.VehicleName = "KHAMELION";
      if (this.VehicleName == "FURORE")
        this.VehicleName = "FUROREGT";
      if (this.VehicleName == "COGCABRI")
        this.VehicleName = "COGCABRIO";
      if (this.VehicleName == "RLOADER")
        this.VehicleName = "RATLOADER";
      if (this.VehicleName == "RLOADER2")
        this.VehicleName = "RATLOADER2";
      if (this.VehicleName == "FELTZER")
        this.VehicleName = "FELTZER2";
      if (this.VehicleName == "WASHINGT")
        this.VehicleName = "WASHINGTON";
      if (this.VehicleName == "BUFFALO02")
        this.VehicleName = "BUFFALO2";
      if (this.VehicleName == "TAILGATE")
        this.VehicleName = "TAILGATER";
      if (this.VehicleName == "SCHAFTER")
        this.VehicleName = "SCHAFTER2";
      if (this.VehicleName == "SCHAFTER")
        this.VehicleName = "SCHAFTER2";
      if (this.VehicleName == "COGNOSC2")
        this.VehicleName = "COGNOSCENTI2";
      if (this.VehicleName == "COGNOSC2")
        this.VehicleName = "COGNOSCENTI2";
      if (this.VehicleName == "COGNOSC")
        this.VehicleName = "COGNOSCENTI";
      if (this.VehicleName == "COGNOSC")
        this.VehicleName = "COGNOSCENTI";
      if (this.VehicleName == "ASTROPE")
        this.VehicleName = "ASTEROPE";
      if (this.VehicleName == "SANDKIN2")
        this.VehicleName = "SANDKING2";
      if (this.VehicleName == "REBEL02")
        this.VehicleName = "REBEL2";
      if (this.VehicleName == "REBEL01")
        this.VehicleName = "REBEL";
      if (this.VehicleName == "RANCHERX")
        this.VehicleName = "RANCHERXL";
      if (this.VehicleName == "BFINJECT")
        this.VehicleName = "BFINJECTION";
      if (this.VehicleName == "DOMINATO2")
        this.VehicleName = "DOMINATOR2";
      if (this.VehicleName == "DILETTAN")
        this.VehicleName = "DILETTANTE";
      if (this.VehicleName == "VOODOO2")
        this.VehicleName = "VOODOO";
      else if (this.VehicleName == "VOODOO")
        this.VehicleName = "VOODOO2";
      if (this.VehicleName == "ABMULAN")
        this.VehicleName = "AMBULANCE";
      if (this.VehicleName == "Ruiner3")
        this.VehicleName = "Ruiner3";
      if (this.VehicleName == "BUCCANEE2")
        this.VehicleName = "BUCCANEER2";
      if (this.VehicleName == "BUCCANEE")
        this.VehicleName = "BUCCANEER";
      if (this.VehicleName == "CARBONIZ")
        this.VehicleName = "CARBONIZZARE";
      if (this.VehicleName == "penetrator")
        this.VehicleName = "PENETRATOR";
      if (this.VehicleName == "TROPHY")
        this.VehicleName = "TROPHYTRUCK";
      if (this.VehicleName == "TROPHY2")
        this.VehicleName = "TROPHYTRUCK2";
      if (this.VehicleName == "ROOSEVELT")
        this.VehicleName = "Btype";
      if (this.VehicleName == "VERLIER")
        this.VehicleName = "VERLIERER2";
      if (this.VehicleName == "BTYPE2")
        this.VehicleName = "Btype2";
      if (this.VehicleName == "ROOSEVELT2")
        this.VehicleName = "Btype3";
      if (this.VehicleName == "DOMINATO")
        this.VehicleName = "DOMINATOR";
      if (this.VehicleName == "NITESHAD")
        this.VehicleName = "NIGHTSHADE";
      this.Config.SetValue<string>("Configurations", "VehicleName", this.VehicleName);
      this.Config.SetValue<GTA.Native.VehicleHash>("Configurations", "VehicleNameHash", this.VehicleNameHash);
      this.Config.SetValue<int>("Configurations", "Roof", this.RoofId);
      this.Config.SetValue<int>("Configurations", "AerialsId", this.AerialsId);
      this.Config.SetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
      this.Config.SetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
      this.Config.SetValue<int>("Configurations", "ArmorId", this.ArmorId);
      this.Config.SetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
      this.Config.SetValue<int>("Configurations", "BrakesId", this.BrakesId);
      this.Config.SetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
      this.Config.SetValue<int>("Configurations", "DashboardId", this.DashboardId);
      this.Config.SetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
      this.Config.SetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
      this.Config.SetValue<int>("Configurations", "EngineId", this.EngineId);
      this.Config.SetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
      this.Config.SetValue<int>("Configurations", "ExaustId", this.ExaustId);
      this.Config.SetValue<int>("Configurations", "FenderId", this.FenderId);
      this.Config.SetValue<int>("Configurations", "FrameId", this.FrameId);
      this.Config.SetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
      this.Config.SetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
      this.Config.SetValue<int>("Configurations", "GrilleId", this.GrilleId);
      this.Config.SetValue<int>("Configurations", "HoodId", this.HoodId);
      this.Config.SetValue<int>("Configurations", "HornsId", this.HornsId);
      this.Config.SetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
      this.Config.SetValue<int>("Configurations", "LiveryId", this.LiveryId);
      this.Config.SetValue<int>("Configurations", "SecondaryVehicleLivery", this.SecondaryVehicleLivery);
      this.Config.SetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
      this.Config.SetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
      this.Config.SetValue<int>("Configurations", "Plateholder", this.Plateholder);
      this.Config.SetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
      this.Config.SetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
      this.Config.SetValue<int>("Configurations", "SeatsId", this.SeatsId);
      this.Config.SetValue<int>("Configurations", "speakers", this.speakers);
      this.Config.SetValue<int>("Configurations", "speakers", this.speakers);
      this.Config.SetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
      this.Config.SetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
      this.Config.SetValue<int>("Configurations", "StrutId", this.StrutId);
      this.Config.SetValue<int>("Configurations", "RoofId", this.RoofId);
      this.Config.SetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
      this.Config.SetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
      this.Config.SetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.Config.SetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.Config.SetValue<int>("Configurations", "TrunkId", this.TrunkId);
      this.Config.SetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
      this.Config.SetValue<int>("Configurations", "WindowId", this.WindowId);
      this.Config.SetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
      if (Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom);
        Color customPrimaryColor = Game.Player.Character.CurrentVehicle.CustomPrimaryColor;
        this.Config.SetValue<string>("Configurations", "CustomPrimaryColor", "Color [A = 255, R = " + customPrimaryColor.R.ToString() + ", G = " + customPrimaryColor.G.ToString() + ", B = " + customPrimaryColor.B.ToString() + "]");
      }
      if (!Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom);
        this.Config.SetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
      }
      if (Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom);
        Color customSecondaryColor = Game.Player.Character.CurrentVehicle.CustomSecondaryColor;
        this.Config.SetValue<string>("Configurations", "CustomSecondaryColor", "Color [A = 255, R = " + customSecondaryColor.R.ToString() + ", G = " + customSecondaryColor.G.ToString() + ", B = " + customSecondaryColor.B.ToString() + "]");
      }
      if (!Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom);
        this.Config.SetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
      }
      this.Config.SetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.Config.SetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.Config.SetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
      this.Config.SetValue<Color>("Configurations", "NeonColour", this.NeonColour);
      this.Config.SetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
      this.Config.SetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
      this.Config.SetValue<int>("Configurations", "Blades", this.Blades);
      this.Config.SetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
      this.Config.SetValue<int>("Configurations", "LightColor", this.LightColor);
      this.Config.SetValue<bool>("Configurations", "TurboActive", this.TurboActive);
      this.VehicleHash = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) this.VehicleName).ToString();
      this.Config.SetValue<Color>("Configurations", "NeonColor", this.NeonColor);
      this.Config.SetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
      this.Config.SetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
      this.Config.SetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
      this.Config.SetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
      this.Config.SetValue<string>("Configurations", "VehicleHash", this.VehicleHash);
      this.Config.SetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.Config.SetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.Config.SetValue<Color>("Configurations", "TireSmokeColor", this.TireSmokeColor);
      this.Config.SetValue<bool>("Configurations", "TireSmoke", this.TireSmoke);
      this.Config.SetValue<VehicleColor>("Configurations", "TrimColor", this.TrimColor);
      this.Config.SetValue<bool>("Configurations", "BulletProofTires", this.BulletProofTires);
      this.Config.SetValue<int>("Configurations", "WheelType", this.WheelType);
      if (this.ExtraOn.Count >= 1)
      {
        for (int index = 0; index < this.ExtraOn.Count; ++index)
          this.Config.SetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), this.ExtraOn[index]);
      }
      this.Config.Save();
      if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        Game.Player.Character.CurrentVehicle.Delete();
    }

    public void SaveCurrentCar(string car, Vehicle V)
    {
      this.VehicleName = car;
      this.VehicleNameHash = (GTA.Native.VehicleHash) V.Model.Hash;
      this.Config.SetValue<string>("Configurations", "VehicleName", V.DisplayName);
      this.Config.SetValue<int>("Configurations", "VehicleHash", V.Model.Hash);
      this.Config.Save();
      this.SpawnHash = V.Model.Hash;
      this.SpawnString = V.DisplayName;
      this.RoofId = V.GetMod(VehicleMod.Roof);
      this.AerialsId = V.GetMod(VehicleMod.Aerials);
      this.AirfilterId = V.GetMod(VehicleMod.AirFilter);
      this.ArchCoverId = V.GetMod(VehicleMod.ArchCover);
      this.ArmorId = V.GetMod(VehicleMod.Armor);
      this.BackWheelsId = V.GetMod(VehicleMod.BackWheels);
      this.BrakesId = V.GetMod(VehicleMod.Brakes);
      this.ColumnShifterLeversId = V.GetMod(VehicleMod.ColumnShifterLevers);
      this.DashboardId = V.GetMod(VehicleMod.Dashboard);
      this.DialDesignId = V.GetMod(VehicleMod.DialDesign);
      this.DoorSpeekersId = V.GetMod(VehicleMod.DoorSpeakers);
      this.EngineId = V.GetMod(VehicleMod.Engine);
      this.EngineBlockId = V.GetMod(VehicleMod.EngineBlock);
      this.ExaustId = V.GetMod(VehicleMod.Exhaust);
      this.FenderId = V.GetMod(VehicleMod.Fender);
      this.FrameId = V.GetMod(VehicleMod.Frame);
      this.FrontBumperId = V.GetMod(VehicleMod.FrontBumper);
      this.FrontWheelsId = V.GetMod(VehicleMod.FrontWheels);
      this.GrilleId = V.GetMod(VehicleMod.Grille);
      this.HoodId = V.GetMod(VehicleMod.Hood);
      this.HornsId = V.GetMod(VehicleMod.Horns);
      this.HydralicsId = V.GetMod(VehicleMod.Hydraulics);
      this.LiveryId = V.GetMod(VehicleMod.Livery);
      this.SecondaryVehicleLivery = Function.Call<int>(Hash._0x2BB9230590DA5E8A, (InputArgument) V);
      this.OrnamentsId = V.GetMod(VehicleMod.Ornaments);
      this.PlaquesId = V.GetMod(VehicleMod.Plaques);
      this.Plateholder = V.GetMod(VehicleMod.PlateHolder);
      this.RearBumperId = V.GetMod(VehicleMod.RearBumper);
      this.RightFenderId = V.GetMod(VehicleMod.RightFender);
      this.SeatsId = V.GetMod(VehicleMod.Seats);
      this.SideSkirt = V.GetMod(VehicleMod.SideSkirt);
      this.speakers = V.GetMod(VehicleMod.Speakers);
      this.SpoilersId = V.GetMod(VehicleMod.Spoilers);
      this.SteeringWheelId = V.GetMod(VehicleMod.SteeringWheels);
      this.StrutId = V.GetMod(VehicleMod.Struts);
      this.SuspensionId = V.GetMod(VehicleMod.Suspension);
      this.TankId = V.GetMod(VehicleMod.Tank);
      this.TransmissionId = V.GetMod(VehicleMod.Transmission);
      this.TrimId = V.GetMod(VehicleMod.Trim);
      this.TrimDesignId = V.GetMod(VehicleMod.TrimDesign);
      this.TrunkId = V.GetMod(VehicleMod.Trunk);
      this.VanityPlatesId = V.GetMod(VehicleMod.VanityPlates);
      this.WindowId = V.GetMod(VehicleMod.Windows);
      this.CustomTiresOn = Function.Call<bool>(Hash._0xB3924ECD70E095DC, (InputArgument) V, (InputArgument) 23);
      this.Blades = V.GetMod(VehicleMod.Trim);
      if (!V.IsPrimaryColorCustom)
        this.PrimaryColor = Game.Player.Character.CurrentVehicle.PrimaryColor;
      if (!V.IsSecondaryColorCustom)
        this.SecondaryColor = Game.Player.Character.CurrentVehicle.SecondaryColor;
      this.Wheelcolour = V.RimColor;
      this.DashBoardColour = V.DashboardColor;
      this.PearlCent = V.PearlescentColor;
      this.NeonColour = V.NeonLightsColor;
      Vehicle currentVehicle = Game.Player.Character.CurrentVehicle;
      this.HasXenonLights = currentVehicle.IsToggleModOn(VehicleToggleMod.XenonHeadlights);
      this.TurboActive = currentVehicle.IsToggleModOn(VehicleToggleMod.Turbo);
      this.LightColor = Function.Call<int>((Hash) 4467343895069330651, (InputArgument) currentVehicle);
      this.TintId = V.WindowTint;
      this.RightNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Right);
      this.LeftNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Left);
      this.BackNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Back);
      this.FrontNeonOn = currentVehicle.IsNeonLightsOn(VehicleNeonLight.Front);
      this.NeonColor = currentVehicle.NeonLightsColor;
      this.TireSmoke = currentVehicle.IsToggleModOn(VehicleToggleMod.TireSmoke);
      this.Wheelcolour = currentVehicle.RimColor;
      this.DashBoardColour = currentVehicle.DashboardColor;
      this.TireSmokeColor = currentVehicle.TireSmokeColor;
      this.VehicleHash = V.Model.Hash.ToString();
      this.PlanteNo = V.NumberPlate;
      this.BulletProofTires = V.CanTiresBurst;
      this.TrimColor = V.TrimColor;
      this.WheelType = Function.Call<int>(Hash._0xB3ED1BFB4BE636DC, (InputArgument) Game.Player.Character.CurrentVehicle);
      try
      {
        this.HasClanTag = this.VE.ReturnClanEmblemOn(V);
        this.Config.SetValue<bool>("Configurations", "CLanTagOn", this.HasClanTag);
      }
      catch (Exception ex)
      {
      }
      if (this.VehicleName == "CARBON")
        this.VehicleName = "CARBONRS";
      if (this.VehicleName == "UTILTRUC")
        this.VehicleName = "UTILLITRUCK";
      if (this.VehicleName == "FORK")
        this.VehicleName = "FORKLIFT";
      if (this.VehicleName == "LANDSTAL")
        this.VehicleName = "LANDSTALKER";
      if (this.VehicleName == "CAVCADE")
        this.VehicleName = "CAVALCADE";
      if (this.VehicleName == "SANCHEZ02")
        this.VehicleName = "SANCHEZ2";
      if (this.VehicleName == "SANCHEZ01")
        this.VehicleName = "SANCHEZ";
      if (this.VehicleName == "FAGGION")
        this.VehicleName = "FAGGIO";
      if (this.VehicleName == "STINGERG")
        this.VehicleName = "FELTZER3";
      if (this.VehicleName == "SCHWARZE")
        this.VehicleName = "SCHWARZER";
      if (this.VehicleName == "SCHWARZE")
        this.VehicleName = "SCHWARZER";
      if (this.VehicleName == "KHAMEL")
        this.VehicleName = "KHAMELION";
      if (this.VehicleName == "FURORE")
        this.VehicleName = "FUROREGT";
      if (this.VehicleName == "COGCABRI")
        this.VehicleName = "COGCABRIO";
      if (this.VehicleName == "RLOADER")
        this.VehicleName = "RATLOADER";
      if (this.VehicleName == "RLOADER2")
        this.VehicleName = "RATLOADER2";
      if (this.VehicleName == "FELTZER")
        this.VehicleName = "FELTZER2";
      if (this.VehicleName == "WASHINGT")
        this.VehicleName = "WASHINGTON";
      if (this.VehicleName == "BUFFALO02")
        this.VehicleName = "BUFFALO2";
      if (this.VehicleName == "TAILGATE")
        this.VehicleName = "TAILGATER";
      if (this.VehicleName == "SCHAFTER")
        this.VehicleName = "SCHAFTER2";
      if (this.VehicleName == "SCHAFTER")
        this.VehicleName = "SCHAFTER2";
      if (this.VehicleName == "COGNOSC2")
        this.VehicleName = "COGNOSCENTI2";
      if (this.VehicleName == "COGNOSC2")
        this.VehicleName = "COGNOSCENTI2";
      if (this.VehicleName == "COGNOSC")
        this.VehicleName = "COGNOSCENTI";
      if (this.VehicleName == "COGNOSC")
        this.VehicleName = "COGNOSCENTI";
      if (this.VehicleName == "ASTROPE")
        this.VehicleName = "ASTEROPE";
      if (this.VehicleName == "SANDKIN2")
        this.VehicleName = "SANDKING2";
      if (this.VehicleName == "REBEL02")
        this.VehicleName = "REBEL2";
      if (this.VehicleName == "REBEL01")
        this.VehicleName = "REBEL";
      if (this.VehicleName == "RANCHERX")
        this.VehicleName = "RANCHERXL";
      if (this.VehicleName == "BFINJECT")
        this.VehicleName = "BFINJECTION";
      if (this.VehicleName == "DOMINATO2")
        this.VehicleName = "DOMINATOR2";
      if (this.VehicleName == "DILETTAN")
        this.VehicleName = "DILETTANTE";
      if (this.VehicleName == "VOODOO2")
        this.VehicleName = "VOODOO";
      else if (this.VehicleName == "VOODOO")
        this.VehicleName = "VOODOO2";
      if (this.VehicleName == "ABMULAN")
        this.VehicleName = "AMBULANCE";
      if (this.VehicleName == "Ruiner3")
        this.VehicleName = "Ruiner3";
      if (this.VehicleName == "BUCCANEE2")
        this.VehicleName = "BUCCANEER2";
      if (this.VehicleName == "BUCCANEE")
        this.VehicleName = "BUCCANEER";
      if (this.VehicleName == "CARBONIZ")
        this.VehicleName = "CARBONIZZARE";
      if (this.VehicleName == "penetrator")
        this.VehicleName = "PENETRATOR";
      if (this.VehicleName == "TROPHY")
        this.VehicleName = "TROPHYTRUCK";
      if (this.VehicleName == "TROPHY2")
        this.VehicleName = "TROPHYTRUCK2";
      if (this.VehicleName == "ROOSEVELT")
        this.VehicleName = "Btype";
      if (this.VehicleName == "VERLIER")
        this.VehicleName = "VERLIERER2";
      if (this.VehicleName == "BTYPE2")
        this.VehicleName = "Btype2";
      if (this.VehicleName == "ROOSEVELT2")
        this.VehicleName = "Btype3";
      if (this.VehicleName == "DOMINATO")
        this.VehicleName = "DOMINATOR";
      if (this.VehicleName == "NITESHAD")
        this.VehicleName = "NIGHTSHADE";
      this.Config.SetValue<string>("Configurations", "VehicleName", this.VehicleName);
      this.Config.SetValue<string>("Configurations", "VehicleName", this.VehicleName);
      this.Config.SetValue<int>("Configurations", "Roof", this.RoofId);
      this.Config.SetValue<int>("Configurations", "AerialsId", this.AerialsId);
      this.Config.SetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
      this.Config.SetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
      this.Config.SetValue<int>("Configurations", "ArmorId", this.ArmorId);
      this.Config.SetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
      this.Config.SetValue<int>("Configurations", "BrakesId", this.BrakesId);
      this.Config.SetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
      this.Config.SetValue<int>("Configurations", "DashboardId", this.DashboardId);
      this.Config.SetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
      this.Config.SetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
      this.Config.SetValue<int>("Configurations", "EngineId", this.EngineId);
      this.Config.SetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
      this.Config.SetValue<int>("Configurations", "ExaustId", this.ExaustId);
      this.Config.SetValue<int>("Configurations", "FenderId", this.FenderId);
      this.Config.SetValue<int>("Configurations", "FrameId", this.FrameId);
      this.Config.SetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
      this.Config.SetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
      this.Config.SetValue<int>("Configurations", "GrilleId", this.GrilleId);
      this.Config.SetValue<int>("Configurations", "HoodId", this.HoodId);
      this.Config.SetValue<int>("Configurations", "HornsId", this.HornsId);
      this.Config.SetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
      this.Config.SetValue<int>("Configurations", "LiveryId", this.LiveryId);
      this.Config.SetValue<int>("Configurations", "SecondaryVehicleLivery", this.SecondaryVehicleLivery);
      this.Config.SetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
      this.Config.SetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
      this.Config.SetValue<int>("Configurations", "Plateholder", this.Plateholder);
      this.Config.SetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
      this.Config.SetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
      this.Config.SetValue<int>("Configurations", "SeatsId", this.SeatsId);
      this.Config.SetValue<int>("Configurations", "speakers", this.speakers);
      this.Config.SetValue<int>("Configurations", "speakers", this.speakers);
      this.Config.SetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
      this.Config.SetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
      this.Config.SetValue<int>("Configurations", "StrutId", this.StrutId);
      this.Config.SetValue<int>("Configurations", "RoofId", this.RoofId);
      this.Config.SetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
      this.Config.SetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
      this.Config.SetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.Config.SetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
      this.Config.SetValue<int>("Configurations", "TrunkId", this.TrunkId);
      this.Config.SetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
      this.Config.SetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
      this.PrimaryColor = Game.Player.Character.CurrentVehicle.PrimaryColor;
      this.SecondaryColor = Game.Player.Character.CurrentVehicle.SecondaryColor;
      if (Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom);
        Color customPrimaryColor = Game.Player.Character.CurrentVehicle.CustomPrimaryColor;
        this.Config.SetValue<string>("Configurations", "CustomPrimaryColor", "Color [A = 255, R = " + customPrimaryColor.R.ToString() + ", G = " + customPrimaryColor.G.ToString() + ", B = " + customPrimaryColor.B.ToString() + "]");
        this.Config.Save();
      }
      if (!Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomPrimaryColor", Game.Player.Character.CurrentVehicle.IsPrimaryColorCustom);
        this.Config.SetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
        this.Config.Save();
      }
      if (Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom);
        Color customSecondaryColor = Game.Player.Character.CurrentVehicle.CustomSecondaryColor;
        this.Config.SetValue<string>("Configurations", "CustomSecondaryColor", "Color [A = 255, R = " + customSecondaryColor.R.ToString() + ", G = " + customSecondaryColor.G.ToString() + ", B = " + customSecondaryColor.B.ToString() + "]");
        this.Config.Save();
      }
      if (!Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom)
      {
        this.Config.SetValue<bool>("Configurations", "UseCustomSecondaryColor", Game.Player.Character.CurrentVehicle.IsSecondaryColorCustom);
        this.Config.SetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
        this.Config.Save();
      }
      this.Config.SetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.Config.SetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.Config.SetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
      this.Config.SetValue<Color>("Configurations", "NeonColour", this.NeonColour);
      this.Config.SetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
      this.Config.SetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
      this.Config.SetValue<int>("Configurations", "Blades", this.Blades);
      this.Config.SetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
      this.Config.SetValue<int>("Configurations", "LightColor", this.LightColor);
      this.Config.SetValue<string>("Configurations", "VehicleHash", this.VehicleHash);
      this.Config.SetValue<bool>("Configurations", "TurboActive", this.TurboActive);
      this.Config.SetValue<Color>("Configurations", "NeonColor", this.NeonColor);
      this.Config.SetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
      this.Config.SetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
      this.Config.SetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
      this.Config.SetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
      this.Config.SetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
      this.Config.SetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
      this.Config.SetValue<Color>("Configurations", "TireSmokeColor", this.TireSmokeColor);
      this.Config.SetValue<bool>("Configurations", "TireSmoke", this.TireSmoke);
      this.Config.SetValue<VehicleColor>("Configurations", "TrimColor", this.TrimColor);
      this.Config.SetValue<bool>("Configurations", "BulletProofTires", this.BulletProofTires);
      this.Config.SetValue<int>("Configurations", "WheelType", this.WheelType);
      if (this.ExtraOn.Count >= 1)
      {
        for (int index = 0; index < this.ExtraOn.Count; ++index)
          this.Config.SetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), this.ExtraOn[index]);
      }
      this.Config.Save();
    }

    public void SaveRandomMods(Vehicle newvehicle)
    {
      System.Random random = new System.Random();
      Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) newvehicle.Handle, (InputArgument) 0);
      Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) newvehicle, (InputArgument) this.WheelType);
      newvehicle.SetMod(VehicleMod.Livery, random.Next(-1, newvehicle.GetModCount(VehicleMod.Livery)), false);
      newvehicle.SetMod(VehicleMod.Roof, random.Next(-1, newvehicle.GetModCount(VehicleMod.Roof)), true);
      newvehicle.SetMod(VehicleMod.Aerials, random.Next(-1, newvehicle.GetModCount(VehicleMod.Aerials)), true);
      newvehicle.SetMod(VehicleMod.AirFilter, random.Next(-1, newvehicle.GetModCount(VehicleMod.AirFilter)), true);
      newvehicle.SetMod(VehicleMod.ArchCover, random.Next(-1, newvehicle.GetModCount(VehicleMod.ArchCover)), true);
      newvehicle.SetMod(VehicleMod.Armor, random.Next(-1, newvehicle.GetModCount(VehicleMod.Armor)), true);
      newvehicle.SetMod(VehicleMod.BackWheels, random.Next(-1, newvehicle.GetModCount(VehicleMod.Brakes)), true);
      newvehicle.SetMod(VehicleMod.Brakes, random.Next(-1, newvehicle.GetModCount(VehicleMod.Livery)), true);
      newvehicle.SetMod(VehicleMod.ColumnShifterLevers, random.Next(-1, newvehicle.GetModCount(VehicleMod.ColumnShifterLevers)), true);
      newvehicle.SetMod(VehicleMod.Dashboard, random.Next(-1, newvehicle.GetModCount(VehicleMod.Dashboard)), true);
      newvehicle.SetMod(VehicleMod.DialDesign, random.Next(-1, newvehicle.GetModCount(VehicleMod.DialDesign)), true);
      newvehicle.SetMod(VehicleMod.DoorSpeakers, random.Next(-1, newvehicle.GetModCount(VehicleMod.DoorSpeakers)), true);
      newvehicle.SetMod(VehicleMod.Engine, random.Next(-1, newvehicle.GetModCount(VehicleMod.Engine)), true);
      newvehicle.SetMod(VehicleMod.EngineBlock, random.Next(-1, newvehicle.GetModCount(VehicleMod.EngineBlock)), true);
      newvehicle.SetMod(VehicleMod.Exhaust, random.Next(-1, newvehicle.GetModCount(VehicleMod.Exhaust)), true);
      newvehicle.SetMod(VehicleMod.Fender, random.Next(-1, newvehicle.GetModCount(VehicleMod.Fender)), true);
      newvehicle.SetMod(VehicleMod.Frame, random.Next(-1, newvehicle.GetModCount(VehicleMod.Frame)), true);
      newvehicle.SetMod(VehicleMod.FrontBumper, random.Next(-1, newvehicle.GetModCount(VehicleMod.FrontBumper)), true);
      newvehicle.SetMod(VehicleMod.FrontWheels, random.Next(-1, newvehicle.GetModCount(VehicleMod.FrontWheels)), true);
      newvehicle.SetMod(VehicleMod.Grille, random.Next(-1, newvehicle.GetModCount(VehicleMod.Grille)), true);
      newvehicle.SetMod(VehicleMod.Hood, random.Next(-1, newvehicle.GetModCount(VehicleMod.Hood)), true);
      newvehicle.SetMod(VehicleMod.Horns, random.Next(-1, newvehicle.GetModCount(VehicleMod.Horns)), true);
      newvehicle.SetMod(VehicleMod.Hydraulics, random.Next(-1, newvehicle.GetModCount(VehicleMod.Hydraulics)), true);
      newvehicle.SetMod(VehicleMod.Livery, random.Next(-1, newvehicle.GetModCount(VehicleMod.Livery)), false);
      newvehicle.SetMod(VehicleMod.Ornaments, random.Next(-1, newvehicle.GetModCount(VehicleMod.Ornaments)), true);
      newvehicle.SetMod(VehicleMod.Plaques, random.Next(-1, newvehicle.GetModCount(VehicleMod.Plaques)), true);
      newvehicle.SetMod(VehicleMod.PlateHolder, random.Next(-1, newvehicle.GetModCount(VehicleMod.PlateHolder)), true);
      newvehicle.SetMod(VehicleMod.RearBumper, random.Next(-1, newvehicle.GetModCount(VehicleMod.RearBumper)), true);
      newvehicle.SetMod(VehicleMod.RightFender, random.Next(-1, newvehicle.GetModCount(VehicleMod.RightFender)), true);
      newvehicle.SetMod(VehicleMod.Seats, random.Next(-1, newvehicle.GetModCount(VehicleMod.Seats)), true);
      newvehicle.SetMod(VehicleMod.SideSkirt, random.Next(-1, newvehicle.GetModCount(VehicleMod.SideSkirt)), true);
      newvehicle.SetMod(VehicleMod.Speakers, random.Next(-1, newvehicle.GetModCount(VehicleMod.Speakers)), true);
      newvehicle.SetMod(VehicleMod.Spoilers, random.Next(-1, newvehicle.GetModCount(VehicleMod.Spoilers)), true);
      newvehicle.SetMod(VehicleMod.SteeringWheels, random.Next(-1, newvehicle.GetModCount(VehicleMod.SteeringWheels)), true);
      newvehicle.SetMod(VehicleMod.Struts, random.Next(-1, newvehicle.GetModCount(VehicleMod.Struts)), true);
      newvehicle.SetMod(VehicleMod.Suspension, random.Next(-1, newvehicle.GetModCount(VehicleMod.Suspension)), true);
      newvehicle.SetMod(VehicleMod.Tank, random.Next(-1, newvehicle.GetModCount(VehicleMod.Tank)), true);
      newvehicle.SetMod(VehicleMod.Transmission, random.Next(-1, newvehicle.GetModCount(VehicleMod.Transmission)), true);
      newvehicle.SetMod(VehicleMod.Trim, random.Next(-1, newvehicle.GetModCount(VehicleMod.Trim)), true);
      newvehicle.SetMod(VehicleMod.TrimDesign, random.Next(-1, newvehicle.GetModCount(VehicleMod.TrimDesign)), true);
      newvehicle.SetMod(VehicleMod.Trunk, random.Next(-1, newvehicle.GetModCount(VehicleMod.Trunk)), true);
      newvehicle.SetMod(VehicleMod.VanityPlates, random.Next(-1, newvehicle.GetModCount(VehicleMod.VanityPlates)), true);
      newvehicle.SetMod(VehicleMod.Windows, random.Next(-1, newvehicle.GetModCount(VehicleMod.Windows)), true);
    }

    private void onKeyDown(object sender, KeyEventArgs e)
    {
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public void SaveName(string Name)
    {
      this.VehicleName = Name;
      this.Config.SetValue<string>("Configurations", "VehicleName", this.VehicleName);
      this.Config.Save();
    }

    public void OnTick(object sender, EventArgs e)
    {
    }

    public Model CheckCar2(string iniName)
    {
      Script.Wait(1);
      this.LoadIniFile(iniName);
      this.VehicleNameHash = this.Config.GetValue<GTA.Native.VehicleHash>("Configurations", "VehicleNameHash", this.VehicleNameHash);
      this.VehicleName = this.Config.GetValue<string>("Configurations", "VehicleName", this.VehicleName);
      if (this.VehicleName == "CARBON")
        this.VehicleName = "CARBONRS";
      if (this.VehicleName == "UTILTRUC")
        this.VehicleName = "UTILLITRUCK";
      if (this.VehicleName == "FORK")
        this.VehicleName = "FORKLIFT";
      if (this.VehicleName == "LANDSTAL")
        this.VehicleName = "LANDSTALKER";
      if (this.VehicleName == "CAVCADE")
        this.VehicleName = "CAVALCADE";
      if (this.VehicleName == "SANCHEZ02")
        this.VehicleName = "SANCHEZ2";
      if (this.VehicleName == "SANCHEZ01")
        this.VehicleName = "SANCHEZ";
      if (this.VehicleName == "FAGGION")
        this.VehicleName = "FAGGIO";
      if (this.VehicleName == "STINGERG")
        this.VehicleName = "FELTZER3";
      if (this.VehicleName == "SCHWARZE")
        this.VehicleName = "SCHWARZER";
      if (this.VehicleName == "SCHWARZE")
        this.VehicleName = "SCHWARZER";
      if (this.VehicleName == "KHAMEL")
        this.VehicleName = "KHAMELION";
      if (this.VehicleName == "FURORE")
        this.VehicleName = "FUROREGT";
      if (this.VehicleName == "COGCABRI")
        this.VehicleName = "COGCABRIO";
      if (this.VehicleName == "RLOADER")
        this.VehicleName = "RATLOADER";
      if (this.VehicleName == "RLOADER2")
        this.VehicleName = "RATLOADER2";
      if (this.VehicleName == "FELTZER")
        this.VehicleName = "FELTZER2";
      if (this.VehicleName == "WASHINGT")
        this.VehicleName = "WASHINGTON";
      if (this.VehicleName == "BUFFALO02")
        this.VehicleName = "BUFFALO2";
      if (this.VehicleName == "TAILGATE")
        this.VehicleName = "TAILGATER";
      if (this.VehicleName == "SCHAFTER")
        this.VehicleName = "SCHAFTER2";
      if (this.VehicleName == "SCHAFTER")
        this.VehicleName = "SCHAFTER2";
      if (this.VehicleName == "COGNOSC2")
        this.VehicleName = "COGNOSCENTI2";
      if (this.VehicleName == "COGNOSC2")
        this.VehicleName = "COGNOSCENTI2";
      if (this.VehicleName == "COGNOSC")
        this.VehicleName = "COGNOSCENTI";
      if (this.VehicleName == "COGNOSC")
        this.VehicleName = "COGNOSCENTI";
      if (this.VehicleName == "ASTROPE")
        this.VehicleName = "ASTEROPE";
      if (this.VehicleName == "SANDKIN2")
        this.VehicleName = "SANDKING2";
      if (this.VehicleName == "REBEL02")
        this.VehicleName = "REBEL2";
      if (this.VehicleName == "REBEL01")
        this.VehicleName = "REBEL";
      if (this.VehicleName == "RANCHERX")
        this.VehicleName = "RANCHERXL";
      if (this.VehicleName == "BFINJECT")
        this.VehicleName = "BFINJECTION";
      if (this.VehicleName == "DOMINATO2")
        this.VehicleName = "DOMINATOR2";
      if (this.VehicleName == "DILETTAN")
        this.VehicleName = "DILETTANTE";
      if (this.VehicleName == "VOODOO2")
        this.VehicleName = "VOODOO";
      else if (this.VehicleName == "VOODOO")
        this.VehicleName = "VOODOO2";
      if (this.VehicleName == "ABMULAN")
        this.VehicleName = "AMBULANCE";
      if (this.VehicleName == "Ruiner3")
        this.VehicleName = "Ruiner3";
      if (this.VehicleName == "BUCCANEE2")
        this.VehicleName = "BUCCANEER2";
      if (this.VehicleName == "BUCCANEE")
        this.VehicleName = "BUCCANEER";
      if (this.VehicleName == "CARBONIZ")
        this.VehicleName = "CARBONIZZARE";
      if (this.VehicleName == "penetrator")
        this.VehicleName = "PENETRATOR";
      if (this.VehicleName == "TROPHY")
        this.VehicleName = "TROPHYTRUCK";
      if (this.VehicleName == "TROPHY2")
        this.VehicleName = "TROPHYTRUCK2";
      if (this.VehicleName == "ROOSEVELT")
        this.VehicleName = "Btype";
      if (this.VehicleName == "VERLIER")
        this.VehicleName = "VERLIERER2";
      if (this.VehicleName == "BTYPE2")
        this.VehicleName = "Btype2";
      if (this.VehicleName == "ROOSEVELT2")
        this.VehicleName = "Btype3";
      if (this.VehicleName == "DOMINATO")
        this.VehicleName = "DOMINATOR";
      if (this.VehicleName == "NITESHAD")
        this.VehicleName = "NIGHTSHADE";
      Model model = new Model();
      if (!File.Exists(iniName))
        return (Model) (string) null;
      if (!this.VehicleName.Equals("null"))
      {
        model = new Model(this.VehicleName);
        model.Request(250);
        if (!model.IsValid && (this.VehicleNameHash != (GTA.Native.VehicleHash) 4294967295 || this.VehicleNameHash > (GTA.Native.VehicleHash) 0))
        {
          model = new Model(this.VehicleNameHash);
          model.Request(250);
          if (!model.IsValid && !this.VehicleName.Equals("null"))
          {
            UI.Notify("~r~ Error~w~ A Invalid Vehicle Name has been Detected in ~b~" + iniName);
            return (Model) (string) null;
          }
          if (!model.IsInCdImage || !model.IsValid)
            return (Model) (string) null;
          while (!model.IsLoaded)
            Script.Wait(50);
          return model;
        }
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(50);
          return model;
        }
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public void LoadVehicleInCargoBay(Vehicle newvehicle)
    {
      if (newvehicle.Model.IsInCdImage && newvehicle.Model.IsValid || (Entity) newvehicle != (Entity) null)
      {
        this.RoofId = this.Config.GetValue<int>("Configurations", "RoofId", this.RoofId);
        this.AerialsId = this.Config.GetValue<int>("Configurations", "AerialsId", this.AerialsId);
        this.AirfilterId = this.Config.GetValue<int>("Configurations", "AirfilterId", this.AirfilterId);
        this.ArchCoverId = this.Config.GetValue<int>("Configurations", "ArchCoverId", this.ArchCoverId);
        this.ArmorId = this.Config.GetValue<int>("Configurations", "ArmorId", this.ArmorId);
        this.BackWheelsId = this.Config.GetValue<int>("Configurations", "BackWheelsId", this.BackWheelsId);
        this.BrakesId = this.Config.GetValue<int>("Configurations", "BrakesId", this.BrakesId);
        this.ColumnShifterLeversId = this.Config.GetValue<int>("Configurations", "ColumnShifterLeversId", this.ColumnShifterLeversId);
        this.DashboardId = this.Config.GetValue<int>("Configurations", "DashboardId", this.DashboardId);
        this.DialDesignId = this.Config.GetValue<int>("Configurations", "DialDesignId", this.DialDesignId);
        this.DoorSpeekersId = this.Config.GetValue<int>("Configurations", "DoorSpeekersId", this.DoorSpeekersId);
        this.EngineId = this.Config.GetValue<int>("Configurations", "EngineId", this.EngineId);
        this.EngineBlockId = this.Config.GetValue<int>("Configurations", "EngineBlockId", this.EngineBlockId);
        this.ExaustId = this.Config.GetValue<int>("Configurations", "ExaustId", this.ExaustId);
        this.FenderId = this.Config.GetValue<int>("Configurations", "FenderId", this.FenderId);
        this.FrameId = this.Config.GetValue<int>("Configurations", "FrameId", this.FrameId);
        this.FrontBumperId = this.Config.GetValue<int>("Configurations", "FrontBumperId", this.FrontBumperId);
        this.FrontWheelsId = this.Config.GetValue<int>("Configurations", "FrontWheelsId", this.FrontWheelsId);
        this.GrilleId = this.Config.GetValue<int>("Configurations", "GrilleId", this.GrilleId);
        this.HoodId = this.Config.GetValue<int>("Configurations", "HoodId", this.HoodId);
        this.HornsId = this.Config.GetValue<int>("Configurations", "HornsId", this.HornsId);
        this.HydralicsId = this.Config.GetValue<int>("Configurations", "HydralicsId", this.HydralicsId);
        this.LiveryId = this.Config.GetValue<int>("Configurations", "LiveryId", this.LiveryId);
        this.SecondaryVehicleLivery = this.Config.GetValue<int>("Configurations", "SecondaryVehicleLivery", this.SecondaryVehicleLivery);
        this.OrnamentsId = this.Config.GetValue<int>("Configurations", "OrnamentsId", this.OrnamentsId);
        this.PlaquesId = this.Config.GetValue<int>("Configurations", "PlaquesId", this.PlaquesId);
        this.Plateholder = this.Config.GetValue<int>("Configurations", "Plateholder", this.Plateholder);
        this.RearBumperId = this.Config.GetValue<int>("Configurations", "RearBumperId", this.RearBumperId);
        this.RightFenderId = this.Config.GetValue<int>("Configurations", "RightFenderId", this.RightFenderId);
        this.SeatsId = this.Config.GetValue<int>("Configurations", "SeatsId", this.SeatsId);
        this.SideSkirt = this.Config.GetValue<int>("Configurations", "SideSkirt", this.SideSkirt);
        this.speakers = this.Config.GetValue<int>("Configurations", "speakers", this.speakers);
        this.SpoilersId = this.Config.GetValue<int>("Configurations", "SpoilersId", this.SpoilersId);
        this.SteeringWheelId = this.Config.GetValue<int>("Configurations", "SteeringWheelId", this.SteeringWheelId);
        this.StrutId = this.Config.GetValue<int>("Configurations", "StrutId", this.StrutId);
        this.SuspensionId = this.Config.GetValue<int>("Configurations", "SuspensionId", this.SuspensionId);
        this.TankId = this.Config.GetValue<int>("Configurations", "TankId", this.TankId);
        this.TransmissionId = this.Config.GetValue<int>("Configurations", "TransmissionId", this.TransmissionId);
        this.TrimId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
        this.TrimDesignId = this.Config.GetValue<int>("Configurations", "TrimDesignId", this.TrimDesignId);
        this.TrunkId = this.Config.GetValue<int>("Configurations", "TrunkId", this.TrunkId);
        this.VanityPlatesId = this.Config.GetValue<int>("Configurations", "VanityPlatesId", this.VanityPlatesId);
        this.WindowId = this.Config.GetValue<int>("Configurations", "WindowId", this.WindowId);
        this.PrimaryColor = this.Config.GetValue<VehicleColor>("Configurations", "PrimaryColor", this.PrimaryColor);
        this.SecondaryColor = this.Config.GetValue<VehicleColor>("Configurations", "SecondaryColor", this.SecondaryColor);
        this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
        this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
        this.PearlCent = this.Config.GetValue<VehicleColor>("Configurations", "PearlCent", this.PearlCent);
        this.NeonColour = this.Config.GetValue<Color>("Configurations", "NeonColour", this.NeonColour);
        this.TintId = this.Config.GetValue<VehicleWindowTint>("Configurations", "TintId", this.TintId);
        this.PlanteNo = this.Config.GetValue<string>("Configurations", "PlanteNo", this.PlanteNo);
        this.Blades = this.Config.GetValue<int>("Configurations", "Blades", this.Blades);
        this.HasXenonLights = this.Config.GetValue<bool>("Configurations", "HasXenonLights", this.HasXenonLights);
        this.TurboActive = this.Config.GetValue<bool>("Configurations", "TurboActive", this.TurboActive);
        this.LightColor = this.Config.GetValue<int>("Configurations", "LightColor", this.LightColor);
        this.NeonColor = this.Config.GetValue<Color>("Configurations", "NeonColor", this.NeonColor);
        this.RightNeonOn = this.Config.GetValue<bool>("Configurations", "RightNeonOn", this.RightNeonOn);
        this.LeftNeonOn = this.Config.GetValue<bool>("Configurations", "LeftNeonOn", this.LeftNeonOn);
        this.FrontNeonOn = this.Config.GetValue<bool>("Configurations", "FrontNeonOn", this.FrontNeonOn);
        this.BackNeonOn = this.Config.GetValue<bool>("Configurations", "BackNeonOn", this.BackNeonOn);
        this.TrimColor = this.Config.GetValue<VehicleColor>("Configurations", "TrimColor", this.TrimColor);
        this.BulletProofTires = this.Config.GetValue<bool>("Configurations", "BulletProofTires", this.BulletProofTires);
        this.WheelType = this.Config.GetValue<int>("Configurations", "WheelType", this.WheelType);
        this.CustomTiresOn = this.Config.GetValue<bool>("Configurations", "CustomTiresOn", this.CustomTiresOn);
        try
        {
          this.Torque = this.Config.GetValue<float>("Configurations", "Torque", this.Torque);
          this.Power = this.Config.GetValue<float>("Configurations", "Power", this.Power);
        }
        catch
        {
          this.Torque = 1f;
          this.Config.SetValue<float>("Configurations", "Torque", this.Torque);
          this.Power = 1f;
          this.Config.SetValue<float>("Configurations", "Power", this.Power);
          this.Config.Save();
        }
        this.Wheelcolour = this.Config.GetValue<VehicleColor>("Configurations", "Wheelcolour", this.Wheelcolour);
        this.DashBoardColour = this.Config.GetValue<VehicleColor>("Configurations", "DashBoardColour", this.DashBoardColour);
        this.TireSmokeColor = this.Config.GetValue<Color>("Configurations", "TireSmokeColor", this.TireSmokeColor);
        this.TireSmoke = this.Config.GetValue<bool>("Configurations", "TireSmoke", this.TireSmoke);
        this.HasClanTag = this.Config.GetValue<bool>("Configurations", "CLanTagOn", this.HasClanTag);
        this.ExtraOn.Clear();
        for (int index = 0; index < 21; ++index)
        {
          if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), true))
            this.ExtraOn.Add(true);
          else
            this.ExtraOn.Add(false);
        }
        Function.Call(Hash._0x1F2AA07F00B3217A, (InputArgument) newvehicle.Handle, (InputArgument) 0);
        Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) newvehicle, (InputArgument) this.WheelType);
        newvehicle.SetMod(VehicleMod.Livery, this.LiveryId, false);
        Function.Call(Hash._0x60BF608F1B8CD1B6, (InputArgument) newvehicle, (InputArgument) this.SecondaryVehicleLivery);
        newvehicle.SetMod(VehicleMod.Roof, this.RoofId, true);
        newvehicle.SetMod(VehicleMod.Aerials, this.AerialsId, true);
        newvehicle.SetMod(VehicleMod.AirFilter, this.AirfilterId, true);
        newvehicle.SetMod(VehicleMod.ArchCover, this.ArchCoverId, true);
        newvehicle.SetMod(VehicleMod.Armor, this.ArmorId, true);
        newvehicle.SetMod(VehicleMod.BackWheels, this.BackWheelsId, true);
        newvehicle.SetMod(VehicleMod.Brakes, this.BrakesId, true);
        newvehicle.SetMod(VehicleMod.ColumnShifterLevers, this.ColumnShifterLeversId, true);
        newvehicle.SetMod(VehicleMod.Dashboard, this.DashboardId, true);
        newvehicle.SetMod(VehicleMod.DialDesign, this.DialDesignId, true);
        newvehicle.SetMod(VehicleMod.DoorSpeakers, this.DoorSpeekersId, true);
        newvehicle.SetMod(VehicleMod.Engine, this.EngineId, true);
        newvehicle.SetMod(VehicleMod.EngineBlock, this.EngineBlockId, true);
        newvehicle.SetMod(VehicleMod.Exhaust, this.ExaustId, true);
        newvehicle.SetMod(VehicleMod.Fender, this.FenderId, true);
        newvehicle.SetMod(VehicleMod.Frame, this.FrameId, true);
        newvehicle.SetMod(VehicleMod.FrontBumper, this.FrontBumperId, true);
        newvehicle.SetMod(VehicleMod.FrontWheels, this.FrontWheelsId, true);
        newvehicle.SetMod(VehicleMod.Grille, this.GrilleId, true);
        newvehicle.SetMod(VehicleMod.Hood, this.HoodId, true);
        newvehicle.SetMod(VehicleMod.Horns, this.HornsId, true);
        newvehicle.SetMod(VehicleMod.Hydraulics, this.HydralicsId, true);
        newvehicle.SetMod(VehicleMod.Livery, this.LiveryId, false);
        Function.Call(Hash._0x60BF608F1B8CD1B6, (InputArgument) newvehicle, (InputArgument) this.SecondaryVehicleLivery);
        newvehicle.SetMod(VehicleMod.Ornaments, this.OrnamentsId, true);
        newvehicle.SetMod(VehicleMod.Plaques, this.PlaquesId, true);
        newvehicle.SetMod(VehicleMod.PlateHolder, this.Plateholder, true);
        newvehicle.SetMod(VehicleMod.RearBumper, this.RearBumperId, true);
        newvehicle.SetMod(VehicleMod.RightFender, this.RightFenderId, true);
        newvehicle.SetMod(VehicleMod.Seats, this.SeatsId, true);
        newvehicle.SetMod(VehicleMod.SideSkirt, this.SideSkirt, true);
        newvehicle.SetMod(VehicleMod.Speakers, this.speakers, true);
        newvehicle.SetMod(VehicleMod.Spoilers, this.SpoilersId, true);
        newvehicle.SetMod(VehicleMod.SteeringWheels, this.SteeringWheelId, true);
        newvehicle.SetMod(VehicleMod.Struts, this.StrutId, true);
        newvehicle.SetMod(VehicleMod.Suspension, this.SuspensionId, true);
        newvehicle.SetMod(VehicleMod.Tank, this.TankId, true);
        newvehicle.SetMod(VehicleMod.Transmission, this.TransmissionId, true);
        newvehicle.SetMod(VehicleMod.Trim, this.TrimId, true);
        newvehicle.SetMod(VehicleMod.TrimDesign, this.TrimDesignId, true);
        newvehicle.SetMod(VehicleMod.Trunk, this.TrunkId, true);
        newvehicle.SetMod(VehicleMod.VanityPlates, this.VanityPlatesId, true);
        newvehicle.SetMod(VehicleMod.Windows, this.WindowId, true);
        newvehicle.SetMod(VehicleMod.Trim, this.Blades, true);
        newvehicle.ToggleMod(VehicleToggleMod.XenonHeadlights, this.HasXenonLights);
        newvehicle.ToggleMod(VehicleToggleMod.Turbo, this.TurboActive);
        Function.Call((Hash) 16433691881432431111, (InputArgument) newvehicle, (InputArgument) this.LightColor);
        Function.Call(Hash._0x487EB21CC7295BA1, (InputArgument) newvehicle, (InputArgument) this.WheelType);
        Function.Call(Hash._0x6AF0636DDEDCB6DD, (InputArgument) newvehicle, (InputArgument) 23, (InputArgument) newvehicle.GetMod(VehicleMod.FrontWheels), (InputArgument) this.CustomTiresOn);
        newvehicle.EngineTorqueMultiplier = this.Torque;
        newvehicle.EnginePowerMultiplier = this.Power;
        try
        {
          if (this.HasClanTag)
          {
            this.VE.CheckforEmblem(newvehicle);
            this.VE.CreateVehEmblem(newvehicle, Game.Player.Character);
          }
        }
        catch (Exception ex)
        {
        }
        if (this.RightNeonOn)
        {
          newvehicle.NeonLightsColor = this.NeonColor;
          newvehicle.SetNeonLightsOn(VehicleNeonLight.Right, true);
        }
        if (this.LeftNeonOn)
        {
          newvehicle.NeonLightsColor = this.NeonColor;
          newvehicle.SetNeonLightsOn(VehicleNeonLight.Left, true);
        }
        if (this.BackNeonOn)
        {
          newvehicle.NeonLightsColor = this.NeonColor;
          newvehicle.SetNeonLightsOn(VehicleNeonLight.Back, true);
        }
        if (this.FrontNeonOn)
        {
          newvehicle.NeonLightsColor = this.NeonColor;
          newvehicle.SetNeonLightsOn(VehicleNeonLight.Front, true);
        }
        newvehicle.WindowTint = this.TintId;
        newvehicle.PrimaryColor = this.PrimaryColor;
        newvehicle.SecondaryColor = this.SecondaryColor;
        newvehicle.RimColor = this.Wheelcolour;
        newvehicle.DashboardColor = this.DashBoardColour;
        newvehicle.PearlescentColor = this.PearlCent;
        newvehicle.NeonLightsColor = this.NeonColour;
        newvehicle.NumberPlate = this.PlanteNo;
        newvehicle.IsDriveable = false;
        this.SavedVehicle = newvehicle;
        newvehicle.ToggleMod(VehicleToggleMod.TireSmoke, this.TireSmoke);
        newvehicle.RimColor = this.Wheelcolour;
        newvehicle.DashboardColor = this.DashBoardColour;
        newvehicle.TireSmokeColor = this.TireSmokeColor;
        newvehicle.TrimColor = this.TrimColor;
        newvehicle.CanTiresBurst = this.BulletProofTires;
        for (int index = 0; index < 21; ++index)
        {
          if (this.Config.GetValue<bool>("ToggleableExtras", "Extras" + index.ToString(), this.ExtraOn[index]))
            newvehicle.ToggleExtra(index, this.ExtraOn[index]);
        }
        this.VehicleHash = Function.Call<int>(Hash._0xD24D37CC275948CC, (InputArgument) newvehicle.DisplayName).ToString();
        this.Config.SetValue<string>("Configurations", "VehicleHash", this.VehicleHash);
        this.Config.Save();
      }
      else
        UI.Notify("~r~Error~w~: " + newvehicle?.ToString() + " is not a Base Game vehicle or has issues with saving, contack HKH191 for more info or help!");
    }
  }
}
