using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;

namespace LeagueSandbox.GameServer.Utils.Providers
{
    public interface ISpellDataProvider
    {
        ISpellData ProvideCharacterSpellData(string characterName, string spellName);
        ISpellData ProvideSummonerSpellData(SummonerSpell spell);
    }
}