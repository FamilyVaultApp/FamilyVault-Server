using FamilyVaultServer.Services.PrivMx.Models;

namespace FamilyVaultServer.Utils
{
    public static class PermissionGroupAcls
    {
        public static readonly List<PrivMxAcl> guardianAcl = [
            new PrivMxAcl("ALLOW", "ALL")
        ];

        public static readonly List<PrivMxAcl> memberAcl = [
            new PrivMxAcl("ALLOW", "thread", "READ"),
            new PrivMxAcl("ALLOW", "thread", "threadCreate"),
            new PrivMxAcl("ALLOW", "thread", "threadUpdate"),
            new PrivMxAcl("ALLOW", "thread", "threadMessageSend"),
            new PrivMxAcl("ALLOW", "thread", "threadMessageDelete"),
            new PrivMxAcl("ALLOW", "thread", "threadDelete"),
            new PrivMxAcl("ALLOW", "store", "READ"),
            new PrivMxAcl("ALLOW", "store", "storeCreate"),
            new PrivMxAcl("ALLOW", "store", "storeFileCreate"),
            new PrivMxAcl("ALLOW", "store", "storeFileWrite"),
            new PrivMxAcl("ALLOW", "store", "storeFileDelete"),
            new PrivMxAcl("ALLOW", "inbox", "READ"),
            new PrivMxAcl("ALLOW", "stream", "READ")
        ];

        public static readonly List<PrivMxAcl> guestAcl = [
            new PrivMxAcl("ALLOW", "thread", "READ"),
            new PrivMxAcl("ALLOW", "thread", "threadCreate"),
            new PrivMxAcl("ALLOW", "thread", "threadMessageSend"),
            new PrivMxAcl("ALLOW", "thread", "threadMessageDelete"),
            new PrivMxAcl("ALLOW", "store", "READ"),
            new PrivMxAcl("ALLOW", "store", "storeCreate"),
            new PrivMxAcl("ALLOW", "store", "storeFileCreate"),
            new PrivMxAcl("ALLOW", "store", "storeFileDelete"),
            new PrivMxAcl("ALLOW", "inbox", "READ"),
            new PrivMxAcl("ALLOW", "stream", "READ")
        ];
    }
}