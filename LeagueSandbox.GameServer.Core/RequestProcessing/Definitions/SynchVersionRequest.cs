namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class SynchVersionRequest : RequestDefinition
    {
        public int SenderNetId { get; }
        public int ClientId { get; }
        public string Version { get; }

        public SynchVersionRequest(int senderNetId, int clientId, string version)
        {
            SenderNetId = senderNetId;
            ClientId = clientId;
            Version = version;
        }
    }
}
