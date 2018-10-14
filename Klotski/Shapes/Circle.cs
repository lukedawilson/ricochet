using System;
using Klotski.Helpers;
using Point = Microsoft.Xna.Framework.Point;

namespace Klotski.Shapes
{
    public struct Circle
    {
        private readonly double _x;
        private readonly double _y;
        private readonly double _radius;

        public Circle(double x, double y, double radius)
        {
            _x = x;
            _y = y;
            _radius = radius;
        }

        public bool Intersects(Line[] sides)
        {
            foreach (var side in sides)
            {
                var dist = MinimumDistance(_x, _y, side.X1, side.Y1, side.X2, side.Y2);
                if (dist <= _radius)
                {
                    return true;
                }
            }

            return false;
        }

        // https://stackoverflow.com/a/6853926/3645045
        private static double MinimumDistance(
            double pointX, double pointY,
            double lineX1, double lineY1,
            double lineX2, double lineY2)
        {
            var a = pointX - lineX1;
            var b = pointY - lineY1;
            var c = lineX2 - lineX1;
            var d = lineY2 - lineY1;

            var dot = a * c + b * d;
            var lenSq = c * c + d * d;
            var param = dot / lenSq;

            double xx, yy;
            if (param < 0)
            {
                xx = lineX1;
                yy = lineY1;
            }
            else if (param > 1)
            {
                xx = lineX2;
                yy = lineY2;
            }
            else
            {
                xx = lineX1 + param * c;
                yy = lineY1 + param * d;
            }

            var dx = pointX - xx;
            var dy = pointY - yy;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}