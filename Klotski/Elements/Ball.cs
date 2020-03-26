using System;
using System.Linq;
using Klotski.Helpers;
using Klotski.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Point = Klotski.Helpers.Point;

namespace Klotski.Elements
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

        private readonly int _screenWidth;
        private readonly int _screenHeight;
        private readonly int _ballRadius;

        private readonly double _gravity;

        private double _x;
        private double _y;
        private double _changeX;
        private double _changeY = -BounceRate;

        private Circle _boundary;
        
        public Ball(
            Screen currentScreen,
            int screenWidth, int screenHeight, int ballRadius,
            double gravity)
        {
            _currentScreen = currentScreen;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _ballRadius = ballRadius;
            _gravity = gravity;

            _x = _screenWidth / 2.0;
            _y = _screenHeight - _ballRadius;
        }

        public void MoveRight()
        {
            _changeX += ChangeX;
        }

        public void MoveLeft()
        {
            _changeX -= ChangeX;
        }

        public void MoveDown() // for testing purposes
        {
            _changeY -= ChangeY;
        }

        public void Bounce()
        {
            _changeY += ChangeY;
        }

        public void Draw()
        {
            UpdateBallPosition();

            var yFromTop = _screenHeight - _y;
            var position = new Vector2((float)(_x - _ballRadius), (float)(yFromTop - _ballRadius));

            var diameter = _ballRadius * 2;
            var colorData = Circle(diameter, Color.Red, Color.Transparent);
            var texture = new Texture2D(GameLoopBase.GraphicsDevice, diameter, diameter);
            texture.SetData(colorData);
            
            GameLoopBase.SpriteBatch.Begin();
            GameLoopBase.SpriteBatch.Draw(texture, position, null, Color.White);
            GameLoopBase.SpriteBatch.End();
        }

        private void UpdateBallPosition()
        {
            const double tolerance = 0.001;

            var potentialX = _x + _changeX;
            var potentialY = _y + _changeY;
            var potentialBoundary = new Circle(potentialX, potentialY, _ballRadius);

            var collision = false;

            // Apply collision logic to tiles
            //var intersectingTiles = _currentScreen.Tiles.Where(tile => potentialBoundary.Intersects(tile.Boundary)).ToArray();
            foreach (var tile in _currentScreen.Tiles)
            {
                foreach (var wall in tile.Boundary)
                {
                    var xDirection = Math.Abs(potentialX - _x) < tolerance ? 0 : (potentialX - _x) / Math.Abs(potentialX - _x);
                    var yDirection = Math.Abs(potentialY - _y) < tolerance ? 0 : (potentialY - _y) / Math.Abs(potentialY - _y);

                    var trajectory = new Line(_x, _y, potentialX + xDirection*_ballRadius, potentialY + yDirection*_ballRadius);
                    var intersection = Geometry.GetIntersection(trajectory, wall);
                    if (intersection == null)
                        continue;

                    collision = true;

                    if (Math.Abs(wall.X1 - wall.X2) < tolerance) // vertical wall
                    {
                        if (_x < wall.X1) // ball --> wall
                        {
                            _x = wall.X1 - _ballRadius;
                        }
                        else // wall <-- ball
                        {
                            _x = wall.X1 + _ballRadius;
                        }

                        _changeX *= -BounceRate;
                    }
                    else if (Math.Abs(wall.Y1 - wall.Y2) < tolerance) // horizontal wall
                    {
                        if (_y < wall.Y1) // ball ^^ wall
                        {
                            _y = wall.Y1 - _ballRadius;
                        }
                        else
                        {
                            _y = wall.Y1 + _ballRadius;
                        }

                        _changeY *= -BounceRate;
                    }

                    // TODO: diagonal walls
                }
            }

            // Apply collision logic to edges of screen
            if (potentialY >= _screenHeight - _ballRadius)
            {
                _y = _screenHeight - _ballRadius;
                _changeY *= -BounceRate;
            }
            else if (potentialY <= _ballRadius)
            {
                _y = _ballRadius;
                _changeY *= -BounceRate;
            }
            else if (!collision)
            {
                _y = potentialY;
            }

            if (potentialX >= _screenWidth - _ballRadius)
            {
                _x =  _screenWidth - _ballRadius;
                _changeX *= -BounceRate;
            }
            else if (potentialX <= _ballRadius)
            {
                _x = _ballRadius;
                _changeX *= -BounceRate;
            }
            else if (!collision)
            {
                _x = potentialX;
            }

            // Move the ball's center
            _boundary = new Circle(_x, _y, _ballRadius);

            // Apply gravity
            if (Math.Abs(_changeY) > 1 || _y < _screenHeight - _ballRadius)
                _changeY -= _gravity;
        }

        private static double GetXComponent(Line trajectory, Line wall)
        {
            var theta = Geometry.GetAngle(trajectory, wall);
            return Math.Sin(2 * (Math.PI - theta));
        }

        private static double GetYComponent(Line trajectory, Line wall)
        {
            var theta = Geometry.GetAngle(trajectory, wall);
            return Math.Cos(2 * (Math.PI - theta));
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