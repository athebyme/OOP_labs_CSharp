namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;

public class NullAddresseeIdException : DefaultException
{
    public NullAddresseeIdException(string message)
        : base(message)
    {
    }

    public NullAddresseeIdException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullAddresseeIdException()
    {
    }
}