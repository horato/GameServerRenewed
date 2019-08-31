using System;
using System.Collections.Generic;
using System.IO;
using LeagueSandbox.GameServer.Core.Domain.Entities;
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

        public void NotifySynchVersion(ulong targetSummonerId, bool versionMatches, MapType mapId, IEnumerable<IPlayer> players, string version)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteSynchVersion(versionMatches, mapId, players, version);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyPingLoadInfo(uint senderNetId, ulong senderSummonerId, PingLoadInfoRequest request)
        {
            var data = _packetWriter.WritePingLoadInfo(senderNetId, request.ClientId, senderSummonerId, request.Percentage, request.ETA, request.Count, request.Ping, request.Ready);
            BroadcastPacket(data, Channel.BroadcastUnreliable);
        }

        public void NotifyTeamRosterUpdate(ulong targetSummonerId, IEnumerable<IPlayer> players)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteTeamRosterUpdate(players);
            SendPacket(targetUser, data, Channel.LoadingScreen);
        }

        public void NotifyRename(ulong targetSummonerId, ulong summonerId, int skinId, string playerName)
        {
            // Broadcast?
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteRename(summonerId, skinId, playerName);
            SendPacket(targetUser, data, Channel.LoadingScreen);
        }

        public void NotifyReskin(ulong targetSummonerId, ulong summonerId, int skinId, string skinName)
        {
            // Broadcast?
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteReskin(summonerId, skinId, skinName);
            SendPacket(targetUser, data, Channel.LoadingScreen);
        }

        public void NotifyStartSpawn(ulong targetSummonerId, int blueBotsCount, int redBotsCount)
        {
            var blueCount = checked((byte)blueBotsCount);
            var redCount = checked((byte)redBotsCount);
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteStartSpawn(blueCount, redCount);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyCreateHero(ulong targetSummonerId, IPlayer player)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteCreateHero(player);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyAvatarInfo(ulong targetSummonerId, IPlayer player)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteAvatarInfo(player);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyEndSpawn(ulong targetSummonerId)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteEndSpawn();
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyGameStart(ulong targetSummonerId, bool enablePause, bool broadcast)
        {
            var data = _packetWriter.WriteStartGame(enablePause);
            if (broadcast)
            {
                BroadcastPacket(data, Channel.Broadcast);
            }
            else
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifyCreateTurret(ulong targetSummonerId, IObjAiTurret turret)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteCreateTurret(turret);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyAddRegion(ulong targetSummonerId, IAttackableUnit unit, uint regionNetId)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteAddRegion(unit, regionNetId);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifySpawnLevelProp(ulong targetSummonerId, ILevelPropAI prop)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteSpawnLevelProp(prop);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyEnterVisibilityClient(IEnumerable<ulong> targetSummonerIds, IObjAiBase unit, bool broadcast)
        {
            var data = _packetWriter.WriteOnEnterVisibilityClient(unit);

            var c = unit as IObjAiHero;
            var m = unit as IObjAiMinion;
            if (c == null && m == null)
                return;

            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }

            if (broadcast)
                NotifyEnterLocalVisibilityClient(targetSummonerIds, (IObjAiBase)c ?? m);
        }

        private void NotifyEnterLocalVisibilityClient(IEnumerable<ulong> targetSummonerIds, IObjAiBase unit)
        {
            var data = _packetWriter.WriteOnEnterLocalVisibilityClient(unit);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void SendPacket(NetworkUser user, byte[] source, Channel channel)
        {
            var data = EncryptIfNeeded(source);
            user.Peer.Send((byte)channel, data);
        }

        private void BroadcastPacket(byte[] source, Channel channel, Team? team = null)
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
