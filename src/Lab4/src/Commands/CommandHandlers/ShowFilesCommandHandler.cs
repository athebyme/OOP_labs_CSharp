using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class ShowFilesCommandHandler : CommandHandler
{
    public ShowFilesCommandHandler(FileSystemNavigator navigator, IEnumerable<IObserver> observers)
        : base(navigator, observers)
    {
    }

    public override ShowFilesCommandHandler Handle(ref string[] args)
    {
        if (args == null || Navigator == null) throw new ArgumentNullException(nameof(args));
        if (args[0].StartsWith("file", StringComparison.CurrentCulture) &&
            args[1].StartsWith("show", StringComparison.CurrentCulture))
        {
            if (Navigator.Connected == false)
            {
                throw new FileSystemNavigatorIsNotConnectedException();
            }

            args = args.Skip(2).ToArray();
            Command = args.Length == 0 ?
                new ShowFilesCommand(Navigator.CurrentLocation?.Path ?? string.Empty, Navigator) :
                new ShowFilesCommand(args[0], Navigator);

            Command.Execute();
        }
        else
        {
            NextHandler?.Handle(ref args);
        }

        return this;
    }
}