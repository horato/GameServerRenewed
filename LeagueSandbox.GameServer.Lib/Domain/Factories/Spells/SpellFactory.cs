using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal class SpellFactory : EntityFactoryBase<Spell>, ISpellFactory
    {
        public SpellFactory(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        public ISpell CreateNew(SpellSlot slot, int level, float castTime, string spellName, int maxLevel, float cooldownRemaining, IDictionary<int, float> cooldownPerLevelMap, IDictionary<int, float> manaCostPerLevelMap, IDictionary<int, float> castRangePerLevelMap, IDictionary<int, float> channelDurationPerLevelMap)
        {
            var instance = new Spell(slot, level, castTime, spellName, maxLevel, SpellState.Ready, cooldownRemaining, cooldownPerLevelMap, manaCostPerLevelMap, castRangePerLevelMap, channelDurationPerLevelMap);

            return SetupDependencies(instance);
        }

        public ISpell CreateFromSpellData(SpellSlot slot, string spellName, int maxLevel, SpellData data)
        {
            var cooldownMap = CreateCooldownMap(data);
            var manaCostMap = CreateManaCostMap(data);
            var castRangeMap = CreateCastRangeMap(data);
            var channelDurationMap = CreateChannelDurationMap(data);

            var instance = new Spell(slot, 0, data.SpellCastTime, spellName, maxLevel, SpellState.Ready, 0, cooldownMap, manaCostMap, castRangeMap, channelDurationMap);

            return SetupDependencies(instance);
        }

        public ISpell CreateSummonerSpell(SpellSlot slot, SummonerSpell spell, int maxLevel, SpellData data)
        {
            var instance = CreateFromSpellData(slot, spell.ToSpellName(), maxLevel, data);
            instance.SetLevel(1);

            return instance;
        }

        private IDictionary<int, float> CreateCooldownMap(SpellData data)
        {
            var map = new Dictionary<int, float>
            {
                { 0, data.Cooldown0 > 0 ? data.Cooldown0 : data.Cooldown },
                { 1, data.Cooldown1 },
                { 2, data.Cooldown2 },
                { 3, data.Cooldown3 },
                { 4, data.Cooldown4 },
                { 5, data.Cooldown5 },
                { 6, data.Cooldown6 }
            };

            return map;
        }

        private IDictionary<int, float> CreateManaCostMap(SpellData data)
        {
            var map = new Dictionary<int, float>
            {
                { 0, data.ManaCost },
                { 1, data.ManaCost1 },
                { 2, data.ManaCost2 },
                { 3, data.ManaCost3 },
                { 4, data.ManaCost4 },
                { 5, data.ManaCost5 },
                { 6, data.ManaCost6 }
            };

            return map;
        }

        private IDictionary<int, float> CreateCastRangeMap(SpellData data)
        {
            var map = new Dictionary<int, float>
            {
                { 0, data.CastRange },
                { 1, data.CastRange1 },
                { 2, data.CastRange2 },
                { 3, data.CastRange3 },
                { 4, data.CastRange4 },
                { 5, data.CastRange5 },
                { 6, data.CastRange6 }
            };

            return map;
        }

        private IDictionary<int, float> CreateChannelDurationMap(SpellData data)
        {
            var map = new Dictionary<int, float>
            {
                { 0, data.ChannelDuration },
                { 1, data.ChannelDuration1 },
                { 2, data.ChannelDuration2 },
                { 3, data.ChannelDuration3 },
                { 4, data.ChannelDuration4 },
                { 5, data.ChannelDuration5 },
                { 6, data.ChannelDuration6 }
            };

            return map;
        }
    }
}
