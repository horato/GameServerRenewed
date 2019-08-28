using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SPingLoadInfo)]
    internal class PingLoadInfoRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public uint SenderNetId { get; }
        public int ClientId { get; set; }
        public ulong SummonerId { get; set; }
        public float Percentage { get; set; }
        public float ETA { get; set; }
        public ushort Count { get; set; }
        public ushort Ping { get; set; }
        public bool Ready { get; set; }
        
        public PingLoadInfoRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                SenderNetId = reader.ReadUInt32();
                ClientId = reader.ReadInt32();
                SummonerId = reader.ReadUInt64();
                Percentage = reader.ReadSingle();
                ETA = reader.ReadSingle();
                Count = reader.ReadUInt16();
                Ping = reader.ReadUInt16();

                var bitfield = reader.ReadByte();
                Ready = (bitfield & 0x01) != 0;
            }
        }
    }
}