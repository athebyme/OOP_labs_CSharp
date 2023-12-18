using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.WarpEngines.WarpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipModels;

public class Vacklas : Spaceship
{
    private static readonly IReadOnlyCollection<Engine.Engine> VacklasEngines = new List<Engine.Engine> { new ImpulseE(), new Gamma() };

    public Vacklas()
        : base(
            VacklasEngines,
            VacklasBaseDeflector,
            VacklasBaseHullType)
    {
    }

    private static Deflector.Deflector VacklasBaseDeflector { get; } = new DeflectorClassA();
    private static HullType VacklasBaseHullType { get;  set; } = HullType.BClassHull;
}