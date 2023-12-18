using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.ComputerCase.ComputerCaseTypes;

public abstract class ComputerCaseType
{
    public abstract int Code { get; }
    public abstract string Name { get; }

    public static ComputerCaseType Create(int code)
    {
        return code switch
        {
            1 => new CaseAtxMidTower(),
            2 => new CaseAtxFullTower(),
            3 => new CaseMiniTower(),
            4 => new CaseDesktop(),
            _ => throw new ComponentIsNotFoundException("Неверный код для создания корпуса !"),
        };
    }
}