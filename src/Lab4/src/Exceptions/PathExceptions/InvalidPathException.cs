namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;

public class InvalidPathException : DefaultException
{
    public InvalidPathException(string message)
        : base(message)
    {
    }

    public InvalidPathException()
    {
    }

    public InvalidPathException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}