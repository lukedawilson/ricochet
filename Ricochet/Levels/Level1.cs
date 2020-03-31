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
                "initial",
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
                "initial-left",
                @"PPPPPPPPPPPPPPPPPPPPPPPPPP",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PPPPPPPPPPPPPPPPPPPPPPPPPP"
            );
            AddScreen(
                "initial-right",
                @"PPPPPPPPPPPPPPPPPPPPPPPPPP",
                @"                        PP",
                @"                        PP",
                @"                        PP",
                @"                        PP",
                @"                        PP",
                @"                        PP",
                @"                        PP",
                @"PPPPPPPPPPPPPPPPPPPPPPPPPP"
            );
            AddScreen(
                "initial-top",
                @"PPPPPPPPPPPPPPPPPPPPPPPPPP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP"
            );
            AddScreen(
                "initial-bottom",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PP                      PP",
                @"PPPPPPPPPPPPPPPPPPPPPPPPPP"
            );

            CurrentScreenKey = "initial";
        }

        private void AddScreen(string key, params string[] layout)
        {
            Screens.Add(key, GenerateLayout(layout, _mappings));
        }

        private readonly string[,] _screensLayout =
        {
            { null,           "initial-top",    null            },
            { "initial-left", "initial",        "initial-right" },
            { null,           "initial-bottom", null            }
        };

        public override void MoveBallToScreen(Side side)
        {
            for (var yy = 0; yy < _screensLayout.GetLength(0); yy++)
            {
                for (var xx = 0; xx < _screensLayout.GetLength(1); xx++)
                {
                    var current = _screensLayout[yy, xx];
                    if (current != CurrentScreenKey) continue;

                    int x, y;
                    switch (side)
                    {
                        case Side.Left:
                            x = xx - 1;
                            y = yy;
                            break;
                        case Side.Right:
                            x = xx + 1;
                            y = yy;
                            break;
                        case Side.Top:
                            x = xx;
                            y = yy - 1;
                            break;
                        case Side.Bottom:
                            x = xx;
                            y = yy + 1;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(side), side, null);
                    }

                    CurrentScreenKey = _screensLayout[y, x];
                    if (CurrentScreenKey == null) throw new ArgumentOutOfRangeException();
                    return;
                }
            }
        }
    }
}
