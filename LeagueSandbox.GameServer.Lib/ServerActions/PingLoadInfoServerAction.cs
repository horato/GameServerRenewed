using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;

namespace LeagueSandbox.GameServer.Lib.ServerActions
{
    internal class PingLoadInfoServerAction : ServerActionBase<PingLoadInfoRequest>
    {
        private readonly IPacketNotifier _packetNotifier;

        public PingLoadInfoServerAction(IPacketNotifier packetNotifier)
        {
            _packetNotifier = packetNotifier;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, PingLoadInfoRequest request)
        {
            _packetNotifier.NotifyPingLoadInfo(request);
        }
    }
}
