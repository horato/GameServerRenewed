using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Stats
{
    internal class FlatStat : IFlatStat
    {
        public bool IsUpdated { get; private set; }

        public float CurrentValue { get; private set; }
        public float BonusPerLevel { get; private set; }
        public float RegenerationPer5 { get; private set; }

        public FlatStat(bool isUpdated, float currentValue, float bonusPerLevel, float regenerationPer5)
        {
            IsUpdated = isUpdated;
            CurrentValue = currentValue;
            BonusPerLevel = bonusPerLevel;
            RegenerationPer5 = regenerationPer5;
        }

        public bool ApplyStatModifier(IFlatStatModifier statModifier)
        {
            if (!statModifier.StatModified)
                return false;

            CurrentValue += statModifier.Value;
            BonusPerLevel += statModifier.BonusPerLevel;
            RegenerationPer5 += statModifier.RegenerationPer5;
            IsUpdated = true;

            return true;
        }

        public bool RemoveStatModifier(IFlatStatModifier statModifier)
        {
            if (!statModifier.StatModified)
                return false;

            CurrentValue -= statModifier.Value;
            BonusPerLevel -= statModifier.BonusPerLevel;
            RegenerationPer5 -= statModifier.RegenerationPer5;
            IsUpdated = true;

            return true;
        }

        public void OnStatUpdateSent()
        {
            IsUpdated = false;
        }
    }
}
