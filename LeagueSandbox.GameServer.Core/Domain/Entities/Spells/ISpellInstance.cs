using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface ISpellInstance
    {
        ISpell Definition { get; }
        SpellInstanceState State { get; }
        float CastTimeRemaining { get; }
        float ChannelTimeRemaining { get; }

        void UpdateState(SpellInstanceState state);
        void UpdateCastTimeRemaining(float castTime);
        void UpdateChannelTimeRemaining(float channelTime);
    }
}