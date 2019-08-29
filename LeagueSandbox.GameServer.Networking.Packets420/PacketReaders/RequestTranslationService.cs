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
                case AttentionPingRequest attentionPingRequest:
                case AutoAttackOption autoAttackOption:
                case BasicTutorialMessageWindowClicked basicTutorialMessageWindowClicked:
                case BlueTipClicked blueTipClicked:
                case BuyItemRequest buyItemRequest:
                case CastSpellRequest castSpellRequest:
                case Click click:
                //case ClientReady clientReady:
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
                case ViewRequest viewRequest:
                default:
                    throw new ArgumentOutOfRangeException(nameof(request), request, "Unknown packet request type.");
            }
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
    }
}