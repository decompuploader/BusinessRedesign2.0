using GTA;
using System;

namespace HKH191SBusinessHelper
{
  public class LoadFile : Script
  {
    private ScriptSettings Config;

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: " + iniName + " Failed To Load.");
      }
    }

    public void Open(string Ini, bool LastFile) => this.LoadIniFile(Ini);

    public void WriteValue(string header, string Variable, string Value)
    {
      this.Config.SetValue<string>(header, Variable, Value);
      this.Config.Save();
    }
  }
}
