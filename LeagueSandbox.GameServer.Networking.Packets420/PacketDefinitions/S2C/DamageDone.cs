using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class UnitApplyDamage : BasePacket
    {
        public UnitApplyDamage(DamageResultType damageResultType, DamageType damageType, uint targetNetId, uint sourceNetId, float damage) 
            : base(PacketCmd.S2CUnitApplyDamage, targetNetId)
        {
            WriteByte((byte)damageResultType);
            WriteZero(1);
            WriteByte((byte)damageType);
            WriteFloat(damage);
            WriteUInt(targetNetId);
            WriteUInt(sourceNetId);
        }
    }
}