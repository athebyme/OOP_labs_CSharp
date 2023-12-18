using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength.HullModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength;

public class SpaceshipHull
{
    private readonly Hull _hull;
    public SpaceshipHull(HullType hullType)
    {
        _hull = CreateHull(hullType);
    }

    public decimal Health => _hull.Health;

    private static Hull CreateHull(HullType type)
    {
        return type switch
        {
            HullType.AClassHull => new HullClassA(),
            HullType.BClassHull => new HullClassB(),
            HullType.CClassHull => new HullClassC(),
            _ => throw new ArgumentException("Invalid environment type"),
        };
    }
}