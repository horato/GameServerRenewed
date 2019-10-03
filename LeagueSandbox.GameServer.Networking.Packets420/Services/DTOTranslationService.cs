using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.Hashing;
using LeagueSandbox.GameServer.Core.RequestProcessing.DTOs;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;
using CompressedWaypoint = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.CompressedWaypoint;
using MovementData = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.MovementData;
using SpellSlot = LeagueSandbox.GameServer.Core.Domain.Enums.SpellSlot;

namespace LeagueSandbox.GameServer.Networking.Packets420.Services
{
    internal class DTOTranslationService : IDTOTranslationService
    {
        private readonly IEnumTranslationService _enumTranslationService;
        private readonly ICoordinatesTranslationService _coordinatesTranslationService;

        public DTOTranslationService(IEnumTranslationService enumTranslationService, ICoordinatesTranslationService coordinatesTranslationService)
        {
            _enumTranslationService = enumTranslationService;
            _coordinatesTranslationService = coordinatesTranslationService;
        }

        public PlayerLoadInfo TranslatePlayerLoadInfo(IPlayer player)
        {
            return new PlayerLoadInfo
            (
                player.SummonerId,
                checked((ushort)player.SummonerLevel),
                player.Champion.SpellBook.GetSpell(SpellSlot.D).SpellName,
                player.Champion.SpellBook.GetSpell(SpellSlot.F).SpellName,
                108,
                _enumTranslationService.TranslateTeam(player.Champion.Team),
                "", //TODO: Bot
                "", //TODO: Bot
                _enumTranslationService.TranslateRank(player.Rank),
                0, //TODO: Bot
                0, //TODO: Bot
                player.Icon,
                player.BadgeAlly,
                player.BadgeEnemy
            );
        }

        public MovementData TranslateMovementData(MovementDataNormal movementData)
        {
            if (movementData == null)
                return null; // Not throw; null is valid business case

            return new MovementData
            (
                movementData.UnitNetId,
                movementData.HasTeleportID,
                movementData.TeleportID,
                movementData.SyncID,
                TranslateWaypoints(movementData.Waypoints).ToList()
            );
        }

        private IEnumerable<CompressedWaypoint> TranslateWaypoints(IList<PacketDefinitions.Common.CompressedWaypoint> waypoints)
        {
            var idx = 0;
            return waypoints.Select(x => new CompressedWaypoint(idx++, new Vector2(x.X, x.Y))).ToList();
        }

        public IEnumerable<MovementDataNormal> TranslateMovementUpdate(IEnumerable<IGameObject> gameObjects, uint syncId, Vector2 mapCenter)
        {
            foreach (var gameObject in gameObjects)
            {
                yield return new MovementDataNormal
                (
                    syncId,
                    gameObject.NetId,
                    false,
                    0,
                    TranslateGameObjectWaypoints(gameObject, mapCenter).ToList()
                );
            }
        }

        private IEnumerable<PacketDefinitions.Common.CompressedWaypoint> TranslateGameObjectWaypoints(IGameObject gameObject, Vector2 mapCenter)
        {
            var idx = 0;
            var translatedVector = _coordinatesTranslationService.TranslateMapVectorToCompressedVector(idx++, gameObject.Position.ToVector2(), mapCenter);
            yield return TranslateToPacketCompressedWaypoint(translatedVector);

            if (gameObject is IObjAiBase aiBase)
            {
                foreach (var waypoint in aiBase.Waypoints.Take(0x7F - 1))
                {
                    var translatedWaypoint = _coordinatesTranslationService.TranslateMapVectorToCompressedVector(idx++, waypoint, mapCenter);
                    yield return TranslateToPacketCompressedWaypoint(translatedWaypoint);
                }
            }
        }

        private PacketDefinitions.Common.CompressedWaypoint TranslateToPacketCompressedWaypoint(CompressedWaypoint translatedVector)
        {
            return new PacketDefinitions.Common.CompressedWaypoint(checked((short)translatedVector.Position.X), checked((short)translatedVector.Position.Y));
        }

