
using GTA;
using GTA.Native;
using System;
using System.Windows.Forms;

namespace DoomsdayBusiness
{
  internal class AkulaStealthFunction : Script
  {
    private ScriptSettings Config;
    public bool AkulaStealthFieldEnabled;
    public bool StealthFieldOn;
    public string Akula = "AKULA";

    public AkulaStealthFunction()
    {
      this.Tick += new EventHandler(this.OnTick);
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.Interval = 1;
      this.LoadIniFile("scripts//HKH191sBusinessMods//DoomsdayBusiness//Main.ini");
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.AkulaStealthFieldEnabled = this.Config.GetValue<bool>("Misc", "AkulaStealthFieldEnabled", this.AkulaStealthFieldEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void ChargeCloak()
    {
      Script.Wait(1200);
      Game.Player.Character.IsVisible = false;
      Game.Player.Character.CanBeTargetted = false;
      if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger) != (Entity) null)
        Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger).IsVisible = false;
      if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.LeftRear) != (Entity) null)
        Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.LeftRear).IsVisible = false;
      if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.RightRear) != (Entity) null)
        Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.RightRear).IsVisible = false;
      Game.Player.Character.CurrentVehicle.Alpha = 220;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 200;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 140;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 120;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 100;
      Script.Wait(100);
      Game.Player.Character.CurrentVehicle.Alpha = 100;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 80;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 60;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 50;
      if (Game.Player.WantedLevel <= 5 && (uint) Game.Player.WantedLevel > 0U && new Random().Next(1, 100) <= 20)
        --Game.Player.WantedLevel;
      this.StealthFieldOn = true;
    }

    private void DeChargeCloak()
    {
      Script.Wait(1200);
      Game.Player.Character.CurrentVehicle.Alpha = 10;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 20;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 30;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 40;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 60;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = 80;
      Script.Wait(50);
      Game.Player.Character.CurrentVehicle.Alpha = (int) byte.MaxValue;
      if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger) != (Entity) null)
        Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger).IsVisible = true;
      if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.LeftRear) != (Entity) null)
        Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.LeftRear).IsVisible = true;
      if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.RightRear) != (Entity) null)
        Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.RightRear).IsVisible = true;
      Game.Player.Character.IsVisible = true;
      Game.Player.Character.CanBeTargetted = true;
      Function.Call(Hash._0x8EEDA153AD141BA4, (InputArgument) false);
      Function.Call(Hash._0x4E9021C1FCDD507A, (InputArgument) 1);
      Function.Call(Hash._0x32C62AA929C2DA6A, (InputArgument) false);
      Function.Call(Hash._0x12B37D54667DB0B8, (InputArgument) false);
      this.StealthFieldOn = false;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (!this.AkulaStealthFieldEnabled || !((Entity) Game.Player.Character.CurrentVehicle != (Entity) null) || !(Game.Player.Character.CurrentVehicle.DisplayName == this.Akula))
        return;
      if (e.KeyCode == Keys.F && this.StealthFieldOn)
      {
        Script.Wait(1200);
        Game.Player.Character.CurrentVehicle.Alpha = 10;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 20;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 30;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 40;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 60;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 80;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = (int) byte.MaxValue;
        if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger) != (Entity) null)
          Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger).IsVisible = true;
        if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.LeftRear) != (Entity) null)
          Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.LeftRear).IsVisible = true;
        if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.RightRear) != (Entity) null)
          Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.RightRear).IsVisible = true;
        Function.Call(Hash._0x8EEDA153AD141BA4, (InputArgument) true);
        Function.Call(Hash._0x4E9021C1FCDD507A, (InputArgument) 1000);
        Function.Call(Hash._0x32C62AA929C2DA6A, (InputArgument) true);
        Function.Call(Hash._0x12B37D54667DB0B8, (InputArgument) true);
        Game.Player.Character.IsVisible = true;
        this.StealthFieldOn = false;
      }
      if (e.KeyCode == Keys.U)
      {
        if (this.StealthFieldOn)
        {
          UI.Notify("Cloak Decharging!");
          this.DeChargeCloak();
        }
        else if (!this.StealthFieldOn)
        {
          UI.Notify("Cloak Charging!");
          this.ChargeCloak();
        }
      }
    }

    private void OnTick(object sender, EventArgs e)
    {
      if (!this.AkulaStealthFieldEnabled || !((Entity) Game.Player.Character.CurrentVehicle != (Entity) null) || (Game.Player.Character.CurrentVehicle.IsAlive || !(Game.Player.Character.CurrentVehicle.DisplayName == this.Akula)))
        return;
      if (this.StealthFieldOn)
      {
        Function.Call(Hash._0x8EEDA153AD141BA4, (InputArgument) true);
        Function.Call(Hash._0x4E9021C1FCDD507A, (InputArgument) 1000);
        Function.Call(Hash._0x32C62AA929C2DA6A, (InputArgument) true);
        Function.Call(Hash._0x12B37D54667DB0B8, (InputArgument) true);
      }
      else if (!this.StealthFieldOn)
      {
        Function.Call(Hash._0x8EEDA153AD141BA4, (InputArgument) false);
        Function.Call(Hash._0x4E9021C1FCDD507A, (InputArgument) 1);
        Function.Call(Hash._0x32C62AA929C2DA6A, (InputArgument) false);
        Function.Call(Hash._0x12B37D54667DB0B8, (InputArgument) false);
      }
      if (this.StealthFieldOn)
      {
        Script.Wait(1200);
        Game.Player.Character.CurrentVehicle.Alpha = 10;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 20;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 30;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 40;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 60;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = 80;
        Script.Wait(50);
        Game.Player.Character.CurrentVehicle.Alpha = (int) byte.MaxValue;
        Function.Call(Hash._0x8EEDA153AD141BA4, (InputArgument) false);
        if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger) != (Entity) null)
          Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Passenger).IsVisible = true;
        if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.LeftRear) != (Entity) null)
          Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.LeftRear).IsVisible = true;
        if ((Entity) Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.RightRear) != (Entity) null)
          Game.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.RightRear).IsVisible = true;
        this.StealthFieldOn = false;
      }
    }
  }
}
