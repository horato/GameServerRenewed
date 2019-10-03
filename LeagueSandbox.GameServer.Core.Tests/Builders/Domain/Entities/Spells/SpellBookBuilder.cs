using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Spells
{
    internal class SpellBookBuilder : EntityBuilderBase<SpellBook>
    {
        private ISpellInstance _currentSpell;
        private int _skillPoints = 21;
        private IEnumerable<Spell> _spells = new List<Spell>();

        public SpellBookBuilder WithCurrentSpell(ISpellInstance currentSpell)
        {
            _currentSpell = currentSpell;
            return this;
        }

        public SpellBookBuilder WithSkillPoints(int skillPoints)
        {
            _skillPoints = skillPoints;
            return this;
        }

        public SpellBookBuilder WithSpells(IEnumerable<Spell> spells)
        {
            _spells = spells ?? new List<Spell>();
            return this;
        }

        public override SpellBook Build()
        {
            var instance = new SpellBook(_currentSpell, _skillPoints, _spells);

            return instance;
        }
    }
}
