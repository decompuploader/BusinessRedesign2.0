using GTA;
using NativeUI;
using System;
using System.Drawing;

namespace DRaC_Business
{
  public class MissionScreen : Script
  {
    private ScriptSettings Config;
    public bool Fail;
    public bool Pass;
    public bool FailSetup;
    public bool PassSetup;
    public string m;
    public int p;
    public string r;
    public int Timer;
    public float t;
    public int H;
    public int c;
    public int cp;
    public int FleecaBestTime;
    public int PacificStandardBestTime;
    public int PaletoBestTime;
    public int VangelicoBestTime;
    public int UnionDelpositioryBestTime;
    public int LEXIGTONRAIDBestTime;
    public int SURVERDOWNBestTime;
    public int NUCLEAREXPANSIONHEISTBestTime;
    public int DEEPDEAPTHSHEISTBestTime;
    public int HUMANELABS2BestTime;
    public int YachtHeistBestTime;
    public int BerkraneJobBestTime;
    public int DiamondHeistBestTime;
    public int BestTime = 0;
    public float MaxHp;
    public float MaxArmour;
    public bool ShowCCTVBlipAliveDebug;
    public bool ShowCCTVBlipDeadDebug;
    public bool ShowPacificStandardVaultDebug;
    public bool CreateUnionDepositoryBlocker;
    public bool ShowTimeronShiftX;
    public bool AIinCasinoHeistCanWander;
    public int AIinCasinoWanderChance;
    public int AIinCasinoWanderRadius;

