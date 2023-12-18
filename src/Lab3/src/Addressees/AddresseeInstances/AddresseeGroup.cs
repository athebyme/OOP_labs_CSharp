using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;

public class AddresseeGroup : Addressee, IAddresseeComponent
{
    private List<Addressee> _addressees = new();

    public AddresseeGroup(AddresseeId addresseeId)
        : base(addresseeId)
    {
    }

    public void AddAddressee(Addressee addressee)
    {
        _addressees.Add(addressee);
    }

    public override void ReceiveMessage(Message message, AddresseeUser msgFrom)
    {
        foreach (Addressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message, msgFrom);
        }
    }
}