using System.Collections.Generic;
using LeagueSandbox.GameServer.ENetCS;

namespace LeagueSandbox.GameServer.Networking.Users
{
    internal interface IUsersCache
    {
        void AddOrUpdate(ulong summonerId, Peer peer);
        NetworkUser GetUser(ulong summonerId);
        IEnumerable<NetworkUser> GetAllUsers();
        void Commit(ulong summonerId);
        void Rollback(ulong summonerId);
        NetworkUser FindByPeer(Peer peer);
    }
}