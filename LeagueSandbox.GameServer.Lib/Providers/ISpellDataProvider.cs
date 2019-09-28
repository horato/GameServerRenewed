using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal interface ISpellDataProvider
    {
        SpellData ProvideCharacterSpellData(string characterName, string spellName);
    }
}