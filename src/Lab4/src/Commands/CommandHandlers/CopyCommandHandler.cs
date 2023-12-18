﻿using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger.Observer;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandHandlers;

public class CopyCommandHandler : CommandHandler
{
    public CopyCommandHandler(
        FileSystemNavigator navigator,
        IEnumerable<IObserver> observers)
        : base(navigator, observers)
    {
    }

    public override CommandHandler Handle(ref string[] args)
    {
        if (args == null || Navigator == null) throw new ArgumentNullException(nameof(args));
        if (args[0].StartsWith("file", StringComparison.CurrentCulture) &&
            args[1].StartsWith("copy", StringComparison.CurrentCulture))
        {
            if (Navigator.Connected == false)
            {
                throw new FileSystemNavigatorIsNotConnectedException();
            }

            args = args.Skip(2).ToArray();
            Command = new CopyCommand(
                PathValidator.MakeRooted(
                    Navigator.CurrentLocation?.Path ?? string.Empty,
                    args[0]),
                PathValidator.MakeRooted(
                    Navigator.CurrentLocation?.Path ?? string.Empty,
                    args[1]),
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