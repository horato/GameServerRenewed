using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    /// <summary> Used in stats update </summary>
    public enum SummonerSpellId : uint
    {
        D = 16u << 0,
        F = 16u << 1
    }
}
