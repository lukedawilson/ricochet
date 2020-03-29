using System.Collections.Generic;
using Klotski.Elements;

namespace Klotski
{
    public enum Side { Left, Right, Top, Bottom }

    public abstract class LevelBase
    {
        protected LevelBase(int screenWidth, int screenHeight)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }

        public int ScreenWidth { get; }
        public double ScreenHeight { get; }

        protected readonly IList<Screen> Screens = new List<Screen>();
        protected int CurrentScreenIndex { get; set; }

        public Screen CurrentScreen => Screens[CurrentScreenIndex];

        public void AddBall(Ball ball) => ball.CurrentLevel = this;
        public abstract void MoveBallToScreen(Side side);
        public abstract void SetInitialBallPosition(Ball ball);

        public void Draw()
        {
            CurrentScreen.Draw();
        }
    }
}