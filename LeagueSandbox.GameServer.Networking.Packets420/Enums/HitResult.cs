using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    public enum HitResult : byte
    {
        Normal = 0x0,
        Critical = 0x1,
        Dodge = 0x2,
        Miss = 0x3,
    }
}
