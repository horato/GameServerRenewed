using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Controllers;
using LeagueSandbox.GameServer.Lib.Services;
using Unity;

namespace LeagueSandbox.GameServer.Lib
{
    public class LibDependencyInjectionInstaller : IDependencyInjectionInstaller
    {
        public void Install(IUnityContainer container)
        {
            container.RegisterType<IGameUpdateService, GameUpdateService>();
            container.RegisterSingleton<IGameObjectsCache, GameObjectsCache>();
            container.RegisterSingleton<IPlayerCache, PlayerCache>();
            container.RegisterSingleton<INetworkIdCreationService, NetworkIdCreationService>();
            container.RegisterSingleton<IClientIdCreationService, ClientIdCreationService>();
            container.RegisterSingleton<ICoordinatesTranslationService, CoordinatesTranslationService>();
        }
    }
}
