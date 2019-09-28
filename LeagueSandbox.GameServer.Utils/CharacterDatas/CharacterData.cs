using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    public class CharacterData
    {
        public float AbilityPowerIncPerLevel { get; }
        public float AcquisitionRange { get; }
        public float Armor { get; }
        public float ArmorPerLevel { get; }
        public float AttackCastTime { get; }
        public float AttackDelayCastOffsetPercent { get; }
        public float AttackDelayCastOffsetPercentAttackSpeedRatio { get; }
        public float AttackDelayOffsetPercent { get; }
        public float AttackRange { get; }
        public float AttackSpeed { get; }
        public float AttackSpeedPerLevel { get; }
        public float AttackTotalTime { get; }
        public float BaseAbilityPower { get; }
        public float BaseAttack_Probability { get; }
        public float BaseCritChance { get; }
        public float BaseDamage { get; }
        public float BaseDodge { get; }
        public float BaseFactorHPRegen { get; }
        public float BaseFactorMPRegen { get; }
        public float BaseHP { get; }
        public float BaseMP { get; }
        public float BaseSpellEffectiveness { get; }
        public float BaseStaticHPRegen { get; }
        public float BaseStaticMPRegen { get; }
        public float CritAttack_AttackCastDelayOffsetPercent { get; }
        public float CritAttack_AttackDelayCastOffsetPercent { get; }
        public float CritAttack_AttackDelayCastOffsetPercentAttackSpeedRatio { get; }
        public float CritAttack_AttackDelayOffsetPercent { get; }
        public float CritAttack_Probability { get; }
        public float CritDamageBonus { get; }
        public float CritPerLevel { get; }
        public float DamagePerLevel { get; }
        public float DelayCastOffsetPercent { get; }
        public float DelayTotalTimePercent { get; }
        public float ExperienceRadius { get; }
        public float ExpGivenOnDeath { get; }

        public string ExtraAttack1 { get; }
        public float ExtraAttack1_AttackCastTime { get; }
        public float ExtraAttack1_AttackDelayCastOffsetPercent { get; }
        public float ExtraAttack1_AttackDelayOffsetPercent { get; }
        public float ExtraAttack1_AttackTotalTime { get; }
        public float ExtraAttack1_Probability { get; }
        public string ExtraAttack2 { get; }
        public float ExtraAttack2_AttackDelayCastOffsetPercent { get; }
        public float ExtraAttack2_AttackDelayOffsetPercent { get; }
        public float ExtraAttack2_Probability { get; }
        public string ExtraAttack3 { get; }
        public float ExtraAttack3_AttackDelayCastOffsetPercent { get; }
        public float ExtraAttack3_AttackDelayOffsetPercent { get; }
        public float ExtraAttack3_Probability { get; }
        public string ExtraAttack4 { get; }
        public float ExtraAttack4_Probability { get; }
        public string ExtraAttack5 { get; }
        public float ExtraAttack5_Probability { get; }
        public string ExtraAttack6 { get; }
        public float ExtraAttack6_Probability { get; }
        public string ExtraAttack7 { get; }
        public float ExtraAttack7_Probability { get; }
        public string ExtraAttack8 { get; }
        public float ExtraAttack8_Probability { get; }
        public string ExtraCritAttack1 { get; }
        public float ExtraCritAttack1_AttackDelayCastOffsetPercent { get; }
        public string ExtraCritAttack2 { get; }
        public string ExtraCritAttack3 { get; }
        public string ExtraSpell1 { get; }
        public string ExtraSpell10 { get; }
        public string ExtraSpell11 { get; }
        public string ExtraSpell12 { get; }
        public string ExtraSpell13 { get; }
        public string ExtraSpell14 { get; }
        public string ExtraSpell2 { get; }
        public string ExtraSpell3 { get; }
        public string ExtraSpell4 { get; }
        public string ExtraSpell5 { get; }
        public string ExtraSpell6 { get; }
        public string ExtraSpell7 { get; }
        public string ExtraSpell8 { get; }
        public string ExtraSpell9 { get; }
        public float GameplayCollisionRadius { get; }
        public float GlobalExpGivenOnDeath { get; }
        public float GlobalGoldGivenOnDeath { get; }
        public float GoldGivenOnDeath { get; }
        public float HPPerLevel { get; }
        public float HPRegenPerLevel { get; }
        public int ChampionId { get; }
        public float ChasingAttackRangePercent { get; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool Immobile { get; }

        [JsonConverter(typeof(StringBoolConverter))]
        public bool IsElite { get; }

        [JsonConverter(typeof(StringBoolConverter))]
        public bool IsEpic { get; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool IsImportantBotTarget { get; }

        [JsonConverter(typeof(StringBoolConverter))]
        public bool IsMelee { get; }

        public float Map10_ArmorPerLevel { get; }
        public float Map10_BaseMP { get; }
        public float Map8_BaseMP { get; }
        public int[] MaxLevels { get; }
        public float MoveSpeed { get; }
        public float MPPerLevel { get; }
        public float MPRegenPerLevel { get; }
        public string Name { get; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool NoAutoAttack { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PrimaryAbilityResourceType PARType { get; }

        public string Passive1 { get; }
        public float? Passive1Effect1 { get; }
        public float? Passive1Effect2 { get; }
        public float? Passive1Effect3 { get; }
        public float? Passive1Effect4 { get; }
        public float? Passive1Effect5 { get; }
        public float Passive1Level1 { get; }
        public float Passive1Level2 { get; }
        public float Passive1Level3 { get; }
        public float Passive1Level4 { get; }
        public float Passive1Level5 { get; }
        public float Passive1Level6 { get; }
        public int Passive1NumEffects { get; }
        public float Passive1Range { get; }
        public string Passive2 { get; }
        public float Passive2Effect1 { get; }
        public float Passive2Effect2 { get; }
        public float Passive2Effect3 { get; }
        public float Passive2Effect4 { get; }
        public float Passive2Level1 { get; }
        public float Passive2Level2 { get; }
        public float Passive2Level3 { get; }
        public float Passive2Level4 { get; }
        public int Passive2NumEffects { get; }
        public string Passive3 { get; }
        public float Passive3Level1 { get; }
        public int Passive3NumEffects { get; }
        public string Passive4 { get; }
        public float Passive4Level1 { get; }
        public int Passive4NumEffects { get; }
        public string PassiveSpell { get; }
        public float PathfindingCollisionRadius { get; }
        public float PerceptionBubbleRadius { get; }
        public float PostAttackMoveDelay { get; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool RecordAsWard { get; }
        public float SoulGivenOnDeath { get; }
        public string Spell1 { get; }
        public string Spell2 { get; }
        public string Spell3 { get; }
        public string Spell4 { get; }
        public float SpellBlock { get; }
        public float SpellBlockPerLevel { get; }
        public int[] SpellsUpLevels1 { get; }
        public int[] SpellsUpLevels2 { get; }
        public int[] SpellsUpLevels3 { get; }
        public int[] SpellsUpLevels4 { get; }
        public int TowerTargetingPriorityBoost { get; }

        public CharacterData(float abilityPowerIncPerLevel, float acquisitionRange, float armor, float armorPerLevel, float attackCastTime, float attackDelayCastOffsetPercent, float attackDelayCastOffsetPercentAttackSpeedRatio, float attackDelayOffsetPercent, float attackRange, float attackSpeed, float attackSpeedPerLevel, float attackTotalTime, float baseAbilityPower, float baseAttackProbability, float baseCritChance, float baseDamage, float baseDodge, float baseFactorHpRegen, float baseFactorMpRegen, float baseHp, float baseMp, float baseSpellEffectiveness, float baseStaticHpRegen, float baseStaticMpRegen, float critAttackAttackCastDelayOffsetPercent, float critAttackAttackDelayCastOffsetPercent, float critAttackAttackDelayCastOffsetPercentAttackSpeedRatio, float critAttackAttackDelayOffsetPercent, float critAttackProbability, float critDamageBonus, float critPerLevel, float damagePerLevel, float delayCastOffsetPercent, float delayTotalTimePercent, float experienceRadius, float expGivenOnDeath, string extraAttack1, float extraAttack1AttackCastTime, float extraAttack1AttackDelayCastOffsetPercent, float extraAttack1AttackDelayOffsetPercent, float extraAttack1AttackTotalTime, float extraAttack1Probability, string extraAttack2, float extraAttack2AttackDelayCastOffsetPercent, float extraAttack2AttackDelayOffsetPercent, float extraAttack2Probability, string extraAttack3, float extraAttack3AttackDelayCastOffsetPercent, float extraAttack3AttackDelayOffsetPercent, float extraAttack3Probability, string extraAttack4, float extraAttack4Probability, string extraAttack5, float extraAttack5Probability, string extraAttack6, float extraAttack6Probability, string extraAttack7, float extraAttack7Probability, string extraAttack8, float extraAttack8Probability, string extraCritAttack1, float extraCritAttack1AttackDelayCastOffsetPercent, string extraCritAttack2, string extraCritAttack3, string extraSpell1, string extraSpell10, string extraSpell11, string extraSpell12, string extraSpell13, string extraSpell14, string extraSpell2, string extraSpell3, string extraSpell4, string extraSpell5, string extraSpell6, string extraSpell7, string extraSpell8, string extraSpell9, float gameplayCollisionRadius, float globalExpGivenOnDeath, float globalGoldGivenOnDeath, float goldGivenOnDeath, float hpPerLevel, float hpRegenPerLevel, int championId, float chasingAttackRangePercent, bool immobile, bool isElite, bool isEpic, bool isImportantBotTarget, bool isMelee, float map10ArmorPerLevel, float map10BaseMp, float map8BaseMp, int[] maxLevels, float moveSpeed, float mpPerLevel, float mpRegenPerLevel, string name, bool noAutoAttack, PrimaryAbilityResourceType parType, string passive1, float? passive1Effect1, float? passive1Effect2, float? passive1Effect3, float? passive1Effect4, float? passive1Effect5, float passive1Level1, float passive1Level2, float passive1Level3, float passive1Level4, float passive1Level5, float passive1Level6, int passive1NumEffects, float passive1Range, string passive2, float passive2Effect1, float passive2Effect2, float passive2Effect3, float passive2Effect4, float passive2Level1, float passive2Level2, float passive2Level3, float passive2Level4, int passive2NumEffects, string passive3, float passive3Level1, int passive3NumEffects, string passive4, float passive4Level1, int passive4NumEffects, string passiveSpell, float pathfindingCollisionRadius, float perceptionBubbleRadius, float postAttackMoveDelay, bool recordAsWard, float soulGivenOnDeath, string spell1, string spell2, string spell3, string spell4, float spellBlock, float spellBlockPerLevel, int[] spellsUpLevels1, int[] spellsUpLevels2, int[] spellsUpLevels3, int[] spellsUpLevels4, int towerTargetingPriorityBoost)
        {
            AbilityPowerIncPerLevel = abilityPowerIncPerLevel;
            AcquisitionRange = acquisitionRange;
            Armor = armor;
            ArmorPerLevel = armorPerLevel;
            AttackCastTime = attackCastTime;
            AttackDelayCastOffsetPercent = attackDelayCastOffsetPercent;
            AttackDelayCastOffsetPercentAttackSpeedRatio = attackDelayCastOffsetPercentAttackSpeedRatio;
            AttackDelayOffsetPercent = attackDelayOffsetPercent;
            AttackRange = attackRange;
            AttackSpeed = attackSpeed;
            AttackSpeedPerLevel = attackSpeedPerLevel;
            AttackTotalTime = attackTotalTime;
            BaseAbilityPower = baseAbilityPower;
            BaseAttack_Probability = baseAttackProbability;
            BaseCritChance = baseCritChance;
            BaseDamage = baseDamage;
            BaseDodge = baseDodge;
            BaseFactorHPRegen = baseFactorHpRegen;
            BaseFactorMPRegen = baseFactorMpRegen;
            BaseHP = baseHp;
            BaseMP = baseMp;
            BaseSpellEffectiveness = baseSpellEffectiveness;
            BaseStaticHPRegen = baseStaticHpRegen;
            BaseStaticMPRegen = baseStaticMpRegen;
            CritAttack_AttackCastDelayOffsetPercent = critAttackAttackCastDelayOffsetPercent;
            CritAttack_AttackDelayCastOffsetPercent = critAttackAttackDelayCastOffsetPercent;
            CritAttack_AttackDelayCastOffsetPercentAttackSpeedRatio = critAttackAttackDelayCastOffsetPercentAttackSpeedRatio;
            CritAttack_AttackDelayOffsetPercent = critAttackAttackDelayOffsetPercent;
            CritAttack_Probability = critAttackProbability;
            CritDamageBonus = critDamageBonus;
            CritPerLevel = critPerLevel;
            DamagePerLevel = damagePerLevel;
            DelayCastOffsetPercent = delayCastOffsetPercent;
            DelayTotalTimePercent = delayTotalTimePercent;
            ExperienceRadius = experienceRadius;
            ExpGivenOnDeath = expGivenOnDeath;
            ExtraAttack1 = extraAttack1;
            ExtraAttack1_AttackCastTime = extraAttack1AttackCastTime;
            ExtraAttack1_AttackDelayCastOffsetPercent = extraAttack1AttackDelayCastOffsetPercent;
            ExtraAttack1_AttackDelayOffsetPercent = extraAttack1AttackDelayOffsetPercent;
            ExtraAttack1_AttackTotalTime = extraAttack1AttackTotalTime;
            ExtraAttack1_Probability = extraAttack1Probability;
            ExtraAttack2 = extraAttack2;
            ExtraAttack2_AttackDelayCastOffsetPercent = extraAttack2AttackDelayCastOffsetPercent;
            ExtraAttack2_AttackDelayOffsetPercent = extraAttack2AttackDelayOffsetPercent;
            ExtraAttack2_Probability = extraAttack2Probability;
            ExtraAttack3 = extraAttack3;
            ExtraAttack3_AttackDelayCastOffsetPercent = extraAttack3AttackDelayCastOffsetPercent;
            ExtraAttack3_AttackDelayOffsetPercent = extraAttack3AttackDelayOffsetPercent;
            ExtraAttack3_Probability = extraAttack3Probability;
            ExtraAttack4 = extraAttack4;
            ExtraAttack4_Probability = extraAttack4Probability;
            ExtraAttack5 = extraAttack5;
            ExtraAttack5_Probability = extraAttack5Probability;
            ExtraAttack6 = extraAttack6;
            ExtraAttack6_Probability = extraAttack6Probability;
            ExtraAttack7 = extraAttack7;
            ExtraAttack7_Probability = extraAttack7Probability;
            ExtraAttack8 = extraAttack8;
            ExtraAttack8_Probability = extraAttack8Probability;
            ExtraCritAttack1 = extraCritAttack1;
            ExtraCritAttack1_AttackDelayCastOffsetPercent = extraCritAttack1AttackDelayCastOffsetPercent;
            ExtraCritAttack2 = extraCritAttack2;
            ExtraCritAttack3 = extraCritAttack3;
            ExtraSpell1 = extraSpell1;
            ExtraSpell10 = extraSpell10;
            ExtraSpell11 = extraSpell11;
            ExtraSpell12 = extraSpell12;
            ExtraSpell13 = extraSpell13;
            ExtraSpell14 = extraSpell14;
            ExtraSpell2 = extraSpell2;
            ExtraSpell3 = extraSpell3;
            ExtraSpell4 = extraSpell4;
            ExtraSpell5 = extraSpell5;
            ExtraSpell6 = extraSpell6;
            ExtraSpell7 = extraSpell7;
            ExtraSpell8 = extraSpell8;
            ExtraSpell9 = extraSpell9;
            GameplayCollisionRadius = gameplayCollisionRadius;
            GlobalExpGivenOnDeath = globalExpGivenOnDeath;
            GlobalGoldGivenOnDeath = globalGoldGivenOnDeath;
            GoldGivenOnDeath = goldGivenOnDeath;
            HPPerLevel = hpPerLevel;
            HPRegenPerLevel = hpRegenPerLevel;
            ChampionId = championId;
            ChasingAttackRangePercent = chasingAttackRangePercent;
            Immobile = immobile;
            IsElite = isElite;
            IsEpic = isEpic;
            IsImportantBotTarget = isImportantBotTarget;
            IsMelee = isMelee;
            Map10_ArmorPerLevel = map10ArmorPerLevel;
            Map10_BaseMP = map10BaseMp;
            Map8_BaseMP = map8BaseMp;
            MaxLevels = maxLevels ?? new[] { 5, 5, 5, 3 };
            MoveSpeed = moveSpeed;
            MPPerLevel = mpPerLevel;
            MPRegenPerLevel = mpRegenPerLevel;
            Name = name;
            NoAutoAttack = noAutoAttack;
            PARType = parType;
            Passive1 = passive1;
            Passive1Effect1 = passive1Effect1;
            Passive1Effect2 = passive1Effect2;
            Passive1Effect3 = passive1Effect3;
            Passive1Effect4 = passive1Effect4;
            Passive1Effect5 = passive1Effect5;
            Passive1Level1 = passive1Level1;
            Passive1Level2 = passive1Level2;
            Passive1Level3 = passive1Level3;
            Passive1Level4 = passive1Level4;
            Passive1Level5 = passive1Level5;
            Passive1Level6 = passive1Level6;
            Passive1NumEffects = passive1NumEffects;
            Passive1Range = passive1Range;
            Passive2 = passive2;
            Passive2Effect1 = passive2Effect1;
            Passive2Effect2 = passive2Effect2;
            Passive2Effect3 = passive2Effect3;
            Passive2Effect4 = passive2Effect4;
            Passive2Level1 = passive2Level1;
            Passive2Level2 = passive2Level2;
            Passive2Level3 = passive2Level3;
            Passive2Level4 = passive2Level4;
            Passive2NumEffects = passive2NumEffects;
            Passive3 = passive3;
            Passive3Level1 = passive3Level1;
            Passive3NumEffects = passive3NumEffects;
            Passive4 = passive4;
            Passive4Level1 = passive4Level1;
            Passive4NumEffects = passive4NumEffects;
            PassiveSpell = passiveSpell;
            PathfindingCollisionRadius = pathfindingCollisionRadius;
            PerceptionBubbleRadius = perceptionBubbleRadius;
            PostAttackMoveDelay = postAttackMoveDelay;
            RecordAsWard = recordAsWard;
            SoulGivenOnDeath = soulGivenOnDeath;
            Spell1 = spell1;
            Spell2 = spell2;
            Spell3 = spell3;
            Spell4 = spell4;
            SpellBlock = spellBlock;
            SpellBlockPerLevel = spellBlockPerLevel;
            SpellsUpLevels1 = spellsUpLevels1;
            SpellsUpLevels2 = spellsUpLevels2;
            SpellsUpLevels3 = spellsUpLevels3;
            SpellsUpLevels4 = spellsUpLevels4;
            TowerTargetingPriorityBoost = towerTargetingPriorityBoost;
        }
    }
}
