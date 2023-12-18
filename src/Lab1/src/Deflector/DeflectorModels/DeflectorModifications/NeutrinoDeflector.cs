namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels.DeflectorModifications;

public class NeutrinoDeflector : DeflectorDecorator
{
    public NeutrinoDeflector(Deflector deflector)
        : base(deflector)
    {
    }

    public override Lab1.Deflector.DeflectorModifications DeflectorModification() => Lab1.Deflector.DeflectorModifications.Neutrino;
}