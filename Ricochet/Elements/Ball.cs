using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ricochet.Elements
{
    /// <summary>
    /// Class to keep track of a ball's location and vector.
    /// </summary>
    public class Ball
    {
        private const double BounceRate = 0.95;
        private const double ChangeX = 0.5;
        private const double ChangeY = 2.0;

        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;

        private readonly int _screenWidth;
        private readonly int _screenHeight;
        private readonly int _ballRadius;

        private readonly double _gravity;

        private double _x;
        private double _y;
        private double _changeX;
        private double _changeY;
        
        public Ball(
            GraphicsDevice graphicsDevice, SpriteBatch spriteBatch,
            int screenWidth, int screenHeight, int ballRadius,
            double gravity)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _ballRadius = ballRadius;
            _gravity = gravity;

            _x = _screenWidth / 2.0;
            _y = _screenWidth / 2.0;
        }

        public void MoveRight()
        {
            _changeX += ChangeX;
        }

        public void MoveLeft()
        {
            _changeX -= ChangeX;
        }

        public void Bounce()
        {
            _changeY -= ChangeY;
        }

        public void Draw()
        {
            UpdateBallPosition();

            var position = new Vector2((float)(_x - _ballRadius), (float)(_y - _ballRadius));

            var diameter = _ballRadius * 2;
            var colorData = Circle(diameter, Color.Red, Color.Transparent);
            var texture = new Texture2D(_graphicsDevice, diameter, diameter);
            texture.SetData(colorData);
            
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, position, null, Color.White);
            _spriteBatch.End();
        }

        private void UpdateBallPosition()
        {
            // ToDo: find intersecting tiles; for each intersecting tile, apply x/y change

            // Move the ball's center
            _x += _changeX;
            _y += _changeY;
            
            // Bounce the ball if needed, and keep in bounds
            if (_y > _screenHeight - _ballRadius || _y < _ballRadius)
            {
                _changeY *= -BounceRate;
                _y = Math.Max(Math.Min(_screenHeight - _ballRadius, _y), _ballRadius);

            }
            if (_x > _screenWidth - _ballRadius || _x < _ballRadius)
            {
                _changeX *= -BounceRate;
                _x = Math.Max(Math.Min(_screenWidth - _ballRadius, _x), _ballRadius);
            }
            
            // Apply gravity
            if (Math.Abs(_changeY) > 1 || _y < _screenHeight - _ballRadius)
                _changeY += _gravity;
        }

        private static Color[] Circle(int diameter, Color fillColour, Color backgroundColour)
        {
            var colorData = new Color[diameter * diameter];

            var diam = diameter / 2f;
            var diamsq = diam * diam;

            for (var x = 0; x < diameter; x++)
            {
                for (var y = 0; y < diameter; y++)
                {
                    var index = x * diameter + y;
                    var pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
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