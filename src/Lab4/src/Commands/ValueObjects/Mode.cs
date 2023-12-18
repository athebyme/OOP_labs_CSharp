using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ValueObjects;

public class Mode
{
    public Mode(string commandMode)
    {
        CommandMode = commandMode ?? throw new ArgumentNullException(nameof(commandMode));
    }

    public string CommandMode { get; }
}