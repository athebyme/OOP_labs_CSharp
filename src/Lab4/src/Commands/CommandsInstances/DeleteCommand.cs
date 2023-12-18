using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.CommandsInstances;

public class DeleteCommand : Command
{
    private readonly string _path;
    public DeleteCommand(string path, FileSystemNavigator navigator)
    {
        SetSystemNavigator(navigator);
        AddObservers(navigator.GetNavigatorObservers);
        _path = path ?? throw new NullPathException();
    }

    public override void Execute()
    {
        try
        {
            PathValidator.ValidatePaths(_path);
        }
        catch (InvalidPathException e)
        {
            NotifyObservers("Неверный путь. Проверьте {0}", e.Message);
            throw;
        }

        File.Delete(_path);
        NotifyObservers("Файл успешно удален.");
    }

    public override void Undo()
    {
        // тут бы что то типа корзины сделать + параметры --soft --hard для удаления ...
    }
}