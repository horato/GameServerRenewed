using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Stats
{
    /// <summary> TODO: This might need re-doing </summary>
    internal class Stats : IStats, INeedDependencies
    {
        private IFlatStatModifierFactory _flatStatModifierFactory;

        private IDictionary<SpellSlot, float> _manaCostDictionary = new Dictionary<SpellSlot, float>
        {
            { SpellSlot.Q, 0 },
            { SpellSlot.W, 0 },
            { SpellSlot.E, 0 },
            { SpellSlot.R, 0 },
        };

        public bool SpellsModified { get; private set; }
        public bool IsTargetableToTeamModified { get; private set; }
        public bool ActionStateModfied { get; private set; }
        public bool ParTypeModified { get; private set; }
        public bool IsMagicImmuneIsModified { get; private set; }
        public bool IsInvulnerableIsModified { get; private set; }
        public bool IsPhysicalImmuneIsModified { get; private set; }
        public bool IsLifestealImmuneIsModified { get; private set; }
        public bool IsTargetableIsModified { get; private set; }
        public bool IsManaCostChanged { get; private set; }

        public SpellSlot SpellsEnabled { get; private set; }
        public SpellFlags IsTargetableToTeam { get; private set; }
        public ActionState ActionState { get; private set; }
        public PrimaryAbilityResourceType ParType { get; }

        public bool IsMagicImmune { get; }
        public bool IsInvulnerable { get; }
        public bool IsPhysicalImmune { get; }
        public bool IsLifestealImmune { get; }
        public bool IsTargetable { get; private set; }
        public bool IsGeneratingGold { get; }
        public float SpellCostReduction { get; }
        public float GoldTotal { get; private set; }

        public IFlatStat FlatAttackSpeed { get; }
        public IFlatStat FlatHealthPoints { get; }
        public IFlatStat FlatManaPoints { get; }
        public IFlatStat FlatAttackDamage { get; }
        public IFlatStat FlatSpellDamage { get; }
        public IFlatStat FlatArmor { get; }
        public IFlatStat FlatMagicResist { get; }
        public IFlatStat FlatCritChance { get; }
        public IFlatStat Gold { get; }
        public IFlatStat Level { get; }
        public IFlatStat Experience { get; }

        public IStat AbilityPower { get; }
        public IStat Armor { get; }
        public IStat ArmorPenetration { get; }
        public IStat AttackDamage { get; }
        public IStat AttackSpeedMultiplier { get; }
        public IStat CooldownReduction { get; }
        public IStat CriticalChance { get; }
        public IStat CriticalDamage { get; }
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

        public Stats(SpellSlot spellsEnabled, SpellFlags isTargetableToTeam, ActionState actionState, PrimaryAbilityResourceType parType, bool isMagicImmune, bool isInvulnerable, bool isPhysicalImmune, bool isLifestealImmune, bool isTargetable, bool isGeneratingGold, float spellCostReduction, float goldTotal, IFlatStat flatAttackSpeed, IFlatStat flatHealthPoints, IFlatStat flatManaPoints, IFlatStat flatAttackDamange, IFlatStat flatSpellDamage, IFlatStat flatArmor, IFlatStat flatMagicResist, IFlatStat flatCritChance, IFlatStat gold, IFlatStat level, IFlatStat experience, IStat abilityPower, IStat armor, IStat armorPenetration, IStat attackDamage, IStat attackSpeedMultiplier, IStat cooldownReduction, IStat criticalChance, IStat criticalDamage, IStat healthPoints, IStat healthRegeneration, IStat lifeSteal, IStat magicResist, IStat magicPenetration, IStat manaPoints, IStat manaRegeneration, IStat moveSpeed, IStat range, IStat size, IStat spellVamp, IStat tenacity)
        {
            SpellsEnabled = spellsEnabled;
            SpellsModified = true;

            IsTargetableToTeam = isTargetableToTeam;
            IsTargetableToTeamModified = true;

            ActionState = actionState;
            ActionStateModfied = true;

            ParType = parType;
            ParTypeModified = true;

            IsMagicImmune = isMagicImmune;
            IsMagicImmuneIsModified = true;

            IsInvulnerable = isInvulnerable;
            IsInvulnerableIsModified = true;

            IsPhysicalImmune = isPhysicalImmune;
            IsPhysicalImmuneIsModified = true;

            IsLifestealImmune = isLifestealImmune;
            IsLifestealImmuneIsModified = true;

            IsTargetable = isTargetable;
            IsTargetableIsModified = true;

            IsGeneratingGold = isGeneratingGold;
            SpellCostReduction = spellCostReduction;

            GoldTotal = goldTotal;
            FlatAttackSpeed = flatAttackSpeed;
            FlatHealthPoints = flatHealthPoints;
            FlatManaPoints = flatManaPoints;
            FlatAttackDamage = flatAttackDamange;
            FlatSpellDamage = flatSpellDamage;
            FlatArmor = flatArmor;
            FlatMagicResist = flatMagicResist;
            FlatCritChance = flatCritChance;
            Gold = gold;
            Level = level;
            Experience = experience;
            AbilityPower = abilityPower;
            Armor = armor;
            ArmorPenetration = armorPenetration;
            AttackDamage = attackDamage;
            AttackSpeedMultiplier = attackSpeedMultiplier;
            CooldownReduction = cooldownReduction;
            CriticalChance = criticalChance;
            CriticalDamage = criticalDamage;
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
        }

        [InjectionMethod]
        public void SetupDependencies(IFlatStatModifierFactory factory)
        {
            _flatStatModifierFactory = factory;
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

        public void AddGold(float amount)
        {
            GoldTotal += amount;

            var modifier = _flatStatModifierFactory.CreateNew(amount, 0, 0, 0);
            Gold.ApplyStatModifier(modifier);
        }

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

            SpellsModified = true;
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

            ActionStateModfied = true;
        }

        public float GetManaCost(SpellSlot slot)
        {
            if (!_manaCostDictionary.ContainsKey(slot))
                throw new InvalidOperationException($"Slot {slot} does not have any mana cost.");

            return _manaCostDictionary[slot];
        }

        public void SetManaCost(SpellSlot slot, float value)
        {
            if (!_manaCostDictionary.ContainsKey(slot))
                _manaCostDictionary.Add(slot, value);

            _manaCostDictionary[slot] = value;
            IsManaCostChanged = true;
        }

        public void OnStatUpdateSent()
        {
            SpellsModified = false;
            ActionStateModfied = false;
            IsTargetableToTeamModified = false;
            ParTypeModified = false;
            IsMagicImmuneIsModified = false;
            IsInvulnerableIsModified = false;
            IsPhysicalImmuneIsModified = false;
            IsLifestealImmuneIsModified = false;
            IsTargetableIsModified = false;
            IsManaCostChanged = false;

            FlatAttackSpeed.OnStatUpdateSent();
            FlatHealthPoints.OnStatUpdateSent();
            FlatManaPoints.OnStatUpdateSent();
            FlatAttackDamage.OnStatUpdateSent();
            FlatArmor.OnStatUpdateSent();
            FlatMagicResist.OnStatUpdateSent();
            Gold.OnStatUpdateSent();
            Level.OnStatUpdateSent();
            Experience.OnStatUpdateSent();

            AbilityPower.OnStatUpdateSent();
            Armor.OnStatUpdateSent();
            ArmorPenetration.OnStatUpdateSent();
            AttackDamage.OnStatUpdateSent();
            AttackSpeedMultiplier.OnStatUpdateSent();
            CooldownReduction.OnStatUpdateSent();
            CriticalChance.OnStatUpdateSent();
            CriticalDamage.OnStatUpdateSent();
            HealthPoints.OnStatUpdateSent();
            HealthRegeneration.OnStatUpdateSent();
            LifeSteal.OnStatUpdateSent();
            MagicResist.OnStatUpdateSent();
            MagicPenetration.OnStatUpdateSent();
            ManaPoints.OnStatUpdateSent();
            ManaRegeneration.OnStatUpdateSent();
            MoveSpeed.OnStatUpdateSent();
            Range.OnStatUpdateSent();
            Size.OnStatUpdateSent();
            SpellVamp.OnStatUpdateSent();
            Tenacity.OnStatUpdateSent();
        }

        public bool IsStatsChanged()
        {
            if (SpellsModified)
                return true;
            if (ActionStateModfied)
                return true;
            if (IsTargetableToTeamModified)
                return true;
            if (ParTypeModified)
                return true;
            if (IsMagicImmuneIsModified)
                return true;
            if (IsInvulnerableIsModified)
                return true;
            if (IsPhysicalImmuneIsModified)
                return true;
            if (IsLifestealImmuneIsModified)
                return true;
            if (IsTargetableIsModified)
                return true;
            if (IsManaCostChanged)
                return true;

            if (FlatAttackSpeed.IsUpdated)
                return true;
            if (FlatHealthPoints.IsUpdated)
                return true;
            if (FlatManaPoints.IsUpdated)
                return true;
            if (FlatAttackDamage.IsUpdated)
                return true;
            if (FlatArmor.IsUpdated)
                return true;
            if (FlatMagicResist.IsUpdated)
                return true;
            if (Gold.IsUpdated)
                return true;
            if (Level.IsUpdated)
                return true;
            if (Experience.IsUpdated)
                return true;

            if (AbilityPower.IsUpdated)
                return true;
            if (Armor.IsUpdated)
                return true;
            if (ArmorPenetration.IsUpdated)
                return true;
            if (AttackDamage.IsUpdated)
                return true;
            if (AttackSpeedMultiplier.IsUpdated)
                return true;
            if (CooldownReduction.IsUpdated)
                return true;
            if (CriticalChance.IsUpdated)
                return true;
            if (CriticalDamage.IsUpdated)
                return true;
            if (HealthPoints.IsUpdated)
                return true;
            if (HealthRegeneration.IsUpdated)
                return true;
            if (LifeSteal.IsUpdated)
                return true;
            if (MagicResist.IsUpdated)
                return true;
            if (MagicPenetration.IsUpdated)
                return true;
            if (ManaPoints.IsUpdated)
                return true;
            if (ManaRegeneration.IsUpdated)
                return true;
            if (MoveSpeed.IsUpdated)
                return true;
            if (Range.IsUpdated)
                return true;
            if (Size.IsUpdated)
                return true;
            if (SpellVamp.IsUpdated)
                return true;
            if (Tenacity.IsUpdated)
                return true;

            return false;
        }

        public void UpdateTargetability(bool isTargetable, SpellFlags isTargetableToTeam)
        {
            IsTargetable = isTargetable;
            IsTargetableToTeam = isTargetableToTeam;

            IsTargetableIsModified = true;
            IsTargetableToTeamModified = true;
        }
    }
}
