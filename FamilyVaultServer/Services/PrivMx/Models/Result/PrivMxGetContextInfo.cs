using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Result
{
    public class PrivMxGetContextResult : PrivMxResponseResult
    {
        [JsonPropertyName("context")]
        public PrivMxGetContext_ContextInfo ContextInfo { get; set; }
    }
}