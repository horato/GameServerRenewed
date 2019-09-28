using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Domain.Enums
{
    /// <summary> Do not edit. Used in json. </summary>
    public enum TargetingType
    {
        Self = 0,
        Target = 1,
        Area = 2,
        Cone = 3,
        SelfAOE = 4,
        TargetOrLocation = 5,
        Location = 6,
        Direction = 7,
        DragDirection = 8,
        LineTargetToCaster = 9
    }
}
