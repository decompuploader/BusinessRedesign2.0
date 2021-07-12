using GTA;
using GTA.Native;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AfterHoursBusiness
{
  public class AllStocks : Script
  {
    private string ModName = "After Hours Business mod";
    private string Developer = "HKH191";
    private string Version = "4.0.0";
    public bool ShowStockIncrease;
    private ScriptSettings Config2;
    private ScriptSettings Config;
    public int waittime;
    public int stockstimer;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public string HostName;
    public BlipColor Blip_Colour;
    public string Uicolour;
    public Color MarkerColor;
    public string MarkerColorString;
    public bool UseGlobalBusinessIncreaseDeceaseMessage;
    public DateTime CurrentDate;
    public DateTime NextDate;
    public int DaysWait = 3;
    public int NextDay;
    public int NextMonth;
    public int NextYear;
    public bool BYPASS_NOSAVE_OR_CRASH = true;
    public int DAYSTORESET_UPDATETIME = 12;
    public int Now;
    private ScriptSettings ScriptConfig;
    public bool IsScriptEnabled;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    private ScriptSettings MainConfigFile;

    private void LoadMain(string iniName)
    {
      try
      {
        this.MainConfigFile = ScriptSettings.Load(iniName);
        this.BusinessUpgradeBasePrice = this.MainConfigFile.GetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
        this.IncreaseStockMinAmount = this.MainConfigFile.GetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
        this.IncreaseStockMaxAmount = this.MainConfigFile.GetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
        this.DecreaseStockMinAmount = this.MainConfigFile.GetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
        this.DecreaseStockMaxAmount = this.MainConfigFile.GetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
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
        this.IsScriptEnabled = this.ScriptConfig.GetValue<bool>("After Hours Business", "Main", this.IsScriptEnabled);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public string GetHostName() => "~" + this.Uicolour + "~ " + this.HostName + "~w~ ";

    public AllStocks()
    {
      this.CheckForScriptEnabled("scripts//DisableBusinesses.ini");
      if (!this.IsScriptEnabled)
        return;
      this.LoadMain("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
      this.LoadIniFile2("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
      this.Tick += new EventHandler(this.OnTick);
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.Now = this.GetDay();
      UI.Notify("~" + this.Uicolour + "~" + this.ModName + "~w~  by ~g~" + this.Developer + "~w~ has Loaded");
    }

    public void CheckStock() => this.IncreaseGain("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");

    public void IncreaseGain(string iniName)
    {
      Random random = new Random();
      this.LoadIniFile(iniName);
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.stocksvalue += (float) (int) ((float) (random.Next((int) this.DecreaseStockMinAmount, (int) this.DecreaseStockMaxAmount) * this.purchaselvl) / 1.45f);
      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.Config.Save();
    }

    public void DecreaseGain(string iniName)
    {
      Random random = new Random();
      this.LoadIniFile(iniName);
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.stocksvalue -= (float) (int) ((float) (random.Next((int) this.DecreaseStockMinAmount, (int) this.DecreaseStockMaxAmount) * this.purchaselvl) / 1.45f);
      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.Config.Save();
    }

    public void SetDate()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
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
      this.Config.SetValue<int>("Setup", "NextYear", this.NextYear);
      this.Config.SetValue<int>("Setup", "NextDay", this.NextDay);
      this.Config.SetValue<int>("Setup", "NextMonth", this.NextMonth);
      this.Config.Save();
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
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
        this.Config.SetValue<int>("Setup", "NextYear", this.NextYear);
        this.Config.SetValue<int>("Setup", "NextDay", this.NextDay);
        this.Config.SetValue<int>("Setup", "NextMonth", this.NextMonth);
        this.Config.Save();
      }
    }

    public int GetHour() => Function.Call<int>(Hash._0x25223CA6B4D20B7F);

    public int GetMinutes() => Function.Call<int>(Hash._0x13D2B8ADD79640F2);

    public int GetDay() => Function.Call<int>(Hash._0x3D10BC92A4DB1D35);

    public int GetMonth() => Function.Call<int>(Hash._0xBBC72712E80257A1);

    public int GetYear() => Function.Call<int>(Hash._0x961777E64BDAF717);

    private void OnTick(object sender, EventArgs e)
    {
      this.GetDateRelative();
      if (this.GetDay() == this.NextDay && this.GetMonth() == this.NextMonth)
      {
        this.SetDate();
        this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
        if (this.Config2.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl) >= 1)
        {
          int num = new Random().Next(1, 1000);
          if (num < 500)
          {
            this.DecreaseGain("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
            if (this.ShowStockIncrease)
            {
              this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
              if (!this.UseGlobalBusinessIncreaseDeceaseMessage)
                AllStocks.TextNotification("CHAR_LESTER", "~" + this.Uicolour + "~" + this.GetHostName(), "After Hours Business", "The Value of Stock has just Increased for our Nightclub");
              if (this.UseGlobalBusinessIncreaseDeceaseMessage)
                AllStocks.TextNotification("CHAR_LESTER", "~g~ Unknown", "All ~g~ HKH191's~w~ Business Mods", "The Value of Stock has just Increased/Decreased for our all Business");
            }
          }
          else if (num >= 500)
          {
            this.IncreaseGain("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
            if (this.ShowStockIncrease)
            {
              this.LoadIniFile("scripts//HKH191sBusinessMods//AfterHoursBusiness//NightClub1//Main.ini");
              if (!this.UseGlobalBusinessIncreaseDeceaseMessage)
                AllStocks.TextNotification("CHAR_LESTER", "~" + this.Uicolour + "~" + this.GetHostName(), "After Hours Business", "The Value of Stock has just Decreased for our Nightclub");
              if (this.UseGlobalBusinessIncreaseDeceaseMessage)
                AllStocks.TextNotification("CHAR_LESTER", "~g~ Unknown", "All ~g~ HKH191's~w~ Business Mods", "The Value of Stock has just Increased/Decreased for our all Business");
            }
          }
        }
        this.Config.Save();
        this.stockstimer = 0;
      }
      else
        ++this.stockstimer;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        try
        {
          ScriptSettings.Load("scripts//DisableBusinesses.ini").GetValue<bool>("Doomsday Heist Business", "LakeZancudoFacility", false);
        }
        catch (Exception ex)
        {
          UI.Notify("~r~MAJOR Error~w~: ~y~ DisableBusinesses.ini ~w~ NOT FOUND IN GTAV/scripts");
        }
        this.Config = ScriptSettings.Load(iniName);
        try
        {
          this.ShowStockIncrease = this.Config.GetValue<bool>("Setup", "ShowStockIncrease", this.ShowStockIncrease);
          this.HostName = this.Config2.GetValue<string>("Misc", "HostName", this.HostName);
          this.Blip_Colour = this.Config2.GetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
          this.Uicolour = this.Config2.GetValue<string>("Misc", "Uicolour", this.Uicolour);
          this.MarkerColorString = this.Config2.GetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
          this.MarkerColor = Color.FromName(this.MarkerColorString);
        }
        catch (Exception ex)
        {
        }
        try
        {
          this.NextDay = this.Config.GetValue<int>("Setup", "NextDay", this.NextDay);
          this.NextMonth = this.Config.GetValue<int>("Setup", "NextMonth", this.NextMonth);
          this.NextYear = this.Config.GetValue<int>("Setup", "NextYear", this.NextYear);
          this.DaysWait = this.Config.GetValue<int>("Setup", "DaysWait", this.DaysWait);
          this.UseGlobalBusinessIncreaseDeceaseMessage = this.Config.GetValue<bool>("Setup", "UseGlobalBusinessIncreaseDeceaseMessage", this.UseGlobalBusinessIncreaseDeceaseMessage);
          this.BYPASS_NOSAVE_OR_CRASH = this.Config.GetValue<bool>("Setup", "BYPASS_NOSAVE_OR_CRASH", this.BYPASS_NOSAVE_OR_CRASH);
          this.DAYSTORESET_UPDATETIME = this.Config.GetValue<int>("Setup", "DAYSTORESET_UPDATETIME", this.DAYSTORESET_UPDATETIME);
        }
        catch
        {
          this.NextDay = 10;
          this.Config.SetValue<int>("Setup", "NextDay", this.NextDay);
          this.NextMonth = 10;
          this.Config.SetValue<int>("Setup", "NextMonth", this.NextMonth);
          this.NextYear = 2010;
          this.Config.SetValue<int>("Setup", "NextYear", this.NextYear);
          this.DaysWait = 3;
          this.Config.SetValue<int>("Setup", "DaysWait", this.DaysWait);
          this.BYPASS_NOSAVE_OR_CRASH = true;
          this.Config.SetValue<bool>("Setup", "BYPASS_NOSAVE_OR_CRASH", this.BYPASS_NOSAVE_OR_CRASH);
          this.UseGlobalBusinessIncreaseDeceaseMessage = this.Config.GetValue<bool>("Setup", "UseGlobalBusinessIncreaseDeceaseMessage", this.UseGlobalBusinessIncreaseDeceaseMessage);
          this.DAYSTORESET_UPDATETIME = 12;
          this.Config.SetValue<int>("Setup", "DAYSTORESET_UPDATETIME", this.DAYSTORESET_UPDATETIME);
          this.Config.Save();
          AllStocks.TextNotification("CHAR_LESTER", "~r~ Warning ", "Found Critical Error", "A Critical Error Was found in Main.ini and has now been Fixed");
        }
        try
        {
          this.BusinessUpgradeBasePrice = this.Config.GetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
          this.IncreaseStockMinAmount = this.Config.GetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
          this.IncreaseStockMaxAmount = this.Config.GetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
          this.DecreaseStockMinAmount = this.Config.GetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
          this.DecreaseStockMaxAmount = this.Config.GetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
        }
        catch
        {
          this.Config.SetValue<float>("Prices", "BusinessUpgradeIncreaseGain", 75000f);
          this.Config.SetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
          this.Config.SetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
          this.Config.SetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
          this.Config.SetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
          this.Config.SetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
          this.Config.Save();
          AllStocks.TextNotification("CHAR_LESTER", "~r~ Warning ", "Found Critical Error", "A Critical Error Was found in Main.ini and has now been Fixed");
        }
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Main.ini Failed To Load.");
      }
    }

    public static void TextNotification(
      string avatar,
      string author,
      string title,
      string message)
    {
      Function.Call(Hash._0x67C540AA08E4A6F5, (InputArgument) -1, (InputArgument) "CONFIRM_BEEP", (InputArgument) "HUD_MINI_GAME_SOUNDSET");
      Function.Call(Hash._0x202709F4C58A0424, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) message);
      Function.Call<int>(Hash._0x1CCD9A37359072CF, (InputArgument) avatar, (InputArgument) avatar, (InputArgument) true, (InputArgument) 0, (InputArgument) title, (InputArgument) author);
    }

    private void LoadIniFile2(string iniName)
    {
      try
      {
        this.Config2 = ScriptSettings.Load(iniName);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }
  }
}
