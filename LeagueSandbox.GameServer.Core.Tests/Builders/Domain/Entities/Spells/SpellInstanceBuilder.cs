using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Spells
{
    internal class SpellInstanceBuilder : EntityBuilderBase<SpellInstance>
    {
        private ISpell _definition;
        private SpellInstanceState _state;
        private float _castTimeRemaining;
        private float _channelTimeRemaining;



        public SpellInstanceBuilder WithDefinition(ISpell definition)
        {
            _definition = definition;
            return this;
        }

        public SpellInstanceBuilder WithState(SpellInstanceState state)
        {
            _state = state;
            return this;
        }

        public SpellInstanceBuilder WithCastTimeRemaining(float castTimeRemaining)
        {
            _castTimeRemaining = castTimeRemaining;
            return this;
        }

        public SpellInstanceBuilder WithChannelTimeRemaining(float channelTimeRemaining)
        {
            _channelTimeRemaining = channelTimeRemaining;
            return this;
        }


        public override SpellInstance Build()
        {
            var instance = new SpellInstance(_definition, _state, _castTimeRemaining, _channelTimeRemaining);

            return instance;
        }
    }
}
