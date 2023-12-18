using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions.PathExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Path;

public abstract class PathValidator
{
    public static bool RootedPath(string path)
    {
        if (path == null) throw new NullPathException(nameof(path));
        return System.IO.Path.IsPathRooted(path);
    }

    public static bool Exists(string path)
    {
        if (path == null) throw new NullPathException(nameof(path));
        return System.IO.Path.Exists(path);
    }

    public static string MakeRooted(string root, string targetPath)
    {
        if (root == null) throw new NullPathException(nameof(root));
        if (targetPath == null) throw new NullPathException(nameof(targetPath));
        string rootedPath = targetPath;
        if (!RootedPath(targetPath))
        {
            rootedPath = System.IO.Path.Combine(root, targetPath);
        }

        return rootedPath;
    }

    public static IEnumerable<string> GetAllFiles(int depth, string path, string indent = "")
    {
        if (path == null) throw new NullPathException(nameof(path));
        if (depth < 0) throw new NullPathException(nameof(path));
        var items = new List<string>();
        if (depth > 0)
        {
            foreach (string folderPath in System.IO.Directory.EnumerateDirectories(path))
            {
                items.Add(indent + GetFolderNameWithIcon(folderPath) + "/");
                items.AddRange(GetAllFiles(depth - 1, folderPath, indent + "\t"));
            }
        }

        items.AddRange(System.IO.Directory.GetFiles(path).Select(filePath => indent + GetFileNameWithIcon(filePath)));

        return items;
    }

    public static void ValidatePaths(string path)
    {
        if (path == null) throw new NullPathException(nameof(path));
        if (!Exists(path) || !RootedPath(path))
        {
            throw new InvalidPathException(path);
        }
    }

    public static string GetValidFileName(string pathFrom, string pathTo)
    {
        if (pathTo == null) throw new NullPathException(nameof(pathTo));
        if (pathFrom == null) throw new NullPathException(nameof(pathFrom));

        string newFilePath = pathTo;
        int i = 0;
        while (Exists(newFilePath))
        {
            ++i;
            newFilePath = System.IO.Path.Combine(
                pathTo,
                System.IO.Path.GetFileNameWithoutExtension(pathFrom) + "(" + i.ToString(CultureInfo.CurrentCulture) + ")" + System.IO.Path.GetExtension(pathFrom));
        }

        return newFilePath;
    }

    private static string GetFolderNameWithIcon(string folderPath)
    {
        return "\ud83d\udcc1 " + System.IO.Path.GetFileName(folderPath);
    }

    private static string GetFileNameWithIcon(string filePath)
    {
        string fileName = System.IO.Path.GetFileName(filePath);
        string extension = System.IO.Path.GetExtension(filePath);
        string icon = extension.ToLower(CultureInfo.CurrentCulture) switch
        {
            ".txt" => "\ud83d\udcc4",
            ".jpg" or ".png" or ".gif" => "📷",
            ".mp3" => "\ud83c\udfb5",
            _ => "\ud83d\udccb",
        };
        return icon + " " + fileName;
    }
}