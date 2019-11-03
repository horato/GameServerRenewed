using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal enum DamageResultType : byte
    {
        Invulnerable = 0,
        InvulnerableNoMessage = 1,
        Dodge = 2,
        Critical = 3,
        Normal = 4,
        Miss = 5
    }
}
