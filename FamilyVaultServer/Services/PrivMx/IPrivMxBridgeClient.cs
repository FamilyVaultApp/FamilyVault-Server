using FamilyVaultServer.Services.PrivMx.Models;
using FamilyVaultServer.Services.PrivMx.Models.Params;
using FamilyVaultServer.Services.PrivMx.Models.Result;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxBridgeClient
    {
        Task<TResponseResult> ExecuteMethod<TRequestParameters, TResponseResult>(string methodName, TRequestParameters parameters)
            where TResponseResult : PrivMxResponseResult
            where TRequestParameters : PrivMxRequestParameters;
        Task<TResponseResult> SendRequest<TRequestParameters, TResponseResult>(PrivMxRequest<TRequestParameters> request) 
            where TResponseResult : PrivMxResponseResult
            where TRequestParameters : PrivMxRequestParameters;
    }
}
