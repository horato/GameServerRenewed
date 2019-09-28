using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    /// <summary> Do not change. Used in json. </summary>
    public enum CastType
    {
        Instant = 0,
        Missile = 1,
        ChainMissile = 2,
        ArcMissile = 3,
        CircleMissile = 4,
        ScriptedMissile = 5
    }
}
