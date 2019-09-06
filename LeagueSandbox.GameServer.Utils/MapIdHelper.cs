using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Utils
{
    internal static class MapIdHelper
    {
        public static int TranslateMapId(MapType mapId)
        {
            switch (mapId)
            {
                case MapType.SummonersRift:
                    return 1;
                case MapType.CrystalScar:
                    return 8;
                case MapType.NewTwistedTreeline:
                    return 10;
                case MapType.NewSummonersRift:
                    return 11;
                case MapType.HowlingAbyss:
                    return 12;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mapId), mapId, null);
            }
        }

    }
}
