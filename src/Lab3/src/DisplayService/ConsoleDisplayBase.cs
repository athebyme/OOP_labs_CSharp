using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.ValueExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayService;

public abstract class ConsoleDisplayBase : IDisplay
{
    public ConsoleColor Color { get; private protected set; } = ConsoleColor.White;
    protected TextWriter OutputWriter { get; private set; } = Console.Out;
    public abstract void DisplayMessage(Message message);
    public abstract void DisplayError(Exception e);
    public abstract void ChangeConsoleColor(ConsoleColor newColor);
    public void SetOutputWriter(TextWriter writer)
    {
        OutputWriter = writer ?? throw new NullConsoleColorException();
    }
}