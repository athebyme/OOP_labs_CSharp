using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public abstract class DeflectorDecorator : Deflector
{
    private readonly Deflector _decoratedDeflector;

    protected DeflectorDecorator(Deflector deflector)
        : base(deflector?.Health ?? 0)
    {
        _decoratedDeflector = deflector ?? throw new ArgumentNullException(nameof(deflector), "deflector cannot be null");
    }

    public override DeflectorModifications DeflectorModification() => _decoratedDeflector.DeflectorModification();
}