        public IEnumerable<ReplicationData> TranslateReplicationData(IEnumerable<IAttackableUnit> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                IDictionary<MasterMask, IDictionary<Enum, object>> replicationData;
                switch (gameObject)
                {
                    case IObjAiHero _:
                        replicationData = TranslateChampionStats(gameObject.Stats);
                        break;
                    case IObjAnimatedBuilding _:
                        replicationData = TranslateAnimatedBuildingStats(gameObject.Stats);
                        break;
                    case IObjAiTurret _:
                        replicationData = TranslateTurretStats(gameObject.Stats);
                        break;
                    case IObjAiMinion _:
                        replicationData = TranslateMinionStats(gameObject.Stats);
                        break;
                    case ILevelPropAI _:
                    case IObjAiBase _:
                    case IObjShop _:
                    case IObjSpawnPoint _:
                    case IObjBuilding _:
                        throw new InvalidOperationException($"Game object {gameObject} doesn't replicate.");
                    default:
                        throw new ArgumentOutOfRangeException(nameof(gameObject), gameObject, null);
                }

                yield return new ReplicationData
                (
                    gameObject.NetId,
                    replicationData
                );
            }
        }

        private IDictionary<MasterMask, IDictionary<Enum, object>> TranslateChampionStats(IStats stats)
        {
            var mm1 = new Dictionary<Enum, object>();
            var mm2 = new Dictionary<Enum, object>();
            var mm3 = new Dictionary<Enum, object>();
            var mm4 = new Dictionary<Enum, object>();
            var mm5 = new Dictionary<Enum, object>();
            var mm6 = new Dictionary<Enum, object>();

            if (stats.AbilityPower.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_AbilityPowerBase, stats.AbilityPower.BaseValue);
                mm2.Add(ObjAiHeroFieldMask.FM2_AbilityPowerBonusFlat, stats.AbilityPower.FlatBonus);
            }

