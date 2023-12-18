namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;

public class NullFileSystemNodeException : DefaultException
{
    public NullFileSystemNodeException(string message)
        : base(message)
    {
    }

    public NullFileSystemNodeException()
    {
    }

    public NullFileSystemNodeException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}