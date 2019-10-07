﻿using System;
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
        private readonly IDictionary<int, float> _channelDurationPerLevelMap;
        private readonly IDictionary<int, float> _ammoRechargeTimePerLevelMap;

        public SpellSlot Slot { get; }
        public int Level { get; private set; }
        public float CastTime { get; }
        public float Cooldown { get; private set; }
        public float ManaCost { get; private set; }
        public float CastRange { get; private set; }
        public float ChannelDuration { get; private set; }
        public string SpellName { get; }
        public int MaxLevel { get; }
        public int AmmoUsed { get; }
        public float AmmoRechargeTime { get; private set; }
        public TargetingType TargetingType { get; }
        public CastType CastType { get; }
        public SpellFlags Flags { get; }
        public SpellState State { get; private set; }
        public float CooldownRemaining { get; private set; }

        public Spell(SpellSlot slot, int level, float castTime, string spellName, int maxLevel, int ammoUsed, TargetingType targetingType, CastType castType, SpellFlags flags, SpellState state, float cooldownRemaining, IDictionary<int, float> cooldownPerLevelMap, IDictionary<int, float> manaCostPerLevelMap, IDictionary<int, float> castRangePerLevelMap, IDictionary<int, float> channelDurationPerLevelMap, IDictionary<int, float> ammoRechargeTimePerLevelMap)
        {
            Slot = slot;
            CastTime = castTime;
            SpellName = spellName;
            MaxLevel = maxLevel;
            AmmoUsed = ammoUsed;
            TargetingType = targetingType;
            CastType = castType;
            Flags = flags;
            State = state;
            CooldownRemaining = cooldownRemaining;
            _cooldownPerLevelMap = cooldownPerLevelMap ?? new Dictionary<int, float>();
            _manaCostPerLevelMap = manaCostPerLevelMap ?? new Dictionary<int, float>();
            _castRangePerLevelMap = castRangePerLevelMap ?? new Dictionary<int, float>();
            _channelDurationPerLevelMap = channelDurationPerLevelMap ?? new Dictionary<int, float>();
            _ammoRechargeTimePerLevelMap = ammoRechargeTimePerLevelMap ?? new Dictionary<int, float>();

            SetLevel(level);
        }

        public void SetLevel(int level)
        {
            if (level > MaxLevel)
                throw new InvalidOperationException($"Spell {SpellName} has max {MaxLevel} level. Cannot set {level}");
            if (!_cooldownPerLevelMap.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain cooldown data for level {level}");
            if (!_manaCostPerLevelMap.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain mana cost data for level {level}");
            if (!_castRangePerLevelMap.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain cast range data for level {level}");
            if (!_channelDurationPerLevelMap.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain channel duration data for level {level}");
            if (!_ammoRechargeTimePerLevelMap.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain ammo recharge data for level {level}");

            Level = level;
            Cooldown = _cooldownPerLevelMap[level];
            ManaCost = _manaCostPerLevelMap[level];
            CastRange = _castRangePerLevelMap[level];
            ChannelDuration = _channelDurationPerLevelMap[level];
            AmmoRechargeTime = _ammoRechargeTimePerLevelMap[level];
        }

        public bool HasFlag(SpellFlags flag)
        {
            return Flags.HasFlag(flag);
        }

        public void StartCooldown()
        {
            if (State != SpellState.Ready)
                throw new InvalidOperationException("Cannot start cooldown. Invalid state.");

            State = SpellState.Cooldown;
            CooldownRemaining = GetCooldown();
        }

        public void CooldownProgress(float secondsDiff)
        {
            if (State != SpellState.Cooldown)
                throw new InvalidOperationException("Invalid state. Cannot progress cooldown.");
            if (secondsDiff < 0)
                throw new InvalidOperationException("Diff must be greater or equal to 0");

            if (CooldownRemaining > secondsDiff)
                CooldownRemaining -= secondsDiff;
            else
                CooldownRemaining = 0;
        }

        public void CooldownFinished()
        {
            if (State != SpellState.Cooldown)
                throw new InvalidOperationException("Invalid state. Cannot finish cooldown.");

            CooldownRemaining = 0;
            State = SpellState.Ready;
        }

        private float GetCooldown()
        {
            //TODO: option to turn off cooldowns globally
            return Cooldown;
        }
    }
}