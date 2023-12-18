namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.ImpulseEngines;

public abstract class ImpulseEngine : Engine
{
    protected ImpulseEngine(decimal fuelUsage, decimal power)
        : base(fuelUsage, power)
    {
        CanJump = false;
    }
}