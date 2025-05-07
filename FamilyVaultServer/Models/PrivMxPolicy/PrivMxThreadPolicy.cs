using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.PrivMxPolicy
{
    public class PrivMxThreadPolicy
    {
        [JsonPropertyName("item")]
        public PrivMxThreadItemPolicy item = new();
    }
}