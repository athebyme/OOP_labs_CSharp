using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayService;

public class ConsoleDisplayDriver : ConsoleDisplayBase, IDisplayDriver
{
    public override void DisplayMessage(Message message)
    {
        OutputWriter.WriteLine(message?.ToString() ?? throw new NullMessageException());
    }

    public override void DisplayError(Exception e)
    {
        OutputWriter.WriteLine(e?.Message ?? throw new NullMessageException());
    }

    public override void ChangeConsoleColor(ConsoleColor newColor)
    {
        Color = newColor;
    }

    public void Show(string text)
    {
        OutputWriter.WriteLine(text ?? throw new NullMessageException());
    }

    public void Clear()
    {
        OutputWriter.Flush();
    }
}