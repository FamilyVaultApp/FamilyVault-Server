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
                PermissionGroup.Member => "ALLOW ALL",
                PermissionGroup.Guest => "ALLOW ALL",
                _ => throw new ArgumentException("Provided not valid PermissionGroup"),
            };
        }
    }
}
