using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Path;

public abstract class CustomPath
{
    protected CustomPath(string path)
    {
        if (!PathValidator.RootedPath(path)) throw new InvalidPathException();
        Path = path;
    }

    public string Path { get; }
}