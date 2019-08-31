using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class ItemData
    {
        public uint ItemID { get; }
        public byte Slot { get; }
        public byte ItemsInSlot { get; }
        public byte SpellCharges { get; }

        public ItemData(uint itemId, byte slot, byte itemsInSlot, byte spellCharges)
        {
            ItemID = itemId;
            Slot = slot;
            ItemsInSlot = itemsInSlot;
            SpellCharges = spellCharges;
        }
    }
}
