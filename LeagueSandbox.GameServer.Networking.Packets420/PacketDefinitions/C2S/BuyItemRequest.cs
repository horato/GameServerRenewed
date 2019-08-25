using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SBuyItemReq)]
	internal class BuyItemRequest : IRequestPacketDefinition
	{
		public PacketCmd Cmd { get; }
		public int NetId { get; }
		public int Id { get; }

		public BuyItemRequest(byte[] data)
		{
			using (var reader = new BinaryReader(new MemoryStream(data)))
			{
				Cmd = (PacketCmd)reader.ReadByte();
				NetId = reader.ReadInt32();
				Id = reader.ReadInt32();
			}
		}
	}
}