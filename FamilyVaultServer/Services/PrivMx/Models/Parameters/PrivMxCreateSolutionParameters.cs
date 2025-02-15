using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxCreateSolutionParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
