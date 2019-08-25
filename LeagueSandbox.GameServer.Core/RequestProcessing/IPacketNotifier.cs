using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.RequestProcessing
{
    public interface IPacketNotifier
    {
        void NotifyKeyCheck(ulong targetSummonerId, ulong summonerId, int clientId);
        void NotifyQueryStatus(ulong targetSummonerId);
    }
}
