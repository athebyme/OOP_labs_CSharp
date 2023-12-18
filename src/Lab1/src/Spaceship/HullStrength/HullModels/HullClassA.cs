namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.HullStrength.HullModels;

public class HullClassA : Hull
{
    private const decimal BaseHealth = 10m;
    public HullClassA()
        : base(BaseHealth)
    {
    }
}