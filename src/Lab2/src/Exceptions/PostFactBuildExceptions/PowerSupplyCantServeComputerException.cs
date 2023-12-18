namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.PostFactBuildExceptions;

public class PowerSupplyCantServeComputerException : BaseException
{
    public PowerSupplyCantServeComputerException(string message)
        : base(message)
    {
    }

    public PowerSupplyCantServeComputerException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public PowerSupplyCantServeComputerException()
    {
    }
}