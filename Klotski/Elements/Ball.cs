using System;
using System.Linq;
using Klotski.Helpers;
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
        private const double BounceRate = 0.5;
        private const double MaxBounceMultiplier = 10.0;
        private const double ChangeX = 0.5;
        private const double ChangeY = 2.0;
        private const double FloatTolerance = 0.001;

        private readonly Screen _currentScreen;

        private readonly int _screenWidth;
        private readonly int _screenHeight;
        private readonly int _ballRadius;

        private readonly double _gravity;

        private double _x;
        private double _y;
        private double _changeX;
        private double _changeY = -BounceRate;

        public Tuple<Side, double, double> ScreenExitHit { get; private set; }
        
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

        public void SpinLeft()
        {
            _changeX -= ChangeX;
        }

        public void SpinRight()
        {
            _changeX += ChangeX;
        }

        public void Bounce(int ticks)
        {
            var potentialX = _x + _changeX;
            var potentialY = _y + _changeY;
            var collision = _currentScreen.Tiles.Any(
                tile => tile.Boundary.Any(
                    wall => GetIntersection(potentialX, potentialY, wall) != null));

            if (collision) _changeY += ChangeY * Math.Min(ticks, MaxBounceMultiplier);
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
            var potentialX = _x + _changeX;
            var potentialY = _y + _changeY;

            // Apply collision logic to tiles
            var collision = false;
            foreach (var tile in _currentScreen.Tiles)
            {
                foreach (var wall in tile.Boundary)
                {
                    if (GetIntersection(potentialX, potentialY, wall) == null)
                        continue;

                    collision = true;

                    if (Math.Abs(wall.X1 - wall.X2) < FloatTolerance) // vertical wall
                    {
                        if (_x < wall.X1 && tile.Boundary.All(w => w.X1 >= wall.X1 && w.X2 >= wall.X1)) // ball --> wall
                        {
                            _x = wall.X1 - _ballRadius;
                        }
                        else if (tile.Boundary.All(w => w.X1 <= wall.X1 && w.X2 <= wall.X1)) // wall <-- ball
                        {
                            _x = wall.X1 + _ballRadius;
                        }

                        _changeX *= -BounceRate;
                    }
                    else if (Math.Abs(wall.Y1 - wall.Y2) < FloatTolerance) // horizontal wall
                    {
                        if (_y < wall.Y1 && tile.Boundary.All(w => w.Y1 >= wall.Y1 && w.Y2 >= wall.Y1)) // ball ^^ wall
                        {
                            _y = wall.Y1 - _ballRadius;
                        }
                        else if (tile.Boundary.All(w => w.Y1 <= wall.Y1 && w.Y2 <= wall.Y1))
                        {
                            _y = wall.Y1 + _ballRadius;
                        }

                        _changeY *= -BounceRate;
                    }
                    else // diagonal wall
                    {
                        var midX = Math.Min(wall.X1, wall.X2) + Math.Abs(wall.X2 - wall.X1) / 2;
                        var midY = Math.Min(wall.Y1, wall.Y2) + Math.Abs(wall.Y2 - wall.Y1) / 2;

                        if (wall.Y1 > wall.Y2) // diagonal \
                        {
                            if (tile.Boundary.All(w => w.X1 <= wall.X2 && w.X2 <= wall.X2)) // bottom-left filled in
                            {
                                _x = midX + _ballRadius;
                                _y = midY + _ballRadius;
                            }
                            else // top-right filled in
                            {
                                _x = midX - _ballRadius;
                                _y = midY - _ballRadius;
                            }
                        }
                        else if (wall.Y1 < wall.Y2) // diagonal /
                        {
                            if (tile.Boundary.All(w => w.X1 <= wall.X1 && w.X2 <= wall.X1)) // top-left filled in
                            {
                                _x = midX + _ballRadius;
                                _y = midY - _ballRadius;
                            }
                            else // bottom-right filled in
                            {
                                _x = midX - _ballRadius;
                                _y = midY + _ballRadius;
                            }
                        }

                        _changeX *= -BounceRate * 0.7;
                        _changeY *= -BounceRate * 0.7;
                    }
                }
            }

            // If edge of screen hit, report this
            Side? side = null;
            if (potentialY >= _screenHeight - _ballRadius) side = Side.Top;
            if (potentialY <= _ballRadius) side = Side.Bottom;
            if (potentialX >= _screenWidth - _ballRadius) side = Side.Right;
            if (potentialX <= _ballRadius) side = Side.Left;
            if (side.HasValue) ScreenExitHit = Tuple.Create(side.Value, potentialX, potentialY);

            // If no collision, move ball normally
            if (!collision)
            {
                _x = potentialX;
                _y = potentialY;
            }

            // Apply gravity
            if (Math.Abs(_changeY) > 1 || _y < _screenHeight - _ballRadius)
                _changeY -= _gravity;
        }

        private Point GetIntersection(double potentialX, double potentialY, Line wall)
        {
            var xDirection = Math.Abs(potentialX - _x) < FloatTolerance ? 0 : (potentialX - _x) / Math.Abs(potentialX - _x);
            var yDirection = Math.Abs(potentialY - _y) < FloatTolerance ? 0 : (potentialY - _y) / Math.Abs(potentialY - _y);

            var trajectory = new Line(_x, _y, potentialX + xDirection * _ballRadius, potentialY + yDirection * _ballRadius);
            var intersection = Geometry.GetIntersection(trajectory, wall);
            return intersection;
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