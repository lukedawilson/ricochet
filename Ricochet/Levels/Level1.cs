using System.Collections.Generic;
using Klotski;
using Klotski.Elements;

namespace Ricochet.Levels
{
    public class Level1 : LevelBase
    {
        private IDictionary<string, TileFactory> LightBlueMappings => new Dictionary<string, TileFactory>
        {
            { @"CC", new TileFactory<SquareTile>("checker2.png") },
            { @"PP", new TileFactory<SquareTile>("pipes1.png") },
            { @"BB", new TileFactory<SquareTile>("bricks2.png") },
            { @"/B", new TileFactory<BottomRightTriangleTile>("bricks2_triangle_bottom_right.png") },
            { @"B/", new TileFactory<TopLeftTriangleTile>("bricks2_triangle_top_left.png") },
            { @"\B", new TileFactory<TopRightTriangleTile>("bricks2_triangle_top_right.png") },
            { @"B\", new TileFactory<BottomLeftTriangleTile>("bricks2_triangle_bottom_left.png") },
            { @"SS", new TileFactory<SquareTile>("sand_ground1.png") },
        };

        public Level1() : base(Configuration.ScreenWidth, Configuration.ScreenHeight, Configuration.TileDimension)
        {
            AddScreen(
                "initial",
                LightBlueMappings,
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
                LightBlueMappings,
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
                LightBlueMappings,
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
                LightBlueMappings,
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
                LightBlueMappings,
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
