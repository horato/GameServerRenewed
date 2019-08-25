using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SAutoAttackOption)]
	internal class AutoAttackOption : IRequestPacketDefinition
	{
        public byte Cmd { get; }
		public int NetId { get; }
		public byte Activated { get; }

		public AutoAttackOption(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = reader.ReadByte();
                NetId = reader.ReadInt32();
                Activated = reader.ReadByte();
            }
        }
    }
}