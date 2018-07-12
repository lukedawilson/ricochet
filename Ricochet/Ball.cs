using System;

namespace Ricochet
{
    /// <summary>
    /// Class to keep track of a ball's location and vector.
    /// </summary>
    public class Ball
    {
        private const int Gravity = 1;
        private const double BounceRate = 0.95;
        private const double ChangeX = 0.5;
        private const double ChangeY = 2.0;

        private readonly int _screenWidth;
        private readonly int _screenHeight;
        private readonly double _ballRadius;

        private double _changeX;
        private double _changeY;

        public double X { get; private set; }
        public double Y { get; private set; }
        
        public Ball(int screenWidth, int screenHeight, double ballRadius)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _ballRadius = ballRadius;
            
            X = _screenWidth / 2.0;
            Y = _screenWidth / 2.0;
        }

        public void MoveRight()
        {
            _changeX += ChangeX;
        }

        public void MoveLeft()
        {
            _changeX -= ChangeX;
        }

        private void ApplyGravity()
        {
            if (Math.Abs(_changeY) > 1 || Y < _screenHeight - _ballRadius)
                _changeY += Gravity;
        }

        public void MoveBall()
        {
            // Move the ball's center
            X += _changeX;
            Y += _changeY;
            
            // Bounce the ball if needed, and keep in bounds
            if (Y > _screenHeight - _ballRadius || Y < _ballRadius)
            {
                _changeY *= -BounceRate;
                Y = Math.Max(Math.Min(_screenHeight - _ballRadius, Y), _ballRadius);

            }
            if (X > _screenWidth - _ballRadius || X < _ballRadius)
            {
                _changeX *= -BounceRate;
                X = Math.Max(Math.Min(_screenWidth - _ballRadius, X), _ballRadius);
            }
            
            // Apply gravity
            ApplyGravity();
        }

        public void Bounce()
        {
            _changeY -= ChangeY;
        }
    }
}