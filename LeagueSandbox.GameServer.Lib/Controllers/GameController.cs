using System;
using System.Diagnostics;
using System.Threading;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Logging;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Lib.Services.Update;
using LeagueSandbox.GameServer.Utils.Providers;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal class GameController : IGameController
    {
        private readonly IGameFactory _gameFactory;
        private readonly IMapFactory _mapFactory;
        private readonly IUnityContainer _unityContainer;
        private readonly IGameUpdateService _gameUpdateService;
        private readonly IGameObjectController _gameObjectController;
        private readonly IServerInformationData _serverInformationData;
        private readonly IMapScriptProvider _mapScriptProvider;
        private readonly IGameObjectsCache _gameObjectsCache;
        private IGame _game;
        private Thread _gameThread;
        private bool _isRunning;
        private Stopwatch _refreshRateWatch;


        public GameController(IGameFactory gameFactory, IMapFactory mapFactory, IGameUpdateService gameUpdateService, IUnityContainer unityContainer, IGameObjectController gameObjectController, IServerInformationData serverInformationData, IMapScriptProvider mapScriptProvider, IGameObjectsCache gameObjectsCache)
        {
            _gameFactory = gameFactory;
            _mapFactory = mapFactory;
            _gameUpdateService = gameUpdateService;
            _unityContainer = unityContainer;
            _gameObjectController = gameObjectController;
            _serverInformationData = serverInformationData;
            _mapScriptProvider = mapScriptProvider;
            _gameObjectsCache = gameObjectsCache;
        }

        public void Initialize(MapType mapId)
        {
            if (_game != null)
                throw new InvalidOperationException("GameController is already initialized");

            var mapScript = _mapScriptProvider.ProvideMapScript(mapId);
            var data = mapScript.Initialize();

            var map = _mapFactory.CreateFromMapInitializationData(data);
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
            _refreshRateWatch = new Stopwatch();
            _refreshRateWatch.Start();
            while (_isRunning)
            {
                var diff = (float)_refreshRateWatch.Elapsed.TotalMilliseconds;
                _refreshRateWatch.Restart();

                if (!_game.IsPaused)
                    ProcessGameUpdate(diff);

                var remainingRefreshTime = _serverInformationData.RefreshRate - _refreshRateWatch.Elapsed;
                if (remainingRefreshTime.TotalMilliseconds > 0)
                    Thread.Sleep(remainingRefreshTime);
            }
        }

        private void ProcessGameUpdate(float diff)
        {
            try
            {
                //TODO: Could/Should we use multiple threads?
                _gameUpdateService.UpdateGame(_game, diff);
                _gameObjectController.UpdateObjects(diff);
                //TODO: Vision
                //TODO: Map - announces, minion spawns, fountain attacks?, surrender
            }
            catch (Exception e)
            {
                LoggerProvider.GetLogger().Error("An error occured during game loop", e);
            }
        }

        public void StopGameLoop()
        {
            _isRunning = false;
            _gameThread.Join();
        }
    }
}
