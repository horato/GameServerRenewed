using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    public enum AutoAttackState
    {
        Preparing = 1,
        Attacking = 2,
        Windup = 3,
        Finished = 4
    }
}
