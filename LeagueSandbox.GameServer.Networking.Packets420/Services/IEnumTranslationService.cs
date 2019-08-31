using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;
using TipCommand = LeagueSandbox.GameServer.Networking.Packets420.Enums.TipCommand;

namespace LeagueSandbox.GameServer.Networking.Packets420.Services
{
    internal interface IEnumTranslationService
    {
        MapId TranslateMapType(MapType type);
        SummonerSpellHash TranslateSummonerSpell(SummonerSpell spell);
        TeamId TranslateTeam(Team team);
        string TranslateRank(Rank rank);
        TipCommand TranslateTipCommand(GameServer.Core.Domain.Enums.TipCommand tipCommand);
    }
}