using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal interface IMapObjectsProvider
    {
        IEnumerable<IGameObject> ProvideStaticGameObjectsForMap(MapType map);
    }
}