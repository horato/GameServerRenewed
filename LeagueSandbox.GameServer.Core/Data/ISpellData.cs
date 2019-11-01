using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Data
{
    public interface ISpellData
    {
        string Name { get; }
        SpellFlags Flags { get; }
        string TextFlags { get; }
        IReadOnlyDictionary<int, float> CooldownTime { get; }
        IReadOnlyDictionary<int, int> MaxAmmo { get; }
        IReadOnlyDictionary<int, int> AmmoUsed { get; }
        IReadOnlyDictionary<int, float> AmmoRechargeTime { get; }
        IReadOnlyDictionary<int, float> ChannelDuration { get; }
        IReadOnlyDictionary<int, float> CastRange { get; }
        IReadOnlyDictionary<int, float> CastRangeGrowthMax { get; }
        IReadOnlyDictionary<int, float> CastRangeGrowthDuration { get; }
        IReadOnlyDictionary<int, float> CastRadius { get; }
        IReadOnlyDictionary<int, float> CastRadiusSecondary { get; }
        IReadOnlyDictionary<int, float> Mana { get; }
        float SpellCastTime { get; }
        float SpellTotalTime { get; }
        float OverrideCastTime { get; }
        float StartCooldown { get; }
        float ChargeUpdateInterval { get; }
        float CancelChargeOnRecastTime { get; }
        float CastConeAngle { get; }
        float CastConeDistance { get; }
        float CastTargetAdditionalUnitsRadius { get; }
        CastType CastType { get; }
        float CastFrame { get; }
        float LineWidth { get; }
        float LineDragLength { get; }
        LookAtPolicy LookAtPolicy { get; }
        SelectionPreference SelectionPreference { get; }
        TargetingType TargetingType { get; }
        bool CastRangeUseBoundingBoxes { get; }
        bool AmmoNotAffectedByCDR { get; }
        bool UseAutoattackCastTime { get; }
        bool IgnoreAnimContinueUntilCastFrame { get; }
        bool IsToggleSpell { get; }
        bool CanNotBeSuppressed { get; }
        bool CanCastWhileDisabled { get; }
        bool CanOnlyCastWhileDisabled { get; }
        bool CantCancelWhileWindingUp { get; }
        bool CantCancelWhileChanneling { get; }
        bool CantCastWhileRooted { get; }
        bool DoesntBreakChannels { get; }
        bool IsDisabledWhileDead { get; }
        bool CanOnlyCastWhileDead { get; }
        bool SpellRevealsChampion { get; }
        bool UseChargeChanneling { get; }
        bool UseChargeTargeting { get; }
        bool CanMoveWhileChanneling { get; }
        bool DoNotNeedToFaceTarget { get; }
        bool NoWinddownIfCancelled { get; }
        bool IgnoreRangeCheck { get; }
        bool ConsideredAsAutoAttack { get; }
        bool ApplyAttackDamage { get; }
        bool ApplyAttackEffect { get; }
        bool AlwaysSnapFacing { get; }
        bool BelongsToAvatar { get; }
        ICastData CastData { get; }

        //string AfterEffectName 
        //int AIBlockLevel 
        //int AIEndOnly 
        //float AILifetime 
        //float AIRadius 
        //float AIRange 
        //int AISendEvent 
        //float AISpeed 
        //string AlternateName 
        //int AmmoCountHiddenInUI 
        //bool ApplyMaterialOnHitSound 
        //float AttackDelayCastOffsetPercent 
        //string CastRadiusSecondaryTexture 
        //float CastRangeDisplayOverride 
        //string ClientOnlyMissileTargetBoneName 
        //float Coefficient 
        //float Coefficient2 
        //float EffectXLevelYAmount 
        //int DeathRecapPriority 
        //string DisplayName 
        //int FloatStaticsDecimalsX 
        //int FloatVarsDecimalsX 
        //bool HaveAfterEffect 
        //bool HaveHitBone 
        //bool HaveHitEffect 
        //bool HavePointEffect 
        //string HitBoneName 
        //string HitEffectName 
        //bool LineMissileCollisionFromStartPoint 
        //float LineMissileTargetHeightAugment 
        //float LocationTargettingLengthX 
        //float LocationTargettingWidthX 
        //float MapX_CooldownY 
        //float MapX_EffectYLevelZAmount 
        //string MissileBoneName 
        //string MissileEffect 
        //string MissileEffectPlayer 
        //bool MissileFollowsTerrainHeight 
        //int NumSpellTargeters 
        //float[] ParticleStartOffset 
        //bool PlatformEnabled 
        //bool SubjectToGlobalCooldown 
        //bool TriggersGlobalCooldown 
        //bool UpdateRotationWhenCasting 
        //bool UseMinimapTargeting 
        //int Version 
        ////float X1 
        //float X2 
        //float X3 
        //float X4 
        //float X5 

    }
}