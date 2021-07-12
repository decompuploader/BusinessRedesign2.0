using GTA;
using GTA.Math;
using GTA.Native;
using System;

namespace AfterHoursBusiness
{
  public class Garages : Script
  {
    public int PounderCustomUnlocked;
    public int MuleCustomUnlocked;
    public int SpeedoCustomUnlocked;
    public SaveCar SaveLoad;
    public Vector3 Vehicle1Loc = new Vector3(-86.7646f, -822.949f, 221f);
    public Vehicle Vehicle1;
    public Vector3 Vehicle2Loc = new Vector3(-83.3558f, -818.657f, 221f);
    public Vehicle Vehicle2;
    public Vector3 Vehicle3Loc = new Vector3(-79.7936f, -817.925f, 221f);
    public Vehicle Vehicle3;
    public Vector3 Vehicle4Loc = new Vector3(-74.5332f, -819.925f, 221f);
    public Vehicle Vehicle4;
    public Vector3 Vehicle5Loc = new Vector3(-70.821f, -823.925f, 221f);
    public Vehicle Vehicle5;
    public Vector3 Vehicle6Loc = new Vector3(-69.0828f, -828.925f, 221f);
    public Vehicle Vehicle6;
    public Vector3 Vehicle7Loc = new Vector3(-69.7485f, -835.925f, 221f);
    public Vehicle Vehicle7;
    public Vector3 Vehicle8Loc = new Vector3(-86.7646f, -822.949f, 228f);
    public Vehicle Vehicle8;
    public Vector3 Vehicle9Loc = new Vector3(-83.3558f, -818.657f, 228f);
    public Vehicle Vehicle9;
    public Vector3 Vehicle10Loc = new Vector3(-79.7936f, -817.925f, 228f);
    public Vehicle Vehicle10;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public bool LoadedIn;

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

    public Model RequestModel(VehicleHash Name)
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

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("After Hours Business", "Main", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public Garages()
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.SaveLoad = new SaveCar();
      this.Aborted += new EventHandler(this.OnShutdown);
      this.setup();
    }

