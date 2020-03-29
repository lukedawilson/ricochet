using Klotski.Elements;

namespace Ricochet
{
    public static class Configuration
    {
        public static int ScreenWidth => Screen.Width * SquareTile.TileDimension;
        public static int ScreenHeight => Screen.Height * SquareTile.TileDimension;
        public static int BallRadius => 25;
        public static double Gravity => 1;
        public static string Title => "Ricochet";
    }
}
