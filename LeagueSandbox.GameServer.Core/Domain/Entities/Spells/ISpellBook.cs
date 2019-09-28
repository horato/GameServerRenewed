using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface ISpellBook
    {       
        /// <summary> Currently casted spell. Assuming there can only be 1 spell cast per unit at a time. </summary>
        ISpellInstance CurrentSpell { get; }

        ISpell GetSpell(SpellSlot slot);
        void AddSpell(ISpell spell);
        IEnumerable<ISpell> GetAllSpells();
    }
}