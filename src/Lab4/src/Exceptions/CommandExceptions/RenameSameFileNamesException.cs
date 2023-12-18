namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.CommandExceptions;

public class RenameSameFileNamesException : DefaultException
{
    public RenameSameFileNamesException(string message)
        : base(message)
    {
    }

    public RenameSameFileNamesException()
    {
    }

    public RenameSameFileNamesException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}