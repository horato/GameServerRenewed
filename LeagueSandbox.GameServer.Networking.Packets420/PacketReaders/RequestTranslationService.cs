using System;
using System.Numerics;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S;
using LeagueSandbox.GameServer.Networking.Packets420.Services;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketReaders
{
    internal class RequestTranslationService : IRequestTranslationService
    {
        private readonly IEnumTranslationService _enumTranslationService;
        private readonly IDTOTranslationService _dTOTranslationService;

        public RequestTranslationService(IEnumTranslationService enumTranslationService, IDTOTranslationService dToTranslationService)
        {
            _enumTranslationService = enumTranslationService;
            _dTOTranslationService = dToTranslationService;
        }

        public IRequestDefinition TranslateRequest(IRequestPacketDefinition request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            switch (request)
            {
                case KeyCheckRequest keyCheckRequest:
                    return TranslateKeyCheckRequest(keyCheckRequest);
                case QueryStatusRequest queryStatusRequest:
                    return TranslateQueryStatusRequest(queryStatusRequest);
                case SynchVersionRequest synchVersionRequest:
                    return TranslateSynchVersion(synchVersionRequest);
                case PingLoadInfoRequest pingLoadInfoRequest:
                    return TranslatePingLoadInfoRequest(pingLoadInfoRequest);
                case JoinTeamRequest joinTeamRequest:
                    return TranslateJoinTeamRequest(joinTeamRequest);
                case CharSelectedRequest charSelectedRequest:
                    return TranslateCharSelectedRequest(charSelectedRequest);
                case ClientReady clientReady:
                    return TranslateClientReadyRequest(clientReady);
                case WorldSendCameraRequest worldSendCameraRequest:
                    return TranslateWorldSendCameraRequest(worldSendCameraRequest);
                case MapPingRequest mapPingRequest:
                    return TranslateMapPingRequest(mapPingRequest);
                case IssueOrderRequest issueOrderRequest:
                    return TranslateIssueOrder(issueOrderRequest);
                case WaypointAccRequest waypointAccRequest:
                    return TranslateWaypointAccRequest(waypointAccRequest);
                case ReplicationConfirmRequest replicationConfirmRequest:
                    return TranslateReplicationConfirmRequest(replicationConfirmRequest);
                case SkillUpRequest skillUpRequest:
                    return TranslateSkillUpRequest(skillUpRequest);
                case CastSpellRequest castSpellRequest:
                    return TranslateCastSpellRequest(castSpellRequest);
                case SynchSimTimeRequest synchSimTimeRequest:
                    return TranslateSynchSimTimeRequest(synchSimTimeRequest);
                case AutoAttackOption autoAttackOption:
                case BasicTutorialMessageWindowClicked basicTutorialMessageWindowClicked:
                case BlueTipClicked blueTipClicked:
                case BuyItemRequest buyItemRequest:
                case Click click:
                case CursorPositionOnWorld cursorPositionOnWorld:
                case EmotionPacketRequest emotionPacketRequest:
                case ChatMessage chatMessage:
                case QuestClicked questClicked:
                case SellItem sellItem:
                case SwapItemsRequest swapItemsRequest:
                case UseObject useObject:
                default:
                    throw new ArgumentOutOfRangeException(nameof(request), request, "Unknown packet request type.");
            }
        }

        private GameServer.Core.RequestProcessing.Definitions.CharSelectedRequest TranslateCharSelectedRequest(CharSelectedRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.CharSelectedRequest();
        }

        private GameServer.Core.RequestProcessing.Definitions.KeyCheckRequest TranslateKeyCheckRequest(PacketDefinitions.C2S.KeyCheckRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.KeyCheckRequest
            (
                request.PartialKey,
                request.ClientID,
                request.SummonerId,
                request.VersionNo,
                request.CheckId
            );
        }

        private GameServer.Core.RequestProcessing.Definitions.QueryStatusRequest TranslateQueryStatusRequest(QueryStatusRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.QueryStatusRequest();
        }

        private GameServer.Core.RequestProcessing.Definitions.SynchVersionRequest TranslateSynchVersion(SynchVersionRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.SynchVersionRequest(request.NetId, request.ClientId, request.Version);
        }

        private GameServer.Core.RequestProcessing.Definitions.PingLoadInfoRequest TranslatePingLoadInfoRequest(PingLoadInfoRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.PingLoadInfoRequest
            (
                request.SenderNetId,
                request.ClientId,
                request.SummonerId,
                request.Percentage,
                request.ETA,
                request.Count,
                request.Ping,
                request.Ready
            );
        }

        private GameServer.Core.RequestProcessing.Definitions.JoinTeamRequest TranslateJoinTeamRequest(JoinTeamRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.JoinTeamRequest(request.ClientId, request.NetTeamId);
        }

        private GameServer.Core.RequestProcessing.Definitions.ClientReadyRequest TranslateClientReadyRequest(ClientReady request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.ClientReadyRequest();
        }

        private GameServer.Core.RequestProcessing.Definitions.WorldSendCameraRequest TranslateWorldSendCameraRequest(WorldSendCameraRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.WorldSendCameraRequest(request.NetId, request.CameraPosition, request.CameraDirection, request.ClientID, request.SyncID);
        }

        private GameServer.Core.RequestProcessing.Definitions.MapPingRequest TranslateMapPingRequest(MapPingRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.MapPingRequest
            (
                request.Position,
                request.TargetNetId,
                _enumTranslationService.TranslatePingCategory(request.PingCategory)
            );
        }

        private GameServer.Core.RequestProcessing.Definitions.IssueOrderRequest TranslateIssueOrder(IssueOrderRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.IssueOrderRequest
            (
                _enumTranslationService.TranslateMovementOrderType(request.OrderType),
                request.Position,
                request.TargetNetID,
                _dTOTranslationService.TranslateMovementData(request.MovementData)
            );
        }

        private GameServer.Core.RequestProcessing.Definitions.WaypointAccRequest TranslateWaypointAccRequest(WaypointAccRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.WaypointAccRequest(request.NetId, request.SyncID, request.TeleportCount);
        }

        private GameServer.Core.RequestProcessing.Definitions.ReplicationConfirmRequest TranslateReplicationConfirmRequest(ReplicationConfirmRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.ReplicationConfirmRequest(request.NetId, request.SyncID);
        }

        private GameServer.Core.RequestProcessing.Definitions.SkillUpRequest TranslateSkillUpRequest(SkillUpRequest request)
        {
            var slot = _enumTranslationService.TranslateSpellSlot(request.Slot);
            return new GameServer.Core.RequestProcessing.Definitions.SkillUpRequest(request.NetId, slot, request.IsEvolve);
        }

        private GameServer.Core.RequestProcessing.Definitions.CastSpellRequest TranslateCastSpellRequest(CastSpellRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.CastSpellRequest
            (
                request.NetId,
                _enumTranslationService.TranslateSpellSlot(request.Slot),
                request.IsSummonerSpellBook,
                request.IsHudClickCast,
                request.Position,
                request.EndPosition,
                request.TargetNetID
            );
        }

        private GameServer.Core.RequestProcessing.Definitions.SynchSimTimeRequest TranslateSynchSimTimeRequest(SynchSimTimeRequest request)
        {
            return new GameServer.Core.RequestProcessing.Definitions.SynchSimTimeRequest
            (
                request.SenderNetId,
                request.TimeLastServerSeconds * 1000,
                request.TimeLastClientSeconds * 1000
            );
        }
    }
}