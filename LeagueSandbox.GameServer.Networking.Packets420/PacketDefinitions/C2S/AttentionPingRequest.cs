using System.IO;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SAttentionPing)]
	internal class AttentionPingRequest : IRequestPacketDefinition
	{
		public byte Cmd { get; }
		public int Unk1 { get; }
		public float X { get; }
		public float Y { get; }
		public int TargetNetId { get; }
		public Pings Type { get; }

		public AttentionPingRequest(byte[] data)
		{
			using (var reader = new BinaryReader(new MemoryStream(data)))
			{
				Cmd = reader.ReadByte();
				Unk1 = reader.ReadInt32();
				X = reader.ReadSingle();
				Y = reader.ReadSingle();
				TargetNetId = reader.ReadInt32();
				Type = (Pings)reader.ReadByte();
			}
		}

		public AttentionPingRequest(float x, float y, int netId, Pings type)
		{
			X = x;
			Y = y;
			TargetNetId = netId;
			Type = type;
		}
	}
}