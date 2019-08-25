using System.IO;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SClientReady, Channel.LoadingScreen)]
	internal class ClientReady : IRequestPacketDefinition
	{
		public PacketCmd Cmd { get; }
		public uint PlayerId { get; }
		public TeamId TeamId { get; }

		public ClientReady(byte[] data)
		{
			using (var reader = new BinaryReader(new MemoryStream(data)))
			{
				Cmd = (PacketCmd)reader.ReadByte();
				PlayerId = reader.ReadUInt32();
				TeamId = (TeamId)reader.ReadInt16();
			}
		}
	}
}