namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpaceBodies.SpaceBodyModels;

public class Meteorite : SpaceBody
{
    private const int BaseDamage = 25;
    public Meteorite()
        : base(BaseDamage)
    {
    }
}