using Microsoft.Xna.Framework;

namespace Klotski
{
    public class GameLoopWrapper : Game
    {
        private readonly GameLoopBase _gameLoopBase;

        public GameLoopWrapper(GameLoopBase gameLoopBase)
        {
            _gameLoopBase = gameLoopBase;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = _gameLoopBase.Title;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameLoopBase.Initialize();
            _gameLoopBase.LoadContent();
        }

        protected override void UnloadContent()
        {
            _gameLoopBase.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _gameLoopBase.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _gameLoopBase.Draw();
            base.Draw(gameTime);
        }
    }
}