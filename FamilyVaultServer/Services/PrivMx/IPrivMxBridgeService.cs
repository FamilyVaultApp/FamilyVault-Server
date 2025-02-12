using FamilyVaultServer.Models.Responses;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxBridgeService
    {
        Task<PrivMxResponseModel> CreateSolution(string name);
        Task<PrivMxResponseModel> CreateFamilyGroup(string solution, string name, string description, string scope);
    }
}
