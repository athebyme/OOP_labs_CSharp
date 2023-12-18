using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.ChipSet;

public abstract class Chipset
{
    protected Chipset(bool supportsXmp, bool supportsNvMe, Frequency maxSupportedFrequency, IReadOnlyCollection<Socket> supportedSockets)
    {
        SupportsXmp = supportsXmp;
        SupportsNvMe = supportsNvMe;
        MaxSupportedFrequency = maxSupportedFrequency;
        SupportedSockets = supportedSockets;
    }

    public abstract MemorySize MaxMemorySize { get; }
    public bool SupportsXmp { get; private set; }
    public Frequency MaxSupportedFrequency { get; private set; }
    public IReadOnlyCollection<Socket> SupportedSockets { get; }
    public bool SupportsNvMe { get; private set; }
}