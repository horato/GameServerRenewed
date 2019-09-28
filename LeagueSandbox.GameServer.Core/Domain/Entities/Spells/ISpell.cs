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
        string SpellName { get; }
        SpellState State { get; }

        float CooldownRemaining { get; }
        float CastTimeRemaining { get; }
    }
}