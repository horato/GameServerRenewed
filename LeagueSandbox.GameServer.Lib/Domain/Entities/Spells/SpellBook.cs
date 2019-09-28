using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using MoreLinq;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class SpellBook : ISpellBook
    {
        private readonly IDictionary<SpellSlot, ISpell> _spells = new Dictionary<SpellSlot, ISpell>();

        public SpellBook(IEnumerable<ISpell> spells)
        {
            spells.ForEach(AddSpell);
        }

        public ISpell GetSpell(SpellSlot slot)
        {
            if (!_spells.ContainsKey(slot))
                throw new InvalidOperationException($"Spell in slot {slot} does not exist");

            return _spells[slot];
        }

        public void AddSpell(ISpell spell)
        {
            if (_spells.ContainsKey(spell.Slot))
                throw new InvalidOperationException($"Spell already exists in slot {spell.Slot}");

            _spells.Add(spell.Slot, spell);
        }
    }
}
