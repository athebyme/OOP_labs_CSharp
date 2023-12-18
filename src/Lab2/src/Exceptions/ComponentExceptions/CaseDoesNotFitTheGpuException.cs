namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ComponentExceptions;

public class CaseDoesNotFitTheGpuException : BaseException
{
    public CaseDoesNotFitTheGpuException(string message)
        : base(message)
    {
    }

    public CaseDoesNotFitTheGpuException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public CaseDoesNotFitTheGpuException()
    {
    }
}