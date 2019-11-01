using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Spells
{
    internal class SpellBuilder : EntityBuilderBase<Spell>
    {
        private SpellSlot _slot = SpellSlot.Q;
        private int _level = 2;
        private SpellState _state = SpellState.Cooldown;
        private float _cooldownRemaining = 8.5f;
        private IBaseSpellData _baseSpellData; //TODO: builder?
        private ISpellData _spellData; //TODO: builder?

        public SpellBuilder WithSlot(SpellSlot slot)
        {
            _slot = slot;
            return this;
        }

        public SpellBuilder WithLevel(int level)
        {
            _level = level;
            return this;
        }

        public SpellBuilder WithState(SpellState state)
        {
            _state = state;
            return this;
        }

        public SpellBuilder WithCooldownRemaining(float cooldownRemaining)
        {
            _cooldownRemaining = cooldownRemaining;
            return this;
        }

        public override Spell Build()
        {
            var instance = new Spell(_slot, _level, _cooldownRemaining, _state, _baseSpellData, _spellData);

            return instance;
        }
    }
}