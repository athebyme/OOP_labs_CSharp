namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;

public class NullFileNameException : DefaultException
{
    public NullFileNameException(string message)
        : base(message)
    {
    }

    public NullFileNameException()
    {
    }

    public NullFileNameException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}