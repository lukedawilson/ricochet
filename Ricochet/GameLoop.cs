using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ricochet
{
    /// <summary>
    /// This is our main program.
    /// </summary>
    public class GameLoop : Game
    {
        private const int ScreenWidth = 700;
        private const int ScreenHeight = 500;

        private const double Gravity = 1;

        private const int BallRadius = 25;

        private SpriteBatch _spriteBatch;
        private Ball _ball;

        public GameLoop()
        {
            var manager = new GraphicsDeviceManager(this);
            manager.PreferredBackBufferWidth = ScreenWidth;
            manager.PreferredBackBufferHeight = ScreenHeight;

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
            _ball = new Ball(GraphicsDevice, _spriteBatch, ScreenWidth, ScreenHeight, BallRadius, Gravity);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.Escape))
            {
                Exit();
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
            _ball.Draw();
            base.Draw(gameTime);
        }

        private static bool IsKeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}