using FamilyVaultServer.Services.MemberJoinToken.Models;

namespace FamilyVaultServer.Services
{
    public interface IFamilyGroupMemberJoinService
    {
        public FamilyGroupMemberJoin GenerateNew();
        public void Delete(Guid token);
        public FamilyGroupMemberJoin? GetStatusByToken(Guid token);
        public FamilyGroupMemberJoin? UpdateInfo(Guid token, FamilyGroupMemberJoinInfo info);
        public FamilyGroupMemberJoin? UpdateStatus(Guid token, FamilyGroupMemberJoinStatusEnum status);
    }
}
