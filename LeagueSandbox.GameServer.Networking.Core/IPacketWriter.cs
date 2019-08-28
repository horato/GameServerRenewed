using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Networking.Core
{
    public interface IPacketWriter
    {
        byte[] WriteKeyCheckResponse(ulong summonerId, int clientId);
        byte[] WriteNotifyQueryStatus();
        byte[] WriteSynchVersion(bool versionMatches, MapType mapId, IEnumerable<IObjAiHero> players, string version);
    }
}
