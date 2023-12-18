namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.WarpEngines.WarpEngineModels;

public class Alpha : WarpEngine
{
    private const int BasePower = 130;
    private const int BaseFuelUsage = 35;
    private const int BaseVelocity = 20;
    private const decimal BaseCpa = 0.7m;
    public Alpha()
        : base(BaseFuelUsage, BasePower)
    {
        Cpa = BaseCpa;
        Velocity = BaseVelocity;
    }
}