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
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.PostFactBuildExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.PC;

namespace Itmo.ObjectOrientedProgramming.Lab2.Director;

public class DirectorPcBuilder
{
    private Builder.Builder _builder;

    public DirectorPcBuilder(Builder.Builder builder)
    {
        _builder = builder;
    }

    public Computer BuildComputer(
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
        if (centralProcessingUnit == null || graphicsProcessingUnit == null || motherBoard == null ||
            ramKit == null || computerCase == null || cpuFan == null ||
            hardDrive == null || powerSupply == null) throw new ParamNullException();

        _builder.WithCase(computerCase);

        CheckMotherboard(
            motherBoard,
            computerCase.SupportedMotherboardFormFactorCodes.All(ff => ff != motherBoard.MotherBoardFf.Code),
            motherBoard.Chipset.SupportedSockets.All(socket => socket.SocketCode != centralProcessingUnit.Socket.SocketCode));

        CheckCpu(centralProcessingUnit);

        CheckCpuFan(
            cpuFan,
            centralProcessingUnit.ThermalDesignPower.TdpValue);

        CheckRamKit(
            ramKit,
            motherBoard.NumberOfRamSlots,
            motherBoard.Chipset.MaxMemorySize.MemSize,
            motherBoard.SupportedMemoryTypes.Code);

        CheckGpu(
            graphicsProcessingUnit,
            computerCase.MaxGpuWidth);

        CheckPowerSupply(
            powerSupply,
            centralProcessingUnit.Power.Watt.MaxWattConsuming + graphicsProcessingUnit.Power.Watt.MaxWattConsuming);

        CheckDrives(
            hardDrive,
            hardDrive.Count(storage => storage.ConnectionType.Code == 4),
            hardDrive.Count(storage => storage.ConnectionType.Code == 3),
            motherBoard.ExpansionSlots.Count(type => type.Code == 4),
            motherBoard.ExpansionSlots.Count(type => type.Code == 3),
            motherBoard.Chipset.SupportsNvMe);

        if (wifiAdapter != null)
            _builder.WithWifiAdapter(wifiAdapter);

        return _builder.Build();
    }

    private void CheckMotherboard(
        MotherBoard mb,
        bool caseNotFitMotherboard,
        bool motherboardDoesNotSupportCpuSocket)
    {
        if (motherboardDoesNotSupportCpuSocket)
            throw new MotherboardDoesNotSupportCpuSocketException();
        if (caseNotFitMotherboard)
            throw new ComputerCaseDoesNotFitsTheMotherboard();
        _builder.WithMotherboard(mb);
    }

    private void CheckCpu(CentralProcessingUnit cpu)
    {
        _builder.WithCpu(cpu);
    }

    private void CheckCpuFan(
        CpuFan cpuFan,
        int cpuTdp)
    {
        if (cpuFan.ThermalDesignPower.TdpValue < cpuTdp)
            throw new CpuFanDoesNotScatterEnoughTdp();
        _builder.WithCooler(cpuFan);
    }

    private void CheckRamKit(
        RamKit ramKit,
        int motherboardRamSlots,
        int motherboardMaxRamSupported,
        int motherboardRamTypeSupportCode)
    {
        if (motherboardRamSlots < ramKit.PackOf)
            throw new MotherboardDoesNotHaveEnoughRamSlotsException();
        if (motherboardMaxRamSupported < ramKit.MemorySize.MemSize)
            throw new MotherboardDoesNotSupportRamSizeException();
        if (motherboardRamTypeSupportCode != ramKit.RamTypes.Code)
            throw new MotherboardDoesNotSupportRamType();
        _builder.WithRam(ramKit);
    }

    private void CheckGpu(GraphicsProcessingUnit gpu, decimal maxCaseGpuWidth)
    {
        if (gpu.GpuWidth > maxCaseGpuWidth)
            throw new CaseDoesNotFitTheGpuException();
        _builder.WithGpu(gpu);
    }

    private void CheckPowerSupply(PowerSupply ps, int totalPowerUsing)
    {
        if (totalPowerUsing > ps.Power.Watt.MaxWattConsuming) throw new PowerSupplyCantServeComputerException();
        _builder.WithPowerSupply(ps);
    }

    private void CheckDrives(
        IEnumerable<InformationStorage> drives,
        int sataDevicesCount,
        int nvmeDeviceCount,
        int motherBoardSataSlots,
        int motherBoardNvmeSlots,
        bool motherBoardSupportNvme)
    {
        if (motherBoardNvmeSlots < nvmeDeviceCount ||
            motherBoardSataSlots < sataDevicesCount)
            throw new MotherBoardDoesNotHaveEnoughDrivePorts();
        if (!motherBoardSupportNvme && nvmeDeviceCount > 0)
            throw new MotherboardDoesNotSupportNvmeException();
        _builder.WithHardDrive(drives);
    }
}