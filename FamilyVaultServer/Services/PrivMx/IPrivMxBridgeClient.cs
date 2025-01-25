using FamilyVaultServer.Models;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxBridgeClient
    {
        Task<object> ExecuteMethod(string methodName, object parameters);
        Task<object> ExecuteMethod(PrivMxCommunicationModel model);
    }
}
