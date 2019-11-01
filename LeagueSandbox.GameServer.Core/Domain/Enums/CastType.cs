using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    /// <summary> Do not change. Used in json. </summary>
    public enum CastType
    {
        Instant = 1,
        Missile = 2,
        ChainMissile = 3,
        ArcMissile = 4,
        CircleMissile = 5,
        ScriptedMissile = 6
    }
}
