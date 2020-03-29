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

        public int ScreenWidth { get; private set; }
        public double ScreenHeight { get; private set; }

        protected readonly IList<Screen> Screens = new List<Screen>();
        protected int CurrentScreenIndex = 0;

        public Screen CurrentScreen => Screens[CurrentScreenIndex];

        public void AddBall(Ball ball) => ball.CurrentLevel = this;
        public abstract void MoveBallToScreen(Side side, Ball ball);
        public abstract void MoveBallToScreen(int index, Ball ball);

        public void Draw()
        {
            CurrentScreen.Draw();
        }
    }
}