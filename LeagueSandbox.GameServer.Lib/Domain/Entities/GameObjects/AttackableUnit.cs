using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal abstract class AttackableUnit : GameObject, IAttackableUnit
    {
        public IStats Stats { get; }

        //TimeOfDeath

        protected AttackableUnit(Team team, Vector3 position, IStats stats, uint netId, float visionRadius, float collisionRadius) : base(team, position, visionRadius, collisionRadius, netId)
        {
            Stats = stats;
        }
    }
}
