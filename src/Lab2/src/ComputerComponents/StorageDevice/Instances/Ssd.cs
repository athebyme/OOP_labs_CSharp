using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Expansions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice.Instances;

public class Ssd : InformationStorage, IModelStringNameOwner
{
    public Ssd(string model, Power power, MemorySize memorySize, Price price, ExpansionType connectionType)
        : base(power, memorySize, price)
    {
        Model = model ?? throw new ParamNullException();
        ConnectionType = connectionType;
    }

    public override ExpansionType ConnectionType { get; }
    public string Model { get; }
}