using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Policy
{
    public class PrivMxThreadPolicy
    {
        [JsonPropertyName("item")]
        public required PrivMxThreadItemPolicy Item { get; set; }
    }
}