namespace Itmo.ObjectOrientedProgramming.Lab1.Raid.RaidResults;

public class Results
{
    public Results(Spaceship.Spaceship? spaceship, ResultType result, ResultTypeAddiction details)
    {
        ResultType = result;
        Spaceship = spaceship;
        Details = details;
    }

    public ResultType ResultType { get; }
    public Spaceship.Spaceship? Spaceship { get; }
    public ResultTypeAddiction Details { get; }
}