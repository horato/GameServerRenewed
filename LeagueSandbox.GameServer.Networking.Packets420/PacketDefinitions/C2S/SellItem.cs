using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SSellItem)]
	internal class SellItem : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public int NetId { get; }
		public byte SlotId { get; }

		public SellItem(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadInt32();
                SlotId = reader.ReadByte();
            }
        }
    }
}