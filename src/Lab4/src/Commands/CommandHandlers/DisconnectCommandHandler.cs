using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class DisconnectCommandHandler : CommandHandler
{
    public DisconnectCommandHandler(FileSystemNavigator navigator, IEnumerable<IObserver> observers)
        : base(navigator, observers)
    {
    }

    public override DisconnectCommandHandler Handle(ref string[] args)
    {
        if (args == null || Navigator == null) throw new ArgumentNullException(nameof(args));
        if (args[0].StartsWith("disconnect", StringComparison.CurrentCulture))
        {
            if (Navigator.Connected == false)
            {
                throw new FileSystemNavigatorIsNotConnectedException();
            }

            Command = new DisconnectCommand(Navigator);
            Command.Execute();
        }
        else
        {
            NextHandler?.Handle(ref args);
        }

        return this;
    }
}