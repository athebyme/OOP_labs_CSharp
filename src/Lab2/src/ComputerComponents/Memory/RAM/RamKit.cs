using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.RamType;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM;

public class RamKit : Ram, IPriceOwner
{
    public RamKit(
        string model,
        Frequency frequency,
        Power power,
        RamTypes ramType,
        XmpProfile? xmpProfile,
        MemorySize memorySize,
        int packOf,
        Price price)
        : base(model, frequency, power, ramType, xmpProfile, memorySize)
    {
        Price = price ?? throw new ParamNullException();
        PackOf = packOf;
    }

    public int PackOf { get; }
    public Price Price { get; }
}