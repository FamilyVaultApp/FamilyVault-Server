using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models
{
    public class PrivMxCommunicationModel
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = "2.0";
        [JsonPropertyName("id")]
        public int Id { get; set; } = 128;
        [JsonPropertyName("method")]
        public string Method { get; set; } = String.Empty;
        [JsonPropertyName("params")]
        public object Parameters { get; set; } = new { };

        static public PrivMxCommunicationModel Create(string methodName, object parameters)
        {
            return new PrivMxCommunicationModel
            {
                Method = methodName,
                Parameters = parameters
            };
        }
    }
}
