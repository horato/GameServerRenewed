﻿using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Spells
{
    internal class SpellBuilder : EntityBuilderBase<Spell>
    {
        private SpellSlot _slot = SpellSlot.Q;
        private int _level = 2;
        private float _castTime = 2f;
        private string _spellName = "SPELL_Q";
        private int _maxLevel = 4;
        private SpellState _state = SpellState.Cooldown;
        private float _cooldownRemaining = 8.5f;
        private int _ammoUsed = 5;
        private TargetingType _targetingType = TargetingType.Cone;
        private SpellFlags _spellFlags = SpellFlags.InstantCast;
        private CastType _castType = CastType.CircleMissile;
        private IDictionary<int, float> _cooldownPerLevelMap = new Dictionary<int, float> { { 2, 15f } };
        private IDictionary<int, float> _manaCostPerLevelMap = new Dictionary<int, float> { { 2, 12.5f } };
        private IDictionary<int, float> _castRangePerLevelMap = new Dictionary<int, float> { { 2, 540f } };
        private IDictionary<int, float> _channelDurationPerLevelMap = new Dictionary<int, float> { { 2, 2f } };
        private IDictionary<int, float> _ammoRechargeTimePerLevelMap = new Dictionary<int, float> { { 2, 2f } };

        public SpellBuilder WithSlot(SpellSlot slot)
        {
            _slot = slot;
            return this;
        }

        public SpellBuilder WithLevel(int level)
        {
            _level = level;
            return this;
        }

        public SpellBuilder WithCastTime(float castTime)
        {
            _castTime = castTime;
            return this;
        }

        public SpellBuilder WithCooldown(IDictionary<int, float> cooldownPerLevelMap)
        {
            _cooldownPerLevelMap = cooldownPerLevelMap ?? new Dictionary<int, float>();
            return this;
        }

        public SpellBuilder WithManaCost(IDictionary<int, float> manaCostPerLevelMap)
        {
            _manaCostPerLevelMap = manaCostPerLevelMap ?? new Dictionary<int, float>();
            return this;
        }

        public SpellBuilder WithCastRange(IDictionary<int, float> castRangePerLevelMap)
        {
            _castRangePerLevelMap = castRangePerLevelMap ?? new Dictionary<int, float>();
            return this;
        }

        public SpellBuilder WithAmmoRechargeTime(IDictionary<int, float> ammoRechargeTimePerLevelMap)
        {
            _ammoRechargeTimePerLevelMap = ammoRechargeTimePerLevelMap ?? new Dictionary<int, float>();
            return this;
        }

        public SpellBuilder WithSpellName(string spellName)
        {
            _spellName = spellName;
            return this;
        }

        public SpellBuilder WithMaxLevel(int maxLevel)
        {
            _maxLevel = maxLevel;
            return this;
        }

        public SpellBuilder WithState(SpellState state)
        {
            _state = state;
            return this;
        }

        public SpellBuilder WithCooldownRemaining(float cooldownRemaining)
        {
            _cooldownRemaining = cooldownRemaining;
            return this;
        }

        public SpellBuilder WithAmmoUsed(int ammoUsed)
        {
            _ammoUsed = ammoUsed;
            return this;
        }

        public SpellBuilder WithTargetingType(TargetingType targetingType)
        {
            _targetingType = targetingType;
            return this;
        }

        public SpellBuilder WithSpellFlags(SpellFlags spellFlags)
        {
            _spellFlags = spellFlags;
            return this;
        }

        public SpellBuilder WithCastType(CastType castType)
        {
            _castType = castType;
            return this;
        }

        public override Spell Build()
        {
            var instance = new Spell(_slot, _level, _castTime, _spellName, _maxLevel, _ammoUsed, _targetingType, _castType, _spellFlags, _state, _cooldownRemaining, _cooldownPerLevelMap, _manaCostPerLevelMap, _castRangePerLevelMap, _channelDurationPerLevelMap, _ammoRechargeTimePerLevelMap);

            return instance;
        }
    }
}