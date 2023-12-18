using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;

public class CopyCommand : Command
{
    private readonly string _fromPath;
    private readonly string _toPath;
    public CopyCommand(string fromPath, string toPath, FileSystemNavigator navigator)
    {
        SetSystemNavigator(navigator);
        AddObservers(navigator.GetNavigatorObservers);
        _toPath = toPath ?? throw new NullPathException();
        _fromPath = fromPath ?? throw new NullPathException();
    }

    public override void Execute()
    {
        try
        {
            PathValidator.ValidatePaths(_fromPath);
            PathValidator.ValidatePaths(_toPath);
        }
        catch (InvalidPathException e)
        {
            NotifyObservers("Неверный путь. Проверьте {0}", e.Message);
            throw;
        }

        if (File.GetAttributes(_toPath) != FileAttributes.Directory)
        {
            NotifyObservers("Нельзя переместить файл не в диркеторию. Проверьте {0}", _toPath);
            throw new CantMoveFileNotIntoFolderException();
        }

        string newFilePath = PathValidator.GetValidFileName(
            _fromPath,
            _toPath);

        File.Copy(
            _fromPath,
            newFilePath);
        NotifyObservers("Файл успешно скопирован.");
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}