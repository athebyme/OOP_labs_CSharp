using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeInstances;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.PermissionsSystem;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.AddresseeExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeProxies;

public class AccessControlSystem
{
    private readonly PermissionSystem _permissionsSystem;

    public AccessControlSystem(
        ref PermissionSystem permissionsSystem)
    {
        _permissionsSystem = permissionsSystem;
    }

    public event EventHandler<AddresseePermissionEventArgs>? AddresseePermission;

    public bool CheckWritePermission(AddresseeUser authenticatedUser)
    {
        if (authenticatedUser == null) throw new NullUserException();

        if (_permissionsSystem.HasPermission(authenticatedUser.User.Id.Id, Permissions.WriteMessages)) return true;

        AddresseePermission?.Invoke(this, new AddresseePermissionEventArgs(authenticatedUser, Permissions.WriteMessages));
        return false;
    }

    public bool CheckReadPermission(int addresseeId, in Addressee addressee)
    {
        if (_permissionsSystem.HasPermission(addresseeId, Permissions.ReadMessages)) return true;

        AddresseePermission?.Invoke(this, new AddresseePermissionEventArgs(addressee, Permissions.ReadMessages));
        return false;
    }
}