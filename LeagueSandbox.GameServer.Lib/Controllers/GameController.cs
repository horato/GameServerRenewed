using System;
using System.Diagnostics;
using System.Threading;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Services;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal class GameController : IGameController
    {
        private readonly IGameFactory _gameFactory;
        private readonly IMapFactory _mapFactory;
        private readonly IUnityContainer _unityContainer;
        private readonly IGameUpdateService _gameUpdateService;
        private IGame _game;
        private Thread _gameThread;
        private bool _isRunning;
        private Stopwatch _lastMapDurationWatch;

        protected const double REFRESH_RATE = 1000.0 / 30.0; // 30 fps

        public GameController(IGameFactory gameFactory, IMapFactory mapFactory, IGameUpdateService gameUpdateService, IUnityContainer unityContainer)
        {
            _gameFactory = gameFactory;
            _mapFactory = mapFactory;
            _gameUpdateService = gameUpdateService;
            _unityContainer = unityContainer;
        }

        public void Initialize(MapType mapId)
        {
            if (_game != null)
                throw new InvalidOperationException("GameController is already initialized");

            var map = _mapFactory.CreateNew(mapId);
            _unityContainer.RegisterInstance<IMap>(map);

            _game = _gameFactory.CreateNew(map);
            _unityContainer.RegisterInstance<IGame>(_game);
        }

        public void StartGameLoop()
        {
            if (_isRunning)
                throw new InvalidOperationException("Server is already running");

            _isRunning = true;
            _gameThread = new Thread(DoGameLoop);
            _gameThread.Start();
        }

        private void DoGameLoop()
        {
            _lastMapDurationWatch = new Stopwatch();
            _lastMapDurationWatch.Start();
            while (_isRunning)
            {
                if (_lastMapDurationWatch.Elapsed.TotalMilliseconds + 1.0 > REFRESH_RATE)
                {
                    var diff = (float)_lastMapDurationWatch.Elapsed.TotalMilliseconds;
                    _lastMapDurationWatch.Restart();
                    _gameUpdateService.UpdateGame(_game, diff);
                }

                Thread.Sleep(1);
            }
        }

        public void StopGameLoop()
        {
            _isRunning = false;
            _gameThread.Join();
        }
    }
}
