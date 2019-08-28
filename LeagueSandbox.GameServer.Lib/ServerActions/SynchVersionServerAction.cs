using System.Collections.Generic;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
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
        private readonly IPlayerController _playerController;
        private readonly IGame _game;

        public SynchVersionServerAction(IServerInformationData serverInformationData, IPacketNotifier packetNotifier, IPlayerController playerController, IGame game)
        {
            _serverInformationData = serverInformationData;
            _packetNotifier = packetNotifier;
            _playerController = playerController;
            _game = game;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, SynchVersionRequest request)
        {
            var serverVersion = _serverInformationData.Version;
            var versionMatches = request.Version == serverVersion;
            if (!versionMatches)
            {
                _packetNotifier.NotifySynchVersion(senderSummonerId, versionMatches, 0, new List<IObjAiHero>(), serverVersion);
                return;
            }

            var champions = _playerController.GetAllChampions();
            _packetNotifier.NotifySynchVersion(senderSummonerId, versionMatches, _game.Map.Id, champions, serverVersion);
        }
    }
}
