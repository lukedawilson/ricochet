using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ricochet.Elements;
using Ricochet.Levels;

namespace Ricochet
{
    /// <summary>
    /// This is our main program.
    /// </summary>
    public class GameLoop : Game
    {
        private const double Gravity = 1;

        private const int BallRadius = 25;

        private SpriteBatch _spriteBatch;

        private LevelBase _currentLevel;
        private Ball _ball;

        public GameLoop()
        {
            var manager = new GraphicsDeviceManager(this);
            manager.PreferredBackBufferWidth = Screen.Width * Tile.TileDimension;
            manager.PreferredBackBufferHeight = Screen.Height * Tile.TileDimension;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Bouncing Balls";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _currentLevel = new Level1(GraphicsDevice, _spriteBatch);
            _ball = new Ball(_currentLevel.CurrentScreen, GraphicsDevice, _spriteBatch, Screen.Width * Tile.TileDimension, Screen.Height * Tile.TileDimension, BallRadius, Gravity);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.Escape))
            {
                //Exit();
            }
            else if (IsKeyDown(Keys.Right))
            {
                _ball.MoveRight();
            }
            else if (IsKeyDown(Keys.Left))
            {
                _ball.MoveLeft();
            }
            else if (IsKeyDown(Keys.Up))
            {
                _ball.Bounce();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _currentLevel.Draw();
            _ball.Draw();
            base.Draw(gameTime);
        }

        private static bool IsKeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}