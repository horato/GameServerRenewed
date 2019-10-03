using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Hashing
{
    public static class SdbmHash
    {
        public static uint HashString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            var lowerCaseString = s.ToLower();
            uint hash = 0;
            foreach (var ch in lowerCaseString)
            {
                hash = ch + (hash << 6) + (hash << 16) - hash;
            }

            return hash;
        }

        public static uint HashCharacterName(string model, int skinId)
        {
            return HashString($"[Character]{model}{skinId:00}");
        }
    }
}
