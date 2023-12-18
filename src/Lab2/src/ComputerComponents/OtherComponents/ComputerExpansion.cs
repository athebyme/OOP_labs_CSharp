using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.OtherComponents;

public abstract class ComputerExpansion : IPowerUser
{
    protected ComputerExpansion(Power power)
    {
        Power = power;
    }

    public Power Power { get; }
}