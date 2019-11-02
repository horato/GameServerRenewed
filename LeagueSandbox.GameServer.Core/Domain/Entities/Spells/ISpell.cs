using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface ISpell
    {
        ISpellData SpellData { get; }
        IBaseSpellData BaseSpellData { get; }
        SpellSlot Slot { get; }
        int Level { get; }
        float Cooldown { get; }
        float ManaCost { get; }
        float CastRange { get; }
        float ChannelDuration { get; }
        string SpellName { get; }
        int AmmoUsed { get; }
        float AmmoRechargeTime { get; }
        int MaxLevel { get; }
        SpellState State { get; }
        float CooldownRemaining { get; }

        void SetLevel(int level);
        bool HasFlag(SpellFlags flag);
        void StartCooldown();
        void CooldownProgress(float secondsDiff);
        void CooldownFinished();
    }
}