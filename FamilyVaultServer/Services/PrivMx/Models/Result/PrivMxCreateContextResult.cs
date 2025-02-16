using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Result
{
    public class PrivMxCreateContextResult : PrivMxResponseResult
    {
        [JsonPropertyName("contextId")]
        public string ContextId { get; set; } = string.Empty;
    }
}
