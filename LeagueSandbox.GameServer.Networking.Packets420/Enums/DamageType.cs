using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal enum DamageType : byte
    {
        Physical = 0,
        Magic = 1,
        True = 2,
        Mixed = 3,
    }
}
