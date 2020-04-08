using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Klotski.Elements
{
    public class ElementBase
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public const int Dimension = 100;

        private Texture2D _texture;
        protected Rectangle Position;

        public ElementBase Initialise(int x, int y, string image)
        {
            X = x;
            Y = y;

            var yFromTop = Screen.Height - 1 - y;
            var rawY = yFromTop * Dimension;
            var rawX = x * Dimension;

            Position = new Rectangle(rawX, rawY, Dimension, Dimension);
            using (var stream = TitleContainer.OpenStream($"Content/img/{image}")) // ToDo: this should be done using a `Content.mgcb` file, but I couldn't get it to work
                _texture = Texture2D.FromStream(GameLoopBase.GraphicsDevice, stream);

            return this;
        }

        public void Draw()
        {
            GameLoopBase.SpriteBatch.Begin();
            GameLoopBase.SpriteBatch.Draw(_texture, Position, null, Color.White);
            GameLoopBase.SpriteBatch.End();
        }
    }
}
