using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

public class ThermalDesignPower
{
    public ThermalDesignPower(int tdp)
    {
        if (tdp < 0) throw new ParamOutOfRangeException();
        TdpValue = tdp;
    }

    public int TdpValue { get; private set; }
}