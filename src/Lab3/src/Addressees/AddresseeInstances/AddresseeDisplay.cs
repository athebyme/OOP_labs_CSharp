using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;

public class AddresseeDisplay : Addressee, IAddresseeComponent
{
    public AddresseeDisplay(AddresseeId addresseeId)
        : base(addresseeId)
    {
    }
}