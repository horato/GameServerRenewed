using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.Enums
{
    internal enum SpellSlot : byte
    {
        Spell1 = 0x00,
        Spell2 = 0x01,
        Spell3 = 0x02,
        Ultimate = 0x03,
        Summoner1 = 0x04,
        Summoner2 = 0x05,
        Trinket = 0x06,
        BluePill = 0x07,
        ExtraItem2 = 0x08,
        TemporaryItemSlotStart = 0x09,
        Respawn = 0x10,
        Use = 0x11,
        Passive = 0x12,
        BaseAttack = 0x40,
        ExtraAttack1 = 0x41,
        ExtraAttack2 = 0x42,
        ExtraAttack3 = 0x43,
        ExtraAttack4 = 0x44,
        ExtraAttack5 = 0x45,
        ExtraAttack6 = 0x46,
        ExtraAttack7 = 0x47,
        ExtraAttack8 = 0x48,
        CritAttack = 0x49,
        ExtraCritAttack1 = 0x4A,
        ExtraCritAttack2 = 0x4B,
        ExtraCritAttack3 = 0x4C,
        ExtraCritAttack4 = 0x4D,
        ExtraCritAttack5 = 0x4E,
        ExtraCritAttack6 = 0x4F,
        ExtraCritAttack7 = 0x50,
        ExtraCritAttack8 = 0x51,
        Slotless = 0xFF,
    }
}
