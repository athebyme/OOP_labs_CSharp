namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;

public class NullAddresseeException : DefaultException
{
    public NullAddresseeException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NullAddresseeException()
    {
    }

    public NullAddresseeException(string message)
        : base(message)
    {
    }
}