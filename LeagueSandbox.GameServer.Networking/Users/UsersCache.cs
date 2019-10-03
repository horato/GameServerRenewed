using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSandbox.GameServer.ENetCS;

namespace LeagueSandbox.GameServer.Networking.Users
{
    internal class UsersCache : IUsersCache
    {
        private readonly IDictionary<ulong, NetworkUser> _newUsers = new Dictionary<ulong, NetworkUser>();
        private readonly IDictionary<ulong, NetworkUser> _usersCache = new Dictionary<ulong, NetworkUser>();

        public void AddOrUpdate(ulong summonerId, Peer peer)
        {
            if (UserExists(summonerId))
                UpdateUser(summonerId, peer);
            else
                AddNewUser(summonerId, peer);
        }

        private void UpdateUser(ulong summonerId, Peer peer)
        {
            if (!UserExists(summonerId))
                throw new InvalidOperationException($"User {summonerId} does not exist.");

            _usersCache[summonerId].UpdatePeer(peer);
        }

        private void AddNewUser(ulong summonerId, Peer peer)
        {
            if (UserExists(summonerId))
                throw new InvalidOperationException($"User {summonerId} already exists");

            _usersCache.Add(summonerId, new NetworkUser(summonerId, peer));
            _newUsers.Add(summonerId, _usersCache[summonerId]);
        }

        private bool UserExists(ulong summonerId)
        {
            return _usersCache.ContainsKey(summonerId);
        }

        public NetworkUser GetUser(ulong summonerId)
        {
            if (!UserExists(summonerId))
                throw new InvalidOperationException($"User {summonerId} does not exist.");

            return _usersCache[summonerId];
        }

        public IEnumerable<NetworkUser> GetAllUsers()
        {
            return _usersCache.Values.ToList();
        }

        public void Commit(ulong summonerId)
        {
            if (!UserExists(summonerId))
                throw new InvalidOperationException($"User {summonerId} does not exist.");

            // If the user is new, there is nothing to commit inside NetworkUser
            if (_newUsers.ContainsKey(summonerId))
            {
                _newUsers.Remove(summonerId);
                return;
            }

            _usersCache[summonerId].Commit();
        }

        public void Rollback(ulong summonerId)
        {
            if (!UserExists(summonerId))
                throw new InvalidOperationException($"User {summonerId} does not exist.");

            // If the user is new, there is nothing to rollback inside NetworkUser
            if (_newUsers.ContainsKey(summonerId))
            {
                _newUsers.Remove(summonerId);
                _usersCache.Remove(summonerId);
                return;
            }

            _usersCache[summonerId].Rollback();
        }

        public NetworkUser FindByPeer(Peer peer)
        {
            return _usersCache.Values.SingleOrDefault(x => x.Peer.Address.Equals(peer.Address));
        }
    }
}
