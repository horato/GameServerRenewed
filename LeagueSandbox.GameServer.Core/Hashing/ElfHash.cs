using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Hashing
{
    public class ElfHash
    {
        public static uint CalculateSpellNameHash(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            var lowercaseStr = str.ToLower();
            uint hash = 0;

            for (var i = 0; i < lowercaseStr.Length; i++)
            {
                hash = (hash << 4) + ((byte)lowercaseStr[i]);

                var x = hash & 0xF0000000;
                if (x != 0)
                {
                    hash ^= (x >> 24);
                }

                hash &= ~x;
            }

            return hash;
        }
    }
}
