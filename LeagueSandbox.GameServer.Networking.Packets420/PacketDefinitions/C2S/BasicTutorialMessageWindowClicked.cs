using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.S2CBasicTutorialMessageWindow)] //?
	internal class BasicTutorialMessageWindowClicked : IRequestPacketDefinition
	{
        public byte Cmd { get; }
		public int Unk { get; }

		public BasicTutorialMessageWindowClicked(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = reader.ReadByte();
                Unk = reader.ReadInt32(); // Seems to be always 0
            }
        }

        public BasicTutorialMessageWindowClicked()
        {

        }
    }
}