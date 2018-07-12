using System;

namespace Ricochet
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var game = new GameLoop())
                game.Run();
        }
    }
}