using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class StatsUpdateService : IStatsUpdateService
    {
        private readonly Lazy<IMap> _map;
        private readonly ICalculationService _calculationService;
        private readonly IFlatStatModifierFactory _flatStatModifierFactory;
        private readonly IStatModifierFactory _statModifierFactory;
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;

        public StatsUpdateService(Lazy<IMap> map, ICalculationService calculationService, IFlatStatModifierFactory flatStatModifierFactory, IStatModifierFactory statModifierFactory, IPacketNotifier packetNotifier, IPlayerCache playerCache)
        {
            _map = map;
            _calculationService = calculationService;
            _flatStatModifierFactory = flatStatModifierFactory;
            _statModifierFactory = statModifierFactory;
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
        }

        public void Update(IAttackableUnit unit, float millisecondsDiff)
        {
            if (unit is IObjAiHero hero)
                UpdateLevelIfNeeded(hero);
        }

        private void UpdateLevelIfNeeded(IObjAiHero hero)
        {
            var stats = hero.Stats;
            var level = _map.Value.GetLevelFromExp(stats.Experience.CurrentValue);
            if (Math.Abs(level - stats.Level.CurrentValue) < float.Epsilon)
                return;

            // Change level
            var levelDifference = _calculationService.CalculateStatDifference(stats.Level.CurrentValue, level, _map.Value.MaxLevel, 1);
            var levelModifier = _flatStatModifierFactory.CreateValueModifier(levelDifference);
            stats.Level.ApplyStatModifier(levelModifier);

            // Change base HP
            var baseDifference = _calculationService.CalculateStatDifferenceForLevelUp(stats.HealthPoints.BaseValue, stats.FlatHealthPoints.BonusPerLevel, levelDifference);
            var baseModifier = _statModifierFactory.CreateNew(baseDifference, 0, 0, 0, 0);
            stats.HealthPoints.ApplyStatModifier(baseModifier);

            // Change base MP
            baseDifference = _calculationService.CalculateStatDifferenceForLevelUp(stats.ManaPoints.BaseValue, stats.FlatManaPoints.BonusPerLevel, levelDifference);
            baseModifier = _statModifierFactory.CreateNew(baseDifference, 0, 0, 0, 0);
            stats.ManaPoints.ApplyStatModifier(baseModifier);

            // Change base AD
            baseDifference = _calculationService.CalculateStatDifferenceForLevelUp(stats.AttackDamage.BaseValue, stats.FlatAttackDamage.BonusPerLevel, levelDifference);
            baseModifier = _statModifierFactory.CreateNew(baseDifference, 0, 0, 0, 0);
            stats.AttackDamage.ApplyStatModifier(baseModifier);

            // Change base armor
            baseDifference = _calculationService.CalculateStatDifferenceForLevelUp(stats.Armor.BaseValue, stats.FlatArmor.BonusPerLevel, levelDifference);
            baseModifier = _statModifierFactory.CreateNew(baseDifference, 0, 0, 0, 0);
            stats.Armor.ApplyStatModifier(baseModifier);

            // Change base MR
            baseDifference = _calculationService.CalculateStatDifferenceForLevelUp(stats.MagicResist.BaseValue, stats.FlatMagicResist.BonusPerLevel, levelDifference);
            baseModifier = _statModifierFactory.CreateNew(baseDifference, 0, 0, 0, 0);
            stats.MagicResist.ApplyStatModifier(baseModifier);

            // Change base HP regen
            baseDifference = _calculationService.CalculateStatDifferenceForLevelUp(stats.HealthRegeneration.BaseValue, stats.FlatHealthPoints.RegenerationBonusPerLevel, levelDifference);
            baseModifier = _statModifierFactory.CreateNew(baseDifference, 0, 0, 0, 0);
            stats.HealthRegeneration.ApplyStatModifier(baseModifier);

            // Change base MP regen
            baseDifference = _calculationService.CalculateStatDifferenceForLevelUp(stats.ManaRegeneration.BaseValue, stats.FlatManaPoints.RegenerationBonusPerLevel, levelDifference);
            baseModifier = _statModifierFactory.CreateNew(baseDifference, 0, 0, 0, 0);
            stats.ManaRegeneration.ApplyStatModifier(baseModifier);

            // Change base AS
            baseDifference = _calculationService.CalculateStatDifferenceForLevelUp(stats.FlatAttackSpeed.CurrentValue, stats.FlatAttackSpeed.BonusPerLevel, levelDifference);
            var asModifier = _flatStatModifierFactory.CreateValueModifier(baseDifference);
            stats.FlatAttackSpeed.ApplyStatModifier(asModifier);

            // TODO: current hp/mp
            //    CurrentHealth = HealthPoints.Total / (HealthPoints.Total - HealthPerLevel) * CurrentHealth;
            //    CurrentMana = ManaPoints.Total / (ManaPoints.Total - ManaPerLevel) * CurrentMana;

            // Change skill points
            hero.SpellBook.ChangeLevel(level);

            var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); //TODO: vision
            _packetNotifier.NotifyLevelUp(targetSummonerIds, hero);
        }
    }       
    
    //public void Update(float diff)
    //{
    //    if (HealthRegeneration.Total > 0 && CurrentHealth < HealthPoints.Total && CurrentHealth > 0)
    //    {
    //        var newHealth = CurrentHealth + HealthRegeneration.Total * diff * 0.001f;
    //        newHealth = Math.Min(HealthPoints.Total, newHealth);
    //        CurrentHealth = newHealth;
    //    }

    //    if (IsGeneratingGold && GoldPerSecond.Total > 0)
    //    {
    //        var newGold = Gold + GoldPerSecond.Total * (diff * 0.001f);
    //        Gold = newGold;
    //    }

    //    if ((byte)ParType > 1)
    //    {
    //        return;
    //    }

    //    if (ManaRegeneration.Total > 0 && CurrentMana < ManaPoints.Total)
    //    {
    //        var newMana = CurrentMana + ManaRegeneration.Total * diff * 0.001f;
    //        newMana = Math.Min(ManaPoints.Total, newMana);
    //        CurrentMana = newMana;
    //    }
    //}

}
