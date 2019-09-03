using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class WaypointAccServerAction : ServerActionBase<WaypointAccRequest>
    {
        protected override void ProcessRequestInternal(ulong senderSummonerId, WaypointAccRequest request)
        {
            // TODO: do something?
        }
    }
}
