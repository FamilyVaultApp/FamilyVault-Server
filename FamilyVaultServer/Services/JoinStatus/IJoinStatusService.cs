using FamilyVaultServer.Services.MemberJoinToken.Models;

namespace FamilyVaultServer.Services
{
    public interface IJoinStatusService
    {
        public JoinStatus GenerateNew();
        public void Delete(Guid token);
        public JoinStatus? GetStatusByToken(Guid token);
        public JoinStatus? UpdateInfo(Guid token, JoinStatusInfo info);
        public JoinStatus? UpdateStatus(Guid token, JoinStatusState status);
    }
}
