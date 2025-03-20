using FamilyVaultServer.Services.MemberJoinToken.Models;

namespace FamilyVaultServer.Services.MemberJoinToken
{
    public class JoinStatusService : IJoinStatusService
    {
        private List<JoinStatus> joinStatuses = [];

        public JoinStatus GenerateNew()
        {
            var joinStatus = JoinStatus.New();
            joinStatuses.Add(joinStatus);
            return joinStatus;
        }

        public void Delete(Guid token)
        {
            joinStatuses.RemoveAll(js => js.Token == token);
        }
        
        public JoinStatus? GetStatusByToken(Guid token)
        {
            return joinStatuses.Find(js => js.Token == token);
        }
        
        public JoinStatus? UpdateInfo(Guid token, JoinStatusInfo info)
        {
            var joinStatus = GetStatusByToken(token);

            if (joinStatus != null)
            {
                joinStatus.Info = info;
            }

            return joinStatus;
        }
        
        public JoinStatus? UpdateStatus(Guid token, JoinStatusState status)
        {
            var joinStatus = GetStatusByToken(token);

            if (joinStatus != null)
            {
                joinStatus.State = status;
            }

            return joinStatus;
        }
    }
}
