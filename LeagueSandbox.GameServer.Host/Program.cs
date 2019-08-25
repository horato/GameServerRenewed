using System;
using System.Diagnostics;
using LeagueSandbox.GameServer.Core.Logging;

namespace LeagueSandbox.GameServer.Host
{
	public class Program
	{
		private static Lib.GameServer _gameServer;

		public static void Main(string[] args)
		{
			LoggerProvider.GetLogger().Info("Starting server");
			LaunchGameServer();
			LoggerProvider.GetLogger().Info("Server started.");
			LoggerProvider.GetLogger().Info("Press enter to stop.");

			Console.ReadLine();

			LoggerProvider.GetLogger().Info("Stopping server.");
			StopGameServer();
			LoggerProvider.GetLogger().Info("Server stopped.");

			Console.ReadLine();
		}

		private static void LaunchGameServer()
		{
			if (_gameServer != null)
				throw new InvalidOperationException("Server is already initialized");

			_gameServer = new Lib.GameServer();
			_gameServer.Start();
		}

		private static void StopGameServer()
		{
			if (_gameServer == null)
				throw new InvalidOperationException("Server is not initialized");

			_gameServer.Stop();
			_gameServer = null;
		}
	}
}
