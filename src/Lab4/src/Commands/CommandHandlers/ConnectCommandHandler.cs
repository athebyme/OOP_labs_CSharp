using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class ConnectCommandHandler : CommandHandler
{
    public ConnectCommandHandler(
        FileSystemNavigator navigator,
        IEnumerable<IObserver> observers)
        : base(navigator, observers)
    {
    }

    public override ConnectCommandHandler Handle(ref string[] args)
    {
        if (args == null || Navigator == null) throw new ArgumentNullException(nameof(args));
        if (args[0].StartsWith("connect", StringComparison.CurrentCulture))
        {
            args = args.Skip(1).ToArray();
            Command = new ConnectCommand(args, Navigator);
            Command.Execute();
        }
        else
        {
            NextHandler?.Handle(ref args);
        }

        return this;
    }
}