﻿using System;
using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
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

        public void NotifyKeyCheck(ulong targetSummonerId, ulong summonerId, int clientId, uint versionNo, ulong checkId)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteKeyCheckResponse(summonerId, clientId, versionNo, checkId);
            SendPacket(targetUser, data, Channel.Default);
        }

        public void NotifyQueryStatus(ulong targetSummonerId)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteNotifyQueryStatus();
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifySynchVersion(ulong targetSummonerId, bool versionMatches, MapType mapId, IEnumerable<IObjAiHero> players, string version)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteSynchVersion(versionMatches, mapId, players, version);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyPingLoadInfo(PingLoadInfoRequest request)
        {
            var data = _packetWriter.WritePingLoadInfo(request.SenderNetId, request.ClientId, request.SummonerId, request.Percentage, request.ETA, request.Count, request.Ping, request.Ready);
            BroadcastPacket(data, Channel.BroadcastUnreliable);
        }

        public void NotifyTeamRosterUpdate(ulong targetSummonerId, IEnumerable<IObjAiHero> players)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteTeamRosterUpdate(players);
            SendPacket(targetUser, data, Channel.LoadingScreen);
        }

        public void NotifyRename(ulong targetSummonerId, ulong summonerId, int skinId, string playerName)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteRename(summonerId, skinId, playerName);
            SendPacket(targetUser, data, Channel.LoadingScreen);
        }

        public void NotifyReskin(ulong targetSummonerId, ulong summonerId, int skinId, string skinName)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteReskin(summonerId, skinId, skinName);
            SendPacket(targetUser, data, Channel.LoadingScreen);
        }

        public void SendPacket(NetworkUser user, byte[] source, Channel channel)
        {
            var data = EncryptIfNeeded(source);
            user.Peer.Send((byte)channel, data);
        }

        private void BroadcastPacket(byte[] source, Channel channel)
        {
            var users = _usersCache.GetAllUsers();
            foreach (var user in users)
            {
                var data = EncryptIfNeeded(source);
                user.Peer.Send((byte)channel, data);
            }
        }

        private byte[] EncryptIfNeeded(byte[] source)
        {
            if (source.Length >= 8)
            {
                return _blowfishCrypter.Encipher(source);
            }
            else
            {
                return source;
            }
        }
    }
}