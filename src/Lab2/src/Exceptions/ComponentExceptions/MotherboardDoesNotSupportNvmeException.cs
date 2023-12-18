namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class MotherboardDoesNotSupportNvmeException : BaseException
{
    public MotherboardDoesNotSupportNvmeException(string message)
        : base(message)
    {
    }

    public MotherboardDoesNotSupportNvmeException()
    {
    }

    public MotherboardDoesNotSupportNvmeException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}