using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Expansions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice;

public abstract class InformationStorage : IPowerUser, ITernalMemOwner, IPriceOwner
{
    protected InformationStorage(Power power, MemorySize memorySize, Price price)
    {
        Power = power ?? throw new ParamNullException();
        MemorySize = memorySize ?? throw new ParamNullException();
        Price = price ?? throw new ParamNullException();
    }

    public abstract ExpansionType ConnectionType { get; }
    public Power Power { get; }
    public MemorySize MemorySize { get; }
    public Price Price { get; }
}