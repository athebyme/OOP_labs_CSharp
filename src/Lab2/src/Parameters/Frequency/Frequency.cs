using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;

public class Frequency
{
    public Frequency(int plainFreq, int overClockedFreq)
    {
        if (plainFreq < 0 || overClockedFreq < 0) throw new ParamOutOfRangeException();
        if (overClockedFreq < plainFreq) throw new ParamComparingLogicException();
        PlainFreq = plainFreq;
        OverClockedFreq = overClockedFreq;
    }

    public int PlainFreq { get; private set; }
    public int OverClockedFreq { get; private set; }
}