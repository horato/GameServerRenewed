using System;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketReaders
{
    internal class RequestTranslationService : IRequestTranslationService
    {
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
                case AttentionPingRequest attentionPingRequest:
                case AutoAttackOption autoAttackOption:
                case BasicTutorialMessageWindowClicked basicTutorialMessageWindowClicked:
                case BlueTipClicked blueTipClicked:
                case BuyItemRequest buyItemRequest:
                case CastSpellRequest castSpellRequest:
                case Click click:
                case CursorPositionOnWorld cursorPositionOnWorld:
                case EmotionPacketRequest emotionPacketRequest:
                case HeartBeat heartBeat:
                case ChatMessage chatMessage:
                case MovementRequest movementRequest:
                case QuestClicked questClicked:
                case SellItem sellItem:
                case SkillUpRequest skillUpRequest:
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
    }
}