using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    [Flags]
    public enum SpellSlot
    {
        Q = 1 << 0,
        W = 1 << 1,
        E = 1 << 2,
        R = 1 << 3,
        D = 1 << 4,
        F = 1 << 5,
        ExtraSpell1 = 1 << 6,
        ExtraSpell2 = 1 << 7,
        ExtraSpell3 = 1 << 8,
        ExtraSpell4 = 1 << 9,
        ExtraSpell5 = 1 << 10,
        ExtraSpell6 = 1 << 11,
        ExtraSpell7 = 1 << 12,
        ExtraSpell8 = 1 << 13,
        ExtraSpell9 = 1 << 14,
        ExtraSpell10 = 1 << 15,
        ExtraSpell11 = 1 << 16,
        ExtraSpell12 = 1 << 17,
        ExtraSpell13 = 1 << 18,
        ExtraSpell14 = 1 << 19,
    }

    public static class SpellSlotExtensions
    {
        public static bool IsClassicSpell(this SpellSlot slot)
        {
            switch (slot)
            {
                case SpellSlot.Q:
                case SpellSlot.W:
                case SpellSlot.E:
                case SpellSlot.R:
                    return true;
                case SpellSlot.D:
                case SpellSlot.F:
                case SpellSlot.ExtraSpell1:
                case SpellSlot.ExtraSpell2:
                case SpellSlot.ExtraSpell3:
                case SpellSlot.ExtraSpell4:
                case SpellSlot.ExtraSpell5:
                case SpellSlot.ExtraSpell6:
                case SpellSlot.ExtraSpell7:
                case SpellSlot.ExtraSpell8:
                case SpellSlot.ExtraSpell9:
                case SpellSlot.ExtraSpell10:
                case SpellSlot.ExtraSpell11:
                case SpellSlot.ExtraSpell12:
                case SpellSlot.ExtraSpell13:
                case SpellSlot.ExtraSpell14:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
            }
        }
    }
}
