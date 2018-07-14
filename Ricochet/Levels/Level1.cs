using Microsoft.Xna.Framework.Graphics;
using Ricochet.Elements;

namespace Ricochet.Levels
{
    public class Level1 : LevelBase
    {
        public Level1(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            var screen1 = new Screen();
            screen1.AddTile(new Tile(graphicsDevice, spriteBatch, 2, 3, "bricks1.png"));
            screen1.AddTile(new Tile(graphicsDevice, spriteBatch, 4, 6, "checker1.png"));
            screen1.AddTile(new Tile(graphicsDevice, spriteBatch, 1, 1, "enemy_square1.png"));

            Screens.Add(screen1);
        }
    }
}