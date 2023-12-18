using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.CommandExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;

public class RenameCommand : Command
{
    private readonly ItemPath _path;
    private readonly string _newName;
    private readonly string _oldName;

    public RenameCommand(string path, string newName, FileSystemNavigator navigator)
    {
        if (path == null) throw new NullPathException();
        if (navigator == null) throw new ArgumentNullException(nameof(navigator));
        AddObservers(navigator.GetNavigatorObservers);
        _path = new ItemPath(System.IO.Path.GetDirectoryName(path) ?? string.Empty);
        _newName = newName;
        _oldName = new FileInfo(path).Name;
    }

    public override void Execute()
    {
        string pathFrom = System.IO.Path.Combine(_path.Path, _oldName);
        string pathTo = System.IO.Path.Combine(_path.Path, _newName);
        try
        {
            PathValidator.ValidatePaths(pathFrom);
        }
        catch (InvalidPathException e)
        {
            NotifyObservers("Неверный путь. Проверьте {0}", e.Message);
            throw;
        }

        if (!PathValidator.Exists(System.IO.Path.Combine(_path.Path, _oldName)))
        {
            NotifyObservers("Файл с таким названием в заданной директории уже существует!");
            throw new InvalidPathException();
        }

        if (!string.Equals(
                System.IO.Path.GetDirectoryName(pathFrom),
                System.IO.Path.GetDirectoryName(pathTo),
                StringComparison.Ordinal))
        {
            NotifyObservers("Невозможно переименовать файл в папку. Проверьте {0}", pathTo);
            throw new RenameFileDifferentParentDirectoryPathsException();
        }

        if (string.Equals(pathFrom, pathTo, StringComparison.Ordinal))
        {
            NotifyObservers("Вы не можете переименовать файл в то же самое название !");
            throw new RenameSameFileNamesException();
        }

        string newFilePath = PathValidator.GetValidFileName(pathFrom, pathTo);
        File.Move(
            System.IO.Path.Combine(_path.Path, _oldName),
            newFilePath);
        NotifyObservers("Файл {0} успешно переименован в {1}", _oldName, _newName);
    }

    public override void Undo()
    {
        File.Move(
            System.IO.Path.Combine(_path.Path, _newName),
            System.IO.Path.Combine(_path.Path, _oldName));
    }
}