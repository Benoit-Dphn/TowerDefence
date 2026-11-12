namespace TowerDefence.Models;

using TowerDefence.Models.Towers;

public enum TileType { Path, Buildable, Spawn, Base }

public class Tile
{
    public TileType Type { get; }
    public Tower? Tower { get; set; }   // null = case libre

    public Tile(TileType type) => Type = type;

    public bool CanBuild => Type == TileType.Buildable && Tower == null;
}