using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface ISpell
    {
        SpellSlot Slot { get; }
        int Level { get; }
        float CastTime { get; }
        float Cooldown { get; }
        float ManaCost { get; }
        float CastRange { get; }
        float ChannelDuration { get; }
        string SpellName { get; }
        int MaxLevel { get; }
        SpellState State { get; }
        float CooldownRemaining { get; }

        void SetLevel(int level);
        void UpdateCooldownRemaining(float cooldownRemaining);
        void UpdateState(SpellState state);
    }
}