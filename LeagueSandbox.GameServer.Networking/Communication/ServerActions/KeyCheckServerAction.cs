using System;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;
using LeagueSandbox.GameServer.Networking.Core.Encryption;
using LeagueSandbox.GameServer.Networking.Users;

namespace LeagueSandbox.GameServer.Networking.Communication.ServerActions
{
    internal class KeyCheckServerAction : ServerActionBase<KeyCheckRequest>
    {
        private readonly IBlowfishCrypter _blowfishCrypter;
        private readonly IPacketNotifier _packetNotifier;
        private readonly IUsersCache _usersCache;

        public KeyCheckServerAction(IBlowfishCrypter blowfishCrypter, IPacketNotifier packetNotifier, IUsersCache usersCache)
        {
            _blowfishCrypter = blowfishCrypter;
            _packetNotifier = packetNotifier;
            _usersCache = usersCache;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, KeyCheckRequest request)
        {
            var summonerId = _blowfishCrypter.Decipher(request.CheckId);
            if (summonerId != request.SummonerId)
                throw new InvalidOperationException("Blowfish check failed.");

            var users = _usersCache.GetAllUsers();
            foreach (var user in users)
            {
                _packetNotifier.NotifyKeyCheck(senderSummonerId, user.SummonerId, user.ClientId, request.VersionNo, request.CheckId);
            }
        }
    }
}
