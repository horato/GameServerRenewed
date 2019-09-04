using System;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    [Flags]
    public enum SpellSlot
    {
        Q = 1,
        W = 2,
        E = 4,
        R = 8,
        D = 16,
        F = 32
    }
}
