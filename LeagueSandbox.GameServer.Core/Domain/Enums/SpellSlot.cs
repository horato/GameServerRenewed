using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    /// <summary> Do not change. Used in json. </summary>
    [Flags]
    public enum SpellSlot : long
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
        ExtraSpell15 = 1 << 20,
        ExtraSpell16 = 1 << 21,
        BaseAttack = 1 << 22,
        ExtraAttack1 = 1 << 23,
        ExtraAttack2 = 1 << 24,
        ExtraAttack3 = 1 << 25,
        ExtraAttack4 = 1 << 26,
        ExtraAttack5 = 1 << 27,
        ExtraAttack6 = 1 << 28,
        ExtraAttack7 = 1 << 29,
        ExtraAttack8 = 1 << 30,
        CritAttack = 1L << 31,
        ExtraCritAttack1 = 1L << 32,
        ExtraCritAttack2 = 1L << 33,
        ExtraCritAttack3 = 1L << 34,
        ExtraCritAttack4 = 1L << 35,
        ExtraCritAttack5 = 1L << 36,
        ExtraCritAttack6 = 1L << 37,
        ExtraCritAttack7 = 1L << 38,
        ExtraCritAttack8 = 1L << 39,
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
                case SpellSlot.ExtraSpell15:
                case SpellSlot.ExtraSpell16:
                case SpellSlot.BaseAttack:
                case SpellSlot.ExtraAttack1:
                case SpellSlot.ExtraAttack2:
                case SpellSlot.ExtraAttack3:
                case SpellSlot.ExtraAttack4:
                case SpellSlot.ExtraAttack5:
                case SpellSlot.ExtraAttack6:
                case SpellSlot.ExtraAttack7:
                case SpellSlot.ExtraAttack8:
                case SpellSlot.CritAttack:
                case SpellSlot.ExtraCritAttack1:
                case SpellSlot.ExtraCritAttack2:
                case SpellSlot.ExtraCritAttack3:
                case SpellSlot.ExtraCritAttack4:
                case SpellSlot.ExtraCritAttack5:
                case SpellSlot.ExtraCritAttack6:
                case SpellSlot.ExtraCritAttack7:
                case SpellSlot.ExtraCritAttack8:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
            }
        }

        public static bool IsAutoAttack(this SpellSlot slot)
        {
            switch (slot)
            {
                case SpellSlot.BaseAttack:
                case SpellSlot.ExtraAttack1:
                case SpellSlot.ExtraAttack2:
                case SpellSlot.ExtraAttack3:
                case SpellSlot.ExtraAttack4:
                case SpellSlot.ExtraAttack5:
                case SpellSlot.ExtraAttack6:
                case SpellSlot.ExtraAttack7:
                case SpellSlot.ExtraAttack8:
                case SpellSlot.CritAttack:
                case SpellSlot.ExtraCritAttack1:
                case SpellSlot.ExtraCritAttack2:
                case SpellSlot.ExtraCritAttack3:
                case SpellSlot.ExtraCritAttack4:
                case SpellSlot.ExtraCritAttack5:
                case SpellSlot.ExtraCritAttack6:
                case SpellSlot.ExtraCritAttack7:
                case SpellSlot.ExtraCritAttack8:
                    return true;
                case SpellSlot.Q:
                case SpellSlot.W:
                case SpellSlot.E:
                case SpellSlot.R:
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
                case SpellSlot.ExtraSpell15:
                case SpellSlot.ExtraSpell16:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
            }
        }
    }
}
