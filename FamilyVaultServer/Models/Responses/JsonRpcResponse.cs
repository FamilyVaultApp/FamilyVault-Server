using FamilyVaultServer.Exceptions;
using System.Text.Json;

namespace FamilyVaultServer.Models.Responses
{
    public class JsonRpcResponse
    {
        public string Jsonrpc { get; set; } = "2.0";
        public int Id { get; set; }
        public JsonElement? Result { get; set; }
        public JsonRpcResponseError? Error { get; set; }
    }
}
