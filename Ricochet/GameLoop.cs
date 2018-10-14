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
            _ball = new Ball(_currentLevel.CurrentScreen, Screen.Width * SquareTile.TileDimension, Screen.Height * SquareTile.TileDimension, BallRadius, Gravity);
        }

        public override void UnloadContent()
        {
        }

        public override void Update()
        {
            if (IsRightArrowDown())
            {
                _ball.MoveRight();
            }
            else if (IsLeftArrowDown())
            {
                _ball.MoveLeft();
            }
            else if (IsUpArrowDown())
            {
                _ball.Bounce();
            }
            else if (IsDownArrowDown())
            {
                _ball.MoveDown();
            }
            else if (IsEscDown())
            {
                Exit();
            }
        }

        public override void Draw()
        {
            _currentLevel.Draw();
            _ball.Draw();
        }
    }
}