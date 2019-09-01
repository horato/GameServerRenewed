using System;

namespace LeagueSandbox.GameServer.Utils.NavGrid
{
    [Flags]
    public enum NavigationGridCellFlags : ushort
    {
        None = 0x00,
        HasGrass = 0x01,
        NotPassable = 0x02,
        Busy = 0x04,
        Targetted = 0x08,
        Marked = 0x10,
        PathedOn = 0x20,
        SeeThrough = 0x40,
        OtherDirectionEndToStart = 0x80,
        HasGlobalVision = 0x100,
    }
}