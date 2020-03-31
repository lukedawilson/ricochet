using System;
using System.Collections.Generic;
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
        private const string Bricks2TriangleTopLeft = "bricks2_triangle_top_left.png";
        private const string Bricks2TriangleTopRight = "bricks2_triangle_top_right.png";

        private readonly IDictionary<string, TileFactory> _mappings = new Dictionary<string, TileFactory>
        {
            { @"CC", new TileFactory<SquareTile>(Checker2) },
            { @"PP", new TileFactory<SquareTile>(Pipes1) },
            { @"BB", new TileFactory<SquareTile>(Bricks2) },
            { @"/B", new TileFactory<BottomRightTriangleTile>(Bricks2TriangleBottomRight) },
            { @"B/", new TileFactory<TopLeftTriangleTile>(Bricks2TriangleTopLeft) },
            { @"\B", new TileFactory<TopRightTriangleTile>(Bricks2TriangleTopRight) },
            { @"B\", new TileFactory<BottomLeftTriangleTile>(Bricks2TriangleBottomLeft) },
        };

        public Level1() : base(Configuration.ScreenWidth, Configuration.ScreenHeight, Configuration.TileDimension)
        {
            AddScreen(
                @"CCCCPPCCCCCC    BBBBBBBBBB",
                @"    CC              \BBBBB",
                @"                      \BBB",
                @"                          ",
                @"                          ",
                @"    CCCCCCCCCC    BBB\    ",
                @"    CC            BBBBBBBB",
                @"CCCCCC          /BBBBBBBBB",
                @"PPPPCC    BBBBBBBBBBBBBBBB"
            );
            AddScreen(
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"PP                        "
            );
            AddScreen(
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"  PP                      "
            );
            AddScreen(
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"    PP                    "
            );
            AddScreen(
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"      PP                  "
            );

            CurrentScreenIndex = 0;
        }

        private void AddScreen(params string[] layout)
        {
            Screens.Add(GenerateLayout(layout, _mappings));
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
