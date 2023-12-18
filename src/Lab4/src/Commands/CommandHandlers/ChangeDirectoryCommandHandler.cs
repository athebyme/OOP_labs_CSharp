using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class ChangeDirectoryCommandHandler : CommandHandler
{
    public ChangeDirectoryCommandHandler(FileSystemNavigator navigator, IEnumerable<IObserver> observers)
        : base(navigator, observers)
    {
    }

    public override ChangeDirectoryCommandHandler Handle(ref string[] args)
    {
        if (args == null || Navigator == null) throw new ArgumentNullException(nameof(args));
        if (args[0].StartsWith("cd", StringComparison.CurrentCulture))
        {
            args = args.Skip(1).ToArray();

            Command = new ChangeDirectoryCommand(
                PathValidator.MakeRooted(
                    Navigator.CurrentLocation?.Path ?? string.Empty,
                    args[0]),
                Navigator);
            Command.Execute();
        }
        else
        {
            NextHandler?.Handle(ref args);
        }

        return this;
    }
}