using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ricochet.Shapes;

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

        private readonly Screen _currentScreen;
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

        private Circle _boundary;
        
        public Ball(
            Screen currentScreen,
            GraphicsDevice graphicsDevice, SpriteBatch spriteBatch,
            int screenWidth, int screenHeight, int ballRadius,
            double gravity)
        {
            _currentScreen = currentScreen;
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _ballRadius = ballRadius;
            _gravity = gravity;

            _x = _screenWidth / 2.0;
            _y = 0;
        }

        public void MoveRight()
        {
            _changeX += ChangeX;
        }

        public void MoveLeft()
        {
            _changeX -= ChangeX;
        }

//        public void MoveDown() // for testing purposes
//        {
//            _changeY += ChangeY;
//        }

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
            // Move the ball's center
            _x += _changeX;
            _y += _changeY;
            _boundary = new Circle(_x, _y, _ballRadius);

            // Apply collision logic to tiles
            // ToDo: handle shapes other than squares
            var intersectingTiles = _currentScreen.Tiles.Where(tile => _boundary.Intersects(tile.Boundary)).ToArray();
            foreach (var tile in intersectingTiles)
            {
                var oldX = _x - _changeX;
                var oldY = _y - _changeY;

                if (oldX <= tile.Boundary.Left && oldX <= tile.Boundary.Right && oldY >= tile.Boundary.Top && oldY <= tile.Boundary.Bottom) // hit left of square
                {
                    _changeX *= -BounceRate;
                    _x = tile.Boundary.Left - _ballRadius;
                }
                else if (oldX >= tile.Boundary.Right && oldX >= tile.Boundary.Right && oldY >= tile.Boundary.Top && oldY <= tile.Boundary.Bottom) // hit right of square
                {
                    _changeX *= -BounceRate;
                    _x = tile.Boundary.Right + _ballRadius;
                }

                if (oldY <= tile.Boundary.Top && oldY <= tile.Boundary.Bottom && oldX >= tile.Boundary.Left && oldX <= tile.Boundary.Right) // hit top of square
                {
                    _changeY *= -BounceRate;
                    _y = tile.Boundary.Top - _ballRadius;
                }
                else if (oldY >= tile.Boundary.Bottom && oldY >= tile.Boundary.Top && oldX >= tile.Boundary.Left && oldX <= tile.Boundary.Right) // hit bottom of square
                {
                    _changeY *= -BounceRate;
                    _y = tile.Boundary.Bottom + _ballRadius;
                }
            }
            
            // Apply collision logic to edges of screen
            if (_y >= _screenHeight - _ballRadius)
            {
                _changeY *= -BounceRate;
                _y = _screenHeight - _ballRadius;

            }
            else if (_y <= _ballRadius)
            {
                _changeY *= -BounceRate;
                _y = _ballRadius;
            }
            if (_x >= _screenWidth - _ballRadius)
            {
                _changeX *= -BounceRate;
                _x = _screenWidth - _ballRadius;
            }
            else if (_x <= _ballRadius)
            {
                _changeX *= -BounceRate;
                _x = _ballRadius;
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