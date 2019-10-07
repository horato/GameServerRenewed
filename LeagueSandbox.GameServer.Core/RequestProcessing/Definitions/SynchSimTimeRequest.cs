namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class SynchSimTimeRequest : RequestDefinition
    {
        public uint SenderNetId { get; }
        public float TimeLastServerMilliseconds { get; }
        public float TimeLastClientMilliseconds { get; }

        public SynchSimTimeRequest(uint senderNetId, float timeLastServerMilliseconds, float timeLastClientMilliseconds)
        {
            SenderNetId = senderNetId;
            TimeLastServerMilliseconds = timeLastServerMilliseconds;
            TimeLastClientMilliseconds = timeLastClientMilliseconds;
        }
    }
}
