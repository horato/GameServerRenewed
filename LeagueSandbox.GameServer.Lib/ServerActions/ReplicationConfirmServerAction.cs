using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class ReplicationConfirmServerAction : ServerActionBase<ReplicationConfirmRequest>
    {
        protected override void ProcessRequestInternal(ulong senderSummonerId, ReplicationConfirmRequest request)
        {
            // nothing?
        }
    }
}
