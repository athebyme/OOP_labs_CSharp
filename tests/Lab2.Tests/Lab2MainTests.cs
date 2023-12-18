using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComponentsInstances.MotherBoards.Chipsets.AMD;
using Itmo.ObjectOrientedProgramming.Lab2.ComponentsInstances.MotherBoards.Chipsets.Intel;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.ComputerCase.ComputerCaseTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystem.Instances;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GraphicsProcessor;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.RamType;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.MotherBoardsTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.OtherComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice.Instances;
using Itmo.ObjectOrientedProgramming.Lab2.Director;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.PostFactBuildExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Expansions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;
using Itmo.ObjectOrientedProgramming.Lab2.PC;
using Itmo.ObjectOrientedProgramming.Lab2.Warehouse;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Lab2MainTests
{
    private readonly List<GraphicsProcessingUnit> _gpus = new()
    {
        new GraphicsProcessingUnit("GT 1030", new Power(30), new Frequency(1265, 1544), new MemorySize(2), ExpansionType.Create(1), 111, new Price(7000)),
        new GraphicsProcessingUnit("GTX 1050 Ti", new Power(75), new Frequency(1290, 1392), new MemorySize(4), ExpansionType.Create(1), 135, new Price(12000)),
        new GraphicsProcessingUnit("RTX 3050", new Power(130), new Frequency(1510, 1780), new MemorySize(8), ExpansionType.Create(1), 130, new Price(30000)),
        new GraphicsProcessingUnit("RTX 3060", new Power(200), new Frequency(1410, 1670), new MemorySize(8), ExpansionType.Create(1), 150, new Price(41000)),
        new GraphicsProcessingUnit("RTX 4070", new Power(285), new Frequency(2310, 2610), new MemorySize(12), ExpansionType.Create(1), 200, new Price(77000)),
        new GraphicsProcessingUnit("RX 580", new Power(185), new Frequency(1257, 1340), new MemorySize(8), ExpansionType.Create(1), 160, new Price(17000)),
    };

    private readonly List<CentralProcessingUnit> _cpus = new()
    {
            new CentralProcessingUnit("Ryzen R3 1200", new Voltage(1.225m), new Frequency(3100, 3400), new ThermalDesignPower(65), 4, false, false, new Frequency(1200, 3200), new Power(65), new Am4(), new Price(3000)),
            new CentralProcessingUnit("Ryzen R3 2400G", new Voltage(1.28m), new Frequency(3600, 3900), new ThermalDesignPower(65), 4,  true, true, new Frequency(1200, 3600), new Power(85), new Am4(), new Price(10000)),
            new CentralProcessingUnit("Ryzen R5 5600", new Voltage(1.3m),  new Frequency(3200, 4600), new ThermalDesignPower(65), 6, true, false, new Frequency(1200, 4200), new Power(100), new Am4(), new Price(15000)),
            new CentralProcessingUnit("Intel Core i3 12000F", new Voltage(1.2m), new Frequency(3300, 4300), new ThermalDesignPower(90), 4, true, true, new Frequency(1200, 4800), new Power(90), new Lga1700(), new Price(12000)),
            new CentralProcessingUnit("Intel Core i5 13400F", new Voltage(1.3m), new Frequency(2500, 4600), new ThermalDesignPower(155), 10,  true, true, new Frequency(2000, 4800), new Power(160), new Lga1700(), new Price(23000)),
            new CentralProcessingUnit("Intel Core i7 13700K", new Voltage(1.4m), new Frequency(3400, 5400), new ThermalDesignPower(255), 16,  true, true, new Frequency(2000, 5600), new Power(260),  new Lga1700(), new Price(54000)),
    };

    private readonly List<CpuFan> _cpuFans = new()
    {
        new CpuFan("DEEPCOOL Theta 21 PWM", new ThermalDesignPower(95), new Power(12), new List<Socket> { new Lga1700() }, new Price(600)),
        new CpuFan("DEEPCOOL GAMMAXX 300", new ThermalDesignPower(130), new Power(13),  new List<Socket> { new Lga1700(), new Am4() }, new Price(999)),
        new CpuFan("DEEPCOOL GAMMAXX 400K", new ThermalDesignPower(180), new Power(15), new List<Socket> { new Lga1700(), new Am4() }, new Price(1500)),
        new CpuFan("ID-COOLING SE-214-XT", new ThermalDesignPower(180), new Power(15), new List<Socket> { new Lga1700(), new Am4() }, new Price(2299)),
        new CpuFan("ID-Cooling FROSTFLOW X 120", new ThermalDesignPower(200), new Power(20), new List<Socket> { new Lga1700(), new Am4() }, new Price(3099)),
        new CpuFan("NZXT Kraken Z73 RGB", new ThermalDesignPower(500), new Power(30), new List<Socket> { new Lga1700(), new Am4() }, new Price(57800)),
    };

    private readonly List<MotherBoard> _motherBoards = new()
    {
      new MotherBoard("GIGABYTE B450M DS3H", new ChipsetB450(), new List<ExpansionType> { ExpansionType.Create(1), ExpansionType.Create(1), ExpansionType.Create(3), ExpansionType.Create(4), ExpansionType.Create(4), }, MotherBoardTypes.Create(2), new Bios("F64b", new List<Socket> { new Am4() }), 4, RamTypes.Create(2), new Price(7000)),
      new MotherBoard("ASRock A520M-ITX/ac", new ChipsetA520(), new List<ExpansionType> { ExpansionType.Create(1), ExpansionType.Create(3), ExpansionType.Create(4), ExpansionType.Create(4), }, MotherBoardTypes.Create(3), new Bios("A31", new List<Socket> { new Am4() }), 2, RamTypes.Create(2), new Price(4500)),
      new MotherBoard("ASRock X570 Steel Legend", new ChipsetX570(), new List<ExpansionType> { ExpansionType.Create(1), ExpansionType.Create(1), ExpansionType.Create(2), ExpansionType.Create(2), ExpansionType.Create(4), ExpansionType.Create(4), ExpansionType.Create(3) }, MotherBoardTypes.Create(1), new Bios("X12-Cs", new List<Socket> { new Am4() }), 4, RamTypes.Create(2), new Price(17000)),
      new MotherBoard("DEXP H610M-HVS/DX", new ChipsetH610(), new List<ExpansionType> { ExpansionType.Create(1), ExpansionType.Create(2), ExpansionType.Create(2), ExpansionType.Create(4), ExpansionType.Create(3), }, MotherBoardTypes.Create(2), new Bios("D9-f", new List<Socket> { new Lga1700() }), 2, RamTypes.Create(2), new Price(11000)),
      new MotherBoard("ASUS PRIME H770-PLUS D4", new ChipsetH770(), new List<ExpansionType> { ExpansionType.Create(1), ExpansionType.Create(1), ExpansionType.Create(4), ExpansionType.Create(2), ExpansionType.Create(4), ExpansionType.Create(4) }, MotherBoardTypes.Create(1), new Bios("X12-Cs", new List<Socket> { new Lga1700() }), 4, RamTypes.Create(2), new Price(14000)),
      new MotherBoard("GIGABYTE Z790 AORUS ELITE AX-W", new ChipsetZ790(), new List<ExpansionType> { ExpansionType.Create(1), ExpansionType.Create(3), ExpansionType.Create(2), ExpansionType.Create(2), ExpansionType.Create(4), ExpansionType.Create(4) }, MotherBoardTypes.Create(1), new Bios("ZF18", new List<Socket> { new Lga1700() }), 4, RamTypes.Create(3), new Price(25000)),
    };

    private readonly List<ComputerCase> _computerCases = new()
    {
        new ComputerCase("Accord A-08B", new List<int> { 1, 2, 3 }.AsReadOnly(), 290, ComputerCaseType.Create(2), new Price(2790), null),
        new ComputerCase("Zalman i3 edge", new List<int> { 1, 2, 3, }.AsReadOnly(), 360, ComputerCaseType.Create(3), new Price(6900), null),
        new ComputerCase("Thermaltake Core V1 Snow", new List<int> { 3 }.AsReadOnly(), 255, ComputerCaseType.Create(4), new Price(7350), null),
        new ComputerCase("Thermaltake CTE C750 Air", new List<int> { 1, 2, 3, }.AsReadOnly(), 420, ComputerCaseType.Create(2), new Price(25000), null),
        new ComputerCase("ATX Zalman S2", new List<int> { 1, 2, 3, }.AsReadOnly(), 330, ComputerCaseType.Create(1), new Price(5020), null),
        new ComputerCase("FOXLINE FL-301-FZ500R", new List<int> { 1, 2, 3, }.AsReadOnly(), 240, ComputerCaseType.Create(1), new Price(5190), new PowerSupply("KCAS", new Power(500), new Price(0))),
        new ComputerCase("NZXT H1 v2 Mini-ITX", new List<int> { 3 }.AsReadOnly(), 450, ComputerCaseType.Create(3), new Price(179000), new PowerSupply("NZXT", new Power(750), new Price(0))),
        new ComputerCase("NZXT H1 v2 ATX-ITX", new List<int> { 1, 2, 3, }.AsReadOnly(), 450, ComputerCaseType.Create(1), new Price(189000), new PowerSupply("NZXT", new Power(750), new Price(0))),
    };

    private readonly List<PowerSupply> _powerSupplies = new()
    {
        new PowerSupply("KCAS PLUS 150 W", new Power(150), new Price(200)),
        new PowerSupply("KCAS PLUS 500 W", new Power(500), new Price(2000)),
        new PowerSupply("KCAS PLUS 600 W", new Power(600), new Price(3500)),
        new PowerSupply("KCAS PLUS 700 W", new Power(700), new Price(5200)),
        new PowerSupply("KCAS PLUS 800 W", new Power(800), new Price(7800)),
        new PowerSupply("KCAS PLUS 1 KW", new Power(1000), new Price(12000)),
        new PowerSupply("KCAS PLUS 2 KW", new Power(2000), new Price(20000)),
        new PowerSupply("NZXT C1200", new Power(1200), new Price(28000)),
    };

    private readonly List<RamKit> _ramKits = new()
    {
        new RamKit("Patriot Signature Line Premium", new Frequency(2666, 2666), new Power(20), RamTypes.Create(2), null, new MemorySize(8), 1, new Price(1500)),
        new RamKit("Crucial CT8G4DFRA266", new Frequency(2666, 3200), new Power(20), RamTypes.Create(2), null, new MemorySize(8), 1, new Price(1999)),
        new RamKit("Crucial Pro RAM 32GB Kit", new Frequency(5600, 5600), new Power(30), RamTypes.Create(3), new XmpProfile(new Timings(46, 45, 45, 19), new Voltage(1.13m), new Frequency(1000, 5600)), new MemorySize(16), 2, new Price(12000)),
        new RamKit("Crucial CT8G4DFRA261", new Frequency(2666, 3200), new Power(20), RamTypes.Create(2), null, new MemorySize(8), 2, new Price(4300)),
    };

    private readonly List<InformationStorage> _drives = new()
    {
        new Ssd("SATA накопитель Silicon Power Slim S55", new Power(5), new MemorySize(240), new Price(2000), ExpansionType.Create(4)),
        new Ssd("M.2 накопитель Patriot P300", new Power(5), new MemorySize(256), new Price(2190), ExpansionType.Create(3)),
        new Ssd("M.2 накопитель Samsung 970 EVO Plus", new Power(5), new MemorySize(1024), new Price(9390), ExpansionType.Create(3)),
        new Ssd("Жесткий диск Toshiba DT01", new Power(5), new MemorySize(1000), new Price(4999), ExpansionType.Create(4)),
        new Ssd("WD Purple Surveillance", new Power(5), new MemorySize(1024), new Price(5899), ExpansionType.Create(4)),
    };

    [Fact]
    public void TestOne()
    {
        // Arrange
        var shop = new Shop();
        AddProductsToRepo(shop);

        // Act
        GraphicsProcessingUnit graphicsProcessingUnit = shop.WarehouseGpuRepository.CheapestOne();
        CentralProcessingUnit centralProcessingUnit = shop.WarehouseCpuRepository.CheapestOne();
        ComputerCase computerCase = shop.WarehouseCaseRepository.BestOne(pcase => pcase.MaxGpuWidth >= graphicsProcessingUnit.GpuWidth);
        MotherBoard motherboard = shop.WarehouseMotherboardRepository.CheapestOne();
        RamKit ram = shop.WarehouseRamRepository.CheapestOne();
        CpuFan cpuFan = shop.WarehouseCpuFanSectionRepository.BestOne(fan => fan.ThermalDesignPower.TdpValue >= centralProcessingUnit.ThermalDesignPower.TdpValue);
        PowerSupply powerSupply = shop.WarehousePowerSupplyRepository.BestOne(ps => ps.Power.Watt.MaxWattConsuming > (centralProcessingUnit.Power.Watt.MaxWattConsuming + graphicsProcessingUnit.Power.Watt.MaxWattConsuming));
        var hardDrives = new List<InformationStorage>
        {
            shop.WarehouseDrivesRepository.CheapestOne(),
            shop.WarehouseDrivesRepository.TopByPrice(),
        };
        var director = new DirectorPcBuilder(new Builder.Builder());

        Computer pc = director.BuildComputer(
            powerSupply,
            hardDrives,
            centralProcessingUnit,
            graphicsProcessingUnit,
            motherboard,
            ram,
            null,
            computerCase,
            cpuFan);

        // Assert
        Assert.NotNull(pc);
    }

    [Fact]
    public void TestPcPowerSupplyCantServePc()
    {
        // Arrange
        var shop = new Shop();
        AddProductsToRepo(shop);

        // Act
        GraphicsProcessingUnit graphicsProcessingUnit = shop.WarehouseGpuRepository.TopByPrice();
        CentralProcessingUnit centralProcessingUnit = shop.WarehouseCpuRepository.TopByPrice();
        ComputerCase computerCase = shop.WarehouseCaseRepository.TopByPrice();
        MotherBoard motherboard = shop.WarehouseMotherboardRepository.TopByPrice();
        RamKit ram = shop.WarehouseRamRepository.TopByPrice();
        CpuFan cpuFan = shop.WarehouseCpuFanSectionRepository.BestOne(fan => fan.ThermalDesignPower.TdpValue >= centralProcessingUnit.ThermalDesignPower.TdpValue);
        PowerSupply powerSupply = shop.WarehousePowerSupplyRepository.CheapestOne();
        var hardDrives = new List<InformationStorage>
        {
            shop.WarehouseDrivesRepository.CheapestOne(),
        };
        var director = new DirectorPcBuilder(new Builder.Builder());

        // Assert
        Assert.Throws<PowerSupplyCantServeComputerException>(() =>
            director.BuildComputer(
            powerSupply,
            hardDrives,
            centralProcessingUnit,
            graphicsProcessingUnit,
            motherboard,
            ram,
            null,
            computerCase,
            cpuFan));
    }

    [Fact]
    public void TestPcCpuFanDoesNotScatterCpuTdp()
    {
        // Arrange
        var shop = new Shop();
        AddProductsToRepo(shop);

        // Act
        GraphicsProcessingUnit graphicsProcessingUnit = shop.WarehouseGpuRepository.TopByPrice();
        CentralProcessingUnit centralProcessingUnit = shop.WarehouseCpuRepository.TopByPrice();
        ComputerCase computerCase = shop.WarehouseCaseRepository.TopByPrice();
        MotherBoard motherboard = shop.WarehouseMotherboardRepository.TopByPrice();
        RamKit ram = shop.WarehouseRamRepository.TopByPrice();
        CpuFan cpuFan = shop.WarehouseCpuFanSectionRepository.CheapestOne();
        PowerSupply powerSupply = shop.WarehousePowerSupplyRepository.CheapestOne();
        var hardDrives = new List<InformationStorage>
        {
            shop.WarehouseDrivesRepository.CheapestOne(),
        };
        var director = new DirectorPcBuilder(new Builder.Builder());

        // Assert
        Assert.Throws<CpuFanDoesNotScatterEnoughTdp>(() =>
            director.BuildComputer(
                powerSupply,
                hardDrives,
                centralProcessingUnit,
                graphicsProcessingUnit,
                motherboard,
                ram,
                new WifiAdapter(new Power(1), 6, 5, true),
                computerCase,
                cpuFan));
    }

    [Fact]
    public void TestPcMotherBoardDoesNotSupportRamType()
    {
        // Arrange
        var shop = new Shop();
        AddProductsToRepo(shop);

        // Act
        GraphicsProcessingUnit graphicsProcessingUnit = shop.WarehouseGpuRepository.CheapestOne();
        CentralProcessingUnit centralProcessingUnit = shop.WarehouseCpuRepository.CheapestOne();
        ComputerCase computerCase = shop.WarehouseCaseRepository.TopByPrice();
        MotherBoard motherboard = shop.WarehouseMotherboardRepository.CheapestOne();
        RamKit ram = shop.WarehouseRamRepository.TopByPrice();
        CpuFan cpuFan = shop.WarehouseCpuFanSectionRepository.CheapestOne();
        PowerSupply powerSupply = shop.WarehousePowerSupplyRepository.CheapestOne();
        var hardDrives = new List<InformationStorage>
        {
            shop.WarehouseDrivesRepository.CheapestOne(),
        };
        var director = new DirectorPcBuilder(new Builder.Builder());

        // Assert
        Assert.Throws<MotherboardDoesNotSupportRamType>(() =>
            director.BuildComputer(
                powerSupply,
                hardDrives,
                centralProcessingUnit,
                graphicsProcessingUnit,
                motherboard,
                ram,
                null,
                computerCase,
                cpuFan));
    }

    private void NewGpuDelivery(IDeliverable<GraphicsProcessingUnit> repo)
    {
        repo.CreateNewDelivery(_gpus);
    }

    private void NewCpuDelivery(IDeliverable<CentralProcessingUnit> repo)
    {
        repo.CreateNewDelivery(_cpus);
    }

    private void NewCpuFanDelivery(IDeliverable<CpuFan> repo)
    {
        repo.CreateNewDelivery(_cpuFans);
    }

    private void NewMotherboardDelivery(IDeliverable<MotherBoard> repo)
    {
        repo.CreateNewDelivery(_motherBoards);
    }

    private void NewRamKitDelivery(IDeliverable<RamKit> repo)
    {
        repo.CreateNewDelivery(_ramKits);
    }

    private void NewPowerSupplyDelivery(IDeliverable<PowerSupply> repo)
    {
        repo.CreateNewDelivery(_powerSupplies);
    }

    private void NewCaseSupplyDelivery(IDeliverable<ComputerCase> repo)
    {
        repo.CreateNewDelivery(_computerCases);
    }

    private void NewDriveDelivery(IDeliverable<InformationStorage> repo)
    {
        repo.CreateNewDelivery(_drives);
    }

    private void AddProductsToRepo(Shop shop)
    {
        NewGpuDelivery(shop.WarehouseGpuRepository);
        NewCpuDelivery(shop.WarehouseCpuRepository);
        NewCpuFanDelivery(shop.WarehouseCpuFanSectionRepository);
        NewMotherboardDelivery(shop.WarehouseMotherboardRepository);
        NewRamKitDelivery(shop.WarehouseRamRepository);
        NewPowerSupplyDelivery(shop.WarehousePowerSupplyRepository);
        NewCaseSupplyDelivery(shop.WarehouseCaseRepository);
        NewDriveDelivery(shop.WarehouseDrivesRepository);
    }
}