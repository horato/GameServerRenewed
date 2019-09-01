using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Controllers;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class JoinTeamServerAction : ServerActionBase<JoinTeamRequest>
    {
        private readonly IPlayerCache _playerCache;
        private readonly IPacketNotifier _packetNotifier;

        public JoinTeamServerAction(IPacketNotifier packetNotifier, IPlayerCache playerCache)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, JoinTeamRequest request)
        {
            var players = _playerCache.GetAllPlayers().ToList();

            _packetNotifier.NotifyTeamRosterUpdate(senderSummonerId, players);
            foreach (var player in players)
            {
                _packetNotifier.NotifyRename(senderSummonerId, player.SummonerId, player.Champion.SkinId, player.SummonerName);
                _packetNotifier.NotifyReskin(senderSummonerId, player.SummonerId, player.Champion.SkinId, player.Champion.SkinName);
            }
        }
    }
}
