namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;

public class ChatIdCantBeBelowZeroException : DefaultException
{
    public ChatIdCantBeBelowZeroException(string message)
        : base(message)
    {
    }

    public ChatIdCantBeBelowZeroException()
    {
    }

    public ChatIdCantBeBelowZeroException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}