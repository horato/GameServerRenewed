using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class AutoAttack : BasePacket
    {
        public AutoAttack(uint netId, BasicAttackData attack) : base(PacketCmd.S2CAutoAttack, netId)
        {
            GetWriter().WriteBasicAttackDataPacket(attack);
        }
    }
}