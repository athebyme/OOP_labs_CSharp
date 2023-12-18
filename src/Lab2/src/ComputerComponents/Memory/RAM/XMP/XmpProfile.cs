using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.XMP;

public class XmpProfile : IVoltageProvider, IFrequencyProvider
{
    public XmpProfile(Timings timings, Voltage voltage, Frequency frequency)
    {
        Timings = timings ?? throw new ParamNullException();
        Voltage = voltage ?? throw new ParamNullException();
        Frequency = frequency ?? throw new ParamNullException();
    }

    public Timings Timings { get; private set; }
    public Voltage Voltage { get; }
    public Frequency Frequency { get; }
}