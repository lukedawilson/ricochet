using System;
using Klotski.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Klotski
{
    public abstract class GameLoopBase : IDisposable
    {
        public abstract string Title { get; }

        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update();
        public abstract void Draw();

        internal void Initialize()
        {
            GraphicsDevice = _gameLoopWrapper.GraphicsDevice;            
            SpriteBatch = new SpriteBatch(_gameLoopWrapper.GraphicsDevice);
        }

        internal static GraphicsDevice GraphicsDevice { get; private set; }
        internal static SpriteBatch SpriteBatch { get; private set; }

        private readonly GameLoopWrapper _gameLoopWrapper;

        protected GameLoopBase()
        {
            _gameLoopWrapper = new GameLoopWrapper(this);

            var manager = new GraphicsDeviceManager(_gameLoopWrapper);
            manager.PreferredBackBufferWidth = Screen.Width  * Tile.TileDimension;
            manager.PreferredBackBufferHeight = Screen.Height * Tile.TileDimension;
        }

        public void Run()
        {
            _gameLoopWrapper.Run();
        }

        public void Exit()
        {
            _gameLoopWrapper.Exit();
        }

        protected static bool IsLeftArrowDown()
        {
            return IsKeyDown(Keys.Left);
        }

        protected static bool IsRightArrowDown()
        {
            return IsKeyDown(Keys.Right);
        }

        protected static bool IsUpArrowDown()
        {
            return IsKeyDown(Keys.Up);
        }

        protected static bool IsEscDown()
        {
            return IsKeyDown(Keys.Escape);
        }

        private static bool IsKeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }

        public void Dispose()
        {
            _gameLoopWrapper?.Dispose();
            SpriteBatch?.Dispose();
        }
    }
}