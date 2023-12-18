using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Expansions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GraphicsProcessor;

public class GraphicsProcessingUnit : IPowerUser, IFrequencyProvider, ITernalMemOwner, IPriceOwner
{
    public GraphicsProcessingUnit(string model, Power power, Frequency frequency, MemorySize memorySize, ExpansionType pcIeVersion, decimal gpuWidth, Price price)
    {
        if (gpuWidth < 0) throw new ParamOutOfRangeException($"{nameof(gpuWidth)}");
        Model = model ?? throw new ParamNullException();
        Power = power ?? throw new ParamNullException();
        Frequency = frequency ?? throw new ParamNullException();
        MemorySize = memorySize ?? throw new ParamNullException();
        Price = price ?? throw new ParamNullException();
        PcIeVersion = pcIeVersion ?? throw new ParamNullException();
        GpuWidth = gpuWidth;
    }

    public string Model { get; }
    public Power Power { get; }
    public Frequency Frequency { get; }
    public MemorySize MemorySize { get; }
    public decimal GpuWidth { get; private set; }
    public ExpansionType PcIeVersion { get; private set; }
    public Price Price { get; }
}