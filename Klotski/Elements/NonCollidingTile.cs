using Klotski.Helpers;

namespace Klotski.Elements
{
    public class NonCollidingTile : TileBase
    {
        public override Line[] Boundary => new Line[0];
    }
}