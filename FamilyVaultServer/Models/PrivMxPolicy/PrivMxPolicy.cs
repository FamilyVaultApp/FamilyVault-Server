using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.PrivMxPolicy
{
    public class PrivMxPolicy
    {
        [JsonPropertyName("thread")]
        public PrivMxThreadPolicy ThreadPolicy = new();
    }
}