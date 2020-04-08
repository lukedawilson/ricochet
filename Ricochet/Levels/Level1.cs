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
            { @"/C", new TileFactory<BottomRightTriangleTile>("checker2_BR.png") },
            { @"C/", new TileFactory<TopLeftTriangleTile>("checker2_TL.png") },
            { @"\C", new TileFactory<TopRightTriangleTile>("checker2_TR.png") },
            { @"C\", new TileFactory<BottomLeftTriangleTile>("checker2_BL.png") },
            { @"PP", new TileFactory<SquareTile>("pipes1.png") },
            { @"BB", new TileFactory<SquareTile>("bricks2.png") },
            { @"/B", new TileFactory<BottomRightTriangleTile>("bricks2_BR.png") },
            { @"B/", new TileFactory<TopLeftTriangleTile>("bricks2_TL.png") },
            { @"\B", new TileFactory<TopRightTriangleTile>("bricks2_TR.png") },
            { @"B\", new TileFactory<BottomLeftTriangleTile>("bricks2_BL.png") },
            { @"SS", new TileFactory<SquareTile>("sand_ground1.png") },
        };

        public Level1() : base(Configuration.ScreenWidth, Configuration.ScreenHeight, Configuration.TileDimension)
        {
            AddScreen(
                "LLTT",
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
            AddScreen(
                "LTT",
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
            AddScreen(
                "TT",
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
            AddScreen(
                "RTT",
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
            AddScreen(
                "RRTT",
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
            AddScreen(
                "LLT",
                LightBlueMappings,
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PPPPPP                    ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        "
            );
            AddScreen(
                "LT",
                LightBlueMappings,
                @"        BBCCCCCCCCCCCCCCCC",
                @"        BB              CC",
                @"      /BB/    CC  CCCCCCCC",
                @"    /BB/      CC        CC",
                @"    BB    CCCCCCCCCCCCCCCC",
                @"    BB                  CC",
                @"    BBBBBB              CC",
                @"        BB                ",
                @"        BBBBBBBBBBBBBBBBBB"
            );
            AddScreen(
                "T",
                LightBlueMappings,
                @"CC    CCCCCCCC  CCCCCCCCCC",
                @"CC          CC            ",
                @"CCCC        CC      CCCCCC",
                @"CC          CC    CC      ",
                @"CC          CC  CC        ",
                @"CCCCCC      CCCCCC      CC",
                @"CCCCCCCC              CCCC",
                @"                    CCCCCC",
                @"CCCCCCCCCCCC    CCCCCCCCCC"
            );
            AddScreen(
                "RT",
                LightBlueMappings,
                @"CC  CCC\                CC",
                @"        \CCCCCCC      /CC/",
                @"CCCCCC      CCCCCCCC  CC  ",
                @"      CC    CCCCCCCC  CCCC",
                @"        CC              CC",
                @"CCCC          CCCCCCCCCCCC",
                @"CCCCCC      CCC/          ",
                @"CCCCCCCC            CCCCCC",
                @"CCCCCCCCCCCCCCCCCCCCCCCCCC"
            );
            AddScreen(
                "RRT",
                LightBlueMappings,
                @"CC                      PP",
                @"CC                      PP",
                @"CC          BBBB        PP",
                @"CC                      PP",
                @"BB                      PP",
                @"BB                  BBBBPP",
                @"                        PP",
                @"BBB\                    PP",
                @"BBBBBBBBBBBBBBBBBBBBBBBBBB"
            );
            AddScreen(
                "LL",
                LightBlueMappings,
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP                        ",
                @"PP        SSSS            ",
                @"PP        SSSSSSSSSSSSSSSS"
            );
            AddScreen(
                "L",
                LightBlueMappings,
                @"      /BBBBBBBBBBBBBBBBBBB",
                @"    /BBBBBBBB/          B/",
                @"    \BBBBBB/          BB  ",
                @"                  BBBBB/  ",
                @"              BBBBBBB/    ",
                @"                          ",
                @"        CC                ",
                @"      CCCCCC        CCCCCC",
                @"SSSSCCCCCCCCCCCCCCCCCCPPPP"
            );
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
                "R",
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
                "RR",
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
                "LLB",
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
                "LB",
                LightBlueMappings,
                @"CCCCCCCCPPPPPPPPPPPPPPPPPP",
                @"CCCCPPPPPPPPPPPPPPPPPPPPPP",
                @"CCCCCCCCCCCCCCCCCCCCCCCCCC",
                @"CC                        ",
                @"CC  CCCCCCCCCCCCCC  CCCCCC",
                @"CC  CC        CCCC      CC",
                @"CC  CCCC      CC    CCCCCC",
                @"CC    CCCCC   CC  CCCCCCCC",
                @"CCCCCCCCCCCC  CC  CCCCCCCC"
            );
            AddScreen(
                "B",
                LightBlueMappings,
                @"CCCCCC    CCCCCCCCCCCCCCCC",
                @"CCCC      CC            PP",
                @"CC        CC      CCCCCCCC",
                @"          CC            CC",
                @"          CCCCCCCC      CC",
                @"CC                      CC",
                @"CCCC                  CCCC",
                @"CCCCCC              CCCCCC",
                @"CCCCCCCCCCCCCCCCCCCCPPPPPP"
            );
            AddScreen(
                "RB",
                LightBlueMappings,
                @"CCCCCC    CCCCCCCCCCCCCCCC",
                @"          CC            PP",
                @"CCCCCCCCCCCC      CCCCCCCC",
                @"PP        CC            CC",
                @"PP        CCCCCCCC      CC",
                @"CC                      CC",
                @"CCCC                  CCCC",
                @"CCCCCC              CCCCCC",
                @"CCCCCCCCCCCCCCCCCCCCPPPPPP"
            );
            AddScreen(
                "RRB",
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
            AddScreen(
                "LLBB",
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
            AddScreen(
                "LBB",
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
            AddScreen(
                "BB",
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
            AddScreen(
                "RBB",
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
            AddScreen(
                "RRBB",
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
            {   "LLTT",     "LTT",      "TT",       "RTT",      "RRTT" },
            {   "LLT",      "LT",       "T",        "RT",       "RRT"  },
            {   "LL",       "L",        "Initial",  "R",        "RR"   },
            {   "LLB",      "LB",       "B",        "RB",       "RRB"  },
            {   "LLBB",     "LBB",      "BB",       "RBB",      "RRBB" }
        };
    }
}
