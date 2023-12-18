using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

public class Voltage
{
    public Voltage(decimal voltage)
    {
        if (voltage < 0) throw new ParamOutOfRangeException();
        VoltageValue = voltage;
    }

    public decimal VoltageValue { get; private set; }
}