using GTA;
using GTA.Math;

namespace DRaC_Business
{
  public class SlotsClass : Script
  {
    public Vector3 Loc { get; set; }

    public float Heading { get; set; }

    public string Machine { get; set; }

    public Prop MachineProp { get; set; }

    public Ped SlotPed { get; set; }

    public bool In_use { get; set; }

    public int SlotSyncedScene { get; set; }

    public SlotsClass(Vector3 L, float H, string m)
    {
      this.Loc = L;
      this.Heading = H;
      this.Machine = m;
    }
  }
}
