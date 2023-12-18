using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.PermissionsSystem;

public class PermissionSystem
{
    private readonly List<int> _userIds = new();
    private readonly List<Permissions> _userPermissions = new();

    public void GrantPermission(int userId, Permissions permission)
    {
        int index = _userIds.IndexOf(userId);

        if (index == -1)
        {
            _userIds.Add(userId);
            _userPermissions.Add(permission);
        }
        else
        {
            _userPermissions[index] |= permission;
        }
    }

    public void RevokePermission(int userId, Permissions permission)
    {
        int index = _userIds.IndexOf(userId);

        if (index != -1)
        {
            _userPermissions[index] &= ~permission;
        }
    }

    public bool HasPermission(int userId, Permissions permission)
    {
        int index = _userIds.IndexOf(userId);

        return index != -1 && (_userPermissions[index] & permission) == permission;
    }
}