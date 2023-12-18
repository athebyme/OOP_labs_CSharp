using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.RamType;

public abstract class RamTypes
{
    public abstract int Code { get; }
    public abstract string Name { get; }

    public static RamTypes Create(int code)
    {
        return code switch
        {
            1 => new Ddr3(),
            2 => new Ddr4(),
            3 => new Ddr5(),
            _ => throw new ComponentIsNotFoundException(),
        };
    }
}