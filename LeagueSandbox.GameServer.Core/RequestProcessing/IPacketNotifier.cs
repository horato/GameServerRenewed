using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;

namespace LeagueSandbox.GameServer.Core.RequestProcessing
{
    public interface IPacketNotifier
    {
        void NotifyKeyCheck(ulong senderSummonerId, ulong userSummonerId, int userClientId, uint versionNo, ulong checkId);
        void NotifyQueryStatus(ulong targetSummonerId);
        void NotifySynchVersion(ulong targetSummonerId, bool versionMatches, MapType mapId, IEnumerable<IObjAiHero> players, string version);
        void NotifyPingLoadInfo(PingLoadInfoRequest request);
        void NotifyTeamRosterUpdate(ulong targetSummonerId, IEnumerable<IObjAiHero> players);
        void NotifyRename(ulong targetSummonerId, ulong summonerId, int skinId, string playerName);
        void NotifyReskin(ulong targetSummonerId, ulong summonerId, int skinId, string skinName);
    }
}
