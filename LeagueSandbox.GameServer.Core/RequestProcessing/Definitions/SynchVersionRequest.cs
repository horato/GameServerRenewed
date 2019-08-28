namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class SynchVersionRequest : RequestDefinition
    {
        public uint SenderNetId { get; }
        public int ClientId { get; }
        public string Version { get; }

        public SynchVersionRequest(uint senderNetId, int clientId, string version)
        {
            SenderNetId = senderNetId;
            ClientId = clientId;
            Version = version;
        }
    }
}
