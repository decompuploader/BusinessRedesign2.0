using GTA;

namespace DRaC_Business
{
  public class PlayerCards : Script
  {
    public Prop Card1 { get; set; }

    public Prop Card2 { get; set; }

    public Prop Card3 { get; set; }

    public string Card1ID { get; set; }

    public string Card2ID { get; set; }

    public string Card3ID { get; set; }

    public PlayerCards(Prop C1, Prop C2, Prop C3, string _1ID, string _2ID, string _3ID)
    {
      this.Card1 = C1;
      this.Card2 = C2;
      this.Card3 = C3;
      this.Card1ID = _1ID;
      this.Card2ID = _2ID;
      this.Card3ID = _3ID;
    }
  }
}
