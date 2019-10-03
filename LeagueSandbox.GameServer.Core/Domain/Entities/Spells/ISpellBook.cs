using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface ISpellBook
    {       
        /// <summary> Currently casted spell. Assuming there can only be 1 spell cast per unit at a time. </summary>
        ISpellInstance CurrentSpell { get; }
        int SkillPoints { get; }

        ISpell GetSpell(SpellSlot slot);
        void AddSpell(ISpell spell);
        IEnumerable<ISpell> GetAllSpells();
        string GetExtraSpell(ExtraSpellNumber number);
        void SkillPointUsed();
        bool IsCastingSpell();
        void BeginCasting(ISpellInstance spell);
        void CastingFinished();
    }
}