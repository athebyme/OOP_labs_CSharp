using Itmo.ObjectOrientedProgramming.Lab2.Warehouse.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Warehouse;

public class Shop
{
    public WarehouseCaseRepository WarehouseCaseRepository { get; } = new();
    public WarehouseCpuRepository WarehouseCpuRepository { get; } = new();
    public WarehouseGpuRepository WarehouseGpuRepository { get; } = new();
    public WarehouseMotherboardRepository WarehouseMotherboardRepository { get; } = new();
    public WarehouseRamRepository WarehouseRamRepository { get; } = new();
    public WarehousePowerSupplyRepository WarehousePowerSupplyRepository { get; } = new();
    public WarehouseCpuFanSectionRepository WarehouseCpuFanSectionRepository { get; } = new();
    public WarehouseDrivesRepository WarehouseDrivesRepository { get; } = new();
}