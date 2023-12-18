using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class DefaultException : Exception
{
    public DefaultException(string message)
        : base(message)
    {
    }

    public DefaultException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DefaultException()
    {
    }
}