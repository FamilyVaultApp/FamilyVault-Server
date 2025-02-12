using FamilyVaultServer.Models;
using FamilyVaultServer.Models.Responses;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxBridgeClient
    {
        Task<object> ExecuteMethod(string methodName, object parameters);
        Task<PrivMxResponseModel> ExecuteMethod(PrivMxCommunicationModel model);
    }
}
