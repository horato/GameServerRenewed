using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;

namespace LeagueSandbox.GameServer.Core.RequestProcessing
{
    public interface IPacketNotifier
    {
        void NotifyKeyCheck(ulong senderSummonerId, ulong userSummonerId, int userClientId, uint versionNo, ulong checkId);
        void NotifyQueryStatus(ulong targetSummonerId);
        void NotifySynchVersion(ulong targetSummonerId, bool versionMatches, MapType mapId, IEnumerable<IPlayer> players, string version);
        void NotifyPingLoadInfo(uint senderNetId, ulong senderSummonerId, PingLoadInfoRequest request);
        void NotifyTeamRosterUpdate(ulong targetSummonerId, IEnumerable<IPlayer> players);
        void NotifyRename(ulong targetSummonerId, ulong summonerId, int skinId, string playerName);
        void NotifyReskin(ulong targetSummonerId, ulong summonerId, int skinId, string skinName);
        void NotifyStartSpawn(ulong targetSummonerId, int blueBotsCount, int redBotsCount);
        void NotifyCreateHero(ulong targetSummonerId, IPlayer player);
        void NotifyAvatarInfo(ulong targetSummonerId, IPlayer player);
        void NotifyEndSpawn(ulong targetSummonerId);
        void NotifyGameStart(ulong targetSummonerId, bool enablePause, bool broadcast);
        void NotifyCreateTurret(ulong targetSummonerId, IObjAiTurret turret);
        void NotifyAddRegion(ulong targetSummonerId, IAttackableUnit unit, uint regionNetId);
        void NotifySpawnLevelProp(ulong targetSummonerId, ILevelPropAI prop);
        void NotifyEnterVisibilityClient(IEnumerable<ulong> targetSummonerIds, IAttackableUnit unit);
        void NotifyEnterLocalVisibilityClient(IEnumerable<ulong> targetSummonerIds, IAttackableUnit unit);
    }
}
