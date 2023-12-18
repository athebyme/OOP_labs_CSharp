using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.CommandExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;

public class ChangeDirectoryCommand : Command
{
    private readonly string _newDirectory;
    private FileSystemNavigator _navigator;

    public ChangeDirectoryCommand(string newDirectory, FileSystemNavigator navigator)
    {
        if (navigator == null) throw new ArgumentNullException(nameof(navigator));
        AddObservers(navigator.GetNavigatorObservers);
        _newDirectory = newDirectory;
        _navigator = navigator;
    }

    public override void Execute()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string fullPath = System.IO.Path.Combine(currentDirectory, _newDirectory);

        if (Directory.Exists(fullPath))
        {
            _navigator.MoveTo(new ItemPath(fullPath));
            NotifyObservers($"Changed directory to: {fullPath}");
        }
        else
        {
            NotifyObservers($"Directory does not exist: {fullPath}");
            throw new ChangeDirectoryPathDirectoryDoesNotExistException();
        }
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}