using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineService;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.StarshipExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public abstract class Spaceship : IRefuable
{
    private readonly SpaceshipEngines _spaceshipEngines;
    private readonly SpaceshipHull _spaceshipHull;

    protected Spaceship(
        IReadOnlyCollection<Engine.Engine> engines,
        Deflector.Deflector? deflector,
        HullType hullType)
    {
        _spaceshipEngines = new SpaceshipEngines(engines);
        Deflector = deflector;
        _spaceshipHull = new SpaceshipHull(hullType);
        Health = _spaceshipHull.Health + (Deflector?.Health ?? 0);
    }

    public bool HasPhotonDeflector => Deflector?.DeflectorModification() is DeflectorModifications.Photon;
    public decimal RemainFuel { get; private set; }
    public bool IsCrewAlive { get; private set; } = true;
    public bool HasNeutrinoDeflector => Deflector?.DeflectorModification() is DeflectorModifications.Neutrino;

    private Deflector.Deflector? Deflector { get; set; }
    private decimal Health { get; set; }

    public decimal FuelRangeConsumption(int range)
    {
        if (range < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(range)} is less than 0");
        return _spaceshipEngines.GetFuelConsumption(range);
    }

    public void Refuel(decimal value)
    {
        if (value < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(value)} = {value} is less than 0");
        RemainFuel += value;
    }

    public bool IsSpaceshipWorking() => Health >= 0;
    public bool CanJump() => _spaceshipEngines.CanJump;
    public decimal MaxReachableRange() => _spaceshipEngines.GetMaxRange(RemainFuel);
    public decimal SpaceshipUtilCoefficientByRange(int range) => _spaceshipEngines.GetFuelConsumption(range);

    public bool IsDeflectorWorking() => Deflector?.IsWorking() ?? false;

    public void Move(int range)
    {
        if (range < 0) throw new ArgumentOutOfRangeException(nameof(range), " cant be < 0  !");
        if (RemainFuel < _spaceshipEngines.GetFuelConsumption(range))
            throw new StarshipIsOutOfFuelException();
        FuelUsed(_spaceshipEngines.GetFuelConsumption(range));
    }

    public void CrewIsDead()
    {
        IsCrewAlive = false;
    }

    public void ChangeDeflector(Deflector.Deflector? deflector)
    {
        Deflector = deflector ?? throw new ArgumentIsNullException();
    }

    public void DeflectorGetsDamage(decimal damage)
    {
        if (Deflector == null) throw new StarshipIsDestroyedException();
        if (damage < 0) throw new ArgumentOutOfRangeException(nameof(damage), " cant be < 0  !");
        Deflector.GetDamage(damage);
        UpdateHealth();
    }

    public void GetDamage(decimal value)
    {
        if (value < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(value)} cant be < 0 !");
        if (Health - value < 0) throw new StarshipIsDestroyedException($"Starship got destroyed");
        Health -= value;
        UpdateHealth();
    }

    private void FuelUsed(decimal value)
    {
        if (value < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(value)} = {value} is less than 0");
        RemainFuel -= value;
    }

    private void UpdateHealth()
    {
        Health = _spaceshipHull.Health + (Deflector?.Health ?? 0);
    }
}