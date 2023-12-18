namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.CommandExceptions;

public class RenameFileDifferentParentDirectoryPathsException : DefaultException
{
    public RenameFileDifferentParentDirectoryPathsException(string message)
        : base(message)
    {
    }

    public RenameFileDifferentParentDirectoryPathsException()
    {
    }

    public RenameFileDifferentParentDirectoryPathsException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}