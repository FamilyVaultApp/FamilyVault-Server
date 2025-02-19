using FamilyVaultServer.Services.PrivMx.Models.Result;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models
{
    public class PrivMxResponseWithResult<TResult> : PrivMxResponse
        where TResult : PrivMxResponseResult
    {
        [JsonPropertyName("result")]
        public new TResult? Result { get; set; }
    }
}
