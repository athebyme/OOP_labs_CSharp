using Itmo.ObjectOrientedProgramming.Lab1.Exception.Exceptions.VariableExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpecialEvents;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentsModels;

public class SubspaceChannel
{
    public SubspaceChannel(
        double length,
        bool requiresJumpEngine,
        bool hasSpecialEvent,
        SpecialEventsType? specialEventsType)
    {
        if (length < 0) throw new ParameterIsOutOfAvailableRangeException($"{nameof(length)} is < 0 !");

        Length = length;
        RequiredJumpEngine = requiresJumpEngine;
        HasSpecialEvent = hasSpecialEvent;
        SpecialEventType = specialEventsType ?? null;
    }

    public double Length { get; private set; }
    public bool RequiredJumpEngine { get; private set; }
    public bool HasSpecialEvent { get; private set; }
    public SpecialEventsType? SpecialEventType { get; private set; }
}