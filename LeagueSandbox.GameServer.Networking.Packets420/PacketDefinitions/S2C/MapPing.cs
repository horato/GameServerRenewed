using System.Numerics;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class MapPing : BasePacket
    {
        public Vector2 Position { get; set; }
        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }

        public Pings PingCategory { get; set; }
        public bool PlayAudio { get; set; }
        public bool ShowChat { get; set; }
        public bool PingThrottled { get; set; }
        public bool PlayVO { get; set; }

        public MapPing(Vector2 position, uint targetNetId, uint sourceNetId, Pings pingCategory, bool playAudio, bool showChat, bool pingThrottled, bool playVo) : base(PacketCmd.S2CMapPing)
        {
            Position = position;
            TargetNetID = targetNetId;
            SourceNetID = sourceNetId;
            PingCategory = pingCategory;
            PlayAudio = playAudio;
            ShowChat = showChat;
            PingThrottled = pingThrottled;
            PlayVO = playVo;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteFloat(Position.X);
            WriteFloat(Position.Y);
            WriteUInt(TargetNetID);
            WriteUInt(SourceNetID);
            WriteByte((byte)PingCategory);

            byte bitfield = 0;
            if (PlayAudio)
                bitfield |= 0x01;
            if (ShowChat)
                bitfield |= 0x02;
            if (PingThrottled)
                bitfield |= 0x04;
            if (PlayVO)
                bitfield |= 0x08;
            WriteByte(bitfield);
        }
    }
}