using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Result
{
    public class PrivMxGetUserFromContextResult : PrivMxResponseResult
    {
        [JsonPropertyName("user")]
        public required PrivMxContextUser User { get; set; }
    }
}
