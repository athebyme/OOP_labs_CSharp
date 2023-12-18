namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class MotherboardDoesNotSupportRamSizeException : BaseException
{
    public MotherboardDoesNotSupportRamSizeException(string message)
        : base(message)
    {
    }

    public MotherboardDoesNotSupportRamSizeException()
    {
    }

    public MotherboardDoesNotSupportRamSizeException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}