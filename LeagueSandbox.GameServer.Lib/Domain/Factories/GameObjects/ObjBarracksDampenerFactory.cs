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
    internal class ObjBarracksDampenerFactory : EntityFactoryBase<ObjBarracksDampener>, IObjBarracksDampenerFactory
    {
        private readonly IStatsFactory _statsFactory;

        public ObjBarracksDampenerFactory(IUnityContainer unityContainer, IStatsFactory statsFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
        }

        public IObjBarracksDampener CreateFromMapObject(MapObject obj)
        {
            var stats = _statsFactory.CreateDefaultStats();

            stats.Armor.ApplyStatModifier(new StatModifier(obj.BarracksData.Armor, 0, 0, 0));
            stats.FlatHealthPoints.ApplyStatModifier(new FlatStatModifier(0, 0, obj.BarracksData.BaseStaticHPRegen));
            stats.HealthPoints.ApplyStatModifier(new StatModifier(obj.BarracksData.MaxHP, 0, 0, 0));
            stats.ManaPoints.ApplyStatModifier(new StatModifier(obj.BarracksData.MaxMP, 0, 0, 0));
            stats.UpdateTargetability(false, SpellFlags.NonTargetableEnemy);

            var instance = new ObjBarracksDampener
            (
                obj.BarracksData.Team, 
                obj.Position, 
                stats,
                obj.BarracksData.NetId,
                1700,
                obj.BarracksData.Lane
            );

            return SetupDependencies(instance);
        }
    }
}
