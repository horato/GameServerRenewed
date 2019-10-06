using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Utils.Map.ExpCurve;
using LeagueSandbox.GameServer.Utils.Map.MapObjects;

namespace LeagueSandbox.GameServer.Utils.Providers
{
    public interface IMapDataProvider
    {
        IEnumerable<MapObject> ProvideStaticGameObjectsForMap(MapType map);
        ExpCurve ProvideExpCurve(MapType mapType);
    }
}