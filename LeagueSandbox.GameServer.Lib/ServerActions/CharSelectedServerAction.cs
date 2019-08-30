using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Controllers;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class CharSelectedServerAction : ServerActionBase<CharSelectedRequest>
    {
        private readonly IPlayerCache _playerCache;
        private readonly IPacketNotifier _packetNotifier;

        public CharSelectedServerAction(IPlayerCache playerCache, IPacketNotifier packetNotifier)
        {
            _playerCache = playerCache;
            _packetNotifier = packetNotifier;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, CharSelectedRequest request)
        {
            var players = _playerCache.GetAllPlayers();
            var blueBots = 0;
            var redBots = 0;
            foreach (var player in players)
            {
                if (!player.Champion.IsBot)
                    continue;

                switch (player.Champion.Team)
                {
                    case Team.Blue:
                        blueBots++;
                        break;
                    case Team.Red:
                        redBots++;
                        break;
                    case Team.Neutral:
                        throw new InvalidOperationException("Bots shouldn't be neutral.");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var sender = _playerCache.GetPlayer(senderSummonerId);
            _packetNotifier.NotifyStartSpawn(senderSummonerId, blueBots, redBots);
            _packetNotifier.NotifyCreateHero(senderSummonerId, sender);
            _packetNotifier.NotifyAvatarInfo(senderSummonerId, sender);
            _packetNotifier.NotifyEndSpawn(senderSummonerId);
        }
    }
}
