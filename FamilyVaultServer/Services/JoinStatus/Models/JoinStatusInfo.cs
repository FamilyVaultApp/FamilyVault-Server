using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.MemberJoinToken.Models
{
    public class JoinStatusInfo
    {
        [JsonPropertyName("contextId")]
        public string? ContextId  { get; set; }
        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }
}
