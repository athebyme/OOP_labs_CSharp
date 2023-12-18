using System;
using Itmo.ObjectOrientedProgramming.Lab4.DisplayService;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.DisplayException;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.LLogger;

public class Logger : IObserver
{
    private const string LoggedMsg = $"[Logged]";
    private IDisplayDriver _displayDriver;

    public Logger(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void ChangeOutput(IDisplayDriver newOutput)
    {
        _displayDriver = newOutput ?? throw new NullConsoleOutputException();
    }

    public void Update(string message)
    {
        _displayDriver.Show($"{LoggedMsg} {DateTime.Now + " "} {message}");
    }
}