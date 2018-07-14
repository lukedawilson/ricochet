namespace Ricochet.Elements
{
    public class Screen
    {
        public const int Width = 12;
        public const int Height = 9;
        
        private readonly Tile[,] _tiles = new Tile[Width, Height]; // (rows, cols)

        public void AddTile(Tile tile)
        {
            _tiles[tile.X, tile.Y] = tile;
        }

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