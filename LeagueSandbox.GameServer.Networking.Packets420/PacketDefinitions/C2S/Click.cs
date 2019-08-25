using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SClick)]
	internal class Click : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public int NetId { get; }
		public int Zero { get; }
		public uint TargetNetId { get; } // netId on which the player clicked

		public Click(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadInt32();
                Zero = reader.ReadInt32();
                TargetNetId = reader.ReadUInt32();
            }
        }
    }
}