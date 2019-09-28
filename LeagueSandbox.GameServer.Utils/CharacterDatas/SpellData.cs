using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    /// <summary>
    /// TODO: Remove public setters once the bug in json deserializer is fixed
    /// https://github.com/JamesNK/Newtonsoft.Json/issues/2176
    /// </summary>
    public class SpellData
    {
        public string AfterEffectName { get; set; }
        public int AIBlockLevel { get; set; }
        public int AIEndOnly { get; set; }
        public float AILifetime { get; set; }
        public float AIRadius { get; set; }
        public float AIRange { get; set; }
        public int AISendEvent { get; set; }
        public float AISpeed { get; set; }
        public string AlternateName { get; set; }
        public object AlwaysSnapFacing { get; set; }
        public int AmmoCountHiddenInUI { get; set; }
        public float AmmoRechargeTime { get; set; }
        public float AmmoRechargeTime1 { get; set; }
        public float AmmoRechargeTime2 { get; set; }
        public float AmmoRechargeTime3 { get; set; }
        public float AmmoRechargeTime4 { get; set; }
        public float AmmoRechargeTime5 { get; set; }
        public float AmmoRechargeTime6 { get; set; }
        public int AmmoUsed { get; set; }
        public string AnimationLoopName { get; set; }
        public string AnimationName { get; set; }
        public string AnimationWinddownName { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool ApplyAttackDamage { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool ApplyAttackEffect { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool ApplyMaterialOnHitSound { get; set; }
        public float AttackDelayCastOffsetPercent { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool BelongsToAvatar { get; set; }
        public float BounceRadius { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CanCastWhileDisabled { get; set; }
        public float CancelChargeOnRecastTime { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CanMoveWhileChanneling { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CannotBeSuppressed { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CanOnlyCastWhileDead { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CantCancelWhileChanneling { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CantCancelWhileWindingUp { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CantCastWhileRooted { get; set; }

        public float CastConeAngle { get; set; }
        public float CastConeDistance { get; set; }
        public float CastFrame { get; set; }
        public float CastRadius { get; set; }
        public float CastRadius1 { get; set; }
        public float CastRadius2 { get; set; }
        public float CastRadius3 { get; set; }
        public float CastRadiusSecondary { get; set; }
        public string CastRadiusSecondaryTexture { get; set; }
        public string CastRadiusTexture { get; set; }
        public float CastRange { get; set; }
        public float CastRange1 { get; set; }
        public float CastRange2 { get; set; }
        public float CastRange3 { get; set; }
        public float CastRange4 { get; set; }
        public float CastRange5 { get; set; }
        public float CastRange6 { get; set; }
        public float CastRangeDisplayOverride { get; set; }
        public float CastRangeGrowthDuration { get; set; }
        public float CastRangeGrowthDuration1 { get; set; }
        public float CastRangeGrowthDuration2 { get; set; }
        public float CastRangeGrowthDuration3 { get; set; }
        public float CastRangeGrowthDuration4 { get; set; }
        public float CastRangeGrowthDuration5 { get; set; }
        public float CastRangeGrowthMax { get; set; }
        public float CastRangeGrowthMax1 { get; set; }
        public float CastRangeGrowthMax2 { get; set; }
        public float CastRangeGrowthMax3 { get; set; }
        public float CastRangeGrowthMax4 { get; set; }
        public float CastRangeGrowthMax5 { get; set; }
        public string CastRangeTextureOverrideName { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CastRangeUseBoundingBoxes { get; set; }
        public float CastTargetAdditionalUnitsRadius { get; set; }
        public CastType CastType { get; set; }
        public float CircleMissileAngularVelocity { get; set; }
        public float CircleMissileRadialVelocity { get; set; }
        public string ClientOnlyMissileTargetBoneName { get; set; }
        public float Coefficient { get; set; }
        public float Coefficient2 { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool ConsideredAsAutoAttack { get; set; }
        public float Cooldown { get; set; }
        public float Cooldown0 { get; set; }
        public float Cooldown1 { get; set; }
        public float Cooldown2 { get; set; }
        public float Cooldown3 { get; set; }
        public float Cooldown4 { get; set; }
        public float Cooldown5 { get; set; }
        public float Cooldown6 { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CursorChangesInGrass { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool CursorChangesInTerrain { get; set; }
        public int DeathRecapPriority { get; set; }
        public float DelayCastOffsetPercent { get; set; }
        public float DelayTotalTimePercent { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool DisableCastBar { get; set; }
        public string DisplayName { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool DoesntBreakChannels { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool DoNotNeedToFaceTarget { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool DrawSecondaryLineIndicator { get; set; }
        public string DynamicExtended { get; set; }
        public string DynamicTooltip { get; set; }
        public float Effect10Level1Amount { get; set; }
        public float Effect10Level2Amount { get; set; }
        public float Effect10Level3Amount { get; set; }
        public float Effect10Level4Amount { get; set; }
        public float Effect10Level5Amount { get; set; }
        public float Effect1Level0Amount { get; set; }
        public float Effect1Level1Amount { get; set; }
        public float Effect1Level2Amount { get; set; }
        public float Effect1Level3Amount { get; set; }
        public float Effect1Level4Amount { get; set; }
        public float Effect1Level5Amount { get; set; }
        public float Effect1Level6Amount { get; set; }
        public float Effect2Level0Amount { get; set; }
        public float Effect2Level1Amount { get; set; }
        public float Effect2Level2Amount { get; set; }
        public float Effect2Level3Amount { get; set; }
        public float Effect2Level4Amount { get; set; }
        public float Effect2Level5Amount { get; set; }
        public float Effect2Level6Amount { get; set; }
        public float Effect3Level0Amount { get; set; }
        public float Effect3Level1Amount { get; set; }
        public float Effect3Level2Amount { get; set; }
        public float Effect3Level3Amount { get; set; }
        public float Effect3Level4Amount { get; set; }
        public float Effect3Level5Amount { get; set; }
        public float Effect3Level6Amount { get; set; }
        public float Effect4Level0Amount { get; set; }
        public float Effect4Level1Amount { get; set; }
        public float Effect4Level2Amount { get; set; }
        public float Effect4Level3Amount { get; set; }
        public float Effect4Level4Amount { get; set; }
        public float Effect4Level5Amount { get; set; }
        public float Effect4Level6Amount { get; set; }
        public float Effect5Level0Amount { get; set; }
        public float Effect5Level1Amount { get; set; }
        public float Effect5Level2Amount { get; set; }
        public float Effect5Level3Amount { get; set; }
        public float Effect5Level4Amount { get; set; }
        public float Effect5Level5Amount { get; set; }
        public float Effect5Level6Amount { get; set; }
        public float Effect6Level0Amount { get; set; }
        public float Effect6Level1Amount { get; set; }
        public float Effect6Level2Amount { get; set; }
        public float Effect6Level3Amount { get; set; }
        public float Effect6Level4Amount { get; set; }
        public float Effect6Level5Amount { get; set; }
        public float Effect6Level6Amount { get; set; }
        public float Effect7Level0Amount { get; set; }
        public float Effect7Level1Amount { get; set; }
        public float Effect7Level2Amount { get; set; }
        public float Effect7Level3Amount { get; set; }
        public float Effect7Level4Amount { get; set; }
        public float Effect7Level5Amount { get; set; }
        public float Effect7Level6Amount { get; set; }
        public float Effect8Level0Amount { get; set; }
        public float Effect8Level1Amount { get; set; }
        public float Effect8Level2Amount { get; set; }
        public float Effect8Level3Amount { get; set; }
        public float Effect8Level4Amount { get; set; }
        public float Effect8Level5Amount { get; set; }
        public float Effect8Level6Amount { get; set; }
        public float Effect9Level0Amount { get; set; }
        public float Effect9Level1Amount { get; set; }
        public float Effect9Level2Amount { get; set; }
        public float Effect9Level3Amount { get; set; }
        public float Effect9Level4Amount { get; set; }
        public float Effect9Level5Amount { get; set; }
        public float Effect9Level6Amount { get; set; }
        public SpellFlags Flags { get; set; }
        public int FloatStaticsDecimals1 { get; set; }
        public int FloatStaticsDecimals2 { get; set; }
        public int FloatStaticsDecimals3 { get; set; }
        public int FloatStaticsDecimals4 { get; set; }
        public int FloatStaticsDecimals5 { get; set; }
        public int FloatStaticsDecimals6 { get; set; }
        public int FloatVarsDecimals1 { get; set; }
        public int FloatVarsDecimals2 { get; set; }
        public int FloatVarsDecimals3 { get; set; }
        public int FloatVarsDecimals4 { get; set; }
        public int FloatVarsDecimals5 { get; set; }
        public int FloatVarsDecimals6 { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool HaveAfterEffect { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool HaveHitBone { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool HaveHitEffect { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool HavePointEffect { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool HideRangeIndicatorWhenCasting { get; set; }
        public string HitBoneName { get; set; }
        public string HitEffectName { get; set; }

        /// <summary> This is an enum, add if needed </summary>
        public int HitEffectOrientType { get; set; }
        public string HitEffectPlayerName { get; set; }
        public float ChannelDuration { get; set; }
        public float ChannelDuration1 { get; set; }
        public float ChannelDuration2 { get; set; }
        public float ChannelDuration3 { get; set; }
        public float ChannelDuration4 { get; set; }
        public float ChannelDuration5 { get; set; }
        public float ChannelDuration6 { get; set; }
        public float ChargeUpdateInterval { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool IgnoreAnimContinueUntilCastFrame { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool IgnoreRangeCheck { get; set; }
        public string InventoryIcon { get; set; }
        public string InventoryIcon1 { get; set; }
        public string InventoryIcon2 { get; set; }
        public string InventoryIcon3 { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool IsDisabledWhileDead { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool IsToggleSpell { get; set; }
        public string Level1Desc { get; set; }
        public string Level2Desc { get; set; }
        public string Level3Desc { get; set; }
        public string Level4Desc { get; set; }
        public string Level5Desc { get; set; }
        public string Level6Desc { get; set; }
        public float LineDragLength { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool LineMissileBounces { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool LineMissileCollisionFromStartPoint { get; set; }
        public float LineMissileDelayDestroyAtEndSeconds { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool LineMissileEndsAtTargetPoint { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool LineMissileFollowsTerrainHeight { get; set; }
        public float LineMissileTargetHeightAugment { get; set; }
        public float LineMissileTimePulseBetweenCollisionSpellHits { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool LineMissileTrackUnits { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool LineMissileUsesAccelerationForBounce { get; set; }
        public string LineTargetingBaseTextureOverrideName { get; set; }
        public string LineTargetingTargetTextureOverrideName { get; set; }
        public float LineWidth { get; set; }
        public float LocationTargettingLength1 { get; set; }
        public float LocationTargettingLength2 { get; set; }
        public float LocationTargettingLength3 { get; set; }
        public float LocationTargettingLength4 { get; set; }
        public float LocationTargettingLength5 { get; set; }
        public float LocationTargettingLength6 { get; set; }
        public float LocationTargettingWidth1 { get; set; }
        public float LocationTargettingWidth2 { get; set; }
        public float LocationTargettingWidth3 { get; set; }
        public float LocationTargettingWidth4 { get; set; }
        public float LocationTargettingWidth5 { get; set; }
        public float LocationTargettingWidth6 { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool LockConeToPlayer { get; set; }

        /// <summary> This is an enum, add if needed </summary>
        public string LookAtPolicy { get; set; }
        public float LuaOnMissileUpdateDistanceInterval { get; set; }
        public float ManaCost { get; set; }
        public float ManaCost1 { get; set; }
        public float ManaCost2 { get; set; }
        public float ManaCost3 { get; set; }
        public float ManaCost4 { get; set; }
        public float ManaCost5 { get; set; }
        public float ManaCost6 { get; set; }
        public float Map10_Cooldown1 { get; set; }
        public float Map10_Cooldown2 { get; set; }
        public float Map10_Cooldown3 { get; set; }
        public float Map10_Cooldown4 { get; set; }
        public float Map10_Cooldown5 { get; set; }
        public float Map10_Effect1Level1Amount { get; set; }
        public float Map10_Effect1Level2Amount { get; set; }
        public float Map10_Effect1Level3Amount { get; set; }
        public float Map10_Effect2Level1Amount { get; set; }
        public float Map10_Effect2Level2Amount { get; set; }
        public float Map10_Effect2Level3Amount { get; set; }
        public float Map10_Effect2Level4Amount { get; set; }
        public float Map10_Effect2Level5Amount { get; set; }
        public float Map10_Effect4Level0Amount { get; set; }
        public float Map10_Effect4Level1Amount { get; set; }
        public float Map10_Effect4Level2Amount { get; set; }
        public float Map10_Effect4Level3Amount { get; set; }
        public float Map10_Effect4Level4Amount { get; set; }
        public float Map10_Effect4Level5Amount { get; set; }
        public float Map10_Effect4Level6Amount { get; set; }
        public float Map8_Cooldown1 { get; set; }
        public float Map8_Cooldown2 { get; set; }
        public float Map8_Cooldown3 { get; set; }
        public float Map8_Cooldown4 { get; set; }
        public float Map8_Cooldown5 { get; set; }
        public int MaxAmmo { get; set; }
        public string MaxGrowthRangeTextureName { get; set; }
        public string MinimapIcon { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool MinimapIconDisplayFlag { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool MinimapIconRotation { get; set; }
        public float MissileAccel { get; set; }
        public string MissileBoneName { get; set; }
        public string MissileEffect { get; set; }
        public string MissileEffectPlayer { get; set; }
        public float MissileFixedTravelTime { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool MissileFollowsTerrainHeight { get; set; }
        public float MissileGravity { get; set; }
        public float MissileLifetime { get; set; }
        public float MissileMaxSpeed { get; set; }
        public float MissileMinSpeed { get; set; }
        public float MissileMinTravelTime { get; set; }
        public float MissilePerceptionBubbleRadius { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool MissilePerceptionBubbleRevealsStealth { get; set; }
        public float MissileSpeed { get; set; }
        public float MissileTargetHeightAugment { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool MissileUnblockable { get; set; }
        public int NumSpellTargeters { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool OrientRadiusTextureFromPlayer { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool OrientRangeIndicatorToCursor { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool OrientRangeIndicatorToFacing { get; set; }
        public float OverrideCastTime { get; set; }
        public float[] ParticleStartOffset { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool PlatformEnabled { get; set; }
        public string PointEffectName { get; set; }
        public string RangeIndicatorTextureName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SelectionPreference SelectionPreference { get; set; }
        public string Sound_CastName { get; set; }
        public string Sound_HitName { get; set; }
        public string Sound_VOEventCategory { get; set; }
        public float SpellCastTime { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool SpellRevealsChampion { get; set; }
        public float SpellTotalTime { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool StartCooldown { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool SubjectToGlobalCooldown { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool TargeterConstrainedToRange { get; set; }
        public TargetingType TargettingType { get; set; }
        public string TextFlags { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool TriggersGlobalCooldown { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool UpdateRotationWhenCasting { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool UseAnimatorFramerate { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool UseAutoattackCastTime { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool UseGlobalLineIndicator { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool UseChargeChanneling { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool UseChargeTargeting { get; set; }

        [JsonConverter(typeof(IntBoolConverter))]
        public bool UseMinimapTargeting { get; set; }
        public int Version { get; set; }
        public float X1 { get; set; }
        public float X2 { get; set; }
        public float X3 { get; set; }
        public float X4 { get; set; }
        public float X5 { get; set; }

        [JsonConstructor]
        private SpellData()
        {

        }


        public SpellData(string afterEffectName, int aiBlockLevel, int aiEndOnly, float aiLifetime, float aiRadius, float aiRange, int aiSendEvent, float aiSpeed, string alternateName, object alwaysSnapFacing, int ammoCountHiddenInUi, float ammoRechargeTime, float ammoRechargeTime1, float ammoRechargeTime2, float ammoRechargeTime3, float ammoRechargeTime4, float ammoRechargeTime5, float ammoRechargeTime6, int ammoUsed, string animationLoopName, string animationName, string animationWinddownName, bool applyAttackDamage, bool applyAttackEffect, bool applyMaterialOnHitSound, float attackDelayCastOffsetPercent, bool belongsToAvatar, float bounceRadius, bool canCastWhileDisabled, float cancelChargeOnRecastTime, bool canMoveWhileChanneling, bool cannotBeSuppressed, bool canOnlyCastWhileDead, bool cantCancelWhileChanneling, bool cantCancelWhileWindingUp, bool cantCastWhileRooted, float castConeAngle, float castConeDistance, float castFrame, float castRadius, float castRadius1, float castRadius2, float castRadius3, float castRadiusSecondary, string castRadiusSecondaryTexture, string castRadiusTexture, float castRange, float castRange1, float castRange2, float castRange3, float castRange4, float castRange5, float castRange6, float castRangeDisplayOverride, float castRangeGrowthDuration, float castRangeGrowthDuration1, float castRangeGrowthDuration2, float castRangeGrowthDuration3, float castRangeGrowthDuration4, float castRangeGrowthDuration5, float castRangeGrowthMax, float castRangeGrowthMax1, float castRangeGrowthMax2, float castRangeGrowthMax3, float castRangeGrowthMax4, float castRangeGrowthMax5, string castRangeTextureOverrideName, bool castRangeUseBoundingBoxes, float castTargetAdditionalUnitsRadius, CastType castType, float circleMissileAngularVelocity, float circleMissileRadialVelocity, string clientOnlyMissileTargetBoneName, float coefficient, float coefficient2, bool consideredAsAutoAttack, float cooldown, float cooldown0, float cooldown1, float cooldown2, float cooldown3, float cooldown4, float cooldown5, float cooldown6, bool cursorChangesInGrass, bool cursorChangesInTerrain, int deathRecapPriority, float delayCastOffsetPercent, float delayTotalTimePercent, string description, bool disableCastBar, string displayName, bool doesntBreakChannels, bool doNotNeedToFaceTarget, bool drawSecondaryLineIndicator, string dynamicExtended, string dynamicTooltip, float effect10Level1Amount, float effect10Level2Amount, float effect10Level3Amount, float effect10Level4Amount, float effect10Level5Amount, float effect1Level0Amount, float effect1Level1Amount, float effect1Level2Amount, float effect1Level3Amount, float effect1Level4Amount, float effect1Level5Amount, float effect1Level6Amount, float effect2Level0Amount, float effect2Level1Amount, float effect2Level2Amount, float effect2Level3Amount, float effect2Level4Amount, float effect2Level5Amount, float effect2Level6Amount, float effect3Level0Amount, float effect3Level1Amount, float effect3Level2Amount, float effect3Level3Amount, float effect3Level4Amount, float effect3Level5Amount, float effect3Level6Amount, float effect4Level0Amount, float effect4Level1Amount, float effect4Level2Amount, float effect4Level3Amount, float effect4Level4Amount, float effect4Level5Amount, float effect4Level6Amount, float effect5Level0Amount, float effect5Level1Amount, float effect5Level2Amount, float effect5Level3Amount, float effect5Level4Amount, float effect5Level5Amount, float effect5Level6Amount, float effect6Level0Amount, float effect6Level1Amount, float effect6Level2Amount, float effect6Level3Amount, float effect6Level4Amount, float effect6Level5Amount, float effect6Level6Amount, float effect7Level0Amount, float effect7Level1Amount, float effect7Level2Amount, float effect7Level3Amount, float effect7Level4Amount, float effect7Level5Amount, float effect7Level6Amount, float effect8Level0Amount, float effect8Level1Amount, float effect8Level2Amount, float effect8Level3Amount, float effect8Level4Amount, float effect8Level5Amount, float effect8Level6Amount, float effect9Level0Amount, float effect9Level1Amount, float effect9Level2Amount, float effect9Level3Amount, float effect9Level4Amount, float effect9Level5Amount, float effect9Level6Amount, SpellFlags flags, int floatStaticsDecimals1, int floatStaticsDecimals2, int floatStaticsDecimals3, int floatStaticsDecimals4, int floatStaticsDecimals5, int floatStaticsDecimals6, int floatVarsDecimals1, int floatVarsDecimals2, int floatVarsDecimals3, int floatVarsDecimals4, int floatVarsDecimals5, int floatVarsDecimals6, bool haveAfterEffect, bool haveHitBone, bool haveHitEffect, bool havePointEffect, bool hideRangeIndicatorWhenCasting, string hitBoneName, string hitEffectName, int hitEffectOrientType, string hitEffectPlayerName, float channelDuration, float channelDuration1, float channelDuration2, float channelDuration3, float channelDuration4, float channelDuration5, float channelDuration6, float chargeUpdateInterval, bool ignoreAnimContinueUntilCastFrame, bool ignoreRangeCheck, string inventoryIcon, string inventoryIcon1, string inventoryIcon2, string inventoryIcon3, bool isDisabledWhileDead, bool isToggleSpell, string level1Desc, string level2Desc, string level3Desc, string level4Desc, string level5Desc, string level6Desc, float lineDragLength, bool lineMissileBounces, bool lineMissileCollisionFromStartPoint, float lineMissileDelayDestroyAtEndSeconds, bool lineMissileEndsAtTargetPoint, bool lineMissileFollowsTerrainHeight, float lineMissileTargetHeightAugment, float lineMissileTimePulseBetweenCollisionSpellHits, bool lineMissileTrackUnits, bool lineMissileUsesAccelerationForBounce, string lineTargetingBaseTextureOverrideName, string lineTargetingTargetTextureOverrideName, float lineWidth, float locationTargettingLength1, float locationTargettingLength2, float locationTargettingLength3, float locationTargettingLength4, float locationTargettingLength5, float locationTargettingLength6, float locationTargettingWidth1, float locationTargettingWidth2, float locationTargettingWidth3, float locationTargettingWidth4, float locationTargettingWidth5, float locationTargettingWidth6, bool lockConeToPlayer, string lookAtPolicy, float luaOnMissileUpdateDistanceInterval, float manaCost, float manaCost1, float manaCost2, float manaCost3, float manaCost4, float manaCost5, float manaCost6, float map10Cooldown1, float map10Cooldown2, float map10Cooldown3, float map10Cooldown4, float map10Cooldown5, float map10Effect1Level1Amount, float map10Effect1Level2Amount, float map10Effect1Level3Amount, float map10Effect2Level1Amount, float map10Effect2Level2Amount, float map10Effect2Level3Amount, float map10Effect2Level4Amount, float map10Effect2Level5Amount, float map10Effect4Level0Amount, float map10Effect4Level1Amount, float map10Effect4Level2Amount, float map10Effect4Level3Amount, float map10Effect4Level4Amount, float map10Effect4Level5Amount, float map10Effect4Level6Amount, float map8Cooldown1, float map8Cooldown2, float map8Cooldown3, float map8Cooldown4, float map8Cooldown5, int maxAmmo, string maxGrowthRangeTextureName, string minimapIcon, bool minimapIconDisplayFlag, bool minimapIconRotation, float missileAccel, string missileBoneName, string missileEffect, string missileEffectPlayer, float missileFixedTravelTime, bool missileFollowsTerrainHeight, float missileGravity, float missileLifetime, float missileMaxSpeed, float missileMinSpeed, float missileMinTravelTime, float missilePerceptionBubbleRadius, bool missilePerceptionBubbleRevealsStealth, float missileSpeed, float missileTargetHeightAugment, bool missileUnblockable, int numSpellTargeters, bool orientRadiusTextureFromPlayer, bool orientRangeIndicatorToCursor, bool orientRangeIndicatorToFacing, float overrideCastTime, float[] particleStartOffset, bool platformEnabled, string pointEffectName, string rangeIndicatorTextureName, SelectionPreference selectionPreference, string soundCastName, string soundHitName, string soundVoEventCategory, float spellCastTime, bool spellRevealsChampion, float spellTotalTime, bool startCooldown, bool subjectToGlobalCooldown, bool targeterConstrainedToRange, TargetingType targettingType, string textFlags, bool triggersGlobalCooldown, bool updateRotationWhenCasting, bool useAnimatorFramerate, bool useAutoattackCastTime, bool useGlobalLineIndicator, bool useChargeChanneling, bool useChargeTargeting, bool useMinimapTargeting, int version, float x1, float x2, float x3, float x4, float x5)
        {
            AfterEffectName = afterEffectName;
            AIBlockLevel = aiBlockLevel;
            AIEndOnly = aiEndOnly;
            AILifetime = aiLifetime;
            AIRadius = aiRadius;
            AIRange = aiRange;
            AISendEvent = aiSendEvent;
            AISpeed = aiSpeed;
            AlternateName = alternateName;
            AlwaysSnapFacing = alwaysSnapFacing;
            AmmoCountHiddenInUI = ammoCountHiddenInUi;
            AmmoRechargeTime = ammoRechargeTime;
            AmmoRechargeTime1 = ammoRechargeTime1;
            AmmoRechargeTime2 = ammoRechargeTime2;
            AmmoRechargeTime3 = ammoRechargeTime3;
            AmmoRechargeTime4 = ammoRechargeTime4;
            AmmoRechargeTime5 = ammoRechargeTime5;
            AmmoRechargeTime6 = ammoRechargeTime6;
            AmmoUsed = ammoUsed;
            AnimationLoopName = animationLoopName;
            AnimationName = animationName;
            AnimationWinddownName = animationWinddownName;
            ApplyAttackDamage = applyAttackDamage;
            ApplyAttackEffect = applyAttackEffect;
            ApplyMaterialOnHitSound = applyMaterialOnHitSound;
            AttackDelayCastOffsetPercent = attackDelayCastOffsetPercent;
            BelongsToAvatar = belongsToAvatar;
            BounceRadius = bounceRadius;
            CanCastWhileDisabled = canCastWhileDisabled;
            CancelChargeOnRecastTime = cancelChargeOnRecastTime;
            CanMoveWhileChanneling = canMoveWhileChanneling;
            CannotBeSuppressed = cannotBeSuppressed;
            CanOnlyCastWhileDead = canOnlyCastWhileDead;
            CantCancelWhileChanneling = cantCancelWhileChanneling;
            CantCancelWhileWindingUp = cantCancelWhileWindingUp;
            CantCastWhileRooted = cantCastWhileRooted;
            CastConeAngle = castConeAngle;
            CastConeDistance = castConeDistance;
            CastFrame = castFrame;
            CastRadius = castRadius;
            CastRadius1 = castRadius1;
            CastRadius2 = castRadius2;
            CastRadius3 = castRadius3;
            CastRadiusSecondary = castRadiusSecondary;
            CastRadiusSecondaryTexture = castRadiusSecondaryTexture;
            CastRadiusTexture = castRadiusTexture;
            CastRange = castRange;
            CastRange1 = castRange1;
            CastRange2 = castRange2;
            CastRange3 = castRange3;
            CastRange4 = castRange4;
            CastRange5 = castRange5;
            CastRange6 = castRange6;
            CastRangeDisplayOverride = castRangeDisplayOverride;
            CastRangeGrowthDuration = castRangeGrowthDuration;
            CastRangeGrowthDuration1 = castRangeGrowthDuration1;
            CastRangeGrowthDuration2 = castRangeGrowthDuration2;
            CastRangeGrowthDuration3 = castRangeGrowthDuration3;
            CastRangeGrowthDuration4 = castRangeGrowthDuration4;
            CastRangeGrowthDuration5 = castRangeGrowthDuration5;
            CastRangeGrowthMax = castRangeGrowthMax;
            CastRangeGrowthMax1 = castRangeGrowthMax1;
            CastRangeGrowthMax2 = castRangeGrowthMax2;
            CastRangeGrowthMax3 = castRangeGrowthMax3;
            CastRangeGrowthMax4 = castRangeGrowthMax4;
            CastRangeGrowthMax5 = castRangeGrowthMax5;
            CastRangeTextureOverrideName = castRangeTextureOverrideName;
            CastRangeUseBoundingBoxes = castRangeUseBoundingBoxes;
            CastTargetAdditionalUnitsRadius = castTargetAdditionalUnitsRadius;
            CastType = castType;
            CircleMissileAngularVelocity = circleMissileAngularVelocity;
            CircleMissileRadialVelocity = circleMissileRadialVelocity;
            ClientOnlyMissileTargetBoneName = clientOnlyMissileTargetBoneName;
            Coefficient = coefficient;
            Coefficient2 = coefficient2;
            ConsideredAsAutoAttack = consideredAsAutoAttack;
            Cooldown = cooldown;
            Cooldown0 = cooldown0;
            Cooldown1 = cooldown1;
            Cooldown2 = cooldown2;
            Cooldown3 = cooldown3;
            Cooldown4 = cooldown4;
            Cooldown5 = cooldown5;
            Cooldown6 = cooldown6;
            CursorChangesInGrass = cursorChangesInGrass;
            CursorChangesInTerrain = cursorChangesInTerrain;
            DeathRecapPriority = deathRecapPriority;
            DelayCastOffsetPercent = delayCastOffsetPercent;
            DelayTotalTimePercent = delayTotalTimePercent;
            Description = description;
            DisableCastBar = disableCastBar;
            DisplayName = displayName;
            DoesntBreakChannels = doesntBreakChannels;
            DoNotNeedToFaceTarget = doNotNeedToFaceTarget;
            DrawSecondaryLineIndicator = drawSecondaryLineIndicator;
            DynamicExtended = dynamicExtended;
            DynamicTooltip = dynamicTooltip;
            Effect10Level1Amount = effect10Level1Amount;
            Effect10Level2Amount = effect10Level2Amount;
            Effect10Level3Amount = effect10Level3Amount;
            Effect10Level4Amount = effect10Level4Amount;
            Effect10Level5Amount = effect10Level5Amount;
            Effect1Level0Amount = effect1Level0Amount;
            Effect1Level1Amount = effect1Level1Amount;
            Effect1Level2Amount = effect1Level2Amount;
            Effect1Level3Amount = effect1Level3Amount;
            Effect1Level4Amount = effect1Level4Amount;
            Effect1Level5Amount = effect1Level5Amount;
            Effect1Level6Amount = effect1Level6Amount;
            Effect2Level0Amount = effect2Level0Amount;
            Effect2Level1Amount = effect2Level1Amount;
            Effect2Level2Amount = effect2Level2Amount;
            Effect2Level3Amount = effect2Level3Amount;
            Effect2Level4Amount = effect2Level4Amount;
            Effect2Level5Amount = effect2Level5Amount;
            Effect2Level6Amount = effect2Level6Amount;
            Effect3Level0Amount = effect3Level0Amount;
            Effect3Level1Amount = effect3Level1Amount;
            Effect3Level2Amount = effect3Level2Amount;
            Effect3Level3Amount = effect3Level3Amount;
            Effect3Level4Amount = effect3Level4Amount;
            Effect3Level5Amount = effect3Level5Amount;
            Effect3Level6Amount = effect3Level6Amount;
            Effect4Level0Amount = effect4Level0Amount;
            Effect4Level1Amount = effect4Level1Amount;
            Effect4Level2Amount = effect4Level2Amount;
            Effect4Level3Amount = effect4Level3Amount;
            Effect4Level4Amount = effect4Level4Amount;
            Effect4Level5Amount = effect4Level5Amount;
            Effect4Level6Amount = effect4Level6Amount;
            Effect5Level0Amount = effect5Level0Amount;
            Effect5Level1Amount = effect5Level1Amount;
            Effect5Level2Amount = effect5Level2Amount;
            Effect5Level3Amount = effect5Level3Amount;
            Effect5Level4Amount = effect5Level4Amount;
            Effect5Level5Amount = effect5Level5Amount;
            Effect5Level6Amount = effect5Level6Amount;
            Effect6Level0Amount = effect6Level0Amount;
            Effect6Level1Amount = effect6Level1Amount;
            Effect6Level2Amount = effect6Level2Amount;
            Effect6Level3Amount = effect6Level3Amount;
            Effect6Level4Amount = effect6Level4Amount;
            Effect6Level5Amount = effect6Level5Amount;
            Effect6Level6Amount = effect6Level6Amount;
            Effect7Level0Amount = effect7Level0Amount;
            Effect7Level1Amount = effect7Level1Amount;
            Effect7Level2Amount = effect7Level2Amount;
            Effect7Level3Amount = effect7Level3Amount;
            Effect7Level4Amount = effect7Level4Amount;
            Effect7Level5Amount = effect7Level5Amount;
            Effect7Level6Amount = effect7Level6Amount;
            Effect8Level0Amount = effect8Level0Amount;
            Effect8Level1Amount = effect8Level1Amount;
            Effect8Level2Amount = effect8Level2Amount;
            Effect8Level3Amount = effect8Level3Amount;
            Effect8Level4Amount = effect8Level4Amount;
            Effect8Level5Amount = effect8Level5Amount;
            Effect8Level6Amount = effect8Level6Amount;
            Effect9Level0Amount = effect9Level0Amount;
            Effect9Level1Amount = effect9Level1Amount;
            Effect9Level2Amount = effect9Level2Amount;
            Effect9Level3Amount = effect9Level3Amount;
            Effect9Level4Amount = effect9Level4Amount;
            Effect9Level5Amount = effect9Level5Amount;
            Effect9Level6Amount = effect9Level6Amount;
            Flags = flags;
            FloatStaticsDecimals1 = floatStaticsDecimals1;
            FloatStaticsDecimals2 = floatStaticsDecimals2;
            FloatStaticsDecimals3 = floatStaticsDecimals3;
            FloatStaticsDecimals4 = floatStaticsDecimals4;
            FloatStaticsDecimals5 = floatStaticsDecimals5;
            FloatStaticsDecimals6 = floatStaticsDecimals6;
            FloatVarsDecimals1 = floatVarsDecimals1;
            FloatVarsDecimals2 = floatVarsDecimals2;
            FloatVarsDecimals3 = floatVarsDecimals3;
            FloatVarsDecimals4 = floatVarsDecimals4;
            FloatVarsDecimals5 = floatVarsDecimals5;
            FloatVarsDecimals6 = floatVarsDecimals6;
            HaveAfterEffect = haveAfterEffect;
            HaveHitBone = haveHitBone;
            HaveHitEffect = haveHitEffect;
            HavePointEffect = havePointEffect;
            HideRangeIndicatorWhenCasting = hideRangeIndicatorWhenCasting;
            HitBoneName = hitBoneName;
            HitEffectName = hitEffectName;
            HitEffectOrientType = hitEffectOrientType;
            HitEffectPlayerName = hitEffectPlayerName;
            ChannelDuration = channelDuration;
            ChannelDuration1 = channelDuration1;
            ChannelDuration2 = channelDuration2;
            ChannelDuration3 = channelDuration3;
            ChannelDuration4 = channelDuration4;
            ChannelDuration5 = channelDuration5;
            ChannelDuration6 = channelDuration6;
            ChargeUpdateInterval = chargeUpdateInterval;
            IgnoreAnimContinueUntilCastFrame = ignoreAnimContinueUntilCastFrame;
            IgnoreRangeCheck = ignoreRangeCheck;
            InventoryIcon = inventoryIcon;
            InventoryIcon1 = inventoryIcon1;
            InventoryIcon2 = inventoryIcon2;
            InventoryIcon3 = inventoryIcon3;
            IsDisabledWhileDead = isDisabledWhileDead;
            IsToggleSpell = isToggleSpell;
            Level1Desc = level1Desc;
            Level2Desc = level2Desc;
            Level3Desc = level3Desc;
            Level4Desc = level4Desc;
            Level5Desc = level5Desc;
            Level6Desc = level6Desc;
            LineDragLength = lineDragLength;
            LineMissileBounces = lineMissileBounces;
            LineMissileCollisionFromStartPoint = lineMissileCollisionFromStartPoint;
            LineMissileDelayDestroyAtEndSeconds = lineMissileDelayDestroyAtEndSeconds;
            LineMissileEndsAtTargetPoint = lineMissileEndsAtTargetPoint;
            LineMissileFollowsTerrainHeight = lineMissileFollowsTerrainHeight;
            LineMissileTargetHeightAugment = lineMissileTargetHeightAugment;
            LineMissileTimePulseBetweenCollisionSpellHits = lineMissileTimePulseBetweenCollisionSpellHits;
            LineMissileTrackUnits = lineMissileTrackUnits;
            LineMissileUsesAccelerationForBounce = lineMissileUsesAccelerationForBounce;
            LineTargetingBaseTextureOverrideName = lineTargetingBaseTextureOverrideName;
            LineTargetingTargetTextureOverrideName = lineTargetingTargetTextureOverrideName;
            LineWidth = lineWidth;
            LocationTargettingLength1 = locationTargettingLength1;
            LocationTargettingLength2 = locationTargettingLength2;
            LocationTargettingLength3 = locationTargettingLength3;
            LocationTargettingLength4 = locationTargettingLength4;
            LocationTargettingLength5 = locationTargettingLength5;
            LocationTargettingLength6 = locationTargettingLength6;
            LocationTargettingWidth1 = locationTargettingWidth1;
            LocationTargettingWidth2 = locationTargettingWidth2;
            LocationTargettingWidth3 = locationTargettingWidth3;
            LocationTargettingWidth4 = locationTargettingWidth4;
            LocationTargettingWidth5 = locationTargettingWidth5;
            LocationTargettingWidth6 = locationTargettingWidth6;
            LockConeToPlayer = lockConeToPlayer;
            LookAtPolicy = lookAtPolicy;
            LuaOnMissileUpdateDistanceInterval = luaOnMissileUpdateDistanceInterval;
            ManaCost = manaCost;
            ManaCost1 = manaCost1;
            ManaCost2 = manaCost2;
            ManaCost3 = manaCost3;
            ManaCost4 = manaCost4;
            ManaCost5 = manaCost5;
            ManaCost6 = manaCost6;
            Map10_Cooldown1 = map10Cooldown1;
            Map10_Cooldown2 = map10Cooldown2;
            Map10_Cooldown3 = map10Cooldown3;
            Map10_Cooldown4 = map10Cooldown4;
            Map10_Cooldown5 = map10Cooldown5;
            Map10_Effect1Level1Amount = map10Effect1Level1Amount;
            Map10_Effect1Level2Amount = map10Effect1Level2Amount;
            Map10_Effect1Level3Amount = map10Effect1Level3Amount;
            Map10_Effect2Level1Amount = map10Effect2Level1Amount;
            Map10_Effect2Level2Amount = map10Effect2Level2Amount;
            Map10_Effect2Level3Amount = map10Effect2Level3Amount;
            Map10_Effect2Level4Amount = map10Effect2Level4Amount;
            Map10_Effect2Level5Amount = map10Effect2Level5Amount;
            Map10_Effect4Level0Amount = map10Effect4Level0Amount;
            Map10_Effect4Level1Amount = map10Effect4Level1Amount;
            Map10_Effect4Level2Amount = map10Effect4Level2Amount;
            Map10_Effect4Level3Amount = map10Effect4Level3Amount;
            Map10_Effect4Level4Amount = map10Effect4Level4Amount;
            Map10_Effect4Level5Amount = map10Effect4Level5Amount;
            Map10_Effect4Level6Amount = map10Effect4Level6Amount;
            Map8_Cooldown1 = map8Cooldown1;
            Map8_Cooldown2 = map8Cooldown2;
            Map8_Cooldown3 = map8Cooldown3;
            Map8_Cooldown4 = map8Cooldown4;
            Map8_Cooldown5 = map8Cooldown5;
            MaxAmmo = maxAmmo;
            MaxGrowthRangeTextureName = maxGrowthRangeTextureName;
            MinimapIcon = minimapIcon;
            MinimapIconDisplayFlag = minimapIconDisplayFlag;
            MinimapIconRotation = minimapIconRotation;
            MissileAccel = missileAccel;
            MissileBoneName = missileBoneName;
            MissileEffect = missileEffect;
            MissileEffectPlayer = missileEffectPlayer;
            MissileFixedTravelTime = missileFixedTravelTime;
            MissileFollowsTerrainHeight = missileFollowsTerrainHeight;
            MissileGravity = missileGravity;
            MissileLifetime = missileLifetime;
            MissileMaxSpeed = missileMaxSpeed;
            MissileMinSpeed = missileMinSpeed;
            MissileMinTravelTime = missileMinTravelTime;
            MissilePerceptionBubbleRadius = missilePerceptionBubbleRadius;
            MissilePerceptionBubbleRevealsStealth = missilePerceptionBubbleRevealsStealth;
            MissileSpeed = missileSpeed;
            MissileTargetHeightAugment = missileTargetHeightAugment;
            MissileUnblockable = missileUnblockable;
            NumSpellTargeters = numSpellTargeters;
            OrientRadiusTextureFromPlayer = orientRadiusTextureFromPlayer;
            OrientRangeIndicatorToCursor = orientRangeIndicatorToCursor;
            OrientRangeIndicatorToFacing = orientRangeIndicatorToFacing;
            OverrideCastTime = overrideCastTime;
            ParticleStartOffset = particleStartOffset;
            PlatformEnabled = platformEnabled;
            PointEffectName = pointEffectName;
            RangeIndicatorTextureName = rangeIndicatorTextureName;
            SelectionPreference = selectionPreference;
            Sound_CastName = soundCastName;
            Sound_HitName = soundHitName;
            Sound_VOEventCategory = soundVoEventCategory;
            SpellCastTime = spellCastTime;
            SpellRevealsChampion = spellRevealsChampion;
            SpellTotalTime = spellTotalTime;
            StartCooldown = startCooldown;
            SubjectToGlobalCooldown = subjectToGlobalCooldown;
            TargeterConstrainedToRange = targeterConstrainedToRange;
            TargettingType = targettingType;
            TextFlags = textFlags;
            TriggersGlobalCooldown = triggersGlobalCooldown;
            UpdateRotationWhenCasting = updateRotationWhenCasting;
            UseAnimatorFramerate = useAnimatorFramerate;
            UseAutoattackCastTime = useAutoattackCastTime;
            UseGlobalLineIndicator = useGlobalLineIndicator;
            UseChargeChanneling = useChargeChanneling;
            UseChargeTargeting = useChargeTargeting;
            UseMinimapTargeting = useMinimapTargeting;
            Version = version;
            X1 = x1;
            X2 = x2;
            X3 = x3;
            X4 = x4;
            X5 = x5;
        }
    }
}
