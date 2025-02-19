using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxCreateSolutionParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
