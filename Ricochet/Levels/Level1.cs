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
        private const string SandGround1 = "sand_ground1.png";

        protected override IDictionary<string, TileFactory> Mappings => new Dictionary<string, TileFactory>
        {
            { @"CC", new TileFactory<SquareTile>(Checker2) },
            { @"PP", new TileFactory<SquareTile>(Pipes1) },
            { @"BB", new TileFactory<SquareTile>(Bricks2) },
            { @"/B", new TileFactory<BottomRightTriangleTile>(Bricks2TriangleBottomRight) },
            { @"B/", new TileFactory<TopLeftTriangleTile>(Bricks2TriangleTopLeft) },
            { @"\B", new TileFactory<TopRightTriangleTile>(Bricks2TriangleTopRight) },
            { @"B\", new TileFactory<BottomLeftTriangleTile>(Bricks2TriangleBottomLeft) },
            { @"SS", new TileFactory<BottomLeftTriangleTile>(SandGround1) },
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
                @"PP      /BBBBBBBBBBBBBBBBB",
                @"PP    /BBBBBB/          B/",
                @"PP    \BBBB/          BB  ",
                @"PP                BBBBB/  ",
                @"PP            BBBBBBB/    ",
                @"PP                        ",
                @"PP      CC                ",
                @"PP    CCCCCC        CCCCCC",
                @"SSSSCCCCCCCCCCCCCCCCCCPPPP"
            );
            AddScreen(
                "initial-right",
                @"CCCCCCCCCCCCCCCCCCCCCCCCCC",
                @"CC                      PP",
                @"CC            CCCCCCCCCCCC",
                @"            CCCCCCCC      ",
                @"          CCCCCCCC    CCCC",
                @"      CC  CCCCCCCC        ",
                @"CCCCCCCCCCCC          CCCC",
                @"PPPPCC              CCCCCC",
                @"PPPPCC  CCCCCCCCCCCCCCPPPP"
            );
            AddScreen(
                "initial-top",
                @"CCPPCCCCCCCCCC  CCCCCCCCCC",
                @"CC          CC            ",
                @"CC          CC      CCCCCC",
                @"CC          CC    CC    PP",
                @"CC          CC  CC      PP",
                @"CCCCCC      CCCCCC      CC",
                @"CCCCCCCC              CCCC",
                @"PP                  CCCCCC",
                @"CCCCCCCCCCCC    CCCCCCCCCC"
            );
            AddScreen(
                "initial-bottom",
                @"CCCCCC    CCCCCCCCCCCCCCCC",
                @"CCCC      CC            PP",
                @"CC        CC      CCCCCCCC",
                @"PP        CC            CC",
                @"PP        CCCCCCCC      CC",
                @"CC                      CC",
                @"CCCC                  CCCC",
                @"CCCCCC              CCCCCC",
                @"CCCCCCCCCCCCCCCCCCCCPPPPPP"
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
