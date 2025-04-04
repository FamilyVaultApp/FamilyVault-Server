using FamilyVaultServer.Services.PrivMx.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class GetFamilyGroupInformationResponse
    {
        [JsonPropertyName("context")]
        public required PrivMxContext Context { get; set; }
    }
}
