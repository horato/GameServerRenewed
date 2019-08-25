using System;
using System.Collections.Generic;
using System.Text;
using ENet;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Core.Encryption;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Users;
using Unity;

namespace LeagueSandbox.GameServer.Networking.Communication
{
    public class PacketNotifier : IPacketNotifier
    {
        private readonly IUsersCache _usersCache;
        private readonly IPacketWriter _packetWriter;
        private readonly IBlowfishCrypter _blowfishCrypter;

        public PacketNotifier(IUnityContainer container, IPacketWriter packetWriter, IBlowfishCrypter blowfishCrypter)
        {
            _packetWriter = packetWriter;
            _blowfishCrypter = blowfishCrypter;
            _usersCache = container.Resolve<IUsersCache>();
        }

        public void NotifyKeyCheck(ulong targetSummonerId, ulong summonerId, int clientId)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteKeyCheckResponse(summonerId, clientId);
            SendPacket(targetUser, data, Channel.Handshake);
        }

        public void NotifyQueryStatus(ulong targetSummonerId)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteNotifyQueryStatus();
            SendPacket(targetUser, data, Channel.S2C);
        }

        public bool SendPacket(NetworkUser user, byte[] source, Channel channelNo)
        {
            byte[] data;
            if (source.Length >= 8)
            {
                data = _blowfishCrypter.Encipher(source);
            }
            else
            {
                data = source;
            }

            return user.Peer.Send((byte)channelNo, data);
        }
    }
}
