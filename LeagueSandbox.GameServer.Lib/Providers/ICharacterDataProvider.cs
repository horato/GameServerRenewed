using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal interface ICharacterDataProvider
    {
        CharacterData ProvideCharacterData(string characterName);
    }
}