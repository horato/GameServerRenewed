﻿using System;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Config;
using LeagueSandbox.GameServer.Lib.Config.Startup;

namespace LeagueSandbox.GameServer.Host.DotNet
{
    public class Program
    {
        private static Lib.GameServer _gameServer;

        private const string HOST = "127.0.0.1";
        private const ushort PORT = 5119;
        private const string BLOWFISH_KEY = "17BLOhi6KZsTtldTsizvHg==";
        private const MapType MAP_ID = MapType.FlatTestMap;

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

            var players = new[] { new StartupPlayer(Rank.Diamond, "Test", "Ezreal", Team.Blue, 0, SummonerSpell.Heal, SummonerSpell.Flash, 2, 0), };
            var config = new StartupConfig(HOST, PORT, BLOWFISH_KEY, MAP_ID, players);

            _gameServer = new Lib.GameServer(config);
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