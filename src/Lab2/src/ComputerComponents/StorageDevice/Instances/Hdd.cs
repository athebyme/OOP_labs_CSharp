using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Expansions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice.Instances;

public class Hdd : InformationStorage, IModelStringNameOwner
{
    protected Hdd(string model, Power power, MemorySize memorySize, Price price)
        : base(power, memorySize, price)
    {
        Model = model ?? throw new ParamNullException();
    }

    public override ExpansionType ConnectionType { get; } = ExpansionType.Create(4);
    public string Model { get; }
}