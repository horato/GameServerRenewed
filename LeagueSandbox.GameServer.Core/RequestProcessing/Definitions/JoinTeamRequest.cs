using System.IO;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class JoinTeamRequest : RequestDefinition
    {
        public int ClientId { get; set; }
        public uint NetTeamId { get; set; }

        public JoinTeamRequest(int clientId, uint netTeamId)
        {
            ClientId = clientId;
            NetTeamId = netTeamId;
        }
    }
}