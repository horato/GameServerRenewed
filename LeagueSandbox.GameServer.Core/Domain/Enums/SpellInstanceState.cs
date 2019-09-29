using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    public enum SpellInstanceState
    {
        PreparingToCast = 1,
        Casting = 2,
        Channeling = 3,
        Finished = 4
    }
}
