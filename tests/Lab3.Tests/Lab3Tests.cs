using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.PermissionsSystem;
using Itmo.ObjectOrientedProgramming.Lab3.Commands;
using Itmo.ObjectOrientedProgramming.Lab3.DisplayService;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.MessageExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.ValueExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.LLogger;
using Itmo.ObjectOrientedProgramming.Lab3.Mediators;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.MessagesBuilder;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.ValueObjects;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Lab3Tests
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly Mock<Logger> _logger;

    public Lab3Tests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _logger = new Mock<Logger>(new XunitConsoleOutputAdapter(_outputHelper));
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new AddresseeUser(new User(new UserId(1))),
            new AddresseeUser(new User(new UserId(2))),
            new PermissionSystem(),
            new MessageBuilder(),
        };
    }

    [SuppressMessage("Usage", "CA1062:Validate arguments of public methods", Justification = "This is a test method and the parameter is validated.")]
    [Theory]
    [MemberData(nameof(TestData))]
    public void SendMessageTest(AddresseeUser user1, AddresseeUser user2, PermissionSystem permissionSystem, MessageBuilder msgBuilder)
    {
        ValidateParams(new List<object?> { user1, user2, permissionSystem, msgBuilder });

        // Arrange
        _logger.Object.ChangeOutput(new XunitConsoleOutputAdapter(_outputHelper));
        var logProxy = new LoggingAddresseeProxy(user2);

        // Act
        var mediator = new TopicMediator(logProxy, ref permissionSystem);

        var topic = new MessageTopic("User 1 topic", user1, mediator, 1);
        var topic2 = new MessageTopic("User 2 topic", user2, mediator, 2);

        GrantAllPermissions(user1, ref permissionSystem);
        GrantAllPermissions(user2, ref permissionSystem);
        SubscribeEvents(ref mediator, ref logProxy, _logger.Object);

        mediator.RegisterTopic(topic);
        mediator.RegisterTopic(topic2);

        user1.AttachObserver(_logger.Object);
        user2.AttachObserver(_logger.Object);
        topic.SendMessage(CreateTestMessage(ref msgBuilder,  "title1",  "hello world",  1), user2);
        _logger.Object.Show("Messages: " + string.Join("\n-----------", topic2.CheckMessages() ?? throw new InvalidOperationException()));
    }

    [SuppressMessage("Usage", "CA1062:Validate arguments of public methods", Justification = "This is a test method and the parameter is validated.")]
    [Theory]
    [MemberData(nameof(TestData))]
    public void NoUserWritePermissions(AddresseeUser user1, AddresseeUser user2, PermissionSystem permissionSystem, MessageBuilder msgBuilder)
    {
        ValidateParams(new List<object?> { user1, user2, permissionSystem, msgBuilder });

        // Arrange
        _logger.Object.ChangeOutput(new XunitConsoleOutputAdapter(_outputHelper));
        var logProxy = new LoggingAddresseeProxy(user2);

        // Act
        var mediator = new TopicMediator(logProxy, ref permissionSystem);

        var topic = new MessageTopic("TestTopic1", user1, mediator, 1);
        SubscribeEvents(ref mediator, ref logProxy, _logger.Object);

        mediator.RegisterTopic(topic);
        user1.AttachObserver(_logger.Object);
        user2.AttachObserver(_logger.Object);
        topic.SendMessage(CreateTestMessage(ref msgBuilder,  "title1",  "hello world",  1), user2);
        _logger.Verify(x => x.Show(It.IsAny<string>()), Times.Exactly(0));
        _logger.Verify(x => x.HandleUserHasNoPermission(It.IsAny<AddresseeUser>(), It.IsAny<Permissions>()), Times.Exactly(1));
    }

    [SuppressMessage("Usage", "CA1062:Validate arguments of public methods", Justification = "This is a test method and the parameter is validated.")]
    [Theory]
    [MemberData(nameof(TestData))]
    public void ChangeMessageState(AddresseeUser user1, AddresseeUser user2, PermissionSystem permissionSystem, MessageBuilder msgBuilder)
    {
        ValidateParams(new List<object?> { user1, user2, permissionSystem, msgBuilder });

        // Arrange
        _logger.Object.ChangeOutput(new XunitConsoleOutputAdapter(_outputHelper));
        var logProxy = new LoggingAddresseeProxy(user2);

        // Act
        var mediator = new TopicMediator(logProxy, ref permissionSystem);

        var topic = new MessageTopic("User 1 topic", user1, mediator, 1);
        var topic2 = new MessageTopic("User 2 topic", user2, mediator, 2);
        GrantAllPermissions(user1, ref permissionSystem);
        GrantAllPermissions(user2, ref permissionSystem);

        SubscribeEvents(ref mediator, ref logProxy, _logger.Object);
        mediator.RegisterTopic(topic);
        mediator.RegisterTopic(topic2);
        user1.AttachObserver(_logger.Object);
        user2.AttachObserver(_logger.Object);

        topic.SendMessage(CreateTestMessage(ref msgBuilder,  "msg 1",  "this is first message",  1), user2);
        Message msg = user2.GetMessageById(1) ?? throw new NullMessageException();
        msg.MessageStateChanged += (_, args) =>
        {
            _logger.Object.HandleMessageStateChanged(args.Message);
        };

        topic.AddCommand(new MarkAsReadCommand(new List<Message> { msg }));
        topic.ExecuteCommands();
        topic.SendMessage(CreateTestMessage(ref msgBuilder, "msg 2", "aboba", 1), user2);
        _logger.Object.Show(string.Join("\n----------\n", topic2.CheckMessages() ?? throw new InvalidOperationException()));
        _logger.Verify(x => x.HandleMessageStateChanged(It.IsAny<Message>()), Times.Exactly(1));
    }

    private static void ValidateParams(IEnumerable<object?> objects)
    {
        if (objects.Any(p => p == null))
        {
            throw new NullParamException();
        }
    }

    private static void GrantAllPermissions(AddresseeUser user, ref PermissionSystem permissionSystem)
    {
        permissionSystem.GrantPermission(user.User.Id.Id, Permissions.ReadMessages);
        permissionSystem.GrantPermission(user.User.Id.Id, Permissions.WriteMessages);
    }

    private static Message CreateTestMessage(ref MessageBuilder msgBuilder, string title, string bodyText,  int importanceStatus)
    {
        msgBuilder.WithBody(new MessageBody(bodyText));
        msgBuilder.WithTitle(new MessageTitle(title));
        msgBuilder.WithImportanceStatus(new MessageImportance(importanceStatus));
        return msgBuilder.Build();
    }

    private static void SubscribeEvents(ref TopicMediator topicMediator, ref LoggingAddresseeProxy logProxy, Logger logger)
    {
        logProxy.MessageSend += (_, args) =>
        {
            logger.HandleMessageSend(args.MessageFrom, args.Message, args.MessageTo);
        };
        topicMediator.AccessControlSystem.AddresseePermission += (_, args) =>
        {
            logger.HandleUserHasNoPermission(args.Addressee, args.Permission);
        };
    }
}