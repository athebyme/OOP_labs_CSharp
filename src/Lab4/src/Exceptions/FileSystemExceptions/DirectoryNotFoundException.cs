using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class DirectoryNotFoundException : DefaultException
{
    public DirectoryNotFoundException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public DirectoryNotFoundException()
    {
    }

    public DirectoryNotFoundException(string message)
        : base(message)
    {
    }
}