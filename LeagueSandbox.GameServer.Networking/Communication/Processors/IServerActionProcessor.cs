using LeagueSandbox.GameServer.Core.RequestProcessing;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal interface IServerActionProcessor
    {
        void ProcessRequest(ulong senderSummonerId, IRequestDefinition request);
    }
}