using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Lib.Services.Update;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal class GameObjectController : IGameObjectController
    {
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly IPlayerCache _playerCache;
        private readonly IPlayerFactory _playerFactory;
        private readonly IObjAiHeroFactory _objAiHeroFactory;
        private readonly IClientIdCreationService _clientIdCreationService;
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPathingService _pathingService;
        private readonly IMapObjectsProvider _mapObjectsProvider;

        private readonly IAttackableUnitUpdateService _attackableUnitUpdateService;
        private readonly IGameObjectUpdateService _gameObjectUpdateService;
        private readonly IMissileUpdateService _missileUpdateService;
        private readonly ILevelPropAiUpdateService _levelPropAiUpdateService;
        private readonly INeutralMinionCampUpdateService _minionCampUpdateService;
        private readonly IObjAiBaseUpdateService _aiBaseUpdateService;
        private readonly IObjAiHeroUpdateService _aiHeroUpdateService;
        private readonly IObjAiMinionUpdateService _aiMinionUpdateService;
        private readonly IObjAnimatedBuildingUpdateService _animatedBuildingUpdateService;
        private readonly IObjBarracksDampenerUpdateService _barracksDampenerUpdateService;
        private readonly IObjBuildingUpdateService _buildingUpdateService;
        private readonly IObjHqUpdateService _hqUpdateService;
        private readonly IObjShopUpdateService _objShopUpdateService;
        private readonly IObjSpawnPointUpdateService _objSpawnPointUpdateService;
        private readonly IObjTurretUpdateService _objTurretUpdateService;

        public GameObjectController(IGameObjectsCache gameObjectsCache, IMissileUpdateService missileUpdateService, IPlayerCache playerCache, IPlayerFactory playerFactory, IObjAiHeroFactory objAiHeroFactory, IClientIdCreationService clientIdCreationService, IPacketNotifier packetNotifier, IPathingService pathingService, IMapObjectsProvider mapObjectsProvider, IAttackableUnitUpdateService attackableUnitUpdateService, IGameObjectUpdateService gameObjectUpdateService, ILevelPropAiUpdateService levelPropAiUpdateService, INeutralMinionCampUpdateService minionCampUpdateService, IObjAiBaseUpdateService aiBaseUpdateService, IObjAiHeroUpdateService aiHeroUpdateService, IObjAiMinionUpdateService aiMinionUpdateService, IObjAnimatedBuildingUpdateService animatedBuildingUpdateService, IObjBarracksDampenerUpdateService barracksDampenerUpdateService, IObjBuildingUpdateService buildingUpdateService, IObjHqUpdateService hqUpdateService, IObjShopUpdateService objShopUpdateService, IObjSpawnPointUpdateService objSpawnPointUpdateService, IObjTurretUpdateService objTurretUpdateService)
        {
            _gameObjectsCache = gameObjectsCache;
            _missileUpdateService = missileUpdateService;
            _playerCache = playerCache;
            _playerFactory = playerFactory;
            _objAiHeroFactory = objAiHeroFactory;
            _clientIdCreationService = clientIdCreationService;
            _packetNotifier = packetNotifier;
            _pathingService = pathingService;
            _mapObjectsProvider = mapObjectsProvider;
            _attackableUnitUpdateService = attackableUnitUpdateService;
            _gameObjectUpdateService = gameObjectUpdateService;
            _levelPropAiUpdateService = levelPropAiUpdateService;
            _minionCampUpdateService = minionCampUpdateService;
            _aiBaseUpdateService = aiBaseUpdateService;
            _aiHeroUpdateService = aiHeroUpdateService;
            _aiMinionUpdateService = aiMinionUpdateService;
            _animatedBuildingUpdateService = animatedBuildingUpdateService;
            _barracksDampenerUpdateService = barracksDampenerUpdateService;
            _buildingUpdateService = buildingUpdateService;
            _hqUpdateService = hqUpdateService;
            _objShopUpdateService = objShopUpdateService;
            _objSpawnPointUpdateService = objSpawnPointUpdateService;
            _objTurretUpdateService = objTurretUpdateService;
        }

        public void InitializeGameObjects(IEnumerable<StartupPlayer> players, MapType map)
        {
            foreach (var startupPlayer in players)
            {
                var champion = _objAiHeroFactory.CreateFromStartupPlayer(startupPlayer, _clientIdCreationService.GetNewId());
                var player = _playerFactory.CreateFromStartupPlayer(startupPlayer, champion);
                _gameObjectsCache.Add(player.Champion.NetId, player.Champion);
                _playerCache.Add(player.SummonerId, player);
            }

            var objects = _mapObjectsProvider.ProvideStaticGameObjectsForMap(map);
            foreach (var gameObject in objects)
            {
                _gameObjectsCache.Add(gameObject.NetId, gameObject);
            }
        }

        public void UpdateObjects(float millisecondsDiff)
        {
            // AttackSpeedFlat = 0.625f / (1 + charData.AttackDelayOffsetPercent);
            //TODO: Player - stats update, gold update, attack, attackmove, respawn timer, level up, death?, multikills, spells/projectiles, cc
            //TODO: Minion - attack, move, cc
            //TODO: Turret - attack, stat increase, hp regen
            //TODO: Inhibitors - respawn, announces

            var movedObjects = new List<IGameObject>();
            var statsUpdatedObjects = new List<IAttackableUnit>();
            var gameObjects = _gameObjectsCache.GetAllObjects();
            foreach (var gameObject in gameObjects)
            {
                // TODO: Update service provider & reflection?

                if (gameObject is IGameObject obj)
                {
                    _gameObjectUpdateService.Update(obj, millisecondsDiff);
                }

                if (gameObject is IMissile missile)
                {
                    _missileUpdateService.Update(missile, millisecondsDiff);
                }

                if (gameObject is IAttackableUnit attackableUnit)
                {
                    _attackableUnitUpdateService.Update(attackableUnit, millisecondsDiff);
                }

                if (gameObject is IObjAiBase aiBase)
                {
                    _aiBaseUpdateService.Update(aiBase, millisecondsDiff);
                }

                if (gameObject is ILevelPropAI levelProp)
                {
                    _levelPropAiUpdateService.Update(levelProp, millisecondsDiff);
                }

                if (gameObject is IObjAiHero hero)
                {
                    _aiHeroUpdateService.Update(hero, millisecondsDiff);
                }

                if (gameObject is IObjAiMinion minion)
                {
                    _aiMinionUpdateService.Update(minion, millisecondsDiff);
                }

                if (gameObject is IObjTurret turret)
                {
                    _objTurretUpdateService.Update(turret, millisecondsDiff);
                }

                if (gameObject is IObjBuilding building)
                {
                    _buildingUpdateService.Update(building, millisecondsDiff);
                }

                if (gameObject is IObjAnimatedBuilding animatedBuilding)
                {
                    _animatedBuildingUpdateService.Update(animatedBuilding, millisecondsDiff);
                }

                if (gameObject is IObjBarracksDampener barracksDampener)
                {
                    _barracksDampenerUpdateService.Update(barracksDampener, millisecondsDiff);
                }

                if (gameObject is IObjHQ hq)
                {
                    _hqUpdateService.Update(hq, millisecondsDiff);
                }

                if (gameObject is INeutralMinionCamp minionCamp)
                {
                    _minionCampUpdateService.Update(minionCamp, millisecondsDiff);
                }

                if (gameObject is IObjShop shop)
                {
                    _objShopUpdateService.Update(shop, millisecondsDiff);
                }

                if (gameObject is IObjSpawnPoint spawnPoint)
                {
                    _objSpawnPointUpdateService.Update(spawnPoint, millisecondsDiff);
                }

                if (gameObject is IAttackableUnit unit && unit.Stats.IsStatsChanged())
                    statsUpdatedObjects.Add(unit);
                if (gameObject is IObjAiBase aiUnit && aiUnit.IsPositionChanged)
                    movedObjects.Add(aiUnit);
            }

            if (movedObjects.Any())
            {
                var mapCenter = _pathingService.GetMapCenter();
                var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); // TODO: vision
                _packetNotifier.NotifyWaypointGroup(targetSummonerIds, movedObjects, mapCenter);
                movedObjects.ForEach(x => x.OnMovementDataSent());
            }

            if (statsUpdatedObjects.Any())
            {
                var targetSummonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId); // TODO: vision
                _packetNotifier.NotifyReplication(targetSummonerIds, statsUpdatedObjects);
                statsUpdatedObjects.ForEach(x => x.Stats.OnStatUpdateSent());
            }
        }
    }
}
