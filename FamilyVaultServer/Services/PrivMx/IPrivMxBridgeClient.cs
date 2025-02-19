using FamilyVaultServer.Services.PrivMx.Models.Params;
using FamilyVaultServer.Services.PrivMx.Models.Result;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxBridgeClient
    {
        Task<bool> ExecuteMethodWithOperationStatus<TRequestParameters>(string methodName, TRequestParameters parameters)
            where TRequestParameters : PrivMxRequestParameters;

        Task<TResponseResult> ExecuteMethodWithResponse<TRequestParameters, TResponseResult>(string methodName, TRequestParameters parameters)
            where TResponseResult : PrivMxResponseResult
            where TRequestParameters : PrivMxRequestParameters;
    }
}
