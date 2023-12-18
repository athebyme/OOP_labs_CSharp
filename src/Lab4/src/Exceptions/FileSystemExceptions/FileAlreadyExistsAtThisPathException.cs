namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;

public class FileAlreadyExistsAtThisPathException : DefaultException
{
    public FileAlreadyExistsAtThisPathException(string message)
        : base(message)
    {
    }

    public FileAlreadyExistsAtThisPathException()
    {
    }

    public FileAlreadyExistsAtThisPathException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}