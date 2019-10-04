using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal interface ISpellDataProvider
    {
        ISpellData ProvideCharacterSpellData(string characterName, string spellName);
        ISpellData ProvideSummonerSpellData(SummonerSpell spell);
    }
}