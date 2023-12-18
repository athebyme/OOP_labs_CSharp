using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;

public class AddresseeMessenger : Addressee, IAddresseeComponent
{
    public AddresseeMessenger(AddresseeId addresseeId)
        : base(addresseeId)
    {
    }
}