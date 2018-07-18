using Microsoft.Xna.Framework.Graphics;
using Ricochet.Elements;

namespace Ricochet.Levels
{
    public class Level1 : LevelBase
    {
        private const string Pipes1 = "pipes1.png";
        private const string Checker2 = "checker2.png";
        private const string Bricks2 = "bricks2.png";

        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;

        public Level1(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;

            var screen1 = new Screen();

            screen1.AddTile(Tile(0, 0, Pipes1));
            screen1.AddTile(Tile(1, 0, Pipes1));
            screen1.AddTile(Tile(2, 0, Checker2));
            screen1.AddTile(Tile(5, 0, Bricks2));
            screen1.AddTile(Tile(6, 0, Bricks2));
            screen1.AddTile(Tile(7, 0, Bricks2));
            screen1.AddTile(Tile(8, 0, Bricks2));
            screen1.AddTile(Tile(9, 0, Bricks2));
            screen1.AddTile(Tile(10, 0, Bricks2));
            screen1.AddTile(Tile(11, 0, Bricks2));
            screen1.AddTile(Tile(12, 0, Bricks2));

            screen1.AddTile(Tile(0, 1, Checker2));
            screen1.AddTile(Tile(1, 1, Checker2));
            screen1.AddTile(Tile(2, 1, Checker2));
            screen1.AddTile(Tile(9, 1, Bricks2));
            screen1.AddTile(Tile(10, 1, Bricks2));
            screen1.AddTile(Tile(11, 1, Bricks2));
            screen1.AddTile(Tile(12, 1, Bricks2));

            screen1.AddTile(Tile(2, 2, Checker2));
            screen1.AddTile(Tile(9, 2, Bricks2));
            screen1.AddTile(Tile(10, 2, Bricks2));
            screen1.AddTile(Tile(11, 2, Bricks2));
            screen1.AddTile(Tile(12, 2, Bricks2));

            screen1.AddTile(Tile(2, 3, Checker2));
            screen1.AddTile(Tile(3, 3, Checker2));
            screen1.AddTile(Tile(4, 3, Checker2));
            screen1.AddTile(Tile(5, 3, Checker2));
            screen1.AddTile(Tile(6, 3, Checker2));
            screen1.AddTile(Tile(9, 3, Bricks2));

            screen1.AddTile(Tile(12, 6, Bricks2));

            screen1.AddTile(Tile(2, 7, Checker2));
            screen1.AddTile(Tile(11, 7, Bricks2));
            screen1.AddTile(Tile(12, 7, Bricks2));

            screen1.AddTile(Tile(0, 8, Checker2));
            screen1.AddTile(Tile(1, 8, Checker2));
            screen1.AddTile(Tile(2, 8, Pipes1));
            screen1.AddTile(Tile(3, 8, Checker2));
            screen1.AddTile(Tile(4, 8, Checker2));
            screen1.AddTile(Tile(5, 8, Checker2));
            screen1.AddTile(Tile(8, 8, Bricks2));
            screen1.AddTile(Tile(9, 8, Bricks2));
            screen1.AddTile(Tile(10, 8, Bricks2));
            screen1.AddTile(Tile(11, 8, Bricks2));
            screen1.AddTile(Tile(12, 8, Bricks2));

            Screens.Add(screen1);
        }

        private Tile Tile(int x, int y, string spriteName)
        {
            return new Tile(_graphicsDevice, _spriteBatch, x, y, spriteName);
        }
    }
}