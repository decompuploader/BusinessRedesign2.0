using GTA;
using GTA.Native;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DRaC_Business
{
  public class AllStocks : Script
  {
    public bool UseGlobalBusinessIncreaseDeceaseMessage;
    private ScriptSettings Config2;
    private ScriptSettings Config;
    private ScriptSettings CarConfig;
    public int waittime;
    public int stockstimer;
    public int purchaselvl;
    public int ArcadeBusinessLevel;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public bool ShowStockIncrease;
    public string HostName;
    public BlipColor Blip_Colour;
    public string Uicolour;
    public Color MarkerColor;
    public string MarkerColorString;
    public int Casino_level;
    public DateTime CurrentDate;
    public DateTime NextDate;
    public int DaysWait = 3;
    public int NextDay;
    public int NextMonth;
    public int NextYear;
    public bool BYPASS_NOSAVE_OR_CRASH = true;
    public int DAYSTORESET_UPDATETIME = 12;
    public int Now;
    public bool ResetPrizeCar;
    public string PrizeCarDisplayName;
    public int PrizeCarUnlocked;
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

    public AllStocks()
    {
      this.LoadMain("scripts//HKH191sBusinessMods//DC&R//Main.ini");
      this.LoadIniFile2("scripts//HKH191sBusinessMods//DC&R//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
      this.Tick += new EventHandler(this.OnTick);
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.Interval = 1;
      this.Now = this.GetDay();
    }

    public string GetHostName() => "~" + this.Uicolour + "~ " + this.HostName + "~w~ ";

    public void UpdateValues() => this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");

    public void IncreaseGain(string iniName)
    {
      this.LoadIniFile(iniName);
      Random random = new Random();
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.stocksvalue += (float) (int) ((float) (random.Next((int) this.DecreaseStockMinAmount, (int) this.DecreaseStockMaxAmount) * this.purchaselvl) / 1.45f);
      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.Config.Save();
    }

    public void DecreaseGain(string iniName)
    {
      this.LoadIniFile(iniName);
      Random random = new Random();
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.stocksvalue -= (float) (int) ((float) (random.Next((int) this.DecreaseStockMinAmount, (int) this.DecreaseStockMaxAmount) * this.purchaselvl) / 1.45f);
      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.Config.Save();
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

    public void SetDate()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Main.ini");
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
        this.ResetPrizeCar = true;
        this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
        if (this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl) >= 1 && this.Config.GetValue<int>("Setup", "Casinoi_Upgrade_Level", this.Casino_level) >= 2)
        {
          int num = new Random().Next(1, 1000);
          if (num < 500)
          {
            this.DecreaseGain("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
            if (this.ShowStockIncrease)
            {
              this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
              this.LoadIniFile2("scripts//HKH191sBusinessMods//DC&R//Main.ini");
              if (!this.UseGlobalBusinessIncreaseDeceaseMessage)
                AllStocks.TextNotification("CHAR_LESTER", "~" + this.Uicolour + "~" + this.GetHostName(), "DC&R Business", "The Value of Stock has just Increased for our DC&R Business");
              if (this.UseGlobalBusinessIncreaseDeceaseMessage)
                AllStocks.TextNotification("CHAR_LESTER", "~g~ Unknown", "All ~g~ HKH191's~w~ Business Mods", "The Value of Stock has just Increased/Decreased for our all Business");
            }
          }
          else if (num >= 500)
          {
            this.IncreaseGain("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
            this.LoadIniFile2("scripts//HKH191sBusinessMods//DC&R//Main.ini");
            if (this.ShowStockIncrease)
            {
              this.LoadIniFile("scripts//HKH191sBusinessMods//DC&R//Casino.ini");
              this.LoadIniFile2("scripts//HKH191sBusinessMods//DC&R//Main.ini");
              if (!this.UseGlobalBusinessIncreaseDeceaseMessage)
                AllStocks.TextNotification("CHAR_LESTER", "~" + this.Uicolour + "~" + this.GetHostName(), "DC&R Business", "The Value of Stock has just Decreased for our DC&R Business");
              if (this.UseGlobalBusinessIncreaseDeceaseMessage)
                AllStocks.TextNotification("CHAR_LESTER", "~g~ Unknown", "All ~g~ HKH191's~w~ Business Mods", "The Value of Stock has just Increased/Decreased for our all Business");
            }
          }
        }
        this.Config.Save();
        this.stockstimer = 0;
        float num1 = (float) new Random().Next(0, 50);
        if ((double) num1 == 0.0)
        {
          this.PrizeCarDisplayName = "THRAX";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 1.0)
        {
          this.PrizeCarDisplayName = "AUTARCH";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 2.0)
        {
          this.PrizeCarDisplayName = "PROTOTIPO";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 3.0)
        {
          this.PrizeCarDisplayName = "DEVESTE";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 4.0)
        {
          this.PrizeCarDisplayName = "ITALIGTO";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 5.0)
        {
          this.PrizeCarDisplayName = "NEO";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 6.0)
        {
          this.PrizeCarDisplayName = "DELUXO";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 7.0)
        {
          this.PrizeCarDisplayName = "TORERO";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 8.0)
        {
          this.PrizeCarDisplayName = "ZTYPE";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 9.0)
        {
          this.PrizeCarDisplayName = "TURISMO2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 10.0)
        {
          this.PrizeCarDisplayName = "HERMES";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 11.0)
        {
          this.PrizeCarDisplayName = "GAUNTLET4";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 12.0)
        {
          this.PrizeCarDisplayName = "NIGHTSHADE";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 13.0)
        {
          this.PrizeCarDisplayName = "FREECRAWLER";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 14.0)
        {
          this.PrizeCarDisplayName = "RIATA";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 15.0)
        {
          this.PrizeCarDisplayName = "MENACER";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 16.0)
        {
          this.PrizeCarDisplayName = "XLS2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 17.0)
        {
          this.PrizeCarDisplayName = "TOROS";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 18.0)
        {
          this.PrizeCarDisplayName = "THRAX";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 19.0)
        {
          this.PrizeCarDisplayName = "LE7B";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 20.0)
        {
          this.PrizeCarDisplayName = "ENTITY2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 21.0)
        {
          this.PrizeCarDisplayName = "EVERON";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 22.0)
        {
          this.PrizeCarDisplayName = "OUTLAW";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 23.0)
        {
          this.PrizeCarDisplayName = "VAGRANT";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 24.0)
        {
          this.PrizeCarDisplayName = "FORMULA";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 25.0)
        {
          this.PrizeCarDisplayName = "FORMULA2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 26.0)
        {
          this.PrizeCarDisplayName = "FURIA";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 27.0)
        {
          this.PrizeCarDisplayName = "VSTR";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 28.0)
        {
          this.PrizeCarDisplayName = "SULTANRS";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 29.0)
        {
          this.PrizeCarDisplayName = "SULTAN2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 30.0)
        {
          this.PrizeCarDisplayName = "SUGOI";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 31.0)
        {
          this.PrizeCarDisplayName = "VIGILANTE";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 32.0)
        {
          this.PrizeCarDisplayName = "KHANJALI";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 33.0)
        {
          this.PrizeCarDisplayName = "BARRAGE";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 34.0)
        {
          this.PrizeCarDisplayName = "LYNX";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 35.0)
        {
          this.PrizeCarDisplayName = "IMORGON";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 36.0)
        {
          this.PrizeCarDisplayName = "COMET5";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 37.0)
        {
          this.PrizeCarDisplayName = "PARIAH";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 38.0)
        {
          this.PrizeCarDisplayName = "VISERIS";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 39.0)
        {
          this.PrizeCarDisplayName = "INFERNUS2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 40.0)
        {
          this.PrizeCarDisplayName = "FCR2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 41.0)
        {
          this.PrizeCarDisplayName = "BF400";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 42.0)
        {
          this.PrizeCarDisplayName = "BATI2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 43.0)
        {
          this.PrizeCarDisplayName = "OPPRESSOR2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 44.0)
        {
          this.PrizeCarDisplayName = "OPPRESSOR";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 45.0)
        {
          this.PrizeCarDisplayName = "STRYDER";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 46.0)
        {
          this.PrizeCarDisplayName = "GAUNTLET3";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 47.0)
        {
          this.PrizeCarDisplayName = "XA21";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 48.0)
        {
          this.PrizeCarDisplayName = "FMJ";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 49.0)
        {
          this.PrizeCarDisplayName = "JB7002";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        if ((double) num1 == 50.0)
        {
          this.PrizeCarDisplayName = "CHEETAH2";
          this.Config.SetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        }
        this.SaveCarToFile("scripts//HKH191sBusinessMods//DC&R//PrizeCar//" + this.PrizeCarDisplayName + ".ini");
        this.SaveCarToFile("scripts//HKH191sBusinessMods//DC&R//PrizeCar//" + this.PrizeCarDisplayName + ".ini");
        this.Config.Save();
        this.ResetPrizeCar = false;
      }
      else
        ++this.stockstimer;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
    }

    private void LoadIniFile2(string iniName)
    {
      try
      {
        this.Config2 = ScriptSettings.Load(iniName);
        this.ShowStockIncrease = this.Config2.GetValue<bool>("Setup", "ShowStockIncrease", this.ShowStockIncrease);
        try
        {
          this.NextDay = this.Config2.GetValue<int>("Setup", "NextDay", this.NextDay);
          this.NextMonth = this.Config2.GetValue<int>("Setup", "NextMonth", this.NextMonth);
          this.NextYear = this.Config2.GetValue<int>("Setup", "NextYear", this.NextYear);
          this.DaysWait = this.Config2.GetValue<int>("Setup", "DaysWait", this.DaysWait);
          this.UseGlobalBusinessIncreaseDeceaseMessage = this.Config2.GetValue<bool>("Setup", "UseGlobalBusinessIncreaseDeceaseMessage", this.UseGlobalBusinessIncreaseDeceaseMessage);
          this.BYPASS_NOSAVE_OR_CRASH = this.Config2.GetValue<bool>("Setup", "BYPASS_NOSAVE_OR_CRASH", this.BYPASS_NOSAVE_OR_CRASH);
          this.DAYSTORESET_UPDATETIME = this.Config2.GetValue<int>("Setup", "DAYSTORESET_UPDATETIME", this.DAYSTORESET_UPDATETIME);
        }
        catch (Exception ex)
        {
          this.NextDay = 10;
          this.Config2.SetValue<int>("Setup", "NextDay", this.NextDay);
          this.NextMonth = 10;
          this.Config2.SetValue<int>("Setup", "NextMonth", this.NextMonth);
          this.NextYear = 2010;
          this.Config2.SetValue<int>("Setup", "NextYear", this.NextYear);
          this.DaysWait = 3;
          this.Config2.SetValue<int>("Setup", "DaysWait", this.DaysWait);
          this.BYPASS_NOSAVE_OR_CRASH = true;
          this.Config2.SetValue<bool>("Setup", "BYPASS_NOSAVE_OR_CRASH", this.BYPASS_NOSAVE_OR_CRASH);
          this.DAYSTORESET_UPDATETIME = 12;
          this.Config2.SetValue<int>("Setup", "DAYSTORESET_UPDATETIME", this.DAYSTORESET_UPDATETIME);
          this.Config2.Save();
        }
        this.BusinessUpgradeBasePrice = this.Config2.GetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
        this.IncreaseStockMinAmount = this.Config2.GetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
        this.IncreaseStockMaxAmount = this.Config2.GetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
        this.DecreaseStockMinAmount = this.Config2.GetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
        this.DecreaseStockMaxAmount = this.Config2.GetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
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
        this.ShowStockIncrease = this.Config.GetValue<bool>("Setup", "ShowStockIncrease", this.ShowStockIncrease);
        this.waittime = this.Config.GetValue<int>("Setup", "WaitTime", this.waittime);
        this.HostName = this.Config.GetValue<string>("Misc", "HostName", this.HostName);
        this.Blip_Colour = this.Config.GetValue<BlipColor>("Misc", "Blip_Colour", this.Blip_Colour);
        this.Uicolour = this.Config.GetValue<string>("Misc", "Uicolour", this.Uicolour);
        this.MarkerColorString = this.Config.GetValue<string>("Misc", "MarkerColor", this.MarkerColorString);
        this.MarkerColor = Color.FromName(this.MarkerColorString);
        this.Casino_level = this.Config.GetValue<int>("Setup", "Casinoi_Upgrade_Level", this.Casino_level);
        this.PrizeCarDisplayName = this.Config.GetValue<string>("Setup", "PrizeCarDisplayName", this.PrizeCarDisplayName);
        this.ArcadeBusinessLevel = this.Config.GetValue<int>("Arcade", "ArcadeBusinessLevel", this.ArcadeBusinessLevel);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    private void SaveCarToFile(string iniName)
    {
      try
      {
        this.CarConfig = ScriptSettings.Load(iniName);
        if (!File.Exists("scripts//HKH191sBusinessMods//DC&R//PrizeCar//" + this.PrizeCarDisplayName + ".ini"))
        {
          File.Create("scripts//HKH191sBusinessMods//DC&R//PrizeCar//" + this.PrizeCarDisplayName + ".ini");
          this.CarConfig = ScriptSettings.Load(iniName);
          this.PrizeCarUnlocked = 0;
          this.CarConfig.SetValue<int>("Vehicle", "Unlocked", this.PrizeCarUnlocked);
          this.CarConfig.Save();
        }
        try
        {
          this.PrizeCarUnlocked = this.CarConfig.GetValue<int>("Vehicle", "Unlocked", this.PrizeCarUnlocked);
        }
        catch
        {
          this.PrizeCarUnlocked = 0;
          this.CarConfig.SetValue<int>("Vehicle", "Unlocked", this.PrizeCarUnlocked);
          this.CarConfig.Save();
        }
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }
  }
}
