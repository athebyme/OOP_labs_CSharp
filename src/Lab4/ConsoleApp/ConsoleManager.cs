using System.Runtime.InteropServices;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleApp;

public static class ConsoleManager
{
    public static void ReleaseConsole()
    {
        FreeConsole();
    }

    public static void CreateConsole()
    {
        AllocConsole();
    }

    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static extern bool AllocConsole();

    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static extern bool FreeConsole();
}