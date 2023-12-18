namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.WarpEngines;

public abstract class WarpEngine : Engine
{
    protected WarpEngine(decimal fuelUsage, decimal power)
        : base(fuelUsage, power)
    {
        CanJump = true;
    }
}