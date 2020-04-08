using Klotski;
using Klotski.Elements;
using Ricochet.Elements;
using Ricochet.Levels;

namespace Ricochet
{
    internal class GameLoop : GameLoopBase
    {
        private LevelBase _currentLevel;
        private Ball _ball;

        public override string Title => Configuration.Title;

        public override void LoadContent()
        { 
            _ball = new Ball(Configuration.BallDiameter, Configuration.Gravity);

            _currentLevel = new Level1();
            _currentLevel.AddPlayer(_ball);
        }

        public override void UnloadContent()
        {
        }

        private int? _downArrowDownTicks = 0;

        public override void Update()
        {
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
    }
}