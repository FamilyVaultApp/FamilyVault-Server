using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class GetFamilyGroupInformation_ContextInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("created")]
        public long Created { get; set; }
        [JsonPropertyName("modified")]
        public long Modified { get; set; }
        [JsonPropertyName("solution")]
        public string Solution { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        [JsonPropertyName("shares")]
        public List<string> Shares { get; set; }
        [JsonPropertyName("policy")]
        public object Policy { get; set; }
    }
}
