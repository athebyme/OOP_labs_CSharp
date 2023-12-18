using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.PermissionsSystem;

[Flags]
public enum Permissions
{
    None = 0,
    ReadMessages = 1 << 0,
    WriteMessages = 1 << 1,
    DeleteMessages = 1 << 2,
}