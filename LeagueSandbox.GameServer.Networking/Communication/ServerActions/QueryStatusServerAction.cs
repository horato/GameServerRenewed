using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.RequestProcessing.Definitions;
using LeagueSandbox.GameServer.Core.RequestProcessing.ServerActions;

namespace LeagueSandbox.GameServer.Networking.Communication.ServerActions
{
    internal class QueryStatusServerAction : ServerActionBase<QueryStatusRequest>
    {
        private readonly IPacketNotifier _packetNotifier;

        public QueryStatusServerAction(IPacketNotifier packetNotifier)
        {
            _packetNotifier = packetNotifier;
        }

        protected override void ProcessRequestInternal(ulong senderSummonerId, QueryStatusRequest request)
        {
            _packetNotifier.NotifyQueryStatus(senderSummonerId);
        }
    }
}
