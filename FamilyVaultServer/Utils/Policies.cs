using FamilyVaultServer.Services.PrivMx.Models.Policy;

namespace FamilyVaultServer.Utils
{
    public static class Policies
    {
        public static PrivMxPolicy Default = new PrivMxPolicy
        {
            Thread = new PrivMxThreadPolicy
            {
                Item = new PrivMxThreadItemPolicy { Update = "all" }
            }
        };
    }
}
