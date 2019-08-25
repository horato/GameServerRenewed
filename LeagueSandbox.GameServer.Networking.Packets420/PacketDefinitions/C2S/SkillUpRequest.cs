using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SSkillUp)]
	internal class SkillUpRequest : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public uint NetId { get; }
		public byte Skill { get; }

		public SkillUpRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                Skill = reader.ReadByte();
            }
        }
    }
}