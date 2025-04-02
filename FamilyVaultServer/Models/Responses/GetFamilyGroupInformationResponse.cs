using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class GetFamilyGroupInformationResponse
    {
        [JsonPropertyName("context")]
        public GetFamilyGroupInformation_ContextInfo ContextInfo { get; set; }
    }
}
