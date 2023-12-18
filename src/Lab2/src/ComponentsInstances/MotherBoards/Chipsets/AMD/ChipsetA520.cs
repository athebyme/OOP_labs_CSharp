using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.ChipSet;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsInstances.MotherBoards.Chipsets.AMD;

public class ChipsetA520 : Chipset
{
    private const bool XmpSupport = false;
    private const bool NvMeSupport = true;
    private const int PlainRamFreq = 2400;
    private const int OverclockedRamFreq = 3200;
    private static readonly Frequency Frequency = new(PlainRamFreq, OverclockedRamFreq);
    private static readonly IReadOnlyCollection<Socket> SocketsSupport = new List<Socket> { new Am4() };
    public ChipsetA520()
        : base(
            XmpSupport,
            NvMeSupport,
            Frequency,
            SocketsSupport)
    {
        MaxMemorySize = new MemorySize(32);
    }

    public override MemorySize MaxMemorySize { get; }
}