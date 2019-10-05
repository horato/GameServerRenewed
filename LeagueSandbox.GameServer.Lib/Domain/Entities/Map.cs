using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities
{
    internal class Map : IMap
    {
        private readonly IDictionary<int, float> _expCurveDictionary;

        public MapType Id { get; }
        public int MaxLevel { get; }
        public float MaxExp { get; }

        public Map(MapType id, IDictionary<int, float> expCurveDictionary)
        {
            Id = id;
            _expCurveDictionary = expCurveDictionary;
            MaxLevel = expCurveDictionary.Keys.Max();
            MaxExp = expCurveDictionary.Values.Max();
        }

        public float GetExpNeededForLevel(int level)
        {
            if (level > MaxLevel)
                throw new InvalidOperationException($"Data for level {level} not found. Max level is {MaxLevel}");
            if (!_expCurveDictionary.ContainsKey(level))
                throw new InvalidOperationException($"Data for level {level} not found");

            return _expCurveDictionary[level];
        }

        public int GetLevelFromExp(float exp)
        {
            var level = 1;
            foreach (var kvp in _expCurveDictionary)
            {
                if (exp > kvp.Value && level < kvp.Key)
                    level = kvp.Key;
            }

            return level;
        }
    }
}
