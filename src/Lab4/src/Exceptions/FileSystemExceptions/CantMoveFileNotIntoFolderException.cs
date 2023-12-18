namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions.FileSystemExceptions;

public class CantMoveFileNotIntoFolderException : DefaultException
{
    public CantMoveFileNotIntoFolderException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public CantMoveFileNotIntoFolderException(string message)
        : base(message)
    {
    }

    public CantMoveFileNotIntoFolderException()
    {
    }
}