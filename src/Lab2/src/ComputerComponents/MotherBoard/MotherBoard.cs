using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.RamType;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.ChipSet;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.MotherBoardsTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Expansions;
using Itmo.ObjectOrientedProgramming.Lab2.Parameters.Price;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard;

public class MotherBoard : IPriceOwner
{
    public MotherBoard(string model, Chipset chipset, IReadOnlyCollection<ExpansionType> expansionSlots, MotherBoardTypes motherBoardsFf, Bios bios, int numberOfRamSlots, RamTypes supportedMemoryTypes, Price price)
    {
        Model = model ?? throw new ParamNullException();
        Chipset = chipset ?? throw new ParamNullException();
        ExpansionSlots = expansionSlots ?? throw new ParamNullException();
        Price = price ?? throw new ParamNullException();
        Bios = bios ?? throw new ParamNullException();
        MotherBoardFf = motherBoardsFf;
        NumberOfRamSlots = numberOfRamSlots;
        SupportedMemoryTypes = supportedMemoryTypes;
    }

    public string Model { get; }
    public Chipset Chipset { get; }
    public Bios Bios { get; }
    public IReadOnlyCollection<ExpansionType> ExpansionSlots { get; }
    public MotherBoardTypes MotherBoardFf { get; }
    public int NumberOfRamSlots { get; }
    public RamTypes SupportedMemoryTypes { get; }
    public Price Price { get; }
}