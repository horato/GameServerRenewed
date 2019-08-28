using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal interface IEnumTranslationService
    {
        MapId TranslateMapType(MapType type);
    }
}