    public void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
        this.FleecaBestTime = this.Config.GetValue<int>("BEST_TIMES", "FLEECA", this.FleecaBestTime);
        this.PaletoBestTime = this.Config.GetValue<int>("BEST_TIMES", "PALETO", this.PaletoBestTime);
        this.PacificStandardBestTime = this.Config.GetValue<int>("BEST_TIMES", "PACIFICSTANDARD", this.PacificStandardBestTime);
        this.VangelicoBestTime = this.Config.GetValue<int>("BEST_TIMES", "VANGELICO", this.VangelicoBestTime);
        this.UnionDelpositioryBestTime = this.Config.GetValue<int>("BEST_TIMES", "UNIONDEPOSITORY", this.UnionDelpositioryBestTime);
        this.LEXIGTONRAIDBestTime = this.Config.GetValue<int>("BEST_TIMES", "LEXIGTONRAID", this.LEXIGTONRAIDBestTime);
        this.SURVERDOWNBestTime = this.Config.GetValue<int>("BEST_TIMES", "SURVERDOWN", this.SURVERDOWNBestTime);
        this.NUCLEAREXPANSIONHEISTBestTime = this.Config.GetValue<int>("BEST_TIMES", "NUCLEAREXPANSIONHEIST", this.NUCLEAREXPANSIONHEISTBestTime);
        this.DEEPDEAPTHSHEISTBestTime = this.Config.GetValue<int>("BEST_TIMES", "DEEPDEAPTHSHEIST", this.DEEPDEAPTHSHEISTBestTime);
        this.HUMANELABS2BestTime = this.Config.GetValue<int>("BEST_TIMES", "HUMANELABS#2", this.HUMANELABS2BestTime);
        this.YachtHeistBestTime = this.Config.GetValue<int>("BEST_TIMES", "YachtHeist", this.YachtHeistBestTime);
        this.BerkraneJobBestTime = this.Config.GetValue<int>("BEST_TIMES", "BerkraneJob", this.BerkraneJobBestTime);
        this.DiamondHeistBestTime = this.Config.GetValue<int>("BEST_TIMES", "DiamondHeist", this.DiamondHeistBestTime);
        this.MaxHp = this.Config.GetValue<float>("Misc", "MaxHp", this.MaxHp);
        this.MaxArmour = this.Config.GetValue<float>("Misc", "MaxArmour", this.MaxArmour);
        this.ShowCCTVBlipAliveDebug = this.Config.GetValue<bool>("Misc", "ShowCCTVBlipAliveDebug", this.ShowCCTVBlipAliveDebug);
        this.ShowCCTVBlipDeadDebug = this.Config.GetValue<bool>("Misc", "ShowCCTVBlipDeadDebug", this.ShowCCTVBlipDeadDebug);
        this.ShowPacificStandardVaultDebug = this.Config.GetValue<bool>("Misc", "ShowPacificStandardVaultDebug", this.ShowPacificStandardVaultDebug);
        this.CreateUnionDepositoryBlocker = this.Config.GetValue<bool>("Misc", "CreateUnionDepositoryBlocker", this.CreateUnionDepositoryBlocker);
        this.ShowTimeronShiftX = this.Config.GetValue<bool>("Misc", "ShowTimeronShiftX", this.ShowTimeronShiftX);
        this.AIinCasinoHeistCanWander = this.Config.GetValue<bool>("Misc", "AIinCasinoHeistCanWander", this.AIinCasinoHeistCanWander);
        this.AIinCasinoWanderChance = this.Config.GetValue<int>("Misc", "AIinCasinoWanderChance", this.AIinCasinoWanderChance);
        this.AIinCasinoWanderRadius = this.Config.GetValue<int>("Misc", "AIinCasinoWanderRadius", this.AIinCasinoWanderRadius);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public void MissionPassed(string MissionName, int Payout)
    {
      this.Fail = false;
      this.Pass = true;
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 450), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("mission passed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 199, 168, 87), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      new UIResText(MissionName, new Point(int32, 230), 0.5f, Color.White, GTA.Font.ChaletComprimeCologne, UIResText.Alignment.Centered).Draw();
      new UIResText("Payout : $" + Payout.ToString("N"), new Point(int32, 300), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void MissionFailed(string Reason, string MissionName)
    {
      this.Pass = false;
      this.Fail = true;
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 30), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 450), 0.0f, Color.FromArgb(230, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("mission failed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 148, 27, 46), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      new UIResText(MissionName, new Point(int32, 230), 0.5f, Color.White, GTA.Font.ChaletComprimeCologne, UIResText.Alignment.Centered).Draw();
      new UIResText("Reason : " + Reason, new Point(int32, 280), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void SetFail(
      string MissionName,
      int Payout,
      int CrewCut,
      string Reason,
      int CrewAlive,
      float Time,
      int Heist)
    {
      Audio.SetAudioFlag("LoadMPData", true);
      Audio.PlaySoundFrontend("Bed", "WastedSounds");
      Audio.SetAudioFlag("LoadMPData", false);
      this.Timer = 300;
      this.m = MissionName;
      this.p = Payout;
      this.t = Time;
      this.c = CrewAlive;
      this.r = Reason;
      this.H = Heist;
      this.cp = CrewCut;
      this.Fail = true;
      for (int index = 0; index < 300; ++index)
      {
        if (this.Fail)
          this.MissionFailed(this.r, this.m, this.cp, this.c, this.t, this.H);
        if (this.Pass)
          this.MissionPassed(this.m, this.p, this.cp, this.c, this.t, this.H);
        Script.Wait(1);
      }
    }

    public void SetPass(
      string MissionName,
      int Payout,
      int CrewCut,
      string Reason,
      int CrewAlive,
      float Time,
      int Heist)
    {
      Audio.SetAudioFlag("LoadMPData", true);
      Audio.PlaySoundFrontend("Mission_Pass_Notify", "DLC_HEISTS_GENERAL_FRONTEND_SOUNDS");
      Audio.SetAudioFlag("LoadMPData", false);
      this.Timer = 300;
      this.m = MissionName;
      this.p = Payout;
      this.t = Time;
      this.c = CrewAlive;
      this.r = Reason;
      this.H = Heist;
      this.cp = CrewCut;
      this.Pass = true;
      for (int index = 0; index < 300; ++index)
      {
        if (this.Fail)
          this.MissionFailed(this.r, this.m, this.cp, this.c, this.t, this.H);
        if (this.Pass)
          this.MissionPassed(this.m, this.p, this.cp, this.c, this.t, this.H);
        Script.Wait(1);
      }
    }

    public bool GetGoldAll()
    {
      this.LoadIniFile("scripts//Payday.ini");
      float num1 = 0.0f;
      int num2 = 0;
      int Heist1 = 1;
      int num3 = 0;
      int num4 = 0;
      if (Heist1 == 1)
      {
        num3 = this.GetTimeBronze(Heist1);
        int timeGold = this.GetTimeGold(Heist1);
        num4 = this.GetTimeSilver(Heist1);
        if (Heist1 == 1)
          num1 = (float) this.FleecaBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist2 = Heist1 + 1;
      if (Heist2 == 2)
      {
        num3 = this.GetTimeBronze(Heist2);
        int timeGold = this.GetTimeGold(Heist2);
        num4 = this.GetTimeSilver(Heist2);
        if (Heist2 == 2)
          num1 = (float) this.PaletoBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist3 = Heist2 + 1;
      if (Heist3 == 3)
      {
        num3 = this.GetTimeBronze(Heist3);
        int timeGold = this.GetTimeGold(Heist3);
        num4 = this.GetTimeSilver(Heist3);
        if (Heist3 == 3)
          num1 = (float) this.PacificStandardBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist4 = Heist3 + 1;
      if (Heist4 == 4)
      {
        num3 = this.GetTimeBronze(Heist4);
        int timeGold = this.GetTimeGold(Heist4);
        num4 = this.GetTimeSilver(Heist4);
        if (Heist4 == 4)
          num1 = (float) this.VangelicoBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist5 = Heist4 + 1;
      if (Heist5 == 5)
      {
        num3 = this.GetTimeBronze(Heist5);
        int timeGold = this.GetTimeGold(Heist5);
        num4 = this.GetTimeSilver(Heist5);
        if (Heist5 == 5)
          num1 = (float) this.UnionDelpositioryBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist6 = Heist5 + 1;
      if (Heist6 == 6)
      {
        num3 = this.GetTimeBronze(Heist6);
        int timeGold = this.GetTimeGold(Heist6);
        num4 = this.GetTimeSilver(Heist6);
        if (Heist6 == 6)
          num1 = (float) this.LEXIGTONRAIDBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist7 = Heist6 + 1;
      if (Heist7 == 7)
      {
        num3 = this.GetTimeBronze(Heist7);
        int timeGold = this.GetTimeGold(Heist7);
        num4 = this.GetTimeSilver(Heist7);
        if (Heist7 == 7)
          num1 = (float) this.SURVERDOWNBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist8 = Heist7 + 1;
      if (Heist8 == 8)
      {
        num3 = this.GetTimeBronze(Heist8);
        int timeGold = this.GetTimeGold(Heist8);
        num4 = this.GetTimeSilver(Heist8);
        if (Heist8 == 8)
          num1 = (float) this.NUCLEAREXPANSIONHEISTBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist9 = Heist8 + 1;
      if (Heist9 == 9)
      {
        num3 = this.GetTimeBronze(Heist9);
        int timeGold = this.GetTimeGold(Heist9);
        num4 = this.GetTimeSilver(Heist9);
        if (Heist9 == 9)
          num1 = (float) this.DEEPDEAPTHSHEISTBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist10 = Heist9 + 1;
      if (Heist10 == 10)
      {
        num3 = this.GetTimeBronze(Heist10);
        int timeGold = this.GetTimeGold(Heist10);
        num4 = this.GetTimeSilver(Heist10);
        if (Heist10 == 10)
          num1 = (float) this.HUMANELABS2BestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist11 = Heist10 + 1;
      if (Heist11 == 11)
      {
        num3 = this.GetTimeBronze(Heist11);
        int timeGold = this.GetTimeGold(Heist11);
        num4 = this.GetTimeSilver(Heist11);
        if (Heist11 == 11)
          num1 = (float) this.YachtHeistBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      int Heist12 = Heist11 + 1;
      if (Heist12 == 12)
      {
        num3 = this.GetTimeBronze(Heist12);
        int timeGold = this.GetTimeGold(Heist12);
        num4 = this.GetTimeSilver(Heist12);
        if (Heist12 == 12)
          num1 = (float) this.BerkraneJobBestTime;
        if ((double) num1 < (double) timeGold)
          ++num2;
        if ((double) num1 > (double) timeGold)
          num2 = num2;
      }
      bool flag = false;
      if (num2 >= 12)
        flag = true;
      if (num2 < 12)
        flag = false;
      return flag;
    }

    public bool GetSliverAll()
    {
      this.LoadIniFile("scripts//Payday.ini");
      float num1 = 0.0f;
      int num2 = 0;
      int Heist1 = 1;
      int num3 = 0;
      int num4 = 0;
      if (Heist1 == 1)
      {
        num3 = this.GetTimeBronze(Heist1);
        num4 = this.GetTimeGold(Heist1);
        int timeSilver = this.GetTimeSilver(Heist1);
        if (Heist1 == 1)
          num1 = (float) this.FleecaBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist2 = Heist1 + 1;
      if (Heist2 == 2)
      {
        num3 = this.GetTimeBronze(Heist2);
        num4 = this.GetTimeGold(Heist2);
        int timeSilver = this.GetTimeSilver(Heist2);
        if (Heist2 == 2)
          num1 = (float) this.PaletoBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist3 = Heist2 + 1;
      if (Heist3 == 3)
      {
        num3 = this.GetTimeBronze(Heist3);
        num4 = this.GetTimeGold(Heist3);
        int timeSilver = this.GetTimeSilver(Heist3);
        if (Heist3 == 3)
          num1 = (float) this.PacificStandardBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist4 = Heist3 + 1;
      if (Heist4 == 4)
      {
        num3 = this.GetTimeBronze(Heist4);
        num4 = this.GetTimeGold(Heist4);
        int timeSilver = this.GetTimeSilver(Heist4);
        if (Heist4 == 4)
          num1 = (float) this.VangelicoBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist5 = Heist4 + 1;
      if (Heist5 == 5)
      {
        num3 = this.GetTimeBronze(Heist5);
        num4 = this.GetTimeGold(Heist5);
        int timeSilver = this.GetTimeSilver(Heist5);
        if (Heist5 == 5)
          num1 = (float) this.UnionDelpositioryBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist6 = Heist5 + 1;
      if (Heist6 == 6)
      {
        num3 = this.GetTimeBronze(Heist6);
        num4 = this.GetTimeGold(Heist6);
        int timeSilver = this.GetTimeSilver(Heist6);
        if (Heist6 == 6)
          num1 = (float) this.LEXIGTONRAIDBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist7 = Heist6 + 1;
      if (Heist7 == 7)
      {
        num3 = this.GetTimeBronze(Heist7);
        num4 = this.GetTimeGold(Heist7);
        int timeSilver = this.GetTimeSilver(Heist7);
        if (Heist7 == 7)
          num1 = (float) this.SURVERDOWNBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist8 = Heist7 + 1;
      if (Heist8 == 8)
      {
        num3 = this.GetTimeBronze(Heist8);
        num4 = this.GetTimeGold(Heist8);
        int timeSilver = this.GetTimeSilver(Heist8);
        if (Heist8 == 8)
          num1 = (float) this.NUCLEAREXPANSIONHEISTBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist9 = Heist8 + 1;
      if (Heist9 == 9)
      {
        num3 = this.GetTimeBronze(Heist9);
        num4 = this.GetTimeGold(Heist9);
        int timeSilver = this.GetTimeSilver(Heist9);
        if (Heist9 == 9)
          num1 = (float) this.DEEPDEAPTHSHEISTBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist10 = Heist9 + 1;
      if (Heist10 == 10)
      {
        num3 = this.GetTimeBronze(Heist10);
        num4 = this.GetTimeGold(Heist10);
        int timeSilver = this.GetTimeSilver(Heist10);
        if (Heist10 == 10)
          num1 = (float) this.HUMANELABS2BestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist11 = Heist10 + 1;
      if (Heist11 == 11)
      {
        num3 = this.GetTimeBronze(Heist11);
        num4 = this.GetTimeGold(Heist11);
        int timeSilver = this.GetTimeSilver(Heist11);
        if (Heist11 == 11)
          num1 = (float) this.YachtHeistBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      int Heist12 = Heist11 + 1;
      if (Heist12 == 12)
      {
        num3 = this.GetTimeBronze(Heist12);
        num4 = this.GetTimeGold(Heist12);
        int timeSilver = this.GetTimeSilver(Heist12);
        if (Heist12 == 12)
          num1 = (float) this.BerkraneJobBestTime;
        if ((double) num1 < (double) timeSilver)
          ++num2;
        if ((double) num1 > (double) timeSilver)
          num2 = num2;
      }
      bool flag = false;
      if (num2 >= 12)
        flag = true;
      if (num2 < 12)
        flag = false;
      return flag;
    }

    public bool GetBronzeAll()
    {
      this.LoadIniFile("scripts//Payday.ini");
      float num1 = 0.0f;
      int num2 = 0;
      int Heist1 = 1;
      int num3 = 0;
      int num4 = 0;
      if (Heist1 == 1)
      {
        int timeBronze = this.GetTimeBronze(Heist1);
        num3 = this.GetTimeGold(Heist1);
        num4 = this.GetTimeSilver(Heist1);
        if (Heist1 == 1)
          num1 = (float) this.FleecaBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist2 = Heist1 + 1;
      if (Heist2 == 2)
      {
        int timeBronze = this.GetTimeBronze(Heist2);
        num3 = this.GetTimeGold(Heist2);
        num4 = this.GetTimeSilver(Heist2);
        if (Heist2 == 2)
          num1 = (float) this.PaletoBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist3 = Heist2 + 1;
      if (Heist3 == 3)
      {
        int timeBronze = this.GetTimeBronze(Heist3);
        num3 = this.GetTimeGold(Heist3);
        num4 = this.GetTimeSilver(Heist3);
        if (Heist3 == 3)
          num1 = (float) this.PacificStandardBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist4 = Heist3 + 1;
      if (Heist4 == 4)
      {
        int timeBronze = this.GetTimeBronze(Heist4);
        num3 = this.GetTimeGold(Heist4);
        num4 = this.GetTimeSilver(Heist4);
        if (Heist4 == 4)
          num1 = (float) this.VangelicoBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist5 = Heist4 + 1;
      if (Heist5 == 5)
      {
        int timeBronze = this.GetTimeBronze(Heist5);
        num3 = this.GetTimeGold(Heist5);
        num4 = this.GetTimeSilver(Heist5);
        if (Heist5 == 5)
          num1 = (float) this.UnionDelpositioryBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist6 = Heist5 + 1;
      if (Heist6 == 6)
      {
        int timeBronze = this.GetTimeBronze(Heist6);
        num3 = this.GetTimeGold(Heist6);
        num4 = this.GetTimeSilver(Heist6);
        if (Heist6 == 6)
          num1 = (float) this.LEXIGTONRAIDBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist7 = Heist6 + 1;
      if (Heist7 == 7)
      {
        int timeBronze = this.GetTimeBronze(Heist7);
        num3 = this.GetTimeGold(Heist7);
        num4 = this.GetTimeSilver(Heist7);
        if (Heist7 == 7)
          num1 = (float) this.SURVERDOWNBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist8 = Heist7 + 1;
      if (Heist8 == 8)
      {
        int timeBronze = this.GetTimeBronze(Heist8);
        num3 = this.GetTimeGold(Heist8);
        num4 = this.GetTimeSilver(Heist8);
        if (Heist8 == 8)
          num1 = (float) this.NUCLEAREXPANSIONHEISTBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist9 = Heist8 + 1;
      if (Heist9 == 9)
      {
        int timeBronze = this.GetTimeBronze(Heist9);
        num3 = this.GetTimeGold(Heist9);
        num4 = this.GetTimeSilver(Heist9);
        if (Heist9 == 9)
          num1 = (float) this.DEEPDEAPTHSHEISTBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist10 = Heist9 + 1;
      if (Heist10 == 10)
      {
        int timeBronze = this.GetTimeBronze(Heist10);
        num3 = this.GetTimeGold(Heist10);
        num4 = this.GetTimeSilver(Heist10);
        if (Heist10 == 10)
          num1 = (float) this.HUMANELABS2BestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist11 = Heist10 + 1;
      if (Heist11 == 11)
      {
        int timeBronze = this.GetTimeBronze(Heist11);
        num3 = this.GetTimeGold(Heist11);
        num4 = this.GetTimeSilver(Heist11);
        if (Heist11 == 11)
          num1 = (float) this.YachtHeistBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      int Heist12 = Heist11 + 1;
      if (Heist12 == 12)
      {
        int timeBronze = this.GetTimeBronze(Heist12);
        num3 = this.GetTimeGold(Heist12);
        num4 = this.GetTimeSilver(Heist12);
        if (Heist12 == 12)
          num1 = (float) this.BerkraneJobBestTime;
        if ((double) num1 < (double) timeBronze)
          ++num2;
        if ((double) num1 > (double) timeBronze)
          num2 = num2;
      }
      bool flag = false;
      if (num2 >= 12)
        flag = true;
      if (num2 < 12)
        flag = false;
      return flag;
    }

    public bool GetGold(int Heist)
    {
      this.LoadIniFile("scripts//Payday.ini");
      float num1 = 0.0f;
      if (Heist == 1)
        num1 = (float) this.FleecaBestTime;
      if (Heist == 2)
        num1 = (float) this.PaletoBestTime;
      if (Heist == 3)
        num1 = (float) this.PacificStandardBestTime;
      if (Heist == 4)
        num1 = (float) this.VangelicoBestTime;
      if (Heist == 5)
        num1 = (float) this.UnionDelpositioryBestTime;
      if (Heist == 6)
        num1 = (float) this.LEXIGTONRAIDBestTime;
      if (Heist == 7)
        num1 = (float) this.SURVERDOWNBestTime;
      if (Heist == 8)
        num1 = (float) this.NUCLEAREXPANSIONHEISTBestTime;
      if (Heist == 9)
        num1 = (float) this.DEEPDEAPTHSHEISTBestTime;
      if (Heist == 10)
        num1 = (float) this.HUMANELABS2BestTime;
      if (Heist == 11)
        num1 = (float) this.YachtHeistBestTime;
      if (Heist == 12)
        num1 = (float) this.BerkraneJobBestTime;
      if (Heist == 13)
        num1 = (float) this.DiamondHeistBestTime;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      string str = "";
      if (Heist == 1)
      {
        str = "The Fleeca Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 2)
      {
        str = "The Paleto Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 3)
      {
        str = "The Pacific Standard";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 4)
      {
        str = "The Jewel Store Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 5)
      {
        str = "The Union Depository";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 6)
      {
        str = "USS Luxington Raid";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 7)
      {
        str = "Surver Down Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 8)
      {
        str = "The Nuclear Expansion";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 9)
      {
        str = "Deep Deapths Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 10)
      {
        str = "Humane Labs #2";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 11)
      {
        str = "The Yacht Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 12)
      {
        str = "The Belkrane Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 13)
      {
        str = "The Diamond Casino Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      bool flag = false;
      if ((double) num1 < (double) num3)
        flag = true;
      if ((double) num1 > (double) num3)
        flag = false;
      return flag;
    }

    public bool GetSliver(int Heist)
    {
      this.LoadIniFile("scripts//Payday.ini");
      float num1 = 0.0f;
      if (Heist == 1)
        num1 = (float) this.FleecaBestTime;
      if (Heist == 2)
        num1 = (float) this.PaletoBestTime;
      if (Heist == 3)
        num1 = (float) this.PacificStandardBestTime;
      if (Heist == 4)
        num1 = (float) this.VangelicoBestTime;
      if (Heist == 5)
        num1 = (float) this.UnionDelpositioryBestTime;
      if (Heist == 6)
        num1 = (float) this.LEXIGTONRAIDBestTime;
      if (Heist == 7)
        num1 = (float) this.SURVERDOWNBestTime;
      if (Heist == 8)
        num1 = (float) this.NUCLEAREXPANSIONHEISTBestTime;
      if (Heist == 9)
        num1 = (float) this.DEEPDEAPTHSHEISTBestTime;
      if (Heist == 10)
        num1 = (float) this.HUMANELABS2BestTime;
      if (Heist == 11)
        num1 = (float) this.YachtHeistBestTime;
      if (Heist == 12)
        num1 = (float) this.BerkraneJobBestTime;
      if (Heist == 13)
        num1 = (float) this.DiamondHeistBestTime;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      string str = "";
      if (Heist == 1)
      {
        str = "The Fleeca Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 2)
      {
        str = "The Paleto Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 3)
      {
        str = "The Pacific Standard";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 4)
      {
        str = "The Jewel Store Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 5)
      {
        str = "The Union Depository";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 6)
      {
        str = "USS Luxington Raid";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 7)
      {
        str = "Surver Down Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 8)
      {
        str = "The Nuclear Expansion";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 9)
      {
        str = "Deep Deapths Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 10)
      {
        str = "Humane Labs #2";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 11)
      {
        str = "The Yacht Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 12)
      {
        str = "The Belkrane Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 13)
      {
        str = "The Diamond Casino Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      bool flag = false;
      if ((double) num1 < (double) num4)
        flag = true;
      if ((double) num1 > (double) num4)
        flag = false;
      return flag;
    }

    public bool GetBronze(int Heist)
    {
      this.LoadIniFile("scripts//Payday.ini");
      float num1 = 0.0f;
      if (Heist == 1)
        num1 = (float) this.FleecaBestTime;
      if (Heist == 2)
        num1 = (float) this.PaletoBestTime;
      if (Heist == 3)
        num1 = (float) this.PacificStandardBestTime;
      if (Heist == 4)
        num1 = (float) this.VangelicoBestTime;
      if (Heist == 5)
        num1 = (float) this.UnionDelpositioryBestTime;
      if (Heist == 6)
        num1 = (float) this.LEXIGTONRAIDBestTime;
      if (Heist == 7)
        num1 = (float) this.SURVERDOWNBestTime;
      if (Heist == 8)
        num1 = (float) this.NUCLEAREXPANSIONHEISTBestTime;
      if (Heist == 9)
        num1 = (float) this.DEEPDEAPTHSHEISTBestTime;
      if (Heist == 10)
        num1 = (float) this.HUMANELABS2BestTime;
      if (Heist == 11)
        num1 = (float) this.YachtHeistBestTime;
      if (Heist == 12)
        num1 = (float) this.BerkraneJobBestTime;
      if (Heist == 13)
        num1 = (float) this.DiamondHeistBestTime;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      string str = "";
      if (Heist == 1)
      {
        str = "The Fleeca Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 2)
      {
        str = "The Paleto Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 3)
      {
        str = "The Pacific Standard";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 4)
      {
        str = "The Jewel Store Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 5)
      {
        str = "The Union Depository";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 6)
      {
        str = "USS Luxington Raid";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 7)
      {
        str = "Surver Down Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 8)
      {
        str = "The Nuclear Expansion";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 9)
      {
        str = "Deep Deapths Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 10)
      {
        str = "Humane Labs #2";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 11)
      {
        str = "The Yacht Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 12)
      {
        str = "The Belkrane Job";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      if (Heist == 13)
      {
        str = "The Diamond Casino Heist";
        num2 = this.GetTimeBronze(Heist);
        num3 = this.GetTimeGold(Heist);
        num4 = this.GetTimeSilver(Heist);
      }
      bool flag = false;
      if ((double) num1 < (double) num2)
        flag = true;
      if ((double) num1 > (double) num2)
        flag = false;
      return flag;
    }

    public void GetHeistTimes(int Heist)
    {
      this.LoadIniFile("scripts//Payday.ini");
      string caption = "";
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (Heist == 1)
      {
        caption = "The Fleeca Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 2)
      {
        caption = "The Paleto Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 3)
      {
        caption = "The Pacific Standard";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 4)
      {
        caption = "The Jewel Store Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 5)
      {
        caption = "The Union Depository";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 6)
      {
        caption = "USS Luxington Raid";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 7)
      {
        caption = "Surver Down Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 8)
      {
        caption = "The Nuclear Expansion";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 9)
      {
        caption = "Deep Deapths Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 10)
      {
        caption = "Humane Labs #2";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 11)
      {
        caption = "The Yacht Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 12)
      {
        caption = "The Belkrane Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 13)
      {
        caption = "The Diamond Casino Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 1020), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText(caption, new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 199, 168, 87), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      string textureName = "goldmedal";
      TimeSpan timeSpan1 = TimeSpan.FromSeconds((double) num2 / 10.5);
      new Sprite("mpmissionend", textureName, new Point(int32 - 300, 300), new Size(46, 46)).Draw();
      new UIResText(timeSpan1.ToString("hh':'mm':'ss") ?? "", new Point(int32 - 200, 301), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      TimeSpan timeSpan2 = TimeSpan.FromSeconds((double) num3 / 10.5);
      new Sprite("mpmissionend", "silvermedal", new Point(int32 - 100, 300), new Size(46, 46)).Draw();
      new UIResText(timeSpan2.ToString("hh':'mm':'ss") ?? "", new Point(int32, 301), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      TimeSpan timeSpan3 = TimeSpan.FromSeconds((double) num1 / 10.5);
      new Sprite("mpmissionend", "bronzemedal", new Point(int32 + 100, 300), new Size(46, 46)).Draw();
      new UIResText(timeSpan3.ToString("hh':'mm':'ss") ?? "", new Point(int32 + 200, 301), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      if (Heist == 1)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "FLEECA", this.BestTime);
      if (Heist == 2)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "PALETO", this.BestTime);
      if (Heist == 3)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "PACIFICSTANDARD", this.BestTime);
      if (Heist == 4)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "VANGELICO", this.BestTime);
      if (Heist == 5)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "UNIONDEPOSITORY", this.BestTime);
      if (Heist == 6)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "LEXIGTONRAID", this.BestTime);
      if (Heist == 7)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "SURVERDOWN", this.BestTime);
      if (Heist == 8)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "NUCLEAREXPANSIONHEIST", this.BestTime);
      if (Heist == 9)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "DEEPDEAPTHSHEIST", this.BestTime);
      if (Heist == 10)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "HUMANELABS#2", this.BestTime);
      if (Heist == 11)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "YachtHeist", this.BestTime);
      if (Heist == 12)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "BerkraneJob", this.BestTime);
      if (Heist == 13)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "DiamondHeist", this.BestTime);
      if (this.BestTime < num1)
        new UIResText("Current   :   " + TimeSpan.FromSeconds((double) this.BestTime / 10.5).ToString("hh':'mm':'ss"), new Point(int32, 360), 0.65f, Color.White, GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      if (this.BestTime > num1)
        new UIResText("Current   :  No Qaulifying Time", new Point(int32, 360), 0.65f, Color.White, GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void DisplayTime(float Time)
    {
      float num = Time / 10.5f;
      this.Fail = false;
      this.Pass = true;
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width + 200f), 100), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Time " + TimeSpan.FromSeconds((double) num).ToString(), new Point(int32 + 500, 30), 0.65f, Color.White, GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      new UIResText("Hold Shift then press X to Disable Popup", new Point(int32 + 500, 70), 0.35f, Color.White, GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void SetFailSetup(string MissionName, string Reason, int Heist)
    {
      Audio.SetAudioFlag("LoadMPData", true);
      Audio.PlaySoundFrontend("Bed", "WastedSounds");
      Audio.SetAudioFlag("LoadMPData", false);
      this.Timer = 300;
      this.m = MissionName;
      this.r = Reason;
      this.H = Heist;
      this.FailSetup = true;
      this.PassSetup = false;
      for (int index = 0; index < 300; ++index)
      {
        if (this.FailSetup)
          this.MissionFailedSetup(this.m, this.r, this.H);
        if (this.PassSetup)
          this.MissionPassedSetup(this.m, this.H);
        Script.Wait(1);
      }
    }

    public void SetPassSetup(string MissionName, string Reason, int Heist)
    {
      Audio.SetAudioFlag("LoadMPData", true);
      Audio.PlaySoundFrontend("Mission_Pass_Notify", "DLC_HEISTS_GENERAL_FRONTEND_SOUNDS");
      Audio.SetAudioFlag("LoadMPData", false);
      this.Timer = 300;
      this.m = MissionName;
      this.r = Reason;
      this.H = Heist;
      this.FailSetup = false;
      this.PassSetup = true;
      for (int index = 0; index < 300; ++index)
      {
        if (this.FailSetup)
          this.MissionFailedSetup(this.m, this.r, this.H);
        if (this.PassSetup)
          this.MissionPassedSetup(this.m, this.H);
        Script.Wait(1);
      }
    }

    public int GetTimeGold(int Heist)
    {
      string str = "";
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (Heist == 1)
      {
        str = "The Fleeca Heist";
        num1 = 15500;
        num2 = 7200;
        num3 = 12500;
      }
      if (Heist == 2)
      {
        str = "The Paleto Job";
        num1 = 25000;
        num2 = 14500;
        num3 = 22000;
      }
      if (Heist == 3)
      {
        str = "The Pacific Standard";
        num1 = 22000;
        num2 = 10500;
        num3 = 16500;
      }
      if (Heist == 4)
      {
        str = "The Jewel Store Job";
        num1 = 34000;
        num2 = 14000;
        num3 = 23000;
      }
      if (Heist == 5)
      {
        str = "The Union Depository";
        num1 = 22000;
        num2 = 13500;
        num3 = 17000;
      }
      if (Heist == 6)
      {
        str = "USS Luxington Raid";
        num1 = 26000;
        num2 = 19500;
        num3 = 23000;
      }
      if (Heist == 7)
      {
        str = "Surver Down Heist";
        num1 = 31000;
        num2 = 18500;
        num3 = 23000;
      }
      if (Heist == 8)
      {
        str = "The Nuclear Expansion";
        num1 = 41000;
        num2 = 27750;
        num3 = 32000;
      }
      if (Heist == 9)
      {
        str = "Deep Deapths Heist";
        num1 = 26000;
        num2 = 15500;
        num3 = 22000;
      }
      if (Heist == 10)
      {
        str = "Humane Labs #2";
        num1 = 29000;
        num2 = 17500;
        num3 = 22000;
      }
      if (Heist == 11)
      {
        str = "The Yacht Heist";
        num1 = 30000;
        num2 = 20500;
        num3 = 24000;
      }
      if (Heist == 12)
      {
        str = "The Belkrane Job";
        num1 = 28000;
        num2 = 8500;
        num3 = 18000;
      }
      if (Heist == 13)
      {
        str = "The Diamond Casino Heist";
        num1 = 28000;
        num2 = 17500;
        num3 = 24000;
      }
      return num2;
    }

    public int GetTimeSilver(int Heist)
    {
      string str = "";
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (Heist == 1)
      {
        str = "The Fleeca Heist";
        num1 = 15500;
        num2 = 7200;
        num3 = 12500;
      }
      if (Heist == 2)
      {
        str = "The Paleto Job";
        num1 = 25000;
        num2 = 14500;
        num3 = 22000;
      }
      if (Heist == 3)
      {
        str = "The Pacific Standard";
        num1 = 22000;
        num2 = 10500;
        num3 = 16500;
      }
      if (Heist == 4)
      {
        str = "The Jewel Store Job";
        num1 = 34000;
        num2 = 14000;
        num3 = 23000;
      }
      if (Heist == 5)
      {
        str = "The Union Depository";
        num1 = 22000;
        num2 = 13500;
        num3 = 17000;
      }
      if (Heist == 6)
      {
        str = "USS Luxington Raid";
        num1 = 26000;
        num2 = 19500;
        num3 = 23000;
      }
      if (Heist == 7)
      {
        str = "Surver Down Heist";
        num1 = 31000;
        num2 = 18500;
        num3 = 23000;
      }
      if (Heist == 8)
      {
        str = "The Nuclear Expansion";
        num1 = 41000;
        num2 = 27750;
        num3 = 32000;
      }
      if (Heist == 9)
      {
        str = "Deep Deapths Heist";
        num1 = 26000;
        num2 = 15500;
        num3 = 22000;
      }
      if (Heist == 10)
      {
        str = "Humane Labs #2";
        num1 = 29000;
        num2 = 17500;
        num3 = 22000;
      }
      if (Heist == 11)
      {
        str = "The Yacht Heist";
        num1 = 30000;
        num2 = 20500;
        num3 = 24000;
      }
      if (Heist == 12)
      {
        str = "The Belkrane Job";
        num1 = 28000;
        num2 = 8500;
        num3 = 18000;
      }
      if (Heist == 13)
      {
        str = "The Diamond Casino Heist";
        num1 = 28000;
        num2 = 17500;
        num3 = 24000;
      }
      return num3;
    }

    public int GetTimeBronze(int Heist)
    {
      string str = "";
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (Heist == 1)
      {
        str = "The Fleeca Heist";
        num1 = 15500;
        num2 = 7200;
        num3 = 12500;
      }
      if (Heist == 2)
      {
        str = "The Paleto Job";
        num1 = 25000;
        num2 = 14500;
        num3 = 22000;
      }
      if (Heist == 3)
      {
        str = "The Pacific Standard";
        num1 = 22000;
        num2 = 10500;
        num3 = 16500;
      }
      if (Heist == 4)
      {
        str = "The Jewel Store Job";
        num1 = 34000;
        num2 = 14000;
        num3 = 23000;
      }
      if (Heist == 5)
      {
        str = "The Union Depository";
        num1 = 22000;
        num2 = 13500;
        num3 = 17000;
      }
      if (Heist == 6)
      {
        str = "USS Luxington Raid";
        num1 = 26000;
        num2 = 19500;
        num3 = 23000;
      }
      if (Heist == 7)
      {
        str = "Surver Down Heist";
        num1 = 31000;
        num2 = 18500;
        num3 = 23000;
      }
      if (Heist == 8)
      {
        str = "The Nuclear Expansion";
        num1 = 41000;
        num2 = 27750;
        num3 = 32000;
      }
      if (Heist == 9)
      {
        str = "Deep Deapths Heist";
        num1 = 26000;
        num2 = 15500;
        num3 = 22000;
      }
      if (Heist == 10)
      {
        str = "Humane Labs #2";
        num1 = 29000;
        num2 = 17500;
        num3 = 22000;
      }
      if (Heist == 11)
      {
        str = "The Yacht Heist";
        num1 = 30000;
        num2 = 20500;
        num3 = 24000;
      }
      if (Heist == 12)
      {
        str = "The Belkrane Job";
        num1 = 28000;
        num2 = 8500;
        num3 = 18000;
      }
      if (Heist == 13)
      {
        str = "The Diamond Casino Heist";
        num1 = 28000;
        num2 = 17500;
        num3 = 24000;
      }
      return num1;
    }

    public void MissionPassed(
      string MissionName,
      int Payout,
      int CrewCut,
      int CrewAlive,
      float Time,
      int Heist)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      float num4 = Time / 10.5f;
      if (Heist == 1)
      {
        MissionName = "The Fleeca Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 2)
      {
        MissionName = "The Paleto Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 3)
      {
        MissionName = "The Pacific Standard";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 4)
      {
        MissionName = "The Jewel Store Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 5)
      {
        MissionName = "The Union Depository";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 6)
      {
        MissionName = "USS Luxington Raid";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 7)
      {
        MissionName = "Surver Down Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 8)
      {
        MissionName = "The Nuclear Expansion";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 9)
      {
        MissionName = "Deep Deapths Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 10)
      {
        MissionName = "Humane Labs #2";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 11)
      {
        MissionName = "The Yacht Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 12)
      {
        MissionName = "The Belkrane Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 13)
      {
        MissionName = "The Diamond Casino Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      string textureName1 = "bronzemedal";
      this.Fail = false;
      this.Pass = true;
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 1020), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("mission passed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 199, 168, 87), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      new UIResText(MissionName, new Point(int32, 230), 1.25f, Color.White, GTA.Font.HouseScript, UIResText.Alignment.Centered).Draw();
      new UIResText("Player Cut : $" + Payout.ToString("N"), new Point(int32, 330), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      new UIResText("Crew Cut $" + CrewCut.ToString("N"), new Point(int32, 400), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      switch (CrewAlive)
      {
        case 3:
          textureName1 = "silvermedal";
          break;
        case 4:
          textureName1 = "goldmedal";
          break;
      }
      new Sprite("mpmissionend", textureName1, new Point(int32 - 180, 470), new Size(46, 46)).Draw();
      new UIResText("Crew Alive : " + CrewAlive.ToString() + "/4", new Point(int32, 471), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      if ((double) Time <= (double) num1)
        textureName1 = "bronzemedal";
      if ((double) Time <= (double) num3)
        textureName1 = "silvermedal";
      if ((double) Time <= (double) num2)
        textureName1 = "goldmedal";
      TimeSpan timeSpan1 = TimeSpan.FromSeconds((double) num4);
      new Sprite("mpmissionend", textureName1, new Point(int32 - 180, 551), new Size(46, 46)).Draw();
      new UIResText("Time : " + timeSpan1.ToString("hh':'mm':'ss"), new Point(int32, 550), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      float num5 = (float) num1 / 10.5f;
      float num6 = (float) num2 / 10.5f;
      float num7 = (float) num3 / 10.5f;
      string textureName2 = "goldmedal";
      TimeSpan timeSpan2 = TimeSpan.FromSeconds((double) num2 / 10.5);
      new Sprite("mpmissionend", textureName2, new Point(int32 - 300, 619), new Size(46, 46)).Draw();
      new UIResText(timeSpan2.ToString("hh':'mm':'ss") ?? "", new Point(int32 - 200, 620), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      TimeSpan timeSpan3 = TimeSpan.FromSeconds((double) num3 / 10.5);
      new Sprite("mpmissionend", "silvermedal", new Point(int32 - 100, 619), new Size(46, 46)).Draw();
      new UIResText(timeSpan3.ToString("hh':'mm':'ss") ?? "", new Point(int32, 620), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      TimeSpan timeSpan4 = TimeSpan.FromSeconds((double) num1 / 10.5);
      string textureName3 = "bronzemedal";
      new Sprite("mpmissionend", textureName3, new Point(int32 + 100, 619), new Size(46, 46)).Draw();
      new UIResText(timeSpan4.ToString("hh':'mm':'ss") ?? "", new Point(int32 + 200, 620), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      if (Heist == 1)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "FLEECA", this.BestTime);
      if (Heist == 2)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "PALETO", this.BestTime);
      if (Heist == 3)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "PACIFICSTANDARD", this.BestTime);
      if (Heist == 4)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "VANGELICO", this.BestTime);
      if (Heist == 5)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "UNIONDEPOSITORY", this.BestTime);
      if (Heist == 6)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "LEXIGTONRAID", this.BestTime);
      if (Heist == 7)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "SURVERDOWN", this.BestTime);
      if (Heist == 8)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "NUCLEAREXPANSIONHEIST", this.BestTime);
      if (Heist == 9)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "DEEPDEAPTHSHEIST", this.BestTime);
      if (Heist == 10)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "HUMANELABS#2", this.BestTime);
      if (Heist == 11)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "YachtHeist", this.BestTime);
      if (Heist == 12)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "BerkraneJob", this.BestTime);
      if (Heist == 13)
        this.BestTime = this.Config.GetValue<int>("BEST_TIMES", "DiamondHeist", this.BestTime);
      TimeSpan timeSpan5 = TimeSpan.FromSeconds((double) this.BestTime / 10.5);
      if ((double) Time <= (double) num1)
        textureName3 = "bronzemedal";
      if ((double) Time <= (double) num3)
        textureName3 = "silvermedal";
      if ((double) Time <= (double) num2)
        textureName3 = "goldmedal";
      if (this.BestTime < this.GetTimeBronze(Heist))
      {
        if ((double) Time >= (double) this.BestTime)
        {
          new Sprite("mpmissionend", textureName3, new Point(int32 - 180, 719), new Size(46, 46)).Draw();
          new UIResText("Best : " + timeSpan5.ToString("hh':'mm':'ss"), new Point(int32, 720), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
        }
        if ((double) Time < (double) this.BestTime)
        {
          new Sprite("mpmissionend", textureName3, new Point(int32 - 180, 719), new Size(46, 46)).Draw();
          new UIResText("Best : " + timeSpan1.ToString("hh':'mm':'ss"), new Point(int32, 720), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
        }
      }
      if (this.BestTime > this.GetTimeBronze(Heist))
        new UIResText("Best :  No Qualifying Time", new Point(int32, 720), 0.5f, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void MissionFailed(
      string Reason,
      string MissionName,
      int CrewCut,
      int CrewAlive,
      float Time,
      int Heist)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      float num4 = Time / 10.5f;
      if (Heist == 1)
      {
        MissionName = "The Fleeca Heist";
        num1 = 18500;
        num2 = 9900;
        num3 = 14500;
      }
      if (Heist == 2)
      {
        MissionName = "The Paleto Job";
        num1 = 42000;
        num2 = 26500;
        num3 = 35000;
      }
      if (Heist == 3)
      {
        MissionName = "The Pacific Standard";
        num1 = 36000;
        num2 = 22500;
        num3 = 28000;
      }
      if (Heist == 4)
      {
        MissionName = "The Jewel Store Job";
        num1 = 28000;
        num2 = 7500;
        num3 = 18000;
      }
      if (Heist == 5)
      {
        MissionName = "The Union Depository";
        num1 = 90000;
        num2 = 25500;
        num3 = 36000;
      }
      if (Heist == 6)
      {
        MissionName = "USS Luxington Raid";
        num1 = 26000;
        num2 = 19500;
        num3 = 23000;
      }
      if (Heist == 7)
      {
        MissionName = "Surver Down Heist";
        num1 = 31000;
        num2 = 18500;
        num3 = 23000;
      }
      if (Heist == 8)
      {
        MissionName = "The Nuclear Expansion";
        num1 = 28000;
        num2 = 14750;
        num3 = 20000;
      }
      if (Heist == 9)
      {
        MissionName = "Deep Deapths Heist";
        num1 = 32000;
        num2 = 22500;
        num3 = 27000;
      }
      if (Heist == 10)
      {
        MissionName = "Humane Labs #2";
        num1 = 29000;
        num2 = 17500;
        num3 = 22000;
      }
      if (Heist == 11)
      {
        MissionName = "The Yacht Heist";
        num1 = 30000;
        num2 = 20500;
        num3 = 24000;
      }
      if (Heist == 12)
      {
        MissionName = "The Belkrane Job";
        num1 = 36000;
        num2 = 18500;
        num3 = 25000;
      }
      if (Heist == 13)
      {
        MissionName = "The Diamond Casino Heist";
        num1 = 42000;
        num2 = 22500;
        num3 = 17000;
      }
      this.Pass = false;
      this.Fail = true;
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 30), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 450), 0.0f, Color.FromArgb(230, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("mission failed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 148, 27, 46), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      new UIResText(MissionName, new Point(int32, 230), 1.25f, Color.White, GTA.Font.HouseScript, UIResText.Alignment.Centered).Draw();
      new UIResText("Reason : " + Reason, new Point(int32, 310), 0.5f, Color.White, GTA.Font.ChaletComprimeCologne, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void MissionPassedSetup(string MissionName, int Heist)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (Heist == 1)
      {
        MissionName = "The Fleeca Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 2)
      {
        MissionName = "The Paleto Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 3)
      {
        MissionName = "The Pacific Standard";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 4)
      {
        MissionName = "The Jewel Store Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 5)
      {
        MissionName = "The Union Depository";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 6)
      {
        MissionName = "USS Luxington Raid";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 7)
      {
        MissionName = "Surver Down Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 8)
      {
        MissionName = "The Nuclear Expansion";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 9)
      {
        MissionName = "Deep Deapths Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 10)
      {
        MissionName = "Humane Labs #2";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 11)
      {
        MissionName = "The Yacht Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 12)
      {
        MissionName = "The Belkrane Job";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      if (Heist == 13)
      {
        MissionName = "The Diamond Casino Heist";
        num1 = this.GetTimeBronze(Heist);
        num2 = this.GetTimeGold(Heist);
        num3 = this.GetTimeSilver(Heist);
      }
      this.Fail = false;
      this.Pass = true;
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 10), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 350), 0.0f, Color.FromArgb(200, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Setup passed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 199, 168, 87), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      new UIResText(MissionName, new Point(int32, 230), 1.25f, Color.White, GTA.Font.HouseScript, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void MissionFailedSetup(string MissionName, string Reason, int Heist)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (Heist == 1)
      {
        MissionName = "The Fleeca Heist";
        num1 = 18500;
        num2 = 9900;
        num3 = 14500;
      }
      if (Heist == 2)
      {
        MissionName = "The Paleto Job";
        num1 = 42000;
        num2 = 26500;
        num3 = 35000;
      }
      if (Heist == 3)
      {
        MissionName = "The Pacific Standard";
        num1 = 36000;
        num2 = 22500;
        num3 = 28000;
      }
      if (Heist == 4)
      {
        MissionName = "The Jewel Store Job";
        num1 = 28000;
        num2 = 7500;
        num3 = 18000;
      }
      if (Heist == 5)
      {
        MissionName = "The Union Depository";
        num1 = 90000;
        num2 = 25500;
        num3 = 36000;
      }
      if (Heist == 6)
      {
        MissionName = "USS Luxington Raid";
        num1 = 35000;
        num2 = 17500;
        num3 = 24000;
      }
      if (Heist == 7)
      {
        MissionName = "Surver Down Heist";
        num1 = 35000;
        num2 = 16500;
        num3 = 24000;
      }
      if (Heist == 8)
      {
        MissionName = "The Nuclear Expansion";
        num1 = 35000;
        num2 = 16500;
        num3 = 24000;
      }
      if (Heist == 9)
      {
        MissionName = "Deep Deapths Heist";
        num1 = 35000;
        num2 = 16500;
        num3 = 24000;
      }
      if (Heist == 10)
      {
        MissionName = "Humane Labs #2";
        num1 = 35000;
        num2 = 16500;
        num3 = 24000;
      }
      if (Heist == 9)
      {
        MissionName = "Surver Down Heist";
        num1 = 35000;
        num2 = 16500;
        num3 = 24000;
      }
      if (Heist == 10)
      {
        MissionName = "Humane Labs #2";
        num1 = 35000;
        num2 = 16500;
        num3 = 24000;
      }
      if (Heist == 11)
      {
        MissionName = "The Yacht Heist";
        num1 = 35000;
        num2 = 21500;
        num3 = 15000;
      }
      if (Heist == 12)
      {
        MissionName = "The Belkrane Job";
        num1 = 42000;
        num2 = 22500;
        num3 = 17000;
      }
      this.Pass = false;
      this.Fail = true;
      SizeF resolutionMantainRatio = UIMenu.GetScreenResolutionMantainRatio();
      int int32 = Convert.ToInt32(resolutionMantainRatio.Width / 2f);
      new Sprite("mpentry", "mp_modenotselected_gradient", new Point(0, 30), new Size(Convert.ToInt32(resolutionMantainRatio.Width), 450), 0.0f, Color.FromArgb(230, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue)).Draw();
      new UIResText("Setup failed", new Point(int32, 100), 2.5f, Color.FromArgb((int) byte.MaxValue, 148, 27, 46), GTA.Font.Pricedown, UIResText.Alignment.Centered).Draw();
      new UIResText(MissionName, new Point(int32, 230), 1.25f, Color.White, GTA.Font.HouseScript, UIResText.Alignment.Centered).Draw();
      new UIResText("Reason : " + Reason, new Point(int32, 310), 0.5f, Color.White, GTA.Font.ChaletComprimeCologne, UIResText.Alignment.Centered).Draw();
      Scaleform scaleform = new Scaleform(0);
      scaleform.Load("instructional_buttons");
      scaleform.Render2D();
    }

    public void SetFail(string MissionName, int Payout, string Reason)
    {
      Audio.SetAudioFlag("LoadMPData", true);
      Audio.PlaySoundFrontend("Bed", "WastedSounds");
      Audio.SetAudioFlag("LoadMPData", false);
      this.Timer = 300;
      this.m = MissionName;
      this.p = Payout;
      this.r = Reason;
      this.Fail = true;
      for (int index = 0; index < 100; ++index)
      {
        if (this.Fail)
          this.MissionFailed(this.r, this.m);
        if (this.Pass)
          this.MissionPassed(this.m, this.p);
        Script.Wait(1);
      }
    }

    public void SetPass(string MissionName, int Payout, string Reason)
    {
      Audio.SetAudioFlag("LoadMPData", true);
      Audio.PlaySoundFrontend("Mission_Pass_Notify", "DLC_HEISTS_GENERAL_FRONTEND_SOUNDS");
      Audio.SetAudioFlag("LoadMPData", false);
      this.Timer = 300;
      this.m = MissionName;
      this.p = Payout;
      this.r = Reason;
      this.Pass = true;
      for (int index = 0; index < 100; ++index)
      {
        if (this.Fail)
          this.MissionFailed(this.r, this.m);
        if (this.Pass)
          this.MissionPassed(this.m, this.p);
        Script.Wait(1);
      }
    }

    public MissionScreen() => this.Tick += new EventHandler(this.OnTick);

    public void OnTick(object sender, EventArgs e)
    {
      if (this.Timer < 0)
        return;
      --this.Timer;
    }
  }
}
