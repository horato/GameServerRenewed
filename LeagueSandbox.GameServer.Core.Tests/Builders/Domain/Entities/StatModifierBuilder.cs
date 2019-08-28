using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities
{
    internal class StatModifierBuilder : EntityBuilderBase<StatModifier>
    {
        private float _baseBonus = 3.4f;
        private float _percentBaseBonus = 3.5f;
        private float _flatBonus = 3.6f;
        private float _percentBonus = 3.7f;

        public StatModifierBuilder WithBaseBonus(float baseBonus)
        {
            _baseBonus = baseBonus;
            return this;
        }

        public StatModifierBuilder WithPercentBaseBonus(float percentBaseBonus)
        {
            _percentBaseBonus = percentBaseBonus;
            return this;
        }

        public StatModifierBuilder WithFlatBonus(float flatBonus)
        {
            _flatBonus = flatBonus;
            return this;
        }

        public StatModifierBuilder WithPercentBonus(float percentBonus)
        {
            _percentBonus = percentBonus;
            return this;
        }

        public override StatModifier Build()
        {
            var instance = new StatModifier(_baseBonus, _percentBaseBonus, _flatBonus, _percentBonus);

            return instance;
        }
    }
}