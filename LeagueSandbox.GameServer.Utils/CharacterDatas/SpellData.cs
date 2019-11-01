using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    public class SpellData : ISpellData
    {
        public string Name { get; }
        public SpellFlags Flags { get; }
        public string TextFlags { get; }
        public IReadOnlyDictionary<int, float> CooldownTime { get; }
        public IReadOnlyDictionary<int, int> MaxAmmo { get; }
        public IReadOnlyDictionary<int, int> AmmoUsed { get; }
        public IReadOnlyDictionary<int, float> AmmoRechargeTime { get; }
        public IReadOnlyDictionary<int, float> ChannelDuration { get; }
        public IReadOnlyDictionary<int, float> CastRange { get; }
        public IReadOnlyDictionary<int, float> CastRangeGrowthMax { get; }
        public IReadOnlyDictionary<int, float> CastRangeGrowthDuration { get; }
        public IReadOnlyDictionary<int, float> CastRadius { get; }
        public IReadOnlyDictionary<int, float> CastRadiusSecondary { get; }
        public IReadOnlyDictionary<int, float> Mana { get; }
        public float SpellCastTime { get; }
        public float SpellTotalTime { get; }
        public float OverrideCastTime { get; }
        public float StartCooldown { get; }
        public float ChargeUpdateInterval { get; }
        public float CancelChargeOnRecastTime { get; }
        public float CastConeAngle { get; }
        public float CastConeDistance { get; }
        public float CastTargetAdditionalUnitsRadius { get; }
        public CastType CastType { get; }
        public float CastFrame { get; }
        public float LineWidth { get; }
        public float LineDragLength { get; }
        public LookAtPolicy LookAtPolicy { get; }
        public SelectionPreference SelectionPreference { get; }
        public TargetingType TargetingType { get; }
        public bool CastRangeUseBoundingBoxes { get; }
        public bool AmmoNotAffectedByCDR { get; }
        public bool UseAutoattackCastTime { get; }
        public bool IgnoreAnimContinueUntilCastFrame { get; }
        public bool IsToggleSpell { get; }
        public bool CanNotBeSuppressed { get; }
        public bool CanCastWhileDisabled { get; }
        public bool CanOnlyCastWhileDisabled { get; }
        public bool CantCancelWhileWindingUp { get; }
        public bool CantCancelWhileChanneling { get; }
        public bool CantCastWhileRooted { get; }
        public bool DoesntBreakChannels { get; }
        public bool IsDisabledWhileDead { get; }
        public bool CanOnlyCastWhileDead { get; }
        public bool SpellRevealsChampion { get; }
        public bool UseChargeChanneling { get; }
        public bool UseChargeTargeting { get; }
        public bool CanMoveWhileChanneling { get; }
        public bool DoNotNeedToFaceTarget { get; }
        public bool NoWinddownIfCancelled { get; }
        public bool IgnoreRangeCheck { get; }
        public bool ConsideredAsAutoAttack { get; }
        public bool ApplyAttackDamage { get; }
        public bool ApplyAttackEffect { get; }
        public bool AlwaysSnapFacing { get; }
        public bool BelongsToAvatar { get; }

        //[JsonConverter(typeof(CastDataConverter))]
        public ICastData CastData { get; }

        public SpellData(string name, SpellFlags flags, string textFlags, IReadOnlyDictionary<int, float> cooldownTime, IReadOnlyDictionary<int, int> maxAmmo, IReadOnlyDictionary<int, int> ammoUsed, IReadOnlyDictionary<int, float> ammoRechargeTime, IReadOnlyDictionary<int, float> channelDuration, IReadOnlyDictionary<int, float> castRange, IReadOnlyDictionary<int, float> castRangeGrowthMax, IReadOnlyDictionary<int, float> castRangeGrowthDuration, IReadOnlyDictionary<int, float> castRadius, IReadOnlyDictionary<int, float> castRadiusSecondary, IReadOnlyDictionary<int, float> mana, float spellCastTime, float spellTotalTime, float overrideCastTime, float startCooldown, float chargeUpdateInterval, float cancelChargeOnRecastTime, float castConeAngle, float castConeDistance, float castTargetAdditionalUnitsRadius, CastType castType, float castFrame, float lineWidth, float lineDragLength, LookAtPolicy lookAtPolicy, SelectionPreference selectionPreference, TargetingType targetingType, bool castRangeUseBoundingBoxes, bool ammoNotAffectedByCdr, bool useAutoattackCastTime, bool ignoreAnimContinueUntilCastFrame, bool isToggleSpell, bool canNotBeSuppressed, bool canCastWhileDisabled, bool canOnlyCastWhileDisabled, bool cantCancelWhileWindingUp, bool cantCancelWhileChanneling, bool cantCastWhileRooted, bool doesntBreakChannels, bool isDisabledWhileDead, bool canOnlyCastWhileDead, bool spellRevealsChampion, bool useChargeChanneling, bool useChargeTargeting, bool canMoveWhileChanneling, bool doNotNeedToFaceTarget, bool noWinddownIfCancelled, bool ignoreRangeCheck, bool consideredAsAutoAttack, bool applyAttackDamage, bool applyAttackEffect, bool alwaysSnapFacing, bool belongsToAvatar, ICastData castData)
        {
            Name = name;
            Flags = flags;
            TextFlags = textFlags;
            CooldownTime = cooldownTime;
            MaxAmmo = maxAmmo;
            AmmoUsed = ammoUsed;
            AmmoRechargeTime = ammoRechargeTime;
            ChannelDuration = channelDuration;
            CastRange = castRange;
            CastRangeGrowthMax = castRangeGrowthMax;
            CastRangeGrowthDuration = castRangeGrowthDuration;
            CastRadius = castRadius;
            CastRadiusSecondary = castRadiusSecondary;
            Mana = mana;
            SpellCastTime = spellCastTime;
            SpellTotalTime = spellTotalTime;
            OverrideCastTime = overrideCastTime;
            StartCooldown = startCooldown;
            ChargeUpdateInterval = chargeUpdateInterval;
            CancelChargeOnRecastTime = cancelChargeOnRecastTime;
            CastConeAngle = castConeAngle;
            CastConeDistance = castConeDistance;
            CastTargetAdditionalUnitsRadius = castTargetAdditionalUnitsRadius;
            CastType = castType;
            CastFrame = castFrame;
            LineWidth = lineWidth;
            LineDragLength = lineDragLength;
            LookAtPolicy = lookAtPolicy;
            SelectionPreference = selectionPreference;
            TargetingType = targetingType;
            CastRangeUseBoundingBoxes = castRangeUseBoundingBoxes;
            AmmoNotAffectedByCDR = ammoNotAffectedByCdr;
            UseAutoattackCastTime = useAutoattackCastTime;
            IgnoreAnimContinueUntilCastFrame = ignoreAnimContinueUntilCastFrame;
            IsToggleSpell = isToggleSpell;
            CanNotBeSuppressed = canNotBeSuppressed;
            CanCastWhileDisabled = canCastWhileDisabled;
            CanOnlyCastWhileDisabled = canOnlyCastWhileDisabled;
            CantCancelWhileWindingUp = cantCancelWhileWindingUp;
            CantCancelWhileChanneling = cantCancelWhileChanneling;
            CantCastWhileRooted = cantCastWhileRooted;
            DoesntBreakChannels = doesntBreakChannels;
            IsDisabledWhileDead = isDisabledWhileDead;
            CanOnlyCastWhileDead = canOnlyCastWhileDead;
            SpellRevealsChampion = spellRevealsChampion;
            UseChargeChanneling = useChargeChanneling;
            UseChargeTargeting = useChargeTargeting;
            CanMoveWhileChanneling = canMoveWhileChanneling;
            DoNotNeedToFaceTarget = doNotNeedToFaceTarget;
            NoWinddownIfCancelled = noWinddownIfCancelled;
            IgnoreRangeCheck = ignoreRangeCheck;
            ConsideredAsAutoAttack = consideredAsAutoAttack;
            ApplyAttackDamage = applyAttackDamage;
            ApplyAttackEffect = applyAttackEffect;
            AlwaysSnapFacing = alwaysSnapFacing;
            BelongsToAvatar = belongsToAvatar;
            CastData = castData;
        }
    }
}
