using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;

public class ShowFilesCommand : Command
{
    private string _path;
    public ShowFilesCommand(string path, FileSystemNavigator navigator)
    {
        SetSystemNavigator(navigator);
        AddObservers(navigator.GetNavigatorObservers);
        _path = path ?? throw new NullPathException();
    }

    public override void Execute()
    {
        if (Navigator == null) throw new ArgumentNullException(nameof(Navigator));
        try
        {
            foreach (string systemItemName in PathValidator.GetAllFiles(Navigator.Depth, _path))
            {
                Navigator.Output.Show(systemItemName);
            }
        }
        catch (UnauthorizedAccessException)
        {
        }
    }

    public override void Undo()
    {
        Navigator?.Output.Clear();
    }
}