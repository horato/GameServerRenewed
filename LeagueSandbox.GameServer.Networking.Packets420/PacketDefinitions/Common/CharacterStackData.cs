using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class CharacterStackData
    {
        public string SkinName { get; }
        public uint SkinID { get; }
        public bool OverrideSpells { get; }
        public bool ModelOnly { get; }
        public bool ReplaceCharacterPackage { get; }
        public uint ID { get; }

        public CharacterStackData(string skinName, uint skinId, bool overrideSpells, bool modelOnly, bool replaceCharacterPackage, uint id)
        {
            SkinName = skinName;
            SkinID = skinId;
            OverrideSpells = overrideSpells;
            ModelOnly = modelOnly;
            ReplaceCharacterPackage = replaceCharacterPackage;
            ID = id;
        }
    }
}
