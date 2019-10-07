using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class ChatServerAction : ServerActionBase<ChatRequest>
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;

        public ChatServerAction(IPacketNotifier packetNotifier, IPlayerCache playerCache)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, ChatRequest request)
        {
            var sender = _playerCache.GetPlayer(senderSummonerId);
            var targetSummonerIds = _playerCache.GetAllPlayers().Where(x => request.ChatType != ChatType.Team || x.Champion.Team == sender.Champion.Team).Select(x => x.SummonerId);
            _packetNotifier.WriteChatMessage(targetSummonerIds, request.ClientID, request.NetID, request.Localized, request.ChatType, request.Params, request.Message);
        }
    }
}
