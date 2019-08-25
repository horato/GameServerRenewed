using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SMoveReq)]
	internal class MovementRequest : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public int NetIdHeader { get; }
		public MovementType Type { get; }
		public float X { get; }
		public float Y { get; }
		public uint TargetNetId { get; }
		public byte CoordCount { get; }
		public int NetId { get; }
		public byte[] MoveData { get; }

		public MovementRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetIdHeader = reader.ReadInt32();
                Type = (MovementType)reader.ReadByte();
                X = reader.ReadSingle();
                Y = reader.ReadSingle();
                TargetNetId = reader.ReadUInt32();
                CoordCount = reader.ReadByte();
                NetId = reader.ReadInt32();
                MoveData = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
            }
        }
    }
}