    public void setup() => Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) 347.2686, (InputArgument) -999.2955, (InputArgument) -99.19622);

    public void DeleteCarintSlot(string Path, string Garage, string Slot)
    {
      this.SaveLoad.LoadIniFile(Path + Garage + "// " + Slot + ".ini");
      this.SaveLoad.VehicleName = "null";
      this.SaveLoad.Save();
    }

    public void DeleteVehicles()
    {
      this.LoadedIn = false;
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

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
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
    }

    public void LoadGarage(string Path, string Garage, int Maxvehicles, Vector3 ExitPos)
    {
      this.DeleteVehicles();
      if (Maxvehicles == 3)
      {
        try
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//MuleCustom.ini");
          this.SaveLoad.CheckCar(Path + Garage + "//MuleCustom.ini");
          this.SaveLoad.LoadIniFile(Path + Garage + "//PounderCustom.ini");
          this.SaveLoad.CheckCar(Path + Garage + "//PounderCustom.ini");
          this.SaveLoad.LoadIniFile(Path + Garage + "//SpeedoCustom.ini");
          this.SaveLoad.CheckCar(Path + Garage + "//SpeedoCustom.ini");
          this.Vehicle1Loc = new Vector3(-1499f, -2992f, -83f);
          this.Vehicle2Loc = new Vector3(-1506f, -2996f, -83f);
          this.Vehicle3Loc = new Vector3(-1513f, -2992f, -83f);
          if (this.MuleCustomUnlocked == 1)
          {
            this.SaveLoad.LoadIniFile(Path + Garage + "//MuleCustom.ini");
            this.SaveLoad.CheckCar(Path + Garage + "//MuleCustom.ini");
            this.Vehicle1 = World.CreateVehicle((Model) VehicleHash.Mule4, this.Vehicle1Loc, 177f);
            this.SaveLoad.Load(this.Vehicle1);
            this.Vehicle1.IsDriveable = false;
          }
          if (this.PounderCustomUnlocked == 1)
          {
            this.SaveLoad.LoadIniFile(Path + Garage + "//PounderCustom.ini");
            this.SaveLoad.CheckCar(Path + Garage + "//PounderCustom.ini");
            this.Vehicle2 = World.CreateVehicle((Model) VehicleHash.Pounder2, this.Vehicle2Loc, 177f);
            this.SaveLoad.Load(this.Vehicle2);
            this.Vehicle2.IsDriveable = false;
          }
          if (this.SpeedoCustomUnlocked == 1)
          {
            this.SaveLoad.LoadIniFile(Path + Garage + "//SpeedoCustom.ini");
            this.SaveLoad.CheckCar(Path + Garage + "//SpeedoCustom.ini");
            this.Vehicle3 = World.CreateVehicle((Model) VehicleHash.Speedo4, this.Vehicle3Loc, 177f);
            this.SaveLoad.Load(this.Vehicle3);
            this.Vehicle3.IsDriveable = false;
          }
          this.LoadedIn = true;
        }
        catch (Exception ex)
        {
          this.LoadedIn = false;
          this.DeleteVehicles();
          UI.Notify("~b~AHB/Garages ~w~ : Somthing went wrong please try this again, if its the first time, its normal");
        }
      }
      if (Maxvehicles != 10)
        return;
      try
      {
        this.DeleteVehicles();
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot1.ini");
        Model model1 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot1.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot2.ini");
        Model model2 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot2.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot3.ini");
        Model model3 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot3.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot4.ini");
        Model model4 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot4.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot5.ini");
        Model model5 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot5.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot6.ini");
        Model model6 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot6.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot7.ini");
        Model model7 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot7.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot8.ini");
        Model model8 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot8.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot9.ini");
        Model model9 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot9.ini");
        this.SaveLoad.LoadIniFile(Path + Garage + "\\Slot10.ini");
        Model model10 = this.SaveLoad.CheckCar(Path + Garage + "\\Slot10.ini");
        this.Vehicle1Loc = new Vector3(-1517f, -2988f, -83f);
        this.Vehicle2Loc = new Vector3(-1513f, -2988f, -83f);
        this.Vehicle3Loc = new Vector3(-1508f, -2988f, -83f);
        this.Vehicle4Loc = new Vector3(-1503f, -2988f, -83f);
        this.Vehicle5Loc = new Vector3(-1498f, -2988f, -83f);
        this.Vehicle6Loc = new Vector3(-1517f, -2997f, -83f);
        this.Vehicle7Loc = new Vector3(-1513f, -2997f, -83f);
        this.Vehicle8Loc = new Vector3(-1508f, -2997f, -83f);
        this.Vehicle9Loc = new Vector3(-1503f, -2997f, -83f);
        this.Vehicle10Loc = new Vector3(-1498f, -2997f, -83f);
        if (model1 != (Model) "null" && model1 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot1.ini");
          this.Vehicle1 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot1.ini"), this.Vehicle1Loc, 177f);
          this.SaveLoad.Load(this.Vehicle1);
          this.Vehicle1.IsDriveable = false;
        }
        if (model2 != (Model) "null" && model2 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot2.ini");
          this.Vehicle2 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot2.ini"), this.Vehicle2Loc, 177f);
          this.SaveLoad.Load(this.Vehicle2);
          this.Vehicle2.IsDriveable = false;
        }
        if (model3 != (Model) "null" && model3 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot3.ini");
          this.Vehicle3 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot3.ini"), this.Vehicle3Loc, 177f);
          this.SaveLoad.Load(this.Vehicle3);
          this.Vehicle3.IsDriveable = false;
        }
        if (model4 != (Model) "null" && model4 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot4.ini");
          this.Vehicle4 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot4.ini"), this.Vehicle4Loc, 177f);
          this.SaveLoad.Load(this.Vehicle4);
          this.Vehicle4.IsDriveable = false;
        }
        if (model5 != (Model) "null" && model5 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot5.ini");
          this.Vehicle5 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot5.ini"), this.Vehicle5Loc, 177f);
          this.SaveLoad.Load(this.Vehicle5);
          this.Vehicle5.IsDriveable = false;
        }
        if (model6 != (Model) "null" && model6 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot6.ini");
          this.Vehicle6 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot6.ini"), this.Vehicle6Loc, 177f);
          this.SaveLoad.Load(this.Vehicle6);
          this.Vehicle6.IsDriveable = false;
        }
        if (model7 != (Model) "null" && model7 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot7.ini");
          this.Vehicle7 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot7.ini"), this.Vehicle7Loc, 177f);
          this.SaveLoad.Load(this.Vehicle7);
          this.Vehicle7.IsDriveable = false;
        }
        if (model8 != (Model) "null" && model8 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot8.ini");
          this.Vehicle8 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot8.ini"), this.Vehicle8Loc, 177f);
          this.SaveLoad.Load(this.Vehicle8);
          this.Vehicle8.IsDriveable = false;
        }
        if (model9 != (Model) "null" && model9 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot9.ini");
          this.Vehicle9 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot9.ini"), this.Vehicle9Loc, 177f);
          this.SaveLoad.Load(this.Vehicle9);
          this.Vehicle9.IsDriveable = false;
        }
        if (model10 != (Model) "null" && model10 != (Model) (string) null)
        {
          this.SaveLoad.LoadIniFile(Path + Garage + "//Slot10.ini");
          this.Vehicle10 = World.CreateVehicle(this.SaveLoad.CheckCar(Path + Garage + "//Slot10.ini"), this.Vehicle10Loc, 177f);
          this.SaveLoad.Load(this.Vehicle10);
          this.Vehicle10.IsDriveable = false;
        }
      }
      catch (Exception ex)
      {
        this.DeleteVehicles();
        UI.Notify("~b~AHR/Garages ~w~ : Somthing went wrong please try this again, if its the first time, its normal");
      }
    }
  }
}
