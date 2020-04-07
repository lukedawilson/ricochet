using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Klotski.Elements
{
    public abstract class CharacterBase
    {
        protected CharacterBase(int dimension)
        {
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
            var position = new Vector2((float)(X - Dimension/2.0), (float)(yFromTop - Dimension/2.0));

            var diameter = Dimension;
            var colorData = Circle(diameter, Color.Red, Color.Transparent);
            var texture = new Texture2D(GameLoopBase.GraphicsDevice, diameter, diameter);
            texture.SetData(colorData);

            GameLoopBase.SpriteBatch.Begin();
            GameLoopBase.SpriteBatch.Draw(texture, position, null, Color.White);
            GameLoopBase.SpriteBatch.End();
        }

        private static Color[] Circle(int diameter, Color fillColour, Color backgroundColour)
        {
            var colorData = new Color[diameter * diameter];

            var radius = diameter / 2f;
            var radiusSq = radius * radius;

            for (var x = 0; x < diameter; x++)
            {
                for (var y = 0; y < diameter; y++)
                {
                    var index = x * diameter + y;
                    var pos = new Vector2(x - radius, y - radius);
                    if (pos.LengthSquared() <= radiusSq)
                    {
                        colorData[index] = fillColour;
                    }
                    else
                    {
                        colorData[index] = backgroundColour;
                    }
                }
            }

            return colorData;
        }
    }
}
