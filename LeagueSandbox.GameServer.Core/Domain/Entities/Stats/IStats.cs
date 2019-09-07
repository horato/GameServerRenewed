using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Stats
{
    public interface IStats
    {
        bool SpellsModified { get; }
        bool IsTargetableToTeamModified { get; }
        bool ActionStateModfied { get; }
        bool ParTypeModified { get; }
        bool IsMagicImmuneIsModified { get; }
        bool IsInvulnerableIsModified { get; }
        bool IsPhysicalImmuneIsModified { get; }
        bool IsLifestealImmuneIsModified { get; }
        bool IsTargetableIsModified { get; }
        bool IsManaCostChanged { get; }

        SpellSlot SpellsEnabled { get; }
        SpellFlags IsTargetableToTeam { get; }
        ActionState ActionState { get; }
        PrimaryAbilityResourceType ParType { get; }

        bool IsMagicImmune { get; }
        bool IsInvulnerable { get; }
        bool IsPhysicalImmune { get; }
        bool IsLifestealImmune { get; }
        bool IsTargetable { get; }
        bool IsGeneratingGold { get; }
        float SpellCostReduction { get; }
        float GoldTotal { get; }

        IFlatStat FlatAttackSpeed { get; }
        IFlatStat FlatHealthPoints { get; }
        IFlatStat FlatManaPoints { get; }
        IFlatStat FlatAttackDamange { get; }
        IFlatStat FlatArmor { get; }
        IFlatStat FlatMagicResist { get; }
        IFlatStat Gold { get; }
        IFlatStat Level { get; }
        IFlatStat Experience { get; }

        IStat AbilityPower { get; }
        IStat Armor { get; }
        IStat ArmorPenetration { get; }
        IStat AttackDamage { get; }
        IStat AttackSpeedMultiplier { get; }
        IStat CooldownReduction { get; }
        IStat CriticalChance { get; }
        IStat CriticalDamage { get; }
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

        void AddModifier(IStatsModifier modifier);
        void RemoveModifier(IStatsModifier modifier);
        float GetTotalAttackSpeed();
        void AddGold(float amount);
        bool GetSpellEnabled(SpellSlot slot);
        void SetSpellEnabled(SpellSlot slot, bool enabled);
        bool GetActionState(ActionState state);
        void SetActionState(ActionState state, bool enabled);
        float GetManaCost(SpellSlot slot);
        void SetManaCost(SpellSlot slot, float value);
        void OnStatUpdateSent();
        bool IsStatsChanged();
        void UpdateTargetability(bool isTargetable, SpellFlags isTargetableToTeam);
    }
}