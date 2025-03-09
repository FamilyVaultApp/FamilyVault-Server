using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxListUsersFromContextParemeters : PrivMxRequestParameters
    {
        [JsonPropertyName("contextId")]
        public required string ContextId{ get; set; }
        [JsonPropertyName("skip")]
        public required int Skip { get; set; }
        [JsonPropertyName("limit")]
        public required int Limit { get; set; } 
        [JsonPropertyName("sortOrder")]
        public required string SortOrder { get; set; }
    }
}   
