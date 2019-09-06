using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal enum ObjAnimatedBuildingFieldMask : uint
    {
        FM2_HealthCurrent = 1 << 0,
        FM2_Invulnerable = 1 << 1,
        
        FM6_IsTargetable = 1 << 0,
        FM6_IsTargetableToTeam = 1 << 1,
    }
}
