using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    public enum PingCategory
    {
        Default = 1,
        Charge = 2,
        Danger = 3,
        Missing = 4,
        OnMyWay = 5,
        GetBack = 6,
        Assist = 7
    }
}
