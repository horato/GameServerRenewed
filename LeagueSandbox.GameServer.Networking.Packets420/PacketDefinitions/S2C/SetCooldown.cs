using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class SetCooldown : BasePacket
    {
        public SetCooldown(uint netId, SpellSlot slotId, bool playVoWhenCooldownReady, bool isSummonerSpell, float cooldown, float maxCooldownForDisplay) : base(PacketCmd.S2CSetCooldown, netId)
        {
            WriteByte((byte)slotId);

            byte bitfield = 0;
            if (playVoWhenCooldownReady)
                bitfield |= 0x01;
            if (isSummonerSpell)
                bitfield |= 0x02;
            WriteByte(bitfield);

            WriteFloat(cooldown);
            WriteFloat(maxCooldownForDisplay);
        }
    }
}