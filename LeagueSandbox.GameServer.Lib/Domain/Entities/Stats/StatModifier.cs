using System;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Stats
{
    internal class StatModifier : IStatModifier
    {
        public float BaseValue { get; }
        public float BaseBonus { get; }
        public float PercentBaseBonus { get; }
        public float FlatBonus { get; }
        public float PercentBonus { get; }
        public bool StatModified => Math.Abs(BaseValue) > 0 ||
                                    Math.Abs(BaseBonus) > 0 ||
                                    Math.Abs(PercentBaseBonus) > 0 ||
                                    Math.Abs(FlatBonus) > 0 ||
                                    Math.Abs(PercentBonus) > 0;

        public StatModifier(float baseValue, float baseBonus, float percentBaseBonus, float flatBonus, float percentBonus)
        {
            BaseValue = baseValue;
            BaseBonus = baseBonus;
            PercentBaseBonus = percentBaseBonus;
            FlatBonus = flatBonus;
            PercentBonus = percentBonus;
        }

        public StatModifier() : this(0, 0, 0, 0, 0)
        {
        }
    }
}
