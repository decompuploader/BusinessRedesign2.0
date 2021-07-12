using GTA;
using GTA.Math;

namespace HKH191SBusinessHelper
{
  public class Bed : Script
  {
    public Vector3 Pos { get; set; }

    public float Hed { get; set; }

    public Bed(Vector3 Position, float Heading)
    {
      this.Pos = Position;
      this.Hed = Heading;
    }
  }
}
