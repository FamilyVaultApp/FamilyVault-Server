using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Result
{
    public class PrivMxGetContext : PrivMxResponseResult
    {
        [JsonPropertyName("context")]
        public required PrivMxContext Context { get; set; }
    }
}