using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SPingLoadInfo)]
	internal class PingLoadInfoRequest : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public uint NetId { get; }
		public int Position { get; }
		public long UserId { get; }
		public float Loaded { get; }
		public float Unk2 { get; }
		public short Ping { get; }
		public short Unk3 { get; }
		public byte Unk4 { get; }

		public PingLoadInfoRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                Position = reader.ReadInt32();
                UserId = reader.ReadInt64();
                Loaded = reader.ReadSingle();
                Unk2 = reader.ReadSingle();
                Ping = reader.ReadInt16();
                Unk3 = reader.ReadInt16();
                Unk4 = reader.ReadByte();
            }
        }
    }
}