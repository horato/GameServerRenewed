using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Config.Startup;

namespace LeagueSandbox.GameServer.Lib.Config
{
    public class StartupConfig
    {
        public string Host { get; }
        public ushort Port { get; }
        public string BlowfishKey { get; }
        public MapType Map { get; }
        public IEnumerable<StartupPlayer> Players { get; }

        public StartupConfig(string host, ushort port, string blowfishKey, MapType map, IEnumerable<StartupPlayer> players)
        {
            Host = host;
            Port = port;
            BlowfishKey = blowfishKey;
            Map = map;
            Players = players;
        }
    }
}
