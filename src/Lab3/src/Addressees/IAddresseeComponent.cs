using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public interface IAddresseeComponent
{
    AddresseeId AddresseeId { get; }
}