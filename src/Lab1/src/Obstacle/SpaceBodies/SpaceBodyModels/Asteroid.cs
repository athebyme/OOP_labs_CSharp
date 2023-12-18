namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle.SpaceBodies.SpaceBodyModels;

public sealed class Asteroid : SpaceBody
{
    private const int BaseDamage = 10;
    public Asteroid()
        : base(BaseDamage)
    {
    }
}