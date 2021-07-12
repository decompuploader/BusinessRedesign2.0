using GTA;
using GTA.Math;
using System;
using System.Drawing;

namespace MethBuisness
{
  internal class Icon : Script
  {
    public BlipColor Safehouse_Colour;
    public BlipColor Blip_Colour;
    public Color MarkerColor;
    public string MarkerColorString;
    public Color SafehouseMColor;
    public string SafehouseMColorString;
    private ScriptSettings MainConfigFile;
    public Vector3 BuyMarker1 = new Vector3(1313.79f, 4367.51f, 41.16f);
    public Blip BusinessMarker1;
    public Vector3 BuyMarker2 = new Vector3(1054f, -2473.07f, 27f);
    public Blip BusinessMarker2;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    private ScriptSettings ScriptConfig2;
    public bool IsScriptEnabled2;

    private void LoadMain(string iniName)
    {
      try
      {
        this.MainConfigFile = ScriptSettings.Load(iniName);
        this.Safehouse_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "Safehouse_Colour", this.Safehouse_Colour);
        this.Blip_Colour = this.MainConfigFile.GetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        this.MarkerColorString = this.MainConfigFile.GetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        this.MarkerColor = Color.FromName(this.MarkerColorString);
        this.SafehouseMColorString = this.MainConfigFile.GetValue<string>("Misc", "SafehouseMColor", this.SafehouseMColorString);
        this.SafehouseMColor = Color.FromName(this.SafehouseMColorString);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    private void CheckForScriptEnabled(string iniName)
    {
      try
      {
        this.ScriptConfig = ScriptSettings.Load(iniName);
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("Biker Business", "GrapeseedHub", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void CheckForScriptEnabled2(string iniName)
    {
      try
      {
        this.ScriptConfig2 = ScriptSettings.Load(iniName);
        this.IsScriptEnabled2 = this.ScriptConfig2.GetValue<bool>("Biker Business", "CypressFlatsHub", this.IsScriptEnabled2);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public Icon()
    {
      this.LoadMain("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      this.Aborted += new EventHandler(this.OnShutdown);
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (this.IsScriptEnabled)
        this.SetupMarker1();
      this.CheckForScriptEnabled2("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled2)
        return;
      this.SetupMarker2();
    }

    private void SetupMarker1()
    {
      this.BusinessMarker1 = World.CreateBlip(this.BuyMarker1);
      this.BusinessMarker1.Sprite = BlipSprite.Marijuana;
      this.BusinessMarker1.Name = "Biker's Business North";
      this.BusinessMarker1.IsShortRange = true;
      this.BusinessMarker1.Color = this.Blip_Colour;
    }

    private void SetupMarker2()
    {
      this.BusinessMarker2 = World.CreateBlip(this.BuyMarker2);
      this.BusinessMarker2.Sprite = BlipSprite.Marijuana;
      this.BusinessMarker2.Name = "Biker's Business South";
      this.BusinessMarker2.IsShortRange = true;
      this.BusinessMarker2.Color = this.Blip_Colour;
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if (this.BusinessMarker1 != (Blip) null)
        this.BusinessMarker1.Remove();
      if (this.BusinessMarker2 != (Blip) null)
        this.BusinessMarker2.Remove();
    }
  }
}
