using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.PrivMxPolicy
{
    public class PrivMxThreadItemPolicy
    {

        [JsonPropertyName("update")]
        public string Update = "all";
    }
}