using System;
using System.Collections.Generic;
using System.Linq;
using Klotski;
using Klotski.Elements;

namespace Ricochet.Levels
{
    public class Level1 : LevelBase
    {
        private readonly int _horizontalTiles;
        private readonly int _verticalTiles;
        private const string Pipes1 = "pipes1.png";
        private const string Checker2 = "checker2.png";
        private const string Bricks2 = "bricks2.png";
        private const string Bricks2TriangleBottomLeft = "bricks2_triangle_bottom_left.png";
        private const string Bricks2TriangleBottomRight = "bricks2_triangle_bottom_right.png";
        private const string Bricks2TriangleTopRight = "bricks2_triangle_top_right.png";

        public Level1(int horizontalTiles, int verticalTiles) : base(
            Configuration.ScreenWidth,
            Configuration.ScreenHeight)
        {
            _horizontalTiles = horizontalTiles;
            _verticalTiles = verticalTiles;

            Screens.Add(Screen0());
            Screens.Add(Screen1());
            Screens.Add(Screen2());
            Screens.Add(Screen3());
            Screens.Add(Screen4());

            CurrentScreenIndex = 0;
        }

        private Screen Screen0()
        {
            var mappings = new Dictionary<string, TileSpec>
            {
                { @"CC", new TileSpec(Checker2) },
                { @"PP", new TileSpec(Pipes1) },
                { @"BB", new TileSpec(Bricks2) },
                { @"/B", new BottomRightTriangleTileSpec(Bricks2TriangleBottomRight) },
                //{ @"B/", Bricks2TriangleTopLeft },
                { @"\B", new TopRightTriangleTileSpec(Bricks2TriangleTopRight) },
                { @"B\", new BottomLeftTriangleTileSpec(Bricks2TriangleBottomLeft) },
            };
//            var layout1 = new[]
//            {
//                @"CCPCCC  BBBBB",
//                @"  C       \BB",
//                @"           \B",
//                @"             ",
//                @"             ",
//                @"  CCCCC  B\  ",
//                @"  C      BBBB",
//                @"CCC     /BBBB",
//                @"PPC  BBBBBBBB"
//            };
            var layout = new[]
            {
                @"CCCCPPCCCCCC    BBBBBBBBBB",
                @"    CC              \BBBBB",
                @"                      \BBB",
                @"                          ",
                @"                          ",
                @"    CCCCCCCCCC    BBB\    ",
                @"    CC            BBBBBBBB",
                @"CCCCCC          /BBBBBBBBB",
                @"PPPPCC    BBBBBBBBBBBBBBBB"
            };

            return GenerateLayout(layout, mappings);
        }

        public class TileSpec
        {
            public TileSpec(string file)
            {
                File = file;
            }

            public string File { get; private set; }
            public virtual Func<int, int, string, SquareTile> Create => (x, y, file) => new SquareTile(x, y, file);
        }

        public class BottomRightTriangleTileSpec : TileSpec
        {
            public BottomRightTriangleTileSpec(string file) : base(file)
            {
            }

            public override Func<int, int, string, SquareTile> Create => (x, y, file) => new BottomRightTriangleTile(x, y, file);
        }

        public class TopRightTriangleTileSpec : TileSpec
        {
            public TopRightTriangleTileSpec(string file) : base(file)
            {
            }

            public override Func<int, int, string, SquareTile> Create => (x, y, file) => new TopRightTriangleTile(x, y, file);
        }

        public class BottomLeftTriangleTileSpec : TileSpec
        {
            public BottomLeftTriangleTileSpec(string file) : base(file)
            {
            }

            public override Func<int, int, string, SquareTile> Create => (x, y, file) => new BottomLeftTriangleTile(x, y, file);
        }

        private Screen GenerateLayout(string[] layout, IDictionary<string, TileSpec> mappings)
        {
            if (layout.Length != _verticalTiles)
                throw new ArgumentException($"Must have {_verticalTiles} rows");

            if (layout.Any(r => r.Length != _horizontalTiles * 2))
                throw new ArgumentException($"Must have {_horizontalTiles} columns");

            var screen = new Screen();

            for (var yy = layout.Length - 1; yy >= 0; yy--)
            {
                var row = layout[yy];

                var y = layout.Length - 1 - yy;
                for (var xx = 0; xx < row.Length; xx+= 2)
                {
                    var tile = row.Substring(xx, 2);
                    if (string.IsNullOrWhiteSpace(tile)) continue;

                    var tileSpec = mappings[row.Substring(xx, 2)];
                    var x = xx / 2;
                    screen.AddTile(tileSpec.Create(x, y, tileSpec.File));
                }
            }

            return screen;
        }

        private static Screen Screen1()
        {
            var screen = new Screen();

            // row 1
            screen.AddTile(new SquareTile(0, 1, Pipes1));

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

        public override void MoveBallToScreen(Side side)
        {
            switch (CurrentScreenIndex)
            {
                case 0:
                    switch (side)
                    {
                        case Side.Left:
                            CurrentScreenIndex =  1;
                            break;
                        case Side.Right:
                            CurrentScreenIndex =  2;
                            break;
                        case Side.Top:
                            CurrentScreenIndex =  3;
                            break;
                        case Side.Bottom:
                            CurrentScreenIndex =  4;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(side), side, null);
                    }

                    break;
                default:
                    CurrentScreenIndex =  0;
                    break;
            }
        }

        public override void InitialiseBallPosition(Ball ball)
        {
            ball.X = Configuration.ScreenWidth / 2.0;
            ball.Y = Configuration.ScreenHeight - ball.BallRadius - 10;
        }
    }
}
