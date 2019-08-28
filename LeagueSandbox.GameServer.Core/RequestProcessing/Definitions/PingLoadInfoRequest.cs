using System.IO;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class PingLoadInfoRequest : RequestDefinition
    {
        public uint SenderNetId { get; }
        public int ClientId { get; set; }
        public ulong SummonerId { get; set; }
        public float Percentage { get; set; }
        public float ETA { get; set; }
        public ushort Count { get; set; }
        public ushort Ping { get; set; }
        public bool Ready { get; set; }

        public PingLoadInfoRequest(uint senderNetId, int clientId, ulong summonerId, float percentage, float eta, ushort count, ushort ping, bool ready)
        {
            SenderNetId = senderNetId;
            ClientId = clientId;
            SummonerId = summonerId;
            Percentage = percentage;
            ETA = eta;
            Count = count;
            Ping = ping;
            Ready = ready;
        }
    }
}