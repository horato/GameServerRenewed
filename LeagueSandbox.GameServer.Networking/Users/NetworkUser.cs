using System;
using System.Collections.Generic;
using System.Text;
using ENet;

namespace LeagueSandbox.GameServer.Networking.Users
{
    public class NetworkUser
    {
        private Peer _stagedPeer;

        public ulong SummonerId { get; }
        public int ClientId { get; }
        public Peer Peer { get; private set; }

        public NetworkUser(ulong summonerId, int clientId, Peer peer)
        {
            SummonerId = summonerId;
            ClientId = clientId;
            Peer = peer;
        }

        internal void UpdatePeer(Peer peer)
        {
            if (_stagedPeer != null)
                throw new InvalidOperationException("Peer is already staged");

            _stagedPeer = peer;
        }

        internal void Commit()
        {
            if (_stagedPeer == null)
                throw new InvalidOperationException("Nothing to commit");

            Peer = _stagedPeer;
            _stagedPeer = null;
        }

        internal void Rollback()
        {
            _stagedPeer = null;
        }
    }
}
