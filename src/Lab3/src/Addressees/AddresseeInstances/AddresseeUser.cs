using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;

public class AddresseeUser : Addressee, IAddresseeComponent
{
    public AddresseeUser(User user)
        : base(new AddresseeId(user?.Id.Id ?? -1))
    {
        User = user ?? throw new NullUserException();
    }

    public User User { get; }
}