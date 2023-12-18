namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.DamageModels.NonPhysical;

public abstract class NonPhysicalDamage : Damage
{
    protected NonPhysicalDamage(decimal value)
    {
        Value = value;
    }

    public sealed override decimal Value { get; }
}