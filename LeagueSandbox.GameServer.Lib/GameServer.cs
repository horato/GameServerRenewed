using System;
using System.IO;
using System.Reflection;
using log4net;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Lib.Config;
using LeagueSandbox.GameServer.Lib.Controllers;
using LeagueSandbox.GameServer.Networking;
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
            InitializeGameController(config);
            InitializeNetworking(config);
        }

        private void InitializeLogger()
        {
            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(repository, new FileInfo("Log4net.config"));
        }

        private void InitializeServerInformationData()
        {
            // Might add launch time/etc in the future
            var infoData = new ServerInformationData(DateTime.Now, VERSION_STRING);

            _container.RegisterInstance<IServerInformationData>(infoData);
        }

        private void InitializeDependencyInjection()
        {
            _container.RegisterInstance<IUnityContainer>(_container);

            var assemblies = _container.Resolve<IServerInformationData>().GetAllApplicationAssemblies();
            _container.Install(assemblies);
        }

        private void InitializeGameController(StartupConfig config)
        {
            var controller = _container.Resolve<GameController>();
            controller.Initialize(config.Map);
            _container.RegisterInstance<IGameController>(controller);
        }

        private void InitializeNetworking(StartupConfig config)
        {
            var networking = _container.Resolve<INetworkController>();
            networking.Initialize(config.Host, config.Port, config.BlowfishKey);
            _container.RegisterInstance<INetworkController>(networking);
        }

        public void Start()
        {
            _container.Resolve<IGameController>().StartGameLoop();
            _container.Resolve<INetworkController>().StartNetworkLoop();
        }

        public void Stop()
        {
            _container.Resolve<IGameController>().StopGameLoop();
            _container.Resolve<INetworkController>().StopNetworkLoop();
        }
    }
}
