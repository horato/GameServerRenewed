using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class WorldSendCameraServerAction : ServerActionBase<WorldSendCameraRequest>
    {
        protected override void ProcessRequestInternal(ulong senderSummonerId, WorldSendCameraRequest request)
        {
            // Nothing to do atm. Might add zoomhack detection
        }
    }
}
