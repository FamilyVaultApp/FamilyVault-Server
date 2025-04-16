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
                PermissionGroup.Member =>
                    "ALLOW thread/READ\n" +
                    "ALLOW thread/threadCreate\n" +
                    "ALLOW thread/threadUpdate\n" +
                    "ALLOW thread/threadMessageSend\n" +
                    "ALLOW thread/threadMessageDelete\n" +
                    "ALLOW thread/threadDelete\n" +
                    "ALLOW store/READ\n" +
                    "ALLOW store/storeFileCreate\n" +
                    "ALLOW store/storeFileWrite\n" +
                    "ALLOW store/storeFileDelete\n" +
                    "ALLOW inbox/READ\n" +
                    "ALLOW stream/READ",

                PermissionGroup.Guest =>
                    "ALLOW thread/READ\n" +
                    "ALLOW thread/threadMessageSend\n" +
                    "ALLOW thread/threadMessageDelete\n" +
                    "ALLOW store/READ\n" +
                    "ALLOW store/storeFileCreate\n" +
                    "ALLOW store/storeFileDelete\n" +
                    "ALLOW inbox/READ\n" +
                    "ALLOW stream/READ",

                _ => throw new ArgumentException("Provided not valid PermissionGroup"),
            };
        }
    }
}
