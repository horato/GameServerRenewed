using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    public enum SpellState
    {
        Ready,
        Casting,
        Cooldown,
        Channeling
    }
}
