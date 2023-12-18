namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public abstract class Engine
{
    protected Engine(decimal fuelUsage, decimal power)
    {
        FuelUsage = fuelUsage;
        Power = power;
    }

    public decimal FuelUsage { get; private set; }
    public decimal Cpa { get; private protected init; }
    public bool CanJump { get; private protected init; }
    protected decimal Velocity { get; private protected init; }
    private decimal Power { get; set; }
    public decimal EngineUtilityCoefficient() => Velocity * Cpa * Power / FuelUsage;
}