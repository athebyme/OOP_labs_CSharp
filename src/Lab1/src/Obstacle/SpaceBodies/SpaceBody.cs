using Itmo.ObjectOrientedProgramming.Lab1.Damage.DamageModels.Physical;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpaceBodies;

public abstract class SpaceBody
{
    protected SpaceBody(decimal damage)
    {
        Damage = new PhysicalDamage(damage);
    }

    public Damage.Damage Damage { get; private set; }
}