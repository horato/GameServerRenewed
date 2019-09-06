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
    internal class ObjTurretFactory : EntityFactoryBase<ObjTurret>, IObjTurretFactory
    {
        private readonly IStatsFactory _statsFactory;

        public ObjTurretFactory(IUnityContainer unityContainer, IStatsFactory statsFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
        }

        public IObjTurret CreateFromMapObject(MapObject obj)
        {
            var stats = _statsFactory.CreateDefaultStats();
            var instance = new ObjTurret(obj.Team, obj.Position, stats, obj.NetId);

            return SetupDependencies(instance);
        }
    }
}
