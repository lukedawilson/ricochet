using Klotski.Elements;

namespace Ricochet
{
    public static class Configuration
    {
        public static int ScreenWidth => Screen.Width * SquareTile.TileDimension;
        public static int ScreenHeight => Screen.Height * SquareTile.TileDimension;
    }
}