            if (stats.Armor.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_ArmorTotal, stats.Armor.Total);
                mm3.Add(ObjAiHeroFieldMask.FM3_ArmorBonusPercent, stats.Armor.PercentBonus);
            }

            if (stats.ArmorPenetration.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_ArmorPenetrationBonusFlat, stats.ArmorPenetration.FlatBonus);
                mm2.Add(ObjAiHeroFieldMask.FM2_ArmorPenetrationBonusPercent, stats.ArmorPenetration.PercentBonus);
            }

            if (stats.AttackDamage.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_AttackDamageBase, stats.AttackDamage.BaseValue);
                mm2.Add(ObjAiHeroFieldMask.FM2_AttackDamageBonusFlat, stats.AttackDamage.FlatBonus);
                mm2.Add(ObjAiHeroFieldMask.FM2_AttackDamageBonusPercent, stats.AttackDamage.PercentBonus);
            }

            if (stats.AttackSpeedMultiplier.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_AttackSpeedMultiplierTotal, stats.AttackSpeedMultiplier.Total);
            }

            if (stats.CooldownReduction.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_CooldownReductionTotal, stats.CooldownReduction.Total);
            }

            if (stats.CriticalChance.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_CritChanceTotal, stats.CriticalChance.Total);
            }

            if (stats.CriticalDamage.IsUpdated)
            {
                // Nothing
            }

            if (stats.HealthPoints.IsUpdated)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_HealthTotal, stats.HealthPoints.Total);
            }

            if (stats.HealthRegeneration.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_HealthRegenerationTotal, stats.HealthRegeneration.Total);
                mm3.Add(ObjAiHeroFieldMask.FM3_HealthRegenerationBonusPercent, stats.HealthRegeneration.PercentBonus);
            }

            if (stats.LifeSteal.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_LifeStealTotal, stats.LifeSteal.Total);
            }

            if (stats.MagicResist.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_MagicResistTotal, stats.MagicResist.Total);
                mm2.Add(ObjAiHeroFieldMask.FM2_MagicResistBonusFlat, stats.MagicResist.FlatBonus);
                mm2.Add(ObjAiHeroFieldMask.FM2_MagicResistBonusPercent, stats.MagicResist.PercentBonus);
            }

            if (stats.MagicPenetration.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_MagicPenetrationBonusFlat, stats.MagicPenetration.FlatBonus);
                mm2.Add(ObjAiHeroFieldMask.FM2_MagicPenetrationBonusPercent, stats.MagicPenetration.PercentBonus);
                mm3.Add(ObjAiHeroFieldMask.FM3_MagicPenetrationBonusPercent, stats.MagicPenetration.PercentBonus);
            }

            if (stats.ManaPoints.IsUpdated)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_ManaTotal, stats.ManaPoints.Total);
            }

            if (stats.ManaRegeneration.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_ManaRegenerationTotal, stats.ManaRegeneration.Total);
                mm3.Add(ObjAiHeroFieldMask.FM3_ManaRegenerationBonusPercent, stats.ManaRegeneration.PercentBonus);
            }

            if (stats.MoveSpeed.IsUpdated)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_MoveSpeedTotal, stats.MoveSpeed.Total);
            }

            if (stats.Range.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_AttackRangeTotal, stats.Range.Total);
                mm2.Add(ObjAiHeroFieldMask.FM2_AttackRangeBonusFlat, stats.Range.FlatBonus);
            }

            if (stats.Size.IsUpdated)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_SizeTotal, stats.Size.Total);
            }

            if (stats.SpellVamp.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_SpellVampTotal, stats.SpellVamp.Total);
            }

            if (stats.Tenacity.IsUpdated)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_TenacityTotal, stats.Tenacity.Total);
            }

            if (stats.SpellsModified)
            {
                var enabledSpells = _enumTranslationService.TranslateSpellSlotForStatsUpdate(stats.SpellsEnabled);
                mm1.Add(ObjAiHeroFieldMask.FM1_Spells_Enabled_Lower, (uint)enabledSpells);
                mm1.Add(ObjAiHeroFieldMask.FM1_Spells_Enabled_Upper, (uint)enabledSpells >> 32); //?

                var enabledSummonerSpells = _enumTranslationService.TranslateSpellSlotSummonerForStatsUpdate(stats.SpellsEnabled);
                mm1.Add(ObjAiHeroFieldMask.FM1_SummonerSpells_Enabled_Lower, (uint)enabledSummonerSpells);
                mm1.Add(ObjAiHeroFieldMask.FM1_SummonerSpells_Enabled_Upper, (uint)enabledSummonerSpells >> 32); //?
            }

            if (stats.IsTargetableToTeamModified)
            {
                var flags = _enumTranslationService.TranslateSpellFlags(stats.IsTargetableToTeam);
                mm4.Add(ObjAiHeroFieldMask.FM4_IsTargetableToTeam, (uint)flags);
            }

            if (stats.ActionStateModfied)
            {
                var state = _enumTranslationService.TranslateActionState(stats.ActionState);
                mm2.Add(ObjAiHeroFieldMask.FM2_ActionState, (uint)state);
            }

            if (stats.ParTypeModified)
            {
                // Nothing
            }

            if (stats.IsMagicImmuneIsModified)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_MagicImmune, stats.IsMagicImmune);
            }

            if (stats.IsInvulnerableIsModified)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_Invulnerable, stats.IsInvulnerable);
            }

            if (stats.IsPhysicalImmuneIsModified)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_PhysicalImmune, stats.IsPhysicalImmune);
            }

            if (stats.IsLifestealImmuneIsModified)
            {
                mm2.Add(ObjAiHeroFieldMask.FM2_LifestealImmune, stats.IsLifestealImmune);
            }

            if (stats.IsTargetableIsModified)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_IsTargetable, stats.IsTargetable);
            }

            if (stats.IsManaCostChanged)
            {
                mm1.Add(ObjAiHeroFieldMask.FM1_ManaCost_Q, stats.GetManaCost(SpellSlot.Q));
                mm1.Add(ObjAiHeroFieldMask.FM1_ManaCost_W, stats.GetManaCost(SpellSlot.W));
                mm1.Add(ObjAiHeroFieldMask.FM1_ManaCost_E, stats.GetManaCost(SpellSlot.E));
                mm1.Add(ObjAiHeroFieldMask.FM1_ManaCost_R, stats.GetManaCost(SpellSlot.R));
            }

            if (stats.FlatAttackSpeed.IsUpdated)
            {
                // Nothing
            }

            if (stats.FlatHealthPoints.IsUpdated)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_HealthCurrent, stats.FlatHealthPoints.CurrentValue);
            }

            if (stats.FlatManaPoints.IsUpdated)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_ManaCurrent, stats.FlatManaPoints.CurrentValue);
            }

            if (stats.FlatAttackDamage.IsUpdated)
            {
                // Nothing
            }

            if (stats.FlatArmor.IsUpdated)
            {
                // Nothing
            }

            if (stats.FlatMagicResist.IsUpdated)
            {
                // Nothing
            }

            if (stats.Gold.IsUpdated)
            {
                mm1.Add(ObjAiHeroFieldMask.FM1_Gold, stats.Gold.CurrentValue);
                mm1.Add(ObjAiHeroFieldMask.FM1_Gold_Total, stats.GoldTotal);
            }

            if (stats.Level.IsUpdated)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_ChampionLevel, stats.Level.CurrentValue);
            }

            if (stats.Experience.IsUpdated)
            {
                mm4.Add(ObjAiHeroFieldMask.FM4_Experience, stats.Experience.CurrentValue);
            }

            var result = new Dictionary<MasterMask, IDictionary<Enum, object>>();

            if (mm1.Any())
                result.Add(MasterMask.One, mm1);
            if (mm2.Any())
                result.Add(MasterMask.Two, mm2);
            if (mm3.Any())
                result.Add(MasterMask.Three, mm3);
            if (mm4.Any())
                result.Add(MasterMask.Four, mm4);
            if (mm5.Any())
                result.Add(MasterMask.Five, mm5);
            if (mm6.Any())
                result.Add(MasterMask.Six, mm6);

            return result;
        }

        private IDictionary<MasterMask, IDictionary<Enum, object>> TranslateAnimatedBuildingStats(IStats stats)
        {
            var mm1 = new Dictionary<Enum, object>();
            var mm2 = new Dictionary<Enum, object>();
            var mm3 = new Dictionary<Enum, object>();
            var mm4 = new Dictionary<Enum, object>();
            var mm5 = new Dictionary<Enum, object>();
            var mm6 = new Dictionary<Enum, object>();

            if (stats.FlatHealthPoints.IsUpdated)
            {
                mm2.Add(ObjAnimatedBuildingFieldMask.FM2_HealthCurrent, stats.FlatHealthPoints.CurrentValue);
            }

            if (stats.IsInvulnerableIsModified)
            {
                mm2.Add(ObjAnimatedBuildingFieldMask.FM2_Invulnerable, stats.IsInvulnerable);
            }

            if (stats.IsTargetableIsModified)
            {
                mm6.Add(ObjAnimatedBuildingFieldMask.FM6_IsTargetable, stats.IsTargetable);
            }

            if (stats.IsTargetableToTeamModified)
            {
                var flags = _enumTranslationService.TranslateSpellFlags(stats.IsTargetableToTeam);
                mm6.Add(ObjAnimatedBuildingFieldMask.FM6_IsTargetableToTeam, (uint)flags);
            }

            var result = new Dictionary<MasterMask, IDictionary<Enum, object>>();

            if (mm1.Any())
                result.Add(MasterMask.One, mm1);
            if (mm2.Any())
                result.Add(MasterMask.Two, mm2);
            if (mm3.Any())
                result.Add(MasterMask.Three, mm3);
            if (mm4.Any())
                result.Add(MasterMask.Four, mm4);
            if (mm5.Any())
                result.Add(MasterMask.Five, mm5);
            if (mm6.Any())
                result.Add(MasterMask.Six, mm6);

            return result;
        }

        private IDictionary<MasterMask, IDictionary<Enum, object>> TranslateTurretStats(IStats stats)
        {
            var mm1 = new Dictionary<Enum, object>();
            var mm2 = new Dictionary<Enum, object>();
            var mm3 = new Dictionary<Enum, object>();
            var mm4 = new Dictionary<Enum, object>();
            var mm5 = new Dictionary<Enum, object>();
            var mm6 = new Dictionary<Enum, object>();

            if (stats.ManaPoints.IsUpdated)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_ManaTotal, stats.ManaPoints.Total);
            }

            if (stats.FlatManaPoints.IsUpdated)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_ManaCurrent, stats.FlatManaPoints.CurrentValue);
            }

            if (stats.ActionStateModfied)
            {
                var state = _enumTranslationService.TranslateActionState(stats.ActionState);
                mm2.Add(ObjAiTurretFieldMask.FM2_ActionState, (uint)state);
            }

            if (stats.IsMagicImmuneIsModified)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_MagicImmune, stats.IsMagicImmune);
            }

            if (stats.IsInvulnerableIsModified)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_Invulnerable, stats.IsInvulnerable);
            }

            if (stats.IsPhysicalImmuneIsModified)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_PhysicalImmune, stats.IsPhysicalImmune);
            }

            if (stats.IsLifestealImmuneIsModified)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_LifestealImmune, stats.IsLifestealImmune);
            }

            if (stats.AttackDamage.IsUpdated)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_AttackDamageBase, stats.AttackDamage.BaseValue);
                mm2.Add(ObjAiTurretFieldMask.FM2_AttackDamageBonusFlat, stats.AttackDamage.FlatBonus);
                mm2.Add(ObjAiTurretFieldMask.FM2_AttackDamageBonusPercent, stats.AttackDamage.PercentBonus);
            }

            if (stats.Armor.IsUpdated)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_ArmorTotal, stats.Armor.Total);
            }

            if (stats.MagicResist.IsUpdated)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_MagicResistTotal, stats.MagicResist.Total);
            }

            if (stats.AttackSpeedMultiplier.IsUpdated)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_AttackSpeedMultiplierTotal, stats.AttackSpeedMultiplier.Total);
            }

            if (stats.AbilityPower.IsUpdated)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_AbilityPowerTotal, stats.AbilityPower.Total);
            }

            if (stats.HealthRegeneration.IsUpdated)
            {
                mm2.Add(ObjAiTurretFieldMask.FM2_HealthRegenerationTotal, stats.HealthRegeneration.Total);
            }

            if (stats.FlatHealthPoints.IsUpdated)
            {
                mm4.Add(ObjAiTurretFieldMask.FM4_HealthCurrent, stats.FlatHealthPoints.CurrentValue);
            }

            if (stats.HealthPoints.IsUpdated)
            {
                mm4.Add(ObjAiTurretFieldMask.FM4_HealthTotal, stats.HealthPoints.Total);
            }

            if (stats.MoveSpeed.IsUpdated)
            {
                mm4.Add(ObjAiTurretFieldMask.FM4_MoveSpeedTotal, stats.MoveSpeed.Total);
            }

            if (stats.Size.IsUpdated)
            {
                mm4.Add(ObjAiTurretFieldMask.FM4_SizeTotal, stats.Size.Total);
            }

            if (stats.IsTargetableIsModified)
            {
                mm6.Add(ObjAiTurretFieldMask.FM6_IsTargetable, stats.IsTargetable);
            }

            if (stats.IsTargetableToTeamModified)
            {
                var flags = _enumTranslationService.TranslateSpellFlags(stats.IsTargetableToTeam);
                mm6.Add(ObjAiTurretFieldMask.FM6_IsTargetableToTeam, (uint)flags);
            }

            var result = new Dictionary<MasterMask, IDictionary<Enum, object>>();

            if (mm1.Any())
                result.Add(MasterMask.One, mm1);
            if (mm2.Any())
                result.Add(MasterMask.Two, mm2);
            if (mm3.Any())
                result.Add(MasterMask.Three, mm3);
            if (mm4.Any())
                result.Add(MasterMask.Four, mm4);
            if (mm5.Any())
                result.Add(MasterMask.Five, mm5);
            if (mm6.Any())
                result.Add(MasterMask.Six, mm6);

            return result;
        }

        private IDictionary<MasterMask, IDictionary<Enum, object>> TranslateMinionStats(IStats stats)
        {
            var mm1 = new Dictionary<Enum, object>();
            var mm2 = new Dictionary<Enum, object>();
            var mm3 = new Dictionary<Enum, object>();
            var mm4 = new Dictionary<Enum, object>();
            var mm5 = new Dictionary<Enum, object>();
            var mm6 = new Dictionary<Enum, object>();

            if (stats.HealthPoints.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_HealthCurrent, stats.FlatHealthPoints.CurrentValue);
            }

            if (stats.HealthPoints.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_HealthTotal, stats.HealthPoints.Total);
            }

            if (stats.ManaPoints.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_ManaTotal, stats.ManaPoints.Total);
            }

            if (stats.FlatManaPoints.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_ManaCurrent, stats.FlatManaPoints.CurrentValue);
            }

            if (stats.ActionStateModfied)
            {
                var state = _enumTranslationService.TranslateActionState(stats.ActionState);
                mm2.Add(ObjAiMinionFieldMask.FM2_ActionState, (uint)state);
            }

            if (stats.IsMagicImmuneIsModified)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_IsMagicImmune, stats.IsMagicImmune);
            }

            if (stats.IsInvulnerableIsModified)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_IsInvulnerable, stats.IsInvulnerable);
            }

            if (stats.IsPhysicalImmuneIsModified)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_IsPhysicalImmune, stats.IsPhysicalImmune);
            }

            if (stats.IsLifestealImmuneIsModified)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_IsLifestealImmune, stats.IsLifestealImmune);
            }

            if (stats.AttackDamage.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_AttackDamageBase, stats.AttackDamage.BaseValue);
                mm2.Add(ObjAiMinionFieldMask.FM2_AttackDamageBonusFlat, stats.AttackDamage.FlatBonus);
                mm2.Add(ObjAiMinionFieldMask.FM2_AttackDamageBonusPercent, stats.AttackDamage.PercentBonus);
            }

            if (stats.Armor.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_ArmorTotal, stats.Armor.Total);
            }

            if (stats.MagicResist.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_MagicResistTotal, stats.MagicResist.Total);
                mm2.Add(ObjAiMinionFieldMask.FM2_MagicResistBonusFlat, stats.MagicResist.FlatBonus);
                mm2.Add(ObjAiMinionFieldMask.FM2_MagicResistBonusPercent, stats.MagicResist.PercentBonus);
            }

            if (stats.AttackSpeedMultiplier.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_AttackSpeedMultiplierTotal, stats.AttackSpeedMultiplier.Total);
            }

            if (stats.AbilityPower.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_AbilityPowerTotal, stats.AbilityPower.Total);
            }

            if (stats.HealthRegeneration.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_HealthRegenerationTotal, stats.HealthRegeneration.Total);
            }

            if (stats.ManaRegeneration.IsUpdated)
            {
                mm2.Add(ObjAiMinionFieldMask.FM2_ManaRegenerationTotal, stats.ManaRegeneration.Total);
            }

            if (stats.MoveSpeed.IsUpdated)
            {
                mm4.Add(ObjAiMinionFieldMask.FM4_MoveSpeedTotal, stats.MoveSpeed.Total);
            }

            if (stats.Size.IsUpdated)
            {
                mm4.Add(ObjAiMinionFieldMask.FM4_SizeTotal, stats.Size.Total);
            }

            if (stats.IsTargetableIsModified)
            {
                mm4.Add(ObjAiMinionFieldMask.FM4_IsTargetable, stats.IsTargetable);
            }

            if (stats.IsTargetableToTeamModified)
            {
                var flags = _enumTranslationService.TranslateSpellFlags(stats.IsTargetableToTeam);
                mm4.Add(ObjAiMinionFieldMask.FM4_IsTargetableToTeam, (uint)flags);
            }

            var result = new Dictionary<MasterMask, IDictionary<Enum, object>>();

            if (mm1.Any())
                result.Add(MasterMask.One, mm1);
            if (mm2.Any())
                result.Add(MasterMask.Two, mm2);
            if (mm3.Any())
                result.Add(MasterMask.Three, mm3);
            if (mm4.Any())
                result.Add(MasterMask.Four, mm4);
            if (mm5.Any())
                result.Add(MasterMask.Five, mm5);
            if (mm6.Any())
                result.Add(MasterMask.Six, mm6);

            return result;
        }

        public CastInfo TranslateCastInfo(IObjAiBase caster, ISpellInstance spell)
        {
            var slot = _enumTranslationService.TranslateSpellSlot(spell.Definition.Slot);
            return new CastInfo
            (
                ElfHash.CalculateSpellNameHash(spell.Definition.SpellName),
                spell.InstanceNetId,
                checked((byte)(spell.Definition.Level)),
                caster.Stats.AttackSpeedMultiplier.Total,
                caster.NetId,
                caster.NetId,
                SdbmHash.HashCharacterName(caster.SkinName, caster.SkinId),
                spell.FutureProjectileNetId,
                spell.TargetPosition.ToVector3(0), // TODO: take these from navgrid?
                spell.TargetEndPosition.ToVector3(0), // TODO: take these from navgrid?
                spell.Target != null ? new List<Target> { new Target(spell.Target.NetId, HitResult.Normal) } : new List<Target>(), //TODO: hit result
                spell.Definition.CastTime,
                0,
                spell.Definition.CastTime,
                spell.Definition.Cooldown,
                0, //TODO: game time?
                false, // TODO: auto attack
                false, // TODO: auto attack
                spell.Definition.ChannelDuration > 0, //TODO: force cast?
                false,
                spell.Definition.TargetingType == TargetingType.Target,
                slot,
                spell.ActualManaCost,
                caster.Position,
                spell.Definition.AmmoUsed,
                spell.Definition.AmmoRechargeTime
            );
        }
    }
}
