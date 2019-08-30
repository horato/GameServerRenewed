using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.Services
{
    internal interface IEnumTranslationService
    {
        MapId TranslateMapType(MapType type);
        SummonerSpellHash TranslateSummonerSpell(SummonerSpell spell);
        TeamId TranslateTeam(Team team);
        string TranslateRank(Rank rank);
    }
}