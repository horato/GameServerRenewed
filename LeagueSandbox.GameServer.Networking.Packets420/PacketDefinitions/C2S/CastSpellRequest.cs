using System.IO;
using System.Numerics;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
    [Packet(PacketCmd.C2SCastSpellRequest)]
    internal class CastSpellRequest : IRequestPacketDefinition
    {
        public PacketCmd Cmd { get; }
        public uint NetId { get; }
        public SpellSlot Slot { get; set; }
        public bool IsSummonerSpellBook { get; set; }
        public bool IsHudClickCast { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 EndPosition { get; set; }
        public uint TargetNetID { get; set; }

        public CastSpellRequest(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                Cmd = (PacketCmd)reader.ReadByte();
                NetId = reader.ReadUInt32();

                var bitfield = reader.ReadByte();
                IsSummonerSpellBook = (bitfield & 0x01) != 0;
                IsHudClickCast = (bitfield & 0x02) != 0;

                Slot = (SpellSlot)reader.ReadByte();
                Position = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                EndPosition = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                TargetNetID = reader.ReadUInt32();
            }
        }
    }
}