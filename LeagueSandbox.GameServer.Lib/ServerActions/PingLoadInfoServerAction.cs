using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class PingLoadInfoServerAction : ServerActionBase<PingLoadInfoRequest>
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;

        public PingLoadInfoServerAction(IPacketNotifier packetNotifier, IPlayerCache playerCache)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, PingLoadInfoRequest request)
        {
            var player = _playerCache.GetPlayer(senderSummonerId);
            _packetNotifier.NotifyPingLoadInfo(player.Champion.NetId, player.Champion.ClientId, senderSummonerId, request);
        }
    }
}
