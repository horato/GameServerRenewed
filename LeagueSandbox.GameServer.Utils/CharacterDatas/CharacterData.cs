using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    public class CharacterData : ICharacterData
    {
        public string Name { get; }
        public CharDataFlags Flags { get; }
        public PrimaryAbilityResourceType PARType { get; }
        public string AssetCategory { get; }
        public int MonsterDataTableID { get; }
        public bool RecordAsWard { get; }
        public float PostAttackMoveDelay { get; }
        public float ChasingAttackRangePercent { get; }
        public int ChampionId { get; }
        public float BaseSpellEffectiveness { get; }
        public float BaseHP { get; }
        public float BasePAR { get; }
        public float HPPerLevel { get; }
        public float PARPerLevel { get; }
        public float HPRegenPerLevel { get; }
        public float PARRegenPerLevel { get; }
        public float BaseStaticHPRegen { get; }
        public float BaseFactorHPRegen { get; }
        public float BaseStaticPARRegen { get; }
        public float BaseFactorPARRegen { get; }
        public float BasePhysicalDamage { get; }
        public float PhysicalDamagePerLevel { get; }
        public float BaseAbilityPower { get; }
        public float AbilityPowerIncPerLevel { get; }
        public float BaseArmor { get; }
        public float ArmorPerLevel { get; }
        public float BaseSpellBlock { get; }
        public float SpellBlockPerLevel { get; }
        public float BaseDodge { get; }
        public float DodgePerLevel { get; }
        public float BaseMissChance { get; }
        public float BaseCritChance { get; }
        public float CritChancePerLevel { get; }
        public float CritDamageMultiplier { get; }
        public float BaseMoveSpeed { get; }
        public float AttackRange { get; }
        public float AttackAutoInterruptPercent { get; }
        public float AcquisitionRange { get; }
        public float AttackSpeedPerLevel { get; }
        public float TowerTargetingPriority { get; }
        public float DeathTime { get; }
        public float GoldGivenOnDeath { get; }
        public float ExpGivenOnDeath { get; }
        public float GoldRadius { get; }
        public float ExperienceRadius { get; }
        public float DeathEventListeningRadius { get; }
        public float LocalGoldGivenOnDeath { get; }
        public float LocalExpGivenOnDeath { get; }
        public bool LocalGoldSplitWithLastHitter { get; }
        public float GlobalGoldGivenOnDeath { get; }
        public float GlobalExpGivenOnDeath { get; }
        public float PerceptionBubbleRadius { get; }
        public float Significance { get; }
        public string CriticalAttack { get; }
        public float HitFxScale { get; }
        public float OverrideCollisionHeight { get; }
        public float OverrideCollisionRadius { get; }
        public float PathfindingCollisionRadius { get; }
        public float GameplayCollisionRadius { get; }
        public float OccludedUnitSelectableDistance { get; }
        public IPassiveData PassiveData { get; }
        public IReadOnlyDictionary<SpellSlot, IBaseSpellData> Spells { get; }
        public IReadOnlyDictionary<SpellSlot, string> ExtraSpells { get; }
        public IReadOnlyDictionary<SpellSlot, IAttackData> AttacksData { get; }

        public CharacterData(string name, CharDataFlags flags, PrimaryAbilityResourceType parType, string assetCategory, int monsterDataTableId, bool recordAsWard, float postAttackMoveDelay, float chasingAttackRangePercent, int championId, float baseSpellEffectiveness, float baseHp, float basePar, float hpPerLevel, float parPerLevel, float hpRegenPerLevel, float parRegenPerLevel, float baseStaticHpRegen, float baseFactorHpRegen, float baseStaticParRegen, float baseFactorParRegen, float basePhysicalDamage, float physicalDamagePerLevel, float baseAbilityPower, float abilityPowerIncPerLevel, float baseArmor, float armorPerLevel, float baseSpellBlock, float spellBlockPerLevel, float baseDodge, float dodgePerLevel, float baseMissChance, float baseCritChance, float critChancePerLevel, float critDamageMultiplier, float baseMoveSpeed, float attackRange, float attackAutoInterruptPercent, float acquisitionRange, float attackSpeedPerLevel, float towerTargetingPriority, float deathTime, float goldGivenOnDeath, float expGivenOnDeath, float goldRadius, float experienceRadius, float deathEventListeningRadius, float localGoldGivenOnDeath, float localExpGivenOnDeath, bool localGoldSplitWithLastHitter, float globalGoldGivenOnDeath, float globalExpGivenOnDeath, float perceptionBubbleRadius, float significance, string criticalAttack, float hitFxScale, float overrideCollisionHeight, float overrideCollisionRadius, float pathfindingCollisionRadius, float gameplayCollisionRadius, float occludedUnitSelectableDistance, IPassiveData passiveData, IReadOnlyDictionary<SpellSlot, IBaseSpellData> spells, IReadOnlyDictionary<SpellSlot, string> extraSpells, IReadOnlyDictionary<SpellSlot, IAttackData> attacksData)
        {
            Name = name;
            Flags = flags;
            PARType = parType;
            AssetCategory = assetCategory;
            MonsterDataTableID = monsterDataTableId;
            RecordAsWard = recordAsWard;
            PostAttackMoveDelay = postAttackMoveDelay;
            ChasingAttackRangePercent = chasingAttackRangePercent;
            ChampionId = championId;
            BaseSpellEffectiveness = baseSpellEffectiveness;
            BaseHP = baseHp;
            BasePAR = basePar;
            HPPerLevel = hpPerLevel;
            PARPerLevel = parPerLevel;
            HPRegenPerLevel = hpRegenPerLevel;
            PARRegenPerLevel = parRegenPerLevel;
            BaseStaticHPRegen = baseStaticHpRegen;
            BaseFactorHPRegen = baseFactorHpRegen;
            BaseStaticPARRegen = baseStaticParRegen;
            BaseFactorPARRegen = baseFactorParRegen;
            BasePhysicalDamage = basePhysicalDamage;
            PhysicalDamagePerLevel = physicalDamagePerLevel;
            BaseAbilityPower = baseAbilityPower;
            AbilityPowerIncPerLevel = abilityPowerIncPerLevel;
            BaseArmor = baseArmor;
            ArmorPerLevel = armorPerLevel;
            BaseSpellBlock = baseSpellBlock;
            SpellBlockPerLevel = spellBlockPerLevel;
            BaseDodge = baseDodge;
            DodgePerLevel = dodgePerLevel;
            BaseMissChance = baseMissChance;
            BaseCritChance = baseCritChance;
            CritChancePerLevel = critChancePerLevel;
            CritDamageMultiplier = critDamageMultiplier;
            BaseMoveSpeed = baseMoveSpeed;
            AttackRange = attackRange;
            AttackAutoInterruptPercent = attackAutoInterruptPercent;
            AcquisitionRange = acquisitionRange;
            AttackSpeedPerLevel = attackSpeedPerLevel;
            TowerTargetingPriority = towerTargetingPriority;
            DeathTime = deathTime;
            GoldGivenOnDeath = goldGivenOnDeath;
            ExpGivenOnDeath = expGivenOnDeath;
            GoldRadius = goldRadius;
            ExperienceRadius = experienceRadius;
            DeathEventListeningRadius = deathEventListeningRadius;
            LocalGoldGivenOnDeath = localGoldGivenOnDeath;
            LocalExpGivenOnDeath = localExpGivenOnDeath;
            LocalGoldSplitWithLastHitter = localGoldSplitWithLastHitter;
            GlobalGoldGivenOnDeath = globalGoldGivenOnDeath;
            GlobalExpGivenOnDeath = globalExpGivenOnDeath;
            PerceptionBubbleRadius = perceptionBubbleRadius;
            Significance = significance;
            CriticalAttack = criticalAttack;
            HitFxScale = hitFxScale;
            OverrideCollisionHeight = overrideCollisionHeight;
            OverrideCollisionRadius = overrideCollisionRadius;
            PathfindingCollisionRadius = pathfindingCollisionRadius;
            GameplayCollisionRadius = gameplayCollisionRadius;
            OccludedUnitSelectableDistance = occludedUnitSelectableDistance;
            PassiveData = passiveData;
            Spells = spells;
            ExtraSpells = extraSpells;
            AttacksData = attacksData;
        }
    }
}
