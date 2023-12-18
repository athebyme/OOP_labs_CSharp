using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;

public class DisconnectCommand : Command
{
    private ItemPath? _lastConnectedPath;
    public DisconnectCommand(FileSystemNavigator navigator)
    {
        SetSystemNavigator(navigator);
        AddObservers(navigator.GetNavigatorObservers);
        NotifyObservers("Disconnected !");
    }

    public override void Execute()
    {
        _lastConnectedPath = Navigator?.CurrentLocation;
        Navigator?.AddCommandToHistory(this);
        Navigator?.ConnectSwitch();
    }

    public override void Undo()
    {
        if (_lastConnectedPath == null) throw new NullPathException();
        Navigator?.MoveTo(_lastConnectedPath);
        Navigator?.AddCommandToHistory(this);
    }
}