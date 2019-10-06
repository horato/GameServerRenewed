using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories.ExpCurve;
using LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Core.Scripting.DTO;
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

        public abstract MapType MapType { get; }

        protected MapScriptBase(IMapDataProvider mapDataProvider, IObjShopFactory shopFactory, IObjBarracksDampenerFactory barracksDampenerFactory, IObjHQFactory hqFactory, IObjAiTurretFactory turretFactory, ILevelPropAIFactory levelPropAiFactory)
        {
            _mapDataProvider = mapDataProvider;
            _shopFactory = shopFactory;
            _barracksDampenerFactory = barracksDampenerFactory;
            _hqFactory = hqFactory;
            _turretFactory = turretFactory;
            _levelPropAiFactory = levelPropAiFactory;
        }

        public virtual MapInitializationData Initialize()
        {
            var expCurve = _mapDataProvider.ProvideExpCurve(MapType);
            var expCurveDictionary = CreateExpCurveDictionary(expCurve);

            var mapObjects = _mapDataProvider.ProvideStaticGameObjectsForMap(MapType);
            var gameObjects = CreateGameObjectsFromMapObjects(mapObjects);

            return new MapInitializationData(expCurveDictionary, gameObjects, MapType, this);
        }

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

        private IEnumerable<IGameObject> CreateGameObjectsFromMapObjects(IEnumerable<MapObject> objects)
        {
            var result = new List<IGameObject>();
            foreach (var mapObject in objects)
            {
                switch (mapObject.ObjectType)
                {
                    case ObjectType.BarrackSpawn:
                    case ObjectType.NexusSpawn: //TODO: create a spawn point?
                    case ObjectType.LevelSize:
                    case ObjectType.AnimatedBuilding:
                    case ObjectType.Lake:
                    case ObjectType.NavPoint:
                    case ObjectType.InfoPoint:
                        break;
                    case ObjectType.Barrack:
                        var barrackInstance = _barracksDampenerFactory.CreateFromMapObject(mapObject);
                        result.Add(barrackInstance);
                        break;
                    case ObjectType.Nexus:
                        var hqInstance = _hqFactory.CreateFromMapObject(mapObject);
                        result.Add(hqInstance);
                        break;
                    case ObjectType.Turret:
                        var turretInstance = _turretFactory.CreateFromMapObject(mapObject);
                        result.Add(turretInstance);
                        break;
                    case ObjectType.Shop:
                        var shopInstance = _shopFactory.CreateFromMapObject(mapObject);
                        result.Add(shopInstance);
                        break;
                    case ObjectType.LevelProp:
                        var propInstance = _levelPropAiFactory.CreateFromMapObject(mapObject);
                        result.Add(propInstance);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(mapObject.ObjectType), mapObject.ObjectType, null);
                }
            }

            return result;
        }
    }
}
