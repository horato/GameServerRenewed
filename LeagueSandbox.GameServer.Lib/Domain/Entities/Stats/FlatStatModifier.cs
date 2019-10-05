using System;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Stats
{
    internal class FlatStatModifier : IFlatStatModifier
    {
        public float Value { get; private set; }
        public float BonusPerLevel { get; private set; }
        public float RegenerationPer5 { get; private set; }
        public float RegenerationBonusPerLevel { get; }

        public bool StatModified => Math.Abs(Value) > 0 ||
                                    Math.Abs(BonusPerLevel) > 0 ||
                                    Math.Abs(RegenerationPer5) > 0 ||
                                    Math.Abs(RegenerationBonusPerLevel) > 0;


        public FlatStatModifier(float value, float bonusPerLevel, float regenerationPer5, float regenerationBonusPerLevel)
        {
            Value = value;
            BonusPerLevel = bonusPerLevel;
            RegenerationPer5 = regenerationPer5;
            RegenerationBonusPerLevel = regenerationBonusPerLevel;
        }

        public FlatStatModifier() : this(0, 0, 0, 0)
        {
        }
    }
}
