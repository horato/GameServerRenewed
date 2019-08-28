using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal class EnumTranslationService : IEnumTranslationService
    {
        public MapId TranslateMapType(MapType type)
        {
            switch (type)
            {
                case MapType.FlatTestMap:
                    return MapId.FlatTestMap;
                case MapType.SummonersRift:
                    return MapId.SummonersRift;
                case MapType.HarrowingRift:
                    return MapId.HarrowingRift;
                case MapType.ProvingGrounds:
                    return MapId.ProvingGrounds;
                case MapType.TwistedTreeline:
                    return MapId.TwistedTreeline;
                case MapType.WinterRift:
                    return MapId.WinterRift;
                case MapType.CrystalScar:
                    return MapId.CrystalScar;
                case MapType.NewTwistedTreeline:
                    return MapId.NewTwistedTreeline;
                case MapType.NewSummonersRift:
                    return MapId.NewSummonersRift;
                case MapType.HowlingAbyss:
                    return MapId.HowlingAbyss;
                case MapType.ButchersBridge:
                    return MapId.ButchersBridge;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
