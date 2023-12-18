using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerSupply;

public class PowerSupply : IPowerUser, IModelStringNameOwner, IPriceOwner
{
    public PowerSupply(string model, Power power, Price price)
    {
        Power = power ?? throw new ParamNullException();
        Price = price ?? throw new ParamNullException();
        Model = model ?? throw new ParamNullException();
    }

    public Power Power { get; }
    public string Model { get; }
    public Price Price { get; }
}