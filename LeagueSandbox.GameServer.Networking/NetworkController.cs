using System;
using System.Threading;
using LeagueSandbox.GameServer.Networking.Communication;
using LeagueSandbox.GameServer.Networking.Core.Encryption;
using Unity;

namespace LeagueSandbox.GameServer.Networking
{
	public class NetworkController : INetworkController
	{
		private readonly IUnityContainer _container;
		private IServerHost _serverHost;
		private Thread _serverThread;
		private bool _isRunning;

		public NetworkController(IUnityContainer container)
		{
			_container = container;
		}

		public void Initialize(string host, ushort port, string blowfishKey)
		{
			var crypter = _container.Resolve<BlowfishCrypter>();
			crypter.Initialize(blowfishKey);
			_container.RegisterInstance<IBlowfishCrypter>(crypter);

			_serverHost = _container.Resolve<ServerHost>();
			_serverHost.InitServer(host, port);
			_container.RegisterInstance<IServerHost>(_serverHost);
		}

		public void StartNetworkLoop()
		{
			if (_isRunning)
				throw new InvalidOperationException("Server is already running");

			_isRunning = true;
			_serverThread = new Thread(DoNetworkLoop);
			_serverThread.Start();
		}

		private void DoNetworkLoop()
		{
			while (_isRunning)
			{
				_serverHost.NetLoop();
			}
		}

		public void StopNetworkLoop()
		{
			_isRunning = false;
            _serverThread.Join();
        }
	}
}
