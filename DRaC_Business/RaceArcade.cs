using GTA;

namespace DRaC_Business
{
  public class RaceArcade : Script
  {
    public Prop Base { get; set; }

    public Prop Seat1 { get; set; }

    public Prop Seat2 { get; set; }

    public string Decleration { get; set; }

    public RaceArcade(Prop Abase, Prop Aseat1, Prop Aseat2, string decleration)
    {
      this.Base = Abase;
      this.Seat1 = Aseat1;
      this.Seat2 = Aseat2;
      this.Decleration = decleration;
    }
  }
}
