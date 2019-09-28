using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface ISpellBookFactory
    {
        ISpellBook CreateEmpty();
        ISpellBook CreateFromCharacterData(string characterName, CharacterData data);
    }
}