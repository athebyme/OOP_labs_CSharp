using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public abstract class Deflector
{
    protected Deflector(decimal health)
    {
        if (health < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(health)} < 0 !");
        Health = health;
    }

    public decimal Health { get; private set; }
    public void GetDamage(decimal value)
    {
        if (value < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(value)} is out of range");
        Health -= value;
    }

    public virtual DeflectorModifications DeflectorModification() => DeflectorModifications.Default;

    public bool IsWorking() => Health > 0;
}