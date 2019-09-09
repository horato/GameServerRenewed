﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Utils.MapObjects;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal class MapObjectsProvider : IMapObjectsProvider
    {
        private readonly IObjShopFactory _shopFactory;
        private readonly IObjBarracksDampenerFactory _barracksDampenerFactory;
        private readonly IObjHQFactory _hqFactory;
        private readonly IObjAiTurretFactory _turretFactory;
        private readonly ILevelPropAIFactory _levelPropAiFactory;

        public MapObjectsProvider(IObjShopFactory shopFactory, IObjBarracksDampenerFactory barracksDampenerFactory, IObjHQFactory hqFactory, IObjAiTurretFactory turretFactory, ILevelPropAIFactory levelPropAiFactory)
        {
            _shopFactory = shopFactory;
            _barracksDampenerFactory = barracksDampenerFactory;
            _hqFactory = hqFactory;
            _turretFactory = turretFactory;
            _levelPropAiFactory = levelPropAiFactory;
        }

        public IEnumerable<IGameObject> ProvideStaticGameObjectsForMap(MapType map)
        {
            var result = new List<IGameObject>();
            var objects = MapObjectsReader.ReadMapObjects(map);
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