using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Lib.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain
{
    public class DomainDependencyInjectionInstaller : IDependencyInjectionInstaller
    {
        public void Install(IUnityContainer container)
        {
            container.RegisterType<IGameFactory, GameFactory>();
            container.RegisterType<IMapFactory, MapFactory>();
            container.RegisterType<IPlayerFactory, PlayerFactory>();
            container.RegisterType<IStatFactory, StatFactory>();
            container.RegisterType<IStatsFactory, StatsFactory>();
            container.RegisterType<IObjAiHeroFactory, ObjAiHeroFactory>();
        }
    }
}
