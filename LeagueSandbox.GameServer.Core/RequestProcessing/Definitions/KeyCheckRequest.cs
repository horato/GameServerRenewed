namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
	public class KeyCheckRequest : RequestDefinition
	{
		public byte[] PartialKey { get; } = new byte[3];
		public uint ClientId { get; }
		public ulong SummonerId { get; }
		public uint VersionNo { get; }
		public ulong CheckId { get; }

		public KeyCheckRequest(uint clientId, ulong summonerId, uint versionNo, ulong checkId)
		{
			ClientId = clientId;
			SummonerId = summonerId;
			VersionNo = versionNo;
			CheckId = checkId;
		}
	}
}
