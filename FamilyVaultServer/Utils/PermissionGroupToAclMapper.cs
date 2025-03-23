using FamilyVaultServer.Models;

namespace FamilyVaultServer.Utils
{
    public static class PermissionGroupToAclMapper
    {
        public static string Map(PermissionGroup permissionGroup)
        {
            return permissionGroup switch
            {
                PermissionGroup.Guardian => "ALLOW ALL",
                PermissionGroup.Member => "DENY ALL",
                PermissionGroup.Guest => "DENY ALL",
                _ => throw new ArgumentException("Provided not valid PermissionGroup"),
            };
        }
    }
}
