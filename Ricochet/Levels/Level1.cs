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

        protected override IDictionary<string, TileFactory> Mappings => new Dictionary<string, TileFactory>
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

        protected override string[,] ScreensLayout => new[,]
        {
            { null,           "initial-top",    null            },
            { "initial-left", "initial",        "initial-right" },
            { null,           "initial-bottom", null            }
        };
    }
}
