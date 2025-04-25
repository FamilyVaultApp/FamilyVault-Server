using FamilyVaultServer.Models;
using FamilyVaultServer.Services.PrivMx.Models;

namespace FamilyVaultServer.Utils
{
    public static class AclToPermissionGroupMapper
    {
        public static PermissionGroup Map(string acl)
        {
            if (HasAllRequiredAcls(acl, PermissionGroupAcls.guardianAcl))
            {
                return PermissionGroup.Guardian;
            }

            if (HasAllRequiredAcls(acl, PermissionGroupAcls.memberAcl))
            {
                return PermissionGroup.Member;
            }

            if (HasAllRequiredAcls(acl, PermissionGroupAcls.guestAcl))
            {
                return PermissionGroup.Guest;
            }

            return PermissionGroup.Unknown;
        }

        private static bool HasAllRequiredAcls(string acl, List<PrivMxAcl> acls) =>
            acls.All((requiredAcl) => acl.Contains(requiredAcl.ToString()));
    }
}
