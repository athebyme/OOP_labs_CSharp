namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;

public class NullUserException : DefaultException
{
    public NullUserException(string message)
        : base(message)
    {
    }

    public NullUserException()
    {
    }

    public NullUserException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}