using Klotski;
using Klotski.Elements;
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
            _currentLevel = new Level1();
            _ball = new Ball(Configuration.BallRadius, Configuration.Gravity)
            {
                CurrentLevel = _currentLevel,
                X = Configuration.ScreenWidth / 2.0,
                Y = Configuration.ScreenHeight - Configuration.BallRadius
            };
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