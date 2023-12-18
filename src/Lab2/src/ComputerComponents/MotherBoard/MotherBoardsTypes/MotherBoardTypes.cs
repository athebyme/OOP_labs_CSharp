using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.MotherBoardsTypes;

public abstract class MotherBoardTypes
{
    public abstract int Code { get; }
    public abstract string Name { get; }

    public static MotherBoardTypes Create(int code)
    {
        return code switch
        {
            1 => new MotherboardAtx(),
            2 => new MotherboardMicroAtx(),
            3 => new MotherboardMiniItx(),
            4 => new MotherboardEAtx(),
            5 => new MotherboardItx(),
            _ => throw new ComponentIsNotFoundException("Неверный код для материнской платы !"),
        };
    }
}