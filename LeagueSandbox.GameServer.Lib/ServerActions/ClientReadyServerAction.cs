using System;
using System.Collections.Generic;
using System.Text;
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

        public ClientReadyServerAction(IPlayerCache playerCache, IPacketNotifier packetNotifier)
        {
            _playerCache = playerCache;
            _packetNotifier = packetNotifier;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, ClientReadyRequest request)
        {
            var player = _playerCache.GetPlayer(senderSummonerId);
            //if (!player.IsDisconnected)
            //{
            //    _game.IncrementReadyPlayers();
            //}

            // Only one packet enter here
            //if (_game.PlayersReady == _playerManager.GetPlayers().Count)
            //{
            _packetNotifier.NotifyGameStart(0, true, true); //TODO: enable/disable pause
            //    foreach (var player in _playerManager.GetPlayers())
            //    {
            //        // Get notified about the spawn of other connected players - IMPORTANT: should only occur one-time
            //        foreach (var p in _playerManager.GetPlayers())
            //        {
            //            if (player.Item2.PlayerId == p.Item2.PlayerId) continue; //Don't self-inform twice
            //            _packetNotifier.NotifyHeroSpawn((int)player.Item2.PlayerId, p.Item2);
            //            _packetNotifier.NotifyAvatarInfo((int)player.Item2.PlayerId, p.Item2);
            //        }

            //        //if (player.Item2.PlayerId == (ulong)userId && !player.Item2.IsMatchingVersion)
            //        //{
            //        //    var msg = "Your client version does not match the server. " +
            //        //              "Check the server log for more information.";
            //        //    _packetNotifier.NotifyDebugMessage(userId, msg);
            //        //}

            //        _packetNotifier.NotifyEnterLocalVisibilityClient(player.Item2.Champion);
            //        // TODO: send this in one place only
            //        _packetNotifier.NotifyUpdatedStats(player.Item2.Champion, false);
            //        _packetNotifier.NotifyBlueTip((int)player.Item2.PlayerId, "Welcome to League Sandbox!", "This is a WIP product.", "", 0, player.Item2.Champion.NetId, _game.NetworkIdManager.GetNewNetId());
            //        _packetNotifier.NotifyBlueTip((int)player.Item2.PlayerId, "Server Build Date", ServerContext.BuildDateString, "", 0, player.Item2.Champion.NetId, _game.NetworkIdManager.GetNewNetId());
            //        _packetNotifier.NotifyBlueTip((int)player.Item2.PlayerId, "Your Champion", "You play " + player.Item2.Champion.Model, "", 0, player.Item2.Champion.NetId, _game.NetworkIdManager.GetNewNetId());
            //    }

            //    _game.Start();
            //}

            //if (_game.IsRunning)
            //{
            //    if (player.IsDisconnected)
            //    {
            //        foreach (var player in _playerManager.GetPlayers())
            //        {
            //            if (player.Item2.Team == player.Team)
            //            {
            //                _packetNotifier.NotifyHeroSpawn2(userId, player.Item2.Champion);

            //                /* This is probably not the best way
            //                 * of updating a champion's level, but it works */
            //                _packetNotifier.NotifyLevelUp(player.Item2.Champion);
            //                if (_game.IsPaused)
            //                {
            //                    _packetNotifier.NotifyPauseGame((int)_game.PauseTimeLeft, true);
            //                }
            //            }
            //        }
            //        player.IsDisconnected = false;
            //        _packetNotifier.NotifyUnitAnnounceEvent(UnitAnnounces.SUMMONER_RECONNECTED, player.Champion);

            //        // Send the initial game time sync packets, then let the map send another
            //        var gameTime = _game.GameTime;
            //        _packetNotifier.NotifyGameTimer(userId, gameTime);
            //        _packetNotifier.NotifyGameTimerUpdate(userId, gameTime);

            //        return true;
            //    }

            //    foreach (var p in _playerManager.GetPlayers())
            //    {
            //        _game.ObjectManager.AddObject(p.Item2.Champion);

            //        // Send the initial game time sync packets, then let the map send another
            //        var gameTime = _game.GameTime;
            //        _packetNotifier.NotifyGameTimer((int)p.Item2.PlayerId, gameTime);
            //        _packetNotifier.NotifyGameTimerUpdate((int)p.Item2.PlayerId, gameTime);
            //    }
            //}

            //return true;
        }
    }
}
