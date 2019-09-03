using System.Collections.Generic;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Controllers;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class SynchVersionServerAction : ServerActionBase<SynchVersionRequest>
    {
        private readonly IServerInformationData _serverInformationData;
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IGame _game;

        public SynchVersionServerAction(IServerInformationData serverInformationData, IPacketNotifier packetNotifier, IPlayerCache playerCache, IGame game)
        {
            _serverInformationData = serverInformationData;
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _game = game;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, SynchVersionRequest request)
        {
            var serverVersion = _serverInformationData.Version;
            var versionMatches = request.Version == serverVersion;
            if (!versionMatches)
            {
                _packetNotifier.NotifySynchVersion(senderSummonerId, versionMatches, MapType.SummonersRift, new List<IPlayer>(), serverVersion);
                return;
            }

            var champions = _playerCache.GetAllPlayers();
            _packetNotifier.NotifySynchVersion(senderSummonerId, versionMatches, _game.Map.Id, champions, serverVersion);
        }
    }
}
