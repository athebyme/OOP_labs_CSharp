namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength;

public abstract class Hull
{
    protected Hull(decimal health)
    {
        Health = health;
    }

    public decimal Health { get; private set; }
}