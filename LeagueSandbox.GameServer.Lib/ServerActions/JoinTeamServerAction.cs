using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Controllers;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class JoinTeamServerAction : ServerActionBase<JoinTeamRequest>
    {
        private readonly IPlayerController _playerController;
        private readonly IPacketNotifier _packetNotifier;

        public JoinTeamServerAction(IPlayerController playerController, IPacketNotifier packetNotifier)
        {
            _playerController = playerController;
            _packetNotifier = packetNotifier;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, JoinTeamRequest request)
        {
            var players = _playerController.GetAllChampions().ToList();
            var senderPlayer = players.Single(x => x.SummonerId == senderSummonerId);
            _packetNotifier.NotifyTeamRosterUpdate(senderSummonerId, players);
            _packetNotifier.NotifyRename(senderSummonerId, senderPlayer.SummonerId, senderPlayer.Champion.SkinId, senderPlayer.SummonerName);
            _packetNotifier.NotifyReskin(senderSummonerId, senderPlayer.SummonerId, senderPlayer.Champion.SkinId, senderPlayer.Champion.SkinName);
        }
    }
}
