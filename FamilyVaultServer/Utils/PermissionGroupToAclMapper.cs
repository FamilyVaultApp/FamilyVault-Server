using FamilyVaultServer.Models;
using FamilyVaultServer.Services.PrivMx.Models;

namespace FamilyVaultServer.Utils
{
    public static class PermissionGroupToAclMapper
    {
        public static string Map(PermissionGroup permissionGroup)
        {
            return permissionGroup switch
            {
                PermissionGroup.Guardian => AclListToString(PermissionGroupAcls.guardianAcl),

                PermissionGroup.Member => AclListToString(PermissionGroupAcls.memberAcl),

                PermissionGroup.Guest => AclListToString(PermissionGroupAcls.guestAcl),

                _ => throw new ArgumentException("Provided not valid PermissionGroup"),
            };
        }

        private static string AclListToString(List<PrivMxAcl> acls) =>
            string.Join("\n", acls.Select((acl) => acl.ToString()));
    }
}
