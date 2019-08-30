using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal enum CreateHeroDeath : uint
    {
        Alive = 0,
        Zombie = 1,
        Dead = 2
    }
}
