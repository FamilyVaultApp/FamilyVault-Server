using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models
{
    public class PrivMxRequest<TRequestParameters> 
        where TRequestParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "2.0";
        [JsonPropertyName("id")]
        public int Id { get; set; } = 128;
        [JsonPropertyName("method")]
        public required string Method { get; set; } 
        [JsonPropertyName("params")]
        public required TRequestParameters Parameters { get; set; }

        static public PrivMxRequest<TRequestParameters> Create(string methodName, TRequestParameters parameters)
        {
            return new PrivMxRequest<TRequestParameters>
            {
                Method = methodName,
                Parameters = parameters
            };
        }
    }
}
