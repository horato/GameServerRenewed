using System.IO;
using System.Numerics;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SMapPing)]
    internal class MapPingRequest : IRequestPacketDefinition
    {
        public byte Cmd { get; }
        public uint NetId { get; }
        public Vector2 Position { get; }
        public uint TargetNetId { get; }
        public Pings PingCategory { get; }

        public MapPingRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = reader.ReadByte();
                NetId = reader.ReadUInt32();
                Position = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                TargetNetId = reader.ReadUInt32();

                var bitfield = reader.ReadByte();
                PingCategory = (Pings)(byte)(bitfield & 0x0F);
            }
        }
    }
}