using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;

public abstract class Command : Observable, ICommand
{
    protected FileSystemNavigator? Navigator { get; private set; }
    protected IEnumerable<IObserver>? Observers { get; private set; }

    public abstract void Execute();
    public abstract void Undo();
    protected void SetSystemNavigator(FileSystemNavigator navigator)
    {
        Navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
    }

    protected void AddObservers(IEnumerable<IObserver> observers)
    {
        IEnumerable<IObserver> enumerable = observers.ToList();
        Observers = enumerable;
        foreach (IObserver observer in enumerable)
        {
            AddObserver(observer);
        }
    }
}