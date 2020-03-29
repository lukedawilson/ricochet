using System.Collections.Generic;
using Klotski.Elements;

namespace Klotski
{
    public enum Side { Left, Right, Top, Bottom }

    public abstract class LevelBase
    {
        protected readonly IList<Screen> Screens = new List<Screen>();
        protected int CurrentScreenIndex = 0;

        public Screen CurrentScreen => Screens[CurrentScreenIndex];
        public abstract void MoveToScreen(Side side, Ball ball);

        public void Draw()
        {
            CurrentScreen.Draw();
        }
    }
}