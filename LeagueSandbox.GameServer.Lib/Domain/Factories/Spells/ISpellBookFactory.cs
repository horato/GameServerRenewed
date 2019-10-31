using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal interface ISpellBookFactory
    {
        ISpellBook CreateEmpty();
        ISpellBook CreateFromCharacterData(string characterName, ICharacterData data);
    }
}