namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxBridgeService
    {
        Task CreateSolution(string name);
        Task CreateFamilyGroup(string solution, string name, string description, string scope);
    }
}
