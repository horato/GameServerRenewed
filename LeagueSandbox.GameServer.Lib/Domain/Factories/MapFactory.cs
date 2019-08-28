using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal class MapFactory : EntityFactoryBase<Map>, IMapFactory
    {
        public MapFactory(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        public Map CreateNew(MapType mapId)
        {
            var instance = new Map(mapId);

            return SetupDependencies(instance);
        }
    }
}