using GTA;
using NativeUI;
using System;
using System.Drawing;

namespace MethBuisness
{
  internal class MissionScreen : Script
  {
    public bool Fail;
    public bool Pass;
    public string m;
    public int p;
    public string r;
    public int Timer;

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
