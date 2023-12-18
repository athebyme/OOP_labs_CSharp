using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

public class Watt
{
    public Watt(int maxWattConsuming)
    {
        if (maxWattConsuming < 0) throw new ParamOutOfRangeException();
        MaxWattConsuming = maxWattConsuming;
    }

    public int MaxWattConsuming { get; private set; }
}