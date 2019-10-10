using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain
{
    internal class GameBuilder : EntityBuilderBase<Game>
    {
        private IMap _map = new MapBuilder().Build();
        private bool _isPaused = true;
        private float _gameTimeElapsed = 214.2f;
        private float _simSpeed = 1;

        public GameBuilder WithMap(IMap map)
        {
            _map = map;
            return this;
        }

        public GameBuilder WithIsPaused(bool isPaused)
        {
            _isPaused = isPaused;
            return this;
        }

        public GameBuilder WithGameTimeElapsed(float elapsed)
        {
            _gameTimeElapsed = elapsed;
            return this;
        }

        public GameBuilder WithSimSpeed(float simSpeed)
        {
            _simSpeed = simSpeed;
            return this;
        }

        public override Game Build()
        {
            var instance = new Game(_map, _isPaused, _gameTimeElapsed, _simSpeed);

            return instance;
        }
    }
}
