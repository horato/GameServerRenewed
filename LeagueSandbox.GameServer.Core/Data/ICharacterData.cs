using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Data
{
    public interface ICharacterData
    {
        string Name { get; }
        CharDataFlags Flags { get; }
        PrimaryAbilityResourceType PARType { get; }
        string AssetCategory { get; }
        int MonsterDataTableID { get; }
        bool RecordAsWard { get; }
        float PostAttackMoveDelay { get; }
        float ChasingAttackRangePercent { get; }
        int ChampionId { get; }
        float BaseSpellEffectiveness { get; }
        float BaseHP { get; }
        float BasePAR { get; }
        float HPPerLevel { get; }
        float PARPerLevel { get; }
        float HPRegenPerLevel { get; }
        float PARRegenPerLevel { get; }
        float BaseStaticHPRegen { get; }
        float BaseFactorHPRegen { get; }
        float BaseStaticPARRegen { get; }
        float BaseFactorPARRegen { get; }
        float BasePhysicalDamage { get; }
        float PhysicalDamagePerLevel { get; }
        float BaseAbilityPower { get; }
        float AbilityPowerIncPerLevel { get; }
        float BaseArmor { get; }
        float ArmorPerLevel { get; }
        float BaseSpellBlock { get; }
        float SpellBlockPerLevel { get; }
        float BaseDodge { get; }
        float DodgePerLevel { get; }
        float BaseMissChance { get; }
        float BaseCritChance { get; }
        float CritChancePerLevel { get; }
        float CritDamageMultiplier { get; }
        float BaseMoveSpeed { get; }
        float AttackRange { get; }
        float AttackAutoInterruptPercent { get; }
        float AcquisitionRange { get; }
        float AttackSpeedPerLevel { get; }
        float TowerTargetingPriority { get; }
        float DeathTime { get; }
        float GoldGivenOnDeath { get; }
        float ExpGivenOnDeath { get; }
        float GoldRadius { get; }
        float ExperienceRadius { get; }
        float DeathEventListeningRadius { get; }
        float LocalGoldGivenOnDeath { get; }
        float LocalExpGivenOnDeath { get; }
        bool LocalGoldSplitWithLastHitter { get; }
        float GlobalGoldGivenOnDeath { get; }
        float GlobalExpGivenOnDeath { get; }
        float PerceptionBubbleRadius { get; }
        float Significance { get; }
        string CriticalAttack { get; }
        float HitFxScale { get; }
        float OverrideCollisionHeight { get; }
        float OverrideCollisionRadius { get; }
        float PathfindingCollisionRadius { get; }
        float GameplayCollisionRadius { get; }
        float OccludedUnitSelectableDistance { get; }
        IPassiveData PassiveData { get; }
        IReadOnlyDictionary<SpellSlot, IBaseSpellData> Spells { get; }
        IReadOnlyDictionary<SpellSlot, string> ExtraSpells { get; }
        IReadOnlyDictionary<SpellSlot, IAttackData> AttacksData { get; }


        //float AttackSpeed { get; }
        //float BaseSpellEffectiveness { get; }
        //float CritAttack_AttackCastDelayOffsetPercent { get; }
        //string PassiveSpell { get; }
        //float PostAttackMoveDelay { get; }



        //int ChampionId { get; }
        //float ChasingAttackRangePercent { get; }
        //float SoulGivenOnDeath { get; }
        //bool RecordAsWard { get; }
        //float Map10_ArmorPerLevel { get; }
        //float Map10_BaseMP { get; }
        //float Map8_BaseMP { get; }
    }
}