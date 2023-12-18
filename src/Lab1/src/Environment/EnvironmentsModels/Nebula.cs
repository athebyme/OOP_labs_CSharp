namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentsModels;

public abstract class Nebula : Environment
{
    protected Nebula(int range)
    {
        Range = range;
        IsWarpRequired = true;
    }
}