using FamilyVaultServer.Services.MemberJoinToken.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class JoinStatusResponse
    {
        [JsonPropertyName("joinStatus")]
        public required JoinStatus JoinStatus { get; set; }
    }
}
