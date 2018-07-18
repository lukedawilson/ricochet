using System.Collections.Generic;
using System.Linq;

namespace Ricochet.Elements
{
    public class Screen
    {
        public const int Width = 13;
        public const int Height = 9;
        
        private readonly Tile[,] _tiles = new Tile[Width, Height]; // (rows, cols)

        public void AddTile(Tile tile)
        {
            _tiles[tile.X, tile.Y] = tile;
        }

        public IReadOnlyCollection<Tile> Tiles => _tiles.Cast<Tile>().Where(tile => tile != null).ToArray();

        public void Draw()
        {
            foreach (var tile in _tiles)
            {
                tile?.Draw();
            }
        }

        // ToDo: return list of tiles, for ball physics
    }
}