using Klotski;
using Klotski.Elements;

namespace Ricochet.Levels
{
    public class Level1 : LevelBase
    {
        private const string Pipes1 = "pipes1.png";
        private const string Checker2 = "checker2.png";
        private const string Bricks2 = "bricks2.png";
        private const string Bricks2TriangleBottomLeft = "bricks2_triangle_bottom_left.png";
        private const string Bricks2TriangleBottomRight = "bricks2_triangle_bottom_right.png";
        private const string Bricks2TriangleTopRight = "bricks2_triangle_top_right.png";

        public Level1()
        {
            var screen1 = new Screen();

            // row 1
            screen1.AddTile(new Tile(0, 0, Pipes1));
            screen1.AddTile(new Tile(1, 0, Pipes1));
            screen1.AddTile(new Tile(2, 0, Checker2));
            screen1.AddTile(new Tile(5, 0, Bricks2));
            screen1.AddTile(new Tile(6, 0, Bricks2));
            screen1.AddTile(new Tile(7, 0, Bricks2));
            screen1.AddTile(new Tile(8, 0, Bricks2));
            screen1.AddTile(new Tile(9, 0, Bricks2));
            screen1.AddTile(new Tile(10, 0, Bricks2));
            screen1.AddTile(new Tile(11, 0, Bricks2));
            screen1.AddTile(new Tile(12, 0, Bricks2));

            // row 2
            screen1.AddTile(new Tile(0, 1, Checker2));
            screen1.AddTile(new Tile(1, 1, Checker2));
            screen1.AddTile(new Tile(2, 1, Checker2));
            screen1.AddTile(new Tile(8, 1, Bricks2TriangleBottomRight));
            screen1.AddTile(new Tile(9, 1, Bricks2));
            screen1.AddTile(new Tile(10, 1, Bricks2));
            screen1.AddTile(new Tile(11, 1, Bricks2));
            screen1.AddTile(new Tile(12, 1, Bricks2));

            // row 3
            screen1.AddTile(new Tile(2, 2, Checker2));
            screen1.AddTile(new Tile(9, 2, Bricks2));
            screen1.AddTile(new Tile(10, 2, Bricks2));
            screen1.AddTile(new Tile(11, 2, Bricks2));
            screen1.AddTile(new Tile(12, 2, Bricks2));

            // row 4
            screen1.AddTile(new Tile(2, 3, Checker2));
            screen1.AddTile(new Tile(3, 3, Checker2));
            screen1.AddTile(new Tile(4, 3, Checker2));
            screen1.AddTile(new Tile(5, 3, Checker2));
            screen1.AddTile(new Tile(6, 3, Checker2));
            screen1.AddTile(new Tile(9, 3, Bricks2));
            screen1.AddTile(new Tile(10, 3, Bricks2TriangleBottomLeft));

            // row 7
            screen1.AddTile(new Tile(11, 6, Bricks2TriangleTopRight));
            screen1.AddTile(new Tile(12, 6, Bricks2));

            // row 8
            screen1.AddTile(new Tile(2, 7, Checker2));
            screen1.AddTile(new Tile(10, 7, Bricks2TriangleTopRight));
            screen1.AddTile(new Tile(11, 7, Bricks2));
            screen1.AddTile(new Tile(12, 7, Bricks2));

            // row 9
            screen1.AddTile(new Tile(0, 8, Checker2));
            screen1.AddTile(new Tile(1, 8, Checker2));
            screen1.AddTile(new Tile(2, 8, Pipes1));
            screen1.AddTile(new Tile(3, 8, Checker2));
            screen1.AddTile(new Tile(4, 8, Checker2));
            screen1.AddTile(new Tile(5, 8, Checker2));
            screen1.AddTile(new Tile(8, 8, Bricks2));
            screen1.AddTile(new Tile(9, 8, Bricks2));
            screen1.AddTile(new Tile(10, 8, Bricks2));
            screen1.AddTile(new Tile(11, 8, Bricks2));
            screen1.AddTile(new Tile(12, 8, Bricks2));

            Screens.Add(screen1);
        }
    }
}