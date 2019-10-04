using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    public enum MissileState
    {
        Created = 1,
        Traveling = 2,
        Arrived = 3,
        Terminated = 4
    }
}
