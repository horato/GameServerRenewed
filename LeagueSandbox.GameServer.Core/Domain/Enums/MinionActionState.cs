using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    public enum MinionActionState
    {
        Spawned = 1,
        Moving = 2,
        Attacking = 3,
        DestinationReached = 4
    }
}
