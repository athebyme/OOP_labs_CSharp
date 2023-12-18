using Itmo.ObjectOrientedProgramming.Lab2.Exceptions.ParamExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Memory.RAM.XMP;

public class Timings
{
    public Timings(int rasToCas, int rasPrecharge, int ras, int rc)
    {
        if (rasToCas < 0 || rasPrecharge < 0 || ras < 0 || rc < 0)
            throw new ParamOutOfRangeException();
        RasToCas = rasToCas;
        RasPrecharge = rasPrecharge;
        Ras = ras;
        Rc = rc;
    }

    public int RasToCas { get; private set; }
    public int RasPrecharge { get; private set; }
    public int Ras { get; private set; }
    public int Rc { get; private set; }
}