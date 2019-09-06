using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.MapObjects;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjAiTurretFactory : EntityFactoryBase<ObjAiTurret>, IObjAiTurretFactory
    {
        private readonly IStatsFactory _statsFactory;

        public ObjAiTurretFactory(IUnityContainer unityContainer, IStatsFactory statsFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
        }

        public IObjAiTurret CreateFromMapObject(MapObject obj)
        {
            var stats = _statsFactory.CreateDefaultStats();

            stats.HealthPoints.ApplyStatModifier(new StatModifier(200, 0, 0, 0));
            stats.FlatHealthPoints.ApplyStatModifier(new FlatStatModifier(200, 0, 0));

            var instance = new ObjAiTurret(obj.Team, obj.Position, stats, obj.NetId, obj.Name, 0);

            return SetupDependencies(instance);
        }
    }
}
