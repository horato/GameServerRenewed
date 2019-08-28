using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities
{
    internal class StatBuilder : EntityBuilderBase<Stat>
    {
        private float _baseBonus = 1.0f;
        private float _flatBonus = 2.0f;
        private float _baseValue = 3.0f;
        private float _percentBonus = 30.2f;
        private float _percentBaseBonus = 11.4f;

        public StatBuilder WithBaseBonus(float baseBonus)
        {
            _baseBonus = baseBonus;
            return this;
        }

        public StatBuilder WithFlatBonus(float flatBonus)
        {
            _flatBonus = flatBonus;
            return this;
        }

        public StatBuilder WithBaseValue(float baseValue)
        {
            _baseValue = baseValue;
            return this;
        }

        public StatBuilder WithPercentBonus(float percentBonus)
        {
            _percentBonus = percentBonus;
            return this;
        }

        public StatBuilder WithPercentBaseBonus(float percentBaseBonus)
        {
            _percentBaseBonus = percentBaseBonus;
            return this;
        }

        public override Stat Build()
        {
            var instance = new Stat(_baseValue, _baseBonus, _percentBaseBonus, _flatBonus, _percentBonus);

            return instance;
        }
    }
}