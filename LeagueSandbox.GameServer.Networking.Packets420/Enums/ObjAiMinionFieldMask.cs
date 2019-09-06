using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal enum ObjAiMinionFieldMask : uint
    {
        FM2_HealthCurrent = 1 << 0,
        FM2_HealthTotal = 1 << 1,
        FM2_LifeTime = 1 << 2,
        FM2_LifeTimeMax = 1 << 3,
        FM2_LifeTimeTicks = 1 << 4,
        FM2_ManaTotal = 1 << 5,
        FM2_ManaCurrent = 1 << 6,
        FM2_ActionState = 1 << 7,
        FM2_IsMagicImmune = 1 << 8,
        FM2_IsInvulnerable = 1 << 9,
        FM2_IsPhysicalImmune = 1 << 10,
        FM2_IsLifestealImmune = 1 << 11,
        FM2_AttackDamageBase = 1 << 12,
        FM2_ArmorTotal = 1 << 13,
        FM2_MagicResistTotal = 1 << 14,
        FM2_AttackSpeedMultiplierTotal = 1 << 15,
        FM2_AttackDamageBonusFlat = 1 << 16,
        FM2_AttackDamageBonusPercent = 1 << 17,
        FM2_AbilityPowerTotal = 1 << 18,
        FM2_HealthRegenerationTotal = 1 << 19,
        FM2_ManaRegenerationTotal = 1 << 20,
        FM2_MagicResistBonusFlat = 1 << 21,
        FM2_MagicResistBonusPercent = 1 << 22,

        FM4_PerceptionRangeBonusFlat = 1 << 0,
        FM4_PerceptionRangeBonusPercent = 1 << 1,
        FM4_MoveSpeedTotal = 1 << 2,
        FM4_SizeTotal = 1 << 3,
        FM4_IsTargetable = 1 << 4,
        FM4_IsTargetableToTeam = 1 << 5,
    }
}
