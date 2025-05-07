using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Policy
{
    public class PrivMxPolicy
    {
        [JsonPropertyName("thread")]
        public required PrivMxThreadPolicy Thread { get; set; }
    }
}