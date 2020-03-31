namespace Klotski.Elements
{
    public abstract class TileFactory
    {
        protected TileFactory(string file)
        {
            File = file;
        }

        public string File { get; }
        public abstract TileBase Create(int x, int y, string file);
    }

    public class TileFactory<T>: TileFactory where T: TileBase, new()
    {
        public TileFactory(string file): base(file)
        {
        }

        public override TileBase Create(int x, int y, string file) => new T().Initialise(x, y, file);
    }
}
