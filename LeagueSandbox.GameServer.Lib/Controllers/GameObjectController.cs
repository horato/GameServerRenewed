using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Lib.Services;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal class GameObjectController : IGameObjectController
    {
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly IPlayerCache _playerCache;
        private readonly IPlayerFactory _playerFactory;
        private readonly IObjAiHeroFactory _objAiHeroFactory;
        private readonly IClientIdCreationService _clientIdCreationService;
        private readonly IMovementService _movementService;
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPathingService _pathingService;

        public GameObjectController(IGameObjectsCache gameObjectsCache, IPlayerCache playerCache, IPlayerFactory playerFactory, IObjAiHeroFactory objAiHeroFactory, IClientIdCreationService clientIdCreationService, IMovementService movementService, IPacketNotifier packetNotifier, IPathingService pathingService)
        {
            _gameObjectsCache = gameObjectsCache;
            _playerCache = playerCache;
            _playerFactory = playerFactory;
            _objAiHeroFactory = objAiHeroFactory;
            _clientIdCreationService = clientIdCreationService;
            _movementService = movementService;
            _packetNotifier = packetNotifier;
            _pathingService = pathingService;
        }

        public void InitializePlayers(IEnumerable<StartupPlayer> players)
        {
            foreach (var startupPlayer in players)
            {
                var champion = _objAiHeroFactory.CreateFromStartupPlayer(startupPlayer, _clientIdCreationService.GetNewId());
                var player = _playerFactory.CreateFromStartupPlayer(startupPlayer, champion);
                _gameObjectsCache.Add(player.SummonerId, player.Champion);
                _playerCache.Add(player.SummonerId, player);
            }
        }

        public void UpdateObjects(float millisecondsDiff)
        {
            var movedObjects = new List<IGameObject>();
            var gameObjects = _gameObjectsCache.GetAllObjects();
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is IObjAiBase aiBase)
                {
                    _movementService.MoveObject(aiBase, millisecondsDiff);
                    if (aiBase.IsPositionChanged)
                        movedObjects.Add(aiBase);
                }

                //TODO: Player - stats update, gold update, attack, attackmove, respawn timer, level up, death?, multikills, spells/projectiles, cc
                //TODO: Minion - attack, move, cc
                //TODO: Turret - attack, stat increase, hp regen
                //TODO: Inhibitors - respawn, announces
            }

            if (movedObjects.Count > 0)
            {
                var mapCenter = _pathingService.GetMapCenter();
                var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); // TODO: vision
                _packetNotifier.NotifyWaypointGroup(targetSummonerIds, movedObjects, mapCenter);
                movedObjects.ForEach(x => x.OnMovementDataSent());
            }
        }
    }
}
