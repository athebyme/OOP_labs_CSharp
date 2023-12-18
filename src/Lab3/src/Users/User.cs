using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Users.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    private List<IAddressee> _contacts = new();
    public User(UserId userId)
    {
        Id = userId;
    }

    public UserId Id { get; }
    public IEnumerable<IAddressee> Contacts => _contacts.Select(contact => contact);
    public void AddContact(IAddressee contact)
    {
        _contacts.Add(contact);
    }
}