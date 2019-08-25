using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SUseObject)]
	internal class UseObject : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public uint NetId { get; }
		public uint TargetNetId { get; } // netId of the object used

		public UseObject(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                TargetNetId = reader.ReadUInt32();
            }
        }
    }
}