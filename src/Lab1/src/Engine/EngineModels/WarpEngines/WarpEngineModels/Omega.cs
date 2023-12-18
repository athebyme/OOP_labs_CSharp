namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.WarpEngines.WarpEngineModels;

public class Omega : WarpEngine
{
    private const int BasePower = 250;
    private const int BaseFuelUsage = 75;
    private const int BaseVelocity = 30;
    private const decimal BaseCpa = 0.8m;
    public Omega()
        : base(BaseFuelUsage, BasePower)
    {
        Cpa = BaseCpa;
        Velocity = BaseVelocity;
    }
}