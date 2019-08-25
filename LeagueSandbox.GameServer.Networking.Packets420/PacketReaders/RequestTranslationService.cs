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
                case AttentionPingRequest attentionPingRequest:
                case AutoAttackOption autoAttackOption:
                case BasicTutorialMessageWindowClicked basicTutorialMessageWindowClicked:
                case BlueTipClicked blueTipClicked:
                case BuyItemRequest buyItemRequest:
                case CastSpellRequest castSpellRequest:
                case Click click:
                case ClientReady clientReady:
                case CursorPositionOnWorld cursorPositionOnWorld:
                case EmotionPacketRequest emotionPacketRequest:
                case HeartBeat heartBeat:
                case ChatMessage chatMessage:
                case MovementRequest movementRequest:
                case PingLoadInfoRequest pingLoadInfoRequest:
                case QuestClicked questClicked:
                case SellItem sellItem:
                case SkillUpRequest skillUpRequest:
                case SwapItemsRequest swapItemsRequest:
                case SynchVersionRequest synchVersionRequest:
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
    }
}