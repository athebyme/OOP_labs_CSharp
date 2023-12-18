using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;

public class ConnectCommand : Command
{
    private readonly ItemPath _connectingPath;
    private ItemPath? _lastConnectedPath;
    private Mode _commandMode;
    public ConnectCommand(string[] args, FileSystemNavigator navigator)
    {
        SetSystemNavigator(navigator);
        AddObservers(navigator.GetNavigatorObservers);
        IList<CommandLineOption?> parsed = CommandArgumentsParser.ParseOptions(args);
        if (!PathValidator.RootedPath(parsed[0]?.Name ?? string.Empty) ||
            !PathValidator.Exists(parsed[0]?.Name ?? string.Empty))
        {
            NotifyObservers("Неверный путь. Проверьте {0}", args[0]);
            throw new InvalidPathException();
        }

        _commandMode = new Mode(
            args.FirstOrDefault(
                param => string.Equals("m", param, StringComparison.Ordinal))
            ?? string.Empty);
        _connectingPath = new ItemPath(parsed[0]?.Name ?? string.Empty);
        _lastConnectedPath = Navigator?.CurrentLocation;
        NotifyObservers("Подключено !");
    }

    public override void Execute()
    {
        Navigator?.MoveTo(_connectingPath);
        Navigator?.AddCommandToHistory(this);
        if (Navigator?.Connected == false)
        {
            Navigator?.ConnectSwitch();
        }

        _lastConnectedPath = _connectingPath;
    }

    public override void Undo()
    {
        if (_lastConnectedPath == null) throw new NullPathException();
        Navigator?.MoveTo(_lastConnectedPath);
        Navigator?.AddCommandToHistory(this);
    }
}