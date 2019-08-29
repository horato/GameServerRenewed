﻿using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Networking.Core
{
    public interface IPacketWriter
    {
        byte[] WriteKeyCheckResponse(ulong summonerId, int clientId, uint versionNo, ulong checkId);
        byte[] WriteNotifyQueryStatus();
        byte[] WriteSynchVersion(bool versionMatches, MapType mapId, IEnumerable<IPlayer> players, string version);
        byte[] WritePingLoadInfo(uint netId, int clientId, ulong summonerId, float loadedPercent, float eta, ushort count, ushort ping, bool isReady);
        byte[] WriteTeamRosterUpdate(IEnumerable<IPlayer> players);
        byte[] WriteRename(ulong playerId, int skinId, string playerName);
        byte[] WriteReskin(ulong summonerId, int skinId, string skinName);
    }
}
