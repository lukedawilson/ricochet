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
            { @"NN", new TileFactory<NonCollidingTile>("pillar_b1.png") },
        };

        public Level1() : base(Configuration.ScreenWidth, Configuration.ScreenHeight, Configuration.TileDimension)
        {
            AddScreen(
                "LLTT",
                LightBlueMappings,
                @"CC                        ",
                @"CC                        ",
                @"CC                        ",
                @"CC                        ",
                @"CC                        ",
                @"CCCCCC    CCCC    CCCC    ",
                @"CC                CCCC    ",
                @"CC  CCCCCC                ",
                @"CC                        "
            );
            AddScreen(
                "LTT",
                LightBlueMappings,
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"    CCCC        /CCCCCCCCC",
                @"    CCCC      /CCCCCCCCCCC",
                @"            /CCCCCCCCCCCCC",
                @"          /CCCCCCCCCPPPPPP"
            );
            AddScreen(
                "TT",
                LightBlueMappings,
                @"                          ",
                @"        CCCCCCCCCC        ",
                @"                  CC      ",
                @"  /CC/              CC    ",
                @"  CC    \CCCCCCC      CC  ",
                @"CCCC                  CCCC",
                @"CC                \CCCCCCC",
                @"CC                  CCCCCC",
                @"CC    CCCCCCCCCCCCCCPPPPPP"
            );
            AddScreen(
                "RTT",
                LightBlueMappings,
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"                          ",
                @"CCCCCCCCCCCCCCCCCC    CCCC",
                @"    CCCCCCCCCCCCCC    CCCC",
                @"CC                  /CC/  ",
                @"CC                /CC/    "
            );
            AddScreen(
                "RRTT",
                LightBlueMappings,
                @"                        CC",
                @"                        CC",
                @"                    CCCCCC",
                @"                        CC",
                @"                        CC",
                @"CCCCCCCCCCCCCCCC      CCCC",
                @"CCCCCCCCCCCCCCCC      CCCC",
                @"                        CC",
                @"                        CC"
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
                @"        /BCCCCCCCCCCCCCCCC",
                @"        BB              CC",
                @"      /BB/    CC    CCCCCC",
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
                @"CC    \CCCCCCC  CCCCCCCCCC",
                @"CC          CC            ",
                @"CCC/        CC      CCCCCC",
                @"CC    \CCCCCCC    CC      ",
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
                @"B/                  BBBBPP",
                @"                        PP",
                @"BBBBB\                  PP",
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
                "M",
                LightBlueMappings,
                @"CCCCPPCCCCCC    BBBBBBBBBB",
                @"    CC          CC  \BBBBB",
                @"              CCCC    \BBB",
                @"                          ",
                @"            NN            ",
                @"    CCCCCCCCCC      B\    ",
                @"    CC            BBBBBBBB",
                @"CCCCCC          BBBBBBBBBB",
                @"PPPPCC    BBBBBBBBBBBBBBBB"
            );
            AddScreen(
                "R",
                LightBlueMappings,
                @"CCCCCCCCCCCCCCCCCCCCCCCCCC",
                @"CC                        ",
                @"CC            CCCCCCCCCCCC",
                @"            CCC/          ",
                @"          CCC/  /CCCCCCCCC",
                @"      CC  C/              ",
                @"CCCCCCCCC/  /CCCCCCC  CCCC",
                @"PPPPCCC/  /C          CCCC",
                @"PPPPCC  /CCCCCCCCCCCCCPPPP"
            );
            AddScreen(
                "RR",
                LightBlueMappings,
                @"CCPPCCCCCCCCCCCCCCCCCCCCCC",
                @"                        CC",
                @"CCCCCCCCCCCCCCCC    CCCCCC",
                @"                  CCC/  PP",
                @"CCCCCCCCCCCCCC          PP",
                @"            CCCCCCCCCCCCCC",
                @"CC                      CC",
                @"CC                  CC  CC",
                @"CCCCCCCCCCCCCCCCCCCCCC  CC"
            );
            AddScreen(
                "LLB",
                LightBlueMappings,
                @"SS        SSSSSSSSSSSSSSSS",
                @"SS          CCCCCCCCCCCCCC",
                @"SSSS                CCCCCC",
                @"SSSSSS      /CCC    CCCCCC",
                @"SS          CCCC        CC",
                @"SS          CCCCCC      CC",
                @"SSSSSSSSSSSSSSSSSSSS    SS",
                @"SSSSSSSSSSSSSSSS        SS",
                @"SSSSSSSSSSSSSSSS    SSSSSS"
            );
            AddScreen(
                "LB",
                LightBlueMappings,
                @"CCCCCCCCPPPPPPPPPPPPPPPPPP",
                @"CCCCPPPPPPPPPPPPC/  \CPPPP",
                @"CCCCCCCCCCCCCCC/        CC",
                @"CC                        ",
                @"CC  CCCCCCCCCCCC    \CCCCC",
                @"CC  CC        CCCC      CC",
                @"CC  CC        CC        CC",
                @"CC      CC    CC    CCCCCC",
                @"CCCCCCCCCCCC  CC    CCCCCC"
            );
            AddScreen(
                "B",
                LightBlueMappings,
                @"CCCCCC    CCCCCCCCCCCCCCCC",
                @"CCCC      CC              ",
                @"CC      CCCC      CCCCCCCC",
                @"          CC            CC",
                @"CC        CCCCCCCC      CC",
                @"CCCC                    CC",
                @"CCCCCCCCCCCCCCCCCCCCCCCCCC",
                @"CCCCCC            CCCCCCCC",
                @"CCCCCC    CCCC    CCPPPPPP"
            );
            AddScreen(
                "RB",
                LightBlueMappings,
                @"CCCCCC    CCCCCCCCCCCCCCCC",
                @"          CC              ",
                @"CCCCCCCCCCCCCC    CCCCCCCC",
                @"CCCCCCCCCCCC            CC",
                @"CCCCCCCCCCCC        /CCCCC",
                @"CCCCCC        CCCCCCCCCCCC",
                @"CCCC          CC          ",
                @"CCCC    CCCCCCCC  CCCCCCCC",
                @"CCCC    CCCCCCCC  CCPPPPPP"
            );
            AddScreen(
                "RRB",
                LightBlueMappings,
                @"CCCCCCCCCCCCCCCCCCCCCC  CC",
                @"                        CC",
                @"CC        CC      CCCCCCCC",
                @"CC        CC            CC",
                @"CCCCCCCCCCCCCCCCCCCCCCCCCC",
                @"CC                      CC",
                @"                    /C  CC",
                @"CCCCCC              CC  CC",
                @"CCCCCCCCCCCCCCCCCCCCCC  CC"
            );
            AddScreen(
                "LLBB",
                LightBlueMappings,
                @"CCCCCCCCCCCCCCCC    CCCCCC",
                @"CC                  CCCCCC",
                @"CC            CCCCCCCCCCCC",
                @"CC        CCCCCCCC  CCCCCC",
                @"PP    CCCCCCCCCCCC  CCCCCC",
                @"CC                      CC",
                @"CCCCCC                  CC",
                @"CCCCCC          /CCCC\  CC",
                @"CCCCCCCCCCCCCCCCCCCCCCCCCC"
            );
            AddScreen(
                "LBB",
                LightBlueMappings,
                @"CCCCCCCCCCCC  CC    CCCCCC",
                @"CCCC      CC  CC          ",
                @"CC        CC  CCCCCCCCCCCC",
                @"CC            CC        CC",
                @"CC        CCCCCCCC        ",
                @"CC                        ",
                @"CCCC                  CCCC",
                @"CCCCCC              CCCCCC",
                @"CCCCCCCCCCCCCCCCCCCCPPPPPP"
            );
            AddScreen(
                "BB",
                LightBlueMappings,
                @"CCCCC/  /CCCCCC\  \CCCCCCC",
                @"        CCCCCCCC    CCCCCC",
                @"CCCCCCCCCCCCCCCCCC        ",
                @"CCCCCC    CCCCCCCCCCCCCCCC",
                @"    \C    CCCCCC          ",
                @"      \CCCCCCCCCCC        ",
                @"CCC\                  CCCC",
                @"CCCCC\              CCCCCC",
                @"CCCCCCCCCCPPPPCCCCCCPPPPPP"
            );
            AddScreen(
                "RBB",
                LightBlueMappings,
                @"CCCC    CCCCCC    CCCCCCCC",
                @"CCC/    CCCC            CC",
                @"        CCCC      CCCCCCC/",
                @"CCCCCCCCCC      CC        ",
                @"            /CCCCC      CC",
                @"            CCC/\CCC    CC",
                @"CCCC    CCCC          CCCC",
                @"CCCCCC              CCCCCC",
                @"CCCCCCCCCCCCCCCCCCCCPPPPPP"
            );
            AddScreen(
                "RRBB",
                LightBlueMappings,
                @"CCCCCCCCCCCCCCCCCCCCCC  CC",
                @"CC                  CC  PP",
                @"            CCCCCCCCCC  CC",
                @"          CC            CC",
                @"CC        CCCCCCCCCC    CC",
                @"CC  /CC\                CC",
                @"CCCCCCCC              CCCC",
                @"CCCCCCCCCC          CCCCCC",
                @"CCCCCCCCCCCCCCCCCCCCPPPPPP"
            );


            CurrentScreenKey = "M";
        }

        protected override string[,] ScreensLayout => new[,]
        {
            {   "LLTT",     "LTT",      "TT",       "RTT",      "RRTT" },
            {   "LLT",      "LT",       "T",        "RT",       "RRT"  },
            {   "LL",       "L",        "M",        "R",        "RR"   },
            {   "LLB",      "LB",       "B",        "RB",       "RRB"  },
            {   "LLBB",     "LBB",      "BB",       "RBB",      "RRBB" }
        };
    }
}
