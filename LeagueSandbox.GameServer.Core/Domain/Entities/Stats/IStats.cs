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

        /// <summary> AS/level </summary>
        IFlatStat FlatAttackSpeed { get; }

        /// <summary> Current HP, HP/level, HP5/level, HP5 static </summary>
        IFlatStat FlatHealthPoints { get; }

        /// <summary> current MP, MP/level, MP5/level, MP5 static </summary>
        IFlatStat FlatManaPoints { get; }
        
        /// <summary> AD/level </summary>
        IFlatStat FlatAttackDamage { get; }

        /// <summary> AP/level </summary>
        IFlatStat FlatSpellDamage { get; }

        /// <summary> Armor/level </summary>
        IFlatStat FlatArmor { get; }

        /// <summary> MR/level </summary>
        IFlatStat FlatMagicResist { get; }

        /// <summary> Crit chance/level </summary>
        IFlatStat FlatCritChance { get; }

        /// <summary> Current gold </summary>
        IFlatStat Gold { get; }

        /// <summary> Current level </summary>
        IFlatStat Level { get; }

        /// <summary> Current Exp </summary>
        IFlatStat Experience { get; }

        IStat AbilityPower { get; }
        IStat Armor { get; }
        IStat ArmorPenetration { get; }
        IStat AttackDamage { get; }
        IStat AttackSpeedMultiplier { get; }
        IStat CooldownReduction { get; }
        IStat CriticalChance { get; }
        IStat CriticalDamage { get; }

        /// <summary> Max HP </summary>
        IStat HealthPoints { get; }
        IStat HealthRegeneration { get; }
        IStat LifeSteal { get; }
        IStat MagicResist { get; }
        IStat MagicPenetration { get; }

        /// <summary> Max MP </summary>
        IStat ManaPoints { get; }
        IStat ManaRegeneration { get; }
        IStat MoveSpeed { get; }
        IStat Range { get; }
        IStat Size { get; }
        IStat SpellVamp { get; }
        IStat Tenacity { get; }

        void AddModifier(IStatsModifier modifier);
        void RemoveModifier(IStatsModifier modifier);
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