using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Result
{
    public class PrivMxCreateSolutionResult : PrivMxResponseResult
    {
        [JsonPropertyName("solutionId")]
        public string SolutionId { get; set; } = string.Empty;
    }
}
