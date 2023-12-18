using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.DisplayException;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.DisplayService;

public class ConsoleDisplayDriver : ConsoleDisplayBase, IDisplayDriver, IObserver
{
    public override void Show(string text)
    {
        OutputWriter.WriteLine(text ?? throw new NullOutputTextException());
    }

    public override void LogError(Exception e)
    {
        OutputWriter.WriteLine(e?.Message ?? throw new NullOutputTextException());
    }

    public override void ChangeConsoleColor(ConsoleColor newColor)
    {
        Color = newColor;
    }

    public void Clear()
    {
        OutputWriter.Flush();
    }

    public void Update(string message)
    {
        OutputWriter.WriteLine(message ?? throw new NullOutputTextException());
    }
}