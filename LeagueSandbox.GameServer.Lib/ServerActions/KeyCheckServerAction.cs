using System;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Networking.Core.Encryption;
using LeagueSandbox.GameServer.Networking.Users;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class KeyCheckServerAction : ServerActionBase<KeyCheckRequest>
    {
        private readonly IBlowfishCrypter _blowfishCrypter;
        private readonly IPacketNotifier _packetNotifier;
        private readonly IPlayerCache _playerCache;
        private readonly IClientIdCreationService _clientIdCreationService;

        public KeyCheckServerAction(IBlowfishCrypter blowfishCrypter, IPacketNotifier packetNotifier, IPlayerCache playerCache, IClientIdCreationService clientIdCreationService)
        {
            _blowfishCrypter = blowfishCrypter;
            _packetNotifier = packetNotifier;
            _playerCache = playerCache;
            _clientIdCreationService = clientIdCreationService;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, KeyCheckRequest request)
        {
            var summonerId = _blowfishCrypter.Decipher(request.CheckId);
            if (summonerId != request.SummonerId)
                throw new InvalidOperationException("Blowfish check failed.");
            if (!_playerCache.PlayerExists(senderSummonerId))
                throw new InvalidOperationException($"Attempted connection from unknown client {senderSummonerId}");

            var player = _playerCache.GetPlayer(senderSummonerId);
            if (player.Champion.IsPlayerControlled)
                throw new InvalidOperationException($"Champion {player.Champion.NetId} is already player controlled");

            var clientId = _clientIdCreationService.GetNewId();
            player.Champion.EnablePlayerControl(clientId);

            var users = _playerCache.GetAllPlayers();
            foreach (var user in users)
            {
                _packetNotifier.NotifyKeyCheck(senderSummonerId, user.SummonerId, user.Champion.ClientId, request.VersionNo, request.CheckId);
            }
        }
    }
}
