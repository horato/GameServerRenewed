using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.RequestProcessing.DTOs;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C;
using CompressedWaypoint = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.CompressedWaypoint;
using MovementData = LeagueSandbox.GameServer.Core.RequestProcessing.DTOs.MovementData;

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
                _enumTranslationService.TranslateSummonerSpell(player.Champion.SummonerSpell1),
                _enumTranslationService.TranslateSummonerSpell(player.Champion.SummonerSpell2),
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
                movementData.TeleportNetID,
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

        public IEnumerable<MovementDataNormal> TranslateMovementUpdate(IEnumerable<IGameObject> gameObjects, int syncId, Vector2 mapCenter)
        {
            foreach (var gameObject in gameObjects)
            {
                yield return new MovementDataNormal
                (
                    syncId,
                    0,
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
    }
}
