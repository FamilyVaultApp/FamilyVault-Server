using FamilyVaultServer.Services.MemberJoinToken.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class JoinUpdateInfoRequest
    {
        [JsonPropertyName("token")]
        public required Guid Token { get; set; }
        [JsonPropertyName("info")]
        public required JoinStatusInfo Info { get; set; }
    }
}
