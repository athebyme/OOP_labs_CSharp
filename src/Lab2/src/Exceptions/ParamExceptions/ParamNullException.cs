namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

public class ParamNullException : BaseException
{
    public ParamNullException(string message)
        : base(message)
    {
    }

    public ParamNullException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public ParamNullException()
    {
    }
}