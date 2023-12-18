using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.DisplayService;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleApp;

public static class Program
{
    public static void RunApp()
    {
        ConsoleManager.CreateConsole();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var systemNavigator = new FileSystemNavigator(
            new ConsoleDisplayDriver());
        var commandController = new CommandController(systemNavigator);
        commandController.AddObserver(new ConsoleDisplayDriver());
        systemNavigator.ChangeTreeDepth(5);
        while (true)
        {
            string? command = Console.ReadLine()?.ToLower(CultureInfo.CurrentCulture);
            if (command == null)
            {
            }
            else if (command == "exit")
            {
                break;
            }
            else
            {
                string[] input = command.Split();
                commandController.Handle(ref input);
            }
        }

        ConsoleManager.ReleaseConsole();
    }
}