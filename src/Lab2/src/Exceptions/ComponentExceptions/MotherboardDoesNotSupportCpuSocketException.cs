namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class MotherboardDoesNotSupportCpuSocketException : BaseException
{
    public MotherboardDoesNotSupportCpuSocketException(string message)
        : base(message)
    {
    }

    public MotherboardDoesNotSupportCpuSocketException()
    {
    }

    public MotherboardDoesNotSupportCpuSocketException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}