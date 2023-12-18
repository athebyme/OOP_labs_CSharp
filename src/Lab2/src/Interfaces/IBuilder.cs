using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystem.Instances;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GraphicsProcessor;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.OtherComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice;
using Itmo.ObjectOrientedProgramming.Lab2.PC;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IBuilder
{
    Computer Build();
    void WithCase(ComputerCase computerCase);
    void WithCooler(CpuFan cooler);
    void WithCpu(CentralProcessingUnit centralProcessingUnit);
    void WithGpu(GraphicsProcessingUnit graphicsProcessingUnit);
    void WithHardDrive(IEnumerable<InformationStorage> informationStorage);
    void WithMotherboard(MotherBoard motherBoard);
    void WithPowerSupply(PowerSupply powerSupply);
    void WithRam(RamKit ram);
    void WithWifiAdapter(WifiAdapter wifiAdapter);
}