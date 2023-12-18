using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineService;

public class SpaceshipEngines
{
    public SpaceshipEngines(IReadOnlyCollection<Engine> engines)
    {
        if (engines is null) throw new ArgumentNullException(nameof(engines), "Parameter has null value");
        Engines = engines.ToList();
    }

    public bool CanJump => Engines.Any(engine => engine.CanJump);

    private IReadOnlyCollection<Engine> Engines { get; set; }
    public decimal GetMaxRange(decimal fuel)
    {
        if (fuel < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(fuel)} is < 0 !");
        return fuel / AllUtilityCoefficient() * 100;
    }

    public decimal GetFuelConsumption(int range)
    {
        if (range < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(range)} is < 0 !");
        return Math.Round(GetDeployTime(range) * AllFuelConsumption() * Engines.Average(engine => engine.Cpa), 2);
    }

    private decimal GetDeployTime(int range)
    {
        return range / AllUtilityCoefficient();
    }

    private decimal AllFuelConsumption() => Engines.Sum(engine => engine.FuelUsage);
    private decimal AllUtilityCoefficient() => Engines.Sum(engine => engine.EngineUtilityCoefficient());
}