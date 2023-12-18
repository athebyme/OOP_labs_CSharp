using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

public class ParamOutOfRangeException : BaseException
{
    public ParamOutOfRangeException(string message)
        : base(message)
    {
    }

    public ParamOutOfRangeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ParamOutOfRangeException()
    {
    }
}