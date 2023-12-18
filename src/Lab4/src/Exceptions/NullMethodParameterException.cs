namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NullMethodParameterException : DefaultException
{
    public NullMethodParameterException(string message)
        : base(message)
    {
    }

    public NullMethodParameterException()
    {
    }

    public NullMethodParameterException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}