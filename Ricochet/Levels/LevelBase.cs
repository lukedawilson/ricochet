using System.Collections.Generic;
using Ricochet.Elements;

namespace Ricochet.Levels
{
    public abstract class LevelBase
    {
        protected readonly IList<Screen> Screens = new List<Screen>(); // ToDo: probably need some sort of dictionary/map
        protected int CurrentScreenIndex = 0;

        public Screen CurrentScreen => Screens[CurrentScreenIndex];

        public void Draw()
        {
            CurrentScreen.Draw();
        }
    }
}