using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface ITdpProvider
{
    ThermalDesignPower ThermalDesignPower { get; }
}