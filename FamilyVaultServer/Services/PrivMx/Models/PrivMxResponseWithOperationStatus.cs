using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models
{
    public class PrivMxResponseWithOperationStatus : PrivMxResponse
    {
        [JsonPropertyName("result")]
        public string? Result { get; set; }
    }
}
