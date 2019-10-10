using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal class GameFactory : EntityFactoryBase<Game>, IGameFactory
    {
        public GameFactory(IUnityContainer unityContainer) : base(unityContainer)
        {

        }

        public IGame CreateNew(IMap map)
        {
            var instance = new Game(map, true, 0, 1);

            return SetupDependencies(instance);
        }
    }
}