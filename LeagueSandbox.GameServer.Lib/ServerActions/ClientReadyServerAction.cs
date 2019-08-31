using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class ClientReadyServerAction : ServerActionBase<ClientReadyRequest>
    {
        private readonly IPlayerCache _playerCache;
        private readonly IPacketNotifier _packetNotifier;
        private readonly IGame _game;

        public ClientReadyServerAction(IPlayerCache playerCache, IPacketNotifier packetNotifier, IGame game)
        {
            _playerCache = playerCache;
            _packetNotifier = packetNotifier;
            _game = game;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, ClientReadyRequest request)
        {
            _playerCache.GetPlayer(senderSummonerId).LoadingFinished();

            var players = _playerCache.GetAllPlayers();
            if (players.All(x => x.IsLoaded))
            {
                _packetNotifier.NotifyGameStart(0, true, true); //TODO: enable/disable pause

                foreach (var player in players)
                {
                    //TODO: what if it just broadcasted everyone?
                    foreach (var p in players)
                    {
                        if (player.SummonerId == p.SummonerId)
                            continue;

                        _packetNotifier.NotifyCreateHero(player.SummonerId, p);
                        _packetNotifier.NotifyAvatarInfo(player.SummonerId, p);
                    }

                    // TODO: Shouldn't SyncVersion do this?
                    //if (player.Item2.PlayerId == (ulong)userId && !player.Item2.IsMatchingVersion)
                    //{
                    //    var msg = "Your client version does not match the server. " +
                    //              "Check the server log for more information.";
                    //    _packetNotifier.NotifyDebugMessage(userId, msg);
                    //}

                    _packetNotifier.NotifyEnterLocalVisibilityClient(players.Select(x => x.SummonerId), player.Champion);

                    // TODO: send this in one place only
                    //_packetNotifier.NotifyUpdatedStats(player.Item2.Champion, false);
                    //_packetNotifier.NotifyBlueTip((int)player.Item2.PlayerId, "Welcome to League Sandbox!", "This is a WIP product.", "", 0, player.Item2.Champion.NetId, _game.NetworkIdManager.GetNewNetId());
                    //_packetNotifier.NotifyBlueTip((int)player.Item2.PlayerId, "Server Build Date", ServerContext.BuildDateString, "", 0, player.Item2.Champion.NetId, _game.NetworkIdManager.GetNewNetId());
                    //_packetNotifier.NotifyBlueTip((int)player.Item2.PlayerId, "Your Champion", "You play " + player.Item2.Champion.Model, "", 0, player.Item2.Champion.NetId, _game.NetworkIdManager.GetNewNetId());
                }

                _game.UnPause();
            }

            if (_game.IsPaused)
                return;

            //TODO: Reconnect
            //if (player.IsDisconnected)
            //{
            //    foreach (var player in _playerManager.GetPlayers())
            //    {
            //        if (player.Item2.Team == player.Team)
            //        {
            //            _packetNotifier.NotifyHeroSpawn2(userId, player.Item2.Champion);

            //            /* This is probably not the best way
            //             * of updating a champion's level, but it works */
            //            _packetNotifier.NotifyLevelUp(player.Item2.Champion);
            //            if (_game.IsPaused)
            //            {
            //                _packetNotifier.NotifyPauseGame((int)_game.PauseTimeLeft, true);
            //            }
            //        }
            //    }
            //    player.IsDisconnected = false;
            //    _packetNotifier.NotifyUnitAnnounceEvent(UnitAnnounces.SUMMONER_RECONNECTED, player.Champion);

            //    // Send the initial game time sync packets, then let the map send another
            //    var gameTime = _game.GameTime;
            //    _packetNotifier.NotifyGameTimer(userId, gameTime);
            //    _packetNotifier.NotifyGameTimerUpdate(userId, gameTime);

            //    return true;
            //}

            foreach (var player in players)
            {
                var gameTime = _game.GameTimeElapsed;
                _packetNotifier.NotifySynchSimTime(player.SummonerId, gameTime);
                _packetNotifier.NotifySyncMissionTime(player.SummonerId, gameTime);
            }
        }
    }
}
