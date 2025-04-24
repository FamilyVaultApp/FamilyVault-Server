using FamilyVaultServer.Models;

namespace FamilyVaultServer.Utils
{
    public static class AclToPermissionGroupMapper
    {
        public static PermissionGroup Map(string acl)
        {
            return acl switch
            {
                PermissionGroupAcls.guestAcl => PermissionGroup.Guest,

                PermissionGroupAcls.memberAcl => PermissionGroup.Member,

                PermissionGroupAcls.guardianAcl => PermissionGroup.Guardian,

                _ => throw new ArgumentException("Provided not valid ACL"),
            };
        }
    }
}
