using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal class StatModifierFactory : EntityFactoryBase<StatModifier>, IStatModifierFactory
    {
        public StatModifierFactory(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        public IStatModifier CreateNew(float baseValue, float baseBonus, float percentBaseBonus, float flatBonus, float percentBonus)
        {
            var instance = new StatModifier(baseValue, baseBonus, percentBaseBonus, flatBonus, percentBonus);

            return SetupDependencies(instance);
        }
    }
}