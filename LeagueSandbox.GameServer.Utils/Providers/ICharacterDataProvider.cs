using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Utils.Providers
{
    public interface ICharacterDataProvider
    {
        CharacterData ProvideCharacterData(string characterName);
    }
}