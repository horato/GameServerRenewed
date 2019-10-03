using System;
using System.IO;
using System.Reflection;
using log4net;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Core.Logging;
using LeagueSandbox.GameServer.Lib.Config;
using LeagueSandbox.GameServer.Lib.Controllers;
using LeagueSandbox.GameServer.Lib.Scripting;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Networking;
using LeagueSandbox.GameServer.Scripts;
using Unity;

namespace LeagueSandbox.GameServer.Lib
{
    public class GameServer
    {
        private readonly IUnityContainer _container;

        private const string VERSION_STRING = "Version 4.20.0.315 [PUBLIC]";

        public GameServer(StartupConfig config) : this(new UnityContainer(), config)
        {
        }

        public GameServer(IUnityContainer container, StartupConfig config)
        {
            _container = container;

            InitializeLogger();
            InitializeServerInformationData();
            InitializeDependencyInjection();
            InitializeScripts();
            InitializeNetworking(config);
            InitializePathing(config);
            InitializeGameObjects(config);
            InitializeGameController(config);
        }

        private void InitializeLogger()
        {
            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(repository, new FileInfo("Log4net.config"));
        }

        private void InitializeServerInformationData()
        {
            LoggerProvider.GetLogger().Info("Initializing server info");

            var infoData = new ServerInformationData(DateTime.Now, VERSION_STRING);
            _container.RegisterInstance<IServerInformationData>(infoData);
        }

        private void InitializeDependencyInjection()
        {
            LoggerProvider.GetLogger().Info("Initializing DI");

            _container.RegisterInstance<IUnityContainer>(_container);
            var assemblies = _container.Resolve<IServerInformationData>().GetAllApplicationAssemblies();
            _container.Install(assemblies);
        }

        private void InitializeScripts()
        {
            LoggerProvider.GetLogger().Info("Initializing scripts");

            var provider = _container.Resolve<SpellScriptProvider>();
            var scriptsProjectName = ScriptsAssemblyDefiningType.Assembly.GetName().Name;
            provider.Initialize($"../../../../{scriptsProjectName}"); //TODO: configurable
            _container.RegisterInstance<ISpellScriptProvider>(provider);
        }

        private void InitializeNetworking(StartupConfig config)
        {
            LoggerProvider.GetLogger().Info("Initializing networking");

            var networking = _container.Resolve<NetworkController>();
            networking.Initialize(config.Host, config.Port, config.BlowfishKey);
            _container.RegisterInstance<INetworkController>(networking);
        }

        private void InitializePathing(StartupConfig config)
        {
            LoggerProvider.GetLogger().Info("Initializing pathing");

            var service = _container.Resolve<PathingService>();
            service.Initialize(config.Map);
            _container.RegisterInstance<IPathingService>(service);
        }

        private void InitializeGameObjects(StartupConfig config)
        {
            LoggerProvider.GetLogger().Info("Initializing GameObjectController");

            var controller = _container.Resolve<GameObjectController>();
            controller.InitializeGameObjects(config.Players, config.Map);
            _container.RegisterInstance<IGameObjectController>(controller);
        }

        private void InitializeGameController(StartupConfig config)
        {
            LoggerProvider.GetLogger().Info("Initializing GameController");

            var controller = _container.Resolve<GameController>();
            controller.Initialize(config.Map);
            _container.RegisterInstance<IGameController>(controller);
        }

        public void Start()
        {
            LoggerProvider.GetLogger().Info("Starting loops");

            _container.Resolve<IGameController>().StartGameLoop();
            _container.Resolve<INetworkController>().StartNetworkLoop();

            LoggerProvider.GetLogger().Info("Loops started");
        }

        public void Stop()
        {
            LoggerProvider.GetLogger().Info("Stopping loops");

            _container.Resolve<IGameController>().StopGameLoop();
            _container.Resolve<INetworkController>().StopNetworkLoop();

            LoggerProvider.GetLogger().Info("Loops stopped");
        }
    }
}
