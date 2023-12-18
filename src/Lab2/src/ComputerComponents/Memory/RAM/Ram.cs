using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.RamType;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM;

public abstract class Ram : Memory
{
    protected Ram(
        string model,
        Frequency frequency,
        Power power,
        RamTypes ramTypes,
        XmpProfile? xmpProfile,
        MemorySize memorySize)
        : base(frequency, power, memorySize)
    {
        Model = model ?? throw new ParamNullException();
        XmpProfile = xmpProfile;
        RamTypes = ramTypes;
    }

    public XmpProfile? XmpProfile { get; private set; }
    public RamTypes RamTypes { get; private set; }
    public string Model { get; }
}