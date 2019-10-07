using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Providers;
using MoreLinq;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class MapPingServerAction : ServerActionBase<MapPingRequest>
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;

        public MapPingServerAction(IPacketNotifier packetNotifier, IPlayerCache playerCache)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, MapPingRequest request)
        {
            var sender = _playerCache.GetPlayer(senderSummonerId);
            var targetPlayers = _playerCache.GetAllPlayers().Where(x => x.Champion.Team == sender.Champion.Team).Select(x => x.SummonerId);
            _packetNotifier.NotifyMapPing(targetPlayers, request.Position, request.TargetNetId, sender.Champion.NetId, request.PingCategory, true, true, false, true);
        }
    }
}
