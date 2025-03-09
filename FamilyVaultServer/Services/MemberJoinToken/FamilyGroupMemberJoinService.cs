using FamilyVaultServer.Services.MemberJoinToken.Models;

namespace FamilyVaultServer.Services.MemberJoinToken
{
    public class FamilyGroupMemberJoinService : IFamilyGroupMemberJoinService
    {
        private List<FamilyGroupMemberJoinStatus> statuses = [];

        public FamilyGroupMemberJoinStatus GenerateNew()
        {
            var memberJoinStatus = FamilyGroupMemberJoinStatus.New();
            statuses.Add(memberJoinStatus);
            return memberJoinStatus;
        }
        public void Delete(Guid token)
        {
            statuses.RemoveAll(js => js.Token == token);
        }
        public FamilyGroupMemberJoinStatus? GetStatusByToken(Guid token)
        {
            return statuses.Find(js => js.Token == token);
        }
        public FamilyGroupMemberJoinStatus? UpdateInfo(Guid token, FamilyGroupMemberJoinStatusInfo info)
        {
            var joinStatus = GetStatusByToken(token);

            if (joinStatus != null)
            {
                joinStatus.Info = info;
            }

            return joinStatus;
        }
        public FamilyGroupMemberJoinStatus? UpdateStatus(Guid token, FamilyGroupMemberJoinStatusEnum status)
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
