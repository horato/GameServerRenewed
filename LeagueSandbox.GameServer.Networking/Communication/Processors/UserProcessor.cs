using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ENet;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Networking.Users;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal class UserProcessor : IUserProcessor
    {
        private readonly IServerActionProcessor _serverActionProcessor;
        private readonly IUsersCache _usersCache;

        public UserProcessor(IServerActionProcessor serverActionProcessor, IUsersCache usersCache)
        {
            _serverActionProcessor = serverActionProcessor;
            _usersCache = usersCache;
        }

        public void ProcessRequest(Peer peer, IRequestDefinition request)
        {
            var keyCheckRequest = request as KeyCheckRequest;
            if (keyCheckRequest != null)
                _usersCache.AddOrUpdate(keyCheckRequest.SummonerId, peer);

            try
            {
                var sender = _usersCache.FindByPeer(peer);
                if (sender == null)
                    throw new InvalidOperationException($"Failed to find user for peer {peer.Address.host}:{peer.Address.port}");

                _serverActionProcessor.ProcessRequest(sender.SummonerId, request);
                if (keyCheckRequest != null)
                    _usersCache.Commit(keyCheckRequest.SummonerId);
            }
            catch
            {
                if (keyCheckRequest != null)
                    _usersCache.Rollback(keyCheckRequest.SummonerId);

                throw;
            }
        }
    }
}
