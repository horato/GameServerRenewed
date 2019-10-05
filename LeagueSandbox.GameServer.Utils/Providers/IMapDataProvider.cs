using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.Map.ExpCurve;

namespace LeagueSandbox.GameServer.Utils.Providers
{
    public interface IMapDataProvider
    {
        IEnumerable<IGameObject> ProvideStaticGameObjectsForMap(MapType map);
        ExpCurve ProvideExpCurve(MapType mapType);
    }
}