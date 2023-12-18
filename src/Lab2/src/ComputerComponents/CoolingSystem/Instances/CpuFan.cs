using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystem.Instances;

public class CpuFan : PCooling, IPriceOwner
{
    public CpuFan(string model, ThermalDesignPower maxThermalDesignPower, Power power, IReadOnlyCollection<Socket> supportedSockets, Price price)
        : base(maxThermalDesignPower, power, supportedSockets)
    {
        Model = model ?? throw new ParamNullException();
        Price = price ?? throw new ParamNullException();
    }

    public string Model { get; }
    public Price Price { get; }
}