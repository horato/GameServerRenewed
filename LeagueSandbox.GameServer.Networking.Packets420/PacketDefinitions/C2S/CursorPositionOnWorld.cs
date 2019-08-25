using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SCursorPositionOnWorld)]
	internal class CursorPositionOnWorld : IRequestPacketDefinition
	{
        public byte Cmd { get; }
		public uint NetId { get; }
		public short Unk1 { get; } // Maybe 2 bytes instead of 1 short?
		public float X { get; }
		public float Z { get; }
		public float Y { get; }

		public CursorPositionOnWorld(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = reader.ReadByte();
                NetId = reader.ReadUInt32();
                Unk1 = reader.ReadInt16();
                X = reader.ReadSingle();
                Z = reader.ReadSingle();
                Y = reader.ReadSingle();
            }
        }
    }
}