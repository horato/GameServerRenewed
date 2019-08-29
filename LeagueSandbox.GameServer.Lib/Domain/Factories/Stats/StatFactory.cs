using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal class StatFactory : EntityFactoryBase<Stat>, IStatFactory
    {
        public StatFactory(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        public IStat CreateEmpty()
        {
            var instance = new Stat(0, 0, 0, 0, 0);

            return SetupDependencies(instance);
        }

        public IStat CreateNew(float baseValue, float baseBonus, float percentBaseBonus, float flatBonus, float percentBonus)
        {
            var instance = new Stat(baseValue, baseBonus, percentBaseBonus, flatBonus, percentBonus);

            return SetupDependencies(instance);
        }
    }
}
