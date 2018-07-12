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
        private const int BallRadius = 25;
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private readonly Ball _ball = new Ball(ScreenWidth, ScreenHeight, BallRadius);

        public GameLoop()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = ScreenWidth,
                PreferredBackBufferHeight = ScreenHeight
            };
            
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Bouncing Balls";
            _texture = Circle(BallRadius * 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _ball.MoveRight();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _ball.MoveLeft();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _ball.Bounce();
            }

            _ball.MoveBall();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, new Vector2((float)_ball.X - BallRadius, (float)_ball.Y - BallRadius));
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        
        private Texture2D Circle(int radius)
        {
            var texture = new Texture2D(GraphicsDevice, radius, radius);
            var colorData = new Color[radius*radius];

            var diam = radius / 2f;
            var diamsq = diam * diam;

            for (var x = 0; x < radius; x++)
            {
                for (var y = 0; y < radius; y++)
                {
                    var index = x * radius + y;
                    var pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.Red;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
    }
}