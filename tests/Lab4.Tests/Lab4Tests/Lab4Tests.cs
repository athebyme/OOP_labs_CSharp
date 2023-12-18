using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.DisplayService;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.NavigationEngine;
using Itmo.ObjectOrientedProgramming.Lab4.LLogger;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Lab4Tests;

public class Lab4Tests
{
    private readonly Mock<XunitConsoleOutputAdapter> _outputConsole;
    private readonly Mock<Logger> _loggerMock;

    public Lab4Tests(ITestOutputHelper outputHelper)
    {
        _outputConsole = new Mock<XunitConsoleOutputAdapter>(outputHelper);
        _loggerMock = new Mock<Logger>(_outputConsole.Object);
    }

    [Theory]
    [InlineData("connect")]
    public void TestSuccessfulConnect(string command)
    {
        // arrange
        if (command == null) throw new ArgumentNullException(nameof(command));
        string testFolderPath = System.IO.Path.Combine("tests", "Lab4.Tests", "TestFolder");
        command += " " + System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, testFolderPath);

        // act
        var systemNavigator = new FileSystemNavigator(_outputConsole.Object);
        var commandController = new CommandController(systemNavigator);
        commandController.AddObserver(_loggerMock.Object);
        string[] input = command.Split();
        commandController.Handle(ref input);

        // assert
        _outputConsole.Verify(x => x.Show(It.IsAny<string>()), Times.Exactly(0));
        _outputConsole.Reset();
    }

    [Theory]
    [InlineData("connect")]
    public void TestConnectInvalidPath(string command)
    {
        // assert
        if (command == null) throw new ArgumentNullException(nameof(command));
        command += " " + System.IO.Path.Combine(Directory.GetCurrentDirectory(), System.IO.Path.Combine("TestFolder123"));

        // act
        var systemNavigator = new FileSystemNavigator(_outputConsole.Object);
        var commandController = new CommandController(systemNavigator);
        commandController.AddObserver(_loggerMock.Object);
        string[] input = command.Split();
        commandController.Handle(ref input);

        // assert
        _outputConsole.Verify(x => x.Show(It.IsAny<string>()), Times.Exactly(0));
        _outputConsole.Reset();
    }
}