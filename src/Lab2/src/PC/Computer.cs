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
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public class Computer
{
    public Computer(
        PowerSupply powerSupply,
        IReadOnlyCollection<InformationStorage> hardDrive,
        CentralProcessingUnit centralProcessingUnit,
        GraphicsProcessingUnit graphicsProcessingUnit,
        MotherBoard motherBoard,
        RamKit ramKit,
        WifiAdapter? wifiAdapter,
        ComputerCase computerCase,
        CpuFan cpuFan)
    {
        PowerSupply = powerSupply;
        HardDrive = hardDrive;
        CentralProcessingUnit = centralProcessingUnit;
        GraphicsProcessingUnit = graphicsProcessingUnit;
        MotherBoard = motherBoard;
        RamKit = ramKit;
        WifiAdapter = wifiAdapter;
        ComputerCase = computerCase;
        CpuFan = cpuFan;
        PowerUsingComponents = new List<IPowerUser>
        {
            powerSupply, centralProcessingUnit, graphicsProcessingUnit, ramKit, cpuFan,
        };
    }

    public PowerSupply PowerSupply { get; }
    public IReadOnlyCollection<InformationStorage> HardDrive { get; }
    public CentralProcessingUnit CentralProcessingUnit { get; }
    public GraphicsProcessingUnit GraphicsProcessingUnit { get; }
    public MotherBoard MotherBoard { get; }
    public RamKit RamKit { get; }
    public WifiAdapter? WifiAdapter { get; }
    public ComputerCase ComputerCase { get; }
    public CpuFan CpuFan { get; }
    public IReadOnlyCollection<IPowerUser> PowerUsingComponents { get; }
}