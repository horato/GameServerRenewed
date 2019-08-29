using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Lib.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Caches
{
    internal class PlayerCache : IPlayerCache
    {
        private readonly IDictionary<ulong, IPlayer> _players = new ConcurrentDictionary<ulong, IPlayer>();

        public void Add(ulong summonerId, IPlayer player)
        {
            if (PlayerExists(summonerId))
                throw new InvalidOperationException($"Player {summonerId} already exists");

            _players.Add(summonerId, player);
        }

        public bool PlayerExists(ulong summonerId)
        {
            return _players.ContainsKey(summonerId);
        }

        public IPlayer GetPlayer(ulong summonerId)
        {
            if (!PlayerExists(summonerId))
                throw new InvalidOperationException($"Player {summonerId} does not exist.");

            return _players[summonerId];
        }

        public IEnumerable<IPlayer> GetAllPlayers()
        {
            return _players.Values.ToList();
        }
    }
}
