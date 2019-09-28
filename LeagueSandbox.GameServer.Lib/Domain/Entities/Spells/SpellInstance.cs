using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class SpellInstance : ISpellInstance
    {
        public ISpell Definition { get; }
        public SpellInstanceState State { get; private set; }
        public float CastTimeRemaining { get; private set; }
        public float ChannelTimeRemaining { get; private set; }

        public SpellInstance(ISpell definition, SpellInstanceState state, float castTimeRemaining, float channelTimeRemaining)
        {
            Definition = definition;
            State = state;
            CastTimeRemaining = castTimeRemaining;
            ChannelTimeRemaining = channelTimeRemaining;
        }

        public void UpdateState(SpellInstanceState state)
        {
            State = state;
        }

        public void UpdateCastTimeRemaining(float castTime)
        {
            if (castTime < 0)
                throw new InvalidOperationException("Remaining cooldown must be greater or equal to 0");

            CastTimeRemaining = castTime;
        }

        public void UpdateChannelTimeRemaining(float channelTime)
        {
            if (channelTime < 0)
                throw new InvalidOperationException("Remaining cooldown must be greater or equal to 0");

            ChannelTimeRemaining = channelTime;
        }
    }
}
