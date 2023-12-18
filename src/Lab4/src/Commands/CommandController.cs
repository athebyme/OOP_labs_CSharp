using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CommandController : Observable
{
    private readonly CommandHandlersContainer? _commandHandlersContainer;
    public CommandController(FileSystemNavigator navigator)
    {
        FileSystemNavigator systemNavigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        foreach (IObserver observer in systemNavigator.GetNavigatorObservers)
        {
            AddObserver(observer);
        }

        _commandHandlersContainer = new CommandHandlersContainer(systemNavigator, systemNavigator.GetNavigatorObservers);
    }

    public void Handle(ref string[] args)
    {
        try
        {
            _commandHandlersContainer?.Handle(ref args);
        }
        catch (DefaultException)
        {
        }
    }
}