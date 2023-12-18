using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class CommandHandlersContainer
{
    private readonly RenameCommandHandler _renameCommandHandler;
    private readonly DisconnectCommandHandler _disconnectCommandHandler;
    private readonly ConnectCommandHandler _connectHandlerImplementation;
    private readonly ShowFilesCommandHandler _showFilesCommandHandler;
    private readonly ChangeDirectoryCommandHandler _changeDirectoryCommandHandler;
    private readonly MoveCommandHandler _moveCommandHandler;
    private readonly CopyCommandHandler _copyCommandHandler;
    private readonly DeleteCommandHandler _deleteCommandHandler;
    private readonly List<IObserver> _observers;

    public CommandHandlersContainer(
        FileSystemNavigator navigator,
        IEnumerable<IObserver> observers)
    {
        _observers = observers.ToList() ?? throw new ArgumentNullException(nameof(observers));
        FileSystemNavigator systemNavigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        _connectHandlerImplementation = new ConnectCommandHandler(systemNavigator, _observers);
        _disconnectCommandHandler = new DisconnectCommandHandler(systemNavigator, _observers);
        _renameCommandHandler = new RenameCommandHandler(systemNavigator, _observers);
        _showFilesCommandHandler = new ShowFilesCommandHandler(systemNavigator, _observers);
        _changeDirectoryCommandHandler = new ChangeDirectoryCommandHandler(systemNavigator, _observers);
        _moveCommandHandler = new MoveCommandHandler(systemNavigator, _observers);
        _copyCommandHandler = new CopyCommandHandler(systemNavigator, _observers);
        _deleteCommandHandler = new DeleteCommandHandler(systemNavigator, _observers);
        SetAllAvailableCommands();
    }

    public void Handle(ref string[] args)
    {
        _connectHandlerImplementation.Handle(ref args);
    }

    private void SetAllAvailableCommands()
    {
        _connectHandlerImplementation
            .SetNext(_renameCommandHandler)
            .SetNext(_disconnectCommandHandler)
            .SetNext(_showFilesCommandHandler)
            .SetNext(_changeDirectoryCommandHandler)
            .SetNext(_moveCommandHandler)
            .SetNext(_copyCommandHandler)
            .SetNext(_deleteCommandHandler);
    }
}