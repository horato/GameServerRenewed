using LeagueSandbox.GameServer.ENetCS;
using LeagueSandbox.GameServer.Networking.Core.Enums;

namespace LeagueSandbox.GameServer.Networking.Communication.Processors
{
    internal interface IPacketProcessor
    {
        void ProcessRequest(Peer peer, Packet packet, Channel channel);
    }
}