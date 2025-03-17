namespace FamilyVaultServer.Services.MemberJoinToken.Models
{
    public class JoinStatus
    {
        public required Guid Token { get; set; }
        public required JoinStatusState State { get; set; } = JoinStatusState.Initiated;
        public JoinStatusInfo? Info { get; set; } = null;
        public static JoinStatus New()
        {
            return new JoinStatus { Token = Guid.NewGuid(), State = JoinStatusState.Pending };
        }
    }
}