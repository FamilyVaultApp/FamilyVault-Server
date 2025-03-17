using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class JoinTokenRequest
    {
        [JsonPropertyName("token")]
        public required Guid Token { get; set; }
    }
}
