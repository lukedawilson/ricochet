﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Klotski.Elements
{
    public class Tile
    {
        public int X { get; }
        public int Y { get; }

        public const int TileDimension = 100;

        private readonly Texture2D _texture;
        private readonly Rectangle _position;

        public Tile(
            int x, int y, string image)
        {
            X = x;
            Y = y;

            var yFromTop = Screen.Height - 1 - y;
            var rawY = yFromTop * TileDimension;
            var rawX = x * TileDimension;

            _position = new Rectangle(rawX, rawY, TileDimension, TileDimension);
            using (var stream = TitleContainer.OpenStream($"Content/img/{image}")) // ToDo: this should be done using a `Content.mgcb` file, but I couldn't get it to work
                _texture = Texture2D.FromStream(GameLoopBase.GraphicsDevice, stream);
        }

        public void Draw()
        {
            GameLoopBase.SpriteBatch.Begin();
            GameLoopBase.SpriteBatch.Draw(_texture, _position, null, Color.White);
            GameLoopBase.SpriteBatch.End();
        }

        public Rectangle Boundary => _position;
    }
}