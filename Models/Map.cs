namespace TowerDefence.Models;

public class Map
{
    private readonly Tile[,] _tiles;
    public int Width { get; }
    public int Height { get; }

    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        _tiles = new Tile[width, height];
    }

    public Tile this[int x, int y] => _tiles[x, y];

    public bool IsInside(int x, int y)
        => x >= 0 && x < Width && y >= 0 && y < Height;
}