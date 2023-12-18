using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.WarpEngines.WarpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipModels;

public class Stella : Spaceship
{
    private static readonly IReadOnlyCollection<Engine.Engine> StellaEngines = new List<Engine.Engine> { new ImpulseC(), new Omega() };

    public Stella()
        : base(
            StellaEngines,
            StellaBaseDeflector,
            StellaBaseHullType)
    {
    }

    private static Deflector.Deflector StellaBaseDeflector { get; } = new DeflectorClassA();
    private static HullType StellaBaseHullType { get;  set; } = HullType.AClassHull;
}