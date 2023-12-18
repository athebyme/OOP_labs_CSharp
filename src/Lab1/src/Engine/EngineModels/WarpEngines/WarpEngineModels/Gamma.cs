namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.WarpEngines.WarpEngineModels;

public class Gamma : WarpEngine
{
    private const int BasePower = 170;
    private const int BaseFuelUsage = 50;
    private const int BaseVelocity = 25;
    private const decimal BaseCpa = 0.75m;
    public Gamma()
        : base(BaseFuelUsage, BasePower)
    {
        Cpa = BaseCpa;
        Velocity = BaseVelocity;
    }
}