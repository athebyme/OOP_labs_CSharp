using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.OtherComponents;

public class WifiAdapter : ComputerExpansion
{
    public WifiAdapter(Power power, int wifiGeneration, decimal pCieVersion, bool hasBluetooth)
        : base(power)
    {
        if (wifiGeneration < 0) throw new ParamOutOfRangeException($"{wifiGeneration}");
        if (pCieVersion < 0) throw new ParamOutOfRangeException($"{pCieVersion}");
        WifiGeneration = wifiGeneration;
        PCieVersion = pCieVersion;
        HasBluetooth = hasBluetooth;
    }

    public bool HasBluetooth { get; }
    public decimal PCieVersion { get; }
    public int WifiGeneration { get; }
}