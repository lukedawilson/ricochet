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
            Screens.Add(Screen1());
            Screens.Add(Screen2());
            Screens.Add(Screen3());
            Screens.Add(Screen4());

            CurrentScreenIndex = 0;
        }

        private static Screen Screen1()
        {
            var screen = new Screen();

            // row 1
            screen.AddTile(new SquareTile(0, 0, Pipes1));
            screen.AddTile(new SquareTile(1, 0, Pipes1));
            screen.AddTile(new SquareTile(2, 0, Checker2));
            screen.AddTile(new SquareTile(5, 0, Bricks2));
            screen.AddTile(new SquareTile(6, 0, Bricks2));
            screen.AddTile(new SquareTile(7, 0, Bricks2));
            screen.AddTile(new SquareTile(8, 0, Bricks2));
            screen.AddTile(new SquareTile(9, 0, Bricks2));
            screen.AddTile(new SquareTile(10, 0, Bricks2));
            screen.AddTile(new SquareTile(11, 0, Bricks2));
            screen.AddTile(new SquareTile(12, 0, Bricks2));

            // row 2
            screen.AddTile(new SquareTile(0, 1, Checker2));
            screen.AddTile(new SquareTile(1, 1, Checker2));
            screen.AddTile(new SquareTile(2, 1, Checker2));
            screen.AddTile(new BottomRightTriangleTile(8, 1, Bricks2TriangleBottomRight));
            screen.AddTile(new SquareTile(9, 1, Bricks2));
            screen.AddTile(new SquareTile(10, 1, Bricks2));
            screen.AddTile(new SquareTile(11, 1, Bricks2));
            screen.AddTile(new SquareTile(12, 1, Bricks2));

            // row 3
            screen.AddTile(new SquareTile(2, 2, Checker2));
            screen.AddTile(new SquareTile(9, 2, Bricks2));
            screen.AddTile(new SquareTile(10, 2, Bricks2));
            screen.AddTile(new SquareTile(11, 2, Bricks2));
            screen.AddTile(new SquareTile(12, 2, Bricks2));

            // row 4
            screen.AddTile(new SquareTile(2, 3, Checker2));
            screen.AddTile(new SquareTile(3, 3, Checker2));
            screen.AddTile(new SquareTile(4, 3, Checker2));
            screen.AddTile(new SquareTile(5, 3, Checker2));
            screen.AddTile(new SquareTile(6, 3, Checker2));
            screen.AddTile(new SquareTile(9, 3, Bricks2));
            screen.AddTile(new BottomLeftTriangleTile(10, 3, Bricks2TriangleBottomLeft));

            // row 7
            screen.AddTile(new TopRightTriangleTile(11, 6, Bricks2TriangleTopRight));
            screen.AddTile(new SquareTile(12, 6, Bricks2));

            // row 8
            screen.AddTile(new SquareTile(2, 7, Checker2));
            screen.AddTile(new TopRightTriangleTile(10, 7, Bricks2TriangleTopRight));
            screen.AddTile(new SquareTile(11, 7, Bricks2));
            screen.AddTile(new SquareTile(12, 7, Bricks2));

            // row 9
            screen.AddTile(new SquareTile(0, 8, Checker2));
            screen.AddTile(new SquareTile(1, 8, Checker2));
            screen.AddTile(new SquareTile(2, 8, Pipes1));
            screen.AddTile(new SquareTile(3, 8, Checker2));
            screen.AddTile(new SquareTile(4, 8, Checker2));
            screen.AddTile(new SquareTile(5, 8, Checker2));
            screen.AddTile(new SquareTile(8, 8, Bricks2));
            screen.AddTile(new SquareTile(9, 8, Bricks2));
            screen.AddTile(new SquareTile(10, 8, Bricks2));
            screen.AddTile(new SquareTile(11, 8, Bricks2));
            screen.AddTile(new SquareTile(12, 8, Bricks2));

            return screen;
        }

        private static Screen Screen2()
        {
            var screen = new Screen();

            // row 1
            screen.AddTile(new SquareTile(0, 0, Pipes1));

            return screen;
        }

        private static Screen Screen3()
        {
            var screen = new Screen();

            // row 1
            screen.AddTile(new SquareTile(1, 0, Pipes1));

            return screen;
        }

        private static Screen Screen4()
        {
            var screen = new Screen();

            // row 1
            screen.AddTile(new SquareTile(2, 0, Pipes1));

            return screen;
        }

        public override void MoveToScreen(double ballX, double ballY)
        {
            var x = (int)ballX / SquareTile.TileDimension + 1;
            var y = (int)ballY / SquareTile.TileDimension + 1;

            switch (CurrentScreenIndex)
            {
                case 0:
                    if (y == 1 && x >= 4 && x <= 5)
                        CurrentScreenIndex = 1;
                    else if (y == 9 && x >= 7 && x <= 8)
                        CurrentScreenIndex = 2;
                    else if (x == 1 && y >= 3 && y <= 11)
                        CurrentScreenIndex = 3;
                    else if (x == 12 && y >= 4 && y <= 6)
                        CurrentScreenIndex = 4;
                    break;
                default:
                    CurrentScreenIndex = 0;
                    break;
            }
        }
    }
}