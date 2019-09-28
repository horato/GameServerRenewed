using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface ISpellBook
    {
        ISpell GetSpell(SpellSlot slot);
        void AddSpell(ISpell spell);
    }
}