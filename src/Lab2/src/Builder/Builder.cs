using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystem.Instances;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GraphicsProcessor;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.OtherComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.PC;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builder;

public class Builder : IBuilder
{
    private List<InformationStorage> _informationStorages = new();
    private CentralProcessingUnit? _cpu;
    private GraphicsProcessingUnit? _gpu;
    private MotherBoard? _motherBoard;
    private CpuFan? _cpuFan;
    private RamKit? _ram;
    private ComputerCase? _computerCase;
    private PowerSupply? _powerSupply;
    private WifiAdapter? _wifiAdapter;
    public void WithCooler(CpuFan cooler)
    {
        _cpuFan = cooler ?? throw new ParamNullException();
    }

    public void WithCpu(CentralProcessingUnit centralProcessingUnit)
    {
        _cpu = centralProcessingUnit ?? throw new ParamNullException();
    }

    public void WithGpu(GraphicsProcessingUnit graphicsProcessingUnit)
    {
        _gpu = graphicsProcessingUnit ?? throw new ParamNullException();
    }

    public void WithMotherboard(MotherBoard motherBoard)
    {
        _motherBoard = motherBoard ?? throw new ParamNullException();
    }

    public void WithRam(RamKit ram)
    {
        _ram = ram ?? throw new ParamNullException();
    }

    public void WithHardDrive(IEnumerable<InformationStorage> informationStorage)
    {
        _informationStorages = informationStorage.ToList() ?? throw new ParamNullException();
    }

    public void WithPowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply ?? throw new ParamNullException();
    }

    public void WithWifiAdapter(WifiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter ?? throw new ParamNullException();
    }

    public void WithCase(ComputerCase computerCase)
    {
        _computerCase = computerCase ?? throw new ParamNullException();
        if (computerCase.PowerSupply != null)
            _powerSupply = computerCase.PowerSupply;
    }

    public Computer Build()
    {
        return new Computer(
            _powerSupply ?? throw new NoComputerComponentException(),
            _informationStorages.AsReadOnly(),
            _cpu ?? throw new NoComputerComponentException(),
            _gpu ?? throw new NoComputerComponentException(),
            _motherBoard ?? throw new NoComputerComponentException(),
            _ram ?? throw new NoComputerComponentException(),
            _wifiAdapter,
            _computerCase ?? throw new NoComputerComponentException(),
            _cpuFan ?? throw new NoComputerComponentException());
    }
}