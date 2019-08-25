using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SHeartBeat)]
	internal class HeartBeat : IRequestPacketDefinition
	{
        public PacketCmd Cmd { get; }
		public int NetId { get; }
		public float ReceiveTime { get; }
		public float AckTime { get; }

		public HeartBeat(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadInt32();
                ReceiveTime = reader.ReadSingle();
                AckTime = reader.ReadSingle();
                reader.Close();
            }
        }
    }
}