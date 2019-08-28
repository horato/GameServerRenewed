namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
	public class KeyCheckRequest : RequestDefinition
	{
		public byte[] PartialKey { get; }
        public int ClientID { get; }
        public ulong SummonerId { get; }
        public uint VersionNo { get; }
        public ulong CheckId { get; }

        public KeyCheckRequest(byte[] partialKey, int clientId, ulong summonerId, uint versionNo, ulong checkId)
        {
            PartialKey = partialKey;
            ClientID = clientId;
            SummonerId = summonerId;
            VersionNo = versionNo;
            CheckId = checkId;
        }
    }
}
