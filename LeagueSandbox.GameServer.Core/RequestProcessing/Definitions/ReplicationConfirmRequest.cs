using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class ReplicationConfirmRequest : RequestDefinition
    {
        public uint NetId { get; }
        public uint SyncID { get; }

        public ReplicationConfirmRequest(uint netId, uint syncId)
        {
            NetId = netId;
            SyncID = syncId;
        }
    }
}
