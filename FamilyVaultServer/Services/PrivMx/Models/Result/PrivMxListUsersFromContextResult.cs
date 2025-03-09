using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Result
{
    public class PrivMxListUsersFromContextResult : PrivMxResponseResult
    {
        [JsonPropertyName("users")]
        public required List<PrivMxContextUser> Users { get; set; }
    }
}
