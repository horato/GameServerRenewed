using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class AutoAttackPos : BasePacket
    {
        private readonly BasicAttackData _attack;
        private readonly Vector2 _position;

        public AutoAttackPos(uint netId, BasicAttackData attack, Vector2 position) : base(PacketCmd.S2CAutoAttackPos, netId)
        {
            _attack = attack;
            _position = position;

            WritePacket();
        }

        private void WritePacket()
        {
            GetWriter().WriteBasicAttackDataPacket(_attack);
            WriteVector2(_position);
        }
    }
}