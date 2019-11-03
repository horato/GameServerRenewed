using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class ShowHealthBar : BasePacket
    {
        public ShowHealthBar(uint targetNetId, bool show, bool changeHealthBarType, HealthBarType healthBarType, TeamId observerTeam) : base(PacketCmd.ShowHealthBar, targetNetId)
        {
            byte bitfield = 0;
            if (show)
                bitfield |= 1;
            if (changeHealthBarType)
                bitfield |= 2;

            WriteByte(bitfield);
            WriteByte((byte)healthBarType);
            if (changeHealthBarType)
                WriteUInt((uint)observerTeam);
        }
    }
}