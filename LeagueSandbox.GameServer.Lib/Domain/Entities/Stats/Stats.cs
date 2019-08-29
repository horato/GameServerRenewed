using System;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Stats
{
    internal class Stats : IStats
    {
        public SpellSlot SpellsEnabled { get; private set; }

        public bool IsMagicImmune { get; }
        public bool IsInvulnerable { get; }
        public bool IsPhysicalImmune { get; }
        public bool IsLifestealImmune { get; }
        public bool IsTargetable { get; }
        public SpellFlags IsTargetableToTeam { get; }
        public ActionState ActionState { get; private set; }
        public PrimaryAbilityResourceType ParType { get; }

        public float AttackSpeedFlat { get; }
        public float HealthPerLevel { get; }
        public float ManaPerLevel { get; }
        public float AdPerLevel { get; }
        public float ArmorPerLevel { get; }
        public float MagicResistPerLevel { get; }
        public float HealthRegenerationPerLevel { get; }
        public float ManaRegenerationPerLevel { get; }
        public float GrowthAttackSpeed { get; }
        public float[] ManaCost { get; }

        public IStat AbilityPower { get; }
        public IStat Armor { get; }
        public IStat ArmorPenetration { get; }
        public IStat AttackDamage { get; }
        public IStat AttackSpeedMultiplier { get; }
        public IStat CooldownReduction { get; }
        public IStat CriticalChance { get; }
        public IStat CriticalDamage { get; }
        public IStat GoldPerSecond { get; }
        public IStat HealthPoints { get; }
        public IStat HealthRegeneration { get; }
        public IStat LifeSteal { get; }
        public IStat MagicResist { get; }
        public IStat MagicPenetration { get; }
        public IStat ManaPoints { get; }
        public IStat ManaRegeneration { get; }
        public IStat MoveSpeed { get; }
        public IStat Range { get; }
        public IStat Size { get; }
        public IStat SpellVamp { get; }
        public IStat Tenacity { get; }

        public float Gold { get; }
        public byte Level { get; }
        public float Experience { get; }

        private float _currentHealth;
        public float CurrentHealth
        {
            get => Math.Min(HealthPoints.Total, _currentHealth);
            private set => _currentHealth = value;
        }

        private float _currentMana;
        public float CurrentMana
        {
            get => Math.Min(ManaPoints.Total, _currentMana);
            private set => _currentMana = value;
        }

        public bool IsGeneratingGold { get; }
        public float SpellCostReduction { get; }

        public Stats(SpellSlot spellsEnabled, bool isMagicImmune, bool isInvulnerable, bool isPhysicalImmune, bool isLifestealImmune, bool isTargetable, SpellFlags isTargetableToTeam, ActionState actionState, PrimaryAbilityResourceType parType, float attackSpeedFlat, float healthPerLevel, float manaPerLevel, float adPerLevel, float armorPerLevel, float magicResistPerLevel, float healthRegenerationPerLevel, float manaRegenerationPerLevel, float growthAttackSpeed, float[] manaCost, IStat abilityPower, IStat armor, IStat armorPenetration, IStat attackDamage, IStat attackSpeedMultiplier, IStat cooldownReduction, IStat criticalChance, IStat criticalDamage, IStat goldPerSecond, IStat healthPoints, IStat healthRegeneration, IStat lifeSteal, IStat magicResist, IStat magicPenetration, IStat manaPoints, IStat manaRegeneration, IStat moveSpeed, IStat range, IStat size, IStat spellVamp, IStat tenacity, float gold, byte level, float experience, float currentHealth, float currentMana, bool isGeneratingGold, float spellCostReduction)
        {
            SpellsEnabled = spellsEnabled;
            IsMagicImmune = isMagicImmune;
            IsInvulnerable = isInvulnerable;
            IsPhysicalImmune = isPhysicalImmune;
            IsLifestealImmune = isLifestealImmune;
            IsTargetable = isTargetable;
            IsTargetableToTeam = isTargetableToTeam;
            ActionState = actionState;
            ParType = parType;
            AttackSpeedFlat = attackSpeedFlat;
            HealthPerLevel = healthPerLevel;
            ManaPerLevel = manaPerLevel;
            AdPerLevel = adPerLevel;
            ArmorPerLevel = armorPerLevel;
            MagicResistPerLevel = magicResistPerLevel;
            HealthRegenerationPerLevel = healthRegenerationPerLevel;
            ManaRegenerationPerLevel = manaRegenerationPerLevel;
            GrowthAttackSpeed = growthAttackSpeed;
            ManaCost = manaCost;
            AbilityPower = abilityPower;
            Armor = armor;
            ArmorPenetration = armorPenetration;
            AttackDamage = attackDamage;
            AttackSpeedMultiplier = attackSpeedMultiplier;
            CooldownReduction = cooldownReduction;
            CriticalChance = criticalChance;
            CriticalDamage = criticalDamage;
            GoldPerSecond = goldPerSecond;
            HealthPoints = healthPoints;
            HealthRegeneration = healthRegeneration;
            LifeSteal = lifeSteal;
            MagicResist = magicResist;
            MagicPenetration = magicPenetration;
            ManaPoints = manaPoints;
            ManaRegeneration = manaRegeneration;
            MoveSpeed = moveSpeed;
            Range = range;
            Size = size;
            SpellVamp = spellVamp;
            Tenacity = tenacity;
            Gold = gold;
            Level = level;
            Experience = experience;
            CurrentHealth = currentHealth;
            CurrentMana = currentMana;
            IsGeneratingGold = isGeneratingGold;
            SpellCostReduction = spellCostReduction;
        }

        public void AddModifier(IStatsModifier modifier)
        {
            AbilityPower.ApplyStatModifier(modifier.AbilityPower);
            Armor.ApplyStatModifier(modifier.Armor);
            ArmorPenetration.ApplyStatModifier(modifier.ArmorPenetration);
            AttackDamage.ApplyStatModifier(modifier.AttackDamage);
            AttackSpeedMultiplier.ApplyStatModifier(modifier.AttackSpeed);
            CriticalChance.ApplyStatModifier(modifier.CriticalChance);
            CriticalDamage.ApplyStatModifier(modifier.CriticalDamage);
            GoldPerSecond.ApplyStatModifier(modifier.GoldPerSecond);
            HealthPoints.ApplyStatModifier(modifier.HealthPoints);
            HealthRegeneration.ApplyStatModifier(modifier.HealthRegeneration);
            LifeSteal.ApplyStatModifier(modifier.LifeSteal);
            MagicResist.ApplyStatModifier(modifier.MagicResist);
            MagicPenetration.ApplyStatModifier(modifier.MagicPenetration);
            ManaPoints.ApplyStatModifier(modifier.ManaPoints);
            ManaRegeneration.ApplyStatModifier(modifier.ManaRegeneration);
            MoveSpeed.ApplyStatModifier(modifier.MoveSpeed);
            Range.ApplyStatModifier(modifier.Range);
            Size.ApplyStatModifier(modifier.Size);
            SpellVamp.ApplyStatModifier(modifier.SpellVamp);
            Tenacity.ApplyStatModifier(modifier.Tenacity);
        }

        public void RemoveModifier(IStatsModifier modifier)
        {
            AbilityPower.RemoveStatModifier(modifier.AbilityPower);
            Armor.RemoveStatModifier(modifier.Armor);
            ArmorPenetration.RemoveStatModifier(modifier.ArmorPenetration);
            AttackDamage.RemoveStatModifier(modifier.AttackDamage);
            AttackSpeedMultiplier.RemoveStatModifier(modifier.AttackSpeed);
            CriticalChance.RemoveStatModifier(modifier.CriticalChance);
            CriticalDamage.RemoveStatModifier(modifier.CriticalDamage);
            GoldPerSecond.RemoveStatModifier(modifier.GoldPerSecond);
            HealthPoints.RemoveStatModifier(modifier.HealthPoints);
            HealthRegeneration.RemoveStatModifier(modifier.HealthRegeneration);
            LifeSteal.RemoveStatModifier(modifier.LifeSteal);
            MagicResist.RemoveStatModifier(modifier.MagicResist);
            MagicPenetration.RemoveStatModifier(modifier.MagicPenetration);
            ManaPoints.RemoveStatModifier(modifier.ManaPoints);
            ManaRegeneration.RemoveStatModifier(modifier.ManaRegeneration);
            MoveSpeed.RemoveStatModifier(modifier.MoveSpeed);
            Range.RemoveStatModifier(modifier.Range);
            Size.RemoveStatModifier(modifier.Size);
            SpellVamp.RemoveStatModifier(modifier.SpellVamp);
            Tenacity.RemoveStatModifier(modifier.Tenacity);
        }

        public float GetTotalAttackSpeed()
        {
            return AttackSpeedFlat * AttackSpeedMultiplier.Total;
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

        //public void LevelUp()
        //{
        //    Level++;

        //    HealthPoints.BaseValue += HealthPerLevel;
        //    CurrentHealth = HealthPoints.Total / (HealthPoints.Total - HealthPerLevel) * CurrentHealth;
        //    ManaPoints.BaseValue = ManaPoints.Total + ManaPerLevel;
        //    CurrentMana = ManaPoints.Total / (ManaPoints.Total - ManaPerLevel) * CurrentMana;
        //    AttackDamage.BaseValue = AttackDamage.BaseValue + AdPerLevel;
        //    Armor.BaseValue = Armor.BaseValue + ArmorPerLevel;
        //    MagicResist.BaseValue = MagicResist.Total + MagicResistPerLevel;
        //    HealthRegeneration.BaseValue = HealthRegeneration.BaseValue + HealthRegenerationPerLevel;
        //    ManaRegeneration.BaseValue = ManaRegeneration.BaseValue + ManaRegenerationPerLevel;
        //}

        public bool GetSpellEnabled(SpellSlot slot)
        {
            return SpellsEnabled.HasFlag(slot);
        }

        public void SetSpellEnabled(SpellSlot slot, bool enabled)
        {
            if (enabled)
                SpellsEnabled |= slot;
            else
                SpellsEnabled &= ~slot;
        }

        public bool GetActionState(ActionState state)
        {
            return ActionState.HasFlag(state);
        }

        public void SetActionState(ActionState state, bool enabled)
        {
            if (enabled)
                ActionState |= state;
            else
                ActionState &= ~state;
        }
    }
}
