using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.DamageModels.Physical;

public class PhysicalDamage : Damage
{
    public PhysicalDamage(decimal value)
    {
        if (value < 0)
            throw new ParameterIsOutOfAvailableRangeException($"{nameof(value)} cant be < 0 !");
        Value = value;
    }

    public sealed override decimal Value { get; }
}