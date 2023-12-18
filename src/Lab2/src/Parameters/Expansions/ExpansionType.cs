using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Parameters.Expansions;

public abstract class ExpansionType
{
    public abstract int Code { get; }
    public abstract string Name { get; }

    public static ExpansionType Create(int code)
    {
        return code switch
        {
            1 => new PcieX16(),
            2 => new PcieX1(),
            3 => new M2Expansion(),
            4 => new SataExpansion(),
            _ => throw new ComponentIsNotFoundException("Неверный код для расширения !"),
        };
    }
}