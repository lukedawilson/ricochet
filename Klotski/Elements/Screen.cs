using System.Collections.Generic;
using System.Linq;

namespace Klotski.Elements
{
    public class Screen
    {
        public const int Width = 13;
        public const int Height = 9;
        
        private readonly TileBase[,] _tiles = new TileBase[Width, Height]; // (rows, cols)

        public void AddTile(TileBase tile)
        {
            _tiles[tile.X, tile.Y] = tile;
        }

        public IReadOnlyCollection<TileBase> Tiles => _tiles.Cast<TileBase>().Where(tile => tile != null).ToArray();

        public void Draw()
        {
            foreach (var tile in _tiles)
            {
                tile?.Draw();
            }
        }
    }
}