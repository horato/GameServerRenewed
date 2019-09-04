using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    [Flags]
    internal enum SpellSlot : byte
    {
        Spell1 = 0x00,
        Spell2 = 0x01,
        Spell3 = 0x02,
        Ultimate = 0x03,
        Trinket = 0x06,
        BluePill = 0x07,
        ExtraItem2 = 0x08,
        TemporaryItemSlotStart = 0x09,
        Respawn = 0x10,
        Use = 0x11,
        Passive = 0x12,
        Slotless = 0xFF,
    }
}
