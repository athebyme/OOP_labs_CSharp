namespace Itmo.ObjectOrientedProgramming.Lab2.Parameters.PowerSettings;

public class Power
{
    public Power(int wattConsuming)
    {
        Watt = new Watt(wattConsuming);
    }

    public Watt Watt { get; private set; }
}