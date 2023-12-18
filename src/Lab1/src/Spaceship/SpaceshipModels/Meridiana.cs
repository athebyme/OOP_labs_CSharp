using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels.DeflectorModifications;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipModels;

public class Meridiana : Spaceship
{
    private static readonly IReadOnlyCollection<Engine.Engine> MeridianaEngines = new List<Engine.Engine> { new ImpulseE() };

    public Meridiana()
        : base(
            MeridianaEngines,
            MeridianaBaseDeflector,
            MeridianaBaseHullType)
    {
    }

    private static Deflector.Deflector MeridianaBaseDeflector { get; } = new NeutrinoDeflector(new DeflectorClassB());
    private static HullType MeridianaBaseHullType { get;  set; } = HullType.BClassHull;
}