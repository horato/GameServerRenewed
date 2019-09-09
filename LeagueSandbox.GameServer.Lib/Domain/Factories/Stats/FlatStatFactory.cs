using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal class FlatStatFactory : EntityFactoryBase<FlatStat>, IFlatStatFactory
    {
        public FlatStatFactory(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        public IFlatStat CreateEmpty()
        {
            var instance = new FlatStat(false, 0, 0, 0, 0);

            return SetupDependencies(instance);
        }

        public IFlatStat CreateNew(float currentValue, float bonusPerLevel, float regenerationPer5, float regenerationBonusPerLevel)
        {
            var instance = new FlatStat(true, currentValue, bonusPerLevel, regenerationPer5, regenerationBonusPerLevel);

            return SetupDependencies(instance);
        }
    }
}
