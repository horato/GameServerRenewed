using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities
{
    internal class FlatStatBuilder : EntityBuilderBase<FlatStat>
    {
        private bool _isUpdated = true;
        private float _currentValue = 245;
        private float _bonusPerLevel = 1.7f;
        private float _regenerationPer5 = 14.4f;

        public FlatStatBuilder WithIsUpdated(bool isUpdated)
        {
            _isUpdated = isUpdated;
            return this;
        }

        public FlatStatBuilder WithCurrentValue(float currentValue)
        {
            _currentValue = currentValue;
            return this;
        }

        public FlatStatBuilder WithBonusPerLevel(float bonusPerLevel)
        {
            _bonusPerLevel = bonusPerLevel;
            return this;
        }

        public FlatStatBuilder WithRegenerationPer5(float regenerationPer5)
        {
            _regenerationPer5 = regenerationPer5;
            return this;
        }

        public override FlatStat Build()
        {
            var instance = new FlatStat(_isUpdated, _currentValue, _bonusPerLevel, _regenerationPer5);

            return instance;
        }
    }
}
