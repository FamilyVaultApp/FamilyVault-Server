using FamilyVaultServer.Services.MemberJoinToken.Models;

namespace FamilyVaultServer.Services.MemberJoinToken
{
    public class FamilyGroupMemberJoinService : IFamilyGroupMemberJoinService
    {
        private List<FamilyGroupMemberJoin> statuses = [];

        public FamilyGroupMemberJoin GenerateNew()
        {
            var memberJoinStatus = FamilyGroupMemberJoin.New();
            statuses.Add(memberJoinStatus);
            return memberJoinStatus;
        }
        public void Delete(Guid token)
        {
            statuses.RemoveAll(js => js.Token == token);
        }
        public FamilyGroupMemberJoin? GetStatusByToken(Guid token)
        {
            return statuses.Find(js => js.Token == token);
        }
        public FamilyGroupMemberJoin? UpdateInfo(Guid token, FamilyGroupMemberJoinInfo info)
        {
            var joinStatus = GetStatusByToken(token);

            if (joinStatus != null)
            {
                joinStatus.Info = info;
            }

            return joinStatus;
        }
        public FamilyGroupMemberJoin? UpdateStatus(Guid token, FamilyGroupMemberJoinStatusEnum status)
        {
            var joinStatus = GetStatusByToken(token);

            if (joinStatus != null)
            {
                joinStatus.Status = status;
            }

            return joinStatus;
        }
    }
}
