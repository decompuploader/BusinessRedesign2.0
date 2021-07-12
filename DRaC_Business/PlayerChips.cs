using GTA;

namespace DRaC_Business
{
  public class PlayerChips : Script
  {
    public Prop Chips1 { get; set; }

    public Prop Chips2 { get; set; }

    public Prop Chips3 { get; set; }

    public Prop Chips4 { get; set; }

    public PlayerChips(Prop C1, Prop C2, Prop C3, Prop C4)
    {
      this.Chips1 = C1;
      this.Chips2 = C2;
      this.Chips3 = C3;
      this.Chips4 = C4;
    }
  }
}
