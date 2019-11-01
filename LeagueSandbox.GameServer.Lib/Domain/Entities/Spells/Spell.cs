using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class Spell : ISpell
    {
        public ISpellData SpellData { get; }
        public IBaseSpellData BaseSpellData { get; }

        public SpellSlot Slot { get; }
        public int Level { get; private set; }
        public float CastTime { get; }
        public float Cooldown { get; private set; }
        public float ManaCost { get; private set; }
        public float CastRange { get; private set; }
        public float ChannelDuration { get; private set; }
        public string SpellName { get; }
        public int MaxLevel { get; }
        public int AmmoUsed { get; private set; }
        public float AmmoRechargeTime { get; private set; }
        public TargetingType TargetingType { get; }
        public CastType CastType { get; }
        public SpellFlags Flags { get; }
        public SpellState State { get; private set; }
        public float CooldownRemaining { get; private set; }

        public Spell(SpellSlot slot, int level, float cooldownRemaining, SpellState state, IBaseSpellData baseSpellData, ISpellData data)
        {
            Slot = slot;
            CastTime = data.SpellCastTime;
            SpellName = baseSpellData.Name;
            MaxLevel = baseSpellData.MaxLevelOverride;
            TargetingType = data.TargetingType;
            CastType = data.CastType;
            Flags = data.Flags;
            State = state;
            CooldownRemaining = cooldownRemaining;
            SpellData = data;
            BaseSpellData = baseSpellData;

            SetLevel(level);
        }

        public void SetLevel(int level)
        {
            if (level > MaxLevel)
                throw new InvalidOperationException($"Spell {SpellName} has max {MaxLevel} level. Cannot set {level}");
            if (!SpellData.CooldownTime.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain cooldown data for level {level}");
            if (!SpellData.Mana.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain mana cost data for level {level}");
            if (!SpellData.CastRange.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain cast range data for level {level}");
            if (!SpellData.ChannelDuration.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain channel duration data for level {level}");
            if (!SpellData.AmmoRechargeTime.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain ammo recharge data for level {level}");
            if (!SpellData.AmmoUsed.ContainsKey(level))
                throw new InvalidOperationException($"Spell {SpellName} doesn't contain ammo use data for level {level}");

            Level = level;
            Cooldown = SpellData.CooldownTime[level];
            ManaCost = SpellData.Mana[level];
            CastRange = SpellData.CastRange[level];
            ChannelDuration = SpellData.ChannelDuration[level];
            AmmoRechargeTime = SpellData.AmmoRechargeTime[level];
            AmmoUsed = SpellData.AmmoUsed[level];
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
