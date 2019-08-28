using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Stats
{
    public class Stat : IStat
    {
        public float BaseBonus { get; private set; }
        public float FlatBonus { get; private set; }
        public float BaseValue { get; private set; }
        public float PercentBonus { get; private set; }
        public float PercentBaseBonus { get; private set; }
        public float Total => ((BaseValue + BaseBonus) * (1 + PercentBaseBonus) + FlatBonus) * (1 + PercentBonus);

        public Stat(float baseValue, float baseBonus, float percentBaseBonus, float flatBonus, float percentBonus)
        {
            BaseValue = baseValue;
            BaseBonus = baseBonus;
            PercentBaseBonus = percentBaseBonus;
            FlatBonus = flatBonus;
            PercentBonus = percentBonus;
        }

        public Stat() : this(0, 0, 0, 0, 0)
        {

        }

        public bool ApplyStatModifier(IStatModifier statModifier)
        {
            if (!statModifier.StatModified)
                return false;

            BaseBonus += statModifier.BaseBonus;
            PercentBaseBonus += statModifier.PercentBaseBonus;
            FlatBonus += statModifier.FlatBonus;
            PercentBonus += statModifier.PercentBonus;

            return true;
        }

        public bool RemoveStatModifier(IStatModifier statModifier)
        {
            if (!statModifier.StatModified)
                return false;

            BaseBonus -= statModifier.BaseBonus;
            PercentBaseBonus -= statModifier.PercentBaseBonus;
            FlatBonus -= statModifier.FlatBonus;
            PercentBonus -= statModifier.PercentBonus;

            return true;
        }
    }
}
