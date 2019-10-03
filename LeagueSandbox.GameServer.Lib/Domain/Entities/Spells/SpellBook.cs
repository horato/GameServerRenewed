using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using MoreLinq;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class SpellBook : ISpellBook
    {
        private readonly IDictionary<SpellSlot, ISpell> _spells = new ConcurrentDictionary<SpellSlot, ISpell>();
        private readonly IDictionary<ExtraSpellNumber, string> _extraSpells;

        public ISpellInstance CurrentSpell { get; private set; }
        public int SkillPoints { get; private set; }

        public SpellBook(ISpellInstance currentSpell, int skillPoints, IEnumerable<ISpell> spells, IDictionary<ExtraSpellNumber, string> extraSpells)
        {
            CurrentSpell = currentSpell;
            SkillPoints = skillPoints;
            spells.ForEach(AddSpell);
            _extraSpells = new ReadOnlyDictionary<ExtraSpellNumber, string>(extraSpells);
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

        public string GetExtraSpell(ExtraSpellNumber number)
        {
            if(!_extraSpells.ContainsKey(number))
                throw new InvalidOperationException($"Extra spell {number} doesn't exist");

            return _extraSpells[number];
        }

        public void SkillPointUsed()
        {
            if (SkillPoints < 1)
                throw new InvalidOperationException("Used non-existent skill point");

            SkillPoints--;
        }

        public bool IsCastingSpell()
        {
            return CurrentSpell != null;
        }

        public void BeginCasting(ISpellInstance spell)
        {
            if (IsCastingSpell())
                throw new InvalidOperationException("A spell is already being cast");

            CurrentSpell = spell;
        }

        public void CastingFinished()
        {
            if (!IsCastingSpell())
                throw new InvalidOperationException("Nothing is being casted");

            CurrentSpell = null;
        }
    }
}
