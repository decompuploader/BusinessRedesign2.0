using GTA;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ExecutiveBusiness
{
  public class AllStocks : Script
  {
    public bool UseGlobalBusinessIncreaseDeceaseMessage;
    public float BusinessUpgradeBasePrice = 125000f;
    public float IncreaseStockMinAmount = 25000f;
    public float IncreaseStockMaxAmount = 350000f;
    public float DecreaseStockMinAmount = 25000f;
    public float DecreaseStockMaxAmount = 350000f;
    private ScriptSettings Config;
    public int waittime;
    public int stockstimer;
    public int purchaselvl;
    public int maxstocks;
    public float stocksvalue;
    public float profitMargin;
    public int stockscount;
    public bool ShowStockIncrease;
    public DateTime CurrentDate;
    public DateTime NextDate;
    public int DaysWait = 3;
    public int NextDay;
    public int NextMonth;
    public int NextYear;
    public bool BYPASS_NOSAVE_OR_CRASH = true;
    public int DAYSTORESET_UPDATETIME = 12;
    public int Now;
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
      this.Tick += new EventHandler(this.OnTick);
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.Interval = 1;
      this.LoadMain("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
      UI.Notify("~b~ Executive Busienss~w~ Loaded, by ~g~HKH191~");
      this.Now = this.GetDay();
    }

    public void IncreaseGain(string iniName)
    {
      this.LoadIniFile2(iniName);
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl) < 1)
        return;
      Random random = new Random();
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      int decreaseStockMinAmount = (int) this.DecreaseStockMinAmount;
      int decreaseStockMaxAmount = (int) this.DecreaseStockMaxAmount;
      this.stocksvalue += (float) (int) ((float) (random.Next(decreaseStockMinAmount, decreaseStockMaxAmount) * this.purchaselvl) / 1.45f);
      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.Config.Save();
    }

    public void DecreaseGain(string iniName)
    {
      this.LoadIniFile2(iniName);
      if (this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl) < 1)
        return;
      Random random = new Random();
      this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
      this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
      int decreaseStockMinAmount = (int) this.DecreaseStockMinAmount;
      int decreaseStockMaxAmount = (int) this.DecreaseStockMaxAmount;
      this.stocksvalue -= (float) (int) ((float) (random.Next(decreaseStockMinAmount, decreaseStockMaxAmount) * this.purchaselvl) / 1.45f);
      this.Config.SetValue<float>("Setup", "StocksValue", this.stocksvalue);
      this.Config.Save();
    }

    public void SetDate()
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
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
      if ((num1 > this.NextDay || num2 > this.NextMonth) && (num2 >= this.NextMonth && num2 <= this.NextMonth) && year == this.NextYear)
        return;
      this.NextMonth = this.GetMonth();
      this.NextDay = this.GetDay() + this.DaysWait;
      this.NextYear = this.GetYear();
      this.Config.SetValue<int>("Setup", "NextYear", this.NextYear);
      this.Config.SetValue<int>("Setup", "NextDay", this.NextDay);
      this.Config.SetValue<int>("Setup", "NextMonth", this.NextMonth);
      this.Config.Save();
    }

    public int GetHour() => Function.Call<int>(Hash._0x25223CA6B4D20B7F);

    public int GetMinutes() => Function.Call<int>(Hash._0x13D2B8ADD79640F2);

    public int GetDay() => Function.Call<int>(Hash._0x3D10BC92A4DB1D35);

    public int GetMonth() => Function.Call<int>(Hash._0xBBC72712E80257A1);

    public int GetYear() => Function.Call<int>(Hash._0x961777E64BDAF717);

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

    private void OnTick(object sender, EventArgs e)
    {
      this.GetDateRelative();
      if (this.GetDay() == this.NextDay && this.GetMonth() == this.NextMonth)
      {
        this.SetDate();
        bool flag = false;
        foreach (object obj in new List<object>()
        {
          (object) "Main.ini"
        })
        {
          // ISSUE: reference to a compiler-generated field
          if (AllStocks.\u003C\u003Eo__38.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            AllStocks.\u003C\u003Eo__38.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (AllStocks)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (AllStocks.\u003C\u003Eo__38.\u003C\u003Ep__0.Target((CallSite) AllStocks.\u003C\u003Eo__38.\u003C\u003Ep__0, obj) != null)
          {
            this.LoadIniFile2("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
            if (this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl) >= 1)
            {
              flag = true;
              break;
            }
          }
        }
        if (!flag)
          return;
        int num = new Random().Next(1, 1000);
        if (num < 500)
        {
          this.DecreaseGain("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          if (this.ShowStockIncrease)
          {
            if (!this.UseGlobalBusinessIncreaseDeceaseMessage)
              AllStocks.TextNotification("CHAR_LESTER", "~b~ Office Assistant ", "Executive Business", "The Value of Stock has just Increased for our Executive Business");
            if (this.UseGlobalBusinessIncreaseDeceaseMessage)
              AllStocks.TextNotification("CHAR_LESTER", "~g~ Unknown", "All ~g~ HKH191's~w~ Business Mods", "The Value of Stock has just Increased/Decreased for our all Business");
          }
        }
        else if (num >= 500)
        {
          this.IncreaseGain("scripts//HKH191sBusinessMods//ExecutiveBusiness//Main.ini");
          if (this.ShowStockIncrease)
          {
            if (!this.UseGlobalBusinessIncreaseDeceaseMessage)
              AllStocks.TextNotification("CHAR_LESTER", "~b~ Office Assistant ", "Executive Business", "The Value of Stock has just Decreased for our Executive Business");
            if (this.UseGlobalBusinessIncreaseDeceaseMessage)
              AllStocks.TextNotification("CHAR_LESTER", "~g~ Unknown", "All ~g~ HKH191's~w~ Business Mods", "The Value of Stock has just Increased/Decreased for our all Business");
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

    private void LoadIniFile2(string iniName)
    {
      try
      {
        try
        {
          ScriptSettings.Load("scripts//DisableBusinesses.ini").GetValue<bool>("Doomsday Heist Business", "LakeZancudoFacility", (false ? 1 : 0) != 0);
        }
        catch (Exception ex)
        {
          UI.Notify("~r~MAJOR Error~w~: ~y~ DisableBusinesses.ini ~w~ NOT FOUND IN GTAV/scripts");
        }
        this.Config = ScriptSettings.Load(iniName);
        this.purchaselvl = this.Config.GetValue<int>("Setup", "BuisnessLevel", this.purchaselvl);
        this.stockscount = this.Config.GetValue<int>("Setup", "stockslevel", this.stockscount);
        this.stocksvalue = this.Config.GetValue<float>("Setup", "StocksValue", this.stocksvalue);
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
        this.Config = ScriptSettings.Load(iniName);
        this.ShowStockIncrease = this.Config.GetValue<bool>("Setup", "ShowStockIncrease", this.ShowStockIncrease);
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
        catch (Exception ex)
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
          this.DAYSTORESET_UPDATETIME = 12;
          this.Config.SetValue<int>("Setup", "DAYSTORESET_UPDATETIME", this.DAYSTORESET_UPDATETIME);
          this.Config.Save();
        }
        this.BusinessUpgradeBasePrice = this.Config.GetValue<float>("Prices", "BusinessUpgradeBasePrice", this.BusinessUpgradeBasePrice);
        this.IncreaseStockMinAmount = this.Config.GetValue<float>("Prices", "IncreaseStockMinAmount", this.IncreaseStockMinAmount);
        this.IncreaseStockMaxAmount = this.Config.GetValue<float>("Prices", "IncreaseStockMaxAmount", this.IncreaseStockMaxAmount);
        this.DecreaseStockMinAmount = this.Config.GetValue<float>("Prices", "DecreaseStockMinAmount", this.DecreaseStockMinAmount);
        this.DecreaseStockMaxAmount = this.Config.GetValue<float>("Prices", "DecreaseStockMaxAmount", this.DecreaseStockMaxAmount);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }
  }
}
