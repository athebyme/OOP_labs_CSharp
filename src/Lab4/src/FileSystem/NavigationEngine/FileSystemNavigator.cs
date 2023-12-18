using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.DisplayService;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;

public class FileSystemNavigator
{
    private readonly List<IObserver> _observers = new();
    private List<Command> _commandHistory = new();
    public FileSystemNavigator(IDisplayDriver output)
    {
        Output = output;
        _observers.Add((IObserver)output);
    }

    public IDisplayDriver Output { get; }
    public IEnumerable<IObserver> GetNavigatorObservers => _observers;

    public bool Connected { get; private set; }
    public ItemPath? CurrentLocation { get; private set; }
    public int Depth { get; private set; } = 1;

    public void ConnectSwitch() => Connected = !Connected;

    public void ChangeTreeDepth(int newDepth)
    {
        if (newDepth < 0) throw new ValueOutOfRangeException();
        Depth = newDepth;
    }

    public void AddCommandToHistory(Command command)
    {
        _commandHistory.Add(command);
    }

    public void MoveTo(ItemPath newPath)
    {
        CurrentLocation = newPath;
    }
}