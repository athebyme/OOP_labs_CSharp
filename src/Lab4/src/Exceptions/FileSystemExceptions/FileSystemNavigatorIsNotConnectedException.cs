namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;

public class FileSystemNavigatorIsNotConnectedException : DefaultException
{
    public FileSystemNavigatorIsNotConnectedException(string message)
        : base(message)
    {
    }

    public FileSystemNavigatorIsNotConnectedException()
    {
    }

    public FileSystemNavigatorIsNotConnectedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}