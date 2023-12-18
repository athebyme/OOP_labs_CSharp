namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.EngineModels.ImpulseEngines;

public class ImpulseC : ImpulseEngine
{
    private const int BasePower = 120;
    private const int BaseFuelUsage = 30;
    private const int BaseVelocity = 20;
    private const decimal BaseCpa = 0.7m;

    public ImpulseC()
        : base(BaseFuelUsage, BasePower)
    {
        Cpa = BaseCpa;
        Velocity = BaseVelocity;
    }
}