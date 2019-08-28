using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SSynchVersion)]
	internal class SynchVersionRequest : IRequestPacketDefinition
	{
		private byte[] _version = new byte[256]; // version string might be shorter?

        public PacketCmd Cmd { get; }
		public uint NetId { get; }
		public int ClientId { get; }
        public string Version
        {
            get
            {
                var s = Encoding.Default.GetString(_version);
                var idx = s.IndexOf('\0');
                if (idx > 0)
                {
                    return s.Substring(0, idx);
                }

                return s;
            }
        }

        public SynchVersionRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();
                ClientId = reader.ReadInt32();
                _version = reader.ReadBytes(256);
            }
        }
    }
}