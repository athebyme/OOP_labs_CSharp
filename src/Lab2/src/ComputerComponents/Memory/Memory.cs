using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory;

public abstract class Memory : IFrequencyProvider, IPowerUser, ITernalMemOwner
{
    protected Memory(Frequency frequency, Power power, MemorySize memorySize)
    {
        Frequency = frequency ?? throw new ParamNullException();
        Power = power ?? throw new ParamNullException();
        MemorySize = memorySize ?? throw new ParamNullException();
    }

    public Frequency Frequency { get; }
    public Power Power { get; }
    public MemorySize MemorySize { get; }
}