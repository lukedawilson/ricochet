using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Klotski.Elements
{
    public abstract class CharacterBase
    {
        private readonly string _image;

        protected CharacterBase(int dimension, string image)
        {
            _image = image;
            Dimension = dimension;
        }

        public LevelBase CurrentLevel { protected get; set; }
        public double X { protected get; set; }
        public double Y { protected get; set; }
        public int Dimension { get; }
        protected abstract void UpdatePosition();

        public void Draw()
        {
            UpdatePosition();

            var yFromTop = CurrentLevel.ScreenHeight - Y;
            var position = new Rectangle((int)X - Dimension/2, (int)yFromTop - Dimension/2, Dimension, Dimension);

            Texture2D texture;
            using (var stream = TitleContainer.OpenStream($"Content/img/{_image}")) // ToDo: this should be done using a `Content.mgcb` file, but I couldn't get it to work
                texture = Texture2D.FromStream(GameLoopBase.GraphicsDevice, stream);

            GameLoopBase.SpriteBatch.Begin();
            GameLoopBase.SpriteBatch.Draw(texture, position, null, Color.White);
            GameLoopBase.SpriteBatch.End();
        }
    }
}
