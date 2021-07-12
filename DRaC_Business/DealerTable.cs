using GTA;
using GTA.Math;

namespace DRaC_Business
{
  public class DealerTable : Script
  {
    public bool CreatedDealer { get; set; }

    public Vector3 DealerOriginPosition { get; set; }

    public float DealerOriginHeading { get; set; }

    public Prop Card1 { get; set; }

    public Prop Card2 { get; set; }

    public Prop Card3 { get; set; }

    public string Card1Id { get; set; }

    public string Card2Id { get; set; }

    public string Card3Id { get; set; }

    public int Card1num { get; set; }

    public int Card2num { get; set; }

    public int Card3num { get; set; }

    public Prop Table { get; set; }

    public Ped Dealer { get; set; }

    public DealerTable()
    {
    }

    public DealerTable(Prop T, Ped D)
    {
      this.Table = T;
      this.Dealer = D;
    }

    public DealerTable(Prop T) => this.Table = T;
  }
}
