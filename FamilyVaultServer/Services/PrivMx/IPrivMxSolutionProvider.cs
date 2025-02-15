namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxSolutionProvider
    {
        public Task<string> GetSolutionId();
    }
}
