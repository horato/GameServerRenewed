using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Config.Startup;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Config
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
