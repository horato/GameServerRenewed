using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class SkillUpResponse : BasePacket
    {
        public SkillUpResponse(uint netId, SpellSlot slot, byte level, byte skillPoints) : base(PacketCmd.S2CSUpgradeSpell, netId)
        {
            WriteByte((byte)slot);
            WriteByte(level);
            WriteByte(skillPoints);
        }
    }
}