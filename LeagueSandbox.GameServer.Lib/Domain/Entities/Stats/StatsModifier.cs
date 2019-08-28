using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Stats
{
    internal class StatsModifier : IStatsModifier
    {
        // Stats
        public IStatModifier HealthPoints { get; } = new StatModifier();
        public IStatModifier HealthRegeneration { get; } = new StatModifier();
        public IStatModifier AttackDamage { get; } = new StatModifier();
        public IStatModifier AbilityPower { get; } = new StatModifier();
        public IStatModifier CriticalChance { get; } = new StatModifier();
        public IStatModifier CriticalDamage { get; } = new StatModifier();
        public IStatModifier Armor { get; } = new StatModifier();
        public IStatModifier MagicResist { get; } = new StatModifier();
        public IStatModifier AttackSpeed { get; } = new StatModifier();
        public IStatModifier ArmorPenetration { get; } = new StatModifier();
        public IStatModifier MagicPenetration { get; } = new StatModifier();
        public IStatModifier ManaPoints { get; } = new StatModifier();
        public IStatModifier ManaRegeneration { get; } = new StatModifier();
        public IStatModifier LifeSteal { get; } = new StatModifier();
        public IStatModifier SpellVamp { get; } = new StatModifier();
        public IStatModifier Tenacity { get; } = new StatModifier();
        public IStatModifier Size { get; } = new StatModifier();
        public IStatModifier Range { get; } = new StatModifier();
        public IStatModifier MoveSpeed { get; } = new StatModifier();
        public IStatModifier GoldPerSecond { get; } = new StatModifier();

        public StatsModifier()
        {
        }

        public StatsModifier(IStatModifier healthPoints, IStatModifier healthRegeneration, IStatModifier attackDamage, IStatModifier abilityPower, IStatModifier criticalChance, IStatModifier criticalDamage, IStatModifier armor, IStatModifier magicResist, IStatModifier attackSpeed, IStatModifier armorPenetration, IStatModifier magicPenetration, IStatModifier manaPoints, IStatModifier manaRegeneration, IStatModifier lifeSteal, IStatModifier spellVamp, IStatModifier tenacity, IStatModifier size, IStatModifier range, IStatModifier moveSpeed, IStatModifier goldPerSecond)
        {
            HealthPoints = healthPoints;
            HealthRegeneration = healthRegeneration;
            AttackDamage = attackDamage;
            AbilityPower = abilityPower;
            CriticalChance = criticalChance;
            CriticalDamage = criticalDamage;
            Armor = armor;
            MagicResist = magicResist;
            AttackSpeed = attackSpeed;
            ArmorPenetration = armorPenetration;
            MagicPenetration = magicPenetration;
            ManaPoints = manaPoints;
            ManaRegeneration = manaRegeneration;
            LifeSteal = lifeSteal;
            SpellVamp = spellVamp;
            Tenacity = tenacity;
            Size = size;
            Range = range;
            MoveSpeed = moveSpeed;
            GoldPerSecond = goldPerSecond;
        }
    }
}
