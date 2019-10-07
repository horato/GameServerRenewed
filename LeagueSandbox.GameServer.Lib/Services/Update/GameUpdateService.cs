using System;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Lib.Caches;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class GameUpdateService : IGameUpdateService
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private float _nextNotifyTime;

        public GameUpdateService(IPacketNotifier packetNotifier, IPlayerCache playerCache)
        {
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
        }

        public void UpdateGame(IGame game, float millisecondDiff)
        {
            if (game.IsPaused)
                return;

            game.ApplyGameTimeDiff(millisecondDiff);

            var gameTime = game.GameTimeElapsedMilliseconds;
            if (gameTime >= _nextNotifyTime)
            {
                _nextNotifyTime = gameTime + 10000;
                var players = _playerCache.GetAllPlayers();
                foreach (var player in players)
                {
                    _packetNotifier.NotifySynchSimTime(player.SummonerId, gameTime);
                }
            }
        }
    }
}