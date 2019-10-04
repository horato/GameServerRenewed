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

            stats.FlatHealthPoints.ApplyStatModifier(new FlatStatModifier(stats.HealthPoints.Total - stats.FlatHealthPoints.CurrentValue, 0, 0, 0));
            stats.FlatArmor.ApplyStatModifier(new FlatStatModifier(stats.Armor.Total - stats.FlatArmor.CurrentValue, 0, 0, 0));
            stats.FlatAttackDamage.ApplyStatModifier(new FlatStatModifier(stats.AttackDamage.Total - stats.FlatAttackDamage.CurrentValue, 0, 0, 0));
            stats.FlatMagicResist.ApplyStatModifier(new FlatStatModifier(stats.MagicResist.Total - stats.FlatMagicResist.CurrentValue, 0, 0, 0));
            stats.FlatManaPoints.ApplyStatModifier(new FlatStatModifier(stats.ManaPoints.Total - stats.FlatManaPoints.CurrentValue, 0, 0, 0));
        }
    }
}
