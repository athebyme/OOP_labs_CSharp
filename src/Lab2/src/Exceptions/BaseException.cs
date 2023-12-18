using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class BaseException : Exception
{
    public BaseException(string message)
        : base(message)
    {
    }

    public BaseException()
    {
    }

    public BaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}