namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.ValueExceptions;

public class NullParamException : DefaultException
{
    public NullParamException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullParamException()
    {
    }

    public NullParamException(string message)
        : base(message)
    {
    }
}