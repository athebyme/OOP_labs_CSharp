using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoard.BIOS;

public class Bios
{
    public Bios(string version, IReadOnlyCollection<Socket> supportedProcessors)
    {
        Version = version ?? throw new ParamNullException();
        SupportedProcessors = supportedProcessors ?? throw new ParamNullException();
    }

    public string Version { get; set; }
    public IReadOnlyCollection<Socket> SupportedProcessors { get; set; }
}