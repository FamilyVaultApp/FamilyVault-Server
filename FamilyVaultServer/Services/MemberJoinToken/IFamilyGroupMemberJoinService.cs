using FamilyVaultServer.Services.MemberJoinToken.Models;

namespace FamilyVaultServer.Services
{
    public interface IFamilyGroupMemberJoinService
    {
        public FamilyGroupMemberJoinStatus GenerateNew();
        public void Delete(Guid token);
        public FamilyGroupMemberJoinStatus? GetStatusByToken(Guid token);
        public FamilyGroupMemberJoinStatus? UpdateInfo(Guid token, FamilyGroupMemberJoinStatusInfo info);
        public FamilyGroupMemberJoinStatus? UpdateStatus(Guid token, FamilyGroupMemberJoinStatusEnum status);
    }
}
