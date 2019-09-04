using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Stats
{
    internal class StatsModifierBuilder : EntityBuilderBase<StatsModifier>
    {
        private IStatModifier _healthPoints = new StatModifierBuilder().Build();
        private IStatModifier _healthRegeneration = new StatModifierBuilder().Build();
        private IStatModifier _attackDamage = new StatModifierBuilder().Build();
        private IStatModifier _abilityPower = new StatModifierBuilder().Build();
        private IStatModifier _criticalChance = new StatModifierBuilder().Build();
        private IStatModifier _criticalDamage = new StatModifierBuilder().Build();
        private IStatModifier _armor = new StatModifierBuilder().Build();
        private IStatModifier _magicResist = new StatModifierBuilder().Build();
        private IStatModifier _attackSpeed = new StatModifierBuilder().Build();
        private IStatModifier _armorPenetration = new StatModifierBuilder().Build();
        private IStatModifier _magicPenetration = new StatModifierBuilder().Build();
        private IStatModifier _manaPoints = new StatModifierBuilder().Build();
        private IStatModifier _manaRegeneration = new StatModifierBuilder().Build();
        private IStatModifier _lifeSteal = new StatModifierBuilder().Build();
        private IStatModifier _spellVamp = new StatModifierBuilder().Build();
        private IStatModifier _tenacity = new StatModifierBuilder().Build();
        private IStatModifier _size = new StatModifierBuilder().Build();
        private IStatModifier _range = new StatModifierBuilder().Build();
        private IStatModifier _moveSpeed = new StatModifierBuilder().Build();
        private IStatModifier _goldPerSecond = new StatModifierBuilder().Build();
        
        public StatsModifierBuilder WithHealthPoints(IStatModifier healthPoints)
        {
            _healthPoints = healthPoints;
            return this;
        }

        public StatsModifierBuilder WithHealthRegeneration(IStatModifier healthRegeneration)
        {
            _healthRegeneration = healthRegeneration;
            return this;
        }

        public StatsModifierBuilder WithAttackDamage(IStatModifier attackDamage)
        {
            _attackDamage = attackDamage;
            return this;
        }

        public StatsModifierBuilder WithAbilityPower(IStatModifier abilityPower)
        {
            _abilityPower = abilityPower;
            return this;
        }

        public StatsModifierBuilder WithCriticalChance(IStatModifier criticalChance)
        {
            _criticalChance = criticalChance;
            return this;
        }

        public StatsModifierBuilder WithCriticalDamage(IStatModifier criticalDamage)
        {
            _criticalDamage = criticalDamage;
            return this;
        }

        public StatsModifierBuilder WithArmor(IStatModifier armor)
        {
            _armor = armor;
            return this;
        }

        public StatsModifierBuilder WithMagicResist(IStatModifier magicResist)
        {
            _magicResist = magicResist;
            return this;
        }

        public StatsModifierBuilder WithAttackSpeed(IStatModifier attackSpeed)
        {
            _attackSpeed = attackSpeed;
            return this;
        }

        public StatsModifierBuilder WithArmorPenetration(IStatModifier armorPenetration)
        {
            _armorPenetration = armorPenetration;
            return this;
        }

        public StatsModifierBuilder WithMagicPenetration(IStatModifier magicPenetration)
        {
            _magicPenetration = magicPenetration;
            return this;
        }

        public StatsModifierBuilder WithManaPoints(IStatModifier manaPoints)
        {
            _manaPoints = manaPoints;
            return this;
        }

        public StatsModifierBuilder WithManaRegeneration(IStatModifier manaRegeneration)
        {
            _manaRegeneration = manaRegeneration;
            return this;
        }

        public StatsModifierBuilder WithLifeSteal(IStatModifier lifeSteal)
        {
            _lifeSteal = lifeSteal;
            return this;
        }

        public StatsModifierBuilder WithSpellVamp(IStatModifier spellVamp)
        {
            _spellVamp = spellVamp;
            return this;
        }

        public StatsModifierBuilder WithTenacity(IStatModifier tenacity)
        {
            _tenacity = tenacity;
            return this;
        }

        public StatsModifierBuilder WithSize(IStatModifier size)
        {
            _size = size;
            return this;
        }

        public StatsModifierBuilder WithRange(IStatModifier range)
        {
            _range = range;
            return this;
        }

        public StatsModifierBuilder WithMoveSpeed(IStatModifier moveSpeed)
        {
            _moveSpeed = moveSpeed;
            return this;
        }

        public StatsModifierBuilder WithGoldPerSecond(IStatModifier goldPerSecond)
        {
            _goldPerSecond = goldPerSecond;
            return this;
        }
        
        public override StatsModifier Build()
        {
            var instance = new StatsModifier(_healthPoints, _healthRegeneration, _attackDamage, _abilityPower, _criticalChance, _criticalDamage, 
                _armor, _magicResist, _attackSpeed, _armorPenetration, _magicPenetration, _manaPoints, _manaRegeneration, _lifeSteal, _spellVamp,
                _tenacity, _size, _range, _moveSpeed, _goldPerSecond);

            return instance;
        }
    }
}