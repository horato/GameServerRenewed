using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal enum ObjAiTurretFieldMask : uint
    {
        FM2_ManaTotal = 1 << 0,
        FM2_ManaCurrent = 1 << 1,
        FM2_ActionState = 1 << 2,
        FM2_MagicImmune = 1 << 3,
        FM2_Invulnerable = 1 << 4,
        FM2_PhysicalImmune = 1 << 5,
        FM2_LifestealImmune = 1 << 6,
        FM2_AttackDamageBase = 1 << 7,
        FM2_ArmorTotal = 1 << 8,
        FM2_MagicResistTotal = 1 << 9,
        FM2_AttackSpeedMultiplierTotal = 1 << 10,
        FM2_AttackDamageBonusFlat = 1 << 11,
        FM2_AttackDamageBonusPercent = 1 << 12,
        FM2_AbilityPowerTotal = 1 << 13,
        FM2_HealthRegenerationTotal = 1 << 14,

        FM4_HealthCurrent = 1 << 0,
        FM4_HealthTotal = 1 << 1,
        FM4_PerceptionRangeBonusFlat = 1 << 2,
        FM4_PerceptionRangeBonusPercent = 1 << 3,
        FM4_MoveSpeedTotal = 1 << 4,
        FM4_SizeTotal = 1 << 5,

        FM6_IsTargetable = 1 << 0,
        FM6_IsTargetableToTeam = 1 << 1,
    }
}
