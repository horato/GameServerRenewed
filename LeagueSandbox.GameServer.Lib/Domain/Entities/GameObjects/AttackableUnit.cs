using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class AttackableUnit : GameObject, IAttackableUnit
    {
        public IStats Stats { get; }
        public uint NetId { get; }
        //TimeOfDeath

        public AttackableUnit(Team team, Vector3 position, IStats stats, uint netId) : base(team, position)
        {
            Stats = stats;
            NetId = netId;
        }
    }
}
