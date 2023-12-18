using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;

public class CentralProcessingUnit : IVoltageProvider, IFrequencyProvider, ITdpProvider, IPowerUser, IPriceOwner
{
    public CentralProcessingUnit(
        string model,
        Voltage voltage,
        Frequency frequency,
        ThermalDesignPower thermalDesignPower,
        int coreCount,
        bool hasMultiThreading,
        bool hasIntegratedGraphics,
        Frequency supportedMemoryFrequency,
        Power power,
        Socket socket,
        Price price)
    {
        if (coreCount < 0) throw new ParameterIsOutOfAvailableRangeException();
        Model = model ?? throw new ParamNullException();
        Voltage = voltage ?? throw new ParamNullException();
        Frequency = frequency ?? throw new ParamNullException();
        ThermalDesignPower = thermalDesignPower ?? throw new ParamNullException();
        Price = price ?? throw new ParamNullException();
        Power = power ?? throw new ParamNullException();
        CoreCount = coreCount;
        HasIntegratedGraphics = hasIntegratedGraphics;
        SupportedMemoryFrequency = supportedMemoryFrequency;
        Socket = socket;
        ThreadCount = hasMultiThreading ? coreCount * 2 : coreCount;
    }

    public Voltage Voltage { get; private protected init; }
    public Frequency Frequency { get; private protected init; }
    public Frequency SupportedMemoryFrequency { get; private set; }
    public ThermalDesignPower ThermalDesignPower { get; set; }
    public Power Power { get; }
    public Price Price { get; }

    public Socket Socket { get; private set; }
    public bool HasIntegratedGraphics { get; private set; }
    public int CoreCount { get; private set; }
    public int ThreadCount { get; private set; }
    public string Model { get; }
}