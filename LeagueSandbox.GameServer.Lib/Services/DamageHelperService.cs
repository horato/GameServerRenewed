using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class DamageHelperService : IDamageHelperService
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IFlatStatModifierFactory _flatStatModifierFactory;
        private readonly ICalculationService _calculationService;

        public DamageHelperService(IPacketNotifier packetNotifier, IPlayerCache playerCache, IFlatStatModifierFactory flatStatModifierFactory, ICalculationService calculationService)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _flatStatModifierFactory = flatStatModifierFactory;
            _calculationService = calculationService;
        }

        public void DealAutoAttackDamage(IObjAiBase from, IAttackableUnit to, ISpell spell, DamageType damageType)
        {
            var ad = from.Stats.AttackDamage.Total;
            if (spell.Slot.IsAutoAttack() && spell.Slot.IsCritical())
                ad *= from.Stats.CriticalDamage.Total;

            DealDamage(from, to, spell, damageType, ad);
        }

        public void DealDamage(IObjAiBase from, IAttackableUnit to, ISpell spell, DamageType damageType, float damage)
        {
            var defense = CalculateDefense(from.Stats, to.Stats, damageType);
            var damageAfterReduction = defense >= 0 ? 100 / (100 + defense) * damage : (2 - 100 / (100 - defense)) * damage;

            // Substract from receiver's HP
            var hpDifference = _calculationService.CalculateStatDifferenceSubstract(to.Stats.FlatHealthPoints.CurrentValue, damageAfterReduction, to.Stats.HealthPoints.Total);
            var modifier = _flatStatModifierFactory.CreateValueModifier(hpDifference);
            to.Stats.FlatHealthPoints.ApplyStatModifier(modifier);
            
            //TODO: death
            //if (!IsDead && Stats.CurrentHealth <= 0)
            //{
            //    IsDead = true;
            //    Die(attacker);
            //}

            var damageResultType = GetDamageResultType(spell);
            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); // TODO: vision
            _packetNotifier.NotifyUnitApplyDamage(targetSummonerIds, damageResultType, damageType, to.NetId, from.NetId, damageAfterReduction);

            var regain = CalculateRegain(from.Stats, spell.Slot.ToDamageSource());
            if (regain > 0)
            {
                hpDifference = _calculationService.CalculateStatDifferenceAdd(from.Stats.FlatHealthPoints.CurrentValue, regain * damageAfterReduction, from.Stats.HealthPoints.Total);
                modifier = _flatStatModifierFactory.CreateValueModifier(hpDifference);
                from.Stats.FlatHealthPoints.ApplyStatModifier(modifier);
            }
        }

        private DamageResultType GetDamageResultType(ISpell spell)
        {
            //TODO: add other types of damage result
            if (spell.Slot.IsAutoAttack())
            {
                return spell.Slot.IsCritical() ? DamageResultType.Critical : DamageResultType.Normal;
            }

            return DamageResultType.Normal;
        }

        private float CalculateDefense(IStats fromStats, IStats toStats, DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    return (1 - fromStats.ArmorPenetration.PercentBonus) * toStats.Armor.Total - fromStats.ArmorPenetration.FlatBonus;
                case DamageType.Magic:
                    return (1 - fromStats.MagicPenetration.PercentBonus) * toStats.MagicPenetration.Total - fromStats.MagicPenetration.FlatBonus;
                case DamageType.True:
                    return 0;
                case DamageType.Mixed:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(damageType), damageType, null);
            }
        }

        private float CalculateRegain(IStats fromStats, DamageSource damageSource)
        {
            switch (damageSource)
            {
                case DamageSource.Spell:
                    return fromStats.SpellVamp.Total;
                case DamageSource.Attack:
                    return fromStats.LifeSteal.Total;
                case DamageSource.SummonerSpell:
                case DamageSource.Passive:
                    return 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(damageSource), damageSource, null);
            }
        }
    }
}
