using FamilyVaultServer.Services.PrivMx;
using System.Text.Json;

namespace FamilyVaultServer.Exceptions
{
    public class JsonRpcResponse
    {
        public string Jsonrpc { get; set; } = "2.0";
        public int Id { get; set; }
        public JsonElement? Result { get; set; }
        public JsonRpcResponseError? Error { get; set; }
    }
}
