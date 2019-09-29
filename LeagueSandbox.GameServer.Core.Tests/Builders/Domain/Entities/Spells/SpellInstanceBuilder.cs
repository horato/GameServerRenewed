using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Spells
{
    internal class SpellInstanceBuilder : EntityBuilderBase<SpellInstance>
    {
        private ISpell _definition = new SpellBuilder().Build();
        private SpellInstanceState _state = SpellInstanceState.Channeling;
        private float _castTimeRemaining = 2.1f;
        private float _channelTimeRemaining = 1.7f;
        private Vector2 _position = new Vector2(2145, 465);
        private Vector2 _endPosition = new Vector2(2170, 454);
        private IAttackableUnit _targetUnit = new ObjAiHeroBuilder().Build();
        private uint _futureProjectileNetId = 0xFF445455;
        private uint _instanceNetId = 0xFF445456;

        public SpellInstanceBuilder WithDefinition(ISpell definition)
        {
            _definition = definition;
            return this;
        }

        public SpellInstanceBuilder WithState(SpellInstanceState state)
        {
            _state = state;
            return this;
        }

        public SpellInstanceBuilder WithCastTimeRemaining(float castTimeRemaining)
        {
            _castTimeRemaining = castTimeRemaining;
            return this;
        }

        public SpellInstanceBuilder WithChannelTimeRemaining(float channelTimeRemaining)
        {
            _channelTimeRemaining = channelTimeRemaining;
            return this;
        }

        public SpellInstanceBuilder WithStartPosition(Vector2 startPosition)
        {
            _position = startPosition;
            return this;
        }

        public SpellInstanceBuilder WithEndPosition(Vector2 endPosition)
        {
            _endPosition = endPosition;
            return this;
        }

        public SpellInstanceBuilder WithTarget(IAttackableUnit target)
        {
            _targetUnit = target;
            return this;
        }

        public SpellInstanceBuilder WithFutureProjectileNetId(uint futureProjectileNetId)
        {
            _futureProjectileNetId = futureProjectileNetId;
            return this;
        }

        public SpellInstanceBuilder WithInstanceNetId(uint instanceNetId)
        {
            _instanceNetId = instanceNetId;
            return this;
        }

        public override SpellInstance Build()
        {
            var instance = new SpellInstance(_definition, _state, _castTimeRemaining, _channelTimeRemaining, _position, _endPosition, _targetUnit, _futureProjectileNetId, _instanceNetId);

            return instance;
        }
    }
}
