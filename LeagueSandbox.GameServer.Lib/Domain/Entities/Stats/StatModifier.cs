using System;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Stats
{
    internal class StatModifier : IStatModifier
    {
        public float BaseBonus { get; }
        public float PercentBaseBonus { get; }
        public float FlatBonus { get; }
        public float PercentBonus { get; }
        public bool StatModified => Math.Abs(BaseBonus) > MathConstants.COMPARE_EPSILON ||
                                    Math.Abs(PercentBaseBonus) > MathConstants.COMPARE_EPSILON ||
                                    Math.Abs(FlatBonus) > MathConstants.COMPARE_EPSILON ||
                                    Math.Abs(PercentBonus) > MathConstants.COMPARE_EPSILON;

        public StatModifier(float baseBonus, float percentBaseBonus, float flatBonus, float percentBonus)
        {
            BaseBonus = baseBonus;
            PercentBaseBonus = percentBaseBonus;
            FlatBonus = flatBonus;
            PercentBonus = percentBonus;
        }

        public StatModifier() : this(0, 0, 0, 0)
        {
        }
    }
}
