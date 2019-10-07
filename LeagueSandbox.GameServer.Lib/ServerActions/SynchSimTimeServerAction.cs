using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class SynchSimTimeServerAction : ServerActionBase<SynchSimTimeRequest>
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IGame _game;

        public SynchSimTimeServerAction(IPacketNotifier packetNotifier, IPlayerCache playerCache, IGame game)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _game = game;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, SynchSimTimeRequest request)
        {
            var sender = _playerCache.GetPlayer(senderSummonerId);
            var elapsed = _game.GameTimeElapsedMilliseconds;
            var clientTime = request.TimeLastClientMilliseconds;
            var serverTime = request.TimeLastServerMilliseconds;
            var overhead = elapsed - serverTime;
            // TODO: Verify this
            _packetNotifier.NotifySynchSimTimeFinal(senderSummonerId, sender.Champion.NetId, clientTime, overhead, elapsed);
        }
    }
}
