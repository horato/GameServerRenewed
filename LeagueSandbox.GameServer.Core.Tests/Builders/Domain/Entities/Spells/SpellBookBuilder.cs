using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Spells
{
    internal class SpellBookBuilder : EntityBuilderBase<SpellBook>
    {
        private IEnumerable<Spell> _spells = new List<Spell>();

        public SpellBookBuilder WithSpells(IEnumerable<Spell> spells)
        {
            _spells = spells ?? new List<Spell>();
            return this;
        }

        public override SpellBook Build()
        {
            var instance = new SpellBook(_spells);

            return instance;
        }
    }
}
