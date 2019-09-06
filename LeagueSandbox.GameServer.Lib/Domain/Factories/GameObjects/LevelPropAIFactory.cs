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
    internal class LevelPropAIFactory : EntityFactoryBase<LevelPropAI>, ILevelPropAIFactory
    {
        private readonly IStatsFactory _statsFactory;

        public LevelPropAIFactory(IUnityContainer unityContainer, IStatsFactory statsFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
        }

        public ILevelPropAI CreateFromMapObject(MapObject obj)
        {
            var stats = _statsFactory.CreateDefaultStats();
            var instance = new LevelPropAI(obj.Team, obj.Position, stats, obj.NetId, string.Empty, 0, 1200, new Vector3(0, 0, 0), obj.Rotation, obj.Scale, obj.Name);

            return SetupDependencies(instance);
        }
    }
}
