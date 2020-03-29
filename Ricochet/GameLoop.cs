using Klotski;
using Klotski.Elements;
using Ricochet.Levels;

namespace Ricochet
{
    internal class GameLoop : GameLoopBase
    {
        private const double Gravity = 1;
        private const int BallRadius = 25;

        private LevelBase _currentLevel;
        private Ball _ball;

        public override string Title => "Ricochet";

        public override void LoadContent()
        { 
            _currentLevel = new Level1();
            _ball = CreateBall();
        }

        public override void UnloadContent()
        {
        }

        private int? _downArrowDownTicks = 0;

        public override void Update()
        {
            if (_ball.ScreenExitHit != null)
            {
                _currentLevel.MoveToScreen(_ball.ScreenExitHit.Item1, _ball.ScreenExitHit.Item2, _ball.ScreenExitHit.Item3);
                _ball = CreateBall();
                return;
            }

            if (IsLeftArrowDown()) _ball.SpinLeft();
            if (IsRightArrowDown()) _ball.SpinRight();
            if (IsEscDown()) Exit();

            if (IsDownArrowDown())
            {
                _downArrowDownTicks = _downArrowDownTicks ?? 0;
                _downArrowDownTicks++;
            }
            else if (_downArrowDownTicks.HasValue)
            {
                _ball.Bounce(_downArrowDownTicks.Value);
                _downArrowDownTicks = null;
            }
        }

        public override void Draw()
        {
            _currentLevel.Draw();
            _ball.Draw();
        }

        private Ball CreateBall()
        {
            return new Ball(_currentLevel.CurrentScreen, Screen.Width * SquareTile.TileDimension, Screen.Height * SquareTile.TileDimension, BallRadius, Gravity);
        }
    }
}