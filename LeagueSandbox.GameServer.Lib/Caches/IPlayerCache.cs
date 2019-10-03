using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities;

namespace LeagueSandbox.GameServer.Lib.Caches
{
    internal interface IPlayerCache
    {
        void Add(ulong summonerId, IPlayer player);
        bool PlayerExists(ulong summonerId);
        IPlayer GetPlayer(ulong summonerId);
        IEnumerable<IPlayer> GetAllPlayers();
    }
}