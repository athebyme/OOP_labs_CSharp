using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.ChipSet;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsInstances.MotherBoards.Chipsets.Intel;

public class ChipsetH610 : Chipset
{
    private const bool XmpSupport = true;
    private const bool NvMeSupport = false;
    private const int PlainRamFreq = 2400;
    private const int OverclockedRamFreq = 3200;
    private static readonly Frequency Frequency = new(PlainRamFreq, OverclockedRamFreq);
    private static readonly IReadOnlyCollection<Socket> SocketsSupport = new List<Socket> { new Lga1700() };

    public ChipsetH610()
        : base(
            XmpSupport,
            NvMeSupport,
            Frequency,
            SocketsSupport)
    {
        MaxMemorySize = new MemorySize(64);
    }

    public override MemorySize MaxMemorySize { get; }
}