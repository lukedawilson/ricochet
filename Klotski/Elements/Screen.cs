using System.Collections.Generic;
using System.Linq;

namespace Klotski.Elements
{
    public class Screen
    {
        public const int Width = 13;
        public const int Height = 9;
        
        private readonly SquareTile[,] _tiles = new SquareTile[Width, Height]; // (rows, cols)

        public void AddTile(SquareTile tile)
        {
            _tiles[tile.X, tile.Y] = tile;
        }

        public IReadOnlyCollection<SquareTile> Tiles => _tiles.Cast<SquareTile>().Where(tile => tile != null).ToArray();

        public void Draw()
        {
            foreach (var tile in _tiles)
            {
                tile?.Draw();
            }
        }
    }
}