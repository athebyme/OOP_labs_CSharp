using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.DisplayException;

namespace Itmo.ObjectOrientedProgramming.Lab4.DisplayService;

public abstract class ConsoleDisplayBase : IDisplay
{
    public ConsoleColor Color { get; private protected set; } = ConsoleColor.White;
    protected TextWriter OutputWriter { get; private set; } = Console.Out;
    public abstract void Show(string text);
    public abstract void LogError(Exception e);
    public abstract void ChangeConsoleColor(ConsoleColor newColor);
    public void SetOutputWriter(TextWriter writer)
    {
        OutputWriter = writer ?? throw new NullConsoleColorException();
    }
}