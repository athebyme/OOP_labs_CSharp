namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector.DeflectorModels.DeflectorModifications;

public class PhotonDeflector : DeflectorDecorator
{
    public PhotonDeflector(Deflector deflector)
        : base(deflector)
    {
    }

    public override Lab1.Deflector.DeflectorModifications DeflectorModification() => Lab1.Deflector.DeflectorModifications.Photon;
}