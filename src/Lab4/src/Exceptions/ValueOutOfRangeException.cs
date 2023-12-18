namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ValueOutOfRangeException : DefaultException
{
    public ValueOutOfRangeException(string message)
        : base(message)
    {
    }

    public ValueOutOfRangeException()
    {
    }

    public ValueOutOfRangeException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}