namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;

public class NullPathException : DefaultException
{
    public NullPathException(string message)
        : base(message)
    {
    }

    public NullPathException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullPathException()
    {
    }
}