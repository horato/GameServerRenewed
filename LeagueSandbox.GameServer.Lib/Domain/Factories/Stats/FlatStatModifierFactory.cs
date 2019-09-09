using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal class FlatStatModifierFactory : EntityFactoryBase<FlatStatModifier>, IFlatStatModifierFactory
    {
        public FlatStatModifierFactory(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        public FlatStatModifier CreateNew(float value, float bonusPerLevel, float regenerationPer5, float regenerationBonusPerLevel)
        {
            var instance = new FlatStatModifier(value, bonusPerLevel, regenerationPer5, regenerationBonusPerLevel);

            return SetupDependencies(instance);
        }
    }
}