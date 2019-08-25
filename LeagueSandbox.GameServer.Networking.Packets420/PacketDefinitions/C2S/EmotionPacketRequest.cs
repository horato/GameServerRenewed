using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SEmotion)]
	internal class EmotionPacketRequest : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public uint NetId { get; }
		public EmotionType Id { get; }

		public EmotionPacketRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                Id = (EmotionType)reader.ReadByte();
            }
        }
    }
}