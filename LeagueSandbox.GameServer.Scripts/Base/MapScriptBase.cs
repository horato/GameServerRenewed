using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories.ExpCurve;
using LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Scripting.DTO;
using LeagueSandbox.GameServer.Scripts.Base.DTOs;
using LeagueSandbox.GameServer.Utils.Map.ExpCurve;
using LeagueSandbox.GameServer.Utils.Map.MapObjects;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Scripts.Base
{
    public abstract class MapScriptBase : IMapScript
    {
        private readonly IMapDataProvider _mapDataProvider;
        private readonly IObjShopFactory _shopFactory;
        private readonly IObjBarracksDampenerFactory _barracksDampenerFactory;
        private readonly IObjHQFactory _hqFactory;
        private readonly IObjAiTurretFactory _turretFactory;
        private readonly ILevelPropAIFactory _levelPropAiFactory;
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly IObjAiMinionFactory _minionFactory;

        public abstract MapType MapType { get; }

        protected MapScriptBase(IMapDataProvider mapDataProvider, IObjShopFactory shopFactory, IObjBarracksDampenerFactory barracksDampenerFactory, IObjHQFactory hqFactory, IObjAiTurretFactory turretFactory, ILevelPropAIFactory levelPropAiFactory, IGameObjectsCache gameObjectsCache, IObjAiMinionFactory minionFactory)
        {
            _mapDataProvider = mapDataProvider;
            _shopFactory = shopFactory;
            _barracksDampenerFactory = barracksDampenerFactory;
            _hqFactory = hqFactory;
            _turretFactory = turretFactory;
            _levelPropAiFactory = levelPropAiFactory;
            _gameObjectsCache = gameObjectsCache;
            _minionFactory = minionFactory;
        }

        public MapInitializationData Initialize()
        {
            InitializeMapObjects();

            var expCurve = _mapDataProvider.ProvideExpCurve(MapType);
            var expCurveDictionary = CreateExpCurveDictionary(expCurve);
            return new MapInitializationData(expCurveDictionary, MapType, this);
        }

        #region Static game objects

        private void InitializeMapObjects()
        {
            var mapObjects = _mapDataProvider.ProvideStaticGameObjectsForMap(MapType);
            CreateGameObjectsFromMapObjects(mapObjects);
        }

        private void CreateGameObjectsFromMapObjects(IEnumerable<MapObject> objects)
        {
            var spawnSettings = CreateMapSpawnSettings();
            foreach (var mapObject in objects)
            {
                IGameObject gameObject;
                switch (mapObject.ObjectType)
                {
                    case ObjectType.BarrackSpawn:
                    case ObjectType.NexusSpawn: //TODO: create a spawn point?
                    case ObjectType.LevelSize:
                    case ObjectType.AnimatedBuilding:
                    case ObjectType.Lake:
                    case ObjectType.NavPoint:
                    case ObjectType.InfoPoint:
                        continue;
                    case ObjectType.Barrack:
                        gameObject = CreateBarrack(objects, mapObject, spawnSettings);
                        break;
                    case ObjectType.Nexus:
                        gameObject = _hqFactory.CreateFromMapObject(mapObject);
                        break;
                    case ObjectType.Turret:
                        gameObject = _turretFactory.CreateFromMapObject(mapObject);
                        break;
                    case ObjectType.Shop:
                        gameObject = _shopFactory.CreateFromMapObject(mapObject);
                        break;
                    case ObjectType.LevelProp:
                        gameObject = _levelPropAiFactory.CreateFromMapObject(mapObject);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(mapObject.ObjectType), mapObject.ObjectType, null);
                }

                _gameObjectsCache.Add(gameObject.NetId, gameObject);
            }
        }

        private IGameObject CreateBarrack(IEnumerable<MapObject> objects, IMapObject mapObject, MapSpawnSettings spawnSettings)
        {
            var laneNavPoints = objects.Where(x => x.ObjectType == ObjectType.NavPoint).Where(x => x.NavPointData.Lane == mapObject.BarracksData.Lane).OrderBy(x => x.NavPointData.Order).AsEnumerable();
            if (mapObject.BarracksData.Team == Team.Red)
                laneNavPoints = laneNavPoints.Reverse();

            var idx = 0;
            var navPoints = laneNavPoints.ToDictionary(x => idx++, x => x.Position.ToVector2());

            var spawnPoint = objects.Where(x => x.ObjectType == ObjectType.BarrackSpawn).Single(x => x.BarrackSpawnData.Team == mapObject.BarracksData.Team && x.BarrackSpawnData.Lane == mapObject.BarracksData.Lane).Position.ToVector2();
            return _barracksDampenerFactory.CreateFromMapObject(mapObject, navPoints, spawnPoint, spawnSettings);
        }

        #endregion

        #region Exp curve

        private IDictionary<int, float> CreateExpCurveDictionary(IExpCurve expCurve)
        {
            var result = new Dictionary<int, float>
            {
                { 2, expCurve.Level2 },
                { 3, expCurve.Level3 },
                { 4, expCurve.Level4 },
                { 5, expCurve.Level5 },
                { 6, expCurve.Level6 },
                { 7, expCurve.Level7 },
                { 8, expCurve.Level8 },
                { 9, expCurve.Level9 },
                { 10, expCurve.Level10 },
                { 11, expCurve.Level11 },
                { 12, expCurve.Level12 },
                { 13, expCurve.Level13 },
                { 14, expCurve.Level14 },
                { 15, expCurve.Level15 },
                { 16, expCurve.Level16 },
                { 17, expCurve.Level17 },
                { 18, expCurve.Level18 },
                { 19, expCurve.Level19 },
                { 20, expCurve.Level20 },
                { 21, expCurve.Level21 },
                { 22, expCurve.Level22 },
                { 23, expCurve.Level23 },
                { 24, expCurve.Level24 },
                { 25, expCurve.Level25 },
                { 26, expCurve.Level26 },
                { 27, expCurve.Level27 },
                { 28, expCurve.Level28 },
                { 29, expCurve.Level29 },
                { 30, expCurve.Level30 },
            };

            result.Where(x => Math.Abs(x.Value) < float.Epsilon).ToList().ForEach(x => result.Remove(x.Key));
            result.Add(1, 0);

            return result;
        }

        #endregion

        public virtual MinionSpawnResult SpawnMinion(int minionNumber, IObjBarracksDampener barrack)
        {
            var minionInfo = GetMinionSpawnInfo(barrack.Lane, barrack.Team, barrack.WavesCount, minionNumber);
            if (minionInfo == null)
                return new MinionSpawnResult(null, false);

            var minion = _minionFactory.CreateFromMinionInfo(barrack, minionInfo.Name, minionInfo.Info);
            return new MinionSpawnResult(minion, true);
        }

        protected abstract MapSpawnSettings CreateMapSpawnSettings();
        private protected abstract NamedMinionInfo GetMinionSpawnInfo(Lane lane, Team team, int waveNumber, int minionNumber);
    }
}
