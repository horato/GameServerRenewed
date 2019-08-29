using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal class PlayerController : IPlayerController
    {
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly IPlayerCache _playerCache;
        private readonly IPlayerFactory _playerFactory;
        private readonly IObjAiHeroFactory _objAiHeroFactory;

        public PlayerController(IGameObjectsCache gameObjectsCache, IPlayerCache playerCache, IPlayerFactory playerFactory, IObjAiHeroFactory objAiHeroFactory)
        {
            _gameObjectsCache = gameObjectsCache;
            _playerCache = playerCache;
            _playerFactory = playerFactory;
            _objAiHeroFactory = objAiHeroFactory;
        }

        public void InitializePlayers(IEnumerable<StartupPlayer> players)
        {
            foreach (var startupPlayer in players)
            {
                var champion = _objAiHeroFactory.CreateFromStartupPlayer(startupPlayer);
                var player = _playerFactory.CreateFromStartupPlayer(startupPlayer, champion);
                _gameObjectsCache.Add(player.SummonerId, player.Champion);
                _playerCache.Add(player.SummonerId, player);
            }
        }

        public IEnumerable<IPlayer> GetAllChampions()
        {
            return _playerCache.GetAllPlayers();
        }
    }
}
