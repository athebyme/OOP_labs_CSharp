using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystem;

public abstract class PCooling : ITdpProvider, IPowerUser
{
    protected PCooling(ThermalDesignPower maxThermalDesignPower, Power power, IReadOnlyCollection<Socket> supportedSockets)
    {
        ThermalDesignPower = maxThermalDesignPower ?? throw new ParamNullException();
        Power = power ?? throw new ParamNullException();
        SupportedSockets = supportedSockets ?? throw new ParamNullException();
    }

    public ThermalDesignPower ThermalDesignPower { get; }
    public Power Power { get; }
    public IReadOnlyCollection<Socket> SupportedSockets { get; private set; }
}