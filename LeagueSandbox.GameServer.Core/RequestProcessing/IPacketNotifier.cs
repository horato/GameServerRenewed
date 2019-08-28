using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.RequestProcessing
{
    public interface IPacketNotifier
    {
        void NotifyKeyCheck(ulong targetSummonerId, ulong summonerId, int clientId);
        void NotifyQueryStatus(ulong targetSummonerId);
        void NotifySynchVersion(ulong targetSummonerId, bool versionMatches, MapType mapId, IEnumerable<IObjAiHero> players, string version);
    }
}
