using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.ENetCS;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal interface IUserProcessor
    {
        void ProcessRequest(Peer peer, IRequestDefinition request);
    }
}