using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    public enum ObjAiHeroFieldMask : uint
    {
        FM1_Gold = 1 << 0,
        FM1_Gold_Total = 1 << 1,
        FM1_Spells_Enabled_Lower = 1 << 2, // Bits: 0-3 -> Q-R, 4-9 -> Items, 10 -> Trinket
        FM1_Spells_Enabled_Upper = 1 << 3,
        FM1_SummonerSpells_Enabled_Lower = 1 << 4, // Bits: 0 -> D, 1 -> F
        FM1_SummonerSpells_Enabled_Upper = 1 << 5,
        FM1_EvolvePoints = 1 << 6,
        FM1_EvolveFlag = 1 << 7,
        FM1_ManaCost_Q = 1 << 8,
        FM1_ManaCost_W = 1 << 9,
        FM1_ManaCost_E = 1 << 10,
        FM1_ManaCost_R = 1 << 11,
        FM1_ManaCost_Ex0 = 1 << 12,
        FM1_ManaCost_Ex1 = 1 << 13,
        FM1_ManaCost_Ex2 = 1 << 14,
        FM1_ManaCost_Ex3 = 1 << 15,
        FM1_ManaCost_Ex4 = 1 << 16,
        FM1_ManaCost_Ex5 = 1 << 17,
        FM1_ManaCost_Ex6 = 1 << 18,
        FM1_ManaCost_Ex7 = 1 << 19,
        FM1_ManaCost_Ex8 = 1 << 20,
        FM1_ManaCost_Ex9 = 1 << 21,
        FM1_ManaCost_Ex10 = 1 << 22,
        FM1_ManaCost_Ex11 = 1 << 23,
        FM1_ManaCost_Ex12 = 1 << 24,
        FM1_ManaCost_Ex13 = 1 << 25,
        FM1_ManaCost_Ex14 = 1 << 26,
        FM1_ManaCost_Ex15 = 1 << 27,

        FM2_ActionState = 1 << 0,
        FM2_MagicImmune = 1 << 1,
        FM2_Invulnerable = 1 << 2,
        FM2_PhysicalImmune = 1 << 3,
        FM2_LifestealImmune = 1 << 4,
        FM2_AttackDamageBase = 1 << 5,
        FM2_AbilityPowerBase = 1 << 6,
        FM2_Dodge = 1 << 7,
        FM2_CritChanceTotal = 1 << 8, // 0.5 = 50%
        FM2_ArmorTotal = 1 << 9,
        FM2_MagicResistTotal = 1 << 10,
        FM2_HealthRegenerationTotal = 1 << 11,
        FM2_ManaRegenerationTotal = 1 << 12,
        FM2_AttackRangeTotal = 1 << 13,
        FM2_AttackDamageBonusFlat = 1 << 14,
        FM2_AttackDamageBonusPercent = 1 << 15,
        FM2_AbilityPowerBonusFlat = 1 << 16,
        FM2_MagicResistBonusFlat = 1 << 17,
        FM2_MagicResistBonusPercent = 1 << 18,
        FM2_AttackSpeedMultiplierTotal = 1 << 19, // Attack speed multiplier. If set to 2 and champ's base attack speed is 0.600, then his new AtkSpeed becomes 1.200
        FM2_AttackRangeBonusFlat = 1 << 20,
        FM2_CooldownReductionTotal = 1 << 21, // 0.5 = 50% 
        FM2_PassiveCooldownEndTime = 1 << 22,
        FM2_PassiveCooldownTotalTime = 1 << 23,
        FM2_ArmorPenetrationBonusFlat = 1 << 24,
        FM2_ArmorPenetrationBonusPercent = 1 << 25,
        FM2_MagicPenetrationBonusFlat = 1 << 26,
        FM2_MagicPenetrationBonusPercent = 1 << 27,
        FM2_LifeStealTotal = 1 << 28, // 0.5 = 50%
        FM2_SpellVampTotal = 1 << 29, // 0.5 = 50%
        FM2_TenacityTotal = 1 << 30, // 0.5 = 50%

        FM3_ArmorBonusPercent = 1 << 0,
        FM3_MagicPenetrationBonusPercent = 1 << 1,
        FM3_HealthRegenerationBonusPercent = 1 << 2,
        FM3_ManaRegenerationBonusPercent = 1 << 3,

        FM4_HealthCurrent = 1 << 0,
        FM4_ManaCurrent = 1 << 1,
        FM4_HealthTotal = 1 << 2,
        FM4_ManaTotal = 1 << 3,
        FM4_Experience = 1 << 4,
        FM4_LifeTime = 1 << 5, //?
        FM4_LifeTimeMax = 1 << 6, //?
        FM4_LifeTimeTicks = 1 << 7, //?
        FM4_PerceptionRangeBonusFlat = 1 << 8, //vision?
        FM4_PerceptionRangeBonusPercent = 1 << 9,
        FM4_MoveSpeedTotal = 1 << 10,
        FM4_SizeTotal = 1 << 11,
        FM4_PathfindingRadiusBonusFlat = 1 << 12,
        FM4_ChampionLevel = 1 << 13,
        FM4_MinionsKilled = 1 << 14,
        FM4_IsTargetable = 1 << 15,
        FM4_IsTargetableToTeam = 1 << 16,
    }
}
