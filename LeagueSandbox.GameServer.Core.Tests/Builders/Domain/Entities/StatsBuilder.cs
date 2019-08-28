using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities
{
    internal class StatsBuilder : EntityBuilderBase<Stats>
    {
        private SpellSlot _spellsEnabled = SpellSlot.Q | SpellSlot.W | SpellSlot.E | SpellSlot.R;
        private bool _isMagicImmune = true;
        private bool _isInvulnerable = true;
        private bool _isPhysicalImmune = true;
        private bool _isLifestealImmune = true;
        private bool _isTargetable = true;
        private SpellFlags _isTargetableToTeam = SpellFlags.TargetableToAll;
        private ActionState _actionState = ActionState.CanAttack | ActionState.CanCast;
        private PrimaryAbilityResourceType _parType = PrimaryAbilityResourceType.Mana;
        private float _attackSpeedFlat = 1.5f;
        private float _healthPerLevel = 1.6f;
        private float _manaPerLevel = 1.7f;
        private float _adPerLevel = 1.8f;
        private float _armorPerLevel = 1.9f;
        private float _magicResistPerLevel = 2.0f;
        private float _healthRegenerationPerLevel = 2.1f;
        private float _manaRegenerationPerLevel = 2.2f;
        private float _growthAttackSpeed = 2.3f;
        private float[] _manaCost = new[] { 1f, 2f, 3f, 4f };
        private IStat _abilityPower = new StatBuilder().Build();
        private IStat _armor = new StatBuilder().Build();
        private IStat _armorPenetration = new StatBuilder().Build();
        private IStat _attackDamage = new StatBuilder().Build();
        private IStat _attackSpeedMultiplier = new StatBuilder().Build();
        private IStat _cooldownReduction = new StatBuilder().Build();
        private IStat _criticalChance = new StatBuilder().Build();
        private IStat _criticalDamage = new StatBuilder().Build();
        private IStat _goldPerSecond = new StatBuilder().Build();
        private IStat _healthPoints = new StatBuilder().Build();
        private IStat _healthRegeneration = new StatBuilder().Build();
        private IStat _lifeSteal = new StatBuilder().Build();
        private IStat _magicResist = new StatBuilder().Build();
        private IStat _magicPenetration = new StatBuilder().Build();
        private IStat _manaPoints = new StatBuilder().Build();
        private IStat _manaRegeneration = new StatBuilder().Build();
        private IStat _moveSpeed = new StatBuilder().Build();
        private IStat _range = new StatBuilder().Build();
        private IStat _size = new StatBuilder().Build();
        private IStat _spellVamp = new StatBuilder().Build();
        private IStat _tenacity = new StatBuilder().Build();
        private float _gold = 51f;
        private byte _level = 11;
        private float _experience = 120456;
        private float _currentHealth = 345;
        private float _currentMana = 32;
        private bool _isGeneratingGold = true;
        private float _spellCostReduction = 5.5f;

        public StatsBuilder WithSpellsEnabled(SpellSlot spellsEnabled)
        {
            _spellsEnabled = spellsEnabled;
            return this;
        }

        public StatsBuilder WithIsMagicImmune(bool isMagicImmune)
        {
            _isMagicImmune = isMagicImmune;
            return this;
        }

        public StatsBuilder WithIsInvulnerable(bool isInvulnerable)
        {
            _isInvulnerable = isInvulnerable;
            return this;
        }

        public StatsBuilder WithIsPhysicalImmune(bool isPhysicalImmune)
        {
            _isPhysicalImmune = isPhysicalImmune;
            return this;
        }

        public StatsBuilder WithIsLifestealImmune(bool isLifestealImmune)
        {
            _isLifestealImmune = isLifestealImmune;
            return this;
        }

        public StatsBuilder WithIsTargetable(bool isTargetable)
        {
            _isTargetable = isTargetable;
            return this;
        }

        public StatsBuilder WithIsTargetableToTeam(SpellFlags isTargetableToTeam)
        {
            _isTargetableToTeam = isTargetableToTeam;
            return this;
        }

        public StatsBuilder WithActionState(ActionState actionState)
        {
            _actionState = actionState;
            return this;
        }

        public StatsBuilder WithParType(PrimaryAbilityResourceType parType)
        {
            _parType = parType;
            return this;
        }

        public StatsBuilder WithAttackSpeedFlat(float attackSpeedFlat)
        {
            _attackSpeedFlat = attackSpeedFlat;
            return this;
        }

        public StatsBuilder WithHealthPerLevel(float healthPerLevel)
        {
            _healthPerLevel = healthPerLevel;
            return this;
        }

        public StatsBuilder WithManaPerLevel(float manaPerLevel)
        {
            _manaPerLevel = manaPerLevel;
            return this;
        }

        public StatsBuilder WithAdPerLevel(float adPerLevel)
        {
            _adPerLevel = adPerLevel;
            return this;
        }

        public StatsBuilder WithArmorPerLevel(float armorPerLevel)
        {
            _armorPerLevel = armorPerLevel;
            return this;
        }

        public StatsBuilder WithMagicResistPerLevel(float magicResistPerLevel)
        {
            _magicResistPerLevel = magicResistPerLevel;
            return this;
        }

        public StatsBuilder WithHealthRegenerationPerLevel(float healthRegenerationPerLevel)
        {
            _healthRegenerationPerLevel = healthRegenerationPerLevel;
            return this;
        }

        public StatsBuilder WithManaRegenerationPerLevel(float manaRegenerationPerLevel)
        {
            _manaRegenerationPerLevel = manaRegenerationPerLevel;
            return this;
        }

        public StatsBuilder WithGrowthAttackSpeed(float growthAttackSpeed)
        {
            _growthAttackSpeed = growthAttackSpeed;
            return this;
        }

        public StatsBuilder WithManaCost(float[] manaCost)
        {
            _manaCost = manaCost;
            return this;
        }

        public StatsBuilder WithAbilityPower(IStat abilityPower)
        {
            _abilityPower = abilityPower;
            return this;
        }

        public StatsBuilder WithArmor(IStat armor)
        {
            _armor = armor;
            return this;
        }

        public StatsBuilder WithArmorPenetration(IStat armorPenetration)
        {
            _armorPenetration = armorPenetration;
            return this;
        }

        public StatsBuilder WithAttackDamage(IStat attackDamage)
        {
            _attackDamage = attackDamage;
            return this;
        }

        public StatsBuilder WithAttackSpeedMultiplier(IStat attackSpeedMultiplier)
        {
            _attackSpeedMultiplier = attackSpeedMultiplier;
            return this;
        }

        public StatsBuilder WithCooldownReduction(IStat cooldownReduction)
        {
            _cooldownReduction = cooldownReduction;
            return this;
        }

        public StatsBuilder WithCriticalChance(IStat criticalChance)
        {
            _criticalChance = criticalChance;
            return this;
        }

        public StatsBuilder WithCriticalDamage(IStat criticalDamage)
        {
            _criticalDamage = criticalDamage;
            return this;
        }

        public StatsBuilder WithGoldPerSecond(IStat goldPerSecond)
        {
            _goldPerSecond = goldPerSecond;
            return this;
        }

        public StatsBuilder WithHealthPoints(IStat healthPoints)
        {
            _healthPoints = healthPoints;
            return this;
        }

        public StatsBuilder WithHealthRegeneration(IStat healthRegeneration)
        {
            _healthRegeneration = healthRegeneration;
            return this;
        }

        public StatsBuilder WithLifeSteal(IStat lifeSteal)
        {
            _lifeSteal = lifeSteal;
            return this;
        }

        public StatsBuilder WithMagicResist(IStat magicResist)
        {
            _magicResist = magicResist;
            return this;
        }

        public StatsBuilder WithMagicPenetration(IStat magicPenetration)
        {
            _magicPenetration = magicPenetration;
            return this;
        }

        public StatsBuilder WithManaPoints(IStat manaPoints)
        {
            _manaPoints = manaPoints;
            return this;
        }

        public StatsBuilder WithManaRegeneration(IStat manaRegeneration)
        {
            _manaRegeneration = manaRegeneration;
            return this;
        }

        public StatsBuilder WithMoveSpeed(IStat moveSpeed)
        {
            _moveSpeed = moveSpeed;
            return this;
        }

        public StatsBuilder WithRange(IStat range)
        {
            _range = range;
            return this;
        }

        public StatsBuilder WithSize(IStat size)
        {
            _size = size;
            return this;
        }

        public StatsBuilder WithSpellVamp(IStat spellVamp)
        {
            _spellVamp = spellVamp;
            return this;
        }

        public StatsBuilder WithTenacity(IStat tenacity)
        {
            _tenacity = tenacity;
            return this;
        }

        public StatsBuilder WithGold(float gold)
        {
            _gold = gold;
            return this;
        }

        public StatsBuilder WithLevel(byte level)
        {
            _level = level;
            return this;
        }

        public StatsBuilder WithExperience(float experience)
        {
            _experience = experience;
            return this;
        }

        public StatsBuilder WithCurrentHealth(float currentHealth)
        {
            _currentHealth = currentHealth;
            return this;
        }

        public StatsBuilder WithCurrentMana(float currentMana)
        {
            _currentMana = currentMana;
            return this;
        }

        public StatsBuilder WithIsGeneratingGold(bool isGeneratingGold)
        {
            _isGeneratingGold = isGeneratingGold;
            return this;
        }

        public StatsBuilder WithSpellCostReduction(float spellCostReduction)
        {
            _spellCostReduction = spellCostReduction;
            return this;
        }

        public override Stats Build()
        {
            var instance = new Stats(_spellsEnabled, _isMagicImmune, _isInvulnerable, _isPhysicalImmune, _isLifestealImmune, _isTargetable, _isTargetableToTeam,
                _actionState, _parType, _attackSpeedFlat, _healthPerLevel, _manaPerLevel, _adPerLevel, _armorPerLevel, _magicResistPerLevel, _healthRegenerationPerLevel,
                _manaRegenerationPerLevel, _growthAttackSpeed, _manaCost, _abilityPower, _armor, _armorPenetration, _attackDamage, _attackSpeedMultiplier, _cooldownReduction,
                _criticalChance, _criticalDamage, _goldPerSecond, _healthPoints, _healthRegeneration, _lifeSteal, _magicResist, _magicPenetration, _manaPoints, _manaRegeneration,
                _moveSpeed, _range, _size, _spellVamp, _tenacity, _gold, _level, _experience, _currentHealth, _currentMana, _isGeneratingGold, _spellCostReduction);

            return instance;
        }
    }
}
