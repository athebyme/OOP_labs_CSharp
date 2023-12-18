using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.ComputerCase.ComputerCaseTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.ComputerCase;

public class ComputerCase : IPriceOwner
{
    public ComputerCase(
        string model,
        IReadOnlyCollection<int> supportedMotherboardFf,
        decimal maxGpuWidth,
        ComputerCaseType caseFf,
        Price price,
        PowerSupply.PowerSupply? powerSupply)
    {
        if (maxGpuWidth < 0) throw new ParamOutOfRangeException();
        SupportedMotherboardFormFactorCodes = supportedMotherboardFf ?? throw new ParamNullException();
        Model = model ?? throw new ParamNullException();
        Price = price ?? throw new ParamNullException();
        PowerSupply = powerSupply;
        MaxGpuWidth = maxGpuWidth;
        CaseFf = caseFf;
    }

    public IReadOnlyCollection<int> SupportedMotherboardFormFactorCodes { get; }
    public ComputerCaseType CaseFf { get; private set; }
    public string Model { get; }
    public PowerSupply.PowerSupply? PowerSupply { get; }
    public decimal MaxGpuWidth { get; private init; }
    public Price Price { get; }
}