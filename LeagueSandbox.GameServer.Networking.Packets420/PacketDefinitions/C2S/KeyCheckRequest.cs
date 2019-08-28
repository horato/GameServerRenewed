using System.IO;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.KeyCheck, Channel.Default)]
    internal class KeyCheckRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public byte[] PartialKey { get; } = new byte[3];   //Bytes 1 to 3 from the blowfish key for that client
        public int ClientID { get; }
        public ulong SummonerId { get; }
        public uint VersionNo { get; }
        public ulong CheckId { get; }
        public uint Trash { get; }

        public KeyCheckRequest(byte[] bytes)
        {
            using (var reader = new BinaryReader(new MemoryStream(bytes)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                PartialKey[0] = reader.ReadByte();
                PartialKey[1] = reader.ReadByte();
                PartialKey[2] = reader.ReadByte();
                ClientID = reader.ReadInt32();
                SummonerId = reader.ReadUInt64();
                VersionNo = reader.ReadUInt32();
                CheckId = reader.ReadUInt64();
                if (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    Trash = reader.ReadUInt32();
                }
            }
        }
    }
}