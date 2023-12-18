using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipModels;

public class Shuttle : Spaceship
{
    private static readonly IReadOnlyCollection<Engine.Engine> ShuttleEngines = new List<Engine.Engine> { new ImpulseC() };

    public Shuttle()
        : base(
            ShuttleEngines,
            null,
            ShuttleBaseHullType)
    {
    }

    private static HullType ShuttleBaseHullType { get; set; } = HullType.AClassHull;
}