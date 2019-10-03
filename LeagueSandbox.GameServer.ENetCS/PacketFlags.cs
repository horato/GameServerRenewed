﻿#region

using System;

#endregion

namespace LeagueSandbox.GameServer.ENetCS
{
    [Flags]
    public enum PacketFlags
    {
        None = 0,
        Reliable = 1 << 0,
        Unsequenced = 1 << 1,
        NoAllocate = 1 << 2
    }
}