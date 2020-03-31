using Klotski.Helpers;

namespace Klotski.Elements
{
    public class BottomRightTriangleTile : TileBase
    {
        public override Line[] Boundary => new[]
        {
            new Line(Position.Right, Screen.Height*TileDimension - Position.Top, Position.Right, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Right, Screen.Height*TileDimension - Position.Bottom, Position.Left, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Left, Screen.Height*TileDimension - Position.Bottom, Position.Right, Screen.Height*TileDimension - Position.Top)
        };
    }
}