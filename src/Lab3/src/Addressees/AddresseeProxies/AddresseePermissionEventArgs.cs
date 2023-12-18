using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.PermissionsSystem;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.AddresseeProxies;

public class AddresseePermissionEventArgs : EventArgs
{
    public AddresseePermissionEventArgs(Addressee addressee, Permissions permission)
    {
        Addressee = addressee;
        Permission = permission;
    }

    public Addressee Addressee { get; }
    public Permissions Permission { get; }
}