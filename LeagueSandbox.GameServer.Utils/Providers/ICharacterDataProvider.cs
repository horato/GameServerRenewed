using LeagueSandbox.GameServer.Core.Data;

namespace LeagueSandbox.GameServer.Utils.Providers
{
    public interface ICharacterDataProvider
    {
        ICharacterData ProvideCharacterData(string characterName);
    }
}