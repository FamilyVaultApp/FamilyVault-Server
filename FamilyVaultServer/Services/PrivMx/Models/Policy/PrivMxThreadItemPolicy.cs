using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Policy
{
    public class PrivMxThreadItemPolicy
    {

        [JsonPropertyName("update")]
        public required string Update { get; set; }
    }
}