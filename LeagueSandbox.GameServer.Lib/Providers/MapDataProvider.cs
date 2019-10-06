using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Utils.Map.ExpCurve;
using LeagueSandbox.GameServer.Utils.Map.MapObjects;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal class MapDataProvider : IMapDataProvider
    {
        public IEnumerable<MapObject> ProvideStaticGameObjectsForMap(MapType map)
        {
            return MapObjectsReader.ReadMapObjects(map);
        }

        public ExpCurve ProvideExpCurve(MapType mapType)
        {
            return ExpCurveReader.ReadExpCurve(mapType);
        }
    }
}
