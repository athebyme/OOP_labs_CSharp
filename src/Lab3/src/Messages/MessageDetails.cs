using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public record struct MessageDetails
{
    public required Message Message { get; init; }
    public required IAddressee Addressee { get; init; }
    public required IAddressee Sender { get; init; }
    public required int Id { get; init; }
    public DateTime SendingTime { get; init; }
}