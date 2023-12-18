using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.StorageDevice.StorageDevices;

public abstract class HardDrive
{
    public abstract int Code { get; }
    public abstract string Name { get; }

    public static HardDrive Create(int code)
    {
        return code switch
        {
            1 => new Hdd35(),
            2 => new Hdd25(),
            3 => new M2(),
            _ => throw new ComponentIsNotFoundException("Неизвестный тип устройства записи"),
        };
    }
}