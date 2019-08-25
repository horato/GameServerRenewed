using System;
using System.IO;
using System.Linq;
using System.Reflection;
using log4net;
using LeagueSandbox.GameServer.Core;
using LeagueSandbox.GameServer.Core.DependencyInjection;
using LeagueSandbox.GameServer.Core.Logging;
using LeagueSandbox.GameServer.Networking;
using LeagueSandbox.GameServer.Networking.Packets420;
using Unity;

namespace LeagueSandbox.GameServer.Lib
{
    public class GameServer
    {
        private readonly IUnityContainer _container;

        private const string HOST = "127.0.0.1";
        private const ushort PORT = 5119;
        private const string BLOWFISH_KEY = "17BLOhi6KZsTtldTsizvHg==";

        public GameServer() : this(new UnityContainer())
        {
        }

        public GameServer(IUnityContainer container)
        {
            _container = container;

            InitializeLogger();
            InitializeServerInformationData();
            InitializeDependencyInjection();
            InitializeNetworking();
        }

        private void InitializeLogger()
        {
            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(repository, new FileInfo("Log4net.config"));
        }

        private void InitializeServerInformationData()
        {
            // Might add launch time/etc in the future
            var infoData = new ServerInformationData();

            _container.RegisterInstance<IServerInformationData>(infoData);
        }

        private void InitializeDependencyInjection()
        {
            _container.RegisterInstance<IUnityContainer>(_container);

            var assemblies = _container.Resolve<IServerInformationData>().GetAllApplicationAssemblies();
            _container.Install(assemblies);
        }

        private void InitializeNetworking()
        {
            var networking = _container.Resolve<ServerNetworking>();
            networking.Initialize(HOST, PORT, BLOWFISH_KEY);
            _container.RegisterInstance<IServerNetworking>(networking);
        }

        public void Start()
        {
            _container.Resolve<IServerNetworking>().StartNetworkLoop();
        }

        public void Stop()
        {
            _container.Resolve<IServerNetworking>().StopNetworkLoop();
        }
    }
}
