using System;
using System.Linq;
using Klotski;
using Klotski.Elements;
using Klotski.Helpers;
using Point = Klotski.Helpers.Point;

namespace Ricochet.Elements
{
    /// <summary>
    /// Class to keep track of a ball's location and vector.
    /// </summary>
    public class Ball : CharacterBase
    {
        private const double MaxBounceMultiplier = 12.0;
        private const double ChangeX = 0.5;
        private const double ChangeY = 2.0;
        private const double FloatTolerance = 0.001;

        private int BallRadius => Dimension / 2;

        private readonly double _gravity;

        private double _changeX;
        private double _changeY;
        
        public Ball(int ballDiameter, double gravity)
            : base(ballDiameter, "sprite_n.png")
        {
            _gravity = gravity;
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
            var potentialX = X + _changeX;
            var potentialY = Y + _changeY;
            var collision = CurrentLevel.CurrentScreen.Tiles.Any(
                tile => tile.Boundary.Any(
                    wall => GetIntersection(potentialX, potentialY, wall) != null));

            if (collision) _changeY += ChangeY * Math.Min(ticks, MaxBounceMultiplier);
        }

        protected override void UpdatePosition()
        {
            var potentialX = X + _changeX;
            var potentialY = Y + _changeY;

            // Apply collision logic to tiles
            var collision = false;
            foreach (var tile in CurrentLevel.CurrentScreen.Tiles)
            {
                foreach (var wall in tile.Boundary)
                {
                    if (GetIntersection(potentialX, potentialY, wall) == null)
                        continue;

                    collision = true;

                    if (Math.Abs(wall.X1 - wall.X2) < FloatTolerance) // vertical wall
                    {
                        if (X < wall.X1 && tile.Boundary.All(w => w.X1 >= wall.X1 && w.X2 >= wall.X1)) // ball --> wall
                        {
                            X = wall.X1 - BallRadius;
                        }
                        else if (tile.Boundary.All(w => w.X1 <= wall.X1 && w.X2 <= wall.X1)) // wall <-- ball
                        {
                            X = wall.X1 + BallRadius;
                        }

                        _changeX = 0;
                    }
                    else if (Math.Abs(wall.Y1 - wall.Y2) < FloatTolerance) // horizontal wall
                    {
                        if (Y < wall.Y1 && tile.Boundary.All(w => w.Y1 >= wall.Y1 && w.Y2 >= wall.Y1)) // ball ^^ wall
                        {
                            Y = wall.Y1 - BallRadius;
                        }
                        else if (tile.Boundary.All(w => w.Y1 <= wall.Y1 && w.Y2 <= wall.Y1))
                        {
                            Y = wall.Y1 + BallRadius;
                        }

                        _changeY = 0;
                    }
                    else // diagonal wall
                    {
                        if (wall.Y1 > wall.Y2) // diagonal \
                        {
                            if (tile.Boundary.All(w => w.X1 <= wall.X2 && w.X2 <= wall.X2)) // bottom-left filled in
                            {
                                X += BallRadius;
                                Y += BallRadius;
                            }
                            else // top-right filled in
                            {
                                X -= BallRadius;
                                Y -= BallRadius;
                            }
                        }
                        else if (wall.Y1 < wall.Y2) // diagonal /
                        {
                            if (tile.Boundary.All(w => w.X1 <= wall.X1 && w.X2 <= wall.X1)) // top-left filled in
                            {
                                X += BallRadius;
                                Y -= BallRadius;
                            }
                            else // bottom-right filled in
                            {
                                X -= BallRadius;
                                Y += BallRadius;
                            }
                        }

                        _changeX = 0;
                        _changeY = 0;
                    }
                }
            }

            // If no collision, move ball normally
            if (!collision)
            {
                X = potentialX;
                Y = potentialY;
            }

            // Apply gravity
            if (Math.Abs(_changeY) > 1 || Y < CurrentLevel.ScreenHeight - BallRadius)
                _changeY -= _gravity;

            // If edge of screen hit, switch screens and continue
            Side? side = null;
            if (Y >= CurrentLevel.ScreenHeight) side = Side.Top;
            if (Y <= 0) side = Side.Bottom;
            if (X >= CurrentLevel.ScreenWidth) side = Side.Right;
            if (X <= 0) side = Side.Left;
            if (side.HasValue)
            {
                CurrentLevel.MoveBallToScreen(side.Value);
                CurrentLevel.InitialisePlayerPosition(side.Value, this);
            }
        }

        private Point GetIntersection(double potentialX, double potentialY, Line wall)
        {
            var xDirection = Math.Abs(potentialX - X) < FloatTolerance ? 0 : (potentialX - X) / Math.Abs(potentialX - X);
            var yDirection = Math.Abs(potentialY - Y) < FloatTolerance ? 0 : (potentialY - Y) / Math.Abs(potentialY - Y);

            var trajectory = new Line(X, Y, potentialX + xDirection * BallRadius, potentialY + yDirection * BallRadius);
            var intersection = Geometry.GetIntersection(trajectory, wall);
            return intersection;
        }
    }
}