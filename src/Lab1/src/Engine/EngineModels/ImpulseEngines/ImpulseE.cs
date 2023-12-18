namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.ImpulseEngines;

public class ImpulseE : ImpulseEngine
{
    private const int BasePower = 150;
    private const int BaseFuelUsage = 40;
    private const int BaseVelocity = 23;
    private const decimal BaseCpa = 0.7m;
    public ImpulseE()
        : base(BaseFuelUsage, BasePower)
    {
        Cpa = BaseCpa;
        Velocity = BaseVelocity;
    }
}