using Klotski.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Klotski.Elements
{
    public class SquareTile
    {
        public int X { get; }
        public int Y { get; }

        public const int TileDimension = 100;

        private readonly Texture2D _texture;
        protected readonly Rectangle Position;

        public SquareTile(
            int x, int y, string image)
        {
            X = x;
            Y = y;

            var yFromTop = Screen.Height - 1 - y;
            var rawY = yFromTop * TileDimension;
            var rawX = x * TileDimension;

            Position = new Rectangle(rawX, rawY, TileDimension, TileDimension);
            using (var stream = TitleContainer.OpenStream($"Content/img/{image}")) // ToDo: this should be done using a `Content.mgcb` file, but I couldn't get it to work
                _texture = Texture2D.FromStream(GameLoopBase.GraphicsDevice, stream);
        }

        public void Draw()
        {
            GameLoopBase.SpriteBatch.Begin();
            GameLoopBase.SpriteBatch.Draw(_texture, Position, null, Color.White);
            GameLoopBase.SpriteBatch.End();
        }

        public virtual Line[] Boundary => new[]
        {
            new Line(Position.Left, Screen.Height*TileDimension - Position.Top, Position.Right, Screen.Height*TileDimension - Position.Top), 
            new Line(Position.Right, Screen.Height*TileDimension - Position.Top, Position.Right, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Right, Screen.Height*TileDimension - Position.Bottom, Position.Left, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Left, Screen.Height*TileDimension - Position.Bottom, Position.Left, Screen.Height*TileDimension - Position.Top)
        };
    }

    public class BottomLeftTriangleTile : SquareTile
    {
        public BottomLeftTriangleTile(int x, int y, string image) : base(x, y, image)
        {
        }

        public override Line[] Boundary => new[]
        {
            new Line(Position.Left, Screen.Height*TileDimension - Position.Top, Position.Right, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Right, Screen.Height*TileDimension - Position.Bottom, Position.Left, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Left, Screen.Height*TileDimension - Position.Bottom, Position.Left, Screen.Height*TileDimension - Position.Top)
        };
    }

    public class BottomRightTriangleTile : SquareTile
    {
        public BottomRightTriangleTile(int x, int y, string image) : base(x, y, image)
        {
        }

        public override Line[] Boundary => new[]
        {
            new Line(Position.Right, Screen.Height*TileDimension - Position.Top, Position.Right, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Right, Screen.Height*TileDimension - Position.Bottom, Position.Left, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Left, Screen.Height*TileDimension - Position.Bottom, Position.Right, Screen.Height*TileDimension - Position.Top)
        };
    }

    public class TopLeftTriangleTile : SquareTile
    {
        public TopLeftTriangleTile(int x, int y, string image) : base(x, y, image)
        {
        }

        public override Line[] Boundary => new[]
        {
            new Line(Position.Left, Screen.Height*TileDimension - Position.Top, Position.Right, Screen.Height*TileDimension - Position.Top), 
            new Line(Position.Right, Screen.Height*TileDimension - Position.Top, Position.Left, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Left, Screen.Height*TileDimension - Position.Bottom, Position.Left, Screen.Height*TileDimension - Position.Top)
        };
    }

    public class TopRightTriangleTile : SquareTile
    {
        public TopRightTriangleTile(int x, int y, string image) : base(x, y, image)
        {
        }

        public override Line[] Boundary => new[]
        {
            new Line(Position.Left, Screen.Height*TileDimension - Position.Top, Position.Right, Screen.Height*TileDimension - Position.Top), 
            new Line(Position.Right, Screen.Height*TileDimension - Position.Top, Position.Right, Screen.Height*TileDimension - Position.Bottom), 
            new Line(Position.Right, Screen.Height*TileDimension - Position.Bottom, Position.Left, Screen.Height*TileDimension - Position.Top)
        };
    }
}