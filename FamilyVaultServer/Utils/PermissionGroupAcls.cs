using FamilyVaultServer.Models;

public static class PermissionGroupAcls
{
    public const string guardianAcl = "ALLOW ALL";
    public const string memberAcl =
        "ALLOW thread/READ\n" +
        "ALLOW thread/threadCreate\n" +
        "ALLOW thread/threadUpdate\n" +
        "ALLOW thread/threadMessageSend\n" +
        "ALLOW thread/threadMessageDelete\n" +
        "ALLOW thread/threadDelete\n" +
        "ALLOW store/READ\n" +
        "ALLOW store/storeCreate\n" +
        "ALLOW store/storeFileCreate\n" +
        "ALLOW store/storeFileWrite\n" +
        "ALLOW store/storeFileDelete\n" +
        "ALLOW inbox/READ\n" +
        "ALLOW stream/READ";
    public const string guestAcl =
        "ALLOW thread/READ\n" +
        "ALLOW thread/threadCreate\n" +
        "ALLOW thread/threadMessageSend\n" +
        "ALLOW thread/threadMessageDelete\n" +
        "ALLOW store/READ\n" +
        "ALLOW store/storeCreate\n" +
        "ALLOW store/storeFileCreate\n" +
        "ALLOW store/storeFileDelete\n" +
        "ALLOW inbox/READ\n" +
        "ALLOW stream/READ";
}