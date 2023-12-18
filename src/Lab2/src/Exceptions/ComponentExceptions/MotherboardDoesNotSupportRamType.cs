namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class MotherboardDoesNotSupportRamType : BaseException
{
    public MotherboardDoesNotSupportRamType(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public MotherboardDoesNotSupportRamType()
    {
    }

    public MotherboardDoesNotSupportRamType(string message)
        : base(message)
    {
    }
}