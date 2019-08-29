using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Stats
{
    public interface IStats
    {
        SpellSlot SpellsEnabled { get; }
        bool IsMagicImmune { get; }
        bool IsInvulnerable { get; }
        bool IsPhysicalImmune { get; }
        bool IsLifestealImmune { get; }
        bool IsTargetable { get; }
        SpellFlags IsTargetableToTeam { get; }
        ActionState ActionState { get; }
        PrimaryAbilityResourceType ParType { get; }
        float AttackSpeedFlat { get; }
        float HealthPerLevel { get; }
        float ManaPerLevel { get; }
        float AdPerLevel { get; }
        float ArmorPerLevel { get; }
        float MagicResistPerLevel { get; }
        float HealthRegenerationPerLevel { get; }
        float ManaRegenerationPerLevel { get; }
        float GrowthAttackSpeed { get; }
        float[] ManaCost { get; }
        IStat AbilityPower { get; }
        IStat Armor { get; }
        IStat ArmorPenetration { get; }
        IStat AttackDamage { get; }
        IStat AttackSpeedMultiplier { get; }
        IStat CooldownReduction { get; }
        IStat CriticalChance { get; }
        IStat CriticalDamage { get; }
        IStat GoldPerSecond { get; }
        IStat HealthPoints { get; }
        IStat HealthRegeneration { get; }
        IStat LifeSteal { get; }
        IStat MagicResist { get; }
        IStat MagicPenetration { get; }
        IStat ManaPoints { get; }
        IStat ManaRegeneration { get; }
        IStat MoveSpeed { get; }
        IStat Range { get; }
        IStat Size { get; }
        IStat SpellVamp { get; }
        IStat Tenacity { get; }
        float Gold { get; }
        byte Level { get; }
        float Experience { get; }
        float CurrentHealth { get; }
        float CurrentMana { get; }
        bool IsGeneratingGold { get; }
        float SpellCostReduction { get; }
        void AddModifier(IStatsModifier modifier);
        void RemoveModifier(IStatsModifier modifier);
        float GetTotalAttackSpeed();
        bool GetSpellEnabled(SpellSlot slot);
        void SetSpellEnabled(SpellSlot slot, bool enabled);
        bool GetActionState(ActionState state);
        void SetActionState(ActionState state, bool enabled);
    }
}