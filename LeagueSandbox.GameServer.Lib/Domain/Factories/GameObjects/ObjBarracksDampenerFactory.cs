using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.Map.MapObjects;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjBarracksDampenerFactory : EntityFactoryBase<ObjBarracksDampener>, IObjBarracksDampenerFactory
    {
        private readonly IStatsFactory _statsFactory;

        public ObjBarracksDampenerFactory(IUnityContainer unityContainer, IStatsFactory statsFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
        }

        public IObjBarracksDampener CreateFromMapObject(IMapObject obj, IDictionary<int, Vector2> navPoints, Vector2 spawnPoint, IMapSpawnSettings spawnSettings)
        {
            var stats = _statsFactory.CreateFromBarrackData(obj.BarracksData);
            stats.UpdateTargetability(false, SpellFlags.NonTargetableEnemy);

            var instance = new ObjBarracksDampener
            (
                obj.BarracksData.Team,
                obj.Position,
                stats,
                obj.BarracksData.NetId,
                1700,
                obj.BarracksData.PathfindingCollisionRadius,
                obj.BarracksData.Lane,
                navPoints,
                spawnPoint,
                spawnSettings.ExpGivenRadius,
                spawnSettings.GoldGivenRadius,
                spawnSettings.FirstMinionSpawnDelay,
                spawnSettings.WaveSpawnRate,
                spawnSettings.SingleMinionSpawnDelay,
                BarrackState.Alive,
                0,
                BarrackSpawnState.Waiting
            );

            return SetupDependencies(instance);
        }
    }
}
