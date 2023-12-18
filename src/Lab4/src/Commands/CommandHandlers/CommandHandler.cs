using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public abstract class CommandHandler : ICommandHandler
{
    protected CommandHandler(FileSystemNavigator navigator, IEnumerable<IObserver> observers)
    {
        Observers = observers;
        Navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
    }

    protected IEnumerable<IObserver>? Observers { get; }
    protected ICommandHandler? NextHandler { get; private set; }
    protected ICommand? Command { get; private protected set; }
    protected FileSystemNavigator? Navigator { get; }

    public ICommandHandler SetNext(ICommandHandler nextHandler)
    {
        NextHandler = nextHandler ?? throw new ArgumentNullException(nameof(nextHandler));
        return NextHandler;
    }

    public abstract CommandHandler Handle(ref string[] args);
}