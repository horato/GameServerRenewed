using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Networking.Core;
using LeagueSandbox.GameServer.Networking.Core.Encryption;
using LeagueSandbox.GameServer.Networking.Core.Enums;
using LeagueSandbox.GameServer.Networking.Users;
using MoreLinq.Extensions;
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

        public void NotifyPingLoadInfo(uint senderNetId, int senderClientId, ulong senderSummonerId, PingLoadInfoRequest request)
        {
            var data = _packetWriter.WritePingLoadInfo(senderNetId, senderClientId, senderSummonerId, request.Percentage, request.ETA, request.Count, request.Ping, request.Ready);
            BroadcastPacket(data, Channel.Broadcast);
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

        public void NotifyEnterVisibilityClient(IEnumerable<ulong> targetSummonerIds, IAttackableUnit unit)
        {
            var data = _packetWriter.WriteOnEnterVisibilityClient(unit);

            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }

            if (targetSummonerIds.Count() > 1)
                NotifyEnterLocalVisibilityClient(targetSummonerIds, unit);
        }

        public void NotifyEnterLocalVisibilityClient(IEnumerable<ulong> targetSummonerIds, IAttackableUnit unit)
        {
            var data = _packetWriter.WriteOnEnterLocalVisibilityClient(unit);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifySynchSimTime(ulong targetSummonerId, float simTimeMilliseconds)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteSynchSimTime(simTimeMilliseconds);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifySyncMissionTime(ulong targetSummonerId, float missionTimeMilliseconds)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteSyncMissionTime(missionTimeMilliseconds);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyTipUpdate(ulong targetSummonerId, string tipHeader, string tipText, string tipImagePath, TipCommand tipCommand, uint targetNetId, uint tipId)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteHandleTipUpdate(tipHeader, tipText, tipImagePath, tipCommand, tipId, targetNetId);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyMapPing(IEnumerable<ulong> targetSummonerIds, Vector2 position, uint targetNetId, uint sourceNetId, PingCategory pingCategory, bool playAudio, bool showChat, bool pingThrottled, bool playVo)
        {
            var data = _packetWriter.WriteMapPing(position, targetNetId, sourceNetId, pingCategory, playAudio, showChat, pingThrottled, playVo);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.BroadcastUnreliable);
            }
        }

        public void NotifyWaypointGroup(IEnumerable<ulong> targetSummonerIds, IEnumerable<IGameObject> gameObjects, Vector2 mapCenter)
        {
            var data = _packetWriter.WriteWaypointGroup(gameObjects, mapCenter);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifyReplication(IEnumerable<ulong> targetSummonerIds, IEnumerable<IAttackableUnit> gameObjects)
        {
            var batches = gameObjects.Where(IsReplicating).Batch(0xFF);
            foreach (var subSet in batches)
            {
                var data = _packetWriter.WriteReplication(subSet);
                foreach (var targetSummonerId in targetSummonerIds)
                {
                    var targetUser = _usersCache.GetUser(targetSummonerId);
                    SendPacket(targetUser, data, Channel.Broadcast);
                }
            }
        }

        private bool IsReplicating(IAttackableUnit unit)
        {
            switch (unit)
            {
                case IObjAiHero _:
                case IObjAnimatedBuilding _:
                case IObjAiTurret _:
                case IObjAiMinion _:
                    return true;
                case ILevelPropAI _:
                case IObjAiBase _:
                case IObjShop _:
                case IObjSpawnPoint _:
                case IObjBuilding _:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }
        }

        public void NotifySetCooldown(ulong targetSummonerId, IObjAiBase owner, ISpellInstance spell)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteSetCooldown(owner, spell);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifySkillUp(ulong targetSummonerId, IObjAiBase owner, ISpell spell)
        {
            var targetUser = _usersCache.GetUser(targetSummonerId);
            var data = _packetWriter.WriteSkillUp(owner, spell);
            SendPacket(targetUser, data, Channel.Broadcast);
        }

        public void NotifyCastSpellAns(IEnumerable<ulong> targetSummonerIds, IObjAiBase caster, ISpellInstance spell)
        {
            var data = _packetWriter.WriteCastSpellAns(caster, spell);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifyMissileReplication(IEnumerable<ulong> targetSummonerIds, IMissile missile)
        {
            var data = _packetWriter.WriteMissileReplication(missile);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifyDestroyMissile(IEnumerable<ulong> targetSummonerIds, IMissile missile)
        {
            var data = _packetWriter.WriteDestroyMissile(missile);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifyLevelUp(IEnumerable<ulong> targetSummonerIds, IObjAiHero hero)
        {
            var data = _packetWriter.WriteLevelUp(hero);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifyMinionSpawn(IEnumerable<ulong> targetSummonerIds, IObjAiMinion minion)
        {
            var data = _packetWriter.WriteMinionSpawn(minion);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifySynchSimTimeFinal(ulong targetSummonerId, uint netId, float timeLastClientMilliseconds, float timeRttLastOverheadMilliseconds, float timeConvergenceMilliseconds)
        {
            var data = _packetWriter.WriteSynchSimTimeFinal(netId, timeLastClientMilliseconds, timeRttLastOverheadMilliseconds, timeConvergenceMilliseconds);
            var targetUser = _usersCache.GetUser(targetSummonerId);
            SendPacket(targetUser, data, Channel.SynchClock);
        }

        public void WriteChatMessage(IEnumerable<ulong> targetSummonerIds, int clientId, uint netId, bool localized, ChatType chatType, string @params, string message)
        {
            var data = _packetWriter.WriteChatMessage(clientId, netId, localized, chatType, @params, message);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Chat);
            }
        }

        public void NotifyAutoAttackStart(IEnumerable<ulong> targetSummonerIds, IObjAiBase gameObject, uint projectileNetId)
        {
            var data = _packetWriter.WriteAutoAttackStart(gameObject, projectileNetId);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }
        
        public void NotifyAutoAttack(IEnumerable<ulong> targetSummonerIds, IObjAiBase gameObject, uint projectileNetId)
        {
            var data = _packetWriter.WriteAutoAttack(gameObject, projectileNetId);
            foreach (var targetSummonerId in targetSummonerIds)
            {
                var targetUser = _usersCache.GetUser(targetSummonerId);
                SendPacket(targetUser, data, Channel.Broadcast);
            }
        }

        public void NotifyUnitSetLookAt(IEnumerable<ulong> targetSummonerIds, IObjAiBase unit, IAttackableUnit target)
        {
            var data = _packetWriter.WriteUnitSetLookAt(unit, target);
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
