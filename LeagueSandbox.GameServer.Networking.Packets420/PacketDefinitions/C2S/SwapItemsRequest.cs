using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SSwapItems)]
	internal class SwapItemsRequest : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public int NetId { get; }
		public byte SlotFrom { get; }
		public byte SlotTo { get; }

		public SwapItemsRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadInt32();
                SlotFrom = reader.ReadByte();
                SlotTo = reader.ReadByte();
            }
        }
    }
}