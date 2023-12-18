namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class CpuFanDoesNotScatterEnoughTdp : BaseException
{
    public CpuFanDoesNotScatterEnoughTdp(string message)
        : base(message)
    {
    }

    public CpuFanDoesNotScatterEnoughTdp()
    {
    }

    public CpuFanDoesNotScatterEnoughTdp(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}