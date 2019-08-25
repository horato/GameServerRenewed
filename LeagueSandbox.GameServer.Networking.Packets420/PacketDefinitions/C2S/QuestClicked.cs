using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SQuestClicked)]
	internal class QuestClicked : IRequestPacketDefinition
	{
        public byte Cmd { get; }
		public uint PlayerNetId { get; }
		public byte Unk { get; }
		public uint NetId { get; }

		public QuestClicked(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = reader.ReadByte();
                PlayerNetId = reader.ReadUInt32();
                Unk = reader.ReadByte();
                NetId = reader.ReadUInt32();
            }
        }
    }
}