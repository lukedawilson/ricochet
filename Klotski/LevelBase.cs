using System;
using System.Collections.Generic;
using System.Linq;
using Klotski.Elements;

namespace Klotski
{
    public enum Side { Left, Right, Top, Bottom }

    public abstract class LevelBase
    {
        private readonly int _horizontalTiles;
        private readonly int _verticalTiles;

        protected LevelBase(int screenWidth, int screenHeight, int tileDimension)
        {
            _horizontalTiles = screenWidth / tileDimension;
            _verticalTiles = screenHeight / tileDimension;

            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }

        public int ScreenWidth { get; }
        public double ScreenHeight { get; }

        protected readonly IDictionary<string, Screen> Screens = new Dictionary<string, Screen>();
        protected string CurrentScreenKey { get; set; }

        public Screen CurrentScreen => Screens[CurrentScreenKey];

        public void AddBall(Ball ball)
        {
            ball.CurrentLevel = this;
            ball.X = ScreenWidth / 2.0;
            ball.Y = ScreenHeight - ball.BallRadius - 150;
        }

        public virtual void InitialiseBallPosition(Side side, Ball ball)
        {
            switch (side)
            {
                case Side.Left:
                    ball.X = ScreenWidth;
                    break;
                case Side.Right:
                    ball.X = 0;
                    break;
                case Side.Top:
                    ball.Y = 0;
                    break;
                case Side.Bottom:
                    ball.Y = ScreenHeight;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(side), side, null);
            }
        }

        public void Draw()
        {
            CurrentScreen.Draw();
        }

        protected void AddScreen(string key, params string[] layout)
        {
            Screens.Add(key, GenerateLayout(layout, Mappings));
        }

        protected Screen GenerateLayout(IReadOnlyList<string> layout, IDictionary<string, TileFactory> mappings)
        {
            if (layout.Count != _verticalTiles)
                throw new ArgumentException($"Must have {_verticalTiles} rows");

            if (layout.Any(r => r.Length != _horizontalTiles * 2))
                throw new ArgumentException($"Must have {_horizontalTiles} columns");

            var screen = new Screen();

            for (var yy = layout.Count - 1; yy >= 0; yy--)
            {
                var row = layout[yy];

                var y = layout.Count - 1 - yy;
                for (var xx = 0; xx < row.Length; xx+= 2)
                {
                    var tile = row.Substring(xx, 2);
                    if (string.IsNullOrWhiteSpace(tile)) continue;

                    var tileDetails = mappings[row.Substring(xx, 2)];
                    var x = xx / 2;
                    screen.AddTile(tileDetails.Create(x, y, tileDetails.File));
                }
            }

            return screen;
        }

        protected abstract IDictionary<string, TileFactory> Mappings { get; }

        // ToDo: implement this
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

        protected abstract string[,] ScreensLayout { get; }

        public virtual void MoveBallToScreen(Side side)
        {
            for (var yy = 0; yy < ScreensLayout.GetLength(0); yy++)
            {
                for (var xx = 0; xx < ScreensLayout.GetLength(1); xx++)
                {
                    var current = ScreensLayout[yy, xx];
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

                    CurrentScreenKey = ScreensLayout[y, x];
                    if (CurrentScreenKey == null) throw new ArgumentOutOfRangeException();
                    return;
                }
            }
        }
    }
}