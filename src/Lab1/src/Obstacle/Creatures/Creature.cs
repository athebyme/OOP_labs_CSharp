using Itmo.ObjectOrientedProgramming.Lab1.Damage.DamageModels.Physical;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Creatures;

public abstract class Creature
{
    protected Creature(decimal damage)
    {
        Damage = new PhysicalDamage(damage);
    }

    public Damage.Damage Damage { get; private set; }
}