using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class Spell : ISpell
    {
        private readonly IDictionary<int, float> _cooldownPerLevelMap;
        private readonly IDictionary<int, float> _manaCostPerLevelMap;
        private readonly IDictionary<int, float> _castRangePerLevelMap;

        public SpellSlot Slot { get; }
        public int Level { get; private set; }
        public float CastTime { get; }
        public float Cooldown { get; private set; }
        public float ManaCost { get; private set; }
        public float CastRange { get; private set; }
        public string SpellName { get; }
        public SpellState State { get; } = SpellState.Ready;

        public float CooldownRemaining { get; }
        public float CastTimeRemaining { get; }

        public Spell(SpellSlot slot, int level, float castTime, string spellName, float cooldownRemaining, float castTimeRemaining, IDictionary<int, float> cooldownPerLevelMap, IDictionary<int, float> manaCostPerLevelMap, IDictionary<int, float> castRangePerLevelMap)
        {
            Slot = slot;
            CastTime = castTime;
            SpellName = spellName;
            CooldownRemaining = cooldownRemaining;
            CastTimeRemaining = castTimeRemaining;
            _cooldownPerLevelMap = cooldownPerLevelMap ?? new Dictionary<int, float>();
            _manaCostPerLevelMap = manaCostPerLevelMap ?? new Dictionary<int, float>();
            _castRangePerLevelMap = castRangePerLevelMap ?? new Dictionary<int, float>();

            SetLevel(level);
        }

        public void SetLevel(int level)
        {
            if (!_cooldownPerLevelMap.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain cooldown data for level {level}");
            if (!_manaCostPerLevelMap.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain mana cost data for level {level}");
            if (!_castRangePerLevelMap.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain cast range data for level {level}");

            Level = level;
            Cooldown = _cooldownPerLevelMap[level];
            ManaCost = _manaCostPerLevelMap[level];
            CastRange = _castRangePerLevelMap[level];
        }
    }
}
