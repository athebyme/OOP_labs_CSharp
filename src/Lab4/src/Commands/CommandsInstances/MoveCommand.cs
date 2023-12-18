using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;

public class MoveCommand : Command
{
    private readonly string _fromMovingPath;
    private readonly string _toMovingPath;

    public MoveCommand(string fromPath, string toPath, FileSystemNavigator navigator)
    {
        SetSystemNavigator(navigator);
        AddObservers(navigator.GetNavigatorObservers);
        _fromMovingPath = fromPath ?? throw new NullPathException();
        _toMovingPath = toPath ?? throw new NullPathException();
        if (!string.Equals(_fromMovingPath, _toMovingPath, StringComparison.Ordinal)) return;
        NotifyObservers("Вы не можете переместить файл туда же !");
        throw new InvalidPathException();
    }

    public override void Execute()
    {
        try
        {
            PathValidator.ValidatePaths(_fromMovingPath);
            PathValidator.ValidatePaths(_toMovingPath);
        }
        catch (InvalidPathException e)
        {
            NotifyObservers("Неверный путь. Проверьте {0}", e.Message);
            throw;
        }

        if (File.GetAttributes(_toMovingPath) != FileAttributes.Directory)
        {
            NotifyObservers("Нельзя переместить файл не в диркеторию. Проверьте {0}", _toMovingPath);
            throw new CantMoveFileNotIntoFolderException();
        }

        string newFilePath = PathValidator.GetValidFileName(
            _fromMovingPath,
            _toMovingPath);

        File.Move(
            _fromMovingPath,
            newFilePath);
        NotifyObservers("Файл успешно перенесен.");
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}