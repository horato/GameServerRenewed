using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
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
    internal class ObjHQFactory : EntityFactoryBase<ObjHQ>, IObjHQFactory
    {
        private readonly IStatsFactory _statsFactory;

        public ObjHQFactory(IUnityContainer unityContainer, IStatsFactory statsFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
        }

        public IObjHQ CreateFromMapObject(MapObject obj)
        {
            var stats = _statsFactory.CreateDefaultStats();

            stats.Armor.ApplyStatModifier(new StatModifier(obj.HqData.Armor, 0, 0, 0));
            stats.HealthRegeneration.ApplyStatModifier(new StatModifier(obj.HqData.BaseStaticHPRegen, 0, 0, 0));
            stats.HealthPoints.ApplyStatModifier(new StatModifier(obj.HqData.MaxHp, 0, 0, 0));
            stats.ManaPoints.ApplyStatModifier(new StatModifier(obj.HqData.MaxMP, 0, 0, 0));
            
            stats.UpdateTargetability(false, SpellFlags.NonTargetableEnemy);

            var instance = new ObjHQ(obj.Team, obj.Position, stats, obj.NetId, 1700);

            return SetupDependencies(instance);
        }
    }
}
