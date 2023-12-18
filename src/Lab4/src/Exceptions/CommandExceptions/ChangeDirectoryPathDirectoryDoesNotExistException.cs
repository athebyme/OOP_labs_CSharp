namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.CommandExceptions;

public class ChangeDirectoryPathDirectoryDoesNotExistException : DefaultException
{
    public ChangeDirectoryPathDirectoryDoesNotExistException(string message)
        : base(message)
    {
    }

    public ChangeDirectoryPathDirectoryDoesNotExistException()
    {
    }

    public ChangeDirectoryPathDirectoryDoesNotExistException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}