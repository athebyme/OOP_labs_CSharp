namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

public class ParamComparingLogicException : BaseException
{
    public ParamComparingLogicException(string message)
        : base(message)
    {
    }

    public ParamComparingLogicException()
    {
    }

    public ParamComparingLogicException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}