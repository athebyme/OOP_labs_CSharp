using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.WarpEngines.WarpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipModels;

public class Avgure : Spaceship
{
    private static readonly IReadOnlyCollection<Engine.Engine> AvgureBaseEngines = new List<Engine.Engine> { new ImpulseE(), new Alpha() };

    public Avgure()
        : base(
            AvgureBaseEngines,
            AvgureBaseDeflector,
            AvgureBaseHullType)
    {
    }

    private static Deflector.Deflector AvgureBaseDeflector { get; } = new DeflectorClassC();
    private static HullType AvgureBaseHullType { get;  set; } = HullType.CClassHull;
}