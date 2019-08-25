using ENet;
using LeagueSandbox.GameServer.Core.RequestProcessing;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal interface IUserProcessor
    {
        void ProcessRequest(Peer peer, IRequestDefinition request);
    }
}