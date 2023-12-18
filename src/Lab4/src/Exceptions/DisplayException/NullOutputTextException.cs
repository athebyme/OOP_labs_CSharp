namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.DisplayException;

public class NullOutputTextException : DefaultException
{
    public NullOutputTextException(string message)
        : base(message)
    {
    }

    public NullOutputTextException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullOutputTextException()
    {
    }
}