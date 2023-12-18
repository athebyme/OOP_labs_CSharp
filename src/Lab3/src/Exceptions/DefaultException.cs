using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class DefaultException : Exception
{
    public DefaultException(string message)
        : base(message)
    {
    }

    public DefaultException()
    {
    }

    public DefaultException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}