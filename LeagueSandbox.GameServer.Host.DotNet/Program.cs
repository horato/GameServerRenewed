using LeagueSandbox.GameServer.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSandbox.GameServer.Host.DotNet
{
    public class Program
    {
        private static Lib.GameServer _gameServer;

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting server");
            LaunchGameServer();
            Console.WriteLine("Server started.");
            Console.WriteLine("Press enter to stop.");

            Console.ReadLine();

            Console.WriteLine("Stopping server.");
            StopGameServer();
            Console.WriteLine("Server stopped.");

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
