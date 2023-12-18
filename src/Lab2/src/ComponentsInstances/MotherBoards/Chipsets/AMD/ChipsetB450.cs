using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.ChipSet;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Frequency;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.MemorySize;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComponentsInstances.MotherBoards.Chipsets.AMD;

public class ChipsetB450 : Chipset
{
    private const bool XmpSupport = true;
    private const bool NvMeSupport = true;
    private const int PlainRamFreq = 2400;
    private const int OverclockedRamFreq = 3600;
    private static readonly Frequency Frequency = new(PlainRamFreq, OverclockedRamFreq);
    private static readonly IReadOnlyCollection<Socket> SocketsSupport = new List<Socket> { new Am4() };
    public ChipsetB450()
        : base(
            XmpSupport,
            NvMeSupport,
            Frequency,
            SocketsSupport)
    {
        MaxMemorySize = new MemorySize(128);
    }

    public override MemorySize MaxMemorySize { get; }
}