using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using MoreLinq;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class SpellBook : ISpellBook
    {
        private readonly IDictionary<SpellSlot, ISpell> _spells = new ConcurrentDictionary<SpellSlot, ISpell>();

        public ISpellInstance CurrentSpell { get; private set; }
        public int SkillPoints { get; private set; }

        public SpellBook(ISpellInstance currentSpell, int skillPoints, IEnumerable<ISpell> spells)
        {
            CurrentSpell = currentSpell;
            SkillPoints = skillPoints;
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

        public IEnumerable<ISpell> GetAllSpells()
        {
            return _spells.Values;
        }

        public void SkillPointUsed()
        {
            if (SkillPoints < 1)
                throw new InvalidOperationException("Used non-existent skill point");

            SkillPoints--;
        }
    }
}
