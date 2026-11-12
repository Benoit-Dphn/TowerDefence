namespace TowerDefence.Models.Towers;

using TowerDefence.Models;

public abstract class Tower
{
    public GridPosition Position { get; }
    public int Level { get; private set; } = 1;
    public double Range { get; protected set; }
    public double Damage { get; protected set; }
    public double FireRate { get; protected set; }
    public int Cost { get; }
    public ITargetingStrategy Targeting { get; set; } = new NearestTargeting();

    private double _cooldown;

    protected Tower(GridPosition position, int cost)
    {
        Position = position;
        Cost = cost;
    }

    public void Update(double dt, IEnumerable<Enemy> enemies)
    {
        _cooldown -= dt;
        if (_cooldown > 0) return;

        var inRange = enemies.Where(e => IsInRange(e));
        var target = Targeting.SelectTarget(this, inRange);
        if (target == null) return;

        Attack(target, enemies);
        _cooldown = 1.0 / FireRate;
    }

    protected abstract void Attack(Enemy target, IEnumerable<Enemy> allEnemies);
}